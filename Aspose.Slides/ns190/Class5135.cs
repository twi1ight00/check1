using System.Drawing;
using ns171;
using ns176;
using ns178;
using ns187;
using ns205;

namespace ns190;

internal abstract class Class5135 : Class5094
{
	private Class5703 class5703_0;

	private int int_1;

	private int int_2;

	private string string_3;

	private Interface181 interface181_0;

	private Class5445 class5445_0;

	protected Class5171 class5171_0;

	protected Class5135(Class5088 parent)
		: base(parent)
	{
		class5171_0 = (Class5171)parent;
	}

	public override void vmethod_2(Class5634 pList)
	{
		class5703_0 = pList.method_17();
		int_1 = pList.method_5(87).imethod_0();
		int_2 = pList.method_5(169).imethod_0();
		string_3 = pList.method_5(199).vmethod_13();
		interface181_0 = pList.method_5(197).vmethod_10();
		class5445_0 = Class5445.smethod_1(pList.method_5(267).imethod_0());
		if (string.IsNullOrEmpty(string_3))
		{
			string_3 = vmethod_33();
		}
		else if (method_48(method_53()) && !method_53().Equals(vmethod_33()))
		{
			method_5().imethod_20(this, method_17(), string_3, method_1());
		}
		if (method_52().method_19(discard: false, null) != 0 || method_52().method_18(discard: false, null) != 0)
		{
			method_5().imethod_21(this, method_17(), string_3, canRecover: true, method_1());
		}
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			method_11(loc, nsURI, localName);
		}
	}

	public abstract RectangleF vmethod_32(Class5728 pageRefRect);

	internal abstract string vmethod_33();

	protected bool method_48(string name)
	{
		if (!name.Equals("xsl-region-before") && !name.Equals("xsl-region-start") && !name.Equals("xsl-region-end") && !name.Equals("xsl-region-after") && !name.Equals("xsl-before-float-separator"))
		{
			return name.Equals("xsl-footnote-separator");
		}
		return true;
	}

	protected Interface172 method_49(int lengthBase)
	{
		return class5171_0.method_49(lengthBase);
	}

	protected Interface172 method_50(int lengthBase)
	{
		return class5171_0.method_50(lengthBase);
	}

	public override bool vmethod_30()
	{
		return true;
	}

	protected Class5135 method_51(int regionId)
	{
		return class5171_0.method_51(regionId);
	}

	public Class5703 method_52()
	{
		return class5703_0;
	}

	public string method_53()
	{
		return string_3;
	}

	public int method_54()
	{
		return int_2;
	}

	public int method_55()
	{
		return int_1;
	}

	public int method_56()
	{
		return interface181_0.imethod_5();
	}

	public Class5445 method_57()
	{
		return class5445_0;
	}
}
