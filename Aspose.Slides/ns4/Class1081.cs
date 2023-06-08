using System;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns15;

namespace ns4;

internal class Class1081
{
	internal static LayoutSlide smethod_0(IMasterSlide masterSlide, SlideLayoutType layoutType)
	{
		return smethod_1(masterSlide, layoutType, null);
	}

	internal static LayoutSlide smethod_1(IMasterSlide masterSlide, SlideLayoutType layoutType, Class857 deserializationContext)
	{
		Class150 @class = new Class150(masterSlide, layoutType);
		switch (layoutType)
		{
		default:
			throw new IndexOutOfRangeException();
		case SlideLayoutType.Custom:
			return smethod_13(@class);
		case SlideLayoutType.Title:
			return smethod_2(@class);
		case SlideLayoutType.TitleOnly:
			return smethod_7(@class);
		case SlideLayoutType.Blank:
			return smethod_8(@class);
		case SlideLayoutType.TitleAndObject:
			return smethod_3(@class);
		case SlideLayoutType.VerticalText:
			return smethod_11(@class);
		case SlideLayoutType.VerticalTitleAndText:
			return smethod_12(@class);
		case SlideLayoutType.TwoObjects:
			return smethod_5(@class);
		case SlideLayoutType.Text:
		case SlideLayoutType.TwoColumnText:
		case SlideLayoutType.Table:
		case SlideLayoutType.TextAndChart:
		case SlideLayoutType.ChartAndText:
		case SlideLayoutType.Diagram:
		case SlideLayoutType.Chart:
		case SlideLayoutType.TextAndClipArt:
		case SlideLayoutType.ClipArtAndText:
		case SlideLayoutType.TextAndObject:
		case SlideLayoutType.ObjectAndText:
		case SlideLayoutType.Object:
		case SlideLayoutType.TextAndMedia:
		case SlideLayoutType.MediaAndText:
		case SlideLayoutType.ObjectOverText:
		case SlideLayoutType.TextOverObject:
		case SlideLayoutType.TextAndTwoObjects:
		case SlideLayoutType.TwoObjectsAndText:
		case SlideLayoutType.TwoObjectsOverText:
		case SlideLayoutType.FourObjects:
		case SlideLayoutType.ClipArtAndVerticalText:
		case SlideLayoutType.VerticalTitleAndTextOverChart:
		case SlideLayoutType.ObjectAndTwoObject:
		case SlideLayoutType.TwoObjectsAndObject:
			if (deserializationContext != null)
			{
				deserializationContext.DomPresentation.LoadOptions.method_1(string.Concat("SlideLayoutType ", layoutType, " PPT deserialization is not implemented yet."), WarningType.MajorFormattingLoss);
				@class.LayoutType = SlideLayoutType.Blank;
				return smethod_8(@class);
			}
			throw new NotImplementedException(string.Concat("Layout type ", layoutType, " is not supported now"));
		case SlideLayoutType.SectionHeader:
			return smethod_4(@class);
		case SlideLayoutType.TwoTextAndTwoObjects:
			return smethod_6(@class);
		case SlideLayoutType.TitleObjectAndCaption:
			return smethod_9(@class);
		case SlideLayoutType.PictureAndCaption:
			return smethod_10(@class);
		}
	}

	internal static LayoutSlide smethod_2(Class150 layoutTemplatesContext)
	{
		LayoutSlide result = layoutTemplatesContext.method_0("Title Slide");
		layoutTemplatesContext.method_5(54.0, 167.75, 612.0, 115.75);
		smethod_14(layoutTemplatesContext, centered: true);
		layoutTemplatesContext.method_5(108.0, 306.0, 504.0, 138.0);
		layoutTemplatesContext.method_6(smethod_24(0));
		smethod_16(layoutTemplatesContext);
		smethod_21(layoutTemplatesContext);
		smethod_22(layoutTemplatesContext);
		smethod_23(layoutTemplatesContext);
		return result;
	}

	internal static LayoutSlide smethod_3(Class150 layoutTemplatesContext)
	{
		LayoutSlide result = layoutTemplatesContext.method_0("Title and Content");
		smethod_14(layoutTemplatesContext, centered: false);
		smethod_19(layoutTemplatesContext, PlaceholderSize.Full);
		smethod_21(layoutTemplatesContext);
		smethod_22(layoutTemplatesContext);
		smethod_23(layoutTemplatesContext);
		return result;
	}

	internal static LayoutSlide smethod_4(Class150 layoutTemplatesContext)
	{
		LayoutSlide result = layoutTemplatesContext.method_0("Section Header");
		layoutTemplatesContext.method_5(56.87503937007874, 347.0, 612.0, 107.25);
		layoutTemplatesContext.method_6(smethod_24(1));
		layoutTemplatesContext.method_7(TextAnchorType.Top);
		smethod_14(layoutTemplatesContext, centered: false);
		layoutTemplatesContext.method_5(56.87503937007874, 228.87503937007875, 612.0, 118.12496062992126);
		layoutTemplatesContext.method_6(smethod_24(2));
		layoutTemplatesContext.method_7(TextAnchorType.Bottom);
		smethod_17(layoutTemplatesContext, PlaceholderSize.Full);
		smethod_21(layoutTemplatesContext);
		smethod_22(layoutTemplatesContext);
		smethod_23(layoutTemplatesContext);
		return result;
	}

	internal static LayoutSlide smethod_5(Class150 layoutTemplatesContext)
	{
		LayoutSlide result = layoutTemplatesContext.method_0("Two Content");
		smethod_14(layoutTemplatesContext, centered: false);
		layoutTemplatesContext.method_5(36.0, 126.0, 318.0, 356.37503937007875);
		layoutTemplatesContext.method_6(smethod_24(3));
		smethod_19(layoutTemplatesContext, PlaceholderSize.Half);
		layoutTemplatesContext.method_5(366.0, 126.0, 318.0, 356.37503937007875);
		layoutTemplatesContext.method_6(smethod_24(4));
		smethod_19(layoutTemplatesContext, PlaceholderSize.Half);
		smethod_21(layoutTemplatesContext);
		smethod_22(layoutTemplatesContext);
		smethod_23(layoutTemplatesContext);
		return result;
	}

	internal static LayoutSlide smethod_6(Class150 layoutTemplatesContext)
	{
		LayoutSlide result = layoutTemplatesContext.method_0("Comparison");
		layoutTemplatesContext.method_6(smethod_24(5));
		smethod_14(layoutTemplatesContext, centered: false);
		layoutTemplatesContext.method_5(36.0, 120.87503937007874, 318.12503937007875, 50.37496062992126);
		layoutTemplatesContext.method_6(smethod_24(6));
		layoutTemplatesContext.method_7(TextAnchorType.Bottom);
		smethod_17(layoutTemplatesContext, PlaceholderSize.Full);
		layoutTemplatesContext.method_5(36.0, 171.25, 318.12503937007875, 311.12503937007875);
		layoutTemplatesContext.method_6(smethod_24(7));
		smethod_19(layoutTemplatesContext, PlaceholderSize.Half);
		layoutTemplatesContext.method_5(365.75, 120.87503937007874, 318.25, 50.37496062992126);
		layoutTemplatesContext.method_6(smethod_24(8));
		layoutTemplatesContext.method_7(TextAnchorType.Bottom);
		smethod_17(layoutTemplatesContext, PlaceholderSize.Quarter);
		layoutTemplatesContext.method_5(365.75, 171.25, 318.25, 311.12503937007875);
		layoutTemplatesContext.method_6(smethod_24(9));
		smethod_19(layoutTemplatesContext, PlaceholderSize.Quarter);
		smethod_21(layoutTemplatesContext);
		smethod_22(layoutTemplatesContext);
		smethod_23(layoutTemplatesContext);
		return result;
	}

	internal static LayoutSlide smethod_7(Class150 layoutTemplatesContext)
	{
		LayoutSlide result = layoutTemplatesContext.method_0("Title Only");
		smethod_14(layoutTemplatesContext, centered: false);
		smethod_21(layoutTemplatesContext);
		smethod_22(layoutTemplatesContext);
		smethod_23(layoutTemplatesContext);
		return result;
	}

	internal static LayoutSlide smethod_8(Class150 layoutTemplatesContext)
	{
		LayoutSlide result = layoutTemplatesContext.method_0("Blank");
		smethod_21(layoutTemplatesContext);
		smethod_22(layoutTemplatesContext);
		smethod_23(layoutTemplatesContext);
		return result;
	}

	internal static LayoutSlide smethod_9(Class150 layoutTemplatesContext)
	{
		LayoutSlide result = layoutTemplatesContext.method_0("Content with Caption");
		layoutTemplatesContext.method_5(36.0, 21.5, 236.87503937007875, 91.5);
		layoutTemplatesContext.method_6(smethod_24(10));
		layoutTemplatesContext.method_7(TextAnchorType.Bottom);
		smethod_14(layoutTemplatesContext, centered: false);
		layoutTemplatesContext.method_5(281.5, 21.5, 402.5, 460.87503937007875);
		layoutTemplatesContext.method_6(smethod_24(11));
		smethod_19(layoutTemplatesContext, PlaceholderSize.Full);
		layoutTemplatesContext.method_5(36.0, 113.0, 236.87503937007875, 369.37503937007875);
		layoutTemplatesContext.method_6(smethod_24(12));
		smethod_17(layoutTemplatesContext, PlaceholderSize.Half);
		smethod_21(layoutTemplatesContext);
		smethod_22(layoutTemplatesContext);
		smethod_23(layoutTemplatesContext);
		return result;
	}

	internal static LayoutSlide smethod_10(Class150 layoutTemplatesContext)
	{
		LayoutSlide result = layoutTemplatesContext.method_0("Picture with Caption");
		layoutTemplatesContext.method_5(141.12503937007875, 378.0, 432.0, 44.62503937007874);
		layoutTemplatesContext.method_6(smethod_24(13));
		layoutTemplatesContext.method_7(TextAnchorType.Bottom);
		smethod_14(layoutTemplatesContext, centered: false);
		layoutTemplatesContext.method_5(141.12503937007875, 48.25, 432.0, 324.0);
		layoutTemplatesContext.method_6(smethod_24(14));
		smethod_20(layoutTemplatesContext);
		layoutTemplatesContext.method_5(141.12503937007875, 422.62503937007875, 432.0, 63.37496062992126);
		layoutTemplatesContext.method_6(smethod_24(15));
		smethod_17(layoutTemplatesContext, PlaceholderSize.Half);
		smethod_21(layoutTemplatesContext);
		smethod_22(layoutTemplatesContext);
		smethod_23(layoutTemplatesContext);
		return result;
	}

	internal static LayoutSlide smethod_11(Class150 layoutTemplatesContext)
	{
		LayoutSlide result = layoutTemplatesContext.method_0("Title and Vertical Text");
		smethod_14(layoutTemplatesContext, centered: false);
		smethod_18(layoutTemplatesContext);
		smethod_21(layoutTemplatesContext);
		smethod_22(layoutTemplatesContext);
		smethod_23(layoutTemplatesContext);
		return result;
	}

	internal static LayoutSlide smethod_12(Class150 layoutTemplatesContext)
	{
		LayoutSlide result = layoutTemplatesContext.method_0("Vertical Title and Text");
		layoutTemplatesContext.method_5(522.0, 21.62503937007874, 162.0, 460.75);
		smethod_15(layoutTemplatesContext);
		layoutTemplatesContext.method_5(36.0, 21.62503937007874, 474.0, 460.75);
		smethod_18(layoutTemplatesContext);
		smethod_21(layoutTemplatesContext);
		smethod_22(layoutTemplatesContext);
		smethod_23(layoutTemplatesContext);
		return result;
	}

	internal static LayoutSlide smethod_13(Class150 layoutTemplatesContext)
	{
		return layoutTemplatesContext.method_0("Custom Layout");
	}

	private static void smethod_14(Class150 layoutTemplatesContext, bool centered)
	{
		AutoShape autoShape = layoutTemplatesContext.method_1("Title", Orientation.Horizontal, PlaceholderSize.Full, centered ? PlaceholderType.CenteredTitle : PlaceholderType.Title);
		if (autoShape != null)
		{
			Paragraph paragraph = new Paragraph();
			Portion portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Click to edit Master title style";
			paragraph.Portions.Add(portion);
			layoutTemplatesContext.method_4(portion);
			Portion portion2 = new Portion();
			portion2.PortionFormat.LanguageId = "en-US";
			paragraph.Portions.Add(portion2);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			layoutTemplatesContext.method_3();
		}
	}

	private static void smethod_15(Class150 layoutTemplatesContext)
	{
		AutoShape autoShape = layoutTemplatesContext.method_1("Vertical Title", Orientation.Vertical, PlaceholderSize.Full, PlaceholderType.Title);
		if (autoShape != null)
		{
			autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;
			Paragraph paragraph = new Paragraph();
			Portion portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Click to edit Master title style";
			paragraph.Portions.Add(portion);
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			layoutTemplatesContext.method_3();
		}
	}

	private static void smethod_16(Class150 layoutTemplatesContext)
	{
		AutoShape autoShape = layoutTemplatesContext.method_1("Subtitle", Orientation.Horizontal, PlaceholderSize.Full, PlaceholderType.Subtitle);
		if (autoShape != null)
		{
			Paragraph paragraph = new Paragraph();
			Portion portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Click to edit Master subtitle style";
			paragraph.Portions.Add(portion);
			Portion portion2 = new Portion();
			portion2.PortionFormat.LanguageId = "en-US";
			paragraph.Portions.Add(portion2);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			layoutTemplatesContext.method_3();
		}
	}

	private static void smethod_17(Class150 layoutTemplatesContext, PlaceholderSize placeholderSize)
	{
		AutoShape autoShape = layoutTemplatesContext.method_1("Text Placeholder", Orientation.Horizontal, placeholderSize, PlaceholderType.Body);
		if (autoShape != null)
		{
			Paragraph paragraph = new Paragraph();
			paragraph.ParagraphFormat.Depth = 0;
			Portion portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Click to edit Master text styles";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			layoutTemplatesContext.method_3();
		}
	}

	private static void smethod_18(Class150 layoutTemplatesContext)
	{
		AutoShape autoShape = layoutTemplatesContext.method_1("Vertical Text Placeholder", Orientation.Vertical, PlaceholderSize.Full, PlaceholderType.Body);
		if (autoShape != null)
		{
			autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;
			Paragraph paragraph = new Paragraph();
			paragraph.ParagraphFormat.Depth = 0;
			Portion portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Click to edit Master text styles";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			paragraph = new Paragraph();
			paragraph.ParagraphFormat.Depth = 1;
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Second level";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			paragraph = new Paragraph();
			paragraph.ParagraphFormat.Depth = 2;
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Third level";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			paragraph = new Paragraph();
			paragraph.ParagraphFormat.Depth = 3;
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Fourth level";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			paragraph = new Paragraph();
			paragraph.ParagraphFormat.Depth = 4;
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Fifth level";
			paragraph.Portions.Add(portion);
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			layoutTemplatesContext.method_3();
		}
	}

	private static void smethod_19(Class150 layoutTemplatesContext, PlaceholderSize placeholderSize)
	{
		AutoShape autoShape = layoutTemplatesContext.method_1("Content Placeholder", Orientation.Horizontal, placeholderSize, PlaceholderType.Object);
		if (autoShape != null)
		{
			Paragraph paragraph = new Paragraph();
			paragraph.ParagraphFormat.Depth = 0;
			Portion portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Click to edit Master text styles";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			paragraph = new Paragraph();
			paragraph.ParagraphFormat.Depth = 1;
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Second level";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			paragraph = new Paragraph();
			paragraph.ParagraphFormat.Depth = 2;
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Third level";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			paragraph = new Paragraph();
			paragraph.ParagraphFormat.Depth = 3;
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Fourth level";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			paragraph = new Paragraph();
			paragraph.ParagraphFormat.Depth = 4;
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Fifth level";
			paragraph.Portions.Add(portion);
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			layoutTemplatesContext.method_3();
		}
	}

	private static void smethod_20(Class150 layoutTemplatesContext)
	{
		AutoShape autoShape = layoutTemplatesContext.method_1("Picture Placeholder", Orientation.Horizontal, PlaceholderSize.Full, PlaceholderType.Picture);
		if (autoShape != null)
		{
			Paragraph paragraph = new Paragraph();
			Portion portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			layoutTemplatesContext.method_3();
		}
	}

	private static void smethod_21(Class150 layoutTemplatesContext)
	{
		AutoShape autoShape = layoutTemplatesContext.method_1("Date Placeholder", Orientation.Horizontal, PlaceholderSize.Half, PlaceholderType.DateAndTime);
		if (autoShape != null)
		{
			Paragraph paragraph = new Paragraph();
			Portion portion = new Portion();
			portion.AddField("datetimeFigureOut");
			((Field)portion.Field).Guid = new Guid("E8FD0B7A-F5DD-4F40-B4CB-3B2C354B893A");
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "Date";
			paragraph.Portions.Add(portion);
			layoutTemplatesContext.method_4(portion);
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			layoutTemplatesContext.method_3();
		}
	}

	private static void smethod_22(Class150 layoutTemplatesContext)
	{
		AutoShape autoShape = layoutTemplatesContext.method_1("Footer Placeholder", Orientation.Horizontal, PlaceholderSize.Quarter, PlaceholderType.Footer);
		if (autoShape != null)
		{
			if (layoutTemplatesContext.autoShape_0 != null)
			{
				Paragraph paragraph = new Paragraph();
				IParagraph paragraph2 = layoutTemplatesContext.autoShape_0.TextFrame.Paragraphs[0];
				paragraph.method_0((Paragraph)paragraph2);
				autoShape.TextFrame.Paragraphs.Add(paragraph);
			}
			else
			{
				Paragraph paragraph3 = new Paragraph();
				Portion portion = new Portion();
				portion.PortionFormat.LanguageId = "en-US";
				paragraph3.Portions.Add(portion);
				autoShape.TextFrame.Paragraphs.Add(paragraph3);
				layoutTemplatesContext.method_4(portion);
			}
			layoutTemplatesContext.method_3();
		}
	}

	private static void smethod_23(Class150 layoutTemplatesContext)
	{
		AutoShape autoShape = layoutTemplatesContext.method_1("Slide Number Placeholder", Orientation.Horizontal, PlaceholderSize.Quarter, PlaceholderType.SlideNumber);
		if (autoShape != null)
		{
			Paragraph paragraph = new Paragraph();
			Portion portion = new Portion();
			portion.AddField("slidenum");
			((Field)portion.Field).Guid = new Guid("93AE1883-0942-4AA3-9DB2-9C7C3A0314B1");
			portion.PortionFormat.LanguageId = "en-US";
			portion.PortionFormat.SmartTagClean = false;
			portion.TextInternal = "‹#›";
			paragraph.Portions.Add(portion);
			layoutTemplatesContext.method_4(portion);
			portion = new Portion();
			portion.PortionFormat.LanguageId = "en-US";
			paragraph.Portions.Add(portion);
			autoShape.TextFrame.Paragraphs.Add(paragraph);
			layoutTemplatesContext.method_3();
		}
	}

	private static TextStyle smethod_24(int index)
	{
		TextStyle textStyle = new TextStyle(null);
		switch (index)
		{
		default:
			textStyle = null;
			break;
		case 0:
		{
			IParagraphFormat paragraphFormat103 = textStyle.method_3(0);
			paragraphFormat103.Bullet.Type = BulletType.None;
			paragraphFormat103.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat103.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat103.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat103.Alignment = TextAlignment.Center;
			paragraphFormat103.MarginLeft = 0f;
			paragraphFormat103.Indent = 0f;
			IParagraphFormat paragraphFormat104 = textStyle.method_3(1);
			paragraphFormat104.Bullet.Type = BulletType.None;
			paragraphFormat104.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat104.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat104.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat104.Alignment = TextAlignment.Center;
			paragraphFormat104.MarginLeft = 36f;
			paragraphFormat104.Indent = 0f;
			IParagraphFormat paragraphFormat105 = textStyle.method_3(2);
			paragraphFormat105.Bullet.Type = BulletType.None;
			paragraphFormat105.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat105.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat105.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat105.Alignment = TextAlignment.Center;
			paragraphFormat105.MarginLeft = 72f;
			paragraphFormat105.Indent = 0f;
			IParagraphFormat paragraphFormat106 = textStyle.method_3(3);
			paragraphFormat106.Bullet.Type = BulletType.None;
			paragraphFormat106.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat106.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat106.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat106.Alignment = TextAlignment.Center;
			paragraphFormat106.MarginLeft = 108f;
			paragraphFormat106.Indent = 0f;
			IParagraphFormat paragraphFormat107 = textStyle.method_3(4);
			paragraphFormat107.Bullet.Type = BulletType.None;
			paragraphFormat107.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat107.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat107.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat107.Alignment = TextAlignment.Center;
			paragraphFormat107.MarginLeft = 144f;
			paragraphFormat107.Indent = 0f;
			IParagraphFormat paragraphFormat108 = textStyle.method_3(5);
			paragraphFormat108.Bullet.Type = BulletType.None;
			paragraphFormat108.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat108.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat108.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat108.Alignment = TextAlignment.Center;
			paragraphFormat108.MarginLeft = 180f;
			paragraphFormat108.Indent = 0f;
			IParagraphFormat paragraphFormat109 = textStyle.method_3(6);
			paragraphFormat109.Bullet.Type = BulletType.None;
			paragraphFormat109.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat109.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat109.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat109.Alignment = TextAlignment.Center;
			paragraphFormat109.MarginLeft = 216f;
			paragraphFormat109.Indent = 0f;
			IParagraphFormat paragraphFormat110 = textStyle.method_3(7);
			paragraphFormat110.Bullet.Type = BulletType.None;
			paragraphFormat110.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat110.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat110.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat110.Alignment = TextAlignment.Center;
			paragraphFormat110.MarginLeft = 252f;
			paragraphFormat110.Indent = 0f;
			IParagraphFormat paragraphFormat111 = textStyle.method_3(8);
			paragraphFormat111.Bullet.Type = BulletType.None;
			paragraphFormat111.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat111.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat111.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat111.Alignment = TextAlignment.Center;
			paragraphFormat111.MarginLeft = 288f;
			paragraphFormat111.Indent = 0f;
			break;
		}
		case 1:
		{
			IParagraphFormat paragraphFormat102 = textStyle.method_3(0);
			paragraphFormat102.DefaultPortionFormat.FontHeight = 40f;
			paragraphFormat102.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat102.DefaultPortionFormat.TextCapType = TextCapType.All;
			paragraphFormat102.Alignment = TextAlignment.Left;
			break;
		}
		case 2:
		{
			IParagraphFormat paragraphFormat93 = textStyle.method_3(0);
			paragraphFormat93.Bullet.Type = BulletType.None;
			paragraphFormat93.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat93.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat93.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat93.DefaultPortionFormat.FontHeight = 20f;
			paragraphFormat93.MarginLeft = 0f;
			paragraphFormat93.Indent = 0f;
			IParagraphFormat paragraphFormat94 = textStyle.method_3(1);
			paragraphFormat94.Bullet.Type = BulletType.None;
			paragraphFormat94.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat94.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat94.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat94.DefaultPortionFormat.FontHeight = 18f;
			paragraphFormat94.MarginLeft = 36f;
			paragraphFormat94.Indent = 0f;
			IParagraphFormat paragraphFormat95 = textStyle.method_3(2);
			paragraphFormat95.Bullet.Type = BulletType.None;
			paragraphFormat95.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat95.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat95.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat95.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat95.MarginLeft = 72f;
			paragraphFormat95.Indent = 0f;
			IParagraphFormat paragraphFormat96 = textStyle.method_3(3);
			paragraphFormat96.Bullet.Type = BulletType.None;
			paragraphFormat96.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat96.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat96.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat96.DefaultPortionFormat.FontHeight = 14f;
			paragraphFormat96.MarginLeft = 108f;
			paragraphFormat96.Indent = 0f;
			IParagraphFormat paragraphFormat97 = textStyle.method_3(4);
			paragraphFormat97.Bullet.Type = BulletType.None;
			paragraphFormat97.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat97.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat97.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat97.DefaultPortionFormat.FontHeight = 14f;
			paragraphFormat97.MarginLeft = 144f;
			paragraphFormat97.Indent = 0f;
			IParagraphFormat paragraphFormat98 = textStyle.method_3(5);
			paragraphFormat98.Bullet.Type = BulletType.None;
			paragraphFormat98.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat98.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat98.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat98.DefaultPortionFormat.FontHeight = 14f;
			paragraphFormat98.MarginLeft = 180f;
			paragraphFormat98.Indent = 0f;
			IParagraphFormat paragraphFormat99 = textStyle.method_3(6);
			paragraphFormat99.Bullet.Type = BulletType.None;
			paragraphFormat99.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat99.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat99.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat99.DefaultPortionFormat.FontHeight = 14f;
			paragraphFormat99.MarginLeft = 216f;
			paragraphFormat99.Indent = 0f;
			IParagraphFormat paragraphFormat100 = textStyle.method_3(7);
			paragraphFormat100.Bullet.Type = BulletType.None;
			paragraphFormat100.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat100.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat100.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat100.DefaultPortionFormat.FontHeight = 14f;
			paragraphFormat100.MarginLeft = 252f;
			paragraphFormat100.Indent = 0f;
			IParagraphFormat paragraphFormat101 = textStyle.method_3(8);
			paragraphFormat101.Bullet.Type = BulletType.None;
			paragraphFormat101.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
			paragraphFormat101.DefaultPortionFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Text1;
			paragraphFormat101.DefaultPortionFormat.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);
			paragraphFormat101.DefaultPortionFormat.FontHeight = 14f;
			paragraphFormat101.MarginLeft = 288f;
			paragraphFormat101.Indent = 0f;
			break;
		}
		case 3:
		{
			IParagraphFormat paragraphFormat84 = textStyle.method_3(0);
			paragraphFormat84.DefaultPortionFormat.FontHeight = 28f;
			IParagraphFormat paragraphFormat85 = textStyle.method_3(1);
			paragraphFormat85.DefaultPortionFormat.FontHeight = 24f;
			IParagraphFormat paragraphFormat86 = textStyle.method_3(2);
			paragraphFormat86.DefaultPortionFormat.FontHeight = 20f;
			IParagraphFormat paragraphFormat87 = textStyle.method_3(3);
			paragraphFormat87.DefaultPortionFormat.FontHeight = 18f;
			IParagraphFormat paragraphFormat88 = textStyle.method_3(4);
			paragraphFormat88.DefaultPortionFormat.FontHeight = 18f;
			IParagraphFormat paragraphFormat89 = textStyle.method_3(5);
			paragraphFormat89.DefaultPortionFormat.FontHeight = 18f;
			IParagraphFormat paragraphFormat90 = textStyle.method_3(6);
			paragraphFormat90.DefaultPortionFormat.FontHeight = 18f;
			IParagraphFormat paragraphFormat91 = textStyle.method_3(7);
			paragraphFormat91.DefaultPortionFormat.FontHeight = 18f;
			IParagraphFormat paragraphFormat92 = textStyle.method_3(8);
			paragraphFormat92.DefaultPortionFormat.FontHeight = 18f;
			break;
		}
		case 4:
		{
			IParagraphFormat paragraphFormat75 = textStyle.method_3(0);
			paragraphFormat75.DefaultPortionFormat.FontHeight = 28f;
			IParagraphFormat paragraphFormat76 = textStyle.method_3(1);
			paragraphFormat76.DefaultPortionFormat.FontHeight = 24f;
			IParagraphFormat paragraphFormat77 = textStyle.method_3(2);
			paragraphFormat77.DefaultPortionFormat.FontHeight = 20f;
			IParagraphFormat paragraphFormat78 = textStyle.method_3(3);
			paragraphFormat78.DefaultPortionFormat.FontHeight = 18f;
			IParagraphFormat paragraphFormat79 = textStyle.method_3(4);
			paragraphFormat79.DefaultPortionFormat.FontHeight = 18f;
			IParagraphFormat paragraphFormat80 = textStyle.method_3(5);
			paragraphFormat80.DefaultPortionFormat.FontHeight = 18f;
			IParagraphFormat paragraphFormat81 = textStyle.method_3(6);
			paragraphFormat81.DefaultPortionFormat.FontHeight = 18f;
			IParagraphFormat paragraphFormat82 = textStyle.method_3(7);
			paragraphFormat82.DefaultPortionFormat.FontHeight = 18f;
			IParagraphFormat paragraphFormat83 = textStyle.method_3(8);
			paragraphFormat83.DefaultPortionFormat.FontHeight = 18f;
			break;
		}
		case 5:
			textStyle.method_3(0);
			break;
		case 6:
		{
			IParagraphFormat paragraphFormat66 = textStyle.method_3(0);
			paragraphFormat66.Bullet.Type = BulletType.None;
			paragraphFormat66.DefaultPortionFormat.FontHeight = 24f;
			paragraphFormat66.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat66.MarginLeft = 0f;
			paragraphFormat66.Indent = 0f;
			IParagraphFormat paragraphFormat67 = textStyle.method_3(1);
			paragraphFormat67.Bullet.Type = BulletType.None;
			paragraphFormat67.DefaultPortionFormat.FontHeight = 20f;
			paragraphFormat67.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat67.MarginLeft = 36f;
			paragraphFormat67.Indent = 0f;
			IParagraphFormat paragraphFormat68 = textStyle.method_3(2);
			paragraphFormat68.Bullet.Type = BulletType.None;
			paragraphFormat68.DefaultPortionFormat.FontHeight = 18f;
			paragraphFormat68.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat68.MarginLeft = 72f;
			paragraphFormat68.Indent = 0f;
			IParagraphFormat paragraphFormat69 = textStyle.method_3(3);
			paragraphFormat69.Bullet.Type = BulletType.None;
			paragraphFormat69.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat69.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat69.MarginLeft = 108f;
			paragraphFormat69.Indent = 0f;
			IParagraphFormat paragraphFormat70 = textStyle.method_3(4);
			paragraphFormat70.Bullet.Type = BulletType.None;
			paragraphFormat70.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat70.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat70.MarginLeft = 144f;
			paragraphFormat70.Indent = 0f;
			IParagraphFormat paragraphFormat71 = textStyle.method_3(5);
			paragraphFormat71.Bullet.Type = BulletType.None;
			paragraphFormat71.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat71.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat71.MarginLeft = 180f;
			paragraphFormat71.Indent = 0f;
			IParagraphFormat paragraphFormat72 = textStyle.method_3(6);
			paragraphFormat72.Bullet.Type = BulletType.None;
			paragraphFormat72.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat72.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat72.MarginLeft = 216f;
			paragraphFormat72.Indent = 0f;
			IParagraphFormat paragraphFormat73 = textStyle.method_3(7);
			paragraphFormat73.Bullet.Type = BulletType.None;
			paragraphFormat73.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat73.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat73.MarginLeft = 252f;
			paragraphFormat73.Indent = 0f;
			IParagraphFormat paragraphFormat74 = textStyle.method_3(8);
			paragraphFormat74.Bullet.Type = BulletType.None;
			paragraphFormat74.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat74.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat74.MarginLeft = 288f;
			paragraphFormat74.Indent = 0f;
			break;
		}
		case 7:
		{
			IParagraphFormat paragraphFormat57 = textStyle.method_3(0);
			paragraphFormat57.DefaultPortionFormat.FontHeight = 24f;
			IParagraphFormat paragraphFormat58 = textStyle.method_3(1);
			paragraphFormat58.DefaultPortionFormat.FontHeight = 20f;
			IParagraphFormat paragraphFormat59 = textStyle.method_3(2);
			paragraphFormat59.DefaultPortionFormat.FontHeight = 18f;
			IParagraphFormat paragraphFormat60 = textStyle.method_3(3);
			paragraphFormat60.DefaultPortionFormat.FontHeight = 16f;
			IParagraphFormat paragraphFormat61 = textStyle.method_3(4);
			paragraphFormat61.DefaultPortionFormat.FontHeight = 16f;
			IParagraphFormat paragraphFormat62 = textStyle.method_3(5);
			paragraphFormat62.DefaultPortionFormat.FontHeight = 16f;
			IParagraphFormat paragraphFormat63 = textStyle.method_3(6);
			paragraphFormat63.DefaultPortionFormat.FontHeight = 16f;
			IParagraphFormat paragraphFormat64 = textStyle.method_3(7);
			paragraphFormat64.DefaultPortionFormat.FontHeight = 16f;
			IParagraphFormat paragraphFormat65 = textStyle.method_3(8);
			paragraphFormat65.DefaultPortionFormat.FontHeight = 16f;
			break;
		}
		case 8:
		{
			IParagraphFormat paragraphFormat48 = textStyle.method_3(0);
			paragraphFormat48.Bullet.Type = BulletType.None;
			paragraphFormat48.DefaultPortionFormat.FontHeight = 24f;
			paragraphFormat48.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat48.MarginLeft = 0f;
			paragraphFormat48.Indent = 0f;
			IParagraphFormat paragraphFormat49 = textStyle.method_3(1);
			paragraphFormat49.Bullet.Type = BulletType.None;
			paragraphFormat49.DefaultPortionFormat.FontHeight = 20f;
			paragraphFormat49.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat49.MarginLeft = 36f;
			paragraphFormat49.Indent = 0f;
			IParagraphFormat paragraphFormat50 = textStyle.method_3(2);
			paragraphFormat50.Bullet.Type = BulletType.None;
			paragraphFormat50.DefaultPortionFormat.FontHeight = 18f;
			paragraphFormat50.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat50.MarginLeft = 72f;
			paragraphFormat50.Indent = 0f;
			IParagraphFormat paragraphFormat51 = textStyle.method_3(3);
			paragraphFormat51.Bullet.Type = BulletType.None;
			paragraphFormat51.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat51.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat51.MarginLeft = 108f;
			paragraphFormat51.Indent = 0f;
			IParagraphFormat paragraphFormat52 = textStyle.method_3(4);
			paragraphFormat52.Bullet.Type = BulletType.None;
			paragraphFormat52.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat52.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat52.MarginLeft = 144f;
			paragraphFormat52.Indent = 0f;
			IParagraphFormat paragraphFormat53 = textStyle.method_3(5);
			paragraphFormat53.Bullet.Type = BulletType.None;
			paragraphFormat53.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat53.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat53.MarginLeft = 180f;
			paragraphFormat53.Indent = 0f;
			IParagraphFormat paragraphFormat54 = textStyle.method_3(6);
			paragraphFormat54.Bullet.Type = BulletType.None;
			paragraphFormat54.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat54.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat54.MarginLeft = 216f;
			paragraphFormat54.Indent = 0f;
			IParagraphFormat paragraphFormat55 = textStyle.method_3(7);
			paragraphFormat55.Bullet.Type = BulletType.None;
			paragraphFormat55.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat55.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat55.MarginLeft = 252f;
			paragraphFormat55.Indent = 0f;
			IParagraphFormat paragraphFormat56 = textStyle.method_3(8);
			paragraphFormat56.Bullet.Type = BulletType.None;
			paragraphFormat56.DefaultPortionFormat.FontHeight = 16f;
			paragraphFormat56.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat56.MarginLeft = 288f;
			paragraphFormat56.Indent = 0f;
			break;
		}
		case 9:
		{
			IParagraphFormat paragraphFormat39 = textStyle.method_3(0);
			paragraphFormat39.DefaultPortionFormat.FontHeight = 24f;
			IParagraphFormat paragraphFormat40 = textStyle.method_3(1);
			paragraphFormat40.DefaultPortionFormat.FontHeight = 20f;
			IParagraphFormat paragraphFormat41 = textStyle.method_3(2);
			paragraphFormat41.DefaultPortionFormat.FontHeight = 18f;
			IParagraphFormat paragraphFormat42 = textStyle.method_3(3);
			paragraphFormat42.DefaultPortionFormat.FontHeight = 16f;
			IParagraphFormat paragraphFormat43 = textStyle.method_3(4);
			paragraphFormat43.DefaultPortionFormat.FontHeight = 16f;
			IParagraphFormat paragraphFormat44 = textStyle.method_3(5);
			paragraphFormat44.DefaultPortionFormat.FontHeight = 16f;
			IParagraphFormat paragraphFormat45 = textStyle.method_3(6);
			paragraphFormat45.DefaultPortionFormat.FontHeight = 16f;
			IParagraphFormat paragraphFormat46 = textStyle.method_3(7);
			paragraphFormat46.DefaultPortionFormat.FontHeight = 16f;
			IParagraphFormat paragraphFormat47 = textStyle.method_3(8);
			paragraphFormat47.DefaultPortionFormat.FontHeight = 16f;
			break;
		}
		case 10:
		{
			IParagraphFormat paragraphFormat38 = textStyle.method_3(0);
			paragraphFormat38.DefaultPortionFormat.FontHeight = 20f;
			paragraphFormat38.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat38.Alignment = TextAlignment.Left;
			break;
		}
		case 11:
		{
			IParagraphFormat paragraphFormat29 = textStyle.method_3(0);
			paragraphFormat29.DefaultPortionFormat.FontHeight = 32f;
			IParagraphFormat paragraphFormat30 = textStyle.method_3(1);
			paragraphFormat30.DefaultPortionFormat.FontHeight = 28f;
			IParagraphFormat paragraphFormat31 = textStyle.method_3(2);
			paragraphFormat31.DefaultPortionFormat.FontHeight = 24f;
			IParagraphFormat paragraphFormat32 = textStyle.method_3(3);
			paragraphFormat32.DefaultPortionFormat.FontHeight = 20f;
			IParagraphFormat paragraphFormat33 = textStyle.method_3(4);
			paragraphFormat33.DefaultPortionFormat.FontHeight = 20f;
			IParagraphFormat paragraphFormat34 = textStyle.method_3(5);
			paragraphFormat34.DefaultPortionFormat.FontHeight = 20f;
			IParagraphFormat paragraphFormat35 = textStyle.method_3(6);
			paragraphFormat35.DefaultPortionFormat.FontHeight = 20f;
			IParagraphFormat paragraphFormat36 = textStyle.method_3(7);
			paragraphFormat36.DefaultPortionFormat.FontHeight = 20f;
			IParagraphFormat paragraphFormat37 = textStyle.method_3(8);
			paragraphFormat37.DefaultPortionFormat.FontHeight = 20f;
			break;
		}
		case 12:
		{
			IParagraphFormat paragraphFormat20 = textStyle.method_3(0);
			paragraphFormat20.Bullet.Type = BulletType.None;
			paragraphFormat20.DefaultPortionFormat.FontHeight = 14f;
			paragraphFormat20.MarginLeft = 0f;
			paragraphFormat20.Indent = 0f;
			IParagraphFormat paragraphFormat21 = textStyle.method_3(1);
			paragraphFormat21.Bullet.Type = BulletType.None;
			paragraphFormat21.DefaultPortionFormat.FontHeight = 12f;
			paragraphFormat21.MarginLeft = 36f;
			paragraphFormat21.Indent = 0f;
			IParagraphFormat paragraphFormat22 = textStyle.method_3(2);
			paragraphFormat22.Bullet.Type = BulletType.None;
			paragraphFormat22.DefaultPortionFormat.FontHeight = 10f;
			paragraphFormat22.MarginLeft = 72f;
			paragraphFormat22.Indent = 0f;
			IParagraphFormat paragraphFormat23 = textStyle.method_3(3);
			paragraphFormat23.Bullet.Type = BulletType.None;
			paragraphFormat23.DefaultPortionFormat.FontHeight = 9f;
			paragraphFormat23.MarginLeft = 108f;
			paragraphFormat23.Indent = 0f;
			IParagraphFormat paragraphFormat24 = textStyle.method_3(4);
			paragraphFormat24.Bullet.Type = BulletType.None;
			paragraphFormat24.DefaultPortionFormat.FontHeight = 9f;
			paragraphFormat24.MarginLeft = 144f;
			paragraphFormat24.Indent = 0f;
			IParagraphFormat paragraphFormat25 = textStyle.method_3(5);
			paragraphFormat25.Bullet.Type = BulletType.None;
			paragraphFormat25.DefaultPortionFormat.FontHeight = 9f;
			paragraphFormat25.MarginLeft = 180f;
			paragraphFormat25.Indent = 0f;
			IParagraphFormat paragraphFormat26 = textStyle.method_3(6);
			paragraphFormat26.Bullet.Type = BulletType.None;
			paragraphFormat26.DefaultPortionFormat.FontHeight = 9f;
			paragraphFormat26.MarginLeft = 216f;
			paragraphFormat26.Indent = 0f;
			IParagraphFormat paragraphFormat27 = textStyle.method_3(7);
			paragraphFormat27.Bullet.Type = BulletType.None;
			paragraphFormat27.DefaultPortionFormat.FontHeight = 9f;
			paragraphFormat27.MarginLeft = 252f;
			paragraphFormat27.Indent = 0f;
			IParagraphFormat paragraphFormat28 = textStyle.method_3(8);
			paragraphFormat28.Bullet.Type = BulletType.None;
			paragraphFormat28.DefaultPortionFormat.FontHeight = 9f;
			paragraphFormat28.MarginLeft = 288f;
			paragraphFormat28.Indent = 0f;
			break;
		}
		case 13:
		{
			IParagraphFormat paragraphFormat19 = textStyle.method_3(0);
			paragraphFormat19.DefaultPortionFormat.FontHeight = 20f;
			paragraphFormat19.DefaultPortionFormat.FontBold = NullableBool.True;
			paragraphFormat19.Alignment = TextAlignment.Left;
			break;
		}
		case 14:
		{
			IParagraphFormat paragraphFormat10 = textStyle.method_3(0);
			paragraphFormat10.Bullet.Type = BulletType.None;
			paragraphFormat10.DefaultPortionFormat.FontHeight = 32f;
			paragraphFormat10.MarginLeft = 0f;
			paragraphFormat10.Indent = 0f;
			IParagraphFormat paragraphFormat11 = textStyle.method_3(1);
			paragraphFormat11.Bullet.Type = BulletType.None;
			paragraphFormat11.DefaultPortionFormat.FontHeight = 28f;
			paragraphFormat11.MarginLeft = 36f;
			paragraphFormat11.Indent = 0f;
			IParagraphFormat paragraphFormat12 = textStyle.method_3(2);
			paragraphFormat12.Bullet.Type = BulletType.None;
			paragraphFormat12.DefaultPortionFormat.FontHeight = 24f;
			paragraphFormat12.MarginLeft = 72f;
			paragraphFormat12.Indent = 0f;
			IParagraphFormat paragraphFormat13 = textStyle.method_3(3);
			paragraphFormat13.Bullet.Type = BulletType.None;
			paragraphFormat13.DefaultPortionFormat.FontHeight = 20f;
			paragraphFormat13.MarginLeft = 108f;
			paragraphFormat13.Indent = 0f;
			IParagraphFormat paragraphFormat14 = textStyle.method_3(4);
			paragraphFormat14.Bullet.Type = BulletType.None;
			paragraphFormat14.DefaultPortionFormat.FontHeight = 20f;
			paragraphFormat14.MarginLeft = 144f;
			paragraphFormat14.Indent = 0f;
			IParagraphFormat paragraphFormat15 = textStyle.method_3(5);
			paragraphFormat15.Bullet.Type = BulletType.None;
			paragraphFormat15.DefaultPortionFormat.FontHeight = 20f;
			paragraphFormat15.MarginLeft = 180f;
			paragraphFormat15.Indent = 0f;
			IParagraphFormat paragraphFormat16 = textStyle.method_3(6);
			paragraphFormat16.Bullet.Type = BulletType.None;
			paragraphFormat16.DefaultPortionFormat.FontHeight = 20f;
			paragraphFormat16.MarginLeft = 216f;
			paragraphFormat16.Indent = 0f;
			IParagraphFormat paragraphFormat17 = textStyle.method_3(7);
			paragraphFormat17.Bullet.Type = BulletType.None;
			paragraphFormat17.DefaultPortionFormat.FontHeight = 20f;
			paragraphFormat17.MarginLeft = 252f;
			paragraphFormat17.Indent = 0f;
			IParagraphFormat paragraphFormat18 = textStyle.method_3(8);
			paragraphFormat18.Bullet.Type = BulletType.None;
			paragraphFormat18.DefaultPortionFormat.FontHeight = 20f;
			paragraphFormat18.MarginLeft = 288f;
			paragraphFormat18.Indent = 0f;
			break;
		}
		case 15:
		{
			IParagraphFormat paragraphFormat = textStyle.method_3(0);
			paragraphFormat.Bullet.Type = BulletType.None;
			paragraphFormat.DefaultPortionFormat.FontHeight = 14f;
			paragraphFormat.MarginLeft = 0f;
			paragraphFormat.Indent = 0f;
			IParagraphFormat paragraphFormat2 = textStyle.method_3(1);
			paragraphFormat2.Bullet.Type = BulletType.None;
			paragraphFormat2.DefaultPortionFormat.FontHeight = 12f;
			paragraphFormat2.MarginLeft = 36f;
			paragraphFormat2.Indent = 0f;
			IParagraphFormat paragraphFormat3 = textStyle.method_3(2);
			paragraphFormat3.Bullet.Type = BulletType.None;
			paragraphFormat3.DefaultPortionFormat.FontHeight = 10f;
			paragraphFormat3.MarginLeft = 72f;
			paragraphFormat3.Indent = 0f;
			IParagraphFormat paragraphFormat4 = textStyle.method_3(3);
			paragraphFormat4.Bullet.Type = BulletType.None;
			paragraphFormat4.DefaultPortionFormat.FontHeight = 9f;
			paragraphFormat4.MarginLeft = 108f;
			paragraphFormat4.Indent = 0f;
			IParagraphFormat paragraphFormat5 = textStyle.method_3(4);
			paragraphFormat5.Bullet.Type = BulletType.None;
			paragraphFormat5.DefaultPortionFormat.FontHeight = 9f;
			paragraphFormat5.MarginLeft = 144f;
			paragraphFormat5.Indent = 0f;
			IParagraphFormat paragraphFormat6 = textStyle.method_3(5);
			paragraphFormat6.Bullet.Type = BulletType.None;
			paragraphFormat6.DefaultPortionFormat.FontHeight = 9f;
			paragraphFormat6.MarginLeft = 180f;
			paragraphFormat6.Indent = 0f;
			IParagraphFormat paragraphFormat7 = textStyle.method_3(6);
			paragraphFormat7.Bullet.Type = BulletType.None;
			paragraphFormat7.DefaultPortionFormat.FontHeight = 9f;
			paragraphFormat7.MarginLeft = 216f;
			paragraphFormat7.Indent = 0f;
			IParagraphFormat paragraphFormat8 = textStyle.method_3(7);
			paragraphFormat8.Bullet.Type = BulletType.None;
			paragraphFormat8.DefaultPortionFormat.FontHeight = 9f;
			paragraphFormat8.MarginLeft = 252f;
			paragraphFormat8.Indent = 0f;
			IParagraphFormat paragraphFormat9 = textStyle.method_3(8);
			paragraphFormat9.Bullet.Type = BulletType.None;
			paragraphFormat9.DefaultPortionFormat.FontHeight = 9f;
			paragraphFormat9.MarginLeft = 288f;
			paragraphFormat9.Indent = 0f;
			break;
		}
		}
		return textStyle;
	}
}
