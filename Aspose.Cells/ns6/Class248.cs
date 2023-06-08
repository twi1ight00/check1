using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns5;

namespace ns6;

internal class Class248 : Class160
{
	internal Class248(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]);
				num4 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]);
				num = rectangleF_0.Width / 2f + rectangleF_0.Width * Math.Abs(Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f);
				num2 = rectangleF_0.Height / 2f + rectangleF_0.Height * Math.Abs(Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f);
				if (num <= rectangleF_0.Width && num2 <= rectangleF_0.Height)
				{
					graphicsPath.AddRectangle(rectangleF_0);
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
		}
		else
		{
			num3 = -20473f;
			num4 = 61957f;
			num = rectangleF_0.Width / 2f + rectangleF_0.Width * Math.Abs(-0.20473f);
			num2 = rectangleF_0.Height / 2f + rectangleF_0.Height * Math.Abs(0.61957f);
		}
		float num5 = (float)(Math.Atan(rectangleF_0.Width / rectangleF_0.Height) * 180.0 / Math.PI);
		float num6 = 0f;
		num6 = ((num3 > 0f && num4 > 0f) ? ((float)(Math.Atan(num2 / num) * 180.0 / Math.PI)) : ((num3 < 0f && num4 > 0f) ? (180f - (float)(Math.Atan(num2 / num) * 180.0 / Math.PI)) : ((!(num3 < 0f) || !(num4 < 0f)) ? (360f - (float)(Math.Atan(num2 / num) * 180.0 / Math.PI)) : (180f + (float)(Math.Atan(num2 / num) * 180.0 / Math.PI)))));
		if (num6 > 0f && num6 < 90f - num5)
		{
			ref PointF reference = ref array[0];
			reference = new PointF(rectangleF_0.X + num, rectangleF_0.Y + num2);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height * 0.83f);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(rectangleF_0.X, rectangleF_0.Y);
			ref PointF reference6 = ref array[5];
			reference6 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y);
			ref PointF reference7 = ref array[6];
			reference7 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height * 0.58f);
		}
		else if (num6 > 90f - num5 && num6 < 90f)
		{
			ref PointF reference8 = ref array[0];
			reference8 = new PointF(rectangleF_0.X + num, rectangleF_0.Y + num2);
			ref PointF reference9 = ref array[1];
			reference9 = new PointF(rectangleF_0.X + rectangleF_0.Width * 0.58f, rectangleF_0.Y + rectangleF_0.Height);
			ref PointF reference10 = ref array[2];
			reference10 = new PointF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height);
			ref PointF reference11 = ref array[3];
			reference11 = new PointF(rectangleF_0.X, rectangleF_0.Y);
			ref PointF reference12 = ref array[4];
			reference12 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y);
			ref PointF reference13 = ref array[5];
			reference13 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height);
			ref PointF reference14 = ref array[6];
			reference14 = new PointF(rectangleF_0.X + rectangleF_0.Width * 0.83f, rectangleF_0.Y + rectangleF_0.Height);
		}
		else if (num6 > 90f && num6 < 90f + num5)
		{
			if (num > rectangleF_0.Width)
			{
				float num7 = num - rectangleF_0.Width;
				ref PointF reference15 = ref array[0];
				reference15 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
				ref PointF reference16 = ref array[1];
				reference16 = new PointF(num7 + 0.17f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference17 = ref array[2];
				reference17 = new PointF(num7 + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference18 = ref array[3];
				reference18 = new PointF(num7 + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference19 = ref array[4];
				reference19 = new PointF(num + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference20 = ref array[5];
				reference20 = new PointF(num + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference21 = ref array[6];
				reference21 = new PointF(num7 + 0.42f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
			}
			else
			{
				ref PointF reference22 = ref array[0];
				reference22 = new PointF(rectangleF_0.X + rectangleF_0.Width - num, num2 + rectangleF_0.Y);
				ref PointF reference23 = ref array[1];
				reference23 = new PointF(0.17f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference24 = ref array[2];
				reference24 = new PointF(rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference25 = ref array[3];
				reference25 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference26 = ref array[4];
				reference26 = new PointF(rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference27 = ref array[5];
				reference27 = new PointF(rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference28 = ref array[6];
				reference28 = new PointF(0.42f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
			}
		}
		else if (num6 > 90f + num5 && num6 < 180f)
		{
			float num8 = num - rectangleF_0.Width;
			ref PointF reference29 = ref array[0];
			reference29 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
			ref PointF reference30 = ref array[1];
			reference30 = new PointF(num8 + rectangleF_0.X, rectangleF_0.Height * 0.58f + rectangleF_0.Y);
			ref PointF reference31 = ref array[2];
			reference31 = new PointF(num8 + rectangleF_0.X, rectangleF_0.Y);
			ref PointF reference32 = ref array[3];
			reference32 = new PointF(num + rectangleF_0.X, rectangleF_0.Y);
			ref PointF reference33 = ref array[4];
			reference33 = new PointF(num + rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height);
			ref PointF reference34 = ref array[5];
			reference34 = new PointF(num8 + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
			ref PointF reference35 = ref array[6];
			reference35 = new PointF(num8 + rectangleF_0.X, rectangleF_0.Height * 0.83f + rectangleF_0.Y);
		}
		else if (num6 > 180f && num6 < 180f + (90f - num5))
		{
			if (num2 > rectangleF_0.Height)
			{
				float num9 = num - rectangleF_0.Width;
				float num10 = num2 - rectangleF_0.Height;
				ref PointF reference36 = ref array[0];
				reference36 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference37 = ref array[1];
				reference37 = new PointF(num9 + rectangleF_0.X, rectangleF_0.Height * 0.17f + num10 + rectangleF_0.Y);
				ref PointF reference38 = ref array[2];
				reference38 = new PointF(num9 + rectangleF_0.X, num10 + rectangleF_0.Y);
				ref PointF reference39 = ref array[3];
				reference39 = new PointF(num + rectangleF_0.X, num10 + rectangleF_0.Y);
				ref PointF reference40 = ref array[4];
				reference40 = new PointF(num + rectangleF_0.X, rectangleF_0.Y + num2);
				ref PointF reference41 = ref array[5];
				reference41 = new PointF(num9 + rectangleF_0.X, num2 + rectangleF_0.Y);
				ref PointF reference42 = ref array[6];
				reference42 = new PointF(num9 + rectangleF_0.X, rectangleF_0.Height * 0.42f + num10 + rectangleF_0.Y);
			}
			else
			{
				float num11 = num - rectangleF_0.Width;
				ref PointF reference43 = ref array[0];
				reference43 = new PointF(rectangleF_0.X, rectangleF_0.Height - num2 + rectangleF_0.Y);
				ref PointF reference44 = ref array[1];
				reference44 = new PointF(num11 + rectangleF_0.X, rectangleF_0.Height * 0.17f + rectangleF_0.Y);
				ref PointF reference45 = ref array[2];
				reference45 = new PointF(num11 + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference46 = ref array[3];
				reference46 = new PointF(num + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference47 = ref array[4];
				reference47 = new PointF(num + rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height);
				ref PointF reference48 = ref array[5];
				reference48 = new PointF(num11 + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference49 = ref array[6];
				reference49 = new PointF(num11 + rectangleF_0.X, rectangleF_0.Height * 0.42f + rectangleF_0.Y);
			}
		}
		else if (num6 > 180f + (90f - num5) && num6 < 270f)
		{
			if (num > rectangleF_0.Width)
			{
				float num12 = num - rectangleF_0.Width;
				float num13 = num2 - rectangleF_0.Height;
				ref PointF reference50 = ref array[0];
				reference50 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference51 = ref array[1];
				reference51 = new PointF(num12 + 0.42f * rectangleF_0.Width + rectangleF_0.X, num13 + rectangleF_0.Y);
				ref PointF reference52 = ref array[2];
				reference52 = new PointF(num + rectangleF_0.X, num13 + rectangleF_0.Y);
				ref PointF reference53 = ref array[3];
				reference53 = new PointF(num + rectangleF_0.X, num2 + rectangleF_0.Y);
				ref PointF reference54 = ref array[4];
				reference54 = new PointF(num12 + rectangleF_0.X, rectangleF_0.Y + num2);
				ref PointF reference55 = ref array[5];
				reference55 = new PointF(num12 + rectangleF_0.X, num13 + rectangleF_0.Y);
				ref PointF reference56 = ref array[6];
				reference56 = new PointF(num12 + 0.17f * rectangleF_0.Width + rectangleF_0.X, num13 + rectangleF_0.Y);
			}
			else
			{
				float num14 = num2 - rectangleF_0.Height;
				ref PointF reference57 = ref array[0];
				reference57 = new PointF(rectangleF_0.X + rectangleF_0.Width - num, rectangleF_0.Y);
				ref PointF reference58 = ref array[1];
				reference58 = new PointF(0.42f * rectangleF_0.Width + rectangleF_0.X, num14 + rectangleF_0.Y);
				ref PointF reference59 = ref array[2];
				reference59 = new PointF(rectangleF_0.Width + rectangleF_0.X, num14 + rectangleF_0.Y);
				ref PointF reference60 = ref array[3];
				reference60 = new PointF(rectangleF_0.Width + rectangleF_0.X, num2 + rectangleF_0.Y);
				ref PointF reference61 = ref array[4];
				reference61 = new PointF(rectangleF_0.X, rectangleF_0.Y + num2);
				ref PointF reference62 = ref array[5];
				reference62 = new PointF(rectangleF_0.X, num14 + rectangleF_0.Y);
				ref PointF reference63 = ref array[6];
				reference63 = new PointF(rectangleF_0.Width * 0.17f + rectangleF_0.X, num14 + rectangleF_0.Y);
			}
		}
		else if (num6 > 270f && num6 < 270f + num5)
		{
			float num15 = num2 - rectangleF_0.Height;
			ref PointF reference64 = ref array[0];
			reference64 = new PointF(rectangleF_0.X + num, rectangleF_0.Y);
			ref PointF reference65 = ref array[1];
			reference65 = new PointF(0.83f * rectangleF_0.Width + rectangleF_0.X, num15 + rectangleF_0.Y);
			ref PointF reference66 = ref array[2];
			reference66 = new PointF(rectangleF_0.Width + rectangleF_0.X, num15 + rectangleF_0.Y);
			ref PointF reference67 = ref array[3];
			reference67 = new PointF(rectangleF_0.Width + rectangleF_0.X, num2 + rectangleF_0.Y);
			ref PointF reference68 = ref array[4];
			reference68 = new PointF(rectangleF_0.X, rectangleF_0.Y + num2);
			ref PointF reference69 = ref array[5];
			reference69 = new PointF(rectangleF_0.X, num15 + rectangleF_0.Y);
			ref PointF reference70 = ref array[6];
			reference70 = new PointF(0.58f * rectangleF_0.Width + rectangleF_0.X, num15 + rectangleF_0.Y);
		}
		else if (num6 > 270f + num5 && num6 < 360f)
		{
			if (num2 > rectangleF_0.Height)
			{
				_ = rectangleF_0.Width;
				float num16 = num2 - rectangleF_0.Height;
				ref PointF reference71 = ref array[0];
				reference71 = new PointF(rectangleF_0.X + num, rectangleF_0.Y);
				ref PointF reference72 = ref array[1];
				reference72 = new PointF(rectangleF_0.Width + rectangleF_0.X, 0.42f * rectangleF_0.Height + num16 + rectangleF_0.Y);
				ref PointF reference73 = ref array[2];
				reference73 = new PointF(rectangleF_0.Width + rectangleF_0.X, num2 + rectangleF_0.Y);
				ref PointF reference74 = ref array[3];
				reference74 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
				ref PointF reference75 = ref array[4];
				reference75 = new PointF(rectangleF_0.X, rectangleF_0.Y + num16);
				ref PointF reference76 = ref array[5];
				reference76 = new PointF(rectangleF_0.Width + rectangleF_0.X, num16 + rectangleF_0.Y);
				ref PointF reference77 = ref array[6];
				reference77 = new PointF(rectangleF_0.Width + rectangleF_0.X, num16 + rectangleF_0.Height * 0.17f + rectangleF_0.Y);
			}
			else
			{
				_ = rectangleF_0.Width;
				ref PointF reference78 = ref array[0];
				reference78 = new PointF(rectangleF_0.X + num, rectangleF_0.Y + rectangleF_0.Height - num2);
				ref PointF reference79 = ref array[1];
				reference79 = new PointF(rectangleF_0.Width + rectangleF_0.X, 0.42f * rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference80 = ref array[2];
				reference80 = new PointF(rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference81 = ref array[3];
				reference81 = new PointF(rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference82 = ref array[4];
				reference82 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference83 = ref array[5];
				reference83 = new PointF(rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference84 = ref array[6];
				reference84 = new PointF(rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height * 0.17f + rectangleF_0.Y);
			}
		}
		graphicsPath.AddPolygon(array);
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
