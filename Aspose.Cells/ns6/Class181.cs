using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class181 : Class160
{
	internal Class181(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = float_3;
		float y = float_4;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		float num = 0f;
		num = ((class913_0.class901_0 == null) ? 0.25f : ((class913_0.class901_0.arrayList_0.Count <= 0) ? 0.25f : (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f)));
		GraphicsPath graphicsPath = new GraphicsPath();
		RectangleF rect = new RectangleF(x, y, width, height);
		graphicsPath.AddEllipse(rect);
		float num2 = ((width > height) ? height : width);
		rect.Inflate((0f - num) * num2, (0f - num) * num2);
		graphicsPath.AddEllipse(rect);
		return graphicsPath;
	}
}
