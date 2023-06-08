using Aspose.Slides;
using Aspose.Slides.Charts;
using ns25;

namespace ns2;

internal class Class16 : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, IOverridableText, ILayoutable
{
	private Chart chart_0;

	private Class316 class316_0;

	private Class17 class17_0;

	private TextFrame textFrame_0;

	internal Class316 PPTXUnsupportedProps => class316_0;

	IFormattedTextContainer IOverridableText.AsIFormattedTextContainer => this;

	IChartComponent ILayoutable.AsIChartComponent => this;

	public IChart Chart => chart_0;

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

	public ITextFrame TextFrameForOverriding => textFrame_0;

	public IChartTextFormat TextFormat => class17_0.TextFormatOfAutoText;

	internal Class17 TextFormatManager => class17_0;

	internal Class16(Chart parent)
	{
		chart_0 = parent;
		class316_0 = new Class316(parent);
		class17_0 = new Class17(this);
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
