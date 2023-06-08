using System;
using System.Globalization;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Properties;

namespace ns16;

internal class Class1577
{
	private Workbook workbook_0;

	private Class1540 class1540_0;

	internal Class1577(Class1540 class1540_1)
	{
		workbook_0 = class1540_1.workbook_0;
		class1540_0 = class1540_1;
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("cp:coreProperties");
		xmlTextWriter_0.WriteAttributeString("xmlns", "cp", null, "http://schemas.openxmlformats.org/package/2006/metadata/core-properties");
		xmlTextWriter_0.WriteAttributeString("xmlns", "dc", null, "http://purl.org/dc/elements/1.1/");
		xmlTextWriter_0.WriteAttributeString("xmlns", "dcterms", null, "http://purl.org/dc/terms/");
		xmlTextWriter_0.WriteAttributeString("xmlns", "dcmitype", null, "http://purl.org/dc/dcmitype/");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
		BuiltInDocumentPropertyCollection builtInDocumentProperties = workbook_0.Worksheets.BuiltInDocumentProperties;
		xmlTextWriter_0.WriteElementString("dc:title", builtInDocumentProperties.Title);
		xmlTextWriter_0.WriteElementString("dc:subject", builtInDocumentProperties.Subject);
		xmlTextWriter_0.WriteElementString("dc:creator", builtInDocumentProperties.Author);
		xmlTextWriter_0.WriteElementString("cp:keywords", builtInDocumentProperties.Keywords);
		xmlTextWriter_0.WriteElementString("dc:description", builtInDocumentProperties.Comments);
		xmlTextWriter_0.WriteElementString("cp:lastModifiedBy", builtInDocumentProperties.LastSavedBy);
		if (builtInDocumentProperties.LastPrinted > DateTime.MinValue)
		{
			xmlTextWriter_0.WriteStartElement("cp:lastPrinted", null);
			xmlTextWriter_0.WriteString(builtInDocumentProperties.LastPrinted.ToString("yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture));
			xmlTextWriter_0.WriteEndElement();
		}
		if (builtInDocumentProperties.CreatedTime > DateTime.MinValue)
		{
			xmlTextWriter_0.WriteStartElement("dcterms:created", null);
			xmlTextWriter_0.WriteAttributeString("xsi:type", null, "dcterms:W3CDTF");
			xmlTextWriter_0.WriteString(builtInDocumentProperties.CreatedTime.ToString("yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture));
			xmlTextWriter_0.WriteEndElement();
		}
		if (builtInDocumentProperties.LastSavedTime > DateTime.MinValue)
		{
			xmlTextWriter_0.WriteStartElement("dcterms:modified", null);
			xmlTextWriter_0.WriteAttributeString("xsi:type", null, "dcterms:W3CDTF");
			xmlTextWriter_0.WriteString(builtInDocumentProperties.LastSavedTime.ToString("yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture));
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteElementString("cp:category", builtInDocumentProperties.Category);
		xmlTextWriter_0.WriteElementString("cp:contentType", builtInDocumentProperties.ContentType);
		xmlTextWriter_0.WriteElementString("cp:contentStatus", builtInDocumentProperties.ContentStatus);
		if (builtInDocumentProperties.RevisionNumber != 0)
		{
			xmlTextWriter_0.WriteElementString("cp:revision", Class1618.smethod_80(builtInDocumentProperties.RevisionNumber));
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}
}
