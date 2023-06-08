using System;
using ns84;

namespace ns73;

internal class Class3605 : Class3549<Enum520>
{
	public override string imethod_2(Enum520 value)
	{
		return value switch
		{
			Enum520.const_0 => "running", 
			Enum520.const_1 => "paused", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum520 value)
	{
		switch (token.ToLower())
		{
		case "paused":
			value = Enum520.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "running":
			value = Enum520.const_0;
			return true;
		}
	}
}
