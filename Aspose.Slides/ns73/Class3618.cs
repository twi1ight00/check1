using System;
using ns84;

namespace ns73;

internal class Class3618 : Class3549<Enum573>
{
	public override string imethod_2(Enum573 value)
	{
		return value switch
		{
			Enum573.const_0 => "normal", 
			Enum573.const_1 => "break-all", 
			Enum573.const_2 => "keep-all", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum573 value)
	{
		switch (token.ToLower())
		{
		case "keep-all":
			value = Enum573.const_2;
			return true;
		case "break-all":
			value = Enum573.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "normal":
			value = Enum573.const_0;
			return true;
		}
	}
}
