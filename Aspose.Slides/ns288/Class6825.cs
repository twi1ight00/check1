using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6825 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		return value.ToLower(CultureInfo.InvariantCulture).Trim() switch
		{
			"right" => Enum935.const_2, 
			"left" => Enum935.const_1, 
			"both" => Enum935.const_3, 
			_ => Enum935.const_0, 
		};
	}

	public string imethod_1(object value)
	{
		return (Enum935)value switch
		{
			Enum935.const_1 => "left", 
			Enum935.const_2 => "right", 
			Enum935.const_3 => "both", 
			_ => "none", 
		};
	}
}
