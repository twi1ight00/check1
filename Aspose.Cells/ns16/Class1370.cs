using System.Collections;
using System.Runtime.CompilerServices;
using System.Xml;
using Aspose.Cells;

namespace ns16;

internal class Class1370
{
	private Class1547 class1547_0;

	private string string_0;

	private string string_1;

	private Worksheet worksheet_0;

	private Class1548 class1548_0;

	private Hashtable hashtable_0;

	private bool bool_0;

	private Class1610 class1610_0;

	internal Class1370(Class1547 class1547_1, Class1548 class1548_1, bool bool_1)
	{
		class1547_0 = class1547_1;
		class1548_0 = class1548_1;
		worksheet_0 = class1548_1.worksheet_0;
		hashtable_0 = new Hashtable();
		bool_0 = bool_1;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_7(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				switch (xmlTextReader_0.LocalName)
				{
				case "sheetData":
					method_0(xmlTextReader_0);
					break;
				case "cols":
					method_5(xmlTextReader_0);
					break;
				default:
					xmlTextReader_0.Skip();
					break;
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	private void method_0(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int int_ = -1;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (!(xmlTextReader_0.LocalName == "row"))
				{
					xmlTextReader_0.Skip();
					throw new CellsException(ExceptionType.InvalidData, "Invalid sheetData sub Element " + xmlTextReader_0.LocalName);
				}
				int_ = method_1(xmlTextReader_0, int_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private int method_1(XmlTextReader xmlTextReader_0, int int_0)
	{
		int num = int_0 + 1;
		int num2 = -1;
		double num3 = -1.0;
		bool flag = false;
		bool flag2 = false;
		bool isHidden = false;
		bool flag3 = false;
		short num4 = -1;
		bool bool_ = false;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.NamespaceURI != "")
				{
					continue;
				}
				if (xmlTextReader_0.LocalName == "r")
				{
					num = Class1618.smethod_87(xmlTextReader_0.Value) - 1;
				}
				else if (xmlTextReader_0.LocalName == "s")
				{
					num2 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "customFormat" && xmlTextReader_0.Value == "1")
				{
					flag = true;
				}
				else if (xmlTextReader_0.LocalName == "ht")
				{
					num3 = Class1618.smethod_85(xmlTextReader_0.Value);
					if (num3 > 409.5)
					{
						num3 = 409.5;
					}
					flag3 = true;
				}
				else if (xmlTextReader_0.LocalName == "customHeight" && xmlTextReader_0.Value == "1")
				{
					flag2 = true;
				}
				else if (xmlTextReader_0.LocalName == "hidden" && xmlTextReader_0.Value == "1")
				{
					isHidden = true;
				}
				else if (xmlTextReader_0.LocalName == "outlineLevel")
				{
					num4 = Class1618.smethod_89(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "collapsed" && xmlTextReader_0.Value == "1")
				{
					bool_ = true;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		Row row = worksheet_0.Cells.Rows.method_1(num, 16);
		if (num2 != -1 && flag)
		{
			object obj = class1547_0.hashtable_3[num2];
			if (obj == null)
			{
				throw new CellsException(ExceptionType.InvalidData, "Invalid row style Idx, rowid:" + num);
			}
			row.method_11((int)obj);
			row.method_21(bool_1: true);
		}
		row.method_19(bool_);
		if (num4 != -1)
		{
			row.method_25((byte)num4);
		}
		if (flag3)
		{
			if (flag2)
			{
				worksheet_0.Cells.SetRowHeight(num, num3);
			}
			else
			{
				row.method_14((ushort)(num3 * 20.0));
				row.IsHeightMatched = true;
			}
		}
		row.IsHidden = isHidden;
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return num;
		}
		int int_ = -1;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "c")
			{
				int_ = method_3(xmlTextReader_0, row, num, int_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return num;
	}

	[SpecialName]
	internal void method_2(Class1610 class1610_1)
	{
		class1610_0 = class1610_1;
	}

	private int method_3(XmlTextReader xmlTextReader_0, Row row_0, int int_0, int int_1)
	{
		int num = -1;
		string text = "n";
		string text2 = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != ""))
				{
					if (xmlTextReader_0.LocalName == "r")
					{
						text2 = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "s")
					{
						num = Class1618.smethod_87(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "t")
					{
						text = xmlTextReader_0.Value;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		int column = int_1 + 1;
		if (text2 != null)
		{
			CellsHelper.CellNameToIndex(text2, out var row, out column);
			if (int_0 != row || column < int_1 + 1)
			{
				throw new CellsException(ExceptionType.InvalidData, "Invalid cell name");
			}
		}
		Cell cell = row_0.GetCell(worksheet_0.Cells.Rows, column, bool_1: false, bool_2: false, bool_3: false, 0);
		int_1 = column;
		if (num != -1)
		{
			int int_2 = (int)class1547_0.hashtable_3[num];
			cell.method_37(int_2);
		}
		else
		{
			cell.method_37(15);
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			if (cell.method_46())
			{
				cell.method_6();
			}
			xmlTextReader_0.Skip();
			return int_1;
		}
		bool flag = true;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (bool_0 && xmlTextReader_0.LocalName == "f")
				{
					flag = false;
					string attribute = xmlTextReader_0.GetAttribute("t");
					if (!(attribute == "array") && !(attribute == "shared"))
					{
						string text3 = xmlTextReader_0.ReadElementString();
						cell.Formula = "=" + text3;
						continue;
					}
					string attribute2 = xmlTextReader_0.GetAttribute("ref");
					string attribute3 = xmlTextReader_0.GetAttribute("si");
					string text4 = xmlTextReader_0.ReadElementString();
					if (attribute2 != null && text4 != null)
					{
						if (attribute == "array")
						{
							int rownum = 0;
							int colnum = 0;
							smethod_0(attribute2, out rownum, out colnum);
							cell.SetArrayFormula("=" + text4, rownum, colnum);
						}
						else if (attribute == "shared")
						{
							CellArea cellArea_ = Class1618.smethod_17(attribute2);
							byte[] value = cell.method_73("=" + text4, cellArea_);
							if (attribute3 != null)
							{
								hashtable_0[attribute3] = value;
							}
						}
					}
					else if (attribute == "shared" && attribute3 != null)
					{
						object obj = hashtable_0[attribute3];
						if (obj != null)
						{
							cell.method_74((byte[])obj);
						}
					}
				}
				else if (xmlTextReader_0.LocalName == "v")
				{
					if (flag && cell.method_46())
					{
						cell.method_6();
					}
					string text5 = xmlTextReader_0.ReadElementString();
					if (text5 != null && text5 != "")
					{
						method_4(cell, text5, text);
					}
				}
				else if (xmlTextReader_0.LocalName == "is")
				{
					if (text == "inlineStr" && class1610_0 != null)
					{
						int int_3 = class1610_0.method_0(xmlTextReader_0);
						class1547_0.workbook_0.Worksheets.class1301_0.method_5(cell, int_3);
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
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return int_1;
	}

	private void method_4(Cell cell_0, string string_2, string string_3)
	{
		switch (string_3)
		{
		case "b":
		{
			bool flag = string_2 == "1";
			cell_0.method_65(flag);
			break;
		}
		case "str":
		case "e":
			cell_0.method_65(string_2);
			break;
		case "s":
		{
			int int_ = Class1618.smethod_87(string_2);
			class1547_0.workbook_0.Worksheets.class1301_0.method_5(cell_0, int_);
			break;
		}
		case "n":
		{
			double num = Class1618.smethod_85(string_2);
			cell_0.method_65(num);
			break;
		}
		}
	}

	private void method_5(XmlTextReader xmlTextReader_0)
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "col")
				{
					method_6(xmlTextReader_0);
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

	private void method_6(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		short num4 = -1;
		double num5 = -1.0;
		bool flag = false;
		bool isHidden = false;
		bool flag2 = false;
		bool flag3 = false;
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (!(xmlTextReader_0.NamespaceURI != ""))
			{
				if (xmlTextReader_0.LocalName == "min")
				{
					num = Class1618.smethod_87(xmlTextReader_0.Value) - 1;
					num2 = num;
				}
				else if (xmlTextReader_0.LocalName == "max")
				{
					num2 = Class1618.smethod_87(xmlTextReader_0.Value) - 1;
				}
				else if (xmlTextReader_0.LocalName == "width")
				{
					num5 = Class1618.smethod_85(xmlTextReader_0.Value);
					flag = true;
				}
				else if (xmlTextReader_0.LocalName == "style")
				{
					num3 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "hidden" && xmlTextReader_0.Value == "1")
				{
					isHidden = true;
				}
				else if (xmlTextReader_0.LocalName == "customWidth" && xmlTextReader_0.Value == "1")
				{
					flag2 = true;
				}
				else if (xmlTextReader_0.LocalName == "outlineLevel")
				{
					num4 = Class1618.smethod_89(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "collapsed" && xmlTextReader_0.Value == "1")
				{
					flag3 = true;
				}
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
		for (int i = num; i <= num2 && i <= 255; i++)
		{
			Column column = worksheet_0.Cells.Columns[(byte)i];
			if (flag && flag2)
			{
				worksheet_0.Cells.SetColumnWidthPixel(i, (int)(num5 * (double)class1547_0.workbook_0.Worksheets.method_72()));
			}
			if (num3 != -1)
			{
				int int_ = (int)class1547_0.hashtable_3[num3];
				column.method_6(int_);
			}
			else
			{
				column.method_6(15);
			}
			if (num4 != -1)
			{
				column.method_4((byte)num4);
			}
			column.IsHidden = isHidden;
			column.method_15(flag3);
		}
	}

	private void method_7(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || xmlTextReader_0.LocalName != "worksheet")
		{
			throw new CellsException(ExceptionType.InvalidData, "worksheet root element eror");
		}
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add(namespaceURI);
		string_1 = nameTable.Add("http://schemas.openxmlformats.org/officeDocument/2006/relationships");
	}

	private static void smethod_0(string szFormulaRange, out int rownum, out int colnum)
	{
		int i;
		for (i = 0; i < szFormulaRange.Length && szFormulaRange[i] != ':'; i++)
		{
		}
		if (i == szFormulaRange.Length)
		{
			rownum = 1;
			colnum = 1;
			return;
		}
		int row = 0;
		int row2 = 0;
		int column = 0;
		int column2 = 0;
		CellsHelper.CellNameToIndex(szFormulaRange.Substring(0, i), out row, out column);
		CellsHelper.CellNameToIndex(szFormulaRange.Substring(i + 1), out row2, out column2);
		rownum = row2 - row + 1;
		colnum = column2 - column + 1;
	}
}
