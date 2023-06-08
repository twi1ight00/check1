namespace ns228;

internal class Class6024
{
	private Class6024()
	{
	}

	public static int smethod_0(int a)
	{
		int num = 0;
		while (a != 0)
		{
			a >>= 1;
			num++;
		}
		return num - 1;
	}

	public static int smethod_1(int size, int alignmentSize)
	{
		int num = alignmentSize - size % alignmentSize;
		if (num != alignmentSize)
		{
			return num;
		}
		return 0;
	}
}
