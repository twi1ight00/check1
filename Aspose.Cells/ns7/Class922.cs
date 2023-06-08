using System.Collections;
using System.Globalization;
using System.Text;
using Aspose.Cells;
using ns12;
using ns2;
using ns29;

namespace ns7;

internal class Class922
{
	internal static bool smethod_0(Interface45 interface45_0, WorksheetCollection worksheetCollection_0)
	{
		if (interface45_0.imethod_4() != null)
		{
			int[] range = Class1279.GetRange(worksheetCollection_0, interface45_0.imethod_4(), -1, bool_0: true, 0, 0);
			if (range != null)
			{
				if (range[1] == range[3])
				{
					return false;
				}
				if (range[2] == range[4])
				{
					return false;
				}
				return true;
			}
		}
		if (interface45_0.imethod_2() != null)
		{
			foreach (object item in interface45_0.imethod_2())
			{
				if (item != null && item is string)
				{
					string text = (string)item;
					if (text.IndexOf('\n') != -1)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	internal static void smethod_1(ArrayList arrayList_0, ArrayList arrayList_1, bool bool_0)
	{
		if (arrayList_0 == null)
		{
			return;
		}
		foreach (object item in arrayList_0)
		{
			Class1196 @class = new Class1196(item, 0, null);
			arrayList_1.Add(@class);
			if (!(item is double) && !(item is int))
			{
				string text = (string)item;
				if (Class1673.smethod_8(text))
				{
					@class.cellValueType_0 = CellValueType.IsError;
					if (bool_0)
					{
						@class.object_0 = 0.0;
					}
				}
				else if (bool_0 && Class1677.smethod_18(text))
				{
					@class.object_0 = double.Parse(text, CultureInfo.InvariantCulture);
					@class.cellValueType_0 = CellValueType.IsNumeric;
				}
				else
				{
					@class.cellValueType_0 = CellValueType.IsString;
				}
			}
			else
			{
				@class.cellValueType_0 = CellValueType.IsNumeric;
			}
		}
	}

	internal static Style smethod_2(Cells cells_0, int int_0, int int_1)
	{
		int num = cells_0.Rows.method_5(int_0);
		if (num != -1)
		{
			Row rowByIndex = cells_0.Rows.GetRowByIndex(num);
			if (rowByIndex.method_27())
			{
				return rowByIndex.method_26();
			}
		}
		return null;
	}

	internal static string smethod_3(ArrayList arrayList_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('{');
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			object obj = arrayList_0[i];
			if (obj is double num)
			{
				if (num == (double)(int)num)
				{
					stringBuilder.Append((int)num);
				}
				else
				{
					stringBuilder.Append(num.ToString("0.##################################", CultureInfo.InvariantCulture));
				}
			}
			else
			{
				stringBuilder.Append((string)obj);
			}
			stringBuilder.Append(',');
		}
		return stringBuilder.ToString(0, stringBuilder.Length - 1) + "}";
	}

	internal static string[] smethod_4(string string_0)
	{
		ArrayList arrayList = new ArrayList();
		char[] array = string_0.ToCharArray();
		bool flag = false;
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			char c = array[i];
			if (c == '\'')
			{
				flag = !flag;
			}
			if (!flag && c == ',')
			{
				arrayList.Add(new string(array, num, i - num));
				num = i + 1;
			}
		}
		if (arrayList.Count == 0)
		{
			return new string[1] { string_0 };
		}
		arrayList.Add(new string(array, num, array.Length - num));
		string[] array2 = new string[arrayList.Count];
		for (int j = 0; j < arrayList.Count; j++)
		{
			array2[j] = (string)arrayList[j];
		}
		return array2;
	}

	internal static ArrayList smethod_5(ArrayList arrayList_0, bool bool_0, bool bool_1, ref int int_0)
	{
		int_0 = 1;
		string[][] array = new string[arrayList_0.Count][];
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			if (arrayList_0[i] != null)
			{
				string string_ = arrayList_0[i].ToString();
				array[i] = Class1679.Split(string_, '\n');
				if (array[i] != null && int_0 < array[i].Length)
				{
					int_0 = array[i].Length;
				}
			}
		}
		if (int_0 == 1)
		{
			ArrayList arrayList = new ArrayList();
			smethod_1(arrayList_0, arrayList, bool_0: true);
			return arrayList;
		}
		ArrayList arrayList2 = new ArrayList();
		for (int j = 0; j < int_0; j++)
		{
			arrayList2.Add(new ArrayList());
		}
		for (int k = 0; k < array.Length; k++)
		{
			if (array[k] == null)
			{
				for (int l = 0; l < int_0; l++)
				{
					Class1196 value = new Class1196(null, 0, null);
					((ArrayList)arrayList2[l]).Add(value);
				}
				continue;
			}
			for (int num = int_0 - 1; num >= 0; num--)
			{
				int num2 = int_0 - 1 - num;
				_ = (ArrayList)arrayList2[num];
				if (num2 < array[k].Length)
				{
					string text = array[k][num2];
					Class1196 @class = new Class1196(text, 0, null);
					((ArrayList)arrayList2[num]).Add(@class);
					if (text != null)
					{
						if (Class1673.smethod_8(text))
						{
							@class.cellValueType_0 = CellValueType.IsError;
						}
						else
						{
							@class.cellValueType_0 = CellValueType.IsString;
						}
					}
				}
				else
				{
					Class1196 value2 = new Class1196(null, 0, null);
					((ArrayList)arrayList2[num]).Add(value2);
				}
			}
		}
		return arrayList2;
	}
}
