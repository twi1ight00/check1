using System.Collections;
using System.Collections.Generic;
using ns173;
using ns176;
using ns183;
using ns184;
using ns187;
using ns189;
using ns197;
using ns198;
using ns199;
using ns205;

namespace ns196;

internal class Class5283 : Class5281, Interface184
{
	protected class Class5404 : Class5403
	{
		private Class5283 class5283_0;

		public Class5404(Class5283 bl)
			: base(bl)
		{
			arrayList_0 = new ArrayList(10);
			class5283_0 = bl;
		}

		public override bool imethod_0()
		{
			if (int_0 >= arrayList_0.Count)
			{
				return method_0(int_0);
			}
			return true;
		}

		protected bool method_0(int pos)
		{
			ArrayList arrayList = class5283_0.method_14(pos + 1 - arrayList_0.Count);
			if (arrayList != null)
			{
				arrayList_0.AddRange(arrayList);
			}
			return pos < arrayList_0.Count;
		}
	}

	private Class4962 class4962_0;

	protected Interface168 interface168_2;

	private int int_10 = 12000;

	private Interface182 interface182_0;

	private int int_11 = 2000;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private Class5746 class5746_0;

	private Class5746 class5746_1;

	public Class5283(Class5106 inBlock)
		: base(inBlock)
	{
		interface168_2 = new Class5404(this);
	}

	public override void imethod_3()
	{
		base.imethod_3();
		Class5106 @class = method_56();
		Class5730 class2 = @class.vmethod_3().vmethod_1();
		Class5732[] array = @class.method_53().method_9(class2);
		Class5729 class3 = class2.method_12(array[0], method_56().method_53().interface182_0.imethod_6(this), @class.method_53().method_5());
		int_10 = class3.method_1();
		int_11 = -class3.method_3();
		interface182_0 = @class.method_63().method_10(this).vmethod_0();
		int_6 = @class.method_50().interface182_4.imethod_6(this);
		int_7 = @class.method_50().interface182_5.imethod_6(this);
		int_3 = @class.method_50().class5046_0.vmethod_5().method_10(this).vmethod_0()
			.imethod_6(this);
		int_4 = @class.method_50().class5046_1.vmethod_5().method_10(this).vmethod_0()
			.imethod_6(this);
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		return imethod_26(context, alignment, null, null, null);
	}

	public override ArrayList imethod_26(Class5687 context, int alignment, Stack lmStack, Class5254 restartPosition, Interface173 restartAtLM)
	{
		method_53();
		return base.imethod_26(context, alignment, lmStack, restartPosition, restartAtLM);
	}

	protected override ArrayList vmethod_6(Interface173 childLM, Class5687 context, Class5687 childLC, int alignment, Stack lmStack, Class5254 restartPosition, Interface173 restartAtLM)
	{
		childLC.method_0(context);
		if (childLM is Class5319)
		{
			childLC.method_30(imethod_16());
		}
		if (childLM == arrayList_0[0])
		{
			childLC.method_1(16);
		}
		if (lmStack == null)
		{
			return childLM.imethod_14(childLC, alignment);
		}
		if (childLM is Class5319)
		{
			return ((Class5319)childLM).method_31(childLC, alignment, (Class5258)restartPosition);
		}
		return childLM.imethod_26(childLC, alignment, lmStack, restartPosition, restartAtLM);
	}

	private void method_53()
	{
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		bool_8 = false;
		class5746_0 = null;
		class5746_1 = null;
	}

	internal static Class5296 smethod_1(Interface173 layoutManager)
	{
		if (layoutManager == null)
		{
			return null;
		}
		if (layoutManager is Class5296 result)
		{
			return result;
		}
		return smethod_1(layoutManager.imethod_2());
	}

	internal static Class5289 smethod_2(Interface173 layoutManager)
	{
		if (layoutManager == null)
		{
			return null;
		}
		if (layoutManager is Class5289 result)
		{
			return result;
		}
		return smethod_2(layoutManager.imethod_2());
	}

	public override bool imethod_10(int pos)
	{
		do
		{
			if (interface168_2.imethod_0())
			{
				Interface173 @interface = (Interface173)interface168_2.imethod_1();
				if (@interface is Interface175 && !(@interface is Class5298))
				{
					Class5319 lm = method_54(@interface);
					imethod_12(lm);
				}
				else if (@interface is Class5298)
				{
					Class5298 @class = @interface as Class5298;
					Class5296 class2 = smethod_1(this);
					if (class2 != null && !Class5326.Instance.InsideFloat)
					{
						Class5326.Instance.method_0(class2, @class);
						continue;
					}
					List<Class5298> list = Class5282.smethod_3(this);
					if (list != null)
					{
						list.Add(@class);
						continue;
					}
					list = Class5282.smethod_2(this, forsed: true);
					@class.imethod_1(this);
					list?.Add(@class);
				}
				else
				{
					imethod_12(@interface);
				}
				continue;
			}
			return false;
		}
		while (pos >= arrayList_0.Count);
		return true;
	}

	private Class5319 method_54(Interface173 firstlm)
	{
		Class5319 @class = new Class5319(method_56(), interface182_0, int_10, int_11);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(firstlm);
		while (interface168_2.imethod_0())
		{
			Interface173 @interface = (Interface173)interface168_2.imethod_1();
			if (@interface is Interface175)
			{
				arrayList.Add(@interface);
				continue;
			}
			interface168_2.imethod_3();
			break;
		}
		@class.imethod_13(arrayList);
		return @class;
	}

	public override Class5043 imethod_35()
	{
		return method_56().method_58();
	}

	public override Class5043 imethod_36()
	{
		return method_56().method_57();
	}

	public override Class5043 imethod_37()
	{
		return method_56().method_56();
	}

	public override void imethod_9(Class5652 parentIter, Class5687 layoutContext)
	{
		imethod_7(null);
		if (layoutContext.method_53() > 0)
		{
			method_26(0.0, Class5746.smethod_1(layoutContext.method_53()));
		}
		Interface173 @interface = null;
		Class5687 @class = new Class5687(0);
		@class.method_37(layoutContext.method_38());
		if (layoutContext.method_55() > 0)
		{
			@class.method_56(layoutContext.method_55());
		}
		ArrayList arrayList = new ArrayList();
		Class5254 class2 = null;
		Class5254 pos = null;
		while (parentIter.imethod_0())
		{
			Class5254 class3 = (Class5254)parentIter.imethod_1();
			if (class3.method_4() >= 0)
			{
				if (class2 == null)
				{
					class2 = class3;
				}
				pos = class3;
			}
			Class5254 class4 = class3;
			if (class3 is Class5255)
			{
				class4 = class3.vmethod_0();
			}
			if (class4 != null && (class4.method_0() != this || class4 is Class5261))
			{
				arrayList.Add(class4);
				@interface = class4.method_0();
			}
		}
		vmethod_1();
		method_21(isStarting: true, method_16(class2), method_17(pos));
		Class5652 class5 = new Class5652(new Class5495(arrayList));
		Interface173 interface2;
		while ((interface2 = class5.method_0()) != null)
		{
			@class.method_2(128, layoutContext.method_7() && interface2 == @interface);
			@class.method_28(layoutContext.method_29());
			interface2.imethod_9(class5, @class);
		}
		method_21(isStarting: false, method_16(class2), method_17(pos));
		Class5677.smethod_15(class4962_0, layoutContext.method_38(), class5746_0, class5746_1);
		vmethod_2();
		class4962_0 = null;
		method_53();
		method_23(pos);
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		if (class4962_0 == null)
		{
			class4962_0 = new Class4962();
			class4962_0.method_11(base.imethod_16());
			class4962_0.method_16(method_56().method_41());
			Class5677.smethod_17(class4962_0, method_56().imethod_2(), method_56().imethod_1());
			interface173_0.imethod_7(class4962_0);
			Class5677.smethod_22(class4962_0, method_56().method_70());
			Class5677.smethod_21(class4962_0, method_56().vmethod_31());
			Class5677.smethod_4(class4962_0, method_56().method_52(), this);
			Class5677.smethod_29(class4962_0, method_56().method_79());
			Class5677.smethod_3(class4962_0, method_56().method_51(), bool_5, bool_6, discardStart: false, discardEnd: false, this);
			Class5677.smethod_7(class4962_0, method_56().method_51(), bool_7, bool_8, discardStart: false, discardEnd: false, this);
			Class5677.smethod_12(class4962_0, method_56().method_51(), int_6, int_7, this);
			method_25(class4962_0);
		}
		return class4962_0;
	}

	internal int method_55()
	{
		if (class4962_0 == null)
		{
			return 0;
		}
		ArrayList arrayList = class4962_0.method_37();
		if (arrayList != null)
		{
			return class4962_0.method_37().Count;
		}
		return 0;
	}

	public override void imethod_8(Class4942 childArea)
	{
		if (class4962_0 != null)
		{
			if (childArea is Class4972)
			{
				class4962_0.method_43((Class4972)childArea);
			}
			else
			{
				class4962_0.vmethod_5((Class4962)childArea);
			}
		}
	}

	protected override void vmethod_2()
	{
		if (class4962_0 != null)
		{
			Class5677.smethod_11(class4962_0, method_56().method_51(), this);
			base.vmethod_2();
		}
	}

	internal Class5106 method_56()
	{
		return (Class5106)class5094_0;
	}

	public override int imethod_16()
	{
		if (class4962_0 != null)
		{
			return class4962_0.method_12();
		}
		return base.imethod_16();
	}

	public override int imethod_17()
	{
		if (class4962_0 != null)
		{
			return class4962_0.vmethod_1();
		}
		return -1;
	}

	public override bool imethod_19()
	{
		return true;
	}

	public void imethod_38(Class5695 side, Class5746 effectiveLength)
	{
		if (Class5695.class5695_0 == side)
		{
			class5746_0 = effectiveLength;
		}
		else
		{
			class5746_1 = effectiveLength;
		}
	}

	public void imethod_39(Class5695 side, Class5746 effectiveLength)
	{
		if (effectiveLength == null)
		{
			if (Class5695.class5695_0 == side)
			{
				bool_5 = true;
			}
			else
			{
				bool_6 = true;
			}
		}
	}

	public void imethod_40(Class5695 side, Class5746 effectiveLength)
	{
		if (effectiveLength == null)
		{
			if (Class5695.class5695_0 == side)
			{
				bool_7 = true;
			}
			else
			{
				bool_8 = true;
			}
		}
	}

	public override bool imethod_24()
	{
		return true;
	}
}
