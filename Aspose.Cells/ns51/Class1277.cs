using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns1;
using ns12;
using ns14;
using ns2;
using ns22;
using ns25;
using ns29;
using ns39;
using ns45;
using ns58;

namespace ns51;

internal class Class1277
{
	internal Enum47 enum47_0;

	internal bool bool_0;

	private bool bool_1;

	private ArrayList arrayList_0;

	private Hashtable hashtable_0;

	private int[] int_0;

	private Hashtable hashtable_1 = new Hashtable();

	private ICustomFunction icustomFunction_0;

	private int int_1;

	internal Workbook workbook_0;

	private bool bool_2;

	private Hashtable hashtable_2;

	private ArrayList arrayList_1;

	private ArrayList arrayList_2 = new ArrayList();

	private int int_2;

	internal Class1277(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		arrayList_0 = new ArrayList();
		hashtable_0 = new Hashtable();
		int_2 = workbook_1.Settings.CalcStackSize;
	}

	internal void method_0(bool bool_3, ICustomFunction icustomFunction_1)
	{
		icustomFunction_0 = icustomFunction_1;
		bool_1 = bool_3;
	}

	internal void Clear()
	{
		arrayList_0.Clear();
		hashtable_0.Clear();
		icustomFunction_0 = null;
		if (hashtable_2 != null)
		{
			hashtable_2.Clear();
		}
		int_1 = 0;
		int_0 = null;
	}

	internal int method_1(int int_3)
	{
		int count = workbook_0.Worksheets.Count;
		if (int_0 == null || count != int_0.Length)
		{
			int_0 = new int[count];
			for (int i = 0; i < count; i++)
			{
				int_0[i] = workbook_0.Worksheets[i].Cells.MaxDataRow;
				if (int_0[i] < 0)
				{
					int_0[i] = 0;
				}
			}
		}
		return int_0[int_3];
	}

	internal int method_2(int int_3, int int_4)
	{
		if (method_1(int_3) == 0)
		{
			return 0;
		}
		string key = int_3 + "-" + int_4;
		if (hashtable_1[key] != null)
		{
			return (int)hashtable_1[key];
		}
		RowCollection rows = workbook_0.Worksheets[int_3].Cells.Rows;
		int num = rows.Count - 1;
		Row row;
		while (true)
		{
			if (num >= 0)
			{
				row = rows.method_4(num);
				Cell cellOrNull = row.GetCellOrNull(int_4);
				if (cellOrNull != null && (cellOrNull.IsFormula || !cellOrNull.IsBlank))
				{
					break;
				}
				num--;
				continue;
			}
			hashtable_1[key] = -1;
			return -1;
		}
		hashtable_1[key] = row.Index;
		return row.Index;
	}

	internal Class1375 method_3(Struct87 struct87_0, bool bool_3, bool bool_4, bool bool_5, bool bool_6)
	{
		int num = struct87_0.int_1;
		Cells cells = workbook_0.Worksheets[num].Cells;
		int num2 = struct87_0.cellArea_0.StartRow;
		int startColumn = struct87_0.cellArea_0.StartColumn;
		int num3 = struct87_0.cellArea_0.EndRow;
		int num4 = struct87_0.cellArea_0.EndColumn;
		if (num2 > num3)
		{
			int num5 = num2;
			num2 = num3;
			num3 = num5;
		}
		int num6 = ((!bool_5) ? cells.method_20(0) : method_1(num));
		if (num3 > num6)
		{
			num3 = num6;
		}
		if (num3 < num2)
		{
			num3 = num2;
		}
		if (num4 > cells.MaxColumn)
		{
			num4 = cells.MaxColumn;
		}
		if (num4 < startColumn)
		{
			num4 = startColumn;
		}
		return method_4(num, num2, startColumn, num3, num4, bool_3, bool_4, bool_6);
	}

	internal Class1375 method_4(int int_3, int int_4, int int_5, int int_6, int int_7, bool bool_3, bool bool_4, bool bool_5)
	{
		Class1375 @class = null;
		bool flag = false;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			@class = (Class1375)arrayList_0[i];
			if (@class.int_0 == int_3 && @class.int_2 == int_5 && @class.int_1 == int_4 && @class.int_3 == int_6 && @class.int_4 == int_7)
			{
				flag = true;
				bool_4 = true;
				break;
			}
		}
		if (!flag)
		{
			@class = null;
			if (bool_3)
			{
				@class = new Class1375();
				@class.int_0 = int_3;
				@class.int_1 = int_4;
				@class.int_2 = int_5;
				@class.int_3 = int_6;
				@class.int_4 = int_7;
				if (arrayList_0.Count >= 20)
				{
					arrayList_0.RemoveAt(0);
				}
				arrayList_0.Add(@class);
			}
		}
		else if (@class.bool_1)
		{
			@class.object_0 = null;
		}
		if (!bool_4)
		{
			return @class;
		}
		if (@class.object_0 != null && bool_5 && !@class.bool_0)
		{
			@class.bool_0 = true;
			object[][] array = (object[][])@class.object_0;
			int num = array.Length;
			for (int j = 0; j < num; j++)
			{
				object[] array2 = array[j];
				if (array2 == null)
				{
					continue;
				}
				for (int k = 0; k < array2.Length; k++)
				{
					if (array2[k] != null && array2[k] is Cell)
					{
						array2[k] = method_211((Cell)array2[k]);
					}
				}
			}
			return @class;
		}
		if (bool_4 && @class.object_0 == null)
		{
			@class.bool_0 = bool_5;
			int num2 = int_6 - int_4 + 1;
			int num3 = int_7 - int_5 + 1;
			object[][] array3 = new object[num2][];
			array3[0] = new object[num3];
			Worksheet worksheet = workbook_0.Worksheets[int_3];
			RowCollection rows = worksheet.Cells.Rows;
			if (int_6 > method_1(int_3))
			{
				int_6 = method_1(int_3);
			}
			if (int_7 > worksheet.Cells.method_22(0))
			{
				int_7 = worksheet.Cells.method_22(0);
			}
			int l = worksheet.Cells.Rows.method_14(int_4, int_6);
			Cell cell = null;
			if (l != -1)
			{
				for (; l < rows.Count; l++)
				{
					Row row = rows.method_4(l);
					int index = row.Index;
					if (index > int_6)
					{
						break;
					}
					int num4 = index - int_4;
					array3[num4] = new object[num3];
					for (int m = 0; m < num3; m++)
					{
						cell = row.GetCellOrNull(int_5 + m);
						if (cell == null)
						{
							continue;
						}
						if (bool_5)
						{
							array3[num4][m] = method_211(cell);
							if (cell.IsFormula && cell.method_62())
							{
								@class.bool_1 = true;
							}
						}
						else if (cell.IsFormula && cell.method_60() != 2)
						{
							array3[num4][m] = cell;
						}
						else
						{
							array3[num4][m] = cell.method_59();
						}
					}
				}
			}
			@class.object_0 = array3;
		}
		return @class;
	}

	internal object method_5(Class1661 class1661_0, Cell cell_0)
	{
		object result = null;
		if (cell_0 != null && cell_0.IsInArray)
		{
			byte[] array = cell_0.method_41();
			int num = BitConverter.ToInt32(array, 5);
			int num2 = Class1268.smethod_1(array, 9);
			if (num != cell_0.Row || num2 != cell_0.Column)
			{
				Cell cell = cell_0.method_4().GetCell(num, num2, bool_2: false);
				switch (cell.method_60())
				{
				case 0:
				{
					Class1661 @class = workbook_0.Worksheets.Formula.method_10(cell);
					if (@class != null)
					{
						result = method_5(@class, cell);
						Class1379.smethod_0(result, cell);
						return cell_0.method_59();
					}
					break;
				}
				case 1:
					return ErrorType.Recursive;
				case 2:
					return cell_0.method_59();
				}
			}
		}
		switch (class1661_0.Type)
		{
		case Enum180.const_1:
			result = method_39(class1661_0, cell_0);
			break;
		case Enum180.const_2:
			result = method_6(class1661_0, cell_0);
			break;
		case Enum180.const_3:
		case Enum180.const_5:
			result = method_44(class1661_0, cell_0);
			break;
		}
		return result;
	}

	private object method_6(Class1661 class1661_0, Cell cell_0)
	{
		switch (class1661_0.method_9()[0])
		{
		case 5:
			return method_27(class1661_0, cell_0);
		case 6:
			return method_28(class1661_0, cell_0);
		case 7:
			return method_16(class1661_0, cell_0);
		case 8:
			return method_15(class1661_0, cell_0);
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
			return method_12(class1661_0, cell_0);
		case 15:
			return method_10(class1661_0, cell_0);
		case 16:
			return method_9(class1661_0, cell_0);
		case 17:
			return method_11(class1661_0, cell_0);
		case 3:
		case 18:
			return method_25(class1661_0, cell_0);
		case 4:
		case 19:
			return method_26(class1661_0, cell_0);
		case 20:
			return method_8(class1661_0, cell_0);
		case 21:
			return method_7(class1661_0, cell_0);
		default:
			return null;
		case 36:
		case 68:
		case 100:
			return method_39(class1661_0, cell_0);
		}
	}

	private object method_7(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		return method_5(class1661_, cell_0);
	}

	private object method_8(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 @class = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(@class.Type switch
		{
			Enum180.const_1 => method_39(@class, cell_0), 
			Enum180.const_2 => method_6(@class, cell_0), 
			Enum180.const_3 => method_44(@class, cell_0), 
			_ => null, 
		}, workbook_0.Settings.Date1904);
		if (obj == null)
		{
			return 0.0;
		}
		if (Type.GetTypeCode(obj.GetType()) != TypeCode.Double)
		{
			return ErrorType.Value;
		}
		return (double)obj / 100.0;
	}

	private object method_9(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		object obj = method_5(class1661_, cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		object obj2 = method_5(class1661_2, cell_0);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		ArrayList arrayList = new ArrayList();
		Class1660.smethod_30(arrayList, obj);
		Class1660.smethod_30(arrayList, obj2);
		object[][] array = new object[1][] { new object[arrayList.Count] };
		for (int i = 0; i < arrayList.Count; i++)
		{
			array[0][i] = arrayList[i];
		}
		return array;
	}

	private object method_10(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		object obj = method_5(class1661_, cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		object obj2 = method_5(class1661_2, cell_0);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		if (obj is Struct87 && obj2 is Struct87)
		{
			Struct87 @struct = (Struct87)obj;
			Struct87 struct2 = (Struct87)obj2;
			if (@struct.int_1 != struct2.int_1)
			{
				return ErrorType.Value;
			}
			object obj3 = Class1678.Intersect(@struct.cellArea_0, struct2.cellArea_0);
			if (obj3 == null)
			{
				return ErrorType.Null;
			}
			if (class1661_0.method_5() != null && class1661_0.method_3() == "AREAS")
			{
				return 1.0;
			}
			CellArea cellArea = (CellArea)obj3;
			return CalculateRange(class1661_0, workbook_0.Worksheets[@struct.int_1], cell_0, cellArea.StartRow, cellArea.EndRow, cellArea.StartColumn, cellArea.EndColumn, bool_3: false);
		}
		return null;
	}

	private object method_11(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		object obj = method_5(class1661_, cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		object obj2 = method_5(class1661_2, cell_0);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		bool bool_ = cell_0?.IsInArray ?? true;
		if (obj is string)
		{
			if (obj2 is string && Class1267.smethod_1((string)obj) && Class1267.smethod_1((string)obj2))
			{
				CellsHelper.CellNameToIndex((string)obj, out var row, out var column);
				CellsHelper.CellNameToIndex((string)obj2, out var row2, out var column2);
				if (row > row2)
				{
					int num = row2;
					row2 = row;
					row = num;
				}
				if (column > column2)
				{
					int num2 = column2;
					column2 = column;
					column = num2;
				}
				return CalculateRange(class1661_0, cell_0.method_4().method_3(), cell_0, row, row2, column, column2, bool_);
			}
		}
		else if (obj is Struct87 && obj2 is Struct87)
		{
			Struct87 @struct = (Struct87)obj;
			Struct87 struct2 = (Struct87)obj2;
			if (@struct.int_1 != struct2.int_1)
			{
				return ErrorType.Value;
			}
			int num3 = ((@struct.cellArea_0.StartRow >= struct2.cellArea_0.StartRow) ? struct2.cellArea_0.StartRow : @struct.cellArea_0.StartRow);
			int num4 = ((@struct.cellArea_0.StartColumn >= struct2.cellArea_0.StartColumn) ? struct2.cellArea_0.StartColumn : @struct.cellArea_0.StartColumn);
			int num5 = ((@struct.cellArea_0.EndRow >= struct2.cellArea_0.EndRow) ? @struct.cellArea_0.EndRow : struct2.cellArea_0.EndRow);
			int num6 = ((@struct.cellArea_0.EndColumn >= struct2.cellArea_0.EndColumn) ? @struct.cellArea_0.EndColumn : struct2.cellArea_0.EndColumn);
			if (class1661_0.method_5() != null && class1661_0.method_3() == "AREAS")
			{
				if (num6 >= num4 && num5 >= num3)
				{
					return 1.0;
				}
				return ErrorType.Null;
			}
			if (cell_0 == null)
			{
				Struct87 struct3 = default(Struct87);
				struct3.int_1 = @struct.int_1;
				struct3.cellArea_0.StartRow = num3;
				struct3.cellArea_0.StartColumn = num4;
				struct3.cellArea_0.EndRow = num5;
				struct3.cellArea_0.EndColumn = num6;
				return struct3;
			}
			return CalculateRange(class1661_0, workbook_0.Worksheets[@struct.int_1], cell_0, num3, num5, num4, num6, bool_);
		}
		return null;
	}

	private object method_12(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 @class = (Class1661)class1661_0.method_7()[0];
		Class1661 class2 = (Class1661)class1661_0.method_7()[1];
		object obj = @class.Type switch
		{
			Enum180.const_1 => method_39(@class, cell_0), 
			Enum180.const_2 => method_6(@class, cell_0), 
			Enum180.const_3 => method_44(@class, cell_0), 
			_ => null, 
		};
		object obj2 = class2.Type switch
		{
			Enum180.const_1 => method_39(class2, cell_0), 
			Enum180.const_2 => method_6(class2, cell_0), 
			Enum180.const_3 => method_44(class2, cell_0), 
			_ => null, 
		};
		if (obj is object[][])
		{
			object[][] array = (object[][])obj;
			object[][] array2 = new object[array.Length][];
			int num = array[0].Length;
			for (int i = 0; i < array.Length; i++)
			{
				object[] array3 = array[i];
				array2[i] = new object[num];
				if (array3 == null)
				{
					object obj3 = Compare(null, obj2, class1661_0.method_9()[0]);
					for (int j = 0; j < num; j++)
					{
						array2[i][j] = obj3;
					}
				}
				else
				{
					for (int k = 0; k < array3.Length; k++)
					{
						object object_ = array3[k];
						array2[i][k] = Compare(object_, obj2, class1661_0.method_9()[0]);
					}
				}
			}
			return array2;
		}
		if (obj2 is object[][])
		{
			object[][] array4 = (object[][])obj2;
			object[][] array5 = new object[array4.Length][];
			int num2 = array4[0].Length;
			for (int l = 0; l < array4.Length; l++)
			{
				object[] array6 = array4[l];
				array5[l] = new object[num2];
				if (array6 == null)
				{
					object obj4 = Compare(obj, null, class1661_0.method_9()[0]);
					for (int m = 0; m < num2; m++)
					{
						array5[l][m] = obj4;
					}
				}
				else
				{
					for (int n = 0; n < array6.Length; n++)
					{
						object object_2 = array6[n];
						array5[l][n] = Compare(obj, object_2, class1661_0.method_9()[0]);
					}
				}
			}
			return array5;
		}
		if (cell_0 != null && cell_0.method_4().method_3().method_25())
		{
			if (obj != null && obj is string && ((string)obj).Trim() == "")
			{
				obj = 0.0;
			}
			if (obj2 != null && obj2 is string && ((string)obj2).Trim() == "")
			{
				obj2 = 0.0;
			}
		}
		return Compare(obj, obj2, class1661_0.method_9()[0]);
	}

	private object Compare(object object_0, object object_1, byte byte_0)
	{
		if (object_0 != null && object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_1 != null && object_1 is ErrorType)
		{
			return object_1;
		}
		if (object_0 == null)
		{
			if (object_1 == null)
			{
				switch (byte_0)
				{
				default:
					return null;
				case 10:
				case 11:
				case 12:
					return true;
				case 9:
				case 13:
					return false;
				case 14:
					return false;
				}
			}
			switch (byte_0)
			{
			default:
				return null;
			case 9:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				case TypeCode.Double:
					if ((double)object_1 <= 0.0)
					{
						return false;
					}
					break;
				case TypeCode.DateTime:
					if (CellsHelper.GetDoubleFromDateTime((DateTime)object_1, workbook_0.Settings.Date1904) <= 0.0)
					{
						return false;
					}
					break;
				case TypeCode.Boolean:
					if (!(bool)object_1)
					{
						return false;
					}
					break;
				}
				return true;
			case 10:
				return Type.GetTypeCode(object_1.GetType()) switch
				{
					TypeCode.Double => (double)object_1 >= 0.0, 
					TypeCode.DateTime => CellsHelper.GetDoubleFromDateTime((DateTime)object_1, workbook_0.Settings.Date1904) >= 0.0, 
					_ => true, 
				};
			case 11:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				case TypeCode.Double:
					if ((double)object_1 == 0.0)
					{
						return true;
					}
					goto default;
				case TypeCode.DateTime:
					if (CellsHelper.GetDoubleFromDateTime((DateTime)object_1, workbook_0.Settings.Date1904) == 0.0)
					{
						return true;
					}
					goto default;
				case TypeCode.String:
					if ((string)object_1 == "")
					{
						return true;
					}
					goto default;
				default:
					return false;
				case TypeCode.Boolean:
					return !(bool)object_1;
				}
			case 12:
				return Type.GetTypeCode(object_1.GetType()) switch
				{
					TypeCode.Double => (double)object_1 <= 0.0, 
					TypeCode.DateTime => CellsHelper.GetDoubleFromDateTime((DateTime)object_1, workbook_0.Settings.Date1904) <= 0.0, 
					TypeCode.Boolean => !(bool)object_1, 
					_ => false, 
				};
			case 13:
				return Type.GetTypeCode(object_1.GetType()) switch
				{
					TypeCode.Double => (double)object_1 < 0.0, 
					TypeCode.DateTime => CellsHelper.GetDoubleFromDateTime((DateTime)object_1, workbook_0.Settings.Date1904) < 0.0, 
					_ => false, 
				};
			case 14:
				switch (Type.GetTypeCode(object_1.GetType()))
				{
				case TypeCode.Double:
					if ((double)object_1 == 0.0)
					{
						return false;
					}
					goto default;
				case TypeCode.DateTime:
					if (CellsHelper.GetDoubleFromDateTime((DateTime)object_1, workbook_0.Settings.Date1904) == 0.0)
					{
						return false;
					}
					goto default;
				case TypeCode.String:
					if ((string)object_1 == "")
					{
						return false;
					}
					goto default;
				default:
					return true;
				case TypeCode.Boolean:
					return (bool)object_1;
				}
			}
		}
		if (object_1 == null)
		{
			return byte_0 switch
			{
				9 => Type.GetTypeCode(object_0.GetType()) switch
				{
					TypeCode.Double => (double)object_0 < 0.0, 
					TypeCode.DateTime => CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbook_0.Settings.Date1904) < 0.0, 
					_ => false, 
				}, 
				10 => Type.GetTypeCode(object_0.GetType()) switch
				{
					TypeCode.Double => (double)object_0 <= 0.0, 
					TypeCode.DateTime => CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbook_0.Settings.Date1904) <= 0.0, 
					TypeCode.Boolean => !(bool)object_0, 
					_ => false, 
				}, 
				11 => Type.GetTypeCode(object_0.GetType()) switch
				{
					TypeCode.Double => (double)object_0 == 0.0, 
					TypeCode.DateTime => CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbook_0.Settings.Date1904) == 0.0, 
					TypeCode.String => ((string)object_0).Length == 0, 
					TypeCode.Boolean => !(bool)object_0, 
					_ => false, 
				}, 
				12 => Type.GetTypeCode(object_0.GetType()) switch
				{
					TypeCode.Double => (double)object_0 >= 0.0, 
					TypeCode.DateTime => CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbook_0.Settings.Date1904) >= 0.0, 
					_ => true, 
				}, 
				13 => Type.GetTypeCode(object_0.GetType()) switch
				{
					TypeCode.Double => (double)object_0 > 0.0, 
					TypeCode.DateTime => CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbook_0.Settings.Date1904) > 0.0, 
					TypeCode.Boolean => (bool)object_0, 
					_ => true, 
				}, 
				14 => Type.GetTypeCode(object_0.GetType()) switch
				{
					TypeCode.Double => (double)object_0 != 0.0, 
					TypeCode.DateTime => CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbook_0.Settings.Date1904) != 0.0, 
					TypeCode.Boolean => (bool)object_0, 
					_ => true, 
				}, 
				_ => null, 
			};
		}
		return byte_0 switch
		{
			9 => Class1662.Compare(object_0, object_1, "<", workbook_0.Settings.Date1904), 
			10 => Class1662.Compare(object_0, object_1, "<=", workbook_0.Settings.Date1904), 
			11 => Class1662.Compare(object_0, object_1, "=", workbook_0.Settings.Date1904, bool_1: false), 
			12 => Class1662.Compare(object_0, object_1, ">=", workbook_0.Settings.Date1904), 
			13 => Class1662.Compare(object_0, object_1, ">", workbook_0.Settings.Date1904), 
			14 => Class1662.Compare(object_0, object_1, "<>", workbook_0.Settings.Date1904), 
			_ => null, 
		};
	}

	private object method_13(Class1661 class1661_0, Cell cell_0)
	{
		DateTime dateTime = new DateTime(1900, 1, 1);
		object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
		if (obj is double)
		{
			dateTime = CellsHelper.GetDateTimeFromDouble((double)obj, workbook_0.Settings.Date1904);
			object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
			if (obj2 is double)
			{
				int num = (int)Class1179.ToDouble(obj2);
				return Class1670.smethod_0(dateTime, num);
			}
			return obj2;
		}
		return obj;
	}

	private object method_14(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 @class = (Class1661)class1661_0.method_7()[0];
		Class1661 class2 = (Class1661)class1661_0.method_7()[1];
		object obj = @class.Type switch
		{
			Enum180.const_1 => method_39(@class, cell_0), 
			Enum180.const_2 => method_6(@class, cell_0), 
			Enum180.const_3 => method_44(@class, cell_0), 
			_ => null, 
		};
		object obj2 = class2.Type switch
		{
			Enum180.const_1 => method_39(class2, cell_0), 
			Enum180.const_2 => method_6(class2, cell_0), 
			Enum180.const_3 => method_44(class2, cell_0), 
			_ => null, 
		};
		if (obj == null)
		{
			if (obj2 == null)
			{
				return true;
			}
			if (obj2 is ErrorType)
			{
				return obj2;
			}
			return false;
		}
		if (obj2 == null)
		{
			if (obj is ErrorType)
			{
				return obj;
			}
			return false;
		}
		if (!cell_0.IsInArray && class1661_0.method_9()[0] != 97)
		{
			return Class1374.smethod_8(workbook_0, obj, obj2);
		}
		return Class1120.smethod_7(workbook_0, obj, obj2);
	}

	private object method_15(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 @class = (Class1661)class1661_0.method_7()[0];
		Class1661 class2 = (Class1661)class1661_0.method_7()[1];
		object obj = @class.Type switch
		{
			Enum180.const_1 => method_39(@class, cell_0), 
			Enum180.const_2 => method_6(@class, cell_0), 
			Enum180.const_3 => method_44(@class, cell_0), 
			_ => null, 
		};
		object obj2 = class2.Type switch
		{
			Enum180.const_1 => method_39(class2, cell_0), 
			Enum180.const_2 => method_6(class2, cell_0), 
			Enum180.const_3 => method_44(class2, cell_0), 
			_ => null, 
		};
		if (obj is Array)
		{
			Array array_ = (Array)obj;
			if (obj2 is Array)
			{
				Array array_2 = (Array)obj2;
				return Class1120.smethod_5(array_, array_2);
			}
		}
		if (obj == null)
		{
			obj = "";
		}
		else if (obj is DateTime)
		{
			obj = CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904).ToString();
		}
		else
		{
			obj = Class1660.smethod_24(obj);
			if (obj is ErrorType)
			{
				return obj;
			}
		}
		if (obj2 == null)
		{
			obj2 = "";
		}
		else if (obj2 is DateTime)
		{
			obj2 = CellsHelper.GetDoubleFromDateTime((DateTime)obj2, workbook_0.Settings.Date1904).ToString();
		}
		else
		{
			obj2 = Class1660.smethod_24(obj2);
			if (obj2 is ErrorType)
			{
				return obj2;
			}
		}
		return obj.ToString() + obj2.ToString();
	}

	private object method_16(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		object obj = method_5(class1661_, cell_0);
		object obj2 = method_5(class1661_2, cell_0);
		if (obj == null)
		{
			obj = 0.0;
		}
		if (obj2 == null)
		{
			obj2 = 0.0;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		if (!(obj is Array) && !(obj2 is Array))
		{
			return Class1374.smethod_10(workbook_0, obj, obj2);
		}
		return Class1120.smethod_4(workbook_0, obj, obj2);
	}

	private object method_17(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		Class1661 class1661_3 = (Class1661)class1661_0.method_7()[2];
		object obj = method_5(class1661_, cell_0);
		object obj2 = method_5(class1661_2, cell_0);
		object obj3 = method_5(class1661_3, cell_0);
		if (obj == null)
		{
			obj = 0.0;
		}
		if (obj2 == null)
		{
			obj2 = 0.0;
		}
		if (obj3 == null)
		{
			return ErrorType.Div;
		}
		obj = Class1660.smethod_26(obj, workbook_0.Settings.Date1904);
		if (obj is ErrorType)
		{
			return obj;
		}
		obj2 = Class1660.smethod_26(obj2, workbook_0.Settings.Date1904);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		obj3 = Class1660.smethod_26(obj3, workbook_0.Settings.Date1904);
		if (obj3 is ErrorType)
		{
			return obj3;
		}
		double num = (double)obj;
		double num2 = (double)obj2;
		double num3 = (double)obj3;
		if (num3 == 0.0)
		{
			return ErrorType.Div;
		}
		return (num - num2) / num3;
	}

	private object method_18(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		Class1661 class1661_3 = (Class1661)class1661_0.method_7()[2];
		Class1661 class1661_4 = (Class1661)class1661_0.method_7()[3];
		object obj = method_5(class1661_, cell_0);
		object obj2 = method_5(class1661_2, cell_0);
		object obj3 = method_5(class1661_3, cell_0);
		object object_ = method_5(class1661_4, cell_0);
		if (obj == null)
		{
			obj = 0.0;
		}
		if (obj2 == null)
		{
			obj2 = 0.0;
		}
		if (obj3 == null)
		{
			return ErrorType.Div;
		}
		obj = Class1660.smethod_26(obj, workbook_0.Settings.Date1904);
		if (obj is ErrorType)
		{
			return obj;
		}
		obj2 = Class1660.smethod_26(obj2, workbook_0.Settings.Date1904);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		obj3 = Class1660.smethod_26(obj3, workbook_0.Settings.Date1904);
		if (obj3 is ErrorType)
		{
			return obj3;
		}
		object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
		if (object_ is ErrorType)
		{
			return object_;
		}
		double num = (double)obj;
		double num2 = (double)obj2;
		double num3 = (double)obj3;
		double num4 = (double)object_;
		if (num3 == 0.0)
		{
			return ErrorType.Div;
		}
		if (num4 >= num3 + 1.0)
		{
			return ErrorType.Number;
		}
		return (num - num2) * (num3 - num4 + 1.0) * 2.0 / (num3 * (num3 + 1.0));
	}

	private object method_19(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_52((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		double double_ = (double)obj;
		obj = method_52((Class1661)class1661_0.method_7()[1], cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		double double_2 = (double)obj;
		obj = method_52((Class1661)class1661_0.method_7()[2], cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		double double_3 = (double)obj;
		object object_ = method_5((Class1661)class1661_0.method_7()[3], cell_0);
		object_ = Class1660.smethod_13(object_, cell_0, workbook_0.Settings.Date1904, bool_1: true);
		if (object_ is ErrorType)
		{
			return object_;
		}
		double[] double_4 = (double[])object_;
		return Class1341.smethod_0(double_, double_2, double_3, double_4);
	}

	private object method_20(Class1661 class1661_0, Cell cell_0, bool bool_3)
	{
		object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj == null)
		{
			return ErrorType.Value;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		if (!(obj is Array))
		{
			return ErrorType.Value;
		}
		object[][] array = (object[][])obj;
		object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
		if (obj2 == null)
		{
			return ErrorType.Value;
		}
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		int num = -1;
		bool flag = false;
		string[] array2 = new string[array[0].Length];
		if (obj2 is double)
		{
			num = (int)Class1179.ToDouble(obj2) - 1;
			if (num < 0 || num >= array[0].Length)
			{
				return ErrorType.Value;
			}
			for (int i = 0; i < array[0].Length; i++)
			{
				array2[i] = array[0][i].ToString().ToUpper();
			}
		}
		else
		{
			string text = obj2.ToString().ToUpper();
			for (int j = 0; j < array[0].Length; j++)
			{
				if (array[0][j] != null)
				{
					array2[j] = array[0][j].ToString().ToUpper();
					if (!flag && array2[j] == text)
					{
						flag = true;
						num = j;
					}
				}
			}
			if (!flag)
			{
				return ErrorType.Value;
			}
		}
		object obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
		object[][] array3 = null;
		int[] array4 = null;
		if (obj3 == null)
		{
			return ErrorType.Value;
		}
		if (obj3 is ErrorType)
		{
			return obj3;
		}
		if (!(obj3 is Array))
		{
			return ErrorType.Value;
		}
		array3 = Class779.smethod_0((object[][])obj3);
		array4 = new int[array3[0].Length];
		int num2 = 0;
		while (true)
		{
			if (num2 < array3[0].Length)
			{
				if (array3[0][num2] != null)
				{
					string text2 = array3[0][num2].ToString().ToUpper();
					flag = false;
					for (int k = 0; k < array2.Length; k++)
					{
						if (array2[k] == text2)
						{
							array4[num2] = k;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						break;
					}
				}
				num2++;
				continue;
			}
			for (int l = 1; l < array3.Length; l++)
			{
				object[] array5 = array3[l];
				for (int m = 0; m < array5.Length; m++)
				{
					if (array3[l][m] == null)
					{
						continue;
					}
					string text3 = array3[l][m].ToString();
					if (text3[0] != '=' && text3[0] != '<' && text3[0] != '>')
					{
						if (array3[l][m] is string)
						{
							object obj4 = Class1662.smethod_5((string)array3[l][m]);
							if (obj4 != null && !(obj4 is ErrorType))
							{
								array3[l][m] = obj4;
							}
						}
						array3[l][m] = new object[2]
						{
							"=",
							array3[l][m]
						};
					}
					else
					{
						object[] array6 = Class1662.smethod_6(text3);
						array3[l][m] = array6;
					}
				}
			}
			ArrayList arrayList = new ArrayList();
			int num3 = 0;
			int num4 = 1;
			while (true)
			{
				if (num4 < array.Length)
				{
					object[] array7 = array[num4];
					if (array7 != null)
					{
						bool flag2 = true;
						if (array3 != null)
						{
							for (int n = 1; n < array3.Length; n++)
							{
								object[] array8 = array3[n];
								flag2 = true;
								for (int num5 = 0; num5 < array8.Length; num5++)
								{
									if (array8[num5] != null)
									{
										object[] array9 = (object[])array8[num5];
										object obj5 = Class1662.smethod_2(array[num4][array4[num5]], array9[1], (string)array9[0], workbook_0.Settings.Date1904);
										if (obj5 is ErrorType)
										{
											return obj5;
										}
										if (!(bool)obj5)
										{
											flag2 = false;
											break;
										}
									}
								}
								if (flag2)
								{
									break;
								}
							}
						}
						if (flag2)
						{
							object obj6 = array7[num];
							if (obj6 != null)
							{
								if (bool_3)
								{
									num3++;
								}
								if (class1661_0.method_3() == "DGET")
								{
									arrayList.Add(obj6);
									if (arrayList.Count > 1)
									{
										break;
									}
								}
								else
								{
									obj6 = Class1660.smethod_26(obj6, workbook_0.Settings.Date1904);
									if (!(obj6 is ErrorType))
									{
										arrayList.Add(obj6);
									}
								}
							}
						}
					}
					num4++;
					continue;
				}
				string key;
				if ((key = class1661_0.method_3()) != null)
				{
					if (Class1742.dictionary_83 == null)
					{
						Class1742.dictionary_83 = new Dictionary<string, int>(8)
						{
							{ "DCOUNT", 0 },
							{ "DCOUNTA", 1 },
							{ "DGET", 2 },
							{ "DAVERAGE", 3 },
							{ "DSTDEV", 4 },
							{ "DSTDEVP", 5 },
							{ "DVAR", 6 },
							{ "DVARP", 7 }
						};
					}
					if (Class1742.dictionary_83.TryGetValue(key, out var value))
					{
						switch (value)
						{
						case 0:
							return (double)arrayList.Count;
						case 1:
							return (double)num3;
						case 2:
							break;
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
							goto IL_0529;
						default:
							goto IL_0539;
						}
						if (arrayList.Count == 0)
						{
							return ErrorType.Value;
						}
						if (arrayList.Count > 1)
						{
							return ErrorType.Number;
						}
						return arrayList[0];
					}
				}
				goto IL_0539;
				IL_0551:
				double[] array10 = new double[arrayList.Count];
				for (int num6 = 0; num6 < arrayList.Count; num6++)
				{
					array10[num6] = (double)arrayList[num6];
				}
				string key2;
				if ((key2 = class1661_0.method_3()) != null)
				{
					if (Class1742.dictionary_84 == null)
					{
						Class1742.dictionary_84 = new Dictionary<string, int>(9)
						{
							{ "DAVERAGE", 0 },
							{ "DMAX", 1 },
							{ "DMIN", 2 },
							{ "DPRODUCT", 3 },
							{ "DSTDEV", 4 },
							{ "DSTDEVP", 5 },
							{ "DSUM", 6 },
							{ "DVAR", 7 },
							{ "DVARP", 8 }
						};
					}
					if (Class1742.dictionary_84.TryGetValue(key2, out var value2))
					{
						switch (value2)
						{
						case 0:
							return Class1668.smethod_39(array10, 1, array10.Length);
						case 1:
							return Class1668.smethod_26(array10);
						case 2:
							return Class1668.smethod_25(array10);
						case 3:
							return Class1668.smethod_27(array10);
						case 4:
							return Class1668.smethod_28(array10);
						case 5:
							return Class1668.smethod_30(array10);
						case 6:
							return Class1668.smethod_40(array10);
						case 7:
							return Class1668.smethod_29(array10);
						case 8:
							return Class1668.smethod_31(array10);
						}
					}
				}
				return null;
				IL_0529:
				if (arrayList.Count == 0)
				{
					return ErrorType.Div;
				}
				goto IL_0551;
				IL_0539:
				if (arrayList.Count == 0)
				{
					return 0.0;
				}
				goto IL_0551;
			}
			return ErrorType.Number;
		}
		return ErrorType.Value;
	}

	private object method_21(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_52((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[1];
		object object_ = method_5(class1661_, cell_0);
		object_ = Class1660.smethod_13(object_, cell_0, workbook_0.Settings.Date1904, bool_1: true);
		if (object_ is ErrorType)
		{
			return object_;
		}
		double[] double_ = (double[])object_;
		return Class1378.smethod_75((double)obj, double_);
	}

	private object method_22(Class1661 class1661_0, Cell cell_0, int int_3)
	{
		object[] array = new object[int_3];
		int num = 0;
		object obj;
		while (true)
		{
			if (num < int_3)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num];
				obj = method_5(class1661_, cell_0);
				if (obj is ErrorType)
				{
					break;
				}
				array[num] = obj;
				num++;
				continue;
			}
			object obj2 = Class1660.smethod_12(array[0], array[1], workbook_0.Settings);
			if (obj2 is ErrorType)
			{
				return obj2;
			}
			array = (object[])obj2;
			return class1661_0.method_3() switch
			{
				"SLOPE" => Class1668.smethod_33((double[])array[0], (double[])array[1]), 
				"INTERCEPT" => Class1668.smethod_42((double[])array[0], (double[])array[1]), 
				_ => null, 
			};
		}
		return obj;
	}

	private object method_23(Class1661 class1661_0, Cell cell_0, int int_3)
	{
		object[] array = new object[int_3];
		int num = 0;
		object object_;
		while (true)
		{
			if (num < int_3)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num];
				object_ = method_5(class1661_, cell_0);
				object_ = Class1660.smethod_13(object_, cell_0, workbook_0.Settings.Date1904, bool_1: false);
				if (object_ is ErrorType)
				{
					break;
				}
				array[num] = object_;
				num++;
				continue;
			}
			string key;
			if ((key = class1661_0.method_3()) != null)
			{
				if (Class1742.dictionary_85 == null)
				{
					Class1742.dictionary_85 = new Dictionary<string, int>(9)
					{
						{ "COVAR", 0 },
						{ "MIRR", 1 },
						{ "PERCENTRANK", 2 },
						{ "STEYX", 3 },
						{ "SUMX2MY2", 4 },
						{ "SUMX2PY2", 5 },
						{ "SUMXMY2", 6 },
						{ "TRIMMEAN", 7 },
						{ "ZTEST", 8 }
					};
				}
				if (Class1742.dictionary_85.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						return Class1668.smethod_53((double[])array[0], (double[])array[1]);
					case 1:
					{
						object obj3 = method_52((Class1661)class1661_0.method_7()[1], cell_0);
						if (obj3 is ErrorType)
						{
							return obj3;
						}
						object obj4 = method_52((Class1661)class1661_0.method_7()[2], cell_0);
						if (obj4 is ErrorType)
						{
							return obj4;
						}
						return Class1378.smethod_80((double[])array[0], (double)obj3, (double)obj4);
					}
					case 2:
					{
						object obj6 = method_52((Class1661)class1661_0.method_7()[1], cell_0);
						if (obj6 is ErrorType)
						{
							return obj6;
						}
						if (class1661_0.method_7().Count >= 3)
						{
							object obj7 = method_52((Class1661)class1661_0.method_7()[2], cell_0);
							if (obj7 is ErrorType)
							{
								return obj7;
							}
							return Class1668.smethod_64((double[])array[0], (double)obj6, (double)obj7);
						}
						return Class1668.smethod_65((double[])array[0], (double)obj6);
					}
					case 3:
						return Class1668.smethod_38((double[])array[0], (double[])array[1]);
					case 4:
						if (((double[])array[0]).Length != ((double[])array[1]).Length)
						{
							return ErrorType.NA;
						}
						return Class1341.smethod_1((double[])array[0], (double[])array[1]);
					case 5:
						if (((double[])array[0]).Length != ((double[])array[1]).Length)
						{
							return ErrorType.NA;
						}
						return Class1341.smethod_2((double[])array[0], (double[])array[1]);
					case 6:
						if (((double[])array[0]).Length != ((double[])array[1]).Length)
						{
							return ErrorType.NA;
						}
						return Class1341.smethod_3((double[])array[0], (double[])array[1]);
					case 7:
					{
						object obj5 = method_52((Class1661)class1661_0.method_7()[1], cell_0);
						if (obj5 is ErrorType)
						{
							return obj5;
						}
						return Class1668.smethod_41((double[])array[0], (double)obj5);
					}
					case 8:
					{
						object obj = method_52((Class1661)class1661_0.method_7()[1], cell_0);
						if (obj is ErrorType)
						{
							return obj;
						}
						if (class1661_0.method_7().Count >= 3)
						{
							object obj2 = method_52((Class1661)class1661_0.method_7()[2], cell_0);
							if (obj2 is ErrorType)
							{
								return obj2;
							}
							return Class1668.smethod_66((double[])array[0], (double)obj, (double)obj2);
						}
						return Class1668.smethod_67((double[])array[0], (double)obj);
					}
					}
				}
			}
			return null;
		}
		return object_;
	}

	private object method_24(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		Class1661 class1661_3 = (Class1661)class1661_0.method_7()[2];
		Class1661 class1661_4 = (Class1661)class1661_0.method_7()[3];
		object obj = method_5(class1661_, cell_0);
		object obj2 = method_5(class1661_2, cell_0);
		object obj3 = method_5(class1661_3, cell_0);
		object obj4 = method_5(class1661_4, cell_0);
		if (obj == null)
		{
			obj = 0.0;
		}
		if (obj2 == null)
		{
			obj2 = 0.0;
		}
		if (obj3 == null)
		{
			return ErrorType.Div;
		}
		if (obj4 == null)
		{
			obj4 = 0.0;
		}
		obj = Class1660.smethod_26(obj, workbook_0.Settings.Date1904);
		if (obj is ErrorType)
		{
			return obj;
		}
		obj2 = Class1660.smethod_26(obj2, workbook_0.Settings.Date1904);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		obj3 = Class1660.smethod_26(obj3, workbook_0.Settings.Date1904);
		if (obj3 is ErrorType)
		{
			return obj3;
		}
		obj4 = Class1660.smethod_26(obj4, workbook_0.Settings.Date1904);
		if (obj4 is ErrorType)
		{
			return obj4;
		}
		double double_ = (double)obj;
		double double_2 = (double)obj2;
		double num = (double)obj3;
		if (num == 0.0)
		{
			return ErrorType.Div;
		}
		double double_3 = (double)obj4;
		double double_4 = 2.0;
		if (class1661_0.method_7().Count > 4)
		{
			Class1661 class1661_5 = (Class1661)class1661_0.method_7()[4];
			object object_ = method_5(class1661_5, cell_0);
			object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
			if (object_ == null)
			{
				double_4 = 0.0;
			}
			else
			{
				if (object_ is ErrorType)
				{
					return object_;
				}
				double_4 = (double)object_;
			}
		}
		return Class1378.smethod_66(double_, double_2, num, double_3, double_4);
	}

	private object method_25(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_9()[0] == 3)
		{
			Class1661 @class = (Class1661)class1661_0.method_7()[0];
			Class1661 class2 = (Class1661)class1661_0.method_7()[1];
			object obj = @class.Type switch
			{
				Enum180.const_1 => method_39(@class, cell_0), 
				Enum180.const_2 => method_6(@class, cell_0), 
				Enum180.const_3 => method_44(@class, cell_0), 
				_ => null, 
			};
			object obj2 = class2.Type switch
			{
				Enum180.const_1 => method_39(class2, cell_0), 
				Enum180.const_2 => method_6(class2, cell_0), 
				Enum180.const_3 => method_44(class2, cell_0), 
				_ => null, 
			};
			if (cell_0 != null && cell_0.method_4().method_3().method_25())
			{
				if (obj != null && obj is string)
				{
					obj = 0.0;
				}
				if (obj2 != null && obj2 is string)
				{
					obj2 = 0.0;
				}
			}
			return Class1374.smethod_5(workbook_0, obj, obj2, bool_0: true);
		}
		Class1661 class3 = (Class1661)class1661_0.method_7()[0];
		switch (class3.Type)
		{
		default:
			return null;
		case Enum180.const_1:
		{
			object object_ = method_39(class3, cell_0);
			return Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
		}
		case Enum180.const_2:
			return method_6(class3, cell_0);
		case Enum180.const_3:
			return method_44(class3, cell_0);
		}
	}

	private object method_26(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_9()[0] == 4)
		{
			Class1661 @class = (Class1661)class1661_0.method_7()[0];
			Class1661 class2 = (Class1661)class1661_0.method_7()[1];
			return Class1374.smethod_5(object_0: @class.Type switch
			{
				Enum180.const_1 => method_39(@class, cell_0), 
				Enum180.const_2 => method_6(@class, cell_0), 
				Enum180.const_3 => method_44(@class, cell_0), 
				_ => null, 
			}, object_1: class2.Type switch
			{
				Enum180.const_1 => method_39(class2, cell_0), 
				Enum180.const_2 => method_6(class2, cell_0), 
				Enum180.const_3 => method_44(class2, cell_0), 
				_ => null, 
			}, workbook_0: workbook_0, bool_0: false);
		}
		Class1661 class3 = (Class1661)class1661_0.method_7()[0];
		switch (class3.Type)
		{
		default:
			return null;
		case Enum180.const_1:
		{
			object obj = method_39(class3, cell_0);
			if (obj == null)
			{
				return 0.0;
			}
			if (obj is ErrorType)
			{
				return obj;
			}
			switch (Type.GetTypeCode(obj.GetType()))
			{
			case TypeCode.Double:
				return -1.0 * (double)obj;
			case TypeCode.DateTime:
				return -1.0 * CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904);
			default:
				if (obj is object[][])
				{
					object[][] array3 = Class779.smethod_0((object[][])obj);
					foreach (object[] array4 in array3)
					{
						for (int l = 0; l < array4.Length; l++)
						{
							object obj3 = array4[l];
							if (obj3 == null)
							{
								continue;
							}
							switch (Type.GetTypeCode(obj3.GetType()))
							{
							case TypeCode.Double:
								array4[l] = -1.0 * (double)obj3;
								break;
							default:
								array4[l] = ErrorType.Value;
								break;
							case TypeCode.DateTime:
								array4[l] = -1.0 * CellsHelper.GetDoubleFromDateTime((DateTime)obj3, workbook_0.Settings.Date1904);
								break;
							case TypeCode.Boolean:
								if ((bool)obj3)
								{
									array4[l] = -1.0;
								}
								else
								{
									array4[l] = 0.0;
								}
								break;
							}
						}
					}
					return obj;
				}
				return ErrorType.Value;
			case TypeCode.String:
				if (Class1677.smethod_20((string)obj))
				{
					return -1.0 * double.Parse((string)obj);
				}
				return ErrorType.Value;
			case TypeCode.Boolean:
				return ((bool)obj) ? (-1.0) : 0.0;
			}
		}
		case Enum180.const_2:
		{
			object obj = method_6(class3, cell_0);
			if (obj == null)
			{
				return 0.0;
			}
			if (obj is ErrorType)
			{
				return obj;
			}
			switch (Type.GetTypeCode(obj.GetType()))
			{
			case TypeCode.Double:
				return -1.0 * (double)obj;
			case TypeCode.DateTime:
				return -1.0 * CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904);
			default:
				if (obj is object[][] && method_165(class3))
				{
					object[][] array = Class779.smethod_0((object[][])obj);
					foreach (object[] array2 in array)
					{
						for (int j = 0; j < array2.Length; j++)
						{
							object obj2 = array2[j];
							if (obj2 == null)
							{
								continue;
							}
							switch (Type.GetTypeCode(obj2.GetType()))
							{
							case TypeCode.Double:
								array2[j] = -1.0 * (double)obj2;
								break;
							default:
								array2[j] = ErrorType.Value;
								break;
							case TypeCode.DateTime:
								array2[j] = -1.0 * CellsHelper.GetDoubleFromDateTime((DateTime)obj2, workbook_0.Settings.Date1904);
								break;
							case TypeCode.Boolean:
								if ((bool)obj2)
								{
									array2[j] = -1.0;
								}
								else
								{
									array2[j] = 0.0;
								}
								break;
							}
						}
					}
					return obj;
				}
				return ErrorType.Value;
			case TypeCode.String:
				return ErrorType.Value;
			case TypeCode.Boolean:
				if ((bool)obj)
				{
					return -1.0;
				}
				return 0;
			}
		}
		case Enum180.const_3:
		{
			object obj = method_44(class3, cell_0);
			if (obj == null)
			{
				return 0.0;
			}
			if (obj is ErrorType)
			{
				return obj;
			}
			switch (Type.GetTypeCode(obj.GetType()))
			{
			default:
				return ErrorType.Value;
			case TypeCode.String:
				return ErrorType.Value;
			case TypeCode.Double:
				return -1.0 * (double)obj;
			case TypeCode.Boolean:
				if ((bool)obj)
				{
					return -1.0;
				}
				return 0;
			}
		}
		}
	}

	private object method_27(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 @class = (Class1661)class1661_0.method_7()[0];
		Class1661 class2 = (Class1661)class1661_0.method_7()[1];
		object obj = @class.Type switch
		{
			Enum180.const_1 => method_39(@class, cell_0), 
			Enum180.const_2 => method_6(@class, cell_0), 
			Enum180.const_3 => method_44(@class, cell_0), 
			_ => null, 
		};
		object obj2 = class2.Type switch
		{
			Enum180.const_1 => method_39(class2, cell_0), 
			Enum180.const_2 => method_6(class2, cell_0), 
			Enum180.const_3 => method_44(class2, cell_0), 
			_ => null, 
		};
		if (obj == null)
		{
			obj = 0.0;
		}
		else
		{
			if (obj is Array)
			{
				return Class1120.smethod_2(workbook_0, obj, obj2);
			}
			obj = Class1660.smethod_26(obj, workbook_0.Settings.Date1904);
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		if (obj2 == null)
		{
			return 0.0;
		}
		if (obj2 is Array)
		{
			return Class1120.smethod_2(workbook_0, obj, obj2);
		}
		obj2 = Class1660.smethod_26(obj2, workbook_0.Settings.Date1904);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		double num = (double)obj;
		double num2 = (double)obj2;
		double num3 = num * num2;
		if (Math.Abs(num3) < 7.922816251426434E+28)
		{
			return (double)Convert.ToDecimal(num3);
		}
		return num3;
	}

	private object method_28(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 @class = (Class1661)class1661_0.method_7()[0];
		Class1661 class2 = (Class1661)class1661_0.method_7()[1];
		object obj = @class.Type switch
		{
			Enum180.const_1 => method_39(@class, cell_0), 
			Enum180.const_2 => method_6(@class, cell_0), 
			Enum180.const_3 => method_44(@class, cell_0), 
			_ => null, 
		};
		if (obj == null)
		{
			obj = 0.0;
		}
		else if (obj is ErrorType)
		{
			return obj;
		}
		object obj2 = class2.Type switch
		{
			Enum180.const_1 => method_39(class2, cell_0), 
			Enum180.const_2 => method_6(class2, cell_0), 
			Enum180.const_3 => method_44(class2, cell_0), 
			_ => null, 
		};
		if (obj2 == null)
		{
			return ErrorType.Div;
		}
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		if (!(obj is Array) && !(obj2 is Array))
		{
			return Class1374.smethod_7(workbook_0, obj, obj2);
		}
		return Class1120.smethod_3(workbook_0, obj, obj2);
	}

	private object method_29(Class1661 class1661_0, Cell cell_0)
	{
		object[] array = new object[3];
		int num = 0;
		while (true)
		{
			if (num < 3)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num];
				array[num] = method_5(class1661_, cell_0);
				array[num] = Class1660.smethod_26(array[num], workbook_0.Settings.Date1904);
				if (array[num] is ErrorType)
				{
					break;
				}
				switch (Type.GetTypeCode(array[num].GetType()))
				{
				case TypeCode.Double:
					array[num] = (int)Class1179.ToDouble(array[num]);
					break;
				case TypeCode.DateTime:
					switch (num)
					{
					case 0:
						array[0] = ((DateTime)array[0]).Hour;
						break;
					case 1:
						array[1] = ((DateTime)array[1]).Minute;
						break;
					case 2:
						array[2] = ((DateTime)array[2]).Second;
						break;
					}
					break;
				default:
					return ErrorType.Value;
				}
				num++;
				continue;
			}
			int num2 = (int)array[0];
			int num3 = (int)array[1];
			int num4 = (int)array[2];
			num3 += num4 / 60;
			num4 %= 60;
			num2 += num3 / 60;
			num3 %= 60;
			num2 %= 24;
			double num5 = (double)(num2 * 3600 + num3 * 60 + num4) / 86400.0;
			if (num5 < 0.0)
			{
				return ErrorType.Number;
			}
			return num5;
		}
		return array[num];
	}

	private object method_30(Class1661 class1661_0, Cell cell_0)
	{
		int num = 0;
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object object_ = method_5(class1661_, cell_0);
		object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
		if (object_ is ErrorType)
		{
			return object_;
		}
		object obj = null;
		if (class1661_0.method_7().Count == 2)
		{
			obj = method_5((Class1661)class1661_0.method_7()[1], cell_0);
			obj = Class1660.smethod_26(obj, workbook_0.Settings.Date1904);
			if (obj is ErrorType)
			{
				return obj;
			}
		}
		double num2 = (double)object_;
		if (num2 == 0.0)
		{
			return num2;
		}
		if (obj != null)
		{
			num = (int)Class1179.ToDouble(obj);
		}
		if (num == 0)
		{
			if (num2 > 0.0)
			{
				return Math.Floor(num2);
			}
			return Math.Ceiling(num2);
		}
		if (num > 0)
		{
			double d = Math.Abs(num2);
			string text = d.ToString(CultureInfo.InvariantCulture);
			if (text.IndexOf('E') == -1)
			{
				int num3 = text.IndexOf('.');
				if (num3 != -1 && num3 + num < text.Length)
				{
					double num4 = Math.Floor(d);
					double num5 = 10.0;
					for (int i = 1; i <= num; i++)
					{
						num4 += (double)(text[i + num3] - 48) / num5;
						num5 *= 10.0;
					}
					if (num2 > 0.0)
					{
						return num4;
					}
					return 0.0 - num4;
				}
				return num2;
			}
		}
		double num6 = Math.Pow(10.0, num);
		if (num < 0)
		{
			num = 0;
		}
		if (num2 > 0.0)
		{
			return Math.Round(Math.Floor(num2 * num6) / num6, num);
		}
		return Math.Round(Math.Ceiling(num2 * num6) / num6, num);
	}

	private object method_31(Class1661 class1661_0, Cell cell_0, bool bool_3)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return "";
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		if (bool_3)
		{
			return obj.ToString().ToUpper();
		}
		return obj.ToString().ToLower();
	}

	private object method_32(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return "";
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		if (obj is object[][])
		{
			object[][] array = Class779.smethod_0((object[][])obj);
			foreach (object[] array2 in array)
			{
				if (array2 == null)
				{
					continue;
				}
				for (int j = 0; j < array2.Length; j++)
				{
					object obj2 = array2[j];
					if (obj2 != null)
					{
						array2[j] = obj2.ToString().Trim();
					}
				}
			}
			return array;
		}
		obj = Class1660.smethod_24(obj);
		if (obj is ErrorType)
		{
			return obj;
		}
		return Class1253.smethod_0((string)obj);
	}

	private object method_33(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return 0.0;
		}
		switch (Type.GetTypeCode(obj.GetType()))
		{
		case TypeCode.String:
		{
			string text = obj.ToString().Replace(",", null);
			if (text != null && !(text == ""))
			{
				obj = Class1677.smethod_38(text, bool_0: true);
				if (obj is string)
				{
					return ErrorType.Value;
				}
				return obj;
			}
			return ErrorType.Value;
		}
		default:
			return obj;
		case TypeCode.Boolean:
			return ErrorType.Value;
		}
	}

	private object method_34(Class1661 class1661_0, Worksheet worksheet_0, Cell cell_0, int int_3, int int_4)
	{
		string key;
		Cell cell;
		object obj;
		if (class1661_0 != null && class1661_0.method_5() != null && (key = class1661_0.method_5().method_3()) != null)
		{
			if (Class1742.dictionary_86 == null)
			{
				Class1742.dictionary_86 = new Dictionary<string, int>(13)
				{
					{ "CELL", 0 },
					{ "COLUMN", 1 },
					{ "COLUMNS", 2 },
					{ "ROWS", 3 },
					{ "CONCATENATE", 4 },
					{ "COUNT", 5 },
					{ "COUNTA", 6 },
					{ "IF", 7 },
					{ "ROW", 8 },
					{ "ISBLANK", 9 },
					{ "OFFSET", 10 },
					{ ":", 11 },
					{ "GETPIVOTDATA", 12 }
				};
			}
			if (Class1742.dictionary_86.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					if (class1661_0.method_5().method_7()[1] == class1661_0)
					{
						Struct87 struct3 = default(Struct87);
						struct3.cellArea_0.StartRow = (struct3.cellArea_0.EndRow = int_3);
						struct3.cellArea_0.StartColumn = (struct3.cellArea_0.EndColumn = int_4);
						struct3.int_1 = worksheet_0.Index;
						return struct3;
					}
					cell = worksheet_0.Cells.GetCell(int_3, int_4, bool_2: false);
					method_38(cell_0, cell);
					if (cell.method_20() == Enum199.const_7)
					{
						return null;
					}
					return method_211(cell);
				case 1:
					return (double)(int_4 + 1);
				case 2:
				case 3:
					return 1.0;
				case 4:
					cell = worksheet_0.Cells.GetCell(int_3, int_4, bool_2: false);
					method_38(cell_0, cell);
					return method_211(cell);
				case 5:
				case 6:
					cell = worksheet_0.Cells.GetCell(int_3, int_4, bool_2: false);
					method_38(cell_0, cell);
					obj = method_211(cell);
					if (obj == null)
					{
						return 0.0;
					}
					if (class1661_0.method_5().method_3() == "COUNTA")
					{
						return 1.0;
					}
					if (Type.GetTypeCode(obj.GetType()) == TypeCode.Double)
					{
						return 1.0;
					}
					return 0.0;
				case 7:
					if (class1661_0.method_5().method_5() != null && class1661_0.method_5().method_7()[0] != class1661_0 && class1661_0.method_5().method_5().method_3() == "SUM")
					{
						Struct87 struct2 = default(Struct87);
						struct2.cellArea_0.StartRow = int_3;
						struct2.cellArea_0.EndRow = int_3;
						struct2.cellArea_0.StartColumn = int_4;
						struct2.cellArea_0.EndColumn = int_4;
						struct2.int_1 = worksheet_0.Index;
						struct2.int_0 = workbook_0.Worksheets.method_36();
						struct2.worksheet_0 = worksheet_0;
						return struct2;
					}
					cell = worksheet_0.Cells.CheckCell(int_3, int_4);
					if (cell == null)
					{
						return null;
					}
					method_38(cell_0, cell);
					return method_211(cell);
				case 8:
					return (double)(int_3 + 1);
				case 9:
				{
					cell = worksheet_0.Cells.GetCell(int_3, int_4, bool_2: false);
					method_38(cell_0, cell);
					Enum199 @enum = cell.method_20();
					if (@enum == Enum199.const_7)
					{
						return null;
					}
					return method_211(cell);
				}
				case 10:
				case 11:
				{
					Struct87 struct4 = default(Struct87);
					struct4.cellArea_0.StartRow = int_3;
					struct4.cellArea_0.EndRow = int_3;
					struct4.cellArea_0.StartColumn = int_4;
					struct4.cellArea_0.EndColumn = int_4;
					struct4.int_1 = worksheet_0.Index;
					struct4.int_0 = workbook_0.Worksheets.method_36();
					struct4.worksheet_0 = worksheet_0;
					return struct4;
				}
				case 12:
					if (class1661_0.method_5().method_7()[1] == class1661_0)
					{
						Struct87 @struct = default(Struct87);
						@struct.cellArea_0.StartRow = int_3;
						@struct.cellArea_0.EndRow = int_3;
						@struct.cellArea_0.StartColumn = int_4;
						@struct.cellArea_0.EndColumn = int_4;
						@struct.int_1 = worksheet_0.Index;
						@struct.int_0 = workbook_0.Worksheets.method_36();
						@struct.worksheet_0 = worksheet_0;
						return @struct;
					}
					cell = worksheet_0.Cells.GetCell(int_3, int_4, bool_2: false);
					method_38(cell_0, cell);
					if (cell.method_20() == Enum199.const_7)
					{
						return null;
					}
					return method_211(cell);
				}
			}
		}
		cell = worksheet_0.Cells.GetCell(int_3, int_4, bool_2: false);
		method_38(cell_0, cell);
		if (cell.method_20() == Enum199.const_7)
		{
			return null;
		}
		obj = method_211(cell);
		if (bool_2 && cell.IsFormula && cell.method_62() && cell_0 != null && !cell_0.method_62())
		{
			string key2 = cell_0.method_4().method_3().Name + "!" + cell_0.Name;
			Class1376 @class = new Class1376();
			Class1661 class1661_ = workbook_0.Worksheets.Formula.method_10(cell_0);
			@class.class1661_0 = class1661_;
			@class.int_0 = 1;
			@class.object_0 = cell_0.Value;
			@class.bool_0 = false;
			@class.int_1 = hashtable_2.Count;
			@class.cell_0 = cell_0;
			cell_0.method_63(bool_0: true);
			method_212()[key2] = @class;
			arrayList_1.Add(@class);
		}
		return obj;
	}

	private object method_35(Class1661 class1661_0, Worksheet worksheet_0, Cell cell_0, int int_3, int int_4, int int_5, int int_6)
	{
		double[][] array = new double[int_4 - int_3 + 1][];
		for (int i = 0; i <= int_4 - int_3; i++)
		{
			array[i] = new double[int_6 - int_5 + 1];
		}
		for (int j = int_3; j <= int_4; j++)
		{
			Row row = worksheet_0.Cells.Rows.method_3(j);
			if (row == null)
			{
				continue;
			}
			for (int k = int_5; k <= int_6; k++)
			{
				Cell cellOrNull = row.GetCellOrNull(k);
				if (cellOrNull != null)
				{
					object obj = method_211(cellOrNull);
					if (obj != null)
					{
						if (!(obj is ErrorType))
						{
							switch (Type.GetTypeCode(obj.GetType()))
							{
							case TypeCode.Double:
								array[j - int_3][k - int_5] = (double)obj;
								break;
							case TypeCode.DateTime:
								array[j - int_3][k - int_5] = CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904);
								break;
							default:
								return ErrorType.Value;
							}
							continue;
						}
						return obj;
					}
					return ErrorType.Value;
				}
				return ErrorType.Value;
			}
		}
		return array;
	}

	private object method_36(Class1661 class1661_0, Worksheet worksheet_0, Cell cell_0, int int_3, int int_4, int int_5, int int_6, bool bool_3)
	{
		double[][] array = new double[int_4 - int_3 + 1][];
		for (int i = 0; i <= int_4 - int_3; i++)
		{
			array[i] = new double[int_6 - int_5 + 1];
		}
		for (int j = int_3; j <= int_4; j++)
		{
			Row row = worksheet_0.Cells.Rows.method_3(j);
			if (row == null)
			{
				continue;
			}
			for (int k = int_5; k <= int_6; k++)
			{
				Cell cellOrNull = row.GetCellOrNull(k);
				if (cellOrNull == null)
				{
					continue;
				}
				object obj = method_211(cellOrNull);
				if (array == null)
				{
					array[j - int_3][k - int_5] = 0.0;
					continue;
				}
				if (bool_3 || !(obj is ErrorType))
				{
					if (!(obj is double))
					{
						array[j - int_3][k - int_5] = 0.0;
					}
					else
					{
						array[j - int_3][k - int_5] = (double)obj;
					}
					continue;
				}
				return obj;
			}
		}
		return array;
	}

	internal object method_37(Class1661 class1661_0, Worksheet worksheet_0, Cell cell_0, int int_3, int int_4, int int_5, int int_6)
	{
		string text;
		if (class1661_0.method_5() != null && cell_0 != null && !cell_0.IsInArray && (text = class1661_0.method_5().method_3()) != null && text == "TYPE" && int_3 != int_4)
		{
			if (int_5 != int_6)
			{
				return ErrorType.Value;
			}
			if (cell_0.Row >= int_3 && cell_0.Row <= int_4)
			{
				return method_34(class1661_0, worksheet_0, cell_0, cell_0.Row, int_5);
			}
			return ErrorType.Value;
		}
		return method_4(worksheet_0.Index, int_3, int_5, int_4, int_6, bool_3: true, bool_4: true, bool_5: true)?.object_0;
	}

	private object CalculateRange(Class1661 class1661_0, Worksheet worksheet_0, Cell cell_0, int int_3, int int_4, int int_5, int int_6, bool bool_3)
	{
		return CalculateRange(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6, bool_3, bool_4: false);
	}

	private object CalculateRange(Class1661 class1661_0, Worksheet worksheet_0, Cell cell_0, int int_3, int int_4, int int_5, int int_6, bool bool_3, bool bool_4)
	{
		bool flag = false;
		if (!bool_3)
		{
			bool_3 = cell_0?.IsInArray ?? false;
		}
		if (!bool_3)
		{
			flag = Class1672.smethod_0(class1661_0, bool_4);
		}
		if (flag)
		{
			if (bool_0)
			{
				return method_34(class1661_0, worksheet_0, cell_0, int_3, int_5);
			}
			int[] array = Class1672.smethod_1(cell_0, int_3, int_5, int_4, int_6);
			if (array != null)
			{
				return method_34(class1661_0, worksheet_0, cell_0, array[0], array[1]);
			}
			return ErrorType.Value;
		}
		bool flag2 = true;
		double num = 0.0;
		int endRow = int_4;
		int endColumn = int_6;
		if (int_3 > int_4)
		{
			int num2 = int_3;
			int_3 = int_4;
			int_4 = num2;
		}
		if (int_5 > int_6)
		{
			int num3 = int_5;
			int_5 = int_6;
			int_6 = num3;
		}
		if (enum47_0 == Enum47.const_0)
		{
			worksheet_0.Workbook.class1382_0.AddRange(cell_0, worksheet_0, int_5, int_3, int_6, int_4);
		}
		if (class1661_0.method_5() == null)
		{
			return method_37(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6);
		}
		string key;
		if ((key = class1661_0.method_5().method_3()) != null)
		{
			if (Class1742.dictionary_87 == null)
			{
				Class1742.dictionary_87 = new Dictionary<string, int>(47)
				{
					{ "COLUMN", 0 },
					{ "COLUMNS", 1 },
					{ "CONCATENATE", 2 },
					{ "DATE", 3 },
					{ "IF", 4 },
					{ "AND", 5 },
					{ "OR", 6 },
					{ "INDEX", 7 },
					{ "VLOOKUP", 8 },
					{ "HLOOKUP", 9 },
					{ "MATCH", 10 },
					{ "LOOKUP", 11 },
					{ "OFFSET", 12 },
					{ "SUMIF", 13 },
					{ "COUNTIF", 14 },
					{ "AVERAGEIF", 15 },
					{ "SUMIFS", 16 },
					{ "_xlfn.SUMIFS", 17 },
					{ "COUNTIFS", 18 },
					{ "_xlfn.COUNTIFS", 19 },
					{ "AVERAGEIFS", 20 },
					{ "_xlfn.AVERAGEIFS", 21 },
					{ "ROW", 22 },
					{ "ROWS", 23 },
					{ "SUBTOTAL", 24 },
					{ "SUMPRODUCT", 25 },
					{ "LOGEST", 26 },
					{ "MCORRELS", 27 },
					{ "REGRESSN", 28 },
					{ "PEARSON", 29 },
					{ "RSQ", 30 },
					{ "FREQUENCY", 31 },
					{ "LINEST", 32 },
					{ "SMALL", 33 },
					{ "AVERAGE", 34 },
					{ "AVERAGEA", 35 },
					{ "COUNT", 36 },
					{ "COUNTA", 37 },
					{ "MIN", 38 },
					{ "MINA", 39 },
					{ "MAX", 40 },
					{ "MAXA", 41 },
					{ "SUM", 42 },
					{ " ", 43 },
					{ ",", 44 },
					{ ":", 45 },
					{ "GETPIVOTDATA", 46 }
				};
			}
			if (Class1742.dictionary_87.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return (double)(int_5 + 1);
				case 1:
					return (double)(int_6 - int_5 + 1);
				case 2:
					return ErrorType.Value;
				case 3:
					return ErrorType.Value;
				case 4:
					if (!bool_3 && !cell_0.IsInArray)
					{
						if (class1661_0.method_5().method_9()[0] == 34 && class1661_0.method_5().method_5() != null)
						{
							Class1661 @class = class1661_0.method_5().method_5();
							string text;
							if ((text = @class.method_3()) != null && text == "SUMIF")
							{
								if (@class.method_7()[1] != class1661_0)
								{
									int_4 = ((worksheet_0.Cells.method_20(0) < int_4) ? worksheet_0.Cells.method_20(0) : int_4);
									Struct87 struct8 = default(Struct87);
									struct8.cellArea_0.StartRow = int_3;
									struct8.cellArea_0.EndRow = int_4;
									struct8.cellArea_0.StartColumn = int_5;
									struct8.cellArea_0.EndColumn = int_6;
									struct8.int_1 = worksheet_0.Index;
									return struct8;
								}
								return method_37(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6);
							}
						}
						return ErrorType.Value;
					}
					return method_37(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6);
				case 5:
				{
					for (int k = int_3; k <= int_4; k++)
					{
						for (int l = int_5; l <= int_6; l++)
						{
							Cell cell = worksheet_0.Cells.CheckCell(k, l);
							if (cell == null)
							{
								continue;
							}
							object obj = method_211(cell);
							if (obj == null)
							{
								continue;
							}
							if (Type.GetTypeCode(obj.GetType()) == TypeCode.Double)
							{
								num = (double)obj;
								if (!(Math.Abs(num) >= double.Epsilon))
								{
									return false;
								}
								flag2 = false;
							}
							if (Type.GetTypeCode(obj.GetType()) == TypeCode.Boolean)
							{
								if (!(bool)obj)
								{
									return false;
								}
								flag2 = false;
							}
						}
					}
					if (!flag2)
					{
						return true;
					}
					return null;
				}
				case 6:
				{
					for (int i = int_3; i <= int_4; i++)
					{
						for (int j = int_5; j <= int_6; j++)
						{
							Cell cell = worksheet_0.Cells.CheckCell(i, j);
							if (cell == null)
							{
								continue;
							}
							object obj = method_211(cell);
							if (obj == null)
							{
								continue;
							}
							if (Type.GetTypeCode(obj.GetType()) == TypeCode.Double)
							{
								num = (double)obj;
								if (!(Math.Abs(num) < double.Epsilon))
								{
									return true;
								}
								flag2 = false;
							}
							if (Type.GetTypeCode(obj.GetType()) == TypeCode.Boolean)
							{
								if ((bool)obj)
								{
									return true;
								}
								flag2 = false;
							}
						}
					}
					if (!flag2)
					{
						return false;
					}
					return null;
				}
				case 7:
					if (class1661_0.method_5().method_7()[0] == class1661_0)
					{
						Struct87 struct2 = default(Struct87);
						struct2.cellArea_0.StartRow = int_3;
						struct2.cellArea_0.EndRow = int_4;
						struct2.cellArea_0.StartColumn = int_5;
						struct2.cellArea_0.EndColumn = int_6;
						struct2.int_1 = worksheet_0.Index;
						return struct2;
					}
					return method_37(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6);
				case 8:
				case 9:
				case 10:
					if (class1661_0.method_5().method_7()[1] == class1661_0)
					{
						Struct87 struct4 = default(Struct87);
						struct4.cellArea_0.StartRow = int_3;
						struct4.cellArea_0.EndRow = int_4;
						struct4.cellArea_0.StartColumn = int_5;
						struct4.cellArea_0.EndColumn = int_6;
						struct4.int_1 = worksheet_0.Index;
						return struct4;
					}
					return method_37(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6);
				case 11:
					if (class1661_0.method_5().method_7().Count > 2 && class1661_0.method_5().method_7()[2] == class1661_0)
					{
						Struct87 struct10 = default(Struct87);
						struct10.cellArea_0.StartRow = int_3;
						struct10.cellArea_0.EndRow = endRow;
						struct10.cellArea_0.StartColumn = int_5;
						struct10.cellArea_0.EndColumn = endColumn;
						struct10.int_1 = worksheet_0.Index;
						return struct10;
					}
					return method_37(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6);
				case 12:
				{
					Struct87 struct9 = default(Struct87);
					struct9.cellArea_0.StartRow = int_3;
					struct9.cellArea_0.EndRow = int_4;
					struct9.cellArea_0.StartColumn = int_5;
					struct9.cellArea_0.EndColumn = int_6;
					struct9.int_1 = worksheet_0.Index;
					struct9.int_0 = workbook_0.Worksheets.method_36();
					return struct9;
				}
				case 13:
				case 14:
				case 15:
					if (class1661_0.method_5().method_7()[1] != class1661_0)
					{
						int_4 = ((worksheet_0.Cells.method_20(0) < int_4) ? worksheet_0.Cells.method_20(0) : int_4);
						Struct87 struct6 = default(Struct87);
						struct6.cellArea_0.StartRow = int_3;
						struct6.cellArea_0.EndRow = int_4;
						struct6.cellArea_0.StartColumn = int_5;
						struct6.cellArea_0.EndColumn = int_6;
						struct6.int_1 = worksheet_0.Index;
						return struct6;
					}
					return method_37(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6);
				case 16:
				case 17:
				case 18:
				case 19:
				case 20:
				case 21:
				{
					Struct87 struct5 = default(Struct87);
					struct5.cellArea_0.StartRow = int_3;
					struct5.cellArea_0.EndRow = ((worksheet_0.Cells.method_20(0) < int_4) ? worksheet_0.Cells.method_20(0) : int_4);
					struct5.cellArea_0.StartColumn = int_5;
					struct5.cellArea_0.EndColumn = int_6;
					struct5.int_1 = worksheet_0.Index;
					return struct5;
				}
				case 22:
					if (cell_0 != null && cell_0.IsInArray)
					{
						object[][] array2 = new object[int_4 - int_3 + 1][];
						for (int m = 0; m < array2.Length; m++)
						{
							array2[m] = new object[1] { (double)(int_3 + m + 1) };
						}
						return array2;
					}
					return (double)(int_3 + 1);
				case 23:
					return (double)(int_4 - int_3 + 1);
				case 24:
					if (class1661_0.method_5().method_7()[0] != class1661_0)
					{
						Struct87 struct7 = default(Struct87);
						struct7.cellArea_0.StartRow = int_3;
						struct7.cellArea_0.StartColumn = int_5;
						struct7.cellArea_0.EndRow = int_4;
						struct7.cellArea_0.EndColumn = int_6;
						struct7.int_1 = worksheet_0.Index;
						return struct7;
					}
					return method_37(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6);
				case 25:
					return method_36(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6, bool_3: false);
				case 26:
				case 27:
				case 28:
				case 29:
				case 30:
					return method_36(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6, bool_3: true);
				case 31:
					if (int_4 > method_1(worksheet_0.Index))
					{
						int_4 = method_1(worksheet_0.Index);
						if (int_4 < int_3)
						{
							int_3 = int_4;
						}
					}
					return method_36(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6, bool_3: true);
				case 32:
					return method_35(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6);
				case 33:
				case 34:
				case 35:
				case 36:
				case 37:
				case 38:
				case 39:
				case 40:
				case 41:
					if (int_4 > method_1(worksheet_0.Index))
					{
						int_4 = method_1(worksheet_0.Index);
						if (int_4 < int_3)
						{
							int_3 = int_4;
						}
					}
					return method_37(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6);
				case 42:
				case 43:
				case 44:
				case 45:
				{
					Struct87 struct3 = default(Struct87);
					struct3.cellArea_0.StartRow = int_3;
					struct3.cellArea_0.EndRow = int_4;
					struct3.cellArea_0.StartColumn = int_5;
					struct3.cellArea_0.EndColumn = int_6;
					struct3.int_1 = worksheet_0.Index;
					struct3.worksheet_0 = worksheet_0;
					return struct3;
				}
				case 46:
					if (class1661_0.method_5().method_7()[1] == class1661_0)
					{
						Struct87 @struct = default(Struct87);
						@struct.cellArea_0.StartRow = int_3;
						@struct.cellArea_0.EndRow = int_4;
						@struct.cellArea_0.StartColumn = int_5;
						@struct.cellArea_0.EndColumn = int_6;
						@struct.int_1 = worksheet_0.Index;
						@struct.worksheet_0 = worksheet_0;
						return @struct;
					}
					return method_37(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6);
				}
			}
		}
		return method_37(class1661_0, worksheet_0, cell_0, int_3, int_4, int_5, int_6);
	}

	internal void method_38(Cell cell_0, Cell cell_1)
	{
		if (enum47_0 == Enum47.const_0)
		{
			cell_1.method_0(cell_0);
		}
	}

	private object method_39(Class1661 class1661_0, Cell cell_0)
	{
		switch (class1661_0.method_9()[0])
		{
		case 58:
		case 90:
		case 122:
		{
			int num = BitConverter.ToUInt16(class1661_0.method_9(), 1);
			if (num >= workbook_0.Worksheets.method_32().Count)
			{
				return ErrorType.Ref;
			}
			Class1246 @class = workbook_0.Worksheets.method_32()[num];
			int ushort_ = @class.ushort_0;
			int ushort_2 = @class.ushort_1;
			int int_5 = BitConverter.ToInt32(class1661_0.method_9(), 3);
			int int_6 = Class1268.smethod_1(class1661_0.method_9(), 7);
			if (ushort_ != workbook_0.Worksheets.method_36())
			{
				return Class1377.smethod_3(workbook_0.Worksheets, ushort_, ushort_2, int_5, int_6);
			}
			if (ushort_2 != -1 && ushort_2 < workbook_0.Worksheets.Count)
			{
				if (@class.ushort_1 != @class.ushort_2 && class1661_0.method_5() != null && class1661_0.method_5().method_3() == "SUM")
				{
					object[][] array = new object[1][] { new object[@class.ushort_2 - @class.ushort_1 + 1] };
					for (int i = @class.ushort_1; i <= @class.ushort_2; i++)
					{
						array[0][i - @class.ushort_1] = method_34(class1661_0, workbook_0.Worksheets[i], cell_0, int_5, int_6);
					}
					return array;
				}
				return method_34(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, int_5, int_6);
			}
			return ErrorType.Ref;
		}
		case 59:
		case 91:
		case 123:
		{
			int num = BitConverter.ToUInt16(class1661_0.method_9(), 1);
			if (num >= workbook_0.Worksheets.method_32().Count)
			{
				return ErrorType.Ref;
			}
			Class1246 class2 = workbook_0.Worksheets.method_32()[num];
			int ushort_3 = class2.ushort_0;
			int ushort_2 = class2.ushort_1;
			int int_ = BitConverter.ToInt32(class1661_0.method_9(), 3);
			int int_2 = BitConverter.ToInt32(class1661_0.method_9(), 7);
			int int_3 = Class1268.smethod_1(class1661_0.method_9(), 11);
			int int_4 = Class1268.smethod_1(class1661_0.method_9(), 13);
			if (ushort_3 != workbook_0.Worksheets.method_36())
			{
				return Class1377.smethod_2(class1661_0, ushort_3, workbook_0.Worksheets, ushort_2, int_, int_3, int_2, int_4, hashtable_0, null);
			}
			if (ushort_2 >= 0 && ushort_2 < workbook_0.Worksheets.Count)
			{
				if (class2.ushort_1 != class2.ushort_2 && class1661_0.method_5() != null && class1661_0.method_5().method_3() == "SUM")
				{
					object[][] array3 = new object[1][] { new object[class2.ushort_2 - class2.ushort_1 + 1] };
					for (int j = class2.ushort_1; j <= class2.ushort_2; j++)
					{
						array3[0][j - class2.ushort_1] = method_37(class1661_0.method_5(), workbook_0.Worksheets[j], cell_0, int_, int_2, int_3, int_4);
					}
					return array3;
				}
				return CalculateRange(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, int_, int_2, int_3, int_4, bool_3: false);
			}
			return ErrorType.Ref;
		}
		case 57:
		case 89:
		case 105:
		{
			int num = BitConverter.ToUInt16(class1661_0.method_9(), 1);
			ushort num9 = BitConverter.ToUInt16(class1661_0.method_9(), 3);
			int num10 = workbook_0.Worksheets.method_32().method_12(num);
			int ushort_2 = workbook_0.Worksheets.method_32().method_13(num);
			if (num10 != workbook_0.Worksheets.method_36())
			{
				return Class1377.smethod_1(class1661_0, workbook_0.Worksheets, num10, ushort_2, num9 - 1, bool_0: true, hashtable_0);
			}
			if (ushort_2 == -1)
			{
				return ErrorType.Ref;
			}
			if (ushort_2 >= workbook_0.Worksheets.Count)
			{
				num = 0;
			}
			Name name2 = workbook_0.Worksheets.Names[num9 - 1];
			int int_ = 0;
			int int_2 = 0;
			int int_3 = 0;
			int int_4 = 0;
			int[] array5 = null;
			array5 = ((cell_0 == null) ? name2.GetCellArea(0, 0, bool_0: false) : name2.GetCellArea(cell_0.Row, cell_0.Column, bool_0: false));
			if (array5 != null)
			{
				num = array5[0];
				int_ = array5[1];
				int_3 = array5[2];
				int_2 = array5[3];
				int_4 = array5[4];
				ushort_2 = workbook_0.Worksheets.method_32().method_13(num);
				if (int_ == int_2 && int_3 == int_4)
				{
					return method_34(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, int_, int_3);
				}
				return CalculateRange(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, int_, int_2, int_3, int_4, bool_3: false);
			}
			if (name2.RefersTo != null && !(name2.RefersTo == "") && !(name2.RefersTo == "="))
			{
				try
				{
					Class1661 class1661_2 = workbook_0.Worksheets.Formula.method_9(name2, cell_0);
					return method_5(class1661_2, cell_0);
				}
				catch (Exception ex2)
				{
					if (class1661_0.method_5() == null || !(class1661_0.method_5().method_3() == "ISERROR"))
					{
						throw (CellsException)ex2;
					}
					return ErrorType.NA;
				}
			}
			return ErrorType.NA;
		}
		case 23:
		{
			int num2 = BitConverter.ToUInt16(class1661_0.method_9(), 1);
			if (num2 == 0)
			{
				return "";
			}
			return Encoding.Unicode.GetString(class1661_0.method_9(), 3, num2 * 2);
		}
		case 24:
			if (class1661_0.method_9()[1] == 25)
			{
				int num5 = 0;
				byte[] array4 = class1661_0.method_9();
				int num6 = 0;
				int num7 = 0;
				if (cell_0 != null)
				{
					num6 = cell_0.Row;
					num7 = cell_0.Column;
				}
				int[] range = Class1689.GetRange(workbook_0.Worksheets, array4, num5, num6, num7);
				if (range == null)
				{
					return ErrorType.Ref;
				}
				int num = range[0];
				int int_7 = range[1];
				int num8 = range[2];
				int int_8 = range[3];
				int int_9 = range[4];
				int ushort_2 = workbook_0.Worksheets.method_32().method_13(num);
				if ((array4[num5 + 5] & 8u) != 0)
				{
					return CalculateRange(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, int_7, int_8, num8, num8, bool_3: true);
				}
				if (Class1660.smethod_7(class1661_0))
				{
					return method_34(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, cell_0.Row, num8);
				}
				return CalculateRange(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, int_7, int_8, num8, int_9, bool_3: false);
			}
			if (class1661_0.method_9()[1] == 29)
			{
				int int_10 = BitConverter.ToInt32(class1661_0.method_9(), 2);
				if (workbook_0.Worksheets.method_2() != null)
				{
					return ((Class1149)workbook_0.Worksheets.method_2()).method_136(int_10);
				}
			}
			return ErrorType.Ref;
		case 28:
			return Class1673.smethod_5(class1661_0.method_9()[1]);
		case 29:
			if (class1661_0.method_9()[1] == 0)
			{
				return false;
			}
			return true;
		case 30:
		{
			if (class1661_0.method_5() == null)
			{
				return (double)(int)BitConverter.ToUInt16(class1661_0.method_9(), 1);
			}
			string text2;
			if ((text2 = class1661_0.method_5().method_3()) != null && text2 == "COUNT")
			{
				return 1.0;
			}
			return (double)(int)BitConverter.ToUInt16(class1661_0.method_9(), 1);
		}
		case 31:
		{
			if (class1661_0.method_5() == null)
			{
				return BitConverter.ToDouble(class1661_0.method_9(), 1);
			}
			string text;
			if ((text = class1661_0.method_5().method_3()) != null && text == "COUNT")
			{
				return 1.0;
			}
			return BitConverter.ToDouble(class1661_0.method_9(), 1);
		}
		case 32:
		case 64:
		case 96:
			if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
			{
				return class1661_0.method_7()[0];
			}
			return null;
		case 35:
		case 67:
		case 99:
		{
			if (workbook_0.Worksheets.Names.Count == 0)
			{
				return null;
			}
			ushort num3 = BitConverter.ToUInt16(class1661_0.method_9(), 1);
			Name name = workbook_0.Worksheets.Names[num3 - 1];
			int num = 0;
			int int_ = 0;
			int int_2 = 0;
			int int_3 = 0;
			int int_4 = 0;
			int[] array2 = null;
			array2 = ((cell_0 == null) ? name.GetCellArea(0, 0, bool_0: false) : name.GetCellArea(cell_0.Row, cell_0.Column, bool_0: false));
			if (array2 != null)
			{
				num = array2[0];
				int_ = array2[1];
				int_3 = array2[2];
				int_2 = array2[3];
				int_4 = array2[4];
				int num4 = workbook_0.Worksheets.method_32().method_12(num);
				int ushort_2 = workbook_0.Worksheets.method_32().method_13(num);
				if (ushort_2 >= 0 && ushort_2 < 65535)
				{
					if (num4 == workbook_0.Worksheets.method_36())
					{
						if (int_ == int_2 && int_3 == int_4)
						{
							return method_34(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, int_, int_3);
						}
						if (class1661_0.method_9()[0] == 67 && cell_0 != null && !cell_0.IsInArray)
						{
							try
							{
								if (int_ == int_2)
								{
									if (cell_0.Column <= int_4 && cell_0.Column >= int_3)
									{
										return method_34(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, int_, cell_0.Column);
									}
								}
								else if (int_3 == int_4 && cell_0.Row <= int_2 && cell_0.Row >= int_)
								{
									return method_34(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, cell_0.Row, int_3);
								}
							}
							catch (Exception ex)
							{
								throw new CellsException(ExceptionType.Formula, ex.Message);
							}
						}
						return CalculateRange(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, int_, int_2, int_3, int_4, bool_3: false);
					}
					if (int_ == int_2 && int_3 == int_4)
					{
						return Class1377.smethod_3(workbook_0.Worksheets, num4, ushort_2, int_, int_3);
					}
					return Class1377.smethod_2(class1661_0, num4, workbook_0.Worksheets, ushort_2, int_, int_3, int_2, int_4, hashtable_0, null);
				}
				return ErrorType.Ref;
			}
			if (name.RefersTo != null && !(name.RefersTo == "") && !(name.RefersTo == "="))
			{
				Class1661 class1661_ = workbook_0.Worksheets.Formula.method_9(name, cell_0);
				object obj = method_5(class1661_, null);
				if (obj is Struct87 struct3)
				{
					int ushort_2 = struct3.int_1;
					int_ = struct3.cellArea_0.StartRow;
					int_3 = struct3.cellArea_0.StartColumn;
					int_2 = struct3.cellArea_0.EndRow;
					int_4 = struct3.cellArea_0.EndColumn;
					if (int_ == int_2 && int_3 == int_4)
					{
						return method_34(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, int_, int_3);
					}
					if (class1661_0.method_9()[0] == 67 && cell_0 != null && !cell_0.IsInArray)
					{
						if (int_ == int_2)
						{
							if (cell_0.Column <= int_4 && cell_0.Column >= int_3)
							{
								return method_34(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, int_, cell_0.Column);
							}
						}
						else if (int_3 == int_4 && cell_0.Row <= int_2 && cell_0.Row >= int_)
						{
							return method_34(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, cell_0.Row, int_3);
						}
					}
					return CalculateRange(class1661_0, workbook_0.Worksheets[ushort_2], cell_0, int_, int_2, int_3, int_4, bool_3: false);
				}
				return obj;
			}
			return ErrorType.Name;
		}
		case 36:
		case 68:
		case 100:
		{
			int int_5 = BitConverter.ToInt32(class1661_0.method_9(), 1);
			int int_6 = Class1268.smethod_1(class1661_0.method_9(), 5);
			if (class1661_0.method_5() != null)
			{
				switch (class1661_0.method_5().method_3())
				{
				case "ROWS":
				case "COLUMNS":
					return 1.0;
				case "IF":
					if (class1661_0.method_5() != null && class1661_0.method_5().method_5() != null && class1661_0.method_5().method_5().method_3() == "SUM")
					{
						Struct87 struct2 = default(Struct87);
						struct2.cellArea_0.StartRow = int_5;
						struct2.cellArea_0.EndRow = int_5;
						struct2.cellArea_0.StartColumn = int_6;
						struct2.cellArea_0.EndColumn = int_6;
						struct2.int_1 = cell_0.method_4().method_3().SheetIndex;
						return struct2;
					}
					break;
				case "OFFSET":
				case ":":
				{
					Struct87 @struct = default(Struct87);
					@struct.cellArea_0.StartRow = int_5;
					@struct.cellArea_0.EndRow = int_5;
					@struct.cellArea_0.StartColumn = int_6;
					@struct.cellArea_0.EndColumn = int_6;
					@struct.int_1 = cell_0.method_4().method_3().SheetIndex;
					return @struct;
				}
				}
			}
			return method_34(class1661_0, cell_0.method_4().method_3(), cell_0, int_5, int_6);
		}
		case 37:
		case 69:
		case 101:
		{
			method_182(class1661_0.method_9(), 1, out var int_, out var int_3, out var int_2, out var int_4);
			return CalculateRange(class1661_0, cell_0.method_4().method_3(), cell_0, int_, int_2, int_3, int_4, class1661_0.method_9()[0] == 101);
		}
		default:
			return null;
		case 42:
		case 43:
		case 60:
		case 61:
		case 74:
		case 75:
		case 92:
		case 93:
		case 106:
		case 107:
		case 124:
		case 125:
			return ErrorType.Ref;
		case 44:
		case 76:
		case 108:
		{
			int int_5 = Class1268.smethod_2(class1661_0.method_9(), 1, cell_0.Row, class1661_0.method_9()[6]);
			int int_6 = Class1268.smethod_6(class1661_0.method_9(), 5, cell_0.Column, class1661_0.method_9()[6]);
			return method_34(class1661_0, cell_0.method_4().method_3(), cell_0, int_5, int_6);
		}
		case 45:
		case 77:
		case 109:
		{
			int int_ = Class1268.smethod_2(class1661_0.method_9(), 1, cell_0.Row, class1661_0.method_9()[10]);
			int int_2 = Class1268.smethod_2(class1661_0.method_9(), 5, cell_0.Row, class1661_0.method_9()[12]);
			int int_3 = Class1268.smethod_6(class1661_0.method_9(), 9, cell_0.Column, class1661_0.method_9()[10]);
			int int_4 = Class1268.smethod_6(class1661_0.method_9(), 11, cell_0.Column, class1661_0.method_9()[12]);
			return CalculateRange(class1661_0, cell_0.method_4().method_3(), cell_0, int_, int_2, int_3, int_4, bool_3: false);
		}
		}
	}

	private object method_40(Class1661 class1661_0, Cell cell_0)
	{
		object object_ = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		return Class1122.Calculate(object_);
	}

	private object method_41(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj == null)
		{
			return ErrorType.Value;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		string text = obj.ToString();
		if (text.Length == 0)
		{
			return ErrorType.Value;
		}
		return (double)(int)text[0];
	}

	private object method_42(Class1661 class1661_0, Cell cell_0)
	{
		object object_ = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		return Class1121.Calculate(object_);
	}

	private object method_43(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj == null)
		{
			return ErrorType.Value;
		}
		object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
		if (!(obj2 is Struct87))
		{
			return ErrorType.Value;
		}
		object[] array = new object[class1661_0.method_7().Count - 2];
		int num = 2;
		object obj3;
		while (true)
		{
			if (num < class1661_0.method_7().Count)
			{
				obj3 = method_5((Class1661)class1661_0.method_7()[num], cell_0);
				if (obj3 != null)
				{
					if (obj3 is ErrorType)
					{
						break;
					}
					array[num - 2] = obj3;
					num++;
					continue;
				}
				return ErrorType.Value;
			}
			Struct87 @struct = (Struct87)obj2;
			return @struct.worksheet_0.PivotTables.method_1(@struct.cellArea_0.StartRow, @struct.cellArea_0.StartColumn, obj.ToString(), array);
		}
		return obj3;
	}

	private object method_44(Class1661 class1661_0, Cell cell_0)
	{
		string key;
		if ((key = class1661_0.method_3()) != null)
		{
			if (Class1742.dictionary_88 == null)
			{
				Class1742.dictionary_88 = new Dictionary<string, int>(354)
				{
					{ "ABS", 0 },
					{ "ACCRINT", 1 },
					{ "ACCRINTM", 2 },
					{ "ADDRESS", 3 },
					{ "AND", 4 },
					{ "ACOS", 5 },
					{ "ACOSH", 6 },
					{ "AMORDEGRC", 7 },
					{ "AMORLINC", 8 },
					{ "AREAS", 9 },
					{ "ASIN", 10 },
					{ "ASINH", 11 },
					{ "ATAN", 12 },
					{ "ATAN2", 13 },
					{ "ATANH", 14 },
					{ "AVEDEV", 15 },
					{ "AVERAGE", 16 },
					{ "AVERAGEA", 17 },
					{ "AVERAGEIF", 18 },
					{ "_xlfn.AVERAGEIF", 19 },
					{ "AVERAGEIFS", 20 },
					{ "_xlfn.AVERAGEIFS", 21 },
					{ "BESSELI", 22 },
					{ "BESSELJ", 23 },
					{ "BESSELK", 24 },
					{ "BESSELY", 25 },
					{ "BIN2DEC", 26 },
					{ "BIN2HEX", 27 },
					{ "BIN2OCT", 28 },
					{ "DEC2BIN", 29 },
					{ "DEC2HEX", 30 },
					{ "DEC2OCT", 31 },
					{ "BETADIST", 32 },
					{ "BETAINV", 33 },
					{ "BINOMDIST", 34 },
					{ "CELL", 35 },
					{ "CEILING", 36 },
					{ "CHAR", 37 },
					{ "CHIDIST", 38 },
					{ "CHIINV", 39 },
					{ "CHITEST", 40 },
					{ "CHOOSE", 41 },
					{ "CLEAN", 42 },
					{ "CODE", 43 },
					{ "COLUMN", 44 },
					{ "ROW", 45 },
					{ "COLUMNS", 46 },
					{ "ROWS", 47 },
					{ "COMBIN", 48 },
					{ "COMPLEX", 49 },
					{ "CONCATENATE", 50 },
					{ "CONFIDENCE", 51 },
					{ "CONVERT", 52 },
					{ "CORREL", 53 },
					{ "COS", 54 },
					{ "COSH", 55 },
					{ "COUNT", 56 },
					{ "COUNTA", 57 },
					{ "COUNTBLANK", 58 },
					{ "COUNTIF", 59 },
					{ "COUNTIFS", 60 },
					{ "_xlfn.COUNTIFS", 61 },
					{ "COUPDAYBS", 62 },
					{ "COUPDAYS", 63 },
					{ "COUPDAYSNC", 64 },
					{ "COUPNCD", 65 },
					{ "COUPNUM", 66 },
					{ "COUPPCD", 67 },
					{ "CUMIPMT", 68 },
					{ "CUMPRINC", 69 },
					{ "COVAR", 70 },
					{ "CRITBINOM", 71 },
					{ "DCOUNTA", 72 },
					{ "DAVERAGE", 73 },
					{ "DCOUNT", 74 },
					{ "DGET", 75 },
					{ "DMAX", 76 },
					{ "DMIN", 77 },
					{ "DPRODUCT", 78 },
					{ "DSTDEV", 79 },
					{ "DSTDEVP", 80 },
					{ "DSUM", 81 },
					{ "DVAR", 82 },
					{ "DVARP", 83 },
					{ "DATEVALUE", 84 },
					{ "DATEDIF", 85 },
					{ "DATE", 86 },
					{ "DAY", 87 },
					{ "DAYS360", 88 },
					{ "DB", 89 },
					{ "DEGREES", 90 },
					{ "DELTA", 91 },
					{ "DEVSQ", 92 },
					{ "DDB", 93 },
					{ "DISC", 94 },
					{ "DOLLAR", 95 },
					{ "USDOLLAR", 96 },
					{ "DOLLARFR", 97 },
					{ "DOLLARDE", 98 },
					{ "DURATION", 99 },
					{ "EDATE", 100 },
					{ "EFFECT", 101 },
					{ "EOMONTH", 102 },
					{ "ERF", 103 },
					{ "ERFC", 104 },
					{ "ERROR.TYPE", 105 },
					{ "EXACT", 106 },
					{ "EXP", 107 },
					{ "EXPONDIST", 108 },
					{ "EVEN", 109 },
					{ "FACT", 110 },
					{ "FACTDOUBLE", 111 },
					{ "FALSE", 112 },
					{ "FDIST", 113 },
					{ "FREQUENCY", 114 },
					{ "FIND", 115 },
					{ "FINDB", 116 },
					{ "FINV", 117 },
					{ "FISHER", 118 },
					{ "FISHERINV", 119 },
					{ "FIXED", 120 },
					{ "FLOOR", 121 },
					{ "FORECAST", 122 },
					{ "FV", 123 },
					{ "FVSCHEDULE", 124 },
					{ "GAMMADIST", 125 },
					{ "GAMMAINV", 126 },
					{ "GAMMALN", 127 },
					{ "GCD", 128 },
					{ "GETPIVOTDATA", 129 },
					{ "GEOMEAN", 130 },
					{ "GESTEP", 131 },
					{ "GROWTH", 132 },
					{ "HARMEAN", 133 },
					{ "HEX2BIN", 134 },
					{ "HEX2DEC", 135 },
					{ "HEX2OCT", 136 },
					{ "HLOOKUP", 137 },
					{ "HYPERLINK", 138 },
					{ "HYPGEOMDIST", 139 },
					{ "IF", 140 },
					{ "IMABS", 141 },
					{ "IMAGINARY", 142 },
					{ "IMARGUMENT", 143 },
					{ "IMCONJUGATE", 144 },
					{ "IMCOS", 145 },
					{ "IMDIV", 146 },
					{ "IMEXP", 147 },
					{ "IMLN", 148 },
					{ "IMLOG10", 149 },
					{ "IMLOG2", 150 },
					{ "IMPOWER", 151 },
					{ "IMREAL", 152 },
					{ "IMSIN", 153 },
					{ "IMSQRT", 154 },
					{ "IMSUB", 155 },
					{ "IMPRODUCT", 156 },
					{ "IMSUM", 157 },
					{ "INDEX", 158 },
					{ "INDIRECT", 159 },
					{ "INT", 160 },
					{ "INTERCEPT", 161 },
					{ "INTRATE", 162 },
					{ "IPMT", 163 },
					{ "IRR", 164 },
					{ "ISERR", 165 },
					{ "ISEVEN", 166 },
					{ "ISERROR", 167 },
					{ "IFERROR", 168 },
					{ "_xlfn.IFERROR", 169 },
					{ "ISNA", 170 },
					{ "ISNONTEXT", 171 },
					{ "ISLOGICAL", 172 },
					{ "ISNUMBER", 173 },
					{ "ISBLANK", 174 },
					{ "ISODD", 175 },
					{ "ISPMT", 176 },
					{ "ISREF", 177 },
					{ "ISTEXT", 178 },
					{ "KURT", 179 },
					{ "LARGE", 180 },
					{ "LCM", 181 },
					{ "LEFT", 182 },
					{ "LEFTB", 183 },
					{ "LEN", 184 },
					{ "LENB", 185 },
					{ "LINEST", 186 },
					{ "LN", 187 },
					{ "LOG", 188 },
					{ "LOG10", 189 },
					{ "LOGEST", 190 },
					{ "LOGINV", 191 },
					{ "LOGNORMDIST", 192 },
					{ "LOOKUP", 193 },
					{ "LOWER", 194 },
					{ "MATCH", 195 },
					{ "MAX", 196 },
					{ "MAXA", 197 },
					{ "MCORRELS", 198 },
					{ "MDETERM", 199 },
					{ "MDURATION", 200 },
					{ "MID", 201 },
					{ "MIDB", 202 },
					{ "MIN", 203 },
					{ "MINA", 204 },
					{ "MINVERSE", 205 },
					{ "MIRR", 206 },
					{ "MMULT", 207 },
					{ "MOD", 208 },
					{ "MODE", 209 },
					{ "MONTH", 210 },
					{ "MEDIAN", 211 },
					{ "MROUND", 212 },
					{ "MULTINOMIAL", 213 },
					{ "N", 214 },
					{ "NA", 215 },
					{ "NEGBINOMDIST", 216 },
					{ "NETWORKDAYS", 217 },
					{ "NETWORKDAYS.INTL", 218 },
					{ "NOT", 219 },
					{ "NOW", 220 },
					{ "NOMINAL", 221 },
					{ "NORMINV", 222 },
					{ "NORMSINV", 223 },
					{ "NORMDIST", 224 },
					{ "NORMSDIST", 225 },
					{ "NPER", 226 },
					{ "NPV", 227 },
					{ "OCT2BIN", 228 },
					{ "OCT2DEC", 229 },
					{ "OCT2HEX", 230 },
					{ "ODD", 231 },
					{ "ODDFPRICE", 232 },
					{ "ODDFYIELD", 233 },
					{ "ODDLPRICE", 234 },
					{ "ODDLYIELD", 235 },
					{ "OFFSET", 236 },
					{ "OR", 237 },
					{ "PEARSON", 238 },
					{ "PERCENTRANK", 239 },
					{ "PERCENTILE", 240 },
					{ "PERMUT", 241 },
					{ "PI", 242 },
					{ "POISSON", 243 },
					{ "POWER", 244 },
					{ "PRICE", 245 },
					{ "PRICEDISC", 246 },
					{ "PRICEMAT", 247 },
					{ "PROB", 248 },
					{ "PRODUCT", 249 },
					{ "PROPER", 250 },
					{ "PMT", 251 },
					{ "PPMT", 252 },
					{ "PV", 253 },
					{ "QUOTIENT", 254 },
					{ "QUARTILE", 255 },
					{ "RADIANS", 256 },
					{ "RAND", 257 },
					{ "RANDBETWEEN", 258 },
					{ "RANK", 259 },
					{ "RATE", 260 },
					{ "RECEIVED", 261 },
					{ "REGRESSN", 262 },
					{ "REPLACE", 263 },
					{ "REPLACEB", 264 },
					{ "REPT", 265 },
					{ "RIGHT", 266 },
					{ "RIGHTB", 267 },
					{ "ROMAN", 268 },
					{ "ROUND", 269 },
					{ "ROUNDDOWN", 270 },
					{ "ROUNDUP", 271 },
					{ "RSQ", 272 },
					{ "SEARCH", 273 },
					{ "SEARCHB", 274 },
					{ "SERIESSUM", 275 },
					{ "SIGN", 276 },
					{ "SIN", 277 },
					{ "SINH", 278 },
					{ "SKEW", 279 },
					{ "SLN", 280 },
					{ "SLOPE", 281 },
					{ "SMALL", 282 },
					{ "SQRT", 283 },
					{ "SQRTPI", 284 },
					{ "STANDARDIZE", 285 },
					{ "STDEV", 286 },
					{ "STDEV.S", 287 },
					{ "_xlfn.STDEV.S", 288 },
					{ "STDEVA", 289 },
					{ "STDEVP", 290 },
					{ "STDEV.P", 291 },
					{ "_xlfn.STDEV.P", 292 },
					{ "STDEVPA", 293 },
					{ "STEYX", 294 },
					{ "SUBSTITUTE", 295 },
					{ "SUBTOTAL", 296 },
					{ "SUM", 297 },
					{ "SUMIF", 298 },
					{ "SUMIFS", 299 },
					{ "_xlfn.SUMIFS", 300 },
					{ "SUMPRODUCT", 301 },
					{ "SUMSQ", 302 },
					{ "SUMX2MY2", 303 },
					{ "SUMX2PY2", 304 },
					{ "SUMXMY2", 305 },
					{ "SYD", 306 },
					{ "T", 307 },
					{ "TBILLEQ", 308 },
					{ "TBILLPRICE", 309 },
					{ "TBILLYIELD", 310 },
					{ "TAN", 311 },
					{ "TANH", 312 },
					{ "TDIST", 313 },
					{ "TEXT", 314 },
					{ "TIME", 315 },
					{ "TIMEVALUE", 316 },
					{ "TINV", 317 },
					{ "TRANSPOSE", 318 },
					{ "TRIM", 319 },
					{ "TRIMMEAN", 320 },
					{ "TREND", 321 },
					{ "TRUE", 322 },
					{ "TRUNC", 323 },
					{ "TTEST", 324 },
					{ "TODAY", 325 },
					{ "TYPE", 326 },
					{ "SECOND", 327 },
					{ "MINUTE", 328 },
					{ "HOUR", 329 },
					{ "UPPER", 330 },
					{ "VALUE", 331 },
					{ "VAR", 332 },
					{ "VARA", 333 },
					{ "VARP", 334 },
					{ "VARPA", 335 },
					{ "VDB", 336 },
					{ "VLOOKUP", 337 },
					{ "WEEKDAY", 338 },
					{ "WEEKNUM", 339 },
					{ "WORKDAY", 340 },
					{ "WORKDAY.INTL", 341 },
					{ "XIRR", 342 },
					{ "XINTZINSFUSS", 343 },
					{ "XNPV", 344 },
					{ "XKAPITALWERT", 345 },
					{ "YEAR", 346 },
					{ "YIELD", 347 },
					{ "YIELDDISC", 348 },
					{ "YIELDMAT", 349 },
					{ "BRTEILJAHRE", 350 },
					{ "YEARFRAC", 351 },
					{ "WEIBULL", 352 },
					{ "ZTEST", 353 }
				};
			}
			if (Class1742.dictionary_88.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return method_207(class1661_0, cell_0);
				case 1:
				case 2:
					return method_190(class1661_0, cell_0);
				case 3:
					return method_208(class1661_0, cell_0);
				case 4:
					return method_173(class1661_0, cell_0);
				case 5:
					return method_177(class1661_0, cell_0);
				case 6:
					return method_198(class1661_0, cell_0);
				case 7:
				case 8:
					return method_194(class1661_0, cell_0);
				case 9:
					return method_106(class1661_0, cell_0);
				case 10:
					return method_178(class1661_0, cell_0);
				case 11:
					return method_197(class1661_0, cell_0);
				case 12:
					return method_200(class1661_0, cell_0);
				case 13:
					return method_201(class1661_0, cell_0);
				case 14:
					return method_199(class1661_0, cell_0);
				case 15:
					return method_185(class1661_0, cell_0, bool_3: false, bool_4: false, bool_5: false, bool_6: false);
				case 16:
				case 17:
					return method_174(class1661_0, cell_0);
				case 18:
				case 19:
					return method_146(class1661_0, cell_0);
				case 20:
				case 21:
					return method_150(class1661_0, cell_0);
				case 22:
				case 23:
				case 24:
				case 25:
				case 26:
				case 27:
				case 28:
				case 29:
				case 30:
				case 31:
					return method_194(class1661_0, cell_0);
				case 32:
					return method_64(class1661_0, cell_0);
				case 33:
					return method_65(class1661_0, cell_0);
				case 34:
					return method_62(class1661_0, cell_0);
				case 35:
					return method_169(class1661_0, cell_0);
				case 36:
					return method_172(class1661_0, cell_0);
				case 37:
					return method_170(class1661_0, cell_0);
				case 38:
					return method_68(class1661_0, cell_0);
				case 39:
					return method_69(class1661_0, cell_0);
				case 40:
					return method_133(class1661_0, cell_0, 2);
				case 41:
					return method_171(class1661_0, cell_0);
				case 42:
					return method_42(class1661_0, cell_0);
				case 43:
					return method_41(class1661_0, cell_0);
				case 44:
				case 45:
					return method_167(class1661_0, cell_0);
				case 46:
				case 47:
					return method_166(class1661_0, cell_0);
				case 48:
					return method_194(class1661_0, cell_0);
				case 49:
					return method_188(class1661_0, cell_0);
				case 50:
					return method_164(class1661_0, cell_0);
				case 51:
					return method_194(class1661_0, cell_0);
				case 52:
					return method_189(class1661_0, cell_0);
				case 53:
					return method_120(class1661_0, cell_0);
				case 54:
					return method_175(class1661_0, cell_0);
				case 55:
					return method_180(class1661_0, cell_0);
				case 56:
					return method_161(class1661_0, cell_0);
				case 57:
					return method_162(class1661_0, cell_0);
				case 58:
					return method_163(class1661_0, cell_0);
				case 59:
					return method_148(class1661_0, cell_0);
				case 60:
				case 61:
					return method_149(class1661_0, cell_0);
				case 62:
				case 63:
				case 64:
				case 65:
				case 66:
				case 67:
				case 68:
				case 69:
					return method_194(class1661_0, cell_0);
				case 70:
					return method_23(class1661_0, cell_0, 2);
				case 71:
					return method_194(class1661_0, cell_0);
				case 72:
					return method_20(class1661_0, cell_0, bool_3: true);
				case 73:
				case 74:
				case 75:
				case 76:
				case 77:
				case 78:
				case 79:
				case 80:
				case 81:
				case 82:
				case 83:
					return method_20(class1661_0, cell_0, bool_3: false);
				case 84:
					return method_110(class1661_0, cell_0);
				case 85:
					return method_112(class1661_0, cell_0);
				case 86:
					return method_113(class1661_0, cell_0);
				case 87:
					return method_56(class1661_0, cell_0, 0);
				case 88:
					return method_114(class1661_0, cell_0);
				case 89:
					return method_187(class1661_0, cell_0);
				case 90:
				case 91:
					return method_194(class1661_0, cell_0);
				case 92:
					return method_185(class1661_0, cell_0, bool_3: true, bool_4: true, bool_5: true, bool_6: false);
				case 93:
					return method_24(class1661_0, cell_0);
				case 94:
					return method_194(class1661_0, cell_0);
				case 95:
				case 96:
					return method_115(class1661_0, cell_0);
				case 97:
				case 98:
					return method_194(class1661_0, cell_0);
				case 99:
					return method_194(class1661_0, cell_0);
				case 100:
					return method_53(class1661_0, cell_0, class1661_0.method_3());
				case 101:
					return method_194(class1661_0, cell_0);
				case 102:
					return method_13(class1661_0, cell_0);
				case 103:
				case 104:
					return method_194(class1661_0, cell_0);
				case 105:
					return method_107(class1661_0, cell_0);
				case 106:
					return method_14(class1661_0, cell_0);
				case 107:
					return method_203(class1661_0, cell_0);
				case 108:
					return method_63(class1661_0, cell_0);
				case 109:
					return method_194(class1661_0, cell_0);
				case 110:
					return method_194(class1661_0, cell_0);
				case 111:
					return method_194(class1661_0, cell_0);
				case 112:
					return false;
				case 113:
					return method_70(class1661_0, cell_0);
				case 114:
					return method_139(class1661_0, cell_0);
				case 115:
					return method_88(class1661_0, cell_0, bool_3: false);
				case 116:
					return method_88(class1661_0, cell_0, bool_3: true);
				case 117:
					return method_71(class1661_0, cell_0);
				case 118:
				case 119:
					return method_194(class1661_0, cell_0);
				case 120:
					return method_57(class1661_0, cell_0);
				case 121:
					return method_58(class1661_0, cell_0);
				case 122:
					return method_141(class1661_0, cell_0);
				case 123:
					return method_59(class1661_0, cell_0);
				case 124:
					return method_21(class1661_0, cell_0);
				case 125:
					return method_60(class1661_0, cell_0);
				case 126:
					return method_61(class1661_0, cell_0);
				case 127:
					return method_194(class1661_0, cell_0);
				case 128:
					return method_119(class1661_0, cell_0);
				case 129:
					return method_43(class1661_0, cell_0);
				case 130:
					return method_140(class1661_0, cell_0);
				case 131:
					return method_194(class1661_0, cell_0);
				case 132:
					return method_137(class1661_0, cell_0);
				case 133:
					return method_185(class1661_0, cell_0, bool_3: true, bool_4: true, bool_5: true, bool_6: false);
				case 134:
				case 135:
				case 136:
					return method_193(class1661_0, cell_0, 1);
				case 137:
					return Class1125.smethod_0(this, class1661_0, cell_0);
				case 138:
					return method_91(class1661_0, cell_0);
				case 139:
					return method_194(class1661_0, cell_0);
				case 140:
					return method_94(class1661_0, cell_0);
				case 141:
				case 142:
				case 143:
				case 144:
				case 145:
					return method_193(class1661_0, cell_0, 1);
				case 146:
					return method_193(class1661_0, cell_0, 2);
				case 147:
				case 148:
				case 149:
				case 150:
				case 151:
				case 152:
				case 153:
				case 154:
					return method_193(class1661_0, cell_0, 1);
				case 155:
					return method_193(class1661_0, cell_0, 2);
				case 156:
				case 157:
					return method_191(class1661_0, cell_0, 255);
				case 158:
					return method_95(class1661_0, cell_0);
				case 159:
					return method_96(class1661_0, cell_0);
				case 160:
					return method_98(class1661_0, cell_0);
				case 161:
					return method_22(class1661_0, cell_0, 2);
				case 162:
					return method_194(class1661_0, cell_0);
				case 163:
					return method_99(class1661_0, cell_0);
				case 164:
					return method_100(class1661_0, cell_0);
				case 165:
					return method_103(class1661_0, cell_0);
				case 166:
					return method_107(class1661_0, cell_0);
				case 167:
					return method_101(class1661_0, cell_0);
				case 168:
				case 169:
					return method_102(class1661_0, cell_0);
				case 170:
					return method_104(class1661_0, cell_0);
				case 171:
				case 172:
					return method_107(class1661_0, cell_0);
				case 173:
					return method_105(class1661_0, cell_0);
				case 174:
					return method_109(class1661_0, cell_0);
				case 175:
					return method_107(class1661_0, cell_0);
				case 176:
					return method_194(class1661_0, cell_0);
				case 177:
					return method_108(class1661_0, cell_0);
				case 178:
					return method_107(class1661_0, cell_0);
				case 179:
					return method_185(class1661_0, cell_0, bool_3: true, bool_4: true, bool_5: true, bool_6: false);
				case 180:
					return method_181(class1661_0, cell_0, bool_3: false);
				case 181:
					return method_119(class1661_0, cell_0);
				case 182:
					return method_85(class1661_0, cell_0, bool_3: false);
				case 183:
					return method_85(class1661_0, cell_0, bool_3: true);
				case 184:
					return method_84(class1661_0, cell_0, bool_3: false);
				case 185:
					return method_84(class1661_0, cell_0, bool_3: true);
				case 186:
					return method_134(class1661_0, cell_0);
				case 187:
					return method_204(class1661_0, cell_0);
				case 188:
					return method_194(class1661_0, cell_0);
				case 189:
					return method_205(class1661_0, cell_0);
				case 190:
					return method_130(class1661_0, cell_0);
				case 191:
				case 192:
					return method_194(class1661_0, cell_0);
				case 193:
					return method_92(class1661_0, cell_0);
				case 194:
					return method_31(class1661_0, cell_0, bool_3: false);
				case 195:
					return method_83(class1661_0, cell_0);
				case 196:
					return method_77(class1661_0, cell_0);
				case 197:
					return method_79(class1661_0, cell_0);
				case 198:
					return method_118(class1661_0, cell_0);
				case 199:
					return method_133(class1661_0, cell_0, 1);
				case 200:
					return method_194(class1661_0, cell_0);
				case 201:
					return method_87(class1661_0, cell_0, bool_3: false);
				case 202:
					return method_87(class1661_0, cell_0, bool_3: true);
				case 203:
					return method_78(class1661_0, cell_0);
				case 204:
					return method_80(class1661_0, cell_0);
				case 205:
					return method_133(class1661_0, cell_0, 1);
				case 206:
					return method_23(class1661_0, cell_0, 1);
				case 207:
					return method_133(class1661_0, cell_0, 2);
				case 208:
					return method_81(class1661_0, cell_0);
				case 209:
					return method_40(class1661_0, cell_0);
				case 210:
					return method_56(class1661_0, cell_0, 1);
				case 211:
					return method_119(class1661_0, cell_0);
				case 212:
					return method_82(class1661_0, cell_0);
				case 213:
					return method_185(class1661_0, cell_0, bool_3: true, bool_4: true, bool_5: true, bool_6: false);
				case 214:
					return method_107(class1661_0, cell_0);
				case 215:
					return ErrorType.NA;
				case 216:
					return method_194(class1661_0, cell_0);
				case 217:
					return method_54(class1661_0, cell_0);
				case 218:
					return method_54(class1661_0, cell_0);
				case 219:
					return method_151(class1661_0, cell_0);
				case 220:
					return DateTime.Now;
				case 221:
					return method_194(class1661_0, cell_0);
				case 222:
					return method_152(class1661_0, cell_0);
				case 223:
					return method_156(class1661_0, cell_0);
				case 224:
					return method_154(class1661_0, cell_0);
				case 225:
					return method_155(class1661_0, cell_0);
				case 226:
					return method_160(class1661_0, cell_0);
				case 227:
					return method_157(class1661_0, cell_0);
				case 228:
				case 229:
				case 230:
				case 231:
					return method_194(class1661_0, cell_0);
				case 232:
				case 233:
				case 234:
				case 235:
					return method_194(class1661_0, cell_0);
				case 236:
					return method_75(class1661_0, cell_0);
				case 237:
					return method_76(class1661_0, cell_0);
				case 238:
					return method_121(class1661_0, cell_0);
				case 239:
					return method_23(class1661_0, cell_0, 1);
				case 240:
					return method_122(class1661_0, cell_0);
				case 241:
					return method_194(class1661_0, cell_0);
				case 242:
					return Math.PI;
				case 243:
					return method_153(class1661_0, cell_0);
				case 244:
					return method_16(class1661_0, cell_0);
				case 245:
				case 246:
				case 247:
					return method_194(class1661_0, cell_0);
				case 248:
					return method_131(class1661_0, cell_0);
				case 249:
					return method_124(class1661_0, cell_0);
				case 250:
					return method_73(class1661_0, cell_0);
				case 251:
					return method_159(class1661_0, cell_0);
				case 252:
					return method_123(class1661_0, cell_0);
				case 253:
					return method_158(class1661_0, cell_0);
				case 254:
					return method_194(class1661_0, cell_0);
				case 255:
					return method_126(class1661_0, cell_0);
				case 256:
					return method_194(class1661_0, cell_0);
				case 257:
				{
					Random random = new Random();
					return random.NextDouble();
				}
				case 258:
					return method_194(class1661_0, cell_0);
				case 259:
					return method_127(class1661_0, cell_0);
				case 260:
					return method_128(class1661_0, cell_0);
				case 261:
					return method_194(class1661_0, cell_0);
				case 262:
					return method_129(class1661_0, cell_0);
				case 263:
					return method_90(class1661_0, cell_0, bool_3: false);
				case 264:
					return method_90(class1661_0, cell_0, bool_3: true);
				case 265:
					return method_74(class1661_0, cell_0);
				case 266:
					return method_86(class1661_0, cell_0, bool_3: false);
				case 267:
					return method_86(class1661_0, cell_0, bool_3: true);
				case 268:
					return method_194(class1661_0, cell_0);
				case 269:
					return method_72(class1661_0, cell_0, 0);
				case 270:
					return method_72(class1661_0, cell_0, -1);
				case 271:
					return method_72(class1661_0, cell_0, 1);
				case 272:
					return method_125(class1661_0, cell_0);
				case 273:
					return method_89(class1661_0, cell_0, bool_3: false);
				case 274:
					return method_89(class1661_0, cell_0, bool_3: true);
				case 275:
					return method_19(class1661_0, cell_0);
				case 276:
					return method_206(class1661_0, cell_0);
				case 277:
					return method_176(class1661_0, cell_0);
				case 278:
					return method_179(class1661_0, cell_0);
				case 279:
					return method_185(class1661_0, cell_0, bool_3: true, bool_4: true, bool_5: true, bool_6: false);
				case 280:
					return method_17(class1661_0, cell_0);
				case 281:
					return method_22(class1661_0, cell_0, 2);
				case 282:
					return method_181(class1661_0, cell_0, bool_3: true);
				case 283:
					return method_202(class1661_0, cell_0);
				case 284:
					return method_194(class1661_0, cell_0);
				case 285:
					return method_194(class1661_0, cell_0);
				case 286:
				case 287:
				case 288:
					return method_142(class1661_0, cell_0);
				case 289:
					return method_185(class1661_0, cell_0, bool_3: false, bool_4: false, bool_5: true, bool_6: false);
				case 290:
				case 291:
				case 292:
					return method_143(class1661_0, cell_0);
				case 293:
					return method_185(class1661_0, cell_0, bool_3: false, bool_4: false, bool_5: true, bool_6: false);
				case 294:
					return method_23(class1661_0, cell_0, 2);
				case 295:
					return method_184(class1661_0, cell_0);
				case 296:
					return method_183(class1661_0, cell_0);
				case 297:
					return method_145(class1661_0, cell_0);
				case 298:
					return method_146(class1661_0, cell_0);
				case 299:
				case 300:
					return method_147(class1661_0, cell_0);
				case 301:
					return method_138(class1661_0, cell_0);
				case 302:
					return method_185(class1661_0, cell_0, bool_3: true, bool_4: true, bool_5: true, bool_6: false);
				case 303:
				case 304:
				case 305:
					return method_23(class1661_0, cell_0, 2);
				case 306:
					return method_18(class1661_0, cell_0);
				case 307:
					return method_192(class1661_0, cell_0);
				case 308:
				case 309:
				case 310:
					return method_194(class1661_0, cell_0);
				case 311:
					return method_195(class1661_0, cell_0);
				case 312:
					return method_196(class1661_0, cell_0);
				case 313:
					return method_66(class1661_0, cell_0);
				case 314:
					return method_46(class1661_0, cell_0);
				case 315:
					return method_29(class1661_0, cell_0);
				case 316:
					return method_111(class1661_0, cell_0);
				case 317:
					return method_67(class1661_0, cell_0);
				case 318:
					return method_135(class1661_0, cell_0);
				case 319:
					return method_32(class1661_0, cell_0);
				case 320:
					return method_23(class1661_0, cell_0, 1);
				case 321:
					return method_136(class1661_0, cell_0);
				case 322:
					return true;
				case 323:
					return method_30(class1661_0, cell_0);
				case 324:
					return method_132(class1661_0, cell_0);
				case 325:
					return DateTime.Today;
				case 326:
					return method_107(class1661_0, cell_0);
				case 327:
					return method_56(class1661_0, cell_0, 3);
				case 328:
					return method_56(class1661_0, cell_0, 4);
				case 329:
					return method_56(class1661_0, cell_0, 5);
				case 330:
					return method_31(class1661_0, cell_0, bool_3: true);
				case 331:
					return method_33(class1661_0, cell_0);
				case 332:
					return method_185(class1661_0, cell_0, bool_3: true, bool_4: true, bool_5: true, bool_6: false);
				case 333:
					return method_185(class1661_0, cell_0, bool_3: false, bool_4: false, bool_5: true, bool_6: false);
				case 334:
					return method_185(class1661_0, cell_0, bool_3: true, bool_4: true, bool_5: true, bool_6: false);
				case 335:
					return method_185(class1661_0, cell_0, bool_3: false, bool_4: false, bool_5: true, bool_6: false);
				case 336:
					return method_186(class1661_0, cell_0);
				case 337:
					return Class1126.Calculate(this, class1661_0, cell_0);
				case 338:
					return method_50(class1661_0, cell_0);
				case 339:
					return method_55(class1661_0, cell_0);
				case 340:
					return method_53(class1661_0, cell_0, "WORKDAY");
				case 341:
					return method_53(class1661_0, cell_0, "WORKDAY.INTL");
				case 342:
				case 343:
					return method_47(class1661_0, cell_0);
				case 344:
				case 345:
					return method_48(class1661_0, cell_0);
				case 346:
					return method_56(class1661_0, cell_0, 2);
				case 347:
				case 348:
				case 349:
					return method_194(class1661_0, cell_0);
				case 350:
				case 351:
					return method_49(class1661_0, cell_0);
				case 352:
					return method_194(class1661_0, cell_0);
				case 353:
					return method_23(class1661_0, cell_0, 1);
				}
			}
		}
		if (icustomFunction_0 == null)
		{
			return ErrorType.Name;
		}
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		arrayList2.Add(workbook_0);
		arrayList2.Add(cell_0.method_4().method_3());
		arrayList2.Add(cell_0);
		ArrayList arrayList3 = new ArrayList();
		ReferredAreaCollection referredAreaCollection = new ReferredAreaCollection(bool_1: false);
		method_45(class1661_0, cell_0, arrayList, arrayList3, referredAreaCollection);
		arrayList2.Add(arrayList3);
		arrayList2.Add(referredAreaCollection);
		object obj = icustomFunction_0.CalculateCustomFunction(class1661_0.method_3(), arrayList, arrayList2);
		if (obj != null)
		{
			if (obj is string)
			{
				bool isError = false;
				ErrorType errorType = Class1673.smethod_3((string)obj, out isError);
				if (isError)
				{
					return errorType;
				}
			}
			else if (obj is int)
			{
				obj = (double)(int)obj;
			}
			else if (obj is object[])
			{
				if (!(obj is object[][]))
				{
					obj = new object[1] { obj };
				}
			}
			else if (obj is Range)
			{
				Range range = (Range)obj;
				CellArea area = range.Area;
				obj = CalculateRange(class1661_0, range.Worksheet, cell_0, area.StartRow, area.EndRow, area.StartColumn, area.EndColumn, cell_0?.IsInArray ?? false, bool_4: true);
			}
		}
		return obj;
	}

	private void method_45(Class1661 class1661_0, Cell cell_0, ArrayList arrayList_3, ArrayList arrayList_4, ReferredAreaCollection referredAreaCollection_0)
	{
		if (class1661_0.method_7() == null)
		{
			return;
		}
		for (int i = 0; i < class1661_0.method_7().Count; i++)
		{
			Class1661 @class = (Class1661)class1661_0.method_7()[i];
			object obj = method_5(@class, cell_0);
			if (obj != null && obj is ErrorType)
			{
				obj = Class1673.smethod_4((ErrorType)obj);
			}
			arrayList_3.Add(obj);
			StringBuilder stringBuilder = new StringBuilder();
			workbook_0.Worksheets.method_4().method_5(stringBuilder, @class, cell_0.Row, cell_0.Column, bool_0: false);
			arrayList_4.Add(stringBuilder.ToString());
			if (@class.method_9() != null)
			{
				int count = referredAreaCollection_0.Count;
				Class1674.GetPrecedents(@class.method_9(), 0, @class.method_9().Length - 1, cell_0.Row, cell_0.Column, workbook_0.Worksheets, cell_0.method_4(), referredAreaCollection_0, bool_0: false, null, cell_0.method_4().method_3().Name);
				if (referredAreaCollection_0.Count == count)
				{
					referredAreaCollection_0.method_0(null);
				}
			}
			else
			{
				referredAreaCollection_0.method_0(null);
			}
		}
	}

	private object method_46(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object obj = method_5(class1661_, cell_0);
			if (obj == null)
			{
				obj = 0.0;
			}
			else if (obj is ErrorType)
			{
				return obj;
			}
			bool flag = true;
			switch (Type.GetTypeCode(obj.GetType()))
			{
			case TypeCode.DateTime:
				flag = false;
				goto case TypeCode.Double;
			default:
				return obj.ToString();
			case TypeCode.String:
			{
				string text2 = (string)obj;
				Class530 @class = Class1345.smethod_0(text2, workbook_0.Settings);
				if (@class != null)
				{
					obj = @class.Value;
					flag = @class.method_1() != CellValueType.IsDateTime;
					goto case TypeCode.Double;
				}
				return text2;
			}
			case TypeCode.Double:
			{
				class1661_ = (Class1661)class1661_0.method_7()[1];
				object obj2 = method_5(class1661_, cell_0);
				if (obj2 == null)
				{
					return "";
				}
				if (obj2 is ErrorType)
				{
					return obj2;
				}
				string text = null;
				TypeCode typeCode = Type.GetTypeCode(obj2.GetType());
				if (typeCode != TypeCode.Boolean)
				{
					switch (typeCode)
					{
					default:
						return obj2.ToString();
					case TypeCode.String:
						text = (string)obj2;
						break;
					case TypeCode.Double:
						text = obj2.ToString();
						break;
					}
					if (Regex.IsMatch(text, Class1386.string_1, RegexOptions.IgnoreCase) && flag)
					{
						switch (text)
						{
						case "[h]":
						case "[H]":
							return (double)(int)((double)obj * 24.0);
						}
						if ((double)obj < 0.0)
						{
							return ErrorType.Value;
						}
						obj = CellsHelper.GetDateTimeFromDouble((double)obj, workbook_0.Settings.Date1904);
						flag = false;
					}
					if (flag)
					{
						text = Class1345.smethod_1(text, workbook_0.Settings);
					}
					return Class1345.Format(obj, text, workbook_0.Settings).StringValue;
				}
				return ErrorType.Value;
			}
			case TypeCode.Boolean:
				if (!(bool)obj)
				{
					return "FALSE";
				}
				return "TRUE";
			}
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_47(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
		double double_ = 0.1;
		if (class1661_0.method_7().Count == 3)
		{
			object obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
			if (obj3 != null)
			{
				TypeCode typeCode = Type.GetTypeCode(obj3.GetType());
				if (typeCode == TypeCode.Double)
				{
					double_ = (double)obj3;
				}
			}
		}
		if (obj != null && obj2 != null)
		{
			if (obj is Array)
			{
				if (obj2 is Array)
				{
					Array array = (Array)obj;
					int length = array.Length;
					Array array2 = (Array)array.GetValue(0);
					int length2 = array2.Length;
					double[] array3 = new double[length * length2];
					for (int i = 0; i < length; i++)
					{
						array2 = (Array)array.GetValue(i);
						for (int j = 0; j < length2; j++)
						{
							object value = array2.GetValue(j);
							if (value != null)
							{
								switch (Type.GetTypeCode(value.GetType()))
								{
								case TypeCode.Double:
									array3[i * length2 + j] = (double)value;
									break;
								case TypeCode.DateTime:
									array3[i * length2 + j] = CellsHelper.GetDoubleFromDateTime((DateTime)value, workbook_0.Settings.Date1904);
									break;
								default:
									return ErrorType.Value;
								}
							}
						}
					}
					Array array4 = (Array)obj2;
					if (array4.Length != length)
					{
						return ErrorType.Number;
					}
					Array array5 = (Array)array4.GetValue(0);
					if (array5.Length != length2)
					{
						return ErrorType.Number;
					}
					double[] array6 = new double[array3.Length];
					for (int k = 0; k < length; k++)
					{
						array5 = (Array)array4.GetValue(k);
						for (int l = 0; l < length2; l++)
						{
							object value2 = array5.GetValue(l);
							if (value2 != null)
							{
								switch (Type.GetTypeCode(value2.GetType()))
								{
								case TypeCode.Double:
									array6[k * length2 + l] = (double)value2;
									break;
								case TypeCode.DateTime:
									array6[k * length2 + l] = CellsHelper.GetDoubleFromDateTime((DateTime)value2, workbook_0.Settings.Date1904);
									break;
								default:
									return ErrorType.Value;
								}
							}
						}
					}
					Class1671 @class = new Class1671();
					return @class.Calculate(array3, array6, double_);
				}
				if (obj2 is ErrorType)
				{
					return obj2;
				}
				return ErrorType.Number;
			}
			if (obj is ErrorType)
			{
				return obj;
			}
			if (obj2 is Array)
			{
				return ErrorType.Number;
			}
			return ErrorType.NA;
		}
		return ErrorType.NA;
	}

	private object method_48(Class1661 class1661_0, Cell cell_0)
	{
		object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
		if (obj is double double_)
		{
			object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
			if (obj2 != null && obj2 is ErrorType)
			{
				return obj2;
			}
			object obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
			if (obj3 != null && obj3 is ErrorType)
			{
				return obj3;
			}
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			if (obj2 is Array)
			{
				Array array = (Array)obj2;
				if (obj3 is Array)
				{
					Array array2 = (Array)obj3;
					if (array.Length != array2.Length)
					{
						return ErrorType.Number;
					}
					Array array3 = (Array)array.GetValue(0);
					Array array4 = (Array)array2.GetValue(0);
					if (array3.Length != array4.Length)
					{
						return ErrorType.Value;
					}
					for (int i = 0; i < array.Length; i++)
					{
						array3 = (Array)array.GetValue(i);
						array4 = (Array)array2.GetValue(i);
						for (int j = 0; j < array3.Length; j++)
						{
							object value = array3.GetValue(j);
							if (value != null)
							{
								value = Class1660.smethod_26(value, workbook_0.Settings.Date1904);
								if (value is double)
								{
									arrayList.Add(value);
									object value2 = array4.GetValue(j);
									if (value2 != null)
									{
										value2 = Class1660.smethod_26(value2, workbook_0.Settings.Date1904);
										if (value2 is double)
										{
											arrayList2.Add(Math.Floor((double)value2));
											continue;
										}
										return value2;
									}
									return ErrorType.Value;
								}
								return value;
							}
							return ErrorType.Value;
						}
					}
				}
				else
				{
					object obj4 = Class1660.smethod_26(obj3, workbook_0.Settings.Date1904);
					if (!(obj4 is double))
					{
						return obj4;
					}
					arrayList2.Add(obj4);
					if (array.Length != 1)
					{
						return ErrorType.Number;
					}
					Array array5 = (Array)array.GetValue(0);
					if (array5.Length == 1)
					{
						object obj5 = Class1660.smethod_26(array5.GetValue(0), workbook_0.Settings.Date1904);
						if (!(obj5 is double))
						{
							return obj5;
						}
						arrayList.Add(obj5);
					}
				}
				return Class1665.smethod_4(double_, arrayList, arrayList2);
			}
			return ErrorType.Number;
		}
		return obj;
	}

	private object method_49(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2 && class1661_0.method_7().Count <= 3)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
			double num = 0.0;
			if (obj is double)
			{
				num = Math.Floor((double)obj);
				class1661_ = (Class1661)class1661_0.method_7()[1];
				object obj2 = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
				double num2 = 0.0;
				if (obj2 is double)
				{
					num2 = Math.Floor((double)obj2);
					int num3 = 0;
					if (class1661_0.method_7().Count == 3)
					{
						num3 = 0;
						num3 = 0;
						class1661_ = (Class1661)class1661_0.method_7()[2];
						object obj3 = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
						if (!(obj3 is double))
						{
							return obj3;
						}
						switch ((int)Class1179.ToDouble(obj3))
						{
						default:
							return ErrorType.Number;
						case 1:
							if (num < num2)
							{
								return (num2 - num) / Class1670.smethod_2(num, num2, workbook_0.Settings.Date1904);
							}
							if (num > num2)
							{
								return (num - num2) / Class1670.smethod_2(num2, num, workbook_0.Settings.Date1904);
							}
							return 0.0;
						case 2:
							return Math.Abs(num - num2) / 360.0;
						case 3:
							return Math.Abs(num - num2) / 365.0;
						case 4:
							if (num < num2)
							{
								return Class1670.smethod_1(num, num2, bool_0: true, workbook_0.Settings.Date1904) / 360.0;
							}
							if (num > num2)
							{
								return Class1670.smethod_1(num2, num, bool_0: true, workbook_0.Settings.Date1904) / 360.0;
							}
							return 0.0;
						case 0:
							break;
						}
					}
					else
					{
						num3 = 0;
						num3 = 0;
						int num4 = 0;
					}
					if (num < num2)
					{
						return Class1670.smethod_1(num, num2, bool_0: false, workbook_0.Settings.Date1904) / 360.0;
					}
					if (num > num2)
					{
						return Class1670.smethod_1(num2, num, bool_0: false, workbook_0.Settings.Date1904) / 360.0;
					}
					return 0.0;
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_50(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1 && class1661_0.method_7().Count <= 2)
		{
			object object_ = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			object_ = Class1660.smethod_9(workbook_0, object_, bool_0: true);
			if (object_ is ErrorType)
			{
				return object_;
			}
			int dayOfWeek = (int)CellsHelper.GetDateTimeFromDouble((double)object_, workbook_0.Settings.Date1904).DayOfWeek;
			int num = 1;
			if (class1661_0.method_7().Count > 1)
			{
				num = 1;
				num = 1;
				object_ = method_5((Class1661)class1661_0.method_7()[1], cell_0);
				object_ = Class1660.smethod_9(workbook_0, object_, bool_0: true);
				if (object_ is ErrorType)
				{
					return object_;
				}
				num = (int)Class1179.ToDouble(object_);
				switch (num)
				{
				case 2:
					if (dayOfWeek == 0)
					{
						return 7.0;
					}
					return (double)dayOfWeek;
				case 3:
					dayOfWeek--;
					if (dayOfWeek < 0)
					{
						return 6;
					}
					return dayOfWeek;
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
					dayOfWeek -= num % 10 - 1;
					if (dayOfWeek <= 0)
					{
						dayOfWeek += 7;
					}
					return dayOfWeek;
				}
			}
			else
			{
				num = 1;
				num = 1;
				int num2 = 1;
			}
			return (double)(dayOfWeek + 1);
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_51(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5(class1661_0, cell_0);
		if (obj == null)
		{
			return CellsHelper.GetDateTimeFromDouble(0.0, workbook_0.Settings.Date1904);
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		obj = Class1660.smethod_9(workbook_0, obj, bool_0: false);
		if (obj is ErrorType)
		{
			return obj;
		}
		return CellsHelper.GetDateTimeFromDouble((double)obj, workbook_0.Settings.Date1904);
	}

	private object method_52(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5(class1661_0, cell_0);
		if (obj == null)
		{
			return 0.0;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		return Class1660.smethod_9(workbook_0, obj, bool_0: false);
	}

	private object method_53(Class1661 class1661_0, Cell cell_0, string string_0)
	{
		object obj = method_51((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		DateTime dateTime_ = (DateTime)obj;
		object obj2 = null;
		switch (string_0)
		{
		case "WORKDAY.INTL":
		{
			int num3 = 0;
			obj2 = method_52((Class1661)class1661_0.method_7()[1], cell_0);
			if (obj2 is ErrorType)
			{
				return obj2;
			}
			num3 = (int)Class1179.ToDouble(obj2);
			object object_ = 1;
			if (class1661_0.method_7().Count >= 3)
			{
				obj2 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
				object_ = ((!(obj2 is double)) ? obj2.ToString() : ((object)Class1179.smethod_1((double)obj2)));
			}
			DateTime[] dateTime_3 = null;
			if (class1661_0.method_7().Count >= 4)
			{
				obj2 = method_5((Class1661)class1661_0.method_7()[3], cell_0);
				obj2 = Class1660.smethod_16(obj2, cell_0, workbook_0.Settings.Date1904);
				if (obj2 is ErrorType)
				{
					return obj2;
				}
				dateTime_3 = (DateTime[])obj2;
			}
			return Class1339.smethod_7(dateTime_, num3, object_, dateTime_3);
		}
		case "WORKDAY":
		{
			int num2 = 0;
			obj2 = method_52((Class1661)class1661_0.method_7()[1], cell_0);
			if (obj2 is ErrorType)
			{
				return obj2;
			}
			num2 = (int)Class1179.ToDouble(obj2);
			DateTime[] dateTime_2 = null;
			if (class1661_0.method_7().Count >= 3)
			{
				obj2 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
				obj2 = Class1660.smethod_16(obj2, cell_0, workbook_0.Settings.Date1904);
				if (obj2 is ErrorType)
				{
					return obj2;
				}
				dateTime_2 = (DateTime[])obj2;
			}
			return Class1339.smethod_9(dateTime_, num2, dateTime_2);
		}
		case "EDATE":
		{
			int num = 0;
			obj2 = method_52((Class1661)class1661_0.method_7()[1], cell_0);
			if (obj2 is ErrorType)
			{
				return obj2;
			}
			num = (int)Class1179.ToDouble(obj2);
			return dateTime_.AddMonths(num);
		}
		default:
			return null;
		}
	}

	private object method_54(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_51((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		object obj2 = method_51((Class1661)class1661_0.method_7()[1], cell_0);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		DateTime dateTime_ = (DateTime)obj;
		DateTime dateTime_2 = (DateTime)obj2;
		object obj3 = null;
		switch (class1661_0.method_3())
		{
		case "NETWORKDAYS.INTL":
		{
			object object_ = 1;
			if (class1661_0.method_7().Count >= 3)
			{
				obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
				object_ = ((!(obj3 is double)) ? obj3.ToString() : ((object)Class1179.smethod_1((double)obj3)));
			}
			DateTime[] dateTime_4 = null;
			if (class1661_0.method_7().Count >= 4)
			{
				obj3 = method_5((Class1661)class1661_0.method_7()[3], cell_0);
				obj3 = Class1660.smethod_16(obj3, cell_0, workbook_0.Settings.Date1904);
				if (obj3 is ErrorType)
				{
					return obj3;
				}
				dateTime_4 = (DateTime[])obj3;
			}
			return Class1339.smethod_10(dateTime_, dateTime_2, object_, dateTime_4, workbook_0.Settings.Date1904);
		}
		case "NETWORKDAYS":
		{
			DateTime[] dateTime_3 = null;
			if (class1661_0.method_7().Count >= 3)
			{
				obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
				obj3 = Class1660.smethod_16(obj3, cell_0, workbook_0.Settings.Date1904);
				if (obj3 is ErrorType)
				{
					return obj3;
				}
				dateTime_3 = (DateTime[])obj3;
			}
			return Class1339.smethod_12(dateTime_, dateTime_2, dateTime_3, workbook_0.Settings.Date1904);
		}
		default:
			return null;
		}
	}

	private object method_55(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1 && class1661_0.method_7().Count <= 2)
		{
			object object_ = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			object_ = Class1660.smethod_9(workbook_0, object_, bool_0: true);
			if (object_ is ErrorType)
			{
				return object_;
			}
			DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble((double)object_, workbook_0.Settings.Date1904);
			int num = 1;
			if (class1661_0.method_7().Count > 1)
			{
				object_ = method_5((Class1661)class1661_0.method_7()[1], cell_0);
				object_ = Class1660.smethod_9(workbook_0, object_, bool_0: true);
				if (object_ is ErrorType)
				{
					return object_;
				}
				num = (int)Class1179.ToDouble(object_);
			}
			return Class1339.smethod_3(dateTimeFromDouble, num);
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_56(Class1661 class1661_0, Cell cell_0, int int_3)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object obj = method_5(class1661_, cell_0);
			if (obj != null && obj is Array)
			{
				Array array = (Array)obj;
				object value = array.GetValue(0);
				object[][] array2 = new object[array.Length][];
				int num = 1;
				if (value is Array)
				{
					Array array3 = (Array)value;
					num = array3.Length;
				}
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = new object[num];
					value = array.GetValue(i);
					if (value == null)
					{
						continue;
					}
					if (value is Array)
					{
						Array array4 = (Array)value;
						for (int j = 0; j < array4.Length; j++)
						{
							array2[i][j] = Class1339.smethod_2(int_3, array4.GetValue(j), workbook_0.Settings);
						}
					}
					else
					{
						array2[i][0] = Class1339.smethod_2(int_3, value, workbook_0.Settings);
					}
				}
				return array2;
			}
			return Class1339.smethod_2(int_3, obj, workbook_0.Settings);
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_57(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 1 && class1661_0.method_7().Count <= 3)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object object_ = method_5(class1661_, cell_0);
			object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
			if (object_ is ErrorType)
			{
				return object_;
			}
			object obj;
			if (class1661_0.method_7().Count > 1)
			{
				class1661_ = (Class1661)class1661_0.method_7()[1];
				obj = method_5(class1661_, cell_0);
				if (obj != null)
				{
					obj = Class1660.smethod_26(obj, workbook_0.Settings.Date1904);
					if (obj is ErrorType)
					{
						return obj;
					}
				}
				else
				{
					obj = 2.0;
				}
			}
			else
			{
				obj = 2.0;
			}
			int num = (int)Class1179.ToDouble(obj);
			double num2 = Math.Pow(10.0, num);
			double num3 = (double)object_;
			double num4 = ((!(num3 > 0.0)) ? ((double)(int)(num3 * num2 - 0.5) / num2) : ((double)(int)(num3 * num2 + 0.5) / num2));
			bool flag = false;
			if (class1661_0.method_7().Count == 3)
			{
				class1661_ = (Class1661)class1661_0.method_7()[1];
				obj = method_5(class1661_, cell_0);
				if (obj == null)
				{
					return null;
				}
				if (obj is bool)
				{
					flag = (bool)obj;
				}
			}
			if (flag)
			{
				return num4.ToString();
			}
			StringBuilder stringBuilder = new StringBuilder("#" + CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator + "##0");
			if (num > 0)
			{
				stringBuilder.Append(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
				for (int i = 0; i < num; i++)
				{
					stringBuilder.Append("0");
				}
			}
			return num4.ToString(stringBuilder.ToString());
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_58(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 2)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return 0.0;
		}
		obj = Class1660.smethod_26(obj, workbook_0.Settings.Date1904);
		if (obj is ErrorType)
		{
			return obj;
		}
		if ((double)obj == 0.0)
		{
			return obj;
		}
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		object obj2 = method_5(class1661_2, cell_0);
		if (obj2 == null)
		{
			return ErrorType.Div;
		}
		obj2 = Class1660.smethod_26(obj2, workbook_0.Settings.Date1904);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		double num = (double)obj;
		double num2 = (double)obj2;
		if (num2 == 0.0)
		{
			return ErrorType.Div;
		}
		if (num * num2 < 0.0)
		{
			return ErrorType.Number;
		}
		return (double)(int)(num / num2) * num2;
	}

	private object method_59(Class1661 class1661_0, Cell cell_0)
	{
		int count = class1661_0.method_7().Count;
		if (class1661_0.method_7() != null && count >= 2 && count <= 5)
		{
			object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
			if (obj is double double_)
			{
				object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj2 is double double_2)
				{
					double num = 0.0;
					object obj3 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
					if (obj3 is double double_3)
					{
						double double_4 = 0.0;
						if (count > 3)
						{
							object obj4 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[3], cell_0), workbook_0.Settings.Date1904);
							if (!(obj4 is double))
							{
								return obj4;
							}
							double_4 = (double)obj4;
						}
						double num2 = 0.0;
						if (count > 4)
						{
							object obj5 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[4], cell_0), workbook_0.Settings.Date1904);
							if (!(obj5 is double))
							{
								return obj5;
							}
							num2 = (double)obj5;
							if (num2 != 0.0)
							{
								num2 = 1.0;
							}
						}
						return Class1378.smethod_58(double_, double_2, double_3, double_4, num2);
					}
					return obj3;
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_60(Class1661 class1661_0, Cell cell_0)
	{
		int count = class1661_0.method_7().Count;
		if (class1661_0.method_7() != null && count >= 3 && count <= 4)
		{
			object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
			if (obj is double double_)
			{
				object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj2 is double double_2)
				{
					double num = 0.0;
					object obj3 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
					if (obj3 is double double_3)
					{
						bool flag = false;
						if (count > 3)
						{
							object obj4 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[3], cell_0), workbook_0.Settings.Date1904);
							if (!(obj4 is double))
							{
								return obj4;
							}
							flag = (double)obj4 != 0.0;
						}
						return Class1669.smethod_5(double_, double_2, double_3, flag);
					}
					return obj3;
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_61(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
			if (obj is double double_)
			{
				object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj2 is double double_2)
				{
					double num = 0.0;
					object obj3 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
					if (obj3 is double double_3)
					{
						return Class1669.smethod_6(double_, double_2, double_3);
					}
					return obj3;
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_62(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() == null)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		int count = class1661_0.method_7().Count;
		if (count != 4)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		double[] array = new double[count];
		int num = 0;
		object obj;
		while (true)
		{
			if (num < count)
			{
				obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[num], cell_0), workbook_0.Settings.Date1904);
				if (!(obj is double))
				{
					break;
				}
				array[num] = (double)obj;
				num++;
				continue;
			}
			return Class1669.smethod_0((int)array[0], (int)array[1], array[2], array[3] != 0.0);
		}
		return obj;
	}

	private object method_63(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() == null)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		int count = class1661_0.method_7().Count;
		if (count != 3)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		double[] array = new double[count];
		int num = 0;
		object obj;
		while (true)
		{
			if (num < count)
			{
				obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[num], cell_0), workbook_0.Settings.Date1904);
				if (!(obj is double))
				{
					break;
				}
				array[num] = (double)obj;
				num++;
				continue;
			}
			return Class1669.smethod_1(array[0], array[1], array[2] != 0.0);
		}
		return obj;
	}

	private object method_64(Class1661 class1661_0, Cell cell_0)
	{
		int count = class1661_0.method_7().Count;
		if (class1661_0.method_7() != null && count >= 3 && count <= 5)
		{
			object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
			if (obj is double double_)
			{
				object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj2 is double double_2)
				{
					double num = 0.0;
					object obj3 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
					if (obj3 is double double_3)
					{
						double double_4 = 0.0;
						if (count > 3)
						{
							object obj4 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[3], cell_0), workbook_0.Settings.Date1904);
							if (!(obj4 is double))
							{
								return obj4;
							}
							double_4 = (double)obj4;
						}
						double double_5 = 1.0;
						if (count > 4)
						{
							object obj5 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[4], cell_0), workbook_0.Settings.Date1904);
							if (!(obj5 is double))
							{
								return obj5;
							}
							double_5 = (double)obj5;
						}
						return Class1669.smethod_3(double_, double_2, double_3, double_4, double_5);
					}
					return obj3;
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_65(Class1661 class1661_0, Cell cell_0)
	{
		int count = class1661_0.method_7().Count;
		if (class1661_0.method_7() != null && count >= 3 && count <= 5)
		{
			object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
			if (obj is double double_)
			{
				object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj2 is double double_2)
				{
					double num = 0.0;
					object obj3 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
					if (obj3 is double double_3)
					{
						double double_4 = 0.0;
						if (count > 3)
						{
							object obj4 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[3], cell_0), workbook_0.Settings.Date1904);
							if (!(obj4 is double))
							{
								return obj4;
							}
							double_4 = (double)obj4;
						}
						double double_5 = 1.0;
						if (count > 4)
						{
							object obj5 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[4], cell_0), workbook_0.Settings.Date1904);
							if (!(obj5 is double))
							{
								return obj5;
							}
							double_5 = (double)obj5;
						}
						return Class1669.smethod_4(double_, double_2, double_3, double_4, double_5);
					}
					return obj3;
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_66(Class1661 class1661_0, Cell cell_0)
	{
		int count = class1661_0.method_7().Count;
		if (class1661_0.method_7() != null && count == 3)
		{
			object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
			if (obj is double double_)
			{
				double num = 0.0;
				object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj2 is double double_2)
				{
					double num2 = 0.0;
					object obj3 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
					if (obj3 is double num3)
					{
						return Class1669.smethod_7(double_, double_2, (int)num3);
					}
					return obj3;
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_67(Class1661 class1661_0, Cell cell_0)
	{
		int count = class1661_0.method_7().Count;
		if (class1661_0.method_7() != null && count == 2)
		{
			object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
			if (obj is double double_)
			{
				double num = 0.0;
				object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj2 is double double_2)
				{
					return Class1669.smethod_8(double_, double_2);
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_68(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
			if (obj is double double_)
			{
				double num = 0.0;
				object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj2 is double double_2)
				{
					return Class1669.smethod_9(double_, double_2);
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_69(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
			if (obj is double double_)
			{
				double num = 0.0;
				object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj2 is double double_2)
				{
					return Class1669.smethod_10(double_, double_2);
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_70(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
			if (obj is double double_)
			{
				double num = 0.0;
				object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj2 is double double_2)
				{
					double num2 = 0.0;
					object obj3 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
					if (obj3 is double double_3)
					{
						return Class1669.smethod_11(double_, double_2, double_3);
					}
					return obj3;
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_71(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
			if (obj is double double_)
			{
				double num = 0.0;
				object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj2 is double double_2)
				{
					double num2 = 0.0;
					object obj3 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
					if (obj2 is double)
					{
						num2 = (double)obj3;
						return Class1669.smethod_12(double_, double_2, num2);
					}
					return obj3;
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_72(Class1661 class1661_0, Cell cell_0, int int_3)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object obj = method_5(class1661_, cell_0);
			class1661_ = (Class1661)class1661_0.method_7()[1];
			object object_ = method_5(class1661_, cell_0);
			if (obj != null && obj is object[][])
			{
				return Class1120.smethod_17((object[][])obj, object_, workbook_0, int_3);
			}
			return int_3 switch
			{
				-1 => Class1374.smethod_11(obj, object_, workbook_0), 
				0 => Class1374.smethod_12(obj, object_, workbook_0), 
				1 => Class1374.smethod_13(obj, object_, workbook_0), 
				_ => null, 
			};
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_73(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object object_ = method_5(class1661_, cell_0);
			object_ = Class1660.GetStringValue(object_);
			if (object_ is ErrorType)
			{
				return object_;
			}
			string text = (string)object_;
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			foreach (char c in text)
			{
				if (c >= 'A' && c <= 'Z')
				{
					if (flag)
					{
						stringBuilder.Append((char)(c + 32));
						continue;
					}
					stringBuilder.Append(c);
					flag = true;
				}
				else if (c >= 'a' && c <= 'z')
				{
					if (!flag)
					{
						stringBuilder.Append((char)(c - 32));
						flag = true;
					}
					else
					{
						stringBuilder.Append(c);
					}
				}
				else
				{
					stringBuilder.Append(c);
					flag = false;
				}
			}
			return stringBuilder.ToString();
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_74(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object object_ = method_5(class1661_, cell_0);
			object_ = Class1660.GetStringValue(object_);
			if (object_ is ErrorType)
			{
				return object_;
			}
			class1661_ = (Class1661)class1661_0.method_7()[1];
			object obj = method_5(class1661_, cell_0);
			if (object_ != null && obj != null)
			{
				obj = Class1660.smethod_26(obj, workbook_0.Settings.Date1904);
				if (obj is ErrorType)
				{
					return obj;
				}
				int num = (int)Class1179.ToDouble(obj);
				if (num == 0)
				{
					return "";
				}
				if (num < 0)
				{
					return ErrorType.Value;
				}
				if (((string)object_).Length * num > 32767)
				{
					return ErrorType.Value;
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < num; i++)
				{
					stringBuilder.Append((string)object_);
				}
				return stringBuilder.ToString();
			}
			return null;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_75(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 3 && class1661_0.method_7().Count <= 5)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object obj = method_5(class1661_, cell_0);
			if (obj != null && obj is ErrorType)
			{
				return obj;
			}
			class1661_0.method_4("");
			Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
			object obj2 = method_5(class1661_2, cell_0);
			Class1661 class1661_3 = (Class1661)class1661_0.method_7()[2];
			object obj3 = method_5(class1661_3, cell_0);
			if (obj is Struct87 @struct)
			{
				CellArea cellArea_ = @struct.cellArea_0;
				int num;
				if (obj2 == null)
				{
					num = 0;
				}
				else
				{
					if (obj2 is ErrorType)
					{
						class1661_0.method_4("OFFSET");
						return obj2;
					}
					switch (Type.GetTypeCode(obj2.GetType()))
					{
					case TypeCode.Double:
						num = (int)Class1179.ToDouble(obj2);
						break;
					case TypeCode.DateTime:
						num = (int)CellsHelper.GetDoubleFromDateTime((DateTime)obj2, workbook_0.Settings.Date1904);
						break;
					default:
						class1661_0.method_4("OFFSET");
						return ErrorType.Value;
					case TypeCode.String:
					{
						string text = (string)obj2;
						if (Class1677.smethod_19(text))
						{
							try
							{
								num = (int)double.Parse(text);
							}
							catch
							{
								class1661_0.method_4("OFFSET");
								return ErrorType.Value;
							}
							break;
						}
						class1661_0.method_4("OFFSET");
						return ErrorType.Value;
					}
					}
				}
				int num2;
				if (obj3 == null)
				{
					num2 = 0;
				}
				else
				{
					if (obj3 is ErrorType)
					{
						class1661_0.method_4("OFFSET");
						return obj3;
					}
					switch (Type.GetTypeCode(obj3.GetType()))
					{
					case TypeCode.Double:
						num2 = (int)Class1179.ToDouble(obj3);
						break;
					case TypeCode.DateTime:
						num2 = (int)CellsHelper.GetDoubleFromDateTime((DateTime)obj3, workbook_0.Settings.Date1904);
						break;
					default:
						class1661_0.method_4("OFFSET");
						return ErrorType.Value;
					case TypeCode.String:
					{
						string text2 = (string)obj3;
						if (Class1677.smethod_20(text2))
						{
							try
							{
								num2 = (int)double.Parse(text2);
							}
							catch
							{
								class1661_0.method_4("OFFSET");
								return ErrorType.Value;
							}
							break;
						}
						class1661_0.method_4("OFFSET");
						return ErrorType.Value;
					}
					}
				}
				cellArea_.StartRow += num;
				cellArea_.EndRow += num;
				cellArea_.EndColumn += num2;
				cellArea_.StartColumn += num2;
				if (class1661_0.method_7().Count > 3)
				{
					Class1661 @class = (Class1661)class1661_0.method_7()[3];
					if (!@class.method_0())
					{
						object obj6 = Class1660.smethod_26(method_5(@class, cell_0), workbook_0.Settings.Date1904);
						if (!(obj6 is double))
						{
							class1661_0.method_4("OFFSET");
							return obj6;
						}
						int num3 = (int)Class1179.ToDouble(obj6);
						if (num3 == 0)
						{
							class1661_0.method_4("OFFSET");
							return ErrorType.Ref;
						}
						if (num3 > 0)
						{
							cellArea_.EndRow = cellArea_.StartRow + num3 - 1;
						}
						else
						{
							if (num3 >= 0)
							{
								return ErrorType.Ref;
							}
							cellArea_.StartRow += num3 + 1;
						}
					}
				}
				if (class1661_0.method_7().Count > 4)
				{
					Class1661 class2 = (Class1661)class1661_0.method_7()[4];
					if (!class2.method_0())
					{
						object obj7 = Class1660.smethod_26(method_5(class2, cell_0), workbook_0.Settings.Date1904);
						if (!(obj7 is double))
						{
							class1661_0.method_4("OFFSET");
							return obj7;
						}
						int num4 = (int)Class1179.ToDouble(obj7);
						if (num4 == 0)
						{
							class1661_0.method_4("OFFSET");
							return ErrorType.Ref;
						}
						if (num4 > 0)
						{
							cellArea_.EndColumn = cellArea_.StartColumn + num4 - 1;
						}
						else
						{
							if (num4 >= 0)
							{
								return ErrorType.Ref;
							}
							cellArea_.StartColumn += num4 + 1;
						}
					}
				}
				if (cellArea_.StartColumn >= 0 && cellArea_.StartColumn <= 16383 && cellArea_.EndColumn >= 0 && cellArea_.EndColumn <= 16383 && cellArea_.StartRow >= 0 && cellArea_.StartRow <= 1048575 && cellArea_.EndRow >= 0 && cellArea_.EndRow <= 1048575)
				{
					if (cellArea_.StartRow > cellArea_.EndRow)
					{
						int startRow = cellArea_.StartRow;
						cellArea_.StartRow = cellArea_.EndRow;
						cellArea_.EndRow = startRow;
					}
					if (cellArea_.StartColumn > cellArea_.EndColumn)
					{
						int startColumn = cellArea_.StartColumn;
						cellArea_.StartColumn = cellArea_.EndColumn;
						cellArea_.EndColumn = startColumn;
					}
					if (class1661_0.method_5() != null)
					{
						if (class1661_0.method_5().Type == Enum180.const_3)
						{
							switch (class1661_0.method_5().method_3())
							{
							case "SUMIF":
								if (class1661_0.method_5().method_7().Count == 3 && class1661_0.method_5().method_7()[2] == class1661_0)
								{
									@struct.cellArea_0 = cellArea_;
									return @struct;
								}
								break;
							case "ROW":
							case "ROWS":
							case "COLUMN":
							case "COLUMNS":
							case "SUM":
								@struct.cellArea_0 = cellArea_;
								return @struct;
							}
						}
						else if (class1661_0.method_5().method_9() != null)
						{
							byte b = class1661_0.method_5().method_9()[0];
							if (b == 17)
							{
								@struct.cellArea_0 = cellArea_;
								return @struct;
							}
						}
					}
					else if (cell_0 == null)
					{
						@struct.cellArea_0 = cellArea_;
						return @struct;
					}
					object result;
					if (cellArea_.StartRow == cellArea_.EndRow && cellArea_.StartColumn == cellArea_.EndColumn)
					{
						if (class1661_0.method_5() != null && class1661_0.method_5().method_9() != null && class1661_0.method_9().Length > 0 && class1661_0.method_5().method_9()[0] == 17)
						{
							class1661_0.method_4("OFFSET");
							@struct.cellArea_0 = cellArea_;
							return @struct;
						}
						result = method_34(class1661_0, workbook_0.Worksheets[@struct.int_1], cell_0, cellArea_.StartRow, cellArea_.StartColumn);
						class1661_0.method_4("OFFSET");
						return result;
					}
					result = method_37(class1661_0, workbook_0.Worksheets[@struct.int_1], cell_0, cellArea_.StartRow, cellArea_.EndRow, cellArea_.StartColumn, cellArea_.EndColumn);
					class1661_0.method_4("OFFSET");
					return result;
				}
				class1661_0.method_4("OFFSET");
				return ErrorType.Ref;
			}
			class1661_0.method_4("OFFSET");
			return null;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_76(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 255)
		{
			bool flag = true;
			int num = 0;
			object obj;
			while (true)
			{
				if (num < class1661_0.method_7().Count)
				{
					Class1661 class1661_ = (Class1661)class1661_0.method_7()[num];
					obj = method_5(class1661_, cell_0);
					if (obj != null)
					{
						if (obj is ErrorType)
						{
							break;
						}
						switch (Type.GetTypeCode(obj.GetType()))
						{
						default:
						{
							if (!(obj is Array))
							{
								break;
							}
							Array array = (Array)obj;
							for (int i = 0; i < array.Length; i++)
							{
								object value2 = array.GetValue(i);
								if (value2 == null)
								{
									continue;
								}
								if (value2 is Array)
								{
									Array array2 = (Array)value2;
									for (int j = 0; j < array2.Length; j++)
									{
										object value3 = array2.GetValue(j);
										if (value3 != null && value3 is bool)
										{
											if ((bool)value3)
											{
												return true;
											}
											flag = false;
										}
									}
								}
								else if (value2 is bool)
								{
									if ((bool)value2)
									{
										return true;
									}
									flag = false;
								}
							}
							break;
						}
						case TypeCode.Double:
						{
							double value = (double)obj;
							if (Math.Abs(value) < double.Epsilon)
							{
								flag = false;
								break;
							}
							return true;
						}
						case TypeCode.Boolean:
							if (!(bool)obj)
							{
								flag = false;
								break;
							}
							num++;
							while (true)
							{
								if (num < class1661_0.method_7().Count)
								{
									class1661_ = (Class1661)class1661_0.method_7()[num];
									obj = method_5(class1661_, cell_0);
									if (obj != null && obj is ErrorType)
									{
										break;
									}
									num++;
									continue;
								}
								return true;
							}
							return obj;
						case TypeCode.String:
							return ErrorType.Value;
						}
					}
					num++;
					continue;
				}
				if (!flag)
				{
					return false;
				}
				return ErrorType.Value;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_77(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 255)
		{
			double num = 0.0;
			bool flag = true;
			int num2 = 0;
			object obj;
			while (true)
			{
				if (num2 < class1661_0.method_7().Count)
				{
					Class1661 class1661_ = (Class1661)class1661_0.method_7()[num2];
					obj = method_5(class1661_, cell_0);
					if (obj != null)
					{
						if (obj is ErrorType)
						{
							break;
						}
						if (obj is Array)
						{
							Array array = (Array)obj;
							for (int i = 0; i < array.Length; i++)
							{
								Array array2 = (Array)array.GetValue(i);
								if (array2 == null)
								{
									continue;
								}
								for (int j = 0; j < array2.Length; j++)
								{
									object value = array2.GetValue(j);
									if (value != null && value is double num3)
									{
										if (flag)
										{
											num = num3;
											flag = false;
										}
										else if (num3 > num)
										{
											num = num3;
										}
									}
								}
							}
						}
						else
						{
							switch (Type.GetTypeCode(obj.GetType()))
							{
							case TypeCode.Double:
							{
								double num4 = (double)obj;
								if (flag)
								{
									num = num4;
									flag = false;
								}
								else if (num4 > num)
								{
									num = num4;
								}
								break;
							}
							case TypeCode.DateTime:
							{
								double num4 = CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904);
								if (flag)
								{
									num = num4;
									flag = false;
								}
								else if (num4 > num)
								{
									num = num4;
								}
								break;
							}
							case TypeCode.String:
								if (((Class1661)class1661_0.method_7()[num2]).method_9() != null && ((Class1661)class1661_0.method_7()[num2]).method_9()[0] == 23)
								{
									return ErrorType.Value;
								}
								break;
							case TypeCode.Boolean:
								if (((Class1661)class1661_0.method_7()[num2]).method_9() == null)
								{
									break;
								}
								switch (((Class1661)class1661_0.method_7()[num2]).method_9()[0])
								{
								case 9:
								case 10:
								case 11:
								case 12:
								case 13:
								case 14:
								case 29:
								case 33:
								case 34:
									if ((bool)obj)
									{
										if (num < 1.0 || flag)
										{
											num = 1.0;
										}
									}
									else if (num < 0.0)
									{
										num = 0.0;
									}
									if (flag)
									{
										flag = false;
									}
									break;
								}
								break;
							}
						}
					}
					num2++;
					continue;
				}
				if (flag)
				{
					return 0.0;
				}
				return num;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_78(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 255)
		{
			double num = 0.0;
			bool flag = true;
			int num2 = 0;
			object obj;
			while (true)
			{
				if (num2 < class1661_0.method_7().Count)
				{
					Class1661 class1661_ = (Class1661)class1661_0.method_7()[num2];
					obj = method_5(class1661_, cell_0);
					if (obj != null)
					{
						if (obj is ErrorType)
						{
							break;
						}
						if (obj is Array)
						{
							Array array = (Array)obj;
							for (int i = 0; i < array.Length; i++)
							{
								Array array2 = (Array)array.GetValue(i);
								if (array2 == null)
								{
									continue;
								}
								for (int j = 0; j < array2.Length; j++)
								{
									object value = array2.GetValue(j);
									if (value != null && value is double num3)
									{
										if (flag)
										{
											num = num3;
											flag = false;
										}
										else if (num3 < num)
										{
											num = num3;
										}
									}
								}
							}
						}
						else
						{
							switch (Type.GetTypeCode(obj.GetType()))
							{
							case TypeCode.Double:
							{
								double num4 = (double)obj;
								if (flag)
								{
									num = num4;
									flag = false;
								}
								else if (num4 < num)
								{
									num = num4;
								}
								break;
							}
							case TypeCode.DateTime:
							{
								double num4 = CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904);
								if (flag)
								{
									num = num4;
									flag = false;
								}
								else if (num4 < num)
								{
									num = num4;
								}
								break;
							}
							case TypeCode.String:
								if (((Class1661)class1661_0.method_7()[num2]).method_9() != null && ((Class1661)class1661_0.method_7()[num2]).method_9()[0] == 23)
								{
									return ErrorType.Value;
								}
								break;
							case TypeCode.Boolean:
								if (((Class1661)class1661_0.method_7()[num2]).method_9() == null)
								{
									break;
								}
								switch (((Class1661)class1661_0.method_7()[num2]).method_9()[0])
								{
								case 9:
								case 10:
								case 11:
								case 12:
								case 13:
								case 14:
								case 29:
								case 33:
								case 34:
									if ((bool)obj)
									{
										if (num > 1.0 || flag)
										{
											num = 1.0;
										}
									}
									else if (num > 0.0)
									{
										num = 0.0;
									}
									if (flag)
									{
										flag = false;
									}
									break;
								}
								break;
							}
						}
					}
					num2++;
					continue;
				}
				if (flag)
				{
					return 0.0;
				}
				return num;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_79(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 255)
		{
			double num = 0.0;
			bool flag = true;
			int num2 = 0;
			object obj;
			while (true)
			{
				if (num2 < class1661_0.method_7().Count)
				{
					Class1661 class1661_ = (Class1661)class1661_0.method_7()[num2];
					obj = method_5(class1661_, cell_0);
					if (obj != null)
					{
						if (obj is ErrorType)
						{
							return obj;
						}
						if (obj is Array)
						{
							Array array = (Array)obj;
							for (int i = 0; i < array.Length; i++)
							{
								Array array2 = (Array)array.GetValue(i);
								if (array2 == null)
								{
									continue;
								}
								for (int j = 0; j < array2.Length; j++)
								{
									object value = array2.GetValue(j);
									value = Class1660.smethod_27(value, workbook_0.Settings.Date1904);
									if (!(value is ErrorType))
									{
										double num3 = (double)value;
										if (flag)
										{
											num = num3;
											flag = false;
										}
										else if (num3 > num)
										{
											num = num3;
										}
										continue;
									}
									return value;
								}
							}
						}
						else
						{
							obj = Class1660.smethod_27(obj, workbook_0.Settings.Date1904);
							if (obj is ErrorType)
							{
								break;
							}
							double num3 = (double)obj;
							if (flag)
							{
								num = num3;
								flag = false;
							}
							else if (num3 > num)
							{
								num = num3;
							}
						}
					}
					num2++;
					continue;
				}
				if (flag)
				{
					return 0.0;
				}
				return num;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_80(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 255)
		{
			double num = 0.0;
			bool flag = true;
			int num2 = 0;
			object obj;
			while (true)
			{
				if (num2 < class1661_0.method_7().Count)
				{
					Class1661 class1661_ = (Class1661)class1661_0.method_7()[num2];
					obj = method_5(class1661_, cell_0);
					if (obj != null)
					{
						if (obj is ErrorType)
						{
							return obj;
						}
						if (obj is Array)
						{
							Array array = (Array)obj;
							for (int i = 0; i < array.Length; i++)
							{
								Array array2 = (Array)array.GetValue(i);
								if (array2 == null)
								{
									continue;
								}
								for (int j = 0; j < array2.Length; j++)
								{
									object value = array2.GetValue(j);
									value = Class1660.smethod_27(value, workbook_0.Settings.Date1904);
									if (!(value is ErrorType))
									{
										double num3 = (double)value;
										if (flag)
										{
											num = num3;
											flag = false;
										}
										else if (num3 < num)
										{
											num = num3;
										}
										continue;
									}
									return value;
								}
							}
						}
						else
						{
							obj = Class1660.smethod_27(obj, workbook_0.Settings.Date1904);
							if (obj is ErrorType)
							{
								break;
							}
							double num3 = (double)obj;
							if (flag)
							{
								num = num3;
								flag = false;
							}
							else if (num3 < num)
							{
								num = num3;
							}
						}
					}
					num2++;
					continue;
				}
				if (flag)
				{
					return 0.0;
				}
				return num;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_81(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object obj = method_5(class1661_, cell_0);
			class1661_ = (Class1661)class1661_0.method_7()[1];
			object obj2 = method_5(class1661_, cell_0);
			if (obj2 == null)
			{
				return ErrorType.Div;
			}
			if (obj == null)
			{
				return 0.0;
			}
			obj = Class1660.smethod_26(obj, workbook_0.Settings.Date1904);
			obj2 = Class1660.smethod_26(obj2, workbook_0.Settings.Date1904);
			if (!(obj is double))
			{
				return obj;
			}
			if (!(obj2 is double))
			{
				return obj2;
			}
			double num = (double)obj;
			double num2 = (double)obj2;
			if (Math.Abs(num2) < double.Epsilon)
			{
				return ErrorType.Div;
			}
			if (Math.Abs(num) < double.Epsilon)
			{
				return 0.0;
			}
			double num3 = num % num2;
			if (Math.Sign(num) != Math.Sign(num2))
			{
				num3 += num2;
			}
			return num3;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_82(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object object_ = method_5(class1661_, cell_0);
			object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
			if (object_ is ErrorType)
			{
				return object_;
			}
			class1661_ = (Class1661)class1661_0.method_7()[1];
			object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
			if (obj is ErrorType)
			{
				return obj;
			}
			double num = (double)object_;
			double num2 = (double)obj;
			if (num != 0.0 && num2 != 0.0)
			{
				if (num * num2 < 0.0)
				{
					return ErrorType.Number;
				}
				int num3 = (int)(num / num2 + 0.5);
				return num2 * (double)num3;
			}
			return 0.0;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_83(Class1661 class1661_0, Cell cell_0)
	{
		Class1271 @class = new Class1271(this, workbook_0);
		return @class.method_0(class1661_0, cell_0);
	}

	private object method_84(Class1661 class1661_0, Cell cell_0, bool bool_3)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			if (obj == null)
			{
				return 0.0;
			}
			if (obj is ErrorType)
			{
				return obj;
			}
			if (obj is Array)
			{
				Array array = (Array)obj;
				object[][] array2 = new object[array.Length][];
				for (int i = 0; i < array.Length; i++)
				{
					Array array3 = (Array)array.GetValue(i);
					if (array3 == null)
					{
						continue;
					}
					array2[i] = new object[array3.Length];
					for (int j = 0; j < array3.Length; j++)
					{
						obj = array3.GetValue(j);
						if (obj == null)
						{
							array2[i][j] = 0.0;
						}
						else if (bool_3)
						{
							array2[i][j] = (double)Class1253.smethod_2(obj.ToString());
						}
						else
						{
							array2[i][j] = (double)obj.ToString().Length;
						}
					}
				}
				return array2;
			}
			if (obj is DateTime)
			{
				obj = CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904);
			}
			string text = obj.ToString();
			if (bool_3)
			{
				return (double)Class1253.smethod_2(text);
			}
			return (double)text.Length;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_85(Class1661 class1661_0, Cell cell_0, bool bool_3)
	{
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			switch (class1661_0.method_7().Count)
			{
			case 1:
			{
				object object_3 = method_5((Class1661)class1661_0.method_7()[0], cell_0);
				object_3 = Class1660.GetStringValue(object_3);
				if (object_3 is ErrorType)
				{
					return object_3;
				}
				string text2 = object_3.ToString();
				if (bool_3)
				{
					return Class1253.smethod_5(text2);
				}
				if (text2.Length > 1)
				{
					return text2.Substring(0, 1);
				}
				return "";
			}
			case 2:
			{
				object object_ = method_5((Class1661)class1661_0.method_7()[0], cell_0);
				object_ = Class1660.GetStringValue(object_);
				if (object_ is ErrorType)
				{
					return object_;
				}
				object object_2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
				object_2 = Class1660.smethod_26(object_2, workbook_0.Settings.Date1904);
				if (object_2 is ErrorType)
				{
					return object_2;
				}
				string text = object_.ToString();
				int num = (int)Class1179.ToDouble(object_2);
				if (bool_3)
				{
					return Class1253.smethod_4(text, num);
				}
				if (num < 0)
				{
					return ErrorType.Value;
				}
				if (num < text.Length)
				{
					return text.Substring(0, num);
				}
				return text;
			}
			default:
				throw new CellsException(ExceptionType.Formula, "Invalid formula.");
			}
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_86(Class1661 class1661_0, Cell cell_0, bool bool_3)
	{
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 1 || class1661_0.method_7().Count == 2))
		{
			switch (class1661_0.method_7().Count)
			{
			case 1:
			{
				object object_3 = method_5((Class1661)class1661_0.method_7()[0], cell_0);
				object_3 = Class1660.GetStringValue(object_3);
				if (object_3 is ErrorType)
				{
					return object_3;
				}
				string text2 = object_3.ToString();
				if (bool_3)
				{
					return Class1253.smethod_7(text2);
				}
				if (text2.Length > 0)
				{
					return text2.Substring(text2.Length - 1, 1);
				}
				return "";
			}
			case 2:
			{
				object object_ = method_5((Class1661)class1661_0.method_7()[0], cell_0);
				object_ = Class1660.GetStringValue(object_);
				if (object_ is ErrorType)
				{
					return object_;
				}
				string text = (string)object_;
				object object_2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
				object_2 = Class1660.smethod_26(object_2, workbook_0.Settings.Date1904);
				if (object_2 is ErrorType)
				{
					return object_2;
				}
				int num = (int)Class1179.ToDouble(object_2);
				if (bool_3)
				{
					return Class1253.smethod_6(text, num);
				}
				if (num < 0)
				{
					return ErrorType.Value;
				}
				if (num < text.Length)
				{
					return text.Substring(text.Length - num, num);
				}
				return text;
			}
			default:
				throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
			}
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_87(Class1661 class1661_0, Cell cell_0, bool bool_3)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 3)
		{
			object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
			object obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
			if (obj2 != null && obj3 != null)
			{
				if (obj == null)
				{
					return "";
				}
				if (obj is ErrorType)
				{
					return obj;
				}
				TypeCode typeCode = Type.GetTypeCode(obj.GetType());
				string text;
				if (typeCode == TypeCode.Boolean)
				{
					text = ((!(bool)obj) ? "FALSE" : "TRUE");
				}
				else
				{
					if (obj is Array)
					{
						Array array = (Array)obj;
						if (array.Length > 1)
						{
							return ErrorType.Value;
						}
						array = (Array)array.GetValue(0);
						if (array.Length > 1)
						{
							return ErrorType.Value;
						}
						obj = array.GetValue(0);
						if (obj == null)
						{
							return "";
						}
						if (obj is bool)
						{
							if ((bool)obj)
							{
								text = "TRUE";
							}
							else
							{
								text = "FALSE";
							}
						}
					}
					text = obj.ToString();
				}
				int num = 0;
				obj2 = Class1660.smethod_26(obj2, workbook_0.Settings.Date1904);
				if (obj2 is double)
				{
					num = (int)Class1179.ToDouble(obj2) - 1;
					if (num < 0)
					{
						return ErrorType.Value;
					}
					int num2 = 0;
					obj3 = Class1660.smethod_26(obj3, workbook_0.Settings.Date1904);
					if (obj3 is double)
					{
						num2 = (int)Class1179.ToDouble(obj3);
						if (num2 < 0)
						{
							return ErrorType.Value;
						}
						if (bool_3)
						{
							return Class1253.smethod_3(text, num + 1, num2);
						}
						if (num < 0)
						{
							return text;
						}
						if (num >= text.Length)
						{
							return "";
						}
						if (num2 + num <= text.Length && num2 <= text.Length)
						{
							return text.Substring(num, num2);
						}
						return text.Substring(num);
					}
					return obj3;
				}
				return obj2;
			}
			return ErrorType.Value;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_88(Class1661 class1661_0, Cell cell_0, bool bool_3)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2)
		{
			object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			if (obj == null)
			{
				return 1;
			}
			if (obj is ErrorType)
			{
				return obj;
			}
			string text = obj.ToString();
			if (text == "")
			{
				return 1;
			}
			object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
			if (obj2 == null)
			{
				return ErrorType.Value;
			}
			if (obj2 is Array)
			{
				Array array = (Array)obj2;
				if (array.Length > 1)
				{
					return ErrorType.Value;
				}
				array = (Array)array.GetValue(0);
				if (array.Length > 1)
				{
					return ErrorType.Value;
				}
				obj2 = array.GetValue(0);
				if (obj2 == null)
				{
					return ErrorType.Value;
				}
			}
			if (obj2 is ErrorType)
			{
				return obj2;
			}
			string text2 = obj2.ToString();
			if (text2 == "")
			{
				return ErrorType.Value;
			}
			if (class1661_0.method_7().Count == 2)
			{
				if (bool_3)
				{
					return Class1660.smethod_26(Class1253.smethod_12(text, text2), bool_0: false);
				}
				int num = text2.IndexOf(text);
				if (num == -1)
				{
					return ErrorType.Value;
				}
				num++;
				return (double)num;
			}
			object obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
			if (obj3 == null)
			{
				return ErrorType.Value;
			}
			int num2 = Class1660.smethod_28(workbook_0, obj3, bool_0: true);
			if (num2 < 0)
			{
				return ErrorType.Value;
			}
			if (bool_3)
			{
				return Class1253.smethod_13(text, text2, num2 + 1);
			}
			if (num2 >= text2.Length)
			{
				return ErrorType.Value;
			}
			int num3 = text2.IndexOf(text, num2);
			if (num3 == -1)
			{
				return ErrorType.Value;
			}
			num3++;
			return (double)num3;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_89(Class1661 class1661_0, Cell cell_0, bool bool_3)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2)
		{
			object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			if (obj == null)
			{
				return 1;
			}
			if (obj is ErrorType)
			{
				return obj;
			}
			string string_ = obj.ToString().ToUpper();
			object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
			if (obj2 == null)
			{
				return ErrorType.Value;
			}
			if (obj2 is ErrorType)
			{
				return obj2;
			}
			if (obj2 is Array)
			{
				Array array = (Array)obj2;
				if (array.Length > 1)
				{
					return ErrorType.Value;
				}
				array = (Array)array.GetValue(0);
				if (array.Length > 1)
				{
					return ErrorType.Value;
				}
				obj2 = array.GetValue(0);
				if (obj2 == null)
				{
					return ErrorType.Value;
				}
			}
			string text = obj2.ToString().ToUpper();
			if (text == "")
			{
				return ErrorType.Value;
			}
			object obj3 = null;
			if (class1661_0.method_7().Count > 2)
			{
				obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
				if (obj3 == null)
				{
					return ErrorType.Value;
				}
			}
			if (obj is object[][])
			{
				return Class1253.smethod_8((object[][])obj, text, obj3, bool_3, workbook_0.Settings);
			}
			return Class1253.smethod_9(string_, text, obj3, bool_3, workbook_0.Settings);
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_90(Class1661 class1661_0, Cell cell_0, bool bool_3)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 4)
		{
			object object_ = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			object_ = Class1660.GetStringValue(object_);
			if (object_ is ErrorType)
			{
				return object_;
			}
			string text = (string)object_;
			object obj = method_5((Class1661)class1661_0.method_7()[1], cell_0);
			if (obj == null)
			{
				return ErrorType.Value;
			}
			int num = Class1660.smethod_28(workbook_0, obj, bool_0: true);
			if (num < 0)
			{
				return ErrorType.Value;
			}
			object obj2 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
			if (obj2 == null)
			{
				return ErrorType.Value;
			}
			int num2 = Class1660.smethod_28(workbook_0, obj2, bool_0: false);
			if (num2 < 0)
			{
				return ErrorType.Value;
			}
			object object_2 = method_5((Class1661)class1661_0.method_7()[3], cell_0);
			object_2 = Class1660.GetStringValue(object_2);
			if (object_2 is ErrorType)
			{
				return object_2;
			}
			string text2 = (string)object_2;
			if (bool_3)
			{
				return Class1253.smethod_14(text, num + 1, num2, text2);
			}
			if (text == "")
			{
				return text2;
			}
			if (num >= text.Length)
			{
				return text + text2;
			}
			if (num + num2 > text.Length)
			{
				return text.Substring(0, num) + text2;
			}
			return text.Substring(0, num) + text2 + text.Substring(num + num2);
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_91(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj == null)
		{
			return null;
		}
		obj = Class1660.GetStringValue(obj);
		if (obj is ErrorType)
		{
			return obj;
		}
		string text = (string)obj;
		string result = text;
		if (class1661_0.method_7().Count > 1)
		{
			obj = method_5((Class1661)class1661_0.method_7()[1], cell_0);
			if (obj != null)
			{
				obj = Class1660.GetStringValue(obj);
				if (obj is ErrorType)
				{
					return obj;
				}
				result = (string)obj;
			}
		}
		return result;
	}

	private object method_92(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2)
		{
			object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
			if (class1661_0.method_7().Count == 2)
			{
				return Class1250.smethod_0(obj, obj2, workbook_0.Settings.Date1904);
			}
			object obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
			if (obj == null)
			{
				return ErrorType.NA;
			}
			if (obj is Array)
			{
				return ErrorType.Value;
			}
			if (obj3 is Struct87 @struct && @struct.cellArea_0.StartRow != @struct.cellArea_0.EndRow && @struct.cellArea_0.StartColumn != @struct.cellArea_0.EndColumn)
			{
				return ErrorType.NA;
			}
			if (obj2 is Array)
			{
				Array array = (Array)obj2;
				if (array.Length == 1)
				{
					Array array2 = (Array)array.GetValue(0);
					for (int num = array2.Length - 1; num >= 0; num--)
					{
						object value = array2.GetValue(num);
						if (value != null)
						{
							object obj4 = Class1662.CompareTo(obj, value, workbook_0.Settings.Date1904, bool_1: true);
							if (obj4 is ErrorType)
							{
								return obj4;
							}
							double num2 = (double)obj4;
							if (!(num2 < 0.0))
							{
								return method_93(obj3, 0, num);
							}
						}
					}
				}
				else
				{
					for (int num3 = array.Length - 1; num3 >= 0; num3--)
					{
						Array array3 = (Array)array.GetValue(num3);
						object value2 = array3.GetValue(0);
						if (value2 != null && !(value2 is ErrorType))
						{
							object obj5 = Class1662.CompareTo(obj, value2, workbook_0.Settings.Date1904, bool_1: true);
							if (obj5 is ErrorType)
							{
								return obj5;
							}
							double num4 = (double)obj5;
							if (!(num4 < 0.0))
							{
								return method_93(obj3, num3, 0);
							}
						}
					}
				}
			}
			return ErrorType.NA;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_93(object object_0, int int_3, int int_4)
	{
		if (object_0 == null)
		{
			return object_0;
		}
		if (object_0 is Array)
		{
			Array array = (Array)object_0;
			if (int_3 >= array.Length)
			{
				return null;
			}
			object value = array.GetValue(int_3);
			if (value is Array)
			{
				Array array2 = (Array)value;
				if (int_4 >= array2.Length)
				{
					return null;
				}
				return array2.GetValue(int_4);
			}
			if (int_4 == 0)
			{
				return value;
			}
			return null;
		}
		if (object_0 is Struct87 @struct)
		{
			int num = @struct.cellArea_0.StartRow + int_3;
			int num2 = @struct.cellArea_0.StartColumn + int_4;
			Cell cell = workbook_0.Worksheets[@struct.int_1].Cells.GetCell(num, num2, bool_2: false);
			return method_211(cell);
		}
		if (int_3 == 0 && int_4 == 0)
		{
			return object_0;
		}
		return null;
	}

	private object method_94(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
		{
			object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			if (obj is ErrorType)
			{
				return obj;
			}
			bool flag = ((Class1661)class1661_0.method_7()[1]).method_0();
			if (obj is object[][])
			{
				object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
				object obj3 = null;
				if (class1661_0.method_7().Count == 3)
				{
					obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
				}
				object[] array = Class1120.smethod_0(new object[3] { obj, obj2, obj3 });
				object[][] array2 = (object[][])array[0];
				object[][] array3 = (object[][])array[1];
				object[][] array4 = (object[][])array[2];
				object[][] array5 = new object[array2.Length][];
				for (int i = 0; i < array2.Length; i++)
				{
					if (array2[i] == null)
					{
						continue;
					}
					object[] array6 = array2[i];
					array5[i] = new object[array6.Length];
					for (int j = 0; j < array6.Length; j++)
					{
						object obj4 = Class1660.smethod_18(array6[j], workbook_0.Settings.Date1904);
						if (obj4 is bool)
						{
							if ((bool)obj4)
							{
								if (flag)
								{
									array5[i][j] = Class1391.object_3;
								}
								else if (array3 != null && array3[i] != null)
								{
									array5[i][j] = array3[i][j];
								}
							}
							else if (class1661_0.method_7().Count == 2)
							{
								array5[i][j] = false;
							}
							else if (array4 != null && array4[i] != null)
							{
								array5[i][j] = array4[i][j];
							}
							continue;
						}
						return obj4;
					}
				}
				return array5;
			}
			object obj5 = Class1660.smethod_18(obj, workbook_0.Settings.Date1904);
			if (!(obj5 is bool))
			{
				return obj5;
			}
			if ((bool)obj5)
			{
				return method_5((Class1661)class1661_0.method_7()[1], cell_0);
			}
			if (class1661_0.method_7().Count == 2)
			{
				return false;
			}
			return method_5((Class1661)class1661_0.method_7()[2], cell_0);
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_95(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count >= 2 || class1661_0.method_7().Count <= 4))
		{
			object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			if (obj is ErrorType)
			{
				return obj;
			}
			object obj2 = 1.0;
			if (class1661_0.method_7().Count > 1)
			{
				Class1661 @class = (Class1661)class1661_0.method_7()[1];
				if (!@class.method_0())
				{
					obj2 = method_5(@class, cell_0);
					obj2 = Class1660.smethod_26(obj2, workbook_0.Settings.Date1904);
					if (obj2 != null && obj2 is ErrorType)
					{
						return obj2;
					}
				}
				else
				{
					obj2 = 0.0;
				}
			}
			object obj3 = 1.0;
			if (class1661_0.method_7().Count > 2)
			{
				Class1661 class2 = (Class1661)class1661_0.method_7()[2];
				if (!class2.method_0())
				{
					obj3 = method_5(class2, cell_0);
					obj3 = Class1660.smethod_26(obj3, workbook_0.Settings.Date1904);
					if (obj3 != null && obj3 is ErrorType)
					{
						return obj3;
					}
				}
			}
			if (obj2 is double && obj3 is double)
			{
				if (obj is Struct87 @struct)
				{
					Cells cells = workbook_0.Worksheets[@struct.int_1].Cells;
					CellArea cellArea_ = @struct.cellArea_0;
					int num = (int)Class1179.ToDouble(obj2);
					int num2 = (int)Class1179.ToDouble(obj3);
					if (num == 0)
					{
						int num3 = 0;
						int num4 = 0;
						if (num2 != 0)
						{
							num2--;
							num4 = (num3 = cellArea_.StartColumn + num2);
						}
						else
						{
							num3 = cellArea_.StartColumn;
							num4 = cellArea_.EndColumn;
						}
						if (cellArea_.StartRow == cellArea_.EndRow)
						{
							Cell cell = cells.CheckCell(cellArea_.StartRow, num3);
							if (cell != null)
							{
								return method_211(cell);
							}
							return null;
						}
						string text;
						if (class1661_0.method_5() != null && (text = class1661_0.method_5().method_3()) != null && text == "OFFSET")
						{
							cellArea_.StartColumn = num3;
							cellArea_.EndColumn = num4;
							@struct.cellArea_0 = cellArea_;
							return @struct;
						}
						return CalculateRange(class1661_0, cells.method_3(), cell_0, cellArea_.StartRow, cellArea_.EndRow, num3, num4, bool_3: false, bool_4: true);
					}
					if (num2 == 0)
					{
						num--;
						int num5 = cellArea_.StartRow + num;
						if (num5 > cellArea_.EndRow)
						{
							return ErrorType.Ref;
						}
						if (cellArea_.StartColumn == cellArea_.EndColumn)
						{
							Cell cell2 = cells.CheckCell(num5, cellArea_.StartColumn);
							if (cell2 != null)
							{
								return method_211(cell2);
							}
							return null;
						}
						string text2;
						if (class1661_0.method_5() != null && (text2 = class1661_0.method_5().method_3()) != null && text2 == "OFFSET")
						{
							cellArea_.StartRow = num5;
							cellArea_.EndRow = num5;
							@struct.cellArea_0 = cellArea_;
							return @struct;
						}
						return CalculateRange(class1661_0, cells.method_3(), cell_0, num5, num5, cellArea_.StartColumn, cellArea_.EndColumn, bool_3: false);
					}
					num--;
					num2--;
					if (cellArea_.StartRow == cellArea_.EndRow && num > 0)
					{
						num2 = num;
						num = 0;
					}
					if (cellArea_.StartRow + num <= cellArea_.EndRow && cellArea_.StartColumn + num2 <= cellArea_.EndColumn)
					{
						int num6 = cellArea_.StartRow + num;
						int num7 = cellArea_.StartColumn + num2;
						if (class1661_0.method_5() != null)
						{
							string text3 = class1661_0.method_5().method_3();
							if (text3 == "()")
							{
								text3 = class1661_0.method_5().method_5().method_3();
							}
							if (text3 != null)
							{
								switch (text3)
								{
								case "OFFSET":
								case ":":
									cellArea_.StartRow = (cellArea_.EndRow = num6);
									cellArea_.StartColumn = (cellArea_.EndColumn = num7);
									@struct.cellArea_0 = cellArea_;
									return @struct;
								}
							}
						}
						Cell cell3 = cells.CheckCell(num6, num7);
						if (cell3 != null)
						{
							return method_211(cell3);
						}
						return null;
					}
					return ErrorType.Ref;
				}
				if (!(obj is Array))
				{
					if ((int)Class1179.ToDouble(obj2) == 1 && (int)Class1179.ToDouble(obj3) == 1)
					{
						return obj;
					}
					return ErrorType.Ref;
				}
				object[] array = (object[])obj;
				if (array.Length == 0)
				{
					return ErrorType.Ref;
				}
				int num8 = (int)Class1179.ToDouble(obj2);
				if (num8 == 0)
				{
					num8 = (int)Class1179.ToDouble(obj3);
					num8--;
					object[] array2 = (object[])array[0];
					if (num8 > array2.Length - 1)
					{
						return ErrorType.Ref;
					}
					if (array.Length == 1)
					{
						return array2[num8];
					}
					object[][] array3 = new object[array.Length][];
					for (int i = 0; i < array.Length; i++)
					{
						array2 = (object[])array[i];
						array3[i] = new object[1] { array2[num8] };
					}
				}
				num8--;
				if (num8 > array.Length - 1)
				{
					if (array.Length == 1)
					{
						object[] array4 = (object[])array[0];
						if (num8 < array4.Length)
						{
							return array4[num8];
						}
					}
					return ErrorType.Ref;
				}
				object obj4 = array[num8];
				array = (object[])obj4;
				num8 = (int)Class1179.ToDouble(obj3);
				if (num8 == 0)
				{
					if (array.Length == 1)
					{
						return array[0];
					}
					return new object[1] { array };
				}
				num8--;
				if (num8 > array.Length - 1)
				{
					return ErrorType.Ref;
				}
				return array[num8];
			}
			return ErrorType.Value;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_96(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count == 1)
		{
			return method_97(class1661_0, cell_0, bool_3: true);
		}
		if (class1661_0.method_7().Count == 2)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[1];
			object obj = method_5(class1661_, cell_0);
			switch (Type.GetTypeCode(obj.GetType()))
			{
			default:
				return ErrorType.Ref;
			case TypeCode.Double:
			{
				double num = (double)obj;
				if (Math.Abs(num - (double)(int)num) < double.Epsilon)
				{
					return method_97(class1661_0, cell_0, bool_3: false);
				}
				return method_97(class1661_0, cell_0, bool_3: true);
			}
			case TypeCode.Boolean:
				return method_97(class1661_0, cell_0, (bool)obj);
			}
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_97(Class1661 class1661_0, Cell cell_0, bool bool_3)
	{
		bool flag = cell_0?.IsInArray ?? false;
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		Range rangeByName;
		bool flag4;
		if (obj is string)
		{
			string text = ((string)obj).Trim();
			if (!bool_3)
			{
				if (text.IndexOf('R') == -1 && text.IndexOf('C') == -1)
				{
					return ErrorType.Ref;
				}
				text = Class1619.smethod_10(text, cell_0.Row, cell_0.Column);
			}
			if (text.IndexOf("!") != -1)
			{
				string[] array = text.Split('!');
				if (array[0] != null && !(array[0] == ""))
				{
					if (array.Length == 2)
					{
						string text2 = array[0];
						if (text2[0] == '\'')
						{
							text2 = text2.Substring(1, text2.Length - 2);
						}
						int num = workbook_0.Worksheets.method_25(text2);
						if (num == -1)
						{
							return ErrorType.Ref;
						}
						Worksheet worksheet = workbook_0.Worksheets[num];
						array[1] = array[1].ToUpper();
						if (array[1].IndexOf(":") != -1)
						{
							string[] array2 = array[1].Split(':');
							bool isRowAbsolute = false;
							bool isColumnAbsolute = false;
							bool isRowOnly = false;
							bool isColumnOnly = false;
							bool isRowAbsolute2 = false;
							bool isColumnAbsolute2 = false;
							bool isRowOnly2 = false;
							bool isColumnOnly2 = false;
							int row;
							int column;
							bool flag2 = Class1272.CellNameToIndex(array2[0], out row, out column, isInArea: true, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly);
							int row2;
							int column2;
							bool flag3 = Class1272.CellNameToIndex(array2[1], out row2, out column2, isInArea: true, ref isRowAbsolute2, ref isColumnAbsolute2, ref isRowOnly2, ref isColumnOnly2);
							if (flag2 && flag3)
							{
								if (isRowOnly == isRowOnly2 && isColumnOnly == isColumnOnly2)
								{
									if (isRowOnly)
									{
										column = 0;
									}
									if (isRowOnly2)
									{
										column2 = worksheet.Cells.method_22(0);
									}
									if (isColumnOnly)
									{
										row = 0;
									}
									if (isColumnOnly2)
									{
										row2 = worksheet.Cells.method_20(0);
									}
									return CalculateRange(class1661_0, worksheet, cell_0, row, row2, column, column2, bool_3: true);
								}
								return ErrorType.Ref;
							}
							return ErrorType.Ref;
						}
						if (Class1267.smethod_1(array[1]))
						{
							CellsHelper.CellNameToIndex(array[1].Replace("$", ""), out var row3, out var column3);
							if (class1661_0.method_5() != null)
							{
								switch (class1661_0.method_5().method_3())
								{
								case "COLUMNS":
									return 1.0;
								case "ROWS":
									return 1.0;
								case "COLUMN":
									return (double)column3 + 1.0;
								case "ROW":
									return (double)row3 + 1.0;
								case ":":
								case "OFFSET":
								{
									Struct87 @struct = default(Struct87);
									@struct.cellArea_0 = default(CellArea);
									@struct.cellArea_0.StartRow = row3;
									@struct.cellArea_0.EndRow = row3;
									@struct.cellArea_0.StartColumn = column3;
									@struct.cellArea_0.EndColumn = column3;
									@struct.int_1 = worksheet.Index;
									return @struct;
								}
								}
							}
							return method_34(null, worksheet, cell_0, row3, column3);
						}
						int[] array3 = workbook_0.Worksheets.Names.method_10(num, array[1], bool_0: false, bool_1: false);
						int num2 = array3[1];
						if (num2 != -1)
						{
							Name name = workbook_0.Worksheets.Names[num2];
							if (name.method_32())
							{
								int num3 = 0;
								int num4 = 0;
								int num5 = 0;
								int num6 = 0;
								int num7 = 0;
								int[] cellArea = name.GetCellArea(0, 0, bool_0: false);
								num3 = cellArea[0];
								num4 = cellArea[1];
								num6 = cellArea[2];
								num5 = cellArea[3];
								num7 = cellArea[4];
								int num8 = workbook_0.Worksheets.method_32().method_12(num3);
								int index = workbook_0.Worksheets.method_32().method_13(num3);
								if (class1661_0.method_5() != null)
								{
									switch (class1661_0.method_5().method_3())
									{
									case "COLUMNS":
										return (double)num7 - (double)num6 + 1.0;
									case "ROWS":
										return (double)num5 - (double)num4 + 1.0;
									case "COLUMN":
										return (double)num6 + 1.0;
									case "ROW":
										return (double)num4 + 1.0;
									case ":":
									{
										Struct87 struct2 = default(Struct87);
										struct2.cellArea_0 = default(CellArea);
										struct2.cellArea_0.StartRow = num4;
										struct2.cellArea_0.EndRow = num5;
										struct2.cellArea_0.StartColumn = num6;
										struct2.cellArea_0.EndColumn = num7;
										struct2.int_1 = index;
										return struct2;
									}
									}
								}
								if (num4 == num5 && num6 == num7)
								{
									if (num8 == workbook_0.Worksheets.method_36())
									{
										return method_34(class1661_0, workbook_0.Worksheets[index], cell_0, num4, num6);
									}
									return Class1377.smethod_3(workbook_0.Worksheets, num8, index, num4, num6);
								}
								if (num8 == workbook_0.Worksheets.method_36())
								{
									return CalculateRange(class1661_0, workbook_0.Worksheets[index], cell_0, num4, num5, num6, num7, flag, bool_4: true);
								}
								return Class1377.smethod_2(class1661_0, num8, workbook_0.Worksheets, index, num4, num6, num5, num7, hashtable_0, null);
							}
						}
					}
					return ErrorType.Ref;
				}
				return ErrorType.Ref;
			}
			if (Class1267.smethod_1(text))
			{
				CellsHelper.CellNameToIndex(text.Replace("$", ""), out var row4, out var column4);
				if (class1661_0.method_5() != null)
				{
					switch (class1661_0.method_5().method_3())
					{
					case "COLUMN":
						return (double)column4 + 1.0;
					case "ROW":
						return (double)row4 + 1.0;
					case ":":
					{
						Struct87 struct3 = default(Struct87);
						struct3.cellArea_0 = default(CellArea);
						struct3.cellArea_0.StartRow = row4;
						struct3.cellArea_0.EndRow = row4;
						struct3.cellArea_0.StartColumn = column4;
						struct3.cellArea_0.EndColumn = column4;
						struct3.int_1 = cell_0.method_4().method_3().Index;
						return struct3;
					}
					default:
						return method_34(null, cell_0.method_4().method_3(), cell_0, row4, column4);
					}
				}
				return method_34(null, cell_0.method_4().method_3(), cell_0, row4, column4);
			}
			rangeByName = workbook_0.Worksheets.GetRangeByName(text);
			if (rangeByName != null)
			{
				flag4 = false;
				if (!flag)
				{
					if (cell_0 == null)
					{
						Struct87 struct4 = default(Struct87);
						struct4.cellArea_0 = rangeByName.Area;
						struct4.int_1 = rangeByName.Worksheet.Index;
						return struct4;
					}
					if (class1661_0.method_5() != null && class1661_0.method_5().method_3() != null)
					{
						string key;
						if ((key = class1661_0.method_5().method_3()) != null)
						{
							if (Class1742.dictionary_89 == null)
							{
								Class1742.dictionary_89 = new Dictionary<string, int>(11)
								{
									{ "VLOOKUP", 0 },
									{ "HLOOKUP", 1 },
									{ "INDEX", 2 },
									{ "MATCH", 3 },
									{ "OFFSET", 4 },
									{ ":", 5 },
									{ "COUNTIF", 6 },
									{ "ROW", 7 },
									{ "COLUMN", 8 },
									{ "ROWS", 9 },
									{ "COLUMNS", 10 }
								};
							}
							if (Class1742.dictionary_89.TryGetValue(key, out var value))
							{
								switch (value)
								{
								case 3:
									if (class1661_0.method_5().method_7()[1] != class1661_0)
									{
										flag4 = true;
									}
									goto IL_0990;
								case 4:
								case 5:
								{
									Struct87 struct5 = default(Struct87);
									struct5.cellArea_0 = rangeByName.Area;
									struct5.int_1 = rangeByName.Worksheet.Index;
									return struct5;
								}
								case 6:
									break;
								case 7:
									return (double)(rangeByName.FirstRow + 1);
								case 8:
									return (double)(rangeByName.FirstColumn + 1);
								case 9:
									return (double)rangeByName.RowCount;
								case 10:
									return (double)rangeByName.ColumnCount;
								default:
									goto IL_0982;
								case 0:
								case 1:
								case 2:
									goto IL_0990;
								}
								if (class1661_0.method_5().method_7()[0] == class1661_0)
								{
									Struct87 struct6 = default(Struct87);
									struct6.cellArea_0 = rangeByName.Area;
									struct6.int_1 = rangeByName.Worksheet.Index;
									return struct6;
								}
								flag4 = true;
								goto IL_0990;
							}
						}
						goto IL_0982;
					}
					flag4 = true;
				}
				goto IL_0990;
			}
			return ErrorType.Ref;
		}
		return ErrorType.Ref;
		IL_0982:
		flag4 = Class1672.smethod_0(class1661_0, bool_0: true);
		goto IL_0990;
		IL_0990:
		if (flag4)
		{
			Cell cell = rangeByName[0, 0];
			return method_34(null, cell.method_4().method_3(), cell_0, cell.Row, cell.Column);
		}
		return method_37(class1661_0, rangeByName.Worksheet, cell_0, rangeByName.FirstRow, rangeByName.FirstRow + rangeByName.RowCount - 1, rangeByName.FirstColumn, rangeByName.FirstColumn + rangeByName.ColumnCount - 1);
	}

	private object method_98(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object object_ = method_5(class1661_, cell_0);
		return Class1660.smethod_20(object_, workbook_0.Settings.Date1904);
	}

	private object method_99(Class1661 class1661_0, Cell cell_0)
	{
		int count = class1661_0.method_7().Count;
		object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
		if (obj is double double_)
		{
			obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
			if (obj is double num)
			{
				obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
				if (obj is double num2)
				{
					if (!(num < 1.0) && num <= num2)
					{
						obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[3], cell_0), workbook_0.Settings.Date1904);
						if (obj is double double_2)
						{
							double double_3 = 0.0;
							double num3 = 0.0;
							if (count > 4)
							{
								obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[4], cell_0), workbook_0.Settings.Date1904);
								if (!(obj is double))
								{
									return obj;
								}
								double_3 = (double)obj;
								if (count > 5)
								{
									obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[5], cell_0), workbook_0.Settings.Date1904);
									if (!(obj is double))
									{
										return obj;
									}
									num3 = (double)obj;
								}
							}
							if (num3 < 0.0)
							{
								return ErrorType.Number;
							}
							return Class1378.smethod_61(double_, num, num2, double_2, double_3, num3);
						}
						return obj;
					}
					return ErrorType.Number;
				}
				return obj;
			}
			return obj;
		}
		return obj;
	}

	private object method_100(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj is Array)
		{
			Array array = (Array)obj;
			object value = array.GetValue(0);
			double num = 0.0;
			if (value is Array)
			{
				object obj2 = Class1660.smethod_26(((Array)value).GetValue(0), workbook_0.Settings.Date1904);
				if (obj2 is double double_)
				{
					ArrayList arrayList = new ArrayList();
					if (array.Length > 1)
					{
						for (int i = 1; i < array.Length; i++)
						{
							value = array.GetValue(i);
							if (!(value is Array))
							{
								continue;
							}
							object value2 = ((Array)value).GetValue(0);
							if (value2 != null)
							{
								if (value2 is ErrorType)
								{
									return value2;
								}
								switch (Type.GetTypeCode(value2.GetType()))
								{
								case TypeCode.Double:
									arrayList.Add(value2);
									break;
								case TypeCode.DateTime:
									arrayList.Add(CellsHelper.GetDoubleFromDateTime((DateTime)value2, workbook_0.Settings.Date1904));
									break;
								}
							}
						}
					}
					else
					{
						array = (Array)array.GetValue(0);
						for (int j = 1; j < array.Length; j++)
						{
							value = array.GetValue(j);
							if (value != null)
							{
								value = Class1660.smethod_26(value, workbook_0.Settings.Date1904);
								if (!(value is double))
								{
									return value;
								}
								arrayList.Add(value);
							}
						}
					}
					if (arrayList.Count < 1)
					{
						return ErrorType.Number;
					}
					double[] double_2 = (double[])arrayList.ToArray(typeof(double));
					double double_3 = 0.1;
					if (class1661_0.method_7().Count > 1)
					{
						class1661_ = (Class1661)class1661_0.method_7()[1];
						obj = method_5(class1661_, cell_0);
						if (obj is double)
						{
							double_3 = (double)obj;
						}
					}
					Class419 @class = new Class419();
					return @class.Calculate(double_, double_2, double_3);
				}
				return obj2;
			}
			return ErrorType.Number;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		if (obj is double)
		{
			if (class1661_0.method_7().Count <= 1)
			{
				return ErrorType.Number;
			}
			class1661_ = (Class1661)class1661_0.method_7()[1];
			obj = method_5(class1661_, cell_0);
			if (obj is double)
			{
				if ((double)obj + 1.0 <= double.Epsilon)
				{
					return ErrorType.Value;
				}
				return ErrorType.Number;
			}
			if (obj is ErrorType)
			{
				return obj;
			}
		}
		return ErrorType.Value;
	}

	private object method_101(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj is ErrorType)
		{
			switch ((ErrorType)obj)
			{
			case ErrorType.Div:
			case ErrorType.NA:
			case ErrorType.Name:
			case ErrorType.Null:
			case ErrorType.Number:
			case ErrorType.Ref:
			case ErrorType.Recursive:
			case ErrorType.Value:
				return true;
			}
		}
		else if (obj is Array)
		{
			Array array = (Array)obj;
			object value = array.GetValue(0);
			object[][] array2 = new object[array.Length][];
			if (value is Array)
			{
				Array array3 = (Array)value;
				int length = array3.Length;
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = new object[length];
					value = array.GetValue(i);
					if (value == null)
					{
						for (int j = 0; j < length; j++)
						{
							array2[i][j] = false;
						}
						continue;
					}
					Array array4 = (Array)value;
					for (int k = 0; k < array4.Length; k++)
					{
						object value2 = array4.GetValue(k);
						if (value2 is ErrorType)
						{
							switch ((ErrorType)value2)
							{
							default:
								array2[i][k] = false;
								break;
							case ErrorType.Div:
							case ErrorType.NA:
							case ErrorType.Name:
							case ErrorType.Null:
							case ErrorType.Number:
							case ErrorType.Ref:
							case ErrorType.Value:
								array2[i][k] = true;
								break;
							}
						}
						else
						{
							array2[i][k] = false;
						}
					}
				}
			}
			else
			{
				for (int l = 0; l < array.Length; l++)
				{
					array2[l] = new object[1];
					value = array.GetValue(l);
					if (value is ErrorType)
					{
						switch ((ErrorType)value)
						{
						default:
							array2[l][0] = false;
							break;
						case ErrorType.Div:
						case ErrorType.NA:
						case ErrorType.Name:
						case ErrorType.Null:
						case ErrorType.Number:
						case ErrorType.Ref:
						case ErrorType.Value:
							array2[l][0] = true;
							break;
						}
					}
					else
					{
						array2[l][0] = false;
					}
				}
			}
			return array2;
		}
		return false;
	}

	private object method_102(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj is ErrorType)
		{
			switch ((ErrorType)obj)
			{
			case ErrorType.Div:
			case ErrorType.NA:
			case ErrorType.Name:
			case ErrorType.Null:
			case ErrorType.Number:
			case ErrorType.Ref:
			case ErrorType.Value:
				class1661_ = (Class1661)class1661_0.method_7()[1];
				return method_5(class1661_, cell_0);
			}
		}
		return obj;
	}

	private object method_103(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj is Array)
		{
			return true;
		}
		if (obj is ErrorType)
		{
			switch ((ErrorType)obj)
			{
			case ErrorType.Div:
			case ErrorType.Name:
			case ErrorType.Null:
			case ErrorType.Number:
			case ErrorType.Ref:
			case ErrorType.Value:
				return true;
			}
		}
		return false;
	}

	private object method_104(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj is ErrorType)
		{
			return (ErrorType)obj == ErrorType.NA;
		}
		return false;
	}

	private object method_105(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return false;
		}
		if (obj is Array)
		{
			return Class1120.smethod_9(obj);
		}
		switch (Type.GetTypeCode(obj.GetType()))
		{
		default:
			return false;
		case TypeCode.Double:
		case TypeCode.DateTime:
			return true;
		}
	}

	private object method_106(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 @class = (Class1661)class1661_0.method_7()[0];
		return @class.method_9()[0] switch
		{
			21 => @class.method_7().Count, 
			17 => method_5(@class, cell_0), 
			_ => 1.0, 
		};
	}

	private object method_107(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		string key;
		if ((key = class1661_0.method_3()) != null)
		{
			if (Class1742.dictionary_90 == null)
			{
				Class1742.dictionary_90 = new Dictionary<string, int>(8)
				{
					{ "ISLOGICAL", 0 },
					{ "ISTEXT", 1 },
					{ "ISNONTEXT", 2 },
					{ "ISEVEN", 3 },
					{ "ISODD", 4 },
					{ "ERROR.TYPE", 5 },
					{ "N", 6 },
					{ "TYPE", 7 }
				};
			}
			if (Class1742.dictionary_90.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					if (obj is ErrorType)
					{
						return obj;
					}
					return obj != null && obj is bool;
				case 1:
					return Class1340.smethod_7(obj);
				case 2:
					return Class1340.smethod_6(obj);
				case 3:
					return Class1340.smethod_5(obj, workbook_0.Settings.Date1904);
				case 4:
					return Class1340.smethod_4(obj, workbook_0.Settings.Date1904);
				case 5:
					return Class1340.smethod_3(obj);
				case 6:
					return Class1340.smethod_1(obj, workbook_0.Settings.Date1904);
				case 7:
					return Class1340.smethod_0(obj);
				}
			}
		}
		return null;
	}

	private object method_108(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 @class = (Class1661)class1661_0.method_7()[0];
		if (@class.method_9() != null && @class.method_9().Length != 0)
		{
			switch (@class.method_9()[0])
			{
			case 22:
			case 23:
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 64:
			case 96:
				return false;
			default:
			{
				object obj = method_5(@class, cell_0);
				if (obj == null)
				{
					return false;
				}
				if (obj is CellArea)
				{
					return true;
				}
				return false;
			}
			case 35:
			case 67:
			case 99:
			{
				if (workbook_0.Worksheets.Names.Count == 0)
				{
					return false;
				}
				ushort num = BitConverter.ToUInt16(@class.method_9(), 1);
				Name name = workbook_0.Worksheets.Names[num - 1];
				int[] cellArea = name.GetCellArea(0, 0, bool_0: false);
				if (cellArea != null)
				{
					return true;
				}
				return false;
			}
			case 36:
			case 37:
			case 44:
			case 45:
			case 58:
			case 59:
			case 68:
			case 69:
			case 76:
			case 77:
			case 90:
			case 91:
			case 100:
			case 101:
			case 108:
			case 109:
			case 122:
			case 123:
				return true;
			}
		}
		object obj2 = method_5(@class, cell_0);
		if (obj2 == null)
		{
			return false;
		}
		if (obj2 is string)
		{
			if (@class.method_3() == "INDEX")
			{
				return true;
			}
			return false;
		}
		if (obj2 is CellArea)
		{
			return true;
		}
		if (@class.method_3() == "INDEX")
		{
			return true;
		}
		return false;
	}

	private object method_109(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return true;
		}
		return false;
	}

	private object method_110(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return 0.0;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		TypeCode typeCode = Type.GetTypeCode(obj.GetType());
		if (typeCode == TypeCode.String)
		{
			string s = (string)obj;
			try
			{
				DateTime dateTime = DateTime.Parse(s);
				double num = Math.Floor(CellsHelper.GetDoubleFromDateTime(dateTime, workbook_0.Settings.Date1904));
				if (num <= 0.0)
				{
					return ErrorType.Value;
				}
				return num;
			}
			catch
			{
				return ErrorType.Value;
			}
		}
		return ErrorType.Value;
	}

	private object method_111(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return 0.0;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		TypeCode typeCode = Type.GetTypeCode(obj.GetType());
		if (typeCode == TypeCode.String)
		{
			string s = (string)obj;
			try
			{
				DateTime dateTime = DateTime.Parse(s);
				double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime(dateTime, workbook_0.Settings.Date1904);
				if (doubleFromDateTime <= 0.0)
				{
					return ErrorType.Value;
				}
				return doubleFromDateTime - (double)(int)doubleFromDateTime;
			}
			catch
			{
				return ErrorType.Value;
			}
		}
		return ErrorType.Value;
	}

	private object method_112(Class1661 class1661_0, Cell cell_0)
	{
		object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
		if (obj is double double_)
		{
			object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
			if (obj2 is double double_2)
			{
				object obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
				if (obj3 == null)
				{
					return ErrorType.Number;
				}
				if (obj3 is string)
				{
					return Class1339.smethod_0(double_, double_2, (string)obj3, workbook_0.Settings.Date1904);
				}
				return ErrorType.Number;
			}
			return obj2;
		}
		return obj;
	}

	private object method_113(Class1661 class1661_0, Cell cell_0)
	{
		object[] array = new object[3];
		int num = 0;
		while (true)
		{
			if (num < 3)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num];
				array[num] = method_5(class1661_, cell_0);
				if (array[num] == null)
				{
					array[num] = 0.0;
				}
				else if (array[num] is ErrorType)
				{
					break;
				}
				num++;
				continue;
			}
			if (cell_0.IsInArray && array[0] is object[][] && array[1] is object[][] && array[2] is object[][])
			{
				return Class1339.smethod_13(array, workbook_0);
			}
			return Class1339.smethod_14(array, workbook_0);
		}
		return array[num];
	}

	private object method_114(Class1661 class1661_0, Cell cell_0)
	{
		object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
		if (obj is double double_)
		{
			object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
			if (obj2 is double double_2)
			{
				bool flag = false;
				if (class1661_0.method_7().Count > 2)
				{
					object obj3 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
					if (!(obj3 is double))
					{
						return obj3;
					}
					if ((double)obj3 != 0.0)
					{
						flag = true;
					}
				}
				return Class1670.smethod_1(double_, double_2, flag, workbook_0.Settings.Date1904);
			}
			return obj2;
		}
		return obj;
	}

	private object method_115(Class1661 class1661_0, Cell cell_0)
	{
		int num = 2;
		object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
		if (obj is ErrorType)
		{
			return obj;
		}
		double num2 = (double)obj;
		if (class1661_0.method_7().Count == 2)
		{
			obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
			if (obj is ErrorType)
			{
				return obj;
			}
			num = (int)Class1179.ToDouble(obj);
		}
		if (num > 127)
		{
			return ErrorType.Value;
		}
		bool flag = false;
		if (num2 < 0.0)
		{
			flag = true;
			num2 = Math.Abs(num2);
		}
		if (num >= 0)
		{
			string text = ((num != 0) ? ("#,##0." + new string('0', num)) : "#,##0");
			if (flag)
			{
				return "($" + num2.ToString(text) + ")";
			}
			return "$" + num2.ToString(text);
		}
		num2 = (double)(int)(num2 / Math.Pow(10.0, -num) + 0.5) * Math.Pow(10.0, -num);
		if (flag)
		{
			return "($" + num2 + ")";
		}
		return "$" + num2;
	}

	private double[][] method_116(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5(class1661_0, cell_0);
		if (obj == null)
		{
			return null;
		}
		if (obj is Array)
		{
			return Class1660.smethod_10(obj, workbook_0.Settings.Date1904);
		}
		return null;
	}

	private double[] method_117(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5(class1661_0, cell_0);
		if (obj == null)
		{
			return null;
		}
		obj = Class1660.smethod_13(obj, cell_0, workbook_0.Settings.Date1904, bool_1: true);
		if (obj is double[])
		{
			return (double[])obj;
		}
		return null;
	}

	private object method_118(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		double[][] array = method_116(class1661_, cell_0);
		if (array == null)
		{
			return null;
		}
		return Class1660.smethod_8(Class1664.smethod_8(array));
	}

	private object method_119(Class1661 class1661_0, Cell cell_0)
	{
		ArrayList arrayList = new ArrayList();
		int num = 0;
		object obj;
		while (true)
		{
			if (num < class1661_0.method_7().Count)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num];
				obj = method_5(class1661_, cell_0);
				if (obj != null)
				{
					obj = Class1660.smethod_14(arrayList, obj, cell_0, workbook_0.Settings.Date1904);
					if (obj != null && obj is ErrorType)
					{
						break;
					}
				}
				num++;
				continue;
			}
			double[] array = new double[arrayList.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (double)arrayList[i];
			}
			switch (class1661_0.method_3())
			{
			case "MEDIAN":
			{
				int count = arrayList.Count;
				if (count == 0)
				{
					return ErrorType.Number;
				}
				arrayList.Sort();
				if (count % 2 == 0)
				{
					double num2 = (double)arrayList[count / 2 - 1];
					double num3 = (double)arrayList[count / 2];
					return (num2 + num3) / 2.0;
				}
				return arrayList[count / 2];
			}
			case "LCM":
				return Class1341.smethod_10(array);
			case "GCD":
				return Class1341.smethod_11(array);
			default:
				return ErrorType.Name;
			}
		}
		return obj;
	}

	private object method_120(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return ErrorType.Value;
		}
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		object obj2 = method_5(class1661_2, cell_0);
		if (obj2 == null)
		{
			return ErrorType.Value;
		}
		if (obj is Array)
		{
			if (obj2 is Array)
			{
				Array array_ = (Array)obj;
				Array array_2 = (Array)obj2;
				if (Class1120.smethod_11(array_, array_2))
				{
					ArrayList arrayList = new ArrayList();
					ArrayList arrayList2 = new ArrayList();
					object obj3 = Class1120.smethod_12(workbook_0, array_, array_2, arrayList, arrayList2);
					if (obj3 != null)
					{
						return obj3;
					}
					if (arrayList.Count < 2)
					{
						return ErrorType.Div;
					}
					return Class1664.smethod_9(arrayList, arrayList2);
				}
				return ErrorType.NA;
			}
			return ErrorType.NA;
		}
		obj = Class1660.smethod_26(obj, workbook_0.Settings.Date1904);
		if (obj is ErrorType)
		{
			return obj;
		}
		if (obj2 is Array)
		{
			return ErrorType.NA;
		}
		obj2 = Class1660.smethod_26(obj2, workbook_0.Settings.Date1904);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		return ErrorType.Div;
	}

	private object method_121(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		double[] array = method_117(class1661_, cell_0);
		if (array == null)
		{
			return null;
		}
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		double[] array2 = method_117(class1661_2, cell_0);
		if (array2 == null)
		{
			return null;
		}
		if (array.Length != array2.Length)
		{
			return ErrorType.NA;
		}
		return Class1664.smethod_11(array, array2);
	}

	private object method_122(Class1661 class1661_0, Cell cell_0)
	{
		object object_ = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		object object_2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
		return Class1669.smethod_15(object_, object_2, workbook_0.Settings);
	}

	private object method_123(Class1661 class1661_0, Cell cell_0)
	{
		int count = class1661_0.method_7().Count;
		object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
		if (obj is double double_)
		{
			obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
			if (obj is double num)
			{
				obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
				if (obj is double num2)
				{
					if (!(num < 1.0) && num <= num2)
					{
						obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[3], cell_0), workbook_0.Settings.Date1904);
						if (obj is double double_2)
						{
							double double_3 = 0.0;
							double num3 = 0.0;
							if (count > 4)
							{
								obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[4], cell_0), workbook_0.Settings.Date1904);
								if (!(obj is double))
								{
									return obj;
								}
								double_3 = (double)obj;
								if (count > 5)
								{
									obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[5], cell_0), workbook_0.Settings.Date1904);
									if (!(obj is double))
									{
										return obj;
									}
									num3 = (double)obj;
									if (num3 != 0.0)
									{
										num3 = 1.0;
									}
								}
							}
							return Class1378.smethod_60(double_, num, num2, double_2, double_3, num3);
						}
						return obj;
					}
					return ErrorType.Number;
				}
				return obj;
			}
			return obj;
		}
		return obj;
	}

	private object method_124(Class1661 class1661_0, Cell cell_0)
	{
		double num = 1.0;
		bool flag = true;
		int num2 = 0;
		object obj;
		while (true)
		{
			if (num2 < class1661_0.method_7().Count)
			{
				Class1661 @class = (Class1661)class1661_0.method_7()[num2];
				obj = method_5(@class, cell_0);
				if (obj != null)
				{
					if (obj is ErrorType)
					{
						break;
					}
					switch (Type.GetTypeCode(obj.GetType()))
					{
					case TypeCode.Double:
					{
						double doubleFromDateTime = (double)obj;
						if (doubleFromDateTime != 0.0)
						{
							num *= doubleFromDateTime;
							if (flag)
							{
								flag = false;
							}
							break;
						}
						return 0;
					}
					case TypeCode.DateTime:
					{
						double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904);
						if (doubleFromDateTime != 0.0)
						{
							num *= doubleFromDateTime;
							if (flag)
							{
								flag = false;
							}
							break;
						}
						return 0;
					}
					case TypeCode.String:
						if (@class.method_9()[0] != 23)
						{
							break;
						}
						if (Class1677.smethod_20((string)obj))
						{
							try
							{
								num *= double.Parse((string)obj);
								if (flag)
								{
									flag = false;
								}
							}
							catch
							{
								return ErrorType.Value;
							}
							break;
						}
						return ErrorType.Value;
					case TypeCode.Object:
					{
						if (!(obj is Array))
						{
							break;
						}
						Array array = (Array)obj;
						for (int i = 0; i < array.Length; i++)
						{
							Array array2 = (Array)array.GetValue(i);
							for (int j = 0; j < array2.Length; j++)
							{
								obj = array2.GetValue(j);
								if (obj == null)
								{
									continue;
								}
								if (!(obj is ErrorType))
								{
									switch (Type.GetTypeCode(obj.GetType()))
									{
									case TypeCode.Double:
									{
										double doubleFromDateTime = (double)obj;
										if (doubleFromDateTime != 0.0)
										{
											num *= doubleFromDateTime;
											if (flag)
											{
												flag = false;
											}
											break;
										}
										return 0;
									}
									case TypeCode.DateTime:
									{
										double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904);
										if (doubleFromDateTime != 0.0)
										{
											num *= doubleFromDateTime;
											if (flag)
											{
												flag = false;
											}
											break;
										}
										return 0;
									}
									}
									continue;
								}
								return obj;
							}
						}
						break;
					}
					}
				}
				num2++;
				continue;
			}
			if (flag)
			{
				return 0.0;
			}
			return num;
		}
		return obj;
	}

	private object method_125(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		double[] array = method_117(class1661_, cell_0);
		if (array == null)
		{
			return null;
		}
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		double[] array2 = method_117(class1661_2, cell_0);
		if (array2 == null)
		{
			return null;
		}
		if (array.Length != array2.Length)
		{
			return ErrorType.NA;
		}
		object obj = Class1664.smethod_11(array, array2);
		if (obj is ErrorType)
		{
			return obj;
		}
		return (double)obj * (double)obj;
	}

	private object method_126(Class1661 class1661_0, Cell cell_0)
	{
		object object_ = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		object object_2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
		return Class1669.smethod_16(object_, object_2, workbook_0.Settings);
	}

	private object method_127(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 2 || class1661_0.method_7().Count == 3))
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object obj = method_5(class1661_, cell_0);
			Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
			object obj2 = method_5(class1661_2, cell_0);
			if (obj2 is object[][])
			{
				object[][] array = (object[][])obj2;
				if (obj is double)
				{
					object[] array2 = array[0];
					ArrayList arrayList = new ArrayList();
					for (int i = 0; i < array.Length; i++)
					{
						for (int j = 0; j < array2.Length; j++)
						{
							object obj3 = array[i][j];
							if (obj3 is double)
							{
								arrayList.Add(obj3);
							}
						}
					}
					arrayList.Sort();
					double num = (double)obj;
					int num2 = 0;
					while (true)
					{
						if (num2 < arrayList.Count)
						{
							double num3 = (double)arrayList[num2];
							if (num3 == num)
							{
								break;
							}
							num2++;
							continue;
						}
						return ErrorType.NA;
					}
					if (class1661_0.method_7().Count == 3)
					{
						Class1661 class1661_3 = (Class1661)class1661_0.method_7()[2];
						object obj4 = method_5(class1661_3, cell_0);
						if (obj4 is double)
						{
							if ((int)Class1179.ToDouble(obj4) == 0)
							{
								for (num2++; num2 < arrayList.Count; num2++)
								{
									double num3 = (double)arrayList[num2];
									if (num3 != num)
									{
										break;
									}
								}
								return (double)(arrayList.Count - num2 + 1);
							}
							return (double)(num2 + 1);
						}
						return ErrorType.Value;
					}
					for (num2++; num2 < arrayList.Count; num2++)
					{
						double num3 = (double)arrayList[num2];
						if (num3 != num)
						{
							break;
						}
					}
					return (double)(arrayList.Count - num2 + 1);
				}
				return ErrorType.Value;
			}
			return ErrorType.Number;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_128(Class1661 class1661_0, Cell cell_0)
	{
		int count = class1661_0.method_7().Count;
		if (class1661_0.method_7() != null && count >= 3 && count <= 6)
		{
			object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
			if (obj is double num)
			{
				double num2 = 0.0;
				double double_ = 0.0;
				bool flag = false;
				object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj2 is double num3)
				{
					if (num3 >= 0.0 && count > 3)
					{
						object obj3 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[3], cell_0), workbook_0.Settings.Date1904);
						if (!(obj3 is double))
						{
							return obj3;
						}
						double_ = (double)obj3;
						flag = true;
					}
					double num4 = 0.0;
					object obj4 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
					if (obj4 is double double_2)
					{
						if (count > 3 && !flag)
						{
							object obj5 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[3], cell_0), workbook_0.Settings.Date1904);
							if (!(obj5 is double))
							{
								return obj5;
							}
							double_ = (double)obj5;
						}
						double num5 = 0.0;
						if (count > 4)
						{
							object obj6 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[4], cell_0), workbook_0.Settings.Date1904);
							if (!(obj6 is double))
							{
								return obj6;
							}
							num5 = (double)obj6;
							if (num5 != 0.0)
							{
								num5 = 1.0;
							}
						}
						double num6 = 0.1;
						if (count > 5)
						{
							object obj7 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[5], cell_0), workbook_0.Settings.Date1904);
							if (!(obj7 is double))
							{
								return obj7;
							}
							num6 = (double)obj7;
							if (num6 == 0.0)
							{
								num6 = 0.1;
							}
						}
						if (num == 0.0)
						{
							return ErrorType.Number;
						}
						if (num6 <= -1.0)
						{
							return ErrorType.Value;
						}
						return Class1378.smethod_63(num, num3, double_2, double_, num5, num6);
					}
					return obj4;
				}
				return obj2;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_129(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[1];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return null;
		}
		if (obj is Array)
		{
			double[][] array = Class1660.smethod_10(obj, workbook_0.Settings.Date1904);
			double[] array2 = array[0];
			int num = array.Length;
			int num2 = array2.Length;
			double[] array3 = new double[num * num2];
			for (int i = 0; i < num; i++)
			{
				array2 = array[i];
				for (int j = 0; j < num2; j++)
				{
					array3[i * num2 + j] = array2[j];
				}
			}
			class1661_ = (Class1661)class1661_0.method_7()[0];
			double[][] array4 = Class1660.smethod_10(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
			object[][] array5 = Class1664.smethod_0(array3, array4);
			object[][] array6 = new object[7][];
			int num3 = array4[0].Length;
			for (int k = 0; k < 7; k++)
			{
				array6[k] = new object[num3];
				switch (k)
				{
				case 0:
					array6[0][0] = "Regressn Array ... 7 Rows x " + num3 + " Columns";
					break;
				case 1:
				{
					for (int m = 0; m < num3; m++)
					{
						array6[1][m] = "X(" + (m + 1) + ") Coefficient";
					}
					break;
				}
				case 2:
				{
					for (int l = 0; l < num3; l++)
					{
						array6[2][l] = array5[0][num3 - l - 1];
					}
					break;
				}
				case 3:
					array6[3][0] = "Intercept";
					break;
				case 4:
					array6[4][0] = array5[0][num3];
					break;
				case 5:
					array6[5][0] = "Std Error";
					break;
				case 6:
					array6[6][0] = array5[2][1];
					break;
				}
			}
			return array6;
		}
		return null;
	}

	private object method_130(Class1661 class1661_0, Cell cell_0)
	{
		double[][] array = null;
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return null;
		}
		if (obj is Array)
		{
			double[][] array2 = Class1660.smethod_10(obj, workbook_0.Settings.Date1904);
			double[] array3 = array2[0];
			int num = array2.Length;
			int num2 = array3.Length;
			double[] array4 = new double[num * num2];
			for (int i = 0; i < num; i++)
			{
				array3 = array2[i];
				for (int j = 0; j < num2; j++)
				{
					array4[i * num2 + j] = array3[j];
				}
			}
			int num3 = 0;
			while (true)
			{
				if (num3 < array4.Length)
				{
					if (!(array4[num3] > 0.0))
					{
						break;
					}
					array4[num3] = Math.Log(array4[num3]);
					num3++;
					continue;
				}
				if (class1661_0.method_7().Count > 1)
				{
					class1661_ = (Class1661)class1661_0.method_7()[1];
					array = Class1660.smethod_10(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
				}
				if (array != null && array.Length != 0)
				{
					if (array.Length == 1 && array[0].Length == array4.Length)
					{
						array = Class1664.smethod_4(array);
					}
				}
				else
				{
					array = new double[array4.Length][];
					for (int k = 0; k < array4.Length; k++)
					{
						array[k] = new double[1];
						array[k][0] = k + 1;
					}
				}
				object[][] array5 = Class1664.smethod_0(array4, array);
				for (int l = 0; l < array5[0].Length; l++)
				{
					array5[0][l] = Math.Exp((double)array5[0][l]);
				}
				for (int m = 2; m < 5; m++)
				{
					object[] array6 = array5[m];
					for (int n = 2; n < array6.Length; n++)
					{
						array6[n] = "#N/A";
					}
				}
				return array5;
			}
			return ErrorType.Number;
		}
		return null;
	}

	private object method_131(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj == null)
		{
			return null;
		}
		object obj2 = Class1660.smethod_13(obj, cell_0, workbook_0.Settings.Date1904, bool_1: true);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		double[] double_ = (double[])obj2;
		obj = method_5((Class1661)class1661_0.method_7()[1], cell_0);
		if (obj == null)
		{
			return null;
		}
		object obj3 = Class1660.smethod_13(obj, cell_0, workbook_0.Settings.Date1904, bool_1: true);
		if (obj3 is ErrorType)
		{
			return obj3;
		}
		double[] double_2 = (double[])obj3;
		object obj4 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
		if (obj4 is ErrorType)
		{
			return obj4;
		}
		double double_3 = (double)obj4;
		if (class1661_0.method_7().Count > 3)
		{
			object obj5 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[3], cell_0), workbook_0.Settings.Date1904);
			if (obj5 is ErrorType)
			{
				return obj5;
			}
			double double_4 = (double)obj5;
			return Class1668.smethod_48(double_, double_2, double_3, double_4);
		}
		return Class1668.smethod_49(double_, double_2, double_3);
	}

	private object method_132(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj == null)
		{
			return null;
		}
		obj = Class1660.smethod_13(obj, cell_0, workbook_0.Settings.Date1904, bool_1: true);
		if (obj is ErrorType)
		{
			return obj;
		}
		double[] double_ = (double[])obj;
		obj = method_5((Class1661)class1661_0.method_7()[1], cell_0);
		if (obj == null)
		{
			return null;
		}
		obj = Class1660.smethod_13(obj, cell_0, workbook_0.Settings.Date1904, bool_1: true);
		if (obj is ErrorType)
		{
			return obj;
		}
		double[] double_2 = (double[])obj;
		object obj2 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		int num = (int)Class1179.ToDouble(obj2);
		if (num != 1 && num != 2)
		{
			return ErrorType.Number;
		}
		object obj3 = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[3], cell_0), workbook_0.Settings.Date1904);
		if (obj3 is ErrorType)
		{
			return obj3;
		}
		int num2 = (int)Class1179.ToDouble(obj3);
		switch (num2)
		{
		default:
			return ErrorType.Number;
		case 1:
		case 2:
		case 3:
			return Class1342.smethod_9(double_, double_2, num, num2);
		}
	}

	private object method_133(Class1661 class1661_0, Cell cell_0, int int_3)
	{
		object[] array = new object[int_3];
		int num = 0;
		object object_;
		while (true)
		{
			if (num < int_3)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num];
				object_ = method_5(class1661_, cell_0);
				object_ = Class1660.smethod_11(object_, workbook_0.Settings.Date1904);
				if (object_ != null && object_ is ErrorType)
				{
					break;
				}
				array[num] = object_;
				num++;
				continue;
			}
			double[][] array2 = (double[][])array[0];
			double[][] array3 = null;
			if (int_3 > 1)
			{
				array3 = (double[][])array[1];
			}
			switch (class1661_0.method_3())
			{
			case "MMULT":
				if (array2[0].Length != array3.Length)
				{
					return ErrorType.Value;
				}
				return Class1660.smethod_8(Class1664.smethod_6(array2, array3));
			case "MINVERSE":
				return Class1660.smethod_8(Class1664.smethod_3(array2));
			case "MDETERM":
				if (array2 == null)
				{
					return null;
				}
				if (array2.Length != array2[0].Length)
				{
					return ErrorType.Value;
				}
				return Class1664.smethod_12(array2);
			case "CHITEST":
				return Class1668.smethod_59(array2, array3);
			default:
				return null;
			}
		}
		return object_;
	}

	private object method_134(Class1661 class1661_0, Cell cell_0)
	{
		double[][] array = null;
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return null;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		if (obj is Array)
		{
			double[][] array2 = Class1660.smethod_10(obj, workbook_0.Settings.Date1904);
			double[] array3 = array2[0];
			int num = array2.Length;
			int num2 = array3.Length;
			double[] array4 = new double[num * num2];
			for (int i = 0; i < num; i++)
			{
				array3 = array2[i];
				for (int j = 0; j < num2; j++)
				{
					array4[i * num2 + j] = array3[j];
				}
			}
			object obj2 = null;
			if (class1661_0.method_7().Count > 1)
			{
				class1661_ = (Class1661)class1661_0.method_7()[1];
				obj2 = method_5(class1661_, cell_0);
				if (obj2 != null && obj2 is ErrorType)
				{
					return obj2;
				}
			}
			bool flag = false;
			if (class1661_0.method_7().Count > 3)
			{
				class1661_ = (Class1661)class1661_0.method_7()[3];
				object obj3 = method_5(class1661_, cell_0);
				if (obj3 != null && obj3 is bool)
				{
					flag = (bool)obj3;
				}
			}
			if (obj2 != null)
			{
				array = Class1660.smethod_10(obj2, workbook_0.Settings.Date1904);
			}
			if (array != null && array.Length != 0)
			{
				if (array.Length == 1 && array[0].Length == array4.Length)
				{
					array = Class1664.smethod_4(array);
				}
				else if (array.Length != array4.Length)
				{
					return ErrorType.Ref;
				}
			}
			else
			{
				array = new double[array4.Length][];
				for (int k = 0; k < array4.Length; k++)
				{
					array[k] = new double[1];
					array[k][0] = k + 1;
				}
			}
			object[][] array5 = Class1664.smethod_0(array4, array);
			if (cell_0 != null && !cell_0.IsInArray && !flag)
			{
				object[] array6 = array5[0];
				array5 = new object[array6.Length][];
				for (int l = 0; l < array6.Length; l++)
				{
					array5[l] = new object[1] { array6[l] };
				}
				return array5;
			}
			for (int m = 2; m < 5; m++)
			{
				object[] array7 = array5[m];
				for (int n = 2; n < array7.Length; n++)
				{
					array7[n] = "#N/A";
				}
			}
			return array5;
		}
		return null;
	}

	private object method_135(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj is Array)
		{
			if (obj is double[][])
			{
				return Class1664.smethod_4((double[][])obj);
			}
			return Class1664.smethod_5((object[][])obj);
		}
		return obj;
	}

	private object method_136(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return null;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		if (obj is Array)
		{
			double[][] array = Class1660.smethod_10(obj, workbook_0.Settings.Date1904);
			double[] array2 = array[0];
			int num = array.Length;
			int num2 = array2.Length;
			double[] array3 = new double[num * num2];
			for (int i = 0; i < num; i++)
			{
				array2 = array[i];
				for (int j = 0; j < num2; j++)
				{
					array3[i * num2 + j] = array2[j];
				}
			}
			double[][] array4 = null;
			if (class1661_0.method_7().Count > 2)
			{
				class1661_ = (Class1661)class1661_0.method_7()[2];
				object obj2 = method_5(class1661_, cell_0);
				if (obj2 != null && obj2 is ErrorType)
				{
					return obj2;
				}
				array4 = Class1660.smethod_10(obj2, workbook_0.Settings.Date1904);
			}
			bool flag = true;
			if (class1661_0.method_7().Count > 3)
			{
				class1661_ = (Class1661)class1661_0.method_7()[3];
				object obj3 = method_5(class1661_, cell_0);
				if (obj3 != null && obj3 is bool)
				{
					flag = (bool)obj3;
				}
			}
			double[][] array5 = null;
			if (class1661_0.method_7().Count > 1)
			{
				class1661_ = (Class1661)class1661_0.method_7()[1];
				object obj4 = method_5(class1661_, cell_0);
				if (obj4 != null && obj4 is ErrorType)
				{
					return obj4;
				}
				array5 = Class1660.smethod_10(obj4, workbook_0.Settings.Date1904);
			}
			double[] array6;
			if (array5 != null && array5.Length != 0)
			{
				if (array5.Length == array3.Length && array5[0].Length == 1)
				{
					array5 = Class1664.smethod_4(array5);
				}
				array6 = array5[0];
				if (array6 == null || array6.Length == 0)
				{
					array6 = new double[array3.Length];
					for (int k = 0; k < array3.Length; k++)
					{
						array6[k] = k + 1;
					}
				}
			}
			else
			{
				array6 = new double[array3.Length];
				for (int l = 0; l < array3.Length; l++)
				{
					array6[l] = l + 1;
				}
				array5 = new double[1][] { array6 };
			}
			if (array6.Length != array3.Length)
			{
				return ErrorType.Ref;
			}
			double[] array7 = Class1664.smethod_1(array3, array6, flag);
			if (array4 == null)
			{
				array4 = array5;
			}
			object[][] array8 = new object[array4.Length][];
			for (int m = 0; m < array4.Length; m++)
			{
				if (array4 != null && array4.Length != 0)
				{
					array8[m] = new object[array4[m].Length];
					for (int n = 0; n < array4[m].Length; n++)
					{
						array8[m][n] = array7[0] * array4[m][n] + array7[1];
					}
				}
			}
			return array8;
		}
		return null;
	}

	private object method_137(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return null;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		if (obj is Array)
		{
			double[][] array = Class1660.smethod_10(obj, workbook_0.Settings.Date1904);
			double[] array2 = array[0];
			int num = array.Length;
			int num2 = array2.Length;
			double[] array3 = new double[num * num2];
			for (int i = 0; i < num; i++)
			{
				array2 = array[i];
				for (int j = 0; j < num2; j++)
				{
					array3[i * num2 + j] = array2[j];
				}
			}
			object obj2 = null;
			if (class1661_0.method_7().Count > 1)
			{
				class1661_ = (Class1661)class1661_0.method_7()[1];
				obj2 = method_5(class1661_, cell_0);
				if (obj2 != null && obj2 is ErrorType)
				{
					return obj2;
				}
			}
			double[][] array4 = null;
			if (class1661_0.method_7().Count > 2)
			{
				class1661_ = (Class1661)class1661_0.method_7()[2];
				object obj3 = method_5(class1661_, cell_0);
				if (obj3 != null && obj3 is ErrorType)
				{
					return obj3;
				}
				array4 = Class1660.smethod_10(obj3, workbook_0.Settings.Date1904);
			}
			bool flag = true;
			if (class1661_0.method_7().Count > 3)
			{
				class1661_ = (Class1661)class1661_0.method_7()[3];
				object obj4 = method_5(class1661_, cell_0);
				if (obj4 != null && obj4 is bool)
				{
					flag = (bool)obj4;
				}
			}
			double[][] array5 = null;
			if (obj2 != null)
			{
				array5 = Class1660.smethod_10(obj2, workbook_0.Settings.Date1904);
			}
			double[] array6;
			if (array5 != null && array5.Length != 0)
			{
				if (array5.Length == array3.Length && array5[0].Length == 1)
				{
					array5 = Class1664.smethod_4(array5);
				}
				array6 = array5[0];
				if (array6 == null || array6.Length == 0)
				{
					array6 = new double[array3.Length];
					for (int k = 0; k < array3.Length; k++)
					{
						array6[k] = k + 1;
					}
				}
			}
			else
			{
				array6 = new double[array3.Length];
				for (int l = 0; l < array3.Length; l++)
				{
					array6[l] = l + 1;
				}
			}
			if (array6.Length != array3.Length)
			{
				return ErrorType.Ref;
			}
			for (int m = 0; m < array3.Length; m++)
			{
				array3[m] = Math.Log(array3[m]);
			}
			double[] array7 = Class1664.smethod_1(array3, array6, flag);
			if (array4 == null)
			{
				array4 = array5;
				if (array4 == null)
				{
					array4 = new double[1][] { new double[array3.Length] };
					for (int n = 0; n < array3.Length; n++)
					{
						array4[0][n] = n + 1;
					}
				}
			}
			object[][] array8 = new object[array4.Length][];
			for (int num3 = 0; num3 < array4.Length; num3++)
			{
				if (array4 != null && array4.Length != 0)
				{
					array8[num3] = new object[array4[num3].Length];
					for (int num4 = 0; num4 < array4[num3].Length; num4++)
					{
						array8[num3][num4] = Math.Exp(array7[0] * array4[num3][num4] + array7[1]);
					}
				}
			}
			return array8;
		}
		return null;
	}

	private object method_138(Class1661 class1661_0, Cell cell_0)
	{
		double[][][] array = new double[class1661_0.method_7().Count][][];
		int num = 0;
		object obj;
		while (true)
		{
			if (num < class1661_0.method_7().Count)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num];
				obj = method_5(class1661_, cell_0);
				if (obj != null && obj is ErrorType)
				{
					break;
				}
				double[][] array2 = Class1660.smethod_10(obj, workbook_0.Settings.Date1904);
				if (array2 != null)
				{
					int num2 = array2[0].Length;
					if (class1661_0.method_7().Count == 1)
					{
						double num3 = 0.0;
						for (int i = 0; i < array2.Length; i++)
						{
							for (int j = 0; j < num2; j++)
							{
								num3 += array2[i][j];
							}
						}
					}
					array[num] = array2;
				}
				num++;
				continue;
			}
			int num4 = -1;
			int num5 = 0;
			while (true)
			{
				if (num5 < array.Length)
				{
					double[][] array3 = array[num5];
					if (num5 == 0)
					{
						num4 = array3.Length;
					}
					else if (num4 != array3.Length)
					{
						break;
					}
					num5++;
					continue;
				}
				return Class1664.smethod_7(array);
			}
			return ErrorType.Value;
		}
		return obj;
	}

	private object method_139(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		double[] array = method_117(class1661_, cell_0);
		if (array == null)
		{
			return null;
		}
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		double[] array2 = method_117(class1661_2, cell_0);
		if (array2 == null)
		{
			return null;
		}
		bool isError = false;
		return Class1660.smethod_8(Class1668.smethod_21(array, array2, out isError));
	}

	private object method_140(Class1661 class1661_0, Cell cell_0)
	{
		double num = 1.0;
		int num2 = 0;
		int num3 = 0;
		while (true)
		{
			if (num3 < class1661_0.method_7().Count)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num3];
				object obj = method_5(class1661_, cell_0);
				if (obj is Array)
				{
					ArrayList arrayList = new ArrayList();
					obj = Class1660.smethod_15(arrayList, obj, cell_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, workbook_0.Settings.Date1904, bool_5: false);
					if (obj is ErrorType)
					{
						return obj;
					}
					for (int i = 0; i < arrayList.Count; i++)
					{
						num *= (double)arrayList[i];
					}
					num2 += arrayList.Count;
				}
				else
				{
					obj = ((obj != null) ? Class1660.smethod_9(workbook_0, obj, bool_0: false) : ((object)0.0));
					if (obj is ErrorType)
					{
						return obj;
					}
					double num4 = (double)obj;
					if (num4 == 0.0)
					{
						return 0.0;
					}
					if (!(num4 >= 0.0))
					{
						break;
					}
					num *= num4;
					num2++;
				}
				num3++;
				continue;
			}
			if (num2 == 0)
			{
				return ErrorType.Number;
			}
			return Math.Pow(num, 1.0 / (double)num2);
		}
		return ErrorType.Number;
	}

	private object method_141(Class1661 class1661_0, Cell cell_0)
	{
		object object_ = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		object obj = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
		if (obj == null)
		{
			obj = 0.0;
		}
		else if (obj is ErrorType)
		{
			return obj;
		}
		object object_2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
		object object_3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
		object obj2 = Class1660.smethod_12(object_2, object_3, workbook_0.Settings);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		object[] array = (object[])obj2;
		return Class1668.smethod_22((double)obj, (double[])array[0], (double[])array[1]);
	}

	private object method_142(Class1661 class1661_0, Cell cell_0)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = 0;
		int num5 = 0;
		object obj;
		while (true)
		{
			if (num5 < class1661_0.method_7().Count)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num5];
				obj = method_5(class1661_, cell_0);
				if (obj is ErrorType)
				{
					break;
				}
				if (obj is double num6)
				{
					num3 += num6;
					num2 += num6 * num6;
					num4++;
				}
				else if (obj is Array)
				{
					Array array = (Array)obj;
					foreach (object item in array)
					{
						if (!(item is Array))
						{
							continue;
						}
						Array array2 = (Array)item;
						foreach (object item2 in array2)
						{
							if (item2 is double num7)
							{
								num3 += num7;
								num2 += num7 * num7;
								num4++;
							}
						}
					}
				}
				num5++;
				continue;
			}
			if (num4 < 2)
			{
				return ErrorType.Div;
			}
			num = Math.Sqrt(((double)num4 * num2 - num3 * num3) / (double)(num4 * (num4 - 1)));
			return num;
		}
		return obj;
	}

	private object method_143(Class1661 class1661_0, Cell cell_0)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = 0;
		int num5 = 0;
		object obj;
		while (true)
		{
			if (num5 < class1661_0.method_7().Count)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num5];
				obj = method_5(class1661_, cell_0);
				if (obj is ErrorType)
				{
					break;
				}
				if (obj is double num6)
				{
					num3 += num6;
					num2 += num6 * num6;
					num4++;
				}
				else if (obj is Array)
				{
					Array array = (Array)obj;
					foreach (object item in array)
					{
						if (!(item is Array))
						{
							continue;
						}
						Array array2 = (Array)item;
						foreach (object item2 in array2)
						{
							if (item2 is double num7)
							{
								num3 += num7;
								num2 += num7 * num7;
								num4++;
							}
						}
					}
				}
				num5++;
				continue;
			}
			if (num4 < 1)
			{
				return ErrorType.Div;
			}
			num = Math.Sqrt(((double)num4 * num2 - num3 * num3) / (double)(num4 * num4));
			return num;
		}
		return obj;
	}

	private object method_144(Class1661 class1661_0, Struct87 struct87_0, Cell cell_0)
	{
		return method_37(class1661_0, workbook_0.Worksheets[struct87_0.int_1], cell_0, struct87_0.cellArea_0.StartRow, struct87_0.cellArea_0.EndRow, struct87_0.cellArea_0.StartColumn, struct87_0.cellArea_0.EndColumn);
	}

	private object method_145(Class1661 class1661_0, Cell cell_0)
	{
		double num = 0.0;
		int num2 = 0;
		object obj;
		while (true)
		{
			if (num2 < class1661_0.method_7().Count)
			{
				Class1661 @class = (Class1661)class1661_0.method_7()[num2];
				obj = method_5(@class, cell_0);
				if (obj != null)
				{
					if (obj is ErrorType)
					{
						return obj;
					}
					bool flag = true;
					if (obj is Struct87 struct87_)
					{
						obj = method_144(class1661_0, struct87_, cell_0);
						flag = true;
					}
					else if (@class.method_9() != null)
					{
						Enum180 type = @class.Type;
						if (type == Enum180.const_2)
						{
							switch (@class.method_9()[0])
							{
							default:
								flag = false;
								break;
							case 16:
							case 17:
								break;
							}
						}
						else
						{
							switch (@class.method_9()[0])
							{
							case 11:
							case 23:
							case 29:
							case 33:
							case 34:
								flag = false;
								break;
							}
						}
					}
					if (obj is object[][])
					{
						object[][] array = (object[][])obj;
						foreach (object[] array2 in array)
						{
							if (array2 == null)
							{
								continue;
							}
							for (int j = 0; j < array2.Length; j++)
							{
								if (array2[j] != null)
								{
									if (array2[j] is ErrorType)
									{
										return array2[j];
									}
									object obj2 = Class1660.smethod_9(workbook_0, array2[j], flag);
									if (obj2 is ErrorType)
									{
										return obj2;
									}
									num += (double)obj2;
								}
							}
						}
					}
					else
					{
						obj = Class1660.smethod_9(workbook_0, obj, flag);
						if (obj is ErrorType)
						{
							break;
						}
						num += (double)obj;
					}
				}
				num2++;
				continue;
			}
			return num;
		}
		return obj;
	}

	private object method_146(Class1661 class1661_0, Cell cell_0)
	{
		int num = 0;
		switch (class1661_0.method_3())
		{
		case "COUNTIF":
			num = 2;
			break;
		case "AVERAGEIF":
			num = 1;
			break;
		case "SUMIF":
			num = 0;
			break;
		}
		object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		bool flag = cell_0?.IsInArray ?? false;
		object[] object_ = new object[1] { obj };
		string[] array = new string[1];
		object[] array2 = new object[1];
		object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
		object obj3 = obj;
		if (class1661_0.method_7().Count == 3)
		{
			obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
			if (obj3 is ErrorType)
			{
				return obj3;
			}
		}
		if (obj2 == null)
		{
			return 0.0;
		}
		if (obj2 is ErrorType)
		{
			obj2 = Class1673.smethod_4((ErrorType)obj2);
		}
		else
		{
			if (flag && obj2 is Array)
			{
				Array array3 = (Array)obj2;
				string[][] array4 = new string[array3.Length][];
				object[][] array5 = new object[array3.Length][];
				int num2 = 0;
				object stringValue;
				while (true)
				{
					if (num2 < array3.Length)
					{
						object value = array3.GetValue(num2);
						if (value != null)
						{
							if (value is Array)
							{
								Array array6 = (Array)value;
								array4[num2] = new string[array6.Length];
								array5[num2] = new object[array6.Length];
								for (int i = 0; i < array6.Length; i++)
								{
									object value2 = array6.GetValue(i);
									value2 = Class1660.GetStringValue(value2);
									if (!(value2 is ErrorType))
									{
										string string_ = (string)value2;
										object[] array7 = Class1662.smethod_6(string_);
										array4[num2][0] = (string)array7[0];
										array5[num2][0] = array7[1];
										continue;
									}
									return value2;
								}
							}
							else
							{
								array4[num2] = new string[1];
								array5[num2] = new object[1];
								stringValue = Class1660.GetStringValue(value);
								if (stringValue is ErrorType)
								{
									break;
								}
								string string_2 = (string)stringValue;
								object[] array8 = Class1662.smethod_6(string_2);
								array4[num2][0] = (string)array8[0];
								array5[num2][0] = array8[1];
							}
						}
						num2++;
						continue;
					}
					return Class1269.smethod_7(this, workbook_0.Worksheets, cell_0, obj3, object_, array4, array5, num);
				}
				return stringValue;
			}
			object stringValue2 = Class1660.GetStringValue(obj2);
			if (stringValue2 is ErrorType)
			{
				return stringValue2;
			}
			string string_3 = (string)stringValue2;
			object[] array9 = Class1662.smethod_6(string_3);
			array[0] = (string)array9[0];
			array2[0] = array9[1];
		}
		return class1661_0.method_3() switch
		{
			"COUNTIF" => Class1269.Calculate(this, workbook_0.Worksheets, cell_0, obj3, object_, array, array2, 2, bool_0: false), 
			"AVERAGEIF" => Class1269.Calculate(this, workbook_0.Worksheets, cell_0, obj3, object_, array, array2, 1, bool_0: false), 
			"SUMIF" => Class1269.Calculate(this, workbook_0.Worksheets, cell_0, obj3, object_, array, array2, 0, bool_0: false), 
			_ => null, 
		};
	}

	private object method_147(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		int num = 1;
		int num2 = (class1661_0.method_7().Count - 1) / 2;
		object[] array = new object[num2];
		string[] array2 = new string[num2];
		object[] array3 = new object[num2];
		int num3 = 0;
		object obj2;
		while (true)
		{
			if (num3 < num2)
			{
				array[num3] = method_5((Class1661)class1661_0.method_7()[num3 * 2 + num], cell_0);
				obj2 = method_5((Class1661)class1661_0.method_7()[num3 * 2 + num + 1], cell_0);
				if (obj2 == null || obj2 is Array)
				{
					obj2 = Class1660.GetStringValue(obj2);
				}
				if (obj2 is ErrorType)
				{
					break;
				}
				if (obj2 is string)
				{
					string string_ = (string)obj2;
					object[] array4 = Class1662.smethod_6(string_);
					array2[num3] = (string)array4[0];
					array3[num3] = array4[1];
				}
				else
				{
					array2[num3] = "=";
					array3[num3] = obj2;
				}
				num3++;
				continue;
			}
			return Class1269.Calculate(this, workbook_0.Worksheets, cell_0, obj, array, array2, array3, 0, bool_0: true);
		}
		return obj2;
	}

	private object method_148(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
			if (obj2 == null)
			{
				obj2 = 0;
			}
			string[] array = new string[1];
			object[] array2 = new object[1];
			if (obj2 is string)
			{
				string string_ = (string)obj2;
				object[] array3 = Class1662.smethod_6(string_);
				array[0] = (string)array3[0];
				array2[0] = array3[1];
			}
			else
			{
				array[0] = "=";
				array2[0] = obj2;
			}
			return Class1269.Calculate(this, workbook_0.Worksheets, cell_0, obj, new object[1] { obj }, array, array2, 2, bool_0: false);
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_149(Class1661 class1661_0, Cell cell_0)
	{
		int num = 0;
		int num2 = class1661_0.method_7().Count / 2;
		object[] array = new object[num2];
		string[] array2 = new string[num2];
		object[] array3 = new object[num2];
		int num3 = 0;
		object object_;
		while (true)
		{
			if (num3 < num2)
			{
				array[num3] = method_5((Class1661)class1661_0.method_7()[num3 * 2 + num], cell_0);
				object_ = method_5((Class1661)class1661_0.method_7()[num3 * 2 + num + 1], cell_0);
				object_ = Class1660.GetStringValue(object_);
				if (object_ is ErrorType)
				{
					break;
				}
				string string_ = (string)object_;
				object[] array4 = Class1662.smethod_6(string_);
				array2[num3] = (string)array4[0];
				array3[num3] = array4[1];
				num3++;
				continue;
			}
			return Class1269.Calculate(this, workbook_0.Worksheets, cell_0, array[0], array, array2, array3, 2, bool_0: true);
		}
		return object_;
	}

	private object method_150(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		int num = 1;
		int num2 = (class1661_0.method_7().Count - 1) / 2;
		object[] array = new object[num2];
		string[] array2 = new string[num2];
		object[] array3 = new object[num2];
		int num3 = 0;
		object object_;
		while (true)
		{
			if (num3 < num2)
			{
				array[num3] = method_5((Class1661)class1661_0.method_7()[num3 * 2 + num], cell_0);
				object_ = method_5((Class1661)class1661_0.method_7()[num3 * 2 + num + 1], cell_0);
				object_ = Class1660.GetStringValue(object_);
				if (object_ is ErrorType)
				{
					break;
				}
				string string_ = (string)object_;
				object[] array4 = Class1662.smethod_6(string_);
				array2[num3] = (string)array4[0];
				array3[num3] = array4[1];
				num3++;
				continue;
			}
			return Class1269.Calculate(this, workbook_0.Worksheets, cell_0, obj, array, array2, array3, 1, bool_0: true);
		}
		return object_;
	}

	private object method_151(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			if (obj == null)
			{
				return true;
			}
			if (obj is ErrorType)
			{
				return obj;
			}
			if (obj is Array)
			{
				return Class1120.smethod_8(workbook_0, obj);
			}
			return Class1374.smethod_9(workbook_0, obj);
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_152(Class1661 class1661_0, Cell cell_0)
	{
		object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
		if (obj is double num)
		{
			if (!(num < 0.0) && num <= 1.0)
			{
				obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
				if (obj is double double_)
				{
					obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
					if (obj is double num2)
					{
						if (num2 < 0.0)
						{
							return ErrorType.Number;
						}
						return Class1665.smethod_1(num, double_, num2);
					}
					return obj;
				}
				return obj;
			}
			return ErrorType.Number;
		}
		return obj;
	}

	private object method_153(Class1661 class1661_0, Cell cell_0)
	{
		object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
		if (obj is double num)
		{
			if (num < 0.0)
			{
				return ErrorType.Number;
			}
			obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
			if (obj is double num2)
			{
				if (num2 <= 0.0)
				{
					return ErrorType.Number;
				}
				obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
				if (obj is double)
				{
					bool flag = (double)obj != 0.0;
					return Class1669.smethod_2((int)num, num2, flag);
				}
				return obj;
			}
			return obj;
		}
		return obj;
	}

	private object method_154(Class1661 class1661_0, Cell cell_0)
	{
		object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
		if (obj is double double_)
		{
			obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[1], cell_0), workbook_0.Settings.Date1904);
			if (obj is double double_2)
			{
				obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
				if (obj is double num)
				{
					if (num < 0.0)
					{
						return ErrorType.Number;
					}
					obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[3], cell_0), workbook_0.Settings.Date1904);
					if (obj is double)
					{
						bool flag = (double)obj != 0.0;
						return Class1665.smethod_2(double_, double_2, num, flag);
					}
					return obj;
				}
				return obj;
			}
			return obj;
		}
		return obj;
	}

	private object method_155(Class1661 class1661_0, Cell cell_0)
	{
		object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
		if (obj is double double_)
		{
			return Class1665.smethod_3(double_);
		}
		return obj;
	}

	private object method_156(Class1661 class1661_0, Cell cell_0)
	{
		object obj = Class1660.smethod_26(method_5((Class1661)class1661_0.method_7()[0], cell_0), workbook_0.Settings.Date1904);
		if (obj is double double_)
		{
			return Class1665.smethod_0(double_);
		}
		return obj;
	}

	private object method_157(Class1661 class1661_0, Cell cell_0)
	{
		double num = 0.0;
		object object_ = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
		if (object_ is ErrorType)
		{
			return object_;
		}
		double num2 = (double)object_;
		if (num2 + 1.0 < double.Epsilon)
		{
			return ErrorType.Div;
		}
		int num3 = 1;
		int num4 = 1;
		while (true)
		{
			if (num4 < class1661_0.method_7().Count)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num4];
				object_ = method_5(class1661_, cell_0);
				if (object_ != null)
				{
					if (object_ is ErrorType)
					{
						break;
					}
					switch (Type.GetTypeCode(object_.GetType()))
					{
					case TypeCode.Double:
					{
						double num5 = (double)object_;
						num += num5 / Math.Pow(1.0 + num2, num3);
						num3++;
						break;
					}
					case TypeCode.DateTime:
					{
						double num5 = CellsHelper.GetDoubleFromDateTime((DateTime)object_, workbook_0.Settings.Date1904);
						num += num5 / Math.Pow(1.0 + num2, num3);
						num3++;
						break;
					}
					case TypeCode.String:
						if (Class1677.smethod_20((string)object_))
						{
							try
							{
								double num5 = double.Parse((string)object_);
								num += num5 / Math.Pow(1.0 + num2, num3);
								num3++;
							}
							catch
							{
								return ErrorType.Value;
							}
							break;
						}
						return ErrorType.Value;
					case TypeCode.Object:
					{
						if (!(object_ is Array))
						{
							break;
						}
						Array array = (Array)object_;
						for (int i = 0; i < array.Length; i++)
						{
							Array array2 = (Array)array.GetValue(i);
							for (int j = 0; j < array2.Length; j++)
							{
								object value = array2.GetValue(j);
								if (value != null)
								{
									if (value is ErrorType)
									{
										return value;
									}
									switch (Type.GetTypeCode(value.GetType()))
									{
									case TypeCode.Double:
									{
										double num5 = (double)value;
										num += num5 / Math.Pow(1.0 + num2, num3);
										num3++;
										break;
									}
									case TypeCode.DateTime:
									{
										double num5 = CellsHelper.GetDoubleFromDateTime((DateTime)value, workbook_0.Settings.Date1904);
										num += num5 / Math.Pow(1.0 + num2, num3);
										num3++;
										break;
									}
									}
								}
							}
						}
						break;
					}
					case TypeCode.Boolean:
					{
						double num5 = (((bool)object_) ? 1.0 : 0.0);
						num += num5 / Math.Pow(1.0 + num2, num3);
						num3++;
						break;
					}
					}
				}
				num4++;
				continue;
			}
			return num;
		}
		return object_;
	}

	private object method_158(Class1661 class1661_0, Cell cell_0)
	{
		double[] array = new double[5];
		int num = 0;
		object obj;
		while (true)
		{
			if (num < class1661_0.method_7().Count)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num];
				obj = method_5(class1661_, cell_0);
				if (obj != null)
				{
					if (obj is ErrorType)
					{
						break;
					}
					switch (Type.GetTypeCode(obj.GetType()))
					{
					case TypeCode.Double:
						array[num] = (double)obj;
						break;
					case TypeCode.String:
						return ErrorType.Value;
					}
				}
				num++;
				continue;
			}
			return Class1378.smethod_59(array[0], array[1], array[2], array[3], array[4]);
		}
		return obj;
	}

	private object method_159(Class1661 class1661_0, Cell cell_0)
	{
		double[] array = new double[5];
		int num = 0;
		object obj;
		while (true)
		{
			if (num < class1661_0.method_7().Count)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num];
				obj = method_5(class1661_, cell_0);
				if (obj != null)
				{
					if (obj is ErrorType)
					{
						break;
					}
					switch (Type.GetTypeCode(obj.GetType()))
					{
					case TypeCode.Double:
						array[num] = (double)obj;
						break;
					case TypeCode.String:
						return ErrorType.Value;
					}
				}
				num++;
				continue;
			}
			if (array[0] == 0.0 && array[1] == 0.0)
			{
				return ErrorType.Div;
			}
			return Class1378.smethod_62(array[0], array[1], array[2], array[3], array[4]);
		}
		return obj;
	}

	private object method_160(Class1661 class1661_0, Cell cell_0)
	{
		double[] array = new double[5];
		int num = 0;
		object obj;
		while (true)
		{
			if (num < class1661_0.method_7().Count)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num];
				obj = method_5(class1661_, cell_0);
				if (obj != null)
				{
					if (obj is ErrorType)
					{
						break;
					}
					switch (Type.GetTypeCode(obj.GetType()))
					{
					case TypeCode.Double:
						array[num] = (double)obj;
						break;
					case TypeCode.String:
						return ErrorType.Value;
					}
				}
				num++;
				continue;
			}
			return Class1378.smethod_64(array[0], array[1], array[2], array[3], array[4]);
		}
		return obj;
	}

	private object method_161(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 255)
		{
			double num = 0.0;
			for (int i = 0; i < class1661_0.method_7().Count; i++)
			{
				Class1661 @class = (Class1661)class1661_0.method_7()[i];
				object obj = method_5(@class, cell_0);
				if (obj == null)
				{
					continue;
				}
				switch (Type.GetTypeCode(obj.GetType()))
				{
				case TypeCode.Double:
					if (@class.method_9() != null && @class.method_9().Length > 0)
					{
						switch (@class.method_9()[0])
						{
						case 24:
							num += (double)obj;
							break;
						default:
							num += 1.0;
							break;
						case 23:
						case 35:
						case 36:
						case 37:
						case 45:
						case 59:
						case 67:
						case 68:
						case 69:
						case 77:
						case 91:
						case 99:
						case 100:
						case 101:
						case 109:
						case 123:
							num += (double)obj;
							break;
						}
					}
					else
					{
						num += 1.0;
					}
					break;
				default:
					if (obj is Array)
					{
						num += (double)Class1120.smethod_14(obj);
					}
					else if (!(obj is ErrorType))
					{
						num += 1.0;
					}
					break;
				case TypeCode.String:
				{
					string string_ = (string)obj;
					if (Class1677.smethod_20(string_))
					{
						num += 1.0;
					}
					break;
				}
				case TypeCode.Boolean:
				case TypeCode.DateTime:
					num += 1.0;
					break;
				}
			}
			return num;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_162(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 255)
		{
			double num = 0.0;
			for (int i = 0; i < class1661_0.method_7().Count; i++)
			{
				Class1661 @class = (Class1661)class1661_0.method_7()[i];
				object obj = method_5(@class, cell_0);
				if (obj == null)
				{
					continue;
				}
				switch (Type.GetTypeCode(obj.GetType()))
				{
				case TypeCode.Double:
					if (@class.method_9() != null && @class.method_9().Length > 0)
					{
						switch (@class.method_9()[0])
						{
						case 24:
							num += (double)obj;
							break;
						default:
							num += 1.0;
							break;
						case 35:
						case 36:
						case 37:
						case 44:
						case 45:
						case 58:
						case 59:
						case 67:
						case 68:
						case 69:
						case 76:
						case 77:
						case 90:
						case 91:
						case 99:
						case 100:
						case 101:
						case 108:
						case 109:
						case 122:
						case 123:
							num += (double)obj;
							break;
						}
					}
					else
					{
						num += 1.0;
					}
					break;
				case TypeCode.DateTime:
					num += 1.0;
					break;
				default:
					if (obj is Array)
					{
						num += (double)Class1120.smethod_16(obj);
					}
					break;
				case TypeCode.String:
					num += 1.0;
					break;
				case TypeCode.Boolean:
					num += 1.0;
					break;
				}
			}
			return num;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_163(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj != null)
		{
			if (obj is Array)
			{
				double num = Class1120.smethod_13(obj);
				return num;
			}
			if (obj is string)
			{
				if (((string)obj).Length == 0)
				{
					return 1.0;
				}
				return 0.0;
			}
			return 0.0;
		}
		return 1.0;
	}

	private object method_164(Class1661 class1661_0, Cell cell_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		object obj;
		while (true)
		{
			if (num < class1661_0.method_7().Count)
			{
				Class1661 class1661_ = (Class1661)class1661_0.method_7()[num];
				obj = method_5(class1661_, cell_0);
				if (obj != null)
				{
					if (obj is ErrorType)
					{
						break;
					}
					switch (Type.GetTypeCode(obj.GetType()))
					{
					case TypeCode.DateTime:
					{
						double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904);
						stringBuilder.Append(doubleFromDateTime);
						break;
					}
					default:
						stringBuilder.Append(obj.ToString());
						break;
					case TypeCode.String:
						stringBuilder.Append(obj.ToString());
						break;
					case TypeCode.Boolean:
						if ((bool)obj)
						{
							stringBuilder.Append("TRUE");
						}
						else
						{
							stringBuilder.Append("FALSE");
						}
						break;
					}
				}
				num++;
				continue;
			}
			return stringBuilder.ToString();
		}
		return obj;
	}

	private bool method_165(Class1661 class1661_0)
	{
		Class1661 @class = class1661_0.method_5();
		bool flag = false;
		while (@class != null)
		{
			string text;
			if ((text = @class.method_3()) != null && text == "SUMPRODUCT")
			{
				flag = true;
			}
			if (flag)
			{
				break;
			}
			@class = @class.method_5();
		}
		if (flag)
		{
			return true;
		}
		return false;
	}

	private object method_166(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 1)
		{
			Class1661 @class = (Class1661)class1661_0.method_7()[0];
			if (@class.method_9() != null && @class.method_9().Length > 1)
			{
				switch (@class.method_9()[0])
				{
				case 30:
				case 31:
					return 1.0;
				}
			}
			object obj = method_5(@class, cell_0);
			if (obj is ErrorType)
			{
				return obj;
			}
			if (obj is Array)
			{
				Array array = (Array)obj;
				return (double)array.Length;
			}
			TypeCode typeCode = Type.GetTypeCode(obj.GetType());
			if (typeCode == TypeCode.Double)
			{
				return obj;
			}
			return ErrorType.Value;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_167(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count != 0)
		{
			if (class1661_0.method_7().Count > 1)
			{
				throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
			}
			Class1661 @class = (Class1661)class1661_0.method_7()[0];
			if (@class.method_9() != null)
			{
				switch (@class.method_9()[0])
				{
				case 23:
				case 29:
				case 30:
				case 31:
					throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
				}
			}
			object obj = method_5(@class, cell_0);
			if (obj is ErrorType)
			{
				return obj;
			}
			TypeCode typeCode = Type.GetTypeCode(obj.GetType());
			if (typeCode == TypeCode.Double)
			{
				return obj;
			}
			if (obj is Array)
			{
				return obj;
			}
			return ErrorType.Value;
		}
		if (cell_0 == null)
		{
			return 1.0;
		}
		if (class1661_0.method_3() == "ROW")
		{
			return (double)(cell_0.Row + 1);
		}
		return (double)(cell_0.Column + 1);
	}

	private int[] method_168(Class1661 class1661_0, Cell cell_0)
	{
		int[] array = null;
		int num = 0;
		if (cell_0 != null)
		{
			num = cell_0.method_4().method_3().Index;
		}
		int num2 = 0;
		int num3 = workbook_0.Worksheets.method_36();
		int num4 = 0;
		int num5 = 0;
		if (cell_0 != null)
		{
			num4 = cell_0.Row;
			num5 = cell_0.Column;
		}
		switch (class1661_0.method_9()[0])
		{
		case 58:
		case 90:
		case 122:
			array = new int[4];
			num2 = BitConverter.ToUInt16(class1661_0.method_9(), 1);
			num3 = workbook_0.Worksheets.method_32().method_12(num2);
			num = workbook_0.Worksheets.method_32().method_13(num2);
			array[0] = BitConverter.ToInt32(class1661_0.method_9(), 3);
			array[1] = Class1268.smethod_1(class1661_0.method_9(), 7);
			array[2] = num3;
			array[3] = num;
			break;
		case 59:
		case 91:
		case 123:
			array = new int[4]
			{
				BitConverter.ToInt32(class1661_0.method_9(), 3),
				Class1268.smethod_1(class1661_0.method_9(), 11),
				0,
				0
			};
			num2 = BitConverter.ToUInt16(class1661_0.method_9(), 1);
			num3 = workbook_0.Worksheets.method_32().method_12(num2);
			num = workbook_0.Worksheets.method_32().method_13(num2);
			array[2] = num3;
			array[3] = num;
			break;
		case 44:
		case 76:
		case 108:
			array = new int[4]
			{
				Class1268.smethod_2(class1661_0.method_9(), 1, num4, class1661_0.method_9()[6]),
				Class1268.smethod_6(class1661_0.method_9(), 5, num5, class1661_0.method_9()[6]),
				num3,
				num
			};
			break;
		case 45:
		case 77:
		case 109:
			array = new int[4]
			{
				Class1268.smethod_2(class1661_0.method_9(), 1, num5, class1661_0.method_9()[10]),
				Class1268.smethod_6(class1661_0.method_9(), 9, num5, class1661_0.method_9()[10]),
				num3,
				num
			};
			break;
		case 35:
		case 67:
		case 99:
		{
			int index = BitConverter.ToUInt16(class1661_0.method_9(), 1) - 1;
			Name name = workbook_0.Worksheets.Names[index];
			Range range = name.GetRange();
			if (range == null)
			{
				return null;
			}
			array = new int[4]
			{
				range.FirstRow,
				range.FirstColumn,
				num3,
				range.Worksheet.Index
			};
			break;
		}
		case 36:
		case 68:
		case 100:
			array = new int[4]
			{
				BitConverter.ToInt32(class1661_0.method_9(), 1),
				Class1268.smethod_1(class1661_0.method_9(), 5),
				num3,
				num
			};
			break;
		case 37:
		case 69:
		case 101:
			array = new int[4]
			{
				BitConverter.ToInt32(class1661_0.method_9(), 1),
				Class1268.smethod_1(class1661_0.method_9(), 9),
				num3,
				num
			};
			break;
		}
		return array;
	}

	private object method_169(Class1661 class1661_0, Cell cell_0)
	{
		int count = class1661_0.method_7().Count;
		if (cell_0 != null)
		{
			workbook_0.class1380_0.method_3(cell_0);
		}
		if (count != 1 && count != 2)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj is string)
		{
			string text = (string)obj;
			string key;
			if ((key = text.ToUpper()) != null)
			{
				if (Class1742.dictionary_91 == null)
				{
					Class1742.dictionary_91 = new Dictionary<string, int>(12)
					{
						{ "COL", 0 },
						{ "ROW", 1 },
						{ "FILENAME", 2 },
						{ "ADDRESS", 3 },
						{ "FORMAT", 4 },
						{ "PREFIX", 5 },
						{ "PROTECT", 6 },
						{ "CONTENTS", 7 },
						{ "TYPE", 8 },
						{ "WIDTH", 9 },
						{ "COLOR", 10 },
						{ "PARENTHESES", 11 }
					};
				}
				if (Class1742.dictionary_91.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
					{
						if (count == 1)
						{
							return cell_0.Column + 1;
						}
						int[] array4 = method_168((Class1661)class1661_0.method_7()[1], cell_0);
						if (array4 != null)
						{
							return array4[1] + 1;
						}
						break;
					}
					case 1:
					{
						if (count == 1)
						{
							return cell_0.Row + 1;
						}
						int[] array3 = method_168((Class1661)class1661_0.method_7()[1], cell_0);
						if (array3 != null)
						{
							return array3[0] + 1;
						}
						break;
					}
					case 2:
					{
						string fileName = workbook_0.FileName;
						if (fileName != null && !(fileName == ""))
						{
							int num4 = fileName.LastIndexOf('\\');
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder.Append(fileName.Substring(0, num4 + 1));
							stringBuilder.Append('[');
							stringBuilder.Append(fileName.Substring(num4 + 1));
							stringBuilder.Append(']');
							if (class1661_0.method_7().Count == 1)
							{
								stringBuilder.Append(cell_0.method_4().method_3().Name);
							}
							else
							{
								object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
								if (obj2 != null && obj2 is Struct87)
								{
									stringBuilder.Append(workbook_0.Worksheets[((Struct87)obj2).int_1].Name);
								}
								else
								{
									stringBuilder.Append(cell_0.method_4().method_3().Name);
								}
							}
							return stringBuilder.ToString();
						}
						return "";
					}
					case 3:
					{
						if (count == 1)
						{
							return "$" + CellsHelper.ColumnIndexToName(cell_0.Column) + "$" + (cell_0.Row + 1);
						}
						int[] array2 = method_168((Class1661)class1661_0.method_7()[1], cell_0);
						if (array2 != null)
						{
							int num3 = array2[0];
							int column = array2[1];
							return "$" + CellsHelper.ColumnIndexToName(column) + "$" + (num3 + 1);
						}
						return "";
					}
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:
					{
						Cell cell_ = null;
						if (class1661_0.method_7().Count == 0)
						{
							cell_ = cell_0;
						}
						else
						{
							int[] array = method_168((Class1661)class1661_0.method_7()[1], cell_0);
							if (array != null)
							{
								int num = array[2];
								int num2 = array[3];
								if (num == workbook_0.Worksheets.method_36() && num2 >= 0 && num2 < workbook_0.Worksheets.Count)
								{
									string text2;
									if ((text2 = text.ToUpper()) != null && text2 == "WIDTH")
									{
										return (double)(int)(workbook_0.Worksheets[num2].Cells.GetColumnWidth(array[1]) + 0.5);
									}
									cell_ = workbook_0.Worksheets[num2].Cells.CheckCell(array[0], array[1]);
								}
							}
						}
						string key2;
						if ((key2 = text.ToUpper()) != null)
						{
							if (Class1742.dictionary_92 == null)
							{
								Class1742.dictionary_92 = new Dictionary<string, int>(8)
								{
									{ "FORMAT", 0 },
									{ "CONTENTS", 1 },
									{ "PREFIX", 2 },
									{ "PROTECT", 3 },
									{ "TYPE", 4 },
									{ "WIDTH", 5 },
									{ "COLOR", 6 },
									{ "PARENTHESES", 7 }
								};
							}
							if (Class1742.dictionary_92.TryGetValue(key2, out var value2))
							{
								switch (value2)
								{
								case 0:
									return Class740.Format(cell_);
								case 1:
									return Class740.smethod_8(cell_);
								case 2:
									return Class740.smethod_7(cell_);
								case 3:
									return Class740.Protect(cell_);
								case 4:
									return Class740.smethod_6(cell_);
								case 5:
									return Class740.smethod_5(cell_);
								case 6:
									return Class740.smethod_4(cell_);
								case 7:
									return Class740.smethod_2(cell_);
								}
							}
						}
						return ErrorType.Value;
					}
					}
				}
			}
			return "";
		}
		return ErrorType.Value;
	}

	private object method_170(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return ErrorType.Value;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		int num = 0;
		switch (Type.GetTypeCode(obj.GetType()))
		{
		case TypeCode.Double:
			num = (int)Class1179.ToDouble(obj);
			if (num <= 0 || num > 255)
			{
				return ErrorType.Value;
			}
			goto IL_0109;
		case TypeCode.DateTime:
			num = (int)CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904);
			if (num <= 0 || num > 255)
			{
				return ErrorType.Value;
			}
			goto IL_0109;
		default:
			return ErrorType.Value;
		case TypeCode.String:
		{
			string text = (string)obj;
			if (Class1677.smethod_20(text))
			{
				try
				{
					num = (int)double.Parse(text);
					if (num <= 0 || num > 255)
					{
						return ErrorType.Value;
					}
				}
				catch
				{
					return ErrorType.Value;
				}
				goto IL_0109;
			}
			return ErrorType.Value;
		}
		case TypeCode.Boolean:
			{
				if ((bool)obj)
				{
					num = 1;
					goto IL_0109;
				}
				return ErrorType.Value;
			}
			IL_0109:
			return ((char)num).ToString();
		}
	}

	private object method_171(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count >= 2 && class1661_0.method_7().Count <= 255)
		{
			object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
			if (obj == null)
			{
				return ErrorType.Value;
			}
			obj = Class1660.smethod_26(obj, workbook_0.Settings.Date1904);
			if (obj is ErrorType)
			{
				return obj;
			}
			if (obj is string)
			{
				return ErrorType.Value;
			}
			int num = (int)Class1179.ToDouble(obj);
			if (num <= 0)
			{
				return ErrorType.Value;
			}
			if (num >= class1661_0.method_7().Count)
			{
				return ErrorType.Value;
			}
			return method_5((Class1661)class1661_0.method_7()[num], cell_0);
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_172(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 2)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj == null)
		{
			return 0.0;
		}
		obj = Class1660.smethod_26(obj, workbook_0.Settings.Date1904);
		if (obj is ErrorType)
		{
			return obj;
		}
		double num = (double)obj;
		object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
		if (obj2 == null)
		{
			return 0.0;
		}
		obj2 = Class1660.smethod_26(obj2, workbook_0.Settings.Date1904);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		double num2 = (double)obj2;
		if (num != 0.0 && num2 != 0.0)
		{
			double num3 = Math.Ceiling(num / num2);
			if (num3 < 0.0)
			{
				return ErrorType.Number;
			}
			return num3 * num2;
		}
		return 0.0;
	}

	private object method_173(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 0 && class1661_0.method_7().Count <= 255)
		{
			int num = 0;
			object obj = null;
			bool flag = true;
			int num2 = 0;
			while (true)
			{
				if (num2 < class1661_0.method_7().Count)
				{
					Class1661 @class = (Class1661)class1661_0.method_7()[num2];
					obj = method_5(@class, cell_0);
					if (obj == null)
					{
						if (@class.method_9()[0] == 22)
						{
							flag = false;
							num++;
						}
					}
					else
					{
						if (obj is ErrorType)
						{
							break;
						}
						if (flag)
						{
							switch (Type.GetTypeCode(obj.GetType()))
							{
							case TypeCode.Double:
							{
								double num3 = (double)obj;
								if (num3 == 0.0)
								{
									flag = false;
								}
								break;
							}
							default:
								if (obj is Array)
								{
									Array array = (Array)obj;
									bool flag2 = false;
									for (int i = 0; i < array.Length; i++)
									{
										Array array2 = (Array)array.GetValue(i);
										if (array2 == null)
										{
											continue;
										}
										for (int j = 0; j < array2.Length; j++)
										{
											object value = array2.GetValue(j);
											if (value == null)
											{
												continue;
											}
											if (!(value is ErrorType))
											{
												if (!flag)
												{
													continue;
												}
												switch (Type.GetTypeCode(value.GetType()))
												{
												case TypeCode.Double:
													if ((double)value == 0.0)
													{
														flag = false;
													}
													flag2 = true;
													break;
												case TypeCode.Int32:
													if ((int)value == 0)
													{
														flag = false;
													}
													flag2 = true;
													break;
												case TypeCode.Boolean:
													if (!(bool)value)
													{
														flag = false;
													}
													flag2 = true;
													break;
												}
												continue;
											}
											return value;
										}
									}
									if (flag2)
									{
										num++;
									}
								}
								goto IL_01eb;
							case TypeCode.String:
								if (Class1660.smethod_19(@class.method_9()[0]))
								{
									goto IL_01eb;
								}
								return ErrorType.Value;
							case TypeCode.Int32:
								if ((int)obj == 0)
								{
									flag = false;
								}
								break;
							case TypeCode.Boolean:
								if (!(bool)obj)
								{
									flag = false;
								}
								break;
							case TypeCode.DateTime:
								break;
							}
						}
						num++;
					}
					goto IL_01eb;
				}
				if (num == 0)
				{
					return ErrorType.Value;
				}
				return flag;
				IL_01eb:
				num2++;
			}
			return obj;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_174(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count == 0)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		double num = 0.0;
		int num2 = 0;
		int num3 = 0;
		object obj;
		while (true)
		{
			if (num3 < class1661_0.method_7().Count)
			{
				Class1661 @class = (Class1661)class1661_0.method_7()[num3];
				obj = method_5(@class, cell_0);
				if (obj != null)
				{
					if (obj is object[][])
					{
						object[][] array = (object[][])obj;
						foreach (object[] array2 in array)
						{
							foreach (object obj2 in array2)
							{
								if (obj2 != null)
								{
									if (obj2 is ErrorType)
									{
										return obj2;
									}
									switch (Type.GetTypeCode(obj2.GetType()))
									{
									case TypeCode.Double:
										num += (double)obj2;
										num2++;
										break;
									case TypeCode.DateTime:
										num += CellsHelper.GetDoubleFromDateTime((DateTime)obj2, workbook_0.Settings.Date1904);
										num2++;
										break;
									}
								}
							}
						}
					}
					else
					{
						if (obj is ErrorType)
						{
							return obj;
						}
						bool flag = true;
						if (@class.method_9() != null)
						{
							switch (@class.method_9()[0])
							{
							case 11:
							case 23:
							case 29:
							case 33:
							case 34:
								flag = false;
								break;
							}
						}
						obj = Class1660.smethod_9(workbook_0, obj, flag);
						if (obj is ErrorType)
						{
							break;
						}
						num += (double)obj;
						num2 += int_1 + 1;
					}
					int_1 = 0;
				}
				num3++;
				continue;
			}
			if (num2 == 0)
			{
				return ErrorType.Div;
			}
			num /= (double)num2;
			int_1 = 0;
			return num;
		}
		return obj;
	}

	private object method_175(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double)
		{
			return Math.Cos((double)obj);
		}
		return obj;
	}

	private object method_176(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double)
		{
			return Math.Sin((double)obj);
		}
		return obj;
	}

	private object method_177(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double num)
		{
			if (Math.Abs(num) > 1.0)
			{
				return ErrorType.Number;
			}
			return Math.Acos(num);
		}
		return obj;
	}

	private object method_178(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double num)
		{
			if (!(num > 1.0) && num >= -1.0)
			{
				return Math.Asin((double)obj);
			}
			return ErrorType.Number;
		}
		return obj;
	}

	private object method_179(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double)
		{
			return Math.Sinh((double)obj);
		}
		return obj;
	}

	private object method_180(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double)
		{
			return Math.Cosh((double)obj);
		}
		return obj;
	}

	private object method_181(Class1661 class1661_0, Cell cell_0, bool bool_3)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object obj = method_5(class1661_, cell_0);
			if (obj != null)
			{
				if (obj is ErrorType)
				{
					return obj;
				}
				if (obj is Struct87 struct87_)
				{
					obj = method_144(class1661_0, struct87_, cell_0);
				}
			}
			Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
			object obj2 = method_5(class1661_2, cell_0);
			if (obj2 != null && obj2 is ErrorType)
			{
				return obj2;
			}
			if (obj is object[][])
			{
				object[][] array = (object[][])obj;
				if (obj2 is double)
				{
					int num = (bool_3 ? ((int)Class1179.ToDouble(obj2)) : ((int)Math.Ceiling(Class1179.ToDouble(obj2))));
					if (num <= 0)
					{
						return ErrorType.Number;
					}
					object[] array2 = array[0];
					Class934 @class = new Class934(num, !bool_3);
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] == null)
						{
							continue;
						}
						for (int j = 0; j < array2.Length; j++)
						{
							object obj3 = array[i][j];
							if (obj3 is double)
							{
								@class.Add((double)obj3);
							}
						}
					}
					if (@class.int_1 < num)
					{
						return ErrorType.Number;
					}
					return @class[num - 1];
				}
				return ErrorType.Value;
			}
			if (obj is double)
			{
				if (obj2 is double)
				{
					int num2 = (bool_3 ? ((int)Class1179.ToDouble(obj2)) : ((int)Math.Ceiling(Class1179.ToDouble(obj2))));
					if (num2 == 1)
					{
						return obj;
					}
				}
				return ErrorType.Number;
			}
			return ErrorType.Number;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	internal void method_182(byte[] token, int offset, out int startRow, out int startColumn, out int endRow, out int endColumn)
	{
		startRow = BitConverter.ToInt32(token, offset);
		endRow = BitConverter.ToInt32(token, offset + 4);
		startColumn = Class1268.smethod_1(token, offset + 8);
		endColumn = Class1268.smethod_1(token, offset + 10);
	}

	private object method_183(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object object_ = method_5(class1661_, cell_0);
		object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
		if (object_ is ErrorType)
		{
			return object_;
		}
		int num = (int)Class1179.ToDouble(object_);
		bool flag = false;
		if (num <= 111 && num >= 1)
		{
			if (num >= 100)
			{
				flag = true;
			}
			num %= 100;
			if (num > 11)
			{
				return ErrorType.Value;
			}
			ArrayList arrayList = new ArrayList();
			int num2 = 0;
			int num3 = 1;
			object obj;
			while (true)
			{
				if (num3 < class1661_0.method_7().Count)
				{
					_ = (Class1661)class1661_0.method_7()[num3];
					int num4 = 0;
					int num5 = 0;
					int num6 = 0;
					int num7 = 0;
					Worksheet worksheet = null;
					obj = method_5((Class1661)class1661_0.method_7()[num3], cell_0);
					if (obj != null)
					{
						if (obj is Struct87 @struct)
						{
							worksheet = workbook_0.Worksheets[@struct.int_1];
							num4 = @struct.cellArea_0.StartRow;
							num6 = @struct.cellArea_0.StartColumn;
							num5 = @struct.cellArea_0.EndRow;
							num7 = @struct.cellArea_0.EndColumn;
						}
						if (worksheet == null)
						{
							if (obj != null)
							{
								if (obj is ErrorType)
								{
									break;
								}
								switch (num)
								{
								default:
									switch (Type.GetTypeCode(obj.GetType()))
									{
									case TypeCode.Double:
										arrayList.Add(obj);
										break;
									default:
									{
										if (obj is double[][])
										{
											double[][] array = (double[][])obj;
											int num8 = array[0].Length;
											for (int i = 0; i < array.Length; i++)
											{
												if (array[i] == null)
												{
													continue;
												}
												for (int j = 0; j < num8; j++)
												{
													switch (num)
													{
													default:
														arrayList.Add(array[i][j]);
														break;
													case 2:
														num2++;
														break;
													case 3:
														num2++;
														break;
													}
												}
											}
										}
										if (!(obj is object[][]))
										{
											break;
										}
										object[][] array2 = (object[][])obj;
										foreach (object[] array3 in array2)
										{
											foreach (object obj2 in array3)
											{
												if (obj2 == null)
												{
													continue;
												}
												if (!(obj2 is ErrorType))
												{
													switch (num)
													{
													case 2:
														switch (Type.GetTypeCode(obj2.GetType()))
														{
														case TypeCode.Double:
														case TypeCode.DateTime:
															num2++;
															break;
														}
														continue;
													case 3:
														num2++;
														continue;
													}
													switch (Type.GetTypeCode(obj2.GetType()))
													{
													case TypeCode.Double:
														arrayList.Add(obj2);
														break;
													case TypeCode.DateTime:
														arrayList.Add(CellsHelper.GetDoubleFromDateTime((DateTime)obj2, workbook_0.Settings.Date1904));
														break;
													}
													continue;
												}
												return obj2;
											}
										}
										break;
									}
									case TypeCode.DateTime:
										arrayList.Add(CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904));
										break;
									}
									break;
								case 2:
									switch (Type.GetTypeCode(obj.GetType()))
									{
									case TypeCode.Double:
									case TypeCode.DateTime:
										num2++;
										break;
									}
									break;
								case 3:
									num2++;
									break;
								}
							}
						}
						else
						{
							Cells cells = worksheet.Cells;
							Cell cell = null;
							for (int m = num4; m <= num5; m++)
							{
								Row row = cells.Rows.method_3(m);
								if (row == null || (flag && row.IsHidden))
								{
									continue;
								}
								for (int n = num6; n <= num7; n++)
								{
									cell = cells.CheckCell(m, n);
									if (cell == null || (cell.IsFormula && cell.Formula.StartsWith("=SUBTOTAL(")))
									{
										continue;
									}
									object_ = method_211(cell);
									if (object_ == null)
									{
										continue;
									}
									if (!(object_ is ErrorType))
									{
										switch (num)
										{
										case 2:
											switch (Type.GetTypeCode(object_.GetType()))
											{
											case TypeCode.Double:
											case TypeCode.DateTime:
												num2++;
												break;
											}
											continue;
										case 3:
											num2++;
											continue;
										}
										switch (Type.GetTypeCode(object_.GetType()))
										{
										case TypeCode.Double:
											arrayList.Add(object_);
											break;
										case TypeCode.DateTime:
											arrayList.Add(CellsHelper.GetDoubleFromDateTime((DateTime)object_, workbook_0.Settings.Date1904));
											break;
										}
										continue;
									}
									return object_;
								}
							}
						}
					}
					num3++;
					continue;
				}
				if (num != 2 && num != 3)
				{
					double[] double_ = (double[])arrayList.ToArray(typeof(double));
					return num switch
					{
						1 => Class1668.smethod_24(double_), 
						4 => Class1668.smethod_26(double_), 
						5 => Class1668.smethod_25(double_), 
						6 => Class1668.smethod_27(double_), 
						7 => Class1668.smethod_28(double_), 
						8 => Class1668.smethod_30(double_), 
						9 => Class1668.smethod_23(double_), 
						10 => Class1668.smethod_29(double_), 
						11 => Class1668.smethod_31(double_), 
						_ => ErrorType.Value, 
					};
				}
				return (double)num2;
			}
			return obj;
		}
		return ErrorType.Value;
	}

	private object method_184(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object object_ = method_5(class1661_, cell_0);
		object_ = Class1660.GetStringValue(object_);
		if (object_ is ErrorType)
		{
			return object_;
		}
		string text = object_.ToString();
		class1661_ = (Class1661)class1661_0.method_7()[1];
		object_ = method_5(class1661_, cell_0);
		object_ = Class1660.GetStringValue(object_);
		if (object_ is ErrorType)
		{
			return object_;
		}
		string text2 = object_.ToString();
		class1661_ = (Class1661)class1661_0.method_7()[2];
		object_ = method_5(class1661_, cell_0);
		object_ = Class1660.GetStringValue(object_);
		if (object_ is ErrorType)
		{
			return object_;
		}
		string text3 = object_.ToString();
		if (class1661_0.method_7().Count == 3)
		{
			return text.Replace(text2, text3);
		}
		class1661_ = (Class1661)class1661_0.method_7()[3];
		object_ = method_5(class1661_, cell_0);
		if (object_ != null && object_ is bool)
		{
			return ErrorType.Value;
		}
		object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
		if (object_ is ErrorType)
		{
			return object_;
		}
		int num = (int)Class1179.ToDouble(object_);
		if (num <= 0)
		{
			return ErrorType.Value;
		}
		int num2 = 0;
		int num3 = 0;
		while (true)
		{
			if (num3 < num)
			{
				int num4 = text.IndexOf(text2, num2);
				if (num4 == -1)
				{
					break;
				}
				num2 = num4 + text2.Length;
				num3++;
				continue;
			}
			return text.Substring(0, num2 - text2.Length) + text3 + text.Substring(num2);
		}
		return text;
	}

	private object method_185(Class1661 class1661_0, Cell cell_0, bool bool_3, bool bool_4, bool bool_5, bool bool_6)
	{
		ArrayList arrayList = new ArrayList();
		int num = 0;
		object object_;
		while (true)
		{
			if (num < class1661_0.method_7().Count)
			{
				object_ = method_5((Class1661)class1661_0.method_7()[num], cell_0);
				object_ = Class1660.smethod_15(arrayList, object_, cell_0, bool_3, bool_4, bool_5, bool_6, workbook_0.Settings.Date1904, bool_5: false);
				if (object_ != null && object_ is ErrorType)
				{
					break;
				}
				num++;
				continue;
			}
			double[] array = new double[arrayList.Count];
			for (int i = 0; i < arrayList.Count; i++)
			{
				array[i] = (double)arrayList[i];
			}
			string key;
			if ((key = class1661_0.method_3()) != null)
			{
				if (Class1742.dictionary_93 == null)
				{
					Class1742.dictionary_93 = new Dictionary<string, int>(13)
					{
						{ "AVEDEV", 0 },
						{ "DEVSQ", 1 },
						{ "HARMEAN", 2 },
						{ "KURT", 3 },
						{ "MULTINOMIAL", 4 },
						{ "SKEW", 5 },
						{ "STDEVA", 6 },
						{ "STDEVPA", 7 },
						{ "SUMSQ", 8 },
						{ "VAR", 9 },
						{ "VARA", 10 },
						{ "VARP", 11 },
						{ "VARPA", 12 }
					};
				}
				if (Class1742.dictionary_93.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						return Class1668.smethod_55(array);
					case 1:
						return Class1668.smethod_56(array);
					case 2:
						return Class1668.smethod_61(array);
					case 3:
						return Class1668.smethod_43(array);
					case 4:
					{
						int[] array2 = new int[array.Length];
						for (int j = 0; j < array2.Length; j++)
						{
							array2[j] = (int)array[j];
						}
						return Class1341.smethod_6(array2);
					}
					case 5:
						return Class1668.smethod_44(array);
					case 6:
						return Class1668.smethod_28(array);
					case 7:
						return Class1668.smethod_30(array);
					case 8:
						return Class1341.smethod_4(array);
					case 9:
					case 10:
						return Class1668.smethod_29(array);
					case 11:
					case 12:
						return Class1668.smethod_31(array);
					}
				}
			}
			return null;
		}
		return object_;
	}

	private object method_186(Class1661 class1661_0, Cell cell_0)
	{
		double[] array = new double[5];
		int num = 0;
		object obj2;
		while (true)
		{
			if (num < 5)
			{
				object obj = method_5((Class1661)class1661_0.method_7()[num], cell_0);
				if (obj == null)
				{
					array[num] = 0.0;
				}
				else
				{
					if (obj is ErrorType)
					{
						return obj;
					}
					obj2 = Class1660.smethod_9(workbook_0, obj, bool_0: false);
					if (obj2 is ErrorType)
					{
						break;
					}
					array[num] = (double)obj2;
				}
				num++;
				continue;
			}
			double double_ = 2.0;
			if (class1661_0.method_7().Count > 5)
			{
				object obj3 = method_52((Class1661)class1661_0.method_7()[5], cell_0);
				if (obj3 is ErrorType)
				{
					return obj3;
				}
				double_ = (double)obj3;
			}
			bool flag = false;
			if (class1661_0.method_7().Count > 6)
			{
				object object_ = method_5((Class1661)class1661_0.method_7()[6], cell_0);
				object_ = Class1660.smethod_18(object_, workbook_0.Settings.Date1904);
				if (object_ is ErrorType)
				{
					return object_;
				}
				flag = (bool)object_;
			}
			return Class1378.smethod_67(array[0], array[1], array[2], array[3], array[4], double_, flag);
		}
		return obj2;
	}

	private object method_187(Class1661 class1661_0, Cell cell_0)
	{
		double[] array = new double[class1661_0.method_7().Count];
		int num = 0;
		object obj2;
		while (true)
		{
			if (num < class1661_0.method_7().Count)
			{
				object obj = method_5((Class1661)class1661_0.method_7()[num], cell_0);
				if (obj == null)
				{
					array[num] = 0.0;
					if (num == 4)
					{
						array[1] = 12.0;
					}
				}
				else
				{
					if (obj is ErrorType)
					{
						return obj;
					}
					obj2 = Class1660.smethod_9(workbook_0, obj, bool_0: false);
					if (obj2 is ErrorType)
					{
						break;
					}
					array[num] = (double)obj2;
				}
				num++;
				continue;
			}
			return Class1378.smethod_65(array[0], array[1], array[2], array[3], (array.Length > 4) ? array[4] : 12.0);
		}
		return obj2;
	}

	private object method_188(Class1661 class1661_0, Cell cell_0)
	{
		double[] array = new double[2];
		int num = 0;
		object obj2;
		while (true)
		{
			if (num < 2)
			{
				object obj = method_5((Class1661)class1661_0.method_7()[num], cell_0);
				if (obj == null)
				{
					array[num] = 0.0;
				}
				else
				{
					if (obj is ErrorType)
					{
						return obj;
					}
					obj2 = Class1660.smethod_9(workbook_0, obj, bool_0: false);
					if (obj2 is ErrorType)
					{
						break;
					}
					array[num] = (double)obj2;
				}
				num++;
				continue;
			}
			string string_ = "i";
			if (class1661_0.method_7().Count > 2)
			{
				object obj3 = method_5((Class1661)class1661_0.method_7()[2], cell_0);
				if (obj3 != null)
				{
					if (obj3 is ErrorType)
					{
						return obj3;
					}
					string_ = obj3.ToString();
				}
			}
			return Class1252.smethod_0(array[0], array[1], string_);
		}
		return obj2;
	}

	private object method_189(Class1661 class1661_0, Cell cell_0)
	{
		object object_ = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		object_ = Class1660.smethod_9(workbook_0, object_, bool_0: false);
		if (object_ is ErrorType)
		{
			return object_;
		}
		double double_ = (double)object_;
		object_ = method_5((Class1661)class1661_0.method_7()[1], cell_0);
		if (object_ is ErrorType)
		{
			return object_;
		}
		string string_ = object_.ToString();
		object_ = method_5((Class1661)class1661_0.method_7()[2], cell_0);
		if (object_ is ErrorType)
		{
			return object_;
		}
		string string_2 = object_.ToString();
		return Class1252.smethod_2(double_, string_, string_2);
	}

	private object method_190(Class1661 class1661_0, Cell cell_0)
	{
		double[] array = new double[class1661_0.method_7().Count];
		int num = 0;
		object obj2;
		while (true)
		{
			if (num < class1661_0.method_7().Count)
			{
				object obj = method_5((Class1661)class1661_0.method_7()[num], cell_0);
				if (obj == null)
				{
					array[num] = 0.0;
					switch (class1661_0.method_3())
					{
					case "ACCRINTM":
						if (num == 3)
						{
							array[num] = 1000.0;
						}
						break;
					case "ACCRINT":
						if (num == 4)
						{
							array[num] = 1000.0;
						}
						break;
					}
				}
				else
				{
					if (obj is ErrorType)
					{
						return obj;
					}
					obj2 = Class1660.smethod_9(workbook_0, obj, bool_0: false);
					if (obj2 is ErrorType)
					{
						break;
					}
					array[num] = (double)obj2;
				}
				num++;
				continue;
			}
			return class1661_0.method_3() switch
			{
				"ACCRINTM" => Class1378.smethod_23(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2], (array.Length > 3) ? array[3] : 1000.0, (array.Length > 4) ? ((int)array[4]) : 0), 
				"ACCRINT" => Class1378.smethod_22(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[2], workbook_0.Settings.Date1904), array[3], array[4], (int)array[5], (int)((array.Length > 6) ? array[6] : 0.0)), 
				_ => null, 
			};
		}
		return obj2;
	}

	private object method_191(Class1661 class1661_0, Cell cell_0, int int_3)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < int_3 && i < class1661_0.method_7().Count; i++)
		{
			object obj = method_5((Class1661)class1661_0.method_7()[i], cell_0);
			if (obj != null)
			{
				if (obj is ErrorType)
				{
					return obj;
				}
				Class1660.smethod_29(arrayList, obj);
			}
		}
		string[] array = new string[arrayList.Count];
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = (string)arrayList[j];
		}
		return class1661_0.method_3() switch
		{
			"IMSUM" => Class1252.smethod_5(array), 
			"IMPRODUCT" => Class1252.smethod_9(array), 
			_ => null, 
		};
	}

	private object method_192(Class1661 class1661_0, Cell cell_0)
	{
		object obj = method_5((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj != null)
		{
			if (obj is ErrorType)
			{
				return obj;
			}
			if (obj is string)
			{
				return obj;
			}
		}
		return "";
	}

	private object method_193(Class1661 class1661_0, Cell cell_0, int int_3)
	{
		string[] array = new string[int_3];
		int num = 0;
		object obj;
		while (true)
		{
			if (num < int_3)
			{
				obj = method_5((Class1661)class1661_0.method_7()[num], cell_0);
				if (obj == null)
				{
					array[num] = "";
				}
				else
				{
					if (obj is ErrorType)
					{
						break;
					}
					array[num] = obj.ToString();
				}
				num++;
				continue;
			}
			string key;
			if ((key = class1661_0.method_3()) != null)
			{
				if (Class1742.dictionary_94 == null)
				{
					Class1742.dictionary_94 = new Dictionary<string, int>(18)
					{
						{ "HEX2BIN", 0 },
						{ "HEX2DEC", 1 },
						{ "HEX2OCT", 2 },
						{ "IMABS", 3 },
						{ "IMAGINARY", 4 },
						{ "IMARGUMENT", 5 },
						{ "IMCONJUGATE", 6 },
						{ "IMCOS", 7 },
						{ "IMDIV", 8 },
						{ "IMEXP", 9 },
						{ "IMLN", 10 },
						{ "IMLOG10", 11 },
						{ "IMLOG2", 12 },
						{ "IMPOWER", 13 },
						{ "IMREAL", 14 },
						{ "IMSIN", 15 },
						{ "IMSQRT", 16 },
						{ "IMSUB", 17 }
					};
				}
				if (Class1742.dictionary_94.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						if (class1661_0.method_7().Count > 1)
						{
							object obj4 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
							if (obj4 != null)
							{
								obj4 = Class1660.smethod_9(workbook_0, obj4, bool_0: false);
								if (obj4 is ErrorType)
								{
									return obj4;
								}
							}
							else
							{
								obj4 = 0.0;
							}
							return Class1252.smethod_38(array[0], (int)Class1179.ToDouble(obj4));
						}
						return Class1252.smethod_37(array[0]);
					case 1:
						return Class1252.smethod_39(array[0]);
					case 2:
						if (class1661_0.method_7().Count > 1)
						{
							object obj3 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
							if (obj3 != null)
							{
								obj3 = Class1660.smethod_9(workbook_0, obj3, bool_0: false);
								if (obj3 is ErrorType)
								{
									return obj3;
								}
							}
							else
							{
								obj3 = 0.0;
							}
							return Class1252.smethod_41(array[0], (int)Class1179.ToDouble(obj3));
						}
						return Class1252.smethod_40(array[0]);
					case 3:
						return Class1252.smethod_11(array[0]);
					case 4:
						return Class1252.smethod_8(array[0]);
					case 5:
						return Class1252.smethod_20(array[0]);
					case 6:
						return Class1252.smethod_21(array[0]);
					case 7:
						return Class1252.smethod_17(array[0]);
					case 8:
						return Class1252.smethod_10(array[0], array[1]);
					case 9:
						return Class1252.smethod_19(array[0]);
					case 10:
						return Class1252.smethod_12(array[0]);
					case 11:
						return Class1252.smethod_14(array[0]);
					case 12:
						return Class1252.smethod_13(array[0]);
					case 13:
					{
						object obj2 = method_5((Class1661)class1661_0.method_7()[1], cell_0);
						if (obj2 != null)
						{
							obj2 = Class1660.smethod_9(workbook_0, obj2, bool_0: false);
							if (obj2 is ErrorType)
							{
								return obj2;
							}
						}
						else
						{
							obj2 = 0.0;
						}
						return Class1252.smethod_18(array[0], (double)obj2);
					}
					case 14:
						return Class1252.smethod_7(array[0]);
					case 15:
						return Class1252.smethod_16(array[0]);
					case 16:
						return Class1252.smethod_15(array[0]);
					case 17:
						return Class1252.smethod_6(array[0], array[1]);
					}
				}
			}
			return null;
		}
		return obj;
	}

	private object method_194(Class1661 class1661_0, Cell cell_0)
	{
		double[] array = new double[class1661_0.method_7().Count];
		int num = 0;
		object obj;
		while (true)
		{
			if (num < class1661_0.method_7().Count)
			{
				obj = method_52((Class1661)class1661_0.method_7()[num], cell_0);
				if (obj is ErrorType)
				{
					break;
				}
				array[num] = (double)obj;
				num++;
				continue;
			}
			string key;
			if ((key = class1661_0.method_3()) != null)
			{
				if (Class1742.dictionary_95 == null)
				{
					Class1742.dictionary_95 = new Dictionary<string, int>(76)
					{
						{ "AMORDEGRC", 0 },
						{ "AMORLINC", 1 },
						{ "BESSELI", 2 },
						{ "BESSELJ", 3 },
						{ "BESSELK", 4 },
						{ "BESSELY", 5 },
						{ "BIN2DEC", 6 },
						{ "BIN2HEX", 7 },
						{ "BIN2OCT", 8 },
						{ "DEC2BIN", 9 },
						{ "DEC2HEX", 10 },
						{ "DEC2OCT", 11 },
						{ "COMBIN", 12 },
						{ "CONFIDENCE", 13 },
						{ "COUPDAYBS", 14 },
						{ "COUPDAYS", 15 },
						{ "COUPDAYSNC", 16 },
						{ "COUPNCD", 17 },
						{ "COUPNUM", 18 },
						{ "COUPPCD", 19 },
						{ "CUMIPMT", 20 },
						{ "CUMPRINC", 21 },
						{ "CRITBINOM", 22 },
						{ "DEGREES", 23 },
						{ "DELTA", 24 },
						{ "DISC", 25 },
						{ "DOLLARDE", 26 },
						{ "DOLLARFR", 27 },
						{ "DURATION", 28 },
						{ "EVEN", 29 },
						{ "EFFECT", 30 },
						{ "ERF", 31 },
						{ "ERFC", 32 },
						{ "FACT", 33 },
						{ "FACTDOUBLE", 34 },
						{ "FISHER", 35 },
						{ "FISHERINV", 36 },
						{ "GAMMALN", 37 },
						{ "GCD", 38 },
						{ "GESTEP", 39 },
						{ "HYPGEOMDIST", 40 },
						{ "INTRATE", 41 },
						{ "ISPMT", 42 },
						{ "LCM", 43 },
						{ "LOG", 44 },
						{ "LOGINV", 45 },
						{ "LOGNORMDIST", 46 },
						{ "MDURATION", 47 },
						{ "NEGBINOMDIST", 48 },
						{ "NOMINAL", 49 },
						{ "OCT2BIN", 50 },
						{ "OCT2DEC", 51 },
						{ "OCT2HEX", 52 },
						{ "ODD", 53 },
						{ "ODDFPRICE", 54 },
						{ "ODDFYIELD", 55 },
						{ "ODDLPRICE", 56 },
						{ "ODDLYIELD", 57 },
						{ "PERMUT", 58 },
						{ "PRICE", 59 },
						{ "PRICEDISC", 60 },
						{ "PRICEMAT", 61 },
						{ "QUOTIENT", 62 },
						{ "RADIANS", 63 },
						{ "RANDBETWEEN", 64 },
						{ "RECEIVED", 65 },
						{ "ROMAN", 66 },
						{ "SQRTPI", 67 },
						{ "STANDARDIZE", 68 },
						{ "TBILLEQ", 69 },
						{ "TBILLPRICE", 70 },
						{ "TBILLYIELD", 71 },
						{ "WEIBULL", 72 },
						{ "YIELD", 73 },
						{ "YIELDDISC", 74 },
						{ "YIELDMAT", 75 }
					};
				}
				if (Class1742.dictionary_95.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						return Class1378.smethod_26(array[0], CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[2], workbook_0.Settings.Date1904), array[3], array[4], array[5], (array.Length > 6) ? ((int)array[6]) : 0);
					case 1:
						return Class1378.smethod_29(array[0], CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[2], workbook_0.Settings.Date1904), array[3], array[4], array[5], (array.Length > 6) ? ((int)array[6]) : 0);
					case 2:
						return Class1252.smethod_55(array[0], (int)array[1]);
					case 3:
						return Class1252.smethod_51(array[0], (int)array[1]);
					case 4:
						return Class1252.smethod_57(array[0], (int)array[1]);
					case 5:
						return Class1252.smethod_53(array[0], (int)array[1]);
					case 6:
						return Class1252.smethod_26((long)array[0]);
					case 7:
						if (array.Length > 1)
						{
							return Class1252.smethod_29((long)array[0], (int)array[1]);
						}
						return Class1252.smethod_30((long)array[0]);
					case 8:
						if (array.Length > 1)
						{
							return Class1252.smethod_27((long)array[0], (int)array[1]);
						}
						return Class1252.smethod_28((long)array[0]);
					case 9:
						if (array.Length > 1)
						{
							return Class1252.smethod_32((long)array[0], (int)array[1]);
						}
						return Class1252.smethod_31((long)array[0]);
					case 10:
						if (array.Length > 1)
						{
							return Class1252.smethod_36((long)array[0], (int)array[1]);
						}
						return Class1252.smethod_35((long)array[0]);
					case 11:
						if (array.Length > 1)
						{
							return Class1252.smethod_34((long)array[0], (int)array[1]);
						}
						return Class1252.smethod_33((long)array[0]);
					case 12:
						return Class1341.smethod_15(array[0], array[1]);
					case 13:
						return Class1668.smethod_52(array[0], array[1], (int)array[2]);
					case 14:
						return Class1378.smethod_33(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), (int)array[2], (array.Length > 3) ? ((int)array[3]) : 0);
					case 15:
						return Class1378.smethod_34(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), (int)array[2], (array.Length > 3) ? ((int)array[3]) : 0);
					case 16:
						return Class1378.smethod_35(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), (int)array[2], (array.Length > 3) ? ((int)array[3]) : 0);
					case 17:
						return Class1378.smethod_56(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), (int)array[2], (array.Length > 3) ? ((int)array[3]) : 0);
					case 18:
						return Class1378.smethod_57(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), (int)array[2], (array.Length > 3) ? ((int)array[3]) : 0);
					case 19:
						return Class1378.smethod_55(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), (int)array[2], (array.Length > 3) ? ((int)array[3]) : 0);
					case 20:
						if (!(array[0] <= 0.0) && !(array[1] <= 0.0) && array[2] > 0.0)
						{
							if (!(array[3] < 1.0) && !(array[4] < 1.0) && array[3] <= array[4])
							{
								return Class1378.smethod_76(array[0], array[1], array[2], array[3], array[4], array[5]);
							}
							return ErrorType.Number;
						}
						return ErrorType.Number;
					case 21:
						return Class1378.smethod_78(array[0], array[1], array[2], array[3], array[4], array[5]);
					case 22:
						return Class1668.smethod_54((int)array[0], array[1], array[2]);
					case 23:
						return array[0] * 180.0 / Math.PI;
					case 24:
						if (array.Length > 1)
						{
							return Class1252.smethod_22(array[0], array[1]);
						}
						return Class1252.smethod_23(array[0]);
					case 25:
						return Class1378.smethod_68(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2], array[3], (array.Length > 4) ? ((int)array[4]) : 0);
					case 26:
						return Class1378.smethod_69(array[0], array[1]);
					case 27:
						return Class1378.smethod_70(array[0], array[1]);
					case 28:
						return Class1378.smethod_31(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2], array[3], (int)array[4], (array.Length > 5) ? ((int)array[5]) : 0);
					case 29:
						return Class1341.smethod_7(array[0]);
					case 30:
						return Class1378.smethod_71(array[0], (int)array[1]);
					case 31:
						if (array.Length > 1)
						{
							return Class1252.smethod_47(array[0], array[1]);
						}
						return Class1252.smethod_48(array[0]);
					case 32:
						return Class1252.smethod_49(array[0]);
					case 33:
						if (array[0] < 0.0)
						{
							return ErrorType.Number;
						}
						return Class1341.smethod_14((int)array[0]);
					case 34:
						if (array[0] < 0.0)
						{
							return ErrorType.Number;
						}
						return Class1341.smethod_13((int)array[0]);
					case 35:
						return Class1668.smethod_57(array[0]);
					case 36:
						return Class1668.smethod_58(array[0]);
					case 37:
						return Class1668.smethod_60(array[0]);
					case 38:
						if (!(array[0] < 0.0) && array[1] >= 0.0)
						{
							return Class1341.smethod_12((int)array[0], (int)array[1]);
						}
						return ErrorType.Number;
					case 39:
						if (array.Length > 1)
						{
							return Class1252.smethod_24(array[0], array[1]);
						}
						return Class1252.smethod_25(array[0]);
					case 40:
						return Class1668.smethod_62(array[0], array[1], array[2], array[3]);
					case 41:
						return Class1378.smethod_73(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2], array[3], (array.Length > 4) ? ((int)array[4]) : 0);
					case 42:
						return Class1378.smethod_77(array[0], array[1], array[2], array[3]);
					case 43:
						if (!(array[0] < 0.0) && array[1] >= 0.0)
						{
							return Class1341.smethod_9((int)array[0], (int)array[1]);
						}
						return ErrorType.Number;
					case 44:
						if (!(array[0] < 0.0) && (array.Length < 2 || array[1] >= 0.0))
						{
							if (array.Length >= 2)
							{
								return Math.Log(array[0], array[1]);
							}
							return Math.Log(array[0], 10.0);
						}
						return ErrorType.Number;
					case 45:
						return Class1668.smethod_50(array[0], array[1], array[2]);
					case 46:
						return Class1668.smethod_51(array[0], array[1], array[2]);
					case 47:
						return Class1378.smethod_32(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2], array[3], (int)array[4], (array.Length > 5) ? ((int)array[5]) : 0);
					case 48:
						return Class1668.smethod_63(array[0], array[1], array[2]);
					case 49:
						return Class1378.smethod_72(array[0], (int)array[1]);
					case 50:
						if (array.Length > 1)
						{
							return Class1252.smethod_43((long)array[0], (int)array[1]);
						}
						return Class1252.smethod_42((long)array[0]);
					case 51:
						return Class1252.smethod_44((long)array[0]);
					case 52:
						if (array.Length > 1)
						{
							return Class1252.smethod_46((long)array[0], (int)array[1]);
						}
						return Class1252.smethod_45((long)array[0]);
					case 53:
						return Class1341.smethod_8(array[0]);
					case 54:
						return Class1378.smethod_49(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[2], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[3], workbook_0.Settings.Date1904), array[4], array[5], (int)array[6], (int)array[7], (array.Length > 8) ? ((int)array[8]) : 0);
					case 55:
						return Class1378.smethod_48(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[2], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[3], workbook_0.Settings.Date1904), array[4], array[5], (int)array[6], (int)array[7], (array.Length > 8) ? ((int)array[8]) : 0);
					case 56:
						return Class1378.smethod_40(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[2], workbook_0.Settings.Date1904), array[3], array[4], (int)array[5], (int)array[6], (array.Length > 7) ? ((int)array[7]) : 0);
					case 57:
						return Class1378.smethod_41(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[2], workbook_0.Settings.Date1904), array[3], array[4], (int)array[5], (int)array[6], (array.Length > 7) ? ((int)array[7]) : 0);
					case 58:
						return Class1668.smethod_37(array[0], array[1]);
					case 59:
						return Class1378.smethod_50(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2], array[3], (int)array[4], (int)array[5], (array.Length > 6) ? ((int)array[6]) : 0);
					case 60:
						return Class1378.smethod_43(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2], array[3], (array.Length > 4) ? ((int)array[4]) : 0);
					case 61:
						return Class1378.smethod_51(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[2], workbook_0.Settings.Date1904), array[3], array[4], (array.Length > 5) ? ((int)array[5]) : 0);
					case 62:
						return (int)(array[0] / array[1]);
					case 63:
						return array[0] * Math.PI / 180.0;
					case 64:
					{
						Random random = new Random();
						if (array[0] > array[1])
						{
							return ErrorType.Number;
						}
						return (double)random.Next((int)array[0], (int)array[1]);
					}
					case 65:
						return Class1378.smethod_74(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2], array[3], (array.Length > 4) ? ((int)array[4]) : 0);
					case 66:
					{
						int num2 = (int)array[0];
						int num3 = 0;
						if (array.Length > 1)
						{
							num3 = (int)array[1];
						}
						if (num2 >= 0 && num2 <= 3999)
						{
							return Class1341.smethod_5(num2, num3);
						}
						return ErrorType.Value;
					}
					case 67:
						if (array[0] < 0.0)
						{
							return ErrorType.Value;
						}
						return Math.Sqrt(array[0] * Math.PI);
					case 68:
						return Class1668.smethod_36(array[0], array[1], array[2]);
					case 69:
						return Class1378.smethod_44(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2]);
					case 70:
						return Class1378.smethod_45(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2]);
					case 71:
						return Class1378.smethod_46(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2]);
					case 72:
						return Class1668.smethod_32(array[0], array[1], array[2], array[3] != 0.0);
					case 73:
						return Class1378.smethod_53(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2], array[3], array[4], (int)array[5], (array.Length > 6) ? ((int)array[6]) : 0);
					case 74:
						return Class1378.smethod_47(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), array[2], array[3], (array.Length > 4) ? ((int)array[4]) : 0);
					case 75:
						return Class1378.smethod_52(CellsHelper.GetDateTimeFromDouble(array[0], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[1], workbook_0.Settings.Date1904), CellsHelper.GetDateTimeFromDouble(array[2], workbook_0.Settings.Date1904), array[3], array[4], (array.Length > 5) ? ((int)array[5]) : 0);
					}
				}
			}
			return null;
		}
		return obj;
	}

	private object method_195(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double)
		{
			return Math.Tan((double)obj);
		}
		return obj;
	}

	private object method_196(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double)
		{
			return Math.Tanh((double)obj);
		}
		return obj;
	}

	private object method_197(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double num)
		{
			return Math.Log(num + Math.Sqrt(num * num + 1.0));
		}
		return obj;
	}

	private object method_198(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double num)
		{
			if (num < 1.0)
			{
				return ErrorType.Number;
			}
			return Math.Log(num + Math.Sqrt(num * num - 1.0));
		}
		return obj;
	}

	private object method_199(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double num)
		{
			if (!(num <= -1.0) && num < 1.0)
			{
				return Math.Log((1.0 + num) / (1.0 - num)) / 2.0;
			}
			return ErrorType.Number;
		}
		return obj;
	}

	private object method_200(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double d)
		{
			return Math.Atan(d);
		}
		return obj;
	}

	private object method_201(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && class1661_0.method_7().Count == 2)
		{
			Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
			object object_ = method_5(class1661_, cell_0);
			object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
			if (object_ is ErrorType)
			{
				return object_;
			}
			class1661_ = (Class1661)class1661_0.method_7()[1];
			object object_2 = method_5(class1661_, cell_0);
			object_2 = Class1660.smethod_26(object_2, workbook_0.Settings.Date1904);
			if (object_2 is ErrorType)
			{
				return object_2;
			}
			if ((double)object_2 == 0.0 && (double)object_ == 0.0)
			{
				return ErrorType.Div;
			}
			return Math.Atan2((double)object_2, (double)object_);
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private object method_202(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = Class1660.smethod_26(method_5(class1661_, cell_0), workbook_0.Settings.Date1904);
		if (obj is double)
		{
			if ((double)obj < 0.0)
			{
				return ErrorType.Number;
			}
			return Math.Sqrt((double)obj);
		}
		return obj;
	}

	private object method_203(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object object_ = method_5(class1661_, cell_0);
		object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
		if (object_ is ErrorType)
		{
			return object_;
		}
		double num = Math.Exp((double)object_);
		if (double.IsInfinity(num))
		{
			return ErrorType.Number;
		}
		return num;
	}

	private object method_204(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object object_ = method_5(class1661_, cell_0);
		object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
		if (object_ is ErrorType)
		{
			return object_;
		}
		double num = (double)object_;
		if (num <= 0.0)
		{
			return ErrorType.Number;
		}
		return Math.Log(num);
	}

	private object method_205(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object object_ = method_5(class1661_, cell_0);
		object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
		if (object_ is ErrorType)
		{
			return object_;
		}
		if ((double)object_ <= 0.0)
		{
			return ErrorType.Number;
		}
		return Math.Log10((double)object_);
	}

	private object method_206(Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7().Count != 1)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
		}
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object object_ = method_5(class1661_, cell_0);
		object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
		if (object_ is ErrorType)
		{
			return object_;
		}
		double num = (double)object_;
		if (num < 0.0)
		{
			return -1.0;
		}
		if (num > 0.0)
		{
			return 1.0;
		}
		return 0.0;
	}

	private object method_207(Class1661 class1661_0, Cell cell_0)
	{
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object obj = method_5(class1661_, cell_0);
		if (obj == null)
		{
			return 0.0;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		if (obj is Array)
		{
			return Class1120.smethod_10(workbook_0, obj);
		}
		switch (Type.GetTypeCode(obj.GetType()))
		{
		case TypeCode.Double:
			return Math.Abs((double)obj);
		case TypeCode.DateTime:
			return Math.Abs(CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbook_0.Settings.Date1904));
		default:
			return ErrorType.Value;
		case TypeCode.String:
			return ErrorType.Value;
		case TypeCode.Boolean:
			if ((bool)obj)
			{
				return 1.0;
			}
			return 0.0;
		}
	}

	private object method_208(Class1661 class1661_0, Cell cell_0)
	{
		int num = 0;
		int num2 = 0;
		Class1661 class1661_ = (Class1661)class1661_0.method_7()[0];
		object object_ = method_5(class1661_, cell_0);
		object_ = Class1660.smethod_26(object_, workbook_0.Settings.Date1904);
		if (object_ is ErrorType)
		{
			return object_;
		}
		num = (int)Class1179.ToDouble(object_);
		if (num < 1)
		{
			return ErrorType.Value;
		}
		Class1661 class1661_2 = (Class1661)class1661_0.method_7()[1];
		object object_2 = method_5(class1661_2, cell_0);
		object_2 = Class1660.smethod_26(object_2, workbook_0.Settings.Date1904);
		if (object_2 is ErrorType)
		{
			return object_2;
		}
		num2 = (int)Class1179.ToDouble(object_2);
		if (num2 < 1)
		{
			return ErrorType.Value;
		}
		num--;
		num2--;
		bool flag = true;
		bool flag2 = true;
		if (class1661_0.method_7().Count > 2)
		{
			Class1661 @class = (Class1661)class1661_0.method_7()[2];
			object obj = method_5(@class, cell_0);
			obj = ((obj != null || @class.method_9()[0] != 22) ? Class1660.smethod_26(obj, workbook_0.Settings.Date1904) : ((object)1.0));
			if (obj is ErrorType)
			{
				return obj;
			}
			if (obj != null)
			{
				switch ((int)Class1179.ToDouble(obj))
				{
				default:
					return ErrorType.Value;
				case 2:
				case 6:
					flag2 = false;
					break;
				case 3:
				case 7:
					flag = false;
					break;
				case 4:
				case 8:
					flag = (flag2 = false);
					break;
				case 1:
				case 5:
					break;
				}
			}
		}
		bool flag3 = true;
		if (class1661_0.method_7().Count > 3)
		{
			Class1661 class1661_3 = (Class1661)class1661_0.method_7()[3];
			method_5(class1661_3, cell_0);
		}
		string text = null;
		if (class1661_0.method_7().Count > 4)
		{
			object obj2 = method_5((Class1661)class1661_0.method_7()[4], cell_0);
			if (obj2 != null)
			{
				obj2 = Class1660.GetStringValue(obj2);
				if (obj2 is ErrorType)
				{
					return obj2;
				}
				text = (string)obj2;
				if (text != null && Class1677.smethod_21(text))
				{
					text = "'" + text + "'";
				}
			}
		}
		string text2 = "";
		if (flag3)
		{
			text2 = CellsHelper.CellIndexToName(num, num2);
			if (flag)
			{
				for (int i = 0; i < text2.Length; i++)
				{
					if (text2[i] >= '0' && text2[i] <= '9')
					{
						text2 = text2.Insert(i, "$");
						break;
					}
				}
			}
			if (flag2)
			{
				text2 = text2.Insert(0, "$");
			}
		}
		if (text != null)
		{
			text2 = text + "!" + text2;
		}
		return text2;
	}

	internal void method_209(Cell cell_0, Cell cell_1)
	{
		CellArea cellArea = cell_0.method_50().CellArea;
		for (int i = cellArea.StartRow; i <= cellArea.EndRow; i++)
		{
			Row row = cell_0.method_4().Rows.method_3(i);
			if (row == null)
			{
				continue;
			}
			for (int j = cellArea.StartColumn; j <= cellArea.EndColumn; j++)
			{
				Cell cellOrNull = row.GetCellOrNull(j);
				if (cellOrNull == null || !cellOrNull.IsFormula || !Class1120.Equals(cellOrNull.method_41(), cell_0.method_41()))
				{
					continue;
				}
				if (cellOrNull.method_60() != 0)
				{
					break;
				}
				cellOrNull.method_61(1);
				Class1661 @class = workbook_0.Worksheets.Formula.method_10(cellOrNull);
				if (bool_1 && workbook_0.Worksheets.Formula.method_12())
				{
					@class = null;
				}
				if (@class != null)
				{
					object object_ = method_5(@class, cellOrNull);
					if (cellOrNull.method_62() & !bool_2)
					{
						cellOrNull.method_63(bool_0: false);
						cellOrNull.method_61(2);
					}
					else
					{
						cellOrNull.method_66(object_, 2);
					}
				}
				else
				{
					cellOrNull.method_61(2);
				}
				if (cellOrNull == cell_1)
				{
					return;
				}
			}
		}
	}

	private void method_210()
	{
		bool_2 = true;
		int count = arrayList_1.Count;
		for (int i = 0; i < workbook_0.Settings.MaxIteration; i++)
		{
			bool flag = true;
			for (int j = 0; j < arrayList_1.Count; j++)
			{
				Class1376 @class = (Class1376)arrayList_1[j];
				object obj = method_5(@class.class1661_0, @class.cell_0);
				object obj2 = Class1662.Compare(obj, @class.object_0, "=", workbook_0.Settings.Date1904);
				if (obj2 == null || !(obj2 is bool) || !(bool)obj2)
				{
					flag = false;
				}
				@class.object_0 = obj;
				@class.cell_0.method_66(obj, 2);
			}
			if (flag)
			{
				break;
			}
		}
		for (int k = 0; k < arrayList_0.Count; k++)
		{
			((Class1375)arrayList_0[k]).bool_1 = false;
		}
		for (int l = count; l < arrayList_1.Count; l++)
		{
			((Class1376)arrayList_1[l]).cell_0.method_63(bool_0: false);
		}
		hashtable_2.Clear();
		arrayList_1.Clear();
		bool_2 = false;
	}

	internal object method_211(Cell cell_0)
	{
		if (cell_0.IsFormula)
		{
			switch (cell_0.method_60())
			{
			case 0:
			{
				if (cell_0.method_41() != null && workbook_0.Worksheets.Formula.method_13(1, cell_0.method_41()))
				{
					Cell cell = cell_0.method_47();
					if (cell != null && cell.method_60() == 0 && cell.method_50() != null && !cell.method_50().method_1())
					{
						method_209(cell, cell_0);
					}
				}
				if (cell_0.method_60() != 0)
				{
					return cell_0.method_59();
				}
				cell_0.method_61(1);
				Class1661 class1661_ = workbook_0.Worksheets.Formula.method_10(cell_0);
				if (bool_1 && workbook_0.Worksheets.Formula.method_12())
				{
					class1661_ = null;
				}
				if (class1661_ != null)
				{
					object obj = method_5(class1661_, cell_0);
					if (cell_0.method_62() & !bool_2)
					{
						cell_0.method_63(bool_0: false);
						cell_0.method_61(2);
						return cell_0.method_59();
					}
					if (cell_0.IsArrayHeader)
					{
						Class1379.smethod_0(obj, cell_0);
					}
					else
					{
						cell_0.method_66(obj, 2);
					}
					if (obj != null && !(obj is Array))
					{
						return obj;
					}
					return cell_0.method_59();
				}
				cell_0.method_61(2);
				return cell_0.Value;
			}
			case 1:
				if (workbook_0.Settings.Iteration)
				{
					string key = cell_0.method_4().method_3().Name + "!" + cell_0.Name;
					if (method_212()[key] != null)
					{
						Class1376 @class = (Class1376)method_212()[key];
						if (!bool_2)
						{
							method_210();
						}
						return @class.object_0;
					}
					Class1376 class2 = new Class1376();
					Class1661 class1661_ = (class2.class1661_0 = workbook_0.Worksheets.Formula.method_10(cell_0));
					class2.int_0 = 1;
					class2.object_0 = cell_0.Value;
					class2.bool_0 = false;
					class2.int_1 = hashtable_2.Count;
					class2.cell_0 = cell_0;
					cell_0.method_63(bool_0: true);
					method_212()[key] = class2;
					arrayList_1.Add(class2);
					method_5(class1661_, cell_0);
					return cell_0.method_59();
				}
				cell_0.method_61(2);
				if (bool_1)
				{
					cell_0.method_63(bool_0: true);
					return cell_0.Value;
				}
				return ErrorType.Recursive;
			}
		}
		return cell_0.method_59();
	}

	[SpecialName]
	internal Hashtable method_212()
	{
		if (hashtable_2 == null)
		{
			hashtable_2 = new Hashtable();
			arrayList_1 = new ArrayList();
		}
		return hashtable_2;
	}
}
