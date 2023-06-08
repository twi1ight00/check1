using System.Drawing.Drawing2D;
using ns224;
using ns233;

namespace ns238;

internal class Class6571 : Class6568
{
	public Class6571(Class6567 context)
		: base(context)
	{
	}

	public void method_0(Class5990 brush)
	{
		base.Writer.WriteByte(1);
		switch (brush.BrushType)
		{
		case Enum746.const_0:
			method_1((Class5997)brush);
			break;
		case Enum746.const_1:
			method_4((Class5996)brush);
			break;
		case Enum746.const_2:
			method_3((Class5995)brush);
			break;
		case Enum746.const_3:
			method_2((Class5993)brush);
			break;
		default:
			method_1(new Class5997(Class5998.class5998_141));
			break;
		}
	}

	public void Write(Class5990 brush)
	{
		switch (brush.BrushType)
		{
		case Enum746.const_0:
			method_1((Class5997)brush);
			break;
		case Enum746.const_1:
			method_4((Class5996)brush);
			break;
		case Enum746.const_2:
			method_3((Class5995)brush);
			break;
		case Enum746.const_3:
			method_2((Class5993)brush);
			break;
		default:
			method_1(new Class5997(Class5998.class5998_141));
			break;
		}
	}

	private void method_1(Class5997 brush)
	{
		base.Writer.WriteByte(0);
		base.Writer.method_11(brush.Color);
	}

	private void method_2(Class5993 brush)
	{
		base.Writer.WriteByte(16);
		Class6002 @class = ((brush.Transform != null) ? brush.Transform.Clone() : new Class6002());
		@class.method_7(brush.Rectangle.X + brush.Rectangle.Width / 2f, brush.Rectangle.Y + brush.Rectangle.Height / 2f, MatrixOrder.Prepend);
		@class.method_5(brush.Rectangle.Width / 32768f, brush.Rectangle.Height / 32768f, MatrixOrder.Prepend);
		base.Writer.method_14(@class);
		Class6574 class2 = new Class6574(base.Context);
		class2.method_0(brush);
	}

	private void method_3(Class5995 brush)
	{
		method_5(brush.ImageBytes, brush.Transform, brush.WrapMode);
	}

	private void method_4(Class5996 brush)
	{
		byte[] imageBytes = Class6141.smethod_0(brush);
		method_5(imageBytes, null, WrapMode.Tile);
	}

	private void method_5(byte[] imageBytes, Class6002 transform, WrapMode wrapMode)
	{
		if (transform == null)
		{
			transform = new Class6002();
		}
		short value = base.Context.method_6(imageBytes);
		base.Writer.WriteByte((byte)((wrapMode == WrapMode.Clamp) ? 65 : 64));
		base.Writer.method_1(value);
		base.Writer.method_14(transform);
	}

	public void method_6()
	{
		base.Writer.WriteByte(0);
	}
}
