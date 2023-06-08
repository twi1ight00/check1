using ns171;
using ns178;

namespace ns189;

internal class Class5104 : Class5103
{
	private int int_1;

	private int int_2;

	public Class5104(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_6(string elementName, Interface243 locatoR, Interface236 attlist, Class5634 pList)
	{
		if (method_37(78) < 0 && method_37(77) < 0)
		{
			method_12(interface243_0, method_4().method_17(), "http://www.w3.org/1999/XSL/Format", method_17(), "rule.retrieveTableMarkerDescendantOfHeaderOrFooter");
		}
		else
		{
			base.vmethod_6(elementName, locatoR, attlist, pList);
		}
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		int_1 = pList.method_5(209).imethod_0();
		int_2 = pList.method_5(206).imethod_0();
	}

	public int method_56()
	{
		return int_1;
	}

	public int method_57()
	{
		return int_2;
	}

	public override string vmethod_21()
	{
		return "retrieve-table-marker";
	}

	public override int vmethod_24()
	{
		return 65;
	}
}
