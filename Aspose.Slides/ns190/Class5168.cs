using System.Collections;
using ns171;
using ns178;

namespace ns190;

internal class Class5168 : Class5094
{
	private Hashtable hashtable_2;

	private Hashtable hashtable_3;

	public Class5168(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
	}

	internal override void vmethod_10()
	{
		vmethod_20().method_58(this);
		hashtable_2 = new Hashtable();
		hashtable_3 = new Hashtable();
	}

	internal override void vmethod_11()
	{
		if (class5088_2 == null)
		{
			method_13("(simple-page-master|page-sequence-master)+");
		}
		method_48();
		method_49();
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI) && !localName.Equals("simple-page-master") && !localName.Equals("page-sequence-master"))
		{
			method_11(loc, nsURI, localName);
		}
	}

	private void method_48()
	{
		Hashtable hashtable = new Hashtable();
		foreach (Class5171 value in hashtable_2.Values)
		{
			Hashtable hashtable2 = value.method_52();
			foreach (Class5135 value2 in hashtable2.Values)
			{
				if (hashtable.ContainsKey(value2.method_53()))
				{
					string text = (string)hashtable[value2.method_53()];
					if (!text.Equals(value2.vmethod_33()))
					{
						method_5().imethod_16(this, value2.method_53(), text, value2.vmethod_33(), method_1());
					}
				}
				hashtable[value2.method_53()] = value2.vmethod_33();
			}
		}
	}

	private void method_49()
	{
		foreach (Class5169 value in hashtable_3.Values)
		{
			foreach (Interface232 item in value.method_50())
			{
				item.imethod_5(this);
			}
		}
	}

	internal void method_50(Class5171 sPM)
	{
		string text = sPM.method_55();
		if (method_51(text))
		{
			method_5().imethod_7(this, method_17(), text, sPM.method_1());
		}
		hashtable_2.Add(text, sPM);
	}

	private bool method_51(string masterName)
	{
		if (!hashtable_2.ContainsKey(masterName))
		{
			return hashtable_3.ContainsKey(masterName);
		}
		return true;
	}

	public Class5171 method_52(string masterName)
	{
		return (Class5171)hashtable_2[masterName];
	}

	internal void method_53(string masterName, Class5169 pSM)
	{
		if (method_51(masterName))
		{
			method_5().imethod_7(this, method_17(), masterName, pSM.method_1());
		}
		hashtable_3.Add(masterName, pSM);
	}

	public Class5169 method_54(string masterName)
	{
		return (Class5169)hashtable_3[masterName];
	}

	public bool method_55(string regionName)
	{
		foreach (Class5171 value in hashtable_2.Values)
		{
			if (value.method_53(regionName))
			{
				return true;
			}
		}
		return false;
	}

	public override string vmethod_21()
	{
		return "layout-master-set";
	}

	public override int vmethod_24()
	{
		return 38;
	}
}
