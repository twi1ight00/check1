using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns5;

namespace ns6;

internal class Class249 : Class160
{
	internal Class249(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
		switch (class913_0.int_3)
		{
		case 2:
		{
			Matrix matrix_3 = new Matrix(1f, 0f, 0f, -1f, 0f, class913_0.method_25().Height);
			interface42_0.imethod_58(matrix_3);
			break;
		}
		case 3:
		{
			Matrix matrix_2 = new Matrix(-1f, 0f, 0f, -1f, class913_0.method_25().Width, class913_0.method_25().Height);
			interface42_0.imethod_58(matrix_2);
			break;
		}
		case 4:
		{
			Matrix matrix_ = new Matrix(-1f, 0f, 0f, 1f, class913_0.method_25().Width, 0f);
			interface42_0.imethod_58(matrix_);
			break;
		}
		case 1:
			break;
		}
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		PointF[] array = new PointF[7];
		float num5 = 2f * Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.15f;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]);
				num4 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]);
				num = rectangleF_0.Width / 2f + rectangleF_0.Width * Math.Abs(Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f);
				num2 = rectangleF_0.Height / 2f + rectangleF_0.Height * Math.Abs(Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f);
			}
			else
			{
				num3 = -20473f;
				num4 = 61957f;
				num = rectangleF_0.Width / 2f + rectangleF_0.Width * Math.Abs(-0.20473f);
				num2 = rectangleF_0.Height / 2f + rectangleF_0.Height * Math.Abs(0.61957f);
			}
			if (num <= rectangleF_0.Width && num2 <= rectangleF_0.Height)
			{
				RectangleF rect = new RectangleF(size: new SizeF(num5, num5), location: rectangleF_0.Location);
				graphicsPath.AddArc(rect, 180f, 90f);
				rect.X = rectangleF_0.Right - num5;
				graphicsPath.AddArc(rect, 270f, 90f);
				rect.Y = rectangleF_0.Bottom - num5;
				graphicsPath.AddArc(rect, 0f, 90f);
				rect.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect, 90f, 90f);
				graphicsPath.CloseFigure();
				return graphicsPath;
			}
		}
		else
		{
			num3 = -20473f;
			num4 = 61957f;
			num = rectangleF_0.Width / 2f + rectangleF_0.Width * Math.Abs(-0.20473f);
			num2 = rectangleF_0.Height / 2f + rectangleF_0.Height * Math.Abs(0.61957f);
		}
		float num6 = (float)(Math.Atan(rectangleF_0.Width / rectangleF_0.Height) * 180.0 / Math.PI);
		float num7 = 0f;
		num7 = ((num3 > 0f && num4 > 0f) ? ((float)(Math.Atan(num2 / num) * 180.0 / Math.PI)) : ((num3 < 0f && num4 > 0f) ? (180f - (float)(Math.Atan(num2 / num) * 180.0 / Math.PI)) : ((!(num3 < 0f) || !(num4 < 0f)) ? (360f - (float)(Math.Atan(num2 / num) * 180.0 / Math.PI)) : (180f + (float)(Math.Atan(num2 / num) * 180.0 / Math.PI)))));
		if (num7 > 0f && num7 < 90f - num6)
		{
			RectangleF rect2 = new RectangleF(size: new SizeF(num5, num5), location: rectangleF_0.Location);
			ref PointF reference = ref array[0];
			reference = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height * 0.58f);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.X + num, rectangleF_0.Y + num2);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height * 0.83f);
			graphicsPath.AddArc(rect2, 180f, 90f);
			rect2.X = rectangleF_0.Right - num5;
			graphicsPath.AddArc(rect2, 270f, 90f);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			rect2.Y = rectangleF_0.Bottom - num5;
			graphicsPath.AddArc(rect2, 0f, 90f);
			rect2.X = rectangleF_0.Left;
			graphicsPath.AddArc(rect2, 90f, 90f);
		}
		else if (num7 > 90f - num6 && num7 < 90f)
		{
			RectangleF rect3 = new RectangleF(size: new SizeF(num5, num5), location: rectangleF_0.Location);
			ref PointF reference4 = ref array[0];
			reference4 = new PointF(rectangleF_0.X + rectangleF_0.Width * 0.83f, rectangleF_0.Y + rectangleF_0.Height);
			ref PointF reference5 = ref array[1];
			reference5 = new PointF(rectangleF_0.X + num, rectangleF_0.Y + num2);
			ref PointF reference6 = ref array[2];
			reference6 = new PointF(rectangleF_0.X + rectangleF_0.Width * 0.58f, rectangleF_0.Y + rectangleF_0.Height);
			graphicsPath.AddArc(rect3, 180f, 90f);
			rect3.X = rectangleF_0.Right - num5;
			graphicsPath.AddArc(rect3, 270f, 90f);
			rect3.Y = rectangleF_0.Bottom - num5;
			graphicsPath.AddArc(rect3, 0f, 90f);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			rect3.X = rectangleF_0.Left;
			graphicsPath.AddArc(rect3, 90f, 90f);
		}
		else if (num7 > 90f && num7 < 90f + num6)
		{
			if (num > rectangleF_0.Width)
			{
				SizeF size4 = new SizeF(num5, num5);
				float num8 = num - rectangleF_0.Width;
				RectangleF rect4 = new RectangleF(rectangleF_0.Location, size4);
				ref PointF reference7 = ref array[0];
				reference7 = new PointF(num8 + 0.42f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference8 = ref array[1];
				reference8 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
				ref PointF reference9 = ref array[2];
				reference9 = new PointF(num8 + 0.17f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				rect4.X += num8;
				graphicsPath.AddArc(rect4, 180f, 90f);
				rect4.X = rectangleF_0.Right - num5 + num8;
				graphicsPath.AddArc(rect4, 270f, 90f);
				rect4.Y = rectangleF_0.Bottom - num5;
				graphicsPath.AddArc(rect4, 0f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect4.X = rectangleF_0.Left + num8;
				graphicsPath.AddArc(rect4, 90f, 90f);
			}
			else
			{
				RectangleF rect5 = new RectangleF(size: new SizeF(num5, num5), location: rectangleF_0.Location);
				ref PointF reference10 = ref array[0];
				reference10 = new PointF(0.42f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference11 = ref array[1];
				reference11 = new PointF(rectangleF_0.X + rectangleF_0.Width - num, num2 + rectangleF_0.Y);
				ref PointF reference12 = ref array[2];
				reference12 = new PointF(0.17f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				graphicsPath.AddArc(rect5, 180f, 90f);
				rect5.X = rectangleF_0.Right - num5;
				graphicsPath.AddArc(rect5, 270f, 90f);
				rect5.Y = rectangleF_0.Bottom - num5;
				graphicsPath.AddArc(rect5, 0f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect5.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect5, 90f, 90f);
			}
		}
		else if (num7 > 90f + num6 && num7 < 180f)
		{
			RectangleF rect6 = new RectangleF(size: new SizeF(num5, num5), location: rectangleF_0.Location);
			float num9 = num - rectangleF_0.Width;
			ref PointF reference13 = ref array[0];
			reference13 = new PointF(num9 + rectangleF_0.X, rectangleF_0.Height * 0.83f + rectangleF_0.Y);
			ref PointF reference14 = ref array[1];
			reference14 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
			ref PointF reference15 = ref array[2];
			reference15 = new PointF(num9 + rectangleF_0.X, rectangleF_0.Height * 0.58f + rectangleF_0.Y);
			rect6.X += num9;
			graphicsPath.AddArc(rect6, 180f, 90f);
			rect6.X = rectangleF_0.Right - num5 + num9;
			graphicsPath.AddArc(rect6, 270f, 90f);
			rect6.Y = rectangleF_0.Bottom - num5;
			graphicsPath.AddArc(rect6, 0f, 90f);
			rect6.X = rectangleF_0.Left + num9;
			graphicsPath.AddArc(rect6, 90f, 90f);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
		}
		else if (num7 > 180f && num7 < 180f + (90f - num6))
		{
			if (num2 > rectangleF_0.Height)
			{
				RectangleF rect7 = new RectangleF(size: new SizeF(num5, num5), location: rectangleF_0.Location);
				float num10 = num - rectangleF_0.Width;
				float num11 = num2 - rectangleF_0.Height;
				ref PointF reference16 = ref array[0];
				reference16 = new PointF(num10 + rectangleF_0.X, rectangleF_0.Height * 0.42f + num11 + rectangleF_0.Y);
				ref PointF reference17 = ref array[1];
				reference17 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference18 = ref array[2];
				reference18 = new PointF(num10 + rectangleF_0.X, rectangleF_0.Height * 0.17f + num11 + rectangleF_0.Y);
				rect7.X += num10;
				rect7.Y += num11;
				graphicsPath.AddArc(rect7, 180f, 90f);
				rect7.X = rectangleF_0.Right - num5 + num10;
				graphicsPath.AddArc(rect7, 270f, 90f);
				rect7.Y = rectangleF_0.Bottom - num5 + num11;
				graphicsPath.AddArc(rect7, 0f, 90f);
				rect7.X = rectangleF_0.Left + num10;
				graphicsPath.AddArc(rect7, 90f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
			}
			else
			{
				RectangleF rect8 = new RectangleF(size: new SizeF(num5, num5), location: rectangleF_0.Location);
				float num12 = num - rectangleF_0.Width;
				ref PointF reference19 = ref array[0];
				reference19 = new PointF(num12 + rectangleF_0.X, rectangleF_0.Height * 0.42f + rectangleF_0.Y);
				ref PointF reference20 = ref array[1];
				reference20 = new PointF(rectangleF_0.X, rectangleF_0.Height - num2 + rectangleF_0.Y);
				ref PointF reference21 = ref array[2];
				reference21 = new PointF(num12 + rectangleF_0.X, rectangleF_0.Height * 0.17f + rectangleF_0.Y);
				rect8.X += num12;
				graphicsPath.AddArc(rect8, 180f, 90f);
				rect8.X = rectangleF_0.Right - num5 + num12;
				graphicsPath.AddArc(rect8, 270f, 90f);
				rect8.Y = rectangleF_0.Bottom - num5;
				graphicsPath.AddArc(rect8, 0f, 90f);
				rect8.X = rectangleF_0.Left + num12;
				graphicsPath.AddArc(rect8, 90f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
			}
		}
		else if (num7 > 180f + (90f - num6) && num7 < 270f)
		{
			if (num > rectangleF_0.Width)
			{
				RectangleF rect9 = new RectangleF(size: new SizeF(num5, num5), location: rectangleF_0.Location);
				float num13 = num - rectangleF_0.Width;
				float num14 = num2 - rectangleF_0.Height;
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
				rect9.X = rectangleF_0.Right - num5 + num13;
				graphicsPath.AddArc(rect9, 270f, 90f);
				rect9.Y = rectangleF_0.Bottom - num5 + num14;
				graphicsPath.AddArc(rect9, 0f, 90f);
				rect9.X = rectangleF_0.Left + num13;
				graphicsPath.AddArc(rect9, 90f, 90f);
			}
			else
			{
				RectangleF rect10 = new RectangleF(size: new SizeF(num5, num5), location: rectangleF_0.Location);
				float num15 = num2 - rectangleF_0.Height;
				ref PointF reference25 = ref array[0];
				reference25 = new PointF(rectangleF_0.Width * 0.17f + rectangleF_0.X, num15 + rectangleF_0.Y);
				ref PointF reference26 = ref array[1];
				reference26 = new PointF(rectangleF_0.X + rectangleF_0.Width - num, rectangleF_0.Y);
				ref PointF reference27 = ref array[2];
				reference27 = new PointF(0.42f * rectangleF_0.Width + rectangleF_0.X, num15 + rectangleF_0.Y);
				rect10.Y += num15;
				graphicsPath.AddArc(rect10, 180f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect10.X = rectangleF_0.Right - num5;
				graphicsPath.AddArc(rect10, 270f, 90f);
				rect10.Y = rectangleF_0.Bottom - num5 + num15;
				graphicsPath.AddArc(rect10, 0f, 90f);
				rect10.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect10, 90f, 90f);
			}
		}
		else if (num7 > 270f && num7 < 270f + num6)
		{
			RectangleF rect11 = new RectangleF(size: new SizeF(num5, num5), location: rectangleF_0.Location);
			float num16 = num2 - rectangleF_0.Height;
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
			rect11.X = rectangleF_0.Right - num5;
			graphicsPath.AddArc(rect11, 270f, 90f);
			rect11.Y = rectangleF_0.Bottom - num5 + num16;
			graphicsPath.AddArc(rect11, 0f, 90f);
			rect11.X = rectangleF_0.Left;
			graphicsPath.AddArc(rect11, 90f, 90f);
		}
		else if (num7 > 270f + num6 && num7 < 360f)
		{
			if (num2 > rectangleF_0.Height)
			{
				RectangleF rect12 = new RectangleF(size: new SizeF(num5, num5), location: rectangleF_0.Location);
				_ = rectangleF_0.Width;
				float num17 = num2 - rectangleF_0.Height;
				ref PointF reference31 = ref array[0];
				reference31 = new PointF(rectangleF_0.Width + rectangleF_0.X, num17 + rectangleF_0.Height * 0.17f + rectangleF_0.Y);
				ref PointF reference32 = ref array[1];
				reference32 = new PointF(rectangleF_0.X + num, rectangleF_0.Y);
				ref PointF reference33 = ref array[2];
				reference33 = new PointF(rectangleF_0.Width + rectangleF_0.X, 0.42f * rectangleF_0.Height + num17 + rectangleF_0.Y);
				rect12.Y += num17;
				graphicsPath.AddArc(rect12, 180f, 90f);
				rect12.X = rectangleF_0.Right - num5;
				graphicsPath.AddArc(rect12, 270f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect12.Y = rectangleF_0.Bottom - num5 + num17;
				graphicsPath.AddArc(rect12, 0f, 90f);
				rect12.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect12, 90f, 90f);
			}
			else
			{
				RectangleF rect13 = new RectangleF(size: new SizeF(num5, num5), location: rectangleF_0.Location);
				_ = rectangleF_0.Width;
				ref PointF reference34 = ref array[0];
				reference34 = new PointF(rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height * 0.17f + rectangleF_0.Y);
				ref PointF reference35 = ref array[1];
				reference35 = new PointF(rectangleF_0.X + num, rectangleF_0.Y + rectangleF_0.Height - num2);
				ref PointF reference36 = ref array[2];
				reference36 = new PointF(rectangleF_0.Width + rectangleF_0.X, 0.42f * rectangleF_0.Height + rectangleF_0.Y);
				graphicsPath.AddArc(rect13, 180f, 90f);
				rect13.X = rectangleF_0.Right - num5;
				graphicsPath.AddArc(rect13, 270f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect13.Y = rectangleF_0.Bottom - num5;
				graphicsPath.AddArc(rect13, 0f, 90f);
				rect13.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect13, 90f, 90f);
			}
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	internal override void vmethod_4()
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		if (class913_0.class901_0 != null)
		{
			num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]);
			num4 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]);
			num = class913_0.Width / 2f + class913_0.Width * Math.Abs(Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f);
			num2 = class913_0.Height / 2f + class913_0.Height * Math.Abs(Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f);
		}
		else
		{
			num3 = -20473f;
			num4 = 61957f;
			num = class913_0.Width / 2f + class913_0.Width * Math.Abs(-0.20473f);
			num2 = class913_0.Height / 2f + class913_0.Height * Math.Abs(0.61957f);
		}
		float num5 = (float)(Math.Atan(class913_0.Width / class913_0.Height) * 180.0 / Math.PI);
		float num6 = 0f;
		num6 = ((num3 > 0f && num4 > 0f) ? ((float)(Math.Atan(num2 / num) * 180.0 / Math.PI)) : ((num3 < 0f && num4 > 0f) ? (180f - (float)(Math.Atan(num2 / num) * 180.0 / Math.PI)) : ((!(num3 < 0f) || !(num4 < 0f)) ? (360f - (float)(Math.Atan(num2 / num) * 180.0 / Math.PI)) : (180f + (float)(Math.Atan(num2 / num) * 180.0 / Math.PI)))));
		RectangleF rectangleF = default(RectangleF);
		if (num6 > 0f && num6 < 90f - num5)
		{
			rectangleF = class913_0.method_8();
		}
		else if (num6 > 90f - num5 && num6 < 90f)
		{
			rectangleF = class913_0.method_8();
		}
		else if (num6 > 90f && num6 < 90f + num5)
		{
			if (num > class913_0.Width)
			{
				float num7 = num - class913_0.Width;
				rectangleF = new RectangleF(class913_0.X + num7, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height);
			}
			else
			{
				rectangleF = class913_0.method_8();
			}
		}
		else if (num6 > 90f + num5 && num6 < 180f)
		{
			float num8 = num - class913_0.Width;
			rectangleF = new RectangleF(class913_0.X + num8, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height);
		}
		else if (num6 > 180f && num6 < 180f + (90f - num5))
		{
			if (num2 > class913_0.Height)
			{
				float num9 = num - class913_0.Width;
				float num10 = num2 - class913_0.Height;
				rectangleF = new RectangleF(class913_0.X + num9, class913_0.Y + num10, class913_0.method_8().Width, class913_0.method_8().Height);
			}
			else
			{
				float num11 = num - class913_0.Width;
				rectangleF = new RectangleF(class913_0.X + num11, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height);
			}
		}
		else if (num6 > 180f + (90f - num5) && num6 < 270f)
		{
			if (num > class913_0.Width)
			{
				float num12 = num - class913_0.Width;
				float num13 = num2 - class913_0.Height;
				rectangleF = new RectangleF(class913_0.X + num12, class913_0.Y + num13, class913_0.method_8().Width, class913_0.method_8().Height);
			}
			else
			{
				float num14 = num2 - class913_0.Height;
				rectangleF = new RectangleF(class913_0.X, class913_0.Y + num14, class913_0.method_8().Width, class913_0.method_8().Height);
			}
		}
		else if (num6 > 270f && num6 < 270f + num5)
		{
			float num15 = num2 - class913_0.Height;
			rectangleF = new RectangleF(class913_0.X, class913_0.Y + num15, class913_0.method_8().Width, class913_0.method_8().Height);
		}
		else if (num6 > 270f + num5 && num6 < 360f)
		{
			if (num2 > class913_0.Height)
			{
				_ = class913_0.Width;
				float num16 = num2 - class913_0.Height;
				rectangleF = new RectangleF(class913_0.X, class913_0.Y + num16, class913_0.method_8().Width, class913_0.method_8().Height);
			}
			else
			{
				_ = class913_0.Width;
				rectangleF = class913_0.method_8();
			}
		}
		RectangleF rectangleF_ = rectangleF;
		if (!class913_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class913_0.Line.Weight / 2f, 0f - class913_0.Line.Weight / 2f);
		}
		float num17 = Struct72.smethod_9(class913_0.Font);
		if (class913_0.TextHorizontalAlignment != Enum104.const_7 && class913_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class913_0.TextHorizontalAlignment == Enum104.const_0 || class913_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num17;
			}
		}
		else
		{
			rectangleF_.X += num17;
		}
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
	}
}
