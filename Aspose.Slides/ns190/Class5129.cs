using ns171;
using ns178;

namespace ns190;

internal class Class5129 : Class5128
{
	public Class5129(Class5088 parent)
		: base(parent)
	{
	}

	internal override void vmethod_10()
	{
		if (string.IsNullOrEmpty(method_48()))
		{
			method_15("flow-name");
		}
		vmethod_3().vmethod_44(this);
	}

	internal override void vmethod_11()
	{
		if (class5088_2 == null && method_2().method_42())
		{
			method_13("(%block;)+");
		}
		vmethod_3().vmethod_45(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI) && !method_33(nsURI, localName))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public override string vmethod_21()
	{
		return "static-content";
	}

	public override int vmethod_24()
	{
		return 70;
	}
}
