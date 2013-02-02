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

namespace oscc.Formulas
{
    /// <summary>
    /// Formula for 5.1.0A, 16357 - Windows x86
    /// </summary>
    public class MOP_510A_16357_WIN_X86_Formula : Base_Formula
    {
        public MOP_510A_16357_WIN_X86_Formula()
        {
            operationSystemType = eOperationSystemType.WIN;
            platformType = ePlatformType.x86;
            patchNumber = "5.1.0A";
            buildNumber = 16357;
        }

        public override bool FormulaChecker_JAMC(UInt16 opcode)
        {
            return (opcode & 0x12) == 16;
        }
        public override bool FormulaChecker_JAMCC(UInt16 opcode)
        {
            return (opcode & 0x97A) == 2090;
        }

        public override UInt16 Formula_JAMC(UInt16 opcode)
        {
            return (UInt16)(opcode & 1 | ((opcode & 0xC | (opcode >> 1) & 0x7FF0) >> 1));
        }
        public override UInt16 Formula_JAMCC(UInt16 opcode)
        {
            return (UInt16)(opcode & 1 | ((opcode & 4 | (((opcode & 0x80) | ((opcode & 0x600 | (opcode >> 1) & 0x7800) >> 1)) >> 4)) >> 1));
        }
    }
}
