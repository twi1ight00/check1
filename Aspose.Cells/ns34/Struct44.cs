using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns22;
using ns3;
using ns33;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct44
{
	internal static void smethod_0(Interface42 interface42_0, Class823 class823_0, Rectangle rectangle_0, bool bool_0, Class844 class844_0)
	{
		if (Struct63.smethod_18(rectangle_0) || (!class823_0.method_8().IsVisible && !class823_0.method_9().IsVisible))
		{
			return;
		}
		int num = 0;
		num = (bool_0 ? ((class823_0.method_4() == Enum61.const_0 || class823_0.method_4() == Enum61.const_2) ? rectangle_0.Height : rectangle_0.Width) : ((class823_0.method_4() == Enum61.const_0 || class823_0.method_4() == Enum61.const_2) ? rectangle_0.Width : rectangle_0.Height));
		double num2 = 0.0;
		bool flag = class823_0.CategoryType == Enum64.const_2 && (class823_0.method_4() == Enum61.const_0 || class823_0.method_4() == Enum61.const_2);
		double num3 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MaxValue) : class823_0.MaxValue);
		double num4 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MajorUnit) : class823_0.MajorUnit);
		double num6;
		if (!class844_0.method_36() && (class823_0.method_4() == Enum61.const_0 || class823_0.method_4() == Enum61.const_2))
		{
			double num5 = (int)class823_0.MaxValue;
			num6 = (int)class823_0.MinValue;
			int num7;
			if (flag)
			{
				if (!class823_0.Chart.method_1().AxisBetweenCategories && !class823_0.Chart.IsDataTableShown)
				{
					num7 = smethod_29(class823_0.BaseUnitScale, (int)num5, (int)num6, class823_0.Chart.vmethod_0());
					if (num7 == 0)
					{
						num7 = 1;
					}
				}
				else
				{
					num7 = smethod_29(class823_0.BaseUnitScale, (int)num5, (int)num6, class823_0.Chart.vmethod_0()) + 1;
					num3 = smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, 1, (int)num3, class823_0.Chart.vmethod_0());
				}
			}
			else if (!class823_0.Chart.method_1().AxisBetweenCategories && !class823_0.Chart.IsDataTableShown)
			{
				num7 = (int)num5 - (int)num6;
				if (num7 == 0)
				{
					num7 = 1;
				}
			}
			else
			{
				num7 = (int)num5 - (int)num6 + 1;
				num3 += 1.0;
			}
			num2 = (double)num / (double)num7;
		}
		else
		{
			double num5 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MaxValue) : class823_0.MaxValue);
			num6 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MinValue) : class823_0.MinValue);
			num2 = (double)num / (num5 - num6);
		}
		if (class823_0.method_8().IsVisible && num4 > 0.0)
		{
			for (double num8 = num6; num8 <= num3; num8 = ((!flag) ? ((class844_0.method_36() || (class823_0.method_4() != 0 && class823_0.method_4() != Enum61.const_2)) ? Struct63.smethod_11(num8, num4) : (num8 + num4 * (double)class823_0.TickMarkSpacing)) : ((double)smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)num4, (int)num8, class823_0.Chart.vmethod_0()))))
			{
				double num10;
				if (flag)
				{
					int num9 = smethod_29(class823_0.BaseUnitScale, (int)num8, (int)num6, class823_0.Chart.vmethod_0());
					num10 = num2 * (double)num9;
				}
				else
				{
					num10 = num2 * (num8 - num6);
				}
				if (!class823_0.Chart.method_8().method_2().method_17() || (num8 != num6 && num8 != num3))
				{
					if (bool_0)
					{
						if (class823_0.method_4() != 0 && class823_0.method_4() != Enum61.const_2)
						{
							if (class823_0.IsPlotOrderReversed)
							{
								class823_0.method_8().method_7((float)((double)rectangle_0.Right - num10), rectangle_0.Y, (float)((double)rectangle_0.Right - num10), rectangle_0.Bottom);
							}
							else
							{
								class823_0.method_8().method_7((float)((double)rectangle_0.X + num10), rectangle_0.Y, (float)((double)rectangle_0.X + num10), rectangle_0.Bottom);
							}
						}
						else if (class823_0.IsPlotOrderReversed)
						{
							class823_0.method_8().method_7(rectangle_0.X, (float)((double)rectangle_0.Y + num10), rectangle_0.Right, (float)((double)rectangle_0.Y + num10));
						}
						else
						{
							class823_0.method_8().method_7(rectangle_0.X, (float)((double)rectangle_0.Bottom - num10), rectangle_0.Right, (float)((double)rectangle_0.Bottom - num10));
						}
					}
					else if (class823_0.method_4() != 0 && class823_0.method_4() != Enum61.const_2)
					{
						if (class823_0.IsPlotOrderReversed)
						{
							class823_0.method_8().method_7(rectangle_0.X, (float)((double)rectangle_0.Y + num10), rectangle_0.Right, (float)((double)rectangle_0.Y + num10));
						}
						else
						{
							class823_0.method_8().method_7(rectangle_0.X, (float)((double)rectangle_0.Bottom - num10), rectangle_0.Right, (float)((double)rectangle_0.Bottom - num10));
						}
					}
					else if (class823_0.IsPlotOrderReversed)
					{
						class823_0.method_8().method_7((float)((double)rectangle_0.Right - num10), rectangle_0.Y, (float)((double)rectangle_0.Right - num10), rectangle_0.Bottom);
					}
					else
					{
						class823_0.method_8().method_7((float)((double)rectangle_0.X + num10), rectangle_0.Y, (float)((double)rectangle_0.X + num10), rectangle_0.Bottom);
					}
				}
			}
		}
		if (!class823_0.IsLogarithmic)
		{
			double minorUnit = class823_0.MinorUnit;
			if (!class823_0.method_9().IsVisible || !(minorUnit > 0.0))
			{
				return;
			}
			int num11 = 0;
			if (flag)
			{
				int int_ = smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)num4, (int)num6, class823_0.Chart.vmethod_0());
				num11 = smethod_29(class823_0.BaseUnitScale, int_, (int)num6, class823_0.Chart.vmethod_0());
			}
			for (double num12 = num6; num12 <= num3; num12 = ((!flag) ? ((class844_0.method_36() || (class823_0.method_4() != 0 && class823_0.method_4() != Enum61.const_2)) ? Struct63.smethod_11(num12, minorUnit) : (num12 + minorUnit * (double)class823_0.TickMarkSpacing)) : ((double)smethod_31(class823_0.BaseUnitScale, class823_0.MinorUnitScale, (int)minorUnit, (int)num12, class823_0.Chart.vmethod_0()))))
			{
				bool flag2 = false;
				double num14;
				if (flag)
				{
					int num13 = smethod_29(class823_0.BaseUnitScale, (int)num12, (int)num6, class823_0.Chart.vmethod_0());
					num14 = num2 * (double)num13;
					if (num13 % num11 == 0 && class823_0.method_8().IsVisible)
					{
						flag2 = true;
					}
				}
				else
				{
					num14 = num2 * (num12 - num6);
					if (Struct63.smethod_9(num12, num6) % num4 == 0.0 && class823_0.method_8().IsVisible)
					{
						flag2 = true;
					}
				}
				if ((!class823_0.Chart.method_8().method_2().IsVisible || (num12 != num6 && num12 != num3)) && !flag2)
				{
					if (bool_0)
					{
						if (class823_0.method_4() != 0 && class823_0.method_4() != Enum61.const_2)
						{
							if (class823_0.IsPlotOrderReversed)
							{
								class823_0.method_9().method_7((float)((double)rectangle_0.Right - num14), rectangle_0.Y, (float)((double)rectangle_0.Right - num14), rectangle_0.Bottom);
							}
							else
							{
								class823_0.method_9().method_7((float)((double)rectangle_0.X + num14), rectangle_0.Y, (float)((double)rectangle_0.X + num14), rectangle_0.Bottom);
							}
						}
						else if (class823_0.IsPlotOrderReversed)
						{
							class823_0.method_9().method_7(rectangle_0.X, (float)((double)rectangle_0.Y + num14), rectangle_0.Right, (float)((double)rectangle_0.Y + num14));
						}
						else
						{
							class823_0.method_9().method_7(rectangle_0.X, (float)((double)rectangle_0.Bottom - num14), rectangle_0.Right, (float)((double)rectangle_0.Bottom - num14));
						}
					}
					else if (class823_0.method_4() != 0 && class823_0.method_4() != Enum61.const_2)
					{
						if (class823_0.IsPlotOrderReversed)
						{
							class823_0.method_9().method_7(rectangle_0.X, (float)((double)rectangle_0.Y + num14), rectangle_0.Right, (float)((double)rectangle_0.Y + num14));
						}
						else
						{
							class823_0.method_9().method_7(rectangle_0.X, (float)((double)rectangle_0.Bottom - num14), rectangle_0.Right, (float)((double)rectangle_0.Bottom - num14));
						}
					}
					else if (class823_0.IsPlotOrderReversed)
					{
						class823_0.method_9().method_7((float)((double)rectangle_0.Right - num14), rectangle_0.Y, (float)((double)rectangle_0.Right - num14), rectangle_0.Bottom);
					}
					else
					{
						class823_0.method_9().method_7((float)((double)rectangle_0.X + num14), rectangle_0.Y, (float)((double)rectangle_0.X + num14), rectangle_0.Bottom);
					}
				}
			}
			return;
		}
		double minorUnit2 = class823_0.MinorUnit;
		int num15 = Struct63.smethod_12(minorUnit2);
		double num16 = (class823_0.IsLogarithmic ? class823_0.method_6(minorUnit2) : minorUnit2);
		if (!class823_0.method_9().IsVisible || !(minorUnit2 > 0.0))
		{
			return;
		}
		for (double num17 = num6; num17 <= num3 + num16; num17 = Struct63.smethod_11(num17, num16))
		{
			for (int i = 1; i <= 10; i++)
			{
				double double_ = Math.Pow(i, num15) * Math.Pow(10.0, num17);
				double_ = class823_0.method_6(double_);
				if ((i == 1 && num17 != num6) || !(double_ <= num3))
				{
					continue;
				}
				double num18 = num2 * (double_ - num6);
				if (bool_0)
				{
					if (class823_0.method_4() != 0 && class823_0.method_4() != Enum61.const_2)
					{
						if (class823_0.IsPlotOrderReversed)
						{
							class823_0.method_9().method_7((float)((double)rectangle_0.Right - num18), rectangle_0.Y, (float)((double)rectangle_0.Right - num18), rectangle_0.Bottom);
						}
						else
						{
							class823_0.method_9().method_7((float)((double)rectangle_0.X + num18), rectangle_0.Y, (float)((double)rectangle_0.X + num18), rectangle_0.Bottom);
						}
					}
					else if (class823_0.IsPlotOrderReversed)
					{
						class823_0.method_9().method_7(rectangle_0.X, (float)((double)rectangle_0.Y + num18), rectangle_0.Right, (float)((double)rectangle_0.Y + num18));
					}
					else
					{
						class823_0.method_9().method_7(rectangle_0.X, (float)((double)rectangle_0.Bottom - num18), rectangle_0.Right, (float)((double)rectangle_0.Bottom - num18));
					}
				}
				else if (class823_0.method_4() != 0 && class823_0.method_4() != Enum61.const_2)
				{
					if (class823_0.IsPlotOrderReversed)
					{
						class823_0.method_9().method_7(rectangle_0.X, (float)((double)rectangle_0.Y + num18), rectangle_0.Right, (float)((double)rectangle_0.Y + num18));
					}
					else
					{
						class823_0.method_9().method_7(rectangle_0.X, (float)((double)rectangle_0.Bottom - num18), rectangle_0.Right, (float)((double)rectangle_0.Bottom - num18));
					}
				}
				else if (class823_0.IsPlotOrderReversed)
				{
					class823_0.method_9().method_7((float)((double)rectangle_0.Right - num18), rectangle_0.Y, (float)((double)rectangle_0.Right - num18), rectangle_0.Bottom);
				}
				else
				{
					class823_0.method_9().method_7((float)((double)rectangle_0.X + num18), rectangle_0.Y, (float)((double)rectangle_0.X + num18), rectangle_0.Bottom);
				}
			}
		}
	}

	internal static void smethod_1(Interface42 interface42_0, Class823 class823_0, Rectangle rectangle_0, int int_0)
	{
		if (Struct63.smethod_18(rectangle_0))
		{
			return;
		}
		double num = Math.PI * 2.0 / (double)int_0;
		double num2 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0;
		double num3 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0;
		new PointF((float)num2, (float)num3);
		double num4 = rectangle_0.Width / 2;
		if (class823_0.Chart.bool_8 && class823_0 == class823_0.Chart.method_9())
		{
			double num5 = 0.0;
			double num6 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.double_5) : class823_0.double_5);
			double num7 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.double_6) : class823_0.double_6);
			double num8 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.double_7) : class823_0.double_7);
			double num9 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.double_8) : class823_0.double_8);
			if (num8 > 0.0)
			{
				for (double num10 = num7 + num8; num10 <= num6; num10 = Struct63.smethod_11(num10, num8))
				{
					num5 = Math.Abs(num10 - num7);
					double num11 = num4 * num5 / (num6 - num7);
					double num12 = Math.PI / 2.0;
					PointF pointF_ = PointF.Empty;
					for (int i = 0; i < int_0; i++)
					{
						if (class823_0.method_8().IsVisible)
						{
							double num13 = num2 + num11 * Math.Cos(num12);
							double num14 = num3 - num11 * Math.Sin(num12);
							PointF pointF = new PointF((float)num13, (float)num14);
							if (i == 0)
							{
								double num15 = num2 + num11 * Math.Cos(num12 + num);
								double num16 = num3 - num11 * Math.Sin(num12 + num);
								pointF_ = new PointF((float)num15, (float)num16);
							}
							if (Math.Abs(pointF.X - pointF_.X) > 1f || Math.Abs(pointF.Y - pointF_.Y) > 1f)
							{
								class823_0.method_8().method_8(pointF, pointF_);
								pointF_ = pointF;
							}
						}
						num12 -= num;
					}
				}
			}
			if (!(num9 > 0.0))
			{
				return;
			}
			for (double num17 = num7 + num9; num17 <= num6; num17 = Struct63.smethod_11(num17, num9))
			{
				num5 = Math.Abs(num17 - num7);
				double num18 = num4 * num5 / (num6 - num7);
				double num12 = Math.PI / 2.0;
				PointF pointF_2 = PointF.Empty;
				for (int j = 0; j < int_0; j++)
				{
					if (class823_0.method_9().IsVisible)
					{
						double num19 = num2 + num18 * Math.Cos(num12);
						double num20 = num3 - num18 * Math.Sin(num12);
						PointF pointF2 = new PointF((float)num19, (float)num20);
						if (j == 0)
						{
							double num21 = num2 + num18 * Math.Cos(num12 + num);
							double num22 = num3 - num18 * Math.Sin(num12 + num);
							pointF_2 = new PointF((float)num21, (float)num22);
						}
						if (Math.Abs(pointF2.X - pointF_2.X) > 1f || Math.Abs(pointF2.Y - pointF_2.Y) > 1f)
						{
							class823_0.method_9().method_8(pointF2, pointF_2);
							pointF_2 = pointF2;
						}
					}
					num12 -= num;
				}
			}
			return;
		}
		double num23 = 0.0;
		double num24 = class823_0.method_13();
		double num25 = class823_0.method_14();
		double num26 = class823_0.method_16();
		double num27 = class823_0.method_17();
		if (num26 > 0.0)
		{
			for (double num28 = num25 + num26; num28 <= num24; num28 = Struct63.smethod_11(num28, num26))
			{
				num23 = Math.Abs(num28 - num25);
				double num29 = num4 * num23 / (num24 - num25);
				double num12 = Math.PI / 2.0;
				PointF pointF_3 = PointF.Empty;
				for (int k = 0; k < int_0; k++)
				{
					if (class823_0.method_8().IsVisible)
					{
						double num30 = num2 + num29 * Math.Cos(num12);
						double num31 = num3 - num29 * Math.Sin(num12);
						PointF pointF3 = new PointF((float)num30, (float)num31);
						if (k == 0)
						{
							double num32 = num2 + num29 * Math.Cos(num12 + num);
							double num33 = num3 - num29 * Math.Sin(num12 + num);
							pointF_3 = new PointF((float)num32, (float)num33);
						}
						if (Math.Abs(pointF3.X - pointF_3.X) > 1f || Math.Abs(pointF3.Y - pointF_3.Y) > 1f)
						{
							class823_0.method_8().method_8(pointF3, pointF_3);
							pointF_3 = pointF3;
						}
					}
					num12 -= num;
				}
			}
		}
		if (!(num27 > 0.0))
		{
			return;
		}
		for (double num34 = num25 + num27; num34 <= num24; num34 = Struct63.smethod_11(num34, num27))
		{
			num23 = Math.Abs(num34 - num25);
			double num35 = num4 * num23 / (num24 - num25);
			double num12 = Math.PI / 2.0;
			PointF pointF_4 = PointF.Empty;
			for (int l = 0; l < int_0; l++)
			{
				if (class823_0.method_9().IsVisible)
				{
					double num36 = num2 + num35 * Math.Cos(num12);
					double num37 = num3 - num35 * Math.Sin(num12);
					PointF pointF4 = new PointF((float)num36, (float)num37);
					if (l == 0)
					{
						double num38 = num2 + num35 * Math.Cos(num12 + num);
						double num39 = num3 - num35 * Math.Sin(num12 + num);
						pointF_4 = new PointF((float)num38, (float)num39);
					}
					if (Math.Abs(pointF4.X - pointF_4.X) > 1f || Math.Abs(pointF4.Y - pointF_4.Y) > 1f)
					{
						class823_0.method_9().method_8(pointF4, pointF_4);
						pointF_4 = pointF4;
					}
				}
				num12 -= num;
			}
		}
	}

	internal static void smethod_2(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, Rectangle rectangle_0, Class844 class844_0)
	{
		if (Struct63.smethod_18(rectangle_0))
		{
			return;
		}
		Class821 chart = class823_0.Chart;
		ChartType_Chart chartType_Chart_ = class844_0.method_22();
		Class847 @class = class823_0.method_10();
		Class831 class2 = class844_0.method_9().method_1(0);
		string string_ = class2.vmethod_6();
		bool bool_ = class2.vmethod_7();
		bool flag = false;
		if (@class.LinkedSource && class2 != null)
		{
			flag = true;
		}
		class823_0.method_5().method_7(float_0, rectangle_0.Y, float_0, rectangle_0.Bottom);
		Class833 class3 = class823_0.method_12();
		Enum82 enum82_ = Enum82.const_8;
		float num = 0f;
		float num2 = 2 * class823_0.method_19();
		float num3 = class823_0.float_1 / 2f;
		if (class823_0.int_4 == 1)
		{
			num = (float)rectangle_0.X - class823_0.float_0;
			class3.method_2().rectangle_1.X = (int)num - class3.method_2().rectangle_1.Width;
		}
		else if (class823_0.int_4 == 2)
		{
			enum82_ = Enum82.const_7;
			num = rectangle_0.Right;
			num += num2;
			class3.method_2().rectangle_1.X = (int)(num + class823_0.float_0);
		}
		else if (class823_0.int_4 == 3)
		{
			if (bool_0)
			{
				enum82_ = Enum82.const_7;
				num = float_0;
				num += num2;
				class3.method_2().rectangle_1.X = (int)(num + class823_0.float_0);
			}
			else
			{
				num = float_0 - class823_0.float_0;
				class3.method_2().rectangle_1.X = (int)num - class3.method_2().rectangle_1.Width;
			}
		}
		class3.method_2().rectangle_1.Y = rectangle_0.Y;
		ArrayList arrayList_ = class823_0.arrayList_1;
		double num4 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MaxValue) : class823_0.MaxValue);
		double num5 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MinValue) : class823_0.MinValue);
		double num6 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MajorUnit) : class823_0.MajorUnit);
		double num7 = 1E-10;
		if (!class823_0.IsPlotOrderReversed)
		{
			for (int num8 = arrayList_.Count - 1; num8 >= 0; num8--)
			{
				double num9 = Convert.ToDouble(arrayList_[num8]);
				double num10 = (class823_0.IsLogarithmic ? class823_0.method_7(num9) : num9);
				if (num8 - 1 > 0)
				{
					if (Math.Abs(Struct63.smethod_9(num6, Math.Abs(Struct63.smethod_9(num9, Convert.ToDouble(arrayList_[num8 - 1]))))) / num6 > num7)
					{
						continue;
					}
				}
				else if (num8 + 1 < arrayList_.Count && Math.Abs(Struct63.smethod_9(num6, Math.Abs(Struct63.smethod_9(num9, Convert.ToDouble(arrayList_[num8 + 1]))))) / num6 > num7)
				{
					continue;
				}
				float num11 = (float)((double)rectangle_0.Y + (num4 - num9) / (num4 - num5) * (double)rectangle_0.Height);
				if (class823_0.int_4 != 0)
				{
					if (Struct47.smethod_56(chartType_Chart_))
					{
						num10 /= 100.0;
						string_ = "0%";
					}
					string text = "";
					num10 = (class823_0.IsLogarithmic ? num10 : (num10 * Math.Pow(10.0, (double)class823_0.method_12().vmethod_0())));
					Color fontColor = @class.FontColor;
					if (flag)
					{
						text = Struct51.smethod_5(chart.vmethod_2(), num10, string_, bool_);
						fontColor = Struct51.smethod_6(num10, string_, fontColor);
					}
					else
					{
						text = smethod_28(class823_0, num10);
						fontColor = Struct51.smethod_6(num10, @class.imethod_0(), fontColor);
					}
					RectangleF value = new RectangleF(num, num11 - num3, class823_0.float_0 - num2, class823_0.float_1);
					smethod_37(interface42_0, Rectangle.Round(value), text, @class.Rotation, @class.Font, fontColor, enum82_, Enum82.const_1);
				}
				smethod_3(interface42_0, class823_0, bool_0, float_0, num11);
			}
		}
		else
		{
			for (int i = 0; i < arrayList_.Count; i++)
			{
				double num12 = Convert.ToDouble(arrayList_[i]);
				double num13 = (class823_0.IsLogarithmic ? class823_0.method_7(num12) : num12);
				if (i - 1 > 0)
				{
					if (Math.Abs(Struct63.smethod_9(num6, Math.Abs(Struct63.smethod_9(num12, Convert.ToDouble(arrayList_[i - 1]))))) / num6 > num7)
					{
						continue;
					}
				}
				else if (i + 1 < arrayList_.Count && Math.Abs(Struct63.smethod_9(num6, Math.Abs(Struct63.smethod_9(num12, Convert.ToDouble(arrayList_[i + 1]))))) / num6 > num7)
				{
					continue;
				}
				float num14 = (float)((double)rectangle_0.Y + (num12 - class823_0.MinValue) / (class823_0.MaxValue - class823_0.MinValue) * (double)rectangle_0.Height);
				if (class823_0.int_4 != 0)
				{
					if (Struct47.smethod_56(chartType_Chart_))
					{
						num13 /= 100.0;
						string_ = "0%";
					}
					string text2 = "";
					num13 = (class823_0.IsLogarithmic ? num13 : (num13 * Math.Pow(10.0, (double)class823_0.method_12().vmethod_0())));
					Color fontColor2 = @class.FontColor;
					if (flag)
					{
						text2 = Struct51.smethod_5(chart.vmethod_2(), num13, string_, bool_);
						fontColor2 = Struct51.smethod_6(num13, string_, fontColor2);
					}
					else
					{
						text2 = smethod_28(class823_0, num13);
						fontColor2 = Struct51.smethod_6(num13, @class.imethod_0(), fontColor2);
					}
					RectangleF value2 = new RectangleF(num, num14 - num3, class823_0.float_0 - num2, class823_0.float_1);
					smethod_37(interface42_0, Rectangle.Round(value2), text2, @class.Rotation, @class.Font, fontColor2, enum82_, Enum82.const_1);
				}
				smethod_3(interface42_0, class823_0, bool_0, float_0, num14);
			}
		}
		smethod_4(interface42_0, class823_0, bool_0, float_0, rectangle_0.Y, rectangle_0.Bottom);
		class3.method_3();
	}

	private static void smethod_3(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, float float_1)
	{
		Class823 @class = smethod_36(class823_0);
		bool flag = false;
		bool flag2 = false;
		switch (class823_0.MajorTickMark)
		{
		case Enum84.const_0:
			flag = true;
			flag2 = true;
			break;
		case Enum84.const_1:
			flag = true;
			if (bool_0)
			{
				flag = false;
				flag2 = true;
			}
			if (@class.bool_11)
			{
				if (bool_0)
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					flag = false;
					flag2 = true;
				}
			}
			break;
		case Enum84.const_3:
			flag2 = true;
			if (bool_0)
			{
				flag2 = false;
				flag = true;
			}
			if (@class.bool_11)
			{
				if (!bool_0)
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					flag = false;
					flag2 = true;
				}
			}
			break;
		}
		if (flag)
		{
			class823_0.method_5().method_7(float_0, float_1, float_0 + (float)class823_0.method_19(), float_1);
		}
		if (flag2)
		{
			class823_0.method_5().method_7(float_0 - (float)class823_0.method_19(), float_1, float_0, float_1);
		}
	}

	private static void smethod_4(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, float float_1, float float_2)
	{
		if (class823_0.MinorTickMark == Enum84.const_2)
		{
			return;
		}
		Class823 @class = smethod_36(class823_0);
		bool flag = false;
		bool flag2 = false;
		switch (class823_0.MinorTickMark)
		{
		case Enum84.const_0:
			flag = true;
			flag2 = true;
			break;
		case Enum84.const_1:
			flag = true;
			if (bool_0)
			{
				flag = false;
				flag2 = true;
			}
			if (@class.bool_11)
			{
				if (bool_0)
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					flag = false;
					flag2 = true;
				}
			}
			break;
		case Enum84.const_3:
			flag2 = true;
			if (bool_0)
			{
				flag2 = false;
				flag = true;
			}
			if (@class.bool_11)
			{
				if (!bool_0)
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					flag = false;
					flag2 = true;
				}
			}
			break;
		}
		float num = (float)(class823_0.MinorUnit / (class823_0.MaxValue - class823_0.MinValue) * (double)(float_2 - float_1));
		float num2;
		if (!class823_0.IsPlotOrderReversed)
		{
			num2 = float_2;
			num = 0f - num;
		}
		else
		{
			num2 = float_1;
		}
		float num3 = num2;
		do
		{
			if (flag)
			{
				class823_0.method_5().method_7(float_0, num3, float_0 + (float)class823_0.method_21(), num3);
			}
			if (flag2)
			{
				class823_0.method_5().method_7(float_0 - (float)class823_0.method_21(), num3, float_0, num3);
			}
			num3 += num;
		}
		while (float_1 <= num3 && num3 <= float_2);
	}

	internal static void smethod_5(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, Rectangle rectangle_0, int int_0, bool bool_1)
	{
		if (Struct63.smethod_18(rectangle_0))
		{
			return;
		}
		if (class823_0.CategoryType == Enum64.const_2)
		{
			smethod_8(interface42_0, class823_0, bool_0, float_0, rectangle_0);
			return;
		}
		class823_0.method_5().method_7(rectangle_0.X, float_0, rectangle_0.Right, float_0);
		float num = 0f;
		Enum82 enum82_ = Enum82.const_9;
		float num2 = class823_0.method_10().method_1();
		if (class823_0.int_4 != 0)
		{
			num2 += (float)(class823_0.method_19() + class823_0.method_21());
		}
		float y = 0f;
		if (class823_0.int_4 == 1)
		{
			num = (float)rectangle_0.Bottom + num2;
			y = (float)rectangle_0.Bottom + num2;
		}
		else if (class823_0.int_4 == 2)
		{
			enum82_ = Enum82.const_0;
			num = (float)rectangle_0.Y - num2 - class823_0.float_2;
			y = (float)rectangle_0.Y - num2;
		}
		else if (class823_0.int_4 == 3)
		{
			if (bool_0)
			{
				num = float_0 - num2 - class823_0.float_2;
				y = float_0 - num2;
				enum82_ = Enum82.const_0;
			}
			else
			{
				num = float_0 + num2;
				y = float_0 + num2;
			}
		}
		Class821 chart = class823_0.Chart;
		chart.method_7();
		Class847 @class = class823_0.method_10();
		ArrayList arrayList;
		ArrayList[] array;
		if (class823_0.method_4() == Enum61.const_0)
		{
			arrayList = chart.method_7().method_0();
			array = chart.method_7().method_4();
		}
		else
		{
			arrayList = chart.method_7().method_2();
			array = chart.method_7().method_7();
		}
		Class825 class2 = null;
		bool flag = true;
		if (arrayList != null && arrayList.Count > 0)
		{
			class2 = (Class825)arrayList[0];
			if (!class823_0.vmethod_0() && class823_0.TickLabelSpacing > 0 && (class2.imethod_0() == null || class2.imethod_0().Equals("")))
			{
				flag = false;
			}
		}
		bool flag2 = false;
		if (@class.LinkedSource && arrayList.Count > 0)
		{
			flag2 = true;
		}
		if (array != null && array.Length > 0 && arrayList.Count > 0)
		{
			flag2 = true;
		}
		int num3 = 0;
		int num4 = int_0;
		if (class823_0.bool_12)
		{
			num4 = (int)class823_0.MaxValue;
		}
		if (!class823_0.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num3 = num4 - 1;
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		else
		{
			num3 = num4;
		}
		double num5 = (double)rectangle_0.Width / (double)num3;
		SizeF sizeF_ = new SizeF(class823_0.float_3, class823_0.float_2);
		float num6 = -1f;
		float num7 = -1f;
		for (int i = 0; i < num4; i++)
		{
			double num8 = (double)(i + 1) * num5;
			if (!class823_0.AxisBetweenCategories && !class823_0.Chart.IsDataTableShown)
			{
				num8 -= num5 / 2.0;
			}
			float num9;
			float num10;
			float x;
			if (!class823_0.IsPlotOrderReversed)
			{
				num9 = (float)((double)rectangle_0.X + (double)(i + 1) * num5);
				num10 = (float)((double)rectangle_0.X + num8 - num5);
				x = (float)((double)rectangle_0.X + (double)(i + 1) * num5 - num5 / 2.0);
			}
			else
			{
				num9 = (float)((double)(rectangle_0.X + rectangle_0.Width) - (double)(i + 1) * num5);
				num10 = (float)((double)(rectangle_0.X + rectangle_0.Width) - num8);
				x = (float)((double)(rectangle_0.X + rectangle_0.Width) - (double)(i + 1) * num5 + num5 / 2.0);
			}
			if (class823_0.int_4 != 0 && i % class823_0.TickLabelSpacing == 0 && i < class823_0.arrayList_1.Count && flag)
			{
				string text = "";
				Color fontColor = @class.FontColor;
				if (!flag2)
				{
					text = smethod_28(class823_0, class823_0.arrayList_1[i]);
					fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], @class.imethod_0(), fontColor);
				}
				else
				{
					string text2 = "";
					bool flag3 = false;
					text2 = ((i < arrayList.Count) ? ((Class825)arrayList[i]).imethod_3() : "");
					flag3 = i < arrayList.Count && ((Class825)arrayList[i]).imethod_1();
					text = Struct51.smethod_5(chart.vmethod_2(), class823_0.arrayList_1[i], text2, flag3);
					fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], text2, fontColor);
				}
				float height = class823_0.float_2;
				Size size = Struct61.smethod_3(interface42_0, text, @class.Rotation, @class.Font, sizeF_, Enum82.const_1, Enum82.const_1);
				if ((float)size.Height < class823_0.float_2)
				{
					height = size.Height;
				}
				RectangleF value = new RectangleF((float)((double)num10 + num5 / 2.0 - (double)(class823_0.float_3 / 2f)), num, class823_0.float_3, height);
				if (@class.Rotation != 0 && @class.Rotation != 90 && @class.Rotation != -90)
				{
					smethod_39(chart.imethod_0(), text, new PointF(x, y), new SizeF(class823_0.float_3, height), @class.Rotation, @class.Font, fontColor, class823_0.method_0());
				}
				else
				{
					Enum82 enum82_2 = Enum82.const_1;
					Enum82 enum82_3 = Enum82.const_1;
					if (@class.Rotation != 90 && @class.Rotation != -90)
					{
						smethod_38(interface42_0, Rectangle.Round(value), text, @class.Rotation, @class.Font, fontColor, enum82_2, enum82_3);
					}
					else
					{
						Size size2 = Struct61.smethod_3(interface42_0, text, @class.Rotation, @class.Font, value.Size, enum82_2, enum82_3);
						SizeF sizeF = Struct61.smethod_12(interface42_0, text, @class.Font, new SizeF(value.Height, value.Width));
						RectangleF value2 = new RectangleF((float)((double)num10 + num5 / 2.0 - (double)(size2.Width / 2)), num, size2.Width, size2.Height);
						value2.Y -= ((float)size2.Height - sizeF.Width) / 2f;
						if (value2.Width < (float)size2.Height)
						{
							value2.Width = sizeF.Height + 1f;
						}
						smethod_38(interface42_0, Rectangle.Round(value2), text, @class.Rotation, @class.Font, fontColor, enum82_2, enum82_3);
					}
				}
			}
			if (i == 0)
			{
				float num11 = (class823_0.IsPlotOrderReversed ? ((float)rectangle_0.Right) : ((float)rectangle_0.X));
				if (num11 >= (float)rectangle_0.X && num11 <= (float)(rectangle_0.X + rectangle_0.Width))
				{
					smethod_6(interface42_0, class823_0, bool_0, num11, float_0, rectangle_0);
				}
				float num12 = num11;
				num12 = (class823_0.IsPlotOrderReversed ? (num12 + (float)(num5 * (double)class823_0.TickMarkSpacing / 2.0)) : (num12 - (float)(num5 * (double)class823_0.TickMarkSpacing / 2.0)));
				if (num12 > (float)rectangle_0.X && num12 < (float)(rectangle_0.X + rectangle_0.Width))
				{
					smethod_7(interface42_0, class823_0, bool_0, num12, float_0, rectangle_0);
				}
			}
			if ((i + 1) % class823_0.TickMarkSpacing == 0)
			{
				if (num9 >= (float)rectangle_0.X && num9 <= (float)(rectangle_0.X + rectangle_0.Width) && Math.Abs(num6 - num9) > (float)class823_0.method_5().Width / 2f)
				{
					smethod_6(interface42_0, class823_0, bool_0, num9, float_0, rectangle_0);
					num6 = num9;
				}
				float num13 = num9;
				num13 = (class823_0.IsPlotOrderReversed ? (num13 + (float)(num5 * (double)class823_0.TickMarkSpacing / 2.0)) : (num13 - (float)(num5 * (double)class823_0.TickMarkSpacing / 2.0)));
				if (num13 > (float)rectangle_0.X && num13 < (float)(rectangle_0.X + rectangle_0.Width) && Math.Abs(num7 - num13) > (float)class823_0.method_5().Width / 2f)
				{
					smethod_7(interface42_0, class823_0, bool_0, num13, float_0, rectangle_0);
					num7 = num13;
				}
			}
		}
		if (array == null || array.Length <= 0 || arrayList.Count <= 0 || class823_0.int_4 == 0)
		{
			return;
		}
		float num14 = (float)(array.Length + 1) * num2;
		IList list = array[0];
		Class825 class3 = (Class825)list[0];
		string string_ = Struct51.smethod_5(chart.vmethod_2(), class3.imethod_0(), class3.imethod_3(), class3.imethod_1());
		Size size3 = Struct61.smethod_2(class823_0.Chart.imethod_0(), string_, 0, @class.Font, rectangle_0.Size, Enum82.const_1, Enum82.const_1);
		float float_ = 0f;
		bool bool_2 = true;
		if (class823_0.int_4 == 1)
		{
			num = (float)rectangle_0.Bottom + num14 + class823_0.float_1;
			float_ = rectangle_0.Bottom;
			bool_2 = false;
		}
		else if (class823_0.int_4 == 2)
		{
			num = (float)rectangle_0.Y - num14 - class823_0.float_1;
			float_ = rectangle_0.Y;
			bool_2 = true;
		}
		else if (class823_0.int_4 == 3)
		{
			if (bool_0)
			{
				num = float_0 - num14 - class823_0.float_1 + (float)size3.Height;
				bool_2 = true;
			}
			else
			{
				num = float_0 + num14 + class823_0.float_1 - (float)size3.Height;
				bool_2 = false;
			}
			float_ = float_0;
		}
		float float_2 = (class823_0.IsPlotOrderReversed ? ((float)rectangle_0.Right) : ((float)rectangle_0.X));
		smethod_34(interface42_0, array, float_2, num, num2, bool_2, class823_0, num5, @class, enum82_, float_, rectangle_0, bool_1);
	}

	private static void smethod_6(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, float float_1, Rectangle rectangle_0)
	{
		Class823 @class = smethod_36(class823_0);
		bool flag = false;
		bool flag2 = false;
		switch (class823_0.MajorTickMark)
		{
		case Enum84.const_0:
			flag = true;
			flag2 = true;
			break;
		case Enum84.const_1:
			flag = true;
			if (bool_0)
			{
				flag = false;
				flag2 = true;
			}
			if (@class.bool_11)
			{
				if (bool_0)
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					flag = false;
					flag2 = true;
				}
			}
			break;
		case Enum84.const_3:
			flag2 = true;
			if (bool_0)
			{
				flag2 = false;
				flag = true;
			}
			if (@class.bool_11)
			{
				if (!bool_0)
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					flag = false;
					flag2 = true;
				}
			}
			break;
		}
		if (flag)
		{
			class823_0.method_5().method_7(float_0, float_1 - (float)class823_0.method_19(), float_0, float_1);
		}
		if (flag2)
		{
			class823_0.method_5().method_7(float_0, float_1, float_0, float_1 + (float)class823_0.method_19());
		}
	}

	private static void smethod_7(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, float float_1, Rectangle rectangle_0)
	{
		Class823 @class = smethod_36(class823_0);
		bool flag = false;
		bool flag2 = false;
		switch (class823_0.MinorTickMark)
		{
		case Enum84.const_0:
			flag = true;
			flag2 = true;
			break;
		case Enum84.const_1:
			flag = true;
			if (bool_0)
			{
				flag = false;
				flag2 = true;
			}
			if (@class.bool_11)
			{
				if (bool_0)
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					flag = false;
					flag2 = true;
				}
			}
			break;
		case Enum84.const_3:
			flag2 = true;
			if (bool_0)
			{
				flag2 = false;
				flag = true;
			}
			if (@class.bool_11)
			{
				if (!bool_0)
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					flag = false;
					flag2 = true;
				}
			}
			break;
		}
		if (flag)
		{
			class823_0.method_5().method_7(float_0, float_1 - (float)class823_0.method_21(), float_0, float_1);
		}
		if (flag2)
		{
			class823_0.method_5().method_7(float_0, float_1, float_0, float_1 + (float)class823_0.method_21());
		}
	}

	private static void smethod_8(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, Rectangle rectangle_0)
	{
		ArrayList arrayList_ = class823_0.arrayList_1;
		Class821 chart = class823_0.Chart;
		class823_0.method_5().method_7(rectangle_0.X, float_0, rectangle_0.Right, float_0);
		float y = 0f;
		float num = class823_0.method_10().method_1();
		if (class823_0.int_4 != 0)
		{
			num += (float)class823_0.method_19();
		}
		float y2 = 0f;
		if (class823_0.int_4 == 1)
		{
			y = (float)rectangle_0.Bottom + num;
			y2 = (float)rectangle_0.Bottom + num;
		}
		else if (class823_0.int_4 == 2)
		{
			y = (float)rectangle_0.Y - num - class823_0.float_2;
			y2 = (float)rectangle_0.Y - num;
		}
		else if (class823_0.int_4 == 3)
		{
			if (bool_0)
			{
				y = float_0 - num - class823_0.float_2;
				y2 = float_0 - num;
			}
			else
			{
				y = float_0 + num;
				y2 = float_0 + num;
			}
		}
		Class847 @class = class823_0.method_10();
		ArrayList arrayList;
		ArrayList[] array;
		if (class823_0.method_4() == Enum61.const_0)
		{
			arrayList = chart.method_7().method_0();
			array = chart.method_7().method_4();
		}
		else
		{
			arrayList = chart.method_7().method_2();
			array = chart.method_7().method_7();
		}
		bool flag = false;
		if (@class.LinkedSource && arrayList.Count > 0)
		{
			flag = true;
		}
		if (array != null && array.Length > 0 && arrayList.Count > 0)
		{
			flag = true;
		}
		int num2 = 0;
		int int_ = (int)class823_0.MaxValue;
		int num3 = (int)class823_0.MinValue;
		Enum87 baseUnitScale = class823_0.BaseUnitScale;
		if (!chart.method_1().AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num2 = smethod_29(baseUnitScale, int_, num3, class823_0.Chart.vmethod_0());
			if (num2 == 0)
			{
				num2 = 1;
			}
		}
		else
		{
			num2 = smethod_29(baseUnitScale, int_, num3, class823_0.Chart.vmethod_0()) + 1;
		}
		double num4 = (double)rectangle_0.Width / (double)num2;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		num8 = ((!class823_0.IsPlotOrderReversed) ? ((float)rectangle_0.X) : ((float)(rectangle_0.X + rectangle_0.Width)));
		SizeF sizeF_ = new SizeF(class823_0.float_0, class823_0.float_2);
		for (int i = 0; i < arrayList_.Count; i++)
		{
			int num9 = Convert.ToInt32(class823_0.arrayList_1[i]);
			int num10 = smethod_29(baseUnitScale, num9, num3, class823_0.Chart.vmethod_0());
			float num11 = (float)(num4 * (double)num10);
			num5 = (float)(num4 * (double)smethod_29(baseUnitScale, smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, num9, class823_0.Chart.vmethod_0()), num9, class823_0.Chart.vmethod_0()));
			if (class823_0.AxisBetweenCategories || chart.IsDataTableShown)
			{
				num11 += (float)(num4 / 2.0);
			}
			if (class823_0.IsPlotOrderReversed)
			{
				num6 = (float)(rectangle_0.X + rectangle_0.Width) - num11;
				num7 = num6;
				num8 -= num5;
			}
			else
			{
				num6 = (float)rectangle_0.X + num11;
				num7 = num6;
				num8 += num5;
			}
			if (class823_0.int_4 != 0 && i % class823_0.TickLabelSpacing == 0)
			{
				string text = "";
				Color fontColor = @class.FontColor;
				if (!flag)
				{
					text = smethod_28(class823_0, class823_0.arrayList_1[i]);
					fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], @class.imethod_0(), fontColor);
				}
				else
				{
					string text2 = "";
					bool flag2 = false;
					text2 = ((i < arrayList.Count) ? ((Class825)arrayList[i]).imethod_3() : "");
					flag2 = i < arrayList.Count && ((Class825)arrayList[i]).imethod_1();
					text = Struct51.smethod_5(chart.vmethod_2(), class823_0.arrayList_1[i], text2, flag2);
					fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], text2, fontColor);
				}
				float height = class823_0.float_2;
				Size size = Struct61.smethod_3(interface42_0, text, @class.Rotation, @class.Font, sizeF_, Enum82.const_1, Enum82.const_1);
				if ((float)size.Height < class823_0.float_2)
				{
					height = size.Height;
				}
				RectangleF value = new RectangleF(num6 - class823_0.float_0 / 2f, y, class823_0.float_0, height);
				if (@class.Rotation != 0 && @class.Rotation != 90 && @class.Rotation != -90)
				{
					smethod_39(interface42_0, text, new PointF(num7, y2), new SizeF(class823_0.float_0, height), @class.Rotation, @class.Font, fontColor, class823_0.method_0());
				}
				else
				{
					smethod_38(interface42_0, Rectangle.Round(value), text, @class.Rotation, @class.Font, fontColor, Enum82.const_1, Enum82.const_1);
				}
			}
			if (i % class823_0.TickMarkSpacing == 0 && num8 >= (float)rectangle_0.X && num8 <= (float)(rectangle_0.X + rectangle_0.Width))
			{
				smethod_6(interface42_0, class823_0, bool_0, num8, float_0, rectangle_0);
			}
		}
		float num12 = ((!class823_0.IsPlotOrderReversed) ? ((float)rectangle_0.X) : ((float)(rectangle_0.X + rectangle_0.Width)));
		int int_2 = num3;
		int num13 = smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, num3, class823_0.Chart.vmethod_0());
		do
		{
			bool flag3 = true;
			int num14 = smethod_31(class823_0.BaseUnitScale, class823_0.MinorUnitScale, (int)class823_0.MinorUnit, int_2, class823_0.Chart.vmethod_0());
			if (num14 == num13)
			{
				flag3 = false;
				num13 = smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, num13, class823_0.Chart.vmethod_0());
			}
			if (num14 >= num13)
			{
				num13 = smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, num13, class823_0.Chart.vmethod_0());
			}
			float num15 = (float)(num4 * (double)smethod_29(baseUnitScale, num14, int_2, class823_0.Chart.vmethod_0()));
			num12 = ((!class823_0.IsPlotOrderReversed) ? (num12 + num15) : (num12 - num15));
			if (flag3 && num12 >= (float)rectangle_0.X && num12 <= (float)(rectangle_0.X + rectangle_0.Width))
			{
				smethod_7(interface42_0, class823_0, bool_0, num12, float_0, rectangle_0);
			}
			int_2 = num14;
		}
		while (num12 >= (float)rectangle_0.X && num12 <= (float)(rectangle_0.X + rectangle_0.Width));
	}

	internal static void smethod_9(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, Rectangle rectangle_0, Class844 class844_0)
	{
		if (Struct63.smethod_18(rectangle_0))
		{
			return;
		}
		ChartType_Chart chartType_Chart_ = class844_0.method_22();
		Class821 chart = class823_0.Chart;
		Class847 @class = class823_0.method_10();
		Class831 class2 = class844_0.method_9().method_1(0);
		string string_ = class2.vmethod_6();
		bool bool_ = class2.vmethod_7();
		bool flag = false;
		if (@class.LinkedSource && class2 != null)
		{
			flag = true;
		}
		class823_0.method_5().method_7(rectangle_0.X, float_0, rectangle_0.Right, float_0);
		Class833 class3 = class823_0.method_12();
		float num = 0f;
		float num2 = 2 * class823_0.method_19();
		float num3 = class823_0.float_0 / 2f;
		if (class823_0.int_4 == 1)
		{
			num = rectangle_0.Bottom;
			num += num2;
			class3.method_2().rectangle_1.Y = (int)(num + class823_0.float_1);
		}
		else if (class823_0.int_4 == 2)
		{
			num = (float)rectangle_0.Y - class823_0.float_1;
			class3.method_2().rectangle_1.Y = (int)num - class3.method_2().Height;
		}
		else if (class823_0.int_4 == 3)
		{
			if (bool_0)
			{
				num = float_0 - class823_0.float_1;
				class3.method_2().rectangle_1.Y = (int)num - class3.method_2().Height;
			}
			else
			{
				num = float_0;
				num += num2;
				class3.method_2().rectangle_1.Y = (int)(num + class823_0.float_1);
			}
		}
		class3.method_2().rectangle_1.X = rectangle_0.Right - class3.method_2().rectangle_1.Width;
		if (!class823_0.IsPlotOrderReversed)
		{
			for (int i = 0; i < class823_0.arrayList_1.Count; i++)
			{
				double num4 = (double)class823_0.arrayList_1[i];
				if (i - 1 > 0)
				{
					int int_ = Struct63.smethod_8(new double[2]
					{
						num4,
						(double)class823_0.arrayList_1[i - 1]
					});
					if (Math.Abs(Struct63.smethod_9(num4, (double)class823_0.arrayList_1[i - 1])) != Struct63.smethod_10(class823_0.MajorUnit, int_))
					{
						continue;
					}
				}
				else if (i + 1 < class823_0.arrayList_1.Count)
				{
					int int_2 = Struct63.smethod_8(new double[2]
					{
						num4,
						(double)class823_0.arrayList_1[i + 1]
					});
					if (Math.Abs(Struct63.smethod_9(num4, (double)class823_0.arrayList_1[i + 1])) != Struct63.smethod_10(class823_0.MajorUnit, int_2))
					{
						continue;
					}
				}
				float num5 = (float)((double)rectangle_0.X + (num4 - class823_0.MinValue) / (class823_0.MaxValue - class823_0.MinValue) * (double)rectangle_0.Width);
				if (class823_0.int_4 != 0)
				{
					if (Struct47.smethod_56(chartType_Chart_))
					{
						num4 /= 100.0;
						string_ = "0%";
					}
					string text = "";
					Color fontColor = @class.FontColor;
					num4 *= Math.Pow(10.0, (double)class823_0.method_12().vmethod_0());
					if (flag)
					{
						text = Struct51.smethod_5(chart.vmethod_2(), num4, string_, bool_);
						fontColor = Struct51.smethod_6(num4, string_, fontColor);
					}
					else
					{
						text = smethod_28(class823_0, num4);
						fontColor = Struct51.smethod_6(num4, @class.imethod_0(), fontColor);
					}
					RectangleF value = new RectangleF(num5 - num3, num, class823_0.float_0, class823_0.float_1 - num2);
					smethod_37(interface42_0, Rectangle.Round(value), text, @class.Rotation, @class.Font, fontColor, Enum82.const_1, Enum82.const_1);
				}
				smethod_6(interface42_0, class823_0, bool_0, num5, float_0, rectangle_0);
			}
		}
		else
		{
			for (int num6 = class823_0.arrayList_1.Count - 1; num6 >= 0; num6--)
			{
				double num7 = (double)class823_0.arrayList_1[num6];
				if (num6 - 1 > 0)
				{
					int int_3 = Struct63.smethod_8(new double[2]
					{
						num7,
						(double)class823_0.arrayList_1[num6 - 1]
					});
					if (Math.Abs(Struct63.smethod_9(num7, (double)class823_0.arrayList_1[num6 - 1])) != Struct63.smethod_10(class823_0.MajorUnit, int_3))
					{
						continue;
					}
				}
				else if (num6 + 1 < class823_0.arrayList_1.Count)
				{
					int int_4 = Struct63.smethod_8(new double[2]
					{
						num7,
						(double)class823_0.arrayList_1[num6 + 1]
					});
					if (Math.Abs(Struct63.smethod_9(num7, (double)class823_0.arrayList_1[num6 + 1])) != Struct63.smethod_10(class823_0.MajorUnit, int_4))
					{
						continue;
					}
				}
				float num8 = (float)((double)rectangle_0.X + (class823_0.MaxValue - num7) / (class823_0.MaxValue - class823_0.MinValue) * (double)rectangle_0.Width);
				if (class823_0.int_4 != 0)
				{
					if (Struct47.smethod_56(chartType_Chart_))
					{
						num7 /= 100.0;
						string_ = "0%";
					}
					string text2 = "";
					Color fontColor2 = @class.FontColor;
					num7 *= Math.Pow(10.0, (double)class823_0.method_12().vmethod_0());
					if (flag)
					{
						text2 = Struct51.smethod_5(chart.vmethod_2(), num7, string_, bool_);
						fontColor2 = Struct51.smethod_6(num7, string_, fontColor2);
					}
					else
					{
						text2 = smethod_28(class823_0, num7);
						fontColor2 = Struct51.smethod_6(num7, @class.imethod_0(), fontColor2);
					}
					RectangleF value2 = new RectangleF(num8 - num3, num, class823_0.float_0, class823_0.float_1 - num2);
					smethod_37(interface42_0, Rectangle.Round(value2), text2, @class.Rotation, @class.Font, fontColor2, Enum82.const_1, Enum82.const_1);
				}
				smethod_6(interface42_0, class823_0, bool_0, num8, float_0, rectangle_0);
			}
		}
		smethod_10(interface42_0, class823_0, bool_0, float_0, rectangle_0.X, rectangle_0.Right, rectangle_0);
		class3.method_3();
	}

	private static void smethod_10(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, float float_1, float float_2, Rectangle rectangle_0)
	{
		if (class823_0.MinorTickMark == Enum84.const_2)
		{
			return;
		}
		Class823 @class = smethod_36(class823_0);
		bool flag = false;
		bool flag2 = false;
		switch (class823_0.MinorTickMark)
		{
		case Enum84.const_0:
			flag = true;
			flag2 = true;
			break;
		case Enum84.const_1:
			flag = true;
			if (bool_0)
			{
				flag = false;
				flag2 = true;
			}
			if (@class.bool_11)
			{
				if (bool_0)
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					flag = false;
					flag2 = true;
				}
			}
			break;
		case Enum84.const_3:
			flag2 = true;
			if (bool_0)
			{
				flag2 = false;
				flag = true;
			}
			if (@class.bool_11)
			{
				if (!bool_0)
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					flag = false;
					flag2 = true;
				}
			}
			break;
		}
		float num = (float)(class823_0.MinorUnit / (class823_0.MaxValue - class823_0.MinValue) * (double)(float_2 - float_1));
		float num2;
		if (class823_0.IsPlotOrderReversed)
		{
			num2 = float_2;
			num = 0f - num;
		}
		else
		{
			num2 = float_1;
		}
		float num3 = num2;
		do
		{
			if (flag)
			{
				class823_0.method_5().method_7(num3, float_0, num3, float_0 - (float)class823_0.method_21());
			}
			if (flag2)
			{
				class823_0.method_5().method_7(num3, float_0, num3, float_0 + (float)class823_0.method_21());
			}
			num3 += num;
		}
		while (float_1 <= num3 && num3 <= float_2);
	}

	internal static void smethod_11(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, Rectangle rectangle_0, int int_0)
	{
		if (Struct63.smethod_18(rectangle_0))
		{
			return;
		}
		if (class823_0.CategoryType == Enum64.const_2)
		{
			smethod_15(interface42_0, class823_0, bool_0, float_0, rectangle_0);
			return;
		}
		class823_0.method_5().method_7(float_0, rectangle_0.Y, float_0, rectangle_0.Bottom);
		Class821 chart = class823_0.Chart;
		float num = 0f;
		float x = 0f;
		float num2 = class823_0.method_19() + class823_0.method_21() + class823_0.method_10().method_1();
		float num3 = class823_0.float_1 / 2f;
		Enum82 enum82_ = Enum82.const_8;
		float num4 = 0f;
		if (class823_0.method_10().Rotation == 0)
		{
			num4 = class823_0.float_1;
		}
		else if (Math.Abs(class823_0.method_10().Rotation) == 90)
		{
			num4 = class823_0.float_0;
		}
		if (num4 > (float)class823_0.method_10().Font.Height * 1.5f)
		{
			enum82_ = Enum82.const_1;
		}
		if (class823_0.int_4 == 1)
		{
			num = (float)rectangle_0.X - class823_0.float_3 - num2;
			x = (float)rectangle_0.X - num2;
		}
		else if (class823_0.int_4 == 2)
		{
			num = (float)rectangle_0.Right + num2;
			x = (float)rectangle_0.Right + num2;
			enum82_ = Enum82.const_7;
		}
		else if (class823_0.int_4 == 3)
		{
			if (bool_0)
			{
				num = float_0 + num2;
				x = float_0 + num2;
				enum82_ = Enum82.const_7;
			}
			else
			{
				num = float_0 - num2 - class823_0.float_3;
				x = float_0 - num2;
			}
		}
		int num5 = 0;
		if (!class823_0.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num5 = int_0 - 1;
			if (num5 == 0)
			{
				num5 = 1;
			}
		}
		else
		{
			num5 = int_0;
		}
		double num6 = (double)rectangle_0.Height / (double)num5;
		Class847 @class = class823_0.method_10();
		ArrayList arrayList;
		ArrayList[] array;
		if (class823_0.method_4() == Enum61.const_0)
		{
			arrayList = chart.method_7().method_0();
			array = chart.method_7().method_4();
		}
		else
		{
			arrayList = chart.method_7().method_2();
			array = chart.method_7().method_7();
		}
		bool flag = false;
		if (@class.LinkedSource && arrayList.Count > 0)
		{
			flag = true;
		}
		for (int i = 0; i < int_0; i++)
		{
			double num7 = (double)(i + 1) * num6;
			if (class823_0.AxisBetweenCategories || class823_0.Chart.IsDataTableShown)
			{
				num7 += num6 / 2.0;
			}
			float num8;
			float num9;
			float y;
			if (class823_0.IsPlotOrderReversed)
			{
				num8 = (float)((double)rectangle_0.Y + (double)(i + 1) * num6);
				num9 = (float)((double)rectangle_0.Y + num7 - num6);
				y = (float)((double)rectangle_0.Y + num7 - num6);
			}
			else
			{
				num8 = (float)((double)(rectangle_0.Y + rectangle_0.Height) - (double)(i + 1) * num6);
				num9 = (float)((double)(rectangle_0.Y + rectangle_0.Height) - num7 + num6);
				y = (float)((double)(rectangle_0.Y + rectangle_0.Height) - num7 + num6);
			}
			if (class823_0.int_4 != 0 && i % class823_0.TickLabelSpacing == 0 && i < class823_0.arrayList_1.Count)
			{
				string text = "";
				Color fontColor = @class.FontColor;
				if (!flag)
				{
					text = smethod_28(class823_0, class823_0.arrayList_1[i]);
					fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], @class.imethod_0(), fontColor);
				}
				else
				{
					string text2 = "";
					bool flag2 = false;
					text2 = ((i < arrayList.Count) ? ((Class825)arrayList[i]).imethod_3() : "");
					flag2 = i < arrayList.Count && ((Class825)arrayList[i]).imethod_1();
					text = Struct51.smethod_5(chart.vmethod_2(), class823_0.arrayList_1[i], text2, flag2);
					fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], text2, fontColor);
				}
				RectangleF value = new RectangleF(num, num9 - num3, class823_0.float_3, class823_0.float_2);
				if (@class.Rotation != 0 && @class.Rotation != 90 && @class.Rotation != -90)
				{
					smethod_39(interface42_0, text, new PointF(x, y), new SizeF(class823_0.float_3, class823_0.float_2), @class.Rotation, @class.Font, fontColor, class823_0.method_0());
				}
				else
				{
					smethod_37(interface42_0, Rectangle.Round(value), text, @class.Rotation, @class.Font, fontColor, enum82_, Enum82.const_1);
				}
			}
			if (i == 0)
			{
				float num10 = ((!class823_0.IsPlotOrderReversed) ? ((float)rectangle_0.Bottom) : ((float)rectangle_0.Y));
				if (num10 >= (float)rectangle_0.Y && num10 <= (float)(rectangle_0.Y + rectangle_0.Height))
				{
					smethod_3(interface42_0, class823_0, bool_0, float_0, num10);
				}
				float num11 = num10;
				num11 = (class823_0.IsPlotOrderReversed ? (num11 - (float)(num6 * (double)class823_0.TickMarkSpacing / 2.0)) : (num11 + (float)(num6 * (double)class823_0.TickMarkSpacing / 2.0)));
				if (num11 >= (float)rectangle_0.Y && num11 <= (float)(rectangle_0.Y + rectangle_0.Height))
				{
					smethod_14(interface42_0, class823_0, bool_0, float_0, num11, rectangle_0);
				}
			}
			if ((i + 1) % class823_0.TickMarkSpacing == 0)
			{
				if (num8 >= (float)rectangle_0.Y && num8 <= (float)(rectangle_0.Y + rectangle_0.Height))
				{
					smethod_3(interface42_0, class823_0, bool_0, float_0, num8);
				}
				float num12 = num8;
				num12 = (class823_0.IsPlotOrderReversed ? (num12 - (float)(num6 * (double)class823_0.TickMarkSpacing / 2.0)) : (num12 + (float)(num6 * (double)class823_0.TickMarkSpacing / 2.0)));
				if (num12 >= (float)rectangle_0.Y && num12 <= (float)(rectangle_0.Y + rectangle_0.Height))
				{
					smethod_14(interface42_0, class823_0, bool_0, float_0, num12, rectangle_0);
				}
			}
		}
		if (array == null || array.Length <= 0 || arrayList.Count <= 0 || class823_0.int_4 == 0)
		{
			return;
		}
		float num13 = num2 * (float)(array.Length + 1);
		bool bool_ = false;
		float float_ = rectangle_0.X;
		if (class823_0.int_4 == 1)
		{
			num = (float)rectangle_0.X - class823_0.float_0 - num13;
			bool_ = true;
			float_ = rectangle_0.X;
		}
		else if (class823_0.int_4 == 2)
		{
			num = (float)rectangle_0.Right + num13 + class823_0.float_0;
			bool_ = false;
			float_ = rectangle_0.Right;
		}
		else if (class823_0.int_4 == 3)
		{
			if (bool_0)
			{
				num = float_0 + num13 + class823_0.float_0;
				bool_ = false;
			}
			else
			{
				num = float_0 - num13 - class823_0.float_0;
				bool_ = true;
			}
			float_ = float_0;
		}
		smethod_12(float_3: class823_0.IsPlotOrderReversed ? ((float)rectangle_0.Y) : ((float)rectangle_0.Bottom), interface42_0: interface42_0, arrayList_0: array, bool_0: bool_, class823_0: class823_0, class847_0: @class, double_0: num6, rectangle_0: rectangle_0, float_0: num2, float_1: float_, float_2: num);
	}

	private static void smethod_12(Interface42 interface42_0, ArrayList[] arrayList_0, bool bool_0, Class823 class823_0, Class847 class847_0, double double_0, Rectangle rectangle_0, float float_0, float float_1, float float_2, float float_3)
	{
		Class821 chart = class823_0.Chart;
		float num = float_3;
		for (int i = 0; i < arrayList_0.Length; i++)
		{
			Size size = new Size(0, 0);
			IList list = arrayList_0[i];
			for (int j = 0; j < list.Count; j++)
			{
				Class825 @class = (Class825)list[j];
				int num2 = smethod_33(@class);
				float num3 = (float)((double)num2 * double_0);
				string string_ = Struct51.smethod_5(chart.vmethod_2(), @class.imethod_0(), @class.imethod_3(), @class.imethod_1());
				size = Struct61.smethod_3(class823_0.Chart.imethod_0(), string_, 90, class847_0.Font, new SizeF(rectangle_0.Size.Width, rectangle_0.Size.Height), Enum82.const_1, Enum82.const_1);
				float x = (bool_0 ? float_2 : (float_2 - (float)size.Width));
				float y = (class823_0.IsPlotOrderReversed ? (float_3 + num3 / 2f - (float)(size.Height / 2)) : (float_3 - num3 / 2f - (float)(size.Height / 2)));
				RectangleF value = new RectangleF(x, y, size.Width, size.Height);
				smethod_37(interface42_0, Rectangle.Round(value), string_, 90, class847_0.Font, class847_0.FontColor, Enum82.const_1, Enum82.const_9);
				class823_0.method_5().method_7(float_1, float_3, float_2, float_3);
				if (class823_0.MajorTickMark != Enum84.const_2)
				{
					float float_4 = (bool_0 ? (float_2 + (float_0 + (float)size.Width)) : (float_2 - (float_0 + (float)size.Width)));
					smethod_13(interface42_0, @class.imethod_9(), float_1, float_4, float_3, class823_0, double_0);
				}
				float_3 = (class823_0.IsPlotOrderReversed ? (float_3 + num3) : (float_3 - num3));
			}
			class823_0.method_5().method_7(float_1, float_3, float_2, float_3);
			float_3 = num;
			float_2 = (bool_0 ? (float_2 + (float)size.Width + float_0) : (float_2 - (float)size.Width - float_0));
		}
	}

	private static void smethod_13(Interface42 interface42_0, Interface10 interface10_0, float float_0, float float_1, float float_2, Class823 class823_0, double double_0)
	{
		float num = float_2;
		for (int i = 0; i < interface10_0.Count; i++)
		{
			Class825 interface11_ = (Class825)interface10_0[i];
			int num2 = smethod_33(interface11_);
			float num3 = (float)((double)num2 * double_0);
			num = (class823_0.IsPlotOrderReversed ? (num + num3) : (num - num3));
			class823_0.method_5().method_7(float_0, num, float_1, num);
		}
	}

	private static void smethod_14(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, float float_1, Rectangle rectangle_0)
	{
		Class823 @class = smethod_36(class823_0);
		bool flag = false;
		bool flag2 = false;
		switch (class823_0.MinorTickMark)
		{
		case Enum84.const_0:
			flag = true;
			flag2 = true;
			break;
		case Enum84.const_1:
			flag = true;
			if (bool_0)
			{
				flag = false;
				flag2 = true;
			}
			if (@class.bool_11)
			{
				if (bool_0)
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					flag = false;
					flag2 = true;
				}
			}
			break;
		case Enum84.const_3:
			flag2 = true;
			if (bool_0)
			{
				flag2 = false;
				flag = true;
			}
			if (@class.bool_11)
			{
				if (!bool_0)
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					flag = false;
					flag2 = true;
				}
			}
			break;
		}
		if (flag)
		{
			class823_0.method_5().method_7(float_0, float_1, float_0 + (float)class823_0.method_21(), float_1);
		}
		if (flag2)
		{
			class823_0.method_5().method_7(float_0 - (float)class823_0.method_21(), float_1, float_0, float_1);
		}
	}

	private static void smethod_15(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, Rectangle rectangle_0)
	{
		ArrayList arrayList_ = class823_0.arrayList_1;
		Class821 chart = class823_0.Chart;
		class823_0.method_5().method_7(float_0, rectangle_0.Y, float_0, rectangle_0.Bottom);
		float x = 0f;
		float num = class823_0.method_10().method_1();
		Enum82 enum82_ = Enum82.const_8;
		if (class823_0.int_4 == 1)
		{
			x = (float)rectangle_0.X - class823_0.float_0 - num;
		}
		else if (class823_0.int_4 == 2)
		{
			x = (float)rectangle_0.Right + num;
			enum82_ = Enum82.const_7;
		}
		else if (class823_0.int_4 == 3)
		{
			if (bool_0)
			{
				x = float_0 + num;
				enum82_ = Enum82.const_7;
			}
			else
			{
				x = float_0 - num - class823_0.float_0;
			}
		}
		Class847 @class = class823_0.method_10();
		ArrayList arrayList;
		ArrayList[] array;
		if (class823_0.method_4() == Enum61.const_0)
		{
			arrayList = chart.method_7().method_0();
			array = chart.method_7().method_4();
		}
		else
		{
			arrayList = chart.method_7().method_2();
			array = chart.method_7().method_7();
		}
		bool flag = false;
		if (@class.LinkedSource && arrayList.Count > 0)
		{
			flag = true;
		}
		if (array != null && array.Length > 0 && arrayList.Count > 0)
		{
			flag = true;
		}
		int num2 = 0;
		int int_ = (int)class823_0.MaxValue;
		int num3 = (int)class823_0.MinValue;
		Enum87 baseUnitScale = class823_0.BaseUnitScale;
		if (!chart.method_1().AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num2 = smethod_29(baseUnitScale, int_, num3, class823_0.Chart.vmethod_0());
			if (num2 == 0)
			{
				num2 = 1;
			}
		}
		else
		{
			num2 = smethod_29(baseUnitScale, int_, num3, class823_0.Chart.vmethod_0()) + 1;
		}
		double num4 = (double)rectangle_0.Height / (double)num2;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		num7 = ((!class823_0.IsPlotOrderReversed) ? ((float)(rectangle_0.Y + rectangle_0.Height)) : ((float)rectangle_0.Y));
		for (int i = 0; i < arrayList_.Count; i++)
		{
			int num8 = Convert.ToInt32(class823_0.arrayList_1[i]);
			int num9 = smethod_29(baseUnitScale, num8, num3, class823_0.Chart.vmethod_0());
			float num10 = (float)(num4 * (double)num9);
			num5 = (float)(num4 * (double)smethod_29(baseUnitScale, smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, num8, class823_0.Chart.vmethod_0()), num8, class823_0.Chart.vmethod_0()));
			if (class823_0.AxisBetweenCategories || chart.IsDataTableShown)
			{
				num10 += (float)(num4 / 2.0);
			}
			if (class823_0.IsPlotOrderReversed)
			{
				num7 += num5;
				num6 = (float)rectangle_0.Y + num10;
			}
			else
			{
				num7 -= num5;
				num6 = (float)(rectangle_0.Y + rectangle_0.Height) - num10;
			}
			num6 -= class823_0.float_1 / 2f;
			if (class823_0.int_4 != 0 && i % class823_0.TickLabelSpacing == 0)
			{
				string text = "";
				Color fontColor = @class.FontColor;
				if (!flag)
				{
					text = smethod_28(class823_0, class823_0.arrayList_1[i]);
					fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], @class.imethod_0(), fontColor);
				}
				else
				{
					string text2 = "";
					bool flag2 = false;
					text2 = ((i < arrayList.Count) ? ((Class825)arrayList[i]).imethod_3() : "");
					flag2 = i < arrayList.Count && ((Class825)arrayList[i]).imethod_1();
					text = Struct51.smethod_5(chart.vmethod_2(), class823_0.arrayList_1[i], text2, flag2);
					fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], text2, fontColor);
				}
				RectangleF value = new RectangleF(x, num6, class823_0.float_0, class823_0.float_1);
				smethod_37(interface42_0, Rectangle.Round(value), text, @class.Rotation, @class.Font, fontColor, enum82_, Enum82.const_1);
			}
			if (i % class823_0.TickMarkSpacing == 0 && num7 >= (float)rectangle_0.Y && num7 <= (float)(rectangle_0.Y + rectangle_0.Height))
			{
				smethod_3(interface42_0, class823_0, bool_0, float_0, num7);
			}
		}
		float num11 = ((!class823_0.IsPlotOrderReversed) ? ((float)(rectangle_0.Y + rectangle_0.Height)) : ((float)rectangle_0.Y));
		int int_2 = num3;
		int num12 = smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, num3, class823_0.Chart.vmethod_0());
		do
		{
			bool flag3 = true;
			int num13 = smethod_31(class823_0.BaseUnitScale, class823_0.MinorUnitScale, (int)class823_0.MinorUnit, int_2, class823_0.Chart.vmethod_0());
			if (num13 == num12)
			{
				flag3 = false;
				num12 = smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, num12, class823_0.Chart.vmethod_0());
			}
			if (num13 >= num12)
			{
				num12 = smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, num12, class823_0.Chart.vmethod_0());
			}
			float num14 = (float)(num4 * (double)smethod_29(baseUnitScale, num13, int_2, class823_0.Chart.vmethod_0()));
			num11 = ((!class823_0.IsPlotOrderReversed) ? (num11 - num14) : (num11 + num14));
			if (flag3 && num11 >= (float)rectangle_0.Y && num11 <= (float)(rectangle_0.Y + rectangle_0.Height))
			{
				smethod_14(interface42_0, class823_0, bool_0, float_0, num11, rectangle_0);
			}
			int_2 = num13;
		}
		while (num11 >= (float)rectangle_0.Y && num11 <= (float)(rectangle_0.Y + rectangle_0.Height));
	}

	internal static void smethod_16(Interface42 interface42_0, Class823 class823_0, bool bool_0, float float_0, Rectangle rectangle_0, Class844 class844_0)
	{
		if (Struct63.smethod_18(rectangle_0))
		{
			return;
		}
		class823_0.method_5().method_7(rectangle_0.X, float_0, rectangle_0.Right, float_0);
		Class821 chart = class823_0.Chart;
		Class833 @class = class823_0.method_12();
		float num = 0f;
		float num2 = class823_0.method_10().method_1();
		if (class823_0.int_4 == 1)
		{
			num = (float)rectangle_0.Bottom + num2;
			@class.method_2().rectangle_1.Y = (int)(num + class823_0.float_1);
		}
		else if (class823_0.int_4 == 2)
		{
			num = (float)rectangle_0.Y - num2 - class823_0.float_1;
			@class.method_2().rectangle_1.Y = (int)num - @class.method_2().rectangle_1.Height;
		}
		else if (class823_0.int_4 == 3)
		{
			if (bool_0)
			{
				num = float_0 - num2 - class823_0.float_1;
				@class.method_2().rectangle_1.Y = (int)num - @class.method_2().rectangle_1.Height;
			}
			else
			{
				num = float_0 + num2;
				@class.method_2().rectangle_1.Y = (int)(num + class823_0.float_1);
			}
		}
		@class.method_2().rectangle_1.X = rectangle_0.Right - @class.method_2().rectangle_1.Width;
		Class847 class2 = class823_0.method_10();
		Class831 class3 = class844_0.method_9().method_1(0);
		string string_ = class3.imethod_10();
		bool bool_ = class3.imethod_12();
		bool flag = false;
		if (class2.LinkedSource && class3 != null)
		{
			flag = true;
		}
		ArrayList arrayList_ = class823_0.arrayList_1;
		double num3 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MaxValue) : class823_0.MaxValue);
		double num4 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MinValue) : class823_0.MinValue);
		double num5 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MajorUnit) : class823_0.MajorUnit);
		if (!class823_0.IsPlotOrderReversed)
		{
			for (int i = 0; i < arrayList_.Count; i++)
			{
				double num6 = Convert.ToDouble(arrayList_[i]);
				double num7 = (class823_0.IsLogarithmic ? class823_0.method_7(num6) : num6);
				if (i - 1 > 0)
				{
					if (Math.Abs(Struct63.smethod_9(num6, Convert.ToDouble(arrayList_[i - 1]))) != num5)
					{
						continue;
					}
				}
				else if (i + 1 < arrayList_.Count && Math.Abs(Struct63.smethod_9(num6, Convert.ToDouble(arrayList_[i + 1]))) != num5)
				{
					continue;
				}
				float num8 = (float)((double)rectangle_0.X + (num6 - num4) / (num3 - num4) * (double)rectangle_0.Width);
				if (class823_0.int_4 != 0)
				{
					string text = "";
					Color fontColor = class2.FontColor;
					num7 = (class823_0.IsLogarithmic ? num7 : (num7 * Math.Pow(10.0, (double)class823_0.method_12().vmethod_0())));
					if (flag)
					{
						text = Struct51.smethod_5(chart.vmethod_2(), num7, string_, bool_);
						fontColor = Struct51.smethod_6(num7, string_, fontColor);
					}
					else
					{
						text = smethod_28(class823_0, num7);
						fontColor = Struct51.smethod_6(num7, class2.imethod_0(), fontColor);
					}
					RectangleF value = new RectangleF(num8 - class823_0.float_0 / 2f, num, class823_0.float_0, class823_0.float_1);
					smethod_37(interface42_0, Rectangle.Round(value), text, class2.Rotation, class2.Font, fontColor, Enum82.const_1, Enum82.const_1);
				}
				smethod_6(interface42_0, class823_0, bool_0, num8, float_0, rectangle_0);
			}
		}
		else
		{
			for (int num9 = arrayList_.Count - 1; num9 >= 0; num9--)
			{
				double num10 = Convert.ToDouble(arrayList_[num9]);
				double num11 = (class823_0.IsLogarithmic ? class823_0.method_7(num10) : num10);
				if (num9 - 1 > 0)
				{
					if (Math.Abs(Struct63.smethod_9(num10, Convert.ToDouble(arrayList_[num9 - 1]))) != num5)
					{
						continue;
					}
				}
				else if (num9 + 1 < arrayList_.Count && Math.Abs(Struct63.smethod_9(num10, Convert.ToDouble(arrayList_[num9 + 1]))) != num5)
				{
					continue;
				}
				float num12 = (float)((double)rectangle_0.X + (num3 - num10) / (num3 - num4) * (double)rectangle_0.Width);
				if (class823_0.int_4 != 0)
				{
					string text2 = "";
					Color fontColor2 = class2.FontColor;
					num11 = (class823_0.IsLogarithmic ? num11 : (num11 * Math.Pow(10.0, (double)class823_0.method_12().vmethod_0())));
					if (flag)
					{
						text2 = Struct51.smethod_5(chart.vmethod_2(), num11, string_, bool_);
						fontColor2 = Struct51.smethod_6(num11, string_, fontColor2);
					}
					else
					{
						text2 = smethod_28(class823_0, num11);
						fontColor2 = Struct51.smethod_6(num11, class2.imethod_0(), fontColor2);
					}
					RectangleF value2 = new RectangleF(num12 - class823_0.float_0 / 2f, num, class823_0.float_0, class823_0.float_1);
					smethod_37(interface42_0, Rectangle.Round(value2), text2, class2.Rotation, class2.Font, fontColor2, Enum82.const_1, Enum82.const_1);
				}
				smethod_6(interface42_0, class823_0, bool_0, num12, float_0, rectangle_0);
			}
		}
		smethod_10(interface42_0, class823_0, bool_0, float_0, rectangle_0.X, rectangle_0.Right, rectangle_0);
		@class.method_3();
	}

	internal static void smethod_17(Interface42 interface42_0, Class842 class842_0, Class823 class823_0, Rectangle rectangle_0)
	{
		if (Struct63.smethod_18(rectangle_0) || !class823_0.IsVisible || class823_0.TickLabelPosition == Enum83.const_3)
		{
			return;
		}
		Class821 chart = class823_0.Chart;
		Class847 @class = class823_0.method_10();
		class842_0.method_9(0);
		ArrayList arrayList;
		if (class823_0.method_4() == Enum61.const_0)
		{
			arrayList = chart.method_7().method_0();
			chart.method_7().method_4();
		}
		else
		{
			arrayList = chart.method_7().method_2();
			chart.method_7().method_7();
		}
		float num = class823_0.method_10().method_1();
		int num2 = Struct47.smethod_32(class842_0.method_15());
		double num3 = Math.PI * 2.0 / (double)num2;
		double num4 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0;
		double num5 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0;
		new PointF((float)num4, (float)num5);
		double num6 = Math.PI / 2.0 + num3;
		double num7 = rectangle_0.Width / 2;
		for (int i = 0; i < num2; i++)
		{
			num6 -= num3;
			string text = "";
			Color fontColor = @class.FontColor;
			SizeF sizeF_ = new SizeF(class823_0.float_0, class823_0.float_1);
			if (@class.LinkedSource && arrayList.Count > 0)
			{
				string text2 = "";
				bool flag = false;
				text2 = ((i < arrayList.Count) ? ((Class825)arrayList[i]).imethod_3() : "");
				flag = i < arrayList.Count && ((Class825)arrayList[i]).imethod_1();
				text = Struct51.smethod_5(chart.vmethod_2(), class823_0.arrayList_1[i], text2, flag);
				fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], text2, fontColor);
			}
			else
			{
				text = smethod_28(class823_0, class823_0.arrayList_1[i]);
				fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], @class.imethod_0(), fontColor);
			}
			Font font = @class.Font;
			int rotation = @class.Rotation;
			Size size = Struct61.smethod_3(class823_0.Chart.imethod_0(), text, rotation, font, sizeF_, Enum82.const_1, Enum82.const_1);
			double num8 = (num7 + (double)num) * Math.Cos(num6);
			double num9 = (num7 + (double)num) * Math.Sin(num6);
			double num10 = num6 / Math.PI * 180.0;
			if (num10 >= -135.0 && num10 <= -45.0)
			{
				num8 = (float)(num8 + (num10 - -45.0) * (double)size.Width / 90.0);
			}
			else if (num10 <= -225.0 && num10 >= -270.0)
			{
				num8 = (float)(num8 - (num10 - -315.0) * (double)size.Width / 90.0);
			}
			else if (num10 <= 90.0 && num10 >= 45.0)
			{
				num8 = (float)(num8 - (num10 - 45.0) * (double)size.Width / 90.0);
			}
			else if (num10 <= -135.0 && num10 >= -225.0)
			{
				num8 -= (double)size.Width;
			}
			if (num10 >= -225.0 && num10 <= -135.0)
			{
				num9 = (float)(num9 - (num10 - -135.0) * (double)size.Height / 90.0);
			}
			else if (num10 >= -45.0 && num10 <= 45.0)
			{
				num9 = (float)(num9 + (num10 + 45.0) * (double)size.Height / 90.0);
			}
			else if ((num10 <= -225.0 && num10 >= -270.0) || (num10 <= 90.0 && num10 >= 45.0))
			{
				num9 += (double)size.Height;
			}
			num8 = num4 + num8;
			num9 = num5 - num9;
			Rectangle rectangle_ = new Rectangle((int)num8, (int)num9, size.Width, size.Height);
			smethod_37(interface42_0, rectangle_, text, rotation, font, fontColor, Enum82.const_1, Enum82.const_1);
		}
	}

	internal static void smethod_18(Interface42 interface42_0, Class842 class842_0, Class823 class823_0, Rectangle rectangle_0)
	{
		if (Struct63.smethod_18(rectangle_0) || !class823_0.IsVisible)
		{
			return;
		}
		Class844 @class = class842_0.method_9(0);
		Class821 chart = class823_0.Chart;
		Class847 class2 = class823_0.method_10();
		Class831 class3 = @class.method_9().method_1(0);
		bool flag = false;
		if (class2.LinkedSource && class3 != null)
		{
			flag = true;
		}
		int num = Struct47.smethod_32(class842_0.method_15());
		double num2 = Math.PI * 2.0 / (double)num;
		double num3 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0;
		double num4 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0;
		PointF pointF_ = new PointF((float)num3, (float)num4);
		double num5 = Math.PI / 2.0 + num2;
		double num6 = rectangle_0.Width / 2;
		for (int i = 0; i < num; i++)
		{
			num5 -= num2;
			double num7 = num3 + num6 * Math.Cos(num5);
			double num8 = num4 - num6 * Math.Sin(num5);
			PointF pointF_2 = new PointF((float)num7, (float)num8);
			class823_0.method_5().method_8(pointF_2, pointF_);
		}
		double num9 = 0.0;
		class823_0.arrayList_1.Sort();
		double num10 = class823_0.method_13();
		double num11 = class823_0.method_14();
		double num12 = class823_0.method_16();
		double num13 = class823_0.method_17();
		ArrayList arrayList_ = class823_0.arrayList_1;
		if (class823_0.IsVisible && class823_0.TickLabelPosition != Enum83.const_3)
		{
			for (int j = 0; j < class823_0.arrayList_1.Count; j++)
			{
				double num14 = Convert.ToDouble(arrayList_[j]);
				double num15 = (class823_0.IsLogarithmic ? class823_0.method_7(num14) : num14);
				if (j - 1 > 0)
				{
					if (Math.Abs(Struct63.smethod_9(num14, Convert.ToDouble(arrayList_[j - 1]))) != num12)
					{
						continue;
					}
				}
				else if (j + 1 < arrayList_.Count && Math.Abs(Struct63.smethod_9(num14, Convert.ToDouble(arrayList_[j + 1]))) != num12)
				{
					continue;
				}
				num9 = Math.Abs(num14 - num11);
				double num16 = num6 * num9 / (num10 - num11);
				double num17 = num3 + num16 * Math.Cos(Math.PI / 2.0);
				double num18 = num4 - num16 * Math.Sin(Math.PI / 2.0);
				string string_ = smethod_28(class823_0, num15);
				Color fontColor = class823_0.method_10().FontColor;
				fontColor = Struct51.smethod_6(num15, class823_0.method_10().imethod_0(), fontColor);
				if (flag)
				{
					string_ = Struct51.smethod_5(chart.vmethod_2(), num15, class3.vmethod_6(), class3.vmethod_7());
					fontColor = Struct51.smethod_6(num15, class3.vmethod_6(), fontColor);
				}
				Font font = class823_0.method_10().Font;
				int rotation = class823_0.method_10().Rotation;
				Size size = Struct61.smethod_2(class823_0.Chart.imethod_0(), string_, rotation, font, rectangle_0.Size, Enum82.const_1, Enum82.const_1);
				num17 = num17 - (double)size.Width - (double)class823_0.Chart.Width * 0.011;
				num18 -= (double)(size.Height / 2);
				Rectangle rectangle_ = new Rectangle((int)num17, (int)num18, size.Width, size.Height);
				smethod_37(interface42_0, rectangle_, string_, rotation, font, fontColor, Enum82.const_1, Enum82.const_1);
				num5 = Math.PI / 2.0;
			}
		}
		if (class823_0.Chart.bool_8 && class823_0 == class823_0.Chart.method_9())
		{
			num9 = 0.0;
			num10 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.double_5) : class823_0.double_5);
			num11 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.double_6) : class823_0.double_6);
			num12 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.double_7) : class823_0.double_7);
			num13 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.double_8) : class823_0.double_8);
			if (num12 > 0.0)
			{
				for (double num19 = num11 + num12; num19 <= num10; num19 = Struct63.smethod_11(num19, num12))
				{
					num9 = Math.Abs(num19 - num11);
					double num20 = num6 * num9 / (num10 - num11);
					num5 = Math.PI / 2.0;
					for (int k = 0; k < num; k++)
					{
						if (!class823_0.method_8().IsVisible && class823_0.MajorTickMark != Enum84.const_2 && !class823_0.method_9().IsVisible && class823_0.IsVisible)
						{
							double num21 = Math.Atan((double)class823_0.method_19() / num20);
							double num22 = Math.Sqrt(Math.Pow(num20, 2.0) + Math.Pow(class823_0.method_19(), 2.0));
							double num23 = num3 + num22 * Math.Cos(num5 + num21);
							double num24 = num4 - num22 * Math.Sin(num5 + num21);
							PointF pointF_3 = new PointF((float)num23, (float)num24);
							double num25 = num3 + num22 * Math.Cos(num5 - num21);
							double num26 = num4 - num22 * Math.Sin(num5 - num21);
							PointF pointF_4 = new PointF((float)num25, (float)num26);
							class823_0.method_5().method_8(pointF_3, pointF_4);
						}
						num5 -= num2;
					}
				}
			}
			if (!(num13 > 0.0))
			{
				return;
			}
			for (double num27 = num11 + num13; num27 <= num10; num27 = Struct63.smethod_11(num27, num13))
			{
				num9 = Math.Abs(num27 - num11);
				double num28 = num6 * num9 / (num10 - num11);
				num5 = Math.PI / 2.0;
				for (int l = 0; l < num; l++)
				{
					if (!class823_0.method_9().IsVisible && class823_0.MinorTickMark != Enum84.const_2 && class823_0.IsVisible)
					{
						double num29 = Math.Atan((double)class823_0.method_21() / num28);
						double num30 = Math.Sqrt(Math.Pow(num28, 2.0) + Math.Pow(class823_0.method_21(), 2.0));
						double num31 = num3 + num30 * Math.Cos(num5 + num29);
						double num32 = num4 - num30 * Math.Sin(num5 + num29);
						PointF pointF_5 = new PointF((float)num31, (float)num32);
						double num33 = num3 + num30 * Math.Cos(num5 - num29);
						double num34 = num4 - num30 * Math.Sin(num5 - num29);
						PointF pointF_6 = new PointF((float)num33, (float)num34);
						class823_0.method_5().method_8(pointF_5, pointF_6);
					}
					num5 -= num2;
				}
			}
			return;
		}
		num9 = 0.0;
		num10 = class823_0.method_13();
		num11 = class823_0.method_14();
		num12 = class823_0.method_16();
		num13 = class823_0.method_17();
		if (num12 > 0.0)
		{
			for (double num35 = num11 + num12; num35 <= num10; num35 = Struct63.smethod_11(num35, num12))
			{
				num9 = Math.Abs(num35 - num11);
				double num36 = num6 * num9 / (num10 - num11);
				num5 = Math.PI / 2.0;
				for (int m = 0; m < num; m++)
				{
					if (!class823_0.method_8().IsVisible && class823_0.MajorTickMark != Enum84.const_2 && !class823_0.method_9().IsVisible && class823_0.IsVisible)
					{
						double num37 = Math.Atan((double)class823_0.method_19() / num36);
						double num38 = Math.Sqrt(Math.Pow(num36, 2.0) + Math.Pow(class823_0.method_19(), 2.0));
						double num39 = num3 + num38 * Math.Cos(num5 + num37);
						double num40 = num4 - num38 * Math.Sin(num5 + num37);
						PointF pointF_7 = new PointF((float)num39, (float)num40);
						double num41 = num3 + num38 * Math.Cos(num5 - num37);
						double num42 = num4 - num38 * Math.Sin(num5 - num37);
						PointF pointF_8 = new PointF((float)num41, (float)num42);
						class823_0.method_5().method_8(pointF_7, pointF_8);
					}
					num5 -= num2;
				}
			}
		}
		if (!(num13 > 0.0))
		{
			return;
		}
		for (double num43 = num11 + num13; num43 <= num10; num43 = Struct63.smethod_11(num43, num13))
		{
			num9 = Math.Abs(num43 - num11);
			double num44 = num6 * num9 / (num10 - num11);
			num5 = Math.PI / 2.0;
			for (int n = 0; n < num; n++)
			{
				if (!class823_0.method_9().IsVisible && class823_0.MinorTickMark != Enum84.const_2 && class823_0.IsVisible)
				{
					double num45 = Math.Atan((double)class823_0.method_21() / num44);
					double num46 = Math.Sqrt(Math.Pow(num44, 2.0) + Math.Pow(class823_0.method_21(), 2.0));
					double num47 = num3 + num46 * Math.Cos(num5 + num45);
					double num48 = num4 - num46 * Math.Sin(num5 + num45);
					PointF pointF_9 = new PointF((float)num47, (float)num48);
					double num49 = num3 + num46 * Math.Cos(num5 - num45);
					double num50 = num4 - num46 * Math.Sin(num5 - num45);
					PointF pointF_10 = new PointF((float)num49, (float)num50);
					class823_0.method_5().method_8(pointF_9, pointF_10);
				}
				num5 -= num2;
			}
		}
	}

	internal static Size smethod_19(Interface42 interface42_0, Class823 class823_0, Class844 class844_0, bool bool_0)
	{
		if (class823_0.IsVisible && class823_0.TickLabelPosition != Enum83.const_3 && !class823_0.Chart.method_8().method_16())
		{
			Class821 chart = class823_0.Chart;
			Class831 @class = class844_0.method_9().method_1(0);
			ChartType_Chart chartType_Chart_ = class844_0.method_22();
			Class847 class2 = class823_0.method_10();
			string string_ = @class.vmethod_6();
			bool bool_ = @class.vmethod_7();
			bool flag = false;
			if (class2.LinkedSource && @class != null)
			{
				flag = true;
			}
			int num = 0;
			int num2 = 0;
			ArrayList arrayList_ = class823_0.arrayList_1;
			if (!class823_0.IsLogarithmic)
			{
				_ = class823_0.MaxValue;
			}
			else
			{
				class823_0.method_6(class823_0.MaxValue);
			}
			if (!class823_0.IsLogarithmic)
			{
				_ = class823_0.MinValue;
			}
			else
			{
				class823_0.method_6(class823_0.MinValue);
			}
			double num3 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MajorUnit) : class823_0.MajorUnit);
			double num4 = 1E-10;
			for (int i = 0; i < class823_0.arrayList_1.Count; i++)
			{
				double num5 = Convert.ToDouble(arrayList_[i]);
				double num6 = (class823_0.IsLogarithmic ? class823_0.method_7(num5) : num5);
				if (i - 1 > 0)
				{
					if (Math.Abs(Struct63.smethod_9(num3, Math.Abs(Struct63.smethod_9(num5, Convert.ToDouble(arrayList_[i - 1]))))) / num3 > 10000000000.0)
					{
						continue;
					}
				}
				else if (i + 1 < arrayList_.Count && Math.Abs(Struct63.smethod_9(num3, Math.Abs(Struct63.smethod_9(num5, Convert.ToDouble(arrayList_[i + 1]))))) / num4 > 10000000000.0)
				{
					continue;
				}
				if (Struct47.smethod_56(chartType_Chart_))
				{
					num6 /= 100.0;
					string_ = "0%";
				}
				string text = "";
				num6 = (class823_0.IsLogarithmic ? num6 : (num6 * Math.Pow(10.0, (double)class823_0.method_12().vmethod_0())));
				Color fontColor = class2.FontColor;
				if (flag)
				{
					text = Struct51.smethod_5(chart.vmethod_2(), num6, string_, bool_);
					fontColor = Struct51.smethod_6(num6, string_, fontColor);
				}
				else
				{
					text = smethod_28(class823_0, num6);
					fontColor = Struct51.smethod_6(num6, class2.imethod_0(), fontColor);
				}
				Size size = Struct61.smethod_2(class823_0.Chart.imethod_0(), text, class2.Rotation, class2.Font, class823_0.Chart.method_8().rectangle_1.Size, Enum82.const_1, Enum82.const_1);
				if (size.Width > num)
				{
					num = size.Width;
				}
				if (size.Height > num2)
				{
					num2 = size.Height;
				}
			}
			if (bool_0)
			{
				num2 += (int)((double)(2 * class823_0.method_19()) + 0.5);
			}
			else
			{
				num += (int)((double)(2 * class823_0.method_19()) + 0.5);
			}
			class823_0.float_0 = num;
			class823_0.float_1 = num2;
			return new Size(num, num2);
		}
		return new Size(0, 0);
	}

	internal static Size smethod_20(Interface42 interface42_0, Class823 class823_0, Rectangle rectangle_0, Rectangle rectangle_1, int int_0, bool bool_0, Class844 class844_0)
	{
		if (class823_0.IsVisible && class823_0.TickLabelPosition != Enum83.const_3 && !Struct63.smethod_18(rectangle_0))
		{
			bool flag = false;
			if (class823_0.CategoryType == Enum64.const_2)
			{
				flag = true;
				class823_0.imethod_2(bool_15: false);
				class823_0.TickLabelSpacing = 1;
			}
			ArrayList arrayList = (ArrayList)class823_0.arrayList_1.Clone();
			if (class823_0.IsLogarithmic)
			{
				for (int i = 0; i < arrayList.Count; i++)
				{
					arrayList[i] = class823_0.method_7(Convert.ToDouble(arrayList[i]));
				}
			}
			Class821 chart = class823_0.Chart;
			bool flag2 = chart.method_17();
			bool flag3 = false;
			ArrayList arrayList2;
			ArrayList[] array;
			if (class823_0.method_4() == Enum61.const_0)
			{
				arrayList2 = chart.method_7().method_0();
				array = chart.method_7().method_4();
				flag3 = chart.method_7().bool_0;
			}
			else
			{
				arrayList2 = chart.method_7().method_2();
				array = chart.method_7().method_7();
				flag3 = chart.method_7().bool_1;
			}
			bool flag4 = ((array != null && array.Length > 0) ? true : false);
			int num = smethod_21(class823_0);
			Class847 @class = class823_0.method_10();
			int num2 = 300;
			string string_ = class844_0.method_9()[0].imethod_10();
			bool bool_ = class844_0.method_9()[0].imethod_12();
			string text = "";
			bool flag5 = false;
			bool flag6 = false;
			if (class844_0.method_22() != ChartType_Chart.Scatter && class844_0.method_22() != ChartType_Chart.Bubble)
			{
				if (@class.LinkedSource && arrayList2.Count > 0)
				{
					flag6 = true;
				}
				if (array != null && array.Length > 0 && arrayList2.Count > 0)
				{
					flag6 = true;
				}
			}
			else if (@class.LinkedSource)
			{
				flag6 = true;
			}
			SizeF sizeF_ = new SizeF(0f, 0f);
			int num3 = 0;
			if (!flag)
			{
				if (!class823_0.AxisBetweenCategories && !chart.IsDataTableShown)
				{
					num3 = int_0 - 1;
					if (num3 == 0)
					{
						num3 = 1;
					}
				}
				else
				{
					num3 = int_0;
				}
			}
			else
			{
				num3 = arrayList.Count;
			}
			int num4 = 1;
			if (!class844_0.method_36())
			{
				if (bool_0)
				{
					if ((float)rectangle_0.Height / (float)num3 < 1f)
					{
						float num5 = (float)rectangle_0.Height / (float)num3 * 10f;
						num4 *= 10;
						if (num5 < 1f)
						{
							num5 = (float)rectangle_0.Width / (float)num3 * 10f;
							num4 *= 10;
						}
					}
				}
				else if ((float)rectangle_0.Width / (float)num3 < 1f)
				{
					float num6 = (float)rectangle_0.Width / (float)num3 * 10f;
					num4 *= 10;
					if (num6 < 1f)
					{
						num6 = (float)rectangle_0.Width / (float)num3 * 10f;
						num4 *= 10;
					}
				}
			}
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			if (@class.vmethod_1())
			{
				float num11 = 0.55f;
				int num12 = 0;
				int num13 = 0;
				float num14 = 0f;
				bool flag7 = false;
				Size size = Struct61.smethod_6(interface42_0, "a", @class.Font);
				int num15 = 0;
				float[,] array2 = new float[arrayList.Count, 2];
				Size[] array3 = new Size[arrayList.Count];
				string[] array4 = new string[arrayList.Count];
				while (true)
				{
					num7 = 0;
					num8 = 0;
					num9 = 0;
					num10 = 0;
					float num16 = 0f;
					if (!class844_0.method_36())
					{
						if (bool_0)
						{
							sizeF_.Height = (float)rectangle_0.Height / (float)num3 * (float)class823_0.TickLabelSpacing;
							sizeF_.Width = (float)rectangle_0.Width * num11;
							if (class823_0.vmethod_0())
							{
								if (Math.Abs(@class.Rotation) == 0 && class823_0.TickLabelSpacing < num3)
								{
									if (sizeF_.Height < (float)size.Height)
									{
										class823_0.TickLabelSpacing += num4;
										continue;
									}
								}
								else if (Math.Abs(@class.Rotation) == 90 && sizeF_.Height < (float)size.Width && class823_0.TickLabelSpacing < num3)
								{
									class823_0.TickLabelSpacing += num4;
									continue;
								}
							}
							num16 = sizeF_.Height;
						}
						else
						{
							if (num > class823_0.TickLabelSpacing)
							{
								sizeF_.Width = (float)rectangle_0.Width / (float)num3 * (float)num;
							}
							else
							{
								sizeF_.Width = (float)rectangle_0.Width / (float)num3 * (float)class823_0.TickLabelSpacing;
							}
							sizeF_.Height = (float)rectangle_0.Height * num11;
							if (class823_0.vmethod_0())
							{
								if (Math.Abs(@class.Rotation) == 0)
								{
									if (sizeF_.Width < (float)size.Width)
									{
										class823_0.TickLabelSpacing += num4;
										continue;
									}
								}
								else if (Math.Abs(@class.Rotation) == 90 && sizeF_.Width < (float)size.Height)
								{
									class823_0.TickLabelSpacing += num4;
									if (!flag4)
									{
										@class.Rotation = 45;
									}
									continue;
								}
							}
							num16 = sizeF_.Width;
						}
					}
					else
					{
						SizeF sizeF = Struct61.smethod_15(interface42_0, "3", @class.Font);
						if (bool_0)
						{
							sizeF_.Height = (float)rectangle_0.Height / (float)arrayList.Count;
							sizeF_.Width = (float)rectangle_0.Width * num11;
							sizeF_.Height += Struct63.smethod_3(sizeF.Height);
							num16 = sizeF_.Height;
						}
						else
						{
							sizeF_.Width = (float)rectangle_0.Width / (float)arrayList.Count;
							sizeF_.Height = (float)rectangle_0.Height * num11;
							sizeF_.Width += Struct63.smethod_3(sizeF.Width);
							num16 = sizeF_.Width;
						}
					}
					float num17 = 0f;
					if (@class.Rotation == 45)
					{
						num17 = (class844_0.method_36() ? ((!bool_0) ? ((float)(rectangle_0.Width / arrayList.Count)) : ((float)(rectangle_0.Height / arrayList.Count))) : ((!bool_0) ? ((float)(rectangle_0.Width / num3)) : ((float)(rectangle_0.Height / num3))));
					}
					float num18 = 0f;
					float num19 = 0f;
					for (int j = 0; j < arrayList.Count; j++)
					{
						if (@class.Rotation == 45)
						{
							int num20 = arrayList.Count - 1 - j;
							if (bool_0)
							{
								if (class823_0.IsPlotOrderReversed)
								{
									if (@class.Rotation > 0)
									{
										sizeF_.Width = (float)rectangle_0.Width * num11;
										sizeF_.Height = (float)rectangle_0.Height - (float)j * num17 - num17 / 2f;
									}
									else
									{
										sizeF_.Width = (float)rectangle_0.Width * num11;
										sizeF_.Height = (float)rectangle_0.Height - (float)num20 * num17 - num17 / 2f;
									}
								}
								else if (@class.Rotation > 0)
								{
									sizeF_.Width = (float)rectangle_0.Width * num11;
									sizeF_.Height = (float)rectangle_0.Height - (float)num20 * num17 - num17 / 2f;
								}
								else
								{
									sizeF_.Width = (float)rectangle_0.Width * num11;
									sizeF_.Height = (float)rectangle_0.Height - (float)j * num17 - num17 / 2f;
								}
							}
							else if (class823_0.IsPlotOrderReversed)
							{
								if (@class.Rotation > 0)
								{
									sizeF_.Width = (float)rectangle_0.Width - (float)j * num17 - num17 / 2f;
									sizeF_.Height = (float)rectangle_0.Height * num11;
								}
								else
								{
									sizeF_.Width = (float)rectangle_0.Width - (float)num20 * num17 - num17 / 2f;
									sizeF_.Height = (float)rectangle_0.Height * num11;
								}
							}
							else if (@class.Rotation > 0)
							{
								sizeF_.Width = (float)rectangle_0.Width - (float)num20 * num17 - num17 / 2f;
								sizeF_.Height = (float)rectangle_0.Height * num11;
							}
							else
							{
								sizeF_.Width = (float)rectangle_0.Width - (float)j * num17 - num17 / 2f;
								sizeF_.Height = (float)rectangle_0.Height * num11;
							}
							if (sizeF_.Width < (float)rectangle_0.Width * num11)
							{
								sizeF_.Width = (float)rectangle_0.Width * num11;
							}
							if (sizeF_.Height < (float)rectangle_0.Height * num11)
							{
								sizeF_.Height = (float)rectangle_0.Height * num11;
							}
						}
						if (j == 0 && num15 <= 0)
						{
							class823_0.method_10().method_2(size.Width * class823_0.method_10().Offset / num2);
						}
						string text2;
						if (num15 <= 0)
						{
							text2 = "";
							if (flag6)
							{
								text = ((j < arrayList2.Count) ? ((Class825)arrayList2[j]).imethod_3() : "");
								flag5 = j < arrayList2.Count && ((Class825)arrayList2[j]).imethod_1();
								text2 = ((class844_0.method_22() == ChartType_Chart.Scatter || class844_0.method_22() == ChartType_Chart.Bubble) ? Struct51.smethod_5(chart.vmethod_2(), Convert.ToDouble(arrayList[j]) * Math.Pow(10.0, (double)class823_0.method_12().vmethod_0()), string_, bool_) : Struct51.smethod_5(chart.vmethod_2(), arrayList[j], text, flag5));
							}
							else
							{
								text2 = smethod_28(class823_0, arrayList[j]);
							}
							array4[j] = text2;
						}
						else
						{
							text2 = array4[j];
						}
						float num21;
						float num22;
						if (num15 <= 0)
						{
							num21 = Struct61.smethod_14(interface42_0, text2, @class.Font, !flag2);
							num22 = Struct61.smethod_10(interface42_0, text2, @class.Font).Width;
							array2[j, 0] = num21;
							array2[j, 1] = num22;
						}
						else
						{
							num21 = array2[j, 0];
							num22 = array2[j, 1];
						}
						if (num21 > num18)
						{
							num18 = num21;
						}
						if (num22 > num19)
						{
							num19 = num22;
						}
						Size size2 = new Size(0, 0);
						if (flag3)
						{
							size2 = Struct61.smethod_3(interface42_0, text2, @class.Rotation, @class.Font, sizeF_, Enum82.const_1, Enum82.const_1);
						}
						else if (num15 <= 0)
						{
							size2 = Struct61.smethod_6(interface42_0, text2, @class.Font);
							array3[j] = size2;
						}
						else
						{
							size2 = array3[j];
						}
						if (size2.Width > num7)
						{
							num7 = size2.Width;
						}
						if (size2.Height > num8)
						{
							num8 = size2.Height;
						}
						if (j == 0)
						{
							num9 = ((!bool_0) ? (size2.Width / 2) : (size2.Height / 2));
						}
						if (j == arrayList.Count - 1)
						{
							num10 = ((!bool_0) ? (size2.Width / 2) : (size2.Height / 2));
						}
					}
					num15++;
					class823_0.float_2 = num8;
					class823_0.float_3 = num7;
					if (flag3 && num18 > num16)
					{
						if (bool_0)
						{
							if (@class.Rotation == 0 && (float)num8 > (float)size.Height * 1.5f)
							{
								@class.Rotation = 45;
								continue;
							}
							if (@class.Rotation == 45)
							{
								double num23 = (double)Math.Abs(@class.Rotation) / 180.0 * Math.PI;
								double num24 = (double)num19 * Math.Cos(num23) + (double)size.Height * Math.Sin(num23);
								if (num24 > (double)num7)
								{
									@class.Rotation = 90;
									continue;
								}
							}
						}
						else if (!flag4)
						{
							if (@class.Rotation == 0 && (float)num8 > (float)size.Height * 1.5f)
							{
								if ((double)num16 <= (double)size.Height * 1.4)
								{
									@class.Rotation = 90;
								}
								else
								{
									@class.Rotation = 45;
								}
								continue;
							}
							if (@class.Rotation == 45 && (double)num16 <= (double)size.Height * 1.4)
							{
								@class.Rotation = 90;
								continue;
							}
						}
						else if (@class.Rotation != 90)
						{
							@class.Rotation = 90;
							continue;
						}
					}
					else if (bool_0)
					{
						if (sizeF_.Height / (float)num8 > 2f && (double)num11 > 0.2 && sizeF_.Width * 4f / 5f > num18)
						{
							num11 = num11 * 4f / 5f;
							continue;
						}
					}
					else if (sizeF_.Width / (float)num7 > 2f && (double)num11 > 0.3)
					{
						num11 = num11 * 4f / 5f;
						continue;
					}
					if (!class823_0.vmethod_0() || flag7)
					{
						break;
					}
					if (bool_0)
					{
						if ((num7 != num12 || num8 != num13 || num14 != sizeF_.Height) && (float)num8 > sizeF_.Height - 5f && class823_0.TickLabelSpacing < num3)
						{
							num12 = num7;
							num13 = num8;
							num14 = sizeF_.Height;
							class823_0.TickLabelSpacing += num4;
							continue;
						}
						if (class823_0.TickLabelSpacing <= 1)
						{
							break;
						}
						class823_0.TickLabelSpacing -= num4;
						if (class823_0.TickLabelSpacing < 1)
						{
							class823_0.TickLabelSpacing = 1;
						}
						flag7 = true;
					}
					else if ((num7 != num12 || num8 != num13 || num14 != sizeF_.Width) && (float)num7 > sizeF_.Width - 5f && class823_0.TickLabelSpacing < num3)
					{
						num12 = num7;
						num13 = num8;
						num14 = sizeF_.Width;
						class823_0.TickLabelSpacing += num4;
					}
					else
					{
						if (class823_0.TickLabelSpacing <= 1)
						{
							break;
						}
						class823_0.TickLabelSpacing -= num4;
						if (class823_0.TickLabelSpacing < 1)
						{
							class823_0.TickLabelSpacing = 1;
						}
						flag7 = true;
					}
				}
				if (class823_0.IsPlotOrderReversed)
				{
					int num25 = num9;
					num9 = num10;
					num10 = num25;
				}
			}
			else if (@class.Rotation != 0 && @class.Rotation != 90 && @class.Rotation != -90)
			{
				float num26 = 0.5f;
				float num27 = 0f;
				_ = arrayList.Count;
				if (!class844_0.method_36())
				{
					num27 = ((!bool_0) ? ((float)(rectangle_0.Width / num3 * class823_0.TickLabelSpacing)) : ((float)(rectangle_0.Height / num3 * class823_0.TickLabelSpacing)));
				}
				else
				{
					SizeF sizeF2 = Struct61.smethod_15(interface42_0, "3", @class.Font);
					if (bool_0)
					{
						num27 = rectangle_0.Height / arrayList.Count;
						num27 += sizeF2.Height;
					}
					else
					{
						num27 = rectangle_0.Width / arrayList.Count;
						num27 += sizeF2.Width;
					}
				}
				Size size3 = new Size(0, 0);
				for (int k = 0; k < arrayList.Count; k++)
				{
					int num28 = arrayList.Count - 1 - k;
					if (bool_0)
					{
						if (class823_0.IsPlotOrderReversed)
						{
							if (@class.Rotation > 0)
							{
								sizeF_.Width = (float)rectangle_0.Width * num26;
								sizeF_.Height = (float)rectangle_0.Height - (float)k * num27 - num27 / 2f;
							}
							else
							{
								sizeF_.Width = (float)rectangle_0.Width * num26;
								sizeF_.Height = (float)rectangle_0.Height - (float)num28 * num27 - num27 / 2f;
							}
						}
						else if (@class.Rotation > 0)
						{
							sizeF_.Width = (float)rectangle_0.Width * num26;
							sizeF_.Height = (float)rectangle_0.Height - (float)num28 * num27 - num27 / 2f;
						}
						else
						{
							sizeF_.Width = (float)rectangle_0.Width * num26;
							sizeF_.Height = (float)rectangle_0.Height - (float)k * num27 - num27 / 2f;
						}
					}
					else if (class823_0.IsPlotOrderReversed)
					{
						if (@class.Rotation > 0)
						{
							sizeF_.Width = (float)rectangle_0.Width - (float)k * num27 - num27 / 2f;
							sizeF_.Height = (float)rectangle_0.Height * num26;
						}
						else
						{
							sizeF_.Width = (float)rectangle_0.Width - (float)num28 * num27 - num27 / 2f;
							sizeF_.Height = (float)rectangle_0.Height * num26;
						}
					}
					else if (@class.Rotation > 0)
					{
						sizeF_.Width = (float)rectangle_0.Width - (float)num28 * num27 - num27 / 2f;
						sizeF_.Height = (float)rectangle_0.Height * num26;
					}
					else
					{
						sizeF_.Width = (float)rectangle_0.Width - (float)k * num27 - num27 / 2f;
						sizeF_.Height = (float)rectangle_0.Height * num26;
					}
					if (sizeF_.Width < (float)rectangle_0.Width * num26)
					{
						sizeF_.Width = (float)rectangle_0.Width * num26;
					}
					if (sizeF_.Height < (float)rectangle_0.Height * num26)
					{
						sizeF_.Height = (float)rectangle_0.Height * num26;
					}
					if (k == 0)
					{
						size3 = Struct61.smethod_6(interface42_0, "a", @class.Font);
						class823_0.method_10().method_2(size3.Width * class823_0.method_10().Offset / num2 * 4);
					}
					string text3 = "";
					if (flag6)
					{
						text = ((k < arrayList2.Count) ? ((Class825)arrayList2[k]).imethod_3() : "");
						flag5 = k < arrayList2.Count && ((Class825)arrayList2[k]).imethod_1();
						text3 = ((class844_0.method_22() == ChartType_Chart.Scatter || class844_0.method_22() == ChartType_Chart.Bubble) ? Struct51.smethod_5(chart.vmethod_2(), Convert.ToDouble(arrayList[k]) * Math.Pow(10.0, (double)class823_0.method_12().vmethod_0()), string_, bool_) : Struct51.smethod_5(chart.vmethod_2(), arrayList[k], text, flag5));
					}
					else
					{
						text3 = smethod_28(class823_0, arrayList[k]);
					}
					Size size4 = Struct61.smethod_3(interface42_0, text3, @class.Rotation, @class.Font, sizeF_, Enum82.const_1, Enum82.const_1);
					if (size4.Width > num7)
					{
						num7 = size4.Width;
					}
					if (size4.Height > num8)
					{
						num8 = size4.Height;
					}
					int num29 = num7;
					if (bool_0)
					{
						num29 = num8;
					}
					switch (class823_0.method_0())
					{
					case Enum54.const_0:
					{
						if (class823_0.IsPlotOrderReversed)
						{
							if (@class.Rotation > 0)
							{
								float num46 = (float)num28 * num27 + num27 / 2f;
								if ((float)num29 > num46)
								{
									float num47 = (float)num29 - num46;
									if (num47 > (float)num9)
									{
										num9 = (int)num47;
									}
								}
								break;
							}
							float num48 = (float)k * num27 + num27 / 2f;
							if ((float)num29 > num48)
							{
								float num49 = (float)num29 - num48;
								if (num49 > (float)num10)
								{
									num10 = (int)num49;
								}
							}
							break;
						}
						if (@class.Rotation > 0)
						{
							float num50 = (float)k * num27 + num27 / 2f;
							if ((float)num29 > num50)
							{
								float num51 = (float)num29 - num50;
								if (num51 > (float)num9)
								{
									num9 = (int)num51;
								}
							}
							break;
						}
						float num52 = (float)num28 * num27 + num27 / 2f;
						if ((float)num29 > num52)
						{
							float num53 = (float)num29 - num52;
							if (num53 > (float)num10)
							{
								num10 = (int)num53;
							}
						}
						break;
					}
					case Enum54.const_1:
					{
						if (class823_0.IsPlotOrderReversed)
						{
							if (@class.Rotation > 0)
							{
								float num38 = (float)num28 * num27 + num27 / 2f;
								if ((float)num29 > num38)
								{
									float num39 = (float)num29 - num38;
									if (num39 > (float)num9)
									{
										num9 = (int)num39;
									}
								}
								break;
							}
							float num40 = (float)k * num27 + num27 / 2f;
							if ((float)num29 > num40)
							{
								float num41 = (float)num29 - num40;
								if (num41 > (float)num10)
								{
									num10 = (int)num41;
								}
							}
							break;
						}
						if (@class.Rotation > 0)
						{
							float num42 = (float)k * num27 + num27 / 2f;
							if ((float)num29 > num42)
							{
								float num43 = (float)num29 - num42;
								if (num43 > (float)num9)
								{
									num9 = (int)num43;
								}
							}
							break;
						}
						float num44 = (float)num28 * num27 + num27 / 2f;
						if ((float)num29 > num44)
						{
							float num45 = (float)num29 - num44;
							if (num45 > (float)num10)
							{
								num10 = (int)num45;
							}
						}
						break;
					}
					case Enum54.const_2:
					{
						if (class823_0.IsPlotOrderReversed)
						{
							if (@class.Rotation < 0)
							{
								float num54 = (float)num28 * num27 + num27 / 2f;
								if ((float)num29 > num54)
								{
									float num55 = (float)num29 - num54;
									if (num55 > (float)num9)
									{
										num9 = (int)num55;
									}
								}
								break;
							}
							float num56 = (float)k * num27 + num27 / 2f;
							if ((float)num29 > num56)
							{
								float num57 = (float)num29 - num56;
								if (num57 > (float)num10)
								{
									num10 = (int)num57;
								}
							}
							break;
						}
						if (@class.Rotation < 0)
						{
							float num58 = (float)k * num27 + num27 / 2f;
							if ((float)num29 > num58)
							{
								float num59 = (float)num29 - num58;
								if (num59 > (float)num9)
								{
									num9 = (int)num59;
								}
							}
							break;
						}
						float num60 = (float)num28 * num27 + num27 / 2f;
						if ((float)num29 > num60)
						{
							float num61 = (float)num29 - num60;
							if (num61 > (float)num10)
							{
								num10 = (int)num61;
							}
						}
						break;
					}
					case Enum54.const_3:
					{
						if (class823_0.IsPlotOrderReversed)
						{
							if (@class.Rotation < 0)
							{
								float num30 = (float)num28 * num27 + num27 / 2f;
								if ((float)num29 > num30)
								{
									float num31 = (float)num29 - num30;
									if (num31 > (float)num9)
									{
										num9 = (int)num31;
									}
								}
								break;
							}
							float num32 = (float)k * num27 + num27 / 2f;
							if ((float)num29 > num32)
							{
								float num33 = (float)num29 - num32;
								if (num33 > (float)num10)
								{
									num10 = (int)num33;
								}
							}
							break;
						}
						if (@class.Rotation < 0)
						{
							float num34 = (float)k * num27 + num27 / 2f;
							if ((float)num29 > num34)
							{
								float num35 = (float)num29 - num34;
								if (num35 > (float)num9)
								{
									num9 = (int)num35;
								}
							}
							break;
						}
						float num36 = (float)num28 * num27 + num27 / 2f;
						if ((float)num29 > num36)
						{
							float num37 = (float)num29 - num36;
							if (num37 > (float)num10)
							{
								num10 = (int)num37;
							}
						}
						break;
					}
					}
				}
				class823_0.float_3 = num7;
				class823_0.float_2 = num8;
			}
			else
			{
				float num62 = 0.5f;
				int num63 = 0;
				int num64 = 0;
				bool flag8 = false;
				if (!chart.method_8().imethod_3())
				{
					flag8 = true;
				}
				Size size5 = Struct61.smethod_6(interface42_0, "a", @class.Font);
				int num65 = 0;
				string[] array5 = new string[arrayList.Count];
				while (true)
				{
					num7 = 0;
					num8 = 0;
					num9 = 0;
					num10 = 0;
					if (!class844_0.method_36())
					{
						if (bool_0)
						{
							sizeF_.Height = (float)rectangle_0.Height / (float)num3 * (float)class823_0.TickLabelSpacing;
							sizeF_.Width = (float)rectangle_0.Width * num62;
							if (class823_0.vmethod_0())
							{
								if (Math.Abs(@class.Rotation) == 0 && class823_0.TickLabelSpacing < num3)
								{
									if (sizeF_.Height < (float)size5.Height)
									{
										class823_0.TickLabelSpacing += num4;
										continue;
									}
								}
								else if (Math.Abs(@class.Rotation) == 90 && sizeF_.Height < (float)size5.Width && class823_0.TickLabelSpacing < num3)
								{
									class823_0.TickLabelSpacing += num4;
									continue;
								}
							}
						}
						else
						{
							if (num > class823_0.TickLabelSpacing)
							{
								sizeF_.Width = (float)rectangle_0.Width / (float)num3 * (float)num;
							}
							else
							{
								sizeF_.Width = (float)rectangle_0.Width / (float)num3 * (float)class823_0.TickLabelSpacing;
							}
							if (chart.method_8().imethod_3())
							{
								sizeF_.Height = (float)rectangle_1.Height * num62;
							}
							else if (rectangle_0.Bottom <= rectangle_1.Bottom)
							{
								sizeF_.Height = (float)rectangle_1.Height * num62;
								int num66 = rectangle_1.Bottom - rectangle_0.Bottom;
								if (sizeF_.Height > (float)num66)
								{
									sizeF_.Height = num66;
								}
							}
							else
							{
								sizeF_.Height = 0f;
							}
							if (class823_0.vmethod_0())
							{
								if (Math.Abs(@class.Rotation) == 0)
								{
									if (sizeF_.Width < (float)size5.Width)
									{
										class823_0.TickLabelSpacing += num4;
										continue;
									}
								}
								else if (Math.Abs(@class.Rotation) == 90 && sizeF_.Width < (float)size5.Height)
								{
									class823_0.TickLabelSpacing += num4;
									continue;
								}
							}
						}
					}
					else
					{
						SizeF sizeF3 = Struct61.smethod_15(interface42_0, "3", @class.Font);
						if (bool_0)
						{
							sizeF_.Height = (float)rectangle_0.Height / (float)arrayList.Count;
							sizeF_.Width = (float)rectangle_0.Width * num62;
							sizeF_.Height += Struct63.smethod_3(sizeF3.Height);
						}
						else
						{
							sizeF_.Width = (float)rectangle_0.Width / (float)arrayList.Count;
							sizeF_.Height = (float)rectangle_0.Height * num62;
							sizeF_.Width += Struct63.smethod_3(sizeF3.Width);
						}
					}
					for (int l = 0; l < arrayList.Count; l += class823_0.TickLabelSpacing)
					{
						if (l == 0 && num65 <= 0)
						{
							class823_0.method_10().method_2(Struct63.smethod_5(size5.Width * class823_0.method_10().Offset / num2));
						}
						string text4;
						if (num65 <= 0)
						{
							text4 = "";
							if (flag6)
							{
								text = ((l < arrayList2.Count) ? ((Class825)arrayList2[l]).imethod_3() : "");
								flag5 = l < arrayList2.Count && ((Class825)arrayList2[l]).imethod_1();
								text4 = ((!class844_0.method_36()) ? Struct51.smethod_5(chart.vmethod_2(), arrayList[l], text, flag5) : Struct51.smethod_5(chart.vmethod_2(), Convert.ToDouble(arrayList[l]) * Math.Pow(10.0, (double)class823_0.method_12().vmethod_0()), string_, bool_));
							}
							else
							{
								text4 = smethod_28(class823_0, arrayList[l]);
							}
							array5[l] = text4;
						}
						else
						{
							text4 = array5[l];
						}
						Size size6 = Struct61.smethod_3(interface42_0, text4, @class.Rotation, @class.Font, sizeF_, Enum82.const_1, Enum82.const_1);
						if (size6.Width > num7)
						{
							num7 = size6.Width;
						}
						if (size6.Height > num8)
						{
							num8 = size6.Height;
						}
						if (l == 0)
						{
							num9 = ((!bool_0) ? (size6.Width / 2) : (size6.Height / 2));
						}
						if (l == arrayList.Count - 1)
						{
							num10 = ((!bool_0) ? (size6.Width / 2) : (size6.Height / 2));
						}
					}
					num65++;
					class823_0.float_2 = num8;
					class823_0.float_3 = num7;
					if (bool_0)
					{
						if (sizeF_.Height / (float)num8 > 2f && (double)num62 > 0.3)
						{
							num62 = num62 * 4f / 5f;
							continue;
						}
					}
					else if (sizeF_.Width / (float)num7 > 2f && (double)num62 > 0.3)
					{
						num62 = num62 * 4f / 5f;
						continue;
					}
					if (!class823_0.vmethod_0() || flag8)
					{
						break;
					}
					if (bool_0)
					{
						if ((num7 != num63 || num8 != num64) && (float)num8 > sizeF_.Height - 5f && class823_0.TickLabelSpacing < num3)
						{
							num63 = num7;
							num64 = num8;
							_ = sizeF_.Height;
							class823_0.TickLabelSpacing += num4;
							continue;
						}
						if (class823_0.TickLabelSpacing <= 1)
						{
							break;
						}
						class823_0.TickLabelSpacing -= num4;
						if (class823_0.TickLabelSpacing < 1)
						{
							class823_0.TickLabelSpacing = 1;
						}
						flag8 = true;
					}
					else if ((num7 != num63 || num8 != num64) && (float)num7 > sizeF_.Width - 5f && class823_0.TickLabelSpacing < num3)
					{
						num63 = num7;
						num64 = num8;
						_ = sizeF_.Width;
						class823_0.TickLabelSpacing += num4;
					}
					else
					{
						if (class823_0.TickLabelSpacing <= 1)
						{
							break;
						}
						class823_0.TickLabelSpacing -= num4;
						if (class823_0.TickLabelSpacing < 1)
						{
							class823_0.TickLabelSpacing = 1;
						}
						flag8 = true;
					}
				}
				if (class823_0.IsPlotOrderReversed)
				{
					int num67 = num9;
					num9 = num10;
					num10 = num67;
				}
			}
			if (array != null && array.Length > 0 && arrayList2.Count > 0)
			{
				class823_0.TickLabelSpacing = 1;
				int int_ = 0;
				if (bool_0)
				{
					int_ = 90;
				}
				foreach (IList list in array)
				{
					if (bool_0)
					{
						sizeF_.Height = rectangle_0.Height / list.Count;
						sizeF_.Width = (float)rectangle_0.Width * 0.5f;
					}
					else
					{
						sizeF_.Width = rectangle_0.Width / list.Count;
						sizeF_.Height = (float)rectangle_0.Height * 0.5f;
					}
					Size size7 = smethod_24(interface42_0, list, int_, @class, sizeF_);
					if (bool_0)
					{
						num7 += size7.Width;
					}
					else
					{
						num8 += size7.Height;
					}
				}
			}
			class823_0.float_0 = num7;
			class823_0.float_1 = num8;
			if (smethod_22(class823_0, class844_0))
			{
				if (bool_0)
				{
					class823_0.float_4 = (float)num8 / 2f;
				}
				else
				{
					class823_0.float_4 = (float)num7 / 2f;
				}
				class823_0.float_5 = class823_0.float_4;
			}
			else if (smethod_23(class823_0, class844_0))
			{
				class823_0.float_4 = num9;
				class823_0.float_5 = num10;
			}
			return new Size(num7, num8);
		}
		return new Size(0, 0);
	}

	private static int smethod_21(Class823 class823_0)
	{
		Class821 chart = class823_0.Chart;
		bool flag = false;
		ArrayList arrayList;
		if (class823_0.method_4() == Enum61.const_0)
		{
			arrayList = chart.method_7().method_0();
			chart.method_7().method_4();
			flag = chart.method_7().bool_0;
		}
		else
		{
			arrayList = chart.method_7().method_2();
			chart.method_7().method_7();
			flag = chart.method_7().bool_1;
		}
		if (!flag)
		{
			return 1;
		}
		if (arrayList.Count == 1)
		{
			return 1;
		}
		int num = 1;
		int num2 = int.MaxValue;
		float num3 = 0f;
		float num4 = 0f;
		bool flag2 = true;
		int num5 = 0;
		while (true)
		{
			if (num5 < arrayList.Count)
			{
				Class825 @class = (Class825)arrayList[num5];
				if (@class.imethod_0() != null && !@class.imethod_0().Equals(""))
				{
					if (flag2)
					{
						if (num5 == 0)
						{
							num3 = 100f;
						}
						if (!(num3 > 0f))
						{
							return 1;
						}
						flag2 = false;
					}
					else
					{
						if (num5 == arrayList.Count)
						{
							num4 = 100f;
						}
						num4 = ((num3 < num4 / 2f) ? num3 : (num4 / 2f));
						num3 = num4;
						num = Struct63.smethod_5(num3 + 1f + num4);
						if (num <= 1)
						{
							break;
						}
						if (num < num2)
						{
							num2 = num;
						}
					}
				}
				else if (flag2)
				{
					num3 += 1f;
				}
				else
				{
					num4 += 1f;
				}
				num5++;
				continue;
			}
			if (num2 != int.MaxValue)
			{
				return num2;
			}
			return 1;
		}
		return 1;
	}

	internal static bool smethod_22(Class823 class823_0, Class844 class844_0)
	{
		if (class823_0.IsVisible && class823_0.TickLabelPosition != Enum83.const_3)
		{
			if (class823_0.method_4() != Enum61.const_1 && class823_0.method_4() != Enum61.const_3 && class844_0.method_22() != ChartType_Chart.Scatter && class844_0.method_22() != ChartType_Chart.Bubble)
			{
				if (!class823_0.AxisBetweenCategories && class823_0.method_10().Rotation == 0 && class844_0.method_22() != ChartType_Chart.Radar && class844_0.method_22() != ChartType_Chart.RadarFilled)
				{
					return true;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	internal static bool smethod_23(Class823 class823_0, Class844 class844_0)
	{
		if (class823_0.IsVisible && class823_0.TickLabelPosition != Enum83.const_3)
		{
			if (smethod_22(class823_0, class844_0))
			{
				return false;
			}
			if ((class823_0.method_4() == Enum61.const_0 || class823_0.method_4() == Enum61.const_2) && class823_0.AxisBetweenCategories && class844_0.method_22() != ChartType_Chart.Radar && class844_0.method_22() != ChartType_Chart.RadarFilled && Math.Abs(class823_0.method_10().Rotation) != 90 && class823_0.method_10().Rotation != 0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	internal static Size smethod_24(Interface42 interface42_0, IList ilist_0, int int_0, Class847 class847_0, SizeF sizeF_0)
	{
		Class821 chart = class847_0.method_0().Chart;
		sizeF_0.Width += 4f;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < ilist_0.Count; i++)
		{
			Class825 @class = (Class825)ilist_0[i];
			string string_ = Struct51.smethod_5(chart.vmethod_2(), @class.imethod_0(), @class.imethod_3(), @class.imethod_1());
			Size size = Struct61.smethod_3(interface42_0, string_, int_0, class847_0.Font, sizeF_0, Enum82.const_1, Enum82.const_1);
			if (size.Width > num)
			{
				num = size.Width;
			}
			if (size.Height > num2)
			{
				num2 = size.Height;
			}
		}
		return new Size(num, num2);
	}

	internal static void smethod_25(Interface42 interface42_0, Class823 class823_0, Class844 class844_0, bool bool_0)
	{
		if (class823_0.TickLabelPosition == Enum83.const_3)
		{
			return;
		}
		Class821 chart = class823_0.Chart;
		Class831 @class = class844_0.method_9().method_1(0);
		ChartType_Chart chartType_Chart_ = class844_0.method_22();
		Class847 class2 = class823_0.method_10();
		string string_ = @class.vmethod_6();
		bool bool_ = @class.vmethod_7();
		bool flag = false;
		if (class2.LinkedSource && @class != null)
		{
			flag = true;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < class823_0.arrayList_1.Count; i++)
		{
			if (i != 0 && i != class823_0.arrayList_1.Count - 1)
			{
				continue;
			}
			string text = "";
			double num3 = (double)class823_0.arrayList_1[i] * Math.Pow(10.0, (double)class823_0.method_12().vmethod_0());
			if (flag)
			{
				if (Struct47.smethod_56(chartType_Chart_))
				{
					string_ = "0%";
				}
				text = Struct51.smethod_5(chart.vmethod_2(), num3, string_, bool_);
			}
			else
			{
				text = smethod_28(class823_0, num3);
			}
			Size size = Struct61.smethod_2(class823_0.Chart.imethod_0(), text, class2.Rotation, class2.Font, class823_0.Chart.method_8().rectangle_1.Size, Enum82.const_1, Enum82.const_1);
			if (i == 0)
			{
				num = ((!bool_0) ? (size.Height / 2) : (size.Width / 2));
			}
			if (i == class823_0.arrayList_1.Count - 1)
			{
				num2 = ((!bool_0) ? (size.Height / 2) : (size.Width / 2));
			}
		}
		if (class823_0.IsPlotOrderReversed)
		{
			int num4 = num;
			num = num2;
			num2 = num4;
		}
		class823_0.float_4 = num;
		class823_0.float_5 = num2;
	}

	internal static DateTime smethod_26(double double_0, bool bool_0)
	{
		return Struct63.GetDateTimeFromDouble(double_0, bool_0);
	}

	internal static int smethod_27(DateTime dateTime_0, bool bool_0)
	{
		return (int)Struct63.GetDoubleFromDateTime(dateTime_0, bool_0);
	}

	internal static string smethod_28(Class823 class823_0, object object_0)
	{
		string text = class823_0.method_10().imethod_0();
		bool bool_ = class823_0.method_10().vmethod_0();
		string text2 = "";
		if ((class823_0.method_4() == Enum61.const_0 || class823_0.method_4() == Enum61.const_2) && class823_0.CategoryType == Enum64.const_2)
		{
			DateTime dateTime = smethod_26(Convert.ToInt32(object_0), class823_0.Chart.vmethod_0());
			if (!(text != ""))
			{
				text = ((class823_0.BaseUnitScale == Enum87.const_0) ? "M/d/yyyy" : ((class823_0.BaseUnitScale != Enum87.const_1) ? "yyyy" : "MMM-yy"));
			}
			else
			{
				try
				{
					dateTime.ToString(text);
				}
				catch
				{
					text = ((class823_0.BaseUnitScale == Enum87.const_0) ? "M/d/yyyy" : ((class823_0.BaseUnitScale != Enum87.const_1) ? "yyyy" : "MMM-yy"));
				}
			}
			return Struct65.smethod_0(class823_0.Chart.vmethod_2(), dateTime, text);
		}
		return Struct51.smethod_5(class823_0.Chart.vmethod_2(), object_0, text, bool_);
	}

	internal static int smethod_29(Enum87 enum87_0, int int_0, int int_1, bool bool_0)
	{
		DateTime dateTime = smethod_26(int_0, bool_0);
		DateTime dateTime2 = smethod_26(int_1, bool_0);
		return enum87_0 switch
		{
			Enum87.const_0 => int_0 - int_1, 
			Enum87.const_1 => (dateTime.Year - dateTime2.Year) * 12 + dateTime.Month - dateTime2.Month, 
			_ => dateTime.Year - dateTime2.Year, 
		};
	}

	internal static int smethod_30(Enum87 enum87_0, int int_0, int int_1, bool bool_0)
	{
		DateTime dateTime = smethod_26(int_0, bool_0);
		DateTime dateTime2 = smethod_26(int_1, bool_0);
		int num;
		switch (enum87_0)
		{
		case Enum87.const_0:
			num = int_0 - int_1;
			break;
		case Enum87.const_1:
			num = (dateTime.Year - dateTime2.Year) * 12 + dateTime.Month - dateTime2.Month;
			if (dateTime.Day - dateTime2.Day > 0)
			{
				num++;
			}
			break;
		default:
			num = dateTime.Year - dateTime2.Year;
			if (dateTime.Month - dateTime2.Month > 0 || dateTime.Day - dateTime2.Day > 0)
			{
				num++;
			}
			break;
		}
		return num;
	}

	internal static int smethod_31(Enum87 enum87_0, Enum87 enum87_1, int int_0, int int_1, bool bool_0)
	{
		DateTime dateTime = smethod_26(int_1, bool_0);
		return smethod_27(enum87_0 switch
		{
			Enum87.const_0 => enum87_1 switch
			{
				Enum87.const_0 => dateTime.AddDays(int_0), 
				Enum87.const_1 => dateTime.AddMonths(int_0), 
				_ => dateTime.AddYears(int_0), 
			}, 
			Enum87.const_1 => (enum87_1 != Enum87.const_1) ? dateTime.AddYears(int_0) : dateTime.AddMonths(int_0), 
			_ => dateTime.AddYears(int_0), 
		}, bool_0);
	}

	internal static int smethod_32(Enum87 enum87_0, int int_0, bool bool_0)
	{
		switch (enum87_0)
		{
		case Enum87.const_0:
			return int_0;
		case Enum87.const_1:
		{
			DateTime dateTime = smethod_26(int_0, bool_0);
			DateTime dateTime_2 = new DateTime(dateTime.Year, dateTime.Month, 1);
			return smethod_27(dateTime_2, bool_0);
		}
		default:
		{
			DateTime dateTime_ = new DateTime(smethod_26(int_0, bool_0).Year, 1, 1);
			return smethod_27(dateTime_, bool_0);
		}
		}
	}

	internal static int smethod_33(Interface11 interface11_0)
	{
		int num = 0;
		if (interface11_0.imethod_9() != null && interface11_0.imethod_9().Count != 0)
		{
			for (int i = 0; i < interface11_0.imethod_9().Count; i++)
			{
				num += smethod_33(interface11_0.imethod_9()[i]);
			}
			return num;
		}
		return 1;
	}

	private static void smethod_34(Interface42 interface42_0, ArrayList[] arrayList_0, float float_0, float float_1, float float_2, bool bool_0, Class823 class823_0, double double_0, Class847 class847_0, Enum82 enum82_0, float float_3, Rectangle rectangle_0, bool bool_1)
	{
		Class821 chart = class847_0.method_0().Chart;
		int int_ = 0;
		float num = float_1;
		foreach (IList list in arrayList_0)
		{
			SizeF sizeF_ = new SizeF(0f, 0f);
			if (bool_1)
			{
				sizeF_.Height = rectangle_0.Height / list.Count;
				sizeF_.Width = (float)rectangle_0.Width * 0.5f;
			}
			else
			{
				sizeF_.Width = rectangle_0.Width / list.Count;
				sizeF_.Height = (float)rectangle_0.Height * 0.5f;
			}
			Size size = smethod_24(interface42_0, list, int_, class847_0, sizeF_);
			float num2 = float_0;
			for (int j = 0; j < list.Count; j++)
			{
				Class825 @class = (Class825)list[j];
				string string_ = Struct51.smethod_5(chart.vmethod_2(), @class.imethod_0(), @class.imethod_3(), @class.imethod_1());
				int num3 = smethod_33(@class);
				float num4 = (float)((double)num3 * double_0);
				float x = (class823_0.IsPlotOrderReversed ? (num2 - num4 / 2f - (float)(size.Width / 2)) : (num2 + num4 / 2f - (float)(size.Width / 2)));
				float y = (bool_0 ? num : (num - (float)size.Height));
				RectangleF value = new RectangleF(x, y, size.Width, size.Height);
				smethod_38(interface42_0, Rectangle.Round(value), string_, int_, class847_0.Font, class847_0.FontColor, Enum82.const_1, enum82_0);
				class823_0.method_5().method_7(num2, float_3, num2, num);
				if (class823_0.MajorTickMark != Enum84.const_2)
				{
					float num5 = num;
					num5 = (bool_0 ? (num + (float_2 + (float)size.Height)) : (num - (float_2 + (float)size.Height)));
					smethod_35(interface42_0, @class.imethod_9(), num2, float_3, num5, bool_0, class823_0, double_0);
				}
				num2 = (class823_0.IsPlotOrderReversed ? (num2 - num4) : (num2 + num4));
			}
			class823_0.method_5().method_7(num2, float_3, num2, num);
			num = ((!bool_0) ? (num - (float_2 + (float)size.Height)) : (num + (float_2 + (float)size.Height)));
		}
	}

	private static void smethod_35(Interface42 interface42_0, Interface10 interface10_0, float float_0, float float_1, float float_2, bool bool_0, Class823 class823_0, double double_0)
	{
		float num = float_0;
		for (int i = 0; i < interface10_0.Count; i++)
		{
			Class825 interface11_ = (Class825)interface10_0[i];
			int num2 = smethod_33(interface11_);
			float num3 = (float)((double)num2 * double_0);
			num = (class823_0.IsPlotOrderReversed ? (num - num3) : (num + num3));
			class823_0.method_5().method_7(num, float_1, num, float_2);
		}
	}

	internal static Class823 smethod_36(Class823 class823_0)
	{
		Class823 result = null;
		if (class823_0.method_4() == Enum61.const_0)
		{
			result = class823_0.Chart.method_9();
		}
		else if (class823_0.method_4() == Enum61.const_2)
		{
			result = class823_0.Chart.method_10();
		}
		else if (class823_0.method_4() == Enum61.const_1)
		{
			result = class823_0.Chart.method_1();
		}
		else if (class823_0.method_4() == Enum61.const_3)
		{
			result = class823_0.Chart.method_2();
		}
		return result;
	}

	public static void smethod_37(Interface42 interface42_0, Rectangle rectangle_0, string string_0, int int_0, Font font_0, Color color_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = Struct61.smethod_13(enum82_0);
		stringFormat.LineAlignment = Struct61.smethod_13(enum82_1);
		switch (Math.Abs(int_0))
		{
		default:
		{
			double num = Math.Sqrt(Math.Pow(rectangle_0.Width, 2.0) + Math.Pow(rectangle_0.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF = interface42_0.imethod_43(string_0, font_0, (int)num, stringFormat);
			interface42_0.imethod_49(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			interface42_0.imethod_45(-int_0);
			interface42_0.imethod_27(rectangleF_0: new RectangleF((0f - sizeF.Width) / 2f, (0f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), string_0: string_0, font_0: font_0, brush_0: new SolidBrush(color_0), stringFormat_0: stringFormat);
			interface42_0.ResetTransform();
			break;
		}
		case 90:
			interface42_0.imethod_49(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			interface42_0.imethod_45(-int_0);
			rectangle_0 = new Rectangle(-rectangle_0.Height / 2, -rectangle_0.Width / 2, rectangle_0.Height, rectangle_0.Width);
			interface42_0.imethod_28(string_0, font_0, new SolidBrush(color_0), rectangle_0, stringFormat);
			interface42_0.ResetTransform();
			break;
		case 0:
			interface42_0.imethod_28(string_0, font_0, new SolidBrush(color_0), rectangle_0, stringFormat);
			break;
		}
	}

	public static void smethod_38(Interface42 interface42_0, Rectangle rectangle_0, string string_0, int int_0, Font font_0, Color color_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.Alignment = Struct61.smethod_13(enum82_0);
		stringFormat.LineAlignment = Struct61.smethod_13(enum82_1);
		switch (Math.Abs(int_0))
		{
		default:
		{
			double num = Math.Sqrt(Math.Pow(rectangle_0.Width, 2.0) + Math.Pow(rectangle_0.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF = interface42_0.imethod_43(string_0, font_0, (int)num, stringFormat);
			interface42_0.imethod_49(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			interface42_0.imethod_45(-int_0);
			interface42_0.imethod_27(rectangleF_0: new RectangleF((0f - sizeF.Width) / 2f, (0f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), string_0: string_0, font_0: font_0, brush_0: new SolidBrush(color_0), stringFormat_0: stringFormat);
			interface42_0.ResetTransform();
			break;
		}
		case 90:
			interface42_0.imethod_49(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			interface42_0.imethod_45(-int_0);
			rectangle_0 = new Rectangle(-rectangle_0.Height / 2, -rectangle_0.Width / 2, rectangle_0.Height, rectangle_0.Width);
			stringFormat.Trimming = StringTrimming.EllipsisCharacter;
			interface42_0.imethod_28(string_0, font_0, new SolidBrush(color_0), rectangle_0, stringFormat);
			interface42_0.ResetTransform();
			break;
		case 0:
			interface42_0.imethod_28(string_0, font_0, new SolidBrush(color_0), rectangle_0, stringFormat);
			break;
		}
	}

	[Attribute0(true)]
	internal static void smethod_39(Interface42 interface42_0, string string_0, PointF pointF_0, SizeF sizeF_0, int int_0, Font font_0, Color color_0, Enum54 enum54_0)
	{
		Brush brush_ = new SolidBrush(color_0);
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.Trimming = StringTrimming.EllipsisCharacter;
		SizeF sizeF = interface42_0.imethod_41(string_0, font_0, pointF_0, new StringFormat(StringFormat.GenericTypographic));
		double num = (double)Math.Abs(int_0) / 180.0 * Math.PI;
		float num2 = (float)((double)sizeF.Width * Math.Cos(num) + (double)sizeF.Height * Math.Sin(num));
		float num3 = 0f;
		num3 = ((!(num2 <= sizeF_0.Width)) ? ((float)(((double)sizeF_0.Width - (double)sizeF.Height * Math.Sin(num)) / Math.Cos(num))) : sizeF.Width);
		float num4 = (float)((double)sizeF.Height * Math.Sin(num)) / 2f;
		interface42_0.imethod_49(pointF_0.X, pointF_0.Y);
		interface42_0.imethod_45(-int_0);
		RectangleF empty = RectangleF.Empty;
		switch (enum54_0)
		{
		case Enum54.const_0:
			if (int_0 > 0)
			{
				empty = new RectangleF(0f - num3, 0f, num3, sizeF.Height);
				stringFormat.Alignment = StringAlignment.Far;
				interface42_0.imethod_49(0f - num4, 0f);
			}
			else
			{
				empty = new RectangleF(0f, 0f, num3, sizeF.Height);
				stringFormat.Alignment = StringAlignment.Near;
				interface42_0.imethod_49(num4, 0f);
			}
			empty.Y -= sizeF.Height / 2f;
			break;
		case Enum54.const_3:
			if (int_0 < 0)
			{
				empty = new RectangleF(0f - num3, 0f, num3, sizeF.Height);
				stringFormat.Alignment = StringAlignment.Far;
				interface42_0.imethod_49(0f - num4, 0f);
			}
			else
			{
				empty = new RectangleF(0f, 0f, num3, sizeF.Height);
				stringFormat.Alignment = StringAlignment.Near;
				interface42_0.imethod_49(num4, 0f);
			}
			empty.Y -= sizeF.Height / 2f;
			break;
		case Enum54.const_1:
			empty = new RectangleF(0f - num3, (0f - sizeF.Height) / 2f, num3, sizeF.Height);
			stringFormat.Alignment = StringAlignment.Far;
			interface42_0.imethod_49(0f - num4, 0f);
			break;
		default:
			empty = new RectangleF(0f, (0f - sizeF.Height) / 2f, num3, sizeF.Height);
			stringFormat.Alignment = StringAlignment.Near;
			interface42_0.imethod_49(num4, 0f);
			break;
		}
		empty.Height += 3f;
		interface42_0.imethod_27(string_0, font_0, brush_, empty, stringFormat);
		interface42_0.ResetTransform();
	}

	internal static void smethod_40(Class821 class821_0)
	{
		if (class821_0.method_8().method_16())
		{
			return;
		}
		bool flag = false;
		if (class821_0.method_9().MinValue == class821_0.method_9().CrossAt)
		{
			flag = true;
		}
		if (class821_0.Elevation < 0)
		{
			if (flag)
			{
				class821_0.method_1().TickLabelPosition = Enum83.const_3;
				class821_0.method_11().TickLabelPosition = Enum83.const_3;
				class821_0.method_1().IsVisible = false;
				class821_0.method_11().IsVisible = false;
			}
			else if (class821_0.method_1().TickLabelPosition == Enum83.const_1 || !class821_0.method_9().IsPlotOrderReversed)
			{
				class821_0.method_1().TickLabelPosition = Enum83.const_3;
				class821_0.method_11().TickLabelPosition = Enum83.const_3;
			}
		}
	}

	internal static Size smethod_41(Interface42 interface42_0, Class823 class823_0, ArrayList arrayList_0, Rectangle rectangle_0)
	{
		if (class823_0.TickLabelPosition != Enum83.const_3 && arrayList_0.Count != 0)
		{
			Class847 @class = class823_0.method_10();
			int num = 250;
			SizeF sizeF_ = new SizeF(0f, 0f);
			_ = class823_0.Chart;
			int count = arrayList_0.Count;
			sizeF_.Width = rectangle_0.Width / count * class823_0.TickLabelSpacing;
			sizeF_.Height = (float)rectangle_0.Height * 0.5f;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				string text = "";
				text = smethod_28(class823_0, class823_0.arrayList_1[i]);
				Size size = Struct61.smethod_3(interface42_0, text, @class.Rotation, @class.Font, sizeF_, Enum82.const_1, Enum82.const_1);
				if (size.Width > num2)
				{
					num2 = size.Width;
				}
				if (size.Height > num3)
				{
					num3 = size.Height;
				}
				if (i == 0)
				{
					Size size2 = Struct61.smethod_2(class823_0.Chart.imethod_0(), "a", @class.Rotation, @class.Font, rectangle_0.Size, Enum82.const_1, Enum82.const_1);
					class823_0.method_10().method_2(size2.Width * class823_0.method_10().Offset / num);
				}
			}
			class823_0.float_0 = num2;
			class823_0.float_1 = num3;
			return new Size(num2, num3);
		}
		return new Size(0, 0);
	}

	internal static void smethod_42(Interface42 interface42_0, Class823 class823_0)
	{
		if (class823_0.Chart.method_8().method_16())
		{
			return;
		}
		Class821 chart = class823_0.Chart;
		ChartType_Chart type = chart.Type;
		Class851 @class = chart.method_13();
		PointF pointF = Struct48.smethod_4(chart);
		class823_0.method_5().method_7(pointF.X, pointF.Y, pointF.X, pointF.Y - @class.Height);
		Class847 class2 = class823_0.method_10();
		Class844 class3 = chart.method_7().method_9(0);
		Class831 class4 = class3.method_9().method_1(0);
		string string_ = class4.vmethod_6();
		bool bool_ = class4.vmethod_7();
		bool flag = false;
		if (class2.LinkedSource && class4 != null)
		{
			flag = true;
		}
		float num = 0f;
		Enum82 enum82_ = Enum82.const_8;
		if (pointF.X > chart.method_13().method_2())
		{
			enum82_ = Enum82.const_7;
			num = pointF.X;
			num += (float)class823_0.method_19();
		}
		else
		{
			num = pointF.X - class823_0.float_0;
			num -= (float)class823_0.method_19();
		}
		ArrayList arrayList_ = class823_0.arrayList_1;
		double num2 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MaxValue) : class823_0.MaxValue);
		double num3 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MinValue) : class823_0.MinValue);
		double num4 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MajorUnit) : class823_0.MajorUnit);
		for (int i = 0; i < class823_0.arrayList_1.Count; i++)
		{
			double num5 = (double)class823_0.arrayList_1[i];
			double num6 = (class823_0.IsLogarithmic ? class823_0.method_7(num5) : num5);
			if (i - 1 > 0)
			{
				if (Math.Abs(Struct63.smethod_9(num5, Convert.ToDouble(arrayList_[i - 1]))) != num4)
				{
					continue;
				}
			}
			else if (i + 1 < arrayList_.Count && Math.Abs(Struct63.smethod_9(num5, Convert.ToDouble(arrayList_[i + 1]))) != num4)
			{
				continue;
			}
			float num7 = (float)((num5 - num3) / (num2 - num3) * (double)chart.method_13().Height);
			num7 = (class823_0.IsPlotOrderReversed ? (pointF.Y - @class.Height + num7) : (pointF.Y - num7));
			if (class823_0.TickLabelPosition != Enum83.const_3)
			{
				if (Struct47.smethod_56(type))
				{
					num6 /= 100.0;
					string_ = "0%";
				}
				string text = "";
				num6 = (class823_0.IsLogarithmic ? num6 : (num6 * Math.Pow(10.0, (double)class823_0.method_12().vmethod_0())));
				Color fontColor = class2.FontColor;
				if (flag)
				{
					text = Struct51.smethod_5(chart.vmethod_2(), num6, string_, bool_);
					fontColor = Struct51.smethod_6(num6, string_, fontColor);
				}
				else
				{
					text = smethod_28(class823_0, num6);
					fontColor = Struct51.smethod_6(num6, class2.imethod_0(), fontColor);
				}
				RectangleF value = new RectangleF(num, num7 - class823_0.float_1 / 2f, class823_0.float_0, class823_0.float_1);
				smethod_37(interface42_0, Rectangle.Round(value), text, class2.Rotation, class2.Font, fontColor, enum82_, Enum82.const_1);
			}
			smethod_43(interface42_0, class823_0, pointF.X, num7);
		}
		smethod_44(interface42_0, class823_0, pointF.X, pointF.Y - @class.Height, pointF.Y);
	}

	private static void smethod_43(Interface42 interface42_0, Class823 class823_0, float float_0, float float_1)
	{
		if (class823_0.MajorTickMark == Enum84.const_2 || !class823_0.method_5().IsVisible)
		{
			return;
		}
		Class821 chart = class823_0.Chart;
		chart.method_13();
		bool flag = false;
		bool flag2 = false;
		switch (class823_0.MajorTickMark)
		{
		case Enum84.const_0:
			flag = true;
			flag2 = true;
			break;
		case Enum84.const_1:
			flag = true;
			if (float_0 > chart.method_13().method_2())
			{
				flag = false;
				flag2 = true;
			}
			break;
		case Enum84.const_3:
			flag2 = true;
			if (float_0 > chart.method_13().method_2())
			{
				flag2 = false;
				flag = true;
			}
			break;
		}
		if (flag)
		{
			class823_0.method_5().method_7(float_0, float_1, float_0 + (float)class823_0.method_19(), float_1);
		}
		if (flag2)
		{
			class823_0.method_5().method_7(float_0 - (float)class823_0.method_19(), float_1, float_0, float_1);
		}
	}

	private static void smethod_44(Interface42 interface42_0, Class823 class823_0, float float_0, float float_1, float float_2)
	{
		if (class823_0.MinorTickMark == Enum84.const_2 || !class823_0.method_5().IsVisible)
		{
			return;
		}
		Class821 chart = class823_0.Chart;
		chart.method_13();
		bool flag = false;
		bool flag2 = false;
		switch (class823_0.MinorTickMark)
		{
		case Enum84.const_0:
			flag = true;
			flag2 = true;
			break;
		case Enum84.const_1:
			flag = true;
			if (float_0 > chart.method_13().method_2())
			{
				flag = false;
				flag2 = true;
			}
			break;
		case Enum84.const_3:
			flag2 = true;
			if (float_0 > chart.method_13().method_2())
			{
				flag2 = false;
				flag = true;
			}
			break;
		}
		float num = (float)(class823_0.MinorUnit / (class823_0.MaxValue - class823_0.MinValue) * (double)(float_2 - float_1));
		float num2;
		if (!class823_0.IsPlotOrderReversed)
		{
			num2 = float_2;
			num = 0f - num;
		}
		else
		{
			num2 = float_1;
		}
		float num3 = num2;
		do
		{
			if (flag)
			{
				class823_0.method_5().method_7(float_0, num3, float_0 + (float)class823_0.method_21(), num3);
			}
			if (flag2)
			{
				class823_0.method_5().method_7(float_0 - (float)class823_0.method_21(), num3, float_0, num3);
			}
			num3 += num;
		}
		while (float_1 <= num3 && num3 <= float_2);
	}

	internal static void smethod_45(Interface42 interface42_0, Class823 class823_0, int int_0, Rectangle rectangle_0, bool bool_0)
	{
		if (class823_0.Chart.method_8().method_16())
		{
			return;
		}
		if (class823_0.CategoryType == Enum64.const_2)
		{
			smethod_46(interface42_0, class823_0);
			return;
		}
		Class821 chart = class823_0.Chart;
		chart.method_13();
		PointF[] array = Struct48.smethod_2(chart);
		Class823 @class = chart.method_9();
		double num = @class.method_13();
		double num2 = @class.method_14();
		double num3 = @class.method_15();
		bool flag = false;
		if (@class.MinValue == @class.CrossAt)
		{
			flag = true;
		}
		num3 = ((!@class.IsPlotOrderReversed) ? (num3 - num2) : (num - num3));
		int num4 = (int)(num3 / (num - num2) * (double)chart.method_13().Height);
		if (num4 != 0)
		{
			class823_0.method_5().method_7(array[0].X, array[0].Y - (float)num4, array[1].X, array[1].Y - (float)num4);
		}
		if (chart.Elevation >= 0)
		{
			class823_0.method_5().method_7(array[0].X, array[0].Y, array[1].X, array[1].Y);
		}
		if (class823_0.TickLabelPosition == Enum83.const_2)
		{
			array[0].Y -= num4;
			array[1].Y -= num4;
		}
		chart.method_7();
		Class847 class2 = class823_0.method_10();
		ArrayList arrayList = chart.method_7().method_0();
		float num5 = class823_0.method_10().method_1();
		if (class823_0.TickLabelPosition != Enum83.const_3)
		{
			num5 += (float)(class823_0.method_19() + class823_0.method_21());
		}
		bool flag2;
		int num6;
		if (flag2 = class823_0.AxisBetweenCategories || chart.IsDataTableShown)
		{
			num6 = int_0;
		}
		else
		{
			num6 = int_0 - 1;
			if (num6 == 0)
			{
				num6 = 1;
			}
		}
		double num7 = ((array[1].X == array[0].X) ? (Math.PI / 2.0) : Math.Atan(Math.Abs((array[0].Y - array[1].Y) / (array[1].X - array[0].X))));
		float num8 = (array[1].X - array[0].X) / (float)num6;
		float num9 = (array[1].Y - array[0].Y) / (float)num6;
		PointF empty = PointF.Empty;
		for (int i = 0; i < int_0; i++)
		{
			int num10 = i;
			if (class823_0.IsPlotOrderReversed)
			{
				num10 = int_0 - 1 - i;
			}
			string string_ = "";
			Color color_ = class2.FontColor;
			if (num10 < class823_0.arrayList_1.Count)
			{
				string_ = smethod_28(class823_0, class823_0.arrayList_1[num10]);
				color_ = Struct51.smethod_6(class823_0.arrayList_1[num10], class2.imethod_0(), color_);
				if (class2.LinkedSource && arrayList.Count > 0)
				{
					string text = "";
					bool flag3 = false;
					text = ((num10 < arrayList.Count) ? ((Class825)arrayList[num10]).imethod_3() : "");
					flag3 = num10 < arrayList.Count && ((Class825)arrayList[num10]).imethod_1();
					string_ = Struct51.smethod_5(chart.vmethod_2(), class823_0.arrayList_1[num10], text, flag3);
					color_ = Struct51.smethod_6(class823_0.arrayList_1[num10], text, color_);
				}
			}
			if (class823_0.TickLabelPosition == Enum83.const_3 || num10 % class823_0.TickLabelSpacing != 0)
			{
				continue;
			}
			RectangleF value = new RectangleF(0f, 0f, 0f, 0f);
			bool flag4 = false;
			if (flag2)
			{
				if (chart.Elevation >= 0)
				{
					if (array[0].Y == array[1].Y)
					{
						value.X = ((num8 < 0f) ? (array[0].X + (float)(i + 1) * num8) : (array[0].X + (float)i * num8));
						value.Y = array[0].Y + num5;
						value.Width = Math.Abs(num8);
						value.Height = class823_0.float_2;
						flag4 = true;
						empty.X = ((num8 < 0f) ? (value.X - num8 / 2f) : (value.X + num8 / 2f));
						empty.Y = value.Y;
					}
					else if (num7 <= Math.PI / 4.0)
					{
						value.X = ((num8 < 0f) ? (array[0].X + (float)(i + 1) * num8) : (array[0].X + (float)i * num8));
						value.Y = ((num9 > 0f) ? (array[0].Y + (float)(i + 1) * num9) : (array[0].Y + (float)i * num9));
						value.Width = Math.Abs(num8);
						value.Height = class823_0.float_2;
					}
					else
					{
						value.X = ((num9 > 0f) ? (array[0].X + (float)i * num8) : (array[0].X + (float)(i + 1) * num8));
						value.X = ((num8 * num9 <= 0f) ? (value.X + num5 * (float)Math.Sin(num7)) : (value.X - num5 * (float)Math.Sin(num7) - class823_0.float_3));
						value.Y = ((num9 > 0f) ? (array[0].Y + (float)i * num9) : (array[0].Y + (float)(i + 1) * num9));
						value.Y += (Math.Abs(num9) - class823_0.float_2) * (float)Math.Sin(num7) / 2f;
						value.Width = class823_0.float_3;
						value.Height = class823_0.float_2;
					}
				}
				else if (chart.Elevation < 0 && !flag && class823_0.TickLabelPosition == Enum83.const_2)
				{
					if (array[0].Y == array[1].Y)
					{
						value.X = ((num8 > 0f) ? (array[0].X + (float)i * num8) : (array[0].X + (float)(i + 1) * num8));
						value.Y = array[0].Y - class823_0.float_2 - num5;
						value.Width = Math.Abs(num8);
						value.Height = class823_0.float_2;
					}
					else if (num7 <= Math.PI / 4.0)
					{
						value.X = ((num8 < 0f) ? (array[0].X + (float)(i + 1) * num8) : (array[0].X + (float)i * num8));
						value.Y = ((num9 < 0f) ? (array[0].Y + (float)(i + 1) * num9) : (array[0].Y + (float)i * num9));
						value.Y -= class823_0.float_2;
						value.Width = Math.Abs(num8);
						value.Height = class823_0.float_2;
					}
					else
					{
						value.X = ((num9 < 0f) ? (array[0].X + (float)i * num8) : (array[0].X + (float)(i + 1) * num8));
						value.X = ((num8 * num9 >= 0f) ? (value.X + num5 * (float)Math.Sin(num7)) : (value.X - num5 * (float)Math.Sin(num7) - class823_0.float_3));
						value.Y = ((num9 < 0f) ? (array[0].Y + (float)i * num9) : (array[0].Y + (float)(i + 1) * num9));
						value.Y -= (Math.Abs(num9) - class823_0.float_2) * (float)Math.Sin(num7) / 2f;
						value.Y -= class823_0.float_2;
						value.Width = class823_0.float_3;
						value.Height = class823_0.float_2;
					}
				}
			}
			else if (chart.Elevation >= 0)
			{
				if (array[0].Y == array[1].Y)
				{
					value.X = ((num8 < 0f) ? (array[0].X + (float)i * num8 + num8 / 2f) : (array[0].X + (float)i * num8 - num8 / 2f));
					value.Y = array[0].Y + num5;
					value.Width = Math.Abs(num8);
					value.Height = class823_0.float_2;
				}
				else if (num7 <= Math.PI / 4.0)
				{
					value.X = array[0].X + (float)i * num8 - Math.Abs(num8) / 2f;
					value.Y = array[0].Y + (float)i * num9 + num5;
					value.Width = Math.Abs(num8);
					value.Height = class823_0.float_2;
				}
				else
				{
					value.X = array[0].X + (float)i * num8;
					value.X = ((num8 * num9 <= 0f) ? (value.X + num5 * (float)Math.Sin(num7)) : (value.X - num5 * (float)Math.Sin(num7) - class823_0.float_3));
					value.Y = array[0].Y + (float)i * num9 - class823_0.float_2 / 2f;
					value.Width = class823_0.float_3;
					value.Height = class823_0.float_2;
				}
			}
			else if (chart.Elevation < 0 && !flag && class823_0.TickLabelPosition == Enum83.const_2)
			{
				if (array[0].Y == array[1].Y)
				{
					value.X = ((num8 > 0f) ? (array[0].X + (float)i * num8 - num8 / 2f) : (array[0].X + (float)i * num8 + num8 / 2f));
					value.Y = array[0].Y - class823_0.float_2 - num5;
					value.Width = Math.Abs(num8);
					value.Height = class823_0.float_2;
				}
				else if (num7 <= Math.PI / 4.0)
				{
					value.X = array[0].X + (float)i * num8 - Math.Abs(num8) / 2f;
					value.Y = array[0].Y + (float)i * num9;
					value.Y -= class823_0.float_2 + num5;
					value.Width = Math.Abs(num8);
					value.Height = class823_0.float_2;
				}
				else
				{
					value.X = ((num9 < 0f) ? (array[0].X + (float)i * num8) : (array[0].X + (float)i * num8));
					value.X = ((num8 * num9 >= 0f) ? (value.X + num5 * (float)Math.Sin(num7)) : (value.X - num5 * (float)Math.Sin(num7) - class823_0.float_3));
					value.Y = array[0].Y + (float)i * num9 - class823_0.float_2 / 2f;
					value.Width = class823_0.float_3;
					value.Height = class823_0.float_2;
				}
			}
			if (class2.Rotation != 0 && class2.Rotation != 90 && class2.Rotation != -90 && flag4)
			{
				smethod_39(interface42_0, string_, empty, new SizeF(class823_0.float_3, class823_0.float_2), class2.Rotation, class2.Font, color_, class823_0.method_0());
				continue;
			}
			Size size = Struct61.smethod_3(interface42_0, string_, class2.Rotation, class2.Font, value.Size, Enum82.const_1, Enum82.const_1);
			Struct61.smethod_12(interface42_0, string_, class2.Font, new SizeF(value.Height, value.Width));
			value.Height = size.Height;
			smethod_37(interface42_0, Rectangle.Round(value), string_, class2.Rotation, class2.Font, color_, Enum82.const_1, Enum82.const_1);
		}
		smethod_47(interface42_0, class823_0, num4, int_0);
		ArrayList[] array2 = chart.method_7().method_4();
		_ = chart.method_9().IsPlotOrderReversed;
		float y = array[0].Y;
		Enum82 enum82_ = Enum82.const_9;
		if (array2 != null && array2.Length > 0 && arrayList.Count > 0 && class823_0.TickLabelPosition != Enum83.const_3)
		{
			IList list = array2[0];
			Class825 class3 = (Class825)list[0];
			string string_2 = Struct51.smethod_5(chart.vmethod_2(), class3.imethod_0(), class3.imethod_3(), class3.imethod_1());
			Struct61.smethod_3(class823_0.Chart.imethod_0(), string_2, 0, class2.Font, new SizeF(rectangle_0.Width, rectangle_0.Height), Enum82.const_1, Enum82.const_1);
			float float_ = (class823_0.IsPlotOrderReversed ? array[1].X : array[0].X);
			float float_2 = y + num5 * (float)(array2.Length + 1) + class823_0.float_1;
			float float_3 = y;
			bool bool_ = false;
			if (array[0].Y == array[1].Y)
			{
				smethod_34(interface42_0, array2, float_, float_2, num5, bool_, class823_0, num8, class2, enum82_, float_3, rectangle_0, bool_0);
			}
		}
	}

	private static void smethod_46(Interface42 interface42_0, Class823 class823_0)
	{
		Class821 chart = class823_0.Chart;
		chart.method_13();
		PointF[] array = Struct48.smethod_2(chart);
		double num = ((!chart.method_9().IsPlotOrderReversed) ? (chart.method_9().CrossAt - chart.method_9().MinValue) : (chart.method_9().MaxValue - chart.method_9().CrossAt));
		int num2 = (int)(num / (chart.method_9().MaxValue - chart.method_9().MinValue) * (double)chart.method_13().Height);
		if (num2 != 0)
		{
			class823_0.method_5().method_7(array[0].X, array[0].Y - (float)num2, array[1].X, array[1].Y - (float)num2);
		}
		if (chart.Elevation >= 0)
		{
			class823_0.method_5().method_7(array[0].X, array[0].Y, array[1].X, array[1].Y);
		}
		if (class823_0.TickLabelPosition == Enum83.const_2)
		{
			array[0].Y -= num2;
			array[1].Y -= num2;
		}
		chart.method_7();
		Class847 @class = class823_0.method_10();
		ArrayList arrayList = chart.method_7().method_0();
		float num3 = class823_0.method_10().method_1();
		if (class823_0.TickLabelPosition != Enum83.const_3)
		{
			num3 += (float)(class823_0.method_19() + class823_0.method_21());
		}
		double num4 = ((array[1].X == array[0].X) ? (Math.PI / 2.0) : Math.Atan(Math.Abs((array[0].Y - array[1].Y) / (array[1].X - array[0].X))));
		int int_ = (int)class823_0.MaxValue;
		int int_2 = (int)class823_0.MinValue;
		Enum87 baseUnitScale = class823_0.BaseUnitScale;
		bool flag;
		int num5;
		if (flag = class823_0.AxisBetweenCategories || chart.IsDataTableShown)
		{
			num5 = smethod_29(baseUnitScale, int_, int_2, class823_0.Chart.vmethod_0()) + 1;
		}
		else
		{
			num5 = smethod_29(baseUnitScale, int_, int_2, class823_0.Chart.vmethod_0());
			if (num5 == 0)
			{
				num5 = 1;
			}
		}
		float num6 = (array[1].X - array[0].X) / (float)num5;
		float num7 = (array[1].Y - array[0].Y) / (float)num5;
		ArrayList arrayList_ = class823_0.arrayList_1;
		for (int i = 0; i < arrayList_.Count; i++)
		{
			int num8 = i;
			if (class823_0.IsPlotOrderReversed)
			{
				num8 = arrayList_.Count - 1 - i;
			}
			int int_3 = Convert.ToInt32(class823_0.arrayList_1[i]);
			smethod_29(baseUnitScale, int_3, int_2, class823_0.Chart.vmethod_0());
			string string_ = "";
			Color color_ = @class.FontColor;
			if (num8 < class823_0.arrayList_1.Count)
			{
				string_ = smethod_28(class823_0, class823_0.arrayList_1[num8]);
				color_ = Struct51.smethod_6(class823_0.arrayList_1[num8], @class.imethod_0(), color_);
				if (@class.LinkedSource && arrayList.Count > 0)
				{
					string text = "";
					bool flag2 = false;
					text = ((num8 < arrayList.Count) ? ((Class825)arrayList[num8]).imethod_3() : "");
					flag2 = num8 < arrayList.Count && ((Class825)arrayList[num8]).imethod_1();
					string_ = Struct51.smethod_5(chart.vmethod_2(), class823_0.arrayList_1[num8], text, flag2);
					color_ = Struct51.smethod_6(class823_0.arrayList_1[num8], text, color_);
				}
			}
			if (class823_0.TickLabelPosition == Enum83.const_3)
			{
				continue;
			}
			RectangleF value = new RectangleF(0f, 0f, 0f, 0f);
			if (flag)
			{
				if (chart.Elevation >= 0)
				{
					if (array[0].Y == array[1].Y)
					{
						value.X = ((num6 < 0f) ? (array[0].X + (float)(i + 1) * num6) : (array[0].X + (float)i * num6));
						value.Y = array[0].Y + num3;
						value.Width = Math.Abs(num6);
						value.Height = class823_0.float_1;
					}
					else if (num4 <= Math.PI / 4.0)
					{
						value.X = ((num6 < 0f) ? (array[0].X + (float)(i + 1) * num6) : (array[0].X + (float)i * num6));
						value.Y = ((num7 > 0f) ? (array[0].Y + (float)(i + 1) * num7) : (array[0].Y + (float)i * num7));
						value.Width = class823_0.float_0;
						value.Height = class823_0.float_1;
					}
					else
					{
						value.X = ((num7 > 0f) ? (array[0].X + (float)i * num6) : (array[0].X + (float)(i + 1) * num6));
						value.X = ((num6 * num7 <= 0f) ? (value.X + num3 * (float)Math.Sin(num4)) : (value.X - num3 * (float)Math.Sin(num4) - class823_0.float_0));
						value.Y = ((num7 > 0f) ? (array[0].Y + (float)i * num7) : (array[0].Y + (float)(i + 1) * num7));
						value.Y += (Math.Abs(num7) - class823_0.float_1) * (float)Math.Sin(num4) / 2f;
						value.Width = class823_0.float_0;
						value.Height = class823_0.float_1;
					}
				}
				else if (chart.Elevation < 0 && num != 0.0 && class823_0.TickLabelPosition == Enum83.const_2)
				{
					if (array[0].Y == array[1].Y)
					{
						value.X = ((num6 > 0f) ? (array[0].X + (float)i * num6) : (array[0].X + (float)(i + 1) * num6));
						value.Y = array[0].Y - class823_0.float_1 - num3;
						value.Width = class823_0.float_0;
						value.Height = class823_0.float_1;
					}
					else if (num4 <= Math.PI / 4.0)
					{
						value.X = ((num6 < 0f) ? (array[0].X + (float)(i + 1) * num6) : (array[0].X + (float)i * num6));
						value.Y = ((num7 < 0f) ? (array[0].Y + (float)(i + 1) * num7) : (array[0].Y + (float)i * num7));
						value.Y -= class823_0.float_1;
						value.Width = class823_0.float_0;
						value.Height = class823_0.float_1;
					}
					else
					{
						value.X = ((num7 < 0f) ? (array[0].X + (float)i * num6) : (array[0].X + (float)(i + 1) * num6));
						value.X = ((num6 * num7 >= 0f) ? (value.X + num3 * (float)Math.Sin(num4)) : (value.X - num3 * (float)Math.Sin(num4) - class823_0.float_0));
						value.Y = ((num7 < 0f) ? (array[0].Y + (float)i * num7) : (array[0].Y + (float)(i + 1) * num7));
						value.Y -= (Math.Abs(num7) - class823_0.float_1) * (float)Math.Sin(num4) / 2f;
						value.Y -= class823_0.float_1;
						value.Width = class823_0.float_0;
						value.Height = class823_0.float_1;
					}
				}
			}
			else if (chart.Elevation >= 0)
			{
				if (array[0].Y == array[1].Y)
				{
					value.X = ((num6 < 0f) ? (array[0].X + (float)i * num6 + num6 / 2f) : (array[0].X + (float)i * num6 - num6 / 2f));
					value.Y = array[0].Y + num3;
					value.Width = Math.Abs(num6);
					value.Height = class823_0.float_1;
				}
				else if (num4 <= Math.PI / 4.0)
				{
					value.X = array[0].X + (float)i * num6 - Math.Abs(num6) / 2f;
					value.Y = array[0].Y + (float)i * num7 + num3;
					value.Width = Math.Abs(num6);
					value.Height = class823_0.float_1;
				}
				else
				{
					value.X = array[0].X + (float)i * num6;
					value.X = ((num6 * num7 <= 0f) ? (value.X + num3 * (float)Math.Sin(num4)) : (value.X - num3 * (float)Math.Sin(num4) - class823_0.float_0));
					value.Y = array[0].Y + (float)i * num7 - class823_0.float_1 / 2f;
					value.Width = class823_0.float_0;
					value.Height = class823_0.float_1;
				}
			}
			else if (chart.Elevation < 0 && num != 0.0 && class823_0.TickLabelPosition == Enum83.const_2)
			{
				if (array[0].Y == array[1].Y)
				{
					value.X = ((num6 > 0f) ? (array[0].X + (float)i * num6 - num6 / 2f) : (array[0].X + (float)i * num6 + num6 / 2f));
					value.Y = array[0].Y - class823_0.float_1 - num3;
					value.Width = Math.Abs(num6);
					value.Height = class823_0.float_1;
				}
				else if (num4 <= Math.PI / 4.0)
				{
					value.X = array[0].X + (float)i * num6 - Math.Abs(num6) / 2f;
					value.Y = array[0].Y + (float)i * num7;
					value.Y -= class823_0.float_1 + num3;
					value.Width = Math.Abs(num6);
					value.Height = class823_0.float_1;
				}
				else
				{
					value.X = ((num7 < 0f) ? (array[0].X + (float)i * num6) : (array[0].X + (float)i * num6));
					value.X = ((num6 * num7 >= 0f) ? (value.X + num3 * (float)Math.Sin(num4)) : (value.X - num3 * (float)Math.Sin(num4) - class823_0.float_0));
					value.Y = array[0].Y + (float)i * num7 - class823_0.float_1 / 2f;
					value.Width = class823_0.float_0;
					value.Height = class823_0.float_1;
				}
			}
			smethod_37(interface42_0, Rectangle.Round(value), string_, @class.Rotation, @class.Font, color_, Enum82.const_1, Enum82.const_1);
		}
		smethod_48(interface42_0, class823_0, num2);
	}

	private static void smethod_47(Interface42 interface42_0, Class823 class823_0, int int_0, int int_1)
	{
		Class821 chart = class823_0.Chart;
		chart.method_13();
		if ((class823_0.MajorTickMark == Enum84.const_2 && class823_0.MinorTickMark == Enum84.const_2) || !class823_0.method_5().IsVisible)
		{
			return;
		}
		bool flag = class823_0.AxisBetweenCategories || class823_0.Chart.IsDataTableShown;
		PointF[] array;
		if (class823_0.method_4() == Enum61.const_4)
		{
			array = Struct48.smethod_3(chart);
			flag = true;
		}
		else
		{
			array = Struct48.smethod_2(chart);
		}
		double num = ((array[1].X == array[0].X) ? (Math.PI / 2.0) : Math.Atan(Math.Abs((array[0].Y - array[1].Y) / (array[1].X - array[0].X))));
		int num2;
		if (flag)
		{
			num2 = int_1;
		}
		else
		{
			num2 = int_1 - 1;
			if (num2 == 0)
			{
				num2 = 1;
			}
		}
		if (chart.Elevation < 0 && int_0 > 0)
		{
			array[0].Y -= int_0;
			array[1].Y -= int_0;
			int_0 = 0;
		}
		while (true)
		{
			if (!(num <= Math.PI / 4.0))
			{
				bool flag2 = false;
				bool flag3 = false;
				switch (class823_0.MajorTickMark)
				{
				case Enum84.const_0:
					flag2 = true;
					flag3 = true;
					break;
				case Enum84.const_1:
					if (chart.Rotation >= 90 && (chart.Rotation < 225 || chart.Rotation >= 270))
					{
						flag3 = true;
					}
					else
					{
						flag2 = true;
					}
					break;
				case Enum84.const_3:
					if (chart.Rotation >= 90 && (chart.Rotation < 225 || chart.Rotation >= 270))
					{
						flag2 = true;
					}
					else
					{
						flag3 = true;
					}
					break;
				}
				PointF pointF;
				PointF pointF2;
				if (!class823_0.IsPlotOrderReversed)
				{
					pointF = array[0];
					pointF2 = array[1];
				}
				else
				{
					pointF = array[1];
					pointF2 = array[0];
				}
				float num3 = (pointF2.X - pointF.X) / (float)num2;
				float num4 = (pointF2.Y - pointF.Y) / (float)num2;
				if (num3 == 0f && num4 == 0f)
				{
					break;
				}
				float num5 = pointF.X;
				for (float num6 = pointF.Y; (pointF.Y <= num6 && num6 <= pointF2.Y) || (pointF.Y >= num6 && num6 >= pointF2.Y) || Math.Round(num6) == Math.Round(pointF.Y) || Math.Round(num6) == Math.Round(pointF2.Y); num6 += (float)class823_0.TickMarkSpacing * num4)
				{
					if (flag2)
					{
						class823_0.method_5().method_7(num5, num6, num5 + (float)class823_0.method_19(), num6);
					}
					if (flag3)
					{
						class823_0.method_5().method_7(num5 - (float)class823_0.method_19(), num6, num5, num6);
					}
					num5 += (float)class823_0.TickMarkSpacing * num3;
				}
				bool flag4 = false;
				bool flag5 = false;
				switch (class823_0.MinorTickMark)
				{
				case Enum84.const_0:
					flag4 = true;
					flag5 = true;
					break;
				case Enum84.const_1:
					if (chart.Rotation >= 90 && (chart.Rotation < 225 || chart.Rotation >= 270))
					{
						flag5 = true;
					}
					else
					{
						flag4 = true;
					}
					break;
				case Enum84.const_3:
					if (chart.Rotation >= 90 && (chart.Rotation < 225 || chart.Rotation >= 270))
					{
						flag4 = true;
					}
					else
					{
						flag5 = true;
					}
					break;
				}
				num5 = pointF.X + (float)class823_0.TickMarkSpacing * num3 / 2f;
				for (float num6 = pointF.Y + (float)class823_0.TickMarkSpacing * num4 / 2f; (pointF.Y <= num6 && num6 <= pointF2.Y) || (pointF.Y >= num6 && num6 >= pointF2.Y) || Math.Round(num6) == Math.Round(pointF.Y) || Math.Round(num6) == Math.Round(pointF2.Y); num6 += (float)class823_0.TickMarkSpacing * num4)
				{
					if (flag4)
					{
						class823_0.method_5().method_7(num5, num6, num5 + (float)class823_0.method_21(), num6);
					}
					if (flag5)
					{
						class823_0.method_5().method_7(num5 - (float)class823_0.method_21(), num6, num5, num6);
					}
					if (class823_0.MajorTickMark == Enum84.const_2)
					{
						num5 += (float)class823_0.TickMarkSpacing * num3 / 2f;
						num6 += (float)class823_0.TickMarkSpacing * num4 / 2f;
						if ((pointF.Y <= num6 && num6 <= pointF2.Y) || (pointF.Y >= num6 && num6 >= pointF2.Y) || Math.Round(num6) == Math.Round(pointF.Y) || Math.Round(num6) == Math.Round(pointF2.Y))
						{
							if (flag4)
							{
								class823_0.method_5().method_7(num5, num6, num5 + (float)class823_0.method_21(), num6);
							}
							if (flag5)
							{
								class823_0.method_5().method_7(num5 - (float)class823_0.method_21(), num6, num5, num6);
							}
						}
						num5 -= (float)class823_0.TickMarkSpacing * num3 / 2f;
						num6 -= (float)class823_0.TickMarkSpacing * num4 / 2f;
					}
					num5 += (float)class823_0.TickMarkSpacing * num3;
				}
			}
			else
			{
				bool flag6 = false;
				bool flag7 = false;
				switch (class823_0.MajorTickMark)
				{
				case Enum84.const_0:
					flag6 = true;
					flag7 = true;
					break;
				case Enum84.const_1:
					if (chart.Elevation >= 0)
					{
						flag6 = true;
					}
					else
					{
						flag7 = true;
					}
					break;
				case Enum84.const_3:
					if (chart.Elevation >= 0)
					{
						flag7 = true;
					}
					else
					{
						flag6 = true;
					}
					break;
				}
				PointF pointF;
				PointF pointF2;
				if (!class823_0.IsPlotOrderReversed)
				{
					pointF = array[0];
					pointF2 = array[1];
				}
				else
				{
					pointF = array[1];
					pointF2 = array[0];
				}
				float num3 = (pointF2.X - pointF.X) / (float)num2;
				float num4 = (pointF2.Y - pointF.Y) / (float)num2;
				if (num3 == 0f && num4 == 0f)
				{
					break;
				}
				float num7 = pointF.X;
				float num8 = pointF.Y;
				while ((pointF.X <= num7 && num7 <= pointF2.X) || (pointF.X >= num7 && num7 >= pointF2.X) || Math.Round(num7) == Math.Round(pointF.X) || Math.Round(num7) == Math.Round(pointF2.X))
				{
					if (flag6)
					{
						class823_0.method_5().method_7(num7, num8 - (float)class823_0.method_19(), num7, num8);
					}
					if (flag7)
					{
						class823_0.method_5().method_7(num7, num8, num7, num8 + (float)class823_0.method_19());
					}
					num7 += (float)class823_0.TickMarkSpacing * num3;
					num8 += (float)class823_0.TickMarkSpacing * num4;
				}
				bool flag8 = false;
				bool flag9 = false;
				switch (class823_0.MinorTickMark)
				{
				case Enum84.const_0:
					flag8 = true;
					flag9 = true;
					break;
				case Enum84.const_1:
					if (chart.Elevation >= 0)
					{
						flag8 = true;
					}
					else
					{
						flag9 = true;
					}
					break;
				case Enum84.const_3:
					if (chart.Elevation >= 0)
					{
						flag9 = true;
					}
					else
					{
						flag8 = true;
					}
					break;
				}
				num7 = pointF.X + (float)class823_0.TickMarkSpacing * num3 / 2f;
				num8 = pointF.Y + (float)class823_0.TickMarkSpacing * num4 / 2f;
				while ((pointF.X <= num7 && num7 <= pointF2.X) || (pointF.X >= num7 && num7 >= pointF2.X) || Math.Round(num7) == Math.Round(pointF.X) || Math.Round(num7) == Math.Round(pointF2.X))
				{
					if (flag8)
					{
						class823_0.method_5().method_7(num7, num8 - (float)class823_0.method_21(), num7, num8);
					}
					if (flag9)
					{
						class823_0.method_5().method_7(num7, num8, num7, num8 + (float)class823_0.method_21());
					}
					if (class823_0.MajorTickMark == Enum84.const_2)
					{
						num7 += (float)class823_0.TickMarkSpacing * num3 / 2f;
						num8 += (float)class823_0.TickMarkSpacing * num4 / 2f;
						if ((pointF.Y <= num8 && num8 <= pointF2.Y) || (pointF.Y >= num8 && num8 >= pointF2.Y) || Math.Round(num8) == Math.Round(pointF.Y) || Math.Round(num8) == Math.Round(pointF2.Y))
						{
							if (flag8)
							{
								class823_0.method_5().method_7(num7, num8 - (float)class823_0.method_21(), num7, num8);
							}
							if (flag9)
							{
								class823_0.method_5().method_7(num7, num8, num7, num8 + (float)class823_0.method_21());
							}
						}
						num7 -= (float)class823_0.TickMarkSpacing * num3 / 2f;
						num8 -= (float)class823_0.TickMarkSpacing * num4 / 2f;
					}
					num7 += (float)class823_0.TickMarkSpacing * num3;
					num8 += (float)class823_0.TickMarkSpacing * num4;
				}
			}
			if (int_0 > 0)
			{
				array[0].Y -= int_0;
				array[1].Y -= int_0;
				int_0 = 0;
				continue;
			}
			break;
		}
	}

	private static void smethod_48(Interface42 interface42_0, Class823 class823_0, int int_0)
	{
		Class821 chart = class823_0.Chart;
		chart.method_13();
		if ((class823_0.MajorTickMark == Enum84.const_2 && class823_0.MinorTickMark == Enum84.const_2) || !class823_0.method_5().IsVisible)
		{
			return;
		}
		PointF[] array = Struct48.smethod_2(chart);
		double num = ((array[1].X == array[0].X) ? (Math.PI / 2.0) : Math.Atan(Math.Abs((array[0].Y - array[1].Y) / (array[1].X - array[0].X))));
		int int_ = (int)class823_0.MaxValue;
		int int_2 = (int)class823_0.MinValue;
		Enum87 baseUnitScale = class823_0.BaseUnitScale;
		int num2;
		if (class823_0.AxisBetweenCategories || chart.IsDataTableShown)
		{
			num2 = smethod_29(baseUnitScale, int_, int_2, class823_0.Chart.vmethod_0()) + 1;
		}
		else
		{
			num2 = smethod_29(baseUnitScale, int_, int_2, class823_0.Chart.vmethod_0());
			if (num2 == 0)
			{
				num2 = 1;
			}
		}
		if (chart.Elevation < 0 && int_0 > 0)
		{
			array[0].Y -= int_0;
			array[1].Y -= int_0;
			int_0 = 0;
		}
		while (true)
		{
			if (!(num <= Math.PI / 4.0))
			{
				bool flag = false;
				bool flag2 = false;
				switch (class823_0.MajorTickMark)
				{
				case Enum84.const_0:
					flag = true;
					flag2 = true;
					break;
				case Enum84.const_1:
					if (chart.Rotation >= 90 && (chart.Rotation < 225 || chart.Rotation >= 270))
					{
						flag2 = true;
					}
					else
					{
						flag = true;
					}
					break;
				case Enum84.const_3:
					if (chart.Rotation >= 90 && (chart.Rotation < 225 || chart.Rotation >= 270))
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
					break;
				}
				PointF pointF;
				PointF pointF2;
				if (!class823_0.IsPlotOrderReversed)
				{
					pointF = array[0];
					pointF2 = array[1];
				}
				else
				{
					pointF = array[1];
					pointF2 = array[0];
				}
				float num3 = (pointF2.X - pointF.X) / (float)num2;
				float num4 = (pointF2.Y - pointF.Y) / (float)num2;
				float num5 = pointF.X;
				for (float num6 = pointF.Y; (pointF.Y <= num6 && num6 <= pointF2.Y) || (pointF.Y >= num6 && num6 >= pointF2.Y) || Math.Round(num6) == Math.Round(pointF.Y) || Math.Round(num6) == Math.Round(pointF2.Y); num6 += num4 * (float)smethod_29(baseUnitScale, smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, (int)class823_0.MinValue, class823_0.Chart.vmethod_0()), (int)class823_0.MinValue, class823_0.Chart.vmethod_0()))
				{
					if (flag)
					{
						class823_0.method_5().method_7(num5, num6, num5 + (float)class823_0.method_19(), num6);
					}
					if (flag2)
					{
						class823_0.method_5().method_7(num5 - (float)class823_0.method_19(), num6, num5, num6);
					}
					num5 += num3 * (float)smethod_29(baseUnitScale, smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, (int)class823_0.MinValue, class823_0.Chart.vmethod_0()), (int)class823_0.MinValue, class823_0.Chart.vmethod_0());
				}
				bool flag3 = false;
				bool flag4 = false;
				switch (class823_0.MinorTickMark)
				{
				case Enum84.const_0:
					flag3 = true;
					flag4 = true;
					break;
				case Enum84.const_1:
					if (chart.Rotation >= 90 && (chart.Rotation < 225 || chart.Rotation >= 270))
					{
						flag4 = true;
					}
					else
					{
						flag3 = true;
					}
					break;
				case Enum84.const_3:
					if (chart.Rotation >= 90 && (chart.Rotation < 225 || chart.Rotation >= 270))
					{
						flag3 = true;
					}
					else
					{
						flag4 = true;
					}
					break;
				}
				num5 = pointF.X;
				bool bool_;
				for (float num6 = pointF.Y; (pointF.Y <= num6 && num6 <= pointF2.Y) || (pointF.Y >= num6 && num6 >= pointF2.Y) || Math.Round(num6) == Math.Round(pointF.Y) || Math.Round(num6) == Math.Round(pointF2.Y); num6 += num4 * (float)smethod_29(baseUnitScale, smethod_31(class823_0.BaseUnitScale, class823_0.MinorUnitScale, (int)class823_0.MinorUnit, (int)class823_0.MinValue, bool_), (int)class823_0.MinValue, bool_))
				{
					if (flag3)
					{
						class823_0.method_5().method_7(num5, num6, num5 + (float)class823_0.method_21(), num6);
					}
					if (flag4)
					{
						class823_0.method_5().method_7(num5 - (float)class823_0.method_21(), num6, num5, num6);
					}
					bool_ = class823_0.Chart.vmethod_0();
					num5 += num3 * (float)smethod_29(baseUnitScale, smethod_31(class823_0.BaseUnitScale, class823_0.MinorUnitScale, (int)class823_0.MinorUnit, (int)class823_0.MinValue, bool_), (int)class823_0.MinValue, bool_);
				}
			}
			else
			{
				bool flag5 = false;
				bool flag6 = false;
				switch (class823_0.MajorTickMark)
				{
				case Enum84.const_0:
					flag5 = true;
					flag6 = true;
					break;
				case Enum84.const_1:
					if (chart.Elevation >= 0)
					{
						flag5 = true;
					}
					else
					{
						flag6 = true;
					}
					break;
				case Enum84.const_3:
					if (chart.Elevation >= 0)
					{
						flag6 = true;
					}
					else
					{
						flag5 = true;
					}
					break;
				}
				PointF pointF;
				PointF pointF2;
				if (!class823_0.IsPlotOrderReversed)
				{
					pointF = array[0];
					pointF2 = array[1];
				}
				else
				{
					pointF = array[1];
					pointF2 = array[0];
				}
				float num3 = (pointF2.X - pointF.X) / (float)num2;
				float num4 = (pointF2.Y - pointF.Y) / (float)num2;
				float num7 = pointF.X;
				float num8 = pointF.Y;
				while ((pointF.X <= num7 && num7 <= pointF2.X) || (pointF.X >= num7 && num7 >= pointF2.X) || Math.Round(num7) == Math.Round(pointF.X) || Math.Round(num7) == Math.Round(pointF2.X))
				{
					if (flag5)
					{
						class823_0.method_5().method_7(num7, num8 - (float)class823_0.method_19(), num7, num8);
					}
					if (flag6)
					{
						class823_0.method_5().method_7(num7, num8, num7, num8 + (float)class823_0.method_19());
					}
					num7 += num3 * (float)smethod_29(baseUnitScale, smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, (int)class823_0.MinValue, class823_0.Chart.vmethod_0()), (int)class823_0.MinValue, class823_0.Chart.vmethod_0());
					num8 += num4 * (float)smethod_29(baseUnitScale, smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, (int)class823_0.MinValue, class823_0.Chart.vmethod_0()), (int)class823_0.MinValue, class823_0.Chart.vmethod_0());
				}
				bool flag7 = false;
				bool flag8 = false;
				switch (class823_0.MinorTickMark)
				{
				case Enum84.const_0:
					flag7 = true;
					flag8 = true;
					break;
				case Enum84.const_1:
					if (chart.Elevation >= 0)
					{
						flag7 = true;
					}
					else
					{
						flag8 = true;
					}
					break;
				case Enum84.const_3:
					if (chart.Elevation >= 0)
					{
						flag8 = true;
					}
					else
					{
						flag7 = true;
					}
					break;
				}
				num7 = pointF.X;
				num8 = pointF.Y;
				while ((pointF.X <= num7 && num7 <= pointF2.X) || (pointF.X >= num7 && num7 >= pointF2.X) || Math.Round(num7) == Math.Round(pointF.X) || Math.Round(num7) == Math.Round(pointF2.X))
				{
					if (flag7)
					{
						class823_0.method_5().method_7(num7, num8 - (float)class823_0.method_21(), num7, num8);
					}
					if (flag8)
					{
						class823_0.method_5().method_7(num7, num8, num7, num8 + (float)class823_0.method_21());
					}
					num7 += num3 * (float)smethod_29(baseUnitScale, smethod_31(class823_0.BaseUnitScale, class823_0.MinorUnitScale, (int)class823_0.MinorUnit, (int)class823_0.MinValue, class823_0.Chart.vmethod_0()), (int)class823_0.MinValue, class823_0.Chart.vmethod_0());
					num8 += num4 * (float)smethod_29(baseUnitScale, smethod_31(class823_0.BaseUnitScale, class823_0.MinorUnitScale, (int)class823_0.MinorUnit, (int)class823_0.MinValue, class823_0.Chart.vmethod_0()), (int)class823_0.MinValue, class823_0.Chart.vmethod_0());
				}
			}
			if (int_0 > 0)
			{
				array[0].Y -= int_0;
				array[1].Y -= int_0;
				int_0 = 0;
				continue;
			}
			break;
		}
	}

	internal static void smethod_49(Interface42 interface42_0, Class823 class823_0)
	{
		if (class823_0.Chart.method_8().method_16())
		{
			return;
		}
		Class821 chart = class823_0.Chart;
		ChartType_Chart type = chart.Type;
		chart.method_13();
		PointF[] array = Struct48.smethod_2(chart);
		class823_0.method_5().method_8(array[0], array[1]);
		Class847 @class = class823_0.method_10();
		Class844 class2 = chart.method_7().method_9(0);
		Class831 class3 = class2.method_9().method_1(0);
		string string_ = class3.vmethod_6();
		bool bool_ = class3.vmethod_7();
		bool flag = false;
		if (@class.LinkedSource && class3 != null)
		{
			flag = true;
		}
		float num = 0f;
		num = array[0].Y + (float)class823_0.method_19();
		_ = (double)chart.method_13().Width / (class823_0.MaxValue - class823_0.MinValue);
		ArrayList arrayList_ = class823_0.arrayList_1;
		double num2 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MaxValue) : class823_0.MaxValue);
		double num3 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MinValue) : class823_0.MinValue);
		double num4 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MajorUnit) : class823_0.MajorUnit);
		for (int i = 0; i < class823_0.arrayList_1.Count; i++)
		{
			double num5 = (double)class823_0.arrayList_1[i];
			double num6 = (class823_0.IsLogarithmic ? class823_0.method_7(num5) : num5);
			if (i - 1 > 0)
			{
				if (Math.Abs(Struct63.smethod_9(num5, Convert.ToDouble(arrayList_[i - 1]))) != num4)
				{
					continue;
				}
			}
			else if (i + 1 < arrayList_.Count && Math.Abs(Struct63.smethod_9(num5, Convert.ToDouble(arrayList_[i + 1]))) != num4)
			{
				continue;
			}
			float num7 = (float)((num5 - num3) / (num2 - num3) * (double)chart.method_13().Width);
			num7 = (class823_0.IsPlotOrderReversed ? (array[1].X - num7) : (array[0].X + num7));
			if (class823_0.TickLabelPosition != Enum83.const_3)
			{
				if (Struct47.smethod_56(type))
				{
					num6 /= 100.0;
					string_ = "0%";
				}
				string text = "";
				num6 = (class823_0.IsLogarithmic ? num6 : (num6 * Math.Pow(10.0, (double)class823_0.method_12().vmethod_0())));
				Color fontColor = @class.FontColor;
				if (flag)
				{
					text = Struct51.smethod_5(chart.vmethod_2(), num6, string_, bool_);
					fontColor = Struct51.smethod_6(num6, string_, fontColor);
				}
				else
				{
					text = smethod_28(class823_0, num6);
					fontColor = Struct51.smethod_6(num6, @class.imethod_0(), fontColor);
				}
				RectangleF value = new RectangleF(num7 - class823_0.float_0 / 2f, num, class823_0.float_0, class823_0.float_1);
				smethod_37(interface42_0, Rectangle.Round(value), text, @class.Rotation, @class.Font, fontColor, Enum82.const_1, Enum82.const_9);
			}
		}
		smethod_50(interface42_0, class823_0);
	}

	private static void smethod_50(Interface42 interface42_0, Class823 class823_0)
	{
		Class821 chart = class823_0.Chart;
		chart.method_13();
		if ((class823_0.MajorTickMark == Enum84.const_2 && class823_0.MinorTickMark == Enum84.const_2) || !class823_0.method_5().IsVisible)
		{
			return;
		}
		PointF[] array = Struct48.smethod_2(chart);
		bool flag = false;
		bool flag2 = false;
		switch (class823_0.MajorTickMark)
		{
		case Enum84.const_0:
			flag = true;
			flag2 = true;
			break;
		case Enum84.const_1:
			flag = true;
			break;
		case Enum84.const_3:
			flag2 = true;
			break;
		}
		PointF pointF;
		PointF pointF2;
		if (!class823_0.IsPlotOrderReversed)
		{
			pointF = array[0];
			pointF2 = array[1];
		}
		else
		{
			pointF = array[1];
			pointF2 = array[0];
		}
		float num = (float)((double)(pointF2.X - pointF.X) / (class823_0.MaxValue - class823_0.MinValue));
		float num2 = pointF.X;
		float y = pointF.Y;
		for (; (pointF.X <= num2 && num2 <= pointF2.X) || (pointF.X >= num2 && num2 >= pointF2.X) || Math.Round(num2) == Math.Round(pointF.X) || Math.Round(num2) == Math.Round(pointF2.X); num2 += num * (float)class823_0.MajorUnit)
		{
			if (flag)
			{
				class823_0.method_5().method_7(num2, y - (float)class823_0.method_19(), num2, y);
			}
			if (flag2)
			{
				class823_0.method_5().method_7(num2, y, num2, y + (float)class823_0.method_19());
			}
		}
		flag = false;
		flag2 = false;
		switch (class823_0.MinorTickMark)
		{
		case Enum84.const_0:
			flag = true;
			flag2 = true;
			break;
		case Enum84.const_1:
			flag = true;
			break;
		case Enum84.const_3:
			flag2 = true;
			break;
		}
		num2 = pointF.X;
		y = pointF.Y;
		for (; (pointF.X <= num2 && num2 <= pointF2.X) || (pointF.X >= num2 && num2 >= pointF2.X) || Math.Round(num2) == Math.Round(pointF.X) || Math.Round(num2) == Math.Round(pointF2.X); num2 += num * (float)class823_0.MinorUnit)
		{
			if (flag)
			{
				class823_0.method_5().method_7(num2, y - (float)class823_0.method_21(), num2, y);
			}
			if (flag2)
			{
				class823_0.method_5().method_7(num2, y, num2, y + (float)class823_0.method_21());
			}
		}
	}

	internal static void smethod_51(Interface42 interface42_0, Class823 class823_0, int int_0, Rectangle rectangle_0)
	{
		if (class823_0.Chart.method_8().method_16())
		{
			return;
		}
		if (class823_0.CategoryType == Enum64.const_2)
		{
			smethod_52(interface42_0, class823_0);
			return;
		}
		Class821 chart = class823_0.Chart;
		chart.method_13();
		PointF[] array = Struct48.smethod_2(chart);
		Struct48.smethod_4(chart);
		double num = ((!chart.method_9().IsPlotOrderReversed) ? (chart.method_9().CrossAt - chart.method_9().MinValue) : (chart.method_9().MaxValue - chart.method_9().CrossAt));
		int num2 = (int)(num / (chart.method_9().MaxValue - chart.method_9().MinValue) * (double)chart.method_13().Width);
		if (num2 != 0)
		{
			class823_0.method_5().method_7(array[0].X + (float)num2, array[0].Y, array[0].X + (float)num2, array[0].Y - chart.method_13().Height);
		}
		if (chart.Elevation >= 0)
		{
			class823_0.method_5().method_7(array[0].X, array[0].Y, array[0].X, array[0].Y - chart.method_13().Height);
		}
		if (class823_0.TickLabelPosition == Enum83.const_2)
		{
			array[0].X += num2;
		}
		float num3 = 0f;
		float num4 = class823_0.method_10().method_1();
		if (class823_0.TickLabelPosition != Enum83.const_3)
		{
			num4 += (float)(class823_0.method_19() + class823_0.method_21());
		}
		Enum82 enum82_ = Enum82.const_8;
		num3 = array[0].X - class823_0.float_3 - num4;
		float num5 = chart.method_13().Height / (float)int_0;
		Class847 @class = class823_0.method_10();
		ArrayList arrayList = class823_0.Chart.method_7().method_0();
		bool flag = false;
		if (@class.LinkedSource && arrayList.Count > 0)
		{
			flag = true;
		}
		for (int i = 0; i < int_0; i++)
		{
			double num6 = (float)i * num5;
			num6 += (double)(num5 / 2f);
			float y = ((!class823_0.IsPlotOrderReversed) ? ((float)((double)array[0].Y - num6) - class823_0.float_2 / 2f) : ((float)((double)(array[0].Y - chart.method_13().Height) + num6) - class823_0.float_2 / 2f));
			if (class823_0.TickLabelPosition != Enum83.const_3 && i % class823_0.TickLabelSpacing == 0 && i < class823_0.arrayList_1.Count)
			{
				string text = "";
				Color fontColor = @class.FontColor;
				if (!flag)
				{
					text = smethod_28(class823_0, class823_0.arrayList_1[i]);
					fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], @class.imethod_0(), fontColor);
				}
				else
				{
					string text2 = "";
					bool flag2 = false;
					text2 = ((i < arrayList.Count) ? ((Class825)arrayList[i]).imethod_3() : "");
					flag2 = i < arrayList.Count && ((Class825)arrayList[i]).imethod_1();
					text = Struct51.smethod_5(chart.vmethod_2(), class823_0.arrayList_1[i], text2, flag2);
					fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], text2, fontColor);
				}
				RectangleF value = new RectangleF(num3, y, class823_0.float_3, class823_0.float_2);
				smethod_37(interface42_0, Rectangle.Round(value), text, @class.Rotation, @class.Font, fontColor, enum82_, Enum82.const_1);
			}
		}
		smethod_53(interface42_0, class823_0, num2, int_0);
		_ = chart.method_9().IsPlotOrderReversed;
		ArrayList[] array2 = chart.method_7().method_4();
		if (array2 != null && array2.Length > 0 && arrayList.Count > 0 && class823_0.TickLabelPosition != Enum83.const_3)
		{
			IList list = array2[0];
			Class825 class2 = (Class825)list[0];
			string string_ = Struct51.smethod_5(chart.vmethod_2(), class2.imethod_0(), class2.imethod_3(), class2.imethod_1());
			Struct61.smethod_3(class823_0.Chart.imethod_0(), string_, 0, @class.Font, new SizeF(rectangle_0.Width, rectangle_0.Height), Enum82.const_1, Enum82.const_1);
			float num7 = 0f;
			num7 = (class823_0.IsPlotOrderReversed ? (array[0].Y - chart.method_13().Height) : array[0].Y);
			num3 = array[0].X - num4 * (float)(array2.Length + 1) - class823_0.float_0;
			float x = array[0].X;
			smethod_12(interface42_0, array2, bool_0: true, class823_0, @class, num5, rectangle_0, num4, x, num3, num7);
		}
	}

	private static void smethod_52(Interface42 interface42_0, Class823 class823_0)
	{
		Class821 chart = class823_0.Chart;
		Class851 @class = chart.method_13();
		PointF[] array = Struct48.smethod_2(chart);
		Struct48.smethod_4(chart);
		double num = ((!chart.method_9().IsPlotOrderReversed) ? (chart.method_9().CrossAt - chart.method_9().MinValue) : (chart.method_9().MaxValue - chart.method_9().CrossAt));
		int num2 = (int)(num / (chart.method_9().MaxValue - chart.method_9().MinValue) * (double)chart.method_13().Width);
		if (num2 != 0)
		{
			class823_0.method_5().method_7(array[0].X + (float)num2, array[0].Y, array[0].X + (float)num2, array[0].Y - chart.method_13().Height);
		}
		if (chart.Elevation >= 0)
		{
			class823_0.method_5().method_7(array[0].X, array[0].Y, array[0].X, array[0].Y - chart.method_13().Height);
		}
		if (class823_0.TickLabelPosition == Enum83.const_2)
		{
			array[0].X += num2;
		}
		ArrayList arrayList_ = class823_0.arrayList_1;
		float num3 = 0f;
		float num4 = class823_0.method_10().method_1();
		float num5 = class823_0.float_1 / 2f;
		Enum82 enum82_ = Enum82.const_8;
		num3 = array[0].X - class823_0.float_0 - num4;
		Class847 class2 = class823_0.method_10();
		ArrayList arrayList = class823_0.Chart.method_7().method_0();
		bool flag = false;
		if (class2.LinkedSource && arrayList.Count > 0)
		{
			flag = true;
		}
		int int_ = (int)class823_0.MaxValue;
		int int_2 = (int)class823_0.MinValue;
		Enum87 baseUnitScale = class823_0.BaseUnitScale;
		int num6 = smethod_29(baseUnitScale, int_, int_2, class823_0.Chart.vmethod_0()) + 1;
		float num7 = @class.Height / (float)num6;
		for (int i = 0; i < arrayList_.Count; i++)
		{
			int int_3 = Convert.ToInt32(class823_0.arrayList_1[i]);
			int num8 = smethod_29(baseUnitScale, int_3, int_2, class823_0.Chart.vmethod_0());
			float num9 = num7 * (float)num8;
			num9 += num7 / 2f;
			float num10 = ((!class823_0.IsPlotOrderReversed) ? (array[0].Y - num9) : (array[0].Y - chart.method_13().Height + num9));
			if (class823_0.TickLabelPosition != Enum83.const_3 && i % class823_0.TickLabelSpacing == 0 && i < class823_0.arrayList_1.Count)
			{
				string text = "";
				Color fontColor = class2.FontColor;
				if (!flag)
				{
					text = smethod_28(class823_0, class823_0.arrayList_1[i]);
					fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], class2.imethod_0(), fontColor);
				}
				else
				{
					string text2 = "";
					bool flag2 = false;
					text2 = ((i < arrayList.Count) ? ((Class825)arrayList[i]).imethod_3() : "");
					flag2 = i < arrayList.Count && ((Class825)arrayList[i]).imethod_1();
					text = Struct51.smethod_5(chart.vmethod_2(), class823_0.arrayList_1[i], text2, flag2);
					fontColor = Struct51.smethod_6(class823_0.arrayList_1[i], text2, fontColor);
				}
				RectangleF value = new RectangleF(num3, num10 - num5, class823_0.float_0, class823_0.float_1);
				smethod_37(interface42_0, Rectangle.Round(value), text, class2.Rotation, class2.Font, fontColor, enum82_, Enum82.const_1);
			}
		}
		smethod_54(interface42_0, num2, class823_0);
	}

	private static void smethod_53(Interface42 interface42_0, Class823 class823_0, int int_0, int int_1)
	{
		Class821 chart = class823_0.Chart;
		Class851 @class = chart.method_13();
		if ((class823_0.MajorTickMark == Enum84.const_2 && class823_0.MinorTickMark == Enum84.const_2) || !class823_0.method_5().IsVisible)
		{
			return;
		}
		PointF[] array = Struct48.smethod_2(chart);
		while (true)
		{
			bool flag = false;
			bool flag2 = false;
			switch (class823_0.MajorTickMark)
			{
			case Enum84.const_3:
				flag2 = true;
				break;
			case Enum84.const_1:
				flag = true;
				break;
			case Enum84.const_0:
				flag = true;
				flag2 = true;
				break;
			}
			bool flag3 = false;
			bool flag4 = false;
			switch (class823_0.MinorTickMark)
			{
			case Enum84.const_0:
				flag3 = true;
				flag4 = true;
				break;
			case Enum84.const_1:
				flag3 = true;
				break;
			case Enum84.const_3:
				flag4 = true;
				break;
			}
			PointF pointF;
			PointF pointF2;
			if (class823_0.IsPlotOrderReversed)
			{
				pointF = new PointF(array[0].X, array[0].Y - @class.Height);
				pointF2 = new PointF(array[0].X, array[0].Y);
			}
			else
			{
				pointF = new PointF(array[0].X, array[0].Y);
				pointF2 = new PointF(array[0].X, array[0].Y - @class.Height);
			}
			float num = (pointF2.Y - pointF.Y) / (float)int_1;
			float x = pointF.X;
			float num2;
			for (num2 = pointF.Y; (pointF.Y <= num2 && num2 <= pointF2.Y) || (pointF.Y >= num2 && num2 >= pointF2.Y) || Math.Round(num2) == Math.Round(pointF.Y) || Math.Round(num2) == Math.Round(pointF2.Y); num2 += (float)class823_0.TickMarkSpacing * num)
			{
				if ((pointF.Y <= num2 && num2 <= pointF2.Y) || (pointF.Y >= num2 && num2 >= pointF2.Y) || Math.Round(num2) == Math.Round(pointF.Y) || Math.Round(num2) == Math.Round(pointF2.Y))
				{
					if (flag)
					{
						class823_0.method_5().method_7(x, num2, x + (float)class823_0.method_19(), num2);
					}
					if (flag2)
					{
						class823_0.method_5().method_7(x - (float)class823_0.method_19(), num2, x, num2);
					}
				}
				float num3 = num2 - (float)class823_0.TickMarkSpacing * num / 2f;
				if ((pointF.Y <= num3 && num3 <= pointF2.Y) || (pointF.Y >= num3 && num3 >= pointF2.Y) || Math.Round(num3) == Math.Round(pointF.Y) || Math.Round(num3) == Math.Round(pointF2.Y))
				{
					if (flag3)
					{
						class823_0.method_5().method_7(x, num3, x + (float)class823_0.method_19(), num3);
					}
					if (flag4)
					{
						class823_0.method_5().method_7(x - (float)class823_0.method_19(), num3, x, num3);
					}
				}
			}
			if ((float)class823_0.TickMarkSpacing * num > pointF2.Y - pointF.Y)
			{
				float num4 = num2 - (float)class823_0.TickMarkSpacing * num / 2f;
				if ((pointF.Y <= num4 && num4 <= pointF2.Y) || (pointF.Y >= num4 && num4 >= pointF2.Y) || Math.Round(num4) == Math.Round(pointF.Y) || Math.Round(num4) == Math.Round(pointF2.Y))
				{
					if (flag3)
					{
						class823_0.method_5().method_7(x, num4, x + (float)class823_0.method_19(), num4);
					}
					if (flag4)
					{
						class823_0.method_5().method_7(x - (float)class823_0.method_19(), num4, x, num4);
					}
				}
			}
			if (int_0 > 0)
			{
				array[0].X += int_0;
				int_0 = 0;
				continue;
			}
			break;
		}
	}

	private static void smethod_54(Interface42 interface42_0, int int_0, Class823 class823_0)
	{
		Class821 chart = class823_0.Chart;
		Class851 @class = chart.method_13();
		if ((class823_0.MajorTickMark == Enum84.const_2 && class823_0.MinorTickMark == Enum84.const_2) || !class823_0.method_5().IsVisible)
		{
			return;
		}
		PointF[] array = Struct48.smethod_2(chart);
		while (true)
		{
			bool flag = false;
			bool flag2 = false;
			switch (class823_0.MajorTickMark)
			{
			case Enum84.const_3:
				flag2 = true;
				break;
			case Enum84.const_1:
				flag = true;
				break;
			case Enum84.const_0:
				flag = true;
				flag2 = true;
				break;
			}
			PointF pointF;
			PointF pointF2;
			if (class823_0.IsPlotOrderReversed)
			{
				pointF = new PointF(array[0].X, array[0].Y - @class.Height);
				pointF2 = new PointF(array[0].X, array[0].Y);
			}
			else
			{
				pointF = new PointF(array[0].X, array[0].Y);
				pointF2 = new PointF(array[0].X, array[0].Y - @class.Height);
			}
			Enum87 baseUnitScale = class823_0.BaseUnitScale;
			double num = ((class823_0.method_4() != 0 || class823_0.CategoryType != Enum64.const_2) ? (class823_0.MaxValue - class823_0.MinValue) : ((double)(smethod_29(baseUnitScale, (int)class823_0.MaxValue, (int)class823_0.MinValue, class823_0.Chart.vmethod_0()) + 1)));
			float num2 = (float)((double)(pointF2.Y - pointF.Y) / num);
			float x = pointF.X;
			for (float num3 = pointF.Y; (pointF.Y <= num3 && num3 <= pointF2.Y) || (pointF.Y >= num3 && num3 >= pointF2.Y) || Math.Round(num3) == Math.Round(pointF.Y) || Math.Round(num3) == Math.Round(pointF2.Y); num3 += num2 * (float)smethod_29(baseUnitScale, smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, (int)class823_0.MinValue, class823_0.Chart.vmethod_0()), (int)class823_0.MinValue, class823_0.Chart.vmethod_0()))
			{
				if (flag)
				{
					class823_0.method_5().method_7(x, num3, x + (float)class823_0.method_19(), num3);
				}
				if (flag2)
				{
					class823_0.method_5().method_7(x - (float)class823_0.method_19(), num3, x, num3);
				}
			}
			bool flag3 = false;
			bool flag4 = false;
			switch (class823_0.MinorTickMark)
			{
			case Enum84.const_0:
				flag3 = true;
				flag4 = true;
				break;
			case Enum84.const_1:
				flag3 = true;
				break;
			case Enum84.const_3:
				flag4 = true;
				break;
			}
			x = pointF.X;
			for (float num3 = pointF.Y; (pointF.Y <= num3 && num3 <= pointF2.Y) || (pointF.Y >= num3 && num3 >= pointF2.Y) || Math.Round(num3) == Math.Round(pointF.Y) || Math.Round(num3) == Math.Round(pointF2.Y); num3 += num2 * (float)smethod_29(baseUnitScale, smethod_31(class823_0.BaseUnitScale, class823_0.MinorUnitScale, (int)class823_0.MinorUnit, (int)class823_0.MinValue, class823_0.Chart.vmethod_0()), (int)class823_0.MinValue, class823_0.Chart.vmethod_0()))
			{
				if (flag3)
				{
					class823_0.method_5().method_7(x, num3, x + (float)class823_0.method_21(), num3);
				}
				if (flag4)
				{
					class823_0.method_5().method_7(x - (float)class823_0.method_21(), num3, x, num3);
				}
			}
			if (int_0 > 0)
			{
				array[0].X += int_0;
				int_0 = 0;
				continue;
			}
			break;
		}
	}

	internal static void smethod_55(Interface42 interface42_0, Class823 class823_0)
	{
		if (class823_0.Chart.method_8().method_16())
		{
			return;
		}
		Class821 chart = class823_0.Chart;
		chart.method_13();
		PointF[] array = Struct48.smethod_3(chart);
		Class823 @class = chart.method_9();
		double num = @class.method_13();
		double num2 = @class.method_14();
		double num3 = @class.method_15();
		bool flag = false;
		if (@class.MinValue == @class.CrossAt)
		{
			flag = true;
		}
		num3 = ((!@class.IsPlotOrderReversed) ? (num3 - num2) : (num - num3));
		int num4 = (int)(num3 / (num - num2) * (double)chart.method_13().Height);
		if (num4 != 0)
		{
			class823_0.method_5().method_7(array[0].X, array[0].Y - (float)num4, array[1].X, array[1].Y - (float)num4);
		}
		if (chart.Elevation >= 0)
		{
			class823_0.method_5().method_7(array[0].X, array[0].Y, array[1].X, array[1].Y);
		}
		if (class823_0.TickLabelPosition == Enum83.const_2)
		{
			array[0].Y -= num4;
			array[1].Y -= num4;
		}
		chart.method_7();
		Class847 class2 = class823_0.method_10();
		chart.method_7().method_0();
		float num5 = class823_0.method_10().method_1();
		double num6 = ((array[1].X == array[0].X) ? (Math.PI / 2.0) : Math.Atan(Math.Abs((array[0].Y - array[1].Y) / (array[1].X - array[0].X))));
		float num7 = (array[1].X - array[0].X) / (float)class823_0.arrayList_1.Count;
		float num8 = (array[1].Y - array[0].Y) / (float)class823_0.arrayList_1.Count;
		for (int i = 0; i < class823_0.arrayList_1.Count; i++)
		{
			int num9 = i;
			if (class823_0.IsPlotOrderReversed)
			{
				num9 = class823_0.arrayList_1.Count - 1 - i;
			}
			string text = "";
			text = smethod_28(class823_0, class823_0.arrayList_1[num9]);
			if (class823_0.TickLabelPosition == Enum83.const_3 || num9 % class823_0.TickLabelSpacing != 0)
			{
				continue;
			}
			RectangleF value = new RectangleF(0f, 0f, 0f, 0f);
			if (chart.Elevation >= 0)
			{
				if (array[0].Y == array[1].Y)
				{
					value.X = ((num7 < 0f) ? (array[0].X + (float)(i + 1) * num7) : (array[0].X + (float)i * num7));
					value.Y = array[0].Y + num5;
					value.Width = Math.Abs(num7);
					value.Height = class823_0.float_1;
				}
				else if (num6 <= Math.PI / 4.0)
				{
					value.X = ((num7 < 0f) ? (array[0].X + (float)(i + 1) * num7) : (array[0].X + (float)i * num7));
					value.Y = ((num8 > 0f) ? (array[0].Y + (float)(i + 1) * num8) : (array[0].Y + (float)i * num8));
					value.Width = Math.Abs(num7);
					value.Height = class823_0.float_1;
				}
				else
				{
					value.X = ((num8 > 0f) ? (array[0].X + (float)i * num7) : (array[0].X + (float)(i + 1) * num7));
					value.X = ((num7 * num8 <= 0f) ? (value.X + num5 * (float)Math.Sin(num6)) : (value.X - num5 * (float)Math.Sin(num6) - class823_0.float_0));
					value.Y = ((num8 > 0f) ? (array[0].Y + (float)i * num8) : (array[0].Y + (float)(i + 1) * num8));
					value.Y += (Math.Abs(num8) - class823_0.float_1) * (float)Math.Sin(num6) / 2f;
					value.Width = class823_0.float_0;
					value.Height = class823_0.float_1;
				}
			}
			else if (chart.Elevation < 0 && !flag && class823_0.TickLabelPosition == Enum83.const_2)
			{
				if (array[0].Y == array[1].Y)
				{
					value.X = ((num7 > 0f) ? (array[0].X + (float)i * num7) : (array[0].X + (float)(i + 1) * num7));
					value.Y = array[0].Y - class823_0.float_1 - num5;
					value.Width = Math.Abs(num7);
					value.Height = class823_0.float_1;
				}
				else if (num6 <= Math.PI / 4.0)
				{
					value.X = ((num7 < 0f) ? (array[0].X + (float)(i + 1) * num7) : (array[0].X + (float)i * num7));
					value.Y = ((num8 < 0f) ? (array[0].Y + (float)(i + 1) * num8) : (array[0].Y + (float)i * num8));
					value.Y -= class823_0.float_1;
					value.Width = Math.Abs(num7);
					value.Height = class823_0.float_1;
				}
				else
				{
					value.X = ((num8 < 0f) ? (array[0].X + (float)i * num7) : (array[0].X + (float)(i + 1) * num7));
					value.X = ((num7 * num8 >= 0f) ? (value.X + num5 * (float)Math.Sin(num6)) : (value.X - num5 * (float)Math.Sin(num6) - class823_0.float_0));
					value.Y = ((num8 < 0f) ? (array[0].Y + (float)i * num8) : (array[0].Y + (float)(i + 1) * num8));
					value.Y -= (Math.Abs(num8) - class823_0.float_1) * (float)Math.Sin(num6) / 2f;
					value.Y -= class823_0.float_1;
					value.Width = class823_0.float_0;
					value.Height = class823_0.float_1;
				}
			}
			value.Width = class823_0.float_0;
			value.Height = class823_0.float_1;
			smethod_37(interface42_0, Rectangle.Round(value), text, class2.Rotation, class2.Font, class2.FontColor, Enum82.const_1, Enum82.const_1);
		}
		smethod_47(interface42_0, class823_0, num4, class823_0.arrayList_1.Count);
	}
}
