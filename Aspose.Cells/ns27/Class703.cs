using System;
using Aspose.Cells;
using ns2;

namespace ns27;

internal class Class703 : Class538
{
	internal Class703()
	{
		method_2(1212);
	}

	internal void method_4(Class1348 class1348_0)
	{
		byte[] formula = class1348_0.Formula;
		method_0((short)(formula.Length + 8));
		byte_0 = new byte[base.Length];
		CellArea cellArea = class1348_0.CellArea;
		Array.Copy(BitConverter.GetBytes((ushort)cellArea.StartRow), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea.EndRow), 0, byte_0, 2, 2);
		byte_0[4] = (byte)cellArea.StartColumn;
		byte_0[5] = (byte)cellArea.EndColumn;
		byte_0[7] = (byte)((cellArea.EndRow - cellArea.StartRow + 1) * (cellArea.EndColumn - cellArea.StartColumn + 1));
		Array.Copy(formula, 0, byte_0, 8, formula.Length);
	}
}
