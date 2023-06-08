using System;
using System.Runtime.CompilerServices;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns22;

namespace ns16;

internal class Class1334
{
	private Class1547 class1547_0;

	private Class1548 class1548_0;

	private string string_0;

	private Worksheet worksheet_0;

	private ListObject listObject_0;

	[SpecialName]
	public ListObject method_0()
	{
		return listObject_0;
	}

	internal Class1334(Class1548 class1548_1)
	{
		class1547_0 = class1548_1.class1547_0;
		class1548_0 = class1548_1;
		worksheet_0 = class1548_0.worksheet_0;
	}

	[Attribute0(true)]
	private void method_1(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			return;
		}
		string attribute = xmlTextReader_0.GetAttribute("ref");
		if (attribute != null)
		{
			CellArea cellArea = Class1618.smethod_17(attribute);
			listObject_0 = new ListObject(worksheet_0.ListObjects);
			listObject_0.method_2(cellArea.StartRow);
			listObject_0.method_3(cellArea.StartColumn);
			listObject_0.method_4(cellArea.EndRow);
			listObject_0.method_5(cellArea.EndColumn);
			worksheet_0.ListObjects.Add(listObject_0);
			string text = null;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "id")
				{
					listObject_0.method_46(Class1618.smethod_87(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "name")
				{
					listObject_0.method_47(xmlTextReader_0.Value);
				}
				if (xmlTextReader_0.LocalName == "displayName")
				{
					listObject_0.DisplayName = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "comment")
				{
					listObject_0.Comment = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "insertRow")
				{
					listObject_0.method_18(Class1618.smethod_201(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "headerRowCount")
				{
					listObject_0.method_49(Class1618.smethod_87(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "totalsRowCount")
				{
					text = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "totalsRowShown")
				{
					_ = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "published")
				{
					listObject_0.method_26(Class1618.smethod_201(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "headerRowDxfId")
				{
					listObject_0.int_10[0] = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "dataDxfId")
				{
					listObject_0.int_10[1] = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "totalsRowDxfId")
				{
					listObject_0.int_10[2] = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "tableBorderDxfId")
				{
					listObject_0.int_10[3] = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "headerRowBorderDxfId")
				{
					listObject_0.int_10[4] = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "totalsRowBorderDxfId")
				{
					listObject_0.int_10[5] = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "connectionId")
				{
					listObject_0.method_34(Class1618.smethod_87(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "tableType")
				{
					listObject_0.method_14(Class1618.smethod_208(xmlTextReader_0.Value));
				}
			}
			xmlTextReader_0.MoveToElement();
			if (text != null)
			{
				listObject_0.method_52(Class1618.smethod_87(text));
				if (listObject_0.method_51() == 0)
				{
					listObject_0.method_20(bool_0: false);
				}
				else
				{
					listObject_0.method_20(bool_0: true);
				}
			}
		}
		else
		{
			xmlTextReader_0.MoveToElement();
		}
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_6(xmlTextReader_0);
		method_1(xmlTextReader_0);
		if (listObject_0 != null && !xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Read();
			while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
			{
				xmlTextReader_0.MoveToContent();
				if (xmlTextReader_0.NodeType != XmlNodeType.Element)
				{
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "autoFilter")
				{
					Class1617.smethod_3(xmlTextReader_0, listObject_0.AutoFilter);
				}
				else if (xmlTextReader_0.LocalName == "tableColumns")
				{
					method_3(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "tableStyleInfo")
				{
					method_2(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "sortState")
				{
					listObject_0.dataSorter_0 = new DataSorter(class1547_0.workbook_0);
					Class1617.smethod_0(xmlTextReader_0, listObject_0.dataSorter_0);
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

	[Attribute0(true)]
	private void method_2(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return;
		}
		listObject_0.TableStyleName = "None";
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (xmlTextReader_0.LocalName == "name")
			{
				listObject_0.TableStyleName = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "showFirstColumn")
			{
				listObject_0.ShowTableStyleFirstColumn = Class1618.smethod_201(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "showLastColumn")
			{
				listObject_0.ShowTableStyleLastColumn = Class1618.smethod_201(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "showRowStripes")
			{
				listObject_0.ShowTableStyleRowStripes = Class1618.smethod_201(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "showColumnStripes")
			{
				listObject_0.ShowTableStyleColumnStripes = Class1618.smethod_201(xmlTextReader_0.Value);
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_3(XmlTextReader xmlTextReader_0)
	{
		listObject_0.method_6(new ListColumnCollection(listObject_0));
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int num = 0;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "tableColumn")
			{
				method_5(xmlTextReader_0, num++);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_4(XmlTextReader xmlTextReader_0, ListColumn listColumn_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			return;
		}
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (xmlTextReader_0.LocalName == "dataDxfId")
			{
				listColumn_0.int_3[1] = Class1618.smethod_87(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "uniqueName")
			{
				listColumn_0.method_15(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "queryTableFieldId")
			{
				listColumn_0.method_22(Class1618.smethod_87(xmlTextReader_0.Value));
			}
			else if (xmlTextReader_0.LocalName == "totalsRowFunction")
			{
				listColumn_0.method_6(Class1618.smethod_206(xmlTextReader_0.Value));
			}
			else if (xmlTextReader_0.LocalName == "totalsRowLabel")
			{
				listColumn_0.method_17(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "headerRowDxfId")
			{
				listColumn_0.int_3[0] = Class1618.smethod_87(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "totalsRowDxfId")
			{
				listColumn_0.int_3[2] = Class1618.smethod_87(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "id")
			{
				listColumn_0.int_5 = Class1618.smethod_87(xmlTextReader_0.Value);
			}
		}
		xmlTextReader_0.MoveToElement();
	}

	[Attribute0(true)]
	private void method_5(XmlTextReader xmlTextReader_0, int int_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("name");
		if (attribute == null)
		{
			return;
		}
		ListColumn listColumn = new ListColumn(listObject_0.ListColumns, Class1618.smethod_8(attribute), int_0);
		listObject_0.ListColumns.Add(listColumn);
		method_4(xmlTextReader_0, listColumn);
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
			else if (xmlTextReader_0.LocalName == "calculatedColumnFormula")
			{
				string attribute2 = xmlTextReader_0.GetAttribute("array");
				string string_ = xmlTextReader_0.ReadElementString();
				bool bool_ = false;
				if (attribute2 != null)
				{
					bool_ = Class1618.smethod_201(attribute2);
				}
				listColumn.method_11(string_, bool_);
			}
			else if (xmlTextReader_0.LocalName == "xmlColumnPr")
			{
				listColumn.xmlColumnProperty_0 = new XmlColumnProperty();
				listColumn.xmlColumnProperty_0.int_0 = Class1618.smethod_87(xmlTextReader_0.GetAttribute("mapId"));
				listColumn.xmlColumnProperty_0.string_0 = xmlTextReader_0.GetAttribute("xpath");
				listColumn.xmlColumnProperty_0.string_1 = xmlTextReader_0.GetAttribute("xmlDataType");
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "totalsRowFormula")
			{
				string attribute3 = xmlTextReader_0.GetAttribute("array");
				string string_2 = xmlTextReader_0.ReadElementString();
				bool bool_2 = false;
				if (attribute3 != null)
				{
					bool_2 = Class1618.smethod_201(attribute3);
				}
				listColumn.method_9(string_2, bool_2);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_6(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || xmlTextReader_0.LocalName != "table")
		{
			throw new ApplicationException("Table root element eror");
		}
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add(namespaceURI);
	}
}
