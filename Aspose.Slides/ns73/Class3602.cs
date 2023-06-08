using System;
using ns84;

namespace ns73;

internal class Class3602 : Class3549<Enum517>
{
	public override string imethod_2(Enum517 value)
	{
		return value switch
		{
			Enum517.const_0 => "stretch", 
			Enum517.const_1 => "repeat", 
			Enum517.const_2 => "round", 
			Enum517.const_3 => "space", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum517 value)
	{
		switch (token.ToLower())
		{
		case "space":
			value = Enum517.const_3;
			return true;
		case "round":
			value = Enum517.const_2;
			return true;
		case "repeat":
			value = Enum517.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "stretch":
			value = Enum517.const_0;
			return true;
		}
	}
}
