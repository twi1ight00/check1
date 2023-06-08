using System;
using ns84;

namespace ns73;

internal class Class3672 : Class3549<Enum626>
{
	public override string imethod_2(Enum626 value)
	{
		return value switch
		{
			Enum626.const_0 => "larger", 
			Enum626.const_1 => "smaller", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum626 value)
	{
		switch (token.ToLower())
		{
		case "larger":
			value = Enum626.const_0;
			return true;
		default:
			throw new ArgumentException("token");
		case "smaller":
			value = Enum626.const_1;
			return true;
		}
	}
}
