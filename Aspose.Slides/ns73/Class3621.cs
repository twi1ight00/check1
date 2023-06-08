using System;
using ns84;

namespace ns73;

internal class Class3621 : Class3549<Enum576>
{
	public override string imethod_2(Enum576 value)
	{
		return value switch
		{
			Enum576.const_0 => "auto", 
			Enum576.const_1 => "none", 
			Enum576.const_2 => "inter-word", 
			Enum576.const_3 => "inter-ideograph", 
			Enum576.const_4 => "inter-cluster", 
			Enum576.const_5 => "distribute", 
			Enum576.const_6 => "kashida", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum576 value)
	{
		switch (token.ToLower())
		{
		case "auto":
			value = Enum576.const_0;
			return true;
		case "none":
			value = Enum576.const_1;
			return true;
		case "inter-word":
			value = Enum576.const_2;
			return true;
		case "inter-ideograph":
			value = Enum576.const_3;
			return true;
		case "inter-cluster":
			value = Enum576.const_4;
			return true;
		case "distribute":
			value = Enum576.const_5;
			return true;
		default:
			throw new ArgumentException("value");
		case "kashida":
			value = Enum576.const_6;
			return true;
		}
	}
}
