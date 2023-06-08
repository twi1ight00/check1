using System.Drawing;
using System.Runtime.InteropServices;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct56
{
	public static void smethod_0(ref RectangleF rectangleF_0, PointF pointF_0)
	{
		smethod_1(ref rectangleF_0, pointF_0.X);
		smethod_2(ref rectangleF_0, pointF_0.Y);
	}

	public static void smethod_1(ref RectangleF rectangleF_0, float float_0)
	{
		if (float_0 < rectangleF_0.X)
		{
			rectangleF_0.Width = rectangleF_0.Right - float_0;
			rectangleF_0.X = float_0;
		}
		else if (float_0 > rectangleF_0.Right)
		{
			rectangleF_0.Width = float_0 - rectangleF_0.X;
		}
	}

	public static void smethod_2(ref RectangleF rectangleF_0, float float_0)
	{
		if (float_0 < rectangleF_0.Y)
		{
			rectangleF_0.Height = rectangleF_0.Bottom - float_0;
			rectangleF_0.Y = float_0;
		}
		else if (float_0 > rectangleF_0.Bottom)
		{
			rectangleF_0.Height = float_0 - rectangleF_0.Y;
		}
	}
}
