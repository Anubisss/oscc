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
using System.Reflection;

namespace oscc.Formulas
{
    /// <summary>
    /// This class manages the formulas.
    /// Stores, registers and returns them.
    /// </summary>
    public static class FormulaManager
    {
        static FormulaManager()
        {
            formulas = new List<Base_Formula>();
            RegisterAllFormulas();
        }

        public static List<Base_Formula> FormulasList
        {
            get
            {
                return formulas;
            }
        }

        /// <summary>
        /// Returns a formula by a specific index.
        /// </summary>
        /// <param name="index">An index number.</param>
        /// <returns>The specific formula.</returns>
        public static Base_Formula GetFormula(int index)
        {
            return formulas[index];
        }

        #region Formula registration
        /// <summary>
        /// That method registers all the available formulas automagically.
        /// </summary>
        private static void RegisterAllFormulas()
        {
            // registers all the classes which are subclass of Base_Formula
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof(Base_Formula)))
                {
                    // allocate memory and call the constructor
                    Base_Formula formula = (Base_Formula)type.GetConstructor(new Type[0]).Invoke(new Base_Formula[0]);
                    // then just register it
                    RegisterFormula(formula);
                }
            }
            if (formulas.Count > 0)
                formulas.Sort(new Base_Formula.Comparer()); // sort them
        }

        /// <summary>
        /// Concrete formula registration: add to the formula list.
        /// </summary>
        /// <param name="formula">The formula which should be stored.</param>
        private static void RegisterFormula(Base_Formula formula)
        {
            formulas.Add(formula);
        }
        #endregion

        /// <summary>
        /// This list stores the formulas.
        /// </summary>
        private static List<Base_Formula> formulas;
    }
}
