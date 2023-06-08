using ns252;
using ns262;

namespace ns253;

internal class Class6442 : Interface299
{
	private Class6329 class6329_0 = Class6329.smethod_0(1.0);

	public Class6329 Value
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

	public double imethod_0(Class6434 paragraph)
	{
		double num = 0.0;
		foreach (Interface298 element in paragraph.Elements)
		{
			if (num < element.RunProperties.FontSize.ValueInEmus)
			{
				num = element.RunProperties.FontSize.ValueInEmus;
			}
		}
		return num * Value.Fraction;
	}

	public Interface300 imethod_1(Interface300 lineMeasurement)
	{
		Class6471 @class = new Class6471();
		@class.Ascent = lineMeasurement.Ascent * Value.Fraction;
		@class.Descent = lineMeasurement.Descent * Value.Fraction;
		@class.LineSpacing = lineMeasurement.LineSpacing * Value.Fraction;
		return @class;
	}
}
