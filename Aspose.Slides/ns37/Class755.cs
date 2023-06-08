using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using ns36;
using ns38;

namespace ns37;

internal class Class755 : ICloneable, Interface18
{
	private Class740 class740_0;

	private Enum145 enum145_0;

	private Color color_0;

	private Class754 class754_0;

	private FillType fillType_0;

	private bool bool_0;

	private bool bool_1 = true;

	private Class771 class771_0;

	private bool bool_2 = true;

	internal Class740 Chart => class740_0;

	public Color Color
	{
		get
		{
			if (fillType_0 == FillType.NoFill)
			{
				return Color.Empty;
			}
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Class754 LineStyleInternal
	{
		get
		{
			return class754_0;
		}
		set
		{
			class754_0 = value;
		}
	}

	public Interface17 LineStyle => class754_0;

	public bool IsVisible
	{
		get
		{
			if (fillType_0 == FillType.NoFill)
			{
				return false;
			}
			return true;
		}
	}

	internal int Width
	{
		get
		{
			if (Formatting == FillType.NoFill)
			{
				return 0;
			}
			int num = Struct41.smethod_4(class754_0.Width);
			if (num < 1)
			{
				num = 1;
			}
			return num;
		}
	}

	public FillType Formatting
	{
		get
		{
			return fillType_0;
		}
		set
		{
			if (value != FillType.Gradient)
			{
				class771_0 = null;
			}
			fillType_0 = value;
		}
	}

	internal Class771 GradientFillInernal
	{
		get
		{
			return class771_0;
		}
		set
		{
			class771_0 = value;
		}
	}

	public Interface26 GradientFill
	{
		get
		{
			if (class771_0 == null)
			{
				class771_0 = new Class771();
				Formatting = FillType.Gradient;
			}
			return class771_0;
		}
	}

	internal bool IsWeightChanaged
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool IsColorAuto
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	internal Class755(Class740 chart, Enum145 lineParentType)
	{
		fillType_0 = FillType.NotDefined;
		class740_0 = chart;
		enum145_0 = lineParentType;
		color_0 = Color.Empty;
		class754_0 = new Class754();
		bool_0 = false;
	}

	public bool method_0(Class755 other)
	{
		if (IsVisible != other.IsVisible)
		{
			return false;
		}
		if (IsVisible && other.IsVisible)
		{
			if (Formatting != other.Formatting)
			{
				return false;
			}
			if (Formatting == FillType.Gradient)
			{
				if (!GradientFillInernal.method_3(other.GradientFillInernal))
				{
					return false;
				}
			}
			else
			{
				if (!Color.Equals(other.Color))
				{
					return false;
				}
				if (!class754_0.method_0(other.LineStyleInternal))
				{
					return false;
				}
			}
		}
		return true;
	}

	internal void method_1(Color color)
	{
		if ((bool_1 && fillType_0 != 0) || fillType_0 == FillType.NotDefined)
		{
			Color = color;
		}
	}

	internal void method_2()
	{
		if (!bool_2 || !bool_1)
		{
			return;
		}
		switch (enum145_0)
		{
		case Enum145.const_3:
			if (class740_0.StyleIndex <= 32)
			{
				color_0 = class740_0.Themes.ThemeColors.method_3("tx1");
				color_0 = class740_0.Themes.ThemeColors.method_7(color_0, 0.5);
				color_0 = Color.FromArgb(255, color_0);
			}
			else if (class740_0.StyleIndex <= 40)
			{
				color_0 = class740_0.Themes.ThemeColors.method_3("dk1");
				color_0 = class740_0.Themes.ThemeColors.method_7(color_0, 0.5);
				color_0 = Color.FromArgb(255, color_0);
			}
			else
			{
				color_0 = class740_0.Themes.ThemeColors.method_3("dk1");
				color_0 = class740_0.Themes.ThemeColors.method_7(color_0, 0.9);
				color_0 = Color.FromArgb(255, color_0);
			}
			break;
		case Enum145.const_6:
			color_0 = Color.Empty;
			break;
		case Enum145.const_0:
		case Enum145.const_2:
		case Enum145.const_4:
		case Enum145.const_5:
		case Enum145.const_13:
			if (class740_0.StyleIndex <= 32)
			{
				color_0 = class740_0.Themes.ThemeColors.method_3("tx1");
				color_0 = class740_0.Themes.ThemeColors.method_7(color_0, 0.75);
				color_0 = Color.FromArgb(255, color_0);
			}
			else
			{
				color_0 = class740_0.Themes.ThemeColors.method_3("dk1");
				color_0 = class740_0.Themes.ThemeColors.method_7(color_0, 0.75);
				color_0 = Color.FromArgb(255, color_0);
			}
			break;
		case Enum145.const_1:
		case Enum145.const_10:
		case Enum145.const_11:
		case Enum145.const_12:
		case Enum145.const_14:
		case Enum145.const_15:
			color_0 = Color.Empty;
			break;
		case Enum145.const_16:
		case Enum145.const_17:
			if (class740_0.StyleIndex <= 16)
			{
				color_0 = class740_0.Themes.ThemeColors.method_3("tx1");
				color_0 = Color.FromArgb(255, color_0);
			}
			else if (class740_0.StyleIndex <= 32)
			{
				color_0 = Color.Empty;
			}
			else if (class740_0.StyleIndex <= 34)
			{
				color_0 = class740_0.Themes.ThemeColors.method_3("dk1");
				color_0 = Color.FromArgb(255, color_0);
			}
			else if (class740_0.StyleIndex <= 40)
			{
				int num = class740_0.StyleIndex - 34;
				color_0 = class740_0.Themes.ThemeColors.method_3("accent" + num);
				color_0 = class740_0.Themes.ThemeColors.method_8(color_0, 0.25);
				color_0 = Color.FromArgb(255, color_0);
			}
			else
			{
				color_0 = Color.Empty;
			}
			break;
		case Enum145.const_18:
		case Enum145.const_19:
		case Enum145.const_20:
		case Enum145.const_21:
		case Enum145.const_22:
		case Enum145.const_23:
			if (class740_0.StyleIndex <= 32)
			{
				color_0 = class740_0.Themes.ThemeColors.method_3("tx1");
				color_0 = Color.FromArgb(255, color_0);
			}
			else if (class740_0.StyleIndex <= 34)
			{
				color_0 = class740_0.Themes.ThemeColors.method_3("dk1");
				color_0 = Color.FromArgb(255, color_0);
			}
			else if (class740_0.StyleIndex <= 40)
			{
				color_0 = class740_0.Themes.ThemeColors.method_3("dk1");
				color_0 = Color.FromArgb(255, color_0);
			}
			else
			{
				color_0 = class740_0.Themes.ThemeColors.method_3("lt1");
				color_0 = Color.FromArgb(255, color_0);
			}
			break;
		}
		bool_2 = false;
	}

	public object Clone()
	{
		Class755 @class = new Class755(class740_0, enum145_0);
		method_2();
		@class.Color = Color;
		@class.IsColorAuto = IsColorAuto;
		@class.LineStyleInternal = (Class754)LineStyleInternal.Clone();
		@class.Formatting = Formatting;
		@class.GradientFillInernal = class771_0;
		return @class;
	}

	internal void method_3(float x1, float y1, float x2, float y2)
	{
		method_5(new PointF(x1, y1), new PointF(x2, y2));
	}

	internal void method_4(Point point1, Point point2)
	{
		method_5(new PointF(point1.X, point1.Y), new PointF(point2.X, point2.Y));
	}

	internal void method_5(PointF point1, PointF point2)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(point1, point2);
		method_8(graphicsPath);
	}

	internal void method_6(Rectangle rect)
	{
		RectangleF rect2 = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		method_7(rect2);
	}

	internal void method_7(RectangleF rect)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		method_8(graphicsPath);
	}

	internal void method_8(GraphicsPath path)
	{
		method_2();
		if (method_14())
		{
			GraphicsPath path2 = (GraphicsPath)path.Clone();
			Pen pen = method_9(path);
			class740_0.Graphics.imethod_45(pen, path2);
			pen.Dispose();
		}
	}

	internal Pen method_9(GraphicsPath path)
	{
		method_2();
		if (!method_14())
		{
			return new Pen(Color.Empty);
		}
		Pen pen = method_10();
		FillType formatting = Formatting;
		if (formatting == FillType.Gradient)
		{
			if (GradientFill != null)
			{
				Brush brush = GradientFillInernal.method_0(path, pen, isColorReserved: false, 1f);
				Pen pen2 = new Pen(brush, Width);
				method_11(pen2);
				return pen2;
			}
			return pen;
		}
		return pen;
	}

	private Pen method_10()
	{
		if (!method_14())
		{
			return new Pen(Color.Empty);
		}
		Pen pen = (pen = new Pen(Color, Width));
		method_11(pen);
		return pen;
	}

	private void method_11(Pen pen)
	{
		Class754 lineStyleInternal = LineStyleInternal;
		pen.DashCap = DashCap.Round;
		switch (lineStyleInternal.DashStyle)
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
		switch (lineStyleInternal.Compound)
		{
		case Enum155.const_1:
			pen.CompoundArray = new float[6]
			{
				0f,
				1f / 6f,
				1f / 3f,
				2f / 3f,
				5f / 6f,
				1f
			};
			break;
		case Enum155.const_2:
			pen.CompoundArray = new float[4] { 0f, 0.2f, 0.4f, 1f };
			break;
		case Enum155.const_3:
			pen.CompoundArray = new float[4] { 0f, 0.6f, 0.8f, 1f };
			break;
		case Enum155.const_4:
			pen.CompoundArray = new float[4]
			{
				0f,
				1f / 3f,
				2f / 3f,
				1f
			};
			break;
		}
		method_12(pen, lineStyleInternal);
	}

	private void method_12(Pen pen, Class754 lineStyle)
	{
		if (lineStyle.BeginheadStyle != 0)
		{
			method_13(pen, lineStyle.BeginheadStyle, lineStyle.BeginheadWidth, lineStyle.BeginheadLength, isStart: true);
		}
		if (lineStyle.EndheadStyle != 0)
		{
			method_13(pen, lineStyle.EndheadStyle, lineStyle.EndheadWidth, lineStyle.EndheadLength, isStart: false);
		}
	}

	private void method_13(Pen pen, Enum147 headStyle, Enum148 headWidth, Enum146 headLength, bool isStart)
	{
		float num = 0f;
		float num2 = 0f;
		num = headWidth switch
		{
			Enum148.const_0 => 2f, 
			Enum148.const_1 => 3f, 
			_ => 5f, 
		};
		num2 = headLength switch
		{
			Enum146.const_0 => 2f, 
			Enum146.const_1 => 3f, 
			_ => 5f, 
		};
		switch (headStyle)
		{
		case Enum147.const_1:
		{
			AdjustableArrowCap adjustableArrowCap = new AdjustableArrowCap(num, num2);
			if (isStart)
			{
				pen.CustomStartCap = adjustableArrowCap;
			}
			else
			{
				pen.CustomEndCap = adjustableArrowCap;
			}
			break;
		}
		case Enum147.const_2:
		{
			AdjustableArrowCap adjustableArrowCap = new AdjustableArrowCap(num, num2);
			adjustableArrowCap.MiddleInset = 0.9f;
			if (isStart)
			{
				pen.CustomStartCap = adjustableArrowCap;
			}
			else
			{
				pen.CustomEndCap = adjustableArrowCap;
			}
			break;
		}
		case Enum147.const_3:
			if (isStart)
			{
				pen.StartCap = LineCap.DiamondAnchor;
			}
			else
			{
				pen.EndCap = LineCap.DiamondAnchor;
			}
			break;
		case Enum147.const_4:
			if (isStart)
			{
				pen.StartCap = LineCap.RoundAnchor;
			}
			else
			{
				pen.EndCap = LineCap.RoundAnchor;
			}
			break;
		case Enum147.const_5:
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(new PointF(num / 2f, 0f - num2), new PointF(0f, 0f));
			graphicsPath.AddLine(new PointF((0f - num) / 2f, 0f - num2), new PointF(0f, 0f));
			CustomLineCap customLineCap = new CustomLineCap(null, graphicsPath);
			customLineCap.BaseCap = LineCap.Flat;
			customLineCap.StrokeJoin = LineJoin.Round;
			customLineCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
			if (isStart)
			{
				pen.CustomStartCap = customLineCap;
			}
			else
			{
				pen.CustomEndCap = customLineCap;
			}
			break;
		}
		}
	}

	internal bool method_14()
	{
		if (!IsVisible)
		{
			return false;
		}
		if (Width <= 0)
		{
			return false;
		}
		if (!Color.IsEmpty && Color.A != 0)
		{
			return true;
		}
		return false;
	}
}
