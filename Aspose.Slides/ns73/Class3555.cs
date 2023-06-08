using System;
using ns84;

namespace ns73;

internal class Class3555 : Class3549<Enum525>
{
	public override string imethod_2(Enum525 value)
	{
		return value switch
		{
			Enum525.const_0 => "flex-start", 
			Enum525.const_1 => "flex-end", 
			Enum525.const_2 => "center", 
			Enum525.const_3 => "baseline", 
			Enum525.const_4 => "stretch", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum525 value)
	{
		switch (token.ToLower())
		{
		case "stretch":
			value = Enum525.const_4;
			return true;
		case "baseline":
			value = Enum525.const_3;
			return true;
		case "center":
			value = Enum525.const_2;
			return true;
		case "flex-end":
			value = Enum525.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "flex-start":
			value = Enum525.const_0;
			return true;
		}
	}
}
