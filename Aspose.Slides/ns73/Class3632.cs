using System;
using ns84;

namespace ns73;

internal class Class3632 : Class3549<Enum607>
{
	public override string imethod_2(Enum607 value)
	{
		return value switch
		{
			Enum607.const_0 => "thin", 
			Enum607.const_1 => "medium", 
			Enum607.const_2 => "thick", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum607 value)
	{
		switch (token.ToLower())
		{
		case "thin":
			value = Enum607.const_0;
			return true;
		case "thick":
			value = Enum607.const_2;
			return true;
		default:
			throw new ArgumentException("value");
		case "medium":
			value = Enum607.const_1;
			return true;
		}
	}
}
