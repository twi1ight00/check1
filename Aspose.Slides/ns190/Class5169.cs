using System;
using System.Collections;
using ns171;
using ns178;
using ns196;

namespace ns190;

internal class Class5169 : Class5094
{
	private string string_3;

	private Class5168 class5168_0;

	private ArrayList arrayList_1;

	private Interface232 interface232_0;

	private int int_1 = -1;

	private Interface206 interface206_0;

	public Class5169(Class5088 parent, Interface206 blockLevelEventProducer)
		: base(parent)
	{
		interface206_0 = blockLevelEventProducer;
	}

	public override void vmethod_2(Class5634 pList)
	{
		string_3 = pList.method_5(153).vmethod_13();
		if (string.IsNullOrEmpty(string_3))
		{
			method_15("master-name");
		}
	}

	internal override void vmethod_10()
	{
		arrayList_1 = new ArrayList();
		class5168_0 = class5088_0.vmethod_20().method_57();
		class5168_0.method_53(string_3, this);
	}

	internal override void vmethod_11()
	{
		if (class5088_2 == null)
		{
			method_13("(single-page-master-reference|repeatable-page-master-reference|repeatable-page-master-alternatives)+");
		}
	}

	internal override void vmethod_8(Interface243 loc, string nsURI, string localName)
	{
		if ("http://www.w3.org/1999/XSL/Format".Equals(nsURI) && !"single-page-master-reference".Equals(localName) && !"repeatable-page-master-reference".Equals(localName) && !"repeatable-page-master-alternatives".Equals(localName))
		{
			method_11(loc, nsURI, localName);
		}
	}

	internal void method_48(Interface232 pageMasterReference)
	{
		arrayList_1.Add(pageMasterReference);
	}

	private Interface232 method_49()
	{
		int_1++;
		if (int_1 >= 0 && int_1 < arrayList_1.Count)
		{
			return (Interface232)arrayList_1[int_1];
		}
		return null;
	}

	internal ArrayList method_50()
	{
		return arrayList_1;
	}

	public void method_51()
	{
		int_1 = -1;
		interface232_0 = null;
		if (arrayList_1 == null)
		{
			return;
		}
		foreach (Interface232 item in arrayList_1)
		{
			item.imethod_1();
		}
	}

	public bool method_52()
	{
		if (interface232_0 != null && !interface232_0.imethod_2())
		{
			if (int_1 > 0)
			{
				int_1--;
				interface232_0 = (Interface232)arrayList_1[int_1];
			}
			else
			{
				interface232_0 = null;
			}
		}
		return interface232_0 != null;
	}

	public bool method_53()
	{
		if (interface232_0 != null)
		{
			return interface232_0.imethod_3();
		}
		return false;
	}

	public bool method_54()
	{
		if (interface232_0 != null)
		{
			return interface232_0.imethod_4();
		}
		return false;
	}

	public Class5171 method_55(bool isOddPage, bool isFirstPage, bool isLastPage, bool isBlankPage, string mainFlowName)
	{
		if (interface232_0 == null)
		{
			interface232_0 = method_49();
			if (interface232_0 == null)
			{
				interface206_0.imethod_8(this, string_3, method_1());
			}
			if (interface232_0.imethod_7() && !interface232_0.imethod_6(mainFlowName))
			{
				throw new Exception("The current sub-sequence will not terminate whilst processing then main flow");
			}
		}
		Class5171 @class = interface232_0.imethod_0(isOddPage, isFirstPage, isLastPage, isBlankPage);
		bool flag = true;
		while (@class == null)
		{
			Interface232 @interface = method_49();
			if (@interface == null)
			{
				interface206_0.imethod_7(this, string_3, flag & interface232_0.imethod_8(), method_1());
				interface232_0.imethod_1();
				if (!interface232_0.imethod_6(mainFlowName))
				{
					throw new Exception("The last simple-page-master does not reference the main flow");
				}
				flag = false;
			}
			else
			{
				interface232_0 = @interface;
			}
			@class = interface232_0.imethod_0(isOddPage, isFirstPage, isLastPage, isBlankPage);
			if (@class == null && !flag)
			{
				throw new Exception("The current sub-sequence will not terminate whilst processing then main flow");
			}
		}
		return @class;
	}

	public override string vmethod_21()
	{
		return "page-sequence-master";
	}

	public override int vmethod_24()
	{
		return 54;
	}
}
