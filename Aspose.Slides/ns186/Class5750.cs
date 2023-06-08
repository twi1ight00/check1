using System.Collections;
using ns171;
using ns175;
using ns176;
using ns187;

namespace ns186;

internal class Class5750
{
	private Class5052 class5052_0;

	private Class5634 class5634_0;

	private Class5094 class5094_0;

	private Stack stack_0;

	public Class5750(Class5052 maker, Class5634 plist)
	{
		class5052_0 = maker;
		class5634_0 = plist;
		class5094_0 = plist.method_1();
	}

	public Interface180 method_0()
	{
		Interface180 @interface = method_8();
		if (@interface == null)
		{
			return class5052_0.vmethod_5(class5634_0);
		}
		return @interface;
	}

	public Interface182 method_1()
	{
		return class5634_0.method_5(103).vmethod_0();
	}

	public Class5094 method_2()
	{
		return class5094_0;
	}

	public Class5634 method_3()
	{
		return class5634_0;
	}

	public Class5052 method_4()
	{
		return class5052_0;
	}

	public void method_5(Interface162 func)
	{
		if (stack_0 == null)
		{
			stack_0 = new Stack();
		}
		stack_0.Push(func);
	}

	public void method_6()
	{
		if (stack_0 != null)
		{
			stack_0.Pop();
		}
	}

	internal Class5738 method_7()
	{
		if (class5634_0.method_0() == null)
		{
			return null;
		}
		return class5634_0.method_0().method_2();
	}

	private Interface180 method_8()
	{
		if (stack_0 != null)
		{
			Interface162 @interface = (Interface162)stack_0.Peek();
			if (@interface != null)
			{
				return @interface.imethod_1();
			}
		}
		return null;
	}
}
