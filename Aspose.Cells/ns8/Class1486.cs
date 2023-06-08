using System.Collections;
using System.Text;
using Aspose.Cells;
using ns16;
using ns2;
using ns50;

namespace ns8;

internal class Class1486
{
	internal static Hashtable hashtable_0 = new Hashtable();

	internal static bool smethod_0(Style style_0, Style style_1)
	{
		if (style_0 == null)
		{
			return false;
		}
		if ((style_0.ForegroundColor.ToArgb() & 0xFFFFFF) == (style_1.ForegroundColor.ToArgb() & 0xFFFFFF) && style_0.Pattern == BackgroundType.None)
		{
			if (style_0.method_4() != null)
			{
				if (style_0.Borders[BorderType.TopBorder].LineStyle == CellBorderType.None && style_0.Borders[BorderType.BottomBorder].LineStyle == CellBorderType.None && style_0.Borders[BorderType.LeftBorder].LineStyle == CellBorderType.None)
				{
					return style_0.Borders[BorderType.RightBorder].LineStyle != CellBorderType.None;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	internal static string smethod_1(int int_0, int int_1)
	{
		StringBuilder stringBuilder = new StringBuilder(int_1);
		string text = int_0.ToString();
		stringBuilder.Append(text);
		for (int i = 0; i < int_1 - text.Length; i++)
		{
			stringBuilder.Insert(0, '0');
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_2(string string_0)
	{
		if (string_0 == null)
		{
			return null;
		}
		if (string_0.Length == 0)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder(string_0.Length);
		foreach (char c in string_0)
		{
			string text = smethod_3(c);
			if (text != null)
			{
				stringBuilder.Append(text);
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	private static string smethod_3(char char_0)
	{
		return char_0 switch
		{
			'\r' => "&#13;", 
			'\n' => "&#10;", 
			'<' => "&lt;", 
			'>' => "&gt;", 
			'&' => "&amp;", 
			'"' => "&quot;", 
			_ => null, 
		};
	}

	private static string smethod_4(char char_0)
	{
		return char_0 switch
		{
			'\r' => "&#13;", 
			'\n' => "&#10;", 
			'<' => "&lt;", 
			'>' => "&gt;", 
			'&' => "&amp;", 
			' ' => "&nbsp;", 
			'"' => "&quot;", 
			_ => null, 
		};
	}

	private static string smethod_5(char char_0)
	{
		switch (char_0)
		{
		default:
			return null;
		case ' ':
		case '#':
		case '%':
		case '&':
		case '+':
		case '/':
		case '=':
		case '?':
			return "_";
		}
	}

	internal static string smethod_6(string string_0)
	{
		if (string_0 == null)
		{
			return null;
		}
		if (string_0.Length == 0)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder(string_0.Length);
		foreach (char c in string_0)
		{
			string text = smethod_4(c);
			if (text != null)
			{
				stringBuilder.Append(text);
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_7(string string_0)
	{
		if (string_0 == null)
		{
			return null;
		}
		if (string_0.Length == 0)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder(string_0.Length);
		foreach (char c in string_0)
		{
			string text = smethod_5(c);
			if (text != null)
			{
				stringBuilder.Append(text);
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	internal static string[] smethod_8(Cell cell_0)
	{
		string[] array = new string[3];
		switch (cell_0.Type)
		{
		case CellValueType.IsBool:
			array[0] = "bool";
			array[1] = (cell_0.BoolValue ? "TRUE" : "FALSE");
			array[2] = array[1];
			break;
		case CellValueType.IsError:
			array[0] = "err";
			array[1] = "#VALUE!";
			if (cell_0.Value != null)
			{
				array[1] = cell_0.Value.ToString();
			}
			array[2] = array[1];
			break;
		case CellValueType.IsDateTime:
		case CellValueType.IsNumeric:
		{
			array[0] = "num";
			array[1] = cell_0.StringValue;
			Style style = cell_0.method_32();
			if (style.method_44() != 0 || (style.method_46() != null && style.method_46() != ""))
			{
				array[2] = Class1618.smethod_79(cell_0.DoubleValue);
			}
			break;
		}
		case CellValueType.IsString:
		case CellValueType.IsUnknown:
			array[0] = "str";
			array[1] = cell_0.StringValue;
			array[2] = array[1];
			break;
		}
		return array;
	}

	internal static string smethod_9(FontUnderlineType fontUnderlineType_0)
	{
		return fontUnderlineType_0 switch
		{
			FontUnderlineType.None => "", 
			FontUnderlineType.Single => "text-decoration:underline;", 
			FontUnderlineType.Double => "text-decoration:underline; mso-text-underline:double;", 
			FontUnderlineType.Accounting => "text-decoration:underline; ms-text-underline:single-accounting;", 
			FontUnderlineType.DoubleAccounting => "text-decoration:underline; mso-text-underline:double-accounting;", 
			_ => "", 
		};
	}

	internal static string smethod_10(TextAlignmentType textAlignmentType_0)
	{
		return textAlignmentType_0 switch
		{
			TextAlignmentType.Center => "text-align:center", 
			TextAlignmentType.CenterAcross => "text-align:center-across", 
			TextAlignmentType.Distributed => "text-align:distributed", 
			TextAlignmentType.Fill => "text-align:fill", 
			TextAlignmentType.General => "text-align:general", 
			TextAlignmentType.Justify => "text-align:justify", 
			TextAlignmentType.Left => "text-align:left", 
			TextAlignmentType.Right => "text-align:right", 
			_ => null, 
		};
	}

	internal static string smethod_11(TextAlignmentType textAlignmentType_0)
	{
		return textAlignmentType_0 switch
		{
			TextAlignmentType.Top => "vertical-align:top", 
			TextAlignmentType.Bottom => "vertical-align:bottom", 
			TextAlignmentType.Center => "vertical-align:middle", 
			TextAlignmentType.Distributed => "vertical-align:distributed", 
			TextAlignmentType.Justify => "vertical-align:justify", 
			_ => "", 
		};
	}

	internal static long smethod_12(int int_0)
	{
		return int_0 * 32;
	}

	internal static bool smethod_13(WorksheetCollection sheets, Hyperlink href, out string sheetName, out CellArea ca)
	{
		if (href.method_5(sheets) == 2)
		{
			try
			{
				string text = href.Address;
				if (text.IndexOf('!') == -1)
				{
					for (int i = 0; i < sheets.Names.Count; i++)
					{
						Name name = sheets.Names[i];
						text = name.Text;
						if (name.Text.Equals(href.Address))
						{
							text = name.RefersTo;
						}
					}
				}
				string[] array = text.Split('!');
				if (array.Length == 2 && array[0] != null && array[0] != "" && array[1] != null && array[1] != "" && Class1677.smethod_23(array[1]))
				{
					sheetName = array[0];
					char[] trimChars = new char[2] { '\'', '=' };
					sheetName = sheetName.Trim(trimChars);
					ca = Class1618.smethod_17(array[1]);
					return true;
				}
			}
			catch
			{
			}
		}
		sheetName = null;
		ca = default(CellArea);
		return false;
	}

	internal static string smethod_14(CellArea cellArea_0)
	{
		return "#RANGE!" + Class1618.smethod_15(cellArea_0);
	}

	internal static string smethod_15(string string_0)
	{
		if (string_0 != null && string_0.Length != 0)
		{
			StringBuilder stringBuilder = new StringBuilder(string_0.Length);
			foreach (char char_ in string_0)
			{
				stringBuilder.Append(smethod_16(char_));
			}
			return stringBuilder.ToString();
		}
		return "";
	}

	private static string smethod_16(char char_0)
	{
		if (char_0 == '"')
		{
			return "\\0022";
		}
		if (smethod_17(char_0))
		{
			return "\\" + char_0;
		}
		return char_0.ToString();
	}

	private static bool smethod_17(char char_0)
	{
		switch (char_0)
		{
		default:
			return false;
		case '#':
		case '(':
		case ')':
		case ',':
		case '.':
		case '/':
		case ':':
		case ';':
		case '@':
		case '[':
		case '\\':
		case ']':
			return true;
		}
	}

	internal static string smethod_18(FormatCondition formatCondition_0)
	{
		Style style = formatCondition_0.Style;
		string text = smethod_19(style);
		string text2 = smethod_20(style);
		string text3 = smethod_21(style);
		string text4 = text + text2 + text3;
		if (text4.EndsWith(";"))
		{
			text4 = text4.Substring(0, text4.Length - 1);
		}
		return text4;
	}

	internal static string smethod_19(Style style_0)
	{
		if (!style_0.IsModified(StyleModifyFlag.Font))
		{
			return "";
		}
		Font font = style_0.Font;
		StringBuilder stringBuilder = new StringBuilder(100);
		if (style_0.IsModified(StyleModifyFlag.FontColor))
		{
			if (font.InternalColor.method_2())
			{
				stringBuilder.Append("color:windowtext;");
			}
			else
			{
				stringBuilder.Append("color:#" + Class1618.smethod_64(font.Color) + ";");
			}
		}
		if (font.IsItalic)
		{
			stringBuilder.Append("font-style:italic;");
		}
		if (style_0.IsModified(StyleModifyFlag.FontWeight))
		{
			if (font.IsBold)
			{
				stringBuilder.Append("font-weight:700;");
			}
			else
			{
				stringBuilder.Append("font-weight:400;");
			}
		}
		if (style_0.IsModified(StyleModifyFlag.FontUnderline))
		{
			string text = Class1631.smethod_2(font.Underline);
			stringBuilder.Append("text-underline-style:" + text + ";");
		}
		if (style_0.IsModified(StyleModifyFlag.FontStrike))
		{
			if (font.IsStrikeout)
			{
				stringBuilder.Append("text-line-through:single;");
			}
			else
			{
				stringBuilder.Append("text-line-through:none;");
			}
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_20(Style style_0)
	{
		if (!style_0.IsModified(StyleModifyFlag.Borders))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder(100);
		if (style_0.method_9())
		{
			stringBuilder.Append("border-top:" + Class1631.smethod_5(style_0, BorderType.TopBorder) + ";");
			stringBuilder.Append("border-right:" + Class1631.smethod_5(style_0, BorderType.RightBorder) + ";");
			stringBuilder.Append("border-bottom:" + Class1631.smethod_5(style_0, BorderType.BottomBorder) + ";");
			stringBuilder.Append("border-left:" + Class1631.smethod_5(style_0, BorderType.LeftBorder) + ";");
		}
		else
		{
			stringBuilder.Append("border:none;");
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_21(Style style_0)
	{
		if (!style_0.IsModified(StyleModifyFlag.Pattern) && !style_0.IsModified(StyleModifyFlag.BackgroundColor) && !style_0.IsModified(StyleModifyFlag.ForegroundColor))
		{
			return "";
		}
		return Class1631.smethod_4(style_0);
	}

	internal static string smethod_22(string string_0)
	{
		if (string_0 != null && string_0.Length != 0)
		{
			if (string_0[0] == '=')
			{
				return string_0.Substring(1).Replace(">", "&gt;").Replace("<", "&lt;");
			}
			if (Class1677.smethod_19(string_0))
			{
				return string_0;
			}
			return "\"" + string_0 + "\"";
		}
		return "";
	}

	internal static string smethod_23(FormatCondition formatCondition_0)
	{
		string result = null;
		if (formatCondition_0.Type == FormatConditionType.CellValue && formatCondition_0.operatorType_0 != OperatorType.None)
		{
			result = Class1618.smethod_28(formatCondition_0.operatorType_0);
		}
		else if (formatCondition_0.Type == FormatConditionType.ContainsText)
		{
			result = "containsText";
		}
		else if (formatCondition_0.Type == FormatConditionType.NotContainsText)
		{
			result = "notContains";
		}
		else if (formatCondition_0.Type == FormatConditionType.BeginsWith)
		{
			result = "beginsWith";
		}
		else if (formatCondition_0.Type == FormatConditionType.EndsWith)
		{
			result = "endsWith";
		}
		return result;
	}

	internal static string smethod_24(string string_0, bool bool_0)
	{
		if (string_0 == null)
		{
			return null;
		}
		if (string_0.Length == 0)
		{
			return string_0;
		}
		object obj = hashtable_0[string_0];
		if (obj != null)
		{
			return (string)obj;
		}
		int length = string_0.Length;
		StringBuilder stringBuilder = new StringBuilder(length);
		for (int i = 0; i < length; i++)
		{
			char c = string_0[i];
			switch (c)
			{
			case '<':
				if (bool_0)
				{
					stringBuilder.Append("&lt;");
				}
				else
				{
					stringBuilder.Append(c);
				}
				break;
			default:
				stringBuilder.Append(c);
				break;
			case '>':
				if (bool_0)
				{
					stringBuilder.Append("&gt;");
				}
				else
				{
					stringBuilder.Append(c);
				}
				break;
			case '&':
				stringBuilder.Append("&amp;");
				break;
			case '\n':
				stringBuilder.Append("<br>\n");
				break;
			}
		}
		length = stringBuilder.Length;
		StringBuilder stringBuilder2 = new StringBuilder(length);
		bool flag = true;
		for (int j = 0; j < length - 1; j++)
		{
			char c = stringBuilder[j];
			if (c == ' ' && stringBuilder[j + 1] == ' ')
			{
				if (flag)
				{
					stringBuilder2.Append("<span style='mso-spacerun:yes'>&nbsp;");
					flag = false;
				}
				else
				{
					stringBuilder2.Append("&nbsp;");
				}
			}
			else if (c == ' ' && !flag)
			{
				stringBuilder2.Append(" </span>");
				flag = true;
			}
			else
			{
				stringBuilder2.Append(c);
			}
		}
		if (length > 0)
		{
			char c = stringBuilder[length - 1];
			if (!flag)
			{
				stringBuilder2.Append(" </span>");
			}
			else
			{
				stringBuilder2.Append(c);
			}
		}
		string text = stringBuilder2.ToString();
		hashtable_0[string_0] = text;
		return text;
	}

	public static int smethod_25(int int_0, double double_0)
	{
		return (int)(double_0 * (double)int_0 / 72.0 + 0.5);
	}
}
