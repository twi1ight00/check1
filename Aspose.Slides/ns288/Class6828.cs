using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6828 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		string text;
		if ((text = value.ToLower(CultureInfo.InvariantCulture).Trim()) != null && text == "rtl")
		{
			return Enum936.const_1;
		}
		return Enum936.const_0;
	}

	public string imethod_1(object value)
	{
		Enum936 @enum = (Enum936)value;
		if (@enum == Enum936.const_1)
		{
			return "rtl";
		}
		return "ltr";
	}
}
