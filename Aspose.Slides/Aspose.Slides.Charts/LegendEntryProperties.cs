using ns2;
using ns25;

namespace Aspose.Slides.Charts;

public class LegendEntryProperties : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, ILegendEntryProperties
{
	private Chart chart_0;

	private Class324 class324_0 = new Class324();

	private readonly Class17 class17_0;

	private bool bool_0;

	public IChartTextFormat TextFormat => class17_0.TextFormatOfAutoText;

	internal Class17 TextFormatManager => class17_0;

	public bool Hide
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

	public IChart Chart => chart_0;

	IFormattedTextContainer ILegendEntryProperties.AsIFormattedTextContainer => this;

	IChartComponent ILegendEntryProperties.AsIChartComponent => this;

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

	internal Class324 PPTXUnsupportedProps => class324_0;

	internal LegendEntryProperties(Chart parent)
	{
		chart_0 = parent;
		class17_0 = new Class17(this);
	}
}
