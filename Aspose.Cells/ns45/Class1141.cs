using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using Aspose.Cells.Tables;
using ns12;
using ns16;
using ns2;
using ns22;
using ns28;
using ns29;
using ns57;
using ns59;

namespace ns45;

internal class Class1141
{
	internal Class1142 class1142_0;

	internal PivotTableSourceType pivotTableSourceType_0;

	internal Class1139[] class1139_0;

	internal string[][] string_0;

	internal int[][] int_0;

	internal bool bool_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	internal ushort ushort_0;

	internal int int_4;

	internal Class1144 class1144_0;

	internal int int_5;

	internal ArrayList arrayList_0;

	internal ArrayList arrayList_1;

	internal int int_6;

	internal DateTime dateTime_0;

	internal Worksheet worksheet_0;

	internal int int_7;

	internal Class988 class988_0;

	internal string string_1 = "Aspose";

	internal string string_2 = "3";

	internal int int_8 = 2730;

	internal ArrayList arrayList_2;

	internal Class1140 class1140_0;

	internal int int_9 = -1;

	internal Hashtable hashtable_0;

	internal string string_3;

	internal bool bool_1;

	internal string string_4;

	internal ArrayList arrayList_3;

	internal string string_5;

	internal Class1161 class1161_0;

	internal int Index
	{
		get
		{
			return int_7;
		}
		set
		{
			int_7 = value;
		}
	}

	internal Class1141(Class1142 class1142_1, PivotTableSourceType pivotTableSourceType_1, string[] string_6, PivotPageFields pivotPageFields_0, bool bool_2, int int_10, Worksheet worksheet_1)
	{
		class1142_0 = class1142_1;
		pivotTableSourceType_0 = pivotTableSourceType_1;
		class1139_0 = new Class1139[string_6.Length];
		ushort_0 = 37;
		int_5 = 0;
		int_6 = int_10;
		dateTime_0 = default(DateTime);
		worksheet_0 = worksheet_1;
		bool_0 = bool_2;
		switch (pivotTableSourceType_0)
		{
		default:
			throw new ArgumentException("Unsupported PivotTable source type.");
		case PivotTableSourceType.Consilidation:
			if (!bool_2)
			{
				method_9(pivotPageFields_0);
			}
			method_11(string_6);
			break;
		case PivotTableSourceType.ListDatabase:
			method_8(string_6[0]);
			break;
		}
		class1140_0 = new Class1140();
		class1140_0.method_0(this);
	}

	internal Class1141(Class1142 class1142_1, int int_10, Worksheet worksheet_1)
	{
		class1142_0 = class1142_1;
		int_6 = int_10;
		worksheet_0 = worksheet_1;
		dateTime_0 = default(DateTime);
		class1140_0 = new Class1140();
		class1140_0.method_0(this);
	}

	internal Class1141(Class1142 class1142_1)
	{
		class1142_0 = class1142_1;
		dateTime_0 = default(DateTime);
		class1140_0 = new Class1140();
	}

	internal void Copy(Class1141 class1141_0)
	{
		if (class1141_0.arrayList_2 != null)
		{
			arrayList_2 = new ArrayList();
			for (int i = 0; i < class1141_0.arrayList_2.Count; i++)
			{
				arrayList_2.Add(class1141_0.arrayList_2[i]);
			}
			if (class1142_0.worksheetCollection_0.method_10() == null)
			{
				class1142_0.worksheetCollection_0.method_11(new Class1317(WorksheetCollection.guid_0));
			}
			Class1319 @class = class1142_0.worksheetCollection_0.method_10().method_9().method_0("_SX_DB_CUR");
			if (@class == null)
			{
				@class = new Class1319(new Guid("00000000-0000-0000-0000-000000000000"));
				class1142_0.worksheetCollection_0.method_10().method_9().Add("_SX_DB_CUR", @class);
			}
			string text = Class1025.smethod_6(int_6);
			MemoryStream stream = class1141_0.class1142_0.worksheetCollection_0.method_10().method_9().method_0("_SX_DB_CUR")
				.GetStream(Class1025.smethod_6(class1141_0.int_6));
			if (stream != null)
			{
				@class.Add(text, stream);
			}
			return;
		}
		pivotTableSourceType_0 = class1141_0.pivotTableSourceType_0;
		if (class1141_0.class1139_0 != null)
		{
			class1139_0 = new Class1139[class1141_0.class1139_0.Length];
		}
		ushort_0 = class1141_0.ushort_0;
		int_5 = 0;
		dateTime_0 = class1141_0.dateTime_0;
		bool_0 = class1141_0.bool_0;
		if (class1141_0.bool_1)
		{
			if (class1142_0.worksheetCollection_0.Workbook.class1558_0 == null)
			{
				class1142_0.worksheetCollection_0.Workbook.class1558_0 = new Class1558(class1142_0.worksheetCollection_0.Workbook);
				class1142_0.worksheetCollection_0.Workbook.class1558_0.class1553_0 = new Class1553();
			}
			class1142_0.worksheetCollection_0.Workbook.class1558_0.class1553_0.memoryStream_0 = class1141_0.class1142_0.worksheetCollection_0.Workbook.class1558_0.class1553_0.memoryStream_0;
			class1142_0.worksheetCollection_0.Workbook.class1558_0.class1553_0.class746_0 = class1141_0.class1142_0.worksheetCollection_0.Workbook.class1558_0.class1553_0.class746_0;
			class1142_0.worksheetCollection_0.Workbook.class1558_0.class1364_0.arrayList_1 = class1141_0.class1142_0.worksheetCollection_0.Workbook.class1558_0.class1364_0.arrayList_1;
			int_6 = class1141_0.int_6;
			bool_1 = true;
			return;
		}
		switch (pivotTableSourceType_0)
		{
		default:
			throw new ArgumentException("Unsupported PivotTable source type.");
		case PivotTableSourceType.Consilidation:
			string_0 = class1141_0.string_0;
			int_0 = class1141_0.int_0;
			bool_0 = class1141_0.bool_0;
			method_11(class1141_0.method_22());
			break;
		case PivotTableSourceType.ListDatabase:
			if (class1141_0.class1139_0 != null)
			{
				for (int j = 0; j < class1141_0.class1139_0.Length; j++)
				{
					method_7(class1141_0.class1139_0[j].GetSource());
				}
			}
			break;
		}
		arrayList_0 = new ArrayList(class1141_0.arrayList_0.Count);
		for (int k = 0; k < class1141_0.arrayList_0.Count; k++)
		{
			arrayList_0.Add(class1141_0.arrayList_0[k]);
		}
		class1144_0 = new Class1144(this);
		class1144_0 = class1141_0.class1144_0;
	}

	internal int method_0(string string_6)
	{
		ArrayList arrayList = arrayList_0;
		string text = string_6.ToUpper();
		if (text != null && text[0] == '\'')
		{
			text = text.Substring(1, text.Length - 2);
		}
		class1161_0 = (Class1161)arrayList_0[arrayList_0.Count - 1];
		ArrayList arrayList2 = class1161_0.arrayList_1;
		int num = -1;
		for (int i = 0; i < arrayList2.Count; i++)
		{
			Class1166 @class = (Class1166)arrayList2[i];
			if (((Class1161)arrayList[@class.ushort_1]).string_0.ToUpper().Equals(text))
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			for (int j = 0; j < arrayList.Count; j++)
			{
				if (((Class1161)arrayList[j]).string_0.ToUpper().Equals(text))
				{
					num = arrayList2.Count;
					arrayList2.Add(new Class1166(j));
					break;
				}
			}
		}
		return num;
	}

	internal void AddCalculatedField(string string_6, string string_7)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				Class1161 @class = (Class1161)arrayList_0[num];
				if (@class.string_0 != null && @class.string_0 == string_6)
				{
					break;
				}
				num++;
				continue;
			}
			Class1161 class2 = new Class1161(this, string_6, string_7);
			arrayList_0.Add(class2);
			int_2++;
			WorksheetCollection worksheetCollection_ = class1142_0.worksheetCollection_0;
			worksheetCollection_.method_3(this);
			class2.byte_0 = worksheetCollection_.Formula.method_3(string_7, 0, 0, Enum226.const_0, Enum227.const_1, bool_0: false, bool_1: false);
			worksheetCollection_.method_3(null);
			foreach (Worksheet item in class1142_0.worksheetCollection_0)
			{
				if (item.pivotTableCollection_0 == null || item.pivotTableCollection_0.Count == 0)
				{
					continue;
				}
				for (int i = 0; i < item.pivotTableCollection_0.Count; i++)
				{
					if (item.pivotTableCollection_0[i].class1141_0 != this)
					{
						continue;
					}
					item.pivotTableCollection_0[i].BaseFields.method_0(class2);
					for (int j = 0; j < arrayList_0.Count; j++)
					{
						Class1161 class3 = (Class1161)arrayList_0[j];
						if (class3.method_18() && class3 != class2 && item.pivotTableCollection_0[i].BaseFields.method_8(class3.string_0) == null)
						{
							item.pivotTableCollection_0[i].BaseFields.method_0(class3);
						}
					}
				}
			}
			return;
		}
		throw new CellsException(ExceptionType.Limitation, "Invalid calculated field name,it could not be same as the previous field name.");
	}

	internal void method_1(int int_10)
	{
		Class1161 @class = (Class1161)arrayList_0[int_10];
		for (int i = 0; i < @class.arrayList_0.Count; i++)
		{
			Class1158 class2 = (Class1158)@class.arrayList_0[i];
			if (class2.object_0 is double)
			{
				@class.method_11(bool_2: true);
			}
			else if (!(class2.object_0 is int) && !(class2.object_0 is decimal))
			{
				if (class2.object_0 is string)
				{
					@class.method_13(bool_2: true);
				}
				else if (class2.object_0 == null)
				{
					@class.method_30(bool_2: true);
				}
			}
			else
			{
				@class.method_9(bool_2: true);
			}
		}
	}

	internal Class1139 method_2(string string_6)
	{
		Class1139 @class = new Class1139(this, worksheet_0, string_6);
		object[] array = smethod_4(class1142_0.worksheetCollection_0, string_6);
		object obj = array[0];
		Worksheet worksheet = (Worksheet)array[1];
		if (worksheet == null && worksheet_0 != null)
		{
			worksheet = worksheet_0;
		}
		if (obj is Name)
		{
			@class.range_0 = ((Name)obj).CreateRange();
			if (@class.range_0 == null)
			{
				throw new ArgumentException("Invalid pivot table data source");
			}
			worksheet = @class.range_0.Worksheet;
			@class.range_0.method_0(((Name)obj).method_16());
		}
		else if (obj is ListObject)
		{
			ListObject listObject = (ListObject)obj;
			CellArea cellArea = default(CellArea);
			if (array.Length > 2)
			{
				cellArea.StartRow = listObject.StartRow;
				cellArea.EndRow = listObject.EndRow;
				cellArea.StartColumn = (int)array[2];
				cellArea.EndColumn = (int)array[3];
			}
			else
			{
				cellArea.StartRow = listObject.StartRow;
				cellArea.EndRow = listObject.EndRow;
				cellArea.StartColumn = listObject.StartColumn;
				cellArea.EndColumn = listObject.EndColumn;
			}
			@class.range_0 = worksheet.Cells.CreateRange(cellArea.StartRow, cellArea.StartColumn, cellArea.EndRow - cellArea.StartRow + 1, cellArea.EndColumn - cellArea.StartColumn + 1);
			if (@class.range_0 == null)
			{
				throw new ArgumentException("Invalid table data source");
			}
			worksheet = @class.range_0.Worksheet;
			if (array.Length <= 2)
			{
				@class.range_0.method_0(((ListObject)obj).Name);
			}
			else
			{
				@class.range_0.method_0(string_6);
			}
		}
		else
		{
			if (worksheet == null)
			{
				throw new ArgumentException("Invalid pivot table data source");
			}
			CellArea cellArea2 = (CellArea)obj;
			@class.range_0 = worksheet.Cells.CreateRange(cellArea2.StartRow, cellArea2.StartColumn, cellArea2.EndRow - cellArea2.StartRow + 1, cellArea2.EndColumn - cellArea2.StartColumn + 1);
		}
		@class.worksheet_0 = worksheet;
		return @class;
	}

	internal void method_3(int int_10, int int_11, Worksheet worksheet_1)
	{
		if (class1139_0 == null)
		{
			return;
		}
		for (int i = 0; i < class1139_0.Length; i++)
		{
			Class1139 @class = class1139_0[i];
			Range range_ = @class.range_0;
			CellArea area = range_.Area;
			for (int j = 0; j < worksheet_1.method_2().Names.Count; j++)
			{
				Name name = worksheet_1.method_2().Names[j];
				if (range_.Name == name.Text)
				{
					@class.range_0 = name.CreateRange();
					return;
				}
			}
			if (worksheet_1 == @class.worksheet_0 && int_10 == area.EndRow)
			{
				string name2 = @class.range_0.Name;
				@class.range_0 = new Range(area.StartRow, area.StartColumn, area.EndRow + int_11 - area.StartRow + 1, area.EndColumn - area.StartColumn + 1, worksheet_1.Cells);
				@class.range_0.method_0(name2);
			}
		}
	}

	internal void InsertRows(int int_10, int int_11, Worksheet worksheet_1)
	{
		if (class1139_0 == null)
		{
			return;
		}
		for (int i = 0; i < class1139_0.Length; i++)
		{
			Class1139 @class = class1139_0[i];
			Range range_ = @class.range_0;
			CellArea area = range_.Area;
			if (worksheet_1.ListObjects != null && worksheet_1.ListObjects.Count > 0)
			{
				break;
			}
			for (int j = 0; j < worksheet_1.method_2().Names.Count; j++)
			{
				Name name = worksheet_1.method_2().Names[j];
				if (range_.Name == name.Text)
				{
					@class.range_0 = name.CreateRange();
					return;
				}
			}
			if (worksheet_1 == @class.worksheet_0)
			{
				bool flag = false;
				CellArea cellArea = Class1678.InsertRows(area, int_10, int_11, ref flag);
				@class.range_0 = new Range(cellArea.StartRow, cellArea.StartColumn, cellArea.EndRow - cellArea.StartRow + 1, cellArea.EndColumn - cellArea.StartColumn + 1, worksheet_1.Cells);
			}
		}
	}

	internal string method_4(int int_10)
	{
		if (class1161_0 == null)
		{
			return "";
		}
		ArrayList arrayList = class1161_0.arrayList_1;
		Class1166 @class = (Class1166)arrayList[int_10];
		Class1161 class2 = (Class1161)arrayList_0[@class.ushort_1];
		string text = class2.string_0;
		string text2 = "";
		text2 = ((text != null) ? text : "(Blank)");
		if (Class1660.smethod_6(text2))
		{
			text2 = '\'' + text2 + '\'';
		}
		return text2;
	}

	internal void method_5(ArrayList arrayList_4)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1161 @class = (Class1161)arrayList_0[i];
			if (@class.string_1 != null || @class.method_18() || (@class.arrayList_0 != null && @class.arrayList_0.Count == 0 && @class.sxRng_0 != null))
			{
				arrayList_4.Add(@class);
			}
		}
	}

	internal ArrayList method_6(Class1161 class1161_1)
	{
		ArrayList arrayList = new ArrayList();
		if (class1161_1.arrayList_0 != null)
		{
			for (int i = 0; i < class1161_1.arrayList_0.Count; i++)
			{
				Class1158 @class = (Class1158)class1161_1.arrayList_0[i];
				if (@class != null && @class.bool_0)
				{
					arrayList.Add(@class);
				}
			}
		}
		return arrayList;
	}

	internal void method_7(string string_6)
	{
		Class1139 @class = method_2(string_6);
		class1139_0[0] = @class;
		ArrayList arrayList = new ArrayList();
		if (arrayList_0 != null)
		{
			method_5(arrayList);
		}
		Range range_ = @class.range_0;
		_ = @class.worksheet_0.Cells;
		_ = range_.FirstRow;
		_ = range_.FirstColumn;
		int_2 = range_.ColumnCount + arrayList.Count;
		int_1 = range_.ColumnCount;
		int_3 = range_.RowCount - 1;
		arrayList_1 = arrayList_0;
		arrayList_0 = new ArrayList(int_1);
	}

	internal void method_8(string string_6)
	{
		Class1139 @class = method_2(string_6);
		class1139_0[0] = @class;
		ArrayList arrayList = new ArrayList();
		if (arrayList_0 != null)
		{
			method_5(arrayList);
		}
		Range range_ = @class.range_0;
		Cells cells = @class.worksheet_0.Cells;
		int firstRow = range_.FirstRow;
		int firstColumn = range_.FirstColumn;
		int_2 = range_.ColumnCount + arrayList.Count;
		int_1 = range_.ColumnCount;
		int_3 = range_.RowCount - 1;
		arrayList_1 = arrayList_0;
		arrayList_0 = new ArrayList(int_1);
		int maxRow = cells.MaxRow;
		int num = Math.Min(maxRow, int_3);
		if (int_3 > num)
		{
			class1144_0 = new Class1144(this, num + 1, int_1);
		}
		else
		{
			class1144_0 = new Class1144(this, int_3, int_1);
		}
		Cell cell = null;
		int num2 = -1;
		bool isString = false;
		Hashtable hashtable = new Hashtable();
		int num3 = 2;
		for (int i = 0; i < range_.ColumnCount; i++)
		{
			cell = cells.GetCell(firstRow, i + firstColumn, bool_2: false);
			if (!hashtable.Contains(cell.StringValue))
			{
				hashtable.Add(cell.StringValue, i);
				arrayList_0.Add(new Class1161(this, cell.StringValue, bool_2: true));
			}
			else
			{
				string key = cell.StringValue + num3++;
				hashtable.Add(key, i);
				arrayList_0.Add(new Class1161(this, key, bool_2: true));
			}
			Class1161 class2 = (Class1161)arrayList_0[i];
			num2 = -1;
			Hashtable hashtable2 = new Hashtable();
			ArrayList arrayList2 = new ArrayList();
			int num4 = 0;
			class1144_0.bool_0[i] = true;
			for (int j = 1; j <= num; j++)
			{
				cell = cells.CheckCell(j + firstRow, i + firstColumn);
				if (cell == null)
				{
					if (num2 == -1)
					{
						num2 = num4++;
						Class1158 class3 = new Class1158();
						class3.object_0 = null;
						arrayList2.Add(class3);
						class2.method_30(bool_2: true);
					}
					((object[])class1144_0.arrayList_0[j - 1])[i] = num2;
					continue;
				}
				if (cell.Type == CellValueType.IsNull)
				{
					if (num2 == -1)
					{
						num2 = num4++;
						Class1158 class4 = new Class1158();
						class4.object_0 = null;
						arrayList2.Add(class4);
						class2.method_30(bool_2: true);
					}
					((object[])class1144_0.arrayList_0[j - 1])[i] = num2;
					continue;
				}
				object obj = smethod_0(cell.Value, class2, out isString);
				if (obj == null)
				{
					if (num2 == -1)
					{
						Class1158 class5 = new Class1158();
						class5.object_0 = null;
						arrayList2.Add(class5);
						num2 = num4++;
						class2.method_30(bool_2: true);
					}
					((object[])class1144_0.arrayList_0[j - 1])[i] = num2;
					continue;
				}
				object obj2 = (isString ? hashtable2[((string)obj).ToUpper()] : hashtable2[obj]);
				if (obj2 == null)
				{
					((object[])class1144_0.arrayList_0[j - 1])[i] = num4;
					if (isString)
					{
						hashtable2.Add(((string)obj).ToUpper(), num4++);
					}
					else
					{
						hashtable2.Add(obj, num4++);
					}
					Class1158 class6 = new Class1158();
					class6.object_0 = obj;
					arrayList2.Add(class6);
				}
				else
				{
					((object[])class1144_0.arrayList_0[j - 1])[i] = (int)obj2;
				}
			}
			if (int_3 > num && !class2.method_29())
			{
				Class1158 class7 = new Class1158();
				class7.object_0 = null;
				arrayList2.Add(class7);
				class2.method_30(bool_2: true);
				((object[])class1144_0.arrayList_0[num])[i] = arrayList2.Count - 1;
			}
			if (arrayList_1 != null && i < arrayList_1.Count)
			{
				arrayList2.AddRange(method_6((Class1161)arrayList_1[i]));
			}
			class2.arrayList_0 = arrayList2;
			if (arrayList_1 != null && i < arrayList_1.Count)
			{
				class2.sxRng_0 = ((Class1161)arrayList_1[i]).sxRng_0;
			}
			if (class2.sxRng_0 != null)
			{
				class2.method_21(bool_2: true);
			}
		}
		for (int k = 0; k < arrayList.Count; k++)
		{
			arrayList_0.Add(arrayList[k]);
		}
	}

	private void method_9(PivotPageFields pivotPageFields_0)
	{
		if (pivotPageFields_0 == null || pivotPageFields_0.method_0() == null || pivotPageFields_0.method_1() == null)
		{
			return;
		}
		int num = class1139_0.Length;
		string_0 = new string[pivotPageFields_0.method_0().Count][];
		for (int i = 0; i < pivotPageFields_0.method_0().Count; i++)
		{
			string[] array = (string[])pivotPageFields_0.method_0()[i];
			int num2 = array.Length;
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j] == null)
				{
					num2--;
				}
			}
			string_0[i] = new string[num2];
			int num3 = 0;
			for (int k = 0; k < array.Length; k++)
			{
				if (array[k] != null)
				{
					string_0[i][num3++] = array[k];
				}
			}
		}
		if (pivotPageFields_0.method_1().Count != num)
		{
			throw new ArgumentException("The number of pageItemIndex must equal to the number of data sources.");
		}
		int_0 = new int[num][];
		int num4 = 0;
		while (true)
		{
			if (num4 >= pivotPageFields_0.method_1().Count)
			{
				return;
			}
			int[] array2 = (int[])pivotPageFields_0.method_1()[num4];
			if (array2.Length != pivotPageFields_0.method_0().Count)
			{
				break;
			}
			int_0[num4] = new int[pivotPageFields_0.method_0().Count];
			int num5 = 0;
			for (int l = 0; l < array2.Length; l++)
			{
				num5 = array2[l];
				if (num5 != -1 && num5 >= string_0[l].Length)
				{
					num5 = -1;
				}
				int_0[num4][l] = num5;
			}
			num4++;
		}
		throw new ArgumentException("");
	}

	private void method_10(int int_10, Class1161 class1161_1)
	{
		bool flag = true;
		Hashtable hashtable = new Hashtable();
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int[] array = new int[int_0.Length];
		for (int i = 0; i < int_0.Length; i++)
		{
			array[i] = int_0[i][int_10];
		}
		int num2 = 0;
		bool flag2 = false;
		for (int j = 0; j < array.Length; j++)
		{
			flag2 = false;
			for (int num3 = array.Length - 2; num3 >= j; num3--)
			{
				if (array[num3 + 1] < array[num3])
				{
					num2 = array[num3 + 1];
					array[num3 + 1] = array[num3];
					array[num3] = num2;
					flag2 = true;
				}
			}
			if (!flag2)
			{
				break;
			}
		}
		for (int k = 0; k < array.Length; k++)
		{
			int num4 = array[k];
			if (num4 == -1)
			{
				if (flag)
				{
					flag = false;
				}
				continue;
			}
			int l;
			for (l = 0; l < k && num4 != array[l]; l++)
			{
			}
			if (l == k)
			{
				hashtable.Add(string_0[int_10][num4], num++);
				Class1158 @class = new Class1158();
				@class.object_0 = string_0[int_10][num4];
				arrayList.Add(@class);
			}
		}
		if (!flag)
		{
			Class1158 class2 = new Class1158();
			class2.object_0 = null;
			arrayList.Add(class2);
		}
		class1161_1.arrayList_0 = arrayList;
		class1161_1.method_13(bool_2: true);
	}

	internal static object smethod_0(object obj, Class1161 sxFDB, out bool isString)
	{
		isString = false;
		if (obj == null)
		{
			return null;
		}
		switch (Type.GetTypeCode(obj.GetType()))
		{
		case TypeCode.Double:
		{
			string s = ((double)obj).ToString(CultureInfo.InvariantCulture);
			double num = double.Parse(s, CultureInfo.InvariantCulture);
			if ((num <= 2147483647.0 && num == (double)(int)num) || Math.Ceiling(num) == num)
			{
				if (!sxFDB.method_6())
				{
					sxFDB.method_9(bool_2: true);
				}
				if (num <= 2147483647.0)
				{
					return (int)num;
				}
				return num;
			}
			if (!sxFDB.method_10())
			{
				sxFDB.method_11(bool_2: true);
			}
			return num;
		}
		case TypeCode.DateTime:
		{
			DateTime dateTime = (DateTime)obj;
			if (dateTime.Millisecond != 0)
			{
				dateTime = ((dateTime.Millisecond <= 500) ? dateTime.AddMilliseconds(-dateTime.Millisecond) : dateTime.AddMilliseconds(1000 - dateTime.Millisecond));
			}
			if (!sxFDB.method_14())
			{
				sxFDB.method_15(bool_2: true);
			}
			return dateTime;
		}
		case TypeCode.String:
		{
			isString = true;
			string text = (string)obj;
			if (text.Length > 255)
			{
				text = text.Substring(0, 255);
			}
			if (!sxFDB.method_12())
			{
				sxFDB.method_13(bool_2: true);
			}
			return text;
		}
		case TypeCode.Int32:
			if (!sxFDB.method_6())
			{
				sxFDB.method_9(bool_2: true);
			}
			break;
		case TypeCode.Boolean:
			if (!sxFDB.method_12())
			{
				sxFDB.method_13(bool_2: true);
			}
			break;
		}
		return obj;
	}

	internal void method_11(string[] string_6)
	{
		if (bool_0)
		{
			int num = string_6.Length;
			string[] array = new string[num];
			int_0 = new int[num][];
			for (int i = 0; i < num; i++)
			{
				array[i] = "item" + (i + 1);
				int_0[i] = new int[1] { i };
			}
			string_0 = new string[1][];
			string_0[0] = array;
		}
		int num2 = ((string_0 != null) ? string_0.Length : 0);
		int_2 = (int_1 = 3 + num2);
		arrayList_0 = new ArrayList(int_1);
		Class1161 @class = new Class1161(this, "Row", bool_2: true);
		arrayList_0.Add(@class);
		Class1161 class2 = new Class1161(this, "Column", bool_2: true);
		arrayList_0.Add(class2);
		Class1161 value = new Class1161(this, "Value", bool_2: false);
		arrayList_0.Add(value);
		if (string_0 != null)
		{
			for (int j = 0; j < string_0.Length; j++)
			{
				arrayList_0.Add(new Class1161(this, "Page" + (j + 1), bool_2: true));
				method_10(j, (Class1161)arrayList_0[3 + j]);
			}
		}
		for (int k = 0; k < string_6.Length; k++)
		{
			class1139_0[k] = method_2(string_6[k]);
			Range range_ = class1139_0[k].range_0;
			int_3 += (range_.RowCount - 1) * (range_.ColumnCount - 1);
		}
		class1144_0 = new Class1144(this, int_3, int_1);
		Hashtable hashtable = new Hashtable();
		ArrayList arrayList = (@class.arrayList_0 = new ArrayList());
		int num3 = 0;
		Hashtable hashtable2 = new Hashtable();
		ArrayList arrayList2 = (class2.arrayList_0 = new ArrayList());
		int num4 = 0;
		int num5 = 0;
		Cell cell = null;
		int num6 = 0;
		int num7 = -1;
		int num8 = -1;
		bool isString = false;
		for (int l = 0; l < class1139_0.Length; l++)
		{
			Cells cells = class1139_0[l].worksheet_0.Cells;
			Range range_2 = class1139_0[l].range_0;
			int firstRow = range_2.FirstRow;
			int num9 = range_2.RowCount - 1;
			int firstColumn = range_2.FirstColumn;
			int num10 = range_2.ColumnCount - 1;
			ushort[] array2 = null;
			if (int_0 != null)
			{
				array2 = new ushort[int_0[l].Length];
				for (int m = 0; m < array2.Length; m++)
				{
					if (int_0[l][m] == -1)
					{
						array2[m] = (ushort)(((Class1161)arrayList_0[3 + l]).arrayList_0.Count - 1);
					}
					else
					{
						array2[m] = (ushort)int_0[l][m];
					}
				}
			}
			int[] array3 = new int[num10];
			for (int n = 1; n <= num10; n++)
			{
				cell = cells.GetCell(firstRow, firstColumn + n, bool_2: false);
				if (cell.Type == CellValueType.IsNull)
				{
					if (num7 == -1)
					{
						Class1158 class3 = new Class1158();
						class3.object_0 = null;
						arrayList2.Add(class3);
						num7 = num4++;
					}
					array3[n - 1] = num7;
					continue;
				}
				object obj = smethod_0(cell.Value, class2, out isString);
				if (obj == null)
				{
					if (num7 == -1)
					{
						Class1158 class4 = new Class1158();
						class4.object_0 = null;
						arrayList2.Add(class4);
						num7 = num4++;
					}
					array3[n - 1] = num7;
					continue;
				}
				object obj2 = hashtable2[obj];
				if (obj2 == null)
				{
					num6 = num4;
					hashtable2.Add(obj, num4++);
					Class1158 class5 = new Class1158();
					class5.object_0 = obj;
					arrayList2.Add(class5);
				}
				else
				{
					num6 = (int)obj2;
				}
				array3[n - 1] = num6;
			}
			for (int num11 = 1; num11 <= num9; num11++)
			{
				cell = cells.GetCell(num11 + firstRow, firstColumn, bool_2: false);
				if (cell.Type == CellValueType.IsNull)
				{
					if (num8 == -1)
					{
						Class1158 class6 = new Class1158();
						class6.object_0 = null;
						arrayList.Add(class6);
						num8 = num3++;
					}
					num6 = num8;
				}
				else
				{
					object obj3 = smethod_0(cell.Value, @class, out isString);
					if (obj3 == null)
					{
						if (num8 == -1)
						{
							num8 = num3++;
							Class1158 class7 = new Class1158();
							class7.object_0 = null;
							arrayList.Add(class7);
						}
						num6 = num8;
					}
					else
					{
						object obj4 = hashtable[obj3];
						if (obj4 == null)
						{
							num6 = num3;
							hashtable.Add(obj3, num3++);
							Class1158 class8 = new Class1158();
							class8.object_0 = obj3;
							arrayList.Add(class8);
						}
						else
						{
							num6 = (int)obj4;
						}
					}
				}
				for (int num12 = 0; num12 < num10; num12++)
				{
					object[] array4 = (object[])class1144_0.arrayList_0[num5];
					array4[0] = num6;
					array4[1] = array3[num12];
					cell = cells.CheckCell(num11 + firstRow, firstColumn + num12 + 1);
					if (cell == null)
					{
						array4[2] = null;
					}
					else
					{
						array4[2] = cell.Value;
					}
					for (int num13 = 0; num13 < array2.Length; num13++)
					{
						array4[3 + num13] = (int)array2[num13];
					}
					num5++;
				}
			}
		}
	}

	[SpecialName]
	internal bool method_12()
	{
		return method_15(4);
	}

	[SpecialName]
	internal void method_13(bool bool_2)
	{
		method_14(bool_2, 4);
	}

	internal void method_14(bool bool_2, int int_10)
	{
		ushort_0 &= (ushort)(~int_10);
		ushort_0 |= (ushort)(bool_2 ? ((ushort)int_10) : 0);
	}

	internal bool method_15(int int_10)
	{
		return (ushort_0 & int_10) != 0;
	}

	[SpecialName]
	internal int method_16()
	{
		int num = 12;
		switch (pivotTableSourceType_0)
		{
		default:
			throw new ArgumentException("Unsupported PivotTable source type.");
		case PivotTableSourceType.Consilidation:
			return num + method_20();
		case PivotTableSourceType.ListDatabase:
			if (class1139_0 == null)
			{
				return -1;
			}
			return num + class1139_0[0].method_0();
		}
	}

	internal void method_17(Class1725 class1725_0)
	{
		if (arrayList_2 != null)
		{
			for (int i = 0; i < arrayList_2.Count; i++)
			{
				class1725_0.method_3((byte[])arrayList_2[i]);
			}
			return;
		}
		byte[] array = method_18();
		if (array != null)
		{
			class1725_0.method_3(array);
		}
		if (class1140_0.Count > 0)
		{
			for (int j = 0; j < class1140_0.Count; j++)
			{
				Class1157.smethod_0(class1725_0, class1140_0[j]);
			}
		}
		else
		{
			Class1157.smethod_4(class1725_0, this);
		}
	}

	internal byte[] method_18()
	{
		if (method_16() < 0)
		{
			return null;
		}
		byte[] array = new byte[method_16()];
		int num = 0;
		num = 0 + smethod_2(array, 0, int_6);
		num += smethod_3(array, num, pivotTableSourceType_0);
		switch (pivotTableSourceType_0)
		{
		default:
			throw new ArgumentException("Unsupported PivotTable source type.");
		case PivotTableSourceType.Consilidation:
			num += method_23(array, num);
			break;
		case PivotTableSourceType.ListDatabase:
			num += class1139_0[0].method_1(array, num);
			break;
		}
		return array;
	}

	internal void method_19(MemoryStream memoryStream_0)
	{
		Class1725 @class = new Class1725(memoryStream_0);
		if (arrayList_3 != null)
		{
			foreach (byte[] item in arrayList_3)
			{
				@class.method_3(item);
			}
			return;
		}
		Class557 class2 = new Class557(this);
		class2.vmethod_0(@class);
		Class556 class3 = new Class556(this);
		class3.vmethod_0(@class);
		if (class988_0 != null)
		{
			foreach (Class1148 item2 in class988_0)
			{
				Class563 class5 = new Class563(item2);
				class5.vmethod_0(@class);
				if (item2.class1169_0 != null)
				{
					for (int i = 0; i < item2.class1169_0.Count; i++)
					{
						Class1166 class6 = item2.class1169_0[i];
						Class568 class7 = new Class568(class6);
						class7.vmethod_0(@class);
						for (int j = 0; j < class6.method_1().Count; j++)
						{
							Class1167 class1167_ = class6.method_1()[j];
							Class569 class8 = new Class569(class1167_);
							class8.vmethod_0(@class);
						}
					}
				}
				Class572 class9 = new Class572(item2.class1171_0);
				class9.vmethod_0(@class);
				if (item2.class1171_0.arrayList_0 != null)
				{
					for (int k = 0; k < item2.class1171_0.arrayList_0.Count; k++)
					{
						Class1162 class10 = (Class1162)item2.class1171_0.arrayList_0[k];
						Class562 class11 = new Class562(class10);
						class11.vmethod_0(@class);
						byte[] array = new byte[6] { 245, 0, 2, 0, 0, 0 };
						for (int l = 0; l < class10.arrayList_0.Count; l++)
						{
							Array.Copy(BitConverter.GetBytes((ushort)(int)class10.arrayList_0[l]), 0, array, 4, 2);
							@class.method_3(array);
						}
					}
				}
				Class564 class12 = new Class564(item2);
				class12.vmethod_0(@class);
			}
		}
		if (arrayList_0 != null)
		{
			for (int m = 0; m < arrayList_0.Count; m++)
			{
				Class1161 class13 = (Class1161)arrayList_0[m];
				class13.Write(@class);
			}
		}
		if (class1144_0 != null)
		{
			class1144_0.Write(@class);
		}
		@class.method_5(10);
	}

	[SpecialName]
	internal int method_20()
	{
		int num = 10;
		for (int i = 0; i < class1139_0.Length; i++)
		{
			num += class1139_0[i].method_0();
		}
		if (int_0 == null)
		{
			num += 4 * class1139_0.Length;
		}
		else
		{
			for (int j = 0; j < int_0.Length; j++)
			{
				num += 4 + 2 * int_0[j].Length;
			}
		}
		if (string_0 != null)
		{
			for (int k = 0; k < string_0.Length; k++)
			{
				int num2 = string_0[k].Length;
				num += 6;
				for (int l = 0; l < num2; l++)
				{
					num += 6 + Class1677.smethod_29(string_0[k][l]);
				}
			}
		}
		return num;
	}

	[SpecialName]
	internal int method_21()
	{
		int num = 0;
		if (class1139_0 == null)
		{
			return 0;
		}
		Class1139[] array = class1139_0;
		foreach (Class1139 @class in array)
		{
			if (@class.range_0 != null)
			{
				num += @class.range_0.RowCount - 1;
			}
		}
		return num;
	}

	internal string[] method_22()
	{
		if (class1139_0 == null)
		{
			return null;
		}
		string[] array = new string[class1139_0.Length];
		for (int i = 0; i < class1139_0.Length; i++)
		{
			array[i] = class1139_0[i].GetSource();
		}
		return array;
	}

	internal int method_23(byte[] byte_0, int int_10)
	{
		int num = int_10;
		int_10 += method_24(byte_0, int_10);
		for (int i = 0; i < class1139_0.Length; i++)
		{
			int_10 += class1139_0[i].method_1(byte_0, int_10);
		}
		int_10 += method_25(byte_0, int_10);
		if (string_0 != null)
		{
			int_10 += method_26(byte_0, int_10);
		}
		return int_10 - num;
	}

	internal int method_24(byte[] byte_0, int int_10)
	{
		short value = (short)(string_0.Length | (bool_0 ? 32768 : 0));
		byte_0[int_10++] = 208;
		byte_0[int_10++] = 0;
		byte_0[int_10++] = 6;
		byte_0[int_10++] = 0;
		Array.Copy(BitConverter.GetBytes((short)class1139_0.Length), 0, byte_0, int_10, 2);
		Array.Copy(BitConverter.GetBytes((short)int_0.Length), 0, byte_0, int_10 + 2, 2);
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, int_10 + 4, 2);
		return 10;
	}

	internal int method_25(byte[] byte_0, int int_10)
	{
		int num = int_10;
		if (int_0 == null)
		{
			for (int i = 0; i < class1139_0.Length; i++)
			{
				byte_0[int_10++] = 210;
				byte_0[int_10++] = 0;
				byte_0[int_10++] = 0;
				byte_0[int_10++] = 0;
			}
			return int_10 - num;
		}
		for (int j = 0; j < int_0.Length; j++)
		{
			byte_0[int_10++] = 210;
			byte_0[int_10++] = 0;
			int num2 = int_0[j].Length;
			Array.Copy(BitConverter.GetBytes((short)(num2 * 2)), 0, byte_0, int_10, 2);
			int_10 += 2;
			for (int k = 0; k < num2; k++)
			{
				Array.Copy(BitConverter.GetBytes((short)int_0[j][k]), 0, byte_0, int_10, 2);
				int_10 += 2;
			}
		}
		return int_10 - num;
	}

	internal int method_26(byte[] byte_0, int int_10)
	{
		int num = int_10;
		for (int i = 0; i < string_0.Length; i++)
		{
			int num2 = string_0[i].Length;
			int_10 += smethod_1(byte_0, int_10, num2);
			for (int j = 0; j < num2; j++)
			{
				int_10 += Class1161.smethod_2(byte_0, int_10, string_0[i][j]);
			}
		}
		return int_10 - num;
	}

	internal static int smethod_1(byte[] byte_0, int int_10, int int_11)
	{
		byte_0[int_10++] = 209;
		byte_0[int_10++] = 0;
		byte_0[int_10++] = 2;
		byte_0[int_10++] = 0;
		Array.Copy(BitConverter.GetBytes((short)int_11), 0, byte_0, int_10, 2);
		return 6;
	}

	internal static int smethod_2(byte[] byte_0, int int_10, int int_11)
	{
		byte_0[int_10++] = 213;
		byte_0[int_10++] = 0;
		byte_0[int_10++] = 2;
		byte_0[int_10++] = 0;
		Array.Copy(BitConverter.GetBytes((short)int_11), 0, byte_0, int_10, 2);
		return 6;
	}

	internal static int smethod_3(byte[] byte_0, int int_10, PivotTableSourceType pivotTableSourceType_1)
	{
		byte_0[int_10++] = 227;
		byte_0[int_10++] = 0;
		byte_0[int_10++] = 2;
		byte_0[int_10++] = 0;
		Array.Copy(BitConverter.GetBytes((short)pivotTableSourceType_1), 0, byte_0, int_10, 2);
		return 6;
	}

	internal static object[] smethod_4(WorksheetCollection worksheetCollection_0, string string_6)
	{
		string[] array = Class1677.smethod_31(string_6);
		string text = array[0];
		string text2 = array[1];
		Worksheet worksheet = null;
		if (text != null)
		{
			worksheet = worksheetCollection_0[text];
		}
		object obj = null;
		object[] array2 = new object[2];
		ListObject listObject = worksheetCollection_0.method_95(text2);
		if (listObject != null)
		{
			array2[0] = listObject;
			array2[1] = worksheet;
			return array2;
		}
		object[] array3 = new object[4];
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			Worksheet worksheet2 = worksheetCollection_0[i];
			if (worksheet2.ListObjects.Count <= 0)
			{
				continue;
			}
			for (int j = 0; j < worksheet2.ListObjects.Count; j++)
			{
				ListObject listObject2 = worksheet2.ListObjects[j];
				if (text2.Length < listObject2.DisplayName.Length || text2.IndexOf(':') == -1 || !text2.EndsWith("]"))
				{
					continue;
				}
				text2 = text2.Replace("'[", "[").Replace("']", "]");
				string text3 = text2.Substring(0, listObject2.DisplayName.Length);
				if (text3 == listObject2.DisplayName)
				{
					int num = text2.IndexOf(':');
					string text4 = text2.Substring(text3.Length + 2, num - text3.Length - 3);
					string text5 = text2.Substring(num + 2, text2.Length - num - 4);
					int num2 = listObject2.ListColumns.method_0(text4);
					int num3 = listObject2.ListColumns.method_0(text5);
					if (num2 != -1 && num3 != -1)
					{
						array3[0] = listObject2;
						array3[1] = listObject2.DataRange.Worksheet;
						array3[2] = num2;
						array3[3] = num3;
						return array3;
					}
				}
			}
		}
		obj = Class1677.smethod_32(worksheetCollection_0, worksheet?.Index ?? (-1), text2.ToCharArray());
		if (obj == null)
		{
			throw new ArgumentException("Unkown Area");
		}
		array2[0] = obj;
		array2[1] = worksheet;
		return array2;
	}
}
