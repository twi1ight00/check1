using System.Collections;
using ns183;
using ns189;
using ns196;

namespace ns198;

internal class Class5318 : Class5314
{
	private Class5124 class5124_0;

	private Class5314 class5314_0;

	private Class5294 class5294_0;

	private Class5337 class5337_0;

	public Class5318(Class5124 node)
		: base(node)
	{
		class5124_0 = node;
	}

	public override void imethod_3()
	{
		class5314_0 = new Class5315(class5124_0.method_48());
		class5294_0 = new Class5294(class5124_0.method_49());
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		class5314_0.imethod_1(this);
		class5314_0.imethod_3();
		class5294_0.imethod_1(this);
		class5294_0.imethod_3();
		ArrayList arrayList = new ArrayList();
		while (!class5314_0.imethod_5())
		{
			ArrayList arrayList2 = class5314_0.imethod_14(context, alignment);
			if (arrayList2 != null)
			{
				arrayList.AddRange(arrayList2);
			}
		}
		if (arrayList.Count == 0)
		{
			Class5274 @class = new Class5277();
			class5337_0 = new Class5339(0, null, null, auxiliary: true);
			@class.Add(class5337_0);
			arrayList.Add(@class);
		}
		imethod_6(fin: true);
		method_30(arrayList);
		Interface168 @interface = new Class5495(arrayList);
		Interface168 interface2 = null;
		Class5274 class2 = null;
		Class5328 class3 = null;
		while (@interface.imethod_0())
		{
			class2 = (Class5274)@interface.imethod_1();
			interface2 = new Class5495(class2);
			while (interface2.imethod_0())
			{
				class3 = (Class5337)interface2.imethod_1();
				class3.method_1(imethod_22(new Class5255(this, class3.method_0())));
			}
		}
		return arrayList;
	}

	public override ArrayList imethod_38(ArrayList oldList, int alignment, int depth)
	{
		ArrayList arrayList = base.imethod_38(oldList, alignment, depth);
		method_30(arrayList);
		return arrayList;
	}

	public override void imethod_9(Class5652 posIter, Class5687 context)
	{
		ArrayList arrayList = new ArrayList();
		while (posIter.imethod_0())
		{
			Class5254 @class = (Class5254)posIter.imethod_1();
			if (@class != null && @class.vmethod_0() != null)
			{
				arrayList.Add(@class.vmethod_0());
			}
		}
		class5314_0.imethod_1(imethod_2());
		Class5687 class2 = new Class5687(context);
		Class5652 class3 = new Class5652(new Class5495(arrayList));
		Interface173 @interface;
		while ((@interface = class3.method_0()) != null)
		{
			@interface.imethod_9(class3, class2);
			class2.method_18(class2.method_22());
			class2.method_2(256, bSet: true);
		}
	}

	private void method_30(ArrayList citationList)
	{
		Class5339 @class = null;
		Interface168 @interface = new Class5495(citationList, citationList.Count);
		while (@interface.imethod_2() && @class == null)
		{
			object obj = @interface.imethod_3();
			if (obj is Class5337)
			{
				Class5337 class2 = (Class5337)obj;
				if (class2 is Class5339)
				{
					@class = (Class5339)class2;
				}
				continue;
			}
			Class5274 class3 = (Class5274)obj;
			Interface168 interface2 = new Class5495(class3, class3.Count);
			while (interface2.imethod_2() && @class == null)
			{
				Class5337 class4 = (Class5337)interface2.imethod_3();
				if ((class4 is Class5339 && !class4.method_3()) || class4 == class5337_0)
				{
					@class = (Class5339)class4;
				}
			}
		}
		@class?.method_9(class5294_0);
	}
}
