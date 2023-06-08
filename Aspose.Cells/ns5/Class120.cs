using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class120 : Class18
{
	internal Class120(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_3;
		float num2 = float_4;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		RectangleF rect = new RectangleF(num, num2, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		if (!class898_0.Fill.method_0())
		{
			interface42_0.imethod_32(brush_, num, num2, width, height / 3f);
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddArc(num, num2, width, height / 3f, 0f, 180f);
			graphicsPath2.AddLine(num, num2 + height / 6f, num, num2 + 5f * height / 6f);
			graphicsPath2.AddArc(num, num2 + 2f * height / 3f, width, height / 3f, 180f, -180f);
			graphicsPath2.AddLine(num + width, num2 + 5f * height / 6f, num + width, num2 + height / 6f);
			graphicsPath2.CloseFigure();
			interface42_0.imethod_33(brush_, graphicsPath2);
		}
		if (!class898_0.Line.method_0())
		{
			interface42_0.imethod_10(pen_, num, num2, width, height / 3f);
			interface42_0.imethod_5(pen_, num, num2, width, height / 3f, 0f, 180f);
			interface42_0.imethod_16(pen_, num, num2 + height / 6f, num, num2 + 5f * height / 6f);
			interface42_0.imethod_5(pen_, num, num2 + 2f * height / 3f, width, height / 3f, 180f, -180f);
			interface42_0.imethod_16(pen_, num + width, num2 + 5f * height / 6f, num + width, num2 + height / 6f);
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
