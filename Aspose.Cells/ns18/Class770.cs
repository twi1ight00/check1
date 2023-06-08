using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class770
{
	public Color color_0;

	public float float_0;

	public LineCap lineCap_0;

	public LineCap lineCap_1;

	public DashCap dashCap_0;

	public LineJoin lineJoin_0;

	public DashStyle dashStyle_0;

	private float[] float_1;

	public float float_2;

	public PenType penType_0;

	public Brush brush_0;

	public float float_3;

	public bool bool_0 = true;

	internal static Pen smethod_0(Class770 class770_0)
	{
		Pen pen = null;
		pen = ((class770_0.penType_0 != 0) ? new Pen(class770_0.brush_0) : new Pen(class770_0.color_0));
		pen.Width = class770_0.float_0;
		pen.StartCap = class770_0.lineCap_0;
		pen.EndCap = class770_0.lineCap_1;
		pen.DashCap = class770_0.dashCap_0;
		pen.DashOffset = class770_0.float_3;
		pen.DashStyle = class770_0.dashStyle_0;
		if (class770_0.dashStyle_0 != 0)
		{
			pen.DashPattern = class770_0.method_0();
		}
		return pen;
	}

	public static Class770 smethod_1(Pen pen_0)
	{
		Class770 @class = null;
		if (pen_0 == null)
		{
			return null;
		}
		try
		{
			@class = ((pen_0.PenType != 0) ? new Class770(pen_0.Brush, pen_0.Width) : new Class770(pen_0.Color, pen_0.Width));
			if (pen_0.Brush != null)
			{
				@class.brush_0 = pen_0.Brush;
			}
			@class.lineCap_0 = pen_0.StartCap;
			@class.lineCap_1 = pen_0.EndCap;
			@class.dashCap_0 = pen_0.DashCap;
			@class.float_3 = pen_0.DashOffset;
			if (pen_0.DashStyle != 0)
			{
				@class.method_1(pen_0.DashPattern);
			}
			@class.dashStyle_0 = pen_0.DashStyle;
			@class.lineJoin_0 = pen_0.LineJoin;
			@class.float_2 = pen_0.MiterLimit;
			@class.penType_0 = pen_0.PenType;
		}
		catch
		{
		}
		return @class;
	}

	public Class770(Brush brush_1, float float_4)
	{
		brush_0 = brush_1;
		float_0 = float_4;
		lineCap_0 = LineCap.Flat;
		lineCap_1 = LineCap.Flat;
		dashCap_0 = DashCap.Flat;
		lineJoin_0 = LineJoin.Miter;
		dashStyle_0 = DashStyle.Solid;
		method_1(null);
		float_2 = 1f;
		penType_0 = PenType.SolidColor;
		float_3 = 0f;
	}

	public Class770(Color color_1, float float_4)
	{
		color_0 = color_1;
		float_0 = float_4;
		lineCap_0 = LineCap.Flat;
		lineCap_1 = LineCap.Flat;
		dashCap_0 = DashCap.Flat;
		lineJoin_0 = LineJoin.Miter;
		dashStyle_0 = DashStyle.Solid;
		method_1(null);
		float_2 = 1f;
		penType_0 = PenType.SolidColor;
		brush_0 = null;
		float_3 = 0f;
	}

	public Class770(Color color_1)
	{
		color_0 = color_1;
		float_0 = 1f;
		lineCap_0 = LineCap.Flat;
		lineCap_1 = LineCap.Flat;
		dashCap_0 = DashCap.Flat;
		lineJoin_0 = LineJoin.Miter;
		dashStyle_0 = DashStyle.Solid;
		method_1(null);
		float_2 = 1f;
		penType_0 = PenType.SolidColor;
		brush_0 = null;
		float_3 = 0f;
	}

	[SpecialName]
	public float[] method_0()
	{
		return float_1;
	}

	[SpecialName]
	public void method_1(float[] float_4)
	{
		if (float_4 != null)
		{
			float_1 = float_4;
			dashStyle_0 = DashStyle.Custom;
		}
	}

	internal void method_2(LineCap lineCap_2, LineCap lineCap_3, DashCap dashCap_1)
	{
		lineCap_0 = lineCap_2;
		lineCap_1 = lineCap_3;
		dashCap_0 = dashCap_1;
	}
}
