using System.Globalization;

namespace ns322;

internal sealed class Class7436 : Class7399, Interface402
{
	private string string_21;

	public override object Value => string_21;

	public override string _Class => "String";

	public override string Type => "string";

	public static bool smethod_0(string value)
	{
		if (value == null)
		{
			return false;
		}
		if (!(value == "true") && value.Length <= 0)
		{
			return false;
		}
		return true;
	}

	public override bool vmethod_2()
	{
		return smethod_0(string_21);
	}

	public static double smethod_1(string value)
	{
		if (value == null)
		{
			return double.NaN;
		}
		if (double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		return double.NaN;
	}

	public override double vmethod_3()
	{
		return smethod_1(string_21);
	}

	public override string vmethod_6()
	{
		if (string_21 != null)
		{
			return "'" + ToString() + "'";
		}
		return "null";
	}

	public override string ToString()
	{
		return string_21;
	}

	public override int GetHashCode()
	{
		return string_21.GetHashCode();
	}

	public Class7436(string value, Class7399 prototype)
		: base(prototype)
	{
		string_21 = value;
	}
}
