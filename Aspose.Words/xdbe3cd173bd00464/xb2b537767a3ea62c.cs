using Aspose.Words;
using Aspose.Words.Tables;
using x5794c252ba25e723;
using xf9a9481c3f63a419;

namespace xdbe3cd173bd00464;

internal class xb2b537767a3ea62c
{
	private xb2b537767a3ea62c()
	{
	}

	internal static string xfafbf12cd38285b5(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		return $"#{x6c50a99faab7d741.xda71bf6f7c07c3bc:x2}{x6c50a99faab7d741.xc613adc4330033f3:x2}{x6c50a99faab7d741.x26463655896fd90a:x2}{x6c50a99faab7d741.x8e8f6cc6a0756b05:x2}";
	}

	internal static string x7f90501c33a75aa6(ParagraphAlignment x4ec4022180cbf8f4)
	{
		switch (x4ec4022180cbf8f4)
		{
		case ParagraphAlignment.Left:
			return "Left";
		case ParagraphAlignment.Right:
			return "Right";
		case ParagraphAlignment.Center:
			return "Center";
		case ParagraphAlignment.Justify:
		case ParagraphAlignment.Distributed:
			return "Justify";
		default:
			return "Left";
		}
	}

	internal static string xf8b46c270d89b1c8(TableAlignment x2064588236522105)
	{
		return x2064588236522105 switch
		{
			TableAlignment.Left => "Left", 
			TableAlignment.Right => "Right", 
			TableAlignment.Center => "Center", 
			_ => "Left", 
		};
	}

	internal static string x541e8c2724a511cc(double xbcea506a33cf9111, string x10154c16e21df88a)
	{
		return $"{xca004f56614e2431.xdbca7a004e2d3753((xbcea506a33cf9111 > 0.0) ? xbcea506a33cf9111 : 0.0)}{x10154c16e21df88a}";
	}

	internal static string x321f0124fc6d50ae(NumberStyle x3f5f7cef69e188c0)
	{
		switch (x3f5f7cef69e188c0)
		{
		case NumberStyle.Arabic:
		case NumberStyle.Arabic1:
		case NumberStyle.Arabic2:
			return "Decimal";
		case NumberStyle.None:
			return "None";
		case NumberStyle.Bullet:
			return "Disk";
		case NumberStyle.LowercaseRoman:
			return "LowerRoman";
		case NumberStyle.UppercaseRoman:
			return "UpperRoman";
		case NumberStyle.LowercaseLetter:
			return "LowerLatin";
		case NumberStyle.UppercaseLetter:
			return "UpperLatin";
		default:
			return "Decimal";
		}
	}
}
