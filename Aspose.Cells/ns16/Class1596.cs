using System;
using System.Collections;
using System.Globalization;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Markup;
using Aspose.Cells.Pivot;
using ns11;
using ns2;
using ns22;

namespace ns16;

internal class Class1596
{
	private Workbook workbook_0;

	private Worksheet worksheet_0;

	private Class1541 class1541_0;

	private Class1539 class1539_0;

	private Hashtable hashtable_0;

	private bool bool_0;

	private ArrayList arrayList_0;

	private OoxmlSaveOptions ooxmlSaveOptions_0;

	private string string_0 = "";

	internal Class1590 class1590_0;

	private int int_0;

	internal Class1596(Class1541 class1541_1, Class1539 class1539_1, OoxmlSaveOptions ooxmlSaveOptions_1)
	{
		class1541_0 = class1541_1;
		workbook_0 = class1541_1.workbook_0;
		worksheet_0 = class1541_1.worksheet_0;
		class1539_0 = class1539_1;
		if (worksheet_0.Cells.method_22(0) > 0)
		{
			hashtable_0 = new Hashtable(worksheet_0.Cells.method_22(0));
		}
		else
		{
			hashtable_0 = new Hashtable();
		}
		ooxmlSaveOptions_0 = ooxmlSaveOptions_1;
		bool_0 = ooxmlSaveOptions_1.ExportCellName;
		arrayList_0 = new ArrayList();
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("worksheet");
		method_2(xmlTextWriter_0);
		method_13(xmlTextWriter_0);
		method_21(xmlTextWriter_0);
		method_22(xmlTextWriter_0);
		method_28(xmlTextWriter_0);
		method_29(xmlTextWriter_0);
		method_25(xmlTextWriter_0);
		method_12(xmlTextWriter_0);
		method_11(xmlTextWriter_0);
		if (worksheet_0.method_24() > 0)
		{
			smethod_2(xmlTextWriter_0, worksheet_0.AutoFilter);
		}
		method_4(xmlTextWriter_0);
		method_23(xmlTextWriter_0);
		method_34(xmlTextWriter_0);
		method_33(xmlTextWriter_0);
		method_14(xmlTextWriter_0);
		method_31(xmlTextWriter_0);
		method_16(xmlTextWriter_0);
		method_1(xmlTextWriter_0);
		method_5(xmlTextWriter_0);
		method_0(xmlTextWriter_0);
		if (class1541_0.class1358_0.string_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("drawing");
			xmlTextWriter_0.WriteAttributeString("r:id", null, class1541_0.class1358_0.string_0);
			xmlTextWriter_0.WriteEndElement();
		}
		if (class1541_0.class1534_1.string_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("legacyDrawing");
			xmlTextWriter_0.WriteAttributeString("r:id", null, class1541_0.class1534_1.string_0);
			xmlTextWriter_0.WriteEndElement();
		}
		if (class1541_0.class1534_0.string_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("legacyDrawingHF");
			xmlTextWriter_0.WriteAttributeString("r:id", null, class1541_0.class1534_0.string_0);
			xmlTextWriter_0.WriteEndElement();
		}
		if (class1541_0.string_3 != null)
		{
			xmlTextWriter_0.WriteStartElement("picture");
			xmlTextWriter_0.WriteAttributeString("r:id", null, class1541_0.string_3);
			xmlTextWriter_0.WriteEndElement();
		}
		method_7(xmlTextWriter_0);
		method_9(xmlTextWriter_0);
		method_10(xmlTextWriter_0);
		method_6(xmlTextWriter_0);
		method_3(xmlTextWriter_0, this);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	private void method_0(XmlTextWriter xmlTextWriter_0)
	{
		ErrorCheckOptionCollection errorCheckOptionCollection_ = worksheet_0.errorCheckOptionCollection_0;
		if (errorCheckOptionCollection_ == null || errorCheckOptionCollection_.Count == 0)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < errorCheckOptionCollection_.Count; i++)
		{
			ErrorCheckOption errorCheckOption = errorCheckOptionCollection_[i];
			if (errorCheckOption.arrayList_0 != null && errorCheckOption.arrayList_0.Count != 0)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("ignoredErrors");
		for (int j = 0; j < errorCheckOptionCollection_.Count; j++)
		{
			ErrorCheckOption errorCheckOption2 = errorCheckOptionCollection_[j];
			if (errorCheckOption2.arrayList_0 != null && errorCheckOption2.arrayList_0.Count != 0)
			{
				xmlTextWriter_0.WriteStartElement("ignoredError");
				xmlTextWriter_0.WriteAttributeString("sqref", Class1618.smethod_32(errorCheckOption2.arrayList_0, 0, errorCheckOption2.arrayList_0.Count));
				if (!errorCheckOption2.IsErrorCheck(ErrorCheckType.TextNumber))
				{
					xmlTextWriter_0.WriteAttributeString("numberStoredAsText", "1");
				}
				if (!errorCheckOption2.IsErrorCheck(ErrorCheckType.EmptyCellRef))
				{
					xmlTextWriter_0.WriteAttributeString("emptyCellReference", "1");
				}
				if (!errorCheckOption2.IsErrorCheck(ErrorCheckType.Validation))
				{
					xmlTextWriter_0.WriteAttributeString("listDataValidation", "1");
				}
				if (!errorCheckOption2.IsErrorCheck(ErrorCheckType.Calc))
				{
					xmlTextWriter_0.WriteAttributeString("evalError", "1");
				}
				if (!errorCheckOption2.IsErrorCheck(ErrorCheckType.TextDate))
				{
					xmlTextWriter_0.WriteAttributeString("twoDigitTextYear", "1");
				}
				if (!errorCheckOption2.IsErrorCheck(ErrorCheckType.InconsistFormula))
				{
					xmlTextWriter_0.WriteAttributeString("formula", "1");
				}
				if (!errorCheckOption2.IsErrorCheck(ErrorCheckType.InconsistRange))
				{
					xmlTextWriter_0.WriteAttributeString("formulaRange", "1");
				}
				if (!errorCheckOption2.IsErrorCheck(ErrorCheckType.UnproctedFormula))
				{
					xmlTextWriter_0.WriteAttributeString("unlockedFormula", "1");
				}
				if (!errorCheckOption2.IsErrorCheck(ErrorCheckType.CalculatedColumn))
				{
					xmlTextWriter_0.WriteAttributeString("calculatedColumn", "1");
				}
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0)
	{
		SmartTagSetting smartTagSetting = worksheet_0.method_53();
		if (smartTagSetting == null || smartTagSetting.Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("smartTags");
		for (int i = 0; i < smartTagSetting.Count; i++)
		{
			SmartTagCollection smartTagCollection = smartTagSetting[i];
			xmlTextWriter_0.WriteStartElement("cellSmartTags");
			xmlTextWriter_0.WriteAttributeString("r", CellsHelper.CellIndexToName(smartTagCollection.Row, smartTagCollection.Column));
			for (int j = 0; j < smartTagCollection.Count; j++)
			{
				SmartTag smartTag = smartTagCollection[j];
				int num = 0;
				if (smartTag.method_2() == null)
				{
					continue;
				}
				num = workbook_0.Worksheets.method_92().IndexOf(smartTag.method_2());
				if (num >= 0)
				{
					xmlTextWriter_0.WriteStartElement("cellSmartTag");
					xmlTextWriter_0.WriteAttributeString("type", Class1618.smethod_80(num));
					if (smartTag.Deleted)
					{
						xmlTextWriter_0.WriteAttributeString("deleted", "1");
					}
					if (smartTag.method_0())
					{
						xmlTextWriter_0.WriteAttributeString("xmlBased", "1");
					}
					for (int k = 0; k < smartTag.Properties.Count; k++)
					{
						SmartTagProperty smartTagProperty = smartTag.Properties[k];
						xmlTextWriter_0.WriteStartElement("cellSmartTagPr");
						xmlTextWriter_0.WriteAttributeString("key", smartTagProperty.Name);
						xmlTextWriter_0.WriteAttributeString("val", smartTagProperty.Value);
						xmlTextWriter_0.WriteEndElement();
					}
					xmlTextWriter_0.WriteEndElement();
				}
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_2(XmlTextWriter xmlTextWriter_0)
	{
		if (Class1618.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_0);
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_1);
		}
		xmlTextWriter_0.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		if (worksheet_0.class1557_0 == null || worksheet_0.class1557_0.arrayList_0.Count <= 0)
		{
			return;
		}
		foreach (object item in worksheet_0.class1557_0.arrayList_0)
		{
			Class927 @class = (Class927)item;
			xmlTextWriter_0.WriteAttributeString(@class.string_0, @class.string_1);
		}
	}

	private void method_3(XmlTextWriter xmlTextWriter_0, Class1596 class1596_0)
	{
		Class1237 @class = new Class1237(class1541_0);
		@class.Write(xmlTextWriter_0, class1596_0);
	}

	[Attribute0(true)]
	private void method_4(XmlTextWriter xmlTextWriter_0)
	{
		if (worksheet_0.class1557_0 != null && worksheet_0.class1557_0.string_4 != null)
		{
			xmlTextWriter_0.WriteRaw(worksheet_0.class1557_0.string_4);
		}
	}

	[Attribute0(true)]
	private void method_5(XmlTextWriter xmlTextWriter_0)
	{
		int count = class1541_0.arrayList_5.Count;
		if (count != 0)
		{
			xmlTextWriter_0.WriteStartElement("customProperties");
			for (int i = 0; i < count; i++)
			{
				Class1361 @class = (Class1361)class1541_0.arrayList_5[i];
				xmlTextWriter_0.WriteStartElement("customPr");
				xmlTextWriter_0.WriteAttributeString("name", @class.string_0);
				xmlTextWriter_0.WriteAttributeString("r:id", null, @class.string_1);
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_6(XmlTextWriter xmlTextWriter_0)
	{
		if (class1541_0.hashtable_2.Count != 0)
		{
			xmlTextWriter_0.WriteStartElement("tableParts");
			IEnumerator enumerator = class1541_0.hashtable_2.Values.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string value = (string)enumerator.Current;
				xmlTextWriter_0.WriteStartElement("tablePart");
				xmlTextWriter_0.WriteAttributeString("r:id", null, value);
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_7(XmlTextWriter xmlTextWriter_0)
	{
		ArrayList arrayList_ = class1541_0.arrayList_3;
		int count = arrayList_.Count;
		if (count != 0)
		{
			xmlTextWriter_0.WriteStartElement("oleObjects");
			for (int i = 0; i < count; i++)
			{
				Class1538 class1538_ = (Class1538)arrayList_[i];
				method_8(xmlTextWriter_0, class1538_);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_8(XmlTextWriter xmlTextWriter_0, Class1538 class1538_0)
	{
		xmlTextWriter_0.WriteStartElement("oleObject");
		if (class1538_0.oleObject_0.ProgID != null)
		{
			xmlTextWriter_0.WriteAttributeString("progId", class1538_0.oleObject_0.ProgID);
		}
		if (class1538_0.oleObject_0.DisplayAsIcon)
		{
			xmlTextWriter_0.WriteAttributeString("dvAspect", "DVASPECT_ICON");
		}
		if (class1538_0.oleObject_0.IsLink)
		{
			xmlTextWriter_0.WriteAttributeString("link", class1538_0.oleObject_0.method_91());
			if (class1538_0.oleObject_0.method_95())
			{
				xmlTextWriter_0.WriteAttributeString("oleUpdate", "OLEUPDATE_ALWAYS");
			}
		}
		if (class1538_0.string_0 != null)
		{
			xmlTextWriter_0.WriteAttributeString("shapeId", class1538_0.string_0);
		}
		if (class1538_0.string_1 != null)
		{
			xmlTextWriter_0.WriteAttributeString("r:id", null, class1538_0.string_1);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_9(XmlTextWriter xmlTextWriter_0)
	{
		if (worksheet_0.class1557_0 != null && worksheet_0.class1557_0.arrayList_2.Count != 0)
		{
			xmlTextWriter_0.WriteStartElement("controls");
			ArrayList arrayList_ = worksheet_0.class1557_0.arrayList_2;
			for (int i = 0; i < arrayList_.Count; i++)
			{
				Class1550 @class = (Class1550)arrayList_[i];
				xmlTextWriter_0.WriteStartElement("control");
				xmlTextWriter_0.WriteAttributeString("shapeId", @class.string_0);
				xmlTextWriter_0.WriteAttributeString("r:id", null, @class.string_3);
				xmlTextWriter_0.WriteAttributeString("name", @class.string_1);
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_10(XmlTextWriter xmlTextWriter_0)
	{
		if (worksheet_0.class1557_0 != null && worksheet_0.class1557_0.arrayList_3.Count > 0)
		{
			ArrayList arrayList_ = worksheet_0.class1557_0.arrayList_3;
			xmlTextWriter_0.WriteRaw("<mc:AlternateContent xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\">");
			xmlTextWriter_0.WriteRaw("<mc:Choice Requires=\"x14\">");
			xmlTextWriter_0.WriteRaw("<controls>");
			for (int i = 0; i < arrayList_.Count; i++)
			{
				Class443 @class = (Class443)arrayList_[i];
				xmlTextWriter_0.WriteRaw(@class.string_1);
			}
			xmlTextWriter_0.WriteRaw("</controls>");
			xmlTextWriter_0.WriteRaw("</mc:Choice>");
			xmlTextWriter_0.WriteRaw("</mc:AlternateContent>");
		}
		if (worksheet_0.class1557_0 != null && worksheet_0.class1557_0.arrayList_5.Count != 0)
		{
			ArrayList arrayList_2 = worksheet_0.class1557_0.arrayList_5;
			for (int j = 0; j < arrayList_2.Count; j++)
			{
				xmlTextWriter_0.WriteRaw((string)arrayList_2[j]);
			}
		}
	}

	[Attribute0(true)]
	private void method_11(XmlTextWriter xmlTextWriter_0)
	{
		ProtectedRangeCollection allowEditRanges = worksheet_0.AllowEditRanges;
		if (allowEditRanges.Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("protectedRanges");
		foreach (ProtectedRange item in allowEditRanges)
		{
			if (item.method_0() != null && item.method_0().Count != 0)
			{
				xmlTextWriter_0.WriteStartElement("protectedRange");
				if (item.method_1() != 0)
				{
					xmlTextWriter_0.WriteAttributeString("password", Class1025.smethod_6(item.method_1()));
				}
				string value = Class1618.smethod_32(item.method_0(), 0, item.method_0().Count);
				xmlTextWriter_0.WriteAttributeString("sqref", value);
				xmlTextWriter_0.WriteAttributeString("name", item.Name);
				if (item.SecurityDescriptor != null)
				{
					xmlTextWriter_0.WriteAttributeString("securityDescriptor", item.SecurityDescriptor);
				}
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_12(XmlTextWriter xmlTextWriter_0)
	{
		Protection protection = worksheet_0.method_0();
		if (protection == null)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("sheetProtection");
		if (protection.class414_0 != null)
		{
			Class414 class414_ = protection.class414_0;
			if (class414_.string_0 == null)
			{
				if (class414_.method_0() != 0)
				{
					xmlTextWriter_0.WriteAttributeString("password", Class1025.smethod_6(class414_.method_0()));
				}
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("algorithmName", class414_.string_0);
				xmlTextWriter_0.WriteAttributeString("hashValue", Convert.ToBase64String(class414_.byte_0));
				xmlTextWriter_0.WriteAttributeString("saltValue", Convert.ToBase64String(class414_.byte_1));
				xmlTextWriter_0.WriteAttributeString("spinCount", Class1618.smethod_80(class414_.int_0));
			}
		}
		if (!protection.AllowEditingContent)
		{
			xmlTextWriter_0.WriteAttributeString("sheet", "1");
		}
		if (!protection.AllowEditingObject)
		{
			xmlTextWriter_0.WriteAttributeString("objects", "1");
		}
		if (!protection.AllowEditingScenario)
		{
			xmlTextWriter_0.WriteAttributeString("scenarios", "1");
		}
		if (protection.AllowFormattingCell)
		{
			xmlTextWriter_0.WriteAttributeString("formatCells", "0");
		}
		if (protection.AllowFormattingColumn)
		{
			xmlTextWriter_0.WriteAttributeString("formatColumns", "0");
		}
		if (protection.AllowFormattingRow)
		{
			xmlTextWriter_0.WriteAttributeString("formatRows", "0");
		}
		if (protection.AllowInsertingColumn)
		{
			xmlTextWriter_0.WriteAttributeString("insertColumns", "0");
		}
		if (protection.AllowInsertingRow)
		{
			xmlTextWriter_0.WriteAttributeString("insertRows", "0");
		}
		if (protection.AllowInsertingHyperlink)
		{
			xmlTextWriter_0.WriteAttributeString("insertHyperlinks", "0");
		}
		if (protection.AllowDeletingColumn)
		{
			xmlTextWriter_0.WriteAttributeString("deleteColumns", "0");
		}
		if (protection.AllowDeletingRow)
		{
			xmlTextWriter_0.WriteAttributeString("deleteRows", "0");
		}
		if (!protection.AllowSelectingLockedCell)
		{
			xmlTextWriter_0.WriteAttributeString("selectLockedCells", "1");
		}
		if (protection.AllowSorting)
		{
			xmlTextWriter_0.WriteAttributeString("sort", "0");
		}
		if (protection.AllowFiltering)
		{
			xmlTextWriter_0.WriteAttributeString("autoFilter", "0");
		}
		if (protection.AllowUsingPivotTable)
		{
			xmlTextWriter_0.WriteAttributeString("pivotTables", "0");
		}
		if (!protection.AllowSelectingUnlockedCell)
		{
			xmlTextWriter_0.WriteAttributeString("selectUnlockedCells", "1");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	internal static void smethod_0(XmlTextWriter xmlTextWriter_0, DataSorter dataSorter_0)
	{
		xmlTextWriter_0.WriteStartElement("sortState");
		if (dataSorter_0.CaseSensitive)
		{
			xmlTextWriter_0.WriteAttributeString("caseSensitive", "1");
		}
		if (dataSorter_0.SortLeftToRight)
		{
			xmlTextWriter_0.WriteAttributeString("columnSort", "1");
		}
		CellArea area = dataSorter_0.Area;
		xmlTextWriter_0.WriteAttributeString("ref", Class1618.smethod_15(area));
		if (dataSorter_0.string_0 != null && dataSorter_0.string_0 != "")
		{
			xmlTextWriter_0.WriteAttributeString("sortMethod", dataSorter_0.string_0);
		}
		foreach (Class1108 item in dataSorter_0.method_0())
		{
			CellArea cellArea_ = default(CellArea);
			if (dataSorter_0.SortLeftToRight)
			{
				cellArea_.StartRow = item.Index;
				cellArea_.EndRow = item.Index;
				cellArea_.StartColumn = area.StartColumn;
				cellArea_.EndColumn = area.EndColumn;
			}
			else
			{
				cellArea_.StartRow = area.StartRow;
				cellArea_.EndRow = area.EndRow;
				cellArea_.StartColumn = item.Index;
				cellArea_.EndColumn = item.Index;
			}
			smethod_1(xmlTextWriter_0, item, cellArea_);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private static void smethod_1(XmlTextWriter xmlTextWriter_0, Class1108 class1108_0, CellArea cellArea_0)
	{
		xmlTextWriter_0.WriteStartElement("sortCondition");
		if (class1108_0.Order == SortOrder.Descending)
		{
			xmlTextWriter_0.WriteAttributeString("descending", "1");
		}
		switch (class1108_0.Type)
		{
		case Enum135.const_0:
			if (class1108_0.Value != null && class1108_0.Value != "")
			{
				xmlTextWriter_0.WriteAttributeString("customList", class1108_0.Value);
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("sortBy", "value");
			}
			break;
		case Enum135.const_1:
			xmlTextWriter_0.WriteAttributeString("sortBy", "cellColor");
			xmlTextWriter_0.WriteAttributeString("dxfId", Class1618.smethod_80(class1108_0.method_3()));
			break;
		case Enum135.const_2:
			xmlTextWriter_0.WriteAttributeString("sortBy", "fontColor");
			xmlTextWriter_0.WriteAttributeString("dxfId", Class1618.smethod_80(class1108_0.method_3()));
			break;
		case Enum135.const_3:
			xmlTextWriter_0.WriteAttributeString("sortBy", "icon");
			xmlTextWriter_0.WriteAttributeString("iconSet", Class1618.smethod_134(class1108_0.IconSetType));
			if (class1108_0.IconId != -1)
			{
				xmlTextWriter_0.WriteAttributeString("iconId", Class1618.smethod_80(class1108_0.IconId));
			}
			break;
		}
		xmlTextWriter_0.WriteAttributeString("ref", Class1618.smethod_15(cellArea_0));
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	internal static void smethod_2(XmlTextWriter xmlTextWriter_0, AutoFilter autoFilter_0)
	{
		xmlTextWriter_0.WriteStartElement("autoFilter");
		xmlTextWriter_0.WriteAttributeString("ref", autoFilter_0.Range);
		autoFilter_0.method_2();
		FilterColumnCollection filterColumnCollection = autoFilter_0.method_5();
		if (filterColumnCollection != null && filterColumnCollection.Count > 0)
		{
			for (int i = 0; i < filterColumnCollection.Count; i++)
			{
				FilterColumn byIndex = filterColumnCollection.GetByIndex(i);
				smethod_3(xmlTextWriter_0, byIndex);
			}
		}
		if (autoFilter_0.dataSorter_0 != null && autoFilter_0.dataSorter_0.method_0().Count > 0)
		{
			smethod_0(xmlTextWriter_0, autoFilter_0.dataSorter_0);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private static void smethod_3(XmlTextWriter xmlTextWriter_0, FilterColumn filterColumn_0)
	{
		xmlTextWriter_0.WriteStartElement("filterColumn");
		xmlTextWriter_0.WriteAttributeString("colId", Class1618.smethod_80(filterColumn_0.FieldIndex));
		if (filterColumn_0.method_0())
		{
			xmlTextWriter_0.WriteAttributeString("hiddenButton", "1");
		}
		if (!filterColumn_0.method_2())
		{
			xmlTextWriter_0.WriteAttributeString("showButton", "0");
		}
		if (filterColumn_0.FilterType == FilterType.None)
		{
			xmlTextWriter_0.WriteEndElement();
			return;
		}
		switch (filterColumn_0.FilterType)
		{
		case FilterType.ColorFilter:
		{
			ColorFilter colorFilter = (ColorFilter)filterColumn_0.Filter;
			xmlTextWriter_0.WriteStartElement("colorFilter");
			xmlTextWriter_0.WriteAttributeString("dxfId", Class1618.smethod_80(colorFilter.method_1()));
			xmlTextWriter_0.WriteAttributeString("cellColor", colorFilter.FilterByFillColor ? "1" : "0");
			xmlTextWriter_0.WriteEndElement();
			break;
		}
		case FilterType.CustomFilters:
		{
			CustomFilterCollection customFilterCollection = (CustomFilterCollection)filterColumn_0.Filter;
			xmlTextWriter_0.WriteStartElement("customFilters");
			if (customFilterCollection.And && customFilterCollection.Count > 1)
			{
				xmlTextWriter_0.WriteAttributeString("and", "1");
			}
			for (int j = 0; j < customFilterCollection.Count; j++)
			{
				CustomFilter customFilter = customFilterCollection[j];
				xmlTextWriter_0.WriteStartElement("customFilter");
				xmlTextWriter_0.WriteAttributeString("operator", Class1618.smethod_185(customFilter.FilterOperatorType));
				if (customFilter.Criteria != null)
				{
					xmlTextWriter_0.WriteAttributeString("val", AutoFilter.smethod_0(customFilter.Criteria));
				}
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
			break;
		}
		case FilterType.DynamicFilter:
		{
			DynamicFilter dynamicFilter = (DynamicFilter)filterColumn_0.Filter;
			xmlTextWriter_0.WriteStartElement("dynamicFilter");
			xmlTextWriter_0.WriteAttributeString("type", Class1618.smethod_178(dynamicFilter.DynamicFilterType));
			if (dynamicFilter.Value != null)
			{
				xmlTextWriter_0.WriteAttributeString("val", AutoFilter.smethod_0(dynamicFilter.Value));
			}
			if (dynamicFilter.MaxValue != null)
			{
				xmlTextWriter_0.WriteAttributeString("maxVal", AutoFilter.smethod_0(dynamicFilter.MaxValue));
			}
			xmlTextWriter_0.WriteEndElement();
			break;
		}
		case FilterType.MultipleFilters:
		{
			MultipleFilterCollection multipleFilterCollection = (MultipleFilterCollection)filterColumn_0.Filter;
			xmlTextWriter_0.WriteStartElement("filters");
			if (multipleFilterCollection.MatchBlank)
			{
				xmlTextWriter_0.WriteAttributeString("blank", "1");
			}
			if (multipleFilterCollection.string_0 != null)
			{
				xmlTextWriter_0.WriteAttributeString("calendarType", multipleFilterCollection.string_0);
			}
			for (int i = 0; i < multipleFilterCollection.Count; i++)
			{
				object obj = multipleFilterCollection[i];
				if (obj is DateTimeGroupItem)
				{
					DateTimeGroupItem dateTimeGroupItem = (DateTimeGroupItem)obj;
					xmlTextWriter_0.WriteStartElement("dateGroupItem");
					xmlTextWriter_0.WriteAttributeString("dateTimeGrouping", Class1618.smethod_180(dateTimeGroupItem.DateTimeGroupingType));
					switch (dateTimeGroupItem.DateTimeGroupingType)
					{
					case DateTimeGroupingType.Day:
						xmlTextWriter_0.WriteAttributeString("year", Class1618.smethod_80(dateTimeGroupItem.Year));
						xmlTextWriter_0.WriteAttributeString("month", Class1618.smethod_80(dateTimeGroupItem.Month));
						xmlTextWriter_0.WriteAttributeString("day", Class1618.smethod_80(dateTimeGroupItem.Day));
						break;
					case DateTimeGroupingType.Hour:
						xmlTextWriter_0.WriteAttributeString("year", Class1618.smethod_80(dateTimeGroupItem.Year));
						xmlTextWriter_0.WriteAttributeString("month", Class1618.smethod_80(dateTimeGroupItem.Month));
						xmlTextWriter_0.WriteAttributeString("day", Class1618.smethod_80(dateTimeGroupItem.Day));
						xmlTextWriter_0.WriteAttributeString("hour", Class1618.smethod_80(dateTimeGroupItem.Hour));
						break;
					case DateTimeGroupingType.Minute:
						xmlTextWriter_0.WriteAttributeString("year", Class1618.smethod_80(dateTimeGroupItem.Year));
						xmlTextWriter_0.WriteAttributeString("month", Class1618.smethod_80(dateTimeGroupItem.Month));
						xmlTextWriter_0.WriteAttributeString("day", Class1618.smethod_80(dateTimeGroupItem.Day));
						xmlTextWriter_0.WriteAttributeString("hour", Class1618.smethod_80(dateTimeGroupItem.Hour));
						xmlTextWriter_0.WriteAttributeString("minute", Class1618.smethod_80(dateTimeGroupItem.Minute));
						break;
					case DateTimeGroupingType.Month:
						xmlTextWriter_0.WriteAttributeString("year", Class1618.smethod_80(dateTimeGroupItem.Year));
						xmlTextWriter_0.WriteAttributeString("month", Class1618.smethod_80(dateTimeGroupItem.Month));
						break;
					case DateTimeGroupingType.Second:
						xmlTextWriter_0.WriteAttributeString("year", Class1618.smethod_80(dateTimeGroupItem.Year));
						xmlTextWriter_0.WriteAttributeString("month", Class1618.smethod_80(dateTimeGroupItem.Month));
						xmlTextWriter_0.WriteAttributeString("day", Class1618.smethod_80(dateTimeGroupItem.Day));
						xmlTextWriter_0.WriteAttributeString("hour", Class1618.smethod_80(dateTimeGroupItem.Hour));
						xmlTextWriter_0.WriteAttributeString("minute", Class1618.smethod_80(dateTimeGroupItem.Minute));
						xmlTextWriter_0.WriteAttributeString("second", Class1618.smethod_80(dateTimeGroupItem.Second));
						break;
					case DateTimeGroupingType.Year:
						xmlTextWriter_0.WriteAttributeString("year", Class1618.smethod_80(dateTimeGroupItem.Year));
						break;
					}
					xmlTextWriter_0.WriteEndElement();
				}
				else
				{
					xmlTextWriter_0.WriteStartElement("filter");
					xmlTextWriter_0.WriteAttributeString("val", AutoFilter.smethod_0(obj));
					xmlTextWriter_0.WriteEndElement();
				}
			}
			xmlTextWriter_0.WriteEndElement();
			break;
		}
		case FilterType.IconFilter:
		{
			IconFilter iconFilter = (IconFilter)filterColumn_0.Filter;
			xmlTextWriter_0.WriteStartElement("iconFilter");
			if (iconFilter.IconId != -1)
			{
				xmlTextWriter_0.WriteAttributeString("iconId", Class1618.smethod_80(iconFilter.IconId));
			}
			xmlTextWriter_0.WriteAttributeString("iconSet", Class1618.smethod_134(iconFilter.IconSetType));
			xmlTextWriter_0.WriteEndElement();
			break;
		}
		case FilterType.Top10:
		{
			Top10Filter top10Filter = (Top10Filter)filterColumn_0.Filter;
			xmlTextWriter_0.WriteStartElement("top10");
			if (!top10Filter.IsTop)
			{
				xmlTextWriter_0.WriteAttributeString("top", "0");
			}
			if (top10Filter.IsPercent)
			{
				xmlTextWriter_0.WriteAttributeString("percent", "1");
			}
			xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_80(top10Filter.Items));
			if (top10Filter.Criteria != null)
			{
				xmlTextWriter_0.WriteAttributeString("filterVal", AutoFilter.smethod_0(top10Filter.Criteria));
			}
			xmlTextWriter_0.WriteEndElement();
			break;
		}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_13(XmlTextWriter xmlTextWriter_0)
	{
		string text = null;
		if (workbook_0.method_9() && worksheet_0.method_47() != null)
		{
			text = worksheet_0.CodeName;
		}
		bool flag = false;
		if (!worksheet_0.Outline.SummaryColumnRight || !worksheet_0.Outline.SummaryRowBelow)
		{
			flag = true;
		}
		string text2 = null;
		if (worksheet_0.class1557_0 != null)
		{
			text2 = worksheet_0.class1557_0.string_3;
		}
		string text3 = null;
		if (worksheet_0.TransitionEvaluation)
		{
			text3 = "1";
		}
		string text4 = null;
		if (worksheet_0.TransitionEntry)
		{
			text4 = "1";
		}
		if (worksheet_0.PageSetup.IsPercentScale && text == null && worksheet_0.internalColor_0.method_2() && !flag && text2 == null && text3 == null && text4 == null)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("sheetPr");
		if (text2 != null)
		{
			xmlTextWriter_0.WriteAttributeString("published", text2);
		}
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("codeName", text);
		}
		if (text3 != null)
		{
			xmlTextWriter_0.WriteAttributeString("transitionEvaluation", text3);
		}
		if (text4 != null)
		{
			xmlTextWriter_0.WriteAttributeString("transitionEntry", text4);
		}
		if (!worksheet_0.internalColor_0.method_2())
		{
			Class1590.smethod_1(xmlTextWriter_0, worksheet_0.internalColor_0, "tabColor");
		}
		if (flag)
		{
			xmlTextWriter_0.WriteStartElement("outlinePr");
			if (!worksheet_0.Outline.SummaryRowBelow)
			{
				xmlTextWriter_0.WriteAttributeString("summaryBelow", "0");
			}
			if (!worksheet_0.Outline.SummaryColumnRight)
			{
				xmlTextWriter_0.WriteAttributeString("summaryRight", "0");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		if (!worksheet_0.PageSetup.IsPercentScale)
		{
			xmlTextWriter_0.WriteStartElement("pageSetUpPr");
			xmlTextWriter_0.WriteAttributeString("fitToPage", "1");
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_14(XmlTextWriter xmlTextWriter_0)
	{
		ArrayList arrayList = new ArrayList(worksheet_0.Validations.Count);
		foreach (Validation validation4 in worksheet_0.Validations)
		{
			if (validation4.AreaList.Count > 0)
			{
				arrayList.Add(validation4);
			}
		}
		int count = arrayList.Count;
		if (count == 0)
		{
			return;
		}
		int num = 100;
		xmlTextWriter_0.WriteStartElement("dataValidations");
		int num2 = 0;
		for (int i = 0; i < count; i++)
		{
			Validation validation2 = (Validation)arrayList[i];
			if (validation2.AreaList.Count > num)
			{
				num2 += validation2.AreaList.Count / num;
			}
			num2++;
		}
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(num2));
		for (int j = 0; j < count; j++)
		{
			Validation validation3 = (Validation)arrayList[j];
			if (validation3.AreaList.Count > num)
			{
				int num3 = validation3.AreaList.Count / num;
				for (int k = 0; k < num3; k++)
				{
					method_15(validation3, k * num, (k + 1) * num, xmlTextWriter_0);
				}
				method_15(validation3, num3 * num, validation3.AreaList.Count, xmlTextWriter_0);
			}
			else
			{
				method_15(validation3, 0, validation3.AreaList.Count, xmlTextWriter_0);
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_15(Validation validation_0, int int_1, int int_2, XmlTextWriter xmlTextWriter_0)
	{
		if (int_1 >= int_2)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("dataValidation");
		if (validation_0.AlertStyle != ValidationAlertType.Stop)
		{
			if (validation_0.AlertStyle == ValidationAlertType.Information)
			{
				xmlTextWriter_0.WriteAttributeString("errorStyle", "information");
			}
			else if (validation_0.AlertStyle == ValidationAlertType.Warning)
			{
				xmlTextWriter_0.WriteAttributeString("errorStyle", "warning");
			}
		}
		if (validation_0.Type != 0)
		{
			xmlTextWriter_0.WriteAttributeString("type", Class1618.smethod_26(validation_0.Type));
		}
		if (validation_0.Operator != 0 && validation_0.Operator != OperatorType.None)
		{
			string value = Class1618.smethod_29(validation_0.Operator);
			xmlTextWriter_0.WriteAttributeString("operator", value);
		}
		if (validation_0.IgnoreBlank)
		{
			xmlTextWriter_0.WriteAttributeString("allowBlank", "1");
		}
		if (validation_0.Type == Aspose.Cells.ValidationType.List && !validation_0.InCellDropDown)
		{
			xmlTextWriter_0.WriteAttributeString("showDropDown", "1");
		}
		if (validation_0.ShowInput)
		{
			xmlTextWriter_0.WriteAttributeString("showInputMessage", "1");
		}
		if (validation_0.ShowError)
		{
			xmlTextWriter_0.WriteAttributeString("showErrorMessage", "1");
		}
		if (validation_0.InputTitle != null && validation_0.InputTitle.Length > 0)
		{
			xmlTextWriter_0.WriteAttributeString("promptTitle", validation_0.InputTitle);
		}
		if (validation_0.InputMessage != null && validation_0.InputMessage.Length > 0)
		{
			xmlTextWriter_0.WriteAttributeString("prompt", validation_0.InputMessage);
		}
		if (validation_0.ErrorTitle != null && validation_0.ErrorTitle.Length > 0)
		{
			xmlTextWriter_0.WriteAttributeString("errorTitle", validation_0.ErrorTitle);
		}
		if (validation_0.ErrorMessage != null && validation_0.ErrorMessage.Length > 0)
		{
			xmlTextWriter_0.WriteAttributeString("error", validation_0.ErrorMessage);
		}
		if (validation_0.method_5() != 0)
		{
			xmlTextWriter_0.WriteAttributeString("imeMode", Class1618.smethod_44(validation_0.method_5()));
		}
		string value2 = Class1618.smethod_32(validation_0.AreaList, int_1, int_2);
		xmlTextWriter_0.WriteAttributeString("sqref", value2);
		if (validation_0.Formula1 != null && validation_0.Formula1.Length > 0)
		{
			string text = validation_0.Formula1;
			if (validation_0.Type == Aspose.Cells.ValidationType.List)
			{
				if (text[0] == '=')
				{
					text = text.Substring(1);
				}
				else if (text[0] != '"')
				{
					text = "\"" + text + "\"";
				}
			}
			else if (validation_0.Type != Aspose.Cells.ValidationType.Date && validation_0.Type != Aspose.Cells.ValidationType.Time)
			{
				text = Class1618.smethod_93(text);
			}
			else
			{
				if (text[0] == '=')
				{
					text = text.Substring(1);
				}
				if (!Class1677.smethod_19(text))
				{
					try
					{
						DateTime dateTime = DateTime.Parse(text);
						text = ((validation_0.Type != Aspose.Cells.ValidationType.Time) ? Class1618.smethod_79(CellsHelper.GetDoubleFromDateTime(dateTime, workbook_0.Settings.Date1904)) : Class1618.smethod_79(dateTime.TimeOfDay.TotalDays));
					}
					catch
					{
						text = Class1618.smethod_93(text);
					}
				}
			}
			xmlTextWriter_0.WriteStartElement("formula1");
			xmlTextWriter_0.WriteString(Class1618.smethod_4(text));
			xmlTextWriter_0.WriteEndElement();
		}
		if ((validation_0.Operator == OperatorType.Between || validation_0.Operator == OperatorType.NotBetween) && validation_0.Formula2 != null && validation_0.Formula2.Length > 0)
		{
			xmlTextWriter_0.WriteStartElement("formula2");
			string text2 = Class1618.smethod_93(validation_0.Formula2);
			if ((validation_0.Type == Aspose.Cells.ValidationType.Date || validation_0.Type == Aspose.Cells.ValidationType.Time) && !Class1677.smethod_19(text2))
			{
				try
				{
					DateTime dateTime2 = DateTime.Parse(text2);
					text2 = ((validation_0.Type != Aspose.Cells.ValidationType.Time) ? Class1618.smethod_79(CellsHelper.GetDoubleFromDateTime(dateTime2, workbook_0.Settings.Date1904)) : Class1618.smethod_79(dateTime2.TimeOfDay.TotalDays));
				}
				catch
				{
					text2 = Class1618.smethod_93(text2);
				}
			}
			xmlTextWriter_0.WriteString(Class1618.smethod_4(text2));
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_16(XmlTextWriter xmlTextWriter_0)
	{
		PageSetup pageSetup = worksheet_0.PageSetup;
		xmlTextWriter_0.WriteStartElement("printOptions");
		if (pageSetup.PrintGridlines)
		{
			xmlTextWriter_0.WriteAttributeString("gridLines", "1");
		}
		if (pageSetup.PrintHeadings)
		{
			xmlTextWriter_0.WriteAttributeString("headings", "1");
		}
		if (pageSetup.CenterHorizontally)
		{
			xmlTextWriter_0.WriteAttributeString("horizontalCentered", "1");
		}
		if (pageSetup.CenterVertically)
		{
			xmlTextWriter_0.WriteAttributeString("verticalCentered", "1");
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("pageMargins");
		xmlTextWriter_0.WriteAttributeString("left", Class1618.smethod_79(pageSetup.LeftMarginInch));
		xmlTextWriter_0.WriteAttributeString("right", Class1618.smethod_79(pageSetup.RightMarginInch));
		xmlTextWriter_0.WriteAttributeString("top", Class1618.smethod_79(pageSetup.TopMarginInch));
		xmlTextWriter_0.WriteAttributeString("bottom", Class1618.smethod_79(pageSetup.BottomMarginInch));
		xmlTextWriter_0.WriteAttributeString("header", Class1618.smethod_79(pageSetup.HeaderMarginInch));
		xmlTextWriter_0.WriteAttributeString("footer", Class1618.smethod_79(pageSetup.FooterMarginInch));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("pageSetup");
		if (pageSetup.BlackAndWhite)
		{
			xmlTextWriter_0.WriteAttributeString("blackAndWhite", "1");
		}
		if (pageSetup.PrintComments != PrintCommentsType.PrintNoComments)
		{
			xmlTextWriter_0.WriteAttributeString("cellComments", Class1618.smethod_20(pageSetup.PrintComments));
		}
		if (pageSetup.PrintDraft)
		{
			xmlTextWriter_0.WriteAttributeString("draft", "1");
		}
		if (pageSetup.PrintErrors != PrintErrorsType.PrintErrorsDisplayed)
		{
			xmlTextWriter_0.WriteAttributeString("errors", Class1618.smethod_22(pageSetup.PrintErrors));
		}
		if (!pageSetup.IsAutoFirstPageNumber)
		{
			xmlTextWriter_0.WriteAttributeString("firstPageNumber", Class1618.smethod_80(pageSetup.FirstPageNumber));
			xmlTextWriter_0.WriteAttributeString("useFirstPageNumber", "1");
		}
		if (pageSetup.FitToPagesTall != 1)
		{
			xmlTextWriter_0.WriteAttributeString("fitToHeight", Class1618.smethod_80(pageSetup.FitToPagesTall));
		}
		if (pageSetup.FitToPagesWide != 1)
		{
			xmlTextWriter_0.WriteAttributeString("fitToWidth", Class1618.smethod_80(pageSetup.FitToPagesWide));
		}
		if (pageSetup.PrintQuality > 0 && !pageSetup.bool_12)
		{
			xmlTextWriter_0.WriteAttributeString("horizontalDpi", Class1618.smethod_80(pageSetup.PrintQuality));
			xmlTextWriter_0.WriteAttributeString("verticalDpi", Class1618.smethod_80(pageSetup.PrintQuality));
		}
		xmlTextWriter_0.WriteAttributeString("orientation", Class1618.smethod_18(pageSetup.Orientation));
		if (pageSetup.Order != 0)
		{
			xmlTextWriter_0.WriteAttributeString("pageOrder", Class1618.smethod_24(pageSetup.Order));
		}
		if (pageSetup.PaperSize != PaperSizeType.PaperLetter)
		{
			xmlTextWriter_0.WriteAttributeString("paperSize", Class1618.smethod_80((int)pageSetup.PaperSize));
		}
		if (pageSetup.Zoom != 100)
		{
			xmlTextWriter_0.WriteAttributeString("scale", Class1618.smethod_80(pageSetup.Zoom));
		}
		string string_ = class1541_0.string_4;
		if (string_ != null)
		{
			xmlTextWriter_0.WriteAttributeString("r:id", string_);
		}
		xmlTextWriter_0.WriteEndElement();
		method_17(xmlTextWriter_0);
		method_20(xmlTextWriter_0);
	}

	[Attribute0(true)]
	private void method_17(XmlTextWriter xmlTextWriter_0)
	{
		PageSetup pageSetup = worksheet_0.PageSetup;
		string text = method_18(pageSetup.GetFirstPageHeader(0), 0) + method_18(pageSetup.GetFirstPageHeader(1), 1) + method_18(pageSetup.GetFirstPageHeader(2), 2);
		string text2 = method_18(pageSetup.GetFirstPageFooter(0), 0) + method_18(pageSetup.GetFirstPageFooter(1), 1) + method_18(pageSetup.GetFirstPageFooter(2), 2);
		string text3 = method_18(pageSetup.GetEvenHeader(0), 0) + method_18(pageSetup.GetEvenHeader(1), 1) + method_18(pageSetup.GetEvenHeader(2), 2);
		string text4 = method_18(pageSetup.GetEvenFooter(0), 0) + method_18(pageSetup.GetEvenFooter(1), 1) + method_18(pageSetup.GetEvenFooter(2), 2);
		string text5 = method_18(pageSetup.GetHeader(0), 0) + method_18(pageSetup.GetHeader(1), 1) + method_18(pageSetup.GetHeader(2), 2);
		string text6 = method_18(pageSetup.GetFooter(0), 0) + method_18(pageSetup.GetFooter(1), 1) + method_18(pageSetup.GetFooter(2), 2);
		if (text.Length > 0 || text2.Length > 0 || text3.Length > 0 || text4.Length > 0 || text5.Length > 0 || text6.Length > 0)
		{
			xmlTextWriter_0.WriteStartElement("headerFooter");
			if (pageSetup.IsHFDiffOddEven)
			{
				xmlTextWriter_0.WriteAttributeString("differentOddEven", "1");
			}
			if (pageSetup.IsHFDiffFirst)
			{
				xmlTextWriter_0.WriteAttributeString("differentFirst", "1");
			}
			if (!pageSetup.IsHFScaleWithDoc)
			{
				xmlTextWriter_0.WriteAttributeString("scaleWithDoc", "0");
			}
			if (!pageSetup.IsHFAlignMargins)
			{
				xmlTextWriter_0.WriteAttributeString("alignWithMargins", "0");
			}
			if (text5.Length > 0)
			{
				method_19(xmlTextWriter_0, "oddHeader", text5);
			}
			if (text6.Length > 0)
			{
				method_19(xmlTextWriter_0, "oddFooter", text6);
			}
			if (text3.Length > 0)
			{
				method_19(xmlTextWriter_0, "evenHeader", text3);
			}
			if (text4.Length > 0)
			{
				method_19(xmlTextWriter_0, "evenFooter", text4);
			}
			if (text.Length > 0)
			{
				method_19(xmlTextWriter_0, "firstHeader", text);
			}
			if (text2.Length > 0)
			{
				method_19(xmlTextWriter_0, "firstFooter", text2);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private string method_18(string string_1, int int_1)
	{
		string result = string_1;
		if (string_1 != null)
		{
			switch (int_1)
			{
			case 0:
				if (string_1.ToUpper().IndexOf("&L") == -1)
				{
					result = "&L" + string_1;
				}
				break;
			case 1:
				if (string_1.ToUpper().IndexOf("&C") == -1)
				{
					result = "&C" + string_1;
				}
				break;
			case 2:
				if (string_1.ToUpper().IndexOf("&R") == -1)
				{
					result = "&R" + string_1;
				}
				break;
			}
		}
		else
		{
			result = "";
		}
		return result;
	}

	[Attribute0(true)]
	private void method_19(XmlTextWriter xmlTextWriter_0, string string_1, string string_2)
	{
		xmlTextWriter_0.WriteStartElement(string_1);
		if (string_2.StartsWith(" ") || string_2.EndsWith(" "))
		{
			xmlTextWriter_0.WriteAttributeString("xml:space", null, "preserve");
		}
		xmlTextWriter_0.WriteString(string_2);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_20(XmlTextWriter xmlTextWriter_0)
	{
		if (worksheet_0.HorizontalPageBreaks != null && worksheet_0.HorizontalPageBreaks.Count > 0)
		{
			xmlTextWriter_0.WriteStartElement("rowBreaks");
			int count = worksheet_0.HorizontalPageBreaks.Count;
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			xmlTextWriter_0.WriteAttributeString("manualBreakCount", Class1618.smethod_80(count));
			for (int i = 0; i < count; i++)
			{
				HorizontalPageBreak horizontalPageBreak = worksheet_0.HorizontalPageBreaks[i];
				if (horizontalPageBreak != null)
				{
					xmlTextWriter_0.WriteStartElement("brk");
					xmlTextWriter_0.WriteAttributeString("id", Class1618.smethod_80(horizontalPageBreak.Row));
					if (horizontalPageBreak.StartColumn != 0)
					{
						xmlTextWriter_0.WriteAttributeString("min", Class1618.smethod_80(horizontalPageBreak.StartColumn));
					}
					xmlTextWriter_0.WriteAttributeString("max", Class1618.smethod_80(horizontalPageBreak.EndColumn));
					xmlTextWriter_0.WriteAttributeString("man", "1");
					xmlTextWriter_0.WriteEndElement();
				}
			}
			xmlTextWriter_0.WriteEndElement();
		}
		if (worksheet_0.VerticalPageBreaks == null || worksheet_0.VerticalPageBreaks.Count <= 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("colBreaks");
		int count2 = worksheet_0.VerticalPageBreaks.Count;
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count2));
		xmlTextWriter_0.WriteAttributeString("manualBreakCount", Class1618.smethod_80(count2));
		for (int j = 0; j < count2; j++)
		{
			VerticalPageBreak verticalPageBreak = worksheet_0.VerticalPageBreaks[j];
			if (verticalPageBreak != null)
			{
				xmlTextWriter_0.WriteStartElement("brk");
				xmlTextWriter_0.WriteAttributeString("id", Class1618.smethod_80(verticalPageBreak.Column));
				if (verticalPageBreak.StartRow != 0)
				{
					xmlTextWriter_0.WriteAttributeString("min", Class1618.smethod_80(verticalPageBreak.StartRow));
				}
				xmlTextWriter_0.WriteAttributeString("max", Class1618.smethod_80(verticalPageBreak.EndRow));
				xmlTextWriter_0.WriteAttributeString("man", "1");
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_21(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("dimension");
		if (worksheet_0.Cells.method_22(0) >= 0 && worksheet_0.Cells.method_20(0) >= 0)
		{
			string value = CellsHelper.ColumnIndexToName(worksheet_0.Cells.MinColumn) + (worksheet_0.Cells.MinRow + 1) + ":" + CellsHelper.ColumnIndexToName(worksheet_0.Cells.method_22(0)) + (worksheet_0.Cells.method_20(0) + 1);
			xmlTextWriter_0.WriteAttributeString("ref", value);
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("ref", "A1:A1");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_22(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("sheetViews");
		xmlTextWriter_0.WriteStartElement("sheetView");
		if (workbook_0.Worksheets.method_77())
		{
			xmlTextWriter_0.WriteAttributeString("windowProtection", "1");
		}
		if (worksheet_0.method_11())
		{
			xmlTextWriter_0.WriteAttributeString("showFormulas", "1");
		}
		if (!worksheet_0.IsGridlinesVisible)
		{
			xmlTextWriter_0.WriteAttributeString("showGridLines", "0");
		}
		if (!worksheet_0.IsRowColumnHeadersVisible)
		{
			xmlTextWriter_0.WriteAttributeString("showRowColHeaders", "0");
		}
		if (!worksheet_0.DisplayZeros)
		{
			xmlTextWriter_0.WriteAttributeString("showZeros", "0");
		}
		if (worksheet_0.DisplayRightToLeft)
		{
			xmlTextWriter_0.WriteAttributeString("rightToLeft", "1");
		}
		if (worksheet_0.IsSelected)
		{
			xmlTextWriter_0.WriteAttributeString("tabSelected", "1");
		}
		if (!worksheet_0.IsOutlineShown)
		{
			xmlTextWriter_0.WriteAttributeString("showOutlineSymbols", "0");
		}
		int num = worksheet_0.method_44();
		if (num < 64)
		{
			xmlTextWriter_0.WriteAttributeString("defaultGridColor", "0");
		}
		string text = Class1618.smethod_203(worksheet_0.ViewType);
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("view", text);
		}
		if (worksheet_0.ViewType == ViewType.PageLayoutView && !worksheet_0.IsRulerVisible)
		{
			xmlTextWriter_0.WriteAttributeString("showRuler", "0");
		}
		if (worksheet_0.Zoom != 100)
		{
			xmlTextWriter_0.WriteAttributeString("zoomScale", Class1618.smethod_80(worksheet_0.Zoom));
		}
		if (worksheet_0.method_39()[0] != 100)
		{
			xmlTextWriter_0.WriteAttributeString("zoomScaleNormal", Class1618.smethod_80(worksheet_0.method_39()[0]));
		}
		if (worksheet_0.method_39()[1] != 60)
		{
			xmlTextWriter_0.WriteAttributeString("zoomScaleSheetLayoutView", Class1618.smethod_80(worksheet_0.method_39()[1]));
		}
		if (worksheet_0.method_39()[2] != 100)
		{
			xmlTextWriter_0.WriteAttributeString("zoomScalePageLayoutView", Class1618.smethod_80(worksheet_0.method_39()[2]));
		}
		if (num < 64)
		{
			xmlTextWriter_0.WriteAttributeString("colorId", Class1618.smethod_80(num));
		}
		xmlTextWriter_0.WriteAttributeString("workbookViewId", "0");
		string value = CellsHelper.ColumnIndexToName(worksheet_0.FirstVisibleColumn) + Class1618.smethod_80(worksheet_0.FirstVisibleRow + 1);
		xmlTextWriter_0.WriteAttributeString("topLeftCell", value);
		Class1566 @class = Class1566.smethod_2(worksheet_0);
		if (@class.class1567_0 != null)
		{
			Class1567 class1567_ = @class.class1567_0;
			xmlTextWriter_0.WriteStartElement("pane");
			if (class1567_.double_0 != 0.0)
			{
				xmlTextWriter_0.WriteAttributeString("xSplit", Class1618.smethod_79(class1567_.double_0));
			}
			if (class1567_.double_1 != 0.0)
			{
				xmlTextWriter_0.WriteAttributeString("ySplit", Class1618.smethod_79(class1567_.double_1));
			}
			if (class1567_.string_1 != null)
			{
				xmlTextWriter_0.WriteAttributeString("topLeftCell", class1567_.string_1);
			}
			if (class1567_.string_2 != null)
			{
				xmlTextWriter_0.WriteAttributeString("activePane", class1567_.string_2);
			}
			xmlTextWriter_0.WriteAttributeString("state", class1567_.string_0);
			xmlTextWriter_0.WriteEndElement();
		}
		ArrayList arrayList = @class.arrayList_0;
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1568 class2 = (Class1568)arrayList[i];
			xmlTextWriter_0.WriteStartElement("selection");
			if (class2.string_0 != null)
			{
				xmlTextWriter_0.WriteAttributeString("pane", class2.string_0);
			}
			if (class2.string_1 != null)
			{
				xmlTextWriter_0.WriteAttributeString("activeCell", class2.string_1);
			}
			if (class2.int_0 != 0)
			{
				xmlTextWriter_0.WriteAttributeString("activeCellId", Class1618.smethod_80(class2.int_0));
			}
			if (class2.string_2 != null && class2.string_2.Length > 0)
			{
				xmlTextWriter_0.WriteAttributeString("sqref", class2.string_2);
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_23(XmlTextWriter xmlTextWriter_0)
	{
		if (worksheet_0.Cells.method_18().Count != 0)
		{
			xmlTextWriter_0.WriteStartElement("mergeCells");
			Class1133 @class = worksheet_0.Cells.method_18();
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(@class.Count));
			new ArrayList(@class.Count);
			for (int i = 0; i < @class.Count; i++)
			{
				CellArea cellArea_ = @class[i];
				xmlTextWriter_0.WriteStartElement("mergeCell");
				xmlTextWriter_0.WriteAttributeString("ref", Class1618.smethod_15(cellArea_));
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_24(Row row_0, int int_1, int int_2, int int_3, XmlTextWriter xmlTextWriter_0)
	{
		if (int_3 > int_2)
		{
			xmlTextWriter_0.WriteAttributeString("spans", int_2 + 1 + ":" + (int_3 + 1));
		}
		if (int_1 > -1 && class1539_0.hashtable_0.Contains(int_1))
		{
			string value = (string)class1539_0.hashtable_0[int_1];
			xmlTextWriter_0.WriteAttributeString("s", value);
			xmlTextWriter_0.WriteAttributeString("customFormat", "1");
		}
		double innerHeight = row_0.InnerHeight;
		xmlTextWriter_0.WriteAttributeString("ht", Class1618.smethod_79(innerHeight));
		if (!row_0.IsHeightMatched)
		{
			xmlTextWriter_0.WriteAttributeString("customHeight", "1");
		}
		if (row_0.IsHidden)
		{
			xmlTextWriter_0.WriteAttributeString("hidden", "1");
		}
		if (row_0.method_24() != 0)
		{
			xmlTextWriter_0.WriteAttributeString("outlineLevel", Class1618.smethod_84(row_0.method_24()));
		}
		if (row_0.method_18())
		{
			xmlTextWriter_0.WriteAttributeString("collapsed", "1");
		}
	}

	private void method_25(XmlTextWriter xmlTextWriter_0)
	{
		class1541_0.class1540_0.class521_0.method_0(worksheet_0);
		xmlTextWriter_0.WriteStartElement("sheetData");
		Interface0 @interface = null;
		bool flag = false;
		if (class1541_0.class1540_0.class978_0 != null)
		{
			@interface = class1541_0.class1540_0.class978_0.method_0(worksheet_0);
			if (@interface == null)
			{
				@interface = new Class11(worksheet_0);
			}
			else
			{
				flag = true;
			}
		}
		else
		{
			@interface = new Class11(worksheet_0);
		}
		string text = null;
		Row row = null;
		Cell cell = null;
		int num = -2;
		while (true)
		{
			row = @interface.NextRow();
			if (row == null)
			{
				break;
			}
			num = -2;
			text = Class1618.smethod_80(row.int_0 + 1);
			xmlTextWriter_0.WriteStartElement("row");
			xmlTextWriter_0.WriteAttributeString("r", text);
			bool flag2 = row.method_27();
			int num2 = row.method_10();
			if (flag && flag2 && !(row is Class981))
			{
				num2 = class1541_0.class1540_0.class978_0.method_3(num2);
			}
			if (!flag && row.method_1())
			{
				method_24(row, flag2 ? num2 : (-1), row.StartColumn, row.EndColumn, xmlTextWriter_0);
			}
			else
			{
				method_24(row, flag2 ? num2 : (-1), -1, -1, xmlTextWriter_0);
			}
			while (true)
			{
				cell = @interface.NextCell();
				if (cell == null)
				{
					break;
				}
				int num3 = cell.method_36();
				if (cell.IsBlank && (num3 == -1 || (num3 == 15 && !flag2 && class1541_0.class1540_0.class521_0.method_1(cell.Column) == 15)))
				{
					continue;
				}
				if (num3 == -1)
				{
					num3 = ((!row.method_27()) ? class1541_0.class1540_0.class521_0.method_1(cell.Column) : num2);
				}
				xmlTextWriter_0.WriteStartElement("c");
				if (bool_0 || cell.Column != num + 1)
				{
					xmlTextWriter_0.WriteAttributeString("r", method_27(text, cell));
				}
				Class977 @class = null;
				if (num3 != -1 && num3 != 15)
				{
					if (flag)
					{
						if (cell is Class977)
						{
							@class = (Class977)cell;
						}
						else
						{
							num3 = class1541_0.class1540_0.class978_0.method_3(num3);
						}
					}
					object obj = class1539_0.hashtable_0[num3];
					if (obj != null)
					{
						string text2 = (string)obj;
						if (text2 != "0")
						{
							xmlTextWriter_0.WriteAttributeString("s", text2);
						}
					}
				}
				string text3 = null;
				string text4 = null;
				bool isFormula = cell.IsFormula;
				switch (cell.method_18())
				{
				case CellValueType.IsBool:
					text3 = "b";
					text4 = (cell.BoolValue ? "1" : "0");
					break;
				case CellValueType.IsError:
					text3 = "e";
					text4 = ((cell.Value == null || !("#Recursive Reference!" != cell.Value.ToString())) ? "#VALUE!" : cell.Value.ToString());
					break;
				case CellValueType.IsDateTime:
				case CellValueType.IsNumeric:
					text3 = "n";
					text4 = cell.DoubleValue.ToString(CultureInfo.InvariantCulture);
					break;
				case CellValueType.IsString:
				{
					object obj2 = cell.method_57();
					if (obj2 is Class1719)
					{
						text3 = "s";
						int int_ = ((Class1719)obj2).int_1;
						if (class1541_0.class1540_0.class978_0 != null && int_ >= class1541_0.class1540_0.class978_0.int_2)
						{
							if (class1541_0.class1540_0.class978_0.lightCellsDataProvider_0.IsGatherString())
							{
								text4 = Class1618.smethod_80(class1541_0.class1540_0.class978_0.method_6(((Class1719)obj2).string_0, bool_0: true));
								break;
							}
							text3 = "str";
							text4 = Class1618.smethod_4(((Class1719)obj2).string_0);
						}
						else
						{
							text4 = Class1618.smethod_80(int_);
						}
					}
					else if (obj2 is string)
					{
						if (!isFormula && flag && (@class != null || cell is Class977) && ((Class977)cell).bool_0)
						{
							text3 = "s";
							text4 = Class1618.smethod_80(class1541_0.class1540_0.class978_0.method_6((string)obj2, bool_0: true));
						}
						else
						{
							text3 = "str";
							text4 = Class1618.smethod_4((string)obj2);
						}
					}
					break;
				}
				}
				if (text3 != null && text3 != "n")
				{
					xmlTextWriter_0.WriteAttributeString("t", text3);
				}
				if (isFormula)
				{
					if (cell.IsInArray)
					{
						if (cell.IsArrayHeader)
						{
							method_26(xmlTextWriter_0, cell, bool_1: false, -1);
						}
					}
					else if (cell.method_46())
					{
						if (cell.method_45())
						{
							int int_2 = arrayList_0.Add(cell);
							method_26(xmlTextWriter_0, cell, bool_1: true, int_2);
						}
						else
						{
							Cell cell2 = cell.method_47();
							int num4 = arrayList_0.IndexOf(cell2);
							if (num4 != -1)
							{
								xmlTextWriter_0.WriteStartElement("f");
								if (cell.method_16(cell2))
								{
									xmlTextWriter_0.WriteAttributeString("ca", "1");
								}
								xmlTextWriter_0.WriteAttributeString("t", "shared");
								xmlTextWriter_0.WriteAttributeString("si", Class1618.smethod_80(num4));
								xmlTextWriter_0.WriteEndElement();
							}
						}
					}
					else if (cell.IsInTable)
					{
						Class1119 class2 = cell.method_52();
						if (class2 != null)
						{
							xmlTextWriter_0.WriteStartElement("f");
							string value = Class1618.smethod_15(class2.cellArea_0);
							xmlTextWriter_0.WriteAttributeString("t", "dataTable");
							xmlTextWriter_0.WriteAttributeString("ref", value);
							xmlTextWriter_0.WriteAttributeString("dt2D", class2.method_7() ? "1" : "0");
							xmlTextWriter_0.WriteAttributeString("dtr", class2.method_9() ? "1" : "0");
							if (class2.method_7())
							{
								xmlTextWriter_0.WriteAttributeString("r1", class2.method_12());
								xmlTextWriter_0.WriteAttributeString("r2", class2.method_14());
							}
							else if (class2.method_9())
							{
								xmlTextWriter_0.WriteAttributeString("r1", class2.method_12());
							}
							else
							{
								xmlTextWriter_0.WriteAttributeString("r1", class2.method_14());
							}
							if (class2.method_3())
							{
								xmlTextWriter_0.WriteAttributeString("del1", "1");
							}
							if (class2.method_5())
							{
								xmlTextWriter_0.WriteAttributeString("del2", "1");
							}
							xmlTextWriter_0.WriteEndElement();
						}
					}
					else
					{
						string text5 = cell.method_38();
						if (text5 != null && text5.Length > 0)
						{
							xmlTextWriter_0.WriteStartElement("f");
							if (cell.method_16(null))
							{
								xmlTextWriter_0.WriteAttributeString("ca", "1");
							}
							string text6 = Class1618.smethod_93(text5);
							xmlTextWriter_0.WriteString(text6);
							xmlTextWriter_0.WriteEndElement();
						}
					}
				}
				if (text4 != null)
				{
					if (text4.Length > 0)
					{
						xmlTextWriter_0.WriteStartElement("v");
						xmlTextWriter_0.WriteString(text4);
						xmlTextWriter_0.WriteEndElement();
					}
					else
					{
						xmlTextWriter_0.WriteElementString("v", null);
					}
				}
				xmlTextWriter_0.WriteEndElement();
				num = cell.Column;
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_26(XmlTextWriter xmlTextWriter_0, Cell cell_0, bool bool_1, int int_1)
	{
		string string_ = cell_0.method_38();
		xmlTextWriter_0.WriteStartElement("f");
		if (cell_0.method_16(null))
		{
			xmlTextWriter_0.WriteAttributeString("ca", "1");
		}
		if (bool_1)
		{
			xmlTextWriter_0.WriteAttributeString("t", "shared");
			xmlTextWriter_0.WriteAttributeString("si", Class1618.smethod_80(int_1));
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("t", "array");
		}
		string value = Class1618.smethod_15(cell_0.method_50().CellArea);
		xmlTextWriter_0.WriteAttributeString("ref", value);
		string text = Class1618.smethod_93(string_);
		xmlTextWriter_0.WriteString(text);
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_27(string string_1, Cell cell_0)
	{
		object obj = hashtable_0[cell_0.Column];
		string text;
		if (obj != null)
		{
			text = (string)obj;
		}
		else
		{
			text = CellsHelper.ColumnIndexToName(cell_0.Column);
			hashtable_0[cell_0.Column] = text;
		}
		return text + string_1;
	}

	private void method_28(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("sheetFormatPr");
		double double_ = 0.0;
		if (worksheet_0.Cells.Columns.Width != 0.0)
		{
			double_ = worksheet_0.Cells.Columns.Width + 5.0 / (double)workbook_0.Worksheets.method_72();
		}
		xmlTextWriter_0.WriteAttributeString("defaultColWidth", Class1618.smethod_79(double_));
		xmlTextWriter_0.WriteAttributeString("defaultRowHeight", Class1618.smethod_79(worksheet_0.Cells.StandardHeight));
		if (!worksheet_0.Cells.IsDefaultRowHeightMatched)
		{
			xmlTextWriter_0.WriteAttributeString("customHeight", "1");
		}
		if (worksheet_0.Cells.method_25())
		{
			xmlTextWriter_0.WriteAttributeString("zeroHeight", "1");
		}
		if (worksheet_0.Cells.method_29() != 0)
		{
			xmlTextWriter_0.WriteAttributeString("outlineLevelRow", Class1618.smethod_84(worksheet_0.Cells.method_29()));
		}
		if (worksheet_0.Cells.method_27() != 0)
		{
			xmlTextWriter_0.WriteAttributeString("outlineLevelCol", Class1618.smethod_84(worksheet_0.Cells.method_27()));
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_29(XmlTextWriter xmlTextWriter_0)
	{
		ColumnCollection columns = worksheet_0.Cells.Columns;
		if (columns.Count == 0 && (columns.column_0 == null || !columns.column_0.method_18()))
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("cols");
		Column column = columns.column_0;
		int num = 16383;
		if (column != null)
		{
			if (column.method_18())
			{
				Column column2 = new Column(column.Index, worksheet_0, columns.Width, column);
				column = column2;
				num = column2.Index;
			}
			else
			{
				column = null;
			}
		}
		int num2 = 0;
		int num3;
		for (num3 = 0; num3 < columns.Count; num3++)
		{
			Column columnByIndex = columns.GetColumnByIndex(num3);
			if (columnByIndex.Index - num2 != 0 && column != null && columnByIndex.Index > num)
			{
				if (num2 < num)
				{
					num2 = num;
				}
				column.method_0(num2);
				method_30(xmlTextWriter_0, column, columnByIndex.Index - num2 - 1);
			}
			columnByIndex.method_5();
			int num4 = 0;
			for (num3++; num3 < columns.Count; num3++)
			{
				Column columnByIndex2 = columns.GetColumnByIndex(num3);
				if (columnByIndex2.Index == columnByIndex.Index + num4 + 1 && columnByIndex.method_9(columnByIndex2))
				{
					num4++;
					continue;
				}
				num3--;
				break;
			}
			method_30(xmlTextWriter_0, columnByIndex, num4);
			num2 = columnByIndex.Index + num4 + 1;
		}
		if (column != null && num2 <= 16383)
		{
			if (num2 < num)
			{
				num2 = num;
			}
			column.method_0(num2);
			method_30(xmlTextWriter_0, column, 16383 - num2);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_30(XmlTextWriter xmlTextWriter_0, Column column_0, int int_1)
	{
		xmlTextWriter_0.WriteStartElement("col");
		xmlTextWriter_0.WriteAttributeString("min", Class1618.smethod_80(column_0.Index + 1));
		string text = null;
		int num = column_0.method_5();
		if (num != 15 && num != 4095 && num != 0 && class1539_0.hashtable_0.ContainsKey(num))
		{
			text = (string)class1539_0.hashtable_0[num];
		}
		int num2 = column_0.Index + 1 + int_1;
		xmlTextWriter_0.WriteAttributeString("max", Class1618.smethod_80(num2));
		double double_ = (double)GetColumnWidthPixel(column_0) / (double)workbook_0.Worksheets.method_72();
		xmlTextWriter_0.WriteAttributeString("width", Class1618.smethod_79(double_));
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("style", text);
		}
		if (column_0.IsHidden)
		{
			xmlTextWriter_0.WriteAttributeString("hidden", "1");
		}
		else if (column_0.method_16())
		{
			xmlTextWriter_0.WriteAttributeString("bestFit", "1");
		}
		xmlTextWriter_0.WriteAttributeString("customWidth", "1");
		if (column_0.method_3() != 0)
		{
			xmlTextWriter_0.WriteAttributeString("outlineLevel", Class1618.smethod_84(column_0.method_3()));
		}
		if (column_0.method_14())
		{
			xmlTextWriter_0.WriteAttributeString("collapsed", "1");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private int GetColumnWidthPixel(Column column_0)
	{
		WorksheetCollection worksheets = workbook_0.Worksheets;
		double width = column_0.Width;
		if (width > 1.0)
		{
			int num = (int)(width * (double)worksheets.method_72() + 0.5);
			int num2 = (int)((double)(worksheets.method_72() * worksheets.method_71()) / 256.0 + 0.5);
			return num + num2;
		}
		return (int)(width * (double)(worksheets.method_72() + (int)((double)(worksheets.method_72() * worksheets.method_71()) / 256.0 + 0.5)) + 0.5);
	}

	[Attribute0(true)]
	private void method_31(XmlTextWriter xmlTextWriter_0)
	{
		if (class1541_0.arrayList_0 == null || class1541_0.arrayList_0.Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("hyperlinks");
		for (int i = 0; i < class1541_0.arrayList_0.Count; i++)
		{
			Class1537 @class = (Class1537)class1541_0.arrayList_0[i];
			xmlTextWriter_0.WriteStartElement("hyperlink");
			xmlTextWriter_0.WriteAttributeString("ref", Class1618.smethod_15(@class.hyperlink_0.Area));
			if (@class.string_0 != null && @class.string_0.Length > 0)
			{
				xmlTextWriter_0.WriteAttributeString("r:id", null, @class.string_0);
			}
			if (@class.int_0 == 2)
			{
				xmlTextWriter_0.WriteAttributeString("location", @class.hyperlink_0.Address);
			}
			if (@class.hyperlink_0.ScreenTip != null && @class.hyperlink_0.ScreenTip.Length > 0)
			{
				xmlTextWriter_0.WriteAttributeString("tooltip", @class.hyperlink_0.ScreenTip);
			}
			string textToDisplay = @class.hyperlink_0.TextToDisplay;
			if (textToDisplay != null && textToDisplay.Length > 0)
			{
				xmlTextWriter_0.WriteAttributeString("display", textToDisplay);
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private int method_32()
	{
		int num = 1;
		for (int i = 0; i < worksheet_0.ConditionalFormattings.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = worksheet_0.ConditionalFormattings[i];
			for (int j = 0; j < formatConditionCollection.Count; j++)
			{
				num++;
			}
		}
		if (worksheet_0.pivotTableCollection_0 != null)
		{
			for (int k = 0; k < worksheet_0.pivotTableCollection_0.Count; k++)
			{
				PivotTable pivotTable = worksheet_0.pivotTableCollection_0[k];
				if (pivotTable.pivotFormatConditionCollection_0 != null)
				{
					for (int l = 0; l < pivotTable.pivotFormatConditionCollection_0.Count; l++)
					{
						num++;
					}
				}
			}
		}
		return num;
	}

	private void method_33(XmlTextWriter xmlTextWriter_0)
	{
		PivotTableCollection pivotTableCollection_ = worksheet_0.pivotTableCollection_0;
		if (pivotTableCollection_ == null || pivotTableCollection_.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < pivotTableCollection_.Count; i++)
		{
			PivotTable pivotTable = pivotTableCollection_[i];
			method_32();
			PivotFormatConditionCollection pivotFormatConditionCollection_ = pivotTable.pivotFormatConditionCollection_0;
			if (pivotFormatConditionCollection_ == null || pivotFormatConditionCollection_.Count == 0)
			{
				continue;
			}
			for (int j = 0; j < pivotFormatConditionCollection_.Count; j++)
			{
				FormatConditionCollection formatConditionCollection_ = pivotFormatConditionCollection_[j].formatConditionCollection_0;
				formatConditionCollection_.method_3();
				if (formatConditionCollection_.Count != 0 && !formatConditionCollection_.method_6(bool_2: false))
				{
					method_35(xmlTextWriter_0, formatConditionCollection_, bool_1: false);
				}
			}
		}
	}

	private void method_34(XmlTextWriter xmlTextWriter_0)
	{
		if (worksheet_0.ConditionalFormattings.Count == 0)
		{
			return;
		}
		int_0 = method_32();
		for (int i = 0; i < worksheet_0.ConditionalFormattings.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = worksheet_0.ConditionalFormattings[i];
			formatConditionCollection.method_3();
			if (formatConditionCollection.Count != 0 && !formatConditionCollection.method_6(bool_2: false))
			{
				method_35(xmlTextWriter_0, formatConditionCollection, bool_1: false);
			}
		}
	}

	private void method_35(XmlTextWriter xmlTextWriter_0, FormatConditionCollection formatConditionCollection_0, bool bool_1)
	{
		if (!bool_1)
		{
			xmlTextWriter_0.WriteStartElement("conditionalFormatting");
			if (formatConditionCollection_0.bool_1)
			{
				xmlTextWriter_0.WriteAttributeString("pivot", "1");
			}
			if (formatConditionCollection_0.arrayList_1 != null && formatConditionCollection_0.arrayList_1.Count > 0)
			{
				string_0 = Class1618.smethod_32(formatConditionCollection_0.arrayList_1, 0, formatConditionCollection_0.arrayList_1.Count);
				xmlTextWriter_0.WriteAttributeString("sqref", string_0);
			}
			string string_ = method_39(formatConditionCollection_0);
			for (int i = 0; i < formatConditionCollection_0.Count; i++)
			{
				FormatCondition formatCondition_ = formatConditionCollection_0[i];
				method_40(xmlTextWriter_0, formatCondition_, string_, int_0, bool_1);
				int_0--;
			}
			xmlTextWriter_0.WriteEndElement();
			return;
		}
		if (formatConditionCollection_0.arrayList_1 != null && formatConditionCollection_0.arrayList_1.Count > 0)
		{
			string_0 = Class1618.smethod_32(formatConditionCollection_0.arrayList_1, 0, formatConditionCollection_0.arrayList_1.Count);
		}
		xmlTextWriter_0.WriteStartElement("x14:conditionalFormatting");
		xmlTextWriter_0.WriteAttributeString("xmlns:xm", "http://schemas.microsoft.com/office/excel/2006/main");
		if (formatConditionCollection_0.bool_1)
		{
			xmlTextWriter_0.WriteAttributeString("pivot", "1");
		}
		string string_2 = method_39(formatConditionCollection_0);
		for (int j = 0; j < formatConditionCollection_0.Count; j++)
		{
			FormatCondition formatCondition_2 = formatConditionCollection_0[j];
			method_40(xmlTextWriter_0, formatCondition_2, string_2, int_0, bool_1);
			int_0--;
		}
		xmlTextWriter_0.WriteStartElement("xm:sqref");
		xmlTextWriter_0.WriteString(string_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	internal void method_36(XmlTextWriter xmlTextWriter_0)
	{
		if (worksheet_0.PivotTables.Count == 0)
		{
			return;
		}
		for (int i = 0; i < worksheet_0.PivotTables.Count; i++)
		{
			PivotTable pivotTable = worksheet_0.PivotTables[i];
			PivotFormatConditionCollection pivotFormatConditionCollection_ = pivotTable.pivotFormatConditionCollection_0;
			if (pivotFormatConditionCollection_ == null || pivotFormatConditionCollection_.Count == 0)
			{
				continue;
			}
			xmlTextWriter_0.WriteStartElement("ext");
			xmlTextWriter_0.WriteAttributeString("uri", "{78C0D931-6437-407d-A8EE-F0AAD7539E65}");
			xmlTextWriter_0.WriteAttributeString("xmlns:x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
			xmlTextWriter_0.WriteStartElement("x14:conditionalFormattings");
			int_0 = method_32();
			for (int j = 0; j < pivotFormatConditionCollection_.Count; j++)
			{
				FormatConditionCollection formatConditionCollection_ = pivotFormatConditionCollection_[j].formatConditionCollection_0;
				if (formatConditionCollection_.method_6(bool_2: true))
				{
					method_35(xmlTextWriter_0, formatConditionCollection_, bool_1: true);
				}
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
	}

	internal void method_37(XmlTextWriter xmlTextWriter_0)
	{
		ConditionalFormattingCollection conditionalFormattings = worksheet_0.ConditionalFormattings;
		if (conditionalFormattings.Count == 0 || !conditionalFormattings.method_8())
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("ext");
		xmlTextWriter_0.WriteAttributeString("uri", "{78C0D931-6437-407d-A8EE-F0AAD7539E65}");
		xmlTextWriter_0.WriteAttributeString("xmlns:x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
		xmlTextWriter_0.WriteStartElement("x14:conditionalFormattings");
		int_0 = method_32();
		foreach (FormatConditionCollection item in conditionalFormattings)
		{
			if (item.method_6(bool_2: true))
			{
				method_35(xmlTextWriter_0, item, bool_1: true);
			}
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_38(FormatCondition formatCondition_0)
	{
		string result = null;
		if (formatCondition_0.Type == FormatConditionType.CellValue && formatCondition_0.operatorType_0 != OperatorType.None)
		{
			result = Class1618.smethod_29(formatCondition_0.operatorType_0);
		}
		else if (formatCondition_0.Type == FormatConditionType.ContainsText)
		{
			result = "containsText";
		}
		else if (formatCondition_0.Type == FormatConditionType.NotContainsText)
		{
			result = "notContains";
		}
		else if (formatCondition_0.Type == FormatConditionType.BeginsWith)
		{
			result = "beginsWith";
		}
		else if (formatCondition_0.Type == FormatConditionType.EndsWith)
		{
			result = "endsWith";
		}
		return result;
	}

	private string method_39(FormatConditionCollection formatConditionCollection_0)
	{
		int num = 16383;
		int num2 = 1048575;
		for (int i = 0; i < formatConditionCollection_0.arrayList_1.Count; i++)
		{
			CellArea cellArea = (CellArea)formatConditionCollection_0.arrayList_1[i];
			if (cellArea.StartRow < num2)
			{
				num2 = cellArea.StartRow;
			}
			if (cellArea.EndRow < num2)
			{
				num2 = cellArea.EndRow;
			}
			if (cellArea.EndColumn < num)
			{
				num = cellArea.EndColumn;
			}
			if (cellArea.StartColumn < num)
			{
				num = cellArea.StartColumn;
			}
		}
		string text = CellsHelper.ColumnIndexToName(num);
		return text + Class1618.smethod_80(num2 + 1);
	}

	private void method_40(XmlTextWriter xmlTextWriter_0, FormatCondition formatCondition_0, string string_1, int int_1, bool bool_1)
	{
		FormatConditionType formatConditionType_ = formatCondition_0.formatConditionType_0;
		if (!bool_1)
		{
			xmlTextWriter_0.WriteStartElement("cfRule");
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("x14:cfRule");
		}
		xmlTextWriter_0.WriteAttributeString("type", Class1618.smethod_92(formatConditionType_));
		string text = formatCondition_0.method_2();
		if (formatCondition_0.method_24() && bool_1)
		{
			xmlTextWriter_0.WriteAttributeString("id", text);
		}
		else if (formatCondition_0.Priority == 0)
		{
			xmlTextWriter_0.WriteAttributeString("priority", Class1618.smethod_80(int_1));
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("priority", Class1618.smethod_80(formatCondition_0.Priority));
		}
		if (formatCondition_0.method_6() != -1 && !bool_1)
		{
			xmlTextWriter_0.WriteAttributeString("dxfId", Class1618.smethod_80(formatCondition_0.method_6()));
		}
		string text2 = method_38(formatCondition_0);
		if (text2 != null)
		{
			xmlTextWriter_0.WriteAttributeString("operator", text2);
		}
		if (formatCondition_0.StopIfTrue)
		{
			xmlTextWriter_0.WriteAttributeString("stopIfTrue", "1");
		}
		switch (formatConditionType_)
		{
		case FormatConditionType.Top10:
		{
			Top10 top = formatCondition_0.Top10;
			if (top.Rank != 0)
			{
				xmlTextWriter_0.WriteAttributeString("rank", Class1618.smethod_80(top.Rank));
			}
			if (top.IsBottom)
			{
				xmlTextWriter_0.WriteAttributeString("bottom", "1");
			}
			if (top.IsPercent)
			{
				xmlTextWriter_0.WriteAttributeString("percent", "1");
			}
			break;
		}
		case FormatConditionType.ContainsText:
		case FormatConditionType.NotContainsText:
		case FormatConditionType.BeginsWith:
		case FormatConditionType.EndsWith:
		{
			string text3 = formatCondition_0.Text;
			if (text3 == null || text3.Length <= 1 || text3[0] != '=')
			{
				xmlTextWriter_0.WriteAttributeString("text", text3);
			}
			break;
		}
		case FormatConditionType.TimePeriod:
		{
			string value = Class1618.smethod_142(formatCondition_0.TimePeriod);
			xmlTextWriter_0.WriteAttributeString("timePeriod", value);
			break;
		}
		case FormatConditionType.AboveAverage:
		{
			AboveAverage aboveAverage = formatCondition_0.AboveAverage;
			if (!aboveAverage.IsAboveAverage)
			{
				xmlTextWriter_0.WriteAttributeString("aboveAverage", "0");
			}
			if (aboveAverage.IsEqualAverage)
			{
				xmlTextWriter_0.WriteAttributeString("equalAverage", "1");
			}
			if (aboveAverage.StdDev != 0)
			{
				xmlTextWriter_0.WriteAttributeString("stdDev", Class1618.smethod_80(formatCondition_0.AboveAverage.StdDev));
			}
			break;
		}
		}
		switch (formatConditionType_)
		{
		default:
		{
			string formula = formatCondition_0.Formula1;
			method_46(xmlTextWriter_0, formula, bool_1);
			if (bool_1)
			{
				switch (formatConditionType_)
				{
				case FormatConditionType.ContainsText:
				case FormatConditionType.NotContainsText:
				case FormatConditionType.BeginsWith:
				case FormatConditionType.EndsWith:
					formula = formatCondition_0.Text;
					method_46(xmlTextWriter_0, formula, bool_1);
					break;
				}
			}
			break;
		}
		case FormatConditionType.CellValue:
		case FormatConditionType.Expression:
			method_46(xmlTextWriter_0, formatCondition_0.Formula1, bool_1);
			if (formatCondition_0.operatorType_0 == OperatorType.Between || formatCondition_0.operatorType_0 == OperatorType.NotBetween)
			{
				method_46(xmlTextWriter_0, formatCondition_0.Formula2, bool_1);
			}
			break;
		case FormatConditionType.ColorScale:
			method_45(xmlTextWriter_0, formatCondition_0);
			break;
		case FormatConditionType.DataBar:
			method_44(xmlTextWriter_0, formatCondition_0, bool_1);
			if (!bool_1)
			{
				method_48(xmlTextWriter_0, formatCondition_0, text);
			}
			break;
		case FormatConditionType.IconSet:
			method_41(xmlTextWriter_0, formatCondition_0, bool_1);
			break;
		}
		if (bool_1)
		{
			if (formatCondition_0.method_6() != -1)
			{
				class1590_0.method_22(xmlTextWriter_0, formatCondition_0.Style, "x14");
			}
			else
			{
				xmlTextWriter_0.WriteElementString("x14:dxf", "");
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_41(XmlTextWriter xmlTextWriter_0, FormatCondition formatCondition_0, bool bool_1)
	{
		IconSet iconSet = formatCondition_0.IconSet;
		if (!bool_1)
		{
			xmlTextWriter_0.WriteStartElement("iconSet");
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("x14:iconSet");
		}
		if (!formatCondition_0.IconSet.IsCustom)
		{
			xmlTextWriter_0.WriteAttributeString("iconSet", Class1618.smethod_134(iconSet.Type));
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("custom", "1");
		}
		if (!iconSet.ShowValue)
		{
			xmlTextWriter_0.WriteAttributeString("showValue", "0");
		}
		if (iconSet.Reverse)
		{
			xmlTextWriter_0.WriteAttributeString("reverse", "1");
		}
		for (int i = 0; i < iconSet.Cfvos.Count; i++)
		{
			ConditionalFormattingValue conditionalFormattingValue_ = iconSet.Cfvos[i];
			method_43(xmlTextWriter_0, conditionalFormattingValue_, bool_1, bool_2: false);
		}
		if (iconSet.IsCustom && bool_1)
		{
			for (int j = 0; j < iconSet.conditionalFormattingIconCollection_0.Count; j++)
			{
				ConditionalFormattingIcon conditionalFormattingIcon_ = iconSet.conditionalFormattingIconCollection_0[j];
				method_42(xmlTextWriter_0, conditionalFormattingIcon_);
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_42(XmlTextWriter xmlTextWriter_0, ConditionalFormattingIcon conditionalFormattingIcon_0)
	{
		xmlTextWriter_0.WriteStartElement("x14:cfIcon");
		xmlTextWriter_0.WriteAttributeString("iconSet", Class1618.smethod_134(conditionalFormattingIcon_0.Type));
		xmlTextWriter_0.WriteAttributeString("iconId", Class1618.smethod_80(conditionalFormattingIcon_0.Index));
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_43(XmlTextWriter xmlTextWriter_0, ConditionalFormattingValue conditionalFormattingValue_0, bool bool_1, bool bool_2)
	{
		if (!bool_1)
		{
			xmlTextWriter_0.WriteStartElement("cfvo");
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("x14:cfvo");
		}
		if (!conditionalFormattingValue_0.IsGTE)
		{
			xmlTextWriter_0.WriteAttributeString("gte", "0");
		}
		string value = Class1618.smethod_136(conditionalFormattingValue_0.Type);
		if (!bool_1)
		{
			switch (conditionalFormattingValue_0.Type)
			{
			case FormatConditionValueType.AutomaticMax:
				value = "max";
				break;
			case FormatConditionValueType.AutomaticMin:
				value = "min";
				break;
			}
		}
		xmlTextWriter_0.WriteAttributeString("type", value);
		string text = conditionalFormattingValue_0.method_3();
		if (bool_2)
		{
			if (conditionalFormattingValue_0.Type == FormatConditionValueType.AutomaticMax || conditionalFormattingValue_0.Type == FormatConditionValueType.AutomaticMin || conditionalFormattingValue_0.Type == FormatConditionValueType.Max || conditionalFormattingValue_0.Type == FormatConditionValueType.Min)
			{
				xmlTextWriter_0.WriteEndElement();
				return;
			}
		}
		else if (conditionalFormattingValue_0.Type == FormatConditionValueType.Max || conditionalFormattingValue_0.Type == FormatConditionValueType.Min)
		{
			text = "0";
		}
		if (text != null)
		{
			if (!bool_1)
			{
				xmlTextWriter_0.WriteAttributeString("val", text.ToString());
			}
			else
			{
				xmlTextWriter_0.WriteStartElement("xm:f");
				xmlTextWriter_0.WriteString(text.ToString());
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_44(XmlTextWriter xmlTextWriter_0, FormatCondition formatCondition_0, bool bool_1)
	{
		DataBar dataBar = formatCondition_0.DataBar;
		if (!bool_1)
		{
			xmlTextWriter_0.WriteStartElement("dataBar");
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("x14:dataBar");
		}
		if (formatCondition_0.method_24() && bool_1)
		{
			xmlTextWriter_0.WriteAttributeString("minLength", Class1618.smethod_80(dataBar.MinLength));
			xmlTextWriter_0.WriteAttributeString("maxLength", Class1618.smethod_80(dataBar.MaxLength));
			if (dataBar.BarFillType == DataBarFillType.DataBarFillSolid)
			{
				xmlTextWriter_0.WriteAttributeString("gradient", "0");
			}
			if (dataBar.BarBorder.Type == DataBarBorderType.DataBarBorderSolid)
			{
				xmlTextWriter_0.WriteAttributeString("border", "1");
			}
			if (dataBar.Direction != 0)
			{
				xmlTextWriter_0.WriteAttributeString("direction", Class1618.smethod_138(dataBar.Direction));
			}
			if (dataBar.NegativeBarFormat.BorderColorType != DataBarNegativeColorType.DataBarSameAsPositive)
			{
				xmlTextWriter_0.WriteAttributeString("negativeBarBorderColorSameAsPositive", "0");
			}
			if (dataBar.NegativeBarFormat.ColorType == DataBarNegativeColorType.DataBarSameAsPositive)
			{
				xmlTextWriter_0.WriteAttributeString("negativeBarColorSameAsPositive", "1");
			}
			if (dataBar.AxisPosition != 0)
			{
				xmlTextWriter_0.WriteAttributeString("axisPosition", Class1618.smethod_140(dataBar.AxisPosition));
			}
		}
		else
		{
			if (dataBar.MinLength != 10)
			{
				xmlTextWriter_0.WriteAttributeString("minLength", Class1618.smethod_80(dataBar.MinLength));
			}
			if (dataBar.MaxLength != 90)
			{
				xmlTextWriter_0.WriteAttributeString("maxLength", Class1618.smethod_80(dataBar.MaxLength));
			}
		}
		if (!dataBar.ShowValue)
		{
			xmlTextWriter_0.WriteAttributeString("showValue", "0");
		}
		method_43(xmlTextWriter_0, dataBar.MinCfvo, bool_1, bool_2: true);
		method_43(xmlTextWriter_0, dataBar.MaxCfvo, bool_1, bool_2: true);
		if (!bool_1)
		{
			Class1590.smethod_1(xmlTextWriter_0, dataBar.method_4(), "color");
		}
		else
		{
			if (dataBar.BarBorder.Type == DataBarBorderType.DataBarBorderSolid)
			{
				Class1590.smethod_1(xmlTextWriter_0, dataBar.BarBorder.method_0(), "x14:borderColor");
			}
			if (dataBar.NegativeBarFormat.ColorType == DataBarNegativeColorType.DataBarColor)
			{
				Class1590.smethod_1(xmlTextWriter_0, dataBar.NegativeBarFormat.method_2(), "x14:negativeFillColor");
			}
			if (dataBar.BarBorder.Type == DataBarBorderType.DataBarBorderSolid && dataBar.NegativeBarFormat.BorderColorType != DataBarNegativeColorType.DataBarSameAsPositive)
			{
				Class1590.smethod_1(xmlTextWriter_0, dataBar.NegativeBarFormat.method_0(), "x14:negativeBorderColor");
			}
			Class1590.smethod_1(xmlTextWriter_0, dataBar.method_0(), "x14:axisColor");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_45(XmlTextWriter xmlTextWriter_0, FormatCondition formatCondition_0)
	{
		ColorScale colorScale = formatCondition_0.ColorScale;
		xmlTextWriter_0.WriteStartElement("colorScale");
		method_43(xmlTextWriter_0, colorScale.conditionalFormattingValue_0, bool_1: false, bool_2: false);
		if (colorScale.method_0())
		{
			method_43(xmlTextWriter_0, colorScale.conditionalFormattingValue_1, bool_1: false, bool_2: false);
		}
		method_43(xmlTextWriter_0, colorScale.conditionalFormattingValue_2, bool_1: false, bool_2: false);
		Class1590.smethod_1(xmlTextWriter_0, colorScale.method_1(), "color");
		if (colorScale.conditionalFormattingValue_1 != null)
		{
			Class1590.smethod_1(xmlTextWriter_0, colorScale.method_3(), "color");
		}
		Class1590.smethod_1(xmlTextWriter_0, colorScale.method_5(), "color");
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_46(XmlTextWriter xmlTextWriter_0, string string_1, bool bool_1)
	{
		if (bool_1)
		{
			xmlTextWriter_0.WriteStartElement("xm:f");
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("formula");
		}
		xmlTextWriter_0.WriteString(method_47(string_1));
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_47(string string_1)
	{
		if (string_1 == null)
		{
			return "";
		}
		if (string_1.Length == 0)
		{
			return "\"\"";
		}
		if (string_1[0] == '=')
		{
			if (string_1.Length == 1)
			{
				return "\"=\"";
			}
			return string_1.Substring(1);
		}
		if (Class1677.smethod_19(string_1))
		{
			return string_1;
		}
		return "\"" + string_1 + "\"";
	}

	private void method_48(XmlTextWriter xmlTextWriter_0, FormatCondition formatCondition_0, string string_1)
	{
		xmlTextWriter_0.WriteStartElement("extLst");
		xmlTextWriter_0.WriteStartElement("ext");
		xmlTextWriter_0.WriteAttributeString("uri", "{B025F937-C7B1-47D3-B67F-A62EFF666E3E}");
		xmlTextWriter_0.WriteAttributeString("xmlns:x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
		xmlTextWriter_0.WriteStartElement("x14:id");
		xmlTextWriter_0.WriteString(string_1);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}
}
