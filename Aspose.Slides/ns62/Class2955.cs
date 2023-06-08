namespace ns62;

internal class Class2955
{
	private int int_0;

	private int int_1;

	public int X => int_0;

	public int Y => int_1;

	public uint Value
	{
		get
		{
			uint num = (uint)(Y << 16);
			return num | ((uint)X & 0xFFFFu);
		}
	}

	public ulong LongValue => (ulong)(((long)Y << 32) | (uint)X);

	public Class2955(int x, int y)
	{
		int_0 = x;
		int_1 = y;
	}
}
