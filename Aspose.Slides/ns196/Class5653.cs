using System.Collections;
using ns183;

namespace ns196;

internal class Class5653 : Class5652
{
	private int int_0;

	public Class5653(ArrayList elementList, int startPos, int endPos)
		: base(new Class5495(elementList, startPos))
	{
		int_0 = endPos - startPos;
	}

	public Class5653(ArrayList elementList)
		: this(elementList, 0, elementList.Count)
	{
	}

	protected override bool vmethod_2()
	{
		if (int_0 > 0)
		{
			return base.vmethod_2();
		}
		method_2();
		return false;
	}

	public override object imethod_1()
	{
		int_0--;
		return base.imethod_1();
	}

	public Class5328 method_4()
	{
		return (Class5328)method_3();
	}

	protected override Interface173 vmethod_0(object nextObj)
	{
		return ((Class5328)nextObj).method_2();
	}

	protected override Class5254 vmethod_1(object nextObj)
	{
		return ((Class5328)nextObj).method_0();
	}
}
