using System;
using Aspose.Cells;

namespace ns27;

internal class Class692 : Class538
{
	internal Class692()
	{
		method_2(520);
		method_0(16);
		byte_0 = new byte[base.Length];
	}

	internal void method_4(Row row_0, int int_0, int int_1)
	{
		Array.Copy(BitConverter.GetBytes((ushort)row_0.int_0), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes(row_0.method_13()), 0, byte_0, 6, 2);
		int num = row_0.method_8();
		num = ((num & 0xF000) << 16) | (num & 0xFFF0FFF);
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 12, 4);
	}
}
