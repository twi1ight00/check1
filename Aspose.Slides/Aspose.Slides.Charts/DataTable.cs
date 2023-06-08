using ns2;
using ns25;

namespace Aspose.Slides.Charts;

public class DataTable : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, IDataTable
{
	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal bool bool_3;

	internal Format format_0;

	private Chart chart_0;

	private readonly Class17 class17_0;

	private Class322 class322_0 = new Class322();

	internal Class322 PPTXUnsupportedProps => class322_0;

	public IFormat Format => format_0;

	public bool HasBorderHorizontal
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool HasBorderOutline
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool HasBorderVertical
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

	public bool ShowLegendKey
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public IChart Chart => chart_0;

	public IChartTextFormat TextFormat => class17_0.TextFormatOfAutoText;

	internal Class17 TextFormatManager => class17_0;

	IChartComponent IDataTable.AsIChartComponent => this;

	IFormattedTextContainer IDataTable.AsIFormattedTextContainer => this;

	ISlideComponent IChartComponent.AsISlideComponent => this;

	IBaseSlide ISlideComponent.Slide
	{
		get
		{
			if (chart_0 == null)
			{
				return null;
			}
			return chart_0.Slide;
		}
	}

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	IPresentation IPresentationComponent.Presentation
	{
		get
		{
			if (chart_0 == null)
			{
				return null;
			}
			return chart_0.Presentation;
		}
	}

	internal DataTable(Chart parent)
	{
		chart_0 = parent;
		class17_0 = new Class17(this);
		format_0 = new Format(parent);
	}
}
