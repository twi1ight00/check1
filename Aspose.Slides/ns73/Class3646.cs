using System;
using ns84;

namespace ns73;

internal class Class3646 : Class3549<Enum621>
{
	public override string imethod_2(Enum621 value)
	{
		return value switch
		{
			Enum621.const_0 => "outside", 
			Enum621.const_1 => "inside", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum621 value)
	{
		switch (token.ToLower())
		{
		case "outside":
			value = Enum621.const_0;
			return true;
		default:
			throw new ArgumentException("value");
		case "inside":
			value = Enum621.const_1;
			return true;
		}
	}
}
