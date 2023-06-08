using System.Globalization;
using ns301;

namespace ns288;

internal class Class6832 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		return value.ToLower(CultureInfo.InvariantCulture).Trim() switch
		{
			"armenian" => 10, 
			"circle" => 1, 
			"decimal" => 3, 
			"decimal-leading-zero" => 4, 
			"georgian" => 11, 
			"lower-alpha" => 12, 
			"lower-greek" => 7, 
			"lower-latin" => 8, 
			"lower-roman" => 5, 
			"none" => 14, 
			"square" => 2, 
			"upper-alpha" => 13, 
			"upper-latin" => 9, 
			"upper-roman" => 6, 
			_ => 0, 
		};
	}

	public string imethod_1(object value)
	{
		return (int)value switch
		{
			1 => "circle", 
			2 => "square", 
			3 => "decimal", 
			4 => "decimal-leading-zero", 
			5 => "lower-roman", 
			6 => "upper-roman", 
			7 => "lower-greek", 
			8 => "lower-latin", 
			9 => "upper-latin", 
			10 => "armenian", 
			11 => "georgian", 
			12 => "lower-alpha", 
			13 => "upper-alpha", 
			14 => "none", 
			_ => "disc", 
		};
	}
}
