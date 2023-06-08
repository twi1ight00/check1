using System;
using Aspose.Slides.Charts;
using ns22;
using ns24;

namespace Aspose.Slides;

public sealed class TextFrameFormat : IChartTextBlockFormat, ITextFrameFormat
{
	internal delegate void Delegate12();

	internal IPresentationComponent ipresentationComponent_0;

	private Class356 class356_0 = new Class356();

	private Class272 class272_0 = new Class272();

	private uint uint_0;

	internal TextStyle textStyle_0;

	internal double double_0 = double.NaN;

	internal double double_1 = double.NaN;

	internal double double_2 = double.NaN;

	internal double double_3 = double.NaN;

	private TextAnchorType textAnchorType_0 = TextAnchorType.NotDefined;

	private NullableBool nullableBool_0 = NullableBool.NotDefined;

	internal TextVerticalType textVerticalType_0 = TextVerticalType.NotDefined;

	private TextAutofitType textAutofitType_0 = TextAutofitType.NotDefined;

	private uint uint_1;

	internal Paragraph.Class514 class514_0 = new Paragraph.Class514();

	internal Delegate12 delegate12_0;

	ITextStyle ITextFrameFormat.TextStyle => textStyle_0;

	double ITextFrameFormat.MarginLeft
	{
		get
		{
			return double_0;
		}
		set
		{
			method_0(value, out double_0);
		}
	}

	double ITextFrameFormat.MarginRight
	{
		get
		{
			return double_1;
		}
		set
		{
			method_0(value, out double_1);
		}
	}

	double ITextFrameFormat.MarginTop
	{
		get
		{
			return double_2;
		}
		set
		{
			method_0(value, out double_2);
		}
	}

	double ITextFrameFormat.MarginBottom
	{
		get
		{
			return double_3;
		}
		set
		{
			method_0(value, out double_3);
		}
	}

	NullableBool ITextFrameFormat.WrapText
	{
		get
		{
			return PPTXUnsupportedProps.Wrap;
		}
		set
		{
			PPTXUnsupportedProps.Wrap = value;
		}
	}

	public TextAnchorType AnchoringType
	{
		get
		{
			return textAnchorType_0;
		}
		set
		{
			textAnchorType_0 = value;
			method_2();
		}
	}

	public NullableBool CenterText
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			nullableBool_0 = value;
			method_2();
		}
	}

	public TextVerticalType TextVerticalType
	{
		get
		{
			return textVerticalType_0;
		}
		set
		{
			textVerticalType_0 = value;
			method_2();
		}
	}

	internal TextVerticalType InheritedTextVerticalType
	{
		get
		{
			if (textVerticalType_0 == TextVerticalType.NotDefined)
			{
				BaseSlide baseSlide = ((ipresentationComponent_0 is ISlideComponent slideComponent) ? ((BaseSlide)slideComponent.Slide) : null);
				Shape shape = ((ipresentationComponent_0 is TextFrame textFrame) ? (textFrame.islideComponent_0 as Shape) : null);
				if (baseSlide != null && shape != null && shape.Placeholder != null)
				{
					Shape[] array = baseSlide.vmethod_0(shape.Placeholder);
					if (array.Length > 0 && array[0] is AutoShape autoShape && autoShape.TextFrame != null)
					{
						return ((TextFrameFormat)autoShape.TextFrame.TextFrameFormat).InheritedTextVerticalType;
					}
				}
			}
			return textVerticalType_0;
		}
		set
		{
			textVerticalType_0 = value;
			method_2();
		}
	}

	TextAutofitType ITextFrameFormat.AutofitType
	{
		get
		{
			return textAutofitType_0;
		}
		set
		{
			textAutofitType_0 = value;
			method_2();
			method_1();
		}
	}

	internal TextAutofitType AutofitTypeInternal
	{
		get
		{
			return textAutofitType_0;
		}
		set
		{
			textAutofitType_0 = value;
			method_2();
		}
	}

	internal int ColumnCount
	{
		get
		{
			if (PPTXUnsupportedProps.ColumnCount != 0)
			{
				return PPTXUnsupportedProps.ColumnCount;
			}
			return 1;
		}
		set
		{
			if (value < 1)
			{
				throw new PptxException("TextFrame's number of columns can't be less then one.");
			}
			PPTXUnsupportedProps.ColumnCount = value;
			method_1();
		}
	}

	internal float ColumnSpacing
	{
		get
		{
			return (float)PPTXUnsupportedProps.ColumnSpacing;
		}
		set
		{
			if (value < 0f)
			{
				throw new PptxException("TextFrame's space between text columns can't be less then zero.");
			}
			PPTXUnsupportedProps.ColumnSpacing = value;
			method_1();
		}
	}

	internal bool RightToLeftColumns
	{
		get
		{
			return PPTXUnsupportedProps.RightToLeftColumns == NullableBool.True;
		}
		set
		{
			PPTXUnsupportedProps.RightToLeftColumns = (value ? NullableBool.True : NullableBool.False);
		}
	}

	internal float RotationAngle
	{
		get
		{
			return PPTXUnsupportedProps.RotationAngle;
		}
		set
		{
			PPTXUnsupportedProps.RotationAngle = value;
		}
	}

	internal Class356 PPTXUnsupportedProps => class356_0;

	internal Class272 PPTUnsupportedProps => class272_0;

	internal uint Version_OldMode => uint_1 + ((ipresentationComponent_0 != null && ipresentationComponent_0 is Shape) ? ((Shape)ipresentationComponent_0).uint_0 : 0) + (uint)class514_0.int_0;

	internal uint Version => uint_0 + textStyle_0.Version + class356_0.Version;

	internal TextFrameFormat(IPresentationComponent parent)
	{
		if (parent != null && !(parent is IFormattedTextContainer) && !(parent is TextFrame))
		{
			throw new ArgumentException();
		}
		ipresentationComponent_0 = parent;
		textStyle_0 = new TextStyle(parent);
		if (ipresentationComponent_0 != null)
		{
			if (ipresentationComponent_0 is TextFrame && ipresentationComponent_0 is Cell cell)
			{
				class514_0 = ((Table)cell.Table).class514_0;
			}
			textStyle_0.m_styleChanged += class514_0.method_0;
			if (ipresentationComponent_0 != null)
			{
				((TextStyle)((Presentation)ipresentationComponent_0.Presentation).DefaultTextStyle).m_styleChanged += class514_0.method_0;
			}
		}
	}

	private void method_0(double value, out double destination)
	{
		destination = value;
		method_1();
		method_2();
	}

	internal void method_1()
	{
		uint_1++;
		if (delegate12_0 != null)
		{
			delegate12_0();
		}
	}

	private void method_2()
	{
		uint_0++;
	}

	internal void method_3(TextFrameFormat source)
	{
		textAutofitType_0 = source.textAutofitType_0;
		textVerticalType_0 = source.textVerticalType_0;
		PPTXUnsupportedProps.Wrap = source.PPTXUnsupportedProps.Wrap;
		double_0 = source.double_0;
		double_2 = source.double_2;
		double_1 = source.double_1;
		double_3 = source.double_3;
		textAnchorType_0 = source.textAnchorType_0;
		nullableBool_0 = source.nullableBool_0;
		textStyle_0.method_2(source.textStyle_0);
		PPTXUnsupportedProps.method_0(source.PPTXUnsupportedProps);
		method_2();
	}

	internal bool method_4(IChartTextBlockFormat textBlockFormat)
	{
		TextFrameFormat textFrameFormat = (TextFrameFormat)textBlockFormat;
		if (textAnchorType_0 == textFrameFormat.textAnchorType_0 && nullableBool_0 == textFrameFormat.nullableBool_0 && textVerticalType_0 == textFrameFormat.textVerticalType_0 && PPTXUnsupportedProps.method_1(textFrameFormat.PPTXUnsupportedProps))
		{
			return true;
		}
		return false;
	}
}
