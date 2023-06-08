using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using ns183;

namespace ns204;

internal class Class5437
{
	public static Class5619 class5619_0 = new Class5619("http://xmlgraphics.apache.org/fop/extensions", null, "scale");

	private static string string_0 = "\\s+";

	private Class5437()
	{
	}

	public static PointF smethod_0(string scale)
	{
		string format = "Extension 'scale' attribute has incorrect value(s): {0}";
		if (string.IsNullOrEmpty(scale))
		{
			return PointF.Empty;
		}
		string[] array = Regex.Split(scale, string_0);
		double num;
		try
		{
			num = double.Parse(array[0], NumberStyles.Any, Class4985.smethod_0().Ci);
		}
		catch (FormatException)
		{
			throw new ArgumentException(string.Format(format, scale));
		}
		double num2;
		switch (array.Length)
		{
		default:
			throw new ArgumentException("Too many arguments");
		case 1:
			num2 = num;
			break;
		case 2:
			try
			{
				num2 = double.Parse(array[1], NumberStyles.Any, Class4985.smethod_0().Ci);
			}
			catch (FormatException)
			{
				throw new ArgumentException(string.Format(format, scale));
			}
			break;
		}
		if (num <= 0.0 || num2 <= 0.0)
		{
			throw new ArgumentException(string.Format(format, scale));
		}
		return new PointF((float)num, (float)num2);
	}
}
