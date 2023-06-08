using System.Drawing.Drawing2D;
using ns218;

namespace ns220;

internal static class Class6693
{
	internal static double smethod_0(double val)
	{
		return Class5955.smethod_14(val * 96.0);
	}

	internal static string smethod_1(LineJoin lineJoin)
	{
		switch (lineJoin)
		{
		default:
			return "Bevel";
		case LineJoin.Bevel:
			return "Bevel";
		case LineJoin.Round:
			return "Round";
		case LineJoin.Miter:
		case LineJoin.MiterClipped:
			return "Miter";
		}
	}

	internal static string smethod_2(LineCap lineCap)
	{
		switch (lineCap)
		{
		case LineCap.Square:
		case LineCap.SquareAnchor:
			return "Square";
		case LineCap.Round:
		case LineCap.RoundAnchor:
			return "Round";
		case LineCap.Triangle:
			return "Triangle";
		default:
			return "Square";
		case LineCap.Flat:
		case LineCap.NoAnchor:
		case LineCap.DiamondAnchor:
		case LineCap.ArrowAnchor:
		case LineCap.AnchorMask:
		case LineCap.Custom:
			return "Flat";
		}
	}

	internal static string smethod_3(DashCap dashCap)
	{
		return dashCap switch
		{
			DashCap.Flat => "Flat", 
			DashCap.Round => "Round", 
			DashCap.Triangle => "Triangle", 
			_ => "Square", 
		};
	}

	internal static string smethod_4(WrapMode mode)
	{
		return mode switch
		{
			WrapMode.Tile => "Tile", 
			WrapMode.TileFlipX => "FlipX", 
			WrapMode.TileFlipY => "FlipY", 
			WrapMode.TileFlipXY => "FlipXY", 
			WrapMode.Clamp => "None", 
			_ => "None", 
		};
	}
}
