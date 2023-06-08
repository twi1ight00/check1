using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6824 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		string text;
		if ((text = value.ToLower(CultureInfo.InvariantCulture).Trim()) != null && text == "collapse")
		{
			return Enum933.const_1;
		}
		return Enum933.const_0;
	}

	public string imethod_1(object value)
	{
		Enum933 @enum = (Enum933)value;
		if (@enum == Enum933.const_1)
		{
			return "collapse";
		}
		return "separate";
	}
}
