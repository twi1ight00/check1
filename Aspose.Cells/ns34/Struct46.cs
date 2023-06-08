using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns3;
using ns33;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct46
{
	internal static ArrayList smethod_0(Interface42 interface42_0, Class844 class844_0, Rectangle rectangle_0, float float_0, double double_0, int int_0)
	{
		GraphicsState graphicsState_ = interface42_0.Save();
		interface42_0.imethod_50();
		interface42_0.imethod_47(rectangle_0);
		Class821 chart = class844_0.Chart;
		Enum53 @enum = class844_0.method_20();
		Class823 @class;
		Class823 class2;
		if (@enum == Enum53.const_0)
		{
			@class = chart.method_1();
			class2 = chart.method_9();
		}
		else
		{
			@class = chart.method_2();
			class2 = chart.method_10();
		}
		Class842 class3 = chart.method_7();
		_ = class3.Count;
		double num = (class2.IsLogarithmic ? class2.method_6(class2.MinValue) : class2.MinValue);
		double num2 = (class2.IsLogarithmic ? class2.method_6(class2.MaxValue) : class2.MaxValue);
		double_0 = (class2.IsLogarithmic ? class2.method_6(double_0) : double_0);
		double num3 = (@class.IsLogarithmic ? @class.method_6(@class.MinValue) : @class.MinValue);
		double num4 = (@class.IsLogarithmic ? @class.method_6(@class.MaxValue) : @class.MaxValue);
		if (!@class.IsLogarithmic)
		{
			_ = @class.MajorUnit;
		}
		else
		{
			@class.method_6(@class.MajorUnit);
		}
		ArrayList arrayList = new ArrayList();
		double num5 = (double)rectangle_0.Width / (num4 - num3);
		double double_ = smethod_2(class3, num, num2, num3, num4);
		int index = class844_0.Index;
		ArrayList arrayList2 = new ArrayList();
		Class830 class4 = class844_0.method_9();
		for (int i = 0; i < int_0; i++)
		{
			Class831 class5 = class4.method_1(i);
			if (class5 != null && !class5.imethod_0() && !class5.imethod_2())
			{
				if (class5.YValue > num2 || class5.YValue < num || class5.XValue > num4 || class5.XValue < num3)
				{
					continue;
				}
				double num6 = (double)(float)num5 * (class5.XValue - num3);
				num6 = ((!@class.IsPlotOrderReversed) ? ((double)rectangle_0.X + num6) : ((double)(rectangle_0.X + rectangle_0.Width) - num6));
				double num7 = float_0;
				double yValue = class5.YValue;
				double num8 = (yValue - double_0) / (num2 - num) * (double)rectangle_0.Height;
				Class834 class6 = class844_0.method_4();
				PointF pointF_ = new PointF((float)num6, float_0);
				double num9 = 0.0;
				double num10 = 0.0;
				float float_ = 0f;
				float float_2 = 0f;
				if (class6 != null)
				{
					switch (class6.Type)
					{
					case Enum69.const_0:
					{
						double num11 = ((class6.MinusValue.Count > i) ? class6.method_2(class6.MinusValue[i]) : 0.0);
						num9 = num11;
						num11 = ((class6.PlusValue.Count > i) ? class6.method_2(class6.PlusValue[i]) : 0.0);
						num10 = num11;
						break;
					}
					case Enum69.const_1:
						num9 = class6.Amount;
						num10 = num9;
						break;
					case Enum69.const_2:
						num9 = class6.Amount * Math.Abs(class5.XValue) / 100.0;
						num10 = num9;
						break;
					}
					float_ = (float)(num9 / (num4 - num3) * (double)rectangle_0.Width);
					float_2 = (float)(num10 / (num4 - num3) * (double)rectangle_0.Width);
					if (!class2.IsPlotOrderReversed)
					{
						pointF_.Y -= (float)num8;
					}
					else
					{
						pointF_.Y += (float)num8;
					}
				}
				class6.method_0(pointF_, float_, float_2);
				Class834 class7 = class844_0.method_3();
				num9 = 0.0;
				num10 = 0.0;
				float_ = 0f;
				float_2 = 0f;
				if (class7 != null)
				{
					switch (class7.Type)
					{
					case Enum69.const_0:
					{
						double num12 = ((class7.MinusValue.Count > i) ? class7.method_2(class7.MinusValue[i]) : 0.0);
						num9 = num12;
						num12 = ((class7.PlusValue.Count > i) ? class7.method_2(class7.PlusValue[i]) : 0.0);
						num10 = num12;
						break;
					}
					case Enum69.const_1:
						num9 = class7.Amount;
						num10 = num9;
						break;
					case Enum69.const_2:
						num9 = class7.Amount * Math.Abs(class5.YValue) / 100.0;
						num10 = num9;
						break;
					}
					float_ = (float)num9 / (float)(num2 - num) * (float)rectangle_0.Height;
					float_2 = (float)num10 / (float)(num2 - num) * (float)rectangle_0.Height;
				}
				class7.method_0(pointF_, float_, float_2);
				num7 = (class2.IsPlotOrderReversed ? (num7 + num8) : (num7 - num8));
				PointF pointF = new PointF((float)num6, (float)num7);
				float float_3 = 0f;
				if (smethod_1(interface42_0, pointF, class844_0, class5, double_, (int)smethod_3(rectangle_0), ref float_3))
				{
					object[] value = new object[4] { index, i, pointF, @class };
					class5.float_0 = float_3;
					arrayList.Add(value);
				}
			}
			else
			{
				arrayList2.Add(null);
			}
		}
		interface42_0.imethod_44(graphicsState_);
		return arrayList;
	}

	private static bool smethod_1(Interface42 interface42_0, PointF pointF_0, Class844 class844_0, Class831 class831_0, double double_0, int int_0, ref float float_0)
	{
		double num = class831_0.vmethod_8();
		float num2 = (float)class844_0.BubbleScale / 100f;
		Enum63 sizeRepresents = class844_0.SizeRepresents;
		bool showNegativeBubbles = class844_0.ShowNegativeBubbles;
		if (num == 0.0)
		{
			return false;
		}
		if (showNegativeBubbles)
		{
			num = Math.Abs(num);
		}
		else if (num < 0.0)
		{
			return false;
		}
		double num3 = 0.0;
		double num4;
		if (sizeRepresents == Enum63.const_0)
		{
			num3 = Math.PI * Math.Pow(int_0, 2.0) / double_0;
			num4 = Math.Sqrt(num * num3 / Math.PI);
		}
		else
		{
			num3 = (double)(2 * int_0) / double_0;
			num4 = num * num3 / 2.0;
		}
		num4 *= (double)num2;
		RectangleF rectangleF = new RectangleF(pointF_0.X - (float)num4, pointF_0.Y - (float)num4, Struct63.smethod_3(2f * (float)num4), Struct63.smethod_3(2f * (float)num4));
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(rectangleF);
		if (class831_0.method_3().Formatting != 0)
		{
			if (class831_0.vmethod_8() > 0.0)
			{
				class831_0.method_3().method_9(graphicsPath);
			}
			else
			{
				interface42_0.imethod_31(new SolidBrush(Color.White), rectangleF);
			}
		}
		class831_0.method_4().method_11(graphicsPath);
		float_0 = rectangleF.Width;
		return true;
	}

	private static double smethod_2(Class842 class842_0, double double_0, double double_1, double double_2, double double_3)
	{
		double num = 0.0;
		for (int i = 0; i < class842_0.Count; i++)
		{
			Class844 @class = class842_0.method_9(i);
			bool showNegativeBubbles = @class.ShowNegativeBubbles;
			if (@class.Type != ChartType_Chart.Bubble && @class.Type != ChartType_Chart.Bubble3D)
			{
				continue;
			}
			Class830 class2 = @class.method_9();
			for (int j = 0; j < class2.Count; j++)
			{
				Class831 class3 = class2.method_1(j);
				if (class3 != null && !class3.imethod_0())
				{
					double num2 = class3.vmethod_8();
					if (showNegativeBubbles)
					{
						num2 = Math.Abs(num2);
					}
					if (num < num2)
					{
						num = num2;
					}
				}
			}
		}
		return num;
	}

	internal static float smethod_3(Rectangle rectangle_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		return smethod_4(rectangleF_);
	}

	internal static float smethod_4(RectangleF rectangleF_0)
	{
		float num = ((rectangleF_0.Width > rectangleF_0.Height) ? rectangleF_0.Height : rectangleF_0.Width);
		return num / 8f;
	}

	internal static void smethod_5(Interface42 interface42_0, Class842 class842_0, Rectangle rectangle_0, int int_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4, bool bool_5, bool bool_6, bool bool_7)
	{
		Class821 chart = class842_0.method_9(0).Chart;
		Class823 @class = chart.method_1();
		Class823 class2 = chart.method_9();
		double num = class2.MinValue;
		double maxValue = class2.MaxValue;
		double num2 = class2.MajorUnit;
		double num3 = @class.MinValue;
		double num4 = @class.MaxValue;
		double num5 = @class.MajorUnit;
		double double_ = (num4 - num3) / 2.0;
		double double_2 = double_;
		double double_3 = (maxValue - num) / 2.0;
		double double_4 = double_3;
		smethod_7(class842_0, int_0, ref double_, ref double_2, ref double_3, ref double_4);
		double num6 = smethod_3(rectangle_0);
		double num7 = num6 * (num4 - num3) / (double)rectangle_0.Width;
		double num8 = num6 * (maxValue - num) / (double)rectangle_0.Height;
		if (!class2.IsLogarithmic)
		{
			ArrayList arrayList_ = class2.arrayList_1;
			bool flag = false;
			if (bool_7 && double_4 - num8 <= num)
			{
				num = Struct63.smethod_9(num, num2);
				arrayList_.Add(num);
				num8 = num6 * (maxValue - num) / (double)rectangle_0.Height;
				flag = true;
			}
			if (bool_6 && double_3 + num8 >= maxValue)
			{
				maxValue = Struct63.smethod_11(maxValue, num2);
				arrayList_.Insert(0, maxValue);
				num8 = num6 * (maxValue - num) / (double)rectangle_0.Height;
				flag = true;
			}
			if (bool_4 && class2.arrayList_1.Count > 11)
			{
				double num9 = num2 * 0.35;
				if (double_4 - num8 - (double)arrayList_[arrayList_.Count - 1] < num9 || (double)arrayList_[0] - (double_3 + num8) < num9)
				{
					flag = true;
					num2 *= 2.0;
					double num10 = (double)arrayList_[0];
					double num11 = (double)arrayList_[arrayList_.Count - 1];
					double num12 = num2;
					int int_ = Struct63.smethod_7(num12);
					arrayList_.Clear();
					switch (smethod_6(bool_6, bool_7, num10, num11))
					{
					case 1:
					{
						double num14 = num10;
						while (num14 > num11 || Struct63.smethod_9(num11, num14) < num12)
						{
							num14 = Struct63.smethod_10(num14, int_);
							arrayList_.Add(num14);
							num14 -= num12;
						}
						break;
					}
					case 2:
					{
						double num15 = num11;
						while (num15 <= num10 || Struct63.smethod_9(num15, num10) < num12)
						{
							num15 = Struct63.smethod_10(num15, int_);
							arrayList_.Add(num15);
							num15 += num12;
						}
						arrayList_.Reverse();
						break;
					}
					default:
					{
						double num13 = 0.0;
						while (num13 <= num10 || Struct63.smethod_9(num13, num10) < num12)
						{
							num13 = Struct63.smethod_10(num13, int_);
							arrayList_.Add(num13);
							num13 += num12;
						}
						arrayList_.Reverse();
						num13 = 0.0;
						while (num13 > num11 || Struct63.smethod_9(num11, num13) < num12)
						{
							num13 = Struct63.smethod_10(num13, int_);
							arrayList_.Add(num13);
							num13 -= num12;
						}
						break;
					}
					}
				}
			}
			if (flag)
			{
				if (arrayList_.Count >= 2)
				{
					if (bool_6)
					{
						class2.MaxValue = (double)arrayList_[0];
					}
					if (bool_7)
					{
						class2.MinValue = (double)arrayList_[arrayList_.Count - 1];
					}
					if (bool_4)
					{
						class2.MajorUnit = num2;
					}
					if (bool_5)
					{
						class2.MinorUnit = num2 / 5.0;
					}
				}
				Struct44.smethod_19(interface42_0, class2, class842_0.method_9(0), bool_0: false);
			}
		}
		if (@class.IsLogarithmic)
		{
			return;
		}
		ArrayList arrayList_2 = @class.arrayList_1;
		bool flag2 = false;
		if (bool_3 && double_2 - num7 <= num3)
		{
			num3 = Struct63.smethod_9(num3, num5);
			arrayList_2.Add(num3);
			num7 = num6 * (num4 - num3) / (double)rectangle_0.Width;
			flag2 = true;
		}
		if (bool_2 && double_ + num7 >= num4)
		{
			num4 = Struct63.smethod_11(num4, num5);
			arrayList_2.Insert(0, num4);
			num7 = num6 * (num4 - num3) / (double)rectangle_0.Width;
			flag2 = true;
		}
		if (bool_3)
		{
			int int_2 = Struct63.smethod_7(num5);
			if ((double_2 - num7 - (double_ + num7)) / (num3 - (double_ + num7)) > 20.0 / 21.0)
			{
				double num16 = Struct63.smethod_10(num3 - num5, int_2);
				arrayList_2.Add(num16);
				num3 = num16;
				num7 = num6 * (num4 - num3) / (double)rectangle_0.Width;
				flag2 = true;
			}
		}
		if (bool_2)
		{
			int int_3 = Struct63.smethod_7(num5);
			if ((double_ + num7 - (double_2 - num7)) / (num4 - (double_2 - num7)) > 20.0 / 21.0)
			{
				double num17 = Struct63.smethod_10(num4 + num5, int_3);
				arrayList_2.Insert(0, num17);
				num4 = num17;
				num7 = num6 * (num4 - num3) / (double)rectangle_0.Width;
				flag2 = true;
			}
		}
		if (bool_0 && arrayList_2.Count > 11)
		{
			flag2 = true;
			num5 *= 2.0;
			double num18 = (double)arrayList_2[0];
			double num19 = (double)arrayList_2[arrayList_2.Count - 1];
			double num20 = num5;
			int int_4 = Struct63.smethod_7(num20);
			arrayList_2.Clear();
			switch (smethod_6(bool_2, bool_3, num18, num19))
			{
			case 1:
			{
				double num22 = num18;
				while (num22 > num19 || Struct63.smethod_9(num19, num22) < num20)
				{
					num22 = Struct63.smethod_10(num22, int_4);
					arrayList_2.Add(num22);
					num22 -= num20;
				}
				break;
			}
			case 2:
			{
				double num23 = num19;
				while (num23 <= num18 || Struct63.smethod_9(num23, num18) < num20)
				{
					num23 = Struct63.smethod_10(num23, int_4);
					arrayList_2.Add(num23);
					num23 += num20;
				}
				arrayList_2.Reverse();
				break;
			}
			default:
			{
				double num21 = 0.0;
				while (num21 <= num18 || Struct63.smethod_9(num21, num18) < num20)
				{
					num21 = Struct63.smethod_10(num21, int_4);
					arrayList_2.Add(num21);
					num21 += num20;
				}
				arrayList_2.Reverse();
				num21 = 0.0;
				while (num21 > num19 || Struct63.smethod_9(num19, num21) < num20)
				{
					num21 = Struct63.smethod_10(num21, int_4);
					arrayList_2.Add(num21);
					num21 -= num20;
				}
				break;
			}
			}
		}
		if (!flag2)
		{
			return;
		}
		if (arrayList_2.Count >= 2)
		{
			if (bool_2)
			{
				@class.MaxValue = (double)arrayList_2[0];
			}
			if (bool_3)
			{
				@class.MinValue = (double)arrayList_2[arrayList_2.Count - 1];
			}
			if (bool_0)
			{
				@class.MajorUnit = num5;
			}
			if (bool_1)
			{
				@class.MinorUnit = num5 / 5.0;
			}
		}
		Struct44.smethod_20(interface42_0, @class, rectangle_0, rectangle_0, int_0, bool_0: false, class842_0.method_9(0));
	}

	private static int smethod_6(bool bool_0, bool bool_1, double double_0, double double_1)
	{
		int num = 2;
		if (!bool_0 || !bool_1)
		{
			num = ((!bool_0 && bool_1) ? 1 : ((!bool_0 || bool_1) ? 2 : 2));
		}
		else
		{
			num = 3;
			if (double_0 == 0.0)
			{
				num = 2;
			}
			if (double_1 == 0.0)
			{
				num = 1;
			}
		}
		return num;
	}

	private static void smethod_7(Class842 class842_0, int int_0, ref double double_0, ref double double_1, ref double double_2, ref double double_3)
	{
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < class842_0.Count; i++)
		{
			Class830 @class = class842_0.method_9(i).method_9();
			for (int j = 0; j < int_0; j++)
			{
				Class831 class2 = @class.method_1(j);
				if (class2 != null && !class2.imethod_2())
				{
					if (!flag)
					{
						double_0 = class2.XValue;
						double_1 = double_0;
						flag = true;
					}
					else
					{
						if (class2.XValue > double_0)
						{
							double_0 = class2.XValue;
						}
						if (class2.XValue < double_1)
						{
							double_1 = class2.XValue;
						}
					}
				}
				if (class2 == null || class2.imethod_0())
				{
					continue;
				}
				if (!flag2)
				{
					double_2 = class2.YValue;
					double_3 = double_2;
					flag2 = true;
					continue;
				}
				if (class2.YValue > double_2)
				{
					double_2 = class2.YValue;
				}
				if (class2.YValue < double_3)
				{
					double_3 = class2.YValue;
				}
			}
		}
	}
}
