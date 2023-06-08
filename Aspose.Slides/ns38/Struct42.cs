using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using ns2;
using ns33;
using ns35;
using ns36;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct42
{
	internal static ArrayList smethod_0(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		_ = aSeries.Chart;
		Enum141 axisGroup = aSeries.AxisGroup;
		Class783 @class;
		Class783 class2;
		if (axisGroup == Enum141.const_0)
		{
			@class = renderContext.Y1AxisRenderContext;
			class2 = renderContext.X1AxisRenderContext;
		}
		else
		{
			@class = renderContext.Y2AxisRenderContext;
			class2 = renderContext.X2AxisRenderContext;
		}
		double logMinValue = @class.LogMinValue;
		double logMaxValue = @class.LogMaxValue;
		categoryAxisCrossAt = (@class.Axis.IsLogarithmic ? @class.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
		double logMinValue2 = class2.LogMinValue;
		double logMaxValue2 = class2.LogMaxValue;
		ArrayList arrayList = new ArrayList();
		double num = (double)rect.Width / (logMaxValue2 - logMinValue2);
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		Class747 pointsInternal = aSeries.PointsInternal;
		for (int i = 0; i < maxPointsCount; i++)
		{
			Class748 class3 = pointsInternal.method_0(i);
			if (class3 != null && !class3.NotPlotted && !class3.XNotPlotted)
			{
				double num2 = (double)(float)num * (class3.XValue - logMinValue2);
				num2 = ((!class2.Axis.IsPlotOrderReversed) ? ((double)rect.X + num2) : ((double)(rect.X + rect.Width) - num2));
				double num3 = categoryAxisY;
				double yValue = class3.YValue;
				double num4 = (yValue - categoryAxisCrossAt) / (logMaxValue - logMinValue) * (double)rect.Height;
				Class752 xErrorBarInternal = aSeries.XErrorBarInternal;
				PointF originPoint = new PointF((float)num2, categoryAxisY);
				double num5 = 0.0;
				double num6 = 0.0;
				float minusHeight = 0f;
				float plusHeight = 0f;
				if (xErrorBarInternal != null)
				{
					switch (xErrorBarInternal.Type)
					{
					case ErrorBarValueType.Custom:
					{
						double num7 = 0.0;
						try
						{
							num7 = ((xErrorBarInternal.MinusValue.Count > i) ? Convert.ToDouble(xErrorBarInternal.MinusValue[i]) : 0.0);
						}
						catch (Exception ex)
						{
							Class1165.smethod_28(ex);
						}
						num5 = num7;
						try
						{
							num7 = ((xErrorBarInternal.PlusValue.Count > i) ? Convert.ToDouble(xErrorBarInternal.PlusValue[i]) : 0.0);
						}
						catch (Exception ex2)
						{
							Class1165.smethod_28(ex2);
						}
						num6 = num7;
						break;
					}
					case ErrorBarValueType.Fixed:
						num5 = xErrorBarInternal.Amount;
						num6 = num5;
						break;
					case ErrorBarValueType.Percentage:
						num5 = xErrorBarInternal.Amount * yValue / 100.0;
						num6 = num5;
						break;
					}
					minusHeight = (float)(num5 / (logMaxValue2 - logMinValue2) * (double)rect.Width);
					plusHeight = (float)(num6 / (logMaxValue2 - logMinValue2) * (double)rect.Width);
					if (!@class.Axis.IsPlotOrderReversed)
					{
						originPoint.Y -= (float)num4;
					}
					else
					{
						originPoint.Y += (float)num4;
					}
				}
				xErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
				Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
				num5 = 0.0;
				num6 = 0.0;
				minusHeight = 0f;
				plusHeight = 0f;
				if (yErrorBarInternal != null)
				{
					switch (yErrorBarInternal.Type)
					{
					case ErrorBarValueType.Custom:
					{
						double num8 = 0.0;
						try
						{
							num8 = ((yErrorBarInternal.MinusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.MinusValue[i]) : 0.0);
						}
						catch (Exception ex3)
						{
							Class1165.smethod_28(ex3);
						}
						num5 = num8;
						try
						{
							num8 = ((yErrorBarInternal.PlusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.PlusValue[i]) : 0.0);
						}
						catch (Exception ex4)
						{
							Class1165.smethod_28(ex4);
						}
						num6 = num8;
						break;
					}
					case ErrorBarValueType.Fixed:
						num5 = yErrorBarInternal.Amount;
						num6 = num5;
						break;
					case ErrorBarValueType.Percentage:
						num5 = yErrorBarInternal.Amount * class3.YValue / 100.0;
						num6 = num5;
						break;
					}
					minusHeight = (float)num5 / (float)(logMaxValue - logMinValue) * (float)rect.Height;
					plusHeight = (float)num6 / (float)(logMaxValue - logMinValue) * (float)rect.Height;
				}
				yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
				num3 = (@class.Axis.IsPlotOrderReversed ? (num3 + num4) : (num3 - num4));
				PointF pointF = new PointF((float)num2, (float)num3);
				arrayList3.Add(pointF);
				Class750 dataLabelsInternal = class3.DataLabelsInternal;
				if (dataLabelsInternal.IsShown)
				{
					arrayList.Add(new object[4] { aSeries.Index, i, pointF, class2 });
				}
			}
			else
			{
				arrayList3.Add(null);
			}
		}
		if (arrayList3.Count > 1)
		{
			Struct27.smethod_7(g, aSeries, arrayList3, rect);
		}
		smethod_1(g, aSeries, arrayList3, rect);
		arrayList2.Add(arrayList3);
		return arrayList;
	}

	internal static void smethod_1(Interface32 g, Class759 aSeries, IList list, Rectangle plotArea)
	{
		plotArea = new Rectangle(plotArea.X, plotArea.Y, plotArea.Width, plotArea.Height);
		plotArea.Inflate(1, 1);
		for (int i = 0; i < list.Count; i++)
		{
			Class748 @class = aSeries.PointsInternal.method_0(i);
			object obj = list[i];
			if (obj != null)
			{
				PointF pointF = (PointF)obj;
				if (!(pointF.X < (float)plotArea.X) && !(pointF.Y < (float)plotArea.Y) && !(pointF.X > (float)plotArea.Right) && !(pointF.Y > (float)plotArea.Bottom) && @class.MarkerInternal.IsVisible)
				{
					@class.MarkerInternal.method_4(pointF.X, pointF.Y);
				}
			}
		}
	}
}
