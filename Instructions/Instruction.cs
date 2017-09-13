// Started 11-03-2016, Basile Van Hoorick

using System;

namespace StackFish.Instructions
{
    public abstract class Instruction
    {
        private readonly static char[] spaces = { ' ', '\t' };

        private enum Types
        {
            Label, CallReturn, PushPop, DataTransfer, ControlFlow,
            Arithmetic, Logic, Jump, Comment, Other
        }

        public Instruction(int index, string line, string op, string args)
        {
            Index = index;
            Line = line;
            Op = op;
            Args = args;
        }

        public static Instruction Create(int index, string line)
        {
            line = line.Trim(spaces);
            string op = getOp(line);
            string args = getArgs(line, op);
            Types type = getType(line, op);
            switch (type)
            {
                case Types.Label:
                    return new LabelInst(index, line, op, args);
                case Types.CallReturn:
                    return new CallReturnInst(index, line, op, args);
                case Types.PushPop:
                    return new PushPopInst(index, line, op, args);
                case Types.DataTransfer:
                    return new DataTransferInst(index, line, op, args);
                case Types.ControlFlow:
                    return new ControlFlowInst(index, line, op, args);
                case Types.Arithmetic:
                    return new ArithmeticInst(index, line, op, args);
                case Types.Logic:
                    return new LogicInst(index, line, op, args);
                case Types.Jump:
                    return new JumpInst(index, line, op, args);
                case Types.Comment:
                    return new Comment(index, line, op, args);
                default: // includes Other
                    return new OtherInst(index, line, op, args);
            }
        }

        public int Index
        {
            get;
            private set;
        }

        public string Line
        {
            get;
            private set;
        }

        public string Op
        {
            get;
            private set;
        }

        public string Args
        {
            get;
            private set;
        }
        
        /// <returns>Instruction executed successfully</returns>
        public abstract bool Execute(Registers regs, Stack stack, ref int index);

        protected bool setValue(Registers regs, Stack stack, string expr, ulong value, uint size = 4)
        {
            if (expr[0] == '%') // register
            {
                regs.Set(expr.Substring(1), (uint)value);
                return true;
            }

            int leftBracket = expr.IndexOf('(');
            int rightBracket = expr.IndexOf(')');
            if (leftBracket != -1 && rightBracket > leftBracket) // memory address pointed by register
            {
                int disp = (leftBracket == 0 ? 0 : int.Parse(expr.Substring(0, leftBracket)));
                string baseExpr = expr.Substring(leftBracket + 1, rightBracket - leftBracket - 1);
                uint baseAddr = (uint)getValue(regs, stack, baseExpr);
                uint realAddr = (uint)(baseAddr + disp);
                return stack.MemSet(realAddr, value, size);
            }
            return false;
        }

        protected ulong getValue(Registers regs, Stack stack, string expr, uint size = 4)
        {
            if (expr[0] == '%') // register
                return regs.Get(expr.Substring(1));

            if (expr[0] == '$') // number
                return (ulong)long.Parse(expr.Substring(1));

            int leftBracket = expr.IndexOf('(');
            int rightBracket = expr.IndexOf(')');
            if (leftBracket != -1 && rightBracket > leftBracket) // memory address pointed by register
            {
                int disp = (leftBracket == 0 ? 0 : int.Parse(expr.Substring(0, leftBracket)));
                string baseExpr = expr.Substring(leftBracket + 1, rightBracket - leftBracket - 1);
                uint baseAddr = (uint)getValue(regs, stack, baseExpr);
                uint realAddr = (uint)(baseAddr + disp);
                return stack.MemGet(realAddr, size);
            }
            throw new ArgumentException("Unrecognized expression: " + expr);
        }

        protected ulong getAddress(Registers regs, Stack stack, string expr, uint size = 4)
        {
            int leftBracket = expr.IndexOf('(');
            int rightBracket = expr.IndexOf(')');
            if (leftBracket != -1 && rightBracket > leftBracket) // memory address pointed by register
            {
                int disp = (leftBracket == 0 ? 0 : int.Parse(expr.Substring(0, leftBracket)));
                string baseExpr = expr.Substring(leftBracket + 1, rightBracket - leftBracket - 1);
                uint baseAddr = (uint)getValue(regs, stack, baseExpr);
                uint realAddr = (uint)(baseAddr + disp);
                return realAddr;
            }
            throw new ArgumentException("Unrecognized expression: " + expr);
        }

        private static Types getType(string line, string op)
        {
            if (isComment(line))
                return Types.Comment;

            if (line.EndsWith(":"))
                return Types.Label;

            switch (op)
            {
                case "push":
                case "pop":
                case "pushb": // byte
                case "popb":
                case "pushw": // word
                case "popw":
                case "pushl": // long
                case "popl":
                case "pushq": // quad
                case "popq":
                    return Types.PushPop;
                case "call":
                case "ret":
                    return Types.CallReturn;
                // TODO
                case "movl":
                //case "xchgl":
                case "leal":
                    return Types.DataTransfer;
                // TODO
                case "cmpl":
                //case "enter":
                case "leave":
                    return Types.ControlFlow;
                // TODO
                case "addl":
                case "subl":
                    //case "mull":
                    //case "imull":
                    //case "divl":
                    //case "idivl":
                    return Types.Arithmetic;
                // TODO
                case "andl":
                case "orl":
                case "xorl":
                    //case "notl":
                    return Types.Logic;
                case "jmp":
                case "jc": // jump if carry
                case "jnc":
                case "je": // jump if equal
                case "jne":
                case "jo": // jump if overflow
                case "jno":
                case "js": // jump if sign
                case "jns":
                case "jz": // jump if zero
                case "jnz":
                case "jb": // jump if below
                case "jnb":
                case "ja": // jump if above
                case "jna":
                case "jbe": // jump if below or equal
                case "jnbe":
                case "jae": // jump if above or equal
                case "jnae":
                case "jl": // jump if less
                case "jnl":
                case "jg": // jump if greater
                case "jng":
                case "jle": // jump if less or equal
                case "jnle":
                case "jge": // jump if greater or equal
                case "jnge":
                    return Types.Jump;
                default:
                    return Types.Other;
            }
        }

        private static string getOp(string line)
        {
            int opLen = line.IndexOfAny(spaces);
            if (opLen != -1)
                return line.Substring(0, opLen);
            else
                return line;
        }

        private static string getArgs(string line, string op)
        {
            if (op == line)
                return "";
            else
                return line.Substring(op.Length).TrimStart(spaces);
        }

        internal static bool IsRelevant(string line) // don't show ".cfi etc"
        {
            line = line.Trim(spaces);
            return line.Length > 0 && (!line.StartsWith(".") || line.EndsWith(":"));
        }

        private static bool isComment(string line)
        {
            // TODO support multiline /* .. */
            return line.StartsWith("//") || line.StartsWith(";");
        }
    }
}
