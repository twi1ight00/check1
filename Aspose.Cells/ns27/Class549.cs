using System;
using Aspose.Cells.Charts;

namespace ns27;

internal class Class549 : Class538
{
	internal Class549()
	{
		method_2(2206);
	}

	internal void method_4(byte[] byte_1)
	{
		method_0((short)(20 + byte_1.Length));
		byte_0 = new byte[base.Length];
		byte_0[0] = 158;
		byte_0[1] = 8;
		Array.Copy(BitConverter.GetBytes(byte_1.Length), 0, byte_0, 12, 4);
		Array.Copy(byte_1, 0, byte_0, 16, byte_1.Length);
	}

	internal void method_5(Axis axis_0)
	{
		method_0(32);
		byte_0 = new byte[base.Length];
		byte_0[0] = 158;
		byte_0[1] = 8;
		byte_0[12] = 12;
		byte_0[18] = 4;
		smethod_0(axis_0.TickMarkSpacing, 81, byte_0, 20);
	}

	internal static int smethod_0(int int_0, byte byte_1, byte[] byte_2, int int_1)
	{
		byte_2[int_1] = 4;
		byte_2[int_1 + 2] = byte_1;
		Array.Copy(BitConverter.GetBytes(int_0), 0, byte_2, int_1 + 4, 4);
		return 8;
	}
}
