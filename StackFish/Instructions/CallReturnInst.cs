// Started 12-03-2016, Basile Van Hoorick

using StackFish.StackItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackFish.Instructions
{
    public class CallReturnInst : Instruction
    {
        internal CallReturnInst(int index, string line, string op, string args)
            : base(index, line, op, args)
        {
        }

        public Instruction CallDest
        {
            get;
            internal set;
        }

        public override bool Execute(Registers regs, Stack stack, ref int index)
        {
            if (Op == "call")
            {
                if (CallDest != null) // intern call
                {
                    stack.Push(new ReturnAddress(stack.CurrentCalleeName, Args, index + 1));
                    index = CallDest.Index;
                }
                else // extern call
                    index++;
            }
            else if (Op == "ret")
            {
                StackItem popped = stack.Pop(4);
                if (!(popped is ReturnAddress))
                    throw new Exception("Popped stack item is not a return address!");
                index = (int)(popped.Value);
            }
            return true;
        }
    }
}
