using System;
using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6833 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		return value.ToLower(CultureInfo.InvariantCulture).Trim() switch
		{
			"relative" => Enum956.const_3, 
			"fixed" => Enum956.const_2, 
			"absolute" => Enum956.const_1, 
			_ => Enum956.const_0, 
		};
	}

	string Interface331.imethod_1(object value)
	{
		return method_0((Enum956)value);
	}

	public string method_0(Enum956 value)
	{
		return value switch
		{
			Enum956.const_0 => "static", 
			Enum956.const_1 => "absolute", 
			Enum956.const_2 => "fixed", 
			Enum956.const_3 => "relative", 
			_ => throw new ArgumentException("value"), 
		};
	}
}
