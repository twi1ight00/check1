using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using Aspose.Cells;

namespace ns2;

internal class Class992
{
	internal static bool smethod_0(object object_0)
	{
		if (object_0 == null)
		{
			return true;
		}
		if (object_0 is DBNull)
		{
			return true;
		}
		if (object_0 is string)
		{
			return (string)object_0 == "";
		}
		return false;
	}

	internal static string[] smethod_1(string string_0)
	{
		ArrayList arrayList = new ArrayList();
		char[] array = string_0.ToCharArray();
		StringBuilder stringBuilder = new StringBuilder(array.Length);
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i])
			{
			case '[':
				stringBuilder.Append(array[i]);
				num = 1;
				for (i++; i < array.Length; i++)
				{
					stringBuilder.Append(array[i]);
					if (array[i] == ']')
					{
						num--;
						if (num == 0)
						{
							break;
						}
					}
					else if (array[i] == '[')
					{
						num++;
					}
				}
				break;
			case '(':
				num2++;
				if (num2 == 1)
				{
					arrayList.Add(stringBuilder.ToString());
					stringBuilder = new StringBuilder(array.Length);
					break;
				}
				stringBuilder.Append(array[i]);
				for (i++; i < array.Length; i++)
				{
					stringBuilder.Append(array[i]);
					if (array[i] == ')')
					{
						num--;
						if (num == 1)
						{
							break;
						}
					}
					else if (array[i] == '(')
					{
						num++;
					}
				}
				break;
			case ')':
				arrayList.Add(stringBuilder.ToString());
				stringBuilder = new StringBuilder(array.Length);
				break;
			default:
				stringBuilder.Append(array[i]);
				break;
			case ',':
				arrayList.Add(stringBuilder.ToString());
				stringBuilder = new StringBuilder(array.Length);
				break;
			case '"':
				stringBuilder.Append(array[i]);
				for (i++; i < array.Length; i++)
				{
					if (array[i] == '"')
					{
						stringBuilder.Append(array[i]);
						if (i + 1 >= array.Length || array[i + 1] != '"')
						{
							break;
						}
						stringBuilder.Append(array[i++]);
					}
					else
					{
						stringBuilder.Append(array[i]);
					}
				}
				break;
			}
		}
		if (stringBuilder.Length != 0)
		{
			arrayList.Add(stringBuilder.ToString());
		}
		string[] array2 = new string[arrayList.Count];
		for (int j = 0; j < array2.Length; j++)
		{
			array2[j] = (string)arrayList[j];
		}
		return array2;
	}

	internal static int smethod_2(string[] string_0, string string_1)
	{
		int num = 0;
		while (true)
		{
			if (num < string_0.Length)
			{
				if (string.Compare(string_0[num], string_1, ignoreCase: true) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal static string smethod_3(string string_0)
	{
		if (string_0 != null && string_0.Length > 2 && string_0[0] == '[' && string_0[string_0.Length - 1] == ']')
		{
			string_0 = string_0.Substring(1, string_0.Length - 2);
			if (string_0 == null || string_0 == "")
			{
				return null;
			}
		}
		return string_0;
	}

	internal static int smethod_4(string string_0, int int_0)
	{
		int num = -1;
		int num2 = string_0.Length - 1;
		while (num2 >= 0)
		{
			if (char.IsLetter(string_0[num2]))
			{
				num2--;
				continue;
			}
			num = num2 + 1;
			break;
		}
		if (num == -1)
		{
			return 0;
		}
		double num3 = 0.0;
		string text = "pt";
		if (num == string_0.Length)
		{
			num3 = double.Parse(string_0);
		}
		else
		{
			num3 = double.Parse(string_0.Substring(0, num));
			text = string_0.Substring(num);
		}
		return text.Trim().ToLower() switch
		{
			"cm" => (int)(num3 * (double)int_0 / 2.54 + 0.5), 
			"in" => (int)(num3 * (double)int_0 + 0.5), 
			"px" => (int)num3, 
			_ => (int)(num3 * (double)int_0 / 72.0 + 0.5), 
		};
	}

	internal static ICellsDataTable smethod_5(ICollection icollection_0)
	{
		IEnumerator enumerator = icollection_0.GetEnumerator();
		if (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			if (current is ICustomTypeDescriptor)
			{
				return new Class781(icollection_0, TypeDescriptor.GetProperties(current));
			}
			Type type = current.GetType();
			return new Class780(icollection_0, type.GetProperties());
		}
		return null;
	}

	internal static string smethod_6(string string_0, int int_0, int int_1)
	{
		StringBuilder stringBuilder = new StringBuilder(string_0);
		for (int i = 0; i < stringBuilder.Length; i++)
		{
			if (stringBuilder[i] != '{')
			{
				continue;
			}
			if ((stringBuilder[i + 1] == 'R' || stringBuilder[i + 1] == 'r') && stringBuilder[i + 2] == '}')
			{
				stringBuilder.Remove(i, 3);
				string value = (int_0 + 1).ToString();
				stringBuilder.Insert(i, value);
				continue;
			}
			if ((stringBuilder[i + 1] == 'C' || stringBuilder[i + 1] == 'c') && stringBuilder[i + 2] == '}')
			{
				stringBuilder.Remove(i, 3);
				stringBuilder.Insert(i, CellsHelper.ColumnIndexToName(int_1));
				continue;
			}
			for (int j = i + 1; j < stringBuilder.Length; j++)
			{
				if ((stringBuilder[j] >= '0' && stringBuilder[j] <= '9') || stringBuilder[j] == '+' || stringBuilder[j] == '-')
				{
					continue;
				}
				if (stringBuilder[j] == '}')
				{
					int num;
					try
					{
						num = int.Parse(stringBuilder.ToString(i + 1, j - i - 1));
					}
					catch
					{
						throw new CellsException(ExceptionType.InvalidData, "Invalid dynamic formula:" + string_0);
					}
					bool flag = false;
					if (j + 1 < stringBuilder.Length)
					{
						switch (stringBuilder[j + 1])
						{
						case '$':
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
						case '{':
							flag = true;
							break;
						}
					}
					if (flag)
					{
						string value2 = CellsHelper.ColumnIndexToName(int_1 + num);
						stringBuilder.Remove(i, j - i + 1);
						stringBuilder.Insert(i, value2);
					}
					else
					{
						string value3 = (int_0 + 1 + num).ToString();
						stringBuilder.Remove(i, j - i + 1);
						stringBuilder.Insert(i, value3);
					}
					break;
				}
				throw new CellsException(ExceptionType.InvalidData, "Invalid dynamic formula:" + string_0);
			}
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_7(string string_0, bool bool_0, int int_0, int int_1, int int_2, int int_3)
	{
		char[] array = string_0.ToCharArray();
		if (bool_0)
		{
			int_0++;
			int_2++;
		}
		StringBuilder stringBuilder = new StringBuilder(array.Length);
		int i = 0;
		while (true)
		{
			if (i < array.Length)
			{
				char c = array[i];
				if (c == '{')
				{
					int num = i;
					int num2 = -1;
					bool flag = false;
					for (i++; i < array.Length; i++)
					{
						c = array[i];
						switch (c)
						{
						case ':':
							num2 = i;
							continue;
						default:
							if (char.IsDigit(c))
							{
								flag = true;
							}
							continue;
						case '}':
							break;
						}
						break;
					}
					if (i == array.Length)
					{
						break;
					}
					if (bool_0)
					{
						if (flag)
						{
							if (num2 != -1)
							{
								int num3 = int.Parse(string_0.Substring(num + 1, num2 - num - 1));
								int column = int_1 + num3;
								string value = CellsHelper.ColumnIndexToName(column);
								stringBuilder.Append(value);
								stringBuilder.Append(int_0);
								stringBuilder.Append(':');
								num3 = int.Parse(string_0.Substring(num2 + 1, i - num2 - 1));
								column = int_1 + num3;
								value = CellsHelper.ColumnIndexToName(column);
								stringBuilder.Append(value);
								stringBuilder.Append(int_2);
							}
							else
							{
								int num4 = int.Parse(string_0.Substring(i - num - 1, num + 1));
								int column2 = int_1 + num4;
								string value2 = CellsHelper.ColumnIndexToName(column2);
								stringBuilder.Append(value2);
								stringBuilder.Append(int_0);
								stringBuilder.Append(':');
								stringBuilder.Append(value2);
								stringBuilder.Append(int_2);
							}
						}
						else if (num2 != -1)
						{
							stringBuilder.Append(array, num + 1, num2 - num - 1);
							stringBuilder.Append(int_0);
							stringBuilder.Append(':');
							stringBuilder.Append(array, num2 + 1, i - num2 - 1);
							stringBuilder.Append(int_2);
						}
						else
						{
							stringBuilder.Append(array, num + 1, i - num - 1);
							stringBuilder.Append(int_0);
							stringBuilder.Append(':');
							stringBuilder.Append(array, num + 1, i - num - 1);
							stringBuilder.Append(int_2);
						}
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
				i++;
				continue;
			}
			return stringBuilder.ToString();
		}
		return null;
	}
}
