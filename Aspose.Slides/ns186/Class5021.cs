using ns176;
using ns187;

namespace ns186;

internal class Class5021 : Class5003
{
	internal class Class5752 : Interface180
	{
		public int imethod_0()
		{
			return 0;
		}

		public double imethod_1()
		{
			return 255.0;
		}

		public int imethod_2(Interface172 context)
		{
			return 0;
		}
	}

	public override int imethod_0()
	{
		return 3;
	}

	public override Interface180 imethod_1()
	{
		return new Class5752();
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		return Class5040.smethod_0(pInfo.method_7(), string.Concat("rgb(", args[0], ",", args[1], ",", args[2], ")"));
	}
}
