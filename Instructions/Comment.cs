// Started 12-02-2017, Basile Van Hoorick

using System;

namespace StackFish.Instructions
{
    public class Comment : Instruction
    {
        public Comment(int index, string line, string op, string args)
            : base(index, line, op, args)
        { }

        public override bool Execute(Registers regs, Stack stack, ref int index)
        {
            index++;
            return true;
        }
    }
}
