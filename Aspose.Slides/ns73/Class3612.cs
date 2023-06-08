using System;
using ns84;

namespace ns73;

internal class Class3612 : Class3549<Enum566>
{
	public override string imethod_2(Enum566 value)
	{
		return value switch
		{
			Enum566.const_0 => "start", 
			Enum566.const_1 => "end", 
			Enum566.const_2 => "center", 
			Enum566.const_3 => "stretch", 
			_ => throw new ArgumentException("value"), 
		};
	}

	public override bool TryGetValue(string token, out Enum566 value)
	{
		switch (token.ToLower())
		{
		case "stretch":
			value = Enum566.const_3;
			return true;
		case "center":
			value = Enum566.const_2;
			return true;
		case "end":
			value = Enum566.const_1;
			return true;
		default:
			throw new ArgumentException("token");
		case "start":
			value = Enum566.const_0;
			return true;
		}
	}
}
