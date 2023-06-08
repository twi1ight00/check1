using ns176;
using ns195;

namespace ns187;

internal class Class5035 : Class5034
{
	private Class5024 class5024_0;

	public Class5035(Class5024 enumProperty)
	{
		class5024_0 = enumProperty;
	}

	public override int imethod_0()
	{
		return class5024_0.imethod_0();
	}

	public override bool imethod_4()
	{
		return false;
	}

	public override int imethod_5()
	{
		return 0;
	}

	public override int imethod_6(Interface172 context)
	{
		return 0;
	}

	public override double imethod_1()
	{
		return 0.0;
	}

	public override double imethod_2(Interface172 context)
	{
		return 0.0;
	}

	public override string vmethod_13()
	{
		return class5024_0.ToString();
	}

	public override object vmethod_12()
	{
		return class5024_0.vmethod_12();
	}

	public override int GetHashCode()
	{
		return class5024_0.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5035 @class))
		{
			return false;
		}
		return Class5721.smethod_0(class5024_0, @class.class5024_0);
	}
}
