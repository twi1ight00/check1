using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace ns2;

internal class Class1130
{
	internal static string smethod_0(CellBorderType cellBorderType_0)
	{
		return cellBorderType_0 switch
		{
			CellBorderType.None => "none", 
			CellBorderType.Thin => ".5pt solid", 
			CellBorderType.Medium => "1.0pt solid", 
			CellBorderType.Dashed => ".5pt dashed", 
			CellBorderType.Dotted => ".5pt dotted", 
			CellBorderType.Thick => "1.5pt solid", 
			CellBorderType.Double => "2.0pt double", 
			CellBorderType.Hair => ".5pt hairline", 
			CellBorderType.MediumDashed => "1.0pt dashed", 
			CellBorderType.DashDot => ".5pt dot-dash", 
			CellBorderType.MediumDashDot => "1.0pt dot-dash", 
			CellBorderType.DashDotDot => ".5pt dot-dot-dash", 
			CellBorderType.MediumDashDotDot => "1.0pt dot-dot-dash", 
			CellBorderType.SlantedDashDot => "1.0pt dot-dash-slanted", 
			_ => throw new CellsException(ExceptionType.InvalidData, "Invalid BorderLineStyle int val: " + cellBorderType_0), 
		};
	}

	internal static string smethod_1(BackgroundType backgroundType_0)
	{
		return backgroundType_0 switch
		{
			BackgroundType.None => "", 
			BackgroundType.Solid => "none", 
			BackgroundType.Gray50 => "gray-50", 
			BackgroundType.Gray75 => "gray-75", 
			BackgroundType.Gray25 => "gray-25", 
			BackgroundType.HorizontalStripe => "horz-stripe", 
			BackgroundType.VerticalStripe => "vert-stripe", 
			BackgroundType.ReverseDiagonalStripe => "reverse-diag-stripe", 
			BackgroundType.DiagonalStripe => "diag-stripe", 
			BackgroundType.DiagonalCrosshatch => "diag-cross", 
			BackgroundType.ThickDiagonalCrosshatch => "thick-diag-cross", 
			BackgroundType.ThinHorizontalStripe => "thin-horz-stripe", 
			BackgroundType.ThinVerticalStripe => "thin-vert-stripe", 
			BackgroundType.ThinReverseDiagonalStripe => "thin-reverse-diag-stripe", 
			BackgroundType.ThinDiagonalStripe => "thin-diag-stripe", 
			BackgroundType.ThinHorizontalCrosshatch => "thin-horz-cross", 
			BackgroundType.ThinDiagonalCrosshatch => "thin-diag-cross", 
			BackgroundType.Gray12 => "gray-125", 
			BackgroundType.Gray6 => "gray-0625", 
			_ => "", 
		};
	}

	internal static string ToString(IconSetType iconSetType_0)
	{
		return iconSetType_0 switch
		{
			IconSetType.Arrows3 => "Arrows3", 
			IconSetType.ArrowsGray3 => "ArrowsGray3", 
			IconSetType.Flags3 => "Flags3", 
			IconSetType.Signs3 => "Signs3", 
			IconSetType.Symbols3 => "Symbols3", 
			IconSetType.Symbols32 => "Symbols32", 
			IconSetType.TrafficLights31 => "TrafficLights31", 
			IconSetType.TrafficLights32 => "TrafficLights32", 
			IconSetType.Arrows4 => "Arrows4", 
			IconSetType.ArrowsGray4 => "ArrowsGray4", 
			IconSetType.Rating4 => "Rating4", 
			IconSetType.RedToBlack4 => "RedToBlack4", 
			IconSetType.TrafficLights4 => "TrafficLights4", 
			IconSetType.Arrows5 => "Arrows5", 
			IconSetType.ArrowsGray5 => "ArrowsGray5", 
			IconSetType.Quarters5 => "Quarters5", 
			IconSetType.Rating5 => "Rating5", 
			IconSetType.Stars3 => "Stars3", 
			IconSetType.Boxes5 => "Boxes5", 
			IconSetType.Triangles3 => "Triangles3", 
			_ => "", 
		};
	}

	internal static string smethod_2(MsoDrawingType msoDrawingType_0)
	{
		string result = "";
		switch (msoDrawingType_0)
		{
		case MsoDrawingType.Group:
			result = "Group";
			break;
		case MsoDrawingType.Line:
			result = "Line";
			break;
		case MsoDrawingType.Rectangle:
			result = "Rectangle";
			break;
		case MsoDrawingType.Oval:
			result = "Oval";
			break;
		case MsoDrawingType.Arc:
			result = "Arc";
			break;
		case MsoDrawingType.Chart:
			result = "Chart";
			break;
		case MsoDrawingType.TextBox:
			result = "TextBox";
			break;
		case MsoDrawingType.Button:
			result = "Button";
			break;
		case MsoDrawingType.Picture:
			result = "Picture";
			break;
		case MsoDrawingType.Polygon:
			result = "Polygon";
			break;
		case MsoDrawingType.CheckBox:
			result = "CheckBox";
			break;
		case MsoDrawingType.RadioButton:
			result = "RadioButton";
			break;
		case MsoDrawingType.Label:
			result = "Label";
			break;
		case MsoDrawingType.DialogBox:
			result = "DialogBox";
			break;
		case MsoDrawingType.Spinner:
			result = "Spinner";
			break;
		case MsoDrawingType.ScrollBar:
			result = "ScrollBar";
			break;
		case MsoDrawingType.ListBox:
			result = "ListBox";
			break;
		case MsoDrawingType.GroupBox:
			result = "GroupBox";
			break;
		case MsoDrawingType.ComboBox:
			result = "ComboBox";
			break;
		case MsoDrawingType.OleObject:
			result = "OleObject";
			break;
		case MsoDrawingType.Comment:
			result = "Comment";
			break;
		case MsoDrawingType.Unknown:
			result = "Unknown";
			break;
		case MsoDrawingType.CellsDrawing:
			result = "CellsDrawing";
			break;
		}
		return result;
	}

	internal static string smethod_3(BorderType borderType_0)
	{
		return borderType_0 switch
		{
			BorderType.BottomBorder => "BottomBorder", 
			BorderType.LeftBorder => "LeftBorder", 
			BorderType.RightBorder => "RightBorder", 
			BorderType.TopBorder => "TopBorder", 
			BorderType.Horizontal => "Horizontal", 
			BorderType.Vertical => "Vertical", 
			BorderType.DiagonalUp => "DiagonalUp", 
			BorderType.DiagonalDown => "DiagonalDown", 
			_ => "", 
		};
	}

	internal static string smethod_4(CellBorderType cellBorderType_0)
	{
		return cellBorderType_0 switch
		{
			CellBorderType.None => "None", 
			CellBorderType.Thin => "Thin", 
			CellBorderType.Medium => "Medium", 
			CellBorderType.Dashed => "Dashed", 
			CellBorderType.Dotted => "Dotted", 
			CellBorderType.Thick => "Thick", 
			CellBorderType.Double => "Double", 
			CellBorderType.Hair => "Hair", 
			CellBorderType.MediumDashed => "MediumDashed", 
			CellBorderType.DashDot => "DashDot", 
			CellBorderType.MediumDashDot => "MediumDashDot", 
			CellBorderType.DashDotDot => "DashDotDot", 
			CellBorderType.MediumDashDotDot => "MediumDashDotDot", 
			CellBorderType.SlantedDashDot => "SlantedDashDot", 
			_ => "", 
		};
	}

	internal static string smethod_5(BackgroundType backgroundType_0)
	{
		return backgroundType_0 switch
		{
			BackgroundType.None => "None", 
			BackgroundType.Solid => "Solid", 
			BackgroundType.Gray50 => "Gray50", 
			BackgroundType.Gray75 => "Gray75", 
			BackgroundType.Gray25 => "Gray25", 
			BackgroundType.HorizontalStripe => "HorizontalStripe", 
			BackgroundType.VerticalStripe => "VerticalStripe", 
			BackgroundType.ReverseDiagonalStripe => "ReverseDiagonalStripe", 
			BackgroundType.DiagonalStripe => "DiagonalStripe", 
			BackgroundType.DiagonalCrosshatch => "DiagonalCrosshatch", 
			BackgroundType.ThickDiagonalCrosshatch => "ThickDiagonalCrosshatch", 
			BackgroundType.ThinHorizontalStripe => "ThinHorizontalStripe", 
			BackgroundType.ThinVerticalStripe => "ThinVerticalStripe", 
			BackgroundType.ThinReverseDiagonalStripe => "ThinReverseDiagonalStripe", 
			BackgroundType.ThinDiagonalStripe => "ThinDiagonalStripe", 
			BackgroundType.ThinHorizontalCrosshatch => "ThinHorizontalCrosshatch", 
			BackgroundType.ThinDiagonalCrosshatch => "ThinDiagonalCrosshatch", 
			BackgroundType.Gray12 => "Gray12", 
			BackgroundType.Gray6 => "Gray6", 
			_ => "", 
		};
	}

	internal static string smethod_6(CellValueType cellValueType_0)
	{
		return cellValueType_0 switch
		{
			CellValueType.IsBool => "IsBool", 
			CellValueType.IsDateTime => "IsDateTime", 
			CellValueType.IsError => "IsError", 
			CellValueType.IsNull => "IsNull", 
			CellValueType.IsNumeric => "IsNumeric", 
			CellValueType.IsString => "IsString", 
			_ => "IsString", 
		};
	}

	internal static int smethod_7(ConsolidationFunction consolidationFunction_0)
	{
		return consolidationFunction_0 switch
		{
			ConsolidationFunction.Sum => 9, 
			ConsolidationFunction.Count => 2, 
			ConsolidationFunction.Average => 1, 
			ConsolidationFunction.Max => 4, 
			ConsolidationFunction.Min => 5, 
			ConsolidationFunction.Product => 6, 
			ConsolidationFunction.CountNums => 3, 
			ConsolidationFunction.StdDev => 7, 
			ConsolidationFunction.StdDevp => 8, 
			ConsolidationFunction.Var => 10, 
			ConsolidationFunction.Varp => 11, 
			_ => 9, 
		};
	}

	internal static string smethod_8(ConsolidationFunction consolidationFunction_0)
	{
		return consolidationFunction_0 switch
		{
			ConsolidationFunction.Sum => "Sum", 
			ConsolidationFunction.Count => "Count", 
			ConsolidationFunction.Average => "Average", 
			ConsolidationFunction.Max => "Max", 
			ConsolidationFunction.Min => "Min", 
			ConsolidationFunction.Product => "PRODUCT", 
			ConsolidationFunction.CountNums => "Count Nums", 
			ConsolidationFunction.StdDev => "Sed Dev", 
			ConsolidationFunction.StdDevp => "STD Devp", 
			ConsolidationFunction.Var => "Var", 
			ConsolidationFunction.Varp => "Varp", 
			_ => null, 
		};
	}

	internal static string smethod_9(ConsolidationFunction consolidationFunction_0, WorkbookSettings workbookSettings_0)
	{
		return consolidationFunction_0 switch
		{
			ConsolidationFunction.Count => "Count", 
			ConsolidationFunction.Average => "Average", 
			ConsolidationFunction.Max => "Max", 
			ConsolidationFunction.Min => "Min", 
			ConsolidationFunction.Product => "Product", 
			ConsolidationFunction.CountNums => "Count", 
			ConsolidationFunction.StdDev => "SedDev", 
			ConsolidationFunction.StdDevp => "STDDevp", 
			ConsolidationFunction.Var => "Var", 
			ConsolidationFunction.Varp => "Varp", 
			_ => "Total", 
		};
	}
}
