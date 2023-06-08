using System;
using ns84;

namespace ns73;

internal class Class3583 : Class3549<Enum543>
{
	public override string imethod_2(Enum543 value)
	{
		return value switch
		{
			Enum543.const_0 => "normal", 
			Enum543.const_1 => "spell-out", 
			Enum543.const_2 => "digits", 
			Enum543.const_3 => "literal-punctuation", 
			Enum543.const_4 => "no-punctuation", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum543 value)
	{
		switch (token.ToLower())
		{
		case "no-punctuation":
			value = Enum543.const_4;
			return true;
		case "literal-punctuation":
			value = Enum543.const_3;
			return true;
		case "digits":
			value = Enum543.const_2;
			return true;
		case "spell-out":
			value = Enum543.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "normal":
			value = Enum543.const_0;
			return true;
		}
	}
}
