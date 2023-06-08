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
internal struct Struct17
{
	internal static ArrayList smethod_0(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Rectangle rectangle_0, float float_0, double double_0, int int_0)
	{
		ArrayList arrayList = new ArrayList();
		if (int_0 < 2)
		{
			return arrayList;
		}
		Enum53 @enum = class810_0.method_21();
		Class789 @class;
		Class789 class2;
		if (@enum == Enum53.const_0)
		{
			@class = class787_0.method_1();
			class2 = class787_0.method_9();
		}
		else
		{
			@class = class787_0.method_2();
			class2 = class787_0.method_10();
		}
		if (@class.CategoryType == Enum64.const_2)
		{
			return smethod_1(interface42_0, class787_0, class810_0, rectangle_0, float_0, (float)double_0);
		}
		Class808 class3 = class787_0.method_7();
		_ = class3.Count;
		double num = (class2.IsLogarithmic ? Struct40.smethod_7(class2.MaxValue) : class2.MaxValue);
		double num2 = (class2.IsLogarithmic ? Struct40.smethod_7(class2.MinValue) : class2.MinValue);
		double_0 = (class2.IsLogarithmic ? Struct40.smethod_7(double_0) : double_0);
		bool hasDropLines = class810_0.HasDropLines;
		Class806 class806_ = class810_0.method_13();
		int num3 = 0;
		int num4 = int_0;
		if (@class.bool_12)
		{
			num4 = (int)@class.MaxValue;
		}
		if (!@class.AxisBetweenCategories && !class787_0.IsDataTableShown)
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
		_ = class810_0.Index;
		ArrayList ilist_ = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		Class795 class4 = class810_0.method_10();
		int num6 = -1;
		int num7 = 1;
		for (int i = 0; i < num4; i++)
		{
			Class796 class5 = class4.method_1(i);
			double num8 = (float)num5 * (float)i;
			if (@class.AxisBetweenCategories || class787_0.IsDataTableShown)
			{
				num8 += (double)(float)(num5 / 2.0);
			}
			num8 = ((!@class.IsPlotOrderReversed) ? ((double)rectangle_0.X + num8) : ((double)(rectangle_0.X + rectangle_0.Width) - num8));
			if (class5 != null && !class5.imethod_0())
			{
				if (class5.YValue > 0.0 && num6 != 1)
				{
					num6 = 1;
				}
				else if (class5.YValue < 0.0 && num7 != -1)
				{
					num7 = -1;
				}
				double num9 = float_0;
				double yValue = class5.YValue;
				double num10 = (yValue - double_0) / (num - num2) * (double)rectangle_0.Height;
				num9 = (class2.IsPlotOrderReversed ? (num9 + num10) : (num9 - num10));
				PointF pointF_ = new PointF((float)num8, (float)num9);
				if (!class810_0.method_6().IsVisible && i == num4 - 1 && (float)rectangle_0.Right - pointF_.X <= 1f)
				{
					pointF_.X += 1f;
				}
				smethod_6(pointF_, ilist_);
				Class800 class6 = class810_0.method_4();
				double num11 = 0.0;
				double num12 = 0.0;
				float float_ = 0f;
				float float_2 = 0f;
				if (class6 != null)
				{
					switch (class6.Type)
					{
					case Enum69.const_0:
					{
						double num13 = ((class6.MinusValue.Count > i) ? class6.method_2(class6.MinusValue[i]) : 0.0);
						num11 = num13;
						num13 = ((class6.PlusValue.Count > i) ? class6.method_2(class6.PlusValue[i]) : 0.0);
						num12 = num13;
						break;
					}
					case Enum69.const_1:
						num11 = class6.Amount;
						num12 = num11;
						break;
					case Enum69.const_2:
						num11 = class6.Amount * Math.Abs(yValue) / 100.0;
						num12 = num11;
						break;
					}
					float_ = (float)num11 / (float)(num - num2) * (float)rectangle_0.Height;
					float_2 = (float)num12 / (float)(num - num2) * (float)rectangle_0.Height;
				}
				class6.method_0(pointF_, float_, float_2);
			}
			else if (class5 == null)
			{
				arrayList2.Add(i);
			}
			else
			{
				PointF pointF_2 = new PointF((float)num8, float_0);
				smethod_6(pointF_2, ilist_);
			}
		}
		int int_ = 0;
		if (num6 > 0 && num7 > 0)
		{
			int_ = 1;
		}
		else if (num6 < 0 && num7 < 0)
		{
			int_ = 2;
		}
		else if (num6 > 0 && num7 < 0)
		{
			int_ = 3;
		}
		smethod_8(interface42_0, class810_0, ilist_, arrayList2, float_0, hasDropLines, class806_, arrayList, @class, rectangle_0, int_);
		return arrayList;
	}

	private static ArrayList smethod_1(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Rectangle rectangle_0, float float_0, float float_1)
	{
		ArrayList arrayList = new ArrayList();
		Enum53 @enum = class810_0.method_21();
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2;
		Class789 class3;
		ArrayList arrayList2;
		if (@enum == Enum53.const_0)
		{
			class2 = class787_0.method_1();
			class3 = class787_0.method_9();
			arrayList2 = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		}
		else
		{
			class2 = class787_0.method_2();
			class3 = class787_0.method_10();
			arrayList2 = Class817.smethod_71(class787_0.method_7().method_2(), class787_0.vmethod_0());
		}
		double minValue = class3.MinValue;
		double maxValue = class3.MaxValue;
		bool hasDropLines = class810_0.HasDropLines;
		Class806 class806_ = class810_0.method_13();
		int count = arrayList2.Count;
		Enum87 baseUnitScale = class2.BaseUnitScale;
		int int_ = (int)class2.MinValue;
		int int_2 = (int)class2.MaxValue;
		int num = 0;
		if (!class2.AxisBetweenCategories && !class787_0.IsDataTableShown)
		{
			num = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0());
			if (num == 0)
			{
				num = 1;
			}
		}
		else
		{
			num = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0()) + 1;
		}
		double num2 = (double)rectangle_0.Width / (double)num;
		_ = class810_0.Index;
		ArrayList ilist_ = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < count; i++)
		{
			Class796 class4 = class810_0.method_10().method_1(i);
			int int_3 = int.Parse(arrayList2[i].ToString());
			int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
			int num3 = Struct19.smethod_29(baseUnitScale, int_3, int_, class787_0.vmethod_0());
			float num4 = (float)(num2 * (double)num3);
			Struct19.smethod_29(baseUnitScale, Struct19.smethod_31(class2.BaseUnitScale, class2.MajorUnitScale, (int)class2.MajorUnit, int_3, class787_0.vmethod_0()), int_3, class787_0.vmethod_0());
			if (class2.AxisBetweenCategories || class787_0.IsDataTableShown)
			{
				num4 += (float)(num2 / 2.0);
			}
			float num5 = 0f;
			num5 = ((!class2.IsPlotOrderReversed) ? ((float)rectangle_0.X + num4) : ((float)(rectangle_0.X + rectangle_0.Width) - num4));
			if (class4 != null && !class4.imethod_0())
			{
				float num6 = float_0;
				float num7 = (float)class4.YValue;
				float num8 = (num7 - float_1) / (float)(maxValue - minValue) * (float)rectangle_0.Height;
				num6 = (class3.IsPlotOrderReversed ? (num6 + num8) : (num6 - num8));
				PointF pointF_ = new PointF(num5, num6);
				smethod_6(pointF_, ilist_);
				Class800 class5 = class810_0.method_4();
				double num9 = 0.0;
				double num10 = 0.0;
				float float_2 = 0f;
				float float_3 = 0f;
				if (class5 != null)
				{
					switch (class5.Type)
					{
					case Enum69.const_0:
					{
						double num11 = ((class5.MinusValue.Count > i) ? class5.method_2(class5.MinusValue[i]) : 0.0);
						num9 = num11;
						num11 = ((class5.PlusValue.Count > i) ? class5.method_2(class5.PlusValue[i]) : 0.0);
						num10 = num11;
						break;
					}
					case Enum69.const_1:
						num9 = class5.Amount;
						num10 = num9;
						break;
					case Enum69.const_2:
						num9 = class5.Amount * (double)Math.Abs(num7) / 100.0;
						num10 = num9;
						break;
					}
					float_2 = (float)num9 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
					float_3 = (float)num10 / (float)(class3.MaxValue - class3.MinValue) * (float)rectangle_0.Height;
				}
				class5.method_0(pointF_, float_2, float_3);
			}
			else if (class4 == null)
			{
				arrayList3.Add(i);
			}
			else
			{
				PointF pointF_2 = new PointF(num5, float_0);
				smethod_6(pointF_2, ilist_);
			}
		}
		smethod_8(interface42_0, class810_0, ilist_, arrayList3, float_0, hasDropLines, class806_, arrayList, class2, rectangle_0, 1);
		return arrayList;
	}

	internal static ArrayList smethod_2(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Rectangle rectangle_0, float float_0, int int_0)
	{
		ArrayList arrayList = new ArrayList();
		if (int_0 < 2)
		{
			return arrayList;
		}
		Enum53 @enum = class810_0.method_21();
		ChartType_Chart chartType_Chart = ChartType_Chart.AreaStacked;
		Class789 @class;
		Class789 class2;
		if (@enum == Enum53.const_0)
		{
			@class = class787_0.method_1();
			class2 = class787_0.method_9();
		}
		else
		{
			@class = class787_0.method_2();
			class2 = class787_0.method_10();
		}
		if (@class.CategoryType == Enum64.const_2)
		{
			return smethod_3(interface42_0, class787_0, class810_0, rectangle_0, float_0, @enum);
		}
		float num = 0f;
		num = (class2.IsPlotOrderReversed ? ((float)rectangle_0.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height) : ((float)rectangle_0.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height));
		Class808 class3 = class787_0.method_7();
		_ = class3.Count;
		_ = class2.MinValue;
		_ = class2.MaxValue;
		bool hasDropLines = class810_0.HasDropLines;
		Class806 class806_ = class810_0.method_13();
		int num2 = 0;
		int num3 = int_0;
		if (@class.bool_12)
		{
			num3 = (int)@class.MaxValue;
		}
		if (!@class.AxisBetweenCategories && !class787_0.IsDataTableShown)
		{
			num2 = num3 - 1;
			if (num2 == 0)
			{
				num2 = 1;
			}
		}
		else
		{
			num2 = num3;
		}
		double num4 = (double)rectangle_0.Width / (double)num2;
		ArrayList arrayList2 = new ArrayList();
		IList list = class3.method_17(@enum, new ChartType_Chart[1] { chartType_Chart });
		ArrayList arrayList3 = new ArrayList();
		int num5 = class3.method_19(class810_0, @enum, new ChartType_Chart[1] { chartType_Chart });
		Class810 class4 = null;
		if (num5 > 0)
		{
			class4 = class3.method_18(num5 - 1, @enum, new ChartType_Chart[1] { chartType_Chart });
		}
		if (class4 != null)
		{
			arrayList3.Add(class4);
		}
		arrayList3.Add(class810_0);
		for (int i = 0; i < arrayList3.Count; i++)
		{
			Class810 class5 = (Class810)arrayList3[i];
			int num6 = class3.method_19(class5, @enum, new ChartType_Chart[1] { chartType_Chart });
			int index = class5.Index;
			ArrayList arrayList4 = new ArrayList();
			Class795 class6 = class3.method_9(index).method_10();
			for (int j = 0; j < int_0; j++)
			{
				Class796 class7 = class6.method_1(j);
				double num7 = (float)num4 * (float)j + 1f;
				if (@class.AxisBetweenCategories || class787_0.IsDataTableShown)
				{
					num7 += (double)(float)(num4 / 2.0);
				}
				num7 = ((!@class.IsPlotOrderReversed) ? ((double)rectangle_0.X + num7) : ((double)(rectangle_0.X + rectangle_0.Width) - num7));
				if (class7 != null && !class7.imethod_0())
				{
					double yValue = class7.YValue;
					double num8 = yValue;
					for (int k = 0; k < num6; k++)
					{
						Class796 class8 = ((Class810)list[k]).method_10().method_1(j);
						if (class8 != null)
						{
							double yValue2 = class8.YValue;
							num8 += yValue2;
						}
					}
					float num9 = (float)Math.Abs(num8) / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height;
					num9 = ((!class2.IsPlotOrderReversed) ? ((!(num8 <= 0.0)) ? (num - num9) : (num + num9)) : ((!(num8 <= 0.0)) ? (num + num9) : (num - num9)));
					PointF pointF_ = new PointF((float)num7, num9);
					smethod_6(pointF_, arrayList4);
					if (!class5.Equals(class810_0))
					{
						continue;
					}
					Class800 class9 = class810_0.method_4();
					double num10 = 0.0;
					double num11 = 0.0;
					float float_ = 0f;
					float float_2 = 0f;
					if (class9 != null)
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
					}
					class9.method_0(pointF_, float_, float_2);
					continue;
				}
				PointF pointF_2 = new PointF((float)num7, float_0);
				int num13 = i;
				while (num13 > 0)
				{
					if (((ArrayList)arrayList2[num13 - 1])[j] == null)
					{
						num13--;
						continue;
					}
					pointF_2 = (PointF)((ArrayList)arrayList2[num13 - 1])[j];
					break;
				}
				if (i == 0)
				{
					pointF_2 = new PointF((float)num7, float_0);
				}
				smethod_6(pointF_2, arrayList4);
			}
			arrayList2.Add(arrayList4);
		}
		smethod_10(interface42_0, arrayList3, arrayList2, float_0, hasDropLines, class806_, arrayList, @class, rectangle_0);
		return arrayList;
	}

	private static ArrayList smethod_3(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Rectangle rectangle_0, float float_0, Enum53 enum53_0)
	{
		ArrayList arrayList = new ArrayList();
		ChartType_Chart chartType_Chart = ChartType_Chart.AreaStacked;
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class810 class2 = class787_0.method_7().method_13(enum53_0, ChartType_Chart.AreaStacked);
		if (class2 == null)
		{
			return arrayList;
		}
		Class789 class3;
		Class789 class4;
		ArrayList arrayList2;
		if (enum53_0 == Enum53.const_0)
		{
			class3 = class787_0.method_1();
			class4 = class787_0.method_9();
			arrayList2 = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		}
		else
		{
			class3 = class787_0.method_2();
			class4 = class787_0.method_10();
			arrayList2 = Class817.smethod_71(class787_0.method_7().method_2(), class787_0.vmethod_0());
		}
		float num = 0f;
		num = (class4.IsPlotOrderReversed ? ((float)rectangle_0.Bottom - (float)class4.MaxValue / (float)(class4.MaxValue - class4.MinValue) * (float)rectangle_0.Height) : ((float)rectangle_0.Y + (float)class4.MaxValue / (float)(class4.MaxValue - class4.MinValue) * (float)rectangle_0.Height));
		_ = class4.MinValue;
		_ = class4.MaxValue;
		bool hasDropLines = class2.HasDropLines;
		Class806 class806_ = class2.method_13();
		int count = arrayList2.Count;
		Enum87 baseUnitScale = class3.BaseUnitScale;
		int int_ = (int)class3.MinValue;
		int int_2 = (int)class3.MaxValue;
		int num2 = 0;
		if (!class3.AxisBetweenCategories && !class787_0.IsDataTableShown)
		{
			num2 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0());
			if (num2 == 0)
			{
				num2 = 1;
			}
		}
		else
		{
			num2 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0()) + 1;
		}
		double num3 = (double)rectangle_0.Width / (double)num2;
		ArrayList arrayList3 = new ArrayList();
		IList list = @class.method_17(enum53_0, new ChartType_Chart[1] { chartType_Chart });
		ArrayList arrayList4 = new ArrayList();
		int num4 = @class.method_19(class810_0, enum53_0, new ChartType_Chart[1] { chartType_Chart });
		Class810 class5 = null;
		if (num4 > 0)
		{
			class5 = @class.method_18(num4 - 1, enum53_0, new ChartType_Chart[1] { chartType_Chart });
		}
		if (class5 != null)
		{
			arrayList4.Add(class5);
		}
		arrayList4.Add(class810_0);
		for (int i = 0; i < arrayList4.Count; i++)
		{
			Class810 class6 = (Class810)arrayList4[i];
			int num5 = @class.method_19(class6, enum53_0, new ChartType_Chart[1] { chartType_Chart });
			int index = class6.Index;
			ArrayList arrayList5 = new ArrayList();
			for (int j = 0; j < count; j++)
			{
				Class796 class7 = @class.method_9(index).method_10().method_1(j);
				int int_3 = int.Parse(arrayList2[j].ToString());
				int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
				int num6 = Struct19.smethod_29(baseUnitScale, int_3, int_, class787_0.vmethod_0());
				float num7 = (float)(num3 * (double)num6);
				Struct19.smethod_29(baseUnitScale, Struct19.smethod_31(class3.BaseUnitScale, class3.MajorUnitScale, (int)class3.MajorUnit, int_3, class787_0.vmethod_0()), int_3, class787_0.vmethod_0());
				if (class3.AxisBetweenCategories || class787_0.IsDataTableShown)
				{
					num7 += (float)(num3 / 2.0);
				}
				float num8 = 0f;
				num8 = ((!class3.IsPlotOrderReversed) ? ((float)rectangle_0.X + num7) : ((float)(rectangle_0.X + rectangle_0.Width) - num7));
				if (class7 != null && !class7.imethod_0())
				{
					double yValue = class7.YValue;
					double num9 = yValue;
					for (int k = 0; k < num5; k++)
					{
						Class796 class8 = ((Class810)list[k]).method_10().method_1(j);
						if (class8 != null)
						{
							double yValue2 = class8.YValue;
							num9 += yValue2;
						}
					}
					float num10 = (float)Math.Abs(num9) / (float)(class4.MaxValue - class4.MinValue) * (float)rectangle_0.Height;
					num10 = ((!class4.IsPlotOrderReversed) ? ((!(num9 <= 0.0)) ? (num - num10) : (num + num10)) : ((!(num9 <= 0.0)) ? (num + num10) : (num - num10)));
					PointF pointF_ = new PointF(num8, num10);
					smethod_6(pointF_, arrayList5);
					if (!class6.Equals(class810_0))
					{
						continue;
					}
					Class800 class9 = class810_0.method_4();
					double num11 = 0.0;
					double num12 = 0.0;
					float float_ = 0f;
					float float_2 = 0f;
					if (class9 != null)
					{
						switch (class9.Type)
						{
						case Enum69.const_0:
						{
							double num13 = ((class9.MinusValue.Count > j) ? class9.method_2(class9.MinusValue[j]) : 0.0);
							num11 = num13;
							num13 = ((class9.PlusValue.Count > j) ? class9.method_2(class9.PlusValue[j]) : 0.0);
							num12 = num13;
							break;
						}
						case Enum69.const_1:
							num11 = class9.Amount;
							num12 = num11;
							break;
						case Enum69.const_2:
							num11 = class9.Amount * Math.Abs(yValue) / 100.0;
							num12 = num11;
							break;
						}
						float_ = (float)num11 / (float)(class4.MaxValue - class4.MinValue) * (float)rectangle_0.Height;
						float_2 = (float)num12 / (float)(class4.MaxValue - class4.MinValue) * (float)rectangle_0.Height;
					}
					class9.method_0(pointF_, float_, float_2);
					continue;
				}
				PointF pointF_2 = new PointF(num8, float_0);
				int num14 = i;
				while (num14 > 0)
				{
					if (((ArrayList)arrayList3[num14 - 1])[j] == null)
					{
						num14--;
						continue;
					}
					pointF_2 = (PointF)((ArrayList)arrayList3[num14 - 1])[j];
					break;
				}
				if (i == 0)
				{
					pointF_2 = new PointF(num8, float_0);
				}
				smethod_6(pointF_2, arrayList5);
			}
			arrayList3.Add(arrayList5);
		}
		smethod_10(interface42_0, arrayList4, arrayList3, float_0, hasDropLines, class806_, arrayList, class3, rectangle_0);
		return arrayList;
	}

	internal static ArrayList smethod_4(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Rectangle rectangle_0, float float_0, int int_0)
	{
		ArrayList arrayList = new ArrayList();
		if (int_0 < 2)
		{
			return arrayList;
		}
		Enum53 @enum = class810_0.method_21();
		ChartType_Chart chartType_Chart = ChartType_Chart.Area100PercentStacked;
		Class789 @class;
		Class789 class2;
		if (@enum == Enum53.const_0)
		{
			@class = class787_0.method_1();
			class2 = class787_0.method_9();
		}
		else
		{
			@class = class787_0.method_2();
			class2 = class787_0.method_10();
		}
		if (@class.CategoryType == Enum64.const_2)
		{
			return smethod_5(interface42_0, class787_0, class810_0, rectangle_0, float_0, @enum);
		}
		float num = 0f;
		num = (class2.IsPlotOrderReversed ? ((float)rectangle_0.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height) : ((float)rectangle_0.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height));
		Class808 class3 = class787_0.method_7();
		_ = class3.Count;
		_ = class2.MinValue;
		_ = class2.MaxValue;
		bool hasDropLines = class810_0.HasDropLines;
		Class806 class806_ = class810_0.method_13();
		int num2 = 0;
		int num3 = int_0;
		if (@class.bool_12)
		{
			num3 = (int)@class.MaxValue;
		}
		if (!@class.AxisBetweenCategories && !class787_0.IsDataTableShown)
		{
			num2 = num3 - 1;
			if (num2 == 0)
			{
				num2 = 1;
			}
		}
		else
		{
			num2 = num3;
		}
		double num4 = (double)rectangle_0.Width / (double)num2;
		ArrayList arrayList2 = new ArrayList();
		IList list = class3.method_17(@enum, new ChartType_Chart[1] { chartType_Chart });
		ArrayList arrayList3 = new ArrayList();
		int num5 = class3.method_19(class810_0, @enum, new ChartType_Chart[1] { chartType_Chart });
		Class810 class4 = null;
		if (num5 > 0)
		{
			class4 = class3.method_18(num5 - 1, @enum, new ChartType_Chart[1] { chartType_Chart });
		}
		if (class4 != null)
		{
			arrayList3.Add(class4);
		}
		arrayList3.Add(class810_0);
		for (int i = 0; i < arrayList3.Count; i++)
		{
			Class810 class5 = (Class810)arrayList3[i];
			int num6 = class3.method_19(class5, @enum, new ChartType_Chart[1] { chartType_Chart });
			int index = class5.Index;
			ArrayList arrayList4 = new ArrayList();
			Class795 class6 = class3.method_9(index).method_10();
			for (int j = 0; j < int_0; j++)
			{
				Class796 class7 = class6.method_1(j);
				double num7 = (float)num4 * (float)j + 1f;
				if (@class.AxisBetweenCategories || class787_0.IsDataTableShown)
				{
					num7 += (double)(float)(num4 / 2.0);
				}
				num7 = ((!@class.IsPlotOrderReversed) ? ((double)rectangle_0.X + num7) : ((double)(rectangle_0.X + rectangle_0.Width) - num7));
				if (class7 != null && !class7.imethod_0())
				{
					double yValue = class7.YValue;
					double num8 = yValue;
					double num9 = 0.0;
					for (int k = 0; k < num6; k++)
					{
						Class796 class8 = ((Class810)list[k]).method_10().method_1(j);
						if (class8 != null)
						{
							double yValue2 = class8.YValue;
							num8 += yValue2;
						}
					}
					for (int l = 0; l < list.Count; l++)
					{
						Class796 class9 = ((Class810)list[l]).method_10().method_1(j);
						if (class9 != null)
						{
							double yValue3 = class9.YValue;
							num9 += Math.Abs(yValue3);
						}
					}
					float num10 = 0f;
					if (num9 != 0.0)
					{
						num10 = (float)Math.Abs(num8) * 100f / (float)num9 / (float)(class2.MaxValue - class2.MinValue) * (float)rectangle_0.Height;
					}
					num10 = ((!class2.IsPlotOrderReversed) ? ((!(num8 <= 0.0)) ? (num - num10) : (num + num10)) : ((!(num8 <= 0.0)) ? (num + num10) : (num - num10)));
					PointF pointF_ = new PointF((float)num7, num10);
					smethod_6(pointF_, arrayList4);
					if (!class5.Equals(class810_0))
					{
						continue;
					}
					Class800 class10 = class810_0.method_4();
					double num11 = 0.0;
					double num12 = 0.0;
					float float_ = 0f;
					float float_2 = 0f;
					if (class10 != null)
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
					}
					class10.method_0(pointF_, float_, float_2);
					continue;
				}
				PointF pointF_2 = new PointF((float)num7, float_0);
				int num14 = i;
				while (num14 > 0)
				{
					if (((ArrayList)arrayList2[num14 - 1])[j] == null)
					{
						num14--;
						continue;
					}
					pointF_2 = (PointF)((ArrayList)arrayList2[num14 - 1])[j];
					break;
				}
				if (i == 0)
				{
					pointF_2 = new PointF((float)num7, float_0);
				}
				smethod_6(pointF_2, arrayList4);
			}
			arrayList2.Add(arrayList4);
		}
		smethod_10(interface42_0, arrayList3, arrayList2, float_0, hasDropLines, class806_, arrayList, @class, rectangle_0);
		return arrayList;
	}

	private static ArrayList smethod_5(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Rectangle rectangle_0, float float_0, Enum53 enum53_0)
	{
		ArrayList arrayList = new ArrayList();
		ChartType_Chart chartType_Chart = ChartType_Chart.Area100PercentStacked;
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class810 class2 = class787_0.method_7().method_13(enum53_0, ChartType_Chart.Area100PercentStacked);
		if (class2 == null)
		{
			return arrayList;
		}
		Class789 class3;
		Class789 class4;
		ArrayList arrayList2;
		if (enum53_0 == Enum53.const_0)
		{
			class3 = class787_0.method_1();
			class4 = class787_0.method_9();
			arrayList2 = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		}
		else
		{
			class3 = class787_0.method_2();
			class4 = class787_0.method_10();
			arrayList2 = Class817.smethod_71(class787_0.method_7().method_2(), class787_0.vmethod_0());
		}
		float num = 0f;
		num = (class4.IsPlotOrderReversed ? ((float)rectangle_0.Bottom - (float)class4.MaxValue / (float)(class4.MaxValue - class4.MinValue) * (float)rectangle_0.Height) : ((float)rectangle_0.Y + (float)class4.MaxValue / (float)(class4.MaxValue - class4.MinValue) * (float)rectangle_0.Height));
		_ = class4.MinValue;
		_ = class4.MaxValue;
		bool hasDropLines = class2.HasDropLines;
		Class806 class806_ = class2.method_13();
		int count = arrayList2.Count;
		Enum87 baseUnitScale = class3.BaseUnitScale;
		int int_ = (int)class3.MinValue;
		int int_2 = (int)class3.MaxValue;
		int num2 = 0;
		if (!class3.AxisBetweenCategories && !class787_0.IsDataTableShown)
		{
			num2 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0());
			if (num2 == 0)
			{
				num2 = 1;
			}
		}
		else
		{
			num2 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0()) + 1;
		}
		double num3 = (double)rectangle_0.Width / (double)num2;
		ArrayList arrayList3 = new ArrayList();
		IList list = @class.method_17(enum53_0, new ChartType_Chart[1] { chartType_Chart });
		ArrayList arrayList4 = new ArrayList();
		int num4 = @class.method_19(class810_0, enum53_0, new ChartType_Chart[1] { chartType_Chart });
		Class810 class5 = null;
		if (num4 > 0)
		{
			class5 = @class.method_18(num4 - 1, enum53_0, new ChartType_Chart[1] { chartType_Chart });
		}
		if (class5 != null)
		{
			arrayList4.Add(class5);
		}
		arrayList4.Add(class810_0);
		for (int i = 0; i < arrayList4.Count; i++)
		{
			Class810 class6 = (Class810)arrayList4[i];
			int num5 = @class.method_19(class6, enum53_0, new ChartType_Chart[1] { chartType_Chart });
			int index = class6.Index;
			ArrayList arrayList5 = new ArrayList();
			for (int j = 0; j < count; j++)
			{
				Class796 class7 = @class.method_9(index).method_10().method_1(j);
				int int_3 = int.Parse(arrayList2[j].ToString());
				int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
				int num6 = Struct19.smethod_29(baseUnitScale, int_3, int_, class787_0.vmethod_0());
				float num7 = (float)(num3 * (double)num6);
				Struct19.smethod_29(baseUnitScale, Struct19.smethod_31(class3.BaseUnitScale, class3.MajorUnitScale, (int)class3.MajorUnit, int_3, class787_0.vmethod_0()), int_3, class787_0.vmethod_0());
				if (class3.AxisBetweenCategories || class787_0.IsDataTableShown)
				{
					num7 += (float)(num3 / 2.0);
				}
				float num8 = 0f;
				num8 = ((!class3.IsPlotOrderReversed) ? ((float)rectangle_0.X + num7) : ((float)(rectangle_0.X + rectangle_0.Width) - num7));
				if (class7 != null && !class7.imethod_0())
				{
					double yValue = class7.YValue;
					double num9 = yValue;
					double num10 = 0.0;
					for (int k = 0; k < num5; k++)
					{
						Class796 class8 = ((Class810)list[k]).method_10().method_1(j);
						if (class8 != null)
						{
							double yValue2 = class8.YValue;
							num9 += yValue2;
						}
					}
					for (int l = 0; l < list.Count; l++)
					{
						Class796 class9 = ((Class810)list[l]).method_10().method_1(j);
						if (class9 != null)
						{
							double yValue3 = class9.YValue;
							num10 += Math.Abs(yValue3);
						}
					}
					float num11 = 0f;
					if (num10 != 0.0)
					{
						num11 = (float)Math.Abs(num9) * 100f / (float)num10 / (float)(class4.MaxValue - class4.MinValue) * (float)rectangle_0.Height;
					}
					num11 = ((!class4.IsPlotOrderReversed) ? ((!(num9 <= 0.0)) ? (num - num11) : (num + num11)) : ((!(num9 <= 0.0)) ? (num + num11) : (num - num11)));
					PointF pointF_ = new PointF(num8, num11);
					smethod_6(pointF_, arrayList5);
					if (!class6.Equals(class810_0))
					{
						continue;
					}
					Class800 class10 = class810_0.method_4();
					double num12 = 0.0;
					double num13 = 0.0;
					float float_ = 0f;
					float float_2 = 0f;
					if (class10 != null)
					{
						switch (class10.Type)
						{
						case Enum69.const_0:
						{
							double num14 = ((class10.MinusValue.Count > j) ? class10.method_2(class10.MinusValue[j]) : 0.0);
							num12 = num14;
							num14 = ((class10.PlusValue.Count > j) ? class10.method_2(class10.PlusValue[j]) : 0.0);
							num13 = num14;
							break;
						}
						case Enum69.const_1:
							num12 = class10.Amount;
							num13 = num12;
							break;
						case Enum69.const_2:
							num12 = class10.Amount * Math.Abs(yValue) / 100.0;
							num13 = num12;
							break;
						}
						num13 = num13 * 100.0 / num10;
						num12 = num12 * 100.0 / num10;
						float_ = (float)num12 / (float)(class4.MaxValue - class4.MinValue) * (float)rectangle_0.Height;
						float_2 = (float)num13 / (float)(class4.MaxValue - class4.MinValue) * (float)rectangle_0.Height;
					}
					class10.method_0(pointF_, float_, float_2);
					continue;
				}
				PointF pointF_2 = new PointF(num8, float_0);
				int num15 = i;
				while (num15 > 0)
				{
					if (((ArrayList)arrayList3[num15 - 1])[j] == null)
					{
						num15--;
						continue;
					}
					pointF_2 = (PointF)((ArrayList)arrayList3[num15 - 1])[j];
					break;
				}
				if (i == 0)
				{
					pointF_2 = new PointF(num8, float_0);
				}
				smethod_6(pointF_2, arrayList5);
			}
			arrayList3.Add(arrayList5);
		}
		smethod_10(interface42_0, arrayList4, arrayList3, float_0, hasDropLines, class806_, arrayList, class3, rectangle_0);
		return arrayList;
	}

	private static void smethod_6(PointF pointF_0, IList ilist_0)
	{
		if (ilist_0.Count == 0)
		{
			ilist_0.Add(pointF_0);
			return;
		}
		int i;
		for (i = 0; i < ilist_0.Count; i++)
		{
			if (ilist_0[i] != null)
			{
				PointF pointF = (PointF)ilist_0[i];
				if (!(pointF_0.X >= pointF.X))
				{
					ilist_0.Insert(i, pointF_0);
					break;
				}
			}
		}
		if (i == ilist_0.Count)
		{
			ilist_0.Add(pointF_0);
		}
	}

	internal static RectangleF smethod_7(PointF[] pointF_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		if (pointF_0.Length > 0)
		{
			num = pointF_0[0].X;
			num2 = pointF_0[0].X;
			num3 = pointF_0[0].Y;
			num4 = pointF_0[0].Y;
		}
		for (int i = 1; i < pointF_0.Length; i++)
		{
			PointF pointF = pointF_0[i];
			if (pointF.X < num)
			{
				num = pointF.X;
			}
			if (pointF.X > num2)
			{
				num2 = pointF.X;
			}
			if (pointF.Y < num3)
			{
				num3 = pointF.Y;
			}
			if (pointF.Y > num4)
			{
				num4 = pointF.Y;
			}
		}
		return new RectangleF(num, num3, num2 - num, num4 - num3);
	}

	private static void smethod_8(Interface42 interface42_0, Class810 class810_0, IList ilist_0, ArrayList arrayList_0, float float_0, bool bool_0, Class806 class806_0, ArrayList arrayList_1, Class789 class789_0, Rectangle rectangle_0, int int_0)
	{
		if (ilist_0.Count < 2)
		{
			return;
		}
		Rectangle rectangle_ = new Rectangle(rectangle_0.X, rectangle_0.Y + 1, rectangle_0.Width + 2, rectangle_0.Height);
		GraphicsState graphicsState_ = interface42_0.Save();
		interface42_0.imethod_50();
		interface42_0.imethod_47(rectangle_);
		if (!class810_0.method_39())
		{
			for (int i = 0; i < ilist_0.Count; i++)
			{
				PointF pointF = (PointF)ilist_0[i];
				if (!smethod_9(i, arrayList_0) && class810_0.Points[i] != null)
				{
					arrayList_1.Add(new object[4]
					{
						class810_0.Index,
						i,
						new PointF(pointF.X, (pointF.Y + float_0) / 2f),
						class789_0
					});
				}
			}
		}
		else
		{
			PointF pointF2 = PointF.Empty;
			if (ilist_0.Count % 2 == 0)
			{
				PointF pointF3 = (PointF)ilist_0[ilist_0.Count / 2];
				PointF pointF4 = (PointF)ilist_0[ilist_0.Count / 2 - 1];
				pointF2.X = (pointF3.X + pointF4.X) / 2f;
				pointF2.Y = ((pointF3.Y + float_0) / 2f + (pointF4.Y + float_0) / 2f) / 2f;
			}
			else
			{
				PointF pointF5 = (PointF)ilist_0[ilist_0.Count / 2];
				pointF2 = new PointF(pointF5.X, (pointF5.Y + float_0) / 2f);
			}
			if (class810_0.Points[0] != null)
			{
				arrayList_1.Add(new object[4] { class810_0.Index, 0, pointF2, class789_0 });
			}
		}
		ArrayList arrayList = new ArrayList();
		for (int j = 0; j < ilist_0.Count; j++)
		{
			PointF pointF6 = (PointF)ilist_0[j];
			if (!smethod_9(j, arrayList_0) && j != ilist_0.Count - 1)
			{
				arrayList.Add(pointF6);
				continue;
			}
			if (!smethod_9(j, arrayList_0) && j == ilist_0.Count - 1)
			{
				arrayList.Add(pointF6);
			}
			if (arrayList.Count > 1)
			{
				PointF[] array = new PointF[2 * arrayList.Count];
				for (int k = 0; k < arrayList.Count; k++)
				{
					PointF pointF7 = (PointF)arrayList[k];
					array[k] = pointF7;
					ref PointF reference = ref array[array.Length - 1 - k];
					reference = new PointF(pointF7.X, float_0);
				}
				RectangleF rectangleF_ = smethod_7(array);
				using (Brush brush_ = Struct18.smethod_1(class810_0.method_7(), rectangleF_))
				{
					interface42_0.imethod_35(brush_, array);
					interface42_0.imethod_20(Struct29.smethod_5(class810_0.method_6()), array);
				}
				PointF pointF8 = array[0];
				Struct29.smethod_0(interface42_0, pointF8.X, pointF8.Y, pointF8.X, float_0, class810_0.method_6());
			}
			arrayList = new ArrayList();
		}
		if (bool_0)
		{
			for (int l = 1; l < ilist_0.Count - 1; l++)
			{
				PointF pointF9 = (PointF)ilist_0[l];
				if (!smethod_9(l, arrayList_0))
				{
					Struct29.smethod_0(interface42_0, pointF9.X, pointF9.Y, pointF9.X, float_0, class806_0);
				}
			}
		}
		class810_0.vmethod_4();
		interface42_0.imethod_44(graphicsState_);
	}

	private static bool smethod_9(int int_0, ArrayList arrayList_0)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				if ((int)arrayList_0[num] == int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private static void smethod_10(Interface42 interface42_0, IList ilist_0, IList ilist_1, float float_0, bool bool_0, Class806 class806_0, ArrayList arrayList_0, Class789 class789_0, Rectangle rectangle_0)
	{
		Rectangle rectangle_ = new Rectangle(rectangle_0.X, rectangle_0.Y + 1, rectangle_0.Width, rectangle_0.Height + 1);
		GraphicsState graphicsState_ = interface42_0.Save();
		interface42_0.imethod_50();
		interface42_0.imethod_47(rectangle_);
		for (int i = ilist_1.Count - 1; i < ilist_1.Count; i++)
		{
			ArrayList arrayList = (ArrayList)ilist_1[i];
			Class810 @class = (Class810)ilist_0[i];
			ArrayList arrayList2 = null;
			if (i > 0)
			{
				arrayList2 = (ArrayList)ilist_1[i - 1];
			}
			if (arrayList.Count < 2)
			{
				continue;
			}
			PointF pointF = (PointF)arrayList[0];
			Struct29.smethod_0(interface42_0, pointF.X, pointF.Y, pointF.X, float_0, @class.method_6());
			PointF[] array = new PointF[2 * arrayList.Count];
			for (int j = 0; j < arrayList.Count; j++)
			{
				PointF pointF2 = (PointF)arrayList[j];
				array[j] = pointF2;
				if (arrayList2 == null)
				{
					ref PointF reference = ref array[array.Length - 1 - j];
					reference = new PointF(pointF2.X, float_0);
				}
				else
				{
					ref PointF reference2 = ref array[array.Length - 1 - j];
					reference2 = (PointF)arrayList2[j];
				}
			}
			if (!@class.method_39())
			{
				for (int k = 0; k < arrayList.Count; k++)
				{
					if (@class.Points[k] != null)
					{
						PointF pointF3 = (PointF)arrayList[k];
						arrayList_0.Add(new object[4]
						{
							@class.Index,
							k,
							new PointF(pointF3.X, (pointF3.Y + array[array.Length - 1 - k].Y) / 2f),
							class789_0
						});
					}
				}
			}
			else
			{
				PointF pointF4 = PointF.Empty;
				if (arrayList.Count % 2 == 0)
				{
					PointF pointF5 = (PointF)arrayList[arrayList.Count / 2];
					PointF pointF6 = (PointF)arrayList[arrayList.Count / 2 - 1];
					if (arrayList2 == null)
					{
						pointF4.X = (pointF5.X + pointF6.X) / 2f;
						pointF4.Y = ((pointF5.Y + float_0) / 2f + (pointF6.Y + float_0) / 2f) / 2f;
					}
					else
					{
						PointF pointF7 = (PointF)arrayList2[arrayList.Count / 2];
						PointF pointF8 = (PointF)arrayList2[arrayList.Count / 2 - 1];
						pointF4.X = (pointF5.X + pointF6.X) / 2f;
						pointF4.Y = ((pointF5.Y + pointF7.Y) / 2f + (pointF6.Y + pointF8.Y) / 2f) / 2f;
					}
				}
				else
				{
					PointF pointF9 = (PointF)arrayList[arrayList.Count / 2];
					if (arrayList2 == null)
					{
						pointF4 = new PointF(pointF9.X, (pointF9.Y + float_0) / 2f);
					}
					else
					{
						PointF pointF10 = (PointF)arrayList2[arrayList.Count / 2];
						pointF4 = new PointF(pointF9.X, (pointF9.Y + pointF10.Y) / 2f);
					}
				}
				if (@class.Points[0] != null)
				{
					arrayList_0.Add(new object[4] { @class.Index, 0, pointF4, class789_0 });
				}
			}
			RectangleF rectangleF_ = smethod_7(array);
			using (Brush brush_ = Struct18.smethod_1(@class.method_7(), rectangleF_))
			{
				interface42_0.imethod_35(brush_, array);
			}
			interface42_0.imethod_20(Struct29.smethod_5(@class.method_6()), array);
		}
		if (bool_0)
		{
			for (int l = 0; l < ilist_1.Count; l++)
			{
				ArrayList arrayList3 = (ArrayList)ilist_1[l];
				for (int m = 1; m < arrayList3.Count - 1; m++)
				{
					PointF pointF11 = (PointF)arrayList3[m];
					Struct29.smethod_0(interface42_0, pointF11.X, pointF11.Y, pointF11.X, float_0, class806_0);
				}
			}
		}
		interface42_0.imethod_44(graphicsState_);
	}

	internal static void smethod_11(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0, int int_0)
	{
		if (int_0 < 2)
		{
			return;
		}
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		if (class3.CategoryType == Enum64.const_2)
		{
			smethod_12(interface42_0, class787_0, float_0, double_0);
			return;
		}
		float num = (float)class787_0.DepthPercent / 100f;
		float num2 = (float)class787_0.GapDepth / 100f;
		ArrayList arrayList = new ArrayList();
		int num3 = 0;
		bool flag;
		if (flag = class3.AxisBetweenCategories || class787_0.IsDataTableShown)
		{
			num3 = int_0;
		}
		else
		{
			num3 = int_0 - 1;
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		float num4 = class787_0.method_13().Width / (float)num3;
		float float_ = num4 * num / (1f + num2);
		ArrayList arrayList2 = new ArrayList();
		IList list = @class.method_16();
		if ((class787_0.Rotation >= 0 && class787_0.Rotation < 90) || (class787_0.Rotation >= 180 && class787_0.Rotation < 270))
		{
			for (int i = 0; i < list.Count; i++)
			{
				int num5 = list.Count - 1 - i;
				if (class787_0.Rotation >= 180 && class787_0.Rotation < 270)
				{
					num5 = list.Count - 1 - num5;
				}
				if (class787_0.method_11().IsPlotOrderReversed)
				{
					num5 = list.Count - 1 - num5;
				}
				Class810 class4 = (Class810)list[num5];
				int index = class4.Index;
				Class795 class5 = class4.method_10();
				Class796 class796_ = null;
				for (int j = 0; j < int_0; j++)
				{
					int num6 = j;
					if (class787_0.Rotation >= 180 && class787_0.Rotation < 270)
					{
						num6 = int_0 - 1 - num6;
					}
					float num7 = num4 * (float)num6;
					num7 = class787_0.method_13().X + num7;
					if (flag)
					{
						num7 += num4 / 2f;
					}
					int num8 = num6;
					if (class3.IsPlotOrderReversed)
					{
						num8 = int_0 - 1 - num6;
					}
					Class796 class6 = class5.method_1(num8);
					double num9 = 0.0;
					if (class6 != null && !class6.imethod_0())
					{
						num9 = class6.YValue;
						class796_ = class6;
					}
					float num10 = (float)(double_0 - num9) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					if (class2.IsPlotOrderReversed)
					{
						num10 = 0f - num10;
					}
					PointF[] array = Struct25.smethod_48(interface42_0, class787_0, float_0, 0f, num7, float_, index + 1, list.Count);
					arrayList2.Add(array);
					PointF[] array2 = Struct25.smethod_48(interface42_0, class787_0, float_0, num10, num7, float_, index + 1, list.Count);
					arrayList2.Add(array2);
					if (class6 != null && !class6.imethod_0())
					{
						if (!class4.method_39())
						{
							PointF pointF = new PointF(0f, 0f);
							if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
							{
								pointF.X = (array[1].X + array2[1].X) / 2f;
								pointF.Y = (array[1].Y + array2[1].Y) / 2f;
							}
							else
							{
								pointF.X = (array[0].X + array2[0].X) / 2f;
								pointF.Y = (array[0].Y + array2[0].Y) / 2f;
							}
							arrayList.Add(new object[3] { index, num8, pointF });
						}
						else if (num8 == 0)
						{
							float num11 = class787_0.method_13().Width / 2f;
							num11 = class787_0.method_13().X + num11;
							double num12 = 0.0;
							if (int_0 % 2 == 0)
							{
								Class796 class7 = class5.method_1(int_0 / 2);
								Class796 class8 = class5.method_1(int_0 / 2 - 1);
								num12 = (class7.YValue + class8.YValue) / 2.0;
							}
							else
							{
								Class796 class9 = class5.method_1(int_0 / 2);
								num12 = class9.YValue;
							}
							float num13 = (float)(double_0 - num12) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
							if (class2.IsPlotOrderReversed)
							{
								num13 = 0f - num13;
							}
							PointF[] array3 = Struct25.smethod_48(interface42_0, class787_0, float_0, 0f, num11, float_, index + 1, list.Count);
							PointF[] array4 = Struct25.smethod_48(interface42_0, class787_0, float_0, num13, num11, float_, index + 1, list.Count);
							PointF pointF2 = new PointF(0f, 0f);
							if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
							{
								pointF2.X = (array3[1].X + array4[1].X) / 2f;
								pointF2.Y = (array3[1].Y + array4[1].Y) / 2f;
							}
							else
							{
								pointF2.X = (array3[0].X + array4[0].X) / 2f;
								pointF2.Y = (array3[0].Y + array4[0].Y) / 2f;
							}
							arrayList.Add(new object[3] { index, num8, pointF2 });
						}
					}
					else
					{
						arrayList2.Add(null);
					}
				}
				smethod_15(interface42_0, class787_0, class796_, arrayList2);
				arrayList2.Clear();
				Struct25.smethod_45(interface42_0, class787_0, arrayList);
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
				Class810 class10 = (Class810)list[num14];
				int index2 = class10.Index;
				Class795 class11 = class10.method_10();
				Class796 class796_2 = null;
				for (int l = 0; l < int_0; l++)
				{
					int num15 = l;
					if (class787_0.Rotation >= 270 && class787_0.Rotation < 360)
					{
						num15 = int_0 - 1 - num15;
					}
					float num16 = num4 * (float)num15;
					num16 = class787_0.method_13().X + num16;
					if (flag)
					{
						num16 += num4 / 2f;
					}
					int num17 = num15;
					if (class3.IsPlotOrderReversed)
					{
						num17 = int_0 - 1 - num15;
					}
					Class796 class12 = class11.method_1(num17);
					double yValue = class12.YValue;
					if (class12 != null && !class12.imethod_0())
					{
						yValue = class12.YValue;
						class796_2 = class12;
					}
					float num18 = (float)(double_0 - yValue) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					if (class2.IsPlotOrderReversed)
					{
						num18 = 0f - num18;
					}
					PointF[] array5 = Struct25.smethod_48(interface42_0, class787_0, float_0, 0f, num16, float_, index2 + 1, list.Count);
					arrayList2.Add(array5);
					PointF[] array6 = Struct25.smethod_48(interface42_0, class787_0, float_0, num18, num16, float_, index2 + 1, list.Count);
					arrayList2.Add(array6);
					if (class12 != null && !class12.imethod_0())
					{
						if (!class10.method_39())
						{
							PointF pointF3 = new PointF(0f, 0f);
							if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
							{
								pointF3.X = (array5[1].X + array6[1].X) / 2f;
								pointF3.Y = (array5[1].Y + array6[1].Y) / 2f;
							}
							else
							{
								pointF3.X = (array5[0].X + array6[0].X) / 2f;
								pointF3.Y = (array5[0].Y + array6[0].Y) / 2f;
							}
							arrayList.Add(new object[3] { index2, num17, pointF3 });
						}
						else if (num17 == 0)
						{
							float num19 = class787_0.method_13().Width / 2f;
							num19 = class787_0.method_13().X + num19;
							double num20 = 0.0;
							if (int_0 % 2 == 0)
							{
								Class796 class13 = class11.method_1(int_0 / 2);
								Class796 class14 = class11.method_1(int_0 / 2 - 1);
								num20 = (class13.YValue + class14.YValue) / 2.0;
							}
							else
							{
								Class796 class15 = class11.method_1(int_0 / 2);
								num20 = class15.YValue;
							}
							float num21 = (float)(double_0 - num20) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
							if (class2.IsPlotOrderReversed)
							{
								num21 = 0f - num21;
							}
							PointF[] array7 = Struct25.smethod_48(interface42_0, class787_0, float_0, 0f, num19, float_, index2 + 1, list.Count);
							PointF[] array8 = Struct25.smethod_48(interface42_0, class787_0, float_0, num21, num19, float_, index2 + 1, list.Count);
							PointF pointF4 = new PointF(0f, 0f);
							if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
							{
								pointF4.X = (array7[1].X + array8[1].X) / 2f;
								pointF4.Y = (array7[1].Y + array8[1].Y) / 2f;
							}
							else
							{
								pointF4.X = (array7[0].X + array8[0].X) / 2f;
								pointF4.Y = (array7[0].Y + array8[0].Y) / 2f;
							}
							arrayList.Add(new object[3] { index2, num17, pointF4 });
						}
					}
					else
					{
						arrayList2.Add(null);
					}
				}
				smethod_15(interface42_0, class787_0, class796_2, arrayList2);
				arrayList2.Clear();
				Struct25.smethod_45(interface42_0, class787_0, arrayList);
				arrayList.Clear();
			}
		}
	}

	private static void smethod_12(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0)
	{
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
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
				if (class787_0.method_11().IsPlotOrderReversed)
				{
					num5 = list.Count - 1 - num5;
				}
				Class810 class4 = (Class810)list[num5];
				int index = class4.Index;
				Class795 class5 = class4.method_10();
				Class796 class796_ = null;
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
					Class796 class6 = class5.method_1(num10);
					double num11 = 0.0;
					if (class6 != null && !class6.imethod_0())
					{
						num11 = class6.YValue;
						class796_ = class6;
					}
					float num12 = (float)(double_0 - num11) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					if (class2.IsPlotOrderReversed)
					{
						num12 = 0f - num12;
					}
					PointF[] array = Struct25.smethod_48(interface42_0, class787_0, float_0, 0f, num9, float_, index + 1, list.Count);
					arrayList2.Add(array);
					PointF[] array2 = Struct25.smethod_48(interface42_0, class787_0, float_0, num12, num9, float_, index + 1, list.Count);
					arrayList2.Add(array2);
					if (class6 != null && !class6.imethod_0())
					{
						if (!class4.method_39())
						{
							PointF pointF = new PointF(0f, 0f);
							if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
							{
								pointF.X = (array[1].X + array2[1].X) / 2f;
								pointF.Y = (array[1].Y + array2[1].Y) / 2f;
							}
							else
							{
								pointF.X = (array[0].X + array2[0].X) / 2f;
								pointF.Y = (array[0].Y + array2[0].Y) / 2f;
							}
							arrayList.Add(new object[3] { index, num10, pointF });
						}
						else if (num10 == 0)
						{
							float num13 = class787_0.method_13().Width / 2f;
							num13 = class787_0.method_13().X + num13;
							double num14 = 0.0;
							if (count % 2 == 0)
							{
								Class796 class7 = class5.method_1(count / 2);
								Class796 class8 = class5.method_1(count / 2 - 1);
								num14 = (class7.YValue + class8.YValue) / 2.0;
							}
							else
							{
								Class796 class9 = class5.method_1(count / 2);
								num14 = class9.YValue;
							}
							float num15 = (float)(double_0 - num14) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
							if (class2.IsPlotOrderReversed)
							{
								num15 = 0f - num15;
							}
							PointF[] array3 = Struct25.smethod_48(interface42_0, class787_0, float_0, 0f, num13, float_, index + 1, list.Count);
							PointF[] array4 = Struct25.smethod_48(interface42_0, class787_0, float_0, num15, num13, float_, index + 1, list.Count);
							PointF pointF2 = new PointF(0f, 0f);
							if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
							{
								pointF2.X = (array3[1].X + array4[1].X) / 2f;
								pointF2.Y = (array3[1].Y + array4[1].Y) / 2f;
							}
							else
							{
								pointF2.X = (array3[0].X + array4[0].X) / 2f;
								pointF2.Y = (array3[0].Y + array4[0].Y) / 2f;
							}
							arrayList.Add(new object[3] { index, num10, pointF2 });
						}
					}
					else
					{
						arrayList2.Add(null);
					}
				}
				smethod_15(interface42_0, class787_0, class796_, arrayList2);
				arrayList2.Clear();
				Struct25.smethod_45(interface42_0, class787_0, arrayList);
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
				int num16 = k;
				if (class787_0.Rotation >= 270 && class787_0.Rotation < 360)
				{
					num16 = list.Count - 1 - num16;
				}
				if (class787_0.method_11().IsPlotOrderReversed)
				{
					num16 = list.Count - 1 - num16;
				}
				Class810 class10 = (Class810)list[num16];
				int index2 = class10.Index;
				Class795 class11 = class10.method_10();
				Class796 class796_2 = null;
				for (int l = 0; l < count; l++)
				{
					int num17 = l;
					if (class787_0.Rotation >= 270 && class787_0.Rotation < 360)
					{
						num17 = count - 1 - num17;
					}
					int int_4 = int.Parse(arrayList3[num17].ToString());
					int_4 = Struct19.smethod_32(baseUnitScale, int_4, class787_0.vmethod_0());
					int num18 = Struct19.smethod_29(baseUnitScale, int_4, (int)class3.MinValue, class787_0.vmethod_0());
					float num19 = num4 * (float)num18;
					float num20 = class787_0.method_13().X + num19;
					if (flag)
					{
						num20 += num4 / 2f;
					}
					int num21 = num17;
					if (class3.IsPlotOrderReversed)
					{
						num21 = count - 1 - num17;
					}
					Class796 class12 = class11.method_1(num21);
					double yValue = class12.YValue;
					if (class12 != null && !class12.imethod_0())
					{
						yValue = class12.YValue;
						class796_2 = class12;
					}
					float num22 = (float)(double_0 - yValue) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
					if (class2.IsPlotOrderReversed)
					{
						num22 = 0f - num22;
					}
					PointF[] array5 = Struct25.smethod_48(interface42_0, class787_0, float_0, 0f, num20, float_, index2 + 1, list.Count);
					arrayList2.Add(array5);
					PointF[] array6 = Struct25.smethod_48(interface42_0, class787_0, float_0, num22, num20, float_, index2 + 1, list.Count);
					arrayList2.Add(array6);
					if (class12 != null && !class12.imethod_0())
					{
						if (!class10.method_39())
						{
							PointF pointF3 = new PointF(0f, 0f);
							if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
							{
								pointF3.X = (array5[1].X + array6[1].X) / 2f;
								pointF3.Y = (array5[1].Y + array6[1].Y) / 2f;
							}
							else
							{
								pointF3.X = (array5[0].X + array6[0].X) / 2f;
								pointF3.Y = (array5[0].Y + array6[0].Y) / 2f;
							}
							arrayList.Add(new object[3] { index2, num21, pointF3 });
						}
						else if (num21 == 0)
						{
							float num23 = class787_0.method_13().Width / 2f;
							num23 = class787_0.method_13().X + num23;
							double num24 = 0.0;
							if (count % 2 == 0)
							{
								Class796 class13 = class11.method_1(count / 2);
								Class796 class14 = class11.method_1(count / 2 - 1);
								num24 = (class13.YValue + class14.YValue) / 2.0;
							}
							else
							{
								Class796 class15 = class11.method_1(count / 2);
								num24 = class15.YValue;
							}
							float num25 = (float)(double_0 - num24) / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
							if (class2.IsPlotOrderReversed)
							{
								num25 = 0f - num25;
							}
							PointF[] array7 = Struct25.smethod_48(interface42_0, class787_0, float_0, 0f, num23, float_, index2 + 1, list.Count);
							PointF[] array8 = Struct25.smethod_48(interface42_0, class787_0, float_0, num25, num23, float_, index2 + 1, list.Count);
							PointF pointF4 = new PointF(0f, 0f);
							if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
							{
								pointF4.X = (array7[1].X + array8[1].X) / 2f;
								pointF4.Y = (array7[1].Y + array8[1].Y) / 2f;
							}
							else
							{
								pointF4.X = (array7[0].X + array8[0].X) / 2f;
								pointF4.Y = (array7[0].Y + array8[0].Y) / 2f;
							}
							arrayList.Add(new object[3] { index2, num21, pointF4 });
						}
					}
					else
					{
						arrayList2.Add(null);
					}
				}
				smethod_15(interface42_0, class787_0, class796_2, arrayList2);
				arrayList2.Clear();
				Struct25.smethod_45(interface42_0, class787_0, arrayList);
				arrayList.Clear();
			}
		}
	}

	internal static void smethod_13(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0, int int_0, bool bool_0)
	{
		if (int_0 < 2)
		{
			return;
		}
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		if (class3.CategoryType == Enum64.const_2)
		{
			smethod_14(interface42_0, class787_0, float_0, double_0, bool_0);
			return;
		}
		float num = (float)class787_0.DepthPercent / 100f;
		float num2 = (float)class787_0.GapDepth / 100f;
		_ = (float)class787_0.GapWidth / 100f;
		float num3 = 0f;
		num3 = (class2.IsPlotOrderReversed ? (class787_0.method_13().Y - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height) : (class787_0.method_13().Y - class787_0.method_13().Height + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height));
		ArrayList arrayList = new ArrayList();
		int num4 = 0;
		bool flag;
		if (flag = class3.AxisBetweenCategories || class787_0.IsDataTableShown)
		{
			num4 = int_0;
		}
		else
		{
			num4 = int_0 - 1;
			if (num4 == 0)
			{
				num4 = 1;
			}
		}
		float num5 = class787_0.method_13().Width / (float)num4;
		float float_ = num5 * num / (1f + num2);
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < int_0; i++)
		{
			float num6 = class787_0.method_13().X + num5 * (float)i;
			if (flag)
			{
				num6 += num5 / 2f;
			}
			PointF[] value = smethod_19(class787_0, num6, float_, float_0, interface42_0);
			arrayList3.Add(value);
		}
		arrayList2.Add(arrayList3);
		IList list = @class.method_16();
		Class796[] array = new Class796[list.Count];
		ArrayList arrayList4 = null;
		for (int j = 0; j < list.Count; j++)
		{
			Class810 class4 = (Class810)list[j];
			int index = class4.Index;
			int num7 = j;
			Class795 class5 = class4.method_10();
			ArrayList arrayList5 = new ArrayList();
			if (j == 0)
			{
				arrayList4 = arrayList3;
			}
			for (int k = 0; k < int_0; k++)
			{
				int num8 = k;
				float num9 = num5 * (float)num8;
				num9 = class787_0.method_13().X + num9;
				if (flag)
				{
					num9 += num5 / 2f;
				}
				int num10 = num8;
				if (class3.IsPlotOrderReversed)
				{
					num10 = int_0 - 1 - num8;
				}
				Class796 class6 = class5.method_1(num10);
				double num11 = 0.0;
				double num12 = 0.0;
				double num13 = 0.0;
				if (class6 != null && !class6.imethod_0())
				{
					array[j] = class6;
					num11 = Math.Abs(class6.YValue);
					num12 = num11;
					for (int l = 0; l < num7; l++)
					{
						Class796 class7 = ((Class810)list[l]).method_10().method_1(num10);
						if (class7 != null)
						{
							double value2 = Math.Abs(class7.YValue);
							num12 += Math.Abs(value2);
						}
					}
				}
				for (int m = 0; m < list.Count; m++)
				{
					Class796 class8 = ((Class810)list[m]).method_10().method_1(num10);
					if (class8 != null)
					{
						double yValue = class8.YValue;
						num13 += Math.Abs(yValue);
					}
				}
				float num14;
				if (!bool_0)
				{
					num14 = (float)num12 / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
				}
				else
				{
					if (num13 == 0.0)
					{
						continue;
					}
					num14 = (float)num12 * 100f / (float)num13 / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
				}
				if (class2.IsPlotOrderReversed)
				{
					num14 = 0f - num14;
				}
				PointF[] array2 = smethod_19(class787_0, num9, float_, num3 - num14, interface42_0);
				arrayList5.Add(array2);
				if (class6 == null || class6.imethod_0())
				{
					continue;
				}
				if (!class4.method_39() && arrayList4.Count > num8)
				{
					PointF pointF = new PointF(0f, 0f);
					PointF[] array3 = (PointF[])arrayList4[num8];
					if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
					{
						pointF.X = array2[1].X;
						pointF.Y = (array3[1].Y + array2[1].Y) / 2f;
					}
					else
					{
						pointF.X = array2[0].X;
						pointF.Y = (array3[0].Y + array2[0].Y) / 2f;
					}
					arrayList.Add(new object[3] { index, num10, pointF });
				}
				if (k == int_0 - 1)
				{
					PointF[] array4 = (PointF[])arrayList5[int_0 / 2 - 1];
					PointF[] array5 = (PointF[])arrayList5[int_0 / 2];
					PointF[] array6 = (PointF[])arrayList4[int_0 / 2 - 1];
					PointF[] array7 = (PointF[])arrayList4[int_0 / 2];
					if (int_0 % 2 != 0)
					{
						array5 = (PointF[])arrayList5[int_0 / 2 + 1];
						array7 = (PointF[])arrayList4[int_0 / 2 + 1];
					}
					PointF pointF2 = new PointF(0f, 0f);
					if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
					{
						pointF2.X = (array4[1].X + array6[1].X + array5[1].X + array7[1].X) / 4f;
						pointF2.Y = (array4[1].Y + array6[1].Y + array5[1].Y + array7[1].Y) / 4f;
					}
					else
					{
						pointF2.X = (array4[0].X + array6[0].X + array5[0].X + array7[0].X) / 4f;
						pointF2.Y = (array4[0].Y + array6[0].Y + array5[0].Y + array7[0].Y) / 4f;
					}
					arrayList.Add(new object[3] { index, 0, pointF2 });
				}
			}
			arrayList2.Add(arrayList5);
			arrayList4 = arrayList5;
		}
		smethod_20(interface42_0, class787_0, array, arrayList2);
		Struct25.smethod_45(interface42_0, class787_0, arrayList);
	}

	private static void smethod_14(Interface42 interface42_0, Class787 class787_0, float float_0, double double_0, bool bool_0)
	{
		Class808 @class = class787_0.method_7();
		_ = @class.Count;
		Class789 class2 = class787_0.method_9();
		Class789 class3 = class787_0.method_1();
		float num = (float)class787_0.DepthPercent / 100f;
		float num2 = (float)class787_0.GapDepth / 100f;
		_ = (float)class787_0.GapWidth / 100f;
		float num3 = 0f;
		num3 = (class2.IsPlotOrderReversed ? (class787_0.method_13().Y - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height) : (class787_0.method_13().Y - class787_0.method_13().Height + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height));
		ArrayList arrayList = new ArrayList();
		Enum87 baseUnitScale = class3.BaseUnitScale;
		int int_ = (int)class3.MinValue;
		int int_2 = (int)class3.MaxValue;
		int num4 = 0;
		bool flag;
		if (flag = class3.AxisBetweenCategories || class787_0.IsDataTableShown)
		{
			num4 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0()) + 1;
		}
		else
		{
			num4 = Struct19.smethod_29(baseUnitScale, int_2, int_, class787_0.vmethod_0());
			if (num4 == 0)
			{
				num4 = 1;
			}
		}
		float num5 = class787_0.method_13().Width / (float)num4;
		float float_ = num5 * num / (1f + num2);
		ArrayList arrayList2 = Class817.smethod_71(class787_0.method_7().method_0(), class787_0.vmethod_0());
		int count = arrayList2.Count;
		ArrayList arrayList3 = new ArrayList();
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < count; i++)
		{
			int int_3 = int.Parse(arrayList2[i].ToString());
			int_3 = Struct19.smethod_32(baseUnitScale, int_3, class787_0.vmethod_0());
			int num6 = Struct19.smethod_29(baseUnitScale, int_3, (int)class3.MinValue, class787_0.vmethod_0());
			float num7 = num5 * (float)num6;
			float num8 = class787_0.method_13().X + num7;
			if (flag)
			{
				num8 += num5 / 2f;
			}
			PointF[] value = smethod_19(class787_0, num8, float_, float_0, interface42_0);
			arrayList4.Add(value);
		}
		arrayList3.Add(arrayList4);
		IList list = @class.method_16();
		Class796[] array = new Class796[list.Count];
		ArrayList arrayList5 = null;
		for (int j = 0; j < list.Count; j++)
		{
			Class810 class4 = (Class810)list[j];
			int index = class4.Index;
			int num9 = j;
			Class795 class5 = class4.method_10();
			ArrayList arrayList6 = new ArrayList();
			if (j == 0)
			{
				arrayList5 = arrayList4;
			}
			for (int k = 0; k < count; k++)
			{
				int num10 = k;
				int int_4 = int.Parse(arrayList2[num10].ToString());
				int_4 = Struct19.smethod_32(baseUnitScale, int_4, class787_0.vmethod_0());
				int num11 = Struct19.smethod_29(baseUnitScale, int_4, (int)class3.MinValue, class787_0.vmethod_0());
				float num12 = num5 * (float)num11;
				float num13 = class787_0.method_13().X + num12;
				if (flag)
				{
					num13 += num5 / 2f;
				}
				int num14 = num10;
				if (class3.IsPlotOrderReversed)
				{
					num14 = count - 1 - num10;
				}
				Class796 class6 = class5.method_1(num14);
				double num15 = 0.0;
				double num16 = 0.0;
				double num17 = 0.0;
				if (class6 != null && !class6.imethod_0())
				{
					array[j] = class6;
					num15 = Math.Abs(class6.YValue);
					num16 = num15;
					for (int l = 0; l < num9; l++)
					{
						Class796 class7 = ((Class810)list[l]).method_10().method_1(num14);
						if (class7 != null)
						{
							double num18 = Math.Abs(class7.YValue);
							num16 += num18;
						}
					}
				}
				for (int m = 0; m < list.Count; m++)
				{
					Class796 class8 = ((Class810)list[m]).method_10().method_1(num14);
					if (class8 != null && !class6.imethod_0())
					{
						double yValue = class8.YValue;
						num17 += Math.Abs(yValue);
					}
				}
				_ = (float)(double_0 - num15) / (float)(class2.MaxValue - class2.MinValue);
				_ = class787_0.method_13().Height;
				float num19;
				if (!bool_0)
				{
					num19 = (float)num16 / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
				}
				else
				{
					if (num17 == 0.0)
					{
						continue;
					}
					num19 = (float)num16 * 100f / (float)num17 / (float)(class2.MaxValue - class2.MinValue) * class787_0.method_13().Height;
				}
				if (class2.IsPlotOrderReversed)
				{
					num19 = 0f - num19;
				}
				PointF[] array2 = smethod_19(class787_0, num13, float_, num3 - num19, interface42_0);
				arrayList6.Add(array2);
				if (class6 == null || class6.imethod_0())
				{
					continue;
				}
				if (!class4.method_39() && arrayList5.Count > num10)
				{
					PointF pointF = new PointF(0f, 0f);
					PointF[] array3 = (PointF[])arrayList5[num10];
					if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
					{
						pointF.X = array2[1].X;
						pointF.Y = (array3[1].Y + array2[1].Y) / 2f;
					}
					else
					{
						pointF.X = array2[0].X;
						pointF.Y = (array3[0].Y + array2[0].Y) / 2f;
					}
					arrayList.Add(new object[3] { index, num14, pointF });
				}
				if (k == count - 1)
				{
					PointF[] array4 = (PointF[])arrayList6[count / 2 - 1];
					PointF[] array5 = (PointF[])arrayList6[count / 2];
					PointF[] array6 = (PointF[])arrayList5[count / 2 - 1];
					PointF[] array7 = (PointF[])arrayList5[count / 2];
					if (count % 2 != 0)
					{
						array5 = (PointF[])arrayList6[count / 2 + 1];
						array7 = (PointF[])arrayList5[count / 2 + 1];
					}
					PointF pointF2 = new PointF(0f, 0f);
					if (class787_0.Rotation >= 90 && class787_0.Rotation < 270)
					{
						pointF2.X = (array4[1].X + array6[1].X + array5[1].X + array7[1].X) / 4f;
						pointF2.Y = (array4[1].Y + array6[1].Y + array5[1].Y + array7[1].Y) / 4f;
					}
					else
					{
						pointF2.X = (array4[0].X + array6[0].X + array5[0].X + array7[0].X) / 4f;
						pointF2.Y = (array4[0].Y + array6[0].Y + array5[0].Y + array7[0].Y) / 4f;
					}
					arrayList.Add(new object[3] { index, 0, pointF2 });
				}
			}
			arrayList5 = arrayList6;
			arrayList3.Add(arrayList6);
		}
		smethod_20(interface42_0, class787_0, array, arrayList3);
		Struct25.smethod_45(interface42_0, class787_0, arrayList);
	}

	private static void smethod_15(Interface42 interface42_0, Class787 class787_0, Class796 class796_0, IList ilist_0)
	{
		if (ilist_0.Count < 4 || class796_0 == null)
		{
			return;
		}
		int num = ilist_0.Count / 2;
		PointF[] array = new PointF[num];
		PointF[] array2 = new PointF[num];
		PointF[] array3 = new PointF[num];
		PointF[] array4 = new PointF[num];
		for (int i = 0; i < ilist_0.Count; i += 2)
		{
			PointF[] array5 = (PointF[])ilist_0[i];
			PointF[] array6 = (PointF[])ilist_0[i + 1];
			ref PointF reference = ref array[i / 2];
			reference = array5[0];
			ref PointF reference2 = ref array2[i / 2];
			reference2 = array5[1];
			ref PointF reference3 = ref array3[i / 2];
			reference3 = array6[0];
			ref PointF reference4 = ref array4[i / 2];
			reference4 = array6[1];
		}
		for (int j = 1; j < num; j++)
		{
			PointF[] array7 = new PointF[8];
			if (smethod_16(array[j - 1], array[j], array3[j - 1], array3[j], out var crossPoint))
			{
				if (smethod_16(array2[j - 1], array2[j], array4[j - 1], array4[j], out var crossPoint2))
				{
					ref PointF reference5 = ref array7[0];
					reference5 = array[j - 1];
					array7[1] = crossPoint;
					array7[2] = crossPoint2;
					ref PointF reference6 = ref array7[3];
					reference6 = array2[j - 1];
					ref PointF reference7 = ref array7[4];
					reference7 = array3[j - 1];
					array7[5] = crossPoint;
					array7[6] = crossPoint2;
					ref PointF reference8 = ref array7[7];
					reference8 = array4[j - 1];
					smethod_17(interface42_0, class787_0, class796_0, array7);
					array7[0] = crossPoint;
					ref PointF reference9 = ref array7[1];
					reference9 = array[j];
					ref PointF reference10 = ref array7[2];
					reference10 = array2[j];
					array7[3] = crossPoint2;
					array7[4] = crossPoint;
					ref PointF reference11 = ref array7[5];
					reference11 = array3[j];
					ref PointF reference12 = ref array7[6];
					reference12 = array4[j];
					array7[7] = crossPoint2;
					smethod_17(interface42_0, class787_0, class796_0, array7);
				}
			}
			else
			{
				ref PointF reference13 = ref array7[0];
				reference13 = array[j - 1];
				ref PointF reference14 = ref array7[1];
				reference14 = array[j];
				ref PointF reference15 = ref array7[2];
				reference15 = array2[j];
				ref PointF reference16 = ref array7[3];
				reference16 = array2[j - 1];
				ref PointF reference17 = ref array7[4];
				reference17 = array3[j - 1];
				ref PointF reference18 = ref array7[5];
				reference18 = array3[j];
				ref PointF reference19 = ref array7[6];
				reference19 = array4[j];
				ref PointF reference20 = ref array7[7];
				reference20 = array4[j - 1];
				smethod_17(interface42_0, class787_0, class796_0, array7);
			}
		}
		smethod_18(interface42_0, class787_0, class796_0, array, array2, array3, array4);
	}

	private static bool smethod_16(PointF point1, PointF point2, PointF point3, PointF point4, out PointF crossPoint)
	{
		crossPoint = new PointF(0f, 0f);
		if (point1.X != point2.X && point3.X != point4.X)
		{
			float num = (point1.Y - point2.Y) / (point1.X - point2.X);
			float num2 = point1.Y - num * point1.X;
			float num3 = (point3.Y - point4.Y) / (point3.X - point4.X);
			float num4 = point3.Y - num3 * point3.X;
			if (num == num3)
			{
				return false;
			}
			crossPoint.X = (num4 - num2) / (num - num3);
			crossPoint.Y = num * crossPoint.X + num2;
			if ((point1.X < crossPoint.X && point2.X > crossPoint.X && point3.X < crossPoint.X && point4.X > crossPoint.X) || (point1.X > crossPoint.X && point2.X < crossPoint.X && point3.X > crossPoint.X && point4.X < crossPoint.X))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private static void smethod_17(Interface42 interface42_0, Class787 class787_0, Class796 class796_0, PointF[] pointF_0)
	{
		Class788 class788_ = class796_0.method_3();
		using Pen pen_ = Struct29.smethod_5(class796_0.method_4());
		bool flag = ((pointF_0[0].Y + pointF_0[1].Y + pointF_0[2].Y + pointF_0[3].Y > pointF_0[4].Y + pointF_0[5].Y + pointF_0[6].Y + pointF_0[7].Y) ? true : false);
		if (class787_0.Elevation > 0)
		{
			if (flag)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddPolygon(new PointF[4]
				{
					pointF_0[0],
					pointF_0[1],
					pointF_0[2],
					pointF_0[3]
				});
				using (Brush brush_ = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath), 2f / 3f))
				{
					interface42_0.imethod_33(brush_, graphicsPath);
				}
				interface42_0.imethod_18(pen_, graphicsPath);
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2.AddPolygon(new PointF[4]
				{
					pointF_0[4],
					pointF_0[5],
					pointF_0[6],
					pointF_0[7]
				});
				using (Brush brush_2 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath2), 2f / 3f))
				{
					interface42_0.imethod_33(brush_2, graphicsPath2);
				}
				interface42_0.imethod_18(pen_, graphicsPath2);
			}
			else
			{
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddPolygon(new PointF[4]
				{
					pointF_0[4],
					pointF_0[5],
					pointF_0[6],
					pointF_0[7]
				});
				using (Brush brush_3 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath3), 2f / 3f))
				{
					interface42_0.imethod_33(brush_3, graphicsPath3);
				}
				interface42_0.imethod_18(pen_, graphicsPath3);
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddPolygon(new PointF[4]
				{
					pointF_0[0],
					pointF_0[1],
					pointF_0[2],
					pointF_0[3]
				});
				using (Brush brush_4 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath4), 2f / 3f))
				{
					interface42_0.imethod_33(brush_4, graphicsPath4);
				}
				interface42_0.imethod_18(pen_, graphicsPath4);
			}
		}
		else if (!flag)
		{
			GraphicsPath graphicsPath5 = new GraphicsPath();
			graphicsPath5.AddPolygon(new PointF[4]
			{
				pointF_0[0],
				pointF_0[1],
				pointF_0[2],
				pointF_0[3]
			});
			using (Brush brush_5 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath5), 2f / 3f))
			{
				interface42_0.imethod_33(brush_5, graphicsPath5);
			}
			interface42_0.imethod_18(pen_, graphicsPath5);
			GraphicsPath graphicsPath6 = new GraphicsPath();
			graphicsPath6.AddPolygon(new PointF[4]
			{
				pointF_0[4],
				pointF_0[5],
				pointF_0[6],
				pointF_0[7]
			});
			using (Brush brush_6 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath6), 2f / 3f))
			{
				interface42_0.imethod_33(brush_6, graphicsPath6);
			}
			interface42_0.imethod_18(pen_, graphicsPath6);
		}
		else
		{
			GraphicsPath graphicsPath7 = new GraphicsPath();
			graphicsPath7.AddPolygon(new PointF[4]
			{
				pointF_0[4],
				pointF_0[5],
				pointF_0[6],
				pointF_0[7]
			});
			using (Brush brush_7 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath7), 2f / 3f))
			{
				interface42_0.imethod_33(brush_7, graphicsPath7);
			}
			interface42_0.imethod_18(pen_, graphicsPath7);
			GraphicsPath graphicsPath8 = new GraphicsPath();
			graphicsPath8.AddPolygon(new PointF[4]
			{
				pointF_0[0],
				pointF_0[1],
				pointF_0[2],
				pointF_0[3]
			});
			using (Brush brush_8 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath8), 2f / 3f))
			{
				interface42_0.imethod_33(brush_8, graphicsPath8);
			}
			interface42_0.imethod_18(pen_, graphicsPath8);
		}
		if (class787_0.Rotation > 90 && class787_0.Rotation != 360)
		{
			if (class787_0.Rotation > 90 && class787_0.Rotation <= 180)
			{
				GraphicsPath graphicsPath9 = new GraphicsPath();
				graphicsPath9.AddPolygon(new PointF[4]
				{
					pointF_0[1],
					pointF_0[2],
					pointF_0[6],
					pointF_0[5]
				});
				using (Brush brush_9 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath9), 0.5f))
				{
					interface42_0.imethod_33(brush_9, graphicsPath9);
				}
				interface42_0.imethod_18(pen_, graphicsPath9);
			}
			else if (class787_0.Rotation > 180 && class787_0.Rotation <= 270)
			{
				GraphicsPath graphicsPath10 = new GraphicsPath();
				graphicsPath10.AddPolygon(new PointF[4]
				{
					pointF_0[1],
					pointF_0[2],
					pointF_0[6],
					pointF_0[5]
				});
				using (Brush brush_10 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath10), 0.5f))
				{
					interface42_0.imethod_33(brush_10, graphicsPath10);
				}
				interface42_0.imethod_18(pen_, graphicsPath10);
			}
			else if (class787_0.Rotation > 270 && class787_0.Rotation < 360)
			{
				GraphicsPath graphicsPath11 = new GraphicsPath();
				graphicsPath11.AddPolygon(new PointF[4]
				{
					pointF_0[1],
					pointF_0[2],
					pointF_0[6],
					pointF_0[5]
				});
				using (Brush brush_11 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath11), 0.5f))
				{
					interface42_0.imethod_33(brush_11, graphicsPath11);
				}
				interface42_0.imethod_18(pen_, graphicsPath11);
			}
		}
		else
		{
			GraphicsPath graphicsPath12 = new GraphicsPath();
			graphicsPath12.AddPolygon(new PointF[4]
			{
				pointF_0[1],
				pointF_0[2],
				pointF_0[6],
				pointF_0[5]
			});
			using (Brush brush_12 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath12), 0.5f))
			{
				interface42_0.imethod_33(brush_12, graphicsPath12);
			}
			interface42_0.imethod_18(pen_, graphicsPath12);
		}
	}

	private static void smethod_18(Interface42 interface42_0, Class787 class787_0, Class796 class796_0, PointF[] pointF_0, PointF[] pointF_1, PointF[] pointF_2, PointF[] pointF_3)
	{
		Class788 class788_ = class796_0.method_3();
		using Pen pen_ = Struct29.smethod_5(class796_0.method_4());
		if (class787_0.Rotation > 90 && class787_0.Rotation != 360 && (class787_0.Rotation <= 270 || class787_0.Rotation >= 360))
		{
			if ((class787_0.Rotation > 90 && class787_0.Rotation <= 180) || (class787_0.Rotation > 180 && class787_0.Rotation <= 270))
			{
				PointF[] array = new PointF[pointF_1.Length * 2];
				for (int i = 0; i < pointF_1.Length; i++)
				{
					ref PointF reference = ref array[i];
					reference = pointF_1[i];
					ref PointF reference2 = ref array[array.Length - 1 - i];
					reference2 = pointF_3[i];
				}
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddPolygon(array);
				using (Brush brush_ = Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath)))
				{
					interface42_0.imethod_33(brush_, graphicsPath);
				}
				interface42_0.imethod_18(pen_, graphicsPath);
			}
		}
		else
		{
			PointF[] array2 = new PointF[pointF_0.Length * 2];
			for (int j = 0; j < pointF_0.Length; j++)
			{
				ref PointF reference3 = ref array2[j];
				reference3 = pointF_0[j];
				ref PointF reference4 = ref array2[array2.Length - 1 - j];
				reference4 = pointF_2[j];
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPolygon(array2);
			using (Brush brush_2 = Struct18.smethod_1(class788_, Class1181.smethod_1(graphicsPath2)))
			{
				interface42_0.imethod_33(brush_2, graphicsPath2);
			}
			interface42_0.imethod_18(pen_, graphicsPath2);
		}
	}

	private static PointF[] smethod_19(Class787 class787_0, float float_0, float float_1, float float_2, Interface42 interface42_0)
	{
		PointF[] array = new PointF[2];
		float num = class787_0.method_13().method_2();
		if (float_0 <= num)
		{
			float float_3 = 2f * (num - float_0);
			ref PointF reference = ref array[0];
			reference = Struct25.smethod_47(class787_0, float_2, float_3, float_1, 0);
			ref PointF reference2 = ref array[1];
			reference2 = Struct25.smethod_47(class787_0, float_2, float_3, float_1, 3);
		}
		else
		{
			float float_3 = 2f * (float_0 - num);
			ref PointF reference3 = ref array[0];
			reference3 = Struct25.smethod_47(class787_0, float_2, float_3, float_1, 1);
			ref PointF reference4 = ref array[1];
			reference4 = Struct25.smethod_47(class787_0, float_2, float_3, float_1, 2);
		}
		return array;
	}

	private static void smethod_20(Interface42 interface42_0, Class787 class787_0, Class796[] class796_0, IList ilist_0)
	{
		if (ilist_0.Count < 2)
		{
			return;
		}
		IList list = (IList)ilist_0[0];
		if (ilist_0.Count < 2)
		{
			return;
		}
		_ = (IList)ilist_0[1];
		IList list2 = (IList)ilist_0[ilist_0.Count - 1];
		for (int i = 1; i < list.Count; i++)
		{
			if (class787_0.Elevation >= 0)
			{
				int num = ilist_0.Count - 1;
				Class796 @class = class796_0[num - 1];
				Class788 class788_ = @class.method_3();
				using Pen pen_ = Struct29.smethod_5(@class.method_4());
				PointF[] crossPoints;
				bool flag = smethod_22(list2, list, i, out crossPoints);
				if (!class787_0.method_9().IsPlotOrderReversed)
				{
					if (!smethod_21(list2, list, i))
					{
						continue;
					}
					IList list3 = (IList)ilist_0[num];
					if (list3.Count > i)
					{
						PointF[] array = new PointF[4];
						PointF[] array2 = (PointF[])list3[i - 1];
						ref PointF reference = ref array[0];
						reference = array2[0];
						ref PointF reference2 = ref array[1];
						reference2 = array2[1];
						array2 = (PointF[])list3[i];
						ref PointF reference3 = ref array[2];
						reference3 = array2[1];
						ref PointF reference4 = ref array[3];
						reference4 = array2[0];
						GraphicsPath graphicsPath = new GraphicsPath();
						graphicsPath.AddPolygon(array);
						using (Brush brush_ = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath), 2f / 3f))
						{
							interface42_0.imethod_33(brush_, graphicsPath);
						}
						interface42_0.imethod_18(pen_, graphicsPath);
					}
					continue;
				}
				if (!flag)
				{
					continue;
				}
				IList list4 = (IList)ilist_0[num];
				PointF[] array3 = new PointF[4];
				PointF[] array4 = (PointF[])list4[i - 1];
				if (crossPoints[0].Y >= array4[0].Y)
				{
					PointF[] array5 = (PointF[])list[i - 1];
					ref PointF reference5 = ref array3[0];
					reference5 = array5[0];
					ref PointF reference6 = ref array3[1];
					reference6 = array5[1];
					ref PointF reference7 = ref array3[2];
					reference7 = crossPoints[1];
					ref PointF reference8 = ref array3[3];
					reference8 = crossPoints[0];
					GraphicsPath graphicsPath2 = new GraphicsPath();
					graphicsPath2.AddPolygon(array3);
					using (Brush brush_2 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath2), 2f / 3f))
					{
						interface42_0.imethod_33(brush_2, graphicsPath2);
					}
					interface42_0.imethod_18(pen_, graphicsPath2);
				}
				else
				{
					ref PointF reference9 = ref array3[0];
					reference9 = array4[0];
					ref PointF reference10 = ref array3[1];
					reference10 = array4[1];
					ref PointF reference11 = ref array3[2];
					reference11 = crossPoints[1];
					ref PointF reference12 = ref array3[3];
					reference12 = crossPoints[0];
					GraphicsPath graphicsPath3 = new GraphicsPath();
					graphicsPath3.AddPolygon(array3);
					using (Brush brush_3 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath3), 2f / 3f))
					{
						interface42_0.imethod_33(brush_3, graphicsPath3);
					}
					interface42_0.imethod_18(pen_, graphicsPath3);
				}
				array4 = (PointF[])list4[i];
				if (crossPoints[0].Y >= array4[0].Y)
				{
					PointF[] array6 = (PointF[])list[i];
					ref PointF reference13 = ref array3[0];
					reference13 = array6[0];
					ref PointF reference14 = ref array3[1];
					reference14 = array6[1];
					ref PointF reference15 = ref array3[2];
					reference15 = crossPoints[1];
					ref PointF reference16 = ref array3[3];
					reference16 = crossPoints[0];
					GraphicsPath graphicsPath4 = new GraphicsPath();
					graphicsPath4.AddPolygon(array3);
					using (Brush brush_4 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath4), 2f / 3f))
					{
						interface42_0.imethod_33(brush_4, graphicsPath4);
					}
					interface42_0.imethod_18(pen_, graphicsPath4);
				}
				else
				{
					ref PointF reference17 = ref array3[0];
					reference17 = array4[0];
					ref PointF reference18 = ref array3[1];
					reference18 = array4[1];
					ref PointF reference19 = ref array3[2];
					reference19 = crossPoints[1];
					ref PointF reference20 = ref array3[3];
					reference20 = crossPoints[0];
					GraphicsPath graphicsPath5 = new GraphicsPath();
					graphicsPath5.AddPolygon(array3);
					using (Brush brush_5 = Struct18.smethod_3(class788_, Class1181.smethod_1(graphicsPath5), 2f / 3f))
					{
						interface42_0.imethod_33(brush_5, graphicsPath5);
					}
					interface42_0.imethod_18(pen_, graphicsPath5);
				}
			}
			else
			{
				_ = class787_0.method_9().IsPlotOrderReversed;
			}
		}
		for (int j = 1; j < ilist_0.Count; j++)
		{
			Class796 class2 = class796_0[j - 1];
			Class788 class788_2 = class2.method_3();
			using Pen pen_2 = Struct29.smethod_5(class2.method_4());
			IList list5 = (IList)ilist_0[j - 1];
			IList list6 = (IList)ilist_0[j];
			PointF[] array7;
			PointF[] array8;
			if (class787_0.Rotation <= 180)
			{
				array7 = (PointF[])list5[list5.Count - 1];
				array8 = (PointF[])list6[list6.Count - 1];
			}
			else
			{
				array7 = (PointF[])list5[0];
				array8 = (PointF[])list6[0];
			}
			GraphicsPath graphicsPath6 = new GraphicsPath();
			graphicsPath6.AddPolygon(new PointF[4]
			{
				array7[0],
				array7[1],
				array8[1],
				array8[0]
			});
			using (Brush brush_6 = Struct18.smethod_3(class788_2, Class1181.smethod_1(graphicsPath6), 0.5f))
			{
				interface42_0.imethod_33(brush_6, graphicsPath6);
			}
			interface42_0.imethod_18(pen_2, graphicsPath6);
		}
		for (int k = 1; k < ilist_0.Count; k++)
		{
			Class796 class3 = class796_0[k - 1];
			Class788 class788_3 = class3.method_3();
			using Pen pen_3 = Struct29.smethod_5(class3.method_4());
			IList list7 = (IList)ilist_0[k - 1];
			IList list8 = (IList)ilist_0[k];
			int num2 = list8.Count * 2;
			PointF[] array9 = new PointF[num2];
			for (int l = 0; l < list7.Count; l++)
			{
				if (list8.Count > l)
				{
					PointF[] array10 = (PointF[])list7[l];
					PointF[] array11 = (PointF[])list8[l];
					if (class787_0.Rotation > 90 && class787_0.Rotation != 360 && (class787_0.Rotation <= 270 || class787_0.Rotation >= 360))
					{
						ref PointF reference21 = ref array9[l];
						reference21 = array10[1];
						ref PointF reference22 = ref array9[num2 - l - 1];
						reference22 = array11[1];
					}
					else
					{
						ref PointF reference23 = ref array9[l];
						reference23 = array10[0];
						ref PointF reference24 = ref array9[num2 - l - 1];
						reference24 = array11[0];
					}
				}
			}
			GraphicsPath graphicsPath7 = new GraphicsPath();
			graphicsPath7.AddPolygon(array9);
			using (Brush brush_7 = Struct18.smethod_1(class788_3, Class1181.smethod_1(graphicsPath7)))
			{
				interface42_0.imethod_33(brush_7, graphicsPath7);
			}
			interface42_0.imethod_18(pen_3, graphicsPath7);
		}
	}

	private static bool smethod_21(IList ilist_0, IList ilist_1, int int_0)
	{
		if (ilist_0.Count <= int_0)
		{
			return true;
		}
		PointF pointF = ((PointF[])ilist_0[int_0 - 1])[0];
		PointF pointF2 = ((PointF[])ilist_0[int_0])[0];
		PointF pointF3 = ((PointF[])ilist_1[int_0 - 1])[0];
		PointF pointF4 = ((PointF[])ilist_1[int_0])[0];
		if (pointF.Y < pointF3.Y && pointF2.Y < pointF4.Y)
		{
			return true;
		}
		return false;
	}

	private static bool smethod_22(IList seriesLinePoint1, IList seriesLinePoint0, int j, out PointF[] crossPoints)
	{
		crossPoints = new PointF[2];
		if (seriesLinePoint1.Count <= j)
		{
			return false;
		}
		PointF point = ((PointF[])seriesLinePoint1[j - 1])[0];
		PointF point2 = ((PointF[])seriesLinePoint1[j])[0];
		PointF point3 = ((PointF[])seriesLinePoint0[j - 1])[0];
		PointF point4 = ((PointF[])seriesLinePoint0[j])[0];
		PointF crossPoint;
		bool result = smethod_16(point, point2, point3, point4, out crossPoint);
		point = ((PointF[])seriesLinePoint1[j - 1])[1];
		point2 = ((PointF[])seriesLinePoint1[j])[1];
		point3 = ((PointF[])seriesLinePoint0[j - 1])[1];
		point4 = ((PointF[])seriesLinePoint0[j])[1];
		smethod_16(point, point2, point3, point4, out var crossPoint2);
		crossPoints[0] = crossPoint;
		crossPoints[1] = crossPoint2;
		return result;
	}
}
