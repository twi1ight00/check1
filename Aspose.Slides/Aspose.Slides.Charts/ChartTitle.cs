using System.Drawing.Text;
using ns2;
using ns25;
using ns36;
using ns38;

namespace Aspose.Slides.Charts;

public class ChartTitle : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, IOverridableText, ILayoutable, IChartTitle
{
	private bool bool_0 = true;

	private readonly Format format_0;

	private TextFrame textFrame_0;

	private Chart chart_0;

	private Class314 class314_0;

	private readonly Class17 class17_0;

	internal Class314 PPTXUnsupportedProps => class314_0;

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

	public IFormat Format => format_0;

	public ITextFrame TextFrameForOverriding => textFrame_0;

	public IChartTextFormat TextFormat => class17_0.TextFormatOfAutoText;

	internal Class17 TextFormatManager => class17_0;

	ILayoutable IChartTitle.AsILayoutable => this;

	IOverridableText IChartTitle.AsIOverridableText => this;

	public IChart Chart => chart_0;

	IChartComponent ILayoutable.AsIChartComponent => this;

	IFormattedTextContainer IOverridableText.AsIFormattedTextContainer => this;

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

	internal ChartTitle(Chart parent)
	{
		class314_0 = new Class314(parent);
		chart_0 = parent;
		format_0 = new Format(parent);
		class17_0 = new Class17(this);
	}

	internal bool method_0()
	{
		return true;
	}

	internal void method_1(Chart chart)
	{
		chart_0 = chart;
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

	internal void method_2(Class784 renderContext, Class785 titleRenderContext)
	{
		if (!float.IsNaN(X) && !float.IsNaN(Y))
		{
			titleRenderContext.rectangle_0.X = (int)((float)renderContext.Chart2007.Position.Width * X);
			titleRenderContext.rectangle_0.Y = (int)((float)renderContext.Chart2007.Position.Height * Y);
			titleRenderContext.rectangle_0.X = ((titleRenderContext.rectangle_0.X >= 0) ? titleRenderContext.rectangle_0.X : 0);
			titleRenderContext.rectangle_0.Y = ((titleRenderContext.rectangle_0.Y >= 0) ? titleRenderContext.rectangle_0.Y : 0);
		}
		Struct30.smethod_0(renderContext, titleRenderContext.rectangle_0, Format);
		TextRenderingHint textRenderingHint = renderContext.Graphics.TextRenderingHint;
		if (renderContext.Chart2007.ChartAreaInternal.AreaInternal.IsTransparent && titleRenderContext.IsTransparent)
		{
			renderContext.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
		}
		Struct39.smethod_0(renderContext.Graphics, titleRenderContext.rectangle_0, titleRenderContext.Text, (!float.IsNaN(titleRenderContext.Rotation)) ? ((int)titleRenderContext.Rotation) : 0, titleRenderContext.TextFont, titleRenderContext.FontColor, Enum157.const_1, Enum157.const_1);
		if (renderContext.Chart2007.ChartAreaInternal.AreaInternal.IsTransparent && titleRenderContext.IsTransparent)
		{
			renderContext.Graphics.TextRenderingHint = textRenderingHint;
		}
	}
}
