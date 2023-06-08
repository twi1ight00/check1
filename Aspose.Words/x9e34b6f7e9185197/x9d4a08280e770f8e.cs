using System;

namespace x9e34b6f7e9185197;

internal class x9d4a08280e770f8e
{
	public static x19119439284aead2 xb0c325557cbfd6d3(string x6c50a99faab7d741)
	{
		return x6c50a99faab7d741 switch
		{
			"accent1" => x19119439284aead2.x7e35b9f3a95994e6, 
			"accent2" => x19119439284aead2.xa00e6a1b059e8528, 
			"accent3" => x19119439284aead2.x05f2f8a88d550fdf, 
			"accent4" => x19119439284aead2.xb8500fb2f6ef9b56, 
			"accent5" => x19119439284aead2.x1df53383f0784cbf, 
			"accent6" => x19119439284aead2.x5a18ff363fcd7795, 
			"dk1" => x19119439284aead2.x34614caf8d0b54eb, 
			"dk2" => x19119439284aead2.x457bb4d1a786686c, 
			"folHlink" => x19119439284aead2.x897709e2106a7fd6, 
			"hlink" => x19119439284aead2.xc9bcfb2d9630b0c7, 
			"lt1" => x19119439284aead2.xbc991998f16b5de4, 
			"lt2" => x19119439284aead2.x24036af9e33bd304, 
			"tx1" => x19119439284aead2.x8746bc414a8b9cc0, 
			"tx2" => x19119439284aead2.x64b7a46621ad97d7, 
			"bg1" => x19119439284aead2.xdf3651e9ee6f58b9, 
			"bg2" => x19119439284aead2.xe779b81e8f63bfd5, 
			_ => x19119439284aead2.x34614caf8d0b54eb, 
		};
	}

	public static string ToString(x19119439284aead2 color)
	{
		return color switch
		{
			x19119439284aead2.x7e35b9f3a95994e6 => "accent1", 
			x19119439284aead2.xa00e6a1b059e8528 => "accent2", 
			x19119439284aead2.x05f2f8a88d550fdf => "accent3", 
			x19119439284aead2.xb8500fb2f6ef9b56 => "accent4", 
			x19119439284aead2.x1df53383f0784cbf => "accent5", 
			x19119439284aead2.x5a18ff363fcd7795 => "accent6", 
			x19119439284aead2.x34614caf8d0b54eb => "dk1", 
			x19119439284aead2.x457bb4d1a786686c => "dk2", 
			x19119439284aead2.x897709e2106a7fd6 => "folHlink", 
			x19119439284aead2.xc9bcfb2d9630b0c7 => "hlink", 
			x19119439284aead2.xbc991998f16b5de4 => "lt1", 
			x19119439284aead2.x24036af9e33bd304 => "lt2", 
			x19119439284aead2.x8746bc414a8b9cc0 => "tx1", 
			x19119439284aead2.x64b7a46621ad97d7 => "tx2", 
			x19119439284aead2.xdf3651e9ee6f58b9 => "bg1", 
			x19119439284aead2.xe779b81e8f63bfd5 => "bg2", 
			_ => throw new ArgumentOutOfRangeException("color"), 
		};
	}
}
