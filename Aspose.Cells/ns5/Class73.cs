using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class73 : Class18
{
	internal Class73(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_0;
		float num2 = float_1;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		Brush brush_ = Struct69.smethod_2(rectangleF_0: new RectangleF(num, num2, width, height), class884_0: class898_0.Fill);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		float num3 = 0f;
		float num4 = 0f;
		if (class898_0.class885_0.arrayList_0.Count == 2)
		{
			num3 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			num4 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
		}
		else if (class898_0.class885_0.arrayList_0.Count == 1)
		{
			num3 = ((((Class882)class898_0.class885_0.arrayList_0[0]).method_0() != 327) ? (height / 10f) : (height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f));
			num4 = ((((Class882)class898_0.class885_0.arrayList_0[0]).method_0() != 328) ? (3f * height / 6f) : (height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f));
		}
		else
		{
			num3 = height / 10f;
			num4 = 3f * height / 6f;
		}
		switch (class898_0.int_2)
		{
		case 1:
		case 2:
			if (!class898_0.Fill.method_0())
			{
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2.AddArc(num - width / 2f, num2, width, 2f * num3, 270f, 90f);
				graphicsPath2.AddLine(num + width / 2f, num2 + num3, num + width / 2f, num2 + num4 - num3);
				graphicsPath2.AddArc(num + width / 2f, num2 + num4 - 2f * num3, width, 2f * num3, 180f, -90f);
				graphicsPath2.AddArc(num + width / 2f, num2 + num4, width, 2f * num3, 270f, -90f);
				graphicsPath2.AddLine(num + width / 2f, num2 + num4 + num3, num + width / 2f, num2 + height - num3);
				graphicsPath2.AddArc(num - width / 2f, num2 + height - 2f * num3, width, 2f * num3, 0f, 90f);
				graphicsPath2.CloseFigure();
				interface42_0.imethod_33(brush_, graphicsPath2);
			}
			if (!class898_0.Line.method_0())
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
			if (!class898_0.Fill.method_0())
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddArc(num + width / 2f, num2, width, 2f * num3, 270f, -90f);
				graphicsPath.AddLine(num + width / 2f, num2 + num3, num + width / 2f, num2 + num4 - num3);
				graphicsPath.AddArc(num - width / 2f, num2 + num4 - 2f * num3, width, 2f * num3, 0f, 90f);
				graphicsPath.AddArc(num - width / 2f, num2 + num4, width, 2f * num3, 270f, 90f);
				graphicsPath.AddLine(num + width / 2f, num2 + num4 + num3, num + width / 2f, num2 + height - num3);
				graphicsPath.AddArc(num + width / 2f, num2 + height - 2f * num3, width, 2f * num3, 180f, -90f);
				graphicsPath.CloseFigure();
				interface42_0.imethod_33(brush_, graphicsPath);
			}
			if (!class898_0.Line.method_0())
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
