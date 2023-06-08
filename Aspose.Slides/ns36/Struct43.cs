using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using ns33;
using ns40;

namespace ns36;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct43
{
	internal static readonly string string_0 = "MMM|DD|YYYY|M/|/M|D/|D\\\\|/D|Y/|/Y|-M|M-|-D|D-|-Y|Y-|MM|M/D|D/M|M-D|D-M|^D$|\\[H\\]|H:MM|MM:SS|Дк|ФВ|ИХ|К±|·Ц|Гл";

	internal static string smethod_0(object value, string custom, bool isCulture)
	{
		if (value == null)
		{
			return null;
		}
		TypeCode typeCode = Type.GetTypeCode(value.GetType());
		switch (typeCode)
		{
		default:
			try
			{
				switch (typeCode)
				{
				case TypeCode.Double:
					return smethod_5(custom, (double)value);
				default:
					return value.ToString();
				case TypeCode.DateTime:
					custom = custom.Replace("\\", null);
					return smethod_3(custom, (DateTime)value, isCulture);
				case TypeCode.Int32:
					return smethod_5(custom, (int)value);
				}
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
				return value.ToString();
			}
		case TypeCode.String:
			return (string)value;
		case TypeCode.Boolean:
			if (!(bool)value)
			{
				return "FALSE";
			}
			return "TRUE";
		}
	}

	private static string smethod_1(string rhv)
	{
		int length = rhv.Length;
		StringBuilder stringBuilder = new StringBuilder(length);
		int num = 0;
		while (num < length)
		{
			if (rhv[num] == 'm')
			{
				int i;
				for (i = num + 1; i < length && rhv[i] == 'm'; i++)
				{
				}
				char value = (((num <= 0 || !smethod_2(rhv[num - 1])) && (i >= length || !smethod_2(rhv[i]))) ? 'M' : 'm');
				stringBuilder.Append(value, i - num);
				num = i;
				continue;
			}
			if (rhv[num] == '_')
			{
				if (num != length - 1)
				{
					num++;
				}
			}
			else if (rhv[num] != '*')
			{
				if (rhv[num] == 'h')
				{
					stringBuilder.Append('H');
				}
				else
				{
					stringBuilder.Append(rhv[num]);
				}
			}
			num++;
		}
		if (stringBuilder.ToString().Equals("General"))
		{
			return "";
		}
		return stringBuilder.ToString();
	}

	private static bool smethod_2(char ch)
	{
		if (ch != 'h' && ch != 's')
		{
			return ch == ':';
		}
		return true;
	}

	private static string smethod_3(string custom, DateTime dateTimeValue, bool isCulture)
	{
		string[] array = custom.Split(';');
		if (array.Length == 1)
		{
			return smethod_4(custom, dateTimeValue, isCulture);
		}
		return smethod_4(array[0], dateTimeValue, isCulture);
	}

	private static string smethod_4(string custom, DateTime dateTimeValue, bool isCulture)
	{
		if (custom != null && !(custom == ""))
		{
			custom = smethod_1(custom);
			custom = custom.Replace("[HH]", "HH");
			int num = custom.IndexOf("[");
			if (num == -1)
			{
				if (isCulture)
				{
					return dateTimeValue.ToString(custom, DateTimeFormatInfo.InvariantInfo);
				}
				return dateTimeValue.ToString(custom);
			}
			int num2 = custom.IndexOf("]");
			if (num2 == -1)
			{
				return dateTimeValue.ToString();
			}
			custom = custom.Remove(num, num2 - num + 1);
			string text;
			if (isCulture)
			{
				text = dateTimeValue.ToString(custom, DateTimeFormatInfo.InvariantInfo);
			}
			else
			{
				text = dateTimeValue.ToString(custom);
				if (custom == "MMMMM")
				{
					text = text.Substring(0, 1);
				}
			}
			return text;
		}
		if (!isCulture)
		{
			return dateTimeValue.ToString();
		}
		return dateTimeValue.ToString(DateTimeFormatInfo.InvariantInfo);
	}

	private static string smethod_5(string custom, double doubleValue)
	{
		string text = custom;
		switch (text)
		{
		default:
			if (text.StartsWith("General"))
			{
				text = text.Replace("\\", null);
				return doubleValue + text.Substring(7);
			}
			return smethod_7(text, doubleValue, date1904: false);
		case null:
		case "":
		case "General":
			return doubleValue.ToString();
		}
	}

	private static string smethod_6(string custom, double doubleValue)
	{
		switch (custom)
		{
		default:
		{
			int num = custom.IndexOf("[");
			if (num == -1)
			{
				custom = smethod_1(custom);
				if (doubleValue == 0.0)
				{
					custom = custom.Replace("?", null);
				}
				return doubleValue.ToString(custom);
			}
			int num2 = custom.IndexOf("]");
			if (num2 == -1)
			{
				return doubleValue.ToString();
			}
			if (custom[num + 1] == '$')
			{
				if (num == 0)
				{
					string text = custom.Substring(2, num2 - 2);
					int num3 = text.IndexOf("-");
					if (num3 != -1)
					{
						text = text.Substring(0, num3);
					}
					string text2 = doubleValue.ToString(custom.Substring(num2 + 1));
					return text + text2;
				}
				if (custom[0] == '(' && custom[custom.Length - 1] == ')')
				{
					string pattern = "([[]\\$\\S*-\\S*[]])([ ]*)(\\S+)\\)";
					Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
					Match match = regex.Match(custom);
					GroupCollection groups = match.Groups;
					if (groups.Count == 1)
					{
						return "(" + doubleValue.ToString(custom.Substring(1, custom.Length - 2)) + ")";
					}
					string text3 = "";
					for (int i = 1; i < groups.Count; i++)
					{
						string value = groups[i].Value;
						text3 = ((value.IndexOf("$") == -1) ? ((!(value.Replace(" ", null) == "")) ? (text3 + doubleValue.ToString(value)) : (text3 + value)) : ((value.Length == 3 || value[2] == '-') ? (text3 + "$") : (text3 + value[2])));
					}
					return text3;
				}
				return doubleValue.ToString(custom.Substring(0, num)) + custom.Substring(num + 2, num2 - num - 2);
			}
			custom = custom.Remove(num, num2 - num + 1);
			return doubleValue.ToString(custom);
		}
		case null:
		case "":
		case "General":
			return doubleValue.ToString();
		}
	}

	private static string smethod_7(string custom, double doubleValue, bool date1904)
	{
		string[] array = custom.Split(';');
		if (array.Length == 1)
		{
			return smethod_8(custom, doubleValue, date1904);
		}
		if (custom.Length > 2 && custom[0] == '[')
		{
			string text = null;
			switch (custom[1])
			{
			case '<':
				text = custom[2] switch
				{
					'=' => "<=", 
					'>' => ">", 
					_ => "<", 
				};
				break;
			case '=':
				text = "=";
				break;
			case '>':
				text = ((custom[2] != '=') ? ">" : ">=");
				break;
			}
			if (text != null)
			{
				int num = custom.IndexOf(']');
				string text2 = custom.Substring(text.Length + 1, num - (text.Length + 1));
				if (smethod_12(text2))
				{
					try
					{
						double doubleValue2 = Convert.ToDouble(text2, CultureInfo.InvariantCulture);
						if (smethod_13(doubleValue, doubleValue2, text))
						{
							return smethod_8(array[0], doubleValue, date1904);
						}
						return smethod_8(array[1], doubleValue, date1904);
					}
					catch (Exception ex)
					{
						Class1165.smethod_28(ex);
					}
				}
			}
		}
		if (doubleValue > 0.0)
		{
			return smethod_8(array[0], doubleValue, date1904);
		}
		if (doubleValue < 0.0)
		{
			return smethod_8(array[1], Math.Abs(doubleValue), date1904);
		}
		if (array.Length < 3)
		{
			return smethod_8(array[0], doubleValue, date1904);
		}
		return smethod_8(array[2], doubleValue, date1904);
	}

	private static string smethod_8(string custom, double doubleValue, bool date1904)
	{
		if (custom != null && !(custom == ""))
		{
			Match match = Regex.Match(custom, "(^\\?+$)|(^\\?+/\\?+$)");
			if (match.Success)
			{
				if (match.Groups[1].Success)
				{
					return doubleValue.ToString("0");
				}
				return doubleValue.ToString(custom);
			}
			string text = custom;
			custom = custom.Replace("_(", null);
			custom = smethod_11(custom, Enum142.const_1);
			int num = custom.IndexOf("[");
			if (num == -1)
			{
				if (doubleValue == 0.0)
				{
					custom = custom.Replace("?", null);
				}
				string input = smethod_9(custom);
				if (Regex.IsMatch(input, string_0, RegexOptions.IgnoreCase))
				{
					return smethod_15(doubleValue, date1904).ToString(custom);
				}
				if (!(custom.ToUpper() == "GENERAL") && !(custom == "@"))
				{
					if (custom.IndexOf("\"'") != -1)
					{
						return doubleValue.ToString(custom);
					}
					num = custom.IndexOf("\"");
					if (num != -1)
					{
						StringBuilder stringBuilder = new StringBuilder();
						int num2 = 0;
						for (int i = 0; i < custom.Length; i++)
						{
							if (custom[i] != '"')
							{
								continue;
							}
							if (num2 < i)
							{
								stringBuilder.Append(smethod_16(custom.Substring(num2, i - num2), doubleValue));
							}
							for (i++; i < custom.Length; i++)
							{
								if (custom[i] != '"')
								{
									stringBuilder.Append(custom[i]);
									continue;
								}
								num2 = i + 1;
								break;
							}
						}
						if (num2 < custom.Length)
						{
							if (doubleValue < 0.0)
							{
								stringBuilder.Insert(0, '-');
								stringBuilder.Append(smethod_16(custom.Substring(num2), 0.0 - doubleValue));
							}
							else
							{
								stringBuilder.Append(smethod_16(custom.Substring(num2), doubleValue));
							}
						}
						return stringBuilder.ToString();
					}
					return smethod_16(custom, doubleValue);
				}
				return doubleValue.ToString();
			}
			int num3 = custom.IndexOf("]");
			if (num3 == -1)
			{
				return doubleValue.ToString();
			}
			if (custom[num + 1] == '$')
			{
				if (num == 0)
				{
					string text2 = custom.Substring(2, num3 - 2);
					int num4 = text2.IndexOf("-");
					if (num4 != -1)
					{
						text2 = text2.Substring(0, num4);
					}
					custom = custom.Substring(num3 + 1);
					if (custom.ToLower() == "general")
					{
						return doubleValue.ToString();
					}
					custom = smethod_11(custom, Enum142.const_0);
					custom = custom.Replace("?", "");
					int num5 = smethod_10(custom, ',');
					if (num5 > 1)
					{
						doubleValue /= (double)num5;
					}
					string text3 = doubleValue.ToString(custom);
					return text2 + text3;
				}
				if (custom[0] == '(' && custom[custom.Length - 1] == ')')
				{
					string pattern = "([[]\\$\\S*-\\S*[]])([ ]*)(\\S+)\\)";
					Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
					Match match2 = regex.Match(custom);
					GroupCollection groups = match2.Groups;
					if (groups.Count == 1)
					{
						return "(" + doubleValue.ToString(custom.Substring(1, custom.Length - 2)) + ")";
					}
					string text4 = "";
					for (int j = 1; j < groups.Count; j++)
					{
						string value = groups[j].Value;
						if (j != 1 || value[1] != '$')
						{
							text4 = ((!(value.Replace(" ", null) == "")) ? (text4 + doubleValue.ToString(value)) : (text4 + value));
						}
						else if (value.Length > 3 && value[3] == '-')
						{
							text4 += value[2];
						}
					}
					return "(" + text4 + ")";
				}
				StringBuilder stringBuilder2 = new StringBuilder();
				int num6 = 0;
				string pattern2 = "[[]\\$\\S*-\\S*[]]";
				MatchCollection matchCollection = Regex.Matches(custom, pattern2, RegexOptions.IgnoreCase);
				foreach (Match item in matchCollection)
				{
					if (item.Success)
					{
						num = item.Index;
						int num7 = item.Length + num;
						stringBuilder2.Append(custom.Substring(num6, num));
						for (int k = num + 2; k < num7 && custom[k] != '-'; k++)
						{
							stringBuilder2.Append(custom[k]);
						}
						num6 = num7;
					}
				}
				if (num6 != 0)
				{
					if (num6 < custom.Length - 1 && custom[num6] == '*')
					{
						num6++;
					}
					int num8 = custom.Length - num6;
					if (custom.EndsWith("_-"))
					{
						num8 -= 2;
					}
					stringBuilder2.Append(custom.Substring(num6, num8));
				}
				if (stringBuilder2.Length != 0)
				{
					return doubleValue.ToString(stringBuilder2.ToString());
				}
				return doubleValue.ToString(custom.Substring(0, num)) + custom.Substring(num + 2, num3 - num - 2);
			}
			custom = custom.Remove(num, num3 - num + 1).Trim();
			num = custom.IndexOf("[");
			num3 = custom.IndexOf("]");
			if (num != -1 && custom[num + 1] == '$')
			{
				if (num == 0)
				{
					string text5 = custom.Substring(2, num3 - 2);
					int num9 = text5.IndexOf("-");
					if (num9 != -1)
					{
						text5 = text5.Substring(0, num9);
					}
					custom = custom.Substring(num3 + 1);
					if (custom[0] == '*')
					{
						custom = custom.Substring(1).Trim();
					}
					if (custom.EndsWith("_"))
					{
						custom = custom.Substring(0, custom.Length - 1);
					}
					if (string.Compare("M", custom, ignoreCase: true) == 0)
					{
						int month = smethod_15(doubleValue, date1904).Month;
						if (text.StartsWith("[DBNum1]"))
						{
							switch (month)
							{
							case 1:
								return "Т»";
							case 2:
								return "¶ю";
							case 3:
								return "Иэ";
							case 4:
								return "ЛД";
							case 5:
								return "Ое";
							case 6:
								return "Бщ";
							case 7:
								return "ЖЯ";
							case 8:
								return "°Л";
							case 9:
								return "ѕЕ";
							case 10:
								return "К®";
							case 11:
								return "К®Т»";
							case 12:
								return "К®¶ю";
							}
						}
						return month.ToString();
					}
					string text6 = doubleValue.ToString(custom);
					if (text6.EndsWith("_)"))
					{
						text6 = text6.Substring(0, text6.Length - 2);
					}
					return text5 + text6;
				}
				if (custom[0] == '(' && custom[custom.Length - 1] == ')')
				{
					string pattern3 = "([[]\\$\\S*-\\S*[]])([ ]*)(\\S+)\\)";
					Regex regex2 = new Regex(pattern3, RegexOptions.IgnoreCase);
					Match match4 = regex2.Match(custom);
					GroupCollection groups2 = match4.Groups;
					if (groups2.Count == 1)
					{
						return "(" + doubleValue.ToString(custom.Substring(1, custom.Length - 2)) + ")";
					}
					string text7 = "";
					for (int l = 1; l < groups2.Count; l++)
					{
						string value2 = groups2[l].Value;
						text7 = ((value2.IndexOf("$") == -1) ? ((!(value2.Replace(" ", null) == "")) ? (text7 + doubleValue.ToString(value2)) : (text7 + value2)) : ((value2.Length == 3 || value2[2] == '-') ? (text7 + "$") : (text7 + value2[2])));
					}
					return "(" + text7 + ")";
				}
				return doubleValue.ToString(custom.Substring(0, num)) + custom.Substring(num + 2, num3 - num - 2);
			}
			int num10 = smethod_10(custom, ',');
			if (num10 > 1)
			{
				doubleValue /= (double)num10;
			}
			return doubleValue.ToString(custom);
		}
		return "";
	}

	private static string smethod_9(string rhv)
	{
		int length = rhv.Length;
		StringBuilder stringBuilder = new StringBuilder(length);
		for (int i = 0; i < length; i++)
		{
			char c = rhv[i];
			if (c == '"')
			{
				for (i++; i < length && rhv[i] != '"'; i++)
				{
				}
			}
			else
			{
				stringBuilder.Append(rhv[i]);
			}
		}
		return stringBuilder.ToString();
	}

	private static int smethod_10(string rhv, char decimalPoint)
	{
		int length = rhv.Length;
		int num = 1;
		for (int num2 = length - 1; num2 >= 0; num2--)
		{
			char c = rhv[num2];
			switch (c)
			{
			default:
			{
				if (c != decimalPoint)
				{
					break;
				}
				bool flag = false;
				num = 1000;
				num2--;
				while (num2 >= 0)
				{
					c = rhv[num2];
					char c2 = c;
					if (c2 != '#' && c2 != '0')
					{
						if (c == decimalPoint)
						{
							num *= 1000;
							flag = true;
						}
						else
						{
							flag = false;
						}
						if (flag)
						{
							num2--;
							continue;
						}
						num2++;
						num = 1;
						break;
					}
					return num;
				}
				break;
			}
			case '"':
				num2--;
				while (num2 >= 0 && rhv[num2] != '"')
				{
					num2--;
				}
				break;
			case '#':
			case '0':
				return 1;
			}
		}
		return num;
	}

	private static string smethod_11(string rhv, Enum142 code)
	{
		int length = rhv.Length;
		StringBuilder stringBuilder = new StringBuilder(length);
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
					stringBuilder.Append(rhv[i]);
					if (rhv[i] == '"')
					{
						break;
					}
				}
				goto case '*';
			case 'J':
				if (code == Enum142.const_8)
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
					case ' ':
					case '\'':
					case '-':
					case '/':
						break;
					}
				}
				goto case '*';
			case 'T':
				if (code == Enum142.const_8)
				{
					stringBuilder.Append('d');
				}
				else
				{
					stringBuilder.Append('T');
				}
				goto case '*';
			case 'D':
			case 'd':
				stringBuilder.Append('d');
				goto case '*';
			case 'G':
			case 'g':
				if (code == Enum142.const_6)
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
						goto case '*';
					}
				}
				if (rhv.Length > i + 4 && rhv[i + 1] == 'M' && rhv[i + 2] == '/' && rhv[i + 3] == 'P' && rhv[i + 4] == 'M')
				{
					if (code == Enum142.const_8)
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
				else if (code == Enum142.const_6)
				{
					stringBuilder.Append('y');
				}
				else
				{
					stringBuilder.Append(rhv[i]);
				}
				goto case '*';
			default:
				stringBuilder.Append(rhv[i]);
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
				char value = (((i <= 0 || !smethod_2(rhv[i - 1])) && (j >= length || !smethod_2(rhv[j]))) ? 'M' : 'm');
				stringBuilder.Append(value, j - i);
				i = j;
				break;
			}
			}
		}
		string text = stringBuilder.ToString();
		if (code == Enum142.const_8 && text.StartsWith("[$-F800]"))
		{
			text = text.Replace("MMMM\\ dd\\,", "dd. MMMM");
		}
		return text;
	}

	private static bool smethod_12(string text)
	{
		if (text != null && !(text == ""))
		{
			text = text.Trim();
			if (text.Length == 0)
			{
				return false;
			}
			int num = 0;
			int num2 = 0;
			bool result = false;
			char c = Class807.smethod_0().NumberFormat.NumberDecimalSeparator[0];
			int num3 = -1;
			int num4 = 0;
			while (true)
			{
				if (num4 < text.Length)
				{
					if (text[num4] >= '0' && text[num4] <= '9')
					{
						result = true;
					}
					else if (text[num4] != c && text[num4] != '.')
					{
						switch (text[num4])
						{
						case 'E':
							if (text.Length != 1 && num4 != 0 && num4 <= text.Length - 3)
							{
								if (text[num4 + 1] == '+' || text[num4 + 1] == '-')
								{
									num2++;
									if (num2 <= 1)
									{
										num4++;
										break;
									}
									return false;
								}
								return false;
							}
							return false;
						default:
							if (num == 0)
							{
								if (text[num4] == CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0])
								{
									if (num3 == -1 || num4 - num3 > 3)
									{
										num3 = num4;
										if (num4 + 3 >= text.Length)
										{
											return false;
										}
										break;
									}
									return false;
								}
								return false;
							}
							return false;
						case '+':
						case '-':
							if (num4 != 0 || text.Length == 1)
							{
								return false;
							}
							break;
						}
					}
					else
					{
						num++;
						if (num > 1 || text.Length == 1)
						{
							break;
						}
					}
					num4++;
					continue;
				}
				return result;
			}
			return false;
		}
		return false;
	}

	private static bool smethod_13(double doubleValue1, double doubleValue2, string opCode)
	{
		switch (opCode)
		{
		case "<>":
			if (Math.Abs(doubleValue1 - doubleValue2) <= double.Epsilon)
			{
				return false;
			}
			return true;
		case ">=":
			if (!(doubleValue1 > doubleValue2) && Math.Abs(doubleValue1 - doubleValue2) > 1E-16)
			{
				return false;
			}
			return true;
		case "<=":
			if (!(doubleValue1 < doubleValue2) && Math.Abs(doubleValue1 - doubleValue2) > 1E-16)
			{
				return false;
			}
			return true;
		case ">":
			if (smethod_14(doubleValue1, doubleValue2))
			{
				return false;
			}
			if (doubleValue1 > doubleValue2)
			{
				return true;
			}
			return false;
		case "<":
			if (smethod_14(doubleValue1, doubleValue2))
			{
				return false;
			}
			if (doubleValue1 < doubleValue2)
			{
				return true;
			}
			return false;
		case "=":
			if (smethod_14(doubleValue1, doubleValue2))
			{
				return true;
			}
			if (Math.Abs(doubleValue1 - doubleValue2) <= 1E-16)
			{
				return true;
			}
			return false;
		default:
			return false;
		}
	}

	private static bool smethod_14(double a, double b)
	{
		double num = Math.Abs(a - b);
		if (num < double.Epsilon)
		{
			return true;
		}
		if (num < 0.0001 && Math.Abs(a) < 7.922816251426434E+28)
		{
			return (decimal)a == (decimal)b;
		}
		return a == b;
	}

	private static DateTime smethod_15(double doubleValue, bool date1904)
	{
		if (doubleValue > 2958465.99)
		{
			return DateTime.MaxValue;
		}
		if (date1904)
		{
			doubleValue += 1462.0;
		}
		if (doubleValue < 60.0)
		{
			doubleValue += 1.0;
		}
		return DateTime.FromOADate(doubleValue);
	}

	private static string smethod_16(string custom, double doubleValue)
	{
		if (!custom.EndsWith(",") && !custom.EndsWith(",)"))
		{
			int num = 0;
			int num2 = custom.Length - 1;
			int num3;
			for (num3 = num2; num3 >= 0; num3--)
			{
				char c = custom[num3];
				if (!char.IsDigit(c))
				{
					switch (c)
					{
					case ',':
						num++;
						continue;
					default:
						continue;
					case '#':
					case '.':
						break;
					}
				}
				break;
			}
			if (num > 0)
			{
				doubleValue /= Math.Pow(1000.0, num);
				custom = ((num3 >= 0) ? custom.Remove(num3 + 1, num) : custom.Substring(num));
			}
		}
		else
		{
			int num4 = 0;
			int num5 = custom.Length - 1;
			if (custom[num5] == ')')
			{
				num5--;
			}
			int num6 = num5;
			while (num6 >= 0 && custom[num6] == ',')
			{
				num4++;
				num6--;
			}
			doubleValue /= Math.Pow(1000.0, num4);
			custom = custom.Remove(num5 - num4 + 1, num4);
		}
		if (custom.IndexOf("/?") == -1 && custom.IndexOf("?/") == -1)
		{
			if (custom.IndexOf('"') != -1)
			{
				return doubleValue.ToString(custom);
			}
			if (custom.IndexOf('E') == -1 && custom.IndexOf('e') == -1)
			{
				if (custom.StartsWith("\\"))
				{
					custom = custom.Replace("\\", null);
				}
				Regex regex = new Regex("^([a-z|A-Z|(]*)([^a-z|A-Z]+)([a-z|A-Z|)]*)$");
				Match match = regex.Match(custom);
				if (match.Success)
				{
					return match.Groups[1].Value + doubleValue.ToString(match.Groups[2].Value.Replace("?", null)) + match.Groups[3].Value;
				}
				return doubleValue.ToString(custom);
			}
			return doubleValue.ToString(custom);
		}
		return smethod_17(custom, doubleValue);
	}

	private static string smethod_17(string custom, double doubleValue)
	{
		int num = custom.IndexOf(' ');
		string text = null;
		double num2 = Math.Floor(doubleValue);
		double num3 = doubleValue - num2;
		if (num != -1)
		{
			text = custom.Substring(0, num);
			custom = custom.Substring(num + 1);
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (num2 == doubleValue)
		{
			if (text != null)
			{
				return doubleValue.ToString(text);
			}
			return doubleValue.ToString("0");
		}
		if (text != null)
		{
			stringBuilder.Append(num2.ToString(text));
			stringBuilder.Append(' ');
			doubleValue -= num2;
		}
		string[] array = custom.Split('/');
		if (array.Length == 1)
		{
			return stringBuilder.ToString();
		}
		int num4 = 0;
		int num5 = 2;
		if (array[1].IndexOf('?') == -1)
		{
			num5 = int.Parse(array[1]);
			num4 = (int)(doubleValue * (double)num5 + 0.5);
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
		num4 = (int)(doubleValue * (double)num5 + 0.5);
		if (num4 == 0)
		{
			return "0";
		}
		stringBuilder.Append(num4);
		stringBuilder.Append("/");
		stringBuilder.Append(num5);
		return stringBuilder.ToString();
	}
}
