using System;
using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6837 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		return value.ToLower(CultureInfo.InvariantCulture).Trim() switch
		{
			"bottom" => Enum958.const_1, 
			"middle" => Enum958.const_2, 
			"sub" => Enum958.const_4, 
			"super" => Enum958.const_5, 
			"text-bottom" => Enum958.const_6, 
			"text-top" => Enum958.const_7, 
			"top" => Enum958.const_3, 
			_ => Enum958.const_0, 
		};
	}

	string Interface331.imethod_1(object value)
	{
		return method_0((Enum958)value);
	}

	public string method_0(Enum958 value)
	{
		return value switch
		{
			Enum958.const_0 => "baseline", 
			Enum958.const_1 => "bottom", 
			Enum958.const_2 => "middle", 
			Enum958.const_3 => "top", 
			Enum958.const_4 => "sub", 
			Enum958.const_5 => "super", 
			Enum958.const_6 => "text-bottom", 
			Enum958.const_7 => "text-top", 
			_ => throw new ArgumentException("value"), 
		};
	}
}
