using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;
using ns235;

namespace ns249;

internal class Class6363 : Interface284
{
	private Class6364 class6364_0;

	private Enum808 enum808_0;

	public bool AreColorsInReverseOrder => true;

	public Class6364 FillToRectangle
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

	public Enum808 Path
	{
		get
		{
			return enum808_0;
		}
		set
		{
			enum808_0 = value;
		}
	}

	public Interface284 Clone()
	{
		Class6363 @class = new Class6363();
		@class.Path = Path;
		@class.FillToRectangle = FillToRectangle.Clone();
		return @class;
	}

	public Class5992 imethod_0(RectangleF tileRectangle, Class6360 brushRenderingContext, bool rotateWithShape)
	{
		PointF centerPoint = method_0(brushRenderingContext.ShapeBoundingBox);
		Class6217 path = method_1(brushRenderingContext, tileRectangle);
		Class5994 @class = new Class5994(path, centerPoint);
		if (rotateWithShape)
		{
			@class.Transform = Class6365.smethod_1(brushRenderingContext, centerPoint);
		}
		return @class;
	}

	private static Class6002 smethod_0(RectangleF originalBoundingBox, RectangleF newBoundingBox)
	{
		Class6002 @class = new Class6002();
		@class.method_7(0f - originalBoundingBox.X, 0f - originalBoundingBox.Y, MatrixOrder.Append);
		@class.method_5(newBoundingBox.Width / originalBoundingBox.Width, newBoundingBox.Height / originalBoundingBox.Height, MatrixOrder.Append);
		@class.method_7(newBoundingBox.X, newBoundingBox.Y, MatrixOrder.Append);
		return @class;
	}

	private PointF method_0(RectangleF tileRectangle)
	{
		RectangleF rectangleF = FillToRectangle.method_0(tileRectangle);
		return new PointF(rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top + rectangleF.Height / 2f);
	}

	private Class6217 method_1(Class6360 brushRenderingContext, RectangleF tileRectangle)
	{
		Class6217 @class = Path switch
		{
			Enum808.const_0 => smethod_2(brushRenderingContext), 
			Enum808.const_1 => smethod_3(brushRenderingContext), 
			Enum808.const_2 => smethod_1(brushRenderingContext), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
		method_2(brushRenderingContext, @class, tileRectangle);
		return @class;
	}

	private static Class6217 smethod_1(Class6360 brushRenderingContext)
	{
		Class6217 @class = new Class6217();
		@class.Add(Class6218.smethod_2(brushRenderingContext.ShapeBoundingBox));
		return @class;
	}

	private static Class6217 smethod_2(Class6360 brushRenderingContext)
	{
		if (brushRenderingContext.CurrentPath == null)
		{
			return new Class6217();
		}
		return brushRenderingContext.CurrentPath.Clone();
	}

	private static Class6217 smethod_3(Class6360 brushRenderingContext)
	{
		Class6218 @class = new Class6218();
		RectangleF shapeBoundingBox = brushRenderingContext.ShapeBoundingBox;
		PointF pointF = new PointF(shapeBoundingBox.Left + shapeBoundingBox.Width / 2f, shapeBoundingBox.Top + shapeBoundingBox.Height / 2f);
		float num = (float)Math.Sqrt((shapeBoundingBox.Left - pointF.X) * (shapeBoundingBox.Left - pointF.X) + (shapeBoundingBox.Top - pointF.Y) * (shapeBoundingBox.Top - pointF.Y));
		RectangleF bounds = new RectangleF(pointF.X - num, pointF.Y - num, num * 2f, num * 2f);
		@class.method_5(new Class6173(bounds));
		Class6217 class2 = new Class6217();
		class2.Add(@class);
		return class2;
	}

	private void method_2(Class6360 brushRenderingContext, Class6217 path, RectangleF tileRectangle)
	{
		if (Path != 0)
		{
			Class6002 matrix = smethod_0(brushRenderingContext.ShapeBoundingBox, tileRectangle);
			path.method_3(matrix);
		}
	}
}
