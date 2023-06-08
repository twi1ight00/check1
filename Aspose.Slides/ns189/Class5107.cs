using ns171;
using ns178;

namespace ns189;

internal class Class5107 : Class5096
{
	private bool bool_1;

	public Class5107(Class5088 parent)
		: base(parent)
	{
	}

	internal override void vmethod_10()
	{
		base.vmethod_10();
		vmethod_3().vmethod_60(this);
	}

	internal override void vmethod_11()
	{
		base.vmethod_11();
		vmethod_3().vmethod_61(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if ("marker".Equals(localName))
		{
			if (bool_1)
			{
				method_9(loc, "fo:marker", "(#PCDATA|%inline;|%block;)");
			}
		}
		else if (method_35(nsURI, localName))
		{
			try
			{
				Class5088.smethod_0(class5088_0, loc, nsURI, localName);
			}
			catch (Exception54)
			{
				method_12(loc, method_17(), "http://www.w3.org/1999/XSL/Format", localName, "rule.wrapperInvalidChildForParent");
			}
			bool_1 = true;
		}
		else
		{
			method_11(loc, nsURI, localName);
		}
	}

	internal override void vmethod_12(Class5088 child)
	{
		base.vmethod_12(child);
		if (child is Class5172 && ((Class5172)child).method_26())
		{
			Class5088 @class = class5088_0;
			while (@class.vmethod_24() == 81)
			{
				@class = @class.method_4();
			}
			if (!(@class is Class5096))
			{
				method_12(method_1(), vmethod_21(), "http://www.w3.org/1999/XSL/Format", "#PCDATA", "rule.wrapperInvalidChildForParent");
			}
		}
	}

	public override string vmethod_21()
	{
		return "wrapper";
	}

	public override int vmethod_24()
	{
		return 81;
	}

	public override bool vmethod_26(int boundary)
	{
		return false;
	}
}
