namespace ns2;

internal class Class1735
{
	private uint[] uint_0;

	private uint uint_1;

	internal uint Value => uint_1;

	internal Class1735()
	{
		uint_0 = new uint[256];
		method_0();
	}

	internal void method_0()
	{
		for (int i = 0; i < 256; i++)
		{
			uint num = (uint)i;
			num <<= 24;
			for (int j = 0; j < 8; j++)
			{
				if ((num & 0x80000000u) != 0)
				{
					num <<= 1;
					num ^= 0xAFu;
				}
				else
				{
					num <<= 1;
				}
			}
			num &= 0xFFFFu;
			uint_0[i] = num;
		}
	}

	internal void Update(byte[] byte_0)
	{
		foreach (byte b in byte_0)
		{
			uint num = uint_1;
			num >>= 24;
			num ^= b;
			uint_1 <<= 8;
			uint_1 ^= uint_0[num];
		}
	}
}
