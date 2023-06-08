using System;
using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6834 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		string text;
		if ((text = value.ToLower(CultureInfo.InvariantCulture).Trim()) != null && text == "fixed")
		{
			return Enum939.const_1;
		}
		return Enum939.const_0;
	}

	string Interface331.imethod_1(object value)
	{
		return method_0((Enum939)value);
	}

	public string method_0(Enum939 value)
	{
		return value switch
		{
			Enum939.const_0 => "auto", 
			Enum939.const_1 => "fixed", 
			_ => throw new ArgumentException("value"), 
		};
	}
}
