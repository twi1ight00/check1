using System;

namespace ns206;

internal class Class5454
{
	private int int_0;

	private int int_1;

	public static Class5454 smethod_0(string weightRangeString)
	{
		string[] array = weightRangeString.Replace("..", ".").Split('.');
		Class5454 result = null;
		if (array.Length == 2)
		{
			string s = array[0].Trim();
			try
			{
				int num = int.Parse(s);
				int num2 = int.Parse(array[1]);
				if (num <= num2)
				{
					result = new Class5454(num, num2);
				}
			}
			catch (Exception ex)
			{
				if (!(ex is FormatException))
				{
					throw;
				}
			}
		}
		return result;
	}

	public Class5454(int start, int end)
	{
		int_0 = start;
		int_1 = end;
	}

	public bool method_0(int value)
	{
		if (value >= int_0)
		{
			return value <= int_1;
		}
		return false;
	}

	public override string ToString()
	{
		return int_0 + ".." + int_1;
	}

	public int[] method_1()
	{
		int num = 0;
		for (int i = int_0; i <= int_1; i += 100)
		{
			num++;
		}
		int[] array = new int[num];
		for (int j = 0; j < num; j++)
		{
			array[j] = int_0 + j * 100;
		}
		return array;
	}
}
