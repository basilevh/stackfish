// Started 12-03-2016, Basile Van Hoorick

using StackFish.StackItems;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StackFish
{
    public partial class frmInitState : Form
    {
        public frmInitState(frmMain main)
        {
            InitializeComponent();
            this.main = main;
            load();
        }

        private frmMain main;

        private void load()
        {
            if (main.InitStack != null)
            {
                string text = "";
                foreach (StackItem item in main.InitStack)
                    text = StringParser.GetString(item) + "\r\n" + text;
                txtInitStack.Text = text;
            }
            else
                txtInitStack.Text = "return|main|depends|-1\r\n4|n|9";
            txtInitStack.Select(0, 0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var newInit = new List<StackItem>();
            foreach (string line in txtInitStack.Lines)
                if (line.Length != 0)
                    newInit.Insert(0, StringParser.FromString(line));
            main.InitStack = newInit;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
