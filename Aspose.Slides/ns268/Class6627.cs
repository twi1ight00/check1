using System;
using ns224;
using ns267;

namespace ns268;

internal class Class6627 : Class6625
{
	protected override Enum vmethod_0(string value)
	{
		return value.ToUpper() switch
		{
			"RIGHT" => Enum747.const_4, 
			"LEFT" => Enum747.const_3, 
			"OUTSET" => Enum747.const_2, 
			"INSET" => Enum747.const_1, 
			"CENTER" => Enum747.const_0, 
			_ => throw new ArgumentException(), 
		};
	}

	protected override string vmethod_1(Enum value)
	{
		return (Enum747)(object)value switch
		{
			Enum747.const_0 => "Center", 
			Enum747.const_1 => "Inset", 
			Enum747.const_2 => "Outset", 
			Enum747.const_3 => "Left", 
			Enum747.const_4 => "Right", 
			_ => throw new ArgumentException(), 
		};
	}
}
