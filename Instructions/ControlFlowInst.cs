// Started 13-03-2016, Basile Van Hoorick
// https://en.wikibooks.org/wiki/X86_Assembly/Control_Flow
// Does NOT include jump instructions!

using StackFish.StackItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFish.Instructions
{
    public class ControlFlowInst : SizeInst
    {
        private enum Which
        {
            Cmp, Test, Enter, Leave
        }

        internal ControlFlowInst(int index, string line, string op, string args)
            : base(index, line, op, args, 4)
        {
            argsArray = args.Split(',').Select(x => x.Trim()).ToArray();
            if (op.StartsWith("cmp"))
                which = Which.Cmp;
            else if (op.StartsWith("test"))
                which = Which.Test;
            else if (op.StartsWith("enter"))
                which = Which.Enter;
            else if (op.StartsWith("leave"))
                which = Which.Leave;
            else
                throw new ArgumentException("Unrecognized instruction");
        }

        private readonly Which which;
        private readonly string[] argsArray;

        public override bool Execute(Registers regs, Stack stack, ref int index)
        {
            bool result = false;
            // TODO
            switch (which)
            {
                case Which.Cmp:
                    ulong leftVal = getValue(regs, stack, argsArray[0], size);
                    ulong rightVal = getValue(regs, stack, argsArray[1], size);
                    regs.PerformSub(leftVal, rightVal);
                    result = true;
                    break;
                case Which.Test:

                    break;
                case Which.Enter:
                    stack.Push(Registers.Regs.EBP);
                    regs.EBP = regs.ESP;
                    result = true;
                    break;
                case Which.Leave:
                    regs.ESP = regs.EBP;
                    stack.Pop(Registers.Regs.EBP);
                    result = true;
                    break;
            }
            index++;
            return result;
        }
    }
}
