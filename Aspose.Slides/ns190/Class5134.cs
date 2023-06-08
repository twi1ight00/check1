using ns171;
using ns178;

namespace ns190;

internal class Class5134 : Class5094
{
	private string string_3;

	private string string_4;

	public Class5134(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		string_3 = pList.method_6(Enum679.const_211).vmethod_13();
		string_4 = pList.method_6(Enum679.const_212).vmethod_13();
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI) && !localName.Equals("page-sequence") && !localName.Equals("page-sequence-wrapper"))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public string method_48()
	{
		return string_3;
	}

	public string method_49()
	{
		return string_4;
	}

	public override string vmethod_21()
	{
		return "page-sequence-wrapper";
	}

	public override int vmethod_24()
	{
		return 55;
	}
}
