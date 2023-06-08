using System.Xml;
using Aspose.Cells;
using ns29;

namespace ns16;

internal class Class1369
{
	private Class1547 class1547_0;

	private string string_0;

	private string string_1;

	private int int_0;

	internal Class1369(Class1547 class1547_1)
	{
		class1547_0 = class1547_1;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_3(xmlTextReader_0);
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
			else if (xmlTextReader_0.LocalName == "sheets" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "definedNames" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_1(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		class1547_0.workbook_0.Worksheets.ActiveSheetIndex = int_0;
	}

	private void method_0(XmlTextReader xmlTextReader_0)
	{
		class1547_0.workbook_0.Worksheets.Clear();
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1129.smethod_1();
		int num = 0;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else
			{
				if (!(xmlTextReader_0.LocalName == "sheet") || !object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0) || !xmlTextReader_0.HasAttributes)
				{
					continue;
				}
				string text = null;
				string text2 = null;
				string text3 = null;
				string text4 = null;
				string text5 = null;
				while (xmlTextReader_0.MoveToNextAttribute())
				{
					if (xmlTextReader_0.LocalName == "name" && xmlTextReader_0.NamespaceURI == "")
					{
						text = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "sheetId" && xmlTextReader_0.NamespaceURI == "")
					{
						Class1618.smethod_87(xmlTextReader_0.Value);
						text2 = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "id" && object.ReferenceEquals(string_1, xmlTextReader_0.NamespaceURI))
					{
						text3 = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "type" && xmlTextReader_0.NamespaceURI == "")
					{
						text4 = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "state")
					{
						text5 = xmlTextReader_0.Value;
					}
				}
				if (text4 == null || text4 == "chartsheet")
				{
					if (text == null || text.Length == 0 || text3 == null || text3.Length == 0 || text2 == null)
					{
						throw new CellsException(ExceptionType.InvalidData, "invalid sheet attributes data");
					}
					Worksheet worksheet = class1547_0.workbook_0.Worksheets[class1547_0.workbook_0.Worksheets.Add()];
					worksheet.method_7(text);
					switch (text5)
					{
					case "hidden":
						worksheet.method_28(bool_1: false, bool_2: false);
						break;
					case "veryHidden":
						worksheet.method_28(bool_1: false, bool_2: true);
						break;
					}
					class1547_0.method_0(worksheet, num, text2, text3);
				}
				xmlTextReader_0.MoveToElement();
				xmlTextReader_0.Skip();
				num++;
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_1(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		WorksheetCollection worksheets = class1547_0.workbook_0.Worksheets;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else
			{
				if (!(xmlTextReader_0.LocalName == "definedName") || !object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
				{
					continue;
				}
				int num = -1;
				bool isHidden = false;
				string text = null;
				string text2 = null;
				if (xmlTextReader_0.HasAttributes)
				{
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						if (xmlTextReader_0.LocalName == "name" && xmlTextReader_0.NamespaceURI == "")
						{
							text = xmlTextReader_0.Value;
						}
						else if (xmlTextReader_0.LocalName == "localSheetId" && xmlTextReader_0.NamespaceURI == "")
						{
							num = Class1618.smethod_87(xmlTextReader_0.Value);
						}
						else if (xmlTextReader_0.LocalName == "hidden" && xmlTextReader_0.NamespaceURI == "")
						{
							isHidden = ((xmlTextReader_0.Value == "1") ? true : false);
						}
					}
					xmlTextReader_0.MoveToElement();
				}
				text2 = xmlTextReader_0.ReadElementString();
				if (text == null || text2 == null)
				{
					throw new CellsException(ExceptionType.InvalidData, "Invalid name data");
				}
				if (text2.ToUpper().IndexOf("#REF") != -1 || text2.IndexOf('[') != -1)
				{
					continue;
				}
				if (text.ToUpper().Equals("_xlnm.Print_Area".ToUpper()) && class1547_0.method_8().ContainsKey(num))
				{
					Worksheet worksheet = class1547_0.method_1(num);
					int num2 = text2.IndexOf('!');
					text2 = text2.Substring(num2 + 1);
					worksheet.PageSetup.PrintArea = text2;
					continue;
				}
				if (text.ToUpper().Equals("_xlnm.Print_Titles".ToUpper()) && class1547_0.method_8().ContainsKey(num))
				{
					Worksheet worksheet2 = class1547_0.method_1(num);
					int num3 = text2.IndexOf(',');
					if (num3 != -1)
					{
						string text3 = text2.Substring(0, num3);
						int startIndex = text3.IndexOf('!') + 1;
						worksheet2.PageSetup.PrintTitleColumns = text3.Substring(startIndex);
						text3 = text2.Substring(num3 + 1);
						startIndex = text3.IndexOf('!') + 1;
						worksheet2.PageSetup.PrintTitleRows = text3.Substring(startIndex);
					}
					else
					{
						int startIndex2 = text2.IndexOf('!') + 1;
						string text4 = text2.Substring(startIndex2);
						if (method_2(text4))
						{
							worksheet2.PageSetup.PrintTitleRows = text4;
						}
						else
						{
							worksheet2.PageSetup.PrintTitleColumns = text4;
						}
					}
					continue;
				}
				string text5 = text.ToUpper();
				bool flag;
				if (flag = text5.StartsWith("_XLNM."))
				{
					text = text.Substring(6);
					text5 = text.ToUpper();
				}
				if (num != -1)
				{
					num = class1547_0.method_1(num).Index;
				}
				int index = worksheets.Names.method_0(num, text);
				Name name = worksheets.Names[index];
				if (flag)
				{
					name.method_15(text5);
				}
				name.RefersTo = "=" + text2;
				name.IsHidden = isHidden;
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private bool method_2(string string_2)
	{
		for (int i = 0; i < string_2.Length; i++)
		{
			switch (string_2[i])
			{
			case '$':
			case ':':
				break;
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				return true;
			default:
				return false;
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid Print_Titles range");
	}

	private void method_3(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || xmlTextReader_0.LocalName != "workbook")
		{
			throw new CellsException(ExceptionType.InvalidData, "workbook root element eror");
		}
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add(namespaceURI);
		string_1 = nameTable.Add("http://schemas.openxmlformats.org/officeDocument/2006/relationships");
	}
}
