using ns171;
using ns178;
using ns187;

namespace ns189;

internal class Class5124 : Class5094, Interface222
{
	private Class5715 class5715_0;

	private Class5100 class5100_0;

	private Class5112 class5112_0;

	public Class5124(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		class5715_0 = Class5715.smethod_0(pList);
	}

	internal override void vmethod_10()
	{
		vmethod_3().vmethod_54(this);
	}

	internal override void vmethod_11()
	{
		base.vmethod_11();
		if (class5100_0 == null || class5112_0 == null)
		{
			method_13("(inline,footnote-body)");
		}
		vmethod_3().vmethod_55(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if (localName.Equals("inline"))
		{
			if (class5100_0 != null)
			{
				method_8(loc, "fo:inline");
			}
		}
		else if (localName.Equals("footnote-body"))
		{
			if (class5100_0 == null)
			{
				method_9(loc, "fo:inline", "fo:footnote-body");
			}
			else if (class5112_0 != null)
			{
				method_8(loc, "fo:footnote-body");
			}
		}
		else
		{
			method_11(loc, nsURI, localName);
		}
	}

	internal override void vmethod_12(Class5088 child)
	{
		if (child.vmethod_24() == 35)
		{
			class5100_0 = (Class5100)child;
		}
		else if (child.vmethod_24() == 25)
		{
			class5112_0 = (Class5112)child;
		}
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}

	public Class5100 method_48()
	{
		return class5100_0;
	}

	public Class5112 method_49()
	{
		return class5112_0;
	}

	public override string vmethod_21()
	{
		return "footnote";
	}

	public override int vmethod_24()
	{
		return 24;
	}
}
