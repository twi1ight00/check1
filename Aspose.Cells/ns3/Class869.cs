using System.Drawing.Drawing2D;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using Aspose.Cells.Render;
using ns21;
using ns7;

namespace ns3;

internal class Class869
{
	internal static Enum67 smethod_0(DisplayUnitType displayUnitType_0)
	{
		return displayUnitType_0 switch
		{
			DisplayUnitType.Hundreds => Enum67.const_1, 
			DisplayUnitType.Thousands => Enum67.const_2, 
			DisplayUnitType.Millions => Enum67.const_3, 
			DisplayUnitType.Billions => Enum67.const_4, 
			DisplayUnitType.Trillions => Enum67.const_5, 
			_ => Enum67.const_0, 
		};
	}

	internal static HatchStyle smethod_1(FillPattern fillPattern_0)
	{
		return fillPattern_0 switch
		{
			FillPattern.Gray5 => HatchStyle.Percent05, 
			FillPattern.Gray10 => HatchStyle.Percent10, 
			FillPattern.Gray20 => HatchStyle.Percent20, 
			FillPattern.Gray30 => HatchStyle.Percent30, 
			FillPattern.Gray40 => HatchStyle.Percent40, 
			FillPattern.Gray50 => HatchStyle.Percent50, 
			FillPattern.Gray60 => HatchStyle.Percent60, 
			FillPattern.Gray70 => HatchStyle.Percent70, 
			FillPattern.Gray75 => HatchStyle.Percent75, 
			FillPattern.Gray80 => HatchStyle.Percent80, 
			FillPattern.Gray90 => HatchStyle.Percent90, 
			FillPattern.Gray25 => HatchStyle.Percent25, 
			FillPattern.LightDownwardDiagonal => HatchStyle.LightDownwardDiagonal, 
			FillPattern.LightUpwardDiagonal => HatchStyle.LightUpwardDiagonal, 
			FillPattern.DarkDownwardDiagonal => HatchStyle.DarkDownwardDiagonal, 
			FillPattern.DarkUpwardDiagonal => HatchStyle.DarkUpwardDiagonal, 
			FillPattern.WideDownwardDiagonal => HatchStyle.WideDownwardDiagonal, 
			FillPattern.WideUpwardDiagonal => HatchStyle.WideUpwardDiagonal, 
			FillPattern.LightVertical => HatchStyle.LightVertical, 
			FillPattern.LightHorizontal => HatchStyle.LightHorizontal, 
			FillPattern.NarrowVertical => HatchStyle.NarrowVertical, 
			FillPattern.NarrowHorizontal => HatchStyle.NarrowHorizontal, 
			FillPattern.DarkVertical => HatchStyle.DarkVertical, 
			FillPattern.DarkHorizontal => HatchStyle.DarkHorizontal, 
			FillPattern.DashedDownwardDiagonal => HatchStyle.DashedDownwardDiagonal, 
			FillPattern.DashedUpwardDiagonal => HatchStyle.DashedUpwardDiagonal, 
			FillPattern.DashedVertical => HatchStyle.DashedVertical, 
			FillPattern.DashedHorizontal => HatchStyle.DashedHorizontal, 
			FillPattern.SmallConfetti => HatchStyle.SmallConfetti, 
			FillPattern.LargeConfetti => HatchStyle.LargeConfetti, 
			FillPattern.ZigZag => HatchStyle.ZigZag, 
			FillPattern.Wave => HatchStyle.Wave, 
			FillPattern.DiagonalBrick => HatchStyle.DiagonalBrick, 
			FillPattern.HorizontalBrick => HatchStyle.HorizontalBrick, 
			FillPattern.Weave => HatchStyle.Weave, 
			FillPattern.Plaid => HatchStyle.Plaid, 
			FillPattern.Divot => HatchStyle.Divot, 
			FillPattern.DottedGrid => HatchStyle.DottedGrid, 
			FillPattern.DottedDiamond => HatchStyle.DottedDiamond, 
			FillPattern.Shingle => HatchStyle.Shingle, 
			FillPattern.Trellis => HatchStyle.Trellis, 
			FillPattern.Sphere => HatchStyle.Sphere, 
			FillPattern.SmallGrid => HatchStyle.SmallGrid, 
			FillPattern.LargeGrid => HatchStyle.Cross, 
			FillPattern.SmallCheckerBoard => HatchStyle.SmallCheckerBoard, 
			FillPattern.LargeCheckerBoard => HatchStyle.LargeCheckerBoard, 
			FillPattern.OutlinedDiamond => HatchStyle.OutlinedDiamond, 
			FillPattern.SolidDiamond => HatchStyle.SolidDiamond, 
			_ => HatchStyle.Cross, 
		};
	}

	internal static Enum65 smethod_2(ChartMarkerType chartMarkerType_0)
	{
		return chartMarkerType_0 switch
		{
			ChartMarkerType.Circle => Enum65.const_1, 
			ChartMarkerType.Dash => Enum65.const_2, 
			ChartMarkerType.Diamond => Enum65.const_3, 
			ChartMarkerType.Dot => Enum65.const_4, 
			ChartMarkerType.None => Enum65.const_5, 
			ChartMarkerType.SquarePlus => Enum65.const_6, 
			ChartMarkerType.Square => Enum65.const_7, 
			ChartMarkerType.SquareStar => Enum65.const_8, 
			ChartMarkerType.Triangle => Enum65.const_9, 
			ChartMarkerType.SquareX => Enum65.const_10, 
			_ => Enum65.const_0, 
		};
	}

	internal static ChartMarkerType smethod_3(Enum65 enum65_0)
	{
		return enum65_0 switch
		{
			Enum65.const_5 => ChartMarkerType.None, 
			Enum65.const_3 => ChartMarkerType.Diamond, 
			Enum65.const_7 => ChartMarkerType.Square, 
			Enum65.const_9 => ChartMarkerType.Triangle, 
			Enum65.const_10 => ChartMarkerType.SquareX, 
			Enum65.const_8 => ChartMarkerType.SquareStar, 
			Enum65.const_1 => ChartMarkerType.Circle, 
			Enum65.const_6 => ChartMarkerType.SquarePlus, 
			Enum65.const_4 => ChartMarkerType.Dot, 
			Enum65.const_2 => ChartMarkerType.Dash, 
			_ => ChartMarkerType.Automatic, 
		};
	}

	internal static Enum75 smethod_4(DataLablesSeparatorType dataLablesSeparatorType_0)
	{
		return dataLablesSeparatorType_0 switch
		{
			DataLablesSeparatorType.Auto => Enum75.const_0, 
			DataLablesSeparatorType.Space => Enum75.const_1, 
			DataLablesSeparatorType.Comma => Enum75.const_2, 
			DataLablesSeparatorType.Semicolon => Enum75.const_3, 
			DataLablesSeparatorType.Period => Enum75.const_4, 
			DataLablesSeparatorType.NewLine => Enum75.const_5, 
			_ => Enum75.const_0, 
		};
	}

	internal static Enum63 smethod_5(BubbleSizeRepresents bubbleSizeRepresents_0)
	{
		if (bubbleSizeRepresents_0 == BubbleSizeRepresents.SizeIsArea)
		{
			return Enum63.const_0;
		}
		return Enum63.const_1;
	}

	internal static Enum87 smethod_6(TimeUnit timeUnit_0)
	{
		return timeUnit_0 switch
		{
			TimeUnit.Days => Enum87.const_0, 
			TimeUnit.Months => Enum87.const_1, 
			TimeUnit.Years => Enum87.const_2, 
			_ => Enum87.const_0, 
		};
	}

	internal static Enum66 smethod_7(CrossType crossType_0)
	{
		return crossType_0 switch
		{
			CrossType.Automatic => Enum66.const_0, 
			CrossType.Maximum => Enum66.const_1, 
			CrossType.Custom => Enum66.const_2, 
			_ => Enum66.const_0, 
		};
	}

	internal static Enum64 smethod_8(CategoryType categoryType_0)
	{
		return categoryType_0 switch
		{
			CategoryType.CategoryScale => Enum64.const_1, 
			CategoryType.TimeScale => Enum64.const_2, 
			_ => Enum64.const_0, 
		};
	}

	internal static ChartType_Chart smethod_9(ChartType chartType_0)
	{
		return chartType_0 switch
		{
			ChartType.Area => ChartType_Chart.Area, 
			ChartType.AreaStacked => ChartType_Chart.AreaStacked, 
			ChartType.Area100PercentStacked => ChartType_Chart.Area100PercentStacked, 
			ChartType.Area3D => ChartType_Chart.Area3D, 
			ChartType.Area3DStacked => ChartType_Chart.Area3DStacked, 
			ChartType.Area3D100PercentStacked => ChartType_Chart.Area3D100PercentStacked, 
			ChartType.Bar => ChartType_Chart.Bar, 
			ChartType.BarStacked => ChartType_Chart.BarStacked, 
			ChartType.Bar100PercentStacked => ChartType_Chart.Bar100PercentStacked, 
			ChartType.Bar3DClustered => ChartType_Chart.Bar3DClustered, 
			ChartType.Bar3DStacked => ChartType_Chart.Bar3DStacked, 
			ChartType.Bar3D100PercentStacked => ChartType_Chart.Bar3D100PercentStacked, 
			ChartType.Bubble => ChartType_Chart.Bubble, 
			ChartType.Bubble3D => ChartType_Chart.Bubble3D, 
			ChartType.Column => ChartType_Chart.Column, 
			ChartType.ColumnStacked => ChartType_Chart.ColumnStacked, 
			ChartType.Column100PercentStacked => ChartType_Chart.Column100PercentStacked, 
			ChartType.Column3D => ChartType_Chart.Column3D, 
			ChartType.Column3DClustered => ChartType_Chart.Column3DClustered, 
			ChartType.Column3DStacked => ChartType_Chart.Column3DStacked, 
			ChartType.Column3D100PercentStacked => ChartType_Chart.Column3D100PercentStacked, 
			ChartType.Cone => ChartType_Chart.Cone, 
			ChartType.ConeStacked => ChartType_Chart.ConeStacked, 
			ChartType.Cone100PercentStacked => ChartType_Chart.Cone100PercentStacked, 
			ChartType.ConicalBar => ChartType_Chart.ConicalBar, 
			ChartType.ConicalBarStacked => ChartType_Chart.ConicalBarStacked, 
			ChartType.ConicalBar100PercentStacked => ChartType_Chart.ConicalBar100PercentStacked, 
			ChartType.ConicalColumn3D => ChartType_Chart.ConicalColumn3D, 
			ChartType.Cylinder => ChartType_Chart.Cylinder, 
			ChartType.CylinderStacked => ChartType_Chart.CylinderStacked, 
			ChartType.Cylinder100PercentStacked => ChartType_Chart.Cylinder100PercentStacked, 
			ChartType.CylindricalBar => ChartType_Chart.CylindricalBar, 
			ChartType.CylindricalBarStacked => ChartType_Chart.CylindricalBarStacked, 
			ChartType.CylindricalBar100PercentStacked => ChartType_Chart.CylindricalBar100PercentStacked, 
			ChartType.CylindricalColumn3D => ChartType_Chart.CylindricalColumn3D, 
			ChartType.Doughnut => ChartType_Chart.Doughnut, 
			ChartType.DoughnutExploded => ChartType_Chart.DoughnutExploded, 
			ChartType.Line => ChartType_Chart.Line, 
			ChartType.LineStacked => ChartType_Chart.LineStacked, 
			ChartType.Line100PercentStacked => ChartType_Chart.Line100PercentStacked, 
			ChartType.LineWithDataMarkers => ChartType_Chart.LineWithDataMarkers, 
			ChartType.LineStackedWithDataMarkers => ChartType_Chart.LineStackedWithDataMarkers, 
			ChartType.Line100PercentStackedWithDataMarkers => ChartType_Chart.Line100PercentStackedWithDataMarkers, 
			ChartType.Line3D => ChartType_Chart.Line3D, 
			ChartType.Pie => ChartType_Chart.Pie, 
			ChartType.Pie3D => ChartType_Chart.Pie3D, 
			ChartType.PiePie => ChartType_Chart.PiePie, 
			ChartType.PieExploded => ChartType_Chart.PieExploded, 
			ChartType.Pie3DExploded => ChartType_Chart.Pie3DExploded, 
			ChartType.PieBar => ChartType_Chart.PieBar, 
			ChartType.Pyramid => ChartType_Chart.Pyramid, 
			ChartType.PyramidStacked => ChartType_Chart.PyramidStacked, 
			ChartType.Pyramid100PercentStacked => ChartType_Chart.Pyramid100PercentStacked, 
			ChartType.PyramidBar => ChartType_Chart.PyramidBar, 
			ChartType.PyramidBarStacked => ChartType_Chart.PyramidBarStacked, 
			ChartType.PyramidBar100PercentStacked => ChartType_Chart.PyramidBar100PercentStacked, 
			ChartType.PyramidColumn3D => ChartType_Chart.PyramidColumn3D, 
			ChartType.Radar => ChartType_Chart.Radar, 
			ChartType.RadarWithDataMarkers => ChartType_Chart.RadarWithDataMarkers, 
			ChartType.RadarFilled => ChartType_Chart.RadarFilled, 
			ChartType.Scatter => ChartType_Chart.Scatter, 
			ChartType.ScatterConnectedByCurvesWithDataMarker => ChartType_Chart.ScatterConnectedByCurvesWithDataMarker, 
			ChartType.ScatterConnectedByCurvesWithoutDataMarker => ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker, 
			ChartType.ScatterConnectedByLinesWithDataMarker => ChartType_Chart.ScatterConnectedByLinesWithDataMarker, 
			ChartType.ScatterConnectedByLinesWithoutDataMarker => ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker, 
			ChartType.StockHighLowClose => ChartType_Chart.StockHighLowClose, 
			ChartType.StockOpenHighLowClose => ChartType_Chart.StockOpenHighLowClose, 
			ChartType.StockVolumeHighLowClose => ChartType_Chart.StockVolumeHighLowClose, 
			ChartType.StockVolumeOpenHighLowClose => ChartType_Chart.StockVolumeOpenHighLowClose, 
			ChartType.Surface3D => ChartType_Chart.Surface3D, 
			ChartType.SurfaceWireframe3D => ChartType_Chart.SurfaceWireframe3D, 
			ChartType.SurfaceContour => ChartType_Chart.SurfaceContour, 
			ChartType.SurfaceContourWireframe => ChartType_Chart.SurfaceContourWireframe, 
			_ => ChartType_Chart.Column, 
		};
	}

	internal static Enum68 smethod_10(ErrorBarDisplayType errorBarDisplayType_0)
	{
		return errorBarDisplayType_0 switch
		{
			ErrorBarDisplayType.Both => Enum68.const_0, 
			ErrorBarDisplayType.Minus => Enum68.const_1, 
			ErrorBarDisplayType.Plus => Enum68.const_3, 
			_ => Enum68.const_2, 
		};
	}

	internal static Enum69 smethod_11(ErrorBarType errorBarType_0)
	{
		return errorBarType_0 switch
		{
			ErrorBarType.Custom => Enum69.const_0, 
			ErrorBarType.Percent => Enum69.const_2, 
			ErrorBarType.StDev => Enum69.const_3, 
			ErrorBarType.StError => Enum69.const_4, 
			_ => Enum69.const_1, 
		};
	}

	internal static Enum71 smethod_12(FormattingType formattingType_0)
	{
		return formattingType_0 switch
		{
			FormattingType.None => Enum71.const_0, 
			FormattingType.Custom => Enum71.const_2, 
			_ => Enum71.const_1, 
		};
	}

	internal static Enum74 smethod_13(LabelPositionType labelPositionType_0)
	{
		return labelPositionType_0 switch
		{
			LabelPositionType.Center => Enum74.const_1, 
			LabelPositionType.InsideBase => Enum74.const_2, 
			LabelPositionType.InsideEnd => Enum74.const_3, 
			LabelPositionType.OutsideEnd => Enum74.const_4, 
			LabelPositionType.Above => Enum74.const_5, 
			LabelPositionType.Below => Enum74.const_6, 
			LabelPositionType.Left => Enum74.const_7, 
			LabelPositionType.Right => Enum74.const_8, 
			_ => Enum74.const_0, 
		};
	}

	internal static Enum76 smethod_14(LegendPositionType legendPositionType_0)
	{
		return legendPositionType_0 switch
		{
			LegendPositionType.Bottom => Enum76.const_0, 
			LegendPositionType.Corner => Enum76.const_1, 
			LegendPositionType.Top => Enum76.const_5, 
			LegendPositionType.Right => Enum76.const_4, 
			LegendPositionType.Left => Enum76.const_2, 
			LegendPositionType.NotDocked => Enum76.const_3, 
			_ => Enum76.const_2, 
		};
	}

	internal static Enum82 smethod_15(TextAlignmentType textAlignmentType_0)
	{
		return textAlignmentType_0 switch
		{
			TextAlignmentType.Bottom => Enum82.const_0, 
			TextAlignmentType.Center => Enum82.const_1, 
			TextAlignmentType.CenterAcross => Enum82.const_2, 
			TextAlignmentType.Distributed => Enum82.const_3, 
			TextAlignmentType.Fill => Enum82.const_4, 
			TextAlignmentType.General => Enum82.const_5, 
			TextAlignmentType.Justify => Enum82.const_6, 
			TextAlignmentType.Left => Enum82.const_7, 
			TextAlignmentType.Right => Enum82.const_8, 
			TextAlignmentType.Top => Enum82.const_9, 
			_ => Enum82.const_1, 
		};
	}

	internal static Enum83 smethod_16(TickLabelPositionType tickLabelPositionType_0)
	{
		return tickLabelPositionType_0 switch
		{
			TickLabelPositionType.High => Enum83.const_0, 
			TickLabelPositionType.Low => Enum83.const_1, 
			TickLabelPositionType.None => Enum83.const_3, 
			_ => Enum83.const_2, 
		};
	}

	internal static Enum84 smethod_17(TickMarkType tickMarkType_0)
	{
		return tickMarkType_0 switch
		{
			TickMarkType.Cross => Enum84.const_0, 
			TickMarkType.Inside => Enum84.const_1, 
			TickMarkType.None => Enum84.const_2, 
			TickMarkType.Outside => Enum84.const_3, 
			_ => Enum84.const_0, 
		};
	}

	internal static Enum88 smethod_18(TrendlineType trendlineType_0)
	{
		return trendlineType_0 switch
		{
			TrendlineType.Exponential => Enum88.const_0, 
			TrendlineType.Linear => Enum88.const_1, 
			TrendlineType.Logarithmic => Enum88.const_2, 
			TrendlineType.MovingAverage => Enum88.const_3, 
			TrendlineType.Polynomial => Enum88.const_4, 
			TrendlineType.Power => Enum88.const_5, 
			_ => Enum88.const_0, 
		};
	}

	internal static Enum71 smethod_19(Enum229 enum229_0)
	{
		return enum229_0 switch
		{
			Enum229.const_0 => Enum71.const_1, 
			Enum229.const_1 => Enum71.const_2, 
			Enum229.const_2 => Enum71.const_0, 
			Enum229.const_3 => Enum71.const_3, 
			_ => Enum71.const_1, 
		};
	}

	internal static Enum79 smethod_20(MsoLineDashStyle msoLineDashStyle_0)
	{
		return msoLineDashStyle_0 switch
		{
			MsoLineDashStyle.Dash => Enum79.const_0, 
			MsoLineDashStyle.DashDot => Enum79.const_1, 
			MsoLineDashStyle.DashDotDot => Enum79.const_4, 
			MsoLineDashStyle.DashLongDash => Enum79.const_2, 
			MsoLineDashStyle.DashLongDashDot => Enum79.const_3, 
			MsoLineDashStyle.RoundDot => Enum79.const_5, 
			MsoLineDashStyle.Solid => Enum79.const_6, 
			MsoLineDashStyle.SquareDot => Enum79.const_7, 
			_ => Enum79.const_6, 
		};
	}

	internal static Enum79 smethod_21(LineType lineType_0)
	{
		return lineType_0 switch
		{
			LineType.Dash => Enum79.const_0, 
			LineType.Dot => Enum79.const_10, 
			LineType.DashDot => Enum79.const_1, 
			LineType.DashDotDot => Enum79.const_9, 
			LineType.DarkGray => Enum79.const_8, 
			LineType.MediumGray => Enum79.const_12, 
			LineType.LightGray => Enum79.const_11, 
			_ => Enum79.const_6, 
		};
	}

	internal static int smethod_22(WeightType weightType_0)
	{
		switch (weightType_0)
		{
		default:
			return 1;
		case WeightType.HairLine:
		case WeightType.SingleLine:
			return 1;
		case WeightType.MediumLine:
			return 2;
		case WeightType.WideLine:
			return 3;
		}
	}

	internal static Enum78 smethod_23(MsoLineStyle msoLineStyle_0)
	{
		return msoLineStyle_0 switch
		{
			MsoLineStyle.Single => Enum78.const_0, 
			MsoLineStyle.ThickBetweenThin => Enum78.const_1, 
			MsoLineStyle.ThinThick => Enum78.const_2, 
			MsoLineStyle.ThickThin => Enum78.const_3, 
			MsoLineStyle.ThinThin => Enum78.const_4, 
			_ => Enum78.const_0, 
		};
	}

	internal static Enum77 smethod_24(Enum231 enum231_0)
	{
		return enum231_0 switch
		{
			Enum231.const_0 => Enum77.const_1, 
			Enum231.const_1 => Enum77.const_2, 
			Enum231.const_2 => Enum77.const_3, 
			Enum231.const_3 => Enum77.const_0, 
			_ => Enum77.const_2, 
		};
	}

	internal static Enum80 smethod_25(Enum232 enum232_0)
	{
		return enum232_0 switch
		{
			Enum232.const_0 => Enum80.const_1, 
			Enum232.const_1 => Enum80.const_2, 
			Enum232.const_2 => Enum80.const_3, 
			Enum232.const_3 => Enum80.const_0, 
			_ => Enum80.const_1, 
		};
	}

	internal static Enum59 smethod_26(MsoArrowheadStyle msoArrowheadStyle_0)
	{
		return msoArrowheadStyle_0 switch
		{
			MsoArrowheadStyle.Arrow => Enum59.const_1, 
			MsoArrowheadStyle.ArrowStealth => Enum59.const_2, 
			MsoArrowheadStyle.ArrowDiamond => Enum59.const_3, 
			MsoArrowheadStyle.ArrowOval => Enum59.const_4, 
			MsoArrowheadStyle.ArrowOpen => Enum59.const_5, 
			_ => Enum59.const_0, 
		};
	}

	internal static Enum58 smethod_27(MsoArrowheadLength msoArrowheadLength_0)
	{
		return msoArrowheadLength_0 switch
		{
			MsoArrowheadLength.Short => Enum58.const_0, 
			MsoArrowheadLength.Medium => Enum58.const_1, 
			MsoArrowheadLength.Long => Enum58.const_2, 
			_ => Enum58.const_0, 
		};
	}

	internal static Enum60 smethod_28(MsoArrowheadWidth msoArrowheadWidth_0)
	{
		return msoArrowheadWidth_0 switch
		{
			MsoArrowheadWidth.Narrow => Enum60.const_0, 
			MsoArrowheadWidth.Medium => Enum60.const_1, 
			MsoArrowheadWidth.Wide => Enum60.const_2, 
			_ => Enum60.const_0, 
		};
	}

	internal static Enum62 smethod_29(Bar3DShapeType bar3DShapeType_0)
	{
		return bar3DShapeType_0 switch
		{
			Bar3DShapeType.PyramidToPoint => Enum62.const_1, 
			Bar3DShapeType.PyramidToMax => Enum62.const_2, 
			Bar3DShapeType.Cylinder => Enum62.const_3, 
			Bar3DShapeType.ConeToPoint => Enum62.const_4, 
			Bar3DShapeType.ConeToMax => Enum62.const_5, 
			_ => Enum62.const_0, 
		};
	}

	internal static Enum73 smethod_30(GradientFillType gradientFillType_0)
	{
		return gradientFillType_0 switch
		{
			GradientFillType.Linear => Enum73.const_0, 
			GradientFillType.Radial => Enum73.const_2, 
			GradientFillType.Path => Enum73.const_3, 
			_ => Enum73.const_1, 
		};
	}

	internal static Enum72 smethod_31(GradientDirectionType gradientDirectionType_0)
	{
		return gradientDirectionType_0 switch
		{
			GradientDirectionType.FromUpperLeftCorner => Enum72.const_0, 
			GradientDirectionType.FromUpperRightCorner => Enum72.const_1, 
			GradientDirectionType.FromLowerLeftCorner => Enum72.const_2, 
			GradientDirectionType.FromLowerRightCorner => Enum72.const_3, 
			GradientDirectionType.FromCenter => Enum72.const_4, 
			_ => Enum72.const_5, 
		};
	}

	internal static Enum85 smethod_32(RectangleAlignmentType rectangleAlignmentType_0)
	{
		return rectangleAlignmentType_0 switch
		{
			RectangleAlignmentType.Bottom => Enum85.const_0, 
			RectangleAlignmentType.BottomLeft => Enum85.const_0, 
			RectangleAlignmentType.BottomRight => Enum85.const_0, 
			RectangleAlignmentType.Center => Enum85.const_2, 
			RectangleAlignmentType.Left => Enum85.const_4, 
			RectangleAlignmentType.Right => Enum85.const_5, 
			RectangleAlignmentType.Top => Enum85.const_6, 
			RectangleAlignmentType.TopRight => Enum85.const_8, 
			_ => Enum85.const_7, 
		};
	}

	internal static Enum86 smethod_33(MirrorType mirrorType_0)
	{
		return mirrorType_0 switch
		{
			MirrorType.Horizonal => Enum86.const_1, 
			MirrorType.Vertical => Enum86.const_2, 
			MirrorType.Both => Enum86.const_3, 
			_ => Enum86.const_0, 
		};
	}

	internal static Enum70 smethod_34(FillPictureType fillPictureType_0)
	{
		return fillPictureType_0 switch
		{
			FillPictureType.Stack => Enum70.const_1, 
			FillPictureType.StackAndScale => Enum70.const_2, 
			_ => Enum70.const_0, 
		};
	}

	internal static Enum2 smethod_35(ChartSplitType chartSplitType_0)
	{
		return chartSplitType_0 switch
		{
			ChartSplitType.Position => Enum2.const_1, 
			ChartSplitType.Value => Enum2.const_2, 
			ChartSplitType.PercentValue => Enum2.const_3, 
			ChartSplitType.Custom => Enum2.const_4, 
			_ => Enum2.const_0, 
		};
	}

	internal static Enum1 smethod_36(CellValueType cellValueType_0)
	{
		return cellValueType_0 switch
		{
			CellValueType.IsBool => Enum1.const_0, 
			CellValueType.IsDateTime => Enum1.const_1, 
			CellValueType.IsError => Enum1.const_2, 
			CellValueType.IsNull => Enum1.const_3, 
			CellValueType.IsNumeric => Enum1.const_4, 
			CellValueType.IsString => Enum1.const_5, 
			_ => Enum1.const_6, 
		};
	}

	internal static Enum17 smethod_37(Enum0 enum0_0)
	{
		return enum0_0 switch
		{
			Enum0.const_0 => Enum17.const_0, 
			Enum0.const_1 => Enum17.const_1, 
			Enum0.const_2 => Enum17.const_2, 
			Enum0.const_3 => Enum17.const_3, 
			_ => Enum17.const_3, 
		};
	}
}
