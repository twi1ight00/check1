using System.IO;
using System.Xml;
using Aspose.Cells;
using ns22;

namespace ns16;

internal class Class445
{
	private Class1540 class1540_0;

	private Workbook workbook_0;

	private XmlDocument xmlDocument_0;

	private QueryTable queryTable_0;

	private string string_0 = "http://schemas.openxmlformats.org/drawingml/2006/main";

	internal Class445(Class1540 class1540_1, QueryTable queryTable_1)
	{
		class1540_0 = class1540_1;
		workbook_0 = class1540_1.workbook_0;
		queryTable_0 = queryTable_1;
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		Class746 class746_ = class1540_0.class746_0;
		Class744 class744_ = class746_.method_38(queryTable_0.string_0);
		Stream stream = class746_.method_39(class744_);
		xmlDocument_0 = Class1188.smethod_2(stream);
		stream.Close();
		method_0();
		xmlTextWriter_0.WriteRaw(Class1188.smethod_11(xmlDocument_0));
		xmlTextWriter_0.Flush();
	}

	private void method_0()
	{
		XmlElement documentElement = xmlDocument_0.DocumentElement;
		Class1188.smethod_14(documentElement, "preserveFormatting");
		Class1188.smethod_14(documentElement, "adjustColumnWidth");
		if (!queryTable_0.PreserveFormatting)
		{
			method_1(documentElement, "preserveFormatting", "0");
		}
		if (!queryTable_0.AdjustColumnWidth)
		{
			method_1(documentElement, "adjustColumnWidth", "0");
		}
	}

	private void method_1(XmlElement xmlElement_0, string string_1, string string_2)
	{
		XmlAttribute xmlAttribute = xmlDocument_0.CreateAttribute(string_1);
		xmlAttribute.Value = string_2;
		xmlElement_0.Attributes.Append(xmlAttribute);
	}
}
