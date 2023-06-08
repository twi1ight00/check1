using System.Drawing;
using ns175;
using ns176;
using ns187;
using ns195;

namespace ns186;

internal class Class5026 : Class5024, Interface181, Interface182
{
	private double double_0;

	private int int_0;

	internal Class5026(double value, int dim)
	{
		double_0 = value;
		int_0 = dim;
	}

	public int imethod_3()
	{
		return int_0;
	}

	public double imethod_1()
	{
		return double_0;
	}

	public double imethod_2(Interface172 context)
	{
		return double_0;
	}

	public bool imethod_4()
	{
		return true;
	}

	public override Interface181 vmethod_10()
	{
		return this;
	}

	public override object vmethod_9()
	{
		return double_0;
	}

	public int imethod_5()
	{
		return (int)double_0;
	}

	public int imethod_6(Interface172 context)
	{
		return (int)double_0;
	}

	public override Interface182 vmethod_0()
	{
		if (int_0 == 1)
		{
			return this;
		}
		return null;
	}

	public override Color vmethod_1(Class5738 foUserAgent)
	{
		return Color.Empty;
	}

	public override object vmethod_12()
	{
		return this;
	}

	public override string ToString()
	{
		if (int_0 == 1)
		{
			return (int)double_0 + "mpt";
		}
		return double_0 + "^" + int_0;
	}

	public override int GetHashCode()
	{
		int num = 1;
		num = 31 + int_0;
		return 31 * num + Class5721.smethod_3(double_0);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5026))
		{
			return false;
		}
		Class5026 @class = (Class5026)obj;
		if (int_0 == @class.int_0)
		{
			return Class5721.smethod_2(double_0, @class.double_0);
		}
		return false;
	}
}
