using System;
using ns84;

namespace ns73;

internal class Class3586 : Class3549<Enum546>
{
	public override string imethod_2(Enum546 value)
	{
		return value switch
		{
			Enum546.const_0 => "exclude-ruby", 
			Enum546.const_1 => "include-ruby", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum546 value)
	{
		switch (token.ToLower())
		{
		case "include-ruby":
			value = Enum546.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "exclude-ruby":
			value = Enum546.const_0;
			return true;
		}
	}
}
