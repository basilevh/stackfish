// Started 12-03-2016, Basile Van Hoorick

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackFish.StackItems
{
    public class Other : StackItem
    {
        public Other(uint size, string description, ulong value)
            : base(size, description, value)
        { }
    }
}
