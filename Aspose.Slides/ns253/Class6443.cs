using ns252;
using ns262;

namespace ns253;

internal class Class6443 : Interface299
{
	private Class6330 class6330_0 = new Class6330();

	public Class6330 Value
	{
		get
		{
			return class6330_0;
		}
		set
		{
			class6330_0 = value;
		}
	}

	public double imethod_0(Class6434 paragraph)
	{
		return Value.ValueInEmus;
	}

	public Interface300 imethod_1(Interface300 lineMeasurement)
	{
		Class6471 @class = new Class6471();
		@class.LineSpacing = Value.ValueInEmus;
		double num = @class.LineSpacing / lineMeasurement.LineSpacing;
		@class.Ascent = lineMeasurement.Ascent * num;
		@class.Descent = lineMeasurement.Descent * num;
		return @class;
	}
}
