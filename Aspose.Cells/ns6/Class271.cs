using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class271 : Class160
{
	internal Class271(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		RectangleF rectangleF = new RectangleF(float_0, float_1, class913_0.Width, class913_0.Height);
		if (!class913_0.Fill.method_0())
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(rectangleF);
			Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
			interface42_0.imethod_31(brush_, rectangleF);
		}
		if (!class913_0.Line.method_0())
		{
			PointF[] array = new PointF[4]
			{
				new PointF(rectangleF.X, rectangleF.Bottom / 2f),
				new PointF(rectangleF.Right / 2f, rectangleF.Y),
				new PointF(rectangleF.Right, rectangleF.Bottom / 2f),
				new PointF(rectangleF.Right / 2f, rectangleF.Bottom)
			};
			interface42_0.imethod_9(pen_, rectangleF);
			interface42_0.imethod_15(pen_, array[0], array[2]);
			interface42_0.imethod_15(pen_, array[1], array[3]);
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
