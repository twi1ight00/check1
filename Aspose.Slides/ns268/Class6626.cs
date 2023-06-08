using System;
using ns235;
using ns267;

namespace ns268;

internal class Class6626 : Class6625
{
	protected override Enum vmethod_0(string value)
	{
		return value.ToUpper() switch
		{
			"NOJUMP" => Enum803.const_0, 
			"NEXTPAGE" => Enum803.const_1, 
			"PREVIOUSPAGE" => Enum803.const_2, 
			"FIRSTPAGE" => Enum803.const_3, 
			"LASTPAGE" => Enum803.const_4, 
			"LASTSLIDEVIEWED" => Enum803.const_5, 
			"ENDSHOW" => Enum803.const_6, 
			"PAGENUM" => Enum803.const_7, 
			_ => throw new ArgumentException(), 
		};
	}

	protected override string vmethod_1(Enum value)
	{
		return (Enum803)(object)value switch
		{
			Enum803.const_0 => "NoJump", 
			Enum803.const_1 => "NextPage", 
			Enum803.const_2 => "PreviousPage", 
			Enum803.const_3 => "FirstPage", 
			Enum803.const_4 => "LastPage", 
			Enum803.const_5 => "LastSlideViewed", 
			Enum803.const_6 => "EndShow", 
			Enum803.const_7 => "PageNum", 
			_ => throw new ArgumentException(), 
		};
	}
}
