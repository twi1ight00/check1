using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns22;

namespace ns16;

internal class Class1333
{
	private Class1541 class1541_0;

	private ListObject listObject_0;

	internal Class1333(Class1541 class1541_1, ListObject listObject_1)
	{
		listObject_0 = listObject_1;
		class1541_0 = class1541_1;
	}

	[Attribute0(true)]
	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("table");
		xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_0);
		method_4(xmlTextWriter_0);
		if (listObject_0.method_37() != null && listObject_0.method_37().Count > 0)
		{
			Class1596.smethod_2(xmlTextWriter_0, listObject_0.method_37());
		}
		if (listObject_0.dataSorter_0 != null)
		{
			Class1596.smethod_0(xmlTextWriter_0, listObject_0.dataSorter_0);
		}
		method_1(xmlTextWriter_0);
		method_0(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_0(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("tableStyleInfo");
		if (listObject_0.TableStyleName != null && listObject_0.TableStyleName != "None")
		{
			xmlTextWriter_0.WriteAttributeString("name", listObject_0.TableStyleName);
		}
		string value = (listObject_0.ShowTableStyleFirstColumn ? "1" : "0");
		xmlTextWriter_0.WriteAttributeString("showFirstColumn", value);
		value = (listObject_0.ShowTableStyleLastColumn ? "1" : "0");
		xmlTextWriter_0.WriteAttributeString("showLastColumn", value);
		value = (listObject_0.ShowTableStyleRowStripes ? "1" : "0");
		xmlTextWriter_0.WriteAttributeString("showRowStripes", value);
		value = (listObject_0.ShowTableStyleColumnStripes ? "1" : "0");
		xmlTextWriter_0.WriteAttributeString("showColumnStripes", value);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("tableColumns");
		int count = listObject_0.ListColumns.Count;
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
		for (int i = 0; i < count; i++)
		{
			ListColumn listColumn_ = listObject_0.ListColumns[i];
			method_2(xmlTextWriter_0, listColumn_);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_2(XmlTextWriter xmlTextWriter_0, ListColumn listColumn_0)
	{
		xmlTextWriter_0.WriteStartElement("tableColumn");
		int int_ = listColumn_0.Index + 1;
		xmlTextWriter_0.WriteAttributeString("id", Class1618.smethod_80(int_));
		if (listColumn_0.method_14() != null)
		{
			xmlTextWriter_0.WriteAttributeString("uniqueName", Class1618.smethod_5(listColumn_0.method_14()));
		}
		xmlTextWriter_0.WriteAttributeString("name", Class1618.smethod_5(listColumn_0.Name));
		string text = method_6(listColumn_0, 1);
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("dataDxfId", text);
		}
		if (listColumn_0.method_21() != -1)
		{
			xmlTextWriter_0.WriteAttributeString("queryTableFieldId", Class1618.smethod_80(listColumn_0.method_21()));
		}
		if (listColumn_0.TotalsCalculation != 0)
		{
			xmlTextWriter_0.WriteAttributeString("totalsRowFunction", Class1618.smethod_207(listColumn_0.TotalsCalculation));
		}
		if (listColumn_0.method_16() != null)
		{
			xmlTextWriter_0.WriteAttributeString("totalsRowLabel", listColumn_0.method_16());
		}
		text = method_6(listColumn_0, 0);
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("headerRowDxfId", text);
		}
		text = method_6(listColumn_0, 2);
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("totalsRowDxfId", text);
		}
		if (listColumn_0.xmlColumnProperty_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("xmlColumnPr");
			xmlTextWriter_0.WriteAttributeString("mapId", Class1618.smethod_80(listColumn_0.xmlColumnProperty_0.int_0));
			xmlTextWriter_0.WriteAttributeString("xpath", listColumn_0.xmlColumnProperty_0.string_0);
			xmlTextWriter_0.WriteAttributeString("xmlDataType", listColumn_0.xmlColumnProperty_0.string_1);
			xmlTextWriter_0.WriteEndElement();
		}
		if (listColumn_0.method_13() != null)
		{
			xmlTextWriter_0.WriteStartElement("calculatedColumnFormula");
			if (listColumn_0.method_12())
			{
				xmlTextWriter_0.WriteAttributeString("array", "1");
			}
			xmlTextWriter_0.WriteString(listColumn_0.method_13());
			xmlTextWriter_0.WriteEndElement();
		}
		if (listColumn_0.method_10() != null)
		{
			xmlTextWriter_0.WriteStartElement("totalsRowFormula");
			if (listColumn_0.method_12())
			{
				xmlTextWriter_0.WriteAttributeString("array", "1");
			}
			xmlTextWriter_0.WriteString(listColumn_0.method_10());
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_3()
	{
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = listObject_0.StartRow;
		cellArea_.StartColumn = listObject_0.StartColumn;
		cellArea_.EndRow = listObject_0.EndRow;
		if (listObject_0.EndRow - listObject_0.StartRow == 0)
		{
			cellArea_.EndRow++;
		}
		cellArea_.EndColumn = listObject_0.EndColumn;
		return Class1618.smethod_15(cellArea_);
	}

	[Attribute0(true)]
	private void method_4(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteAttributeString("id", Class1618.smethod_80(listObject_0.method_0()));
		string name = listObject_0.Name;
		if (name != null)
		{
			xmlTextWriter_0.WriteAttributeString("name", name);
		}
		name = listObject_0.DisplayName;
		if (name != null)
		{
			xmlTextWriter_0.WriteAttributeString("displayName", name);
		}
		xmlTextWriter_0.WriteAttributeString("ref", method_3());
		if (listObject_0.method_13() != 0)
		{
			xmlTextWriter_0.WriteAttributeString("tableType", Class1618.smethod_209(listObject_0.method_13()));
		}
		name = listObject_0.Comment;
		if (name != null)
		{
			xmlTextWriter_0.WriteAttributeString("comment", name);
		}
		if (listObject_0.method_17())
		{
			xmlTextWriter_0.WriteAttributeString("insertRow", "1");
		}
		int num = ((listObject_0.method_48() == -1) ? 1 : listObject_0.method_48());
		if (num != 1)
		{
			xmlTextWriter_0.WriteAttributeString("headerRowCount", Class1618.smethod_80(num));
		}
		if (!listObject_0.method_19())
		{
			xmlTextWriter_0.WriteAttributeString("totalsRowShown", "0");
		}
		else
		{
			int int_ = ((listObject_0.method_51() <= 1) ? 1 : listObject_0.method_51());
			xmlTextWriter_0.WriteAttributeString("totalsRowCount", Class1618.smethod_80(int_));
		}
		if (listObject_0.method_25())
		{
			xmlTextWriter_0.WriteAttributeString("published", "1");
		}
		name = method_5(0);
		if (name != null)
		{
			xmlTextWriter_0.WriteAttributeString("headerRowDxfId", name);
		}
		name = method_5(1);
		if (name != null)
		{
			xmlTextWriter_0.WriteAttributeString("dataDxfId", name);
		}
		name = method_5(2);
		if (name != null)
		{
			xmlTextWriter_0.WriteAttributeString("totalsRowDxfId", name);
		}
		name = method_5(3);
		if (name != null)
		{
			xmlTextWriter_0.WriteAttributeString("tableBorderDxfId", name);
		}
		name = method_5(4);
		if (name != null)
		{
			xmlTextWriter_0.WriteAttributeString("headerRowBorderDxfId", name);
		}
		name = method_5(5);
		if (name != null)
		{
			xmlTextWriter_0.WriteAttributeString("totalsRowBorderDxfId", name);
		}
		if (listObject_0.method_33() != -1)
		{
			xmlTextWriter_0.WriteAttributeString("connectionId", Class1618.smethod_80(listObject_0.method_33()));
		}
	}

	private string method_5(int int_0)
	{
		if (listObject_0.int_10 != null && int_0 >= 0 && int_0 <= 5)
		{
			if (listObject_0.int_10[int_0] != -1)
			{
				return Class1618.smethod_80(listObject_0.int_10[int_0]);
			}
			return null;
		}
		return null;
	}

	private string method_6(ListColumn listColumn_0, int int_0)
	{
		if (listColumn_0.int_3 != null && int_0 >= 0 && int_0 <= 2)
		{
			if (listColumn_0.int_3[int_0] != -1)
			{
				return Class1618.smethod_80(listColumn_0.int_3[int_0]);
			}
			return null;
		}
		return null;
	}
}
