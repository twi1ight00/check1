using System.Collections;
using System.Xml;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns16;

internal class Class1589
{
	private Workbook workbook_0;

	private Class1540 class1540_0;

	internal Class1589(Class1540 class1540_1)
	{
		workbook_0 = class1540_1.workbook_0;
		class1540_0 = class1540_1;
	}

	[Attribute0(true)]
	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("sst");
		if (Class1618.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_0);
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_1);
		}
		Class1301 class1301_ = workbook_0.Worksheets.class1301_0;
		Class978 class978_ = class1540_0.class978_0;
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_81(class978_?.uint_0 ?? class1301_.method_2()));
		xmlTextWriter_0.WriteAttributeString("uniqueCount", Class1618.smethod_80((class978_ == null) ? class1301_.method_3() : (class978_.int_2 + class978_.arrayList_0.Count)));
		int num = class978_?.int_2 ?? class1301_.method_3();
		for (int i = 0; i < num; i++)
		{
			Class1719 @class = class1301_.class1719_0[i];
			xmlTextWriter_0.WriteStartElement("si");
			if (@class == null)
			{
				method_1(xmlTextWriter_0, "r");
			}
			else if (@class.method_1())
			{
				method_2(xmlTextWriter_0, (Class1720)@class);
			}
			else
			{
				method_0(xmlTextWriter_0, @class);
			}
			xmlTextWriter_0.WriteEndElement();
		}
		if (class978_ != null)
		{
			foreach (string item in class978_.arrayList_0)
			{
				xmlTextWriter_0.WriteStartElement("si");
				method_1(xmlTextWriter_0, item);
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	private void method_0(XmlTextWriter xmlTextWriter_0, Class1719 class1719_0)
	{
		method_1(xmlTextWriter_0, class1719_0.string_0);
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0, string string_0)
	{
		string text = Class1618.smethod_4(string_0);
		xmlTextWriter_0.WriteStartElement("t");
		if (Class1618.smethod_177(text))
		{
			xmlTextWriter_0.WriteAttributeString("xml:space", null, "preserve");
		}
		xmlTextWriter_0.WriteString(text);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_2(XmlTextWriter xmlTextWriter_0, Class1720 class1720_0)
	{
		if (class1720_0.method_2().Length == 0)
		{
			method_1(xmlTextWriter_0, class1720_0.string_0);
			return;
		}
		ArrayList arrayList = Class1544.smethod_0(class1720_0, null, workbook_0);
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1544 @class = (Class1544)arrayList[i];
			xmlTextWriter_0.WriteStartElement("r");
			if (@class.font_0 != null)
			{
				xmlTextWriter_0.WriteStartElement("rPr");
				Class1590.smethod_0(@class.font_0, xmlTextWriter_0, "rFont");
				xmlTextWriter_0.WriteEndElement();
			}
			method_1(xmlTextWriter_0, @class.string_0);
			xmlTextWriter_0.WriteEndElement();
		}
	}
}
