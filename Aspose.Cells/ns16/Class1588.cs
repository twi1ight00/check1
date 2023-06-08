using System.Collections;
using System.Xml;
using ns22;

namespace ns16;

internal class Class1588
{
	internal static void smethod_0(Class1540 class1540_0, XmlTextWriter xmlTextWriter_0)
	{
		ArrayList arrayList = new ArrayList();
		int num = 1;
		Class1564 @class = null;
		num = 1 + 1;
		@class = new Class1564("rId" + 1, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument", "xl/workbook.xml", null);
		arrayList.Add(@class);
		num = 2 + 1;
		@class = new Class1564("rId" + 2, "http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties", "docProps/core.xml", null);
		arrayList.Add(@class);
		num = 3 + 1;
		@class = new Class1564("rId" + 3, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/extended-properties", "docProps/app.xml", null);
		arrayList.Add(@class);
		if (class1540_0.method_35())
		{
			@class = new Class1564("rId" + num++, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/custom-properties", "docProps/custom.xml", null);
			arrayList.Add(@class);
		}
		if (class1540_0.workbook_0.class1558_0 != null && class1540_0.workbook_0.class1558_0.arrayList_3.Count > 0)
		{
			for (int i = 0; i < class1540_0.workbook_0.class1558_0.arrayList_3.Count; i++)
			{
				Class1564 class2 = (Class1564)class1540_0.workbook_0.class1558_0.arrayList_3[i];
				@class = new Class1564("rId" + num++, class2.string_2, class2.string_3, class2.string_4);
				arrayList.Add(@class);
			}
		}
		if (class1540_0.workbook_0.RibbonXml != null && class1540_0.workbook_0.RibbonXml.Length > 0)
		{
			@class = new Class1564("rIdR1d1daea4c3c14db5", "http://schemas.microsoft.com/office/2006/relationships/ui/extensibility", "/customUI/customUI.xml", null);
			arrayList.Add(@class);
		}
		smethod_2(xmlTextWriter_0, arrayList);
	}

	internal static void smethod_1(Class1540 class1540_0, XmlTextWriter xmlTextWriter_0)
	{
		ArrayList arrayList = new ArrayList();
		Class1564 value = new Class1564("rId3", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/extended-properties", "docProps/app.xml", null);
		arrayList.Add(value);
		if (class1540_0.method_35())
		{
			value = new Class1564("rId4", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/custom-properties", "docProps/custom.xml", null);
			arrayList.Add(value);
		}
		value = new Class1564("rId2", "http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties", "docProps/core.xml", null);
		arrayList.Add(value);
		value = new Class1564("rId1", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument", "xl/workbook.bin", null);
		arrayList.Add(value);
		smethod_2(xmlTextWriter_0, arrayList);
	}

	[Attribute0(true)]
	internal static void smethod_2(XmlTextWriter xmlTextWriter_0, ArrayList arrayList_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("Relationships");
		xmlTextWriter_0.WriteAttributeString(null, "xmlns", null, "http://schemas.openxmlformats.org/package/2006/relationships");
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1564 class1564_ = (Class1564)arrayList_0[i];
			smethod_3(xmlTextWriter_0, class1564_);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	internal static void smethod_3(XmlTextWriter xmlTextWriter_0, Class1564 class1564_0)
	{
		xmlTextWriter_0.WriteStartElement("Relationship");
		xmlTextWriter_0.WriteAttributeString("Id", class1564_0.string_1);
		xmlTextWriter_0.WriteAttributeString("Type", class1564_0.string_2);
		xmlTextWriter_0.WriteAttributeString("Target", Class1618.smethod_4(class1564_0.string_3));
		if (class1564_0.string_4 != null && class1564_0.string_4.Length != 0)
		{
			xmlTextWriter_0.WriteAttributeString("TargetMode", class1564_0.string_4);
		}
		xmlTextWriter_0.WriteEndElement();
	}
}
