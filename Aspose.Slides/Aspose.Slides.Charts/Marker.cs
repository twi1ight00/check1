using ns25;

namespace Aspose.Slides.Charts;

public class Marker : IMarker
{
	private ChartSeries chartSeries_0;

	private Class325 class325_0 = new Class325();

	internal int int_0;

	internal MarkerStyleType markerStyleType_0 = MarkerStyleType.NotDefined;

	internal Format format_0;

	public MarkerStyleType Symbol
	{
		get
		{
			return markerStyleType_0;
		}
		set
		{
			if (markerStyleType_0 != value)
			{
				markerStyleType_0 = value;
				chartSeries_0.method_1();
			}
		}
	}

	public IFormat Format => format_0;

	public int Size
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal Class325 PPTXUnsupportedProps => class325_0;

	internal Marker(ChartSeries parent)
	{
		chartSeries_0 = parent;
		format_0 = new Format(parent.Chart);
	}
}
