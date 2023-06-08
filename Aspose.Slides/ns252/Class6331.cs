using System.Text.RegularExpressions;
using ns234;

namespace ns252;

internal class Class6331
{
	private static readonly Regex regex_0 = new Regex("-?[0-9]+(\\.[0-9]+)?%", RegexOptions.Compiled);

	private readonly string string_0;

	private double double_0;

	public double Fraction => double_0;

	public string Value => string_0;

	public Class6331(double value)
	{
		string_0 = Class6159.smethod_41(value * 100.0) + "%";
		double_0 = value;
	}

	public Class6331(string value)
	{
		string input = ((value != null) ? value : string.Empty);
		if (!regex_0.IsMatch(input))
		{
			input = string.Empty;
		}
		string_0 = input;
		double_0 = 0.0;
		method_0();
	}

	public bool Equals(Class6331 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (object.Equals(other.string_0, string_0))
		{
			return other.double_0.Equals(double_0);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(Class6331))
		{
			return false;
		}
		return Equals((Class6331)obj);
	}

	public override int GetHashCode()
	{
		return (((string_0 != null) ? string_0.GetHashCode() : 0) * 397) ^ double_0.GetHashCode();
	}

	private void method_0()
	{
		if (Value.Length == 0)
		{
			double_0 = 0.0;
			return;
		}
		string val = Value.Substring(0, Value.Length - 1);
		double num = Class6159.smethod_8(val);
		double_0 = num / 100.0;
	}
}
