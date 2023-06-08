using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using ns224;
using ns33;

namespace ns4;

internal sealed class Class66 : ICloneable
{
	private static PointF[] pointF_0 = new PointF[4]
	{
		new PointF(0f, 0f),
		new PointF(-5f, -10f),
		new PointF(5f, -10f),
		new PointF(0f, 0f)
	};

	private static PointF[] pointF_1 = new PointF[5]
	{
		new PointF(0f, -6f),
		new PointF(5f, -10f),
		new PointF(0f, 0f),
		new PointF(-5f, -10f),
		new PointF(0f, -6f)
	};

	private static PointF[] pointF_2 = new PointF[5]
	{
		new PointF(-5f, 0f),
		new PointF(0f, -5f),
		new PointF(5f, 0f),
		new PointF(0f, 5f),
		new PointF(-5f, 0f)
	};

	private static float[] float_0 = new float[3] { 1.25f, 1.75f, 2.5f };

	private static float[] float_1 = new float[3] { 2f, 3f, 4.5f };

	internal static readonly float[] float_2 = new float[6]
	{
		0f,
		1f / 6f,
		1f / 3f,
		2f / 3f,
		5f / 6f,
		1f
	};

	internal static readonly float[] float_3 = new float[4] { 0f, 0.6f, 0.8f, 1f };

	internal static readonly float[] float_4 = new float[4] { 0f, 0.2f, 0.4f, 1f };

	internal static readonly float[] float_5 = new float[4]
	{
		0f,
		1f / 3f,
		2f / 3f,
		1f
	};

	internal float float_6 = 576f;

	private double double_0;

	private LineStyle lineStyle_0;

	private short short_0;

	internal Class63 class63_0;

	internal bool bool_0;

	private LineDashStyle lineDashStyle_0;

	private LineArrowheadStyle lineArrowheadStyle_0;

	private LineArrowheadStyle lineArrowheadStyle_1;

	private LineArrowheadLength lineArrowheadLength_0;

	private LineArrowheadLength lineArrowheadLength_1;

	private LineArrowheadWidth lineArrowheadWidth_0;

	private LineArrowheadWidth lineArrowheadWidth_1;

	private float[] float_7;

	private LineJoinStyle lineJoinStyle_0;

	private LineCapStyle lineCapStyle_0;

	internal static readonly Class1155 class1155_0 = new Class1155(LineJoinStyle.Bevel, LineJoin.Bevel, LineJoinStyle.Miter, LineJoin.Miter, LineJoinStyle.Round, LineJoin.Round);

	public double Width
	{
		get
		{
			if (double_0 < 0.0)
			{
				return 1.0;
			}
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public LineStyle LineStyle
	{
		get
		{
			if (lineStyle_0 == LineStyle.NotDefined)
			{
				return LineStyle.Single;
			}
			return lineStyle_0;
		}
		set
		{
			lineStyle_0 = value;
		}
	}

	public LineDashStyle DashStyle
	{
		get
		{
			if (lineDashStyle_0 == LineDashStyle.NotDefined)
			{
				return LineDashStyle.Solid;
			}
			return lineDashStyle_0;
		}
		set
		{
			lineDashStyle_0 = value;
		}
	}

	public LineCapStyle CapStyle
	{
		get
		{
			if (lineCapStyle_0 != LineCapStyle.NotDefined)
			{
				return lineCapStyle_0;
			}
			return LineCapStyle.Flat;
		}
		set
		{
			lineCapStyle_0 = value;
		}
	}

	public LineJoinStyle JoinStyleEx
	{
		get
		{
			if (lineJoinStyle_0 != LineJoinStyle.NotDefined)
			{
				return lineJoinStyle_0;
			}
			return LineJoinStyle.Round;
		}
		set
		{
			lineJoinStyle_0 = value;
		}
	}

	public bool ShowLines
	{
		get
		{
			if (short_0 < 0)
			{
				return class63_0.FillType != FillType.NoFill;
			}
			return short_0 != 0;
		}
		set
		{
			short_0 = (short)(value ? 1 : 0);
		}
	}

	public Color ForeColor
	{
		get
		{
			return class63_0.ForeColor;
		}
		set
		{
			class63_0 = new Class63(value);
		}
	}

	public LineArrowheadStyle BeginArrowheadStyle
	{
		get
		{
			if (lineArrowheadStyle_0 != LineArrowheadStyle.NotDefined)
			{
				return lineArrowheadStyle_0;
			}
			return LineArrowheadStyle.None;
		}
		set
		{
			lineArrowheadStyle_0 = value;
		}
	}

	public LineArrowheadStyle EndArrowheadStyle
	{
		get
		{
			if (lineArrowheadStyle_1 != LineArrowheadStyle.NotDefined)
			{
				return lineArrowheadStyle_1;
			}
			return LineArrowheadStyle.None;
		}
		set
		{
			lineArrowheadStyle_1 = value;
		}
	}

	public LineArrowheadLength BeginArrowheadLength
	{
		get
		{
			if (lineArrowheadLength_0 != LineArrowheadLength.NotDefined)
			{
				return lineArrowheadLength_0;
			}
			return LineArrowheadLength.Medium;
		}
		set
		{
			lineArrowheadLength_0 = value;
		}
	}

	public LineArrowheadLength EndArrowheadLength
	{
		get
		{
			if (lineArrowheadLength_1 != LineArrowheadLength.NotDefined)
			{
				return lineArrowheadLength_1;
			}
			return LineArrowheadLength.Medium;
		}
		set
		{
			lineArrowheadLength_1 = value;
		}
	}

	public LineArrowheadWidth BeginArrowheadWidth
	{
		get
		{
			if (lineArrowheadWidth_0 != LineArrowheadWidth.NotDefined)
			{
				return lineArrowheadWidth_0;
			}
			return LineArrowheadWidth.Medium;
		}
		set
		{
			lineArrowheadWidth_0 = value;
		}
	}

	public LineArrowheadWidth EndArrowheadWidth
	{
		get
		{
			if (lineArrowheadWidth_1 != LineArrowheadWidth.NotDefined)
			{
				return lineArrowheadWidth_1;
			}
			return LineArrowheadWidth.Medium;
		}
		set
		{
			lineArrowheadWidth_1 = value;
		}
	}

	public Class66(Class66 lineparam)
	{
		float_6 = lineparam.float_6;
		double_0 = lineparam.double_0;
		lineStyle_0 = lineparam.lineStyle_0;
		short_0 = lineparam.short_0;
		lineJoinStyle_0 = lineparam.lineJoinStyle_0;
		lineCapStyle_0 = lineparam.lineCapStyle_0;
		class63_0 = lineparam.class63_0;
		bool_0 = lineparam.bool_0;
		lineDashStyle_0 = lineparam.lineDashStyle_0;
		lineArrowheadStyle_0 = lineparam.lineArrowheadStyle_0;
		lineArrowheadStyle_1 = lineparam.lineArrowheadStyle_1;
		lineArrowheadLength_0 = lineparam.lineArrowheadLength_0;
		lineArrowheadLength_1 = lineparam.lineArrowheadLength_1;
		lineArrowheadWidth_0 = lineparam.lineArrowheadWidth_0;
		lineArrowheadWidth_1 = lineparam.lineArrowheadWidth_1;
	}

	public Class66(Color color, float width)
	{
		lineArrowheadLength_1 = LineArrowheadLength.NotDefined;
		lineArrowheadLength_0 = LineArrowheadLength.NotDefined;
		lineArrowheadWidth_1 = LineArrowheadWidth.NotDefined;
		lineArrowheadWidth_0 = LineArrowheadWidth.NotDefined;
		double_0 = width;
		class63_0 = new Class63(color);
		lineStyle_0 = LineStyle.Single;
		short_0 = 1;
		lineDashStyle_0 = LineDashStyle.Solid;
		lineArrowheadStyle_1 = LineArrowheadStyle.None;
		lineArrowheadStyle_0 = LineArrowheadStyle.None;
		lineCapStyle_0 = LineCapStyle.Flat;
		lineJoinStyle_0 = LineJoinStyle.Round;
	}

	public Class66(Class67 arguments, params ILineParamSource[] lineFormats)
	{
		Initialize(arguments, lineFormats);
	}

	private void Initialize(Class67 arguments, ILineParamSource[] lineParamSources)
	{
		double_0 = -1.0;
		lineStyle_0 = LineStyle.NotDefined;
		lineCapStyle_0 = LineCapStyle.NotDefined;
		lineJoinStyle_0 = LineJoinStyle.NotDefined;
		short_0 = -1;
		class63_0 = new Class63(arguments);
		lineArrowheadStyle_1 = LineArrowheadStyle.NotDefined;
		lineArrowheadStyle_0 = LineArrowheadStyle.NotDefined;
		lineArrowheadLength_1 = LineArrowheadLength.NotDefined;
		lineArrowheadLength_0 = LineArrowheadLength.NotDefined;
		lineArrowheadWidth_1 = LineArrowheadWidth.NotDefined;
		lineArrowheadWidth_0 = LineArrowheadWidth.NotDefined;
		lineDashStyle_0 = LineDashStyle.NotDefined;
		float_6 = 72f;
		FloatColor styleColor = null;
		foreach (ILineParamSource lineParamSource in lineParamSources)
		{
			method_2(arguments, ref styleColor, lineParamSource);
		}
	}

	internal Class66 method_0(Class67 arguments, params ILineParamSource[] lineprops)
	{
		Class66 @class = (Class66)Clone();
		if (lineprops != null && lineprops.Length != 0)
		{
			FloatColor styleColor = new FloatColor(0f, 0f, 0f);
			for (int i = 0; i < lineprops.Length; i++)
			{
				@class.method_2(arguments, ref styleColor, lineprops[i]);
			}
		}
		return @class;
	}

	internal Class66 method_1(Class67 arguments, ILineParamSource lineprop)
	{
		Class66 @class = (Class66)Clone();
		if (lineprop != null)
		{
			FloatColor styleColor = new FloatColor(0f, 0f, 0f);
			@class.method_2(arguments, ref styleColor, lineprop);
		}
		return @class;
	}

	private void method_2(Class67 arguments, ref FloatColor styleColor, ILineParamSource lineParamSource)
	{
		if (lineParamSource == null)
		{
			return;
		}
		if (lineParamSource is ILineFormat)
		{
			ILineFormat lineFormat = (ILineFormat)lineParamSource;
			if (lineFormat.Style != LineStyle.NotDefined)
			{
				lineStyle_0 = lineFormat.Style;
			}
			if (lineFormat.BeginArrowheadStyle != LineArrowheadStyle.NotDefined)
			{
				lineArrowheadStyle_0 = lineFormat.BeginArrowheadStyle;
			}
			if (lineFormat.EndArrowheadStyle != LineArrowheadStyle.NotDefined)
			{
				lineArrowheadStyle_1 = lineFormat.EndArrowheadStyle;
			}
			if (lineFormat.BeginArrowheadLength != LineArrowheadLength.NotDefined)
			{
				lineArrowheadLength_0 = lineFormat.BeginArrowheadLength;
			}
			if (lineFormat.EndArrowheadLength != LineArrowheadLength.NotDefined)
			{
				lineArrowheadLength_1 = lineFormat.EndArrowheadLength;
			}
			if (lineFormat.BeginArrowheadWidth != LineArrowheadWidth.NotDefined)
			{
				lineArrowheadWidth_0 = lineFormat.BeginArrowheadWidth;
			}
			if (lineFormat.EndArrowheadWidth != LineArrowheadWidth.NotDefined)
			{
				lineArrowheadWidth_1 = lineFormat.EndArrowheadWidth;
			}
			if (lineFormat.CapStyle != LineCapStyle.NotDefined)
			{
				lineCapStyle_0 = lineFormat.CapStyle;
			}
			if (lineFormat.JoinStyle != LineJoinStyle.NotDefined)
			{
				lineJoinStyle_0 = lineFormat.JoinStyle;
			}
			if (lineFormat.DashStyle != LineDashStyle.NotDefined)
			{
				DashStyle = lineFormat.DashStyle;
				if (lineFormat.DashStyle == LineDashStyle.Custom)
				{
					float_7 = lineFormat.CustomDashPattern;
				}
			}
			class63_0.method_3(arguments, ref styleColor, lineFormat.FillFormat);
			if (!double.IsNaN(lineFormat.Width))
			{
				double_0 = lineFormat.Width;
			}
		}
		else if (lineParamSource is Class512)
		{
			Class512 @class = (Class512)lineParamSource;
			if (@class.floatColor_0 != null)
			{
				styleColor = @class.floatColor_0;
			}
			method_2(arguments, ref styleColor, @class.lineFormat_0);
		}
	}

	internal Class6003 method_3()
	{
		return method_4(float_6);
	}

	internal Class6003 method_4(float dpi)
	{
		Class5990 brush = class63_0.method_5();
		Class6003 @class = new Class6003(brush, (float)Width * dpi / 72f);
		@class.DashCap = ((CapStyle == LineCapStyle.Round) ? DashCap.Round : DashCap.Flat);
		@class.LineJoin = (LineJoin)class1155_0[JoinStyleEx];
		@class.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
		switch (LineStyle)
		{
		case LineStyle.ThinThin:
			@class.CompoundArray = float_5;
			break;
		case LineStyle.ThickThin:
			@class.CompoundArray = (bool_0 ? float_3 : float_4);
			break;
		case LineStyle.ThinThick:
			@class.CompoundArray = (bool_0 ? float_4 : float_3);
			break;
		case LineStyle.ThickBetweenThin:
			@class.CompoundArray = float_2;
			break;
		}
		switch (DashStyle)
		{
		case LineDashStyle.Dot:
			@class.DashPattern = new float[2] { 1f, 3f };
			break;
		case LineDashStyle.Dash:
			@class.DashPattern = new float[2] { 4f, 3f };
			break;
		case LineDashStyle.LargeDash:
			@class.DashPattern = new float[2] { 8f, 3f };
			break;
		case LineDashStyle.DashDot:
			@class.DashPattern = new float[4] { 4f, 3f, 1f, 3f };
			break;
		case LineDashStyle.LargeDashDot:
			@class.DashPattern = new float[4] { 8f, 3f, 1f, 3f };
			break;
		case LineDashStyle.LargeDashDotDot:
			@class.DashPattern = new float[6] { 8f, 3f, 1f, 3f, 1f, 3f };
			break;
		default:
			@class.DashStyle = method_9();
			break;
		case LineDashStyle.Custom:
			@class.DashPattern = float_7;
			break;
		}
		CustomLineCap customLineCap = method_7();
		CustomLineCap customLineCap2 = method_8();
		if (customLineCap != null)
		{
			@class.StartCap = LineCap.Custom;
		}
		else
		{
			@class.StartCap = LineCap.NoAnchor;
		}
		if (customLineCap2 != null)
		{
			@class.EndCap = LineCap.Custom;
		}
		else
		{
			@class.EndCap = LineCap.NoAnchor;
		}
		return @class;
	}

	internal Pen method_5()
	{
		return method_6(float_6);
	}

	internal Pen method_6(float dpi)
	{
		Brush brush = class63_0.method_9();
		Pen pen = new Pen(brush, (float)Width * dpi / 72f);
		pen.DashCap = ((CapStyle == LineCapStyle.Round) ? DashCap.Round : DashCap.Flat);
		pen.LineJoin = (LineJoin)class1155_0[JoinStyleEx];
		pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
		switch (LineStyle)
		{
		case LineStyle.ThinThin:
			pen.CompoundArray = float_5;
			break;
		case LineStyle.ThickThin:
			pen.CompoundArray = (bool_0 ? float_3 : float_4);
			break;
		case LineStyle.ThinThick:
			pen.CompoundArray = (bool_0 ? float_4 : float_3);
			break;
		case LineStyle.ThickBetweenThin:
			pen.CompoundArray = float_2;
			break;
		}
		switch (DashStyle)
		{
		case LineDashStyle.Dot:
			pen.DashPattern = new float[2] { 1f, 3f };
			break;
		case LineDashStyle.Dash:
			pen.DashPattern = new float[2] { 4f, 3f };
			break;
		case LineDashStyle.LargeDash:
			pen.DashPattern = new float[2] { 8f, 3f };
			break;
		case LineDashStyle.DashDot:
			pen.DashPattern = new float[4] { 4f, 3f, 1f, 3f };
			break;
		case LineDashStyle.LargeDashDot:
			pen.DashPattern = new float[4] { 8f, 3f, 1f, 3f };
			break;
		case LineDashStyle.LargeDashDotDot:
			pen.DashPattern = new float[6] { 8f, 3f, 1f, 3f, 1f, 3f };
			break;
		default:
			pen.DashStyle = method_9();
			break;
		case LineDashStyle.Custom:
			pen.DashPattern = float_7;
			break;
		}
		CustomLineCap customLineCap = method_7();
		CustomLineCap customLineCap2 = method_8();
		if (customLineCap != null)
		{
			pen.StartCap = LineCap.Custom;
			pen.CustomStartCap = customLineCap;
		}
		else
		{
			pen.StartCap = LineCap.NoAnchor;
		}
		if (customLineCap2 != null)
		{
			pen.EndCap = LineCap.Custom;
			pen.CustomEndCap = customLineCap2;
		}
		else
		{
			pen.EndCap = LineCap.NoAnchor;
		}
		return pen;
	}

	internal static CustomLineCap smethod_0(LineArrowheadStyle lineArrowheadStyle, LineArrowheadLength lineArrowheadLength, LineArrowheadWidth lineArrowheadWidth)
	{
		float inset;
		GraphicsPath graphicsPath = smethod_1(lineArrowheadStyle, lineArrowheadLength, lineArrowheadWidth, out inset);
		if (graphicsPath == null)
		{
			return null;
		}
		CustomLineCap customLineCap;
		if (lineArrowheadStyle == LineArrowheadStyle.Open)
		{
			customLineCap = new CustomLineCap(null, graphicsPath, LineCap.Round, inset);
			customLineCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
		}
		else
		{
			customLineCap = new CustomLineCap(graphicsPath, null, LineCap.Triangle, inset);
		}
		return customLineCap;
	}

	internal static GraphicsPath smethod_1(LineArrowheadStyle lineArrowheadStyle, LineArrowheadLength lineArrowheadLength, LineArrowheadWidth lineArrowheadWidth, out float inset)
	{
		inset = 0f;
		if (lineArrowheadStyle == LineArrowheadStyle.None)
		{
			return null;
		}
		GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);
		float num = 1 + (1 << (int)lineArrowheadLength);
		float num2 = 1 + (1 << (int)lineArrowheadWidth);
		float num6;
		switch (lineArrowheadStyle)
		{
		default:
			return null;
		case LineArrowheadStyle.Triangle:
			graphicsPath.AddLines(pointF_0);
			graphicsPath.CloseFigure();
			num6 = 0.9f;
			break;
		case LineArrowheadStyle.Stealth:
			graphicsPath.AddLines(pointF_1);
			graphicsPath.CloseFigure();
			num6 = 0.55f;
			break;
		case LineArrowheadStyle.Diamond:
			graphicsPath.AddLines(pointF_2);
			graphicsPath.CloseFigure();
			num6 = 0.3f;
			break;
		case LineArrowheadStyle.Oval:
			graphicsPath.AddEllipse(-5f, -5f, 10f, 10f);
			graphicsPath.CloseFigure();
			num6 = 0.3f;
			break;
		case LineArrowheadStyle.Open:
		{
			float num3 = float_1[(int)lineArrowheadLength];
			float num4 = float_0[(int)lineArrowheadWidth];
			float num5 = (float)(Math.Sqrt(num4 * num4 + num3 * num3) / 2.0 / (double)num4);
			graphicsPath.AddLine((0f - num4) * 10f / num2, (0f - num5 - num3) * 10f / num, 0f, (0f - num5) * 10f / num);
			graphicsPath.AddLine(0f, (0f - num5) * 10f / num, num4 * 10f / num2, (0f - num5 - num3) * 10f / num);
			num6 = num5 / num;
			break;
		}
		}
		inset = num * num6;
		Matrix matrix = new Matrix();
		matrix.Scale(num2 / 10f, num / 10f);
		graphicsPath.Transform(matrix);
		return graphicsPath;
	}

	internal CustomLineCap method_7()
	{
		return smethod_0(BeginArrowheadStyle, BeginArrowheadLength, BeginArrowheadWidth);
	}

	internal CustomLineCap method_8()
	{
		return smethod_0(EndArrowheadStyle, EndArrowheadLength, EndArrowheadWidth);
	}

	internal DashStyle method_9()
	{
		switch (DashStyle)
		{
		default:
			return System.Drawing.Drawing2D.DashStyle.Solid;
		case LineDashStyle.Dash:
		case LineDashStyle.LargeDash:
		case LineDashStyle.SystemDash:
			return System.Drawing.Drawing2D.DashStyle.Dash;
		case LineDashStyle.Dot:
		case LineDashStyle.SystemDot:
			return System.Drawing.Drawing2D.DashStyle.Dot;
		case LineDashStyle.DashDot:
		case LineDashStyle.LargeDashDot:
		case LineDashStyle.SystemDashDot:
			return System.Drawing.Drawing2D.DashStyle.DashDot;
		case LineDashStyle.LargeDashDotDot:
		case LineDashStyle.SystemDashDotDot:
			return System.Drawing.Drawing2D.DashStyle.DashDotDot;
		}
	}

	public object Clone()
	{
		Class66 @class = (Class66)MemberwiseClone();
		@class.class63_0 = (Class63)class63_0.Clone();
		return @class;
	}
}
