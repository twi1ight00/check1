using System;
using ns84;

namespace ns73;

internal class Class3637 : Class3549<Enum608>
{
	public override string imethod_2(Enum608 value)
	{
		return value switch
		{
			Enum608.const_0 => "top", 
			Enum608.const_1 => "bottom", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum608 value)
	{
		switch (token.ToLower())
		{
		case "top":
			value = Enum608.const_0;
			return true;
		default:
			throw new ArgumentException("value");
		case "bottom":
			value = Enum608.const_1;
			return true;
		}
	}
}
