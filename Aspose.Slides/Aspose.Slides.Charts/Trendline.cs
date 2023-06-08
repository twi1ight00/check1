using System;
using ns2;
using ns25;

namespace Aspose.Slides.Charts;

public class Trendline : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, IOverridableText, ITrendline
{
	private ChartSeries chartSeries_0;

	private Class327 class327_0 = new Class327();

	private double double_0 = double.NaN;

	private bool bool_0;

	private bool bool_1;

	private double double_1 = double.NaN;

	private double double_2 = double.NaN;

	private string string_0;

	private byte byte_0 = 2;

	private byte byte_1 = 2;

	private TrendlineType trendlineType_0 = TrendlineType.Linear;

	private readonly Class17 class17_0;

	private TextFrame textFrame_0;

	private Format format_0;

	public string TrendlineName
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

	public TrendlineType TrendlineType
	{
		get
		{
			return trendlineType_0;
		}
		set
		{
			trendlineType_0 = value;
		}
	}

	internal Class327 PPTXUnsupportedProps => class327_0;

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

	public double Backward
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double Forward
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double Intercept
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public bool DisplayEquation
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

	public byte Order
	{
		get
		{
			return byte_0;
		}
		set
		{
			if (value < 2 || value > 6)
			{
				throw new ArgumentOutOfRangeException("Value must be between 2 and 6");
			}
			byte_0 = value;
		}
	}

	public byte Period
	{
		get
		{
			return byte_1;
		}
		set
		{
			if (value < 2)
			{
				throw new ArgumentOutOfRangeException("Value must be between 2 and 255");
			}
			byte_1 = value;
		}
	}

	public bool DisplayRSquaredValue
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

	public ITextFrame TextFrameForOverriding => textFrame_0;

	public IChartTextFormat TextFormat => class17_0.TextFormatOfAutoText;

	internal Class17 TextFormatManager => class17_0;

	public IChart Chart => chartSeries_0.Chart;

	IChartComponent ITrendline.AsIChartComponent => this;

	IOverridableText ITrendline.AsIOverridableText => this;

	IFormattedTextContainer IOverridableText.AsIFormattedTextContainer => this;

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

	internal Trendline(ChartSeries parent)
	{
		chartSeries_0 = parent;
		format_0 = new Format(Chart);
		class17_0 = new Class17(this);
		textFrame_0 = new TextFrame(this);
	}

	public ITextFrame AddTextFrameForOverriding(string text)
	{
		if (textFrame_0 == null)
		{
			textFrame_0 = new TextFrame(this);
		}
		((ParagraphCollection)textFrame_0.Paragraphs).Text = text;
		return textFrame_0;
	}
}
