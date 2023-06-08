using System;
using System.Globalization;

namespace ns22;

internal class Class1025
{
	private static readonly string[] string_0 = new string[11]
	{
		"{0}", "{0:0}", "{0:00}", "{0:000}", "{0:0000}", "{0:00000}", "{0:000000}", "{0:0000000}", "{0:00000000}", "{0:000000000}",
		"{0:0000000000}"
	};

	private Class1025()
	{
	}

	public static string smethod_0(DateTime dateTime_0)
	{
		return dateTime_0.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
	}

	public static double smethod_1(string string_1)
	{
		return double.Parse(string_1, NumberStyles.Float, CultureInfo.InvariantCulture);
	}

	public static int smethod_2(string string_1)
	{
		return int.Parse(string_1, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
	}

	public static string smethod_3(double double_0)
	{
		return double_0.ToString("0.##################################", CultureInfo.InvariantCulture);
	}

	public static string smethod_4(int int_0)
	{
		return int_0.ToString("X", CultureInfo.InvariantCulture);
	}

	public static string smethod_5(int int_0)
	{
		return int_0.ToString("X2", CultureInfo.InvariantCulture);
	}

	public static string smethod_6(int int_0)
	{
		return int_0.ToString("X4", CultureInfo.InvariantCulture);
	}

	public static string smethod_7(int int_0)
	{
		return int_0.ToString("X8", CultureInfo.InvariantCulture);
	}

	public static string smethod_8(double double_0)
	{
		return double_0.ToString(CultureInfo.InvariantCulture);
	}

	public static string smethod_9(double double_0)
	{
		return double_0.ToString("0.#########", CultureInfo.InvariantCulture);
	}

	public static string smethod_10(float float_0)
	{
		return ((double)float_0).ToString("0.########", CultureInfo.InvariantCulture);
	}

	public static string smethod_11(float float_0)
	{
		return ((double)float_0).ToString("0.#########", CultureInfo.InvariantCulture);
	}

	public static string GetFormat(int int_0, int int_1)
	{
		return int_0 switch
		{
			22 => "g", 
			14 => "d", 
			_ => null, 
		};
	}
}
