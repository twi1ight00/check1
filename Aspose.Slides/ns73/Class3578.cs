using System;
using ns84;

namespace ns73;

internal class Class3578 : Class3549<Enum538>
{
	public override string imethod_2(Enum538 value)
	{
		return value switch
		{
			Enum538.const_0 => "@top-left-corner", 
			Enum538.const_1 => "@top-left", 
			Enum538.const_2 => "@top-center", 
			Enum538.const_3 => "@top-right", 
			Enum538.const_4 => "@top-right-corner", 
			Enum538.const_5 => "@bottom-left-corner", 
			Enum538.const_6 => "@bottom-left", 
			Enum538.const_7 => "@bottom-center", 
			Enum538.const_8 => "@bottom-right", 
			Enum538.const_9 => "@bottom-right-corner", 
			Enum538.const_10 => "@left-top", 
			Enum538.const_11 => "@left-middle", 
			Enum538.const_12 => "@left-bottom", 
			Enum538.const_13 => "@right-top", 
			Enum538.const_14 => "@right-middle", 
			Enum538.const_15 => "@right-bottom", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum538 value)
	{
		switch (token.ToLower())
		{
		case "@top-left-corner":
			value = Enum538.const_0;
			return true;
		case "@top-left":
			value = Enum538.const_1;
			return true;
		case "@top-center":
			value = Enum538.const_2;
			return true;
		case "@top-right":
			value = Enum538.const_3;
			return true;
		case "@top-right-corner":
			value = Enum538.const_4;
			return true;
		case "@bottom-left-corner":
			value = Enum538.const_5;
			return true;
		case "@bottom-left":
			value = Enum538.const_6;
			return true;
		case "@bottom-center":
			value = Enum538.const_7;
			return true;
		case "@bottom-right":
			value = Enum538.const_8;
			return true;
		case "@bottom-right-corner":
			value = Enum538.const_9;
			return true;
		case "@left-top":
			value = Enum538.const_10;
			return true;
		case "@left-middle":
			value = Enum538.const_11;
			return true;
		case "@left-bottom":
			value = Enum538.const_12;
			return true;
		case "@right-top":
			value = Enum538.const_13;
			return true;
		case "@right-middle":
			value = Enum538.const_14;
			return true;
		default:
			throw new ArgumentException("value");
		case "@right-bottom":
			value = Enum538.const_15;
			return true;
		}
	}
}
