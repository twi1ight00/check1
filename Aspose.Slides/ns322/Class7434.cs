using System.Globalization;

namespace ns322;

internal sealed class Class7434 : Class7399, Interface402
{
	private double double_0;

	public override object Value => double_0;

	public override string _Class => "Number";

	public override string Type => "number";

	public static bool smethod_0(double value)
	{
		return value != 0.0;
	}

	public override bool vmethod_2()
	{
		return smethod_0(double_0);
	}

	public override double vmethod_3()
	{
		return double_0;
	}

	public override string ToString()
	{
		return double_0.ToString(CultureInfo.InvariantCulture).ToLower();
	}

	public override object vmethod_5()
	{
		return double_0;
	}

	public Class7434(double value, Class7399 prototype)
		: base(prototype)
	{
		double_0 = value;
	}

	public Class7434(int value, Class7399 prototype)
		: base(prototype)
	{
		double_0 = value;
	}
}
