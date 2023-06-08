using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class183 : Class160
{
	internal Class183(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		if (!class913_0.Fill.method_0())
		{
			new RectangleF(float_3, float_4, class913_0.method_8().Width, class913_0.method_8().Height);
			GraphicsPath graphicsPath = new GraphicsPath();
			PointF[] array = new PointF[4];
			float num = 0f;
			num = ((class913_0.class901_0 == null) ? (class913_0.method_8().Height * 0.24f) : ((class913_0.class901_0.arrayList_0.Count <= 0) ? (class913_0.method_8().Height * 0.24f) : (class913_0.method_8().Height * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f)));
			if (num <= 0f)
			{
				ref PointF reference = ref array[0];
				reference = new PointF(float_3, float_4);
				ref PointF reference2 = ref array[1];
				reference2 = new PointF(float_3, class913_0.method_8().Height + float_4);
				ref PointF reference3 = ref array[2];
				reference3 = new PointF(class913_0.method_8().Width + float_3, float_4);
				ref PointF reference4 = ref array[3];
				reference4 = new PointF(class913_0.method_8().Width + float_3, class913_0.method_8().Height + float_4);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(array[2], array[3]);
			}
			else
			{
				float num2 = num * 2f;
				SizeF size = new SizeF(num2, num2);
				PointF location = new PointF(float_3, float_4);
				RectangleF rect = new RectangleF(location, size);
				rect.X = class913_0.method_8().Right - num2;
				graphicsPath.AddArc(rect, 270f, 90f);
				rect.Y = class913_0.method_8().Bottom - num2;
				graphicsPath.AddArc(rect, 0f, 90f);
				rect.X = class913_0.method_8().Left;
				graphicsPath.AddArc(rect, 90f, 90f);
				rect.Y = class913_0.method_8().Top;
				graphicsPath.AddArc(rect, 180f, 90f);
				graphicsPath.CloseFigure();
			}
			Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
			interface42_0.imethod_33(brush_, graphicsPath);
		}
		if (!class913_0.Line.method_0())
		{
			GraphicsPath graphicsPath2 = new GraphicsPath();
			PointF[] array2 = new PointF[4];
			float num3 = 0f;
			num3 = ((class913_0.class901_0 == null) ? (class913_0.method_8().Height * 0.24f) : (class913_0.method_8().Height * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f));
			if (num3 <= 0f)
			{
				ref PointF reference5 = ref array2[0];
				reference5 = new PointF(float_3, float_4);
				ref PointF reference6 = ref array2[1];
				reference6 = new PointF(float_3, class913_0.method_8().Height + float_4);
				ref PointF reference7 = ref array2[2];
				reference7 = new PointF(class913_0.method_8().Width + float_3, float_4);
				ref PointF reference8 = ref array2[3];
				reference8 = new PointF(class913_0.method_8().Width + float_3, class913_0.method_8().Height + float_4);
				graphicsPath2.AddLine(array2[0], array2[1]);
				graphicsPath2.StartFigure();
				graphicsPath2.AddLine(array2[2], array2[3]);
			}
			else
			{
				float num4 = num3 * 2f;
				SizeF size2 = new SizeF(num4, num4);
				PointF location2 = new PointF(float_3, float_4);
				RectangleF rect2 = new RectangleF(location2, size2);
				rect2.X = class913_0.method_8().Width - num4 + float_3;
				graphicsPath2.AddArc(rect2, 270f, 90f);
				rect2.Y = class913_0.method_8().Height - num4 + float_4;
				graphicsPath2.AddArc(rect2, 0f, 90f);
				graphicsPath2.StartFigure();
				rect2.X = float_3;
				graphicsPath2.AddArc(rect2, 90f, 90f);
				rect2.Y = float_4;
				graphicsPath2.AddArc(rect2, 180f, 90f);
				graphicsPath2.StartFigure();
			}
			interface42_0.imethod_18(pen_, graphicsPath2);
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
