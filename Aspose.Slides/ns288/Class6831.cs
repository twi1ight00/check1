using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6831 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		string text;
		if ((text = value.ToLower(CultureInfo.InvariantCulture).Trim()) != null && text == "inside")
		{
			return Enum938.const_1;
		}
		return Enum938.const_0;
	}

	public string imethod_1(object value)
	{
		Enum938 @enum = (Enum938)value;
		if (@enum == Enum938.const_1)
		{
			return "inside";
		}
		return "outside";
	}
}
