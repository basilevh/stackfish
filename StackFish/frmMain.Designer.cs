namespace StackFish
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initialStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepBackwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblExec = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblAuthor = new System.Windows.Forms.ToolStripStatusLabel();
            this.rtbFile = new System.Windows.Forms.RichTextBox();
            this.grpRegs = new System.Windows.Forms.GroupBox();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.lblSign = new System.Windows.Forms.Label();
            this.txtOverflow = new System.Windows.Forms.TextBox();
            this.lblOverflow = new System.Windows.Forms.Label();
            this.txtParity = new System.Windows.Forms.TextBox();
            this.lblParity = new System.Windows.Forms.Label();
            this.txtZero = new System.Windows.Forms.TextBox();
            this.lblZero = new System.Windows.Forms.Label();
            this.txtCarry = new System.Windows.Forms.TextBox();
            this.lblCarry = new System.Windows.Forms.Label();
            this.txtEBP = new System.Windows.Forms.TextBox();
            this.lblEBP = new System.Windows.Forms.Label();
            this.txtESP = new System.Windows.Forms.TextBox();
            this.lblESP = new System.Windows.Forms.Label();
            this.txtEDX = new System.Windows.Forms.TextBox();
            this.lblEDX = new System.Windows.Forms.Label();
            this.txtECX = new System.Windows.Forms.TextBox();
            this.lblECX = new System.Windows.Forms.Label();
            this.txtEBX = new System.Windows.Forms.TextBox();
            this.lblEBX = new System.Windows.Forms.Label();
            this.txtEAX = new System.Windows.Forms.TextBox();
            this.lblEAX = new System.Windows.Forms.Label();
            this.grpStack = new System.Windows.Forms.GroupBox();
            this.txtStack = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.grpRegs.SuspendLayout();
            this.grpStack.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.startToolStripMenuItem,
            this.runningToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.menuStrip.Size = new System.Drawing.Size(838, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initialStateToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // initialStateToolStripMenuItem
            // 
            this.initialStateToolStripMenuItem.Name = "initialStateToolStripMenuItem";
            this.initialStateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.initialStateToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.initialStateToolStripMenuItem.Text = "&Initial stack...";
            this.initialStateToolStripMenuItem.Click += new System.EventHandler(this.initialStateToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 22);
            this.startToolStripMenuItem.Text = "&Start";
            // 
            // runningToolStripMenuItem
            // 
            this.runningToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stepForwardToolStripMenuItem,
            this.stepBackwardToolStripMenuItem,
            this.toolStripSeparator2,
            this.stopToolStripMenuItem});
            this.runningToolStripMenuItem.Name = "runningToolStripMenuItem";
            this.runningToolStripMenuItem.Size = new System.Drawing.Size(64, 22);
            this.runningToolStripMenuItem.Text = "&Running";
            this.runningToolStripMenuItem.Visible = false;
            // 
            // stepForwardToolStripMenuItem
            // 
            this.stepForwardToolStripMenuItem.Name = "stepForwardToolStripMenuItem";
            this.stepForwardToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.stepForwardToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.stepForwardToolStripMenuItem.Text = "Step &Forward";
            this.stepForwardToolStripMenuItem.Click += new System.EventHandler(this.stepForwardToolStripMenuItem_Click);
            // 
            // stepBackwardToolStripMenuItem
            // 
            this.stepBackwardToolStripMenuItem.Name = "stepBackwardToolStripMenuItem";
            this.stepBackwardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.stepBackwardToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.stepBackwardToolStripMenuItem.Text = "Step &Backward";
            this.stepBackwardToolStripMenuItem.Click += new System.EventHandler(this.stepBackwardToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.stopToolStripMenuItem.Text = "&Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblStatus,
            this.tslblExec,
            this.tslblAuthor});
            this.statusStrip.Location = new System.Drawing.Point(0, 520);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.statusStrip.Size = new System.Drawing.Size(838, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "Status";
            // 
            // tslblStatus
            // 
            this.tlblStatus.Name = "tslblStatus";
            this.tlblStatus.Size = new System.Drawing.Size(703, 17);
            this.tlblStatus.Spring = true;
            this.tlblStatus.Text = "Status";
            this.tlblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tslblExec
            // 
            this.tslblExec.Name = "tslblExec";
            this.tslblExec.Size = new System.Drawing.Size(0, 17);
            // 
            // tslblAuthor
            // 
            this.tslblAuthor.ForeColor = System.Drawing.Color.Gray;
            this.tslblAuthor.Margin = new System.Windows.Forms.Padding(0, 3, 12, 2);
            this.tslblAuthor.Name = "tslblAuthor";
            this.tslblAuthor.Size = new System.Drawing.Size(118, 17);
            this.tslblAuthor.Text = "© Basile Van Hoorick";
            this.tslblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rtbFile
            // 
            this.rtbFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbFile.BackColor = System.Drawing.Color.White;
            this.rtbFile.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbFile.ForeColor = System.Drawing.Color.Black;
            this.rtbFile.Location = new System.Drawing.Point(10, 25);
            this.rtbFile.Margin = new System.Windows.Forms.Padding(1);
            this.rtbFile.Name = "rtbFile";
            this.rtbFile.ReadOnly = true;
            this.rtbFile.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbFile.Size = new System.Drawing.Size(374, 494);
            this.rtbFile.TabIndex = 3;
            this.rtbFile.Text = "";
            // 
            // grpRegs
            // 
            this.grpRegs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRegs.Controls.Add(this.txtSign);
            this.grpRegs.Controls.Add(this.lblSign);
            this.grpRegs.Controls.Add(this.txtOverflow);
            this.grpRegs.Controls.Add(this.lblOverflow);
            this.grpRegs.Controls.Add(this.txtParity);
            this.grpRegs.Controls.Add(this.lblParity);
            this.grpRegs.Controls.Add(this.txtZero);
            this.grpRegs.Controls.Add(this.lblZero);
            this.grpRegs.Controls.Add(this.txtCarry);
            this.grpRegs.Controls.Add(this.lblCarry);
            this.grpRegs.Controls.Add(this.txtEBP);
            this.grpRegs.Controls.Add(this.lblEBP);
            this.grpRegs.Controls.Add(this.txtESP);
            this.grpRegs.Controls.Add(this.lblESP);
            this.grpRegs.Controls.Add(this.txtEDX);
            this.grpRegs.Controls.Add(this.lblEDX);
            this.grpRegs.Controls.Add(this.txtECX);
            this.grpRegs.Controls.Add(this.lblECX);
            this.grpRegs.Controls.Add(this.txtEBX);
            this.grpRegs.Controls.Add(this.lblEBX);
            this.grpRegs.Controls.Add(this.txtEAX);
            this.grpRegs.Controls.Add(this.lblEAX);
            this.grpRegs.Location = new System.Drawing.Point(388, 27);
            this.grpRegs.Name = "grpRegs";
            this.grpRegs.Size = new System.Drawing.Size(438, 227);
            this.grpRegs.TabIndex = 4;
            this.grpRegs.TabStop = false;
            this.grpRegs.Text = "Registers && Flags";
            // 
            // txtSign
            // 
            this.txtSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSign.BackColor = System.Drawing.SystemColors.Window;
            this.txtSign.Location = new System.Drawing.Point(64, 201);
            this.txtSign.Name = "txtSign";
            this.txtSign.ReadOnly = true;
            this.txtSign.Size = new System.Drawing.Size(72, 20);
            this.txtSign.TabIndex = 21;
            // 
            // lblSign
            // 
            this.lblSign.AutoSize = true;
            this.lblSign.Location = new System.Drawing.Point(6, 204);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(31, 13);
            this.lblSign.TabIndex = 20;
            this.lblSign.Text = "Sign:";
            // 
            // txtOverflow
            // 
            this.txtOverflow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOverflow.BackColor = System.Drawing.SystemColors.Window;
            this.txtOverflow.Location = new System.Drawing.Point(212, 175);
            this.txtOverflow.Name = "txtOverflow";
            this.txtOverflow.ReadOnly = true;
            this.txtOverflow.Size = new System.Drawing.Size(72, 20);
            this.txtOverflow.TabIndex = 19;
            // 
            // lblOverflow
            // 
            this.lblOverflow.AutoSize = true;
            this.lblOverflow.Location = new System.Drawing.Point(154, 178);
            this.lblOverflow.Name = "lblOverflow";
            this.lblOverflow.Size = new System.Drawing.Size(52, 13);
            this.lblOverflow.TabIndex = 18;
            this.lblOverflow.Text = "Overflow:";
            // 
            // txtParity
            // 
            this.txtParity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParity.BackColor = System.Drawing.SystemColors.Window;
            this.txtParity.Enabled = false;
            this.txtParity.Location = new System.Drawing.Point(360, 175);
            this.txtParity.Name = "txtParity";
            this.txtParity.ReadOnly = true;
            this.txtParity.Size = new System.Drawing.Size(72, 20);
            this.txtParity.TabIndex = 17;
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Enabled = false;
            this.lblParity.Location = new System.Drawing.Point(302, 178);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(36, 13);
            this.lblParity.TabIndex = 16;
            this.lblParity.Text = "Parity:";
            // 
            // txtZero
            // 
            this.txtZero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZero.BackColor = System.Drawing.SystemColors.Window;
            this.txtZero.Location = new System.Drawing.Point(212, 201);
            this.txtZero.Name = "txtZero";
            this.txtZero.ReadOnly = true;
            this.txtZero.Size = new System.Drawing.Size(72, 20);
            this.txtZero.TabIndex = 15;
            // 
            // lblZero
            // 
            this.lblZero.AutoSize = true;
            this.lblZero.Location = new System.Drawing.Point(154, 204);
            this.lblZero.Name = "lblZero";
            this.lblZero.Size = new System.Drawing.Size(32, 13);
            this.lblZero.TabIndex = 14;
            this.lblZero.Text = "Zero:";
            // 
            // txtCarry
            // 
            this.txtCarry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCarry.BackColor = System.Drawing.SystemColors.Window;
            this.txtCarry.Enabled = false;
            this.txtCarry.Location = new System.Drawing.Point(64, 175);
            this.txtCarry.Name = "txtCarry";
            this.txtCarry.ReadOnly = true;
            this.txtCarry.Size = new System.Drawing.Size(72, 20);
            this.txtCarry.TabIndex = 13;
            // 
            // lblCarry
            // 
            this.lblCarry.AutoSize = true;
            this.lblCarry.Enabled = false;
            this.lblCarry.Location = new System.Drawing.Point(6, 178);
            this.lblCarry.Name = "lblCarry";
            this.lblCarry.Size = new System.Drawing.Size(34, 13);
            this.lblCarry.TabIndex = 12;
            this.lblCarry.Text = "Carry:";
            // 
            // txtEBP
            // 
            this.txtEBP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEBP.BackColor = System.Drawing.SystemColors.Window;
            this.txtEBP.Location = new System.Drawing.Point(64, 149);
            this.txtEBP.Name = "txtEBP";
            this.txtEBP.ReadOnly = true;
            this.txtEBP.Size = new System.Drawing.Size(368, 20);
            this.txtEBP.TabIndex = 11;
            // 
            // lblEBP
            // 
            this.lblEBP.AutoSize = true;
            this.lblEBP.Location = new System.Drawing.Point(6, 152);
            this.lblEBP.Name = "lblEBP";
            this.lblEBP.Size = new System.Drawing.Size(31, 13);
            this.lblEBP.TabIndex = 10;
            this.lblEBP.Text = "EBP:";
            // 
            // txtESP
            // 
            this.txtESP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtESP.BackColor = System.Drawing.SystemColors.Window;
            this.txtESP.Location = new System.Drawing.Point(64, 123);
            this.txtESP.Name = "txtESP";
            this.txtESP.ReadOnly = true;
            this.txtESP.Size = new System.Drawing.Size(368, 20);
            this.txtESP.TabIndex = 9;
            // 
            // lblESP
            // 
            this.lblESP.AutoSize = true;
            this.lblESP.Location = new System.Drawing.Point(6, 126);
            this.lblESP.Name = "lblESP";
            this.lblESP.Size = new System.Drawing.Size(31, 13);
            this.lblESP.TabIndex = 8;
            this.lblESP.Text = "ESP:";
            // 
            // txtEDX
            // 
            this.txtEDX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEDX.BackColor = System.Drawing.SystemColors.Window;
            this.txtEDX.Location = new System.Drawing.Point(64, 97);
            this.txtEDX.Name = "txtEDX";
            this.txtEDX.ReadOnly = true;
            this.txtEDX.Size = new System.Drawing.Size(368, 20);
            this.txtEDX.TabIndex = 7;
            // 
            // lblEDX
            // 
            this.lblEDX.AutoSize = true;
            this.lblEDX.Location = new System.Drawing.Point(6, 100);
            this.lblEDX.Name = "lblEDX";
            this.lblEDX.Size = new System.Drawing.Size(32, 13);
            this.lblEDX.TabIndex = 6;
            this.lblEDX.Text = "EDX:";
            // 
            // txtECX
            // 
            this.txtECX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtECX.BackColor = System.Drawing.SystemColors.Window;
            this.txtECX.Location = new System.Drawing.Point(64, 71);
            this.txtECX.Name = "txtECX";
            this.txtECX.ReadOnly = true;
            this.txtECX.Size = new System.Drawing.Size(368, 20);
            this.txtECX.TabIndex = 5;
            // 
            // lblECX
            // 
            this.lblECX.AutoSize = true;
            this.lblECX.Location = new System.Drawing.Point(6, 74);
            this.lblECX.Name = "lblECX";
            this.lblECX.Size = new System.Drawing.Size(31, 13);
            this.lblECX.TabIndex = 4;
            this.lblECX.Text = "ECX:";
            // 
            // txtEBX
            // 
            this.txtEBX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEBX.BackColor = System.Drawing.SystemColors.Window;
            this.txtEBX.Location = new System.Drawing.Point(64, 45);
            this.txtEBX.Name = "txtEBX";
            this.txtEBX.ReadOnly = true;
            this.txtEBX.Size = new System.Drawing.Size(368, 20);
            this.txtEBX.TabIndex = 3;
            // 
            // lblEBX
            // 
            this.lblEBX.AutoSize = true;
            this.lblEBX.Location = new System.Drawing.Point(6, 48);
            this.lblEBX.Name = "lblEBX";
            this.lblEBX.Size = new System.Drawing.Size(31, 13);
            this.lblEBX.TabIndex = 2;
            this.lblEBX.Text = "EBX:";
            // 
            // txtEAX
            // 
            this.txtEAX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEAX.BackColor = System.Drawing.SystemColors.Window;
            this.txtEAX.Location = new System.Drawing.Point(64, 19);
            this.txtEAX.Name = "txtEAX";
            this.txtEAX.ReadOnly = true;
            this.txtEAX.Size = new System.Drawing.Size(368, 20);
            this.txtEAX.TabIndex = 1;
            // 
            // lblEAX
            // 
            this.lblEAX.AutoSize = true;
            this.lblEAX.Location = new System.Drawing.Point(6, 22);
            this.lblEAX.Name = "lblEAX";
            this.lblEAX.Size = new System.Drawing.Size(31, 13);
            this.lblEAX.TabIndex = 0;
            this.lblEAX.Text = "EAX:";
            // 
            // grpStack
            // 
            this.grpStack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStack.Controls.Add(this.txtStack);
            this.grpStack.Location = new System.Drawing.Point(388, 263);
            this.grpStack.Name = "grpStack";
            this.grpStack.Size = new System.Drawing.Size(438, 254);
            this.grpStack.TabIndex = 5;
            this.grpStack.TabStop = false;
            this.grpStack.Text = "Stack";
            // 
            // txtStack
            // 
            this.txtStack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStack.BackColor = System.Drawing.SystemColors.Window;
            this.txtStack.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStack.Location = new System.Drawing.Point(6, 19);
            this.txtStack.Multiline = true;
            this.txtStack.Name = "txtStack";
            this.txtStack.ReadOnly = true;
            this.txtStack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStack.Size = new System.Drawing.Size(426, 229);
            this.txtStack.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 542);
            this.Controls.Add(this.grpStack);
            this.Controls.Add(this.grpRegs);
            this.Controls.Add(this.rtbFile);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "frmMain";
            this.Text = "Stack Simulator 1.0.4";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grpRegs.ResumeLayout(false);
            this.grpRegs.PerformLayout();
            this.grpStack.ResumeLayout(false);
            this.grpStack.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tlblStatus;
        private System.Windows.Forms.RichTextBox rtbFile;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initialStateToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpRegs;
        private System.Windows.Forms.TextBox txtEBP;
        private System.Windows.Forms.Label lblEBP;
        private System.Windows.Forms.TextBox txtESP;
        private System.Windows.Forms.Label lblESP;
        private System.Windows.Forms.TextBox txtEDX;
        private System.Windows.Forms.Label lblEDX;
        private System.Windows.Forms.TextBox txtECX;
        private System.Windows.Forms.Label lblECX;
        private System.Windows.Forms.TextBox txtEBX;
        private System.Windows.Forms.Label lblEBX;
        private System.Windows.Forms.TextBox txtEAX;
        private System.Windows.Forms.Label lblEAX;
        private System.Windows.Forms.GroupBox grpStack;
        private System.Windows.Forms.TextBox txtStack;
        private System.Windows.Forms.ToolStripMenuItem runningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepBackwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tslblAuthor;
        private System.Windows.Forms.Label lblCarry;
        private System.Windows.Forms.TextBox txtCarry;
        private System.Windows.Forms.TextBox txtSign;
        private System.Windows.Forms.Label lblSign;
        private System.Windows.Forms.TextBox txtOverflow;
        private System.Windows.Forms.Label lblOverflow;
        private System.Windows.Forms.TextBox txtParity;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.TextBox txtZero;
        private System.Windows.Forms.Label lblZero;
        private System.Windows.Forms.ToolStripStatusLabel tslblExec;
    }
}

