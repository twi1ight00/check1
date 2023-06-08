using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6830 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		return value.ToLower(CultureInfo.InvariantCulture).Trim() switch
		{
			"right" => Enum954.const_2, 
			"left" => Enum954.const_1, 
			_ => Enum954.const_0, 
		};
	}

	public string imethod_1(object value)
	{
		return (Enum954)value switch
		{
			Enum954.const_1 => "left", 
			Enum954.const_2 => "right", 
			_ => "none", 
		};
	}
}
