using System;

namespace ns261;

internal class Class6421
{
	public static Enum818 smethod_0(string color)
	{
		return color switch
		{
			"accent1" => Enum818.const_4, 
			"accent2" => Enum818.const_5, 
			"accent3" => Enum818.const_6, 
			"accent4" => Enum818.const_7, 
			"accent5" => Enum818.const_8, 
			"accent6" => Enum818.const_9, 
			"dk1" => Enum818.const_0, 
			"dk2" => Enum818.const_2, 
			"folHlink" => Enum818.const_11, 
			"hlink" => Enum818.const_10, 
			"lt1" => Enum818.const_1, 
			"lt2" => Enum818.const_3, 
			"tx1" => Enum818.const_12, 
			"tx2" => Enum818.const_13, 
			"bg1" => Enum818.const_14, 
			"bg2" => Enum818.const_15, 
			_ => Enum818.const_0, 
		};
	}

	public static string ToString(Enum818 color)
	{
		return color switch
		{
			Enum818.const_0 => "dk1", 
			Enum818.const_1 => "lt1", 
			Enum818.const_2 => "dk2", 
			Enum818.const_3 => "lt2", 
			Enum818.const_4 => "accent1", 
			Enum818.const_5 => "accent2", 
			Enum818.const_6 => "accent3", 
			Enum818.const_7 => "accent4", 
			Enum818.const_8 => "accent5", 
			Enum818.const_9 => "accent6", 
			Enum818.const_10 => "hlink", 
			Enum818.const_11 => "folHlink", 
			Enum818.const_12 => "tx1", 
			Enum818.const_13 => "tx2", 
			Enum818.const_14 => "bg1", 
			Enum818.const_15 => "bg2", 
			_ => throw new ArgumentOutOfRangeException("color"), 
		};
	}
}
