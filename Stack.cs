// Started 11-03-2016, Basile Van Hoorick

using StackFish.StackItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace StackFish
{
    public class Stack
    {
        public delegate void StackChangedEventHandler(uint address);
        public event StackChangedEventHandler OnStackChanged;

        public Stack(Registers regs, uint startAddress, List<StackItem> initStack)
        {
            this.regs = regs;
            this.items = new Dictionary<uint, StackItem>();
            this.calleeNames = new List<string>();
            regs.ESP = startAddress;
            if (initStack != null)
                foreach (StackItem item in initStack)
                    Push(item);
        }

        private Dictionary<uint, StackItem> items;
        private Registers regs;

        private List<string> calleeNames;

        public ReadOnlyDictionary<uint, StackItem> Items => new ReadOnlyDictionary<uint, StackItem>(items);

        public string CurrentCalleeName => calleeNames.Last();

        public bool Push(StackItem toPush)
        {
            regs.ESP -= toPush.Size;
            items[regs.ESP] = toPush;
            if (toPush is ReturnAddress)
                calleeNames.Add((toPush as ReturnAddress).CalleeName);
            callStackChanged(regs.ESP);
            return true;
        }

        public bool Push(Registers.Regs reg)
        {
            return Push(new Register(reg, regs.Get(reg)));
        }

        public StackItem Pop(uint size)
        {
            StackItem popped = items[regs.ESP];
            if (size != popped.Size)
                throw new Exception("Popped size " + popped.Size + " did not match argument " + size);
            regs.ESP += size;
            // assuming return names match!
            // TODO why too big or empty?
            if (popped is ReturnAddress)
                calleeNames.RemoveAt(calleeNames.Count - 1);
            callStackChanged(regs.ESP - size);
            return popped;
        }

        public bool Pop(Registers.Regs reg)
        {
            StackItem popped = Pop(4);
            if (popped is Register)
                return regs.Set(reg, (uint)popped.Value);
            else
                return false;
        }

        public bool MemSet(uint address, StackItem item)
        {
            items[address] = item;
            callStackChanged(address);
            return true;
        }

        public bool MemSet(uint address, ulong value, uint size = 4)
        {
            return MemSet(address, new Other(size, "", value));
        }

        public StackItem MemGet(uint address)
        {
            if (items.ContainsKey(address))
                return items[address];
            else
                return null;
        }

        public ulong MemGet(uint address, uint size = 4)
        {
            StackItem item = MemGet(address);
            if (item == null)
                throw new Exception("Memory at address " + address + " is unknown");
            if (size != item.Size)
                throw new Exception("Stack item size " + item.Size + " did not match argument " + size);
            return item.Value;
        }

        internal void Save(MachineState programState, out ReadOnlyDictionary<uint, StackItem> items, out ReadOnlyCollection<string> calleeNames)
        {
            items = new ReadOnlyDictionary<uint, StackItem>(new Dictionary<uint, StackItem>(this.items)); // deep copy
            calleeNames = new List<string>(this.calleeNames).AsReadOnly(); // deep copy

        }

        internal void Restore(MachineState state)
        {
            this.items = new Dictionary<uint, StackItem>(state.StackItems);
            this.calleeNames = new List<string>(state.StackCalleeNames);
        }

        private void callStackChanged(uint address)
        {
            OnStackChanged?.Invoke(address);
        }
    }
}
