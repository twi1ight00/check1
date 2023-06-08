using System;
using System.Collections;
using ns171;
using ns173;
using ns183;
using ns189;

namespace ns196;

internal abstract class Class5280 : Class5279
{
	protected Interface173 interface173_0;

	protected ArrayList arrayList_0;

	protected Interface168 interface168_0;

	private Hashtable hashtable_0;

	private bool bool_2;

	internal Interface173 interface173_1;

	protected Interface168 interface168_1;

	private int int_0 = -1;

	private int int_1 = int.MaxValue;

	public Class5280()
	{
	}

	public Class5280(Class5094 fo)
		: base(fo)
	{
		if (fo == null)
		{
			throw new InvalidOperationException("Null formatting object found.");
		}
		hashtable_0 = fo.method_32();
		interface168_0 = fo.vmethod_15();
		interface168_1 = new Class5403(this);
	}

	public override void imethod_1(Interface173 lm)
	{
		interface173_0 = lm;
	}

	public override Interface173 imethod_2()
	{
		return interface173_0;
	}

	public override void imethod_3()
	{
	}

	protected Interface173 method_9()
	{
		if (interface173_1 != null && !interface173_1.imethod_5())
		{
			return interface173_1;
		}
		if (interface168_1.imethod_0())
		{
			interface173_1 = (Interface173)interface168_1.imethod_1();
			interface173_1.imethod_3();
			return interface173_1;
		}
		return null;
	}

	protected void method_10(Interface173 childLM)
	{
		interface173_1 = childLM;
		interface168_1 = new Class5403(this);
		do
		{
			interface173_1 = (Interface173)interface168_1.imethod_1();
		}
		while (interface173_1 != childLM);
	}

	internal bool method_11()
	{
		return interface168_1.imethod_0();
	}

	protected Interface173 method_12()
	{
		return (Interface173)interface168_1.imethod_1();
	}

	protected Interface173 method_13()
	{
		return (Interface173)interface168_1.imethod_3();
	}

	public override bool imethod_5()
	{
		return bool_2;
	}

	public override void imethod_6(bool fin)
	{
		bool_2 = fin;
	}

	public override void imethod_9(Class5652 posIter, Class5687 context)
	{
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		imethod_6(fin: true);
		return null;
	}

	public override ArrayList imethod_15(ArrayList oldList, int alignment)
	{
		return null;
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		return null;
	}

	public override void imethod_8(Class4942 childArea)
	{
	}

	protected ArrayList method_14(int size)
	{
		if (interface168_0 == null)
		{
			return null;
		}
		ArrayList arrayList = new ArrayList(size);
		while (interface168_0.imethod_0() && arrayList.Count < size)
		{
			object obj = interface168_0.imethod_1();
			if (obj is Class5088)
			{
				Class5088 @class = (Class5088)obj;
				if (@class is Class5105)
				{
					@class = imethod_4().method_33((Class5105)@class);
				}
				if (@class != null)
				{
					imethod_4().method_24().imethod_0(@class, arrayList);
				}
			}
		}
		return arrayList;
	}

	public override Class5322 imethod_4()
	{
		return interface173_0.imethod_4();
	}

	public virtual Class5690 vmethod_0()
	{
		return imethod_4().vmethod_0();
	}

	public Class4974 method_15()
	{
		return imethod_4().vmethod_0().method_1();
	}

	public override bool imethod_10(int pos)
	{
		ArrayList newLMs = method_14(pos + 1 - arrayList_0.Count);
		imethod_13(newLMs);
		return pos < arrayList_0.Count;
	}

	public override ArrayList imethod_11()
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList(10);
		}
		return arrayList_0;
	}

	public override void imethod_12(Interface173 lm)
	{
		if (lm != null)
		{
			lm.imethod_1(this);
			if (arrayList_0 == null)
			{
				arrayList_0 = new ArrayList(10);
			}
			arrayList_0.Add(lm);
		}
	}

	public override void imethod_13(ArrayList newLMs)
	{
		if (newLMs == null || newLMs.Count == 0)
		{
			return;
		}
		foreach (Interface173 newLM in newLMs)
		{
			imethod_12(newLM);
		}
	}

	public override Class5254 imethod_22(Class5254 pos)
	{
		if (pos.method_4() >= 0)
		{
			throw new InvalidOperationException("Position already got its index");
		}
		pos.method_3(++int_0);
		return pos;
	}

	private static void smethod_0(Class5254 pos)
	{
		if (pos == null || pos.method_4() < 0)
		{
			throw new ArgumentException("Only non-null Positions with an index can be checked");
		}
	}

	public bool method_16(Class5254 pos)
	{
		smethod_0(pos);
		if (pos.method_4() == int_1)
		{
			return true;
		}
		if (pos.method_4() < int_1)
		{
			int_1 = pos.method_4();
			return true;
		}
		return false;
	}

	public bool method_17(Class5254 pos)
	{
		smethod_0(pos);
		if (pos.method_4() == int_0)
		{
			return imethod_5();
		}
		return false;
	}

	protected void method_18(Class4941 targetArea)
	{
		Hashtable atts = class5094_0.method_47();
		targetArea.method_1(atts);
	}

	protected void method_19(Class4941 targetArea)
	{
		if (class5094_0.method_45())
		{
			targetArea.method_6(class5094_0.method_44());
		}
	}

	protected void method_20(Class4941 targetArea)
	{
		method_18(targetArea);
		method_19(targetArea);
	}

	internal void method_21(bool isStarting, bool isFirst, bool isLast)
	{
		if (hashtable_0 != null)
		{
			method_15().method_23(hashtable_0, isStarting, isFirst, isLast);
		}
	}

	internal virtual void vmethod_1()
	{
		if (class5094_0 != null)
		{
			imethod_4().method_29(class5094_0.vmethod_31());
		}
	}

	protected void method_22()
	{
		if (class5094_0 != null)
		{
			imethod_4().method_31(class5094_0.vmethod_31());
		}
	}

	internal void method_23(Class5254 pos)
	{
		if (pos != null && pos.method_0() == this && method_17(pos))
		{
			method_22();
			arrayList_0 = null;
			interface173_1 = null;
			interface168_1 = null;
			hashtable_0 = null;
			Interface173 @interface = interface173_0;
			while (!(@interface is Class5297) && !(@interface is Class5322))
			{
				@interface = @interface.imethod_2();
			}
			if (@interface is Class5297)
			{
				class5094_0.method_38();
				interface168_0 = null;
			}
		}
	}

	public override string ToString()
	{
		return base.ToString() + ((class5094_0 != null) ? ("{fobj = " + class5094_0.ToString() + "}") : string.Empty);
	}

	public override void imethod_23()
	{
		bool_2 = false;
		interface173_1 = null;
		interface168_1 = new Class5403(this);
		foreach (Interface173 item in imethod_11())
		{
			item.imethod_23();
		}
		if (class5094_0 != null)
		{
			hashtable_0 = class5094_0.method_32();
		}
		int_0 = -1;
	}
}
