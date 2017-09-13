// Started 13-03-2016, Basile Van Hoorick
// https://en.wikibooks.org/wiki/X86_Assembly/Data_Transfer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFish.Instructions
{
    public class DataTransferInst : SizeInst
    {
        private enum Which
        {
            Mov, Xchg, Lea
        }

        internal DataTransferInst(int index, string line, string op, string args)
            : base(index, line, op, args)
        {
            argsArray = args.Split(',').Select(x => x.Trim()).ToArray();
            source = argsArray[0];
            dest = argsArray[1];
            if (op.StartsWith("mov"))
                which = Which.Mov;
            else if (op.StartsWith("xchg"))
                which = Which.Xchg;
            else if (op.StartsWith("lea"))
                which = Which.Lea;
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
            // TODO
            switch (which)
            {
                case Which.Mov:
                    result = setValue(regs, stack, dest, sourceVal, size);
                    break;
                case Which.Xchg:

                    break;
                case Which.Lea:
                    ulong sourceAddr = getAddress(regs, stack, source, size);
                    result = setValue(regs, stack, dest, sourceAddr, size);
                    break;
            }
            index++;
            return result;
        }
    }
}
