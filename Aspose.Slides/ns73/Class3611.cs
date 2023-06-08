using System;
using ns84;

namespace ns73;

internal class Class3611 : Class3549<Enum565>
{
	public override string imethod_2(Enum565 value)
	{
		return value switch
		{
			Enum565.const_0 => "none", 
			Enum565.const_1 => "rows", 
			Enum565.const_2 => "columns", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum565 value)
	{
		switch (token.ToLower())
		{
		case "columns":
			value = Enum565.const_2;
			return true;
		case "rows":
			value = Enum565.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "none":
			value = Enum565.const_0;
			return true;
		}
	}
}
