using System;
using ns84;

namespace ns73;

internal class Class3585 : Class3549<Enum545>
{
	public override string imethod_2(Enum545 value)
	{
		return value switch
		{
			Enum545.const_0 => "consider-shifts", 
			Enum545.const_1 => "disregard-shifts", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum545 value)
	{
		switch (token.ToLower())
		{
		case "disregard-shifts":
			value = Enum545.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "consider-shifts":
			value = Enum545.const_0;
			return true;
		}
	}
}
