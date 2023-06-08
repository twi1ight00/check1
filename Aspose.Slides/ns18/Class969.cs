using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using ns16;
using ns33;
using ns46;
using ns53;
using ns55;
using ns56;

namespace ns18;

internal class Class969
{
	internal static SortedList<string, object[]> sortedList_0;

	public static void smethod_0(OleObjectFrame oleFrame, Class1991 graphicFrameElementData, Class1030 slideDeserializationContext)
	{
		if (graphicFrameElementData == null)
		{
			return;
		}
		Class959.smethod_0(oleFrame, graphicFrameElementData, slideDeserializationContext);
		Class1352 oleObj = graphicFrameElementData.Graphic.GraphicData.OleObj;
		Class1367 @class = ((!Class1120.list_0.Contains("urn:schemas-microsoft-com:vml") || oleObj.Choice_v == null) ? oleObj.Fallback : oleObj.Choice_v);
		string spid = @class.Spid;
		if (spid != null && spid != "")
		{
			slideDeserializationContext.method_0(spid, oleFrame);
		}
		oleFrame.IsObjectIcon = @class.ShowAsIcon;
		if (@class.OleObject.Name == "link")
		{
			oleFrame.IsExternal = true;
			Class1369 class2 = (Class1369)@class.OleObject.Object;
			oleFrame.bool_3 = class2.UpdateAutomatic;
		}
		else
		{
			oleFrame.IsExternal = false;
			oleFrame.bool_3 = false;
		}
		oleFrame.ObjectName = @class.Name;
		string r_Id = @class.R_Id;
		oleFrame.ObjectProgId = @class.ProgId;
		if (!(r_Id != "*") || string.IsNullOrEmpty(r_Id))
		{
			return;
		}
		Class1347 class3 = slideDeserializationContext.DeserializationContext.RelationshipsOfCurrentPartEntry[r_Id];
		if (class3.TargetMode == Enum180.const_2)
		{
			try
			{
				Uri uri = new Uri(class3.Target);
				Path.GetFileName(uri.LocalPath);
				oleFrame.LinkPathLong = uri.LocalPath;
			}
			catch (Exception ex)
			{
				oleFrame.LinkPathLong = class3.Target;
				Class1165.smethod_28(ex);
			}
		}
		Class1342 targetPart = class3.TargetPart;
		if (targetPart != null)
		{
			oleFrame.ObjectData = targetPart.Data;
			targetPart.Processed = true;
		}
		Class2004 pic = @class.Pic;
		if (pic != null)
		{
			Class1810 blipFill = pic.BlipFill;
			Class974.smethod_0(oleFrame.SubstitutePictureFormat, blipFill, slideDeserializationContext.DeserializationContext);
			Class1921 spPr = pic.SpPr;
			Class949.smethod_0(oleFrame.FillFormat, spPr.FillProperties, slideDeserializationContext.DeserializationContext);
			Class968.smethod_0(oleFrame.LineFormat, spPr.Ln);
			Class939.smethod_0(oleFrame.EffectFormat, spPr.EffectProperties, slideDeserializationContext.DeserializationContext);
		}
	}

	public static void smethod_1(OleObjectFrame oleFrame, Class1991 graphicFrameElementData, Class1031 slideSerializationContext)
	{
		_ = oleFrame.PPTXUnsupportedProps;
		Class1346 serializationContext = slideSerializationContext.SerializationContext;
		Class959.smethod_2(oleFrame, graphicFrameElementData, serializationContext);
		Class1352 @class = graphicFrameElementData.Graphic.GraphicData.delegate18_0();
		Class1367 class2 = @class.delegate63_1();
		Class1367 class3 = @class.delegate63_0();
		Class1347 relToOle = null;
		if (oleFrame.IsObjectLink)
		{
			relToOle = serializationContext.RelationshipsOfCurrentPartEntry.method_6(Class1322.class1338_0.Type, Class1165.smethod_17(oleFrame.LinkPathLong), Enum180.const_2);
		}
		else if (oleFrame.ObjectData != null)
		{
			Class1342 class4 = serializationContext.Package.method_4("/ppt/embeddings/oleObject{0}" + smethod_3(oleFrame), serializationContext.method_15, smethod_4(oleFrame));
			class4.Data = (byte[])oleFrame.ObjectData.Clone();
			string relType = (smethod_5(oleFrame) ? Class1327.class1338_0.Type : Class1322.class1338_0.Type);
			relToOle = serializationContext.RelationshipsOfCurrentPartEntry.method_6(relType, class4.PartPath, Enum180.const_1);
		}
		string spid = $"_x0000_s{slideSerializationContext.method_2(oleFrame):D4}";
		smethod_2(oleFrame, class2, relToOle);
		class2.Spid = spid;
		smethod_2(oleFrame, class3, relToOle);
		class3.Spid = spid;
		Class2004 class5 = class3.delegate1833_0();
		class5.NvPicPr.CNvPr.Name = "OLE substitute image";
		Class983.smethod_5(oleFrame, class5.SpPr, serializationContext);
		Class1908 class6 = (Class1908)class5.SpPr.delegate2773_2("prstGeom").Object;
		class6.Prst = ShapeType.Rectangle;
		class6.delegate1429_0();
		Class974.smethod_1(oleFrame.SubstitutePictureFormat, class5.BlipFill, serializationContext);
	}

	private static void smethod_2(IOleObjectFrame oleFrame, Class1367 oleObjectElementData, Class1347 relToOle)
	{
		oleObjectElementData.Name = oleFrame.ObjectName;
		oleObjectElementData.ProgId = oleFrame.ObjectProgId;
		oleObjectElementData.ShowAsIcon = oleFrame.IsObjectIcon;
		if (oleFrame.IsObjectLink)
		{
			Class1369 @class = (Class1369)oleObjectElementData.delegate2773_0("link").Object;
			@class.UpdateAutomatic = oleFrame.UpdateAutomatic;
		}
		else
		{
			oleObjectElementData.delegate2773_0("embed");
		}
		if (relToOle != null)
		{
			oleObjectElementData.R_Id = relToOle.Id;
		}
	}

	internal static string smethod_3(IOleObjectFrame oleFrame)
	{
		string key = oleFrame.ObjectProgId.ToLower();
		if (!sortedList_0.TryGetValue(key, out var value))
		{
			return ".bin";
		}
		return (string)value[0];
	}

	private static Class1223 smethod_4(IOleObjectFrame oleFrame)
	{
		string key = oleFrame.ObjectProgId.ToLower();
		if (!sortedList_0.TryGetValue(key, out var value))
		{
			return new Class1324();
		}
		return (Class1223)value[1];
	}

	internal static bool smethod_5(IOleObjectFrame oleFrame)
	{
		string key = oleFrame.ObjectProgId.ToLower();
		if (!sortedList_0.TryGetValue(key, out var value))
		{
			return false;
		}
		return (string)value[2] == "1";
	}

	static Class969()
	{
		sortedList_0 = new SortedList<string, object[]>();
		sortedList_0.Add("excel.sheet.12", new object[3]
		{
			".xlsx",
			new Class1328(),
			"1"
		});
		sortedList_0.Add("excel.sheet.8", new object[3]
		{
			".xls",
			new Class1323(),
			"0"
		});
		sortedList_0.Add("word.document.12", new object[3]
		{
			".docx",
			new Class1333(),
			"1"
		});
		sortedList_0.Add("word.document.8", new object[3]
		{
			".doc",
			new Class1326(),
			"0"
		});
		sortedList_0.Add("powerpoint.show.12", new object[3]
		{
			".pptx",
			new Class1330(),
			"1"
		});
		sortedList_0.Add("powerpoint.showmacroenabled.12", new object[3]
		{
			".pptm",
			new Class1329(),
			"1"
		});
		sortedList_0.Add("powerpoint.show.8", new object[3]
		{
			".ppt",
			new Class1325(),
			"0"
		});
		sortedList_0.Add("powerpoint.slide.12", new object[3]
		{
			".sldx",
			new Class1331(),
			"1"
		});
		sortedList_0.Add("excel.sheetmacroenabled.12", new object[3]
		{
			".xlsm",
			new Class1328(),
			"1"
		});
	}
}
