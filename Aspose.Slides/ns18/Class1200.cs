using System.Drawing;
using System.Xml;
using Aspose.Slides;
using ns16;
using ns24;
using ns53;
using ns55;
using ns56;

namespace ns18;

internal class Class1200 : Class1188
{
	private static readonly string string_0 = "Generated by Aspose.Slides for .NET ";

	internal void method_5(IPresentation presentation)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType != XmlNodeType.Element || !(base.XmlPartReader.LocalName == "presentation"))
			{
				continue;
			}
			Class1348 relationshipsOfCurrentPartEntry = base.DeserializationContext.RelationshipsOfCurrentPartEntry;
			Class2220 @class = new Class2220(base.XmlPartReader);
			Class350 pPTXUnsupportedProps = ((Presentation)presentation).PPTXUnsupportedProps;
			smethod_0(presentation, @class);
			Class883.smethod_0(((Presentation)presentation).FontsManagerInternal, @class.EmbeddedFontLst, base.DeserializationContext);
			if (@class.SldMasterIdLst != null)
			{
				Class2256[] sldMasterIdList = @class.SldMasterIdLst.SldMasterIdList;
				foreach (Class2256 class2 in sldMasterIdList)
				{
					string r_Id = class2.R_Id;
					Class1342 targetPart = relationshipsOfCurrentPartEntry[r_Id].TargetPart;
					Class1195 class3 = new Class1195(targetPart, base.DeserializationContext);
					IMasterSlide masterSlide = ((MasterSlideCollection)presentation.Masters).method_0();
					class3.method_7(masterSlide);
					((MasterSlide)masterSlide).PPTXUnsupportedProps.SlideId = class2.Id;
					pPTXUnsupportedProps.method_3(class2.Id);
					base.DeserializationContext.SlidePartPathToSlide.Add(targetPart.PartPath, masterSlide);
					((MasterSlide)masterSlide).PPTXUnsupportedProps.ExtensionListOfSlideIdListEntry = class2.ExtLst;
				}
			}
			if (@class.NotesMasterIdLst != null)
			{
				Class2243 notesMasterId = @class.NotesMasterIdLst.NotesMasterId;
				string r_Id2 = notesMasterId.R_Id;
				Class1342 targetPart2 = relationshipsOfCurrentPartEntry[r_Id2].TargetPart;
				Class1192 class4 = new Class1192(targetPart2, base.DeserializationContext);
				IMasterNotesSlide masterNotesSlide = ((Presentation)presentation).MasterNotesSlideManager.SetDefaultMasterNotesSlide();
				class4.method_7(masterNotesSlide);
				base.DeserializationContext.SlidePartPathToSlide.Add(targetPart2.PartPath, masterNotesSlide);
				((MasterNotesSlide)masterNotesSlide).PPTXUnsupportedProps.ExtensionListOfSlideIdListEntry = notesMasterId.ExtLst;
			}
			if (@class.HandoutMasterIdLst != null)
			{
				Class2237 handoutMasterId = @class.HandoutMasterIdLst.HandoutMasterId;
				string r_Id3 = handoutMasterId.R_Id;
				Class1342 targetPart3 = relationshipsOfCurrentPartEntry[r_Id3].TargetPart;
				Class1191 class5 = new Class1191(targetPart3, base.DeserializationContext);
				IMasterHandoutSlide masterHandoutSlide = ((Presentation)presentation).MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
				class5.method_7(masterHandoutSlide);
				base.DeserializationContext.SlidePartPathToSlide.Add(targetPart3.PartPath, masterHandoutSlide);
				((MasterHandoutSlide)masterHandoutSlide).PPTXUnsupportedProps.ExtensionListOfSlideIdListEntry = handoutMasterId.ExtLst;
			}
			if (@class.SldIdLst != null)
			{
				Class2252[] sldIdList = @class.SldIdLst.SldIdList;
				foreach (Class2252 class6 in sldIdList)
				{
					string r_Id4 = class6.R_Id;
					Class1342 targetPart4 = relationshipsOfCurrentPartEntry[r_Id4].TargetPart;
					Class1196 class7 = new Class1196(targetPart4, base.DeserializationContext);
					Class1347[] array = targetPart4.Relationships.method_0(Class1247.class1338_0);
					ILayoutSlide layout = (ILayoutSlide)base.DeserializationContext.SlidePartPathToSlide[array[0].Target];
					array[0].method_0();
					Slide slide = ((SlideCollection)presentation.Slides).method_1();
					class7.method_7(slide);
					slide.method_17(layout);
					((SlideCollection)presentation.Slides).Add(slide);
					Class1347[] array2 = targetPart4.Relationships.method_0(Class1246.class1338_0);
					if (array2 != null && array2.Length > 0)
					{
						Class1342 targetPart5 = array2[0].TargetPart;
						Class1193 class8 = new Class1193(targetPart5, base.DeserializationContext);
						INotesSlide notesSlide = slide.AddNotesSlide();
						class8.method_7(notesSlide);
						base.DeserializationContext.SlidePartPathToSlide.Add(targetPart5.PartPath, notesSlide);
					}
					slide.PPTXUnsupportedProps.SlideId = class6.Id;
					pPTXUnsupportedProps.method_1(class6.Id);
					base.DeserializationContext.SlidePartPathToSlide.Add(targetPart4.PartPath, slide);
					slide.PPTXUnsupportedProps.ExtensionListOfSlideIdListEntry = class6.ExtLst;
				}
			}
			Class994.smethod_0(presentation.SlideSize, @class.SldSz);
			Class937.smethod_0(presentation.CustomData, @class.CustDataLst, base.DeserializationContext);
			Class1003.smethod_0(presentation.DefaultTextStyle, @class.DefaultTextStyle, base.DeserializationContext);
			pPTXUnsupportedProps.ModifyVerifier.method_1(@class.ModifyVerifier);
		}
		method_2();
	}

	private static void smethod_0(IPresentation presentation, Class2220 presElementData)
	{
		Class350 pPTXUnsupportedProps = ((Presentation)presentation).PPTXUnsupportedProps;
		pPTXUnsupportedProps.NotesSize = new SizeF((float)presElementData.NotesSz.Cx, (float)presElementData.NotesSz.Cy);
		pPTXUnsupportedProps.SmartTags = presElementData.SmartTags;
		pPTXUnsupportedProps.CustomShowList = presElementData.CustShowLst;
		pPTXUnsupportedProps.PhotoAlbumInformation = presElementData.PhotoAlbum;
		pPTXUnsupportedProps.KinsokuSettings = presElementData.Kinsoku;
		pPTXUnsupportedProps.ExtensionList = presElementData.ExtLst;
		pPTXUnsupportedProps.ServerZoom = presElementData.ServerZoom / 100f;
		pPTXUnsupportedProps.FirstSlideNumber = presElementData.FirstSlideNum;
		pPTXUnsupportedProps.ShowHeaderFooterOnTitles = presElementData.ShowSpecialPlsOnTitleSld;
		pPTXUnsupportedProps.RightToLeft = presElementData.Rtl;
		pPTXUnsupportedProps.RemovePersonalInfoOnSave = presElementData.RemovePersonalInfoOnSave;
		pPTXUnsupportedProps.CompatiblityMode = presElementData.CompatMode;
		pPTXUnsupportedProps.StrictFirstAndLastChars = presElementData.StrictFirstAndLastChars;
		pPTXUnsupportedProps.EmbedTrueTypeFonts = presElementData.EmbedTrueTypeFonts;
		pPTXUnsupportedProps.SaveSubsetFonts = presElementData.SaveSubsetFonts;
		pPTXUnsupportedProps.AutoCompressPictures = presElementData.AutoCompressPictures;
		pPTXUnsupportedProps.BookmarkIdSeed = (int)presElementData.BookmarkIdSeed;
	}

	internal void method_6(IPresentation presentation)
	{
		method_3();
		Class2220 @class = new Class2220();
		Class350 pPTXUnsupportedProps = ((Presentation)presentation).PPTXUnsupportedProps;
		Class937.smethod_1(presentation.CustomData, @class.delegate2434_0, base.SerializationContext);
		if (presentation.Masters.Count > 0)
		{
			Class2255 class2 = @class.delegate2512_0();
			foreach (IMasterSlide master in presentation.Masters)
			{
				Class2256 class3 = class2.delegate2515_0();
				class3.Id = ((MasterSlide)master).PPTXUnsupportedProps.SlideId;
				class3.R_Id = base.Part.Relationships.method_1(base.SerializationContext.SlideToSlidePart[master]).Id;
				class3.delegate1535_0(((MasterSlide)master).PPTXUnsupportedProps.ExtensionListOfSlideIdListEntry);
			}
		}
		if (presentation.MasterNotesSlideManager.MasterNotesSlide != null)
		{
			Class2242 class4 = @class.delegate2470_0();
			Class2243 class5 = class4.delegate2473_0();
			class5.R_Id = base.Part.Relationships.method_1(base.SerializationContext.SlideToSlidePart[presentation.MasterNotesSlideManager.MasterNotesSlide]).Id;
			class5.delegate1535_0(((MasterNotesSlide)presentation.MasterNotesSlideManager.MasterNotesSlide).PPTXUnsupportedProps.ExtensionListOfSlideIdListEntry);
		}
		if (presentation.MasterHandoutSlideManager.MasterHandoutSlide != null)
		{
			Class2236 class6 = @class.delegate2452_0();
			Class2237 class7 = class6.delegate2455_0();
			class7.R_Id = base.Part.Relationships.method_1(base.SerializationContext.SlideToSlidePart[presentation.MasterHandoutSlideManager.MasterHandoutSlide]).Id;
			class7.delegate1535_0(((MasterHandoutSlide)presentation.MasterHandoutSlideManager.MasterHandoutSlide).PPTXUnsupportedProps.ExtensionListOfSlideIdListEntry);
		}
		if (presentation.Slides.Count > 0)
		{
			Class2251 class8 = @class.delegate2500_0();
			foreach (Slide slide in presentation.Slides)
			{
				Class2252 class9 = class8.delegate2503_0();
				class9.Id = slide.PPTXUnsupportedProps.SlideId;
				class9.R_Id = base.Part.Relationships.method_1(base.SerializationContext.SlideToSlidePart[slide]).Id;
				class9.delegate1535_0(slide.PPTXUnsupportedProps.ExtensionListOfSlideIdListEntry);
			}
		}
		Class883.smethod_2(((Presentation)presentation).FontsManagerInternal, @class.delegate2440_0, base.SerializationContext);
		Class994.smethod_1(presentation.SlideSize, @class.delegate2521_0);
		Class1003.smethod_1(presentation.DefaultTextStyle, @class.delegate1741_0, base.SerializationContext);
		pPTXUnsupportedProps.ModifyVerifier.Write(@class.delegate2469_0);
		smethod_1(presentation, @class);
		base.XmlPartWriter.WriteComment(string_0 + "15.1.0.0");
		@class.vmethod_4(null, base.XmlPartWriter, "presentation");
		method_4();
	}

	private static void smethod_1(IPresentation presentation, Class2220 presElementData)
	{
		Class350 pPTXUnsupportedProps = ((Presentation)presentation).PPTXUnsupportedProps;
		presElementData.NotesSz.Cx = pPTXUnsupportedProps.NotesSize.Width;
		presElementData.NotesSz.Cy = pPTXUnsupportedProps.NotesSize.Height;
		presElementData.delegate304_0(pPTXUnsupportedProps.SmartTags);
		presElementData.delegate304_1(pPTXUnsupportedProps.CustomShowList);
		presElementData.delegate304_2(pPTXUnsupportedProps.PhotoAlbumInformation);
		presElementData.delegate304_3(pPTXUnsupportedProps.KinsokuSettings);
		presElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		presElementData.ServerZoom = pPTXUnsupportedProps.ServerZoom * 100f;
		presElementData.FirstSlideNum = pPTXUnsupportedProps.FirstSlideNumber;
		presElementData.ShowSpecialPlsOnTitleSld = pPTXUnsupportedProps.ShowHeaderFooterOnTitles;
		presElementData.Rtl = pPTXUnsupportedProps.RightToLeft;
		presElementData.RemovePersonalInfoOnSave = pPTXUnsupportedProps.RemovePersonalInfoOnSave;
		presElementData.CompatMode = pPTXUnsupportedProps.CompatiblityMode;
		presElementData.StrictFirstAndLastChars = pPTXUnsupportedProps.StrictFirstAndLastChars;
		presElementData.EmbedTrueTypeFonts = pPTXUnsupportedProps.EmbedTrueTypeFonts;
		presElementData.SaveSubsetFonts = pPTXUnsupportedProps.SaveSubsetFonts;
		presElementData.AutoCompressPictures = pPTXUnsupportedProps.AutoCompressPictures;
		presElementData.BookmarkIdSeed = (uint)pPTXUnsupportedProps.BookmarkIdSeed;
	}

	public Class1200(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1200(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
