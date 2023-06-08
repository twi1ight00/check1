using System.Collections;
using ns183;

namespace ns196;

internal class Class5648
{
	private Class5648()
	{
	}

	public static void smethod_0(Class5281 bslm, Class5652 parentIter, Class5687 layoutContext)
	{
		Class5687 @class = new Class5687(0);
		Interface173 @interface = null;
		Interface173 interface2 = null;
		Class5254 class2 = null;
		Class5254 pos = null;
		bslm?.vmethod_1();
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
		if (class2 != null)
		{
			bslm?.method_21(isStarting: true, bslm.method_16(class2), bslm.method_17(pos));
			Class5652 class4 = new Class5652(new Class5495(arrayList));
			Interface173 interface3;
			while ((interface3 = class4.method_0()) != null)
			{
				@class.method_2(32, interface3 == @interface);
				@class.method_2(128, interface3 == interface2);
				@class.method_37(layoutContext.method_38());
				@class.method_54((interface3 == @interface) ? layoutContext.method_53() : 0);
				@class.method_56(layoutContext.method_55());
				@class.method_28(layoutContext.method_29());
				interface3.imethod_9(class4, @class);
			}
			if (bslm != null)
			{
				bslm.method_21(isStarting: false, bslm.method_16(class2), bslm.method_17(pos));
				bslm.method_23(pos);
			}
		}
	}
}
