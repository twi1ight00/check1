using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;
using ns250;

namespace ns249;

internal class Class6352 : Class6350
{
	private Interface284 interface284_0;

	private List<Class6361> list_0;

	private bool bool_0;

	private Enum810 enum810_0;

	private Class6364 class6364_0;

	public Enum810 TileFlipMode
	{
		get
		{
			return enum810_0;
		}
		set
		{
			enum810_0 = value;
		}
	}

	public bool RotateWithShape
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

	public List<Class6361> GradientStops
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<Class6361>();
			}
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	public Interface284 Gradient
	{
		get
		{
			if (interface284_0 == null)
			{
				interface284_0 = new Class6362();
			}
			return interface284_0;
		}
		set
		{
			interface284_0 = value;
		}
	}

	public Class6364 TileRectangle
	{
		get
		{
			if (class6364_0 == null)
			{
				class6364_0 = new Class6364();
			}
			return class6364_0;
		}
		set
		{
			class6364_0 = value;
		}
	}

	private bool IsFirstGradientStopShifted
	{
		get
		{
			if (FirstGradientStop != null)
			{
				return FirstGradientStop.Position.Fraction != 0.0;
			}
			return false;
		}
	}

	private bool IsLastGradientStopShifted
	{
		get
		{
			if (LastGradientStop != null)
			{
				return LastGradientStop.Position.Fraction != 1.0;
			}
			return false;
		}
	}

	private Class6361 FirstGradientStop
	{
		get
		{
			if (GradientStops.Count == 0)
			{
				return null;
			}
			return GradientStops[0];
		}
	}

	private Class6361 LastGradientStop
	{
		get
		{
			if (GradientStops.Count == 0)
			{
				return null;
			}
			return GradientStops[GradientStops.Count - 1];
		}
	}

	public override Class5990 vmethod_0(Class6360 brushRenderingContext)
	{
		RectangleF tileRectangle = method_0(brushRenderingContext);
		Class5992 @class = Gradient.imethod_0(tileRectangle, brushRenderingContext, RotateWithShape);
		@class.InterpolationColors = method_1(brushRenderingContext);
		@class.WrapMode = WrapMode.TileFlipXY;
		return @class;
	}

	public override void imethod_0(Interface274 styleColor)
	{
		foreach (Class6361 gradientStop in GradientStops)
		{
			gradientStop.Color.imethod_0(styleColor);
		}
	}

	public override Class6350 Clone()
	{
		Class6352 @class = new Class6352();
		@class.RotateWithShape = RotateWithShape;
		@class.TileFlipMode = TileFlipMode;
		foreach (Class6361 gradientStop in GradientStops)
		{
			@class.GradientStops.Add(gradientStop.Clone());
		}
		@class.Gradient = Gradient.Clone();
		@class.TileRectangle = TileRectangle.Clone();
		return @class;
	}

	public override Class5998 vmethod_1(Class6360 brushRenderingContext)
	{
		return Class5998.class5998_7;
	}

	private RectangleF method_0(Class6360 brushRenderingContext)
	{
		if (class6364_0 != null)
		{
			return TileRectangle.method_0(brushRenderingContext.ShapeBoundingBox);
		}
		return brushRenderingContext.ShapeBoundingBox;
	}

	private Class6000[] method_1(Class6360 brushRenderingContext)
	{
		if (GradientStops.Count == 0)
		{
			return null;
		}
		Class6000[] array = method_3();
		method_5(array, brushRenderingContext);
		method_4(array, brushRenderingContext);
		method_2(array);
		return array;
	}

	private void method_2(Class6000[] interpolationColors)
	{
		if (Gradient.AreColorsInReverseOrder)
		{
			for (int i = 0; (float)i < (float)interpolationColors.Length / 2f; i++)
			{
				Class5998 color = interpolationColors[i].Color;
				int num = interpolationColors.Length - 1 - i;
				interpolationColors[i] = new Class6000(interpolationColors[num].Color, interpolationColors[i].Position);
				interpolationColors[num] = new Class6000(color, interpolationColors[num].Position);
			}
		}
	}

	private Class6000[] method_3()
	{
		int num = GradientStops.Count;
		if (IsFirstGradientStopShifted)
		{
			num++;
		}
		if (IsLastGradientStopShifted)
		{
			num++;
		}
		return new Class6000[num];
	}

	private void method_4(Class6000[] interpolationColors, Class6360 brushRenderingContext)
	{
		int num = (IsFirstGradientStopShifted ? 1 : 0);
		for (int i = 0; i < GradientStops.Count; i++)
		{
			Class6361 @class = GradientStops[i];
			interpolationColors[num + i] = @class.method_0(brushRenderingContext.ThemeProvider, brushRenderingContext.AdditionalColorModifier);
		}
	}

	private void method_5(Class6000[] interpolationColors, Class6360 brushRenderingContext)
	{
		if (IsFirstGradientStopShifted)
		{
			interpolationColors[0] = FirstGradientStop.method_1(0f, brushRenderingContext.ThemeProvider, brushRenderingContext.AdditionalColorModifier);
		}
		if (IsLastGradientStopShifted)
		{
			interpolationColors[interpolationColors.Length - 1] = LastGradientStop.method_1(0f, brushRenderingContext.ThemeProvider, brushRenderingContext.AdditionalColorModifier);
		}
	}
}
