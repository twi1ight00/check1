using System;
using ns84;

namespace ns73;

internal class Class3673 : Class3549<Enum630>
{
	public override string imethod_2(Enum630 value)
	{
		return value switch
		{
			Enum630.const_0 => "inline", 
			Enum630.const_1 => "block", 
			Enum630.const_2 => "list-item", 
			Enum630.const_3 => "inline-block", 
			Enum630.const_4 => "run-in", 
			Enum630.const_5 => "compact", 
			Enum630.const_6 => "table", 
			Enum630.const_7 => "inline-table", 
			Enum630.const_8 => "table-row-group", 
			Enum630.const_9 => "table-header-group", 
			Enum630.const_10 => "table-footer-group", 
			Enum630.const_11 => "table-row", 
			Enum630.const_12 => "table-column-group", 
			Enum630.const_13 => "table-column", 
			Enum630.const_14 => "table-cell", 
			Enum630.const_15 => "table-caption", 
			Enum630.const_16 => "ruby", 
			Enum630.const_17 => "ruby-base", 
			Enum630.const_18 => "ruby-text", 
			Enum630.const_19 => "ruby-base-group", 
			Enum630.const_20 => "ruby-text-group", 
			Enum630.const_21 => "none", 
			Enum630.const_22 => "grid", 
			Enum630.const_23 => "inline-grid", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum630 value)
	{
		switch (token.ToLower())
		{
		case "inline":
			value = Enum630.const_0;
			return true;
		case "block":
			value = Enum630.const_1;
			return true;
		case "list-item":
			value = Enum630.const_2;
			return true;
		case "inline-block":
			value = Enum630.const_3;
			return true;
		case "run-in":
			value = Enum630.const_4;
			return true;
		case "compact":
			value = Enum630.const_5;
			return true;
		case "table":
			value = Enum630.const_6;
			return true;
		case "inline-table":
			value = Enum630.const_7;
			return true;
		case "table-row-group":
			value = Enum630.const_8;
			return true;
		case "table-header-group":
			value = Enum630.const_9;
			return true;
		case "table-footer-group":
			value = Enum630.const_10;
			return true;
		case "table-row":
			value = Enum630.const_11;
			return true;
		case "table-column-group":
			value = Enum630.const_12;
			return true;
		case "table-column":
			value = Enum630.const_13;
			return true;
		case "table-cell":
			value = Enum630.const_14;
			return true;
		case "table-caption":
			value = Enum630.const_15;
			return true;
		case "ruby":
			value = Enum630.const_16;
			return true;
		case "ruby-base":
			value = Enum630.const_17;
			return true;
		case "ruby-text":
			value = Enum630.const_18;
			return true;
		case "ruby-base-group":
			value = Enum630.const_19;
			return true;
		case "ruby-text-group":
			value = Enum630.const_20;
			return true;
		case "grid":
			value = Enum630.const_22;
			return true;
		case "inline-grid":
			value = Enum630.const_23;
			return true;
		default:
			throw new ArgumentException("token");
		case "none":
			value = Enum630.const_21;
			return true;
		}
	}
}
