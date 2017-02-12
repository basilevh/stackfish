// Started 11-03-2016, Basile Van Hoorick

using StackFish.Instructions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace StackFish
{
    public class AssemblyFile
    {
        public AssemblyFile(string path)
        {
            string[] lines = File.ReadAllLines(path, Encoding.ASCII);
            var insts = getInsts(lines);
            Instructions = insts.AsReadOnly();
            Labels = getLabels(insts).AsReadOnly();
            setDests(insts);
        }

        /// <summary>
        /// Collection of all instructions in the current assembly file.
        /// </summary>
        public ReadOnlyCollection<Instruction> Instructions
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Collection of all labels (subset of all instructions) for quick access.
        /// </summary>
        public ReadOnlyCollection<LabelInst> Labels
        {
            get;
            private set;
        }

        private static List<Instruction> getInsts(string[] lines)
        {
            var result = new List<Instruction>(lines.Length);
            int index = 0;
            foreach (string line in lines)
                if (Instruction.IsRelevant(line))
                    result.Add(Instruction.Create(index++, line)); // TODO next necessary?
            result.TrimExcess();
            return result;
        }

        private static List<LabelInst> getLabels(List<Instruction> insts)
        {
            var result = new List<LabelInst>();
            foreach (LabelInst inst in insts.Where(x => x is LabelInst))
                result.Add(inst);
            return result;
        }

        private static void setDests(List<Instruction> insts)
        {
            foreach (Instruction inst in insts.Where(x => x is JumpInst || (x is CallReturnInst && x.Op != "ret")))
            {
                string name = inst.Args;
                Instruction dest = insts.Find(x => x is LabelInst && (x as LabelInst).Name == name);
                if (dest != null) // dest could be null if extern call
                {
                    if (inst is JumpInst)
                        (inst as JumpInst).JumpDest = dest;
                    else if (inst is CallReturnInst)
                        (inst as CallReturnInst).CallDest = dest;
                }
            }
        }
    }
}
