using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using ns2;
using ns35;
using ns36;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct38
{
	internal static List<object[]> smethod_0(Interface32 g, Class759 aSeries, Rectangle rect, int maxPointsCount, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		Enum141 axisGroup = aSeries.AxisGroup;
		ChartType[] array = new ChartType[3]
		{
			ChartType.Radar,
			ChartType.RadarWithMarkers,
			ChartType.FilledRadar
		};
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
		_ = chart.NSeriesInternal;
		List<object[]> list = new List<object[]>();
		double num = (double)rect.X + (double)rect.Width / 2.0;
		double num2 = (double)rect.Y + (double)rect.Height / 2.0;
		double num3 = rect.Width / 2;
		double num4 = Math.PI * 2.0 / (double)maxPointsCount;
		int index = aSeries.Index;
		ArrayList arrayList = new ArrayList();
		List<PointF> list2 = new List<PointF>();
		Class747 pointsInternal = aSeries.PointsInternal;
		double num5 = Math.PI / 2.0;
		for (int i = 0; i < maxPointsCount; i++)
		{
			Class748 class3 = pointsInternal.method_0(i);
			if (class3 != null)
			{
				double num6 = Math.Abs(class3.YValue - @class.MinValue);
				double num7 = num3 * num6 / (@class.MaxValue - @class.MinValue);
				double num8 = num + num7 * Math.Cos(num5);
				double num9 = num2 - num7 * Math.Sin(num5);
				PointF pointF = new PointF((float)num8, (float)num9);
				arrayList.Add(pointF);
				list2.Add(pointF);
				aSeries.MarkerInternal.method_5((float)num8, (float)num9, aSeries.MarkerInternal.MarkerSize);
				double num10 = num + num7 * 1.2 * Math.Cos(num5);
				double num11 = num2 - num7 * 1.2 * Math.Sin(num5);
				list.Add(new object[5]
				{
					index,
					i,
					new PointF((float)num10, (float)num11),
					class2,
					num3
				});
			}
			else
			{
				arrayList.Add(null);
				list2.Add(new PointF((float)num, (float)num2));
			}
			if (i == maxPointsCount - 1)
			{
				class3 = pointsInternal.method_0(0);
				if (class3 != null)
				{
					double num12 = Math.Abs(class3.YValue - @class.MinValue);
					double num13 = num3 * num12 / (@class.MaxValue - @class.MinValue);
					double num14 = num + num13 * Math.Cos(Math.PI / 2.0);
					double num15 = num2 - num13 * Math.Sin(Math.PI / 2.0);
					PointF pointF2 = new PointF((float)num14, (float)num15);
					arrayList.Add(pointF2);
				}
				else
				{
					arrayList.Add(null);
				}
			}
			num5 -= num4;
		}
		if (aSeries.ResembleType != ChartType.FilledRadar)
		{
			if (arrayList.Count > 1)
			{
				Struct27.smethod_7(g, aSeries, arrayList, rect);
			}
		}
		else
		{
			smethod_2(g, list2, aSeries);
		}
		return list;
	}

	internal static void smethod_1(Interface32 g, Class740 chart, ArrayList paramOfDataLabels, Class784 renderContext)
	{
		for (int i = 0; i < paramOfDataLabels.Count; i++)
		{
			object[] array = (object[])paramOfDataLabels[i];
			int seriesIndex = (int)array[0];
			int chartPointIndex = (int)array[1];
			PointF pointF = (PointF)array[2];
			Class783 @class = (Class783)array[3];
			Class783 axisRenderContext = ((@class == renderContext.X1AxisRenderContext) ? renderContext.X1AxisRenderContext : renderContext.X2AxisRenderContext);
			int scaleWidth = Convert.ToInt32(array[4]);
			Struct27.smethod_20(g, seriesIndex, chartPointIndex, pointF, scaleWidth, renderContext, axisRenderContext, 0f);
		}
	}

	private static void smethod_2(Interface32 g, IList list, Class759 aSeries)
	{
		PointF[] array = new PointF[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			PointF pointF = (PointF)list[i];
			array[i] = pointF;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(array);
		aSeries.AreaInternal.method_6(graphicsPath);
		aSeries.LineInternal.method_8(graphicsPath);
	}
}
