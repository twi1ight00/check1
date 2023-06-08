using System;
using System.Globalization;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Properties;

namespace ns16;

internal class Class1602
{
	private Class1547 class1547_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	internal Class1602(Class1547 class1547_1)
	{
		class1547_0 = class1547_1;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_0(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		BuiltInDocumentPropertyCollection builtInDocumentProperties = class1547_0.workbook_0.Worksheets.BuiltInDocumentProperties;
		xmlTextReader_0.Read();
		try
		{
			while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
			{
				xmlTextReader_0.MoveToContent();
				if (xmlTextReader_0.NodeType != XmlNodeType.Element)
				{
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "title" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_1))
				{
					builtInDocumentProperties.Title = xmlTextReader_0.ReadElementString();
				}
				else if (xmlTextReader_0.LocalName == "creator" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_1))
				{
					builtInDocumentProperties.Author = xmlTextReader_0.ReadElementString();
				}
				else if (xmlTextReader_0.LocalName == "subject" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_1))
				{
					builtInDocumentProperties.Subject = xmlTextReader_0.ReadElementString();
				}
				else if (xmlTextReader_0.LocalName == "description" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_1))
				{
					builtInDocumentProperties.Comments = xmlTextReader_0.ReadElementString();
				}
				else if (xmlTextReader_0.LocalName == "lastModifiedBy" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
				{
					builtInDocumentProperties.LastSavedBy = xmlTextReader_0.ReadElementString();
				}
				else if (xmlTextReader_0.LocalName == "keywords" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
				{
					builtInDocumentProperties.Keywords = xmlTextReader_0.ReadElementString();
				}
				else if (xmlTextReader_0.LocalName == "category" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
				{
					builtInDocumentProperties.Category = xmlTextReader_0.ReadElementString();
				}
				else if (xmlTextReader_0.LocalName == "contentType" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
				{
					builtInDocumentProperties.ContentType = xmlTextReader_0.ReadElementString();
				}
				else if (xmlTextReader_0.LocalName == "contentStatus" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
				{
					builtInDocumentProperties.ContentStatus = xmlTextReader_0.ReadElementString();
				}
				else if (xmlTextReader_0.LocalName == "revision")
				{
					try
					{
						builtInDocumentProperties.RevisionNumber = Class1618.smethod_87(xmlTextReader_0.ReadElementString());
					}
					catch
					{
					}
				}
				else if (xmlTextReader_0.LocalName == "lastPrinted" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
				{
					string text = xmlTextReader_0.ReadElementString();
					if (text.Length > 0)
					{
						DateTime lastPrinted = DateTime.ParseExact(text, "yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture);
						builtInDocumentProperties.LastPrinted = lastPrinted;
					}
				}
				else if (xmlTextReader_0.LocalName == "created" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_2))
				{
					string text2 = xmlTextReader_0.ReadElementString();
					if (text2.Length > 0)
					{
						DateTime createdTime = DateTime.ParseExact(text2, "yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture);
						builtInDocumentProperties.CreatedTime = createdTime;
					}
				}
				else if (xmlTextReader_0.LocalName == "modified" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_2))
				{
					string text3 = xmlTextReader_0.ReadElementString();
					if (text3.Length > 0)
					{
						DateTime lastSavedTime = DateTime.ParseExact(text3, "yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture);
						builtInDocumentProperties.LastSavedTime = lastSavedTime;
					}
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
		}
		catch
		{
		}
	}

	private void method_0(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add("http://schemas.openxmlformats.org/package/2006/metadata/core-properties");
		string_1 = nameTable.Add("http://purl.org/dc/elements/1.1/");
		string_2 = nameTable.Add("http://purl.org/dc/terms/");
		string_3 = nameTable.Add("http://purl.org/dc/dcmitype/");
		string_4 = nameTable.Add("http://www.w3.org/2001/XMLSchema-instance");
		xmlTextReader_0.MoveToContent();
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || !object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0) || !(xmlTextReader_0.LocalName == "coreProperties"))
		{
			throw new CellsException(ExceptionType.InvalidData, "coreProperties root element eror");
		}
	}
}
