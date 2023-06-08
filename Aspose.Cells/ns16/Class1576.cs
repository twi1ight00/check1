using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Properties;

namespace ns16;

internal class Class1576
{
	private Workbook workbook_0;

	private Class1540 class1540_0;

	internal Class1576(Class1540 class1540_1)
	{
		workbook_0 = class1540_1.workbook_0;
		class1540_0 = class1540_1;
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("Properties");
		xmlTextWriter_0.WriteAttributeString("xmlns", null, "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties");
		xmlTextWriter_0.WriteAttributeString("xmlns", "vt", null, "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
		BuiltInDocumentPropertyCollection builtInDocumentProperties = workbook_0.Worksheets.BuiltInDocumentProperties;
		xmlTextWriter_0.WriteElementString("Application", builtInDocumentProperties.NameOfApplication);
		xmlTextWriter_0.WriteElementString("DocSecurity", Class1618.smethod_80(builtInDocumentProperties.method_0()));
		xmlTextWriter_0.WriteElementString("Template", builtInDocumentProperties.Template);
		xmlTextWriter_0.WriteElementString("Manager", builtInDocumentProperties.Manager);
		xmlTextWriter_0.WriteElementString("Company", builtInDocumentProperties.Company);
		if (builtInDocumentProperties.Pages > 0)
		{
			xmlTextWriter_0.WriteElementString("Pages", Class1618.smethod_80(builtInDocumentProperties.Pages));
		}
		if (builtInDocumentProperties.Words > 0)
		{
			xmlTextWriter_0.WriteElementString("Words", Class1618.smethod_80(builtInDocumentProperties.Words));
		}
		if (builtInDocumentProperties.Characters > 0)
		{
			xmlTextWriter_0.WriteElementString("Characters", Class1618.smethod_80(builtInDocumentProperties.Characters));
		}
		if (builtInDocumentProperties.Lines > 0)
		{
			xmlTextWriter_0.WriteElementString("Lines", Class1618.smethod_80(builtInDocumentProperties.Lines));
		}
		if (builtInDocumentProperties.Paragraphs > 0)
		{
			xmlTextWriter_0.WriteElementString("Paragraphs", Class1618.smethod_80(builtInDocumentProperties.Paragraphs));
		}
		if (builtInDocumentProperties.TotalEditingTime > 0.0)
		{
			xmlTextWriter_0.WriteElementString("TotalTime", Class1618.smethod_80((int)(builtInDocumentProperties.TotalEditingTime * 60.0)));
		}
		if (builtInDocumentProperties.CharactersWithSpaces > 0)
		{
			xmlTextWriter_0.WriteElementString("CharactersWithSpaces", Class1618.smethod_80(builtInDocumentProperties.CharactersWithSpaces));
		}
		if (builtInDocumentProperties.Contains("HyperlinkBase") && builtInDocumentProperties.HyperlinkBase != "")
		{
			xmlTextWriter_0.WriteElementString("HyperlinkBase", builtInDocumentProperties.HyperlinkBase);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}
}
