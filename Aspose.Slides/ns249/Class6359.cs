using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns218;
using ns222;
using ns224;
using ns233;
using ns252;

namespace ns249;

internal class Class6359 : Interface283
{
	private Enum809 enum809_0;

	private double double_0;

	private Class6329 class6329_0 = Class6329.smethod_0(1.0);

	private Enum810 enum810_0;

	private double double_1;

	private Class6329 class6329_1 = Class6329.smethod_0(1.0);

	public Enum809 Alignment
	{
		get
		{
			return enum809_0;
		}
		set
		{
			enum809_0 = value;
		}
	}

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

	public Class6329 HorizontalRatio
	{
		get
		{
			return class6329_0;
		}
		set
		{
			class6329_0 = value;
		}
	}

	public Class6329 VerticalRatio
	{
		get
		{
			return class6329_1;
		}
		set
		{
			class6329_1 = value;
		}
	}

	public double HorizontalOffset
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

	public double VerticalOffset
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public Interface283 Clone()
	{
		Class6359 @class = new Class6359();
		@class.Alignment = Alignment;
		@class.HorizontalOffset = HorizontalOffset;
		@class.HorizontalRatio = HorizontalRatio;
		@class.VerticalOffset = VerticalOffset;
		@class.VerticalRatio = VerticalRatio;
		@class.TileFlipMode = TileFlipMode;
		return @class;
	}

	public void imethod_0(Class5995 brush, Class6360 brushRenderingContext, Class6147 imageSize)
	{
		method_2(brush);
		method_1(brush, imageSize);
		method_0(brush, brushRenderingContext, imageSize);
		method_3(brush);
	}

	private void method_0(Class5995 brush, Class6360 brushRenderingContext, Class6147 imageSize)
	{
		RectangleF rect = new RectangleF(0f, 0f, imageSize.WidthEmus, imageSize.HeightEmus);
		Class6002 @class = new Class6002();
		@class.method_6((float)class6329_0.Fraction, (float)class6329_1.Fraction);
		rect = @class.method_4(rect);
		PointF pointF = Class5959.smethod_0(rect);
		RectangleF shapeBoundingBox = brushRenderingContext.ShapeBoundingBox;
		shapeBoundingBox = new RectangleF(0f, 0f, shapeBoundingBox.Width, shapeBoundingBox.Height);
		PointF pointF2 = Class5959.smethod_0(shapeBoundingBox);
		float offsetX = 0f;
		float offsetY = 0f;
		switch (Alignment)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum809.const_1:
			offsetX = pointF2.X - pointF.X;
			break;
		case Enum809.const_2:
			offsetX = shapeBoundingBox.Right - rect.Right;
			break;
		case Enum809.const_3:
			offsetY = pointF2.Y - pointF.Y;
			break;
		case Enum809.const_4:
			offsetX = pointF2.X - pointF.X;
			offsetY = pointF2.Y - pointF.Y;
			break;
		case Enum809.const_5:
			offsetY = pointF2.Y - pointF.Y;
			offsetX = shapeBoundingBox.Right - rect.Right;
			break;
		case Enum809.const_6:
			offsetY = shapeBoundingBox.Bottom - rect.Bottom;
			break;
		case Enum809.const_7:
			offsetY = shapeBoundingBox.Bottom - rect.Bottom;
			offsetX = pointF2.X - pointF.X;
			break;
		case Enum809.const_8:
			offsetY = shapeBoundingBox.Bottom - rect.Bottom;
			offsetX = shapeBoundingBox.Right - rect.Right;
			break;
		case Enum809.const_0:
			break;
		}
		brush.Transform.method_7(offsetX, offsetY, MatrixOrder.Append);
	}

	private void method_1(Class5995 brush, Class6147 imageSize)
	{
		Class6002 @class = new Class6002();
		@class.method_6((float)Class5955.smethod_10(1.0, imageSize.HorizontalResolution), (float)Class5955.smethod_10(1.0, imageSize.VerticalResolution));
		@class.method_6((float)class6329_0.Fraction, (float)class6329_1.Fraction);
		brush.Transform.method_9(@class, MatrixOrder.Append);
	}

	private void method_2(Class5995 brush)
	{
		switch (TileFlipMode)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum810.const_0:
			brush.WrapMode = WrapMode.Tile;
			break;
		case Enum810.const_1:
			brush.WrapMode = WrapMode.TileFlipX;
			break;
		case Enum810.const_2:
			brush.WrapMode = WrapMode.TileFlipY;
			break;
		case Enum810.const_3:
			brush.WrapMode = WrapMode.TileFlipXY;
			break;
		}
	}

	private void method_3(Class5995 brush)
	{
		Class6002 @class = new Class6002();
		@class.method_7((float)HorizontalOffset, (float)VerticalOffset, MatrixOrder.Append);
		brush.Transform.method_9(@class, MatrixOrder.Append);
	}
}
