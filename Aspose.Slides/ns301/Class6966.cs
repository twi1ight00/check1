using System.Text;

namespace ns301;

internal sealed class Class6966
{
	private const string string_0 = "abcdefghijklmnopqrstuvwxyz";

	private const string string_1 = " abcdefghijklmnopqrstuvwxyz";

	private const string string_2 = "-";

	private static readonly string[] string_3 = new string[13]
	{
		"i", "iv", "v", "ix", "x", "xl", "l", "xc", "c", "cd",
		"d", "cm", "m"
	};

	private static readonly int[] int_0 = new int[13]
	{
		1, 4, 5, 9, 10, 40, 50, 90, 100, 400,
		500, 900, 1000
	};

	private Class6966()
	{
	}

	public static string smethod_0(int number)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int length = "abcdefghijklmnopqrstuvwxyz".Length;
		int index = number % length;
		number /= length;
		if (number > 0)
		{
			while (number > 0)
			{
				int index2 = number % length;
				if (number >= length - 1)
				{
					stringBuilder.Insert(0, "abcdefghijklmnopqrstuvwxyz"[index2]);
				}
				else
				{
					stringBuilder.Insert(0, " abcdefghijklmnopqrstuvwxyz"[index2]);
				}
				number /= length;
			}
		}
		stringBuilder.Append("abcdefghijklmnopqrstuvwxyz"[index]);
		return stringBuilder.ToString();
	}

	public static string smethod_1(int number)
	{
		if (number <= 0)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = number;
		for (int num2 = int_0.Length - 1; num2 >= 0; num2--)
		{
			while (num >= int_0[num2])
			{
				num -= int_0[num2];
				stringBuilder.Append(string_3[num2]);
			}
		}
		return stringBuilder.ToString();
	}
}
