// Started 12-03-2016, Basile Van Hoorick

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackFish.Instructions
{
    public class JumpInst : Instruction
    {
        internal JumpInst(int index, string line, string op, string args)
            : base(index, line, op, args)
        {
        }

        public Instruction JumpDest // not null if jump or (non-extern) call
        {
            get;
            internal set;
        }

        public override bool Execute(Registers regs, Stack stack, ref int index)
        {
            if (condition(regs, stack))
                index = JumpDest.Index;
            else
                index++;
            return true;
        }

        private bool condition(Registers regs, Stack stack)
        {
            switch(Op)
            {
                case "jmp":
                    return true;
                case "jc": // jump if carry
                    return regs.Carry;
                case "jnc":
                    return !regs.Carry;
                case "je": // jump if equal
                case "jz": // jump if zero
                    return regs.Zero;
                case "jne":
                case "jnz":
                    return !regs.Zero;
                case "jo": // jump if overflow
                    return regs.Overflow;
                case "jno":
                    return !regs.Overflow;
                case "js": // jump if sign
                    return regs.Sign;
                case "jns":
                    return !regs.Sign;
                case "jb": // jump if below
                case "jnae": // jump if not above or equal
                    return regs.Carry;
                case "jnb":
                case "jae":
                    return !regs.Carry;
                case "ja": // jump if above
                case "jnbe": // jump if not below or equal
                    return !regs.Carry && !regs.Zero;
                case "jna":
                case "jbe":
                    return regs.Carry || regs.Zero;
                case "jl": // jump if less
                case "jnge": // jump if not greater or equal
                    return regs.Overflow != regs.Sign;
                case "jnl":
                case "jge":
                    return regs.Overflow == regs.Sign;
                case "jg": // jump if greater
                case "jnle": // jump if not less or equal
                    return regs.Overflow == regs.Sign && !regs.Zero;
                case "jng":
                case "jle":
                    return regs.Overflow != regs.Sign || regs.Zero;
                default:
                    return false;
            }
        }
    }
}
