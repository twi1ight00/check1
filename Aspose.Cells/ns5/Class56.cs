using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class56 : Class18
{
	private float float_5;

	internal Class56(Interface42 interface42_1, float float_6, float float_7, Class898 class898_1)
		: base(interface42_1, float_6, float_7, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_3;
		float num2 = float_4;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		RectangleF rectangleF_ = new RectangleF(num, num2, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		new GraphicsPath();
		PointF[] array = new PointF[7];
		if (class898_0.class885_0.arrayList_0.Count > 0)
		{
			float_5 = rectangleF_.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
		}
		else
		{
			float_5 = rectangleF_.Height * 0.24f;
		}
		if (!class898_0.Fill.method_0())
		{
			if (float_5 == 0f)
			{
				interface42_0.imethod_37(new SolidBrush(Color.White), rectangleF_);
			}
			else
			{
				switch (class898_0.int_2)
				{
				case 1:
				{
					ref PointF reference22 = ref array[0];
					reference22 = new PointF(float_3, float_5 + float_4);
					ref PointF reference23 = ref array[1];
					reference23 = new PointF(float_5 + float_3, float_4);
					ref PointF reference24 = ref array[2];
					reference24 = new PointF(rectangleF_.Width + float_3, float_4);
					ref PointF reference25 = ref array[3];
					reference25 = new PointF(rectangleF_.Width - float_5 + float_3, float_5 + float_4);
					ref PointF reference26 = ref array[4];
					reference26 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height - float_5 + float_4);
					ref PointF reference27 = ref array[5];
					reference27 = new PointF(rectangleF_.Width - float_5 + float_3, rectangleF_.Height + float_4);
					ref PointF reference28 = ref array[6];
					reference28 = new PointF(float_3, rectangleF_.Height + float_4);
					GraphicsPath graphicsPath10 = new GraphicsPath();
					new RectangleF(num, num2, width, float_5);
					graphicsPath10.AddLine(array[0], array[1]);
					graphicsPath10.AddLine(array[1], array[2]);
					graphicsPath10.AddLine(array[2], array[3]);
					graphicsPath10.AddLine(array[3], array[0]);
					graphicsPath10.CloseFigure();
					Brush brush_10 = Struct69.smethod_1(class898_0.Fill, graphicsPath10, 1f, 20f);
					interface42_0.imethod_33(brush_10, graphicsPath10);
					GraphicsPath graphicsPath11 = new GraphicsPath();
					new RectangleF(num, num2 + float_5, width, height - float_5);
					graphicsPath11.AddLine(array[0], array[3]);
					graphicsPath11.AddLine(array[3], array[5]);
					graphicsPath11.AddLine(array[5], array[6]);
					graphicsPath11.AddLine(array[6], array[0]);
					graphicsPath11.CloseFigure();
					Brush brush_11 = Struct69.smethod_0(class898_0.Fill, graphicsPath11);
					interface42_0.imethod_33(brush_11, graphicsPath11);
					GraphicsPath graphicsPath12 = new GraphicsPath();
					new RectangleF(num + width - float_5, num2, float_5, height);
					graphicsPath12.AddLine(array[3], array[2]);
					graphicsPath12.AddLine(array[2], array[4]);
					graphicsPath12.AddLine(array[4], array[5]);
					graphicsPath12.AddLine(array[5], array[3]);
					graphicsPath12.CloseFigure();
					Brush brush_12 = Struct69.smethod_1(class898_0.Fill, graphicsPath12, 0.8f, 0f);
					interface42_0.imethod_33(brush_12, graphicsPath12);
					break;
				}
				case 2:
				{
					ref PointF reference15 = ref array[0];
					reference15 = new PointF(float_3, rectangleF_.Height - float_5 + float_4);
					ref PointF reference16 = ref array[1];
					reference16 = new PointF(float_3, float_4);
					ref PointF reference17 = ref array[2];
					reference17 = new PointF(rectangleF_.Width - float_5 + float_3, float_4);
					ref PointF reference18 = ref array[3];
					reference18 = new PointF(rectangleF_.Width - float_5 + float_3, rectangleF_.Height - float_5 + float_4);
					ref PointF reference19 = ref array[4];
					reference19 = new PointF(rectangleF_.Width + float_3, float_5 + float_4);
					ref PointF reference20 = ref array[5];
					reference20 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height + float_4);
					ref PointF reference21 = ref array[6];
					reference21 = new PointF(float_5 + float_3, rectangleF_.Height + float_4);
					GraphicsPath graphicsPath7 = new GraphicsPath();
					new RectangleF(num, num2, width, float_5);
					graphicsPath7.AddLine(array[0], array[1]);
					graphicsPath7.AddLine(array[1], array[2]);
					graphicsPath7.AddLine(array[2], array[3]);
					graphicsPath7.AddLine(array[3], array[0]);
					graphicsPath7.CloseFigure();
					Brush brush_7 = Struct69.smethod_0(class898_0.Fill, graphicsPath7);
					interface42_0.imethod_33(brush_7, graphicsPath7);
					GraphicsPath graphicsPath8 = new GraphicsPath();
					new RectangleF(num, num2 + float_5, width, height - float_5);
					graphicsPath8.AddLine(array[3], array[2]);
					graphicsPath8.AddLine(array[2], array[4]);
					graphicsPath8.AddLine(array[4], array[5]);
					graphicsPath8.AddLine(array[5], array[3]);
					graphicsPath8.CloseFigure();
					Brush brush_8 = Struct69.smethod_1(class898_0.Fill, graphicsPath8, 0.8f, 0f);
					interface42_0.imethod_33(brush_8, graphicsPath8);
					GraphicsPath graphicsPath9 = new GraphicsPath();
					new RectangleF(num + width - float_5, num2, float_5, height);
					graphicsPath9.AddLine(array[0], array[3]);
					graphicsPath9.AddLine(array[3], array[5]);
					graphicsPath9.AddLine(array[5], array[6]);
					graphicsPath9.AddLine(array[6], array[0]);
					graphicsPath9.CloseFigure();
					Brush brush_9 = Struct69.smethod_1(class898_0.Fill, graphicsPath9, 1f, 20f);
					interface42_0.imethod_33(brush_9, graphicsPath9);
					break;
				}
				case 3:
				{
					ref PointF reference8 = ref array[0];
					reference8 = new PointF(float_3, float_5 + float_4);
					ref PointF reference9 = ref array[1];
					reference9 = new PointF(float_5 + float_3, float_4);
					ref PointF reference10 = ref array[2];
					reference10 = new PointF(rectangleF_.Width + float_3, float_4);
					ref PointF reference11 = ref array[3];
					reference11 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height - float_5 + float_4);
					ref PointF reference12 = ref array[4];
					reference12 = new PointF(float_5 + float_3, rectangleF_.Height - float_5 + float_4);
					ref PointF reference13 = ref array[5];
					reference13 = new PointF(float_3, rectangleF_.Height + float_4);
					ref PointF reference14 = ref array[6];
					reference14 = new PointF(rectangleF_.Width - float_5 + float_3, rectangleF_.Height + float_4);
					GraphicsPath graphicsPath4 = new GraphicsPath();
					new RectangleF(num, num2, width, float_5);
					graphicsPath4.AddLine(array[1], array[2]);
					graphicsPath4.AddLine(array[2], array[3]);
					graphicsPath4.AddLine(array[3], array[4]);
					graphicsPath4.AddLine(array[4], array[1]);
					graphicsPath4.CloseFigure();
					Brush brush_4 = Struct69.smethod_0(class898_0.Fill, graphicsPath4);
					interface42_0.imethod_33(brush_4, graphicsPath4);
					GraphicsPath graphicsPath5 = new GraphicsPath();
					new RectangleF(num, num2, width, float_5);
					graphicsPath5.AddLine(array[1], array[4]);
					graphicsPath5.AddLine(array[4], array[5]);
					graphicsPath5.AddLine(array[5], array[0]);
					graphicsPath5.AddLine(array[0], array[1]);
					graphicsPath5.CloseFigure();
					Brush brush_5 = Struct69.smethod_1(class898_0.Fill, graphicsPath5, 0.8f, 0f);
					interface42_0.imethod_33(brush_5, graphicsPath5);
					GraphicsPath graphicsPath6 = new GraphicsPath();
					new RectangleF(num, num2, width, float_5);
					graphicsPath6.AddLine(array[4], array[5]);
					graphicsPath6.AddLine(array[5], array[6]);
					graphicsPath6.AddLine(array[6], array[3]);
					graphicsPath6.AddLine(array[3], array[4]);
					graphicsPath6.CloseFigure();
					Brush brush_6 = Struct69.smethod_1(class898_0.Fill, graphicsPath6, 1f, 20f);
					interface42_0.imethod_33(brush_6, graphicsPath6);
					break;
				}
				case 4:
				{
					ref PointF reference = ref array[0];
					reference = new PointF(float_3, float_4);
					ref PointF reference2 = ref array[1];
					reference2 = new PointF(rectangleF_.Width - float_5 + float_3, float_4);
					ref PointF reference3 = ref array[2];
					reference3 = new PointF(rectangleF_.Width + float_3, float_5 + float_4);
					ref PointF reference4 = ref array[3];
					reference4 = new PointF(float_5 + float_3, float_5 + float_4);
					ref PointF reference5 = ref array[4];
					reference5 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height + float_4);
					ref PointF reference6 = ref array[5];
					reference6 = new PointF(float_5 + float_3, rectangleF_.Height + float_4);
					ref PointF reference7 = ref array[6];
					reference7 = new PointF(float_3, rectangleF_.Height - float_5 + float_4);
					GraphicsPath graphicsPath = new GraphicsPath();
					new RectangleF(num, num2, width, float_5);
					graphicsPath.AddLine(array[0], array[1]);
					graphicsPath.AddLine(array[1], array[2]);
					graphicsPath.AddLine(array[2], array[3]);
					graphicsPath.AddLine(array[3], array[0]);
					graphicsPath.CloseFigure();
					Brush brush_ = Struct69.smethod_1(class898_0.Fill, graphicsPath, 1f, 20f);
					interface42_0.imethod_33(brush_, graphicsPath);
					GraphicsPath graphicsPath2 = new GraphicsPath();
					new RectangleF(num, num2, width, float_5);
					graphicsPath2.AddLine(array[3], array[0]);
					graphicsPath2.AddLine(array[0], array[6]);
					graphicsPath2.AddLine(array[6], array[5]);
					graphicsPath2.AddLine(array[5], array[3]);
					graphicsPath2.CloseFigure();
					Brush brush_2 = Struct69.smethod_1(class898_0.Fill, graphicsPath2, 0.8f, 0f);
					interface42_0.imethod_33(brush_2, graphicsPath2);
					GraphicsPath graphicsPath3 = new GraphicsPath();
					new RectangleF(num, num2, width, float_5);
					graphicsPath3.AddLine(array[3], array[2]);
					graphicsPath3.AddLine(array[2], array[4]);
					graphicsPath3.AddLine(array[4], array[5]);
					graphicsPath3.AddLine(array[5], array[3]);
					graphicsPath3.CloseFigure();
					Brush brush_3 = Struct69.smethod_0(class898_0.Fill, graphicsPath3);
					interface42_0.imethod_33(brush_3, graphicsPath3);
					break;
				}
				}
			}
		}
		if (!class898_0.Line.method_0())
		{
			if (float_5 == 0f)
			{
				interface42_0.imethod_22(pen_, (int)num, (int)num2, (int)width, (int)height);
			}
			else
			{
				switch (class898_0.int_2)
				{
				case 1:
				{
					GraphicsPath graphicsPath16 = new GraphicsPath();
					ref PointF reference50 = ref array[0];
					reference50 = new PointF(float_3, float_5 + float_4);
					ref PointF reference51 = ref array[1];
					reference51 = new PointF(float_5 + float_3, float_4);
					ref PointF reference52 = ref array[2];
					reference52 = new PointF(rectangleF_.Width + float_3, float_4);
					ref PointF reference53 = ref array[3];
					reference53 = new PointF(rectangleF_.Width - float_5 + float_3, float_5 + float_4);
					ref PointF reference54 = ref array[4];
					reference54 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height - float_5 + float_4);
					ref PointF reference55 = ref array[5];
					reference55 = new PointF(rectangleF_.Width - float_5 + float_3, rectangleF_.Height + float_4);
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
					reference43 = new PointF(float_3, rectangleF_.Height - float_5 + float_4);
					ref PointF reference44 = ref array[1];
					reference44 = new PointF(float_3, float_4);
					ref PointF reference45 = ref array[2];
					reference45 = new PointF(rectangleF_.Width - float_5 + float_3, float_4);
					ref PointF reference46 = ref array[3];
					reference46 = new PointF(rectangleF_.Width - float_5 + float_3, rectangleF_.Height - float_5 + float_4);
					ref PointF reference47 = ref array[4];
					reference47 = new PointF(rectangleF_.Width + float_3, float_5 + float_4);
					ref PointF reference48 = ref array[5];
					reference48 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height + float_4);
					ref PointF reference49 = ref array[6];
					reference49 = new PointF(float_5 + float_3, rectangleF_.Height + float_4);
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
					reference36 = new PointF(float_3, float_5 + float_4);
					ref PointF reference37 = ref array[1];
					reference37 = new PointF(float_5 + float_3, float_4);
					ref PointF reference38 = ref array[2];
					reference38 = new PointF(rectangleF_.Width + float_3, float_4);
					ref PointF reference39 = ref array[3];
					reference39 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height - float_5 + float_4);
					ref PointF reference40 = ref array[4];
					reference40 = new PointF(float_5 + float_3, rectangleF_.Height - float_5 + float_4);
					ref PointF reference41 = ref array[5];
					reference41 = new PointF(float_3, rectangleF_.Height + float_4);
					ref PointF reference42 = ref array[6];
					reference42 = new PointF(rectangleF_.Width - float_5 + float_3, rectangleF_.Height + float_4);
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
					reference30 = new PointF(rectangleF_.Width - float_5 + float_3, float_4);
					ref PointF reference31 = ref array[2];
					reference31 = new PointF(rectangleF_.Width + float_3, float_5 + float_4);
					ref PointF reference32 = ref array[3];
					reference32 = new PointF(float_5 + float_3, float_5 + float_4);
					ref PointF reference33 = ref array[4];
					reference33 = new PointF(rectangleF_.Width + float_3, rectangleF_.Height + float_4);
					ref PointF reference34 = ref array[5];
					reference34 = new PointF(float_5 + float_3, rectangleF_.Height + float_4);
					ref PointF reference35 = ref array[6];
					reference35 = new PointF(float_3, rectangleF_.Height - float_5 + float_4);
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
		vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}

	internal override void vmethod_4()
	{
		interface42_0.ResetTransform();
		RectangleF rectangleF_ = class898_0.method_7();
		rectangleF_.Width -= float_5;
		if (!class898_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class898_0.Line.Weight / 2f, 0f - class898_0.Line.Weight / 2f);
		}
		float num = Struct69.smethod_12(class898_0.Font);
		if (class898_0.TextHorizontalAlignment != Enum104.const_7 && class898_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class898_0.TextHorizontalAlignment == Enum104.const_0 || class898_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num;
			}
		}
		else
		{
			rectangleF_.X += num;
		}
		rectangleF_.X += (float)class898_0.TextFrame.LeftMargin;
		rectangleF_.Y += (float)class898_0.TextFrame.TopMargin + float_5;
		if (rectangleF_.Height < (float)class898_0.Font.Height)
		{
			float num2 = ((float)class898_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class898_0.Font.Height);
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}
}
