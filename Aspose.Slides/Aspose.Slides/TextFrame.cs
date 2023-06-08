using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using Aspose.Slides.Charts;
using ns11;
using ns16;
using ns28;
using ns33;
using ns4;

namespace Aspose.Slides;

public sealed class TextFrame : IPresentationComponent, ISlideComponent, ITextFrame
{
	private const float float_0 = 0.1f;

	private const string string_0 = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";

	internal TextFrameFormat textFrameFormat_0;

	internal Class532 class532_0;

	private ParagraphCollection paragraphCollection_0;

	internal ISlideComponent islideComponent_0;

	private IParagraphFormat[] iparagraphFormat_0;

	private int int_0 = -1;

	internal FloatColor floatColor_0;

	private HyperlinkQueries hyperlinkQueries_0;

	private readonly bool bool_0;

	internal static readonly Class1155 class1155_0 = new Class1155(PlaceholderType.Title, Enum136.const_1, PlaceholderType.CenteredTitle, Enum136.const_1, PlaceholderType.Body, Enum136.const_2, PlaceholderType.Subtitle, Enum136.const_2, PlaceholderType.Object, Enum136.const_2, PlaceholderType.Chart, Enum136.const_2, PlaceholderType.Table, Enum136.const_2, PlaceholderType.ClipArt, Enum136.const_2, PlaceholderType.Diagram, Enum136.const_2, PlaceholderType.Media, Enum136.const_2, PlaceholderType.SlideImage, Enum136.const_2, PlaceholderType.Picture, Enum136.const_2, PlaceholderType.DateAndTime, Enum136.const_0, PlaceholderType.SlideNumber, Enum136.const_0, PlaceholderType.Footer, Enum136.const_0, PlaceholderType.Header, Enum136.const_0);

	internal SizeF WantedSize
	{
		get
		{
			SizeF result = new SizeF(0f, 0f);
			float num = (class532_0.WrapText ? class532_0.Width : class532_0.TextWidth);
			TextVerticalType inheritedTextVerticalType = textFrameFormat_0.InheritedTextVerticalType;
			if (inheritedTextVerticalType != TextVerticalType.Vertical && inheritedTextVerticalType != TextVerticalType.Vertical270 && inheritedTextVerticalType != TextVerticalType.EastAsianVertical && inheritedTextVerticalType != TextVerticalType.MongolianVertical)
			{
				result.Width += num;
				result.Height += class532_0.TextHeight;
			}
			else
			{
				result.Width += class532_0.TextHeight;
				result.Height += num;
			}
			return result;
		}
	}

	internal SizeF WantedSizeWithoutEmptyLines
	{
		get
		{
			SizeF result = new SizeF(0f, 0f);
			float num = (class532_0.WrapText ? class532_0.Width : class532_0.TextWidth);
			TextVerticalType inheritedTextVerticalType = textFrameFormat_0.InheritedTextVerticalType;
			if (inheritedTextVerticalType != TextVerticalType.Vertical && inheritedTextVerticalType != TextVerticalType.Vertical270 && inheritedTextVerticalType != TextVerticalType.EastAsianVertical && inheritedTextVerticalType != TextVerticalType.MongolianVertical)
			{
				result.Width += num;
				result.Height += class532_0.TextHeightWithoutTrailingEmptyLines;
			}
			else
			{
				result.Width += class532_0.TextHeightWithoutTrailingEmptyLines;
				result.Height += num;
			}
			return result;
		}
	}

	internal IParagraphFormat[] TextStyleCache
	{
		get
		{
			if (iparagraphFormat_0 == null || int_0 != textFrameFormat_0.class514_0.int_0)
			{
				if (islideComponent_0 != null)
				{
					if (islideComponent_0 is AutoShape)
					{
						iparagraphFormat_0 = method_2(out floatColor_0);
						int_0 = textFrameFormat_0.class514_0.int_0;
					}
					else if (islideComponent_0 is BaseSlide parent)
					{
						iparagraphFormat_0 = method_8(parent, out floatColor_0);
						int_0 = textFrameFormat_0.class514_0.int_0;
					}
					else if (islideComponent_0 is Cell cell)
					{
						BaseSlide slide = (BaseSlide)Slide;
						MasterSlide master = smethod_0(slide);
						iparagraphFormat_0 = method_9(slide, master, cell.TextStyleCache, out floatColor_0);
						int_0 = textFrameFormat_0.class514_0.int_0;
					}
					else
					{
						int_0 = textFrameFormat_0.class514_0.int_0;
						iparagraphFormat_0 = method_7();
					}
				}
				else
				{
					int_0 = textFrameFormat_0.class514_0.int_0;
					iparagraphFormat_0 = method_7();
				}
			}
			return iparagraphFormat_0;
		}
	}

	public IParagraphCollection Paragraphs => paragraphCollection_0;

	internal string TextInternal
	{
		get
		{
			return paragraphCollection_0.Text;
		}
		set
		{
			paragraphCollection_0.Text = value;
		}
	}

	public string Text
	{
		get
		{
			return Class1179.smethod_3(TextInternal);
		}
		set
		{
			TextInternal = value;
		}
	}

	public ITextFrameFormat TextFrameFormat => textFrameFormat_0;

	public IHyperlinkQueries HyperlinkQueries
	{
		get
		{
			if (hyperlinkQueries_0 == null)
			{
				hyperlinkQueries_0 = new HyperlinkQueries(this);
			}
			return hyperlinkQueries_0;
		}
	}

	internal bool IsGeometryText => bool_0;

	ISlideComponent ITextFrame.AsISlideComponent => this;

	public IBaseSlide Slide
	{
		get
		{
			if (islideComponent_0 == null)
			{
				return null;
			}
			return islideComponent_0.Slide;
		}
	}

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	public IPresentation Presentation
	{
		get
		{
			if (islideComponent_0 == null)
			{
				return null;
			}
			return islideComponent_0.Presentation;
		}
	}

	internal TextFrame(ISlideComponent parent)
		: this(parent, isGeometryText: false)
	{
	}

	internal TextFrame(ISlideComponent parent, bool isGeometryText)
	{
		if (parent == null)
		{
			throw new ArgumentException();
		}
		if (!(parent is AutoShape) && !(parent is Cell) && !(parent is IOverridableText))
		{
			throw new ArgumentException();
		}
		islideComponent_0 = parent;
		textFrameFormat_0 = new TextFrameFormat(this);
		paragraphCollection_0 = new ParagraphCollection(this);
		bool_0 = isGeometryText;
	}

	internal void method_0(ITextFrame source)
	{
		textFrameFormat_0.method_3(((TextFrame)source).textFrameFormat_0);
		method_1((TextFrame)source);
	}

	internal void method_1(TextFrame source)
	{
		paragraphCollection_0.Clear();
		foreach (Paragraph item in source.paragraphCollection_0)
		{
			paragraphCollection_0.Add(new Paragraph(item));
		}
	}

	internal IParagraphFormat[] method_2(out FloatColor styleColor)
	{
		IParagraphFormat[] array = new ParagraphFormat[9];
		styleColor = null;
		AutoShape autoShape = islideComponent_0 as AutoShape;
		Presentation presentation = (Presentation)Presentation;
		BaseSlide baseSlide = (BaseSlide)islideComponent_0.Slide;
		IMasterSlide masterSlide = smethod_0(baseSlide);
		if (baseSlide is Slide slide)
		{
			masterSlide = slide.MasterSlide;
		}
		else if (baseSlide is LayoutSlide layoutSlide)
		{
			masterSlide = layoutSlide.MasterSlide;
		}
		else if (baseSlide is MasterSlide masterSlide2)
		{
			masterSlide = masterSlide2;
		}
		ITextStyle textStyle = presentation.textStyle_0;
		if (masterSlide != null && autoShape.Placeholder != null)
		{
			switch ((Enum136)class1155_0[autoShape.Placeholder.Type])
			{
			case Enum136.const_1:
				textStyle = masterSlide.TitleStyle;
				break;
			case Enum136.const_2:
				textStyle = masterSlide.BodyStyle;
				break;
			case Enum136.const_3:
				textStyle = masterSlide.OtherStyle;
				break;
			}
		}
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = textStyle.GetLevel(i);
		}
		IParagraphFormat paragraphFormat = new ParagraphFormat(textStyle.DefaultParagraphFormat, this);
		if (autoShape.ShapeStyle != null)
		{
			method_3(autoShape.ShapeStyle, baseSlide, paragraphFormat, textStyle, array, ref styleColor);
		}
		Shape[] array2 = autoShape.method_2();
		for (int num = array2.Length - 1; num >= 0; num--)
		{
			if (array2[num] is AutoShape autoShape2 && autoShape2.TextFrame != null)
			{
				if (autoShape2.ShapeStyle != null)
				{
					method_3(autoShape2.ShapeStyle, baseSlide, paragraphFormat, textStyle, array, ref styleColor);
				}
				TextFrame textFrame = (TextFrame)autoShape2.TextFrame;
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = textFrame.textFrameFormat_0.textStyle_0.method_7(j, array[j]);
				}
				paragraphFormat = textFrame.textFrameFormat_0.textStyle_0.method_6(paragraphFormat);
			}
		}
		if (autoShape.TextFrame != null)
		{
			TextFrame textFrame2 = (TextFrame)autoShape.TextFrame;
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = textFrame2.textFrameFormat_0.textStyle_0.method_7(k, array[k]);
			}
			paragraphFormat = textFrame2.textFrameFormat_0.textStyle_0.method_6(paragraphFormat);
		}
		paragraphFormat = ((ParagraphFormat)paragraphFormat).method_3(Aspose.Slides.Presentation.iparagraphFormat_0);
		for (int l = 0; l < array.Length; l++)
		{
			array[l] = ((array[l] == null) ? paragraphFormat : ((ParagraphFormat)array[l]).method_3(Aspose.Slides.Presentation.iparagraphFormat_0));
		}
		return array;
	}

	private void method_3(IShapeStyle style, BaseSlide parentSlide, IParagraphFormat defaultFormat, ITextStyle textStyle, IParagraphFormat[] resultFormats, ref FloatColor styleColor)
	{
		if (style.FontColor.ColorType != ColorType.NotDefined)
		{
			IFillFormat fillFormat = defaultFormat.DefaultPortionFormat.FillFormat;
			styleColor = ((ColorFormat)style.FontColor).FColor;
			fillFormat.FillType = FillType.Solid;
			fillFormat.SolidFillColor.CopyFrom(style.FontColor);
			for (int i = 0; i < resultFormats.Length; i++)
			{
				if (resultFormats[i] != null)
				{
					resultFormats[i] = new ParagraphFormat(textStyle.GetLevel(i), this);
					fillFormat = resultFormats[i].DefaultPortionFormat.FillFormat;
					fillFormat.FillType = FillType.Solid;
					fillFormat.SolidFillColor.CopyFrom(style.FontColor);
				}
			}
		}
		IFontsEffectiveData fontsEffectiveData = null;
		switch (style.FontCollectionIndex)
		{
		case FontCollectionIndex.Minor:
			fontsEffectiveData = parentSlide.CreateThemeEffective().FontScheme.Minor;
			break;
		case FontCollectionIndex.Major:
			fontsEffectiveData = parentSlide.CreateThemeEffective().FontScheme.Major;
			break;
		}
		if (fontsEffectiveData == null)
		{
			return;
		}
		defaultFormat.DefaultPortionFormat.LatinFont = fontsEffectiveData.LatinFont;
		defaultFormat.DefaultPortionFormat.EastAsianFont = fontsEffectiveData.EastAsianFont;
		for (int j = 0; j < resultFormats.Length; j++)
		{
			if (resultFormats[j] != null)
			{
				resultFormats[j].DefaultPortionFormat.LatinFont = fontsEffectiveData.LatinFont;
				resultFormats[j].DefaultPortionFormat.EastAsianFont = fontsEffectiveData.EastAsianFont;
			}
		}
	}

	internal void method_4(float width, float height, IShapeStyle shapeStyle, TextFrame[] parentFrames, Class169 rc)
	{
		AutoShape autoShape = (AutoShape)islideComponent_0;
		int num = ((rc != null) ? (rc.RenderingSlide as Slide) : null)?.SlideNumber ?? 0;
		if (class532_0 != null && autoShape.Version_OldMode == class532_0.uint_0 && class532_0.int_3 == num)
		{
			return;
		}
		TextVerticalType inheritedTextVerticalType = textFrameFormat_0.InheritedTextVerticalType;
		if (inheritedTextVerticalType == TextVerticalType.Vertical || inheritedTextVerticalType == TextVerticalType.Vertical270 || inheritedTextVerticalType == TextVerticalType.EastAsianVertical || inheritedTextVerticalType == TextVerticalType.MongolianVertical)
		{
			float num2 = width;
			width = height;
			height = num2;
		}
		FloatColor floatColor = null;
		IFontsEffectiveData defaultFonts = null;
		FontCollectionIndex fontCollectionIndex = FontCollectionIndex.None;
		if (shapeStyle != null)
		{
			floatColor = ((ColorFormat)shapeStyle.FontColor).FColor;
			if (float.IsNaN(floatColor.float_0 + floatColor.float_1 + floatColor.float_2 + floatColor.float_3))
			{
				floatColor = new FloatColor(0f, 0f, 0f);
			}
			fontCollectionIndex = shapeStyle.FontCollectionIndex;
			defaultFonts = shapeStyle.FontCollectionIndex switch
			{
				FontCollectionIndex.Minor => Slide.CreateThemeEffective().FontScheme.Minor, 
				FontCollectionIndex.Major => Slide.CreateThemeEffective().FontScheme.Major, 
				_ => null, 
			};
		}
		int columnCount = textFrameFormat_0.PPTXUnsupportedProps.ColumnCount;
		double columnSpacing = textFrameFormat_0.PPTXUnsupportedProps.ColumnSpacing;
		NullableBool wrap = textFrameFormat_0.PPTXUnsupportedProps.Wrap;
		TextAnchorType anchoringType = textFrameFormat_0.AnchoringType;
		NullableBool centerText = textFrameFormat_0.CenterText;
		if (parentFrames != null)
		{
			for (int i = 0; i < parentFrames.Length; i++)
			{
				if (columnCount == 0)
				{
					columnCount = parentFrames[i].textFrameFormat_0.PPTXUnsupportedProps.ColumnCount;
				}
				if (double.IsNaN(columnSpacing))
				{
					columnSpacing = parentFrames[i].textFrameFormat_0.PPTXUnsupportedProps.ColumnSpacing;
				}
				if (wrap == NullableBool.NotDefined)
				{
					wrap = parentFrames[i].textFrameFormat_0.PPTXUnsupportedProps.Wrap;
				}
				if (anchoringType == TextAnchorType.NotDefined)
				{
					anchoringType = parentFrames[i].textFrameFormat_0.AnchoringType;
				}
				if (centerText == NullableBool.NotDefined)
				{
					centerText = parentFrames[i].textFrameFormat_0.CenterText;
				}
			}
		}
		if (fontCollectionIndex == FontCollectionIndex.None)
		{
			if (autoShape.Placeholder != null)
			{
				Enum136 @enum = (Enum136)class1155_0[autoShape.Placeholder.Type];
				Enum136 enum2 = @enum;
				if (enum2 == Enum136.const_1)
				{
					fontCollectionIndex = FontCollectionIndex.Major;
					defaultFonts = Slide.CreateThemeEffective().FontScheme.Major;
				}
				else
				{
					fontCollectionIndex = FontCollectionIndex.Minor;
					defaultFonts = Slide.CreateThemeEffective().FontScheme.Minor;
				}
			}
			else
			{
				fontCollectionIndex = FontCollectionIndex.Minor;
				defaultFonts = Slide.CreateThemeEffective().FontScheme.Minor;
			}
		}
		IParagraphFormat[] textStyleCache = TextStyleCache;
		if (TextFrameFormat.AutofitType == TextAutofitType.Normal)
		{
			if (autoShape.Version_OldMode != autoShape.uint_1)
			{
				float num3 = 1f;
				float num4 = 0f;
				class532_0 = new Class532(textStyleCache, paragraphCollection_0, width, height, columnCount, (float)columnSpacing, wrap != NullableBool.False, anchoringType, centerText == NullableBool.True, Slide, floatColor, defaultFonts, fontCollectionIndex, num3, num4, rc);
				if (WantedSizeWithoutEmptyLines.Height > height)
				{
					bool flag = false;
					if (autoShape.Placeholder != null)
					{
						flag = (Enum136)class1155_0[autoShape.Placeholder.Type] == Enum136.const_1;
					}
					if (flag)
					{
						num3 = 0.9f;
						class532_0.method_1(num3, num4);
					}
					else
					{
						class532_0.method_0(height, 0.2f);
						float num5 = 0.75f;
						float num6 = 1f;
						while ((double)(num6 - num5) > 0.10010000149011612)
						{
							num3 = (float)((double)num5 + Math.Round((num6 - num5) / 0.1f / 2f) * 0.10000000149011612);
							class532_0.method_1(num3, 0.2f);
							if (WantedSizeWithoutEmptyLines.Height > height)
							{
								num6 = num3;
							}
							else
							{
								num5 = num3;
							}
						}
						if (WantedSizeWithoutEmptyLines.Height > height && num3 > 0.25f)
						{
							num3 -= 0.1f;
							class532_0.method_1(num3, 0.2f);
						}
						if (WantedSizeWithoutEmptyLines.Height < height)
						{
							class532_0.method_0(height, 0.1f);
							if (WantedSizeWithoutEmptyLines.Height < height)
							{
								class532_0.method_0(height, 0f);
								if (WantedSizeWithoutEmptyLines.Height > height)
								{
									num4 = 0.1f;
									class532_0.method_0(height, num4);
								}
								else
								{
									num4 = 0f;
								}
							}
							else
							{
								num4 = 0.2f;
								class532_0.method_0(height, num4);
							}
						}
					}
				}
				textFrameFormat_0.PPTXUnsupportedProps.NormalAutofitFontScale = num3;
				textFrameFormat_0.PPTXUnsupportedProps.NormalAutofitLineSpaceReduction = num4;
			}
			else
			{
				class532_0 = new Class532(textStyleCache, paragraphCollection_0, width, height, columnCount, (float)columnSpacing, wrap != NullableBool.False, anchoringType, centerText == NullableBool.True, Slide, floatColor, defaultFonts, fontCollectionIndex, textFrameFormat_0.PPTXUnsupportedProps.NormalAutofitFontScale, textFrameFormat_0.PPTXUnsupportedProps.NormalAutofitLineSpaceReduction, rc);
			}
		}
		else
		{
			class532_0 = new Class532(textStyleCache, paragraphCollection_0, width, height, columnCount, (float)columnSpacing, wrap != NullableBool.False, anchoringType, centerText == NullableBool.True, Slide, floatColor, defaultFonts, fontCollectionIndex, 1f, 0f, rc);
		}
		class532_0.uint_0 = autoShape.Version_OldMode;
	}

	internal void method_5(TextFrame[] parentFrames, TextFrame textFrameToUpdate)
	{
		TextFrameFormat textFrameFormat = (TextFrameFormat)textFrameToUpdate.TextFrameFormat;
		textFrameFormat.TextVerticalType = textFrameFormat_0.InheritedTextVerticalType;
		int columnCount = textFrameFormat_0.PPTXUnsupportedProps.ColumnCount;
		double columnSpacing = textFrameFormat_0.PPTXUnsupportedProps.ColumnSpacing;
		NullableBool wrap = textFrameFormat_0.PPTXUnsupportedProps.Wrap;
		TextAnchorType anchoringType = textFrameFormat_0.AnchoringType;
		NullableBool centerText = textFrameFormat_0.CenterText;
		if (parentFrames != null)
		{
			for (int i = 0; i < parentFrames.Length; i++)
			{
				if (columnCount == 0)
				{
					columnCount = parentFrames[i].textFrameFormat_0.PPTXUnsupportedProps.ColumnCount;
				}
				if (double.IsNaN(columnSpacing))
				{
					columnSpacing = parentFrames[i].textFrameFormat_0.PPTXUnsupportedProps.ColumnSpacing;
				}
				if (wrap == NullableBool.NotDefined)
				{
					wrap = parentFrames[i].textFrameFormat_0.PPTXUnsupportedProps.Wrap;
				}
				if (anchoringType == TextAnchorType.NotDefined)
				{
					anchoringType = parentFrames[i].textFrameFormat_0.AnchoringType;
				}
				if (centerText == NullableBool.NotDefined)
				{
					centerText = parentFrames[i].textFrameFormat_0.CenterText;
				}
			}
		}
		textFrameFormat.PPTXUnsupportedProps.ColumnCount = columnCount;
		textFrameFormat.PPTXUnsupportedProps.ColumnSpacing = columnSpacing;
		textFrameFormat.PPTXUnsupportedProps.Wrap = wrap;
		textFrameFormat.AnchoringType = anchoringType;
		textFrameFormat.CenterText = centerText;
		IParagraphFormat[] textStyleCache = TextStyleCache;
		for (int j = 0; j < textStyleCache.Length; j++)
		{
			((TextStyle)textFrameToUpdate.TextFrameFormat.TextStyle).method_1(j + 1, (ParagraphFormat)textStyleCache[j]);
		}
	}

	internal void method_6(float width, float height, Class142 cellTextStyle, Class169 rc)
	{
		_ = textFrameFormat_0.InheritedTextVerticalType;
		FloatColor floatColor = null;
		IFontsEffectiveData fontsEffectiveData = null;
		FontCollectionIndex fontCollectionIndex = FontCollectionIndex.None;
		BaseSlide baseSlide = (BaseSlide)Slide;
		if (baseSlide is Slide && (baseSlide != null || !(baseSlide is Slide)))
		{
			_ = ((Slide)baseSlide).SlideNumber;
		}
		IMasterSlide masterSlide = null;
		Cell cell = (Cell)islideComponent_0;
		if (baseSlide is Slide)
		{
			masterSlide = ((Slide)baseSlide).MasterSlide;
		}
		else if (baseSlide is LayoutSlide)
		{
			masterSlide = ((LayoutSlide)baseSlide).MasterSlide;
		}
		else if (baseSlide is MasterSlide)
		{
			masterSlide = (MasterSlide)baseSlide;
		}
		IParagraphFormat[] array = new ParagraphFormat[9];
		TextStyle textStyle = ((Presentation)baseSlide.ParentPresentation).textStyle_0;
		if (masterSlide != null)
		{
			textStyle = (TextStyle)masterSlide.OtherStyle;
		}
		if (cellTextStyle != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = textStyle.GetLevel(i);
				if (array[i] == null)
				{
					array[i] = new ParagraphFormat(Aspose.Slides.Presentation.iparagraphFormat_0, this);
				}
				else
				{
					array[i] = ((ParagraphFormat)array[i]).method_3(Aspose.Slides.Presentation.iparagraphFormat_0);
				}
			}
		}
		else
		{
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = new ParagraphFormat(Aspose.Slides.Presentation.iparagraphFormat_0, this);
			}
		}
		if (cellTextStyle != null)
		{
			floatColor = ((ColorFormat)cellTextStyle.SchemeColor).method_4(baseSlide, null);
			switch (cellTextStyle.FontSource)
			{
			case Enum274.const_0:
				fontsEffectiveData = null;
				break;
			case Enum274.const_1:
				fontsEffectiveData = new FontsEffectiveData();
				((FontsEffectiveData)fontsEffectiveData).method_0(cellTextStyle.Fonts);
				break;
			case Enum274.const_2:
				fontCollectionIndex = cellTextStyle.FontIndex;
				fontsEffectiveData = fontCollectionIndex switch
				{
					FontCollectionIndex.Major => Slide.CreateThemeEffective().FontScheme.Major, 
					_ => Slide.CreateThemeEffective().FontScheme.Minor, 
				};
				break;
			}
			for (int k = 0; k < array.Length; k++)
			{
				array[k].DefaultPortionFormat.FontBold = cellTextStyle.IsBold;
				array[k].DefaultPortionFormat.FontItalic = cellTextStyle.IsItalic;
				if (fontsEffectiveData != null)
				{
					array[k].DefaultPortionFormat.LatinFont = new FontData(fontsEffectiveData.LatinFont);
					array[k].DefaultPortionFormat.EastAsianFont = new FontData(fontsEffectiveData.EastAsianFont);
					array[k].DefaultPortionFormat.ComplexScriptFont = new FontData(fontsEffectiveData.ComplexScriptFont);
				}
				if (floatColor != null)
				{
					array[k].DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
					array[k].DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.StyleColor;
				}
			}
		}
		if (TextFrameFormat.TextStyle != null)
		{
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = ((TextStyle)TextFrameFormat.TextStyle).method_7(l, array[l]);
			}
		}
		if (fontsEffectiveData == null)
		{
			fontsEffectiveData = Slide.CreateThemeEffective().FontScheme.Minor;
		}
		class532_0 = new Class532(array, paragraphCollection_0, width, height, textFrameFormat_0.PPTXUnsupportedProps.ColumnCount, (float)textFrameFormat_0.PPTXUnsupportedProps.ColumnSpacing, textFrameFormat_0.PPTXUnsupportedProps.Wrap != NullableBool.False, (textFrameFormat_0.AnchoringType == TextAnchorType.NotDefined) ? cell.TextAnchorType : textFrameFormat_0.AnchoringType, textFrameFormat_0.CenterText == NullableBool.True, baseSlide, floatColor, fontsEffectiveData, fontCollectionIndex, 1f, 0f, rc);
	}

	private static MasterSlide smethod_0(BaseSlide slide)
	{
		if (slide is Slide slide2)
		{
			return (MasterSlide)slide2.MasterSlide;
		}
		if (slide is LayoutSlide layoutSlide)
		{
			return (MasterSlide)layoutSlide.MasterSlide;
		}
		return slide as MasterSlide;
	}

	private ParagraphFormat[] method_7()
	{
		ParagraphFormat[] array = new ParagraphFormat[9];
		if (Presentation != null)
		{
			TextStyle textStyle_ = ((Presentation)Presentation).textStyle_0;
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (ParagraphFormat)textStyle_.GetLevel(i);
			}
		}
		else
		{
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = (ParagraphFormat)Aspose.Slides.Presentation.iparagraphFormat_0;
			}
		}
		return array;
	}

	private ParagraphFormat[] method_8(BaseSlide parent, out FloatColor styleColor)
	{
		ParagraphFormat[] array = new ParagraphFormat[9];
		styleColor = null;
		MasterSlide masterSlide = smethod_0(parent);
		TextStyle textStyle_ = ((Presentation)Presentation).textStyle_0;
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (ParagraphFormat)textStyle_.GetLevel(i);
		}
		ParagraphFormat paragraphFormat = new ParagraphFormat(((ParagraphFormat)textStyle_.DefaultParagraphFormat).ipresentationComponent_0);
		if (masterSlide != null)
		{
			paragraphFormat = paragraphFormat.method_3(masterSlide.BodyStyle.DefaultParagraphFormat);
		}
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = ((array[j] == null) ? paragraphFormat : array[j].method_3(Aspose.Slides.Presentation.iparagraphFormat_0));
		}
		return array;
	}

	private IParagraphFormat[] method_9(BaseSlide slide, IMasterSlide master, Class142 cellTextStyle, out FloatColor styleColor)
	{
		IParagraphFormat[] array = new ParagraphFormat[9];
		styleColor = null;
		TextStyle textStyle = ((Presentation)slide.ParentPresentation).textStyle_0;
		if (master != null)
		{
			textStyle = (TextStyle)master.OtherStyle;
		}
		if (cellTextStyle != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = textStyle.GetLevel(i);
				if (array[i] == null)
				{
					array[i] = new ParagraphFormat(Aspose.Slides.Presentation.iparagraphFormat_0, this);
				}
				else
				{
					array[i] = ((ParagraphFormat)array[i]).method_3(Aspose.Slides.Presentation.iparagraphFormat_0);
				}
			}
		}
		else
		{
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = new ParagraphFormat(Aspose.Slides.Presentation.iparagraphFormat_0, this);
			}
		}
		if (cellTextStyle != null)
		{
			styleColor = ((ColorFormat)cellTextStyle.SchemeColor).method_4(slide, null);
			for (int k = 0; k < array.Length; k++)
			{
				array[k].DefaultPortionFormat.FontBold = cellTextStyle.IsBold;
				array[k].DefaultPortionFormat.FontItalic = cellTextStyle.IsItalic;
				if (styleColor != null)
				{
					array[k].DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
					array[k].DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.StyleColor;
				}
			}
		}
		if (textFrameFormat_0.textStyle_0 != null)
		{
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = textFrameFormat_0.textStyle_0.method_7(l, array[l]);
			}
		}
		return array;
	}

	internal void method_10(Class159 canvas, Class169 rc)
	{
		class532_0.method_4(canvas, rc);
	}

	public void JoinPortionsWithSameFormatting()
	{
		foreach (IParagraph paragraph in Paragraphs)
		{
			paragraph.JoinPortionsWithSameFormatting();
		}
	}

	internal void method_11(Class369 shape, Class437 style, Class437 textStyle)
	{
		textFrameFormat_0.AnchoringType = TextAnchorType.NotDefined;
		textFrameFormat_0.CenterText = NullableBool.True;
		textFrameFormat_0.PPTXUnsupportedProps.CompatibleLineSpacing = NullableBool.NotDefined;
		paragraphCollection_0.Clear();
		List<Class369> list = new List<Class369>();
		if (style != null)
		{
			if (style.ParentStyleName != null)
			{
				list.Add(style.ParentStyleName);
			}
			list.Add(style);
		}
		if (textStyle != null)
		{
			if (textStyle.ParentStyleName != null)
			{
				list.Add(textStyle.ParentStyleName);
			}
			list.Add(textStyle);
		}
		foreach (Class437 item in list)
		{
			if (item.GraphicProperties != null)
			{
				if (!double.IsNaN(item.GraphicProperties.PaddingBottom))
				{
					TextFrameFormat.MarginBottom = (float)item.GraphicProperties.PaddingBottom;
				}
				if (!double.IsNaN(item.GraphicProperties.PaddingTop))
				{
					TextFrameFormat.MarginTop = (float)item.GraphicProperties.PaddingTop;
				}
				if (!double.IsNaN(item.GraphicProperties.PaddingLeft))
				{
					TextFrameFormat.MarginLeft = (float)item.GraphicProperties.PaddingLeft;
				}
				if (!double.IsNaN(item.GraphicProperties.PaddingRight))
				{
					TextFrameFormat.MarginRight = (float)item.GraphicProperties.PaddingRight;
				}
				switch (item.GraphicProperties.TextareaVerticalAlign)
				{
				case Enum93.const_0:
					textFrameFormat_0.AnchoringType = TextAnchorType.Top;
					break;
				case Enum93.const_1:
					textFrameFormat_0.AnchoringType = TextAnchorType.Center;
					break;
				case Enum93.const_2:
					textFrameFormat_0.AnchoringType = TextAnchorType.Bottom;
					break;
				case Enum93.const_3:
					textFrameFormat_0.AnchoringType = TextAnchorType.Justified;
					break;
				}
			}
			if (item.ParagraphProperties != null && item.ParagraphProperties.FontIndependentLineSpacing != NullableBool.NotDefined)
			{
				textFrameFormat_0.PPTXUnsupportedProps.CompatibleLineSpacing = item.ParagraphProperties.FontIndependentLineSpacing;
			}
		}
		method_12(shape, list, 0);
	}

	internal void method_12(Class369 parent, List<Class369> styles, int level)
	{
		foreach (XmlNode childNode in parent.ChildNodes)
		{
			List<Class369> list = new List<Class369>(styles);
			if (childNode is Class456 @class)
			{
				Paragraph paragraph = new Paragraph();
				paragraphCollection_0.Add(paragraph);
				if (@class.StyleName != null)
				{
					list.Add(@class.StyleName);
				}
				paragraph.method_7(@class, list, level);
			}
			else if (childNode is Class455 class2)
			{
				int level2 = level + 1;
				if (class2.ListStyleName != null)
				{
					list.Add(class2.ListStyleName);
				}
				Class369[] array = class2.method_29("list-item", "urn:oasis:names:tc:opendocument:xmlns:text:1.0");
				Class369[] array2 = array;
				foreach (Class369 parent2 in array2)
				{
					method_12(parent2, list, level2);
				}
			}
		}
		if (paragraphCollection_0.Count == 0 && (parent.ParentNode as Class369) is Class384)
		{
			Class456 p = (Class456)parent.method_35("p", "urn:oasis:names:tc:opendocument:xmlns:text:1.0");
			Paragraph paragraph2 = new Paragraph();
			paragraphCollection_0.Add(paragraph2);
			paragraph2.method_7(p, styles, level);
			Portion portion = new Portion();
			paragraph2.Portions.Add(portion);
			portion.method_5("", styles, null);
		}
	}

	internal void method_13(Class476 odpPackage, Class369 shape, Class438 autoStyles, Class437 shapeStyle)
	{
		shapeStyle.method_37();
		if (textFrameFormat_0.PPTXUnsupportedProps.CompatibleLineSpacing != NullableBool.NotDefined)
		{
			shapeStyle.method_38();
			shapeStyle.ParagraphProperties.FontIndependentLineSpacing = textFrameFormat_0.PPTXUnsupportedProps.CompatibleLineSpacing;
		}
		switch (textFrameFormat_0.AnchoringType)
		{
		case TextAnchorType.Top:
			shapeStyle.GraphicProperties.TextareaVerticalAlign = Enum93.const_0;
			break;
		case TextAnchorType.Center:
			shapeStyle.GraphicProperties.TextareaVerticalAlign = Enum93.const_1;
			break;
		case TextAnchorType.Bottom:
			shapeStyle.GraphicProperties.TextareaVerticalAlign = Enum93.const_2;
			break;
		case TextAnchorType.Justified:
			shapeStyle.GraphicProperties.TextareaVerticalAlign = Enum93.const_3;
			break;
		}
		if (!double.IsNaN(TextFrameFormat.MarginLeft))
		{
			shapeStyle.GraphicProperties.PaddingLeft = TextFrameFormat.MarginLeft;
		}
		if (!double.IsNaN(TextFrameFormat.MarginRight))
		{
			shapeStyle.GraphicProperties.PaddingRight = TextFrameFormat.MarginRight;
		}
		if (!double.IsNaN(TextFrameFormat.MarginTop))
		{
			shapeStyle.GraphicProperties.PaddingTop = TextFrameFormat.MarginTop;
		}
		if (!double.IsNaN(TextFrameFormat.MarginBottom))
		{
			shapeStyle.GraphicProperties.PaddingBottom = TextFrameFormat.MarginBottom;
		}
		foreach (Paragraph item in paragraphCollection_0)
		{
			item.method_9(odpPackage, autoStyles, shape);
		}
	}

	internal void method_14(Class369 parent, List<Class369> textStyles, int level)
	{
		Class369[] array = parent.method_29("list", "urn:oasis:names:tc:opendocument:xmlns:text:1.0");
		int level2 = level + 1;
		Class369[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Class455 @class = (Class455)array2[i];
			if (@class.ListStyleName != null)
			{
				textStyles.Add(@class.ListStyleName);
			}
			Class369[] array3 = @class.method_29("list-item", "urn:oasis:names:tc:opendocument:xmlns:text:1.0");
			Class369[] array4 = array3;
			foreach (Class369 parent2 in array4)
			{
				method_14(parent2, textStyles, level2);
				method_15(parent2, textStyles, level2);
			}
		}
	}

	internal void method_15(Class369 parent, List<Class369> textStyles, int level)
	{
		Class369[] array = parent.method_29("p", "urn:oasis:names:tc:opendocument:xmlns:text:1.0");
		Class369[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Class456 @class = (Class456)array2[i];
			Paragraph paragraph = new Paragraph();
			paragraphCollection_0.Add(paragraph);
			if (@class.StyleName != null)
			{
				textStyles.Add(@class.StyleName);
			}
			paragraph.method_7(@class, textStyles, level);
		}
	}
}
