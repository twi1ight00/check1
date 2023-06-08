using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Theme;
using Aspose.Slides.Vba;
using ns22;
using ns33;
using ns4;
using ns45;
using ns47;
using ns60;
using ns62;
using ns63;
using ns71;

namespace ns15;

internal class Class890
{
	private readonly Presentation presentation_0;

	private Class857 class857_0;

	public Class890(Presentation domPrsentation)
	{
		presentation_0 = domPrsentation;
		if (presentation_0 == null)
		{
			throw new ArgumentNullException();
		}
	}

	public void method_0(Stream stream)
	{
		Class1110 fs = smethod_2(stream);
		method_1(fs);
	}

	public void method_1(Class1110 fs)
	{
		if (fs.RootFolder.method_1("EncryptedPackage") && fs.RootFolder.method_1("EncryptionInfo"))
		{
			((ProtectionManager)presentation_0.ProtectionManager).method_1(fs);
			return;
		}
		if (fs.RootFolder.method_1("Current User"))
		{
			Class2985 @class = new Class2985(fs, presentation_0.LoadOptions);
			class857_0 = new Class857(@class, presentation_0);
			presentation_0.sourceFormat_0 = SourceFormat.Ppt;
			method_2();
			if (!@class.Encrypted)
			{
				method_3();
				class857_0.DomPresentation.ViewProperties.LastView = Class232.smethod_31(@class.PowerPointDocumentStream.UserEditAtom.LastView);
				method_13();
				method_10();
				method_9();
				method_11();
				method_12();
				method_8();
				method_15();
				method_14();
				for (int i = 0; i < presentation_0.LayoutSlides.Count; i++)
				{
				}
			}
			return;
		}
		throw new PptUnsupportedFormatException("Unknown file format.");
	}

	public static bool smethod_0(Stream stream)
	{
		try
		{
			stream.Seek(0L, SeekOrigin.Begin);
			Class1110 @class = smethod_2(stream);
			if (@class.RootFolder.method_1("EncryptedPackage") && @class.RootFolder.method_1("EncryptionInfo"))
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			throw new PptReadException(ex.Message, ex);
		}
	}

	public static bool smethod_1(Stream stream)
	{
		try
		{
			stream.Seek(0L, SeekOrigin.Begin);
			Class1110 fs = smethod_2(stream);
			return Class2985.smethod_0(fs);
		}
		catch (Exception ex)
		{
			throw new PptxReadException(ex.Message, ex);
		}
	}

	public static Class1110 smethod_2(Stream inputStream)
	{
		try
		{
			return new Class1110(inputStream);
		}
		catch (Exception1 exception)
		{
			throw new PptUnsupportedFormatException(exception.Message, exception);
		}
		catch (Exception exception2)
		{
			throw new PptReadException("Can't read MSCDFileSystem.", exception2);
		}
	}

	private void method_2()
	{
		Class1146 sumProps = null;
		if (class857_0.SummaryInformationStream != null)
		{
			Stream stream = new MemoryStream(class857_0.SummaryInformationStream);
			sumProps = new Class1146(stream);
			stream.Close();
		}
		Class1146 docProps = null;
		if (class857_0.DocumentSummaryInformationStream != null)
		{
			Stream stream = new MemoryStream(class857_0.DocumentSummaryInformationStream);
			docProps = new Class1146(stream);
			stream.Close();
		}
		Class60 @class = new Class60(docProps, sumProps);
		class857_0.DocumentProperties = @class;
		IDocumentProperties documentProperties = presentation_0.DocumentProperties;
		documentProperties.Author = @class.Author;
		documentProperties.Category = @class.Category;
		documentProperties.Comments = @class.Comments;
		documentProperties.Company = @class.Company;
		documentProperties.CreatedTime = @class.CreatedTime;
		documentProperties.Keywords = @class.Keywords;
		documentProperties.LastPrinted = @class.LastPrinted;
		documentProperties.LastSavedBy = @class.LastSavedBy;
		documentProperties.LastSavedTime = @class.LastSavedTime;
		documentProperties.Manager = @class.Manager;
		documentProperties.NameOfApplication = @class.NameOfApplication;
		documentProperties.RevisionNumber = @class.RevisionNumber;
		documentProperties.Subject = @class.Subject;
		documentProperties.ApplicationTemplate = @class.Template;
		documentProperties.Title = @class.Title;
		documentProperties.TotalEditingTime = @class.TotalEditingTime;
		for (int i = 0; i < @class.Count; i++)
		{
			string propertyName = @class.GetPropertyName(i);
			documentProperties[propertyName] = @class[propertyName];
		}
	}

	private void method_3()
	{
		if (presentation_0 == null)
		{
			throw new ArgumentNullException();
		}
		if (class857_0.DocumentContainer == null && presentation_0.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
		{
			throw new Exception("Presentation.IsOnlyDocumentPropertiesLoaded is true that mean only document properties of this presentation are loaded. Check Presentation.LoadOptions.OnlyLoadDocumentProperties property value.");
		}
		Class2864 documentAtom = class857_0.DocumentContainer.DocumentAtom;
		SlideSize domSlideSize = (SlideSize)presentation_0.SlideSize;
		Class232.smethod_9(documentAtom, domSlideSize);
		presentation_0.PPTXUnsupportedProps.NotesSize = new SizeF((float)documentAtom.NotesSize.Width / 8f, (float)documentAtom.NotesSize.Height / 8f);
		method_4();
		method_5();
		method_6();
		method_7();
		Class881.smethod_0(presentation_0.CustomData, class857_0.DocumentContainer.DocInfoList.ProgTags);
	}

	private void method_4()
	{
		try
		{
			if (!class857_0.PicturesStream.HaveData)
			{
				return;
			}
			List<Guid> list = new List<Guid>();
			Class2688 documentContainer = class857_0.DocumentContainer;
			Class2644 officeArtDgg = documentContainer.DrawingGroup.OfficeArtDgg;
			if (officeArtDgg != null && officeArtDgg.BlipStore != null)
			{
				Class2640 blipStore = officeArtDgg.BlipStore;
				int instance = blipStore.Instance;
				if (blipStore.Records.Count != instance)
				{
					throw new PptCorruptFileException("<!> Illegal count of images in blip store!!!");
				}
				for (int i = 0; i < instance; i++)
				{
					try
					{
						if (!(blipStore.Records[i] is Class2638 @class))
						{
							continue;
						}
						uint foDelay = @class.FoDelay;
						_ = @class.Size;
						if (class857_0.PicturesStream.method_6(foDelay) is Class2629 class2)
						{
							class2.uint_0 = @class.FoDelay;
							PPImage pPImage = method_18(class2);
							class857_0.PictureIdToPPImage.Add(i + 1, pPImage);
							list.Add(new Guid(@class.RgbUid));
							@class.Size = (uint)(class2.vmethod_2() + 8);
							Class276 pPTUnsupportedProps = pPImage.PPTUnsupportedProps;
							pPTUnsupportedProps.OfficeArtFBSE_RgbUid = @class.RgbUid;
							if (!(class2 is Class2637))
							{
								Class1165.smethod_27(list[list.Count - 1] == class2.RgbUid, "Guid: " + list[list.Count - 1].ToString() + " != Guid: " + class2.RgbUid.ToString());
							}
							pPTUnsupportedProps.OfficeArtFBSE_Tag = @class.Tag;
						}
					}
					catch (Exception ex)
					{
						Class1165.smethod_28(ex);
					}
				}
			}
			class857_0.ImagesGuids = list.ToArray();
		}
		catch (Exception ex2)
		{
			Class1165.smethod_28(ex2);
		}
	}

	private void method_5()
	{
		Class2730 progTags = class857_0.DocumentContainer.DocInfoList.ProgTags;
		if (progTags == null)
		{
			return;
		}
		Class2683 pP9DocBinaryTagExtension = progTags.PP9DocBinaryTagExtension;
		if (pP9DocBinaryTagExtension == null)
		{
			return;
		}
		Class2701 blipCollectionContainer = pP9DocBinaryTagExtension.BlipCollectionContainer;
		if (blipCollectionContainer != null)
		{
			int num = 0;
			Class2876[] rgBlipEntityAtom = blipCollectionContainer.RgBlipEntityAtom;
			foreach (Class2876 @class in rgBlipEntityAtom)
			{
				class857_0.PictureBulletIdToPPImage.Add(num++, method_18(@class.Blip));
			}
		}
	}

	private void method_6()
	{
		Class2706 fontCollection = class857_0.DocumentContainer.DocumentTextInfo.FontCollection;
		Class48 @class = Class53.smethod_2(class857_0);
		for (int i = 0; i < fontCollection.Records.Count; i++)
		{
			if (fontCollection.Records[i] is Class2879)
			{
				FontData fontData = new FontData((Class2879)fontCollection.Records[i]);
				@class.Add(Class48.smethod_1(fontData.FontName), fontData, noExistsCheck: true, i);
			}
		}
	}

	private void method_7()
	{
		TextStyle textStyle = (TextStyle)presentation_0.DefaultTextStyle;
		Class2894[] array = new Class2894[9];
		class857_0.PptDefaultTextMasterStyleList = array;
		for (int i = 0; i < 9; i++)
		{
			if (i != 3)
			{
				array[i] = new Class2894();
				array[i].method_1((Enum449)i, defaultStyle: true);
			}
		}
		Class2894 textMasterStyleAtom = class857_0.DocumentContainer.DocumentTextInfo.TextMasterStyleAtom;
		if (array != null)
		{
			array[4] = textMasterStyleAtom;
		}
		Class1070.smethod_2(textStyle, textMasterStyleAtom, class857_0);
		Class1070.smethod_3(TextStyle.textStyle_0, textStyle);
		Class2909 @class = class857_0.DocumentContainer.DocumentTextInfo.TextCFDefaultsAtom;
		if (@class == null)
		{
			@class = new Class2909();
			@class.method_1();
		}
		Class2908 class2 = class857_0.DocumentContainer.DocumentTextInfo.TextPFDefaultsAtom;
		if (class2 == null)
		{
			class2 = new Class2908();
			class2.method_1();
		}
		Class1070.smethod_1(textStyle, 0, class2.ParagraphFormat, @class.CharFormat, class857_0);
	}

	private void method_8()
	{
		Class2699 exObjList = class857_0.DocumentContainer.ExObjList;
		Class1144 hyperLinks = class857_0.DocumentProperties.HyperLinks;
		if (exObjList == null || hyperLinks == null)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < exObjList.Records.Count; i++)
		{
			if (exObjList.Records[i] is Class2694 @class)
			{
				if (@class.Records.Count == 3 && @class.Records[2] is Class2843 && hyperLinks.Links.Count > num)
				{
					((Class2843)@class.Records[2]).String = hyperLinks.Links[num].Url;
				}
				else if (@class.Records.Count == 2 && hyperLinks.Links.Count > num)
				{
					@class.Records.Add(new Class2843(hyperLinks.Links[num].Url, 3));
				}
				num++;
			}
		}
	}

	private void method_9()
	{
		uint notesMasterPersistIdRef = class857_0.DocumentContainer.DocumentAtom.NotesMasterPersistIdRef;
		Class2720 @class = (Class2720)class857_0.PowerPointDocumentStream.method_10(notesMasterPersistIdRef);
		if (@class != null)
		{
			Class206.smethod_0(@class, class857_0);
		}
	}

	private void method_10()
	{
		List<Class2855> list = class857_0.DocumentContainer.MasterList.ContentRecords.method_10();
		foreach (Class2855 item in list)
		{
			Class2623 @class = class857_0.PowerPointDocumentStream.method_10(item.PersistIdRef);
			if (@class is Class2718)
			{
				class857_0.MasterRefsList.Add(item.PersistIdRef);
				Class2718 masterContainer = (Class2718)@class;
				MasterSlide value = Class1057.smethod_0(masterContainer, class857_0);
				((MasterSlideCollection)presentation_0.Masters).Add(value);
			}
			else if (@class is Class2719)
			{
				Class2719 titleMasterSlideContainer = (Class2719)@class;
				LayoutSlide layoutSlide = Class1055.smethod_0(titleMasterSlideContainer, class857_0);
				layoutSlide.PPTUnsupportedProps.IsLayoutLoadedAsTitleMasterSlide = true;
			}
		}
		if (presentation_0.Masters.Count > 0)
		{
			MasterThemeManager masterThemeManager = (MasterThemeManager)presentation_0.Masters[0].ThemeManager;
			IMasterTheme masterThemeEffective = masterThemeManager.MasterThemeEffective;
			presentation_0.method_20(masterThemeEffective);
		}
	}

	private void method_11()
	{
		if (class857_0.DocumentContainer.SlideList == null)
		{
			return;
		}
		List<Class2855> list = class857_0.DocumentContainer.SlideList.ContentRecords.method_10();
		foreach (Class2855 item in list)
		{
			Class2623 @class = class857_0.PowerPointDocumentStream.method_10(item.PersistIdRef);
			if (@class is Class2719)
			{
				Class2719 class2 = (Class2719)@class;
				presentation_0.PPTXUnsupportedProps.method_1(class2.SlideId - 1);
				Slide slide = Class1065.smethod_0(class2, class857_0);
				((SlideCollection)presentation_0.Slides).Add(slide);
				class857_0.DomSlideToSlideContainer.Add(slide, class2);
				Class2720 class3 = class857_0.PowerPointDocumentStream.method_17(slide.BaseSlidePPTUnsupportedProps.SlideId);
				if (class3 != null)
				{
					slide.method_18(Class1059.smethod_0(slide, class3, class857_0.LastAddedSlideContext));
				}
			}
		}
		presentation_0.PPTXUnsupportedProps.method_0();
	}

	private void method_12()
	{
		HeaderFooterManager headerFooterManager = (HeaderFooterManager)presentation_0.HeaderFooterManager;
		Class2709 slideHF = class857_0.DocumentContainer.SlideHF;
		if (slideHF != null)
		{
			Class2881 hfAtom = slideHF.HfAtom;
			if (hfAtom.FHasDate)
			{
				headerFooterManager.IsDateTimeVisible = true;
				if (hfAtom.IsDateTimeFixed)
				{
					headerFooterManager.SetDateTimeText(slideHF.UserDate);
				}
			}
			if (hfAtom.FHasSlideNumber)
			{
				headerFooterManager.IsSlideNumberVisible = true;
			}
			if (hfAtom.FHasFooter)
			{
				headerFooterManager.IsFooterVisible = true;
				headerFooterManager.SetFooterText(slideHF.FooterText);
			}
		}
		for (int i = 0; i < presentation_0.Slides.Count; i++)
		{
			Slide slide = (Slide)presentation_0.Slides[i];
			Class2719 @class = class857_0.DomSlideToSlideContainer[slide];
			slideHF = @class.PerSlideHeadersFootersContainer;
			if (slideHF == null)
			{
				continue;
			}
			Class2881 hfAtom2 = slideHF.HfAtom;
			((HeaderFooterManager)presentation_0.HeaderFooterManager).method_8(slide, PlaceholderType.DateAndTime, hfAtom2.FHasDate);
			if (hfAtom2.FHasDate && slide.method_5(PlaceholderType.DateAndTime) is AutoShape autoShape)
			{
				if (hfAtom2.IsDateTimeFixed)
				{
					autoShape.AddTextFrame(slideHF.UserDate).Paragraphs[0].Portions[0].RemoveField();
				}
				else
				{
					autoShape.AddTextFrame(DateTime.Now.ToShortDateString()).Paragraphs[0].Portions[0].AddField(FieldType.DateTime1);
				}
			}
			((HeaderFooterManager)presentation_0.HeaderFooterManager).method_8(slide, PlaceholderType.SlideNumber, hfAtom2.FHasSlideNumber);
			if (hfAtom2.FHasSlideNumber && slide.method_5(PlaceholderType.SlideNumber) is AutoShape autoShape2)
			{
				autoShape2.AddTextFrame((i + 1).ToString()).Paragraphs[0].Portions[0].AddField(FieldType.SlideNumber);
			}
			((HeaderFooterManager)presentation_0.HeaderFooterManager).method_8(slide, PlaceholderType.Footer, hfAtom2.FHasFooter);
			if (hfAtom2.FHasFooter && slide.method_5(PlaceholderType.Footer) is AutoShape autoShape3)
			{
				autoShape3.AddTextFrame(slideHF.FooterText);
			}
		}
	}

	private void method_13()
	{
		if (class857_0.DocumentContainer.DocInfoList.VBAInfo != null && class857_0.PowerPointDocumentStream.method_10(class857_0.DocumentContainer.DocInfoList.VBAInfo.VbaInfoAtom.PersistIdRef) is Class2771 @class)
		{
			using MemoryStream inputStream = new MemoryStream(@class.Data);
			Class1110 fileSystem = smethod_2(inputStream);
			class857_0.DomPresentation.VbaProjectRootStorage = new Class3542(fileSystem);
			class857_0.DomPresentation.VbaProject = new VbaProject(class857_0.DomPresentation.VbaProjectRootStorage);
		}
	}

	private void method_14()
	{
		Class277 pPTUnsupportedProps = presentation_0.PPTUnsupportedProps;
		Class2721 powerPointDocumentStream = class857_0.PowerPointDocumentStream;
		pPTUnsupportedProps.HandoutContainer = powerPointDocumentStream.HandoutContainer;
		Class2688 documentContainer = powerPointDocumentStream.DocumentContainer;
		pPTUnsupportedProps.DocumentContainer_DocumentAtom_ServerZoom = documentContainer.DocumentAtom.ServerZoom;
		pPTUnsupportedProps.DocumentContainer_DocumentAtom_FSaveWithFonts = documentContainer.DocumentAtom.FSaveWithFonts;
		pPTUnsupportedProps.DocumentContainer_DocumentAtom_FRightToLeft = documentContainer.DocumentAtom.FRightToLeft;
		pPTUnsupportedProps.DocumentContainer_DocumentAtom_FShowComments = documentContainer.DocumentAtom.FShowComments;
		pPTUnsupportedProps.DocumentContainer_DocumentTextInfo_Kinsoku = documentContainer.DocumentTextInfo.Kinsoku;
		pPTUnsupportedProps.DocumentContainer_DocumentTextInfo_DefaultRulerAtom = documentContainer.DocumentTextInfo.DefaultRulerAtom;
		pPTUnsupportedProps.DocumentContainer_DocumentTextInfo_TextSIDefaultsAtom = documentContainer.DocumentTextInfo.TextSIDefaultsAtom;
		if (documentContainer.SoundCollection != null)
		{
			pPTUnsupportedProps.DocumentContainer_SoundCollection_UnusedSounds = documentContainer.SoundCollection.method_6();
		}
		pPTUnsupportedProps.DocumentContainer_DrawingGroup_OfficeArtDgg_DrawingPrimaryOptions = documentContainer.DrawingGroup.OfficeArtDgg.DrawingPrimaryOptions;
		pPTUnsupportedProps.DocumentContainer_DrawingGroup_OfficeArtDgg_DrawingTertiaryOptions = documentContainer.DrawingGroup.OfficeArtDgg.DrawingTertiaryOptions;
		pPTUnsupportedProps.DocumentContainer_DrawingGroup_OfficeArtDgg_ColorMRU = documentContainer.DrawingGroup.OfficeArtDgg.ColorMRU;
		pPTUnsupportedProps.DocumentContainer_DrawingGroup_OfficeArtDgg_SplitColors = documentContainer.DrawingGroup.OfficeArtDgg.SplitColors;
		if (documentContainer.DocInfoList != null)
		{
			pPTUnsupportedProps.DocumentContainer_DocInfoList_NormalViewSetInfo = documentContainer.DocInfoList.NormalViewSetInfo;
			pPTUnsupportedProps.DocumentContainer_DocInfoList_NotesTextViewInfo = documentContainer.DocInfoList.NotesTextViewInfo;
			pPTUnsupportedProps.DocumentContainer_DocInfoList_OutlineViewInfo = documentContainer.DocInfoList.OutlineViewInfo;
			pPTUnsupportedProps.DocumentContainer_DocInfoList_SlideViewInfo = documentContainer.DocInfoList.SlideViewInfo;
			pPTUnsupportedProps.DocumentContainer_DocInfoList_NotesViewInfo = documentContainer.DocInfoList.NotesViewInfo;
			pPTUnsupportedProps.DocumentContainer_DocInfoList_SorterViewInfo = documentContainer.DocInfoList.SorterViewInfo;
		}
		if (documentContainer.DocInfoList != null && documentContainer.DocInfoList.ProgTags != null)
		{
			if (documentContainer.DocInfoList.ProgTags.PP9DocBinaryTagExtension != null)
			{
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP9DocBinaryTagExtension_TextDefaultsAtom = documentContainer.DocInfoList.ProgTags.PP9DocBinaryTagExtension.TextDefaultsAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP9DocBinaryTagExtension_KinsokuContainer = documentContainer.DocInfoList.ProgTags.PP9DocBinaryTagExtension.KinsokuContainer;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP9DocBinaryTagExtension_PresAdvisorFlagsAtom = documentContainer.DocInfoList.ProgTags.PP9DocBinaryTagExtension.PresAdvisorFlagsAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP9DocBinaryTagExtension_EnvelopeDataAtom = documentContainer.DocInfoList.ProgTags.PP9DocBinaryTagExtension.EnvelopeDataAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP9DocBinaryTagExtension_EnvelopeFlagsAtom = documentContainer.DocInfoList.ProgTags.PP9DocBinaryTagExtension.EnvelopeFlagsAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP9DocBinaryTagExtension_HtmlDocInfoAtom = documentContainer.DocInfoList.ProgTags.PP9DocBinaryTagExtension.HtmlDocInfoAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP9DocBinaryTagExtension_HtmlPublishInfoAtom = documentContainer.DocInfoList.ProgTags.PP9DocBinaryTagExtension.HtmlPublishInfoAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP9DocBinaryTagExtension_RgBroadcastDocInfo9 = documentContainer.DocInfoList.ProgTags.PP9DocBinaryTagExtension.RgBroadcastDocInfo9;
			}
			if (documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension != null)
			{
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_FontCollectionContainer = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.FontCollectionContainer;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_RgTextMasterStyle10 = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.RgTextMasterStyle10;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_TextDefaultsAtom = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.TextDefaultsAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_GridSpacingAtom = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.GridSpacingAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_FontEmbedFlagsAtom = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.FontEmbedFlagsAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_CopyrightAtom = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.CopyrightAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_KeywordsAtom = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.KeywordsAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_FilterPrivacyFlagsAtom = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.FilterPrivacyFlagsAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_OutlineTextPropsContainer = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.OutlineTextPropsContainer;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_DocToolbarStatesAtom = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.DocToolbarStatesAtom;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_SlideListTableContainer = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.SlideListTableContainer;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_RgDiffTree10Container = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.RgDiffTree10Container;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP10DocBinaryTagExtension_PhotoAlbumInfoAtom = documentContainer.DocInfoList.ProgTags.PP10DocBinaryTagExtension.PhotoAlbumInfoAtom;
			}
			if (documentContainer.DocInfoList.ProgTags.PP11DocBinaryTagExtension != null)
			{
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP11DocBinaryTagExtension_SmartTagStore11 = documentContainer.DocInfoList.ProgTags.PP11DocBinaryTagExtension.SmartTagStore11;
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP11DocBinaryTagExtension_OutlineTextProps = documentContainer.DocInfoList.ProgTags.PP11DocBinaryTagExtension.OutlineTextProps;
			}
			if (documentContainer.DocInfoList.ProgTags.PP12DocBinaryTagExtension != null)
			{
				pPTUnsupportedProps.DocumentContainer_DocInfoList_ProgTags_PP12DocBinaryTagExtension_RtDocFlagsAtom = documentContainer.DocInfoList.ProgTags.PP12DocBinaryTagExtension.RtDocFlagsAtom;
			}
		}
		pPTUnsupportedProps.DocumentContainer_NotesHF = documentContainer.NotesHF;
		pPTUnsupportedProps.DocumentContainer_Summary = documentContainer.Summary;
		pPTUnsupportedProps.DocumentContainer_DocRoutingSlipAtom = documentContainer.DocRoutingSlipAtom;
		pPTUnsupportedProps.DocumentContainer_PrintOptionsAtom = documentContainer.PrintOptionsAtom;
		pPTUnsupportedProps.DocumentContainer_RtCustomTableStylesAtom = documentContainer.RtCustomTableStylesAtom;
	}

	private void method_15()
	{
		method_16();
		presentation_0.PPTXUnsupportedProps.TableStyles = new Class146(presentation_0);
		method_17();
	}

	private void method_16()
	{
		try
		{
			SortedList sortedList = new SortedList();
			Class2721 powerPointDocumentStream = class857_0.PowerPointDocumentStream;
			for (int i = 0; i < powerPointDocumentStream.Records.Count; i++)
			{
				if (powerPointDocumentStream.Records[i] is Class2639 @class && @class.method_1(1036) is Class2714 class2)
				{
					uint drawingId = class2.OfficeArtDg.DrawingData.DrawingId;
					sortedList[drawingId] = null;
				}
			}
			Class2744 drawingGroup = class857_0.DocumentContainer.DrawingGroup.OfficeArtDgg.DrawingGroup;
			drawingGroup.CdgSaved = (uint)sortedList.Count;
			for (int j = 0; j < drawingGroup.Rgidcl.Count; j++)
			{
				Class2947 class3 = drawingGroup.Rgidcl[j];
				if (class3 != null && class3.Dgid != 0 && !sortedList.ContainsKey(class3.Dgid))
				{
					class3.Dgid = 0u;
				}
			}
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
	}

	private void method_17()
	{
		for (int i = 0; i < class857_0.InternalHyperlinks.Count; i++)
		{
			Hyperlink hyperlink = class857_0.InternalHyperlinks[i];
			if (hyperlink.InternalUrl == null)
			{
				continue;
			}
			int j;
			for (j = 0; j < hyperlink.InternalUrl.Length && hyperlink.InternalUrl[j] >= '0' && hyperlink.InternalUrl[j] <= '9'; j++)
			{
			}
			string internalUrl = hyperlink.InternalUrl;
			IBaseSlide baseSlide;
			if (j < internalUrl.Length)
			{
				internalUrl = internalUrl.Substring(0, j);
				if (hyperlink.InternalUrl[j] == '.')
				{
					baseSlide = (BaseSlide)presentation_0.Slides[int.Parse(internalUrl) - 1];
				}
				else
				{
					baseSlide = class857_0.method_3(uint.Parse(internalUrl));
					if (baseSlide == null)
					{
						int k;
						for (k = j + 1; k < hyperlink.InternalUrl.Length && hyperlink.InternalUrl[k] >= '0' && hyperlink.InternalUrl[k] <= '9'; k++)
						{
						}
						internalUrl = hyperlink.InternalUrl;
						if (k < internalUrl.Length)
						{
							internalUrl = internalUrl.Substring(j + 1, k - (j + 1));
							int num = int.Parse(internalUrl);
							if (presentation_0.Slides.Count >= num)
							{
								baseSlide = (BaseSlide)presentation_0.Slides[num - 1];
							}
						}
					}
				}
			}
			else
			{
				baseSlide = class857_0.method_3(uint.Parse(internalUrl));
			}
			hyperlink.InternalUrl = null;
			hyperlink.PPTXUnsupportedProps.TargetSlide = (ISlide)baseSlide;
		}
	}

	private PPImage method_18(Class2628 blip)
	{
		if (blip is Class2631)
		{
			return (PPImage)presentation_0.Images.AddImage(new Bitmap(new MemoryStream(((Class2630)blip).vmethod_6())));
		}
		if (blip is Class2630)
		{
			return (PPImage)presentation_0.Images.AddImage(Image.FromStream(new MemoryStream(((Class2630)blip).BLIPFileData)));
		}
		if (blip is Class2634)
		{
			return (PPImage)presentation_0.Images.AddImage(Image.FromStream(new MemoryStream(((Class2634)blip).vmethod_6())));
		}
		if (!(blip is Class2637))
		{
			throw new ArgumentException();
		}
		return (PPImage)presentation_0.Images.AddImage(new Bitmap(new MemoryStream(((Class2637)blip).vmethod_6())));
	}
}
