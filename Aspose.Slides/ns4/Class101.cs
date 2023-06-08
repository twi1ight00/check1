using System.Drawing;
using Aspose.Slides;

namespace ns4;

internal class Class101
{
	internal float float_0;

	internal Color color_0;

	internal LineStyle lineStyle_0;

	internal LineDashStyle lineDashStyle_0;

	internal bool bool_0;

	internal LineArrowheadStyle lineArrowheadStyle_0;

	internal LineArrowheadStyle lineArrowheadStyle_1;

	internal LineArrowheadLength lineArrowheadLength_0;

	internal LineArrowheadLength lineArrowheadLength_1;

	internal LineArrowheadWidth lineArrowheadWidth_0;

	internal LineArrowheadWidth lineArrowheadWidth_1;

	public float Width => float_0;

	public Color Color => color_0;

	public LineStyle Style => lineStyle_0;

	public LineDashStyle DashStyle => lineDashStyle_0;

	public bool RoundEndCap => bool_0;

	public LineArrowheadStyle BeginArrowheadStyle => lineArrowheadStyle_0;

	public LineArrowheadLength BeginArrowheadLength => lineArrowheadLength_0;

	public LineArrowheadWidth BeginArrowheadWidth => lineArrowheadWidth_0;

	public LineArrowheadStyle EndArrowheadStyle => lineArrowheadStyle_1;

	public LineArrowheadLength EndArrowheadLength => lineArrowheadLength_1;

	public LineArrowheadWidth EndArrowheadWidth => lineArrowheadWidth_1;

	internal Class101(Color color, float width)
	{
		float_0 = width;
		color_0 = color;
		lineStyle_0 = LineStyle.Single;
		lineDashStyle_0 = LineDashStyle.Solid;
		bool_0 = false;
		lineArrowheadStyle_1 = LineArrowheadStyle.None;
		lineArrowheadStyle_0 = LineArrowheadStyle.None;
		lineArrowheadLength_1 = LineArrowheadLength.Medium;
		lineArrowheadLength_0 = LineArrowheadLength.Medium;
		lineArrowheadWidth_1 = LineArrowheadWidth.Medium;
		lineArrowheadWidth_0 = LineArrowheadWidth.Medium;
	}

	internal Class101(LineFormat lineFormat)
	{
		float_0 = (float)lineFormat.Width;
		color_0 = lineFormat.FillFormat.SolidFillColor.Color;
		lineStyle_0 = lineFormat.Style;
		lineDashStyle_0 = lineFormat.DashStyle;
		bool_0 = lineFormat.CapStyle == LineCapStyle.Round;
		lineArrowheadStyle_0 = lineFormat.BeginArrowheadStyle;
		lineArrowheadLength_0 = lineFormat.BeginArrowheadLength;
		lineArrowheadWidth_0 = lineFormat.BeginArrowheadWidth;
		lineArrowheadStyle_1 = lineFormat.EndArrowheadStyle;
		lineArrowheadLength_1 = lineFormat.EndArrowheadLength;
		lineArrowheadWidth_1 = lineFormat.EndArrowheadWidth;
	}
}
