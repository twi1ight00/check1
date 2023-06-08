using ns171;
using ns178;

namespace ns189;

internal class Class5116 : Class5094
{
	private static bool bool_1;

	private bool bool_2;

	private bool bool_3;

	public Class5116(Class5088 parent)
		: base(parent)
	{
		if (!bool_1)
		{
			method_5().imethod_13(this, method_17(), method_17(), method_1());
			bool_1 = true;
		}
	}

	internal override void vmethod_11()
	{
		if (!bool_2 || !bool_3)
		{
			method_13("(multi-property-set+, wrapper)");
		}
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if (localName.Equals("multi-property-set"))
		{
			if (bool_3)
			{
				method_9(loc, "fo:multi-property-set", "fo:wrapper");
			}
			else
			{
				bool_2 = true;
			}
		}
		else if (localName.Equals("wrapper"))
		{
			if (bool_3)
			{
				method_8(loc, "fo:wrapper");
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
		return "multi-properties";
	}

	public override int vmethod_24()
	{
		return 46;
	}
}
