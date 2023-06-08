using System.Collections;
using ns171;
using ns176;
using ns187;

namespace ns192;

internal abstract class Class5150 : Class5149, Interface222, Interface233
{
	private Class5715 class5715_0;

	internal ArrayList arrayList_1;

	internal Class5714 class5714_0;

	public Class5150(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5715_0 = Class5715.smethod_0(pList);
	}

	protected void method_51(Class5157 cell, bool firstRow)
	{
		int num = cell.method_51();
		int num2 = cell.method_53();
		int num3 = cell.method_54();
		Class5156 @class = vmethod_32();
		if (@class.method_55())
		{
			if (num + num2 - 1 > @class.method_59())
			{
				Interface245 @interface = Class5754.smethod_0(method_2().method_48());
				@interface.imethod_5(this, method_1());
			}
		}
		else
		{
			@class.method_52(num + num2 - 1);
			while (arrayList_1.Count < num + num2 - 1)
			{
				arrayList_1.Add(null);
			}
		}
		if (firstRow)
		{
			method_52(cell, num, num2);
		}
		if (num3 > 1)
		{
			for (int i = 0; i < num2; i++)
			{
				arrayList_1[num - 1 + i] = new Class5748(num3);
			}
		}
		class5714_0.method_1(num, num + num2 - 1);
		@class.method_77().vmethod_0(cell);
	}

	private void method_52(Class5157 cell, int colNumber, int colSpan)
	{
		Class5156 @class = vmethod_32();
		Interface182 @interface = null;
		if (cell.method_57().imethod_0() != 9 && colSpan == 1)
		{
			@interface = cell.method_57();
		}
		for (int i = colNumber; i < colNumber + colSpan; i++)
		{
			Class5158 class2 = @class.method_58(i - 1);
			if (@interface != null)
			{
				class2.method_55(@interface);
			}
		}
	}

	internal abstract Class5151 vmethod_34();

	public Class5714 imethod_3()
	{
		return class5714_0;
	}

	public Class5715 imethod_0()
	{
		return class5715_0;
	}
}
