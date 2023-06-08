using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6829 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		string text;
		if ((text = value.ToLower(CultureInfo.InvariantCulture).Trim()) != null && text == "show")
		{
			return Enum937.const_0;
		}
		return Enum937.const_1;
	}

	public string imethod_1(object value)
	{
		if ((Enum937)value == Enum937.const_0)
		{
			return "show";
		}
		return "hide";
	}
}
