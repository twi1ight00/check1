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
internal struct Struct60
{
	internal static ArrayList smethod_0(Interface42 interface42_0, Class844 class844_0, Rectangle rectangle_0, int int_0)
	{
		Class821 chart = class844_0.Chart;
		Enum53 @enum = class844_0.method_20();
		ChartType_Chart[] array = new ChartType_Chart[3]
		{
			ChartType_Chart.Radar,
			ChartType_Chart.RadarWithDataMarkers,
			ChartType_Chart.RadarFilled
		};
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
		ArrayList arrayList = new ArrayList();
		double num = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0;
		double num2 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0;
		double num3 = rectangle_0.Width / 2;
		double num4 = Math.PI * 2.0 / (double)int_0;
		int index = class844_0.Index;
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		Class830 class4 = class844_0.method_9();
		double num5 = Math.PI / 2.0;
		for (int i = 0; i < int_0; i++)
		{
			Class831 class5 = class4.method_1(i);
			if (class5 != null)
			{
				double num6 = Math.Abs(class5.YValue - class2.MinValue);
				double num7 = num3 * num6 / (class2.MaxValue - class2.MinValue);
				double num8 = num + num7 * Math.Cos(num5);
				double num9 = num2 - num7 * Math.Sin(num5);
				PointF pointF = new PointF((float)num8, (float)num9);
				arrayList2.Add(pointF);
				arrayList3.Add(pointF);
				class844_0.method_7().method_7((float)num8, (float)num9, class844_0.method_7().MarkerSize);
				double num10 = num + num7 * 1.2 * Math.Cos(num5);
				double num11 = num2 - num7 * 1.2 * Math.Sin(num5);
				arrayList.Add(new object[5]
				{
					index,
					i,
					new PointF((float)num10, (float)num11),
					@class,
					num3
				});
			}
			else
			{
				arrayList2.Add(null);
				arrayList3.Add(new PointF((float)num, (float)num2));
			}
			if (i == int_0 - 1)
			{
				class5 = class4.method_1(0);
				if (class5 != null)
				{
					double num12 = Math.Abs(class5.YValue - class2.MinValue);
					double num13 = num3 * num12 / (class2.MaxValue - class2.MinValue);
					double num14 = num + num13 * Math.Cos(Math.PI / 2.0);
					double num15 = num2 - num13 * Math.Sin(Math.PI / 2.0);
					PointF pointF2 = new PointF((float)num14, (float)num15);
					arrayList2.Add(pointF2);
				}
				else
				{
					arrayList2.Add(null);
				}
			}
			num5 -= num4;
		}
		if (class844_0.method_22() != ChartType_Chart.RadarFilled)
		{
			if (arrayList2.Count > 1)
			{
				Struct50.smethod_7(interface42_0, class844_0, arrayList2, rectangle_0);
			}
		}
		else
		{
			smethod_2(interface42_0, arrayList3, class844_0);
		}
		return arrayList;
	}

	internal static void smethod_1(Interface42 interface42_0, Class821 class821_0, ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			object[] array = (object[])arrayList_0[i];
			int int_ = (int)array[0];
			int int_2 = (int)array[1];
			PointF pointF_ = (PointF)array[2];
			Class823 class823_ = (Class823)array[3];
			int int_3 = Convert.ToInt32(array[4]);
			Struct50.smethod_19(interface42_0, class823_, int_, int_2, pointF_, int_3);
		}
	}

	private static void smethod_2(Interface42 interface42_0, IList ilist_0, Class844 class844_0)
	{
		PointF[] array = new PointF[ilist_0.Count];
		for (int i = 0; i < ilist_0.Count; i++)
		{
			PointF pointF = (PointF)ilist_0[i];
			array[i] = pointF;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(array);
		class844_0.method_6().method_9(graphicsPath);
		class844_0.method_5().method_11(graphicsPath);
	}
}
