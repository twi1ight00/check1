using System;
using ns84;

namespace ns73;

internal class Class3635 : Class3549<Enum606>
{
	public override string imethod_2(Enum606 value)
	{
		return value switch
		{
			Enum606.const_0 => "collapse", 
			Enum606.const_1 => "separate", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum606 value)
	{
		switch (token.ToLower())
		{
		case "separate":
			value = Enum606.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "collapse":
			value = Enum606.const_0;
			return true;
		}
	}
}
