using System;
using System.Collections.Generic;
using Aspose.Slides;
using ns24;

namespace ns32;

internal class Class542
{
	private static Dictionary<ShapeType, Class342> dictionary_0;

	static Class542()
	{
		dictionary_0 = new Dictionary<ShapeType, Class342>();
		foreach (ShapeType value in Enum.GetValues(typeof(ShapeType)))
		{
			dictionary_0.Add(value, null);
		}
	}

	public static Class342 smethod_0(ShapeType type)
	{
		Class342 @class = dictionary_0[type];
		if (@class == null)
		{
			switch (type)
			{
			case ShapeType.Line:
				dictionary_0[type] = Class663.smethod_0();
				break;
			case ShapeType.LineInverse:
				dictionary_0[type] = Class664.smethod_0();
				break;
			case ShapeType.Triangle:
				dictionary_0[type] = Class719.smethod_0();
				break;
			case ShapeType.RightTriangle:
				dictionary_0[type] = Class696.smethod_0();
				break;
			case ShapeType.NotDefined:
			case ShapeType.Rectangle:
				dictionary_0[ShapeType.Rectangle] = Class685.smethod_0();
				dictionary_0[ShapeType.NotDefined] = dictionary_0[ShapeType.Rectangle];
				break;
			case ShapeType.Diamond:
				dictionary_0[type] = Class600.smethod_0();
				break;
			case ShapeType.Parallelogram:
				dictionary_0[type] = Class676.smethod_0();
				break;
			case ShapeType.Trapezoid:
				dictionary_0[type] = Class718.smethod_0();
				break;
			case ShapeType.NonIsoscelesTrapezoid:
				dictionary_0[type] = Class672.smethod_0();
				break;
			case ShapeType.Pentagon:
				dictionary_0[type] = Class677.smethod_0();
				break;
			case ShapeType.Hexagon:
				dictionary_0[type] = Class646.smethod_0();
				break;
			case ShapeType.Heptagon:
				dictionary_0[type] = Class645.smethod_0();
				break;
			case ShapeType.Octagon:
				dictionary_0[type] = Class675.smethod_0();
				break;
			case ShapeType.Decagon:
				dictionary_0[type] = Class598.smethod_0();
				break;
			case ShapeType.Dodecagon:
				dictionary_0[type] = Class601.smethod_0();
				break;
			case ShapeType.FourPointedStar:
				dictionary_0[type] = Class708.smethod_0();
				break;
			case ShapeType.FivePointedStar:
				dictionary_0[type] = Class709.smethod_0();
				break;
			case ShapeType.SixPointedStar:
				dictionary_0[type] = Class710.smethod_0();
				break;
			case ShapeType.SevenPointedStar:
				dictionary_0[type] = Class711.smethod_0();
				break;
			case ShapeType.EightPointedStar:
				dictionary_0[type] = Class712.smethod_0();
				break;
			case ShapeType.TenPointedStar:
				dictionary_0[type] = Class703.smethod_0();
				break;
			case ShapeType.TwelvePointedStar:
				dictionary_0[type] = Class704.smethod_0();
				break;
			case ShapeType.SixteenPointedStar:
				dictionary_0[type] = Class705.smethod_0();
				break;
			case ShapeType.TwentyFourPointedStar:
				dictionary_0[type] = Class706.smethod_0();
				break;
			case ShapeType.ThirtyTwoPointedStar:
				dictionary_0[type] = Class707.smethod_0();
				break;
			case ShapeType.RoundCornerRectangle:
				dictionary_0[type] = Class695.smethod_0();
				break;
			case ShapeType.OneRoundCornerRectangle:
				dictionary_0[type] = Class692.smethod_0();
				break;
			case ShapeType.TwoSamesideRoundCornerRectangle:
				dictionary_0[type] = Class694.smethod_0();
				break;
			case ShapeType.TwoDiagonalRoundCornerRectangle:
				dictionary_0[type] = Class693.smethod_0();
				break;
			case ShapeType.OneSnipOneRoundCornerRectangle:
				dictionary_0[type] = Class701.smethod_0();
				break;
			case ShapeType.OneSnipCornerRectangle:
				dictionary_0[type] = Class698.smethod_0();
				break;
			case ShapeType.TwoSamesideSnipCornerRectangle:
				dictionary_0[type] = Class700.smethod_0();
				break;
			case ShapeType.TwoDiagonalSnipCornerRectangle:
				dictionary_0[type] = Class699.smethod_0();
				break;
			case ShapeType.Plaque:
				dictionary_0[type] = Class680.smethod_0();
				break;
			case ShapeType.Ellipse:
				dictionary_0[type] = Class606.smethod_0();
				break;
			case ShapeType.Teardrop:
				dictionary_0[type] = Class717.smethod_0();
				break;
			case ShapeType.HomePlate:
				dictionary_0[type] = Class647.smethod_0();
				break;
			case ShapeType.Chevron:
				dictionary_0[type] = Class582.smethod_0();
				break;
			case ShapeType.PieWedge:
				dictionary_0[type] = Class679.smethod_0();
				break;
			case ShapeType.Pie:
				dictionary_0[type] = Class678.smethod_0();
				break;
			case ShapeType.BlockArc:
				dictionary_0[type] = Class569.smethod_0();
				break;
			case ShapeType.Donut:
				dictionary_0[type] = Class602.smethod_0();
				break;
			case ShapeType.NoSmoking:
				dictionary_0[type] = Class673.smethod_0();
				break;
			case ShapeType.RightArrow:
				dictionary_0[type] = Class689.smethod_0();
				break;
			case ShapeType.LeftArrow:
				dictionary_0[type] = Class652.smethod_0();
				break;
			case ShapeType.UpArrow:
				dictionary_0[type] = Class721.smethod_0();
				break;
			case ShapeType.DownArrow:
				dictionary_0[type] = Class605.smethod_0();
				break;
			case ShapeType.StripedRightArrow:
				dictionary_0[type] = Class714.smethod_0();
				break;
			case ShapeType.NotchedRightArrow:
				dictionary_0[type] = Class674.smethod_0();
				break;
			case ShapeType.BentUpArrow:
				dictionary_0[type] = Class567.smethod_0();
				break;
			case ShapeType.LeftRightArrow:
				dictionary_0[type] = Class657.smethod_0();
				break;
			case ShapeType.UpDownArrow:
				dictionary_0[type] = Class723.smethod_0();
				break;
			case ShapeType.LeftUpArrow:
				dictionary_0[type] = Class661.smethod_0();
				break;
			case ShapeType.LeftRightUpArrow:
				dictionary_0[type] = Class660.smethod_0();
				break;
			case ShapeType.QuadArrow:
				dictionary_0[type] = Class684.smethod_0();
				break;
			case ShapeType.CalloutLeftArrow:
				dictionary_0[type] = Class651.smethod_0();
				break;
			case ShapeType.CalloutRightArrow:
				dictionary_0[type] = Class688.smethod_0();
				break;
			case ShapeType.CalloutUpArrow:
				dictionary_0[type] = Class720.smethod_0();
				break;
			case ShapeType.CalloutDownArrow:
				dictionary_0[type] = Class604.smethod_0();
				break;
			case ShapeType.CalloutLeftRightArrow:
				dictionary_0[type] = Class656.smethod_0();
				break;
			case ShapeType.CalloutUpDownArrow:
				dictionary_0[type] = Class722.smethod_0();
				break;
			case ShapeType.CalloutQuadArrow:
				dictionary_0[type] = Class683.smethod_0();
				break;
			case ShapeType.BentArrow:
				dictionary_0[type] = Class562.smethod_0();
				break;
			case ShapeType.UTurnArrow:
				dictionary_0[type] = Class724.smethod_0();
				break;
			case ShapeType.CircularArrow:
				dictionary_0[type] = Class584.smethod_0();
				break;
			case ShapeType.LeftCircularArrow:
				dictionary_0[type] = Class655.smethod_0();
				break;
			case ShapeType.LeftRightCircularArrow:
				dictionary_0[type] = Class658.smethod_0();
				break;
			case ShapeType.CurvedRightArrow:
				dictionary_0[type] = Class596.smethod_0();
				break;
			case ShapeType.CurvedLeftArrow:
				dictionary_0[type] = Class595.smethod_0();
				break;
			case ShapeType.CurvedUpArrow:
				dictionary_0[type] = Class597.smethod_0();
				break;
			case ShapeType.CurvedDownArrow:
				dictionary_0[type] = Class594.smethod_0();
				break;
			case ShapeType.SwooshArrow:
				dictionary_0[type] = Class716.smethod_0();
				break;
			case ShapeType.Cube:
				dictionary_0[type] = Class589.smethod_0();
				break;
			case ShapeType.Can:
				dictionary_0[type] = Class578.smethod_0();
				break;
			case ShapeType.LightningBolt:
				dictionary_0[type] = Class662.smethod_0();
				break;
			case ShapeType.Heart:
				dictionary_0[type] = Class644.smethod_0();
				break;
			case ShapeType.Sun:
				dictionary_0[type] = Class715.smethod_0();
				break;
			case ShapeType.Moon:
				dictionary_0[type] = Class671.smethod_0();
				break;
			case ShapeType.SmileyFace:
				dictionary_0[type] = Class697.smethod_0();
				break;
			case ShapeType.IrregularSeal1:
				dictionary_0[type] = Class649.smethod_0();
				break;
			case ShapeType.IrregularSeal2:
				dictionary_0[type] = Class650.smethod_0();
				break;
			case ShapeType.FoldedCorner:
				dictionary_0[type] = Class638.smethod_0();
				break;
			case ShapeType.Bevel:
				dictionary_0[type] = Class568.smethod_0();
				break;
			case ShapeType.Frame:
				dictionary_0[type] = Class639.smethod_0();
				break;
			case ShapeType.HalfFrame:
				dictionary_0[type] = Class643.smethod_0();
				break;
			case ShapeType.Corner:
				dictionary_0[type] = Class587.smethod_0();
				break;
			case ShapeType.DiagonalStripe:
				dictionary_0[type] = Class599.smethod_0();
				break;
			case ShapeType.Chord:
				dictionary_0[type] = Class583.smethod_0();
				break;
			case ShapeType.CurvedArc:
				dictionary_0[type] = Class561.smethod_0();
				break;
			case ShapeType.LeftBracket:
				dictionary_0[type] = Class654.smethod_0();
				break;
			case ShapeType.RightBracket:
				dictionary_0[type] = Class691.smethod_0();
				break;
			case ShapeType.LeftBrace:
				dictionary_0[type] = Class653.smethod_0();
				break;
			case ShapeType.RightBrace:
				dictionary_0[type] = Class690.smethod_0();
				break;
			case ShapeType.BracketPair:
				dictionary_0[type] = Class574.smethod_0();
				break;
			case ShapeType.BracePair:
				dictionary_0[type] = Class573.smethod_0();
				break;
			case ShapeType.StraightConnector1:
				dictionary_0[type] = Class713.smethod_0();
				break;
			case ShapeType.BentConnector2:
				dictionary_0[type] = Class563.smethod_0();
				break;
			case ShapeType.BentConnector3:
				dictionary_0[type] = Class564.smethod_0();
				break;
			case ShapeType.BentConnector4:
				dictionary_0[type] = Class565.smethod_0();
				break;
			case ShapeType.BentConnector5:
				dictionary_0[type] = Class566.smethod_0();
				break;
			case ShapeType.CurvedConnector2:
				dictionary_0[type] = Class590.smethod_0();
				break;
			case ShapeType.CurvedConnector3:
				dictionary_0[type] = Class591.smethod_0();
				break;
			case ShapeType.CurvedConnector4:
				dictionary_0[type] = Class592.smethod_0();
				break;
			case ShapeType.CurvedConnector5:
				dictionary_0[type] = Class593.smethod_0();
				break;
			case ShapeType.Callout1:
				dictionary_0[type] = Class575.smethod_0();
				break;
			case ShapeType.Callout2:
				dictionary_0[type] = Class576.smethod_0();
				break;
			case ShapeType.Callout3:
				dictionary_0[type] = Class577.smethod_0();
				break;
			case ShapeType.Callout1WithAccent:
				dictionary_0[type] = Class546.smethod_0();
				break;
			case ShapeType.Callout2WithAccent:
				dictionary_0[type] = Class547.smethod_0();
				break;
			case ShapeType.Callout3WithAccent:
				dictionary_0[type] = Class548.smethod_0();
				break;
			case ShapeType.Callout1WithBorder:
				dictionary_0[type] = Class570.smethod_0();
				break;
			case ShapeType.Callout2WithBorder:
				dictionary_0[type] = Class571.smethod_0();
				break;
			case ShapeType.Callout3WithBorder:
				dictionary_0[type] = Class572.smethod_0();
				break;
			case ShapeType.Callout1WithBorderAndAccent:
				dictionary_0[type] = Class543.smethod_0();
				break;
			case ShapeType.Callout2WithBorderAndAccent:
				dictionary_0[type] = Class544.smethod_0();
				break;
			case ShapeType.Callout3WithBorderAndAccent:
				dictionary_0[type] = Class545.smethod_0();
				break;
			case ShapeType.CalloutWedgeRectangle:
				dictionary_0[type] = Class728.smethod_0();
				break;
			case ShapeType.CalloutWedgeRoundRectangle:
				dictionary_0[type] = Class729.smethod_0();
				break;
			case ShapeType.CalloutWedgeEllipse:
				dictionary_0[type] = Class727.smethod_0();
				break;
			case ShapeType.CalloutCloud:
				dictionary_0[type] = Class585.smethod_0();
				break;
			case ShapeType.Cloud:
				dictionary_0[type] = Class586.smethod_0();
				break;
			case ShapeType.Ribbon:
				dictionary_0[type] = Class687.smethod_0();
				break;
			case ShapeType.Ribbon2:
				dictionary_0[type] = Class686.smethod_0();
				break;
			case ShapeType.EllipseRibbon:
				dictionary_0[type] = Class608.smethod_0();
				break;
			case ShapeType.EllipseRibbon2:
				dictionary_0[type] = Class607.smethod_0();
				break;
			case ShapeType.LeftRightRibbon:
				dictionary_0[type] = Class659.smethod_0();
				break;
			case ShapeType.VerticalScroll:
				dictionary_0[type] = Class725.smethod_0();
				break;
			case ShapeType.HorizontalScroll:
				dictionary_0[type] = Class648.smethod_0();
				break;
			case ShapeType.Wave:
				dictionary_0[type] = Class726.smethod_0();
				break;
			case ShapeType.DoubleWave:
				dictionary_0[type] = Class603.smethod_0();
				break;
			case ShapeType.Plus:
				dictionary_0[type] = Class682.smethod_0();
				break;
			case ShapeType.ProcessFlow:
				dictionary_0[type] = Class632.smethod_0();
				break;
			case ShapeType.DecisionFlow:
				dictionary_0[type] = Class612.smethod_0();
				break;
			case ShapeType.InputOutputFlow:
				dictionary_0[type] = Class617.smethod_0();
				break;
			case ShapeType.PredefinedProcessFlow:
				dictionary_0[type] = Class630.smethod_0();
				break;
			case ShapeType.InternalStorageFlow:
				dictionary_0[type] = Class618.smethod_0();
				break;
			case ShapeType.DocumentFlow:
				dictionary_0[type] = Class615.smethod_0();
				break;
			case ShapeType.MultiDocumentFlow:
				dictionary_0[type] = Class625.smethod_0();
				break;
			case ShapeType.TerminatorFlow:
				dictionary_0[type] = Class637.smethod_0();
				break;
			case ShapeType.PreparationFlow:
				dictionary_0[type] = Class631.smethod_0();
				break;
			case ShapeType.ManualInputFlow:
				dictionary_0[type] = Class622.smethod_0();
				break;
			case ShapeType.ManualOperationFlow:
				dictionary_0[type] = Class623.smethod_0();
				break;
			case ShapeType.ConnectorFlow:
				dictionary_0[type] = Class611.smethod_0();
				break;
			case ShapeType.PunchedCardFlow:
				dictionary_0[type] = Class633.smethod_0();
				break;
			case ShapeType.PunchedTapeFlow:
				dictionary_0[type] = Class634.smethod_0();
				break;
			case ShapeType.SummingJunctionFlow:
				dictionary_0[type] = Class636.smethod_0();
				break;
			case ShapeType.OrFlow:
				dictionary_0[type] = Class629.smethod_0();
				break;
			case ShapeType.CollateFlow:
				dictionary_0[type] = Class610.smethod_0();
				break;
			case ShapeType.SortFlow:
				dictionary_0[type] = Class635.smethod_0();
				break;
			case ShapeType.ExtractFlow:
				dictionary_0[type] = Class616.smethod_0();
				break;
			case ShapeType.MergeFlow:
				dictionary_0[type] = Class624.smethod_0();
				break;
			case ShapeType.OfflineStorageFlow:
				dictionary_0[type] = Class626.smethod_0();
				break;
			case ShapeType.OnlineStorageFlow:
				dictionary_0[type] = Class628.smethod_0();
				break;
			case ShapeType.MagneticTapeFlow:
				dictionary_0[type] = Class621.smethod_0();
				break;
			case ShapeType.MagneticDiskFlow:
				dictionary_0[type] = Class619.smethod_0();
				break;
			case ShapeType.MagneticDrumFlow:
				dictionary_0[type] = Class620.smethod_0();
				break;
			case ShapeType.DisplayFlow:
				dictionary_0[type] = Class614.smethod_0();
				break;
			case ShapeType.DelayFlow:
				dictionary_0[type] = Class613.smethod_0();
				break;
			case ShapeType.AlternateProcessFlow:
				dictionary_0[type] = Class609.smethod_0();
				break;
			case ShapeType.OffPageConnectorFlow:
				dictionary_0[type] = Class627.smethod_0();
				break;
			case ShapeType.BlankButton:
				dictionary_0[type] = Class551.smethod_0();
				break;
			case ShapeType.HomeButton:
				dictionary_0[type] = Class556.smethod_0();
				break;
			case ShapeType.HelpButton:
				dictionary_0[type] = Class555.smethod_0();
				break;
			case ShapeType.InformationButton:
				dictionary_0[type] = Class557.smethod_0();
				break;
			case ShapeType.ForwardOrNextButton:
				dictionary_0[type] = Class554.smethod_0();
				break;
			case ShapeType.BackOrPreviousButton:
				dictionary_0[type] = Class549.smethod_0();
				break;
			case ShapeType.EndButton:
				dictionary_0[type] = Class553.smethod_0();
				break;
			case ShapeType.BeginningButton:
				dictionary_0[type] = Class550.smethod_0();
				break;
			case ShapeType.ReturnButton:
				dictionary_0[type] = Class559.smethod_0();
				break;
			case ShapeType.DocumentButton:
				dictionary_0[type] = Class552.smethod_0();
				break;
			case ShapeType.SoundButton:
				dictionary_0[type] = Class560.smethod_0();
				break;
			case ShapeType.MovieButton:
				dictionary_0[type] = Class558.smethod_0();
				break;
			case ShapeType.Gear6:
				dictionary_0[type] = Class641.smethod_0();
				break;
			case ShapeType.Gear9:
				dictionary_0[type] = Class642.smethod_0();
				break;
			case ShapeType.Funnel:
				dictionary_0[type] = Class640.smethod_0();
				break;
			case ShapeType.PlusMath:
				dictionary_0[type] = Class670.smethod_0();
				break;
			case ShapeType.MinusMath:
				dictionary_0[type] = Class667.smethod_0();
				break;
			case ShapeType.MultiplyMath:
				dictionary_0[type] = Class668.smethod_0();
				break;
			case ShapeType.DivideMath:
				dictionary_0[type] = Class665.smethod_0();
				break;
			case ShapeType.EqualMath:
				dictionary_0[type] = Class666.smethod_0();
				break;
			case ShapeType.NotEqualMath:
				dictionary_0[type] = Class669.smethod_0();
				break;
			case ShapeType.CornerTabs:
				dictionary_0[type] = Class588.smethod_0();
				break;
			case ShapeType.SquareTabs:
				dictionary_0[type] = Class702.smethod_0();
				break;
			case ShapeType.PlaqueTabs:
				dictionary_0[type] = Class681.smethod_0();
				break;
			case ShapeType.ChartX:
				dictionary_0[type] = Class581.smethod_0();
				break;
			case ShapeType.ChartStar:
				dictionary_0[type] = Class580.smethod_0();
				break;
			case ShapeType.ChartPlus:
				dictionary_0[type] = Class579.smethod_0();
				break;
			}
			return dictionary_0[type];
		}
		return @class;
	}
}
