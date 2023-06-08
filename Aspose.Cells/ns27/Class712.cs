using System;
using Aspose.Cells;
using ns2;

namespace ns27;

internal class Class712 : Class538
{
	internal Class712(Class1119 class1119_0)
	{
		method_2(566);
		byte_0 = new byte[16];
		method_0(16);
		CellArea cellArea_ = class1119_0.cellArea_0;
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_.StartRow), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_.EndRow), 0, byte_0, 2, 2);
		byte_0[4] = (byte)cellArea_.StartColumn;
		byte_0[5] = (byte)cellArea_.EndColumn;
		byte_0[6] = class1119_0.method_0();
		if (class1119_0.method_7())
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1119_0.int_0), 0, byte_0, 8, 2);
			Array.Copy(BitConverter.GetBytes((ushort)class1119_0.int_1), 0, byte_0, 10, 2);
			Array.Copy(BitConverter.GetBytes((ushort)class1119_0.int_2), 0, byte_0, 12, 2);
			Array.Copy(BitConverter.GetBytes((ushort)class1119_0.int_3), 0, byte_0, 14, 2);
		}
		else if (class1119_0.method_9())
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1119_0.int_0), 0, byte_0, 8, 2);
			Array.Copy(BitConverter.GetBytes((ushort)class1119_0.int_1), 0, byte_0, 10, 2);
		}
		else
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1119_0.int_2), 0, byte_0, 8, 2);
			Array.Copy(BitConverter.GetBytes((ushort)class1119_0.int_3), 0, byte_0, 10, 2);
		}
	}
}
