using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using Aspose.Cells.Tables;
using ns1;
using ns2;
using ns21;
using ns22;
using ns45;
using ns58;
using ns7;

namespace ns16;

internal class Class1618
{
	internal static bool bool_0 = true;

	internal static bool bool_1 = true;

	internal static string string_0 = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";

	internal static string string_1 = "http://schemas.openxmlformats.org/spreadsheetml/2006/5/main";

	internal static string string_2 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";

	internal static string string_3 = "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main";

	internal static bool smethod_0(string string_4)
	{
		return true;
	}

	private static bool smethod_1(char char_0, bool bool_2)
	{
		try
		{
			if (!bool_2)
			{
				char c = char_0;
				if (c == '\n' || c == '\r')
				{
					return false;
				}
			}
			int num = Convert.ToInt32(char_0);
			if ((num >= 32 && num <= 55295) || (num >= 57344 && num <= 65533) || (num > 65536 && num <= 1114111))
			{
				return false;
			}
			return true;
		}
		catch
		{
			return true;
		}
	}

	private static bool smethod_2(char char_0)
	{
		if ((char_0 >= '0' && char_0 <= '9') || (char_0 >= 'a' && char_0 <= 'f') || (char_0 >= 'A' && char_0 <= 'F'))
		{
			return true;
		}
		return false;
	}

	private static string smethod_3(string string_4, bool bool_2)
	{
		if (string_4 != null && string_4.Length != 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int length = string_4.Length;
			for (int i = 0; i < length; i++)
			{
				char c = string_4[i];
				if (c == '\t')
				{
					stringBuilder.Append(' ');
				}
				else if (smethod_1(c, bool_2))
				{
					stringBuilder.AppendFormat("_x{0:X4}_", (int)c);
				}
				else if (c == '_' && i + 6 < length && string_4[i + 1] == 'x' && string_4[i + 6] == '_')
				{
					bool flag = true;
					for (int j = i + 2; j < i + 6; j++)
					{
						char char_ = string_4[j];
						if (!smethod_2(char_))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						stringBuilder.Append("_x005F_");
					}
					else
					{
						stringBuilder.Append(c);
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}
		return string_4;
	}

	internal static string smethod_4(string string_4)
	{
		if (string_4 == null)
		{
			return null;
		}
		if (string_4.Length == 0)
		{
			return string_4;
		}
		if (bool_0)
		{
			return smethod_3(string_4, bool_2: false);
		}
		return XmlConvert.EncodeName(string_4);
	}

	internal static string smethod_5(string string_4)
	{
		if (string_4 == null)
		{
			return null;
		}
		if (string_4.Length == 0)
		{
			return string_4;
		}
		if (bool_0)
		{
			return smethod_3(string_4, bool_2: true);
		}
		return XmlConvert.EncodeName(string_4);
	}

	private static int smethod_6(char char_0)
	{
		switch (char_0)
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
			return char_0 - 48;
		default:
			return -1;
		case 'A':
		case 'B':
		case 'C':
		case 'D':
		case 'E':
		case 'F':
		case 'a':
		case 'b':
		case 'c':
		case 'd':
		case 'e':
		case 'f':
			return (char_0 | 0x20) - 97 + 10;
		}
	}

	private static string smethod_7(string string_4)
	{
		if (string_4.IndexOf("_X") == -1 && string_4.IndexOf("_x") == -1)
		{
			return string_4;
		}
		StringBuilder stringBuilder = new StringBuilder(string_4.Length);
		char[] array = string_4.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == '_' && i + 6 < array.Length && (array[i + 1] | 0x20) == 120 && array[i + 6] == '_')
			{
				int num = 0;
				for (int j = 0; j < 4; j++)
				{
					int num2 = smethod_6(array[i + 2 + j]);
					if (num2 != -1)
					{
						num = (num << 4) | num2;
						continue;
					}
					num = -1;
					break;
				}
				switch (num)
				{
				case -1:
					stringBuilder.Append(array[i]);
					continue;
				default:
					stringBuilder.Append((char)num);
					break;
				case 13:
					break;
				}
				i += 6;
			}
			else
			{
				stringBuilder.Append(array[i]);
			}
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_8(string string_4)
	{
		if (string_4 == null)
		{
			return null;
		}
		if (string_4.Length == 0)
		{
			return string_4;
		}
		if (bool_0)
		{
			return smethod_7(string_4);
		}
		return string_4;
	}

	internal static string smethod_9(FontUnderlineType fontUnderlineType_0)
	{
		return fontUnderlineType_0 switch
		{
			FontUnderlineType.None => "none", 
			FontUnderlineType.Single => "single", 
			FontUnderlineType.Double => "double", 
			FontUnderlineType.Accounting => "singleAccounting", 
			FontUnderlineType.DoubleAccounting => "doubleAccounting", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid FontUnderlineType value"), 
		};
	}

	internal static FontUnderlineType smethod_10(string string_4)
	{
		return string_4 switch
		{
			"none" => FontUnderlineType.None, 
			"doubleAccounting" => FontUnderlineType.DoubleAccounting, 
			"double" => FontUnderlineType.Double, 
			"singleAccounting" => FontUnderlineType.Accounting, 
			"single" => FontUnderlineType.Single, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid FontUnderlineType string val"), 
		};
	}

	internal static int smethod_11(byte[] byte_0, int int_0)
	{
		short num = (short)smethod_12(byte_0, int_0, 2);
		if (num < 0)
		{
			return num & 0xFFFF;
		}
		return num;
	}

	internal static long smethod_12(byte[] byte_0, int int_0, int int_1)
	{
		int num = 0;
		for (int num2 = int_0 + int_1 - 1; num2 >= int_0; num2--)
		{
			num <<= 8;
			num |= byte_0[num2] & 0xFF;
		}
		return num;
	}

	internal static void smethod_13(byte[] byte_0, int int_0, short short_0)
	{
		smethod_14(byte_0, int_0, 2, short_0);
	}

	internal static void smethod_14(byte[] byte_0, int int_0, int int_1, long long_0)
	{
		for (int i = int_0; i < int_1 + int_0; i++)
		{
			byte_0[i] = (byte)(long_0 & 0xFF);
			long_0 >>= 8;
		}
	}

	internal static string smethod_15(CellArea cellArea_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(CellsHelper.ColumnIndexToName(cellArea_0.StartColumn)).Append(smethod_80(cellArea_0.StartRow + 1));
		if (cellArea_0.StartColumn != cellArea_0.EndColumn || cellArea_0.StartRow != cellArea_0.EndRow)
		{
			stringBuilder.Append(":").Append(CellsHelper.ColumnIndexToName(cellArea_0.EndColumn)).Append(smethod_80(cellArea_0.EndRow + 1));
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_16(CellArea cellArea_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (cellArea_0.StartRow == 0 && (cellArea_0.EndRow == 65535 || cellArea_0.EndRow == 1048575))
		{
			stringBuilder.Append("C").Append(smethod_80(cellArea_0.StartColumn + 1));
			if (cellArea_0.StartColumn != cellArea_0.EndColumn)
			{
				stringBuilder.Append(":").Append("C").Append(smethod_80(cellArea_0.EndColumn + 1));
			}
		}
		else if (cellArea_0.StartColumn == 0 && (cellArea_0.EndColumn == 255 || cellArea_0.EndColumn == 16383))
		{
			stringBuilder.Append("R").Append(smethod_80(cellArea_0.StartRow + 1));
			if (cellArea_0.StartColumn != cellArea_0.EndColumn || cellArea_0.StartRow != cellArea_0.EndRow)
			{
				stringBuilder.Append(":").Append("R").Append(smethod_80(cellArea_0.EndRow + 1));
			}
		}
		else
		{
			stringBuilder.Append("R").Append(smethod_80(cellArea_0.StartRow + 1)).Append("C")
				.Append(smethod_80(cellArea_0.StartColumn + 1));
			if (cellArea_0.StartColumn != cellArea_0.EndColumn || cellArea_0.StartRow != cellArea_0.EndRow)
			{
				stringBuilder.Append(":").Append("R").Append(smethod_80(cellArea_0.EndRow + 1))
					.Append("C")
					.Append(smethod_80(cellArea_0.EndColumn + 1));
			}
		}
		return stringBuilder.ToString();
	}

	internal static CellArea smethod_17(string string_4)
	{
		CellArea result = default(CellArea);
		string[] array = string_4.Replace("$", "").Split(':');
		CellsHelper.CellNameToIndex(array[0], out var row, out var column);
		result.StartRow = row;
		result.StartColumn = column;
		if (array.Length == 1)
		{
			result.EndRow = result.StartRow;
			result.EndColumn = result.StartColumn;
		}
		else
		{
			CellsHelper.CellNameToIndex(array[1], out var row2, out column);
			result.EndRow = row2;
			result.EndColumn = column;
		}
		return result;
	}

	internal static string smethod_18(PageOrientationType pageOrientationType_0)
	{
		return pageOrientationType_0 switch
		{
			PageOrientationType.Landscape => "landscape", 
			PageOrientationType.Portrait => "portrait", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid PageOrientationType val"), 
		};
	}

	internal static PageOrientationType smethod_19(string string_4)
	{
		return string_4 switch
		{
			"default" => PageOrientationType.Portrait, 
			"portrait" => PageOrientationType.Portrait, 
			"landscape" => PageOrientationType.Landscape, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid PageOrientationType string val"), 
		};
	}

	internal static string smethod_20(PrintCommentsType printCommentsType_0)
	{
		return printCommentsType_0 switch
		{
			PrintCommentsType.PrintInPlace => "asDisplayed", 
			PrintCommentsType.PrintNoComments => "none", 
			PrintCommentsType.PrintSheetEnd => "atEnd", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid PrintCommentsType val"), 
		};
	}

	internal static PrintCommentsType smethod_21(string string_4)
	{
		return string_4 switch
		{
			"atEnd" => PrintCommentsType.PrintSheetEnd, 
			"none" => PrintCommentsType.PrintNoComments, 
			"asDisplayed" => PrintCommentsType.PrintInPlace, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid PrintCommentsType string val"), 
		};
	}

	internal static string smethod_22(PrintErrorsType printErrorsType_0)
	{
		return printErrorsType_0 switch
		{
			PrintErrorsType.PrintErrorsBlank => "blank", 
			PrintErrorsType.PrintErrorsDash => "dash", 
			PrintErrorsType.PrintErrorsDisplayed => "displayed", 
			PrintErrorsType.PrintErrorsNA => "NA", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid PrintErrorsType val"), 
		};
	}

	internal static PrintErrorsType smethod_23(string string_4)
	{
		return string_4 switch
		{
			"NA" => PrintErrorsType.PrintErrorsNA, 
			"displayed" => PrintErrorsType.PrintErrorsDisplayed, 
			"dash" => PrintErrorsType.PrintErrorsDash, 
			"blank" => PrintErrorsType.PrintErrorsBlank, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid PrintErrorsType string val"), 
		};
	}

	internal static string smethod_24(PrintOrderType printOrderType_0)
	{
		return printOrderType_0 switch
		{
			PrintOrderType.DownThenOver => "downThenOver", 
			PrintOrderType.OverThenDown => "overThenDown", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid PrintOrderType val"), 
		};
	}

	internal static PrintOrderType smethod_25(string string_4)
	{
		return string_4 switch
		{
			"overThenDown" => PrintOrderType.OverThenDown, 
			"downThenOver" => PrintOrderType.DownThenOver, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid PrintOrderType string val"), 
		};
	}

	internal static string smethod_26(Aspose.Cells.ValidationType validationType_0)
	{
		return validationType_0 switch
		{
			Aspose.Cells.ValidationType.AnyValue => "none", 
			Aspose.Cells.ValidationType.WholeNumber => "whole", 
			Aspose.Cells.ValidationType.Decimal => "decimal", 
			Aspose.Cells.ValidationType.List => "list", 
			Aspose.Cells.ValidationType.Date => "date", 
			Aspose.Cells.ValidationType.Time => "time", 
			Aspose.Cells.ValidationType.TextLength => "textLength", 
			Aspose.Cells.ValidationType.Custom => "custom", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid ValidationType val"), 
		};
	}

	internal static Aspose.Cells.ValidationType smethod_27(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_146 == null)
			{
				Class1742.dictionary_146 = new Dictionary<string, int>(9)
				{
					{ "custom", 0 },
					{ "none", 1 },
					{ "any", 2 },
					{ "date", 3 },
					{ "decimal", 4 },
					{ "list", 5 },
					{ "textLength", 6 },
					{ "time", 7 },
					{ "whole", 8 }
				};
			}
			if (Class1742.dictionary_146.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return Aspose.Cells.ValidationType.Custom;
				case 1:
				case 2:
					return Aspose.Cells.ValidationType.AnyValue;
				case 3:
					return Aspose.Cells.ValidationType.Date;
				case 4:
					return Aspose.Cells.ValidationType.Decimal;
				case 5:
					return Aspose.Cells.ValidationType.List;
				case 6:
					return Aspose.Cells.ValidationType.TextLength;
				case 7:
					return Aspose.Cells.ValidationType.Time;
				case 8:
					return Aspose.Cells.ValidationType.WholeNumber;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid ValidationType string val");
	}

	internal static string smethod_28(OperatorType operatorType_0)
	{
		return operatorType_0 switch
		{
			OperatorType.Between => "Between", 
			OperatorType.Equal => "Equal", 
			OperatorType.GreaterThan => "greater", 
			OperatorType.GreaterOrEqual => "GreaterOrEqual", 
			OperatorType.LessThan => "less", 
			OperatorType.LessOrEqual => "LessOrEqual", 
			OperatorType.NotBetween => "notBetween", 
			OperatorType.NotEqual => "notEqual", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid OperatorType val"), 
		};
	}

	internal static string smethod_29(OperatorType operatorType_0)
	{
		return operatorType_0 switch
		{
			OperatorType.Between => "between", 
			OperatorType.Equal => "equal", 
			OperatorType.GreaterThan => "greaterThan", 
			OperatorType.GreaterOrEqual => "greaterThanOrEqual", 
			OperatorType.LessThan => "lessThan", 
			OperatorType.LessOrEqual => "lessThanOrEqual", 
			OperatorType.NotBetween => "notBetween", 
			OperatorType.NotEqual => "notEqual", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid OperatorType val"), 
		};
	}

	internal static OperatorType smethod_30(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_147 == null)
			{
				Class1742.dictionary_147 = new Dictionary<string, int>(8)
				{
					{ "between", 0 },
					{ "equal", 1 },
					{ "greaterThanOrEqual", 2 },
					{ "greaterThan", 3 },
					{ "lessThanOrEqual", 4 },
					{ "lessThan", 5 },
					{ "notBetween", 6 },
					{ "notEqual", 7 }
				};
			}
			if (Class1742.dictionary_147.TryGetValue(key, out var value))
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

	internal static string smethod_31(ArrayList arrayList_0, int int_0, int int_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = int_0; i < int_1; i++)
		{
			if (i > int_0)
			{
				stringBuilder.Append(",");
			}
			CellArea cellArea_ = (CellArea)arrayList_0[i];
			stringBuilder.Append(smethod_16(cellArea_));
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_32(ArrayList arrayList_0, int int_0, int int_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = int_0; i < int_1; i++)
		{
			if (i > int_0)
			{
				stringBuilder.Append(" ");
			}
			CellArea cellArea_ = (CellArea)arrayList_0[i];
			stringBuilder.Append(smethod_15(cellArea_));
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_33(BackgroundType backgroundType_0)
	{
		return backgroundType_0 switch
		{
			BackgroundType.None => "none", 
			BackgroundType.Solid => "solid", 
			BackgroundType.Gray50 => "mediumGray", 
			BackgroundType.Gray75 => "darkGray", 
			BackgroundType.Gray25 => "lightGray", 
			BackgroundType.HorizontalStripe => "darkHorizontal", 
			BackgroundType.VerticalStripe => "darkVertical", 
			BackgroundType.ReverseDiagonalStripe => "darkDown", 
			BackgroundType.DiagonalStripe => "darkUp", 
			BackgroundType.DiagonalCrosshatch => "darkGrid", 
			BackgroundType.ThickDiagonalCrosshatch => "darkTrellis", 
			BackgroundType.ThinHorizontalStripe => "lightHorizontal", 
			BackgroundType.ThinVerticalStripe => "lightVertical", 
			BackgroundType.ThinReverseDiagonalStripe => "lightDown", 
			BackgroundType.ThinDiagonalStripe => "lightUp", 
			BackgroundType.ThinHorizontalCrosshatch => "lightGrid", 
			BackgroundType.ThinDiagonalCrosshatch => "lightTrellis", 
			BackgroundType.Gray12 => "gray125", 
			BackgroundType.Gray6 => "gray0625", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid BackgroundType value"), 
		};
	}

	internal static BackgroundType smethod_34(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_148 == null)
			{
				Class1742.dictionary_148 = new Dictionary<string, int>(19)
				{
					{ "none", 0 },
					{ "solid", 1 },
					{ "darkGray", 2 },
					{ "mediumGray", 3 },
					{ "lightGray", 4 },
					{ "gray125", 5 },
					{ "gray0625", 6 },
					{ "darkHorizontal", 7 },
					{ "darkVertical", 8 },
					{ "darkDown", 9 },
					{ "darkUp", 10 },
					{ "darkGrid", 11 },
					{ "darkTrellis", 12 },
					{ "lightHorizontal", 13 },
					{ "lightVertical", 14 },
					{ "lightDown", 15 },
					{ "lightUp", 16 },
					{ "lightGrid", 17 },
					{ "lightTrellis", 18 }
				};
			}
			if (Class1742.dictionary_148.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return BackgroundType.None;
				case 1:
					return BackgroundType.Solid;
				case 2:
					return BackgroundType.Gray75;
				case 3:
					return BackgroundType.Gray50;
				case 4:
					return BackgroundType.Gray25;
				case 5:
					return BackgroundType.Gray12;
				case 6:
					return BackgroundType.Gray6;
				case 7:
					return BackgroundType.HorizontalStripe;
				case 8:
					return BackgroundType.VerticalStripe;
				case 9:
					return BackgroundType.ReverseDiagonalStripe;
				case 10:
					return BackgroundType.DiagonalStripe;
				case 11:
					return BackgroundType.DiagonalCrosshatch;
				case 12:
					return BackgroundType.ThickDiagonalCrosshatch;
				case 13:
					return BackgroundType.ThinHorizontalStripe;
				case 14:
					return BackgroundType.ThinVerticalStripe;
				case 15:
					return BackgroundType.ThinReverseDiagonalStripe;
				case 16:
					return BackgroundType.ThinDiagonalStripe;
				case 17:
					return BackgroundType.ThinHorizontalCrosshatch;
				case 18:
					return BackgroundType.ThinDiagonalCrosshatch;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid PatternType string value");
	}

	internal static string smethod_35(CellBorderType cellBorderType_0)
	{
		return cellBorderType_0 switch
		{
			CellBorderType.None => "none", 
			CellBorderType.Thin => "thin", 
			CellBorderType.Medium => "medium", 
			CellBorderType.Dashed => "dashed", 
			CellBorderType.Dotted => "dotted", 
			CellBorderType.Thick => "thick", 
			CellBorderType.Double => "double", 
			CellBorderType.Hair => "hair", 
			CellBorderType.MediumDashed => "mediumDashed", 
			CellBorderType.DashDot => "dashDot", 
			CellBorderType.MediumDashDot => "mediumDashDot", 
			CellBorderType.DashDotDot => "dashDotDot", 
			CellBorderType.MediumDashDotDot => "mediumDashDotDot", 
			CellBorderType.SlantedDashDot => "slantDashDot", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid CellBorderType value"), 
		};
	}

	internal static CellBorderType smethod_36(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_149 == null)
			{
				Class1742.dictionary_149 = new Dictionary<string, int>(14)
				{
					{ "dashDot", 0 },
					{ "dashDotDot", 1 },
					{ "dashed", 2 },
					{ "dotted", 3 },
					{ "double", 4 },
					{ "hair", 5 },
					{ "medium", 6 },
					{ "mediumDashDot", 7 },
					{ "mediumDashDotDot", 8 },
					{ "mediumDashed", 9 },
					{ "none", 10 },
					{ "slantDashDot", 11 },
					{ "thick", 12 },
					{ "thin", 13 }
				};
			}
			if (Class1742.dictionary_149.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return CellBorderType.DashDot;
				case 1:
					return CellBorderType.DashDotDot;
				case 2:
					return CellBorderType.Dashed;
				case 3:
					return CellBorderType.Dotted;
				case 4:
					return CellBorderType.Double;
				case 5:
					return CellBorderType.Hair;
				case 6:
					return CellBorderType.Medium;
				case 7:
					return CellBorderType.MediumDashDot;
				case 8:
					return CellBorderType.MediumDashDotDot;
				case 9:
					return CellBorderType.MediumDashed;
				case 10:
					return CellBorderType.None;
				case 11:
					return CellBorderType.SlantedDashDot;
				case 12:
					return CellBorderType.Thick;
				case 13:
					return CellBorderType.Thin;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid CellBorderType string value");
	}

	internal static string smethod_37(TextAlignmentType textAlignmentType_0)
	{
		return textAlignmentType_0 switch
		{
			TextAlignmentType.Center => "center", 
			TextAlignmentType.CenterAcross => "centerContinuous", 
			TextAlignmentType.Distributed => "distributed", 
			TextAlignmentType.Fill => "fill", 
			TextAlignmentType.General => "general", 
			TextAlignmentType.Justify => "justify", 
			TextAlignmentType.Left => "left", 
			TextAlignmentType.Right => "right", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid Horizontal AlignmentType value"), 
		};
	}

	internal static TextAlignmentType smethod_38(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_150 == null)
			{
				Class1742.dictionary_150 = new Dictionary<string, int>(8)
				{
					{ "general", 0 },
					{ "left", 1 },
					{ "center", 2 },
					{ "right", 3 },
					{ "justify", 4 },
					{ "centerContinuous", 5 },
					{ "distributed", 6 },
					{ "fill", 7 }
				};
			}
			if (Class1742.dictionary_150.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return TextAlignmentType.General;
				case 1:
					return TextAlignmentType.Left;
				case 2:
					return TextAlignmentType.Center;
				case 3:
					return TextAlignmentType.Right;
				case 4:
					return TextAlignmentType.Justify;
				case 5:
					return TextAlignmentType.CenterAcross;
				case 6:
					return TextAlignmentType.Distributed;
				case 7:
					return TextAlignmentType.Fill;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid Horizontal AlignmentType string value");
	}

	internal static string smethod_39(TextAlignmentType textAlignmentType_0)
	{
		return textAlignmentType_0 switch
		{
			TextAlignmentType.Top => "top", 
			TextAlignmentType.Bottom => "bottom", 
			TextAlignmentType.Center => "center", 
			TextAlignmentType.Distributed => "distributed", 
			TextAlignmentType.Justify => "justify", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid Vertical AlignmentType value"), 
		};
	}

	internal static TextAlignmentType smethod_40(string string_4)
	{
		return string_4 switch
		{
			"distributed" => TextAlignmentType.Distributed, 
			"justify" => TextAlignmentType.Justify, 
			"bottom" => TextAlignmentType.Bottom, 
			"center" => TextAlignmentType.Center, 
			"top" => TextAlignmentType.Top, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid Vertical AlignmentType string value"), 
		};
	}

	internal static int smethod_41(XmlTextReader xmlTextReader_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("count");
		if (attribute != null)
		{
			return smethod_87(attribute);
		}
		return 0;
	}

	internal static ValidationAlertType smethod_42(string string_4)
	{
		return string_4 switch
		{
			"stop" => ValidationAlertType.Stop, 
			"warning" => ValidationAlertType.Warning, 
			"information" => ValidationAlertType.Information, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid ValidationAlertType string val"), 
		};
	}

	internal static Enum228 smethod_43(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_151 == null)
			{
				Class1742.dictionary_151 = new Dictionary<string, int>(11)
				{
					{ "off", 0 },
					{ "on", 1 },
					{ "noControl", 2 },
					{ "disabled", 3 },
					{ "fullKatakana", 4 },
					{ "halfKatakana", 5 },
					{ "fullAlpha", 6 },
					{ "halfAlpha", 7 },
					{ "hiragana", 8 },
					{ "halfhangul", 9 },
					{ "fullhangul", 10 }
				};
			}
			if (Class1742.dictionary_151.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return Enum228.const_2;
				case 1:
					return Enum228.const_1;
				case 2:
					return Enum228.const_0;
				case 3:
					return Enum228.const_3;
				case 4:
					return Enum228.const_5;
				case 5:
					return Enum228.const_6;
				case 6:
					return Enum228.const_7;
				case 7:
					return Enum228.const_8;
				case 8:
					return Enum228.const_4;
				case 9:
					return Enum228.const_10;
				case 10:
					return Enum228.const_9;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid IMEModeType string val");
	}

	internal static string smethod_44(Enum228 enum228_0)
	{
		return enum228_0 switch
		{
			Enum228.const_0 => "noControl", 
			Enum228.const_1 => "on", 
			Enum228.const_2 => "off", 
			Enum228.const_3 => "disabled", 
			Enum228.const_4 => "hiragana", 
			Enum228.const_5 => "fullKatakana", 
			Enum228.const_6 => "halfKatakana", 
			Enum228.const_7 => "fullAlpha", 
			Enum228.const_8 => "halfAlpha", 
			Enum228.const_9 => "fullhangul", 
			Enum228.const_10 => "halfhangul", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid IMEModeType"), 
		};
	}

	internal static string smethod_45(string string_4, int int_0, ImageFormat imageFormat_0)
	{
		return smethod_46(string_4) + int_0 + smethod_47(imageFormat_0);
	}

	internal static string smethod_46(string string_4)
	{
		return string_4.Replace("%", "_").Replace("+", "_").Replace(" ", "_")
			.Replace("?", "_")
			.Replace("/", "_")
			.Replace("#", "_")
			.Replace("&", "_")
			.Replace("=", "_");
	}

	internal static string smethod_47(ImageFormat imageFormat_0)
	{
		if (imageFormat_0.Equals(ImageFormat.Jpeg))
		{
			return ".jpeg";
		}
		if (imageFormat_0.Equals(ImageFormat.Png))
		{
			return ".png";
		}
		if (imageFormat_0.Equals(ImageFormat.Emf))
		{
			return ".emf";
		}
		if (imageFormat_0.Equals(ImageFormat.Wmf))
		{
			return ".wmf";
		}
		if (imageFormat_0.Equals(ImageFormat.Bmp))
		{
			return ".bmp";
		}
		if (imageFormat_0.Equals(ImageFormat.Gif))
		{
			return ".gif";
		}
		return null;
	}

	internal static int smethod_48(int int_0, int int_1)
	{
		return (int)((double)int_0 / 12700.0 / 72.0 * (double)int_1 + 0.5);
	}

	internal static double smethod_49(int int_0)
	{
		return (double)int_0 / 12700.0;
	}

	internal static int smethod_50(int int_0, int int_1)
	{
		return (int)((double)int_0 * 72.0 / (double)int_1 * 12700.0 + 0.5);
	}

	internal static int smethod_51(double double_0)
	{
		return (int)(double_0 * 12700.0 + 0.5);
	}

	internal static string smethod_52(PlacementType placementType_0)
	{
		return placementType_0 switch
		{
			PlacementType.FreeFloating => "absolute", 
			PlacementType.Move => "oneCell", 
			PlacementType.MoveAndSize => "twoCell", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid PlacementType val"), 
		};
	}

	internal static PlacementType smethod_53(string string_4)
	{
		return string_4 switch
		{
			"twoCell" => PlacementType.MoveAndSize, 
			"oneCell" => PlacementType.Move, 
			"absolute" => PlacementType.FreeFloating, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid PlacementType string val"), 
		};
	}

	internal static string smethod_54(MsoLineStyle msoLineStyle_0)
	{
		return msoLineStyle_0 switch
		{
			MsoLineStyle.Single => "sng", 
			MsoLineStyle.ThickBetweenThin => "tri", 
			MsoLineStyle.ThinThick => "thinThick", 
			MsoLineStyle.ThickThin => "thickThin", 
			MsoLineStyle.ThinThin => "dbl", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid MsoLineStyle val"), 
		};
	}

	internal static MsoLineStyle smethod_55(string string_4)
	{
		return string_4 switch
		{
			"sng" => MsoLineStyle.Single, 
			"tri" => MsoLineStyle.ThickBetweenThin, 
			"thinThick" => MsoLineStyle.ThinThick, 
			"thickThin" => MsoLineStyle.ThickThin, 
			"dbl" => MsoLineStyle.ThinThin, 
			_ => MsoLineStyle.Single, 
		};
	}

	internal static string smethod_56(MsoLineStyle msoLineStyle_0)
	{
		return msoLineStyle_0 switch
		{
			MsoLineStyle.Single => "single", 
			MsoLineStyle.ThickBetweenThin => "thickBetweenThin", 
			MsoLineStyle.ThinThick => "thinThick", 
			MsoLineStyle.ThickThin => "thickThin", 
			MsoLineStyle.ThinThin => "thinThin", 
			_ => "single", 
		};
	}

	internal static MsoLineStyle smethod_57(string string_4)
	{
		return string_4 switch
		{
			"single" => MsoLineStyle.Single, 
			"thickBetweenThin" => MsoLineStyle.ThickBetweenThin, 
			"thinThick" => MsoLineStyle.ThinThick, 
			"thickThin" => MsoLineStyle.ThickThin, 
			"thinThin" => MsoLineStyle.ThinThin, 
			_ => MsoLineStyle.Single, 
		};
	}

	internal static string smethod_58(MsoLineDashStyle msoLineDashStyle_0)
	{
		return msoLineDashStyle_0 switch
		{
			MsoLineDashStyle.Dash => "dash", 
			MsoLineDashStyle.DashDot => "dashDot", 
			MsoLineDashStyle.DashDotDot => "lgDashDotDot", 
			MsoLineDashStyle.DashLongDash => "lgDash", 
			MsoLineDashStyle.DashLongDashDot => "lgDashDot", 
			MsoLineDashStyle.RoundDot => "sysDot", 
			MsoLineDashStyle.Solid => "solid", 
			MsoLineDashStyle.SquareDot => "sysDash", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid MsoLineDashStyle val"), 
		};
	}

	internal static MsoLineDashStyle smethod_59(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_152 == null)
			{
				Class1742.dictionary_152 = new Dictionary<string, int>(8)
				{
					{ "sysDot", 0 },
					{ "sysDash", 1 },
					{ "dash", 2 },
					{ "dashDot", 3 },
					{ "lgDash", 4 },
					{ "lgDashDot", 5 },
					{ "lgDashDotDot", 6 },
					{ "solid", 7 }
				};
			}
			if (Class1742.dictionary_152.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return MsoLineDashStyle.RoundDot;
				case 1:
					return MsoLineDashStyle.SquareDot;
				case 2:
					return MsoLineDashStyle.Dash;
				case 3:
					return MsoLineDashStyle.DashDot;
				case 4:
					return MsoLineDashStyle.DashLongDash;
				case 5:
					return MsoLineDashStyle.DashLongDashDot;
				case 6:
					return MsoLineDashStyle.DashDotDot;
				case 7:
					return MsoLineDashStyle.Solid;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid MsoLineDashStyle string val");
	}

	internal static string smethod_60(MsoLineDashStyle msoLineDashStyle_0)
	{
		return msoLineDashStyle_0 switch
		{
			MsoLineDashStyle.Dash => "dash", 
			MsoLineDashStyle.DashDot => "dashdot", 
			MsoLineDashStyle.DashDotDot => "longdashdotdot", 
			MsoLineDashStyle.DashLongDash => "longdash", 
			MsoLineDashStyle.DashLongDashDot => "longdashdot", 
			MsoLineDashStyle.RoundDot => "dot", 
			MsoLineDashStyle.Solid => "solid", 
			MsoLineDashStyle.SquareDot => "shortdash", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid MsoLineDashStyle val"), 
		};
	}

	internal static MsoLineDashStyle smethod_61(string string_4)
	{
		if (string_4 == null)
		{
			return MsoLineDashStyle.Solid;
		}
		string key;
		if ((key = string_4.ToLower()) != null)
		{
			if (Class1742.dictionary_153 == null)
			{
				Class1742.dictionary_153 = new Dictionary<string, int>(8)
				{
					{ "dot", 0 },
					{ "shortdash", 1 },
					{ "dash", 2 },
					{ "dashdot", 3 },
					{ "longdash", 4 },
					{ "longdashdot", 5 },
					{ "longdashdotdot", 6 },
					{ "solid", 7 }
				};
			}
			if (Class1742.dictionary_153.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return MsoLineDashStyle.RoundDot;
				case 1:
					return MsoLineDashStyle.SquareDot;
				case 2:
					return MsoLineDashStyle.Dash;
				case 3:
					return MsoLineDashStyle.DashDot;
				case 4:
					return MsoLineDashStyle.DashLongDash;
				case 5:
					return MsoLineDashStyle.DashLongDashDot;
				case 6:
					return MsoLineDashStyle.DashDotDot;
				}
			}
		}
		return MsoLineDashStyle.Solid;
	}

	internal static int smethod_62(string string_4)
	{
		return int.Parse(string_4, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
	}

	internal static Color smethod_63(string string_4)
	{
		int argb = int.Parse(string_4, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		return Color.FromArgb(argb);
	}

	internal static string smethod_64(Color color_0)
	{
		int int_ = color_0.ToArgb();
		return Class1025.smethod_7(int_).Substring(2);
	}

	internal static string smethod_65(LegendPositionType legendPositionType_0)
	{
		return legendPositionType_0 switch
		{
			LegendPositionType.Bottom => "b", 
			LegendPositionType.Corner => "tr", 
			LegendPositionType.Top => "t", 
			LegendPositionType.Right => "r", 
			LegendPositionType.Left => "l", 
			LegendPositionType.NotDocked => "r", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid LegendPositionType val"), 
		};
	}

	internal static LegendPositionType smethod_66(string string_4)
	{
		return string_4 switch
		{
			"tr" => LegendPositionType.Corner, 
			"t" => LegendPositionType.Top, 
			"l" => LegendPositionType.Left, 
			"b" => LegendPositionType.Bottom, 
			"r" => LegendPositionType.Right, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid LegendPositionType string val"), 
		};
	}

	internal static string smethod_67(TickMarkType tickMarkType_0)
	{
		return tickMarkType_0 switch
		{
			TickMarkType.Cross => "cross", 
			TickMarkType.Inside => "in", 
			TickMarkType.None => "none", 
			TickMarkType.Outside => "out", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid TickMarkType val"), 
		};
	}

	internal static TickMarkType smethod_68(string string_4)
	{
		return string_4 switch
		{
			"out" => TickMarkType.Outside, 
			"none" => TickMarkType.None, 
			"in" => TickMarkType.Inside, 
			"cross" => TickMarkType.Cross, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid TickMarkType string val"), 
		};
	}

	internal static string smethod_69(TickLabelPositionType tickLabelPositionType_0)
	{
		return tickLabelPositionType_0 switch
		{
			TickLabelPositionType.High => "high", 
			TickLabelPositionType.Low => "low", 
			TickLabelPositionType.NextToAxis => "nextTo", 
			TickLabelPositionType.None => "none", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid TickLabelPositionType val"), 
		};
	}

	internal static TickLabelPositionType smethod_70(string string_4)
	{
		return string_4 switch
		{
			"none" => TickLabelPositionType.None, 
			"nextTo" => TickLabelPositionType.NextToAxis, 
			"low" => TickLabelPositionType.Low, 
			"high" => TickLabelPositionType.High, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid TickLabelPositionType string val"), 
		};
	}

	internal static string smethod_71(CrossType crossType_0)
	{
		return crossType_0 switch
		{
			CrossType.Automatic => "autoZero", 
			CrossType.Maximum => "max", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid CrossType val"), 
		};
	}

	internal static CrossType smethod_72(string string_4)
	{
		return string_4 switch
		{
			"min" => CrossType.Custom, 
			"max" => CrossType.Maximum, 
			"autoZero" => CrossType.Automatic, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid CrossType string val"), 
		};
	}

	internal static TextDirectionType smethod_73(string string_4)
	{
		return string_4 switch
		{
			"r" => TextDirectionType.RightToLeft, 
			"l" => TextDirectionType.LeftToRight, 
			"ctr" => TextDirectionType.Context, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid TextDirectionType string val"), 
		};
	}

	internal static string smethod_74(TextDirectionType textDirectionType_0)
	{
		return textDirectionType_0 switch
		{
			TextDirectionType.Context => "0", 
			TextDirectionType.LeftToRight => "1", 
			TextDirectionType.RightToLeft => "2", 
			_ => "0", 
		};
	}

	internal static TextDirectionType smethod_75(string string_4)
	{
		return string_4 switch
		{
			"2" => TextDirectionType.RightToLeft, 
			"1" => TextDirectionType.LeftToRight, 
			"0" => TextDirectionType.Context, 
			_ => TextDirectionType.Context, 
		};
	}

	internal static string smethod_76(FontUnderlineType fontUnderlineType_0)
	{
		switch (fontUnderlineType_0)
		{
		default:
			throw new CellsException(ExceptionType.InvalidData, "Invalid FontUnderlineType value");
		case FontUnderlineType.None:
			return "none";
		case FontUnderlineType.Single:
		case FontUnderlineType.Accounting:
			return "sng";
		case FontUnderlineType.Double:
		case FontUnderlineType.DoubleAccounting:
			return "dbl";
		}
	}

	internal static FontUnderlineType smethod_77(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_154 == null)
			{
				Class1742.dictionary_154 = new Dictionary<string, int>(17)
				{
					{ "none", 0 },
					{ "dbl", 1 },
					{ "sng", 2 },
					{ "heavy", 3 },
					{ "dotted", 4 },
					{ "dottedHeavy", 5 },
					{ "dash", 6 },
					{ "dashHeavy", 7 },
					{ "dashLong", 8 },
					{ "dashLongHeavy", 9 },
					{ "dotDash", 10 },
					{ "dotDashHeavy", 11 },
					{ "dotDotDash", 12 },
					{ "dotDotDashHeavy", 13 },
					{ "wavy", 14 },
					{ "wavyHeavy", 15 },
					{ "wavyDbl", 16 }
				};
			}
			if (Class1742.dictionary_154.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return FontUnderlineType.None;
				case 1:
					return FontUnderlineType.Double;
				case 2:
					return FontUnderlineType.Single;
				case 3:
					return FontUnderlineType.Heavy;
				case 4:
					return FontUnderlineType.Dotted;
				case 5:
					return FontUnderlineType.DottedHeavy;
				case 6:
					return FontUnderlineType.Dash;
				case 7:
					return FontUnderlineType.DashedHeavy;
				case 8:
					return FontUnderlineType.DashLong;
				case 9:
					return FontUnderlineType.DashLongHeavy;
				case 10:
					return FontUnderlineType.DotDash;
				case 11:
					return FontUnderlineType.DashDotHeavy;
				case 12:
					return FontUnderlineType.DotDotDash;
				case 13:
					return FontUnderlineType.DashDotDotHeavy;
				case 14:
					return FontUnderlineType.Wave;
				case 15:
					return FontUnderlineType.WavyHeavy;
				case 16:
					return FontUnderlineType.WavyDouble;
				}
			}
		}
		return FontUnderlineType.Single;
	}

	internal static string smethod_78(int int_0)
	{
		switch (int_0)
		{
		case 0:
			return "General";
		case 1:
			return "0";
		case 2:
			return "0.00";
		case 3:
			return "#,##0";
		case 4:
			return "#,##0.00";
		case 5:
			return "$#,##0;($#,##0)";
		case 6:
			return "$#,##0;[Red]($#,##0)";
		case 7:
			return "$#,##0.00;($#,##0.00)";
		case 8:
			return "$#,##0.00;[Red]($#,##0.00)";
		case 9:
			return "0%";
		case 10:
			return "0.00%";
		case 11:
			return "0.00E+00";
		case 12:
			return "# ?/?";
		case 13:
			return "# ??/??";
		case 14:
			return "m/d/yy";
		case 15:
			return "d-mmm-yy";
		case 16:
			return "d-mmm";
		case 17:
			return "mmm-yy";
		case 18:
			return "h:mm AM/PM";
		case 19:
			return "h:mm:ss AM/PM";
		case 20:
			return "h:mm";
		case 21:
			return "h:mm:ss";
		case 22:
			return "m/d/yy h:mm";
		default:
			return "General";
		case 30:
			return "M/d/yy";
		case 31:
			return "yyyy\"年\"M\"月\"d\"日\"";
		case 32:
			return "h\"时\"mm\"分\"";
		case 33:
			return "h\"时\"mm\"分\"ss\"秒\"";
		case 37:
			return "#,##0;-#,##0";
		case 38:
			return "#,##0;[Red](#,##0)";
		case 39:
			return "#,##0.00;(#,##0.00)";
		case 40:
			return "#,##0.00;[Red](#,##0.00)";
		case 41:
			return "_ * #,##0_ ;_ * (#,##0)_ ;_ * \" - \"_ ;_ @_ ";
		case 42:
			return "_ $* #,##0_ ;_ $* (#,##0)_ ;_ $* \" - \"_ ;_ @_ ";
		case 43:
			return "_ * #,##0.00_ ;_ * (#,##0.00)_ ;_ * \" - \"??_ ;_ @_ ";
		case 44:
			return "_ $* #,##0.00_ ;_ $* (#,##0.00)_ ;_ $* \" - \"??_ ;_ @_ ";
		case 45:
			return "mm:ss";
		case 46:
			return "[h]:mm:ss";
		case 47:
			return "mm:ss.0";
		case 48:
			return "##0.0E+00";
		case 49:
			return "@";
		case 34:
		case 55:
			return "tth\"时\"mm\"分\"";
		case 35:
		case 56:
			return "tth\"时\"mm\"分\"ss\"秒\"";
		case 27:
		case 36:
		case 50:
		case 52:
		case 57:
			return "yyyy\"年\"M\"月\"";
		case 28:
		case 29:
		case 51:
		case 53:
		case 54:
		case 58:
			return "M\"月\"d\"日\"";
		}
	}

	internal static string smethod_79(double double_0)
	{
		return double_0.ToString(CultureInfo.InvariantCulture);
	}

	internal static string smethod_80(int int_0)
	{
		return int_0.ToString(CultureInfo.InvariantCulture);
	}

	internal static string smethod_81(uint uint_0)
	{
		return uint_0.ToString(CultureInfo.InvariantCulture);
	}

	internal static string smethod_82(float float_0)
	{
		return float_0.ToString(CultureInfo.InvariantCulture);
	}

	internal static string smethod_83(short short_0)
	{
		return short_0.ToString(CultureInfo.InvariantCulture);
	}

	internal static string smethod_84(byte byte_0)
	{
		return byte_0.ToString(CultureInfo.InvariantCulture);
	}

	internal static double smethod_85(string string_4)
	{
		return double.Parse(string_4, CultureInfo.InvariantCulture);
	}

	internal static decimal smethod_86(string string_4)
	{
		return decimal.Parse(string_4, CultureInfo.InvariantCulture);
	}

	internal static int smethod_87(string string_4)
	{
		return int.Parse(string_4, CultureInfo.InvariantCulture);
	}

	internal static uint smethod_88(string string_4)
	{
		return uint.Parse(string_4, CultureInfo.InvariantCulture);
	}

	internal static short smethod_89(string string_4)
	{
		return short.Parse(string_4, CultureInfo.InvariantCulture);
	}

	internal static bool smethod_90(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_155 == null)
			{
				Class1742.dictionary_155 = new Dictionary<string, int>(18)
				{
					{ "cellIs", 0 },
					{ "expression", 1 },
					{ "colorScale", 2 },
					{ "dataBar", 3 },
					{ "iconSet", 4 },
					{ "aboveAverage", 5 },
					{ "beginsWith", 6 },
					{ "containsBlanks", 7 },
					{ "containsErrors", 8 },
					{ "containsText", 9 },
					{ "duplicateValues", 10 },
					{ "endsWith", 11 },
					{ "notContainsBlanks", 12 },
					{ "notContainsErrors", 13 },
					{ "notContainsText", 14 },
					{ "timePeriod", 15 },
					{ "top10", 16 },
					{ "uniqueValues", 17 }
				};
			}
			if (Class1742.dictionary_155.TryGetValue(key, out var value))
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
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
				case 17:
					return true;
				}
			}
		}
		return false;
	}

	internal static FormatConditionType smethod_91(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_156 == null)
			{
				Class1742.dictionary_156 = new Dictionary<string, int>(18)
				{
					{ "cellIs", 0 },
					{ "expression", 1 },
					{ "colorScale", 2 },
					{ "dataBar", 3 },
					{ "iconSet", 4 },
					{ "aboveAverage", 5 },
					{ "beginsWith", 6 },
					{ "containsBlanks", 7 },
					{ "containsErrors", 8 },
					{ "containsText", 9 },
					{ "duplicateValues", 10 },
					{ "endsWith", 11 },
					{ "notContainsBlanks", 12 },
					{ "notContainsErrors", 13 },
					{ "notContainsText", 14 },
					{ "timePeriod", 15 },
					{ "top10", 16 },
					{ "uniqueValues", 17 }
				};
			}
			if (Class1742.dictionary_156.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return FormatConditionType.CellValue;
				case 1:
					return FormatConditionType.Expression;
				case 2:
					return FormatConditionType.ColorScale;
				case 3:
					return FormatConditionType.DataBar;
				case 4:
					return FormatConditionType.IconSet;
				case 5:
					return FormatConditionType.AboveAverage;
				case 6:
					return FormatConditionType.BeginsWith;
				case 7:
					return FormatConditionType.ContainsBlanks;
				case 8:
					return FormatConditionType.ContainsErrors;
				case 9:
					return FormatConditionType.ContainsText;
				case 10:
					return FormatConditionType.DuplicateValues;
				case 11:
					return FormatConditionType.EndsWith;
				case 12:
					return FormatConditionType.NotContainsBlanks;
				case 13:
					return FormatConditionType.NotContainsErrors;
				case 14:
					return FormatConditionType.NotContainsText;
				case 15:
					return FormatConditionType.TimePeriod;
				case 16:
					return FormatConditionType.Top10;
				case 17:
					return FormatConditionType.UniqueValues;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid FormatConditionType string val");
	}

	internal static string smethod_92(FormatConditionType formatConditionType_0)
	{
		return formatConditionType_0 switch
		{
			FormatConditionType.CellValue => "cellIs", 
			FormatConditionType.Expression => "expression", 
			FormatConditionType.ColorScale => "colorScale", 
			FormatConditionType.DataBar => "dataBar", 
			FormatConditionType.IconSet => "iconSet", 
			FormatConditionType.Top10 => "top10", 
			FormatConditionType.UniqueValues => "uniqueValues", 
			FormatConditionType.DuplicateValues => "duplicateValues", 
			FormatConditionType.ContainsText => "containsText", 
			FormatConditionType.NotContainsText => "notContainsText", 
			FormatConditionType.BeginsWith => "beginsWith", 
			FormatConditionType.EndsWith => "endsWith", 
			FormatConditionType.ContainsBlanks => "containsBlanks", 
			FormatConditionType.NotContainsBlanks => "notContainsBlanks", 
			FormatConditionType.ContainsErrors => "containsErrors", 
			FormatConditionType.NotContainsErrors => "notContainsErrors", 
			FormatConditionType.TimePeriod => "timePeriod", 
			FormatConditionType.AboveAverage => "aboveAverage", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid FormatConditionType val"), 
		};
	}

	internal static string smethod_93(string string_4)
	{
		if (string_4 == null)
		{
			return null;
		}
		string_4 = string_4.Trim();
		if (string_4.Length > 1 && string_4[0] == '=')
		{
			return string_4.Substring(1).Trim();
		}
		return string_4;
	}

	internal static string smethod_94(TextAlignmentType textAlignmentType_0)
	{
		return textAlignmentType_0 switch
		{
			TextAlignmentType.Top => "t", 
			TextAlignmentType.Bottom => "b", 
			TextAlignmentType.Center => "ctr", 
			TextAlignmentType.Distributed => "dist", 
			TextAlignmentType.Justify => "just", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid TextAlignmentType val"), 
		};
	}

	internal static TextAlignmentType smethod_95(string string_4)
	{
		return string_4 switch
		{
			"t" => TextAlignmentType.Top, 
			"just" => TextAlignmentType.Justify, 
			"dist" => TextAlignmentType.Distributed, 
			"ctr" => TextAlignmentType.Center, 
			"b" => TextAlignmentType.Bottom, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid ChartTextAnchor string val"), 
		};
	}

	internal static string smethod_96(TextAlignmentType textAlignmentType_0)
	{
		return textAlignmentType_0 switch
		{
			TextAlignmentType.Center => "ctr", 
			TextAlignmentType.Distributed => "dist", 
			TextAlignmentType.Justify => "just", 
			TextAlignmentType.Left => "l", 
			TextAlignmentType.Right => "r", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid TextAlignmentType val"), 
		};
	}

	internal static TextAlignmentType smethod_97(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_157 == null)
			{
				Class1742.dictionary_157 = new Dictionary<string, int>(7)
				{
					{ "r", 0 },
					{ "ctr", 1 },
					{ "dist", 2 },
					{ "just", 3 },
					{ "l", 4 },
					{ "thaiDist", 5 },
					{ "justLow", 6 }
				};
			}
			if (Class1742.dictionary_157.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return TextAlignmentType.Right;
				case 1:
					return TextAlignmentType.Center;
				case 2:
					return TextAlignmentType.Distributed;
				case 3:
					return TextAlignmentType.Justify;
				case 4:
				case 5:
				case 6:
					return TextAlignmentType.Left;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid ChartTextAlignType string val");
	}

	internal static string smethod_98(LabelPositionType labelPositionType_0, ChartType chartType_0)
	{
		if (ChartCollection.smethod_3(chartType_0))
		{
			return labelPositionType_0 switch
			{
				LabelPositionType.BestFit => "bestFit", 
				LabelPositionType.Center => "ctr", 
				LabelPositionType.InsideEnd => "inEnd", 
				LabelPositionType.OutsideEnd => "outEnd", 
				_ => null, 
			};
		}
		if (!ChartCollection.smethod_7(chartType_0) && !ChartCollection.smethod_18(chartType_0))
		{
			if (!ChartCollection.smethod_14(chartType_0) && !ChartCollection.smethod_11(chartType_0) && !ChartCollection.smethod_17(chartType_0))
			{
				if (!ChartCollection.smethod_16(chartType_0) && !ChartCollection.smethod_13(chartType_0) && !smethod_126(chartType_0) && !ChartCollection.smethod_5(chartType_0))
				{
					return null;
				}
				return null;
			}
			return labelPositionType_0 switch
			{
				LabelPositionType.Center => "ctr", 
				LabelPositionType.Above => "t", 
				LabelPositionType.Below => "b", 
				LabelPositionType.Left => "l", 
				LabelPositionType.Right => "r", 
				_ => null, 
			};
		}
		return labelPositionType_0 switch
		{
			LabelPositionType.Center => "ctr", 
			LabelPositionType.InsideBase => "inBase", 
			LabelPositionType.InsideEnd => "inEnd", 
			LabelPositionType.OutsideEnd => "outEnd", 
			_ => null, 
		};
	}

	internal static LabelPositionType smethod_99(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_158 == null)
			{
				Class1742.dictionary_158 = new Dictionary<string, int>(9)
				{
					{ "outEnd", 0 },
					{ "t", 1 },
					{ "b", 2 },
					{ "bestFit", 3 },
					{ "ctr", 4 },
					{ "inBase", 5 },
					{ "inEnd", 6 },
					{ "l", 7 },
					{ "r", 8 }
				};
			}
			if (Class1742.dictionary_158.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return LabelPositionType.OutsideEnd;
				case 1:
					return LabelPositionType.Above;
				case 2:
					return LabelPositionType.Below;
				case 3:
					return LabelPositionType.BestFit;
				case 4:
					return LabelPositionType.Center;
				case 5:
					return LabelPositionType.InsideBase;
				case 6:
					return LabelPositionType.InsideEnd;
				case 7:
					return LabelPositionType.Left;
				case 8:
					return LabelPositionType.Right;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid ChartDLblPos string val");
	}

	internal static string smethod_100(TimeUnit timeUnit_0)
	{
		return timeUnit_0 switch
		{
			TimeUnit.Days => "days", 
			TimeUnit.Months => "months", 
			TimeUnit.Years => "years", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid TimeUnit val"), 
		};
	}

	internal static TimeUnit smethod_101(string string_4)
	{
		return string_4 switch
		{
			"days" => TimeUnit.Days, 
			"years" => TimeUnit.Years, 
			"months" => TimeUnit.Months, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid TimeUnit string val"), 
		};
	}

	internal static string smethod_102(TrendlineType trendlineType_0)
	{
		return trendlineType_0 switch
		{
			TrendlineType.Exponential => "exp", 
			TrendlineType.Linear => "linear", 
			TrendlineType.Logarithmic => "log", 
			TrendlineType.MovingAverage => "movingAvg", 
			TrendlineType.Polynomial => "poly", 
			TrendlineType.Power => "power", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid TrendlineType val"), 
		};
	}

	internal static TrendlineType smethod_103(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_159 == null)
			{
				Class1742.dictionary_159 = new Dictionary<string, int>(6)
				{
					{ "linear", 0 },
					{ "exp", 1 },
					{ "log", 2 },
					{ "movingAvg", 3 },
					{ "poly", 4 },
					{ "power", 5 }
				};
			}
			if (Class1742.dictionary_159.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return TrendlineType.Linear;
				case 1:
					return TrendlineType.Exponential;
				case 2:
					return TrendlineType.Logarithmic;
				case 3:
					return TrendlineType.MovingAverage;
				case 4:
					return TrendlineType.Polynomial;
				case 5:
					return TrendlineType.Power;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid TrendlineType string val");
	}

	internal static string smethod_104(ErrorBarDisplayType errorBarDisplayType_0)
	{
		return errorBarDisplayType_0 switch
		{
			ErrorBarDisplayType.Both => "both", 
			ErrorBarDisplayType.Minus => "minus", 
			ErrorBarDisplayType.Plus => "plus", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid ErrorBarDisplayType val"), 
		};
	}

	internal static ErrorBarDisplayType smethod_105(string string_4)
	{
		return string_4 switch
		{
			"plus" => ErrorBarDisplayType.Plus, 
			"minus" => ErrorBarDisplayType.Minus, 
			"both" => ErrorBarDisplayType.Both, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid ErrorBarDisplayType string val"), 
		};
	}

	internal static string smethod_106(ErrorBarType errorBarType_0)
	{
		return errorBarType_0 switch
		{
			ErrorBarType.Custom => "cust", 
			ErrorBarType.FixedValue => "fixedVal", 
			ErrorBarType.Percent => "percentage", 
			ErrorBarType.StDev => "stdDev", 
			ErrorBarType.StError => "stdErr", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid ErrorBarType val"), 
		};
	}

	internal static ErrorBarType smethod_107(string string_4)
	{
		return string_4 switch
		{
			"cust" => ErrorBarType.Custom, 
			"stdErr" => ErrorBarType.StError, 
			"stdDev" => ErrorBarType.StDev, 
			"percentage" => ErrorBarType.Percent, 
			"fixedVal" => ErrorBarType.FixedValue, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid ErrorBarType string val"), 
		};
	}

	internal static string smethod_108(DataLablesSeparatorType dataLablesSeparatorType_0)
	{
		return dataLablesSeparatorType_0 switch
		{
			DataLablesSeparatorType.Auto => ",", 
			DataLablesSeparatorType.Space => " ", 
			DataLablesSeparatorType.Comma => ",", 
			DataLablesSeparatorType.Semicolon => ";", 
			DataLablesSeparatorType.Period => ".", 
			DataLablesSeparatorType.NewLine => "\n", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid DataLablesSeparatorType val"), 
		};
	}

	internal static DataLablesSeparatorType smethod_109(string string_4)
	{
		if (string_4.IndexOf(",") != -1)
		{
			return DataLablesSeparatorType.Comma;
		}
		if (string_4.IndexOf(".") != -1)
		{
			return DataLablesSeparatorType.Period;
		}
		if (string_4.IndexOf(";") != -1)
		{
			return DataLablesSeparatorType.Semicolon;
		}
		if (string_4.IndexOf(" ") != -1)
		{
			return DataLablesSeparatorType.Space;
		}
		if (string_4.IndexOf("\n") != -1)
		{
			return DataLablesSeparatorType.NewLine;
		}
		return DataLablesSeparatorType.Comma;
	}

	internal static void smethod_110(ChartType type, out string barDir, out string grouping)
	{
		switch (type)
		{
		default:
			throw new CellsException(ExceptionType.InvalidData, "Invalid Bar ChartType val");
		case ChartType.Column:
		case ChartType.Column3DClustered:
		case ChartType.Cone:
		case ChartType.Cylinder:
		case ChartType.Pyramid:
			barDir = "col";
			grouping = "clustered";
			break;
		case ChartType.ColumnStacked:
		case ChartType.Column3DStacked:
		case ChartType.ConeStacked:
		case ChartType.CylinderStacked:
		case ChartType.PyramidStacked:
			barDir = "col";
			grouping = "stacked";
			break;
		case ChartType.Column100PercentStacked:
		case ChartType.Column3D100PercentStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.Pyramid100PercentStacked:
			barDir = "col";
			grouping = "percentStacked";
			break;
		case ChartType.Bar:
		case ChartType.Bar3DClustered:
		case ChartType.ConicalBar:
		case ChartType.CylindricalBar:
		case ChartType.PyramidBar:
			barDir = "bar";
			grouping = "clustered";
			break;
		case ChartType.BarStacked:
		case ChartType.Bar3DStacked:
		case ChartType.ConicalBarStacked:
		case ChartType.CylindricalBarStacked:
		case ChartType.PyramidBarStacked:
			barDir = "bar";
			grouping = "stacked";
			break;
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.PyramidBar100PercentStacked:
			barDir = "bar";
			grouping = "percentStacked";
			break;
		case ChartType.Column3D:
		case ChartType.ConicalColumn3D:
		case ChartType.CylindricalColumn3D:
		case ChartType.PyramidColumn3D:
			barDir = "col";
			grouping = "standard";
			break;
		}
	}

	internal static ChartType smethod_111(string string_4, string string_5, bool bool_2, string string_6)
	{
		bool flag = ((string_4 == "col") ? true : false);
		if (!bool_2)
		{
			switch (string_5)
			{
			case "stacked":
				if (flag)
				{
					return ChartType.ColumnStacked;
				}
				return ChartType.BarStacked;
			case "percentStacked":
				if (flag)
				{
					return ChartType.Column100PercentStacked;
				}
				return ChartType.Bar100PercentStacked;
			case "clustered":
				if (flag)
				{
					return ChartType.Column;
				}
				return ChartType.Bar;
			}
		}
		else
		{
			switch (string_5)
			{
			case "standard":
			{
				string key3;
				if ((key3 = string_6) == null)
				{
					break;
				}
				if (Class1742.dictionary_160 == null)
				{
					Class1742.dictionary_160 = new Dictionary<string, int>(8)
					{
						{ "box", 0 },
						{ "cone", 1 },
						{ "coneToMax", 2 },
						{ "coneToPoint", 3 },
						{ "cylinder", 4 },
						{ "pyramid", 5 },
						{ "pyramidToMax", 6 },
						{ "pyramidToPoint", 7 }
					};
				}
				if (Class1742.dictionary_160.TryGetValue(key3, out var value3))
				{
					switch (value3)
					{
					case 0:
						return ChartType.Column3D;
					case 1:
					case 2:
					case 3:
						return ChartType.ConicalColumn3D;
					case 4:
						return ChartType.CylindricalColumn3D;
					case 5:
					case 6:
					case 7:
						return ChartType.PyramidColumn3D;
					}
				}
				break;
			}
			case "clustered":
			{
				string key2;
				if ((key2 = string_6) == null)
				{
					break;
				}
				if (Class1742.dictionary_161 == null)
				{
					Class1742.dictionary_161 = new Dictionary<string, int>(8)
					{
						{ "box", 0 },
						{ "cone", 1 },
						{ "coneToMax", 2 },
						{ "coneToPoint", 3 },
						{ "cylinder", 4 },
						{ "pyramid", 5 },
						{ "pyramidToMax", 6 },
						{ "pyramidToPoint", 7 }
					};
				}
				if (!Class1742.dictionary_161.TryGetValue(key2, out var value2))
				{
					break;
				}
				switch (value2)
				{
				case 0:
					if (flag)
					{
						return ChartType.Column3DClustered;
					}
					return ChartType.Bar3DClustered;
				case 1:
				case 2:
				case 3:
					if (flag)
					{
						return ChartType.Cone;
					}
					return ChartType.ConicalBar;
				case 4:
					if (flag)
					{
						return ChartType.Cylinder;
					}
					return ChartType.CylindricalBar;
				case 5:
				case 6:
				case 7:
					if (flag)
					{
						return ChartType.Pyramid;
					}
					return ChartType.PyramidBar;
				}
				break;
			}
			case "percentStacked":
			{
				string key4;
				if ((key4 = string_6) == null)
				{
					break;
				}
				if (Class1742.dictionary_162 == null)
				{
					Class1742.dictionary_162 = new Dictionary<string, int>(8)
					{
						{ "box", 0 },
						{ "cone", 1 },
						{ "coneToMax", 2 },
						{ "coneToPoint", 3 },
						{ "cylinder", 4 },
						{ "pyramid", 5 },
						{ "pyramidToMax", 6 },
						{ "pyramidToPoint", 7 }
					};
				}
				if (!Class1742.dictionary_162.TryGetValue(key4, out var value4))
				{
					break;
				}
				switch (value4)
				{
				case 0:
					if (flag)
					{
						return ChartType.Column3D100PercentStacked;
					}
					return ChartType.Bar3D100PercentStacked;
				case 1:
				case 2:
				case 3:
					if (flag)
					{
						return ChartType.Cone100PercentStacked;
					}
					return ChartType.ConicalBar100PercentStacked;
				case 4:
					if (flag)
					{
						return ChartType.Cylinder100PercentStacked;
					}
					return ChartType.CylindricalBar100PercentStacked;
				case 5:
				case 6:
				case 7:
					if (flag)
					{
						return ChartType.Pyramid100PercentStacked;
					}
					return ChartType.PyramidBar100PercentStacked;
				}
				break;
			}
			case "stacked":
			{
				string key;
				if ((key = string_6) == null)
				{
					break;
				}
				if (Class1742.dictionary_163 == null)
				{
					Class1742.dictionary_163 = new Dictionary<string, int>(8)
					{
						{ "box", 0 },
						{ "cone", 1 },
						{ "coneToMax", 2 },
						{ "coneToPoint", 3 },
						{ "cylinder", 4 },
						{ "pyramid", 5 },
						{ "pyramidToMax", 6 },
						{ "pyramidToPoint", 7 }
					};
				}
				if (!Class1742.dictionary_163.TryGetValue(key, out var value))
				{
					break;
				}
				switch (value)
				{
				case 0:
					if (flag)
					{
						return ChartType.Column3DStacked;
					}
					return ChartType.Bar3DStacked;
				case 1:
				case 2:
				case 3:
					if (flag)
					{
						return ChartType.ConeStacked;
					}
					return ChartType.ConicalBarStacked;
				case 4:
					if (flag)
					{
						return ChartType.CylinderStacked;
					}
					return ChartType.CylindricalBarStacked;
				case 5:
				case 6:
				case 7:
					if (flag)
					{
						return ChartType.PyramidStacked;
					}
					return ChartType.PyramidBarStacked;
				}
				break;
			}
			}
		}
		return ChartType.Bar;
	}

	internal static string smethod_112(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			throw new CellsException(ExceptionType.InvalidData, "Invalid area ChartType val");
		case ChartType.Area:
		case ChartType.Area3D:
			return "standard";
		case ChartType.AreaStacked:
		case ChartType.Area3DStacked:
			return "stacked";
		case ChartType.Area100PercentStacked:
		case ChartType.Area3D100PercentStacked:
			return "percentStacked";
		}
	}

	internal static ChartType smethod_113(string string_4, bool bool_2)
	{
		switch (string_4)
		{
		case "percentStacked":
			if (bool_2)
			{
				return ChartType.Area3D100PercentStacked;
			}
			return ChartType.Area100PercentStacked;
		case "stacked":
			if (bool_2)
			{
				return ChartType.Area3DStacked;
			}
			return ChartType.AreaStacked;
		case "standard":
			if (bool_2)
			{
				return ChartType.Area3D;
			}
			return ChartType.Area;
		default:
			throw new CellsException(ExceptionType.InvalidData, "Invalid area grouping val");
		}
	}

	internal static string smethod_114(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			throw new CellsException(ExceptionType.InvalidData, "Invalid Line ChartType val");
		case ChartType.LineStacked:
		case ChartType.LineStackedWithDataMarkers:
			return "stacked";
		case ChartType.Line100PercentStacked:
		case ChartType.Line100PercentStackedWithDataMarkers:
			return "percentStacked";
		case ChartType.Line:
		case ChartType.LineWithDataMarkers:
		case ChartType.Line3D:
			return "standard";
		}
	}

	internal static ChartType smethod_115(bool bool_2, string string_4)
	{
		if (bool_2)
		{
			switch (string_4)
			{
			case "percentStacked":
				return ChartType.Line100PercentStackedWithDataMarkers;
			case "stacked":
				return ChartType.LineStackedWithDataMarkers;
			case "standard":
				return ChartType.LineWithDataMarkers;
			}
		}
		else
		{
			switch (string_4)
			{
			case "percentStacked":
				return ChartType.Line100PercentStacked;
			case "stacked":
				return ChartType.LineStacked;
			case "standard":
				return ChartType.Line;
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid linechart marker or grouping string val");
	}

	internal static string smethod_116(ChartMarkerType chartMarkerType_0)
	{
		return chartMarkerType_0 switch
		{
			ChartMarkerType.Circle => "circle", 
			ChartMarkerType.Dash => "dash", 
			ChartMarkerType.Diamond => "diamond", 
			ChartMarkerType.Dot => "dot", 
			ChartMarkerType.None => "none", 
			ChartMarkerType.SquarePlus => "plus", 
			ChartMarkerType.Square => "square", 
			ChartMarkerType.SquareStar => "star", 
			ChartMarkerType.Triangle => "triangle", 
			ChartMarkerType.SquareX => "x", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid ChartMarkerType val"), 
		};
	}

	internal static ChartMarkerType smethod_117(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_164 == null)
			{
				Class1742.dictionary_164 = new Dictionary<string, int>(11)
				{
					{ "square", 0 },
					{ "diamond", 1 },
					{ "triangle", 2 },
					{ "x", 3 },
					{ "star", 4 },
					{ "dot", 5 },
					{ "dash", 6 },
					{ "circle", 7 },
					{ "plus", 8 },
					{ "none", 9 },
					{ "picture", 10 }
				};
			}
			if (Class1742.dictionary_164.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return ChartMarkerType.Square;
				case 1:
					return ChartMarkerType.Diamond;
				case 2:
					return ChartMarkerType.Triangle;
				case 3:
					return ChartMarkerType.SquareX;
				case 4:
					return ChartMarkerType.SquareStar;
				case 5:
					return ChartMarkerType.Dot;
				case 6:
					return ChartMarkerType.Dash;
				case 7:
					return ChartMarkerType.Circle;
				case 8:
					return ChartMarkerType.SquarePlus;
				case 9:
					return ChartMarkerType.None;
				case 10:
					return ChartMarkerType.Automatic;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid chart MarkerStyle string val");
	}

	internal static int smethod_118(Aspose.Cells.Font font_0, WorksheetCollection worksheetCollection_0)
	{
		ArrayList arrayList = worksheetCollection_0.method_52();
		int num = 0;
		Aspose.Cells.Font font;
		while (true)
		{
			if (num < arrayList.Count)
			{
				font = (Aspose.Cells.Font)arrayList[num];
				if (font.method_19(font_0))
				{
					break;
				}
				num++;
				continue;
			}
			if (arrayList.Count > 3)
			{
				font_0.method_22(arrayList.Count + 1);
			}
			else
			{
				font_0.method_22(arrayList.Count);
			}
			arrayList.Add(font_0);
			return arrayList.Count;
		}
		return font.method_21();
	}

	internal static int smethod_119(Class1542 class1542_0, WorksheetCollection worksheetCollection_0)
	{
		Aspose.Cells.Font font_ = new Aspose.Cells.Font(worksheetCollection_0, null, bool_0: false);
		class1542_0.method_19(font_);
		return smethod_118(font_, worksheetCollection_0);
	}

	internal static string smethod_120(ChartSplitType chartSplitType_0)
	{
		return chartSplitType_0 switch
		{
			ChartSplitType.Position => "pos", 
			ChartSplitType.Value => "val", 
			ChartSplitType.PercentValue => "percent", 
			ChartSplitType.Custom => "cust", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid ChartSplitType val"), 
		};
	}

	internal static ChartSplitType smethod_121(string string_4)
	{
		return string_4 switch
		{
			"val" => ChartSplitType.Value, 
			"pos" => ChartSplitType.Position, 
			"percent" => ChartSplitType.PercentValue, 
			"cust" => ChartSplitType.Custom, 
			"auto" => ChartSplitType.Position, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid chart splitType string val"), 
		};
	}

	internal static bool smethod_122(ChartType chartType_0)
	{
		return true;
	}

	internal static bool smethod_123(Chart chart_0)
	{
		Class1388 @class = chart_0.method_18();
		int num = 0;
		while (true)
		{
			if (num < @class.Count)
			{
				Class1387 class2 = @class[num];
				ChartType chartType_ = class2.method_11();
				if (!smethod_122(chartType_))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	internal static string smethod_124(ChartType chartType_0)
	{
		return chartType_0 switch
		{
			ChartType.Scatter => "lineMarker", 
			ChartType.ScatterConnectedByCurvesWithDataMarker => "smoothMarker", 
			ChartType.ScatterConnectedByCurvesWithoutDataMarker => "smooth", 
			ChartType.ScatterConnectedByLinesWithDataMarker => "lineMarker", 
			ChartType.ScatterConnectedByLinesWithoutDataMarker => "line", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid scatter ChartType val"), 
		};
	}

	internal static ChartType smethod_125(string string_4)
	{
		return string_4 switch
		{
			"smooth" => ChartType.ScatterConnectedByCurvesWithoutDataMarker, 
			"smoothMarker" => ChartType.ScatterConnectedByCurvesWithDataMarker, 
			"line" => ChartType.ScatterConnectedByLinesWithoutDataMarker, 
			"lineMarker" => ChartType.ScatterConnectedByLinesWithDataMarker, 
			"none" => ChartType.Scatter, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid scatter style val"), 
		};
	}

	internal static bool smethod_126(ChartType chartType_0)
	{
		if (chartType_0 != ChartType.Radar && chartType_0 != ChartType.RadarFilled && chartType_0 != ChartType.RadarWithDataMarkers)
		{
			return false;
		}
		return true;
	}

	internal static string smethod_127(ChartType chartType_0)
	{
		return chartType_0 switch
		{
			ChartType.Radar => "standard", 
			ChartType.RadarWithDataMarkers => "marker", 
			ChartType.RadarFilled => "filled", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid radar ChartType val"), 
		};
	}

	internal static ChartType smethod_128(string string_4)
	{
		return string_4 switch
		{
			"filled" => ChartType.RadarFilled, 
			"standard" => ChartType.Radar, 
			"marker" => ChartType.RadarWithDataMarkers, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid radar style val"), 
		};
	}

	internal static string smethod_129(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		case ChartType.Bar3DClustered:
		case ChartType.Bar3DStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.Column3D:
		case ChartType.Column3DClustered:
		case ChartType.Column3DStacked:
		case ChartType.Column3D100PercentStacked:
			return "box";
		case ChartType.Cone:
		case ChartType.ConeStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBar:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.ConicalColumn3D:
			return "cone";
		case ChartType.Cylinder:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.CylindricalColumn3D:
			return "cylinder";
		default:
			return null;
		case ChartType.Pyramid:
		case ChartType.PyramidStacked:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBar:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
		case ChartType.PyramidColumn3D:
			return "pyramid";
		}
	}

	internal static string smethod_130(Bar3DShapeType bar3DShapeType_0)
	{
		return bar3DShapeType_0 switch
		{
			Bar3DShapeType.Box => "box", 
			Bar3DShapeType.PyramidToPoint => "pyramid", 
			Bar3DShapeType.PyramidToMax => "pyramidToMax", 
			Bar3DShapeType.Cylinder => "cylinder", 
			Bar3DShapeType.ConeToPoint => "cone", 
			Bar3DShapeType.ConeToMax => "coneToMax", 
			_ => null, 
		};
	}

	internal static Bar3DShapeType smethod_131(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_165 == null)
			{
				Class1742.dictionary_165 = new Dictionary<string, int>(6)
				{
					{ "box", 0 },
					{ "coneToMax", 1 },
					{ "cone", 2 },
					{ "cylinder", 3 },
					{ "pyramidToMax", 4 },
					{ "pyramid", 5 }
				};
			}
			if (Class1742.dictionary_165.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return Bar3DShapeType.Box;
				case 1:
					return Bar3DShapeType.ConeToMax;
				case 2:
					return Bar3DShapeType.ConeToPoint;
				case 3:
					return Bar3DShapeType.Cylinder;
				case 4:
					return Bar3DShapeType.PyramidToMax;
				case 5:
					return Bar3DShapeType.PyramidToPoint;
				}
			}
		}
		return Bar3DShapeType.Box;
	}

	internal static string smethod_132(FillPattern fillPattern_0)
	{
		return fillPattern_0 switch
		{
			FillPattern.Gray5 => "pct5", 
			FillPattern.Gray10 => "pct10", 
			FillPattern.Gray20 => "pct20", 
			FillPattern.Gray30 => "pct30", 
			FillPattern.Gray40 => "pct40", 
			FillPattern.Gray50 => "pct50", 
			FillPattern.Gray60 => "pct60", 
			FillPattern.Gray70 => "pct70", 
			FillPattern.Gray75 => "pct75", 
			FillPattern.Gray80 => "pct80", 
			FillPattern.Gray90 => "pct90", 
			FillPattern.Gray25 => "pct25", 
			FillPattern.LightDownwardDiagonal => "ltDnDiag", 
			FillPattern.LightUpwardDiagonal => "ltUpDiag", 
			FillPattern.DarkDownwardDiagonal => "dkDnDiag", 
			FillPattern.DarkUpwardDiagonal => "dkUpDiag", 
			FillPattern.WideDownwardDiagonal => "wdDnDiag", 
			FillPattern.WideUpwardDiagonal => "wdUpDiag", 
			FillPattern.LightVertical => "ltVert", 
			FillPattern.LightHorizontal => "ltHorz", 
			FillPattern.NarrowVertical => "narVert", 
			FillPattern.NarrowHorizontal => "narHorz", 
			FillPattern.DarkVertical => "dkVert", 
			FillPattern.DarkHorizontal => "dkHorz", 
			FillPattern.DashedDownwardDiagonal => "dashDnDiag", 
			FillPattern.DashedUpwardDiagonal => "dashUpDiag", 
			FillPattern.DashedVertical => "dashVert", 
			FillPattern.DashedHorizontal => "dashHorz", 
			FillPattern.SmallConfetti => "smConfetti", 
			FillPattern.LargeConfetti => "lgConfetti", 
			FillPattern.ZigZag => "zigZag", 
			FillPattern.Wave => "wave", 
			FillPattern.DiagonalBrick => "diagBrick", 
			FillPattern.HorizontalBrick => "horzBrick", 
			FillPattern.Weave => "weave", 
			FillPattern.Plaid => "plaid", 
			FillPattern.Divot => "divot", 
			FillPattern.DottedGrid => "dotGrid", 
			FillPattern.DottedDiamond => "dotDmnd", 
			FillPattern.Shingle => "shingle", 
			FillPattern.Trellis => "trellis", 
			FillPattern.Sphere => "sphere", 
			FillPattern.SmallGrid => "smGrid", 
			FillPattern.LargeGrid => "lgGrid", 
			FillPattern.SmallCheckerBoard => "smCheck", 
			FillPattern.LargeCheckerBoard => "lgCheck", 
			FillPattern.OutlinedDiamond => "openDmnd", 
			FillPattern.SolidDiamond => "solidDmnd", 
			_ => "pct10", 
		};
	}

	internal static FillPattern smethod_133(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_166 == null)
			{
				Class1742.dictionary_166 = new Dictionary<string, int>(48)
				{
					{ "dashDnDiag", 0 },
					{ "dashHorz", 1 },
					{ "dashUpDiag", 2 },
					{ "dashVert", 3 },
					{ "diagBrick", 4 },
					{ "divot", 5 },
					{ "dkDnDiag", 6 },
					{ "dkHorz", 7 },
					{ "dkUpDiag", 8 },
					{ "dkVert", 9 },
					{ "dotDmnd", 10 },
					{ "dotGrid", 11 },
					{ "horzBrick", 12 },
					{ "lgCheck", 13 },
					{ "lgConfetti", 14 },
					{ "lgGrid", 15 },
					{ "ltDnDiag", 16 },
					{ "ltHorz", 17 },
					{ "ltUpDiag", 18 },
					{ "ltVert", 19 },
					{ "narHorz", 20 },
					{ "narVert", 21 },
					{ "pct10", 22 },
					{ "pct20", 23 },
					{ "pct25", 24 },
					{ "pct30", 25 },
					{ "pct40", 26 },
					{ "pct5", 27 },
					{ "pct50", 28 },
					{ "pct60", 29 },
					{ "pct70", 30 },
					{ "pct75", 31 },
					{ "pct80", 32 },
					{ "pct90", 33 },
					{ "plaid", 34 },
					{ "shingle", 35 },
					{ "smCheck", 36 },
					{ "smConfetti", 37 },
					{ "smGrid", 38 },
					{ "solidDmnd", 39 },
					{ "sphere", 40 },
					{ "trellis", 41 },
					{ "wave", 42 },
					{ "wdDnDiag", 43 },
					{ "wdUpDiag", 44 },
					{ "weave", 45 },
					{ "zigZag", 46 },
					{ "openDmnd", 47 }
				};
			}
			if (Class1742.dictionary_166.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return FillPattern.DashedDownwardDiagonal;
				case 1:
					return FillPattern.DashedHorizontal;
				case 2:
					return FillPattern.DashedUpwardDiagonal;
				case 3:
					return FillPattern.DashedVertical;
				case 4:
					return FillPattern.DiagonalBrick;
				case 5:
					return FillPattern.Divot;
				case 6:
					return FillPattern.DarkDownwardDiagonal;
				case 7:
					return FillPattern.DarkHorizontal;
				case 8:
					return FillPattern.DarkUpwardDiagonal;
				case 9:
					return FillPattern.DarkVertical;
				case 10:
					return FillPattern.DottedDiamond;
				case 11:
					return FillPattern.DottedGrid;
				case 12:
					return FillPattern.HorizontalBrick;
				case 13:
					return FillPattern.LargeCheckerBoard;
				case 14:
					return FillPattern.LargeConfetti;
				case 15:
					return FillPattern.LargeGrid;
				case 16:
					return FillPattern.LightDownwardDiagonal;
				case 17:
					return FillPattern.LightHorizontal;
				case 18:
					return FillPattern.LightUpwardDiagonal;
				case 19:
					return FillPattern.LightVertical;
				case 20:
					return FillPattern.NarrowHorizontal;
				case 21:
					return FillPattern.NarrowVertical;
				case 22:
					return FillPattern.Gray10;
				case 23:
					return FillPattern.Gray20;
				case 24:
					return FillPattern.Gray25;
				case 25:
					return FillPattern.Gray30;
				case 26:
					return FillPattern.Gray40;
				case 27:
					return FillPattern.Gray5;
				case 28:
					return FillPattern.Gray50;
				case 29:
					return FillPattern.Gray60;
				case 30:
					return FillPattern.Gray70;
				case 31:
					return FillPattern.Gray75;
				case 32:
					return FillPattern.Gray80;
				case 33:
					return FillPattern.Gray90;
				case 34:
					return FillPattern.Plaid;
				case 35:
					return FillPattern.Shingle;
				case 36:
					return FillPattern.SmallCheckerBoard;
				case 37:
					return FillPattern.SmallConfetti;
				case 38:
					return FillPattern.SmallGrid;
				case 39:
					return FillPattern.SolidDiamond;
				case 40:
					return FillPattern.Sphere;
				case 41:
					return FillPattern.Trellis;
				case 42:
					return FillPattern.Wave;
				case 43:
					return FillPattern.WideDownwardDiagonal;
				case 44:
					return FillPattern.WideUpwardDiagonal;
				case 45:
					return FillPattern.Weave;
				case 46:
					return FillPattern.ZigZag;
				case 47:
					return FillPattern.OutlinedDiamond;
				}
			}
		}
		return FillPattern.Gray10;
	}

	internal static string smethod_134(IconSetType iconSetType_0)
	{
		return iconSetType_0 switch
		{
			IconSetType.Arrows3 => "3Arrows", 
			IconSetType.ArrowsGray3 => "3ArrowsGray", 
			IconSetType.Flags3 => "3Flags", 
			IconSetType.Signs3 => "3Signs", 
			IconSetType.Symbols3 => "3Symbols", 
			IconSetType.Symbols32 => "3Symbols2", 
			IconSetType.TrafficLights31 => "3TrafficLights1", 
			IconSetType.TrafficLights32 => "3TrafficLights2", 
			IconSetType.Arrows4 => "4Arrows", 
			IconSetType.ArrowsGray4 => "4ArrowsGray", 
			IconSetType.Rating4 => "4Rating", 
			IconSetType.RedToBlack4 => "4RedToBlack", 
			IconSetType.TrafficLights4 => "4TrafficLights", 
			IconSetType.Arrows5 => "5Arrows", 
			IconSetType.ArrowsGray5 => "5ArrowsGray", 
			IconSetType.Quarters5 => "5Quarters", 
			IconSetType.Rating5 => "5Rating", 
			IconSetType.Stars3 => "3Stars", 
			IconSetType.Boxes5 => "5Boxes", 
			IconSetType.Triangles3 => "3Triangles", 
			IconSetType.None => "NoIcons", 
			_ => null, 
		};
	}

	internal static IconSetType smethod_135(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_167 == null)
			{
				Class1742.dictionary_167 = new Dictionary<string, int>(21)
				{
					{ "3Arrows", 0 },
					{ "4Arrows", 1 },
					{ "5Arrows", 2 },
					{ "3ArrowsGray", 3 },
					{ "4ArrowsGray", 4 },
					{ "5ArrowsGray", 5 },
					{ "3Flags", 6 },
					{ "5Quarters", 7 },
					{ "4Rating", 8 },
					{ "5Rating", 9 },
					{ "4RedToBlack", 10 },
					{ "3Signs", 11 },
					{ "3Symbols", 12 },
					{ "3Symbols2", 13 },
					{ "3TrafficLights1", 14 },
					{ "3TrafficLights2", 15 },
					{ "4TrafficLights", 16 },
					{ "3Stars", 17 },
					{ "5Boxes", 18 },
					{ "3Triangles", 19 },
					{ "NoIcons", 20 }
				};
			}
			if (Class1742.dictionary_167.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return IconSetType.Arrows3;
				case 1:
					return IconSetType.Arrows4;
				case 2:
					return IconSetType.Arrows5;
				case 3:
					return IconSetType.ArrowsGray3;
				case 4:
					return IconSetType.ArrowsGray4;
				case 5:
					return IconSetType.ArrowsGray5;
				case 6:
					return IconSetType.Flags3;
				case 7:
					return IconSetType.Quarters5;
				case 8:
					return IconSetType.Rating4;
				case 9:
					return IconSetType.Rating5;
				case 10:
					return IconSetType.RedToBlack4;
				case 11:
					return IconSetType.Signs3;
				case 12:
					return IconSetType.Symbols3;
				case 13:
					return IconSetType.Symbols32;
				case 14:
					return IconSetType.TrafficLights31;
				case 15:
					return IconSetType.TrafficLights32;
				case 16:
					return IconSetType.TrafficLights4;
				case 17:
					return IconSetType.Stars3;
				case 18:
					return IconSetType.Boxes5;
				case 19:
					return IconSetType.Triangles3;
				case 20:
					return IconSetType.None;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid IconSetType val");
	}

	internal static string smethod_136(FormatConditionValueType formatConditionValueType_0)
	{
		return formatConditionValueType_0 switch
		{
			FormatConditionValueType.Formula => "formula", 
			FormatConditionValueType.Max => "max", 
			FormatConditionValueType.Min => "min", 
			FormatConditionValueType.Number => "num", 
			FormatConditionValueType.Percent => "percent", 
			FormatConditionValueType.Percentile => "percentile", 
			FormatConditionValueType.AutomaticMax => "autoMax", 
			FormatConditionValueType.AutomaticMin => "autoMin", 
			_ => null, 
		};
	}

	internal static TextDirectionType smethod_137(string string_4)
	{
		return string_4 switch
		{
			"rightToLeft" => TextDirectionType.RightToLeft, 
			"leftToRight" => TextDirectionType.LeftToRight, 
			_ => TextDirectionType.Context, 
		};
	}

	internal static string smethod_138(TextDirectionType textDirectionType_0)
	{
		return textDirectionType_0 switch
		{
			TextDirectionType.LeftToRight => "leftToRight", 
			TextDirectionType.RightToLeft => "rightToLeft", 
			_ => null, 
		};
	}

	internal static DataBarAxisPosition smethod_139(string string_4)
	{
		return string_4 switch
		{
			"middle" => DataBarAxisPosition.DataBarAxisMidpoint, 
			"none" => DataBarAxisPosition.DataBarAxisNone, 
			_ => DataBarAxisPosition.DataBarAxisAutomatic, 
		};
	}

	internal static string smethod_140(DataBarAxisPosition dataBarAxisPosition_0)
	{
		return dataBarAxisPosition_0 switch
		{
			DataBarAxisPosition.DataBarAxisMidpoint => "middle", 
			DataBarAxisPosition.DataBarAxisNone => "none", 
			_ => null, 
		};
	}

	internal static FormatConditionValueType smethod_141(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_168 == null)
			{
				Class1742.dictionary_168 = new Dictionary<string, int>(8)
				{
					{ "formula", 0 },
					{ "max", 1 },
					{ "min", 2 },
					{ "num", 3 },
					{ "percent", 4 },
					{ "percentile", 5 },
					{ "autoMax", 6 },
					{ "autoMin", 7 }
				};
			}
			if (Class1742.dictionary_168.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return FormatConditionValueType.Formula;
				case 1:
					return FormatConditionValueType.Max;
				case 2:
					return FormatConditionValueType.Min;
				case 3:
					return FormatConditionValueType.Number;
				case 4:
					return FormatConditionValueType.Percent;
				case 5:
					return FormatConditionValueType.Percentile;
				case 6:
					return FormatConditionValueType.AutomaticMax;
				case 7:
					return FormatConditionValueType.AutomaticMin;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid FormatConditionValueType val");
	}

	internal static string smethod_142(TimePeriodType timePeriodType_0)
	{
		return timePeriodType_0 switch
		{
			TimePeriodType.Today => "today", 
			TimePeriodType.Yesterday => "yesterday", 
			TimePeriodType.Tomorrow => "tomorrow", 
			TimePeriodType.Last7Days => "last7Days", 
			TimePeriodType.ThisMonth => "thisMonth", 
			TimePeriodType.LastMonth => "lastMonth", 
			TimePeriodType.NextMonth => "nextMonth", 
			TimePeriodType.ThisWeek => "thisWeek", 
			TimePeriodType.LastWeek => "lastWeek", 
			TimePeriodType.NextWeek => "nextWeek", 
			_ => null, 
		};
	}

	internal static TimePeriodType smethod_143(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_169 == null)
			{
				Class1742.dictionary_169 = new Dictionary<string, int>(10)
				{
					{ "last7Days", 0 },
					{ "lastMonth", 1 },
					{ "lastWeek", 2 },
					{ "nextMonth", 3 },
					{ "nextWeek", 4 },
					{ "thisMonth", 5 },
					{ "thisWeek", 6 },
					{ "today", 7 },
					{ "tomorrow", 8 },
					{ "yesterday", 9 }
				};
			}
			if (Class1742.dictionary_169.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return TimePeriodType.Last7Days;
				case 1:
					return TimePeriodType.LastMonth;
				case 2:
					return TimePeriodType.LastWeek;
				case 3:
					return TimePeriodType.NextMonth;
				case 4:
					return TimePeriodType.NextWeek;
				case 5:
					return TimePeriodType.ThisMonth;
				case 6:
					return TimePeriodType.ThisWeek;
				case 7:
					return TimePeriodType.Today;
				case 8:
					return TimePeriodType.Tomorrow;
				case 9:
					return TimePeriodType.Yesterday;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid TimePeriod val");
	}

	internal static int smethod_144(IconSetType iconSetType_0)
	{
		int result = 0;
		switch (iconSetType_0)
		{
		case IconSetType.Arrows4:
		case IconSetType.ArrowsGray4:
		case IconSetType.Rating4:
		case IconSetType.RedToBlack4:
		case IconSetType.TrafficLights4:
			result = 4;
			break;
		case IconSetType.Arrows5:
		case IconSetType.ArrowsGray5:
		case IconSetType.Quarters5:
		case IconSetType.Rating5:
		case IconSetType.Boxes5:
			result = 5;
			break;
		case IconSetType.Arrows3:
		case IconSetType.ArrowsGray3:
		case IconSetType.Flags3:
		case IconSetType.Signs3:
		case IconSetType.Symbols3:
		case IconSetType.Symbols32:
		case IconSetType.TrafficLights31:
		case IconSetType.TrafficLights32:
		case IconSetType.Stars3:
		case IconSetType.Triangles3:
			result = 3;
			break;
		}
		return result;
	}

	internal static int smethod_145(string string_4)
	{
		if (string_4 != null && string_4.Length != 0)
		{
			int result = -1;
			try
			{
				bool flag = false;
				StringBuilder stringBuilder = new StringBuilder(string_4.Length);
				for (int num = string_4.Length - 1; num >= 0; num--)
				{
					char c = string_4[num];
					if (c < '0' || c > '9')
					{
						break;
					}
					flag = true;
					stringBuilder.Insert(0, c);
				}
				if (flag)
				{
					result = smethod_87(stringBuilder.ToString());
				}
			}
			catch
			{
			}
			return result;
		}
		return -1;
	}

	internal static string smethod_146(PivotTableSourceType pivotTableSourceType_0)
	{
		return pivotTableSourceType_0 switch
		{
			PivotTableSourceType.PivotTable => "scenario", 
			PivotTableSourceType.ListDatabase => "worksheet", 
			PivotTableSourceType.External => "external", 
			PivotTableSourceType.Consilidation => "consolidation", 
			_ => null, 
		};
	}

	internal static PivotTableSourceType smethod_147(string string_4)
	{
		return string_4 switch
		{
			"scenario" => PivotTableSourceType.PivotTable, 
			"external" => PivotTableSourceType.External, 
			"consolidation" => PivotTableSourceType.Consilidation, 
			"worksheet" => PivotTableSourceType.ListDatabase, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid PivotTableSourceType val"), 
		};
	}

	internal static int smethod_148(PivotTableAutoFormatType pivotTableAutoFormatType_0)
	{
		return pivotTableAutoFormatType_0 switch
		{
			PivotTableAutoFormatType.None => 4117, 
			PivotTableAutoFormatType.Report1 => 4096, 
			PivotTableAutoFormatType.Report2 => 4097, 
			PivotTableAutoFormatType.Report3 => 4098, 
			PivotTableAutoFormatType.Report4 => 4099, 
			PivotTableAutoFormatType.Report5 => 4100, 
			PivotTableAutoFormatType.Report6 => 4101, 
			PivotTableAutoFormatType.Report7 => 4102, 
			PivotTableAutoFormatType.Report8 => 4103, 
			PivotTableAutoFormatType.Report9 => 4104, 
			PivotTableAutoFormatType.Report10 => 4105, 
			PivotTableAutoFormatType.Table1 => 4106, 
			PivotTableAutoFormatType.Table2 => 4107, 
			PivotTableAutoFormatType.Table3 => 4108, 
			PivotTableAutoFormatType.Table4 => 4109, 
			PivotTableAutoFormatType.Table5 => 4110, 
			PivotTableAutoFormatType.Table6 => 4111, 
			PivotTableAutoFormatType.Table7 => 4112, 
			PivotTableAutoFormatType.Table8 => 4113, 
			PivotTableAutoFormatType.Table9 => 4114, 
			PivotTableAutoFormatType.Table10 => 4115, 
			_ => 4117, 
		};
	}

	internal static PivotTableAutoFormatType smethod_149(int int_0)
	{
		return int_0 switch
		{
			4096 => PivotTableAutoFormatType.Report1, 
			4097 => PivotTableAutoFormatType.Report2, 
			4098 => PivotTableAutoFormatType.Report3, 
			4099 => PivotTableAutoFormatType.Report4, 
			4100 => PivotTableAutoFormatType.Report5, 
			4101 => PivotTableAutoFormatType.Report6, 
			4102 => PivotTableAutoFormatType.Report7, 
			4103 => PivotTableAutoFormatType.Report8, 
			4104 => PivotTableAutoFormatType.Report9, 
			4105 => PivotTableAutoFormatType.Report10, 
			4106 => PivotTableAutoFormatType.Table1, 
			4107 => PivotTableAutoFormatType.Table2, 
			4108 => PivotTableAutoFormatType.Table3, 
			4109 => PivotTableAutoFormatType.Table4, 
			4110 => PivotTableAutoFormatType.Table5, 
			4111 => PivotTableAutoFormatType.Table6, 
			4112 => PivotTableAutoFormatType.Table7, 
			4113 => PivotTableAutoFormatType.Table8, 
			4114 => PivotTableAutoFormatType.Table9, 
			4115 => PivotTableAutoFormatType.Table10, 
			4117 => PivotTableAutoFormatType.None, 
			_ => PivotTableAutoFormatType.None, 
		};
	}

	internal static string smethod_150(PivotFieldType pivotFieldType_0)
	{
		return pivotFieldType_0 switch
		{
			PivotFieldType.Row => "axisRow", 
			PivotFieldType.Column => "axisCol", 
			PivotFieldType.Page => "axisPage", 
			PivotFieldType.Data => "axisValues", 
			_ => null, 
		};
	}

	internal static string smethod_151(PivotFieldSubtotalType pivotFieldSubtotalType_0)
	{
		return pivotFieldSubtotalType_0 switch
		{
			PivotFieldSubtotalType.Average => "avg", 
			PivotFieldSubtotalType.Automatic => "default", 
			PivotFieldSubtotalType.Sum => "sum", 
			PivotFieldSubtotalType.Count => "count", 
			PivotFieldSubtotalType.Product => "product", 
			PivotFieldSubtotalType.Min => "min", 
			PivotFieldSubtotalType.Max => "max", 
			PivotFieldSubtotalType.Stdev => "stdDev", 
			PivotFieldSubtotalType.CountNums => "countA", 
			PivotFieldSubtotalType.Varp => "varP", 
			PivotFieldSubtotalType.Var => "var", 
			PivotFieldSubtotalType.Stdevp => "stdDevP", 
			_ => null, 
		};
	}

	internal static PivotFieldSubtotalType smethod_152(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_170 == null)
			{
				Class1742.dictionary_170 = new Dictionary<string, int>(15)
				{
					{ "avg", 0 },
					{ "count", 1 },
					{ "countA", 2 },
					{ "max", 3 },
					{ "min", 4 },
					{ "product", 5 },
					{ "stdDev", 6 },
					{ "stdDevP", 7 },
					{ "sum", 8 },
					{ "var", 9 },
					{ "varP", 10 },
					{ "default", 11 },
					{ "blank", 12 },
					{ "grand", 13 },
					{ "data", 14 }
				};
			}
			if (Class1742.dictionary_170.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return PivotFieldSubtotalType.Average;
				case 1:
					return PivotFieldSubtotalType.Count;
				case 2:
					return PivotFieldSubtotalType.CountNums;
				case 3:
					return PivotFieldSubtotalType.Max;
				case 4:
					return PivotFieldSubtotalType.Min;
				case 5:
					return PivotFieldSubtotalType.Product;
				case 6:
					return PivotFieldSubtotalType.Stdev;
				case 7:
					return PivotFieldSubtotalType.Stdevp;
				case 8:
					return PivotFieldSubtotalType.Sum;
				case 9:
					return PivotFieldSubtotalType.Var;
				case 10:
					return PivotFieldSubtotalType.Varp;
				case 11:
				case 12:
				case 13:
				case 14:
					return PivotFieldSubtotalType.Automatic;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid PivotFieldSubtotalType val");
	}

	internal static string smethod_153(ConsolidationFunction consolidationFunction_0)
	{
		return consolidationFunction_0 switch
		{
			ConsolidationFunction.Count => "count", 
			ConsolidationFunction.Average => "average", 
			ConsolidationFunction.Max => "max", 
			ConsolidationFunction.Min => "min", 
			ConsolidationFunction.Product => "product", 
			ConsolidationFunction.CountNums => "countNums", 
			ConsolidationFunction.StdDev => "stdDev", 
			ConsolidationFunction.StdDevp => "stdDevp", 
			ConsolidationFunction.Var => "var", 
			ConsolidationFunction.Varp => "varp", 
			_ => "sum", 
		};
	}

	internal static ConsolidationFunction smethod_154(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_171 == null)
			{
				Class1742.dictionary_171 = new Dictionary<string, int>(11)
				{
					{ "average", 0 },
					{ "count", 1 },
					{ "countNums", 2 },
					{ "max", 3 },
					{ "min", 4 },
					{ "product", 5 },
					{ "stdDev", 6 },
					{ "stdDevp", 7 },
					{ "var", 8 },
					{ "varp", 9 },
					{ "sum", 10 }
				};
			}
			if (Class1742.dictionary_171.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return ConsolidationFunction.Average;
				case 1:
					return ConsolidationFunction.Count;
				case 2:
					return ConsolidationFunction.CountNums;
				case 3:
					return ConsolidationFunction.Max;
				case 4:
					return ConsolidationFunction.Min;
				case 5:
					return ConsolidationFunction.Product;
				case 6:
					return ConsolidationFunction.StdDev;
				case 7:
					return ConsolidationFunction.StdDevp;
				case 8:
					return ConsolidationFunction.Var;
				case 9:
					return ConsolidationFunction.Varp;
				case 10:
					return ConsolidationFunction.Sum;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid ConsolidationFunction val");
	}

	internal static string smethod_155(PivotFieldDataDisplayFormat pivotFieldDataDisplayFormat_0)
	{
		return pivotFieldDataDisplayFormat_0 switch
		{
			PivotFieldDataDisplayFormat.Normal => "normal", 
			PivotFieldDataDisplayFormat.DifferenceFrom => "difference", 
			PivotFieldDataDisplayFormat.PercentageOf => "percent", 
			PivotFieldDataDisplayFormat.PercentageDifferenceFrom => "percentDiff", 
			PivotFieldDataDisplayFormat.RunningTotalIn => "runTotal", 
			PivotFieldDataDisplayFormat.PercentageOfRow => "percentOfRow", 
			PivotFieldDataDisplayFormat.PercentageOfColumn => "percentOfCol", 
			PivotFieldDataDisplayFormat.PercentageOfTotal => "percentOfTotal", 
			PivotFieldDataDisplayFormat.Index => "index", 
			PivotFieldDataDisplayFormat.PercentageOfParentRowTotal => "percentOfParentRow", 
			PivotFieldDataDisplayFormat.PercentageOfParentColumnTotal => "percentOfParentCol", 
			PivotFieldDataDisplayFormat.PercentageOfParentTotal => "percentOfParent", 
			PivotFieldDataDisplayFormat.PercentageOfRunningTotalIn => "percentOfRunningTotal", 
			PivotFieldDataDisplayFormat.RankSmallestToLargest => "rankAscending", 
			PivotFieldDataDisplayFormat.RankLargestToSmallest => "rankDescending", 
			_ => "normal", 
		};
	}

	internal static PivotFieldDataDisplayFormat smethod_156(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_172 == null)
			{
				Class1742.dictionary_172 = new Dictionary<string, int>(15)
				{
					{ "difference", 0 },
					{ "index", 1 },
					{ "normal", 2 },
					{ "percentDiff", 3 },
					{ "percent", 4 },
					{ "percentOfCol", 5 },
					{ "percentOfRow", 6 },
					{ "percentOfTotal", 7 },
					{ "runTotal", 8 },
					{ "percentOfParentRow", 9 },
					{ "percentOfParentCol", 10 },
					{ "percentOfParent", 11 },
					{ "rankAscending", 12 },
					{ "rankDescending", 13 },
					{ "percentOfRunningTotal", 14 }
				};
			}
			if (Class1742.dictionary_172.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return PivotFieldDataDisplayFormat.DifferenceFrom;
				case 1:
					return PivotFieldDataDisplayFormat.Index;
				case 2:
					return PivotFieldDataDisplayFormat.Normal;
				case 3:
					return PivotFieldDataDisplayFormat.PercentageDifferenceFrom;
				case 4:
					return PivotFieldDataDisplayFormat.PercentageOf;
				case 5:
					return PivotFieldDataDisplayFormat.PercentageOfColumn;
				case 6:
					return PivotFieldDataDisplayFormat.PercentageOfRow;
				case 7:
					return PivotFieldDataDisplayFormat.PercentageOfTotal;
				case 8:
					return PivotFieldDataDisplayFormat.RunningTotalIn;
				case 9:
					return PivotFieldDataDisplayFormat.PercentageOfParentRowTotal;
				case 10:
					return PivotFieldDataDisplayFormat.PercentageOfParentColumnTotal;
				case 11:
					return PivotFieldDataDisplayFormat.PercentageOfParentTotal;
				case 12:
					return PivotFieldDataDisplayFormat.RankSmallestToLargest;
				case 13:
					return PivotFieldDataDisplayFormat.RankLargestToSmallest;
				case 14:
					return PivotFieldDataDisplayFormat.PercentageOfRunningTotalIn;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid PivotFieldDataDisplayFormat val");
	}

	internal static string smethod_157(TextAlignmentType textAlignmentType_0)
	{
		switch (textAlignmentType_0)
		{
		default:
			return null;
		case TextAlignmentType.Bottom:
			return "Bottom";
		case TextAlignmentType.Center:
			return "Center";
		case TextAlignmentType.Distributed:
			return "Distributed";
		case TextAlignmentType.CenterAcross:
		case TextAlignmentType.Fill:
		case TextAlignmentType.General:
			return null;
		case TextAlignmentType.Justify:
			return "Justify";
		case TextAlignmentType.Left:
			return "Left";
		case TextAlignmentType.Right:
			return "Right";
		case TextAlignmentType.Top:
			return "Top";
		}
	}

	internal static TextAlignmentType smethod_158(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_173 == null)
			{
				Class1742.dictionary_173 = new Dictionary<string, int>(7)
				{
					{ "Left", 0 },
					{ "Center", 1 },
					{ "Right", 2 },
					{ "Justify", 3 },
					{ "Distributed", 4 },
					{ "Top", 5 },
					{ "Bottom", 6 }
				};
			}
			if (Class1742.dictionary_173.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return TextAlignmentType.Left;
				case 1:
					return TextAlignmentType.Center;
				case 2:
					return TextAlignmentType.Right;
				case 3:
					return TextAlignmentType.Justify;
				case 4:
					return TextAlignmentType.Distributed;
				case 5:
					return TextAlignmentType.Top;
				case 6:
					return TextAlignmentType.Bottom;
				}
			}
		}
		return TextAlignmentType.General;
	}

	internal static int smethod_159(string string_4)
	{
		int num = 0;
		if (!string_4.Equals("lt1") && !string_4.Equals("bg1"))
		{
			if (!string_4.Equals("dk1") && !string_4.Equals("tx1"))
			{
				if (!string_4.Equals("lt2") && !string_4.Equals("bg2"))
				{
					if (!string_4.Equals("dk2") && !string_4.Equals("tx2"))
					{
						if (string_4.Equals("accent1"))
						{
							return 4;
						}
						if (string_4.Equals("accent2"))
						{
							return 5;
						}
						if (string_4.Equals("accent3"))
						{
							return 6;
						}
						if (string_4.Equals("accent4"))
						{
							return 7;
						}
						if (string_4.Equals("accent5"))
						{
							return 8;
						}
						if (string_4.Equals("accent6"))
						{
							return 9;
						}
						if (string_4.Equals("hlink"))
						{
							return 10;
						}
						if (string_4.Equals("folHlink"))
						{
							return 11;
						}
						return 11;
					}
					return 3;
				}
				return 2;
			}
			return 1;
		}
		return 0;
	}

	internal static string smethod_160(int int_0)
	{
		return int_0 switch
		{
			0 => "lt1", 
			1 => "dk1", 
			2 => "lt2", 
			3 => "dk2", 
			4 => "accent1", 
			5 => "accent2", 
			6 => "accent3", 
			7 => "accent4", 
			8 => "accent5", 
			9 => "accent6", 
			10 => "hlink", 
			11 => "folHlink", 
			_ => "lt1", 
		};
	}

	internal static string smethod_161(int int_0)
	{
		string string_ = smethod_160(int_0);
		return smethod_162(string_);
	}

	internal static string smethod_162(string string_4)
	{
		return string_4 switch
		{
			"dk1" => "tx1", 
			"dk2" => "tx2", 
			"lt1" => "bg1", 
			"lt2" => "bg2", 
			_ => string_4, 
		};
	}

	internal static Enum231 smethod_163(string string_4)
	{
		return string_4 switch
		{
			"sq" => Enum231.const_0, 
			"rnd" => Enum231.const_1, 
			"flat" => Enum231.const_2, 
			_ => Enum231.const_3, 
		};
	}

	internal static string smethod_164(Enum231 enum231_0)
	{
		return enum231_0 switch
		{
			Enum231.const_0 => "sq", 
			Enum231.const_1 => "rnd", 
			Enum231.const_2 => "flat", 
			_ => "rnd", 
		};
	}

	internal static MsoLineStyle smethod_165(string string_4)
	{
		return string_4 switch
		{
			"tri" => MsoLineStyle.ThickBetweenThin, 
			"thinThick" => MsoLineStyle.ThinThick, 
			"thickThin" => MsoLineStyle.ThickThin, 
			"sng" => MsoLineStyle.Single, 
			"dbl" => MsoLineStyle.ThinThin, 
			_ => MsoLineStyle.Single, 
		};
	}

	internal static MsoArrowheadLength smethod_166(string string_4)
	{
		return string_4 switch
		{
			"sm" => MsoArrowheadLength.Short, 
			"med" => MsoArrowheadLength.Medium, 
			"lg" => MsoArrowheadLength.Long, 
			_ => MsoArrowheadLength.Medium, 
		};
	}

	internal static string smethod_167(MsoArrowheadLength msoArrowheadLength_0)
	{
		return msoArrowheadLength_0 switch
		{
			MsoArrowheadLength.Short => "sm", 
			MsoArrowheadLength.Medium => "med", 
			MsoArrowheadLength.Long => "lg", 
			_ => "med", 
		};
	}

	internal static MsoArrowheadStyle smethod_168(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_174 == null)
			{
				Class1742.dictionary_174 = new Dictionary<string, int>(6)
				{
					{ "arrow", 0 },
					{ "diamond", 1 },
					{ "none", 2 },
					{ "oval", 3 },
					{ "stealth", 4 },
					{ "triangle", 5 }
				};
			}
			if (Class1742.dictionary_174.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return MsoArrowheadStyle.ArrowOpen;
				case 1:
					return MsoArrowheadStyle.ArrowDiamond;
				case 2:
					return MsoArrowheadStyle.None;
				case 3:
					return MsoArrowheadStyle.ArrowOval;
				case 4:
					return MsoArrowheadStyle.ArrowStealth;
				case 5:
					return MsoArrowheadStyle.Arrow;
				}
			}
		}
		return MsoArrowheadStyle.None;
	}

	internal static string smethod_169(MsoArrowheadStyle msoArrowheadStyle_0)
	{
		return msoArrowheadStyle_0 switch
		{
			MsoArrowheadStyle.None => "none", 
			MsoArrowheadStyle.Arrow => "triangle", 
			MsoArrowheadStyle.ArrowStealth => "stealth", 
			MsoArrowheadStyle.ArrowDiamond => "diamond", 
			MsoArrowheadStyle.ArrowOval => "oval", 
			MsoArrowheadStyle.ArrowOpen => "arrow", 
			_ => "none", 
		};
	}

	internal static MsoArrowheadWidth smethod_170(string string_4)
	{
		return string_4 switch
		{
			"sm" => MsoArrowheadWidth.Narrow, 
			"med" => MsoArrowheadWidth.Medium, 
			"lg" => MsoArrowheadWidth.Wide, 
			_ => MsoArrowheadWidth.Medium, 
		};
	}

	internal static string smethod_171(MsoArrowheadWidth msoArrowheadWidth_0)
	{
		return msoArrowheadWidth_0 switch
		{
			MsoArrowheadWidth.Narrow => "sm", 
			MsoArrowheadWidth.Medium => "med", 
			MsoArrowheadWidth.Wide => "lg", 
			_ => "med", 
		};
	}

	internal static string smethod_172(XmlNode xmlNode_0, string string_4)
	{
		if (!(xmlNode_0 is XmlElement))
		{
			return null;
		}
		return Class1188.smethod_6((XmlElement)xmlNode_0, string_4)?.Value;
	}

	internal static XmlElement smethod_173(XmlNode xmlNode_0, string string_4)
	{
		XmlNodeList childNodes = xmlNode_0.ChildNodes;
		int num = 0;
		XmlElement xmlElement;
		while (true)
		{
			if (num < childNodes.Count)
			{
				if (childNodes[num] is XmlElement)
				{
					xmlElement = (XmlElement)childNodes[num];
					if (xmlElement.LocalName == string_4)
					{
						break;
					}
				}
				num++;
				continue;
			}
			return null;
		}
		return xmlElement;
	}

	internal static string smethod_174(string string_4, string string_5)
	{
		int num = string_4.LastIndexOf("/");
		if (num != -1)
		{
			string_4 = string_4.Substring(0, num + 1);
		}
		return string_4 + string_5;
	}

	internal static string smethod_175(string string_4)
	{
		int num = string_4.LastIndexOf("/");
		if (num != -1)
		{
			string_4 = string_4.Substring(0, num);
		}
		num = string_4.LastIndexOf("/");
		if (num != -1 && string_4.Length > 1)
		{
			string_4 = string_4.Substring(num + 1);
		}
		return string_4;
	}

	internal static string smethod_176(string string_4)
	{
		int num = string_4.LastIndexOf("/");
		if (num != -1)
		{
			string text = string_4.Substring(0, num + 1);
			string text2 = string_4.Substring(num + 1);
			return text + "_rels/" + text2 + ".rels";
		}
		return string_4 + ".rels";
	}

	internal static bool smethod_177(string string_4)
	{
		if (string_4.Length == 0)
		{
			return false;
		}
		char c = string_4[0];
		if (c != ' ' && c != '\n' && c != '\r')
		{
			c = string_4[string_4.Length - 1];
			if (c != ' ' && c != '\n' && c != '\r')
			{
				return false;
			}
			return true;
		}
		return true;
	}

	internal static string smethod_178(DynamicFilterType dynamicFilterType_0)
	{
		return dynamicFilterType_0 switch
		{
			DynamicFilterType.AboveAverage => "aboveAverage", 
			DynamicFilterType.BelowAverage => "belowAverage", 
			DynamicFilterType.LastMonth => "lastMonth", 
			DynamicFilterType.LastQuarter => "lastQuarter", 
			DynamicFilterType.LastWeek => "lastWeek", 
			DynamicFilterType.LastYear => "lastYear", 
			DynamicFilterType.January => "M1", 
			DynamicFilterType.October => "M10", 
			DynamicFilterType.November => "M11", 
			DynamicFilterType.December => "M12", 
			DynamicFilterType.Februray => "M2", 
			DynamicFilterType.March => "M3", 
			DynamicFilterType.April => "M4", 
			DynamicFilterType.May => "M5", 
			DynamicFilterType.June => "M6", 
			DynamicFilterType.July => "M7", 
			DynamicFilterType.August => "M8", 
			DynamicFilterType.September => "M9", 
			DynamicFilterType.NextMonth => "nextMonth", 
			DynamicFilterType.NextQuarter => "nextQuarter", 
			DynamicFilterType.NextWeek => "nextWeek", 
			DynamicFilterType.NextYear => "nextYear", 
			DynamicFilterType.None => "null", 
			DynamicFilterType.Quarter1 => "Q1", 
			DynamicFilterType.Quarter2 => "Q2", 
			DynamicFilterType.Quarter3 => "Q3", 
			DynamicFilterType.Quarter4 => "Q4", 
			DynamicFilterType.ThisMonth => "thisMonth", 
			DynamicFilterType.ThisQuarter => "thisQuarter", 
			DynamicFilterType.ThisWeek => "thisWeek", 
			DynamicFilterType.ThisYear => "thisYear", 
			DynamicFilterType.Today => "today", 
			DynamicFilterType.Tomorrow => "tomorrow", 
			DynamicFilterType.YearToDate => "yearToDate", 
			DynamicFilterType.Yesterday => "yesterday", 
			_ => "null", 
		};
	}

	internal static DynamicFilterType smethod_179(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_175 == null)
			{
				Class1742.dictionary_175 = new Dictionary<string, int>(34)
				{
					{ "aboveAverage", 0 },
					{ "belowAverage", 1 },
					{ "lastMonth", 2 },
					{ "lastQuarter", 3 },
					{ "lastWeek", 4 },
					{ "lastYear", 5 },
					{ "M1", 6 },
					{ "M2", 7 },
					{ "M3", 8 },
					{ "M4", 9 },
					{ "M5", 10 },
					{ "M6", 11 },
					{ "M7", 12 },
					{ "M8", 13 },
					{ "M9", 14 },
					{ "M10", 15 },
					{ "M11", 16 },
					{ "M12", 17 },
					{ "nextMonth", 18 },
					{ "nextQuarter", 19 },
					{ "nextWeek", 20 },
					{ "nextYear", 21 },
					{ "Q1", 22 },
					{ "Q2", 23 },
					{ "Q3", 24 },
					{ "Q4", 25 },
					{ "thisMonth", 26 },
					{ "thisQuarter", 27 },
					{ "thisWeek", 28 },
					{ "thisYear", 29 },
					{ "today", 30 },
					{ "tomorrow", 31 },
					{ "yearToDate", 32 },
					{ "yesterday", 33 }
				};
			}
			if (Class1742.dictionary_175.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return DynamicFilterType.AboveAverage;
				case 1:
					return DynamicFilterType.BelowAverage;
				case 2:
					return DynamicFilterType.LastMonth;
				case 3:
					return DynamicFilterType.LastQuarter;
				case 4:
					return DynamicFilterType.LastWeek;
				case 5:
					return DynamicFilterType.LastYear;
				case 6:
					return DynamicFilterType.January;
				case 7:
					return DynamicFilterType.Februray;
				case 8:
					return DynamicFilterType.March;
				case 9:
					return DynamicFilterType.April;
				case 10:
					return DynamicFilterType.May;
				case 11:
					return DynamicFilterType.June;
				case 12:
					return DynamicFilterType.July;
				case 13:
					return DynamicFilterType.August;
				case 14:
					return DynamicFilterType.September;
				case 15:
					return DynamicFilterType.October;
				case 16:
					return DynamicFilterType.November;
				case 17:
					return DynamicFilterType.December;
				case 18:
					return DynamicFilterType.NextMonth;
				case 19:
					return DynamicFilterType.NextQuarter;
				case 20:
					return DynamicFilterType.NextWeek;
				case 21:
					return DynamicFilterType.NextYear;
				case 22:
					return DynamicFilterType.Quarter1;
				case 23:
					return DynamicFilterType.Quarter2;
				case 24:
					return DynamicFilterType.Quarter3;
				case 25:
					return DynamicFilterType.Quarter4;
				case 26:
					return DynamicFilterType.ThisMonth;
				case 27:
					return DynamicFilterType.ThisQuarter;
				case 28:
					return DynamicFilterType.ThisWeek;
				case 29:
					return DynamicFilterType.ThisYear;
				case 30:
					return DynamicFilterType.Today;
				case 31:
					return DynamicFilterType.Tomorrow;
				case 32:
					return DynamicFilterType.YearToDate;
				case 33:
					return DynamicFilterType.Yesterday;
				}
			}
		}
		return DynamicFilterType.None;
	}

	internal static string smethod_180(DateTimeGroupingType dateTimeGroupingType_0)
	{
		return dateTimeGroupingType_0 switch
		{
			DateTimeGroupingType.Day => "day", 
			DateTimeGroupingType.Hour => "hour", 
			DateTimeGroupingType.Minute => "minute", 
			DateTimeGroupingType.Month => "month", 
			DateTimeGroupingType.Second => "second", 
			DateTimeGroupingType.Year => "year", 
			_ => "day", 
		};
	}

	internal static DateTimeGroupingType smethod_181(string string_4)
	{
		return string_4 switch
		{
			"year" => DateTimeGroupingType.Year, 
			"second" => DateTimeGroupingType.Second, 
			"month" => DateTimeGroupingType.Month, 
			"minute" => DateTimeGroupingType.Minute, 
			"hour" => DateTimeGroupingType.Hour, 
			"day" => DateTimeGroupingType.Day, 
			_ => DateTimeGroupingType.Day, 
		};
	}

	internal static DisplayUnitType smethod_182(string string_4)
	{
		return string_4 switch
		{
			"trillions" => DisplayUnitType.Trillions, 
			"billions" => DisplayUnitType.Billions, 
			"millions" => DisplayUnitType.Millions, 
			"thousands" => DisplayUnitType.Thousands, 
			"hundreds" => DisplayUnitType.Hundreds, 
			_ => DisplayUnitType.None, 
		};
	}

	internal static string smethod_183(DisplayUnitType displayUnitType_0)
	{
		return displayUnitType_0 switch
		{
			DisplayUnitType.Hundreds => "hundreds", 
			DisplayUnitType.Thousands => "thousands", 
			DisplayUnitType.Millions => "millions", 
			DisplayUnitType.Billions => "billions", 
			DisplayUnitType.Trillions => "trillions", 
			_ => "", 
		};
	}

	internal static string smethod_184(Enum128 enum128_0)
	{
		return enum128_0 switch
		{
			Enum128.const_0 => "circle", 
			Enum128.const_2 => "shape", 
			_ => "rect", 
		};
	}

	internal static string smethod_185(FilterOperatorType filterOperatorType_0)
	{
		return filterOperatorType_0 switch
		{
			FilterOperatorType.LessOrEqual => "lessThanOrEqual", 
			FilterOperatorType.LessThan => "lessThan", 
			FilterOperatorType.GreaterThan => "greaterThan", 
			FilterOperatorType.NotEqual => "notEqual", 
			FilterOperatorType.GreaterOrEqual => "greaterThanOrEqual", 
			_ => null, 
		};
	}

	internal static FilterOperatorType smethod_186(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_176 == null)
			{
				Class1742.dictionary_176 = new Dictionary<string, int>(7)
				{
					{ "greaterThan", 0 },
					{ "greaterThanOrEqual", 1 },
					{ "lessThan", 2 },
					{ "lessThanOrEqual", 3 },
					{ "notEqual", 4 },
					{ "equal", 5 },
					{ "none", 6 }
				};
			}
			if (Class1742.dictionary_176.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return FilterOperatorType.GreaterThan;
				case 1:
					return FilterOperatorType.GreaterOrEqual;
				case 2:
					return FilterOperatorType.LessThan;
				case 3:
					return FilterOperatorType.LessOrEqual;
				case 4:
					return FilterOperatorType.NotEqual;
				case 5:
					return FilterOperatorType.Equal;
				case 6:
					return FilterOperatorType.None;
				}
			}
		}
		return FilterOperatorType.Equal;
	}

	internal static Enum128 smethod_187(string string_4)
	{
		return string_4 switch
		{
			"shape" => Enum128.const_2, 
			"circle" => Enum128.const_0, 
			_ => Enum128.const_1, 
		};
	}

	internal static string smethod_188(FillPictureType fillPictureType_0)
	{
		return fillPictureType_0 switch
		{
			FillPictureType.Stretch => "stretch", 
			FillPictureType.Stack => "stack", 
			FillPictureType.StackAndScale => "stackScale", 
			_ => "stretch", 
		};
	}

	internal static FillPictureType smethod_189(string string_4)
	{
		return string_4 switch
		{
			"stackScale" => FillPictureType.StackAndScale, 
			"stretch" => FillPictureType.Stretch, 
			"stack" => FillPictureType.Stack, 
			_ => FillPictureType.Stretch, 
		};
	}

	internal static string smethod_190(MirrorType mirrorType_0)
	{
		return mirrorType_0 switch
		{
			MirrorType.Horizonal => "x", 
			MirrorType.Vertical => "y", 
			MirrorType.Both => "xy", 
			_ => "none", 
		};
	}

	internal static MirrorType smethod_191(string string_4)
	{
		return string_4 switch
		{
			"xy" => MirrorType.Both, 
			"y" => MirrorType.Vertical, 
			"x" => MirrorType.Horizonal, 
			_ => MirrorType.None, 
		};
	}

	internal static string smethod_192(RectangleAlignmentType rectangleAlignmentType_0)
	{
		return rectangleAlignmentType_0 switch
		{
			RectangleAlignmentType.Bottom => "b", 
			RectangleAlignmentType.BottomLeft => "bl", 
			RectangleAlignmentType.BottomRight => "br", 
			RectangleAlignmentType.Center => "ctr", 
			RectangleAlignmentType.Left => "l", 
			RectangleAlignmentType.Right => "r", 
			RectangleAlignmentType.Top => "t", 
			RectangleAlignmentType.TopLeft => "tl", 
			RectangleAlignmentType.TopRight => "tr", 
			_ => "t", 
		};
	}

	internal static RectangleAlignmentType smethod_193(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_177 == null)
			{
				Class1742.dictionary_177 = new Dictionary<string, int>(9)
				{
					{ "b", 0 },
					{ "bl", 1 },
					{ "br", 2 },
					{ "ctr", 3 },
					{ "l", 4 },
					{ "r", 5 },
					{ "t", 6 },
					{ "tl", 7 },
					{ "tr", 8 }
				};
			}
			if (Class1742.dictionary_177.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return RectangleAlignmentType.Bottom;
				case 1:
					return RectangleAlignmentType.BottomLeft;
				case 2:
					return RectangleAlignmentType.BottomRight;
				case 3:
					return RectangleAlignmentType.Center;
				case 4:
					return RectangleAlignmentType.Left;
				case 5:
					return RectangleAlignmentType.Right;
				case 6:
					return RectangleAlignmentType.Top;
				case 7:
					return RectangleAlignmentType.TopLeft;
				case 8:
					return RectangleAlignmentType.TopRight;
				}
			}
		}
		return RectangleAlignmentType.Top;
	}

	internal static string smethod_194(CalcModeType calcModeType_0)
	{
		return calcModeType_0 switch
		{
			CalcModeType.Automatic => "auto", 
			CalcModeType.AutomaticExceptTable => "autoNoTable", 
			CalcModeType.Manual => "manual", 
			_ => "auto", 
		};
	}

	internal static CalcModeType smethod_195(string string_4)
	{
		return string_4 switch
		{
			"manual" => CalcModeType.Manual, 
			"autoNoTable" => CalcModeType.AutomaticExceptTable, 
			"auto" => CalcModeType.Automatic, 
			_ => CalcModeType.Automatic, 
		};
	}

	internal static string smethod_196(TextOrientationType textOrientationType_0)
	{
		return textOrientationType_0 switch
		{
			TextOrientationType.ClockWise => "vert", 
			TextOrientationType.CounterClockWise => "vert270", 
			TextOrientationType.TopToBottom => "wordArtVertRtl", 
			_ => null, 
		};
	}

	internal static TextOrientationType smethod_197(string string_4)
	{
		return string_4 switch
		{
			"wordArtVertRtl" => TextOrientationType.TopToBottom, 
			"vert270" => TextOrientationType.CounterClockWise, 
			"vert" => TextOrientationType.ClockWise, 
			_ => TextOrientationType.NoRotation, 
		};
	}

	internal static bool smethod_198(Shape shape_0)
	{
		switch (shape_0.MsoDrawingType)
		{
		default:
			return false;
		case MsoDrawingType.Button:
		case MsoDrawingType.CheckBox:
		case MsoDrawingType.RadioButton:
		case MsoDrawingType.Label:
		case MsoDrawingType.Spinner:
		case MsoDrawingType.ScrollBar:
		case MsoDrawingType.ListBox:
		case MsoDrawingType.GroupBox:
			return true;
		case MsoDrawingType.ComboBox:
			if (shape_0.method_34())
			{
				ComboBox comboBox = (ComboBox)shape_0;
				if (comboBox.method_69() is AutoFilter || comboBox.method_69() is Validation || comboBox.method_69() is PivotTable)
				{
					return false;
				}
			}
			return true;
		}
	}

	internal static string smethod_199(SelectionType selectionType_0)
	{
		return selectionType_0 switch
		{
			SelectionType.Single => "Single", 
			SelectionType.Multi => "Multi", 
			SelectionType.Extend => "Extend", 
			_ => "Single", 
		};
	}

	internal static SelectionType smethod_200(string string_4)
	{
		return string_4 switch
		{
			"Extend" => SelectionType.Extend, 
			"Multi" => SelectionType.Multi, 
			"Single" => SelectionType.Single, 
			_ => SelectionType.Single, 
		};
	}

	internal static bool smethod_201(string string_4)
	{
		if (string_4.Length == 1)
		{
			switch (string_4)
			{
			case "1":
			case "t":
			case "T":
				return true;
			default:
				return false;
			}
		}
		return string.Compare(string_4, "true", ignoreCase: true) == 0;
	}

	internal static ViewType smethod_202(string string_4)
	{
		return string_4 switch
		{
			"pageLayout" => ViewType.PageLayoutView, 
			"pageBreakPreview" => ViewType.PageBreakPreview, 
			_ => ViewType.NormalView, 
		};
	}

	internal static string smethod_203(ViewType viewType_0)
	{
		return viewType_0 switch
		{
			ViewType.PageBreakPreview => "pageBreakPreview", 
			ViewType.PageLayoutView => "pageLayout", 
			_ => null, 
		};
	}

	internal static PlotEmptyCellsType smethod_204(string string_4)
	{
		return string_4 switch
		{
			"span" => PlotEmptyCellsType.Interpolated, 
			"zero" => PlotEmptyCellsType.Zero, 
			"gap" => PlotEmptyCellsType.NotPlotted, 
			_ => PlotEmptyCellsType.Zero, 
		};
	}

	internal static string smethod_205(PlotEmptyCellsType plotEmptyCellsType_0)
	{
		return plotEmptyCellsType_0 switch
		{
			PlotEmptyCellsType.NotPlotted => "gap", 
			PlotEmptyCellsType.Zero => "zero", 
			PlotEmptyCellsType.Interpolated => "span", 
			_ => "zero", 
		};
	}

	internal static TotalsCalculation smethod_206(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_178 == null)
			{
				Class1742.dictionary_178 = new Dictionary<string, int>(10)
				{
					{ "average", 0 },
					{ "count", 1 },
					{ "countNums", 2 },
					{ "custom", 3 },
					{ "max", 4 },
					{ "min", 5 },
					{ "none", 6 },
					{ "stdDev", 7 },
					{ "sum", 8 },
					{ "var", 9 }
				};
			}
			if (Class1742.dictionary_178.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return TotalsCalculation.Average;
				case 1:
					return TotalsCalculation.Count;
				case 2:
					return TotalsCalculation.CountNums;
				case 3:
					return TotalsCalculation.Custom;
				case 4:
					return TotalsCalculation.Max;
				case 5:
					return TotalsCalculation.Min;
				case 6:
					return TotalsCalculation.None;
				case 7:
					return TotalsCalculation.StdDev;
				case 8:
					return TotalsCalculation.Sum;
				case 9:
					return TotalsCalculation.Var;
				}
			}
		}
		return TotalsCalculation.None;
	}

	internal static string smethod_207(TotalsCalculation totalsCalculation_0)
	{
		return totalsCalculation_0 switch
		{
			TotalsCalculation.None => "none", 
			TotalsCalculation.Average => "average", 
			TotalsCalculation.Count => "count", 
			TotalsCalculation.CountNums => "countNums", 
			TotalsCalculation.Max => "max", 
			TotalsCalculation.Min => "min", 
			TotalsCalculation.Sum => "sum", 
			TotalsCalculation.StdDev => "stdDev", 
			TotalsCalculation.Var => "var", 
			TotalsCalculation.Custom => "custom", 
			_ => "none", 
		};
	}

	internal static Enum234 smethod_208(string string_4)
	{
		return string_4 switch
		{
			"xml" => Enum234.const_2, 
			"queryTable" => Enum234.const_3, 
			_ => Enum234.const_0, 
		};
	}

	internal static string smethod_209(Enum234 enum234_0)
	{
		return enum234_0 switch
		{
			Enum234.const_2 => "xml", 
			Enum234.const_3 => "queryTable", 
			_ => "worksheet", 
		};
	}

	internal static TableStyleElementType smethod_210(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_179 == null)
			{
				Class1742.dictionary_179 = new Dictionary<string, int>(28)
				{
					{ "blankRow", 0 },
					{ "firstColumn", 1 },
					{ "firstColumnStripe", 2 },
					{ "firstColumnSubheading", 3 },
					{ "firstHeaderCell", 4 },
					{ "firstRowStripe", 5 },
					{ "firstRowSubheading", 6 },
					{ "firstSubtotalColumn", 7 },
					{ "firstSubtotalRow", 8 },
					{ "firstTotalCell", 9 },
					{ "headerRow", 10 },
					{ "lastColumn", 11 },
					{ "lastHeaderCell", 12 },
					{ "lastTotalCell", 13 },
					{ "pageFieldLabels", 14 },
					{ "pageFieldValues", 15 },
					{ "secondColumnStripe", 16 },
					{ "secondColumnSubheading", 17 },
					{ "secondRowStripe", 18 },
					{ "secondRowSubheading", 19 },
					{ "secondSubtotalColumn", 20 },
					{ "secondSubtotalRow", 21 },
					{ "thirdColumnSubheading", 22 },
					{ "thirdRowSubheading", 23 },
					{ "thirdSubtotalColumn", 24 },
					{ "thirdSubtotalRow", 25 },
					{ "totalRow", 26 },
					{ "wholeTable", 27 }
				};
			}
			if (Class1742.dictionary_179.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return TableStyleElementType.BlankRow;
				case 1:
					return TableStyleElementType.FirstColumn;
				case 2:
					return TableStyleElementType.FirstColumnStripe;
				case 3:
					return TableStyleElementType.FirstColumnSubheading;
				case 4:
					return TableStyleElementType.FirstHeaderCell;
				case 5:
					return TableStyleElementType.FirstRowStripe;
				case 6:
					return TableStyleElementType.FirstRowSubheading;
				case 7:
					return TableStyleElementType.FirstSubtotalColumn;
				case 8:
					return TableStyleElementType.FirstSubtotalRow;
				case 9:
					return TableStyleElementType.FirstTotalCell;
				case 10:
					return TableStyleElementType.HeaderRow;
				case 11:
					return TableStyleElementType.LastColumn;
				case 12:
					return TableStyleElementType.LastHeaderCell;
				case 13:
					return TableStyleElementType.LastTotalCell;
				case 14:
					return TableStyleElementType.PageFieldLabels;
				case 15:
					return TableStyleElementType.PageFieldValues;
				case 16:
					return TableStyleElementType.SecondColumnStripe;
				case 17:
					return TableStyleElementType.SecondColumnSubheading;
				case 18:
					return TableStyleElementType.SecondRowStripe;
				case 19:
					return TableStyleElementType.SecondRowSubheading;
				case 20:
					return TableStyleElementType.SecondSubtotalColumn;
				case 21:
					return TableStyleElementType.SecondSubtotalRow;
				case 22:
					return TableStyleElementType.ThirdColumnSubheading;
				case 23:
					return TableStyleElementType.ThirdRowSubheading;
				case 24:
					return TableStyleElementType.ThirdSubtotalColumn;
				case 25:
					return TableStyleElementType.ThirdSubtotalRow;
				case 26:
					return TableStyleElementType.TotalRow;
				case 27:
					return TableStyleElementType.WholeTable;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Error TableStyleElementType value");
	}

	internal static string smethod_211(TableStyleElementType tableStyleElementType_0)
	{
		return tableStyleElementType_0 switch
		{
			TableStyleElementType.WholeTable => "wholeTable", 
			TableStyleElementType.PageFieldLabels => "pageFieldLabels", 
			TableStyleElementType.PageFieldValues => "pageFieldValues", 
			TableStyleElementType.FirstColumnStripe => "firstColumnStripe", 
			TableStyleElementType.SecondColumnStripe => "secondColumnStripe", 
			TableStyleElementType.FirstRowStripe => "firstRowStripe", 
			TableStyleElementType.SecondRowStripe => "secondRowStripe", 
			TableStyleElementType.LastColumn => "lastColumn", 
			TableStyleElementType.FirstColumn => "firstColumn", 
			TableStyleElementType.HeaderRow => "headerRow", 
			TableStyleElementType.TotalRow => "totalRow", 
			TableStyleElementType.FirstHeaderCell => "firstHeaderCell", 
			TableStyleElementType.LastHeaderCell => "lastHeaderCell", 
			TableStyleElementType.FirstTotalCell => "firstTotalCell", 
			TableStyleElementType.LastTotalCell => "lastTotalCell", 
			TableStyleElementType.FirstSubtotalColumn => "firstSubtotalColumn", 
			TableStyleElementType.SecondSubtotalColumn => "secondSubtotalColumn", 
			TableStyleElementType.ThirdSubtotalColumn => "thirdSubtotalColumn", 
			TableStyleElementType.BlankRow => "blankRow", 
			TableStyleElementType.FirstSubtotalRow => "firstSubtotalRow", 
			TableStyleElementType.SecondSubtotalRow => "secondSubtotalRow", 
			TableStyleElementType.ThirdSubtotalRow => "thirdSubtotalRow", 
			TableStyleElementType.FirstColumnSubheading => "firstColumnSubheading", 
			TableStyleElementType.SecondColumnSubheading => "secondColumnSubheading", 
			TableStyleElementType.ThirdColumnSubheading => "thirdColumnSubheading", 
			TableStyleElementType.FirstRowSubheading => "firstRowSubheading", 
			TableStyleElementType.SecondRowSubheading => "secondRowSubheading", 
			TableStyleElementType.ThirdRowSubheading => "thirdRowSubheading", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Error TableStyleElementType value"), 
		};
	}

	internal static string smethod_212(string string_4)
	{
		if (string_4[0] == '/')
		{
			return string_4.Substring(1);
		}
		return "xl/" + string_4.Substring(3);
	}

	internal static Enum189 smethod_213(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_180 == null)
			{
				Class1742.dictionary_180 = new Dictionary<string, int>(62)
				{
					{ "legacyObliqueTopLeft", 0 },
					{ "legacyObliqueTop", 1 },
					{ "legacyObliqueTopRight", 2 },
					{ "legacyObliqueLeft", 3 },
					{ "legacyObliqueFront", 4 },
					{ "legacyObliqueRight", 5 },
					{ "legacyObliqueBottomLeft", 6 },
					{ "legacyObliqueBottom", 7 },
					{ "legacyObliqueBottomRight", 8 },
					{ "legacyPerspectiveTopLeft", 9 },
					{ "legacyPerspectiveTop", 10 },
					{ "legacyPerspectiveTopRight", 11 },
					{ "legacyPerspectiveLeft", 12 },
					{ "legacyPerspectiveFront", 13 },
					{ "legacyPerspectiveRight", 14 },
					{ "legacyPerspectiveBottomLeft", 15 },
					{ "legacyPerspectiveBottom", 16 },
					{ "legacyPerspectiveBottomRight", 17 },
					{ "orthographicFront", 18 },
					{ "isometricTopUp", 19 },
					{ "isometricTopDown", 20 },
					{ "isometricBottomUp", 21 },
					{ "isometricBottomDown", 22 },
					{ "isometricLeftUp", 23 },
					{ "isometricLeftDown", 24 },
					{ "isometricRightUp", 25 },
					{ "isometricRightDown", 26 },
					{ "isometricOffAxis1Left", 27 },
					{ "isometricOffAxis1Right", 28 },
					{ "isometricOffAxis1Top", 29 },
					{ "isometricOffAxis2Left", 30 },
					{ "isometricOffAxis2Right", 31 },
					{ "isometricOffAxis2Top", 32 },
					{ "isometricOffAxis3Left", 33 },
					{ "isometricOffAxis3Right", 34 },
					{ "isometricOffAxis3Bottom", 35 },
					{ "isometricOffAxis4Left", 36 },
					{ "isometricOffAxis4Right", 37 },
					{ "isometricOffAxis4Bottom", 38 },
					{ "obliqueTopLeft", 39 },
					{ "obliqueTop", 40 },
					{ "obliqueTopRight", 41 },
					{ "obliqueLeft", 42 },
					{ "obliqueRight", 43 },
					{ "obliqueBottomLeft", 44 },
					{ "obliqueBottom", 45 },
					{ "obliqueBottomRight", 46 },
					{ "perspectiveFront", 47 },
					{ "perspectiveLeft", 48 },
					{ "perspectiveRight", 49 },
					{ "perspectiveAbove", 50 },
					{ "perspectiveBelow", 51 },
					{ "perspectiveAboveLeftFacing", 52 },
					{ "perspectiveAboveRightFacing", 53 },
					{ "perspectiveContrastingLeftFacing", 54 },
					{ "perspectiveContrastingRightFacing", 55 },
					{ "perspectiveHeroicLeftFacing", 56 },
					{ "perspectiveHeroicRightFacing", 57 },
					{ "perspectiveHeroicExtremeLeftFacing", 58 },
					{ "perspectiveHeroicExtremeRightFacing", 59 },
					{ "perspectiveRelaxed", 60 },
					{ "perspectiveRelaxedModerately", 61 }
				};
			}
			if (Class1742.dictionary_180.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return Enum189.const_27;
				case 1:
					return Enum189.const_26;
				case 2:
					return Enum189.const_28;
				case 3:
					return Enum189.const_24;
				case 4:
					return Enum189.const_23;
				case 5:
					return Enum189.const_25;
				case 6:
					return Enum189.const_21;
				case 7:
					return Enum189.const_20;
				case 8:
					return Enum189.const_22;
				case 9:
					return Enum189.const_36;
				case 10:
					return Enum189.const_35;
				case 11:
					return Enum189.const_37;
				case 12:
					return Enum189.const_33;
				case 13:
					return Enum189.const_32;
				case 14:
					return Enum189.const_34;
				case 15:
					return Enum189.const_30;
				case 16:
					return Enum189.const_29;
				case 17:
					return Enum189.const_31;
				case 18:
					return Enum189.const_46;
				case 19:
					return Enum189.const_19;
				case 20:
					return Enum189.const_18;
				case 21:
					return Enum189.const_1;
				case 22:
					return Enum189.const_0;
				case 23:
					return Enum189.const_3;
				case 24:
					return Enum189.const_2;
				case 25:
					return Enum189.const_17;
				case 26:
					return Enum189.const_16;
				case 27:
					return Enum189.const_4;
				case 28:
					return Enum189.const_5;
				case 29:
					return Enum189.const_6;
				case 30:
					return Enum189.const_7;
				case 31:
					return Enum189.const_8;
				case 32:
					return Enum189.const_9;
				case 33:
					return Enum189.const_11;
				case 34:
					return Enum189.const_12;
				case 35:
					return Enum189.const_10;
				case 36:
					return Enum189.const_14;
				case 37:
					return Enum189.const_15;
				case 38:
					return Enum189.const_13;
				case 39:
					return Enum189.const_44;
				case 40:
					return Enum189.const_43;
				case 41:
					return Enum189.const_45;
				case 42:
					return Enum189.const_41;
				case 43:
					return Enum189.const_42;
				case 44:
					return Enum189.const_39;
				case 45:
					return Enum189.const_38;
				case 46:
					return Enum189.const_40;
				case 47:
					return Enum189.const_53;
				case 48:
					return Enum189.const_58;
				case 49:
					return Enum189.const_61;
				case 50:
					return Enum189.const_47;
				case 51:
					return Enum189.const_50;
				case 52:
					return Enum189.const_48;
				case 53:
					return Enum189.const_49;
				case 54:
					return Enum189.const_51;
				case 55:
					return Enum189.const_52;
				case 56:
					return Enum189.const_56;
				case 57:
					return Enum189.const_57;
				case 58:
					return Enum189.const_54;
				case 59:
					return Enum189.const_55;
				case 60:
					return Enum189.const_59;
				case 61:
					return Enum189.const_60;
				}
			}
		}
		return Enum189.const_46;
	}

	internal static string smethod_214(Enum189 enum189_0)
	{
		return enum189_0 switch
		{
			Enum189.const_0 => "isometricBottomDown", 
			Enum189.const_1 => "isometricBottomUp", 
			Enum189.const_2 => "isometricLeftDown", 
			Enum189.const_3 => "isometricLeftUp", 
			Enum189.const_4 => "isometricOffAxis1Left", 
			Enum189.const_5 => "isometricOffAxis1Right", 
			Enum189.const_6 => "isometricOffAxis1Top", 
			Enum189.const_7 => "isometricOffAxis2Left", 
			Enum189.const_8 => "isometricOffAxis2Right", 
			Enum189.const_9 => "isometricOffAxis2Top", 
			Enum189.const_10 => "isometricOffAxis3Bottom", 
			Enum189.const_11 => "isometricOffAxis3Left", 
			Enum189.const_12 => "isometricOffAxis3Right", 
			Enum189.const_13 => "isometricOffAxis4Bottom", 
			Enum189.const_14 => "isometricOffAxis4Left", 
			Enum189.const_15 => "isometricOffAxis4Right", 
			Enum189.const_16 => "isometricRightDown", 
			Enum189.const_17 => "isometricRightUp", 
			Enum189.const_18 => "isometricTopDown", 
			Enum189.const_19 => "isometricTopUp", 
			Enum189.const_20 => "legacyObliqueBottom", 
			Enum189.const_21 => "legacyObliqueBottomLeft", 
			Enum189.const_22 => "legacyObliqueBottomRight", 
			Enum189.const_23 => "legacyObliqueFront", 
			Enum189.const_24 => "legacyObliqueLeft", 
			Enum189.const_25 => "legacyObliqueRight", 
			Enum189.const_26 => "legacyObliqueTop", 
			Enum189.const_27 => "legacyObliqueTopLeft", 
			Enum189.const_28 => "legacyObliqueTopRight", 
			Enum189.const_29 => "legacyPerspectiveBottom", 
			Enum189.const_30 => "legacyPerspectiveBottomLeft", 
			Enum189.const_31 => "legacyPerspectiveBottomRight", 
			Enum189.const_32 => "legacyPerspectiveFront", 
			Enum189.const_33 => "legacyPerspectiveLeft", 
			Enum189.const_34 => "legacyPerspectiveRight", 
			Enum189.const_35 => "legacyPerspectiveTop", 
			Enum189.const_36 => "legacyPerspectiveTopLeft", 
			Enum189.const_37 => "legacyPerspectiveTopRight", 
			Enum189.const_38 => "obliqueBottom", 
			Enum189.const_39 => "obliqueBottomLeft", 
			Enum189.const_40 => "obliqueBottomRight", 
			Enum189.const_41 => "obliqueLeft", 
			Enum189.const_42 => "obliqueRight", 
			Enum189.const_43 => "obliqueTop", 
			Enum189.const_44 => "obliqueTopLeft", 
			Enum189.const_45 => "obliqueTopRight", 
			Enum189.const_46 => "orthographicFront", 
			Enum189.const_47 => "perspectiveAbove", 
			Enum189.const_48 => "perspectiveAboveLeftFacing", 
			Enum189.const_49 => "perspectiveAboveRightFacing", 
			Enum189.const_50 => "perspectiveBelow", 
			Enum189.const_51 => "perspectiveContrastingLeftFacing", 
			Enum189.const_52 => "perspectiveContrastingRightFacing", 
			Enum189.const_53 => "perspectiveFront", 
			Enum189.const_54 => "perspectiveHeroicExtremeLeftFacing", 
			Enum189.const_55 => "perspectiveHeroicExtremeRightFacing", 
			Enum189.const_56 => "perspectiveHeroicLeftFacing", 
			Enum189.const_57 => "perspectiveHeroicRightFacing", 
			Enum189.const_58 => "perspectiveLeft", 
			Enum189.const_59 => "perspectiveRelaxed", 
			Enum189.const_60 => "perspectiveRelaxedModerately", 
			Enum189.const_61 => "perspectiveRight", 
			_ => "orthographicFront", 
		};
	}

	internal static LightRigType smethod_215(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_181 == null)
			{
				Class1742.dictionary_181 = new Dictionary<string, int>(27)
				{
					{ "legacyFlat1", 0 },
					{ "legacyFlat2", 1 },
					{ "legacyFlat3", 2 },
					{ "legacyFlat4", 3 },
					{ "legacyNormal1", 4 },
					{ "legacyNormal2", 5 },
					{ "legacyNormal3", 6 },
					{ "legacyNormal4", 7 },
					{ "legacyHarsh1", 8 },
					{ "legacyHarsh2", 9 },
					{ "legacyHarsh3", 10 },
					{ "legacyHarsh4", 11 },
					{ "threePt", 12 },
					{ "balanced", 13 },
					{ "soft", 14 },
					{ "harsh", 15 },
					{ "flood", 16 },
					{ "contrasting", 17 },
					{ "morning", 18 },
					{ "sunrise", 19 },
					{ "sunset", 20 },
					{ "chilly", 21 },
					{ "freezing", 22 },
					{ "flat", 23 },
					{ "twoPt", 24 },
					{ "glow", 25 },
					{ "brightRoom", 26 }
				};
			}
			if (Class1742.dictionary_181.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return LightRigType.LegacyFlat1;
				case 1:
					return LightRigType.LegacyFlat2;
				case 2:
					return LightRigType.LegacyFlat3;
				case 3:
					return LightRigType.LegacyFlat4;
				case 4:
					return LightRigType.LegacyNormal1;
				case 5:
					return LightRigType.LegacyNormal2;
				case 6:
					return LightRigType.LegacyNormal3;
				case 7:
					return LightRigType.LegacyNormal4;
				case 8:
					return LightRigType.LegacyHarsh1;
				case 9:
					return LightRigType.LegacyHarsh2;
				case 10:
					return LightRigType.LegacyHarsh3;
				case 11:
					return LightRigType.LegacyHarsh4;
				case 12:
					return LightRigType.ThreePoint;
				case 13:
					return LightRigType.Balanced;
				case 14:
					return LightRigType.Soft;
				case 15:
					return LightRigType.Harsh;
				case 16:
					return LightRigType.Flood;
				case 17:
					return LightRigType.Contrasting;
				case 18:
					return LightRigType.Morning;
				case 19:
					return LightRigType.Sunrise;
				case 20:
					return LightRigType.Sunset;
				case 21:
					return LightRigType.Chilly;
				case 22:
					return LightRigType.Freezing;
				case 23:
					return LightRigType.Flat;
				case 24:
					return LightRigType.TwoPoint;
				case 25:
					return LightRigType.Glow;
				case 26:
					return LightRigType.BrightRoom;
				}
			}
		}
		return LightRigType.ThreePoint;
	}

	internal static string smethod_216(LightRigType lightRigType_0)
	{
		return lightRigType_0 switch
		{
			LightRigType.Balanced => "balanced", 
			LightRigType.BrightRoom => "brightRoom", 
			LightRigType.Chilly => "chilly", 
			LightRigType.Contrasting => "contrasting", 
			LightRigType.Flat => "flat", 
			LightRigType.Flood => "flood", 
			LightRigType.Freezing => "freezing", 
			LightRigType.Glow => "glow", 
			LightRigType.Harsh => "harsh", 
			LightRigType.LegacyFlat1 => "legacyFlat1", 
			LightRigType.LegacyFlat2 => "legacyFlat2", 
			LightRigType.LegacyFlat3 => "legacyFlat3", 
			LightRigType.LegacyFlat4 => "legacyFlat4", 
			LightRigType.LegacyHarsh1 => "legacyHarsh1", 
			LightRigType.LegacyHarsh2 => "legacyHarsh2", 
			LightRigType.LegacyHarsh3 => "legacyHarsh3", 
			LightRigType.LegacyHarsh4 => "legacyHarsh4", 
			LightRigType.LegacyNormal1 => "legacyNormal1", 
			LightRigType.LegacyNormal2 => "legacyNormal2", 
			LightRigType.LegacyNormal3 => "legacyNormal3", 
			LightRigType.LegacyNormal4 => "legacyNormal4", 
			LightRigType.Morning => "morning", 
			LightRigType.Soft => "soft", 
			LightRigType.Sunrise => "sunrise", 
			LightRigType.Sunset => "sunset", 
			LightRigType.ThreePoint => "threePt", 
			LightRigType.TwoPoint => "twoPt", 
			_ => "threePt", 
		};
	}

	internal static Enum177 smethod_217(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_182 == null)
			{
				Class1742.dictionary_182 = new Dictionary<string, int>(8)
				{
					{ "tl", 0 },
					{ "t", 1 },
					{ "tr", 2 },
					{ "l", 3 },
					{ "r", 4 },
					{ "bl", 5 },
					{ "b", 6 },
					{ "br", 7 }
				};
			}
			if (Class1742.dictionary_182.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return Enum177.const_6;
				case 1:
					return Enum177.const_5;
				case 2:
					return Enum177.const_7;
				case 3:
					return Enum177.const_3;
				case 4:
					return Enum177.const_4;
				case 5:
					return Enum177.const_1;
				case 6:
					return Enum177.const_0;
				case 7:
					return Enum177.const_2;
				}
			}
		}
		return Enum177.const_5;
	}

	internal static string smethod_218(Enum177 enum177_0)
	{
		return enum177_0 switch
		{
			Enum177.const_0 => "b", 
			Enum177.const_1 => "bl", 
			Enum177.const_2 => "br", 
			Enum177.const_3 => "l", 
			Enum177.const_4 => "r", 
			Enum177.const_5 => "t", 
			Enum177.const_6 => "tl", 
			Enum177.const_7 => "tr", 
			_ => "t", 
		};
	}

	internal static PresetMaterialType smethod_219(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_183 == null)
			{
				Class1742.dictionary_183 = new Dictionary<string, int>(15)
				{
					{ "legacyMatte", 0 },
					{ "legacyPlastic", 1 },
					{ "legacyMetal", 2 },
					{ "legacyWireframe", 3 },
					{ "matte", 4 },
					{ "plastic", 5 },
					{ "metal", 6 },
					{ "warmMatte", 7 },
					{ "translucentPowder", 8 },
					{ "powder", 9 },
					{ "dkEdge", 10 },
					{ "softEdge", 11 },
					{ "clear", 12 },
					{ "flat", 13 },
					{ "softmetal", 14 }
				};
			}
			if (Class1742.dictionary_183.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return PresetMaterialType.LegacyMatte;
				case 1:
					return PresetMaterialType.LegacyPlastic;
				case 2:
					return PresetMaterialType.LegacyMetal;
				case 3:
					return PresetMaterialType.LegacyWireframe;
				case 4:
					return PresetMaterialType.Matte;
				case 5:
					return PresetMaterialType.Plastic;
				case 6:
					return PresetMaterialType.Metal;
				case 7:
					return PresetMaterialType.WarmMatte;
				case 8:
					return PresetMaterialType.TranslucentPowder;
				case 9:
					return PresetMaterialType.Powder;
				case 10:
					return PresetMaterialType.DarkEdge;
				case 11:
					return PresetMaterialType.SoftEdge;
				case 12:
					return PresetMaterialType.Clear;
				case 13:
					return PresetMaterialType.Flat;
				case 14:
					return PresetMaterialType.SoftMetal;
				}
			}
		}
		return PresetMaterialType.WarmMatte;
	}

	internal static string smethod_220(PresetMaterialType presetMaterialType_0)
	{
		return presetMaterialType_0 switch
		{
			PresetMaterialType.Clear => "clear", 
			PresetMaterialType.DarkEdge => "dkEdge", 
			PresetMaterialType.Flat => "flat", 
			PresetMaterialType.LegacyMatte => "legacyMatte", 
			PresetMaterialType.LegacyMetal => "legacyMetal", 
			PresetMaterialType.LegacyPlastic => "legacyPlastic", 
			PresetMaterialType.LegacyWireframe => "legacyWireframe", 
			PresetMaterialType.Matte => "matte", 
			PresetMaterialType.Metal => "metal", 
			PresetMaterialType.Plastic => "plastic", 
			PresetMaterialType.Powder => "powder", 
			PresetMaterialType.SoftEdge => "softEdge", 
			PresetMaterialType.SoftMetal => "softmetal", 
			PresetMaterialType.TranslucentPowder => "translucentPowder", 
			PresetMaterialType.WarmMatte => "warmMatte", 
			_ => "warmMatte", 
		};
	}

	internal static BevelPresetType smethod_221(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_184 == null)
			{
				Class1742.dictionary_184 = new Dictionary<string, int>(12)
				{
					{ "relaxedInset", 0 },
					{ "circle", 1 },
					{ "slope", 2 },
					{ "cross", 3 },
					{ "angle", 4 },
					{ "softRound", 5 },
					{ "convex", 6 },
					{ "coolSlant", 7 },
					{ "divot", 8 },
					{ "riblet", 9 },
					{ "hardEdge", 10 },
					{ "artDeco", 11 }
				};
			}
			if (Class1742.dictionary_184.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return BevelPresetType.RelaxedInset;
				case 1:
					return BevelPresetType.Circle;
				case 2:
					return BevelPresetType.Slope;
				case 3:
					return BevelPresetType.Cross;
				case 4:
					return BevelPresetType.Angle;
				case 5:
					return BevelPresetType.SoftRound;
				case 6:
					return BevelPresetType.Convex;
				case 7:
					return BevelPresetType.CoolSlant;
				case 8:
					return BevelPresetType.Divot;
				case 9:
					return BevelPresetType.Riblet;
				case 10:
					return BevelPresetType.HardEdge;
				case 11:
					return BevelPresetType.ArtDeco;
				}
			}
		}
		return BevelPresetType.Circle;
	}

	internal static string smethod_222(BevelPresetType bevelPresetType_0)
	{
		return bevelPresetType_0 switch
		{
			BevelPresetType.Angle => "angle", 
			BevelPresetType.ArtDeco => "artDeco", 
			BevelPresetType.Circle => "circle", 
			BevelPresetType.Convex => "convex", 
			BevelPresetType.CoolSlant => "coolSlant", 
			BevelPresetType.Cross => "cross", 
			BevelPresetType.Divot => "divot", 
			BevelPresetType.HardEdge => "hardEdge", 
			BevelPresetType.RelaxedInset => "relaxedInset", 
			BevelPresetType.Riblet => "riblet", 
			BevelPresetType.Slope => "slope", 
			BevelPresetType.SoftRound => "softRound", 
			_ => "circle", 
		};
	}

	internal static Color smethod_223(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_185 == null)
			{
				Class1742.dictionary_185 = new Dictionary<string, int>(140)
				{
					{ "aliceBlue", 0 },
					{ "antiqueWhite", 1 },
					{ "aqua", 2 },
					{ "aquamarine", 3 },
					{ "azure", 4 },
					{ "beige", 5 },
					{ "bisque", 6 },
					{ "black", 7 },
					{ "blanchedAlmond", 8 },
					{ "blue", 9 },
					{ "blueViolet", 10 },
					{ "brown", 11 },
					{ "burlyWood", 12 },
					{ "cadetBlue", 13 },
					{ "chartreuse", 14 },
					{ "chocolate", 15 },
					{ "coral", 16 },
					{ "cornflowerBlue", 17 },
					{ "cornsilk", 18 },
					{ "crimson", 19 },
					{ "cyan", 20 },
					{ "deepPink", 21 },
					{ "deepSkyBlue", 22 },
					{ "dimGray", 23 },
					{ "dkBlue", 24 },
					{ "dkCyan", 25 },
					{ "dkGoldenrod", 26 },
					{ "dkGray", 27 },
					{ "dkGreen", 28 },
					{ "dkKhaki", 29 },
					{ "dkMagenta", 30 },
					{ "dkOliveGreen", 31 },
					{ "dkOrange", 32 },
					{ "dkOrchid", 33 },
					{ "dkRed", 34 },
					{ "dkSalmon", 35 },
					{ "dkSeaGreen", 36 },
					{ "dkSlateBlue", 37 },
					{ "dkSlateGray", 38 },
					{ "dkTurquoise", 39 },
					{ "dkViolet", 40 },
					{ "dodgerBlue", 41 },
					{ "firebrick", 42 },
					{ "floralWhite", 43 },
					{ "forestGreen", 44 },
					{ "fuchsia", 45 },
					{ "gainsboro", 46 },
					{ "ghostWhite", 47 },
					{ "gold", 48 },
					{ "goldenrod", 49 },
					{ "gray", 50 },
					{ "green", 51 },
					{ "greenYellow", 52 },
					{ "honeydew", 53 },
					{ "hotPink", 54 },
					{ "indianRed", 55 },
					{ "indigo", 56 },
					{ "ivory", 57 },
					{ "khaki", 58 },
					{ "lavender", 59 },
					{ "lavenderBlush", 60 },
					{ "lawnGreen", 61 },
					{ "lemonChiffon", 62 },
					{ "lime", 63 },
					{ "limeGreen", 64 },
					{ "linen", 65 },
					{ "ltBlue", 66 },
					{ "ltCoral", 67 },
					{ "ltCyan", 68 },
					{ "ltGoldenrodYellow", 69 },
					{ "ltGray", 70 },
					{ "ltGreen", 71 },
					{ "ltPink", 72 },
					{ "ltSalmon", 73 },
					{ "ltSeaGreen", 74 },
					{ "ltSkyBlue", 75 },
					{ "ltSlateGray", 76 },
					{ "ltSteelBlue", 77 },
					{ "ltYellow", 78 },
					{ "magenta", 79 },
					{ "maroon", 80 },
					{ "medAquamarine", 81 },
					{ "medBlue", 82 },
					{ "medOrchid", 83 },
					{ "medPurple", 84 },
					{ "medSeaGreen", 85 },
					{ "medSlateBlue", 86 },
					{ "medSpringGreen", 87 },
					{ "medTurquoise", 88 },
					{ "medVioletRed", 89 },
					{ "midnightBlue", 90 },
					{ "mintCream", 91 },
					{ "mistyRose", 92 },
					{ "moccasin", 93 },
					{ "navajoWhite", 94 },
					{ "navy", 95 },
					{ "oldLace", 96 },
					{ "olive", 97 },
					{ "oliveDrab", 98 },
					{ "orange", 99 },
					{ "orangeRed", 100 },
					{ "orchid", 101 },
					{ "paleGoldenrod", 102 },
					{ "paleGreen", 103 },
					{ "paleTurquoise", 104 },
					{ "paleVioletRed", 105 },
					{ "papayaWhip", 106 },
					{ "peachPuff", 107 },
					{ "peru", 108 },
					{ "pink", 109 },
					{ "plum", 110 },
					{ "powderBlue", 111 },
					{ "purple", 112 },
					{ "red", 113 },
					{ "rosyBrown", 114 },
					{ "royalBlue", 115 },
					{ "saddleBrown", 116 },
					{ "salmon", 117 },
					{ "sandyBrown", 118 },
					{ "seaGreen", 119 },
					{ "seaShell", 120 },
					{ "sienna", 121 },
					{ "silver", 122 },
					{ "skyBlue", 123 },
					{ "slateBlue", 124 },
					{ "slateGray", 125 },
					{ "snow", 126 },
					{ "springGreen", 127 },
					{ "steelBlue", 128 },
					{ "tan", 129 },
					{ "teal", 130 },
					{ "thistle", 131 },
					{ "tomato", 132 },
					{ "turquoise", 133 },
					{ "violet", 134 },
					{ "wheat", 135 },
					{ "white", 136 },
					{ "whiteSmoke", 137 },
					{ "yellow", 138 },
					{ "yellowGreen", 139 }
				};
			}
			if (Class1742.dictionary_185.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return Color.FromArgb(240, 248, 255);
				case 1:
					return Color.FromArgb(250, 235, 215);
				case 2:
					return Color.FromArgb(0, 255, 255);
				case 3:
					return Color.FromArgb(127, 255, 212);
				case 4:
					return Color.FromArgb(240, 255, 255);
				case 5:
					return Color.FromArgb(245, 245, 220);
				case 6:
					return Color.FromArgb(255, 228, 196);
				case 7:
					return Color.FromArgb(0, 0, 0);
				case 8:
					return Color.FromArgb(255, 235, 205);
				case 9:
					return Color.FromArgb(0, 0, 255);
				case 10:
					return Color.FromArgb(138, 43, 226);
				case 11:
					return Color.FromArgb(165, 42, 42);
				case 12:
					return Color.FromArgb(222, 184, 135);
				case 13:
					return Color.FromArgb(95, 158, 160);
				case 14:
					return Color.FromArgb(127, 255, 0);
				case 15:
					return Color.FromArgb(210, 105, 30);
				case 16:
					return Color.FromArgb(255, 127, 80);
				case 17:
					return Color.FromArgb(100, 149, 237);
				case 18:
					return Color.FromArgb(255, 248, 220);
				case 19:
					return Color.FromArgb(220, 20, 60);
				case 20:
					return Color.FromArgb(0, 255, 255);
				case 21:
					return Color.FromArgb(255, 20, 147);
				case 22:
					return Color.FromArgb(0, 191, 255);
				case 23:
					return Color.FromArgb(105, 105, 105);
				case 24:
					return Color.FromArgb(0, 0, 139);
				case 25:
					return Color.FromArgb(0, 139, 139);
				case 26:
					return Color.FromArgb(184, 134, 11);
				case 27:
					return Color.FromArgb(169, 169, 169);
				case 28:
					return Color.FromArgb(0, 100, 0);
				case 29:
					return Color.FromArgb(189, 183, 107);
				case 30:
					return Color.FromArgb(139, 0, 139);
				case 31:
					return Color.FromArgb(85, 107, 47);
				case 32:
					return Color.FromArgb(255, 140, 0);
				case 33:
					return Color.FromArgb(153, 50, 204);
				case 34:
					return Color.FromArgb(139, 0, 0);
				case 35:
					return Color.FromArgb(233, 150, 122);
				case 36:
					return Color.FromArgb(143, 188, 139);
				case 37:
					return Color.FromArgb(72, 61, 139);
				case 38:
					return Color.FromArgb(47, 79, 79);
				case 39:
					return Color.FromArgb(0, 206, 209);
				case 40:
					return Color.FromArgb(148, 0, 211);
				case 41:
					return Color.FromArgb(30, 144, 255);
				case 42:
					return Color.FromArgb(178, 34, 34);
				case 43:
					return Color.FromArgb(255, 250, 240);
				case 44:
					return Color.FromArgb(34, 139, 34);
				case 45:
					return Color.FromArgb(255, 0, 255);
				case 46:
					return Color.FromArgb(220, 220, 220);
				case 47:
					return Color.FromArgb(248, 248, 255);
				case 48:
					return Color.FromArgb(255, 215, 0);
				case 49:
					return Color.FromArgb(218, 165, 32);
				case 50:
					return Color.FromArgb(128, 128, 128);
				case 51:
					return Color.FromArgb(0, 128, 0);
				case 52:
					return Color.FromArgb(173, 255, 47);
				case 53:
					return Color.FromArgb(240, 255, 240);
				case 54:
					return Color.FromArgb(255, 105, 180);
				case 55:
					return Color.FromArgb(205, 92, 92);
				case 56:
					return Color.FromArgb(75, 0, 130);
				case 57:
					return Color.FromArgb(255, 255, 240);
				case 58:
					return Color.FromArgb(240, 230, 140);
				case 59:
					return Color.FromArgb(230, 230, 250);
				case 60:
					return Color.FromArgb(255, 240, 245);
				case 61:
					return Color.FromArgb(124, 252, 0);
				case 62:
					return Color.FromArgb(255, 250, 205);
				case 63:
					return Color.FromArgb(0, 255, 0);
				case 64:
					return Color.FromArgb(50, 205, 50);
				case 65:
					return Color.FromArgb(250, 240, 230);
				case 66:
					return Color.FromArgb(173, 216, 230);
				case 67:
					return Color.FromArgb(240, 128, 128);
				case 68:
					return Color.FromArgb(224, 255, 255);
				case 69:
					return Color.FromArgb(250, 250, 120);
				case 70:
					return Color.FromArgb(211, 211, 211);
				case 71:
					return Color.FromArgb(144, 238, 144);
				case 72:
					return Color.FromArgb(255, 182, 193);
				case 73:
					return Color.FromArgb(255, 160, 122);
				case 74:
					return Color.FromArgb(32, 178, 170);
				case 75:
					return Color.FromArgb(135, 206, 250);
				case 76:
					return Color.FromArgb(119, 136, 153);
				case 77:
					return Color.FromArgb(176, 196, 222);
				case 78:
					return Color.FromArgb(255, 255, 224);
				case 79:
					return Color.FromArgb(255, 0, 255);
				case 80:
					return Color.FromArgb(128, 0, 0);
				case 81:
					return Color.FromArgb(102, 205, 170);
				case 82:
					return Color.FromArgb(0, 0, 205);
				case 83:
					return Color.FromArgb(186, 85, 211);
				case 84:
					return Color.FromArgb(147, 112, 219);
				case 85:
					return Color.FromArgb(60, 179, 113);
				case 86:
					return Color.FromArgb(123, 104, 238);
				case 87:
					return Color.FromArgb(0, 250, 154);
				case 88:
					return Color.FromArgb(72, 209, 204);
				case 89:
					return Color.FromArgb(199, 21, 133);
				case 90:
					return Color.FromArgb(25, 25, 112);
				case 91:
					return Color.FromArgb(245, 255, 250);
				case 92:
					return Color.FromArgb(255, 228, 225);
				case 93:
					return Color.FromArgb(255, 228, 181);
				case 94:
					return Color.FromArgb(255, 222, 173);
				case 95:
					return Color.FromArgb(0, 0, 128);
				case 96:
					return Color.FromArgb(253, 245, 230);
				case 97:
					return Color.FromArgb(128, 128, 0);
				case 98:
					return Color.FromArgb(107, 142, 35);
				case 99:
					return Color.FromArgb(255, 165, 0);
				case 100:
					return Color.FromArgb(255, 69, 0);
				case 101:
					return Color.FromArgb(218, 112, 214);
				case 102:
					return Color.FromArgb(238, 232, 170);
				case 103:
					return Color.FromArgb(152, 251, 152);
				case 104:
					return Color.FromArgb(175, 238, 238);
				case 105:
					return Color.FromArgb(219, 112, 147);
				case 106:
					return Color.FromArgb(255, 239, 213);
				case 107:
					return Color.FromArgb(255, 218, 185);
				case 108:
					return Color.FromArgb(205, 133, 63);
				case 109:
					return Color.FromArgb(255, 192, 203);
				case 110:
					return Color.FromArgb(221, 160, 221);
				case 111:
					return Color.FromArgb(176, 224, 230);
				case 112:
					return Color.FromArgb(128, 0, 128);
				case 113:
					return Color.FromArgb(255, 0, 0);
				case 114:
					return Color.FromArgb(188, 143, 143);
				case 115:
					return Color.FromArgb(65, 105, 225);
				case 116:
					return Color.FromArgb(139, 69, 19);
				case 117:
					return Color.FromArgb(250, 128, 114);
				case 118:
					return Color.FromArgb(244, 164, 96);
				case 119:
					return Color.FromArgb(46, 139, 87);
				case 120:
					return Color.FromArgb(255, 245, 238);
				case 121:
					return Color.FromArgb(160, 82, 45);
				case 122:
					return Color.FromArgb(192, 192, 192);
				case 123:
					return Color.FromArgb(135, 206, 235);
				case 124:
					return Color.FromArgb(106, 90, 205);
				case 125:
					return Color.FromArgb(112, 128, 144);
				case 126:
					return Color.FromArgb(255, 250, 250);
				case 127:
					return Color.FromArgb(0, 255, 127);
				case 128:
					return Color.FromArgb(70, 130, 180);
				case 129:
					return Color.FromArgb(210, 180, 140);
				case 130:
					return Color.FromArgb(0, 128, 128);
				case 131:
					return Color.FromArgb(216, 191, 216);
				case 132:
					return Color.FromArgb(255, 99, 71);
				case 133:
					return Color.FromArgb(64, 224, 208);
				case 134:
					return Color.FromArgb(238, 130, 238);
				case 135:
					return Color.FromArgb(245, 222, 179);
				case 136:
					return Color.FromArgb(255, 255, 255);
				case 137:
					return Color.FromArgb(245, 245, 245);
				case 138:
					return Color.FromArgb(255, 255, 0);
				case 139:
					return Color.FromArgb(154, 205, 50);
				}
			}
		}
		return Color.FromArgb(0, 0, 0);
	}

	internal static string smethod_224(int int_0)
	{
		return int_0 switch
		{
			-16777088 => "navy", 
			-16777216 => "black", 
			-16777011 => "medBlue", 
			-16777077 => "dkBlue", 
			-16751616 => "dkGreen", 
			-16776961 => "blue", 
			-16744320 => "teal", 
			-16744448 => "green", 
			-16728065 => "deepSkyBlue", 
			-16741493 => "dkCyan", 
			-16713062 => "medSpringGreen", 
			-16724271 => "dkTurquoise", 
			-16711809 => "springGreen", 
			-16711936 => "lime", 
			-14774017 => "dodgerBlue", 
			-15132304 => "midnightBlue", 
			-16711681 => "aqua", 
			-14513374 => "forestGreen", 
			-14634326 => "ltSeaGreen", 
			-13676721 => "dkSlateGray", 
			-13726889 => "seaGreen", 
			-12799119 => "medSeaGreen", 
			-13447886 => "limeGreen", 
			-12490271 => "royalBlue", 
			-12525360 => "turquoise", 
			-12042869 => "dkSlateBlue", 
			-12156236 => "steelBlue", 
			-11861886 => "indigo", 
			-12004916 => "medTurquoise", 
			-10510688 => "cadetBlue", 
			-11179217 => "dkOliveGreen", 
			-9868951 => "dimGray", 
			-10039894 => "medAquamarine", 
			-10185235 => "cornflowerBlue", 
			-9728477 => "oliveDrab", 
			-9807155 => "slateBlue", 
			-8943463 => "ltSlateGray", 
			-9404272 => "slateGray", 
			-8586240 => "lawnGreen", 
			-8689426 => "medSlateBlue", 
			-8388652 => "aquamarine", 
			-8388864 => "chartreuse", 
			-8388480 => "purple", 
			-8388608 => "maroon", 
			-8355712 => "gray", 
			-8355840 => "olive", 
			-7876870 => "ltSkyBlue", 
			-7876885 => "skyBlue", 
			-7667573 => "dkMagenta", 
			-7667712 => "dkRed", 
			-7722014 => "blueViolet", 
			-7357301 => "dkSeaGreen", 
			-7650029 => "saddleBrown", 
			-7114533 => "medPurple", 
			-7278960 => "ltGreen", 
			-6751336 => "paleGreen", 
			-7077677 => "dkViolet", 
			-6270419 => "sienna", 
			-6632142 => "yellowGreen", 
			-6737204 => "dkOrchid", 
			-5658199 => "dkGray", 
			-5952982 => "brown", 
			-5374161 => "greenYellow", 
			-5383962 => "ltBlue", 
			-5192482 => "ltSteelBlue", 
			-5247250 => "paleTurquoise", 
			-4684277 => "dkGoldenrod", 
			-5103070 => "firebrick", 
			-5185306 => "powderBlue", 
			-4419697 => "rosyBrown", 
			-4565549 => "medOrchid", 
			-4144960 => "silver", 
			-4343957 => "dkKhaki", 
			-3318692 => "indianRed", 
			-3730043 => "medVioletRed", 
			-2987746 => "chocolate", 
			-3308225 => "peru", 
			-2894893 => "ltGray", 
			-2968436 => "tan", 
			-2461482 => "orchid", 
			-2572328 => "thistle", 
			-2396013 => "paleVioletRed", 
			-2448096 => "goldenrod", 
			-2252579 => "plum", 
			-2302756 => "gainsboro", 
			-2354116 => "crimson", 
			-2031617 => "ltCyan", 
			-2180985 => "burlyWood", 
			-1468806 => "dkSalmon", 
			-1644806 => "lavender", 
			-1120086 => "paleGoldenrod", 
			-1146130 => "violet", 
			-989556 => "khaki", 
			-1015680 => "ltCoral", 
			-983056 => "honeydew", 
			-984833 => "aliceBlue", 
			-744352 => "sandyBrown", 
			-983041 => "azure", 
			-657956 => "beige", 
			-663885 => "wheat", 
			-460545 => "ghostWhite", 
			-655366 => "mintCream", 
			-657931 => "whiteSmoke", 
			-332841 => "antiqueWhite", 
			-360334 => "salmon", 
			-329096 => "ltGoldenrodYellow", 
			-331546 => "linen", 
			-65536 => "red", 
			-133658 => "oldLace", 
			-60269 => "deepPink", 
			-65281 => "fuchsia", 
			-40121 => "tomato", 
			-47872 => "orangeRed", 
			-32944 => "coral", 
			-38476 => "hotPink", 
			-24454 => "ltSalmon", 
			-29696 => "dkOrange", 
			-16181 => "pink", 
			-18751 => "ltPink", 
			-23296 => "orange", 
			-9543 => "peachPuff", 
			-10496 => "gold", 
			-6987 => "moccasin", 
			-8531 => "navajoWhite", 
			-6943 => "mistyRose", 
			-6972 => "bisque", 
			-3851 => "lavenderBlush", 
			-4139 => "papayaWhip", 
			-5171 => "blanchedAlmond", 
			-1828 => "cornsilk", 
			-2578 => "seaShell", 
			-1296 => "floralWhite", 
			-1331 => "lemonChiffon", 
			-256 => "yellow", 
			-1286 => "snow", 
			-1 => "white", 
			-16 => "ivory", 
			-32 => "ltYellow", 
			_ => "black", 
		};
	}

	internal static SparklineType smethod_225(string string_4)
	{
		return string_4 switch
		{
			"stacked" => SparklineType.Stacked, 
			"column" => SparklineType.Column, 
			_ => SparklineType.Line, 
		};
	}

	internal static string smethod_226(SparklineType sparklineType_0)
	{
		return sparklineType_0 switch
		{
			SparklineType.Column => "column", 
			SparklineType.Stacked => "stacked", 
			_ => "line", 
		};
	}

	internal static SparklineAxisMinMaxType smethod_227(string string_4)
	{
		return string_4 switch
		{
			"custom" => SparklineAxisMinMaxType.Custom, 
			"group" => SparklineAxisMinMaxType.Group, 
			_ => SparklineAxisMinMaxType.AutoIndividual, 
		};
	}

	internal static string smethod_228(SparklineAxisMinMaxType sparklineAxisMinMaxType_0)
	{
		return sparklineAxisMinMaxType_0 switch
		{
			SparklineAxisMinMaxType.Group => "group", 
			SparklineAxisMinMaxType.Custom => "custom", 
			_ => "individual", 
		};
	}

	internal static Enum186 smethod_229(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_186 == null)
			{
				Class1742.dictionary_186 = new Dictionary<string, int>(187)
				{
					{ "line", 0 },
					{ "lineInv", 1 },
					{ "triangle", 2 },
					{ "rtTriangle", 3 },
					{ "rect", 4 },
					{ "diamond", 5 },
					{ "parallelogram", 6 },
					{ "trapezoid", 7 },
					{ "nonIsoscelesTrapezoid", 8 },
					{ "pentagon", 9 },
					{ "hexagon", 10 },
					{ "heptagon", 11 },
					{ "octagon", 12 },
					{ "decagon", 13 },
					{ "dodecagon", 14 },
					{ "star4", 15 },
					{ "star5", 16 },
					{ "star6", 17 },
					{ "star7", 18 },
					{ "star8", 19 },
					{ "star10", 20 },
					{ "star12", 21 },
					{ "star16", 22 },
					{ "star24", 23 },
					{ "star32", 24 },
					{ "roundRect", 25 },
					{ "round1Rect", 26 },
					{ "round2SameRect", 27 },
					{ "round2DiagRect", 28 },
					{ "snipRoundRect", 29 },
					{ "snip1Rect", 30 },
					{ "snip2SameRect", 31 },
					{ "snip2DiagRect", 32 },
					{ "plaque", 33 },
					{ "ellipse", 34 },
					{ "teardrop", 35 },
					{ "homePlate", 36 },
					{ "chevron", 37 },
					{ "pieWedge", 38 },
					{ "pie", 39 },
					{ "blockArc", 40 },
					{ "donut", 41 },
					{ "noSmoking", 42 },
					{ "rightArrow", 43 },
					{ "leftArrow", 44 },
					{ "upArrow", 45 },
					{ "downArrow", 46 },
					{ "stripedRightArrow", 47 },
					{ "notchedRightArrow", 48 },
					{ "bentUpArrow", 49 },
					{ "leftRightArrow", 50 },
					{ "upDownArrow", 51 },
					{ "leftUpArrow", 52 },
					{ "leftRightUpArrow", 53 },
					{ "quadArrow", 54 },
					{ "leftArrowCallout", 55 },
					{ "rightArrowCallout", 56 },
					{ "upArrowCallout", 57 },
					{ "downArrowCallout", 58 },
					{ "leftRightArrowCallout", 59 },
					{ "upDownArrowCallout", 60 },
					{ "quadArrowCallout", 61 },
					{ "bentArrow", 62 },
					{ "uturnArrow", 63 },
					{ "circularArrow", 64 },
					{ "leftCircularArrow", 65 },
					{ "leftRightCircularArrow", 66 },
					{ "curvedRightArrow", 67 },
					{ "curvedLeftArrow", 68 },
					{ "curvedUpArrow", 69 },
					{ "curvedDownArrow", 70 },
					{ "swooshArrow", 71 },
					{ "cube", 72 },
					{ "can", 73 },
					{ "lightningBolt", 74 },
					{ "heart", 75 },
					{ "sun", 76 },
					{ "moon", 77 },
					{ "smileyFace", 78 },
					{ "irregularSeal1", 79 },
					{ "irregularSeal2", 80 },
					{ "foldedCorner", 81 },
					{ "bevel", 82 },
					{ "frame", 83 },
					{ "halfFrame", 84 },
					{ "corner", 85 },
					{ "diagStripe", 86 },
					{ "chord", 87 },
					{ "arc", 88 },
					{ "leftBracket", 89 },
					{ "rightBracket", 90 },
					{ "leftBrace", 91 },
					{ "rightBrace", 92 },
					{ "bracketPair", 93 },
					{ "bracePair", 94 },
					{ "straightConnector1", 95 },
					{ "bentConnector2", 96 },
					{ "bentConnector3", 97 },
					{ "bentConnector4", 98 },
					{ "bentConnector5", 99 },
					{ "curvedConnector2", 100 },
					{ "curvedConnector3", 101 },
					{ "curvedConnector4", 102 },
					{ "curvedConnector5", 103 },
					{ "callout1", 104 },
					{ "callout2", 105 },
					{ "callout3", 106 },
					{ "accentCallout1", 107 },
					{ "accentCallout2", 108 },
					{ "accentCallout3", 109 },
					{ "borderCallout1", 110 },
					{ "borderCallout2", 111 },
					{ "borderCallout3", 112 },
					{ "accentBorderCallout1", 113 },
					{ "accentBorderCallout2", 114 },
					{ "accentBorderCallout3", 115 },
					{ "wedgeRectCallout", 116 },
					{ "wedgeRoundRectCallout", 117 },
					{ "wedgeEllipseCallout", 118 },
					{ "cloudCallout", 119 },
					{ "cloud", 120 },
					{ "ribbon", 121 },
					{ "ribbon2", 122 },
					{ "ellipseRibbon", 123 },
					{ "ellipseRibbon2", 124 },
					{ "leftRightRibbon", 125 },
					{ "verticalScroll", 126 },
					{ "horizontalScroll", 127 },
					{ "wave", 128 },
					{ "doubleWave", 129 },
					{ "plus", 130 },
					{ "flowChartProcess", 131 },
					{ "flowChartDecision", 132 },
					{ "flowChartInputOutput", 133 },
					{ "flowChartPredefinedProcess", 134 },
					{ "flowChartInternalStorage", 135 },
					{ "flowChartDocument", 136 },
					{ "flowChartMultidocument", 137 },
					{ "flowChartTerminator", 138 },
					{ "flowChartPreparation", 139 },
					{ "flowChartManualInput", 140 },
					{ "flowChartManualOperation", 141 },
					{ "flowChartConnector", 142 },
					{ "flowChartPunchedCard", 143 },
					{ "flowChartPunchedTape", 144 },
					{ "flowChartSummingJunction", 145 },
					{ "flowChartOr", 146 },
					{ "flowChartCollate", 147 },
					{ "flowChartSort", 148 },
					{ "flowChartExtract", 149 },
					{ "flowChartMerge", 150 },
					{ "flowChartOfflineStorage", 151 },
					{ "flowChartOnlineStorage", 152 },
					{ "flowChartMagneticTape", 153 },
					{ "flowChartMagneticDisk", 154 },
					{ "flowChartMagneticDrum", 155 },
					{ "flowChartDisplay", 156 },
					{ "flowChartDelay", 157 },
					{ "flowChartAlternateProcess", 158 },
					{ "flowChartOffpageConnector", 159 },
					{ "actionButtonBlank", 160 },
					{ "actionButtonHome", 161 },
					{ "actionButtonHelp", 162 },
					{ "actionButtonInformation", 163 },
					{ "actionButtonForwardNext", 164 },
					{ "actionButtonBackPrevious", 165 },
					{ "actionButtonEnd", 166 },
					{ "actionButtonBeginning", 167 },
					{ "actionButtonReturn", 168 },
					{ "actionButtonDocument", 169 },
					{ "actionButtonSound", 170 },
					{ "actionButtonMovie", 171 },
					{ "gear6", 172 },
					{ "gear9", 173 },
					{ "funnel", 174 },
					{ "mathPlus", 175 },
					{ "mathMinus", 176 },
					{ "mathMultiply", 177 },
					{ "mathDivide", 178 },
					{ "mathEqual", 179 },
					{ "mathNotEqual", 180 },
					{ "cornerTabs", 181 },
					{ "squareTabs", 182 },
					{ "plaqueTabs", 183 },
					{ "chartX", 184 },
					{ "chartStar", 185 },
					{ "chartPlus", 186 }
				};
			}
			if (Class1742.dictionary_186.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return Enum186.const_0;
				case 1:
					return Enum186.const_1;
				case 2:
					return Enum186.const_2;
				case 3:
					return Enum186.const_3;
				case 4:
					return Enum186.const_4;
				case 5:
					return Enum186.const_5;
				case 6:
					return Enum186.const_6;
				case 7:
					return Enum186.const_7;
				case 8:
					return Enum186.const_8;
				case 9:
					return Enum186.const_9;
				case 10:
					return Enum186.const_10;
				case 11:
					return Enum186.const_11;
				case 12:
					return Enum186.const_12;
				case 13:
					return Enum186.const_13;
				case 14:
					return Enum186.const_14;
				case 15:
					return Enum186.const_15;
				case 16:
					return Enum186.const_16;
				case 17:
					return Enum186.const_17;
				case 18:
					return Enum186.const_18;
				case 19:
					return Enum186.const_19;
				case 20:
					return Enum186.const_20;
				case 21:
					return Enum186.const_21;
				case 22:
					return Enum186.const_22;
				case 23:
					return Enum186.const_23;
				case 24:
					return Enum186.const_24;
				case 25:
					return Enum186.const_25;
				case 26:
					return Enum186.const_26;
				case 27:
					return Enum186.const_27;
				case 28:
					return Enum186.const_28;
				case 29:
					return Enum186.const_29;
				case 30:
					return Enum186.const_30;
				case 31:
					return Enum186.const_31;
				case 32:
					return Enum186.const_32;
				case 33:
					return Enum186.const_33;
				case 34:
					return Enum186.const_34;
				case 35:
					return Enum186.const_35;
				case 36:
					return Enum186.const_36;
				case 37:
					return Enum186.const_37;
				case 38:
					return Enum186.const_38;
				case 39:
					return Enum186.const_39;
				case 40:
					return Enum186.const_40;
				case 41:
					return Enum186.const_41;
				case 42:
					return Enum186.const_42;
				case 43:
					return Enum186.const_43;
				case 44:
					return Enum186.const_44;
				case 45:
					return Enum186.const_45;
				case 46:
					return Enum186.const_46;
				case 47:
					return Enum186.const_47;
				case 48:
					return Enum186.const_48;
				case 49:
					return Enum186.const_49;
				case 50:
					return Enum186.const_50;
				case 51:
					return Enum186.const_51;
				case 52:
					return Enum186.const_52;
				case 53:
					return Enum186.const_53;
				case 54:
					return Enum186.const_54;
				case 55:
					return Enum186.const_55;
				case 56:
					return Enum186.const_56;
				case 57:
					return Enum186.const_57;
				case 58:
					return Enum186.const_58;
				case 59:
					return Enum186.const_59;
				case 60:
					return Enum186.const_60;
				case 61:
					return Enum186.const_61;
				case 62:
					return Enum186.const_62;
				case 63:
					return Enum186.const_63;
				case 64:
					return Enum186.const_64;
				case 65:
					return Enum186.const_65;
				case 66:
					return Enum186.const_66;
				case 67:
					return Enum186.const_67;
				case 68:
					return Enum186.const_68;
				case 69:
					return Enum186.const_69;
				case 70:
					return Enum186.const_70;
				case 71:
					return Enum186.const_71;
				case 72:
					return Enum186.const_72;
				case 73:
					return Enum186.const_73;
				case 74:
					return Enum186.const_74;
				case 75:
					return Enum186.const_75;
				case 76:
					return Enum186.const_76;
				case 77:
					return Enum186.const_77;
				case 78:
					return Enum186.const_78;
				case 79:
					return Enum186.const_79;
				case 80:
					return Enum186.const_80;
				case 81:
					return Enum186.const_81;
				case 82:
					return Enum186.const_82;
				case 83:
					return Enum186.const_83;
				case 84:
					return Enum186.const_84;
				case 85:
					return Enum186.const_85;
				case 86:
					return Enum186.const_86;
				case 87:
					return Enum186.const_87;
				case 88:
					return Enum186.const_88;
				case 89:
					return Enum186.const_89;
				case 90:
					return Enum186.const_90;
				case 91:
					return Enum186.const_91;
				case 92:
					return Enum186.const_92;
				case 93:
					return Enum186.const_93;
				case 94:
					return Enum186.const_94;
				case 95:
					return Enum186.const_95;
				case 96:
					return Enum186.const_96;
				case 97:
					return Enum186.const_97;
				case 98:
					return Enum186.const_98;
				case 99:
					return Enum186.const_99;
				case 100:
					return Enum186.const_100;
				case 101:
					return Enum186.const_101;
				case 102:
					return Enum186.const_102;
				case 103:
					return Enum186.const_103;
				case 104:
					return Enum186.const_104;
				case 105:
					return Enum186.const_105;
				case 106:
					return Enum186.const_106;
				case 107:
					return Enum186.const_107;
				case 108:
					return Enum186.const_108;
				case 109:
					return Enum186.const_109;
				case 110:
					return Enum186.const_110;
				case 111:
					return Enum186.const_111;
				case 112:
					return Enum186.const_112;
				case 113:
					return Enum186.const_113;
				case 114:
					return Enum186.const_114;
				case 115:
					return Enum186.const_115;
				case 116:
					return Enum186.const_116;
				case 117:
					return Enum186.const_117;
				case 118:
					return Enum186.const_118;
				case 119:
					return Enum186.const_119;
				case 120:
					return Enum186.const_120;
				case 121:
					return Enum186.const_121;
				case 122:
					return Enum186.const_122;
				case 123:
					return Enum186.const_123;
				case 124:
					return Enum186.const_124;
				case 125:
					return Enum186.const_125;
				case 126:
					return Enum186.const_126;
				case 127:
					return Enum186.const_127;
				case 128:
					return Enum186.const_128;
				case 129:
					return Enum186.const_129;
				case 130:
					return Enum186.const_130;
				case 131:
					return Enum186.const_131;
				case 132:
					return Enum186.const_132;
				case 133:
					return Enum186.const_133;
				case 134:
					return Enum186.const_134;
				case 135:
					return Enum186.const_135;
				case 136:
					return Enum186.const_136;
				case 137:
					return Enum186.const_137;
				case 138:
					return Enum186.const_138;
				case 139:
					return Enum186.const_139;
				case 140:
					return Enum186.const_140;
				case 141:
					return Enum186.const_141;
				case 142:
					return Enum186.const_142;
				case 143:
					return Enum186.const_143;
				case 144:
					return Enum186.const_144;
				case 145:
					return Enum186.const_145;
				case 146:
					return Enum186.const_146;
				case 147:
					return Enum186.const_147;
				case 148:
					return Enum186.const_148;
				case 149:
					return Enum186.const_149;
				case 150:
					return Enum186.const_150;
				case 151:
					return Enum186.const_151;
				case 152:
					return Enum186.const_152;
				case 153:
					return Enum186.const_153;
				case 154:
					return Enum186.const_154;
				case 155:
					return Enum186.const_155;
				case 156:
					return Enum186.const_156;
				case 157:
					return Enum186.const_157;
				case 158:
					return Enum186.const_158;
				case 159:
					return Enum186.const_159;
				case 160:
					return Enum186.const_160;
				case 161:
					return Enum186.const_161;
				case 162:
					return Enum186.const_162;
				case 163:
					return Enum186.const_163;
				case 164:
					return Enum186.const_164;
				case 165:
					return Enum186.const_165;
				case 166:
					return Enum186.const_166;
				case 167:
					return Enum186.const_167;
				case 168:
					return Enum186.const_168;
				case 169:
					return Enum186.const_169;
				case 170:
					return Enum186.const_170;
				case 171:
					return Enum186.const_171;
				case 172:
					return Enum186.const_172;
				case 173:
					return Enum186.const_173;
				case 174:
					return Enum186.const_174;
				case 175:
					return Enum186.const_175;
				case 176:
					return Enum186.const_176;
				case 177:
					return Enum186.const_177;
				case 178:
					return Enum186.const_178;
				case 179:
					return Enum186.const_179;
				case 180:
					return Enum186.const_180;
				case 181:
					return Enum186.const_181;
				case 182:
					return Enum186.const_182;
				case 183:
					return Enum186.const_183;
				case 184:
					return Enum186.const_184;
				case 185:
					return Enum186.const_185;
				case 186:
					return Enum186.const_186;
				}
			}
		}
		return Enum186.const_187;
	}

	internal static string smethod_230(Enum186 enum186_0)
	{
		return enum186_0 switch
		{
			Enum186.const_0 => "line", 
			Enum186.const_1 => "lineInv", 
			Enum186.const_2 => "triangle", 
			Enum186.const_3 => "rtTriangle", 
			Enum186.const_4 => "rect", 
			Enum186.const_5 => "diamond", 
			Enum186.const_6 => "parallelogram", 
			Enum186.const_7 => "trapezoid", 
			Enum186.const_8 => "nonIsoscelesTrapezoid", 
			Enum186.const_9 => "pentagon", 
			Enum186.const_10 => "hexagon", 
			Enum186.const_11 => "heptagon", 
			Enum186.const_12 => "octagon", 
			Enum186.const_13 => "decagon", 
			Enum186.const_14 => "dodecagon", 
			Enum186.const_15 => "star4", 
			Enum186.const_16 => "star5", 
			Enum186.const_17 => "star6", 
			Enum186.const_18 => "star7", 
			Enum186.const_19 => "star8", 
			Enum186.const_20 => "star10", 
			Enum186.const_21 => "star12", 
			Enum186.const_22 => "star16", 
			Enum186.const_23 => "star24", 
			Enum186.const_24 => "star32", 
			Enum186.const_25 => "roundRect", 
			Enum186.const_26 => "round1Rect", 
			Enum186.const_27 => "round2SameRect", 
			Enum186.const_28 => "round2DiagRect", 
			Enum186.const_29 => "snipRoundRect", 
			Enum186.const_30 => "snip1Rect", 
			Enum186.const_31 => "snip2SameRect", 
			Enum186.const_32 => "snip2DiagRect", 
			Enum186.const_33 => "plaque", 
			Enum186.const_34 => "ellipse", 
			Enum186.const_35 => "teardrop", 
			Enum186.const_36 => "homePlate", 
			Enum186.const_37 => "chevron", 
			Enum186.const_38 => "pieWedge", 
			Enum186.const_39 => "pie", 
			Enum186.const_40 => "blockArc", 
			Enum186.const_41 => "donut", 
			Enum186.const_42 => "noSmoking", 
			Enum186.const_43 => "rightArrow", 
			Enum186.const_44 => "leftArrow", 
			Enum186.const_45 => "upArrow", 
			Enum186.const_46 => "downArrow", 
			Enum186.const_47 => "stripedRightArrow", 
			Enum186.const_48 => "notchedRightArrow", 
			Enum186.const_49 => "bentUpArrow", 
			Enum186.const_50 => "leftRightArrow", 
			Enum186.const_51 => "upDownArrow", 
			Enum186.const_52 => "leftUpArrow", 
			Enum186.const_53 => "leftRightUpArrow", 
			Enum186.const_54 => "quadArrow", 
			Enum186.const_55 => "leftArrowCallout", 
			Enum186.const_56 => "rightArrowCallout", 
			Enum186.const_57 => "upArrowCallout", 
			Enum186.const_58 => "downArrowCallout", 
			Enum186.const_59 => "leftRightArrowCallout", 
			Enum186.const_60 => "upDownArrowCallout", 
			Enum186.const_61 => "quadArrowCallout", 
			Enum186.const_62 => "bentArrow", 
			Enum186.const_63 => "uturnArrow", 
			Enum186.const_64 => "circularArrow", 
			Enum186.const_65 => "leftCircularArrow", 
			Enum186.const_66 => "leftRightCircularArrow", 
			Enum186.const_67 => "curvedRightArrow", 
			Enum186.const_68 => "curvedLeftArrow", 
			Enum186.const_69 => "curvedUpArrow", 
			Enum186.const_70 => "curvedDownArrow", 
			Enum186.const_71 => "swooshArrow", 
			Enum186.const_72 => "cube", 
			Enum186.const_73 => "can", 
			Enum186.const_74 => "lightningBolt", 
			Enum186.const_75 => "heart", 
			Enum186.const_76 => "sun", 
			Enum186.const_77 => "moon", 
			Enum186.const_78 => "smileyFace", 
			Enum186.const_79 => "irregularSeal1", 
			Enum186.const_80 => "irregularSeal2", 
			Enum186.const_81 => "foldedCorner", 
			Enum186.const_82 => "bevel", 
			Enum186.const_83 => "frame", 
			Enum186.const_84 => "halfFrame", 
			Enum186.const_85 => "corner", 
			Enum186.const_86 => "diagStripe", 
			Enum186.const_87 => "chord", 
			Enum186.const_88 => "arc", 
			Enum186.const_89 => "leftBracket", 
			Enum186.const_90 => "rightBracket", 
			Enum186.const_91 => "leftBrace", 
			Enum186.const_92 => "rightBrace", 
			Enum186.const_93 => "bracketPair", 
			Enum186.const_94 => "bracePair", 
			Enum186.const_95 => "straightConnector1", 
			Enum186.const_96 => "bentConnector2", 
			Enum186.const_97 => "bentConnector3", 
			Enum186.const_98 => "bentConnector4", 
			Enum186.const_99 => "bentConnector5", 
			Enum186.const_100 => "curvedConnector2", 
			Enum186.const_101 => "curvedConnector3", 
			Enum186.const_102 => "curvedConnector4", 
			Enum186.const_103 => "curvedConnector5", 
			Enum186.const_104 => "callout1", 
			Enum186.const_105 => "callout2", 
			Enum186.const_106 => "callout3", 
			Enum186.const_107 => "accentCallout1", 
			Enum186.const_108 => "accentCallout2", 
			Enum186.const_109 => "accentCallout3", 
			Enum186.const_110 => "borderCallout1", 
			Enum186.const_111 => "borderCallout2", 
			Enum186.const_112 => "borderCallout3", 
			Enum186.const_113 => "accentBorderCallout1", 
			Enum186.const_114 => "accentBorderCallout2", 
			Enum186.const_115 => "accentBorderCallout3", 
			Enum186.const_116 => "wedgeRectCallout", 
			Enum186.const_117 => "wedgeRoundRectCallout", 
			Enum186.const_118 => "wedgeEllipseCallout", 
			Enum186.const_119 => "cloudCallout", 
			Enum186.const_120 => "cloud", 
			Enum186.const_121 => "ribbon", 
			Enum186.const_122 => "ribbon2", 
			Enum186.const_123 => "ellipseRibbon", 
			Enum186.const_124 => "ellipseRibbon2", 
			Enum186.const_125 => "leftRightRibbon", 
			Enum186.const_126 => "verticalScroll", 
			Enum186.const_127 => "horizontalScroll", 
			Enum186.const_128 => "wave", 
			Enum186.const_129 => "doubleWave", 
			Enum186.const_130 => "plus", 
			Enum186.const_131 => "flowChartProcess", 
			Enum186.const_132 => "flowChartDecision", 
			Enum186.const_133 => "flowChartInputOutput", 
			Enum186.const_134 => "flowChartPredefinedProcess", 
			Enum186.const_135 => "flowChartInternalStorage", 
			Enum186.const_136 => "flowChartDocument", 
			Enum186.const_137 => "flowChartMultidocument", 
			Enum186.const_138 => "flowChartTerminator", 
			Enum186.const_139 => "flowChartPreparation", 
			Enum186.const_140 => "flowChartManualInput", 
			Enum186.const_141 => "flowChartManualOperation", 
			Enum186.const_142 => "flowChartConnector", 
			Enum186.const_143 => "flowChartPunchedCard", 
			Enum186.const_144 => "flowChartPunchedTape", 
			Enum186.const_145 => "flowChartSummingJunction", 
			Enum186.const_146 => "flowChartOr", 
			Enum186.const_147 => "flowChartCollate", 
			Enum186.const_148 => "flowChartSort", 
			Enum186.const_149 => "flowChartExtract", 
			Enum186.const_150 => "flowChartMerge", 
			Enum186.const_151 => "flowChartOfflineStorage", 
			Enum186.const_152 => "flowChartOnlineStorage", 
			Enum186.const_153 => "flowChartMagneticTape", 
			Enum186.const_154 => "flowChartMagneticDisk", 
			Enum186.const_155 => "flowChartMagneticDrum", 
			Enum186.const_156 => "flowChartDisplay", 
			Enum186.const_157 => "flowChartDelay", 
			Enum186.const_158 => "flowChartAlternateProcess", 
			Enum186.const_159 => "flowChartOffpageConnector", 
			Enum186.const_160 => "actionButtonBlank", 
			Enum186.const_161 => "actionButtonHome", 
			Enum186.const_162 => "actionButtonHelp", 
			Enum186.const_163 => "actionButtonInformation", 
			Enum186.const_164 => "actionButtonForwardNext", 
			Enum186.const_165 => "actionButtonBackPrevious", 
			Enum186.const_166 => "actionButtonEnd", 
			Enum186.const_167 => "actionButtonBeginning", 
			Enum186.const_168 => "actionButtonReturn", 
			Enum186.const_169 => "actionButtonDocument", 
			Enum186.const_170 => "actionButtonSound", 
			Enum186.const_171 => "actionButtonMovie", 
			Enum186.const_172 => "gear6", 
			Enum186.const_173 => "gear9", 
			Enum186.const_174 => "funnel", 
			Enum186.const_175 => "mathPlus", 
			Enum186.const_176 => "mathMinus", 
			Enum186.const_177 => "mathMultiply", 
			Enum186.const_178 => "mathDivide", 
			Enum186.const_179 => "mathEqual", 
			Enum186.const_180 => "mathNotEqual", 
			Enum186.const_181 => "cornerTabs", 
			Enum186.const_182 => "squareTabs", 
			Enum186.const_183 => "plaqueTabs", 
			Enum186.const_184 => "chartX", 
			Enum186.const_185 => "chartStar", 
			Enum186.const_186 => "chartPlus", 
			_ => null, 
		};
	}

	internal static Enum186 smethod_231(AutoShapeType autoShapeType_0)
	{
		return autoShapeType_0 switch
		{
			AutoShapeType.Heptagon => Enum186.const_11, 
			AutoShapeType.Decagon => Enum186.const_13, 
			AutoShapeType.Dodecagon => Enum186.const_14, 
			AutoShapeType.Star6 => Enum186.const_17, 
			AutoShapeType.Star7 => Enum186.const_18, 
			AutoShapeType.Star10 => Enum186.const_20, 
			AutoShapeType.Star12 => Enum186.const_21, 
			AutoShapeType.RoundSingleCornerRectangle => Enum186.const_26, 
			AutoShapeType.RoundSameSideCornerRectangle => Enum186.const_27, 
			AutoShapeType.RoundDiagonalCornerRectangle => Enum186.const_28, 
			AutoShapeType.SnipRoundSingleCornerRectangle => Enum186.const_29, 
			AutoShapeType.SnipSingleCornerRectangle => Enum186.const_30, 
			AutoShapeType.SnipSameSideCornerRectangle => Enum186.const_31, 
			AutoShapeType.SnipDiagonalCornerRectangle => Enum186.const_32, 
			AutoShapeType.Teardrop => Enum186.const_35, 
			AutoShapeType.Pie => Enum186.const_39, 
			AutoShapeType.Frame => Enum186.const_83, 
			AutoShapeType.HalfFrame => Enum186.const_84, 
			AutoShapeType.L_Shape => Enum186.const_85, 
			AutoShapeType.DiagonalStripe => Enum186.const_86, 
			AutoShapeType.Chord => Enum186.const_87, 
			AutoShapeType.Cloud => Enum186.const_120, 
			AutoShapeType.MathPlus => Enum186.const_175, 
			AutoShapeType.MathMinus => Enum186.const_176, 
			AutoShapeType.MathMultiply => Enum186.const_177, 
			AutoShapeType.MathDivide => Enum186.const_178, 
			AutoShapeType.MathEqual => Enum186.const_179, 
			AutoShapeType.MathNotEqual => Enum186.const_180, 
			AutoShapeType.Rectangle => Enum186.const_4, 
			AutoShapeType.RoundedRectangle => Enum186.const_25, 
			AutoShapeType.Oval => Enum186.const_34, 
			AutoShapeType.Diamond => Enum186.const_5, 
			AutoShapeType.IsoscelesTriangle => Enum186.const_2, 
			AutoShapeType.RightTriangle => Enum186.const_3, 
			AutoShapeType.Parallelogram => Enum186.const_6, 
			AutoShapeType.Trapezoid => Enum186.const_7, 
			AutoShapeType.Hexagon => Enum186.const_10, 
			AutoShapeType.Octagon => Enum186.const_12, 
			AutoShapeType.Cross => Enum186.const_130, 
			AutoShapeType.Star5 => Enum186.const_16, 
			AutoShapeType.RightArrow => Enum186.const_43, 
			AutoShapeType.HomePlate => Enum186.const_36, 
			AutoShapeType.Cube => Enum186.const_72, 
			AutoShapeType.Arc => Enum186.const_88, 
			AutoShapeType.Line => Enum186.const_0, 
			AutoShapeType.Plaque => Enum186.const_33, 
			AutoShapeType.Can => Enum186.const_73, 
			AutoShapeType.Donut => Enum186.const_41, 
			AutoShapeType.StraightConnector => Enum186.const_95, 
			AutoShapeType.BentConnector2 => Enum186.const_96, 
			AutoShapeType.ElbowConnector => Enum186.const_97, 
			AutoShapeType.BentConnector4 => Enum186.const_98, 
			AutoShapeType.BentConnector5 => Enum186.const_99, 
			AutoShapeType.CurvedConnector2 => Enum186.const_100, 
			AutoShapeType.CurvedConnector => Enum186.const_101, 
			AutoShapeType.CurvedConnector4 => Enum186.const_102, 
			AutoShapeType.CurvedConnector5 => Enum186.const_103, 
			AutoShapeType.LineCalloutNoBorder2 => Enum186.const_104, 
			AutoShapeType.LineCalloutNoBorder3 => Enum186.const_105, 
			AutoShapeType.LineCalloutNoBorder4 => Enum186.const_106, 
			AutoShapeType.LineCalloutWithAccentBar2 => Enum186.const_107, 
			AutoShapeType.LineCalloutWithAccentBar3 => Enum186.const_108, 
			AutoShapeType.LineCalloutWithAccentBar4 => Enum186.const_109, 
			AutoShapeType.LineCalloutWithBorder2 => Enum186.const_110, 
			AutoShapeType.LineCalloutWithBorder3 => Enum186.const_111, 
			AutoShapeType.LineCalloutWithBorder4 => Enum186.const_112, 
			AutoShapeType.LineCalloutWithBorderAndAccentBar2 => Enum186.const_113, 
			AutoShapeType.LineCalloutWithBorderAndAccentBar3 => Enum186.const_114, 
			AutoShapeType.LineCalloutWithBorderAndAccentBar4 => Enum186.const_115, 
			AutoShapeType.DownRibbon => Enum186.const_121, 
			AutoShapeType.UpRibbon => Enum186.const_122, 
			AutoShapeType.Chevron => Enum186.const_37, 
			AutoShapeType.RegularPentagon => Enum186.const_9, 
			AutoShapeType.NoSymbol => Enum186.const_42, 
			AutoShapeType.Star8 => Enum186.const_19, 
			AutoShapeType.Star16 => Enum186.const_22, 
			AutoShapeType.Star32 => Enum186.const_24, 
			AutoShapeType.RectangularCallout => Enum186.const_116, 
			AutoShapeType.RoundedRectangularCallout => Enum186.const_117, 
			AutoShapeType.OvalCallout => Enum186.const_118, 
			AutoShapeType.Wave => Enum186.const_128, 
			AutoShapeType.FoldedCorner => Enum186.const_81, 
			AutoShapeType.LeftArrow => Enum186.const_44, 
			AutoShapeType.DownArrow => Enum186.const_46, 
			AutoShapeType.UpArrow => Enum186.const_45, 
			AutoShapeType.LeftRightArrow => Enum186.const_50, 
			AutoShapeType.UpDownArrow => Enum186.const_51, 
			AutoShapeType.Explosion1 => Enum186.const_79, 
			AutoShapeType.Explosion2 => Enum186.const_80, 
			AutoShapeType.LightningBolt => Enum186.const_74, 
			AutoShapeType.Heart => Enum186.const_75, 
			AutoShapeType.QuadArrow => Enum186.const_54, 
			AutoShapeType.LeftArrowCallout => Enum186.const_55, 
			AutoShapeType.RightArrowCallout => Enum186.const_56, 
			AutoShapeType.UpArrowCallout => Enum186.const_57, 
			AutoShapeType.DownArrowCallout => Enum186.const_58, 
			AutoShapeType.LeftRightArrowCallout => Enum186.const_59, 
			AutoShapeType.UpDownArrowCallout => Enum186.const_60, 
			AutoShapeType.QuadArrowCallout => Enum186.const_61, 
			AutoShapeType.Bevel => Enum186.const_82, 
			AutoShapeType.LeftBracket => Enum186.const_89, 
			AutoShapeType.RightBracket => Enum186.const_90, 
			AutoShapeType.LeftBrace => Enum186.const_91, 
			AutoShapeType.RightBrace => Enum186.const_92, 
			AutoShapeType.LeftUpArrow => Enum186.const_52, 
			AutoShapeType.BentUpArrow => Enum186.const_49, 
			AutoShapeType.BentArrow => Enum186.const_62, 
			AutoShapeType.Star24 => Enum186.const_23, 
			AutoShapeType.StripedRightArrow => Enum186.const_47, 
			AutoShapeType.NotchedRightArrow => Enum186.const_48, 
			AutoShapeType.BlockArc => Enum186.const_40, 
			AutoShapeType.SmileyFace => Enum186.const_78, 
			AutoShapeType.VerticalScroll => Enum186.const_126, 
			AutoShapeType.HorizontalScroll => Enum186.const_127, 
			AutoShapeType.CircularArrow => Enum186.const_64, 
			AutoShapeType.UTurnArrow => Enum186.const_63, 
			AutoShapeType.CurvedRightArrow => Enum186.const_67, 
			AutoShapeType.CurvedLeftArrow => Enum186.const_68, 
			AutoShapeType.CurvedUpArrow => Enum186.const_69, 
			AutoShapeType.CurvedDownArrow => Enum186.const_70, 
			AutoShapeType.CloudCallout => Enum186.const_119, 
			AutoShapeType.CurvedDownRibbon => Enum186.const_123, 
			AutoShapeType.CurvedUpRibbon => Enum186.const_124, 
			AutoShapeType.FlowChartProcess => Enum186.const_131, 
			AutoShapeType.FlowChartDecision => Enum186.const_132, 
			AutoShapeType.FlowChartData => Enum186.const_133, 
			AutoShapeType.FlowChartPredefinedProcess => Enum186.const_134, 
			AutoShapeType.FlowChartInternalStorage => Enum186.const_135, 
			AutoShapeType.FlowChartDocument => Enum186.const_136, 
			AutoShapeType.FlowChartMultidocument => Enum186.const_137, 
			AutoShapeType.FlowChartTerminator => Enum186.const_138, 
			AutoShapeType.FlowChartPreparation => Enum186.const_139, 
			AutoShapeType.FlowChartManualInput => Enum186.const_140, 
			AutoShapeType.FlowChartManualOperation => Enum186.const_141, 
			AutoShapeType.FlowChartConnector => Enum186.const_142, 
			AutoShapeType.FlowChartCard => Enum186.const_143, 
			AutoShapeType.FlowChartPunchedTape => Enum186.const_144, 
			AutoShapeType.FlowChartSummingJunction => Enum186.const_145, 
			AutoShapeType.FlowChartOr => Enum186.const_146, 
			AutoShapeType.FlowChartCollate => Enum186.const_147, 
			AutoShapeType.FlowChartSort => Enum186.const_148, 
			AutoShapeType.FlowChartExtract => Enum186.const_149, 
			AutoShapeType.FlowChartMerge => Enum186.const_150, 
			AutoShapeType.FlowChartStoredData => Enum186.const_152, 
			AutoShapeType.FlowChartSequentialAccessStorage => Enum186.const_153, 
			AutoShapeType.FlowChartMagneticDisk => Enum186.const_154, 
			AutoShapeType.FlowChartDirectAccessStorage => Enum186.const_155, 
			AutoShapeType.FlowChartDisplay => Enum186.const_156, 
			AutoShapeType.FlowChartDelay => Enum186.const_157, 
			AutoShapeType.FlowChartAlternateProcess => Enum186.const_158, 
			AutoShapeType.FlowChartOffpageConnector => Enum186.const_159, 
			AutoShapeType.LineCalloutNoBorder1 => Enum186.const_104, 
			AutoShapeType.LineCalloutWithAccentBar1 => Enum186.const_104, 
			AutoShapeType.LineCalloutWithBorder1 => Enum186.const_110, 
			AutoShapeType.LineCalloutWithBorderAndAccentBar1 => Enum186.const_110, 
			AutoShapeType.LeftRightUpArrow => Enum186.const_53, 
			AutoShapeType.Sun => Enum186.const_76, 
			AutoShapeType.Moon => Enum186.const_77, 
			AutoShapeType.DoubleBracket => Enum186.const_93, 
			AutoShapeType.DoubleBrace => Enum186.const_94, 
			AutoShapeType.Star4 => Enum186.const_15, 
			AutoShapeType.DoubleWave => Enum186.const_129, 
			_ => Enum186.const_187, 
		};
	}

	internal static AutoShapeType smethod_232(Enum186 enum186_0)
	{
		return enum186_0 switch
		{
			Enum186.const_0 => AutoShapeType.Line, 
			Enum186.const_2 => AutoShapeType.IsoscelesTriangle, 
			Enum186.const_3 => AutoShapeType.RightTriangle, 
			Enum186.const_4 => AutoShapeType.Rectangle, 
			Enum186.const_5 => AutoShapeType.Diamond, 
			Enum186.const_6 => AutoShapeType.Parallelogram, 
			Enum186.const_7 => AutoShapeType.Trapezoid, 
			Enum186.const_9 => AutoShapeType.RegularPentagon, 
			Enum186.const_10 => AutoShapeType.Hexagon, 
			Enum186.const_11 => AutoShapeType.Heptagon, 
			Enum186.const_12 => AutoShapeType.Octagon, 
			Enum186.const_13 => AutoShapeType.Decagon, 
			Enum186.const_14 => AutoShapeType.Dodecagon, 
			Enum186.const_15 => AutoShapeType.Star4, 
			Enum186.const_16 => AutoShapeType.Star5, 
			Enum186.const_17 => AutoShapeType.Star6, 
			Enum186.const_18 => AutoShapeType.Star7, 
			Enum186.const_19 => AutoShapeType.Star8, 
			Enum186.const_20 => AutoShapeType.Star10, 
			Enum186.const_21 => AutoShapeType.Star12, 
			Enum186.const_22 => AutoShapeType.Star16, 
			Enum186.const_23 => AutoShapeType.Star24, 
			Enum186.const_24 => AutoShapeType.Star32, 
			Enum186.const_25 => AutoShapeType.RoundedRectangle, 
			Enum186.const_26 => AutoShapeType.RoundSingleCornerRectangle, 
			Enum186.const_27 => AutoShapeType.RoundSameSideCornerRectangle, 
			Enum186.const_28 => AutoShapeType.RoundDiagonalCornerRectangle, 
			Enum186.const_29 => AutoShapeType.SnipRoundSingleCornerRectangle, 
			Enum186.const_30 => AutoShapeType.SnipSingleCornerRectangle, 
			Enum186.const_31 => AutoShapeType.SnipSameSideCornerRectangle, 
			Enum186.const_32 => AutoShapeType.SnipDiagonalCornerRectangle, 
			Enum186.const_33 => AutoShapeType.Plaque, 
			Enum186.const_34 => AutoShapeType.Oval, 
			Enum186.const_35 => AutoShapeType.Teardrop, 
			Enum186.const_36 => AutoShapeType.HomePlate, 
			Enum186.const_37 => AutoShapeType.Chevron, 
			Enum186.const_39 => AutoShapeType.Pie, 
			Enum186.const_40 => AutoShapeType.BlockArc, 
			Enum186.const_41 => AutoShapeType.Donut, 
			Enum186.const_42 => AutoShapeType.NoSymbol, 
			Enum186.const_43 => AutoShapeType.RightArrow, 
			Enum186.const_44 => AutoShapeType.LeftArrow, 
			Enum186.const_45 => AutoShapeType.UpArrow, 
			Enum186.const_46 => AutoShapeType.DownArrow, 
			Enum186.const_47 => AutoShapeType.StripedRightArrow, 
			Enum186.const_48 => AutoShapeType.NotchedRightArrow, 
			Enum186.const_49 => AutoShapeType.BentUpArrow, 
			Enum186.const_50 => AutoShapeType.LeftRightArrow, 
			Enum186.const_51 => AutoShapeType.UpDownArrow, 
			Enum186.const_52 => AutoShapeType.LeftUpArrow, 
			Enum186.const_53 => AutoShapeType.LeftRightUpArrow, 
			Enum186.const_54 => AutoShapeType.QuadArrow, 
			Enum186.const_55 => AutoShapeType.LeftArrowCallout, 
			Enum186.const_56 => AutoShapeType.RightArrowCallout, 
			Enum186.const_57 => AutoShapeType.UpArrowCallout, 
			Enum186.const_58 => AutoShapeType.DownArrowCallout, 
			Enum186.const_59 => AutoShapeType.LeftRightArrowCallout, 
			Enum186.const_60 => AutoShapeType.UpDownArrowCallout, 
			Enum186.const_61 => AutoShapeType.QuadArrowCallout, 
			Enum186.const_62 => AutoShapeType.BentArrow, 
			Enum186.const_63 => AutoShapeType.UTurnArrow, 
			Enum186.const_64 => AutoShapeType.CircularArrow, 
			Enum186.const_67 => AutoShapeType.CurvedRightArrow, 
			Enum186.const_68 => AutoShapeType.CurvedLeftArrow, 
			Enum186.const_69 => AutoShapeType.CurvedUpArrow, 
			Enum186.const_70 => AutoShapeType.CurvedDownArrow, 
			Enum186.const_72 => AutoShapeType.Cube, 
			Enum186.const_73 => AutoShapeType.Can, 
			Enum186.const_74 => AutoShapeType.LightningBolt, 
			Enum186.const_75 => AutoShapeType.Heart, 
			Enum186.const_76 => AutoShapeType.Sun, 
			Enum186.const_77 => AutoShapeType.Moon, 
			Enum186.const_78 => AutoShapeType.SmileyFace, 
			Enum186.const_79 => AutoShapeType.Explosion1, 
			Enum186.const_80 => AutoShapeType.Explosion2, 
			Enum186.const_81 => AutoShapeType.FoldedCorner, 
			Enum186.const_82 => AutoShapeType.Bevel, 
			Enum186.const_83 => AutoShapeType.Frame, 
			Enum186.const_84 => AutoShapeType.HalfFrame, 
			Enum186.const_85 => AutoShapeType.L_Shape, 
			Enum186.const_86 => AutoShapeType.DiagonalStripe, 
			Enum186.const_87 => AutoShapeType.Chord, 
			Enum186.const_88 => AutoShapeType.Arc, 
			Enum186.const_89 => AutoShapeType.LeftBracket, 
			Enum186.const_90 => AutoShapeType.RightBracket, 
			Enum186.const_91 => AutoShapeType.LeftBrace, 
			Enum186.const_92 => AutoShapeType.RightBrace, 
			Enum186.const_93 => AutoShapeType.DoubleBracket, 
			Enum186.const_94 => AutoShapeType.DoubleBrace, 
			Enum186.const_95 => AutoShapeType.StraightConnector, 
			Enum186.const_96 => AutoShapeType.BentConnector2, 
			Enum186.const_97 => AutoShapeType.ElbowConnector, 
			Enum186.const_98 => AutoShapeType.BentConnector4, 
			Enum186.const_99 => AutoShapeType.BentConnector5, 
			Enum186.const_100 => AutoShapeType.CurvedConnector2, 
			Enum186.const_101 => AutoShapeType.CurvedConnector, 
			Enum186.const_102 => AutoShapeType.CurvedConnector4, 
			Enum186.const_103 => AutoShapeType.CurvedConnector5, 
			Enum186.const_104 => AutoShapeType.LineCalloutNoBorder1, 
			Enum186.const_105 => AutoShapeType.LineCalloutNoBorder3, 
			Enum186.const_106 => AutoShapeType.LineCalloutNoBorder4, 
			Enum186.const_107 => AutoShapeType.LineCalloutWithAccentBar2, 
			Enum186.const_108 => AutoShapeType.LineCalloutWithAccentBar3, 
			Enum186.const_109 => AutoShapeType.LineCalloutWithAccentBar4, 
			Enum186.const_110 => AutoShapeType.LineCalloutWithBorder1, 
			Enum186.const_111 => AutoShapeType.LineCalloutWithBorder3, 
			Enum186.const_112 => AutoShapeType.LineCalloutWithBorder4, 
			Enum186.const_113 => AutoShapeType.LineCalloutWithBorderAndAccentBar2, 
			Enum186.const_114 => AutoShapeType.LineCalloutWithBorderAndAccentBar3, 
			Enum186.const_115 => AutoShapeType.LineCalloutWithBorderAndAccentBar4, 
			Enum186.const_116 => AutoShapeType.RectangularCallout, 
			Enum186.const_117 => AutoShapeType.RoundedRectangularCallout, 
			Enum186.const_118 => AutoShapeType.OvalCallout, 
			Enum186.const_119 => AutoShapeType.CloudCallout, 
			Enum186.const_120 => AutoShapeType.Cloud, 
			Enum186.const_121 => AutoShapeType.DownRibbon, 
			Enum186.const_122 => AutoShapeType.UpRibbon, 
			Enum186.const_123 => AutoShapeType.CurvedDownRibbon, 
			Enum186.const_124 => AutoShapeType.CurvedUpRibbon, 
			Enum186.const_126 => AutoShapeType.VerticalScroll, 
			Enum186.const_127 => AutoShapeType.HorizontalScroll, 
			Enum186.const_128 => AutoShapeType.Wave, 
			Enum186.const_129 => AutoShapeType.DoubleWave, 
			Enum186.const_130 => AutoShapeType.Cross, 
			Enum186.const_131 => AutoShapeType.FlowChartProcess, 
			Enum186.const_132 => AutoShapeType.FlowChartDecision, 
			Enum186.const_133 => AutoShapeType.FlowChartData, 
			Enum186.const_134 => AutoShapeType.FlowChartPredefinedProcess, 
			Enum186.const_135 => AutoShapeType.FlowChartInternalStorage, 
			Enum186.const_136 => AutoShapeType.FlowChartDocument, 
			Enum186.const_137 => AutoShapeType.FlowChartMultidocument, 
			Enum186.const_138 => AutoShapeType.FlowChartTerminator, 
			Enum186.const_139 => AutoShapeType.FlowChartPreparation, 
			Enum186.const_140 => AutoShapeType.FlowChartManualInput, 
			Enum186.const_141 => AutoShapeType.FlowChartManualOperation, 
			Enum186.const_142 => AutoShapeType.FlowChartConnector, 
			Enum186.const_143 => AutoShapeType.FlowChartCard, 
			Enum186.const_144 => AutoShapeType.FlowChartPunchedTape, 
			Enum186.const_145 => AutoShapeType.FlowChartSummingJunction, 
			Enum186.const_146 => AutoShapeType.FlowChartOr, 
			Enum186.const_147 => AutoShapeType.FlowChartCollate, 
			Enum186.const_148 => AutoShapeType.FlowChartSort, 
			Enum186.const_149 => AutoShapeType.FlowChartExtract, 
			Enum186.const_150 => AutoShapeType.FlowChartMerge, 
			Enum186.const_152 => AutoShapeType.FlowChartStoredData, 
			Enum186.const_153 => AutoShapeType.FlowChartSequentialAccessStorage, 
			Enum186.const_154 => AutoShapeType.FlowChartMagneticDisk, 
			Enum186.const_155 => AutoShapeType.FlowChartDirectAccessStorage, 
			Enum186.const_156 => AutoShapeType.FlowChartDisplay, 
			Enum186.const_157 => AutoShapeType.FlowChartDelay, 
			Enum186.const_158 => AutoShapeType.FlowChartAlternateProcess, 
			Enum186.const_159 => AutoShapeType.FlowChartOffpageConnector, 
			Enum186.const_175 => AutoShapeType.MathPlus, 
			Enum186.const_176 => AutoShapeType.MathMinus, 
			Enum186.const_177 => AutoShapeType.MathMultiply, 
			Enum186.const_178 => AutoShapeType.MathDivide, 
			Enum186.const_179 => AutoShapeType.MathEqual, 
			Enum186.const_180 => AutoShapeType.MathNotEqual, 
			_ => AutoShapeType.Unknown, 
		};
	}

	internal static bool smethod_233(Shape shape_0)
	{
		if (shape_0.MsoDrawingType == MsoDrawingType.Picture)
		{
			return false;
		}
		if (shape_0.AutoShapeType != AutoShapeType.Unknown && smethod_231(shape_0.AutoShapeType) != Enum186.const_187)
		{
			return true;
		}
		MsoDrawingType msoDrawingType = shape_0.MsoDrawingType;
		if (msoDrawingType == MsoDrawingType.Line)
		{
			return true;
		}
		return false;
	}

	internal static string smethod_234(AutoShapeType autoShapeType_0)
	{
		return autoShapeType_0 switch
		{
			AutoShapeType.TextPlainText => "textPlain", 
			AutoShapeType.TextStop => "textStop", 
			AutoShapeType.TextTriangle => "textTriangle", 
			AutoShapeType.TextTriangleInverted => "textTriangleInverted", 
			AutoShapeType.TextChevron => "textChevron", 
			AutoShapeType.TextChevronInverted => "textChevronInverted", 
			AutoShapeType.TextRingInside => "textRingInside", 
			AutoShapeType.TextRingOutside => "textRingOutside", 
			AutoShapeType.TextArchUpCurve => "textArchUp", 
			AutoShapeType.TextArchDownCurve => "textArchDownCurve", 
			AutoShapeType.TextCircleCurve => "textCircleCurve", 
			AutoShapeType.TextButtonCurve => "textButtonCurve", 
			AutoShapeType.TextArchUpPour => "textArchUpPour", 
			AutoShapeType.TextArchDownPour => "textArchDownPour", 
			AutoShapeType.TextCirclePour => "textCirclePour", 
			AutoShapeType.TextButtonPour => "textButtonPour", 
			AutoShapeType.TextCurveUp => "textCurveUp", 
			AutoShapeType.TextCurveDown => "textCurveDown", 
			AutoShapeType.TextCascadeUp => "textCascadeUp", 
			AutoShapeType.TextCascadeDown => "textCascadeDown", 
			AutoShapeType.TextWave1 => "textWave1", 
			AutoShapeType.TextWave2 => "textWave2", 
			AutoShapeType.TextWave3 => "textDoubleWave1", 
			AutoShapeType.TextWave4 => "textWave4", 
			AutoShapeType.TextInflate => "textInflate", 
			AutoShapeType.TextDeflate => "textDeflate", 
			AutoShapeType.TextInflateBottom => "textInflateBottom", 
			AutoShapeType.TextDeflateBottom => "textDeflateBottom", 
			AutoShapeType.TextInflateTop => "textInflateTop", 
			AutoShapeType.TextDeflateTop => "textDeflateTop", 
			AutoShapeType.TextDeflateInflateDeflate => "textDeflateInflateDeflate", 
			AutoShapeType.TextFadeRight => "textFadeRight", 
			AutoShapeType.TextFadeLeft => "textFadeLeft", 
			AutoShapeType.TextFadeUp => "textFadeUp", 
			AutoShapeType.TextFadeDown => "textFadeDown", 
			AutoShapeType.TextSlantUp => "textSlantUp", 
			AutoShapeType.TextSlantDown => "textSlantDown", 
			AutoShapeType.TextCanUp => "textCanUp", 
			AutoShapeType.TextCanDown => "textCanDown", 
			_ => "", 
		};
	}

	internal static bool smethod_235(AutoShapeType autoShapeType_0)
	{
		switch (autoShapeType_0)
		{
		default:
			return false;
		case AutoShapeType.TextPlainText:
		case AutoShapeType.TextStop:
		case AutoShapeType.TextTriangle:
		case AutoShapeType.TextTriangleInverted:
		case AutoShapeType.TextChevron:
		case AutoShapeType.TextChevronInverted:
		case AutoShapeType.TextRingInside:
		case AutoShapeType.TextRingOutside:
		case AutoShapeType.TextArchUpCurve:
		case AutoShapeType.TextArchDownCurve:
		case AutoShapeType.TextCircleCurve:
		case AutoShapeType.TextButtonCurve:
		case AutoShapeType.TextArchUpPour:
		case AutoShapeType.TextArchDownPour:
		case AutoShapeType.TextCirclePour:
		case AutoShapeType.TextButtonPour:
		case AutoShapeType.TextCurveUp:
		case AutoShapeType.TextCurveDown:
		case AutoShapeType.TextCascadeUp:
		case AutoShapeType.TextCascadeDown:
		case AutoShapeType.TextWave1:
		case AutoShapeType.TextWave2:
		case AutoShapeType.TextWave3:
		case AutoShapeType.TextWave4:
		case AutoShapeType.TextInflate:
		case AutoShapeType.TextDeflate:
		case AutoShapeType.TextInflateBottom:
		case AutoShapeType.TextDeflateBottom:
		case AutoShapeType.TextInflateTop:
		case AutoShapeType.TextDeflateTop:
		case AutoShapeType.TextDeflateInflateDeflate:
		case AutoShapeType.TextFadeRight:
		case AutoShapeType.TextFadeLeft:
		case AutoShapeType.TextFadeUp:
		case AutoShapeType.TextFadeDown:
		case AutoShapeType.TextSlantUp:
		case AutoShapeType.TextSlantDown:
		case AutoShapeType.TextCanUp:
		case AutoShapeType.TextCanDown:
			return true;
		}
	}

	internal static string smethod_236(PivotGroupByType pivotGroupByType_0)
	{
		return pivotGroupByType_0 switch
		{
			PivotGroupByType.RangeOfValues => "range", 
			PivotGroupByType.Seconds => "seconds", 
			PivotGroupByType.Minutes => "minutes", 
			PivotGroupByType.Hours => "hours", 
			PivotGroupByType.Days => "days", 
			PivotGroupByType.Months => "months", 
			PivotGroupByType.Quarters => "quarters", 
			PivotGroupByType.Years => "years", 
			_ => "", 
		};
	}

	internal static PivotGroupByType smethod_237(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_187 == null)
			{
				Class1742.dictionary_187 = new Dictionary<string, int>(8)
				{
					{ "days", 0 },
					{ "hours", 1 },
					{ "minutes", 2 },
					{ "months", 3 },
					{ "quarters", 4 },
					{ "range", 5 },
					{ "seconds", 6 },
					{ "years", 7 }
				};
			}
			if (Class1742.dictionary_187.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return PivotGroupByType.Days;
				case 1:
					return PivotGroupByType.Hours;
				case 2:
					return PivotGroupByType.Minutes;
				case 3:
					return PivotGroupByType.Months;
				case 4:
					return PivotGroupByType.Quarters;
				case 5:
					return PivotGroupByType.RangeOfValues;
				case 6:
					return PivotGroupByType.Seconds;
				case 7:
					return PivotGroupByType.Years;
				}
			}
		}
		return PivotGroupByType.RangeOfValues;
	}

	internal static string smethod_238(Enum185 enum185_0)
	{
		return enum185_0 switch
		{
			Enum185.const_0 => "data", 
			Enum185.const_1 => "default", 
			Enum185.const_2 => "sum", 
			Enum185.const_3 => "countA", 
			Enum185.const_4 => "count", 
			Enum185.const_5 => "avg", 
			Enum185.const_6 => "max", 
			Enum185.const_7 => "min", 
			Enum185.const_8 => "product", 
			Enum185.const_9 => "stdDev", 
			Enum185.const_10 => "stdDevP", 
			Enum185.const_11 => "var", 
			Enum185.const_12 => "varP", 
			Enum185.const_13 => "grand", 
			Enum185.const_14 => "blank", 
			_ => "", 
		};
	}

	internal static Enum185 smethod_239(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_188 == null)
			{
				Class1742.dictionary_188 = new Dictionary<string, int>(15)
				{
					{ "data", 0 },
					{ "default", 1 },
					{ "avg", 2 },
					{ "count", 3 },
					{ "countA", 4 },
					{ "grand", 5 },
					{ "max", 6 },
					{ "min", 7 },
					{ "product", 8 },
					{ "stdDev", 9 },
					{ "stdDevP", 10 },
					{ "sum", 11 },
					{ "var", 12 },
					{ "varP", 13 },
					{ "blank", 14 }
				};
			}
			if (Class1742.dictionary_188.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return Enum185.const_0;
				case 1:
					return Enum185.const_1;
				case 2:
					return Enum185.const_5;
				case 3:
					return Enum185.const_4;
				case 4:
					return Enum185.const_3;
				case 5:
					return Enum185.const_13;
				case 6:
					return Enum185.const_6;
				case 7:
					return Enum185.const_7;
				case 8:
					return Enum185.const_8;
				case 9:
					return Enum185.const_9;
				case 10:
					return Enum185.const_10;
				case 11:
					return Enum185.const_2;
				case 12:
					return Enum185.const_11;
				case 13:
					return Enum185.const_12;
				case 14:
					return Enum185.const_14;
				}
			}
		}
		return Enum185.const_1;
	}

	internal static string smethod_240(TextOverflowType textOverflowType_0)
	{
		return textOverflowType_0 switch
		{
			TextOverflowType.Clip => "clip", 
			TextOverflowType.Ellipsis => "ellipsis", 
			_ => "overflow", 
		};
	}

	internal static TextOverflowType smethod_241(string string_4)
	{
		return string_4 switch
		{
			"ellipsis" => TextOverflowType.Ellipsis, 
			"clip" => TextOverflowType.Clip, 
			_ => TextOverflowType.Overflow, 
		};
	}

	internal static string smethod_242(Enum22 enum22_0)
	{
		return enum22_0 switch
		{
			Enum22.const_0 => "0", 
			Enum22.const_1 => "1", 
			Enum22.const_2 => "2", 
			Enum22.const_3 => "3", 
			Enum22.const_4 => "4", 
			_ => "1", 
		};
	}

	internal static Enum22 smethod_243(string string_4)
	{
		return string_4 switch
		{
			"4" => Enum22.const_4, 
			"3" => Enum22.const_3, 
			"2" => Enum22.const_2, 
			"1" => Enum22.const_1, 
			"0" => Enum22.const_0, 
			_ => Enum22.const_1, 
		};
	}

	internal static string smethod_244(string string_4)
	{
		int num = string_4.LastIndexOf(".");
		int num2 = string_4.LastIndexOf('\\');
		if (num != -1)
		{
			return string_4.Substring(num2 + 1, num - num2 - 1);
		}
		return "";
	}

	internal static string smethod_245(string string_4, Class442 class442_0)
	{
		StringBuilder stringBuilder = new StringBuilder(8000);
		stringBuilder.Append("<connection id=\"");
		if (class442_0 != null && class442_0.arrayList_0 != null)
		{
			stringBuilder.Append(class442_0.arrayList_0.Count + 1);
		}
		else
		{
			stringBuilder.Append("1");
		}
		stringBuilder.Append("\" ");
		stringBuilder.Append("name=\"");
		stringBuilder.Append(smethod_244(string_4));
		stringBuilder.Append("\" ");
		stringBuilder.Append("type=\"4\" ");
		stringBuilder.Append("refreshedVersion=\"0\" ");
		stringBuilder.Append("background=\"1\"> ");
		stringBuilder.Append("<webPr ");
		stringBuilder.Append("xml=\"1\" ");
		stringBuilder.Append("sourceData=\"1\" ");
		stringBuilder.Append("parsePre=\"1\" ");
		stringBuilder.Append("consecutive=\"1\" ");
		stringBuilder.Append("url=\"");
		stringBuilder.Append(string_4);
		stringBuilder.Append("\"");
		stringBuilder.Append(" htmlTables=\"1\"");
		stringBuilder.Append("/>");
		stringBuilder.Append("</connection>");
		return stringBuilder.ToString();
	}

	internal static string smethod_246(int int_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<Schema ID=\"Schema");
		stringBuilder.Append(int_0);
		stringBuilder.Append("\">");
		stringBuilder.Append("<xsd:schema xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"\"> </xsd:schema> </Schema>");
		return stringBuilder.ToString();
	}

	internal static string smethod_247(string string_4, string string_5)
	{
		if (string_5[0] != '/' && string_5[0] != '\\')
		{
			switch (string_5[0])
			{
			default:
				return string_4 + string_5;
			case '.':
			{
				int num = 0;
				int num2 = 0;
				num2 = 0;
				while (num2 < string_5.Length && num2 + 3 < string_5.Length && string_5[num2] == '.' && string_5[num2 + 1] == '.' && (string_5[num2 + 2] == '/' || string_5[num2 + 2] == '\\'))
				{
					num2 += 3;
					num++;
				}
				int num3 = string_4.Length - 1;
				while (true)
				{
					if (num3 >= 0)
					{
						if (string_4[num3] == '/' || string_4[num3] == '\\')
						{
							num--;
							if (num < 0)
							{
								break;
							}
						}
						num3--;
						continue;
					}
					return string_5;
				}
				return string_4.Substring(0, num3 + 1) + string_5.Substring(num2);
			}
			case '/':
			case '\\':
				return string_5;
			}
		}
		return string_5;
	}
}
