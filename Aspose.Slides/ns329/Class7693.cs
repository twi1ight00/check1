using System;
using ns322;
using ns328;

namespace ns329;

internal class Class7693 : Class7691
{
	public override string vmethod_0(Enum @enum)
	{
		return (Enum985)(object)@enum switch
		{
			Enum985.const_0 => "Data", 
			Enum985.const_1 => "Get", 
			Enum985.const_2 => "Set", 
			_ => throw new ArgumentException(), 
		};
	}
}
