using ns171;
using ns178;
using ns196;

namespace ns190;

internal class Class5133 : Class5094
{
	private string string_3;

	private Class5171 class5171_0;

	private int int_1;

	private int int_2;

	private int int_3;

	public Class5133(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		string_3 = pList.method_6(Enum679.const_241).vmethod_13();
		int_1 = pList.method_6(Enum679.const_272).imethod_0();
		int_2 = pList.method_6(Enum679.const_254).imethod_0();
		int_3 = pList.method_6(Enum679.const_17).imethod_0();
		if (string.IsNullOrEmpty(string_3))
		{
			method_15("master-reference");
		}
	}

	internal override void vmethod_10()
	{
		method_48().method_49(this);
	}

	private Class5146 method_48()
	{
		return (Class5146)class5088_0;
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		method_11(loc, nsURI, localName);
	}

	internal bool method_49(bool isOddPage, bool isFirstPage, bool isLastPage, bool isBlankPage)
	{
		if ((int_1 != 8 && (int_1 != 50 || !isFirstPage) && (int_1 != 72 || !isLastPage) && (int_1 != 186 || !isFirstPage || !isLastPage) && (int_1 != 117 || isFirstPage || isLastPage)) || (int_2 != 8 && (int_2 != 99 || !isOddPage) && (int_2 != 43 || isOddPage)))
		{
			return false;
		}
		if (int_3 != 8 && (int_3 != 16 || !isBlankPage))
		{
			if (int_3 == 98)
			{
				return !isBlankPage;
			}
			return false;
		}
		return true;
	}

	public Class5171 method_50()
	{
		return class5171_0;
	}

	public int method_51()
	{
		return int_1;
	}

	public override string vmethod_21()
	{
		return "conditional-page-master-reference";
	}

	public override int vmethod_24()
	{
		return 12;
	}

	public void method_52(Class5168 layoutMasterSet)
	{
		class5171_0 = layoutMasterSet.method_52(string_3);
		if (class5171_0 == null)
		{
			Class5701.smethod_0(method_2().method_48()).imethod_9(this, class5088_0.method_17(), string_3, method_1());
		}
	}
}
