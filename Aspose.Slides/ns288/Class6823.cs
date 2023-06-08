using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6823 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		return value.ToLower(CultureInfo.InvariantCulture).Trim() switch
		{
			"center" => Enum948.const_1, 
			"right" => Enum948.const_2, 
			_ => Enum948.const_0, 
		};
	}

	public string imethod_1(object value)
	{
		return (Enum948)value switch
		{
			Enum948.const_1 => "center", 
			Enum948.const_2 => "right", 
			_ => "left", 
		};
	}
}
