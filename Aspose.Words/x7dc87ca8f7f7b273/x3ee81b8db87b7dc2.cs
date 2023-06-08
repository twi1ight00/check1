using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using x5794c252ba25e723;
using xf9a9481c3f63a419;

namespace x7dc87ca8f7f7b273;

internal class x3ee81b8db87b7dc2
{
	private x3ee81b8db87b7dc2()
	{
	}

	internal static string xfafbf12cd38285b5(x26d9ecb4bdf0456d xbcea506a33cf9111)
	{
		return $"#{xbcea506a33cf9111.xc613adc4330033f3:x2}{xbcea506a33cf9111.x26463655896fd90a:x2}{xbcea506a33cf9111.x8e8f6cc6a0756b05:x2}";
	}

	internal static string x8ba7763bb24dc716(x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		return $"matrix({xca004f56614e2431.x37804260a70f74eb(xa801ccff44b0c7eb.xb4f54e8f080ddae5)},{xca004f56614e2431.x37804260a70f74eb(xa801ccff44b0c7eb.xdde8182ef4f9942b)},{xca004f56614e2431.x37804260a70f74eb(xa801ccff44b0c7eb.xa71255917a9143ca)},{xca004f56614e2431.x37804260a70f74eb(xa801ccff44b0c7eb.xcd7062a84a8f3162)},{xca004f56614e2431.x37804260a70f74eb(xa801ccff44b0c7eb.x35fa2f38e277fdee)},{xca004f56614e2431.x37804260a70f74eb(xa801ccff44b0c7eb.x93f6f49bd53e2628)})";
	}

	internal static string x8f172b45504f0a43(float[] xa679552e30d81989, float xce90ee8e49859281)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < xa679552e30d81989.Length; i++)
		{
			stringBuilder.Append(xca004f56614e2431.x37804260a70f74eb(xa679552e30d81989[i] * xce90ee8e49859281));
			if (i < xa679552e30d81989.Length - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}

	internal static string x0f5673aedffb2dd7(LineCap x924d47924ddd687d)
	{
		switch (x924d47924ddd687d)
		{
		case LineCap.Flat:
		case LineCap.Triangle:
		case LineCap.NoAnchor:
		case LineCap.DiamondAnchor:
		case LineCap.ArrowAnchor:
		case LineCap.AnchorMask:
		case LineCap.Custom:
			return "butt";
		case LineCap.Round:
		case LineCap.RoundAnchor:
			return "round";
		case LineCap.Square:
		case LineCap.SquareAnchor:
			return "square";
		default:
			return "butt";
		}
	}

	internal static string x9e3d00bac32f57a2(LineJoin x116dc3c08b623a0b)
	{
		return x116dc3c08b623a0b switch
		{
			LineJoin.Bevel => "bevel", 
			LineJoin.Round => "round", 
			_ => "miter", 
		};
	}

	internal static string x917c5a6cdc05561e(FontStyle x768946a353232575)
	{
		if (!xa143daf3bef8b339(x768946a353232575))
		{
			return "normal";
		}
		return "bold";
	}

	internal static string x32b37ded42f44b0e(FontStyle x768946a353232575)
	{
		if (!xb65ca9637cc40782(x768946a353232575))
		{
			return "normal";
		}
		return "italic";
	}

	private static bool xa143daf3bef8b339(FontStyle x768946a353232575)
	{
		if (x768946a353232575 != FontStyle.Bold)
		{
			return x768946a353232575 == (FontStyle.Bold | FontStyle.Italic);
		}
		return true;
	}

	private static bool xb65ca9637cc40782(FontStyle x768946a353232575)
	{
		if (x768946a353232575 != FontStyle.Italic)
		{
			return x768946a353232575 == (FontStyle.Bold | FontStyle.Italic);
		}
		return true;
	}
}
