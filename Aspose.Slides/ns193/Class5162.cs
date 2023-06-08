using System.Collections;
using ns171;
using ns178;
using ns187;

namespace ns193;

internal class Class5162 : Class5094, Interface222
{
	private Class5163 class5163_0;

	private ArrayList arrayList_1 = new ArrayList();

	private Class5715 class5715_0;

	private string string_3;

	private string string_4;

	private bool bool_1 = true;

	public Class5162(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		class5715_0 = Class5715.smethod_0(pList);
		string_4 = pList.method_5(94).vmethod_13();
		string_3 = pList.method_5(128).vmethod_13();
		bool_1 = pList.method_5(234).imethod_0() == 130;
		if (string_3.Length > 0)
		{
			string_4 = null;
		}
		else if (string_4.Length == 0)
		{
			method_5().imethod_14(this, method_17(), interface243_0);
		}
		else
		{
			method_5().imethod_13(this, method_17(), "external-destination", method_1());
		}
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if (localName.Equals("bookmark-title"))
		{
			if (class5163_0 != null)
			{
				method_8(loc, "fo:bookmark-title");
			}
		}
		else if (localName.Equals("bookmark"))
		{
			if (class5163_0 == null)
			{
				method_9(loc, "fo:bookmark-title", "fo:bookmark");
			}
		}
		else
		{
			method_11(loc, nsURI, localName);
		}
	}

	internal override void vmethod_11()
	{
		if (class5163_0 == null)
		{
			method_13("(bookmark-title, bookmark*)");
		}
	}

	internal override void vmethod_12(Class5088 obj)
	{
		if (obj is Class5163)
		{
			class5163_0 = (Class5163)obj;
		}
		else if (obj is Class5162)
		{
			arrayList_1.Add(obj);
		}
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}

	public string method_48()
	{
		if (class5163_0 != null)
		{
			return class5163_0.method_48();
		}
		return string.Empty;
	}

	public string method_49()
	{
		return string_3;
	}

	public string method_50()
	{
		return string_4;
	}

	public bool method_51()
	{
		return bool_1;
	}

	public ArrayList method_52()
	{
		return arrayList_1;
	}

	public override string vmethod_21()
	{
		return "bookmark";
	}

	public override int vmethod_24()
	{
		return 6;
	}
}
