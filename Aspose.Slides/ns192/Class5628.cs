using System.Collections;
using ns171;
using ns183;

namespace ns192;

internal class Class5628 : Class5627
{
	private int int_0;

	private Class5155 class5155_0;

	private int int_1;

	private ArrayList arrayList_0;

	private bool bool_0 = true;

	private ArrayList arrayList_1;

	private Interface225 interface225_0;

	internal Class5628(Class5156 t)
		: base(t)
	{
		int_0 = t.method_59();
		if (t.method_72())
		{
			interface225_0 = new Class5633();
		}
		else
		{
			interface225_0 = new Class5622(t);
		}
		method_0();
	}

	private void method_0()
	{
		arrayList_0 = new ArrayList();
		int_1 = 0;
	}

	internal override void vmethod_0(Class5157 cell)
	{
		for (int i = arrayList_0.Count; i < int_1 + cell.method_54(); i++)
		{
			ArrayList arrayList = new ArrayList(int_0);
			for (int j = 0; j < int_0; j++)
			{
				arrayList.Add(null);
			}
			arrayList_0.Add(arrayList);
		}
		int num = cell.method_51() - 1;
		Class5631 @class = new Class5631(cell, num);
		ArrayList arrayList2 = (ArrayList)arrayList_0[int_1];
		arrayList2[num] = @class;
		Class5630[] array = new Class5630[cell.method_53()];
		array[0] = @class;
		for (int k = 1; k < cell.method_53(); k++)
		{
			Class5630 class3 = (Class5630)(arrayList2[num + k] = new Class5630(@class, k, 0));
			array[k] = class3;
		}
		@class.method_29(array);
		for (int l = 1; l < cell.method_54(); l++)
		{
			arrayList2 = (ArrayList)arrayList_0[int_1 + l];
			array = new Class5630[cell.method_53()];
			for (int m = 0; m < cell.method_53(); m++)
			{
				Class5630 class5 = (Class5630)(arrayList2[num + m] = new Class5630(@class, m, l));
				array[m] = class5;
			}
			@class.method_29(array);
		}
	}

	private static void smethod_0(int flag, ArrayList row)
	{
		Interface168 @interface = new Class5495(row);
		while (@interface.imethod_0())
		{
			((Class5630)@interface.imethod_1()).method_18(flag);
		}
	}

	internal override void vmethod_1(Class5155 tableRow)
	{
		class5155_0 = tableRow;
	}

	internal override void vmethod_2()
	{
		if (int_1 > 0 && class5155_0.imethod_2() != 9)
		{
			Interface245 @interface = Class5754.smethod_0(class5155_0.method_2().method_48());
			@interface.imethod_11(this, class5155_0.method_17(), breakBefore: true, class5155_0.method_1());
		}
		if (int_1 < arrayList_0.Count - 1 && class5155_0.imethod_1() != 9)
		{
			Interface245 interface2 = Class5754.smethod_0(class5155_0.method_2().method_48());
			interface2.imethod_11(this, class5155_0.method_17(), breakBefore: false, class5155_0.method_1());
		}
		if (arrayList_0.Count != 0)
		{
			Interface208 interface3 = new Class5495((ArrayList)arrayList_0[int_1]);
			while (interface3.imethod_0())
			{
				((Class5630)interface3.imethod_1())?.method_3(class5155_0);
			}
			method_1(class5155_0);
		}
	}

	internal override void vmethod_3(Class5151 part)
	{
		method_1(part);
	}

	private void method_1(Class5150 container)
	{
		ArrayList arrayList = (arrayList_1 = (ArrayList)arrayList_0[int_1]);
		for (int i = 0; i < int_0; i++)
		{
			if (arrayList[i] == null)
			{
				arrayList[i] = new Class5632(class5156_0, class5155_0, i);
			}
		}
		interface225_0.imethod_0(arrayList, container);
		if (bool_0)
		{
			smethod_0(Class5630.int_0, arrayList);
			bool_0 = false;
		}
		if (int_1 == arrayList_0.Count - 1)
		{
			container.vmethod_34().method_54(arrayList_0);
			method_0();
		}
		else
		{
			int_1++;
		}
		class5155_0 = null;
	}

	internal override void vmethod_4(Class5151 part)
	{
		bool_0 = true;
		interface225_0.imethod_1(part);
	}

	internal override void vmethod_5()
	{
		if (arrayList_0.Count > 0)
		{
			throw new Exception54("A table-cell is spanning more rows than available in its parent element.");
		}
		smethod_0(Class5630.int_1, arrayList_1);
		interface225_0.imethod_2();
	}

	internal override void vmethod_6()
	{
		interface225_0.imethod_3();
	}
}
