using System;
using System.Collections;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using ns22;
using ns45;

namespace ns16;

internal class Class1587
{
	private PivotTable pivotTable_0;

	private string string_0;

	internal Class1587(PivotTable pivotTable_1, string string_1)
	{
		pivotTable_0 = pivotTable_1;
		string_0 = string_1;
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("pivotTableDefinition");
		xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_0);
		method_26(xmlTextWriter_0);
		method_24(xmlTextWriter_0);
		method_20(xmlTextWriter_0);
		method_3(xmlTextWriter_0);
		method_5(xmlTextWriter_0);
		method_4(xmlTextWriter_0);
		method_7(xmlTextWriter_0);
		method_2(xmlTextWriter_0);
		method_1(xmlTextWriter_0);
		method_12(xmlTextWriter_0);
		method_0(xmlTextWriter_0);
		method_11(xmlTextWriter_0);
		method_13(xmlTextWriter_0);
		method_8(xmlTextWriter_0);
		method_21(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	private void method_0(XmlTextWriter xmlTextWriter_0)
	{
		int int_ = pivotTable_0.int_10;
		if (int_ != 0)
		{
			xmlTextWriter_0.WriteStartElement("pivotHierarchies");
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(int_));
			xmlTextWriter_0.WriteRaw(pivotTable_0.string_3);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0)
	{
		PivotFieldCollection dataFields = pivotTable_0.DataFields;
		int count = dataFields.Count;
		if (count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("dataFields");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
		for (int i = 0; i < count; i++)
		{
			PivotField pivotField = dataFields[i];
			Class1159 class1159_ = pivotField.class1159_0;
			xmlTextWriter_0.WriteStartElement("dataField");
			if (class1159_.Name != null)
			{
				xmlTextWriter_0.WriteAttributeString("name", class1159_.Name);
			}
			xmlTextWriter_0.WriteAttributeString("fld", Class1618.smethod_80(class1159_.pivotField_0.BaseIndex));
			if (class1159_.consolidationFunction_0 != 0)
			{
				xmlTextWriter_0.WriteAttributeString("subtotal", Class1618.smethod_153(class1159_.consolidationFunction_0));
			}
			if (class1159_.pivotFieldDataDisplayFormat_0 != 0 && class1159_.pivotFieldDataDisplayFormat_0 != PivotFieldDataDisplayFormat.PercentageOfParentColumnTotal && class1159_.pivotFieldDataDisplayFormat_0 != PivotFieldDataDisplayFormat.PercentageOfParentRowTotal && class1159_.pivotFieldDataDisplayFormat_0 != PivotFieldDataDisplayFormat.PercentageOfParentTotal && class1159_.pivotFieldDataDisplayFormat_0 != PivotFieldDataDisplayFormat.RankLargestToSmallest && class1159_.pivotFieldDataDisplayFormat_0 != PivotFieldDataDisplayFormat.RankSmallestToLargest && class1159_.pivotFieldDataDisplayFormat_0 != PivotFieldDataDisplayFormat.PercentageOfRunningTotalIn)
			{
				xmlTextWriter_0.WriteAttributeString("showDataAs", Class1618.smethod_155(class1159_.pivotFieldDataDisplayFormat_0));
			}
			xmlTextWriter_0.WriteAttributeString("baseField", Class1618.smethod_80(class1159_.int_0));
			xmlTextWriter_0.WriteAttributeString("baseItem", Class1618.smethod_80(class1159_.int_1));
			if (class1159_.short_0 > 0)
			{
				xmlTextWriter_0.WriteAttributeString("numFmtId", Class1618.smethod_83(class1159_.short_0));
			}
			if (class1159_.pivotFieldDataDisplayFormat_0 == PivotFieldDataDisplayFormat.PercentageOfParentColumnTotal || class1159_.pivotFieldDataDisplayFormat_0 == PivotFieldDataDisplayFormat.PercentageOfParentRowTotal || class1159_.pivotFieldDataDisplayFormat_0 == PivotFieldDataDisplayFormat.PercentageOfParentTotal || class1159_.pivotFieldDataDisplayFormat_0 == PivotFieldDataDisplayFormat.RankLargestToSmallest || class1159_.pivotFieldDataDisplayFormat_0 == PivotFieldDataDisplayFormat.RankSmallestToLargest || class1159_.pivotFieldDataDisplayFormat_0 == PivotFieldDataDisplayFormat.PercentageOfRunningTotalIn)
			{
				method_22(xmlTextWriter_0, pivotField);
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_2(XmlTextWriter xmlTextWriter_0)
	{
		PivotFieldCollection pageFields = pivotTable_0.PageFields;
		int count = pageFields.Count;
		if (count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("pageFields");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
		for (int i = 0; i < count; i++)
		{
			PivotField pivotField = pageFields[i];
			xmlTextWriter_0.WriteStartElement("pageField");
			xmlTextWriter_0.WriteAttributeString("fld", Class1618.smethod_80(pivotField.int_1));
			if (pivotField.class1170_0.short_0 != 32765)
			{
				xmlTextWriter_0.WriteAttributeString("item", Class1618.smethod_83(pivotField.class1170_0.short_0));
			}
			xmlTextWriter_0.WriteAttributeString("hier", Class1618.smethod_80(pivotField.class1170_0.int_1));
			if (pivotField.class1170_0.string_0 != null)
			{
				xmlTextWriter_0.WriteAttributeString("name", pivotField.class1170_0.string_0);
			}
			if (pivotField.class1170_0.string_1 != null)
			{
				xmlTextWriter_0.WriteAttributeString("cap", pivotField.class1170_0.string_1);
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_3(XmlTextWriter xmlTextWriter_0)
	{
		PivotFieldCollection rowFields = pivotTable_0.RowFields;
		int count = rowFields.Count;
		if (count != 0)
		{
			xmlTextWriter_0.WriteStartElement("rowFields");
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			for (int i = 0; i < count; i++)
			{
				PivotField pivotField = rowFields[i];
				xmlTextWriter_0.WriteStartElement("field");
				xmlTextWriter_0.WriteAttributeString("x", Class1618.smethod_83((short)pivotField.int_1));
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_4(XmlTextWriter xmlTextWriter_0)
	{
		PivotFieldCollection columnFields = pivotTable_0.ColumnFields;
		int count = columnFields.Count;
		if (count != 0)
		{
			xmlTextWriter_0.WriteStartElement("colFields");
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			for (int i = 0; i < count; i++)
			{
				PivotField pivotField = columnFields[i];
				xmlTextWriter_0.WriteStartElement("field");
				xmlTextWriter_0.WriteAttributeString("x", Class1618.smethod_83((short)pivotField.int_1));
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_5(XmlTextWriter xmlTextWriter_0)
	{
		ArrayList arrayList_ = pivotTable_0.arrayList_0;
		if (arrayList_ == null)
		{
			return;
		}
		int count = arrayList_.Count;
		if (count != 0)
		{
			xmlTextWriter_0.WriteStartElement("rowItems");
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			for (int i = 0; i < count; i++)
			{
				int[] int_ = (int[])arrayList_[i];
				method_6(xmlTextWriter_0, int_);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_6(XmlTextWriter xmlTextWriter_0, int[] int_0)
	{
		xmlTextWriter_0.WriteStartElement("i");
		if (int_0[1] != 0)
		{
			xmlTextWriter_0.WriteAttributeString("t", Class1618.smethod_238((Enum185)int_0[1]));
		}
		int num = (int_0[3] & 0x1FE) >> 1;
		if (num != 0)
		{
			xmlTextWriter_0.WriteAttributeString("i", Class1618.smethod_80(num));
		}
		if (int_0[0] != 0)
		{
			xmlTextWriter_0.WriteAttributeString("r", Class1618.smethod_80(int_0[0]));
		}
		if (int_0[2] > 0)
		{
			for (int i = int_0[0]; i < int_0[2]; i++)
			{
				xmlTextWriter_0.WriteStartElement("x");
				if (int_0[4 + i] != 0)
				{
					xmlTextWriter_0.WriteAttributeString("v", Class1618.smethod_80(int_0[4 + i]));
				}
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_7(XmlTextWriter xmlTextWriter_0)
	{
		ArrayList arrayList_ = pivotTable_0.arrayList_1;
		if (arrayList_ == null)
		{
			return;
		}
		int count = arrayList_.Count;
		if (count != 0)
		{
			xmlTextWriter_0.WriteStartElement("colItems");
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			for (int i = 0; i < count; i++)
			{
				int[] int_ = (int[])arrayList_[i];
				method_6(xmlTextWriter_0, int_);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_8(XmlTextWriter xmlTextWriter_0)
	{
		PivotFilterCollection pivotFilterCollection_ = pivotTable_0.pivotFilterCollection_0;
		if (pivotFilterCollection_ == null)
		{
			return;
		}
		int count = pivotFilterCollection_.Count;
		if (count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("filters");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
		for (int i = 0; i < count; i++)
		{
			PivotFilter pivotFilter = pivotFilterCollection_[i];
			xmlTextWriter_0.WriteStartElement("filter");
			xmlTextWriter_0.WriteAttributeString("fld", Class1618.smethod_80(pivotFilter.int_0));
			xmlTextWriter_0.WriteAttributeString("type", Class1156.smethod_6(pivotFilter.pivotFilterType_0));
			xmlTextWriter_0.WriteAttributeString("evalOrder", Class1618.smethod_80(pivotFilter.int_3));
			xmlTextWriter_0.WriteAttributeString("id", Class1618.smethod_80(pivotFilter.int_1));
			xmlTextWriter_0.WriteAttributeString("iMeasureFld", Class1618.smethod_80(pivotFilter.int_2));
			if (pivotFilter.string_2 != null)
			{
				xmlTextWriter_0.WriteAttributeString("name", pivotFilter.string_2);
			}
			if (pivotFilter.string_0 != null)
			{
				xmlTextWriter_0.WriteAttributeString("stringValue1", pivotFilter.string_0);
			}
			if (pivotFilter.string_1 != null)
			{
				xmlTextWriter_0.WriteAttributeString("stringValue2", pivotFilter.string_1);
			}
			if (pivotFilter.int_4 != -1)
			{
				xmlTextWriter_0.WriteAttributeString("mpFld", Class1618.smethod_80(pivotFilter.int_4));
			}
			Class1596.smethod_2(xmlTextWriter_0, pivotFilter.autoFilter_0);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_9(XmlTextWriter xmlTextWriter_0, Class1171 class1171_0)
	{
		xmlTextWriter_0.WriteStartElement("pivotArea");
		if (class1171_0.method_14())
		{
			xmlTextWriter_0.WriteAttributeString("outline", "1");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("outline", "0");
		}
		xmlTextWriter_0.WriteAttributeString("fieldPosition", Class1618.smethod_84(class1171_0.byte_0));
		if (class1171_0.method_10() == 2)
		{
			xmlTextWriter_0.WriteAttributeString("axis", "axisCol");
		}
		else if (class1171_0.method_10() == 4)
		{
			xmlTextWriter_0.WriteAttributeString("axis", "axisPage");
		}
		else if (class1171_0.method_10() == 1)
		{
			xmlTextWriter_0.WriteAttributeString("axis", "axisRow");
		}
		else if (class1171_0.method_10() == 8)
		{
			xmlTextWriter_0.WriteAttributeString("axis", "axisValues");
		}
		if (class1171_0.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("collapsedLevelsAreSubtotals", "1");
		}
		if (!class1171_0.method_0())
		{
			xmlTextWriter_0.WriteAttributeString("dataOnly", "0");
		}
		if (class1171_0.byte_1 != byte.MaxValue)
		{
			if (class1171_0.byte_1 == 254)
			{
				xmlTextWriter_0.WriteAttributeString("field", "-2");
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("field", Class1618.smethod_84(class1171_0.byte_1));
			}
		}
		if (class1171_0.method_6())
		{
			xmlTextWriter_0.WriteAttributeString("grandCol", "1");
		}
		if (class1171_0.method_4())
		{
			xmlTextWriter_0.WriteAttributeString("grandRow", "1");
		}
		if (class1171_0.method_2())
		{
			xmlTextWriter_0.WriteAttributeString("labelOnly", "1");
		}
		if (class1171_0.method_16())
		{
			CellArea cellArea_ = default(CellArea);
			cellArea_.StartRow = class1171_0.byte_2;
			cellArea_.EndRow = class1171_0.byte_3;
			cellArea_.StartColumn = class1171_0.byte_4;
			cellArea_.EndColumn = class1171_0.byte_5;
			xmlTextWriter_0.WriteAttributeString("offset", Class1618.smethod_15(cellArea_));
		}
		switch (class1171_0.method_12())
		{
		case 0:
			xmlTextWriter_0.WriteAttributeString("type", "none");
			break;
		case 1:
			xmlTextWriter_0.WriteAttributeString("type", "normal");
			break;
		case 2:
			xmlTextWriter_0.WriteAttributeString("type", "data");
			break;
		case 3:
			xmlTextWriter_0.WriteAttributeString("type", "all");
			break;
		case 4:
			xmlTextWriter_0.WriteAttributeString("type", "origin");
			break;
		case 5:
			xmlTextWriter_0.WriteAttributeString("type", "button");
			break;
		case 6:
			xmlTextWriter_0.WriteAttributeString("type", "topRight");
			break;
		}
		if (class1171_0.arrayList_0.Count > 0)
		{
			int count = class1171_0.arrayList_0.Count;
			xmlTextWriter_0.WriteStartElement("references");
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			for (int i = 0; i < class1171_0.arrayList_0.Count; i++)
			{
				Class1162 @class = (Class1162)class1171_0.arrayList_0[i];
				xmlTextWriter_0.WriteStartElement("reference");
				xmlTextWriter_0.WriteAttributeString("field", Class1618.smethod_81((uint)(short)@class.method_1()));
				if (@class.bool_4)
				{
					xmlTextWriter_0.WriteAttributeString("avgSubtotal", "1");
				}
				if (@class.bool_3)
				{
					xmlTextWriter_0.WriteAttributeString("countASubtotal", "1");
				}
				if (@class.bool_8)
				{
					xmlTextWriter_0.WriteAttributeString("countSubtotal", "1");
				}
				if (@class.bool_1)
				{
					xmlTextWriter_0.WriteAttributeString("defaultSubtotal", "1");
				}
				if (@class.bool_5)
				{
					xmlTextWriter_0.WriteAttributeString("maxSubtotal", "1");
				}
				if (@class.bool_6)
				{
					xmlTextWriter_0.WriteAttributeString("minSubtotal", "1");
				}
				if (@class.bool_7)
				{
					xmlTextWriter_0.WriteAttributeString("productSubtotal", "1");
				}
				if (@class.bool_10)
				{
					xmlTextWriter_0.WriteAttributeString("stdDevPSubtotal", "1");
				}
				if (@class.bool_9)
				{
					xmlTextWriter_0.WriteAttributeString("stdDevSubtotal", "1");
				}
				if (@class.bool_2)
				{
					xmlTextWriter_0.WriteAttributeString("sumSubtotal", "1");
				}
				if (@class.bool_12)
				{
					xmlTextWriter_0.WriteAttributeString("varPSubtotal", "1");
				}
				if (@class.bool_11)
				{
					xmlTextWriter_0.WriteAttributeString("varSubtotal", "1");
				}
				if (!@class.method_5())
				{
					xmlTextWriter_0.WriteAttributeString("selected", "0");
				}
				int count2 = @class.arrayList_0.Count;
				xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count2));
				for (int j = 0; j < count2; j++)
				{
					xmlTextWriter_0.WriteStartElement("x");
					xmlTextWriter_0.WriteAttributeString("v", Class1618.smethod_80((int)@class.arrayList_0[j]));
					xmlTextWriter_0.WriteEndElement();
				}
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private int method_10()
	{
		int num = 1;
		Worksheet worksheet_ = pivotTable_0.pivotTableCollection_0.worksheet_0;
		if (worksheet_ != null)
		{
			for (int i = 0; i < pivotTable_0.pivotTableCollection_0.worksheet_0.ConditionalFormattings.Count; i++)
			{
				FormatConditionCollection formatConditionCollection = worksheet_.ConditionalFormattings[i];
				for (int j = 0; j < formatConditionCollection.Count; j++)
				{
					num++;
				}
			}
			if (worksheet_.pivotTableCollection_0 != null)
			{
				for (int k = 0; k < worksheet_.pivotTableCollection_0.Count; k++)
				{
					PivotTable pivotTable = worksheet_.pivotTableCollection_0[k];
					if (pivotTable.pivotFormatConditionCollection_0 != null)
					{
						for (int l = 0; l < pivotTable.pivotFormatConditionCollection_0.Count; l++)
						{
							num++;
						}
					}
				}
				num--;
			}
		}
		return num;
	}

	[Attribute0(true)]
	private void method_11(XmlTextWriter xmlTextWriter_0)
	{
		PivotFormatConditionCollection pivotFormatConditionCollection_ = pivotTable_0.pivotFormatConditionCollection_0;
		if (pivotFormatConditionCollection_ == null || pivotFormatConditionCollection_.Count == 0)
		{
			return;
		}
		int int_ = method_10();
		int count = pivotFormatConditionCollection_.Count;
		xmlTextWriter_0.WriteStartElement("conditionalFormats");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
		for (int i = 0; i < count; i++)
		{
			PivotFormatCondition pivotFormatCondition = pivotFormatConditionCollection_[i];
			xmlTextWriter_0.WriteStartElement("conditionalFormat");
			if (pivotFormatCondition.int_0 == 0)
			{
				xmlTextWriter_0.WriteAttributeString("priority", Class1618.smethod_80(int_));
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("priority", Class1618.smethod_80(pivotFormatCondition.int_0));
			}
			if (pivotFormatCondition.pivotConditionFormatScopeType_0 != PivotConditionFormatScopeType.selection)
			{
				xmlTextWriter_0.WriteAttributeString("scope", Class1156.smethod_0(pivotFormatCondition.pivotConditionFormatScopeType_0));
			}
			int count2 = pivotFormatCondition.arrayList_0.Count;
			xmlTextWriter_0.WriteStartElement("pivotAreas");
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count2));
			for (int j = 0; j < count2; j++)
			{
				Class1171 class1171_ = (Class1171)pivotFormatCondition.arrayList_0[j];
				method_9(xmlTextWriter_0, class1171_);
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_12(XmlTextWriter xmlTextWriter_0)
	{
		Class1164 class1164_ = pivotTable_0.class1164_0;
		int count = class1164_.Count;
		if (count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("formats");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
		for (int i = 0; i < class1164_.Count; i++)
		{
			Class1163 @class = class1164_[i];
			xmlTextWriter_0.WriteStartElement("format");
			if (@class.byte_0 == 0)
			{
				xmlTextWriter_0.WriteAttributeString("action", "blank");
			}
			if (@class.int_0 != -1)
			{
				xmlTextWriter_0.WriteAttributeString("dxfId", Class1618.smethod_80(@class.int_0));
			}
			Class1171 class1171_ = @class.class1171_0;
			xmlTextWriter_0.WriteStartElement("pivotArea");
			if (class1171_.method_14())
			{
				xmlTextWriter_0.WriteAttributeString("outline", "1");
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("outline", "0");
			}
			xmlTextWriter_0.WriteAttributeString("fieldPosition", Class1618.smethod_84(class1171_.byte_0));
			if (class1171_.method_10() == 2)
			{
				xmlTextWriter_0.WriteAttributeString("axis", "axisCol");
			}
			else if (class1171_.method_10() == 4)
			{
				xmlTextWriter_0.WriteAttributeString("axis", "axisPage");
			}
			else if (class1171_.method_10() == 1)
			{
				xmlTextWriter_0.WriteAttributeString("axis", "axisRow");
			}
			else if (class1171_.method_10() == 8)
			{
				xmlTextWriter_0.WriteAttributeString("axis", "axisValues");
			}
			if (class1171_.bool_0)
			{
				xmlTextWriter_0.WriteAttributeString("collapsedLevelsAreSubtotals", "1");
			}
			if (!class1171_.method_0())
			{
				xmlTextWriter_0.WriteAttributeString("dataOnly", "0");
			}
			if (class1171_.byte_1 != byte.MaxValue)
			{
				if (class1171_.byte_1 == 254)
				{
					xmlTextWriter_0.WriteAttributeString("field", "-2");
				}
				else
				{
					xmlTextWriter_0.WriteAttributeString("field", Class1618.smethod_84(class1171_.byte_1));
				}
			}
			if (class1171_.method_6())
			{
				xmlTextWriter_0.WriteAttributeString("grandCol", "1");
			}
			if (class1171_.method_4())
			{
				xmlTextWriter_0.WriteAttributeString("grandRow", "1");
			}
			if (class1171_.method_2())
			{
				xmlTextWriter_0.WriteAttributeString("labelOnly", "1");
			}
			if (class1171_.method_16())
			{
				CellArea cellArea_ = default(CellArea);
				cellArea_.StartRow = class1171_.byte_2;
				cellArea_.EndRow = class1171_.byte_3;
				cellArea_.StartColumn = class1171_.byte_4;
				cellArea_.EndColumn = class1171_.byte_5;
				xmlTextWriter_0.WriteAttributeString("offset", Class1618.smethod_15(cellArea_));
			}
			switch (class1171_.method_12())
			{
			case 3:
				xmlTextWriter_0.WriteAttributeString("type", "all");
				break;
			case 4:
				xmlTextWriter_0.WriteAttributeString("type", "origin");
				break;
			case 5:
				xmlTextWriter_0.WriteAttributeString("type", "button");
				break;
			case 6:
				xmlTextWriter_0.WriteAttributeString("type", "topRight");
				break;
			}
			if (class1171_.arrayList_0.Count > 0)
			{
				int count2 = class1171_.arrayList_0.Count;
				xmlTextWriter_0.WriteStartElement("references");
				xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count2));
				for (int j = 0; j < class1171_.arrayList_0.Count; j++)
				{
					Class1162 class2 = (Class1162)class1171_.arrayList_0[j];
					xmlTextWriter_0.WriteStartElement("reference");
					xmlTextWriter_0.WriteAttributeString("field", Class1618.smethod_81((uint)(short)class2.method_1()));
					if (class2.bool_4)
					{
						xmlTextWriter_0.WriteAttributeString("avgSubtotal", "1");
					}
					if (class2.bool_3)
					{
						xmlTextWriter_0.WriteAttributeString("countASubtotal", "1");
					}
					if (class2.bool_8)
					{
						xmlTextWriter_0.WriteAttributeString("countSubtotal", "1");
					}
					if (class2.bool_1)
					{
						xmlTextWriter_0.WriteAttributeString("defaultSubtotal", "1");
					}
					if (class2.bool_5)
					{
						xmlTextWriter_0.WriteAttributeString("maxSubtotal", "1");
					}
					if (class2.bool_6)
					{
						xmlTextWriter_0.WriteAttributeString("minSubtotal", "1");
					}
					if (class2.bool_7)
					{
						xmlTextWriter_0.WriteAttributeString("productSubtotal", "1");
					}
					if (class2.bool_10)
					{
						xmlTextWriter_0.WriteAttributeString("stdDevPSubtotal", "1");
					}
					if (class2.bool_9)
					{
						xmlTextWriter_0.WriteAttributeString("stdDevSubtotal", "1");
					}
					if (class2.bool_2)
					{
						xmlTextWriter_0.WriteAttributeString("sumSubtotal", "1");
					}
					if (class2.bool_12)
					{
						xmlTextWriter_0.WriteAttributeString("varPSubtotal", "1");
					}
					if (class2.bool_11)
					{
						xmlTextWriter_0.WriteAttributeString("varSubtotal", "1");
					}
					int count3 = class2.arrayList_0.Count;
					xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count3));
					for (int k = 0; k < count3; k++)
					{
						xmlTextWriter_0.WriteStartElement("x");
						if ((int)class2.arrayList_0[k] == 32767)
						{
							xmlTextWriter_0.WriteAttributeString("v", Class1618.smethod_80(1048832));
						}
						else
						{
							xmlTextWriter_0.WriteAttributeString("v", Class1618.smethod_80((int)class2.arrayList_0[k]));
						}
						xmlTextWriter_0.WriteEndElement();
					}
					xmlTextWriter_0.WriteEndElement();
				}
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_13(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("pivotTableStyleInfo");
		if (pivotTable_0.PivotTableStyleName != null && pivotTable_0.PivotTableStyleName.Length != 0)
		{
			xmlTextWriter_0.WriteAttributeString("name", pivotTable_0.PivotTableStyleName);
		}
		xmlTextWriter_0.WriteAttributeString("showRowHeaders", pivotTable_0.ShowPivotStyleRowHeader ? "1" : "0");
		xmlTextWriter_0.WriteAttributeString("showColHeaders", pivotTable_0.ShowPivotStyleColumnHeader ? "1" : "0");
		xmlTextWriter_0.WriteAttributeString("showRowStripes", pivotTable_0.ShowPivotStyleRowStripes ? "1" : "0");
		xmlTextWriter_0.WriteAttributeString("showColStripes", pivotTable_0.ShowPivotStyleColumnStripes ? "1" : "0");
		xmlTextWriter_0.WriteAttributeString("showLastColumn", pivotTable_0.ShowPivotStyleLastColumn ? "1" : "0");
		xmlTextWriter_0.WriteEndElement();
	}

	private int method_14(PivotField pivotField_0)
	{
		int num = pivotField_0.pivotItemCollection_0.Count;
		if (pivotField_0.IsAutoSubtotals)
		{
			num++;
		}
		else if (!pivotField_0.GetSubtotals(PivotFieldSubtotalType.None))
		{
			ushort ushort_ = pivotField_0.class1173_0.ushort_0;
			for (int i = 1; i < 14; i++)
			{
				if (((uint)(ushort_ >> i) & (true ? 1u : 0u)) != 0)
				{
					num++;
				}
			}
		}
		return num;
	}

	[Attribute0(true)]
	private void method_15(XmlTextWriter xmlTextWriter_0, PivotField pivotField_0)
	{
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.None))
		{
			xmlTextWriter_0.WriteAttributeString("defaultSubtotal", "0");
		}
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Sum))
		{
			xmlTextWriter_0.WriteAttributeString("sumSubtotal", "1");
		}
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Count))
		{
			xmlTextWriter_0.WriteAttributeString("countSubtotal", "1");
		}
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.CountNums))
		{
			xmlTextWriter_0.WriteAttributeString("countASubtotal", "1");
		}
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Stdev))
		{
			xmlTextWriter_0.WriteAttributeString("stdDevSubtotal", "1");
		}
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Stdevp))
		{
			xmlTextWriter_0.WriteAttributeString("stdDevPSubtotal", "1");
		}
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Var))
		{
			xmlTextWriter_0.WriteAttributeString("varSubtotal", "1");
		}
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Varp))
		{
			xmlTextWriter_0.WriteAttributeString("varPSubtotal", "1");
		}
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Average))
		{
			xmlTextWriter_0.WriteAttributeString("avgSubtotal", "1");
		}
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Max))
		{
			xmlTextWriter_0.WriteAttributeString("maxSubtotal", "1");
		}
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Min))
		{
			xmlTextWriter_0.WriteAttributeString("minSubtotal", "1");
		}
		if (pivotField_0.GetSubtotals(PivotFieldSubtotalType.Product))
		{
			xmlTextWriter_0.WriteAttributeString("productSubtotal", "1");
		}
	}

	private bool method_16()
	{
		if (pivotTable_0.AutoFormatType != PivotTableAutoFormatType.Table1 && pivotTable_0.AutoFormatType != PivotTableAutoFormatType.Table2 && pivotTable_0.AutoFormatType != PivotTableAutoFormatType.Table3 && pivotTable_0.AutoFormatType != PivotTableAutoFormatType.Table4 && pivotTable_0.AutoFormatType != PivotTableAutoFormatType.Table5 && pivotTable_0.AutoFormatType != PivotTableAutoFormatType.Table7)
		{
			return false;
		}
		return true;
	}

	[Attribute0(true)]
	private void method_17(XmlTextWriter xmlTextWriter_0, PivotField pivotField_0, int int_0)
	{
		if (pivotField_0.pivotFieldType_0 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("axis", Class1618.smethod_150(pivotField_0.pivotFieldType_0));
		}
		if (pivotField_0.method_4())
		{
			xmlTextWriter_0.WriteAttributeString("dataField", "1");
		}
		if (pivotField_0.ShowInOutlineForm)
		{
			if (!pivotField_0.ShowCompact)
			{
				xmlTextWriter_0.WriteAttributeString("compact", "0");
			}
			if (!pivotField_0.ShowSubtotalAtTop)
			{
				xmlTextWriter_0.WriteAttributeString("subtotalTop", "0");
			}
		}
		else
		{
			if (!pivotField_0.ShowCompact)
			{
				xmlTextWriter_0.WriteAttributeString("compact", "0");
			}
			xmlTextWriter_0.WriteAttributeString("outline", "0");
			if (!pivotField_0.ShowSubtotalAtTop)
			{
				xmlTextWriter_0.WriteAttributeString("subtotalTop", "0");
			}
		}
		if (pivotField_0.bool_1)
		{
			xmlTextWriter_0.WriteAttributeString("allDrilled", "1");
		}
		if (!pivotField_0.ShowAllItems)
		{
			xmlTextWriter_0.WriteAttributeString("showAll", "0");
		}
		if (pivotField_0.IsAutoShow)
		{
			xmlTextWriter_0.WriteAttributeString("autoShow", "1");
			if (!pivotField_0.IsAscendShow)
			{
				xmlTextWriter_0.WriteAttributeString("topAutoShow", "0");
			}
		}
		if (int_0 == 0)
		{
			if (method_16())
			{
				xmlTextWriter_0.WriteAttributeString("insertBlankRow", "1");
			}
		}
		else if (pivotField_0.InsertBlankRow)
		{
			xmlTextWriter_0.WriteAttributeString("insertBlankRow", "1");
		}
		if (pivotField_0.IsIncludeNewItemsInFilter)
		{
			xmlTextWriter_0.WriteAttributeString("includeNewItemsInFilter", "1");
		}
		if (pivotField_0.IsAutoShow)
		{
			short num = (short)pivotField_0.AutoShowCount;
			if (num != 10)
			{
				xmlTextWriter_0.WriteAttributeString("itemPageCount", Class1618.smethod_83(num));
			}
		}
		if (pivotField_0.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("multipleItemSelectionAllowed", "1");
		}
		if (pivotField_0.IsAutoSort)
		{
			string value = (pivotField_0.IsAscendSort ? "ascending" : "descending");
			xmlTextWriter_0.WriteAttributeString("sortType", value);
		}
		if (pivotField_0.AutoShowField >= 0)
		{
			xmlTextWriter_0.WriteAttributeString("rankBy", Class1618.smethod_80(pivotField_0.AutoShowField));
		}
		if (pivotField_0.class1174_0.short_0 > 0)
		{
			xmlTextWriter_0.WriteAttributeString("numFmtId", Class1618.smethod_83(pivotField_0.class1174_0.short_0));
		}
		if (pivotField_0.DisplayName != null)
		{
			xmlTextWriter_0.WriteAttributeString("name", pivotField_0.DisplayName);
		}
		if (pivotField_0.IsInsertPageBreaksBetweenItems)
		{
			xmlTextWriter_0.WriteAttributeString("insertPageBreak", "1");
		}
		if (!pivotField_0.DragToRow)
		{
			xmlTextWriter_0.WriteAttributeString("dragToRow", "0");
		}
		if (!pivotField_0.DragToColumn)
		{
			xmlTextWriter_0.WriteAttributeString("dragToCol", "0");
		}
		if (!pivotField_0.DragToPage)
		{
			xmlTextWriter_0.WriteAttributeString("dragToPage", "0");
		}
		if (!pivotField_0.DragToData)
		{
			xmlTextWriter_0.WriteAttributeString("dragToData", "0");
		}
		if (!pivotField_0.DragToHide)
		{
			xmlTextWriter_0.WriteAttributeString("dragOff", "0");
		}
		if (pivotField_0.bool_2)
		{
			xmlTextWriter_0.WriteAttributeString("dataSourceSort", "1");
		}
		method_15(xmlTextWriter_0, pivotField_0);
	}

	[Attribute0(true)]
	private void method_18(XmlTextWriter xmlTextWriter_0, PivotField pivotField_0)
	{
		xmlTextWriter_0.WriteStartElement("autoSortScope");
		method_9(xmlTextWriter_0, pivotField_0.class1171_0);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_19(XmlTextWriter xmlTextWriter_0, PivotField pivotField_0)
	{
		PivotItemCollection pivotItemCollection_ = pivotField_0.pivotItemCollection_0;
		if (pivotItemCollection_ == null || pivotItemCollection_.Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("items");
		int num = method_14(pivotField_0);
		int num2 = 0;
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(num));
		num2 = ((!pivotField_0.IsAutoSubtotals) ? num : (num - 1));
		num2 = Math.Min(num2, pivotItemCollection_.Count);
		for (int i = 0; i < num2; i++)
		{
			PivotItem pivotItem = pivotItemCollection_[i];
			if (pivotItem.Index != -1)
			{
				xmlTextWriter_0.WriteStartElement("item");
				if (pivotItem.string_0 != null && pivotItem.string_0.Length > 0)
				{
					xmlTextWriter_0.WriteAttributeString("n", pivotItem.string_0);
				}
				if (pivotItem.IsHidden)
				{
					xmlTextWriter_0.WriteAttributeString("h", "1");
				}
				if (pivotItem.method_0())
				{
					xmlTextWriter_0.WriteAttributeString("sd", "0");
				}
				if (pivotItem.IsFormula)
				{
					xmlTextWriter_0.WriteAttributeString("f", "1");
				}
				if (pivotItem.method_3())
				{
					xmlTextWriter_0.WriteAttributeString("m", "1");
				}
				if (pivotItem.bool_2)
				{
					xmlTextWriter_0.WriteAttributeString("s", "1");
				}
				if (pivotItem.bool_0)
				{
					xmlTextWriter_0.WriteAttributeString("c", "1");
				}
				xmlTextWriter_0.WriteAttributeString("x", Class1618.smethod_80(pivotItem.Index));
				if (pivotItem.bool_1)
				{
					xmlTextWriter_0.WriteAttributeString("d", "1");
				}
				xmlTextWriter_0.WriteEndElement();
			}
		}
		if (pivotField_0.IsAutoSubtotals)
		{
			method_23(xmlTextWriter_0, "t", "default");
		}
		else if (!pivotField_0.GetSubtotals(PivotFieldSubtotalType.None))
		{
			ushort ushort_ = pivotField_0.class1173_0.ushort_0;
			for (int j = 1; j < 14; j++)
			{
				if (((uint)(ushort_ >> j) & (true ? 1u : 0u)) != 0)
				{
					PivotFieldSubtotalType pivotFieldSubtotalType_ = (PivotFieldSubtotalType)(1 << j);
					string string_ = Class1618.smethod_151(pivotFieldSubtotalType_);
					method_23(xmlTextWriter_0, "t", string_);
				}
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_20(XmlTextWriter xmlTextWriter_0)
	{
		PivotFieldCollection baseFields = pivotTable_0.BaseFields;
		int count = baseFields.Count;
		if (count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("pivotFields");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
		for (int i = 0; i < count; i++)
		{
			PivotField pivotField = baseFields[i];
			xmlTextWriter_0.WriteStartElement("pivotField");
			method_17(xmlTextWriter_0, pivotField, i);
			method_19(xmlTextWriter_0, pivotField);
			if (pivotField.IsAutoSort && pivotField.AutoSortField >= 0 && pivotField.class1171_0 != null)
			{
				method_18(xmlTextWriter_0, pivotField);
			}
			if (pivotField.IsRepeatItemLabels)
			{
				method_22(xmlTextWriter_0, pivotField);
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_21(XmlTextWriter xmlTextWriter_0)
	{
		if (pivotTable_0.bool_13 || pivotTable_0.EnableDataValueEditing || pivotTable_0.string_0 != null || pivotTable_0.string_1 != null)
		{
			xmlTextWriter_0.WriteStartElement("extLst");
			xmlTextWriter_0.WriteStartElement("ext");
			xmlTextWriter_0.WriteAttributeString("uri", pivotTable_0.string_2);
			xmlTextWriter_0.WriteAttributeString("xmlns:x14", Class1618.string_3);
			xmlTextWriter_0.WriteStartElement("x14:pivotTableDefinition");
			if (pivotTable_0.bool_13)
			{
				xmlTextWriter_0.WriteAttributeString("hideValuesRow", "1");
			}
			if (pivotTable_0.EnableDataValueEditing)
			{
				xmlTextWriter_0.WriteAttributeString("enableEdit", "1");
			}
			if (pivotTable_0.string_0 != null)
			{
				xmlTextWriter_0.WriteAttributeString("altText", pivotTable_0.string_0);
			}
			if (pivotTable_0.string_1 != null)
			{
				xmlTextWriter_0.WriteAttributeString("altTextSummary", pivotTable_0.string_1);
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_22(XmlTextWriter xmlTextWriter_0, PivotField pivotField_0)
	{
		xmlTextWriter_0.WriteStartElement("extLst");
		xmlTextWriter_0.WriteStartElement("ext");
		xmlTextWriter_0.WriteAttributeString("uri", pivotField_0.string_0);
		xmlTextWriter_0.WriteAttributeString("xmlns:x14", Class1618.string_3);
		if (pivotField_0.bool_3)
		{
			xmlTextWriter_0.WriteStartElement("x14:pivotField");
			xmlTextWriter_0.WriteAttributeString("fillDownLabels", "1");
		}
		else if (pivotField_0.class1159_0.pivotFieldDataDisplayFormat_0 != 0)
		{
			xmlTextWriter_0.WriteStartElement("x14:dataField");
			xmlTextWriter_0.WriteAttributeString("pivotShowAs", Class1618.smethod_155(pivotField_0.class1159_0.pivotFieldDataDisplayFormat_0));
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_23(XmlTextWriter xmlTextWriter_0, string string_1, string string_2)
	{
		xmlTextWriter_0.WriteStartElement("item");
		xmlTextWriter_0.WriteAttributeString(string_1, string_2);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_24(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("location");
		xmlTextWriter_0.WriteAttributeString("ref", Class1618.smethod_15(pivotTable_0.TableRange1));
		int int_ = ((pivotTable_0.int_4 - pivotTable_0.int_0 > 0) ? (pivotTable_0.int_4 - pivotTable_0.int_0) : 0);
		int int_2 = ((pivotTable_0.int_5 - pivotTable_0.int_0 > 0) ? (pivotTable_0.int_5 - pivotTable_0.int_0) : 0);
		int int_3 = ((pivotTable_0.int_6 - pivotTable_0.int_2 <= 0) ? 1 : (pivotTable_0.int_6 - pivotTable_0.int_2));
		xmlTextWriter_0.WriteAttributeString("firstHeaderRow", Class1618.smethod_80(int_));
		xmlTextWriter_0.WriteAttributeString("firstDataRow", Class1618.smethod_80(int_2));
		xmlTextWriter_0.WriteAttributeString("firstDataCol", Class1618.smethod_80(int_3));
		if (pivotTable_0.PageFields.Count > 0)
		{
			xmlTextWriter_0.WriteAttributeString("rowPageCount", Class1618.smethod_80(pivotTable_0.PageFields.Count));
			xmlTextWriter_0.WriteAttributeString("colPageCount", "1");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_25(XmlTextWriter xmlTextWriter_0)
	{
		bool flag = true;
		int num = -1;
		if (pivotTable_0.class1175_0.pivotFieldCollection_1.Count > 1)
		{
			PivotField dataField = pivotTable_0.DataField;
			if (dataField != null)
			{
				num = dataField.Position;
				switch (dataField.pivotFieldType_0)
				{
				case PivotFieldType.Row:
					if (num == pivotTable_0.RowFields.Count - 1)
					{
						num = -1;
					}
					break;
				case PivotFieldType.Column:
					flag = false;
					if (num == pivotTable_0.ColumnFields.Count - 1)
					{
						num = -1;
					}
					break;
				}
			}
		}
		if (flag)
		{
			xmlTextWriter_0.WriteAttributeString("dataOnRows", "1");
		}
		if (num != -1)
		{
			xmlTextWriter_0.WriteAttributeString("dataPosition", Class1618.smethod_80(num));
		}
	}

	[Attribute0(true)]
	private void method_26(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteAttributeString("name", pivotTable_0.Name);
		xmlTextWriter_0.WriteAttributeString("cacheId", string_0);
		method_25(xmlTextWriter_0);
		string value = "0";
		if (pivotTable_0.AutoFormatType != PivotTableAutoFormatType.Classic)
		{
			int int_ = Class1618.smethod_148(pivotTable_0.AutoFormatType);
			xmlTextWriter_0.WriteAttributeString("autoFormatId", Class1618.smethod_80(int_));
			value = "1";
		}
		xmlTextWriter_0.WriteAttributeString("applyNumberFormats", value);
		xmlTextWriter_0.WriteAttributeString("applyBorderFormats", value);
		xmlTextWriter_0.WriteAttributeString("applyFontFormats", value);
		xmlTextWriter_0.WriteAttributeString("applyPatternFormats", value);
		xmlTextWriter_0.WriteAttributeString("applyAlignmentFormats", value);
		xmlTextWriter_0.WriteAttributeString("applyWidthHeightFormats", "1");
		xmlTextWriter_0.WriteAttributeString("dataCaption", pivotTable_0.class1175_0.string_1);
		if (pivotTable_0.ErrorString != "")
		{
			xmlTextWriter_0.WriteAttributeString("errorCaption", pivotTable_0.ErrorString);
		}
		if (pivotTable_0.class1176_0 != null && pivotTable_0.class1176_0.string_0 != null)
		{
			xmlTextWriter_0.WriteAttributeString("grandTotalCaption", pivotTable_0.GrandTotalName);
		}
		if (pivotTable_0.DisplayErrorString)
		{
			xmlTextWriter_0.WriteAttributeString("showError", "1");
		}
		if (pivotTable_0.NullString != "")
		{
			xmlTextWriter_0.WriteAttributeString("missingCaption", pivotTable_0.NullString);
		}
		if (pivotTable_0.DisplayNullString)
		{
			xmlTextWriter_0.WriteAttributeString("showMissing", "1");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("showMissing", "0");
		}
		if (!pivotTable_0.DisplayImmediateItems)
		{
			xmlTextWriter_0.WriteAttributeString("showItems", "0");
		}
		if (!pivotTable_0.bool_7)
		{
			xmlTextWriter_0.WriteAttributeString("showHeaders", "0");
		}
		if (!pivotTable_0.bool_8)
		{
			xmlTextWriter_0.WriteAttributeString("customListSort", "0");
		}
		if (!pivotTable_0.EnableDrilldown)
		{
			xmlTextWriter_0.WriteAttributeString("enableDrill", "0");
		}
		if (!pivotTable_0.ShowDrill)
		{
			xmlTextWriter_0.WriteAttributeString("showDrill", "0");
		}
		if (pivotTable_0.PreserveFormatting)
		{
			xmlTextWriter_0.WriteAttributeString("preserveFormatting", "1");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("preserveFormatting", "0");
		}
		if (pivotTable_0.IsAutoFormat)
		{
			xmlTextWriter_0.WriteAttributeString("useAutoFormatting", "1");
		}
		if (pivotTable_0.PageFieldWrapCount > 0)
		{
			xmlTextWriter_0.WriteAttributeString("pageWrap", Class1618.smethod_80(pivotTable_0.PageFieldWrapCount));
		}
		if (pivotTable_0.PageFieldOrder == PrintOrderType.OverThenDown)
		{
			xmlTextWriter_0.WriteAttributeString("pageOverThenDown", "1");
		}
		if (pivotTable_0.SubtotalHiddenPageItems)
		{
			xmlTextWriter_0.WriteAttributeString("subtotalHiddenItems", "1");
		}
		if (!pivotTable_0.ColumnGrand)
		{
			xmlTextWriter_0.WriteAttributeString("rowGrandTotals", "0");
		}
		if (!pivotTable_0.RowGrand)
		{
			xmlTextWriter_0.WriteAttributeString("colGrandTotals", "0");
		}
		if (!pivotTable_0.EnableFieldList)
		{
			xmlTextWriter_0.WriteAttributeString("disableFieldList", "1");
		}
		if (!pivotTable_0.EnableWizard)
		{
			xmlTextWriter_0.WriteAttributeString("EnableWizard", "0");
		}
		if (!pivotTable_0.EnableFieldDialog)
		{
			xmlTextWriter_0.WriteAttributeString("enableFieldProperties", "0");
		}
		if (pivotTable_0.PrintTitles)
		{
			xmlTextWriter_0.WriteAttributeString("fieldPrintTitles", "1");
		}
		if (pivotTable_0.ItemPrintTitles)
		{
			xmlTextWriter_0.WriteAttributeString("itemPrintTitles", "1");
		}
		if (pivotTable_0.bool_3)
		{
			xmlTextWriter_0.WriteAttributeString("compact", "0");
		}
		if (pivotTable_0.bool_4)
		{
			xmlTextWriter_0.WriteAttributeString("compactData", "0");
		}
		if (pivotTable_0.MergeLabels)
		{
			xmlTextWriter_0.WriteAttributeString("mergeItem", "1");
		}
		if (pivotTable_0.bool_6)
		{
			xmlTextWriter_0.WriteAttributeString("createdVersion", Class1618.smethod_80(pivotTable_0.int_8));
		}
		if (pivotTable_0.bool_5)
		{
			xmlTextWriter_0.WriteAttributeString("updatedVersion", Class1618.smethod_80(pivotTable_0.int_7));
		}
		if (pivotTable_0.int_9 != -1)
		{
			xmlTextWriter_0.WriteAttributeString("indent", Class1618.smethod_80(pivotTable_0.int_9));
		}
		if (pivotTable_0.bool_2)
		{
			xmlTextWriter_0.WriteAttributeString("gridDropZones", "1");
		}
		if (pivotTable_0.RowHeaderCaption != null)
		{
			xmlTextWriter_0.WriteAttributeString("rowHeaderCaption", pivotTable_0.RowHeaderCaption);
		}
		if (pivotTable_0.ColumnHeaderCaption != null)
		{
			xmlTextWriter_0.WriteAttributeString("colHeaderCaption", pivotTable_0.ColumnHeaderCaption);
		}
		if (pivotTable_0.Tag != null)
		{
			xmlTextWriter_0.WriteAttributeString("tag", pivotTable_0.Tag);
		}
		if (!pivotTable_0.IsMultipleFieldFilters)
		{
			xmlTextWriter_0.WriteAttributeString("multipleFieldFilters", "0");
		}
		if (!pivotTable_0.ShowDataTips)
		{
			xmlTextWriter_0.WriteAttributeString("showDataTips", "0");
		}
		if (pivotTable_0.ShowMemberPropertyTips)
		{
			xmlTextWriter_0.WriteAttributeString("showMemberPropertyTips", "1");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("showMemberPropertyTips", "0");
		}
		if (pivotTable_0.ShowEmptyCol)
		{
			xmlTextWriter_0.WriteAttributeString("showEmptyCol ", "1");
		}
		if (pivotTable_0.ShowEmptyRow)
		{
			xmlTextWriter_0.WriteAttributeString("showEmptyRow ", "1");
		}
		if (pivotTable_0.FieldListSortAscending)
		{
			xmlTextWriter_0.WriteAttributeString("fieldListSortAscending ", "1");
		}
		if (pivotTable_0.PrintDrill)
		{
			xmlTextWriter_0.WriteAttributeString("printDrill ", "1");
		}
		if (pivotTable_0.EnableDataValueEditing)
		{
			xmlTextWriter_0.WriteAttributeString("editData ", "1");
		}
	}
}
