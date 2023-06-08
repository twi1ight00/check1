using System;
using System.Collections;
using System.Globalization;
using ns171;
using ns178;
using ns187;
using ns188;
using ns193;

namespace ns190;

internal class Class5170 : Class5094, Interface222
{
	private Class5715 class5715_0;

	private Class5168 class5168_0;

	private Class5167 class5167_0;

	private Class5164 class5164_0;

	private ArrayList arrayList_1;

	private ArrayList arrayList_2;

	private CultureInfo cultureInfo_0;

	private bool bool_1;

	private int int_1;

	private int int_2;

	private Class5737 class5737_0;

	private Class4866 class4866_0;

	public Class5170(Class5088 parent)
		: base(parent)
	{
		arrayList_2 = new ArrayList();
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
		string text = pList.method_5(134).vmethod_13();
		string text2 = pList.method_5(81).vmethod_13();
		if (method_48(text))
		{
			if (method_48(text2))
			{
				cultureInfo_0 = new CultureInfo(text + "-" + text2);
			}
			else
			{
				cultureInfo_0 = new CultureInfo(text);
			}
		}
	}

	private bool method_48(string property)
	{
		if (property != null)
		{
			return !property.Equals("none");
		}
		return false;
	}

	internal override void vmethod_10()
	{
		class4866_0.vmethod_4(this);
	}

	internal override void vmethod_11()
	{
		if (!bool_1 || class5168_0 == null)
		{
			method_13("(layout-master-set, declarations?, bookmark-tree?, (page-sequence|fox:external-document)+)");
		}
		class4866_0.vmethod_5(this);
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI))
		{
			if (localName.Equals("layout-master-set"))
			{
				if (class5168_0 != null)
				{
					method_8(loc, "fo:layout-master-set");
				}
			}
			else if (localName.Equals("declarations"))
			{
				if (class5168_0 == null)
				{
					method_9(loc, "fo:layout-master-set", "fo:declarations");
				}
				else if (class5167_0 != null)
				{
					method_8(loc, "fo:declarations");
				}
				else if (class5164_0 != null)
				{
					method_9(loc, "fo:declarations", "fo:bookmark-tree");
				}
				else if (bool_1)
				{
					method_9(loc, "fo:declarations", "fo:page-sequence");
				}
			}
			else if (localName.Equals("bookmark-tree"))
			{
				if (class5168_0 == null)
				{
					method_9(loc, "fo:layout-master-set", "fo:bookmark-tree");
				}
				else if (class5164_0 != null)
				{
					method_8(loc, "fo:bookmark-tree");
				}
				else if (bool_1)
				{
					method_9(loc, "fo:bookmark-tree", "fo:page-sequence");
				}
			}
			else if (localName.Equals("page-sequence"))
			{
				if (class5168_0 == null)
				{
					method_9(loc, "fo:layout-master-set", "fo:page-sequence");
				}
				else
				{
					bool_1 = true;
				}
			}
			else
			{
				method_11(loc, nsURI, localName);
			}
		}
		else if ("http://xmlgraphics.apache.org/fop/extensions".Equals(nsURI) && "external-document".Equals(localName))
		{
			bool_1 = true;
		}
	}

	protected void method_49(Interface243 loc, Class5088 child)
	{
		if (child is Class5125)
		{
			bool_1 = true;
		}
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}

	public void method_50(Class4866 foEventHandler)
	{
		class4866_0 = foEventHandler;
	}

	public override Class4866 vmethod_3()
	{
		return class4866_0;
	}

	public void method_51(Class5737 context)
	{
		class5737_0 = context;
	}

	public override Class5737 vmethod_4()
	{
		return class5737_0;
	}

	public int method_52()
	{
		return int_1;
	}

	public int method_53()
	{
		return int_2;
	}

	public void method_54(int lastPageNumber, int additionalPages)
	{
		if (additionalPages < 0)
		{
			throw new ArgumentException("Number of additional pages must be zero or greater.");
		}
		int_2 += additionalPages;
		int_1 = lastPageNumber;
	}

	public int method_55()
	{
		return arrayList_2.Count;
	}

	public Class5127 method_56(Class5127 current)
	{
		int num = arrayList_2.IndexOf(current);
		if (num == -1)
		{
			return null;
		}
		if (num < arrayList_2.Count - 1)
		{
			return (Class5127)arrayList_2[num + 1];
		}
		return null;
	}

	public Class5168 method_57()
	{
		return class5168_0;
	}

	public void method_58(Class5168 layoutMasterSet)
	{
		class5168_0 = layoutMasterSet;
	}

	public Class5167 method_59()
	{
		return class5167_0;
	}

	public void method_60(Class5167 declarations)
	{
		class5167_0 = declarations;
	}

	public void method_61(Class5164 bookmarkTree)
	{
		class5164_0 = bookmarkTree;
	}

	public void method_62(Class5093 destination)
	{
		if (arrayList_1 == null)
		{
			arrayList_1 = new ArrayList();
		}
		arrayList_1.Add(destination);
	}

	public ArrayList method_63()
	{
		return arrayList_1;
	}

	public Class5164 method_64()
	{
		return class5164_0;
	}

	public override Class5170 vmethod_20()
	{
		return this;
	}

	public override string vmethod_21()
	{
		return "root";
	}

	public override int vmethod_24()
	{
		return 66;
	}

	public CultureInfo method_65()
	{
		return cultureInfo_0;
	}
}
