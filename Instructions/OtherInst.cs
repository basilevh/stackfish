// Started 12-03-2016, Basile Van Hoorick

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackFish.Instructions
{
    public class OtherInst : Instruction
    {
        internal OtherInst(int index, string line, string op, string args)
            : base(index, line, op, args)
        {
        }

        public override bool Execute(Registers regs, Stack stack, ref int index)
        {
            // TODO
            index++;
            return false;
        }
    }
}
