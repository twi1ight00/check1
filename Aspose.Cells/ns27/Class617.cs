using System;
using Aspose.Cells;

namespace ns27;

internal class Class617 : Class538
{
	internal Class617()
	{
		method_2(125);
		method_0(12);
	}

	internal void method_4(Column column_0, int int_0, int int_1, int int_2, int int_3)
	{
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(int_2), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes(int_3), 0, byte_0, 2, 2);
		double num = column_0.Width;
		if (num > 255.0)
		{
			num = 255.0;
		}
		int num2 = 0;
		num2 = ((!(num >= 1.0)) ? ((ushort)(num * (256.0 + (double)int_1) + 0.5)) : ((ushort)(num * 256.0 + (double)int_1 + 0.5)));
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, 4, 2);
		int num3 = 15;
		num3 = ((column_0.method_5() != -1) ? column_0.method_5() : 15);
		Array.Copy(BitConverter.GetBytes(num3), 0, byte_0, 6, 2);
		byte b = 2;
		if (column_0.IsHidden)
		{
			b = (byte)(b | 1u);
		}
		if (column_0.method_16())
		{
			b = (byte)(b | 4u);
		}
		byte_0[8] = b;
		b = column_0.method_3();
		if (column_0.method_14())
		{
			b = (byte)(b | 0x10u);
		}
		byte_0[9] = b;
	}
}
