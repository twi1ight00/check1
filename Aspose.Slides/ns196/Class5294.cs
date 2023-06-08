using System.Collections;
using ns173;
using ns183;
using ns189;

namespace ns196;

internal class Class5294 : Class5281
{
	public Class5294(Class5112 body)
		: base(body)
	{
	}

	public override void imethod_9(Class5652 parentIter, Class5687 layoutContext)
	{
		Interface173 @interface = null;
		Class5687 @class = new Class5687(0);
		ArrayList arrayList = new ArrayList();
		while (parentIter.imethod_0())
		{
			Class5254 class2 = (Class5254)parentIter.imethod_1();
			if (class2 is Class5255)
			{
				Class5254 class3 = class2.vmethod_0();
				if (class3.method_0() != this)
				{
					arrayList.Add(class3);
					@interface = class3.method_0();
				}
			}
		}
		Class5652 class4 = new Class5652(new Class5495(arrayList));
		Interface173 interface2;
		while ((interface2 = class4.method_0()) != null)
		{
			@class.method_2(128, layoutContext.method_7() && interface2 == @interface);
			interface2.imethod_9(class4, @class);
		}
	}

	public override void imethod_8(Class4942 childArea)
	{
		childArea.method_10(Class4942.int_8);
		interface173_0.imethod_8(childArea);
	}

	protected Class5112 method_53()
	{
		return (Class5112)class5094_0;
	}

	public override Class5686 imethod_29()
	{
		return method_38();
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
