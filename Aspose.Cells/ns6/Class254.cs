using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class254 : Class160
{
	internal Class254(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_3;
		float num2 = float_4;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rect = new RectangleF(num, num2, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		if (!class913_0.Fill.method_0())
		{
			interface42_0.imethod_32(brush_, num + 2f * width / 3f, num2, width / 3f, height);
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddArc(num + 2f * width / 3f, num2, width / 3f, height, 90f, 180f);
			graphicsPath2.AddLine(num + 5f * width / 6f, num2 + height, num + width / 6f, num2 + height);
			graphicsPath2.AddArc(num, num2, width / 3f, height, 90f, 180f);
			graphicsPath2.AddLine(num + width / 6f, num2, num + 5f * width / 6f, num2);
			graphicsPath2.CloseFigure();
			interface42_0.imethod_33(brush_, graphicsPath2);
		}
		if (!class913_0.Line.method_0())
		{
			interface42_0.imethod_10(pen_, num + 2f * width / 3f, num2, width / 3f, height);
			interface42_0.imethod_5(pen_, num + 2f * width / 3f, num2, width / 3f, height, 90f, 180f);
			interface42_0.imethod_16(pen_, num + 5f * width / 6f, num2 + height, num + width / 6f, num2 + height);
			interface42_0.imethod_5(pen_, num, num2, width / 3f, height, 90f, 180f);
			interface42_0.imethod_16(pen_, num + width / 6f, num2, num + 5f * width / 6f, num2);
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
