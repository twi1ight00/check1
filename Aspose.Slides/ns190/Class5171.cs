using System.Collections;
using ns171;
using ns176;
using ns178;
using ns187;
using ns205;

namespace ns190;

internal class Class5171 : Class5094
{
	private Class5718 class5718_0;

	private string string_3;

	private Interface182 interface182_0;

	private Interface182 interface182_1;

	private Interface181 interface181_0;

	private Class5445 class5445_0;

	private Hashtable hashtable_2;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	public Class5171(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		class5718_0 = pList.method_20();
		string_3 = pList.method_5(153).vmethod_13();
		interface182_0 = pList.method_5(183).vmethod_0();
		interface182_1 = pList.method_5(186).vmethod_0();
		interface181_0 = pList.method_5(197).vmethod_10();
		class5445_0 = Class5445.smethod_1(pList.method_5(267).imethod_0());
		if (string.IsNullOrEmpty(string_3))
		{
			method_15("master-name");
		}
	}

	internal override void vmethod_10()
	{
		Class5168 @class = (Class5168)class5088_0;
		if (string_3 == null)
		{
			method_15("master-name");
		}
		else
		{
			@class.method_50(this);
		}
		hashtable_2 = new Hashtable(5);
	}

	internal override void vmethod_11()
	{
		if (!bool_1)
		{
			method_13("(region-body, region-before?, region-after?, region-start?, region-end?)");
		}
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if (!"http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			return;
		}
		if (localName.Equals("region-body"))
		{
			if (bool_1)
			{
				method_8(loc, "fo:region-body");
			}
			else
			{
				bool_1 = true;
			}
		}
		else if (localName.Equals("region-before"))
		{
			if (!bool_1)
			{
				method_9(loc, "fo:region-body", "fo:region-before");
			}
			else if (bool_2)
			{
				method_8(loc, "fo:region-before");
			}
			else if (bool_3)
			{
				method_9(loc, "fo:region-before", "fo:region-after");
			}
			else if (bool_4)
			{
				method_9(loc, "fo:region-before", "fo:region-start");
			}
			else if (bool_5)
			{
				method_9(loc, "fo:region-before", "fo:region-end");
			}
			else
			{
				bool_2 = true;
			}
		}
		else if (localName.Equals("region-after"))
		{
			if (!bool_1)
			{
				method_9(loc, "fo:region-body", "fo:region-after");
			}
			else if (bool_3)
			{
				method_8(loc, "fo:region-after");
			}
			else if (bool_4)
			{
				method_9(loc, "fo:region-after", "fo:region-start");
			}
			else if (bool_5)
			{
				method_9(loc, "fo:region-after", "fo:region-end");
			}
			else
			{
				bool_3 = true;
			}
		}
		else if (localName.Equals("region-start"))
		{
			if (!bool_1)
			{
				method_9(loc, "fo:region-body", "fo:region-start");
			}
			else if (bool_4)
			{
				method_8(loc, "fo:region-start");
			}
			else if (bool_5)
			{
				method_9(loc, "fo:region-start", "fo:region-end");
			}
			else
			{
				bool_4 = true;
			}
		}
		else if (localName.Equals("region-end"))
		{
			if (!bool_1)
			{
				method_9(loc, "fo:region-body", "fo:region-end");
			}
			else if (bool_5)
			{
				method_8(loc, "fo:region-end");
			}
			else
			{
				bool_5 = true;
			}
		}
		else
		{
			method_11(loc, nsURI, localName);
		}
	}

	public override bool vmethod_30()
	{
		return true;
	}

	internal override void vmethod_12(Class5088 child)
	{
		if (child is Class5135)
		{
			method_48((Class5135)child);
		}
		else
		{
			base.vmethod_12(child);
		}
	}

	protected void method_48(Class5135 region)
	{
		hashtable_2[region.vmethod_24().ToString()] = region;
	}

	internal Interface172 method_49(int lengthBase)
	{
		if (interface181_0.imethod_5() % 180 != 0)
		{
			return new Class5753(null, lengthBase, method_57().imethod_5());
		}
		return new Class5753(null, lengthBase, method_56().imethod_5());
	}

	internal Interface172 method_50(int lengthBase)
	{
		if (interface181_0.imethod_5() % 180 != 0)
		{
			return new Class5753(null, lengthBase, method_56().imethod_5());
		}
		return new Class5753(null, lengthBase, method_57().imethod_5());
	}

	public Class5135 method_51(int regionId)
	{
		return (Class5135)hashtable_2[regionId.ToString()];
	}

	public Hashtable method_52()
	{
		return hashtable_2;
	}

	internal bool method_53(string regionName)
	{
		foreach (Class5135 value in hashtable_2.Values)
		{
			if (value.method_53().Equals(regionName))
			{
				return true;
			}
		}
		return false;
	}

	public Class5718 method_54()
	{
		return class5718_0;
	}

	public string method_55()
	{
		return string_3;
	}

	public Interface182 method_56()
	{
		return interface182_1;
	}

	public Interface182 method_57()
	{
		return interface182_0;
	}

	public int method_58()
	{
		return interface181_0.imethod_5();
	}

	public Class5445 method_59()
	{
		return class5445_0;
	}

	public override string vmethod_21()
	{
		return "simple-page-master";
	}

	public override int vmethod_24()
	{
		return 68;
	}
}
