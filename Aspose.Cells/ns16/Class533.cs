using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Properties;
using ns22;

namespace ns16;

internal class Class533
{
	private Workbook workbook_0;

	private Class1540 class1540_0;

	internal Class533(Class1540 class1540_1)
	{
		workbook_0 = class1540_1.workbook_0;
		class1540_0 = class1540_1;
	}

	[Attribute0(true)]
	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("p:properties");
		xmlTextWriter_0.WriteAttributeString("xmlns", "p", null, "http://schemas.microsoft.com/office/2006/metadata/properties");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
		xmlTextWriter_0.WriteStartElement("documentManagement");
		ContentTypePropertyCollection contentTypeProperties = workbook_0.ContentTypeProperties;
		for (int i = 0; i < contentTypeProperties.Count; i++)
		{
			ContentTypeProperty contentTypeProperty_ = contentTypeProperties[i];
			method_0(xmlTextWriter_0, contentTypeProperty_);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_0(XmlTextWriter xmlTextWriter_0, ContentTypeProperty contentTypeProperty_0)
	{
		string name = contentTypeProperty_0.Name;
		string value = contentTypeProperty_0.Value;
		xmlTextWriter_0.WriteStartElement(name);
		xmlTextWriter_0.WriteAttributeString("xmlns", null, contentTypeProperty_0.string_0);
		xmlTextWriter_0.WriteRaw(Class1618.smethod_4(value));
		xmlTextWriter_0.WriteEndElement();
	}
}
