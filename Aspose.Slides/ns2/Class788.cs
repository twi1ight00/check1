using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns36;
using ns37;
using ns38;

namespace ns2;

internal class Class788
{
	private Rectangle rectangle_0;

	private Font font_0;

	private Color color_0;

	private bool bool_0;

	private bool bool_1 = true;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private float float_0;

	private float float_1;

	private int int_4;

	private bool bool_2;

	private List<Class787> list_0;

	public Font TextFont => font_0;

	public Color FontColor => color_0;

	public Rectangle DrawingRect
	{
		get
		{
			return rectangle_0;
		}
		set
		{
			rectangle_0 = value;
		}
	}

	public bool IsTransparent => bool_0;

	public bool IsVertical
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public int FontHeight => int_0;

	public int FrameBlank => int_1;

	public int TextSpan => int_2;

	public int KeyHeight => int_3;

	public float OneColumnSpan => float_0;

	public int WideKeyWidth => int_4;

	public float MultiColumnSpan => float_1;

	public bool IsRenderedLegendByPoint => bool_2;

	public List<Class787> DisplayedEntryProperties
	{
		get
		{
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	internal bool IsWideKey
	{
		get
		{
			if (DisplayedEntryProperties == null)
			{
				return false;
			}
			foreach (Class787 displayedEntryProperty in DisplayedEntryProperties)
			{
				if (displayedEntryProperty.EntryType != Enum144.const_1)
				{
					if (displayedEntryProperty.EntryType == Enum144.const_0 && displayedEntryProperty.Series.IsWideKeyInLegend)
					{
						return true;
					}
					continue;
				}
				return true;
			}
			return false;
		}
	}

	internal Class788(Legend legend, Class784 renderContext)
	{
		Chart chart = (Chart)legend.Chart;
		color_0 = renderContext.method_0((chart.Style + 1 > StyleType.Style41) ? ColorSchemeIndex.Light1 : ColorSchemeIndex.Dark1);
		color_0 = chart.method_14(legend.TextFormatManager, null, color_0, renderContext.Chart2007);
		font_0 = chart.method_15(legend.TextFormatManager, null, isBold: false, isTitle: false);
		switch (legend.Format.Fill.FillType)
		{
		case FillType.NoFill:
			bool_0 = true;
			break;
		case FillType.Solid:
		{
			Color color;
			if (legend.Format.Fill.SolidFillColor.SchemeColor != SchemeColor.NotDefined)
			{
				ColorFormat colorFormat = ((Slide)chart.Slide).method_2(legend.Format.Fill.SolidFillColor.SchemeColor);
				((ColorOperationCollection)colorFormat.ColorTransform).list_0 = ((ColorOperationCollection)legend.Format.Fill.SolidFillColor.ColorTransform).list_0;
				color = colorFormat.Color;
			}
			else
			{
				color = legend.Format.Fill.SolidFillColor.Color;
			}
			if (color.A <= 250)
			{
				bool_0 = true;
			}
			break;
		}
		}
		int_0 = Struct39.smethod_22(renderContext.Graphics, TextFont);
		int_1 = Struct41.smethod_5((float)Struct39.smethod_22(renderContext.Graphics, TextFont) * 0.2f);
		int num = Struct41.smethod_5((float)Struct39.smethod_22(renderContext.Graphics, TextFont) * 0.2f);
		int_2 = ((num < 4) ? 4 : num);
		float num2 = ((TextFont.Size <= 6f) ? 0.6f : 0.465f);
		num = Struct41.smethod_5((float)int_0 * num2);
		int_3 = ((num < 3) ? 3 : num);
		float num3 = (float)int_0 * 0.25f;
		float_0 = ((num3 < 2f) ? (-2f) : (0f - num3));
		num2 = ((TextFont.Size <= 6f) ? 0f : (TextFont.Size * 0.02f + 0.01f));
		num3 = (float)int_0 * num2;
		float_1 = ((num3 > 10f) ? (-10f) : (0f - num3));
		bool_2 = Struct31.smethod_7(chart);
		list_0 = new List<Class787>();
		method_1(legend, renderContext.Chart2007);
		int_4 = (method_0() ? 36 : 27);
	}

	private bool method_0()
	{
		foreach (Class787 displayedEntryProperty in DisplayedEntryProperties)
		{
			if (displayedEntryProperty.EntryType == Enum144.const_0)
			{
				Class759 series = displayedEntryProperty.Series;
				if (series != null && series.IsWideKeyInLegend && series.LineInternal.LineStyleInternal.DashStyle != 0)
				{
					return true;
				}
			}
			else
			{
				Class763 trendline = displayedEntryProperty.Trendline;
				if (trendline != null && trendline.BorderInternal.LineStyleInternal.DashStyle != 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	internal void method_1(Legend legend, Class740 chart2007)
	{
		List<Class759> list = chart2007.NSeriesInternal.method_9();
		bool flag = true;
		for (int i = 0; i < list.Count; i++)
		{
			Class759 @class = list[i];
			if (i == 0 && @class.PlotOnSecondAxis)
			{
				flag = false;
			}
			LegendEntryProperties legendEntryProperties = (LegendEntryProperties)legend.Entries[@class.ID];
			if (!legendEntryProperties.Hide)
			{
				Class787 class2 = new Class787(legendEntryProperties, chart2007);
				class2.Name = @class.Name;
				class2.EntryType = Enum144.const_0;
				class2.Series = @class;
				DisplayedEntryProperties.Add(class2);
			}
		}
		List<Interface23> list2 = (flag ? chart2007.NSeriesInternal.method_14() : chart2007.NSeriesInternal.method_15());
		for (int j = 0; j < list2.Count; j++)
		{
			Class763 class3 = (Class763)list2[j];
			Class787 class4 = new Class787((Chart)legend.Chart, chart2007);
			class4.Name = class3.Name;
			class4.EntryType = Enum144.const_1;
			class4.Series = class3.TrendlinesInternal.ASeriesInternal;
			class4.Trendline = class3;
			DisplayedEntryProperties.Add(class4);
		}
	}
}
