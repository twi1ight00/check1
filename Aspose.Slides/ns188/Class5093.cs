using ns171;
using ns178;
using ns190;

namespace ns188;

internal class Class5093 : Class5088
{
	private string string_2;

	private Class5170 class5170_0;

	public Class5093(Class5088 parent)
		: base(parent)
	{
		class5170_0 = parent.vmethod_20();
	}

	public override void vmethod_6(string elementName, Interface243 locatoR, Interface236 attlist, Class5634 pList)
	{
		string_2 = attlist.imethod_5("internal-destination");
		if (string_2 == null || string_2.Length == 0)
		{
			method_15("internal-destination");
		}
	}

	internal override void vmethod_11()
	{
		class5170_0.method_62(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		method_11(loc, nsURI, localName);
	}

	public string method_25()
	{
		return string_2;
	}

	public override string vmethod_23()
	{
		return "http://xmlgraphics.apache.org/fop/extensions";
	}

	public override string vmethod_22()
	{
		return "fox";
	}

	public override string vmethod_21()
	{
		return "destination";
	}
}
