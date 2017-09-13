// Started 13-03-2016, Basile Van Hoorick

using StackFish.StackItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFish
{
    public class MachineState
    {
        // TODO encompass 3 classes (Registers, Flags, Stack)

        public MachineState(int instIndex, Registers regs, Stack stack)
        {
            this.InstIndex = instIndex;
            eax = regs.EAX;
            ebx = regs.EBX;
            ecx = regs.ECX;
            edx = regs.EDX;
            esp = regs.ESP;
            ebp = regs.EBP;
            carry = regs.Carry;
            overflow = regs.Overflow;
            parity = regs.Parity;
            sign = regs.Sign;
            zero = regs.Zero;
            // TODO cleaner?
            stack.Save(this, out StackItems, out StackCalleeNames);
        }

        private readonly uint eax, ebx, ecx, edx, esp, ebp;
        private readonly bool carry, overflow, parity, sign, zero;
        internal readonly int InstIndex;
        internal readonly ReadOnlyDictionary<uint, StackItem> StackItems;
        internal readonly ReadOnlyCollection<string> StackCalleeNames;

        public void Restore(Registers regs, Stack stack)
        {
            regs.EAX = eax;
            regs.EBX = ebx;
            regs.ECX = ecx;
            regs.EDX = edx;
            regs.ESP = esp;
            regs.EBP = ebp;
            regs.Carry = carry;
            regs.Overflow = overflow;
            regs.Parity = parity;
            regs.Sign = sign;
            regs.Zero = zero;
            stack.Restore(this); // I must be an argument for protection
        }
    }
}
