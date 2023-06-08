namespace ns130;

internal class Class4582
{
	public const int int_0 = 1;

	public const int int_1 = 3;

	public const int int_2 = 2;

	public const int int_3 = 3;

	public const int int_4 = 3;

	public const int int_5 = 2;

	public const int int_6 = 7168;

	public const int int_7 = 512;

	public int int_8;

	public int int_9;

	public int int_10;

	public int int_11;

	public int int_12;

	public int int_13;

	public Class4582(int length)
	{
		int_13 = 1;
		for (int_11 = 1 + (1 << 3 * int_13) - 1; int_11 < length; int_11 = 1 + (1 << 3 * int_13) - 1)
		{
			int_13++;
		}
		int_8 = 256 + 8 * int_13;
		int_9 = int_8 + 1;
		int_10 = int_9 + 1;
		int_12 = int_10 + 1;
	}
}
