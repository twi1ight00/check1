using System.Xml;
using Aspose.Cells.Properties;

namespace ns16;

internal class Class532
{
	private Class1547 class1547_0;

	private string string_0;

	private string string_1;

	private ContentTypePropertyCollection contentTypePropertyCollection_0;

	internal Class532(Class1547 class1547_1)
	{
		class1547_0 = class1547_1;
		contentTypePropertyCollection_0 = class1547_0.workbook_0.ContentTypeProperties;
	}

	internal bool Read(XmlTextReader xmlTextReader_0, int int_0)
	{
		if (!method_1(xmlTextReader_0, int_0))
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
			else if (int_0 == 1)
			{
				method_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "documentManagement")
			{
				method_0(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		return true;
	}

	internal void method_0(XmlTextReader xmlTextReader_0)
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
			else if (!xmlTextReader_0.IsEmptyElement)
			{
				ContentTypeProperty contentTypeProperty = new ContentTypeProperty(contentTypePropertyCollection_0);
				contentTypeProperty.string_0 = xmlTextReader_0.NamespaceURI;
				contentTypeProperty.Name = xmlTextReader_0.LocalName;
				contentTypeProperty.Value = xmlTextReader_0.ReadInnerXml();
				contentTypePropertyCollection_0.Add(contentTypeProperty);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private bool method_1(XmlTextReader xmlTextReader_0, int int_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add("http://schemas.microsoft.com/office/2006/metadata/properties");
		string_1 = nameTable.Add("http://www.w3.org/2001/XMLSchema-instance");
		xmlTextReader_0.MoveToContent();
		if ((xmlTextReader_0.NodeType != XmlNodeType.Element || !object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0) || !(xmlTextReader_0.LocalName == "properties")) && int_0 != 1)
		{
			return false;
		}
		return true;
	}
}
