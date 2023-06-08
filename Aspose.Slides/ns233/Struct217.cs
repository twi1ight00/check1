namespace ns233;

internal struct Struct217
{
	public readonly short short_0;

	public readonly short short_1;

	public readonly short short_2;

	public Struct217(short length, short code, short runlen)
	{
		short_1 = length;
		short_0 = code;
		short_2 = runlen;
	}

	public Struct217(int length, int code, int runlen)
		: this((short)length, (short)code, (short)runlen)
	{
	}

	public static Struct217 smethod_0(short[] array, int entryNumber)
	{
		int num = entryNumber * 3;
		return new Struct217(array[num], array[num + 1], array[num + 2]);
	}
}
