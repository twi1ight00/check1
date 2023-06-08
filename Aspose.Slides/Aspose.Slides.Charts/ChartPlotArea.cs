using ns25;

namespace Aspose.Slides.Charts;

public class ChartPlotArea : IPresentationComponent, ISlideComponent, IChartComponent, ILayoutable, IChartPlotArea
{
	private Chart chart_0;

	private Class313 class313_0;

	private IFormat iformat_0;

	internal bool bool_0;

	internal Class313 PPTXUnsupportedProps => class313_0;

	public IFormat Format => iformat_0;

	public float X
	{
		get
		{
			return PPTXUnsupportedProps.X;
		}
		set
		{
			bool_0 = false;
			PPTXUnsupportedProps.X = value;
		}
	}

	internal float XInternal => PPTXUnsupportedProps.X;

	public float Y
	{
		get
		{
			return PPTXUnsupportedProps.Y;
		}
		set
		{
			bool_0 = false;
			PPTXUnsupportedProps.Y = value;
		}
	}

	internal float YInternal => PPTXUnsupportedProps.Y;

	public float Width
	{
		get
		{
			return PPTXUnsupportedProps.Width;
		}
		set
		{
			bool_0 = false;
			PPTXUnsupportedProps.Width = value;
		}
	}

	internal float WidthInternal => PPTXUnsupportedProps.Width;

	public float Height
	{
		get
		{
			return PPTXUnsupportedProps.Height;
		}
		set
		{
			bool_0 = false;
			PPTXUnsupportedProps.Height = value;
		}
	}

	internal float HeightInternal => PPTXUnsupportedProps.Height;

	public float Right => PPTXUnsupportedProps.Right;

	public float Bottom => PPTXUnsupportedProps.Bottom;

	public IChart Chart => chart_0;

	public bool IsLocationAutocalculated => bool_0;

	IChartComponent ILayoutable.AsIChartComponent => this;

	ILayoutable IChartPlotArea.AsILayoutable => this;

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

	internal ChartPlotArea(Chart parent)
	{
		chart_0 = parent;
		class313_0 = new Class313(parent);
		iformat_0 = new Format(parent);
	}
}
