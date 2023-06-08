using System.Collections;
using System.IO;
using Aspose.Cells;
using ns16;
using ns2;
using ns9;

namespace ns10;

internal class Class1228
{
	private Class1540 class1540_0;

	private Workbook workbook_0;

	private MemoryStream memoryStream_0;

	private Class1229 class1229_0;

	private Class1541 class1541_0;

	internal Class1228(Class1229 class1229_1, Class1540 class1540_1)
	{
		class1540_0 = class1540_1;
		class1229_0 = class1229_1;
		workbook_0 = class1540_1.workbook_0;
		memoryStream_0 = new MemoryStream();
	}

	internal void Write(Class1541 class1541_1, string string_0, Stream6 stream6_0)
	{
		class1541_0 = class1541_1;
		Write();
		Class1229.smethod_1(string_0, memoryStream_0, stream6_0);
		memoryStream_0.Close();
		memoryStream_0 = null;
	}

	private void Write()
	{
		Worksheet worksheet_ = class1541_0.worksheet_0;
		Class316 @class = new Class316(129);
		@class.method_0(memoryStream_0);
		Class395 class2 = new Class395();
		class2.method_6(worksheet_);
		class2.method_0(memoryStream_0);
		method_18();
		method_3(worksheet_, workbook_0);
		method_14();
		method_15();
		if (class1541_0.worksheet_0.method_0() != null)
		{
			Class378 class3 = new Class378(worksheet_.Protection);
			class3.method_0(memoryStream_0);
		}
		if (worksheet_.method_24() > 0)
		{
			smethod_0(worksheet_.AutoFilter, memoryStream_0);
		}
		if (worksheet_.Cells.method_18() != null && worksheet_.Cells.method_18().Count != 0)
		{
			method_13(worksheet_);
		}
		if (worksheet_.conditionalFormattingCollection_0 != null && worksheet_.ConditionalFormattings.Count != 0)
		{
			method_8(worksheet_);
		}
		if (worksheet_.Validations.Count != 0)
		{
			method_7(worksheet_);
		}
		if (class1541_0.arrayList_0 != null && class1541_0.arrayList_0.Count > 0)
		{
			method_6();
		}
		method_4(worksheet_);
		if (class1541_0.class1358_0.string_0 != null)
		{
			Class356 class4 = new Class356(class1541_0.class1358_0.string_0);
			class4.method_0(memoryStream_0);
		}
		if (class1541_0.class1534_1.string_0 != null)
		{
			Class371 class5 = new Class371(class1541_0.class1534_1.string_0);
			class5.method_0(memoryStream_0);
		}
		if (class1541_0.class1534_0.string_0 != null)
		{
			Class370 class6 = new Class370(class1541_0.class1534_0.string_0);
			class6.method_0(memoryStream_0);
		}
		if (class1541_0.string_3 != null)
		{
			Class321 class7 = new Class321(class1541_0.string_3);
			class7.method_0(memoryStream_0);
		}
		method_0();
		method_1();
		method_2();
		Class316 class8 = new Class316(130);
		class8.method_0(memoryStream_0);
	}

	private void method_0()
	{
		ArrayList arrayList_ = class1541_0.arrayList_3;
		if (arrayList_.Count != 0)
		{
			Class316 @class = new Class316(638);
			@class.method_0(memoryStream_0);
			for (int i = 0; i < arrayList_.Count; i++)
			{
				Class1538 class1538_ = (Class1538)arrayList_[i];
				Class317 class2 = new Class317(class1538_);
				class2.method_0(memoryStream_0);
			}
			Class316 class3 = new Class316(640);
			class3.method_0(memoryStream_0);
		}
	}

	private void method_1()
	{
		if (class1541_0.worksheet_0.class1557_0 != null && class1541_0.worksheet_0.class1557_0.arrayList_2.Count != 0)
		{
			Class316 @class = new Class316(643);
			@class.method_0(memoryStream_0);
			ArrayList arrayList_ = class1541_0.worksheet_0.class1557_0.arrayList_2;
			for (int i = 0; i < arrayList_.Count; i++)
			{
				Class1550 class1550_ = (Class1550)arrayList_[i];
				Class319 class2 = new Class319(class1550_);
				class2.method_0(memoryStream_0);
			}
			Class316 class3 = new Class316(645);
			class3.method_0(memoryStream_0);
		}
	}

	private void method_2()
	{
		int count = class1541_0.hashtable_2.Count;
		if (count != 0)
		{
			Class316 @class = new Class316(660, count);
			@class.method_0(memoryStream_0);
			IEnumerator enumerator = class1541_0.hashtable_2.Values.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string string_ = (string)enumerator.Current;
				Class387 class2 = new Class387(string_);
				class2.method_0(memoryStream_0);
			}
			Class316 class3 = new Class316(662);
			class3.method_0(memoryStream_0);
		}
	}

	private void method_3(Worksheet worksheet_0, Workbook workbook_1)
	{
		Class394 @class = new Class394(worksheet_0, workbook_1);
		@class.method_0(memoryStream_0);
	}

	internal static void smethod_0(AutoFilter autoFilter_0, MemoryStream memoryStream_1)
	{
		Class323 @class = new Class323(autoFilter_0.method_7());
		@class.method_0(memoryStream_1);
		for (int i = 0; i < autoFilter_0.method_5().Count; i++)
		{
			FilterColumn filterColumn = autoFilter_0.method_5()[i];
			if (filterColumn.FilterType == FilterType.None)
			{
				continue;
			}
			Class329 class2 = new Class329(filterColumn);
			class2.method_0(memoryStream_1);
			switch (filterColumn.FilterType)
			{
			case FilterType.ColorFilter:
			{
				ColorFilter colorFilter_ = (ColorFilter)filterColumn.Filter;
				Class347 class12 = new Class347();
				class12.method_6(colorFilter_);
				class12.method_0(memoryStream_1);
				break;
			}
			case FilterType.CustomFilters:
			{
				CustomFilterCollection customFilterCollection = (CustomFilterCollection)filterColumn.Filter;
				int int_ = 0;
				if (customFilterCollection.And && customFilterCollection.Count > 1)
				{
					int_ = 1;
				}
				Class316 class9 = new Class316(172, int_);
				class9.method_0(memoryStream_1);
				for (int k = 0; k < customFilterCollection.Count; k++)
				{
					CustomFilter customFilter_ = customFilterCollection[k];
					Class354 class10 = new Class354();
					class10.method_6(customFilter_);
					class10.method_0(memoryStream_1);
				}
				Class316 class11 = new Class316(173);
				class11.method_0(memoryStream_1);
				break;
			}
			case FilterType.DynamicFilter:
			{
				DynamicFilter dynamicFilter_ = (DynamicFilter)filterColumn.Filter;
				Class358 class13 = new Class358();
				class13.method_6(dynamicFilter_);
				class13.method_0(memoryStream_1);
				break;
			}
			case FilterType.MultipleFilters:
			{
				MultipleFilterCollection multipleFilterCollection = (MultipleFilterCollection)filterColumn.Filter;
				Class330 class5 = new Class330(multipleFilterCollection);
				class5.method_0(memoryStream_1);
				for (int j = 0; j < multipleFilterCollection.Count; j++)
				{
					object obj = multipleFilterCollection[j];
					if (obj is DateTimeGroupItem)
					{
						Class355 class6 = new Class355();
						class6.method_6((DateTimeGroupItem)obj);
						class6.method_0(memoryStream_1);
					}
					else
					{
						Class366 class7 = new Class366((string)obj);
						class7.method_0(memoryStream_1);
					}
				}
				Class316 class8 = new Class316(166);
				class8.method_0(memoryStream_1);
				break;
			}
			case FilterType.IconFilter:
			{
				IconFilter iconFilter_ = (IconFilter)filterColumn.Filter;
				Class369 class4 = new Class369();
				class4.method_6(iconFilter_);
				class4.method_0(memoryStream_1);
				break;
			}
			case FilterType.Top10:
			{
				Top10Filter top10Filter_ = (Top10Filter)filterColumn.Filter;
				Class391 class3 = new Class391();
				class3.method_6(top10Filter_);
				class3.method_0(memoryStream_1);
				break;
			}
			}
			Class316 class14 = new Class316(164);
			class14.method_0(memoryStream_1);
		}
		Class316 class15 = new Class316(162);
		class15.method_0(memoryStream_1);
	}

	private void method_4(Worksheet worksheet_0)
	{
		PageSetup pageSetup = worksheet_0.PageSetup;
		Class376 @class = new Class376(worksheet_0.PageSetup);
		@class.method_0(memoryStream_0);
		Class372 class2 = new Class372(worksheet_0.PageSetup);
		class2.method_0(memoryStream_0);
		Class375 class3 = new Class375(worksheet_0.PageSetup);
		class3.method_0(memoryStream_0);
		if (worksheet_0.HorizontalPageBreaks.Count > 0)
		{
			Class332 class4 = new Class332(worksheet_0);
			class4.method_0(memoryStream_0);
			for (int i = 0; i < worksheet_0.HorizontalPageBreaks.Count; i++)
			{
				Class343 class5 = new Class343();
				class5.method_6(worksheet_0.HorizontalPageBreaks[i]);
				class5.method_0(memoryStream_0);
			}
			Class316 class6 = new Class316(393);
			class6.method_0(memoryStream_0);
		}
		if (worksheet_0.VerticalPageBreaks.Count > 0)
		{
			Class324 class7 = new Class324(worksheet_0);
			class7.method_0(memoryStream_0);
			for (int j = 0; j < worksheet_0.VerticalPageBreaks.Count; j++)
			{
				Class343 class8 = new Class343();
				class8.method_7(worksheet_0.VerticalPageBreaks[j]);
				class8.method_0(memoryStream_0);
			}
			Class316 class9 = new Class316(395);
			class9.method_0(memoryStream_0);
		}
		method_5(pageSetup);
	}

	private void method_5(PageSetup pageSetup_0)
	{
		Class405 @class = new Class405();
		@class.method_6(pageSetup_0);
		@class.method_0(memoryStream_0);
		Class316 class2 = new Class316(480);
		class2.method_0(memoryStream_0);
	}

	private void method_6()
	{
		for (int i = 0; i < class1541_0.arrayList_0.Count; i++)
		{
			Class1537 link = (Class1537)class1541_0.arrayList_0[i];
			Class406 @class = new Class406();
			@class.SetLink(link);
			@class.method_0(memoryStream_0);
		}
	}

	private void method_7(Worksheet worksheet_0)
	{
		if (worksheet_0.Validations.Count != 0)
		{
			Class396 @class = new Class396();
			@class.method_6(worksheet_0.Validations);
			@class.method_0(memoryStream_0);
			for (int i = 0; i < worksheet_0.Validations.Count; i++)
			{
				Validation validation_ = worksheet_0.Validations[i];
				Class404 class2 = new Class404();
				class2.method_6(validation_);
				class2.method_0(memoryStream_0);
			}
			Class316 class3 = new Class316(574);
			class3.method_0(memoryStream_0);
		}
	}

	private void method_8(Worksheet worksheet_0)
	{
		if (worksheet_0.ConditionalFormattings.Count == 0)
		{
			return;
		}
		for (int i = 0; i < worksheet_0.ConditionalFormattings.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = worksheet_0.ConditionalFormattings[i];
			Class326 @class = new Class326();
			@class.method_6(formatConditionCollection);
			@class.method_0(memoryStream_0);
			for (int j = 0; j < formatConditionCollection.Count; j++)
			{
				FormatCondition formatCondition = formatConditionCollection[j];
				Class333 class2 = new Class333();
				class2.method_6(formatCondition);
				class2.method_0(memoryStream_0);
				if (formatCondition.Type == FormatConditionType.IconSet)
				{
					method_9(formatCondition);
				}
				else if (formatCondition.Type == FormatConditionType.DataBar)
				{
					method_11(formatCondition);
				}
				else if (formatCondition.Type == FormatConditionType.ColorScale)
				{
					method_12(formatCondition);
				}
				Class316 class3 = new Class316(464);
				class3.method_0(memoryStream_0);
			}
			Class316 class4 = new Class316(462);
			class4.method_0(memoryStream_0);
		}
	}

	private void method_9(FormatCondition formatCondition_0)
	{
		IconSet iconSet = formatCondition_0.IconSet;
		Class331 @class = new Class331();
		@class.method_6(iconSet);
		@class.method_0(memoryStream_0);
		for (int i = 0; i < iconSet.Cfvos.Count; i++)
		{
			ConditionalFormattingValue conditionalFormattingValue_ = iconSet.Cfvos[i];
			method_10(conditionalFormattingValue_);
		}
		Class316 class2 = new Class316(466);
		class2.method_0(memoryStream_0);
	}

	private void method_10(ConditionalFormattingValue conditionalFormattingValue_0)
	{
		Class346 @class = new Class346(conditionalFormattingValue_0);
		@class.method_0(memoryStream_0);
	}

	private void method_11(FormatCondition formatCondition_0)
	{
		DataBar dataBar = formatCondition_0.DataBar;
		Class328 @class = new Class328(dataBar);
		@class.method_0(memoryStream_0);
		method_10(dataBar.conditionalFormattingValue_0);
		method_10(dataBar.conditionalFormattingValue_1);
		Class348 class2 = new Class348(dataBar.method_4(), workbook_0);
		class2.method_0(memoryStream_0);
		Class316 class3 = new Class316(468);
		class3.method_0(memoryStream_0);
	}

	private void method_12(FormatCondition formatCondition_0)
	{
		ColorScale colorScale = formatCondition_0.ColorScale;
		method_10(colorScale.conditionalFormattingValue_0);
		if (colorScale.conditionalFormattingValue_1 != null)
		{
			method_10(colorScale.conditionalFormattingValue_1);
		}
		method_10(colorScale.conditionalFormattingValue_2);
		Class348 @class = new Class348(colorScale.method_1(), workbook_0);
		@class.method_0(memoryStream_0);
		if (colorScale.conditionalFormattingValue_1 != null)
		{
			@class = new Class348(colorScale.method_3(), workbook_0);
			@class.method_0(memoryStream_0);
		}
		@class = new Class348(colorScale.method_5(), workbook_0);
		@class.method_0(memoryStream_0);
	}

	private void method_13(Worksheet worksheet_0)
	{
		Class1133 @class = worksheet_0.Cells.method_18();
		Class316 class2 = new Class316(177, @class.Count);
		class2.method_0(memoryStream_0);
		for (int i = 0; i < @class.Count; i++)
		{
			CellArea cellArea_ = @class[i];
			Class373 class3 = new Class373(cellArea_);
			class3.method_0(memoryStream_0);
		}
		Class316 class4 = new Class316(178);
		class4.method_0(memoryStream_0);
	}

	private void method_14()
	{
		ColumnCollection columns = class1541_0.worksheet_0.Cells.Columns;
		if (columns.Count == 0 && (columns.column_0 == null || !columns.column_0.method_18()))
		{
			return;
		}
		Class316 @class = new Class316(390);
		@class.method_0(memoryStream_0);
		int num = 16383;
		Column column = columns.column_0;
		if (column != null)
		{
			if (column.method_18())
			{
				Column column2 = new Column(column.Index, class1541_0.worksheet_0, columns.Width, column);
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
				Class403 class2 = new Class403();
				class2.method_6(column, columnByIndex.Index - 1, workbook_0.Worksheets.method_71(), class1540_0.class1539_0.hashtable_0);
				class2.method_0(memoryStream_0);
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
			Class403 class3 = new Class403();
			class3.method_6(columnByIndex, columnByIndex.Index + num4, workbook_0.Worksheets.method_71(), class1540_0.class1539_0.hashtable_0);
			class3.method_0(memoryStream_0);
			num2 = columnByIndex.Index + num4 + 1;
		}
		if (column != null && num2 <= 16383)
		{
			if (num2 < num)
			{
				num2 = num;
			}
			column.method_0(num2);
			Class403 class4 = new Class403();
			class4.method_6(column, 16383, workbook_0.Worksheets.method_71(), class1540_0.class1539_0.hashtable_0);
			class4.method_0(memoryStream_0);
		}
		Class316 class5 = new Class316(391);
		class5.method_0(memoryStream_0);
	}

	private void method_15()
	{
		Class316 @class = new Class316(145);
		@class.method_0(memoryStream_0);
		Cells cells = class1541_0.worksheet_0.Cells;
		for (int i = 0; i < cells.Rows.Count; i++)
		{
			Row rowByIndex = cells.Rows.GetRowByIndex(i);
			if (rowByIndex.Cells.Count == 0)
			{
				method_16(rowByIndex);
			}
			else
			{
				method_17(cells, rowByIndex, rowByIndex.Cells);
			}
		}
		Class316 class2 = new Class316(146);
		class2.method_0(memoryStream_0);
	}

	private void method_16(Row row_0)
	{
		Class408 @class = new Class408();
		@class.method_6(row_0, 0, 0, class1540_0.class1539_0.hashtable_0);
		@class.method_0(memoryStream_0);
	}

	private void method_17(Cells cells_0, Row row_0, ArrayList arrayList_0)
	{
		Class408 @class = new Class408();
		Hashtable hashtable_ = class1540_0.class1539_0.hashtable_0;
		int column = ((Cell)arrayList_0[0]).Column;
		int column2 = ((Cell)arrayList_0[arrayList_0.Count - 1]).Column;
		@class.method_6(row_0, column, column2, hashtable_);
		@class.method_0(memoryStream_0);
		Cell cell = null;
		bool flag = false;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Cell cell2 = (Cell)arrayList_0[i];
			flag = cell == null || cell.Column + 1 != cell2.Column;
			switch (cell2.method_20())
			{
			case Enum199.const_0:
			{
				Class398 class7 = new Class398();
				class7.method_6(flag, cell2, hashtable_);
				class7.method_0(memoryStream_0);
				break;
			}
			case Enum199.const_1:
			{
				Class399 class6 = new Class399();
				class6.method_6(cell2, hashtable_);
				class6.method_0(memoryStream_0);
				break;
			}
			case Enum199.const_4:
			case Enum199.const_5:
			{
				Class400 class5 = new Class400();
				class5.method_6(cell2, hashtable_);
				class5.method_0(memoryStream_0);
				break;
			}
			case Enum199.const_6:
			{
				Class402 class4 = new Class402();
				class4.method_6(flag, cell2, hashtable_);
				class4.method_0(memoryStream_0);
				break;
			}
			case Enum199.const_7:
			{
				Class397 class3 = new Class397();
				class3.method_6(flag, cell2, hashtable_);
				class3.method_0(memoryStream_0);
				break;
			}
			case Enum199.const_2:
			case Enum199.const_3:
			case Enum199.const_8:
			{
				Class401 class2 = new Class401();
				class2.method_6(flag, cell2, hashtable_);
				class2.method_0(memoryStream_0);
				break;
			}
			}
			cell = cell2;
			if (cell2.IsFormula)
			{
				if (cell2.IsArrayHeader)
				{
					Class322 class8 = new Class322(cell2.method_50());
					class8.method_0(memoryStream_0);
				}
				else if (cell2.method_45())
				{
					Class379 class9 = new Class379(cell2.method_50());
					class9.method_0(memoryStream_0);
				}
			}
		}
	}

	private void method_18()
	{
		Class316 @class = new Class316(133);
		@class.method_0(memoryStream_0);
		Class340 class2 = new Class340();
		class2.method_6(class1541_0.worksheet_0);
		class2.method_0(memoryStream_0);
		if (class1541_0.worksheet_0.GetPanes() != null)
		{
			Class407 class3 = new Class407();
			class3.method_6(class1541_0.worksheet_0);
			class3.method_0(memoryStream_0);
		}
		if (class1541_0.worksheet_0.method_34() != null)
		{
			Class1733 class4 = class1541_0.worksheet_0.method_34();
			for (int i = 0; i < class4.Count; i++)
			{
				Class1732 class1732_ = (Class1732)class4[i];
				Class377 class5 = new Class377();
				class5.method_6(class1732_);
				class5.method_0(memoryStream_0);
			}
		}
		Class316 class6 = new Class316(138);
		class6.method_0(memoryStream_0);
		Class316 class7 = new Class316(134);
		class7.method_0(memoryStream_0);
	}
}
