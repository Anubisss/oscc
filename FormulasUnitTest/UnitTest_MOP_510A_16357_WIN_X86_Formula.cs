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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using oscc.Formulas;

namespace oscc.FormulasUnitTest
{
    /// <summary>
    /// Tests formulas.
    /// </summary>
    [TestClass]
    public class UnitTest_Formulas
    {
        /// <summary>
        /// Tests all the available formulas.
        /// Tests it via 3 methods.
        /// <see cref="Test_FormulaChecker"/>
        /// <see cref="Test_Formula_JAMC"/>
        /// <see cref="Test_Formula_JAMCC"/>
        /// </summary>
        [TestMethod]
        public void Test_Formulas()
        {
            // loop over all the formulas
            foreach (Base_Formula formula in FormulaManager.FormulasList)
            {
                Test_FormulaChecker(formula);
                Test_Formula_JAMC(formula);
                Test_Formula_JAMCC(formula);
            }
        }

        #region Formula tests
        /// <summary>
        /// Tests if all the possible opcodes (0-65535) have exact one type.
        /// </summary>
        /// <param name="formula">The specific formula.</param>
        private void Test_FormulaChecker(Base_Formula formula)
        {
            for (UInt16 opcode = 0; opcode < UInt16.MaxValue; ++opcode)
            {
                // assert if both methods are true
                if (formula.FormulaChecker_JAMC(opcode) && formula.FormulaChecker_JAMCC(opcode))
                    Assert.Inconclusive("Opcode 0x{0:X4} has more than one type, formula: {1}", opcode, formula.GetType().ToString());
            }
        }

        /// <summary>
        /// Tests if a switch case (JAMC) belongs to more than one opcode.
        /// </summary>
        /// <param name="formula">The specific formula.</param>
        private void Test_Formula_JAMC(Base_Formula formula)
        {
            // contains all the results
            List<UInt16> resultList = new List<UInt16>();
            for (UInt16 opcode = 0; opcode < UInt16.MaxValue; ++opcode)
            {
                // bad type opcode
                if (!formula.FormulaChecker_JAMC(opcode))
                    continue;
                // calculate the switch case
                UInt16 switchCase = formula.Formula_JAMC(opcode);
                UInt16 alreadyHaveThis = resultList.Find(
                    delegate(UInt16 x)
                    {
                        return x == switchCase;
                    }
                );
                // assert if already contains that switch case
                Assert.IsNotNull(alreadyHaveThis, "More than one opcode belong to this switch case: 0x{0:X4}, formula: {1}", switchCase, formula.GetType().ToString());

                resultList.Add(switchCase);
            }
        }

        /// <summary>
        /// Tests if a switch case (JAMCC) belongs to more than one opcodes
        /// </summary>
        /// <param name="formula">The specific formula.</param>
        private void Test_Formula_JAMCC(Base_Formula formula)
        {
            // contains all the results
            List<UInt16> resultList = new List<UInt16>();
            for (UInt16 opcode = 0; opcode < UInt16.MaxValue; ++opcode)
            {
                // bad type opcode
                if (!formula.FormulaChecker_JAMCC(opcode))
                    continue;
                // calculate the switch case
                UInt16 switchCase = formula.Formula_JAMCC(opcode);
                UInt16 alreadyHaveThis = resultList.Find(
                    delegate(UInt16 x)
                    {
                        return x == switchCase;
                    }
                );
                // assert if already contains that switch case
                Assert.IsNotNull(alreadyHaveThis, "More than one opcode belong to this switch case: 0x{0:X4}, formula: {1}", switchCase, formula.GetType().ToString());

                resultList.Add(switchCase);
            }
        }
        #endregion
    }
}
