namespace ns130;

internal class Class4579
{
	private int int_0;

	private Class4576 class4576_0;

	private Class4576 class4576_1;

	private Class4576 class4576_2;

	private Class4582 class4582_0;

	public byte[] method_0(byte[] data)
	{
		Class4574 @class = new Class4574(data);
		@class.method_0();
		class4576_0 = new Class4576(@class, 8);
		class4576_1 = new Class4576(@class, 8);
		int_0 = @class.method_1(24);
		class4582_0 = new Class4582(int_0);
		class4576_2 = new Class4576(@class, class4582_0.int_12);
		return method_1(data);
	}

	private byte[] method_1(byte[] data)
	{
		byte[] array = smethod_0(int_0 + 7168);
		byte[] array2 = new byte[int_0];
		int num = 0;
		int num2 = 7168;
		while (num2 < array.Length)
		{
			short num3 = class4576_2.method_0();
			byte b;
			if (num3 < 256)
			{
				b = (byte)num3;
			}
			else if (num3 == class4582_0.int_8)
			{
				int num4 = num2 - 2;
				b = array[num4];
			}
			else if (num3 == class4582_0.int_9)
			{
				int num4 = num2 - 4;
				b = array[num4];
			}
			else
			{
				int num4;
				if (num3 != class4582_0.int_10)
				{
					int numDistRanges;
					int num5 = method_3(num3, out numDistRanges);
					int num6 = method_2(numDistRanges);
					if (num6 >= 512)
					{
						num5++;
					}
					int num7 = num2 - num6 - num5 + 1;
					for (int i = 0; i < num5; i++)
					{
						num4 = num7 + i;
						b = array[num4];
						array[num2++] = b;
						array2[num++] = b;
					}
					continue;
				}
				num4 = num2 - 6;
				b = array[num4];
			}
			array[num2++] = b;
			array2[num++] = b;
		}
		return array2;
	}

	private static byte[] smethod_0(int length)
	{
		byte[] array = new byte[length];
		int num = 0;
		for (int i = 0; i < 32; i++)
		{
			for (int j = 0; j < 96; j++)
			{
				array[num++] = (byte)i;
				array[num++] = (byte)j;
			}
		}
		int num2 = 0;
		while (num < 7168 && num2 < 256)
		{
			array[num++] = (byte)num2;
			array[num++] = (byte)num2;
			array[num++] = (byte)num2;
			array[num++] = (byte)num2;
			num2++;
		}
		return array;
	}

	private int method_2(int distRanges)
	{
		int num = 0;
		for (int num2 = distRanges; num2 > 0; num2--)
		{
			int num3 = class4576_0.method_0();
			num <<= 3;
			num |= num3;
		}
		return num + 1;
	}

	private int method_3(short symbol, out int numDistRanges)
	{
		numDistRanges = 0;
		int num = 4;
		bool flag = symbol >= 0;
		int num2 = 0;
		bool flag2;
		do
		{
			int num3;
			if (!flag)
			{
				num3 = class4576_1.method_0();
			}
			else
			{
				num3 = symbol - 256;
				flag = false;
				numDistRanges = num3 / 8 + 1;
				num3 %= 8;
			}
			flag2 = (num3 & num) == 0;
			num3 &= ~num;
			num2 <<= 2;
			num2 |= num3;
		}
		while (!flag2);
		return num2 + 2;
	}
}
