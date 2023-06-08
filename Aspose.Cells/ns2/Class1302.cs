using System.Collections;
using System.Drawing;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;

namespace ns2;

internal class Class1302
{
	internal static Color[] smethod_0(Workbook workbook_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < workbook_0.Worksheets.method_52().Count; i++)
		{
			Aspose.Cells.Font font_ = (Aspose.Cells.Font)workbook_0.Worksheets.method_52()[i];
			smethod_3(font_, arrayList);
		}
		for (int j = 0; j < workbook_0.Worksheets.method_58().Count; j++)
		{
			Style style_ = workbook_0.Worksheets.method_58()[j];
			smethod_1(style_, arrayList);
		}
		for (int k = 0; k < workbook_0.Worksheets.method_56().Count; k++)
		{
			Style style_2 = workbook_0.Worksheets.method_56()[k];
			smethod_2(style_2, arrayList);
		}
		for (int l = 0; l < workbook_0.Worksheets.Count; l++)
		{
			ChartCollection charts = workbook_0.Worksheets[l].Charts;
			for (int m = 0; m < charts.Count; m++)
			{
				smethod_4(charts[m], arrayList);
			}
		}
		Color[] array = new Color[arrayList.Count];
		for (int n = 0; n < arrayList.Count; n++)
		{
			ref Color reference = ref array[n];
			reference = (Color)arrayList[n];
		}
		return array;
	}

	internal static void smethod_1(Style style_0, ArrayList arrayList_0)
	{
		smethod_3(style_0.Font, arrayList_0);
		if (style_0.IsGradient)
		{
			smethod_12(arrayList_0, style_0.ForegroundColor);
			smethod_12(arrayList_0, style_0.BackgroundColor);
			return;
		}
		switch (style_0.Pattern)
		{
		default:
			smethod_12(arrayList_0, style_0.ForegroundColor);
			smethod_12(arrayList_0, style_0.BackgroundColor);
			break;
		case BackgroundType.None:
			break;
		case BackgroundType.Solid:
			smethod_12(arrayList_0, style_0.ForegroundColor);
			break;
		}
	}

	internal static void smethod_2(Style style_0, ArrayList arrayList_0)
	{
		if (style_0.IsModified(StyleModifyFlag.FontColor))
		{
			smethod_3(style_0.Font, arrayList_0);
		}
		if (style_0.IsModified(StyleModifyFlag.ForegroundColor))
		{
			smethod_12(arrayList_0, style_0.ForegroundColor);
		}
		if (style_0.IsModified(StyleModifyFlag.BackgroundColor))
		{
			smethod_12(arrayList_0, style_0.BackgroundColor);
		}
		if (style_0.IsGradient)
		{
			smethod_12(arrayList_0, style_0.ForegroundColor);
			smethod_12(arrayList_0, style_0.BackgroundColor);
		}
	}

	internal static void smethod_3(Aspose.Cells.Font font_0, ArrayList arrayList_0)
	{
		if (!font_0.Color.IsEmpty)
		{
			smethod_12(arrayList_0, font_0.Color);
		}
	}

	internal static void smethod_4(Chart chart_0, ArrayList arrayList_0)
	{
		smethod_9(chart_0.ChartArea, arrayList_0);
		smethod_9(chart_0.PlotArea, arrayList_0);
		smethod_9(chart_0.Legend, arrayList_0);
		chart_0.method_25();
		if (chart_0.method_20() != null)
		{
			smethod_9(chart_0.method_20(), arrayList_0);
		}
		if (chart_0.CategoryAxis.IsVisible)
		{
			smethod_8(chart_0.CategoryAxis, arrayList_0);
		}
		if (chart_0.ValueAxis.IsVisible)
		{
			smethod_8(chart_0.ValueAxis, arrayList_0);
		}
		if (chart_0.method_21() != null && chart_0.SeriesAxis.IsVisible)
		{
			smethod_8(chart_0.SeriesAxis, arrayList_0);
		}
		if (chart_0.SecondCategoryAxis.IsVisible)
		{
			smethod_8(chart_0.SecondCategoryAxis, arrayList_0);
		}
		if (chart_0.SecondValueAxis.IsVisible)
		{
			smethod_8(chart_0.SecondValueAxis, arrayList_0);
		}
		for (int i = 0; i < chart_0.NSeries.Count; i++)
		{
			Series series_ = chart_0.NSeries[i];
			smethod_6(series_, arrayList_0);
		}
		if (ChartCollection.smethod_0(chart_0.Type))
		{
			if (chart_0.method_28() != null)
			{
				smethod_5(chart_0.method_28(), arrayList_0);
			}
			if (chart_0.method_29() != null)
			{
				smethod_5(chart_0.method_29(), arrayList_0);
			}
		}
	}

	internal static void smethod_5(Floor floor_0, ArrayList arrayList_0)
	{
		smethod_11(floor_0, arrayList_0);
		if (floor_0.line_0 != null)
		{
			smethod_10(floor_0.line_0, arrayList_0);
		}
	}

	internal static void smethod_6(Series series_0, ArrayList arrayList_0)
	{
		if (series_0.method_24() != null)
		{
			smethod_9(series_0.method_24(), arrayList_0);
		}
		if (series_0.method_5() != null)
		{
			smethod_11(series_0.method_5(), arrayList_0);
		}
		if (series_0.method_6() != null)
		{
			smethod_10(series_0.method_6(), arrayList_0);
		}
		if (series_0.method_3() != null)
		{
			ArrayList arrayList_ = series_0.method_3().arrayList_0;
			for (int i = 0; i < arrayList_.Count; i++)
			{
				ChartPoint chartPoint_ = (ChartPoint)arrayList_[i];
				smethod_7(chartPoint_, arrayList_0);
			}
		}
	}

	internal static void smethod_7(ChartPoint chartPoint_0, ArrayList arrayList_0)
	{
		if (chartPoint_0.method_9() != null)
		{
			smethod_9(chartPoint_0.method_9(), arrayList_0);
		}
		if (chartPoint_0.method_6() != null)
		{
			smethod_11(chartPoint_0.method_6(), arrayList_0);
		}
		if (chartPoint_0.method_5() != null)
		{
			smethod_10(chartPoint_0.method_5(), arrayList_0);
		}
	}

	internal static void smethod_8(Axis axis_0, ArrayList arrayList_0)
	{
		smethod_9(axis_0.method_20(), arrayList_0);
	}

	internal static void smethod_9(ChartFrame chartFrame_0, ArrayList arrayList_0)
	{
		if (chartFrame_0.method_12() != null)
		{
			smethod_3(chartFrame_0.Font, arrayList_0);
		}
		if (chartFrame_0.method_11() != null)
		{
			smethod_11(chartFrame_0.method_11(), arrayList_0);
		}
		if (chartFrame_0.method_10() != null)
		{
			smethod_10(chartFrame_0.method_10(), arrayList_0);
		}
	}

	internal static void smethod_10(Line line_0, ArrayList arrayList_0)
	{
		if (line_0.IsVisible && !line_0.IsAutomaticColor)
		{
			smethod_12(arrayList_0, line_0.Color);
		}
	}

	internal static void smethod_11(Area area_0, ArrayList arrayList_0)
	{
		if (area_0.Formatting == FormattingType.Custom)
		{
			smethod_12(arrayList_0, area_0.ForegroundColor);
		}
	}

	internal static void smethod_12(ArrayList arrayList_0, Color color_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			if ((((Color)arrayList_0[i]).ToArgb() & 0xFFFFFF) == (color_0.ToArgb() & 0xFFFFFF))
			{
				return;
			}
		}
		arrayList_0.Add(color_0);
	}
}
