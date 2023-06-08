using System;
using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6836 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		return value.ToLower(CultureInfo.InvariantCulture).Trim() switch
		{
			"uppercase" => Enum940.const_2, 
			"lowercase" => Enum940.const_3, 
			"capitalize" => Enum940.const_1, 
			_ => Enum940.const_0, 
		};
	}

	string Interface331.imethod_1(object value)
	{
		return method_0((Enum940)value);
	}

	public string method_0(Enum940 value)
	{
		return value switch
		{
			Enum940.const_0 => "none", 
			Enum940.const_1 => "capitalize", 
			Enum940.const_2 => "uppercase", 
			Enum940.const_3 => "lowercase", 
			_ => throw new ArgumentException("value"), 
		};
	}
}
