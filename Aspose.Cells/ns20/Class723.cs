using System;
using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using Aspose.Cells.Properties;
using Aspose.Cells.Tables;
using ns2;
using ns27;
using ns52;
using ns59;

namespace ns20;

internal class Class723
{
	private Worksheet worksheet_0;

	private Cells cells_0;

	private Workbook workbook_0;

	private WorksheetCollection worksheetCollection_0;

	private Class721 class721_0;

	internal Class723(Worksheet worksheet_1, Class721 class721_1)
	{
		worksheet_0 = worksheet_1;
		cells_0 = worksheet_0.Cells;
		workbook_0 = worksheet_1.Workbook;
		worksheetCollection_0 = workbook_0.Worksheets;
		class721_0 = class721_1;
	}

	internal void Write(Class1725 class1725_0)
	{
		Class605 @class = new Class605(worksheet_0.Type, worksheetCollection_0.method_23());
		@class.vmethod_0(class1725_0);
		long long_ = class1725_0.method_10();
		method_7(class1725_0, class721_0.class933_0.Count);
		method_0(class1725_0, long_);
		class1725_0.method_8(512);
		class1725_0.method_8(14);
		for (int i = 0; i < 14; i++)
		{
			class1725_0.WriteByte(0);
		}
		int int_ = (int)class1725_0.method_10();
		class721_0.method_0(class1725_0);
		method_8(class721_0, class1725_0, long_, int_);
		method_1(class1725_0);
		if (workbook_0.SaveOptions.ClearData)
		{
			cells_0.Clear();
		}
		Class630 class2 = new Class630();
		class2.vmethod_0(class1725_0);
	}

	internal void method_0(Class1725 class1725_0, long long_0)
	{
		class1725_0.method_8(13);
		class1725_0.method_8(2);
		switch (worksheet_0.Workbook.Settings.CalcMode)
		{
		default:
			class1725_0.method_8(1);
			break;
		case CalcModeType.AutomaticExceptTable:
			class1725_0.method_6(2);
			break;
		case CalcModeType.Manual:
			class1725_0.method_8(0);
			break;
		}
		class1725_0.method_8(12);
		class1725_0.method_8(2);
		class1725_0.method_6((ushort)worksheet_0.Workbook.Settings.MaxIteration);
		class1725_0.method_8(15);
		class1725_0.method_8(2);
		class1725_0.method_8((!worksheet_0.Workbook.Settings.method_1()) ? 1 : 0);
		class1725_0.method_8(17);
		class1725_0.method_8(2);
		if (worksheet_0.Workbook.Settings.Iteration)
		{
			class1725_0.method_8(1);
		}
		else
		{
			class1725_0.method_8(0);
		}
		class1725_0.method_8(16);
		class1725_0.method_8(8);
		class1725_0.method_9(worksheet_0.Workbook.Settings.MaxChange);
		class1725_0.method_8(95);
		class1725_0.method_8(2);
		if (worksheet_0.Workbook.Settings.RecalculateBeforeSave)
		{
			class1725_0.method_8(1);
		}
		else
		{
			class1725_0.method_8(0);
		}
		Cells cells = worksheet_0.Cells;
		PageSetup pageSetup = cells.PageSetup;
		class1725_0.method_8(42);
		class1725_0.method_8(2);
		if (pageSetup.PrintHeadings)
		{
			class1725_0.method_8(1);
		}
		else
		{
			class1725_0.method_8(0);
		}
		class1725_0.method_8(43);
		class1725_0.method_8(2);
		if (pageSetup.PrintGridlines)
		{
			class1725_0.method_8(1);
		}
		else
		{
			class1725_0.method_8(0);
		}
		class1725_0.method_8(130);
		class1725_0.method_8(2);
		class1725_0.method_8(1);
		if (cells.method_27() > 0 || cells.method_29() > 0)
		{
			Class644 @class = new Class644();
			if (cells.method_27() > 0)
			{
				@class.method_4((ushort)(17 + cells.method_27() * 12));
				@class.method_5((byte)(cells.method_27() + 1));
			}
			if (cells.method_29() > 0)
			{
				@class.method_6((ushort)(17 + cells.method_29() * 12));
				@class.method_7((byte)(cells.method_29() + 1));
			}
			@class.vmethod_0(class1725_0);
		}
		method_6(class1725_0);
		class1725_0.method_5(131201);
		byte[] bytes = BitConverter.GetBytes(worksheet_0.short_0);
		if (pageSetup.IsPercentScale)
		{
			bytes[1] &= 254;
		}
		else
		{
			bytes[1] |= 1;
		}
		if (worksheet_0.Outline.SummaryRowBelow)
		{
			bytes[0] |= 64;
		}
		else
		{
			bytes[0] &= 191;
		}
		if (worksheet_0.Outline.SummaryColumnRight)
		{
			bytes[0] |= 128;
		}
		else
		{
			bytes[0] &= 127;
		}
		class1725_0.method_3(bytes);
		method_2(class1725_0);
		method_3(class1725_0);
		Class645 class2 = new Class645(bool_0: true);
		class2.method_4(pageSetup.string_2);
		class2.vmethod_0(class1725_0);
		Class645 class3 = new Class645(bool_0: false);
		class3.method_4(pageSetup.string_3);
		class3.vmethod_0(class1725_0);
		class1725_0.method_8(131);
		class1725_0.method_8(2);
		if (pageSetup.CenterHorizontally)
		{
			class1725_0.method_8(1);
		}
		else
		{
			class1725_0.method_8(0);
		}
		class1725_0.method_8(132);
		class1725_0.method_8(2);
		if (pageSetup.CenterVertically)
		{
			class1725_0.method_8(1);
		}
		else
		{
			class1725_0.method_8(0);
		}
		if (pageSetup.LeftMargin >= 0.0)
		{
			class1725_0.method_8(38);
			class1725_0.method_8(8);
			class1725_0.method_9(pageSetup.LeftMarginInch);
		}
		if (pageSetup.RightMargin >= 0.0)
		{
			class1725_0.method_8(39);
			class1725_0.method_8(8);
			class1725_0.method_9(pageSetup.RightMarginInch);
		}
		if (pageSetup.TopMargin >= 0.0)
		{
			class1725_0.method_8(40);
			class1725_0.method_8(8);
			class1725_0.method_9(pageSetup.TopMarginInch);
		}
		if (pageSetup.BottomMargin >= 0.0)
		{
			class1725_0.method_8(41);
			class1725_0.method_8(8);
			class1725_0.method_9(pageSetup.BottomMarginInch);
		}
		if (pageSetup.method_4() != null)
		{
			Class668 class4 = new Class668();
			class4.method_4(pageSetup.method_4());
			class4.vmethod_0(class1725_0);
		}
		Class702 class5 = new Class702();
		class5.method_3(pageSetup.method_12());
		class5.vmethod_0(class1725_0);
		Class583 class6 = new Class583();
		class6.method_4(pageSetup);
		class6.vmethod_0(class1725_0);
		object obj = worksheet_0.method_49();
		if (obj != null)
		{
			if (obj is ArrayList)
			{
				foreach (byte[] item in (ArrayList)obj)
				{
					class1725_0.method_3(item);
				}
			}
			else if (obj is byte[])
			{
				Class602 class7 = new Class602();
				class7.method_4((byte[])obj);
				class7.vmethod_0(class1725_0);
			}
		}
		if (worksheet_0.method_52() != null && worksheet_0.CustomProperties.Count > 0)
		{
			for (int i = 0; i < worksheet_0.CustomProperties.Count; i++)
			{
				CustomProperty customProperty_ = worksheet_0.CustomProperties[i];
				Class675 class8 = new Class675(customProperty_);
				class8.method_4(class1725_0);
			}
		}
		if (worksheet_0.IsProtected)
		{
			if (!worksheet_0.Protection.AllowEditingContent)
			{
				class1725_0.method_8(18);
				class1725_0.method_8(2);
				class1725_0.method_8(1);
			}
			if (!worksheet_0.Protection.AllowEditingScenario)
			{
				class1725_0.method_8(221);
				class1725_0.method_8(2);
				class1725_0.method_8(1);
			}
			if (!worksheet_0.Protection.AllowEditingObject)
			{
				class1725_0.method_8(99);
				class1725_0.method_8(2);
				class1725_0.method_8(1);
			}
			if (worksheet_0.Protection.method_2() != 0)
			{
				class1725_0.method_8(19);
				class1725_0.method_8(2);
				class1725_0.method_3(BitConverter.GetBytes((short)worksheet_0.Protection.method_2()));
			}
		}
		if (!cells.method_9())
		{
			method_4(class1725_0, (uint)long_0);
		}
		method_5(class1725_0);
		method_13(class1725_0);
		if (worksheet_0.method_32() != null)
		{
			worksheet_0.method_32().vmethod_0(class1725_0);
		}
	}

	internal void method_1(Class1725 class1725_0)
	{
		if (worksheet_0.method_36() != null && worksheet_0.method_36().Count != 0)
		{
			Class1710 @class = new Class1710(worksheetCollection_0, worksheet_0, worksheet_0.method_36(), class1725_0);
			@class.method_0();
		}
		if (worksheet_0.Cells.PageSetup.method_32() != null && worksheet_0.Cells.PageSetup.method_32().Count != 0)
		{
			Class687 class2 = new Class687();
			class2.method_6(cells_0.PageSetup.method_32());
			class2.method_7(class1725_0);
		}
		CommentCollection comments = worksheet_0.Comments;
		if (worksheet_0.Comments.Count > 0)
		{
			foreach (Comment item in comments)
			{
				if (item.method_0())
				{
					Class660 class3 = new Class660();
					class3.method_4((ushort)item.Row, (byte)item.Column, item.CommentShape.method_23(), item.IsVisible, item.Author);
					class3.vmethod_0(class1725_0);
				}
			}
		}
		if (worksheet_0.pivotTableCollection_0 != null && worksheet_0.pivotTableCollection_0.Count != 0)
		{
			foreach (PivotTable item2 in worksheet_0.pivotTableCollection_0)
			{
				item2.Write(class1725_0);
			}
		}
		Class719 class4 = new Class719(FileFormatType.Default);
		class4.method_6(worksheet_0);
		class4.vmethod_0(class1725_0);
		if (worksheet_0.Zoom != 100)
		{
			Class694 class5 = new Class694(worksheet_0.Zoom);
			class5.vmethod_0(class1725_0);
		}
		if (worksheet_0.ViewType == ViewType.PageLayoutView)
		{
			Class584 class6 = new Class584();
			class6.method_4(worksheet_0);
			class6.vmethod_0(class1725_0);
		}
		if (worksheet_0.GetPanes() != null)
		{
			Class665 class7 = new Class665();
			if (worksheet_0.method_13())
			{
				class7.method_4(worksheet_0.GetPanes());
			}
			else
			{
				class7.method_5(worksheet_0.GetPanes());
			}
			class7.vmethod_0(class1725_0);
		}
		Class1733 class8 = worksheet_0.method_34();
		if (class8 != null && class8.Count > 0)
		{
			foreach (Class1732 item3 in class8)
			{
				Class695 class9 = new Class695();
				class9.method_4(item3);
				class9.vmethod_0(class1725_0);
			}
		}
		method_9(class1725_0);
		if (worksheet_0.method_21() != null)
		{
			ArrayList arrayList = worksheet_0.method_21();
			if (arrayList.Count > 0)
			{
				foreach (byte[] item4 in arrayList)
				{
					class1725_0.method_3(item4);
				}
			}
		}
		method_10(class1725_0);
		method_11(class1725_0);
		method_12(class1725_0);
		if (worksheet_0.Validations.Count != 0)
		{
			Class628 class10 = new Class628();
			if (class10.method_4(worksheet_0.Validations))
			{
				class10.vmethod_0(class1725_0);
				for (int i = 0; i < worksheet_0.Validations.Count; i++)
				{
					Validation validation_ = worksheet_0.Validations[i];
					Class629 class11 = new Class629(worksheet_0);
					if (class11.method_4(validation_))
					{
						class11.vmethod_0(class1725_0);
					}
				}
			}
		}
		if (worksheet_0.method_30() != null)
		{
			ArrayList arrayList2 = worksheet_0.method_30();
			if (arrayList2.Count > 0)
			{
				foreach (byte[] item5 in arrayList2)
				{
					class1725_0.method_3(item5);
				}
			}
		}
		if (worksheet_0.method_47() != null)
		{
			Class616 class12 = new Class616();
			class12.method_4(worksheet_0.method_47());
			class12.vmethod_0(class1725_0);
		}
		if (worksheet_0.method_50() != null)
		{
			foreach (byte[] item6 in worksheet_0.method_50())
			{
				class1725_0.method_3(item6);
			}
		}
		if (worksheet_0.method_17() != null)
		{
			ListObjectCollection listObjectCollection = worksheet_0.method_17();
			if (listObjectCollection.Count > 0)
			{
				Class690 class13 = new Class690();
				class13.vmethod_0(class1725_0);
				for (int j = 0; j < listObjectCollection.Count; j++)
				{
					ListObject listObject_ = listObjectCollection[j];
					Class691 class14 = new Class691();
					class14.method_6(j, listObject_);
					class14.method_10(class1725_0);
					Class589 class15 = new Class589();
					class15.method_5(listObject_);
					class15.vmethod_0(class1725_0);
					class15 = new Class589();
					class15.method_7(listObject_);
					class15.vmethod_0(class1725_0);
					class15 = new Class589();
					class15.method_6(listObject_);
					class15.vmethod_0(class1725_0);
				}
			}
		}
		if (worksheet_0.method_0() != null)
		{
			Class688 class16 = new Class688();
			class16.method_4(worksheet_0.method_0());
			class16.vmethod_0(class1725_0);
		}
		if (worksheet_0.errorCheckOptionCollection_0 != null && worksheet_0.errorCheckOptionCollection_0.Count > 0)
		{
			for (int k = 0; k < worksheet_0.errorCheckOptionCollection_0.Count; k++)
			{
				Class550 class17 = new Class550();
				class17.method_4(worksheet_0.errorCheckOptionCollection_0[k]);
				class17.vmethod_0(class1725_0);
			}
		}
		if (worksheet_0.AllowEditRanges != null)
		{
			ProtectedRangeCollection allowEditRanges = worksheet_0.AllowEditRanges;
			for (int l = 0; l < allowEditRanges.Count; l++)
			{
				ProtectedRange protectedRange_ = allowEditRanges[l];
				Class689 class18 = new Class689();
				class18.method_4(protectedRange_);
				class18.vmethod_0(class1725_0);
			}
		}
		if (!worksheet_0.internalColor_0.method_2())
		{
			int num = worksheet_0.method_41();
			if (num != 64 || worksheet_0.internalColor_0.ColorType == ColorType.Theme)
			{
				Class686 class19 = new Class686(num, worksheet_0.internalColor_0);
				class19.vmethod_0(class1725_0);
			}
		}
	}

	private void method_2(Class1725 class1725_0)
	{
		HorizontalPageBreakCollection hPageBreaks = cells_0.HPageBreaks;
		if (hPageBreaks.Count > 0)
		{
			Class647 @class = new Class647(FileFormatType.Default);
			@class.method_4(hPageBreaks);
			@class.vmethod_0(class1725_0);
		}
	}

	private void method_3(Class1725 class1725_0)
	{
		VerticalPageBreakCollection vPageBreaks = cells_0.VPageBreaks;
		if (vPageBreaks.Count > 0)
		{
			Class717 @class = new Class717(FileFormatType.Default);
			@class.method_4(vPageBreaks);
			@class.vmethod_0(class1725_0);
		}
	}

	private void method_4(Class1725 class1725_0, uint uint_0)
	{
		long num = class1725_0.method_10();
		class1725_0.Seek(uint_0 + 16);
		class1725_0.method_4((uint)num);
		class1725_0.Seek(num);
		Class625 @class = new Class625((ushort)cells_0.Columns.Width);
		@class.vmethod_0(class1725_0);
	}

	private void method_5(Class1725 class1725_0)
	{
		ArrayList arrayList = cells_0.Columns.method_11();
		foreach (Class617 item in arrayList)
		{
			item.vmethod_0(class1725_0);
		}
	}

	private void method_6(Class1725 class1725_0)
	{
		Class626 @class = new Class626();
		if (cells_0.method_0() >= 0.0)
		{
			@class.method_4(cells_0.method_23(), (ushort)cells_0.method_0());
		}
		@class.vmethod_0(class1725_0);
	}

	private void method_7(Class1725 class1725_0, int int_0)
	{
		class1725_0.method_7(523);
		class1725_0.method_7((short)(16 + 4 * int_0));
		class1725_0.method_5(0);
		class1725_0.method_5(0);
		class1725_0.method_5(0);
		class1725_0.method_5(0);
		for (int i = 0; i < int_0; i++)
		{
			class1725_0.method_5(0);
		}
	}

	private void method_8(Class721 class721_1, Class1725 class1725_0, long long_0, int int_0)
	{
		int num = (int)class1725_0.method_10();
		class1725_0.Seek(int_0 - 14);
		class1725_0.method_5(class721_1.int_0);
		class1725_0.method_5(class721_1.int_1);
		class1725_0.method_7((short)class721_0.int_2);
		class1725_0.method_7((short)class721_0.int_3);
		class1725_0.Seek(long_0 + 8);
		class1725_0.method_5(class721_1.int_0);
		class1725_0.method_5(class721_1.int_1);
		class1725_0.Seek(long_0 + 20);
		int count = class721_1.class933_0.Count;
		for (int i = 0; i < count; i++)
		{
			class1725_0.method_5(class721_1.class933_0[i] + int_0);
		}
		class1725_0.Seek(num);
	}

	private void method_9(Class1725 class1725_0)
	{
		Class642 @class = new Class642();
		ColumnCollection columns = cells_0.Columns;
		for (int i = 0; i < columns.Count; i++)
		{
			Column columnByIndex = columns.GetColumnByIndex(i);
			@class.method_4((byte)columnByIndex.Index);
		}
		@class.vmethod_0(class1725_0);
		if (cells_0.method_9())
		{
			Class706 class2 = new Class706(cells_0.Columns.Width, worksheetCollection_0.method_71());
			class2.vmethod_0(class1725_0);
		}
	}

	private void method_10(Class1725 class1725_0)
	{
		if (cells_0.method_18().Count <= 0)
		{
			return;
		}
		if (cells_0.method_18().Count <= 1024)
		{
			Class654 @class = new Class654(cells_0.method_18());
			@class.vmethod_0(class1725_0);
			return;
		}
		int num = 0;
		int num2 = 1024;
		while (num < cells_0.method_18().Count)
		{
			Class654 class2 = new Class654(cells_0.method_18(), num, num2);
			class2.vmethod_0(class1725_0);
			num = num2;
			num2 = ((num2 + 1024 >= cells_0.method_18().Count) ? cells_0.method_18().Count : (num2 + 1024));
		}
	}

	private void method_11(Class1725 class1725_0)
	{
		if (worksheet_0.conditionalFormattingCollection_0 == null)
		{
			return;
		}
		ConditionalFormattingCollection conditionalFormattingCollection_ = worksheet_0.conditionalFormattingCollection_0;
		int count = conditionalFormattingCollection_.Count;
		if (count < 1)
		{
			return;
		}
		int num = 1026;
		for (int i = 0; i < count; i++)
		{
			FormatConditionCollection formatConditionCollection = conditionalFormattingCollection_[i];
			int rangeCount = formatConditionCollection.RangeCount;
			if (rangeCount <= num)
			{
				continue;
			}
			int num2;
			for (int j = num; j < rangeCount; j += num2)
			{
				num2 = rangeCount - j;
				if (num2 > num)
				{
					num2 = num;
				}
				FormatConditionCollection formatConditionCollection2 = new FormatConditionCollection(conditionalFormattingCollection_);
				formatConditionCollection2.Copy(formatConditionCollection, null);
				if (j + num2 < rangeCount)
				{
					formatConditionCollection2.arrayList_1.RemoveRange(j + num2, rangeCount - (j + num2));
				}
				formatConditionCollection2.arrayList_1.RemoveRange(0, j);
				conditionalFormattingCollection_.Add(formatConditionCollection2);
			}
			formatConditionCollection.arrayList_1.RemoveRange(num, rangeCount - num);
		}
		count = conditionalFormattingCollection_.Count;
		ArrayList arrayList = new ArrayList();
		for (int k = 0; k < count; k++)
		{
			FormatConditionCollection formatConditionCollection3 = conditionalFormattingCollection_[k];
			int num3 = 0;
			int count2 = arrayList.Count;
			int count3 = formatConditionCollection3.Count;
			for (int l = 0; l < count3; l++)
			{
				Class995 @class = new Class995(k, formatConditionCollection3[l], num3);
				arrayList.Add(@class);
				if (@class.method_0())
				{
					num3++;
				}
			}
			if (num3 < 1)
			{
				Class582 class2 = new Class582();
				class2.method_4(formatConditionCollection3, formatConditionCollection3.Count, k);
				class2.vmethod_0(class1725_0);
				for (int m = 0; m < count3; m++)
				{
					Class579 class3 = new Class579();
					class3.method_4((Class995)arrayList[count2 + m]);
					class3.vmethod_0(class1725_0);
				}
				for (int num4 = arrayList.Count - 1; num4 >= count2; num4--)
				{
					arrayList.RemoveAt(num4);
				}
				continue;
			}
			Class618 class4 = new Class618();
			class4.method_4(formatConditionCollection3, num3, k);
			class4.vmethod_0(class1725_0);
			bool flag = true;
			for (int n = 0; n < count3; n++)
			{
				Class995 class5 = (Class995)arrayList[count2 + n];
				if (class5.method_0())
				{
					Class580 class6 = new Class580();
					class6.method_4(class5);
					class6.vmethod_0(class1725_0);
					if (flag && class5.method_1())
					{
						flag = false;
					}
				}
				else
				{
					flag = false;
				}
			}
			if (flag)
			{
				for (int num5 = arrayList.Count - 1; num5 >= count2; num5--)
				{
					arrayList.RemoveAt(num5);
				}
			}
		}
		foreach (Class995 item in arrayList)
		{
			Class540 class8 = new Class540();
			if (item.method_0())
			{
				class8.method_4(item);
				class8.vmethod_0(class1725_0);
				continue;
			}
			class8.method_5(item.int_1);
			class8.vmethod_0(class1725_0);
			Class579 class9 = new Class579();
			class9.method_4(item);
			class9.vmethod_0(class1725_0);
		}
	}

	private void method_12(Class1725 class1725_0)
	{
		if (cells_0.Hyperlinks.Count <= 0)
		{
			return;
		}
		byte[] array = new byte[10000];
		int num = 0;
		for (int i = 0; i < cells_0.Hyperlinks.Count; i++)
		{
			Hyperlink hyperlink = cells_0.Hyperlinks[i];
			if (hyperlink.Address == null || !(hyperlink.Address != ""))
			{
				continue;
			}
			Class646 @class = new Class646(hyperlink.Area, hyperlink.TextToDisplay, hyperlink.Address, hyperlink);
			if (num < array.Length)
			{
				if (num + 4 + @class.Data.Length < array.Length)
				{
					array[num] = 184;
					array[num + 1] = 1;
					Array.Copy(BitConverter.GetBytes(@class.Length), 0, array, num + 2, 2);
					Array.Copy(@class.Data, 0, array, num + 4, @class.Length);
					num += 4 + @class.Length;
				}
				else
				{
					class1725_0.method_1(array, num);
					array = new byte[10000];
					num = 0;
					array[0] = 184;
					array[0 + 1] = 1;
					Array.Copy(BitConverter.GetBytes(@class.Length), 0, array, 0 + 2, 2);
					Array.Copy(@class.Data, 0, array, 0 + 4, @class.Length);
					num = 0 + (4 + @class.Length);
				}
			}
			if (hyperlink.ScreenTip != null && hyperlink.ScreenTip != "")
			{
				Class676 class2 = new Class676();
				class2.method_4(hyperlink.Area, hyperlink.ScreenTip);
				if (num + 4 + class2.Data.Length < array.Length)
				{
					array[num + 1] = 8;
					Array.Copy(BitConverter.GetBytes(class2.Length), 0, array, num + 2, 2);
					Array.Copy(class2.Data, 0, array, num + 4, class2.Length);
					num += 4 + class2.Length;
				}
				else
				{
					class1725_0.method_1(array, num);
					array = new byte[10000];
					num = 0;
					array[0 + 1] = 8;
					Array.Copy(BitConverter.GetBytes(class2.Length), 0, array, 0 + 2, 2);
					Array.Copy(class2.Data, 0, array, 0 + 4, class2.Length);
					num = 0 + (4 + class2.Length);
				}
			}
		}
		if (num != 0)
		{
			class1725_0.method_1(array, num);
		}
	}

	private void method_13(Class1725 class1725_0)
	{
		if (worksheet_0.method_24() < 1)
		{
			return;
		}
		if (worksheet_0.AutoFilter.method_6())
		{
			class1725_0.method_5(155);
		}
		class1725_0.method_8(157);
		class1725_0.method_8(2);
		class1725_0.method_6((ushort)worksheet_0.method_24());
		if (worksheet_0.AutoFilter.method_5() != null && worksheet_0.AutoFilter.method_5().Count > 0)
		{
			if (worksheet_0.AutoFilter.bool_0)
			{
				worksheet_0.AutoFilter.Refresh();
			}
			FilterColumnCollection filterColumnCollection = worksheet_0.AutoFilter.method_5();
			for (int i = 0; i < filterColumnCollection.Count; i++)
			{
				FilterColumn byIndex = filterColumnCollection.GetByIndex(i);
				if (byIndex != null)
				{
					Class598 @class = new Class598();
					@class.method_4(byIndex);
					@class.vmethod_0(class1725_0);
				}
			}
		}
		DataSorter dataSorter_ = worksheet_0.AutoFilter.dataSorter_0;
		if (dataSorter_ == null || dataSorter_.method_0().Count <= 0)
		{
			return;
		}
		CellArea area = dataSorter_.Area;
		Class544 class2 = new Class544();
		class2.method_4(dataSorter_, area);
		class2.vmethod_0(class1725_0);
		foreach (Class1108 item in dataSorter_.method_0())
		{
			Class543 class4 = new Class543();
			CellArea cellArea_ = default(CellArea);
			if (dataSorter_.SortLeftToRight)
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
			class4.method_4(item, cellArea_);
			class4.vmethod_0(class1725_0);
		}
	}
}
