using ns221;
using ns224;
using ns252;

namespace ns251;

internal class Class6318 : Class6292
{
	private Class6323 class6323_0;

	public Class6323 Value
	{
		get
		{
			return class6323_0;
		}
		set
		{
			class6323_0 = value;
		}
	}

	public override Class5998 imethod_0(Class5998 color)
	{
		Class5960 @class = new Class5960(color);
		@class.Hue = Value.ValueInDegrees / 360.0;
		return new Class5998(color.A, @class.method_0());
	}

	public override Interface275 Clone()
	{
		Class6318 @class = new Class6318();
		@class.Value = Value;
		return @class;
	}
}
