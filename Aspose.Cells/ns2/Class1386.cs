using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns22;
using ns29;

namespace ns2;

internal class Class1386
{
	internal static readonly string[] string_0 = new string[33]
	{
		"MMM", "DD", "DDD", "YYYY", "M/", "/M", "/D", "D/", "/Y", "Y/",
		"-M", "M-", "-D", "D-", "-Y", "Y-", "MM/DD", "DD/MM", "M/D", "D/M",
		"MM-DD", "DD-MM", "M-D", "D-M", "H:MM", "MM:SS", "年", "月", "日", "时",
		"分", "秒", "MM"
	};

	internal static readonly string string_1 = "MMM|DD|DDD|YYYY|M/|/M|D/|D\\\\|/D|Y/|/Y|-M|M-|-D|D-|-Y|Y-|MM|M/D|D/M|M-D|D-M|^D$|\\[H\\]|H:MM|MM:SS|年|月|日|时|分|秒|MD";

	private static Regex regex_0 = null;

	[SpecialName]
	internal static Regex smethod_0()
	{
		if (regex_0 == null)
		{
			regex_0 = new Regex("^([a-z|A-Z|(]*)([^a-z|A-Z]+)([a-z|A-Z|)]*)$");
		}
		return regex_0;
	}

	internal Class1386()
	{
	}

	internal static bool smethod_1(string string_2)
	{
		string input = smethod_2(string_2);
		return Regex.IsMatch(input, string_1, RegexOptions.IgnoreCase);
	}

	internal static string smethod_2(string string_2)
	{
		int length = string_2.Length;
		StringBuilder stringBuilder = new StringBuilder(length);
		for (int i = 0; i < length; i++)
		{
			switch (string_2[i])
			{
			default:
				stringBuilder.Append(string_2[i]);
				break;
			case '\\':
				stringBuilder.Append(string_2[i++]);
				stringBuilder.Append(string_2[i]);
				break;
			case '\'':
				for (i++; i < length && string_2[i] != '\''; i++)
				{
				}
				break;
			case '"':
				for (i++; i < length && string_2[i] != '"'; i++)
				{
				}
				break;
			}
		}
		return stringBuilder.ToString();
	}

	internal static object[] smethod_3(string string_2, char char_0)
	{
		int length = string_2.Length;
		int num = 1;
		int num2 = 0;
		object[] array = new object[2] { 1, string_2 };
		for (int num3 = length - 1; num3 >= 0; num3--)
		{
			char c = string_2[num3];
			switch (c)
			{
			default:
			{
				if (c != char_0)
				{
					break;
				}
				bool flag = false;
				num = 1000;
				num2 = 1;
				num3--;
				while (num3 >= 0)
				{
					c = string_2[num3];
					char c2 = c;
					if (c2 != '#' && c2 != '0')
					{
						if (c == char_0)
						{
							num *= 1000;
							num2++;
							flag = true;
						}
						else
						{
							flag = false;
						}
						if (flag)
						{
							num3--;
							continue;
						}
						num3++;
						num = 1;
						num2 = 0;
						break;
					}
					array[0] = num;
					array[1] = string_2.Substring(0, num3 + 1) + string_2.Substring(num3 + num2 + 1);
					return array;
				}
				break;
			}
			case '\'':
				num3--;
				while (num3 >= 0 && string_2[num3] != '\'')
				{
					num3--;
				}
				break;
			case '"':
				num3--;
				while (num3 >= 0 && string_2[num3] != '"')
				{
					num3--;
				}
				break;
			case '#':
			case '0':
				return array;
			}
		}
		array[0] = num;
		array[1] = string_2;
		return array;
	}

	internal static string smethod_4(string string_2)
	{
		return string_2;
	}

	internal static void smethod_5(StringBuilder stringBuilder_0)
	{
		if (stringBuilder_0.Length > 0 && stringBuilder_0[stringBuilder_0.Length - 1] == '\'')
		{
			stringBuilder_0.Remove(stringBuilder_0.Length - 1, 1);
		}
		else
		{
			stringBuilder_0.Append('\'');
		}
	}

	internal static object[] smethod_6(string string_2, CountryCode countryCode_0, bool bool_0)
	{
		Enum136 @enum = Enum136.const_7;
		bool flag = false;
		int length = string_2.Length;
		StringBuilder stringBuilder = new StringBuilder(length);
		StringBuilder stringBuilder2 = new StringBuilder(length);
		int i = 0;
		while (i < length)
		{
			switch (string_2[i])
			{
			case '\'':
				flag = true;
				stringBuilder.Append("\"'");
				while (true)
				{
					i++;
					if (i < length)
					{
						if (string_2[i] == '\'')
						{
							stringBuilder.Append('\'');
							continue;
						}
						if (string_2[i] == '\\')
						{
							stringBuilder.Append(string_2[i + 1]);
							i++;
							continue;
						}
						stringBuilder.Append('"');
						i--;
						break;
					}
					stringBuilder.Append('"');
					break;
				}
				break;
			case '"':
				flag = true;
				stringBuilder.Append(string_2[i]);
				for (i++; i < length; i++)
				{
					if (string_2[i] != '"')
					{
						stringBuilder.Append(string_2[i]);
						continue;
					}
					stringBuilder.Append(string_2[i]);
					break;
				}
				break;
			case '/':
				if (i + 1 < string_2.Length && string_2[i + 1] == '?')
				{
					@enum = Enum136.const_4;
				}
				else if (i - 1 < string_2.Length && string_2[i - 1] == '?')
				{
					@enum = Enum136.const_4;
				}
				stringBuilder.Append(string_2[i]);
				break;
			case '#':
			case '0':
				if (@enum == Enum136.const_7)
				{
					@enum = Enum136.const_2;
				}
				stringBuilder.Append(string_2[i]);
				break;
			case 'T':
				if (countryCode_0 == CountryCode.Germany)
				{
					@enum = Enum136.const_3;
					stringBuilder.Append('d');
				}
				else
				{
					stringBuilder.Append('T');
				}
				break;
			case '@':
				@enum = Enum136.const_1;
				stringBuilder.Append(string_2[i]);
				break;
			case 'J':
				if (countryCode_0 == CountryCode.Germany)
				{
					@enum = Enum136.const_3;
					stringBuilder.Append('y');
				}
				else
				{
					stringBuilder.Append('J');
				}
				break;
			case 'M':
			case 'm':
			{
				@enum = Enum136.const_3;
				int k;
				for (k = i + 1; k < length && string_2[k] == 'm'; k++)
				{
				}
				char value = (((i <= 0 || !smethod_8(string_2[i - 1])) && (k >= length || !smethod_8(string_2[k]))) ? 'M' : 'm');
				stringBuilder.Append(value, k - i);
				i = k;
				continue;
			}
			case 'Y':
			case 'y':
				@enum = Enum136.const_3;
				stringBuilder.Append('y');
				break;
			case '[':
			{
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				for (i++; i < length && string_2[i] != ']'; i++)
				{
					if (string_2[i] == '-')
					{
						flag3 = true;
					}
					else if (string_2[i] == '$' && !flag2)
					{
						flag3 = false;
						flag2 = true;
					}
					else if (flag3)
					{
						stringBuilder2.Append(string_2[i]);
					}
					else if (flag2)
					{
						if (!flag4)
						{
							flag4 = true;
							smethod_5(stringBuilder);
						}
						stringBuilder.Append(string_2[i]);
					}
				}
				if (flag4)
				{
					smethod_5(stringBuilder);
					flag = true;
				}
				break;
			}
			case '\\':
				if (i + 1 < length)
				{
					switch (string_2[i + 1])
					{
					case '\'':
						stringBuilder.Append(string_2[i]);
						stringBuilder.Append(string_2[i + 1]);
						i++;
						break;
					default:
						stringBuilder.Append(string_2[i]);
						break;
					case ' ':
					case '-':
					case '/':
					case '–':
						break;
					}
				}
				break;
			case '_':
				if (i != length - 1)
				{
					if (bool_0)
					{
						smethod_5(stringBuilder);
						stringBuilder.Append(string_2[i + 1]);
						smethod_5(stringBuilder);
					}
					i++;
				}
				break;
			case 'A':
			case 'a':
				if (string_2.Length - i >= 3)
				{
					int num = 1;
					for (int j = i + 1; j < string_2.Length; j++)
					{
						if (string_2[j] == 'a')
						{
							num++;
						}
					}
					if (num >= 3)
					{
						@enum = Enum136.const_3;
						if (num == 3)
						{
							stringBuilder.Append("ddd");
						}
						else
						{
							stringBuilder.Append("dddd");
						}
						i += num - 1;
						break;
					}
				}
				if (string_2.Length > i + 4 && string_2[i + 1] == 'M' && string_2[i + 2] == '/' && string_2[i + 3] == 'P' && string_2[i + 4] == 'M')
				{
					if (countryCode_0 == CountryCode.Germany)
					{
						@enum = Enum136.const_3;
						if (!string_2.StartsWith("[$-F400]"))
						{
							stringBuilder.Append("tt");
							stringBuilder.Replace('H', 'h');
						}
					}
					else
					{
						stringBuilder.Append("tt");
						stringBuilder.Replace('H', 'h');
						@enum = Enum136.const_3;
					}
					i += 4;
				}
				else if (countryCode_0 == CountryCode.Italy)
				{
					@enum = Enum136.const_3;
					stringBuilder.Append('y');
				}
				else
				{
					stringBuilder.Append(string_2[i]);
				}
				break;
			case 'D':
			case 'd':
				@enum = Enum136.const_3;
				stringBuilder.Append('d');
				break;
			case 'E':
			case 'e':
				if (i > 0)
				{
					switch (string_2[i - 1])
					{
					default:
						stringBuilder.Append(string_2[i]);
						break;
					case '#':
					case '.':
					case '0':
						@enum = Enum136.const_5;
						stringBuilder.Append('E');
						if (i + 1 < length && string_2[i + 1] == '+')
						{
							i++;
						}
						break;
					}
				}
				else
				{
					stringBuilder.Append(string_2[i]);
				}
				break;
			default:
				stringBuilder.Append(string_2[i]);
				break;
			case 'G':
			case 'g':
				if (countryCode_0 == CountryCode.Italy)
				{
					@enum = Enum136.const_3;
					stringBuilder.Append('d');
					break;
				}
				stringBuilder.Append(string_2[i]);
				if (i + 6 < length && ((string_2[i + 1] | 0x20) == 101 || (string_2[i + 2] | 0x20) == 110 || (string_2[i + 3] | 0x20) == 101 || (string_2[i + 4] | 0x20) == 114 || (string_2[i + 5] | 0x20) == 97 || (string_2[i + 6] | 0x20) == 108))
				{
					@enum = Enum136.const_1;
					stringBuilder.Append(string_2, i + 1, 6);
				}
				break;
			case 'H':
			case 'h':
				@enum = Enum136.const_3;
				if (i == 0 || string_2[i - 1] != 'h' || (i < string_2.Length - 1 && string_2[i + 1] == ':'))
				{
					stringBuilder.Append('H');
				}
				break;
			case '*':
				break;
			}
			i++;
		}
		if (@enum != Enum136.const_4)
		{
			stringBuilder.Replace("?", "");
		}
		string text = stringBuilder.ToString();
		string text2 = stringBuilder2.ToString();
		if (countryCode_0 == CountryCode.Germany && text2 == "F800")
		{
			text = text.Replace("MMMM\\ dd\\,", "dd. MMMM");
		}
		return new object[3] { text, @enum, flag };
	}

	internal static string smethod_7(string rhv, CountryCode code, out bool hasLocal)
	{
		int length = rhv.Length;
		StringBuilder stringBuilder = new StringBuilder(length);
		hasLocal = false;
		int i = 0;
		while (i < length)
		{
			switch (rhv[i])
			{
			case '\'':
				stringBuilder.Append("\"'");
				while (true)
				{
					i++;
					if (i < length)
					{
						if (rhv[i] == '\'')
						{
							stringBuilder.Append('\'');
							continue;
						}
						if (rhv[i] == '\\')
						{
							stringBuilder.Append(rhv[i + 1]);
							i++;
							continue;
						}
						stringBuilder.Append('"');
						i--;
						break;
					}
					stringBuilder.Append('"');
					break;
				}
				goto case '*';
			case '"':
				stringBuilder.Append(rhv[i]);
				for (i++; i < length; i++)
				{
					if (rhv[i] != '"')
					{
						stringBuilder.Append(rhv[i]);
						continue;
					}
					stringBuilder.Append(rhv[i]);
					break;
				}
				goto case '*';
			case 'T':
				if (code == CountryCode.Germany)
				{
					stringBuilder.Append('d');
				}
				else
				{
					stringBuilder.Append('T');
				}
				goto case '*';
			case 'J':
				if (code == CountryCode.Germany)
				{
					stringBuilder.Append('y');
				}
				else
				{
					stringBuilder.Append('J');
				}
				goto case '*';
			case '\\':
				if (i + 1 < length)
				{
					switch (rhv[i + 1])
					{
					default:
						stringBuilder.Append(rhv[i]);
						break;
					case '\'':
					case '-':
					case '/':
						break;
					}
				}
				goto case '*';
			case '_':
				if (i != length - 1)
				{
					i++;
				}
				goto case '*';
			case 'A':
			case 'a':
				if (rhv.Length - i >= 3)
				{
					int num = 1;
					for (int k = i + 1; k < rhv.Length; k++)
					{
						if (rhv[k] == 'a')
						{
							num++;
						}
					}
					if (num >= 3)
					{
						if (num == 3)
						{
							stringBuilder.Append("ddd");
						}
						else
						{
							stringBuilder.Append("dddd");
						}
						i += num - 1;
						hasLocal = true;
						goto case '*';
					}
				}
				if (rhv.Length > i + 4 && rhv[i + 1] == 'M' && rhv[i + 2] == '/' && rhv[i + 3] == 'P' && rhv[i + 4] == 'M')
				{
					if (code == CountryCode.Germany)
					{
						if (!rhv.StartsWith("[$-F400]"))
						{
							stringBuilder.Append("tt");
							stringBuilder.Replace('H', 'h');
						}
					}
					else
					{
						stringBuilder.Append("tt");
						stringBuilder.Replace('H', 'h');
					}
					i += 4;
				}
				else if (code == CountryCode.Italy)
				{
					stringBuilder.Append('y');
				}
				else
				{
					stringBuilder.Append(rhv[i]);
				}
				goto case '*';
			case 'B':
			case 'b':
				if (code == CountryCode.Thailand)
				{
					stringBuilder.Append('y');
				}
				else
				{
					stringBuilder.Append(rhv[i]);
				}
				goto case '*';
			case 'D':
			case 'd':
				stringBuilder.Append('d');
				goto case '*';
			case 'G':
			case 'g':
				if (code == CountryCode.Italy)
				{
					stringBuilder.Append('d');
				}
				else
				{
					stringBuilder.Append(rhv[i]);
				}
				goto case '*';
			case 'H':
			case 'h':
				if (i == 0 || rhv[i - 1] != 'h' || (i < rhv.Length - 1 && rhv[i + 1] == ':'))
				{
					stringBuilder.Append('H');
				}
				goto case '*';
			default:
				stringBuilder.Append(rhv[i]);
				goto case '*';
			case 'ด':
				if (code == CountryCode.Thailand)
				{
					stringBuilder.Append('M');
				}
				else
				{
					stringBuilder.Append(rhv[i]);
				}
				goto case '*';
			case 'Y':
			case 'y':
				stringBuilder.Append('y');
				goto case '*';
			case '*':
				i++;
				break;
			case 'M':
			case 'm':
			{
				int j;
				for (j = i + 1; j < length && rhv[j] == 'm'; j++)
				{
				}
				char value = (((i <= 0 || !smethod_8(rhv[i - 1])) && (j >= length || !smethod_8(rhv[j]))) ? 'M' : 'm');
				stringBuilder.Append(value, j - i);
				i = j;
				break;
			}
			}
		}
		string text = stringBuilder.ToString();
		if (code == CountryCode.Germany && text.StartsWith("[$-F800]"))
		{
			text = text.Replace("MMMM\\ dd\\,", "dd. MMMM");
		}
		return text;
	}

	internal static bool smethod_8(char char_0)
	{
		if (char_0 != 'h' && char_0 != 's')
		{
			return char_0 == ':';
		}
		return true;
	}

	internal static string smethod_9(int int_0, string string_2, object object_0, TypeCode typeCode_0, bool bool_0, CountryCode countryCode_0, CultureInfo cultureInfo_0, bool bool_1)
	{
		string result = null;
		if (cultureInfo_0 == null)
		{
			cultureInfo_0 = CultureInfo.CurrentCulture;
		}
		double num = 0.0;
		int num2 = 0;
		switch (typeCode_0)
		{
		case TypeCode.Double:
			num = (double)object_0;
			break;
		case TypeCode.Int32:
			num = (int)object_0;
			break;
		}
		double num3 = 0.0 - num;
		switch (int_0)
		{
		case 0:
			switch (typeCode_0)
			{
			case TypeCode.Double:
				num = (double)object_0;
				if (string_2 != null && !(string_2 == ""))
				{
					result = smethod_12(string_2, num, bool_0, bool_1: false);
					break;
				}
				if (num > 100000000000.0)
				{
					return num.ToString();
				}
				if (bool_1)
				{
					double num4 = Math.Abs(num);
					if (num4 > 1.0)
					{
						int num5 = (int)Math.Log10((int)num4);
						if (num < 0.0)
						{
							num5++;
						}
						int num6 = 10 - num5;
						if (num6 > 0)
						{
							StringBuilder stringBuilder = new StringBuilder(10);
							stringBuilder.Append("0.");
							for (int i = 0; i < num6; i++)
							{
								stringBuilder.Append("#");
							}
							return num.ToString(stringBuilder.ToString());
						}
					}
				}
				result = num.ToString("0.###############");
				break;
			case TypeCode.Int32:
				result = ((int)object_0).ToString();
				break;
			}
			break;
		case 1:
			result = num.ToString("0");
			break;
		case 2:
			result = num.ToString("0.00");
			break;
		case 3:
			result = num.ToString("#,##0");
			break;
		case 4:
			result = num.ToString("#,##0.00");
			break;
		case 5:
		case 6:
			result = ((string_2 != null && !(string_2 == "")) ? smethod_12(string_2, num, bool_0, bool_1) : ((!(num > 0.0)) ? ("(" + NumberFormatInfo.CurrentInfo.CurrencySymbol + num3.ToString("#,##0") + ")") : (NumberFormatInfo.CurrentInfo.CurrencySymbol + num.ToString("#,##0"))));
			break;
		case 7:
		case 8:
			result = ((string_2 != null && !(string_2 == "")) ? smethod_12(string_2, num, bool_0, bool_1) : ((!(num > 0.0)) ? ("(" + NumberFormatInfo.CurrentInfo.CurrencySymbol + num3.ToString("#,##0.00") + ")") : (NumberFormatInfo.CurrentInfo.CurrencySymbol + num.ToString("#,##0.00"))));
			break;
		case 9:
			result = num.ToString("0%");
			break;
		case 10:
			result = num.ToString("0.00%");
			break;
		case 11:
			switch (typeCode_0)
			{
			case TypeCode.Double:
				num = (double)object_0;
				result = smethod_17(num, "0.00E+00", "0.00E00");
				break;
			case TypeCode.Int32:
				num2 = (int)object_0;
				result = smethod_17(num2, "0.00E+00", "0.00E00");
				break;
			}
			break;
		case 12:
			switch (typeCode_0)
			{
			case TypeCode.Double:
				num = (double)object_0;
				result = smethod_15("# ?/?", num);
				break;
			case TypeCode.Int32:
				result = ((int)object_0).ToString("0");
				break;
			}
			break;
		case 13:
			switch (typeCode_0)
			{
			case TypeCode.Double:
				num = (double)object_0;
				result = smethod_15("# ??/??", num);
				break;
			case TypeCode.Int32:
				result = ((int)object_0).ToString("0");
				break;
			}
			break;
		case 23:
		case 24:
			result = ((!(num >= 0.0)) ? ("($" + num3.ToString("#,##0") + ")") : ("$" + num.ToString("#,##0")));
			break;
		case 25:
		case 26:
			result = ((!(num >= 0.0)) ? ("($" + num3.ToString("#,##0.00") + ")") : ("$" + num.ToString("#,##0.00")));
			break;
		case 37:
		case 38:
			result = num.ToString("#,##0;(#,##0)");
			break;
		case 39:
		case 40:
			result = num.ToString("#,##0.00;(#,##0.00)");
			break;
		case 41:
			result = ((!(num > 0.0)) ? ((num != 0.0) ? num3.ToString("(#,##0)") : "-") : num.ToString("#,##0"));
			break;
		case 42:
			result = ((!(num > 0.0)) ? ((num != 0.0) ? (NumberFormatInfo.CurrentInfo.CurrencySymbol + " " + num3.ToString("(#,##0)")) : "-") : (NumberFormatInfo.CurrentInfo.CurrencySymbol + " " + num.ToString("#,##0")));
			break;
		case 43:
			result = ((!(num > 0.0)) ? ((num != 0.0) ? num3.ToString("(#,##0.00)") : "-") : num.ToString("#,##0.00"));
			break;
		case 44:
			result = ((!(num > 0.0)) ? ((num != 0.0) ? (NumberFormatInfo.CurrentInfo.CurrencySymbol + " " + num3.ToString("(#,##0.00)")) : "-") : (NumberFormatInfo.CurrentInfo.CurrencySymbol + " " + num.ToString("#,##0.00")));
			break;
		case 48:
			switch (typeCode_0)
			{
			case TypeCode.Double:
				num = (double)object_0;
				result = smethod_17(num, "##0.0E+0", "##0.0E0");
				break;
			case TypeCode.Int32:
				num2 = (int)object_0;
				result = smethod_17(num2, "##0.0E+0", "##0.0E0");
				break;
			}
			break;
		case 49:
			switch (typeCode_0)
			{
			case TypeCode.Double:
				num = (double)object_0;
				result = ((cultureInfo_0 == null) ? num.ToString() : num.ToString("0.###################", cultureInfo_0));
				break;
			case TypeCode.Int32:
				result = ((int)object_0).ToString();
				break;
			}
			break;
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
		case 22:
		case 27:
		case 28:
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
		case 45:
		case 46:
		case 47:
		case 50:
		case 51:
		case 52:
		case 53:
		case 54:
		case 55:
		case 56:
		case 57:
		case 58:
		{
			DateTime dateTime;
			switch (typeCode_0)
			{
			default:
				dateTime = (DateTime)object_0;
				break;
			case TypeCode.Double:
				num = (double)object_0;
				dateTime = CellsHelper.GetDateTimeFromDouble(num, bool_0);
				break;
			case TypeCode.Int32:
				num2 = (int)object_0;
				dateTime = CellsHelper.GetDateTimeFromDouble(num2, bool_0);
				break;
			}
			switch (int_0)
			{
			case 14:
				return dateTime.ToString(Class1025.GetFormat(14, (int)countryCode_0));
			case 15:
				if (countryCode_0 == CountryCode.Germany)
				{
					return dateTime.ToString("d.MMM yy", cultureInfo_0);
				}
				return dateTime.ToString("d-MMM-yy", CultureInfo.InvariantCulture);
			case 16:
				if (countryCode_0 == CountryCode.Germany)
				{
					return dateTime.ToString("d.MMM", cultureInfo_0);
				}
				return dateTime.ToString("d-MMM", CultureInfo.InvariantCulture);
			case 17:
				return dateTime.ToString("MMM-yy", CultureInfo.InvariantCulture);
			case 18:
				if (countryCode_0 == CountryCode.Germany)
				{
					return dateTime.ToString("MMM yy", cultureInfo_0);
				}
				return dateTime.ToString("h:mm tt", CultureInfo.InvariantCulture);
			case 19:
				return dateTime.ToString("h:mm:ss tt", CultureInfo.InvariantCulture);
			case 20:
				return dateTime.ToString("H:mm", CultureInfo.InvariantCulture);
			case 21:
				return dateTime.ToString("H:mm:ss", CultureInfo.InvariantCulture);
			case 22:
				return dateTime.ToString(Class1025.GetFormat(22, (int)countryCode_0));
			case 30:
				result = dateTime.ToString("M/d/yy");
				break;
			case 31:
				result = dateTime.ToString("M月d日yyyy年");
				break;
			case 32:
				result = dateTime.ToString("h时mm分");
				break;
			case 33:
				result = dateTime.ToString("h时mm分ss秒");
				break;
			case 45:
				result = dateTime.ToString("mm:ss");
				break;
			case 46:
				num = CellsHelper.GetDoubleFromDateTime(dateTime, bool_0);
				result = (int)(num * 24.0) + ":" + dateTime.ToString("mm:ss");
				break;
			case 47:
				result = dateTime.ToString("mm:ss.f");
				break;
			default:
				return ((DateTime)object_0).ToString();
			case 34:
			case 55:
				result = dateTime.ToString("tth时mm分");
				break;
			case 35:
			case 56:
				result = dateTime.ToString("tth时mm分ss秒");
				break;
			case 27:
			case 36:
			case 50:
			case 52:
			case 57:
				result = dateTime.ToString("yyyy年M月");
				break;
			case 28:
			case 29:
			case 51:
			case 53:
			case 54:
			case 58:
				result = dateTime.ToString("M月d日");
				break;
			}
			break;
		}
		}
		return result;
	}

	internal static string smethod_10(string string_2, DateTime dateTime_0, CountryCode countryCode_0, bool bool_0)
	{
		string[] array = string_2.Split(';');
		if (array.Length == 1)
		{
			return smethod_11(string_2, dateTime_0, countryCode_0, bool_0);
		}
		return smethod_11(array[0], dateTime_0, countryCode_0, bool_0);
	}

	private static string smethod_11(string string_2, DateTime dateTime_0, CountryCode countryCode_0, bool bool_0)
	{
		if (string_2 != null && !(string_2 == ""))
		{
			string_2 = smethod_7(string_2, countryCode_0, out var hasLocal);
			if (string_2 == "d")
			{
				return dateTime_0.ToString("%d");
			}
			int num = string_2.IndexOf("[");
			if (num == -1)
			{
				DateTimeFormatInfo dateTimeFormatInfo = null;
				return dateTime_0.ToString(string_2, countryCode_0 switch
				{
					CountryCode.Germany => new CultureInfo("de-DE", useUserOverride: false).DateTimeFormat, 
					CountryCode.Italy => new CultureInfo("it-IT", useUserOverride: false).DateTimeFormat, 
					CountryCode.Saudi => new CultureInfo("ar-AE", useUserOverride: false).DateTimeFormat, 
					CountryCode.SouthKorea => (!hasLocal) ? DateTimeFormatInfo.InvariantInfo : new CultureInfo("ko-KR", useUserOverride: false).DateTimeFormat, 
					CountryCode.Thailand => new CultureInfo("th-TH", useUserOverride: false).DateTimeFormat, 
					_ => DateTimeFormatInfo.InvariantInfo, 
				});
			}
			int num2 = string_2.IndexOf("]");
			if (num2 == -1)
			{
				return dateTime_0.ToString();
			}
			if (num2 - num == 2 && (string_2[num + 1] == 'h' || string_2[num + 1] == 'H'))
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (num != 0)
				{
					stringBuilder.Append(dateTime_0.ToString(string_2.Substring(0, num), DateTimeFormatInfo.InvariantInfo));
				}
				stringBuilder.Append(((int)(CellsHelper.GetDoubleFromDateTime(dateTime_0, bool_0) * 24.0)).ToString(DateTimeFormatInfo.InvariantInfo));
				if (num2 != string_2.Length - 1)
				{
					stringBuilder.Append(dateTime_0.ToString(string_2.Substring(num2 + 1), DateTimeFormatInfo.InvariantInfo));
				}
				return stringBuilder.ToString();
			}
			string text = string_2.Substring(num + 1, num2 - num - 1);
			string_2 = string_2.Remove(num, num2 - num + 1);
			string text2;
			string text3;
			if (text != null && (text2 = text) != null && text2 == "$-409" && (text3 = string_2) != null && text3 == "MMMMM-yy")
			{
				return dateTime_0.ToString("MMM")[0] + "-" + dateTime_0.ToString("yy");
			}
			return dateTime_0.ToString(string_2, DateTimeFormatInfo.CurrentInfo);
		}
		return "";
	}

	internal static string smethod_12(string string_2, double double_0, bool bool_0, bool bool_1)
	{
		string format = Class775.GetFormat(ref double_0, string_2);
		return smethod_13(format, double_0, bool_0, bool_1);
	}

	private static string smethod_13(string string_2, double double_0, bool bool_0, bool bool_1)
	{
		if (string_2 != null && !(string_2 == ""))
		{
			object[] array = smethod_6(string_2, CountryCode.USA, bool_1);
			string_2 = (string)array[0];
			Enum136 @enum = (Enum136)array[1];
			bool flag = (bool)array[2];
			switch (@enum)
			{
			case Enum136.const_1:
				return double_0.ToString();
			case Enum136.const_3:
				return CellsHelper.GetDateTimeFromDouble(double_0, bool_0).ToString(string_2);
			case Enum136.const_4:
				return smethod_15(string_2, double_0);
			case Enum136.const_5:
				return double_0.ToString(string_2);
			default:
				if (flag)
				{
					StringBuilder stringBuilder = new StringBuilder();
					int num = 0;
					for (int i = 0; i < string_2.Length; i++)
					{
						if (string_2[i] != '"')
						{
							continue;
						}
						if (num < i)
						{
							stringBuilder.Append(smethod_14(string_2.Substring(num, i - num), double_0, flag));
						}
						for (i++; i < string_2.Length; i++)
						{
							if (string_2[i] != '"')
							{
								stringBuilder.Append(string_2[i]);
								continue;
							}
							num = i + 1;
							break;
						}
					}
					if (num < string_2.Length)
					{
						if (double_0 < 0.0)
						{
							stringBuilder.Insert(0, '-');
							stringBuilder.Append(smethod_14(string_2.Substring(num), 0.0 - double_0, flag));
						}
						else
						{
							stringBuilder.Append(smethod_14(string_2.Substring(num), double_0, flag));
						}
					}
					return stringBuilder.ToString();
				}
				return smethod_14(string_2, double_0, flag);
			case Enum136.const_7:
				string_2 = string_2.Replace("\"", null);
				string_2 = string_2.Replace("'", null);
				return string_2;
			}
		}
		return "";
	}

	internal static string smethod_14(string string_2, double double_0, bool bool_0)
	{
		object[] array = smethod_3(string_2, ',');
		int num = (int)array[0];
		if (num > 1)
		{
			double_0 /= (double)num;
			string_2 = (string)array[1];
		}
		string_2 = smethod_4(string_2);
		Match match = smethod_0().Match(string_2);
		if (match.Success)
		{
			return match.Groups[1].Value + double_0.ToString(match.Groups[2].Value) + match.Groups[3].Value;
		}
		return double_0.ToString(string_2);
	}

	private static string smethod_15(string string_2, double double_0)
	{
		int num = string_2.IndexOf(' ');
		string text = null;
		double num2 = Math.Floor(double_0);
		double num3 = double_0 - num2;
		if (num != -1)
		{
			text = string_2.Substring(0, num);
			string_2 = string_2.Substring(num + 1);
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (num2 == double_0)
		{
			if (text != null)
			{
				return double_0.ToString(text);
			}
			return double_0.ToString("0");
		}
		if (text != null)
		{
			stringBuilder.Append(num2.ToString(text));
			stringBuilder.Append(' ');
			double_0 -= num2;
		}
		string[] array = string_2.Split('/');
		if (array.Length == 1)
		{
			return stringBuilder.ToString();
		}
		int num4 = 0;
		int num5 = 2;
		if (array[1].IndexOf('?') == -1)
		{
			num5 = int.Parse(array[1]);
			num4 = (int)(double_0 * (double)num5 + 0.5);
			if (num4 == num5)
			{
				return (num2 + 1.0).ToString(text);
			}
			if (num4 == 0)
			{
				return stringBuilder.ToString();
			}
			stringBuilder.Append(num4);
			stringBuilder.Append("/");
			stringBuilder.Append(array[1]);
			return stringBuilder.ToString();
		}
		int num6 = (int)Math.Pow(10.0, array[1].Length);
		double num7 = 1.0;
		double num8 = num7;
		for (int i = 2; i < num6; i++)
		{
			num8 = num3 * (double)i;
			num8 -= (double)(int)num8;
			if (num8 < 0.5)
			{
				if (num8 < num7)
				{
					num7 = num8;
					num5 = i;
				}
				continue;
			}
			num8 = 1.0 - num8;
			if (num8 < num7)
			{
				num7 = num8;
				num5 = i;
			}
		}
		num4 = (int)(double_0 * (double)num5 + 0.5);
		if (num4 == 0)
		{
			return "0";
		}
		stringBuilder.Append(num4);
		stringBuilder.Append("/");
		stringBuilder.Append(num5);
		return stringBuilder.ToString();
	}

	internal static string smethod_16(int int_0, string string_2, object object_0, bool bool_0, CountryCode countryCode_0, CultureInfo cultureInfo_0, bool bool_1)
	{
		TypeCode typeCode = Type.GetTypeCode(object_0.GetType());
		if (string_2 != null && string_2 != "")
		{
			switch (typeCode)
			{
			case TypeCode.Double:
				return smethod_12(string_2, (double)object_0, bool_0, bool_1);
			case TypeCode.DateTime:
				return smethod_10(string_2, (DateTime)object_0, countryCode_0, bool_0);
			case TypeCode.Int32:
				return smethod_12(string_2, (int)object_0, bool_0, bool_1);
			}
		}
		return smethod_9(int_0, string_2, object_0, typeCode, bool_0, countryCode_0, cultureInfo_0, bool_1);
	}

	internal static string smethod_17(double double_0, string string_2, string string_3)
	{
		return double_0.ToString(string_2);
	}
}
