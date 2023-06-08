using System;

namespace ns27;

internal class Class657 : Class538
{
	internal static byte[] smethod_0(double double_0)
	{
		byte[] array = new byte[4];
		byte[] bytes = BitConverter.GetBytes(double_0);
		if ((bytes[4] & 3) == 0 && bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0 && bytes[3] == 0)
		{
			array[0] = bytes[4];
			array[1] = bytes[5];
			array[2] = bytes[6];
			array[3] = bytes[7];
		}
		else if (Math.Abs(double_0 - (double)(int)double_0) < double.Epsilon && Math.Abs((int)double_0) < 536870911)
		{
			int value = (int)double_0 << 2;
			bytes = BitConverter.GetBytes(value);
			array[0] = (byte)(bytes[0] + 2);
			array[1] = bytes[1];
			array[2] = bytes[2];
			array[3] = bytes[3];
		}
		else
		{
			double num = double_0 * 100.0;
			bytes = BitConverter.GetBytes(num);
			if ((bytes[4] & 3) == 0 && bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0 && bytes[3] == 0)
			{
				array[0] = (byte)(bytes[4] + 1);
				array[1] = bytes[5];
				array[2] = bytes[6];
				array[3] = bytes[7];
			}
			else
			{
				bytes = BitConverter.GetBytes((int)num << 2);
				array[0] = (byte)(bytes[0] + 3);
				array[1] = bytes[1];
				array[2] = bytes[2];
				array[3] = bytes[3];
			}
		}
		return array;
	}
}
