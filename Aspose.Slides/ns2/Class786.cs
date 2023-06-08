using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Slides.Charts;
using ns36;
using ns37;
using ns38;

namespace ns2;

internal class Class786
{
	private List<Class787> list_0;

	private Rectangle rectangle_0;

	private Font font_0;

	internal Color color_0;

	internal Rectangle rectangle_1;

	private Class784 class784_0;

	internal Color color_1;

	private Size size_0 = Size.Empty;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private int int_2;

	[CompilerGenerated]
	private int int_3;

	[CompilerGenerated]
	private int int_4;

	internal List<Class787> LegendEntries
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

	public Font Font => font_0;

	public Color FontColor => color_0;

	public int FrameBlank
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int TextVerticalSpan
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int TextHorizontalSpan
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	internal Size LegendSize
	{
		get
		{
			return size_0;
		}
		set
		{
			size_0 = value;
		}
	}

	internal int CategoryLabelHeight
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	internal int FirstRowCategoryLabelHeight
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	internal Class786(DataTable dataTable, Class784 chartRenderContext)
	{
		class784_0 = chartRenderContext;
		if (chartRenderContext.Chart.HasDataTable)
		{
			FirstRowCategoryLabelHeight = 0;
			CategoryLabelHeight = 0;
			Chart chart = (Chart)dataTable.Chart;
			color_0 = ((!chart.PPTXUnsupportedProps.ColorMappingOverride.On || !chart.ThemeManager.IsOverrideThemeEnabled) ? chart.Slide.CreateThemeEffective().GetColorScheme(Color.Empty).Dark1 : chart.ThemeManager.OverrideTheme.ColorScheme.Dark1.Color);
			color_1 = ((!class784_0.Chart.PPTXUnsupportedProps.ColorMappingOverride.On || !class784_0.Chart.ThemeManager.IsOverrideThemeEnabled) ? class784_0.Chart.Slide.CreateThemeEffective().GetColorScheme(Color.Empty).Dark1 : class784_0.Chart.ThemeManager.OverrideTheme.ColorScheme.Dark1.Color);
			color_1 = Struct44.smethod_10(color_1, 0.75);
			color_1 = Color.FromArgb(255, color_1);
			color_0 = chart.method_14(dataTable.TextFormatManager, null, color_0, class784_0.Chart2007);
			font_0 = chart.method_15(dataTable.TextFormatManager, null, isBold: false, isTitle: false);
			list_0 = new List<Class787>();
			method_0(dataTable, class784_0.Chart2007);
			TextHorizontalSpan = (FrameBlank = Struct41.smethod_5((float)Struct39.smethod_22(class784_0.Graphics, font_0) * 0.2f));
			if (FrameBlank < 4)
			{
				FrameBlank = 4;
			}
			TextVerticalSpan = Struct41.smethod_5((float)Struct39.smethod_22(class784_0.Graphics, font_0) * 0.25f);
			if (TextVerticalSpan < 4)
			{
				TextVerticalSpan = 4;
			}
			rectangle_1 = Rectangle.Empty;
		}
	}

	internal void method_0(DataTable dataTable, Class740 chart)
	{
		List<Class759> list = chart.NSeriesInternal.method_9();
		for (int i = 0; i < list.Count; i++)
		{
			Class759 @class = list[i];
			Class787 class2 = new Class787((Chart)dataTable.Chart, chart);
			class2.Name = @class.Name;
			class2.EntryType = Enum144.const_0;
			class2.Series = @class;
			list_0.Add(class2);
		}
	}
}
