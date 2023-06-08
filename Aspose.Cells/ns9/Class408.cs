using System;
using System.Collections;
using Aspose.Cells;

namespace ns9;

internal class Class408 : Class316
{
	internal Class408()
	{
		int_0 = 0;
	}

	internal void method_6(Row row_0, int int_1, int int_2, Hashtable hashtable_0)
	{
		byte_0 = new byte[25];
		Array.Copy(BitConverter.GetBytes(row_0.int_0), 0, byte_0, 0, 4);
		int value = (int)hashtable_0[row_0.method_10()];
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes(row_0.method_13()), 0, byte_0, 8, 2);
		byte b = 0;
		if (row_0.method_24() > 0)
		{
			b = (byte)(b | row_0.method_24());
		}
		if (row_0.method_15())
		{
			b = (byte)(b | 8u);
		}
		if (row_0.IsHidden)
		{
			b = (byte)(b | 0x10u);
		}
		if (!row_0.IsHeightMatched)
		{
			b = (byte)(b | 0x20u);
		}
		if (row_0.method_20())
		{
			b = (byte)(b | 0x40u);
		}
		byte_0[11] = b;
		Array.Copy(BitConverter.GetBytes(1), 0, byte_0, 13, 4);
		Array.Copy(BitConverter.GetBytes(int_1), 0, byte_0, 17, 4);
		Array.Copy(BitConverter.GetBytes(int_2), 0, byte_0, 21, 4);
	}
}
