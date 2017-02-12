// Started 11-03-2016, Basile Van Hoorick

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using StackFish.Instructions;
using StackFish.StackItems;

namespace StackFish
{
    public partial class frmMain : Form
    {
        private readonly static Keys[] FKeys =
            { Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6,
            Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12 };
        private readonly TextBox[] txtMarked; // set bold on change
        private readonly Font defaultFont, changedFont;

        public frmMain()
        {
            DpiAwareness.Set(DpiAwareness.Mode.SystemDpiAware);
            InitializeComponent();
#if DEBUG
            openFile("..\\..\\test.asm");
#else
            openToolStripMenuItem_Click(null, null);
#endif
            BringToFront();

            defaultFont = new Font(txtEAX.Font, FontStyle.Regular);
            changedFont = new Font(txtEAX.Font, FontStyle.Bold);
            txtMarked = new TextBox[] { txtEAX, txtEBX, txtECX, txtEDX, txtESP, txtEBP, txtCarry, txtOverflow, txtParity, txtSign, txtZero };
            foreach (TextBox txt in txtMarked)
                txt.TextChanged += ((sender, e) =>
                {
                    (sender as TextBox).Font = changedFont;
                });
        }

        #region Control Events

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                openFile(dialog.FileName);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void initialStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmInitState(this).ShowDialog(this);
        }

        private void stepForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (simulator != null)
            {
                clearChangedMarks();
                bool result = false;
                bool retry = true;
                while (retry)
                {
                    try
                    {
                        result = simulator.StepForward();
                        retry = false;
                    }
                    catch (Exception ex)
                    {
                        DialogResult dr = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.AbortRetryIgnore,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button3);
                        if (dr == DialogResult.Abort)
                        {
                            stop();
                            return;
                        }
                        else if (dr == DialogResult.Retry)
                            retry = true;
                        else if (dr == DialogResult.Ignore)
                            simulator.Ignore();
                    }
                }
                if (result)
                {
                    executed++; // TODO don't count labels and comments
                    updateExecuted();
                }
            }
        }

        private void stepBackwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (simulator != null)
            {
                clearChangedMarks();
                if (simulator.StepBackward())
                {
                    setStatus("Stepped backwards");
                    executed--;
                    updateExecuted();
                }
                else
                    setStatus("Could not step backwards! Program state history limit reached");
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stop();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAbout().Show();
        }

        private void clearChangedMarks()
        {
            foreach (TextBox txt in txtMarked)
                txt.Font = defaultFont;
        }

        #endregion

        private AssemblyFile file;
        private int[] lineTextIndices; // for efficient RTB formatting..
        internal List<StackItem> InitStack = null;
        private Simulator simulator;
        private int executed;

        private void setStatus(string msg)
        {
            tlblStatus.Text = msg;
        }

        private bool run(LabelInst label)
        {
            if (InitStack == null)
            {
                MessageBox.Show("Initial stack has not been set yet!", "StackFish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Recreate return address to rename callee to current label & set return address -1
            StackItem lastItem = InitStack[InitStack.Count - 1];
            if (lastItem is ReturnAddress)
            {
                ReturnAddress ra = lastItem as ReturnAddress;
                InitStack[InitStack.Count - 1] = new ReturnAddress(ra.CallerName, label.Name, -1);
            }

            // Create simulator
            this.simulator = new Simulator(file, InitStack); // TODO initial registers
            simulator.OnInstructionReady += Simulator_OnInstructionReady;
            simulator.Registers.OnRegisterChanged += Registers_OnRegisterChanged;
            simulator.Registers.OnPointerChanged += Registers_OnPointerChanged;
            simulator.Registers.OnFlagChanged += Registers_OnFlagChanged;
            simulator.Stack.OnStackChanged += Stack_OnStackChanged;
            simulator.Start(label.Index);

            // Update controls
            startToolStripMenuItem.Visible = false;
            runningToolStripMenuItem.Visible = true;
            updateRegisters();
            updateFlags();
            drawStack();
            executed = 0;
            updateExecuted();
            setStatus("Started at " + label.Name + "! Press F5 to step forward, Shift+F5 to step backward");
            return true;
        }

        private void stop()
        {
            simulator = null;
            highlightLine(-1);
            startToolStripMenuItem.Visible = true;
            runningToolStripMenuItem.Visible = false;
            setStatus("Stopped!");
        }

        private bool openFile(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show(path + " does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Parse instructions
            file = new AssemblyFile(path);

            // Initialize code textbox
            loadCodeText();

            // Initialize 'Start' menu
            loadStartMenu();

            // Update status
            setStatus("Successfully loaded " + path + " (" + file.Instructions.Count + " instructions)");
            return true;
        }

        private void loadCodeText()
        {
            lineTextIndices = new int[file.Instructions.Count];
            Font defaultFont = new Font(rtbFile.Font, FontStyle.Regular);
            Font unrecogFont = new Font(rtbFile.Font, FontStyle.Strikeout);
            rtbFile.Clear();
            for (int i = 0; i < file.Instructions.Count; i++)
            {
                Instruction inst = file.Instructions[i];
                rtbFile.SelectionFont = defaultFont;
                if (inst is LabelInst)
                    rtbFile.SelectionColor = Color.Red;
                else if (inst is PushPopInst)
                    rtbFile.SelectionColor = Color.Green;
                else if (inst is JumpInst)
                    rtbFile.SelectionColor = Color.Blue;
                else if (inst is CallReturnInst)
                    rtbFile.SelectionColor = Color.Olive;
                else if (inst is OtherInst) // not recognized -> strikeout
                    rtbFile.SelectionFont = unrecogFont;
                else if (inst is Comment)
                    rtbFile.SelectionColor = Color.Gray;
                else
                    rtbFile.SelectionColor = Color.Black;

                string toAppend = (inst is LabelInst || inst is Comment ? "" : "\t");
                toAppend += inst.Line + "\r\n";
                if (i != 0)
                    lineTextIndices[i] = rtbFile.TextLength;

                rtbFile.AppendText(toAppend);
                rtbFile.ScrollToCaret();
            }
            rtbFile.Select(0, 0);
            rtbFile.ScrollToCaret();
        }

        private void loadStartMenu()
        {
            startToolStripMenuItem.DropDownItems.Clear();
            for (int i = 0; i < file.Labels.Count; i++)
            {
                LabelInst label = file.Labels[i];
                ToolStripMenuItem menuItem = new ToolStripMenuItem(label.Op);
                menuItem.Click += (sender, e) => run(label); // yay for syntactic sugar
                if (i < FKeys.Length)
                    menuItem.ShortcutKeys = Keys.Control | FKeys[i];
                startToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }

        private int hlStart, hlLength;

        private void highlightLine(int index)
        {
            rtbFile.Select(hlStart, hlLength);
            rtbFile.SelectionBackColor = Color.White;
            if (0 <= index && index < lineTextIndices.Length)
            {
                hlStart = lineTextIndices[index];
                hlLength = rtbFile.Lines[index].Length;
                rtbFile.Select(hlStart, hlLength);
                rtbFile.SelectionBackColor = Color.Lime;
            }
            rtbFile.SelectionLength = 0;
        }

        #region Updating

        private void Simulator_OnInstructionReady(int index, bool lastSuccess)
        {
            highlightLine(index);
            if (index == -1)
                setStatus("End of program reached! Press Shift+F5 to step back, F8 to stop");
            else
                setStatus((lastSuccess ? "Success!" : "Fail!") + " Waiting at line " + (index + 1) + "...");
        }

        private void Registers_OnRegisterChanged(Registers.Regs reg, uint value)
        {
            updateRegisters();
        }

        private void Registers_OnFlagChanged(Registers.Flags flag, bool value)
        {
            updateFlags();
        }

        private void Registers_OnPointerChanged(Registers.Regs reg, uint value)
        {
            drawStack();
        }

        private void Stack_OnStackChanged(uint address)
        {
            drawStack();
        }

        private void updateRegisters()
        {
            txtEAX.Text = simulator.Registers.EAX.ToString();
            txtEBX.Text = simulator.Registers.EBX.ToString();
            txtECX.Text = simulator.Registers.ECX.ToString();
            txtEDX.Text = simulator.Registers.EDX.ToString();
            txtESP.Text = simulator.Registers.ESP.ToString();
            txtEBP.Text = simulator.Registers.EBP.ToString();
        }

        private void updateFlags()
        {
            txtCarry.Text = (simulator.Registers.Carry ? "1" : "0");
            txtOverflow.Text = (simulator.Registers.Overflow ? "1" : "0");
            txtParity.Text = (simulator.Registers.Parity ? "1" : "0");
            txtSign.Text = (simulator.Registers.Sign ? "1" : "0");
            txtZero.Text = (simulator.Registers.Zero ? "1" : "0");
        }

        private void drawStack()
        {
            // TODO what if not mod 4?
            uint lowestAddr = simulator.Stack.Items.Keys.Min();
            uint highestAddr = simulator.Stack.Items.Keys.Max();
            // lowestAddr = Math.Min(lowestAddr, simulator.Registers.ESP);
            lowestAddr = simulator.Registers.ESP;
            highestAddr = Math.Max(highestAddr, simulator.Registers.ESP);
            string toSet = "";
            for (uint addr = lowestAddr; addr <= highestAddr; addr += 4)
            {
                StackItem item = simulator.Stack.MemGet(addr);
                string toInsert = fillSpaces(addr + ": ", 8);
                if (item != null)
                {
                    toInsert += fillSpaces(item.Description, 16);
                    if (item is ReturnAddress)
                    {
                        if ((int)item.Value != -1) // not root
                            toInsert += fillSpaces("(line " + (item.Value + 1) + ")", 16);
                    }
                    else
                        toInsert += fillSpaces(item.Value + "", 16);
                }
                toInsert = fillSpaces(toInsert, 8 + 16 + 16);
                if (addr == simulator.Registers.ESP)
                    toInsert += " <- ESP";
                if (addr == simulator.Registers.EBP)
                    toInsert += " <- EBP";
                toSet += toInsert + "\r\n";
            }

            txtStack.Text = toSet;
            txtStack.Select(0, 0);
            txtStack.ScrollToCaret();
        }

        private void updateExecuted()
        {
            tslblExec.Text = "Instructions executed: " + executed;
        }

        private static string fillSpaces(string input, int length)
        {
            while (input.Length < length)
                input += " ";
            return input;
        }

        #endregion
    }
}
