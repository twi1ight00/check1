using System.Collections;
using ns171;
using ns178;

namespace ns190;

internal class Class5167 : Class5094
{
	private Hashtable hashtable_2;

	public Class5167(Class5088 parent)
		: base(parent)
	{
		((Class5170)parent).method_60(this);
	}

	public override void vmethod_2(Class5634 pList)
	{
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI) && !localName.Equals("color-profile"))
		{
			method_11(loc, nsURI, localName);
		}
	}

	internal override void vmethod_11()
	{
		if (class5088_2 != null)
		{
			Interface163 @interface = vmethod_15();
			while (@interface.imethod_0())
			{
				Class5088 @class = @interface.imethod_10();
				if (@class.method_17().Equals("fo:color-profile"))
				{
					Class5166 class2 = (Class5166)@class;
					if (!string.IsNullOrEmpty(class2.method_48()))
					{
						method_48(class2);
					}
					else
					{
						method_5().imethod_4(this, class2.method_17(), "color-profile-name", interface243_0);
					}
				}
			}
		}
		class5088_2 = null;
	}

	private void method_48(Class5166 cp)
	{
		if (hashtable_2 == null)
		{
			hashtable_2 = new Hashtable();
		}
		if (hashtable_2[cp.method_48()] != null)
		{
			method_5().imethod_6(this, cp.method_17(), cp.method_48(), interface243_0);
		}
		hashtable_2.Add(cp.method_48(), cp);
	}

	public override string vmethod_21()
	{
		return "declarations";
	}

	public override int vmethod_24()
	{
		return 13;
	}

	public Class5166 method_49(string cpName)
	{
		Class5166 result = null;
		if (hashtable_2 != null)
		{
			result = (Class5166)hashtable_2[cpName];
		}
		return result;
	}
}
