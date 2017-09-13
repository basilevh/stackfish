// Started 12-03-2016, Basile Van Hoorick

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackFish
{
    public class Registers
    {
        // TODO eflags
        // TODO seperate Flags class

        public delegate void RegisterChangedEventHandler(Regs reg, uint value);
        public delegate void FlagChangedEventHandler(Flags flag, bool value);
        public event RegisterChangedEventHandler OnRegisterChanged;
        public event RegisterChangedEventHandler OnPointerChanged; // esp, ebp
        public event FlagChangedEventHandler OnFlagChanged;

        public enum Regs
        {
            EAX, EBX, ECX, EDX, ESP, EBP
        }

        public enum Flags
        {
            Carry, Overflow, Parity, Sign, Zero
        }

        public static Regs Parse(string name)
        {
            switch (name.ToUpper())
            {
                case "EAX": return Regs.EAX;
                case "EBX": return Regs.EBX;
                case "ECX": return Regs.ECX;
                case "EDX": return Regs.EDX;
                case "ESP": return Regs.ESP;
                case "EBP": return Regs.EBP;
            }
            throw new ArgumentException("Invalid register name");
        }

        public Registers(uint eax, uint ebx, uint ecx, uint edx)
        {
            this.eax = eax;
            this.ebx = ebx;
            this.ecx = ecx;
            this.edx = edx;
        }

        public Registers() : this(0, 0, 0, 0)
        { }

        private uint eax, ebx, ecx, edx, esp, ebp; // 32-bit registers: 0-4294967295
        private bool carry, overflow, parity, sign, zero;

        // modifies flags
        public void PerformAdd(ulong sourceU, ulong destU)
        {
            long sourceS = (long)sourceU;
            long destS = (long)destU;
            ulong addU = destU + sourceU;
            long addS = sourceS + destS;

            // Carry <=> sum of unsigned numbers > max value <=> sum is smaller than either operand
            Carry = (addU < sourceU || addU < destU);
            // Overflow <=> sum of two same-signed numbers exceeds range
            Overflow = (destS > 0 && sourceS > 0 && addS < 0) || (destS < 0 && sourceS < 0 && addS > 0);
            // Parity TODO

            Sign = (addS < 0);
            Zero = (addS == 0);
        }

        public void PerformSub(ulong sourceU, ulong destU)
        {
            long sourceS = (long)sourceU;
            long destS = (long)destU;
            ulong subU = destU - sourceU;
            long subS = destS - sourceS;

            // Carry TODO

            // Overflow <=> difference of two opposite-signed numbers exceeds range
            Overflow = (destS > 0 && sourceS < 0 && subS < 0) || (destS < 0 && sourceS > 0 && subS > 0);
            // Parity TODO

            Sign = (subS < 0);
            Zero = (subS == 0);
        }

        public void PerformAnd(ulong sourceU, ulong destU)
        {
            ulong andU = sourceU & destU;
            long andS = (long)(andU);
            // TODO correct?
            Carry = false;
            Overflow = false;
            // Parity TODO

            Sign = (andS < 0);
            Zero = (andU == 0);
        }

        public void PerformOr(ulong sourceU, ulong destU)
        {
            ulong orU = sourceU | destU;
            long orS = (long)(orU);
            // TODO correct?
            Carry = false;
            Overflow = false;
            // Parity TODO

            Sign = (orS < 0);
            Zero = (orU == 0);
        }

        public void PerformXor(ulong sourceU, ulong destU)
        {
            ulong xorU = sourceU ^ destU;
            long xorS = (long)(xorU);
            // TODO correct?
            Carry = false;
            Overflow = false;
            // Parity TODO

            Sign = (xorS < 0);
            Zero = (xorU == 0);
        }

        #region Get/Set

        public uint Get(Regs reg)
        {
            switch (reg)
            {
                case Regs.EAX: return EAX;
                case Regs.EBX: return EBX;
                case Regs.ECX: return ECX;
                case Regs.EDX: return EDX;
                case Regs.ESP: return ESP;
                case Regs.EBP: return EBP;
            }
            throw new ArgumentException("Unknown register");
        }

        public uint Get(string name)
        {
            return Get(Parse(name));
        }

        /// <returns>Register was changed</returns>
        public bool Set(Regs reg, uint value)
        {
            uint old;
            switch (reg)
            {
                case Regs.EAX: old = EAX; EAX = value; break;
                case Regs.EBX: old = EBX; EBX = value; break;
                case Regs.ECX: old = ECX; ECX = value; break;
                case Regs.EDX: old = EDX; EDX = value; break;
                case Regs.ESP: old = ESP; ESP = value; break;
                case Regs.EBP: old = EBP; EBP = value; break;
                default:
                    throw new ArgumentException("Unknown register");
            }
            return old != value;
        }

        /// <returns>Register was changed</returns>
        public bool Set(string name, uint value)
        {
            return Set(Parse(name), value);
        }

        public bool Get(Flags flag)
        {
            switch (flag)
            {
                case Flags.Carry: return carry;
                case Flags.Overflow: return overflow;
                case Flags.Parity: return parity;
                case Flags.Sign: return sign;
                case Flags.Zero: return zero;
            }
            throw new ArgumentException("Unknown flag");
        }

        /// <returns>Flag was changed</returns>
        public bool Set(Flags flag, bool value)
        {
            bool old;
            switch (flag)
            {
                case Flags.Carry: old = carry; carry = value; break;
                case Flags.Overflow: old = overflow; overflow = value; break;
                case Flags.Parity: old = parity; parity = value; break;
                case Flags.Sign: old = sign; sign = value; break;
                case Flags.Zero: old = zero; zero = value; break;
                default:
                    throw new ArgumentException("Unknown flag");
            }
            return old != value;
        }

        #endregion

        #region Public accessors

        public uint EAX
        {
            get
            {
                return eax;
            }
            set
            {
                eax = value;
                OnRegisterChanged?.Invoke(Regs.EAX, value);
            }
        }

        public uint EBX
        {
            get
            {
                return ebx;
            }
            set
            {
                ebx = value;
                OnRegisterChanged?.Invoke(Regs.EBX, value);
            }
        }

        public uint ECX
        {
            get
            {
                return ecx;
            }
            set
            {
                ecx = value;
                OnRegisterChanged?.Invoke(Regs.ECX, value);
            }
        }

        public uint EDX
        {
            get
            {
                return edx;
            }
            set
            {
                edx = value;
                OnRegisterChanged?.Invoke(Regs.EDX, value);
            }
        }

        public uint ESP
        {
            get
            {
                return esp;
            }
            set
            {
                esp = value;
                OnRegisterChanged?.Invoke(Regs.ESP, value);
                OnPointerChanged?.Invoke(Regs.ESP, value);
            }
        }

        public uint EBP
        {
            get
            {
                return ebp;
            }
            set
            {
                ebp = value;
                OnRegisterChanged?.Invoke(Regs.EBP, value);
                OnPointerChanged?.Invoke(Regs.EBP, value);
            }
        }

        public bool Carry
        {
            get
            {
                return carry;
            }
            set
            {
                carry = value;
                OnFlagChanged?.Invoke(Flags.Carry, value);
            }
        }

        public bool Overflow
        {
            get
            {
                return overflow;
            }
            set
            {
                overflow = value;
                OnFlagChanged?.Invoke(Flags.Overflow, value);
            }
        }

        public bool Parity
        {
            get
            {
                return parity;
            }
            set
            {
                parity = value;
                OnFlagChanged?.Invoke(Flags.Parity, value);
            }
        }

        public bool Sign
        {
            get
            {
                return sign;
            }
            set
            {
                sign = value;
                OnFlagChanged?.Invoke(Flags.Sign, value);
            }
        }

        public bool Zero
        {
            get
            {
                return zero;
            }
            set
            {
                zero = value;
                OnFlagChanged?.Invoke(Flags.Zero, value);
            }
        }

        #endregion
    }
}
