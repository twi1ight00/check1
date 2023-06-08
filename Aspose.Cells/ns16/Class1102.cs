using System;
using System.Xml;
using Aspose.Cells;
using ns2;
using ns22;
using ns45;

namespace ns16;

internal class Class1102
{
	private string string_0;

	private Class1142 class1142_0;

	private Class1141 class1141_0;

	private Workbook workbook_0;

	private string string_1;

	private Class746 class746_0;

	private Class1547 class1547_0;

	internal Class1102(Class1547 class1547_1, Class1141 class1141_1, string string_2, Class746 class746_1)
	{
		class1547_0 = class1547_1;
		string_0 = string_2;
		class1142_0 = class1547_1.workbook_0.Worksheets.method_89();
		class1141_0 = class1141_1;
		workbook_0 = class1547_1.workbook_0;
		class746_0 = class746_1;
	}

	[Attribute0(true)]
	internal void Read(XmlTextReader xmlTextReader_0)
	{
		int num = 0;
		if (class1141_0.class1144_0 != null)
		{
			class1141_0.class1144_0.method_0();
		}
		method_1(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "r" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_0(xmlTextReader_0, num);
				num++;
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_0(XmlTextReader xmlTextReader_0, int int_0)
	{
		int num = 0;
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "x" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				xmlTextReader_0.GetAttribute("v");
				if (class1141_0.class1144_0 != null && int_0 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_0]).Length)
				{
					((object[])class1141_0.class1144_0.arrayList_0[int_0])[num] = Class1618.smethod_87(xmlTextReader_0.GetAttribute("v"));
					num++;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "s" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				if (class1141_0.class1144_0 != null && int_0 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_0]).Length)
				{
					((object[])class1141_0.class1144_0.arrayList_0[int_0])[num] = xmlTextReader_0.GetAttribute("v");
					num++;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "n" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				if (class1141_0.class1144_0 != null && int_0 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_0]).Length)
				{
					string attribute = xmlTextReader_0.GetAttribute("v");
					if (Class1677.smethod_18(attribute))
					{
						((object[])class1141_0.class1144_0.arrayList_0[int_0])[num] = Class1618.smethod_85(attribute);
						num++;
					}
					else
					{
						((object[])class1141_0.class1144_0.arrayList_0[int_0])[num] = 0;
						num++;
					}
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "d" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				if (class1141_0.class1144_0 != null && int_0 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_0]).Length)
				{
					((object[])class1141_0.class1144_0.arrayList_0[int_0])[num] = Convert.ToDateTime(xmlTextReader_0.GetAttribute("v"));
					num++;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "b" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				if (class1141_0.class1144_0 != null && int_0 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_0]).Length)
				{
					((object[])class1141_0.class1144_0.arrayList_0[int_0])[num] = xmlTextReader_0.GetAttribute("v") == "1";
					num++;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "m" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				if (class1141_0.class1144_0 != null && int_0 < class1141_0.class1144_0.arrayList_0.Count && num < ((object[])class1141_0.class1144_0.arrayList_0[int_0]).Length)
				{
					((object[])class1141_0.class1144_0.arrayList_0[int_0])[num] = null;
					num++;
				}
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_1(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || xmlTextReader_0.LocalName != "pivotCacheRecords")
		{
			throw new ApplicationException("pivotCacheRecords root element eror");
		}
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_1 = nameTable.Add(namespaceURI);
	}
}
