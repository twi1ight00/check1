using System.Drawing;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns31;
using ns33;
using ns34;
using ns7;

namespace ns3;

internal class Class868
{
	internal void Calculate(Chart chart_0, bool bool_0)
	{
		if (chart_0.method_14().Workbook.method_23())
		{
			method_3(chart_0, bool_0);
		}
		else
		{
			method_0(chart_0, bool_0);
		}
	}

	private void method_0(Chart chart_0, bool bool_0)
	{
		using Class870 class2 = new Class870(null);
		Class787 @class = null;
		try
		{
			@class = class2.method_2(chart_0);
			if (@class == null)
			{
				return;
			}
			Rectangle rectangle = @class.method_27();
			Rectangle rectangle2 = @class.method_8().method_15();
			if (!@class.method_15())
			{
				chart_0.PlotArea.method_30(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
			}
			else
			{
				chart_0.PlotArea.method_30(rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height);
			}
			chart_0.PlotArea.method_40(rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height);
			Rectangle rectangle3 = @class.method_6().method_0().method_15();
			Legend legend = chart_0.Legend;
			legend.method_30(rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height);
			method_1(chart_0, @class);
			method_6(chart_0.ValueAxis, @class.method_9());
			method_5(chart_0.CategoryAxis, @class.CategoryAxis, @class.vmethod_0());
			method_6(chart_0.SecondValueAxis, @class.method_10());
			method_5(chart_0.SecondCategoryAxis, @class.imethod_3(), @class.vmethod_0());
			Title title = chart_0.method_20();
			if (title != null)
			{
				if (title.IsAutoText && @class.Title.Text != "")
				{
					title.Text = @class.Title.Text;
				}
				if (title.Text != null && title.Text != "")
				{
					Rectangle rectangle4 = @class.method_12().method_0().method_16();
					title.method_35(rectangle4.X, rectangle4.Y, rectangle4.Width, rectangle4.Height);
					Rectangle rectangle5 = @class.method_12().method_0().method_15();
					title.method_30(rectangle5.X, rectangle5.Y, rectangle5.Width, rectangle5.Height);
					title.X = rectangle5.X;
					title.Y = rectangle5.Y;
				}
			}
			method_20(chart_0.NSeries, @class.method_7());
		}
		finally
		{
			if (@class != null && @class.imethod_0() != null)
			{
				@class.imethod_0().Dispose();
			}
		}
	}

	private void method_1(Chart chart_0, Class787 class787_0)
	{
		method_2(chart_0.CategoryAxis, class787_0.method_1());
		method_2(chart_0.SecondCategoryAxis, class787_0.method_2());
		method_2(chart_0.ValueAxis, class787_0.method_9());
		method_2(chart_0.SecondCategoryAxis, class787_0.method_10());
	}

	private void method_2(Axis axis_0, Class789 class789_0)
	{
		axis_0.method_1(Class869.smethod_37(class789_0.method_4()));
		Title title = axis_0.method_20();
		if (title != null)
		{
			if (title.IsAutoText && class789_0.Title.Text != "")
			{
				title.Text = class789_0.Title.Text;
			}
			if (title.Text != null && title.Text != "")
			{
				Rectangle rectangle_ = class789_0.method_10().method_0().rectangle_1;
				rectangle_.X = rectangle_.X * 4000 / class789_0.Chart.Width;
				rectangle_.Y = rectangle_.Y * 4000 / class789_0.Chart.Height;
				rectangle_.Width = rectangle_.Width * 4000 / class789_0.Chart.Width;
				rectangle_.Height = rectangle_.Height * 4000 / class789_0.Chart.Height;
				title.method_35(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
				Rectangle rectangle = class789_0.method_10().method_0().method_15();
				title.method_30(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
				title.X = rectangle.X;
				title.Y = rectangle.Y;
			}
		}
	}

	private void method_3(Chart chart_0, bool bool_0)
	{
		using Class870 class2 = new Class870(null);
		Class821 @class = null;
		try
		{
			@class = class2.method_3(chart_0);
			if (@class == null)
			{
				return;
			}
			Rectangle rectangle = @class.method_27();
			Rectangle rectangle2 = @class.method_8().method_13();
			if (!@class.method_17())
			{
				chart_0.PlotArea.method_30(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
			}
			else
			{
				chart_0.PlotArea.method_30(rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height);
			}
			chart_0.PlotArea.method_40(rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height);
			Rectangle rectangle3 = @class.method_6().method_0().method_13();
			Legend legend = chart_0.Legend;
			legend.method_30(rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height);
			method_6(chart_0.ValueAxis, @class.method_9());
			method_5(chart_0.CategoryAxis, @class.CategoryAxis, @class.vmethod_0());
			method_6(chart_0.SecondValueAxis, @class.method_10());
			method_5(chart_0.SecondCategoryAxis, @class.imethod_3(), @class.vmethod_0());
			method_10(chart_0, @class);
			Title title = chart_0.method_20();
			if (title != null)
			{
				if (title.IsAutoText && @class.Title.Text != "")
				{
					title.Text = @class.Title.Text;
				}
				if (title.Text != null && title.Text != "")
				{
					Rectangle rectangle4 = @class.method_12().method_0().method_14();
					title.method_35(rectangle4.X, rectangle4.Y, rectangle4.Width, rectangle4.Height);
					Rectangle rectangle5 = @class.method_12().method_0().method_13();
					title.method_30(rectangle5.X, rectangle5.Y, rectangle5.Width, rectangle5.Height);
				}
			}
			method_4(chart_0.CategoryAxis, @class.method_1());
			method_4(chart_0.SecondCategoryAxis, @class.method_2());
			method_4(chart_0.ValueAxis, @class.method_9());
			method_4(chart_0.SecondValueAxis, @class.method_10());
			method_12(chart_0, @class);
		}
		finally
		{
			if (@class != null && @class.imethod_0() != null)
			{
				@class.imethod_0().Dispose();
			}
		}
	}

	private void method_4(Axis axis_0, Class823 class823_0)
	{
		Title title = axis_0.method_20();
		if (title != null)
		{
			if (title.IsAutoText && class823_0.Title.Text != "")
			{
				title.Text = class823_0.Title.Text;
			}
			if (title.Text != null && title.Text != "")
			{
				Rectangle rectangle_ = class823_0.method_11().method_0().rectangle_1;
				rectangle_.X = rectangle_.X * 4000 / class823_0.Chart.Width;
				rectangle_.Y = rectangle_.Y * 4000 / class823_0.Chart.Height;
				rectangle_.Width = rectangle_.Width * 4000 / class823_0.Chart.Width;
				rectangle_.Height = rectangle_.Height * 4000 / class823_0.Chart.Height;
				title.method_35(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
				Rectangle rectangle = class823_0.method_11().method_0().method_13();
				title.method_30(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
			}
		}
	}

	private void method_5(Axis axis_0, Interface9 interface9_0, bool bool_0)
	{
		if ((axis_0.CategoryType == CategoryType.AutomaticScale || interface9_0.CategoryType == Enum64.const_1) && axis_0.method_16())
		{
			axis_0.method_15(interface9_0.TickLabelSpacing);
		}
		axis_0.method_8(interface9_0.MajorUnit);
		if (interface9_0.CategoryType == Enum64.const_0)
		{
			axis_0.method_5(interface9_0.MaxValue);
		}
		else
		{
			axis_0.method_5(interface9_0.MaxValue);
			axis_0.method_24(method_11(interface9_0.MajorUnitScale));
			axis_0.method_21(method_11(interface9_0.BaseUnitScale));
		}
		axis_0.method_10(interface9_0.MinorUnit);
		if (interface9_0.CategoryType == Enum64.const_0)
		{
			axis_0.method_4(interface9_0.MinValue);
			return;
		}
		axis_0.method_4(interface9_0.MinValue);
		axis_0.method_25(method_11(interface9_0.MinorUnitScale));
	}

	private void method_6(Axis axis_0, Interface9 interface9_0)
	{
		axis_0.IsVisible = interface9_0.IsVisible;
		if (axis_0.method_7())
		{
			axis_0.method_8(interface9_0.MajorUnit);
		}
		if (axis_0.method_6())
		{
			axis_0.method_5(interface9_0.MaxValue);
		}
		if (axis_0.method_9())
		{
			axis_0.method_10(interface9_0.MinorUnit);
		}
		if (axis_0.method_3())
		{
			axis_0.method_4(interface9_0.MinValue);
		}
	}

	private Class844 method_7(Class842 class842_0, int int_0)
	{
		if (int_0 < class842_0.Count)
		{
			Class844 @class = class842_0.method_9(int_0);
			if (@class.vmethod_4() == int_0)
			{
				return @class;
			}
			return method_8(class842_0, int_0, 0, class842_0.Count - 1);
		}
		return null;
	}

	private Class844 method_8(Class842 class842_0, int int_0, int int_1, int int_2)
	{
		switch (int_2 - int_1)
		{
		default:
		{
			Class844 class4 = class842_0.method_9(int_1);
			Class844 class5 = class842_0.method_9(int_2);
			if (int_0 > class5.Index)
			{
				return null;
			}
			if (int_0 == class5.Index)
			{
				return class5;
			}
			if (int_0 > class4.Index && int_0 < class5.Index)
			{
				int num = (int_2 + int_1) / 2;
				Class844 class6 = class842_0.method_9(num);
				if (int_0 > class6.Index)
				{
					if (int_2 - num == 1)
					{
						return null;
					}
					return method_8(class842_0, int_0, num + 1, int_2 - 1);
				}
				if (int_0 == class6.Index)
				{
					return class6;
				}
				if (num - int_1 == 1)
				{
					return null;
				}
				return method_8(class842_0, int_0, int_1 + 1, num - 1);
			}
			if (int_0 == class4.Index)
			{
				return class4;
			}
			return null;
		}
		case 0:
		{
			Class844 class3 = class842_0.method_9(int_1);
			if (int_0 == class3.Index)
			{
				return class3;
			}
			return null;
		}
		case 1:
		{
			Class844 @class = class842_0.method_9(int_1);
			Class844 class2 = class842_0.method_9(int_2);
			if (int_0 == @class.Index)
			{
				return @class;
			}
			if (int_0 == class2.Index)
			{
				return class2;
			}
			return null;
		}
		}
	}

	private Rectangle method_9(Rectangle rectangle_0, Interface7 interface7_0)
	{
		Rectangle empty = Rectangle.Empty;
		empty.X = (int)((double)((float)rectangle_0.X * 4000f / (float)interface7_0.Width) + 0.5);
		empty.Y = (int)((double)((float)rectangle_0.Y * 4000f / (float)interface7_0.Height) + 0.5);
		empty.Width = (int)((double)((float)rectangle_0.Width * 4000f / (float)interface7_0.Width) + 0.5);
		empty.Height = (int)((double)((float)rectangle_0.Height * 4000f / (float)interface7_0.Height) + 0.5);
		return empty;
	}

	private void method_10(Chart chart_0, Class821 class821_0)
	{
		if (class821_0.method_17())
		{
			Walls walls = chart_0.Walls;
			Class851 @class = class821_0.method_13();
			walls.CenterX = (int)((double)(@class.method_2() * 4000f / (float)class821_0.Width) + 0.5);
			walls.CenterY = (int)((double)((@class.Y - @class.Height / 2f) * 4000f / (float)class821_0.Height) + 0.5);
			walls.Width = (int)((double)(@class.Width * 4000f / (float)class821_0.Width) + 0.5);
			walls.Height = (int)((double)(@class.Height * 4000f / (float)class821_0.Height) + 0.5);
			walls.Depth = (int)((double)(@class.Depth * 4000f / (float)class821_0.Width) + 0.5);
		}
	}

	private TimeUnit method_11(Enum87 enum87_0)
	{
		return enum87_0 switch
		{
			Enum87.const_1 => TimeUnit.Months, 
			Enum87.const_2 => TimeUnit.Years, 
			_ => TimeUnit.Days, 
		};
	}

	private void method_12(Chart chart_0, Class821 class821_0)
	{
		if (class821_0 == null)
		{
			return;
		}
		bool flag = ChartCollection.smethod_0(chart_0.Type);
		method_13(chart_0.ChartArea, class821_0.method_3(), chart_0);
		method_13(chart_0.PlotArea, class821_0.method_8(), chart_0);
		method_13(chart_0.Legend, class821_0.method_6().method_0(), chart_0);
		if (chart_0.method_20() != null)
		{
			method_13(chart_0.Title, class821_0.method_12().method_0(), chart_0);
		}
		method_16(chart_0.CategoryAxis, class821_0.method_1());
		method_16(chart_0.SecondCategoryAxis, class821_0.method_2());
		method_16(chart_0.ValueAxis, class821_0.method_9());
		method_16(chart_0.SecondValueAxis, class821_0.method_10());
		method_17(chart_0.NSeries, class821_0.method_7(), class821_0);
		if (flag)
		{
			if (chart_0.PlotArea.Area.Formatting == FormattingType.Automatic)
			{
				chart_0.PlotArea.Area.Formatting = FormattingType.None;
			}
			method_14(chart_0.Walls, class821_0.method_14().method_1());
			SetBorder(chart_0.Walls.Border, class821_0.method_14().method_0(), chart_0);
			method_14(chart_0.Floor, class821_0.method_5().method_1());
			SetBorder(chart_0.Floor.Border, class821_0.method_5().method_0(), chart_0);
		}
	}

	private void method_13(ChartFrame chartFrame_0, Class829 class829_0, Chart chart_0)
	{
		method_14(chartFrame_0.Area, class829_0.method_1());
		SetBorder(chartFrame_0.Border, class829_0.method_2(), chart_0);
	}

	private void method_14(Area area_0, Class822 class822_0)
	{
		if (area_0.Formatting != 0)
		{
			return;
		}
		switch (class822_0.method_0())
		{
		case Enum52.const_8:
		case Enum52.const_9:
		case Enum52.const_10:
		case Enum52.const_12:
		case Enum52.const_13:
			class822_0.Formatting = Enum71.const_0;
			return;
		}
		if (class822_0.ForegroundColor.IsEmpty)
		{
			class822_0.Formatting = Enum71.const_0;
		}
		else
		{
			area_0.ForegroundColor = class822_0.ForegroundColor;
		}
	}

	private void SetBorder(Line line_0, Class840 class840_0, Chart chart_0)
	{
		if (line_0.method_26() != 0)
		{
			return;
		}
		if (class840_0.Color.IsEmpty)
		{
			line_0.method_27(Enum229.const_2);
			return;
		}
		line_0.Color = class840_0.Color;
		if (!line_0.method_28() && class840_0.LineStyle.Width != 0.0)
		{
			line_0.WeightPt = class840_0.LineStyle.Width * 72.0 / (double)chart_0.method_14().method_75();
		}
	}

	private void method_15(Marker marker_0, Class841 class841_0)
	{
		if (marker_0.MarkerStyle == ChartMarkerType.Automatic)
		{
			marker_0.method_1(Class869.smethod_3(class841_0.MarkerStyle));
		}
		method_14(marker_0.Area, class841_0.method_1());
		SetBorder(marker_0.Border, class841_0.method_2(), marker_0.Chart);
	}

	private void method_16(Axis axis_0, Class823 class823_0)
	{
		if (!class823_0.IsVisible)
		{
			return;
		}
		if (axis_0.method_20() != null)
		{
			method_13(axis_0.Title, class823_0.method_11().method_0(), axis_0.Chart);
			if (axis_0.Title.Area.Formatting == FormattingType.Automatic)
			{
				axis_0.Title.Area.Formatting = FormattingType.None;
			}
		}
		if (axis_0.method_18() != null)
		{
			method_13(axis_0.DisplayUnitLabel, class823_0.method_12().method_2(), axis_0.Chart);
			if (axis_0.DisplayUnitLabel.Area.Formatting == FormattingType.Automatic)
			{
				axis_0.DisplayUnitLabel.Area.Formatting = FormattingType.None;
			}
		}
		SetBorder(axis_0.AxisLine, class823_0.method_5(), axis_0.Chart);
		SetBorder(axis_0.MajorGridLines, class823_0.method_8(), axis_0.Chart);
		SetBorder(axis_0.MinorGridLines, class823_0.method_8(), axis_0.Chart);
	}

	private void method_17(SeriesCollection seriesCollection_0, Class842 class842_0, Class821 class821_0)
	{
		for (int i = 0; i < seriesCollection_0.Count; i++)
		{
			Series series = seriesCollection_0[i];
			Class844 @class = method_7(class842_0, series.method_0());
			if (@class == null)
			{
				continue;
			}
			series.method_14(@class.Name);
			if (!ChartCollection.smethod_3(series.Type))
			{
				method_14(series.Area, @class.method_6());
				SetBorder(series.Border, @class.method_5(), seriesCollection_0.Chart);
				method_15(series.Marker, @class.method_7());
			}
			for (int j = 0; j < @class.Points.Count; j++)
			{
				Class831 class2 = @class.method_9().method_1(j);
				ChartPoint chartPoint = series.Points[j];
				if (chartPoint == null || class2 == null)
				{
					continue;
				}
				chartPoint.XValue = class2.vmethod_3();
				chartPoint.YValue = class2.vmethod_5();
				float num = class2.method_8().X * 4000f / (float)@class.Chart.Width;
				float num2 = class2.method_8().Y * 4000f / (float)@class.Chart.Height;
				float num3 = class2.method_8().Width * 4000f / (float)@class.Chart.Width;
				float num4 = class2.method_8().Height * 4000f / (float)@class.Chart.Height;
				chartPoint.method_10((int)num, (int)num2);
				chartPoint.method_11((int)num3, (int)num4);
				if (chartPoint.method_6() != null || chartPoint.method_5() != null || chartPoint.method_7() != null || ChartCollection.smethod_3(series.Type))
				{
					method_14(chartPoint.Area, class2.method_3());
					SetBorder(chartPoint.Border, class2.method_4(), seriesCollection_0.Chart);
					method_15(chartPoint.Marker, class2.method_5());
				}
				if (class2.method_6().IsVisible)
				{
					Rectangle rectangle_ = class2.method_6().method_0().rectangle_1;
					if (class2.method_6().IsLegendKeyShown)
					{
						rectangle_.X -= Struct51.int_0;
						rectangle_.Width += 2 * Struct51.int_0;
					}
					rectangle_.Y -= Struct51.int_0;
					rectangle_.Height += 2 * Struct51.int_0;
					Rectangle rectangle = method_9(rectangle_, class821_0);
					chartPoint.DataLabels.method_35(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
					Rectangle rectangle_2 = class2.method_6().method_0().rectangle_0;
					Rectangle rectangle2 = method_9(rectangle_2, class821_0);
					chartPoint.DataLabels.method_30(rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height);
				}
			}
			for (int k = 0; k < series.TrendLines.Count; k++)
			{
				Trendline line_ = series.TrendLines[k];
				Class850 class3 = @class.method_10().method_1(k);
				if (class3 != null)
				{
					SetBorder(line_, class3.method_1(), seriesCollection_0.Chart);
				}
			}
		}
	}

	private void method_18(Area area_0, Class788 class788_0)
	{
		if (area_0.Formatting == FormattingType.Automatic)
		{
			if (class788_0.ForegroundColor.IsEmpty)
			{
				class788_0.Formatting = Enum71.const_0;
			}
			else
			{
				area_0.ForegroundColor = class788_0.ForegroundColor;
			}
		}
	}

	private void SetBorder(Line line_0, Class806 class806_0, Chart chart_0)
	{
		if (line_0.method_26() != 0)
		{
			return;
		}
		if (class806_0.Color.IsEmpty)
		{
			line_0.method_27(Enum229.const_2);
			return;
		}
		line_0.Color = class806_0.Color;
		if (!line_0.method_28() && class806_0.LineStyle.Width != 0.0)
		{
			line_0.WeightPt = class806_0.LineStyle.Width * 72.0 / (double)chart_0.method_14().method_75();
		}
	}

	private void method_19(Marker marker_0, Class807 class807_0)
	{
		if (marker_0.MarkerStyle == ChartMarkerType.Automatic)
		{
			marker_0.method_1(Class869.smethod_3(class807_0.MarkerStyle));
		}
		method_18(marker_0.Area, class807_0.method_0());
		SetBorder(marker_0.Border, class807_0.method_1(), marker_0.Chart);
	}

	private void method_20(SeriesCollection seriesCollection_0, Class808 class808_0)
	{
		for (int i = 0; i < seriesCollection_0.Count; i++)
		{
			Series series = seriesCollection_0[i];
			Class810 @class = method_21(class808_0, series.method_0());
			if (@class == null)
			{
				continue;
			}
			series.method_14(@class.Name);
			method_18(series.Area, @class.method_7());
			SetBorder(series.Border, @class.method_6(), seriesCollection_0.Chart);
			method_19(series.Marker, @class.method_8());
			for (int j = 0; j < @class.method_10().Count; j++)
			{
				Class796 class2 = @class.method_10().method_1(j);
				ChartPoint chartPoint = series.Points[j];
				if (chartPoint != null && class2 != null)
				{
					chartPoint.XValue = class2.vmethod_3();
					chartPoint.YValue = class2.vmethod_5();
					float num = class2.method_11().X * 4000f / (float)@class.Chart.Width;
					float num2 = class2.method_11().Y * 4000f / (float)@class.Chart.Height;
					float num3 = class2.method_11().Width * 4000f / (float)@class.Chart.Width;
					float num4 = class2.method_11().Height * 4000f / (float)@class.Chart.Height;
					chartPoint.method_10((int)num, (int)num2);
					chartPoint.method_11((int)num3, (int)num4);
					if (chartPoint.method_6() != null || chartPoint.method_5() != null || chartPoint.method_7() != null)
					{
						method_18(chartPoint.Area, class2.method_3());
						SetBorder(chartPoint.Border, class2.method_4(), seriesCollection_0.Chart);
						method_19(chartPoint.Marker, class2.method_5());
					}
				}
			}
		}
	}

	private Class810 method_21(Class808 class808_0, int int_0)
	{
		if (int_0 < class808_0.Count)
		{
			Class810 @class = class808_0.method_9(int_0);
			if (@class.vmethod_5() == int_0)
			{
				return @class;
			}
			return method_22(class808_0, int_0, 0, class808_0.Count - 1);
		}
		return null;
	}

	private Class810 method_22(Class808 class808_0, int int_0, int int_1, int int_2)
	{
		switch (int_2 - int_1)
		{
		default:
		{
			Class810 class4 = class808_0.method_9(int_1);
			Class810 class5 = class808_0.method_9(int_2);
			if (int_0 > class5.Index)
			{
				return null;
			}
			if (int_0 == class5.Index)
			{
				return class5;
			}
			if (int_0 > class4.Index && int_0 < class5.Index)
			{
				int num = (int_2 + int_1) / 2;
				Class810 class6 = class808_0.method_9(num);
				if (int_0 > class6.Index)
				{
					if (int_2 - num == 1)
					{
						return null;
					}
					return method_22(class808_0, int_0, num + 1, int_2 - 1);
				}
				if (int_0 == class6.Index)
				{
					return class6;
				}
				if (num - int_1 == 1)
				{
					return null;
				}
				return method_22(class808_0, int_0, int_1 + 1, num - 1);
			}
			if (int_0 == class4.Index)
			{
				return class4;
			}
			return null;
		}
		case 0:
		{
			Class810 class3 = class808_0.method_9(int_1);
			if (int_0 == class3.Index)
			{
				return class3;
			}
			return null;
		}
		case 1:
		{
			Class810 @class = class808_0.method_9(int_1);
			Class810 class2 = class808_0.method_9(int_2);
			if (int_0 == @class.Index)
			{
				return @class;
			}
			if (int_0 == class2.Index)
			{
				return class2;
			}
			return null;
		}
		}
	}
}
