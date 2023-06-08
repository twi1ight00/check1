namespace ns11;

internal class Class1649
{
	private Class1649()
	{
	}

	public static void smethod_0(uint[] uint_0, uint uint_1, byte[] byte_0, uint uint_2, uint uint_3)
	{
		uint num = uint_1 / 4u;
		int num2 = (int)uint_1 % 4;
		for (int i = 0; i < uint_3; i++)
		{
			uint_0[num] &= (uint)(~(255 << num2 * 8));
			uint_0[num] |= (uint)(byte_0[uint_2 + i] << num2 * 8);
			if (++num2 == 4)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public static bool smethod_1(byte[] byte_0, byte[] byte_1, uint uint_0)
	{
		int num = 0;
		while (true)
		{
			if (num < uint_0)
			{
				if (byte_0[num] != byte_1[num])
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}
}
