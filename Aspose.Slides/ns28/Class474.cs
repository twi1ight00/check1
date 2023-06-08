using System;
using System.Drawing;
using Aspose.Slides;
using ns4;

namespace ns28;

internal class Class474
{
	private LineStyle lineStyle_0 = LineStyle.NotDefined;

	private double double_0 = double.NaN;

	private Color color_0;

	private LineArrowheadStyle lineArrowheadStyle_0 = LineArrowheadStyle.NotDefined;

	private LineArrowheadStyle lineArrowheadStyle_1 = LineArrowheadStyle.NotDefined;

	private LineArrowheadLength lineArrowheadLength_0 = LineArrowheadLength.NotDefined;

	private LineArrowheadLength lineArrowheadLength_1 = LineArrowheadLength.NotDefined;

	private LineArrowheadWidth lineArrowheadWidth_0 = LineArrowheadWidth.NotDefined;

	private LineArrowheadWidth lineArrowheadWidth_1 = LineArrowheadWidth.NotDefined;

	private LineDashStyle lineDashStyle_0 = LineDashStyle.NotDefined;

	private float[] float_0;

	private Class469 class469_0 = new Class469();

	internal LineStyle LineStyle => lineStyle_0;

	internal double Width => double_0;

	internal Color StrokeColor => color_0;

	internal LineArrowheadStyle StartArrowheadStyle => lineArrowheadStyle_0;

	internal LineArrowheadStyle EndArrowheadStyle => lineArrowheadStyle_1;

	internal LineArrowheadLength StartArrowheadLength => lineArrowheadLength_0;

	internal LineArrowheadLength EndArrowheadLength => lineArrowheadLength_1;

	internal LineArrowheadWidth StartArrowheadWidth => lineArrowheadWidth_0;

	internal LineArrowheadWidth EndArrowheadWidth => lineArrowheadWidth_1;

	internal LineDashStyle DashStyle => lineDashStyle_0;

	internal float[] DashPattern => float_0;

	internal Class469 FillParam => class469_0;

	public Class474(ILineParamSource[] formats)
	{
		foreach (ILineParamSource lineParamSource in formats)
		{
			method_0(lineParamSource);
		}
	}

	private void method_0(ILineParamSource lineParamSource)
	{
		if (lineParamSource == null)
		{
			return;
		}
		if (lineParamSource is LineFormat)
		{
			LineFormat lineFormat = (LineFormat)lineParamSource;
			if (lineFormat.Style != LineStyle.NotDefined)
			{
				lineStyle_0 = lineFormat.Style;
			}
			if (lineFormat.BeginArrowheadStyle != LineArrowheadStyle.NotDefined)
			{
				lineArrowheadStyle_0 = lineFormat.BeginArrowheadStyle;
			}
			if (lineFormat.BeginArrowheadLength != LineArrowheadLength.NotDefined)
			{
				lineArrowheadLength_0 = lineFormat.BeginArrowheadLength;
			}
			if (lineFormat.BeginArrowheadWidth != LineArrowheadWidth.NotDefined)
			{
				lineArrowheadWidth_0 = lineFormat.BeginArrowheadWidth;
			}
			if (lineFormat.EndArrowheadStyle != LineArrowheadStyle.NotDefined)
			{
				lineArrowheadStyle_1 = lineFormat.EndArrowheadStyle;
			}
			if (lineFormat.EndArrowheadLength != LineArrowheadLength.NotDefined)
			{
				lineArrowheadLength_1 = lineFormat.EndArrowheadLength;
			}
			if (lineFormat.EndArrowheadWidth != LineArrowheadWidth.NotDefined)
			{
				lineArrowheadWidth_1 = lineFormat.EndArrowheadWidth;
			}
			if (lineFormat.DashStyle != LineDashStyle.NotDefined)
			{
				lineDashStyle_0 = lineFormat.DashStyle;
				float_0 = lineFormat.CustomDashPattern;
			}
			if (!double.IsNaN(lineFormat.Width))
			{
				double_0 = lineFormat.Width;
			}
			class469_0.method_0(lineFormat.FillFormat);
			if (lineFormat.FillFormat.FillType == FillType.Solid)
			{
				color_0 = lineFormat.FillFormat.SolidFillColor.Color;
			}
		}
		else if (lineParamSource is Class512)
		{
			Class512 @class = (Class512)lineParamSource;
			method_0(@class.lineFormat_0);
			if (@class.floatColor_0 != null)
			{
				color_0 = @class.floatColor_0.Color;
			}
		}
	}

	internal void method_1(Class437 style, Class476 odpPackage)
	{
		if (FillParam.FillType != FillType.NotDefined && FillParam.FillType != 0)
		{
			style.GraphicProperties.StrokeWidth = (double.IsNaN(Width) ? 0.0 : Width);
			if (FillParam.FillType == FillType.Solid)
			{
				style.GraphicProperties.StrokeColor = StrokeColor;
				if (StrokeColor.A < byte.MaxValue)
				{
					style.GraphicProperties.StrokeOpacity = (double)(int)StrokeColor.A / 255.0;
				}
			}
			if (StartArrowheadStyle != 0 && StartArrowheadStyle != LineArrowheadStyle.NotDefined)
			{
				style.GraphicProperties.StartMarker = method_2(odpPackage, StartArrowheadStyle, StartArrowheadLength, StartArrowheadWidth);
				style.GraphicProperties.StartMarkerWidth = (double)(1 + (1 << Math.Abs((int)StartArrowheadWidth))) * Width * 1.2;
			}
			if (EndArrowheadStyle != 0 && EndArrowheadStyle != LineArrowheadStyle.NotDefined)
			{
				style.GraphicProperties.EndMarker = method_2(odpPackage, EndArrowheadStyle, EndArrowheadLength, EndArrowheadWidth);
				style.GraphicProperties.EndMarkerWidth = (double)(1 + (1 << Math.Abs((int)EndArrowheadWidth))) * Width * 1.2000000476837158;
			}
			if (DashStyle == LineDashStyle.Solid)
			{
				style.GraphicProperties.StrokeStyle = Enum83.const_2;
			}
			else
			{
				if (DashStyle == LineDashStyle.NotDefined)
				{
					return;
				}
				Class436 @class = odpPackage.class465_0.method_12("Dashes_" + odpPackage.int_0++);
				style.GraphicProperties.StrokeDash = @class.Name;
				style.GraphicProperties.StrokeStyle = Enum83.const_1;
				switch (DashStyle)
				{
				case LineDashStyle.Dot:
					@class.Dots1Length = 1.0 * Width;
					@class.Distance = 3.0 * Width;
					@class.Dots1 = 1;
					break;
				case LineDashStyle.Dash:
					@class.Dots1Length = 4.0 * Width;
					@class.Distance = 3.0 * Width;
					@class.Dots1 = 1;
					break;
				case LineDashStyle.LargeDash:
					@class.Dots1Length = 8.0 * Width;
					@class.Distance = 3.0 * Width;
					@class.Dots1 = 1;
					break;
				case LineDashStyle.DashDot:
					@class.Dots1Length = 4.0 * Width;
					@class.Dots2Length = 1.0 * Width;
					@class.Distance = 3.0 * Width;
					@class.Dots1 = 1;
					@class.Dots2 = 1;
					break;
				case LineDashStyle.LargeDashDot:
					@class.Dots1Length = 8.0 * Width;
					@class.Dots2Length = 1.0 * Width;
					@class.Distance = 3.0 * Width;
					@class.Dots1 = 1;
					@class.Dots2 = 1;
					break;
				case LineDashStyle.LargeDashDotDot:
					@class.Dots1Length = 8.0 * Width;
					@class.Dots2Length = 1.0 * Width;
					@class.Distance = 3.0 * Width;
					@class.Dots1 = 1;
					@class.Dots2 = 2;
					break;
				case LineDashStyle.SystemDash:
					@class.Dots1Length = 3.0 * Width;
					@class.Distance = 1.0 * Width;
					@class.Dots1 = 1;
					break;
				case LineDashStyle.SystemDot:
					@class.Dots1Length = 1.0 * Width;
					@class.Distance = 1.0 * Width;
					@class.Dots1 = 1;
					break;
				case LineDashStyle.SystemDashDot:
					@class.Dots1Length = 3.0 * Width;
					@class.Dots2Length = 1.0 * Width;
					@class.Distance = 1.0 * Width;
					@class.Dots1 = 1;
					@class.Dots2 = 1;
					break;
				case LineDashStyle.SystemDashDotDot:
					@class.Dots1Length = 3.0 * Width;
					@class.Dots2Length = 1.0 * Width;
					@class.Distance = 1.0 * Width;
					@class.Dots1 = 1;
					@class.Dots2 = 2;
					break;
				case LineDashStyle.Custom:
				{
					if (DashPattern.Length < 2)
					{
						break;
					}
					@class.Distance = DashPattern[1];
					int i = 0;
					int num = 1;
					@class.Dots1 = 0;
					@class.Dots2 = 0;
					@class.Dots1Length = (double)DashPattern[0] * Width;
					float num2 = DashPattern[0];
					for (; i < DashPattern.Length - 1; i += 2)
					{
						if (DashPattern[i] == num2 && num == 1)
						{
							@class.Dots1++;
							continue;
						}
						if (DashPattern[i] == num2 && num == 2)
						{
							@class.Dots2++;
							continue;
						}
						if (DashPattern[i] != num2 && num == 1)
						{
							num = 2;
							num2 = DashPattern[i];
							@class.Dots2Length = (double)DashPattern[i] * Width;
							@class.Dots2++;
							continue;
						}
						break;
					}
					break;
				}
				}
			}
		}
		else
		{
			style.GraphicProperties.StrokeStyle = Enum83.const_0;
		}
	}

	internal string method_2(Class476 odpPackage, LineArrowheadStyle arrowhead, LineArrowheadLength length, LineArrowheadWidth width)
	{
		if (arrowhead != LineArrowheadStyle.NotDefined && arrowhead != 0)
		{
			Class409 @class = odpPackage.class465_0.method_10(Class368.smethod_2(arrowhead, length, width), Class368.smethod_4(arrowhead, length, width), Class368.smethod_3(arrowhead) + odpPackage.int_0++);
			return @class.Name;
		}
		return null;
	}
}
