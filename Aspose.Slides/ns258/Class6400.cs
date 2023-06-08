using System;
using System.Drawing.Drawing2D;
using ns224;
using ns249;
using ns250;

namespace ns258;

internal class Class6400 : Interface273, Interface294
{
	private static readonly float[] float_0 = new float[4]
	{
		0f,
		1f / 3f,
		2f / 3f,
		1f
	};

	private static readonly float[] float_1 = new float[2] { 0f, 1f };

	private static readonly float[] float_2 = new float[4] { 0f, 0.6f, 0.8f, 1f };

	private static readonly float[] float_3 = new float[4] { 0f, 0.2f, 0.4f, 1f };

	private static readonly float[] float_4 = new float[6]
	{
		0f,
		1f / 6f,
		1f / 3f,
		2f / 3f,
		5f / 6f,
		1f
	};

	private Enum811 enum811_0;

	private Class6393 class6393_0;

	private Class6350 class6350_0;

	private Class6398 class6398_0;

	private Enum812 enum812_0 = Enum812.const_1;

	private Enum815 enum815_0;

	private Class6399 class6399_0;

	private double double_0;

	public Class6350 Fill
	{
		get
		{
			return class6350_0;
		}
		set
		{
			class6350_0 = value;
		}
	}

	public double Width
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public Enum811 CompoundLineType
	{
		get
		{
			return enum811_0;
		}
		set
		{
			enum811_0 = value;
		}
	}

	public Enum812 LineEndingCapType
	{
		get
		{
			return enum812_0;
		}
		set
		{
			enum812_0 = value;
		}
	}

	public Enum815 StrokeAlignment
	{
		get
		{
			return enum815_0;
		}
		set
		{
			enum815_0 = value;
		}
	}

	public Class6393 Dash
	{
		get
		{
			if (class6393_0 == null)
			{
				class6393_0 = new Class6395();
			}
			return class6393_0;
		}
		set
		{
			class6393_0 = value;
		}
	}

	public Class6399 TailLineEndStyle
	{
		get
		{
			return class6399_0;
		}
		set
		{
			class6399_0 = value;
		}
	}

	public Class6398 HeadLineEndStyle
	{
		get
		{
			return class6398_0;
		}
		set
		{
			class6398_0 = value;
		}
	}

	public Class6003 imethod_1(Class6360 brushRenderingContext)
	{
		Class6400 themeOutline = brushRenderingContext.Style.method_0(brushRenderingContext) as Class6400;
		Class5990 brush = method_1(brushRenderingContext, themeOutline);
		double num = method_2(themeOutline);
		Class6003 @class = new Class6003(brush, (float)num);
		method_4(@class);
		method_3(@class);
		method_0(@class);
		Dash.vmethod_0(@class);
		if (HeadLineEndStyle != null)
		{
			HeadLineEndStyle.vmethod_0(@class);
		}
		if (TailLineEndStyle != null)
		{
			TailLineEndStyle.vmethod_0(@class);
		}
		return @class;
	}

	private void method_0(Class6003 pen)
	{
		switch (StrokeAlignment)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum815.const_0:
			pen.Alignment = Enum747.const_0;
			break;
		case Enum815.const_1:
			pen.Alignment = Enum747.const_1;
			break;
		}
	}

	private Class5990 method_1(Class6360 brushRenderingContext, Class6400 themeOutline)
	{
		Class6350 @class = Fill;
		if (@class == null && themeOutline != null)
		{
			@class = themeOutline.Fill;
		}
		if (@class == null)
		{
			@class = new Class6354();
		}
		return @class.vmethod_0(brushRenderingContext);
	}

	private double method_2(Class6400 themeOutline)
	{
		double width = Width;
		if (width == 0.0 && themeOutline != null)
		{
			width = themeOutline.Width;
		}
		return width;
	}

	public Interface294 Clone()
	{
		Class6400 @class = new Class6400();
		if (Fill != null)
		{
			@class.Fill = Fill.Clone();
		}
		@class.Width = Width;
		if (@class.TailLineEndStyle != null)
		{
			@class.TailLineEndStyle = (Class6399)TailLineEndStyle.Clone();
		}
		if (@class.HeadLineEndStyle != null)
		{
			@class.HeadLineEndStyle = (Class6398)HeadLineEndStyle.Clone();
		}
		@class.StrokeAlignment = StrokeAlignment;
		@class.LineEndingCapType = LineEndingCapType;
		@class.CompoundLineType = CompoundLineType;
		@class.Dash = Dash.Clone();
		return @class;
	}

	private void method_3(Class6003 pen)
	{
		switch (LineEndingCapType)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum812.const_0:
			pen.StartCap = LineCap.Square;
			pen.EndCap = LineCap.Square;
			pen.DashCap = DashCap.Flat;
			break;
		case Enum812.const_1:
			pen.StartCap = LineCap.Flat;
			pen.EndCap = LineCap.Flat;
			pen.DashCap = DashCap.Flat;
			break;
		case Enum812.const_2:
			pen.StartCap = LineCap.Round;
			pen.EndCap = LineCap.Round;
			pen.DashCap = DashCap.Round;
			break;
		}
	}

	private void method_4(Class6003 pen)
	{
		switch (CompoundLineType)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum811.const_0:
			pen.CompoundArray = float_1;
			break;
		case Enum811.const_1:
			pen.CompoundArray = float_0;
			break;
		case Enum811.const_2:
			pen.CompoundArray = float_2;
			break;
		case Enum811.const_3:
			pen.CompoundArray = float_3;
			break;
		case Enum811.const_4:
			pen.CompoundArray = float_4;
			break;
		}
	}

	public void imethod_0(Interface274 styleColor)
	{
		if (Fill != null)
		{
			Fill.imethod_0(styleColor);
		}
	}
}
