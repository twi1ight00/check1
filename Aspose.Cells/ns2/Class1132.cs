using System;

namespace ns2;

internal class Class1132
{
	internal static bool smethod_0(int int_0)
	{
		if (int_0 >= -536870911)
		{
			return int_0 <= 536870911;
		}
		return false;
	}

	internal static bool smethod_1(double double_0)
	{
		try
		{
			byte[] array = new byte[8];
			array = BitConverter.GetBytes(double_0);
			if ((array[4] & 3) == 0 && array[0] == 0 && array[1] == 0 && array[2] == 0 && array[3] == 0)
			{
				return true;
			}
			if (Math.Abs(double_0 - (double)(int)double_0) < double.Epsilon && Math.Abs((int)double_0) < 536870911)
			{
				return true;
			}
			double num = double_0 * 100.0;
			array = BitConverter.GetBytes(num);
			if ((array[4] & 3) == 0 && array[0] == 0 && array[1] == 0 && array[2] == 0 && array[3] == 0)
			{
				return true;
			}
			if (Math.Abs(num - (double)(int)num) < double.Epsilon && Math.Abs((int)num) < 536870911)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	internal static double smethod_2(int int_0)
	{
		double num = 0.0;
		if (((uint)int_0 & 2u) != 0)
		{
			num = int_0 >> 2;
		}
		else
		{
			int value = int_0 - (int_0 & 3);
			byte[] array = new byte[8];
			Array.Copy(BitConverter.GetBytes(value), 0, array, 4, 4);
			num = BitConverter.ToDouble(array, 0);
		}
		if (((uint)int_0 & (true ? 1u : 0u)) != 0)
		{
			num /= 100.0;
		}
		return num;
	}

	internal static byte[] smethod_3(double double_0)
	{
		byte[] bytes = BitConverter.GetBytes(double_0);
		byte[] array = new byte[4];
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
			array = BitConverter.GetBytes(value);
			array[0] = (byte)(array[0] + 2);
		}
		else
		{
			if (double_0 > 1.7976931348623156E+306 || !(double_0 >= -1.7976931348623156E+306))
			{
				return null;
			}
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
				if (!(Math.Abs(num - (double)(int)num) < double.Epsilon) || Math.Abs((int)num) >= 536870911)
				{
					return null;
				}
				array = BitConverter.GetBytes((int)num << 2);
				array[0] = (byte)(array[0] + 3);
			}
		}
		return array;
	}
}
