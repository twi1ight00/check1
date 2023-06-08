using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6838 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		return value.ToLower(CultureInfo.InvariantCulture).Trim() switch
		{
			"pre-wrap" => Enum959.const_3, 
			"pre-line" => Enum959.const_2, 
			"pre" => Enum959.const_1, 
			"nowrap" => Enum959.const_4, 
			"normal" => Enum959.const_0, 
			_ => Enum959.const_0, 
		};
	}

	public string imethod_1(object value)
	{
		return (Enum959)value switch
		{
			Enum959.const_0 => "normal", 
			Enum959.const_1 => "pre", 
			Enum959.const_2 => "pre-line", 
			Enum959.const_3 => "pre-wrap", 
			Enum959.const_4 => "nowrap", 
			_ => "normal", 
		};
	}
}
