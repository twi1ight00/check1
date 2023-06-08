namespace ns47;

internal class Class1075
{
	internal static int smethod_0(int int_0, int int_1)
	{
		int num = 1;
		if (int_0 < 0)
		{
			int_0 = -int_0;
			num = -1;
		}
		if (int_1 < 0)
		{
			int_1 = -int_1;
			num = -num;
		}
		int num2 = (int)((long)int_0 * (long)int_1 + 32768 >> 16);
		if (num <= 0)
		{
			return -num2;
		}
		return num2;
	}

	internal static int smethod_1(int int_0, int int_1)
	{
		int num = 1;
		if (int_0 < 0)
		{
			int_0 = -int_0;
			num = -1;
		}
		if (int_1 < 0)
		{
			int_1 = -int_1;
			num = -num;
		}
		uint num2 = (uint)((int_1 != 0) ? ((((long)int_0 << 16) + (int_1 >> 1)) / int_1) : 2147483647u);
		if (num >= 0)
		{
			return (int)num2;
		}
		return (int)(0 - num2);
	}

	internal static int smethod_2(int int_0)
	{
		return int_0 & -64;
	}

	internal static int smethod_3(int int_0)
	{
		return (int_0 + 32) & -64;
	}

	internal static int smethod_4(int int_0)
	{
		return (int_0 + 63) & -64;
	}
}
