using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;
using ns233;
using ns250;
using ns254;

namespace ns249;

internal class Class6351 : Class6350
{
	private Class6349 class6349_0;

	private Interface283 interface283_0;

	private uint uint_0;

	private bool bool_0;

	private Class6364 class6364_0 = new Class6364();

	private Interface282 interface282_0;

	public Class6349 Blip
	{
		get
		{
			if (class6349_0 == null)
			{
				class6349_0 = new Class6349();
			}
			return class6349_0;
		}
		set
		{
			class6349_0 = value;
		}
	}

	public uint DotsPerInch
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
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

	public Class6364 SourceRectangle
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

	public Interface283 BlipFillMode
	{
		get
		{
			if (interface283_0 == null)
			{
				interface283_0 = new Class6358();
			}
			return interface283_0;
		}
		set
		{
			interface283_0 = value;
		}
	}

	internal Interface282 EffectsApplier
	{
		get
		{
			if (interface282_0 == null)
			{
				interface282_0 = new Class6346();
			}
			return interface282_0;
		}
		set
		{
			interface282_0 = value;
		}
	}

	public override Class5990 vmethod_0(Class6360 brushRenderingContext)
	{
		byte[] array = Blip.method_0(brushRenderingContext.DataProvider);
		if (array == null)
		{
			return new Class5997(Class5998.class5998_141);
		}
		Class5995 @class = new Class5995(array);
		EffectsApplier.imethod_0(@class, brushRenderingContext, Blip.Effects);
		method_0(@class, brushRenderingContext, array);
		method_2(@class, brushRenderingContext);
		return @class;
	}

	public override void imethod_0(Interface274 styleColor)
	{
	}

	public override Class6350 Clone()
	{
		Class6351 @class = new Class6351();
		@class.DotsPerInch = DotsPerInch;
		@class.RotateWithShape = RotateWithShape;
		if (class6364_0 != null)
		{
			@class.SourceRectangle = class6364_0.Clone();
		}
		if (interface283_0 != null)
		{
			@class.BlipFillMode = interface283_0.Clone();
		}
		if (class6349_0 != null)
		{
			@class.Blip = class6349_0.Clone();
		}
		return @class;
	}

	public override Class5998 vmethod_1(Class6360 brushRenderingContext)
	{
		return Class5998.class5998_7;
	}

	private void method_0(Class5995 brush, Class6360 brushRenderingContext, byte[] image)
	{
		Class6147 imageSize = Class6148.smethod_3(image);
		imageSize = method_1(imageSize);
		brush.ImageArea = SourceRectangle.method_0(new RectangleF(0f, 0f, imageSize.Width, imageSize.Height));
		BlipFillMode.imethod_0(brush, brushRenderingContext, imageSize);
	}

	private Class6147 method_1(Class6147 imageSize)
	{
		if (DotsPerInch == 0)
		{
			return imageSize;
		}
		return Class6147.smethod_2(imageSize.Left, imageSize.Top, imageSize.Right, imageSize.Bottom, DotsPerInch, DotsPerInch);
	}

	private void method_2(Class5995 brush, Class6360 brushRenderingContext)
	{
		if (RotateWithShape)
		{
			PointF centerPoint = new PointF(brushRenderingContext.ShapeBoundingBox.Width / 2f, brushRenderingContext.ShapeBoundingBox.Height / 2f);
			Class6002 tx = Class6365.smethod_1(brushRenderingContext, centerPoint);
			brush.Transform.method_9(tx, MatrixOrder.Append);
		}
	}
}
