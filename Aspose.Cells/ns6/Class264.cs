using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class264 : Class160
{
	internal Class264(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_3;
		float num2 = float_4;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rectangleF = new RectangleF(num, num2, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangleF);
		Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		if (!class913_0.Fill.method_0())
		{
			interface42_0.imethod_37(brush_, rectangleF);
		}
		if (!class913_0.Line.method_0())
		{
			interface42_0.imethod_23(pen_, num, num2, width, height);
			interface42_0.imethod_16(pen_, num + width / 8f, num2, num + width / 8f, num2 + height);
			interface42_0.imethod_16(pen_, num + 7f * width / 8f, num2, num + 7f * width / 8f, num2 + height);
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
