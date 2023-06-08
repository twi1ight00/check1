using System;
using System.Globalization;

namespace ns22;

internal class Class1024
{
	private Class1024()
	{
	}

	public static int GetHashCode(double double_0)
	{
		return double_0.GetHashCode();
	}

	public static double smethod_0(double double_0, int int_0)
	{
		return Math.Round(double_0, int_0, MidpointRounding.AwayFromZero);
	}

	public static double smethod_1(string string_0)
	{
		return double.Parse(string_0, CultureInfo.InvariantCulture);
	}
}
