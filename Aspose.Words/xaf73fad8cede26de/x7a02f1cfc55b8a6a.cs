using System.Drawing.Drawing2D;
using x6c95d9cf46ff5f25;

namespace xaf73fad8cede26de;

internal class x7a02f1cfc55b8a6a
{
	private x7a02f1cfc55b8a6a()
	{
	}

	internal static double xef598e966b5dee6f(double x37cf7043760b312e)
	{
		return x4574ea26106f0edb.xc4ed0440a9ee9c3e(x37cf7043760b312e * 96.0);
	}

	internal static string xc0a593247dbbc377(LineJoin x116dc3c08b623a0b)
	{
		switch (x116dc3c08b623a0b)
		{
		case LineJoin.Bevel:
			return "Bevel";
		case LineJoin.Miter:
		case LineJoin.MiterClipped:
			return "Miter";
		case LineJoin.Round:
			return "Round";
		default:
			return "Bevel";
		}
	}

	internal static string xc54c279f16da6376(LineCap x924d47924ddd687d)
	{
		switch (x924d47924ddd687d)
		{
		case LineCap.Flat:
		case LineCap.NoAnchor:
		case LineCap.DiamondAnchor:
		case LineCap.ArrowAnchor:
		case LineCap.AnchorMask:
		case LineCap.Custom:
			return "Flat";
		case LineCap.Round:
		case LineCap.RoundAnchor:
			return "Round";
		case LineCap.Square:
		case LineCap.SquareAnchor:
			return "Square";
		case LineCap.Triangle:
			return "Triangle";
		default:
			return "Square";
		}
	}

	internal static string xffa6b5e790e9ca3d(DashCap x88200c6807d3c74b)
	{
		return x88200c6807d3c74b switch
		{
			DashCap.Flat => "Flat", 
			DashCap.Round => "Round", 
			DashCap.Triangle => "Triangle", 
			_ => "Square", 
		};
	}

	internal static string x7fafd389d77711f2(WrapMode xa4aa8b4150b11435)
	{
		return xa4aa8b4150b11435 switch
		{
			WrapMode.Clamp => "None", 
			WrapMode.Tile => "Tile", 
			WrapMode.TileFlipX => "FlipX", 
			WrapMode.TileFlipY => "FlipY", 
			WrapMode.TileFlipXY => "FlipXY", 
			_ => "None", 
		};
	}
}
