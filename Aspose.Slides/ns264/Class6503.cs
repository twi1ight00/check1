namespace ns264;

internal class Class6503
{
	private int int_0;

	public int R => int_0 & 0xFF;

	public int G => (int_0 >> 8) & 0xFF;

	public int B => (int_0 >> 16) & 0xFF;

	internal Enum869 Flags => (Enum869)((int_0 >> 24) & 0xFF);

	internal Class6503(int value)
	{
		int_0 = value;
	}
}
