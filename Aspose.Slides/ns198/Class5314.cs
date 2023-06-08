using System.Collections;
using ns171;
using ns173;
using ns176;
using ns181;
using ns183;
using ns187;
using ns195;
using ns196;
using ns205;

namespace ns198;

internal abstract class Class5314 : Class5280, Interface172, Interface173, Interface175
{
	protected Class5746 class5746_0;

	private Class4942 class4942_0;

	protected Class5687 class5687_0;

	protected Class5314(Class5094 node)
		: base(node)
	{
		class5746_0 = Class5746.class5746_0;
	}

	public void method_24(Interface168 iter)
	{
		interface168_1 = iter;
	}

	protected virtual Class5746 vmethod_2(bool bNotFirst, bool bNotLast)
	{
		return Class5746.class5746_0;
	}

	public override int imethod_16()
	{
		return imethod_2()?.imethod_16() ?? 0;
	}

	protected virtual bool vmethod_3(bool bNotFirst)
	{
		return false;
	}

	protected virtual bool vmethod_4(bool bNotLast)
	{
		return false;
	}

	protected virtual Class5046 vmethod_5()
	{
		return null;
	}

	protected virtual Class5046 vmethod_6()
	{
		return null;
	}

	protected Class4942 method_25()
	{
		return class4942_0;
	}

	protected void method_26(Class4942 area)
	{
		class4942_0 = area;
	}

	protected virtual void vmethod_7(bool bNotFirst, bool bNotLast)
	{
	}

	protected void method_27(Class5687 lc)
	{
		class5687_0 = lc;
	}

	protected Class5687 method_28()
	{
		return class5687_0;
	}

	protected void method_29(Class4942 parentArea, Class5746 spaceRange, double spaceAdjust)
	{
		if (spaceRange == null)
		{
			return;
		}
		int num = spaceRange.method_2();
		if (spaceAdjust > 0.0)
		{
			num += (int)((double)spaceRange.method_5() * spaceAdjust);
		}
		else if (spaceAdjust < 0.0)
		{
			num += (int)((double)spaceRange.method_4() * spaceAdjust);
		}
		if (num != 0)
		{
			Class4954 @class = new Class4954();
			@class.method_11(num);
			int num2 = parentArea.method_18();
			if (num2 >= 0)
			{
				@class.method_16(num2);
			}
			parentArea.vmethod_2(@class);
		}
	}

	public ArrayList imethod_27(ArrayList oldList)
	{
		return imethod_28(oldList, 0);
	}

	public ArrayList imethod_28(ArrayList oldList, int thisDepth)
	{
		Interface168 @interface = new Class5495(oldList, oldList.Count);
		Class5337 @class = (Class5337)@interface.imethod_3();
		int depth = thisDepth + 1;
		Class5254 class2 = @class.method_0();
		Interface175 interface2 = null;
		if (class2 != null)
		{
			interface2 = (Interface175)class2.method_1(depth);
		}
		if (interface2 == null)
		{
			return oldList;
		}
		oldList = interface2.imethod_28(oldList, depth);
		@interface = new Class5495(oldList);
		while (@interface.imethod_0())
		{
			@class = (Class5337)@interface.imethod_1();
			class2 = @class.method_0();
			interface2 = null;
			if (class2 != null)
			{
				interface2 = (Interface175)class2.method_1(thisDepth);
			}
			if (interface2 != this)
			{
				@class.method_1(imethod_22(new Class5255(this, @class.method_0())));
			}
		}
		return oldList;
	}

	public string imethod_29(Class5254 pos)
	{
		Class5254 @class = pos.vmethod_0();
		return ((Interface175)@class.method_0()).imethod_29(@class);
	}

	public void imethod_30(Class5254 pos, Class5685 hc)
	{
		Class5254 @class = pos.vmethod_0();
		((Interface175)@class.method_0()).imethod_30(@class, hc);
	}

	public bool imethod_31(ArrayList oldList)
	{
		return imethod_32(oldList, 0);
	}

	public bool imethod_32(ArrayList oldList, int depth)
	{
		Interface168 @interface = new Class5495(oldList);
		depth++;
		Interface175 interface2 = null;
		int index = 0;
		bool flag = false;
		while (@interface.imethod_0())
		{
			Class5337 @class = (Class5337)@interface.imethod_1();
			Class5254 class2 = @class.method_0();
			Interface175 interface3 = ((class2 != null) ? ((Interface175)class2.method_1(depth)) : null);
			if (interface2 == null)
			{
				interface2 = interface3;
			}
			if (interface3 == interface2 && @interface.imethod_0())
			{
				continue;
			}
			if (interface2 != this && interface3 != this)
			{
				if (@interface.imethod_0())
				{
					flag = interface2.imethod_32(oldList.GetRange(index, @interface.imethod_5()), depth) || flag;
					interface2 = interface3;
					index = @interface.imethod_5();
					continue;
				}
				if (interface3 == interface2)
				{
					flag = (interface2 != null && interface2.imethod_32(oldList.GetRange(index, oldList.Count), depth)) || flag;
					continue;
				}
				flag = interface2.imethod_32(oldList.GetRange(index, @interface.imethod_5()), depth) || flag;
				if (interface3 != null)
				{
					flag = interface3.imethod_32(oldList.GetRange(@interface.imethod_5(), oldList.Count), depth) || flag;
				}
			}
			else
			{
				interface2 = interface3;
			}
		}
		return flag;
	}

	public override ArrayList imethod_15(ArrayList oldList, int alignment)
	{
		return imethod_38(oldList, alignment, 0);
	}

	public virtual ArrayList imethod_38(ArrayList oldList, int alignment, int depth)
	{
		Interface168 @interface = new Class5495(oldList);
		depth++;
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		Interface175 interface2 = null;
		int num = 0;
		while (@interface.imethod_0())
		{
			Class5337 @class = (Class5337)@interface.imethod_1();
			Class5254 class2 = @class.method_0();
			Interface175 interface3 = ((class2 != null) ? ((Interface175)class2.method_1(depth)) : null);
			if (interface2 == null)
			{
				interface2 = interface3;
			}
			if (interface3 == interface2 && @interface.imethod_0())
			{
				continue;
			}
			if (@interface.imethod_0())
			{
				Class5693.smethod_2(arrayList, interface2.imethod_38(oldList.GetRange(num, @interface.imethod_5() - num + 1), alignment, depth));
				interface2 = interface3;
				num = @interface.imethod_5();
				continue;
			}
			if (interface3 == interface2)
			{
				Class5693.smethod_2(arrayList, interface2.imethod_38(oldList.GetRange(num, oldList.Count - num + 1), alignment, depth));
				continue;
			}
			Class5693.smethod_2(arrayList, interface2.imethod_38(oldList.GetRange(num, @interface.imethod_5() - num + 1), alignment, depth));
			if (interface3 != null)
			{
				Class5693.smethod_2(arrayList, interface3.imethod_38(oldList.GetRange(@interface.imethod_5(), oldList.Count - @interface.imethod_5() + 1), alignment, depth));
			}
		}
		Interface168 interface4 = new Class5495(arrayList);
		while (interface4.imethod_0())
		{
			Class5337 class3 = (Class5337)interface4.imethod_1();
			class3.method_1(imethod_22(new Class5255(this, class3.method_0())));
			arrayList2.Add(class3);
		}
		return arrayList2;
	}
}
