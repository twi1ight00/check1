using ns224;
using ns249;
using ns253;

namespace ns262;

internal class Class6467 : Interface311
{
	private readonly Class6360 class6360_0;

	public Class6467(Class6360 brushRenderingContext)
	{
		class6360_0 = brushRenderingContext;
	}

	public Class5998 imethod_0(Class6445 properties)
	{
		return properties.Fill.vmethod_1(class6360_0);
	}

	public Class5998 imethod_1(Class6445 properties)
	{
		if (properties.Outline.Fill == null)
		{
			return Class5998.class5998_141;
		}
		return properties.Outline.Fill.vmethod_1(class6360_0);
	}
}
