namespace ns45;

internal class Class1102 : Class1099
{
	private int int_3;

	private int int_4;

	public Class1102(int sectorSize)
	{
		int_4 = sectorSize;
	}

	public void method_3(int firstSID, Class1101 sat, Interface36 reader)
	{
		int[] array = sat.method_1(firstSID);
		int_0 = new int[array.Length * reader.imethod_1(0).method_0().Length];
		for (int i = 0; i < array.Length; i++)
		{
			Class1111 @class = reader.imethod_1(array[i]);
			method_0(@class, @class.method_0().Length);
		}
	}

	public int method_4(int firstSID)
	{
		int[] array = null;
		array = ((firstSID < 0) ? new int[0] : method_1(firstSID));
		int num = method_5();
		if (array.Length != 0)
		{
			int_0[array[array.Length - 1]] = num;
		}
		int_0[num] = -2;
		return num;
	}

	private int method_5()
	{
		if (int_3 + 1 > int_0.Length - 1)
		{
			method_2();
		}
		while (int_0[int_3] != -1)
		{
			int_3++;
		}
		return int_3;
	}

	public int method_6(int numberOfSectors)
	{
		int num = method_4(-5);
		int result = num;
		for (int i = 1; i < numberOfSectors; i++)
		{
			num = method_4(num);
		}
		return result;
	}
}
