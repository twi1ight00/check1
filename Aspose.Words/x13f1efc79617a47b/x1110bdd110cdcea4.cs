namespace x13f1efc79617a47b;

internal class x1110bdd110cdcea4
{
	public static string _xaacba899487bce8c(string x5e99b576d2530d13, int x2710752c36f2d14b)
	{
		ushort num = (ushort)x2710752c36f2d14b;
		char[] array = default(char[]);
		if ((uint)x2710752c36f2d14b <= uint.MaxValue)
		{
			array = new char[x5e99b576d2530d13.Length / 4];
			for (int i = 0; i < x5e99b576d2530d13.Length / 4; i++)
			{
				ushort num2 = (ushort)(x5e99b576d2530d13[4 * i] - 97 + (x5e99b576d2530d13[4 * i + 1] - 97 << 4) + (x5e99b576d2530d13[4 * i + 2] - 97 << 8) + (x5e99b576d2530d13[4 * i + 3] - 97 << 12));
				do
				{
					num2 = (array[i] = (char)(num2 - num));
					num = (ushort)(num + 1789);
				}
				while ((uint)(x2710752c36f2d14b + x2710752c36f2d14b) > uint.MaxValue);
			}
		}
		return new string(array);
	}
}
