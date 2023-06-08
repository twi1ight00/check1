using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using ns16;
using ns2;
using ns221;
using ns33;
using ns35;
using ns36;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct21
{
	internal static float smethod_0(float fontSize)
	{
		return fontSize * 0.4f;
	}

	internal static float smethod_1(float fontSize)
	{
		return fontSize * 0.28f;
	}

	internal static void smethod_2(Interface32 g, Rectangle plotAreaRect, bool axisIsDisplayAxisSameAsBar, Class759 firstSeries, Class783 axisRenderContext, Class784 renderContext)
	{
		if (axisRenderContext.Axis == null)
		{
			return;
		}
		Class740 chart = renderContext.Chart2007;
		if (Struct41.smethod_21(plotAreaRect) || (!axisRenderContext.Axis.ShowMajorGridLines && !axisRenderContext.Axis.ShowMinorGridLines))
		{
			return;
		}
		int num = 0;
		num = ((!axisIsDisplayAxisSameAsBar) ? ((axisRenderContext.AxisType == Enum160.const_0 || axisRenderContext.AxisType == Enum160.const_1) ? plotAreaRect.Width : plotAreaRect.Height) : ((axisRenderContext.AxisType == Enum160.const_0 || axisRenderContext.AxisType == Enum160.const_1) ? plotAreaRect.Height : plotAreaRect.Width));
		double num2 = 0.0;
		bool flag = axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2 && (axisRenderContext.AxisType == Enum160.const_0 || axisRenderContext.AxisType == Enum160.const_1);
		double num3 = axisRenderContext.LogMaxValue;
		double num4 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MajorUnit) : axisRenderContext.MajorUnit);
		double num6;
		if (!firstSeries.IsXValueSeries && (axisRenderContext.AxisType == Enum160.const_0 || axisRenderContext.AxisType == Enum160.const_1))
		{
			double num5 = (int)axisRenderContext.MaxValue;
			num6 = (int)axisRenderContext.MinValue;
			int num7;
			if (flag)
			{
				if (!renderContext.X1AxisRenderContext.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
				{
					num7 = smethod_35(axisRenderContext.Axis.BaseUnitScale, (int)num5, (int)num6, chart.IsDate1904);
					if (num7 == 0)
					{
						num7 = 1;
					}
				}
				else
				{
					num7 = smethod_35(axisRenderContext.Axis.BaseUnitScale, (int)num5, (int)num6, chart.IsDate1904) + 1;
					num3 = smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, 1, (int)num3, chart.IsDate1904);
				}
			}
			else if (!renderContext.X1AxisRenderContext.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
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
			double num5 = axisRenderContext.LogMaxValue;
			num6 = axisRenderContext.LogMinValue;
			num2 = (double)num / (num5 - num6);
		}
		if (axisRenderContext.Axis.ShowMajorGridLines && num4 > 0.0)
		{
			for (double num8 = num6; num8 <= num3; num8 = ((!flag) ? ((firstSeries.IsXValueSeries || (axisRenderContext.AxisType != 0 && axisRenderContext.AxisType != Enum160.const_1)) ? Struct41.smethod_12(num8, num4) : (num8 + num4 * (double)axisRenderContext.TickMarkSpacing)) : ((double)smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)num4, (int)num8, chart.IsDate1904))))
			{
				double num10;
				if (flag)
				{
					int num9 = smethod_35(axisRenderContext.Axis.BaseUnitScale, (int)num8, (int)num6, chart.IsDate1904);
					num10 = num2 * (double)num9;
				}
				else
				{
					num10 = num2 * (num8 - num6);
				}
				if (!chart.PlotAreaInternal.BorderInternal.method_14() || (num8 != num6 && num8 != num3))
				{
					if (axisIsDisplayAxisSameAsBar)
					{
						if (axisRenderContext.AxisType != 0 && axisRenderContext.AxisType != Enum160.const_1)
						{
							if (axisRenderContext.Axis.IsPlotOrderReversed)
							{
								axisRenderContext.method_4((float)((double)plotAreaRect.Right - num10), plotAreaRect.Y, (float)((double)plotAreaRect.Right - num10), plotAreaRect.Bottom);
							}
							else
							{
								axisRenderContext.method_4((float)((double)plotAreaRect.X + num10), plotAreaRect.Y, (float)((double)plotAreaRect.X + num10), plotAreaRect.Bottom);
							}
						}
						else if (axisRenderContext.Axis.IsPlotOrderReversed)
						{
							axisRenderContext.method_4(plotAreaRect.X, (float)((double)plotAreaRect.Y + num10), plotAreaRect.Right, (float)((double)plotAreaRect.Y + num10));
						}
						else
						{
							axisRenderContext.method_4(plotAreaRect.X, (float)((double)plotAreaRect.Bottom - num10), plotAreaRect.Right, (float)((double)plotAreaRect.Bottom - num10));
						}
					}
					else if (axisRenderContext.AxisType != 0 && axisRenderContext.AxisType != Enum160.const_1)
					{
						if (axisRenderContext.Axis.IsPlotOrderReversed)
						{
							axisRenderContext.method_4(plotAreaRect.X, (float)((double)plotAreaRect.Y + num10), plotAreaRect.Right, (float)((double)plotAreaRect.Y + num10));
						}
						else
						{
							axisRenderContext.method_4(plotAreaRect.X, (float)((double)plotAreaRect.Bottom - num10), plotAreaRect.Right, (float)((double)plotAreaRect.Bottom - num10));
						}
					}
					else if (axisRenderContext.Axis.IsPlotOrderReversed)
					{
						axisRenderContext.method_4((float)((double)plotAreaRect.Right - num10), plotAreaRect.Y, (float)((double)plotAreaRect.Right - num10), plotAreaRect.Bottom);
					}
					else
					{
						axisRenderContext.method_4((float)((double)plotAreaRect.X + num10), plotAreaRect.Y, (float)((double)plotAreaRect.X + num10), plotAreaRect.Bottom);
					}
				}
			}
		}
		if (!axisRenderContext.Axis.IsLogarithmic)
		{
			double minorUnit = axisRenderContext.MinorUnit;
			if (!axisRenderContext.Axis.ShowMinorGridLines || !(minorUnit > 0.0))
			{
				return;
			}
			int num11 = 0;
			if (flag)
			{
				int maxValue = smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)num4, (int)num6, chart.IsDate1904);
				num11 = smethod_35(axisRenderContext.Axis.BaseUnitScale, maxValue, (int)num6, chart.IsDate1904);
			}
			for (double num12 = num6; num12 <= num3; num12 = ((!flag) ? ((firstSeries.IsXValueSeries || (axisRenderContext.AxisType != 0 && axisRenderContext.AxisType != Enum160.const_1)) ? Struct41.smethod_12(num12, minorUnit) : (num12 + minorUnit * (double)axisRenderContext.TickMarkSpacing)) : ((double)smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MinorUnitScale, (int)minorUnit, (int)num12, chart.IsDate1904))))
			{
				bool flag2 = false;
				double num14;
				if (flag)
				{
					int num13 = smethod_35(axisRenderContext.Axis.BaseUnitScale, (int)num12, (int)num6, chart.IsDate1904);
					num14 = num2 * (double)num13;
					if (num13 % num11 == 0 && axisRenderContext.Axis.ShowMinorGridLines)
					{
						flag2 = true;
					}
				}
				else
				{
					num14 = num2 * (num12 - num6);
					if (Struct41.smethod_11(num12, num6) % num4 == 0.0 && axisRenderContext.Axis.ShowMinorGridLines)
					{
						flag2 = true;
					}
				}
				if ((!chart.PlotAreaInternal.BorderInternal.IsVisible || (num12 != num6 && num12 != num3)) && !flag2)
				{
					if (axisIsDisplayAxisSameAsBar)
					{
						if (axisRenderContext.AxisType != 0 && axisRenderContext.AxisType != Enum160.const_1)
						{
							if (axisRenderContext.Axis.IsPlotOrderReversed)
							{
								axisRenderContext.method_5((float)((double)plotAreaRect.Right - num14), plotAreaRect.Y, (float)((double)plotAreaRect.Right - num14), plotAreaRect.Bottom);
							}
							else
							{
								axisRenderContext.method_5((float)((double)plotAreaRect.X + num14), plotAreaRect.Y, (float)((double)plotAreaRect.X + num14), plotAreaRect.Bottom);
							}
						}
						else if (axisRenderContext.Axis.IsPlotOrderReversed)
						{
							axisRenderContext.method_5(plotAreaRect.X, (float)((double)plotAreaRect.Y + num14), plotAreaRect.Right, (float)((double)plotAreaRect.Y + num14));
						}
						else
						{
							axisRenderContext.method_5(plotAreaRect.X, (float)((double)plotAreaRect.Bottom - num14), plotAreaRect.Right, (float)((double)plotAreaRect.Bottom - num14));
						}
					}
					else if (axisRenderContext.AxisType != 0 && axisRenderContext.AxisType != Enum160.const_1)
					{
						if (axisRenderContext.Axis.IsPlotOrderReversed)
						{
							axisRenderContext.method_5(plotAreaRect.X, (float)((double)plotAreaRect.Y + num14), plotAreaRect.Right, (float)((double)plotAreaRect.Y + num14));
						}
						else
						{
							axisRenderContext.method_5(plotAreaRect.X, (float)((double)plotAreaRect.Bottom - num14), plotAreaRect.Right, (float)((double)plotAreaRect.Bottom - num14));
						}
					}
					else if (axisRenderContext.Axis.IsPlotOrderReversed)
					{
						axisRenderContext.method_5((float)((double)plotAreaRect.Right - num14), plotAreaRect.Y, (float)((double)plotAreaRect.Right - num14), plotAreaRect.Bottom);
					}
					else
					{
						axisRenderContext.method_5((float)((double)plotAreaRect.X + num14), plotAreaRect.Y, (float)((double)plotAreaRect.X + num14), plotAreaRect.Bottom);
					}
				}
			}
			return;
		}
		double minorUnit2 = axisRenderContext.MinorUnit;
		int num15 = Struct41.smethod_13(minorUnit2);
		double num16 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(minorUnit2) : minorUnit2);
		if (!axisRenderContext.Axis.ShowMinorGridLines || !(minorUnit2 > 0.0))
		{
			return;
		}
		for (double num17 = num6; num17 <= num3 + num16; num17 = Struct41.smethod_12(num17, num16))
		{
			for (int i = 1; i <= 10; i++)
			{
				double d = Math.Pow(i, num15) * Math.Pow(10.0, num17);
				d = axisRenderContext.method_0(d);
				if ((i == 1 && num17 != num6) || !(d <= num3))
				{
					continue;
				}
				double num18 = num2 * (d - num6);
				if (axisIsDisplayAxisSameAsBar)
				{
					if (axisRenderContext.AxisType != 0 && axisRenderContext.AxisType != Enum160.const_1)
					{
						if (axisRenderContext.Axis.IsPlotOrderReversed)
						{
							axisRenderContext.method_5((float)((double)plotAreaRect.Right - num18), plotAreaRect.Y, (float)((double)plotAreaRect.Right - num18), plotAreaRect.Bottom);
						}
						else
						{
							axisRenderContext.method_5((float)((double)plotAreaRect.X + num18), plotAreaRect.Y, (float)((double)plotAreaRect.X + num18), plotAreaRect.Bottom);
						}
					}
					else if (axisRenderContext.Axis.IsPlotOrderReversed)
					{
						axisRenderContext.method_5(plotAreaRect.X, (float)((double)plotAreaRect.Y + num18), plotAreaRect.Right, (float)((double)plotAreaRect.Y + num18));
					}
					else
					{
						axisRenderContext.method_5(plotAreaRect.X, (float)((double)plotAreaRect.Bottom - num18), plotAreaRect.Right, (float)((double)plotAreaRect.Bottom - num18));
					}
				}
				else if (axisRenderContext.AxisType != 0 && axisRenderContext.AxisType != Enum160.const_1)
				{
					if (axisRenderContext.Axis.IsPlotOrderReversed)
					{
						axisRenderContext.method_5(plotAreaRect.X, (float)((double)plotAreaRect.Y + num18), plotAreaRect.Right, (float)((double)plotAreaRect.Y + num18));
					}
					else
					{
						axisRenderContext.method_5(plotAreaRect.X, (float)((double)plotAreaRect.Bottom - num18), plotAreaRect.Right, (float)((double)plotAreaRect.Bottom - num18));
					}
				}
				else if (axisRenderContext.Axis.IsPlotOrderReversed)
				{
					axisRenderContext.method_5((float)((double)plotAreaRect.Right - num18), plotAreaRect.Y, (float)((double)plotAreaRect.Right - num18), plotAreaRect.Bottom);
				}
				else
				{
					axisRenderContext.method_5((float)((double)plotAreaRect.X + num18), plotAreaRect.Y, (float)((double)plotAreaRect.X + num18), plotAreaRect.Bottom);
				}
			}
		}
	}

	internal static void smethod_3(Class783 axisRenderContext, Interface32 g, Rectangle rect, int maxPointsCount, Class784 chartRenderContext)
	{
		if (Struct41.smethod_21(rect))
		{
			return;
		}
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		float num = smethod_0(axisRenderContext.TickLabelTextFont.Size);
		float num2 = smethod_1(axisRenderContext.TickLabelTextFont.Size);
		double num3 = Math.PI * 2.0 / (double)maxPointsCount;
		double num4 = (double)rect.X + (double)rect.Width / 2.0;
		double num5 = (double)rect.Y + (double)rect.Height / 2.0;
		double num6 = rect.Width / 2;
		if (chart.bool_8 && axisRenderContext == chartRenderContext.Y1AxisRenderContext)
		{
			double num7 = 0.0;
			double num8 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MaxValue) : axisRenderContext.MaxValue);
			double num9 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MinValue) : axisRenderContext.MinValue);
			double num10 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MajorUnit) : axisRenderContext.MajorUnit);
			double num11 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MinorUnit) : axisRenderContext.MinorUnit);
			if (num10 > 0.0)
			{
				for (double num12 = num9 + num10; num12 <= num8; num12 = Struct41.smethod_12(num12, num10))
				{
					num7 = Math.Abs(num12 - num9);
					double num13 = num6 * num7 / (num8 - num9);
					double num14 = Math.PI / 2.0;
					PointF pointF = PointF.Empty;
					for (int i = 0; i < maxPointsCount; i++)
					{
						if (axisRenderContext.Axis.ShowMajorGridLines)
						{
							double num15 = num4 + num13 * Math.Cos(num14);
							double num16 = num5 - num13 * Math.Sin(num14);
							PointF pointF2 = new PointF((float)num15, (float)num16);
							if (i == 0)
							{
								double num17 = num4 + num13 * Math.Cos(num14 + num3);
								double num18 = num5 - num13 * Math.Sin(num14 + num3);
								pointF = new PointF((float)num17, (float)num18);
							}
							if (Math.Abs(pointF2.X - pointF.X) > 1f || Math.Abs(pointF2.Y - pointF.Y) > 1f)
							{
								axisRenderContext.method_4((float)num15, (float)num16, pointF.X, pointF.Y);
								pointF = pointF2;
							}
						}
						else if (axisRenderContext.Axis != null && axisRenderContext.Axis.IsVisible && axisRenderContext.Axis.MajorTickMark != TickMarkType.None && !axisRenderContext.Axis.ShowMinorGridLines)
						{
							double num19 = Math.Atan((double)num / num13);
							double num20 = Math.Sqrt(Math.Pow(num13, 2.0) + Math.Pow(num, 2.0));
							double num21 = num4 + num20 * Math.Cos(num14 + num19);
							double num22 = num5 - num20 * Math.Sin(num14 + num19);
							double num23 = num4 + num20 * Math.Cos(num14 - num19);
							double num24 = num5 - num20 * Math.Sin(num14 - num19);
							axisRenderContext.method_3((float)num21, (float)num22, (float)num23, (float)num24);
						}
						num14 -= num3;
					}
				}
			}
			if (!(num11 > 0.0))
			{
				return;
			}
			for (double num25 = num9 + num11; num25 <= num8; num25 = Struct41.smethod_12(num25, num11))
			{
				num7 = Math.Abs(num25 - num9);
				double num26 = num6 * num7 / (num8 - num9);
				double num14 = Math.PI / 2.0;
				PointF pointF3 = PointF.Empty;
				for (int j = 0; j < maxPointsCount; j++)
				{
					if (axisRenderContext.Axis.ShowMinorGridLines)
					{
						double num27 = num4 + num26 * Math.Cos(num14);
						double num28 = num5 - num26 * Math.Sin(num14);
						PointF pointF4 = new PointF((float)num27, (float)num28);
						if (j == 0)
						{
							double num29 = num4 + num26 * Math.Cos(num14 + num3);
							double num30 = num5 - num26 * Math.Sin(num14 + num3);
							pointF3 = new PointF((float)num29, (float)num30);
						}
						if (Math.Abs(pointF4.X - pointF3.X) > 1f || Math.Abs(pointF4.Y - pointF3.Y) > 1f)
						{
							axisRenderContext.method_5(pointF4.X, pointF4.Y, pointF3.X, pointF3.Y);
							pointF3 = pointF4;
						}
					}
					else if (axisRenderContext.Axis.MinorTickMark != TickMarkType.None && axisRenderContext.Axis != null && axisRenderContext.Axis.IsVisible)
					{
						double num31 = Math.Atan((double)num2 / num26);
						double num32 = Math.Sqrt(Math.Pow(num26, 2.0) + Math.Pow(num2, 2.0));
						float x = (float)(num4 + num32 * Math.Cos(num14 + num31));
						float y = (float)(num5 - num32 * Math.Sin(num14 + num31));
						float x2 = (float)(num4 + num32 * Math.Cos(num14 - num31));
						float y2 = (float)(num5 - num32 * Math.Sin(num14 - num31));
						axisRenderContext.method_3(x, y, x2, y2);
					}
					num14 -= num3;
				}
			}
			return;
		}
		double num33 = 0.0;
		double logMaxValue = axisRenderContext.LogMaxValue;
		double logMinValue = axisRenderContext.LogMinValue;
		double num34 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MajorUnit) : axisRenderContext.MajorUnit);
		double num35 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MinorUnit) : axisRenderContext.MinorUnit);
		if (num34 > 0.0)
		{
			for (double num36 = logMinValue + num34; num36 <= logMaxValue; num36 = Struct41.smethod_12(num36, num34))
			{
				num33 = Math.Abs(num36 - logMinValue);
				double num37 = num6 * num33 / (logMaxValue - logMinValue);
				double num14 = Math.PI / 2.0;
				PointF pointF5 = PointF.Empty;
				for (int k = 0; k < maxPointsCount; k++)
				{
					if (axisRenderContext.Axis.ShowMajorGridLines)
					{
						double num38 = num4 + num37 * Math.Cos(num14);
						double num39 = num5 - num37 * Math.Sin(num14);
						PointF pointF6 = new PointF((float)num38, (float)num39);
						if (k == 0)
						{
							double num40 = num4 + num37 * Math.Cos(num14 + num3);
							double num41 = num5 - num37 * Math.Sin(num14 + num3);
							pointF5 = new PointF((float)num40, (float)num41);
						}
						if (Math.Abs(pointF6.X - pointF5.X) > 1f || Math.Abs(pointF6.Y - pointF5.Y) > 1f)
						{
							axisRenderContext.method_3(pointF6.X, pointF6.Y, pointF5.X, pointF5.Y);
							pointF5 = pointF6;
						}
					}
					else if (axisRenderContext.Axis != null && axisRenderContext.Axis.MajorTickMark != TickMarkType.None && !axisRenderContext.Axis.ShowMinorGridLines && axisRenderContext.Axis.IsVisible)
					{
						double num42 = Math.Atan((double)num / num37);
						double num43 = Math.Sqrt(Math.Pow(num37, 2.0) + Math.Pow(num, 2.0));
						float x3 = (float)(num4 + num43 * Math.Cos(num14 + num42));
						float y3 = (float)(num5 - num43 * Math.Sin(num14 + num42));
						float x4 = (float)(num4 + num43 * Math.Cos(num14 - num42));
						float y4 = (float)(num5 - num43 * Math.Sin(num14 - num42));
						axisRenderContext.method_3(x3, y3, x4, y4);
					}
					num14 -= num3;
				}
			}
		}
		if (!(num35 > 0.0))
		{
			return;
		}
		for (double num44 = logMinValue + num35; num44 <= logMaxValue; num44 = Struct41.smethod_12(num44, num35))
		{
			num33 = Math.Abs(num44 - logMinValue);
			double num45 = num6 * num33 / (logMaxValue - logMinValue);
			double num14 = Math.PI / 2.0;
			PointF pointF7 = PointF.Empty;
			for (int l = 0; l < maxPointsCount; l++)
			{
				if (axisRenderContext.Axis.ShowMinorGridLines)
				{
					double num46 = num4 + num45 * Math.Cos(num14);
					double num47 = num5 - num45 * Math.Sin(num14);
					PointF pointF8 = new PointF((float)num46, (float)num47);
					if (l == 0)
					{
						double num48 = num4 + num45 * Math.Cos(num14 + num3);
						double num49 = num5 - num45 * Math.Sin(num14 + num3);
						pointF7 = new PointF((float)num48, (float)num49);
					}
					if (Math.Abs(pointF8.X - pointF7.X) > 1f || Math.Abs(pointF8.Y - pointF7.Y) > 1f)
					{
						axisRenderContext.method_5(pointF8.X, pointF8.Y, pointF7.X, pointF7.Y);
						pointF7 = pointF8;
					}
				}
				else if (axisRenderContext.Axis != null && axisRenderContext.Axis.MinorTickMark != TickMarkType.None && axisRenderContext.Axis.IsVisible)
				{
					double num50 = Math.Atan((double)num2 / num45);
					double num51 = Math.Sqrt(Math.Pow(num45, 2.0) + Math.Pow(num2, 2.0));
					float x5 = (float)(num4 + num51 * Math.Cos(num14 + num50));
					float y5 = (float)(num5 - num51 * Math.Sin(num14 + num50));
					float x6 = (float)(num4 + num51 * Math.Cos(num14 - num50));
					float y6 = (float)(num5 - num51 * Math.Sin(num14 - num50));
					axisRenderContext.method_3(x5, y5, x6, y6);
				}
				num14 -= num3;
			}
		}
	}

	internal static void smethod_4(Interface32 g, bool reversed, float left, Rectangle plotAreaRect, Class759 firstSeries, Class783 axisRenderContext, Class784 renderContext)
	{
		if (Struct41.smethod_21(plotAreaRect))
		{
			return;
		}
		ChartType resembleType = firstSeries.ResembleType;
		Class748 @class = firstSeries.PointsInternal.method_0(0);
		string format = @class.YFormat;
		bool yValueIsCulture = @class.YValueIsCulture;
		axisRenderContext.method_3(left, plotAreaRect.Y, left, plotAreaRect.Bottom);
		Class751 displayUnitInternal = axisRenderContext.DisplayUnitInternal;
		Enum157 horizontalAlignment = Enum157.const_8;
		float num = 0f;
		float num2 = 2f * smethod_0(axisRenderContext.TickLabelTextFont.Size);
		float num3 = axisRenderContext.float_2 / 2f;
		if (axisRenderContext.int_5 == 1)
		{
			num = (float)plotAreaRect.X - axisRenderContext.float_1;
			displayUnitInternal.ChartFrameInternal.rectangle_1.X = (int)num - displayUnitInternal.ChartFrameInternal.rectangle_1.Width;
		}
		else if (axisRenderContext.int_5 == 2)
		{
			horizontalAlignment = Enum157.const_7;
			num = plotAreaRect.Right;
			num += num2;
			displayUnitInternal.ChartFrameInternal.rectangle_1.X = (int)(num + axisRenderContext.float_1);
		}
		else if (axisRenderContext.int_5 == 3)
		{
			if (reversed)
			{
				horizontalAlignment = Enum157.const_7;
				num = left;
				num += num2;
				displayUnitInternal.ChartFrameInternal.rectangle_1.X = (int)(num + axisRenderContext.float_1);
			}
			else
			{
				num = left - axisRenderContext.float_1;
				displayUnitInternal.ChartFrameInternal.rectangle_1.X = (int)num - displayUnitInternal.ChartFrameInternal.rectangle_1.Width;
			}
		}
		displayUnitInternal.ChartFrameInternal.rectangle_1.Y = plotAreaRect.Y;
		ArrayList arrayList_ = axisRenderContext.arrayList_0;
		double logMaxValue = axisRenderContext.LogMaxValue;
		double logMinValue = axisRenderContext.LogMinValue;
		double num4 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MajorUnit) : axisRenderContext.MajorUnit);
		double num5 = 1E-06;
		if (!axisRenderContext.Axis.IsPlotOrderReversed)
		{
			for (int num6 = arrayList_.Count - 1; num6 >= 0; num6--)
			{
				double num7 = (double)arrayList_[num6];
				double num8 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_1(num7) : num7);
				if (num6 - 1 > 0)
				{
					if (Math.Abs(Struct41.smethod_11(num4, Math.Abs(Struct41.smethod_11(num7, (double)arrayList_[num6 - 1])))) / num4 > num5)
					{
						continue;
					}
				}
				else if (num6 + 1 < arrayList_.Count && Math.Abs(Struct41.smethod_11(num4, Math.Abs(Struct41.smethod_11(num7, (double)arrayList_[num6 + 1])))) / num4 > num5)
				{
					continue;
				}
				float num9 = (float)((double)plotAreaRect.Y + (logMaxValue - num7) / (logMaxValue - logMinValue) * (double)plotAreaRect.Height);
				if (axisRenderContext.int_5 != 0)
				{
					if (Struct24.smethod_42(resembleType))
					{
						num8 /= 100.0;
						format = "0%";
					}
					string text = "";
					num8 = (axisRenderContext.Axis.IsLogarithmic ? num8 : (num8 * smethod_22(axisRenderContext)));
					Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
					if (axisRenderContext.IsLinkedSource)
					{
						text = Struct28.smethod_5(num8, format, yValueIsCulture);
						tickLabelFontColor = Struct28.smethod_6(num8, format, tickLabelFontColor);
					}
					else
					{
						text = smethod_34(num8, axisRenderContext);
						tickLabelFontColor = Struct28.smethod_6(num8, axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
					}
					RectangleF value = new RectangleF(num, num9 - num3, axisRenderContext.float_1 - num2, axisRenderContext.float_2);
					smethod_44(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, horizontalAlignment, Enum157.const_1);
				}
				smethod_5(g, reversed, left, num9, axisRenderContext, renderContext);
			}
		}
		else
		{
			for (int i = 0; i < arrayList_.Count; i++)
			{
				double num10 = (double)arrayList_[i];
				double num11 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_1(num10) : num10);
				if (i - 1 > 0)
				{
					if (Math.Abs(Struct41.smethod_11(num4, Math.Abs(Struct41.smethod_11(num10, (double)arrayList_[i - 1])))) / num4 > num5)
					{
						continue;
					}
				}
				else if (i + 1 < arrayList_.Count && Math.Abs(Struct41.smethod_11(num4, Math.Abs(Struct41.smethod_11(num10, (double)arrayList_[i + 1])))) / num4 > num5)
				{
					continue;
				}
				float num12 = (float)((double)plotAreaRect.Y + (num10 - axisRenderContext.MinValue) / (axisRenderContext.MaxValue - axisRenderContext.MinValue) * (double)plotAreaRect.Height);
				if (axisRenderContext.int_5 != 0)
				{
					if (Struct24.smethod_42(resembleType))
					{
						num11 /= 100.0;
						format = "0%";
					}
					string text2 = "";
					num11 = (axisRenderContext.Axis.IsLogarithmic ? num11 : (num11 * smethod_22(axisRenderContext)));
					Color tickLabelFontColor2 = axisRenderContext.TickLabelFontColor;
					if (axisRenderContext.IsLinkedSource)
					{
						text2 = Struct28.smethod_5(num11, format, yValueIsCulture);
						tickLabelFontColor2 = Struct28.smethod_6(num11, format, tickLabelFontColor2);
					}
					else
					{
						text2 = smethod_34(num11, axisRenderContext);
						tickLabelFontColor2 = Struct28.smethod_6(num11, axisRenderContext.Axis.NumberFormat, tickLabelFontColor2);
					}
					RectangleF value2 = new RectangleF(num, num12 - num3, axisRenderContext.float_1 - num2, axisRenderContext.float_2);
					smethod_44(g, Rectangle.Round(value2), text2, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor2, horizontalAlignment, Enum157.const_1);
				}
				smethod_5(g, reversed, left, num12, axisRenderContext, renderContext);
			}
		}
		smethod_6(g, reversed, left, plotAreaRect.Y, plotAreaRect.Bottom, axisRenderContext, renderContext);
		displayUnitInternal.method_0();
	}

	private static void smethod_5(Interface32 g, bool reversed, float left, float y, Class783 axisRenderContext, Class784 renderContext)
	{
		Class783 @class = smethod_43(renderContext, axisRenderContext);
		bool flag = false;
		bool flag2 = false;
		switch (axisRenderContext.Axis.MajorTickMark)
		{
		case TickMarkType.Cross:
			flag = true;
			flag2 = true;
			break;
		case TickMarkType.Inside:
			flag = true;
			if (reversed)
			{
				flag = false;
				flag2 = true;
			}
			if (@class.Axis.CrossType == CrossesType.Maximum)
			{
				if (reversed)
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
		case TickMarkType.Outside:
			flag2 = true;
			if (reversed)
			{
				flag2 = false;
				flag = true;
			}
			if (@class.Axis.CrossType == CrossesType.Maximum)
			{
				if (!reversed)
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
		float num = smethod_0(axisRenderContext.TickLabelTextFont.Size);
		if (flag)
		{
			axisRenderContext.method_3(left, y, left + num, y);
		}
		if (flag2)
		{
			axisRenderContext.method_3(left - num, y, left, y);
		}
	}

	private static void smethod_6(Interface32 g, bool reversed, float left, float y0, float y1, Class783 axisRenderContext, Class784 renderContext)
	{
		if (axisRenderContext.Axis.MinorTickMark == TickMarkType.None)
		{
			return;
		}
		Class783 @class = smethod_43(renderContext, axisRenderContext);
		bool flag = false;
		bool flag2 = false;
		switch (axisRenderContext.Axis.MinorTickMark)
		{
		case TickMarkType.Cross:
			flag = true;
			flag2 = true;
			break;
		case TickMarkType.Inside:
			flag = true;
			if (reversed)
			{
				flag = false;
				flag2 = true;
			}
			if (@class.Axis.CrossType == CrossesType.Maximum)
			{
				if (reversed)
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
		case TickMarkType.Outside:
			flag2 = true;
			if (reversed)
			{
				flag2 = false;
				flag = true;
			}
			if (@class.Axis.CrossType == CrossesType.Maximum)
			{
				if (!reversed)
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
		float num = (float)(axisRenderContext.MinorUnit / (axisRenderContext.MaxValue - axisRenderContext.MinValue) * (double)(y1 - y0));
		float num2;
		if (!axisRenderContext.Axis.IsPlotOrderReversed)
		{
			num2 = y1;
			num = 0f - num;
		}
		else
		{
			num2 = y0;
		}
		float num3 = num2;
		float num4 = smethod_1(axisRenderContext.TickLabelTextFont.Size);
		do
		{
			if (flag)
			{
				axisRenderContext.method_3(left, num3, left + num4, num3);
			}
			if (flag2)
			{
				axisRenderContext.method_3(left - num4, num3, left, num3);
			}
			num3 += num;
		}
		while (y0 <= num3 && num3 <= y1);
	}

	internal static void smethod_7(Interface32 g, bool reversed, float top, Rectangle plotAreaRect, int maxPointsCount, bool isDisplayAxisSameAsBar, Class783 axisRenderContext, Class784 renderContext)
	{
		if (Struct41.smethod_21(plotAreaRect))
		{
			return;
		}
		if (axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_10(g, reversed, top, plotAreaRect, axisRenderContext, renderContext);
			return;
		}
		axisRenderContext.method_3(plotAreaRect.X, top, plotAreaRect.Right, top);
		float num = 0f;
		Enum157 vAlign = Enum157.const_9;
		float num2 = axisRenderContext.TickLabelsOffsetPixel;
		if (axisRenderContext.int_5 != 0)
		{
			float size = axisRenderContext.TickLabelTextFont.Size;
			num2 += smethod_0(size) + smethod_1(size);
		}
		float y = 0f;
		if (axisRenderContext.int_5 == 1)
		{
			num = (float)plotAreaRect.Bottom + num2;
			y = (float)plotAreaRect.Bottom + num2;
		}
		else if (axisRenderContext.int_5 == 2)
		{
			vAlign = Enum157.const_0;
			num = (float)plotAreaRect.Y - num2 - axisRenderContext.float_3;
			y = (float)plotAreaRect.Y - num2;
		}
		else if (axisRenderContext.int_5 == 3)
		{
			if (reversed)
			{
				num = top - num2 - axisRenderContext.float_3;
				y = top - num2;
				vAlign = Enum157.const_0;
			}
			else
			{
				num = top + num2;
				y = top + num2;
			}
		}
		Class740 chart = renderContext.Chart2007;
		List<Interface8> list;
		List<Interface8>[] array;
		if (axisRenderContext.AxisType == Enum160.const_0)
		{
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			array = chart.NSeriesInternal.Categories;
		}
		else
		{
			list = chart.NSeriesInternal.Category2LabelsInternal;
			array = chart.NSeriesInternal.Categories2;
		}
		Class743 @class = null;
		bool flag = true;
		if (list != null && list.Count > 0)
		{
			@class = (Class743)list[0];
			if (!axisRenderContext.IsAutoTickLabelSpacing && axisRenderContext.TickLabelSpacing > 0 && (@class.LabelValue == null || @class.LabelValue.Equals("")))
			{
				flag = false;
			}
		}
		bool flag2 = axisRenderContext.IsLinkedSource && list.Count > 0;
		if (array != null && array.Length > 0 && list.Count > 0)
		{
			flag2 = true;
		}
		int num3 = 0;
		if (!axisRenderContext.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num3 = maxPointsCount - 1;
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		else
		{
			num3 = maxPointsCount;
		}
		double num4 = (double)plotAreaRect.Width / (double)num3;
		SizeF layoutArea = new SizeF(axisRenderContext.float_4, axisRenderContext.float_3);
		float num5 = -1f;
		float num6 = -1f;
		for (int i = 0; i < maxPointsCount; i++)
		{
			double num7 = (double)(i + 1) * num4;
			if (!axisRenderContext.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
			{
				num7 -= num4 / 2.0;
			}
			float num8;
			float num9;
			float x;
			if (!axisRenderContext.Axis.IsPlotOrderReversed)
			{
				num8 = (float)((double)plotAreaRect.X + (double)(i + 1) * num4);
				num9 = (float)((double)plotAreaRect.X + num7 - num4);
				x = (float)((double)plotAreaRect.X + (double)(i + 1) * num4 - num4 / 2.0);
			}
			else
			{
				num8 = (float)((double)(plotAreaRect.X + plotAreaRect.Width) - (double)(i + 1) * num4);
				num9 = (float)((double)(plotAreaRect.X + plotAreaRect.Width) - num7);
				x = (float)((double)(plotAreaRect.X + plotAreaRect.Width) - (double)(i + 1) * num4 + num4 / 2.0);
			}
			if (axisRenderContext.int_5 != 0 && i % axisRenderContext.TickLabelSpacing == 0 && i < axisRenderContext.arrayList_0.Count && flag)
			{
				string text = "";
				Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
				if (!flag2)
				{
					text = smethod_34(axisRenderContext.arrayList_0[i], axisRenderContext);
					tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
				}
				else
				{
					string text2 = "";
					bool flag3 = false;
					text2 = ((i < list.Count) ? ((Class743)list[i]).SourceFormat : "");
					flag3 = i < list.Count && ((Class743)list[i]).IsCulture;
					text = Struct28.smethod_5(axisRenderContext.arrayList_0[i], text2, flag3);
					tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], text2, tickLabelFontColor);
				}
				float height = axisRenderContext.float_3;
				Size size2 = Struct39.smethod_3(g, text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, layoutArea, Enum157.const_1, Enum157.const_1);
				if ((float)size2.Height < axisRenderContext.float_3)
				{
					height = size2.Height;
				}
				RectangleF value = new RectangleF((float)((double)num9 + num4 / 2.0 - (double)(axisRenderContext.float_4 / 2f)), num, axisRenderContext.float_4, height);
				if (axisRenderContext.TickLableRotation != 0 && axisRenderContext.TickLableRotation != 90 && axisRenderContext.TickLableRotation != -90)
				{
					smethod_46(chart.Graphics, text, new PointF(x, y), new SizeF(axisRenderContext.float_4, height), axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, axisRenderContext.Axis.Position);
				}
				else
				{
					Enum157 horizontalAlignment = Enum157.const_1;
					Enum157 verticalAlignment = Enum157.const_1;
					if (axisRenderContext.TickLableRotation != 90 && axisRenderContext.TickLableRotation != -90)
					{
						smethod_45(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, horizontalAlignment, verticalAlignment);
					}
					else
					{
						Size size3 = Struct39.smethod_3(g, text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, value.Size, horizontalAlignment, verticalAlignment);
						SizeF sizeF = Struct39.smethod_17(g, text, axisRenderContext.TickLabelTextFont, new SizeF(value.Height, value.Width));
						RectangleF value2 = new RectangleF((float)((double)num9 + num4 / 2.0 - (double)(size3.Width / 2)), num, size3.Width, size3.Height);
						value2.Y -= ((float)size3.Height - sizeF.Width) / 2f;
						if (value2.Width < (float)size3.Height)
						{
							value2.Width = sizeF.Height + 1f;
						}
						smethod_45(g, Rectangle.Round(value2), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, horizontalAlignment, verticalAlignment);
					}
				}
			}
			if (i == 0)
			{
				float num10 = (axisRenderContext.Axis.IsPlotOrderReversed ? ((float)plotAreaRect.Right) : ((float)plotAreaRect.X));
				if (num10 >= (float)plotAreaRect.X && num10 <= (float)(plotAreaRect.X + plotAreaRect.Width))
				{
					smethod_8(g, reversed, num10, top, plotAreaRect, axisRenderContext, renderContext);
				}
				float num11 = num10;
				num11 = (axisRenderContext.Axis.IsPlotOrderReversed ? (num11 + (float)(num4 * (double)axisRenderContext.TickMarkSpacing / 2.0)) : (num11 - (float)(num4 * (double)axisRenderContext.TickMarkSpacing / 2.0)));
				if (num11 > (float)plotAreaRect.X && num11 < (float)(plotAreaRect.X + plotAreaRect.Width))
				{
					smethod_9(g, reversed, num11, top, plotAreaRect, axisRenderContext, renderContext);
				}
			}
			if ((i + 1) % axisRenderContext.TickMarkSpacing == 0)
			{
				if (num8 >= (float)plotAreaRect.X && num8 <= (float)(plotAreaRect.X + plotAreaRect.Width) && Math.Abs(num5 - num8) > (double.IsNaN(axisRenderContext.Axis.Format.Line.Width) ? 1f : ((float)axisRenderContext.Axis.Format.Line.Width / 2f)))
				{
					smethod_8(g, reversed, num8, top, plotAreaRect, axisRenderContext, renderContext);
					num5 = num8;
				}
				float num12 = num8;
				num12 = (axisRenderContext.Axis.IsPlotOrderReversed ? (num12 + (float)(num4 * (double)axisRenderContext.TickMarkSpacing / 2.0)) : (num12 - (float)(num4 * (double)axisRenderContext.TickMarkSpacing / 2.0)));
				if (num12 > (float)plotAreaRect.X && num12 < (float)(plotAreaRect.X + plotAreaRect.Width) && Math.Abs(num6 - num12) > (float)axisRenderContext.Axis.Format.Line.Width / 2f)
				{
					smethod_9(g, reversed, num12, top, plotAreaRect, axisRenderContext, renderContext);
					num6 = num12;
				}
			}
		}
		if (array == null || array.Length <= 0 || list.Count <= 0 || axisRenderContext.int_5 == 0)
		{
			return;
		}
		float num13 = (float)(array.Length + 1) * num2;
		IList list2 = array[0];
		Class743 class2 = (Class743)list2[0];
		string text3 = Struct28.smethod_5(class2.LabelValue, class2.SourceFormat, class2.IsCulture);
		Size size4 = Struct39.smethod_2(chart.Graphics, text3, 0, axisRenderContext.TickLabelTextFont, plotAreaRect.Size, Enum157.const_1, Enum157.const_1);
		float lineStartY = 0f;
		bool isPlus = true;
		if (axisRenderContext.int_5 == 1)
		{
			num = (float)plotAreaRect.Bottom + num13 + axisRenderContext.float_2;
			lineStartY = plotAreaRect.Bottom;
			isPlus = false;
		}
		else if (axisRenderContext.int_5 == 2)
		{
			num = (float)plotAreaRect.Y - num13 - axisRenderContext.float_2;
			lineStartY = plotAreaRect.Y;
			isPlus = true;
		}
		else if (axisRenderContext.int_5 == 3)
		{
			if (reversed)
			{
				num = top - num13 - axisRenderContext.float_2 + (float)size4.Height;
				isPlus = true;
			}
			else
			{
				num = top + num13 + axisRenderContext.float_2 - (float)size4.Height;
				isPlus = false;
			}
			lineStartY = top;
		}
		float labelX = (axisRenderContext.Axis.IsPlotOrderReversed ? ((float)plotAreaRect.Right) : ((float)plotAreaRect.X));
		smethod_41(g, array, labelX, num, num2, isPlus, num4, vAlign, lineStartY, plotAreaRect, isDisplayAxisSameAsBar, axisRenderContext);
	}

	private static void smethod_8(Interface32 g, bool reversed, float x, float y, Rectangle plotAreaRect, Class783 axisRenderContext, Class784 renderContext)
	{
		Class783 @class = smethod_43(renderContext, axisRenderContext);
		bool flag = false;
		bool flag2 = false;
		switch (axisRenderContext.Axis.MajorTickMark)
		{
		case TickMarkType.Cross:
			flag = true;
			flag2 = true;
			break;
		case TickMarkType.Inside:
			flag = true;
			if (reversed)
			{
				flag = false;
				flag2 = true;
			}
			if (@class.Axis.CrossType == CrossesType.Maximum)
			{
				if (reversed)
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
		case TickMarkType.Outside:
			flag2 = true;
			if (reversed)
			{
				flag2 = false;
				flag = true;
			}
			if (@class.Axis.CrossType == CrossesType.Maximum)
			{
				if (!reversed)
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
		float num = smethod_0(axisRenderContext.TickLabelTextFont.Size);
		if (flag)
		{
			axisRenderContext.method_3(x, y - num, x, y);
		}
		if (flag2)
		{
			axisRenderContext.method_3(x, y, x, y + num);
		}
	}

	private static void smethod_9(Interface32 g, bool reversed, float x, float y, Rectangle plotAreaRect, Class783 axisRenderContext, Class784 renderContext)
	{
		Class783 @class = smethod_43(renderContext, axisRenderContext);
		bool flag = false;
		bool flag2 = false;
		switch (axisRenderContext.Axis.MinorTickMark)
		{
		case TickMarkType.Cross:
			flag = true;
			flag2 = true;
			break;
		case TickMarkType.Inside:
			flag = true;
			if (reversed)
			{
				flag = false;
				flag2 = true;
			}
			if (@class.Axis.CrossType == CrossesType.Maximum)
			{
				if (reversed)
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
		case TickMarkType.Outside:
			flag2 = true;
			if (reversed)
			{
				flag2 = false;
				flag = true;
			}
			if (@class.Axis.CrossType == CrossesType.Maximum)
			{
				if (!reversed)
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
		float num = smethod_1(axisRenderContext.TickLabelTextFont.Size);
		if (flag)
		{
			axisRenderContext.method_3(x, y - num, x, y);
		}
		if (flag2)
		{
			axisRenderContext.method_3(x, y, x, y + num);
		}
	}

	private static void smethod_10(Interface32 g, bool reversed, float top, Rectangle plotAreaRect, Class783 axisRenderContext, Class784 renderContext)
	{
		ArrayList arrayList_ = axisRenderContext.arrayList_0;
		Class740 chart = renderContext.Chart2007;
		axisRenderContext.method_3(plotAreaRect.X, top, plotAreaRect.Right, top);
		float y = 0f;
		float num = axisRenderContext.TickLabelsOffsetPixel;
		if (axisRenderContext.int_5 != 0)
		{
			num += smethod_0(axisRenderContext.TickLabelTextFont.Size);
		}
		float y2 = 0f;
		if (axisRenderContext.int_5 == 1)
		{
			y = (float)plotAreaRect.Bottom + num;
			y2 = (float)plotAreaRect.Bottom + num;
		}
		else if (axisRenderContext.int_5 == 2)
		{
			y = (float)plotAreaRect.Y - num - axisRenderContext.float_3;
			y2 = (float)plotAreaRect.Y - num;
		}
		else if (axisRenderContext.int_5 == 3)
		{
			if (reversed)
			{
				y = top - num - axisRenderContext.float_3;
				y2 = top - num;
			}
			else
			{
				y = top + num;
				y2 = top + num;
			}
		}
		List<Interface8> list;
		List<Interface8>[] array;
		if (axisRenderContext.AxisType == Enum160.const_0)
		{
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			array = chart.NSeriesInternal.Categories;
		}
		else
		{
			list = chart.NSeriesInternal.Category2LabelsInternal;
			array = chart.NSeriesInternal.Categories2;
		}
		bool flag = axisRenderContext.IsLinkedSource && list.Count > 0;
		if (array != null && array.Length > 0 && list.Count > 0)
		{
			flag = true;
		}
		int num2 = 0;
		int maxValue = (int)axisRenderContext.MaxValue;
		int num3 = (int)axisRenderContext.MinValue;
		TimeUnitType baseUnitScale = axisRenderContext.Axis.BaseUnitScale;
		if (!renderContext.X1AxisRenderContext.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num2 = smethod_35(baseUnitScale, maxValue, num3, chart.IsDate1904);
			if (num2 == 0)
			{
				num2 = 1;
			}
		}
		else
		{
			num2 = smethod_35(baseUnitScale, maxValue, num3, chart.IsDate1904) + 1;
		}
		double num4 = (double)plotAreaRect.Width / (double)num2;
		float num5 = ((!axisRenderContext.Axis.IsPlotOrderReversed) ? ((float)plotAreaRect.X) : ((float)(plotAreaRect.X + plotAreaRect.Width)));
		SizeF layoutArea = new SizeF(axisRenderContext.float_1, axisRenderContext.float_3);
		for (int i = 0; i < arrayList_.Count; i++)
		{
			int num6 = Convert.ToInt32(axisRenderContext.arrayList_0[i]);
			int num7 = smethod_35(baseUnitScale, num6, num3, chart.IsDate1904);
			float num8 = (float)(num4 * (double)num7);
			float num9 = (float)(num4 * (double)smethod_35(baseUnitScale, smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, num6, chart.IsDate1904), num6, chart.IsDate1904));
			if (axisRenderContext.AxisBetweenCategories || renderContext.Chart.HasDataTable)
			{
				num8 += (float)(num4 / 2.0);
			}
			float num10;
			float x;
			if (axisRenderContext.Axis.IsPlotOrderReversed)
			{
				num10 = (float)(plotAreaRect.X + plotAreaRect.Width) - num8;
				x = num10;
				num5 -= num9;
			}
			else
			{
				num10 = (float)plotAreaRect.X + num8;
				x = num10;
				num5 += num9;
			}
			if (axisRenderContext.int_5 != 0 && i % axisRenderContext.TickLabelSpacing == 0)
			{
				string text = "";
				Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
				if (!flag)
				{
					text = smethod_34(axisRenderContext.arrayList_0[i], axisRenderContext);
					tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
				}
				else
				{
					string text2 = "";
					bool flag2 = false;
					text2 = ((i < list.Count) ? ((Class743)list[i]).SourceFormat : "");
					flag2 = i < list.Count && ((Class743)list[i]).IsCulture;
					text = Struct28.smethod_5(axisRenderContext.arrayList_0[i], text2, flag2);
					tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], text2, tickLabelFontColor);
				}
				float height = axisRenderContext.float_3;
				Size size = Struct39.smethod_3(g, text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, layoutArea, Enum157.const_1, Enum157.const_1);
				if ((float)size.Height < axisRenderContext.float_3)
				{
					height = size.Height;
				}
				RectangleF value = new RectangleF(num10 - axisRenderContext.float_1 / 2f, y, axisRenderContext.float_1, height);
				if (axisRenderContext.TickLableRotation != 0 && axisRenderContext.TickLableRotation != 90 && axisRenderContext.TickLableRotation != -90)
				{
					smethod_46(g, text, new PointF(x, y2), new SizeF(axisRenderContext.float_1, height), axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, axisRenderContext.Axis.Position);
				}
				else
				{
					smethod_45(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, Enum157.const_1, Enum157.const_1);
				}
			}
			if (i % axisRenderContext.TickMarkSpacing == 0 && num5 >= (float)plotAreaRect.X && num5 <= (float)(plotAreaRect.X + plotAreaRect.Width))
			{
				smethod_8(g, reversed, num5, top, plotAreaRect, axisRenderContext, renderContext);
			}
		}
		float num11 = ((!axisRenderContext.Axis.IsPlotOrderReversed) ? ((float)plotAreaRect.X) : ((float)(plotAreaRect.X + plotAreaRect.Width)));
		int num12 = num3;
		int num13 = smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, num3, chart.IsDate1904);
		do
		{
			bool flag3 = true;
			int num14 = smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MinorUnitScale, (int)axisRenderContext.MinorUnit, num12, chart.IsDate1904);
			if (num14 == num13)
			{
				flag3 = false;
				num13 = smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, num13, chart.IsDate1904);
			}
			if (num14 >= num13)
			{
				num13 = smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, num13, chart.IsDate1904);
			}
			float num15 = (float)(num4 * (double)smethod_35(baseUnitScale, num14, num12, chart.IsDate1904));
			num11 = ((!axisRenderContext.Axis.IsPlotOrderReversed) ? (num11 + num15) : (num11 - num15));
			if (flag3 && num11 >= (float)plotAreaRect.X && num11 <= (float)(plotAreaRect.X + plotAreaRect.Width))
			{
				smethod_9(g, reversed, num11, top, plotAreaRect, axisRenderContext, renderContext);
			}
			num12 = num14;
		}
		while (num11 >= (float)plotAreaRect.X && num11 <= (float)(plotAreaRect.X + plotAreaRect.Width));
	}

	internal static void smethod_11(Interface32 g, bool reversed, float top, Rectangle plotAreaRect, Class759 firstSeries, Class783 axisRenderContext, Class784 renderContext)
	{
		if (Struct41.smethod_21(plotAreaRect))
		{
			return;
		}
		ChartType resembleType = firstSeries.ResembleType;
		Class748 @class = firstSeries.PointsInternal.method_0(0);
		string format = @class.YFormat;
		bool yValueIsCulture = @class.YValueIsCulture;
		axisRenderContext.method_3(plotAreaRect.X, top, plotAreaRect.Right, top);
		Class751 displayUnitInternal = axisRenderContext.DisplayUnitInternal;
		float num = 0f;
		float num2 = 2f * smethod_0(axisRenderContext.TickLabelTextFont.Size);
		float num3 = axisRenderContext.float_1 / 2f;
		if (axisRenderContext.int_5 == 1)
		{
			num = plotAreaRect.Bottom;
			num += num2;
			displayUnitInternal.ChartFrameInternal.rectangle_1.Y = (int)(num + axisRenderContext.float_2);
		}
		else if (axisRenderContext.int_5 == 2)
		{
			num = (float)plotAreaRect.Y - axisRenderContext.float_2;
			displayUnitInternal.ChartFrameInternal.rectangle_1.Y = (int)num - displayUnitInternal.ChartFrameInternal.Height;
		}
		else if (axisRenderContext.int_5 == 3)
		{
			if (reversed)
			{
				num = top - axisRenderContext.float_2;
				displayUnitInternal.ChartFrameInternal.rectangle_1.Y = (int)num - displayUnitInternal.ChartFrameInternal.Height;
			}
			else
			{
				num = top;
				num += num2;
				displayUnitInternal.ChartFrameInternal.rectangle_1.Y = (int)(num + axisRenderContext.float_2);
			}
		}
		displayUnitInternal.ChartFrameInternal.rectangle_1.X = plotAreaRect.Right - displayUnitInternal.ChartFrameInternal.rectangle_1.Width;
		if (!axisRenderContext.Axis.IsPlotOrderReversed)
		{
			double value = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MajorUnit) : axisRenderContext.MajorUnit);
			for (int i = 0; i < axisRenderContext.arrayList_0.Count; i++)
			{
				double num4 = (double)axisRenderContext.arrayList_0[i];
				if (i - 1 > 0)
				{
					int digits = Struct41.smethod_10(num4, (double)axisRenderContext.arrayList_0[i - 1]);
					if (Math.Abs(Struct41.smethod_11(num4, (double)axisRenderContext.arrayList_0[i - 1])) != Math.Round(value, digits))
					{
						continue;
					}
				}
				else if (i + 1 < axisRenderContext.arrayList_0.Count)
				{
					int digits2 = Struct41.smethod_10(num4, (double)axisRenderContext.arrayList_0[i + 1]);
					if (Math.Abs(Struct41.smethod_11(num4, (double)axisRenderContext.arrayList_0[i + 1])) != Math.Round(value, digits2))
					{
						continue;
					}
				}
				float num5 = ((!axisRenderContext.Axis.IsLogarithmic) ? ((float)((double)plotAreaRect.X + (num4 - axisRenderContext.MinValue) / (axisRenderContext.MaxValue - axisRenderContext.MinValue) * (double)plotAreaRect.Width)) : ((float)((double)plotAreaRect.X + (num4 - axisRenderContext.method_0(axisRenderContext.MinValue)) / (axisRenderContext.method_0(axisRenderContext.MaxValue) - axisRenderContext.method_0(axisRenderContext.MinValue)) * (double)plotAreaRect.Width)));
				if (axisRenderContext.int_5 != 0)
				{
					if (Struct24.smethod_42(resembleType))
					{
						num4 /= 100.0;
						format = "0%";
					}
					string text = "";
					Color color = axisRenderContext.TickLabelFontColor;
					num4 *= smethod_22(axisRenderContext);
					if (axisRenderContext.Axis.IsLogarithmic)
					{
						text = Math.Pow(axisRenderContext.Axis.LogBase, num4).ToString();
					}
					else if (axisRenderContext.IsLinkedSource)
					{
						text = Struct28.smethod_5(num4, format, yValueIsCulture);
						color = Struct28.smethod_6(num4, format, color);
					}
					else
					{
						text = smethod_34(num4, axisRenderContext);
						color = Struct28.smethod_6(num4, axisRenderContext.Axis.NumberFormat, color);
					}
					RectangleF value2 = new RectangleF(num5 - num3, num, axisRenderContext.float_1, axisRenderContext.float_2 - num2);
					smethod_44(g, Rectangle.Round(value2), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, color, Enum157.const_1, Enum157.const_1);
				}
				smethod_8(g, reversed, num5, top, plotAreaRect, axisRenderContext, renderContext);
			}
		}
		else
		{
			for (int num6 = axisRenderContext.arrayList_0.Count - 1; num6 >= 0; num6--)
			{
				double num7 = (double)axisRenderContext.arrayList_0[num6];
				if (num6 - 1 > 0)
				{
					int digits3 = Struct41.smethod_10(num7, (double)axisRenderContext.arrayList_0[num6 - 1]);
					if (Math.Abs(Struct41.smethod_11(num7, (double)axisRenderContext.arrayList_0[num6 - 1])) != Math.Round(axisRenderContext.MajorUnit, digits3))
					{
						continue;
					}
				}
				else if (num6 + 1 < axisRenderContext.arrayList_0.Count)
				{
					int digits4 = Struct41.smethod_10(num7, (double)axisRenderContext.arrayList_0[num6 + 1]);
					if (Math.Abs(Struct41.smethod_11(num7, (double)axisRenderContext.arrayList_0[num6 + 1])) != Math.Round(axisRenderContext.MajorUnit, digits4))
					{
						continue;
					}
				}
				float num8 = ((!axisRenderContext.Axis.IsLogarithmic) ? ((float)((double)plotAreaRect.X + (axisRenderContext.MaxValue - num7) / (axisRenderContext.MaxValue - axisRenderContext.MinValue) * (double)plotAreaRect.Width)) : ((float)((double)plotAreaRect.X + (axisRenderContext.method_0(axisRenderContext.MaxValue) - num7) / (axisRenderContext.method_0(axisRenderContext.MaxValue) - axisRenderContext.method_0(axisRenderContext.MinValue)) * (double)plotAreaRect.Width)));
				if (axisRenderContext.int_5 != 0)
				{
					if (Struct24.smethod_42(resembleType))
					{
						num7 /= 100.0;
						format = "0%";
					}
					string text2 = "";
					Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
					num7 *= smethod_22(axisRenderContext);
					if (axisRenderContext.IsLinkedSource)
					{
						text2 = Struct28.smethod_5(num7, format, yValueIsCulture);
						tickLabelFontColor = Struct28.smethod_6(num7, format, tickLabelFontColor);
					}
					else
					{
						text2 = smethod_34(num7, axisRenderContext);
						tickLabelFontColor = Struct28.smethod_6(num7, axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
					}
					RectangleF value3 = new RectangleF(num8 - num3, num, axisRenderContext.float_1, axisRenderContext.float_2 - num2);
					smethod_44(g, Rectangle.Round(value3), text2, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, Enum157.const_1, Enum157.const_1);
				}
				smethod_8(g, reversed, num8, top, plotAreaRect, axisRenderContext, renderContext);
			}
		}
		smethod_12(g, reversed, top, plotAreaRect.X, plotAreaRect.Right, plotAreaRect, axisRenderContext, renderContext);
		displayUnitInternal.method_0();
	}

	private static void smethod_12(Interface32 g, bool reversed, float top, float x0, float x1, Rectangle plotAreaRect, Class783 axisRenderContext, Class784 renderContext)
	{
		if (axisRenderContext.Axis.MinorTickMark == TickMarkType.None)
		{
			return;
		}
		Class783 @class = smethod_43(renderContext, axisRenderContext);
		bool flag = false;
		bool flag2 = false;
		switch (axisRenderContext.Axis.MinorTickMark)
		{
		case TickMarkType.Cross:
			flag = true;
			flag2 = true;
			break;
		case TickMarkType.Inside:
			flag = true;
			if (reversed)
			{
				flag = false;
				flag2 = true;
			}
			if (@class.Axis.CrossType == CrossesType.Maximum)
			{
				if (reversed)
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
		case TickMarkType.Outside:
			flag2 = true;
			if (reversed)
			{
				flag2 = false;
				flag = true;
			}
			if (@class.Axis.CrossType == CrossesType.Maximum)
			{
				if (!reversed)
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
		float num = (float)(axisRenderContext.MinorUnit / (axisRenderContext.MaxValue - axisRenderContext.MinValue) * (double)(x1 - x0));
		float num2;
		if (axisRenderContext.Axis.IsPlotOrderReversed)
		{
			num2 = x1;
			num = 0f - num;
		}
		else
		{
			num2 = x0;
		}
		float num3 = num2;
		float num4 = smethod_1(axisRenderContext.TickLabelTextFont.Size);
		do
		{
			if (flag)
			{
				axisRenderContext.method_3(num3, top, num3, top - num4);
			}
			if (flag2)
			{
				axisRenderContext.method_3(num3, top, num3, top + num4);
			}
			num3 += num;
		}
		while (x0 <= num3 && num3 <= x1);
	}

	internal static void smethod_13(Interface32 g, bool reversed, float left, Rectangle plotAreaRect, int maxPointsCount, Class783 axisRenderContext, Class784 renderContext)
	{
		if (Struct41.smethod_21(plotAreaRect))
		{
			return;
		}
		if (axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_17(g, reversed, left, plotAreaRect, axisRenderContext, renderContext);
			return;
		}
		axisRenderContext.method_3(left, plotAreaRect.Y, left, plotAreaRect.Bottom);
		Class740 chart = renderContext.Chart2007;
		float num = 0f;
		float x = 0f;
		float size = axisRenderContext.TickLabelTextFont.Size;
		float num2 = smethod_0(size) + smethod_1(size) + (float)axisRenderContext.TickLabelsOffsetPixel;
		float num3 = axisRenderContext.float_2 / 2f;
		Enum157 horizontalAlignment = Enum157.const_8;
		float num4 = 0f;
		if (Math.Abs(axisRenderContext.TickLableRotation) == 90)
		{
			num4 = axisRenderContext.float_1;
		}
		if (num4 > (float)axisRenderContext.TickLabelTextFont.Height * 1.5f)
		{
			horizontalAlignment = Enum157.const_1;
		}
		if (axisRenderContext.int_5 == 1)
		{
			num = (float)plotAreaRect.X - axisRenderContext.float_4 - num2;
			x = (float)plotAreaRect.X - num2;
		}
		else if (axisRenderContext.int_5 == 2)
		{
			num = (float)plotAreaRect.Right + num2;
			x = (float)plotAreaRect.Right + num2;
			horizontalAlignment = Enum157.const_7;
		}
		else if (axisRenderContext.int_5 == 3)
		{
			if (reversed)
			{
				num = left + num2;
				x = left + num2;
				horizontalAlignment = Enum157.const_7;
			}
			else
			{
				num = left - num2 - axisRenderContext.float_4;
				x = left - num2;
			}
		}
		int num5 = 0;
		if (!axisRenderContext.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num5 = maxPointsCount - 1;
			if (num5 == 0)
			{
				num5 = 1;
			}
		}
		else
		{
			num5 = maxPointsCount;
		}
		double num6 = (double)plotAreaRect.Height / (double)num5;
		List<Interface8> list;
		List<Interface8>[] array;
		if (axisRenderContext.AxisType == Enum160.const_0)
		{
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			array = chart.NSeriesInternal.Categories;
		}
		else
		{
			list = chart.NSeriesInternal.Category2LabelsInternal;
			array = chart.NSeriesInternal.Categories2;
		}
		bool flag = axisRenderContext.IsLinkedSource && list.Count > 0;
		for (int i = 0; i < maxPointsCount; i++)
		{
			double num7 = (double)(i + 1) * num6;
			if (axisRenderContext.AxisBetweenCategories || renderContext.Chart.HasDataTable)
			{
				num7 += num6 / 2.0;
			}
			float num8;
			float num9;
			float y;
			if (axisRenderContext.Axis.IsPlotOrderReversed)
			{
				num8 = (float)((double)plotAreaRect.Y + (double)(i + 1) * num6);
				num9 = (float)((double)plotAreaRect.Y + num7 - num6);
				y = (float)((double)plotAreaRect.Y + num7 - num6);
			}
			else
			{
				num8 = (float)((double)(plotAreaRect.Y + plotAreaRect.Height) - (double)(i + 1) * num6);
				num9 = (float)((double)(plotAreaRect.Y + plotAreaRect.Height) - num7 + num6);
				y = (float)((double)(plotAreaRect.Y + plotAreaRect.Height) - num7 + num6);
			}
			if (axisRenderContext.int_5 != 0 && i % axisRenderContext.TickLabelSpacing == 0 && i < axisRenderContext.arrayList_0.Count)
			{
				string text = "";
				Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
				if (!flag)
				{
					text = smethod_34(axisRenderContext.arrayList_0[i], axisRenderContext);
					tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
				}
				else
				{
					string text2 = "";
					bool flag2 = false;
					text2 = ((i < list.Count) ? ((Class743)list[i]).SourceFormat : "");
					flag2 = i < list.Count && ((Class743)list[i]).IsCulture;
					text = Struct28.smethod_5(axisRenderContext.arrayList_0[i], text2, flag2);
					tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], text2, tickLabelFontColor);
				}
				RectangleF value = new RectangleF(num, num9 - num3, axisRenderContext.float_4, axisRenderContext.float_3);
				if (axisRenderContext.TickLableRotation != 0 && axisRenderContext.TickLableRotation != 90)
				{
					smethod_46(g, text, new PointF(x, y), new SizeF(axisRenderContext.float_4, axisRenderContext.float_3), axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, axisRenderContext.Axis.Position);
				}
				else
				{
					smethod_44(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, horizontalAlignment, Enum157.const_1);
				}
			}
			if (i == 0)
			{
				float num10 = ((!axisRenderContext.Axis.IsPlotOrderReversed) ? ((float)plotAreaRect.Bottom) : ((float)plotAreaRect.Y));
				if (num10 >= (float)plotAreaRect.Y && num10 <= (float)(plotAreaRect.Y + plotAreaRect.Height))
				{
					smethod_5(g, reversed, left, num10, axisRenderContext, renderContext);
				}
				float num11 = num10;
				num11 = (axisRenderContext.Axis.IsPlotOrderReversed ? (num11 - (float)(num6 * (double)axisRenderContext.TickMarkSpacing / 2.0)) : (num11 + (float)(num6 * (double)axisRenderContext.TickMarkSpacing / 2.0)));
				if (num11 >= (float)plotAreaRect.Y && num11 <= (float)(plotAreaRect.Y + plotAreaRect.Height))
				{
					smethod_16(reversed, left, num11, axisRenderContext, renderContext);
				}
			}
			if ((i + 1) % axisRenderContext.TickMarkSpacing == 0)
			{
				if (num8 >= (float)plotAreaRect.Y && num8 <= (float)(plotAreaRect.Y + plotAreaRect.Height))
				{
					smethod_5(g, reversed, left, num8, axisRenderContext, renderContext);
				}
				float num12 = num8;
				num12 = (axisRenderContext.Axis.IsPlotOrderReversed ? (num12 - (float)(num6 * (double)axisRenderContext.TickMarkSpacing / 2.0)) : (num12 + (float)(num6 * (double)axisRenderContext.TickMarkSpacing / 2.0)));
				if (num12 >= (float)plotAreaRect.Y && num12 <= (float)(plotAreaRect.Y + plotAreaRect.Height))
				{
					smethod_16(reversed, left, num12, axisRenderContext, renderContext);
				}
			}
		}
		if (array == null || array.Length <= 0 || list.Count <= 0 || axisRenderContext.int_5 == 0)
		{
			return;
		}
		float num13 = num2 * (float)(array.Length + 1);
		bool isPlus = false;
		float categoryX = plotAreaRect.X;
		if (axisRenderContext.int_5 == 1)
		{
			num = (float)plotAreaRect.X - axisRenderContext.float_1 - num13;
			isPlus = true;
			categoryX = plotAreaRect.X;
		}
		else if (axisRenderContext.int_5 == 2)
		{
			num = (float)plotAreaRect.Right + num13 + axisRenderContext.float_1;
			isPlus = false;
			categoryX = plotAreaRect.Right;
		}
		else if (axisRenderContext.int_5 == 3)
		{
			if (reversed)
			{
				num = left + num13 + axisRenderContext.float_1;
				isPlus = false;
			}
			else
			{
				num = left - num13 - axisRenderContext.float_1;
				isPlus = true;
			}
			categoryX = left;
		}
		smethod_14(labelY: axisRenderContext.Axis.IsPlotOrderReversed ? ((float)plotAreaRect.Y) : ((float)plotAreaRect.Bottom), g: g, categories: array, isPlus: isPlus, unitWidth: num6, plotAreaRect: plotAreaRect, xLableOffset: num2, categoryX: categoryX, labelX: num, axisRenderContext: axisRenderContext);
	}

	private static void smethod_14(Interface32 g, List<Interface8>[] categories, bool isPlus, double unitWidth, Rectangle plotAreaRect, float xLableOffset, float categoryX, float labelX, float labelY, Class783 axisRenderContext)
	{
		float num = labelY;
		for (int i = 0; i < categories.Length; i++)
		{
			Size size = new Size(0, 0);
			IList list = categories[i];
			for (int j = 0; j < list.Count; j++)
			{
				Class743 @class = (Class743)list[j];
				int num2 = smethod_39(@class);
				float num3 = (float)((double)num2 * unitWidth);
				string text = Struct28.smethod_5(@class.LabelValue, @class.SourceFormat, @class.IsCulture);
				size = Struct39.smethod_3(g, text, 90, axisRenderContext.TickLabelTextFont, new SizeF(plotAreaRect.Size.Width, plotAreaRect.Size.Height), Enum157.const_1, Enum157.const_1);
				float x = (isPlus ? labelX : (labelX - (float)size.Width));
				float y = (axisRenderContext.Axis.IsPlotOrderReversed ? (labelY + num3 / 2f - (float)(size.Height / 2)) : (labelY - num3 / 2f - (float)(size.Height / 2)));
				RectangleF value = new RectangleF(x, y, size.Width, size.Height);
				smethod_44(g, Rectangle.Round(value), text, 90, axisRenderContext.TickLabelTextFont, axisRenderContext.TickLabelFontColor, Enum157.const_1, Enum157.const_9);
				axisRenderContext.method_3(categoryX, labelY, labelX, labelY);
				if (axisRenderContext.Axis.MajorTickMark != TickMarkType.None)
				{
					float endX = (isPlus ? (labelX + (xLableOffset + (float)size.Width)) : (labelX - (xLableOffset + (float)size.Width)));
					smethod_15(g, @class.Children, categoryX, endX, labelY, unitWidth, axisRenderContext);
				}
				labelY = (axisRenderContext.Axis.IsPlotOrderReversed ? (labelY + num3) : (labelY - num3));
			}
			axisRenderContext.method_3(categoryX, labelY, labelX, labelY);
			labelY = num;
			labelX = (isPlus ? (labelX + (float)size.Width + xLableOffset) : (labelX - (float)size.Width - xLableOffset));
		}
	}

	private static void smethod_15(Interface32 g, Interface7 categoryLabelList, float startX, float endX, float startY, double unitWidth, Class783 axisRenderContext)
	{
		float num = startY;
		for (int i = 0; i < categoryLabelList.Count; i++)
		{
			Class743 categoryLabel = (Class743)categoryLabelList[i];
			int num2 = smethod_39(categoryLabel);
			float num3 = (float)((double)num2 * unitWidth);
			num = (axisRenderContext.Axis.IsPlotOrderReversed ? (num + num3) : (num - num3));
			axisRenderContext.method_3(startX, num, endX, num);
		}
	}

	private static void smethod_16(bool reversed, float left, float y, Class783 axisRenderContext, Class784 renderContext)
	{
		Class783 @class = smethod_43(renderContext, axisRenderContext);
		bool flag = false;
		bool flag2 = false;
		switch (axisRenderContext.Axis.MinorTickMark)
		{
		case TickMarkType.Cross:
			flag = true;
			flag2 = true;
			break;
		case TickMarkType.Inside:
			flag = true;
			if (reversed)
			{
				flag = false;
				flag2 = true;
			}
			if (@class.Axis.CrossType == CrossesType.Maximum)
			{
				if (reversed)
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
		case TickMarkType.Outside:
			flag2 = true;
			if (reversed)
			{
				flag2 = false;
				flag = true;
			}
			if (@class.Axis.CrossType == CrossesType.Maximum)
			{
				if (!reversed)
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
		float num = smethod_1(axisRenderContext.TickLabelTextFont.Size);
		if (flag)
		{
			axisRenderContext.method_3(left, y, left + num, y);
		}
		if (flag2)
		{
			axisRenderContext.method_3(left - num, y, left, y);
		}
	}

	private static void smethod_17(Interface32 g, bool reversed, float left, Rectangle plotAreaRect, Class783 axisRenderContext, Class784 renderContext)
	{
		ArrayList arrayList_ = axisRenderContext.arrayList_0;
		Class740 chart = renderContext.Chart2007;
		axisRenderContext.method_3(left, plotAreaRect.Y, left, plotAreaRect.Bottom);
		float x = 0f;
		float num = axisRenderContext.TickLabelsOffsetPixel;
		Enum157 horizontalAlignment = Enum157.const_8;
		if (axisRenderContext.int_5 == 1)
		{
			x = (float)plotAreaRect.X - axisRenderContext.float_1 - num;
		}
		else if (axisRenderContext.int_5 == 2)
		{
			x = (float)plotAreaRect.Right + num;
			horizontalAlignment = Enum157.const_7;
		}
		else if (axisRenderContext.int_5 == 3)
		{
			if (reversed)
			{
				x = left + num;
				horizontalAlignment = Enum157.const_7;
			}
			else
			{
				x = left - num - axisRenderContext.float_1;
			}
		}
		List<Interface8> list;
		List<Interface8>[] array;
		if (axisRenderContext.AxisType == Enum160.const_0)
		{
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			array = chart.NSeriesInternal.Categories;
		}
		else
		{
			list = chart.NSeriesInternal.Category2LabelsInternal;
			array = chart.NSeriesInternal.Categories2;
		}
		bool flag = axisRenderContext.IsLinkedSource && list.Count > 0;
		if (array != null && array.Length > 0 && list.Count > 0)
		{
			flag = true;
		}
		int num2 = 0;
		int maxValue = (int)axisRenderContext.MaxValue;
		int num3 = (int)axisRenderContext.MinValue;
		TimeUnitType baseUnitScale = axisRenderContext.Axis.BaseUnitScale;
		if (!renderContext.X1AxisRenderContext.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num2 = smethod_35(baseUnitScale, maxValue, num3, chart.IsDate1904);
			if (num2 == 0)
			{
				num2 = 1;
			}
		}
		else
		{
			num2 = smethod_35(baseUnitScale, maxValue, num3, chart.IsDate1904) + 1;
		}
		double num4 = (double)plotAreaRect.Height / (double)num2;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		num7 = ((!axisRenderContext.Axis.IsPlotOrderReversed) ? ((float)(plotAreaRect.Y + plotAreaRect.Height)) : ((float)plotAreaRect.Y));
		for (int i = 0; i < arrayList_.Count; i++)
		{
			int num8 = Convert.ToInt32(axisRenderContext.arrayList_0[i]);
			int num9 = smethod_35(baseUnitScale, num8, num3, chart.IsDate1904);
			float num10 = (float)(num4 * (double)num9);
			num5 = (float)(num4 * (double)smethod_35(baseUnitScale, smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, num8, chart.IsDate1904), num8, chart.IsDate1904));
			if (axisRenderContext.AxisBetweenCategories || renderContext.Chart.HasDataTable)
			{
				num10 += (float)(num4 / 2.0);
			}
			if (axisRenderContext.Axis.IsPlotOrderReversed)
			{
				num7 += num5;
				num6 = (float)plotAreaRect.Y + num10;
			}
			else
			{
				num7 -= num5;
				num6 = (float)(plotAreaRect.Y + plotAreaRect.Height) - num10;
			}
			num6 -= axisRenderContext.float_2 / 2f;
			if (axisRenderContext.int_5 != 0 && i % axisRenderContext.TickLabelSpacing == 0)
			{
				string text = "";
				Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
				if (!flag)
				{
					text = smethod_34(axisRenderContext.arrayList_0[i], axisRenderContext);
					tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
				}
				else
				{
					string text2 = "";
					bool flag2 = false;
					text2 = ((i < list.Count) ? ((Class743)list[i]).SourceFormat : "");
					flag2 = i < list.Count && ((Class743)list[i]).IsCulture;
					text = Struct28.smethod_5(axisRenderContext.arrayList_0[i], text2, flag2);
					tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], text2, tickLabelFontColor);
				}
				RectangleF value = new RectangleF(x, num6, axisRenderContext.float_1, axisRenderContext.float_2);
				smethod_44(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, horizontalAlignment, Enum157.const_1);
			}
			if (i % axisRenderContext.TickMarkSpacing == 0 && num7 >= (float)plotAreaRect.Y && num7 <= (float)(plotAreaRect.Y + plotAreaRect.Height))
			{
				smethod_5(g, reversed, left, num7, axisRenderContext, renderContext);
			}
		}
		float num11 = ((!axisRenderContext.Axis.IsPlotOrderReversed) ? ((float)(plotAreaRect.Y + plotAreaRect.Height)) : ((float)plotAreaRect.Y));
		int num12 = num3;
		int num13 = smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, num3, chart.IsDate1904);
		do
		{
			bool flag3 = true;
			int num14 = smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MinorUnitScale, (int)axisRenderContext.MinorUnit, num12, chart.IsDate1904);
			if (num14 == num13)
			{
				flag3 = false;
				num13 = smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, num13, chart.IsDate1904);
			}
			if (num14 >= num13)
			{
				num13 = smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, num13, chart.IsDate1904);
			}
			float num15 = (float)(num4 * (double)smethod_35(baseUnitScale, num14, num12, chart.IsDate1904));
			num11 = ((!axisRenderContext.Axis.IsPlotOrderReversed) ? (num11 - num15) : (num11 + num15));
			if (flag3 && num11 >= (float)plotAreaRect.Y && num11 <= (float)(plotAreaRect.Y + plotAreaRect.Height))
			{
				smethod_16(reversed, left, num11, axisRenderContext, renderContext);
			}
			num12 = num14;
		}
		while (num11 >= (float)plotAreaRect.Y && num11 <= (float)(plotAreaRect.Y + plotAreaRect.Height));
	}

	internal static void smethod_18(Interface32 g, bool reversed, float top, Rectangle plotAreaRect, Class759 firstSeries, Class783 axisRenderContext, Class784 renderContext)
	{
		if (Struct41.smethod_21(plotAreaRect))
		{
			return;
		}
		axisRenderContext.method_3(plotAreaRect.X, top, plotAreaRect.Right, top);
		Class751 displayUnitInternal = axisRenderContext.DisplayUnitInternal;
		float num = 0f;
		float num2 = axisRenderContext.TickLabelsOffsetPixel;
		if (axisRenderContext.int_5 == 1)
		{
			num = (float)plotAreaRect.Bottom + num2;
			displayUnitInternal.ChartFrameInternal.rectangle_1.Y = (int)(num + axisRenderContext.float_2);
		}
		else if (axisRenderContext.int_5 == 2)
		{
			num = (float)plotAreaRect.Y - num2 - axisRenderContext.float_2;
			displayUnitInternal.ChartFrameInternal.rectangle_1.Y = (int)num - displayUnitInternal.ChartFrameInternal.rectangle_1.Height;
		}
		else if (axisRenderContext.int_5 == 3)
		{
			if (reversed)
			{
				num = top - num2 - axisRenderContext.float_2;
				displayUnitInternal.ChartFrameInternal.rectangle_1.Y = (int)num - displayUnitInternal.ChartFrameInternal.rectangle_1.Height;
			}
			else
			{
				num = top + num2;
				displayUnitInternal.ChartFrameInternal.rectangle_1.Y = (int)(num + axisRenderContext.float_2);
			}
		}
		displayUnitInternal.ChartFrameInternal.rectangle_1.X = plotAreaRect.Right - displayUnitInternal.ChartFrameInternal.rectangle_1.Width;
		Class748 @class = firstSeries.PointsInternal.method_0(0);
		string xFormat = @class.XFormat;
		bool xValueIsCulture = @class.XValueIsCulture;
		ArrayList arrayList_ = axisRenderContext.arrayList_0;
		double num3 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MaxValue) : axisRenderContext.MaxValue);
		double num4 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MinValue) : axisRenderContext.MinValue);
		double num5 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MajorUnit) : axisRenderContext.MajorUnit);
		if (!axisRenderContext.Axis.IsPlotOrderReversed)
		{
			for (int i = 0; i < arrayList_.Count; i++)
			{
				double num6 = (double)arrayList_[i];
				double num7 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_1(num6) : num6);
				if (i - 1 > 0)
				{
					if (Math.Abs(Struct41.smethod_11(num6, (double)arrayList_[i - 1])) != num5)
					{
						continue;
					}
				}
				else if (i + 1 < arrayList_.Count && Math.Abs(Struct41.smethod_11(num6, (double)arrayList_[i + 1])) != num5)
				{
					continue;
				}
				float num8 = (float)((double)plotAreaRect.X + (num6 - num4) / (num3 - num4) * (double)plotAreaRect.Width);
				if (axisRenderContext.int_5 != 0)
				{
					string text = "";
					Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
					num7 = (axisRenderContext.Axis.IsLogarithmic ? num7 : (num7 * smethod_22(axisRenderContext)));
					if (axisRenderContext.IsLinkedSource)
					{
						text = Struct28.smethod_5(num7, xFormat, xValueIsCulture);
						tickLabelFontColor = Struct28.smethod_6(num7, xFormat, tickLabelFontColor);
					}
					else
					{
						text = smethod_34(num7, axisRenderContext);
						tickLabelFontColor = Struct28.smethod_6(num7, axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
					}
					RectangleF value = new RectangleF(num8 - axisRenderContext.float_1 / 2f, num, axisRenderContext.float_1, axisRenderContext.float_2);
					smethod_44(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, Enum157.const_1, Enum157.const_1);
				}
				smethod_8(g, reversed, num8, top, plotAreaRect, axisRenderContext, renderContext);
			}
		}
		else
		{
			for (int num9 = arrayList_.Count - 1; num9 >= 0; num9--)
			{
				double num10 = (double)arrayList_[num9];
				double num11 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_1(num10) : num10);
				if (num9 - 1 > 0)
				{
					if (Math.Abs(Struct41.smethod_11(num10, (double)arrayList_[num9 - 1])) != num5)
					{
						continue;
					}
				}
				else if (num9 + 1 < arrayList_.Count && Math.Abs(Struct41.smethod_11(num10, (double)arrayList_[num9 + 1])) != num5)
				{
					continue;
				}
				float num12 = (float)((double)plotAreaRect.X + (num3 - num10) / (num3 - num4) * (double)plotAreaRect.Width);
				if (axisRenderContext.int_5 != 0)
				{
					string text2 = "";
					Color tickLabelFontColor2 = axisRenderContext.TickLabelFontColor;
					num11 = (axisRenderContext.Axis.IsLogarithmic ? num11 : (num11 * smethod_22(axisRenderContext)));
					if (axisRenderContext.IsLinkedSource)
					{
						text2 = Struct28.smethod_5(num11, xFormat, xValueIsCulture);
						tickLabelFontColor2 = Struct28.smethod_6(num11, xFormat, tickLabelFontColor2);
					}
					else
					{
						text2 = smethod_34(num11, axisRenderContext);
						tickLabelFontColor2 = Struct28.smethod_6(num11, axisRenderContext.Axis.NumberFormat, tickLabelFontColor2);
					}
					RectangleF value2 = new RectangleF(num12 - axisRenderContext.float_1 / 2f, num, axisRenderContext.float_1, axisRenderContext.float_2);
					smethod_44(g, Rectangle.Round(value2), text2, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor2, Enum157.const_1, Enum157.const_1);
				}
				smethod_8(g, reversed, num12, top, plotAreaRect, axisRenderContext, renderContext);
			}
		}
		smethod_12(g, reversed, top, plotAreaRect.X, plotAreaRect.Right, plotAreaRect, axisRenderContext, renderContext);
		displayUnitInternal.method_0();
	}

	internal static void smethod_19(Class783 axisRenderContext, Interface32 g, Class757 nSeries, Rectangle rect)
	{
		if (Struct41.smethod_21(rect) || axisRenderContext.Axis == null || !axisRenderContext.Axis.IsVisible || axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.None)
		{
			return;
		}
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		List<Interface8> list = ((axisRenderContext.AxisType == Enum160.const_0) ? chart.NSeriesInternal.CategoryLabelsInternal : chart.NSeriesInternal.Category2LabelsInternal);
		float num = axisRenderContext.TickLabelsOffsetPixel;
		int num2 = Struct24.smethod_23(nSeries.ListSeries);
		double num3 = Math.PI * 2.0 / (double)num2;
		double num4 = (double)rect.X + (double)rect.Width / 2.0;
		double num5 = (double)rect.Y + (double)rect.Height / 2.0;
		double num6 = Math.PI / 2.0 + num3;
		double num7 = rect.Width / 2;
		for (int i = 0; i < num2; i++)
		{
			num6 -= num3;
			string text = "";
			Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
			SizeF layoutArea = new SizeF(axisRenderContext.float_1, axisRenderContext.float_2);
			if (axisRenderContext.IsLinkedSource && list.Count > 0)
			{
				string text2 = "";
				bool flag = false;
				text2 = ((i < list.Count) ? ((Class743)list[i]).SourceFormat : "");
				flag = i < list.Count && ((Class743)list[i]).IsCulture;
				text = Struct28.smethod_5(axisRenderContext.arrayList_0[i], text2, flag);
				tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], text2, tickLabelFontColor);
			}
			else
			{
				text = smethod_34(axisRenderContext.arrayList_0[i], axisRenderContext);
				tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
			}
			Font tickLabelTextFont = axisRenderContext.TickLabelTextFont;
			int tickLableRotation = axisRenderContext.TickLableRotation;
			Size size = Struct39.smethod_3(g, text, tickLableRotation, tickLabelTextFont, layoutArea, Enum157.const_1, Enum157.const_1);
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
			Rectangle rect2 = new Rectangle((int)num8, (int)num9, size.Width, size.Height);
			smethod_44(g, rect2, text, tickLableRotation, tickLabelTextFont, tickLabelFontColor, Enum157.const_1, Enum157.const_1);
		}
	}

	internal static void smethod_20(Class783 axisRenderContext, Interface32 g, Class757 nSeries, Rectangle rect)
	{
		if (Struct41.smethod_21(rect) || axisRenderContext.Axis == null || !axisRenderContext.Axis.IsVisible)
		{
			return;
		}
		Class759 @class = nSeries.method_0(0);
		Class748 class2 = @class.PointsInternal.method_0(0);
		int num = Struct24.smethod_23(nSeries.ListSeries);
		double num2 = Math.PI * 2.0 / (double)num;
		double num3 = (double)rect.X + (double)rect.Width / 2.0;
		double num4 = (double)rect.Y + (double)rect.Height / 2.0;
		PointF pointF = new PointF((float)num3, (float)num4);
		double num5 = Math.PI / 2.0 + num2;
		double num6 = rect.Width / 2;
		for (int i = 0; i < num; i++)
		{
			num5 -= num2;
			float x = (float)(num3 + num6 * Math.Cos(num5));
			float y = (float)(num4 - num6 * Math.Sin(num5));
			axisRenderContext.method_3(x, y, pointF.X, pointF.Y);
		}
		double num7 = 0.0;
		axisRenderContext.arrayList_0.Sort();
		double logMaxValue = axisRenderContext.LogMaxValue;
		double logMinValue = axisRenderContext.LogMinValue;
		double num8 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MajorUnit) : axisRenderContext.MajorUnit);
		ArrayList arrayList_ = axisRenderContext.arrayList_0;
		if (axisRenderContext.Axis == null || !axisRenderContext.Axis.IsVisible || axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.None)
		{
			return;
		}
		for (int j = 0; j < axisRenderContext.arrayList_0.Count; j++)
		{
			double num9 = (double)arrayList_[j];
			double num10 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_1(num9) : num9);
			if (j - 1 > 0)
			{
				if (Math.Abs(Struct41.smethod_11(num9, (double)arrayList_[j - 1])) != num8)
				{
					continue;
				}
			}
			else if (j + 1 < arrayList_.Count && Math.Abs(Struct41.smethod_11(num9, (double)arrayList_[j + 1])) != num8)
			{
				continue;
			}
			num7 = Math.Abs(num9 - logMinValue);
			double num11 = num6 * num7 / (logMaxValue - logMinValue);
			double num12 = num3 + num11 * Math.Cos(Math.PI / 2.0);
			double num13 = num4 - num11 * Math.Sin(Math.PI / 2.0);
			string text = smethod_34(num10, axisRenderContext);
			Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
			tickLabelFontColor = Struct28.smethod_6(num10, axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
			if (axisRenderContext.IsLinkedSource)
			{
				text = Struct28.smethod_5(num10, class2.YFormat, class2.YValueIsCulture);
				tickLabelFontColor = Struct28.smethod_6(num10, class2.YFormat, tickLabelFontColor);
			}
			Font tickLabelTextFont = axisRenderContext.TickLabelTextFont;
			int tickLableRotation = axisRenderContext.TickLableRotation;
			Size size = Struct39.smethod_2(g, text, tickLableRotation, tickLabelTextFont, rect.Size, Enum157.const_1, Enum157.const_1);
			num12 = num12 - (double)size.Width - (double)axisRenderContext.ChartRenderContext.Chart2007.Width * 0.011;
			num13 -= (double)(size.Height / 2);
			Rectangle rect2 = new Rectangle((int)num12, (int)num13, size.Width, size.Height);
			smethod_44(g, rect2, text, tickLableRotation, tickLabelTextFont, tickLabelFontColor, Enum157.const_1, Enum157.const_1);
		}
	}

	internal static Size smethod_21(Class783 axisRenderContext, Interface32 g, Class759 firstSeries, bool isDisplayAxisSameAsBar)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if (axisRenderContext.Axis != null && axisRenderContext.Axis.IsVisible && axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None && !chart.PlotAreaInternal.method_16())
		{
			Class748 @class = firstSeries.PointsInternal.method_0(0);
			ChartType resembleType = firstSeries.ResembleType;
			string format = @class.YFormat;
			bool yValueIsCulture = @class.YValueIsCulture;
			int num = 0;
			int num2 = 0;
			ArrayList arrayList_ = axisRenderContext.arrayList_0;
			double num3 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MajorUnit) : axisRenderContext.MajorUnit);
			double num4 = 1E-10;
			for (int i = 0; i < axisRenderContext.arrayList_0.Count; i++)
			{
				double num5 = (double)arrayList_[i];
				double num6 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_1(num5) : num5);
				if (i - 1 > 0)
				{
					if (Math.Abs(Struct41.smethod_11(num3, Math.Abs(Struct41.smethod_11(num5, (double)arrayList_[i - 1])))) / num3 > 10000000000.0)
					{
						continue;
					}
				}
				else if (i + 1 < arrayList_.Count && Math.Abs(Struct41.smethod_11(num3, Math.Abs(Struct41.smethod_11(num5, (double)arrayList_[i + 1])))) / num4 > 10000000000.0)
				{
					continue;
				}
				if (Struct24.smethod_42(resembleType))
				{
					num6 /= 100.0;
					format = "0%";
				}
				num6 = (axisRenderContext.Axis.IsLogarithmic ? num6 : (num6 * smethod_22(axisRenderContext)));
				string text = (axisRenderContext.IsLinkedSource ? Struct28.smethod_5(num6, format, yValueIsCulture) : smethod_34(num6, axisRenderContext));
				Size size = Struct39.smethod_2(g, text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, chart.PlotAreaInternal.rectangle_1.Size, Enum157.const_1, Enum157.const_1);
				if (size.Width > num)
				{
					num = size.Width;
				}
				if (size.Height > num2)
				{
					num2 = size.Height;
				}
			}
			float num7 = smethod_0(axisRenderContext.TickLabelTextFont.Size);
			if (isDisplayAxisSameAsBar)
			{
				num2 += (int)((double)(2f * num7) + 0.5);
			}
			else
			{
				num += (int)((double)(2f * num7) + 0.5);
			}
			axisRenderContext.float_1 = num;
			axisRenderContext.float_2 = num2;
			return new Size(num, num2);
		}
		return new Size(0, 0);
	}

	internal static double smethod_22(Class783 axisRenderContext)
	{
		int num = 0;
		if (axisRenderContext.Axis != null)
		{
			num = (int)((axisRenderContext.Axis.DisplayUnit != 0) ? (axisRenderContext.Axis.DisplayUnit + 1) : DisplayUnitType.None);
		}
		return Math.Pow(10.0, -num);
	}

	internal static Size smethod_23(Class783 axisRenderContext, Interface32 g, Rectangle rect, int maxPointsCount, bool isDisplayAxisSameAsBar, Class759 firstSeries)
	{
		if (axisRenderContext.Axis != null && axisRenderContext.Axis.IsVisible && axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None && !Struct41.smethod_21(rect))
		{
			if (isDisplayAxisSameAsBar && axisRenderContext.TickLabelAutoRotation)
			{
				axisRenderContext.TickLabelAutoRotation = false;
			}
			if (axisRenderContext.TickLabelAutoRotation)
			{
				return smethod_24(axisRenderContext, g, rect, maxPointsCount, isDisplayAxisSameAsBar, firstSeries);
			}
			if (axisRenderContext.TickLableRotation != 0 && axisRenderContext.TickLableRotation != 90 && axisRenderContext.TickLableRotation != -90)
			{
				return smethod_26(axisRenderContext, g, rect, maxPointsCount, isDisplayAxisSameAsBar, firstSeries);
			}
			return smethod_25(axisRenderContext, g, rect, maxPointsCount, isDisplayAxisSameAsBar, firstSeries);
		}
		return new Size(0, 0);
	}

	private static Size smethod_24(Class783 axisRenderContext, Interface32 g, Rectangle rect, int maxPointsCount, bool isDisplayAxisSameAsBar, Class759 firstSeries)
	{
		bool flag = false;
		if (axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			flag = true;
			axisRenderContext.IsAutoTickLabelSpacing = false;
			axisRenderContext.TickLabelSpacing = 1;
		}
		ArrayList arrayList = (ArrayList)axisRenderContext.arrayList_0.Clone();
		if (axisRenderContext.Axis.IsLogarithmic)
		{
			for (int i = 0; i < arrayList.Count; i++)
			{
				arrayList[i] = axisRenderContext.method_1(Convert.ToDouble(arrayList[i]));
			}
		}
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		bool flag2 = false;
		List<Interface8> list;
		List<Interface8>[] array;
		if (axisRenderContext.AxisType == Enum160.const_0)
		{
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			array = chart.NSeriesInternal.Categories;
			flag2 = chart.NSeriesInternal.bool_0;
		}
		else
		{
			list = chart.NSeriesInternal.Category2LabelsInternal;
			array = chart.NSeriesInternal.Categories2;
			flag2 = chart.NSeriesInternal.bool_1;
		}
		bool flag3 = array != null && array.Length > 0;
		int num = smethod_27(axisRenderContext);
		int num2 = 300;
		string xFormat = firstSeries.PointsInternal[0].XFormat;
		bool xValueIsCulture = firstSeries.PointsInternal[0].XValueIsCulture;
		string text = "";
		bool flag4 = false;
		bool flag5 = false;
		if (firstSeries.ResembleType == ChartType.ScatterWithMarkers || firstSeries.ResembleType == ChartType.Bubble)
		{
			flag5 = axisRenderContext.IsLinkedSource;
		}
		SizeF layoutArea = new SizeF(0f, 0f);
		int num3 = 0;
		if (!flag)
		{
			if (!axisRenderContext.AxisBetweenCategories && !axisRenderContext.ChartRenderContext.Chart.HasDataTable)
			{
				num3 = maxPointsCount - 1;
				if (num3 == 0)
				{
					num3 = 1;
				}
			}
			else
			{
				num3 = maxPointsCount;
			}
		}
		else
		{
			num3 = arrayList.Count;
		}
		int num4 = 1;
		if (!firstSeries.IsXValueSeries)
		{
			if (isDisplayAxisSameAsBar)
			{
				if ((float)rect.Height / (float)num3 < 1f)
				{
					float num5 = (float)rect.Height / (float)num3 * 10f;
					num4 *= 10;
					if (num5 < 1f)
					{
						num4 *= 10;
					}
				}
			}
			else if ((float)rect.Width / (float)num3 < 1f)
			{
				float num6 = (float)rect.Width / (float)num3 * 10f;
				num4 *= 10;
				if (num6 < 1f)
				{
					num4 *= 10;
				}
			}
		}
		int num7 = 0;
		int num8 = 0;
		float num9 = 0.5f;
		int num10 = 0;
		int num11 = 0;
		float num12 = 0f;
		bool flag6 = false;
		bool flag7 = axisRenderContext.ChartRenderContext.Chart2007.Is3DChart();
		Size size = Struct39.smethod_10(g, "a", axisRenderContext.TickLabelTextFont);
		int num13 = 0;
		float[,] array2 = new float[arrayList.Count, 2];
		Size[] array3 = new Size[arrayList.Count];
		string[] array4 = new string[arrayList.Count];
		int num14;
		int num15;
		while (true)
		{
			num14 = 0;
			num15 = 0;
			num7 = 0;
			num8 = 0;
			float num16 = 0f;
			if (!firstSeries.IsXValueSeries)
			{
				if (isDisplayAxisSameAsBar)
				{
					layoutArea.Height = (float)rect.Height / (float)num3 * (float)axisRenderContext.TickLabelSpacing;
					layoutArea.Width = (float)rect.Width * num9;
					if (axisRenderContext.IsAutoTickLabelSpacing)
					{
						if (Math.Abs(axisRenderContext.TickLableRotation) == 0 && axisRenderContext.TickLabelSpacing < num3)
						{
							if (layoutArea.Height < (float)size.Height)
							{
								axisRenderContext.TickLabelSpacing += num4;
								continue;
							}
						}
						else if (Math.Abs(axisRenderContext.TickLableRotation) == 90 && layoutArea.Height < (float)size.Width && axisRenderContext.TickLabelSpacing < num3)
						{
							axisRenderContext.TickLabelSpacing += num4;
							continue;
						}
					}
					num16 = layoutArea.Height;
				}
				else
				{
					if (num > axisRenderContext.TickLabelSpacing)
					{
						layoutArea.Width = (float)rect.Width / (float)num3 * (float)num;
					}
					else
					{
						layoutArea.Width = (float)rect.Width / (float)num3 * (float)axisRenderContext.TickLabelSpacing;
					}
					layoutArea.Height = (float)rect.Height * num9;
					if (axisRenderContext.IsAutoTickLabelSpacing)
					{
						if (Math.Abs(axisRenderContext.TickLableRotation) == 0)
						{
							if (layoutArea.Width < (float)size.Width)
							{
								axisRenderContext.TickLabelSpacing += num4;
								continue;
							}
						}
						else if (Math.Abs(axisRenderContext.TickLableRotation) == 90 && layoutArea.Width < (float)size.Height)
						{
							axisRenderContext.TickLabelSpacing += num4;
							if (!flag3)
							{
								axisRenderContext.TickLableRotation = 45;
							}
							continue;
						}
					}
					num16 = layoutArea.Width;
				}
			}
			else
			{
				SizeF sizeF = Struct39.smethod_21(g, "3", axisRenderContext.TickLabelTextFont);
				if (isDisplayAxisSameAsBar)
				{
					layoutArea.Height = (float)rect.Height / (float)arrayList.Count;
					layoutArea.Width = (float)rect.Width * num9;
					layoutArea.Height += Struct41.smethod_3(sizeF.Height);
					num16 = layoutArea.Height;
				}
				else
				{
					layoutArea.Width = (float)rect.Width / (float)arrayList.Count;
					layoutArea.Height = (float)rect.Height * num9;
					layoutArea.Width += Struct41.smethod_3(sizeF.Width);
					num16 = layoutArea.Width;
				}
			}
			float num17 = 0f;
			if (axisRenderContext.TickLableRotation == 45)
			{
				num17 = (firstSeries.IsXValueSeries ? ((!isDisplayAxisSameAsBar) ? ((float)(rect.Width / arrayList.Count)) : ((float)(rect.Height / arrayList.Count))) : ((!isDisplayAxisSameAsBar) ? ((float)(rect.Width / num3)) : ((float)(rect.Height / num3))));
			}
			float num18 = 0f;
			float num19 = 0f;
			for (int j = 0; j < arrayList.Count; j++)
			{
				if (axisRenderContext.TickLableRotation == 45)
				{
					int num20 = arrayList.Count - 1 - j;
					if (isDisplayAxisSameAsBar)
					{
						if (axisRenderContext.Axis.IsPlotOrderReversed)
						{
							if (axisRenderContext.TickLableRotation > 0)
							{
								layoutArea.Width = (float)rect.Width * num9;
								layoutArea.Height = (float)rect.Height - (float)j * num17 - num17 / 2f;
							}
							else
							{
								layoutArea.Width = (float)rect.Width * num9;
								layoutArea.Height = (float)rect.Height - (float)num20 * num17 - num17 / 2f;
							}
						}
						else if (axisRenderContext.TickLableRotation > 0)
						{
							layoutArea.Width = (float)rect.Width * num9;
							layoutArea.Height = (float)rect.Height - (float)num20 * num17 - num17 / 2f;
						}
						else
						{
							layoutArea.Width = (float)rect.Width * num9;
							layoutArea.Height = (float)rect.Height - (float)j * num17 - num17 / 2f;
						}
					}
					else if (axisRenderContext.Axis.IsPlotOrderReversed)
					{
						if (axisRenderContext.TickLableRotation > 0)
						{
							layoutArea.Width = (float)rect.Width - (float)j * num17 - num17 / 2f;
							layoutArea.Height = (float)rect.Height * num9;
						}
						else
						{
							layoutArea.Width = (float)rect.Width - (float)num20 * num17 - num17 / 2f;
							layoutArea.Height = (float)rect.Height * num9;
						}
					}
					else if (axisRenderContext.TickLableRotation > 0)
					{
						layoutArea.Width = (float)rect.Width - (float)num20 * num17 - num17 / 2f;
						layoutArea.Height = (float)rect.Height * num9;
					}
					else
					{
						layoutArea.Width = (float)rect.Width - (float)j * num17 - num17 / 2f;
						layoutArea.Height = (float)rect.Height * num9;
					}
					if (layoutArea.Width < (float)rect.Width * num9)
					{
						layoutArea.Width = (float)rect.Width * num9;
					}
					if (layoutArea.Height < (float)rect.Height * num9)
					{
						layoutArea.Height = (float)rect.Height * num9;
					}
				}
				if (j == 0 && num13 <= 0)
				{
					axisRenderContext.TickLabelsOffsetPixel = size.Width * axisRenderContext.TickLabelsOffset / num2;
				}
				string text2;
				if (num13 <= 0)
				{
					text2 = "";
					if (flag5)
					{
						text = ((j < list.Count) ? ((Class743)list[j]).SourceFormat : "");
						flag4 = j < list.Count && ((Class743)list[j]).IsCulture;
						text2 = ((firstSeries.ResembleType == ChartType.ScatterWithMarkers || firstSeries.ResembleType == ChartType.Bubble) ? Struct28.smethod_5((double)arrayList[j] * smethod_22(axisRenderContext), xFormat, xValueIsCulture) : Struct28.smethod_5(arrayList[j], text, flag4));
					}
					else
					{
						text2 = smethod_34(arrayList[j], axisRenderContext);
					}
					array4[j] = text2;
				}
				else
				{
					text2 = array4[j];
				}
				float num21;
				float num22;
				if (num13 <= 0)
				{
					num21 = Struct39.smethod_19(g, text2, axisRenderContext.TickLabelTextFont, !flag7);
					num22 = Struct39.smethod_14(g, text2, axisRenderContext.TickLabelTextFont).Width;
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
				if (flag2)
				{
					size2 = Struct39.smethod_3(g, text2, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, layoutArea, Enum157.const_1, Enum157.const_1);
				}
				else if (num13 <= 0)
				{
					size2 = Struct39.smethod_10(g, text2, axisRenderContext.TickLabelTextFont);
					array3[j] = size2;
				}
				else
				{
					size2 = array3[j];
				}
				if (size2.Width > num14)
				{
					num14 = size2.Width;
				}
				if (size2.Height > num15)
				{
					num15 = size2.Height;
				}
				if (j == 0)
				{
					num7 = ((!isDisplayAxisSameAsBar) ? ((axisRenderContext.TickLableRotation == 45) ? ((int)((double)size2.Width - (double)num17 * 0.6)) : ((int)((double)size2.Width * 0.65))) : (size2.Height / 2));
				}
				if (j == arrayList.Count - 1)
				{
					num8 = ((!isDisplayAxisSameAsBar) ? (size2.Width / 2) : (size2.Height / 2));
				}
			}
			num13++;
			axisRenderContext.float_3 = num15;
			axisRenderContext.float_4 = num14;
			if (flag2 && num18 > num16)
			{
				if (isDisplayAxisSameAsBar)
				{
					if (axisRenderContext.TickLableRotation == 0 && (float)num15 > (float)size.Height * 1.5f)
					{
						axisRenderContext.TickLableRotation = 45;
						continue;
					}
					if (axisRenderContext.TickLableRotation == 45)
					{
						double num23 = (double)Math.Abs(axisRenderContext.TickLableRotation) / 180.0 * Math.PI;
						double num24 = (double)num19 * Math.Cos(num23) + (double)size.Height * Math.Sin(num23);
						if (num24 > (double)num14)
						{
							axisRenderContext.TickLableRotation = 90;
							continue;
						}
					}
				}
				else if (!flag3)
				{
					if (axisRenderContext.TickLableRotation == 0 && (float)num15 > (float)size.Height * 1.5f)
					{
						if ((double)num16 <= (double)size.Height * 1.4)
						{
							axisRenderContext.TickLableRotation = 90;
						}
						else
						{
							axisRenderContext.TickLableRotation = 45;
						}
						continue;
					}
					if (axisRenderContext.TickLableRotation == 45 && (double)num16 <= (double)size.Height * 1.4)
					{
						axisRenderContext.TickLableRotation = 90;
						continue;
					}
				}
				else if (axisRenderContext.TickLableRotation != 90)
				{
					axisRenderContext.TickLableRotation = 90;
					continue;
				}
			}
			else if (isDisplayAxisSameAsBar)
			{
				if ((double)(layoutArea.Height / (float)num15) > 2.5 && (double)num9 > 0.2 && (double)layoutArea.Width * 0.8 > (double)num18)
				{
					num9 *= 0.8f;
					continue;
				}
			}
			else if (layoutArea.Width / (float)num14 > 2f && (double)num9 > 0.3)
			{
				num9 = num9 * 4f / 5f;
				continue;
			}
			if (!axisRenderContext.IsAutoTickLabelSpacing || flag6)
			{
				break;
			}
			if (isDisplayAxisSameAsBar)
			{
				if ((num14 != num10 || num15 != num11 || num12 != layoutArea.Height) && (float)num15 > layoutArea.Height - 5f && axisRenderContext.TickLabelSpacing < num3)
				{
					num10 = num14;
					num11 = num15;
					num12 = layoutArea.Height;
					axisRenderContext.TickLabelSpacing += num4;
					continue;
				}
				if (axisRenderContext.TickLabelSpacing <= 1)
				{
					break;
				}
				axisRenderContext.TickLabelSpacing -= num4;
				if (axisRenderContext.TickLabelSpacing < 1)
				{
					axisRenderContext.TickLabelSpacing = 1;
				}
				flag6 = true;
			}
			else if ((num14 != num10 || num15 != num11 || num12 != layoutArea.Width) && (float)num14 > layoutArea.Width - 5f && axisRenderContext.TickLabelSpacing < num3)
			{
				num10 = num14;
				num11 = num15;
				num12 = layoutArea.Width;
				axisRenderContext.TickLabelSpacing += num4;
			}
			else
			{
				if (axisRenderContext.TickLabelSpacing <= 1)
				{
					break;
				}
				axisRenderContext.TickLabelSpacing -= num4;
				if (axisRenderContext.TickLabelSpacing < 1)
				{
					axisRenderContext.TickLabelSpacing = 1;
				}
				flag6 = true;
			}
		}
		if (axisRenderContext.Axis.IsPlotOrderReversed)
		{
			int num25 = num7;
			num7 = num8;
			num8 = num25;
		}
		if (array != null && array.Length > 0 && list.Count > 0)
		{
			axisRenderContext.TickLabelSpacing = 1;
			int rotation = 0;
			if (isDisplayAxisSameAsBar)
			{
				rotation = 90;
			}
			foreach (IList list2 in array)
			{
				if (isDisplayAxisSameAsBar)
				{
					layoutArea.Height = rect.Height / list2.Count;
					layoutArea.Width = (float)rect.Width * 0.5f;
				}
				else
				{
					layoutArea.Width = rect.Width / list2.Count;
					layoutArea.Height = (float)rect.Height * 0.5f;
				}
				Size size3 = smethod_30(g, list2, rotation, layoutArea, axisRenderContext);
				if (isDisplayAxisSameAsBar)
				{
					num14 += size3.Width;
				}
				else
				{
					num15 += size3.Height;
				}
			}
		}
		axisRenderContext.float_1 = num14;
		axisRenderContext.float_2 = num15;
		if (smethod_28(axisRenderContext, firstSeries))
		{
			if (isDisplayAxisSameAsBar)
			{
				axisRenderContext.float_5 = (float)num15 / 2f;
			}
			else
			{
				axisRenderContext.float_5 = (float)num14 / 2f;
			}
			axisRenderContext.float_6 = axisRenderContext.float_5;
		}
		else if (smethod_29(axisRenderContext, firstSeries))
		{
			axisRenderContext.float_5 = num7;
			axisRenderContext.float_6 = num8;
		}
		return new Size(num14, num15);
	}

	private static Size smethod_25(Class783 axisRenderContext, Interface32 g, Rectangle rect, int maxPointsCount, bool isDisplayAxisSameAsBar, Class759 firstSeries)
	{
		bool flag = false;
		if (axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			flag = true;
			axisRenderContext.IsAutoTickLabelSpacing = false;
			axisRenderContext.TickLabelSpacing = 1;
		}
		ArrayList arrayList = (ArrayList)axisRenderContext.arrayList_0.Clone();
		if (axisRenderContext.Axis.IsLogarithmic)
		{
			for (int i = 0; i < arrayList.Count; i++)
			{
				arrayList[i] = axisRenderContext.method_1(Convert.ToDouble(arrayList[i]));
			}
		}
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		List<Interface8> list;
		List<Interface8>[] array;
		if (axisRenderContext.AxisType == Enum160.const_0)
		{
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			array = chart.NSeriesInternal.Categories;
		}
		else
		{
			list = chart.NSeriesInternal.Category2LabelsInternal;
			array = chart.NSeriesInternal.Categories2;
		}
		int num = smethod_27(axisRenderContext);
		int num2 = 300;
		string xFormat = firstSeries.PointsInternal[0].XFormat;
		bool xValueIsCulture = firstSeries.PointsInternal[0].XValueIsCulture;
		string text = "";
		bool flag2 = false;
		bool flag3 = false;
		if (firstSeries.ResembleType != ChartType.ScatterWithMarkers && firstSeries.ResembleType != ChartType.Bubble)
		{
			if (axisRenderContext.Axis.IsNumberFormatLinkedToSource && list.Count > 0)
			{
				flag3 = true;
			}
			if (array != null && array.Length > 0 && list.Count > 0)
			{
				flag3 = true;
			}
		}
		else
		{
			flag3 = axisRenderContext.IsLinkedSource;
		}
		SizeF layoutArea = new SizeF(0f, 0f);
		int num3 = 0;
		if (!flag)
		{
			if (!axisRenderContext.AxisBetweenCategories && !axisRenderContext.ChartRenderContext.Chart.HasDataTable)
			{
				num3 = maxPointsCount - 1;
				if (num3 == 0)
				{
					num3 = 1;
				}
			}
			else
			{
				num3 = maxPointsCount;
			}
		}
		else
		{
			num3 = arrayList.Count;
		}
		int num4 = 1;
		if (!firstSeries.IsXValueSeries)
		{
			if (isDisplayAxisSameAsBar)
			{
				if ((float)rect.Height / (float)num3 < 1f)
				{
					float num5 = (float)rect.Height / (float)num3 * 10f;
					num4 *= 10;
					if (num5 < 1f)
					{
						num5 = (float)rect.Width / (float)num3 * 10f;
						num4 *= 10;
					}
				}
			}
			else if ((float)rect.Width / (float)num3 < 1f)
			{
				float num6 = (float)rect.Width / (float)num3 * 10f;
				num4 *= 10;
				if (num6 < 1f)
				{
					num4 *= 10;
				}
			}
		}
		int num7 = 0;
		int num8 = 0;
		float num9 = 0.5f;
		int num10 = 0;
		int num11 = 0;
		bool flag4 = false;
		Size size = Struct39.smethod_10(g, "a", axisRenderContext.TickLabelTextFont);
		int num12 = 0;
		string[] array2 = new string[arrayList.Count];
		int num13;
		int num14;
		while (true)
		{
			num13 = 0;
			num14 = 0;
			num7 = 0;
			num8 = 0;
			if (!firstSeries.IsXValueSeries)
			{
				if (isDisplayAxisSameAsBar)
				{
					layoutArea.Height = (float)rect.Height / (float)num3 * (float)axisRenderContext.TickLabelSpacing;
					layoutArea.Width = (float)rect.Width * num9;
					if (axisRenderContext.IsAutoTickLabelSpacing)
					{
						if (Math.Abs(axisRenderContext.TickLableRotation) == 0 && axisRenderContext.TickLabelSpacing < num3)
						{
							if (layoutArea.Height < (float)size.Height)
							{
								axisRenderContext.TickLabelSpacing += num4;
								continue;
							}
						}
						else if (Math.Abs(axisRenderContext.TickLableRotation) == 90 && layoutArea.Height < (float)size.Width && axisRenderContext.TickLabelSpacing < num3)
						{
							axisRenderContext.TickLabelSpacing += num4;
							continue;
						}
					}
				}
				else
				{
					if (num > axisRenderContext.TickLabelSpacing)
					{
						layoutArea.Width = (float)rect.Width / (float)num3 * (float)num;
					}
					else
					{
						layoutArea.Width = (float)rect.Width / (float)num3 * (float)axisRenderContext.TickLabelSpacing;
					}
					layoutArea.Height = (float)rect.Height * num9;
					if (axisRenderContext.IsAutoTickLabelSpacing)
					{
						if (Math.Abs(axisRenderContext.TickLableRotation) == 0)
						{
							if (layoutArea.Width < (float)size.Width)
							{
								axisRenderContext.TickLabelSpacing += num4;
								continue;
							}
						}
						else if (Math.Abs(axisRenderContext.TickLableRotation) == 90 && layoutArea.Width < (float)size.Height)
						{
							axisRenderContext.TickLabelSpacing += num4;
							continue;
						}
					}
				}
			}
			else
			{
				SizeF sizeF = Struct39.smethod_21(g, "3", axisRenderContext.TickLabelTextFont);
				if (isDisplayAxisSameAsBar)
				{
					layoutArea.Height = (float)rect.Height / (float)arrayList.Count;
					layoutArea.Width = (float)rect.Width * num9;
					layoutArea.Height += Struct41.smethod_3(sizeF.Height);
				}
				else
				{
					layoutArea.Width = (float)rect.Width / (float)arrayList.Count;
					layoutArea.Height = (float)rect.Height * num9;
					layoutArea.Width += Struct41.smethod_3(sizeF.Width);
				}
			}
			for (int j = 0; j < arrayList.Count; j += axisRenderContext.TickLabelSpacing)
			{
				if (j == 0 && num12 <= 0)
				{
					if (axisRenderContext.TickLableRotation == 0)
					{
						axisRenderContext.TickLabelsOffsetPixel = Struct41.smethod_5(size.Width * axisRenderContext.TickLabelsOffset / num2);
					}
					else
					{
						axisRenderContext.TickLabelsOffsetPixel = 0;
					}
				}
				string text2;
				if (num12 <= 0)
				{
					text2 = "";
					if (flag3)
					{
						text = ((j < list.Count) ? ((Class743)list[j]).SourceFormat : "");
						flag2 = j < list.Count && ((Class743)list[j]).IsCulture;
						text2 = ((!firstSeries.IsXValueSeries) ? Struct28.smethod_5(arrayList[j], text, flag2) : Struct28.smethod_5((double)arrayList[j] * smethod_22(axisRenderContext), xFormat, xValueIsCulture));
					}
					else
					{
						text2 = smethod_34(arrayList[j], axisRenderContext);
					}
					array2[j] = text2;
				}
				else
				{
					text2 = array2[j];
				}
				Size size2 = Struct39.smethod_3(g, text2, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, layoutArea, Enum157.const_1, Enum157.const_1);
				if (size2.Width > num13)
				{
					num13 = size2.Width;
				}
				if (size2.Height > num14)
				{
					num14 = size2.Height;
				}
				if (j == 0)
				{
					num7 = ((!isDisplayAxisSameAsBar) ? (size2.Width / 2) : (size2.Height / 2));
				}
				if (j == arrayList.Count - 1)
				{
					num8 = ((!isDisplayAxisSameAsBar) ? (size2.Width / 2) : (size2.Height / 2));
				}
			}
			num12++;
			axisRenderContext.float_3 = num14;
			axisRenderContext.float_4 = num13;
			if (isDisplayAxisSameAsBar)
			{
				if ((double)(layoutArea.Height / (float)num14) > 2.5 && (double)num9 > 0.2)
				{
					num9 *= 0.8f;
					continue;
				}
			}
			else if (axisRenderContext.TickLableRotation != 0 && (float)num14 <= (float)rect.Height * num9)
			{
				layoutArea.Height = rect.Height - num14;
			}
			else if (layoutArea.Width / (float)num13 > 2f && (double)num9 > 0.3)
			{
				num9 = num9 * 4f / 5f;
				continue;
			}
			if (!axisRenderContext.IsAutoTickLabelSpacing || flag4)
			{
				break;
			}
			if (isDisplayAxisSameAsBar)
			{
				if ((num13 != num10 || num14 != num11) && (float)num14 > layoutArea.Height - 5f && axisRenderContext.TickLabelSpacing < num3)
				{
					num10 = num13;
					num11 = num14;
					axisRenderContext.TickLabelSpacing += num4;
					continue;
				}
				if (axisRenderContext.TickLabelSpacing <= 1)
				{
					break;
				}
				axisRenderContext.TickLabelSpacing -= num4;
				if (axisRenderContext.TickLabelSpacing < 1)
				{
					axisRenderContext.TickLabelSpacing = 1;
				}
				flag4 = true;
			}
			else if ((num13 != num10 || num14 != num11) && (float)num13 > layoutArea.Width - 5f && axisRenderContext.TickLabelSpacing < num3)
			{
				num10 = num13;
				num11 = num14;
				axisRenderContext.TickLabelSpacing += num4;
			}
			else
			{
				if (axisRenderContext.TickLabelSpacing <= 1)
				{
					break;
				}
				axisRenderContext.TickLabelSpacing -= num4;
				if (axisRenderContext.TickLabelSpacing < 1)
				{
					axisRenderContext.TickLabelSpacing = 1;
				}
				flag4 = true;
			}
		}
		if (axisRenderContext.Axis.IsPlotOrderReversed)
		{
			int num15 = num7;
			num7 = num8;
			num8 = num15;
		}
		if (array != null && array.Length > 0 && list.Count > 0)
		{
			axisRenderContext.TickLabelSpacing = 1;
			int rotation = 0;
			if (isDisplayAxisSameAsBar)
			{
				rotation = 90;
			}
			foreach (IList list2 in array)
			{
				if (isDisplayAxisSameAsBar)
				{
					layoutArea.Height = rect.Height / list2.Count;
					layoutArea.Width = (float)rect.Width * 0.5f;
				}
				else
				{
					layoutArea.Width = rect.Width / list2.Count;
					layoutArea.Height = (float)rect.Height * 0.5f;
				}
				Size size3 = smethod_30(g, list2, rotation, layoutArea, axisRenderContext);
				if (isDisplayAxisSameAsBar)
				{
					num13 += size3.Width;
				}
				else
				{
					num14 += size3.Height;
				}
			}
		}
		axisRenderContext.float_1 = num13;
		axisRenderContext.float_2 = num14;
		if (smethod_28(axisRenderContext, firstSeries))
		{
			if (isDisplayAxisSameAsBar)
			{
				axisRenderContext.float_5 = (float)num14 / 2f;
			}
			else
			{
				axisRenderContext.float_5 = (float)num13 / 2f;
			}
			axisRenderContext.float_6 = axisRenderContext.float_5;
		}
		else if (smethod_29(axisRenderContext, firstSeries))
		{
			axisRenderContext.float_5 = num7;
			axisRenderContext.float_6 = num8;
		}
		return new Size(num13, num14);
	}

	private static Size smethod_26(Class783 axisRenderContext, Interface32 g, Rectangle rect, int maxPointsCount, bool isDisplayAxisSameAsBar, Class759 firstSeries)
	{
		bool flag = false;
		if (axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			flag = true;
			axisRenderContext.IsAutoTickLabelSpacing = false;
			axisRenderContext.TickLabelSpacing = 1;
		}
		ArrayList arrayList = (ArrayList)axisRenderContext.arrayList_0.Clone();
		if (axisRenderContext.Axis.IsLogarithmic)
		{
			for (int i = 0; i < arrayList.Count; i++)
			{
				arrayList[i] = axisRenderContext.method_1(Convert.ToDouble(arrayList[i]));
			}
		}
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		List<Interface8> list;
		List<Interface8>[] array;
		if (axisRenderContext.AxisType == Enum160.const_0)
		{
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			array = chart.NSeriesInternal.Categories;
		}
		else
		{
			list = chart.NSeriesInternal.Category2LabelsInternal;
			array = chart.NSeriesInternal.Categories2;
		}
		int num = 300;
		string xFormat = firstSeries.PointsInternal[0].XFormat;
		bool xValueIsCulture = firstSeries.PointsInternal[0].XValueIsCulture;
		string text = "";
		bool flag2 = false;
		bool flag3 = false;
		if (firstSeries.ResembleType != ChartType.ScatterWithMarkers && firstSeries.ResembleType != ChartType.Bubble)
		{
			if (axisRenderContext.Axis.IsNumberFormatLinkedToSource && list.Count > 0)
			{
				flag3 = true;
			}
			if (array != null && array.Length > 0 && list.Count > 0)
			{
				flag3 = true;
			}
		}
		else
		{
			flag3 = axisRenderContext.IsLinkedSource;
		}
		SizeF layoutArea = new SizeF(0f, 0f);
		int num2 = 0;
		if (!flag)
		{
			if (!axisRenderContext.AxisBetweenCategories && !axisRenderContext.ChartRenderContext.Chart.HasDataTable)
			{
				num2 = maxPointsCount - 1;
				if (num2 == 0)
				{
					num2 = 1;
				}
			}
			else
			{
				num2 = maxPointsCount;
			}
		}
		else
		{
			num2 = arrayList.Count;
		}
		if (!firstSeries.IsXValueSeries)
		{
			if (isDisplayAxisSameAsBar)
			{
				if ((float)rect.Height / (float)num2 < 1f)
				{
					_ = (float)rect.Height / (float)num2;
				}
			}
			else if ((float)rect.Width / (float)num2 < 1f)
			{
				_ = (float)rect.Width / (float)num2;
			}
		}
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		float num7 = 0.5f;
		float num8 = 0f;
		_ = arrayList.Count;
		if (!firstSeries.IsXValueSeries)
		{
			num8 = ((!isDisplayAxisSameAsBar) ? ((float)(rect.Width / num2 * axisRenderContext.TickLabelSpacing)) : ((float)(rect.Height / num2 * axisRenderContext.TickLabelSpacing)));
		}
		else
		{
			SizeF sizeF = Struct39.smethod_21(g, "3", axisRenderContext.TickLabelTextFont);
			if (isDisplayAxisSameAsBar)
			{
				num8 = rect.Height / arrayList.Count;
				num8 += sizeF.Height;
			}
			else
			{
				num8 = rect.Width / arrayList.Count;
				num8 += sizeF.Width;
			}
		}
		Size size = new Size(0, 0);
		for (int j = 0; j < arrayList.Count; j++)
		{
			int num9 = arrayList.Count - 1 - j;
			if (isDisplayAxisSameAsBar)
			{
				if (axisRenderContext.Axis.IsPlotOrderReversed)
				{
					if (axisRenderContext.TickLableRotation > 0)
					{
						layoutArea.Width = (float)rect.Width * num7;
						layoutArea.Height = (float)rect.Height - (float)j * num8 - num8 / 2f;
					}
					else
					{
						layoutArea.Width = (float)rect.Width * num7;
						layoutArea.Height = (float)rect.Height - (float)num9 * num8 - num8 / 2f;
					}
				}
				else if (axisRenderContext.TickLableRotation > 0)
				{
					layoutArea.Width = (float)rect.Width * num7;
					layoutArea.Height = (float)rect.Height - (float)num9 * num8 - num8 / 2f;
				}
				else
				{
					layoutArea.Width = (float)rect.Width * num7;
					layoutArea.Height = (float)rect.Height - (float)j * num8 - num8 / 2f;
				}
			}
			else if (axisRenderContext.Axis.IsPlotOrderReversed)
			{
				if (axisRenderContext.TickLableRotation > 0)
				{
					layoutArea.Width = (float)rect.Width - (float)j * num8 - num8 / 2f;
					layoutArea.Height = (float)rect.Height * num7;
				}
				else
				{
					layoutArea.Width = (float)rect.Width - (float)num9 * num8 - num8 / 2f;
					layoutArea.Height = (float)rect.Height * num7;
				}
			}
			else if (axisRenderContext.TickLableRotation > 0)
			{
				layoutArea.Width = (float)rect.Width - (float)num9 * num8 - num8 / 2f;
				layoutArea.Height = (float)rect.Height * num7;
			}
			else
			{
				layoutArea.Width = (float)rect.Width - (float)j * num8 - num8 / 2f;
				layoutArea.Height = (float)rect.Height * num7;
			}
			if (layoutArea.Width < (float)rect.Width * num7)
			{
				layoutArea.Width = (float)rect.Width * num7;
			}
			if (layoutArea.Height < (float)rect.Height * num7)
			{
				layoutArea.Height = (float)rect.Height * num7;
			}
			if (j == 0)
			{
				axisRenderContext.TickLabelsOffsetPixel = Struct39.smethod_10(g, "a", axisRenderContext.TickLabelTextFont).Width * axisRenderContext.TickLabelsOffset / num;
			}
			string text2 = "";
			if (flag3)
			{
				text = ((j < list.Count) ? ((Class743)list[j]).SourceFormat : "");
				flag2 = j < list.Count && ((Class743)list[j]).IsCulture;
				text2 = ((firstSeries.ResembleType == ChartType.ScatterWithMarkers || firstSeries.ResembleType == ChartType.Bubble) ? Struct28.smethod_5((double)arrayList[j] * smethod_22(axisRenderContext), xFormat, xValueIsCulture) : Struct28.smethod_5(arrayList[j], text, flag2));
			}
			else
			{
				text2 = smethod_34(arrayList[j], axisRenderContext);
			}
			Size size2 = Struct39.smethod_3(g, text2, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, layoutArea, Enum157.const_1, Enum157.const_1);
			if (size2.Width > num3)
			{
				num3 = size2.Width;
			}
			if (size2.Height > num4)
			{
				num4 = size2.Height;
			}
			int num10 = num3;
			if (isDisplayAxisSameAsBar)
			{
				num10 = num4;
			}
			switch (axisRenderContext.Axis.Position)
			{
			case AxisPositionType.Bottom:
			{
				if (axisRenderContext.Axis.IsPlotOrderReversed)
				{
					if (axisRenderContext.TickLableRotation > 0)
					{
						float num27 = (float)num9 * num8 + num8 / 2f;
						if ((float)num10 > num27)
						{
							float num28 = (float)num10 - num27;
							if (num28 > (float)num5)
							{
								num5 = (int)num28;
							}
						}
						break;
					}
					float num29 = (float)j * num8 + num8 / 2f;
					if ((float)num10 > num29)
					{
						float num30 = (float)num10 - num29;
						if (num30 > (float)num6)
						{
							num6 = (int)num30;
						}
					}
					break;
				}
				if (axisRenderContext.TickLableRotation > 0)
				{
					float num31 = (float)j * num8 + num8 / 2f;
					if ((float)num10 > num31)
					{
						float num32 = (float)num10 - num31;
						if (num32 > (float)num5)
						{
							num5 = (int)num32;
						}
					}
					break;
				}
				float num33 = (float)num9 * num8 + num8 / 2f;
				if ((float)num10 > num33)
				{
					float num34 = (float)num10 - num33;
					if (num34 > (float)num6)
					{
						num6 = (int)num34;
					}
				}
				break;
			}
			case AxisPositionType.Left:
			{
				if (axisRenderContext.Axis.IsPlotOrderReversed)
				{
					if (axisRenderContext.TickLableRotation > 0)
					{
						float num19 = (float)num9 * num8 + num8 / 2f;
						if ((float)num10 > num19)
						{
							float num20 = (float)num10 - num19;
							if (num20 > (float)num5)
							{
								num5 = (int)num20;
							}
						}
						break;
					}
					float num21 = (float)j * num8 + num8 / 2f;
					if ((float)num10 > num21)
					{
						float num22 = (float)num10 - num21;
						if (num22 > (float)num6)
						{
							num6 = (int)num22;
						}
					}
					break;
				}
				if (axisRenderContext.TickLableRotation > 0)
				{
					float num23 = (float)j * num8 + num8 / 2f;
					if ((float)num10 > num23)
					{
						float num24 = (float)num10 - num23;
						if (num24 > (float)num5)
						{
							num5 = (int)num24;
						}
					}
					break;
				}
				float num25 = (float)num9 * num8 + num8 / 2f;
				if ((float)num10 > num25)
				{
					float num26 = (float)num10 - num25;
					if (num26 > (float)num6)
					{
						num6 = (int)num26;
					}
				}
				break;
			}
			case AxisPositionType.Right:
			{
				if (axisRenderContext.Axis.IsPlotOrderReversed)
				{
					if (axisRenderContext.TickLableRotation < 0)
					{
						float num35 = (float)num9 * num8 + num8 / 2f;
						if ((float)num10 > num35)
						{
							float num36 = (float)num10 - num35;
							if (num36 > (float)num5)
							{
								num5 = (int)num36;
							}
						}
						break;
					}
					float num37 = (float)j * num8 + num8 / 2f;
					if ((float)num10 > num37)
					{
						float num38 = (float)num10 - num37;
						if (num38 > (float)num6)
						{
							num6 = (int)num38;
						}
					}
					break;
				}
				if (axisRenderContext.TickLableRotation < 0)
				{
					float num39 = (float)j * num8 + num8 / 2f;
					if ((float)num10 > num39)
					{
						float num40 = (float)num10 - num39;
						if (num40 > (float)num5)
						{
							num5 = (int)num40;
						}
					}
					break;
				}
				float num41 = (float)num9 * num8 + num8 / 2f;
				if ((float)num10 > num41)
				{
					float num42 = (float)num10 - num41;
					if (num42 > (float)num6)
					{
						num6 = (int)num42;
					}
				}
				break;
			}
			case AxisPositionType.Top:
			{
				if (axisRenderContext.Axis.IsPlotOrderReversed)
				{
					if (axisRenderContext.TickLableRotation < 0)
					{
						float num11 = (float)num9 * num8 + num8 / 2f;
						if ((float)num10 > num11)
						{
							float num12 = (float)num10 - num11;
							if (num12 > (float)num5)
							{
								num5 = (int)num12;
							}
						}
						break;
					}
					float num13 = (float)j * num8 + num8 / 2f;
					if ((float)num10 > num13)
					{
						float num14 = (float)num10 - num13;
						if (num14 > (float)num6)
						{
							num6 = (int)num14;
						}
					}
					break;
				}
				if (axisRenderContext.TickLableRotation < 0)
				{
					float num15 = (float)j * num8 + num8 / 2f;
					if ((float)num10 > num15)
					{
						float num16 = (float)num10 - num15;
						if (num16 > (float)num5)
						{
							num5 = (int)num16;
						}
					}
					break;
				}
				float num17 = (float)num9 * num8 + num8 / 2f;
				if ((float)num10 > num17)
				{
					float num18 = (float)num10 - num17;
					if (num18 > (float)num6)
					{
						num6 = (int)num18;
					}
				}
				break;
			}
			}
		}
		axisRenderContext.float_4 = num3;
		axisRenderContext.float_3 = num4;
		if (array != null && array.Length > 0 && list.Count > 0)
		{
			axisRenderContext.TickLabelSpacing = 1;
			int rotation = 0;
			if (isDisplayAxisSameAsBar)
			{
				rotation = 90;
			}
			foreach (IList list2 in array)
			{
				if (isDisplayAxisSameAsBar)
				{
					layoutArea.Height = rect.Height / list2.Count;
					layoutArea.Width = (float)rect.Width * 0.5f;
				}
				else
				{
					layoutArea.Width = rect.Width / list2.Count;
					layoutArea.Height = (float)rect.Height * 0.5f;
				}
				Size size3 = smethod_30(g, list2, rotation, layoutArea, axisRenderContext);
				if (isDisplayAxisSameAsBar)
				{
					num3 += size3.Width;
				}
				else
				{
					num4 += size3.Height;
				}
			}
		}
		axisRenderContext.float_1 = num3;
		axisRenderContext.float_2 = num4;
		if (smethod_28(axisRenderContext, firstSeries))
		{
			if (isDisplayAxisSameAsBar)
			{
				axisRenderContext.float_5 = (float)num4 / 2f;
			}
			else
			{
				axisRenderContext.float_5 = (float)num3 / 2f;
			}
			axisRenderContext.float_6 = axisRenderContext.float_5;
		}
		else if (smethod_29(axisRenderContext, firstSeries))
		{
			axisRenderContext.float_5 = num5;
			axisRenderContext.float_6 = num6;
		}
		return new Size(num3, num4);
	}

	private static int smethod_27(Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		bool flag = false;
		List<Interface8> list;
		if (axisRenderContext.AxisType == Enum160.const_0)
		{
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			flag = chart.NSeriesInternal.bool_0;
		}
		else
		{
			list = chart.NSeriesInternal.Category2LabelsInternal;
			flag = chart.NSeriesInternal.bool_1;
		}
		if (!flag)
		{
			return 1;
		}
		if (list.Count == 1)
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
			if (num5 < list.Count)
			{
				Class743 @class = (Class743)list[num5];
				if (@class.LabelValue != null && !@class.LabelValue.Equals(""))
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
						if (num5 == list.Count)
						{
							num4 = 100f;
						}
						num4 = ((num3 < num4 / 2f) ? num3 : (num4 / 2f));
						num3 = num4;
						num = Struct41.smethod_5(num3 + 1f + num4);
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

	internal static bool smethod_28(Class783 axisRenderContext, Class759 firstSeries)
	{
		if (axisRenderContext.Axis != null && axisRenderContext.Axis.IsVisible && axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
		{
			if (axisRenderContext.AxisType != Enum160.const_2 && axisRenderContext.AxisType != Enum160.const_3 && firstSeries.ResembleType != ChartType.ScatterWithMarkers && firstSeries.ResembleType != ChartType.Bubble)
			{
				if (!axisRenderContext.AxisBetweenCategories && axisRenderContext.TickLableRotation == 0 && firstSeries.ResembleType != ChartType.Radar && firstSeries.ResembleType != ChartType.FilledRadar)
				{
					return true;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	internal static bool smethod_29(Class783 axisRenderContext, Class759 firstSeries)
	{
		if (axisRenderContext.Axis != null && axisRenderContext.Axis.IsVisible && axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
		{
			if (smethod_28(axisRenderContext, firstSeries))
			{
				return false;
			}
			if ((axisRenderContext.AxisType == Enum160.const_0 || axisRenderContext.AxisType == Enum160.const_1) && axisRenderContext.AxisBetweenCategories && firstSeries.ResembleType != ChartType.Radar && firstSeries.ResembleType != ChartType.FilledRadar && Math.Abs(axisRenderContext.TickLableRotation) != 90 && axisRenderContext.TickLableRotation != 0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	internal static Size smethod_30(Interface32 g, IList categoryList, int rotation, SizeF layoutArea, Class783 axisRenderContext)
	{
		layoutArea.Width += 4f;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < categoryList.Count; i++)
		{
			Class743 @class = (Class743)categoryList[i];
			string text = Struct28.smethod_5(@class.LabelValue, @class.SourceFormat, @class.IsCulture);
			Size size = Struct39.smethod_3(g, text, rotation, axisRenderContext.TickLabelTextFont, layoutArea, Enum157.const_1, Enum157.const_1);
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

	internal static void smethod_31(Interface32 g, Class759 firstSeries, bool isDisplayAxisSameAsBar, Class783 axisRenderContext)
	{
		if (axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.None)
		{
			return;
		}
		Class748 @class = firstSeries.PointsInternal.method_0(0);
		ChartType resembleType = firstSeries.ResembleType;
		string format = @class.YFormat;
		bool yValueIsCulture = @class.YValueIsCulture;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < axisRenderContext.arrayList_0.Count; i++)
		{
			if (i != 0 && i != axisRenderContext.arrayList_0.Count - 1)
			{
				continue;
			}
			string text = "";
			double num3 = (double)axisRenderContext.arrayList_0[i] * smethod_22(axisRenderContext);
			if (axisRenderContext.IsLinkedSource)
			{
				if (Struct24.smethod_42(resembleType))
				{
					format = "0%";
				}
				text = Struct28.smethod_5(num3, format, yValueIsCulture);
			}
			else
			{
				text = smethod_34(num3, axisRenderContext);
			}
			Size size = Struct39.smethod_2(g, text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, axisRenderContext.ChartRenderContext.Chart2007.PlotAreaInternal.rectangle_1.Size, Enum157.const_1, Enum157.const_1);
			if (i == 0)
			{
				num = ((!isDisplayAxisSameAsBar) ? (size.Height / 2) : (size.Width / 2));
			}
			if (i == axisRenderContext.arrayList_0.Count - 1)
			{
				num2 = ((!isDisplayAxisSameAsBar) ? (size.Height / 2) : (size.Width / 2));
			}
		}
		if (axisRenderContext.Axis.IsPlotOrderReversed)
		{
			int num4 = num;
			num = num2;
			num2 = num4;
		}
		axisRenderContext.float_5 = num;
		axisRenderContext.float_6 = num2;
	}

	internal static DateTime smethod_32(double val, bool date1904)
	{
		return Struct41.smethod_29(val, date1904);
	}

	internal static int smethod_33(DateTime dateTime, bool date1904)
	{
		return (int)Struct41.smethod_30(dateTime, date1904);
	}

	internal static string smethod_34(object scale, Class783 axisRenderContext)
	{
		string text = axisRenderContext.Axis.NumberFormat;
		string text2 = "";
		if ((axisRenderContext.AxisType == Enum160.const_0 || axisRenderContext.AxisType == Enum160.const_1) && axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			DateTime dateTime = smethod_32(Convert.ToInt32(scale), axisRenderContext.ChartRenderContext.Chart2007.IsDate1904);
			if (!(text != ""))
			{
				text = ((axisRenderContext.Axis.BaseUnitScale == TimeUnitType.Days) ? "M/d/yyyy" : ((axisRenderContext.Axis.BaseUnitScale != TimeUnitType.Months) ? "yyyy" : "MMM-yy"));
			}
			else
			{
				try
				{
					dateTime.ToString(text);
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
					text = ((axisRenderContext.Axis.BaseUnitScale == TimeUnitType.Days) ? "M/d/yyyy" : ((axisRenderContext.Axis.BaseUnitScale != TimeUnitType.Months) ? "yyyy" : "MMM-yy"));
				}
			}
			return Struct43.smethod_0(dateTime, text, isCulture: false);
		}
		return Struct28.smethod_5(scale, text, isCulture: false);
	}

	internal static int smethod_35(TimeUnitType baseUnitScale, int maxValue, int minValue, bool date1904)
	{
		DateTime dateTime = smethod_32(maxValue, date1904);
		DateTime dateTime2 = smethod_32(minValue, date1904);
		return baseUnitScale switch
		{
			TimeUnitType.Days => maxValue - minValue, 
			TimeUnitType.Months => (dateTime.Year - dateTime2.Year) * 12 + dateTime.Month - dateTime2.Month, 
			_ => dateTime.Year - dateTime2.Year, 
		};
	}

	internal static int smethod_36(TimeUnitType baseUnitScale, int maxValue, int minValue, bool date1904)
	{
		DateTime dateTime = smethod_32(maxValue, date1904);
		DateTime dateTime2 = smethod_32(minValue, date1904);
		int num;
		switch (baseUnitScale)
		{
		case TimeUnitType.Days:
			num = maxValue - minValue;
			break;
		case TimeUnitType.Months:
			num = (dateTime.Year - dateTime2.Year) * 12 + dateTime.Month - dateTime2.Month;
			if (dateTime.Day - dateTime2.Day > 0)
			{
				num++;
			}
			break;
		default:
			num = dateTime.Year - dateTime2.Year;
			break;
		}
		return num;
	}

	internal static int smethod_37(TimeUnitType baseUnitScale, TimeUnitType stepScale, int step, int start, bool date1904)
	{
		DateTime dateTime = smethod_32(start, date1904);
		return smethod_33(baseUnitScale switch
		{
			TimeUnitType.Days => stepScale switch
			{
				TimeUnitType.Days => dateTime.AddDays(step), 
				TimeUnitType.Months => dateTime.AddMonths(step), 
				_ => dateTime.AddYears(step), 
			}, 
			TimeUnitType.Months => (stepScale != TimeUnitType.Months) ? dateTime.AddYears(step) : dateTime.AddMonths(step), 
			_ => dateTime.AddYears(step), 
		}, date1904);
	}

	internal static int smethod_38(TimeUnitType baseUnitScale, int val, bool date1904)
	{
		switch (baseUnitScale)
		{
		case TimeUnitType.Days:
			return val;
		case TimeUnitType.Months:
		{
			DateTime dateTime2 = smethod_32(val, date1904);
			DateTime dateTime3 = new DateTime(dateTime2.Year, dateTime2.Month, 1);
			return smethod_33(dateTime3, date1904);
		}
		default:
		{
			DateTime dateTime = new DateTime(smethod_32(val, date1904).Year, 1, 1);
			return smethod_33(dateTime, date1904);
		}
		}
	}

	internal static int smethod_39(Interface8 categoryLabel)
	{
		int num = 0;
		if (categoryLabel.Children != null && categoryLabel.Children.Count != 0)
		{
			for (int i = 0; i < categoryLabel.Children.Count; i++)
			{
				num += smethod_39(categoryLabel.Children[i]);
			}
			return num;
		}
		return 1;
	}

	private static int smethod_40(Class743 categoryLabel)
	{
		int num = 0;
		while (categoryLabel.Children != null)
		{
			num++;
			categoryLabel = (Class743)categoryLabel.Children[0];
		}
		return num;
	}

	private static void smethod_41(Interface32 g, List<Interface8>[] categoryList, float labelX, float labelY, float xLableOffset, bool isPlus, double unitWidth, Enum157 vAlign, float lineStartY, Rectangle plotAreaRect, bool isDisplayAxisSameAsBar, Class783 axisRenderContext)
	{
		int rotation = 0;
		float num = labelY;
		foreach (IList list in categoryList)
		{
			SizeF layoutArea = new SizeF(0f, 0f);
			if (isDisplayAxisSameAsBar)
			{
				layoutArea.Height = plotAreaRect.Height / list.Count;
				layoutArea.Width = (float)plotAreaRect.Width * 0.5f;
			}
			else
			{
				layoutArea.Width = plotAreaRect.Width / list.Count;
				layoutArea.Height = (float)plotAreaRect.Height * 0.5f;
			}
			Size size = smethod_30(g, list, rotation, layoutArea, axisRenderContext);
			float num2 = labelX;
			for (int j = 0; j < list.Count; j++)
			{
				Class743 @class = (Class743)list[j];
				string text = Struct28.smethod_5(@class.LabelValue, @class.SourceFormat, @class.IsCulture);
				int num3 = smethod_39(@class);
				float num4 = (float)((double)num3 * unitWidth);
				float x = (axisRenderContext.Axis.IsPlotOrderReversed ? (num2 - num4 / 2f - (float)(size.Width / 2)) : (num2 + num4 / 2f - (float)(size.Width / 2)));
				float y = (isPlus ? num : (num - (float)size.Height));
				RectangleF value = new RectangleF(x, y, size.Width, size.Height);
				smethod_45(g, Rectangle.Round(value), text, rotation, axisRenderContext.TickLabelTextFont, axisRenderContext.TickLabelFontColor, Enum157.const_1, vAlign);
				axisRenderContext.method_3(num2, lineStartY, num2, num);
				if (axisRenderContext.Axis.MajorTickMark != TickMarkType.None)
				{
					float num5 = num;
					num5 = (isPlus ? (num + (xLableOffset + (float)size.Height)) : (num - (xLableOffset + (float)size.Height)));
					smethod_42(g, @class.Children, num2, lineStartY, num5, isPlus, unitWidth, axisRenderContext);
				}
				num2 = (axisRenderContext.Axis.IsPlotOrderReversed ? (num2 - num4) : (num2 + num4));
			}
			axisRenderContext.method_3(num2, lineStartY, num2, num);
			num = ((!isPlus) ? (num - (xLableOffset + (float)size.Height)) : (num + (xLableOffset + (float)size.Height)));
		}
	}

	private static void smethod_42(Interface32 g, Interface7 categoryLabelList, float startX, float startY, float endY, bool isPlus, double unitWidth, Class783 axisRenderContext)
	{
		float num = startX;
		for (int i = 0; i < categoryLabelList.Count; i++)
		{
			Class743 categoryLabel = (Class743)categoryLabelList[i];
			int num2 = smethod_39(categoryLabel);
			float num3 = (float)((double)num2 * unitWidth);
			num = (axisRenderContext.Axis.IsPlotOrderReversed ? (num - num3) : (num + num3));
			axisRenderContext.method_3(num, startY, num, endY);
		}
	}

	internal static Class783 smethod_43(Class784 chartRenderContext, Class783 axisRenderContext)
	{
		return axisRenderContext.AxisType switch
		{
			Enum160.const_0 => chartRenderContext.Y1AxisRenderContext, 
			Enum160.const_1 => chartRenderContext.Y2AxisRenderContext, 
			Enum160.const_2 => chartRenderContext.X1AxisRenderContext, 
			Enum160.const_3 => chartRenderContext.X2AxisRenderContext, 
			_ => null, 
		};
	}

	public static void smethod_44(Interface32 g, Rectangle rect, string text, int rotation, Font font, Color fontColor, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.Alignment = Struct39.smethod_18(horizontalAlignment);
		stringFormat.LineAlignment = Struct39.smethod_18(verticalAlignment);
		switch (Math.Abs(rotation))
		{
		default:
		{
			double num = Math.Sqrt(Math.Pow(rect.Width, 2.0) + Math.Pow(rect.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF = g.imethod_110(text, font, (int)num, stringFormat);
			g.imethod_132(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
			g.imethod_115(-rotation);
			g.imethod_61(layoutRectangle: new RectangleF((0f - sizeF.Width) / 2f, (0f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), s: text, font: font, brush: new SolidBrush(fontColor), format: stringFormat);
			g.ResetTransform();
			break;
		}
		case 90:
			g.imethod_132(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
			g.imethod_115(-rotation);
			rect = new Rectangle(-rect.Height / 2, -rect.Width / 2, rect.Height, rect.Width);
			g.imethod_62(text, font, new SolidBrush(fontColor), rect, stringFormat);
			g.ResetTransform();
			break;
		case 0:
			g.imethod_62(text, font, new SolidBrush(fontColor), rect, stringFormat);
			break;
		}
	}

	public static void smethod_45(Interface32 g, Rectangle rect, string text, int rotation, Font font, Color fontColor, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.Alignment = Struct39.smethod_18(horizontalAlignment);
		stringFormat.LineAlignment = Struct39.smethod_18(verticalAlignment);
		switch (Math.Abs(rotation))
		{
		default:
		{
			double num = Math.Sqrt(Math.Pow(rect.Width, 2.0) + Math.Pow(rect.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF = g.imethod_110(text, font, (int)num, stringFormat);
			g.imethod_132(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
			g.imethod_115(-rotation);
			g.imethod_61(layoutRectangle: new RectangleF((0f - sizeF.Width) / 2f, (0f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), s: text, font: font, brush: new SolidBrush(fontColor), format: stringFormat);
			g.ResetTransform();
			break;
		}
		case 90:
			g.imethod_132(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
			g.imethod_115(-rotation);
			rect = new Rectangle(-rect.Height / 2, -rect.Width / 2, rect.Height, rect.Width);
			g.imethod_62(text, font, new SolidBrush(fontColor), rect, stringFormat);
			g.ResetTransform();
			break;
		case 0:
			g.imethod_62(text, font, new SolidBrush(fontColor), rect, stringFormat);
			break;
		}
	}

	[Attribute7(true)]
	internal static void smethod_46(Interface32 g, string text, PointF transForm, SizeF layoutArea, int rotation, Font font, Color fontColor, AxisPositionType axisPositionType)
	{
		if (rotation <= 90 && rotation >= -90 && rotation != 0)
		{
			Brush brush = new SolidBrush(fontColor);
			StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
			stringFormat.Trimming = StringTrimming.EllipsisCharacter;
			SizeF sizeF = g.imethod_108(text, font, transForm, new StringFormat(StringFormat.GenericTypographic));
			double num = (double)Math.Abs(rotation) / 180.0 * Math.PI;
			float num2 = (float)((double)sizeF.Width * Math.Cos(num) + (double)sizeF.Height * Math.Sin(num));
			float num3 = 0f;
			num3 = ((!(num2 <= layoutArea.Width)) ? ((float)(((double)layoutArea.Width - (double)sizeF.Height * Math.Sin(num)) / Math.Cos(num))) : sizeF.Width);
			float num4 = (float)((double)sizeF.Height * Math.Sin(num)) / 2f;
			g.imethod_132(transForm.X, transForm.Y);
			g.imethod_115(-rotation);
			RectangleF empty = RectangleF.Empty;
			switch (axisPositionType)
			{
			case AxisPositionType.Bottom:
				if (rotation > 0)
				{
					empty = new RectangleF(0f - num3, 0f, num3, sizeF.Height);
					stringFormat.Alignment = StringAlignment.Far;
					g.imethod_132(0f - num4, 0f);
				}
				else
				{
					empty = new RectangleF(0f, 0f, num3, sizeF.Height);
					stringFormat.Alignment = StringAlignment.Near;
					g.imethod_132(num4, 0f);
				}
				empty.Y -= sizeF.Height / 2f;
				break;
			case AxisPositionType.Top:
				if (rotation < 0)
				{
					empty = new RectangleF(0f - num3, 0f, num3, sizeF.Height);
					stringFormat.Alignment = StringAlignment.Far;
					g.imethod_132(0f - num4, 0f);
				}
				else
				{
					empty = new RectangleF(0f, 0f, num3, sizeF.Height);
					stringFormat.Alignment = StringAlignment.Near;
					g.imethod_132(num4, 0f);
				}
				empty.Y -= sizeF.Height / 2f;
				break;
			case AxisPositionType.Left:
				empty = new RectangleF(0f - num3, (0f - sizeF.Height) / 2f, num3, sizeF.Height);
				stringFormat.Alignment = StringAlignment.Far;
				g.imethod_132(0f - num4, 0f);
				break;
			default:
				empty = new RectangleF(0f, (0f - sizeF.Height) / 2f, num3, sizeF.Height);
				stringFormat.Alignment = StringAlignment.Near;
				g.imethod_132(num4, 0f);
				break;
			}
			empty.Height += 1f;
			g.imethod_61(text, font, brush, empty, stringFormat);
			g.ResetTransform();
			return;
		}
		throw new Exception("You are calling wrong method!");
	}

	public static void smethod_47(Interface32 g, Rectangle rect, string text, int rotation, Font font, Color fontColor, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.Alignment = Struct39.smethod_18(horizontalAlignment);
		stringFormat.LineAlignment = Struct39.smethod_18(verticalAlignment);
		stringFormat.FormatFlags |= StringFormatFlags.LineLimit;
		stringFormat.Trimming = StringTrimming.EllipsisCharacter;
		switch (Math.Abs(rotation))
		{
		default:
		{
			double num = Math.Sqrt(Math.Pow(rect.Width, 2.0) + Math.Pow(rect.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF = g.imethod_110(text, font, (int)num, stringFormat);
			g.imethod_132(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
			g.imethod_115(-rotation);
			g.imethod_61(layoutRectangle: new RectangleF((0f - sizeF.Width) / 2f, (0f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), s: text, font: font, brush: new SolidBrush(fontColor), format: stringFormat);
			g.ResetTransform();
			break;
		}
		case 90:
			g.imethod_132(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
			g.imethod_115(-rotation);
			rect = new Rectangle(-rect.Height / 2, -rect.Width / 2, rect.Height, rect.Width);
			g.imethod_62(text, font, new SolidBrush(fontColor), rect, stringFormat);
			g.ResetTransform();
			break;
		case 0:
			g.imethod_62(text, font, new SolidBrush(fontColor), rect, stringFormat);
			break;
		}
	}

	internal static Size smethod_48(Interface32 g, ArrayList scales, Rectangle rect, Class783 axisRenderContext)
	{
		if (axisRenderContext.Axis != null && axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None && scales.Count != 0)
		{
			int num = 250;
			SizeF layoutArea = new SizeF(0f, 0f);
			int count = scales.Count;
			layoutArea.Width = rect.Width / count * axisRenderContext.TickLabelSpacing;
			layoutArea.Height = (float)rect.Height * 0.5f;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < scales.Count; i++)
			{
				string text = "";
				text = smethod_34(axisRenderContext.arrayList_0[i], axisRenderContext);
				Size size = Struct39.smethod_3(g, text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, layoutArea, Enum157.const_1, Enum157.const_1);
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
					axisRenderContext.TickLabelsOffsetPixel = Struct39.smethod_2(g, "a", axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, rect.Size, Enum157.const_1, Enum157.const_1).Width * axisRenderContext.TickLabelsOffset / num;
				}
			}
			axisRenderContext.float_1 = num2;
			axisRenderContext.float_2 = num3;
			return new Size(num2, num3);
		}
		return new Size(0, 0);
	}

	internal static void smethod_49(Interface32 g, Class783 axisRenderContext, Class784 renderContext)
	{
		Class740 chart = renderContext.Chart2007;
		if (chart.PlotAreaInternal.method_16())
		{
			return;
		}
		ChartType type = chart.Type;
		Class764 wallsInternal = chart.WallsInternal;
		PointF pointF = Struct25.smethod_5(chart);
		axisRenderContext.method_3(pointF.X, pointF.Y, pointF.X, pointF.Y - wallsInternal.Height);
		Class759 @class = chart.NSeriesInternal.method_0(0);
		Class748 class2 = @class.PointsInternal.method_0(0);
		string format = class2.YFormat;
		bool yValueIsCulture = class2.YValueIsCulture;
		float num = 0f;
		Enum157 horizontalAlignment = Enum157.const_8;
		float num2 = smethod_0(axisRenderContext.TickLabelTextFont.Size);
		if (pointF.X > chart.WallsInternal.xCenter)
		{
			horizontalAlignment = Enum157.const_7;
			num = pointF.X;
			num += num2;
		}
		else
		{
			num = pointF.X - axisRenderContext.float_1;
			num -= num2;
		}
		ArrayList arrayList_ = axisRenderContext.arrayList_0;
		double num3 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MaxValue) : axisRenderContext.MaxValue);
		double num4 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MinValue) : axisRenderContext.MinValue);
		double num5 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MajorUnit) : axisRenderContext.MajorUnit);
		for (int i = 0; i < axisRenderContext.arrayList_0.Count; i++)
		{
			double num6 = (double)axisRenderContext.arrayList_0[i];
			double num7 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_1(num6) : num6);
			if (i - 1 > 0)
			{
				if (Math.Abs(Struct41.smethod_11(num6, (double)arrayList_[i - 1])) != num5)
				{
					continue;
				}
			}
			else if (i + 1 < arrayList_.Count && Math.Abs(Struct41.smethod_11(num6, (double)arrayList_[i + 1])) != num5)
			{
				continue;
			}
			float num8 = (float)((num6 - num4) / (num3 - num4) * (double)chart.WallsInternal.Height);
			num8 = (axisRenderContext.Axis.IsPlotOrderReversed ? (pointF.Y - wallsInternal.Height + num8) : (pointF.Y - num8));
			if (axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
			{
				if (Struct24.smethod_42(type))
				{
					num7 /= 100.0;
					format = "0%";
				}
				string text = "";
				num7 = (axisRenderContext.Axis.IsLogarithmic ? num7 : (num7 * smethod_22(axisRenderContext)));
				Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
				if (axisRenderContext.IsLinkedSource)
				{
					text = Struct28.smethod_5(num7, format, yValueIsCulture);
					tickLabelFontColor = Struct28.smethod_6(num7, format, tickLabelFontColor);
				}
				else
				{
					text = smethod_34(num7, axisRenderContext);
					tickLabelFontColor = Struct28.smethod_6(num7, axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
				}
				RectangleF value = new RectangleF(num, num8 - axisRenderContext.float_2 / 2f, axisRenderContext.float_1, axisRenderContext.float_2);
				smethod_44(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, horizontalAlignment, Enum157.const_1);
			}
			smethod_50(g, pointF.X, num8, axisRenderContext);
		}
		smethod_51(g, pointF.X, pointF.Y - wallsInternal.Height, pointF.Y, axisRenderContext);
	}

	private static void smethod_50(Interface32 g, float x, float y, Class783 axisRenderContext)
	{
		if (axisRenderContext.Axis.MajorTickMark == TickMarkType.None || !axisRenderContext.Axis.IsVisible)
		{
			return;
		}
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		bool flag = false;
		bool flag2 = false;
		switch (axisRenderContext.Axis.MajorTickMark)
		{
		case TickMarkType.Cross:
			flag = true;
			flag2 = true;
			break;
		case TickMarkType.Inside:
			flag = true;
			if (x > chart.WallsInternal.xCenter)
			{
				flag = false;
				flag2 = true;
			}
			break;
		case TickMarkType.Outside:
			flag2 = true;
			if (x > chart.WallsInternal.xCenter)
			{
				flag2 = false;
				flag = true;
			}
			break;
		}
		float num = smethod_0(axisRenderContext.TickLabelTextFont.Size);
		if (flag)
		{
			axisRenderContext.method_3(x, y, x + num, y);
		}
		if (flag2)
		{
			axisRenderContext.method_3(x - num, y, x, y);
		}
	}

	private static void smethod_51(Interface32 g, float x, float y0, float y1, Class783 axisRenderContext)
	{
		if (axisRenderContext.Axis.MinorTickMark == TickMarkType.None || !axisRenderContext.Axis.IsVisible)
		{
			return;
		}
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		bool flag = false;
		bool flag2 = false;
		switch (axisRenderContext.Axis.MinorTickMark)
		{
		case TickMarkType.Cross:
			flag = true;
			flag2 = true;
			break;
		case TickMarkType.Inside:
			flag = true;
			if (x > chart.WallsInternal.xCenter)
			{
				flag = false;
				flag2 = true;
			}
			break;
		case TickMarkType.Outside:
			flag2 = true;
			if (x > chart.WallsInternal.xCenter)
			{
				flag2 = false;
				flag = true;
			}
			break;
		}
		float num = (float)(axisRenderContext.MinorUnit / (axisRenderContext.MaxValue - axisRenderContext.MinValue) * (double)(y1 - y0));
		float num2;
		if (!axisRenderContext.Axis.IsPlotOrderReversed)
		{
			num2 = y1;
			num = 0f - num;
		}
		else
		{
			num2 = y0;
		}
		float num3 = num2;
		float num4 = smethod_1(axisRenderContext.TickLabelTextFont.Size);
		do
		{
			if (flag)
			{
				axisRenderContext.method_3(x, num3, x + num4, num3);
			}
			if (flag2)
			{
				axisRenderContext.method_3(x - num4, num3, x, num3);
			}
			num3 += num;
		}
		while (y0 <= num3 && num3 <= y1);
	}

	internal static void smethod_52(Interface32 g, int maxPointsCount, Rectangle plotAreaRect, bool isDisplayAxisSameAsBar, Class783 axisRenderContext, Class784 renderContext)
	{
		Class740 chart = renderContext.Chart2007;
		if (chart.PlotAreaInternal.method_16())
		{
			return;
		}
		if (axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_53(g, axisRenderContext, renderContext);
			return;
		}
		PointF[] array = Struct25.smethod_3(chart);
		double logMaxValue = renderContext.Y1AxisRenderContext.LogMaxValue;
		double logMinValue = renderContext.Y1AxisRenderContext.LogMinValue;
		double logCrossAt = renderContext.Y1AxisRenderContext.LogCrossAt;
		bool flag = renderContext.Y1AxisRenderContext.MinValue == (double)renderContext.Y1AxisRenderContext.CrossAt;
		logCrossAt = ((!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed) ? (logCrossAt - logMinValue) : (logMaxValue - logCrossAt));
		int num = (int)(logCrossAt / (logMaxValue - logMinValue) * (double)chart.WallsInternal.Height);
		if (num != 0)
		{
			axisRenderContext.method_3(array[0].X, array[0].Y - (float)num, array[1].X, array[1].Y - (float)num);
		}
		if (chart.Elevation >= 0)
		{
			axisRenderContext.method_3(array[0].X, array[0].Y, array[1].X, array[1].Y);
		}
		if (axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.NextTo)
		{
			array[0].Y -= num;
			array[1].Y -= num;
		}
		List<Interface8> categoryLabelsInternal = chart.NSeriesInternal.CategoryLabelsInternal;
		float num2 = axisRenderContext.TickLabelsOffsetPixel;
		if (axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
		{
			float size = axisRenderContext.TickLabelTextFont.Size;
			num2 += smethod_0(size) + smethod_1(size);
		}
		bool flag2;
		int num3;
		if (flag2 = axisRenderContext.AxisBetweenCategories || renderContext.Chart.HasDataTable)
		{
			num3 = maxPointsCount;
		}
		else
		{
			num3 = maxPointsCount - 1;
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		double num4 = ((array[1].X == array[0].X) ? (Math.PI / 2.0) : Math.Atan(Math.Abs((array[0].Y - array[1].Y) / (array[1].X - array[0].X))));
		float num5 = (array[1].X - array[0].X) / (float)num3;
		float num6 = (array[1].Y - array[0].Y) / (float)num3;
		PointF empty = PointF.Empty;
		for (int i = 0; i < maxPointsCount; i++)
		{
			int num7 = i;
			if (axisRenderContext.Axis.IsPlotOrderReversed)
			{
				num7 = maxPointsCount - 1 - i;
			}
			string text = "";
			Color color = axisRenderContext.TickLabelFontColor;
			if (num7 < axisRenderContext.arrayList_0.Count)
			{
				text = smethod_34(axisRenderContext.arrayList_0[i], axisRenderContext);
				color = Struct28.smethod_6(axisRenderContext.arrayList_0[num7], axisRenderContext.Axis.NumberFormat, color);
				if (axisRenderContext.IsLinkedSource && categoryLabelsInternal.Count > 0)
				{
					string text2 = "";
					bool flag3 = false;
					text2 = ((num7 < categoryLabelsInternal.Count) ? ((Class743)categoryLabelsInternal[num7]).SourceFormat : "");
					flag3 = num7 < categoryLabelsInternal.Count && ((Class743)categoryLabelsInternal[num7]).IsCulture;
					text = Struct28.smethod_5(axisRenderContext.arrayList_0[num7], text2, flag3);
					color = Struct28.smethod_6(axisRenderContext.arrayList_0[num7], text2, color);
				}
			}
			if (axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.None || num7 % axisRenderContext.TickLabelSpacing != 0)
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
						value.X = ((num5 < 0f) ? (array[0].X + (float)(i + 1) * num5) : (array[0].X + (float)i * num5));
						value.Y = array[0].Y + num2;
						value.Width = Math.Abs(num5);
						value.Height = axisRenderContext.float_3;
						flag4 = true;
						empty.X = ((num5 < 0f) ? (value.X - num5 / 2f) : (value.X + num5 / 2f));
						empty.Y = value.Y;
					}
					else if (num4 <= Math.PI / 4.0)
					{
						value.X = ((num5 < 0f) ? (array[0].X + (float)(i + 1) * num5) : (array[0].X + (float)i * num5));
						value.Y = ((num6 > 0f) ? (array[0].Y + (float)(i + 1) * num6) : (array[0].Y + (float)i * num6));
						value.Width = Math.Abs(num5);
						value.Height = axisRenderContext.float_3;
					}
					else
					{
						value.X = ((num6 > 0f) ? (array[0].X + (float)i * num5) : (array[0].X + (float)(i + 1) * num5));
						value.X = ((num5 * num6 <= 0f) ? (value.X + num2 * (float)Math.Sin(num4)) : (value.X - num2 * (float)Math.Sin(num4) - axisRenderContext.float_4));
						value.Y = ((num6 > 0f) ? (array[0].Y + (float)i * num6) : (array[0].Y + (float)(i + 1) * num6));
						value.Y += (Math.Abs(num6) - axisRenderContext.float_3) * (float)Math.Sin(num4) / 2f;
						value.Width = axisRenderContext.float_4;
						value.Height = axisRenderContext.float_3;
					}
				}
				else if (chart.Elevation < 0 && !flag && axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.NextTo)
				{
					if (array[0].Y == array[1].Y)
					{
						value.X = ((num5 > 0f) ? (array[0].X + (float)i * num5) : (array[0].X + (float)(i + 1) * num5));
						value.Y = array[0].Y - axisRenderContext.float_3 - num2;
						value.Width = Math.Abs(num5);
						value.Height = axisRenderContext.float_3;
					}
					else if (num4 <= Math.PI / 4.0)
					{
						value.X = ((num5 < 0f) ? (array[0].X + (float)(i + 1) * num5) : (array[0].X + (float)i * num5));
						value.Y = ((num6 < 0f) ? (array[0].Y + (float)(i + 1) * num6) : (array[0].Y + (float)i * num6));
						value.Y -= axisRenderContext.float_3;
						value.Width = Math.Abs(num5);
						value.Height = axisRenderContext.float_3;
					}
					else
					{
						value.X = ((num6 < 0f) ? (array[0].X + (float)i * num5) : (array[0].X + (float)(i + 1) * num5));
						value.X = ((num5 * num6 >= 0f) ? (value.X + num2 * (float)Math.Sin(num4)) : (value.X - num2 * (float)Math.Sin(num4) - axisRenderContext.float_4));
						value.Y = ((num6 < 0f) ? (array[0].Y + (float)i * num6) : (array[0].Y + (float)(i + 1) * num6));
						value.Y -= (Math.Abs(num6) - axisRenderContext.float_3) * (float)Math.Sin(num4) / 2f;
						value.Y -= axisRenderContext.float_3;
						value.Width = axisRenderContext.float_4;
						value.Height = axisRenderContext.float_3;
					}
				}
			}
			else if (chart.Elevation >= 0)
			{
				if (array[0].Y == array[1].Y)
				{
					value.X = ((num5 < 0f) ? (array[0].X + (float)i * num5 + num5 / 2f) : (array[0].X + (float)i * num5 - num5 / 2f));
					value.Y = array[0].Y + num2;
					value.Width = Math.Abs(num5);
					value.Height = axisRenderContext.float_3;
				}
				else if (num4 <= Math.PI / 4.0)
				{
					value.X = array[0].X + (float)i * num5 - Math.Abs(num5) / 2f;
					value.Y = array[0].Y + (float)i * num6 + num2;
					value.Width = Math.Abs(num5);
					value.Height = axisRenderContext.float_3;
				}
				else
				{
					value.X = array[0].X + (float)i * num5;
					value.X = ((num5 * num6 <= 0f) ? (value.X + num2 * (float)Math.Sin(num4)) : (value.X - num2 * (float)Math.Sin(num4) - axisRenderContext.float_4));
					value.Y = array[0].Y + (float)i * num6 - axisRenderContext.float_3 / 2f;
					value.Width = axisRenderContext.float_4;
					value.Height = axisRenderContext.float_3;
				}
			}
			else if (chart.Elevation < 0 && !flag && axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.NextTo)
			{
				if (array[0].Y == array[1].Y)
				{
					value.X = ((num5 > 0f) ? (array[0].X + (float)i * num5 - num5 / 2f) : (array[0].X + (float)i * num5 + num5 / 2f));
					value.Y = array[0].Y - axisRenderContext.float_3 - num2;
					value.Width = Math.Abs(num5);
					value.Height = axisRenderContext.float_3;
				}
				else if (num4 <= Math.PI / 4.0)
				{
					value.X = array[0].X + (float)i * num5 - Math.Abs(num5) / 2f;
					value.Y = array[0].Y + (float)i * num6;
					value.Y -= axisRenderContext.float_3 + num2;
					value.Width = Math.Abs(num5);
					value.Height = axisRenderContext.float_3;
				}
				else
				{
					value.X = ((num6 < 0f) ? (array[0].X + (float)i * num5) : (array[0].X + (float)i * num5));
					value.X = ((num5 * num6 >= 0f) ? (value.X + num2 * (float)Math.Sin(num4)) : (value.X - num2 * (float)Math.Sin(num4) - axisRenderContext.float_4));
					value.Y = array[0].Y + (float)i * num6 - axisRenderContext.float_3 / 2f;
					value.Width = axisRenderContext.float_4;
					value.Height = axisRenderContext.float_3;
				}
			}
			if (axisRenderContext.TickLableRotation != 0 && axisRenderContext.TickLableRotation != 90 && axisRenderContext.TickLableRotation != -90 && flag4)
			{
				smethod_46(g, text, empty, new SizeF(axisRenderContext.float_4, axisRenderContext.float_3), axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, color, axisRenderContext.Axis.Position);
			}
			else
			{
				smethod_44(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, color, Enum157.const_1, Enum157.const_1);
			}
		}
		smethod_54(g, num, maxPointsCount, axisRenderContext);
		List<Interface8>[] categories = chart.NSeriesInternal.Categories;
		float y = array[0].Y;
		Enum157 vAlign = Enum157.const_9;
		if (categories != null && categories.Length > 0 && categoryLabelsInternal.Count > 0 && axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
		{
			float labelX = (axisRenderContext.Axis.IsPlotOrderReversed ? array[1].X : array[0].X);
			float labelY = y + num2 * (float)(categories.Length + 1) + axisRenderContext.float_2;
			float lineStartY = y;
			bool isPlus = false;
			if (array[0].Y == array[1].Y)
			{
				smethod_41(g, categories, labelX, labelY, num2, isPlus, num5, vAlign, lineStartY, plotAreaRect, isDisplayAxisSameAsBar, axisRenderContext);
			}
		}
	}

	private static void smethod_53(Interface32 g, Class783 axisRenderContext, Class784 renderContext)
	{
		Class740 chart = renderContext.Chart2007;
		PointF[] array = Struct25.smethod_3(chart);
		double num = ((!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed) ? ((double)renderContext.Y1AxisRenderContext.CrossAt - renderContext.Y1AxisRenderContext.MinValue) : (renderContext.Y1AxisRenderContext.MaxValue - (double)renderContext.Y1AxisRenderContext.CrossAt));
		int num2 = (int)(num / (renderContext.Y1AxisRenderContext.MaxValue - renderContext.Y1AxisRenderContext.MinValue) * (double)chart.WallsInternal.Height);
		if (num2 != 0)
		{
			axisRenderContext.method_3(array[0].X, array[0].Y - (float)num2, array[1].X, array[1].Y - (float)num2);
		}
		if (chart.Elevation >= 0)
		{
			axisRenderContext.method_3(array[0].X, array[0].Y, array[1].X, array[1].Y);
		}
		if (axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.NextTo)
		{
			array[0].Y -= num2;
			array[1].Y -= num2;
		}
		List<Interface8> categoryLabelsInternal = chart.NSeriesInternal.CategoryLabelsInternal;
		float num3 = axisRenderContext.TickLabelsOffsetPixel;
		if (axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
		{
			float size = axisRenderContext.TickLabelTextFont.Size;
			num3 += smethod_0(size) + smethod_1(size);
		}
		double num4 = ((array[1].X == array[0].X) ? (Math.PI / 2.0) : Math.Atan(Math.Abs((array[0].Y - array[1].Y) / (array[1].X - array[0].X))));
		int maxValue = (int)axisRenderContext.MaxValue;
		int minValue = (int)axisRenderContext.MinValue;
		TimeUnitType baseUnitScale = axisRenderContext.Axis.BaseUnitScale;
		bool flag;
		int num5;
		if (flag = axisRenderContext.AxisBetweenCategories || renderContext.Chart.HasDataTable)
		{
			num5 = smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		}
		else
		{
			num5 = smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904);
			if (num5 == 0)
			{
				num5 = 1;
			}
		}
		float num6 = (array[1].X - array[0].X) / (float)num5;
		float num7 = (array[1].Y - array[0].Y) / (float)num5;
		ArrayList arrayList_ = axisRenderContext.arrayList_0;
		for (int i = 0; i < arrayList_.Count; i++)
		{
			int num8 = i;
			if (axisRenderContext.Axis.IsPlotOrderReversed)
			{
				num8 = arrayList_.Count - 1 - i;
			}
			Convert.ToInt32(axisRenderContext.arrayList_0[i]);
			string text = "";
			Color color = axisRenderContext.TickLabelFontColor;
			if (num8 < axisRenderContext.arrayList_0.Count)
			{
				text = smethod_34(axisRenderContext.arrayList_0[num8], axisRenderContext);
				color = Struct28.smethod_6(axisRenderContext.arrayList_0[num8], axisRenderContext.Axis.NumberFormat, color);
				if (axisRenderContext.IsLinkedSource && categoryLabelsInternal.Count > 0)
				{
					string text2 = "";
					bool flag2 = false;
					text2 = ((num8 < categoryLabelsInternal.Count) ? ((Class743)categoryLabelsInternal[num8]).SourceFormat : "");
					flag2 = num8 < categoryLabelsInternal.Count && ((Class743)categoryLabelsInternal[num8]).IsCulture;
					text = Struct28.smethod_5(axisRenderContext.arrayList_0[num8], text2, flag2);
					color = Struct28.smethod_6(axisRenderContext.arrayList_0[num8], text2, color);
				}
			}
			if (axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.None)
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
						value.Height = axisRenderContext.float_2;
					}
					else if (num4 <= Math.PI / 4.0)
					{
						value.X = ((num6 < 0f) ? (array[0].X + (float)(i + 1) * num6) : (array[0].X + (float)i * num6));
						value.Y = ((num7 > 0f) ? (array[0].Y + (float)(i + 1) * num7) : (array[0].Y + (float)i * num7));
						value.Width = axisRenderContext.float_1;
						value.Height = axisRenderContext.float_2;
					}
					else
					{
						value.X = ((num7 > 0f) ? (array[0].X + (float)i * num6) : (array[0].X + (float)(i + 1) * num6));
						value.X = ((num6 * num7 <= 0f) ? (value.X + num3 * (float)Math.Sin(num4)) : (value.X - num3 * (float)Math.Sin(num4) - axisRenderContext.float_1));
						value.Y = ((num7 > 0f) ? (array[0].Y + (float)i * num7) : (array[0].Y + (float)(i + 1) * num7));
						value.Y += (Math.Abs(num7) - axisRenderContext.float_2) * (float)Math.Sin(num4) / 2f;
						value.Width = axisRenderContext.float_1;
						value.Height = axisRenderContext.float_2;
					}
				}
				else if (chart.Elevation < 0 && num != 0.0 && axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.NextTo)
				{
					if (array[0].Y == array[1].Y)
					{
						value.X = ((num6 > 0f) ? (array[0].X + (float)i * num6) : (array[0].X + (float)(i + 1) * num6));
						value.Y = array[0].Y - axisRenderContext.float_2 - num3;
						value.Width = axisRenderContext.float_1;
						value.Height = axisRenderContext.float_2;
					}
					else if (num4 <= Math.PI / 4.0)
					{
						value.X = ((num6 < 0f) ? (array[0].X + (float)(i + 1) * num6) : (array[0].X + (float)i * num6));
						value.Y = ((num7 < 0f) ? (array[0].Y + (float)(i + 1) * num7) : (array[0].Y + (float)i * num7));
						value.Y -= axisRenderContext.float_2;
						value.Width = axisRenderContext.float_1;
						value.Height = axisRenderContext.float_2;
					}
					else
					{
						value.X = ((num7 < 0f) ? (array[0].X + (float)i * num6) : (array[0].X + (float)(i + 1) * num6));
						value.X = ((num6 * num7 >= 0f) ? (value.X + num3 * (float)Math.Sin(num4)) : (value.X - num3 * (float)Math.Sin(num4) - axisRenderContext.float_1));
						value.Y = ((num7 < 0f) ? (array[0].Y + (float)i * num7) : (array[0].Y + (float)(i + 1) * num7));
						value.Y -= (Math.Abs(num7) - axisRenderContext.float_2) * (float)Math.Sin(num4) / 2f;
						value.Y -= axisRenderContext.float_2;
						value.Width = axisRenderContext.float_1;
						value.Height = axisRenderContext.float_2;
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
					value.Height = axisRenderContext.float_2;
				}
				else if (num4 <= Math.PI / 4.0)
				{
					value.X = array[0].X + (float)i * num6 - Math.Abs(num6) / 2f;
					value.Y = array[0].Y + (float)i * num7 + num3;
					value.Width = Math.Abs(num6);
					value.Height = axisRenderContext.float_2;
				}
				else
				{
					value.X = array[0].X + (float)i * num6;
					value.X = ((num6 * num7 <= 0f) ? (value.X + num3 * (float)Math.Sin(num4)) : (value.X - num3 * (float)Math.Sin(num4) - axisRenderContext.float_1));
					value.Y = array[0].Y + (float)i * num7 - axisRenderContext.float_2 / 2f;
					value.Width = axisRenderContext.float_1;
					value.Height = axisRenderContext.float_2;
				}
			}
			else if (chart.Elevation < 0 && num != 0.0 && axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.NextTo)
			{
				if (array[0].Y == array[1].Y)
				{
					value.X = ((num6 > 0f) ? (array[0].X + (float)i * num6 - num6 / 2f) : (array[0].X + (float)i * num6 + num6 / 2f));
					value.Y = array[0].Y - axisRenderContext.float_2 - num3;
					value.Width = Math.Abs(num6);
					value.Height = axisRenderContext.float_2;
				}
				else if (num4 <= Math.PI / 4.0)
				{
					value.X = array[0].X + (float)i * num6 - Math.Abs(num6) / 2f;
					value.Y = array[0].Y + (float)i * num7;
					value.Y -= axisRenderContext.float_2 + num3;
					value.Width = Math.Abs(num6);
					value.Height = axisRenderContext.float_2;
				}
				else
				{
					value.X = ((num7 < 0f) ? (array[0].X + (float)i * num6) : (array[0].X + (float)i * num6));
					value.X = ((num6 * num7 >= 0f) ? (value.X + num3 * (float)Math.Sin(num4)) : (value.X - num3 * (float)Math.Sin(num4) - axisRenderContext.float_1));
					value.Y = array[0].Y + (float)i * num7 - axisRenderContext.float_2 / 2f;
					value.Width = axisRenderContext.float_1;
					value.Height = axisRenderContext.float_2;
				}
			}
			smethod_44(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, color, Enum157.const_1, Enum157.const_1);
		}
		smethod_55(g, num2, axisRenderContext);
	}

	private static void smethod_54(Interface32 g, int axisHeight, int maxPointsCount, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if ((axisRenderContext.Axis.MajorTickMark == TickMarkType.None && axisRenderContext.Axis.MinorTickMark == TickMarkType.None) || !axisRenderContext.Axis.IsVisible)
		{
			return;
		}
		float num = smethod_0(axisRenderContext.TickLabelTextFont.Size);
		float num2 = smethod_1(axisRenderContext.TickLabelTextFont.Size);
		bool flag = axisRenderContext.AxisBetweenCategories || axisRenderContext.ChartRenderContext.Chart.HasDataTable;
		PointF[] array;
		if (axisRenderContext.AxisType == Enum160.const_4)
		{
			array = Struct25.smethod_4(chart);
			flag = true;
		}
		else
		{
			array = Struct25.smethod_3(chart);
		}
		double num3 = ((array[1].X == array[0].X) ? (Math.PI / 2.0) : Math.Atan(Math.Abs((array[0].Y - array[1].Y) / (array[1].X - array[0].X))));
		int num4;
		if (flag)
		{
			num4 = maxPointsCount;
		}
		else
		{
			num4 = maxPointsCount - 1;
			if (num4 == 0)
			{
				num4 = 1;
			}
		}
		if (chart.Elevation < 0 && axisHeight > 0)
		{
			array[0].Y -= axisHeight;
			array[1].Y -= axisHeight;
			axisHeight = 0;
		}
		while (true)
		{
			if (!(num3 <= Math.PI / 4.0))
			{
				bool flag2 = false;
				bool flag3 = false;
				switch (axisRenderContext.Axis.MajorTickMark)
				{
				case TickMarkType.Cross:
					flag2 = true;
					flag3 = true;
					break;
				case TickMarkType.Inside:
					if (chart.Rotation >= 90 && (chart.Rotation < 225 || chart.Rotation >= 270))
					{
						flag3 = true;
					}
					else
					{
						flag2 = true;
					}
					break;
				case TickMarkType.Outside:
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
				if (!axisRenderContext.Axis.IsPlotOrderReversed)
				{
					pointF = array[0];
					pointF2 = array[1];
				}
				else
				{
					pointF = array[1];
					pointF2 = array[0];
				}
				float num5 = (pointF2.X - pointF.X) / (float)num4;
				float num6 = (pointF2.Y - pointF.Y) / (float)num4;
				if (num5 == 0f && num6 == 0f)
				{
					break;
				}
				float num7 = pointF.X;
				for (float num8 = pointF.Y; (pointF.Y <= num8 && num8 <= pointF2.Y) || (pointF.Y >= num8 && num8 >= pointF2.Y) || Math.Round(num8) == Math.Round(pointF.Y) || Math.Round(num8) == Math.Round(pointF2.Y); num8 += (float)axisRenderContext.TickMarkSpacing * num6)
				{
					if (flag2)
					{
						axisRenderContext.method_3(num7, num8, num7 + num, num8);
					}
					if (flag3)
					{
						axisRenderContext.method_3(num7 - num, num8, num7, num8);
					}
					num7 += (float)axisRenderContext.TickMarkSpacing * num5;
				}
				bool flag4 = false;
				bool flag5 = false;
				switch (axisRenderContext.Axis.MinorTickMark)
				{
				case TickMarkType.Cross:
					flag4 = true;
					flag5 = true;
					break;
				case TickMarkType.Inside:
					if (chart.Rotation >= 90 && (chart.Rotation < 225 || chart.Rotation >= 270))
					{
						flag5 = true;
					}
					else
					{
						flag4 = true;
					}
					break;
				case TickMarkType.Outside:
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
				num7 = pointF.X + (float)axisRenderContext.TickMarkSpacing * num5 / 2f;
				for (float num8 = pointF.Y + (float)axisRenderContext.TickMarkSpacing * num6 / 2f; (pointF.Y <= num8 && num8 <= pointF2.Y) || (pointF.Y >= num8 && num8 >= pointF2.Y) || Math.Round(num8) == Math.Round(pointF.Y) || Math.Round(num8) == Math.Round(pointF2.Y); num8 += (float)axisRenderContext.TickMarkSpacing * num6)
				{
					if (flag4)
					{
						axisRenderContext.method_3(num7, num8, num7 + num2, num8);
					}
					if (flag5)
					{
						axisRenderContext.method_3(num7 - num2, num8, num7, num8);
					}
					if (axisRenderContext.Axis.MajorTickMark == TickMarkType.None)
					{
						num7 += (float)axisRenderContext.TickMarkSpacing * num5 / 2f;
						num8 += (float)axisRenderContext.TickMarkSpacing * num6 / 2f;
						if ((pointF.Y <= num8 && num8 <= pointF2.Y) || (pointF.Y >= num8 && num8 >= pointF2.Y) || Math.Round(num8) == Math.Round(pointF.Y) || Math.Round(num8) == Math.Round(pointF2.Y))
						{
							if (flag4)
							{
								axisRenderContext.method_3(num7, num8, num7 + num2, num8);
							}
							if (flag5)
							{
								axisRenderContext.method_3(num7 - num2, num8, num7, num8);
							}
						}
						num7 -= (float)axisRenderContext.TickMarkSpacing * num5 / 2f;
						num8 -= (float)axisRenderContext.TickMarkSpacing * num6 / 2f;
					}
					num7 += (float)axisRenderContext.TickMarkSpacing * num5;
				}
			}
			else
			{
				bool flag6 = false;
				bool flag7 = false;
				switch (axisRenderContext.Axis.MajorTickMark)
				{
				case TickMarkType.Cross:
					flag6 = true;
					flag7 = true;
					break;
				case TickMarkType.Inside:
					if (chart.Elevation >= 0)
					{
						flag6 = true;
					}
					else
					{
						flag7 = true;
					}
					break;
				case TickMarkType.Outside:
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
				if (!axisRenderContext.Axis.IsPlotOrderReversed)
				{
					pointF = array[0];
					pointF2 = array[1];
				}
				else
				{
					pointF = array[1];
					pointF2 = array[0];
				}
				float num5 = (pointF2.X - pointF.X) / (float)num4;
				float num6 = (pointF2.Y - pointF.Y) / (float)num4;
				if (num5 == 0f && num6 == 0f)
				{
					break;
				}
				float num9 = pointF.X;
				float num10 = pointF.Y;
				while ((pointF.X <= num9 && num9 <= pointF2.X) || (pointF.X >= num9 && num9 >= pointF2.X) || Math.Round(num9) == Math.Round(pointF.X) || Math.Round(num9) == Math.Round(pointF2.X))
				{
					if (flag6)
					{
						axisRenderContext.method_3(num9, num10 - num, num9, num10);
					}
					if (flag7)
					{
						axisRenderContext.method_3(num9, num10, num9, num10 + num);
					}
					num9 += (float)axisRenderContext.TickMarkSpacing * num5;
					num10 += (float)axisRenderContext.TickMarkSpacing * num6;
				}
				bool flag8 = false;
				bool flag9 = false;
				switch (axisRenderContext.Axis.MinorTickMark)
				{
				case TickMarkType.Cross:
					flag8 = true;
					flag9 = true;
					break;
				case TickMarkType.Inside:
					if (chart.Elevation >= 0)
					{
						flag8 = true;
					}
					else
					{
						flag9 = true;
					}
					break;
				case TickMarkType.Outside:
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
				num9 = pointF.X + (float)axisRenderContext.TickMarkSpacing * num5 / 2f;
				num10 = pointF.Y + (float)axisRenderContext.TickMarkSpacing * num6 / 2f;
				while ((pointF.X <= num9 && num9 <= pointF2.X) || (pointF.X >= num9 && num9 >= pointF2.X) || Math.Round(num9) == Math.Round(pointF.X) || Math.Round(num9) == Math.Round(pointF2.X))
				{
					if (flag8)
					{
						axisRenderContext.method_3(num9, num10 - num2, num9, num10);
					}
					if (flag9)
					{
						axisRenderContext.method_3(num9, num10, num9, num10 + num2);
					}
					if (axisRenderContext.Axis.MajorTickMark == TickMarkType.None)
					{
						num9 += (float)axisRenderContext.TickMarkSpacing * num5 / 2f;
						num10 += (float)axisRenderContext.TickMarkSpacing * num6 / 2f;
						if ((pointF.Y <= num10 && num10 <= pointF2.Y) || (pointF.Y >= num10 && num10 >= pointF2.Y) || Math.Round(num10) == Math.Round(pointF.Y) || Math.Round(num10) == Math.Round(pointF2.Y))
						{
							if (flag8)
							{
								axisRenderContext.method_3(num9, num10 - num2, num9, num10);
							}
							if (flag9)
							{
								axisRenderContext.method_3(num9, num10, num9, num10 + num2);
							}
						}
						num9 -= (float)axisRenderContext.TickMarkSpacing * num5 / 2f;
						num10 -= (float)axisRenderContext.TickMarkSpacing * num6 / 2f;
					}
					num9 += (float)axisRenderContext.TickMarkSpacing * num5;
					num10 += (float)axisRenderContext.TickMarkSpacing * num6;
				}
			}
			if (axisHeight > 0)
			{
				array[0].Y -= axisHeight;
				array[1].Y -= axisHeight;
				axisHeight = 0;
				continue;
			}
			break;
		}
	}

	private static void smethod_55(Interface32 g, int axisHeight, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if ((axisRenderContext.Axis.MajorTickMark == TickMarkType.None && axisRenderContext.Axis.MinorTickMark == TickMarkType.None) || !axisRenderContext.Axis.IsVisible)
		{
			return;
		}
		float num = smethod_0(axisRenderContext.TickLabelTextFont.Size);
		float num2 = smethod_1(axisRenderContext.TickLabelTextFont.Size);
		PointF[] array = Struct25.smethod_3(chart);
		double num3 = ((array[1].X == array[0].X) ? (Math.PI / 2.0) : Math.Atan(Math.Abs((array[0].Y - array[1].Y) / (array[1].X - array[0].X))));
		int maxValue = (int)axisRenderContext.MaxValue;
		int minValue = (int)axisRenderContext.MinValue;
		TimeUnitType baseUnitScale = axisRenderContext.Axis.BaseUnitScale;
		int num4;
		if (axisRenderContext.AxisBetweenCategories || axisRenderContext.ChartRenderContext.Chart.HasDataTable)
		{
			num4 = smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		}
		else
		{
			num4 = smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904);
			if (num4 == 0)
			{
				num4 = 1;
			}
		}
		if (chart.Elevation < 0 && axisHeight > 0)
		{
			array[0].Y -= axisHeight;
			array[1].Y -= axisHeight;
			axisHeight = 0;
		}
		while (true)
		{
			if (!(num3 <= Math.PI / 4.0))
			{
				bool flag = false;
				bool flag2 = false;
				switch (axisRenderContext.Axis.MajorTickMark)
				{
				case TickMarkType.Cross:
					flag = true;
					flag2 = true;
					break;
				case TickMarkType.Inside:
					if (chart.Rotation >= 90 && (chart.Rotation < 225 || chart.Rotation >= 270))
					{
						flag2 = true;
					}
					else
					{
						flag = true;
					}
					break;
				case TickMarkType.Outside:
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
				if (!axisRenderContext.Axis.IsPlotOrderReversed)
				{
					pointF = array[0];
					pointF2 = array[1];
				}
				else
				{
					pointF = array[1];
					pointF2 = array[0];
				}
				float num5 = (pointF2.X - pointF.X) / (float)num4;
				float num6 = (pointF2.Y - pointF.Y) / (float)num4;
				float num7 = pointF.X;
				for (float num8 = pointF.Y; (pointF.Y <= num8 && num8 <= pointF2.Y) || (pointF.Y >= num8 && num8 >= pointF2.Y) || Math.Round(num8) == Math.Round(pointF.Y) || Math.Round(num8) == Math.Round(pointF2.Y); num8 += num6 * (float)smethod_35(baseUnitScale, smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, (int)axisRenderContext.MinValue, chart.IsDate1904), (int)axisRenderContext.MinValue, chart.IsDate1904))
				{
					if (flag)
					{
						axisRenderContext.method_3(num7, num8, num7 + num, num8);
					}
					if (flag2)
					{
						axisRenderContext.method_3(num7 - num, num8, num7, num8);
					}
					num7 += num5 * (float)smethod_35(baseUnitScale, smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, (int)axisRenderContext.MinValue, chart.IsDate1904), (int)axisRenderContext.MinValue, chart.IsDate1904);
				}
				bool flag3 = false;
				bool flag4 = false;
				switch (axisRenderContext.Axis.MinorTickMark)
				{
				case TickMarkType.Cross:
					flag3 = true;
					flag4 = true;
					break;
				case TickMarkType.Inside:
					if (chart.Rotation >= 90 && (chart.Rotation < 225 || chart.Rotation >= 270))
					{
						flag4 = true;
					}
					else
					{
						flag3 = true;
					}
					break;
				case TickMarkType.Outside:
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
				num7 = pointF.X;
				bool isDate;
				for (float num8 = pointF.Y; (pointF.Y <= num8 && num8 <= pointF2.Y) || (pointF.Y >= num8 && num8 >= pointF2.Y) || Math.Round(num8) == Math.Round(pointF.Y) || Math.Round(num8) == Math.Round(pointF2.Y); num8 += num6 * (float)smethod_35(baseUnitScale, smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MinorUnitScale, (int)axisRenderContext.MinorUnit, (int)axisRenderContext.MinValue, isDate), (int)axisRenderContext.MinValue, isDate))
				{
					if (flag3)
					{
						axisRenderContext.method_3(num7, num8, num7 + num2, num8);
					}
					if (flag4)
					{
						axisRenderContext.method_3(num7 - num2, num8, num7, num8);
					}
					isDate = chart.IsDate1904;
					num7 += num5 * (float)smethod_35(baseUnitScale, smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MinorUnitScale, (int)axisRenderContext.MinorUnit, (int)axisRenderContext.MinValue, isDate), (int)axisRenderContext.MinValue, isDate);
				}
			}
			else
			{
				bool flag5 = false;
				bool flag6 = false;
				switch (axisRenderContext.Axis.MajorTickMark)
				{
				case TickMarkType.Cross:
					flag5 = true;
					flag6 = true;
					break;
				case TickMarkType.Inside:
					if (chart.Elevation >= 0)
					{
						flag5 = true;
					}
					else
					{
						flag6 = true;
					}
					break;
				case TickMarkType.Outside:
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
				if (!axisRenderContext.Axis.IsPlotOrderReversed)
				{
					pointF = array[0];
					pointF2 = array[1];
				}
				else
				{
					pointF = array[1];
					pointF2 = array[0];
				}
				float num5 = (pointF2.X - pointF.X) / (float)num4;
				float num6 = (pointF2.Y - pointF.Y) / (float)num4;
				float num9 = pointF.X;
				float num10 = pointF.Y;
				while ((pointF.X <= num9 && num9 <= pointF2.X) || (pointF.X >= num9 && num9 >= pointF2.X) || Math.Round(num9) == Math.Round(pointF.X) || Math.Round(num9) == Math.Round(pointF2.X))
				{
					if (flag5)
					{
						axisRenderContext.method_3(num9, num10 - num, num9, num10);
					}
					if (flag6)
					{
						axisRenderContext.method_3(num9, num10, num9, num10 + num);
					}
					num9 += num5 * (float)smethod_35(baseUnitScale, smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, (int)axisRenderContext.MinValue, chart.IsDate1904), (int)axisRenderContext.MinValue, chart.IsDate1904);
					num10 += num6 * (float)smethod_35(baseUnitScale, smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, (int)axisRenderContext.MinValue, chart.IsDate1904), (int)axisRenderContext.MinValue, chart.IsDate1904);
				}
				bool flag7 = false;
				bool flag8 = false;
				switch (axisRenderContext.Axis.MinorTickMark)
				{
				case TickMarkType.Cross:
					flag7 = true;
					flag8 = true;
					break;
				case TickMarkType.Inside:
					if (chart.Elevation >= 0)
					{
						flag7 = true;
					}
					else
					{
						flag8 = true;
					}
					break;
				case TickMarkType.Outside:
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
				num9 = pointF.X;
				num10 = pointF.Y;
				while ((pointF.X <= num9 && num9 <= pointF2.X) || (pointF.X >= num9 && num9 >= pointF2.X) || Math.Round(num9) == Math.Round(pointF.X) || Math.Round(num9) == Math.Round(pointF2.X))
				{
					if (flag7)
					{
						axisRenderContext.method_3(num9, num10 - num2, num9, num10);
					}
					if (flag8)
					{
						axisRenderContext.method_3(num9, num10, num9, num10 + num2);
					}
					num9 += num5 * (float)smethod_35(baseUnitScale, smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MinorUnitScale, (int)axisRenderContext.MinorUnit, (int)axisRenderContext.MinValue, chart.IsDate1904), (int)axisRenderContext.MinValue, chart.IsDate1904);
					num10 += num6 * (float)smethod_35(baseUnitScale, smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MinorUnitScale, (int)axisRenderContext.MinorUnit, (int)axisRenderContext.MinValue, chart.IsDate1904), (int)axisRenderContext.MinValue, chart.IsDate1904);
				}
			}
			if (axisHeight > 0)
			{
				array[0].Y -= axisHeight;
				array[1].Y -= axisHeight;
				axisHeight = 0;
				continue;
			}
			break;
		}
	}

	internal static void smethod_56(Interface32 g, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if (chart.PlotAreaInternal.method_16())
		{
			return;
		}
		ChartType type = chart.Type;
		PointF[] array = Struct25.smethod_3(chart);
		axisRenderContext.method_3(array[0].X, array[0].Y, array[1].X, array[1].Y);
		Class759 @class = chart.NSeriesInternal.method_0(0);
		Class748 class2 = @class.PointsInternal.method_0(0);
		string format = class2.YFormat;
		bool yValueIsCulture = class2.YValueIsCulture;
		float num = 0f;
		num = array[0].Y + smethod_0(axisRenderContext.TickLabelTextFont.Size);
		ArrayList arrayList_ = axisRenderContext.arrayList_0;
		double num2 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MaxValue) : axisRenderContext.MaxValue);
		double num3 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MinValue) : axisRenderContext.MinValue);
		double num4 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_0(axisRenderContext.MajorUnit) : axisRenderContext.MajorUnit);
		for (int i = 0; i < axisRenderContext.arrayList_0.Count; i++)
		{
			double num5 = (double)axisRenderContext.arrayList_0[i];
			double num6 = (axisRenderContext.Axis.IsLogarithmic ? axisRenderContext.method_1(num5) : num5);
			if (i - 1 > 0)
			{
				if (Math.Abs(Struct41.smethod_11(num5, (double)arrayList_[i - 1])) != num4)
				{
					continue;
				}
			}
			else if (i + 1 < arrayList_.Count && Math.Abs(Struct41.smethod_11(num5, (double)arrayList_[i + 1])) != num4)
			{
				continue;
			}
			float num7 = (float)((num5 - num3) / (num2 - num3) * (double)chart.WallsInternal.Width);
			num7 = (axisRenderContext.Axis.IsPlotOrderReversed ? (array[1].X - num7) : (array[0].X + num7));
			if (axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
			{
				if (Struct24.smethod_42(type))
				{
					num6 /= 100.0;
					format = "0%";
				}
				string text = "";
				num6 = (axisRenderContext.Axis.IsLogarithmic ? num6 : (num6 * smethod_22(axisRenderContext)));
				Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
				if (axisRenderContext.IsLinkedSource)
				{
					text = Struct28.smethod_5(num6, format, yValueIsCulture);
					tickLabelFontColor = Struct28.smethod_6(num6, format, tickLabelFontColor);
				}
				else
				{
					text = smethod_34(num6, axisRenderContext);
					tickLabelFontColor = Struct28.smethod_6(num6, axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
				}
				RectangleF value = new RectangleF(num7 - axisRenderContext.float_1 / 2f, num, axisRenderContext.float_1, axisRenderContext.float_2);
				smethod_44(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, Enum157.const_1, Enum157.const_9);
			}
		}
		smethod_57(axisRenderContext);
	}

	private static void smethod_57(Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if ((axisRenderContext.Axis.MajorTickMark == TickMarkType.None && axisRenderContext.Axis.MinorTickMark == TickMarkType.None) || !axisRenderContext.Axis.IsVisible)
		{
			return;
		}
		PointF[] array = Struct25.smethod_3(chart);
		bool flag = false;
		bool flag2 = false;
		switch (axisRenderContext.Axis.MajorTickMark)
		{
		case TickMarkType.Cross:
			flag = true;
			flag2 = true;
			break;
		case TickMarkType.Inside:
			flag = true;
			break;
		case TickMarkType.Outside:
			flag2 = true;
			break;
		}
		PointF pointF;
		PointF pointF2;
		if (!axisRenderContext.Axis.IsPlotOrderReversed)
		{
			pointF = array[0];
			pointF2 = array[1];
		}
		else
		{
			pointF = array[1];
			pointF2 = array[0];
		}
		float num = (float)((double)(pointF2.X - pointF.X) / (axisRenderContext.MaxValue - axisRenderContext.MinValue));
		float num2 = pointF.X;
		float y = pointF.Y;
		float num3 = smethod_0(axisRenderContext.TickLabelTextFont.Size);
		for (; (pointF.X <= num2 && num2 <= pointF2.X) || (pointF.X >= num2 && num2 >= pointF2.X) || Math.Round(num2) == Math.Round(pointF.X) || Math.Round(num2) == Math.Round(pointF2.X); num2 += num * (float)axisRenderContext.MajorUnit)
		{
			if (flag)
			{
				axisRenderContext.method_3(num2, y - num3, num2, y);
			}
			if (flag2)
			{
				axisRenderContext.method_3(num2, y, num2, y + num3);
			}
		}
		flag = false;
		flag2 = false;
		switch (axisRenderContext.Axis.MinorTickMark)
		{
		case TickMarkType.Cross:
			flag = true;
			flag2 = true;
			break;
		case TickMarkType.Inside:
			flag = true;
			break;
		case TickMarkType.Outside:
			flag2 = true;
			break;
		}
		num2 = pointF.X;
		y = pointF.Y;
		float num4 = smethod_1(axisRenderContext.TickLabelTextFont.Size);
		for (; (pointF.X <= num2 && num2 <= pointF2.X) || (pointF.X >= num2 && num2 >= pointF2.X) || Math.Round(num2) == Math.Round(pointF.X) || Math.Round(num2) == Math.Round(pointF2.X); num2 += num * (float)axisRenderContext.MinorUnit)
		{
			if (flag)
			{
				axisRenderContext.method_3(num2, y - num4, num2, y);
			}
			if (flag2)
			{
				axisRenderContext.method_3(num2, y, num2, y + num4);
			}
		}
	}

	internal static void smethod_58(Interface32 g, int maxPointsCount, Rectangle plotAreaRect, Class783 axisRenderContext, Class784 renderContext)
	{
		Class740 chart = renderContext.Chart2007;
		if (chart.PlotAreaInternal.method_16())
		{
			return;
		}
		if (axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_59(g, axisRenderContext, renderContext);
			return;
		}
		PointF[] array = Struct25.smethod_3(chart);
		double num = ((!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed) ? ((double)renderContext.Y1AxisRenderContext.CrossAt - renderContext.Y1AxisRenderContext.MinValue) : (renderContext.Y1AxisRenderContext.MaxValue - (double)renderContext.Y1AxisRenderContext.CrossAt));
		int num2 = (int)(num / (renderContext.Y1AxisRenderContext.MaxValue - renderContext.Y1AxisRenderContext.MinValue) * (double)chart.WallsInternal.Width);
		if (num2 != 0)
		{
			axisRenderContext.method_3(array[0].X + (float)num2, array[0].Y, array[0].X + (float)num2, array[0].Y - chart.WallsInternal.Height);
		}
		if (chart.Elevation >= 0)
		{
			axisRenderContext.method_3(array[0].X, array[0].Y, array[0].X, array[0].Y - chart.WallsInternal.Height);
		}
		if (axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.NextTo)
		{
			array[0].X += num2;
		}
		float num3 = 0f;
		float num4 = axisRenderContext.TickLabelsOffsetPixel;
		if (axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
		{
			float size = axisRenderContext.TickLabelTextFont.Size;
			num4 += smethod_0(size) + smethod_1(size);
		}
		Enum157 horizontalAlignment = Enum157.const_8;
		num3 = array[0].X - axisRenderContext.float_4 - num4;
		float num5 = chart.WallsInternal.Height / (float)maxPointsCount;
		List<Interface8> categoryLabelsInternal = chart.NSeriesInternal.CategoryLabelsInternal;
		bool flag = axisRenderContext.IsLinkedSource && categoryLabelsInternal.Count > 0;
		for (int i = 0; i < maxPointsCount; i++)
		{
			double num6 = (float)i * num5;
			num6 += (double)(num5 / 2f);
			float y = ((!axisRenderContext.Axis.IsPlotOrderReversed) ? ((float)((double)array[0].Y - num6) - axisRenderContext.float_3 / 2f) : ((float)((double)(array[0].Y - chart.WallsInternal.Height) + num6) - axisRenderContext.float_3 / 2f));
			if (axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None && i % axisRenderContext.TickLabelSpacing == 0 && i < axisRenderContext.arrayList_0.Count)
			{
				string text = "";
				Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
				if (!flag)
				{
					text = smethod_34(axisRenderContext.arrayList_0[i], axisRenderContext);
					tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
				}
				else
				{
					string text2 = "";
					bool flag2 = false;
					text2 = ((i < categoryLabelsInternal.Count) ? ((Class743)categoryLabelsInternal[i]).SourceFormat : "");
					flag2 = i < categoryLabelsInternal.Count && ((Class743)categoryLabelsInternal[i]).IsCulture;
					text = Struct28.smethod_5(axisRenderContext.arrayList_0[i], text2, flag2);
					tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], text2, tickLabelFontColor);
				}
				RectangleF value = new RectangleF(num3, y, axisRenderContext.float_4, axisRenderContext.float_3);
				smethod_44(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, horizontalAlignment, Enum157.const_1);
			}
		}
		smethod_60(num2, maxPointsCount, axisRenderContext);
		List<Interface8>[] categories = chart.NSeriesInternal.Categories;
		if (categories != null && categories.Length > 0 && categoryLabelsInternal.Count > 0 && axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
		{
			float num7 = 0f;
			num7 = (axisRenderContext.Axis.IsPlotOrderReversed ? (array[0].Y - chart.WallsInternal.Height) : array[0].Y);
			num3 = array[0].X - num4 * (float)(categories.Length + 1) - axisRenderContext.float_1;
			float x = array[0].X;
			smethod_14(g, categories, isPlus: true, num5, plotAreaRect, num4, x, num3, num7, axisRenderContext);
		}
	}

	private static void smethod_59(Interface32 g, Class783 axisRenderContext, Class784 renderContext)
	{
		Class740 chart = renderContext.Chart2007;
		Class764 wallsInternal = chart.WallsInternal;
		PointF[] array = Struct25.smethod_3(chart);
		double num = ((!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed) ? ((double)renderContext.Y1AxisRenderContext.CrossAt - renderContext.Y1AxisRenderContext.MinValue) : (renderContext.Y1AxisRenderContext.MaxValue - (double)renderContext.Y1AxisRenderContext.CrossAt));
		int num2 = (int)(num / (renderContext.Y1AxisRenderContext.MaxValue - renderContext.Y1AxisRenderContext.MinValue) * (double)chart.WallsInternal.Width);
		if (num2 != 0)
		{
			axisRenderContext.method_3(array[0].X + (float)num2, array[0].Y, array[0].X + (float)num2, array[0].Y - chart.WallsInternal.Height);
		}
		if (chart.Elevation >= 0)
		{
			axisRenderContext.method_3(array[0].X, array[0].Y, array[0].X, array[0].Y - chart.WallsInternal.Height);
		}
		if (axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.NextTo)
		{
			array[0].X += num2;
		}
		ArrayList arrayList_ = axisRenderContext.arrayList_0;
		float num3 = 0f;
		float num4 = axisRenderContext.TickLabelsOffsetPixel;
		float num5 = axisRenderContext.float_2 / 2f;
		Enum157 horizontalAlignment = Enum157.const_8;
		num3 = array[0].X - axisRenderContext.float_1 - num4;
		List<Interface8> categoryLabelsInternal = chart.NSeriesInternal.CategoryLabelsInternal;
		bool flag = axisRenderContext.IsLinkedSource && categoryLabelsInternal.Count > 0;
		int maxValue = (int)axisRenderContext.MaxValue;
		int minValue = (int)axisRenderContext.MinValue;
		TimeUnitType baseUnitScale = axisRenderContext.Axis.BaseUnitScale;
		int num6 = smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		float num7 = wallsInternal.Height / (float)num6;
		for (int i = 0; i < arrayList_.Count; i++)
		{
			int maxValue2 = Convert.ToInt32(axisRenderContext.arrayList_0[i]);
			int num8 = smethod_35(baseUnitScale, maxValue2, minValue, chart.IsDate1904);
			float num9 = num7 * (float)num8;
			num9 += num7 / 2f;
			float num10 = (axisRenderContext.Axis.IsPlotOrderReversed ? (array[0].Y - chart.WallsInternal.Height + num9) : (array[0].Y - num9));
			if (axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None && i % axisRenderContext.TickLabelSpacing == 0 && i < axisRenderContext.arrayList_0.Count)
			{
				string text = "";
				Color tickLabelFontColor = axisRenderContext.TickLabelFontColor;
				if (!flag)
				{
					text = smethod_34(axisRenderContext.arrayList_0[i], axisRenderContext);
					tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], axisRenderContext.Axis.NumberFormat, tickLabelFontColor);
				}
				else
				{
					string text2 = "";
					bool flag2 = false;
					text2 = ((i < categoryLabelsInternal.Count) ? ((Class743)categoryLabelsInternal[i]).SourceFormat : "");
					flag2 = i < categoryLabelsInternal.Count && ((Class743)categoryLabelsInternal[i]).IsCulture;
					text = Struct28.smethod_5(axisRenderContext.arrayList_0[i], text2, flag2);
					tickLabelFontColor = Struct28.smethod_6(axisRenderContext.arrayList_0[i], text2, tickLabelFontColor);
				}
				RectangleF value = new RectangleF(num3, num10 - num5, axisRenderContext.float_1, axisRenderContext.float_2);
				smethod_44(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, tickLabelFontColor, horizontalAlignment, Enum157.const_1);
			}
		}
		smethod_61(g, num2, axisRenderContext);
	}

	private static void smethod_60(int axisHeight, int maxPointsCount, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		Class764 wallsInternal = chart.WallsInternal;
		if ((axisRenderContext.Axis.MajorTickMark == TickMarkType.None && axisRenderContext.Axis.MinorTickMark == TickMarkType.None) || !axisRenderContext.Axis.IsVisible)
		{
			return;
		}
		PointF[] array = Struct25.smethod_3(chart);
		while (true)
		{
			bool flag = false;
			bool flag2 = false;
			switch (axisRenderContext.Axis.MajorTickMark)
			{
			case TickMarkType.Outside:
				flag2 = true;
				break;
			case TickMarkType.Inside:
				flag = true;
				break;
			case TickMarkType.Cross:
				flag = true;
				flag2 = true;
				break;
			}
			bool flag3 = false;
			bool flag4 = false;
			switch (axisRenderContext.Axis.MinorTickMark)
			{
			case TickMarkType.Cross:
				flag3 = true;
				flag4 = true;
				break;
			case TickMarkType.Inside:
				flag3 = true;
				break;
			case TickMarkType.Outside:
				flag4 = true;
				break;
			}
			PointF pointF;
			PointF pointF2;
			if (axisRenderContext.Axis.IsPlotOrderReversed)
			{
				pointF = new PointF(array[0].X, array[0].Y - wallsInternal.Height);
				pointF2 = new PointF(array[0].X, array[0].Y);
			}
			else
			{
				pointF = new PointF(array[0].X, array[0].Y);
				pointF2 = new PointF(array[0].X, array[0].Y - wallsInternal.Height);
			}
			float num = (pointF2.Y - pointF.Y) / (float)maxPointsCount;
			float x = pointF.X;
			float num2 = pointF.Y;
			float num3 = smethod_0(axisRenderContext.TickLabelTextFont.Size);
			for (; (pointF.Y <= num2 && num2 <= pointF2.Y) || (pointF.Y >= num2 && num2 >= pointF2.Y) || Math.Round(num2) == Math.Round(pointF.Y) || Math.Round(num2) == Math.Round(pointF2.Y); num2 += (float)axisRenderContext.TickMarkSpacing * num)
			{
				if ((pointF.Y <= num2 && num2 <= pointF2.Y) || (pointF.Y >= num2 && num2 >= pointF2.Y) || Math.Round(num2) == Math.Round(pointF.Y) || Math.Round(num2) == Math.Round(pointF2.Y))
				{
					if (flag)
					{
						axisRenderContext.method_3(x, num2, x + num3, num2);
					}
					if (flag2)
					{
						axisRenderContext.method_3(x - num3, num2, x, num2);
					}
				}
				float num4 = num2 - (float)axisRenderContext.TickMarkSpacing * num / 2f;
				if ((pointF.Y <= num4 && num4 <= pointF2.Y) || (pointF.Y >= num4 && num4 >= pointF2.Y) || Math.Round(num4) == Math.Round(pointF.Y) || Math.Round(num4) == Math.Round(pointF2.Y))
				{
					if (flag3)
					{
						axisRenderContext.method_3(x, num4, x + num3, num4);
					}
					if (flag4)
					{
						axisRenderContext.method_3(x - num3, num4, x, num4);
					}
				}
			}
			if ((float)axisRenderContext.TickMarkSpacing * num > pointF2.Y - pointF.Y)
			{
				float num5 = num2 - (float)axisRenderContext.TickMarkSpacing * num / 2f;
				if ((pointF.Y <= num5 && num5 <= pointF2.Y) || (pointF.Y >= num5 && num5 >= pointF2.Y) || Math.Round(num5) == Math.Round(pointF.Y) || Math.Round(num5) == Math.Round(pointF2.Y))
				{
					if (flag3)
					{
						axisRenderContext.method_3(x, num5, x + num3, num5);
					}
					if (flag4)
					{
						axisRenderContext.method_3(x - num3, num5, x, num5);
					}
				}
			}
			if (axisHeight > 0)
			{
				array[0].X += axisHeight;
				axisHeight = 0;
				continue;
			}
			break;
		}
	}

	private static void smethod_61(Interface32 g, int axisHeight, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		Class764 wallsInternal = chart.WallsInternal;
		if ((axisRenderContext.Axis.MajorTickMark == TickMarkType.None && axisRenderContext.Axis.MinorTickMark == TickMarkType.None) || !axisRenderContext.Axis.IsVisible)
		{
			return;
		}
		PointF[] array = Struct25.smethod_3(chart);
		while (true)
		{
			bool flag = false;
			bool flag2 = false;
			switch (axisRenderContext.Axis.MajorTickMark)
			{
			case TickMarkType.Outside:
				flag2 = true;
				break;
			case TickMarkType.Inside:
				flag = true;
				break;
			case TickMarkType.Cross:
				flag = true;
				flag2 = true;
				break;
			}
			PointF pointF;
			PointF pointF2;
			if (axisRenderContext.Axis.IsPlotOrderReversed)
			{
				pointF = new PointF(array[0].X, array[0].Y - wallsInternal.Height);
				pointF2 = new PointF(array[0].X, array[0].Y);
			}
			else
			{
				pointF = new PointF(array[0].X, array[0].Y);
				pointF2 = new PointF(array[0].X, array[0].Y - wallsInternal.Height);
			}
			TimeUnitType baseUnitScale = axisRenderContext.Axis.BaseUnitScale;
			double num = ((axisRenderContext.AxisType != 0 || axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2) ? (axisRenderContext.MaxValue - axisRenderContext.MinValue) : ((double)(smethod_35(baseUnitScale, (int)axisRenderContext.MaxValue, (int)axisRenderContext.MinValue, chart.IsDate1904) + 1)));
			float num2 = (float)((double)(pointF2.Y - pointF.Y) / num);
			float x = pointF.X;
			float num3 = pointF.Y;
			float num4 = smethod_0(axisRenderContext.TickLabelTextFont.Size);
			for (; (pointF.Y <= num3 && num3 <= pointF2.Y) || (pointF.Y >= num3 && num3 >= pointF2.Y) || Math.Round(num3) == Math.Round(pointF.Y) || Math.Round(num3) == Math.Round(pointF2.Y); num3 += num2 * (float)smethod_35(baseUnitScale, smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, (int)axisRenderContext.MinValue, chart.IsDate1904), (int)axisRenderContext.MinValue, chart.IsDate1904))
			{
				if (flag)
				{
					axisRenderContext.method_3(x, num3, x + num4, num3);
				}
				if (flag2)
				{
					axisRenderContext.method_3(x - num4, num3, x, num3);
				}
			}
			bool flag3 = false;
			bool flag4 = false;
			switch (axisRenderContext.Axis.MinorTickMark)
			{
			case TickMarkType.Cross:
				flag3 = true;
				flag4 = true;
				break;
			case TickMarkType.Inside:
				flag3 = true;
				break;
			case TickMarkType.Outside:
				flag4 = true;
				break;
			}
			x = pointF.X;
			num3 = pointF.Y;
			float num5 = smethod_1(axisRenderContext.TickLabelTextFont.Size);
			for (; (pointF.Y <= num3 && num3 <= pointF2.Y) || (pointF.Y >= num3 && num3 >= pointF2.Y) || Math.Round(num3) == Math.Round(pointF.Y) || Math.Round(num3) == Math.Round(pointF2.Y); num3 += num2 * (float)smethod_35(baseUnitScale, smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MinorUnitScale, (int)axisRenderContext.MinorUnit, (int)axisRenderContext.MinValue, chart.IsDate1904), (int)axisRenderContext.MinValue, chart.IsDate1904))
			{
				if (flag3)
				{
					axisRenderContext.method_3(x, num3, x + num5, num3);
				}
				if (flag4)
				{
					axisRenderContext.method_3(x - num5, num3, x, num3);
				}
			}
			if (axisHeight > 0)
			{
				array[0].X += axisHeight;
				axisHeight = 0;
				continue;
			}
			break;
		}
	}

	internal static void smethod_62(Interface32 g, Class783 axisRenderContext, Class784 renderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if (chart.PlotAreaInternal.method_16())
		{
			return;
		}
		PointF[] array = Struct25.smethod_4(chart);
		double logMaxValue = renderContext.Y1AxisRenderContext.LogMaxValue;
		double logMinValue = renderContext.Y1AxisRenderContext.LogMinValue;
		double logCrossAt = renderContext.Y1AxisRenderContext.LogCrossAt;
		bool flag = renderContext.Y1AxisRenderContext.MinValue == (double)renderContext.Y1AxisRenderContext.CrossAt;
		logCrossAt = ((!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed) ? (logCrossAt - logMinValue) : (logMaxValue - logCrossAt));
		int num = (int)(logCrossAt / (logMaxValue - logMinValue) * (double)chart.WallsInternal.Height);
		if (num != 0)
		{
			axisRenderContext.method_3(array[0].X, array[0].Y - (float)num, array[1].X, array[1].Y - (float)num);
		}
		if (chart.Elevation >= 0)
		{
			axisRenderContext.method_3(array[0].X, array[0].Y, array[1].X, array[1].Y);
		}
		if (axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.NextTo)
		{
			array[0].Y -= num;
			array[1].Y -= num;
		}
		float num2 = axisRenderContext.TickLabelsOffsetPixel;
		double num3 = ((array[1].X == array[0].X) ? (Math.PI / 2.0) : Math.Atan(Math.Abs((array[0].Y - array[1].Y) / (array[1].X - array[0].X))));
		float num4 = (array[1].X - array[0].X) / (float)axisRenderContext.arrayList_0.Count;
		float num5 = (array[1].Y - array[0].Y) / (float)axisRenderContext.arrayList_0.Count;
		for (int i = 0; i < axisRenderContext.arrayList_0.Count; i++)
		{
			int num6 = i;
			if (axisRenderContext.Axis.IsPlotOrderReversed)
			{
				num6 = axisRenderContext.arrayList_0.Count - 1 - i;
			}
			string text = "";
			text = smethod_34(axisRenderContext.arrayList_0[num6], axisRenderContext);
			if (axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.None || num6 % axisRenderContext.TickLabelSpacing != 0)
			{
				continue;
			}
			RectangleF value = new RectangleF(0f, 0f, 0f, 0f);
			if (chart.Elevation >= 0)
			{
				if (array[0].Y == array[1].Y)
				{
					value.X = ((num4 < 0f) ? (array[0].X + (float)(i + 1) * num4) : (array[0].X + (float)i * num4));
					value.Y = array[0].Y + num2;
					value.Width = Math.Abs(num4);
					value.Height = axisRenderContext.float_2;
				}
				else if (num3 <= Math.PI / 4.0)
				{
					value.X = ((num4 < 0f) ? (array[0].X + (float)(i + 1) * num4) : (array[0].X + (float)i * num4));
					value.Y = ((num5 > 0f) ? (array[0].Y + (float)(i + 1) * num5) : (array[0].Y + (float)i * num5));
					value.Width = Math.Abs(num4);
					value.Height = axisRenderContext.float_2;
				}
				else
				{
					value.X = ((num5 > 0f) ? (array[0].X + (float)i * num4) : (array[0].X + (float)(i + 1) * num4));
					value.X = ((num4 * num5 <= 0f) ? (value.X + num2 * (float)Math.Sin(num3)) : (value.X - num2 * (float)Math.Sin(num3) - axisRenderContext.float_1));
					value.Y = ((num5 > 0f) ? (array[0].Y + (float)i * num5) : (array[0].Y + (float)(i + 1) * num5));
					value.Y += (Math.Abs(num5) - axisRenderContext.float_2) * (float)Math.Sin(num3) / 2f;
					value.Width = axisRenderContext.float_1;
					value.Height = axisRenderContext.float_2;
				}
			}
			else if (chart.Elevation < 0 && !flag && axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.NextTo)
			{
				if (array[0].Y == array[1].Y)
				{
					value.X = ((num4 > 0f) ? (array[0].X + (float)i * num4) : (array[0].X + (float)(i + 1) * num4));
					value.Y = array[0].Y - axisRenderContext.float_2 - num2;
					value.Width = Math.Abs(num4);
					value.Height = axisRenderContext.float_2;
				}
				else if (num3 <= Math.PI / 4.0)
				{
					value.X = ((num4 < 0f) ? (array[0].X + (float)(i + 1) * num4) : (array[0].X + (float)i * num4));
					value.Y = ((num5 < 0f) ? (array[0].Y + (float)(i + 1) * num5) : (array[0].Y + (float)i * num5));
					value.Y -= axisRenderContext.float_2;
					value.Width = Math.Abs(num4);
					value.Height = axisRenderContext.float_2;
				}
				else
				{
					value.X = ((num5 < 0f) ? (array[0].X + (float)i * num4) : (array[0].X + (float)(i + 1) * num4));
					value.X = ((num4 * num5 >= 0f) ? (value.X + num2 * (float)Math.Sin(num3)) : (value.X - num2 * (float)Math.Sin(num3) - axisRenderContext.float_1));
					value.Y = ((num5 < 0f) ? (array[0].Y + (float)i * num5) : (array[0].Y + (float)(i + 1) * num5));
					value.Y -= (Math.Abs(num5) - axisRenderContext.float_2) * (float)Math.Sin(num3) / 2f;
					value.Y -= axisRenderContext.float_2;
					value.Width = axisRenderContext.float_1;
					value.Height = axisRenderContext.float_2;
				}
			}
			value.Width = axisRenderContext.float_1;
			value.Height = axisRenderContext.float_2;
			smethod_44(g, Rectangle.Round(value), text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, axisRenderContext.TickLabelFontColor, Enum157.const_1, Enum157.const_1);
		}
		smethod_54(g, num, axisRenderContext.arrayList_0.Count, axisRenderContext);
	}
}
