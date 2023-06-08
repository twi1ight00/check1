namespace ns157;

internal class Class4728
{
	internal enum Enum667
	{
		const_0,
		const_1
	}

	private const int int_0 = 52845;

	private const int int_1 = 22719;

	private int int_2;

	public Class4728(Enum667 mode)
	{
		switch (mode)
		{
		case Enum667.const_0:
			int_2 = 55665;
			break;
		case Enum667.const_1:
			int_2 = 4330;
			break;
		}
	}

	public byte method_0(byte cipher)
	{
		byte b = (byte)(int_2 >> 8);
		byte result = (byte)(cipher ^ b);
		int_2 = ((cipher + int_2) * 52845 + 22719) & 0xFFFF;
		return result;
	}

	public byte Encrypt(byte plain)
	{
		byte b = (byte)(int_2 >> 8);
		byte b2 = (byte)(plain ^ b);
		int_2 = ((b2 + int_2) * 52845 + 22719) & 0xFFFF;
		return b2;
	}
}
