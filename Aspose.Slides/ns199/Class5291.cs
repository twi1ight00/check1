using System.Collections;
using ns173;
using ns183;
using ns187;
using ns189;
using ns196;
using ns205;

namespace ns199;

internal class Class5291 : Class5281, Interface184
{
	private Class4962 class4962_0;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private Class5746 class5746_0;

	private Class5746 class5746_1;

	public Class5291(Class5159 node)
		: base(node)
	{
	}

	protected Class5159 method_53()
	{
		return (Class5159)class5094_0;
	}

	public override void imethod_3()
	{
		int_6 = method_53().method_48().interface182_4.imethod_6(this);
		int_7 = method_53().method_48().interface182_5.imethod_6(this);
	}

	private void method_54()
	{
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		bool_8 = false;
		class5746_0 = null;
		class5746_1 = null;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		method_54();
		ArrayList arrayList = base.imethod_14(context, alignment);
		int num = method_53().method_53().imethod_5();
		if (num != 0)
		{
			Class5683.smethod_1(arrayList, num);
		}
		int num2 = method_53().method_54().imethod_5();
		if (num2 != 0)
		{
			Class5683.smethod_2(arrayList, num2);
		}
		return arrayList;
	}

	public override void imethod_9(Class5652 parentIter, Class5687 layoutContext)
	{
		imethod_7(null);
		if (layoutContext.method_53() > 0)
		{
			method_26(0.0, Class5746.smethod_1(layoutContext.method_53()));
		}
		vmethod_1();
		Class5687 @class = new Class5687(0);
		Interface173 @interface = null;
		Interface173 interface2 = null;
		Class5254 class2 = null;
		Class5254 pos = null;
		ArrayList arrayList = new ArrayList();
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
			if (class3 is Class5255 && class3.vmethod_0() != null && class3.vmethod_0().method_0() != this)
			{
				arrayList.Add(class3.vmethod_0());
				interface2 = class3.vmethod_0().method_0();
				if (@interface == null)
				{
					@interface = interface2;
				}
			}
		}
		method_21(isStarting: true, method_16(class2), method_17(pos));
		Class5652 class4 = new Class5652(new Class5495(arrayList));
		Interface173 interface3;
		while ((interface3 = class4.method_0()) != null)
		{
			@class.method_37(layoutContext.method_38());
			@class.method_2(32, interface3 == @interface);
			@class.method_2(128, interface3 == interface2);
			@class.method_28(layoutContext.method_29());
			interface3.imethod_9(class4, @class);
		}
		method_21(isStarting: false, method_16(class2), method_17(pos));
		Class5677.smethod_11(class4962_0, method_53().method_49(), this);
		Class5677.smethod_15(class4962_0, layoutContext.method_38(), class5746_0, class5746_1);
		vmethod_2();
		class4962_0 = null;
		method_54();
		method_23(pos);
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		if (class4962_0 == null)
		{
			class4962_0 = new Class4962();
			interface173_0.imethod_7(class4962_0);
			Class5677.smethod_21(class4962_0, method_53().vmethod_31());
			Class5677.smethod_3(class4962_0, method_53().method_49(), bool_5, bool_6, discardStart: false, discardEnd: false, this);
			Class5677.smethod_7(class4962_0, method_53().method_49(), bool_7, bool_8, discardStart: false, discardEnd: false, this);
			Class5677.smethod_13(class4962_0, method_53().method_49(), method_53().method_48(), this);
			Class5677.smethod_17(class4962_0, method_53().imethod_2(), method_53().imethod_1());
			int ipD = int_5 - vmethod_7();
			class4962_0.method_11(ipD);
			method_25(class4962_0);
		}
		return class4962_0;
	}

	public override void imethod_8(Class4942 childArea)
	{
		if (class4962_0 != null)
		{
			class4962_0.vmethod_5((Class4962)childArea);
		}
	}

	public override Class5043 imethod_35()
	{
		return method_53().method_52();
	}

	public override Class5043 imethod_36()
	{
		return method_53().method_51();
	}

	public override Class5043 imethod_37()
	{
		return method_53().method_50();
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
}
