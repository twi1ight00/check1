using System.Collections;
using ns171;
using ns178;
using ns190;

namespace ns193;

internal class Class5164 : Class5094
{
	private ArrayList arrayList_1 = new ArrayList();

	public Class5164(Class5088 parent)
		: base(parent)
	{
	}

	internal override void vmethod_12(Class5088 obj)
	{
		if (obj is Class5162)
		{
			arrayList_1.Add(obj);
		}
	}

	internal override void vmethod_11()
	{
		if (arrayList_1 == null)
		{
			method_13("(fo:bookmark+)");
		}
		((Class5170)class5088_0).method_61(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI) && !localName.Equals("bookmark"))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public ArrayList method_48()
	{
		return arrayList_1;
	}

	public override string vmethod_21()
	{
		return "bookmark-tree";
	}

	public override int vmethod_24()
	{
		return 5;
	}
}
