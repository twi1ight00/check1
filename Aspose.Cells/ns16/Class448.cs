using System.Xml;
using Aspose.Cells.Properties;

namespace ns16;

internal class Class448
{
	private Class1547 class1547_0;

	private string string_0;

	private string string_1;

	private ContentTypePropertyCollection contentTypePropertyCollection_0;

	internal Class448(Class1547 class1547_1)
	{
		class1547_0 = class1547_1;
		contentTypePropertyCollection_0 = class1547_0.workbook_0.ContentTypeProperties;
	}

	internal bool Read(XmlTextReader xmlTextReader_0)
	{
		if (!method_6(xmlTextReader_0))
		{
			return false;
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			return false;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "schema")
			{
				method_5(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		return true;
	}

	internal void method_0(XmlTextReader xmlTextReader_0, ContentTypeProperty contentTypeProperty_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "restriction")
			{
				contentTypeProperty_0.string_1 = xmlTextReader_0.GetAttribute("base");
				method_1(xmlTextReader_0, contentTypeProperty_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal void method_1(XmlTextReader xmlTextReader_0, ContentTypeProperty contentTypeProperty_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "enumeration")
			{
				string attribute = xmlTextReader_0.GetAttribute("value");
				contentTypeProperty_0.arrayList_0.Add(attribute);
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal void method_2(XmlTextReader xmlTextReader_0, ContentTypeProperty contentTypeProperty_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "simpleType")
			{
				method_0(xmlTextReader_0, contentTypeProperty_0);
			}
			else if (xmlTextReader_0.LocalName == "complexType")
			{
				contentTypeProperty_0.string_2 = xmlTextReader_0.ReadInnerXml();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal void method_3(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "element")
			{
				string attribute = xmlTextReader_0.GetAttribute("name");
				ContentTypeProperty contentTypeProperty = contentTypePropertyCollection_0[attribute];
				if (contentTypeProperty != null)
				{
					method_2(xmlTextReader_0, contentTypeProperty);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal void method_4(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "import")
			{
				string attribute = xmlTextReader_0.GetAttribute("namespace");
				contentTypePropertyCollection_0.arrayList_0.Add(attribute);
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal void method_5(XmlTextReader xmlTextReader_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("targetNamespace");
		if (attribute.Equals("http://schemas.microsoft.com/office/2006/metadata/properties"))
		{
			method_4(xmlTextReader_0);
		}
		else
		{
			method_3(xmlTextReader_0);
		}
	}

	private bool method_6(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add("http://schemas.microsoft.com/office/2006/metadata/contentType");
		string_1 = nameTable.Add("http://schemas.microsoft.com/office/2006/metadata/properties/metaAttributes");
		xmlTextReader_0.MoveToContent();
		if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0) && xmlTextReader_0.LocalName == "contentTypeSchema")
		{
			return true;
		}
		return false;
	}
}
