using System;

namespace ns73;

internal class Class3606 : Class3549<Enum510>
{
	public override string imethod_2(Enum510 value)
	{
		return value switch
		{
			Enum510.const_0 => "portrait", 
			Enum510.const_1 => "landscape", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum510 value)
	{
		switch (token.ToLower())
		{
		case "landscape":
			value = Enum510.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "portrait":
			value = Enum510.const_0;
			return true;
		}
	}
}
