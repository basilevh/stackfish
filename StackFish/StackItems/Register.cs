// Started 12-03-2016, Basile Van Hoorick

using System;

namespace StackFish.StackItems
{
    public class Register : StackItem
    {
        public Register(Registers.Regs reg, uint value)
            : base(4, reg.ToString(), value)
        { }
    }
}
