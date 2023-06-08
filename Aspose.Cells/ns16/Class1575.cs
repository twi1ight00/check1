using System.Xml;
using Aspose.Cells;
using ns22;

namespace ns16;

internal class Class1575
{
	private Workbook workbook_0;

	private Class1540 class1540_0;

	internal Class1575(Class1540 class1540_1)
	{
		workbook_0 = class1540_1.workbook_0;
		class1540_0 = class1540_1;
	}

	[Attribute0(true)]
	internal void method_0(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("Types");
		xmlTextWriter_0.WriteAttributeString("xmlns", null, "http://schemas.openxmlformats.org/package/2006/content-types");
		for (int i = 0; i < class1540_0.arrayList_4.Count; i++)
		{
			Class1530 @class = (Class1530)class1540_0.arrayList_4[i];
			if (@class.bool_0)
			{
				method_1(xmlTextWriter_0, @class.string_0, @class.string_2);
			}
			else
			{
				method_2(xmlTextWriter_0, @class.string_1, @class.string_2);
			}
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0, string string_0, string string_1)
	{
		xmlTextWriter_0.WriteStartElement("Default");
		xmlTextWriter_0.WriteAttributeString("Extension", null, string_0);
		xmlTextWriter_0.WriteAttributeString("ContentType", null, string_1);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_2(XmlTextWriter xmlTextWriter_0, string string_0, string string_1)
	{
		xmlTextWriter_0.WriteStartElement("Override");
		xmlTextWriter_0.WriteAttributeString("PartName", string_0);
		xmlTextWriter_0.WriteAttributeString("ContentType", string_1);
		xmlTextWriter_0.WriteEndElement();
	}
}
