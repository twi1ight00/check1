using System;

namespace ns73;

internal class Class3600 : Class3549<Enum497>
{
	public override string imethod_2(Enum497 value)
	{
		return value switch
		{
			Enum497.const_0 => "progressive", 
			Enum497.const_1 => "progressive", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum497 value)
	{
		switch (token.ToLower())
		{
		case "progressive":
			value = Enum497.const_0;
			return true;
		default:
			throw new ArgumentException("value");
		case "interlace":
			value = Enum497.const_1;
			return true;
		}
	}
}
