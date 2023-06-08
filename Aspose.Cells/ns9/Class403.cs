using System;
using System.Collections;
using Aspose.Cells;

namespace ns9;

internal class Class403 : Class316
{
	internal Class403()
	{
		int_0 = 60;
	}

	internal void method_6(Column column_0, int int_1, int int_2, Hashtable hashtable_0)
	{
		byte_0 = new byte[18];
		Array.Copy(BitConverter.GetBytes(column_0.Index), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(int_1), 0, byte_0, 4, 4);
		int num = 0;
		num = ((!(column_0.Width >= 1.0)) ? ((int)(column_0.Width * (256.0 + (double)int_2) + 0.5)) : ((int)(column_0.Width * 256.0 + (double)int_2 + 0.5)));
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 8, 4);
		int value = (int)hashtable_0[(column_0.method_5() == -1) ? 15 : column_0.method_5()];
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 12, 4);
		ushort num2 = 0;
		if (column_0.IsHidden)
		{
			num2 = (ushort)(num2 | 1u);
		}
		if (column_0.method_3() > 0)
		{
			num2 = (ushort)(num2 | (ushort)(column_0.method_3() << 8));
		}
		if (column_0.method_14())
		{
			num2 = (ushort)(num2 | 0x1000u);
		}
		num2 = (ushort)(num2 | 2u);
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, 16, 2);
	}
}
