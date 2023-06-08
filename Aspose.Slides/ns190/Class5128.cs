using ns171;
using ns178;

namespace ns190;

internal class Class5128 : Class5094
{
	private string string_3;

	private bool bool_1;

	public Class5128(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		string_3 = pList.method_5(98).vmethod_13();
	}

	internal override void vmethod_10()
	{
		if (string.IsNullOrEmpty(string_3))
		{
			method_15("flow-name");
		}
		vmethod_3().vmethod_14(this);
	}

	internal override void vmethod_11()
	{
		if (!bool_1)
		{
			method_13("marker* (%block;)+");
		}
		vmethod_3().vmethod_15(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if (localName.Equals("marker"))
		{
			if (bool_1)
			{
				method_9(loc, "fo:marker", "(%block;)");
			}
		}
		else if (!method_33(nsURI, localName))
		{
			method_11(loc, nsURI, localName);
		}
		else
		{
			bool_1 = true;
		}
	}

	public override bool vmethod_30()
	{
		return true;
	}

	public string method_48()
	{
		return string_3;
	}

	public override string vmethod_21()
	{
		return "flow";
	}

	public override int vmethod_24()
	{
		return 16;
	}
}
