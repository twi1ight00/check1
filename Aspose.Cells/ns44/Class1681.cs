using System.Runtime.CompilerServices;

namespace ns44;

internal class Class1681
{
	internal static readonly Class1681 class1681_0 = new Class1681();

	private double double_0;

	private double double_1;

	private double double_2;

	internal Class1681()
	{
		double_0 = 0.0;
		double_1 = 0.0;
		double_2 = 0.0;
	}

	internal Class1681(double double_3, double double_4, double double_5)
	{
		double_0 = ((double_3 > 360.0) ? 360.0 : ((double_3 < 0.0) ? 0.0 : double_3));
		double_1 = ((double_4 > 1.0) ? 1.0 : ((double_4 < 0.0) ? 0.0 : double_4));
		double_2 = ((double_5 > 1.0) ? 1.0 : ((double_5 < 0.0) ? 0.0 : double_5));
	}

	[SpecialName]
	internal double method_0()
	{
		return double_0;
	}

	[SpecialName]
	internal void method_1(double double_3)
	{
		double_0 = ((double_3 > 360.0) ? 360.0 : ((double_3 < 0.0) ? 0.0 : double_3));
	}

	[SpecialName]
	internal double method_2()
	{
		return double_1;
	}

	[SpecialName]
	internal void method_3(double double_3)
	{
		double_1 = ((double_3 > 1.0) ? 1.0 : ((double_3 < 0.0) ? 0.0 : double_3));
	}

	[SpecialName]
	internal double method_4()
	{
		return double_2;
	}

	[SpecialName]
	internal void method_5(double double_3)
	{
		double_2 = ((double_3 > 1.0) ? 1.0 : ((double_3 < 0.0) ? 0.0 : double_3));
	}

	public override int GetHashCode()
	{
		return method_0().GetHashCode() ^ method_2().GetHashCode() ^ method_4().GetHashCode();
	}
}
