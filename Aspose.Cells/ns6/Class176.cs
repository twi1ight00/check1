using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class176 : Class160
{
	internal Class176(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_3;
		float num2 = float_4;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rectangleF_ = new RectangleF(num, num2, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		Brush brush_ = Struct72.smethod_20(class913_0.Fill, rectangleF_);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		new GraphicsPath();
		PointF[] array = new PointF[7];
		float num3 = 0f;
		num3 = ((class913_0.class901_0 == null) ? (rectangleF_.Height * 0.24f) : ((class913_0.class901_0.arrayList_0.Count <= 0) ? (rectangleF_.Height * 0.24f) : (rectangleF_.Height * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f)));
		if (!class913_0.Fill.method_0())
		{
			if (num3 == 0f)
			{
				interface42_0.imethod_37(brush_, rectangleF_);
			}
			else
			{
				switch (class913_0.int_3)
				{
				case 1:
				{
					ref PointF reference22 = ref array[0];
					reference22 = new PointF(float_3, num3 + float_4);
					ref PointF reference23 = ref array[1];
					reference23 = new PointF(num3 + float_3, float_4);
					ref PointF reference24 = ref array[2];
					reference24 = new PointF(rectangleF_.Width + float_3, float_4);
					ref PointF reference25 = ref array[3];
					reference25 = new PointF(rectangleF_.Width - num3 + float_3, num3 + float_4);
					ref PointF reference26 = ref array[4];
					reference26 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height - num3 + float_4);
					ref PointF reference27 = ref array[5];
					reference27 = new PointF(rectangleF_.Width - num3 + float_3, rectangleF_.Height + float_4);
					ref PointF reference28 = ref array[6];
					reference28 = new PointF(float_3, rectangleF_.Height + float_4);
					GraphicsPath graphicsPath10 = new GraphicsPath();
					RectangleF rectangleF_8 = new RectangleF(num, num2, width, num3);
					graphicsPath10.AddLine(array[0], array[1]);
					graphicsPath10.AddLine(array[1], array[2]);
					graphicsPath10.AddLine(array[2], array[3]);
					graphicsPath10.AddLine(array[3], array[0]);
					graphicsPath10.CloseFigure();
					interface42_0.imethod_33(Struct72.smethod_19(class913_0.Fill, rectangleF_8, 1f, 20f), graphicsPath10);
					GraphicsPath graphicsPath11 = new GraphicsPath();
					new RectangleF(num, num2 + num3, width, height - num3);
					graphicsPath11.AddLine(array[0], array[3]);
					graphicsPath11.AddLine(array[3], array[5]);
					graphicsPath11.AddLine(array[5], array[6]);
					graphicsPath11.AddLine(array[6], array[0]);
					graphicsPath11.CloseFigure();
					interface42_0.imethod_33(brush_, graphicsPath11);
					GraphicsPath graphicsPath12 = new GraphicsPath();
					RectangleF rectangleF_9 = new RectangleF(num + width - num3, num2, num3, height);
					graphicsPath12.AddLine(array[3], array[2]);
					graphicsPath12.AddLine(array[2], array[4]);
					graphicsPath12.AddLine(array[4], array[5]);
					graphicsPath12.AddLine(array[5], array[3]);
					graphicsPath12.CloseFigure();
					interface42_0.imethod_33(Struct72.smethod_19(class913_0.Fill, rectangleF_9, 0.8f, 0f), graphicsPath12);
					break;
				}
				case 2:
				{
					ref PointF reference15 = ref array[0];
					reference15 = new PointF(float_3, rectangleF_.Height - num3 + float_4);
					ref PointF reference16 = ref array[1];
					reference16 = new PointF(float_3, float_4);
					ref PointF reference17 = ref array[2];
					reference17 = new PointF(rectangleF_.Width - num3 + float_3, float_4);
					ref PointF reference18 = ref array[3];
					reference18 = new PointF(rectangleF_.Width - num3 + float_3, rectangleF_.Height - num3 + float_4);
					ref PointF reference19 = ref array[4];
					reference19 = new PointF(rectangleF_.Width + float_3, num3 + float_4);
					ref PointF reference20 = ref array[5];
					reference20 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height + float_4);
					ref PointF reference21 = ref array[6];
					reference21 = new PointF(num3 + float_3, rectangleF_.Height + float_4);
					GraphicsPath graphicsPath7 = new GraphicsPath();
					new RectangleF(num, num2, width, num3);
					graphicsPath7.AddLine(array[0], array[1]);
					graphicsPath7.AddLine(array[1], array[2]);
					graphicsPath7.AddLine(array[2], array[3]);
					graphicsPath7.AddLine(array[3], array[0]);
					graphicsPath7.CloseFigure();
					interface42_0.imethod_33(brush_, graphicsPath7);
					GraphicsPath graphicsPath8 = new GraphicsPath();
					RectangleF rectangleF_6 = new RectangleF(num, num2 + num3, width, height - num3);
					graphicsPath8.AddLine(array[3], array[2]);
					graphicsPath8.AddLine(array[2], array[4]);
					graphicsPath8.AddLine(array[4], array[5]);
					graphicsPath8.AddLine(array[5], array[3]);
					graphicsPath8.CloseFigure();
					interface42_0.imethod_33(Struct72.smethod_19(class913_0.Fill, rectangleF_6, 0.8f, 0f), graphicsPath8);
					GraphicsPath graphicsPath9 = new GraphicsPath();
					RectangleF rectangleF_7 = new RectangleF(num + width - num3, num2, num3, height);
					graphicsPath9.AddLine(array[0], array[3]);
					graphicsPath9.AddLine(array[3], array[5]);
					graphicsPath9.AddLine(array[5], array[6]);
					graphicsPath9.AddLine(array[6], array[0]);
					graphicsPath9.CloseFigure();
					interface42_0.imethod_33(Struct72.smethod_19(class913_0.Fill, rectangleF_7, 1f, 20f), graphicsPath9);
					break;
				}
				case 3:
				{
					ref PointF reference8 = ref array[0];
					reference8 = new PointF(float_3, num3 + float_4);
					ref PointF reference9 = ref array[1];
					reference9 = new PointF(num3 + float_3, float_4);
					ref PointF reference10 = ref array[2];
					reference10 = new PointF(rectangleF_.Width + float_3, float_4);
					ref PointF reference11 = ref array[3];
					reference11 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height - num3 + float_4);
					ref PointF reference12 = ref array[4];
					reference12 = new PointF(num3 + float_3, rectangleF_.Height - num3 + float_4);
					ref PointF reference13 = ref array[5];
					reference13 = new PointF(float_3, rectangleF_.Height + float_4);
					ref PointF reference14 = ref array[6];
					reference14 = new PointF(rectangleF_.Width - num3 + float_3, rectangleF_.Height + float_4);
					GraphicsPath graphicsPath4 = new GraphicsPath();
					new RectangleF(num, num2, width, num3);
					graphicsPath4.AddLine(array[1], array[2]);
					graphicsPath4.AddLine(array[2], array[3]);
					graphicsPath4.AddLine(array[3], array[4]);
					graphicsPath4.AddLine(array[4], array[1]);
					graphicsPath4.CloseFigure();
					interface42_0.imethod_33(brush_, graphicsPath4);
					GraphicsPath graphicsPath5 = new GraphicsPath();
					RectangleF rectangleF_4 = new RectangleF(num, num2, width, num3);
					graphicsPath5.AddLine(array[1], array[4]);
					graphicsPath5.AddLine(array[4], array[5]);
					graphicsPath5.AddLine(array[5], array[0]);
					graphicsPath5.AddLine(array[0], array[1]);
					graphicsPath5.CloseFigure();
					interface42_0.imethod_33(Struct72.smethod_19(class913_0.Fill, rectangleF_4, 0.8f, 0f), graphicsPath5);
					GraphicsPath graphicsPath6 = new GraphicsPath();
					RectangleF rectangleF_5 = new RectangleF(num, num2, width, num3);
					graphicsPath6.AddLine(array[4], array[5]);
					graphicsPath6.AddLine(array[5], array[6]);
					graphicsPath6.AddLine(array[6], array[3]);
					graphicsPath6.AddLine(array[3], array[4]);
					graphicsPath6.CloseFigure();
					interface42_0.imethod_33(Struct72.smethod_19(class913_0.Fill, rectangleF_5, 1f, 20f), graphicsPath6);
					break;
				}
				case 4:
				{
					ref PointF reference = ref array[0];
					reference = new PointF(float_3, float_4);
					ref PointF reference2 = ref array[1];
					reference2 = new PointF(rectangleF_.Width - num3 + float_3, float_4);
					ref PointF reference3 = ref array[2];
					reference3 = new PointF(rectangleF_.Width + float_3, num3 + float_4);
					ref PointF reference4 = ref array[3];
					reference4 = new PointF(num3 + float_3, num3 + float_4);
					ref PointF reference5 = ref array[4];
					reference5 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height + float_4);
					ref PointF reference6 = ref array[5];
					reference6 = new PointF(num3 + float_3, rectangleF_.Height + float_4);
					ref PointF reference7 = ref array[6];
					reference7 = new PointF(float_3, rectangleF_.Height - num3 + float_4);
					GraphicsPath graphicsPath = new GraphicsPath();
					RectangleF rectangleF_2 = new RectangleF(num, num2, width, num3);
					graphicsPath.AddLine(array[0], array[1]);
					graphicsPath.AddLine(array[1], array[2]);
					graphicsPath.AddLine(array[2], array[3]);
					graphicsPath.AddLine(array[3], array[0]);
					graphicsPath.CloseFigure();
					interface42_0.imethod_33(Struct72.smethod_19(class913_0.Fill, rectangleF_2, 1f, 20f), graphicsPath);
					GraphicsPath graphicsPath2 = new GraphicsPath();
					RectangleF rectangleF_3 = new RectangleF(num, num2, width, num3);
					graphicsPath2.AddLine(array[3], array[0]);
					graphicsPath2.AddLine(array[0], array[6]);
					graphicsPath2.AddLine(array[6], array[5]);
					graphicsPath2.AddLine(array[5], array[3]);
					graphicsPath2.CloseFigure();
					interface42_0.imethod_33(Struct72.smethod_19(class913_0.Fill, rectangleF_3, 0.8f, 0f), graphicsPath2);
					GraphicsPath graphicsPath3 = new GraphicsPath();
					new RectangleF(num, num2, width, num3);
					graphicsPath3.AddLine(array[3], array[2]);
					graphicsPath3.AddLine(array[2], array[4]);
					graphicsPath3.AddLine(array[4], array[5]);
					graphicsPath3.AddLine(array[5], array[3]);
					graphicsPath3.CloseFigure();
					interface42_0.imethod_33(brush_, graphicsPath3);
					break;
				}
				}
			}
		}
		if (!class913_0.Line.method_0())
		{
			if (num3 == 0f)
			{
				interface42_0.imethod_22(pen_, (int)num, (int)num2, (int)width, (int)height);
			}
			else
			{
				switch (class913_0.int_3)
				{
				case 1:
				{
					GraphicsPath graphicsPath16 = new GraphicsPath();
					ref PointF reference50 = ref array[0];
					reference50 = new PointF(float_3, num3 + float_4);
					ref PointF reference51 = ref array[1];
					reference51 = new PointF(num3 + float_3, float_4);
					ref PointF reference52 = ref array[2];
					reference52 = new PointF(rectangleF_.Width + float_3, float_4);
					ref PointF reference53 = ref array[3];
					reference53 = new PointF(rectangleF_.Width - num3 + float_3, num3 + float_4);
					ref PointF reference54 = ref array[4];
					reference54 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height - num3 + float_4);
					ref PointF reference55 = ref array[5];
					reference55 = new PointF(rectangleF_.Width - num3 + float_3, rectangleF_.Height + float_4);
					ref PointF reference56 = ref array[6];
					reference56 = new PointF(float_3, rectangleF_.Height + float_4);
					graphicsPath16.AddLine(array[0], array[1]);
					graphicsPath16.AddLine(array[1], array[2]);
					graphicsPath16.AddLine(array[2], array[3]);
					graphicsPath16.AddLine(array[3], array[0]);
					graphicsPath16.AddLine(array[0], array[3]);
					graphicsPath16.AddLine(array[3], array[5]);
					graphicsPath16.AddLine(array[5], array[6]);
					graphicsPath16.AddLine(array[6], array[0]);
					graphicsPath16.AddLine(array[3], array[2]);
					graphicsPath16.AddLine(array[2], array[4]);
					graphicsPath16.AddLine(array[4], array[5]);
					graphicsPath16.AddLine(array[5], array[3]);
					graphicsPath16.CloseFigure();
					interface42_0.imethod_18(pen_, graphicsPath16);
					break;
				}
				case 2:
				{
					GraphicsPath graphicsPath15 = new GraphicsPath();
					ref PointF reference43 = ref array[0];
					reference43 = new PointF(float_3, rectangleF_.Height - num3 + float_4);
					ref PointF reference44 = ref array[1];
					reference44 = new PointF(float_3, float_4);
					ref PointF reference45 = ref array[2];
					reference45 = new PointF(rectangleF_.Width - num3 + float_3, float_4);
					ref PointF reference46 = ref array[3];
					reference46 = new PointF(rectangleF_.Width - num3 + float_3, rectangleF_.Height - num3 + float_4);
					ref PointF reference47 = ref array[4];
					reference47 = new PointF(rectangleF_.Width + float_3, num3 + float_4);
					ref PointF reference48 = ref array[5];
					reference48 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height + float_4);
					ref PointF reference49 = ref array[6];
					reference49 = new PointF(num3 + float_3, rectangleF_.Height + float_4);
					graphicsPath15.AddLine(array[0], array[1]);
					graphicsPath15.AddLine(array[1], array[2]);
					graphicsPath15.AddLine(array[2], array[3]);
					graphicsPath15.AddLine(array[3], array[0]);
					graphicsPath15.AddLine(array[3], array[2]);
					graphicsPath15.AddLine(array[2], array[4]);
					graphicsPath15.AddLine(array[4], array[5]);
					graphicsPath15.AddLine(array[5], array[3]);
					graphicsPath15.AddLine(array[0], array[3]);
					graphicsPath15.AddLine(array[3], array[5]);
					graphicsPath15.AddLine(array[5], array[6]);
					graphicsPath15.AddLine(array[6], array[0]);
					graphicsPath15.CloseFigure();
					interface42_0.imethod_18(pen_, graphicsPath15);
					break;
				}
				case 3:
				{
					GraphicsPath graphicsPath14 = new GraphicsPath();
					ref PointF reference36 = ref array[0];
					reference36 = new PointF(float_3, num3 + float_4);
					ref PointF reference37 = ref array[1];
					reference37 = new PointF(num3 + float_3, float_4);
					ref PointF reference38 = ref array[2];
					reference38 = new PointF(rectangleF_.Width + float_3, float_4);
					ref PointF reference39 = ref array[3];
					reference39 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height - num3 + float_4);
					ref PointF reference40 = ref array[4];
					reference40 = new PointF(num3 + float_3, rectangleF_.Height - num3 + float_4);
					ref PointF reference41 = ref array[5];
					reference41 = new PointF(float_3, rectangleF_.Height + float_4);
					ref PointF reference42 = ref array[6];
					reference42 = new PointF(rectangleF_.Width - num3 + float_3, rectangleF_.Height + float_4);
					graphicsPath14.AddLine(array[1], array[2]);
					graphicsPath14.AddLine(array[2], array[3]);
					graphicsPath14.AddLine(array[3], array[4]);
					graphicsPath14.AddLine(array[4], array[1]);
					graphicsPath14.AddLine(array[1], array[4]);
					graphicsPath14.AddLine(array[4], array[5]);
					graphicsPath14.AddLine(array[5], array[0]);
					graphicsPath14.AddLine(array[0], array[1]);
					graphicsPath14.AddLine(array[4], array[5]);
					graphicsPath14.AddLine(array[5], array[6]);
					graphicsPath14.AddLine(array[6], array[3]);
					graphicsPath14.AddLine(array[3], array[4]);
					graphicsPath14.CloseFigure();
					interface42_0.imethod_18(pen_, graphicsPath14);
					break;
				}
				case 4:
				{
					GraphicsPath graphicsPath13 = new GraphicsPath();
					ref PointF reference29 = ref array[0];
					reference29 = new PointF(float_3, float_4);
					ref PointF reference30 = ref array[1];
					reference30 = new PointF(rectangleF_.Width - num3 + float_3, float_4);
					ref PointF reference31 = ref array[2];
					reference31 = new PointF(rectangleF_.Width + float_3, num3 + float_4);
					ref PointF reference32 = ref array[3];
					reference32 = new PointF(num3 + float_3, num3 + float_4);
					ref PointF reference33 = ref array[4];
					reference33 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height + float_4);
					ref PointF reference34 = ref array[5];
					reference34 = new PointF(num3 + float_3, rectangleF_.Height + float_4);
					ref PointF reference35 = ref array[6];
					reference35 = new PointF(float_3, rectangleF_.Height - num3 + float_4);
					graphicsPath13.AddLine(array[0], array[1]);
					graphicsPath13.AddLine(array[1], array[2]);
					graphicsPath13.AddLine(array[2], array[3]);
					graphicsPath13.AddLine(array[3], array[0]);
					graphicsPath13.AddLine(array[3], array[0]);
					graphicsPath13.AddLine(array[0], array[6]);
					graphicsPath13.AddLine(array[6], array[5]);
					graphicsPath13.AddLine(array[5], array[3]);
					graphicsPath13.AddLine(array[3], array[2]);
					graphicsPath13.AddLine(array[2], array[4]);
					graphicsPath13.AddLine(array[4], array[5]);
					graphicsPath13.AddLine(array[5], array[3]);
					graphicsPath13.CloseFigure();
					interface42_0.imethod_18(pen_, graphicsPath13);
					break;
				}
				}
			}
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
