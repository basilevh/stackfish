// Started 13-03-2016, Basile Van Hoorick
// https://en.wikibooks.org/wiki/X86_Assembly/Arithmetic

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFish.Instructions
{
    public class ArithmeticInst : SizeInst
    {
        private enum Which
        {
            Add, Sub, Mul, Imul, Div, Idiv
        }

        internal ArithmeticInst(int index, string line, string op, string args)
            : base(index, line, op, args)
        {
            argsArray = args.Split(',').Select(x => x.Trim()).ToArray();
            source = argsArray[0];
            dest = argsArray[1];
            if (op.StartsWith("add"))
                which = Which.Add;
            else if (op.StartsWith("sub"))
                which = Which.Sub;
            else if (op.StartsWith("mul"))
                which = Which.Mul;
            else if (op.StartsWith("imul"))
                which = Which.Imul;
            else if (op.StartsWith("div"))
                which = Which.Div;
            else if (op.StartsWith("idiv"))
                which = Which.Idiv;
            else
                throw new ArgumentException("Unrecognized instruction");
        }

        private readonly Which which;
        private readonly string[] argsArray;
        private readonly string source, dest;

        public override bool Execute(Registers regs, Stack stack, ref int index)
        {
            bool result = false;
            ulong sourceVal = getValue(regs, stack, source, size);
            ulong destVal = getValue(regs, stack, dest, size);
            // TODO
            switch (which)
            {
                case Which.Add:
                    destVal += sourceVal;
                    result = setValue(regs, stack, dest, destVal, size);
                    regs.PerformAdd(sourceVal, destVal); // flags
                    break;
                case Which.Sub:
                    destVal -= sourceVal;
                    result = setValue(regs, stack, dest, destVal, size);
                    regs.PerformSub(sourceVal, destVal); // flags
                    break;
            }
            index++;
            return true;
        }
    }
}
