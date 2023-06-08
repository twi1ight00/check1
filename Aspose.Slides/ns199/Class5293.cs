using System.Collections;
using ns173;
using ns183;
using ns187;
using ns189;
using ns196;

namespace ns199;

internal class Class5293 : Class5281
{
	private Class4962 class4962_0;

	private int int_10;

	private int int_11;

	public Class5293(Class5132 node)
		: base(node)
	{
	}

	public Class5293(Class5131 node)
		: base(node)
	{
	}

	internal Class5130 method_53()
	{
		return (Class5130)class5094_0;
	}

	public void method_54(int off)
	{
		int_10 = off;
	}

	public override void imethod_9(Class5652 parentIter, Class5687 layoutContext)
	{
		imethod_7(null);
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
			if (class3 == null)
			{
				continue;
			}
			if (class3.method_4() >= 0)
			{
				if (class2 == null)
				{
					class2 = class3;
				}
				pos = class3;
			}
			if (class3 is Class5255)
			{
				arrayList.Add(class3.vmethod_0());
				interface2 = class3.vmethod_0().method_0();
				if (@interface == null)
				{
					@interface = interface2;
				}
			}
			else if (class3 is Class5644.Class5263)
			{
				arrayList.Add(class3);
			}
		}
		method_21(isStarting: true, method_16(class2), method_17(pos));
		Class5652 class4 = new Class5652(new Class5495(arrayList));
		Interface173 interface3;
		while ((interface3 = class4.method_0()) != null)
		{
			@class.method_2(32, interface3 == @interface);
			@class.method_2(128, interface3 == interface2);
			@class.method_37(layoutContext.method_38());
			@class.method_28(layoutContext.method_29());
			interface3.imethod_9(class4, @class);
		}
		method_21(isStarting: false, method_16(class2), method_17(pos));
		vmethod_2();
		class4962_0 = null;
		method_23(pos);
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		if (class4962_0 == null)
		{
			class4962_0 = new Class4962();
			class4962_0.method_44(2);
			class4962_0.method_38(int_10, leftAuto: false, rightAuto: false);
			class4962_0.method_11(int_11);
			Class5677.smethod_21(class4962_0, method_53().vmethod_31());
			Class4942 @class = interface173_0.imethod_7(class4962_0);
			int ipD = @class.method_12();
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
		return method_53().method_48();
	}

	public override Class5686 imethod_33()
	{
		return Class5686.class5686_0;
	}

	public override Class5686 imethod_31()
	{
		return Class5686.class5686_0;
	}
}
