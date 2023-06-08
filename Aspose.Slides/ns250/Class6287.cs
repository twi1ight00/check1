using System;
using ns224;
using ns252;
using ns261;

namespace ns250;

internal class Class6287 : Class6284
{
	private Class6331 class6331_0 = new Class6331(0.0);

	private Class6331 class6331_1 = new Class6331(0.0);

	private Class6331 class6331_2 = new Class6331(0.0);

	public Class6331 R
	{
		get
		{
			return class6331_2;
		}
		set
		{
			class6331_2 = value;
		}
	}

	public Class6331 G
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

	public Class6331 B
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

	protected override Class5998 vmethod_0(Interface297 themeProvider)
	{
		int r = (int)Math.Round(R.Fraction * 255.0);
		int g = (int)Math.Round(G.Fraction * 255.0);
		int b = (int)Math.Round(B.Fraction * 255.0);
		return new Class5998(r, g, b);
	}

	public override Interface274 Clone()
	{
		Class6287 @class = new Class6287();
		@class.R = R;
		@class.G = G;
		@class.B = B;
		method_1(@class);
		return @class;
	}
}
