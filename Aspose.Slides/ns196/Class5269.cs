using System.Collections;
using ns205;

namespace ns196;

internal abstract class Class5269 : Class5268
{
	private Class5280 class5280_0;

	private Class5746 class5746_2;

	protected Class5395 class5395_0;

	private Class5276 class5276_0;

	private Class5276 class5276_1;

	public Class5269(Class5280 layoutManager, Class5746 ipd)
	{
		class5280_0 = layoutManager;
		class5746_2 = ipd;
	}

	protected override void vmethod_16(ArrayList elementList)
	{
		Class5651.smethod_2(elementList, class5280_0.imethod_21().vmethod_21(), class5280_0.imethod_21().vmethod_31());
	}

	protected override bool vmethod_5()
	{
		return false;
	}

	protected override bool vmethod_6()
	{
		return true;
	}

	protected override Interface173 vmethod_3()
	{
		return class5280_0;
	}

	protected override Class5687 vmethod_14()
	{
		Class5687 @class = base.vmethod_14();
		@class.method_30(class5746_2.method_2());
		return @class;
	}

	protected override ArrayList vmethod_9(Class5687 context, int alignment)
	{
		return null;
	}

	protected override bool vmethod_1()
	{
		return !class5280_0.imethod_5();
	}

	protected override void vmethod_17(Class5395 alg, int partCount, Class5276 originalList, Class5276 effectiveList)
	{
		class5395_0 = alg;
		class5276_0 = originalList;
		class5276_1 = effectiveList;
	}

	protected override void vmethod_13(Class5395 alg, Class5259 pbp)
	{
	}

	protected override Interface173 vmethod_4()
	{
		return class5280_0.interface173_1;
	}

	public void method_7()
	{
		if (!method_0())
		{
			class5395_0.method_25();
			method_3(class5395_0, class5395_0.method_23().Count, class5276_0, class5276_1);
		}
	}

	public virtual bool vmethod_21()
	{
		if (!method_0())
		{
			if (class5395_0.method_23().Count <= 1)
			{
				return class5395_0.int_14 - class5395_0.int_16 > class5395_0.vmethod_22();
			}
			return true;
		}
		return false;
	}

	public virtual int vmethod_22()
	{
		return class5395_0.int_14 - class5395_0.int_16 - class5395_0.vmethod_22();
	}

	public virtual int vmethod_23()
	{
		return class5395_0.int_14;
	}
}
