using System.Runtime.CompilerServices;

namespace ns8;

internal struct Struct48
{
	private double double_0;

	private double double_1;

	public double Height
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double Width
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public Struct48(double width, double height)
	{
		double_0 = height;
		double_1 = width;
	}

	[SpecialName]
	public static Struct48 smethod_0(Struct48 a, Struct48 b)
	{
		return new Struct48(a.double_1 + b.double_1, a.double_0 + b.double_0);
	}

	[SpecialName]
	public static Struct48 smethod_1(Struct48 a, Struct48 b)
	{
		return new Struct48(a.double_1 - b.double_1, a.double_0 - b.double_0);
	}
}
