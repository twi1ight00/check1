using ns224;
using ns250;
using ns251;
using ns252;
using ns261;

namespace ns249;

internal class Class6361
{
	private Interface274 interface274_0;

	private Class6329 class6329_0 = new Class6329();

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

	public Class6329 Position
	{
		get
		{
			return class6329_0;
		}
		set
		{
			class6329_0 = value;
		}
	}

	public Class6361 Clone()
	{
		Class6361 @class = new Class6361();
		@class.Color = Color.Clone();
		@class.Position = Position;
		return @class;
	}

	public Class6000 method_0(Interface297 themeProvider, Interface275 additionalModifier)
	{
		return new Class6000(Color.imethod_1(themeProvider, additionalModifier), (float)Position.Fraction);
	}

	public Class6000 method_1(float newPosition, Interface297 themeProvider, Interface275 additionalModifier)
	{
		return new Class6000(Color.imethod_1(themeProvider, additionalModifier), newPosition);
	}
}
