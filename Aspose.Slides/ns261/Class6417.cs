using ns249;

namespace ns261;

internal class Class6417 : Class6415
{
	private const int int_0 = 1001;

	private const int int_1 = 1;

	private const int int_2 = 999;

	private int int_3;

	public int StyleMatrixIndex
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public Class6350 method_0(Class6360 brushRenderingContext)
	{
		Class6350 @class = method_1(brushRenderingContext);
		@class.imethod_0(base.Color);
		return @class;
	}

	private Class6350 method_1(Class6360 brushRenderingContext)
	{
		Class6350 @class = null;
		if (1 <= StyleMatrixIndex && StyleMatrixIndex <= 999)
		{
			@class = method_3(brushRenderingContext.ThemeProvider);
		}
		else if (StyleMatrixIndex >= 1001)
		{
			@class = method_2(brushRenderingContext.ThemeProvider);
		}
		if (@class == null)
		{
			@class = new Class6354();
		}
		return @class;
	}

	private Class6350 method_2(Interface297 themeProvider)
	{
		if (themeProvider == null)
		{
			return null;
		}
		int index = StyleMatrixIndex - 1001;
		return themeProvider.imethod_1(index);
	}

	private Class6350 method_3(Interface297 themeProvider)
	{
		if (themeProvider == null)
		{
			return null;
		}
		int index = StyleMatrixIndex - 1;
		return themeProvider.imethod_2(index);
	}
}
