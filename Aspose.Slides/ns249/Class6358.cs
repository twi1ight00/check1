using System.Drawing;
using System.Drawing.Drawing2D;
using ns218;
using ns224;
using ns233;

namespace ns249;

internal class Class6358 : Interface283
{
	private Class6364 class6364_0;

	public Class6364 FillRectangle
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

	public Interface283 Clone()
	{
		Class6358 @class = new Class6358();
		@class.FillRectangle = FillRectangle.Clone();
		return @class;
	}

	public void imethod_0(Class5995 brush, Class6360 brushRenderingContext, Class6147 imageSize)
	{
		brush.WrapMode = WrapMode.Clamp;
		RectangleF rect = Class5955.smethod_42(brushRenderingContext.ShapeBoundingBox);
		RectangleF to = FillRectangle.method_0(rect);
		Class6002 tx = Class6002.smethod_1(brush.ImageArea, to);
		brush.Transform.method_9(tx, MatrixOrder.Append);
	}
}
