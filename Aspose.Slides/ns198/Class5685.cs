namespace ns198;

internal class Class5685
{
	private int[] int_0;

	private int int_1;

	private int int_2;

	public Class5685(int[] hyphPoints)
	{
		int_0 = hyphPoints;
	}

	public int method_0()
	{
		while (true)
		{
			if (int_2 < int_0.Length)
			{
				if (int_0[int_2] > int_1)
				{
					break;
				}
				int_2++;
				continue;
			}
			return -1;
		}
		return int_0[int_2] - int_1;
	}

	public bool method_1()
	{
		while (true)
		{
			if (int_2 < int_0.Length)
			{
				if (int_0[int_2] > int_1)
				{
					break;
				}
				int_2++;
				continue;
			}
			return false;
		}
		return true;
	}

	public void method_2(int iCharsProcessed)
	{
		int_1 += iCharsProcessed;
	}
}
