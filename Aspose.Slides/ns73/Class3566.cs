using System;
using ns84;

namespace ns73;

internal class Class3566 : Class3549<Enum506>
{
	public override string imethod_2(Enum506 value)
	{
		return value switch
		{
			Enum506.const_0 => "above", 
			Enum506.const_1 => "behind", 
			Enum506.const_2 => "front", 
			Enum506.const_3 => "back", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum506 value)
	{
		switch (token.ToLower())
		{
		case "back":
			value = Enum506.const_3;
			return true;
		case "front":
			value = Enum506.const_2;
			return true;
		case "behind":
			value = Enum506.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "above":
			value = Enum506.const_0;
			return true;
		}
	}
}
