using ns224;
using ns250;

namespace ns249;

internal class Class6353 : Class6350
{
	public override Class5990 vmethod_0(Class6360 brushRenderingContext)
	{
		Class6350 @class = brushRenderingContext.FillProvider.imethod_0();
		if (@class == null)
		{
			return Class5990.smethod_0();
		}
		return @class.vmethod_0(brushRenderingContext);
	}

	public override void imethod_0(Interface274 styleColor)
	{
	}

	public override Class6350 Clone()
	{
		return new Class6353();
	}

	public override Class5998 vmethod_1(Class6360 brushRenderingContext)
	{
		Class6350 @class = brushRenderingContext.FillProvider.imethod_0();
		if (@class == null)
		{
			return Class5998.class5998_141;
		}
		return @class.vmethod_1(brushRenderingContext);
	}
}
