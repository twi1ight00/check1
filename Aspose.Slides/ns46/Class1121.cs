namespace ns46;

internal class Class1121
{
	public int int_0;

	public int int_1;

	public readonly char[] char_0;

	public int Length => int_1 - int_0;

	internal Class1121(int startIndex, int endIndex, char[] data)
	{
		int_0 = startIndex;
		int_1 = endIndex;
		char_0 = data;
	}
}
