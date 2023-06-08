using System.Drawing;
using ns218;
using ns224;
using ns235;

namespace ns238;

internal class Class6582 : Class6568
{
	public Class6582(Class6567 context)
		: base(context)
	{
	}

	public void method_0(Class6217 path, short characterId)
	{
		Class6584 @class = new Class6584(base.Context);
		@class.method_0();
		base.Writer.method_1(characterId);
		RectangleF rectangleF = Class6192.smethod_0(path);
		base.Writer.method_13(Class5964.smethod_29(rectangleF.Left), Class5964.smethod_29(rectangleF.Right), Class5964.smethod_29(rectangleF.Top), Class5964.smethod_29(rectangleF.Bottom));
		base.Writer.method_13(Class5964.smethod_29(rectangleF.Left), Class5964.smethod_29(rectangleF.Right), Class5964.smethod_29(rectangleF.Top), Class5964.smethod_29(rectangleF.Bottom));
		base.Writer.method_6(0, 5, closeByte: false);
		base.Writer.method_6(0, 1, closeByte: false);
		base.Writer.method_6(0, 1, closeByte: false);
		base.Writer.method_6(0, 1, closeByte: false);
		Class5990 brush = ((path.Brush == null || !Class6193.smethod_0(path)) ? new Class5997(Class5998.class5998_140) : path.Brush);
		Class6571 class2 = new Class6571(base.Context);
		class2.method_0(brush);
		Class6003 pen = ((path.Pen != null) ? path.Pen : new Class6003(Class5998.class5998_141, 1f));
		Class6577 class3 = new Class6577(base.Context);
		class3.method_0(pen);
		base.Writer.method_6(1, 4, closeByte: false);
		base.Writer.method_6(1, 4, closeByte: false);
		Class6581 class4 = new Class6581(base.Context);
		class4.method_2();
		class4.method_3();
		Class6194 class5 = new Class6194(base.Context);
		class5.Write(path);
		class4.method_0();
		@class.method_1(Enum878.const_56);
	}
}
