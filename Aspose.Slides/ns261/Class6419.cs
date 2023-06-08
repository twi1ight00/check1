using ns249;
using ns258;

namespace ns261;

internal class Class6419 : Class6415
{
	private int int_0;

	public int StyleMatrixIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public Interface294 method_0(Class6360 brushRenderingContext)
	{
		if (StyleMatrixIndex == 0)
		{
			return new Class6400();
		}
		Class6400 @class = brushRenderingContext.ThemeProvider.imethod_3(StyleMatrixIndex - 1);
		@class.imethod_0(base.Color);
		return @class;
	}
}
