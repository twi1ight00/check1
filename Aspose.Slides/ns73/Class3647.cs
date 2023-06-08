using System;
using ns84;

namespace ns73;

internal class Class3647 : Class3549<Enum625>
{
	public override string imethod_2(Enum625 value)
	{
		return value switch
		{
			Enum625.const_0 => "normal", 
			Enum625.const_1 => "italic", 
			Enum625.const_2 => "oblique", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum625 value)
	{
		switch (token.ToLower())
		{
		case "oblique":
			value = Enum625.const_2;
			return true;
		case "normal":
			value = Enum625.const_0;
			return true;
		default:
			throw new ArgumentException("value");
		case "italic":
			value = Enum625.const_1;
			return true;
		}
	}
}
