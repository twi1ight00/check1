using System;
using System.Text;

namespace ns148;

internal class Class4684
{
	private static Random random_0;

	static Class4684()
	{
		random_0 = new Random();
	}

	public static string smethod_0(string fontName)
	{
		return smethod_1() + fontName;
	}

	public static string smethod_1()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 6; i++)
		{
			stringBuilder.Append((char)(random_0.NextDouble() * 26.0 + 65.0));
		}
		stringBuilder.Append("+");
		return stringBuilder.ToString();
	}
}
