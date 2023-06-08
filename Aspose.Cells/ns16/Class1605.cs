using System.Collections;
using System.Xml;
using Aspose.Cells;
using ns2;
using ns22;
using ns25;

namespace ns16;

internal class Class1605
{
	private Class1547 class1547_0;

	private Hashtable hashtable_0;

	private string string_0;

	internal Class1605(Class1547 class1547_1, Hashtable hashtable_1)
	{
		class1547_0 = class1547_1;
		hashtable_0 = hashtable_1;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_13(xmlTextReader_0);
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
			else if (xmlTextReader_0.LocalName == "externalBook")
			{
				method_6(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "oleLink")
			{
				method_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "ddeLink")
			{
				method_3(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_0(XmlTextReader xmlTextReader_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("progId");
		string text = null;
		string attribute2 = xmlTextReader_0.GetAttribute("r:id");
		if (attribute2 != null && hashtable_0 != null)
		{
			Class1564 @class = Class1608.smethod_5(hashtable_0, attribute2);
			text = method_2(@class.string_3);
		}
		Class1718 class2 = new Class1718(Enum194.const_4);
		if (!xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Read();
			while (Class536.smethod_4(xmlTextReader_0))
			{
				if (xmlTextReader_0.LocalName == "oleItems" && !xmlTextReader_0.IsEmptyElement)
				{
					method_1(xmlTextReader_0, class2);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
		}
		else
		{
			xmlTextReader_0.Skip();
		}
		if (attribute != null && text != null)
		{
			class2.method_23(attribute, text);
		}
		int num = class1547_0.workbook_0.Worksheets.method_39().Add(class2);
		class1547_0.workbook_0.Worksheets.method_32().method_3((ushort)num, 65534, 65534);
	}

	[Attribute0(true)]
	private ArrayList method_1(XmlTextReader xmlTextReader_0, Class1718 class1718_0)
	{
		ArrayList arrayList = class1718_0.method_0();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "oleItem")
			{
				Class1653 @class = method_5(xmlTextReader_0, class1718_0);
				if (@class != null)
				{
					arrayList.Add(@class);
				}
			}
			else if (xmlTextReader_0.LocalName == "AlternateContent")
			{
				xmlTextReader_0.Read();
				while (Class536.smethod_4(xmlTextReader_0))
				{
					string localName;
					if ((localName = xmlTextReader_0.LocalName) != null && localName == "Fallback")
					{
						xmlTextReader_0.Read();
						while (Class536.smethod_4(xmlTextReader_0))
						{
							string localName2;
							if ((localName2 = xmlTextReader_0.LocalName) != null && localName2 == "oleItem")
							{
								Class1653 class2 = method_5(xmlTextReader_0, class1718_0);
								if (class2 != null)
								{
									arrayList.Add(class2);
								}
							}
							else
							{
								xmlTextReader_0.Skip();
							}
						}
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return arrayList;
	}

	private string method_2(string string_1)
	{
		return string_1?.Replace("%20", " ");
	}

	[Attribute0(true)]
	private void method_3(XmlTextReader xmlTextReader_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("ddeService");
		string attribute2 = xmlTextReader_0.GetAttribute("ddeTopic");
		Class1718 @class = new Class1718(Enum194.const_3);
		if (!xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Read();
			while (Class536.smethod_4(xmlTextReader_0))
			{
				if (xmlTextReader_0.LocalName == "ddeItems" && !xmlTextReader_0.IsEmptyElement)
				{
					method_4(xmlTextReader_0, @class);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
		}
		else
		{
			xmlTextReader_0.Skip();
		}
		if (attribute != null && attribute2 != null)
		{
			@class.method_21(attribute, attribute2);
		}
		int num = class1547_0.workbook_0.Worksheets.method_39().Add(@class);
		class1547_0.workbook_0.Worksheets.method_32().method_3((ushort)num, 65534, 65534);
	}

	[Attribute0(true)]
	private void method_4(XmlTextReader xmlTextReader_0, Class1718 class1718_0)
	{
		ArrayList arrayList = class1718_0.method_0();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "ddeItem")
			{
				Class1653 @class = method_5(xmlTextReader_0, class1718_0);
				if (@class != null)
				{
					arrayList.Add(@class);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private Class1653 method_5(XmlTextReader xmlTextReader_0, Class1718 class1718_0)
	{
		Class1653 @class = null;
		if (xmlTextReader_0.HasAttributes)
		{
			@class = new Class1653(class1718_0);
			Class1653 class2 = @class;
			class2.method_11((ushort)(class2.method_10() | 0x10u));
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != ""))
				{
					if (xmlTextReader_0.LocalName == "name")
					{
						@class.Name = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "ole")
					{
						@class.method_16(Class1618.smethod_201(xmlTextReader_0.Value));
					}
					else if (xmlTextReader_0.LocalName == "advise")
					{
						@class.method_18(Class1618.smethod_201(xmlTextReader_0.Value));
					}
					else if (xmlTextReader_0.LocalName == "preferPic")
					{
						@class.method_20(Class1618.smethod_201(xmlTextReader_0.Value));
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
		return @class;
	}

	private void method_6(XmlTextReader xmlTextReader_0)
	{
		string string_ = null;
		ArrayList arrayList = null;
		string attribute = xmlTextReader_0.GetAttribute("r:id");
		if (attribute != null && hashtable_0 != null)
		{
			Class1564 @class = Class1608.smethod_5(hashtable_0, attribute);
			string_ = method_2(@class.string_3);
		}
		Class1718 class2 = new Class1718(Enum194.const_0);
		int num = class1547_0.workbook_0.Worksheets.method_39().Add(class2);
		if (!xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Read();
			while (Class536.smethod_4(xmlTextReader_0))
			{
				if (xmlTextReader_0.LocalName == "sheetNames" && !xmlTextReader_0.IsEmptyElement)
				{
					arrayList = method_11(xmlTextReader_0);
					string[] array = new string[arrayList.Count];
					for (int i = 0; i < arrayList.Count; i++)
					{
						array[i] = (string)arrayList[i];
						class1547_0.workbook_0.Worksheets.method_32().method_3((ushort)num, (ushort)i, (ushort)i);
					}
					class2.method_5(array);
				}
				else if (xmlTextReader_0.LocalName == "definedNames" && !xmlTextReader_0.IsEmptyElement)
				{
					method_12(xmlTextReader_0, class2);
				}
				else if (xmlTextReader_0.LocalName == "sheetDataSet" && !xmlTextReader_0.IsEmptyElement)
				{
					method_7(xmlTextReader_0, class2);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
		}
		else
		{
			xmlTextReader_0.Skip();
		}
		class2.method_27(string_);
	}

	private void method_7(XmlTextReader xmlTextReader_0, Class1718 class1718_0)
	{
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "sheetData")
			{
				method_8(xmlTextReader_0, class1718_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_8(XmlTextReader xmlTextReader_0, Class1718 class1718_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("sheetId");
		Class1373 @class = class1718_0.method_9(Class1618.smethod_87(attribute));
		string attribute2 = xmlTextReader_0.GetAttribute("refreshError");
		if (attribute2 != null)
		{
			@class.method_0().Add(Enum129.const_2, attribute2);
		}
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
			else if (xmlTextReader_0.LocalName == "row" && !xmlTextReader_0.IsEmptyElement)
			{
				method_9(xmlTextReader_0, @class);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_9(XmlTextReader xmlTextReader_0, Class1373 class1373_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("r");
		Class1117 row = class1373_0.GetRow(Class1618.smethod_87(attribute) - 1);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "cell" && !xmlTextReader_0.IsEmptyElement)
			{
				method_10(xmlTextReader_0, row);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_10(XmlTextReader xmlTextReader_0, Class1117 class1117_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("r");
		string attribute2 = xmlTextReader_0.GetAttribute("t");
		string text = null;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "v")
			{
				text = xmlTextReader_0.ReadElementString();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		int column = -1;
		int row = -1;
		object object_ = null;
		if (text != null && attribute != null)
		{
			CellsHelper.CellNameToIndex(attribute, out row, out column);
			switch (attribute2)
			{
			case "str":
				object_ = text;
				break;
			case "b":
				object_ = Class1618.smethod_201(text);
				break;
			case "e":
			{
				bool isError = true;
				object_ = Class1673.smethod_3(text, out isError);
				if (!isError)
				{
					object_ = text;
				}
				break;
			}
			default:
				object_ = text;
				break;
			case "n":
			case null:
				object_ = Class1618.smethod_85(text);
				break;
			}
		}
		if (column != -1)
		{
			class1117_0.Add(column, object_);
		}
	}

	[Attribute0(true)]
	private ArrayList method_11(XmlTextReader xmlTextReader_0)
	{
		ArrayList arrayList = new ArrayList();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "sheetName")
			{
				string attribute = xmlTextReader_0.GetAttribute("val");
				xmlTextReader_0.Skip();
				arrayList.Add(attribute);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return arrayList;
	}

	private void method_12(XmlTextReader xmlTextReader_0, Class1718 class1718_0)
	{
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "definedName")
			{
				Class1653 @class = new Class1653(class1718_0);
				@class.Name = xmlTextReader_0.GetAttribute("name");
				string attribute = xmlTextReader_0.GetAttribute("refersTo");
				string attribute2 = xmlTextReader_0.GetAttribute("sheetId");
				xmlTextReader_0.Skip();
				if (attribute2 != null)
				{
					@class.SheetIndex = Class1618.smethod_87(attribute2) + 1;
				}
				if (attribute != null && attribute != "")
				{
					@class.method_8(class1547_0.workbook_0.Worksheets, attribute);
				}
				class1718_0.method_0().Add(@class);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_13(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add("http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		xmlTextReader_0.MoveToContent();
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || !(xmlTextReader_0.LocalName == "externalLink"))
		{
			throw new CellsException(ExceptionType.InvalidData, "externalLink root element eror");
		}
	}
}
