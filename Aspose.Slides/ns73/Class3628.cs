using System;
using ns84;

namespace ns73;

internal class Class3628 : Class3549<Enum583>
{
	public override string imethod_2(Enum583 value)
	{
		return value switch
		{
			Enum583.const_0 => "over", 
			Enum583.const_1 => "under", 
			Enum583.const_2 => "right", 
			Enum583.const_3 => "left", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum583 value)
	{
		switch (token.ToLower())
		{
		case "right":
			value = Enum583.const_2;
			return true;
		case "left":
			value = Enum583.const_3;
			return true;
		case "under":
			value = Enum583.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "over":
			value = Enum583.const_0;
			return true;
		}
	}
}
