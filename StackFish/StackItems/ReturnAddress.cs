// Started 12-03-2016, Basile Van Hoorick

using System;

namespace StackFish.StackItems
{
    public class ReturnAddress : StackItem
    {
        public ReturnAddress(string callerName, string calleeName, int fallIndex)
            : base(4, "return " + callerName, (ulong)fallIndex)
        {
            this.CallerName = callerName;
            this.CalleeName = calleeName;
        }

        public string CallerName
        {
            get;
            private set;
        }

        public string CalleeName
        {
            get;
            private set;
        }

        public int FallIndex => (int)Value;
    }
}
