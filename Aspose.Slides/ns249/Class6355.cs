using System.Drawing.Drawing2D;
using ns224;
using ns250;

namespace ns249;

internal class Class6355 : Class6350
{
	private Interface274 interface274_0;

	private HatchStyle hatchStyle_0;

	private Interface274 interface274_1;

	public HatchStyle FillPresetPattern
	{
		get
		{
			return hatchStyle_0;
		}
		set
		{
			hatchStyle_0 = value;
		}
	}

	public Interface274 BackgroundColor
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

	public Interface274 ForegroundColor
	{
		get
		{
			if (interface274_1 == null)
			{
				interface274_1 = new Class6285();
			}
			return interface274_1;
		}
		set
		{
			interface274_1 = value;
		}
	}

	public override Class5990 vmethod_0(Class6360 brushRenderingContext)
	{
		Class5998 foreColor = method_0(brushRenderingContext);
		Class5998 backColor = method_1(brushRenderingContext);
		return new Class5996(FillPresetPattern, foreColor, backColor);
	}

	private Class5998 method_0(Class6360 brushRenderingContext)
	{
		return ForegroundColor.imethod_1(brushRenderingContext.ThemeProvider, brushRenderingContext.AdditionalColorModifier);
	}

	private Class5998 method_1(Class6360 brushRenderingContext)
	{
		return BackgroundColor.imethod_1(brushRenderingContext.ThemeProvider, brushRenderingContext.AdditionalColorModifier);
	}

	public override void imethod_0(Interface274 styleColor)
	{
		ForegroundColor.imethod_0(styleColor);
		BackgroundColor.imethod_0(styleColor);
	}

	public override Class6350 Clone()
	{
		Class6355 @class = new Class6355();
		@class.FillPresetPattern = FillPresetPattern;
		@class.BackgroundColor = BackgroundColor.Clone();
		@class.ForegroundColor = ForegroundColor.Clone();
		return @class;
	}

	public override Class5998 vmethod_1(Class6360 brushRenderingContext)
	{
		return method_0(brushRenderingContext);
	}
}
