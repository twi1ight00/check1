using System.Collections.Generic;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using ns1;
using ns21;

namespace ns2;

internal class Class1673
{
	internal static PivotTableSourceType smethod_0(int int_0)
	{
		return int_0 switch
		{
			8 => PivotTableSourceType.PivotTable, 
			1 => PivotTableSourceType.ListDatabase, 
			2 => PivotTableSourceType.External, 
			4 => PivotTableSourceType.Consilidation, 
			_ => PivotTableSourceType.ListDatabase, 
		};
	}

	internal static ThemeColorType smethod_1(int int_0)
	{
		return (ThemeColorType)int_0;
	}

	internal static int smethod_2(ThemeColorType themeColorType_0)
	{
		return (int)themeColorType_0;
	}

	internal static ErrorType smethod_3(string error, out bool isError)
	{
		isError = true;
		if (error.Length == 0)
		{
			isError = false;
			return ErrorType.Invalid;
		}
		if (error[0] != '#')
		{
			isError = false;
			return ErrorType.Invalid;
		}
		string key;
		if ((key = error) != null)
		{
			if (Class1742.dictionary_212 == null)
			{
				Class1742.dictionary_212 = new Dictionary<string, int>(8)
				{
					{ "#DIV/0!", 0 },
					{ "#N/A", 1 },
					{ "#NAME?", 2 },
					{ "#NULL!", 3 },
					{ "#NUM!", 4 },
					{ "#REF!", 5 },
					{ "#VALUE!", 6 },
					{ "#Recursive Reference!", 7 }
				};
			}
			if (Class1742.dictionary_212.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return ErrorType.Div;
				case 1:
					return ErrorType.NA;
				case 2:
					return ErrorType.Name;
				case 3:
					return ErrorType.Null;
				case 4:
					return ErrorType.Number;
				case 5:
					return ErrorType.Ref;
				case 6:
					return ErrorType.Value;
				case 7:
					return ErrorType.Recursive;
				}
			}
		}
		isError = false;
		return ErrorType.Invalid;
	}

	internal static string smethod_4(ErrorType errorType_0)
	{
		return errorType_0 switch
		{
			ErrorType.Div => "#DIV/0!", 
			ErrorType.NA => "#N/A", 
			ErrorType.Name => "#NAME?", 
			ErrorType.Null => "#NULL!", 
			ErrorType.Number => "#NUM!", 
			ErrorType.Ref => "#REF!", 
			ErrorType.Recursive => "#Recursive Reference!", 
			ErrorType.Value => "#VALUE!", 
			_ => null, 
		};
	}

	internal static ErrorType smethod_5(byte byte_0)
	{
		return byte_0 switch
		{
			15 => ErrorType.Value, 
			7 => ErrorType.Div, 
			0 => ErrorType.Null, 
			29 => ErrorType.Name, 
			23 => ErrorType.Ref, 
			42 => ErrorType.NA, 
			36 => ErrorType.Number, 
			_ => ErrorType.Invalid, 
		};
	}

	internal static string smethod_6(byte byte_0)
	{
		return byte_0 switch
		{
			15 => "#VALUE!", 
			7 => "#DIV/0!", 
			0 => "#NULL!", 
			29 => "#NAME?", 
			23 => "#REF!", 
			42 => "#N/A", 
			36 => "#NUM!", 
			_ => null, 
		};
	}

	internal static bool smethod_7(string string_0)
	{
		if (string_0.Length == 0)
		{
			return false;
		}
		if (string_0[0] != '#')
		{
			return false;
		}
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_213 == null)
			{
				Class1742.dictionary_213 = new Dictionary<string, int>(8)
				{
					{ "#DIV/0!", 0 },
					{ "#N/A", 1 },
					{ "#NAME?", 2 },
					{ "#NULL!", 3 },
					{ "#NUM!", 4 },
					{ "#REF!", 5 },
					{ "#VALUE!", 6 },
					{ "#Recursive Reference!", 7 }
				};
			}
			if (Class1742.dictionary_213.TryGetValue(key, out var value))
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
					return true;
				}
			}
		}
		return false;
	}

	internal static bool smethod_8(string string_0)
	{
		return Class428.smethod_0(string_0);
	}

	internal static bool smethod_9(string string_0, ref bool bool_0)
	{
		if (string_0.Length == 0)
		{
			return false;
		}
		if (string_0[0] != '#')
		{
			return false;
		}
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_214 == null)
			{
				Class1742.dictionary_214 = new Dictionary<string, int>(8)
				{
					{ "#DIV/0!", 0 },
					{ "#N/A", 1 },
					{ "#NAME?", 2 },
					{ "#NULL!", 3 },
					{ "#NUM!", 4 },
					{ "#REF!", 5 },
					{ "#VALUE!", 6 },
					{ "#Recursive Reference!", 7 }
				};
			}
			if (Class1742.dictionary_214.TryGetValue(key, out var value))
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
					return true;
				case 7:
					bool_0 = true;
					return true;
				}
			}
		}
		return false;
	}

	internal static TextAlignmentType smethod_10(int int_0, bool bool_0)
	{
		if (bool_0)
		{
			switch (int_0)
			{
			case 0:
				return TextAlignmentType.Top;
			case 1:
				return TextAlignmentType.Center;
			case 2:
				return TextAlignmentType.Bottom;
			case 3:
				return TextAlignmentType.Justify;
			case 4:
				return TextAlignmentType.Distributed;
			}
		}
		else
		{
			switch (int_0)
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
				return TextAlignmentType.Fill;
			case 5:
				return TextAlignmentType.Justify;
			case 6:
				return TextAlignmentType.CenterAcross;
			case 7:
				return TextAlignmentType.Distributed;
			}
		}
		return TextAlignmentType.General;
	}

	internal static int smethod_11(TextAlignmentType textAlignmentType_0, bool bool_0)
	{
		int result = 0;
		if (bool_0)
		{
			switch (textAlignmentType_0)
			{
			case TextAlignmentType.Top:
				result = 0;
				break;
			case TextAlignmentType.Bottom:
				result = 2;
				break;
			case TextAlignmentType.Center:
				result = 1;
				break;
			case TextAlignmentType.Distributed:
				result = 4;
				break;
			case TextAlignmentType.Justify:
				result = 3;
				break;
			}
		}
		else
		{
			switch (textAlignmentType_0)
			{
			case TextAlignmentType.Center:
				result = 2;
				break;
			case TextAlignmentType.CenterAcross:
				result = 6;
				break;
			case TextAlignmentType.Distributed:
				result = 7;
				break;
			case TextAlignmentType.Fill:
				result = 4;
				break;
			case TextAlignmentType.General:
				result = 0;
				break;
			case TextAlignmentType.Justify:
				result = 5;
				break;
			case TextAlignmentType.Left:
				result = 1;
				break;
			case TextAlignmentType.Right:
				result = 3;
				break;
			}
		}
		return result;
	}

	internal static OperatorType smethod_12(byte byte_0)
	{
		return byte_0 switch
		{
			1 => OperatorType.Between, 
			2 => OperatorType.NotBetween, 
			3 => OperatorType.Equal, 
			4 => OperatorType.NotEqual, 
			5 => OperatorType.GreaterThan, 
			6 => OperatorType.LessThan, 
			7 => OperatorType.GreaterOrEqual, 
			8 => OperatorType.LessOrEqual, 
			_ => OperatorType.None, 
		};
	}

	internal static IconSetType smethod_13(int int_0)
	{
		return int_0 switch
		{
			0 => IconSetType.Arrows3, 
			1 => IconSetType.ArrowsGray3, 
			2 => IconSetType.Flags3, 
			3 => IconSetType.TrafficLights31, 
			4 => IconSetType.TrafficLights32, 
			5 => IconSetType.Signs3, 
			6 => IconSetType.Symbols3, 
			7 => IconSetType.Symbols32, 
			8 => IconSetType.Arrows4, 
			9 => IconSetType.ArrowsGray4, 
			10 => IconSetType.RedToBlack4, 
			11 => IconSetType.Rating4, 
			12 => IconSetType.TrafficLights4, 
			13 => IconSetType.Arrows5, 
			14 => IconSetType.ArrowsGray5, 
			15 => IconSetType.Rating5, 
			16 => IconSetType.Quarters5, 
			_ => IconSetType.Arrows3, 
		};
	}

	internal static int smethod_14(IconSetType iconSetType_0)
	{
		return iconSetType_0 switch
		{
			IconSetType.Arrows3 => 0, 
			IconSetType.ArrowsGray3 => 1, 
			IconSetType.Flags3 => 2, 
			IconSetType.Signs3 => 5, 
			IconSetType.Symbols3 => 6, 
			IconSetType.Symbols32 => 7, 
			IconSetType.TrafficLights31 => 3, 
			IconSetType.TrafficLights32 => 4, 
			IconSetType.Arrows4 => 8, 
			IconSetType.ArrowsGray4 => 9, 
			IconSetType.Rating4 => 11, 
			IconSetType.RedToBlack4 => 10, 
			IconSetType.TrafficLights4 => 12, 
			IconSetType.Arrows5 => 13, 
			IconSetType.ArrowsGray5 => 14, 
			IconSetType.Quarters5 => 16, 
			IconSetType.Rating5 => 15, 
			_ => 0, 
		};
	}

	internal static MsoPathType smethod_15(int int_0)
	{
		MsoPathType result = MsoPathType.Unknown;
		switch (int_0)
		{
		case 0:
			result = MsoPathType.MsopathLineTo;
			break;
		case 1:
			result = MsoPathType.MsopathCurveTo;
			break;
		case 2:
			result = MsoPathType.MsopathMoveTo;
			break;
		case 3:
			result = MsoPathType.MsopathClose;
			break;
		case 4:
			result = MsoPathType.MsopathEnd;
			break;
		case 5:
			result = MsoPathType.MsopathEscape;
			break;
		}
		return result;
	}

	internal static int smethod_16(MsoPathType msoPathType_0)
	{
		int result = 5;
		switch (msoPathType_0)
		{
		case MsoPathType.MsopathLineTo:
			result = 0;
			break;
		case MsoPathType.MsopathCurveTo:
			result = 1;
			break;
		case MsoPathType.MsopathMoveTo:
			result = 2;
			break;
		case MsoPathType.MsopathClose:
			result = 3;
			break;
		case MsoPathType.MsopathEnd:
			result = 4;
			break;
		case MsoPathType.MsopathEscape:
			result = 5;
			break;
		}
		return result;
	}

	internal static Enum131 smethod_17(string string_0)
	{
		Enum131 result = Enum131.const_5;
		switch (string_0)
		{
		case "none":
			result = Enum131.const_4;
			break;
		case "lightenLess":
			result = Enum131.const_3;
			break;
		case "lighten":
			result = Enum131.const_2;
			break;
		case "darkenLess":
			result = Enum131.const_1;
			break;
		case "darken":
			result = Enum131.const_0;
			break;
		}
		return result;
	}

	internal static string smethod_18(Enum131 enum131_0)
	{
		string result = "norm";
		switch (enum131_0)
		{
		case Enum131.const_0:
			result = "darken";
			break;
		case Enum131.const_1:
			result = "darkenLess";
			break;
		case Enum131.const_2:
			result = "lighten";
			break;
		case Enum131.const_3:
			result = "lightenLess";
			break;
		case Enum131.const_4:
			result = "none";
			break;
		}
		return result;
	}
}
