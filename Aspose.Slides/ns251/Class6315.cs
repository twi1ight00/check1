using ns221;
using ns224;

namespace ns251;

internal class Class6315 : Class6292
{
	public override Class5998 imethod_0(Class5998 color)
	{
		Class5960 @class = new Class5960(color);
		double num = @class.Hue + 0.5;
		if (num > 1.0)
		{
			num -= 1.0;
		}
		@class.Hue = num;
		return @class.method_0();
	}

	public override Interface275 Clone()
	{
		return new Class6315();
	}
}
