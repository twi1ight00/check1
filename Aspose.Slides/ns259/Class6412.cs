using System;
using System.Drawing;
using ns224;
using ns235;
using ns249;
using ns251;
using ns256;
using ns258;

namespace ns259;

internal class Class6412 : Interface296
{
	private Class6360 class6360_0;

	private PointF pointF_0 = PointF.Empty;

	private Class6350 class6350_0;

	private Interface288 interface288_0;

	private Interface294 interface294_0;

	private double double_0;

	private double double_1;

	private bool bool_0;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	public double ShapeWidth => double_3;

	public double ShapeHeight => double_2;

	public double PathWidth => double_1;

	public double PathHeight => double_0;

	public PointF CurrentPoint
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	public Interface288 GuideValueProvider => interface288_0;

	public Class6360 BrushRenderingContext => class6360_0;

	public bool IsPictureRenderingMode
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

	public Class6412(double shapeWidth, double shapeHeight, Interface294 outline, Class6350 fill, Class6360 brushRenderingContext, Interface288 guideValueProvider)
	{
		double_3 = shapeWidth;
		double_2 = shapeHeight;
		interface294_0 = outline;
		class6350_0 = fill;
		class6360_0 = brushRenderingContext;
		interface288_0 = guideValueProvider;
	}

	public void imethod_2(double pathWidth, double pathHeight)
	{
		double_1 = ((pathWidth == -1.0) ? double_3 : pathWidth);
		double_0 = ((pathHeight == -1.0) ? double_2 : pathHeight);
		if (PathWidth <= 0.0)
		{
			throw new ArgumentOutOfRangeException("pathWidth");
		}
		if (PathHeight <= 0.0)
		{
			throw new ArgumentOutOfRangeException("pathHeight");
		}
		double_4 = ShapeWidth / PathWidth;
		double_5 = ShapeHeight / PathHeight;
		CurrentPoint = PointF.Empty;
	}

	public PointF imethod_0(Class6410 point)
	{
		return new PointF((float)imethod_1(point.X, isXCoordinate: true), (float)imethod_1(point.Y, isXCoordinate: false));
	}

	public double imethod_1(Class6403 coordinate, bool isXCoordinate)
	{
		return Math.Round(coordinate.method_0(GuideValueProvider) * (isXCoordinate ? double_4 : double_5));
	}

	public Class6003 imethod_3()
	{
		Class6003 @class = interface294_0.imethod_1(BrushRenderingContext);
		if (IsPictureRenderingMode)
		{
			@class.Alignment = Enum747.const_2;
		}
		return @class;
	}

	public Class5990 imethod_4(Interface275 modifier, Class6217 path)
	{
		Interface275 additionalColorModifier = BrushRenderingContext.AdditionalColorModifier;
		Class6217 currentPath = BrushRenderingContext.CurrentPath;
		try
		{
			BrushRenderingContext.AdditionalColorModifier = modifier;
			BrushRenderingContext.CurrentPath = path;
			return class6350_0.vmethod_0(BrushRenderingContext);
		}
		finally
		{
			BrushRenderingContext.AdditionalColorModifier = additionalColorModifier;
			BrushRenderingContext.CurrentPath = currentPath;
		}
	}
}
