using ns178;
using ns189;

namespace ns171;

internal abstract class Class5096 : Class5094
{
	private Class5172 class5172_0;

	protected Class5088 class5088_4;

	internal Class5172 class5172_1;

	protected Class5096(Class5088 parent)
		: base(parent)
	{
	}

	internal override void vmethod_9(char[] data, int start, int length, Class5634 pList, Interface243 locatoR)
	{
		if (class5172_0 == null)
		{
			class5172_0 = new Class5172(this);
			class5172_0.method_0(locatoR);
			if (!vmethod_5())
			{
				class5172_0.vmethod_2(pList);
			}
		}
		class5172_0.vmethod_9(data, start, length, null, null);
	}

	internal override void vmethod_11()
	{
		base.vmethod_11();
		if (!vmethod_5() || vmethod_24() == 44)
		{
			method_49();
		}
	}

	protected static void smethod_11(Class5096 fobj, Class5088 nextChild)
	{
		fobj.vmethod_4().method_3().method_0(fobj, fobj.class5088_4, nextChild);
	}

	private void method_48()
	{
		if (class5172_0 == null)
		{
			return;
		}
		Class5172 @class = class5172_0;
		class5172_0 = null;
		if (vmethod_24() == 3)
		{
			@class.method_27((Class5106)this);
			class5172_1 = @class;
		}
		else if (vmethod_24() != 44 && vmethod_24() != 80 && vmethod_24() != 7)
		{
			Class5088 class2 = class5088_0;
			int num = class2.vmethod_24();
			while (num != 3 && num != 44 && num != 80 && num != 7 && num != 53)
			{
				class2 = class2.method_4();
				num = class2.vmethod_24();
			}
			switch (num)
			{
			case 3:
				@class.method_27((Class5106)class2);
				((Class5096)class2).class5172_1 = @class;
				break;
			case 53:
				@class.method_26();
				break;
			}
		}
		vmethod_12(@class);
	}

	private void method_49()
	{
		if (class5088_4 != null)
		{
			Interface163 @interface = vmethod_16(class5088_4);
			while (@interface.imethod_0())
			{
				Class5088 @class = @interface.imethod_10();
				if (@class.vmethod_24() == 10)
				{
					@class.vmethod_10();
				}
				@class.vmethod_11();
			}
		}
		class5088_4 = null;
	}

	internal override void vmethod_12(Class5088 child)
	{
		method_48();
		if (!vmethod_5())
		{
			if (!(child is Class5172) && child.vmethod_24() != 10)
			{
				smethod_11(this, child);
				method_49();
			}
			else if (class5088_4 == null)
			{
				class5088_4 = child;
			}
		}
		base.vmethod_12(child);
	}

	public override void vmethod_13(Class5088 child)
	{
		base.vmethod_13(child);
		if (child == class5088_4)
		{
			class5088_4 = ((child.class5088_1 != null) ? child.class5088_1[1] : null);
		}
	}

	public override void vmethod_14()
	{
		method_48();
		if (!vmethod_5() || vmethod_24() == 44)
		{
			smethod_11(this, null);
		}
	}

	public override Class5656 vmethod_17()
	{
		return new Class5661(this);
	}
}
