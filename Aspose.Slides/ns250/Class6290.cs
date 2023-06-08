using ns224;
using ns261;

namespace ns250;

internal class Class6290 : Class6284
{
	private Enum818 enum818_0;

	public Enum818 Value
	{
		get
		{
			return enum818_0;
		}
		set
		{
			enum818_0 = value;
		}
	}

	protected override Class5998 vmethod_0(Interface297 themeProvider)
	{
		Interface274 @interface = themeProvider.imethod_0(Value);
		return @interface.imethod_1(themeProvider, null);
	}

	public override Interface274 Clone()
	{
		Class6290 @class = new Class6290();
		@class.Value = Value;
		method_1(@class);
		return @class;
	}
}
