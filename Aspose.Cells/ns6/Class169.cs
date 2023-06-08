using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class169 : Class160
{
	internal Class169(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		RectangleF rect = new RectangleF(float_3, float_4, class913_0.method_8().Width, class913_0.method_8().Height);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		if (!class913_0.Fill.method_0())
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (class913_0.class901_0 != null)
			{
				if (class913_0.class901_0.arrayList_0.Count > 0)
				{
					num = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]);
					num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]);
				}
				else
				{
					num = 0f;
				}
			}
			else
			{
				num = 0f;
			}
			if (num <= 0f)
			{
				graphicsPath.AddArc(rect, 270f, 90f);
				graphicsPath.AddLine(float_3 + rect.Width, float_4 + rect.Height / 2f, float_3 + rect.Width / 2f, float_4 + rect.Height / 2f);
				graphicsPath.AddLine(float_3 + rect.Width / 2f, float_4 + rect.Height / 2f, float_3 + rect.Width / 2f, float_4);
			}
			else
			{
				if (num >= 0f && num <= 5400000f)
				{
					num5 = num / 5400000f * 90f;
				}
				else if (num >= 5400000f && num <= 10800000f)
				{
					num5 = num / 10800000f * 180f;
				}
				else if (num >= 10800000f && num <= 16200000f)
				{
					num5 = num / 16200000f * 270f;
				}
				else if (num >= 16200000f && num <= 21600000f)
				{
					num5 = num / 21600000f * 360f;
				}
				if (num2 >= 0f && num2 <= 5400000f)
				{
					num6 = num2 / 5400000f * 90f;
				}
				else if (num2 >= 5400000f && num2 <= 10800000f)
				{
					num6 = num2 / 10800000f * 180f;
				}
				else if (num2 >= 10800000f && num2 <= 16200000f)
				{
					num6 = num2 / 16200000f * 270f;
				}
				else if (num2 >= 16200000f && num2 <= 21600000f)
				{
					num6 = num2 / 21600000f * 360f;
				}
				num3 = num5;
				num4 = ((num >= 0f && num <= 5400000f && num2 >= 0f && num2 <= 5400000f) ? (num6 - num5) : ((num >= 5400000f && num <= 10800000f && num2 >= 5400000f && num2 <= 10800000f) ? (num6 - num5) : ((num >= 10800000f && num <= 16200000f && num2 >= 10800000f && num2 <= 16200000f) ? (num6 - num5) : ((num >= 16200000f && num <= 21600000f && num2 >= 16200000f && num2 <= 21600000f) ? (num6 - num5) : ((!(num6 - num5 < 0f)) ? (num6 - num5) : (360f - Math.Abs(num6 - num5)))))));
				Rectangle rect2 = new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
				graphicsPath.AddPie(rect2, num3, num4);
			}
			Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
			interface42_0.imethod_33(brush_, graphicsPath);
		}
		if (!class913_0.Line.method_0())
		{
			GraphicsPath graphicsPath2 = new GraphicsPath();
			if (class913_0.class901_0 != null)
			{
				num = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]);
				num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]);
			}
			else
			{
				num = 0f;
			}
			if (num <= 0f)
			{
				graphicsPath2.AddArc(rect, 270f, 90f);
			}
			else
			{
				if (num >= 0f && num <= 5400000f)
				{
					num5 = num / 5400000f * 90f;
				}
				else if (num >= 5400000f && num <= 10800000f)
				{
					num5 = num / 10800000f * 180f;
				}
				else if (num >= 10800000f && num <= 16200000f)
				{
					num5 = num / 16200000f * 270f;
				}
				else if (num >= 16200000f && num <= 21600000f)
				{
					num5 = num / 21600000f * 360f;
				}
				if (num2 >= 0f && num2 <= 5400000f)
				{
					num6 = num2 / 5400000f * 90f;
				}
				else if (num2 >= 5400000f && num2 <= 10800000f)
				{
					num6 = num2 / 10800000f * 180f;
				}
				else if (num2 >= 10800000f && num2 <= 16200000f)
				{
					num6 = num2 / 16200000f * 270f;
				}
				else if (num2 >= 16200000f && num2 <= 21600000f)
				{
					num6 = num2 / 21600000f * 360f;
				}
				num3 = num5;
				graphicsPath2.AddArc(sweepAngle: (num >= 0f && num <= 5400000f && num2 >= 0f && num2 <= 5400000f) ? (num6 - num5) : ((num >= 5400000f && num <= 10800000f && num2 >= 5400000f && num2 <= 10800000f) ? (num6 - num5) : ((num >= 10800000f && num <= 16200000f && num2 >= 10800000f && num2 <= 16200000f) ? (num6 - num5) : ((num >= 16200000f && num <= 21600000f && num2 >= 16200000f && num2 <= 21600000f) ? (num6 - num5) : ((!(num6 - num5 < 0f)) ? (num6 - num5) : (360f - Math.Abs(num6 - num5)))))), rect: rect, startAngle: num3);
			}
			interface42_0.imethod_18(pen_, graphicsPath2);
		}
		interface42_0.imethod_55(smoothingMode_);
		base.vmethod_4();
	}
}
