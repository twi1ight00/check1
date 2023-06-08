using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using ns22;

namespace ns18;

internal class Class1059
{
	private Class1059()
	{
	}

	internal static double smethod_0(double double_0)
	{
		return Class1395.smethod_4(double_0 * 96.0);
	}

	internal static string smethod_1(double double_0)
	{
		return Class1025.smethod_9(smethod_0(double_0));
	}

	internal static string smethod_2(Color color_0)
	{
		return "#" + Class1025.smethod_7(color_0.ToArgb());
	}

	internal static string smethod_3(Matrix matrix_0)
	{
		float[] elements = matrix_0.Elements;
		return $"{Class1025.smethod_11(elements[0])},{Class1025.smethod_11(elements[1])},{Class1025.smethod_11(elements[2])},{Class1025.smethod_11(elements[3])},{Class1025.smethod_11(elements[4])},{Class1025.smethod_11(elements[5])}";
	}

	internal static string smethod_4(PointF pointF_0)
	{
		return $"{Class1025.smethod_11(pointF_0.X)},{Class1025.smethod_11(pointF_0.Y)}";
	}

	internal static string smethod_5(LineJoin lineJoin_0)
	{
		switch (lineJoin_0)
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

	internal static string smethod_6(LineCap lineCap_0)
	{
		switch (lineCap_0)
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

	internal static string smethod_7(DashCap dashCap_0)
	{
		return dashCap_0 switch
		{
			DashCap.Flat => "Flat", 
			DashCap.Round => "Round", 
			DashCap.Triangle => "Triangle", 
			_ => "Square", 
		};
	}

	internal static string smethod_8(float[] float_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < float_0.Length; i++)
		{
			stringBuilder.Append(Class1025.smethod_11(float_0[i]));
			if (i < float_0.Length - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_9(WrapMode wrapMode_0)
	{
		return wrapMode_0 switch
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
