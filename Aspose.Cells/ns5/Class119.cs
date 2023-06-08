using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class119 : Class18
{
	internal Class119(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_3;
		float num2 = float_4;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		RectangleF rectangleF = new RectangleF(num, num2, width, height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangleF);
		Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		if (!class898_0.Fill.method_0())
		{
			interface42_0.imethod_37(brush_, rectangleF);
		}
		if (!class898_0.Line.method_0())
		{
			interface42_0.imethod_23(pen_, num, num2, width, height);
			interface42_0.imethod_16(pen_, num + width / 8f, num2, num + width / 8f, num2 + height);
			interface42_0.imethod_16(pen_, num, num2 + height / 8f, num + width, num2 + height / 8f);
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
