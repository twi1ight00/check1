using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns22;
using ns3;
using ns31;

namespace ns32;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct25
{
	internal static ArrayList smethod_0(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0, float float_0, double double_0, int int_0)
	{
		ArrayList arrayList = new ArrayList();
		Class787 chart = class810_0.Chart;
		Class808 @class = chart.method_7();
		_ = @class.Count;
		Enum53 @enum = class810_0.method_21();
		Class789 class2;
		Class789 class3;
		int num;
		if (@enum == Enum53.const_0)
		{
			class2 = chart.method_1();
			class3 = chart.method_9();
			num = @class.method_12(Enum53.const_0);
		}
		else
		{
			class2 = chart.method_2();
			class3 = chart.method_10();
			num = @class.method_12(Enum53.const_1);
		}
		if (class2.CategoryType == Enum64.const_2)
		{
			return smethod_1(interface42_0, class810_0, rectangle_0, float_0, double_0);
		}
		double num2 = (class3.IsLogarithmic ? Struct40.smethod_7(class3.MaxValue) : class3.MaxValue);
		double num3 = (class3.IsLogarithmic ? Struct40.smethod_7(class3.MinValue) : class3.MinValue);
		double_0 = (class3.IsLogarithmic ? Struct40.smethod_7(double_0) : double_0);
		float num4 = 0f;
		float num5 = 1.5f;
		Class810 class4 = chart.method_7().method_11(@enum);
		if (class4 != null)
		{
			num4 = (float)class4.Overlap / 100f;
			num5 = (float)class4.GapWidth / 100f;
		}
		int num6 = 0;
		int num7 = int_0;
		if (class2.bool_12)
		{
			num7 = (int)class2.MaxValue;
		}
		if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num6 = num7 - 1;
			if (num6 == 0)
			{
				num6 = 1;
			}
		}
		else
		{
			num6 = num7;
		}
		double num8 = (double)rectangle_0.Width / (double)num6;
		int num9 = @class.method_19(class810_0, @enum, new ChartType_Chart[1] { ChartType_Chart.Column });
		if (num9 == -1)
		{
			return arrayList;
		}
		int index = class810_0.Index;
		Class795 class5 = class810_0.method_10();
		for (int i = 0; i < class5.Count; i++)
		{
			Class796 class6 = class5.method_1(i);
			float num10 = (float)num8 / ((float)num - num4 * (float)(num - 1) + num5);
			float num11 = num10 * num4;
			float num12 = num10 * num5;
			float num13 = (float)num9 * (num10 - num11);
			float num14 = (float)num8 * (float)i + num12 / 2f + num13;
			if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
			{
				num14 -= (float)(num8 / 2.0);
			}
			num14 = ((!class2.IsPlotOrderReversed) ? ((float)rectangle_0.X + num14) : ((float)(rectangle_0.X + rectangle_0.Width) - num14 - num10));
			if (class6 == null || class6.imethod_0())
			{
				continue;
			}
			double yValue = class6.YValue;
			float num15 = (float)(double_0 - yValue) / (float)(num2 - num3) * (float)rectangle_0.Height;
			bool flag = false;
			if (num15 == 0f)
			{
				flag = true;
			}
			Class800 class7 = class810_0.method_4();
			if (class7 != null && class7.DisplayType != Enum68.const_2)
			{
				PointF pointF_ = new PointF(num14 + num10 / 2f, float_0);
				double num16 = 0.0;
				double num17 = 0.0;
				float float_ = 0f;
				float float_2 = 0f;
				if (class7 != null)
				{
					switch (class7.Type)
					{
					case Enum69.const_0:
					{
						double num18 = ((class7.MinusValue.Count > i) ? class7.method_2(class7.MinusValue[i]) : 0.0);
						num16 = num18;
						num18 = ((class7.PlusValue.Count > i) ? class7.method_2(class7.PlusValue[i]) : 0.0);
						num17 = num18;
						break;
					}
					case Enum69.const_1:
						num16 = class7.Amount;
						num17 = num16;
						break;
					case Enum69.const_2:
						num16 = class7.Amount * Math.Abs(yValue) / 100.0;
						num17 = num16;
						break;
					}
					float_ = (float)num16 / (float)(num2 - num3) * (float)rectangle_0.Height;
					float_2 = (float)num17 / (float)(num2 - num3) * (float)rectangle_0.Height;
					if (!class3.IsPlotOrderReversed)
					{
						pointF_.Y += num15;
					}
					else
					{
						pointF_.Y -= num15;
					}
				}
				class7.method_0(pointF_, float_, float_2);
			}
			float num19 = float_0;
			if (!class3.IsPlotOrderReversed)
			{
				if (num15 < 0f)
				{
					num15 = 0f - num15;
					num19 -= num15;
				}
			}
			else if (num15 < 0f)
			{
				num15 = 0f - num15;
			}
			else
			{
				num19 -= num15;
			}
			RectangleF rectangleF = new RectangleF(num14, num19, num10, num15 + 1f);
			if (rectangleF.Y < (float)rectangle_0.Y)
			{
				rectangleF.Height -= (float)rectangle_0.Y - rectangleF.Y;
				rectangleF.Y = rectangle_0.Y;
			}
			if (rectangleF.Bottom > (float)(rectangle_0.Bottom + 1))
			{
				rectangleF.Height -= rectangleF.Bottom - (float)rectangle_0.Bottom;
			}
			if (!(rectangleF.Right >= (float)rectangle_0.X) || !(rectangleF.Left <= (float)rectangle_0.Right))
			{
				continue;
			}
			if (rectangleF.X < (float)rectangle_0.X)
			{
				rectangleF.Width -= (float)rectangle_0.X - rectangleF.X;
				rectangleF.X = rectangle_0.X;
			}
			else if (rectangleF.Right > (float)rectangle_0.Right)
			{
				rectangleF.Width -= rectangleF.Right - (float)rectangle_0.Right;
			}
			if (rectangleF.Width + 1f >= (num10 - 1f) / 3f)
			{
				if (!flag)
				{
					smethod_2(interface42_0, class6, rectangleF, chart.method_14(class810_0.vmethod_7()).GetColor(index), float_0, class3);
				}
				object[] array = new object[5];
				bool flag2 = rectangleF.Y < float_0 || (yValue == 0.0 && ((!class3.IsPlotOrderReversed) ? true : false));
				array[0] = index;
				array[1] = i;
				array[2] = rectangleF;
				array[3] = class2;
				array[4] = flag2;
				arrayList.Add(array);
			}
		}
		return arrayList;
	}

	private static ArrayList smethod_1(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0, float float_0, double double_0)
	{
		Class787 chart = class810_0.Chart;
		_ = chart.method_7().Count;
		Class808 @class = chart.method_7();
		Enum53 @enum = class810_0.method_21();
		float num = 0f;
		float num2 = 1.5f;
		Class810 class2 = chart.method_7().method_11(@enum);
		if (class2 != null)
		{
			num = (float)class2.Overlap / 100f;
			num2 = (float)class2.GapWidth / 100f;
		}
		Class789 class3;
		Class789 class4;
		int num3;
		ArrayList arrayList;
		if (@enum == Enum53.const_0)
		{
			class3 = chart.method_1();
			class4 = chart.method_9();
			num3 = @class.method_12(Enum53.const_0);
			arrayList = Class817.smethod_71(chart.method_7().method_0(), class810_0.Chart.vmethod_0());
		}
		else
		{
			class3 = chart.method_2();
			class4 = chart.method_10();
			num3 = @class.method_12(Enum53.const_1);
			arrayList = Class817.smethod_71(chart.method_7().method_2(), class810_0.Chart.vmethod_0());
		}
		double num4 = (class4.IsLogarithmic ? Struct40.smethod_7(class4.MaxValue) : class4.MaxValue);
		double num5 = (class4.IsLogarithmic ? Struct40.smethod_7(class4.MinValue) : class4.MinValue);
		double_0 = (class4.IsLogarithmic ? Struct40.smethod_7(double_0) : double_0);
		ArrayList arrayList2 = new ArrayList();
		int count = arrayList.Count;
		Enum87 baseUnitScale = class3.BaseUnitScale;
		int int_ = (int)class3.MinValue;
		int int_2 = (int)class3.MaxValue;
		int num6 = 0;
		if (!class3.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num6 = Struct19.smethod_29(baseUnitScale, int_2, int_, class810_0.Chart.vmethod_0());
			if (num6 == 0)
			{
				num6 = 1;
			}
		}
		else
		{
			num6 = Struct19.smethod_29(baseUnitScale, int_2, int_, class810_0.Chart.vmethod_0()) + 1;
		}
		double num7 = (double)rectangle_0.Width / (double)num6;
		int num8 = 0;
		while (true)
		{
			if (num8 < count)
			{
				Class796 class5 = class810_0.method_10().method_1(num8);
				float num9 = (float)(num7 / (double)((float)num3 - num * (float)(num3 - 1) + num2));
				float num10 = num9 * num;
				float num11 = num9 * num2;
				int int_3 = int.Parse(arrayList[num8].ToString());
				int_3 = Struct19.smethod_32(baseUnitScale, int_3, class810_0.Chart.vmethod_0());
				int num12 = Struct19.smethod_29(baseUnitScale, int_3, int_, class810_0.Chart.vmethod_0());
				float num13 = (float)(num7 * (double)num12);
				if (!class3.AxisBetweenCategories && !chart.IsDataTableShown)
				{
					num13 -= (float)(num7 / 2.0);
				}
				float num14 = 0f;
				num14 = ((!class3.IsPlotOrderReversed) ? ((float)rectangle_0.X + num13 + num11 / 2f + 1f) : ((float)(rectangle_0.X + rectangle_0.Width) - num13 - num11 / 2f - num9 - 1f));
				int num15 = @class.method_19(class810_0, @enum, new ChartType_Chart[1] { ChartType_Chart.Column });
				if (num15 == -1)
				{
					break;
				}
				int index = class810_0.Index;
				num14 = ((!class3.IsPlotOrderReversed) ? (num14 + (float)num15 * (num9 - num10)) : (num14 - (float)num15 * (num9 - num10)));
				if (class5 != null && !class5.imethod_0())
				{
					double yValue = class5.YValue;
					float num16 = (float)(double_0 - yValue) / (float)(num4 - num5) * (float)rectangle_0.Height;
					bool flag = false;
					if (num16 == 0f)
					{
						flag = true;
					}
					Class800 class6 = class810_0.method_4();
					if (class6 != null && class6.DisplayType != Enum68.const_2)
					{
						PointF pointF_ = new PointF(num14 + num9 / 2f, float_0);
						double num17 = 0.0;
						double num18 = 0.0;
						float float_ = 0f;
						float float_2 = 0f;
						if (class6 != null)
						{
							switch (class6.Type)
							{
							case Enum69.const_0:
							{
								double num19 = ((class6.MinusValue.Count > num8) ? class6.method_2(class6.MinusValue[num8]) : 0.0);
								num17 = num19;
								num19 = ((class6.PlusValue.Count > num8) ? class6.method_2(class6.PlusValue[num8]) : 0.0);
								num18 = num19;
								break;
							}
							case Enum69.const_1:
								num17 = class6.Amount;
								num18 = num17;
								break;
							case Enum69.const_2:
								num17 = class6.Amount * Math.Abs(yValue) / 100.0;
								num18 = num17;
								break;
							}
							float_ = (float)num17 / (float)(num4 - num5) * (float)rectangle_0.Height;
							float_2 = (float)num18 / (float)(num4 - num5) * (float)rectangle_0.Height;
							if (!class4.IsPlotOrderReversed)
							{
								pointF_.Y += num16;
							}
							else
							{
								pointF_.Y -= num16;
							}
						}
						class6.method_0(pointF_, float_, float_2);
					}
					float num20 = float_0;
					if (!class4.IsPlotOrderReversed)
					{
						if (num16 < 0f)
						{
							num16 = 0f - num16;
							num20 -= num16;
						}
					}
					else if (num16 < 0f)
					{
						num16 = 0f - num16;
					}
					else
					{
						num20 -= num16;
					}
					RectangleF rectangleF = new RectangleF(num14, num20, num9, num16 + 1f);
					if (rectangleF.Y < (float)rectangle_0.Y)
					{
						rectangleF.Height -= (float)rectangle_0.Y - rectangleF.Y;
						rectangleF.Y = rectangle_0.Y;
					}
					if (rectangleF.Bottom > (float)(rectangle_0.Bottom + 1))
					{
						rectangleF.Height -= rectangleF.Bottom - (float)rectangle_0.Bottom;
					}
					if (rectangleF.Right >= (float)rectangle_0.X && rectangleF.Left <= (float)rectangle_0.Right)
					{
						if (rectangleF.X < (float)rectangle_0.X)
						{
							rectangleF.Width -= (float)rectangle_0.X - rectangleF.X;
							rectangleF.X = rectangle_0.X;
						}
						else if (rectangleF.Right > (float)rectangle_0.Right)
						{
							rectangleF.Width -= rectangleF.Right - (float)rectangle_0.Right;
						}
						if (rectangleF.Width + 1f >= (num9 - 1f) / 3f)
						{
							if (!flag)
							{
								smethod_2(interface42_0, class5, rectangleF, chart.method_14(class810_0.vmethod_7()).GetColor(index), float_0, class4);
							}
							object[] array = new object[5];
							bool flag2 = rectangleF.Y < float_0 || (yValue == 0.0 && ((!class4.IsPlotOrderReversed) ? true : false));
							array[0] = index;
							array[1] = num8;
							array[2] = rectangleF;
							array[3] = class3;
							array[4] = flag2;
							arrayList2.Add(array);
						}
					}
				}
				num8++;
				continue;
			}
			return arrayList2;
		}
		return arrayList2;
	}

	private static void smethod_2(Interface42 interface42_0, Class796 class796_0, RectangleF rectangleF_0, Color color_0, float float_0, Class789 class789_0)
	{
		if (class796_0.method_3().Formatting != 0 || class796_0.method_4().IsVisible)
		{
			class796_0.method_12(new RectangleF(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height));
		}
		if (rectangleF_0.Width < 10f)
		{
			rectangleF_0.X = (int)rectangleF_0.X;
		}
		bool invertIfNegative = class796_0.method_1().method_0().method_7()
			.InvertIfNegative;
		if (!class796_0.method_3().bool_1)
		{
			invertIfNegative = class796_0.method_3().InvertIfNegative;
		}
		bool bool_ = false;
		if ((rectangleF_0.Bottom - 2f > float_0 && invertIfNegative && !class789_0.IsPlotOrderReversed) || (rectangleF_0.Y + 2f < float_0 && invertIfNegative && class789_0.IsPlotOrderReversed))
		{
			bool_ = true;
		}
		if (class796_0.method_3().Formatting != 0)
		{
			using Brush brush_ = Struct18.smethod_2(class796_0.method_3(), rectangleF_0, bool_);
			rectangleF_0.Y -= 0.5f;
			interface42_0.imethod_37(brush_, rectangleF_0);
		}
		if ((double)rectangleF_0.Width > class796_0.method_4().LineStyle.Width / 2.0)
		{
			rectangleF_0.Width -= (float)(class796_0.method_4().LineStyle.Width / 2.0);
		}
		if ((double)rectangleF_0.Height > class796_0.method_4().LineStyle.Width / 2.0)
		{
			rectangleF_0.Height -= (float)class796_0.method_4().LineStyle.Width / 2f;
		}
		Struct29.smethod_2(interface42_0, rectangleF_0, class796_0.method_4());
		bool flag = false;
		if (rectangleF_0.Bottom - 2f < float_0)
		{
			flag = true;
		}
		if (!class796_0.vmethod_11() || (class796_0.method_3().Formatting == Enum71.const_0 && class796_0.method_4().Formatting == Enum71.const_0))
		{
			return;
		}
		using Pen pen_ = new Pen(Color.Black, 2f);
		int num = 2;
		int num2 = 1;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rectangleF_0.Right + 1f, rectangleF_0.Y + 2f, rectangleF_0.Right + 1f, rectangleF_0.Bottom + 1f);
		if (!flag)
		{
			graphicsPath.AddLine(rectangleF_0.X + (float)num, rectangleF_0.Bottom + (float)num2, rectangleF_0.Right + (float)num2, rectangleF_0.Bottom + (float)num2);
		}
		interface42_0.imethod_18(pen_, graphicsPath);
	}

	private static void smethod_3(Interface42 interface42_0, Class794 class794_0, RectangleF rectangleF_0)
	{
		if (class794_0.method_1().Formatting != 0)
		{
			using Brush brush_ = Struct18.smethod_1(class794_0.method_1(), rectangleF_0);
			interface42_0.imethod_37(brush_, rectangleF_0);
		}
		if (class794_0.method_2().IsVisible)
		{
			if ((double)rectangleF_0.Width > class794_0.method_2().LineStyle.Width / 2.0)
			{
				rectangleF_0.Width -= (float)class794_0.method_2().LineStyle.Width / 2f;
			}
			if (rectangleF_0.Height < 1f)
			{
				rectangleF_0.Height = 1f;
			}
			Struct29.smethod_2(interface42_0, rectangleF_0, class794_0.method_2());
		}
	}

	internal static void smethod_4(Interface42 interface42_0, Class787 class787_0, ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			object[] array = (object[])arrayList_0[i];
			int int_ = (int)array[0];
			int int_2 = (int)array[1];
			RectangleF rectangleF_ = (RectangleF)array[2];
			Class789 class789_ = (Class789)array[3];
			bool bool_ = (bool)array[4];
			int int_3 = (int)((float)class787_0.Width * Struct40.float_0);
			smethod_5(interface42_0, class789_, int_, int_2, rectangleF_, bool_, int_3);
		}
	}

	private static void smethod_5(Interface42 interface42_0, Class789 class789_0, int int_0, int int_1, RectangleF rectangleF_0, bool bool_0, int int_2)
	{
		Class808 @class = class789_0.Chart.method_7();
		Class798 class2 = @class.method_9(int_0).method_10().method_1(int_1)
			.method_6();
		SizeF sizeF = Struct26.smethod_0(interface42_0, class789_0, @class, int_0, int_1, int_2);
		float num = rectangleF_0.X + rectangleF_0.Width / 2f - sizeF.Width / 2f;
		float num2 = 0f;
		Enum74 @enum = class2.vmethod_0();
		if (@enum == Enum74.const_9)
		{
			@enum = Struct26.smethod_12(@class[int_0].Type);
		}
		switch (@enum)
		{
		default:
			if (bool_0)
			{
				num2 = rectangleF_0.Y - sizeF.Height;
				num2 += -1f;
			}
			else
			{
				num2 = rectangleF_0.Y + rectangleF_0.Height;
				num2 += 5f;
			}
			break;
		case Enum74.const_1:
			num2 = rectangleF_0.Y + rectangleF_0.Height / 2f - sizeF.Height / 2f;
			break;
		case Enum74.const_2:
			if (bool_0)
			{
				num2 = rectangleF_0.Y + rectangleF_0.Height - sizeF.Height;
				num2 += -1f;
			}
			else
			{
				num2 = rectangleF_0.Y;
				num2 += 5f;
			}
			break;
		case Enum74.const_3:
			if (bool_0)
			{
				num2 = rectangleF_0.Y;
				num2 += 5f;
			}
			else
			{
				num2 = rectangleF_0.Y + rectangleF_0.Height - sizeF.Height;
				num2 += -1f;
			}
			break;
		}
		if (@class.method_9(int_0).method_24(new ChartType_Chart[1] { ChartType_Chart.Column }))
		{
			if (bool_0)
			{
				if (num2 + (float)Struct26.int_0 + sizeF.Height > rectangleF_0.Bottom)
				{
					num2 -= num2 + (float)Struct26.int_0 + sizeF.Height - rectangleF_0.Bottom;
				}
			}
			else if (num2 < rectangleF_0.Y)
			{
				num2 += rectangleF_0.Y - num2;
			}
		}
		class2.method_0().rectangle_1 = new Rectangle(Struct40.smethod_5(num), Struct40.smethod_5(num2), Struct40.smethod_3(sizeF.Width), Struct40.smethod_3(sizeF.Height));
		class2.method_0().method_9();
		Struct26.smethod_1(interface42_0, class789_0, @class, int_0, int_1, class2.method_0().rectangle_0);
	}

	internal static void smethod_6(Interface42 interface42_0, Class810 class810_0, IList ilist_0, Pen pen_0, Rectangle rectangle_0)
	{
		GraphicsState graphicsState_ = interface42_0.Save();
		RectangleF rectangleF_ = interface42_0.imethod_50();
		interface42_0.imethod_47(rectangle_0);
		bool flag = false;
		if (class810_0.Type == ChartType_Chart.Line100PercentStacked || class810_0.Type == ChartType_Chart.Line100PercentStackedWithDataMarkers || class810_0.Type == ChartType_Chart.LineStacked || class810_0.Type == ChartType_Chart.LineStackedWithDataMarkers)
		{
			flag = true;
		}
		for (int i = 0; i < ilist_0.Count; i++)
		{
			if (ilist_0[i] != null)
			{
				PointF pointF = (PointF)ilist_0[i];
				if (Struct29.smethod_3(new PointF(pointF.X / 10f, pointF.Y / 10f), rectangleF_))
				{
					ilist_0[i] = null;
				}
			}
		}
		if (class810_0.Smooth)
		{
			if (ilist_0.Count > 1)
			{
				_ = ilist_0[0];
				ArrayList arrayList = new ArrayList();
				int int_ = 0;
				ArrayList arrayList2 = new ArrayList();
				for (int j = 0; j < ilist_0.Count; j++)
				{
					Class796 @class = class810_0.method_10().method_1(j);
					if (j == ilist_0.Count - 1 && (class810_0.Type == ChartType_Chart.Radar || class810_0.Type == ChartType_Chart.RadarWithDataMarkers))
					{
						@class = class810_0.method_10().method_1(0);
					}
					if (@class == null)
					{
						if (arrayList.Count > 1)
						{
							smethod_7(interface42_0, pen_0, arrayList, rectangle_0, int_, j, arrayList2, class810_0);
						}
						arrayList.Clear();
						arrayList2.Clear();
					}
					else if (@class != null && !flag && (@class.vmethod_1() || @class.method_10() || @class.vmethod_0()))
					{
						arrayList2.Add(j);
					}
					else if (ilist_0[j] != null)
					{
						PointF pointF2 = (PointF)ilist_0[j];
						arrayList.Add(pointF2);
						if (arrayList.Count == 1)
						{
							int_ = j;
						}
					}
					else
					{
						if (arrayList.Count > 1)
						{
							smethod_7(interface42_0, pen_0, arrayList, rectangle_0, int_, j, arrayList2, class810_0);
						}
						arrayList.Clear();
						arrayList2.Clear();
					}
				}
				if (arrayList.Count > 1)
				{
					smethod_7(interface42_0, pen_0, arrayList, rectangle_0, int_, ilist_0.Count - 1, arrayList2, class810_0);
				}
			}
		}
		else if (ilist_0.Count > 1)
		{
			ArrayList arrayList3 = new ArrayList();
			object obj = null;
			Class796 class2 = null;
			int num = 0;
			for (int k = 0; k < ilist_0.Count; k++)
			{
				Class796 class3 = class810_0.method_10().method_1(k);
				if (class3 == null || flag || (!class3.vmethod_1() && !class3.method_10() && !class3.vmethod_0()))
				{
					obj = ilist_0[k];
					class2 = class3;
					if (obj != null)
					{
						arrayList3.Add(obj);
					}
					num = k + 1;
					break;
				}
			}
			for (num = 1; num < ilist_0.Count; num++)
			{
				object obj2 = ilist_0[num];
				Class796 class4 = class810_0.method_10().method_1(num);
				if (num == ilist_0.Count - 1 && (class810_0.Type == ChartType_Chart.Radar || class810_0.Type == ChartType_Chart.RadarWithDataMarkers))
				{
					class4 = class810_0.method_10().method_1(0);
				}
				if (class4 != null && !flag && (class4.vmethod_1() || class4.method_10() || class4.vmethod_0()))
				{
					continue;
				}
				if (class4 != null && obj2 != null)
				{
					if (!class2.method_4().method_1(class4.method_4()) && arrayList3.Count > 1)
					{
						new GraphicsPath();
						PointF[] pointF_ = smethod_10(arrayList3);
						smethod_12(interface42_0, pointF_, class2);
						class2 = class4;
						PointF pointF3 = (PointF)arrayList3[arrayList3.Count - 1];
						arrayList3.Clear();
						if (obj2 != null)
						{
							arrayList3.Add(pointF3);
							arrayList3.Add(obj2);
							continue;
						}
					}
					if (obj2 != null)
					{
						arrayList3.Add(obj2);
					}
					class2 = class4;
				}
				else
				{
					obj = obj2;
					if (arrayList3.Count > 1)
					{
						new GraphicsPath();
						PointF[] pointF_2 = smethod_10(arrayList3);
						smethod_12(interface42_0, pointF_2, class2);
					}
					arrayList3.Clear();
					class2 = class4;
				}
			}
			if (arrayList3.Count > 1)
			{
				new GraphicsPath();
				PointF[] pointF_3 = smethod_10(arrayList3);
				smethod_12(interface42_0, pointF_3, class2);
			}
		}
		interface42_0.imethod_44(graphicsState_);
	}

	private static void smethod_7(Interface42 interface42_0, Pen pen_0, IList ilist_0, Rectangle rectangle_0, int int_0, int int_1, ArrayList arrayList_0, Class810 class810_0)
	{
		float float_ = 0.3f;
		float float_2 = 0.5f;
		if (ilist_0.Count < 3)
		{
			PointF[] pointF_ = smethod_10(ilist_0);
			if (!class810_0.IsColorVaried)
			{
				interface42_0.imethod_7(pen_0, pointF_, float_2);
			}
			else
			{
				smethod_9(interface42_0, class810_0.method_10(), pointF_, float_2, int_0, int_1, arrayList_0);
			}
			return;
		}
		ArrayList arrayList = new ArrayList();
		bool flag = false;
		bool flag2 = false;
		int_1 = int_0;
		for (int i = 0; i < ilist_0.Count; i++)
		{
			PointF pointF = (PointF)ilist_0[i];
			arrayList.Add(pointF);
			if (arrayList.Count == 1)
			{
				int_0 = int_1;
			}
			else
			{
				int_1++;
				while (arrayList_0.Contains(int_1))
				{
					int_1++;
				}
			}
			if (arrayList.Count >= 3)
			{
				PointF pointF2 = (PointF)arrayList[arrayList.Count - 3];
				PointF pointF3 = (PointF)arrayList[arrayList.Count - 2];
				float value = (pointF3.Y - pointF2.Y) / (pointF3.X - pointF2.X);
				float value2 = (pointF.Y - pointF3.Y) / (pointF.X - pointF3.X);
				float num = pointF3.Y - pointF2.Y;
				float num2 = pointF.Y - pointF3.Y;
				Math.Abs(Math.Abs(value2) - Math.Abs(value));
				if (Math.Abs(value2) < 2f || num2 / num < 8f)
				{
					continue;
				}
			}
			bool flag3;
			if (flag3 = Struct29.smethod_7(pointF, rectangle_0))
			{
				if (flag2)
				{
					int num3 = arrayList.Count - 1 - 1;
					for (i++; i < ilist_0.Count; i++)
					{
						PointF pointF4 = (PointF)ilist_0[i];
						if (!Struct29.smethod_7(pointF4, rectangle_0))
						{
							break;
						}
						arrayList.Add(pointF4);
					}
					i--;
					if (arrayList.Count != 2 && num3 != 0)
					{
						if (arrayList.Count > 2)
						{
							PointF[] pointF_2 = smethod_11(arrayList, 0, num3);
							if (!class810_0.IsColorVaried)
							{
								interface42_0.imethod_7(pen_0, pointF_2, float_2);
							}
							else
							{
								smethod_9(interface42_0, class810_0.method_10(), pointF_2, float_2, int_0, int_0 + num3, arrayList_0);
							}
							smethod_8(interface42_0, pen_0, smethod_11(arrayList, num3, arrayList.Count - 1), float_, int_0 + num3, int_1, arrayList_0, class810_0);
							arrayList.Clear();
							arrayList.Add(pointF);
							int_0 = int_1;
							flag = false;
							flag2 = false;
						}
					}
					else
					{
						smethod_8(interface42_0, pen_0, smethod_10(arrayList), float_, int_0, int_1, arrayList_0, class810_0);
						arrayList.Clear();
						arrayList.Add(pointF);
						int_0 = int_1;
						flag = false;
						flag2 = false;
					}
				}
			}
			else if (flag)
			{
				smethod_8(interface42_0, pen_0, smethod_10(arrayList), float_, int_0, int_1, arrayList_0, class810_0);
				arrayList.Clear();
				arrayList.Add(pointF);
				int_0 = int_1;
				flag = false;
				flag2 = false;
			}
			if (flag3)
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
		}
		if (arrayList.Count <= 1)
		{
			return;
		}
		if (flag)
		{
			smethod_8(interface42_0, pen_0, smethod_10(arrayList), float_, int_0, int_1, arrayList_0, class810_0);
			return;
		}
		PointF[] pointF_3 = smethod_10(arrayList);
		if (!class810_0.IsColorVaried)
		{
			interface42_0.imethod_7(pen_0, pointF_3, float_2);
		}
		else
		{
			smethod_9(interface42_0, class810_0.method_10(), pointF_3, float_2, int_0, int_1, arrayList_0);
		}
	}

	private static void smethod_8(Interface42 interface42_0, Pen pen_0, PointF[] pointF_0, float float_0, int int_0, int int_1, ArrayList arrayList_0, Class810 class810_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		for (int i = 0; i < pointF_0.Length; i++)
		{
			if (i == 0)
			{
				num = pointF_0[i].X;
				num2 = num;
				num3 = pointF_0[i].Y;
				num4 = num3;
				continue;
			}
			if (pointF_0[i].X < num)
			{
				num = pointF_0[i].X;
			}
			if (pointF_0[i].X > num2)
			{
				num2 = pointF_0[i].X;
			}
			if (pointF_0[i].Y < num3)
			{
				num3 = pointF_0[i].Y;
			}
			if (pointF_0[i].Y > num4)
			{
				num4 = pointF_0[i].Y;
			}
		}
		int num5 = Struct40.smethod_13(num2 - num);
		int num6 = Struct40.smethod_13(num4 - num3);
		int num7 = ((num5 > num6) ? num5 : num6);
		if (num7 > 4)
		{
			float_0 *= (float)Math.Pow(10.0, 4 - num7);
		}
		if (!class810_0.IsColorVaried)
		{
			interface42_0.imethod_7(pen_0, pointF_0, float_0);
		}
		else
		{
			smethod_9(interface42_0, class810_0.method_10(), pointF_0, float_0, int_0, int_1, arrayList_0);
		}
	}

	private static void smethod_9(Interface42 interface42_0, Class795 class795_0, PointF[] pointF_0, float float_0, int int_0, int int_1, ArrayList arrayList_0)
	{
		int num = 0;
		for (int i = int_0 + 1; i <= int_1; i++)
		{
			if (arrayList_0.Contains(i) || i >= class795_0.Count)
			{
				continue;
			}
			Class796 @class = class795_0.method_1(i);
			if (@class == null)
			{
				continue;
			}
			using Pen pen_ = Struct29.smethod_5(@class.method_4());
			if (num < pointF_0.Length - 1)
			{
				interface42_0.imethod_8(pen_, pointF_0, num, 1, float_0);
			}
			num++;
		}
	}

	private static PointF[] smethod_10(IList ilist_0)
	{
		PointF[] array = new PointF[ilist_0.Count];
		for (int i = 0; i < ilist_0.Count; i++)
		{
			ref PointF reference = ref array[i];
			reference = (PointF)ilist_0[i];
		}
		return array;
	}

	private static PointF[] smethod_11(IList ilist_0, int int_0, int int_1)
	{
		PointF[] array = new PointF[int_1 - int_0 + 1];
		for (int i = int_0; i <= int_1; i++)
		{
			ref PointF reference = ref array[i - int_0];
			reference = (PointF)ilist_0[i];
		}
		return array;
	}

	private static void smethod_12(Interface42 interface42_0, PointF[] pointF_0, Class796 class796_0)
	{
		if (pointF_0.Length < 3)
		{
			Struct29.smethod_1(interface42_0, pointF_0[0], pointF_0[1], class796_0.method_4());
			return;
		}
		smethod_15(ref pointF_0);
		ArrayList arrayList = new ArrayList();
		PointF pointF = pointF_0[0];
		PointF pointF2 = pointF_0[1];
		arrayList.Add(pointF);
		arrayList.Add(pointF2);
		for (int i = 2; i < pointF_0.Length; i++)
		{
			PointF pointF3 = pointF_0[i];
			double num = smethod_13(pointF, pointF2, pointF3);
			num = num * 180.0 / Math.PI;
			if (num < 30.0)
			{
				smethod_14(interface42_0, arrayList, class796_0);
				Struct29.smethod_1(interface42_0, pointF2, pointF3, class796_0.method_4());
				pointF = pointF2;
				pointF2 = pointF3;
				arrayList.Clear();
				arrayList.Add(pointF);
				arrayList.Add(pointF2);
			}
			else
			{
				arrayList.Add(pointF3);
				pointF = pointF2;
				pointF2 = pointF3;
			}
		}
		if (arrayList.Count > 1)
		{
			smethod_14(interface42_0, arrayList, class796_0);
		}
	}

	private static double smethod_13(PointF pointF_0, PointF pointF_1, PointF pointF_2)
	{
		double num = Math.Sqrt(Math.Pow(pointF_1.Y - pointF_0.Y, 2.0) + Math.Pow(pointF_1.X - pointF_0.X, 2.0));
		double num2 = Math.Sqrt(Math.Pow(pointF_2.Y - pointF_1.Y, 2.0) + Math.Pow(pointF_2.X - pointF_1.X, 2.0));
		double x = Math.Sqrt(Math.Pow(pointF_2.Y - pointF_0.Y, 2.0) + Math.Pow(pointF_2.X - pointF_0.X, 2.0));
		double d = (Math.Pow(num, 2.0) + Math.Pow(num2, 2.0) - Math.Pow(x, 2.0)) / (2.0 * num * num2);
		return Math.Acos(d);
	}

	private static void smethod_14(Interface42 interface42_0, ArrayList arrayList_0, Class796 class796_0)
	{
		if (arrayList_0.Count == 2)
		{
			Struct29.smethod_1(interface42_0, (PointF)arrayList_0[0], (PointF)arrayList_0[1], class796_0.method_4());
			return;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] points = smethod_10(arrayList_0);
		graphicsPath.AddLines(points);
		using Pen pen = Struct29.smethod_5(class796_0.method_4());
		interface42_0.imethod_18(pen, graphicsPath);
		pen.Dispose();
	}

	private static void smethod_15(ref PointF[] pointF_0)
	{
		PointF pointF = PointF.Empty;
		if (pointF_0.Length > 0)
		{
			pointF = pointF_0[0];
		}
		int num = 0;
		for (int i = 1; i < pointF_0.Length; i++)
		{
			PointF pointF2 = pointF_0[i];
			if (pointF_0.Length - num <= 2)
			{
				break;
			}
			if (Math.Abs(pointF.X - pointF2.X) < 1f && Math.Abs(pointF.Y - pointF2.Y) < 1f)
			{
				ref PointF reference = ref pointF_0[i];
				reference = PointF.Empty;
				num++;
			}
			else
			{
				pointF = pointF_0[i];
			}
		}
		if (num <= 0)
		{
			return;
		}
		PointF[] array = new PointF[pointF_0.Length - num];
		int num2 = 0;
		for (int j = 0; j < pointF_0.Length; j++)
		{
			if (!pointF_0[j].IsEmpty)
			{
				ref PointF reference2 = ref array[num2];
				reference2 = pointF_0[j];
				num2++;
			}
		}
		pointF_0 = array;
	}

	internal static void smethod_16(Interface42 interface42_0, Class810 class810_0, IList ilist_0, Rectangle rectangle_0)
	{
		rectangle_0 = new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		rectangle_0.Inflate(1, 1);
		for (int i = 0; i < ilist_0.Count; i++)
		{
			object obj = ilist_0[i];
			if (obj != null)
			{
				Class796 @class = class810_0.method_10().method_1(i);
				PointF pointF = (PointF)obj;
				if (!(pointF.X < (float)rectangle_0.X) && !(pointF.Y < (float)rectangle_0.Y) && !(pointF.X > (float)rectangle_0.Right) && !(pointF.Y > (float)rectangle_0.Bottom) && @class.method_5().IsVisible)
				{
					Struct28.smethod_8(interface42_0, pointF.X, pointF.Y, @class.method_5(), @class.method_5().MarkerSize, bool_0: false);
				}
			}
		}
	}

	internal static ArrayList smethod_17(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0, float float_0, double double_0, int int_0)
	{
		ArrayList arrayList = new ArrayList();
		Class787 chart = class810_0.Chart;
		ChartType_Chart[] chartType_Chart_ = new ChartType_Chart[2]
		{
			ChartType_Chart.Line,
			ChartType_Chart.LineWithDataMarkers
		};
		Enum53 @enum = class810_0.method_21();
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
		if (@class.CategoryType == Enum64.const_2)
		{
			return smethod_21(interface42_0, class810_0, rectangle_0, float_0, (float)double_0);
		}
		Class808 class3 = chart.method_7();
		_ = class3.Count;
		float num = (float)class810_0.GapWidth / 100f;
		double num2 = (class2.IsLogarithmic ? Struct40.smethod_7(class2.MaxValue) : class2.MaxValue);
		double num3 = (class2.IsLogarithmic ? Struct40.smethod_7(class2.MinValue) : class2.MinValue);
		double_0 = (class2.IsLogarithmic ? Struct40.smethod_7(double_0) : double_0);
		bool hasDropLines = class810_0.HasDropLines;
		Class806 class806_ = class810_0.method_13();
		Class806 class806_2 = class810_0.method_14();
		Class794 class794_ = class810_0.method_16();
		Class794 class794_2 = class810_0.method_17();
		int num4 = 0;
		int num5 = int_0;
		if (@class.bool_12)
		{
			num5 = (int)@class.MaxValue;
		}
		if (!@class.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num4 = num5 - 1;
			if (num4 == 0)
			{
				num4 = 1;
			}
		}
		else
		{
			num4 = num5;
		}
		double num6 = (double)rectangle_0.Width / (double)num4;
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		IList list = class3.method_17(@enum, chartType_Chart_);
		for (int i = 0; i < list.Count; i++)
		{
			Class810 class4 = (Class810)list[i];
			if ((chart.method_30() && !class4.Equals(class810_0)) || (!class810_0.HasUpDownBars && !class810_0.vmethod_0() && !class4.Equals(class810_0)))
			{
				continue;
			}
			int index = class4.Index;
			Pen pen = null;
			ArrayList arrayList4 = new ArrayList();
			Class795 class5 = class4.method_10();
			for (int j = 0; j < int_0; j++)
			{
				Class796 class6 = class5.method_1(j);
				if (class6 != null && !class6.imethod_0() && !class6.method_10())
				{
					pen?.Dispose();
					pen = Struct29.smethod_5(class6.method_4());
					double num7 = (float)num6 * (float)j + 1f;
					if (@class.AxisBetweenCategories || chart.IsDataTableShown)
					{
						num7 += (double)(float)(num6 / 2.0);
					}
					num7 = ((!@class.IsPlotOrderReversed) ? ((double)rectangle_0.X + num7) : ((double)(rectangle_0.X + rectangle_0.Width) - num7));
					double num8 = float_0;
					double yValue = class6.YValue;
					double num9 = (yValue - double_0) / (num2 - num3) * (double)rectangle_0.Height;
					Class800 class7 = class810_0.method_4();
					if (class7 != null && class7.DisplayType != Enum68.const_2)
					{
						PointF pointF_ = new PointF((float)num7, float_0);
						double num10 = 0.0;
						double num11 = 0.0;
						float float_ = 0f;
						float float_2 = 0f;
						if (class7 != null)
						{
							switch (class7.Type)
							{
							case Enum69.const_0:
							{
								double num12 = ((class7.MinusValue.Count > j) ? class7.method_2(class7.MinusValue[j]) : 0.0);
								num10 = num12;
								num12 = ((class7.PlusValue.Count > j) ? class7.method_2(class7.PlusValue[j]) : 0.0);
								num11 = num12;
								break;
							}
							case Enum69.const_1:
								num10 = class7.Amount;
								num11 = num10;
								break;
							case Enum69.const_2:
								num10 = class7.Amount * Math.Abs(yValue) / 100.0;
								num11 = num10;
								break;
							}
							float_ = (float)num10 / (float)(num2 - num3) * (float)rectangle_0.Height;
							float_2 = (float)num11 / (float)(num2 - num3) * (float)rectangle_0.Height;
							if (!class2.IsPlotOrderReversed)
							{
								pointF_.Y -= (float)num9;
							}
							else
							{
								pointF_.Y += (float)num9;
							}
						}
						if (class4.Equals(class810_0))
						{
							class7.method_0(pointF_, float_, float_2);
						}
					}
					num8 = (class2.IsPlotOrderReversed ? (num8 + num9) : (num8 - num9));
					PointF pointF = new PointF((float)num7, (float)num8);
					arrayList4.Add(pointF);
					if (class4.Equals(class810_0))
					{
						if (hasDropLines)
						{
							Struct29.smethod_0(interface42_0, (float)num7, (float)num8, (float)num7, float_0, class806_);
						}
						arrayList3.Add(pointF);
						arrayList.Add(new object[4] { index, j, pointF, @class });
					}
				}
				else
				{
					arrayList4.Add(null);
					if (class4.Equals(class810_0))
					{
						arrayList3.Add(null);
					}
				}
			}
			if (class4.Equals(class810_0))
			{
				if (pen == null)
				{
					pen = Struct29.smethod_5(class4.method_6());
				}
				smethod_6(interface42_0, class810_0, arrayList4, pen, rectangle_0);
			}
			pen?.Dispose();
			arrayList2.Add(arrayList4);
		}
		for (int k = 0; k < int_0; k++)
		{
			bool flag = false;
			bool flag2 = false;
			float float_3 = 0f;
			float float_4 = 0f;
			float float_5 = 0f;
			bool flag3 = false;
			bool flag4 = false;
			float num13 = 0f;
			float num14 = 0f;
			for (int l = 0; l < arrayList2.Count; l++)
			{
				ArrayList arrayList5 = (ArrayList)arrayList2[l];
				if (arrayList5.Count <= k || arrayList5[k] == null)
				{
					continue;
				}
				PointF pointF2 = (PointF)arrayList5[k];
				float_5 = pointF2.X;
				if (!flag)
				{
					float_3 = pointF2.Y;
					flag = true;
				}
				else if (!flag2)
				{
					if (float_3 < pointF2.Y)
					{
						float_4 = float_3;
						float_3 = pointF2.Y;
						flag2 = true;
					}
					else
					{
						float_4 = pointF2.Y;
						flag2 = true;
					}
				}
				else
				{
					if (float_3 < pointF2.Y)
					{
						float_3 = pointF2.Y;
					}
					if (float_4 > pointF2.Y)
					{
						float_4 = pointF2.Y;
					}
				}
				if (l == 0)
				{
					num13 = pointF2.Y;
					flag3 = true;
				}
				else if (l == arrayList2.Count - 1)
				{
					num14 = pointF2.Y;
					flag4 = true;
				}
			}
			if (class810_0.vmethod_0() && flag && flag2 && smethod_18(class2.method_18(), rectangle_0, ref float_5, ref float_3, ref float_5, ref float_4))
			{
				Struct29.smethod_0(interface42_0, float_5, float_3, float_5, float_4, class806_2);
			}
			if (class810_0.HasUpDownBars && flag3 && flag4)
			{
				int num15 = (int)(num6 / (double)(1f + num));
				RectangleF rectangleF_ = default(RectangleF);
				if (num13 <= num14)
				{
					rectangleF_.Width = num15;
					rectangleF_.Height = num14 - num13;
					rectangleF_.X = float_5 - rectangleF_.Width / 2f;
					rectangleF_.Y = num13;
					smethod_3(interface42_0, class794_2, rectangleF_);
				}
				else
				{
					rectangleF_.Width = num15;
					rectangleF_.Height = num13 - num14;
					rectangleF_.X = float_5 - rectangleF_.Width / 2f;
					rectangleF_.Y = num14;
					smethod_3(interface42_0, class794_, rectangleF_);
				}
			}
		}
		smethod_16(interface42_0, class810_0, arrayList3, rectangle_0);
		return arrayList;
	}

	private static bool smethod_18(int int_0, Rectangle rectangle_0, ref float float_0, ref float float_1, ref float float_2, ref float float_3)
	{
		float num = (float)int_0 * 1.5f;
		if ((float_0 + num <= (float)rectangle_0.X && float_2 + num <= (float)rectangle_0.X) || (float_0 - num >= (float)rectangle_0.Right && float_2 - num >= (float)rectangle_0.Right))
		{
			return false;
		}
		if ((float_1 + num <= (float)rectangle_0.Y && float_3 + num <= (float)rectangle_0.Y) || (float_1 - num >= (float)rectangle_0.Bottom && float_3 - num >= (float)rectangle_0.Bottom))
		{
			return false;
		}
		if (float_0 + num < (float)rectangle_0.X)
		{
			float_0 = (float)rectangle_0.X - num;
		}
		if (float_0 - num > (float)rectangle_0.Right)
		{
			float_0 = (float)rectangle_0.Right + num;
		}
		if (float_2 + num < (float)rectangle_0.X)
		{
			float_2 = (float)rectangle_0.X - num;
		}
		if (float_2 - num > (float)rectangle_0.Right)
		{
			float_2 = (float)rectangle_0.Right + num;
		}
		if (float_1 + num < (float)rectangle_0.Y)
		{
			float_1 = (float)rectangle_0.Y - num;
		}
		if (float_1 - num > (float)rectangle_0.Bottom)
		{
			float_1 = (float)rectangle_0.Bottom + num;
		}
		if (float_3 + num < (float)rectangle_0.Y)
		{
			float_3 = (float)rectangle_0.Y - num;
		}
		if (float_3 - num > (float)rectangle_0.Bottom)
		{
			float_3 = (float)rectangle_0.Bottom + num;
		}
		return true;
	}

	internal static void smethod_19(Interface42 interface42_0, Class787 class787_0, ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			object[] array = (object[])arrayList_0[i];
			int int_ = (int)array[0];
			int int_2 = (int)array[1];
			PointF pointF_ = (PointF)array[2];
			Class789 class789_ = (Class789)array[3];
			int int_3 = (int)((float)class787_0.Width * Struct40.float_0);
			smethod_20(interface42_0, class789_, int_, int_2, pointF_, int_3);
		}
	}

	internal static void smethod_20(Interface42 interface42_0, Class789 class789_0, int int_0, int int_1, PointF pointF_0, int int_2)
	{
		Class808 @class = class789_0.Chart.method_7();
		Class810 class2 = @class.method_9(int_0);
		Class796 class3 = class2.method_10().method_1(int_1);
		Class798 class4 = class3.method_6();
		SizeF sizeF = Struct26.smethod_0(interface42_0, class789_0, @class, int_0, int_1, int_2);
		float num = 0f;
		float num2 = 0f;
		float num3 = 4f;
		if (class2.Type != ChartType_Chart.Bubble && class2.Type != ChartType_Chart.Bubble3D)
		{
			if (class3.method_5().MarkerStyle != Enum65.const_5)
			{
				num3 += (float)(int)((float)class3.method_5().MarkerSize / 2f);
			}
		}
		else
		{
			num3 += class3.float_0 / 2f;
		}
		Enum74 @enum = class4.vmethod_0();
		if (@enum == Enum74.const_9)
		{
			@enum = Struct26.smethod_12(@class[int_0].Type);
		}
		switch (@enum)
		{
		case Enum74.const_1:
			num = pointF_0.X - sizeF.Width / 2f;
			num2 = pointF_0.Y - sizeF.Height / 2f;
			break;
		default:
			num = pointF_0.X + num3;
			num2 = pointF_0.Y - sizeF.Height / 2f;
			if (class4.IsLegendKeyShown)
			{
				num += (float)Struct26.int_0;
			}
			break;
		case Enum74.const_5:
			num = pointF_0.X - sizeF.Width / 2f;
			num2 = pointF_0.Y - sizeF.Height - num3;
			num2 -= (float)Struct26.int_0;
			break;
		case Enum74.const_6:
			num = pointF_0.X - sizeF.Width / 2f;
			num2 = pointF_0.Y + num3;
			num2 += (float)Struct26.int_0;
			break;
		case Enum74.const_7:
			num = pointF_0.X - sizeF.Width - num3;
			num2 = pointF_0.Y - sizeF.Height / 2f;
			if (class4.IsLegendKeyShown)
			{
				num -= (float)Struct26.int_0;
			}
			break;
		}
		class4.method_0().rectangle_1 = new Rectangle(Struct40.smethod_5(num), Struct40.smethod_5(num2), Struct40.smethod_3(sizeF.Width), Struct40.smethod_3(sizeF.Height));
		class4.method_0().method_9();
		Struct26.smethod_1(interface42_0, class789_0, @class, int_0, int_1, class4.method_0().rectangle_0);
	}

	private static ArrayList smethod_21(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0, float float_0, double double_0)
	{
		ArrayList arrayList = new ArrayList();
		Class787 chart = class810_0.Chart;
		ChartType_Chart[] chartType_Chart_ = new ChartType_Chart[2]
		{
			ChartType_Chart.Line,
			ChartType_Chart.LineWithDataMarkers
		};
		Enum53 @enum = class810_0.method_21();
		Class808 @class = chart.method_7();
		int count = @class.Count;
		float num = (float)class810_0.GapWidth / 100f;
		Class789 class2;
		Class789 class3;
		ArrayList arrayList2;
		if (@enum == Enum53.const_0)
		{
			class2 = chart.method_1();
			class3 = chart.method_9();
			arrayList2 = Class817.smethod_71(chart.method_7().method_0(), class810_0.Chart.vmethod_0());
		}
		else
		{
			class2 = chart.method_2();
			class3 = chart.method_10();
			arrayList2 = Class817.smethod_71(chart.method_7().method_2(), class810_0.Chart.vmethod_0());
		}
		double num2 = (class3.IsLogarithmic ? Struct40.smethod_7(class3.MaxValue) : class3.MaxValue);
		double num3 = (class3.IsLogarithmic ? Struct40.smethod_7(class3.MinValue) : class3.MinValue);
		double_0 = (class3.IsLogarithmic ? Struct40.smethod_7(double_0) : double_0);
		bool hasDropLines = class810_0.HasDropLines;
		Class806 class806_ = class810_0.method_13();
		Class806 class806_2 = class810_0.method_14();
		Class794 class794_ = class810_0.method_16();
		Class794 class794_2 = class810_0.method_17();
		int count2 = arrayList2.Count;
		Enum87 baseUnitScale = class2.BaseUnitScale;
		int int_ = (int)class2.MinValue;
		int int_2 = (int)class2.MaxValue;
		int num4 = 0;
		if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num4 = Struct19.smethod_29(baseUnitScale, int_2, int_, class810_0.Chart.vmethod_0());
			if (num4 == 0)
			{
				num4 = 1;
			}
		}
		else
		{
			num4 = Struct19.smethod_29(baseUnitScale, int_2, int_, class810_0.Chart.vmethod_0()) + 1;
		}
		double num5 = (double)rectangle_0.Width / (double)num4;
		float num6 = 0f;
		ArrayList arrayList3 = new ArrayList();
		ArrayList arrayList4 = new ArrayList();
		IList list = @class.method_17(@enum, chartType_Chart_);
		for (int i = 0; i < list.Count; i++)
		{
			Class810 class4 = (Class810)list[i];
			if ((chart.method_30() && !class4.Equals(class810_0)) || (!class810_0.HasUpDownBars && !class810_0.vmethod_0() && !class4.Equals(class810_0)))
			{
				continue;
			}
			int index = class4.Index;
			Pen pen = null;
			ArrayList arrayList5 = new ArrayList();
			for (int j = 0; j < count2; j++)
			{
				Class796 class5 = class4.method_10().method_1(j);
				if (class5 != null && !class5.imethod_0() && !class5.method_10())
				{
					pen?.Dispose();
					pen = Struct29.smethod_5(class5.method_4());
					int int_3 = int.Parse(arrayList2[j].ToString());
					int_3 = Struct19.smethod_32(baseUnitScale, int_3, class810_0.Chart.vmethod_0());
					int num7 = Struct19.smethod_29(baseUnitScale, int_3, int_, class810_0.Chart.vmethod_0());
					float num8 = (float)(num5 * (double)num7);
					num6 = (float)(num5 * (double)Struct19.smethod_29(baseUnitScale, Struct19.smethod_31(class2.BaseUnitScale, class2.MajorUnitScale, (int)class2.MajorUnit, int_3, class810_0.Chart.vmethod_0()), int_3, class810_0.Chart.vmethod_0()));
					if (class2.AxisBetweenCategories || chart.IsDataTableShown)
					{
						num8 += (float)(num5 / 2.0);
					}
					float num9 = 0f;
					num9 = ((!class2.IsPlotOrderReversed) ? ((float)rectangle_0.X + num8) : ((float)(rectangle_0.X + rectangle_0.Width) - num8));
					float num10 = float_0;
					float num11 = (float)class5.YValue;
					float num12 = (float)(((double)num11 - double_0) / (num2 - num3) * (double)rectangle_0.Height);
					Class800 class6 = class810_0.method_4();
					if (class6 != null && class6.DisplayType != Enum68.const_2)
					{
						PointF pointF_ = new PointF(num9, float_0);
						double num13 = 0.0;
						double num14 = 0.0;
						float float_ = 0f;
						float float_2 = 0f;
						if (class6 != null)
						{
							switch (class6.Type)
							{
							case Enum69.const_0:
							{
								double num15 = ((class6.MinusValue.Count > j) ? class6.method_2(class6.MinusValue[j]) : 0.0);
								num13 = num15;
								num15 = ((class6.PlusValue.Count > j) ? class6.method_2(class6.PlusValue[j]) : 0.0);
								num14 = num15;
								break;
							}
							case Enum69.const_1:
								num13 = class6.Amount;
								num14 = num13;
								break;
							case Enum69.const_2:
								num13 = class6.Amount * (double)Math.Abs(num11) / 100.0;
								num14 = num13;
								break;
							}
							float_ = (float)num13 / (float)(num2 - num3) * (float)rectangle_0.Height;
							float_2 = (float)num14 / (float)(num2 - num3) * (float)rectangle_0.Height;
							if (!class3.IsPlotOrderReversed)
							{
								pointF_.Y -= num12;
							}
							else
							{
								pointF_.Y += num12;
							}
						}
						if (class4.Equals(class810_0))
						{
							class6.method_0(pointF_, float_, float_2);
						}
					}
					num10 = (class3.IsPlotOrderReversed ? (num10 + num12) : (num10 - num12));
					PointF pointF = new PointF(num9, num10);
					if (arrayList5.Count == 0)
					{
						arrayList5.Add(pointF);
					}
					else
					{
						smethod_22(pointF, arrayList5, class2.IsPlotOrderReversed);
					}
					if (class4.Equals(class810_0))
					{
						if (hasDropLines)
						{
							Struct29.smethod_0(interface42_0, num9, num10, num9, float_0, class806_);
						}
						arrayList4.Add(pointF);
						arrayList.Add(new object[4] { index, j, pointF, class2 });
					}
				}
				else
				{
					arrayList5.Add(null);
					if (class4.Equals(class810_0))
					{
						arrayList4.Add(null);
					}
				}
			}
			if (class4.Equals(class810_0))
			{
				if (pen == null)
				{
					pen = Struct29.smethod_5(class4.method_6());
				}
				smethod_6(interface42_0, class810_0, arrayList5, pen, rectangle_0);
			}
			pen?.Dispose();
			arrayList3.Add(arrayList5);
		}
		for (int k = 0; k < count2; k++)
		{
			bool flag = false;
			bool flag2 = false;
			float float_3 = 0f;
			float float_4 = 0f;
			float float_5 = 0f;
			bool flag3 = false;
			bool flag4 = false;
			float num16 = 0f;
			float num17 = 0f;
			for (int l = 0; l < arrayList3.Count; l++)
			{
				ArrayList arrayList6 = (ArrayList)arrayList3[l];
				if (arrayList6.Count <= k || arrayList6[k] == null)
				{
					continue;
				}
				PointF pointF2 = (PointF)arrayList6[k];
				float_5 = pointF2.X;
				if (!flag)
				{
					float_3 = pointF2.Y;
					flag = true;
				}
				else if (!flag2)
				{
					if (float_3 < pointF2.Y)
					{
						float_4 = float_3;
						float_3 = pointF2.Y;
						flag2 = true;
					}
					else
					{
						float_4 = pointF2.Y;
						flag2 = true;
					}
				}
				else
				{
					if (float_3 < pointF2.Y)
					{
						float_3 = pointF2.Y;
					}
					if (float_4 > pointF2.Y)
					{
						float_4 = pointF2.Y;
					}
				}
				if (l == 0)
				{
					num16 = pointF2.Y;
					flag3 = true;
				}
				else if (l == count - 1)
				{
					num17 = pointF2.Y;
					flag4 = true;
				}
			}
			if (class810_0.vmethod_0() && flag && flag2 && smethod_18(class3.method_18(), rectangle_0, ref float_5, ref float_3, ref float_5, ref float_4))
			{
				Struct29.smethod_0(interface42_0, float_5, float_3, float_5, float_4, class806_2);
			}
			if (class810_0.HasUpDownBars && flag3 && flag4)
			{
				int num18 = (int)(num6 / (1f + num));
				RectangleF rectangleF_ = default(RectangleF);
				if (num16 <= num17)
				{
					rectangleF_.Width = num18;
					rectangleF_.Height = num17 - num16;
					rectangleF_.X = float_5 - rectangleF_.Width / 2f;
					rectangleF_.Y = num16;
					smethod_3(interface42_0, class794_2, rectangleF_);
				}
				else
				{
					rectangleF_.Width = num18;
					rectangleF_.Height = num16 - num17;
					rectangleF_.X = float_5 - rectangleF_.Width / 2f;
					rectangleF_.Y = num17;
					smethod_3(interface42_0, class794_, rectangleF_);
				}
			}
		}
		smethod_16(interface42_0, class810_0, arrayList4, rectangle_0);
		return arrayList;
	}

	private static void smethod_22(PointF pointF_0, ArrayList arrayList_0, bool bool_0)
	{
		bool flag = false;
		if (bool_0)
		{
			for (int i = 0; i <= arrayList_0.Count - 1; i++)
			{
				if (arrayList_0[i] != null)
				{
					PointF pointF = (PointF)arrayList_0[i];
					if (!(pointF_0.X > pointF.X))
					{
						arrayList_0.Insert(i, pointF_0);
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				arrayList_0.Add(pointF_0);
			}
			return;
		}
		int num = arrayList_0.Count - 1;
		while (num >= 0)
		{
			if (arrayList_0[num] != null)
			{
				PointF pointF2 = (PointF)arrayList_0[num];
				if (pointF_0.X < pointF2.X)
				{
					num--;
					continue;
				}
				if (num == arrayList_0.Count - 1)
				{
					arrayList_0.Add(pointF_0);
				}
				else
				{
					arrayList_0.Insert(num + 1, pointF_0);
				}
				flag = true;
				break;
			}
			if (num == arrayList_0.Count - 1)
			{
				arrayList_0.Add(pointF_0);
			}
			else
			{
				arrayList_0.Insert(num + 1, pointF_0);
			}
			flag = true;
			break;
		}
		if (!flag)
		{
			arrayList_0.Insert(0, pointF_0);
		}
	}

	internal static ArrayList smethod_23(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0, int int_0)
	{
		Class787 chart = class810_0.Chart;
		ChartType_Chart chartType_Chart = ChartType_Chart.ColumnStacked;
		Class808 @class = chart.method_7();
		_ = @class.Count;
		Enum53 @enum = class810_0.method_21();
		Class789 class2;
		Class789 class3;
		int num;
		if (@enum == Enum53.const_0)
		{
			class2 = chart.method_1();
			class3 = chart.method_9();
			num = @class.method_14(Enum53.const_0, chartType_Chart);
		}
		else
		{
			class2 = chart.method_2();
			class3 = chart.method_10();
			num = @class.method_14(Enum53.const_1, chartType_Chart);
		}
		if (class2.CategoryType == Enum64.const_2)
		{
			return smethod_25(interface42_0, class810_0, rectangle_0);
		}
		double num2 = (class3.IsLogarithmic ? Struct40.smethod_7(class3.MaxValue) : class3.MaxValue);
		double num3 = (class3.IsLogarithmic ? Struct40.smethod_7(class3.MinValue) : class3.MinValue);
		float num4 = 0f;
		num4 = (class3.IsPlotOrderReversed ? ((float)rectangle_0.Bottom - (float)num2 / (float)(num2 - num3) * (float)rectangle_0.Height) : ((float)rectangle_0.Y + (float)num2 / (float)(num2 - num3) * (float)rectangle_0.Height));
		float num5 = (float)class810_0.Overlap / 100f;
		float num6 = (float)class810_0.GapWidth / 100f;
		ArrayList arrayList = new ArrayList();
		int num7 = 0;
		int num8 = int_0;
		if (class2.bool_12)
		{
			num8 = (int)class2.MaxValue;
		}
		if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num7 = num8 - 1;
			if (num7 == 0)
			{
				num7 = 1;
			}
		}
		else
		{
			num7 = num8;
		}
		double num9 = (double)rectangle_0.Width / (double)num7;
		float num10 = 0f;
		IList list = @class.method_17(@enum, new ChartType_Chart[1] { chartType_Chart });
		int num11 = @class.method_19(class810_0, @enum, new ChartType_Chart[1] { chartType_Chart });
		if (num11 == -1)
		{
			return new ArrayList();
		}
		int index = class810_0.Index;
		Class795 class4 = class810_0.method_10();
		ArrayList arrayList_ = new ArrayList();
		for (int i = 0; i < class4.Count; i++)
		{
			Class796 class5 = class4.method_1(i);
			float num12 = (float)num9 / ((float)num - num5 * (float)(num - 1) + num6);
			float num13 = num12 * num5;
			float num14 = num12 * num6;
			num10 += (float)num11 * (num12 - num13);
			float num15 = (float)num9 * (float)i + num14 / 2f + num10;
			if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
			{
				num15 -= (float)(num9 / 2.0);
			}
			num15 = ((!class2.IsPlotOrderReversed) ? ((float)rectangle_0.X + num15) : ((float)(rectangle_0.X + rectangle_0.Width) - num15 - num12));
			ArrayList arrayList2 = new ArrayList();
			double yValue = class5.YValue;
			double num16 = yValue;
			if (yValue >= 0.0)
			{
				for (int j = 0; j < num11; j++)
				{
					Class796 class6 = ((Class810)list[j]).method_10().method_1(i);
					if (class6 != null)
					{
						double yValue2 = class6.YValue;
						if (yValue2 > 0.0)
						{
							num16 += yValue2;
						}
					}
				}
			}
			else
			{
				for (int k = 0; k < num11; k++)
				{
					Class796 class7 = ((Class810)list[k]).method_10().method_1(i);
					if (class7 != null)
					{
						double yValue3 = class7.YValue;
						if (yValue3 <= 0.0)
						{
							num16 += yValue3;
						}
					}
				}
			}
			float num17 = (float)Math.Abs(yValue) / (float)(num2 - num3) * (float)rectangle_0.Height;
			float num18 = (float)Math.Abs(num16) / (float)(num2 - num3) * (float)rectangle_0.Height;
			bool flag = false;
			if (num17 == 0f)
			{
				flag = true;
			}
			Class800 class8 = class810_0.method_4();
			if (class8 != null && class8.DisplayType != Enum68.const_2)
			{
				PointF pointF_ = new PointF(num15 + num12 / 2f, num4);
				double num19 = 0.0;
				double num20 = 0.0;
				float float_ = 0f;
				float float_2 = 0f;
				if (class8 != null)
				{
					switch (class8.Type)
					{
					case Enum69.const_0:
					{
						double num21 = ((class8.MinusValue.Count > i) ? class8.method_2(class8.MinusValue[i]) : 0.0);
						num19 = num21;
						num21 = ((class8.PlusValue.Count > i) ? class8.method_2(class8.PlusValue[i]) : 0.0);
						num20 = num21;
						break;
					}
					case Enum69.const_1:
						num19 = class8.Amount;
						num20 = num19;
						break;
					case Enum69.const_2:
						num19 = class8.Amount * Math.Abs(yValue) / 100.0;
						num20 = num19;
						break;
					}
					float_ = (float)num19 / (float)(num2 - num3) * (float)rectangle_0.Height;
					float_2 = (float)num20 / (float)(num2 - num3) * (float)rectangle_0.Height;
					if (!class3.IsPlotOrderReversed)
					{
						if (yValue <= 0.0)
						{
							pointF_.Y += num18;
						}
						else
						{
							pointF_.Y -= num18;
						}
					}
					else if (yValue <= 0.0)
					{
						pointF_.Y -= num18;
					}
					else
					{
						pointF_.Y += num18;
					}
				}
				class8.method_0(pointF_, float_, float_2);
			}
			num18 = ((!class3.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num4 - num18) : (num4 + num18 - num17)) : ((!(yValue < 0.0)) ? (num4 + num18 - num17) : (num4 - num18)));
			if (class5.method_4().IsVisible)
			{
				num17 -= 1f;
			}
			RectangleF rectangleF = new RectangleF(num15, num18, num12, num17 + 1f);
			if (rectangleF.Y < (float)rectangle_0.Y)
			{
				rectangleF.Height -= (float)rectangle_0.Y - rectangleF.Y;
				rectangleF.Y = rectangle_0.Y;
			}
			if (rectangleF.Bottom > (float)(rectangle_0.Bottom + 1))
			{
				rectangleF.Height -= rectangleF.Bottom - (float)rectangle_0.Bottom;
			}
			if (rectangleF.Right >= (float)rectangle_0.X && rectangleF.Left <= (float)rectangle_0.Right)
			{
				if (rectangleF.X < (float)rectangle_0.X)
				{
					rectangleF.Width -= (float)rectangle_0.X - rectangleF.X;
					rectangleF.X = rectangle_0.X;
				}
				else if (rectangleF.Right > (float)rectangle_0.Right)
				{
					rectangleF.Width -= rectangleF.Right - (float)rectangle_0.Right;
				}
				if (rectangleF.Width + 1f >= (num12 - 1f) / 3f)
				{
					if (!flag)
					{
						smethod_2(interface42_0, class5, rectangleF, chart.method_14(class810_0.vmethod_7()).GetColor(index), num4, class3);
					}
					object[] array = new object[5];
					bool flag2 = rectangleF.Y + rectangleF.Height / 2f < num4 || (yValue == 0.0 && ((!class3.IsPlotOrderReversed) ? true : false));
					array[0] = index;
					array[1] = i;
					array[2] = rectangleF;
					array[3] = class2;
					array[4] = flag2;
					if (!class5.imethod_0())
					{
						arrayList.Add(array);
					}
					if (class810_0.HasSeriesLines)
					{
						arrayList2.Add(rectangleF);
						arrayList2.Add(flag2);
					}
				}
			}
			smethod_24(interface42_0, class810_0, ref arrayList_, arrayList2);
		}
		return arrayList;
	}

	private static void smethod_24(Interface42 interface42_0, Class810 class810_0, ref ArrayList arrayList_0, ArrayList arrayList_1)
	{
		if (arrayList_0.Count > 0 && arrayList_1.Count > 0 && class810_0.HasSeriesLines)
		{
			RectangleF rectangleF = (RectangleF)arrayList_0[0];
			bool flag = (bool)arrayList_0[1];
			RectangleF rectangleF2 = (RectangleF)arrayList_1[0];
			bool flag2 = (bool)arrayList_1[1];
			PointF pointF_;
			PointF pointF_2;
			if (!(rectangleF.X < rectangleF2.X))
			{
				pointF_ = ((!flag) ? new PointF(rectangleF.Left, rectangleF.Bottom) : new PointF(rectangleF.Left, rectangleF.Top));
				pointF_2 = ((!flag2) ? new PointF(rectangleF2.Right, rectangleF2.Bottom) : new PointF(rectangleF2.Right, rectangleF2.Top));
			}
			else
			{
				pointF_ = ((!flag) ? new PointF(rectangleF.Right, rectangleF.Bottom) : new PointF(rectangleF.Right, rectangleF.Top));
				pointF_2 = ((!flag2) ? new PointF(rectangleF2.Left, rectangleF2.Bottom) : new PointF(rectangleF2.Left, rectangleF2.Top));
			}
			Struct29.smethod_1(interface42_0, pointF_, pointF_2, class810_0.method_18());
		}
		if (arrayList_1.Count > 0)
		{
			arrayList_0 = arrayList_1;
		}
	}

	private static ArrayList smethod_25(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0)
	{
		Class787 chart = class810_0.Chart;
		Enum53 @enum = class810_0.method_21();
		ChartType_Chart chartType_Chart = ChartType_Chart.ColumnStacked;
		_ = chart.method_7().Count;
		Class808 @class = chart.method_7();
		float num = (float)class810_0.Overlap / 100f;
		float num2 = (float)class810_0.GapWidth / 100f;
		Class789 class2;
		Class789 class3;
		int num3;
		ArrayList arrayList;
		if (@enum == Enum53.const_0)
		{
			class2 = chart.method_1();
			class3 = chart.method_9();
			num3 = @class.method_14(Enum53.const_0, chartType_Chart);
			arrayList = Class817.smethod_71(chart.method_7().method_0(), class810_0.Chart.vmethod_0());
		}
		else
		{
			class2 = chart.method_2();
			class3 = chart.method_10();
			num3 = @class.method_14(Enum53.const_1, chartType_Chart);
			arrayList = Class817.smethod_71(chart.method_7().method_2(), class810_0.Chart.vmethod_0());
		}
		float num4 = 0f;
		num4 = (class3.IsPlotOrderReversed ? ((float)rectangle_0.Bottom - (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height) : ((float)rectangle_0.Y + (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height));
		_ = class3.MinValue;
		_ = class3.MaxValue;
		ArrayList arrayList2 = new ArrayList();
		int count = arrayList.Count;
		Enum87 baseUnitScale = class2.BaseUnitScale;
		int int_ = (int)class2.MinValue;
		int int_2 = (int)class2.MaxValue;
		int num5 = 0;
		if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num5 = Struct19.smethod_29(baseUnitScale, int_2, int_, class810_0.Chart.vmethod_0());
			if (num5 == 0)
			{
				num5 = 1;
			}
		}
		else
		{
			num5 = Struct19.smethod_29(baseUnitScale, int_2, int_, class810_0.Chart.vmethod_0()) + 1;
		}
		double num6 = (double)rectangle_0.Width / (double)num5;
		ArrayList arrayList_ = new ArrayList();
		int num7 = 0;
		while (true)
		{
			if (num7 < count)
			{
				Class796 class4 = class810_0.method_10().method_1(num7);
				float num8 = (float)(num6 / (double)((float)num3 - num * (float)(num3 - 1) + num2));
				float num9 = num8 * num;
				float num10 = num8 * num2;
				int int_3 = int.Parse(arrayList[num7].ToString());
				int_3 = Struct19.smethod_32(baseUnitScale, int_3, class810_0.Chart.vmethod_0());
				int num11 = Struct19.smethod_29(baseUnitScale, int_3, int_, class810_0.Chart.vmethod_0());
				float num12 = (float)(num6 * (double)num11);
				if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
				{
					num12 -= (float)(num6 / 2.0);
				}
				float num13 = 0f;
				num13 = ((!class2.IsPlotOrderReversed) ? ((float)rectangle_0.X + num12 + num10 / 2f + 1f) : ((float)(rectangle_0.X + rectangle_0.Width) - num12 - num10 / 2f - num8 - 1f));
				IList list = @class.method_17(@enum, new ChartType_Chart[1] { chartType_Chart });
				int num14 = @class.method_19(class810_0, @enum, new ChartType_Chart[1] { chartType_Chart });
				if (num14 == -1)
				{
					break;
				}
				int index = class810_0.Index;
				num13 = ((!class2.IsPlotOrderReversed) ? (num13 + (float)num14 * (num8 - num9)) : (num13 - (float)num14 * (num8 - num9)));
				ArrayList arrayList3 = new ArrayList();
				if (class4 != null)
				{
					double yValue = class4.YValue;
					double num15 = yValue;
					if (yValue >= 0.0)
					{
						for (int i = 0; i < num14; i++)
						{
							Class796 class5 = ((Class810)list[i]).method_10().method_1(num7);
							if (class5 != null)
							{
								double yValue2 = class5.YValue;
								if (yValue2 > 0.0)
								{
									num15 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int j = 0; j < num14; j++)
						{
							Class796 class6 = ((Class810)list[j]).method_10().method_1(num7);
							if (class6 != null)
							{
								double yValue3 = class6.YValue;
								if (yValue3 <= 0.0)
								{
									num15 += yValue3;
								}
							}
						}
					}
					float num16 = (float)Math.Abs(yValue) / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
					float num17 = (float)Math.Abs(num15) / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
					bool flag = false;
					if (num16 == 0f)
					{
						flag = true;
					}
					Class800 class7 = class810_0.method_4();
					if (class7 != null && class7.DisplayType != Enum68.const_2)
					{
						PointF pointF_ = new PointF(num13 + num8 / 2f, num4);
						double num18 = 0.0;
						double num19 = 0.0;
						float float_ = 0f;
						float float_2 = 0f;
						if (class7 != null)
						{
							switch (class7.Type)
							{
							case Enum69.const_0:
							{
								double num20 = ((class7.MinusValue.Count > num7) ? class7.method_2(class7.MinusValue[num7]) : 0.0);
								num18 = num20;
								num20 = ((class7.PlusValue.Count > num7) ? class7.method_2(class7.PlusValue[num7]) : 0.0);
								num19 = num20;
								break;
							}
							case Enum69.const_1:
								num18 = class7.Amount;
								num19 = num18;
								break;
							case Enum69.const_2:
								num18 = class7.Amount * Math.Abs(yValue) / 100.0;
								num19 = num18;
								break;
							}
							float_ = (float)num18 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
							float_2 = (float)num19 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
							if (!class3.IsPlotOrderReversed)
							{
								if (yValue <= 0.0)
								{
									pointF_.Y += num17;
								}
								else
								{
									pointF_.Y -= num17;
								}
							}
							else if (yValue <= 0.0)
							{
								pointF_.Y -= num17;
							}
							else
							{
								pointF_.Y += num17;
							}
						}
						class7.method_0(pointF_, float_, float_2);
					}
					num17 = ((!class3.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num4 - num17) : (num4 + num17 - num16)) : ((!(yValue < 0.0)) ? (num4 + num17 - num16) : (num4 - num17)));
					if (class4.method_4().IsVisible)
					{
						num16 -= 1f;
					}
					RectangleF rectangleF = new RectangleF(num13, num17, num8, num16 + 1f);
					if (rectangleF.Y < (float)rectangle_0.Y)
					{
						rectangleF.Height -= (float)rectangle_0.Y - rectangleF.Y;
						rectangleF.Y = rectangle_0.Y;
					}
					if (rectangleF.Bottom > (float)(rectangle_0.Bottom + 1))
					{
						rectangleF.Height -= rectangleF.Bottom - (float)rectangle_0.Bottom;
					}
					if (rectangleF.Right >= (float)rectangle_0.X && rectangleF.Left <= (float)rectangle_0.Right)
					{
						if (rectangleF.X < (float)rectangle_0.X)
						{
							rectangleF.Width -= (float)rectangle_0.X - rectangleF.X;
							rectangleF.X = rectangle_0.X;
						}
						else if (rectangleF.Right > (float)rectangle_0.Right)
						{
							rectangleF.Width -= rectangleF.Right - (float)rectangle_0.Right;
						}
						if (rectangleF.Width + 1f >= (num8 - 1f) / 3f)
						{
							if (!flag)
							{
								smethod_2(interface42_0, class4, rectangleF, chart.method_14(class810_0.vmethod_7()).GetColor(index), num4, class3);
							}
							object[] array = new object[5];
							bool flag2 = rectangleF.Y + rectangleF.Height / 2f < num4 || (yValue == 0.0 && ((!class3.IsPlotOrderReversed) ? true : false));
							array[0] = index;
							array[1] = num7;
							array[2] = rectangleF;
							array[3] = class2;
							array[4] = flag2;
							if (!class4.imethod_0())
							{
								arrayList2.Add(array);
							}
							if (class810_0.HasSeriesLines)
							{
								arrayList3.Add(rectangleF);
								arrayList3.Add(flag2);
							}
						}
					}
				}
				smethod_24(interface42_0, class810_0, ref arrayList_, arrayList3);
				num7++;
				continue;
			}
			return arrayList2;
		}
		return arrayList2;
	}

	internal static ArrayList smethod_26(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0, float float_0, int int_0)
	{
		ArrayList arrayList = new ArrayList();
		Class787 chart = class810_0.Chart;
		ChartType_Chart[] chartType_Chart_ = new ChartType_Chart[2]
		{
			ChartType_Chart.LineStacked,
			ChartType_Chart.LineStackedWithDataMarkers
		};
		Enum53 @enum = class810_0.method_21();
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
		if (@class.CategoryType == Enum64.const_2)
		{
			return smethod_27(interface42_0, class810_0, rectangle_0, float_0);
		}
		float num = 0f;
		num = (class2.IsPlotOrderReversed ? ((float)rectangle_0.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height) : ((float)rectangle_0.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height));
		Class808 class3 = chart.method_7();
		int count = class3.Count;
		float num2 = (float)class810_0.GapWidth / 100f;
		_ = class2.MinValue;
		_ = class2.MaxValue;
		bool hasDropLines = class810_0.HasDropLines;
		Class806 class806_ = class810_0.method_13();
		Class806 class806_2 = class810_0.method_14();
		Class794 class794_ = class810_0.method_16();
		Class794 class794_2 = class810_0.method_17();
		int num3 = 0;
		int num4 = int_0;
		if (@class.bool_12)
		{
			num4 = (int)@class.MaxValue;
		}
		if (!@class.AxisBetweenCategories && !chart.IsDataTableShown)
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
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		IList list = class3.method_17(@enum, chartType_Chart_);
		for (int i = 0; i < list.Count; i++)
		{
			Class810 class4 = (Class810)list[i];
			if ((chart.method_30() && !class4.Equals(class810_0)) || (!class810_0.HasUpDownBars && !class810_0.vmethod_0() && !class4.Equals(class810_0)))
			{
				continue;
			}
			int num6 = class3.method_19(class4, @enum, chartType_Chart_);
			int index = class4.Index;
			Pen pen = null;
			ArrayList arrayList4 = new ArrayList();
			Class795 class5 = class4.method_10();
			for (int j = 0; j < int_0; j++)
			{
				Class796 class6 = class5.method_1(j);
				if (class6 != null)
				{
					pen?.Dispose();
					pen = Struct29.smethod_5(class6.method_4());
					double num7 = (float)num5 * (float)j + 1f;
					if (@class.AxisBetweenCategories || chart.IsDataTableShown)
					{
						num7 += (double)(float)(num5 / 2.0);
					}
					num7 = ((!@class.IsPlotOrderReversed) ? ((double)rectangle_0.X + num7) : ((double)(rectangle_0.X + rectangle_0.Width) - num7));
					double yValue = class6.YValue;
					double num8 = yValue;
					if (yValue >= 0.0)
					{
						for (int k = 0; k < num6; k++)
						{
							Class796 class7 = ((Class810)list[k]).method_10().method_1(j);
							if (class7 != null)
							{
								double yValue2 = class7.YValue;
								if (yValue2 > 0.0)
								{
									num8 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int l = 0; l < num6; l++)
						{
							Class796 class8 = ((Class810)list[l]).method_10().method_1(j);
							if (class8 != null)
							{
								double yValue3 = class8.YValue;
								if (yValue3 <= 0.0)
								{
									num8 += yValue3;
								}
							}
						}
					}
					float num9 = (float)Math.Abs(num8) / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height;
					Class800 class9 = class810_0.method_4();
					if (class9 != null && class9.DisplayType != Enum68.const_2)
					{
						PointF pointF_ = new PointF((float)num7, num);
						double num10 = 0.0;
						double num11 = 0.0;
						float float_ = 0f;
						float float_2 = 0f;
						if (class9 != null && !class6.imethod_0())
						{
							switch (class9.Type)
							{
							case Enum69.const_0:
							{
								double num12 = ((class9.MinusValue.Count > j) ? class9.method_2(class9.MinusValue[j]) : 0.0);
								num10 = num12;
								num12 = ((class9.PlusValue.Count > j) ? class9.method_2(class9.PlusValue[j]) : 0.0);
								num11 = num12;
								break;
							}
							case Enum69.const_1:
								num10 = class9.Amount;
								num11 = num10;
								break;
							case Enum69.const_2:
								num10 = class9.Amount * Math.Abs(yValue) / 100.0;
								num11 = num10;
								break;
							}
							float_ = (float)num10 / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height;
							float_2 = (float)num11 / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height;
							if (!class2.IsPlotOrderReversed)
							{
								if (yValue < 0.0)
								{
									pointF_.Y += num9;
								}
								else
								{
									pointF_.Y -= num9;
								}
							}
							else if (yValue < 0.0)
							{
								pointF_.Y -= num9;
							}
							else
							{
								pointF_.Y += num9;
							}
						}
						if (class4.Equals(class810_0) && !class6.imethod_0())
						{
							class9.method_0(pointF_, float_, float_2);
						}
					}
					num9 = ((!class2.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num - num9) : (num + num9)) : ((!(yValue < 0.0)) ? (num + num9) : (num - num9)));
					PointF pointF = new PointF((float)num7, num9);
					arrayList4.Add(pointF);
					if (class4.Equals(class810_0))
					{
						if (hasDropLines)
						{
							Struct29.smethod_0(interface42_0, (float)num7, num9, (float)num7, float_0, class806_);
						}
						arrayList3.Add(pointF);
						if (!class6.imethod_0())
						{
							arrayList.Add(new object[4] { index, j, pointF, @class });
						}
					}
				}
				else
				{
					arrayList4.Add(null);
					if (class4.Equals(class810_0))
					{
						arrayList3.Add(null);
					}
				}
			}
			if (class4.Equals(class810_0))
			{
				if (pen == null)
				{
					pen = Struct29.smethod_5(class4.method_6());
				}
				smethod_6(interface42_0, class4, arrayList4, pen, rectangle_0);
			}
			pen?.Dispose();
			arrayList2.Add(arrayList4);
		}
		for (int m = 0; m < int_0; m++)
		{
			bool flag = false;
			bool flag2 = false;
			float float_3 = 0f;
			float float_4 = 0f;
			float float_5 = 0f;
			bool flag3 = false;
			bool flag4 = false;
			float num13 = 0f;
			float num14 = 0f;
			for (int n = 0; n < arrayList2.Count; n++)
			{
				ArrayList arrayList5 = (ArrayList)arrayList2[n];
				if (arrayList5.Count <= m || arrayList5[m] == null)
				{
					continue;
				}
				PointF pointF2 = (PointF)arrayList5[m];
				float_5 = pointF2.X;
				if (!flag)
				{
					float_3 = pointF2.Y;
					flag = true;
				}
				else if (!flag2)
				{
					if (float_3 < pointF2.Y)
					{
						float_4 = float_3;
						float_3 = pointF2.Y;
						flag2 = true;
					}
					else
					{
						float_4 = pointF2.Y;
						flag2 = true;
					}
				}
				else
				{
					if (float_3 < pointF2.Y)
					{
						float_3 = pointF2.Y;
					}
					if (float_4 > pointF2.Y)
					{
						float_4 = pointF2.Y;
					}
				}
				if (n == 0)
				{
					num13 = pointF2.Y;
					flag3 = true;
				}
				else if (n == count - 1)
				{
					num14 = pointF2.Y;
					flag4 = true;
				}
			}
			if (class810_0.vmethod_0() && flag && flag2 && smethod_18(class2.method_18(), rectangle_0, ref float_5, ref float_3, ref float_5, ref float_4))
			{
				Struct29.smethod_0(interface42_0, float_5, float_3, float_5, float_4, class806_2);
			}
			if (class810_0.HasUpDownBars && flag3 && flag4)
			{
				int num15 = (int)(num5 / (double)(1f + num2));
				RectangleF rectangleF_ = default(RectangleF);
				if (num13 <= num14)
				{
					rectangleF_.Width = num15;
					rectangleF_.Height = num14 - num13;
					rectangleF_.X = float_5 - rectangleF_.Width / 2f;
					rectangleF_.Y = num13;
					smethod_3(interface42_0, class794_2, rectangleF_);
				}
				else
				{
					rectangleF_.Width = num15;
					rectangleF_.Height = num13 - num14;
					rectangleF_.X = float_5 - rectangleF_.Width / 2f;
					rectangleF_.Y = num14;
					smethod_3(interface42_0, class794_, rectangleF_);
				}
			}
		}
		smethod_16(interface42_0, class810_0, arrayList3, rectangle_0);
		return arrayList;
	}

	private static ArrayList smethod_27(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0, float float_0)
	{
		ArrayList arrayList = new ArrayList();
		Class787 chart = class810_0.Chart;
		ChartType_Chart[] chartType_Chart_ = new ChartType_Chart[2]
		{
			ChartType_Chart.LineStacked,
			ChartType_Chart.LineStackedWithDataMarkers
		};
		Enum53 @enum = class810_0.method_21();
		Class808 @class = chart.method_7();
		int count = @class.Count;
		float num = (float)class810_0.GapWidth / 100f;
		Class789 class2;
		Class789 class3;
		ArrayList arrayList2;
		if (@enum == Enum53.const_0)
		{
			class2 = chart.method_1();
			class3 = chart.method_9();
			arrayList2 = Class817.smethod_71(chart.method_7().method_0(), class810_0.Chart.vmethod_0());
		}
		else
		{
			class2 = chart.method_2();
			class3 = chart.method_10();
			arrayList2 = Class817.smethod_71(chart.method_7().method_2(), class810_0.Chart.vmethod_0());
		}
		float num2 = 0f;
		num2 = (class3.IsPlotOrderReversed ? ((float)rectangle_0.Bottom - (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height) : ((float)rectangle_0.Y + (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height));
		_ = class3.MinValue;
		_ = class3.MaxValue;
		bool hasDropLines = class810_0.HasDropLines;
		Class806 class806_ = class810_0.method_13();
		Class806 class806_2 = class810_0.method_14();
		Class794 class794_ = class810_0.method_16();
		Class794 class794_2 = class810_0.method_17();
		int count2 = arrayList2.Count;
		Enum87 baseUnitScale = class2.BaseUnitScale;
		int int_ = (int)class2.MinValue;
		int int_2 = (int)class2.MaxValue;
		int num3 = 0;
		if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num3 = Struct19.smethod_29(baseUnitScale, int_2, int_, class810_0.Chart.vmethod_0());
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		else
		{
			num3 = Struct19.smethod_29(baseUnitScale, int_2, int_, class810_0.Chart.vmethod_0()) + 1;
		}
		double num4 = (double)rectangle_0.Width / (double)num3;
		float num5 = 0f;
		ArrayList arrayList3 = new ArrayList();
		ArrayList arrayList4 = new ArrayList();
		IList list = @class.method_17(@enum, chartType_Chart_);
		for (int i = 0; i < list.Count; i++)
		{
			Class810 class4 = (Class810)list[i];
			if ((chart.method_30() && !class4.Equals(class810_0)) || (!class810_0.HasUpDownBars && !class810_0.vmethod_0() && !class4.Equals(class810_0)))
			{
				continue;
			}
			int num6 = @class.method_19(class4, @enum, chartType_Chart_);
			int index = class4.Index;
			Pen pen = null;
			ArrayList arrayList5 = new ArrayList();
			for (int j = 0; j < count2; j++)
			{
				Class796 class5 = class4.method_10().method_1(j);
				if (class5 != null)
				{
					pen?.Dispose();
					pen = Struct29.smethod_5(class5.method_4());
					int int_3 = int.Parse(arrayList2[j].ToString());
					int_3 = Struct19.smethod_32(baseUnitScale, int_3, class810_0.Chart.vmethod_0());
					int num7 = Struct19.smethod_29(baseUnitScale, int_3, int_, class810_0.Chart.vmethod_0());
					float num8 = (float)(num4 * (double)num7);
					num5 = (float)(num4 * (double)Struct19.smethod_29(baseUnitScale, Struct19.smethod_31(class2.BaseUnitScale, class2.MajorUnitScale, (int)class2.MajorUnit, int_3, class810_0.Chart.vmethod_0()), int_3, class810_0.Chart.vmethod_0()));
					if (class2.AxisBetweenCategories || chart.IsDataTableShown)
					{
						num8 += (float)(num4 / 2.0);
					}
					float num9 = 0f;
					num9 = ((!class2.IsPlotOrderReversed) ? ((float)rectangle_0.X + num8) : ((float)(rectangle_0.X + rectangle_0.Width) - num8));
					double yValue = class5.YValue;
					double num10 = yValue;
					if (yValue >= 0.0)
					{
						for (int k = 0; k < num6; k++)
						{
							Class796 class6 = ((Class810)list[k]).method_10().method_1(j);
							if (class6 != null)
							{
								double yValue2 = class6.YValue;
								if (yValue2 > 0.0)
								{
									num10 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int l = 0; l < num6; l++)
						{
							Class796 class7 = ((Class810)list[l]).method_10().method_1(j);
							if (class7 != null)
							{
								double yValue3 = class7.YValue;
								if (yValue3 <= 0.0)
								{
									num10 += yValue3;
								}
							}
						}
					}
					float num11 = (float)Math.Abs(num10) / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
					Class800 class8 = class810_0.method_4();
					if (class8 != null && class8.DisplayType != Enum68.const_2)
					{
						PointF pointF_ = new PointF(num9, num2);
						double num12 = 0.0;
						double num13 = 0.0;
						float float_ = 0f;
						float float_2 = 0f;
						if (class8 != null && !class5.imethod_0())
						{
							switch (class8.Type)
							{
							case Enum69.const_0:
							{
								double num14 = ((class8.MinusValue.Count > j) ? class8.method_2(class8.MinusValue[j]) : 0.0);
								num12 = num14;
								num14 = ((class8.PlusValue.Count > j) ? class8.method_2(class8.PlusValue[j]) : 0.0);
								num13 = num14;
								break;
							}
							case Enum69.const_1:
								num12 = class8.Amount;
								num13 = num12;
								break;
							case Enum69.const_2:
								num12 = class8.Amount * Math.Abs(yValue) / 100.0;
								num13 = num12;
								break;
							}
							float_ = (float)num12 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
							float_2 = (float)num13 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
							if (!class3.IsPlotOrderReversed)
							{
								if (yValue < 0.0)
								{
									pointF_.Y += num11;
								}
								else
								{
									pointF_.Y -= num11;
								}
							}
							else if (yValue < 0.0)
							{
								pointF_.Y -= num11;
							}
							else
							{
								pointF_.Y += num11;
							}
						}
						if (class4.Equals(class810_0) && !class5.imethod_0())
						{
							class8.method_0(pointF_, float_, float_2);
						}
					}
					num11 = ((!class3.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num2 - num11) : (num2 + num11)) : ((!(yValue < 0.0)) ? (num2 + num11) : (num2 - num11)));
					PointF pointF = new PointF(num9, num11);
					if (arrayList5.Count == 0)
					{
						arrayList5.Add(pointF);
					}
					else
					{
						smethod_22(pointF, arrayList5, class2.IsPlotOrderReversed);
					}
					if (class4.Equals(class810_0))
					{
						if (hasDropLines)
						{
							Struct29.smethod_0(interface42_0, num9, num11, num9, float_0, class806_);
						}
						arrayList4.Add(pointF);
						if (!class5.imethod_0())
						{
							arrayList.Add(new object[4] { index, j, pointF, class2 });
						}
					}
				}
				else
				{
					arrayList5.Add(null);
					if (class4.Equals(class810_0))
					{
						arrayList4.Add(null);
					}
				}
			}
			if (class4.Equals(class810_0))
			{
				if (pen == null)
				{
					pen = Struct29.smethod_5(class4.method_6());
				}
				smethod_6(interface42_0, class4, arrayList5, pen, rectangle_0);
			}
			pen?.Dispose();
			arrayList3.Add(arrayList5);
		}
		for (int m = 0; m < count2; m++)
		{
			bool flag = false;
			bool flag2 = false;
			float float_3 = 0f;
			float float_4 = 0f;
			float float_5 = 0f;
			bool flag3 = false;
			bool flag4 = false;
			float num15 = 0f;
			float num16 = 0f;
			for (int n = 0; n < arrayList3.Count; n++)
			{
				ArrayList arrayList6 = (ArrayList)arrayList3[n];
				if (arrayList6.Count <= m || arrayList6[m] == null)
				{
					continue;
				}
				PointF pointF2 = (PointF)arrayList6[m];
				float_5 = pointF2.X;
				if (!flag)
				{
					float_3 = pointF2.Y;
					flag = true;
				}
				else if (!flag2)
				{
					if (float_3 < pointF2.Y)
					{
						float_4 = float_3;
						float_3 = pointF2.Y;
						flag2 = true;
					}
					else
					{
						float_4 = pointF2.Y;
						flag2 = true;
					}
				}
				else
				{
					if (float_3 < pointF2.Y)
					{
						float_3 = pointF2.Y;
					}
					if (float_4 > pointF2.Y)
					{
						float_4 = pointF2.Y;
					}
				}
				if (n == 0)
				{
					num15 = pointF2.Y;
					flag3 = true;
				}
				else if (n == count - 1)
				{
					num16 = pointF2.Y;
					flag4 = true;
				}
			}
			if (class810_0.vmethod_0() && flag && flag2 && smethod_18(class3.method_18(), rectangle_0, ref float_5, ref float_3, ref float_5, ref float_4))
			{
				Struct29.smethod_0(interface42_0, float_5, float_3, float_5, float_4, class806_2);
			}
			if (class810_0.HasUpDownBars && flag3 && flag4)
			{
				int num17 = (int)(num5 / (1f + num));
				RectangleF rectangleF_ = default(RectangleF);
				if (num15 <= num16)
				{
					rectangleF_.Width = num17;
					rectangleF_.Height = num16 - num15;
					rectangleF_.X = float_5 - rectangleF_.Width / 2f;
					rectangleF_.Y = num15;
					smethod_3(interface42_0, class794_2, rectangleF_);
				}
				else
				{
					rectangleF_.Width = num17;
					rectangleF_.Height = num15 - num16;
					rectangleF_.X = float_5 - rectangleF_.Width / 2f;
					rectangleF_.Y = num16;
					smethod_3(interface42_0, class794_, rectangleF_);
				}
			}
		}
		smethod_16(interface42_0, class810_0, arrayList4, rectangle_0);
		return arrayList;
	}

	internal static ArrayList smethod_28(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0, int int_0)
	{
		Class787 chart = class810_0.Chart;
		Enum53 @enum = class810_0.method_21();
		ChartType_Chart chartType_Chart = ChartType_Chart.Column100PercentStacked;
		Class808 @class = chart.method_7();
		_ = @class.Count;
		Class789 class2;
		Class789 class3;
		int num;
		if (@enum == Enum53.const_0)
		{
			class2 = chart.method_1();
			class3 = chart.method_9();
			num = @class.method_14(Enum53.const_0, chartType_Chart);
		}
		else
		{
			class2 = chart.method_2();
			class3 = chart.method_10();
			num = @class.method_14(Enum53.const_1, chartType_Chart);
		}
		if (class2.CategoryType == Enum64.const_2)
		{
			return smethod_29(interface42_0, class810_0, rectangle_0);
		}
		float num2 = 0f;
		num2 = (class3.IsPlotOrderReversed ? ((float)rectangle_0.Bottom - (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height) : ((float)rectangle_0.Y + (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height));
		float num3 = (float)class810_0.Overlap / 100f;
		float num4 = (float)class810_0.GapWidth / 100f;
		ArrayList arrayList = new ArrayList();
		int num5 = 0;
		int num6 = int_0;
		if (class2.bool_12)
		{
			num6 = (int)class2.MaxValue;
		}
		if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num5 = num6 - 1;
			if (num5 == 0)
			{
				num5 = 1;
			}
		}
		else
		{
			num5 = num6;
		}
		double num7 = (double)rectangle_0.Width / (double)num5;
		float num8 = 0f;
		IList list = @class.method_17(@enum, new ChartType_Chart[1] { chartType_Chart });
		int num9 = @class.method_19(class810_0, @enum, new ChartType_Chart[1] { chartType_Chart });
		if (num9 == -1)
		{
			return arrayList;
		}
		int index = class810_0.Index;
		Class795 class4 = class810_0.method_10();
		ArrayList arrayList_ = new ArrayList();
		for (int i = 0; i < class4.Count; i++)
		{
			Class796 class5 = class4.method_1(i);
			float num10 = (float)num7 / ((float)num - num3 * (float)(num - 1) + num4);
			float num11 = num10 * num3;
			float num12 = num10 * num4;
			num8 = (float)num9 * (num10 - num11);
			float num13 = (float)num7 * (float)i + num12 / 2f + num8;
			if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
			{
				num13 -= (float)(num7 / 2.0);
			}
			num13 = ((!class2.IsPlotOrderReversed) ? ((float)rectangle_0.X + num13) : ((float)(rectangle_0.X + rectangle_0.Width) - num13 - num10));
			ArrayList arrayList2 = new ArrayList();
			double yValue = class5.YValue;
			double num14 = yValue;
			double num15 = 0.0;
			if (yValue >= 0.0)
			{
				for (int j = 0; j < num9; j++)
				{
					Class796 class6 = ((Class810)list[j]).method_10().method_1(i);
					if (class6 != null)
					{
						double yValue2 = class6.YValue;
						if (yValue2 > 0.0)
						{
							num14 += yValue2;
						}
					}
				}
			}
			else
			{
				for (int k = 0; k < num9; k++)
				{
					Class796 class7 = ((Class810)list[k]).method_10().method_1(i);
					if (class7 != null)
					{
						double yValue3 = class7.YValue;
						if (yValue3 <= 0.0)
						{
							num14 += yValue3;
						}
					}
				}
			}
			for (int l = 0; l < list.Count; l++)
			{
				Class796 class8 = ((Class810)list[l]).method_10().method_1(i);
				if (class8 != null)
				{
					double yValue4 = class8.YValue;
					num15 += Math.Abs(yValue4);
				}
			}
			if (num15 == 0.0 || num15 == 0.0)
			{
				continue;
			}
			float num16 = (float)Math.Abs(yValue) * 100f / (float)num15 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
			float num17 = (float)Math.Abs(num14) * 100f / (float)num15 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
			bool flag = false;
			if (num16 == 0f)
			{
				flag = true;
			}
			Class800 class9 = class810_0.method_4();
			if (class9 != null && class9.DisplayType != Enum68.const_2)
			{
				PointF pointF_ = new PointF(num13 + num10 / 2f, num2);
				double num18 = 0.0;
				double num19 = 0.0;
				float float_ = 0f;
				float float_2 = 0f;
				if (class9 != null)
				{
					switch (class9.Type)
					{
					case Enum69.const_0:
					{
						double num20 = ((class9.MinusValue.Count > i) ? class9.method_2(class9.MinusValue[i]) : 0.0);
						num18 = num20;
						num20 = ((class9.PlusValue.Count > i) ? class9.method_2(class9.PlusValue[i]) : 0.0);
						num19 = num20;
						break;
					}
					case Enum69.const_1:
						num18 = class9.Amount;
						num19 = num18;
						break;
					case Enum69.const_2:
						num18 = class9.Amount * Math.Abs(yValue) / 100.0;
						num19 = num18;
						break;
					}
					num19 = num19 * 100.0 / num15;
					num18 = num18 * 100.0 / num15;
					float_ = (float)num18 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
					float_2 = (float)num19 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
					if (!class3.IsPlotOrderReversed)
					{
						if (yValue <= 0.0)
						{
							pointF_.Y += num17;
						}
						else
						{
							pointF_.Y -= num17;
						}
					}
					else if (yValue <= 0.0)
					{
						pointF_.Y -= num17;
					}
					else
					{
						pointF_.Y += num17;
					}
				}
				class9.method_0(pointF_, float_, float_2);
			}
			num17 = ((!class3.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num2 - num17) : (num2 + num17 - num16)) : ((!(yValue < 0.0)) ? (num2 + num17 - num16) : (num2 - num17)));
			if (class5.method_4().IsVisible)
			{
				num16 -= 1f;
			}
			RectangleF rectangleF = new RectangleF(num13, num17, num10, num16 + 1f);
			if (rectangleF.Y < (float)rectangle_0.Y)
			{
				rectangleF.Height -= (float)rectangle_0.Y - rectangleF.Y;
				rectangleF.Y = rectangle_0.Y;
			}
			if (rectangleF.Bottom > (float)(rectangle_0.Bottom + 1))
			{
				rectangleF.Height -= rectangleF.Bottom - (float)rectangle_0.Bottom;
			}
			if (rectangleF.Right >= (float)rectangle_0.X && rectangleF.Left <= (float)rectangle_0.Right)
			{
				if (rectangleF.X < (float)rectangle_0.X)
				{
					rectangleF.Width -= (float)rectangle_0.X - rectangleF.X;
					rectangleF.X = rectangle_0.X;
				}
				else if (rectangleF.Right > (float)rectangle_0.Right)
				{
					rectangleF.Width -= rectangleF.Right - (float)rectangle_0.Right;
				}
				if (rectangleF.Width + 1f >= (num10 - 1f) / 3f)
				{
					if (!flag)
					{
						smethod_2(interface42_0, class5, rectangleF, chart.method_14(class810_0.vmethod_7()).GetColor(index), num2, class3);
					}
					object[] array = new object[5];
					bool flag2 = rectangleF.Y + rectangleF.Height / 2f < num2 || (yValue == 0.0 && ((!class3.IsPlotOrderReversed) ? true : false));
					array[0] = index;
					array[1] = i;
					array[2] = rectangleF;
					array[3] = class2;
					array[4] = flag2;
					if (!class5.imethod_0())
					{
						arrayList.Add(array);
					}
					if (class810_0.HasSeriesLines)
					{
						arrayList2.Add(rectangleF);
						arrayList2.Add(flag2);
					}
				}
			}
			smethod_24(interface42_0, class810_0, ref arrayList_, arrayList2);
		}
		return arrayList;
	}

	private static ArrayList smethod_29(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0)
	{
		Class787 chart = class810_0.Chart;
		Enum53 @enum = class810_0.method_21();
		ChartType_Chart chartType_Chart = ChartType_Chart.Column100PercentStacked;
		_ = chart.method_7().Count;
		Class808 @class = chart.method_7();
		float num = (float)class810_0.Overlap / 100f;
		float num2 = (float)class810_0.GapWidth / 100f;
		Class789 class2;
		Class789 class3;
		int num3;
		ArrayList arrayList;
		if (@enum == Enum53.const_0)
		{
			class2 = chart.method_1();
			class3 = chart.method_9();
			num3 = @class.method_14(Enum53.const_0, chartType_Chart);
			arrayList = Class817.smethod_71(chart.method_7().method_0(), class810_0.Chart.vmethod_0());
		}
		else
		{
			class2 = chart.method_2();
			class3 = chart.method_10();
			num3 = @class.method_14(Enum53.const_1, chartType_Chart);
			arrayList = Class817.smethod_71(chart.method_7().method_2(), class810_0.Chart.vmethod_0());
		}
		float num4 = 0f;
		num4 = (class3.IsPlotOrderReversed ? ((float)rectangle_0.Bottom - (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height) : ((float)rectangle_0.Y + (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height));
		_ = class3.MinValue;
		_ = class3.MaxValue;
		ArrayList arrayList2 = new ArrayList();
		int count = arrayList.Count;
		Enum87 baseUnitScale = class2.BaseUnitScale;
		int int_ = (int)class2.MinValue;
		int int_2 = (int)class2.MaxValue;
		int num5 = 0;
		if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num5 = Struct19.smethod_29(baseUnitScale, int_2, int_, class810_0.Chart.vmethod_0());
			if (num5 == 0)
			{
				num5 = 1;
			}
		}
		else
		{
			num5 = Struct19.smethod_29(baseUnitScale, int_2, int_, class810_0.Chart.vmethod_0()) + 1;
		}
		double num6 = (double)rectangle_0.Width / (double)num5;
		ArrayList arrayList_ = new ArrayList();
		int num7 = 0;
		while (true)
		{
			if (num7 < count)
			{
				Class796 class4 = class810_0.method_10().method_1(num7);
				float num8 = (float)(num6 / (double)((float)num3 - num * (float)(num3 - 1) + num2));
				float num9 = num8 * num;
				float num10 = num8 * num2;
				int int_3 = int.Parse(arrayList[num7].ToString());
				int_3 = Struct19.smethod_32(baseUnitScale, int_3, class810_0.Chart.vmethod_0());
				int num11 = Struct19.smethod_29(baseUnitScale, int_3, int_, class810_0.Chart.vmethod_0());
				float num12 = (float)(num6 * (double)num11);
				if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
				{
					num12 -= (float)(num6 / 2.0);
				}
				float num13 = 0f;
				num13 = ((!class2.IsPlotOrderReversed) ? ((float)rectangle_0.X + num12 + num10 / 2f + 1f) : ((float)(rectangle_0.X + rectangle_0.Width) - num12 - num10 / 2f - num8 - 1f));
				IList list = @class.method_17(@enum, new ChartType_Chart[1] { chartType_Chart });
				int num14 = @class.method_19(class810_0, @enum, new ChartType_Chart[1] { chartType_Chart });
				if (num14 == -1)
				{
					break;
				}
				int index = class810_0.Index;
				num13 = ((!class2.IsPlotOrderReversed) ? (num13 + (float)num14 * (num8 - num9)) : (num13 - (float)num14 * (num8 - num9)));
				ArrayList arrayList3 = new ArrayList();
				if (class4 != null)
				{
					double yValue = class4.YValue;
					double num15 = yValue;
					double num16 = 0.0;
					if (yValue >= 0.0)
					{
						for (int i = 0; i < num14; i++)
						{
							Class796 class5 = ((Class810)list[i]).method_10().method_1(num7);
							if (class5 != null)
							{
								double yValue2 = class5.YValue;
								if (yValue2 > 0.0)
								{
									num15 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int j = 0; j < num14; j++)
						{
							Class796 class6 = ((Class810)list[j]).method_10().method_1(num7);
							if (class6 != null)
							{
								double yValue3 = class6.YValue;
								if (yValue3 <= 0.0)
								{
									num15 += yValue3;
								}
							}
						}
					}
					for (int k = 0; k < list.Count; k++)
					{
						Class796 class7 = ((Class810)list[k]).method_10().method_1(num7);
						if (class7 != null)
						{
							double yValue4 = class7.YValue;
							num16 += Math.Abs(yValue4);
						}
					}
					if (num16 == 0.0 || num16 == 0.0)
					{
						goto IL_0958;
					}
					float num17 = (float)Math.Abs(yValue) * 100f / (float)num16 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
					float num18 = (float)Math.Abs(num15) * 100f / (float)num16 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
					bool flag = false;
					if (num17 == 0f)
					{
						flag = true;
					}
					Class800 class8 = class810_0.method_4();
					if (class8 != null && class8.DisplayType != Enum68.const_2 && !class4.imethod_0())
					{
						PointF pointF_ = new PointF(num13 + num8 / 2f, num4);
						double num19 = 0.0;
						double num20 = 0.0;
						float float_ = 0f;
						float float_2 = 0f;
						if (class8 != null)
						{
							switch (class8.Type)
							{
							case Enum69.const_0:
							{
								double num21 = ((class8.MinusValue.Count > num7) ? class8.method_2(class8.MinusValue[num7]) : 0.0);
								num19 = num21;
								num21 = ((class8.PlusValue.Count > num7) ? class8.method_2(class8.PlusValue[num7]) : 0.0);
								num20 = num21;
								break;
							}
							case Enum69.const_1:
								num19 = class8.Amount;
								num20 = num19;
								break;
							case Enum69.const_2:
								num19 = class8.Amount * Math.Abs(yValue) / 100.0;
								num20 = num19;
								break;
							}
							num20 = num20 * 100.0 / num16;
							num19 = num19 * 100.0 / num16;
							float_ = (float)num19 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
							float_2 = (float)num20 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
							if (!class3.IsPlotOrderReversed)
							{
								if (yValue <= 0.0)
								{
									pointF_.Y += num18;
								}
								else
								{
									pointF_.Y -= num18;
								}
							}
							else if (yValue <= 0.0)
							{
								pointF_.Y -= num18;
							}
							else
							{
								pointF_.Y += num18;
							}
						}
						class8.method_0(pointF_, float_, float_2);
					}
					num18 = ((!class3.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num4 - num18) : (num4 + num18 - num17)) : ((!(yValue < 0.0)) ? (num4 + num18 - num17) : (num4 - num18)));
					if (class4.method_4().IsVisible)
					{
						num17 -= 1f;
					}
					RectangleF rectangleF = new RectangleF(num13, num18, num8, num17 + 1f);
					if (rectangleF.Y < (float)rectangle_0.Y)
					{
						rectangleF.Height -= (float)rectangle_0.Y - rectangleF.Y;
						rectangleF.Y = rectangle_0.Y;
					}
					if (rectangleF.Bottom > (float)(rectangle_0.Bottom + 1))
					{
						rectangleF.Height -= rectangleF.Bottom - (float)rectangle_0.Bottom;
					}
					if (rectangleF.Right >= (float)rectangle_0.X && rectangleF.Left <= (float)rectangle_0.Right)
					{
						if (rectangleF.X < (float)rectangle_0.X)
						{
							rectangleF.Width -= (float)rectangle_0.X - rectangleF.X;
							rectangleF.X = rectangle_0.X;
						}
						else if (rectangleF.Right > (float)rectangle_0.Right)
						{
							rectangleF.Width -= rectangleF.Right - (float)rectangle_0.Right;
						}
						if (rectangleF.Width + 1f >= (num8 - 1f) / 3f)
						{
							if (!flag && !class4.imethod_0())
							{
								smethod_2(interface42_0, class4, rectangleF, chart.method_14(class810_0.vmethod_7()).GetColor(index), num4, class3);
							}
							object[] array = new object[5];
							bool flag2 = rectangleF.Y + rectangleF.Height / 2f < num4 || (yValue == 0.0 && ((!class3.IsPlotOrderReversed) ? true : false));
							array[0] = index;
							array[1] = num7;
							array[2] = rectangleF;
							array[3] = class2;
							array[4] = flag2;
							if (!class4.imethod_0())
							{
								arrayList2.Add(array);
							}
							if (class810_0.HasSeriesLines)
							{
								arrayList3.Add(rectangleF);
								arrayList3.Add(flag2);
							}
						}
					}
				}
				smethod_24(interface42_0, class810_0, ref arrayList_, arrayList3);
				goto IL_0958;
			}
			return arrayList2;
			IL_0958:
			num7++;
		}
		return new ArrayList();
	}

	internal static ArrayList smethod_30(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0, float float_0, int int_0)
	{
		Class787 chart = class810_0.Chart;
		ChartType_Chart[] chartType_Chart_ = new ChartType_Chart[2]
		{
			ChartType_Chart.Line100PercentStacked,
			ChartType_Chart.Line100PercentStackedWithDataMarkers
		};
		Enum53 @enum = class810_0.method_21();
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
		if (@class.CategoryType == Enum64.const_2)
		{
			return smethod_31(interface42_0, class810_0, rectangle_0, float_0);
		}
		float num = 0f;
		num = (class2.IsPlotOrderReversed ? ((float)rectangle_0.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height) : ((float)rectangle_0.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height));
		Class808 class3 = chart.method_7();
		int count = class3.Count;
		float num2 = (float)class810_0.GapWidth / 100f;
		_ = class2.MinValue;
		_ = class2.MaxValue;
		bool hasDropLines = class810_0.HasDropLines;
		Class806 class806_ = class810_0.method_13();
		Class806 class806_2 = class810_0.method_14();
		Class794 class794_ = class810_0.method_16();
		Class794 class794_2 = class810_0.method_17();
		ArrayList arrayList = new ArrayList();
		int num3 = 0;
		int num4 = int_0;
		if (@class.bool_12)
		{
			num4 = (int)@class.MaxValue;
		}
		if (!@class.AxisBetweenCategories && !chart.IsDataTableShown)
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
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		IList list = class3.method_17(@enum, chartType_Chart_);
		for (int i = 0; i < list.Count; i++)
		{
			Class810 class4 = (Class810)list[i];
			if ((chart.method_30() && !class4.Equals(class810_0)) || (!class810_0.HasUpDownBars && !class810_0.vmethod_0() && !class4.Equals(class810_0)))
			{
				continue;
			}
			int num6 = class3.method_19(class4, @enum, chartType_Chart_);
			int index = class4.Index;
			Pen pen = null;
			ArrayList arrayList4 = new ArrayList();
			Class795 class5 = class4.method_10();
			for (int j = 0; j < int_0; j++)
			{
				Class796 class6 = class5.method_1(j);
				if (class6 != null)
				{
					pen?.Dispose();
					pen = Struct29.smethod_5(class6.method_4());
					double num7 = (float)num5 * (float)j + 1f;
					if (@class.AxisBetweenCategories || chart.IsDataTableShown)
					{
						num7 += (double)(float)(num5 / 2.0);
					}
					num7 = ((!@class.IsPlotOrderReversed) ? ((double)rectangle_0.X + num7) : ((double)(rectangle_0.X + rectangle_0.Width) - num7));
					double yValue = class6.YValue;
					double num8 = yValue;
					double num9 = 0.0;
					if (yValue >= 0.0)
					{
						for (int k = 0; k < num6; k++)
						{
							Class796 class7 = ((Class810)list[k]).method_10().method_1(j);
							if (class7 != null)
							{
								double yValue2 = class7.YValue;
								if (yValue2 > 0.0)
								{
									num8 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int l = 0; l < num6; l++)
						{
							Class796 class8 = ((Class810)list[l]).method_10().method_1(j);
							if (class8 != null)
							{
								double yValue3 = class8.YValue;
								if (yValue3 <= 0.0)
								{
									num8 += yValue3;
								}
							}
						}
					}
					for (int m = 0; m < list.Count; m++)
					{
						Class796 class9 = ((Class810)list[m]).method_10().method_1(j);
						if (class9 != null)
						{
							double yValue4 = class9.YValue;
							num9 += Math.Abs(yValue4);
						}
					}
					float num10 = 0f;
					if (num9 != 0.0)
					{
						num10 = (float)Math.Abs(num8) * 100f / (float)num9 / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height;
					}
					Class800 class10 = class810_0.method_4();
					if (class10 != null && class10.DisplayType != Enum68.const_2)
					{
						PointF pointF_ = new PointF((float)num7, num);
						double num11 = 0.0;
						double num12 = 0.0;
						float float_ = 0f;
						float float_2 = 0f;
						if (class10 != null && !class6.imethod_0())
						{
							switch (class10.Type)
							{
							case Enum69.const_0:
							{
								double num13 = ((class10.MinusValue.Count > j) ? class10.method_2(class10.MinusValue[j]) : 0.0);
								num11 = num13;
								num13 = ((class10.PlusValue.Count > j) ? class10.method_2(class10.PlusValue[j]) : 0.0);
								num12 = num13;
								break;
							}
							case Enum69.const_1:
								num11 = class10.Amount;
								num12 = num11;
								break;
							case Enum69.const_2:
								num11 = class10.Amount * Math.Abs(yValue) / 100.0;
								num12 = num11;
								break;
							}
							num12 = num12 * 100.0 / num9;
							num11 = num11 * 100.0 / num9;
							float_ = (float)num11 / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height;
							float_2 = (float)num12 / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height;
							if (!class2.IsPlotOrderReversed)
							{
								if (yValue < 0.0)
								{
									pointF_.Y += num10;
								}
								else
								{
									pointF_.Y -= num10;
								}
							}
							else if (yValue < 0.0)
							{
								pointF_.Y -= num10;
							}
							else
							{
								pointF_.Y += num10;
							}
						}
						if (class4.Equals(class810_0) && !class6.imethod_0())
						{
							class10.method_0(pointF_, float_, float_2);
						}
					}
					num10 = ((!class2.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num - num10) : (num + num10)) : ((!(yValue < 0.0)) ? (num + num10) : (num - num10)));
					PointF pointF = new PointF((float)num7, num10);
					arrayList4.Add(pointF);
					if (class4.Equals(class810_0))
					{
						if (hasDropLines)
						{
							Struct29.smethod_0(interface42_0, (float)num7, num10, (float)num7, float_0, class806_);
						}
						arrayList3.Add(pointF);
						if (!class6.imethod_0())
						{
							arrayList.Add(new object[4] { index, j, pointF, @class });
						}
					}
				}
				else
				{
					arrayList4.Add(null);
					if (class4.Equals(class810_0))
					{
						arrayList3.Add(null);
					}
				}
			}
			if (class4.Equals(class810_0))
			{
				if (pen == null)
				{
					pen = Struct29.smethod_5(class4.method_6());
				}
				smethod_6(interface42_0, class4, arrayList4, pen, rectangle_0);
			}
			pen?.Dispose();
			arrayList2.Add(arrayList4);
		}
		for (int n = 0; n < int_0; n++)
		{
			bool flag = false;
			bool flag2 = false;
			float float_3 = 0f;
			float float_4 = 0f;
			float float_5 = 0f;
			bool flag3 = false;
			bool flag4 = false;
			float num14 = 0f;
			float num15 = 0f;
			for (int num16 = 0; num16 < arrayList2.Count; num16++)
			{
				ArrayList arrayList5 = (ArrayList)arrayList2[num16];
				if (arrayList5.Count <= n || arrayList5[n] == null)
				{
					continue;
				}
				PointF pointF2 = (PointF)arrayList5[n];
				float_5 = pointF2.X;
				if (!flag)
				{
					float_3 = pointF2.Y;
					flag = true;
				}
				else if (!flag2)
				{
					if (float_3 < pointF2.Y)
					{
						float_4 = float_3;
						float_3 = pointF2.Y;
						flag2 = true;
					}
					else
					{
						float_4 = pointF2.Y;
						flag2 = true;
					}
				}
				else
				{
					if (float_3 < pointF2.Y)
					{
						float_3 = pointF2.Y;
					}
					if (float_4 > pointF2.Y)
					{
						float_4 = pointF2.Y;
					}
				}
				if (num16 == 0)
				{
					num14 = pointF2.Y;
					flag3 = true;
				}
				else if (num16 == count - 1)
				{
					num15 = pointF2.Y;
					flag4 = true;
				}
			}
			if (class810_0.vmethod_0() && flag && flag2 && smethod_18(class2.method_18(), rectangle_0, ref float_5, ref float_3, ref float_5, ref float_4))
			{
				Struct29.smethod_0(interface42_0, float_5, float_3, float_5, float_4, class806_2);
			}
			if (class810_0.HasUpDownBars && flag3 && flag4)
			{
				int num17 = (int)(num5 / (double)(1f + num2));
				RectangleF rectangleF_ = default(RectangleF);
				if (num14 <= num15)
				{
					rectangleF_.Width = num17;
					rectangleF_.Height = num15 - num14;
					rectangleF_.X = float_5 - rectangleF_.Width / 2f;
					rectangleF_.Y = num14;
					smethod_3(interface42_0, class794_2, rectangleF_);
				}
				else
				{
					rectangleF_.Width = num17;
					rectangleF_.Height = num14 - num15;
					rectangleF_.X = float_5 - rectangleF_.Width / 2f;
					rectangleF_.Y = num15;
					smethod_3(interface42_0, class794_, rectangleF_);
				}
			}
		}
		smethod_16(interface42_0, class810_0, arrayList3, rectangle_0);
		return arrayList;
	}

	private static ArrayList smethod_31(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0, float float_0)
	{
		Class787 chart = class810_0.Chart;
		ChartType_Chart[] chartType_Chart_ = new ChartType_Chart[2]
		{
			ChartType_Chart.Line100PercentStacked,
			ChartType_Chart.Line100PercentStackedWithDataMarkers
		};
		Enum53 @enum = class810_0.method_21();
		Class808 @class = chart.method_7();
		int count = @class.Count;
		_ = (float)class810_0.Overlap / 100f;
		float num = (float)class810_0.GapWidth / 100f;
		Class789 class2;
		Class789 class3;
		ArrayList arrayList;
		if (@enum == Enum53.const_0)
		{
			class2 = chart.method_1();
			class3 = chart.method_9();
			arrayList = Class817.smethod_71(chart.method_7().method_0(), class810_0.Chart.vmethod_0());
		}
		else
		{
			class2 = chart.method_2();
			class3 = chart.method_10();
			arrayList = Class817.smethod_71(chart.method_7().method_2(), class810_0.Chart.vmethod_0());
		}
		float num2 = 0f;
		num2 = (class3.IsPlotOrderReversed ? ((float)rectangle_0.Bottom - (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height) : ((float)rectangle_0.Y + (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height));
		_ = class3.MinValue;
		_ = class3.MaxValue;
		bool hasDropLines = class810_0.HasDropLines;
		Class806 class806_ = class810_0.method_13();
		Class806 class806_2 = class810_0.method_14();
		Class794 class794_ = class810_0.method_16();
		Class794 class794_2 = class810_0.method_17();
		int count2 = arrayList.Count;
		Enum87 baseUnitScale = class2.BaseUnitScale;
		int int_ = (int)class2.MinValue;
		int int_2 = (int)class2.MaxValue;
		int num3 = 0;
		if (!class2.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num3 = Struct19.smethod_29(baseUnitScale, int_2, int_, class810_0.Chart.vmethod_0());
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		else
		{
			num3 = Struct19.smethod_29(baseUnitScale, int_2, int_, class810_0.Chart.vmethod_0()) + 1;
		}
		double num4 = (double)rectangle_0.Width / (double)num3;
		float num5 = 0f;
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		ArrayList arrayList4 = new ArrayList();
		IList list = @class.method_17(@enum, chartType_Chart_);
		for (int i = 0; i < list.Count; i++)
		{
			Class810 class4 = (Class810)list[i];
			if ((chart.method_30() && !class4.Equals(class810_0)) || (!class810_0.HasUpDownBars && !class810_0.vmethod_0() && !class4.Equals(class810_0)))
			{
				continue;
			}
			int num6 = @class.method_19(class4, @enum, chartType_Chart_);
			int index = class4.Index;
			Pen pen = null;
			ArrayList arrayList5 = new ArrayList();
			for (int j = 0; j < count2; j++)
			{
				Class796 class5 = class4.method_10().method_1(j);
				if (class5 != null)
				{
					pen?.Dispose();
					pen = Struct29.smethod_5(class5.method_4());
					int int_3 = int.Parse(arrayList[j].ToString());
					int_3 = Struct19.smethod_32(baseUnitScale, int_3, class810_0.Chart.vmethod_0());
					int num7 = Struct19.smethod_29(baseUnitScale, int_3, int_, class810_0.Chart.vmethod_0());
					float num8 = (float)(num4 * (double)num7);
					num5 = (float)(num4 * (double)Struct19.smethod_29(baseUnitScale, Struct19.smethod_31(class2.BaseUnitScale, class2.MajorUnitScale, (int)class2.MajorUnit, int_3, class810_0.Chart.vmethod_0()), int_3, class810_0.Chart.vmethod_0()));
					if (class2.AxisBetweenCategories || chart.IsDataTableShown)
					{
						num8 += (float)(num4 / 2.0);
					}
					float num9 = 0f;
					num9 = ((!class2.IsPlotOrderReversed) ? ((float)rectangle_0.X + num8) : ((float)(rectangle_0.X + rectangle_0.Width) - num8));
					double yValue = class5.YValue;
					double num10 = yValue;
					double num11 = 0.0;
					if (yValue >= 0.0)
					{
						for (int k = 0; k < num6; k++)
						{
							Class796 class6 = ((Class810)list[k]).method_10().method_1(j);
							if (class6 != null)
							{
								double yValue2 = class6.YValue;
								if (yValue2 > 0.0)
								{
									num10 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int l = 0; l < num6; l++)
						{
							Class796 class7 = ((Class810)list[l]).method_10().method_1(j);
							if (class7 != null)
							{
								double yValue3 = class7.YValue;
								if (yValue3 <= 0.0)
								{
									num10 += yValue3;
								}
							}
						}
					}
					for (int m = 0; m < list.Count; m++)
					{
						Class796 class8 = ((Class810)list[m]).method_10().method_1(j);
						if (class8 != null)
						{
							double yValue4 = class8.YValue;
							num11 += Math.Abs(yValue4);
						}
					}
					if (num11 == 0.0)
					{
						continue;
					}
					float num12 = (float)Math.Abs(num10) * 100f / (float)num11 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
					Class800 class9 = class810_0.method_4();
					if (class9 != null && class9.DisplayType != Enum68.const_2 && class4.Equals(class810_0))
					{
						PointF pointF_ = new PointF(num9, num2);
						double num13 = 0.0;
						double num14 = 0.0;
						float float_ = 0f;
						float float_2 = 0f;
						if (class9 != null && !class5.imethod_0())
						{
							switch (class9.Type)
							{
							case Enum69.const_0:
							{
								double num15 = ((class9.MinusValue.Count > j) ? class9.method_2(class9.MinusValue[j]) : 0.0);
								num13 = num15;
								num15 = ((class9.PlusValue.Count > j) ? class9.method_2(class9.PlusValue[j]) : 0.0);
								num14 = num15;
								break;
							}
							case Enum69.const_1:
								num13 = class9.Amount;
								num14 = num13;
								break;
							case Enum69.const_2:
								num13 = class9.Amount * Math.Abs(yValue) / 100.0;
								num14 = num13;
								break;
							}
							num14 = num14 * 100.0 / num11;
							num13 = num13 * 100.0 / num11;
							float_ = (float)num13 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
							float_2 = (float)num14 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
							if (!class3.IsPlotOrderReversed)
							{
								if (yValue < 0.0)
								{
									pointF_.Y += num12;
								}
								else
								{
									pointF_.Y -= num12;
								}
							}
							else if (yValue < 0.0)
							{
								pointF_.Y -= num12;
							}
							else
							{
								pointF_.Y += num12;
							}
						}
						if (class4.Equals(class810_0) && !class5.imethod_0())
						{
							class9.method_0(pointF_, float_, float_2);
						}
					}
					num12 = ((!class3.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num2 - num12) : (num2 + num12)) : ((!(yValue < 0.0)) ? (num2 + num12) : (num2 - num12)));
					PointF pointF = new PointF(num9, num12);
					if (arrayList5.Count == 0)
					{
						arrayList5.Add(pointF);
					}
					else
					{
						smethod_22(pointF, arrayList5, class2.IsPlotOrderReversed);
					}
					if (class4.Equals(class810_0))
					{
						if (hasDropLines)
						{
							Struct29.smethod_0(interface42_0, num9, num12, num9, float_0, class806_);
						}
						arrayList4.Add(pointF);
						if (!class5.imethod_0())
						{
							arrayList2.Add(new object[4] { index, j, pointF, class2 });
						}
					}
				}
				else
				{
					arrayList5.Add(null);
					if (class4.Equals(class810_0))
					{
						arrayList4.Add(null);
					}
				}
			}
			if (class4.Equals(class810_0))
			{
				if (pen == null)
				{
					pen = Struct29.smethod_5(class4.method_6());
				}
				smethod_6(interface42_0, class4, arrayList5, pen, rectangle_0);
			}
			pen?.Dispose();
			arrayList3.Add(arrayList5);
		}
		for (int n = 0; n < count2; n++)
		{
			bool flag = false;
			bool flag2 = false;
			float float_3 = 0f;
			float float_4 = 0f;
			float float_5 = 0f;
			bool flag3 = false;
			bool flag4 = false;
			float num16 = 0f;
			float num17 = 0f;
			for (int num18 = 0; num18 < arrayList3.Count; num18++)
			{
				ArrayList arrayList6 = (ArrayList)arrayList3[num18];
				if (arrayList6.Count <= n || arrayList6[n] == null)
				{
					continue;
				}
				PointF pointF2 = (PointF)arrayList6[n];
				float_5 = pointF2.X;
				if (!flag)
				{
					float_3 = pointF2.Y;
					flag = true;
				}
				else if (!flag2)
				{
					if (float_3 < pointF2.Y)
					{
						float_4 = float_3;
						float_3 = pointF2.Y;
						flag2 = true;
					}
					else
					{
						float_4 = pointF2.Y;
						flag2 = true;
					}
				}
				else
				{
					if (float_3 < pointF2.Y)
					{
						float_3 = pointF2.Y;
					}
					if (float_4 > pointF2.Y)
					{
						float_4 = pointF2.Y;
					}
				}
				if (num18 == 0)
				{
					num16 = pointF2.Y;
					flag3 = true;
				}
				else if (num18 == count - 1)
				{
					num17 = pointF2.Y;
					flag4 = true;
				}
			}
			if (class810_0.vmethod_0() && flag && flag2 && smethod_18(class3.method_18(), rectangle_0, ref float_5, ref float_3, ref float_5, ref float_4))
			{
				Struct29.smethod_0(interface42_0, float_5, float_3, float_5, float_4, class806_2);
			}
			if (class810_0.HasUpDownBars && flag3 && flag4)
			{
				int num19 = (int)(num5 / (1f + num));
				RectangleF rectangleF_ = default(RectangleF);
				if (num16 <= num17)
				{
					rectangleF_.Width = num19;
					rectangleF_.Height = num17 - num16;
					rectangleF_.X = float_5 - rectangleF_.Width / 2f;
					rectangleF_.Y = num16;
					smethod_3(interface42_0, class794_2, rectangleF_);
				}
				else
				{
					rectangleF_.Width = num19;
					rectangleF_.Height = num16 - num17;
					rectangleF_.X = float_5 - rectangleF_.Width / 2f;
					rectangleF_.Y = num17;
					smethod_3(interface42_0, class794_, rectangleF_);
				}
			}
		}
		smethod_16(interface42_0, class810_0, arrayList4, rectangle_0);
		return arrayList2;
	}

	internal static void smethod_32(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0, int int_0)
	{
		Class808 @class = class787_0.method_7();
		int count = @class.Count;
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		if (class3.CategoryType == Enum64.const_2)
		{
			smethod_33(interface42_0, class787_0, float_0, double_0);
			return;
		}
		ArrayList arrayList = new ArrayList();
		float num = class787_0.method_13().Width / (float)int_0;
		float num2 = class787_0.method_13().method_3(bool_1: false, int_0, count);
		float float_ = class787_0.method_13().method_4();
		float num3 = num2 * (float)class787_0.GapWidth / 100f;
		double double_ = 1.0;
		for (int i = 0; i < int_0; i++)
		{
			int num4 = i;
			if (class787_0.Rotation > 180)
			{
				num4 = int_0 - 1 - i;
			}
			IList list = @class.method_16();
			for (int j = 0; j < list.Count; j++)
			{
				int num5 = j;
				if (class787_0.Rotation > 180)
				{
					num5 = list.Count - 1 - j;
				}
				Class810 class4 = (Class810)list[num5];
				int index = class4.Index;
				float num6 = (float)num5 * num2;
				float num7 = num * (float)num4 + num3 / 2f + num6;
				num7 = class787_0.method_13().X + num7;
				Class795 class5 = class4.method_10();
				int num8 = num4;
				if (class3.IsPlotOrderReversed)
				{
					num8 = int_0 - 1 - num4;
				}
				Class796 class6 = class5.method_1(num8);
				if (class6 != null && !class6.imethod_0() && !class6.method_10())
				{
					double num9 = class2.method_17(class6.YValue);
					float num10 = (float)(double_0 - num9) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					if (class2.IsPlotOrderReversed)
					{
						num10 = 0f - num10;
					}
					smethod_46(interface42_0, class6, class787_0, num7, num2, float_, float_0, num10, double.NaN, ref double_);
					PointF pointF = smethod_43(class787_0, num7, num2, float_0, num10);
					arrayList.Add(new object[3] { index, num8, pointF });
				}
			}
		}
		smethod_45(interface42_0, class787_0, arrayList);
	}

	private static void smethod_33(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0)
	{
		Class808 @class = class787_0.method_7();
		int count = @class.Count;
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		ArrayList arrayList = new ArrayList();
		int int_ = (int)class3.MaxValue;
		int int_2 = (int)class3.MinValue;
		Enum87 baseUnitScale = class3.BaseUnitScale;
		int num = Struct19.smethod_29(baseUnitScale, int_, int_2, class787_0.vmethod_0()) + 1;
		float num2 = class787_0.method_13().Width / (float)num;
		float num3 = class787_0.method_13().method_3(bool_1: false, num, count);
		float float_ = class787_0.method_13().method_4();
		float num4 = num3 * (float)class787_0.GapWidth / 100f;
		ArrayList arrayList2 = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		int count2 = arrayList2.Count;
		for (int i = 0; i < count2; i++)
		{
			int num5 = i;
			if (class787_0.Rotation > 180)
			{
				num5 = count2 - 1 - i;
			}
			int int_3 = int.Parse(arrayList2[num5].ToString());
			int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
			int num6 = Struct19.smethod_29(baseUnitScale, int_3, (int)class3.MinValue, class787_0.vmethod_0());
			float num7 = num2 * (float)num6;
			num7 += class787_0.method_13().X + num4 / 2f;
			IList list = @class.method_16();
			double double_ = 1.0;
			for (int j = 0; j < list.Count; j++)
			{
				int num8 = j;
				if (class787_0.Rotation > 180)
				{
					num8 = list.Count - 1 - j;
				}
				Class810 class4 = (Class810)list[num8];
				int index = class4.Index;
				float num9 = (float)num8 * num3;
				float float_2 = num7 + num9;
				Class795 class5 = class4.method_10();
				int num10 = num5;
				if (class3.IsPlotOrderReversed)
				{
					num10 = count2 - 1 - num5;
				}
				Class796 class6 = class5.method_1(num10);
				if (class6 != null && !class6.imethod_0() && !class6.method_10())
				{
					double num11 = class2.method_17(class6.YValue);
					float num12 = (float)(double_0 - num11) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					if (class2.IsPlotOrderReversed)
					{
						num12 = 0f - num12;
					}
					smethod_46(interface42_0, class6, class787_0, float_2, num3, float_, float_0, num12, double.NaN, ref double_);
					PointF pointF = smethod_43(class787_0, float_2, num3, float_0, num12);
					arrayList.Add(new object[3] { index, num10, pointF });
				}
			}
		}
		smethod_45(interface42_0, class787_0, arrayList);
	}

	internal static void smethod_34(Interface42 interface42_0, Class787 class787_0, double double_0, int int_0)
	{
		Class808 @class = class787_0.method_7();
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		ArrayList arrayList = @class.method_16();
		int num = Class817.smethod_33(arrayList, class2);
		double num2 = 0.0;
		switch (num)
		{
		case 1:
			num2 = class2.MinValue;
			break;
		case 2:
			num2 = class2.MaxValue;
			break;
		}
		float num3 = 0f;
		num3 = ((!class787_0.method_9().IsPlotOrderReversed) ? (class787_0.method_13().Y - (float)Math.Abs((class2.MinValue - num2) / (double)(float)(class2.MaxValue - class2.MinValue)) * class787_0.method_13().Height) : (class787_0.method_13().Y - (float)Math.Abs((class2.MaxValue - num2) / (double)(float)(class2.MaxValue - class2.MinValue)) * class787_0.method_13().Height));
		if (class3.CategoryType == Enum64.const_2)
		{
			smethod_35(interface42_0, class787_0, num3, double_0, num, num2);
			return;
		}
		ArrayList arrayList2 = new ArrayList();
		float num4 = class787_0.method_13().Width / (float)int_0;
		float num5 = class787_0.method_13().method_3(bool_1: false, int_0, 1);
		float float_ = class787_0.method_13().method_4();
		float num6 = num5 * (float)class787_0.GapWidth / 100f;
		for (int i = 0; i < int_0; i++)
		{
			int num7 = i;
			if (class787_0.Rotation > 180)
			{
				num7 = int_0 - 1 - i;
			}
			float num8 = class787_0.method_13().X + num4 * (float)num7 + num6 / 2f;
			ArrayList arrayList3 = new ArrayList();
			for (int j = 0; j < arrayList.Count; j++)
			{
				Class810 class4 = (Class810)arrayList[j];
				int index = class4.Index;
				Class795 class5 = class4.method_10();
				int num9 = num7;
				if (class3.IsPlotOrderReversed)
				{
					num9 = int_0 - 1 - num9;
				}
				Class796 class6 = class5.method_1(num9);
				int displayOrder = j;
				if (class6 == null || class6.imethod_0() || class6.method_10())
				{
					continue;
				}
				double pointVal = class6.YValue;
				if (Struct40.smethod_14(ref pointVal, out var valTotal, arrayList, displayOrder, num9, class2.MaxValue, class2.MinValue))
				{
					if (num == 1 && j == 0)
					{
						pointVal -= num2;
					}
					else if (num == 2 && j == 0)
					{
						pointVal -= num2;
					}
					float num10 = (float)pointVal / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					float num11 = (float)(valTotal - num2) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					float num12;
					if (class2.IsPlotOrderReversed)
					{
						num12 = num3 + (num11 - num10);
					}
					else
					{
						num12 = num3 - (num11 - num10);
						num10 = 0f - num10;
					}
					float num13 = num12 + num10;
					if (num12 > class787_0.method_13().Y)
					{
						num12 = class787_0.method_13().Y;
					}
					if (num12 < class787_0.method_13().Y - class787_0.method_13().Height)
					{
						num12 = class787_0.method_13().Y - class787_0.method_13().Height;
					}
					if (num13 > class787_0.method_13().Y)
					{
						num13 = class787_0.method_13().Y;
					}
					if (num13 < class787_0.method_13().Y - class787_0.method_13().Height)
					{
						num13 = class787_0.method_13().Y - class787_0.method_13().Height;
					}
					num10 = num13 - num12;
					smethod_42(object_0: new object[5] { class6, num8, num12, num10, valTotal }, double_0: pointVal, arrayList_0: arrayList3, class789_0: class2);
					PointF pointF = smethod_44(class787_0, num8, num5, float_, num12, num10);
					arrayList2.Add(new object[3] { index, num9, pointF });
				}
			}
			double double_ = 1.0;
			for (int k = 0; k < arrayList3.Count; k++)
			{
				object[] array = (object[])arrayList3[k];
				Class796 class796_ = (Class796)array[0];
				smethod_46(interface42_0, class796_, class787_0, (float)array[1], num5, float_, (float)array[2], (float)array[3], (double)array[4], ref double_);
			}
			arrayList3.Clear();
			smethod_45(interface42_0, class787_0, arrayList2);
			arrayList2.Clear();
		}
	}

	private static void smethod_35(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0, int int_0, double double_1)
	{
		Class808 @class = class787_0.method_7();
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		ArrayList arrayList = new ArrayList();
		int int_ = (int)class3.MaxValue;
		int int_2 = (int)class3.MinValue;
		Enum87 baseUnitScale = class3.BaseUnitScale;
		int num = Struct19.smethod_29(baseUnitScale, int_, int_2, class787_0.vmethod_0()) + 1;
		float num2 = class787_0.method_13().Width / (float)num;
		float num3 = class787_0.method_13().method_3(bool_1: false, num, 1);
		float float_ = class787_0.method_13().method_4();
		float num4 = num3 * (float)class787_0.GapWidth / 100f;
		ArrayList arrayList2 = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		int count = arrayList2.Count;
		for (int i = 0; i < count; i++)
		{
			int num5 = i;
			if (class787_0.Rotation > 180)
			{
				num5 = count - 1 - i;
			}
			int int_3 = int.Parse(arrayList2[num5].ToString());
			int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
			int num6 = Struct19.smethod_29(baseUnitScale, int_3, (int)class3.MinValue, class787_0.vmethod_0());
			float num7 = num2 * (float)num6;
			float num8 = class787_0.method_13().X + num4 / 2f + num7;
			ArrayList arrayList3 = new ArrayList();
			IList list = @class.method_16();
			for (int j = 0; j < list.Count; j++)
			{
				Class810 class4 = (Class810)list[j];
				int index = class4.Index;
				Class795 class5 = class4.method_10();
				int num9 = num5;
				if (class3.IsPlotOrderReversed)
				{
					num9 = count - 1 - num9;
				}
				Class796 class6 = class5.method_1(num9);
				int displayOrder = j;
				if (class6 == null || class6.imethod_0() || class6.method_10())
				{
					continue;
				}
				double pointVal = class6.YValue;
				if (Struct40.smethod_14(ref pointVal, out var valTotal, list, displayOrder, num9, class2.MaxValue, class2.MinValue))
				{
					if (int_0 == 1 && j == 0)
					{
						pointVal -= double_1;
					}
					else if (int_0 == 2 && j == 0)
					{
						pointVal -= double_1;
					}
					float num10 = (float)pointVal / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					float num11 = (float)(valTotal - double_1) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					float num12;
					if (class2.IsPlotOrderReversed)
					{
						num12 = float_0 + (num11 - num10);
					}
					else
					{
						num12 = float_0 - (num11 - num10);
						num10 = 0f - num10;
					}
					float num13 = num12 + num10;
					if (num12 > class787_0.method_13().Y)
					{
						num12 = class787_0.method_13().Y;
					}
					if (num12 < class787_0.method_13().Y - class787_0.method_13().Height)
					{
						num12 = class787_0.method_13().Y - class787_0.method_13().Height;
					}
					if (num13 > class787_0.method_13().Y)
					{
						num13 = class787_0.method_13().Y;
					}
					if (num13 < class787_0.method_13().Y - class787_0.method_13().Height)
					{
						num13 = class787_0.method_13().Y - class787_0.method_13().Height;
					}
					num10 = num13 - num12;
					smethod_42(object_0: new object[5] { class6, num8, num12, num10, valTotal }, double_0: pointVal, arrayList_0: arrayList3, class789_0: class2);
					PointF pointF = smethod_44(class787_0, num8, num3, float_, num12, num10);
					arrayList.Add(new object[3] { index, num9, pointF });
				}
			}
			double double_2 = 1.0;
			for (int k = 0; k < arrayList3.Count; k++)
			{
				object[] array = (object[])arrayList3[k];
				Class796 class796_ = (Class796)array[0];
				smethod_46(interface42_0, class796_, class787_0, (float)array[1], num3, float_, (float)array[2], (float)array[3], (double)array[4], ref double_2);
			}
			arrayList3.Clear();
			smethod_45(interface42_0, class787_0, arrayList);
			arrayList.Clear();
		}
	}

	internal static void smethod_36(Interface42 interface42_0, Class787 class787_0, double double_0, int int_0)
	{
		Class808 @class = class787_0.method_7();
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		float num = 0f;
		num = ((!class787_0.method_9().IsPlotOrderReversed) ? (class787_0.method_13().Y - class787_0.method_13().Height + (float)Math.Abs(class2.MaxValue / (double)(float)(class2.MaxValue - class2.MinValue)) * class787_0.method_13().Height) : (class787_0.method_13().Y - (float)Math.Abs(class2.MaxValue / (double)(float)(class2.MaxValue - class2.MinValue)) * class787_0.method_13().Height));
		if (class3.CategoryType == Enum64.const_2)
		{
			smethod_37(interface42_0, class787_0, num, double_0);
			return;
		}
		ArrayList arrayList = new ArrayList();
		float num2 = class787_0.method_13().Width / (float)int_0;
		float num3 = class787_0.method_13().method_3(bool_1: false, int_0, 1);
		float float_ = class787_0.method_13().method_4();
		float num4 = num3 * (float)class787_0.GapWidth / 100f;
		for (int i = 0; i < int_0; i++)
		{
			int num5 = i;
			if (class787_0.Rotation > 180)
			{
				num5 = int_0 - 1 - i;
			}
			float num6 = class787_0.method_13().X + num2 * (float)num5 + num4 / 2f;
			ArrayList arrayList2 = new ArrayList();
			IList list = @class.method_16();
			for (int j = 0; j < list.Count; j++)
			{
				Class810 class4 = (Class810)list[j];
				int index = class4.Index;
				Class795 class5 = class4.method_10();
				int num7 = num5;
				if (class3.IsPlotOrderReversed)
				{
					num7 = int_0 - 1 - num5;
				}
				Class796 class6 = class5.method_1(num7);
				int displayOrder = j;
				if (class6 == null || class6.imethod_0() || class6.method_10())
				{
					continue;
				}
				double num8 = Struct40.smethod_15(list, num7);
				if (num8 == 0.0)
				{
					continue;
				}
				double pointVal = class6.YValue;
				double valTotal = pointVal;
				if (Struct40.smethod_16(ref pointVal, out valTotal, list, displayOrder, num7, class2, num8))
				{
					float num9 = (float)pointVal * 100f / (float)num8 / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					float num10 = (float)valTotal * 100f / (float)num8 / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					float num11;
					if (class2.IsPlotOrderReversed)
					{
						num11 = num + (num10 - num9);
					}
					else
					{
						num11 = num - (num10 - num9);
						num9 = 0f - num9;
					}
					float num12 = num11 + num9;
					if (num11 > class787_0.method_13().Y)
					{
						num11 = class787_0.method_13().Y;
					}
					if (num11 < class787_0.method_13().Y - class787_0.method_13().Height)
					{
						num11 = class787_0.method_13().Y - class787_0.method_13().Height;
					}
					if (num12 > class787_0.method_13().Y)
					{
						num12 = class787_0.method_13().Y;
					}
					if (num12 < class787_0.method_13().Y - class787_0.method_13().Height)
					{
						num12 = class787_0.method_13().Y - class787_0.method_13().Height;
					}
					num9 = num12 - num11;
					smethod_42(object_0: new object[5] { class6, num6, num11, num9, valTotal }, double_0: pointVal, arrayList_0: arrayList2, class789_0: class2);
					PointF pointF = smethod_44(class787_0, num6, num3, float_, num11, num9);
					arrayList.Add(new object[3] { index, num7, pointF });
				}
			}
			double double_ = 1.0;
			for (int k = 0; k < arrayList2.Count; k++)
			{
				object[] array = (object[])arrayList2[k];
				Class796 class796_ = (Class796)array[0];
				smethod_46(interface42_0, class796_, class787_0, (float)array[1], num3, float_, (float)array[2], (float)array[3], (double)array[4], ref double_);
			}
			arrayList2.Clear();
			smethod_45(interface42_0, class787_0, arrayList);
			arrayList.Clear();
		}
	}

	private static void smethod_37(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0)
	{
		Class808 @class = class787_0.method_7();
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		ArrayList arrayList = new ArrayList();
		int int_ = (int)class3.MaxValue;
		int int_2 = (int)class3.MinValue;
		Enum87 baseUnitScale = class3.BaseUnitScale;
		int num = Struct19.smethod_29(baseUnitScale, int_, int_2, class787_0.vmethod_0()) + 1;
		float num2 = class787_0.method_13().Width / (float)num;
		float num3 = class787_0.method_13().method_3(bool_1: false, num, 1);
		float float_ = class787_0.method_13().method_4();
		float num4 = num3 * (float)class787_0.GapWidth / 100f;
		ArrayList arrayList2 = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		int count = arrayList2.Count;
		for (int i = 0; i < count; i++)
		{
			int num5 = i;
			if (class787_0.Rotation > 180)
			{
				num5 = count - 1 - i;
			}
			int int_3 = int.Parse(arrayList2[num5].ToString());
			int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
			int num6 = Struct19.smethod_29(baseUnitScale, int_3, (int)class3.MinValue, class787_0.vmethod_0());
			float num7 = num2 * (float)num6;
			float num8 = class787_0.method_13().X + num4 / 2f + num7;
			ArrayList arrayList3 = new ArrayList();
			IList list = @class.method_16();
			for (int j = 0; j < list.Count; j++)
			{
				Class810 class4 = (Class810)list[j];
				int index = class4.Index;
				Class795 class5 = class4.method_10();
				int num9 = num5;
				if (class3.IsPlotOrderReversed)
				{
					num9 = count - 1 - num5;
				}
				Class796 class6 = class5.method_1(num9);
				int displayOrder = j;
				if (class6 == null || class6.imethod_0() || class6.method_10())
				{
					continue;
				}
				double num10 = Struct40.smethod_15(list, num9);
				if (num10 == 0.0)
				{
					continue;
				}
				double pointVal = class6.YValue;
				double valTotal = pointVal;
				if (Struct40.smethod_16(ref pointVal, out valTotal, list, displayOrder, num9, class2, num10))
				{
					float num11 = (float)pointVal * 100f / (float)num10 / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					float num12 = (float)valTotal * 100f / (float)num10 / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					float num13;
					if (class2.IsPlotOrderReversed)
					{
						num13 = float_0 + (num12 - num11);
					}
					else
					{
						num13 = float_0 - (num12 - num11);
						num11 = 0f - num11;
					}
					float num14 = num13 + num11;
					if (num13 > class787_0.method_13().Y)
					{
						num13 = class787_0.method_13().Y;
					}
					if (num13 < class787_0.method_13().Y - class787_0.method_13().Height)
					{
						num13 = class787_0.method_13().Y - class787_0.method_13().Height;
					}
					if (num14 > class787_0.method_13().Y)
					{
						num14 = class787_0.method_13().Y;
					}
					if (num14 < class787_0.method_13().Y - class787_0.method_13().Height)
					{
						num14 = class787_0.method_13().Y - class787_0.method_13().Height;
					}
					num11 = num14 - num13;
					smethod_42(object_0: new object[5] { class6, num8, num13, num11, valTotal }, double_0: pointVal, arrayList_0: arrayList3, class789_0: class2);
					PointF pointF = smethod_44(class787_0, num8, num3, float_, num13, num11);
					arrayList.Add(new object[3] { index, num9, pointF });
				}
			}
			double double_ = 1.0;
			for (int k = 0; k < arrayList3.Count; k++)
			{
				object[] array = (object[])arrayList3[k];
				Class796 class796_ = (Class796)array[0];
				smethod_46(interface42_0, class796_, class787_0, (float)array[1], num3, float_, (float)array[2], (float)array[3], (double)array[4], ref double_);
			}
			arrayList3.Clear();
			smethod_45(interface42_0, class787_0, arrayList);
			arrayList.Clear();
		}
	}

	internal static void smethod_38(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0, int int_0)
	{
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		if (class3.CategoryType == Enum64.const_2)
		{
			smethod_39(interface42_0, class787_0, float_0, double_0);
			return;
		}
		float num = (float)class787_0.DepthPercent / 100f;
		float num2 = (float)class787_0.GapDepth / 100f;
		float num3 = (float)class787_0.GapWidth / 100f;
		ArrayList arrayList = new ArrayList();
		float num4 = class787_0.method_13().Width / (float)int_0;
		float num5 = num4 / (1f + num3);
		float num6 = num5 * num3;
		float float_ = num4 * num / (1f + num2);
		IList list = @class.method_16();
		if ((class787_0.Rotation >= 0 && class787_0.Rotation < 90) || (class787_0.Rotation >= 180 && class787_0.Rotation < 270))
		{
			for (int i = 0; i < list.Count; i++)
			{
				int num7 = list.Count - 1 - i;
				if (class787_0.Rotation >= 180 && class787_0.Rotation < 270)
				{
					num7 = list.Count - 1 - num7;
				}
				if (class787_0.method_11().IsPlotOrderReversed)
				{
					num7 = list.Count - 1 - num7;
				}
				Class810 class4 = (Class810)list[num7];
				int index = class4.Index;
				Class795 class5 = class4.method_10();
				for (int j = 0; j < int_0; j++)
				{
					int num8 = j;
					if (class787_0.Rotation >= 180 && class787_0.Rotation < 270)
					{
						num8 = int_0 - 1 - num8;
					}
					float num9 = num4 * (float)num8 + num6 / 2f;
					num9 = class787_0.method_13().X + num9;
					int num10 = num8;
					if (class3.IsPlotOrderReversed)
					{
						num10 = int_0 - 1 - num8;
					}
					Class796 class6 = class5.method_1(num10);
					if (class6 != null && !class6.imethod_0() && !class6.method_10())
					{
						double num11 = class2.method_17(class6.YValue);
						float num12 = (float)(double_0 - num11) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
						if (class2.IsPlotOrderReversed)
						{
							num12 = 0f - num12;
						}
						smethod_49(interface42_0, class6, class787_0, float_0, num12, num9, num5, float_, index + 1, list.Count);
						PointF pointF = smethod_56(class787_0, float_0, num12, num9, num5, float_, index + 1, list.Count);
						arrayList.Clear();
						arrayList.Add(new object[3] { index, num10, pointF });
						smethod_45(interface42_0, class787_0, arrayList);
					}
				}
			}
		}
		else
		{
			if ((class787_0.Rotation < 90 || class787_0.Rotation >= 180) && (class787_0.Rotation < 270 || class787_0.Rotation >= 360))
			{
				return;
			}
			for (int k = 0; k < int_0; k++)
			{
				int num13 = k;
				if (class787_0.Rotation >= 270 && class787_0.Rotation < 360)
				{
					num13 = int_0 - 1 - num13;
				}
				for (int l = 0; l < list.Count; l++)
				{
					int num14 = l;
					if (class787_0.Rotation >= 270 && class787_0.Rotation < 360)
					{
						num14 = list.Count - 1 - num14;
					}
					if (class787_0.method_11().IsPlotOrderReversed)
					{
						num14 = list.Count - 1 - num14;
					}
					Class810 class7 = (Class810)list[num14];
					int index2 = class7.Index;
					float num15 = num4 * (float)num13 + num6 / 2f;
					num15 = class787_0.method_13().X + num15;
					Class795 class8 = class7.method_10();
					int num16 = num13;
					if (class3.IsPlotOrderReversed)
					{
						num16 = int_0 - 1 - num13;
					}
					Class796 class9 = class8.method_1(num16);
					if (class9 != null && !class9.imethod_0())
					{
						double num17 = class2.method_17(class9.YValue);
						float num18 = (float)(double_0 - num17) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
						if (class2.IsPlotOrderReversed)
						{
							num18 = 0f - num18;
						}
						smethod_49(interface42_0, class9, class787_0, float_0, num18, num15, num5, float_, index2 + 1, list.Count);
						PointF pointF2 = smethod_56(class787_0, float_0, num18, num15, num5, float_, index2 + 1, list.Count);
						arrayList.Clear();
						arrayList.Add(new object[3] { index2, num16, pointF2 });
						smethod_45(interface42_0, class787_0, arrayList);
					}
				}
			}
		}
	}

	private static void smethod_39(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0)
	{
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		Class789 class4 = class787_0.method_11();
		float num = (float)class787_0.DepthPercent / 100f;
		float num2 = (float)class787_0.GapDepth / 100f;
		float num3 = (float)class787_0.GapWidth / 100f;
		ArrayList arrayList = new ArrayList();
		int int_ = (int)class3.MaxValue;
		int int_2 = (int)class3.MinValue;
		Enum87 baseUnitScale = class3.BaseUnitScale;
		int num4 = Struct19.smethod_29(baseUnitScale, int_, int_2, class787_0.vmethod_0()) + 1;
		float num5 = class787_0.method_13().Width / (float)num4;
		float num6 = num5 / (1f + num3);
		float num7 = num6 * num3;
		float float_ = num5 * num / (1f + num2);
		IList list = @class.method_16();
		ArrayList arrayList2 = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		int count = arrayList2.Count;
		if ((class787_0.Rotation >= 0 && class787_0.Rotation < 90) || (class787_0.Rotation >= 180 && class787_0.Rotation < 270))
		{
			for (int i = 0; i < list.Count; i++)
			{
				int num8 = list.Count - 1 - i;
				if (class787_0.Rotation >= 180 && class787_0.Rotation < 270)
				{
					num8 = list.Count - 1 - num8;
				}
				if (class4.IsPlotOrderReversed)
				{
					num8 = list.Count - 1 - num8;
				}
				Class810 class5 = (Class810)list[num8];
				int index = class5.Index;
				Class795 class6 = class5.method_10();
				for (int j = 0; j < count; j++)
				{
					int num9 = j;
					if (class787_0.Rotation >= 180 && class787_0.Rotation < 270)
					{
						num9 = count - 1 - num9;
					}
					int int_3 = int.Parse(arrayList2[num9].ToString());
					int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
					int num10 = Struct19.smethod_29(baseUnitScale, int_3, (int)class3.MinValue, class787_0.vmethod_0());
					float num11 = num5 * (float)num10;
					float float_2 = class787_0.method_13().X + num11 + num7 / 2f;
					int num12 = num9;
					if (class3.IsPlotOrderReversed)
					{
						num12 = count - 1 - num9;
					}
					Class796 class7 = class6.method_1(num12);
					if (class7 != null && !class7.imethod_0())
					{
						double num13 = class2.method_17(class7.YValue);
						float num14 = (float)(double_0 - num13) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
						if (class2.IsPlotOrderReversed)
						{
							num14 = 0f - num14;
						}
						smethod_49(interface42_0, class7, class787_0, float_0, num14, float_2, num6, float_, index + 1, list.Count);
						PointF pointF = smethod_56(class787_0, float_0, num14, float_2, num6, float_, index + 1, list.Count);
						arrayList.Clear();
						arrayList.Add(new object[3] { index, num12, pointF });
						smethod_45(interface42_0, class787_0, arrayList);
					}
				}
			}
		}
		else
		{
			if ((class787_0.Rotation < 90 || class787_0.Rotation >= 180) && (class787_0.Rotation < 270 || class787_0.Rotation >= 360))
			{
				return;
			}
			for (int k = 0; k < count; k++)
			{
				int num15 = k;
				if (class787_0.Rotation >= 270 && class787_0.Rotation < 360)
				{
					num15 = count - 1 - num15;
				}
				int int_4 = int.Parse(arrayList2[num15].ToString());
				int_4 = Struct19.smethod_32(baseUnitScale, int_4, class787_0.vmethod_0());
				int num16 = Struct19.smethod_29(baseUnitScale, int_4, (int)class3.MinValue, class787_0.vmethod_0());
				float num17 = num5 * (float)num16;
				float float_3 = class787_0.method_13().X + num17 + num7 / 2f;
				for (int l = 0; l < list.Count; l++)
				{
					int num18 = l;
					if (class787_0.Rotation >= 270 && class787_0.Rotation < 360)
					{
						num18 = list.Count - 1 - num18;
					}
					if (class4.IsPlotOrderReversed)
					{
						num18 = list.Count - 1 - num18;
					}
					Class810 class8 = (Class810)list[num18];
					int index2 = class8.Index;
					Class795 class9 = class8.method_10();
					int num19 = num15;
					if (class3.IsPlotOrderReversed)
					{
						num19 = count - 1 - num15;
					}
					Class796 class10 = class9.method_1(num19);
					if (class10 != null && !class10.imethod_0())
					{
						double num20 = class2.method_17(class10.YValue);
						float num21 = (float)(double_0 - num20) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
						if (class2.IsPlotOrderReversed)
						{
							num21 = 0f - num21;
						}
						smethod_49(interface42_0, class10, class787_0, float_0, num21, float_3, num6, float_, index2 + 1, list.Count);
						PointF pointF2 = smethod_56(class787_0, float_0, num21, float_3, num6, float_, index2 + 1, list.Count);
						arrayList.Clear();
						arrayList.Add(new object[3] { index2, num19, pointF2 });
						smethod_45(interface42_0, class787_0, arrayList);
					}
				}
			}
		}
	}

	internal static void smethod_40(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0, int int_0)
	{
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		if (class3.CategoryType == Enum64.const_2)
		{
			smethod_41(interface42_0, class787_0, float_0, double_0);
			return;
		}
		float num = (float)class787_0.DepthPercent / 100f;
		float num2 = (float)class787_0.GapDepth / 100f;
		ArrayList arrayList = new ArrayList();
		double num3 = (class2.IsLogarithmic ? Struct40.smethod_7(class2.MaxValue) : class2.MaxValue);
		double num4 = (class2.IsLogarithmic ? Struct40.smethod_7(class2.MinValue) : class2.MinValue);
		double_0 = (class2.IsLogarithmic ? Struct40.smethod_7(double_0) : double_0);
		int num5 = 0;
		bool flag;
		if (flag = class3.AxisBetweenCategories || class787_0.IsDataTableShown)
		{
			num5 = int_0;
		}
		else
		{
			num5 = int_0 - 1;
			if (num5 == 0)
			{
				num5 = 1;
			}
		}
		float num6 = class787_0.method_13().Width / (float)num5;
		float float_ = num6 * num / (1f + num2);
		ArrayList arrayList2 = new ArrayList();
		IList list = @class.method_16();
		if ((class787_0.Rotation >= 0 && class787_0.Rotation < 90) || (class787_0.Rotation >= 180 && class787_0.Rotation < 270))
		{
			for (int i = 0; i < list.Count; i++)
			{
				int num7 = list.Count - 1 - i;
				if (class787_0.Rotation >= 180 && class787_0.Rotation < 270)
				{
					num7 = list.Count - 1 - num7;
				}
				if (class787_0.method_11().IsPlotOrderReversed)
				{
					num7 = list.Count - 1 - num7;
				}
				Class810 class4 = (Class810)list[num7];
				int index = class4.Index;
				Class795 class5 = class4.method_10();
				for (int j = 0; j < int_0; j++)
				{
					int num8 = j;
					if (class787_0.Rotation >= 180 && class787_0.Rotation < 270)
					{
						num8 = int_0 - 1 - num8;
					}
					float num9 = num6 * (float)num8;
					num9 = class787_0.method_13().X + num9;
					if (flag)
					{
						num9 += num6 / 2f;
					}
					int num10 = num8;
					if (class3.IsPlotOrderReversed)
					{
						num10 = int_0 - 1 - num8;
					}
					Class796 class6 = class5.method_1(num10);
					if (class6 != null && !class6.imethod_0())
					{
						double num11 = class2.method_17(class6.YValue);
						float num12 = (float)(double_0 - num11) / (float)(num3 - num4) * class787_0.method_13().Height;
						if (class2.IsPlotOrderReversed)
						{
							num12 = 0f - num12;
						}
						object[] array = new object[2]
						{
							class6,
							smethod_48(interface42_0, class787_0, float_0, num12, num9, float_, index + 1, list.Count)
						};
						arrayList2.Add(array);
						int num13 = 0;
						if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
						{
							num13 = 1;
						}
						arrayList.Add(new object[3]
						{
							index,
							num10,
							((PointF[])array[1])[num13]
						});
					}
					else
					{
						arrayList2.Add(null);
					}
				}
				smethod_54(interface42_0, class787_0, arrayList2);
				arrayList2.Clear();
				smethod_45(interface42_0, class787_0, arrayList);
				arrayList.Clear();
			}
		}
		else
		{
			if ((class787_0.Rotation < 90 || class787_0.Rotation >= 180) && (class787_0.Rotation < 270 || class787_0.Rotation >= 360))
			{
				return;
			}
			for (int k = 0; k < list.Count; k++)
			{
				int num14 = k;
				if (class787_0.Rotation >= 270 && class787_0.Rotation < 360)
				{
					num14 = list.Count - 1 - num14;
				}
				if (class787_0.method_11().IsPlotOrderReversed)
				{
					num14 = list.Count - 1 - num14;
				}
				Class810 class7 = (Class810)list[num14];
				int index2 = class7.Index;
				Class795 class8 = class7.method_10();
				for (int l = 0; l < int_0; l++)
				{
					int num15 = l;
					if (class787_0.Rotation >= 270 && class787_0.Rotation < 360)
					{
						num15 = int_0 - 1 - num15;
					}
					float num16 = num6 * (float)num15;
					num16 = class787_0.method_13().X + num16;
					if (flag)
					{
						num16 += num6 / 2f;
					}
					int num17 = num15;
					if (class3.IsPlotOrderReversed)
					{
						num17 = int_0 - 1 - num15;
					}
					Class796 class9 = class8.method_1(num17);
					if (class9 != null && !class9.imethod_0())
					{
						double num18 = class2.method_17(class9.YValue);
						float num19 = (float)(double_0 - num18) / (float)(num3 - num4) * class787_0.method_13().Height;
						if (class2.IsPlotOrderReversed)
						{
							num19 = 0f - num19;
						}
						object[] array2 = new object[2]
						{
							class9,
							smethod_48(interface42_0, class787_0, float_0, num19, num16, float_, index2 + 1, list.Count)
						};
						arrayList2.Add(array2);
						int num20 = 0;
						if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
						{
							num20 = 1;
						}
						arrayList.Add(new object[3]
						{
							index2,
							num17,
							((PointF[])array2[1])[num20]
						});
					}
				}
				smethod_54(interface42_0, class787_0, arrayList2);
				arrayList2.Clear();
				smethod_45(interface42_0, class787_0, arrayList);
				arrayList.Clear();
			}
		}
	}

	private static void smethod_41(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0)
	{
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		Class789 class4 = class787_0.method_11();
		float num = (float)class787_0.DepthPercent / 100f;
		float num2 = (float)class787_0.GapDepth / 100f;
		ArrayList arrayList = new ArrayList();
		Enum87 baseUnitScale = class3.BaseUnitScale;
		int int_ = (int)class3.MinValue;
		int int_2 = (int)class3.MaxValue;
		int num3 = 0;
		bool flag;
		if (flag = class3.AxisBetweenCategories || class787_0.IsDataTableShown)
		{
			num3 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0()) + 1;
		}
		else
		{
			num3 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0());
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		float num4 = class787_0.method_13().Width / (float)num3;
		float float_ = num4 * num / (1f + num2);
		ArrayList arrayList2 = new ArrayList();
		IList list = @class.method_16();
		ArrayList arrayList3 = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		int count = arrayList3.Count;
		if ((class787_0.Rotation >= 0 && class787_0.Rotation < 90) || (class787_0.Rotation >= 180 && class787_0.Rotation < 270))
		{
			for (int i = 0; i < list.Count; i++)
			{
				int num5 = list.Count - 1 - i;
				if (class787_0.Rotation >= 180 && class787_0.Rotation < 270)
				{
					num5 = list.Count - 1 - num5;
				}
				if (class4.IsPlotOrderReversed)
				{
					num5 = list.Count - 1 - num5;
				}
				Class810 class5 = (Class810)list[num5];
				int index = class5.Index;
				Class795 class6 = class5.method_10();
				for (int j = 0; j < count; j++)
				{
					int num6 = j;
					if (class787_0.Rotation >= 180 && class787_0.Rotation < 270)
					{
						num6 = count - 1 - num6;
					}
					int int_3 = int.Parse(arrayList3[num6].ToString());
					int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
					int num7 = Struct19.smethod_29(baseUnitScale, int_3, (int)class3.MinValue, class787_0.vmethod_0());
					float num8 = num4 * (float)num7;
					float num9 = class787_0.method_13().X + num8;
					if (flag)
					{
						num9 += num4 / 2f;
					}
					int num10 = num6;
					if (class3.IsPlotOrderReversed)
					{
						num10 = count - 1 - num6;
					}
					Class796 class7 = class6.method_1(num10);
					if (class7 != null && !class7.imethod_0())
					{
						double num11 = class2.method_17(class7.YValue);
						float num12 = (float)(double_0 - num11) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
						if (class2.IsPlotOrderReversed)
						{
							num12 = 0f - num12;
						}
						object[] array = new object[2]
						{
							class7,
							smethod_48(interface42_0, class787_0, float_0, num12, num9, float_, index + 1, list.Count)
						};
						arrayList2.Add(array);
						int num13 = 0;
						if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
						{
							num13 = 1;
						}
						arrayList.Add(new object[3]
						{
							index,
							num10,
							((PointF[])array[1])[num13]
						});
					}
					else
					{
						arrayList2.Add(null);
					}
				}
				smethod_54(interface42_0, class787_0, arrayList2);
				arrayList2.Clear();
				smethod_45(interface42_0, class787_0, arrayList);
				arrayList.Clear();
			}
		}
		else
		{
			if ((class787_0.Rotation < 90 || class787_0.Rotation >= 180) && (class787_0.Rotation < 270 || class787_0.Rotation >= 360))
			{
				return;
			}
			for (int k = 0; k < list.Count; k++)
			{
				int num14 = k;
				if (class787_0.Rotation >= 270 && class787_0.Rotation < 360)
				{
					num14 = list.Count - 1 - num14;
				}
				if (class4.IsPlotOrderReversed)
				{
					num14 = list.Count - 1 - num14;
				}
				Class810 class8 = (Class810)list[num14];
				int index2 = class8.Index;
				Class795 class9 = class8.method_10();
				for (int l = 0; l < count; l++)
				{
					int num15 = l;
					if (class787_0.Rotation >= 270 && class787_0.Rotation < 360)
					{
						num15 = count - 1 - num15;
					}
					int int_4 = int.Parse(arrayList3[num15].ToString());
					int_4 = Struct19.smethod_32(baseUnitScale, int_4, class787_0.vmethod_0());
					int num16 = Struct19.smethod_29(baseUnitScale, int_4, (int)class3.MinValue, class787_0.vmethod_0());
					float num17 = num4 * (float)num16;
					float num18 = class787_0.method_13().X + num17;
					if (flag)
					{
						num18 += num4 / 2f;
					}
					int num19 = num15;
					if (class3.IsPlotOrderReversed)
					{
						num19 = count - 1 - num15;
					}
					Class796 class10 = class9.method_1(num19);
					if (class10 != null && !class10.imethod_0())
					{
						double num20 = class2.method_17(class10.YValue);
						float num21 = (float)(double_0 - num20) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
						if (class2.IsPlotOrderReversed)
						{
							num21 = 0f - num21;
						}
						object[] array2 = new object[2]
						{
							class10,
							smethod_48(interface42_0, class787_0, float_0, num21, num18, float_, index2 + 1, list.Count)
						};
						arrayList2.Add(array2);
						int num22 = 0;
						if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
						{
							num22 = 1;
						}
						arrayList.Add(new object[3]
						{
							index2,
							num19,
							((PointF[])array2[1])[num22]
						});
					}
				}
				smethod_54(interface42_0, class787_0, arrayList2);
				arrayList2.Clear();
				smethod_45(interface42_0, class787_0, arrayList);
				arrayList.Clear();
			}
		}
	}

	private static void smethod_42(double double_0, object[] object_0, ArrayList arrayList_0, Class789 class789_0)
	{
		Class787 chart = class789_0.Chart;
		int num = (int)((double)((float)object_0[2] + (float)object_0[3]) + 0.5);
		if (arrayList_0.Count == 0)
		{
			arrayList_0.Add(object_0);
			return;
		}
		int num2 = 0;
		while (true)
		{
			if (num2 >= arrayList_0.Count)
			{
				return;
			}
			object[] array = (object[])arrayList_0[num2];
			int num3 = (int)((double)((float)array[2] + (float)array[3]) + 0.5);
			if (chart.Elevation >= 0)
			{
				if (num > num3)
				{
					arrayList_0.Insert(num2, object_0);
					return;
				}
				if (num == num3)
				{
					if (class789_0.IsPlotOrderReversed)
					{
						if (double_0 > 0.0)
						{
							arrayList_0.Insert(num2, object_0);
						}
						else
						{
							arrayList_0.Insert(num2 + 1, object_0);
						}
					}
					else if (double_0 < 0.0)
					{
						arrayList_0.Insert(num2, object_0);
					}
					else
					{
						arrayList_0.Insert(num2 + 1, object_0);
					}
					return;
				}
				if (num2 == arrayList_0.Count - 1)
				{
					arrayList_0.Add(object_0);
					return;
				}
			}
			else
			{
				if (num < num3)
				{
					arrayList_0.Insert(num2, object_0);
					return;
				}
				if (num == num3)
				{
					if (!class789_0.IsPlotOrderReversed)
					{
						if (double_0 > 0.0)
						{
							arrayList_0.Insert(num2, object_0);
						}
						else
						{
							arrayList_0.Insert(num2 + 1, object_0);
						}
					}
					else if (double_0 < 0.0)
					{
						arrayList_0.Insert(num2, object_0);
					}
					else
					{
						arrayList_0.Insert(num2 + 1, object_0);
					}
					return;
				}
				if (num2 == arrayList_0.Count - 1)
				{
					break;
				}
			}
			num2++;
		}
		arrayList_0.Add(object_0);
	}

	private static PointF smethod_43(Class787 class787_0, float float_0, float float_1, float float_2, float float_3)
	{
		int num = class787_0.Rotation / 45;
		float num2 = 0f;
		switch (num)
		{
		case 1:
			num2 = float_1;
			float_3 /= 2f;
			break;
		case 2:
			num2 = float_1;
			float_3 /= 2f;
			break;
		case 3:
			num2 = float_1 / 2f;
			break;
		case 4:
			num2 = float_1 / 2f;
			break;
		case 5:
			num2 = 0f;
			float_3 /= 2f;
			break;
		case 6:
			num2 = 0f;
			float_3 /= 2f;
			break;
		case 7:
			num2 = float_1 / 2f;
			break;
		case 0:
		case 8:
			num2 = float_1 / 2f;
			break;
		}
		float num3 = class787_0.method_13().method_2();
		float_0 += num2;
		float float_4;
		if (float_0 <= num3)
		{
			float_4 = 2f * (num3 - float_0);
			return smethod_47(class787_0, float_2 + float_3, float_4, 0f, 0);
		}
		float_4 = 2f * (float_0 - num3);
		return smethod_47(class787_0, float_2 + float_3, float_4, 0f, 1);
	}

	internal static PointF smethod_44(Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4)
	{
		int num = class787_0.Rotation / 45;
		float num2 = 0f;
		int num3 = 0;
		switch (num)
		{
		case 1:
			num2 = float_1;
			float_2 = 0f;
			break;
		case 2:
			num2 = float_1;
			float_2 = 0f;
			break;
		case 3:
			num2 = float_1 / 2f;
			num3 = 1;
			break;
		case 4:
			num2 = float_1 / 2f;
			num3 = 2;
			break;
		case 5:
			num2 = 0f;
			float_2 = 0f;
			break;
		case 6:
			num2 = 0f;
			float_2 = 0f;
			break;
		case 7:
			num2 = float_1 / 2f;
			break;
		case 0:
		case 8:
			num2 = float_1 / 2f;
			break;
		}
		float num4 = class787_0.method_13().method_2();
		float_0 += num2;
		float float_5;
		int int_;
		if (float_0 <= num4)
		{
			float_5 = 2f * (num4 - float_0);
			int_ = ((num3 != 0) ? 3 : 0);
			return smethod_47(class787_0, float_3 + float_4 / 2f, float_5, float_2, int_);
		}
		float_5 = 2f * (float_0 - num4);
		int_ = ((num3 == 0) ? 1 : 2);
		return smethod_47(class787_0, float_3 + float_4 / 2f, float_5, float_2, int_);
	}

	internal static void smethod_45(Interface42 interface42_0, Class787 class787_0, ArrayList arrayList_0)
	{
		Class808 @class = class787_0.method_7();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			object[] array = (object[])arrayList_0[i];
			int num = (int)array[0];
			int num2 = (int)array[1];
			PointF pointF = (PointF)array[2];
			Class798 class2 = @class.method_9(num).method_10().method_1(num2)
				.method_6();
			SizeF sizeF = Struct26.smethod_0(interface42_0, class787_0.method_1(), @class, num, num2, (int)class787_0.method_13().Width);
			float num3 = pointF.X - sizeF.Width / 2f;
			float num4 = pointF.Y - sizeF.Height / 2f;
			class2.method_0().rectangle_1 = new Rectangle(Struct40.smethod_5(num3), Struct40.smethod_5(num4), Struct40.smethod_3(sizeF.Width), Struct40.smethod_3(sizeF.Height));
			class2.method_0().method_9();
			Struct26.smethod_1(interface42_0, class787_0.method_1(), @class, num, num2, class2.method_0().rectangle_0);
		}
	}

	private static void smethod_46(Interface42 interface42_0, Class796 class796_0, Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4, double double_0, ref double double_1)
	{
		Class810 @class = class796_0.method_1().method_0();
		double num = 1.0;
		double num2 = 1.0;
		switch (@class.BarShape)
		{
		case Enum62.const_0:
			smethod_60(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, (float)num, (float)num2);
			break;
		case Enum62.const_1:
			if (!@class.method_30() && !@class.method_32())
			{
				num = 0.0;
			}
			else
			{
				smethod_58(@class.NSeries, class796_0.Index, out var totalPositiveYValue6, out var totalMinusYValue6);
				if (class796_0.YValue == 0.0)
				{
					num = double_1;
					num2 = double_1;
				}
				else if (class796_0.YValue > 0.0)
				{
					num = ((totalPositiveYValue6 == 0.0) ? 1.0 : ((totalPositiveYValue6 - double_0) / totalPositiveYValue6));
					num2 = ((totalPositiveYValue6 == 0.0) ? 1.0 : ((totalPositiveYValue6 - (double_0 - class796_0.YValue)) / totalPositiveYValue6));
				}
				else
				{
					num = ((totalMinusYValue6 == 0.0) ? 1.0 : ((totalMinusYValue6 - double_0) / totalMinusYValue6));
					num2 = ((totalMinusYValue6 == 0.0) ? 1.0 : ((totalMinusYValue6 - (double_0 - class796_0.YValue)) / totalMinusYValue6));
				}
			}
			double_1 = num;
			smethod_60(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, (float)num, (float)num2);
			break;
		case Enum62.const_2:
			if (@class.method_30())
			{
				smethod_59(@class.NSeries, class796_0.Index, out var totalPositiveYValue3, out var totalMinusYValue3);
				if (class796_0.YValue == 0.0)
				{
					num = double_1;
					num2 = double_1;
				}
				else if (class796_0.YValue > 0.0)
				{
					num = ((totalPositiveYValue3 == 0.0) ? 1.0 : ((totalPositiveYValue3 - double_0) / totalPositiveYValue3));
					num2 = ((totalPositiveYValue3 == 0.0) ? 1.0 : ((totalPositiveYValue3 - (double_0 - class796_0.YValue)) / totalPositiveYValue3));
				}
				else
				{
					num = ((totalMinusYValue3 == 0.0) ? 1.0 : ((totalMinusYValue3 - double_0) / totalMinusYValue3));
					num2 = ((totalMinusYValue3 == 0.0) ? 1.0 : ((totalMinusYValue3 - (double_0 - class796_0.YValue)) / totalMinusYValue3));
				}
			}
			else if (@class.method_32())
			{
				smethod_58(@class.NSeries, class796_0.Index, out var totalPositiveYValue4, out var totalMinusYValue4);
				if (class796_0.YValue == 0.0)
				{
					num = double_1;
					num2 = double_1;
				}
				else if (class796_0.YValue > 0.0)
				{
					num = ((totalPositiveYValue4 == 0.0) ? 1.0 : ((totalPositiveYValue4 - double_0) / totalPositiveYValue4));
					num2 = ((totalPositiveYValue4 == 0.0) ? 1.0 : ((totalPositiveYValue4 - (double_0 - class796_0.YValue)) / totalPositiveYValue4));
				}
				else
				{
					num = ((totalMinusYValue4 == 0.0) ? 1.0 : ((totalMinusYValue4 - double_0) / totalMinusYValue4));
					num2 = ((totalMinusYValue4 == 0.0) ? 1.0 : ((totalMinusYValue4 - (double_0 - class796_0.YValue)) / totalMinusYValue4));
				}
			}
			else
			{
				num = (float)smethod_57(class796_0);
				num2 = 1.0;
			}
			double_1 = num;
			smethod_60(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, (float)num, (float)num2);
			break;
		case Enum62.const_3:
			double_1 = num;
			smethod_62(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, (float)num, (float)num2);
			break;
		case Enum62.const_4:
			if (!@class.method_30() && !@class.method_32())
			{
				num = 0.0;
			}
			else
			{
				smethod_58(@class.NSeries, class796_0.Index, out var totalPositiveYValue5, out var totalMinusYValue5);
				if (class796_0.YValue == 0.0)
				{
					num = double_1;
					num2 = double_1;
				}
				else if (class796_0.YValue > 0.0)
				{
					num = ((totalPositiveYValue5 == 0.0) ? 1.0 : ((totalPositiveYValue5 - double_0) / totalPositiveYValue5));
					num2 = ((totalPositiveYValue5 == 0.0) ? 1.0 : ((totalPositiveYValue5 - (double_0 - class796_0.YValue)) / totalPositiveYValue5));
				}
				else
				{
					num = ((totalMinusYValue5 == 0.0) ? 1.0 : ((totalMinusYValue5 - double_0) / totalMinusYValue5));
					num2 = ((totalMinusYValue5 == 0.0) ? 1.0 : ((totalMinusYValue5 - (double_0 - class796_0.YValue)) / totalMinusYValue5));
				}
			}
			double_1 = num;
			smethod_62(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, (float)num, (float)num2);
			break;
		case Enum62.const_5:
			if (@class.method_30())
			{
				smethod_59(@class.NSeries, class796_0.Index, out var totalPositiveYValue, out var totalMinusYValue);
				if (class796_0.YValue == 0.0)
				{
					num = double_1;
					num2 = double_1;
				}
				else if (class796_0.YValue > 0.0)
				{
					num = ((totalPositiveYValue == 0.0) ? 1.0 : ((totalPositiveYValue - double_0) / totalPositiveYValue));
					num2 = ((totalPositiveYValue == 0.0) ? 1.0 : ((totalPositiveYValue - (double_0 - class796_0.YValue)) / totalPositiveYValue));
				}
				else
				{
					num = ((totalMinusYValue == 0.0) ? 1.0 : ((totalMinusYValue - double_0) / totalMinusYValue));
					num2 = ((totalMinusYValue == 0.0) ? 1.0 : ((totalMinusYValue - (double_0 - class796_0.YValue)) / totalMinusYValue));
				}
			}
			else if (@class.method_32())
			{
				smethod_58(@class.NSeries, class796_0.Index, out var totalPositiveYValue2, out var totalMinusYValue2);
				if (class796_0.YValue == 0.0)
				{
					num = double_1;
					num2 = double_1;
				}
				else if (class796_0.YValue > 0.0)
				{
					num = ((totalPositiveYValue2 == 0.0) ? 1.0 : ((totalPositiveYValue2 - double_0) / totalPositiveYValue2));
					num2 = ((totalPositiveYValue2 == 0.0) ? 1.0 : ((totalPositiveYValue2 - (double_0 - class796_0.YValue)) / totalPositiveYValue2));
				}
				else
				{
					num = ((totalMinusYValue2 == 0.0) ? 1.0 : ((totalMinusYValue2 - double_0) / totalMinusYValue2));
					num2 = ((totalMinusYValue2 == 0.0) ? 1.0 : ((totalMinusYValue2 - (double_0 - class796_0.YValue)) / totalMinusYValue2));
				}
			}
			else
			{
				num = (float)smethod_57(class796_0);
				num2 = 1.0;
			}
			double_1 = num;
			smethod_62(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, (float)num, (float)num2);
			break;
		}
	}

	internal static PointF smethod_47(Class787 class787_0, float float_0, float float_1, float float_2, int int_0)
	{
		PointF pointF = new PointF(class787_0.method_13().X + class787_0.method_13().Width / 2f, float_0);
		int num = class787_0.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2 = class787_0.Rotation / 45;
		float num3;
		float num4;
		switch (num2)
		{
		default:
			num3 = float_2;
			num4 = float_1;
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			num3 = float_1;
			num4 = float_2;
			break;
		}
		float num5 = num4 * (float)Math.Sin((double)num * Math.PI / 180.0);
		float num6 = num4 * (float)Math.Sin((double)class787_0.Elevation * Math.PI / 180.0);
		PointF[] array = new PointF[4];
		switch (num2)
		{
		case 1:
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			break;
		case 2:
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			break;
		case 3:
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			break;
		case 4:
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			break;
		case 5:
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			break;
		case 6:
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			break;
		case 7:
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			break;
		case 0:
		case 8:
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[0].X + num5;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			break;
		}
		return array[int_0];
	}

	internal static PointF[] smethod_48(Interface42 interface42_0, Class787 class787_0, float float_0, float float_1, float float_2, float float_3, int int_0, int int_1)
	{
		float num = float_3 * (float)class787_0.GapDepth / 100f;
		PointF[] array = new PointF[2];
		float num2 = class787_0.method_13().method_2();
		Class789 @class = class787_0.method_11();
		float num3 = class787_0.method_13().Depth / (float)int_1;
		float num4 = (float)int_1 / 2f;
		if (@class.IsPlotOrderReversed)
		{
			int_0 = int_1 + 1 - int_0;
		}
		if ((float)int_0 <= num4 && !@class.IsPlotOrderReversed)
		{
			float num5 = ((num4 - (float)int_0) * num3 + num / 2f + float_3) * 2f;
			if (float_2 <= num2)
			{
				float float_4 = 2f * (num2 - float_2);
				ref PointF reference = ref array[0];
				reference = smethod_47(class787_0, float_0 + float_1, float_4, num5, 0);
				num5 -= float_3 * 2f;
				ref PointF reference2 = ref array[1];
				reference2 = smethod_47(class787_0, float_0 + float_1, float_4, num5, 0);
			}
			else
			{
				float float_4 = 2f * (float_2 - num2);
				ref PointF reference3 = ref array[0];
				reference3 = smethod_47(class787_0, float_0 + float_1, float_4, num5, 1);
				num5 -= float_3 * 2f;
				ref PointF reference4 = ref array[1];
				reference4 = smethod_47(class787_0, float_0 + float_1, float_4, num5, 1);
			}
		}
		else
		{
			float num5 = (((float)int_0 - num4) * num3 - num / 2f - float_3) * 2f;
			if (float_2 <= num2)
			{
				float float_4 = 2f * (num2 - float_2);
				ref PointF reference5 = ref array[0];
				reference5 = smethod_47(class787_0, float_0 + float_1, float_4, num5, 3);
				num5 += float_3 * 2f;
				ref PointF reference6 = ref array[1];
				reference6 = smethod_47(class787_0, float_0 + float_1, float_4, num5, 3);
			}
			else
			{
				float float_4 = 2f * (float_2 - num2);
				ref PointF reference7 = ref array[0];
				reference7 = smethod_47(class787_0, float_0 + float_1, float_4, num5, 2);
				num5 += float_3 * 2f;
				ref PointF reference8 = ref array[1];
				reference8 = smethod_47(class787_0, float_0 + float_1, float_4, num5, 2);
			}
		}
		return array;
	}

	private static void smethod_49(Interface42 interface42_0, Class796 class796_0, Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4, int int_0, int int_1)
	{
		Class810 @class = class796_0.method_1().method_0();
		switch (@class.BarShape)
		{
		case Enum62.const_0:
			smethod_50(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, int_0, int_1, 1f);
			break;
		case Enum62.const_1:
			smethod_50(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, int_0, int_1, 0f);
			break;
		case Enum62.const_3:
			smethod_51(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, int_0, int_1, 1f);
			break;
		case Enum62.const_4:
			smethod_51(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, int_0, int_1, 0f);
			break;
		case Enum62.const_2:
			break;
		}
	}

	private static void smethod_50(Interface42 interface42_0, Class796 class796_0, Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4, int int_0, int int_1, float float_5)
	{
		float num = float_4 * (float)class787_0.GapDepth / 100f;
		PointF[] array = new PointF[8];
		float num2 = class787_0.method_13().method_2();
		Class789 @class = class787_0.method_11();
		float num3 = float_2;
		float num4 = float_2 + float_3 * (1f - float_5) / 2f;
		float num5 = class787_0.method_13().Depth / (float)int_1;
		float num6 = (float)int_1 / 2f;
		if (@class.IsPlotOrderReversed)
		{
			int_0 = int_1 + 1 - int_0;
		}
		bool flag = false;
		if ((float)int_0 <= num6 && !@class.IsPlotOrderReversed)
		{
			flag = true;
		}
		float num7 = (((float)int_0 - num6) * num5 - num / 2f - float_4) * 2f;
		int int_2;
		int int_3;
		if (flag)
		{
			num7 = 0f - num7;
			int_2 = 0;
			int_3 = 1;
		}
		else
		{
			int_2 = 3;
			int_3 = 2;
		}
		int num8 = 3;
		PointF empty = PointF.Empty;
		for (int i = 0; i < 2; i++)
		{
			if (num3 <= num2)
			{
				float float_6 = 2f * (num2 - num3);
				ref PointF reference = ref array[i];
				reference = smethod_47(class787_0, float_0, float_6, num7, int_2);
				num7 = ((!flag) ? (num7 + float_4 * 2f) : (num7 - float_4 * 2f));
				ref PointF reference2 = ref array[i + num8];
				reference2 = smethod_47(class787_0, float_0, float_6, num7, int_2);
			}
			else
			{
				float float_6 = 2f * (num3 - num2);
				ref PointF reference3 = ref array[i];
				reference3 = smethod_47(class787_0, float_0, float_6, num7, int_3);
				num7 = ((!flag) ? (num7 + float_4 * 2f) : (num7 - float_4 * 2f));
				ref PointF reference4 = ref array[i + num8];
				reference4 = smethod_47(class787_0, float_0, float_6, num7, int_3);
			}
			num7 = (((float)int_0 - num6) * num5 - num / 2f - float_4) * 2f;
			if (flag)
			{
				num7 = 0f - num7;
			}
			if (num4 <= num2)
			{
				float float_6 = 2f * (num2 - num4);
				empty = smethod_47(class787_0, float_0, float_6, smethod_53(num7, flag, float_4, float_5), int_2);
				array[i + 4].X = empty.X;
				array[i + 4].Y = empty.Y + float_1;
				if (float_5 == 1f)
				{
					num7 = ((!flag) ? (num7 + float_4 * 2f) : (num7 - float_4 * 2f));
				}
				empty = smethod_47(class787_0, float_0, float_6, smethod_53(num7, flag, float_4, float_5), int_2);
				array[i + num8 + 4].X = empty.X;
				array[i + num8 + 4].Y = empty.Y + float_1;
			}
			else
			{
				float float_6 = 2f * (num4 - num2);
				empty = smethod_47(class787_0, float_0, float_6, smethod_53(num7, flag, float_4, float_5), int_3);
				array[i + 4].X = empty.X;
				array[i + 4].Y = empty.Y + float_1;
				if (float_5 == 1f)
				{
					num7 = ((!flag) ? (num7 + float_4 * 2f) : (num7 - float_4 * 2f));
				}
				empty = smethod_47(class787_0, float_0, float_6, smethod_53(num7, flag, float_4, float_5), int_3);
				array[i + num8 + 4].X = empty.X;
				array[i + num8 + 4].Y = empty.Y + float_1;
			}
			num8 = 1;
			num3 += float_3;
			num4 += float_3 * float_5;
			num7 = (((float)int_0 - num6) * num5 - num / 2f - float_4) * 2f;
			if (flag)
			{
				num7 = 0f - num7;
			}
		}
		smethod_61(interface42_0, class787_0, class796_0, array, float_1);
	}

	private static void smethod_51(Interface42 interface42_0, Class796 class796_0, Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4, int int_0, int int_1, float float_5)
	{
		float num = class787_0.method_13().method_2();
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		float num2 = float_2 + float_3 / 2f;
		float num3 = float_4 * (float)class787_0.GapDepth / 100f;
		Class789 @class = class787_0.method_11();
		float num4 = class787_0.method_13().Depth / (float)int_1;
		float num5 = (float)int_1 / 2f;
		if (@class.IsPlotOrderReversed)
		{
			int_0 = int_1 + 1 - int_0;
		}
		bool flag = false;
		if ((float)int_0 <= num5 && !@class.IsPlotOrderReversed)
		{
			flag = true;
		}
		float num6 = (((float)int_0 - num5) * num4 - num3 / 2f - float_4 / 2f) * 2f;
		int int_2;
		int int_3;
		if (flag)
		{
			num6 = 0f - num6;
			int_2 = 0;
			int_3 = 1;
		}
		else
		{
			int_2 = 3;
			int_3 = 2;
		}
		for (int i = 0; i <= 180; i++)
		{
			double num7 = (double)i * Math.PI / 180.0;
			float float_6 = (float)((double)float_4 * Math.Sin(num7));
			float num8 = (float)((double)num2 + (double)(float_3 / 2f) * Math.Cos(num7));
			if (num8 <= num)
			{
				float float_7 = 2f * (num - num8);
				if (!hashtable.ContainsKey(360 - i))
				{
					hashtable.Add(360 - i, smethod_47(class787_0, float_0, float_7, smethod_52(360 - i, flag, num6, float_6), int_2));
				}
				if (!hashtable.ContainsKey(i))
				{
					hashtable.Add(i, smethod_47(class787_0, float_0, float_7, smethod_52(i, flag, num6, float_6), int_2));
				}
			}
			else
			{
				float float_7 = 2f * (num8 - num);
				if (!hashtable.ContainsKey(360 - i))
				{
					hashtable.Add(360 - i, smethod_47(class787_0, float_0, float_7, smethod_52(360 - i, flag, num6, float_6), int_3));
				}
				if (!hashtable.ContainsKey(i))
				{
					hashtable.Add(i, smethod_47(class787_0, float_0, float_7, smethod_52(i, flag, num6, float_6), int_3));
				}
			}
			num8 = (float)((double)num2 + (double)(float_3 / 2f * float_5) * Math.Cos(num7));
			float_6 = (float)((double)(float_4 * float_5) * Math.Sin(num7));
			if (num8 <= num)
			{
				float float_7 = 2f * (num - num8);
				if (!hashtable2.ContainsKey(360 - i))
				{
					PointF pointF = smethod_47(class787_0, float_0, float_7, smethod_52(360 - i, flag, num6, float_6), int_2);
					pointF.Y += float_1;
					hashtable2.Add(360 - i, pointF);
				}
				if (!hashtable2.ContainsKey(i))
				{
					PointF pointF2 = smethod_47(class787_0, float_0, float_7, smethod_52(i, flag, num6, float_6), int_2);
					pointF2.Y += float_1;
					hashtable2.Add(i, pointF2);
				}
			}
			else
			{
				float float_7 = 2f * (num8 - num);
				if (!hashtable2.ContainsKey(360 - i))
				{
					PointF pointF3 = smethod_47(class787_0, float_0, float_7, smethod_52(360 - i, flag, num6, float_6), int_3);
					pointF3.Y += float_1;
					hashtable2.Add(360 - i, pointF3);
				}
				if (!hashtable2.ContainsKey(i))
				{
					PointF pointF4 = smethod_47(class787_0, float_0, float_7, smethod_52(i, flag, num6, float_6), int_3);
					pointF4.Y += float_1;
					hashtable2.Add(i, pointF4);
				}
			}
		}
		smethod_63(interface42_0, class796_0, hashtable, hashtable2, float_1);
	}

	private static float smethod_52(int int_0, bool bool_0, float float_0, float float_1)
	{
		if (bool_0)
		{
			if (int_0 <= 180)
			{
				return float_0 - float_1;
			}
			return float_0 + float_1;
		}
		if (int_0 <= 180)
		{
			return float_0 + float_1;
		}
		return float_0 - float_1;
	}

	private static float smethod_53(float float_0, bool bool_0, float float_1, float float_2)
	{
		float_0 = ((!bool_0) ? (float_0 + float_1 * (1f - float_2)) : (float_0 - float_1 * (1f - float_2)));
		return float_0;
	}

	private static void smethod_54(Interface42 interface42_0, Class787 class787_0, IList ilist_0)
	{
		if (ilist_0.Count <= 1)
		{
			return;
		}
		PointF[] pointF_ = null;
		int i;
		for (i = 0; i < ilist_0.Count; i++)
		{
			if (ilist_0[i] != null)
			{
				object[] array = (object[])ilist_0[i];
				pointF_ = (PointF[])array[1];
				i++;
				break;
			}
		}
		for (int j = i; j < ilist_0.Count; j++)
		{
			if (ilist_0[j] != null)
			{
				object[] array2 = (object[])ilist_0[j];
				Class796 class796_ = (Class796)array2[0];
				PointF[] array3 = (PointF[])array2[1];
				smethod_55(interface42_0, class787_0, class796_, pointF_, array3);
				pointF_ = array3;
			}
			else
			{
				pointF_ = null;
			}
		}
	}

	private static void smethod_55(Interface42 interface42_0, Class787 class787_0, Class796 class796_0, PointF[] pointF_0, PointF[] pointF_1)
	{
		if (pointF_0 == null || pointF_1 == null || class796_0 == null)
		{
			return;
		}
		Class788 class788_ = class796_0.method_3();
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(new PointF[4]
		{
			pointF_0[0],
			pointF_1[0],
			pointF_1[1],
			pointF_0[1]
		});
		graphicsPath.CloseAllFigures();
		Brush brush = null;
		using Pen pen_ = Struct29.smethod_5(class796_0.method_4());
		if (class787_0.Rotation == 0 || class787_0.Rotation == 360 || class787_0.Rotation == 180)
		{
			brush = ((pointF_1[1].Y > pointF_1[0].Y) ? ((class787_0.Rotation == 0 || class787_0.Rotation == 360) ? Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath), 2f / 3f) : Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath))) : ((class787_0.Rotation == 0 || class787_0.Rotation == 360) ? Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath)) : Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath), 2f / 3f)));
		}
		else if (class787_0.Rotation == 90 || class787_0.Rotation == 270)
		{
			brush = ((!(pointF_1[0].Y > pointF_0[0].Y)) ? Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath), 2f / 3f) : Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath)));
		}
		else if (pointF_0[1].X != pointF_1[1].X && pointF_0[1].Y != pointF_1[1].Y)
		{
			float num = 0f;
			float num2 = (num - pointF_0[1].Y - (num - pointF_1[1].Y)) / (pointF_0[1].X - pointF_1[1].X);
			float num3 = num - pointF_1[1].Y - num2 * pointF_1[1].X;
			float num4 = num - pointF_1[0].Y;
			float num5 = num2 * pointF_1[0].X + num3;
			if ((class787_0.Rotation > 0 && class787_0.Rotation < 90) || (class787_0.Rotation > 270 && class787_0.Rotation < 360))
			{
				brush = ((!(num4 > num5)) ? Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath)) : Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath), 2f / 3f));
			}
			else if (class787_0.Rotation > 90 && class787_0.Rotation < 270)
			{
				brush = ((!(num4 < num5)) ? Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath)) : Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath), 2f / 3f));
			}
		}
		if (brush == null)
		{
			brush = Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath));
		}
		interface42_0.imethod_33(brush, graphicsPath);
		interface42_0.imethod_15(pen_, pointF_0[0], pointF_1[0]);
		interface42_0.imethod_15(pen_, pointF_1[0], pointF_1[1]);
		interface42_0.imethod_15(pen_, pointF_1[1], pointF_0[1]);
		interface42_0.imethod_15(pen_, pointF_0[1], pointF_0[0]);
		brush?.Dispose();
	}

	private static PointF smethod_56(Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4, int int_0, int int_1)
	{
		int num = class787_0.Rotation / 45;
		float num2 = 0f;
		float num3 = 0f;
		switch (num)
		{
		case 1:
			num2 = float_3;
			num3 = float_4 / 2f;
			break;
		case 2:
			num2 = float_3;
			num3 = float_4 / 2f;
			break;
		case 3:
			num2 = float_3 / 2f;
			num3 = float_4;
			break;
		case 4:
			num2 = float_3 / 2f;
			num3 = float_4;
			break;
		case 5:
			num2 = 0f;
			num3 = float_4 / 2f;
			break;
		case 6:
			num2 = 0f;
			num3 = float_4 / 2f;
			break;
		case 7:
			num2 = float_3 / 2f;
			break;
		case 0:
		case 8:
			num2 = float_3 / 2f;
			break;
		}
		float num4 = class787_0.method_13().method_2();
		float_2 += num2;
		float_1 /= 2f;
		Class789 @class = class787_0.method_11();
		float num5 = float_4 * (float)class787_0.GapDepth / 100f;
		float num6 = class787_0.method_13().Depth / (float)int_1;
		float num7 = (float)int_1 / 2f;
		if (@class.IsPlotOrderReversed)
		{
			int_0 = int_1 + 1 - int_0;
		}
		float float_5;
		float float_6;
		if ((float)int_0 <= num7 && !@class.IsPlotOrderReversed)
		{
			float_5 = ((num7 - (float)int_0) * num6 + num5 / 2f + float_4 - num3) * 2f;
			if (float_2 <= num4)
			{
				float_6 = 2f * (num4 - float_2);
				return smethod_47(class787_0, float_0 + float_1, float_6, float_5, 0);
			}
			float_6 = 2f * (float_2 - num4);
			return smethod_47(class787_0, float_0 + float_1, float_6, float_5, 1);
		}
		float_5 = (((float)int_0 - num7) * num6 - num5 / 2f - float_4 + num3) * 2f;
		if (float_2 <= num4)
		{
			float_6 = 2f * (num4 - float_2);
			return smethod_47(class787_0, float_0 + float_1, float_6, float_5, 3);
		}
		float_6 = 2f * (float_2 - num4);
		return smethod_47(class787_0, float_0 + float_1, float_6, float_5, 2);
	}

	internal static double smethod_57(Class796 class796_0)
	{
		double num = 0.0;
		double num2 = 0.0;
		Class789 @class = class796_0.Chart.method_9();
		double num3 = @class.method_14();
		Class808 class2 = class796_0.Chart.method_7();
		class2.method_10();
		for (int i = 0; i < class796_0.method_1().Count; i++)
		{
			for (int j = 0; j < class2.Count; j++)
			{
				Class796 class3 = class2.method_9(j).method_10().method_1(i);
				if (class3 != null)
				{
					double yValue = class3.YValue;
					if (yValue > num3 && num < yValue - num3)
					{
						num = yValue - num3;
					}
					if (yValue < num3 && num2 < num3 - yValue)
					{
						num2 = num3 - yValue;
					}
				}
			}
		}
		double num4 = @class.method_17(class796_0.YValue);
		if (class796_0.YValue >= num3)
		{
			if (num != 0.0)
			{
				return (num - (num4 - num3)) / num;
			}
			return 1.0;
		}
		if (num2 != 0.0)
		{
			return (num2 - (num3 - num4)) / num2;
		}
		return 1.0;
	}

	internal static void smethod_58(Class808 nSeries, int pointIndex, out double totalPositiveYValue, out double totalMinusYValue)
	{
		totalPositiveYValue = 0.0;
		totalMinusYValue = 0.0;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Class810 @class = nSeries.method_9(i);
			double yValue = @class.method_10()[pointIndex].YValue;
			if (yValue > 0.0)
			{
				totalPositiveYValue += yValue;
			}
			if (yValue < 0.0)
			{
				totalMinusYValue += yValue;
			}
		}
	}

	internal static void smethod_59(Class808 nSeries, int pointIndex, out double totalPositiveYValue, out double totalMinusYValue)
	{
		totalPositiveYValue = 0.0;
		totalMinusYValue = 0.0;
		int num = nSeries.method_10();
		for (int i = 0; i < num; i++)
		{
			smethod_58(nSeries, i, out var totalPositiveYValue2, out var totalMinusYValue2);
			if (totalPositiveYValue2 > totalPositiveYValue)
			{
				totalPositiveYValue = totalPositiveYValue2;
			}
			if (totalMinusYValue2 < totalMinusYValue)
			{
				totalMinusYValue = totalMinusYValue2;
			}
		}
	}

	private static void smethod_60(Interface42 interface42_0, Class796 class796_0, Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6)
	{
		PointF[] array = new PointF[8];
		float num = class787_0.method_13().method_2();
		int num2 = 3;
		PointF empty = PointF.Empty;
		float num3 = float_0 + float_1 * (1f - float_5) / 2f;
		float num4 = float_0 + float_1 * (1f - float_6) / 2f;
		for (int i = 0; i < 2; i++)
		{
			if (num4 <= num)
			{
				float float_7 = 2f * (num - num4);
				ref PointF reference = ref array[i];
				reference = smethod_47(class787_0, float_3, float_7, float_2 * float_6, 0);
				ref PointF reference2 = ref array[i + num2];
				reference2 = smethod_47(class787_0, float_3, float_7, float_2 * float_6, 3);
			}
			else
			{
				float float_7 = 2f * (num4 - num);
				ref PointF reference3 = ref array[i];
				reference3 = smethod_47(class787_0, float_3, float_7, float_2 * float_6, 1);
				ref PointF reference4 = ref array[i + num2];
				reference4 = smethod_47(class787_0, float_3, float_7, float_2 * float_6, 2);
			}
			if (num3 <= num)
			{
				float float_7 = 2f * (num - num3);
				empty = smethod_47(class787_0, float_3, float_7, float_2 * float_5, 0);
				array[i + 4].X = empty.X;
				array[i + 4].Y = empty.Y + float_4;
				empty = smethod_47(class787_0, float_3, float_7, float_2 * float_5, 3);
				array[i + num2 + 4].X = empty.X;
				array[i + num2 + 4].Y = empty.Y + float_4;
			}
			else
			{
				float float_7 = 2f * (num3 - num);
				empty = smethod_47(class787_0, float_3, float_7, float_2 * float_5, 1);
				array[i + 4].X = empty.X;
				array[i + 4].Y = empty.Y + float_4;
				empty = smethod_47(class787_0, float_3, float_7, float_2 * float_5, 2);
				array[i + num2 + 4].X = empty.X;
				array[i + num2 + 4].Y = empty.Y + float_4;
			}
			num2 = 1;
			num4 += float_1 * float_6;
			num3 += float_1 * float_5;
		}
		smethod_61(interface42_0, class787_0, class796_0, array, float_4);
	}

	private static void smethod_61(Interface42 interface42_0, Class787 class787_0, Class796 class796_0, PointF[] pointF_0, float float_0)
	{
		Class788 class788_ = class796_0.method_3();
		using Pen pen = Struct29.smethod_5(class796_0.method_4());
		interface42_0.imethod_15(pen, pointF_0[0], pointF_0[1]);
		interface42_0.imethod_15(pen, pointF_0[1], pointF_0[2]);
		interface42_0.imethod_15(pen, pointF_0[2], pointF_0[3]);
		interface42_0.imethod_15(pen, pointF_0[0], pointF_0[3]);
		if (float_0 != 0f)
		{
			interface42_0.imethod_15(pen, pointF_0[4], pointF_0[5]);
			interface42_0.imethod_15(pen, pointF_0[5], pointF_0[6]);
			interface42_0.imethod_15(pen, pointF_0[6], pointF_0[7]);
			interface42_0.imethod_15(pen, pointF_0[4], pointF_0[7]);
			interface42_0.imethod_15(pen, pointF_0[0], pointF_0[4]);
			interface42_0.imethod_15(pen, pointF_0[1], pointF_0[5]);
			interface42_0.imethod_15(pen, pointF_0[2], pointF_0[6]);
			interface42_0.imethod_15(pen, pointF_0[3], pointF_0[7]);
		}
		if (float_0 != 0f)
		{
			if (class787_0.Rotation > 45 && class787_0.Rotation != 360)
			{
				if (class787_0.Rotation > 45 && class787_0.Rotation <= 90)
				{
					GraphicsPath graphicsPath = new GraphicsPath();
					graphicsPath.AddPolygon(new PointF[4]
					{
						pointF_0[1],
						pointF_0[2],
						pointF_0[6],
						pointF_0[5]
					});
					using (Brush brush = Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath)))
					{
						if (pen.Color.A == 0)
						{
							using Pen pen_ = new Pen(brush);
							interface42_0.imethod_16(pen_, pointF_0[1].X, pointF_0[1].Y, pointF_0[5].X, pointF_0[5].Y);
						}
						interface42_0.imethod_33(brush, graphicsPath);
					}
					GraphicsPath graphicsPath2 = new GraphicsPath();
					graphicsPath2.AddPolygon(new PointF[4]
					{
						pointF_0[0],
						pointF_0[1],
						pointF_0[5],
						pointF_0[4]
					});
					using (Brush brush_ = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath2), 0.5f))
					{
						interface42_0.imethod_33(brush_, graphicsPath2);
					}
					if (pen.Color.A != 0)
					{
						interface42_0.imethod_18(pen, graphicsPath);
						interface42_0.imethod_18(pen, graphicsPath2);
					}
				}
				else if (class787_0.Rotation > 90 && class787_0.Rotation <= 135)
				{
					GraphicsPath graphicsPath3 = new GraphicsPath();
					graphicsPath3.AddPolygon(new PointF[4]
					{
						pointF_0[1],
						pointF_0[2],
						pointF_0[6],
						pointF_0[5]
					});
					using (Brush brush2 = Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath3)))
					{
						if (pen.Color.A == 0)
						{
							using Pen pen_2 = new Pen(brush2);
							interface42_0.imethod_16(pen_2, pointF_0[2].X, pointF_0[2].Y, pointF_0[6].X, pointF_0[6].Y);
						}
						interface42_0.imethod_33(brush2, graphicsPath3);
					}
					GraphicsPath graphicsPath4 = new GraphicsPath();
					graphicsPath4.AddPolygon(new PointF[4]
					{
						pointF_0[2],
						pointF_0[3],
						pointF_0[7],
						pointF_0[6]
					});
					using (Brush brush_2 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath4), 0.5f))
					{
						interface42_0.imethod_33(brush_2, graphicsPath4);
					}
					if (pen.Color.A != 0)
					{
						interface42_0.imethod_18(pen, graphicsPath3);
						interface42_0.imethod_18(pen, graphicsPath4);
					}
				}
				else if (class787_0.Rotation > 135 && class787_0.Rotation <= 180)
				{
					GraphicsPath graphicsPath5 = new GraphicsPath();
					graphicsPath5.AddPolygon(new PointF[4]
					{
						pointF_0[2],
						pointF_0[3],
						pointF_0[7],
						pointF_0[6]
					});
					using (Brush brush3 = Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath5)))
					{
						if (pen.Color.A == 0)
						{
							using Pen pen_3 = new Pen(brush3);
							interface42_0.imethod_16(pen_3, pointF_0[2].X, pointF_0[2].Y, pointF_0[6].X, pointF_0[6].Y);
						}
						interface42_0.imethod_33(brush3, graphicsPath5);
					}
					GraphicsPath graphicsPath6 = new GraphicsPath();
					graphicsPath6.AddPolygon(new PointF[4]
					{
						pointF_0[1],
						pointF_0[2],
						pointF_0[6],
						pointF_0[5]
					});
					using (Brush brush_3 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath6), 0.5f))
					{
						interface42_0.imethod_33(brush_3, graphicsPath6);
					}
					if (pen.Color.A != 0)
					{
						interface42_0.imethod_18(pen, graphicsPath5);
						interface42_0.imethod_18(pen, graphicsPath6);
					}
				}
				else if (class787_0.Rotation > 180 && class787_0.Rotation <= 225)
				{
					GraphicsPath graphicsPath7 = new GraphicsPath();
					graphicsPath7.AddPolygon(new PointF[4]
					{
						pointF_0[2],
						pointF_0[3],
						pointF_0[7],
						pointF_0[6]
					});
					using (Brush brush4 = Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath7)))
					{
						if (pen.Color.A == 0)
						{
							using Pen pen_4 = new Pen(brush4);
							interface42_0.imethod_16(pen_4, pointF_0[3].X, pointF_0[3].Y, pointF_0[7].X, pointF_0[7].Y);
						}
						interface42_0.imethod_33(brush4, graphicsPath7);
					}
					GraphicsPath graphicsPath8 = new GraphicsPath();
					graphicsPath8.AddPolygon(new PointF[4]
					{
						pointF_0[3],
						pointF_0[0],
						pointF_0[4],
						pointF_0[7]
					});
					using (Brush brush_4 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath8), 0.5f))
					{
						interface42_0.imethod_33(brush_4, graphicsPath8);
					}
					if (pen.Color.A != 0)
					{
						interface42_0.imethod_18(pen, graphicsPath7);
						interface42_0.imethod_18(pen, graphicsPath8);
					}
				}
				else if (class787_0.Rotation > 225 && class787_0.Rotation <= 270)
				{
					GraphicsPath graphicsPath9 = new GraphicsPath();
					graphicsPath9.AddPolygon(new PointF[4]
					{
						pointF_0[3],
						pointF_0[0],
						pointF_0[4],
						pointF_0[7]
					});
					using (Brush brush5 = Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath9)))
					{
						if (pen.Color.A == 0)
						{
							using Pen pen_5 = new Pen(brush5);
							interface42_0.imethod_16(pen_5, pointF_0[3].X, pointF_0[3].Y, pointF_0[7].X, pointF_0[7].Y);
						}
						interface42_0.imethod_33(brush5, graphicsPath9);
					}
					GraphicsPath graphicsPath10 = new GraphicsPath();
					graphicsPath10.AddPolygon(new PointF[4]
					{
						pointF_0[2],
						pointF_0[3],
						pointF_0[7],
						pointF_0[6]
					});
					using (Brush brush_5 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath10), 0.5f))
					{
						interface42_0.imethod_33(brush_5, graphicsPath10);
					}
					if (pen.Color.A != 0)
					{
						interface42_0.imethod_18(pen, graphicsPath9);
						interface42_0.imethod_18(pen, graphicsPath10);
					}
				}
				else if (class787_0.Rotation > 270 && class787_0.Rotation <= 315)
				{
					GraphicsPath graphicsPath11 = new GraphicsPath();
					graphicsPath11.AddPolygon(new PointF[4]
					{
						pointF_0[3],
						pointF_0[0],
						pointF_0[4],
						pointF_0[7]
					});
					using (Brush brush6 = Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath11)))
					{
						if (pen.Color.A == 0)
						{
							using Pen pen_6 = new Pen(brush6);
							interface42_0.imethod_16(pen_6, pointF_0[0].X, pointF_0[0].Y, pointF_0[4].X, pointF_0[4].Y);
						}
						interface42_0.imethod_33(brush6, graphicsPath11);
					}
					GraphicsPath graphicsPath12 = new GraphicsPath();
					graphicsPath12.AddPolygon(new PointF[4]
					{
						pointF_0[0],
						pointF_0[1],
						pointF_0[5],
						pointF_0[4]
					});
					using (Brush brush_6 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath12), 0.5f))
					{
						interface42_0.imethod_33(brush_6, graphicsPath12);
					}
					if (pen.Color.A != 0)
					{
						interface42_0.imethod_18(pen, graphicsPath11);
						interface42_0.imethod_18(pen, graphicsPath12);
					}
				}
				else if (class787_0.Rotation > 315 && class787_0.Rotation < 360)
				{
					GraphicsPath graphicsPath13 = new GraphicsPath();
					graphicsPath13.AddPolygon(new PointF[4]
					{
						pointF_0[0],
						pointF_0[1],
						pointF_0[5],
						pointF_0[4]
					});
					using (Brush brush7 = Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath13)))
					{
						if (pen.Color.A == 0)
						{
							using Pen pen_7 = new Pen(brush7);
							interface42_0.imethod_16(pen_7, pointF_0[0].X, pointF_0[0].Y, pointF_0[4].X, pointF_0[4].Y);
						}
						interface42_0.imethod_33(brush7, graphicsPath13);
					}
					GraphicsPath graphicsPath14 = new GraphicsPath();
					graphicsPath14.AddPolygon(new PointF[4]
					{
						pointF_0[3],
						pointF_0[0],
						pointF_0[4],
						pointF_0[7]
					});
					using (Brush brush_7 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath14), 0.5f))
					{
						interface42_0.imethod_33(brush_7, graphicsPath14);
					}
					if (pen.Color.A != 0)
					{
						interface42_0.imethod_18(pen, graphicsPath13);
						interface42_0.imethod_18(pen, graphicsPath14);
					}
				}
			}
			else
			{
				GraphicsPath graphicsPath15 = new GraphicsPath();
				graphicsPath15.AddPolygon(new PointF[4]
				{
					pointF_0[0],
					pointF_0[1],
					pointF_0[5],
					pointF_0[4]
				});
				using (Brush brush8 = Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath15)))
				{
					if (pen.Color.A == 0)
					{
						using Pen pen_8 = new Pen(brush8);
						interface42_0.imethod_16(pen_8, pointF_0[1].X, pointF_0[1].Y, pointF_0[5].X, pointF_0[5].Y);
					}
					interface42_0.imethod_33(brush8, graphicsPath15);
				}
				GraphicsPath graphicsPath16 = new GraphicsPath();
				graphicsPath16.AddPolygon(new PointF[4]
				{
					pointF_0[1],
					pointF_0[2],
					pointF_0[6],
					pointF_0[5]
				});
				using (Brush brush_8 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath16), 0.5f))
				{
					interface42_0.imethod_33(brush_8, graphicsPath16);
				}
				if (pen.Color.A != 0)
				{
					interface42_0.imethod_18(pen, graphicsPath15);
					interface42_0.imethod_18(pen, graphicsPath16);
				}
			}
			if (class787_0.Elevation > 0)
			{
				if (float_0 <= 0f)
				{
					GraphicsPath graphicsPath17 = new GraphicsPath();
					graphicsPath17.AddPolygon(new PointF[4]
					{
						pointF_0[4],
						pointF_0[5],
						pointF_0[6],
						pointF_0[7]
					});
					using (Brush brush_9 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath17), 2f / 3f))
					{
						interface42_0.imethod_33(brush_9, graphicsPath17);
					}
					interface42_0.imethod_18(pen, graphicsPath17);
				}
				else
				{
					GraphicsPath graphicsPath18 = new GraphicsPath();
					graphicsPath18.AddPolygon(new PointF[4]
					{
						pointF_0[0],
						pointF_0[1],
						pointF_0[2],
						pointF_0[3]
					});
					using (Brush brush_10 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath18), 0f))
					{
						interface42_0.imethod_33(brush_10, graphicsPath18);
					}
					interface42_0.imethod_18(pen, graphicsPath18);
				}
			}
			else
			{
				if (class787_0.Elevation >= 0)
				{
					return;
				}
				if (float_0 <= 0f)
				{
					GraphicsPath graphicsPath19 = new GraphicsPath();
					graphicsPath19.AddPolygon(new PointF[4]
					{
						pointF_0[0],
						pointF_0[1],
						pointF_0[2],
						pointF_0[3]
					});
					using (Brush brush_11 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath19), 0f))
					{
						interface42_0.imethod_33(brush_11, graphicsPath19);
					}
					interface42_0.imethod_18(pen, graphicsPath19);
				}
				else
				{
					GraphicsPath graphicsPath20 = new GraphicsPath();
					graphicsPath20.AddPolygon(new PointF[4]
					{
						pointF_0[4],
						pointF_0[5],
						pointF_0[6],
						pointF_0[7]
					});
					using (Brush brush_12 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath20), 2f / 3f))
					{
						interface42_0.imethod_33(brush_12, graphicsPath20);
					}
					interface42_0.imethod_18(pen, graphicsPath20);
				}
			}
		}
		else
		{
			GraphicsPath graphicsPath21 = new GraphicsPath();
			graphicsPath21.AddPolygon(new PointF[4]
			{
				pointF_0[0],
				pointF_0[1],
				pointF_0[2],
				pointF_0[3]
			});
			Brush brush9 = ((class787_0.Elevation <= 0) ? Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath21), 0f) : Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath21), 2f / 3f));
			interface42_0.imethod_33(brush9, graphicsPath21);
			brush9?.Dispose();
			interface42_0.imethod_18(pen, graphicsPath21);
		}
	}

	private static void smethod_62(Interface42 interface42_0, Class796 class796_0, Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6)
	{
		float num = class787_0.method_13().method_2();
		class796_0.method_1().method_0();
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		float num2 = float_0 + float_1 / 2f;
		for (int i = 0; i <= 180; i++)
		{
			double num3 = (double)i * Math.PI / 180.0;
			float num4 = (float)((double)float_2 * Math.Sin(num3));
			float num5 = (float)((double)num2 + (double)(float_1 * float_6 / 2f) * Math.Cos(num3));
			if (num5 <= num)
			{
				float float_7 = 2f * (num - num5);
				if (!hashtable.ContainsKey(360 - i))
				{
					hashtable.Add(360 - i, smethod_47(class787_0, float_3, float_7, num4 * float_6, 0));
				}
				if (!hashtable.ContainsKey(i))
				{
					hashtable.Add(i, smethod_47(class787_0, float_3, float_7, num4 * float_6, 3));
				}
			}
			else
			{
				float float_7 = 2f * (num5 - num);
				if (!hashtable.ContainsKey(360 - i))
				{
					hashtable.Add(360 - i, smethod_47(class787_0, float_3, float_7, num4 * float_6, 1));
				}
				if (!hashtable.ContainsKey(i))
				{
					hashtable.Add(i, smethod_47(class787_0, float_3, float_7, num4 * float_6, 2));
				}
			}
			num5 = (float)((double)num2 + (double)(float_1 * float_5 / 2f) * Math.Cos(num3));
			if (num5 <= num)
			{
				float float_7 = 2f * (num - num5);
				if (!hashtable2.ContainsKey(360 - i))
				{
					PointF pointF = smethod_47(class787_0, float_3, float_7, num4 * float_5, 0);
					pointF.Y += float_4;
					hashtable2.Add(360 - i, pointF);
				}
				if (!hashtable2.ContainsKey(i))
				{
					PointF pointF2 = smethod_47(class787_0, float_3, float_7, num4 * float_5, 3);
					pointF2.Y += float_4;
					hashtable2.Add(i, pointF2);
				}
			}
			else
			{
				float float_7 = 2f * (num5 - num);
				if (!hashtable2.ContainsKey(360 - i))
				{
					PointF pointF3 = smethod_47(class787_0, float_3, float_7, num4 * float_5, 1);
					pointF3.Y += float_4;
					hashtable2.Add(360 - i, pointF3);
				}
				if (!hashtable2.ContainsKey(i))
				{
					PointF pointF4 = smethod_47(class787_0, float_3, float_7, num4 * float_5, 2);
					pointF4.Y += float_4;
					hashtable2.Add(i, pointF4);
				}
			}
		}
		smethod_63(interface42_0, class796_0, hashtable, hashtable2, float_4);
	}

	private static void smethod_63(Interface42 interface42_0, Class796 class796_0, Hashtable hashtable_0, Hashtable hashtable_1, float float_0)
	{
		class796_0.method_1().method_0();
		Class787 chart = class796_0.Chart;
		Class788 class788_ = class796_0.method_3();
		int rotation = chart.Rotation;
		smethod_64(hashtable_0, out var max, out var min, out var maxAngle, out var minAngle);
		smethod_64(hashtable_1, out var max2, out var min2, out var _, out var _);
		if (float_0 != 0f)
		{
			int num = 180;
			int num2 = 360;
			float num3 = 0.5f;
			float num4 = 7.5f;
			float num5;
			for (num5 = 180 + rotation; num5 <= (float)(num2 + rotation); num5 += num4)
			{
				int num6 = (int)(num5 % 360f);
				PointF pointF = (PointF)hashtable_0[num6];
				PointF pointF2 = (PointF)hashtable_1[num6];
				if (num5 == (float)(num + rotation))
				{
					pointF = min;
					pointF2 = min2;
				}
				float num7 = num4;
				if ((num5 - (float)num == 45f && rotation <= 30) || (num5 - (float)num == 135f && rotation > 30) || num5 - (float)num == 90f || num5 - (float)num == 180f || (num5 - (float)num == 225f && rotation > 120) || num5 - (float)num == 270f || (num5 - (float)num == 315f && rotation > 210) || num5 - (float)num == 360f || (num5 - (float)num == 405f && rotation > 300) || num5 - (float)num == 450f)
				{
					num7 = 2f * num4;
				}
				if (num5 == (float)(num + rotation))
				{
					num7 = num4 - (float)rotation % num4;
				}
				int num8 = ((num5 + num7 > (float)(num2 + rotation)) ? ((num2 + rotation) % 360) : ((int)((num5 + num7) % 360f)));
				PointF pointF3 = (PointF)hashtable_0[num8];
				PointF pointF4 = (PointF)hashtable_1[num8];
				if (num5 + num7 >= (float)(num2 + rotation))
				{
					pointF3 = max;
					pointF4 = max2;
				}
				GraphicsPath graphicsPath = new GraphicsPath();
				PointF[] array = new PointF[(int)num7 + 1];
				int num9 = 0;
				for (int i = (int)num5; i <= (int)num5 + (int)num7; i++)
				{
					ref PointF reference = ref array[num9];
					reference = (PointF)hashtable_0[i % 360];
					num9++;
				}
				graphicsPath.AddLine(pointF, pointF3);
				graphicsPath.AddLine(pointF3, pointF4);
				PointF[] array2 = new PointF[(int)num7 + 1];
				num9 = 0;
				for (int num10 = (int)num5 + (int)num7; num10 >= (int)num5; num10--)
				{
					ref PointF reference2 = ref array2[num9];
					reference2 = (PointF)hashtable_1[num10 % 360];
					num9++;
				}
				graphicsPath.AddLine(pointF4, pointF2);
				graphicsPath.AddLine(pointF2, pointF);
				if (rotation >= 0 && rotation <= 30)
				{
					num3 = ((!(num5 - (float)num < 45f)) ? (1.125f - 0.5f * ((num5 - (float)num) / 180f)) : (0.75f + 0.5f * ((num5 - (float)num) / 90f)));
				}
				else if (rotation > 30 && rotation <= 120)
				{
					num3 = ((!(num5 - (float)num < 135f)) ? (1.375f - 0.5f * ((num5 - (float)num) / 180f)) : (0.625f + 0.5f * ((num5 - (float)num) / 180f)));
				}
				else if (rotation > 120 && rotation <= 210)
				{
					num3 = ((!(num5 - (float)num < 225f)) ? (1.375f - 0.5f * ((num5 - (float)num - 90f) / 180f)) : (0.625f + 0.5f * ((num5 - (float)num - 90f) / 180f)));
				}
				else if (rotation > 210 && rotation <= 300)
				{
					num3 = ((!(num5 - (float)num < 315f)) ? (1.375f - 0.5f * ((num5 - (float)num - 180f) / 180f)) : (0.625f + 0.5f * ((num5 - (float)num - 180f) / 180f)));
				}
				else if (rotation > 300 && rotation <= 360)
				{
					num3 = ((!(num5 - (float)num < 405f)) ? (1.375f - 0.5f * ((num5 - (float)num - 270f) / 180f)) : (0.625f + 0.5f * ((num5 - (float)num - 270f) / 180f)));
				}
				if (num3 == 1f)
				{
					num3 -= 1f / 90f;
				}
				using (Brush brush_ = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath), num3))
				{
					interface42_0.imethod_33(brush_, graphicsPath);
				}
				num5 += num7 - num4;
			}
		}
		using Pen pen_ = Struct29.smethod_5(class796_0.method_4());
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		PointF[] array3 = new PointF[hashtable_0.Count];
		PointF[] array4 = new PointF[hashtable_0.Count];
		for (int j = 0; j <= 360; j++)
		{
			ref PointF reference3 = ref array3[j];
			reference3 = (PointF)hashtable_0[j];
			ref PointF reference4 = ref array4[j];
			reference4 = (PointF)hashtable_1[j];
		}
		graphicsPath2.AddCurve(array3);
		graphicsPath3.AddCurve(array4);
		if (chart.Elevation > 0)
		{
			if (float_0 < 0f)
			{
				using (Brush brush_2 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath3), 0.7f))
				{
					interface42_0.imethod_33(brush_2, graphicsPath3);
				}
				interface42_0.imethod_18(pen_, graphicsPath3);
				smethod_65(interface42_0, maxAngle, minAngle, hashtable_0, pen_);
			}
			else if (float_0 > 0f)
			{
				using (Brush brush_3 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath3), 0f))
				{
					interface42_0.imethod_33(brush_3, graphicsPath2);
				}
				interface42_0.imethod_18(pen_, graphicsPath2);
				smethod_65(interface42_0, maxAngle, minAngle, hashtable_1, pen_);
			}
			else
			{
				using (Brush brush_4 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath3), 0.7f))
				{
					interface42_0.imethod_33(brush_4, graphicsPath2);
				}
				interface42_0.imethod_18(pen_, graphicsPath2);
			}
		}
		else if (chart.Elevation < 0)
		{
			if (float_0 < 0f)
			{
				using (Brush brush_5 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath3), 0f))
				{
					interface42_0.imethod_33(brush_5, graphicsPath2);
				}
				interface42_0.imethod_18(pen_, graphicsPath2);
				smethod_65(interface42_0, maxAngle, minAngle, hashtable_1, pen_);
			}
			else if (float_0 > 0f)
			{
				using (Brush brush_6 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath3), 0.7f))
				{
					interface42_0.imethod_33(brush_6, graphicsPath3);
				}
				interface42_0.imethod_18(pen_, graphicsPath3);
				smethod_65(interface42_0, maxAngle, minAngle, hashtable_0, pen_);
			}
			else
			{
				using (Brush brush_7 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath3), 0f))
				{
					interface42_0.imethod_33(brush_7, graphicsPath2);
				}
				interface42_0.imethod_18(pen_, graphicsPath2);
			}
		}
		else
		{
			interface42_0.imethod_16(pen_, min.X, min.Y, max.X, max.Y);
			interface42_0.imethod_16(pen_, min2.X, min2.Y, max2.X, max2.Y);
		}
		if (float_0 != 0f)
		{
			interface42_0.imethod_16(pen_, min.X, min.Y, min2.X, min2.Y);
			interface42_0.imethod_16(pen_, max.X, max.Y, max2.X, max2.Y);
		}
	}

	private static void smethod_64(Hashtable htPoint, out PointF max, out PointF min, out int maxAngle, out int minAngle)
	{
		max = PointF.Empty;
		min = PointF.Empty;
		maxAngle = 0;
		minAngle = 0;
		IDictionaryEnumerator enumerator = htPoint.GetEnumerator();
		while (enumerator.MoveNext())
		{
			PointF pointF = (PointF)enumerator.Value;
			if (max == PointF.Empty || pointF.X > max.X)
			{
				max = pointF;
				maxAngle = (int)enumerator.Key;
			}
			if (min == PointF.Empty || pointF.X < min.X)
			{
				min = pointF;
				minAngle = (int)enumerator.Key;
			}
		}
	}

	internal static void smethod_65(Interface42 interface42_0, int int_0, int int_1, Hashtable hashtable_0, Pen pen_0)
	{
		if (int_1 > int_0)
		{
			int_0 += 360;
		}
		PointF[] array = new PointF[Math.Abs(int_0 - int_1 + 1)];
		int num = 0;
		for (int i = int_1; i <= int_0; i++)
		{
			ref PointF reference = ref array[num];
			reference = (PointF)hashtable_0[i % 360];
			num++;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddCurve(array);
		interface42_0.imethod_18(pen_0, graphicsPath);
	}
}
