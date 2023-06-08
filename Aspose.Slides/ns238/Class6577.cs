using System.Drawing.Drawing2D;
using ns218;
using ns224;

namespace ns238;

internal class Class6577 : Class6568
{
	public Class6577(Class6567 context)
		: base(context)
	{
	}

	public void method_0(Class6003 pen)
	{
		base.Writer.WriteByte(1);
		base.Writer.method_1((short)Class5964.smethod_29(pen.Width));
		base.Writer.method_6(smethod_0(pen.StartCap), 2, closeByte: false);
		int num = smethod_1(pen.LineJoin);
		base.Writer.method_6(num, 2, closeByte: false);
		base.Writer.method_4(bit: true, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_6(0, 5, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_6(smethod_0(pen.EndCap), 2, closeByte: false);
		if (num == 2)
		{
			base.Writer.method_1((short)Class5964.smethod_29(pen.MiterLimit));
		}
		Class6571 @class = new Class6571(base.Context);
		@class.Write(pen.Brush);
	}

	public void method_1()
	{
		base.Writer.WriteByte(0);
	}

	private static int smethod_0(LineCap lineCap)
	{
		switch (lineCap)
		{
		case LineCap.Square:
		case LineCap.SquareAnchor:
			return 2;
		case LineCap.Round:
		case LineCap.RoundAnchor:
			return 0;
		default:
			return 1;
		}
	}

	private static int smethod_1(LineJoin lineJoin)
	{
		switch (lineJoin)
		{
		default:
			return 1;
		case LineJoin.Bevel:
			return 1;
		case LineJoin.Round:
			return 0;
		case LineJoin.Miter:
		case LineJoin.MiterClipped:
			return 2;
		}
	}
}
