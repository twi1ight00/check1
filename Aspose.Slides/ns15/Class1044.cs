using System.IO;
using Aspose.Slides;
using ns22;
using ns60;
using ns61;
using ns62;
using ns63;
using ns65;
using ns66;

namespace ns15;

internal class Class1044 : Class1043
{
	internal static void smethod_13(OleObjectFrame domShape, Class2670 pptOfficeArtSpContainer, Interface46 pptExContainer, Class2771 pptExStg, Class854 context)
	{
		if (pptOfficeArtSpContainer != null && pptOfficeArtSpContainer.ClientData != null && pptOfficeArtSpContainer.ClientData.ExObjRefAtom != null)
		{
			if (pptExStg == null)
			{
				throw new PptException("Frame is not an OleObjectFrame_PPT.");
			}
			Class1043.smethod_12(domShape, pptOfficeArtSpContainer, context);
			domShape.pictureFillFormat_0 = new PictureFillFormat(domShape);
			domShape.pictureFillFormat_0.PictureFillMode = PictureFillMode.Stretch;
			domShape.ObjectProgId = ((pptExContainer.ProgIdAtom != null) ? pptExContainer.ProgIdAtom.String : "");
			domShape.ObjectName = ((pptExContainer.MenuNameAtom != null) ? pptExContainer.MenuNameAtom.String : "");
			domShape.IsObjectIcon = pptExContainer.ExOleObjAtom.DrawAspect != 1;
			domShape.PPTUnsupportedProps.DocumentContainer_ExObjList_ExOleContainer_ExOleObjAtom_DrawAspect = pptExContainer.ExOleObjAtom.DrawAspect;
			domShape.PPTUnsupportedProps.DocumentContainer_ExObjList_ExOleContainer_ClipboardNameAtom_String = ((pptExContainer.ClipboardNameAtom != null) ? pptExContainer.ClipboardNameAtom.String : "");
			if (pptExContainer is Class2693)
			{
				domShape.ObjectData = pptExStg.Data;
			}
			else if (pptExContainer is Class2696)
			{
				Class2957 @class = new Class2957(pptExStg.Data);
				if (@class.OleStream != null)
				{
					Class2959 class2 = (Class2959)@class.OleStream.AbsoluteSourceMonikerStream.Data;
					domShape.string_6 = class2.UnicodePath;
					if (domShape.string_6 == null)
					{
						domShape.string_6 = class2.AnsiPath;
					}
					domShape.PPTUnsupportedProps.ExOleObjStg_OleCompount_OleStream_Clsid = @class.OleStream.Clsid;
				}
				domShape.IsExternal = true;
			}
			int pib = pptOfficeArtSpContainer.Pib;
			if (pib > 0 && context.DeserializationContext.PictureIdToPPImage.ContainsKey(pib))
			{
				domShape.pictureFillFormat_0.Picture.Image = context.DeserializationContext.PictureIdToPPImage[pib];
			}
			Class275 pPTUnsupportedProps = domShape.PPTUnsupportedProps;
			if (pptExContainer is Class2693 class3)
			{
				Class2693 class4 = class3;
				pPTUnsupportedProps.DocumentContainer_ExObjList_ExOleEmbedContainer_ExOleEmbedAtom_FCantLockServer = class4.ExOleEmbedAtom.FCantLockServer;
				pPTUnsupportedProps.DocumentContainer_ExObjList_ExOleEmbedContainer_ExOleEmbedAtom_FNoSizeToServer = class4.ExOleEmbedAtom.FNoSizeToServer;
				pPTUnsupportedProps.DocumentContainer_ExObjList_ExOleEmbedContainer_ExOleEmbedAtom_FIsTable = class4.ExOleEmbedAtom.FIsTable;
			}
			else if (pptExContainer is Class2696 class5)
			{
				Class2696 class6 = class5;
				pPTUnsupportedProps.DocumentContainer_ExObjList_ExOleLinkContainer_ExOleLinkAtom_OleUpdateMode = class6.ExOleLinkAtom.OleUpdateMode;
			}
			pPTUnsupportedProps.DocumentContainer_ExObjList_ExOleEmbedContainer_Metafile = pptExContainer.Metafile;
			return;
		}
		throw new PptException("Frame is not an OleObjectFrame_PPT.");
	}

	internal static uint smethod_14(OleObjectFrame domShape, Class856 context)
	{
		Class2699 @class = context.PptBinaryFile.PowerPointDocumentStream.DocumentContainer.method_12();
		Interface46 @interface = ((!domShape.IsObjectLink) ? ((Interface46)new Class2693()) : ((Interface46)new Class2696()));
		@class.Records.Add((Class2623)@interface);
		Class2771 class4;
		if (domShape.IsObjectLink)
		{
			Class2957 class2 = new Class2957();
			class2.OleStream.Flags = 1;
			class2.OleStream.AbsoluteSourceMonikerStream = new Class2960(new Class2959());
			Class2959 class3 = (Class2959)class2.OleStream.AbsoluteSourceMonikerStream.Data;
			class3.UnicodePath = domShape.string_6;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				class2.Write(memoryStream);
				class4 = new Class2771();
				class4.Data = memoryStream.ToArray();
			}
			class2.OleStream.Clsid = domShape.PPTUnsupportedProps.ExOleObjStg_OleCompount_OleStream_Clsid;
		}
		else
		{
			class4 = new Class2771();
			class4.Data = domShape.ObjectData;
		}
		class4.PersistId = context.PptBinaryFile.PowerPointDocumentStream.method_16(class4);
		Class2875 exOleObjAtom = @interface.ExOleObjAtom;
		exOleObjAtom.DrawAspect = ((domShape.PPTUnsupportedProps.DocumentContainer_ExObjList_ExOleContainer_ExOleObjAtom_DrawAspect > 0) ? domShape.PPTUnsupportedProps.DocumentContainer_ExObjList_ExOleContainer_ExOleObjAtom_DrawAspect : ((!domShape.IsObjectIcon) ? 1 : 4));
		exOleObjAtom.ObjType = (domShape.IsObjectLink ? Enum438.const_1 : Enum438.const_0);
		exOleObjAtom.ExObjId = @class.ExObjListAtom.ExObjIdSeed++;
		exOleObjAtom.SubType = smethod_15(domShape.ObjectProgId);
		Class275 pPTUnsupportedProps = domShape.PPTUnsupportedProps;
		exOleObjAtom.PersistIdRef = class4.PersistId;
		if (domShape.IsObjectLink)
		{
			Class2871 exOleLinkAtom = ((Class2696)@interface).ExOleLinkAtom;
			exOleLinkAtom.SlideIdRef = context.method_12(context.PptCurrentMasterOrSlideContainer.PersistId).SlideId;
			exOleLinkAtom.OleUpdateMode = pPTUnsupportedProps.DocumentContainer_ExObjList_ExOleLinkContainer_ExOleLinkAtom_OleUpdateMode;
		}
		else
		{
			Class2868 exOleEmbedAtom = ((Class2693)@interface).ExOleEmbedAtom;
			exOleEmbedAtom.ExColorFollow = pPTUnsupportedProps.DocumentContainer_ExObjList_ExOleEmbedContainer_ExOleEmbedAtom_ExColorFollow;
			exOleEmbedAtom.FCantLockServer = pPTUnsupportedProps.DocumentContainer_ExObjList_ExOleEmbedContainer_ExOleEmbedAtom_FCantLockServer;
			exOleEmbedAtom.FIsTable = pPTUnsupportedProps.DocumentContainer_ExObjList_ExOleEmbedContainer_ExOleEmbedAtom_FIsTable;
			exOleEmbedAtom.FNoSizeToServer = pPTUnsupportedProps.DocumentContainer_ExObjList_ExOleEmbedContainer_ExOleEmbedAtom_FNoSizeToServer;
		}
		@interface.MenuNameAtom.String = domShape.ObjectName;
		@interface.ProgIdAtom.String = domShape.ObjectProgId;
		@interface.ClipboardNameAtom.String = pPTUnsupportedProps.DocumentContainer_ExObjList_ExOleContainer_ClipboardNameAtom_String;
		return exOleObjAtom.ExObjId;
	}

	private static Enum424 smethod_15(string progId)
	{
		Enum424 result = Enum424.const_0;
		if (progId != null && !progId.Equals(string.Empty))
		{
			string text = progId.ToLower();
			if (text.IndexOf("word.document") == 0)
			{
				result = Enum424.const_2;
			}
			else if (text.IndexOf("excel.sheet") == 0)
			{
				result = Enum424.const_3;
			}
			else if (text.IndexOf("msgraph") == 0)
			{
				result = Enum424.const_4;
			}
			else if (text.IndexOf("ogrchart") == 0)
			{
				result = Enum424.const_5;
			}
			else if (text.IndexOf("msorgchart") == 0)
			{
				result = Enum424.const_5;
			}
			else if (text.IndexOf("orgpluswopx") == 0)
			{
				result = Enum424.const_5;
			}
			else if (text.IndexOf("equation") == 0)
			{
				result = Enum424.const_6;
			}
			else if (text.IndexOf("mswordart") == 0)
			{
				result = Enum424.const_7;
			}
			else if (text.IndexOf("soundrec") == 0)
			{
				result = Enum424.const_8;
			}
			else if (text.IndexOf("msproject") == 0)
			{
				result = Enum424.const_12;
			}
			else if (text.IndexOf("note") == 0)
			{
				result = Enum424.const_13;
			}
			else if (text.IndexOf("excel.chart") == 0)
			{
				result = Enum424.const_14;
			}
			else if (text.IndexOf("mplayer") == 0)
			{
				result = Enum424.const_15;
			}
			else if (text.IndexOf("midfile") == 0)
			{
				result = Enum424.const_15;
			}
			else if (text.IndexOf("avifile") == 0)
			{
				result = Enum424.const_15;
			}
			else if (text.IndexOf("wordpad") == 0)
			{
				result = Enum424.const_16;
			}
			else if (text.IndexOf("visio") == 0)
			{
				result = Enum424.const_17;
			}
			else if (text.IndexOf("word.opendocument") == 0)
			{
				result = Enum424.const_18;
			}
			else if (text.IndexOf("excel.opendocument") == 0)
			{
				result = Enum424.const_19;
			}
			return result;
		}
		return result;
	}
}
