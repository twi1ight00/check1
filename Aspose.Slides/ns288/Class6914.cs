using System.Globalization;
using ns284;
using ns301;

namespace ns288;

internal class Class6914 : Interface331
{
	public object imethod_0(string value)
	{
		Class6892.smethod_1(value, "value");
		return value.ToLower(CultureInfo.InvariantCulture).Trim() switch
		{
			"block" => Enum952.const_1, 
			"inline" => Enum952.const_0, 
			"list-item" => Enum952.const_2, 
			"run-in" => Enum952.const_3, 
			"inline-block" => Enum952.const_4, 
			"table" => Enum952.const_5, 
			"inline-table" => Enum952.const_6, 
			"table-row-group" => Enum952.const_7, 
			"table-header-group" => Enum952.const_8, 
			"table-footer-group" => Enum952.const_9, 
			"table-row" => Enum952.const_10, 
			"table-column-group" => Enum952.const_11, 
			"table-column" => Enum952.const_12, 
			"table-cell" => Enum952.const_13, 
			"table-caption" => Enum952.const_14, 
			"none" => Enum952.const_15, 
			"inherit" => Enum952.const_16, 
			_ => Enum952.const_0, 
		};
	}

	public string imethod_1(object value)
	{
		return (Enum952)value switch
		{
			Enum952.const_0 => "inline", 
			Enum952.const_1 => "block", 
			Enum952.const_2 => "list-item", 
			Enum952.const_3 => "run-in", 
			Enum952.const_4 => "inline-block", 
			Enum952.const_5 => "table", 
			Enum952.const_6 => "inline-table", 
			Enum952.const_7 => "table-row-group", 
			Enum952.const_8 => "table-header-group", 
			Enum952.const_9 => "table-footer-group", 
			Enum952.const_10 => "table-row", 
			Enum952.const_11 => "table-column-group", 
			Enum952.const_12 => "table-column", 
			Enum952.const_13 => "table-cell", 
			Enum952.const_14 => "table-caption", 
			Enum952.const_15 => "none", 
			Enum952.const_16 => "inherit", 
			_ => "inline", 
		};
	}
}
