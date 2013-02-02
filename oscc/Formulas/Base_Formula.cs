/*
 * This file is part of OSCC.
 *
 * OSCC is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * OSCC is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with OSCC.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;

namespace oscc.Formulas
{
    /// <summary>
    /// This class has to be inherited by the specific formulas and
    /// the Formula* functions have to be implemented.
    /// Calculations (opcode, switch case) can be used via this class.
    /// </summary>
    public abstract partial class Base_Formula
    {
        #region Enums: eOperationSystemType, ePlatformType
        /// <summary>
        /// Operation system types, just OS X and Windows are supported by WoW.
        /// </summary>
        public enum eOperationSystemType
        {
            OSX,
            WIN
        }
        /// <summary>
        /// 32 bit and 64 bit modes are supported by WoW.
        /// </summary>
        public enum ePlatformType
        {
            x86,
            x64
        }
        #endregion

        #region Formula comparer
        /// <summary>
        /// This class used to sort formulas.
        /// </summary>
        public class Comparer : IComparer<Base_Formula>
        {
            /// <summary>
            /// First: compare based on build number
            /// Second: if build numbers are equal then
            /// compares operation system types: Windows forward.
            /// Third: if OS types are equal too then
            /// compares platform types: x86 forward.
            /// </summary>
            /// <param name="x">The first formula to compare.</param>
            /// <param name="y">The second formula to compare.</param>
            /// <returns></returns>
            public int Compare(Base_Formula x, Base_Formula y)
            {
                if (x.BuildNumber < y.BuildNumber)
                    return -1;
                if (x.BuildNumber > y.BuildNumber)
                    return 1;
                if (x.BuildNumber == y.BuildNumber)
                {
                    if (x.OperationSystemType != y.OperationSystemType)
                    {
                        // WIN first
                        if (x.OperationSystemType == eOperationSystemType.WIN)
                            return -1;
                        // OS X second
                        else
                            return 1;
                    }
                    else if (x.PlatformType != y.PlatformType)
                    {
                        // x86 first
                        if (x.PlatformType == ePlatformType.x86)
                            return -1;
                        // x64 second
                        else
                            return 1;
                    }
                }
                // equal
                return 0;
            }
        }
        #endregion

        #region FormulaResult
        /// <summary>
        /// That class returned by calculations.
        /// Can get the type of the result and itself value of the result.
        /// </summary>
        public class FormulaResult
        {
            /// <summary>
            /// These are the types of the opcodes.
            /// UNK means unknown so the type can't be determined.
            /// </summary>
            public enum eOpcodeType
            {
                JAMC,
                JAMCC,
                UNK
            }

            public FormulaResult(eOpcodeType scType, UInt16 result)
            {
                switchCaseType = scType;
                resultValue = result;
            }

            public eOpcodeType SwitchCaseType
            {
                get
                {
                    return switchCaseType;
                }
            }
            public UInt16 ResultValue
            {
                get
                {
                    return resultValue;
                }
            }

            private eOpcodeType switchCaseType;
            private UInt16 resultValue;
        }
        #endregion

        public Base_Formula()
        {
            operationSystemType = eOperationSystemType.OSX;
            platformType = ePlatformType.x86;
            patchNumber = String.Empty;
            buildNumber = 0;
        }

        #region Formulas related
        #region Formula checkers
        /// <summary>
        /// This function has to override in a specific formula.
        /// Checks that the given opcode is valid for
        /// the current (JAMC) opcode type.
        /// </summary>
        /// <param name="opcode">The opcode which should be checked.</param>
        /// <returns>True if this a valid JAMC opcode, otherwise false.</returns>
        public abstract bool FormulaChecker_JAMC(UInt16 opcode);
        /// <summary>
        /// This function has to override in a specific formula.
        /// Checks that the given opcode is valid for
        /// the current (JAMCC) opcode type.
        /// </summary>
        /// <param name="opcode">The opcode which should be checked.</param>
        /// <returns>True if this a valid JAMCC opcode, otherwise false.</returns>
        public abstract bool FormulaChecker_JAMCC(UInt16 opcode);
        #endregion

        #region Formulas
        /// <summary>
        /// That function has to override in a specific formula.
        /// Converts the opcode for a proper (JAMC) switch case value.
        /// </summary>
        /// <param name="opcode">The opcode which should be converted.</param>
        /// <returns>The converted (from opcode) switch case value.</returns>
        public abstract UInt16 Formula_JAMC(UInt16 opcode);
        /// <summary>
        /// That function has to override in a specific formula.
        /// Converts the opcode for a proper (JAMCC) switch case value.
        /// </summary>
        /// <param name="opcode">The opcode which should be converted.</param>
        /// <returns>The converted (from opcode) switch case value.</returns>
        public abstract UInt16 Formula_JAMCC(UInt16 opcode);
        #endregion
        #endregion

        #region Calculations
        /// <summary>
        /// Returns the type of the opcode.
        /// </summary>
        /// <param name="opcode">An opcode which should be examined.</param>
        /// <returns>The type of the opcode. Returns UNK if this is an invalid opcode.</returns>
        /// <see cref="FormulaResult.eOpcodeType"/>
        private FormulaResult.eOpcodeType GetSwitchCaseType(UInt16 opcode)
        {
            if (FormulaChecker_JAMC(opcode))
                return FormulaResult.eOpcodeType.JAMC;
            if (FormulaChecker_JAMCC(opcode))
                return FormulaResult.eOpcodeType.JAMCC;
            return FormulaResult.eOpcodeType.UNK;
        }
        /// <summary>
        /// Calculates the switch case from the specific opcode (and from type).
        /// </summary>
        /// <param name="opcode">Switch case value will be calculated from this opcode.</param>
        /// <param name="scType">
        /// The type of the opcode.
        /// If this type is UNK then the type will be calculated by GetSwitchCaseType().
        /// </param>
        /// <returns>A FormulaResult object which stores the switch case value (result) and the type.</returns>
        public FormulaResult CalculateSwitchCase(UInt16 opcode, FormulaResult.eOpcodeType scType = FormulaResult.eOpcodeType.UNK)
        {
            UInt16 switchCase = 0;
            // default value: so let's calculate it!
            if (scType == FormulaResult.eOpcodeType.UNK)
                scType = GetSwitchCaseType(opcode);
            switch (scType)
            {
                case FormulaResult.eOpcodeType.JAMC:
                    switchCase = Formula_JAMC(opcode);
                    break;
                case FormulaResult.eOpcodeType.JAMCC:
                    switchCase = Formula_JAMCC(opcode);
                    break;
            }
            return new FormulaResult(scType, switchCase);
        }

        /// <summary>
        /// "Brute forces" the opcode from a specific switch case and type.
        /// </summary>
        /// <param name="switchCase">Opcode will be calculated from that switch case value.</param>
        /// <param name="scType">This is the type of the switch case and the opcode too.</param>
        /// <returns>A FormulaResult object which contains the opcode (result) and the type.</returns>
        public FormulaResult CalculateOpcode(UInt16 switchCase, FormulaResult.eOpcodeType scType)
        {
            // "brute force"
            for (UInt16 i = 0; i < UInt16.MaxValue; ++i)
            {
                FormulaResult.eOpcodeType tempSCType = GetSwitchCaseType(i);
                // if the given and the calculated type doesn't match
                if (tempSCType == FormulaResult.eOpcodeType.UNK || tempSCType != scType)
                    continue;
                FormulaResult tempResult = CalculateSwitchCase(i, scType);
                // the given swich case and the calculated one matches
                // so the opcode should be good
                if (tempResult.ResultValue == switchCase)
                    return new FormulaResult(tempResult.SwitchCaseType, i);
            }
            // invalid switch case
            return new FormulaResult(FormulaResult.eOpcodeType.UNK, 0);
        }
        #endregion

        #region Get properties
        public UInt16 BuildNumber
        {
            get
            {
                return buildNumber;
            }
        }
        public eOperationSystemType OperationSystemType
        {
            get
            {
                return operationSystemType;
            }
        }
        public ePlatformType PlatformType
        {
            get
            {
                return platformType;
            }
        }
        #endregion

        #region Misc
        /// <summary>
        /// Convert a specific formula to a displayable string.
        /// Formula: PatchNumber, BuildNumber - OperationSystem PlatformType
        /// eg.: 5.1.0A, 16357 - Windows x86
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return String.Format("{0}, {1} - {2} {3}", patchNumber, buildNumber, OperationSystemName, platformType);
        }

        /// <summary>
        /// Nice string from operation system type.
        /// </summary>
        /// <see cref="eOperationSystemType"/>
        private String OperationSystemName
        {
            get
            {
                if (operationSystemType == eOperationSystemType.WIN)
                    return "Windows";
                else
                    return "OS X";
            }
        }
        #endregion

        protected eOperationSystemType operationSystemType;
        protected ePlatformType platformType;
        protected String patchNumber;
        protected UInt16 buildNumber;
    }
}
