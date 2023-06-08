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
internal struct Struct20
{
	internal static ArrayList smethod_0(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Rectangle rectangle_0, float float_0, double double_0, int int_0)
	{
		Enum53 @enum = class810_0.method_21();
		ChartType_Chart chartType_Chart = ChartType_Chart.Bar;
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2;
		Class789 class3;
		int num;
		if (@enum == Enum53.const_0)
		{
			class2 = class787_0.method_1();
			class3 = class787_0.method_9();
			num = @class.method_14(Enum53.const_0, ChartType_Chart.Bar);
		}
		else
		{
			class2 = class787_0.method_2();
			class3 = class787_0.method_10();
			num = @class.method_14(Enum53.const_1, ChartType_Chart.Bar);
		}
		if (class2.CategoryType == Enum64.const_2)
		{
			return smethod_4(interface42_0, class787_0, class810_0, rectangle_0, float_0, double_0);
		}
		double num2 = (class3.IsLogarithmic ? Struct40.smethod_7(class3.MaxValue) : class3.MaxValue);
		double num3 = (class3.IsLogarithmic ? Struct40.smethod_7(class3.MinValue) : class3.MinValue);
		double_0 = (class3.IsLogarithmic ? Struct40.smethod_7(double_0) : double_0);
		float num4 = (float)class810_0.Overlap / 100f;
		float num5 = (float)class810_0.GapWidth / 100f;
		ArrayList arrayList = new ArrayList();
		int num6 = 0;
		if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
		{
			num6 = int_0 - 1;
			if (num6 == 0)
			{
				num6 = 1;
			}
		}
		else
		{
			num6 = int_0;
		}
		double num7 = (double)rectangle_0.Height / (double)num6;
		float num8 = 0f;
		int num9 = @class.method_19(class810_0, @enum, new ChartType_Chart[1] { chartType_Chart });
		int index = class810_0.Index;
		Class795 class4 = class810_0.method_10();
		for (int i = 0; i < class4.Count; i++)
		{
			Class796 class5 = class4.method_1(i);
			float num10 = (float)num7 / ((float)num - num4 * (float)(num - 1) + num5);
			float num11 = num10 * num4;
			float num12 = num10 * num5;
			num8 = (float)num9 * (num10 - num11);
			float num13 = (float)num7 * (float)i + num12 / 2f + num8;
			if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
			{
				num13 -= (float)(num7 / 2.0);
			}
			num13 = (class2.IsPlotOrderReversed ? ((float)rectangle_0.Y + num13) : ((float)(rectangle_0.Y + rectangle_0.Height) - num13 - num10));
			if (class5 == null || class5.imethod_0())
			{
				continue;
			}
			double yValue = class5.YValue;
			float num14 = (float)(double_0 - yValue) / (float)(num2 - num3) * (float)rectangle_0.Width;
			bool flag = false;
			if (num14 == 0f)
			{
				flag = true;
			}
			Class800 class6 = class810_0.method_4();
			PointF pointF_ = new PointF(float_0, num13 + num10 / 2f);
			double num15 = 0.0;
			double num16 = 0.0;
			float float_ = 0f;
			float float_2 = 0f;
			if (class6 != null)
			{
				switch (class6.Type)
				{
				case Enum69.const_0:
				{
					double num17 = ((class6.MinusValue.Count > i) ? class6.method_2(class6.MinusValue[i]) : 0.0);
					num15 = num17;
					num17 = ((class6.PlusValue.Count > i) ? class6.method_2(class6.PlusValue[i]) : 0.0);
					num16 = num17;
					break;
				}
				case Enum69.const_1:
					num15 = class6.Amount;
					num16 = num15;
					break;
				case Enum69.const_2:
					num15 = class6.Amount * Math.Abs(yValue) / 100.0;
					num16 = num15;
					break;
				}
				float_ = (float)num15 / (float)(num2 - num3) * (float)rectangle_0.Width;
				float_2 = (float)num16 / (float)(num2 - num3) * (float)rectangle_0.Width;
				if (!class3.IsPlotOrderReversed)
				{
					pointF_.X -= num14;
				}
				else
				{
					pointF_.X += num14;
				}
			}
			class6.method_0(pointF_, float_, float_2);
			float num18 = float_0;
			if (class3.IsPlotOrderReversed)
			{
				if (num14 < 0f)
				{
					num14 = 0f - num14;
					num18 -= num14;
				}
			}
			else if (num14 < 0f)
			{
				num14 = 0f - num14;
			}
			else
			{
				num18 -= num14;
			}
			RectangleF rectangleF = new RectangleF(num18, num13, num14 + 1f, num10);
			if (rectangleF.X < (float)rectangle_0.X)
			{
				rectangleF.Width -= (float)rectangle_0.X - rectangleF.X;
				rectangleF.X = rectangle_0.X;
			}
			if (rectangleF.Right > (float)(rectangle_0.Right + 1))
			{
				rectangleF.Width -= rectangleF.Right - (float)rectangle_0.Right;
			}
			if (!(rectangleF.Bottom >= (float)rectangle_0.Y) || !(rectangleF.Y <= (float)rectangle_0.Bottom))
			{
				continue;
			}
			if (rectangleF.Y < (float)rectangle_0.Y)
			{
				rectangleF.Height -= (float)rectangle_0.Y - rectangleF.Y;
				rectangleF.Y = rectangle_0.Y;
			}
			else if (rectangleF.Bottom > (float)rectangle_0.Bottom)
			{
				rectangleF.Height -= rectangleF.Bottom - (float)rectangle_0.Bottom;
			}
			if (rectangleF.Height + 1f >= (num10 - 1f) / 3f)
			{
				if (!flag)
				{
					smethod_1(interface42_0, class5, rectangleF, class787_0.method_14(class810_0.vmethod_7()).GetColor(index), float_0, class3);
				}
				object[] array = new object[4];
				bool flag2 = !(rectangleF.X < float_0) && (yValue != 0.0 || ((!class3.IsPlotOrderReversed) ? true : false));
				array[0] = index;
				array[1] = i;
				array[2] = rectangleF;
				array[3] = flag2;
				arrayList.Add(array);
			}
		}
		return arrayList;
	}

	private static void smethod_1(Interface42 interface42_0, Class796 class796_0, RectangleF rectangleF_0, Color color_0, float float_0, Class789 class789_0)
	{
		if (class796_0.method_3().Formatting != 0 || class796_0.method_4().IsVisible)
		{
			class796_0.method_12(new RectangleF(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height));
		}
		if (rectangleF_0.Height < 10f)
		{
			rectangleF_0.Y = (int)rectangleF_0.Y;
		}
		bool invertIfNegative = class796_0.method_1().method_0().method_7()
			.InvertIfNegative;
		if (!class796_0.method_3().bool_1)
		{
			invertIfNegative = class796_0.method_3().InvertIfNegative;
		}
		bool bool_ = false;
		if ((rectangleF_0.X + 2f < float_0 && invertIfNegative && !class789_0.IsPlotOrderReversed) || (rectangleF_0.Right - 2f > float_0 && invertIfNegative && class789_0.IsPlotOrderReversed))
		{
			bool_ = true;
		}
		if (class796_0.method_3().Formatting != 0)
		{
			using Brush brush_ = Struct18.smethod_2(class796_0.method_3(), rectangleF_0, bool_);
			interface42_0.imethod_37(brush_, rectangleF_0);
		}
		if ((double)rectangleF_0.Width > class796_0.method_4().LineStyle.Width / 2.0)
		{
			rectangleF_0.Width -= (float)class796_0.method_4().LineStyle.Width / 2f;
		}
		if ((double)rectangleF_0.Height > class796_0.method_4().LineStyle.Width / 2.0)
		{
			rectangleF_0.Height -= (float)class796_0.method_4().LineStyle.Width / 2f;
		}
		Struct29.smethod_2(interface42_0, rectangleF_0, class796_0.method_4());
		bool flag = false;
		if (rectangleF_0.Right - 2f < float_0)
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
		graphicsPath.AddLine(rectangleF_0.X + 2f, rectangleF_0.Bottom + 1f, rectangleF_0.Right + 1f, rectangleF_0.Bottom + 1f);
		if (!flag)
		{
			graphicsPath.AddLine(rectangleF_0.Right + (float)num2, rectangleF_0.Bottom + (float)num2, rectangleF_0.Right + (float)num2, rectangleF_0.Y + (float)num);
		}
		interface42_0.imethod_18(pen_, graphicsPath);
	}

	internal static void smethod_2(Interface42 interface42_0, Class787 class787_0, Rectangle rectangle_0, ArrayList arrayList_0)
	{
		if (!Struct40.smethod_19(rectangle_0))
		{
			Class808 @class = class787_0.method_7();
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				object[] array = (object[])arrayList_0[i];
				int int_ = (int)array[0];
				int int_2 = (int)array[1];
				RectangleF rectangleF_ = (RectangleF)array[2];
				bool bool_ = (bool)array[3];
				Class810 class2 = @class.method_9(int_);
				Enum53 @enum = class2.method_21();
				Class789 class789_ = ((@enum != Enum53.const_0) ? class787_0.method_2() : class787_0.method_1());
				smethod_3(interface42_0, class789_, @class, int_, int_2, rectangleF_, bool_, rectangle_0.Width);
			}
		}
	}

	private static void smethod_3(Interface42 interface42_0, Class789 class789_0, Class808 class808_0, int int_0, int int_1, RectangleF rectangleF_0, bool bool_0, int int_2)
	{
		Class798 @class = class808_0.method_9(int_0).method_10().method_1(int_1)
			.method_6();
		SizeF sizeF = Struct26.smethod_0(interface42_0, class789_0, class808_0, int_0, int_1, int_2);
		float num = 0f;
		float num2 = rectangleF_0.Y + (rectangleF_0.Height - sizeF.Height) / 2f;
		Enum74 @enum = @class.vmethod_0();
		if (@enum == Enum74.const_9)
		{
			@enum = Struct26.smethod_12(class808_0[int_0].Type);
		}
		switch (@enum)
		{
		default:
			if (bool_0)
			{
				num = rectangleF_0.X + rectangleF_0.Width;
				num += 5f;
			}
			else
			{
				num = rectangleF_0.X - sizeF.Width;
			}
			break;
		case Enum74.const_1:
			num = rectangleF_0.X + rectangleF_0.Width / 2f - sizeF.Width / 2f;
			break;
		case Enum74.const_2:
			if (bool_0)
			{
				num = rectangleF_0.X;
				num += 5f;
			}
			else
			{
				num = rectangleF_0.X + rectangleF_0.Width - sizeF.Width;
			}
			break;
		case Enum74.const_3:
			if (bool_0)
			{
				num = rectangleF_0.X + rectangleF_0.Width - sizeF.Width;
				num += -1f;
			}
			else
			{
				num = rectangleF_0.X;
				num += 6f;
			}
			break;
		}
		if (class808_0.method_9(int_0).method_24(new ChartType_Chart[1] { ChartType_Chart.Bar }))
		{
			if (bool_0)
			{
				if (num - (float)Struct26.int_0 < rectangleF_0.X)
				{
					num += rectangleF_0.X - (num - (float)Struct26.int_0);
				}
			}
			else
			{
				if (num + (float)Struct26.int_0 + sizeF.Width > rectangleF_0.Right)
				{
					num -= num + (float)Struct26.int_0 + sizeF.Width - rectangleF_0.Right;
				}
				if (@class.vmethod_0() == Enum74.const_9 && rectangleF_0.Width <= 3f)
				{
					num = rectangleF_0.Right;
				}
			}
		}
		@class.method_0().rectangle_1 = new Rectangle(Struct40.smethod_5(num), Struct40.smethod_5(num2), Struct40.smethod_3(sizeF.Width), Struct40.smethod_3(sizeF.Height));
		@class.method_0().method_9();
		Struct26.smethod_1(interface42_0, class789_0, class808_0, int_0, int_1, @class.method_0().rectangle_0);
	}

	private static ArrayList smethod_4(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Rectangle rectangle_0, float float_0, double double_0)
	{
		Enum53 @enum = class810_0.method_21();
		ChartType_Chart chartType_Chart = ChartType_Chart.Bar;
		_ = class787_0.method_7().Count;
		Class808 @class = class787_0.method_7();
		Class789 class2;
		Class789 class3;
		int num;
		ArrayList arrayList;
		if (@enum == Enum53.const_0)
		{
			class2 = class787_0.method_1();
			class3 = class787_0.method_9();
			num = @class.method_14(Enum53.const_0, ChartType_Chart.Bar);
			arrayList = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		}
		else
		{
			class2 = class787_0.method_2();
			class3 = class787_0.method_10();
			num = @class.method_14(Enum53.const_1, ChartType_Chart.Bar);
			arrayList = Class817.smethod_71(class787_0.method_7().method_2(), class787_0.vmethod_0());
		}
		double num2 = (class3.IsLogarithmic ? Struct40.smethod_7(class3.MaxValue) : class3.MaxValue);
		double num3 = (class3.IsLogarithmic ? Struct40.smethod_7(class3.MinValue) : class3.MinValue);
		double_0 = (class3.IsLogarithmic ? Struct40.smethod_7(double_0) : double_0);
		float num4 = (float)class810_0.Overlap / 100f;
		float num5 = (float)class810_0.GapWidth / 100f;
		ArrayList arrayList2 = new ArrayList();
		int count = arrayList.Count;
		Enum87 baseUnitScale = class2.BaseUnitScale;
		int int_ = (int)class2.MinValue;
		int int_2 = (int)class2.MaxValue;
		int num6 = 0;
		if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
		{
			num6 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0());
			if (num6 == 0)
			{
				num6 = 1;
			}
		}
		else
		{
			num6 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0()) + 1;
		}
		double num7 = (double)rectangle_0.Height / (double)num6;
		for (int i = 0; i < count; i++)
		{
			Class796 class4 = class810_0.method_10().method_1(i);
			float num8 = (float)(num7 / (double)((float)num - num4 * (float)(num - 1) + num5));
			float num9 = num8 * num4;
			float num10 = num8 * num5;
			int int_3 = int.Parse(arrayList[i].ToString());
			int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
			int num11 = Struct19.smethod_29(baseUnitScale, int_3, int_, class787_0.vmethod_0());
			float num12 = (float)(num7 * (double)num11);
			if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
			{
				num12 -= (float)(num7 / 2.0);
			}
			float num13 = 0f;
			num13 = ((!class2.IsPlotOrderReversed) ? ((float)(rectangle_0.Y + rectangle_0.Height) - num8 - num12 - num10 / 2f) : ((float)rectangle_0.Y + num12 + num10 / 2f));
			int num14 = @class.method_19(class810_0, @enum, new ChartType_Chart[1] { chartType_Chart });
			int index = class810_0.Index;
			num13 = ((!class2.IsPlotOrderReversed) ? (num13 - (float)num14 * (num8 - num9)) : (num13 + (float)num14 * (num8 - num9)));
			if (class4 == null || class4.imethod_0())
			{
				continue;
			}
			double yValue = class4.YValue;
			float num15 = (float)(double_0 - yValue) / (float)(num2 - num3) * (float)rectangle_0.Width;
			bool flag = false;
			if (num15 == 0f)
			{
				flag = true;
			}
			float num16 = float_0;
			Class800 class5 = class810_0.method_4();
			PointF pointF_ = new PointF(float_0, num13 + num8 / 2f);
			double num17 = 0.0;
			double num18 = 0.0;
			float float_ = 0f;
			float float_2 = 0f;
			if (class5 != null)
			{
				switch (class5.Type)
				{
				case Enum69.const_0:
				{
					double num19 = ((class5.MinusValue.Count > i) ? class5.method_2(class5.MinusValue[i]) : 0.0);
					num17 = num19;
					num19 = ((class5.PlusValue.Count > i) ? class5.method_2(class5.PlusValue[i]) : 0.0);
					num18 = num19;
					break;
				}
				case Enum69.const_1:
					num17 = class5.Amount;
					num18 = num17;
					break;
				case Enum69.const_2:
					num17 = class5.Amount * Math.Abs(yValue) / 100.0;
					num18 = num17;
					break;
				}
				float_ = (float)num17 / (float)(num2 - num3) * (float)rectangle_0.Width;
				float_2 = (float)num18 / (float)(num2 - num3) * (float)rectangle_0.Width;
				if (!class3.IsPlotOrderReversed)
				{
					pointF_.X -= num15;
				}
				else
				{
					pointF_.X += num15;
				}
			}
			class5.method_0(pointF_, float_, float_2);
			if (!class3.IsPlotOrderReversed)
			{
				if (num15 < 0f)
				{
					num15 = 0f - num15;
				}
				else
				{
					num16 -= num15;
				}
			}
			else if (num15 < 0f)
			{
				num15 = 0f - num15;
				num16 -= num15;
			}
			RectangleF rectangleF = new RectangleF(num16, num13, num15 + 1f, num8);
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
			if (rectangleF.Height + 1f >= (num8 - 1f) / 3f)
			{
				if (!flag)
				{
					smethod_1(interface42_0, class4, rectangleF, class787_0.method_14(class810_0.vmethod_7()).GetColor(index), float_0, class3);
				}
				object[] array = new object[4];
				bool flag2 = !(rectangleF.X < float_0) && (yValue != 0.0 || ((!class3.IsPlotOrderReversed) ? true : false));
				array[0] = index;
				array[1] = i;
				array[2] = rectangleF;
				array[3] = flag2;
				arrayList2.Add(array);
			}
		}
		return arrayList2;
	}

	internal static ArrayList smethod_5(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Rectangle rectangle_0, int int_0)
	{
		Enum53 @enum = class810_0.method_21();
		ChartType_Chart chartType_Chart = ChartType_Chart.BarStacked;
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2;
		Class789 class3;
		int num;
		if (@enum == Enum53.const_0)
		{
			class2 = class787_0.method_1();
			class3 = class787_0.method_9();
			num = @class.method_14(Enum53.const_0, chartType_Chart);
		}
		else
		{
			class2 = class787_0.method_2();
			class3 = class787_0.method_10();
			num = @class.method_14(Enum53.const_1, chartType_Chart);
		}
		float num2 = 0f;
		num2 = ((!class3.IsPlotOrderReversed) ? ((float)rectangle_0.Right - (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width) : ((float)rectangle_0.X + (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width));
		if (class2.CategoryType == Enum64.const_2)
		{
			return smethod_7(interface42_0, class787_0, class810_0, rectangle_0, num2);
		}
		_ = class3.MinValue;
		_ = class3.MaxValue;
		float num3 = (float)class810_0.Overlap / 100f;
		float num4 = (float)class810_0.GapWidth / 100f;
		ArrayList arrayList = new ArrayList();
		int num5 = 0;
		if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
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
		float num7 = 0f;
		IList list = @class.method_17(@enum, new ChartType_Chart[1] { chartType_Chart });
		int num8 = @class.method_19(class810_0, @enum, new ChartType_Chart[1] { chartType_Chart });
		if (num8 == -1)
		{
			return arrayList;
		}
		int index = class810_0.Index;
		Class795 class4 = class810_0.method_10();
		ArrayList arrayList_ = new ArrayList();
		for (int i = 0; i < class4.Count; i++)
		{
			Class796 class5 = class4.method_1(i);
			float num9 = (float)num6 / ((float)num - num3 * (float)(num - 1) + num4);
			float num10 = num9 * num3;
			float num11 = num9 * num4;
			num7 = (float)num8 * (num9 - num10);
			float num12 = (float)num6 * (float)i + num11 / 2f + num7;
			if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
			{
				num12 -= (float)(num6 / 2.0);
			}
			num12 = (class2.IsPlotOrderReversed ? ((float)rectangle_0.Y + num12) : ((float)(rectangle_0.Y + rectangle_0.Height) - num12 - num9));
			ArrayList arrayList2 = new ArrayList();
			if (class5 != null)
			{
				double yValue = class5.YValue;
				double num13 = yValue;
				if (yValue >= 0.0)
				{
					for (int j = 0; j < num8; j++)
					{
						Class796 class6 = ((Class810)list[j]).method_10().method_1(i);
						if (class6 != null)
						{
							double yValue2 = class6.YValue;
							if (yValue2 > 0.0)
							{
								num13 += yValue2;
							}
						}
					}
				}
				else
				{
					for (int k = 0; k < num8; k++)
					{
						Class796 class7 = ((Class810)list[k]).method_10().method_1(i);
						if (class7 != null)
						{
							double yValue3 = class7.YValue;
							if (yValue3 <= 0.0)
							{
								num13 += yValue3;
							}
						}
					}
				}
				float num14 = (float)Math.Abs(yValue) / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
				float num15 = (float)Math.Abs(num13) / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
				bool flag = false;
				if (num14 == 0f)
				{
					flag = true;
				}
				Class800 class8 = class810_0.method_4();
				PointF pointF_ = new PointF(num2, num12 + num9 / 2f);
				double num16 = 0.0;
				double num17 = 0.0;
				float float_ = 0f;
				float float_2 = 0f;
				if (class8 != null)
				{
					switch (class8.Type)
					{
					case Enum69.const_0:
					{
						double num18 = ((class8.MinusValue.Count > i) ? class8.method_2(class8.MinusValue[i]) : 0.0);
						num16 = num18;
						num18 = ((class8.PlusValue.Count > i) ? class8.method_2(class8.PlusValue[i]) : 0.0);
						num17 = num18;
						break;
					}
					case Enum69.const_1:
						num16 = class8.Amount;
						num17 = num16;
						break;
					case Enum69.const_2:
						num16 = class8.Amount * Math.Abs(yValue) / 100.0;
						num17 = num16;
						break;
					}
					float_ = (float)num16 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
					float_2 = (float)num17 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
					if (!class3.IsPlotOrderReversed)
					{
						if (yValue <= 0.0)
						{
							pointF_.X -= num15;
						}
						else
						{
							pointF_.X += num15;
						}
					}
					else if (yValue <= 0.0)
					{
						pointF_.X += num15;
					}
					else
					{
						pointF_.X -= num15;
					}
				}
				class8.method_0(pointF_, float_, float_2);
				num15 = ((!class3.IsPlotOrderReversed) ? ((!(yValue >= 0.0)) ? (num2 - num15) : (num2 + num15 - num14)) : ((!(yValue >= 0.0)) ? (num2 + num15 - num14) : (num2 - num15)));
				RectangleF rectangleF = new RectangleF(num15, num12, num14, num9);
				if (rectangleF.X < (float)rectangle_0.X)
				{
					rectangleF.Width -= (float)rectangle_0.X - rectangleF.X;
					rectangleF.X = rectangle_0.X;
				}
				if (rectangleF.Right > (float)(rectangle_0.Right + 1))
				{
					rectangleF.Width -= rectangleF.Right - (float)rectangle_0.Right;
				}
				if (rectangleF.Bottom >= (float)rectangle_0.Y && rectangleF.Y <= (float)rectangle_0.Bottom)
				{
					if (rectangleF.Y < (float)rectangle_0.Y)
					{
						rectangleF.Height -= (float)rectangle_0.Y - rectangleF.Y;
						rectangleF.Y = rectangle_0.Y;
					}
					else if (rectangleF.Bottom > (float)rectangle_0.Bottom)
					{
						rectangleF.Height -= rectangleF.Bottom - (float)rectangle_0.Bottom;
					}
					if (rectangleF.Height + 1f >= (num9 - 1f) / 3f)
					{
						if (!flag)
						{
							smethod_1(interface42_0, class5, rectangleF, class787_0.method_14(class810_0.vmethod_7()).GetColor(index), num2, class3);
						}
						object[] array = new object[4];
						bool flag2 = !(rectangleF.X + rectangleF.Width / 2f < num2) && (yValue != 0.0 || ((!class3.IsPlotOrderReversed) ? true : false));
						array[0] = index;
						array[1] = i;
						array[2] = rectangleF;
						array[3] = flag2;
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
			}
			smethod_6(interface42_0, class810_0, ref arrayList_, arrayList2);
		}
		return arrayList;
	}

	private static void smethod_6(Interface42 interface42_0, Class810 class810_0, ref ArrayList arrayList_0, ArrayList arrayList_1)
	{
		if (arrayList_0.Count > 0 && arrayList_1.Count > 0 && class810_0.HasSeriesLines)
		{
			RectangleF rectangleF = (RectangleF)arrayList_0[0];
			bool flag = (bool)arrayList_0[1];
			RectangleF rectangleF2 = (RectangleF)arrayList_1[0];
			bool flag2 = (bool)arrayList_1[1];
			PointF pointF_;
			PointF pointF_2;
			if (!(rectangleF.Y < rectangleF2.Y))
			{
				pointF_ = ((!flag) ? new PointF(rectangleF.Left, rectangleF.Top) : new PointF(rectangleF.Right, rectangleF.Top));
				pointF_2 = ((!flag2) ? new PointF(rectangleF2.Left, rectangleF2.Bottom) : new PointF(rectangleF2.Right, rectangleF2.Bottom));
			}
			else
			{
				pointF_ = ((!flag) ? new PointF(rectangleF.Left, rectangleF.Bottom) : new PointF(rectangleF.Right, rectangleF.Bottom));
				pointF_2 = ((!flag2) ? new PointF(rectangleF2.Left, rectangleF2.Top) : new PointF(rectangleF2.Right, rectangleF2.Top));
			}
			Struct29.smethod_1(interface42_0, pointF_, pointF_2, class810_0.method_18());
		}
		if (arrayList_1.Count > 0)
		{
			arrayList_0 = arrayList_1;
		}
	}

	private static ArrayList smethod_7(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Rectangle rectangle_0, float float_0)
	{
		Enum53 @enum = class810_0.method_21();
		ChartType_Chart chartType_Chart = ChartType_Chart.BarStacked;
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2;
		Class789 class3;
		int num;
		ArrayList arrayList;
		if (@enum == Enum53.const_0)
		{
			class2 = class787_0.method_1();
			class3 = class787_0.method_9();
			num = @class.method_14(Enum53.const_0, chartType_Chart);
			arrayList = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		}
		else
		{
			class2 = class787_0.method_2();
			class3 = class787_0.method_10();
			num = @class.method_14(Enum53.const_1, chartType_Chart);
			arrayList = Class817.smethod_71(class787_0.method_7().method_2(), class787_0.vmethod_0());
		}
		_ = class3.MinValue;
		_ = class3.MaxValue;
		float num2 = (float)class810_0.Overlap / 100f;
		float num3 = (float)class810_0.GapWidth / 100f;
		ArrayList arrayList2 = new ArrayList();
		int count = arrayList.Count;
		Enum87 baseUnitScale = class2.BaseUnitScale;
		int int_ = (int)class2.MinValue;
		int int_2 = (int)class2.MaxValue;
		int num4 = 0;
		if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
		{
			num4 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0());
			if (num4 == 0)
			{
				num4 = 1;
			}
		}
		else
		{
			num4 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0()) + 1;
		}
		double num5 = (double)rectangle_0.Height / (double)num4;
		ArrayList arrayList_ = new ArrayList();
		int num6 = 0;
		while (true)
		{
			if (num6 < count)
			{
				Class796 class4 = class810_0.method_10().method_1(num6);
				float num7 = (float)(num5 / (double)((float)num - num2 * (float)(num - 1) + num3));
				float num8 = num7 * num2;
				float num9 = num7 * num3;
				int int_3 = int.Parse(arrayList[num6].ToString());
				int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
				int num10 = Struct19.smethod_29(baseUnitScale, int_3, int_, class787_0.vmethod_0());
				float num11 = (float)(num5 * (double)num10);
				if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
				{
					num11 -= (float)(num5 / 2.0);
				}
				float num12 = 0f;
				num12 = ((!class2.IsPlotOrderReversed) ? ((float)(rectangle_0.Y + rectangle_0.Height) - num7 - num11 - num9 / 2f) : ((float)rectangle_0.Y + num11 + num9 / 2f));
				IList list = @class.method_17(@enum, new ChartType_Chart[1] { chartType_Chart });
				int num13 = @class.method_19(class810_0, @enum, new ChartType_Chart[1] { chartType_Chart });
				if (num13 == -1)
				{
					break;
				}
				int index = class810_0.Index;
				num12 = ((!class2.IsPlotOrderReversed) ? (num12 - (float)num13 * (num7 - num8)) : (num12 + (float)num13 * (num7 - num8)));
				ArrayList arrayList3 = new ArrayList();
				if (class4 != null)
				{
					double yValue = class4.YValue;
					double num14 = yValue;
					if (yValue >= 0.0)
					{
						for (int i = 0; i < num13; i++)
						{
							Class796 class5 = ((Class810)list[i]).method_10().method_1(num6);
							if (class5 != null)
							{
								double yValue2 = class5.YValue;
								if (yValue2 > 0.0)
								{
									num14 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int j = 0; j < num13; j++)
						{
							Class796 class6 = ((Class810)list[j]).method_10().method_1(num6);
							if (class6 != null)
							{
								double yValue3 = class6.YValue;
								if (yValue3 <= 0.0)
								{
									num14 += yValue3;
								}
							}
						}
					}
					float num15 = (float)Math.Abs(yValue) / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
					float num16 = (float)Math.Abs(num14) / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
					bool flag = false;
					if (num15 == 0f)
					{
						flag = true;
					}
					Class800 class7 = class810_0.method_4();
					PointF pointF_ = new PointF(float_0, num12 + num7 / 2f);
					double num17 = 0.0;
					double num18 = 0.0;
					float float_ = 0f;
					float float_2 = 0f;
					if (class7 != null)
					{
						switch (class7.Type)
						{
						case Enum69.const_0:
						{
							double num19 = ((class7.MinusValue.Count > num6) ? class7.method_2(class7.MinusValue[num6]) : 0.0);
							num17 = num19;
							num19 = ((class7.PlusValue.Count > num6) ? class7.method_2(class7.PlusValue[num6]) : 0.0);
							num18 = num19;
							break;
						}
						case Enum69.const_1:
							num17 = class7.Amount;
							num18 = num17;
							break;
						case Enum69.const_2:
							num17 = class7.Amount * Math.Abs(yValue) / 100.0;
							num18 = num17;
							break;
						}
						float_ = (float)num17 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
						float_2 = (float)num18 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
						if (!class3.IsPlotOrderReversed)
						{
							if (yValue <= 0.0)
							{
								pointF_.X -= num16;
							}
							else
							{
								pointF_.X += num16;
							}
						}
						else if (yValue <= 0.0)
						{
							pointF_.X += num16;
						}
						else
						{
							pointF_.X -= num16;
						}
					}
					class7.method_0(pointF_, float_, float_2);
					num16 = ((!class3.IsPlotOrderReversed) ? ((!(yValue >= 0.0)) ? (float_0 - num16) : (float_0 + num16 - num15)) : ((!(yValue >= 0.0)) ? (float_0 + num16 - num15) : (float_0 - num16)));
					RectangleF rectangleF = new RectangleF(num16, num12, num15, num7);
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
						if (rectangleF.Height + 1f >= (num7 - 1f) / 3f)
						{
							if (!flag)
							{
								smethod_1(interface42_0, class4, rectangleF, class787_0.method_14(class810_0.vmethod_7()).GetColor(index), float_0, class3);
							}
							object[] array = new object[4];
							bool flag2 = !(rectangleF.X + rectangleF.Width / 2f < float_0) && (yValue != 0.0 || ((!class3.IsPlotOrderReversed) ? true : false));
							array[0] = index;
							array[1] = num6;
							array[2] = rectangleF;
							array[3] = flag2;
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
				smethod_6(interface42_0, class810_0, ref arrayList_, arrayList3);
				num6++;
				continue;
			}
			return arrayList2;
		}
		return arrayList2;
	}

	internal static ArrayList smethod_8(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Rectangle rectangle_0, int int_0)
	{
		Enum53 @enum = class810_0.method_21();
		ChartType_Chart chartType_Chart = ChartType_Chart.Bar100PercentStacked;
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2;
		Class789 class3;
		int num;
		if (@enum == Enum53.const_0)
		{
			class2 = class787_0.method_1();
			class3 = class787_0.method_9();
			num = @class.method_14(Enum53.const_0, chartType_Chart);
		}
		else
		{
			class2 = class787_0.method_2();
			class3 = class787_0.method_10();
			num = @class.method_14(Enum53.const_1, chartType_Chart);
		}
		float num2 = 0f;
		num2 = ((!class3.IsPlotOrderReversed) ? ((float)rectangle_0.Right - (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width) : ((float)rectangle_0.X + (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width));
		if (class2.CategoryType == Enum64.const_2)
		{
			return smethod_9(interface42_0, class787_0, class810_0, rectangle_0, num2);
		}
		_ = class3.MinValue;
		_ = class3.MaxValue;
		float num3 = (float)class810_0.Overlap / 100f;
		float num4 = (float)class810_0.GapWidth / 100f;
		ArrayList arrayList = new ArrayList();
		int num5 = 0;
		if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
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
		float num7 = 0f;
		IList list = @class.method_17(@enum, new ChartType_Chart[1] { chartType_Chart });
		int num8 = @class.method_19(class810_0, @enum, new ChartType_Chart[1] { chartType_Chart });
		if (num8 == -1)
		{
			return arrayList;
		}
		int index = class810_0.Index;
		ArrayList arrayList_ = new ArrayList();
		Class795 class4 = class810_0.method_10();
		for (int i = 0; i < class4.Count; i++)
		{
			Class796 class5 = class4.method_1(i);
			float num9 = (float)num6 / ((float)num - num3 * (float)(num - 1) + num4);
			float num10 = num9 * num3;
			float num11 = num9 * num4;
			num7 = (float)num8 * (num9 - num10);
			float num12 = (float)num6 * (float)i + num11 / 2f + num7;
			if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
			{
				num12 -= (float)(num6 / 2.0);
			}
			num12 = (class2.IsPlotOrderReversed ? ((float)rectangle_0.Y + num12) : ((float)(rectangle_0.Y + rectangle_0.Height) - num12 - num9));
			ArrayList arrayList2 = new ArrayList();
			if (class5 != null)
			{
				double yValue = class5.YValue;
				double num13 = yValue;
				double num14 = 0.0;
				if (yValue >= 0.0)
				{
					for (int j = 0; j < num8; j++)
					{
						Class796 class6 = ((Class810)list[j]).method_10().method_1(i);
						if (class6 != null)
						{
							double yValue2 = class6.YValue;
							if (yValue2 > 0.0)
							{
								num13 += yValue2;
							}
						}
					}
				}
				else
				{
					for (int k = 0; k < num8; k++)
					{
						Class796 class7 = ((Class810)list[k]).method_10().method_1(i);
						if (class7 != null)
						{
							double yValue3 = class7.YValue;
							if (yValue3 <= 0.0)
							{
								num13 += yValue3;
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
						num14 += Math.Abs(yValue4);
					}
				}
				float num15 = 0f;
				float num16 = 0f;
				if (num14 != 0.0)
				{
					num15 = (float)Math.Abs(yValue) * 100f / (float)num14 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
					num16 = (float)Math.Abs(num13) * 100f / (float)num14 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
				}
				bool flag = false;
				if (num15 == 0f)
				{
					flag = true;
				}
				Class800 class9 = class810_0.method_4();
				PointF pointF_ = new PointF(num2, num12 + num9 / 2f);
				double num17 = 0.0;
				double num18 = 0.0;
				float float_ = 0f;
				float float_2 = 0f;
				if (class9 != null)
				{
					switch (class9.Type)
					{
					case Enum69.const_0:
					{
						double num19 = ((class9.MinusValue.Count > i) ? class9.method_2(class9.MinusValue[i]) : 0.0);
						num17 = num19;
						num19 = ((class9.PlusValue.Count > i) ? class9.method_2(class9.PlusValue[i]) : 0.0);
						num18 = num19;
						break;
					}
					case Enum69.const_1:
						num17 = class9.Amount;
						num18 = num17;
						break;
					case Enum69.const_2:
						num17 = class9.Amount * Math.Abs(yValue) / 100.0;
						num18 = num17;
						break;
					}
					num18 = num18 * 100.0 / num14;
					num17 = num17 * 100.0 / num14;
					float_ = (float)num17 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
					float_2 = (float)num18 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
					if (!class3.IsPlotOrderReversed)
					{
						if (yValue <= 0.0)
						{
							pointF_.X -= num16;
						}
						else
						{
							pointF_.X += num16;
						}
					}
					else if (yValue <= 0.0)
					{
						pointF_.X += num16;
					}
					else
					{
						pointF_.X -= num16;
					}
				}
				class9.method_0(pointF_, float_, float_2);
				num16 = ((!class3.IsPlotOrderReversed) ? ((!(yValue >= 0.0)) ? (num2 - num16) : (num2 + num16 - num15)) : ((!(yValue >= 0.0)) ? (num2 + num16 - num15) : (num2 - num16)));
				RectangleF rectangleF = new RectangleF(num16, num12, num15, num9);
				if (rectangleF.X < (float)rectangle_0.X)
				{
					rectangleF.Width -= (float)rectangle_0.X - rectangleF.X;
					rectangleF.X = rectangle_0.X;
				}
				if (rectangleF.Right > (float)(rectangle_0.Right + 1))
				{
					rectangleF.Width -= rectangleF.Right - (float)rectangle_0.Right;
				}
				if (rectangleF.Bottom >= (float)rectangle_0.Y && rectangleF.Y <= (float)rectangle_0.Bottom)
				{
					if (rectangleF.Y < (float)rectangle_0.Y)
					{
						rectangleF.Height -= (float)rectangle_0.Y - rectangleF.Y;
						rectangleF.Y = rectangle_0.Y;
					}
					else if (rectangleF.Bottom > (float)rectangle_0.Bottom)
					{
						rectangleF.Height -= rectangleF.Bottom - (float)rectangle_0.Bottom;
					}
					if (rectangleF.Height + 1f >= (num9 - 1f) / 3f)
					{
						if (!flag)
						{
							smethod_1(interface42_0, class5, rectangleF, class787_0.method_14(class810_0.vmethod_7()).GetColor(index), num2, class3);
						}
						object[] array = new object[4];
						bool flag2 = !(rectangleF.X + rectangleF.Width / 2f < num2) && (yValue != 0.0 || ((!class3.IsPlotOrderReversed) ? true : false));
						array[0] = index;
						array[1] = i;
						array[2] = rectangleF;
						array[3] = flag2;
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
			}
			smethod_6(interface42_0, class810_0, ref arrayList_, arrayList2);
		}
		return arrayList;
	}

	private static ArrayList smethod_9(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Rectangle rectangle_0, float float_0)
	{
		Enum53 @enum = class810_0.method_21();
		ChartType_Chart chartType_Chart = ChartType_Chart.Bar100PercentStacked;
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2;
		Class789 class3;
		int num;
		ArrayList arrayList;
		if (@enum == Enum53.const_0)
		{
			class2 = class787_0.method_1();
			class3 = class787_0.method_9();
			num = @class.method_14(Enum53.const_0, chartType_Chart);
			arrayList = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		}
		else
		{
			class2 = class787_0.method_2();
			class3 = class787_0.method_10();
			num = @class.method_14(Enum53.const_1, chartType_Chart);
			arrayList = Class817.smethod_71(class787_0.method_7().method_2(), class787_0.vmethod_0());
		}
		_ = class3.MinValue;
		_ = class3.MaxValue;
		float num2 = (float)class810_0.Overlap / 100f;
		float num3 = (float)class810_0.GapWidth / 100f;
		ArrayList arrayList2 = new ArrayList();
		int count = arrayList.Count;
		Enum87 baseUnitScale = class2.BaseUnitScale;
		int int_ = (int)class2.MinValue;
		int int_2 = (int)class2.MaxValue;
		int num4 = 0;
		if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
		{
			num4 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0());
			if (num4 == 0)
			{
				num4 = 1;
			}
		}
		else
		{
			num4 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0()) + 1;
		}
		double num5 = (double)rectangle_0.Height / (double)num4;
		ArrayList arrayList_ = new ArrayList();
		int num6 = 0;
		while (true)
		{
			if (num6 < count)
			{
				Class796 class4 = class810_0.method_10().method_1(num6);
				float num7 = (float)(num5 / (double)((float)num - num2 * (float)(num - 1) + num3));
				float num8 = num7 * num2;
				float num9 = num7 * num3;
				int int_3 = int.Parse(arrayList[num6].ToString());
				int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
				int num10 = Struct19.smethod_29(baseUnitScale, int_3, int_, class787_0.vmethod_0());
				float num11 = (float)(num5 * (double)num10);
				if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
				{
					num11 -= (float)(num5 / 2.0);
				}
				float num12 = 0f;
				num12 = ((!class2.IsPlotOrderReversed) ? ((float)(rectangle_0.Y + rectangle_0.Height) - num7 - num11 - num9 / 2f) : ((float)rectangle_0.Y + num11 + num9 / 2f));
				IList list = @class.method_17(@enum, new ChartType_Chart[1] { chartType_Chart });
				int num13 = @class.method_19(class810_0, @enum, new ChartType_Chart[1] { chartType_Chart });
				if (num13 == -1)
				{
					break;
				}
				int index = class810_0.Index;
				num12 = ((!class2.IsPlotOrderReversed) ? (num12 - (float)num13 * (num7 - num8)) : (num12 + (float)num13 * (num7 - num8)));
				ArrayList arrayList3 = new ArrayList();
				if (class4 != null)
				{
					double yValue = class4.YValue;
					double num14 = yValue;
					double num15 = 0.0;
					if (yValue >= 0.0)
					{
						for (int i = 0; i < num13; i++)
						{
							Class796 class5 = ((Class810)list[i]).method_10().method_1(num6);
							if (class5 != null)
							{
								double yValue2 = class5.YValue;
								if (yValue2 > 0.0)
								{
									num14 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int j = 0; j < num13; j++)
						{
							Class796 class6 = ((Class810)list[j]).method_10().method_1(num6);
							if (class6 != null)
							{
								double yValue3 = class6.YValue;
								if (yValue3 <= 0.0)
								{
									num14 += yValue3;
								}
							}
						}
					}
					for (int k = 0; k < list.Count; k++)
					{
						Class796 class7 = ((Class810)list[k]).method_10().method_1(num6);
						if (class7 != null)
						{
							double yValue4 = class7.YValue;
							num15 += Math.Abs(yValue4);
						}
					}
					float num16 = 0f;
					float num17 = 0f;
					if (num15 != 0.0)
					{
						num16 = (float)Math.Abs(yValue) * 100f / (float)num15 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
						num17 = (float)Math.Abs(num14) * 100f / (float)num15 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
					}
					bool flag = false;
					if (num16 == 0f)
					{
						flag = true;
					}
					Class800 class8 = class810_0.method_4();
					PointF pointF_ = new PointF(float_0, num12 + num7 / 2f);
					double num18 = 0.0;
					double num19 = 0.0;
					float float_ = 0f;
					float float_2 = 0f;
					if (class8 != null)
					{
						switch (class8.Type)
						{
						case Enum69.const_0:
						{
							double num20 = ((class8.MinusValue.Count > num6) ? class8.method_2(class8.MinusValue[num6]) : 0.0);
							num18 = num20;
							num20 = ((class8.PlusValue.Count > num6) ? class8.method_2(class8.PlusValue[num6]) : 0.0);
							num19 = num20;
							break;
						}
						case Enum69.const_1:
							num18 = class8.Amount;
							num19 = num18;
							break;
						case Enum69.const_2:
							num18 = class8.Amount * Math.Abs(yValue) / 100.0;
							num19 = num18;
							break;
						}
						num19 = num19 * 100.0 / num15;
						num18 = num18 * 100.0 / num15;
						float_ = (float)num18 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
						float_2 = (float)num19 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Width;
						if (!class3.IsPlotOrderReversed)
						{
							if (yValue <= 0.0)
							{
								pointF_.X -= num17;
							}
							else
							{
								pointF_.X += num17;
							}
						}
						else if (yValue <= 0.0)
						{
							pointF_.X += num17;
						}
						else
						{
							pointF_.X -= num17;
						}
					}
					class8.method_0(pointF_, float_, float_2);
					num17 = ((!class3.IsPlotOrderReversed) ? ((!(yValue >= 0.0)) ? (float_0 - num17) : (float_0 + num17 - num16)) : ((!(yValue >= 0.0)) ? (float_0 + num17 - num16) : (float_0 - num17)));
					RectangleF rectangleF = new RectangleF(num17, num12, num16, num7);
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
						if (rectangleF.Height + 1f >= (num7 - 1f) / 3f)
						{
							if (!flag)
							{
								smethod_1(interface42_0, class4, rectangleF, class787_0.method_14(class810_0.vmethod_7()).GetColor(index), float_0, class3);
							}
							object[] array = new object[4];
							bool flag2 = !(rectangleF.X + rectangleF.Width / 2f < float_0) && (yValue != 0.0 || ((!class3.IsPlotOrderReversed) ? true : false));
							array[0] = index;
							array[1] = num6;
							array[2] = rectangleF;
							array[3] = flag2;
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
				smethod_6(interface42_0, class810_0, ref arrayList_, arrayList3);
				num6++;
				continue;
			}
			return arrayList2;
		}
		return arrayList2;
	}

	internal static void smethod_10(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0, int int_0)
	{
		Class808 @class = class787_0.method_7();
		int count = @class.Count;
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		if (class3.CategoryType == Enum64.const_2)
		{
			smethod_11(interface42_0, class787_0, float_0, double_0);
			return;
		}
		ArrayList arrayList = new ArrayList();
		float num = class787_0.method_13().Height / (float)int_0;
		float num2 = class787_0.method_13().method_3(bool_1: true, int_0, count);
		float float_ = class787_0.method_13().method_4();
		float num3 = num2 * (float)class787_0.GapWidth / 100f;
		for (int i = 0; i < int_0; i++)
		{
			ArrayList arrayList2 = @class.method_16();
			for (int j = 0; j < arrayList2.Count; j++)
			{
				Class810 class4 = (Class810)arrayList2[j];
				int index = class4.Index;
				float num4 = (float)j * num2;
				float num5 = num * (float)i + num3 / 2f + num4;
				num5 = class787_0.method_13().Y - num5;
				Class795 class5 = class4.method_10();
				int num6 = i;
				if (class3.IsPlotOrderReversed)
				{
					num6 = int_0 - 1 - num6;
				}
				Class796 class6 = class5.method_1(num6);
				if (class6 != null && !class6.imethod_0() && !class6.method_10())
				{
					double num7 = class2.method_17(class6.YValue);
					float num8 = (float)(num7 - double_0) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Width;
					if (class2.IsPlotOrderReversed)
					{
						num8 = 0f - num8;
					}
					smethod_20(interface42_0, class6, class787_0, num5, num2, float_, float_0, num8, double.NaN);
					PointF pointF = smethod_17(class787_0, num5, num2, float_, float_0, num8);
					arrayList.Add(new object[3] { index, num6, pointF });
				}
			}
		}
		smethod_19(interface42_0, class787_0, arrayList);
	}

	private static void smethod_11(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0)
	{
		Class808 @class = class787_0.method_7();
		Class816 class2 = class787_0.method_13();
		int count = @class.Count;
		Class789 class3 = class787_0.method_9();
		Class789 class4 = class787_0.method_1();
		ArrayList arrayList = new ArrayList();
		int int_ = (int)class4.MaxValue;
		int int_2 = (int)class4.MinValue;
		Enum87 baseUnitScale = class4.BaseUnitScale;
		int num = Struct19.smethod_29(baseUnitScale, int_, int_2, class787_0.vmethod_0()) + 1;
		float num2 = class2.Height / (float)num;
		float num3 = class787_0.method_13().method_3(bool_1: true, num, count);
		float float_ = class787_0.method_13().method_4();
		float num4 = num3 * (float)class787_0.GapWidth / 100f;
		ArrayList arrayList2 = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		int count2 = arrayList2.Count;
		for (int i = 0; i < count2; i++)
		{
			int int_3 = int.Parse(arrayList2[i].ToString());
			int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
			int num5 = Struct19.smethod_29(baseUnitScale, int_3, (int)class4.MinValue, class787_0.vmethod_0());
			float num6 = num2 * (float)num5;
			float num7 = num6 + num4 / 2f;
			num7 = class787_0.method_13().Y - num7 + num3;
			IList list = @class.method_16();
			for (int j = 0; j < list.Count; j++)
			{
				Class810 class5 = (Class810)list[j];
				int index = class5.Index;
				float num8 = num3;
				num7 -= num8;
				Class795 class6 = class5.method_10();
				int num9 = i;
				if (class4.IsPlotOrderReversed)
				{
					num9 = count2 - 1 - num9;
				}
				Class796 class7 = class6.method_1(num9);
				if (class7 != null && !class7.imethod_0() && !class7.method_10())
				{
					double num10 = class3.method_17(class7.YValue);
					float num11 = (float)(num10 - double_0) / (float)(class3.MaxValue - class3.MinValue) * class787_0.method_13().Width;
					if (class3.IsPlotOrderReversed)
					{
						num11 = 0f - num11;
					}
					smethod_20(interface42_0, class7, class787_0, num7, num3, float_, float_0, num11, double.NaN);
					PointF pointF = smethod_17(class787_0, num7, num3, float_, float_0, num11);
					arrayList.Add(new object[3] { index, num9, pointF });
				}
			}
		}
		smethod_19(interface42_0, class787_0, arrayList);
	}

	internal static void smethod_12(Interface42 interface42_0, Class787 class787_0, double double_0, int int_0)
	{
		Class808 @class = class787_0.method_7();
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		float num = 0f;
		num = ((!class787_0.method_9().IsPlotOrderReversed) ? (class787_0.method_13().X + (float)Math.Abs(class2.MinValue / (double)(float)(class2.MaxValue - class2.MinValue)) * class787_0.method_13().Width) : (class787_0.method_13().X + (float)Math.Abs(class2.MaxValue / (double)(float)(class2.MaxValue - class2.MinValue)) * class787_0.method_13().Width));
		if (class3.CategoryType == Enum64.const_2)
		{
			smethod_13(interface42_0, class787_0, num, double_0);
			return;
		}
		ArrayList arrayList = new ArrayList();
		float num2 = class787_0.method_13().Height / (float)int_0;
		float num3 = class787_0.method_13().method_3(bool_1: true, int_0, 1);
		float float_ = class787_0.method_13().method_4();
		float num4 = num3 * (float)class787_0.GapWidth / 100f;
		for (int i = 0; i < int_0; i++)
		{
			ArrayList arrayList2 = new ArrayList();
			IList list = @class.method_16();
			for (int j = 0; j < list.Count; j++)
			{
				Class810 class4 = (Class810)list[j];
				int index = class4.Index;
				float num5 = num2 * (float)i + num4 / 2f;
				num5 = class787_0.method_13().Y - num5;
				Class795 class5 = class4.method_10();
				int num6 = i;
				if (class3.IsPlotOrderReversed)
				{
					num6 = int_0 - 1 - num6;
				}
				Class796 class6 = class5.method_1(num6);
				int displayOrder = j;
				if (class6 == null || class6.imethod_0() || class6.method_10())
				{
					continue;
				}
				double pointVal = class6.YValue;
				if (Struct40.smethod_14(ref pointVal, out var valTotal, list, displayOrder, num6, class2.MaxValue, class2.MinValue))
				{
					float num7 = (float)pointVal / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Width;
					float num8 = (float)valTotal / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Width;
					float num9;
					if (class2.IsPlotOrderReversed)
					{
						num9 = num - (num8 - num7);
						num7 = 0f - num7;
					}
					else
					{
						num9 = num + (num8 - num7);
					}
					float num10 = num9 + num7;
					if (num9 < class787_0.method_13().X)
					{
						num9 = class787_0.method_13().X;
					}
					if (num9 > class787_0.method_13().X + class787_0.method_13().Width)
					{
						num9 = class787_0.method_13().X + class787_0.method_13().Width;
					}
					if (num10 < class787_0.method_13().X)
					{
						num10 = class787_0.method_13().X;
					}
					if (num10 > class787_0.method_13().X + class787_0.method_13().Width)
					{
						num10 = class787_0.method_13().X + class787_0.method_13().Width;
					}
					num7 = num10 - num9;
					smethod_16(object_0: new object[5] { class6, num5, num9, num7, valTotal }, double_0: pointVal, arrayList_0: arrayList2, class789_0: class2);
					PointF pointF = smethod_18(class787_0, num5, num3, float_, num9, num7);
					arrayList.Add(new object[3] { index, num6, pointF });
				}
			}
			for (int k = 0; k < arrayList2.Count; k++)
			{
				object[] array = (object[])arrayList2[k];
				Class796 class796_ = (Class796)array[0];
				smethod_20(interface42_0, class796_, class787_0, (float)array[1], num3, float_, (float)array[2], (float)array[3], (double)array[4]);
			}
			arrayList2.Clear();
		}
		smethod_19(interface42_0, class787_0, arrayList);
	}

	private static void smethod_13(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0)
	{
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		ArrayList arrayList = new ArrayList();
		int int_ = (int)class3.MaxValue;
		int int_2 = (int)class3.MinValue;
		Enum87 baseUnitScale = class3.BaseUnitScale;
		int num = Struct19.smethod_29(baseUnitScale, int_, int_2, class787_0.vmethod_0()) + 1;
		float num2 = class787_0.method_13().Height / (float)num;
		float num3 = class787_0.method_13().method_3(bool_1: true, num, 1);
		float float_ = class787_0.method_13().method_4();
		float num4 = num3 * (float)class787_0.GapWidth / 100f;
		ArrayList arrayList2 = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		int count = arrayList2.Count;
		for (int i = 0; i < count; i++)
		{
			ArrayList arrayList3 = new ArrayList();
			int int_3 = int.Parse(arrayList2[i].ToString());
			int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
			int num5 = Struct19.smethod_29(baseUnitScale, int_3, (int)class3.MinValue, class787_0.vmethod_0());
			float num6 = num2 * (float)num5;
			float num7 = num6 + num4 / 2f;
			num7 = class787_0.method_13().Y - num7;
			IList list = @class.method_16();
			for (int j = 0; j < list.Count; j++)
			{
				Class810 class4 = (Class810)list[j];
				int index = class4.Index;
				Class795 class5 = class4.method_10();
				int num8 = i;
				if (class3.IsPlotOrderReversed)
				{
					num8 = count - 1 - num8;
				}
				Class796 class6 = class5.method_1(num8);
				int displayOrder = j;
				if (class6 == null || class6.imethod_0() || class6.method_10())
				{
					continue;
				}
				double pointVal = class6.YValue;
				if (Struct40.smethod_14(ref pointVal, out var valTotal, list, displayOrder, num8, class2.MaxValue, class2.MinValue))
				{
					float num9 = (float)pointVal / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Width;
					float num10 = (float)valTotal / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Width;
					float num11;
					if (class2.IsPlotOrderReversed)
					{
						num11 = float_0 - (num10 - num9);
						num9 = 0f - num9;
					}
					else
					{
						num11 = float_0 + (num10 - num9);
					}
					float num12 = num11 + num9;
					if (num11 < class787_0.method_13().X)
					{
						num11 = class787_0.method_13().X;
					}
					if (num11 > class787_0.method_13().X + class787_0.method_13().Width)
					{
						num11 = class787_0.method_13().X + class787_0.method_13().Width;
					}
					if (num12 < class787_0.method_13().X)
					{
						num12 = class787_0.method_13().Y;
					}
					if (num12 > class787_0.method_13().X + class787_0.method_13().Width)
					{
						num12 = class787_0.method_13().X + class787_0.method_13().Width;
					}
					num9 = num12 - num11;
					smethod_16(object_0: new object[5] { class6, num7, num11, num9, valTotal }, double_0: pointVal, arrayList_0: arrayList3, class789_0: class2);
					PointF pointF = smethod_18(class787_0, num7, num3, float_, num11, num9);
					arrayList.Add(new object[3] { index, num8, pointF });
				}
			}
			for (int k = 0; k < arrayList3.Count; k++)
			{
				object[] array = (object[])arrayList3[k];
				Class796 class796_ = (Class796)array[0];
				smethod_20(interface42_0, class796_, class787_0, (float)array[1], num3, float_, (float)array[2], (float)array[3], (double)array[4]);
			}
			arrayList3.Clear();
		}
		smethod_19(interface42_0, class787_0, arrayList);
	}

	internal static void smethod_14(Interface42 interface42_0, Class787 class787_0, double double_0, int int_0)
	{
		Class808 @class = class787_0.method_7();
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		float num = 0f;
		num = ((!class787_0.method_9().IsPlotOrderReversed) ? (class787_0.method_13().X + class787_0.method_13().Width - (float)Math.Abs(class2.MaxValue / (double)(float)(class2.MaxValue - class2.MinValue)) * class787_0.method_13().Width) : (class787_0.method_13().X + (float)Math.Abs(class2.MaxValue / (double)(float)(class2.MaxValue - class2.MinValue)) * class787_0.method_13().Width));
		if (class3.CategoryType == Enum64.const_2)
		{
			smethod_15(interface42_0, class787_0, num, double_0);
			return;
		}
		ArrayList arrayList = new ArrayList();
		float num2 = class787_0.method_13().Height / (float)int_0;
		float num3 = class787_0.method_13().method_3(bool_1: true, int_0, 1);
		float float_ = class787_0.method_13().method_4();
		float num4 = num3 * (float)class787_0.GapWidth / 100f;
		for (int i = 0; i < int_0; i++)
		{
			ArrayList arrayList2 = new ArrayList();
			IList list = @class.method_16();
			for (int j = 0; j < list.Count; j++)
			{
				Class810 class4 = (Class810)list[j];
				int index = class4.Index;
				float num5 = num2 * (float)i + num4 / 2f;
				num5 = class787_0.method_13().Y - num5;
				Class795 class5 = class4.method_10();
				int num6 = i;
				if (class3.IsPlotOrderReversed)
				{
					num6 = int_0 - 1 - num6;
				}
				Class796 class6 = class5.method_1(num6);
				int displayOrder = j;
				if (class6 == null || class6.imethod_0() || class6.method_10())
				{
					continue;
				}
				double num7 = Struct40.smethod_15(list, num6);
				if (num7 == 0.0)
				{
					continue;
				}
				double pointVal = class6.YValue;
				double valTotal = pointVal;
				if (Struct40.smethod_16(ref pointVal, out valTotal, list, displayOrder, num6, class2, num7))
				{
					float num8 = (float)pointVal * 100f / (float)num7 / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Width;
					float num9 = (float)valTotal * 100f / (float)num7 / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Width;
					float num10;
					if (class2.IsPlotOrderReversed)
					{
						num10 = num - (num9 - num8);
						num8 = 0f - num8;
					}
					else
					{
						num10 = num + (num9 - num8);
					}
					float num11 = num10 + num8;
					if (num10 < class787_0.method_13().X)
					{
						num10 = class787_0.method_13().X;
					}
					if (num10 > class787_0.method_13().X + class787_0.method_13().Width)
					{
						num10 = class787_0.method_13().X + class787_0.method_13().Width;
					}
					if (num11 < class787_0.method_13().X)
					{
						num11 = class787_0.method_13().X;
					}
					if (num11 > class787_0.method_13().X + class787_0.method_13().Width)
					{
						num11 = class787_0.method_13().X + class787_0.method_13().Width;
					}
					num8 = num11 - num10;
					smethod_16(object_0: new object[5] { class6, num5, num10, num8, valTotal }, double_0: pointVal, arrayList_0: arrayList2, class789_0: class2);
					PointF pointF = smethod_18(class787_0, num5, num3, float_, num10, num8);
					arrayList.Add(new object[3] { index, num6, pointF });
				}
			}
			for (int k = 0; k < arrayList2.Count; k++)
			{
				object[] array = (object[])arrayList2[k];
				Class796 class796_ = (Class796)array[0];
				smethod_20(interface42_0, class796_, class787_0, (float)array[1], num3, float_, (float)array[2], (float)array[3], (double)array[4]);
			}
			arrayList2.Clear();
		}
		smethod_19(interface42_0, class787_0, arrayList);
	}

	private static void smethod_15(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0)
	{
		Class808 @class = class787_0.method_7();
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		ArrayList arrayList = new ArrayList();
		int int_ = (int)class3.MaxValue;
		int int_2 = (int)class3.MinValue;
		Enum87 baseUnitScale = class3.BaseUnitScale;
		int num = Struct19.smethod_29(baseUnitScale, int_, int_2, class787_0.vmethod_0()) + 1;
		float num2 = class787_0.method_13().Height / (float)num;
		float num3 = class787_0.method_13().method_3(bool_1: true, num, 1);
		float float_ = class787_0.method_13().method_4();
		float num4 = num3 * (float)class787_0.GapWidth / 100f;
		ArrayList arrayList2 = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		int count = arrayList2.Count;
		for (int i = 0; i < count; i++)
		{
			ArrayList arrayList3 = new ArrayList();
			int int_3 = int.Parse(arrayList2[i].ToString());
			int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
			int num5 = Struct19.smethod_29(baseUnitScale, int_3, (int)class3.MinValue, class787_0.vmethod_0());
			float num6 = num2 * (float)num5;
			float num7 = num6 + num4 / 2f;
			num7 = class787_0.method_13().Y - num7;
			IList list = @class.method_16();
			for (int j = 0; j < list.Count; j++)
			{
				Class810 class4 = (Class810)list[j];
				int index = class4.Index;
				Class795 class5 = class4.method_10();
				int num8 = i;
				if (class3.IsPlotOrderReversed)
				{
					num8 = count - 1 - num8;
				}
				Class796 class6 = class5.method_1(num8);
				int displayOrder = j;
				if (class6 == null || class6.imethod_0() || class6.method_10())
				{
					continue;
				}
				double num9 = Struct40.smethod_15(list, num8);
				if (num9 == 0.0)
				{
					continue;
				}
				double pointVal = class6.YValue;
				double valTotal = pointVal;
				if (Struct40.smethod_16(ref pointVal, out valTotal, list, displayOrder, num8, class2, num9))
				{
					float num10 = (float)pointVal * 100f / (float)num9 / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Width;
					float num11 = (float)valTotal * 100f / (float)num9 / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Width;
					float num12;
					if (class2.IsPlotOrderReversed)
					{
						num12 = float_0 - (num11 - num10);
						num10 = 0f - num10;
					}
					else
					{
						num12 = float_0 + (num11 - num10);
					}
					float num13 = num12 + num10;
					if (num12 < class787_0.method_13().X)
					{
						num12 = class787_0.method_13().X;
					}
					if (num12 > class787_0.method_13().X + class787_0.method_13().Width)
					{
						num12 = class787_0.method_13().X + class787_0.method_13().Width;
					}
					if (num13 < class787_0.method_13().X)
					{
						num13 = class787_0.method_13().Y;
					}
					if (num13 > class787_0.method_13().X + class787_0.method_13().Width)
					{
						num13 = class787_0.method_13().X + class787_0.method_13().Width;
					}
					num10 = num13 - num12;
					smethod_16(object_0: new object[5] { class6, num7, num12, num10, valTotal }, double_0: pointVal, arrayList_0: arrayList3, class789_0: class2);
					PointF pointF = smethod_18(class787_0, num7, num3, float_, num12, num10);
					arrayList.Add(new object[3] { index, num8, pointF });
				}
			}
			for (int k = 0; k < arrayList3.Count; k++)
			{
				object[] array = (object[])arrayList3[k];
				Class796 class796_ = (Class796)array[0];
				smethod_20(interface42_0, class796_, class787_0, (float)array[1], num3, float_, (float)array[2], (float)array[3], (double)array[4]);
			}
			arrayList3.Clear();
		}
		smethod_19(interface42_0, class787_0, arrayList);
	}

	private static void smethod_16(double double_0, object[] object_0, ArrayList arrayList_0, Class789 class789_0)
	{
		_ = class789_0.Chart;
		float num = (float)object_0[2] + (float)object_0[3];
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
			float num3 = (float)array[2] + (float)array[3];
			if (num >= num3)
			{
				if (num != num3)
				{
					if (num2 == arrayList_0.Count - 1)
					{
						break;
					}
					num2++;
					continue;
				}
				if (class789_0.IsPlotOrderReversed)
				{
					if (double_0 >= 0.0)
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
			arrayList_0.Insert(num2, object_0);
			return;
		}
		arrayList_0.Add(object_0);
	}

	private static PointF smethod_17(Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4)
	{
		float num = float_3 + float_4;
		float num2 = class787_0.method_13().method_2();
		PointF pointF;
		if (num <= num2)
		{
			float float_5 = 2f * (num2 - num);
			int int_ = ((!(float_3 > num)) ? 3 : 0);
			pointF = Struct25.smethod_47(class787_0, float_0, float_5, float_2, int_);
		}
		else
		{
			int int_ = ((float_3 > num) ? 1 : 2);
			float float_5 = 2f * (num - num2);
			pointF = Struct25.smethod_47(class787_0, float_0, float_5, float_2, int_);
		}
		PointF pointF2 = Struct25.smethod_47(class787_0, float_0, 1f, float_2, 0);
		float num3 = float_2 * (float)Math.Sin((double)class787_0.Elevation * Math.PI / 180.0);
		return new PointF(pointF.X, pointF2.Y - (float_1 + num3) / 2f);
	}

	private static PointF smethod_18(Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4)
	{
		float_3 += float_4 / 2f;
		float num = class787_0.method_13().method_2();
		float float_5;
		if (float_3 <= num)
		{
			float_5 = 2f * (num - float_3);
			return Struct25.smethod_47(class787_0, float_0 - float_1 / 2f, float_5, float_2, 0);
		}
		float_5 = 2f * (float_3 - num);
		return Struct25.smethod_47(class787_0, float_0 - float_1 / 2f, float_5, float_2, 1);
	}

	private static void smethod_19(Interface42 interface42_0, Class787 class787_0, ArrayList arrayList_0)
	{
		Class808 @class = class787_0.method_7();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			object[] array = (object[])arrayList_0[i];
			int num = (int)array[0];
			int int_ = (int)array[1];
			PointF pointF = (PointF)array[2];
			@class.method_9(num).method_3();
			SizeF sizeF = Struct26.smethod_0(interface42_0, class787_0.method_1(), @class, num, int_, (int)class787_0.method_13().Width);
			Struct26.smethod_2(rectangleF_0: new RectangleF(pointF.X - sizeF.Width / 2f, pointF.Y - sizeF.Height / 2f, sizeF.Width, sizeF.Height), interface42_0: interface42_0, class789_0: class787_0.method_1(), class808_0: @class, int_1: num, int_2: int_);
		}
	}

	private static void smethod_20(Interface42 interface42_0, Class796 class796_0, Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4, double double_0)
	{
		Class810 @class = class796_0.method_1().method_0();
		double num = 1.0;
		double num2 = 1.0;
		switch (@class.BarShape)
		{
		case Enum62.const_0:
			smethod_21(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, (float)num, (float)num2);
			break;
		case Enum62.const_1:
			if (!@class.method_30() && !@class.method_32())
			{
				num = 0.0;
			}
			else
			{
				Struct25.smethod_58(@class.NSeries, class796_0.Index, out var totalPositiveYValue4, out var totalMinusYValue4);
				if (class796_0.YValue > 0.0)
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
			smethod_21(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, (float)num, (float)num2);
			break;
		case Enum62.const_2:
			if (@class.method_30())
			{
				Struct25.smethod_59(@class.NSeries, class796_0.Index, out var totalPositiveYValue5, out var totalMinusYValue5);
				if (class796_0.YValue > 0.0)
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
			else if (@class.method_32())
			{
				Struct25.smethod_58(@class.NSeries, class796_0.Index, out var totalPositiveYValue6, out var totalMinusYValue6);
				if (class796_0.YValue > 0.0)
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
			else
			{
				num = (float)Struct25.smethod_57(class796_0);
				num2 = 1.0;
			}
			smethod_21(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, (float)num, (float)num2);
			break;
		case Enum62.const_3:
			smethod_22(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, (float)num, (float)num2);
			break;
		case Enum62.const_4:
			if (!@class.method_30() && !@class.method_32())
			{
				num = 0.0;
			}
			else
			{
				Struct25.smethod_58(@class.NSeries, class796_0.Index, out var totalPositiveYValue3, out var totalMinusYValue3);
				if (class796_0.YValue > 0.0)
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
			smethod_22(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, (float)num, (float)num2);
			break;
		case Enum62.const_5:
			if (@class.method_30())
			{
				Struct25.smethod_59(@class.NSeries, class796_0.Index, out var totalPositiveYValue, out var totalMinusYValue);
				if (class796_0.YValue > 0.0)
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
				Struct25.smethod_58(@class.NSeries, class796_0.Index, out var totalPositiveYValue2, out var totalMinusYValue2);
				if (class796_0.YValue > 0.0)
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
				num = (float)Struct25.smethod_57(class796_0);
				num2 = 1.0;
			}
			smethod_22(interface42_0, class796_0, class787_0, float_0, float_1, float_2, float_3, float_4, (float)num, (float)num2);
			break;
		}
	}

	private static void smethod_21(Interface42 interface42_0, Class796 class796_0, Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6)
	{
		Class788 class788_ = class796_0.method_3();
		PointF[] array = new PointF[8];
		float num = class787_0.method_13().method_2();
		float num2 = float_3;
		int num3 = 3;
		float float_7 = float_2 * float_6;
		float num4 = float_1 * float_6;
		float float_8 = float_0 - float_1 * (1f - float_6) / 2f;
		for (int i = 0; i < 2; i++)
		{
			if (num2 <= num)
			{
				float float_9 = 2f * (num - num2);
				ref PointF reference = ref array[i];
				reference = Struct25.smethod_47(class787_0, float_8, float_9, float_7, 0);
				array[i + 4].X = array[i].X;
				array[i + 4].Y = array[i].Y - num4;
				ref PointF reference2 = ref array[i + num3];
				reference2 = Struct25.smethod_47(class787_0, float_8, float_9, float_7, 3);
				array[i + num3 + 4].X = array[i + num3].X;
				array[i + num3 + 4].Y = array[i + num3].Y - num4;
			}
			else
			{
				float float_9 = 2f * (num2 - num);
				ref PointF reference3 = ref array[i];
				reference3 = Struct25.smethod_47(class787_0, float_8, float_9, float_7, 1);
				array[i + 4].X = array[i].X;
				array[i + 4].Y = array[i].Y - num4;
				ref PointF reference4 = ref array[i + num3];
				reference4 = Struct25.smethod_47(class787_0, float_8, float_9, float_7, 2);
				array[i + num3 + 4].X = array[i + num3].X;
				array[i + num3 + 4].Y = array[i + num3].Y - num4;
			}
			num3 = 1;
			num2 += float_4;
			float_8 = float_0 - float_1 * (1f - float_5) / 2f;
			float_7 = float_2 * float_5;
			num4 = float_1 * float_5;
		}
		using Pen pen_ = Struct29.smethod_5(class796_0.method_4());
		if (float_4 != 0f)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPolygon(new PointF[4]
			{
				array[0],
				array[1],
				array[5],
				array[4]
			});
			using (Brush brush_ = Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath)))
			{
				interface42_0.imethod_33(brush_, graphicsPath);
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPolygon(new PointF[4]
			{
				array[4],
				array[5],
				array[6],
				array[7]
			});
			using (Brush brush_2 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath2), 2f / 3f))
			{
				interface42_0.imethod_33(brush_2, graphicsPath2);
			}
			interface42_0.imethod_18(pen_, graphicsPath);
			interface42_0.imethod_18(pen_, graphicsPath2);
		}
		if (float_4 > 0f)
		{
			GraphicsPath graphicsPath3 = new GraphicsPath();
			graphicsPath3.AddPolygon(new PointF[4]
			{
				array[1],
				array[2],
				array[6],
				array[5]
			});
			using (Brush brush_3 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath3), 0.5f))
			{
				interface42_0.imethod_33(brush_3, graphicsPath3);
			}
			interface42_0.imethod_18(pen_, graphicsPath3);
		}
		else if (float_4 < 0f)
		{
			GraphicsPath graphicsPath4 = new GraphicsPath();
			graphicsPath4.AddPolygon(new PointF[4]
			{
				array[0],
				array[3],
				array[7],
				array[4]
			});
			using (Brush brush_4 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath4), 0f))
			{
				interface42_0.imethod_33(brush_4, graphicsPath4);
			}
			interface42_0.imethod_18(pen_, graphicsPath4);
		}
		else
		{
			GraphicsPath graphicsPath5 = new GraphicsPath();
			graphicsPath5.AddPolygon(new PointF[4]
			{
				array[0],
				array[3],
				array[7],
				array[4]
			});
			using (Brush brush_5 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath5), 0.5f))
			{
				interface42_0.imethod_33(brush_5, graphicsPath5);
			}
			interface42_0.imethod_18(pen_, graphicsPath5);
		}
	}

	private static void smethod_22(Interface42 interface42_0, Class796 class796_0, Class787 class787_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6)
	{
		Class788 class788_ = class796_0.method_3();
		float num = class787_0.method_13().method_2();
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		float num2 = float_0 - float_1 / 2f;
		for (int i = 0; i <= 90; i++)
		{
			double num3 = (double)i * Math.PI / 180.0;
			float float_7 = (float)((double)(float_2 * float_6) * Math.Cos(num3));
			float float_8 = (float)((double)num2 - (double)(float_1 * float_6 / 2f) * Math.Sin(num3));
			float float_9 = (float)((double)num2 + (double)(float_1 * float_6 / 2f) * Math.Sin(num3));
			if (float_3 <= num)
			{
				float float_10 = 2f * (num - float_3);
				if (!hashtable.ContainsKey(180 - i))
				{
					hashtable.Add(180 - i, Struct25.smethod_47(class787_0, float_8, float_10, float_7, 0));
				}
				if (!hashtable.ContainsKey(180 + i))
				{
					hashtable.Add(180 + i, Struct25.smethod_47(class787_0, float_9, float_10, float_7, 0));
				}
				if (!hashtable.ContainsKey(i))
				{
					hashtable.Add(i, Struct25.smethod_47(class787_0, float_8, float_10, float_7, 3));
				}
				if (!hashtable.ContainsKey(360 - i))
				{
					hashtable.Add(360 - i, Struct25.smethod_47(class787_0, float_9, float_10, float_7, 3));
				}
			}
			else
			{
				float float_10 = 2f * (float_3 - num);
				if (!hashtable.ContainsKey(180 - i))
				{
					hashtable.Add(180 - i, Struct25.smethod_47(class787_0, float_8, float_10, float_7, 1));
				}
				if (!hashtable.ContainsKey(180 + i))
				{
					hashtable.Add(180 + i, Struct25.smethod_47(class787_0, float_9, float_10, float_7, 1));
				}
				if (!hashtable.ContainsKey(i))
				{
					hashtable.Add(i, Struct25.smethod_47(class787_0, float_8, float_10, float_7, 2));
				}
				if (!hashtable.ContainsKey(360 - i))
				{
					hashtable.Add(360 - i, Struct25.smethod_47(class787_0, float_9, float_10, float_7, 2));
				}
			}
			float num4 = float_3 + float_4;
			float float_11 = (float)((double)(float_2 * float_5) * Math.Cos(num3));
			float_8 = (float)((double)num2 - (double)(float_1 * float_5 / 2f) * Math.Sin(num3));
			float_9 = (float)((double)num2 + (double)(float_1 * float_5 / 2f) * Math.Sin(num3));
			if (num4 <= num)
			{
				float float_10 = 2f * (num - num4);
				if (!hashtable2.ContainsKey(180 - i))
				{
					hashtable2.Add(180 - i, Struct25.smethod_47(class787_0, float_8, float_10, float_11, 0));
				}
				if (!hashtable2.ContainsKey(180 + i))
				{
					hashtable2.Add(180 + i, Struct25.smethod_47(class787_0, float_9, float_10, float_11, 0));
				}
				if (!hashtable2.ContainsKey(i))
				{
					hashtable2.Add(i, Struct25.smethod_47(class787_0, float_8, float_10, float_11, 3));
				}
				if (!hashtable2.ContainsKey(360 - i))
				{
					hashtable2.Add(360 - i, Struct25.smethod_47(class787_0, float_9, float_10, float_11, 3));
				}
			}
			else
			{
				float float_10 = 2f * (num4 - num);
				if (!hashtable2.ContainsKey(180 - i))
				{
					hashtable2.Add(180 - i, Struct25.smethod_47(class787_0, float_8, float_10, float_11, 1));
				}
				if (!hashtable2.ContainsKey(180 + i))
				{
					hashtable2.Add(180 + i, Struct25.smethod_47(class787_0, float_9, float_10, float_11, 1));
				}
				if (!hashtable2.ContainsKey(i))
				{
					hashtable2.Add(i, Struct25.smethod_47(class787_0, float_8, float_10, float_11, 2));
				}
				if (!hashtable2.ContainsKey(360 - i))
				{
					hashtable2.Add(360 - i, Struct25.smethod_47(class787_0, float_9, float_10, float_11, 2));
				}
			}
		}
		smethod_23(hashtable, out var max, out var min, out var maxAngle, out var minAngle);
		smethod_23(hashtable2, out var max2, out var min2, out var _, out var _);
		if (float_4 != 0f)
		{
			int num5 = 90;
			int num6 = 270;
			float num7 = 0.5f;
			int elevation = class787_0.Elevation;
			float num8 = 7.5f;
			float num9;
			for (num9 = 90 - elevation; num9 <= (float)(num6 - elevation); num9 += num8)
			{
				int num10 = (int)(num9 % 360f);
				PointF pointF = (PointF)hashtable[num10];
				PointF pointF2 = (PointF)hashtable2[num10];
				if (num9 == (float)(num5 - elevation))
				{
					pointF = min;
					pointF2 = min2;
				}
				float num11 = num8;
				if ((num9 - (float)num5 == 30f && elevation <= 30) || num9 - (float)num5 == 75f || (num9 - (float)num5 == 120f && elevation > 30))
				{
					num11 = 2f * num8;
				}
				if (num9 == (float)(num5 - elevation) && (float)elevation % num8 != 0f)
				{
					num11 = (float)elevation % num8;
				}
				int num12 = ((num9 + num11 > (float)(num6 - elevation)) ? ((num6 - elevation) % 360) : ((int)((num9 + num11) % 360f)));
				PointF pointF3 = (PointF)hashtable[num12];
				PointF pointF4 = (PointF)hashtable2[num12];
				if (num9 + num11 >= (float)(num6 - elevation))
				{
					pointF3 = max;
					pointF4 = max2;
				}
				GraphicsPath graphicsPath = new GraphicsPath();
				PointF[] array = new PointF[(int)num11 + 1];
				int num13 = 0;
				for (int j = (int)num9; j <= (int)num9 + (int)num11; j++)
				{
					ref PointF reference = ref array[num13];
					reference = (PointF)hashtable[j % 360];
					num13++;
				}
				graphicsPath.AddLine(pointF, pointF3);
				graphicsPath.AddLine(pointF3, pointF4);
				PointF[] array2 = new PointF[(int)num11 + 1];
				num13 = 0;
				for (int num14 = (int)num9 + (int)num11; num14 >= (int)num9; num14--)
				{
					ref PointF reference2 = ref array2[num13];
					reference2 = (PointF)hashtable2[num14 % 360];
					num13++;
				}
				graphicsPath.AddLine(pointF4, pointF2);
				graphicsPath.AddLine(pointF2, pointF);
				num7 = ((elevation >= 0 && elevation <= 30) ? ((!(num9 - (float)num5 <= 30f)) ? (1.0833334f - 0.5f * ((num9 - (float)num5) / 180f)) : (11f / 12f + 0.5f * ((num9 - (float)num5) / 180f))) : ((!(num9 - (float)num5 <= 120f)) ? (1.3333334f - 0.5f * ((num9 - (float)num5) / 180f)) : (2f / 3f + 0.5f * ((num9 - (float)num5) / 180f))));
				if (num7 == 1f)
				{
					num7 -= 1f / 90f;
				}
				using (Brush brush_ = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath), num7))
				{
					interface42_0.imethod_33(brush_, graphicsPath);
				}
				num9 += num11 - num8;
			}
		}
		using Pen pen_ = Struct29.smethod_5(class796_0.method_4());
		PointF[] array3 = new PointF[hashtable.Count];
		PointF[] array4 = new PointF[hashtable2.Count];
		for (int k = 0; k <= 360; k++)
		{
			ref PointF reference3 = ref array3[k];
			reference3 = (PointF)hashtable[k];
			ref PointF reference4 = ref array4[k];
			reference4 = (PointF)hashtable2[k];
		}
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath2.AddCurve(array3);
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath3.AddCurve(array4);
		if (class787_0.Rotation != 0)
		{
			if (float_4 > 0f)
			{
				using (Brush brush_2 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath3), 0.7f))
				{
					interface42_0.imethod_33(brush_2, graphicsPath3);
				}
				interface42_0.imethod_18(pen_, graphicsPath3);
				Struct25.smethod_65(interface42_0, maxAngle, minAngle, hashtable, pen_);
			}
			else if (float_4 < 0f)
			{
				using (Brush brush_3 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath3), 0f))
				{
					interface42_0.imethod_33(brush_3, graphicsPath2);
				}
				interface42_0.imethod_18(pen_, graphicsPath2);
				Struct25.smethod_65(interface42_0, maxAngle, minAngle, hashtable2, pen_);
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
		else
		{
			interface42_0.imethod_16(pen_, min.X, min.Y, max.X, max.Y);
			interface42_0.imethod_16(pen_, min2.X, min2.Y, max2.X, max2.Y);
		}
		if (float_4 != 0f)
		{
			interface42_0.imethod_16(pen_, min.X, min.Y, min2.X, min2.Y);
			interface42_0.imethod_16(pen_, max.X, max.Y, max2.X, max2.Y);
		}
	}

	private static void smethod_23(Hashtable htPoint, out PointF max, out PointF min, out int maxAngle, out int minAngle)
	{
		max = PointF.Empty;
		min = PointF.Empty;
		maxAngle = 0;
		minAngle = 0;
		IDictionaryEnumerator enumerator = htPoint.GetEnumerator();
		while (enumerator.MoveNext())
		{
			PointF pointF = (PointF)enumerator.Value;
			if (max == PointF.Empty || pointF.Y > max.Y)
			{
				max = pointF;
				maxAngle = (int)enumerator.Key;
			}
			if (min == PointF.Empty || pointF.Y < min.Y)
			{
				min = pointF;
				minAngle = (int)enumerator.Key;
			}
		}
	}
}
