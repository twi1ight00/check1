using System.Drawing;
using System.Runtime.InteropServices;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct34
{
	public static void smethod_0(ref RectangleF rect, PointF pointToInclude)
	{
		smethod_1(ref rect, pointToInclude.X);
		smethod_2(ref rect, pointToInclude.Y);
	}

	public static void smethod_1(ref RectangleF rect, float xToInclude)
	{
		if (xToInclude < rect.X)
		{
			rect.Width = rect.Right - xToInclude;
			rect.X = xToInclude;
		}
		else if (xToInclude > rect.Right)
		{
			rect.Width = xToInclude - rect.X;
		}
	}

	public static void smethod_2(ref RectangleF rect, float yToInclude)
	{
		if (yToInclude < rect.Y)
		{
			rect.Height = rect.Bottom - yToInclude;
			rect.Y = yToInclude;
		}
		else if (yToInclude > rect.Bottom)
		{
			rect.Height = yToInclude - rect.Y;
		}
	}
}
