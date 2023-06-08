namespace ns18;

internal class Class1010
{
	private Class1010()
	{
	}

	public static uint smethod_0(uint uint_0)
	{
		return ((uint_0 & 0xFF) << 24) | ((uint_0 & 0xFF00) << 8) | ((uint_0 & 0xFF0000) >> 8) | ((uint_0 & 0xFF000000u) >> 24);
	}

	public static short smethod_1(short short_0)
	{
		return (short)smethod_2((ushort)short_0);
	}

	public static ushort smethod_2(ushort ushort_0)
	{
		return (ushort)(((ushort_0 & 0xFF) << 8) | ((ushort_0 & 0xFF00) >> 8));
	}
}
