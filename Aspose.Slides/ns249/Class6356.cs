using ns224;
using ns250;

namespace ns249;

internal class Class6356 : Class6350
{
	private Interface274 interface274_0;

	public Interface274 Color
	{
		get
		{
			if (interface274_0 == null)
			{
				interface274_0 = new Class6285();
			}
			return interface274_0;
		}
		set
		{
			interface274_0 = value;
		}
	}

	public Class6356()
	{
	}

	public Class6356(Interface274 color)
	{
		interface274_0 = color;
	}

	public override Class5990 vmethod_0(Class6360 brushRenderingContext)
	{
		Class5998 color = vmethod_1(brushRenderingContext);
		return new Class5997(color);
	}

	public override void imethod_0(Interface274 styleColor)
	{
		Color.imethod_0(styleColor);
	}

	public override Class6350 Clone()
	{
		Class6356 @class = new Class6356();
		@class.Color = Color.Clone();
		return @class;
	}

	public override Class5998 vmethod_1(Class6360 brushRenderingContext)
	{
		return Color.imethod_1(brushRenderingContext.ThemeProvider, brushRenderingContext.AdditionalColorModifier);
	}
}
