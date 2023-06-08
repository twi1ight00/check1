using System;
using ns84;

namespace ns73;

internal class Class3564 : Class3549<Enum504>
{
	public override string imethod_2(Enum504 value)
	{
		return value switch
		{
			Enum504.const_0 => "current", 
			Enum504.const_1 => "root", 
			Enum504.const_2 => "parent", 
			Enum504.const_3 => "new", 
			Enum504.const_4 => "modal", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum504 value)
	{
		switch (token.ToLower())
		{
		case "modal":
			value = Enum504.const_4;
			return true;
		case "new":
			value = Enum504.const_3;
			return true;
		case "parent":
			value = Enum504.const_2;
			return true;
		case "root":
			value = Enum504.const_1;
			return true;
		default:
			throw new ArgumentException("value");
		case "current":
			value = Enum504.const_0;
			return true;
		}
	}
}
