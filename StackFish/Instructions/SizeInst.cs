// Started 13-03-2016, Basile Van Hoorick

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFish.Instructions
{
    public abstract class SizeInst : Instruction
    {
        internal SizeInst(int index, string line, string op, string args, uint defaultSize = 0)
            : base(index, line, op, args)
        {
            // https://en.wikibooks.org/wiki/X86_Assembly/GAS_Syntax
            switch (op[op.Length - 1])
            {
                case 'b': this.size = 1; break;
                case 's':
                case 'w': this.size = 2; break;
                case 'l': this.size = 4; break;
                case 'q': this.size = 8; break;
                case 't': this.size = 10; break;
                default:
                    if (defaultSize == 0)
                        throw new ArgumentException("Size could not be parsed");
                    else
                        this.size = defaultSize;
                    break;
            }
        }

        protected readonly uint size;
    }
}
