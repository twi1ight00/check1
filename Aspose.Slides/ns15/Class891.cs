using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;
using ns16;
using ns18;
using ns233;
using ns24;
using ns4;
using ns47;
using ns56;
using ns60;
using ns62;
using ns63;

namespace ns15;

internal class Class891
{
	private readonly Class856 class856_0;

	private bool bool_0;

	public Class891(Presentation domPresentation)
	{
		class856_0 = new Class856(domPresentation, new Class2985());
	}

	public void method_0(Stream stream, ISaveOptions saveOptions)
	{
		bool_0 = true;
		class856_0.SaveOptions = saveOptions;
		method_4();
		class856_0.PptBinaryFile.method_0(stream);
	}

	private void method_1()
	{
		Class60 @class = new Class60(method_2(), method_3());
		IDocumentProperties documentProperties = class856_0.DomPresentation.DocumentProperties;
		@class.Author = documentProperties.Author;
		@class.Category = documentProperties.Category;
		@class.Comments = documentProperties.Comments;
		@class.Company = documentProperties.Company;
		@class.CreatedTime = documentProperties.CreatedTime;
		@class.Keywords = documentProperties.Keywords;
		@class.LastPrinted = documentProperties.LastPrinted;
		@class.LastSavedBy = documentProperties.LastSavedBy;
		@class.LastSavedTime = documentProperties.LastSavedTime;
		@class.Manager = documentProperties.Manager;
		@class.NameOfApplication = documentProperties.NameOfApplication;
		@class.RevisionNumber = documentProperties.RevisionNumber;
		@class.Subject = documentProperties.Subject;
		@class.Template = documentProperties.ApplicationTemplate;
		@class.Title = documentProperties.Title;
		@class.TotalEditingTime = documentProperties.TotalEditingTime;
		for (int i = 0; i < documentProperties.Count; i++)
		{
			string propertyName = documentProperties.GetPropertyName(i);
			@class[propertyName] = documentProperties[propertyName];
		}
		if (@class.Si != null)
		{
			class856_0.PptBinaryFile.SummaryInformationStream = @class.Si.Write();
		}
		if (@class.DSi != null)
		{
			class856_0.PptBinaryFile.DocumentSummaryInformationStream = @class.DSi.Write();
		}
	}

	private Class1146 method_2()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write((ushort)65534);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(131334u);
		binaryWriter.Write(Guid.Empty.ToByteArray());
		binaryWriter.Write(1u);
		binaryWriter.Write(new Guid("{d5cdd502-2e9c-101b-9397-08002b2cf9ae}").ToByteArray());
		binaryWriter.Write((uint)(memoryStream.Position + 4L));
		Class1145 @class = new Class1145();
		@class.Properties.Remove(0u);
		@class.Properties.Remove(2u);
		@class.Properties[1u] = new Class1147((short)1251);
		@class.Properties[3u] = new Class1147("Экран", unicode: false);
		@class.Properties[4u] = new Class1147(class856_0.PptBinaryFile.PowerPointDocumentStream.vmethod_2());
		@class.Properties[6u] = new Class1147(0);
		@class.Properties[7u] = new Class1147(1);
		@class.Properties[8u] = new Class1147(0);
		@class.Properties[9u] = new Class1147(0);
		@class.Properties[10u] = new Class1147(0);
		@class.Properties[11u] = new Class1147(b: false);
		@class.Properties[15u] = new Class1147("Aspose", unicode: false);
		@class.Properties[16u] = new Class1147(b: false);
		@class.Properties[19u] = new Class1147(b: false);
		@class.Properties[22u] = new Class1147(b: false);
		@class.Properties[23u] = new Class1147(727464);
		byte[] buffer = @class.Write();
		binaryWriter.Write(buffer);
		memoryStream.Position = 0L;
		Class1146 result = new Class1146(memoryStream);
		binaryWriter.Close();
		return result;
	}

	private Class1146 method_3()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write((ushort)65534);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(131334u);
		binaryWriter.Write(Guid.Empty.ToByteArray());
		binaryWriter.Write(1u);
		binaryWriter.Write(new Guid("{f29f85e0-4ff9-1068-ab91-08002b27b3d9}").ToByteArray());
		binaryWriter.Write((uint)(memoryStream.Position + 4L));
		Class1145 @class = new Class1145();
		@class.Properties.Remove(0u);
		@class.Properties[1u] = new Class1147((short)1251);
		@class.Properties[2u] = new Class1147("Slide 1", unicode: false);
		@class.Properties[4u] = new Class1147("Aspose.Slides", unicode: false);
		@class.Properties[8u] = new Class1147("Aspose.Slides", unicode: false);
		@class.Properties[9u] = new Class1147("1", unicode: false);
		@class.Properties[10u] = new Class1147(DateTime.Now);
		@class.Properties[12u] = new Class1147(DateTime.Now);
		@class.Properties[13u] = new Class1147(DateTime.Now);
		@class.Properties[15u] = new Class1147(0);
		@class.Properties[18u] = new Class1147("Aspose.Slides Library", unicode: false);
		byte[] buffer = @class.Write();
		binaryWriter.Write(buffer);
		memoryStream.Position = 0L;
		Class1146 result = new Class1146(memoryStream);
		binaryWriter.Close();
		return result;
	}

	private void method_4()
	{
		method_9();
		method_20();
		method_16();
		method_31();
		method_32();
		method_11();
		method_33();
		method_22();
		method_7();
		method_1();
		method_12();
		method_5();
	}

	private void method_5()
	{
		method_6();
	}

	private void method_6()
	{
		List<Class2718> mainMasterContainerList = class856_0.PptBinaryFile.PowerPointDocumentStream.MainMasterContainerList;
		foreach (Class2718 item in mainMasterContainerList)
		{
			Class2894[] rgTextMasterStyle = item.RgTextMasterStyle;
			foreach (Class2894 textMasterStyleAtom in rgTextMasterStyle)
			{
				Class862.smethod_8(textMasterStyleAtom);
			}
		}
	}

	private void method_7()
	{
		Class2706 fontCollection = class856_0.PptBinaryFile.PowerPointDocumentStream.DocumentContainer.DocumentTextInfo.FontCollection;
		if (fontCollection == null || fontCollection.Records.Count < 1)
		{
			Class53.smethod_1(class856_0).Add(Enum2.const_0, new FontData("Arial"));
		}
		Class2887 item = new Class2887();
		class856_0.PptBinaryFile.PowerPointDocumentStream.Records.Add(item);
		Class2895 @class = new Class2895();
		class856_0.PptBinaryFile.PowerPointDocumentStream.Records.Add(@class);
		@class.DocPersistIdRef = 1u;
		@class.EncryptSessionPersistIdRef = 0u;
		@class.LastView = Class232.smethod_30(class856_0.DomPresentation.ViewProperties.LastView);
		@class.LastSlideIdRef = 0u;
		if (class856_0.DomPresentation.Slides.Count > 0)
		{
			Class2731 slideList = class856_0.PptBinaryFile.PowerPointDocumentStream.DocumentContainer.SlideList;
			List<Class2855> list = slideList.ContentRecords.method_10();
			if (list != null)
			{
				@class.LastSlideIdRef = list[0].SlideId;
			}
		}
		class856_0.PptBinaryFile.PowerPointDocumentStream.method_8();
		Class2895 userEditAtom = class856_0.PptBinaryFile.PowerPointDocumentStream.UserEditAtom;
		userEditAtom.OffsetLastEdit = 0u;
		Class2844 class2 = new Class2844();
		class2.AnsiUserName = "Aspose.Slides";
		class856_0.PptBinaryFile.CurrentUserStream.method_5(class2);
	}

	private void method_8(IBaseSlide domSlide, Class2643 odrawDgContainer)
	{
		if (domSlide.Background != null && domSlide.Background.Type != BackgroundType.NotDefined)
		{
			Background background = (Background)domSlide.Background;
			Class201 @class = new Class201(class856_0);
			Class2670 class2 = @class.method_0(odrawDgContainer, addToContainer: true);
			Class2835 class3 = new Class2835();
			class3.Header.Instance = 1;
			class2.Records.Add(class3);
			class3.Spid = class856_0.method_8(incFdgCsp: false);
			class3.FGroup = false;
			class3.FChild = false;
			class3.FPatriarch = false;
			class3.FDeleted = false;
			class3.FOleShape = false;
			class3.FHaveMaster = false;
			class3.FFlipH = false;
			class3.FFlipV = false;
			class3.FConnector = false;
			class3.FHaveAnchor = false;
			class3.FBackground = true;
			class3.FHaveSpt = true;
			Class2834 class4 = new Class2834();
			class2.Records.Add(class4);
			FillFormat fillFormat = background.method_0((BaseSlide)domSlide);
			if (fillFormat.FillType == FillType.Solid)
			{
				fillFormat = (FillFormat)background.FillFormat;
			}
			Class1052.smethod_1(fillFormat, class4, null, background: true, class856_0);
			Class2923 class5 = new Class2923();
			class4.Properties.Add(class5);
			class5.Folded_fLine = false;
			Class2925 class6 = new Class2925();
			class4.Properties.Add(class6);
			class6.LfUsefBackground = true;
			class6.XfBackground = true;
			Class2911 property = new Class2911(Enum426.const_2, isBid: false, 9u);
			class4.Properties.Add(property);
		}
		else
		{
			class856_0.method_8(incFdgCsp: false);
		}
	}

	private void method_9()
	{
		Presentation domPresentation = class856_0.DomPresentation;
		Class2688 documentContainer = class856_0.PptBinaryFile.PowerPointDocumentStream.DocumentContainer;
		method_10(documentContainer.DocumentAtom, domPresentation);
		Class2689 documentTextInfo = documentContainer.DocumentTextInfo;
		Class2909 @class = new Class2909();
		documentTextInfo.Records.Add(@class);
		Class862.smethod_3(domPresentation.DefaultTextStyle.DefaultParagraphFormat.DefaultPortionFormat, @class.CharFormat, class856_0);
		@class.CharFormat.Kumi = NullableBool.False;
		@class.CharFormat.Position = null;
		Class2908 class2 = new Class2908();
		documentTextInfo.Records.Add(class2);
		class2.method_1();
		Class2907 class3 = new Class2907();
		documentTextInfo.Records.Add(class3);
		method_41(domPresentation.DefaultTextStyle.DefaultParagraphFormat, class3.SpecialInfo);
		Class2894[] array = new Class2894[9];
		class856_0.PptDefaultTextMasterStyleList = array;
		for (int i = 0; i < 9; i++)
		{
			if (i != 3)
			{
				array[i] = new Class2894();
				array[i].method_1((Enum449)i, defaultStyle: true);
			}
		}
		Class2894 class4 = Class862.smethod_7(domPresentation.DefaultTextStyle, class856_0);
		if (class4 == null)
		{
			class4 = array[4];
		}
		else
		{
			array[4] = class4;
		}
		documentTextInfo.Records.Add(class4);
		class4.Header.Instance = 4;
		smethod_1(class4, class856_0.DomPresentation.MasterTheme, class856_0);
		Class2644 officeArtDgg = documentContainer.DrawingGroup.OfficeArtDgg;
		Class2834 class5 = new Class2834();
		class5.method_1(Enum452.const_0, 0);
		officeArtDgg.Records.Add(class5);
		Class2900 class6 = new Class2900(134217732u, 134217729u, 134217730u, 268435703u);
		class6.Header.Instance = 4;
		officeArtDgg.Records.Add(class6);
		Class2716 class7 = new Class2716();
		class7.method_5();
		class7.Header.Version = 15;
		class7.Header.Instance = 0;
		documentContainer.method_2(class7);
	}

	private void method_10(Class2864 documentAtom, Presentation domPresentation)
	{
		Class232.smethod_10((SlideSize)domPresentation.SlideSize, documentAtom);
	}

	private void method_11()
	{
		Class2688 documentContainer = class856_0.PptBinaryFile.PowerPointDocumentStream.DocumentContainer;
		Class2709 slideHF = documentContainer.SlideHF;
		slideHF.HfAtom.FHasDate = class856_0.DomPresentation.HeaderFooterManager.IsDateTimeVisible;
		slideHF.HfAtom.FHasFooter = class856_0.DomPresentation.HeaderFooterManager.IsFooterVisible;
		slideHF.HfAtom.FHasSlideNumber = class856_0.DomPresentation.HeaderFooterManager.IsSlideNumberVisible;
		foreach (Class2719 slideContainer in class856_0.PptBinaryFile.PowerPointDocumentStream.SlideContainerList)
		{
			if (slideContainer.SlideAtom.Geom == Enum451.const_2)
			{
				continue;
			}
			Class2709 perSlideHeadersFootersContainer = slideContainer.PerSlideHeadersFootersContainer;
			if (perSlideHeadersFootersContainer.HfAtom.FHasDate == slideHF.HfAtom.FHasDate && perSlideHeadersFootersContainer.HfAtom.FHasFooter == slideHF.HfAtom.FHasFooter && perSlideHeadersFootersContainer.HfAtom.FHasSlideNumber == slideHF.HfAtom.FHasSlideNumber)
			{
				slideHF.FooterText = perSlideHeadersFootersContainer.FooterText;
				slideHF.HfAtom.IsDateTimeFixed = perSlideHeadersFootersContainer.HfAtom.IsDateTimeFixed;
				if (perSlideHeadersFootersContainer.HfAtom.IsDateTimeFixed)
				{
					slideHF.UserDate = perSlideHeadersFootersContainer.UserDate;
				}
				break;
			}
		}
		foreach (Class2719 slideContainer2 in class856_0.PptBinaryFile.PowerPointDocumentStream.SlideContainerList)
		{
			if (slideContainer2.SlideAtom.Geom != Enum451.const_2)
			{
				Class2709 perSlideHeadersFootersContainer2 = slideContainer2.PerSlideHeadersFootersContainer;
				if (perSlideHeadersFootersContainer2.Equals(slideHF))
				{
					slideContainer2.Records.Remove(perSlideHeadersFootersContainer2);
				}
			}
		}
	}

	internal void method_12()
	{
		Class2706 @class = new Class2706();
		class856_0.PptBinaryFile.PowerPointDocumentStream.DocumentContainer.DocumentTextInfo.method_2(@class);
		Class48 class2 = Class53.smethod_1(class856_0);
		for (int i = 0; i < class2.Count; i++)
		{
			IFontData fontData = class2.method_5(i).FontData;
			Class2879 class3 = new Class2879();
			class3.Header.Instance = (short)(@class.method_7() + 1);
			@class.Records.Add(class3);
			class3.LfFaceName = fontData.FontName;
			class3.LfCharSet = 0;
			class3.FEmbedSubsetted = 0;
			class3.Quality = 4;
			class3.LfPitchAndFamily = 0;
		}
	}

	private void method_13(IBaseSlide domSlide, Class2671 odrawSpgrContainer, Class2888 pptSlideAtom, int pptPlaceholderPosition, bool patriarch)
	{
		SizeF size = class856_0.DomPresentation.SlideSize.Size;
		float num = 0f;
		float num2 = 0f;
		float num3 = size.Width / 4f;
		float num4 = size.Height / 2f;
		for (int i = 0; i < 9; i++)
		{
			if (i != 3)
			{
				Enum449 @enum = (Enum449)i;
				AutoShape autoShape = new AutoShape(domSlide);
				autoShape.shapeCollection_0 = (ShapeCollection)domSlide.Shapes;
				TextFrame textFrame = new TextFrame(autoShape);
				autoShape.Frame = new ShapeFrame(num, num2, num3, num4, NullableBool.False, NullableBool.False, 0f);
				num += num3;
				if (i > 3 && num2 < 10f)
				{
					num = 0f;
					num2 += num4;
				}
				autoShape.TextFrameInternal = textFrame;
				Paragraph paragraph = new Paragraph();
				textFrame.Paragraphs.Add(paragraph);
				paragraph.ParagraphFormat.Depth = 0;
				paragraph.Portions.Add(new Portion("TextType: " + @enum));
				for (int j = 0; j < 5; j++)
				{
					paragraph = new Paragraph();
					textFrame.Paragraphs.Add(paragraph);
					paragraph.ParagraphFormat.Depth = (short)j;
					paragraph.Portions.Add(new Portion("Level " + j));
				}
				Class2670 @class = method_26(autoShape, odrawSpgrContainer, pptSlideAtom, pptPlaceholderPosition, !patriarch);
				Class2642 clientTextBox = @class.ClientTextBox;
				clientTextBox.ContentRecords.TextHeader.TextType = @enum;
				Class2885 class2 = new Class2885();
				class2.Position = 0;
				class2.PlacementId = method_14(@enum);
				class2.Size = Enum385.const_0;
				@class.ClientData.method_2(class2);
			}
		}
	}

	private Enum384 method_14(Enum449 textType)
	{
		return textType switch
		{
			Enum449.const_0 => Enum384.const_13, 
			Enum449.const_1 => Enum384.const_14, 
			Enum449.const_2 => Enum384.const_12, 
			Enum449.const_3 => Enum384.const_14, 
			Enum449.const_4 => Enum384.const_16, 
			Enum449.const_5 => Enum384.const_15, 
			Enum449.const_6 => Enum384.const_14, 
			Enum449.const_7 => Enum384.const_14, 
			_ => Enum384.const_14, 
		};
	}

	private void method_15(IBaseSlide domSlide, Class2671 odrawSpgrContainer, Class2888 pptSlideAtom, int pptPlaceholderPosition, bool patriarch)
	{
		AutoShape autoShape = new AutoShape(domSlide);
		autoShape.shapeCollection_0 = (ShapeCollection)domSlide.Shapes;
		TextFrame textFrame = new TextFrame(autoShape);
		SizeF size = class856_0.DomPresentation.SlideSize.Size;
		autoShape.Frame = new ShapeFrame(0f, 0f, size.Width, size.Height, NullableBool.False, NullableBool.False, 0f);
		autoShape.TextFrameInternal = textFrame;
		textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
		string textInternal = "Evaluation only." + '\r' + "Created with Aspose.Slides for .NET 4.0 15.1.0.0" + '\r' + "Copyright 2004-" + "2015.01.30".Substring(0, 4) + " Aspose Pty Ltd.";
		textFrame.TextInternal = textInternal;
		textFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
		autoShape.LineFormat.FillFormat.FillType = FillType.NoFill;
		foreach (Paragraph paragraph in textFrame.Paragraphs)
		{
			paragraph.ParagraphFormat.Alignment = TextAlignment.Center;
			paragraph.ParagraphFormat.SpaceWithin = 150f;
			PortionFormat portionFormat = (PortionFormat)paragraph.Portions[0].PortionFormat;
			portionFormat.FontHeight = 32f;
			((FillFormat)portionFormat.FillFormat).FillType = FillType.Solid;
			((FillFormat)portionFormat.FillFormat).colorFormat_0 = new ColorFormat(null, Color.FromArgb(255, 255, 216, 207));
			((EffectFormat)portionFormat.EffectFormat).EnablePresetShadowEffect();
		}
		textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
		Class2670 @class = method_26(autoShape, odrawSpgrContainer, pptSlideAtom, pptPlaceholderPosition, !patriarch);
		Class2834 shapePrimaryOptions = @class.ShapePrimaryOptions;
		shapePrimaryOptions.Properties.method_0(new Class2911(Enum426.const_404, 14680288u));
	}

	private void method_16()
	{
		for (int i = 0; i < class856_0.DomPresentation.Masters.Count; i++)
		{
			method_17((MasterSlide)class856_0.DomPresentation.Masters[i]);
		}
	}

	private void method_17(MasterSlide domMasterSlide)
	{
		Class2718 @class = new Class2718();
		class856_0.PptBinaryFile.PowerPointDocumentStream.method_12(@class, domMasterSlide.PPTUnsupportedProps.SlideId);
		class856_0.PptCurrentMasterOrSlideContainer = @class;
		class856_0.MasterSlideToMainMasterContainer.Add(domMasterSlide, @class);
		Class2888 slideAtom = @class.SlideAtom;
		IMasterTheme overrideTheme = domMasterSlide.ThemeManager.OverrideTheme;
		for (int i = 0; i < overrideTheme.ExtraColorSchemes.Count; i++)
		{
			Class1050.smethod_1(overrideTheme.ExtraColorSchemes[i].ColorScheme, @class, list: true);
		}
		method_18(domMasterSlide, overrideTheme, @class);
		method_34(domMasterSlide);
		method_24(domMasterSlide, @class);
		Class1050.smethod_1(overrideTheme.ColorScheme, @class, list: false);
		method_36(domMasterSlide, @class);
		Class2843 class2 = new Class2843("Оформление по умолчанию", 2);
		class2.Header.Version = 0;
		@class.Records.Add(class2);
		method_42(slideAtom, domMasterSlide);
		class856_0.PptCurrentMasterOrSlideContainer = null;
		for (int j = 0; j < domMasterSlide.LayoutSlides.Count; j++)
		{
			LayoutSlide layoutSlide = (LayoutSlide)domMasterSlide.LayoutSlides[j];
			if (layoutSlide.PPTUnsupportedProps.IsLayoutLoadedAsTitleMasterSlide)
			{
				method_19(layoutSlide);
			}
		}
		IMasterThemeManager themeManager = domMasterSlide.ThemeManager;
		@class.TemplateName = themeManager.OverrideTheme.Name;
		Class231.smethod_1(domMasterSlide, @class, class856_0);
	}

	private void method_18(MasterSlide domMasterSlide, IMasterTheme domMasterTheme, Class2718 masterContainer)
	{
		Class2894[] array = new Class2894[9];
		class856_0.DelayedMasterStyles.Add(domMasterSlide, array);
		for (int i = 0; i < 9; i++)
		{
			if (i != 3)
			{
				array[i] = new Class2894();
				array[i].method_1((Enum449)i, defaultStyle: false);
				masterContainer.Records.Add(array[i]);
				if (array[i].Levels.Count > 0)
				{
					array[i].Levels[0].CharFormat.PP9RT = 0;
				}
			}
		}
		Class2894 destTextMasterStyleAtom = array[0];
		Class862.smethod_9(destTextMasterStyleAtom, domMasterSlide.TitleStyle, class856_0);
		Class2894 destTextMasterStyleAtom2 = array[1];
		Class862.smethod_9(destTextMasterStyleAtom2, domMasterSlide.BodyStyle, class856_0);
	}

	private void method_19(LayoutSlide titleLayout)
	{
		Class2719 @class = new Class2719();
		Class2855 class2 = class856_0.PptBinaryFile.PowerPointDocumentStream.method_13(@class, titleLayout.PPTUnsupportedProps.SlideId);
		class856_0.TitleLayoutMasterSlideToSlideId.Add(titleLayout, class2.SlideId);
		class856_0.PptCurrentMasterOrSlideContainer = @class;
		class2.FShouldCollapse = titleLayout.BaseSlidePPTUnsupportedProps.SlidePersistAtom_FShouldCollapse;
		Class2888 slideAtom = @class.SlideAtom;
		slideAtom.Geom = Enum451.const_2;
		slideAtom.MasterIdRef = ((MasterSlide)titleLayout.MasterSlide).PPTUnsupportedProps.SlideId;
		slideAtom.NotesIdRef = 0u;
		slideAtom.FMasterBackground = titleLayout.Background.Type == BackgroundType.NotDefined;
		slideAtom.FMasterObjects = titleLayout.PPTXUnsupportedProps.ShowMasterShapes;
		slideAtom.FMasterScheme = !titleLayout.ThemeManager.IsOverrideThemeEnabled;
		method_24(titleLayout, @class);
		Class1050.smethod_1(((ThemeEffectiveData)titleLayout.ThemeManager.CreateThemeEffective()).ColorSchemeInternal, @class, list: false);
		method_36(titleLayout, @class);
		class856_0.PptCurrentMasterOrSlideContainer = null;
	}

	private void method_20()
	{
		bool flag = false;
		foreach (Slide slide in class856_0.DomPresentation.Slides)
		{
			if (slide.NotesSlide != null)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			Class2720 @class = new Class2720();
			class856_0.PptCurrentNotesContainer = @class;
			class856_0.PptBinaryFile.PowerPointDocumentStream.DocumentContainer.DocumentAtom.NotesMasterPersistIdRef = class856_0.PptBinaryFile.PowerPointDocumentStream.method_11(@class);
			Class2884 class2 = new Class2884();
			@class.Records.Add(class2);
			class2.SlideIdRef = 0u;
			class2.FMasterBackground = false;
			class2.FMasterObjects = false;
			class2.FMasterScheme = false;
			Class2714 class3 = new Class2714();
			@class.Records.Add(class3);
			Class2643 class4 = new Class2643();
			class3.Records.Add(class4);
			Class2743 class5 = new Class2743();
			class4.Records.Add(class5);
			class856_0.PptCurrentOfficeArtFdg = class5;
			class5.DrawingId = (ushort)class856_0.method_9();
			Class2671 class6 = new Class2671();
			class4.Records.Add(class6);
			Class2670 class7 = new Class2670();
			class6.Records.Add(class7);
			class7.Records.Add(new Class2836());
			Class2835 class8 = new Class2835();
			class7.Records.Add(class8);
			class8.Spid = class856_0.method_8(incFdgCsp: true);
			class8.FPatriarch = true;
			class8.FGroup = true;
			class8.ShapeType = Enum425.const_0;
			Class2670 class9 = new Class2670();
			class4.Records.Add(class9);
			Class2835 class10 = new Class2835();
			class9.Records.Add(class10);
			class10.Spid = class856_0.method_8(incFdgCsp: false);
			class10.FBackground = true;
			class10.FHaveSpt = true;
			class10.ShapeType = Enum425.const_1;
			Class2834 class11 = new Class2834();
			class9.Records.Add(class11);
			class11.Properties.Add(new Class2911(Enum426.const_82, 134217728u));
			class11.Properties.Add(new Class2911(Enum426.const_84, 134217733u));
			class11.Properties.Add(new Class2911(Enum426.const_100, 6864350u));
			class11.Properties.Add(new Class2911(Enum426.const_101, 9150350u));
			class11.Properties.Add(new Class2911(Enum426.const_119, 1179666u));
			class11.Properties.Add(new Class2911(Enum426.const_154, 524288u));
			class11.Properties.Add(new Class2911(Enum426.const_2, 9u));
			class11.Properties.Add(new Class2911(Enum426.const_10, 65537u));
			Class2670 class12 = new Class2670();
			class6.Records.Add(class12);
			Class2835 class13 = new Class2835();
			class12.Records.Add(class13);
			class13.Spid = class856_0.method_8(incFdgCsp: true);
			class13.FHaveAnchor = true;
			class13.FHaveSpt = true;
			class13.ShapeType = Enum425.const_1;
			Class2834 class14 = new Class2834();
			class12.Records.Add(class14);
			class14.Properties.Add(new Class2911(Enum426.const_404, 327681u));
			class14.Properties.Add(new Class2911(Enum426.const_405, class856_0.method_10()));
			class14.Properties.Add(new Class2911(Enum426.const_82, 134217732u));
			class14.Properties.Add(new Class2911(Enum426.const_84, 134217728u));
			class14.Properties.Add(new Class2911(Enum426.const_119, 1114113u));
			class14.Properties.Add(new Class2911(Enum426.const_120, 134217729u));
			class14.Properties.Add(new Class2911(Enum426.const_154, 589825u));
			class14.Properties.Add(new Class2911(Enum426.const_296, 134217730u));
			Class2742 class15 = new Class2742();
			class12.Records.Add(class15);
			class15.X = 0;
			class15.Y = 0;
			class15.Width = 1872;
			class15.Height = 288;
			Class2641 class16 = new Class2641();
			class12.Records.Add(class16);
			Class2885 class17 = new Class2885();
			class16.Records.Add(class17);
			class17.Position = 0;
			class17.PlacementId = Enum384.const_10;
			class17.Size = Enum385.const_2;
			Class2642 class18 = new Class2642();
			class12.Records.Add(class18);
			Class2951 contentRecords = class18.ContentRecords;
			Class2859 class19 = new Class2859(contentRecords);
			contentRecords.Add(class19);
			class19.TextType = Enum449.const_3;
			Class2858 class20 = new Class2858(contentRecords);
			contentRecords.Add(class20);
			class20.Text = "*";
			Class2850 class21 = new Class2850(contentRecords);
			contentRecords.Add(class21);
			class21.Position = 0;
			Class2670 class22 = new Class2670();
			class6.Records.Add(class22);
			Class2835 class23 = new Class2835();
			class22.Records.Add(class23);
			class23.Spid = class856_0.method_8(incFdgCsp: true);
			class23.FHaveAnchor = true;
			class23.FHaveSpt = true;
			class23.ShapeType = Enum425.const_1;
			Class2834 class24 = new Class2834();
			class22.Records.Add(class24);
			class24.Properties.Add(new Class2911(Enum426.const_404, 327681u));
			class24.Properties.Add(new Class2911(Enum426.const_405, class856_0.method_10()));
			class24.Properties.Add(new Class2911(Enum426.const_82, 134217732u));
			class24.Properties.Add(new Class2911(Enum426.const_84, 134217728u));
			class24.Properties.Add(new Class2911(Enum426.const_119, 1114113u));
			class24.Properties.Add(new Class2911(Enum426.const_120, 134217729u));
			class24.Properties.Add(new Class2911(Enum426.const_154, 589825u));
			class24.Properties.Add(new Class2911(Enum426.const_296, 134217730u));
			Class2742 class25 = new Class2742();
			class22.Records.Add(class25);
			class25.X = 2447;
			class25.Y = 0;
			class25.Width = 1872;
			class25.Height = 288;
			Class2641 class26 = new Class2641();
			class22.Records.Add(class26);
			Class2885 class27 = new Class2885();
			class26.Records.Add(class27);
			class27.Position = 1;
			class27.PlacementId = Enum384.const_7;
			class27.Size = Enum385.const_0;
			Class2642 class28 = new Class2642();
			class22.Records.Add(class28);
			Class2951 contentRecords2 = class28.ContentRecords;
			Class2859 class29 = new Class2859(contentRecords2);
			contentRecords2.Add(class29);
			class29.TextType = Enum449.const_3;
			Class2858 class30 = new Class2858(contentRecords2);
			contentRecords2.Add(class30);
			class30.Text = "*";
			Class2849 class31 = new Class2849(contentRecords2);
			contentRecords2.Add(class31);
			class31.Position = 0;
			Class2670 class32 = new Class2670();
			class6.Records.Add(class32);
			Class2835 class33 = new Class2835();
			class32.Records.Add(class33);
			class33.Spid = class856_0.method_8(incFdgCsp: true);
			class33.FHaveAnchor = true;
			class33.FHaveSpt = true;
			class33.ShapeType = Enum425.const_1;
			Class2834 class34 = new Class2834();
			class32.Records.Add(class34);
			class34.Properties.Add(new Class2911(Enum426.const_404, 17039620u));
			class34.Properties.Add(new Class2911(Enum426.const_412, 1u));
			class34.Properties.Add(new Class2911(Enum426.const_80, 65536u));
			class34.Properties.Add(new Class2911(Enum426.const_119, 1114129u));
			class34.Properties.Add(new Class2911(Enum426.const_154, 589832u));
			class34.Properties.Add(new Class2911(Enum426.const_324, 65537u));
			Class2742 class35 = new Class2742();
			class32.Records.Add(class35);
			class35.X = 720;
			class35.Y = 432;
			class35.Width = 2880;
			class35.Height = 2160;
			Class2641 class36 = new Class2641();
			class32.Records.Add(class36);
			Class2885 class37 = new Class2885();
			class36.Records.Add(class37);
			class37.Position = 2;
			class37.PlacementId = Enum384.const_5;
			class37.Size = Enum385.const_0;
			Class2670 class38 = new Class2670();
			class6.Records.Add(class38);
			Class2835 class39 = new Class2835();
			class38.Records.Add(class39);
			class39.Spid = class856_0.method_8(incFdgCsp: true);
			class39.FHaveAnchor = true;
			class39.FHaveSpt = true;
			class39.ShapeType = Enum425.const_1;
			Class2834 class40 = new Class2834();
			class38.Records.Add(class40);
			class40.Properties.Add(new Class2911(Enum426.const_404, 327681u));
			class40.Properties.Add(new Class2911(Enum426.const_405, class856_0.method_10()));
			class40.Properties.Add(new Class2911(Enum426.const_82, 134217732u));
			class40.Properties.Add(new Class2911(Enum426.const_84, 134217728u));
			class40.Properties.Add(new Class2911(Enum426.const_119, 1114113u));
			class40.Properties.Add(new Class2911(Enum426.const_120, 134217729u));
			class40.Properties.Add(new Class2911(Enum426.const_154, 589825u));
			class40.Properties.Add(new Class2911(Enum426.const_296, 134217730u));
			Class2742 class41 = new Class2742();
			class38.Records.Add(class41);
			class41.X = 432;
			class41.Y = 2736;
			class41.Width = 3456;
			class41.Height = 2592;
			Class2641 class42 = new Class2641();
			class38.Records.Add(class42);
			Class2885 class43 = new Class2885();
			class42.Records.Add(class43);
			class43.Position = 3;
			class43.PlacementId = Enum384.const_6;
			class43.Size = Enum385.const_2;
			Class2642 class44 = new Class2642();
			class38.Records.Add(class44);
			Class2951 contentRecords3 = class44.ContentRecords;
			Class2859 class45 = new Class2859(contentRecords3);
			contentRecords3.Add(class45);
			class45.TextType = Enum449.const_2;
			Class2857 class46 = new Class2858(contentRecords3);
			contentRecords3.Add(class46);
			class46.Text = "Click to edit Master text styles\rSecond level\rThird level\rFourth level\rFifth level";
			Class2853 class47 = new Class2853(contentRecords3);
			contentRecords3.Add(class47);
			class47.RgMasterTextPropRun.Add(new Class2961(33u, 0));
			class47.RgMasterTextPropRun.Add(new Class2961(13u, 1));
			class47.RgMasterTextPropRun.Add(new Class2961(12u, 2));
			class47.RgMasterTextPropRun.Add(new Class2961(13u, 3));
			class47.RgMasterTextPropRun.Add(new Class2961(12u, 4));
			Class2670 class48 = new Class2670();
			class6.Records.Add(class48);
			Class2835 class49 = new Class2835();
			class48.Records.Add(class49);
			class49.Spid = class856_0.method_8(incFdgCsp: true);
			class49.FHaveAnchor = true;
			class49.FHaveSpt = true;
			class49.ShapeType = Enum425.const_1;
			Class2834 class50 = new Class2834();
			class48.Records.Add(class50);
			class50.Properties.Add(new Class2911(Enum426.const_404, 327681u));
			class50.Properties.Add(new Class2911(Enum426.const_405, class856_0.method_10()));
			class50.Properties.Add(new Class2911(Enum426.const_412, 2u));
			class50.Properties.Add(new Class2911(Enum426.const_82, 134217732u));
			class50.Properties.Add(new Class2911(Enum426.const_84, 134217728u));
			class50.Properties.Add(new Class2911(Enum426.const_119, 1114113u));
			class50.Properties.Add(new Class2911(Enum426.const_120, 134217729u));
			class50.Properties.Add(new Class2911(Enum426.const_154, 589825u));
			class50.Properties.Add(new Class2911(Enum426.const_296, 134217730u));
			Class2742 class51 = new Class2742();
			class48.Records.Add(class51);
			class51.X = 0;
			class51.Y = 5471;
			class51.Width = 1872;
			class51.Height = 288;
			Class2641 class52 = new Class2641();
			class48.Records.Add(class52);
			Class2885 class53 = new Class2885();
			class52.Records.Add(class53);
			class53.Position = 4;
			class53.PlacementId = Enum384.const_9;
			class53.Size = Enum385.const_2;
			Class2642 class54 = new Class2642();
			class48.Records.Add(class54);
			Class2951 contentRecords4 = class54.ContentRecords;
			Class2859 class55 = new Class2859(contentRecords4);
			contentRecords4.Add(class55);
			class55.TextType = Enum449.const_3;
			Class2858 class56 = new Class2858(contentRecords4);
			contentRecords4.Add(class56);
			class56.Text = "*";
			Class2848 class57 = new Class2848(contentRecords4);
			contentRecords4.Add(class57);
			class57.Position = 0;
			Class2670 class58 = new Class2670();
			class6.Records.Add(class58);
			Class2835 class59 = new Class2835();
			class58.Records.Add(class59);
			class59.Spid = class856_0.method_8(incFdgCsp: true);
			class59.FHaveAnchor = true;
			class59.FHaveSpt = true;
			class59.ShapeType = Enum425.const_1;
			Class2834 class60 = new Class2834();
			class58.Records.Add(class60);
			class60.Properties.Add(new Class2911(Enum426.const_404, 327681u));
			class60.Properties.Add(new Class2911(Enum426.const_405, class856_0.method_10()));
			class60.Properties.Add(new Class2911(Enum426.const_412, 2u));
			class60.Properties.Add(new Class2911(Enum426.const_82, 134217732u));
			class60.Properties.Add(new Class2911(Enum426.const_84, 134217728u));
			class60.Properties.Add(new Class2911(Enum426.const_119, 1114113u));
			class60.Properties.Add(new Class2911(Enum426.const_120, 134217729u));
			class60.Properties.Add(new Class2911(Enum426.const_154, 589825u));
			class60.Properties.Add(new Class2911(Enum426.const_296, 134217730u));
			Class2742 class61 = new Class2742();
			class58.Records.Add(class61);
			class61.X = 2447;
			class61.Y = 5471;
			class61.Width = 1872;
			class61.Height = 288;
			Class2641 class62 = new Class2641();
			class58.Records.Add(class62);
			Class2885 class63 = new Class2885();
			class62.Records.Add(class63);
			class63.Position = 5;
			class63.PlacementId = Enum384.const_8;
			class63.Size = Enum385.const_2;
			Class2642 class64 = new Class2642();
			class58.Records.Add(class64);
			Class2951 contentRecords5 = class64.ContentRecords;
			Class2859 class65 = new Class2859(contentRecords5);
			contentRecords5.Add(class65);
			class65.TextType = Enum449.const_3;
			Class2858 class66 = new Class2858(contentRecords5);
			contentRecords5.Add(class66);
			class66.Text = "*";
			Class2852 class67 = new Class2852(contentRecords5);
			contentRecords5.Add(class67);
			class67.Position = 0;
			Class2840 class68 = new Class2840();
			@class.Records.Add(class68);
			class68.method_3(0, 16777215);
			class68.method_3(1, 0);
			class68.method_3(2, 8421504);
			class68.method_3(3, 0);
			class68.method_3(4, 14934203);
			class68.method_3(5, 10040115);
			class68.method_3(6, 10066176);
			class68.method_3(7, 52377);
			class856_0.PptCurrentNotesContainer = null;
		}
	}

	private void method_21(BaseSlide domNotesSlide, IOverrideThemeManager domThemeManager)
	{
		Class2720 @class = new Class2720();
		class856_0.PptCurrentNotesContainer = @class;
		Class2855 class2 = class856_0.PptBinaryFile.PowerPointDocumentStream.method_15(@class);
		Class2719 class3 = class856_0.PptCurrentMasterOrSlideContainer as Class2719;
		if (class3 != null)
		{
			class3.SlideAtom.NotesIdRef = class2.SlideId;
		}
		Class2884 class4 = new Class2884();
		@class.Records.Add(class4);
		if (class3 != null)
		{
			class4.SlideIdRef = class856_0.method_12(class3.PersistId).SlideId;
			class4.FMasterBackground = domNotesSlide.Background.Type == BackgroundType.NotDefined;
			class4.FMasterObjects = true;
			class4.FMasterScheme = !domThemeManager.IsOverrideThemeEnabled;
		}
		else
		{
			class4.SlideIdRef = 0u;
			class4.FMasterBackground = false;
			class4.FMasterObjects = false;
			class4.FMasterScheme = false;
		}
		method_24(domNotesSlide, @class);
		foreach (Class2670 record in @class.Drawing.OfficeArtDg.GroupShape.Records)
		{
			record.AutoInit = false;
			if (record.ClientTextBox != null)
			{
				Class2642 clientTextBox = record.ClientTextBox;
				if (clientTextBox.ContentRecords.HaveTextHeader && clientTextBox.ContentRecords.TextHeader.TextType == Enum449.const_2)
				{
					record.AutoInit = true;
					Class2885 class6 = new Class2885();
					class6.PlacementId = Enum384.const_12;
					class6.Position = 0;
					class6.Size = Enum385.const_0;
					record.ClientData.method_2(class6);
					break;
				}
			}
			record.AutoInit = true;
		}
		Class1050.smethod_1(((ThemeEffectiveData)domThemeManager.CreateThemeEffective()).ColorSchemeInternal, @class, list: false);
		method_36(domNotesSlide, @class);
		class856_0.PptCurrentNotesContainer = null;
	}

	private void method_22()
	{
		if (class856_0.DomPresentation.Images.Count <= 0)
		{
			return;
		}
		uint num = 0u;
		List<Class2638> list = new List<Class2638>();
		int num2 = 1;
		foreach (Class878 patternBlip in class856_0.PatternBlips)
		{
			Class2629 @class = patternBlip.method_1(num2);
			Class2638 class2 = new Class2638();
			class2.Header.Version = 2;
			class2.Header.Instance = (short)@class.BlipType;
			class2.BtWin32 = (byte)@class.BlipType;
			class2.BtMacOs = (byte)@class.BlipType;
			class2.FoDelay = num;
			class2.Size = (uint)(@class.vmethod_2() + 8);
			class2.Tag = 255;
			class2.RgbUid = @class.RgbUid.ToByteArray();
			class2.CRef = (uint)patternBlip.ReferenceCount;
			num += class2.Size;
			class856_0.PptBinaryFile.PicturesStream.method_5(@class);
			list.Add(class2);
			num2++;
		}
		foreach (KeyValuePair<IPPImage, List<Class2911>> blipPib in class856_0.BlipPibs)
		{
			PPImage image = (PPImage)blipPib.Key;
			List<Class2911> value = blipPib.Value;
			foreach (Class2911 item in value)
			{
				item.Value = (uint)num2;
			}
			Class2629 class3 = method_23(image);
			Class2638 class4 = new Class2638();
			class4.Header.Version = 2;
			class4.Header.Instance = (short)class3.BlipType;
			class4.BtWin32 = (byte)class3.BlipType;
			class4.BtMacOs = (byte)class3.BlipType;
			class4.FoDelay = num;
			class4.Size = (uint)(class3.vmethod_2() + 8);
			class4.Tag = 255;
			class4.RgbUid = class3.RgbUid.ToByteArray();
			class4.CRef = (uint)value.Count;
			num += class4.Size;
			class856_0.PptBinaryFile.PicturesStream.method_5(class3);
			list.Add(class4);
			num2++;
		}
		if (class856_0.PptBinaryFile.PicturesStream.Records.Count > 0)
		{
			Class2640 blipStore = class856_0.PptBinaryFile.PowerPointDocumentStream.DocumentContainer.DrawingGroup.OfficeArtDgg.BlipStore;
			for (int i = 0; i < list.Count; i++)
			{
				blipStore.Records.Add(list[i]);
			}
			blipStore.Header.Instance = (short)blipStore.Records.Count;
		}
	}

	private Class2629 method_23(PPImage image)
	{
		Class2629 result = null;
		byte[] binaryData = image.BinaryData;
		Enum788 @enum = Class6148.smethod_0(binaryData);
		MemoryStream memoryStream = new MemoryStream(binaryData);
		switch (@enum)
		{
		case Enum788.const_0:
			result = Class2630.smethod_2(memoryStream);
			break;
		case Enum788.const_1:
		case Enum788.const_2:
		{
			Metafile srcMetafile = (Metafile)Image.FromStream(memoryStream);
			memoryStream.Position = 0L;
			result = Class2634.smethod_2(srcMetafile, memoryStream);
			break;
		}
		case Enum788.const_3:
		case Enum788.const_4:
		case Enum788.const_5:
		case Enum788.const_6:
		case Enum788.const_7:
		case Enum788.const_8:
			result = Class2630.smethod_2(memoryStream);
			break;
		}
		return result;
	}

	private void method_24(IBaseSlide domSlide, Class2639 pptMasterOrSlideContainer)
	{
		Class2718 @class = pptMasterOrSlideContainer as Class2718;
		Class2719 class2 = pptMasterOrSlideContainer as Class2719;
		Class2720 class3 = pptMasterOrSlideContainer as Class2720;
		Class2888 pptSlideAtom;
		if (@class != null)
		{
			pptSlideAtom = @class.SlideAtom;
		}
		else if (class2 != null)
		{
			pptSlideAtom = class2.SlideAtom;
		}
		else
		{
			if (class3 == null)
			{
				throw new ArgumentException("MainMasterContainer or SlideContainer is needed.");
			}
			pptSlideAtom = null;
		}
		Class2714 class4 = new Class2714();
		pptMasterOrSlideContainer.Records.Add(class4);
		Class2643 class5 = new Class2643();
		class4.Records.Add(class5);
		Class2743 class6 = new Class2743();
		class5.Records.Add(class6);
		class856_0.PptCurrentOfficeArtFdg = class6;
		class6.DrawingId = (ushort)class856_0.method_9();
		method_25(domSlide, domSlide.Shapes, class5, patriarch: true, pptSlideAtom);
	}

	private void method_25(IBaseSlide domSlide, IShapeCollection domShapeCollection, Class2639 odrawContainer, bool patriarch, Class2888 pptSlideAtom)
	{
		Class2671 @class = new Class2671();
		odrawContainer.Records.Add(@class);
		Class2670 class2 = new Class2670();
		@class.Records.Add(class2);
		Class2836 class3 = new Class2836();
		class2.Records.Add(class3);
		GroupShape groupShape = (GroupShape)domShapeCollection.ParentGroup;
		Class2835 class4 = new Class2835();
		class2.Records.Add(class4);
		class4.Spid = class856_0.method_8(incFdgCsp: true);
		class4.FChild = !patriarch && groupShape.IsGrouped;
		class4.FPatriarch = patriarch;
		class4.FGroup = true;
		if (!patriarch)
		{
			class3.X = (int)(groupShape.RawFrameImpl.ChildX * 12700.0 + 0.5);
			class3.Y = (int)(groupShape.RawFrameImpl.ChildY * 12700.0 + 0.5);
			class3.Width = (int)(groupShape.RawFrameImpl.ChildWidth * 12700.0 + 0.5);
			class3.Height = (int)(groupShape.RawFrameImpl.ChildHeight * 12700.0 + 0.5);
			class4.FHaveAnchor = true;
			Class2834 class5 = new Class2834();
			class2.method_2(class5);
			float rotation = groupShape.RawFrameImpl.Rotation;
			if ((double)Math.Abs(rotation) > 1E-06)
			{
				Class2911 property = new Class2911(Enum426.const_394, isBid: false, (uint)(rotation + 180f) % 360u - 180 << 16);
				class5.Properties.method_0(property);
			}
			if (class4.FChild)
			{
				Class2741 class6 = new Class2741();
				class2.Records.Add(class6);
				if ((rotation >= 45f && rotation < 135f) || (rotation >= 225f && rotation < 315f))
				{
					class6.X = (int)((groupShape.RawFrameImpl.X - (groupShape.RawFrameImpl.Height - groupShape.RawFrameImpl.Width) / 2.0) * 12700.0 + 0.5);
					class6.Y = (int)((groupShape.RawFrameImpl.Y - (groupShape.RawFrameImpl.Width - groupShape.RawFrameImpl.Height) / 2.0) * 12700.0 + 0.5);
					class6.Width = (int)(groupShape.RawFrameImpl.Height * 12700.0 + 0.5);
					class6.Height = (int)(groupShape.RawFrameImpl.Width * 12700.0 + 0.5);
					class2.ShapeProp.FFlipH = groupShape.RawFrameImpl.FlipV == NullableBool.True;
					class2.ShapeProp.FFlipV = groupShape.RawFrameImpl.FlipH == NullableBool.True;
				}
				else
				{
					class6.X = (int)(groupShape.RawFrameImpl.X * 12700.0 + 0.5);
					class6.Y = (int)(groupShape.RawFrameImpl.Y * 12700.0 + 0.5);
					class6.Width = (int)(groupShape.RawFrameImpl.Width * 12700.0 + 0.5);
					class6.Height = (int)(groupShape.RawFrameImpl.Height * 12700.0 + 0.5);
					class2.ShapeProp.FFlipH = groupShape.RawFrameImpl.FlipH == NullableBool.True;
					class2.ShapeProp.FFlipV = groupShape.RawFrameImpl.FlipV == NullableBool.True;
				}
			}
			else
			{
				Class2742 class7 = new Class2742();
				class2.Records.Add(class7);
				if ((rotation >= 45f && rotation < 135f) || (rotation >= 225f && rotation < 315f))
				{
					class7.X = (int)((double)((groupShape.X - (groupShape.Height - groupShape.Width) / 2f) * 8f) + 0.5);
					class7.Y = (int)((double)((groupShape.Y - (groupShape.Width - groupShape.Height) / 2f) * 8f) + 0.5);
					class7.Width = (int)((double)(groupShape.Height * 8f) + 0.5);
					class7.Height = (int)((double)(groupShape.Width * 8f) + 0.5);
					class2.ShapeProp.FFlipH = groupShape.RawFrameImpl.FlipV == NullableBool.True;
					class2.ShapeProp.FFlipV = groupShape.RawFrameImpl.FlipH == NullableBool.True;
				}
				else
				{
					class7.X = (int)((double)(groupShape.X * 8f) + 0.5);
					class7.Y = (int)((double)(groupShape.Y * 8f) + 0.5);
					class7.Width = (int)((double)(groupShape.Width * 8f) + 0.5);
					class7.Height = (int)((double)(groupShape.Height * 8f) + 0.5);
					class2.ShapeProp.FFlipH = groupShape.RawFrameImpl.FlipH == NullableBool.True;
					class2.ShapeProp.FFlipV = groupShape.RawFrameImpl.FlipV == NullableBool.True;
				}
			}
		}
		if (patriarch)
		{
			method_8(domSlide, (Class2643)odrawContainer);
		}
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < domShapeCollection.Count)
			{
				Shape shape = (Shape)domShapeCollection[num2];
				if (shape is IGroupShape)
				{
					IGroupShape groupShape2 = shape as IGroupShape;
					method_25(domSlide, groupShape2.Shapes, @class, patriarch: false, pptSlideAtom);
				}
				else if (shape is ITable)
				{
					Class1045.smethod_20((Table)shape, @class, class856_0);
				}
				else
				{
					if (shape.Slide is ISlide && shape.Placeholder != null)
					{
						switch (shape.Placeholder.Type)
						{
						case PlaceholderType.DateAndTime:
						{
							Class2709 perSlideHeadersFootersContainer = class856_0.PptCurrentMasterOrSlideContainer.PerSlideHeadersFootersContainer;
							perSlideHeadersFootersContainer.HfAtom.FHasDate = true;
							perSlideHeadersFootersContainer.HfAtom.IsDateTimeFixed = ((AutoShape)shape).TextFrame.Paragraphs[0].Portions[0].Field == null;
							if (perSlideHeadersFootersContainer.HfAtom.IsDateTimeFixed)
							{
								perSlideHeadersFootersContainer.UserDate = ((TextFrame)((AutoShape)shape).TextFrame).TextInternal;
							}
							goto IL_0756;
						}
						case PlaceholderType.SlideNumber:
						{
							Class2709 perSlideHeadersFootersContainer = class856_0.PptCurrentMasterOrSlideContainer.PerSlideHeadersFootersContainer;
							perSlideHeadersFootersContainer.HfAtom.FHasSlideNumber = true;
							goto IL_0756;
						}
						case PlaceholderType.Footer:
						{
							Class2709 perSlideHeadersFootersContainer = class856_0.PptCurrentMasterOrSlideContainer.PerSlideHeadersFootersContainer;
							perSlideHeadersFootersContainer.HfAtom.FHasFooter = true;
							perSlideHeadersFootersContainer.FooterText = ((TextFrame)((AutoShape)shape).TextFrame).TextInternal;
							goto IL_0756;
						}
						}
					}
					method_26(shape, @class, pptSlideAtom, num, !patriarch);
					if (shape.Placeholder != null)
					{
						num++;
					}
					if (num > 7)
					{
						throw new PptException("PPT presentaiton can't constains more than 8 placeholders in one slide.");
					}
				}
				goto IL_0756;
			}
			if (class856_0.NotLicensed)
			{
				method_15(domSlide, @class, pptSlideAtom, num, patriarch);
			}
			break;
			IL_0756:
			num2++;
		}
	}

	private Class2670 method_26(Shape domShape, Class2671 odrawShgrContainer, Class2888 pptSlideAtom, int pptPlaceholderPosition, bool child)
	{
		Class201 @class = new Class201(class856_0);
		Class2670 class2 = @class.method_0(odrawShgrContainer, addToContainer: false);
		class2.AutoInit = true;
		bool flag = true;
		AutoShape autoShape = domShape as AutoShape;
		OleObjectFrame oleObjectFrame = domShape as OleObjectFrame;
		Class2835 class3 = new Class2835();
		if (oleObjectFrame != null)
		{
			class3.Header.Instance = 75;
			class3.FHaveSpt = true;
		}
		class2.Records.Add(class3);
		class3.FGroup = false;
		class3.FChild = child;
		class3.FPatriarch = false;
		class3.FDeleted = false;
		class3.FOleShape = oleObjectFrame != null;
		class3.FHaveMaster = false;
		class3.FFlipH = domShape.Frame.FlipH == NullableBool.True;
		class3.FFlipV = domShape.Frame.FlipV == NullableBool.True;
		class3.FConnector = domShape is IConnector;
		class3.FHaveAnchor = true;
		class3.FBackground = false;
		GeometryShape geometryShape = domShape as GeometryShape;
		if (geometryShape != null)
		{
			if (geometryShape.ShapeType == ShapeType.NotDefined && domShape.PPTUnsupportedProps.OfficeArtSpContainer_ShapeProp != null)
			{
				class3.ShapeType = domShape.PPTUnsupportedProps.OfficeArtSpContainer_ShapeProp.ShapeType;
				class3.FHaveSpt = domShape.PPTUnsupportedProps.OfficeArtSpContainer_ShapeProp.FHaveSpt;
			}
			else
			{
				Enum425 @enum = method_45(geometryShape.ShapeType);
				if (@enum != 0)
				{
					class3.ShapeType = @enum;
					class3.FHaveSpt = geometryShape.ShapeType != ShapeType.NotDefined;
				}
				else
				{
					class3.FHaveSpt = false;
				}
			}
		}
		Class2834 class4 = @class.method_1();
		class4.Properties.method_0(new Class2911(Enum426.const_404, 262144u));
		Class2837 class5 = @class.method_3();
		method_28(domShape, class4, class5);
		Class858.smethod_1(domShape, class4);
		if (autoShape != null && autoShape.TextFrame != null)
		{
			Class1036.smethod_11(autoShape, class4, class856_0);
		}
		method_30(domShape, class4, class5);
		if (domShape.Hidden)
		{
			Class2922 class6 = new Class2922();
			class4.Properties.method_0(class6);
			class6.OfUsefHidden = true;
			class6.efHidden = true;
		}
		FillFormatEffectiveData fillFormatEffectiveData = domShape.vmethod_1();
		FillFormat fillFormat;
		if (fillFormatEffectiveData != null)
		{
			fillFormat = new FillFormat(domShape);
			fillFormat.method_1(fillFormatEffectiveData);
		}
		else
		{
			fillFormat = (FillFormat)domShape.FillFormat;
		}
		Class1052.smethod_1(fillFormat, class4, class5, background: false, class856_0);
		LineFormatEffectiveData lineFormatEffectiveData = domShape.vmethod_0();
		LineFormat lineFormat;
		if (lineFormatEffectiveData != null)
		{
			lineFormat = new LineFormat(domShape);
			lineFormat.method_1(lineFormatEffectiveData);
		}
		else
		{
			lineFormat = (LineFormat)domShape.LineFormat;
		}
		LineJoinStyle defaultJoin = ((geometryShape != null) ? Class232.smethod_7(geometryShape.ShapeType) : LineJoinStyle.NotDefined);
		if (lineFormat != null)
		{
			Class1056.smethod_2(lineFormat, class2, defaultJoin, class856_0);
		}
		Class875.smethod_1(domShape.EffectFormat, class4, class5, class856_0);
		Class864.smethod_1(domShape.ThreeDFormat, class4, class5, class856_0);
		if ((double)Math.Abs(domShape.RawFrameImpl.Rotation) > 1E-06)
		{
			Class2911 property = new Class2911(Enum426.const_394, isBid: false, (uint)domShape.RawFrameImpl.Rotation % 360u << 16);
			class4.Properties.method_0(property);
		}
		if (domShape.PPTUnsupportedProps.OfficeArtSpContainer_ShapePrimaryOptions != null)
		{
			Class2944 properties = domShape.PPTUnsupportedProps.OfficeArtSpContainer_ShapePrimaryOptions.Properties;
			Class2914 class7 = properties[Enum426.const_426] as Class2914;
			if (class7 != null)
			{
				class4.Properties.method_0(class7);
			}
			if (properties[Enum426.const_424] is Class2932 property2)
			{
				class4.Properties.method_0(property2);
			}
			if (properties[Enum426.const_420] is Class2931 property3)
			{
				class4.Properties.method_0(property3);
			}
			Class2920 class8 = properties[Enum426.const_119] as Class2920;
			if (class8 != null)
			{
				class4.Properties.method_0(class8);
			}
			if (properties[Enum426.const_82] is Class2912 property4)
			{
				class4.Properties.method_0(property4);
			}
			Class2923 class9 = properties[Enum426.const_154] as Class2923;
			if (class9 != null)
			{
				class4.Properties.method_0(class9);
			}
			Class2918 class10 = properties[Enum426.const_419] as Class2918;
			if (class10 != null)
			{
				class4.Properties.method_0(class10);
			}
			if (properties[Enum426.const_410] is Class2928 property5)
			{
				class4.Properties.method_0(property5);
			}
			if (properties[Enum426.const_18] is Class2933 property6)
			{
				class4.Properties.method_0(property6);
			}
			Class2922 class11 = properties[Enum426.const_50] as Class2922;
			if (class11 != null)
			{
				class4.Properties.method_0(class11);
			}
		}
		float rotation = domShape.RawFrameImpl.Rotation;
		if (child)
		{
			Class2741 class12 = new Class2741();
			class2.Records.Add(class12);
			if ((rotation >= 45f && rotation < 135f) || (rotation >= 225f && rotation < 315f))
			{
				class12.X = (int)((domShape.RawFrameImpl.X - (domShape.RawFrameImpl.Height - domShape.RawFrameImpl.Width) / 2.0) * 12700.0 + 0.5);
				class12.Y = (int)((domShape.RawFrameImpl.Y - (domShape.RawFrameImpl.Width - domShape.RawFrameImpl.Height) / 2.0) * 12700.0 + 0.5);
				class12.Width = (int)(domShape.RawFrameImpl.Height * 12700.0 + 0.5);
				class12.Height = (int)(domShape.RawFrameImpl.Width * 12700.0 + 0.5);
				class2.ShapeProp.FFlipH = domShape.RawFrameImpl.FlipV == NullableBool.True;
				class2.ShapeProp.FFlipV = domShape.RawFrameImpl.FlipH == NullableBool.True;
			}
			else
			{
				class12.X = (int)(domShape.RawFrameImpl.X * 12700.0 + 0.5);
				class12.Y = (int)(domShape.RawFrameImpl.Y * 12700.0 + 0.5);
				class12.Width = (int)(domShape.RawFrameImpl.Width * 12700.0 + 0.5);
				class12.Height = (int)(domShape.RawFrameImpl.Height * 12700.0 + 0.5);
				class2.ShapeProp.FFlipH = domShape.RawFrameImpl.FlipH == NullableBool.True;
				class2.ShapeProp.FFlipV = domShape.RawFrameImpl.FlipV == NullableBool.True;
			}
		}
		else
		{
			Class2742 class13 = new Class2742();
			class2.Records.Add(class13);
			if ((rotation >= 45f && rotation < 135f) || (rotation >= 225f && rotation < 315f))
			{
				class13.X = (int)((double)((domShape.X - (domShape.Height - domShape.Width) / 2f) * 8f) + 0.5);
				class13.Y = (int)((double)((domShape.Y - (domShape.Width - domShape.Height) / 2f) * 8f) + 0.5);
				class13.Width = (int)((double)(domShape.Height * 8f) + 0.5);
				class13.Height = (int)((double)(domShape.Width * 8f) + 0.5);
				class2.ShapeProp.FFlipH = domShape.RawFrameImpl.FlipV == NullableBool.True;
				class2.ShapeProp.FFlipV = domShape.RawFrameImpl.FlipH == NullableBool.True;
			}
			else
			{
				class13.X = (int)((double)(domShape.X * 8f) + 0.5);
				class13.Y = (int)((double)(domShape.Y * 8f) + 0.5);
				class13.Width = (int)((double)(domShape.Width * 8f) + 0.5);
				class13.Height = (int)((double)(domShape.Height * 8f) + 0.5);
				class2.ShapeProp.FFlipH = domShape.RawFrameImpl.FlipH == NullableBool.True;
				class2.ShapeProp.FFlipV = domShape.RawFrameImpl.FlipV == NullableBool.True;
			}
		}
		Class2304 class14 = method_27(domShape);
		if (class14 != null)
		{
			Class2641 class15 = new Class2641();
			class2.Records.Add(class15);
			Class215.smethod_12(class14, class15);
		}
		Class2641 class16 = @class.method_4();
		if (oleObjectFrame != null)
		{
			Class2874 class17 = new Class2874();
			class2.ClientData.Records.Add(class17);
			class17.ExObjIdRef = Class1044.smethod_14(oleObjectFrame, class856_0);
		}
		if (domShape.HyperlinkClick != null)
		{
			Class1054.smethod_3(domShape.HyperlinkClick, class2, class856_0);
		}
		if (domShape.Placeholder != null)
		{
			Class2885 class18 = new Class2885();
			if (domShape.Slide is IMasterSlide)
			{
				class18.Position = pptPlaceholderPosition;
			}
			else
			{
				class18.Position = -1;
			}
			class18.Size = (Enum385)domShape.Placeholder.Size;
			if (!(domShape.Slide is IMasterSlide) && (!(domShape.Slide is ILayoutSlide) || ((ILayoutSlide)domShape.Slide).LayoutType != 0))
			{
				if (domShape.Slide is ISlide)
				{
					class18.PlacementId = Class232.smethod_5(domShape.Placeholder.Type, domShape.Placeholder.Orientation);
					if (autoShape != null)
					{
						@class.method_8(autoShape.TextFrame, null, method_43(class18.PlacementId, class18.Size));
					}
				}
				else if (domShape.Slide is INotesSlide)
				{
					if (Class232.smethod_4(domShape.Placeholder.Type) == Enum384.const_0)
					{
						flag = false;
					}
					if (flag)
					{
						class18.PlacementId = Class232.smethod_4(domShape.Placeholder.Type);
						if (autoShape != null)
						{
							@class.method_8(autoShape.TextFrame, null, method_43(class18.PlacementId, class18.Size));
						}
					}
				}
			}
			else
			{
				class18.PlacementId = Class232.smethod_3(domShape.Placeholder.Type);
				if (class18.PlacementId != Enum384.const_7 && class18.PlacementId != Enum384.const_9 && class18.PlacementId != Enum384.const_8)
				{
					if (autoShape != null)
					{
						@class.method_8(autoShape.TextFrame, null, method_43(class18.PlacementId, class18.Size));
					}
				}
				else
				{
					TextFrame textFrame = ((autoShape == null || autoShape.TextFrame == null) ? new TextFrame(null) : ((TextFrame)autoShape.TextFrame));
					textFrame.TextInternal = "*";
					Class2951 contentRecords = class2.ClientTextBox.ContentRecords;
					switch (class18.PlacementId)
					{
					case Enum384.const_7:
						contentRecords.ParentList.method_2(new Class2849(contentRecords));
						break;
					case Enum384.const_8:
						contentRecords.ParentList.method_2(new Class2852(contentRecords));
						break;
					case Enum384.const_9:
						contentRecords.ParentList.method_2(new Class2848(contentRecords));
						break;
					}
					@class.method_8(textFrame, null, method_43(class18.PlacementId, class18.Size));
				}
			}
			bool flag2 = class18.PlacementId != Enum384.const_0;
			if (class18.Position == -1 && pptSlideAtom == null)
			{
				flag2 = false;
			}
			if (flag2)
			{
				class2.ClientData.Records.Add(class18);
			}
			if (pptSlideAtom != null)
			{
				pptSlideAtom.RgPlaceholderTypes[pptPlaceholderPosition] = class18.PlacementId;
			}
			Class2923 class19 = class4.Properties[Enum426.const_154] as Class2923;
			if (class19 == null)
			{
				class4.Properties.Add(class19 = new Class2923());
			}
			class19.Folded_fNoLineDrawDash = false;
			if (class18.PlacementId != Enum384.const_13)
			{
				class19.Folded_fNoLineDrawDash = true;
			}
		}
		method_29(domShape, class16);
		if (autoShape != null && domShape.Placeholder == null)
		{
			bool flag3 = false;
			if (autoShape.TextFrame != null && ((TextFrame)autoShape.TextFrame).IsGeometryText)
			{
				flag3 = true;
			}
			if (!flag3)
			{
				@class.method_8(autoShape.TextFrame, null, Enum449.const_3);
			}
		}
		if (flag)
		{
			@class.method_9();
			@class.method_6();
			class3.Spid = class856_0.method_8(incFdgCsp: true);
			class856_0.ShapeIdToOfficeArtFSPSpidMap[domShape.ShapeId] = class3.Spid;
		}
		Class2885 placeholderAtom = class16.PlaceholderAtom;
		if (class856_0.PptCurrentMasterOrSlideContainer is Class2719 class20 && class20.SlideAtom.Geom != Enum451.const_2 && class856_0.PptCurrentNotesContainer == null && placeholderAtom != null)
		{
			Class2718 class21 = null;
			foreach (Class2718 mainMasterContainer in class856_0.PptBinaryFile.PowerPointDocumentStream.MainMasterContainerList)
			{
				if (mainMasterContainer.SlideId == class20.SlideAtom.MasterIdRef)
				{
					class21 = mainMasterContainer;
					break;
				}
			}
			if (class21 != null)
			{
				List<Class2623> list = Class2639.smethod_0(class21.Drawing.OfficeArtDg, 61444);
				foreach (Class2623 item in list)
				{
					Class2670 class22 = (Class2670)item;
					if (class22.ClientData != null && class22.ClientData.PlaceholderAtom != null && class22.ClientData.PlaceholderAtom.PlacementId == method_44(placeholderAtom.PlacementId))
					{
						class3.FHaveMaster = true;
						class3.FHaveSpt = false;
						Class2911 property7 = new Class2911(Enum426.const_0, class22.ShapeProp.Spid);
						class4.Properties.Add(property7);
						break;
					}
				}
			}
		}
		@class.method_7();
		return class2;
	}

	private Class2304 method_27(Shape domShape)
	{
		foreach (IEffect item in domShape.Slide.Timeline.MainSequence)
		{
			if (item is Effect effect2 && effect2.PPTXUnsupportedProps.ShapeTarget is Shape shape && shape.ShapeId == domShape.ShapeId && effect2.PresetClassType == EffectPresetClassType.Entrance)
			{
				return effect2.PPTXUnsupportedProps.ParRef;
			}
		}
		return null;
	}

	private void method_28(IShape domShape, Class2834 odrawFopt, Class2837 odrawTertiaryFopt)
	{
		PictureFillFormat pictureFillFormat = null;
		if (!(domShape is PictureFrame pictureFrame))
		{
			if (!(domShape is OleObjectFrame oleObjectFrame))
			{
				return;
			}
			pictureFillFormat = oleObjectFrame.pictureFillFormat_0;
		}
		else
		{
			pictureFillFormat = (PictureFillFormat)pictureFrame.PictureFormat;
		}
		if (pictureFillFormat != null)
		{
			Class1061.smethod_1(pictureFillFormat, odrawFopt, class856_0);
			Class2919 property = new Class2919();
			odrawFopt.Properties.method_0(property);
		}
	}

	private void method_29(Shape domShape, Class2641 ppOfficeArtClientData)
	{
		if (class856_0.DomPresentation.method_0() || domShape.CustomData.Tags.Count != 0)
		{
			Class2729 @class = new Class2729();
			ppOfficeArtClientData.method_2(@class);
			if (class856_0.DomPresentation.method_0())
			{
				Class2726 class2 = new Class2726();
				@class.Records.Add(class2);
				Class2843 item = new Class2843(Class2729.string_0, 0);
				class2.Records.Add(item);
				Class2843 item2 = new Class2843(domShape.UniqueId.ToString(CultureInfo.InvariantCulture), 1);
				class2.Records.Add(item2);
			}
			string[] namesOfTags = domShape.CustomData.Tags.GetNamesOfTags();
			for (int i = 0; i < namesOfTags.Length; i++)
			{
				Class2726 class3 = new Class2726();
				@class.Records.Add(class3);
				Class2843 item3 = new Class2843(namesOfTags[i], 0);
				class3.Records.Add(item3);
				Class2843 item4 = new Class2843(domShape.CustomData.Tags[namesOfTags[i]], 1);
				class3.Records.Add(item4);
			}
		}
	}

	private void method_30(IShape domShape, Class2834 odrawFopt, Class2837 odrawTertiaryFopt)
	{
		if (!(domShape is GeometryShape geometryShape))
		{
			return;
		}
		Class2921 @class = (Class2921)odrawFopt.Properties[Enum426.const_80];
		if (@class == null)
		{
			odrawFopt.Properties.Add(@class = new Class2921());
		}
		if (method_45(geometryShape.ShapeType) == Enum425.const_0)
		{
			Class2911 property = new Class2911(Enum426.const_57, 0u);
			odrawFopt.Properties.method_0(property);
			Class2911 property2 = new Class2911(Enum426.const_58, 0u);
			odrawFopt.Properties.method_0(property2);
			Class2911 property3 = new Class2911(Enum426.const_59, 21600u);
			odrawFopt.Properties.method_0(property3);
			Class2911 property4 = new Class2911(Enum426.const_60, 21600u);
			odrawFopt.Properties.method_0(property4);
			Class2911 property5 = new Class2911(Enum426.const_61, 4u);
			odrawFopt.Properties.method_0(property5);
			Class516[] paths = geometryShape.Geometry.PPTXUnsupportedProps.Paths;
			int num = 0;
			int num2 = 0;
			List<Class2955> list = new List<Class2955>();
			List<Class2953> list2 = new List<Class2953>();
			if (paths != null)
			{
				Class2955 class2 = new Class2955(0, 0);
				foreach (Class516 class3 in paths)
				{
					if (class3.Width > num)
					{
						num = (int)class3.Width;
					}
					if (class3.Height > num2)
					{
						num2 = (int)class3.Height;
					}
					long[] data = class3.Data;
					int num3 = 0;
					for (int j = 0; j < class3.Commands.Length; j++)
					{
						switch (class3.Commands[j])
						{
						case Enum115.const_0:
							list2.Add(new Class2953(Enum431.const_3, 1));
							break;
						case Enum115.const_1:
						{
							int x4 = (int)data[num3];
							int y4 = (int)data[num3 + 1];
							num3 += 2;
							list2.Add(new Class2953(Enum431.const_2, 0));
							class2 = new Class2955(x4, y4);
							list.Add(class2);
							if (class2.X > num)
							{
								num = class2.X;
							}
							if (class2.Y > num2)
							{
								num2 = class2.Y;
							}
							break;
						}
						case Enum115.const_2:
						{
							int x5 = (int)data[num3];
							int y5 = (int)data[num3 + 1];
							num3 += 2;
							list2.Add(new Class2953(Enum431.const_0, 1));
							class2 = new Class2955(x5, y5);
							list.Add(class2);
							if (class2.X > num)
							{
								num = class2.X;
							}
							if (class2.Y > num2)
							{
								num2 = class2.Y;
							}
							break;
						}
						case Enum115.const_3:
						{
							int num4 = (int)data[num3];
							int num5 = (int)data[num3 + 1];
							int num6 = (int)(data[num3 + 2] / 60000L);
							int num7 = (int)(data[num3 + 3] / 60000L);
							int num8 = num6 + num7;
							num3 += 4;
							int num9 = (int)((double)class2.X - Math.Cos((double)num6 * Math.PI / 180.0) * (double)num4);
							int num10 = (int)((double)class2.Y - Math.Sin((double)num6 * Math.PI / 180.0) * (double)num5);
							int x6 = num9 - num4;
							int y6 = num10 - num5;
							int x7 = num9 + num4;
							int y7 = num10 + num5;
							int num11 = (int)(Math.Cos((double)num6 * Math.PI / 180.0) * (double)num4);
							int num12 = (int)(Math.Sin((double)num6 * Math.PI / 180.0) * (double)num5);
							int num13 = (int)(Math.Cos((double)num8 * Math.PI / 180.0) * (double)num4);
							int num14 = (int)(Math.Sin((double)num8 * Math.PI / 180.0) * (double)num5);
							if (num7 < 0)
							{
								list2.Add(new Class2954(Enum431.const_5, Enum430.const_3, 4));
							}
							else
							{
								list2.Add(new Class2954(Enum431.const_5, Enum430.const_5, 4));
							}
							list.Add(new Class2955(x6, y6));
							list.Add(new Class2955(x7, y7));
							list.Add(new Class2955(num9 + num11, num10 + num12));
							class2 = new Class2955(num9 + num13, num10 + num14);
							list.Add(class2);
							if (class2.X > num)
							{
								num = class2.X;
							}
							if (class2.Y > num2)
							{
								num2 = class2.Y;
							}
							break;
						}
						case Enum115.const_4:
						{
							int x8 = (int)data[num3];
							int y8 = (int)data[num3 + 1];
							int x9 = (int)data[num3 + 2];
							int y9 = (int)data[num3 + 3];
							num3 += 4;
							list2.Add(new Class2954(Enum431.const_5, Enum430.const_9, 1));
							list.Add(new Class2955(x8, y8));
							class2 = new Class2955(x9, y9);
							list.Add(class2);
							if (class2.X > num)
							{
								num = class2.X;
							}
							if (class2.Y > num2)
							{
								num2 = class2.Y;
							}
							break;
						}
						case Enum115.const_5:
						{
							int x = (int)data[num3];
							int y = (int)data[num3 + 1];
							int x2 = (int)data[num3 + 2];
							int y2 = (int)data[num3 + 3];
							int x3 = (int)data[num3 + 4];
							int y3 = (int)data[num3 + 5];
							num3 += 6;
							list2.Add(new Class2953(Enum431.const_1, 1));
							list.Add(new Class2955(x, y));
							list.Add(new Class2955(x2, y2));
							class2 = new Class2955(x3, y3);
							list.Add(class2);
							if (class2.X > num)
							{
								num = class2.X;
							}
							if (class2.Y > num2)
							{
								num2 = class2.Y;
							}
							break;
						}
						}
					}
				}
			}
			if (num != 0)
			{
				odrawFopt.Properties.method_0(new Class2911(Enum426.const_59, isBid: false, (uint)num));
			}
			if (num2 != 0)
			{
				odrawFopt.Properties.method_0(new Class2911(Enum426.const_60, isBid: false, (uint)num2));
			}
			if (list.Count > 0)
			{
				Class2934 class4 = new Class2934(Enum426.const_62, (ushort)list.Count, 8);
				odrawFopt.Properties.method_0(class4);
				for (int k = 0; k < list.Count; k++)
				{
					class4[k] = list[k].LongValue;
				}
			}
			if (list2.Count > 0)
			{
				if (list2[list2.Count - 1].Type != Enum431.const_4)
				{
					list2.Add(new Class2953(Enum431.const_4, 0));
				}
				Class2934 class5 = new Class2934(Enum426.const_63, (ushort)list2.Count, 2);
				odrawFopt.Properties.method_0(class5);
				for (int l = 0; l < list2.Count; l++)
				{
					class5[l] = list2[l].Value;
				}
			}
		}
		int[] array = Class232.smethod_25(geometryShape.Geometry.Adjustments, geometryShape.Geometry.Preset, geometryShape.Frame.Width, geometryShape.Frame.Height);
		for (int m = 0; m < array.Length; m++)
		{
			Class2911 property6 = new Class2911((Enum426)(327 + m), (uint)array[m]);
			odrawFopt.Properties.method_0(property6);
		}
		if (@class.Value == 0)
		{
			odrawFopt.Properties.Remove(Enum426.const_80);
		}
	}

	private void method_31()
	{
		for (int i = 0; i < class856_0.DomPresentation.Slides.Count; i++)
		{
			method_35((Slide)class856_0.DomPresentation.Slides[i]);
		}
	}

	private void method_32()
	{
		if (class856_0.DomPresentation.VbaProject != null)
		{
			Class2716 docInfoList = class856_0.PptBinaryFile.PowerPointDocumentStream.DocumentContainer.DocInfoList;
			Class2736 vBAInfo = docInfoList.VBAInfo;
			Class2771 @class = new Class2771();
			@class.Data = ((class856_0.DomPresentation.VbaProjectRootStorage == null) ? null : class856_0.DomPresentation.VbaProjectRootStorage.ToBinary());
			vBAInfo.VbaInfoAtom.PersistIdRef = class856_0.PptBinaryFile.PowerPointDocumentStream.method_16(@class);
			vBAInfo.VbaInfoAtom.FHasMacros = true;
		}
	}

	private void method_33()
	{
		foreach (KeyValuePair<Class2694, ISlide> internalHyperlink in class856_0.InternalHyperlinks)
		{
			uint num = class856_0.SlideToSlideId[internalHyperlink.Value];
			internalHyperlink.Key.Records.Add(new Class2843("Slide " + (num - 256 + 1), 0));
			internalHyperlink.Key.Records.Add(new Class2843(num + "," + (num - 256 + 1) + ",Slide " + (num - 256 + 1), 3));
		}
	}

	private void method_34(IMasterSlide domMasterSlide)
	{
		class856_0.PptCurrentTextMasterStyleList = null;
		if (class856_0.DelayedMasterStyles.ContainsKey(domMasterSlide))
		{
			class856_0.PptCurrentTextMasterStyleList = class856_0.DelayedMasterStyles[domMasterSlide];
		}
	}

	private void method_35(Slide domSlide)
	{
		Class2719 @class = new Class2719();
		Class2855 class2 = class856_0.PptBinaryFile.PowerPointDocumentStream.method_14(@class, domSlide.PPTUnsupportedProps.SlideId);
		class856_0.SlideToSlideId.Add(domSlide, class2.SlideId);
		class856_0.PptCurrentMasterOrSlideContainer = @class;
		class2.FShouldCollapse = domSlide.BaseSlidePPTUnsupportedProps.SlidePersistAtom_FShouldCollapse;
		Class2888 slideAtom = @class.SlideAtom;
		if (domSlide.LayoutSlide != null && ((LayoutSlide)domSlide.LayoutSlide).PPTUnsupportedProps.IsLayoutLoadedAsTitleMasterSlide)
		{
			slideAtom.MasterIdRef = class856_0.TitleLayoutMasterSlideToSlideId[domSlide.LayoutSlide];
		}
		else
		{
			slideAtom.MasterIdRef = ((MasterSlide)domSlide.MasterSlide).PPTUnsupportedProps.SlideId;
		}
		slideAtom.NotesIdRef = 0u;
		slideAtom.FMasterBackground = domSlide.Background.Type == BackgroundType.NotDefined;
		slideAtom.FMasterObjects = domSlide.PPTXUnsupportedProps.ShowMasterShapes;
		bool flag;
		if (flag = domSlide.PPTUnsupportedProps.SlideContainer_ColorSchemeAtom != null && !domSlide.PPTUnsupportedProps.IsMasterTheme)
		{
			slideAtom.FMasterScheme = domSlide.PPTUnsupportedProps.IsMasterTheme;
		}
		else
		{
			slideAtom.FMasterScheme = !domSlide.ThemeManager.IsOverrideThemeEnabled;
		}
		method_34(domSlide.MasterSlide);
		class856_0.NotLicensed = Class1179.smethod_1() == Enum179.const_0;
		method_24(domSlide, @class);
		class856_0.NotLicensed = false;
		if (flag)
		{
			@class.Records.Add(domSlide.PPTUnsupportedProps.SlideContainer_ColorSchemeAtom);
		}
		else
		{
			Class1050.smethod_1(((ThemeEffectiveData)domSlide.ThemeManager.CreateThemeEffective()).ColorSchemeInternal, @class, list: false);
		}
		method_36(domSlide, @class);
		slideAtom.Geom = Enum451.const_11;
		for (int i = 0; i < 8; i++)
		{
			slideAtom.RgPlaceholderTypes[i] = Enum384.const_0;
		}
		if (domSlide.NotesSlide != null)
		{
			method_21((NotesSlide)domSlide.NotesSlide, domSlide.NotesSlide.ThemeManager);
		}
		Class231.smethod_1(domSlide, @class, class856_0);
		class856_0.PptCurrentMasterOrSlideContainer = null;
	}

	private void method_36(BaseSlide domSlide, Class2639 slideContainer)
	{
		Class2727 @class = new Class2728();
		slideContainer.Records.Add(@class);
		method_37(domSlide, @class);
		Class2723 class2 = new Class2723();
		@class.Records.Add(class2);
		Class2843 class3 = new Class2843("___PPT10", 0);
		class3.Header.Instance = 0;
		class2.Records.Add(class3);
		Class2673 class4 = new Class2675();
		class2.Records.Add(class4);
		class4.Header.Version = 0;
		class4.Header.Instance = 0;
		if (domSlide != null)
		{
			ICommentAuthorCollection commentAuthors = class856_0.DomPresentation.CommentAuthors;
			if (commentAuthors != null)
			{
				foreach (ICommentAuthor item in commentAuthors)
				{
					ICommentCollection comments = item.Comments;
					foreach (Comment item2 in comments)
					{
						if (item2.Slide == domSlide)
						{
							Class2685 class5 = new Class2685();
							class4.Records.Add(class5);
							method_40(item2, class5);
						}
					}
				}
			}
		}
		Class2889 class6 = new Class2889();
		class6.Header.Version = 0;
		class6.Header.Instance = 0;
		class4.Records.Add(class6);
		method_38(domSlide, class4);
	}

	private void method_37(BaseSlide domSlide, Class2727 progTagsContainer)
	{
		if (domSlide != null && domSlide.CustomData != null && domSlide.CustomData.Tags != null && domSlide.CustomData.Tags.Count != 0)
		{
			if (progTagsContainer == null)
			{
				throw new InvalidOperationException();
			}
			Class880.smethod_1(domSlide.CustomData.Tags, progTagsContainer);
		}
	}

	private void method_38(BaseSlide domSlide, Class2673 binaryTagExtension)
	{
		if (domSlide != null && domSlide.Timeline != null && (domSlide.Timeline.MainSequence.Count != 0 || domSlide.Timeline.InteractiveSequences.Count != 0))
		{
			method_39(domSlide, out var timingElementData, out var timelineSerializationContext);
			Class2880 item = new Class2880();
			binaryTagExtension.Records.Add(item);
			Class2650 @class = new Class2650();
			binaryTagExtension.Records.Add(@class);
			Class214.smethod_1(timingElementData, @class, timelineSerializationContext);
			Class210.smethod_2(timingElementData, binaryTagExtension, timelineSerializationContext);
		}
	}

	private void method_39(IBaseSlide domSlide, out Class2259 timingElementData, out Class234 timelineSerializationContext)
	{
		timingElementData = new Class2259();
		Class899.smethod_4(domSlide);
		timelineSerializationContext = new Class234(class856_0, smethod_0(Class899.smethod_4(domSlide)), class856_0.ShapeIdToOfficeArtFSPSpidMap);
		Class1008.smethod_2(domSlide.Timeline, domSlide.Shapes, timingElementData, timelineSerializationContext);
	}

	private static Dictionary<IShape, uint> smethod_0(SortedList<string, ISlideComponent> shapes)
	{
		Dictionary<IShape, uint> dictionary = new Dictionary<IShape, uint>();
		foreach (KeyValuePair<string, ISlideComponent> shape2 in shapes)
		{
			if (shape2.Value is Shape shape)
			{
				dictionary.Add(shape, shape.ShapeId);
			}
		}
		return dictionary;
	}

	private void method_40(Comment comment, Class2685 comment10Container)
	{
		comment10Container.Author = comment.Author.Name;
		comment10Container.Text = comment.Text;
		comment10Container.Initials = comment.Author.Initials;
		comment10Container.CommentAtom.DateTime = comment.CreatedTime;
		comment10Container.CommentAtom.Anchor = new System.Drawing.Point((int)(comment.Position.X * 12700f), (int)(comment.Position.Y * 12700f));
		comment10Container.CommentAtom.Index = class856_0.method_4();
	}

	private void method_41(IParagraphFormat domParagraphFormat, Class2977 pptTextSiException)
	{
		pptTextSiException.SpellInfo = new Class2967(error: false, clean: true, grammar: false);
		pptTextSiException.Lid = 1049;
		pptTextSiException.AltLid = 0;
	}

	private void method_42(Class2888 slideAtom, MasterSlide domMasterSlide)
	{
		slideAtom.MasterIdRef = 0u;
		slideAtom.NotesIdRef = 0u;
		slideAtom.FMasterBackground = false;
		slideAtom.FMasterObjects = false;
		slideAtom.FMasterScheme = false;
		if (!class856_0.method_2(slideAtom))
		{
			slideAtom.Geom = Enum451.const_11;
		}
		slideAtom.Geom = Enum451.const_1;
		slideAtom.RgPlaceholderTypes[0] = Enum384.const_1;
		slideAtom.RgPlaceholderTypes[1] = Enum384.const_2;
		slideAtom.RgPlaceholderTypes[2] = Enum384.const_7;
		slideAtom.RgPlaceholderTypes[3] = Enum384.const_9;
		slideAtom.RgPlaceholderTypes[4] = Enum384.const_8;
		for (int i = 0; i < domMasterSlide.LayoutSlides.Count; i++)
		{
		}
	}

	private static void smethod_1(Class2894 pptTextmasterStyleAtom, IMasterTheme domTheme, Class856 context)
	{
		Class48 @class = Class53.smethod_1(context);
		if (!pptTextmasterStyleAtom.Levels[0].CharFormat.FontRef.HasValue && domTheme.FontScheme.Major.LatinFont != null && !string.IsNullOrEmpty(domTheme.FontScheme.Major.LatinFont.FontName))
		{
			pptTextmasterStyleAtom.Levels[0].CharFormat.FontRef = @class.Add(Enum2.const_0, domTheme.FontScheme.Major.LatinFont);
		}
		if (!pptTextmasterStyleAtom.Levels[0].CharFormat.OldEAFontRef.HasValue && domTheme.FontScheme.Major.EastAsianFont != null && !string.IsNullOrEmpty(domTheme.FontScheme.Major.EastAsianFont.FontName))
		{
			pptTextmasterStyleAtom.Levels[0].CharFormat.OldEAFontRef = @class.Add(Enum2.const_1, domTheme.FontScheme.Major.EastAsianFont);
		}
	}

	internal static Class2966.Enum441 smethod_2(SchemeColor domColor)
	{
		return domColor switch
		{
			SchemeColor.Background1 => Class2966.Enum441.const_0, 
			SchemeColor.Text1 => Class2966.Enum441.const_1, 
			SchemeColor.Background2 => Class2966.Enum441.const_2, 
			SchemeColor.Text2 => Class2966.Enum441.const_3, 
			SchemeColor.Accent1 => Class2966.Enum441.const_4, 
			SchemeColor.Accent2 => Class2966.Enum441.const_5, 
			SchemeColor.Hyperlink => Class2966.Enum441.const_6, 
			SchemeColor.FollowedHyperlink => Class2966.Enum441.const_7, 
			_ => Class2966.Enum441.const_8, 
		};
	}

	private Enum449 method_43(Enum384 placeholderType, Enum385 size)
	{
		switch (placeholderType)
		{
		default:
			throw new ArgumentOutOfRangeException("placeholderType");
		case Enum384.const_0:
			return Enum449.const_3;
		case Enum384.const_7:
		case Enum384.const_8:
		case Enum384.const_9:
			return Enum449.const_3;
		case Enum384.const_11:
		case Enum384.const_12:
			return Enum449.const_2;
		case Enum384.const_1:
		case Enum384.const_13:
			return Enum449.const_0;
		case Enum384.const_3:
		case Enum384.const_15:
			return Enum449.const_5;
		case Enum384.const_4:
		case Enum384.const_16:
			return Enum449.const_4;
		case Enum384.const_2:
		case Enum384.const_14:
		case Enum384.const_18:
		case Enum384.const_19:
		case Enum384.const_20:
		case Enum384.const_21:
		case Enum384.const_22:
		case Enum384.const_23:
		case Enum384.const_24:
			return size switch
			{
				Enum385.const_0 => Enum449.const_1, 
				Enum385.const_1 => Enum449.const_6, 
				Enum385.const_2 => Enum449.const_7, 
				_ => throw new ArgumentOutOfRangeException("size"), 
			};
		case Enum384.const_5:
		case Enum384.const_6:
		case Enum384.const_10:
		case Enum384.const_17:
		case Enum384.const_25:
		case Enum384.const_26:
			return Enum449.const_3;
		}
	}

	private Enum384 method_44(Enum384 placeholderType)
	{
		switch (placeholderType)
		{
		default:
			throw new ArgumentOutOfRangeException("placeholderType");
		case Enum384.const_1:
		case Enum384.const_2:
		case Enum384.const_3:
		case Enum384.const_4:
		case Enum384.const_5:
		case Enum384.const_6:
		case Enum384.const_7:
		case Enum384.const_8:
		case Enum384.const_9:
		case Enum384.const_10:
			return Enum384.const_0;
		case Enum384.const_13:
			return Enum384.const_1;
		case Enum384.const_15:
			return Enum384.const_3;
		case Enum384.const_16:
			return Enum384.const_4;
		case Enum384.const_14:
		case Enum384.const_19:
		case Enum384.const_20:
		case Enum384.const_21:
		case Enum384.const_22:
		case Enum384.const_23:
		case Enum384.const_24:
			return Enum384.const_2;
		case Enum384.const_0:
		case Enum384.const_11:
		case Enum384.const_12:
		case Enum384.const_17:
		case Enum384.const_18:
		case Enum384.const_25:
		case Enum384.const_26:
			return Enum384.const_0;
		}
	}

	private Enum425 method_45(ShapeType domShapeType)
	{
		Enum425 result = Enum425.const_0;
		switch (domShapeType)
		{
		case ShapeType.NotDefined:
			result = Enum425.const_1;
			break;
		case ShapeType.Line:
			result = Enum425.const_20;
			break;
		case ShapeType.Triangle:
			result = Enum425.const_5;
			break;
		case ShapeType.RightTriangle:
			result = Enum425.const_6;
			break;
		case ShapeType.Rectangle:
			result = Enum425.const_1;
			break;
		case ShapeType.Diamond:
			result = Enum425.const_4;
			break;
		case ShapeType.Parallelogram:
			result = Enum425.const_7;
			break;
		case ShapeType.Trapezoid:
			result = Enum425.const_8;
			break;
		case ShapeType.Pentagon:
			result = Enum425.const_56;
			break;
		case ShapeType.Hexagon:
			result = Enum425.const_9;
			break;
		case ShapeType.Octagon:
			result = Enum425.const_10;
			break;
		case ShapeType.FourPointedStar:
			result = Enum425.const_187;
			break;
		case ShapeType.FivePointedStar:
			result = Enum425.const_12;
			break;
		case ShapeType.EightPointedStar:
			result = Enum425.const_58;
			break;
		case ShapeType.SixteenPointedStar:
			result = Enum425.const_59;
			break;
		case ShapeType.TwentyFourPointedStar:
			result = Enum425.const_92;
			break;
		case ShapeType.ThirtyTwoPointedStar:
			result = Enum425.const_60;
			break;
		case ShapeType.RoundCornerRectangle:
			result = Enum425.const_2;
			break;
		case ShapeType.Plaque:
			result = Enum425.const_21;
			break;
		case ShapeType.Ellipse:
			result = Enum425.const_3;
			break;
		case ShapeType.HomePlate:
			result = Enum425.const_15;
			break;
		case ShapeType.Chevron:
			result = Enum425.const_55;
			break;
		case ShapeType.BlockArc:
			result = Enum425.const_95;
			break;
		case ShapeType.Donut:
			result = Enum425.const_23;
			break;
		case ShapeType.NoSmoking:
			result = Enum425.const_57;
			break;
		case ShapeType.LeftArrow:
			result = Enum425.const_66;
			break;
		case ShapeType.UpArrow:
			result = Enum425.const_68;
			break;
		case ShapeType.DownArrow:
			result = Enum425.const_67;
			break;
		case ShapeType.StripedRightArrow:
			result = Enum425.const_93;
			break;
		case ShapeType.NotchedRightArrow:
			result = Enum425.const_94;
			break;
		case ShapeType.BentUpArrow:
			result = Enum425.const_90;
			break;
		case ShapeType.LeftRightArrow:
			result = Enum425.const_69;
			break;
		case ShapeType.UpDownArrow:
			result = Enum425.const_70;
			break;
		case ShapeType.LeftUpArrow:
			result = Enum425.const_89;
			break;
		case ShapeType.LeftRightUpArrow:
			result = Enum425.const_182;
			break;
		case ShapeType.QuadArrow:
			result = Enum425.const_76;
			break;
		case ShapeType.CalloutLeftArrow:
			result = Enum425.const_77;
			break;
		case ShapeType.CalloutRightArrow:
			result = Enum425.const_78;
			break;
		case ShapeType.CalloutUpArrow:
			result = Enum425.const_79;
			break;
		case ShapeType.CalloutDownArrow:
			result = Enum425.const_80;
			break;
		case ShapeType.CalloutLeftRightArrow:
			result = Enum425.const_81;
			break;
		case ShapeType.CalloutUpDownArrow:
			result = Enum425.const_82;
			break;
		case ShapeType.CalloutQuadArrow:
			result = Enum425.const_83;
			break;
		case ShapeType.BentArrow:
			result = Enum425.const_91;
			break;
		case ShapeType.UTurnArrow:
			result = Enum425.const_101;
			break;
		case ShapeType.CircularArrow:
			result = Enum425.const_99;
			break;
		case ShapeType.CurvedRightArrow:
			result = Enum425.const_102;
			break;
		case ShapeType.CurvedLeftArrow:
			result = Enum425.const_103;
			break;
		case ShapeType.CurvedUpArrow:
			result = Enum425.const_104;
			break;
		case ShapeType.CurvedDownArrow:
			result = Enum425.const_105;
			break;
		case ShapeType.Cube:
			result = Enum425.const_16;
			break;
		case ShapeType.Can:
			result = Enum425.const_22;
			break;
		case ShapeType.LightningBolt:
			result = Enum425.const_73;
			break;
		case ShapeType.Heart:
			result = Enum425.const_74;
			break;
		case ShapeType.Sun:
			result = Enum425.const_183;
			break;
		case ShapeType.Moon:
			result = Enum425.const_184;
			break;
		case ShapeType.SmileyFace:
			result = Enum425.const_96;
			break;
		case ShapeType.IrregularSeal1:
			result = Enum425.const_71;
			break;
		case ShapeType.IrregularSeal2:
			result = Enum425.const_72;
			break;
		case ShapeType.FoldedCorner:
			result = Enum425.const_65;
			break;
		case ShapeType.Bevel:
			result = Enum425.const_84;
			break;
		case ShapeType.LeftBracket:
			result = Enum425.const_85;
			break;
		case ShapeType.RightBracket:
			result = Enum425.const_86;
			break;
		case ShapeType.LeftBrace:
			result = Enum425.const_87;
			break;
		case ShapeType.RightBrace:
			result = Enum425.const_88;
			break;
		case ShapeType.BracketPair:
			result = Enum425.const_185;
			break;
		case ShapeType.BracePair:
			result = Enum425.const_186;
			break;
		case ShapeType.StraightConnector1:
			result = Enum425.const_32;
			break;
		case ShapeType.BentConnector2:
			result = Enum425.const_33;
			break;
		case ShapeType.BentConnector3:
			result = Enum425.const_34;
			break;
		case ShapeType.BentConnector4:
			result = Enum425.const_35;
			break;
		case ShapeType.BentConnector5:
			result = Enum425.const_36;
			break;
		case ShapeType.CurvedConnector2:
			result = Enum425.const_37;
			break;
		case ShapeType.CurvedConnector3:
			result = Enum425.const_38;
			break;
		case ShapeType.CurvedConnector4:
			result = Enum425.const_39;
			break;
		case ShapeType.CurvedConnector5:
			result = Enum425.const_40;
			break;
		case ShapeType.Callout1:
			result = Enum425.const_41;
			break;
		case ShapeType.Callout2:
			result = Enum425.const_42;
			break;
		case ShapeType.Callout3:
			result = Enum425.const_43;
			break;
		case ShapeType.Callout1WithAccent:
			result = Enum425.const_44;
			break;
		case ShapeType.Callout2WithAccent:
			result = Enum425.const_45;
			break;
		case ShapeType.Callout3WithAccent:
			result = Enum425.const_52;
			break;
		case ShapeType.Callout1WithBorder:
			result = Enum425.const_47;
			break;
		case ShapeType.Callout2WithBorder:
			result = Enum425.const_48;
			break;
		case ShapeType.Callout3WithBorder:
			result = Enum425.const_49;
			break;
		case ShapeType.Callout1WithBorderAndAccent:
			result = Enum425.const_50;
			break;
		case ShapeType.Callout2WithBorderAndAccent:
			result = Enum425.const_51;
			break;
		case ShapeType.Callout3WithBorderAndAccent:
			result = Enum425.const_52;
			break;
		case ShapeType.CalloutWedgeRectangle:
			result = Enum425.const_61;
			break;
		case ShapeType.CalloutWedgeRoundRectangle:
			result = Enum425.const_62;
			break;
		case ShapeType.CalloutWedgeEllipse:
			result = Enum425.const_63;
			break;
		case ShapeType.CalloutCloud:
			result = Enum425.const_106;
			break;
		case ShapeType.Ribbon:
			result = Enum425.const_53;
			break;
		case ShapeType.Ribbon2:
			result = Enum425.const_54;
			break;
		case ShapeType.EllipseRibbon:
			result = Enum425.const_107;
			break;
		case ShapeType.EllipseRibbon2:
			result = Enum425.const_108;
			break;
		case ShapeType.VerticalScroll:
			result = Enum425.const_97;
			break;
		case ShapeType.HorizontalScroll:
			result = Enum425.const_98;
			break;
		case ShapeType.Wave:
			result = Enum425.const_64;
			break;
		case ShapeType.DoubleWave:
			result = Enum425.const_188;
			break;
		case ShapeType.Plus:
			result = Enum425.const_11;
			break;
		case ShapeType.ProcessFlow:
			result = Enum425.const_109;
			break;
		case ShapeType.DecisionFlow:
			result = Enum425.const_110;
			break;
		case ShapeType.InputOutputFlow:
			result = Enum425.const_111;
			break;
		case ShapeType.PredefinedProcessFlow:
			result = Enum425.const_112;
			break;
		case ShapeType.InternalStorageFlow:
			result = Enum425.const_113;
			break;
		case ShapeType.DocumentFlow:
			result = Enum425.const_114;
			break;
		case ShapeType.MultiDocumentFlow:
			result = Enum425.const_115;
			break;
		case ShapeType.TerminatorFlow:
			result = Enum425.const_116;
			break;
		case ShapeType.PreparationFlow:
			result = Enum425.const_117;
			break;
		case ShapeType.ManualInputFlow:
			result = Enum425.const_118;
			break;
		case ShapeType.ManualOperationFlow:
			result = Enum425.const_119;
			break;
		case ShapeType.PunchedCardFlow:
			result = Enum425.const_121;
			break;
		case ShapeType.PunchedTapeFlow:
			result = Enum425.const_122;
			break;
		case ShapeType.SummingJunctionFlow:
			result = Enum425.const_123;
			break;
		case ShapeType.OrFlow:
			result = Enum425.const_124;
			break;
		case ShapeType.SortFlow:
			result = Enum425.const_126;
			break;
		case ShapeType.ExtractFlow:
			result = Enum425.const_127;
			break;
		case ShapeType.MergeFlow:
			result = Enum425.const_128;
			break;
		case ShapeType.OfflineStorageFlow:
			result = Enum425.const_129;
			break;
		case ShapeType.OnlineStorageFlow:
			result = Enum425.const_130;
			break;
		case ShapeType.MagneticTapeFlow:
			result = Enum425.const_131;
			break;
		case ShapeType.MagneticDiskFlow:
			result = Enum425.const_132;
			break;
		case ShapeType.MagneticDrumFlow:
			result = Enum425.const_133;
			break;
		case ShapeType.DisplayFlow:
			result = Enum425.const_134;
			break;
		case ShapeType.DelayFlow:
			result = Enum425.const_135;
			break;
		case ShapeType.OffPageConnectorFlow:
			result = Enum425.const_177;
			break;
		case ShapeType.BlankButton:
			result = Enum425.const_189;
			break;
		case ShapeType.HomeButton:
			result = Enum425.const_190;
			break;
		case ShapeType.HelpButton:
			result = Enum425.const_191;
			break;
		case ShapeType.InformationButton:
			result = Enum425.const_192;
			break;
		case ShapeType.ForwardOrNextButton:
			result = Enum425.const_193;
			break;
		case ShapeType.BackOrPreviousButton:
			result = Enum425.const_194;
			break;
		case ShapeType.EndButton:
			result = Enum425.const_195;
			break;
		case ShapeType.BeginningButton:
			result = Enum425.const_196;
			break;
		case ShapeType.ReturnButton:
			result = Enum425.const_197;
			break;
		case ShapeType.DocumentButton:
			result = Enum425.const_198;
			break;
		case ShapeType.SoundButton:
			result = Enum425.const_199;
			break;
		case ShapeType.MovieButton:
			result = Enum425.const_200;
			break;
		}
		return result;
	}

	private Enum453 method_46(SlideSizeType domSlideSizeType)
	{
		return domSlideSizeType switch
		{
			SlideSizeType.OnScreen => Enum453.const_0, 
			SlideSizeType.LetterPaper => Enum453.const_1, 
			SlideSizeType.A4Paper => Enum453.const_2, 
			SlideSizeType.Slide35mm => Enum453.const_3, 
			SlideSizeType.Overhead => Enum453.const_4, 
			SlideSizeType.Banner => Enum453.const_5, 
			_ => Enum453.const_6, 
		};
	}
}
