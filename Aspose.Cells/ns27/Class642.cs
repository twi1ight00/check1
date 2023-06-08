namespace ns27;

internal class Class642 : Class538
{
	internal Class642()
	{
		method_2(171);
		method_0(34);
		byte_0 = new byte[34];
		byte_0[0] = 32;
		byte_0[1] = 0;
		for (int i = 2; i < 34; i++)
		{
			byte_0[i] = byte.MaxValue;
		}
	}

	internal void method_4(byte byte_1)
	{
		byte b = (byte)((int)byte_1 / 8);
		byte b2 = (byte)((int)byte_1 % 8);
		byte b3 = (byte)(1 << (int)b2);
		byte_0[2 + b] = (byte)(byte_0[2 + b] - b3);
	}
}
