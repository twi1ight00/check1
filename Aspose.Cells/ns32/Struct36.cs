using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns3;
using ns31;

namespace ns32;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct36
{
	internal static ArrayList smethod_0(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0, int int_0)
	{
		Class787 chart = class810_0.Chart;
		Enum53 @enum = class810_0.method_21();
		ChartType_Chart[] array = new ChartType_Chart[3]
		{
			ChartType_Chart.Radar,
			ChartType_Chart.RadarWithDataMarkers,
			ChartType_Chart.RadarFilled
		};
		Class789 @class;
		Class789 class2;
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
		double num = (class2.IsLogarithmic ? Struct40.smethod_7(class2.MaxValue) : class2.MaxValue);
		double num2 = (class2.IsLogarithmic ? Struct40.smethod_7(class2.MinValue) : class2.MinValue);
		Class808 class3 = chart.method_7();
		_ = class3.Count;
		ArrayList arrayList = new ArrayList();
		double num3 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0;
		double num4 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0;
		double num5 = rectangle_0.Width / 2;
		double num6 = Math.PI * 2.0 / (double)int_0;
		int index = class810_0.Index;
		Pen pen = null;
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		Class795 class4 = class810_0.method_10();
		double num7 = Math.PI / 2.0;
		for (int i = 0; i < int_0; i++)
		{
			Class796 class5 = class4.method_1(i);
			if (class5 != null && !class5.imethod_0() && !class5.method_10())
			{
				pen?.Dispose();
				pen = Struct29.smethod_5(class5.method_4());
				double num8 = Math.Abs(class5.YValue - num2);
				double num9 = num5 * num8 / (num - num2);
				double num10 = num3 + num9 * Math.Cos(num7);
				double num11 = num4 - num9 * Math.Sin(num7);
				PointF pointF = new PointF((float)num10, (float)num11);
				arrayList2.Add(pointF);
				arrayList3.Add(pointF);
				Struct28.smethod_8(interface42_0, (float)num10, (float)num11, class810_0.method_8(), class810_0.method_8().MarkerSize, bool_0: false);
				arrayList.Add(new object[5] { index, i, pointF, @class, num5 });
			}
			else
			{
				arrayList2.Add(null);
				arrayList3.Add(new PointF((float)num3, (float)num4));
			}
			if (i == int_0 - 1)
			{
				class5 = class4.method_1(0);
				if (class5 != null && !class5.imethod_0())
				{
					double num12 = Math.Abs(class5.YValue - num2);
					double num13 = num5 * num12 / (num - num2);
					double num14 = num3 + num13 * Math.Cos(Math.PI / 2.0);
					double num15 = num4 - num13 * Math.Sin(Math.PI / 2.0);
					PointF pointF2 = new PointF((float)num14, (float)num15);
					arrayList2.Add(pointF2);
				}
				else
				{
					arrayList2.Add(null);
				}
			}
			num7 -= num6;
		}
		if (class810_0.method_22() != ChartType_Chart.RadarFilled)
		{
			if (pen == null)
			{
				pen = Struct29.smethod_5(class810_0.method_6());
			}
			Struct25.smethod_6(interface42_0, class810_0, arrayList2, pen, rectangle_0);
		}
		else
		{
			smethod_2(interface42_0, arrayList3, class810_0);
		}
		pen?.Dispose();
		return arrayList;
	}

	internal static void smethod_1(Interface42 interface42_0, Class787 class787_0, ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			object[] array = (object[])arrayList_0[i];
			int int_ = (int)array[0];
			int int_2 = (int)array[1];
			PointF pointF_ = (PointF)array[2];
			Class789 class789_ = (Class789)array[3];
			int int_3 = Convert.ToInt32(array[4]);
			Struct25.smethod_20(interface42_0, class789_, int_, int_2, pointF_, int_3);
		}
	}

	private static void smethod_2(Interface42 interface42_0, IList ilist_0, Class810 class810_0)
	{
		PointF[] array = new PointF[ilist_0.Count];
		for (int i = 0; i < ilist_0.Count; i++)
		{
			PointF pointF = (PointF)ilist_0[i];
			array[i] = pointF;
		}
		RectangleF rectangleF_ = Struct17.smethod_7(array);
		using (Brush brush_ = Struct18.smethod_1(class810_0.method_7(), rectangleF_))
		{
			interface42_0.imethod_35(brush_, array);
		}
		interface42_0.imethod_20(Struct29.smethod_5(class810_0.method_6()), array);
	}
}
