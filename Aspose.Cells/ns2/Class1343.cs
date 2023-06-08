using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns1;

namespace ns2;

internal class Class1343
{
	internal bool bool_0 = true;

	private WorksheetCollection worksheetCollection_0;

	private Enum180 enum180_0 = Enum180.const_1;

	private ArrayList arrayList_0;

	private string string_0;

	internal Class1343(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
	}

	private void method_0(Class1343 class1343_0)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		arrayList_0.Add(class1343_0);
	}

	internal void method_1(string string_1)
	{
		if (!bool_0)
		{
			return;
		}
		if (enum180_0 == Enum180.const_3)
		{
			if (string_1 == null || string_1 == "")
			{
				return;
			}
			string[] array = method_3(string_1);
			int num = 0;
			while (true)
			{
				if (num >= array.Length)
				{
					return;
				}
				if (array[num].IndexOf('"') != -1)
				{
					if (array[num].IndexOf('"') == array[num].LastIndexOf('"'))
					{
						string text = array[num] + ',';
						if (num > array.Length - 2)
						{
							bool_0 = false;
							return;
						}
						bool flag = false;
						for (int i = num + 1; i < array.Length; i++)
						{
							text += array[i];
							if (array[i].IndexOf('"') == -1)
							{
								text += ',';
								continue;
							}
							flag = true;
							num = i;
							break;
						}
						if (!flag)
						{
							break;
						}
						Class1343 @class = new Class1343(worksheetCollection_0);
						method_0(@class);
						@class.method_1(text);
					}
					else
					{
						Class1343 class2 = new Class1343(worksheetCollection_0);
						method_0(class2);
						class2.method_1(array[num]);
					}
				}
				else
				{
					Class1343 class3 = new Class1343(worksheetCollection_0);
					method_0(class3);
					class3.method_1(array[num]);
				}
				num++;
			}
			bool_0 = false;
		}
		else if (string_1 != null && !(string_1 == ""))
		{
			if (string_1[0] == '"' && string_1[string_1.Length - 1] == '"')
			{
				string_0 = string_1;
				return;
			}
			int num2 = string_1.IndexOf('(');
			int num3;
			if (num2 == -1)
			{
				if (!bool_0)
				{
					return;
				}
				num3 = method_2(string_1, 0, string_1.Length);
				if (num3 == -1)
				{
					if (bool_0)
					{
						if (string_1[string_1.Length - 1] == '%')
						{
							method_4(string_1, string_1.Length - 1);
						}
						else
						{
							string_0 = string_1.ToUpper();
						}
					}
				}
				else
				{
					method_4(string_1, num3);
				}
				return;
			}
			int num4 = -1;
			int num5 = 0;
			for (int j = num2 + 1; j < string_1.Length; j++)
			{
				if (string_1[j] == '(')
				{
					num5++;
				}
				if (string_1[j] == ')')
				{
					if (num5 == 0)
					{
						num4 = j;
						break;
					}
					num5--;
				}
			}
			if (num5 != 0)
			{
				bool_0 = false;
				return;
			}
			if (num2 == 0)
			{
				if (num4 == string_1.Length - 1)
				{
					string_1 = string_1.Substring(1, string_1.Length - 2);
					string_0 = "()";
					enum180_0 = Enum180.const_2;
					Class1343 class4 = new Class1343(worksheetCollection_0);
					method_0(class4);
					class4.method_1(string_1);
				}
				else
				{
					num3 = method_2(string_1, num4 + 1, string_1.Length);
					if (num3 == -1)
					{
						bool_0 = false;
					}
					else
					{
						method_4(string_1, num3);
					}
				}
				return;
			}
			string text2 = string_1.Substring(0, num2);
			num3 = ((text2.IndexOfAny("+-*/^<>".ToCharArray()) == -1) ? (-1) : method_2(string_1, 0, num2));
			if (num3 == -1)
			{
				if (num4 == string_1.Length - 1)
				{
					string_0 = text2.ToUpper();
					enum180_0 = Enum180.const_3;
					method_1(string_1.Substring(num2 + 1, num4 - num2 - 1));
					return;
				}
				if (num4 >= string_1.Length - 2)
				{
					bool_0 = false;
					return;
				}
				num3 = method_2(string_1, num4 + 1, string_1.Length);
				if (num3 == -1)
				{
					bool_0 = false;
				}
				else
				{
					method_4(string_1, num3);
				}
			}
			else
			{
				method_4(string_1, num3);
			}
		}
		else
		{
			string_0 = "";
		}
	}

	private int method_2(string string_1, int int_0, int int_1)
	{
		if (!bool_0)
		{
			return -1;
		}
		int num = int_0;
		while (true)
		{
			if (num < int_1)
			{
				if (string_1[num] == '\'')
				{
					int num2 = string_1.IndexOf('\'', num + 1);
					if (num2 == -1)
					{
						bool_0 = false;
						return -1;
					}
					num = num2;
				}
				else
				{
					if (string_1[num] == '<' || string_1[num] == '>' || string_1[num] == '=' || string_1[num] == '&')
					{
						break;
					}
					if (string_1[num] == '+')
					{
						if (num < string_1.Length - 1 && (string_1[num + 1] == '+' || string_1[num + 1] == '-' || string_1[num + 1] == '*' || string_1[num + 1] == '/'))
						{
							bool_0 = false;
							return -1;
						}
						if (string_1[num + 1] == '(')
						{
							return num;
						}
						int num3 = int_1 - 1;
						while (true)
						{
							if (num3 > num + 1)
							{
								if (string_1[num3] == '+' || string_1[num3] == '-' || string_1[num3] == '<')
								{
									break;
								}
								if (string_1[num3] != '=')
								{
									if (string_1[num3] != '>')
									{
										num3--;
										continue;
									}
									if (string_1[num3 - 1] == '<')
									{
										return num3 - 1;
									}
									return num3;
								}
								if (string_1[num3 - 1] != '<' && string_1[num3 - 1] != '>')
								{
									return num3;
								}
								return num3 - 1;
							}
							return num;
						}
						return num3;
					}
					if (string_1[num] == '-')
					{
						if (num < string_1.Length - 1 && (string_1[num + 1] == '+' || string_1[num + 1] == '-' || string_1[num + 1] == '*' || string_1[num + 1] == '/'))
						{
							bool_0 = false;
							return -1;
						}
						if (string_1[num + 1] == '(')
						{
							return num;
						}
						int num4 = int_1 - 1;
						while (true)
						{
							if (num4 > num + 1)
							{
								if (string_1[num4] == '+' || string_1[num4] == '-' || string_1[num4] == '<')
								{
									break;
								}
								if (string_1[num4] != '=')
								{
									if (string_1[num4] != '>')
									{
										num4--;
										continue;
									}
									if (string_1[num4 - 1] == '<')
									{
										return num4 - 1;
									}
									return num4;
								}
								if (string_1[num4 - 1] != '<' && string_1[num4 - 1] != '>')
								{
									return num4;
								}
								return num4 - 1;
							}
							return num;
						}
						return num4;
					}
					if (string_1[num] == '*' || string_1[num] == '/')
					{
						if (num < string_1.Length - 1 && (string_1[num + 1] == '+' || string_1[num + 1] == '-' || string_1[num + 1] == '*' || string_1[num + 1] == '/'))
						{
							bool_0 = false;
							return -1;
						}
						int num5 = num + 2;
						while (true)
						{
							if (num5 < int_1)
							{
								if (string_1[num5] != '+')
								{
									if (string_1[num5] == '-')
									{
										break;
									}
									num5++;
									continue;
								}
								if (num5 + 1 < int_1 && string_1[num5 + 1] != '+' && string_1[num5 + 1] != '-' && string_1[num5 + 1] != '*' && string_1[num5 + 1] != '/')
								{
									return num5;
								}
								bool_0 = false;
								return -1;
							}
							return num;
						}
						if (num5 + 1 < int_1 && string_1[num5 + 1] != '+' && string_1[num5 + 1] != '-' && string_1[num5 + 1] != '*' && string_1[num5 + 1] != '/')
						{
							int num6 = int_1 - 1;
							while (true)
							{
								if (num6 > num5 + 1)
								{
									if (string_1[num6] == '+' || string_1[num6] == '-')
									{
										break;
									}
									num6--;
									continue;
								}
								return num5;
							}
							if (num6 + 1 < int_1 && string_1[num6 + 1] != '+' && string_1[num6 + 1] != '-' && string_1[num6 + 1] != '*' && string_1[num6 + 1] != '/')
							{
								return num6;
							}
							bool_0 = false;
							return -1;
						}
						bool_0 = false;
						return -1;
					}
					if (string_1[num] == '^')
					{
						if (num < string_1.Length - 1 && (string_1[num + 1] == '+' || string_1[num + 1] == '-' || string_1[num + 1] == '*' || string_1[num + 1] == '/'))
						{
							bool_0 = false;
							return -1;
						}
						int num7 = num + 2;
						while (true)
						{
							if (num7 < int_1)
							{
								if (string_1[num7] != '+')
								{
									if (string_1[num7] != '-')
									{
										if (string_1[num7] == '*' || string_1[num7] == '/')
										{
											break;
										}
										num7++;
										continue;
									}
									if (num7 + 1 < int_1 && string_1[num7 + 1] != '+' && string_1[num7 + 1] != '-' && string_1[num7 + 1] != '*' && string_1[num7 + 1] != '/')
									{
										int num8 = int_1 - 1;
										while (true)
										{
											if (num8 > num7 + 1)
											{
												if (string_1[num8] == '+' || string_1[num8] == '-')
												{
													break;
												}
												num8--;
												continue;
											}
											return num7;
										}
										if (num8 + 1 < int_1 && string_1[num8 + 1] != '+' && string_1[num8 + 1] != '-' && string_1[num8 + 1] != '*' && string_1[num8 + 1] != '/')
										{
											return num8;
										}
										bool_0 = false;
										return -1;
									}
									bool_0 = false;
									return -1;
								}
								if (num7 + 1 < int_1 && string_1[num7 + 1] != '+' && string_1[num7 + 1] != '-' && string_1[num7 + 1] != '*' && string_1[num7 + 1] != '/')
								{
									return num7;
								}
								bool_0 = false;
								return -1;
							}
							return num;
						}
						if (num7 + 1 < int_1 && string_1[num7 + 1] != '+' && string_1[num7 + 1] != '-' && string_1[num7 + 1] != '*' && string_1[num7 + 1] != '/')
						{
							int num9 = num7 + 2;
							while (true)
							{
								if (num9 < int_1)
								{
									if (string_1[num9] != '+')
									{
										if (string_1[num9] == '-')
										{
											break;
										}
										num9++;
										continue;
									}
									if (num9 + 1 < int_1 && string_1[num9 + 1] != '+' && string_1[num9 + 1] != '-' && string_1[num9 + 1] != '*' && string_1[num9 + 1] != '/')
									{
										return num9;
									}
									bool_0 = false;
									return -1;
								}
								return num7;
							}
							if (num9 + 1 < int_1 && string_1[num9 + 1] != '+' && string_1[num9 + 1] != '-' && string_1[num9 + 1] != '*' && string_1[num9 + 1] != '/')
							{
								int num10 = int_1 - 1;
								while (true)
								{
									if (num10 > num9 + 1)
									{
										if (string_1[num10] == '+' || string_1[num10] == '-')
										{
											break;
										}
										num10--;
										continue;
									}
									return num9;
								}
								if (num10 + 1 < int_1 && string_1[num10 + 1] != '+' && string_1[num10 + 1] != '-' && string_1[num10 + 1] != '*' && string_1[num10 + 1] != '/')
								{
									return num10;
								}
								bool_0 = false;
								return -1;
							}
							bool_0 = false;
							return -1;
						}
						bool_0 = false;
						return -1;
					}
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	private string[] method_3(string string_1)
	{
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < string_1.Length; i++)
		{
			if (string_1[i] == ',')
			{
				if (num == 0)
				{
					arrayList.Add(string_1.Substring(num2, i - num2));
					num2 = i + 1;
				}
			}
			else if (string_1[i] == '(')
			{
				num++;
			}
			else if (string_1[i] == ')')
			{
				num--;
			}
		}
		arrayList.Add(string_1.Substring(num2));
		string[] array = new string[arrayList.Count];
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = ((string)arrayList[j]).Trim();
		}
		return array;
	}

	private void method_4(string string_1, int int_0)
	{
		string text;
		string text2;
		if (string_1[int_0] == '<')
		{
			if (string_1[int_0 + 1] != '>' && string_1[int_0 + 1] != '=')
			{
				string_0 = string_1[int_0].ToString();
				enum180_0 = Enum180.const_2;
				text = string_1.Substring(0, int_0).Trim();
				text2 = string_1.Substring(int_0 + 1, string_1.Length - int_0 - 1).Trim();
			}
			else
			{
				string_0 = string_1.Substring(int_0, 2);
				enum180_0 = Enum180.const_2;
				text = string_1.Substring(0, int_0).Trim();
				text2 = string_1.Substring(int_0 + 2, string_1.Length - int_0 - 2).Trim();
			}
		}
		else if (string_1[int_0] == '>')
		{
			if (string_1[int_0 + 1] == '=')
			{
				string_0 = string_1.Substring(int_0, 2);
				enum180_0 = Enum180.const_2;
				text = string_1.Substring(0, int_0).Trim();
				text2 = string_1.Substring(int_0 + 2, string_1.Length - int_0 - 2).Trim();
			}
			else
			{
				string_0 = string_1[int_0].ToString();
				enum180_0 = Enum180.const_2;
				text = string_1.Substring(0, int_0).Trim();
				text2 = string_1.Substring(int_0 + 1, string_1.Length - int_0 - 1).Trim();
			}
		}
		else
		{
			string_0 = string_1[int_0].ToString();
			enum180_0 = Enum180.const_2;
			text = string_1.Substring(0, int_0).Trim();
			text2 = string_1.Substring(int_0 + 1, string_1.Length - int_0 - 1).Trim();
		}
		if (text != null && text != "")
		{
			Class1343 @class = new Class1343(worksheetCollection_0);
			method_0(@class);
			@class.method_1(text);
		}
		if (text2 != null && text2 != "")
		{
			Class1343 class2 = new Class1343(worksheetCollection_0);
			method_0(class2);
			class2.method_1(text2);
		}
	}

	internal void method_5()
	{
		if (!bool_0)
		{
			return;
		}
		if (arrayList_0 != null && arrayList_0.Count != 0)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Class1343 @class = (Class1343)arrayList_0[i];
				@class.method_5();
				if (!bool_0)
				{
					break;
				}
			}
		}
		if (bool_0)
		{
			method_6();
		}
	}

	private void method_6()
	{
		if (string_0 == null || string_0 == "")
		{
			return;
		}
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_97 == null)
			{
				Class1742.dictionary_97 = new Dictionary<string, int>(81)
				{
					{ "+", 0 },
					{ "-", 1 },
					{ "*", 2 },
					{ "/", 3 },
					{ "^", 4 },
					{ "&", 5 },
					{ "<", 6 },
					{ "=", 7 },
					{ "<=", 8 },
					{ ">", 9 },
					{ ">=", 10 },
					{ "<>", 11 },
					{ "CEILING", 12 },
					{ "FLOOR", 13 },
					{ "MOD", 14 },
					{ "ROUND", 15 },
					{ "TEXT", 16 },
					{ "()", 17 },
					{ "%", 18 },
					{ "ABS", 19 },
					{ "COLUMNS", 20 },
					{ "DAY", 21 },
					{ "EXP", 22 },
					{ "HOUR", 23 },
					{ "INT", 24 },
					{ "ISBLANK", 25 },
					{ "ISNUMBER", 26 },
					{ "LEN", 27 },
					{ "MINUTE", 28 },
					{ "MONTH", 29 },
					{ "NOT", 30 },
					{ "ROWS", 31 },
					{ "SECOND", 32 },
					{ "VALUE", 33 },
					{ "YEAR", 34 },
					{ "AND", 35 },
					{ "COUNT", 36 },
					{ "COUNTA", 37 },
					{ "MAX", 38 },
					{ "MEDIAN", 39 },
					{ "MIN", 40 },
					{ "OR", 41 },
					{ "STDEV", 42 },
					{ "STDEVP", 43 },
					{ "SUM", 44 },
					{ "AVERAGE", 45 },
					{ "CONCATENATE", 46 },
					{ "COLUMN", 47 },
					{ "ROW", 48 },
					{ "DATE", 49 },
					{ "DAVERAGE", 50 },
					{ "DCOUNT", 51 },
					{ "DCOUNTA", 52 },
					{ "DGET", 53 },
					{ "DMAX", 54 },
					{ "DMIN", 55 },
					{ "DPRODUCT", 56 },
					{ "DSTDEV", 57 },
					{ "DSTDEVP", 58 },
					{ "DSUM", 59 },
					{ "DVAR", 60 },
					{ "DVARP", 61 },
					{ "MID", 62 },
					{ "TIME", 63 },
					{ "FALSE", 64 },
					{ "NOW", 65 },
					{ "TODAY", 66 },
					{ "TRUE", 67 },
					{ "FV", 68 },
					{ "PMT", 69 },
					{ "PV", 70 },
					{ "OFFSET", 71 },
					{ "HLOOKUP", 72 },
					{ "VLOOKUP", 73 },
					{ "IF", 74 },
					{ "LOOKUP", 75 },
					{ "SUMIF", 76 },
					{ "NPV", 77 },
					{ "SUBTOTAL", 78 },
					{ "REPLACE", 79 },
					{ "WEEKDAY", 80 }
				};
			}
			if (Class1742.dictionary_97.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
					if (arrayList_0 == null || arrayList_0.Count == 0 || arrayList_0.Count > 2)
					{
						bool_0 = false;
					}
					return;
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
					if (arrayList_0 == null || arrayList_0.Count != 2)
					{
						bool_0 = false;
					}
					return;
				case 19:
				case 20:
				case 21:
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
				case 32:
				case 33:
				case 34:
					if (arrayList_0 == null || arrayList_0.Count != 1)
					{
						bool_0 = false;
					}
					return;
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
					if (arrayList_0 == null || arrayList_0.Count == 0 || arrayList_0.Count > 30)
					{
						bool_0 = false;
					}
					return;
				case 45:
				case 46:
					if (arrayList_0 == null || arrayList_0.Count == 0)
					{
						bool_0 = false;
					}
					return;
				case 47:
				case 48:
					if (arrayList_0 != null && arrayList_0.Count > 1)
					{
						bool_0 = false;
					}
					return;
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
				case 56:
				case 57:
				case 58:
				case 59:
				case 60:
				case 61:
				case 62:
				case 63:
					if (arrayList_0 == null || arrayList_0.Count != 3)
					{
						bool_0 = false;
					}
					return;
				case 64:
				case 65:
				case 66:
				case 67:
					if (arrayList_0 != null && arrayList_0.Count != 0)
					{
						bool_0 = false;
					}
					return;
				case 68:
				case 69:
				case 70:
				case 71:
					if (arrayList_0 == null || arrayList_0.Count < 3 || arrayList_0.Count > 5)
					{
						bool_0 = false;
					}
					return;
				case 72:
				case 73:
					if (arrayList_0 == null || arrayList_0.Count < 3 || arrayList_0.Count > 4)
					{
						bool_0 = false;
					}
					return;
				case 74:
				case 75:
				case 76:
					if (arrayList_0 == null || (arrayList_0.Count != 2 && arrayList_0.Count != 3))
					{
						bool_0 = false;
					}
					return;
				case 77:
				case 78:
					if (arrayList_0 == null || arrayList_0.Count < 2 || arrayList_0.Count > 30)
					{
						bool_0 = false;
					}
					return;
				case 79:
					if (arrayList_0 == null || arrayList_0.Count != 4)
					{
						bool_0 = false;
					}
					return;
				case 80:
					if (arrayList_0 == null || (arrayList_0.Count != 1 && arrayList_0.Count != 2))
					{
						bool_0 = false;
					}
					return;
				case 17:
				case 18:
					return;
				}
			}
		}
		method_7();
	}

	private void method_7()
	{
		if (!bool_0 || (string_0[0] == '"' && string_0[string_0.Length - 1] == '"'))
		{
			return;
		}
		bool flag = true;
		int num = 0;
		for (int i = 0; i < string_0.Length; i++)
		{
			if (string_0[i] < '0' || string_0[i] > '9')
			{
				if (string_0[i] != '.')
				{
					flag = false;
					break;
				}
				num++;
				if (num > 1)
				{
					bool_0 = false;
					return;
				}
			}
		}
		if (!flag)
		{
			int num2 = string_0.IndexOf(':');
			if (num2 != -1)
			{
				method_8();
			}
			else
			{
				method_9(string_0);
			}
		}
	}

	private void method_8()
	{
		if (!bool_0)
		{
			return;
		}
		string[] array = string_0.Split(':');
		if (array.Length != 2)
		{
			bool_0 = false;
			return;
		}
		method_9(array[0]);
		if (bool_0)
		{
			method_9(array[1]);
		}
	}

	private void method_9(string string_1)
	{
		if (!bool_0)
		{
			return;
		}
		string[] array = string_1.Split('!');
		if (array.Length == 1)
		{
			method_10(string_1);
		}
		else if (array.Length == 2)
		{
			bool flag = false;
			for (int i = 0; i < worksheetCollection_0.Count; i++)
			{
				if (array[0] == worksheetCollection_0[i].Name.ToUpper())
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				method_10(array[1]);
			}
			else
			{
				bool_0 = false;
			}
		}
		else
		{
			bool_0 = false;
		}
	}

	private void method_10(string string_1)
	{
		bool flag = true;
		int num = 0;
		for (int i = 0; i < string_1.Length; i++)
		{
			if (string_1[i] < '0' || string_1[i] > '9')
			{
				if (string_1[i] != '.')
				{
					flag = false;
					break;
				}
				num++;
				if (num > 1)
				{
					bool_0 = false;
					return;
				}
			}
		}
		if (!flag)
		{
			method_11(string_1);
		}
	}

	private void method_11(string string_1)
	{
		if (!bool_0)
		{
			return;
		}
		if (string_1.IndexOf("$") != -1)
		{
			Match match = Regex.Match(string_1, ".*\\$[^\\$]+\\$?[^\\$]+", RegexOptions.IgnoreCase);
			if (!match.Success)
			{
				bool_0 = false;
				return;
			}
			string_1 = string_1.Replace("$", null);
		}
		if (!char.IsLetter(string_1[0]))
		{
			bool_0 = false;
		}
		else
		{
			if (string_1.Length == 1 && char.IsLetter(string_1[0]))
			{
				return;
			}
			if (char.IsLetter(string_1, 1))
			{
				if (string_1.Length == 2)
				{
					return;
				}
				int num = 2;
				while (true)
				{
					if (num < string_1.Length)
					{
						if (!char.IsDigit(string_1, num))
						{
							break;
						}
						num++;
						continue;
					}
					uint num2 = (uint)((string_1[0] - 64) * 26 + string_1[1] - 65);
					if (num2 != 0 && num2 <= 255)
					{
						try
						{
							int num3 = int.Parse(string_1.Substring(2));
							if (num3 < 1 || num3 > 65536)
							{
								bool_0 = false;
							}
							return;
						}
						catch
						{
							bool_0 = false;
							return;
						}
					}
					bool_0 = false;
					return;
				}
				bool_0 = false;
			}
			else if (char.IsDigit(string_1, 1))
			{
				uint num4 = (uint)(string_1[0] - 65);
				if (num4 <= 255)
				{
					try
					{
						int num5 = int.Parse(string_1.Substring(1));
						if (num5 < 1 || num5 > 65536)
						{
							bool_0 = false;
						}
						return;
					}
					catch
					{
						bool_0 = false;
						return;
					}
				}
				bool_0 = false;
			}
			else
			{
				bool_0 = false;
			}
		}
	}
}
