using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Slides;
using Aspose.Slides.Charts;

namespace ns2;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct44
{
	internal static void smethod_0(PointF p1, PointF p2, Color defColor, LineFormat lineFormat, Class784 chartRenderContext)
	{
		if (lineFormat.FillFormat.FillType == FillType.NoFill)
		{
			return;
		}
		using GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(p1, p2);
		GraphicsPath path = (GraphicsPath)graphicsPath.Clone();
		using Pen pen = smethod_4(defColor, lineFormat, chartRenderContext);
		chartRenderContext.Chart2007.Graphics.imethod_45(pen, path);
	}

	internal static void smethod_1(Color defColor, Class784 renderContext, RectangleF rect, Format format)
	{
		smethod_2(defColor, renderContext, rect, (LineFormat)format.Line, (FillFormat)format.Fill);
	}

	internal static void smethod_2(Color defColor, Class784 renderContext, RectangleF rect, LineFormat lineFormat, FillFormat fillFormat)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		smethod_3(defColor, renderContext, graphicsPath, lineFormat, fillFormat);
	}

	internal static void smethod_3(Color defColor, Class784 renderContext, GraphicsPath path, LineFormat lineFormat, FillFormat fillFormat)
	{
		Brush brush = smethod_5(Color.Empty, fillFormat, renderContext, path);
		renderContext.Graphics.imethod_77(brush, path);
		brush.Dispose();
		Pen pen = smethod_4(defColor, lineFormat, renderContext);
		renderContext.Graphics.imethod_45(pen, path);
		pen.Dispose();
	}

	private static Pen smethod_4(Color defColor, LineFormat lineFormat, Class784 chartRenderContext)
	{
		Color color = defColor;
		Pen pen = new Pen(lineFormat.FillFormat.FillType switch
		{
			FillType.Solid => smethod_7((ColorFormat)lineFormat.FillFormat.SolidFillColor, chartRenderContext), 
			FillType.Gradient => defColor, 
			_ => defColor, 
		}, double.IsNaN(lineFormat.Width) ? 1f : ((float)lineFormat.Width));
		smethod_9(pen, lineFormat);
		return pen;
	}

	private static Brush smethod_5(Color defColor, FillFormat fillFormat, Class784 chartRenderContext, GraphicsPath path)
	{
		switch (fillFormat.FillType)
		{
		default:
			return new SolidBrush(defColor);
		case FillType.NoFill:
			return new SolidBrush(Color.Empty);
		case FillType.Solid:
			return new SolidBrush(smethod_7((ColorFormat)fillFormat.SolidFillColor, chartRenderContext));
		case FillType.Gradient:
			return smethod_6(fillFormat, chartRenderContext, path);
		case FillType.Pattern:
		{
			Color foreColor = smethod_7((ColorFormat)fillFormat.PatternFormat.ForeColor, chartRenderContext);
			Color backColor = smethod_7((ColorFormat)fillFormat.PatternFormat.BackColor, chartRenderContext);
			return new HatchBrush(smethod_13(fillFormat.PatternFormat.PatternStyle), foreColor, backColor);
		}
		case FillType.Picture:
			return smethod_8(fillFormat, path);
		}
	}

	private static Brush smethod_6(IFillFormat fillFormat, Class784 chartRenderContext, GraphicsPath path)
	{
		RectangleF bounds = path.GetBounds();
		if (!(bounds.Width <= 0f) && bounds.Height > 0f)
		{
			Color[] array = new Color[fillFormat.GradientFormat.GradientStops.Count];
			float[] array2 = new float[fillFormat.GradientFormat.GradientStops.Count];
			for (int i = 0; i < fillFormat.GradientFormat.GradientStops.Count; i++)
			{
				IGradientStop gradientStop = fillFormat.GradientFormat.GradientStops[i];
				ref Color reference = ref array[i];
				reference = smethod_7((ColorFormat)gradientStop.Color, chartRenderContext);
				array2[i] = gradientStop.Position;
			}
			ColorBlend colorBlend = new ColorBlend();
			colorBlend.Colors = array;
			colorBlend.Positions = array2;
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, Color.Red, Color.Green, fillFormat.GradientFormat.LinearGradientAngle);
			linearGradientBrush.InterpolationColors = colorBlend;
			return linearGradientBrush;
		}
		return new SolidBrush(Color.Empty);
	}

	private static Color smethod_7(ColorFormat srcColorFormat, Class784 renderContext)
	{
		if (srcColorFormat.ColorType == ColorType.Scheme)
		{
			Chart chart = renderContext.Chart;
			ColorFormat colorFormat = new ColorFormat(renderContext.Chart);
			if (chart.PPTXUnsupportedProps.ColorMappingOverride.On && chart.ThemeManager.IsOverrideThemeEnabled)
			{
				ColorSchemeIndex index = (ColorSchemeIndex)srcColorFormat.int_0;
				colorFormat = new ColorFormat(chart, chart.ThemeManager.OverrideTheme.ColorScheme[index].Color);
			}
			else
			{
				colorFormat = new ColorFormat(chart, ((Slide)chart.Slide).method_2(srcColorFormat.SchemeColor).Color);
			}
			((ColorOperationCollection)colorFormat.ColorTransform).list_0 = ((ColorOperationCollection)srcColorFormat.ColorTransform).list_0;
			return colorFormat.Color;
		}
		return srcColorFormat.Color;
	}

	internal static Brush smethod_8(IFillFormat fillFormat, GraphicsPath path)
	{
		Image systemImage = fillFormat.PictureFillFormat.Picture.Image.SystemImage;
		if (fillFormat.PictureFillFormat.PictureFillMode == PictureFillMode.Tile)
		{
			RectangleF bounds = path.GetBounds();
			TextureBrush textureBrush = new TextureBrush(systemImage, WrapMode.Tile);
			Matrix matrix = new Matrix();
			matrix.Translate(bounds.X, bounds.Y);
			textureBrush.Transform = matrix;
			return textureBrush;
		}
		RectangleF bounds2 = path.GetBounds();
		Bitmap bitmap = new Bitmap((int)bounds2.Width, (int)bounds2.Height);
		TextureBrush textureBrush2 = new TextureBrush(bitmap);
		Matrix matrix2 = new Matrix();
		matrix2.Translate(bounds2.X, bounds2.Y);
		textureBrush2.Transform = matrix2;
		return textureBrush2;
	}

	private static void smethod_9(Pen pen, ILineFormat lineFormat)
	{
		pen.DashCap = DashCap.Round;
		switch (lineFormat.DashStyle)
		{
		case LineDashStyle.Solid:
			pen.DashStyle = DashStyle.Solid;
			break;
		case LineDashStyle.Dash:
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[2] { 4f, 3f };
			break;
		case LineDashStyle.LargeDash:
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[2] { 8f, 3f };
			break;
		case LineDashStyle.DashDot:
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[4] { 4f, 3f, 1f, 3f };
			break;
		case LineDashStyle.LargeDashDot:
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[4] { 8f, 3f, 1f, 3f };
			break;
		case LineDashStyle.LargeDashDotDot:
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[6] { 8f, 3f, 1f, 3f, 1f, 3f };
			break;
		case LineDashStyle.SystemDash:
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[2] { 3f, 1f };
			break;
		case LineDashStyle.SystemDot:
			pen.DashStyle = DashStyle.Dot;
			pen.DashCap = DashCap.Round;
			break;
		}
		switch (lineFormat.JoinStyle)
		{
		default:
			pen.LineJoin = LineJoin.Round;
			break;
		case LineJoinStyle.Bevel:
			pen.LineJoin = LineJoin.Bevel;
			break;
		case LineJoinStyle.Miter:
			pen.LineJoin = LineJoin.Miter;
			break;
		}
	}

	internal static Color smethod_10(Color color, double tint)
	{
		int[] array = new int[3] { color.R, color.G, color.B };
		for (int i = 0; i < 3; i++)
		{
			double num = smethod_12(array[i]);
			double scrgbValue = num * (1.0 + (1.0 - tint));
			if (tint > 0.0)
			{
				scrgbValue = num * (1.0 - (1.0 - tint)) + (1.0 - tint);
			}
			array[i] = smethod_11(scrgbValue);
		}
		return Color.FromArgb(array[0], array[1], array[2]);
	}

	private static int smethod_11(double scrgbValue)
	{
		double num = ((scrgbValue < 0.0) ? 0.0 : ((scrgbValue <= 0.0031308) ? (scrgbValue * 12.92) : ((!(scrgbValue < 1.0)) ? 1.0 : (1.055 * Math.Pow(scrgbValue, 5.0 / 12.0) - 0.055))));
		return (int)Math.Round(num * 255.0, 0, MidpointRounding.AwayFromZero);
	}

	private static double smethod_12(int srgbValue)
	{
		double num = (double)srgbValue / 255.0;
		double num2 = 0.0;
		if (num < 0.0)
		{
			return 0.0;
		}
		if (num <= 0.04045)
		{
			return num / 12.92;
		}
		if (num <= 1.0)
		{
			return Math.Pow((num + 0.055) / 1.055, 2.4);
		}
		return 1.0;
	}

	private static HatchStyle smethod_13(PatternStyle patternStyle)
	{
		HatchStyle result = HatchStyle.DashedHorizontal;
		switch (patternStyle)
		{
		case PatternStyle.Percent05:
			result = HatchStyle.Percent05;
			break;
		case PatternStyle.Percent10:
			result = HatchStyle.Percent10;
			break;
		case PatternStyle.Percent20:
			result = HatchStyle.Percent20;
			break;
		case PatternStyle.Percent25:
			result = HatchStyle.Percent25;
			break;
		case PatternStyle.Percent30:
			result = HatchStyle.Percent30;
			break;
		case PatternStyle.Percent40:
			result = HatchStyle.Percent40;
			break;
		case PatternStyle.Percent50:
			result = HatchStyle.Percent50;
			break;
		case PatternStyle.Percent60:
			result = HatchStyle.Percent60;
			break;
		case PatternStyle.Percent70:
			result = HatchStyle.Percent70;
			break;
		case PatternStyle.Percent75:
			result = HatchStyle.Percent75;
			break;
		case PatternStyle.Percent80:
			result = HatchStyle.Percent80;
			break;
		case PatternStyle.Percent90:
			result = HatchStyle.Percent90;
			break;
		case PatternStyle.DarkHorizontal:
			result = HatchStyle.DarkHorizontal;
			break;
		case PatternStyle.DarkVertical:
			result = HatchStyle.DarkVertical;
			break;
		case PatternStyle.DarkDownwardDiagonal:
			result = HatchStyle.DarkDownwardDiagonal;
			break;
		case PatternStyle.DarkUpwardDiagonal:
			result = HatchStyle.DarkUpwardDiagonal;
			break;
		case PatternStyle.SmallCheckerBoard:
			result = HatchStyle.SmallCheckerBoard;
			break;
		case PatternStyle.Trellis:
			result = HatchStyle.Trellis;
			break;
		case PatternStyle.LightHorizontal:
			result = HatchStyle.LightHorizontal;
			break;
		case PatternStyle.LightVertical:
			result = HatchStyle.LightVertical;
			break;
		case PatternStyle.LightDownwardDiagonal:
			result = HatchStyle.LightDownwardDiagonal;
			break;
		case PatternStyle.LightUpwardDiagonal:
			result = HatchStyle.LightUpwardDiagonal;
			break;
		case PatternStyle.SmallGrid:
			result = HatchStyle.SmallGrid;
			break;
		case PatternStyle.DottedDiamond:
			result = HatchStyle.DottedDiamond;
			break;
		case PatternStyle.WideDownwardDiagonal:
			result = HatchStyle.WideDownwardDiagonal;
			break;
		case PatternStyle.WideUpwardDiagonal:
			result = HatchStyle.WideUpwardDiagonal;
			break;
		case PatternStyle.DashedDownwardDiagonal:
			result = HatchStyle.DashedDownwardDiagonal;
			break;
		case PatternStyle.DashedUpwardDiagonal:
			result = HatchStyle.DashedUpwardDiagonal;
			break;
		case PatternStyle.NarrowVertical:
			result = HatchStyle.Horizontal;
			break;
		case PatternStyle.NarrowHorizontal:
			result = HatchStyle.Cross;
			break;
		case PatternStyle.DashedVertical:
			result = HatchStyle.DashedVertical;
			break;
		case PatternStyle.DashedHorizontal:
			result = HatchStyle.DashedHorizontal;
			break;
		case PatternStyle.LargeConfetti:
			result = HatchStyle.LargeConfetti;
			break;
		case PatternStyle.LargeGrid:
			result = HatchStyle.Cross;
			break;
		case PatternStyle.HorizontalBrick:
			result = HatchStyle.HorizontalBrick;
			break;
		case PatternStyle.LargeCheckerBoard:
			result = HatchStyle.LargeCheckerBoard;
			break;
		case PatternStyle.SmallConfetti:
			result = HatchStyle.SmallConfetti;
			break;
		case PatternStyle.SolidDiamond:
			result = HatchStyle.SolidDiamond;
			break;
		case PatternStyle.DiagonalBrick:
			result = HatchStyle.DiagonalBrick;
			break;
		case PatternStyle.OutlinedDiamond:
			result = HatchStyle.OutlinedDiamond;
			break;
		case PatternStyle.Plaid:
			result = HatchStyle.Plaid;
			break;
		case PatternStyle.Sphere:
			result = HatchStyle.Sphere;
			break;
		case PatternStyle.Weave:
			result = HatchStyle.Weave;
			break;
		case PatternStyle.DottedGrid:
			result = HatchStyle.DottedGrid;
			break;
		case PatternStyle.Divot:
			result = HatchStyle.Divot;
			break;
		case PatternStyle.Shingle:
			result = HatchStyle.Shingle;
			break;
		case PatternStyle.Wave:
			result = HatchStyle.Wave;
			break;
		case PatternStyle.Horizontal:
			result = HatchStyle.Horizontal;
			break;
		case PatternStyle.Vertical:
			result = HatchStyle.Vertical;
			break;
		case PatternStyle.Cross:
			result = HatchStyle.Cross;
			break;
		case PatternStyle.DownwardDiagonal:
			result = HatchStyle.ForwardDiagonal;
			break;
		case PatternStyle.UpwardDiagonal:
			result = HatchStyle.LightUpwardDiagonal;
			break;
		case PatternStyle.DiagonalCross:
			result = HatchStyle.DiagonalCross;
			break;
		}
		return result;
	}
}
