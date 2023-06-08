using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class138 : Class18
{
	internal Class138(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	private GraphicsPath[] method_3(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		if (class898_0.method_4() == null)
		{
			return null;
		}
		Class887 @class = class898_0.method_4();
		int count = @class.method_0().Count;
		GraphicsPath[] array = new GraphicsPath[count];
		int num = 0;
		int num2 = 0;
		int x = 0;
		int y = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = (int)rectangleF_0.X;
		int num10 = (int)rectangleF_0.Y;
		int num11 = (int)rectangleF_0.Width;
		int num12 = (int)rectangleF_0.Height;
		for (int i = 0; i < count; i++)
		{
			num = (int)((Class886)@class.method_0()[i]).Width;
			num2 = (int)((Class886)@class.method_0()[i]).Height;
			foreach (Class890 path in ((Class886)@class.method_0()[i]).PathList)
			{
				Point[] array2 = new Point[4];
				_ = path.PointList.Count;
				if (path.PointList.Count == 1)
				{
					ref Point reference = ref array2[0];
					reference = (Point)path.PointList[0];
				}
				else if (path.PointList.Count == 2)
				{
					ref Point reference2 = ref array2[0];
					reference2 = (Point)path.PointList[0];
					ref Point reference3 = ref array2[1];
					reference3 = (Point)path.PointList[1];
				}
				else if (path.PointList.Count == 4)
				{
					ref Point reference4 = ref array2[0];
					reference4 = (Point)path.PointList[0];
					ref Point reference5 = ref array2[1];
					reference5 = (Point)path.PointList[1];
					ref Point reference6 = ref array2[2];
					reference6 = (Point)path.PointList[2];
					ref Point reference7 = ref array2[3];
					reference7 = (Point)path.PointList[3];
				}
				switch (path.Type)
				{
				case Enum100.const_0:
					num3 = array2[1].X * num11 / num + num9;
					num4 = array2[1].Y * num12 / num2 + num10;
					graphicsPath.AddLine(x, y, num3, num4);
					x = num3;
					y = num4;
					break;
				case Enum100.const_1:
					num3 = array2[1].X * num11 / num + num9;
					num4 = array2[1].Y * num12 / num2 + num10;
					num5 = array2[2].X * num11 / num + num9;
					num6 = array2[2].Y * num12 / num2 + num10;
					num7 = array2[3].X * num11 / num + num9;
					num8 = array2[3].Y * num12 / num2 + num10;
					graphicsPath.AddBezier(x, y, num3, num4, num5, num6, num7, num8);
					x = num7;
					y = num8;
					break;
				case Enum100.const_2:
					graphicsPath.StartFigure();
					x = array2[0].X * num11 / num + num9;
					y = array2[0].Y * num12 / num2 + num10;
					break;
				case Enum100.const_3:
					graphicsPath.CloseFigure();
					break;
				}
			}
			array[i] = graphicsPath;
		}
		return array;
	}

	internal override void vmethod_3()
	{
		float x = class898_0.method_7().X;
		float y = class898_0.method_7().Y;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		RectangleF rectangleF_ = new RectangleF(x, y, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		GraphicsPath[] array = method_3(rectangleF_);
		Brush brush = null;
		if (array == null)
		{
			return;
		}
		int num = array.Length;
		if (num == 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			if (!class898_0.Fill.method_0())
			{
				brush = Struct69.smethod_0(class898_0.Fill, array[i]);
				interface42_0.imethod_33(brush, array[i]);
			}
			if (!class898_0.Line.method_0())
			{
				interface42_0.imethod_18(pen_, array[i]);
			}
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
