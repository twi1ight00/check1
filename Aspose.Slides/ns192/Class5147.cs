using ns171;
using ns178;
using ns187;

namespace ns192;

internal class Class5147 : Class5094, Interface222
{
	private Class5715 class5715_0;

	private static bool bool_1;

	private bool bool_2;

	private bool bool_3;

	public Class5147(Class5088 parent)
		: base(parent)
	{
		if (!bool_1)
		{
			method_5().imethod_13(this, method_17(), "fo:table-and-caption", method_1());
			bool_1 = true;
		}
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
	}

	internal override void vmethod_11()
	{
		if (!bool_3)
		{
			method_13("marker* table-caption? table");
		}
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if (localName.Equals("marker"))
		{
			if (bool_2)
			{
				method_9(loc, "fo:marker", "fo:table-caption");
			}
			else if (bool_3)
			{
				method_9(loc, "fo:marker", "fo:table");
			}
		}
		else if (localName.Equals("table-caption"))
		{
			if (bool_2)
			{
				method_8(loc, "fo:table-caption");
			}
			else if (bool_3)
			{
				method_9(loc, "fo:table-caption", "fo:table");
			}
			else
			{
				bool_2 = true;
			}
		}
		else if (localName.Equals("table"))
		{
			if (bool_3)
			{
				method_8(loc, "fo:table");
			}
			else
			{
				bool_3 = true;
			}
		}
		else
		{
			method_11(loc, nsURI, localName);
		}
	}

	public override string vmethod_21()
	{
		return "table-and-caption";
	}

	public override int vmethod_24()
	{
		return 72;
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}
}
