using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns12;

internal class Class1660
{
	internal static string[] Split(string string_0, char char_0)
	{
		if (string_0.IndexOf('\'') != -1)
		{
			char[] array = string_0.ToCharArray();
			ArrayList arrayList = new ArrayList();
			StringBuilder stringBuilder = new StringBuilder(array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == char_0)
				{
					arrayList.Add(stringBuilder.ToString());
					stringBuilder = new StringBuilder(array.Length);
				}
				else if (array[i] == '\'')
				{
					stringBuilder.Append(array[i]);
					for (i++; i < array.Length; i++)
					{
						stringBuilder.Append(array[i]);
						if (array[i] == '\'')
						{
							break;
						}
					}
				}
				else
				{
					stringBuilder.Append(array[i]);
				}
			}
			arrayList.Add(stringBuilder.ToString());
			string[] array2 = new string[arrayList.Count];
			for (int j = 0; j < arrayList.Count; j++)
			{
				array2[j] = (string)arrayList[j];
			}
			return array2;
		}
		return string_0.Split(char_0);
	}

	internal static string smethod_0(string string_0)
	{
		string_0 = string_0.Replace("'", "''");
		return string_0;
	}

	internal static int smethod_1(string string_0, char char_0)
	{
		int num = string_0.Length - 1;
		while (true)
		{
			if (num >= 0)
			{
				char c = string_0[num];
				if (c != '"' && c != '\'')
				{
					if (string_0[num] == char_0)
					{
						break;
					}
				}
				else
				{
					char c2 = string_0[num];
					num--;
					while (num >= 0 && string_0[num] != c2)
					{
						num--;
					}
				}
				num--;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal static string smethod_2(string string_0)
	{
		if (string_0[0] == '\'' && string_0[string_0.Length - 1] == '\'')
		{
			string_0 = string_0.Substring(1, string_0.Length - 2);
			string_0 = string_0.Replace("''", "'");
		}
		return string_0;
	}

	internal static int[] smethod_3(WorksheetCollection worksheetCollection_0, string string_0)
	{
		if (string_0.Length == 0)
		{
			return worksheetCollection_0.method_39().method_0(worksheetCollection_0);
		}
		string_0 = smethod_2(string_0);
		int num = -1;
		int num2 = -1;
		int num3 = worksheetCollection_0.method_36();
		int num4 = -1;
		string text = string_0.ToUpper();
		switch (string_0)
		{
		case "#REF":
		case "#REF!":
			num = (num2 = -1);
			num4 = worksheetCollection_0.method_32().method_10(num3, 65535, 65535);
			if (num4 == -1)
			{
				num4 = worksheetCollection_0.method_32().method_3((ushort)num3, ushort.MaxValue, ushort.MaxValue);
			}
			break;
		default:
		{
			object obj = worksheetCollection_0.method_6()[text];
			if (obj != null)
			{
				int[] array = (int[])obj;
				num = (num2 = array[0]);
				num4 = array[1];
				break;
			}
			int num5 = string_0.LastIndexOf('[');
			if (num5 != -1)
			{
				string text2 = null;
				int num6 = string_0.LastIndexOf(']');
				text2 = ((num5 == 0) ? string_0.Substring(1, num6 - 1) : (string_0.Substring(0, num5) + string_0.Substring(num5 + 1, num6 - num5 - 1)));
				string_0 = string_0.Substring(num6 + 1);
				int[] array2 = smethod_4(worksheetCollection_0, text2, string_0, bool_0: true);
				num3 = array2[0];
				num4 = array2[1];
				break;
			}
			int num7 = string_0.IndexOf(":");
			num = (num2 = -1);
			bool flag = false;
			int num8 = -1;
			if (num7 != -1 && num7 + 1 < string_0.Length && string_0[num7 + 1] != '\\' && string_0[num7 + 1] != '/')
			{
				string[] array3 = text.Split(':');
				if (array3.Length != 2)
				{
					throw new CellsException(ExceptionType.Formula, "Invalid formula.");
				}
				bool flag2 = false;
				for (num8 = 0; num8 < worksheetCollection_0.Count; num8++)
				{
					string text3 = worksheetCollection_0[num8].Name.ToUpper();
					if (text3 == array3[0])
					{
						flag = true;
						num = num8;
					}
					else if (text3 == array3[1])
					{
						flag2 = true;
						num2 = num8;
						break;
					}
				}
				if (!flag || !flag2 || num2 < num)
				{
					throw new CellsException(ExceptionType.Formula, "Invalid formula.");
				}
				num4 = worksheetCollection_0.method_32().method_10(num3, num, num2);
				if (num4 == -1)
				{
					num4 = worksheetCollection_0.method_32().method_3((ushort)num3, (ushort)num, (ushort)num2);
				}
			}
			else
			{
				int[] array4 = smethod_4(worksheetCollection_0, string_0, null, bool_0: false);
				num3 = array4[0];
				num4 = array4[1];
			}
			break;
		}
		}
		return new int[4] { num4, num3, num, num2 };
	}

	private static int[] smethod_4(WorksheetCollection worksheetCollection_0, string string_0, string string_1, bool bool_0)
	{
		int num = 0;
		int num2 = 0;
		Class1303 @class = worksheetCollection_0.method_39();
		if (worksheetCollection_0.Workbook.FileName != null && worksheetCollection_0.Workbook.FileName.EndsWith(string_0))
		{
			num = worksheetCollection_0.method_36();
			num2 = worksheetCollection_0.method_32().method_11(num, 65534, 65534, bool_0: true);
			return new int[2] { num, num2 };
		}
		string_0 = Class1718.smethod_0(string_0, Enum188.const_0);
		bool flag = false;
		if (@class != null)
		{
			if (Class1677.smethod_19(string_0))
			{
				num = int.Parse(string_0);
				int num3 = 0;
				int num4 = 0;
				Class1718 class2 = @class[num];
				int[] array = smethod_5(worksheetCollection_0, class2, class2.method_16(), string_1, num);
				if (flag = array != null)
				{
					num3 = array[0];
					num4 = array[1];
					num2 = worksheetCollection_0.method_32().method_11(num, num3, num4, bool_0: true);
				}
			}
			else
			{
				for (int i = 0; i < @class.Count; i++)
				{
					Class1718 class2 = @class[i];
					if (class2.method_15())
					{
						int num5 = 0;
						int num6 = 0;
						int[] array2 = smethod_5(worksheetCollection_0, class2, string_0, string_1, i);
						if (flag = array2 != null)
						{
							num5 = array2[0];
							num6 = array2[1];
							num = i;
							num2 = worksheetCollection_0.method_32().method_11(i, num5, num6, bool_0: true);
							break;
						}
					}
				}
			}
		}
		if (!flag)
		{
			Class1718 class2;
			if (worksheetCollection_0.method_39() == null)
			{
				worksheetCollection_0.method_40(new Class1303());
				class2 = new Class1718();
				class2.Type = Enum194.const_1;
				worksheetCollection_0.method_39().Add(class2);
			}
			class2 = new Class1718();
			class2.Type = Enum194.const_0;
			class2.method_17(string_0);
			num = worksheetCollection_0.method_39().Count;
			worksheetCollection_0.method_39().Add(class2);
			if (string_1 != null && !(string_1 == ""))
			{
				class2.method_5(new string[1] { string_1 });
				num2 = worksheetCollection_0.method_32().method_3((ushort)(worksheetCollection_0.method_39().Count - 1), 0, 0);
			}
			else
			{
				class2.method_5(new string[1] { "Sheet1" });
				num2 = worksheetCollection_0.method_32().method_3((ushort)(worksheetCollection_0.method_39().Count - 1), 65534, 65534);
			}
		}
		return new int[2] { num, num2 };
	}

	private static int[] smethod_5(WorksheetCollection worksheetCollection_0, Class1718 class1718_0, string string_0, string string_1, int int_0)
	{
		int num = 0;
		int num2 = 0;
		if (string.Compare(class1718_0.method_16(), string_0, ignoreCase: true) == 0)
		{
			bool flag = false;
			if (string_1 != null && !(string_1 == ""))
			{
				string_1 = string_1.ToUpper();
				int num3 = string_1.IndexOf(':');
				if (num3 != -1)
				{
					string[] array = string_1.Split(':');
					for (int i = 0; i < class1718_0.method_4().Length; i++)
					{
						if (class1718_0.method_4()[i].ToUpper() == array[0].ToUpper())
						{
							num = i;
							flag = true;
						}
						if (class1718_0.method_4()[i].ToUpper() == array[1].ToUpper())
						{
							num2 = i;
							flag = true;
						}
					}
				}
				else
				{
					for (int j = 0; j < class1718_0.method_4().Length; j++)
					{
						if (class1718_0.method_4()[j].ToUpper() == string_1.ToUpper())
						{
							num = (num2 = j);
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					class1718_0.method_3(string_1);
					num = class1718_0.method_4().Length - 1;
					worksheetCollection_0.method_32().method_3((ushort)int_0, (ushort)num, (ushort)num2);
				}
			}
			else
			{
				int num4 = worksheetCollection_0.method_32().method_8((ushort)int_0, 65534);
				if (num4 == -1)
				{
					worksheetCollection_0.method_32().method_3((ushort)int_0, 65534, 65534);
				}
				num = (num2 = 65534);
			}
			return new int[2] { num, num2 };
		}
		return null;
	}

	public static bool smethod_6(string string_0)
	{
		int num = 0;
		for (int i = 0; i < string_0.Length; i++)
		{
			switch (string_0[i])
			{
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				num++;
				break;
			case ' ':
			case '!':
			case '#':
			case '$':
			case '%':
			case '&':
			case '\'':
			case '(':
			case ')':
			case '+':
			case ',':
			case '-':
			case '<':
			case '=':
			case '>':
			case '@':
			case '\\':
			case '{':
			case '|':
			case '}':
			case '~':
				return true;
			}
		}
		return num == string_0.Length;
	}

	internal static bool smethod_7(Class1661 class1661_0)
	{
		Class1661 @class = class1661_0.method_5();
		if (@class == null)
		{
			return true;
		}
		if (@class.Type != Enum180.const_3 && @class.Type != Enum180.const_5)
		{
			return true;
		}
		if (@class.Type == Enum180.const_3)
		{
			int i;
			for (i = 0; i < @class.method_7().Count && @class.method_7()[i] != class1661_0; i++)
			{
			}
			int num = -1;
			switch (@class.method_9()[0])
			{
			default:
				return false;
			case 33:
			case 65:
			case 97:
				num = BitConverter.ToUInt16(@class.method_9(), 1);
				break;
			case 34:
			case 66:
			case 98:
				num = BitConverter.ToUInt16(@class.method_9(), 2);
				break;
			}
			Enum227[] array = smethod_23(num, Enum226.const_0);
			if (array == null)
			{
				return false;
			}
			if (i >= array.Length)
			{
				return array[array.Length - 1] == Enum227.const_1;
			}
			return array[i] == Enum227.const_1;
		}
		return false;
	}

	internal static object[][] smethod_8(double[][] double_0)
	{
		object[][] array = new object[double_0.Length][];
		for (int i = 0; i < double_0.Length; i++)
		{
			if (double_0[i] != null)
			{
				array[i] = new object[double_0[i].Length];
				for (int j = 0; j < double_0[i].Length; j++)
				{
					array[i][j] = double_0[i][j];
				}
			}
		}
		return array;
	}

	internal static object smethod_9(Workbook workbook_0, object object_0, bool bool_0)
	{
		if (object_0 == null)
		{
			return 0.0;
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			return (double)object_0;
		case TypeCode.DateTime:
			return CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbook_0.Settings.Date1904);
		case TypeCode.String:
		{
			if (bool_0)
			{
				return 0.0;
			}
			string text = (string)object_0;
			if (Class1677.smethod_20(text))
			{
				return double.Parse(text);
			}
			string pattern = "(^\\d{0,4}[ -/]\\d{1,2}[ -/]\\d{0,4}$)|(^[a-z]{1,9}\\s\\d{1,2},\\s*\\d{2,4}$)|(^\\d{0,4}[ -/]\\d{1,2}[ -/]\\d{0,4},?\\s*\\d{1,2}:\\d{2}(AM|PM)?)";
			if (Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase))
			{
				try
				{
					DateTime dateTime = DateTime.Parse(text);
					return CellsHelper.GetDoubleFromDateTime(dateTime, workbook_0.Settings.Date1904);
				}
				catch
				{
				}
			}
			return ErrorType.Value;
		}
		case TypeCode.Int16:
			return (double)(short)object_0;
		default:
			if (object_0 is double[][])
			{
				double num = 0.0;
				double[][] array = (double[][])object_0;
				int num2 = array[0].Length;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != null)
					{
						for (int j = 0; j < num2; j++)
						{
							num += array[i][j];
						}
					}
				}
				return num;
			}
			if (object_0 is Array)
			{
				double num3 = 0.0;
				Array array2 = (Array)object_0;
				foreach (object item in array2)
				{
					if (item is double)
					{
						num3 += (double)item;
					}
					else
					{
						if (!(item is Array))
						{
							continue;
						}
						Array array3 = (Array)item;
						foreach (object item2 in array3)
						{
							if (item2 is double)
							{
								num3 += (double)item2;
							}
						}
					}
				}
				return num3;
			}
			return 0.0;
		case TypeCode.Int32:
			return (double)(int)object_0;
		case TypeCode.Boolean:
			if (!bool_0 && (bool)object_0)
			{
				return 1.0;
			}
			return 0.0;
		}
	}

	internal static double[][] smethod_10(object object_0, bool bool_0)
	{
		if (object_0 is double[][])
		{
			return (double[][])object_0;
		}
		double[][] array3;
		if (object_0 is Array)
		{
			object value = ((Array)object_0).GetValue(0);
			if (value is Array)
			{
				Array array = (Array)object_0;
				Array array2 = (Array)value;
				int length = array.Length;
				int length2 = array2.Length;
				array3 = new double[length][];
				for (int i = 0; i < length; i++)
				{
					array3[i] = new double[length2];
					array2 = (Array)array.GetValue(i);
					for (int j = 0; j < length2; j++)
					{
						object value2 = array2.GetValue(j);
						if (value2 is double)
						{
							array3[i][j] = (double)value2;
						}
					}
				}
			}
			else
			{
				Array array4 = (Array)object_0;
				int length3 = array4.Length;
				array3 = new double[1][] { new double[length3] };
				for (int k = 0; k < length3; k++)
				{
					object value3 = array4.GetValue(k);
					if (value3 is double)
					{
						array3[0][k] = (double)value3;
					}
				}
			}
		}
		else
		{
			array3 = new double[1][];
			object obj = smethod_26(object_0, bool_0);
			if (obj is double)
			{
				array3[0] = new double[1] { (double)obj };
			}
			else
			{
				array3[0] = new double[1];
			}
		}
		return array3;
	}

	internal static object smethod_11(object object_0, bool bool_0)
	{
		if (object_0 == null)
		{
			return null;
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_0 is double[][])
		{
			return object_0;
		}
		if (!(object_0 is Array))
		{
			object obj = smethod_26(object_0, bool_0);
			if (obj is ErrorType)
			{
				return obj;
			}
			return new double[1][] { new double[1] { (double)obj } };
		}
		double[][] array;
		if (object_0 is Array)
		{
			object value = ((Array)object_0).GetValue(0);
			if (!(value is Array))
			{
				array = new double[1][] { (double[])object_0 };
			}
			else
			{
				Array array2 = (Array)object_0;
				Array array3 = (Array)value;
				int length = array2.Length;
				int length2 = array3.Length;
				array = new double[length][];
				for (int i = 0; i < length; i++)
				{
					array[i] = new double[length2];
					array3 = (Array)array2.GetValue(i);
					for (int j = 0; j < length2; j++)
					{
						object value2 = array3.GetValue(j);
						if (value2 is double)
						{
							array[i][j] = (double)value2;
						}
					}
				}
			}
		}
		else
		{
			array = new double[1][];
			object obj2 = smethod_26(object_0, bool_0);
			if (obj2 is double)
			{
				array[0] = new double[1] { (double)obj2 };
			}
			else
			{
				array[0] = new double[1];
			}
		}
		return array;
	}

	internal static object smethod_12(object object_0, object object_1, WorkbookSettings workbookSettings_0)
	{
		if (object_0 == null)
		{
			return null;
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		object[][] array = null;
		array = ((object_0 is object[][]) ? ((object[][])object_0) : new object[1][] { new object[1] { object_0 } });
		if (object_1 == null)
		{
			return null;
		}
		if (object_1 is ErrorType)
		{
			return object_1;
		}
		object[][] array2 = null;
		array2 = ((object_1 is object[][]) ? ((object[][])object_1) : new object[1][] { new object[1] { object_1 } });
		int num = array.Length;
		int num2 = array[0].Length;
		if (num == 1)
		{
			if (array2.Length != 1 && array2[0].Length == 1)
			{
				object[][] array3 = new object[1][] { new object[array2.Length] };
				for (int i = 0; i < array2.Length; i++)
				{
					if (array2[i] != null)
					{
						array3[0][i] = array2[i][0];
					}
				}
				array2 = array3;
			}
		}
		else if (array2.Length == 1 && array[0].Length == 1)
		{
			if (array2[0].Length != num)
			{
				return ErrorType.NA;
			}
			object[][] array4 = new object[num][];
			for (int j = 0; j < num; j++)
			{
				array4[j][0] = new object[1] { array2[0][j] };
			}
			array2 = array4;
		}
		if (array.Length == array2.Length && array[0].Length == array2[0].Length)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			for (int k = 0; k < num; k++)
			{
				if (array[k] == null || array2[k] == null)
				{
					continue;
				}
				for (int l = 0; l < num2; l++)
				{
					if (array[k][l] != null && array2[k][l] != null)
					{
						if (array[k][l] is ErrorType)
						{
							return array[k][l];
						}
						if (array2[k][l] is ErrorType)
						{
							return array2[k][l];
						}
						if (array[k][l] is double && array2[k][l] is double)
						{
							arrayList.Add(array[k][l]);
							arrayList2.Add(array2[k][l]);
						}
					}
				}
			}
			double[] array5 = new double[arrayList.Count];
			double[] array6 = new double[arrayList2.Count];
			for (int m = 0; m < arrayList.Count; m++)
			{
				array5[m] = (double)arrayList[m];
				array6[m] = (double)arrayList2[m];
			}
			return new object[2] { array5, array6 };
		}
		return ErrorType.NA;
	}

	internal static object smethod_13(object object_0, Cell cell_0, bool bool_0, bool bool_1)
	{
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_0 is double[][])
		{
			double[][] array = (double[][])object_0;
			int num = array[0].Length;
			double[] array2 = new double[array.Length * num];
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null)
				{
					for (int j = 0; j < array[i].Length; j++)
					{
						array2[i * num + j] = array[i][j];
					}
				}
			}
			return array2;
		}
		if (object_0 is Array)
		{
			object value = ((Array)object_0).GetValue(0);
			double[] array5;
			if (value is Array)
			{
				Array array3 = (Array)object_0;
				Array array4 = (Array)value;
				int length = array3.Length;
				int length2 = array4.Length;
				array5 = new double[length * length2];
				for (int k = 0; k < length; k++)
				{
					array4 = (Array)array3.GetValue(k);
					for (int l = 0; l < length2; l++)
					{
						object value2 = array4.GetValue(l);
						if (value2 is double)
						{
							array5[k * length2 + l] = (double)value2;
						}
						else if (value2 is ErrorType && !bool_1)
						{
							return value2;
						}
					}
				}
			}
			else
			{
				array5 = (double[])object_0;
			}
			return array5;
		}
		object obj = smethod_26(object_0, bool_0);
		if (obj is ErrorType)
		{
			return obj;
		}
		return new double[1] { (double)obj };
	}

	internal static object smethod_14(ArrayList arrayList_0, object object_0, Cell cell_0, bool bool_0)
	{
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_0 is double[][])
		{
			double[][] array = (double[][])object_0;
			int num = array[0].Length;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null)
				{
					for (int j = 0; j < num; j++)
					{
						arrayList_0.Add(array[i][j]);
					}
				}
			}
			return null;
		}
		if (object_0 is Array)
		{
			object value = ((Array)object_0).GetValue(0);
			if (value is Array)
			{
				Array array2 = (Array)object_0;
				Array array3 = (Array)value;
				int length = array2.Length;
				int length2 = array3.Length;
				for (int k = 0; k < length; k++)
				{
					array3 = (Array)array2.GetValue(k);
					for (int l = 0; l < length2; l++)
					{
						object value2 = array3.GetValue(l);
						if (value2 is double)
						{
							arrayList_0.Add(value2);
						}
					}
				}
			}
			else
			{
				double[] array4 = (double[])object_0;
				for (int m = 0; m < array4.Length; m++)
				{
					arrayList_0.Add(array4[m]);
				}
			}
		}
		else
		{
			object obj = smethod_26(object_0, bool_0);
			if (obj is ErrorType)
			{
				return obj;
			}
			arrayList_0.Add(obj);
		}
		return null;
	}

	internal static object smethod_15(ArrayList arrayList_0, object object_0, Cell cell_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4, bool bool_5)
	{
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_0 is double[][])
		{
			double[][] array = (double[][])object_0;
			int num = array[0].Length;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null)
				{
					for (int j = 0; j < num; j++)
					{
						arrayList_0.Add(array[i][j]);
					}
				}
			}
			return null;
		}
		if (object_0 is Array)
		{
			object value = ((Array)object_0).GetValue(0);
			if (value is Array)
			{
				Array array2 = (Array)object_0;
				Array array3 = (Array)value;
				int length = array2.Length;
				int length2 = array3.Length;
				for (int k = 0; k < length; k++)
				{
					array3 = (Array)array2.GetValue(k);
					for (int l = 0; l < length2; l++)
					{
						object value2 = array3.GetValue(l);
						if (value2 == null)
						{
							if (!bool_2)
							{
								arrayList_0.Add(0.0);
							}
							continue;
						}
						if (value2 is ErrorType)
						{
							if (!bool_3)
							{
								arrayList_0.Add(0.0);
							}
							if (!bool_5)
							{
								return value2;
							}
							continue;
						}
						switch (Type.GetTypeCode(value2.GetType()))
						{
						case TypeCode.Double:
							arrayList_0.Add(value2);
							break;
						case TypeCode.DateTime:
							arrayList_0.Add(CellsHelper.GetDoubleFromDateTime((DateTime)value2, bool_4));
							break;
						case TypeCode.String:
							if (!bool_1)
							{
								arrayList_0.Add(0.0);
							}
							break;
						case TypeCode.Int32:
							arrayList_0.Add((double)(int)value2);
							break;
						case TypeCode.Boolean:
							if (!bool_0)
							{
								arrayList_0.Add(((bool)value2) ? 1.0 : 0.0);
							}
							break;
						}
					}
				}
			}
			else
			{
				double[] array4 = (double[])object_0;
				for (int m = 0; m < array4.Length; m++)
				{
					arrayList_0.Add(array4[m]);
				}
			}
		}
		else
		{
			object obj = smethod_26(object_0, bool_4);
			if (obj is ErrorType)
			{
				return obj;
			}
			arrayList_0.Add(obj);
		}
		return null;
	}

	internal static object smethod_16(object object_0, Cell cell_0, bool bool_0)
	{
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_0 is double[][])
		{
			double[][] array = (double[][])object_0;
			int num = array[0].Length;
			DateTime[] array2 = new DateTime[array.Length * num];
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null)
				{
					for (int j = 0; j < num; j++)
					{
						ref DateTime reference = ref array2[i * num + j];
						reference = CellsHelper.GetDateTimeFromDouble(array[i][j], bool_0);
					}
				}
			}
			return array2;
		}
		if (object_0 is Array)
		{
			object value = ((Array)object_0).GetValue(0);
			DateTime[] array5;
			if (value is Array)
			{
				Array array3 = (Array)object_0;
				Array array4 = (Array)value;
				int length = array3.Length;
				int length2 = array4.Length;
				array5 = new DateTime[length * length2];
				for (int k = 0; k < length; k++)
				{
					array4 = (Array)array3.GetValue(k);
					for (int l = 0; l < length2; l++)
					{
						object obj = smethod_26(array4.GetValue(l), bool_0);
						if (!(obj is ErrorType))
						{
							ref DateTime reference2 = ref array5[k * length2 + l];
							reference2 = CellsHelper.GetDateTimeFromDouble((double)obj, bool_0);
							continue;
						}
						return obj;
					}
				}
			}
			else
			{
				double[] array6 = (double[])object_0;
				array5 = new DateTime[array6.Length];
				for (int m = 0; m < array6.Length; m++)
				{
					ref DateTime reference3 = ref array5[m];
					reference3 = CellsHelper.GetDateTimeFromDouble(array6[m], bool_0);
				}
			}
			return array5;
		}
		object obj2 = smethod_26(object_0, bool_0);
		if (obj2 is ErrorType)
		{
			return obj2;
		}
		return new DateTime[1] { CellsHelper.GetDateTimeFromDouble((double)obj2, bool_0) };
	}

	internal static string[] smethod_17(string string_0)
	{
		if (string_0.IndexOf('\'') == -1)
		{
			return string_0.Split(',');
		}
		ArrayList arrayList = new ArrayList();
		char[] array = string_0.ToCharArray();
		bool flag = false;
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			char c = array[i];
			if (c == '\'')
			{
				if (flag && i + 1 < array.Length && array[i + 1] == '\'')
				{
					continue;
				}
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
			return null;
		}
		arrayList.Add(new string(array, num, array.Length - num));
		string[] array2 = new string[arrayList.Count];
		for (int j = 0; j < arrayList.Count; j++)
		{
			array2[j] = (string)arrayList[j];
		}
		return array2;
	}

	internal static object smethod_18(object object_0, bool bool_0)
	{
		if (object_0 == null)
		{
			return false;
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		return Type.GetTypeCode(object_0.GetType()) switch
		{
			TypeCode.Double => (double)object_0 != 0.0, 
			TypeCode.DateTime => CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0) != 0.0, 
			TypeCode.String => "#VALUE!", 
			TypeCode.Boolean => (bool)object_0, 
			_ => "#VALUE!", 
		};
	}

	internal static bool smethod_19(byte byte_0)
	{
		switch (byte_0)
		{
		default:
			return false;
		case 35:
		case 36:
		case 37:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
		case 57:
		case 58:
		case 59:
		case 60:
		case 61:
		case 67:
		case 68:
		case 69:
		case 70:
		case 71:
		case 72:
		case 73:
		case 74:
		case 75:
		case 76:
		case 77:
		case 78:
		case 79:
		case 89:
		case 90:
		case 91:
		case 92:
		case 93:
		case 99:
		case 100:
		case 101:
		case 102:
		case 103:
		case 104:
		case 105:
		case 106:
		case 107:
		case 108:
		case 109:
		case 110:
		case 111:
		case 121:
		case 122:
		case 123:
		case 124:
		case 125:
			return true;
		}
	}

	internal static object smethod_20(object object_0, bool bool_0)
	{
		if (object_0 == null)
		{
			return 0.0;
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			return Math.Floor((double)object_0);
		case TypeCode.DateTime:
			return Math.Floor(CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0));
		default:
			if (object_0 is Array)
			{
				return Class1120.smethod_15(object_0, bool_0);
			}
			return ErrorType.Value;
		case TypeCode.String:
		{
			string text = (string)object_0;
			if (Class1677.smethod_20(text))
			{
				try
				{
					double d = double.Parse(text);
					return Math.Floor(d);
				}
				catch
				{
					return ErrorType.Value;
				}
			}
			return ErrorType.Value;
		}
		case TypeCode.Boolean:
			if ((bool)object_0)
			{
				return 1.0;
			}
			return 0.0;
		}
	}

	internal static bool smethod_21(Array array_0, ref object object_0)
	{
		if (array_0.Length != 1)
		{
			return false;
		}
		Array array = (Array)array_0.GetValue(0);
		if (array.Length != 1)
		{
			return false;
		}
		object_0 = array.GetValue(0);
		return true;
	}

	internal static Enum227 smethod_22(int int_0, Enum226 enum226_0)
	{
		return int_0 switch
		{
			252 => Enum227.const_2, 
			1 => Enum227.const_0, 
			_ => Enum227.const_1, 
		};
	}

	internal static Enum227[] smethod_23(int int_0, Enum226 enum226_0)
	{
		switch (int_0)
		{
		case 1:
			if (enum226_0 == Enum226.const_1)
			{
				return new Enum227[2]
				{
					Enum227.const_2,
					Enum227.const_0
				};
			}
			return Class1663.enum227_8;
		case 28:
			if (enum226_0 == Enum226.const_1)
			{
				return new Enum227[2]
				{
					Enum227.const_1,
					Enum227.const_2
				};
			}
			return Class1663.enum227_8;
		case 49:
		case 51:
			return new Enum227[3]
			{
				Enum227.const_0,
				Enum227.const_0,
				Enum227.const_1
			};
		case 50:
		case 52:
			return new Enum227[4]
			{
				Enum227.const_0,
				Enum227.const_0,
				Enum227.const_0,
				Enum227.const_1
			};
		case 101:
		case 102:
			return new Enum227[4]
			{
				Enum227.const_1,
				Enum227.const_0,
				Enum227.const_0,
				Enum227.const_1
			};
		case 216:
			return new Enum227[3]
			{
				Enum227.const_1,
				Enum227.const_0,
				Enum227.const_1
			};
		case 309:
			return new Enum227[2]
			{
				Enum227.const_1,
				Enum227.const_2
			};
		case 316:
		case 317:
			return new Enum227[3]
			{
				Enum227.const_2,
				Enum227.const_2,
				Enum227.const_1
			};
		case 83:
		case 163:
		case 164:
		case 165:
		case 228:
		case 252:
		case 303:
		case 304:
		case 305:
		case 306:
		case 307:
		case 308:
		case 310:
		case 311:
		case 312:
		case 313:
		case 314:
		case 315:
		case 330:
			return Class1663.enum227_4;
		case 11:
		case 64:
		case 100:
		case 125:
		case 344:
			return Class1663.enum227_8;
		case 345:
			return new Enum227[3]
			{
				Enum227.const_0,
				Enum227.const_1,
				Enum227.const_0
			};
		case 29:
		case 61:
		case 62:
		case 78:
		case 324:
		case 325:
		case 326:
		case 327:
		case 328:
		case 329:
		case 331:
		case 346:
			return Class1663.enum227_6;
		default:
			return null;
		case 2:
		case 3:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 20:
		case 21:
		case 22:
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
		case 30:
		case 31:
		case 32:
		case 33:
		case 38:
		case 39:
		case 48:
		case 56:
		case 57:
		case 58:
		case 59:
		case 60:
		case 65:
		case 66:
		case 67:
		case 68:
		case 69:
		case 70:
		case 71:
		case 72:
		case 73:
		case 82:
		case 86:
		case 97:
		case 98:
		case 99:
		case 109:
		case 111:
		case 112:
		case 113:
		case 114:
		case 115:
		case 116:
		case 117:
		case 118:
		case 119:
		case 120:
		case 121:
		case 124:
		case 126:
		case 127:
		case 128:
		case 129:
		case 140:
		case 141:
		case 142:
		case 143:
		case 144:
		case 148:
		case 162:
		case 167:
		case 168:
		case 184:
		case 192:
		case 197:
		case 198:
		case 204:
		case 205:
		case 206:
		case 207:
		case 208:
		case 209:
		case 210:
		case 211:
		case 212:
		case 213:
		case 214:
		case 215:
		case 219:
		case 220:
		case 222:
		case 229:
		case 230:
		case 231:
		case 232:
		case 233:
		case 234:
		case 244:
		case 247:
		case 261:
		case 270:
		case 271:
		case 272:
		case 273:
		case 274:
		case 275:
		case 276:
		case 277:
		case 278:
		case 279:
		case 280:
		case 281:
		case 282:
		case 283:
		case 284:
		case 285:
		case 286:
		case 287:
		case 288:
		case 289:
		case 290:
		case 291:
		case 292:
		case 293:
		case 294:
		case 295:
		case 296:
		case 297:
		case 298:
		case 299:
		case 300:
		case 301:
		case 302:
		case 332:
		case 336:
		case 337:
		case 342:
		case 343:
		case 350:
		case 351:
		case 352:
		case 353:
		case 354:
		case 359:
			return Class1663.enum227_2;
		case 0:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 12:
		case 36:
		case 37:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
		case 75:
		case 76:
		case 77:
		case 105:
		case 130:
		case 131:
		case 169:
		case 183:
		case 191:
		case 193:
		case 194:
		case 195:
		case 196:
		case 199:
		case 227:
		case 235:
		case 269:
		case 318:
		case 319:
		case 320:
		case 321:
		case 322:
		case 323:
		case 347:
		case 360:
		case 361:
		case 362:
		case 363:
		case 364:
		case 365:
		case 366:
		case 367:
			return Class1663.enum227_3;
		}
	}

	internal static object smethod_24(object object_0)
	{
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		TypeCode typeCode = Type.GetTypeCode(object_0.GetType());
		if (typeCode == TypeCode.Boolean)
		{
			if ((bool)object_0)
			{
				return "TRUE";
			}
			return "FALSE";
		}
		return object_0.ToString();
	}

	internal static object smethod_25(object object_0, bool bool_0, CountryCode countryCode_0)
	{
		if (object_0 == null)
		{
			return 0.0;
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			return (double)object_0;
		case TypeCode.DateTime:
			return CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
		case TypeCode.String:
		{
			string text = (string)object_0;
			double num = 1.0;
			if (text.Length > 0 && text[text.Length - 1] == '%')
			{
				text = text.Substring(0, text.Length - 1).Trim();
				num = 0.01;
			}
			if (text.Length > 0)
			{
				switch (text[0])
				{
				case '$':
				case '€':
				case '￡':
				case '￥':
					text = text.Substring(1).Trim();
					break;
				}
			}
			if (countryCode_0 == CountryCode.Germany)
			{
				string pattern = "(^\\d{0,4}[ -/.]\\d{1,2}[ -/.]\\d{0,4}$)|(^[a-z]{1,9}\\s\\d{1,2},\\s*\\d{2,4}$)|(^\\d{0,4}[ -/]\\d{1,2}[ -/]\\d{0,4},?\\s*\\d{1,2}:\\d{2}(AM|PM)?)|(^\\d{0,4}\\s*[a-z]{1,9}\\s*\\d{0,4},?\\s*\\d{1,2}:\\d{2}(AM|PM)?)";
				if (Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase))
				{
					try
					{
						DateTime dateTime = DateTime.Parse(text);
						return CellsHelper.GetDoubleFromDateTime(dateTime, bool_0) * num;
					}
					catch
					{
					}
				}
			}
			if (Class1677.smethod_20(text))
			{
				return double.Parse(text) * num;
			}
			string pattern2 = "(^\\d{0,4}[ -/.]\\d{1,2}[ -/.]\\d{0,4}$)|(^[a-z]{1,9}\\s\\d{1,2},\\s*\\d{2,4}$)|(^\\d{0,4}[ -/]\\d{1,2}[ -/]\\d{0,4},?\\s*\\d{1,2}:\\d{2}(AM|PM)?)|(^\\d{0,4}\\s*[a-z]{1,9}\\s*\\d{0,4},?\\s*\\d{1,2}:\\d{2}(AM|PM)?)";
			if (Regex.IsMatch(text, pattern2, RegexOptions.IgnoreCase))
			{
				try
				{
					DateTime dateTime2 = DateTime.Parse(text);
					return CellsHelper.GetDoubleFromDateTime(dateTime2, bool_0) * num;
				}
				catch
				{
				}
			}
			return ErrorType.Value;
		}
		case TypeCode.Int16:
			return (double)(short)object_0;
		default:
			if (object_0 is double[][])
			{
				double[][] array = (double[][])object_0;
				if (array.Length == 1 && array[0].Length == 1)
				{
					return array[0][0];
				}
				return ErrorType.Value;
			}
			if (object_0 is Array)
			{
				object object_ = null;
				if (smethod_21((Array)object_0, ref object_))
				{
					return smethod_26(object_, bool_0);
				}
			}
			return ErrorType.Value;
		case TypeCode.Int32:
			return (double)(int)object_0;
		case TypeCode.Boolean:
			if ((bool)object_0)
			{
				return 1.0;
			}
			return 0.0;
		}
	}

	internal static object smethod_26(object object_0, bool bool_0)
	{
		if (object_0 == null)
		{
			return 0.0;
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			return (double)object_0;
		case TypeCode.DateTime:
			return CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
		case TypeCode.String:
		{
			string text = (string)object_0;
			double num = 1.0;
			if (text.Length > 0 && text[text.Length - 1] == '%')
			{
				text = text.Substring(0, text.Length - 1).Trim();
				num = 0.01;
			}
			if (text.Length > 0)
			{
				switch (text[0])
				{
				case '$':
				case '€':
				case '￡':
				case '￥':
					text = text.Substring(1).Trim();
					break;
				}
			}
			if (Class1677.smethod_20(text))
			{
				return double.Parse(text) * num;
			}
			if (Class1677.smethod_16(text.Trim()))
			{
				try
				{
					DateTime dateTime = DateTime.Parse(text);
					return CellsHelper.GetDoubleFromDateTime(dateTime, bool_0) * num;
				}
				catch
				{
				}
			}
			return ErrorType.Value;
		}
		case TypeCode.Int16:
			return (double)(short)object_0;
		default:
			if (object_0 is double[][])
			{
				double[][] array = (double[][])object_0;
				if (array.Length == 1 && array[0].Length == 1)
				{
					return array[0][0];
				}
				return ErrorType.Value;
			}
			if (object_0 is Array)
			{
				object object_ = null;
				if (smethod_21((Array)object_0, ref object_))
				{
					return smethod_26(object_, bool_0);
				}
			}
			return ErrorType.Value;
		case TypeCode.Int32:
			return (double)(int)object_0;
		case TypeCode.Boolean:
			if ((bool)object_0)
			{
				return 1.0;
			}
			return 0.0;
		}
	}

	internal static object smethod_27(object object_0, bool bool_0)
	{
		if (object_0 == null)
		{
			return 0.0;
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			return (double)object_0;
		case TypeCode.DateTime:
			return CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0);
		case TypeCode.String:
			return 0.0;
		case TypeCode.Int16:
			return (double)(short)object_0;
		default:
			return 0.0;
		case TypeCode.Int32:
			return (double)(int)object_0;
		case TypeCode.Boolean:
			if ((bool)object_0)
			{
				return 1.0;
			}
			return 0.0;
		}
	}

	internal static object GetStringValue(object object_0)
	{
		if (object_0 == null)
		{
			return "";
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_0 is double[][])
		{
			double[][] array = (double[][])object_0;
			return array[0][0].ToString();
		}
		if (object_0 is Array)
		{
			Array array2 = (Array)object_0;
			if (array2.Length > 1)
			{
				return ErrorType.Value;
			}
			object_0 = (Array)array2.GetValue(0);
			if (array2.Length > 1)
			{
				return ErrorType.Value;
			}
			object_0 = array2.GetValue(0);
			if (object_0 == null)
			{
				return ErrorType.Value;
			}
		}
		TypeCode typeCode = Type.GetTypeCode(object_0.GetType());
		if (typeCode == TypeCode.Boolean)
		{
			if (!(bool)object_0)
			{
				return "FALSE";
			}
			return "TRUE";
		}
		return object_0.ToString();
	}

	internal static int smethod_28(Workbook workbook_0, object object_0, bool bool_0)
	{
		int num = -1;
		if (object_0 is double)
		{
			num = (int)Class1179.ToDouble(object_0);
		}
		else if (object_0 is int)
		{
			num = (int)object_0;
		}
		if (bool_0)
		{
			num--;
		}
		return num;
	}

	internal static void smethod_29(ArrayList arrayList_0, object object_0)
	{
		if (object_0 == null)
		{
			return;
		}
		if (object_0 is Array)
		{
			Array array = (Array)object_0;
			for (int i = 0; i < array.Length; i++)
			{
				object value = array.GetValue(i);
				if (value == null)
				{
					continue;
				}
				if (value is Array)
				{
					Array array2 = (Array)value;
					for (int j = 0; j < array2.Length; j++)
					{
						object value2 = array2.GetValue(j);
						if (value2 != null)
						{
							arrayList_0.Add(value2.ToString());
						}
					}
				}
				else
				{
					arrayList_0.Add(value.ToString());
				}
			}
		}
		else
		{
			arrayList_0.Add(object_0);
		}
	}

	internal static void smethod_30(ArrayList arrayList_0, object object_0)
	{
		if (object_0 == null)
		{
			return;
		}
		if (object_0 is Array)
		{
			Array array = (Array)object_0;
			object value = array.GetValue(0);
			if (value is Array)
			{
				for (int i = 0; i < array.Length; i++)
				{
					Array array2 = (Array)array.GetValue(i);
					for (int j = 0; j < array2.Length; j++)
					{
						arrayList_0.Add(array2.GetValue(j));
					}
				}
			}
			else
			{
				for (int k = 0; k < array.Length; k++)
				{
					arrayList_0.Add(array.GetValue(k));
				}
			}
		}
		else
		{
			arrayList_0.Add(object_0);
		}
	}

	internal static bool CellNameToIndex(string cellName, out int row, out int column)
	{
		column = 0;
		row = 0;
		if (cellName != null && char.IsLetter(cellName, 0) && char.IsDigit(cellName, cellName.Length - 1))
		{
			cellName = cellName.ToUpper();
			column = 0;
			int num = 0;
			for (num = 0; num < cellName.Length && char.IsLetter(cellName[num]); num++)
			{
				column = column * 26 + cellName[num] - 65 + 1;
			}
			if (column > 0)
			{
				column--;
			}
			try
			{
				row = int.Parse(cellName.Substring(num));
				if (row > 0)
				{
					row--;
				}
			}
			catch (Exception)
			{
				return false;
			}
			if (row <= 1048575 && column <= 16383)
			{
				return true;
			}
			return false;
		}
		return false;
	}
}
