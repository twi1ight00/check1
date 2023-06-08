using System;
using Aspose.Cells;
using ns2;

namespace ns27;

internal class Class654 : Class538
{
	internal Class654(Class1133 class1133_0)
	{
		method_2(229);
		method_0((short)(class1133_0.Count * 8 + 2));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes((short)class1133_0.Count), byte_0, 2);
		for (int i = 0; i < class1133_0.Count; i++)
		{
			CellArea cellArea = class1133_0[i];
			Array.Copy(BitConverter.GetBytes((ushort)cellArea.StartRow), 0, byte_0, 8 * i + 2, 2);
			Array.Copy(BitConverter.GetBytes((ushort)cellArea.EndRow), 0, byte_0, 8 * i + 4, 2);
			byte_0[8 * i + 6] = (byte)cellArea.StartColumn;
			byte_0[8 * i + 8] = (byte)cellArea.EndColumn;
		}
	}

	internal Class654(Class1133 class1133_0, int int_0, int int_1)
	{
		method_2(229);
		method_0((short)((int_1 - int_0) * 8 + 2));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes((short)(int_1 - int_0)), byte_0, 2);
		for (int i = int_0; i < int_1; i++)
		{
			CellArea cellArea = class1133_0[i];
			Array.Copy(BitConverter.GetBytes((ushort)cellArea.StartRow), 0, byte_0, 8 * (i - int_0) + 2, 2);
			Array.Copy(BitConverter.GetBytes((ushort)cellArea.EndRow), 0, byte_0, 8 * (i - int_0) + 4, 2);
			byte_0[8 * (i - int_0) + 6] = (byte)cellArea.StartColumn;
			byte_0[8 * (i - int_0) + 8] = (byte)cellArea.EndColumn;
		}
	}
}
