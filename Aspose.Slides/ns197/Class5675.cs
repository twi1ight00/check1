using System;
using System.Collections;
using ns183;
using ns192;
using ns195;
using ns196;

namespace ns197;

internal class Class5675
{
	private Class5674 class5674_0;

	private Class5645[] class5645_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private bool bool_0;

	internal ArrayList arrayList_0 = new ArrayList();

	private ArrayList arrayList_1 = new ArrayList();

	private bool bool_1;

	private int int_4;

	private bool bool_2;

	private int int_5;

	public Class5675(Class5674 tclm)
	{
		class5674_0 = tclm;
		int_0 = tclm.method_0().method_53().method_59();
	}

	private void method_0(Class5645[] rows)
	{
		class5645_0 = rows;
		int_2 = 0;
		int_3 = 0;
		arrayList_0.Clear();
		arrayList_1.Clear();
		bool_1 = false;
		int_4 = 0;
		bool_2 = false;
	}

	private void method_1()
	{
		int_1 = 0;
		for (int i = 0; i < class5645_0.Length; i++)
		{
			int_1 += class5645_0[i].method_3().method_2();
		}
	}

	private int method_2()
	{
		int num = 0;
		Interface208 @interface = new Class5495(arrayList_0);
		while (@interface.imethod_0())
		{
			Class5646 @class = (Class5646)@interface.imethod_1();
			int num2 = @class.method_3();
			Class5631 class2 = @class.method_1();
			for (int i = int_3 + 1; i < class2.method_31() - class5645_0[0].method_0() + class2.method_1().method_54(); i++)
			{
				num2 -= class5645_0[i].method_3().method_2();
			}
			num = Math.Max(num, num2);
		}
		for (int j = int_3 + 1; j < class5645_0.Length; j++)
		{
			num += class5645_0[j].method_3().method_2();
		}
		return num;
	}

	private void method_3(ArrayList activeCellList, int rowIndex)
	{
		Class5645 @class = class5645_0[rowIndex];
		for (int i = 0; i < int_0; i++)
		{
			Class5630 class2 = @class.method_8(i);
			if (!class2.method_4() && class2.vmethod_2())
			{
				activeCellList.Add(new Class5646((Class5631)class2, @class, rowIndex, int_2, method_15()));
			}
		}
	}

	public ArrayList method_4(Class5687 context, Class5645[] rows, int bodyType)
	{
		method_0(rows);
		method_3(arrayList_0, 0);
		method_1();
		int num = 0;
		Class5265 @class = null;
		ArrayList arrayList = new ArrayList();
		int num2 = method_5();
		do
		{
			int num3 = method_2();
			int num4 = num2 + num3 - int_1;
			int num5 = num2 - num - Math.Max(0, num4);
			num += num5 + Math.Max(0, -num4);
			ArrayList arrayList2 = new ArrayList();
			ArrayList arrayList3 = new ArrayList(arrayList_0.Count);
			Interface208 @interface = new Class5495(arrayList_0);
			while (@interface.imethod_0())
			{
				Class5646 class2 = (Class5646)@interface.imethod_1();
				Class5649 value = class2.method_16();
				arrayList3.Add(value);
				class2.method_17(arrayList2);
			}
			Class5265 class3 = new Class5265(method_15(), arrayList3, class5645_0[int_3]);
			if (bool_1)
			{
				class3.method_6(class5645_0[int_3 + 1]);
			}
			if (arrayList.Count == 0)
			{
				class3.method_11(Class5265.int_1, value: true);
			}
			@class = class3;
			if (arrayList2.Count == 0)
			{
				arrayList.Add(new Class5338(num5, class3, auxiliary: false));
			}
			else
			{
				arrayList.Add(new Class5341(num5, arrayList2, new ArrayList(), class3, auxiliary: false));
			}
			int num6 = Math.Max(0, num4);
			Class5267 class4 = new Class5267(method_15());
			if (bodyType == 0)
			{
				if (!method_15().method_53().method_62())
				{
					num6 += class5674_0.method_3();
					class4.arrayList_0 = class5674_0.method_5();
				}
				if (!method_15().method_53().method_63())
				{
					num6 += class5674_0.method_4();
					class4.arrayList_1 = class5674_0.method_6();
				}
			}
			Class5686 class5 = method_15().imethod_29();
			int num7 = 0;
			Interface208 interface2 = new Class5495(arrayList_0);
			while (interface2.imethod_0())
			{
				Class5646 class6 = (Class5646)interface2.imethod_1();
				class5 = class5.method_4(class6.method_18());
				num7 = Math.Max(num7, class6.method_19());
			}
			if (!bool_0)
			{
				class5 = class5.method_4(class5645_0[int_3].method_13());
			}
			else if (int_3 < class5645_0.Length - 1)
			{
				class5 = class5.method_4(class5645_0[int_3].method_12());
				class5 = class5.method_4(class5645_0[int_3 + 1].method_11());
				int_5 = Class5676.smethod_1(int_5, class5645_0[int_3].method_15());
				int_5 = Class5676.smethod_1(int_5, class5645_0[int_3 + 1].method_14());
			}
			int val = class5.method_3();
			if (bool_2)
			{
				bool_2 = false;
				val = Class5337.int_0;
			}
			val = Math.Max(val, num7);
			int breakClass = class5.method_2();
			if (int_5 != 9)
			{
				val = -Class5337.int_0;
				breakClass = int_5;
			}
			arrayList.Add(new Class5336(class4, num6, val, breakClass, context));
			if (num4 < 0)
			{
				arrayList.Add(new Class5344(-num4, 0, 0, new Class5254(null), auxiliary: true));
			}
			num2 = method_6();
		}
		while (num2 >= 0);
		@class.method_11(Class5265.int_2, value: true);
		return arrayList;
	}

	private int method_5()
	{
		method_7(arrayList_0);
		method_9();
		int num = method_11(int_4);
		method_10(num);
		return num;
	}

	private int method_6()
	{
		if (bool_0)
		{
			if (int_3 == class5645_0.Length - 1)
			{
				return -1;
			}
			bool_0 = false;
			method_13();
			bool_1 = true;
		}
		if (bool_1)
		{
			int num = method_8();
			if (num < 0 || num >= int_4 || num > class5645_0[int_3].method_5().method_3())
			{
				bool_1 = false;
				num = int_4;
				method_14();
				method_9();
				num = method_11(num);
			}
			method_10(num);
			return num;
		}
		int step = method_8();
		step = method_11(step);
		method_10(step);
		return step;
	}

	private void method_7(ArrayList cells)
	{
		Interface208 @interface = new Class5495(cells);
		while (@interface.imethod_0())
		{
			Class5646 @class = (Class5646)@interface.imethod_1();
			int_4 = Math.Max(int_4, @class.method_5());
		}
	}

	private int method_8()
	{
		int num = int.MaxValue;
		bool flag = false;
		Interface208 @interface = new Class5495(arrayList_0);
		while (@interface.imethod_0())
		{
			Class5646 @class = (Class5646)@interface.imethod_1();
			int num2 = @class.method_10();
			if (num2 >= 0)
			{
				flag = true;
				num = Math.Min(num, num2);
			}
		}
		if (flag)
		{
			return num;
		}
		return -1;
	}

	private void method_9()
	{
		Interface208 @interface = new Class5495(arrayList_0);
		while (@interface.imethod_0())
		{
			Class5646 @class = (Class5646)@interface.imethod_1();
			@class.method_8(int_4);
		}
	}

	private void method_10(int step)
	{
		int_5 = 9;
		Interface208 @interface = new Class5495(arrayList_0);
		while (@interface.imethod_0())
		{
			Class5646 @class = (Class5646)@interface.imethod_1();
			int_5 = Class5676.smethod_1(int_5, @class.method_12(step));
		}
	}

	private int method_11(int step)
	{
		bool_0 = true;
		Interface208 @interface = new Class5495(arrayList_0);
		while (@interface.imethod_0())
		{
			Class5646 @class = (Class5646)@interface.imethod_1();
			if (@class.method_2(int_3))
			{
				bool_0 &= @class.method_15(step);
			}
		}
		if (bool_0)
		{
			int num = 0;
			Interface208 interface2 = new Class5495(arrayList_0);
			while (interface2.imethod_0())
			{
				Class5646 class2 = (Class5646)interface2.imethod_1();
				if (class2.method_2(int_3))
				{
					num = Math.Max(num, class2.method_6());
				}
			}
			Interface208 interface3 = new Class5495(arrayList_0);
			while (interface3.imethod_0())
			{
				Class5646 class3 = (Class5646)interface3.imethod_1();
				class3.method_14(int_3);
				if (!class3.method_2(int_3))
				{
					class3.method_9(num);
				}
			}
			if (num < step)
			{
				bool_2 = true;
			}
			step = num;
			method_12();
		}
		return step;
	}

	private void method_12()
	{
		if (int_3 < class5645_0.Length - 1)
		{
			int_2 += class5645_0[int_3].method_3().method_2();
			method_3(arrayList_1, int_3 + 1);
			method_7(arrayList_1);
		}
	}

	private void method_13()
	{
		Interface208 @interface = new Class5495(arrayList_0);
		while (@interface.imethod_0())
		{
			Class5646 @class = (Class5646)@interface.imethod_1();
			if (@class.method_2(int_3))
			{
				@interface.imethod_6();
			}
		}
	}

	private void method_14()
	{
		int_3++;
		Interface208 @interface = new Class5495(arrayList_0);
		while (@interface.imethod_0())
		{
			Class5646 @class = (Class5646)@interface.imethod_1();
			@class.method_13();
		}
		arrayList_0.AddRange(arrayList_1);
		arrayList_1.Clear();
	}

	private Class5287 method_15()
	{
		return class5674_0.method_0();
	}
}
