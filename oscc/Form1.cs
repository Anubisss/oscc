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
using System.Windows.Forms;
using System.Globalization;

using oscc.Formulas;

namespace oscc
{
    /// <summary>
    /// The main form.
    /// </summary>
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();

            FillFormulasComboBox();
            FillSCTypeComboBox();

            // select the first item 
            calculatorTypeComboBox.SelectedIndex = 0;
            // default state is invisible
            scTypeComboBox.Visible = false;
        }

        #region Combo box filling
        /// <summary>
        /// Fills the combo box with the registered (in FormulaManager) formulas.
        /// </summary>
        private void FillFormulasComboBox()
        {
            foreach (Base_Formula formula in FormulaManager.FormulasList)
                formulasComboBox.Items.Add(formula.ToString());
            // select the first one
            if (formulasComboBox.Items.Count > 0)
                formulasComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Fills the combo box with the opcode types.
        /// </summary>
        /// <see cref="Base_Formula.FormulaResult.eOpcodeType"/>
        private void FillSCTypeComboBox()
        {
            foreach (var enumValue in typeof(Base_Formula.FormulaResult.eOpcodeType).GetEnumValues())
            {
                // ignore UNK
                if ((Base_Formula.FormulaResult.eOpcodeType)enumValue != Base_Formula.FormulaResult.eOpcodeType.UNK)
                scTypeComboBox.Items.Add(enumValue);
            }
            scTypeComboBox.SelectedIndex = 0;
        }
        #endregion

        #region String to integer conversion
        /// <summary>
        /// Converts the input string to an integer.
        /// </summary>
        /// <param name="input">The input string which should be converted to integer.</param>
        /// <param name="error">If this set to true then an error happened otherwise it's false.</param>
        /// <returns>The number which is converted from the string.</returns>
        private UInt16 GetNumberFromInput(String input, out bool error)
        {
            error = false;
            UInt16 inputNumber = 0;
            // hex input string
            if (input.Contains("x") || input.Contains("X"))
            {
                // find and remove "x" or "X"
                Int32 xIndex = input.IndexOf('x');
                input = input.Remove(xIndex > -1 ? xIndex : input.IndexOf('X'), 1);
                try
                {
                    inputNumber = UInt16.Parse(input, NumberStyles.HexNumber);
                }
                catch (SystemException ex)
                {
                    // input is too big or contains not just integers
                    if (ex is FormatException || ex is OverflowException)
                    {
                        MessageBox.Show("Invalid input, format is 0x1234, range is 0x0000-0xFFFF.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = true;
                    }
                    else
                        throw;
                }
            }
            // decimal
            else
            {
                try
                {
                    inputNumber = UInt16.Parse(input, NumberStyles.Integer);
                }
                catch (SystemException ex)
                {
                    if (ex is FormatException || ex is OverflowException)
                    {
                        MessageBox.Show("Invalid input, format is 01234, range is 0-65535.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = true;
                    }
                    else
                        throw;
                }
            }
            return inputNumber;
        }
        #endregion

        #region Calculations
        /// <summary>
        /// Calculates the switch case from the opcode.
        /// </summary>
        /// <param name="input">Opcode string from the input box.</param>
        private void calculateSwitchCase(String input)
        {
            bool error = false;
            UInt16 inputNumber = GetNumberFromInput(input, out error);
            if (!error && FormulaManager.FormulasList.Count > 0)
            {
                Base_Formula.FormulaResult result = FormulaManager.GetFormula(formulasComboBox.SelectedIndex).CalculateSwitchCase(inputNumber);
                resultTextBox.Text = String.Format("[{0}] 0x{1:X4}", result.SwitchCaseType, result.ResultValue);
            }
        }

        /// <summary>
        /// Calculates the opcode from the switch case and the type.
        /// </summary>
        /// <param name="input">Switch case string from the input box.</param>
        private void calculateOpcode(String input)
        {
            bool error = false;
            UInt16 inputNumber = GetNumberFromInput(input, out error);
            if (!error && FormulaManager.FormulasList.Count > 0)
            {
                Base_Formula.FormulaResult result = FormulaManager.GetFormula(formulasComboBox.SelectedIndex).CalculateOpcode(inputNumber, (Base_Formula.FormulaResult.eOpcodeType)scTypeComboBox.SelectedItem);
                resultTextBox.Text = String.Format("[{0}] 0x{1:X4}", result.SwitchCaseType, result.ResultValue);
            }
        }
        #endregion

        #region Event callbacks
        private void opcodeTextBox_Enter(object sender, EventArgs e)
        {
            // if the default value (0x0000) is present just empty it
            TextBox box = (TextBox)sender;
            if (box.Text == "0x0000")
                box.Text = String.Empty;
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // call the proper function based on selected index
            if (calculatorTypeComboBox.SelectedIndex == 0)
                calculateSwitchCase(inputTextBox.Text);
            else
                calculateOpcode(inputTextBox.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // File - Exit
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Help - About
            MessageBox.Show("   OSCC - Opcode Switch Case Calculator\n\nLicense: GNU GPLv3\nSource code at: github.com/Anubisss/oscc", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void calculatorTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if type is "Switch Case" scType combo box should be visible
            // otherwise it's invisible
            resultTextBox.Text = String.Empty;
            if (calculatorTypeComboBox.SelectedIndex == 0)
                scTypeComboBox.Visible = false;
            else
                scTypeComboBox.Visible = true;
        }

        private void formulasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reset the result text
            resultTextBox.Text = String.Empty;
        }
        #endregion
    }
}
