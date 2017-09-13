// Started 13-03-2016, Basile Van Hoorick
// https://en.wikibooks.org/wiki/X86_Assembly/Logic

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFish.Instructions
{
    public class LogicInst : SizeInst
    {
        private enum Which
        {
            And, Or, Xor, Not
        }

        internal LogicInst(int index, string line, string op, string args)
            : base(index, line, op, args)
        {
            argsArray = args.Split(',').Select(x => x.Trim()).ToArray();
            source = argsArray[0];
            dest = argsArray[1];
            if (op.StartsWith("and"))
                which = Which.And;
            else if (op.StartsWith("or"))
                which = Which.Or;
            else if (op.StartsWith("xor"))
                which = Which.Xor;
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
                case Which.And:
                    destVal &= sourceVal;
                    regs.PerformAnd(sourceVal, destVal); // flags
                    break;
                case Which.Or:
                    destVal |= sourceVal;
                    regs.PerformOr(sourceVal, destVal); // flags
                    break;
                case Which.Xor:
                    destVal ^= sourceVal;
                    regs.PerformXor(sourceVal, destVal); // flags
                    break;
            }
            result = setValue(regs, stack, dest, destVal, size);
            index++;
            return result;
        }
    }
}
