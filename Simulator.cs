// Started 11-03-2016, Basile Van Hoorick

using StackFish.Instructions;
using StackFish.StackItems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StackFish
{
    /// <summary>
    /// Main assembly simulator class
    /// </summary>
    public class Simulator
    {
        private const int MaxStates = 256;
        
        public delegate void InstructionReadyEventHandler(int index, bool lastSuccess);
        public event InstructionReadyEventHandler OnInstructionReady;

        public Simulator(AssemblyFile file, List<StackItem> initStack)
        {
            this.file = file;
            this.Registers = new Registers();
            this.Stack = new Stack(Registers, 1000 + getTotalSize(initStack), initStack); // return main will always be at 1000!
        }

        private AssemblyFile file;

        public Registers Registers
        {
            get;
            private set;
        }

        public Stack Stack
        {
            get;
            private set;
        }

        private int index; // next instruction to be executed
        private LinkedList<MachineState> prevStates;

        /// <returns>Successful (always true)</returns>
        public bool Start(int startIndex)
        {
            index = startIndex;
            prevStates = new LinkedList<MachineState>();
            OnInstructionReady?.Invoke(index, true);
            return true;
        }

        /// <returns>Instruction successful</returns>
        public bool StepForward()
        {
            if (index == -1)
                return false;

            // Save current machine state
            prevStates.AddLast(new MachineState(index, Registers, Stack));
            if (prevStates.Count >= MaxStates)
                prevStates.RemoveFirst();

            // Execute next instruction
            Instruction inst = file.Instructions[index];
            bool success = inst.Execute(Registers, Stack, ref index);

            // Skip comments
            while (0 <= index && index < file.Instructions.Count && file.Instructions[index] is Comment)
                index++;

            // Detect end of program
            if (index >= file.Instructions.Count)
                index = -1;

            OnInstructionReady?.Invoke(index, success);
            return success;
        }

        /// <returns>Instruction successful (always false)</returns>
        public bool Ignore()
        {
            index++;
            OnInstructionReady?.Invoke(index, false);
            return false;
        }

        /// <returns>Instruction successful (true if a previous state exists, false otherwise)</returns>
        public bool StepBackward()
        {
            if (prevStates.Count == 0)
                return false;

            MachineState last = prevStates.Last();
            last.Restore(Registers, Stack);
            prevStates.RemoveLast();
            index = last.InstIndex;

            OnInstructionReady?.Invoke(index, true);
            return true;
        }

        private static uint getTotalSize(List<StackItem> items)
        {
            uint result = 0;
            foreach (StackItem item in items)
                result += item.Size;
            return result;
        }
    }
}
