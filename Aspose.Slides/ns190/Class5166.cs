using ns171;
using ns178;

namespace ns190;

internal class Class5166 : Class5094
{
	private string string_3;

	private string string_4;

	private int int_1;

	public Class5166(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		string_3 = pList.method_5(232).vmethod_13();
		string_4 = pList.method_5(73).vmethod_13();
		int_1 = pList.method_5(204).imethod_0();
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public string method_48()
	{
		return string_4;
	}

	public override string vmethod_21()
	{
		return "color-profile";
	}

	public override int vmethod_24()
	{
		return 11;
	}

	public string method_49()
	{
		return string_3;
	}

	public int method_50()
	{
		return int_1;
	}
}
