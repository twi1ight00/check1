using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Properties;
using ns22;

namespace ns16;

internal class Class531
{
	private Workbook workbook_0;

	private Class1540 class1540_0;

	internal Class531(Class1540 class1540_1)
	{
		workbook_0 = class1540_1.workbook_0;
		class1540_0 = class1540_1;
	}

	[Attribute0(true)]
	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		ContentTypePropertyCollection contentTypeProperties = workbook_0.ContentTypeProperties;
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("ct:contentTypeSchema");
		xmlTextWriter_0.WriteAttributeString("ct:_", null, "");
		xmlTextWriter_0.WriteAttributeString("ma:_", null, "");
		xmlTextWriter_0.WriteAttributeString("ma:contentTypeName", null, "Document");
		xmlTextWriter_0.WriteAttributeString("ma:contentTypeID", null, "0x01010002CD4CE788C0924AAB9A9AF8274C3BA0");
		xmlTextWriter_0.WriteAttributeString("ma:contentTypeVersion", null, "4");
		xmlTextWriter_0.WriteAttributeString("ma:contentTypeDescription", null, "Create a new document.");
		xmlTextWriter_0.WriteAttributeString("ma:contentTypeScope", null, "");
		xmlTextWriter_0.WriteAttributeString("ma:versionID", null, "273ab99c845a0ab368c691b7cbc8d5c9");
		xmlTextWriter_0.WriteAttributeString("xmlns", "ct", null, "http://schemas.microsoft.com/office/2006/metadata/contentType");
		xmlTextWriter_0.WriteAttributeString("xmlns", "ma", null, "http://schemas.microsoft.com/office/2006/metadata/properties/metaAttributes");
		xmlTextWriter_0.WriteStartElement("xsd:schema", null);
		xmlTextWriter_0.WriteAttributeString("targetNamespace", "http://schemas.microsoft.com/office/2006/metadata/properties");
		xmlTextWriter_0.WriteAttributeString("ma:root", "true");
		xmlTextWriter_0.WriteAttributeString("ma:fieldsID", "cc735bd373cf9519d82bcfd02363e949");
		xmlTextWriter_0.WriteAttributeString("ns1:_", "");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xs", null, "http://www.w3.org/2001/XMLSchema");
		xmlTextWriter_0.WriteAttributeString("xmlns", "p", null, "http://schemas.microsoft.com/office/2006/metadata/properties");
		if (contentTypeProperties.arrayList_0.Count == 0)
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", "ns1", null, "f0ee3e2c-6582-4549-9afa-575e8dac0aa5");
			contentTypeProperties.arrayList_0.Add("f0ee3e2c-6582-4549-9afa-575e8dac0aa5");
		}
		else
		{
			for (int i = 0; i < contentTypeProperties.arrayList_0.Count; i++)
			{
				xmlTextWriter_0.WriteAttributeString("xmlns", "ns" + (i + 1), null, (string)contentTypeProperties.arrayList_0[i]);
			}
		}
		for (int j = 0; j < contentTypeProperties.arrayList_0.Count; j++)
		{
			xmlTextWriter_0.WriteStartElement("xsd:import", null);
			xmlTextWriter_0.WriteAttributeString("namespace", (string)contentTypeProperties.arrayList_0[j]);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("name", "properties");
		xmlTextWriter_0.WriteStartElement("xsd:complexType", null);
		xmlTextWriter_0.WriteStartElement("xsd:sequence", null);
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("name", "documentManagement");
		xmlTextWriter_0.WriteStartElement("xsd:complexType", null);
		xmlTextWriter_0.WriteStartElement("xsd:all", null);
		for (int k = 0; k < contentTypeProperties.Count; k++)
		{
			xmlTextWriter_0.WriteStartElement("xsd:element", null);
			ContentTypeProperty contentTypeProperty = contentTypeProperties[k];
			xmlTextWriter_0.WriteAttributeString("ref", "ns" + (contentTypeProperty.Index + 1) + ":" + contentTypeProperty.Name);
			xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		for (int l = 0; l < contentTypeProperties.arrayList_0.Count; l++)
		{
			xmlTextWriter_0.WriteStartElement("xsd:schema", null);
			xmlTextWriter_0.WriteAttributeString("targetNamespace", (string)contentTypeProperties.arrayList_0[l]);
			xmlTextWriter_0.WriteAttributeString("elementFormDefault", "qualified");
			xmlTextWriter_0.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
			xmlTextWriter_0.WriteAttributeString("xmlns", "xs", null, "http://www.w3.org/2001/XMLSchema");
			xmlTextWriter_0.WriteAttributeString("xmlns", "dms", null, "http://schemas.microsoft.com/office/2006/documentManagement/types");
			xmlTextWriter_0.WriteAttributeString("xmlns", "pc", null, "http://schemas.microsoft.com/office/infopath/2007/PartnerControls");
			xmlTextWriter_0.WriteStartElement("xsd:import", null);
			xmlTextWriter_0.WriteAttributeString("namespace", "http://schemas.microsoft.com/office/2006/documentManagement/types");
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("xsd:import", null);
			xmlTextWriter_0.WriteAttributeString("namespace", "http://schemas.microsoft.com/office/infopath/2007/PartnerControls");
			xmlTextWriter_0.WriteEndElement();
			for (int m = 0; m < contentTypeProperties.Count; m++)
			{
				ContentTypeProperty contentTypeProperty2 = contentTypeProperties[m];
				if (contentTypeProperty2.Index != l)
				{
					continue;
				}
				xmlTextWriter_0.WriteStartElement("xsd:element", null);
				xmlTextWriter_0.WriteAttributeString("name", contentTypeProperty2.Name);
				xmlTextWriter_0.WriteAttributeString("ma:index", m.ToString());
				xmlTextWriter_0.WriteAttributeString("nillable", "true");
				xmlTextWriter_0.WriteAttributeString("ma:displayName", contentTypeProperty2.Name);
				xmlTextWriter_0.WriteAttributeString("ma:default", contentTypeProperty2.Value);
				xmlTextWriter_0.WriteAttributeString("ma:internalName", contentTypeProperty2.Name);
				if (contentTypeProperty2.string_2 != null)
				{
					xmlTextWriter_0.WriteStartElement("xsd:complexType", null);
					xmlTextWriter_0.WriteRaw(contentTypeProperty2.string_2);
					xmlTextWriter_0.WriteEndElement();
				}
				else
				{
					xmlTextWriter_0.WriteStartElement("xsd:simpleType", null);
					xmlTextWriter_0.WriteStartElement("xsd:restriction", null);
					if (contentTypeProperty2.string_1 != null)
					{
						xmlTextWriter_0.WriteAttributeString("base", contentTypeProperty2.string_1);
					}
					else
					{
						xmlTextWriter_0.WriteAttributeString("base", "dms:Text");
					}
					for (int n = 0; n < contentTypeProperty2.arrayList_0.Count; n++)
					{
						xmlTextWriter_0.WriteStartElement("xsd:enumeration ", null);
						xmlTextWriter_0.WriteAttributeString("value", (string)contentTypeProperty2.arrayList_0[n]);
						xmlTextWriter_0.WriteEndElement();
					}
					xmlTextWriter_0.WriteEndElement();
					xmlTextWriter_0.WriteEndElement();
				}
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteStartElement("xsd:schema", null);
		xmlTextWriter_0.WriteAttributeString("targetNamespace", "http://schemas.openxmlformats.org/package/2006/metadata/core-properties");
		xmlTextWriter_0.WriteAttributeString("elementFormDefault", "qualified");
		xmlTextWriter_0.WriteAttributeString("attributeFormDefault", "unqualified");
		xmlTextWriter_0.WriteAttributeString("blockDefault", "#all");
		xmlTextWriter_0.WriteAttributeString("xmlns", null, "http://schemas.openxmlformats.org/package/2006/metadata/core-properties");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
		xmlTextWriter_0.WriteAttributeString("xmlns", "dc", null, "http://purl.org/dc/elements/1.1/");
		xmlTextWriter_0.WriteAttributeString("xmlns", "dcterms", null, "http://purl.org/dc/terms/");
		xmlTextWriter_0.WriteAttributeString("xmlns", "odoc", null, "http://schemas.microsoft.com/internal/obd");
		xmlTextWriter_0.WriteStartElement("xsd:import", null);
		xmlTextWriter_0.WriteAttributeString("namespace", "http://purl.org/dc/elements/1.1/");
		xmlTextWriter_0.WriteAttributeString("schemaLocation", "http://dublincore.org/schemas/xmls/qdc/2003/04/02/dc.xsd");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:import", null);
		xmlTextWriter_0.WriteAttributeString("namespace", "http://purl.org/dc/terms/");
		xmlTextWriter_0.WriteAttributeString("schemaLocation", "http://dublincore.org/schemas/xmls/qdc/2003/04/02/dcterms.xsd");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("name", "coreProperties");
		xmlTextWriter_0.WriteAttributeString("type", "CT_coreProperties");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:complexType ", null);
		xmlTextWriter_0.WriteAttributeString("name", "CT_coreProperties");
		xmlTextWriter_0.WriteStartElement("xsd:all ", null);
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("ref", "dc:creator");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("ref", "dcterms:created");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("ref", "dc:identifier");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("name", "contentType");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteAttributeString("type", "xsd:string");
		xmlTextWriter_0.WriteAttributeString("ma:index", "0");
		xmlTextWriter_0.WriteAttributeString("ma:displayName", "Content Type");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("ref", "dc:title");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteAttributeString("ma:index", "4");
		xmlTextWriter_0.WriteAttributeString("ma:displayName", "Title");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("ref", "dc:subject");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("ref", "dc:description");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("name", "keywords");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteAttributeString("type", "xsd:string");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("ref", "dc:language");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("name", "category");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteAttributeString("type", "xsd:string");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("name", "version");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteAttributeString("type", "xsd:string");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("name", "revision");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteAttributeString("type", "xsd:string");
		xmlTextWriter_0.WriteStartElement("xsd:annotation", null);
		xmlTextWriter_0.WriteElementString("xsd:documentation", "This value indicates the number of saves or revisions. The application is responsible for updating this value after each revision.");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("name", "lastModifiedBy");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteAttributeString("type", "xsd:string");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("ref", "dcterms:modified");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("xsd:element", null);
		xmlTextWriter_0.WriteAttributeString("name", "contentStatus");
		xmlTextWriter_0.WriteAttributeString("minOccurs", "0");
		xmlTextWriter_0.WriteAttributeString("maxOccurs", "1");
		xmlTextWriter_0.WriteAttributeString("type", "xsd:string");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}
}
