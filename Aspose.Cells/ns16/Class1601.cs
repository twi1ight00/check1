using System.Collections.Generic;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Properties;
using ns1;
using ns22;

namespace ns16;

internal class Class1601
{
	private Class1547 class1547_0;

	private string string_0;

	private string string_1;

	internal Class1601(Class1547 class1547_1)
	{
		class1547_0 = class1547_1;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_1(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		BuiltInDocumentPropertyCollection builtInDocumentProperties = class1547_0.workbook_0.Worksheets.BuiltInDocumentProperties;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
				continue;
			}
			string localName;
			if ((localName = xmlTextReader_0.LocalName) != null)
			{
				if (Class1742.dictionary_129 == null)
				{
					Class1742.dictionary_129 = new Dictionary<string, int>(14)
					{
						{ "Application", 0 },
						{ "Manager", 1 },
						{ "Company", 2 },
						{ "HyperlinkBase", 3 },
						{ "AppVersion", 4 },
						{ "DocSecurity", 5 },
						{ "Template", 6 },
						{ "Pages", 7 },
						{ "Words", 8 },
						{ "Characters", 9 },
						{ "Lines", 10 },
						{ "Paragraphs", 11 },
						{ "TotalTime", 12 },
						{ "CharactersWithSpaces", 13 }
					};
				}
				if (Class1742.dictionary_129.TryGetValue(localName, out var value))
				{
					switch (value)
					{
					case 0:
						builtInDocumentProperties.NameOfApplication = xmlTextReader_0.ReadElementString();
						continue;
					case 1:
						builtInDocumentProperties.Manager = xmlTextReader_0.ReadElementString();
						continue;
					case 2:
						builtInDocumentProperties.Company = xmlTextReader_0.ReadElementString();
						continue;
					case 3:
						builtInDocumentProperties.HyperlinkBase = xmlTextReader_0.ReadElementString();
						continue;
					case 4:
					{
						string string_ = xmlTextReader_0.ReadElementString();
						try
						{
							builtInDocumentProperties.Version = (int)Class1618.smethod_85(string_);
						}
						catch
						{
						}
						continue;
					}
					case 5:
					{
						int num3 = method_0(xmlTextReader_0);
						if (num3 != -1)
						{
							builtInDocumentProperties.method_1(num3);
						}
						continue;
					}
					case 6:
						builtInDocumentProperties.Template = xmlTextReader_0.ReadElementString();
						continue;
					case 7:
					{
						int num8 = method_0(xmlTextReader_0);
						if (num8 != -1)
						{
							builtInDocumentProperties.Pages = num8;
						}
						continue;
					}
					case 8:
					{
						int num7 = method_0(xmlTextReader_0);
						if (num7 != -1)
						{
							builtInDocumentProperties.Words = num7;
						}
						continue;
					}
					case 9:
					{
						int num6 = method_0(xmlTextReader_0);
						if (num6 != -1)
						{
							builtInDocumentProperties.Characters = num6;
						}
						continue;
					}
					case 10:
					{
						int num5 = method_0(xmlTextReader_0);
						if (num5 != -1)
						{
							builtInDocumentProperties.Lines = num5;
						}
						continue;
					}
					case 11:
					{
						int num4 = method_0(xmlTextReader_0);
						if (num4 != -1)
						{
							builtInDocumentProperties.Paragraphs = num4;
						}
						continue;
					}
					case 12:
					{
						int num2 = method_0(xmlTextReader_0);
						if (num2 != -1)
						{
							builtInDocumentProperties.TotalEditingTime = (double)num2 / 60.0;
						}
						continue;
					}
					case 13:
					{
						int num = method_0(xmlTextReader_0);
						if (num != -1)
						{
							builtInDocumentProperties.CharactersWithSpaces = num;
						}
						continue;
					}
					}
				}
			}
			xmlTextReader_0.Skip();
		}
	}

	[Attribute0(true)]
	private int method_0(XmlTextReader xmlTextReader_0)
	{
		int num = -1;
		string string_ = xmlTextReader_0.ReadElementString();
		try
		{
			return Class1618.smethod_87(string_);
		}
		catch
		{
			return -1;
		}
	}

	private void method_1(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add("http://schemas.openxmlformats.org/officeDocument/2006/extended-properties");
		string_1 = nameTable.Add("http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
		xmlTextReader_0.MoveToContent();
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || !object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0) || !(xmlTextReader_0.LocalName == "Properties"))
		{
			throw new CellsException(ExceptionType.InvalidData, "DocPropsApp root element eror");
		}
	}
}
