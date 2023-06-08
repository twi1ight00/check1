using System.Drawing;
using Aspose.Slides;
using ns7;

namespace ns4;

internal class Class150
{
	public int int_0;

	public AutoShape autoShape_0;

	private IMasterSlide imasterSlide_0;

	private LayoutSlide layoutSlide_0;

	private SlideLayoutType slideLayoutType_0;

	private uint uint_0;

	private AutoShape autoShape_1;

	private TextFrame textFrame_0;

	private AutoShape autoShape_2;

	private Class154 class154_0;

	private TextStyle textStyle_0;

	private TextAnchorType textAnchorType_0 = TextAnchorType.NotDefined;

	internal LayoutSlide TargetLayoutSlide => layoutSlide_0;

	internal SlideLayoutType LayoutType
	{
		get
		{
			return slideLayoutType_0;
		}
		set
		{
			slideLayoutType_0 = value;
		}
	}

	internal LayoutSlide method_0(string name)
	{
		if (layoutSlide_0 == null)
		{
			layoutSlide_0 = new LayoutSlide(imasterSlide_0, slideLayoutType_0);
			layoutSlide_0.PPTXUnsupportedProps.SlideId = ((Presentation)imasterSlide_0.Presentation).PPTXUnsupportedProps.method_2();
			layoutSlide_0.Name = name;
			layoutSlide_0.PPTXUnsupportedProps.Preserve = true;
			layoutSlide_0.groupShape_0.RawFrameImpl.vmethod_0(0.0, 0.0, 0.0, 0.0);
			layoutSlide_0.groupShape_0.RawFrameImpl.ChildRect = new RectangleF(0f, 0f, 0f, 0f);
			layoutSlide_0.groupShape_0.AlternativeText = "";
			layoutSlide_0.groupShape_0.Name = "";
		}
		return layoutSlide_0;
	}

	internal AutoShape method_1(string shapeName, Orientation orientation, PlaceholderSize size, PlaceholderType placeholderType)
	{
		bool flag = true;
		autoShape_1 = method_2(placeholderType);
		if (autoShape_1 != null)
		{
			textFrame_0 = autoShape_1.TextFrameInternal;
			autoShape_0 = autoShape_1;
		}
		else
		{
			switch (placeholderType)
			{
			case PlaceholderType.DateAndTime:
			case PlaceholderType.SlideNumber:
			case PlaceholderType.Footer:
				flag = false;
				break;
			}
		}
		if (flag)
		{
			uint_0++;
			autoShape_2 = new AutoShape(layoutSlide_0);
			if (class154_0 != null)
			{
				autoShape_2.RawFrameImpl.vmethod_0(class154_0.X, class154_0.Y, class154_0.Width, class154_0.Height);
			}
			class154_0 = null;
			autoShape_2.AlternativeText = "";
			autoShape_2.Name = shapeName + " " + uint_0;
			autoShape_2.method_0(orientation, size, placeholderType, uint_0 - 1, hasCustomPrompt: false);
			autoShape_2.ShapeLock.GroupingLocked = true;
			autoShape_2.AddTextFrame("");
			autoShape_2.TextFrame.Paragraphs.Clear();
			if (textStyle_0 != null)
			{
				((TextStyle)autoShape_2.TextFrame.TextFrameFormat.TextStyle).method_2(textStyle_0);
				textStyle_0 = null;
			}
			if (textAnchorType_0 != TextAnchorType.NotDefined)
			{
				autoShape_2.TextFrame.TextFrameFormat.AnchoringType = textAnchorType_0;
				textAnchorType_0 = TextAnchorType.NotDefined;
			}
			return autoShape_2;
		}
		autoShape_2 = null;
		textFrame_0 = null;
		autoShape_0 = null;
		return null;
	}

	internal Class150(IMasterSlide masterSlide, SlideLayoutType slideLayoutType)
	{
		imasterSlide_0 = masterSlide;
		slideLayoutType_0 = slideLayoutType;
	}

	private AutoShape method_2(PlaceholderType placeholderType)
	{
		foreach (IShape shape in imasterSlide_0.Shapes)
		{
			if (shape is AutoShape autoShape && autoShape.Placeholder != null && autoShape.Placeholder.Type == placeholderType)
			{
				return autoShape;
			}
		}
		return null;
	}

	internal void method_3()
	{
		((ShapeCollection)layoutSlide_0.groupShape_0.Shapes).Add(autoShape_2);
		autoShape_2.method_26();
	}

	internal void method_4(Portion portion)
	{
		if (textFrame_0 != null)
		{
			((ParagraphFormat)portion.paragraph_0.ParagraphFormat).method_0((ParagraphFormat)textFrame_0.Paragraphs[0].ParagraphFormat);
			((PortionFormat)portion.PortionFormat).vmethod_1((PortionFormat)textFrame_0.Paragraphs[0].Portions[0].PortionFormat);
		}
	}

	public void method_5(double x, double y, double width, double height)
	{
		class154_0 = new Class154();
		class154_0.vmethod_0(x, y, width, height);
	}

	public void method_6(TextStyle textStyle)
	{
		textStyle_0 = textStyle;
	}

	public void method_7(TextAnchorType anchorType)
	{
		textAnchorType_0 = anchorType;
	}
}
