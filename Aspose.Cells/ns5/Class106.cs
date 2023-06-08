using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class106 : Class18
{
	internal Class106(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = 0f;
		float num2 = 0f;
		PointF[] array = new PointF[7];
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
			num = Math.Abs(rectangleF_0.Width * (num3 / 21600f));
			num2 = Math.Abs(rectangleF_0.Height * (num4 / 21600f));
			if (num3 > 0f && num4 > 0f && num <= rectangleF_0.Width && num2 <= rectangleF_0.Height)
			{
				graphicsPath.AddRectangle(rectangleF_0);
				return graphicsPath;
			}
		}
		else
		{
			num3 = 1111f;
			num4 = 26041f;
			num = rectangleF_0.Width * Math.Abs(num3 / 21600f);
			num2 = rectangleF_0.Height * Math.Abs(num4 / 21600f);
		}
		float num5 = (float)(Math.Atan(rectangleF_0.Width / rectangleF_0.Height) * 180.0 / Math.PI);
		float num6 = 0f;
		num6 = ((num3 > 0f && num4 > 0f) ? ((num < rectangleF_0.Width / 2f && num2 > rectangleF_0.Height) ? (90f + (float)(Math.Atan((rectangleF_0.Width / 2f - num) / (num2 - rectangleF_0.Height / 2f)) * 180.0 / Math.PI)) : ((!(num > rectangleF_0.Width) || !(num2 < rectangleF_0.Height / 2f)) ? ((float)(Math.Atan(num2 / num) * 180.0 / Math.PI)) : (360f - (float)(Math.Atan((rectangleF_0.Height / 2f + num2) / (num - rectangleF_0.Width / 2f)) * 180.0 / Math.PI)))) : ((num3 < 0f && num4 > 0f) ? ((!(num2 > rectangleF_0.Height / 2f)) ? (180f + (float)(Math.Atan((rectangleF_0.Height / 2f - num2) / (num + rectangleF_0.Width / 2f)) * 180.0 / Math.PI)) : (90f + (float)(Math.Atan((rectangleF_0.Width / 2f + num) / (num2 - rectangleF_0.Height / 2f)) * 180.0 / Math.PI))) : ((num3 < 0f && num4 < 0f) ? (180f + (float)(Math.Atan((rectangleF_0.Height / 2f + num2) / (num + rectangleF_0.Width / 2f)) * 180.0 / Math.PI)) : ((!(num > rectangleF_0.Width / 2f)) ? (180f + (float)(Math.Atan((rectangleF_0.Height / 2f + num2) / (rectangleF_0.Width / 2f - num)) * 180.0 / Math.PI)) : (360f - (float)(Math.Atan((rectangleF_0.Height / 2f + num2) / (num - rectangleF_0.Width / 2f)) * 180.0 / Math.PI))))));
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
			if (num3 < 0f)
			{
				float num7 = num;
				ref PointF reference15 = ref array[0];
				reference15 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
				ref PointF reference16 = ref array[1];
				reference16 = new PointF(num7 + 0.17f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference17 = ref array[2];
				reference17 = new PointF(num7 + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference18 = ref array[3];
				reference18 = new PointF(num7 + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference19 = ref array[4];
				reference19 = new PointF(num7 + rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference20 = ref array[5];
				reference20 = new PointF(num7 + rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference21 = ref array[6];
				reference21 = new PointF(num7 + 0.42f * rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
			}
			else
			{
				ref PointF reference22 = ref array[0];
				reference22 = new PointF(rectangleF_0.X + num, num2 + rectangleF_0.Y);
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
			float num8 = num;
			ref PointF reference29 = ref array[0];
			reference29 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
			ref PointF reference30 = ref array[1];
			reference30 = new PointF(num8 + rectangleF_0.X, rectangleF_0.Height * 0.58f + rectangleF_0.Y);
			ref PointF reference31 = ref array[2];
			reference31 = new PointF(num8 + rectangleF_0.X, rectangleF_0.Y);
			ref PointF reference32 = ref array[3];
			reference32 = new PointF(num8 + rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Y);
			ref PointF reference33 = ref array[4];
			reference33 = new PointF(num8 + rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height);
			ref PointF reference34 = ref array[5];
			reference34 = new PointF(num8 + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
			ref PointF reference35 = ref array[6];
			reference35 = new PointF(num8 + rectangleF_0.X, rectangleF_0.Height * 0.83f + rectangleF_0.Y);
		}
		else if (num6 > 180f && num6 < 180f + (90f - num5))
		{
			if (num4 < 0f)
			{
				float num9 = num;
				float num10 = num2;
				ref PointF reference36 = ref array[0];
				reference36 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference37 = ref array[1];
				reference37 = new PointF(num9 + rectangleF_0.X, rectangleF_0.Height * 0.17f + num10 + rectangleF_0.Y);
				ref PointF reference38 = ref array[2];
				reference38 = new PointF(num9 + rectangleF_0.X, num10 + rectangleF_0.Y);
				ref PointF reference39 = ref array[3];
				reference39 = new PointF(num9 + rectangleF_0.Width + rectangleF_0.X, num10 + rectangleF_0.Y);
				ref PointF reference40 = ref array[4];
				reference40 = new PointF(num9 + rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height + num2);
				ref PointF reference41 = ref array[5];
				reference41 = new PointF(num9 + rectangleF_0.X, num2 + rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference42 = ref array[6];
				reference42 = new PointF(num9 + rectangleF_0.X, rectangleF_0.Height * 0.42f + num10 + rectangleF_0.Y);
			}
			else
			{
				float num11 = num;
				ref PointF reference43 = ref array[0];
				reference43 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
				ref PointF reference44 = ref array[1];
				reference44 = new PointF(num11 + rectangleF_0.X, rectangleF_0.Height * 0.17f + rectangleF_0.Y);
				ref PointF reference45 = ref array[2];
				reference45 = new PointF(num11 + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference46 = ref array[3];
				reference46 = new PointF(num11 + rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference47 = ref array[4];
				reference47 = new PointF(num11 + rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height);
				ref PointF reference48 = ref array[5];
				reference48 = new PointF(num11 + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference49 = ref array[6];
				reference49 = new PointF(num11 + rectangleF_0.X, rectangleF_0.Height * 0.42f + rectangleF_0.Y);
			}
		}
		else if (num6 > 180f + (90f - num5) && num6 < 270f)
		{
			if (num3 < 0f)
			{
				float num12 = num;
				float num13 = num2;
				ref PointF reference50 = ref array[0];
				reference50 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference51 = ref array[1];
				reference51 = new PointF(num12 + 0.42f * rectangleF_0.Width + rectangleF_0.X, num13 + rectangleF_0.Y);
				ref PointF reference52 = ref array[2];
				reference52 = new PointF(num12 + rectangleF_0.Width + rectangleF_0.X, num13 + rectangleF_0.Y);
				ref PointF reference53 = ref array[3];
				reference53 = new PointF(num12 + rectangleF_0.Width + rectangleF_0.X, num13 + rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference54 = ref array[4];
				reference54 = new PointF(num12 + rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height + num13);
				ref PointF reference55 = ref array[5];
				reference55 = new PointF(num12 + rectangleF_0.X, num13 + rectangleF_0.Y);
				ref PointF reference56 = ref array[6];
				reference56 = new PointF(num12 + 0.17f * rectangleF_0.Width + rectangleF_0.X, num13 + rectangleF_0.Y);
			}
			else
			{
				float num14 = num2;
				ref PointF reference57 = ref array[0];
				reference57 = new PointF(rectangleF_0.X + num, rectangleF_0.Y);
				ref PointF reference58 = ref array[1];
				reference58 = new PointF(0.42f * rectangleF_0.Width + rectangleF_0.X, num14 + rectangleF_0.Y);
				ref PointF reference59 = ref array[2];
				reference59 = new PointF(rectangleF_0.Width + rectangleF_0.X, num14 + rectangleF_0.Y);
				ref PointF reference60 = ref array[3];
				reference60 = new PointF(rectangleF_0.Width + rectangleF_0.X, num14 + rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference61 = ref array[4];
				reference61 = new PointF(rectangleF_0.X, rectangleF_0.Y + num14 + rectangleF_0.Height);
				ref PointF reference62 = ref array[5];
				reference62 = new PointF(rectangleF_0.X, num14 + rectangleF_0.Y);
				ref PointF reference63 = ref array[6];
				reference63 = new PointF(rectangleF_0.Width * 0.17f + rectangleF_0.X, num14 + rectangleF_0.Y);
			}
		}
		else if (num6 > 270f && num6 < 270f + num5)
		{
			if (num > rectangleF_0.Width)
			{
				_ = rectangleF_0.Width;
				float num15 = num2;
				ref PointF reference64 = ref array[0];
				reference64 = new PointF(rectangleF_0.X + num, rectangleF_0.Y);
				ref PointF reference65 = ref array[1];
				reference65 = new PointF(0.83f * rectangleF_0.Width + rectangleF_0.X, num15 + rectangleF_0.Y);
				ref PointF reference66 = ref array[2];
				reference66 = new PointF(rectangleF_0.Width + rectangleF_0.X, num15 + rectangleF_0.Y);
				ref PointF reference67 = ref array[3];
				reference67 = new PointF(rectangleF_0.Width + rectangleF_0.X, num15 + rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference68 = ref array[4];
				reference68 = new PointF(rectangleF_0.X, rectangleF_0.Y + num15 + rectangleF_0.Height);
				ref PointF reference69 = ref array[5];
				reference69 = new PointF(rectangleF_0.X, num15 + rectangleF_0.Y);
				ref PointF reference70 = ref array[6];
				reference70 = new PointF(0.58f * rectangleF_0.Width + rectangleF_0.X, num15 + rectangleF_0.Y);
			}
			else
			{
				float num16 = num2;
				ref PointF reference71 = ref array[0];
				reference71 = new PointF(rectangleF_0.X + num, rectangleF_0.Y);
				ref PointF reference72 = ref array[1];
				reference72 = new PointF(0.83f * rectangleF_0.Width + rectangleF_0.X, num16 + rectangleF_0.Y);
				ref PointF reference73 = ref array[2];
				reference73 = new PointF(rectangleF_0.Width + rectangleF_0.X, num16 + rectangleF_0.Y);
				ref PointF reference74 = ref array[3];
				reference74 = new PointF(rectangleF_0.Width + rectangleF_0.X, num16 + rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference75 = ref array[4];
				reference75 = new PointF(rectangleF_0.X, rectangleF_0.Y + num16 + rectangleF_0.Height);
				ref PointF reference76 = ref array[5];
				reference76 = new PointF(rectangleF_0.X, num16 + rectangleF_0.Y);
				ref PointF reference77 = ref array[6];
				reference77 = new PointF(0.58f * rectangleF_0.Width + rectangleF_0.X, num16 + rectangleF_0.Y);
			}
		}
		else if (num6 > 270f + num5 && num6 < 360f)
		{
			if (num4 < 0f)
			{
				_ = rectangleF_0.Width;
				float num17 = num2;
				ref PointF reference78 = ref array[0];
				reference78 = new PointF(rectangleF_0.X + num, rectangleF_0.Y);
				ref PointF reference79 = ref array[1];
				reference79 = new PointF(rectangleF_0.Width + rectangleF_0.X, 0.42f * rectangleF_0.Height + num17 + rectangleF_0.Y);
				ref PointF reference80 = ref array[2];
				reference80 = new PointF(rectangleF_0.Width + rectangleF_0.X, num17 + rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference81 = ref array[3];
				reference81 = new PointF(rectangleF_0.X, num17 + rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference82 = ref array[4];
				reference82 = new PointF(rectangleF_0.X, rectangleF_0.Y + num17);
				ref PointF reference83 = ref array[5];
				reference83 = new PointF(rectangleF_0.Width + rectangleF_0.X, num17 + rectangleF_0.Y);
				ref PointF reference84 = ref array[6];
				reference84 = new PointF(rectangleF_0.Width + rectangleF_0.X, num17 + rectangleF_0.Height * 0.17f + rectangleF_0.Y);
			}
			else
			{
				_ = rectangleF_0.Width;
				ref PointF reference85 = ref array[0];
				reference85 = new PointF(rectangleF_0.X + num, rectangleF_0.Y + num2);
				ref PointF reference86 = ref array[1];
				reference86 = new PointF(rectangleF_0.Width + rectangleF_0.X, 0.42f * rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference87 = ref array[2];
				reference87 = new PointF(rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference88 = ref array[3];
				reference88 = new PointF(rectangleF_0.X, rectangleF_0.Height + rectangleF_0.Y);
				ref PointF reference89 = ref array[4];
				reference89 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference90 = ref array[5];
				reference90 = new PointF(rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference91 = ref array[6];
				reference91 = new PointF(rectangleF_0.Width + rectangleF_0.X, rectangleF_0.Height * 0.17f + rectangleF_0.Y);
			}
		}
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[4]);
		graphicsPath.AddLine(array[4], array[5]);
		graphicsPath.AddLine(array[5], array[6]);
		graphicsPath.AddLine(array[6], array[0]);
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
