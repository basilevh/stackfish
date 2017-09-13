// Started 12-03-2016, Basile Van Hoorick

using System;

namespace StackFish.StackItems
{
    /// <summary>
    /// Helper class for parsing initial stack information
    /// </summary>
    public static class StringParser
    {
        public static StackItem FromString(string input)
        {
            string[] split = input.Split('|');
            switch (split[0])
            {
                case "register":
                    return new Register(Registers.Parse(split[1]), uint.Parse(split[2]));
                case "return":
                    return new ReturnAddress(split[1], split[2], int.Parse(split[3]));
                default:
                    return new Other(uint.Parse(split[0]), split[1], ulong.Parse(split[2]));
            }
        }

        public static string GetString(StackItem item)
        {
            if (item is Register)
                return "register|" + item.Description + "|" + item.Value;
            else if (item is ReturnAddress)
                return "return|" + (item as ReturnAddress).CallerName + "|" + (item as ReturnAddress).CalleeName + "|" + (int)(item.Value);
            else
                return item.Size + "|" + item.Description + "|" + item.Value;
        }
    }
}
