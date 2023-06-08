using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using Aspose.Cells;
using ns1;
using ns16;
using ns2;

namespace ns50;

internal class Class1631
{
	public static readonly string[] string_0 = new string[26]
	{
		"Title", "Subject", "Author", "Keywords", "Description", "LastAuthor", "Revision", "AppName", "TotalTime", "LastPrinted",
		"Created", "LastSaved", "Pages", "Words", "Characters", "Category", "PresentationFormat", "Manager", "Company", "Guid",
		"HyperlinkBase", "Bytes", "Lines", "Paragraphs", "CharactersWithSpaces", "Version"
	};

	public static readonly string[] string_1 = new string[4] { "HideHorizontalScrollBar", "HideVerticalScrollBar", "HideWorkbookTabs", "ActiveSheet" };

	public static readonly string[] string_2 = new string[6] { "Alignment", "Borders", "Font", "Interior", "NumberFormat", "Protection" };

	internal static int[] int_0 = new int[56]
	{
		0, 16777215, 255, 65280, 16711680, 65535, 16711935, 16776960, 128, 32768,
		8388608, 32896, 8388736, 8421376, 12632256, 8421504, 16751001, 6697881, 13434879, 16777164,
		6684774, 8421631, 13395456, 16764108, 8388608, 16711935, 65535, 16776960, 8388736, 128,
		8421376, 16711680, 16763904, 16777164, 13434828, 10092543, 16764057, 13408767, 16751052, 10079487,
		16737843, 13421619, 52377, 52479, 39423, 26367, 10053222, 9868950, 6697728, 6723891,
		13056, 13107, 13209, 6697881, 10040115, 3355443
	};

	internal static string smethod_0(OperatorType operatorType_0)
	{
		return operatorType_0 switch
		{
			OperatorType.Between => "Between", 
			OperatorType.Equal => "Equal", 
			OperatorType.GreaterThan => "Greater", 
			OperatorType.GreaterOrEqual => "GreaterOrEqual", 
			OperatorType.LessThan => "Less", 
			OperatorType.LessOrEqual => "LessOrEqual", 
			OperatorType.NotBetween => "NotBetween", 
			OperatorType.NotEqual => "NotEqual", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid OperatorType val"), 
		};
	}

	internal static OperatorType smethod_1(string string_3)
	{
		string key;
		if ((key = string_3) != null)
		{
			if (Class1742.dictionary_191 == null)
			{
				Class1742.dictionary_191 = new Dictionary<string, int>(8)
				{
					{ "Between", 0 },
					{ "Equal", 1 },
					{ "GreaterOrEqual", 2 },
					{ "Greater", 3 },
					{ "LessOrEqual", 4 },
					{ "Less", 5 },
					{ "NotBetween", 6 },
					{ "NotEqual", 7 }
				};
			}
			if (Class1742.dictionary_191.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return OperatorType.Between;
				case 1:
					return OperatorType.Equal;
				case 2:
					return OperatorType.GreaterOrEqual;
				case 3:
					return OperatorType.GreaterThan;
				case 4:
					return OperatorType.LessOrEqual;
				case 5:
					return OperatorType.LessThan;
				case 6:
					return OperatorType.NotBetween;
				case 7:
					return OperatorType.NotEqual;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid OperatorType string val");
	}

	internal static string smethod_2(FontUnderlineType fontUnderlineType_0)
	{
		switch (fontUnderlineType_0)
		{
		default:
			return "none";
		case FontUnderlineType.Single:
		case FontUnderlineType.Accounting:
			return "single";
		case FontUnderlineType.Double:
		case FontUnderlineType.DoubleAccounting:
			return "double";
		}
	}

	internal static FontUnderlineType smethod_3(string string_3)
	{
		return string_3 switch
		{
			"double" => FontUnderlineType.Double, 
			"single" => FontUnderlineType.Single, 
			_ => FontUnderlineType.None, 
		};
	}

	public static string smethod_4(Style style_0)
	{
		StringBuilder stringBuilder = new StringBuilder(30);
		if (style_0.IsModified(StyleModifyFlag.BackgroundColor))
		{
			if (!style_0.BackgroundInternalColor.method_2())
			{
				string text = "#" + Class1618.smethod_64(style_0.BackgroundColor);
				stringBuilder.Append("background:" + text + ";");
			}
			else
			{
				stringBuilder.Append("mso-background-source:auto;");
			}
		}
		if (style_0.IsModified(StyleModifyFlag.Pattern) || style_0.IsModified(StyleModifyFlag.ForegroundColor))
		{
			stringBuilder.Append("mso-pattern:");
			if (style_0.IsModified(StyleModifyFlag.ForegroundColor))
			{
				string text2 = "auto";
				if (!style_0.ForeInternalColor.method_2())
				{
					text2 = "#" + Class1618.smethod_64(style_0.ForegroundColor);
				}
				stringBuilder.Append(text2 + " ");
			}
			string text3 = Class1130.smethod_1(style_0.Pattern);
			stringBuilder.Append(text3 + ";");
		}
		return stringBuilder.ToString();
	}

	public static string smethod_5(Style style_0, BorderType borderType_0)
	{
		Border border = style_0.Borders[borderType_0];
		CellBorderType lineStyle = border.LineStyle;
		if (lineStyle == CellBorderType.None)
		{
			return "none";
		}
		StringBuilder stringBuilder = new StringBuilder(Class1130.smethod_0(lineStyle));
		if (!border.InternalColor.method_2())
		{
			stringBuilder.Append(" #" + Class1618.smethod_64(border.Color));
		}
		else
		{
			stringBuilder.Append(" windowtext");
		}
		return stringBuilder.ToString();
	}

	internal static Color smethod_6(string string_3)
	{
		int argb = int.Parse(string_3, NumberStyles.HexNumber);
		return Color.FromArgb(argb);
	}

	internal static CellBorderType smethod_7(string string_3)
	{
		string key;
		if ((key = string_3) != null)
		{
			if (Class1742.dictionary_192 == null)
			{
				Class1742.dictionary_192 = new Dictionary<string, int>(14)
				{
					{ "none", 0 },
					{ ".5pt solid", 1 },
					{ "1.0pt solid", 2 },
					{ ".5pt dashed", 3 },
					{ ".5pt dotted", 4 },
					{ "1.5pt solid", 5 },
					{ "2.0pt double", 6 },
					{ ".5pt hairline", 7 },
					{ "1.0pt dashed", 8 },
					{ ".5pt dot-dash", 9 },
					{ "1.0pt dot-dash", 10 },
					{ ".5pt dot-dot-dash", 11 },
					{ "1.0pt dot-dot-dash", 12 },
					{ "1.0pt dot-dash-slanted", 13 }
				};
			}
			if (Class1742.dictionary_192.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return CellBorderType.None;
				case 1:
					return CellBorderType.Thin;
				case 2:
					return CellBorderType.Medium;
				case 3:
					return CellBorderType.Dashed;
				case 4:
					return CellBorderType.Dotted;
				case 5:
					return CellBorderType.Thick;
				case 6:
					return CellBorderType.Double;
				case 7:
					return CellBorderType.Hair;
				case 8:
					return CellBorderType.MediumDashed;
				case 9:
					return CellBorderType.DashDot;
				case 10:
					return CellBorderType.MediumDashDot;
				case 11:
					return CellBorderType.DashDotDot;
				case 12:
					return CellBorderType.MediumDashDotDot;
				case 13:
					return CellBorderType.SlantedDashDot;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid BorderLineStyleString val: " + string_3);
	}

	internal static BackgroundType smethod_8(string string_3)
	{
		string key;
		if ((key = string_3) != null)
		{
			if (Class1742.dictionary_193 == null)
			{
				Class1742.dictionary_193 = new Dictionary<string, int>(18)
				{
					{ "none", 0 },
					{ "gray-75", 1 },
					{ "gray-50", 2 },
					{ "gray-25", 3 },
					{ "gray-125", 4 },
					{ "gray-0625", 5 },
					{ "horz-stripe", 6 },
					{ "vert-stripe", 7 },
					{ "reverse-diag-stripe", 8 },
					{ "diag-stripe", 9 },
					{ "diag-cross", 10 },
					{ "thick-diag-cross", 11 },
					{ "thin-horz-stripe", 12 },
					{ "thin-vert-stripe", 13 },
					{ "thin-reverse-diag-stripe", 14 },
					{ "thin-diag-stripe", 15 },
					{ "thin-horz-cross", 16 },
					{ "thin-diag-cross", 17 }
				};
			}
			if (Class1742.dictionary_193.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return BackgroundType.Solid;
				case 1:
					return BackgroundType.Gray75;
				case 2:
					return BackgroundType.Gray50;
				case 3:
					return BackgroundType.Gray25;
				case 4:
					return BackgroundType.Gray12;
				case 5:
					return BackgroundType.Gray6;
				case 6:
					return BackgroundType.HorizontalStripe;
				case 7:
					return BackgroundType.VerticalStripe;
				case 8:
					return BackgroundType.ReverseDiagonalStripe;
				case 9:
					return BackgroundType.DiagonalStripe;
				case 10:
					return BackgroundType.DiagonalCrosshatch;
				case 11:
					return BackgroundType.ThickDiagonalCrosshatch;
				case 12:
					return BackgroundType.ThinHorizontalStripe;
				case 13:
					return BackgroundType.ThinVerticalStripe;
				case 14:
					return BackgroundType.ThinReverseDiagonalStripe;
				case 15:
					return BackgroundType.ThinDiagonalStripe;
				case 16:
					return BackgroundType.ThinHorizontalCrosshatch;
				case 17:
					return BackgroundType.ThinDiagonalCrosshatch;
				}
			}
		}
		return BackgroundType.None;
	}

	internal static CellArea smethod_9(string string_3, int int_1, int int_2)
	{
		bool flag = false;
		CellArea cellArea = default(CellArea);
		char[] array = string_3.ToCharArray();
		int num = -1;
		int num2 = -1;
		int endRow = -1;
		int endColumn = -1;
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i])
			{
			case ':':
				flag = true;
				break;
			case 'C':
			case 'c':
				if (i + 1 < array.Length)
				{
					char c2 = array[i + 1];
					if (c2 == '[')
					{
						num4 = i + 2;
						for (i += 2; i < array.Length && array[i] != ']'; i++)
						{
						}
						num3 = int.Parse(string_3.Substring(num4, i - num4)) + int_2;
					}
					else
					{
						num4 = i + 1;
						for (i++; i < array.Length && array[i] != ':'; i++)
						{
						}
						num3 = ((i == num4) ? int_2 : (int.Parse(string_3.Substring(num4, i - num4)) + int_2));
						i--;
					}
				}
				else
				{
					num3 = int_2;
				}
				if (flag)
				{
					endColumn = num3;
				}
				else
				{
					num2 = num3;
				}
				break;
			case 'R':
			case 'r':
				if (i + 1 < array.Length)
				{
					char c = array[i + 1];
					if (c == '[')
					{
						num4 = i + 2;
						for (i += 2; i < array.Length && array[i] != ']'; i++)
						{
						}
						num3 = int.Parse(string_3.Substring(num4, i - num4)) + int_1;
					}
					else
					{
						num4 = i + 1;
						for (i++; i < array.Length && array[i] != ':' && array[i] != 'c' && array[i] != 'C'; i++)
						{
						}
						num3 = ((i == num4) ? int_1 : (int.Parse(string_3.Substring(num4, i - num4)) + int_1));
						i--;
					}
				}
				else
				{
					num3 = int_1;
				}
				if (flag)
				{
					endRow = num3;
				}
				else
				{
					num = num3;
				}
				break;
			}
		}
		if (flag)
		{
			if (num == -1)
			{
				return CellArea.CreateCellArea(num, 0, endRow, 16383);
			}
			if (num2 == -1)
			{
				return CellArea.CreateCellArea(0, num2, 1048575, endColumn);
			}
			return CellArea.CreateCellArea(num, num2, endRow, endColumn);
		}
		if (num == -1)
		{
			return CellArea.CreateCellArea(num, 0, num, 16383);
		}
		if (num2 == -1)
		{
			return CellArea.CreateCellArea(0, num2, 1048575, num2);
		}
		return CellArea.CreateCellArea(num, num2, num, num2);
	}

	internal static CellArea smethod_10(string string_3)
	{
		CellArea result = default(CellArea);
		string_3 = string_3.ToLower();
		int num = string_3.IndexOf('r');
		int num2 = string_3.IndexOf('c');
		if (num != -1 && num2 != -1)
		{
			string[] array = string_3.Split(':');
			smethod_14(array[0], out result.StartRow, out var column);
			result.StartColumn = column;
			if (array.Length == 1)
			{
				result.EndRow = result.StartRow;
				result.EndColumn = result.StartColumn;
			}
			else
			{
				smethod_14(array[1], out result.EndRow, out column);
				result.EndColumn = column;
			}
			return result;
		}
		return smethod_11(string_3);
	}

	private static CellArea smethod_11(string string_3)
	{
		CellArea result = default(CellArea);
		string_3 = string_3.ToLower();
		int num = string_3.IndexOf('r');
		int num2 = string_3.IndexOf('c');
		if (num != -1 && num2 == -1)
		{
			string[] array = string_3.Split(':');
			result.StartRow = smethod_13(array[0]) - 1;
			if (array.Length == 1)
			{
				result.EndRow = result.StartRow;
			}
			else
			{
				result.EndRow = smethod_13(array[1]) - 1;
			}
			result.StartColumn = 0;
			result.EndColumn = 255;
		}
		else if (num2 != -1 && num == -1)
		{
			string[] array2 = string_3.Split(':');
			result.StartColumn = smethod_13(array2[0]) - 1;
			if (array2.Length == 1)
			{
				result.EndColumn = result.StartColumn;
			}
			else
			{
				result.EndColumn = smethod_13(array2[1]) - 1;
			}
			result.StartRow = 0;
			result.EndRow = 65535;
		}
		return result;
	}

	internal static void smethod_12(string string_3, ArrayList arrayList_0)
	{
		string[] array = string_3.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i].Trim();
			if (text.Length > 0)
			{
				CellArea cellArea = smethod_10(text);
				arrayList_0.Add(cellArea);
			}
		}
	}

	private static int smethod_13(string string_3)
	{
		bool flag = false;
		int num = 0;
		int num2 = string_3.Length;
		for (int i = 0; i < string_3.Length; i++)
		{
			char c = string_3[i];
			if (c >= '0' && c <= '9')
			{
				if (!flag)
				{
					flag = true;
					num = i;
				}
				num2 = i;
			}
			else if (flag)
			{
				break;
			}
		}
		int result = 1;
		if (flag)
		{
			string s = string_3.Substring(num, num2 - num + 1);
			result = int.Parse(s);
		}
		return result;
	}

	internal static void smethod_14(string cellName, out int row, out int column)
	{
		row = 0;
		column = 0;
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		for (int i = 0; i < cellName.Length; i++)
		{
			switch (cellName[i])
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
				if (i == cellName.Length - 1)
				{
					num3 = i + 1;
				}
				break;
			default:
				num3 = i;
				break;
			case 'C':
			case 'c':
				num2 = i;
				break;
			case 'R':
			case 'r':
				num = i;
				break;
			}
			if (num != -1 && num2 - num > 1 && num3 - num2 > 1)
			{
				row = int.Parse(cellName.Substring(num + 1, num2 - num - 1)) - 1;
				column = int.Parse(cellName.Substring(num2 + 1, num3 - num2 - 1)) - 1;
			}
			if (num3 != -1)
			{
				num = (num3 = (num2 = -1));
			}
		}
	}
}
