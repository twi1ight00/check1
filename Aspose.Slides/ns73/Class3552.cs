using System;
using ns84;

namespace ns73;

internal class Class3552 : Class3549<Enum522>
{
	public override string imethod_2(Enum522 value)
	{
		return value switch
		{
			Enum522.const_0 => "top", 
			Enum522.const_1 => "center", 
			Enum522.const_2 => "bottom", 
			Enum522.const_3 => "left", 
			Enum522.const_4 => "right", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum522 value)
	{
		switch (token.ToLower())
		{
		case "right":
			value = Enum522.const_4;
			return true;
		case "left":
			value = Enum522.const_3;
			return true;
		case "bottom":
			value = Enum522.const_2;
			return true;
		case "center":
			value = Enum522.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "top":
			value = Enum522.const_0;
			return true;
		}
	}
}
