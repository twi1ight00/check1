using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class200 : Class160
{
	internal Class200(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_0;
		float num2 = float_1;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		new RectangleF(num, num2, width, height);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		float num3 = 0f;
		float num4 = 0f;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num3 = height * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 209999.98f;
				num4 = height * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f;
			}
			else
			{
				num3 = height / 35f;
				num4 = 3f * height / 6f;
			}
		}
		else
		{
			num3 = height / 35f;
			num4 = 3f * height / 6f;
		}
		switch (class913_0.int_3)
		{
		case 1:
		case 2:
			if (!class913_0.Fill.method_0())
			{
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2.AddArc(num - width / 2f, num2, width, 2f * num3, 270f, 90f);
				graphicsPath2.AddLine(num + width / 2f, num2 + num3, num + width / 2f, num2 + num4 - num3);
				graphicsPath2.AddArc(num + width / 2f, num2 + num4 - 2f * num3, width, 2f * num3, 180f, -90f);
				graphicsPath2.AddArc(num + width / 2f, num2 + num4, width, 2f * num3, 270f, -90f);
				graphicsPath2.AddLine(num + width / 2f, num2 + num4 + num3, num + width / 2f, num2 + height - num3);
				graphicsPath2.AddArc(num - width / 2f, num2 + height - 2f * num3, width, 2f * num3, 0f, 90f);
				graphicsPath2.CloseFigure();
				Brush brush_2 = Struct72.smethod_21(class913_0.Fill, graphicsPath2);
				interface42_0.imethod_33(brush_2, graphicsPath2);
			}
			if (!class913_0.Line.method_0())
			{
				interface42_0.imethod_5(pen_, num - width / 2f, num2, width, 2f * num3, 270f, 90f);
				interface42_0.imethod_5(pen_, num + width / 2f, num2 + num4 - 2f * num3, width, 2f * num3, 180f, -90f);
				interface42_0.imethod_5(pen_, num + width / 2f, num2 + num4, width, 2f * num3, 270f, -90f);
				interface42_0.imethod_5(pen_, num - width / 2f, num2 + height - 2f * num3, width, 2f * num3, 0f, 90f);
				interface42_0.imethod_16(pen_, num + width / 2f, num2 + num3, num + width / 2f, num2 + num4 - num3);
				interface42_0.imethod_16(pen_, num + width / 2f, num2 + num4 + num3, num + width / 2f, num2 + height - num3);
			}
			break;
		case 3:
		case 4:
			if (!class913_0.Fill.method_0())
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddArc(num + width / 2f, num2, width, 2f * num3, 270f, -90f);
				graphicsPath.AddLine(num + width / 2f, num2 + num3, num + width / 2f, num2 + num4 - num3);
				graphicsPath.AddArc(num - width / 2f, num2 + num4 - 2f * num3, width, 2f * num3, 0f, 90f);
				graphicsPath.AddArc(num - width / 2f, num2 + num4, width, 2f * num3, 270f, 90f);
				graphicsPath.AddLine(num + width / 2f, num2 + num4 + num3, num + width / 2f, num2 + height - num3);
				graphicsPath.AddArc(num + width / 2f, num2 + height - 2f * num3, width, 2f * num3, 180f, -90f);
				graphicsPath.CloseFigure();
				Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
				interface42_0.imethod_33(brush_, graphicsPath);
			}
			if (!class913_0.Line.method_0())
			{
				interface42_0.imethod_5(pen_, num + width / 2f, num2, width, 2f * num3, 270f, -90f);
				interface42_0.imethod_5(pen_, num - width / 2f, num2 + num4 - 2f * num3, width, 2f * num3, 0f, 90f);
				interface42_0.imethod_5(pen_, num - width / 2f, num2 + num4, width, 2f * num3, 270f, 90f);
				interface42_0.imethod_5(pen_, num + width / 2f, num2 + height - 2f * num3, width, 2f * num3, 180f, -90f);
				interface42_0.imethod_16(pen_, num + width / 2f, num2 + num3, num + width / 2f, num2 + num4 - num3);
				interface42_0.imethod_16(pen_, num + width / 2f, num2 + num4 + num3, num + width / 2f, num2 + height - num3);
			}
			break;
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
