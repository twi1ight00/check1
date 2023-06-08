using System;
using ns84;

namespace ns73;

internal class Class3551 : Class3549<Enum521>
{
	public override string imethod_2(Enum521 value)
	{
		return value switch
		{
			Enum521.const_0 => "visible", 
			Enum521.const_1 => "hidden", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum521 value)
	{
		switch (token.ToLower())
		{
		case "hidden":
			value = Enum521.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "visible":
			value = Enum521.const_0;
			return true;
		}
	}
}
