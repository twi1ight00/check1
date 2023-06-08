using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class282 : Class160
{
	internal Class282(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	private GraphicsPath[] method_3(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		if (class913_0.method_3() == null)
		{
			return null;
		}
		Class903 @class = class913_0.method_3();
		int count = @class.method_0().Count;
		GraphicsPath[] array = new GraphicsPath[count];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		int num11 = (int)rectangleF_0.X;
		int num12 = (int)rectangleF_0.Y;
		int num13 = (int)rectangleF_0.Width;
		int num14 = (int)rectangleF_0.Height;
		for (int i = 0; i < count; i++)
		{
			num = (int)((Class902)@class.method_0()[i]).Width;
			num2 = (int)((Class902)@class.method_0()[i]).Height;
			if (num <= 0)
			{
				num++;
			}
			if (num2 <= 0)
			{
				num2++;
			}
			foreach (Class907 path in ((Class902)@class.method_0()[i]).PathList)
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
				else if (path.PointList.Count == 3)
				{
					ref Point reference4 = ref array2[0];
					reference4 = (Point)path.PointList[0];
					ref Point reference5 = ref array2[1];
					reference5 = (Point)path.PointList[1];
					ref Point reference6 = ref array2[2];
					reference6 = (Point)path.PointList[2];
				}
				else if (path.PointList.Count == 4)
				{
					ref Point reference7 = ref array2[0];
					reference7 = (Point)path.PointList[0];
					ref Point reference8 = ref array2[1];
					reference8 = (Point)path.PointList[1];
					ref Point reference9 = ref array2[2];
					reference9 = (Point)path.PointList[2];
					ref Point reference10 = ref array2[3];
					reference10 = (Point)path.PointList[3];
				}
				switch (path.Type)
				{
				case Enum119.const_0:
					num5 = array2[1].X * num13 / num + num11;
					num6 = array2[1].Y * num14 / num2 + num12;
					graphicsPath.AddLine(num3, num4, num5, num6);
					num3 = num5;
					num4 = num6;
					break;
				case Enum119.const_1:
					num5 = array2[1].X * num13 / num + num11;
					num6 = array2[1].Y * num14 / num2 + num12;
					num7 = array2[2].X * num13 / num + num11;
					num8 = array2[2].Y * num14 / num2 + num12;
					num9 = array2[3].X * num13 / num + num11;
					num10 = array2[3].Y * num14 / num2 + num12;
					graphicsPath.AddBezier(num3, num4, num5, num6, num7, num8, num9, num10);
					num3 = num9;
					num4 = num10;
					break;
				case Enum119.const_2:
					graphicsPath.StartFigure();
					num3 = array2[0].X * num13 / num + num11;
					num4 = array2[0].Y * num14 / num2 + num12;
					break;
				case Enum119.const_3:
					graphicsPath.CloseFigure();
					break;
				case Enum119.const_5:
					num3 = num11;
					num4 = num12;
					num5 = array2[1].X * num13 / num;
					num6 = array2[1].Y * num14 / num2;
					num7 = array2[2].X * num13 / num;
					num8 = array2[2].Y * num14 / num2;
					graphicsPath.AddArc(num3, num4, num5 * 2, num6 * 2, num7, num8);
					break;
				}
			}
			array[i] = graphicsPath;
		}
		return array;
	}

	internal override void vmethod_3()
	{
		float x = class913_0.method_8().X;
		float y = class913_0.method_8().Y;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rectangleF = new RectangleF(x, y, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangleF);
		Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		GraphicsPath[] array = method_3(rectangleF);
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
			if (!class913_0.Fill.method_0())
			{
				interface42_0.imethod_33(brush_, array[i]);
			}
			if (!class913_0.Line.method_0())
			{
				interface42_0.imethod_18(pen_, array[i]);
			}
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
