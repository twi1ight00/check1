using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using ns1;
using ns22;
using ns45;

namespace ns16;

internal class Class1607
{
	private Class1547 class1547_0;

	private Class1548 class1548_0;

	private string string_0;

	private string string_1;

	private PivotTable pivotTable_0;

	private PivotField pivotField_0;

	private PivotFieldType pivotFieldType_0;

	internal Class1607(Class1547 class1547_1, Class1548 class1548_1, string string_2)
	{
		class1547_0 = class1547_1;
		class1548_0 = class1548_1;
		string_1 = string_2;
		pivotFieldType_0 = PivotFieldType.Undefined;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		pivotTable_0 = new PivotTable(class1548_0.worksheet_0.pivotTableCollection_0);
		pivotTable_0.bool_1 = true;
		class1548_0.worksheet_0.PivotTables.method_5(pivotTable_0);
		method_36(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		if (xmlTextReader_0.LocalName == "pivotTableDefinition" && xmlTextReader_0.NodeType == XmlNodeType.Element)
		{
			method_1(xmlTextReader_0);
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "pivotFields" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_3(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "location" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_2(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "rowFields" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_4(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "rowItems" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_5(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "colFields" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_8(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "colItems" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_7(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "dataFields" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_11(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "pageFields" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_9(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "pivotTableStyleInfo" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_13(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "formats" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_29(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "filters" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_31(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "extLst" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_15(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "conditionalFormats" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_33(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "pivotHierarchies" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_0(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		pivotTable_0.bool_1 = true;
	}

	private void method_0(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		pivotTable_0.int_10 = Class1618.smethod_87(xmlTextReader_0.GetAttribute("count"));
		pivotTable_0.string_3 = xmlTextReader_0.ReadInnerXml();
	}

	private void method_1(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		pivotTable_0.bool_7 = true;
		pivotTable_0.ItemPrintTitles = false;
		pivotTable_0.EnableFieldList = true;
		bool flag = false;
		pivotTable_0.bool_8 = true;
		pivotTable_0.int_9 = 1;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if ((localName = xmlTextReader_0.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_131 == null)
				{
					Class1742.dictionary_131 = new Dictionary<string, int>(44)
					{
						{ "name", 0 },
						{ "cacheId", 1 },
						{ "gridDropZones", 2 },
						{ "itemPrintTitles", 3 },
						{ "fieldPrintTitles", 4 },
						{ "colGrandTotals", 5 },
						{ "rowGrandTotals", 6 },
						{ "subtotalHiddenItems", 7 },
						{ "pageOverThenDown", 8 },
						{ "useAutoFormatting", 9 },
						{ "preserveFormatting", 10 },
						{ "enableDrill", 11 },
						{ "showDrill", 12 },
						{ "showItems", 13 },
						{ "showMissing", 14 },
						{ "showHeaders", 15 },
						{ "missingCaption", 16 },
						{ "showError", 17 },
						{ "errorCaption", 18 },
						{ "dataCaption", 19 },
						{ "grandTotalCaption", 20 },
						{ "compact", 21 },
						{ "compactData", 22 },
						{ "mergeItem", 23 },
						{ "updatedVersion", 24 },
						{ "createdVersion", 25 },
						{ "indent", 26 },
						{ "rowHeaderCaption", 27 },
						{ "colHeaderCaption", 28 },
						{ "customListSort", 29 },
						{ "autoFormatId", 30 },
						{ "pageWrap", 31 },
						{ "disableFieldList", 32 },
						{ "enableWizard", 33 },
						{ "enableFieldProperties", 34 },
						{ "tag", 35 },
						{ "multipleFieldFilters", 36 },
						{ "showDataTips", 37 },
						{ "showMemberPropertyTips", 38 },
						{ "showEmptyCol", 39 },
						{ "showEmptyRow", 40 },
						{ "fieldListSortAscending", 41 },
						{ "printDrill", 42 },
						{ "editData", 43 }
					};
				}
				if (!Class1742.dictionary_131.TryGetValue(localName, out var value))
				{
					continue;
				}
				switch (value)
				{
				case 0:
					pivotTable_0.class1175_0.string_0 = xmlTextReader_0.Value;
					break;
				case 1:
				{
					int int_ = Class1618.smethod_87(xmlTextReader_0.Value);
					pivotTable_0.int_11 = int_;
					break;
				}
				case 2:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.bool_2 = true;
					}
					break;
				case 3:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.ItemPrintTitles = true;
					}
					break;
				case 4:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.PrintTitles = true;
					}
					break;
				case 5:
					if (xmlTextReader_0.Value == "0")
					{
						pivotTable_0.RowGrand = false;
					}
					break;
				case 6:
					if (xmlTextReader_0.Value == "0")
					{
						pivotTable_0.ColumnGrand = false;
					}
					break;
				case 7:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.SubtotalHiddenPageItems = true;
					}
					break;
				case 8:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.PageFieldOrder = PrintOrderType.OverThenDown;
					}
					break;
				case 9:
					flag = true;
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.IsAutoFormat = true;
					}
					break;
				case 10:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.PreserveFormatting = true;
					}
					else
					{
						pivotTable_0.PreserveFormatting = false;
					}
					break;
				case 11:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.EnableDrilldown = true;
					}
					else
					{
						pivotTable_0.EnableDrilldown = false;
					}
					break;
				case 12:
					if (xmlTextReader_0.Value == "0")
					{
						pivotTable_0.ShowDrill = false;
					}
					break;
				case 13:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.DisplayImmediateItems = true;
					}
					else
					{
						pivotTable_0.DisplayImmediateItems = false;
					}
					break;
				case 14:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.DisplayNullString = true;
					}
					else
					{
						pivotTable_0.DisplayNullString = false;
					}
					break;
				case 15:
					if (xmlTextReader_0.Value == "0")
					{
						pivotTable_0.bool_7 = false;
					}
					break;
				case 16:
					pivotTable_0.NullString = xmlTextReader_0.Value;
					break;
				case 17:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.DisplayErrorString = true;
					}
					break;
				case 18:
					pivotTable_0.ErrorString = xmlTextReader_0.Value;
					break;
				case 19:
					pivotTable_0.class1175_0.string_1 = xmlTextReader_0.Value;
					break;
				case 20:
					if (pivotTable_0.class1176_0 != null)
					{
						pivotTable_0.class1176_0.string_0 = xmlTextReader_0.Value;
					}
					break;
				case 21:
					if (xmlTextReader_0.Value == "0")
					{
						pivotTable_0.bool_3 = true;
					}
					break;
				case 22:
					if (xmlTextReader_0.Value == "0")
					{
						pivotTable_0.bool_4 = true;
					}
					break;
				case 23:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.MergeLabels = true;
					}
					break;
				case 24:
					pivotTable_0.bool_5 = true;
					pivotTable_0.int_7 = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case 25:
					pivotTable_0.bool_6 = true;
					pivotTable_0.int_8 = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case 26:
					pivotTable_0.int_9 = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case 27:
					pivotTable_0.RowHeaderCaption = xmlTextReader_0.Value;
					break;
				case 28:
					pivotTable_0.ColumnHeaderCaption = xmlTextReader_0.Value;
					break;
				case 29:
					if (xmlTextReader_0.Value == "0")
					{
						pivotTable_0.bool_8 = false;
					}
					break;
				case 30:
					pivotTable_0.AutoFormatType = Class1618.smethod_149(Class1618.smethod_87(xmlTextReader_0.Value));
					break;
				case 31:
					pivotTable_0.PageFieldWrapCount = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case 32:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.EnableFieldList = false;
					}
					else
					{
						pivotTable_0.EnableFieldList = true;
					}
					break;
				case 33:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.EnableWizard = true;
					}
					else
					{
						pivotTable_0.EnableWizard = false;
					}
					break;
				case 34:
					if (xmlTextReader_0.Value == "1")
					{
						pivotTable_0.EnableFieldDialog = true;
					}
					else
					{
						pivotTable_0.EnableFieldDialog = false;
					}
					break;
				case 35:
					pivotTable_0.Tag = xmlTextReader_0.Value;
					break;
				case 36:
					pivotTable_0.IsMultipleFieldFilters = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 37:
					pivotTable_0.ShowDataTips = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 38:
					pivotTable_0.ShowMemberPropertyTips = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 39:
					pivotTable_0.ShowEmptyCol = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 40:
					pivotTable_0.ShowEmptyRow = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 41:
					pivotTable_0.FieldListSortAscending = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 42:
					pivotTable_0.bool_17 = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 43:
					pivotTable_0.bool_18 = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (!flag)
		{
			pivotTable_0.IsAutoFormat = false;
		}
	}

	[Attribute0(true)]
	private void method_2(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName)
				{
				case "firstDataCol":
					pivotTable_0.int_6 = Class1618.smethod_87(xmlTextReader_0.Value) + pivotTable_0.int_2;
					break;
				case "firstDataRow":
					pivotTable_0.int_5 = Class1618.smethod_87(xmlTextReader_0.Value) + pivotTable_0.int_0;
					break;
				case "firstHeaderRow":
					pivotTable_0.int_4 = Class1618.smethod_87(xmlTextReader_0.Value) + pivotTable_0.int_0;
					break;
				case "ref":
				{
					CellArea cellArea = Class1618.smethod_17(xmlTextReader_0.Value);
					pivotTable_0.int_0 = cellArea.StartRow;
					pivotTable_0.int_2 = cellArea.StartColumn;
					pivotTable_0.int_1 = cellArea.EndRow;
					pivotTable_0.int_3 = cellArea.EndColumn;
					break;
				}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	private void method_3(XmlTextReader xmlTextReader_0)
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
			if (xmlTextReader_0.LocalName == "pivotField" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_14(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_4(XmlTextReader xmlTextReader_0)
	{
		PivotFieldCollection rowFields = pivotTable_0.RowFields;
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "field" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				int num = Class1618.smethod_87(xmlTextReader_0.GetAttribute("x"));
				if (xmlTextReader_0.GetAttribute("x") == "-2")
				{
					pivotTable_0.pivotField_0 = new PivotField(pivotTable_0, pivotTable_0.DataFields);
					pivotTable_0.pivotField_0.int_1 = -2;
					pivotTable_0.pivotField_0.pivotFieldType_0 = PivotFieldType.Row;
					rowFields.method_4(pivotTable_0.DataField);
				}
				else
				{
					PivotField pivotField = pivotTable_0.BaseFields[num];
					pivotField.int_1 = num;
					rowFields.method_4(pivotField);
					pivotField_0 = pivotField;
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

	[Attribute0(true)]
	private void method_5(XmlTextReader xmlTextReader_0)
	{
		ArrayList arrayList = new ArrayList();
		pivotTable_0.arrayList_0 = arrayList;
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "i" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				int num = 4 + pivotTable_0.RowFields.Count;
				int[] array = new int[num];
				for (int i = 4; i < num; i++)
				{
					array[i] = 32767;
				}
				arrayList.Add(array);
				if (pivotTable_0.DataField != null && pivotTable_0.DataField.pivotFieldType_0 == PivotFieldType.Row)
				{
					array[3] |= 4096;
				}
				string attribute = xmlTextReader_0.GetAttribute("i");
				if (attribute != null)
				{
					array[3] |= Class1618.smethod_87(attribute) << 1;
				}
				string attribute2 = xmlTextReader_0.GetAttribute("t");
				if (attribute2 != null)
				{
					array[1] = (int)Class1618.smethod_239(attribute2);
					switch (attribute2)
					{
					case "grand":
						array[3] |= 2560;
						if (pivotTable_0.BaseFields.method_1() > 1)
						{
							array[3] |= 1;
						}
						break;
					case "blank":
						array[3] = 8192;
						break;
					case "default":
						array[3] |= 512;
						break;
					}
					if (attribute2 != "default")
					{
						for (int j = 4; j < num; j++)
						{
							array[j] = 0;
						}
					}
				}
				string attribute3 = xmlTextReader_0.GetAttribute("r");
				int num2 = 0;
				if (attribute3 != null)
				{
					num2 = Class1618.smethod_87(attribute3);
				}
				array[0] = num2;
				if (num2 > 0)
				{
					ArrayList arrayList2 = null;
					int[] array2 = null;
					arrayList2 = pivotTable_0.arrayList_0;
					int count = arrayList2.Count;
					array2 = ((count <= 1) ? ((int[])arrayList2[count - 1]) : ((int[])arrayList2[count - 2]));
					for (int k = 0; k < num2; k++)
					{
						array[4 + k] = array2[4 + k];
					}
				}
				method_6(xmlTextReader_0, array, num2);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_6(XmlTextReader xmlTextReader_0, int[] int_0, int int_1)
	{
		int num = 4;
		int num2 = 0;
		int num3 = int_0[0];
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
				if (xmlTextReader_0.LocalName == "x" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					num2++;
					if (xmlTextReader_0.GetAttribute("v") != null)
					{
						int_0[num + num3] = Class1618.smethod_87(xmlTextReader_0.GetAttribute("v"));
						num++;
					}
					else
					{
						int_0[num + num3] = 0;
						num++;
					}
					xmlTextReader_0.Skip();
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
		int_0[2] = num2 + num3;
	}

	[Attribute0(true)]
	private void method_7(XmlTextReader xmlTextReader_0)
	{
		ArrayList arrayList = new ArrayList();
		pivotTable_0.arrayList_1 = arrayList;
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "i" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				int num = 4 + pivotTable_0.ColumnFields.Count;
				int[] array = new int[num];
				arrayList.Add(array);
				if (pivotTable_0.DataField != null && pivotTable_0.DataField.pivotFieldType_0 == PivotFieldType.Column)
				{
					array[3] |= 4096;
				}
				string attribute = xmlTextReader_0.GetAttribute("i");
				if (attribute != null)
				{
					array[3] = (Class1618.smethod_87(attribute) << 1) | array[3];
				}
				string attribute2 = xmlTextReader_0.GetAttribute("t");
				if (attribute2 != null)
				{
					array[1] = (int)Class1618.smethod_239(attribute2);
					switch (attribute2)
					{
					case "grand":
						array[3] |= 2560;
						if (pivotTable_0.BaseFields.method_1() > 1)
						{
							array[3] |= 1;
						}
						break;
					case "blank":
						array[3] = 8192;
						break;
					case "default":
						array[3] |= 512;
						break;
					}
					if (attribute2 != "default")
					{
						for (int i = 4; i < num; i++)
						{
							array[i] = 0;
						}
					}
				}
				string attribute3 = xmlTextReader_0.GetAttribute("r");
				int num2 = 0;
				if (attribute3 != null)
				{
					num2 = Class1618.smethod_87(attribute3);
				}
				array[0] = num2;
				if (num2 > 0)
				{
					ArrayList arrayList2 = null;
					int[] array2 = null;
					arrayList2 = pivotTable_0.arrayList_1;
					int count = arrayList2.Count;
					array2 = ((count <= 1) ? ((int[])arrayList2[count - 1]) : ((int[])arrayList2[count - 2]));
					for (int j = 0; j < num2; j++)
					{
						array[4 + j] = array2[4 + j];
					}
				}
				method_6(xmlTextReader_0, array, num2);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_8(XmlTextReader xmlTextReader_0)
	{
		PivotFieldCollection columnFields = pivotTable_0.ColumnFields;
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "field" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				int num = Class1618.smethod_87(xmlTextReader_0.GetAttribute("x"));
				if (xmlTextReader_0.GetAttribute("x") == "-2")
				{
					pivotTable_0.pivotField_0 = new PivotField(pivotTable_0, pivotTable_0.DataFields);
					pivotTable_0.pivotField_0.int_1 = -2;
					pivotTable_0.pivotField_0.pivotFieldType_0 = PivotFieldType.Column;
					columnFields.method_4(pivotTable_0.DataField);
				}
				else
				{
					PivotField pivotField = pivotTable_0.BaseFields[num];
					pivotField.int_1 = num;
					columnFields.method_4(pivotField);
					pivotField_0 = pivotField;
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

	[Attribute0(true)]
	private void method_9(XmlTextReader xmlTextReader_0)
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
			if (xmlTextReader_0.LocalName == "pageField" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_10(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_10(XmlTextReader xmlTextReader_0)
	{
		PivotField pivotField = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != ""))
				{
					switch (xmlTextReader_0.LocalName)
					{
					case "cap":
						pivotField.class1170_0.string_1 = xmlTextReader_0.Value;
						break;
					case "name":
						pivotField.class1170_0.string_0 = xmlTextReader_0.Value;
						break;
					case "hier":
						pivotField.class1170_0.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case "fld":
					{
						int num2 = Class1618.smethod_87(xmlTextReader_0.Value);
						pivotField = pivotTable_0.BaseFields[num2];
						pivotTable_0.PageFields.method_4(pivotField);
						pivotField.class1159_0 = new Class1159();
						pivotField.class1170_0 = new Class1170(pivotField);
						pivotField.int_1 = num2;
						break;
					}
					case "item":
					{
						int num = Class1618.smethod_87(xmlTextReader_0.Value);
						pivotField.class1170_0.short_0 = (short)num;
						pivotField.class1170_0.int_0 = pivotField.pivotItemCollection_0[num].Index;
						break;
					}
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	private void method_11(XmlTextReader xmlTextReader_0)
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
			if (xmlTextReader_0.LocalName == "dataField" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_12(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_12(XmlTextReader xmlTextReader_0)
	{
		PivotFieldCollection dataFields = pivotTable_0.DataFields;
		PivotField pivotField = null;
		string text = null;
		Class1159 @class = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (xmlTextReader_0.NamespaceURI != "" || (localName = xmlTextReader_0.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_132 == null)
				{
					Class1742.dictionary_132 = new Dictionary<string, int>(7)
					{
						{ "name", 0 },
						{ "fld", 1 },
						{ "baseField", 2 },
						{ "baseItem", 3 },
						{ "numFmtId", 4 },
						{ "subtotal", 5 },
						{ "showDataAs", 6 }
					};
				}
				if (!Class1742.dictionary_132.TryGetValue(localName, out var value))
				{
					continue;
				}
				switch (value)
				{
				case 0:
					text = xmlTextReader_0.Value;
					break;
				case 1:
				{
					int index = Class1618.smethod_87(xmlTextReader_0.Value);
					pivotField = new PivotField();
					pivotField.pivotFieldCollection_0 = dataFields;
					pivotField.pivotField_0 = pivotTable_0.BaseFields[index];
					pivotField.Index = dataFields.Count;
					dataFields.method_4(pivotField);
					pivotField.method_5(bool_7: true);
					pivotField.class1159_0 = new Class1159();
					@class = pivotField.class1159_0;
					if (text != null)
					{
						@class.string_1 = text;
					}
					@class.pivotField_0 = pivotField;
					@class.pivotField_0.method_7(Class1618.smethod_87(xmlTextReader_0.Value));
					break;
				}
				case 2:
					@class.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case 3:
					@class.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case 4:
					@class.short_0 = Class1618.smethod_89(xmlTextReader_0.Value);
					@class.string_0 = class1547_0.workbook_0.Worksheets.method_46(@class.short_0);
					break;
				case 5:
					@class.consolidationFunction_0 = Class1618.smethod_154(xmlTextReader_0.Value);
					break;
				case 6:
					@class.pivotFieldDataDisplayFormat_0 = Class1618.smethod_156(xmlTextReader_0.Value);
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (pivotTable_0.DataField != null)
		{
			PivotItem pivotItem = new PivotItem(pivotTable_0.pivotField_0.pivotItemCollection_0);
			pivotTable_0.pivotField_0.pivotItemCollection_0.Add(pivotItem);
			pivotItem.Index = pivotTable_0.DataFields.Count - 1;
			pivotItem.pivotField_0 = pivotField;
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
			if (xmlTextReader_0.LocalName == "extLst" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_17(xmlTextReader_0, pivotField);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_13(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != ""))
				{
					switch (xmlTextReader_0.LocalName)
					{
					case "showLastColumn":
						pivotTable_0.ShowPivotStyleLastColumn = Class1618.smethod_201(xmlTextReader_0.Value);
						break;
					case "showColStripes":
						pivotTable_0.ShowPivotStyleColumnStripes = Class1618.smethod_201(xmlTextReader_0.Value);
						break;
					case "showRowStripes":
						pivotTable_0.ShowPivotStyleRowStripes = Class1618.smethod_201(xmlTextReader_0.Value);
						break;
					case "showColHeaders":
						pivotTable_0.ShowPivotStyleColumnHeader = Class1618.smethod_201(xmlTextReader_0.Value);
						break;
					case "showRowHeaders":
						pivotTable_0.ShowPivotStyleRowHeader = Class1618.smethod_201(xmlTextReader_0.Value);
						break;
					case "name":
						pivotTable_0.PivotTableStyleName = xmlTextReader_0.Value;
						break;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	private void method_14(XmlTextReader xmlTextReader_0)
	{
		PivotField pivotField = new PivotField(pivotTable_0.BaseFields);
		pivotField.Index = pivotTable_0.BaseFields.Count;
		pivotField.pivotTable_0 = pivotTable_0;
		pivotField.ShowInOutlineForm = true;
		pivotField.ShowCompact = true;
		pivotField.ShowSubtotalAtTop = true;
		pivotField.ShowAllItems = true;
		pivotTable_0.BaseFields.method_4(pivotField);
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (xmlTextReader_0.NamespaceURI != "" || (localName = xmlTextReader_0.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_133 == null)
				{
					Class1742.dictionary_133 = new Dictionary<string, int>(25)
					{
						{ "axis", 0 },
						{ "dataField", 1 },
						{ "outline", 2 },
						{ "compact", 3 },
						{ "subtotalTop", 4 },
						{ "defaultSubtotal", 5 },
						{ "showAll", 6 },
						{ "autoShow", 7 },
						{ "topAutoShow", 8 },
						{ "itemPageCount", 9 },
						{ "sortType", 10 },
						{ "rankBy", 11 },
						{ "multipleItemSelectionAllowed", 12 },
						{ "numFmtId", 13 },
						{ "insertBlankRow", 14 },
						{ "insertPageBreak", 15 },
						{ "name", 16 },
						{ "dragToRow", 17 },
						{ "dragToCol", 18 },
						{ "dragToPage", 19 },
						{ "dragToData", 20 },
						{ "dragOff", 21 },
						{ "includeNewItemsInFilter", 22 },
						{ "allDrilled", 23 },
						{ "dataSourceSort", 24 }
					};
				}
				if (!Class1742.dictionary_133.TryGetValue(localName, out var value))
				{
					continue;
				}
				switch (value)
				{
				case 0:
					if (xmlTextReader_0.Value == "axisRow")
					{
						pivotField.pivotFieldType_0 = PivotFieldType.Row;
					}
					else if (xmlTextReader_0.Value == "axisCol")
					{
						pivotField.pivotFieldType_0 = PivotFieldType.Column;
					}
					else if (xmlTextReader_0.Value == "axisPage")
					{
						pivotField.pivotFieldType_0 = PivotFieldType.Page;
					}
					break;
				case 1:
					if (xmlTextReader_0.Value == "1")
					{
						pivotField.bool_5 = true;
					}
					break;
				case 2:
					if (xmlTextReader_0.Value == "1")
					{
						pivotField.ShowInOutlineForm = true;
					}
					else
					{
						pivotField.ShowInOutlineForm = false;
					}
					break;
				case 3:
					if (xmlTextReader_0.Value == "1")
					{
						pivotField.ShowCompact = true;
					}
					else
					{
						pivotField.ShowCompact = false;
					}
					break;
				case 4:
					if (xmlTextReader_0.Value == "1")
					{
						pivotField.ShowSubtotalAtTop = true;
					}
					else
					{
						pivotField.ShowSubtotalAtTop = false;
					}
					break;
				case 5:
					if (xmlTextReader_0.Value == "0" && (!pivotField.method_4() || pivotField.pivotFieldType_0 != PivotFieldType.Data))
					{
						pivotField.SetSubtotals(PivotFieldSubtotalType.None, shown: true);
					}
					break;
				case 6:
					if (xmlTextReader_0.Value == "1")
					{
						pivotField.ShowAllItems = true;
					}
					else
					{
						pivotField.ShowAllItems = false;
					}
					break;
				case 7:
					if (xmlTextReader_0.Value == "1")
					{
						pivotField.IsAutoShow = true;
					}
					else
					{
						pivotField.IsAutoShow = false;
					}
					break;
				case 8:
					if (xmlTextReader_0.Value == "1")
					{
						pivotField.IsAscendShow = true;
					}
					else
					{
						pivotField.IsAscendShow = false;
					}
					break;
				case 9:
					pivotField.AutoShowCount = (byte)Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case 10:
					pivotField.IsAutoSort = true;
					if (xmlTextReader_0.Value == "ascending")
					{
						pivotField.IsAscendSort = true;
					}
					else
					{
						pivotField.IsAscendSort = false;
					}
					break;
				case 11:
					pivotField.AutoShowField = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case 12:
					pivotField.bool_0 = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 13:
					pivotField.class1174_0.short_0 = Class1618.smethod_89(xmlTextReader_0.Value);
					pivotField.class1174_0.string_0 = class1547_0.workbook_0.Worksheets.method_46(pivotField.class1174_0.short_0);
					break;
				case 14:
					pivotField.InsertBlankRow = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 15:
					pivotField.IsInsertPageBreaksBetweenItems = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 16:
					pivotField.DisplayName = xmlTextReader_0.Value;
					break;
				case 17:
					pivotField.DragToRow = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 18:
					pivotField.DragToColumn = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 19:
					pivotField.DragToPage = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 20:
					pivotField.DragToData = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 21:
					pivotField.DragToHide = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 22:
					pivotField.IsIncludeNewItemsInFilter = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 23:
					pivotField.bool_1 = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 24:
					pivotField.bool_2 = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
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
			if (xmlTextReader_0.LocalName == "items" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_27(xmlTextReader_0, pivotField);
			}
			else if (xmlTextReader_0.LocalName == "autoSortScope" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_19(xmlTextReader_0, pivotField);
			}
			else if (xmlTextReader_0.LocalName == "extLst" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_17(xmlTextReader_0, pivotField);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_15(XmlTextReader xmlTextReader_0)
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
				if (xmlTextReader_0.LocalName == "ext" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					method_16(xmlTextReader_0);
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

	[Attribute0(true)]
	private void method_16(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (!(xmlTextReader_0.NamespaceURI != "") && (localName = xmlTextReader_0.LocalName) != null && localName == "uri")
				{
					pivotTable_0.string_2 = xmlTextReader_0.Value;
				}
			}
			xmlTextReader_0.MoveToElement();
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
			else if (xmlTextReader_0.LocalName == "pivotTableDefinition" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				string attribute = xmlTextReader_0.GetAttribute("hideValuesRow");
				if (attribute != null && attribute.Equals("1"))
				{
					pivotTable_0.bool_13 = true;
				}
				attribute = xmlTextReader_0.GetAttribute("enableEdit");
				if (attribute != null && attribute.Equals("1"))
				{
					pivotTable_0.EnableDataValueEditing = true;
				}
				pivotTable_0.string_0 = xmlTextReader_0.GetAttribute("altText");
				pivotTable_0.string_1 = xmlTextReader_0.GetAttribute("altTextSummary");
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_17(XmlTextReader xmlTextReader_0, PivotField pivotField_1)
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
				if (xmlTextReader_0.LocalName == "ext" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					method_18(xmlTextReader_0, pivotField_1);
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

	[Attribute0(true)]
	private void method_18(XmlTextReader xmlTextReader_0, PivotField pivotField_1)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (!(xmlTextReader_0.NamespaceURI != "") && (localName = xmlTextReader_0.LocalName) != null && localName == "uri")
				{
					pivotField_1.string_0 = xmlTextReader_0.Value;
				}
			}
			xmlTextReader_0.MoveToElement();
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
			else if (xmlTextReader_0.LocalName == "pivotField" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				string attribute = xmlTextReader_0.GetAttribute("fillDownLabels");
				if (attribute.Equals("1"))
				{
					pivotField_1.IsRepeatItemLabels = true;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "dataField" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				string attribute2 = xmlTextReader_0.GetAttribute("pivotShowAs");
				pivotField_1.class1159_0.pivotFieldDataDisplayFormat_0 = Class1618.smethod_156(attribute2);
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "pivotTableDefinition" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				string attribute3 = xmlTextReader_0.GetAttribute("hideValuesRow");
				if (attribute3.Equals("1"))
				{
					pivotTable_0.bool_13 = true;
				}
				attribute3 = xmlTextReader_0.GetAttribute("enableEdit");
				if (attribute3.Equals("1"))
				{
					pivotTable_0.bool_18 = true;
				}
				else
				{
					pivotTable_0.bool_18 = false;
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

	[Attribute0(true)]
	private void method_19(XmlTextReader xmlTextReader_0, PivotField pivotField_1)
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
				if (xmlTextReader_0.LocalName == "pivotArea" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					method_20(xmlTextReader_0, pivotField_1);
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

	[Attribute0(true)]
	private void method_20(XmlTextReader xmlTextReader_0, PivotField pivotField_1)
	{
		Class1171 @class = (pivotField_1.class1171_0 = new Class1171());
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.NamespaceURI != "")
				{
					continue;
				}
				switch (xmlTextReader_0.LocalName)
				{
				case "fieldPosition":
					@class.byte_0 = (byte)Class1618.smethod_89(xmlTextReader_0.Value);
					break;
				case "outline":
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_15(bool_1: true);
					}
					else
					{
						@class.method_15(bool_1: false);
					}
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "references" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					method_21(xmlTextReader_0, @class, pivotField_1);
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

	[Attribute0(true)]
	private void method_21(XmlTextReader xmlTextReader_0, Class1171 class1171_0, PivotField pivotField_1)
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
			if (xmlTextReader_0.LocalName == "reference" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_22(xmlTextReader_0, class1171_0, pivotField_1);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_22(XmlTextReader xmlTextReader_0, Class1171 class1171_0, PivotField pivotField_1)
	{
		Class1162 @class = new Class1162();
		class1171_0.arrayList_0.Add(@class);
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.NamespaceURI != "")
				{
					continue;
				}
				switch (xmlTextReader_0.LocalName)
				{
				case "selected":
					if (xmlTextReader_0.Value == "0")
					{
						@class.method_6(bool_14: false);
					}
					break;
				case "field":
					@class.method_2((ushort)Class1618.smethod_88(xmlTextReader_0.Value));
					if (@class.method_1() == 65534)
					{
						@class.method_3(8);
					}
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "x" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					string attribute = xmlTextReader_0.GetAttribute("v");
					int num2 = (pivotField_1.AutoSortField = Class1618.smethod_87(attribute));
					if (@class.arrayList_0 == null)
					{
						@class.arrayList_0 = new ArrayList();
					}
					@class.arrayList_0.Add(num2);
					xmlTextReader_0.Skip();
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

	[Attribute0(true)]
	private void method_23(XmlTextReader xmlTextReader_0, PivotFormatCondition pivotFormatCondition_0)
	{
		Class1171 @class = new Class1171();
		pivotFormatCondition_0.arrayList_0.Add(@class);
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (xmlTextReader_0.NamespaceURI != "" || (localName = xmlTextReader_0.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_134 == null)
				{
					Class1742.dictionary_134 = new Dictionary<string, int>(11)
					{
						{ "outline", 0 },
						{ "fieldPosition", 1 },
						{ "axis", 2 },
						{ "collapsedLevelsAreSubtotals", 3 },
						{ "dataOnly", 4 },
						{ "field", 5 },
						{ "grandCol", 6 },
						{ "grandRow", 7 },
						{ "labelOnly", 8 },
						{ "offset", 9 },
						{ "type", 10 }
					};
				}
				if (!Class1742.dictionary_134.TryGetValue(localName, out var value))
				{
					continue;
				}
				switch (value)
				{
				case 0:
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_15(bool_1: true);
					}
					else
					{
						@class.method_15(bool_1: false);
					}
					break;
				case 1:
					@class.byte_0 = (byte)Class1618.smethod_89(xmlTextReader_0.Value);
					break;
				case 2:
					if (xmlTextReader_0.Value == "axisCol")
					{
						@class.method_11(2);
					}
					else if (xmlTextReader_0.Value == "axisPage")
					{
						@class.method_11(4);
					}
					else if (xmlTextReader_0.Value == "axisRow")
					{
						@class.method_11(1);
					}
					else if (xmlTextReader_0.Value == "axisValues")
					{
						@class.method_11(8);
					}
					break;
				case 3:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_0 = true;
					}
					else
					{
						@class.bool_0 = false;
					}
					break;
				case 4:
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_1(bool_1: true);
					}
					else
					{
						@class.method_1(bool_1: false);
					}
					break;
				case 5:
					@class.byte_1 = (byte)Class1618.smethod_89(xmlTextReader_0.Value);
					break;
				case 6:
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_7(bool_1: true);
					}
					else
					{
						@class.method_7(bool_1: false);
					}
					break;
				case 7:
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_5(bool_1: true);
					}
					else
					{
						@class.method_5(bool_1: false);
					}
					break;
				case 8:
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_3(bool_1: true);
					}
					else
					{
						@class.method_3(bool_1: false);
					}
					break;
				case 9:
				{
					CellArea cellArea = Class1618.smethod_17(xmlTextReader_0.Value);
					@class.byte_2 = (byte)cellArea.StartRow;
					@class.byte_3 = (byte)cellArea.EndRow;
					@class.byte_4 = (byte)cellArea.StartColumn;
					@class.byte_5 = (byte)cellArea.EndColumn;
					@class.method_17(bool_1: true);
					break;
				}
				case 10:
					if (xmlTextReader_0.Value == "topRight")
					{
						@class.method_13(6);
					}
					else if (xmlTextReader_0.Value == "button")
					{
						@class.method_13(5);
					}
					else if (xmlTextReader_0.Value == "origin")
					{
						@class.method_13(4);
					}
					else if (xmlTextReader_0.Value == "all")
					{
						@class.method_13(3);
					}
					else if (xmlTextReader_0.Value == "data")
					{
						@class.method_13(2);
					}
					else if (xmlTextReader_0.Value == "normal")
					{
						@class.method_13(1);
					}
					else if (xmlTextReader_0.Value == "none")
					{
						@class.method_13(0);
					}
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "references" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					method_24(xmlTextReader_0, @class);
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

	[Attribute0(true)]
	private void method_24(XmlTextReader xmlTextReader_0, Class1171 class1171_0)
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
			if (xmlTextReader_0.LocalName == "reference" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_26(xmlTextReader_0, class1171_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_25(XmlTextReader xmlTextReader_0, Class1163 class1163_0)
	{
		Class1171 @class = (class1163_0.class1171_0 = new Class1171());
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (xmlTextReader_0.NamespaceURI != "" || (localName = xmlTextReader_0.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_135 == null)
				{
					Class1742.dictionary_135 = new Dictionary<string, int>(11)
					{
						{ "outline", 0 },
						{ "fieldPosition", 1 },
						{ "axis", 2 },
						{ "collapsedLevelsAreSubtotals", 3 },
						{ "dataOnly", 4 },
						{ "field", 5 },
						{ "grandCol", 6 },
						{ "grandRow", 7 },
						{ "labelOnly", 8 },
						{ "offset", 9 },
						{ "type", 10 }
					};
				}
				if (!Class1742.dictionary_135.TryGetValue(localName, out var value))
				{
					continue;
				}
				switch (value)
				{
				case 0:
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_15(bool_1: true);
					}
					else
					{
						@class.method_15(bool_1: false);
					}
					break;
				case 1:
					@class.byte_0 = (byte)Class1618.smethod_89(xmlTextReader_0.Value);
					break;
				case 2:
					if (xmlTextReader_0.Value == "axisCol")
					{
						@class.method_11(2);
					}
					else if (xmlTextReader_0.Value == "axisPage")
					{
						@class.method_11(4);
					}
					else if (xmlTextReader_0.Value == "axisRow")
					{
						@class.method_11(1);
					}
					else if (xmlTextReader_0.Value == "axisValues")
					{
						@class.method_11(8);
					}
					break;
				case 3:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_0 = true;
					}
					else
					{
						@class.bool_0 = false;
					}
					break;
				case 4:
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_1(bool_1: true);
					}
					else
					{
						@class.method_1(bool_1: false);
					}
					break;
				case 5:
					@class.byte_1 = (byte)Class1618.smethod_89(xmlTextReader_0.Value);
					break;
				case 6:
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_7(bool_1: true);
					}
					else
					{
						@class.method_7(bool_1: false);
					}
					break;
				case 7:
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_5(bool_1: true);
					}
					else
					{
						@class.method_5(bool_1: false);
					}
					break;
				case 8:
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_3(bool_1: true);
					}
					else
					{
						@class.method_3(bool_1: false);
					}
					break;
				case 9:
				{
					CellArea cellArea = Class1618.smethod_17(xmlTextReader_0.Value);
					@class.byte_2 = (byte)cellArea.StartRow;
					@class.byte_3 = (byte)cellArea.EndRow;
					@class.byte_4 = (byte)cellArea.StartColumn;
					@class.byte_5 = (byte)cellArea.EndColumn;
					@class.method_17(bool_1: true);
					break;
				}
				case 10:
					if (xmlTextReader_0.Value == "topRight")
					{
						@class.method_13(6);
					}
					else if (xmlTextReader_0.Value == "button")
					{
						@class.method_13(5);
					}
					else if (xmlTextReader_0.Value == "origin")
					{
						@class.method_13(4);
					}
					else if (xmlTextReader_0.Value == "all")
					{
						@class.method_13(3);
					}
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "references" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					method_24(xmlTextReader_0, @class);
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

	[Attribute0(true)]
	private void method_26(XmlTextReader xmlTextReader_0, Class1171 class1171_0)
	{
		Class1162 @class = new Class1162();
		class1171_0.arrayList_0.Add(@class);
		@class.Function = 1;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (xmlTextReader_0.NamespaceURI != "" || (localName = xmlTextReader_0.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_136 == null)
				{
					Class1742.dictionary_136 = new Dictionary<string, int>(14)
					{
						{ "field", 0 },
						{ "avgSubtotal", 1 },
						{ "countASubtotal", 2 },
						{ "countSubtotal", 3 },
						{ "defaultSubtotal", 4 },
						{ "maxSubtotal", 5 },
						{ "minSubtotal", 6 },
						{ "productSubtotal", 7 },
						{ "stdDevPSubtotal", 8 },
						{ "stdDevSubtotal", 9 },
						{ "sumSubtotal", 10 },
						{ "varPSubtotal", 11 },
						{ "varSubtotal", 12 },
						{ "selected", 13 }
					};
				}
				if (!Class1742.dictionary_136.TryGetValue(localName, out var value))
				{
					continue;
				}
				switch (value)
				{
				case 0:
				{
					@class.method_2((ushort)Class1618.smethod_88(xmlTextReader_0.Value));
					if (@class.method_1() == 65534)
					{
						@class.method_3(8);
						break;
					}
					PivotField pivotField = pivotTable_0.BaseFields[@class.method_1()];
					if (pivotField.pivotFieldType_0 == PivotFieldType.Row)
					{
						@class.method_3(1);
					}
					else if (pivotField.pivotFieldType_0 == PivotFieldType.Column)
					{
						@class.method_3(2);
					}
					else if (pivotField.pivotFieldType_0 == PivotFieldType.Page)
					{
						@class.method_3(4);
					}
					break;
				}
				case 1:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_4 = true;
					}
					break;
				case 2:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_3 = true;
					}
					break;
				case 3:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_8 = true;
					}
					break;
				case 4:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_1 = true;
					}
					break;
				case 5:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_5 = true;
					}
					break;
				case 6:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_6 = true;
					}
					break;
				case 7:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_7 = true;
					}
					break;
				case 8:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_10 = true;
					}
					break;
				case 9:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_9 = true;
					}
					break;
				case 10:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_2 = true;
					}
					break;
				case 11:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_12 = true;
					}
					break;
				case 12:
					if (xmlTextReader_0.Value == "1")
					{
						@class.bool_11 = true;
					}
					break;
				case 13:
					if (xmlTextReader_0.Value == "0")
					{
						@class.method_6(bool_14: false);
					}
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (@class.Function == 0)
		{
			@class.Function = 1;
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "x" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					string attribute = xmlTextReader_0.GetAttribute("v");
					if (@class.arrayList_0 == null)
					{
						@class.arrayList_0 = new ArrayList();
					}
					@class.arrayList_0.Add(Class1618.smethod_87(attribute));
					xmlTextReader_0.Skip();
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

	[Attribute0(true)]
	private void method_27(XmlTextReader xmlTextReader_0, PivotField pivotField_1)
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
				if (xmlTextReader_0.LocalName == "item" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					if (xmlTextReader_0.GetAttribute("t") == null)
					{
						method_28(xmlTextReader_0, pivotField_1);
						continue;
					}
					if (xmlTextReader_0.GetAttribute("t") != "default")
					{
						pivotField_1.SetSubtotals(Class1618.smethod_152(xmlTextReader_0.GetAttribute("t")), shown: true);
					}
					xmlTextReader_0.Skip();
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

	[Attribute0(true)]
	private void method_28(XmlTextReader xmlTextReader_0, PivotField pivotField_1)
	{
		PivotItem pivotItem = new PivotItem(pivotField_1.PivotItems);
		pivotField_1.PivotItems.Add(pivotItem);
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.NamespaceURI != "")
				{
					continue;
				}
				if (xmlTextReader_0.LocalName == "x")
				{
					pivotItem.Index = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "n")
				{
					pivotItem.string_0 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "h")
				{
					if (xmlTextReader_0.Value == "1")
					{
						pivotItem.IsHidden = true;
					}
					else
					{
						pivotItem.IsHidden = false;
					}
				}
				else if (xmlTextReader_0.LocalName == "sd")
				{
					if (xmlTextReader_0.Value == "1")
					{
						pivotItem.method_1(bool_3: false);
					}
					else
					{
						pivotItem.method_1(bool_3: true);
					}
				}
				else if (xmlTextReader_0.LocalName == "m")
				{
					if (xmlTextReader_0.Value == "1")
					{
						pivotItem.method_4(bool_3: true);
					}
					else
					{
						pivotItem.method_4(bool_3: false);
					}
				}
				else if (xmlTextReader_0.LocalName == "f")
				{
					if (xmlTextReader_0.Value == "1")
					{
						pivotItem.method_2(bool_3: true);
					}
					else
					{
						pivotItem.method_2(bool_3: false);
					}
				}
				else if (xmlTextReader_0.LocalName == "t")
				{
					if (xmlTextReader_0.Value != "default")
					{
						pivotField_1.SetSubtotals(Class1618.smethod_152(xmlTextReader_0.Value), shown: true);
					}
				}
				else if (xmlTextReader_0.LocalName == "c")
				{
					pivotItem.bool_0 = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "d")
				{
					pivotItem.bool_1 = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "s")
				{
					pivotItem.bool_2 = Class1618.smethod_201(xmlTextReader_0.Value);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_29(XmlTextReader xmlTextReader_0)
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
			if (xmlTextReader_0.LocalName == "format" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_30(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_30(XmlTextReader xmlTextReader_0)
	{
		Class1163 @class = new Class1163(pivotTable_0.class1164_0);
		pivotTable_0.class1164_0.Add(@class);
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.NamespaceURI != "")
				{
					continue;
				}
				switch (xmlTextReader_0.LocalName)
				{
				case "dxfId":
					@class.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case "action":
					if (xmlTextReader_0.Value == "blank")
					{
						@class.byte_0 = 0;
					}
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
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
			if (xmlTextReader_0.LocalName == "pivotArea" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_25(xmlTextReader_0, @class);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_31(XmlTextReader xmlTextReader_0)
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
			if (xmlTextReader_0.LocalName == "filter" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_32(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_32(XmlTextReader xmlTextReader_0)
	{
		PivotFilter pivotFilter = new PivotFilter(class1548_0.worksheet_0);
		pivotTable_0.pivotFilterCollection_0.Add(pivotFilter);
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (xmlTextReader_0.NamespaceURI != "" || (localName = xmlTextReader_0.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_137 == null)
				{
					Class1742.dictionary_137 = new Dictionary<string, int>(9)
					{
						{ "fld", 0 },
						{ "evalOrder", 1 },
						{ "id", 2 },
						{ "iMeasureFld", 3 },
						{ "type", 4 },
						{ "stringValue1", 5 },
						{ "stringValue2", 6 },
						{ "name", 7 },
						{ "mpFld", 8 }
					};
				}
				if (Class1742.dictionary_137.TryGetValue(localName, out var value))
				{
					switch (value)
					{
					case 0:
						pivotFilter.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 1:
						pivotFilter.int_3 = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 2:
						pivotFilter.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 3:
						pivotFilter.int_2 = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 4:
						pivotFilter.pivotFilterType_0 = Class1156.smethod_5(xmlTextReader_0.Value);
						break;
					case 5:
						pivotFilter.string_0 = xmlTextReader_0.Value;
						break;
					case 6:
						pivotFilter.string_1 = xmlTextReader_0.Value;
						break;
					case 7:
						pivotFilter.string_2 = xmlTextReader_0.Value;
						break;
					case 8:
						pivotFilter.int_4 = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
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
			if (xmlTextReader_0.LocalName == "autoFilter" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				Class1617.smethod_3(xmlTextReader_0, pivotFilter.autoFilter_0);
				for (int i = 0; i < pivotFilter.autoFilter_0.method_5().Count; i++)
				{
					FilterColumn filterColumn = pivotFilter.autoFilter_0.method_5()[i];
					if (filterColumn.FilterType == FilterType.Top10)
					{
						PivotField pivotField = pivotTable_0.BaseFields[pivotFilter.int_0];
						pivotField.int_0 = ((Top10Filter)filterColumn.Filter).Items;
					}
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
	private void method_33(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		PivotFormatConditionCollection pivotFormatConditions = pivotTable_0.PivotFormatConditions;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "conditionalFormat")
				{
					method_34(xmlTextReader_0, pivotFormatConditions);
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

	[Attribute0(true)]
	private void method_34(XmlTextReader xmlTextReader_0, PivotFormatConditionCollection pivotFormatConditionCollection_0)
	{
		int index = pivotFormatConditionCollection_0.method_0();
		PivotFormatCondition pivotFormatCondition = pivotFormatConditionCollection_0[index];
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != ""))
				{
					switch (xmlTextReader_0.LocalName)
					{
					case "scope":
						pivotFormatCondition.pivotConditionFormatScopeType_0 = Class1156.smethod_1(xmlTextReader_0.Value);
						break;
					case "priority":
						pivotFormatCondition.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
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
			if (xmlTextReader_0.LocalName == "pivotAreas" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_35(xmlTextReader_0, pivotFormatCondition);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_35(XmlTextReader xmlTextReader_0, PivotFormatCondition pivotFormatCondition_0)
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
			if (xmlTextReader_0.LocalName == "pivotArea" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_23(xmlTextReader_0, pivotFormatCondition_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_36(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || xmlTextReader_0.LocalName != "pivotTableDefinition")
		{
			throw new ApplicationException("pivotTableDefinition root element eror");
		}
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add(namespaceURI);
	}
}
