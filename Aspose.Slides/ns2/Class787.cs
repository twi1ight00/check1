using System.Drawing;
using Aspose.Slides.Charts;
using ns36;
using ns37;

namespace ns2;

internal class Class787
{
	private string string_0;

	private Enum144 enum144_0;

	private Class759 class759_0;

	private Class763 class763_0;

	private Font font_0;

	private Color color_0;

	private LegendEntryProperties legendEntryProperties_0;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Enum144 EntryType
	{
		get
		{
			return enum144_0;
		}
		set
		{
			enum144_0 = value;
		}
	}

	public Class763 Trendline
	{
		get
		{
			return class763_0;
		}
		set
		{
			class763_0 = value;
		}
	}

	public Class759 Series
	{
		get
		{
			return class759_0;
		}
		set
		{
			class759_0 = value;
		}
	}

	public Font TextFont => font_0;

	public Color FontColor => color_0;

	public LegendEntryProperties LegendEntryProperties => legendEntryProperties_0;

	internal Class787(LegendEntryProperties legendProperties, Class740 chart2007)
	{
		Chart chart2008 = (Chart)legendProperties.Chart;
		legendEntryProperties_0 = legendProperties;
		font_0 = chart2008.method_15(legendEntryProperties_0.TextFormatManager, null, isBold: false, isTitle: false);
		color_0 = chart2008.method_14(legendEntryProperties_0.TextFormatManager, null, color_0, chart2007);
	}

	internal Class787(Chart chart, Class740 chart2007)
	{
		legendEntryProperties_0 = new LegendEntryProperties(chart);
		font_0 = chart.method_15(legendEntryProperties_0.TextFormatManager, null, isBold: false, isTitle: false);
		color_0 = chart.method_14(legendEntryProperties_0.TextFormatManager, null, color_0, chart2007);
	}
}
