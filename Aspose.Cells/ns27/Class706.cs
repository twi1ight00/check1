using System;

namespace ns27;

internal class Class706 : Class538
{
	internal Class706(double double_0, int int_0)
	{
		method_2(153);
		method_0(2);
		byte_0 = new byte[2];
		if (double_0 > 0.0)
		{
			if (double_0 > 1.0)
			{
				ushort value = (ushort)Math.Floor(double_0 * 256.0 + (double)int_0 + 0.5);
				Array.Copy(BitConverter.GetBytes(value), byte_0, 2);
			}
			else
			{
				ushort value2 = (ushort)Math.Floor(double_0 * (double)(256 + int_0) + 0.5);
				Array.Copy(BitConverter.GetBytes(value2), byte_0, 2);
			}
		}
	}
}
