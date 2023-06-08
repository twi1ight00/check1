using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using ns22;

namespace ns16;

internal class Class1591
{
	private Class1540 class1540_0;

	private Workbook workbook_0;

	private XmlDocument xmlDocument_0;

	private string string_0 = "http://schemas.openxmlformats.org/drawingml/2006/main";

	internal Class1591(Class1540 class1540_1)
	{
		class1540_0 = class1540_1;
		workbook_0 = class1540_1.workbook_0;
	}

	internal Class1591(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		if (method_0() && class1540_0 != null)
		{
			Class746 class746_ = class1540_0.class746_0;
			Class744 class744_ = class746_.method_38(workbook_0.class1558_0.string_1);
			Stream stream = class746_.method_39(class744_);
			xmlDocument_0 = Class1188.smethod_2(stream);
			stream.Close();
		}
		else
		{
			string text = method_1();
			xmlDocument_0 = Class1188.smethod_1(text);
		}
		method_2();
		xmlTextWriter_0.WriteRaw(Class1188.smethod_11(xmlDocument_0));
		xmlTextWriter_0.Flush();
	}

	private bool method_0()
	{
		if (workbook_0.class1558_0 != null && workbook_0.class1558_0.bool_1 && !workbook_0.class1558_0.bool_2)
		{
			return true;
		}
		return false;
	}

	private string method_1()
	{
		StringBuilder stringBuilder = new StringBuilder(8000);
		string text = "ＭＳ Ｐゴシック";
		string text2 = "맑은 고딕";
		string text3 = "宋体";
		string text4 = "新細明體";
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n");
		stringBuilder.Append("<a:theme xmlns:a=\"http://schemas.openxmlformats.org/drawingml/2006/main\" name=\"Office Theme\">");
		stringBuilder.Append("<a:themeElements><a:clrScheme name=\"Office\"><a:dk1><a:sysClr val=\"windowText\" lastClr=\"000000\"/></a:dk1><a:lt1><a:sysClr val=\"window\" lastClr=\"FFFFFF\"/></a:lt1><a:dk2><a:srgbClr val=\"1F497D\"/></a:dk2><a:lt2><a:srgbClr val=\"EEECE1\"/></a:lt2><a:accent1><a:srgbClr val=\"4F81BD\"/></a:accent1><a:accent2><a:srgbClr val=\"C0504D\"/></a:accent2><a:accent3><a:srgbClr val=\"9BBB59\"/></a:accent3><a:accent4><a:srgbClr val=\"8064A2\"/></a:accent4><a:accent5><a:srgbClr val=\"4BACC6\"/></a:accent5><a:accent6><a:srgbClr val=\"F79646\"/></a:accent6><a:hlink><a:srgbClr val=\"0000FF\"/></a:hlink><a:folHlink><a:srgbClr val=\"800080\"/></a:folHlink></a:clrScheme><a:fontScheme name=\"Office\"><a:majorFont><a:latin typeface=\"Cambria\"/><a:ea typeface=\"\"/><a:cs typeface=\"\"/>");
		stringBuilder.Append("<a:font script=\"Jpan\" typeface=\"" + text + "\"/><a:font script=\"Hang\" typeface=\"" + text2 + "\"/><a:font script=\"Hans\" typeface=\"" + text3 + "\"/><a:font script=\"Hant\" typeface=\"" + text4 + "\"/>");
		stringBuilder.Append("<a:font script=\"Arab\" typeface=\"Times New Roman\"/>");
		stringBuilder.Append("<a:font script=\"Hebr\" typeface=\"Times New Roman\"/><a:font script=\"Thai\" typeface=\"Tahoma\"/><a:font script=\"Ethi\" typeface=\"Nyala\"/><a:font script=\"Beng\" typeface=\"Vrinda\"/><a:font script=\"Gujr\" typeface=\"Shruti\"/><a:font script=\"Khmr\" typeface=\"MoolBoran\"/><a:font script=\"Knda\" typeface=\"Tunga\"/><a:font script=\"Guru\" typeface=\"Raavi\"/><a:font script=\"Cans\" typeface=\"Euphemia\"/><a:font script=\"Cher\" typeface=\"Plantagenet Cherokee\"/><a:font script=\"Yiii\" typeface=\"Microsoft Yi Baiti\"/><a:font script=\"Tibt\" typeface=\"Microsoft Himalaya\"/><a:font script=\"Thaa\" typeface=\"MV Boli\"/><a:font script=\"Deva\" typeface=\"Mangal\"/><a:font script=\"Telu\" typeface=\"Gautami\"/><a:font script=\"Taml\" typeface=\"Latha\"/><a:font script=\"Syrc\" typeface=\"Estrangelo Edessa\"/><a:font script=\"Orya\" typeface=\"Kalinga\"/><a:font script=\"Mlym\" typeface=\"Kartika\"/><a:font script=\"Laoo\" typeface=\"DokChampa\"/><a:font script=\"Sinh\" typeface=\"Iskoola Pota\"/>");
		stringBuilder.Append("<a:font script=\"Mong\" typeface=\"Mongolian Baiti\"/><a:font script=\"Viet\" typeface=\"Times New Roman\"/><a:font script=\"Uigh\" typeface=\"Microsoft Uighur\"/></a:majorFont><a:minorFont><a:latin typeface=\"Calibri\"/><a:ea typeface=\"\"/><a:cs typeface=\"\"/>");
		stringBuilder.Append("<a:font script=\"Jpan\" typeface=\"" + text + "\"/><a:font script=\"Hang\" typeface=\"" + text2 + "\"/><a:font script=\"Hans\" typeface=\"" + text3 + "\"/><a:font script=\"Hant\" typeface=\"" + text4 + "\"/>");
		stringBuilder.Append("<a:font script=\"Arab\" typeface=\"Arial\"/><a:font script=\"Hebr\" typeface=\"Arial\"/><a:font script=\"Thai\" typeface=\"Tahoma\"/><a:font script=\"Ethi\" typeface=\"Nyala\"/><a:font script=\"Beng\" typeface=\"Vrinda\"/><a:font script=\"Gujr\" typeface=\"Shruti\"/><a:font script=\"Khmr\" typeface=\"DaunPenh\"/><a:font script=\"Knda\" typeface=\"Tunga\"/><a:font script=\"Guru\" typeface=\"Raavi\"/><a:font script=\"Cans\" typeface=\"Euphemia\"/><a:font script=\"Cher\" typeface=\"Plantagenet Cherokee\"/><a:font script=\"Yiii\" typeface=\"Microsoft Yi Baiti\"/>");
		stringBuilder.Append("<a:font script=\"Tibt\" typeface=\"Microsoft Himalaya\"/><a:font script=\"Thaa\" typeface=\"MV Boli\"/><a:font script=\"Deva\" typeface=\"Mangal\"/><a:font script=\"Telu\" typeface=\"Gautami\"/><a:font script=\"Taml\" typeface=\"Latha\"/><a:font script=\"Syrc\" typeface=\"Estrangelo Edessa\"/><a:font script=\"Orya\" typeface=\"Kalinga\"/><a:font script=\"Mlym\" typeface=\"Kartika\"/><a:font script=\"Laoo\" typeface=\"DokChampa\"/><a:font script=\"Sinh\" typeface=\"Iskoola Pota\"/><a:font script=\"Mong\" typeface=\"Mongolian Baiti\"/><a:font script=\"Viet\" typeface=\"Arial\"/><a:font script=\"Uigh\" typeface=\"Microsoft Uighur\"/></a:minorFont></a:fontScheme><a:fmtScheme name=\"Office\"><a:fillStyleLst><a:solidFill><a:schemeClr val=\"phClr\"/></a:solidFill><a:gradFill rotWithShape=\"1\"><a:gsLst><a:gs pos=\"0\"><a:schemeClr val=\"phClr\"><a:tint val=\"50000\"/><a:satMod val=\"300000\"/></a:schemeClr></a:gs><a:gs pos=\"35000\"><a:schemeClr val=\"phClr\"><a:tint val=\"37000\"/><a:satMod val=\"300000\"/>");
		stringBuilder.Append("</a:schemeClr></a:gs><a:gs pos=\"100000\"><a:schemeClr val=\"phClr\"><a:tint val=\"15000\"/><a:satMod val=\"350000\"/></a:schemeClr></a:gs></a:gsLst><a:lin ang=\"16200000\" scaled=\"1\"/></a:gradFill><a:gradFill rotWithShape=\"1\"><a:gsLst><a:gs pos=\"0\"><a:schemeClr val=\"phClr\"><a:tint val=\"100000\"/><a:shade val=\"100000\"/><a:satMod val=\"130000\"/></a:schemeClr></a:gs><a:gs pos=\"100000\"><a:schemeClr val=\"phClr\"><a:tint val=\"50000\"/><a:shade val=\"100000\"/><a:satMod val=\"350000\"/></a:schemeClr></a:gs></a:gsLst><a:lin ang=\"16200000\" scaled=\"0\"/></a:gradFill></a:fillStyleLst><a:lnStyleLst><a:ln w=\"9525\" cap=\"flat\" cmpd=\"sng\" algn=\"ctr\"><a:solidFill><a:schemeClr val=\"phClr\"><a:shade val=\"95000\"/><a:satMod val=\"105000\"/></a:schemeClr></a:solidFill><a:prstDash val=\"solid\"/></a:ln><a:ln w=\"25400\" cap=\"flat\" cmpd=\"sng\" algn=\"ctr\"><a:solidFill><a:schemeClr val=\"phClr\"/></a:solidFill><a:prstDash val=\"solid\"/></a:ln><a:ln w=\"38100\" cap=\"flat\" cmpd=\"sng\" algn=\"ctr\"><a:solidFill><a:schemeClr val=\"phClr\"/></a:solidFill>");
		stringBuilder.Append("<a:prstDash val=\"solid\"/></a:ln></a:lnStyleLst><a:effectStyleLst><a:effectStyle><a:effectLst><a:outerShdw blurRad=\"40000\" dist=\"20000\" dir=\"5400000\" rotWithShape=\"0\"><a:srgbClr val=\"000000\"><a:alpha val=\"38000\"/></a:srgbClr></a:outerShdw></a:effectLst></a:effectStyle><a:effectStyle><a:effectLst><a:outerShdw blurRad=\"40000\" dist=\"23000\" dir=\"5400000\" rotWithShape=\"0\"><a:srgbClr val=\"000000\"><a:alpha val=\"35000\"/></a:srgbClr></a:outerShdw></a:effectLst></a:effectStyle><a:effectStyle><a:effectLst><a:outerShdw blurRad=\"40000\" dist=\"23000\" dir=\"5400000\" rotWithShape=\"0\"><a:srgbClr val=\"000000\"><a:alpha val=\"35000\"/></a:srgbClr></a:outerShdw></a:effectLst><a:scene3d><a:camera prst=\"orthographicFront\"><a:rot lat=\"0\" lon=\"0\" rev=\"0\"/></a:camera><a:lightRig rig=\"threePt\" dir=\"t\"><a:rot lat=\"0\" lon=\"0\" rev=\"1200000\"/></a:lightRig></a:scene3d><a:sp3d><a:bevelT w=\"63500\" h=\"25400\"/></a:sp3d></a:effectStyle></a:effectStyleLst><a:bgFillStyleLst><a:solidFill><a:schemeClr val=\"phClr\"/></a:solidFill>");
		stringBuilder.Append("<a:gradFill rotWithShape=\"1\"><a:gsLst><a:gs pos=\"0\"><a:schemeClr val=\"phClr\"><a:tint val=\"40000\"/><a:satMod val=\"350000\"/></a:schemeClr></a:gs><a:gs pos=\"40000\"><a:schemeClr val=\"phClr\"><a:tint val=\"45000\"/><a:shade val=\"99000\"/><a:satMod val=\"350000\"/></a:schemeClr></a:gs><a:gs pos=\"100000\"><a:schemeClr val=\"phClr\"><a:shade val=\"20000\"/><a:satMod val=\"255000\"/></a:schemeClr></a:gs></a:gsLst><a:path path=\"circle\"><a:fillToRect l=\"50000\" t=\"-80000\" r=\"50000\" b=\"180000\"/></a:path></a:gradFill><a:gradFill rotWithShape=\"1\"><a:gsLst><a:gs pos=\"0\"><a:schemeClr val=\"phClr\"><a:tint val=\"80000\"/><a:satMod val=\"300000\"/></a:schemeClr></a:gs><a:gs pos=\"100000\"><a:schemeClr val=\"phClr\"><a:shade val=\"30000\"/><a:satMod val=\"200000\"/></a:schemeClr></a:gs></a:gsLst><a:path path=\"circle\"><a:fillToRect l=\"50000\" t=\"50000\" r=\"50000\" b=\"50000\"/></a:path></a:gradFill></a:bgFillStyleLst></a:fmtScheme></a:themeElements>");
		stringBuilder.Append("<a:objectDefaults><a:spDef><a:spPr/><a:bodyPr/><a:lstStyle/><a:style><a:lnRef idx=\"1\"><a:schemeClr val=\"accent1\"/></a:lnRef><a:fillRef idx=\"3\"><a:schemeClr val=\"accent1\"/></a:fillRef><a:effectRef idx=\"2\"><a:schemeClr val=\"accent1\"/></a:effectRef><a:fontRef idx=\"minor\"><a:schemeClr val=\"lt1\"/></a:fontRef></a:style></a:spDef><a:lnDef><a:spPr/><a:bodyPr/><a:lstStyle/><a:style><a:lnRef idx=\"2\"><a:schemeClr val=\"accent1\"/></a:lnRef><a:fillRef idx=\"0\"><a:schemeClr val=\"accent1\"/></a:fillRef><a:effectRef idx=\"1\"><a:schemeClr val=\"accent1\"/></a:effectRef><a:fontRef idx=\"minor\"><a:schemeClr val=\"tx1\"/></a:fontRef></a:style></a:lnDef></a:objectDefaults><a:extraClrSchemeLst/>");
		stringBuilder.Append("</a:theme>");
		return stringBuilder.ToString();
	}

	private void method_2()
	{
		XmlElement xmlElement = Class1618.smethod_173(xmlDocument_0.DocumentElement, "themeElements");
		if (xmlElement != null)
		{
			XmlElement xmlElement2 = Class1618.smethod_173(xmlElement, "clrScheme");
			xmlElement2.RemoveAll();
			method_3(xmlElement2);
		}
	}

	private void method_3(XmlElement xmlElement_0)
	{
		method_5(xmlElement_0, "name", workbook_0.class1569_0.string_0);
		Class928[] class928_ = workbook_0.class1569_0.class928_0;
		method_4(xmlElement_0, class928_[1]);
		method_4(xmlElement_0, class928_[0]);
		method_4(xmlElement_0, class928_[3]);
		method_4(xmlElement_0, class928_[2]);
		int num = class928_.Length;
		for (int i = 4; i < num; i++)
		{
			method_4(xmlElement_0, class928_[i]);
		}
	}

	private void method_4(XmlElement xmlElement_0, Class928 class928_0)
	{
		XmlElement xmlElement_ = method_6(xmlElement_0, "a", class928_0.string_0, string_0);
		if (class928_0.method_0() && class928_0.string_1 != null)
		{
			XmlElement xmlElement_2 = method_6(xmlElement_, "a", "sysClr", string_0);
			method_5(xmlElement_2, "val", class928_0.string_1);
			method_5(xmlElement_2, "lastClr", Class1618.smethod_64(class928_0.Color));
			return;
		}
		XmlElement xmlElement_3 = method_6(xmlElement_, "a", "srgbClr", string_0);
		method_5(xmlElement_3, "val", Class1618.smethod_64(class928_0.Color));
		object obj = class928_0.class1363_0.method_0(Enum129.const_3);
		if (obj == null)
		{
			return;
		}
		ArrayList arrayList = (ArrayList)obj;
		foreach (object item in arrayList)
		{
			Class927 @class = (Class927)item;
			method_5(xmlElement_3, @class.string_0, @class.string_1);
		}
	}

	private void method_5(XmlElement xmlElement_0, string string_1, string string_2)
	{
		XmlAttribute xmlAttribute = xmlDocument_0.CreateAttribute(string_1);
		xmlAttribute.Value = string_2;
		xmlElement_0.Attributes.Append(xmlAttribute);
	}

	private XmlElement method_6(XmlElement xmlElement_0, string string_1, string string_2, string string_3)
	{
		XmlElement xmlElement = xmlDocument_0.CreateElement(string_1, string_2, string_3);
		xmlElement_0.AppendChild(xmlElement);
		return xmlElement;
	}
}
