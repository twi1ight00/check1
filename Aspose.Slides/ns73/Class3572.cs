using System;
using ns84;

namespace ns73;

internal class Class3572 : Class3549<Enum532>
{
	public override string imethod_2(Enum532 value)
	{
		return value switch
		{
			Enum532.const_0 => "A5", 
			Enum532.const_1 => "A4", 
			Enum532.const_2 => "A3", 
			Enum532.const_3 => "B5", 
			Enum532.const_4 => "B4", 
			Enum532.const_5 => "letter", 
			Enum532.const_6 => "legal", 
			Enum532.const_7 => "ledger", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum532 value)
	{
		switch (token.ToLower())
		{
		case "a5":
			value = Enum532.const_0;
			return true;
		case "a4":
			value = Enum532.const_1;
			return true;
		case "a3":
			value = Enum532.const_2;
			return true;
		case "b5":
			value = Enum532.const_3;
			return true;
		case "b4":
			value = Enum532.const_4;
			return true;
		case "letter":
			value = Enum532.const_5;
			return true;
		case "legal":
			value = Enum532.const_6;
			return true;
		default:
			throw new ArgumentException("value");
		case "ledger":
			value = Enum532.const_7;
			return true;
		}
	}
}
