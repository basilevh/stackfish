// Started 11-03-2016, Basile Van Hoorick

using System;

namespace StackFish.StackItems
{
    public abstract class StackItem
    {
        public StackItem(uint size, string description, ulong value)
        {
            Size = size;
            Description = description;
            Value = value;
        }

        public uint Size
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        public ulong Value
        {
            get;
            private set;
        }
    }
}
