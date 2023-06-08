using ns171;
using ns187;

namespace ns186;

internal class Class5008 : Class5003
{
	public override int imethod_0()
	{
		return 1;
	}

	public override bool imethod_3()
	{
		return true;
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		string text = args[0].vmethod_13();
		if (text == null)
		{
			throw new Exception55("Incorrect parameter to from-parent function");
		}
		int num = Class5735.smethod_3(text);
		if (num < 0)
		{
			throw new Exception55("Unknown property name used with inherited-property-value function: " + text);
		}
		return pInfo.method_3().method_8(num);
	}
}
