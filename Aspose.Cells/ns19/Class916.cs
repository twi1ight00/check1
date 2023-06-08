using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns19;

internal class Class916
{
	public static bool smethod_0(Interface42 interface42_0, GraphicsPath graphicsPath_0, ref float float_0, ref float float_1)
	{
		if (graphicsPath_0.PathData.Points.Length <= 0)
		{
			return false;
		}
		float x = graphicsPath_0.PathData.Points[0].X;
		float y = graphicsPath_0.PathData.Points[0].Y;
		float x2 = graphicsPath_0.PathData.Points[0].X;
		float y2 = graphicsPath_0.PathData.Points[0].Y;
		int num = graphicsPath_0.PathData.Points.Length;
		PointF[] points = graphicsPath_0.PathData.Points;
		for (int i = 1; i < num; i++)
		{
			if (points[i].X < x2)
			{
				x2 = points[i].X;
			}
			if (points[i].Y < y2)
			{
				y2 = points[i].Y;
			}
			if (points[i].X > x)
			{
				x = points[i].X;
			}
			if (points[i].Y > y)
			{
				y = points[i].Y;
			}
		}
		x2 = ((!(x2 < 0f)) ? 0f : (0f - x2));
		y2 = ((!(y2 < 0f)) ? 0f : (0f - y2));
		return smethod_1(interface42_0, x2 + x - float_0, y2 + y - float_1, ref float_0, ref float_1);
	}

	public static bool smethod_1(Interface42 interface42_0, float float_0, float float_1, ref float float_2, ref float float_3)
	{
		GraphicsUnit graphicsUnit = interface42_0.imethod_53();
		float num = interface42_0.imethod_51();
		float num2 = interface42_0.imethod_52();
		switch (graphicsUnit)
		{
		case GraphicsUnit.World:
			return false;
		case GraphicsUnit.Point:
			float_2 = 1f / 72f * num * float_0;
			float_3 = 1f / 72f * num2 * float_1;
			return true;
		case GraphicsUnit.Inch:
			float_2 = num * float_0;
			float_3 = num2 * float_1;
			return true;
		case GraphicsUnit.Document:
			float_2 = 0.0033333334f * num * float_0;
			float_3 = 0.0033333334f * num2 * float_1;
			return true;
		case GraphicsUnit.Millimeter:
			float_2 = 0.03937008f * num * float_0;
			float_3 = 0.03937008f * num2 * float_1;
			return true;
		default:
			return false;
		case GraphicsUnit.Display:
		case GraphicsUnit.Pixel:
			float_2 = float_0;
			float_3 = float_1;
			return true;
		}
	}
}
