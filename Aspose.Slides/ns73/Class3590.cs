using System;
using ns84;

namespace ns73;

internal class Class3590 : Class3549<Enum550>
{
	public override string imethod_2(Enum550 value)
	{
		return value switch
		{
			Enum550.const_0 => "before", 
			Enum550.const_1 => "after", 
			Enum550.const_2 => "inter-character", 
			Enum550.const_3 => "inline", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum550 value)
	{
		switch (token.ToLower())
		{
		case "inline":
			value = Enum550.const_3;
			return true;
		case "inter-character":
			value = Enum550.const_2;
			return true;
		case "after":
			value = Enum550.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "before":
			value = Enum550.const_0;
			return true;
		}
	}
}
