using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using ns19;
using ns3;
using ns33;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct64
{
	internal static ArrayList smethod_0(Interface42 interface42_0, Class844 class844_0, Rectangle rectangle_0, float float_0, double double_0, int int_0)
	{
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
		double num = (class2.IsLogarithmic ? class2.method_6(class2.MinValue) : class2.MinValue);
		double num2 = (class2.IsLogarithmic ? class2.method_6(class2.MaxValue) : class2.MaxValue);
		double_0 = (class2.IsLogarithmic ? class2.method_6(double_0) : double_0);
		double num3 = (@class.IsLogarithmic ? @class.method_6(@class.MinValue) : @class.MinValue);
		double num4 = (@class.IsLogarithmic ? @class.method_6(@class.MaxValue) : @class.MaxValue);
		_ = class844_0.HasDropLines;
		class844_0.method_12();
		class844_0.method_13();
		class844_0.method_15();
		class844_0.method_16();
		ArrayList arrayList = new ArrayList();
		double num5 = (double)rectangle_0.Width / (num4 - num3);
		int num6 = int_0;
		if (@class.bool_12)
		{
			num6 = (int)@class.MaxValue;
			if (@class.AxisBetweenCategories)
			{
				num5 = (double)rectangle_0.Width / (num4 - num3 + 1.0);
			}
		}
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		Class830 class3 = class844_0.method_9();
		for (int i = 0; i < num6; i++)
		{
			Class831 class4 = class3.method_1(i);
			if (class4 != null && !class4.imethod_0() && !class4.imethod_2())
			{
				double num7 = (double)(float)num5 * (class4.XValue - num3);
				if (@class.AxisBetweenCategories)
				{
					num7 += (double)((float)num5 / 2f);
				}
				num7 = ((!@class.IsPlotOrderReversed) ? ((double)rectangle_0.X + num7) : ((double)(rectangle_0.X + rectangle_0.Width) - num7));
				double num8 = float_0;
				double yValue = class4.YValue;
				double num9 = (yValue - double_0) / (num2 - num) * (double)rectangle_0.Height;
				Class834 class5 = class844_0.method_4();
				PointF pointF_ = new PointF((float)num7, float_0);
				double num10 = 0.0;
				double num11 = 0.0;
				float float_ = 0f;
				float float_2 = 0f;
				if (class5 != null)
				{
					switch (class5.Type)
					{
					case Enum69.const_0:
					{
						double num12 = ((class5.MinusValue.Count > i) ? class5.method_2(class5.MinusValue[i]) : 0.0);
						num10 = num12;
						num12 = ((class5.PlusValue.Count > i) ? class5.method_2(class5.PlusValue[i]) : 0.0);
						num11 = num12;
						break;
					}
					case Enum69.const_1:
						num10 = class5.Amount;
						num11 = num10;
						break;
					case Enum69.const_2:
						num10 = class5.Amount * Math.Abs(class4.XValue) / 100.0;
						num11 = num10;
						break;
					}
					float_ = (float)(num10 / (num4 - num3) * (double)rectangle_0.Width);
					float_2 = (float)(num11 / (num4 - num3) * (double)rectangle_0.Width);
					if (!class2.IsPlotOrderReversed)
					{
						pointF_.Y -= (float)num9;
					}
					else
					{
						pointF_.Y += (float)num9;
					}
				}
				class5.method_0(pointF_, float_, float_2);
				Class834 class6 = class844_0.method_3();
				num10 = 0.0;
				num11 = 0.0;
				float_ = 0f;
				float_2 = 0f;
				if (class6 != null)
				{
					switch (class6.Type)
					{
					case Enum69.const_0:
					{
						double num13 = ((class6.MinusValue.Count > i) ? class6.method_2(class6.MinusValue[i]) : 0.0);
						num10 = num13;
						num13 = ((class6.PlusValue.Count > i) ? class6.method_2(class6.PlusValue[i]) : 0.0);
						num11 = num13;
						break;
					}
					case Enum69.const_1:
						num10 = class6.Amount;
						num11 = num10;
						break;
					case Enum69.const_2:
						num10 = class6.Amount * Math.Abs(class4.YValue) / 100.0;
						num11 = num10;
						break;
					}
					float_ = (float)num10 / (float)(num2 - num) * (float)rectangle_0.Height;
					float_2 = (float)num11 / (float)(num2 - num) * (float)rectangle_0.Height;
				}
				class6.method_0(pointF_, float_, float_2);
				num8 = (class2.IsPlotOrderReversed ? (num8 + num9) : (num8 - num9));
				PointF pointF = new PointF((float)num7, (float)num8);
				arrayList3.Add(pointF);
				Class832 class7 = class4.method_6();
				int digits = (@class.IsLogarithmic ? Struct63.smethod_7((double)class4.vmethod_3()) : 0);
				int digits2 = (class2.IsLogarithmic ? Struct63.smethod_7((double)class4.vmethod_5()) : 0);
				bool flag = true;
				bool flag2 = true;
				if ((@class.IsLogarithmic && Math.Round(@class.method_7(class4.XValue), digits) <= Math.Round(@class.method_7(num4), digits) && Math.Round(@class.method_7(class4.XValue), digits) >= Math.Round(@class.method_7(num3), digits)) || (!@class.IsLogarithmic && class4.XValue <= num4 && class4.XValue >= num3))
				{
					flag = false;
				}
				if ((class2.IsLogarithmic && Math.Round(class2.method_7(class4.YValue), digits2) <= Math.Round(class2.method_7(num2), digits2) && Math.Round(class2.method_7(class4.YValue), digits2) >= Math.Round(class2.method_7(num), digits2)) || (!class2.IsLogarithmic && class4.YValue <= num2 && class4.YValue >= num))
				{
					flag2 = false;
				}
				if (class7.method_1() && !flag && !flag2)
				{
					arrayList.Add(new object[4] { class844_0.Index, i, pointF, @class });
				}
			}
			else
			{
				arrayList3.Add(null);
			}
		}
		if (arrayList3.Count > 1)
		{
			Struct50.smethod_7(interface42_0, class844_0, arrayList3, rectangle_0);
		}
		smethod_1(interface42_0, class844_0, arrayList3, rectangle_0);
		arrayList2.Add(arrayList3);
		return arrayList;
	}

	internal static void smethod_1(Interface42 interface42_0, Class844 class844_0, IList ilist_0, Rectangle rectangle_0)
	{
		rectangle_0 = new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		rectangle_0.Inflate(1, 1);
		for (int i = 0; i < ilist_0.Count; i++)
		{
			object obj = ilist_0[i];
			if (obj != null)
			{
				Class831 @class = class844_0.method_9().method_1(i);
				PointF pointF = (PointF)obj;
				if (!(pointF.X < (float)rectangle_0.X) && !(pointF.Y < (float)rectangle_0.Y) && !(pointF.X > (float)rectangle_0.Right) && !(pointF.Y > (float)rectangle_0.Bottom) && @class.method_5().IsVisible)
				{
					@class.method_5().method_6(pointF.X, pointF.Y);
				}
			}
		}
	}
}
