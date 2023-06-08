using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns2;
using ns22;
using ns26;

namespace ns15;

internal class Class1516
{
	internal static bool smethod_0(string string_0)
	{
		if (string_0 != null)
		{
			return string_0 == "";
		}
		return true;
	}

	internal static int smethod_1(double double_0, string string_0)
	{
		double num = smethod_2(double_0, string_0);
		return (int)(num * double_0 / 72.0 + 0.5);
	}

	internal static double smethod_2(double double_0, string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			char c = string_0[string_0.Length - 1];
			if (c >= '0' && c <= '9')
			{
				return smethod_16(string_0);
			}
			string text = string_0.Substring(string_0.Length - 2);
			string_0 = string_0.Substring(0, string_0.Length - 2);
			double num = smethod_16(string_0);
			switch (text)
			{
			case "cm":
				num = num * 72.0 / 2.54;
				break;
			case "px":
				num = num * 72.0 / double_0;
				break;
			case "in":
				num *= 72.0;
				break;
			}
			return num;
		}
		return 0.0;
	}

	internal static string smethod_3(string string_0)
	{
		if (string_0[0] == '[')
		{
			string_0 = string_0.Substring(1, string_0.Length - 2);
		}
		int num = string_0.IndexOf(':');
		if (num != -1)
		{
			string[] array = string_0.Split(':');
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i][0] == '$')
				{
					array[i] = array[i].Substring(1);
				}
				if (array[i].IndexOf('.') == 0)
				{
					array[i] = array[i].Substring(1);
				}
				else
				{
					array[i] = array[i].Replace('.', '!');
				}
				stringBuilder.Append(array[i]);
				if (i != array.Length - 1)
				{
					stringBuilder.Append(':');
				}
			}
			return stringBuilder.ToString();
		}
		string[] array2 = string_0.Split('.');
		if (array2[0][0] == '$')
		{
			array2[0] = array2[0].Substring(1);
		}
		return array2[0] + "!" + array2[1];
	}

	internal static int[] Intersect(int int_0, int int_1, int int_2, int int_3)
	{
		int num = ((int_0 < int_2) ? int_2 : int_0);
		int num2 = ((int_1 > int_3) ? int_3 : int_1);
		if (num > num2)
		{
			return null;
		}
		return new int[2] { num, num2 };
	}

	internal static void smethod_4(PageSetup pageSetup, out int printTitleStartColumn, out int printTitleEndColumn)
	{
		printTitleEndColumn = -1;
		printTitleStartColumn = -1;
		string text = pageSetup.PrintTitleColumns;
		if (text == null || text == "")
		{
			return;
		}
		if (text[0] == '=')
		{
			text = text.Substring(1);
		}
		string[] array = text.Split(':');
		if (array.Length == 2)
		{
			if (array[0][0] == '$')
			{
				array[0] = array[0].Substring(1);
			}
			printTitleStartColumn = CellsHelper.ColumnNameToIndex(array[0]);
			if (array[1][0] == '$')
			{
				array[1] = array[1].Substring(1);
			}
			printTitleEndColumn = CellsHelper.ColumnNameToIndex(array[1]);
		}
	}

	internal static void smethod_5(PageSetup pageSetup, out int printTitleStartRow, out int printTitleEndRow)
	{
		printTitleEndRow = -1;
		printTitleStartRow = -1;
		string text = pageSetup.PrintTitleRows;
		if (text == null || text == "")
		{
			return;
		}
		if (text[0] == '=')
		{
			text = text.Substring(1);
		}
		string[] array = text.Split(':');
		if (array.Length == 2)
		{
			if (array[0][0] == '$')
			{
				array[0] = array[0].Substring(1);
			}
			printTitleStartRow = int.Parse(array[0]) - 1;
			if (array[1][0] == '$')
			{
				array[1] = array[1].Substring(1);
			}
			printTitleEndRow = int.Parse(array[1]) - 1;
		}
	}

	internal static string smethod_6(string string_0, string string_1)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			if (string_0[0] == '=')
			{
				string_0 = string_0.Substring(1);
			}
			if (string_0[0] == '(')
			{
				string_0 = string_0.Substring(1, string_0.Length - 2);
			}
			string[] array = string_0.Split(',');
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				smethod_7(stringBuilder, array[i], string_1);
				if (i != array.Length - 1)
				{
					stringBuilder.Append(' ');
				}
			}
			return stringBuilder.ToString();
		}
		return string_0;
	}

	internal static void smethod_7(StringBuilder stringBuilder_0, string string_0, string string_1)
	{
		if (string_0 == null || string_0 == "")
		{
			return;
		}
		if (string_0[0] == '=')
		{
			string_0 = string_0.Substring(1);
		}
		string[] array = string_0.Split(':');
		if (array[0].IndexOf('!') != -1)
		{
			stringBuilder_0.Append(array[0].Replace('!', '.'));
		}
		else
		{
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append('.');
			stringBuilder_0.Append(array[0]);
		}
		if (array.Length > 1)
		{
			stringBuilder_0.Append(':');
			if (array[1].IndexOf('.') != -1)
			{
				stringBuilder_0.Append(array[1].Replace('!', '.'));
				return;
			}
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append('.');
			stringBuilder_0.Append(array[1]);
		}
	}

	internal static string smethod_8(Color color_0)
	{
		return "K" + Class1025.smethod_5(color_0.R) + Class1025.smethod_5(color_0.G) + Class1025.smethod_5(color_0.B);
	}

	internal static string smethod_9(Color color_0)
	{
		return "#" + Class1025.smethod_5(color_0.R) + Class1025.smethod_5(color_0.G) + Class1025.smethod_5(color_0.B);
	}

	internal static string smethod_10(string string_0)
	{
		return string_0.ToLower() switch
		{
			"#0000ff" => "BLUE", 
			"#008000" => "GREEN", 
			"#ff0000" => "RED", 
			_ => null, 
		};
	}

	internal static Color smethod_11(string string_0)
	{
		if (string_0[0] == '#')
		{
			string_0 = string_0.Substring(1);
		}
		int argb = int.Parse(string_0, NumberStyles.HexNumber);
		return Color.FromArgb(argb);
	}

	internal static string smethod_12(double double_0)
	{
		return double_0.ToString(CultureInfo.InvariantCulture);
	}

	internal static string smethod_13(int int_0)
	{
		return int_0.ToString(CultureInfo.InvariantCulture);
	}

	internal static string smethod_14(short short_0)
	{
		return short_0.ToString(CultureInfo.InvariantCulture);
	}

	internal static string smethod_15(double double_0)
	{
		return double_0.ToString(CultureInfo.InvariantCulture);
	}

	internal static double smethod_16(string string_0)
	{
		return double.Parse(string_0, CultureInfo.InvariantCulture);
	}

	internal static string smethod_17(CellBorderType cellBorderType_0)
	{
		switch (cellBorderType_0)
		{
		default:
			return "1.0pt solid ";
		case CellBorderType.None:
			return null;
		case CellBorderType.Thick:
			return "4.0pt solid ";
		case CellBorderType.Double:
			return "3.0pt double ";
		case CellBorderType.Dotted:
		case CellBorderType.Hair:
			return "0.05pt solid ";
		case CellBorderType.Thin:
		case CellBorderType.Dashed:
		case CellBorderType.DashDot:
		case CellBorderType.DashDotDot:
			return "1.0pt solid ";
		case CellBorderType.Medium:
		case CellBorderType.MediumDashed:
		case CellBorderType.MediumDashDot:
		case CellBorderType.MediumDashDotDot:
		case CellBorderType.SlantedDashDot:
			return "2.5pt solid ";
		}
	}

	internal static string smethod_18(bool bool_0)
	{
		if (bool_0)
		{
			return "true";
		}
		return "false";
	}

	internal static string[] smethod_19(string string_0)
	{
		ArrayList arrayList = new ArrayList();
		int num = 0;
		for (int i = 0; i < string_0.Length; i++)
		{
			switch (string_0[i])
			{
			case '[':
				if (i != string_0.Length - 1)
				{
					for (i++; i < string_0.Length && string_0[i] != ']'; i++)
					{
					}
				}
				break;
			case ';':
				if (i - num > 1)
				{
					arrayList.Add(string_0.Substring(num, i - num));
				}
				else
				{
					arrayList.Add("");
				}
				num = i + 1;
				break;
			case '"':
				if (i != string_0.Length - 1)
				{
					for (i++; i < string_0.Length && string_0[i] != '"'; i++)
					{
					}
				}
				break;
			}
		}
		if (num < string_0.Length)
		{
			arrayList.Add(string_0.Substring(num));
		}
		string[] array = new string[arrayList.Count];
		for (int j = 0; j < arrayList.Count; j++)
		{
			array[j] = (string)arrayList[j];
		}
		return array;
	}

	internal static double smethod_20(string string_0)
	{
		double num = 0.0;
		int num2 = 0;
		for (int i = 0; i < string_0.Length; i++)
		{
			switch (string_0[i])
			{
			case 'H':
				num += (double)((float)num2 / 24f);
				num2 = 0;
				break;
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
				num2 = num2 * 10 + string_0[i] - 48;
				break;
			case 'S':
				num += (double)((float)num2 / 86400f);
				num2 = 0;
				break;
			case 'M':
				num += (double)((float)num2 / 1440f);
				num2 = 0;
				break;
			}
		}
		return num;
	}

	internal static string smethod_21(double double_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (double_0 != 0.0)
		{
			string text = null;
			if (double_0 > 0.0)
			{
				text = "PT";
			}
			else
			{
				text = "-PT";
				double_0 = 0.0 - double_0;
			}
			stringBuilder.Append(text);
			double_0 *= 24.0;
			double num = Math.Floor(double_0);
			double num2 = double_0 - num;
			if (10.0 - num > 0.0)
			{
				stringBuilder.Append(0);
			}
			stringBuilder.Append((int)num);
			if (num2 == 0.0)
			{
				stringBuilder.Append("H00M00S");
				return stringBuilder.ToString();
			}
			num2 *= 60.0;
			double num3 = Math.Floor(num2);
			double num4 = num2 - num3;
			stringBuilder.Append("H");
			if (10.0 - num3 > 0.0)
			{
				stringBuilder.Append(0);
			}
			stringBuilder.Append((int)num3);
			if (num4 == 0.0)
			{
				stringBuilder.Append("M00S");
				return stringBuilder.ToString();
			}
			num4 *= 60.0;
			double num5 = Math.Floor(num4);
			stringBuilder.Append("M");
			if (10.0 - num5 > 0.0)
			{
				stringBuilder.Append(0);
			}
			stringBuilder.Append((int)num5);
			stringBuilder.Append("S");
			return stringBuilder.ToString();
		}
		return "PT00H00M00S";
	}

	internal static string smethod_22(TextAlignmentType textAlignmentType_0)
	{
		return textAlignmentType_0 switch
		{
			TextAlignmentType.Top => "top", 
			TextAlignmentType.Justify => "justify", 
			TextAlignmentType.Bottom => "bottom", 
			TextAlignmentType.Center => "middle", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid TextAlignmentType val"), 
		};
	}

	internal static TextAlignmentType smethod_23(string string_0)
	{
		return string_0 switch
		{
			"top" => TextAlignmentType.Top, 
			"justify" => TextAlignmentType.Justify, 
			"middle" => TextAlignmentType.Center, 
			"bottom" => TextAlignmentType.Bottom, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid ShapeTextAnchor string val"), 
		};
	}

	internal static string smethod_24(TextAlignmentType textAlignmentType_0)
	{
		return textAlignmentType_0 switch
		{
			TextAlignmentType.Justify => "justify", 
			TextAlignmentType.Left => "left", 
			TextAlignmentType.Right => "right", 
			TextAlignmentType.Center => "center", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid TextAlignmentType val"), 
		};
	}

	internal static TextAlignmentType smethod_25(string string_0)
	{
		return string_0 switch
		{
			"left" => TextAlignmentType.Left, 
			"justify" => TextAlignmentType.Justify, 
			"center" => TextAlignmentType.Center, 
			"right" => TextAlignmentType.Right, 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid ShapeTextAlignType string val"), 
		};
	}

	internal static double smethod_26(string string_0)
	{
		return (double)int.Parse(string_0.Substring(0, string_0.Length - 1)) / 100.0;
	}

	internal static string smethod_27(double double_0)
	{
		return double_0 * 100.0 + "%";
	}

	internal static bool smethod_28(string string_0)
	{
		if (string_0 == "no-wrap")
		{
			return false;
		}
		return true;
	}

	internal static string smethod_29(bool bool_0)
	{
		if (bool_0)
		{
			return "wrap";
		}
		return "no-wrap";
	}

	internal static string smethod_30(string string_0)
	{
		if (string_0.IndexOf("./") == 0)
		{
			return string_0.Substring(2);
		}
		return string_0;
	}

	public static object[] smethod_31(Workbook workbook_0)
	{
		workbook_0.Worksheets.method_27();
		object[] array = new object[3]
		{
			workbook_0.Worksheets.method_52(),
			null,
			null
		};
		Class1683 @class = workbook_0.Worksheets.method_58();
		array[1] = workbook_0.Worksheets.method_58();
		ArrayList arrayList = (ArrayList)(array[2] = new ArrayList());
		for (int i = 0; i < @class.Count; i++)
		{
			Style style = @class[i];
			style.method_41(out var number, out var custom);
			if (number <= 0)
			{
				continue;
			}
			bool flag = false;
			int j;
			for (j = 0; j < arrayList.Count; j++)
			{
				Struct79 @struct = (Struct79)arrayList[j];
				if (@struct.int_0 != number)
				{
					if (@struct.int_0 > number)
					{
						break;
					}
					continue;
				}
				flag = true;
				break;
			}
			if (!flag)
			{
				Struct79 struct2 = default(Struct79);
				struct2.int_0 = number;
				struct2.string_0 = custom;
				if (j >= arrayList.Count)
				{
					arrayList.Add(struct2);
				}
				else
				{
					arrayList.Insert(j, struct2);
				}
			}
		}
		return array;
	}

	public static string smethod_32(WorksheetCollection worksheetCollection_0, Name name_0)
	{
		if (name_0.method_2() != null && name_0.method_2().Length > 2)
		{
			Class1666 @class = new Class1666(worksheetCollection_0);
			byte[] byte_ = name_0.method_2();
			return @class.method_0(-1, byte_, 0, 0, bool_0: false);
		}
		return null;
	}

	public static string smethod_33(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return "chart:bar";
		case ChartType.Area:
		case ChartType.AreaStacked:
		case ChartType.Area100PercentStacked:
		case ChartType.Area3D:
		case ChartType.Area3DStacked:
		case ChartType.Area3D100PercentStacked:
			return "chart:area";
		case ChartType.Bubble:
		case ChartType.Bubble3D:
			return "chart:scatter";
		case ChartType.Doughnut:
		case ChartType.DoughnutExploded:
			return "chart:ring";
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.LineWithDataMarkers:
		case ChartType.LineStackedWithDataMarkers:
		case ChartType.Line100PercentStackedWithDataMarkers:
		case ChartType.Line3D:
			return "chart:line";
		case ChartType.Pie:
		case ChartType.Pie3D:
		case ChartType.PiePie:
		case ChartType.PieExploded:
		case ChartType.Pie3DExploded:
		case ChartType.PieBar:
			return "chart:circle";
		case ChartType.Bar:
		case ChartType.BarStacked:
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3DClustered:
		case ChartType.Bar3DStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.Column:
		case ChartType.ColumnStacked:
		case ChartType.Column100PercentStacked:
		case ChartType.Column3D:
		case ChartType.Column3DClustered:
		case ChartType.Column3DStacked:
		case ChartType.Column3D100PercentStacked:
		case ChartType.Cone:
		case ChartType.ConeStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBar:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.ConicalColumn3D:
		case ChartType.Cylinder:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.CylindricalColumn3D:
		case ChartType.Pyramid:
		case ChartType.PyramidStacked:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBar:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
		case ChartType.PyramidColumn3D:
			return "chart:bar";
		case ChartType.Radar:
		case ChartType.RadarWithDataMarkers:
		case ChartType.RadarFilled:
			return "chart:radar";
		case ChartType.Scatter:
		case ChartType.ScatterConnectedByCurvesWithDataMarker:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType.ScatterConnectedByLinesWithDataMarker:
		case ChartType.ScatterConnectedByLinesWithoutDataMarker:
			return "chart:scatter";
		case ChartType.StockHighLowClose:
		case ChartType.StockOpenHighLowClose:
		case ChartType.StockVolumeHighLowClose:
		case ChartType.StockVolumeOpenHighLowClose:
			return "chart:stock";
		case ChartType.Surface3D:
		case ChartType.SurfaceWireframe3D:
		case ChartType.SurfaceContour:
		case ChartType.SurfaceContourWireframe:
			return "chart:bar";
		}
	}

	public static bool smethod_34(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.AreaStacked:
		case ChartType.Area100PercentStacked:
		case ChartType.Area3DStacked:
		case ChartType.Area3D100PercentStacked:
		case ChartType.BarStacked:
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3DStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.ColumnStacked:
		case ChartType.Column100PercentStacked:
		case ChartType.Column3DStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.LineStackedWithDataMarkers:
		case ChartType.Line100PercentStackedWithDataMarkers:
		case ChartType.PyramidStacked:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
			return true;
		}
	}

	public static bool smethod_35(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Bar:
		case ChartType.BarStacked:
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3DClustered:
		case ChartType.Bar3DStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.ConicalBar:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.PyramidBar:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
			return true;
		}
	}

	public static bool smethod_36(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Area100PercentStacked:
		case ChartType.Area3D100PercentStacked:
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.Column100PercentStacked:
		case ChartType.Column3D100PercentStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.Line100PercentStackedWithDataMarkers:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBar100PercentStacked:
			return true;
		}
	}

	public static bool smethod_37(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Pie:
		case ChartType.Pie3D:
		case ChartType.PiePie:
		case ChartType.PieExploded:
		case ChartType.Pie3DExploded:
		case ChartType.PieBar:
			return true;
		}
	}

	public static bool smethod_38(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Cylinder:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.CylindricalColumn3D:
			return true;
		}
	}

	public static bool smethod_39(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.ScatterConnectedByCurvesWithDataMarker:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
			return true;
		}
	}

	public static string smethod_40(ChartMarkerType chartMarkerType_0, int int_0)
	{
		return chartMarkerType_0 switch
		{
			ChartMarkerType.Automatic => "automatic", 
			ChartMarkerType.Circle => "arrow-right", 
			ChartMarkerType.Dash => "arrow-right", 
			ChartMarkerType.Diamond => "diamond", 
			ChartMarkerType.Dot => "arrow-down", 
			ChartMarkerType.None => "none", 
			ChartMarkerType.SquarePlus => "arrow-left", 
			ChartMarkerType.Square => "square", 
			ChartMarkerType.SquareStar => "hourglass", 
			ChartMarkerType.Triangle => "arrow-up", 
			ChartMarkerType.SquareX => "bow-tie", 
			_ => "automatic", 
		};
	}

	public static double smethod_41(double double_0)
	{
		return double_0 / 96.0 * 2.54;
	}

	internal static string smethod_42(double double_0, int int_0)
	{
		return smethod_12(Math.Round((double)int_0 / double_0, 4)) + "in";
	}

	public static double smethod_43(WorksheetCollection worksheetCollection_0, int int_0)
	{
		return (float)int_0 * 72f / (float)worksheetCollection_0.method_75();
	}

	public static double smethod_44(WorksheetCollection worksheetCollection_0, double double_0)
	{
		double num = double_0 * (double)worksheetCollection_0.method_75() / 72.0 + 0.5;
		return num / 96.0 * 2.54;
	}

	public static double smethod_45(WorksheetCollection worksheetCollection_0, double double_0)
	{
		int int_ = (int)(double_0 * 96.0 / 2.54);
		return smethod_43(worksheetCollection_0, int_);
	}

	public static double smethod_46(WorksheetCollection worksheetCollection_0, double double_0)
	{
		int num = (int)(double_0 * 96.0 / 2.54);
		return num;
	}

	public static double smethod_47(double double_0)
	{
		return double_0 / 2.54;
	}

	public static double smethod_48(double double_0)
	{
		return double_0 * 2.54;
	}

	public static string smethod_49(double double_0)
	{
		return ((double)(int)((double_0 + 0.005) * 100.0) / 100.0).ToString();
	}

	public static string smethod_50(ChartShape chartShape_0)
	{
		return chartShape_0.method_26().Index + "-" + chartShape_0.Index;
	}

	public static string smethod_51(Enum214 enum214_0)
	{
		return enum214_0 switch
		{
			Enum214.const_0 => "currency", 
			Enum214.const_1 => "number", 
			Enum214.const_2 => "date", 
			Enum214.const_3 => "time", 
			Enum214.const_4 => "bool", 
			Enum214.const_5 => "text", 
			Enum214.const_6 => "percentage", 
			_ => "unknown", 
		};
	}

	public static string smethod_52(Enum213 enum213_0)
	{
		return enum213_0 switch
		{
			Enum213.const_0 => "text", 
			Enum213.const_1 => "textcontent", 
			Enum213.const_2 => "textproperties", 
			Enum213.const_3 => "currencysymbo", 
			Enum213.const_4 => "number", 
			Enum213.const_5 => "map", 
			Enum213.const_6 => "year", 
			Enum213.const_7 => "month", 
			Enum213.const_8 => "day", 
			Enum213.const_9 => "hours", 
			Enum213.const_10 => "minutes", 
			Enum213.const_11 => "seconds", 
			Enum213.const_12 => "ampm", 
			Enum213.const_13 => "fraction", 
			Enum213.const_14 => "scientificnumber", 
			Enum213.const_15 => "dayofweek", 
			_ => "unknown", 
		};
	}

	public static LabelPositionType smethod_53(string string_0)
	{
		return string_0 switch
		{
			"center" => LabelPositionType.Center, 
			"outside" => LabelPositionType.OutsideEnd, 
			"inside" => LabelPositionType.InsideEnd, 
			_ => LabelPositionType.OutsideEnd, 
		};
	}

	internal static TickLabelPositionType smethod_54(string string_0)
	{
		return string_0 switch
		{
			"near-axis-other-side" => TickLabelPositionType.NextToAxis, 
			"outside-end" => TickLabelPositionType.Low, 
			"outside-start" => TickLabelPositionType.High, 
			_ => TickLabelPositionType.None, 
		};
	}

	public static string smethod_55(string string_0)
	{
		string_0 = string_0.Replace('.', '!');
		string[] array = string_0.Split(':');
		if (array.Length == 2 && array[0] == array[1])
		{
			return array[0];
		}
		return string_0;
	}
}
