using System;

namespace ns8;

internal class Class738
{
	public static int smethod_0(string string_0)
	{
		int num = 0;
		while (true)
		{
			if (num < string_0.Length)
			{
				char c = string_0[num];
				if (c >= '0' && c <= '9')
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return Convert.ToInt32(string_0.Substring(num)) - 1;
	}

	public static int ColumnNameToIndex(string string_0)
	{
		int num = 0;
		foreach (char c in string_0)
		{
			if (c < 'A' || c > 'Z')
			{
				break;
			}
			num = num * 26 + c - 65 + 1;
		}
		return num - 1;
	}
}
