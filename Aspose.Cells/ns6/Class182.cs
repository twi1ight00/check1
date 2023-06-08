using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class182 : Class160
{
	internal Class182(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = 0f;
		float x = class913_0.X;
		float y = class913_0.Y;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		new RectangleF(x, y, width, height);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		num = ((class913_0.class901_0 == null) ? 8333f : ((class913_0.class901_0.arrayList_0.Count <= 0) ? 8333f : Convert.ToSingle(class913_0.class901_0.arrayList_0[0])));
		float num2 = num * ((width > height) ? height : width) / 100000f;
		if (!class913_0.Fill.method_0())
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(x + width - 3f * num2, y, 2f * num2, 2f * num2, 270f, 90f);
			graphicsPath.AddArc(x + width - num2, y + height / 2f - 2f * num2, 2f * num2, 2f * num2, 180f, -90f);
			graphicsPath.AddArc(x + width - num2, y + height / 2f, 2f * num2, 2f * num2, 270f, -90f);
			graphicsPath.AddArc(x + width - 3f * num2, y + height - 2f * num2, 2f * num2, 2f * num2, 0f, 90f);
			graphicsPath.AddArc(x + num2, y + height - 2f * num2, 2f * num2, 2f * num2, 90f, 90f);
			graphicsPath.AddArc(x - num2, y + height / 2f, 2f * num2, 2f * num2, 0f, -90f);
			graphicsPath.AddArc(x - num2, y + height / 2f - 2f * num2, 2f * num2, 2f * num2, 90f, -90f);
			graphicsPath.AddArc(x + num2, y, 2f * num2, 2f * num2, 180f, 90f);
			graphicsPath.CloseFigure();
			Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
			interface42_0.imethod_33(brush_, graphicsPath);
		}
		if (!class913_0.Line.method_0())
		{
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.StartFigure();
			graphicsPath2.AddArc(x + width - 3f * num2, y, 2f * num2, 2f * num2, 270f, 90f);
			graphicsPath2.AddArc(x + width - num2, y + height / 2f - 2f * num2, 2f * num2, 2f * num2, 180f, -90f);
			graphicsPath2.AddArc(x + width - num2, y + height / 2f, 2f * num2, 2f * num2, 270f, -90f);
			graphicsPath2.AddArc(x + width - 3f * num2, y + height - 2f * num2, 2f * num2, 2f * num2, 0f, 90f);
			graphicsPath2.StartFigure();
			graphicsPath2.AddArc(x + num2, y + height - 2f * num2, 2f * num2, 2f * num2, 90f, 90f);
			graphicsPath2.AddArc(x - num2, y + height / 2f, 2f * num2, 2f * num2, 0f, -90f);
			graphicsPath2.AddArc(x - num2, y + height / 2f - 2f * num2, 2f * num2, 2f * num2, 90f, -90f);
			graphicsPath2.AddArc(x + num2, y, 2f * num2, 2f * num2, 180f, 90f);
			graphicsPath2.StartFigure();
			interface42_0.imethod_18(pen_, graphicsPath2);
		}
		base.vmethod_4();
	}
}
