using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class107 : Class18
{
	internal Class107(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = 0f;
		float num2 = 0f;
		PointF[] array = new PointF[7];
		float num3 = 2f * Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.15f;
		float num4 = 1111f;
		float num5 = 26041f;
		ArrayList arrayList_ = class898_0.class885_0.arrayList_0;
		if (arrayList_.Count > 0)
		{
			foreach (Class882 item in arrayList_)
			{
				if (item.method_0() == 327)
				{
					num4 = Convert.ToSingle(item.Value);
				}
				if (item.method_0() == 328)
				{
					num5 = Convert.ToSingle(item.Value);
				}
			}
			num = Math.Abs(rectangleF_0.Width * (num4 / 21600f));
			num2 = Math.Abs(rectangleF_0.Height * (num5 / 21600f));
			if (num4 > 0f && num5 > 0f && num <= rectangleF_0.Width && num2 <= rectangleF_0.Height)
			{
				RectangleF rect = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
				graphicsPath.AddArc(rect, 180f, 90f);
				rect.X = rectangleF_0.Right - num3;
				graphicsPath.AddArc(rect, 270f, 90f);
				rect.Y = rectangleF_0.Bottom - num3;
				graphicsPath.AddArc(rect, 0f, 90f);
				rect.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect, 90f, 90f);
				graphicsPath.CloseFigure();
				return graphicsPath;
			}
		}
		else
		{
			num4 = 1111f;
			num5 = 26041f;
			num = rectangleF_0.Width * Math.Abs(num4 / 21600f);
			num2 = rectangleF_0.Height * Math.Abs(num5 / 21600f);
		}
		float num6 = (float)(Math.Atan(rectangleF_0.Width / rectangleF_0.Height) * 180.0 / Math.PI);
		float num7 = 0f;
		num7 = ((num4 > 0f && num5 > 0f) ? ((num < rectangleF_0.Width / 2f && num2 > rectangleF_0.Height) ? (90f + (float)(Math.Atan((rectangleF_0.Width / 2f - num) / (num2 - rectangleF_0.Height / 2f)) * 180.0 / Math.PI)) : ((!(num > rectangleF_0.Width) || !(num2 < rectangleF_0.Height / 2f)) ? ((float)(Math.Atan(num2 / num) * 180.0 / Math.PI)) : (360f - (float)(Math.Atan((rectangleF_0.Height / 2f + num2) / (num - rectangleF_0.Width / 2f)) * 180.0 / Math.PI)))) : ((num4 < 0f && num5 > 0f) ? ((!(num2 > rectangleF_0.Height / 2f)) ? (180f + (float)(Math.Atan((rectangleF_0.Height / 2f - num2) / (num + rectangleF_0.Width / 2f)) * 180.0 / Math.PI)) : (90f + (float)(Math.Atan((rectangleF_0.Width / 2f + num) / (num2 - rectangleF_0.Height / 2f)) * 180.0 / Math.PI))) : ((num4 < 0f && num5 < 0f) ? (180f + (float)(Math.Atan((rectangleF_0.Height / 2f + num2) / (num + rectangleF_0.Width / 2f)) * 180.0 / Math.PI)) : ((!(num > rectangleF_0.Width / 2f)) ? (180f + (float)(Math.Atan((rectangleF_0.Height / 2f + num2) / (rectangleF_0.Width / 2f - num)) * 180.0 / Math.PI)) : (360f - (float)(Math.Atan((rectangleF_0.Height / 2f + num2) / (num - rectangleF_0.Width / 2f)) * 180.0 / Math.PI))))));
		if (num7 > 0f && num7 < 90f - num6)
		{
			RectangleF rect2 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
			ref PointF reference = ref array[0];
			reference = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height * 0.58f);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.X + num, rectangleF_0.Y + num2);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height * 0.83f);
			graphicsPath.AddArc(rect2, 180f, 90f);
			rect2.X = rectangleF_0.Right - num3;
			graphicsPath.AddArc(rect2, 270f, 90f);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			rect2.Y = rectangleF_0.Bottom - num3;
			graphicsPath.AddArc(rect2, 0f, 90f);
			rect2.X = rectangleF_0.Left;
			graphicsPath.AddArc(rect2, 90f, 90f);
		}
		else if (num7 > 90f - num6 && num7 < 90f)
		{
			RectangleF rect3 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
			ref PointF reference4 = ref array[0];
			reference4 = new PointF(rectangleF_0.X + rectangleF_0.Width * 0.83f, rectangleF_0.Y + rectangleF_0.Height);
			ref PointF reference5 = ref array[1];
			reference5 = new PointF(rectangleF_0.X + num, rectangleF_0.Y + num2);
			ref PointF reference6 = ref array[2];
			reference6 = new PointF(rectangleF_0.X + rectangleF_0.Width * 0.58f, rectangleF_0.Y + rectangleF_0.Height);
			graphicsPath.AddArc(rect3, 180f, 90f);
			rect3.X = rectangleF_0.Right - num3;
			graphicsPath.AddArc(rect3, 270f, 90f);
			rect3.Y = rectangleF_0.Bottom - num3;
			graphicsPath.AddArc(rect3, 0f, 90f);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			rect3.X = rectangleF_0.Left;
			graphicsPath.AddArc(rect3, 90f, 90f);
		}
		else if (num7 > 90f && num7 < 90f + num6)
		{
			if (num4 < 0f)
			{
				SizeF size4 = new SizeF(num3, num3);
				float num8 = num;
				RectangleF rect4 = new RectangleF(rectangleF_0.Location, size4);
				ref PointF reference7 = ref array[0];
				reference7 = new PointF(num8 + 0.42f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference8 = ref array[1];
				reference8 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
				ref PointF reference9 = ref array[2];
				reference9 = new PointF(num8 + 0.17f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				rect4.X += num8;
				graphicsPath.AddArc(rect4, 180f, 90f);
				rect4.X = rectangleF_0.Right - num3 + num8;
				graphicsPath.AddArc(rect4, 270f, 90f);
				rect4.Y = rectangleF_0.Bottom - num3;
				graphicsPath.AddArc(rect4, 0f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect4.X = rectangleF_0.Left + num8;
				graphicsPath.AddArc(rect4, 90f, 90f);
			}
			else
			{
				RectangleF rect5 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
				ref PointF reference10 = ref array[0];
				reference10 = new PointF(0.42f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference11 = ref array[1];
				reference11 = new PointF(rectangleF_0.X + num, num2 + rectangleF_0.Y);
				ref PointF reference12 = ref array[2];
				reference12 = new PointF(0.17f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				graphicsPath.AddArc(rect5, 180f, 90f);
				rect5.X = rectangleF_0.Right - num3;
				graphicsPath.AddArc(rect5, 270f, 90f);
				rect5.Y = rectangleF_0.Bottom - num3;
				graphicsPath.AddArc(rect5, 0f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect5.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect5, 90f, 90f);
			}
		}
		else if (num7 > 90f + num6 && num7 < 180f)
		{
			RectangleF rect6 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
			float num9 = num;
			ref PointF reference13 = ref array[0];
			reference13 = new PointF(num9 + rectangleF_0.X, rectangleF_0.Height * 0.83f + rectangleF_0.Y);
			ref PointF reference14 = ref array[1];
			reference14 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
			ref PointF reference15 = ref array[2];
			reference15 = new PointF(num9 + rectangleF_0.X, rectangleF_0.Height * 0.58f + rectangleF_0.Y);
			rect6.X += num9;
			graphicsPath.AddArc(rect6, 180f, 90f);
			rect6.X = rectangleF_0.Right - num3 + num9;
			graphicsPath.AddArc(rect6, 270f, 90f);
			rect6.Y = rectangleF_0.Bottom - num3;
			graphicsPath.AddArc(rect6, 0f, 90f);
			rect6.X = rectangleF_0.Left + num9;
			graphicsPath.AddArc(rect6, 90f, 90f);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
		}
		else if (num7 > 180f && num7 < 180f + (90f - num6))
		{
			if (num5 < 0f)
			{
				RectangleF rect7 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
				float num10 = num;
				float num11 = num2;
				ref PointF reference16 = ref array[0];
				reference16 = new PointF(num10 + rectangleF_0.X, rectangleF_0.Height * 0.42f + num11 + rectangleF_0.Y);
				ref PointF reference17 = ref array[1];
				reference17 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference18 = ref array[2];
				reference18 = new PointF(num10 + rectangleF_0.X, rectangleF_0.Height * 0.17f + num11 + rectangleF_0.Y);
				rect7.X += num10;
				rect7.Y += num11;
				graphicsPath.AddArc(rect7, 180f, 90f);
				rect7.X = rectangleF_0.Right - num3 + num10;
				graphicsPath.AddArc(rect7, 270f, 90f);
				rect7.Y = rectangleF_0.Bottom - num3 + num11;
				graphicsPath.AddArc(rect7, 0f, 90f);
				rect7.X = rectangleF_0.Left + num10;
				graphicsPath.AddArc(rect7, 90f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
			}
			else
			{
				RectangleF rect8 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
				float num12 = num;
				ref PointF reference19 = ref array[0];
				reference19 = new PointF(num12 + rectangleF_0.X, rectangleF_0.Height * 0.42f + rectangleF_0.Y);
				ref PointF reference20 = ref array[1];
				reference20 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
				ref PointF reference21 = ref array[2];
				reference21 = new PointF(num12 + rectangleF_0.X, rectangleF_0.Height * 0.17f + rectangleF_0.Y);
				rect8.X += num12;
				graphicsPath.AddArc(rect8, 180f, 90f);
				rect8.X = rectangleF_0.Right - num3 + num12;
				graphicsPath.AddArc(rect8, 270f, 90f);
				rect8.Y = rectangleF_0.Bottom - num3;
				graphicsPath.AddArc(rect8, 0f, 90f);
				rect8.X = rectangleF_0.Left + num12;
				graphicsPath.AddArc(rect8, 90f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
			}
		}
		else if (num7 > 180f + (90f - num6) && num7 < 270f)
		{
			if (num4 < 0f)
			{
				RectangleF rect9 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
				float num13 = num;
				float num14 = num2;
				ref PointF reference22 = ref array[0];
				reference22 = new PointF(num13 + 0.17f * rectangleF_0.Width + rectangleF_0.X, num14 + rectangleF_0.Y);
				ref PointF reference23 = ref array[1];
				reference23 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference24 = ref array[2];
				reference24 = new PointF(num13 + 0.42f * rectangleF_0.Width + rectangleF_0.X, num14 + rectangleF_0.Y);
				rect9.X += num13;
				rect9.Y += num14;
				graphicsPath.AddArc(rect9, 180f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect9.X = rectangleF_0.Right - num3 + num13;
				graphicsPath.AddArc(rect9, 270f, 90f);
				rect9.Y = rectangleF_0.Bottom - num3 + num14;
				graphicsPath.AddArc(rect9, 0f, 90f);
				rect9.X = rectangleF_0.Left + num13;
				graphicsPath.AddArc(rect9, 90f, 90f);
			}
			else
			{
				RectangleF rect10 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
				float num15 = num2;
				ref PointF reference25 = ref array[0];
				reference25 = new PointF(rectangleF_0.Width * 0.17f + rectangleF_0.X, num15 + rectangleF_0.Y);
				ref PointF reference26 = ref array[1];
				reference26 = new PointF(rectangleF_0.X + num, rectangleF_0.Y);
				ref PointF reference27 = ref array[2];
				reference27 = new PointF(0.42f * rectangleF_0.Width + rectangleF_0.X, num15 + rectangleF_0.Y);
				rect10.Y += num15;
				graphicsPath.AddArc(rect10, 180f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect10.X = rectangleF_0.Right - num3;
				graphicsPath.AddArc(rect10, 270f, 90f);
				rect10.Y = rectangleF_0.Bottom - num3 + num15;
				graphicsPath.AddArc(rect10, 0f, 90f);
				rect10.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect10, 90f, 90f);
			}
		}
		else if (num7 > 270f && num7 < 270f + num6)
		{
			if (num > rectangleF_0.Width)
			{
				RectangleF rect11 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
				float num16 = num2;
				ref PointF reference28 = ref array[0];
				reference28 = new PointF(0.58f * rectangleF_0.Width + rectangleF_0.X, num16 + rectangleF_0.Y);
				ref PointF reference29 = ref array[1];
				reference29 = new PointF(rectangleF_0.X + num, rectangleF_0.Y);
				ref PointF reference30 = ref array[2];
				reference30 = new PointF(0.83f * rectangleF_0.Width + rectangleF_0.X, num16 + rectangleF_0.Y);
				rect11.Y += num16;
				graphicsPath.AddArc(rect11, 180f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect11.X = rectangleF_0.Right - num3;
				graphicsPath.AddArc(rect11, 270f, 90f);
				rect11.Y = rectangleF_0.Bottom - num3 + num16;
				graphicsPath.AddArc(rect11, 0f, 90f);
				rect11.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect11, 90f, 90f);
			}
			else
			{
				RectangleF rect12 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
				float num17 = num2;
				ref PointF reference31 = ref array[0];
				reference31 = new PointF(0.58f * rectangleF_0.Width + rectangleF_0.X, num17 + rectangleF_0.Y);
				ref PointF reference32 = ref array[1];
				reference32 = new PointF(rectangleF_0.X + num, rectangleF_0.Y);
				ref PointF reference33 = ref array[2];
				reference33 = new PointF(0.83f * rectangleF_0.Width + rectangleF_0.X, num17 + rectangleF_0.Y);
				rect12.Y += num17;
				graphicsPath.AddArc(rect12, 180f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect12.X = rectangleF_0.Right - num3;
				graphicsPath.AddArc(rect12, 270f, 90f);
				rect12.Y = rectangleF_0.Bottom - num3 + num17;
				graphicsPath.AddArc(rect12, 0f, 90f);
				rect12.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect12, 90f, 90f);
			}
		}
		else if (num7 > 270f + num6 && num7 < 360f)
		{
			if (num5 < 0f)
			{
				RectangleF rect13 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
				_ = rectangleF_0.Width;
				float num18 = num2;
				ref PointF reference34 = ref array[0];
				reference34 = new PointF(rectangleF_0.Width + rectangleF_0.X, num18 + rectangleF_0.Height * 0.17f + rectangleF_0.Y);
				ref PointF reference35 = ref array[1];
				reference35 = new PointF(rectangleF_0.X + num, rectangleF_0.Y);
				ref PointF reference36 = ref array[2];
				reference36 = new PointF(rectangleF_0.Width + rectangleF_0.X, 0.42f * rectangleF_0.Height + num18 + rectangleF_0.Y);
				rect13.Y += num18;
				graphicsPath.AddArc(rect13, 180f, 90f);
				rect13.X = rectangleF_0.Right - num3;
				graphicsPath.AddArc(rect13, 270f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect13.Y = rectangleF_0.Bottom - num3 + num18;
				graphicsPath.AddArc(rect13, 0f, 90f);
				rect13.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect13, 90f, 90f);
			}
			else
			{
				RectangleF rect14 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
				_ = rectangleF_0.Width;
				ref PointF reference37 = ref array[0];
				reference37 = new PointF(rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height * 0.17f + rectangleF_0.Y);
				ref PointF reference38 = ref array[1];
				reference38 = new PointF(rectangleF_0.X + num, rectangleF_0.Y + num2);
				ref PointF reference39 = ref array[2];
				reference39 = new PointF(rectangleF_0.Width + rectangleF_0.X, 0.42f * rectangleF_0.Height + rectangleF_0.Y);
				graphicsPath.AddArc(rect14, 180f, 90f);
				rect14.X = rectangleF_0.Right - num3;
				graphicsPath.AddArc(rect14, 270f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect14.Y = rectangleF_0.Bottom - num3;
				graphicsPath.AddArc(rect14, 0f, 90f);
				rect14.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect14, 90f, 90f);
			}
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	internal override void vmethod_4()
	{
		interface42_0.ResetTransform();
		float num = 0f;
		float num2 = 0f;
		float num3 = 1111f;
		float num4 = 26041f;
		ArrayList arrayList_ = class898_0.class885_0.arrayList_0;
		if (arrayList_.Count > 0)
		{
			foreach (Class882 item in arrayList_)
			{
				if (item.method_0() == 327)
				{
					num3 = Convert.ToSingle(item.Value);
				}
				if (item.method_0() == 328)
				{
					num4 = Convert.ToSingle(item.Value);
				}
			}
			num = Math.Abs(class898_0.Width * (num3 / 21600f));
			num2 = Math.Abs(class898_0.Height * (num4 / 21600f));
		}
		else
		{
			num3 = 1111f;
			num4 = 26041f;
			num = class898_0.Width * Math.Abs(num3 / 21600f);
			num2 = class898_0.Height * Math.Abs(num4 / 21600f);
		}
		float num5 = (float)(Math.Atan(class898_0.Width / class898_0.Height) * 180.0 / Math.PI);
		float num6 = 0f;
		num6 = ((num3 > 0f && num4 > 0f) ? ((num < class898_0.Width / 2f && num2 > class898_0.Height) ? (90f + (float)(Math.Atan((class898_0.Width / 2f - num) / (num2 - class898_0.Height / 2f)) * 180.0 / Math.PI)) : ((!(num > class898_0.Width) || !(num2 < class898_0.Height / 2f)) ? ((float)(Math.Atan(num2 / num) * 180.0 / Math.PI)) : (360f - (float)(Math.Atan((class898_0.Height / 2f + num2) / (num - class898_0.Width / 2f)) * 180.0 / Math.PI)))) : ((num3 < 0f && num4 > 0f) ? ((!(num2 > class898_0.Height / 2f)) ? (180f + (float)(Math.Atan((class898_0.Height / 2f - num2) / (num + class898_0.Width / 2f)) * 180.0 / Math.PI)) : (90f + (float)(Math.Atan((class898_0.Width / 2f + num) / (num2 - class898_0.Height / 2f)) * 180.0 / Math.PI))) : ((num3 < 0f && num4 < 0f) ? (180f + (float)(Math.Atan((class898_0.Height / 2f + num2) / (num + class898_0.Width / 2f)) * 180.0 / Math.PI)) : ((!(num > class898_0.Width / 2f)) ? (180f + (float)(Math.Atan((class898_0.Height / 2f + num2) / (class898_0.Width / 2f - num)) * 180.0 / Math.PI)) : (360f - (float)(Math.Atan((class898_0.Height / 2f + num2) / (num - class898_0.Width / 2f)) * 180.0 / Math.PI))))));
		RectangleF rectangleF = default(RectangleF);
		if (num6 > 0f && num6 < 90f - num5)
		{
			rectangleF = class898_0.method_7();
		}
		else if (num6 > 90f - num5 && num6 < 90f)
		{
			rectangleF = class898_0.method_7();
		}
		else if (num6 > 90f && num6 < 90f + num5)
		{
			if (num3 < 0f)
			{
				float num7 = num;
				rectangleF = new RectangleF(class898_0.X + num7, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height);
			}
			else
			{
				rectangleF = class898_0.method_7();
			}
		}
		else if (num6 > 90f + num5 && num6 < 180f)
		{
			float num8 = num;
			rectangleF = new RectangleF(class898_0.X + num8, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height);
		}
		else if (num6 > 180f && num6 < 180f + (90f - num5))
		{
			if (num4 < 0f)
			{
				float num9 = num;
				float num10 = num2;
				rectangleF = new RectangleF(class898_0.X + num9, class898_0.Y + num10, class898_0.method_7().Width, class898_0.method_7().Height);
			}
			else
			{
				float num11 = num;
				rectangleF = new RectangleF(class898_0.X + num11, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height);
			}
		}
		else if (num6 > 180f + (90f - num5) && num6 < 270f)
		{
			if (num3 < 0f)
			{
				float num12 = num;
				float num13 = num2;
				rectangleF = new RectangleF(class898_0.X + num12, class898_0.Y + num13, class898_0.method_7().Width, class898_0.method_7().Height);
			}
			else
			{
				float num14 = num2;
				rectangleF = new RectangleF(class898_0.X, class898_0.Y + num14, class898_0.method_7().Width, class898_0.method_7().Height);
			}
		}
		else if (num6 > 270f && num6 < 270f + num5)
		{
			float num15 = num2;
			rectangleF = new RectangleF(class898_0.X, class898_0.Y + num15, class898_0.method_7().Width, class898_0.method_7().Height);
		}
		else if (num6 > 270f + num5 && num6 < 360f)
		{
			if (num4 < 0f)
			{
				float num16 = num2;
				rectangleF = new RectangleF(class898_0.X, class898_0.Y + num16, class898_0.method_7().Width, class898_0.method_7().Height);
			}
			else
			{
				rectangleF = class898_0.method_7();
			}
		}
		RectangleF rectangleF_ = rectangleF;
		if (!class898_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class898_0.Line.Weight / 2f, 0f - class898_0.Line.Weight / 2f);
		}
		float num17 = Struct69.smethod_12(class898_0.Font);
		if (class898_0.TextHorizontalAlignment != Enum104.const_7 && class898_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class898_0.TextHorizontalAlignment == Enum104.const_0 || class898_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num17;
			}
		}
		else
		{
			rectangleF_.X += num17;
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}
}
