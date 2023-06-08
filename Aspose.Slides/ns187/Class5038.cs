using System;
using ns171;
using ns176;
using ns195;

namespace ns187;

internal class Class5038 : Class5034
{
	private double double_0;

	private Class5094 class5094_0;

	public Class5038(double tcolUnits, Class5094 column)
	{
		double_0 = tcolUnits;
		class5094_0 = column;
	}

	public double method_3()
	{
		return double_0;
	}

	public override bool imethod_4()
	{
		return false;
	}

	public override double imethod_1()
	{
		throw new NotSupportedException("Must call getNumericValue with PercentBaseContext");
	}

	public override double imethod_2(Interface172 context)
	{
		return double_0 * (double)context.imethod_0(11, class5094_0);
	}

	public override int imethod_5()
	{
		throw new NotSupportedException("Must call getValue with PercentBaseContext");
	}

	public override int imethod_6(Interface172 context)
	{
		return (int)(double_0 * (double)context.imethod_0(11, class5094_0));
	}

	public override string ToString()
	{
		return double_0 + " table-column-units";
	}

	public override int GetHashCode()
	{
		int num = 1;
		num = 31 + Class5721.smethod_1(class5094_0);
		return 31 * num + Class5721.smethod_3(double_0);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5038 @class))
		{
			return false;
		}
		if (Class5721.smethod_0(class5094_0, @class.class5094_0))
		{
			return Class5721.smethod_2(double_0, @class.double_0);
		}
		return false;
	}
}
