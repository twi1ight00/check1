using ns221;
using ns224;

namespace ns251;

internal class Class6303 : Class6293
{
	public override Class5998 imethod_0(Class5998 color)
	{
		Class5960 @class = new Class5960(color);
		@class.Hue *= base.Value.Fraction;
		return new Class5998(color.A, @class.method_0());
	}

	protected override Class6293 vmethod_0()
	{
		return new Class6303();
	}
}
