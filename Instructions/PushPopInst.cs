// Started 12-03-2016, Basile Van Hoorick

using StackFish.StackItems;
using System;

namespace StackFish.Instructions
{
    public class PushPopInst : SizeInst
    {
        private enum Which
        {
            Push, Pop
        }

        internal PushPopInst(int index, string line, string op, string args)
            : base(index, line, op, args, 4)
        {
            if (op.StartsWith("push"))
                this.which = Which.Push;
            else if (op.StartsWith("pop"))
                this.which = Which.Pop;
            else
                throw new ArgumentException("Unrecognized instruction");

            if (args[0] == '%') // is register -> default size 4 correct
                this.reg = Registers.Parse(args.Substring(1));
        }

        private readonly Which which;
        private readonly Registers.Regs? reg;

        public override bool Execute(Registers regs, Stack stack, ref int index)
        {
            bool result = false;
            if (which == Which.Push) // Push
            {
                if (reg != null)
                    result = stack.Push(reg.Value);
                else
                {
                    ulong value = getValue(regs, stack, Args, size);
                    result = stack.Push(new Other(size, "", value));
                }
            }
            else // Pop
            {
                if (reg != null)
                    result = stack.Pop(reg.Value);
                else
                {
                    StackItem popped = stack.Pop(size);
                    if (popped is ReturnAddress)
                        throw new Exception("Return addresses are symbolic and cannot be popped");
                    result = setValue(regs, stack, Args, popped.Value, size);
                }
            }
            index++;
            return result;
        }
    }
}
