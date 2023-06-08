using System;
using ns84;

namespace ns73;

internal class Class3594 : Class3549<Enum554>
{
	public override string imethod_2(Enum554 value)
	{
		return value switch
		{
			Enum554.const_0 => "fill", 
			Enum554.const_1 => "hidden", 
			Enum554.const_2 => "meet", 
			Enum554.const_3 => "slice", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum554 value)
	{
		switch (token.ToLower())
		{
		case "slice":
			value = Enum554.const_3;
			return true;
		case "meet":
			value = Enum554.const_2;
			return true;
		case "hidden":
			value = Enum554.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "fill":
			value = Enum554.const_0;
			return true;
		}
	}
}
