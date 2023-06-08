using System.Text;
using Aspose.Cells;
using ns22;

namespace ns12;

internal class Class1253
{
	internal static string smethod_0(string string_0)
	{
		StringBuilder stringBuilder = new StringBuilder(string_0.Length);
		char[] array = string_0.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == ' ')
			{
				int num = i;
				for (i++; i < array.Length; i++)
				{
					if (array[i] != ' ')
					{
						if (num != 0)
						{
							stringBuilder.Append(' ');
						}
						stringBuilder.Append(array[i]);
						break;
					}
				}
			}
			else
			{
				stringBuilder.Append(array[i]);
			}
		}
		return stringBuilder.ToString();
	}

	internal static int smethod_1(char char_0)
	{
		if (char_0 > '\u007f')
		{
			return 2;
		}
		return 1;
	}

	internal static int smethod_2(string string_0)
	{
		char[] array = string_0.ToCharArray();
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			num += smethod_1(array[i]);
		}
		return num;
	}

	internal static object smethod_3(string string_0, int int_0, int int_1)
	{
		if (int_0 >= 1 && int_1 >= 0)
		{
			StringBuilder stringBuilder = new StringBuilder(int_1);
			char[] array = string_0.ToCharArray();
			int num = 0;
			int_0--;
			int i = 0;
			while (true)
			{
				if (i < array.Length)
				{
					int num2 = smethod_1(array[i]);
					num += num2;
					if (num > int_0)
					{
						if (num2 == 2)
						{
							if (num - int_0 == 1)
							{
								stringBuilder.Append(' ');
								int_1--;
							}
							else
							{
								if (int_1 == 1)
								{
									stringBuilder.Append(' ');
									return stringBuilder.ToString();
								}
								stringBuilder.Append(array[i]);
								int_1 -= 2;
							}
						}
						else
						{
							stringBuilder.Append(array[i]);
							int_1--;
						}
						if (int_1 <= 0)
						{
							break;
						}
						for (i++; i < array.Length; i++)
						{
							num2 = smethod_1(array[i]);
							int_1 -= num2;
							if (int_1 != 0)
							{
								if (int_1 >= 0)
								{
									stringBuilder.Append(array[i]);
									continue;
								}
								stringBuilder.Append(' ');
								return stringBuilder.ToString();
							}
							stringBuilder.Append(array[i]);
							return stringBuilder.ToString();
						}
					}
					i++;
					continue;
				}
				if (stringBuilder.Length == 0)
				{
					return ErrorType.Value;
				}
				return stringBuilder.ToString();
			}
			return stringBuilder.ToString();
		}
		return ErrorType.Value;
	}

	internal static object smethod_4(string string_0, int int_0)
	{
		return smethod_3(string_0, 1, int_0);
	}

	internal static object smethod_5(string string_0)
	{
		return smethod_4(string_0, 1);
	}

	internal static object smethod_6(string string_0, int int_0)
	{
		int num = smethod_2(string_0);
		if (num - int_0 < 0)
		{
			return smethod_3(string_0, 1, num);
		}
		return smethod_3(string_0, num - int_0 + 1, int_0);
	}

	internal static object smethod_7(string string_0)
	{
		return smethod_6(string_0, 1);
	}

	internal static object smethod_8(object[][] object_0, string string_0, object object_1, bool bool_0, WorkbookSettings workbookSettings_0)
	{
		object[][] array = new object[object_0.Length][];
		int num = object_0[0].Length;
		for (int i = 0; i < object_0.Length; i++)
		{
			object[] array2 = object_0[i];
			if (array2 == null)
			{
				continue;
			}
			array[i] = new object[array2.Length];
			for (int j = 0; j < num; j++)
			{
				object obj = array2[j];
				if (obj == null)
				{
					array[i][j] = 1;
				}
				else if (obj is ErrorType)
				{
					array[i][j] = obj;
				}
				else
				{
					array[i][j] = smethod_9(obj.ToString().ToUpper(), string_0, object_1, bool_0, workbookSettings_0);
				}
			}
		}
		return array;
	}

	internal static object smethod_9(string string_0, string string_1, object object_0, bool bool_0, WorkbookSettings workbookSettings_0)
	{
		if (string_0 == "")
		{
			return 1;
		}
		if (string_1 == "")
		{
			return ErrorType.Value;
		}
		if (object_0 == null)
		{
			if (bool_0)
			{
				return Class1660.smethod_26(smethod_10(string_0, string_1), bool_0: false);
			}
			int num = string_1.IndexOf(string_0);
			if (num == -1)
			{
				return ErrorType.Value;
			}
			num++;
			return (double)num;
		}
		object_0 = Class1660.smethod_26(object_0, workbookSettings_0.Date1904);
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		int num2 = (int)Class1179.ToDouble(object_0) - 1;
		if (bool_0)
		{
			return smethod_11(string_0, string_1, num2 + 1);
		}
		if (num2 >= 0 && num2 < string_1.Length)
		{
			int num3 = string_1.IndexOf(string_0, num2);
			if (num3 == -1)
			{
				return ErrorType.Value;
			}
			num3++;
			return (double)num3;
		}
		return ErrorType.Value;
	}

	internal static object smethod_10(string string_0, string string_1)
	{
		return smethod_11(string_0, string_1, 1);
	}

	internal static object smethod_11(string string_0, string string_1, int int_0)
	{
		string text = string_0.ToUpper();
		string text2 = string_1.ToUpper();
		int length = text2.Length;
		int length2 = text.Length;
		if (int_0 + length2 > length)
		{
			return ErrorType.Value;
		}
		if (int_0 <= 0)
		{
			return ErrorType.Value;
		}
		if (length2 == 0)
		{
			return (double)int_0;
		}
		int[] array = new int[length2];
		length2--;
		int num = 0;
		int num2 = -1;
		array[0] = -1;
		while (num < length2)
		{
			if (num2 != -1 && text[num2] != '?' && text[num] != text[num2])
			{
				num2 = array[num2];
				continue;
			}
			num++;
			num2 = (array[num] = num2 + 1);
		}
		length2++;
		int num3 = int_0 - 1;
		int num4 = 0;
		while (num3 < length && num4 < length2)
		{
			if (num4 != -1 && text[num4] != '?' && text2[num3] != text[num4])
			{
				num4 = array[num4];
				continue;
			}
			num3++;
			num4++;
		}
		int num5 = 0;
		if (num4 >= length2)
		{
			num5 = num3 - length2 + 1;
			int num6 = smethod_2(string_1.Substring(0, num5 - 1)) + 1;
			return (double)num6;
		}
		return ErrorType.Value;
	}

	internal static object smethod_12(string string_0, string string_1)
	{
		return smethod_13(string_0, string_1, 1);
	}

	internal static object smethod_13(string string_0, string string_1, int int_0)
	{
		int length = string_1.Length;
		int length2 = string_0.Length;
		if (int_0 + length2 > length)
		{
			return ErrorType.Value;
		}
		if (int_0 > 0 && int_0 <= length)
		{
			if (length2 == 0)
			{
				return (double)int_0;
			}
			int[] array = new int[length2];
			length2--;
			int num = 0;
			int num2 = -1;
			array[0] = -1;
			while (num < length2)
			{
				if (num2 != -1 && string_0[num] != string_0[num2])
				{
					num2 = array[num2];
					continue;
				}
				num++;
				num2 = (array[num] = num2 + 1);
			}
			length2++;
			int num3 = int_0 - 1;
			int num4 = 0;
			while (num3 < length && num4 < length2)
			{
				if (num4 != -1 && string_1[num3] != string_0[num4])
				{
					num4 = array[num4];
					continue;
				}
				num3++;
				num4++;
			}
			int num5 = 0;
			if (num4 >= length2)
			{
				num5 = num3 - length2 + 1;
				int num6 = smethod_2(string_1.Substring(int_0 - 1, num5 - 1)) + 1;
				return (double)num6;
			}
			return ErrorType.Value;
		}
		return ErrorType.Value;
	}

	internal static object smethod_14(string string_0, int int_0, int int_1, string string_1)
	{
		object obj = smethod_3(string_0, int_0, int_1);
		if (!obj.Equals(ErrorType.Value))
		{
			string oldValue = (string)obj;
			return string_0.Replace(oldValue, string_1);
		}
		return ErrorType.Value;
	}
}
