using System;
using Aspose.Slides;
using ns16;
using ns24;
using ns46;
using ns53;
using ns55;
using ns56;
using ns7;

namespace ns18;

internal class Class936
{
	internal const string string_0 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";

	internal const string string_1 = "http://schemas.openxmlformats.org/presentationml/2006/main";

	public static void smethod_0(IControl control, Class1778 AlternateContentOf_controlElementData, Class1030 slideDeserializationContext)
	{
		Class2228 @class = ((!Class1120.list_0.Contains("urn:schemas-microsoft-com:vml") || AlternateContentOf_controlElementData.Choice_v == null) ? AlternateContentOf_controlElementData.Fallback : AlternateContentOf_controlElementData.Choice_v);
		Class333 pPTXUnsupportedProps = ((Control)control).PPTXUnsupportedProps;
		Class1341 deserializationContext = slideDeserializationContext.DeserializationContext;
		string spid = @class.Spid;
		if (!string.IsNullOrEmpty(spid))
		{
			slideDeserializationContext.method_0(spid, control);
		}
		control.Name = @class.Name;
		pPTXUnsupportedProps.ShowAsIcon = @class.ShowAsIcon;
		string r_Id = @class.R_Id;
		if (!string.IsNullOrEmpty(r_Id))
		{
			Class1342 targetPart = deserializationContext.RelationshipsOfCurrentPartEntry[r_Id].TargetPart;
			Class1189 class2 = new Class1189(targetPart, deserializationContext);
			class2.method_5(control);
		}
		Class2004 pic = @class.Pic;
		if (pic != null)
		{
			Class1810 blipFill = pic.BlipFill;
			Class974.smethod_0(pPTXUnsupportedProps.SubstituteImage, blipFill, deserializationContext);
			Class1921 spPr = pic.SpPr;
			if (spPr != null)
			{
				Class154 class3 = new Class154();
				Class1021.smethod_1(class3, spPr.Xfrm);
				((Control)control).method_0((float)class3.X, (float)class3.Y, (float)class3.Width, (float)class3.Height, class3.FlipH, class3.FlipV, class3.Rotation);
			}
		}
		pPTXUnsupportedProps.ImageHeight = @class.ImgH;
		pPTXUnsupportedProps.ImageWidth = @class.ImgW;
	}

	public static void smethod_1(IControl control, Class1778 AlternateContentOf_controlElementData, Class1031 slideSerializationContext)
	{
		Class333 pPTXUnsupportedProps = ((Control)control).PPTXUnsupportedProps;
		Class1346 serializationContext = slideSerializationContext.SerializationContext;
		Class1347 @class = null;
		if (pPTXUnsupportedProps.ActiveXControlBinary != null || (control.Properties != null && control.Properties.Count > 0) || pPTXUnsupportedProps.ClassId != Guid.Empty)
		{
			Class1342 class2 = serializationContext.Package.method_4("/ppt/activeX/activeX{0}.xml", serializationContext.method_18, new Class1261());
			Class1189 class3 = new Class1189(class2, serializationContext);
			class3.method_6(control);
			@class = serializationContext.RelationshipsOfCurrentPartEntry.method_4(class2);
		}
		if (smethod_2())
		{
			Class2228 class4 = AlternateContentOf_controlElementData.delegate2422_1();
			class4.Name = control.Name;
			class4.ImgH = (long)Math.Round(pPTXUnsupportedProps.ImageHeight * 12700.0);
			class4.ImgW = (long)Math.Round(pPTXUnsupportedProps.ImageWidth * 12700.0);
			class4.R_Id = @class.Id;
			class4.Spid = slideSerializationContext.method_2(control).ToString("D4");
		}
		Class2228 class5 = AlternateContentOf_controlElementData.delegate2422_0();
		class5.Name = control.Name;
		class5.ImgH = pPTXUnsupportedProps.ImageHeight;
		class5.ImgW = pPTXUnsupportedProps.ImageWidth;
		class5.R_Id = @class.Id;
		Class2004 class6 = class5.delegate1833_0();
		class6.NvPicPr.CNvPr.Id = 0u;
		class6.NvPicPr.CNvPr.Name = control.Name;
		class6.NvPicPr.CNvPicPr.delegate1573_0().NoChangeArrowheads = true;
		class6.NvPicPr.CNvPicPr.PicLocks.NoChangeShapeType = true;
		Class974.smethod_1(pPTXUnsupportedProps.SubstituteImage, class6.BlipFill, serializationContext);
		Class1921 spPr = class6.SpPr;
		Class1021.smethod_5(control.Frame, spPr.delegate1795_0());
		Class1908 class7 = (Class1908)spPr.delegate2773_2("prstGeom").Object;
		class7.Prst = ShapeType.Rectangle;
		spPr.delegate2773_1("noFill");
		spPr.delegate1504_0();
	}

	private static bool smethod_2()
	{
		return true;
	}
}
