using System;
using ns25;

namespace Aspose.Slides.Charts;

public class ErrorBarsFormat : IPresentationComponent, ISlideComponent, IChartComponent, IErrorBarsFormat
{
	private Class279 class279_0 = new Class279();

	private ErrorBarType errorBarType_0;

	private ErrorBarValueType errorBarValueType_0 = ErrorBarValueType.StandardError;

	private bool bool_0 = true;

	private float float_0;

	private Format format_0;

	private ChartSeries chartSeries_0;

	private bool bool_1;

	public ErrorBarType Type
	{
		get
		{
			return errorBarType_0;
		}
		set
		{
			errorBarType_0 = value;
		}
	}

	public ErrorBarValueType ValueType
	{
		get
		{
			return errorBarValueType_0;
		}
		set
		{
			errorBarValueType_0 = value;
		}
	}

	public bool HasEndCap
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

	public float Value
	{
		get
		{
			if (ValueType != 0 && ValueType != ErrorBarValueType.StandardError)
			{
				return float_0;
			}
			return float.NaN;
		}
		set
		{
			if (ValueType == ErrorBarValueType.Custom || ValueType == ErrorBarValueType.StandardError)
			{
				throw new InvalidOperationException("Value of ValueType property must be Fixed, Percentage or StandardDeviation");
			}
			float_0 = value;
		}
	}

	public IFormat Format
	{
		get
		{
			return format_0;
		}
		set
		{
			format_0 = (Format)value;
		}
	}

	public IChart Chart => chartSeries_0.Chart;

	public bool IsVisible
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

	IChartComponent IErrorBarsFormat.AsIChartComponent => this;

	ISlideComponent IChartComponent.AsISlideComponent => this;

	IBaseSlide ISlideComponent.Slide
	{
		get
		{
			if (chartSeries_0 == null)
			{
				return null;
			}
			return ((ISlideComponent)chartSeries_0).Slide;
		}
	}

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	IPresentation IPresentationComponent.Presentation
	{
		get
		{
			if (chartSeries_0 == null)
			{
				return null;
			}
			return ((IPresentationComponent)chartSeries_0).Presentation;
		}
	}

	internal Class279 PPTXUnsupportedProps => class279_0;

	internal ErrorBarsFormat(ChartSeries parent)
	{
		chartSeries_0 = parent;
		format_0 = new Format(Chart);
	}
}
