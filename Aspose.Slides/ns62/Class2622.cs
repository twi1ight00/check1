namespace ns62;

internal class Class2622
{
	private uint uint_0;

	public int FSysIndex => (int)((uint_0 >> 28) & 1);

	public int FSchemeIndex => (int)((uint_0 >> 27) & 1);

	public int FSystemRGB => (int)((uint_0 >> 26) & 1);

	public int FPaletteRGB => (int)((uint_0 >> 25) & 1);

	public int FPaletteIndex => (int)((uint_0 >> 24) & 1);

	public uint Blue => (uint_0 >> 16) & 0xFFu;

	public uint Green => (uint_0 >> 8) & 0xFFu;

	public uint Red => uint_0 & 0xFFu;

	public Class2622(uint value)
	{
		uint_0 = value;
	}
}
