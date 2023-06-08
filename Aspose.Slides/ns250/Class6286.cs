using ns221;
using ns224;
using ns252;
using ns261;

namespace ns250;

internal class Class6286 : Class6284
{
	private Class6323 class6323_0 = new Class6323();

	private Class6331 class6331_0 = new Class6331(0.0);

	private Class6331 class6331_1 = new Class6331(0.0);

	public Class6331 Saturation
	{
		get
		{
			return class6331_1;
		}
		set
		{
			class6331_1 = value;
		}
	}

	public Class6331 Luminance
	{
		get
		{
			return class6331_0;
		}
		set
		{
			class6331_0 = value;
		}
	}

	public Class6323 Hue
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

	public override Interface274 Clone()
	{
		Class6286 @class = new Class6286();
		@class.Saturation = Saturation;
		@class.Luminance = Luminance;
		@class.Hue = Hue;
		method_1(@class);
		return @class;
	}

	protected override Class5998 vmethod_0(Interface297 themeProvider)
	{
		Class5960 @class = new Class5960();
		@class.Hue = Hue.ValueInDegrees / 360.0;
		@class.Lum = Luminance.Fraction;
		@class.Sat = Saturation.Fraction;
		return @class.method_0();
	}
}
