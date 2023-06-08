using System.Collections;
using ns171;
using ns178;
using ns187;

namespace ns190;

internal class Class5146 : Class5094, Interface232
{
	private Class5024 class5024_0;

	private static int int_1 = -1;

	private int int_2;

	private ArrayList arrayList_1;

	private bool bool_1;

	private bool bool_2;

	public Class5146(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		class5024_0 = pList.method_6(Enum679.const_243);
	}

	internal override void vmethod_10()
	{
		arrayList_1 = new ArrayList();
		Class5169 @class = (Class5169)class5088_0;
		@class.method_48(this);
	}

	internal override void vmethod_11()
	{
		if (class5088_2 == null)
		{
			method_13("(conditional-page-master-reference+)");
		}
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI) && !localName.Equals("conditional-page-master-reference"))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public int method_48()
	{
		if (class5024_0.imethod_0() == 89)
		{
			return int_1;
		}
		int num = class5024_0.vmethod_10().imethod_5();
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public Class5171 imethod_0(bool isOddPage, bool isFirstPage, bool isLastPage, bool isBlankPage)
	{
		if (!imethod_7() && int_2 >= method_48())
		{
			return null;
		}
		int_2++;
		foreach (Class5133 item in arrayList_1)
		{
			if (item.method_49(isOddPage, isFirstPage, isLastPage, isBlankPage))
			{
				return item.method_50();
			}
		}
		return null;
	}

	public void method_49(Class5133 cpmr)
	{
		arrayList_1.Add(cpmr);
		if (cpmr.method_51() == 72)
		{
			bool_1 = true;
		}
		if (cpmr.method_51() == 186)
		{
			bool_2 = true;
		}
	}

	public void imethod_1()
	{
		int_2 = 0;
	}

	public bool imethod_2()
	{
		if (int_2 == 0)
		{
			return false;
		}
		int_2--;
		return true;
	}

	public bool imethod_3()
	{
		return bool_1;
	}

	public bool imethod_4()
	{
		return bool_2;
	}

	public override string vmethod_21()
	{
		return "repeatable-page-master-alternatives";
	}

	public override int vmethod_24()
	{
		return 62;
	}

	public void imethod_5(Class5168 layoutMasterSet)
	{
		foreach (Class5133 item in arrayList_1)
		{
			item.method_52(layoutMasterSet);
		}
	}

	public bool imethod_6(string flowName)
	{
		bool flag = true;
		ArrayList arrayList = new ArrayList();
		foreach (Class5133 item in arrayList_1)
		{
			if (item.method_49(isOddPage: true, isFirstPage: false, isLastPage: false, isBlankPage: false) || item.method_49(isOddPage: false, isFirstPage: false, isLastPage: false, isBlankPage: false))
			{
				arrayList.Add(item);
			}
		}
		if (arrayList.Count != 0)
		{
			flag = false;
			foreach (Class5133 item2 in arrayList)
			{
				flag |= item2.method_50().method_51(58).method_53()
					.Equals(flowName);
			}
		}
		return flag;
	}

	public bool imethod_7()
	{
		return method_48() == int_1;
	}

	public bool imethod_8()
	{
		return false;
	}
}
