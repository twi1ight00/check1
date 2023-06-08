using ns171;
using ns178;
using ns187;

namespace ns193;

internal class Class5163 : Class5094, Interface222
{
	private Class5715 class5715_0;

	private string string_3 = string.Empty;

	public Class5163(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
	}

	internal override void vmethod_9(char[] data, int start, int length, Class5634 pList, Interface243 locatoR)
	{
		string_3 += new string(data, start, length);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}

	public string method_48()
	{
		return string_3;
	}

	public override string vmethod_21()
	{
		return "bookmark-title";
	}

	public override int vmethod_24()
	{
		return 7;
	}
}
