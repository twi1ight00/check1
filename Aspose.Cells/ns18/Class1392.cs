namespace ns18;

internal class Class1392
{
	private Class1392()
	{
	}

	public static int smethod_0(int[] int_0, int int_1, int int_2, int int_3)
	{
		int num = int_1;
		int num2 = int_1 + int_2 - 1;
		int num3;
		while (true)
		{
			if (num <= num2)
			{
				num3 = num + num2 >> 1;
				int num4 = int_0[num3];
				if (num4 == int_3)
				{
					break;
				}
				if (num4 < int_3)
				{
					num = num3 + 1;
				}
				else
				{
					num2 = num3 - 1;
				}
				continue;
			}
			return ~num;
		}
		return num3;
	}
}
