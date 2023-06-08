using System;
using ns84;

namespace ns73;

internal class Class3581 : Class3549<Enum541>
{
	public override string imethod_2(Enum541 value)
	{
		return value switch
		{
			Enum541.const_0 => "before-edge", 
			Enum541.const_1 => "text-before-edge", 
			Enum541.const_2 => "central", 
			Enum541.const_3 => "middle", 
			Enum541.const_4 => "hanging", 
			Enum541.const_5 => "mathematical", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum541 value)
	{
		switch (token.ToLower())
		{
		case "before-edge":
			value = Enum541.const_0;
			return true;
		case "text-before-edge":
			value = Enum541.const_1;
			return true;
		case "central":
			value = Enum541.const_2;
			return true;
		case "middle":
			value = Enum541.const_3;
			return true;
		case "hanging":
			value = Enum541.const_4;
			return true;
		default:
			throw new ArgumentException("value");
		case "mathematical":
			value = Enum541.const_5;
			return true;
		}
	}
}
