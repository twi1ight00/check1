using System.Collections.Generic;
using System.Text;
using Aspose.Cells;
using ns1;

namespace ns12;

internal class Class740
{
	internal static object[][] smethod_0(object[][] object_0)
	{
		object[][] array = new object[object_0.Length][];
		int num = object_0[0].Length;
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new object[num];
			if (object_0[i] == null)
			{
				for (int j = 0; j < num; j++)
				{
					array[i][j] = false;
				}
				continue;
			}
			for (int k = 0; k < num; k++)
			{
				if (object_0[i][k] != null && object_0[i][k] is ErrorType)
				{
					array[i][k] = smethod_1((ErrorType)object_0[i][k]);
				}
				else
				{
					array[i][k] = false;
				}
			}
		}
		return array;
	}

	internal static bool smethod_1(ErrorType errorType_0)
	{
		switch (errorType_0)
		{
		default:
			return false;
		case ErrorType.Div:
		case ErrorType.NA:
		case ErrorType.Name:
		case ErrorType.Null:
		case ErrorType.Number:
		case ErrorType.Ref:
		case ErrorType.Value:
			return true;
		}
	}

	internal static double smethod_2(Cell cell_0)
	{
		if (cell_0 == null)
		{
			return 0.0;
		}
		Style style = cell_0.method_28();
		if (style.method_46() != null && style.method_46() != "")
		{
			string text = style.method_46();
			string[] array = text.Split(';');
			text = array[0];
			int num = text.LastIndexOf(']');
			if (num != -1)
			{
				text = text.Substring(num + 1);
			}
			if (text.IndexOf('(') != -1 && text.IndexOf(')') != -1)
			{
				return 1.0;
			}
		}
		else
		{
			switch (style.Number)
			{
			case 5:
			case 6:
			case 7:
			case 8:
			case 37:
			case 38:
			case 39:
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
				return 1.0;
			}
		}
		return 0.0;
	}

	internal static bool smethod_3(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_28 == null)
			{
				Class1742.dictionary_28 = new Dictionary<string, int>(10)
				{
					{ "black", 0 },
					{ "whiter", 1 },
					{ "red", 2 },
					{ "orange", 3 },
					{ "yellow", 4 },
					{ "green", 5 },
					{ "blue", 6 },
					{ "pink", 7 },
					{ "purple", 8 },
					{ "gold", 9 }
				};
			}
			if (Class1742.dictionary_28.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
					return true;
				}
			}
		}
		return false;
	}

	internal static double smethod_4(Cell cell_0)
	{
		if (cell_0 == null)
		{
			return 0.0;
		}
		Style style = cell_0.method_28();
		if (style.method_46() != null && style.method_46() != "")
		{
			string text = style.method_46();
			string[] array = text.Split(';');
			if (array.Length >= 2)
			{
				text = array[1];
				if (text == null || text == "")
				{
					return 0.0;
				}
				if (text[0] == '[')
				{
					int num = text.IndexOf(']');
					if (num != -1)
					{
						text = text.Substring(1, num - 1);
						if (smethod_3(text.ToLower()))
						{
							return 1.0;
						}
						return 0.0;
					}
				}
			}
		}
		else
		{
			switch (style.Number)
			{
			case 6:
			case 8:
			case 38:
			case 40:
				return 1.0;
			}
		}
		return 0.0;
	}

	internal static double smethod_5(Cell cell_0)
	{
		if (cell_0 == null)
		{
			return 8.0;
		}
		return (int)(cell_0.method_4().GetColumnWidth(cell_0.Column) + 0.5);
	}

	internal static string smethod_6(Cell cell_0)
	{
		if (cell_0 == null)
		{
			return "b";
		}
		return cell_0.Type switch
		{
			CellValueType.IsNull => "b", 
			CellValueType.IsString => "l", 
			_ => "v", 
		};
	}

	internal static string smethod_7(Cell cell_0)
	{
		if (cell_0 == null)
		{
			return "";
		}
		CellValueType type = cell_0.Type;
		if (type == CellValueType.IsString)
		{
			switch (cell_0.method_28().HorizontalAlignment)
			{
			default:
				return "";
			case TextAlignmentType.Center:
			case TextAlignmentType.CenterAcross:
				return "^";
			case TextAlignmentType.Fill:
				return "\\";
			case TextAlignmentType.Distributed:
			case TextAlignmentType.General:
			case TextAlignmentType.Justify:
			case TextAlignmentType.Left:
				return "'";
			case TextAlignmentType.Right:
				return "\"";
			}
		}
		return "";
	}

	internal static object smethod_8(Cell cell_0)
	{
		return cell_0?.Value;
	}

	internal static double Protect(Cell cell_0)
	{
		if (cell_0 != null && !cell_0.method_28().IsLocked)
		{
			return 0.0;
		}
		return 1.0;
	}

	internal static bool smethod_9(char char_0)
	{
		switch (char_0)
		{
		default:
			return false;
		case '$':
		case '£':
		case '€':
		case '￥':
			return true;
		}
	}

	internal static bool smethod_10(string string_0, int int_0)
	{
		int num = string_0.IndexOf('[', int_0);
		if (num == -1)
		{
			return false;
		}
		int num2 = string_0.IndexOf(']', num);
		if (num == -1)
		{
			return false;
		}
		string text = string_0.Substring(num + 1, num2 - num - 1);
		return smethod_3(text.ToLower());
	}

	internal static string smethod_11(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_29 == null)
			{
				Class1742.dictionary_29 = new Dictionary<string, int>(24)
				{
					{ "mdyy", 0 },
					{ "mdyyyy", 1 },
					{ "mdyyhmm", 2 },
					{ "mdyyhmmam/pm", 3 },
					{ "mdyyhmma/p", 4 },
					{ "mmddyy", 5 },
					{ "dmmmyy", 6 },
					{ "ddmmmyy", 7 },
					{ "dddmyyyy", 8 },
					{ "dmyy", 9 },
					{ "yymd", 10 },
					{ "yymdhmm", 11 },
					{ "dmmm", 12 },
					{ "ddmmm", 13 },
					{ "ddddmmmmdyyyy", 14 },
					{ "ddddmmddyyyy", 15 },
					{ "mmmyy", 16 },
					{ "mmdd", 17 },
					{ "hmmam/pm", 18 },
					{ "hmma/p", 19 },
					{ "hmmssam/pm", 20 },
					{ "hmmss a/p", 21 },
					{ "hmm", 22 },
					{ "hmmss", 23 }
				};
			}
			if (Class1742.dictionary_29.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
					return "D4";
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					return "D1";
				case 12:
				case 13:
				case 14:
				case 15:
					return "D2";
				case 16:
					return "D3";
				case 17:
					return "D5";
				case 18:
				case 19:
					return "D7";
				case 20:
				case 21:
					return "D6";
				case 22:
					return "D9";
				case 23:
					return "D8";
				}
			}
		}
		return "G";
	}

	internal static string smethod_12(string string_0)
	{
		string_0 = string_0.ToLower();
		int length = string_0.Length;
		int num = string_0.Length;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		int num2 = -1;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		bool flag8 = false;
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < length; i++)
		{
			switch (string_0[i])
			{
			case ';':
				num = i;
				flag7 = smethod_10(string_0, i + 1);
				i = string_0.Length;
				break;
			case '"':
			{
				int num3 = i;
				for (i++; i < length; i++)
				{
					if (string_0[i] == '"')
					{
						if (!flag && i == num3 + 2)
						{
							flag = smethod_9(string_0[num3 + 1]);
						}
						break;
					}
				}
				break;
			}
			case '%':
				flag2 = true;
				break;
			case '\'':
			{
				int num4 = i;
				for (i++; i < length; i++)
				{
					if (string_0[i] == '\'')
					{
						if (!flag && i == num4 + 2)
						{
							flag = smethod_9(string_0[num4 + 1]);
						}
						break;
					}
				}
				break;
			}
			case '(':
				flag5 = true;
				break;
			case '*':
				i++;
				break;
			case ',':
				flag3 = true;
				break;
			case '.':
				num2 = 0;
				break;
			case '/':
				if (i + 1 < string_0.Length)
				{
					switch (string_0[i + 1])
					{
					case '#':
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
					case '?':
						return "G";
					}
				}
				break;
			case '#':
			case '0':
				flag6 = true;
				if (num2 >= 0)
				{
					num2++;
				}
				break;
			case '[':
				for (i++; i < length && string_0[i] != ']'; i++)
				{
				}
				break;
			case '\\':
				if (i + 1 < string_0.Length)
				{
					char c = string_0[i + 1];
					if (c == '"' || c == '\'')
					{
						i++;
					}
				}
				break;
			case '_':
				i++;
				break;
			case 'a':
				if (i + 4 < string_0.Length && string_0[i + 1] == 'm' && string_0[i + 2] == '/' && string_0[i + 3] == 'p' && string_0[i + 4] == 'm')
				{
					stringBuilder.Append(string_0[i]);
					stringBuilder.Append(string_0[i + 1]);
					stringBuilder.Append(string_0[i + 2]);
					stringBuilder.Append(string_0[i + 3]);
					stringBuilder.Append(string_0[i + 4]);
					i += 4;
				}
				else if (i + 2 < string_0.Length && string_0[i + 1] == '/' && string_0[i + 2] == 'p')
				{
					stringBuilder.Append(string_0[i]);
					stringBuilder.Append(string_0[i + 1]);
					stringBuilder.Append(string_0[i + 2]);
					i += 2;
				}
				break;
			case 'd':
				stringBuilder.Append(string_0[i]);
				break;
			case 'e':
				if (i + 1 < string_0.Length)
				{
					switch (string_0[i + 1])
					{
					case '+':
					case '-':
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
						flag4 = true;
						i = string_0.Length - 1;
						break;
					}
				}
				break;
			case 'g':
				if (i + 6 < string_0.Length && string_0[i + 1] == 'e' && string_0[i + 2] == 'n' && string_0[i + 3] == 'e' && string_0[i + 4] == 'r' && string_0[i + 5] == 'a' && string_0[i + 6] == 'l')
				{
					flag8 = true;
					i += 6;
				}
				break;
			case 'h':
			case 'm':
			case 's':
			case 'y':
				stringBuilder.Append(string_0[i]);
				break;
			case '$':
			case '£':
			case '€':
			case '￥':
				flag = true;
				break;
			}
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		if (stringBuilder.Length > 1)
		{
			stringBuilder2.Append(smethod_11(stringBuilder.ToString()));
		}
		else
		{
			if (num == 0)
			{
				return "H";
			}
			if (flag8 && !flag6)
			{
				stringBuilder2.Append("G");
			}
			if (flag6)
			{
				if (flag2)
				{
					stringBuilder2.Append("P");
				}
				else if (flag4)
				{
					stringBuilder2.Append("S");
				}
				else if (flag)
				{
					stringBuilder2.Append("C");
				}
				else if (flag3)
				{
					stringBuilder2.Append(",");
				}
				else
				{
					stringBuilder2.Append("F");
				}
				if (num2 > 0)
				{
					stringBuilder2.Append(num2);
				}
				else
				{
					stringBuilder2.Append(0);
				}
			}
		}
		if (flag7)
		{
			stringBuilder2.Append("-");
		}
		if (flag5)
		{
			stringBuilder2.Append("()");
		}
		if (stringBuilder2.Length > 0)
		{
			return stringBuilder2.ToString();
		}
		return "G";
	}

	internal static string Format(Cell cell_0)
	{
		if (cell_0 == null)
		{
			return "G";
		}
		Style style = cell_0.method_28();
		if (style == null)
		{
			return "G";
		}
		string text = style.method_46();
		if (text != null && text != "")
		{
			return smethod_12(text);
		}
		return style.method_44() switch
		{
			0 => "G", 
			1 => "F0", 
			2 => "F2", 
			3 => ",0", 
			4 => ",2", 
			5 => "C0", 
			6 => "C0-", 
			7 => "C2", 
			8 => "C2-", 
			9 => "P0", 
			10 => "P2", 
			11 => "S2", 
			14 => "D4", 
			15 => "D1", 
			16 => "D2", 
			17 => "D3", 
			18 => "D7", 
			19 => "D6", 
			20 => "D9", 
			21 => "D8", 
			22 => "D4", 
			_ => "G", 
		};
	}
}
