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

namespace oscc
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.formulasComboBox = new System.Windows.Forms.ComboBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.formulaLabel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatorTypeComboBox = new System.Windows.Forms.ComboBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.scTypeComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // formulasComboBox
            // 
            this.formulasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formulasComboBox.FormattingEnabled = true;
            this.formulasComboBox.Location = new System.Drawing.Point(127, 48);
            this.formulasComboBox.Name = "formulasComboBox";
            this.formulasComboBox.Size = new System.Drawing.Size(173, 21);
            this.formulasComboBox.TabIndex = 0;
            this.formulasComboBox.SelectedIndexChanged += new System.EventHandler(this.formulasComboBox_SelectedIndexChanged);
            // 
            // inputTextBox
            // 
            this.inputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputTextBox.Location = new System.Drawing.Point(210, 100);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.inputTextBox.Size = new System.Drawing.Size(90, 20);
            this.inputTextBox.TabIndex = 1;
            this.inputTextBox.Text = "0x0000";
            this.inputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inputTextBox.Enter += new System.EventHandler(this.opcodeTextBox_Enter);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(116, 225);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(108, 23);
            this.calculateButton.TabIndex = 2;
            this.calculateButton.Text = "Calculate!";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // formulaLabel
            // 
            this.formulaLabel.AutoSize = true;
            this.formulaLabel.Location = new System.Drawing.Point(25, 51);
            this.formulaLabel.Name = "formulaLabel";
            this.formulaLabel.Size = new System.Drawing.Size(47, 13);
            this.formulaLabel.TabIndex = 4;
            this.formulaLabel.Text = "Formula:";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(321, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // calculatorTypeComboBox
            // 
            this.calculatorTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.calculatorTypeComboBox.FormattingEnabled = true;
            this.calculatorTypeComboBox.Items.AddRange(new object[] {
            "Opcode",
            "Switch Case"});
            this.calculatorTypeComboBox.Location = new System.Drawing.Point(28, 99);
            this.calculatorTypeComboBox.Name = "calculatorTypeComboBox";
            this.calculatorTypeComboBox.Size = new System.Drawing.Size(93, 21);
            this.calculatorTypeComboBox.TabIndex = 6;
            this.calculatorTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.calculatorTypeComboBox_SelectedIndexChanged);
            // 
            // resultTextBox
            // 
            this.resultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultTextBox.Location = new System.Drawing.Point(210, 159);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(90, 20);
            this.resultTextBox.TabIndex = 7;
            this.resultTextBox.TabStop = false;
            this.resultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(28, 161);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(40, 13);
            this.resultLabel.TabIndex = 8;
            this.resultLabel.Text = "Result:";
            // 
            // scTypeComboBox
            // 
            this.scTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scTypeComboBox.FormattingEnabled = true;
            this.scTypeComboBox.Location = new System.Drawing.Point(127, 99);
            this.scTypeComboBox.Name = "scTypeComboBox";
            this.scTypeComboBox.Size = new System.Drawing.Size(62, 21);
            this.scTypeComboBox.TabIndex = 9;
            // 
            // mainForm
            // 
            this.AcceptButton = this.calculateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 278);
            this.Controls.Add(this.scTypeComboBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.calculatorTypeComboBox);
            this.Controls.Add(this.formulaLabel);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.formulasComboBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opcode Switch Case Calculator";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox formulasComboBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label formulaLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox calculatorTypeComboBox;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.ComboBox scTypeComboBox;
    }
}
