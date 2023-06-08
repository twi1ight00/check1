using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class126 : Class18
{
	internal Class126(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		RectangleF rectangleF = new RectangleF(float_0, float_1, class898_0.Width, class898_0.Height);
		if (!class898_0.Fill.method_0())
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(rectangleF);
			Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
			interface42_0.imethod_31(brush_, rectangleF);
		}
		if (!class898_0.Line.method_0())
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
