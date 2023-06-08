using ns224;
using ns261;

namespace ns250;

internal class Class6288 : Class6284
{
	private Interface274 interface274_0;

	public Interface274 StyleColor
	{
		get
		{
			return interface274_0;
		}
		set
		{
			interface274_0 = value;
		}
	}

	protected override Class5998 vmethod_0(Interface297 themeProvider)
	{
		if (StyleColor != null)
		{
			return StyleColor.imethod_1(themeProvider, null);
		}
		return Class5998.class5998_141;
	}

	public override Interface274 Clone()
	{
		Class6288 @class = new Class6288();
		if (StyleColor != null)
		{
			@class.StyleColor = StyleColor.Clone();
		}
		method_1(@class);
		return @class;
	}

	public override void imethod_0(Interface274 styleColor)
	{
		StyleColor = styleColor;
	}
}
