using System;
using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6835 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		return value.ToLower(CultureInfo.InvariantCulture).Trim() switch
		{
			"full-justify" => Enum957.const_5, 
			"middle" => Enum957.const_2, 
			"justify" => Enum957.const_3, 
			"center" => Enum957.const_1, 
			"right" => Enum957.const_4, 
			_ => Enum957.const_0, 
		};
	}

	string Interface331.imethod_1(object value)
	{
		return method_0((Enum957)value);
	}

	public string method_0(Enum957 value)
	{
		return value switch
		{
			Enum957.const_0 => "left", 
			Enum957.const_1 => "center", 
			Enum957.const_2 => "middle", 
			Enum957.const_3 => "justify", 
			Enum957.const_4 => "right", 
			Enum957.const_5 => "full-justify", 
			_ => throw new ArgumentException("value"), 
		};
	}
}
