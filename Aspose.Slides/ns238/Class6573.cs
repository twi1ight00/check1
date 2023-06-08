using ns235;
using ns271;

namespace ns238;

internal class Class6573 : Class6568
{
	private Class6581 class6581_0;

	public Class6573(Class6567 context)
		: base(context)
	{
		class6581_0 = new Class6581(context);
	}

	public void method_0(Class6658 glyphData)
	{
		base.Writer.method_6(1, 4, closeByte: false);
		base.Writer.method_6(0, 4, closeByte: false);
		class6581_0.method_3();
		Class6217 @class = glyphData.method_0();
		Class6194 visitor = new Class6194(class6581_0);
		@class.vmethod_0(visitor);
		class6581_0.method_0();
	}

	public void method_1()
	{
		base.Writer.method_6(1, 4, closeByte: false);
		base.Writer.method_6(0, 4, closeByte: false);
		class6581_0.method_3();
		class6581_0.method_0();
	}
}
