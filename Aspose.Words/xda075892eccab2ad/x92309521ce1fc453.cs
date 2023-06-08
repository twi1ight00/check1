using Aspose.Words;
using Aspose.Words.Drawing;
using x28925c9b27b37a46;

namespace xda075892eccab2ad;

internal class x92309521ce1fc453
{
	private x92309521ce1fc453()
	{
	}

	internal static x8fdc64e3f5579ea8 xf248423f5577449f(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"top" => x8fdc64e3f5579ea8.xe360b1885d8d4a41, 
			"center" => x8fdc64e3f5579ea8.x58d2ccae3c5cfd08, 
			"baseline" => x8fdc64e3f5579ea8.x139412b8dea2f02b, 
			"bottom" => x8fdc64e3f5579ea8.x9bcb07e204e30218, 
			"auto" => x8fdc64e3f5579ea8.x2bca50d746ec73b2, 
			_ => x8fdc64e3f5579ea8.x2bca50d746ec73b2, 
		};
	}

	internal static string xc173fe801c66caab(x8fdc64e3f5579ea8 xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			x8fdc64e3f5579ea8.xe360b1885d8d4a41 => "top", 
			x8fdc64e3f5579ea8.x58d2ccae3c5cfd08 => "center", 
			x8fdc64e3f5579ea8.x139412b8dea2f02b => "baseline", 
			x8fdc64e3f5579ea8.x9bcb07e204e30218 => "bottom", 
			x8fdc64e3f5579ea8.x2bca50d746ec73b2 => "auto", 
			_ => "", 
		};
	}

	internal static DropCapPosition x26dc9f8eb858bc15(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"none" => DropCapPosition.None, 
			"drop" => DropCapPosition.Normal, 
			"margin" => DropCapPosition.Margin, 
			_ => DropCapPosition.None, 
		};
	}

	internal static string xd937af05f4d45eb5(DropCapPosition xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			DropCapPosition.None => "none", 
			DropCapPosition.Normal => "drop", 
			DropCapPosition.Margin => "margin", 
			_ => "", 
		};
	}

	internal static VerticalAlignment x130a3ebac2306cbd(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"inline" => VerticalAlignment.Inline, 
			"top" => VerticalAlignment.Top, 
			"center" => VerticalAlignment.Center, 
			"bottom" => VerticalAlignment.Bottom, 
			"inside" => VerticalAlignment.Inside, 
			"outside" => VerticalAlignment.Outside, 
			_ => VerticalAlignment.None, 
		};
	}

	internal static string xf7b3d51063ad99cc(VerticalAlignment xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			VerticalAlignment.Inline => "inline", 
			VerticalAlignment.Top => "top", 
			VerticalAlignment.Center => "center", 
			VerticalAlignment.Bottom => "bottom", 
			VerticalAlignment.Inside => "inside", 
			VerticalAlignment.Outside => "outside", 
			_ => "", 
		};
	}

	internal static HorizontalAlignment x15b3d0aaa5b4546f(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"left" => HorizontalAlignment.Left, 
			"center" => HorizontalAlignment.Center, 
			"right" => HorizontalAlignment.Right, 
			"inside" => HorizontalAlignment.Inside, 
			"outside" => HorizontalAlignment.Outside, 
			_ => HorizontalAlignment.None, 
		};
	}

	internal static string x9617344359c63dd2(HorizontalAlignment xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			HorizontalAlignment.Left => "left", 
			HorizontalAlignment.Center => "center", 
			HorizontalAlignment.Right => "right", 
			HorizontalAlignment.Inside => "inside", 
			HorizontalAlignment.Outside => "outside", 
			_ => "", 
		};
	}

	internal static RelativeHorizontalPosition xcf7be470fced425c(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"text" => RelativeHorizontalPosition.Column, 
			"margin" => RelativeHorizontalPosition.Margin, 
			"page" => RelativeHorizontalPosition.Page, 
			_ => RelativeHorizontalPosition.Column, 
		};
	}

	internal static string x14e082375ba0c07c(RelativeHorizontalPosition xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			RelativeHorizontalPosition.Column => "text", 
			RelativeHorizontalPosition.Margin => "margin", 
			RelativeHorizontalPosition.Page => "page", 
			_ => "", 
		};
	}

	internal static RelativeVerticalPosition xb26f8f5e78b630a9(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"text" => RelativeVerticalPosition.Paragraph, 
			"margin" => RelativeVerticalPosition.Margin, 
			"page" => RelativeVerticalPosition.Page, 
			_ => RelativeVerticalPosition.Paragraph, 
		};
	}

	internal static string xd28acd82ad3fd5e3(RelativeVerticalPosition xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			RelativeVerticalPosition.Paragraph => "text", 
			RelativeVerticalPosition.Margin => "margin", 
			RelativeVerticalPosition.Page => "page", 
			_ => "", 
		};
	}

	internal static WrapType xa76a170faf04ac8c(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"auto" => WrapType.Inline, 
			"notBeside" => WrapType.TopBottom, 
			"not-beside" => WrapType.TopBottom, 
			"around" => WrapType.Square, 
			"tight" => WrapType.Tight, 
			"through" => WrapType.Through, 
			"none" => WrapType.None, 
			_ => WrapType.None, 
		};
	}

	internal static string x6c8d42123b0d0381(WrapType xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case WrapType.Inline:
			return "auto";
		case WrapType.TopBottom:
			if (!x5fbb1a9c98604ef5)
			{
				return "not-beside";
			}
			return "notBeside";
		case WrapType.Square:
			return "around";
		case WrapType.Tight:
			return "tight";
		case WrapType.Through:
			return "through";
		case WrapType.None:
			return "none";
		default:
			return "";
		}
	}

	internal static HeightRule xe39d51b7fd3464b5(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"auto" => HeightRule.Auto, 
			"exact" => HeightRule.Exactly, 
			"atLeast" => HeightRule.AtLeast, 
			"at-least" => HeightRule.AtLeast, 
			_ => HeightRule.Auto, 
		};
	}

	internal static string xe450fbc63c45b368(HeightRule xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case HeightRule.Auto:
			return "auto";
		case HeightRule.Exactly:
			return "exact";
		case HeightRule.AtLeast:
			if (!x5fbb1a9c98604ef5)
			{
				return "at-least";
			}
			return "atLeast";
		default:
			return "";
		}
	}

	internal static LineSpacingRule x3fd0472225201508(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"auto" => LineSpacingRule.Multiple, 
			"exact" => LineSpacingRule.Exactly, 
			"atLeast" => LineSpacingRule.AtLeast, 
			"at-least" => LineSpacingRule.AtLeast, 
			_ => LineSpacingRule.AtLeast, 
		};
	}

	internal static string x41319507d42a4e5c(LineSpacingRule xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case LineSpacingRule.Multiple:
			return "auto";
		case LineSpacingRule.Exactly:
			return "exact";
		case LineSpacingRule.AtLeast:
			if (!x5fbb1a9c98604ef5)
			{
				return "at-least";
			}
			return "atLeast";
		default:
			return "";
		}
	}

	internal static ParagraphAlignment x394c54208191de14(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"start" => ParagraphAlignment.Left, 
			"left" => ParagraphAlignment.Left, 
			"center" => ParagraphAlignment.Center, 
			"right" => ParagraphAlignment.Right, 
			"end" => ParagraphAlignment.Right, 
			"both" => ParagraphAlignment.Justify, 
			"distribute" => ParagraphAlignment.Distributed, 
			_ => ParagraphAlignment.Left, 
		};
	}

	internal static string x443159ac7b83b091(ParagraphAlignment xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			ParagraphAlignment.Left => "left", 
			ParagraphAlignment.Center => "center", 
			ParagraphAlignment.Right => "right", 
			ParagraphAlignment.Justify => "both", 
			ParagraphAlignment.Distributed => "distribute", 
			_ => "", 
		};
	}

	internal static TabLeader xa1511adbdafd3114(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"none" => TabLeader.None, 
			"dot" => TabLeader.Dots, 
			"hyphen" => TabLeader.Dashes, 
			"underscore" => TabLeader.Line, 
			"heavy" => TabLeader.Heavy, 
			"middleDot" => TabLeader.MiddleDot, 
			"middle-dot" => TabLeader.MiddleDot, 
			_ => TabLeader.None, 
		};
	}

	internal static string x6effb923e5aae32a(TabLeader xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case TabLeader.None:
			return "none";
		case TabLeader.Dots:
			return "dot";
		case TabLeader.Dashes:
			return "hyphen";
		case TabLeader.Line:
			return "underscore";
		case TabLeader.Heavy:
			return "heavy";
		case TabLeader.MiddleDot:
			if (!x5fbb1a9c98604ef5)
			{
				return "middle-dot";
			}
			return "middleDot";
		default:
			return "";
		}
	}

	internal static TabAlignment x34ab042462331e81(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"clear" => TabAlignment.Clear, 
			"left" => TabAlignment.Left, 
			"start" => TabAlignment.Left, 
			"center" => TabAlignment.Center, 
			"right" => TabAlignment.Right, 
			"end" => TabAlignment.Right, 
			"decimal" => TabAlignment.Decimal, 
			"bar" => TabAlignment.Bar, 
			"num" => TabAlignment.List, 
			"list" => TabAlignment.List, 
			_ => TabAlignment.Clear, 
		};
	}

	internal static string xe929b13e37410177(TabAlignment xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case TabAlignment.Clear:
			return "clear";
		case TabAlignment.Left:
			return "left";
		case TabAlignment.Center:
			return "center";
		case TabAlignment.Right:
			return "right";
		case TabAlignment.Decimal:
			return "decimal";
		case TabAlignment.Bar:
			return "bar";
		case TabAlignment.List:
			if (!x5fbb1a9c98604ef5)
			{
				return "list";
			}
			return "num";
		default:
			return "";
		}
	}
}
