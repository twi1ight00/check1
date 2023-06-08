using ns2;
using ns25;

namespace Aspose.Slides.Charts;

public class Legend : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, ILayoutable, ILegend
{
	private bool bool_0;

	internal LegendPositionType legendPositionType_0 = LegendPositionType.Right;

	internal Format format_0;

	private Chart chart_0;

	private Class317 class317_0;

	private readonly Class17 class17_0;

	private LegendEntryCollection legendEntryCollection_0;

	internal Class317 PPTXUnsupportedProps => class317_0;

	public float X
	{
		get
		{
			return PPTXUnsupportedProps.X;
		}
		set
		{
			PPTXUnsupportedProps.X = value;
		}
	}

	public float Y
	{
		get
		{
			return PPTXUnsupportedProps.Y;
		}
		set
		{
			PPTXUnsupportedProps.Y = value;
		}
	}

	public float Width
	{
		get
		{
			return PPTXUnsupportedProps.Width;
		}
		set
		{
			PPTXUnsupportedProps.Width = value;
		}
	}

	public float Height
	{
		get
		{
			return PPTXUnsupportedProps.Height;
		}
		set
		{
			PPTXUnsupportedProps.Height = value;
		}
	}

	public float Right => PPTXUnsupportedProps.Right;

	public float Bottom => PPTXUnsupportedProps.Bottom;

	public bool Overlay
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

	public IChartTextFormat TextFormat => class17_0.TextFormatOfAutoText;

	internal Class17 TextFormatManager => class17_0;

	public LegendPositionType Position
	{
		get
		{
			return legendPositionType_0;
		}
		set
		{
			legendPositionType_0 = value;
		}
	}

	public IFormat Format => format_0;

	public IChart Chart => chart_0;

	public ILegendEntryCollection Entries => legendEntryCollection_0;

	IChartComponent ILayoutable.AsIChartComponent => this;

	IFormattedTextContainer ILegend.AsIFormattedTextContainer => this;

	ILayoutable ILegend.AsILayoutable => this;

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

	internal Legend(Chart parent)
	{
		chart_0 = parent;
		class317_0 = new Class317(parent);
		class17_0 = new Class17(this);
		format_0 = new Format(parent);
		legendEntryCollection_0 = new LegendEntryCollection(parent);
	}
}
