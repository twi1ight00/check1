using ns171;
using ns178;
using ns196;

namespace ns190;

internal class Class5144 : Class5094, Interface232
{
	private string string_3;

	private Class5171 class5171_0;

	private static int int_1 = 0;

	private static int int_2 = 1;

	private int int_3;

	public Class5144(Class5088 parent)
		: base(parent)
	{
		int_3 = int_1;
	}

	public override void vmethod_2(Class5634 pList)
	{
		string_3 = pList.method_6(Enum679.const_241).vmethod_13();
		if (string.IsNullOrEmpty(string_3))
		{
			method_15("master-reference");
		}
	}

	internal override void vmethod_10()
	{
		Class5169 @class = (Class5169)class5088_0;
		@class.method_48(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public Class5171 imethod_0(bool isOddPage, bool isFirstPage, bool isLastPage, bool isBlankPage)
	{
		if (int_3 == int_1)
		{
			int_3 = int_2;
			return class5171_0;
		}
		return null;
	}

	public void imethod_1()
	{
		int_3 = int_1;
	}

	public bool imethod_2()
	{
		if (int_3 == int_1)
		{
			return false;
		}
		int_3 = int_1;
		return true;
	}

	public bool imethod_3()
	{
		return false;
	}

	public bool imethod_4()
	{
		return false;
	}

	public override string vmethod_21()
	{
		return "single-page-master-reference";
	}

	public override int vmethod_24()
	{
		return 69;
	}

	public void imethod_5(Class5168 layoutMasterSet)
	{
		class5171_0 = layoutMasterSet.method_52(string_3);
		if (class5171_0 == null)
		{
			Class5701.smethod_0(method_2().method_48()).imethod_9(this, class5088_0.method_17(), string_3, method_1());
		}
	}

	public bool imethod_6(string flowName)
	{
		return class5171_0.method_51(58).method_53().Equals(flowName);
	}

	public bool imethod_7()
	{
		return false;
	}

	public bool imethod_8()
	{
		return true;
	}
}
