using ns176;
using ns195;

namespace ns187;

internal class Class5041 : Class5024, Interface181
{
	private static Class5749 class5749_0 = new Class5749();

	private Class5042 class5042_0;

	private Class5041(Class5024 enumProperty)
	{
		class5042_0 = (Class5042)enumProperty;
	}

	public static Class5041 smethod_0(Class5024 enumProperty)
	{
		return (Class5041)class5749_0.method_0(new Class5041((Class5042)enumProperty));
	}

	public override int imethod_0()
	{
		return class5042_0.imethod_0();
	}

	public override string vmethod_13()
	{
		return class5042_0.ToString();
	}

	public override object vmethod_12()
	{
		return class5042_0.vmethod_12();
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5041 @class))
		{
			return false;
		}
		return Class5721.smethod_0(class5042_0, @class.class5042_0);
	}

	public override int GetHashCode()
	{
		return class5042_0.GetHashCode();
	}

	public int imethod_3()
	{
		return 0;
	}

	public bool imethod_4()
	{
		return true;
	}

	public double imethod_2(Interface172 context)
	{
		return 0.0;
	}

	public int imethod_6(Interface172 context)
	{
		return 0;
	}

	public int imethod_5()
	{
		return 0;
	}

	public double imethod_1()
	{
		return 0.0;
	}

	public override Interface181 vmethod_10()
	{
		return this;
	}
}
