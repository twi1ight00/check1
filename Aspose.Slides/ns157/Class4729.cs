using System.Globalization;
using System.Text;

namespace ns157;

internal class Class4729
{
	public static bool smethod_0(byte[] testBytes, int index)
	{
		if (testBytes[index] == 45)
		{
			if (index + 1 <= testBytes.Length - 1)
			{
				return smethod_2(testBytes[index + 1]);
			}
			return false;
		}
		return smethod_2(testBytes[index]);
	}

	public static string smethod_1(string denormalizedString)
	{
		return denormalizedString.Replace(".", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator).Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
	}

	public static double ToDouble(string strValue)
	{
		double result = double.MinValue;
		double.TryParse(smethod_1(strValue.ToString()), NumberStyles.Float, CultureInfo.InvariantCulture, out result);
		return result;
	}

	private static bool smethod_2(byte testByte)
	{
		string @string = Encoding.ASCII.GetString(new byte[1] { testByte });
		double result;
		return double.TryParse(@string, out result);
	}
}
