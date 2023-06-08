using System.Collections;
using System.Runtime.CompilerServices;
using ns12;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Represents a collection of all the <see cref="T:Aspose.Cells.Name" /> objects in the spreadsheet. 
///       </summary>
public class NameCollection : CollectionBase
{
	private WorksheetCollection worksheetCollection_0;

	private Hashtable hashtable_0;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Name" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public Name this[int index] => (Name)base.InnerList[index];

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Name" /> element with the specified name.
	///        </summary>
	/// <param name="text">Name text.</param>
	/// <returns>The element with the specified name.</returns>
	public Name this[string text]
	{
		get
		{
			text = text.ToUpper();
			int sheetIndex = -1;
			text = method_20(text, out sheetIndex);
			int num = method_8(text, sheetIndex, bool_0: false);
			if (num == -1)
			{
				return null;
			}
			return this[num];
		}
	}

	internal Name this[string string_0, int int_0]
	{
		get
		{
			int num = method_8(string_0, int_0, bool_0: false);
			if (num == -1)
			{
				return null;
			}
			return this[num];
		}
	}

	internal NameCollection(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
	}

	internal Range[] GetNamedRanges(WorksheetCollection worksheetCollection_1)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Name name = (Name)base.InnerList[i];
			if (name.Type != 0)
			{
				Range range = name.CreateRange();
				if (range != null)
				{
					arrayList.Add(range);
				}
			}
		}
		if (arrayList.Count == 0)
		{
			return null;
		}
		Range[] array = new Range[arrayList.Count];
		arrayList.CopyTo(array);
		return array;
	}

	/// <summary>
	///       Defines a new name.
	///       </summary>
	/// <param name="text">The text to use as the name.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Name" /> object index.</returns>
	/// <remarks>Name cannot include spaces and cannot look like cell references.</remarks>
	public int Add(string text)
	{
		int sheetIndex = -1;
		text = method_20(text, out sheetIndex);
		return method_0(sheetIndex, text);
	}

	internal int method_0(int int_0, string string_0)
	{
		int num = method_8(string_0, int_0, bool_0: false);
		if (num != -1)
		{
			return num;
		}
		Name name = new Name(worksheetCollection_0, string_0);
		name.SheetIndex = int_0 + 1;
		return method_3(name, bool_0: true);
	}

	internal int method_1(int int_0, string string_0)
	{
		int num = method_8(string_0, int_0, bool_0: true);
		if (num != -1)
		{
			return num;
		}
		Name name = new Name(worksheetCollection_0, string_0);
		name.SheetIndex = int_0 + 1;
		return method_3(name, bool_0: true);
	}

	[SpecialName]
	private Hashtable method_2()
	{
		if (hashtable_0 == null)
		{
			hashtable_0 = new Hashtable();
			for (int i = 0; i < base.Count; i++)
			{
				Name name = this[i];
				string key = smethod_0(name.SheetIndex - 1, name.Text.ToUpper());
				if (hashtable_0[key] == null)
				{
					hashtable_0.Add(key, i);
				}
			}
		}
		return hashtable_0;
	}

	internal int method_3(Name name_0, bool bool_0)
	{
		int count = base.Count;
		if (bool_0)
		{
			string key = smethod_0(name_0.SheetIndex - 1, name_0.Text);
			method_2()[key] = count;
		}
		base.InnerList.Add(name_0);
		return count;
	}

	internal void method_4(bool bool_0)
	{
		if (bool_0)
		{
			for (int i = 0; i < base.Count; i++)
			{
				Name name = this[i];
				if (name.method_2() == null)
				{
					name.RefersTo = name.RefersTo;
				}
			}
			return;
		}
		for (int j = 0; j < base.Count; j++)
		{
			Name name2 = this[j];
			if (name2.method_2() == null)
			{
				name2.method_19(name2.RefersTo);
			}
		}
	}

	private void Remove(SortedList sortedList_0)
	{
		hashtable_0 = null;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			Cells cells = worksheetCollection_0[i].Cells;
			for (int j = 0; j < cells.Rows.Count; j++)
			{
				Row rowByIndex = cells.Rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.IsFormula)
					{
						if (cellByIndex.method_50() != null)
						{
							Class1674.smethod_16(cellByIndex.method_50().Formula, -1, -1, sortedList_0, worksheetCollection_0);
						}
						else
						{
							Class1674.smethod_16(cellByIndex.method_41(), -1, -1, sortedList_0, worksheetCollection_0);
						}
					}
				}
			}
			Worksheet worksheet = worksheetCollection_0[i];
			if (worksheet.method_36() != null && worksheet.Charts.Count > 0)
			{
				worksheet.Charts.method_5(sortedList_0);
			}
			ConditionalFormattingCollection conditionalFormattings = worksheet.ConditionalFormattings;
			for (int l = 0; l < conditionalFormattings.Count; l++)
			{
				FormatConditionCollection formatConditionCollection = conditionalFormattings[l];
				for (int m = 0; m < formatConditionCollection.Count; m++)
				{
					FormatCondition formatCondition = formatConditionCollection[m];
					formatCondition.method_11();
					if (formatCondition.method_0() != null)
					{
						byte[] array = formatCondition.method_0();
						Class1674.smethod_16(array, -1, array.Length - 1, sortedList_0, worksheetCollection_0);
					}
					if (formatCondition.method_4() != null)
					{
						byte[] array2 = formatCondition.method_4();
						Class1674.smethod_16(array2, -1, array2.Length - 1, sortedList_0, worksheetCollection_0);
					}
				}
			}
			ValidationCollection validations = worksheet.Validations;
			for (int n = 0; n < validations.Count; n++)
			{
				Validation validation = validations[n];
				if (validation.method_7() != null)
				{
					byte[] array3 = validation.method_7();
					Class1674.smethod_16(array3, 0, array3.Length - 1, sortedList_0, worksheetCollection_0);
				}
				if (validation.method_9() != null)
				{
					byte[] array4 = validation.method_9();
					Class1674.smethod_16(array4, 0, array4.Length - 1, sortedList_0, worksheetCollection_0);
				}
			}
		}
		int num = 0;
		int num2 = -1;
		Hashtable hashtable = new Hashtable();
		IEnumerator enumerator = sortedList_0.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			int num3 = (int)enumerator.Current;
			if ((bool)sortedList_0[num3])
			{
				Name name = (Name)base.InnerList[num3];
				name.method_33();
				continue;
			}
			if (num2 != -1 && num2 + 1 != num3)
			{
				for (num2++; num2 < num3; num2++)
				{
					hashtable.Add(num2, num2 - num);
				}
			}
			num2 = num3;
			num++;
		}
		if (num2 == -1)
		{
			return;
		}
		if (num2 < base.Count)
		{
			for (num2++; num2 < base.Count; num2++)
			{
				hashtable.Add(num2, num2 - num);
			}
		}
		num = 0;
		IEnumerator enumerator2 = sortedList_0.Keys.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			int num4 = (int)enumerator2.Current;
			if (!(bool)sortedList_0[num4])
			{
				base.InnerList.RemoveAt(num4 - num);
				num++;
			}
		}
		method_7(hashtable);
	}

	/// <summary>
	///       Remove an array of name
	///       </summary>
	/// <param name="names">The names' text.</param>
	public void Remove(string[] names)
	{
		SortedList sortedList = new SortedList();
		for (int i = 0; i < names.Length; i++)
		{
			string text = names[i];
			int sheetIndex = -1;
			text = method_20(text, out sheetIndex);
			int num = method_8(text, sheetIndex, bool_0: false);
			if (num != -1)
			{
				sortedList.Add(num, false);
			}
		}
		Remove(sortedList);
	}

	/// <summary>
	///       Remove the name.
	///       </summary>
	/// <param name="text">The name text.</param>
	public void Remove(string text)
	{
		int sheetIndex = -1;
		text = method_20(text, out sheetIndex);
		int num = method_8(text, sheetIndex, bool_0: false);
		if (num != -1)
		{
			RemoveAt(num);
		}
	}

	/// <summary>
	///       Remove the name at the specific index.
	///       </summary>
	/// <param name="index">
	/// </param>
	/// <remarks>
	///       Please make sure that the name is not referred by the other formulas before calling the method.
	///       And if the name is referred,please only set Name.RefersTo as null.
	///       </remarks>
	public new void RemoveAt(int index)
	{
		Name name = this[index];
		if (name.IsReferred)
		{
			name.method_33();
			return;
		}
		hashtable_0 = null;
		Hashtable hashtable = new Hashtable();
		for (int i = index + 1; i < base.Count; i++)
		{
			hashtable.Add(i, i - 1);
		}
		base.InnerList.RemoveAt(index);
		method_7(hashtable);
	}

	private bool[] method_5()
	{
		bool[] array = new bool[base.Count];
		Cell cell = null;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			Cells cells = worksheetCollection_0[i].Cells;
			for (int j = 0; j < cells.Rows.Count; j++)
			{
				Row rowByIndex = cells.Rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					cell = rowByIndex.GetCellByIndex(k);
					if (cell.IsFormula)
					{
						if (cell.method_50() != null)
						{
							Class1674.smethod_15(cell.method_50().Formula, -1, -1, array, worksheetCollection_0);
						}
						else
						{
							Class1674.smethod_15(cell.method_41(), -1, -1, array, worksheetCollection_0);
						}
					}
				}
			}
			Worksheet worksheet = worksheetCollection_0[i];
			if (worksheet.method_36() != null && worksheet.Charts.Count > 0)
			{
				worksheet.Charts.method_6(array);
			}
			ConditionalFormattingCollection conditionalFormattings = worksheet.ConditionalFormattings;
			for (int l = 0; l < conditionalFormattings.Count; l++)
			{
				FormatConditionCollection formatConditionCollection = conditionalFormattings[l];
				for (int m = 0; m < formatConditionCollection.Count; m++)
				{
					FormatCondition formatCondition = formatConditionCollection[m];
					formatCondition.method_11();
					if (formatCondition.method_0() != null)
					{
						byte[] array2 = formatCondition.method_0();
						Class1674.smethod_15(array2, -1, array2.Length - 1, array, worksheetCollection_0);
					}
					if (formatCondition.method_4() != null)
					{
						byte[] array3 = formatCondition.method_4();
						Class1674.smethod_15(array3, -1, array3.Length - 1, array, worksheetCollection_0);
					}
				}
			}
			ValidationCollection validations = worksheet.Validations;
			for (int n = 0; n < validations.Count; n++)
			{
				Validation validation = validations[n];
				if (validation.method_7() != null)
				{
					byte[] array4 = validation.method_7();
					Class1674.smethod_15(array4, 0, array4.Length - 1, array, worksheetCollection_0);
				}
				if (validation.method_9() != null)
				{
					byte[] array5 = validation.method_9();
					Class1674.smethod_15(array5, 0, array5.Length - 1, array, worksheetCollection_0);
				}
			}
		}
		return array;
	}

	/// <summary>
	///       Remove all defined names which are not refered by the formulas and data source.
	///       If the defined name is refered, we only set Name.ReferTo as null and hide them.
	///       </summary>
	public new void Clear()
	{
		bool[] array = method_5();
		Hashtable hashtable = new Hashtable();
		hashtable_0 = null;
		int num = 0;
		for (int i = 0; i < base.Count; i++)
		{
			Name name = this[i];
			if (array[num])
			{
				hashtable.Add(num, hashtable.Count);
				name.method_33();
			}
			else
			{
				base.InnerList.RemoveAt(i--);
			}
			num++;
		}
		method_7(hashtable);
	}

	internal void method_6()
	{
		hashtable_0 = null;
		base.InnerList.Clear();
	}

	/// <summary>
	///       Remove the duplicate defined names
	///       </summary>
	public void RemoveDuplicateNames()
	{
		method_16();
		hashtable_0 = null;
		Hashtable hashtable = new Hashtable();
		bool[] array = new bool[base.Count];
		int num = 0;
		for (int i = 0; i < base.Count; i++)
		{
			if (array[i])
			{
				num++;
				continue;
			}
			Name name = this[i];
			hashtable.Add(i, i - num);
			for (int j = i + 1; j < base.Count; j++)
			{
				Name name2 = this[j];
				if (name.SheetIndex == name2.SheetIndex && string.Compare(name.method_16(), name2.method_16(), ignoreCase: true) == 0)
				{
					array[j] = true;
					hashtable.Add(j, i - num);
				}
			}
		}
		for (int k = 0; k < base.Count; k++)
		{
			if (array[k])
			{
				base.InnerList.RemoveAt(k);
			}
		}
		method_7(hashtable);
	}

	/// <summary>
	///       Sorts defined names.
	///       </summary>
	/// <remarks>If you create a large amount of named ranges in the Excel file, please call this method after all named ranges are created and before saving </remarks>
	public void Sort()
	{
		method_16();
		hashtable_0 = null;
		Hashtable hashtable_ = Class1717.Sort(worksheetCollection_0);
		method_7(hashtable_);
	}

	private void method_7(Hashtable hashtable_1)
	{
		if (hashtable_1.Count == 0)
		{
			return;
		}
		for (int i = 0; i < base.Count; i++)
		{
			byte[] array = this[i].method_2();
			if (array != null)
			{
				Class1674.smethod_17(array, -1, array.Length - 1, hashtable_1, worksheetCollection_0);
			}
		}
		for (int j = 0; j < worksheetCollection_0.Count; j++)
		{
			Cells cells = worksheetCollection_0[j].Cells;
			for (int k = 0; k < cells.Rows.Count; k++)
			{
				Row rowByIndex = cells.Rows.GetRowByIndex(k);
				for (int l = 0; l < rowByIndex.method_0(); l++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(l);
					if (cellByIndex.IsFormula)
					{
						cellByIndex.method_71(hashtable_1);
					}
				}
			}
			Worksheet worksheet = worksheetCollection_0[j];
			if (worksheet.method_36() != null)
			{
				worksheet.Shapes.SortNames(hashtable_1);
			}
			ConditionalFormattingCollection conditionalFormattings = worksheetCollection_0[j].ConditionalFormattings;
			for (int m = 0; m < conditionalFormattings.Count; m++)
			{
				FormatConditionCollection formatConditionCollection = conditionalFormattings[m];
				for (int n = 0; n < formatConditionCollection.Count; n++)
				{
					FormatCondition formatCondition = formatConditionCollection[n];
					formatCondition.method_11();
					if (formatCondition.method_0() != null)
					{
						byte[] array2 = formatCondition.method_0();
						Class1674.smethod_17(array2, -1, array2.Length - 1, hashtable_1, worksheetCollection_0);
					}
					if (formatCondition.method_4() != null)
					{
						byte[] array3 = formatCondition.method_4();
						Class1674.smethod_17(array3, -1, array3.Length - 1, hashtable_1, worksheetCollection_0);
					}
				}
			}
			ValidationCollection validations = worksheet.Validations;
			for (int num = 0; num < validations.Count; num++)
			{
				Validation validation = validations[num];
				if (validation.method_7() != null)
				{
					byte[] array4 = validation.method_7();
					Class1674.smethod_17(array4, 0, array4.Length - 1, hashtable_1, worksheetCollection_0);
				}
				if (validation.method_9() != null)
				{
					byte[] array5 = validation.method_9();
					Class1674.smethod_17(array5, 0, array5.Length - 1, hashtable_1, worksheetCollection_0);
				}
			}
		}
	}

	internal int method_8(string string_0, int int_0, bool bool_0)
	{
		string_0 = string_0.ToUpper();
		object obj = method_2()[smethod_0(int_0, string_0)];
		if (obj != null)
		{
			return (int)obj;
		}
		if (bool_0 && int_0 >= 0)
		{
			obj = method_2()[string_0];
			if (obj != null)
			{
				return (int)obj;
			}
		}
		return -1;
	}

	internal int method_9(string string_0, int int_0)
	{
		return method_8(string_0, int_0, bool_0: false);
	}

	internal int[] method_10(int int_0, string string_0, bool bool_0, bool bool_1)
	{
		int num = -1;
		int num2 = string_0.IndexOf("!");
		int num3 = -1;
		int num4 = -1;
		if (num2 != -1)
		{
			string string_ = string_0.Substring(0, num2);
			string_0 = string_0.Substring(num2 + 1);
			string text = string_0.ToUpper();
			int[] array = Class1660.smethod_3(worksheetCollection_0, string_);
			num3 = array[0];
			int num5 = array[1];
			num = array[2];
			if (num5 != worksheetCollection_0.method_36())
			{
				Class1718 @class = worksheetCollection_0.method_39()[num5];
				if (@class.method_0().Count > 0)
				{
					for (int i = 0; i < @class.method_0().Count; i++)
					{
						Class1653 class2 = (Class1653)@class.method_0()[i];
						if (class2.Name.ToUpper() == text)
						{
							num4 = i;
						}
					}
				}
				if (num4 == -1)
				{
					Class1653 class3 = new Class1653(@class);
					class3.Name = string_0;
					num4 = @class.method_0().Add(class3);
				}
				return new int[2] { num3, num4 };
			}
			num4 = ((num == -1) ? method_8(string_0, int_0, bool_0: true) : method_8(string_0, num, bool_0: true));
		}
		else
		{
			num4 = method_8(string_0, int_0, bool_0: true);
		}
		if (num4 == -1)
		{
			if (bool_1)
			{
				Name name = new Name(worksheetCollection_0, string_0);
				name.SheetIndex = num + 1;
				num4 = method_3(name, bool_0: true);
				if (bool_0)
				{
					name.method_1(14);
				}
			}
		}
		else if (num3 != -1)
		{
			Name name2 = this[num4];
			if (name2.SheetIndex == 0)
			{
				num3 = -1;
			}
		}
		return new int[2] { num3, num4 };
	}

	internal void method_11(int int_0, byte byte_0)
	{
		int num = 0;
		Name name;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				name = (Name)base.InnerList[num];
				if (name.SheetIndex == int_0 + 1 && name.Type == Enum184.const_0 && name.method_25() == byte_0)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		name.IsHidden = true;
		name.method_33();
	}

	internal void method_12(int int_0)
	{
		SortedList sortedList = new SortedList();
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Name name = (Name)base.InnerList[i];
			if (name.SheetIndex == int_0 + 1)
			{
				sortedList.Add(i, false);
			}
			else if (name.SheetIndex > int_0 + 1)
			{
				name.method_31();
			}
		}
		Remove(sortedList);
	}

	internal void method_13(int int_0)
	{
		int_0++;
		hashtable_0 = null;
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Name name = (Name)base.InnerList[i];
			if (name.SheetIndex >= int_0)
			{
				name.SheetIndex++;
			}
		}
	}

	internal void method_14(int int_0, int int_1)
	{
		hashtable_0 = null;
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Name name = (Name)base.InnerList[i];
			if (name.SheetIndex == int_0 + 1)
			{
				name.SheetIndex = int_1 + 1;
			}
			else if (name.SheetIndex <= int_0 && name.SheetIndex > int_1)
			{
				name.SheetIndex++;
			}
		}
	}

	internal void Copy(NameCollection nameCollection_0)
	{
		base.InnerList.Clear();
		hashtable_0 = null;
		for (int i = 0; i < nameCollection_0.Count; i++)
		{
			Name name_ = (Name)nameCollection_0.InnerList[i];
			Name name = new Name(worksheetCollection_0);
			name.Copy(name_);
			method_3(name, bool_0: false);
			name_ = null;
			name = null;
		}
	}

	internal void InsertColumns(int int_0, int int_1, int int_2)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Name name = this[i];
			if ((name.SheetIndex == 0 || name.SheetIndex == int_0 + 1) && name.method_2() != null)
			{
				name.InsertColumns(int_0, int_1, int_2);
			}
		}
	}

	internal void InsertRows(int int_0, int int_1, int int_2)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Name name = this[i];
			if ((name.SheetIndex == 0 || name.SheetIndex == int_0 + 1) && name.method_2() != null)
			{
				name.InsertRows(int_0, int_1, int_2);
			}
		}
	}

	internal void method_15(Worksheet worksheet_0, CellArea cellArea_0, int int_0, ShiftType shiftType_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Name name = this[i];
			if ((name.SheetIndex == 0 || name.SheetIndex == worksheet_0.Index + 1) && name.method_2() != null)
			{
				Class1674.smethod_19(cellArea_0, int_0, shiftType_0, worksheet_0, bool_0: false, name.method_2(), -1, -1, 0, 0, 0, 0);
				name.method_18(null);
			}
		}
	}

	internal void method_16()
	{
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			Worksheet worksheet = worksheetCollection_0[i];
			try
			{
				if (worksheet.method_24() > 0)
				{
					int index = method_0(i, "_FILTERDATABASE");
					Name name = this[index];
					name.IsHidden = true;
					name.SheetIndex = i + 1;
					name.method_15("_FILTERDATABASE");
					name.SetRange(i, worksheet.AutoFilter.method_7());
				}
				else
				{
					method_11(worksheet.Index, 13);
				}
			}
			catch
			{
				throw new CellsException(ExceptionType.InvalidData, "error in set autofilter");
			}
			if (worksheet.Cells.PageSetup.method_29())
			{
				method_18(worksheet, i);
				worksheet.Cells.PageSetup.method_30(bool_14: false);
			}
			if (worksheet.Cells.PageSetup.method_2())
			{
				method_17(worksheet, i);
				worksheet.Cells.PageSetup.method_3(bool_14: false);
			}
		}
	}

	private void method_17(Worksheet worksheet_0, int int_0)
	{
		string text = worksheet_0.PageSetup.PrintTitleColumns;
		if (worksheet_0.PageSetup.PrintTitleRows != null && worksheet_0.PageSetup.PrintTitleRows != "")
		{
			text = ((text == null || text == "") ? worksheet_0.PageSetup.PrintTitleRows : (text + "," + worksheet_0.PageSetup.PrintTitleRows));
		}
		if (text != null && text != "")
		{
			try
			{
				int index = method_0(int_0, "PRINT_TITLES");
				Name name = this[index];
				name.method_26(worksheetCollection_0, int_0, text, "PRINT_TITLES");
				return;
			}
			catch
			{
				throw new CellsException(ExceptionType.InvalidData, "error in set print area");
			}
		}
		if (base.Count != 0)
		{
			method_11(int_0, 7);
		}
	}

	private void method_18(Worksheet worksheet_0, int int_0)
	{
		string printArea = worksheet_0.Cells.PageSetup.PrintArea;
		if (printArea != null && printArea != "")
		{
			try
			{
				int index = method_0(int_0, "PRINT_AREA");
				Name name = this[index];
				name.method_26(worksheetCollection_0, int_0, printArea, "PRINT_AREA");
				return;
			}
			catch
			{
				throw new CellsException(ExceptionType.InvalidData, "error in set print area");
			}
		}
		if (base.Count != 0)
		{
			method_11(int_0, 6);
		}
	}

	internal void method_19(Name name_0, string string_0)
	{
		if (hashtable_0 != null)
		{
			string key = smethod_0(name_0.SheetIndex - 1, name_0.Text);
			string key2 = smethod_0(name_0.SheetIndex - 1, string_0);
			if (hashtable_0[key2] != null)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "The defined name[" + string_0 + "] already exists.");
			}
			object obj = hashtable_0[key];
			if (obj != null)
			{
				hashtable_0.Remove(key);
				hashtable_0[key2] = obj;
			}
		}
	}

	private static string smethod_0(int int_0, string string_0)
	{
		string_0 = string_0.ToUpper();
		if (int_0 < 0)
		{
			return string_0;
		}
		return int_0 + "!" + string_0;
	}

	private string method_20(string text, out int sheetIndex)
	{
		sheetIndex = -1;
		int num = text.LastIndexOf('!');
		if (num != -1)
		{
			string text2 = text.Substring(0, num);
			if (text2[0] == '\'')
			{
				text2 = text2.Substring(1, text2.Length - 2);
			}
			text2 = text2.ToUpper();
			for (int i = 0; i < worksheetCollection_0.Count; i++)
			{
				if (worksheetCollection_0[i].Name.ToUpper().Equals(text2))
				{
					sheetIndex = i;
					text = text.Substring(num + 1);
					break;
				}
			}
		}
		return text;
	}
}
