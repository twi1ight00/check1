using System.Text;
using ns176;
using ns186;
using ns195;

namespace ns187;

internal class Class5037 : Class5034
{
	private double double_0;

	private Interface180 interface180_0;

	public Class5037(double factor, Interface180 lbase)
	{
		double_0 = factor;
		interface180_0 = lbase;
	}

	public Interface180 method_3()
	{
		return interface180_0;
	}

	internal double method_4()
	{
		return double_0 * 100.0;
	}

	public override bool imethod_4()
	{
		return false;
	}

	public override double imethod_1()
	{
		return imethod_2(null);
	}

	public override double imethod_2(Interface172 context)
	{
		try
		{
			return double_0 * (double)interface180_0.imethod_2(context);
		}
		catch (Exception55)
		{
			return 0.0;
		}
	}

	public override string vmethod_13()
	{
		return double_0 * 100.0 + "%";
	}

	public override int imethod_5()
	{
		return (int)imethod_1();
	}

	public override int imethod_6(Interface172 context)
	{
		return (int)imethod_2(context);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(GetType().Name).Append("[factor=").Append(double_0).Append(",lbase=")
			.Append(interface180_0)
			.Append("]");
		return stringBuilder.ToString();
	}

	public override int GetHashCode()
	{
		int num = 1;
		num = 31 + Class5721.smethod_3(double_0);
		return 31 * num + Class5721.smethod_1(interface180_0);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5037 @class))
		{
			return false;
		}
		if (Class5721.smethod_2(double_0, @class.double_0))
		{
			return Class5721.smethod_0(interface180_0, @class.interface180_0);
		}
		return false;
	}
}
