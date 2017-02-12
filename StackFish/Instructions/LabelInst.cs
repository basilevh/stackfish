// Started 12-03-2016, Basile Van Hoorick

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackFish.Instructions
{
    public class LabelInst : Instruction
    {
        internal LabelInst(int index, string line, string op, string args)
            : base(index, line, op, args)
        {
            Name = line.Substring(0, line.IndexOf(':'));
        }

        public string Name
        {
            get;
            private set;
        }

        public override bool Execute(Registers regs, Stack stack, ref int index)
        {
            index++;
            return true;
        }
    }
}
