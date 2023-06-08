using System;
using Aspose.Cells;
using ns2;

namespace ns27;

internal class Class596 : Class538
{
	internal Class596()
	{
		method_2(545);
	}

	internal void SetArrayFormula(Class1348 class1348_0)
	{
		CellArea cellArea = class1348_0.CellArea;
		byte[] formula = class1348_0.Formula;
		method_0((short)(12 + formula.Length));
		byte_0 = new byte[base.Length];
		Array.Copy(formula, 0, byte_0, 12, formula.Length);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea.StartRow), byte_0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea.EndRow), 0, byte_0, 2, 2);
		byte_0[4] = (byte)cellArea.StartColumn;
		byte_0[5] = (byte)cellArea.EndColumn;
		byte_0[6] = 2;
	}
}
