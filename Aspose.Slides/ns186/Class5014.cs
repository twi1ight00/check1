using System;
using ns171;
using ns176;
using ns187;
using ns192;

namespace ns186;

internal class Class5014 : Class5003
{
	private class Class5386 : Interface180
	{
		public int imethod_2(Interface172 context)
		{
			return 0;
		}

		public double imethod_1()
		{
			return 1.0;
		}

		public int imethod_0()
		{
			return 0;
		}
	}

	public override int imethod_0()
	{
		return 1;
	}

	public override Interface180 imethod_1()
	{
		return new Class5386();
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		object obj = args[0].vmethod_9();
		if (obj == null)
		{
			throw new Exception55("Non numeric operand to proportional-column-width() function.");
		}
		Class5634 @class = pInfo.method_3();
		if (!"fo:table-column".Equals(@class.method_0().method_17()))
		{
			throw new Exception55("proportional-column-width() function may only be used on fo:table-column.");
		}
		Class5156 class2 = (Class5156)@class.method_1();
		if (class2.method_56())
		{
			throw new Exception55("proportional-column-width() function may only be used when fo:table has table-layout=\"fixed\".");
		}
		return new Class5038(Convert.ToDouble(obj), pInfo.method_2());
	}
}
