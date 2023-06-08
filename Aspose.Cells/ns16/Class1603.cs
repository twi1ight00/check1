using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Properties;
using ns1;

namespace ns16;

internal class Class1603
{
	private Class1547 class1547_0;

	private string string_0;

	private string string_1;

	private CustomDocumentPropertyCollection customDocumentPropertyCollection_0;

	internal Class1603(Class1547 class1547_1)
	{
		class1547_0 = class1547_1;
		customDocumentPropertyCollection_0 = class1547_0.workbook_0.Worksheets.CustomDocumentProperties;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_2(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
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
			else if (xmlTextReader_0.LocalName == "property")
			{
				method_0(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	internal void method_0(XmlTextReader xmlTextReader_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("name");
		if (!xmlTextReader_0.IsEmptyElement && attribute != null && attribute.Length != 0)
		{
			DocumentProperty documentProperty_ = null;
			string attribute2 = xmlTextReader_0.GetAttribute("linkTarget");
			if (attribute2 != null)
			{
				documentProperty_ = customDocumentPropertyCollection_0.AddLinkToContent(attribute, attribute2);
			}
			xmlTextReader_0.Read();
			while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
			{
				xmlTextReader_0.MoveToContent();
				if (xmlTextReader_0.NodeType != XmlNodeType.Element)
				{
					xmlTextReader_0.Skip();
				}
				else if (object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_1))
				{
					string localName = xmlTextReader_0.LocalName;
					string string_ = Class1618.smethod_8(xmlTextReader_0.ReadElementString());
					method_1(documentProperty_, attribute, string_, localName);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			xmlTextReader_0.ReadEndElement();
		}
		else
		{
			xmlTextReader_0.Skip();
		}
	}

	private void method_1(DocumentProperty documentProperty_0, string string_2, string string_3, string string_4)
	{
		try
		{
			string key;
			if ((key = string_4) != null)
			{
				if (Class1742.dictionary_130 == null)
				{
					Class1742.dictionary_130 = new Dictionary<string, int>(8)
					{
						{ "filetime", 0 },
						{ "i1", 1 },
						{ "i2", 2 },
						{ "i4", 3 },
						{ "r4", 4 },
						{ "r8", 5 },
						{ "bool", 6 },
						{ "lpwstr", 7 }
					};
				}
				if (Class1742.dictionary_130.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
					{
						DateTime dateTime = DateTime.ParseExact(string_3, "yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture);
						if (documentProperty_0 == null)
						{
							customDocumentPropertyCollection_0.Add(string_2, dateTime);
						}
						else
						{
							documentProperty_0.Value = dateTime;
						}
						return;
					}
					case 1:
					case 2:
					case 3:
					{
						int num2 = Class1618.smethod_87(string_3);
						if (documentProperty_0 == null)
						{
							customDocumentPropertyCollection_0.Add(string_2, num2);
						}
						else
						{
							documentProperty_0.Value = num2;
						}
						return;
					}
					case 4:
					case 5:
					{
						double num = Class1618.smethod_85(string_3);
						if (documentProperty_0 == null)
						{
							customDocumentPropertyCollection_0.Add(string_2, num);
						}
						else
						{
							documentProperty_0.Value = num;
						}
						return;
					}
					case 6:
					{
						bool flag = (string_3.ToLower().Equals("true") ? true : false);
						if (documentProperty_0 == null)
						{
							customDocumentPropertyCollection_0.Add(string_2, flag);
						}
						else
						{
							documentProperty_0.Value = flag;
						}
						return;
					}
					}
				}
			}
			if (documentProperty_0 == null)
			{
				customDocumentPropertyCollection_0.Add(string_2, string_3);
			}
			else
			{
				documentProperty_0.Value = string_3;
			}
		}
		catch
		{
			if (documentProperty_0 == null)
			{
				customDocumentPropertyCollection_0.Add(string_2, string_3);
			}
			else
			{
				documentProperty_0.Value = string_3;
			}
		}
	}

	private void method_2(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add("http://schemas.openxmlformats.org/officeDocument/2006/custom-properties");
		string_1 = nameTable.Add("http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
		xmlTextReader_0.MoveToContent();
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || !object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0) || !(xmlTextReader_0.LocalName == "Properties"))
		{
			throw new CellsException(ExceptionType.InvalidData, "DocPropsCustom root element eror");
		}
	}
}
