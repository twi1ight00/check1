namespace ns50;

internal class Class1104
{
	public int int_0;

	public int int_1;

	public bool bool_0;

	public Class1104()
	{
		int_0 = 0;
		int_1 = 0;
		bool_0 = false;
	}

	public int Contains(int int_2)
	{
		if (int_2 < int_0)
		{
			return -1;
		}
		if (int_2 > int_0 + int_1)
		{
			return 1;
		}
		return 0;
	}
}
