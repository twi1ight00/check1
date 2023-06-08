using System;
using System.Collections;
using ns183;
using ns187;
using ns192;
using ns195;
using ns196;
using ns205;

namespace ns197;

internal class Class5654
{
	private static Class5746 class5746_0 = Class5746.smethod_0(0, 0, int.MaxValue);

	private Class5645[] class5645_0;

	private Class5287 class5287_0;

	private Class5675 class5675_0;

	internal Class5654(Class5287 tableLM, Class5645[] rowGroup, Class5675 tableStepper)
	{
		class5287_0 = tableLM;
		class5645_0 = rowGroup;
		class5675_0 = tableStepper;
	}

	public ArrayList method_0(Class5687 context, int alignment, int bodyType)
	{
		ArrayList arrayList = new ArrayList();
		method_1(context, alignment, bodyType, arrayList);
		context.method_15(class5645_0[0].method_11());
		context.method_14(class5645_0[class5645_0.Length - 1].method_12());
		int @break = 9;
		Class5155 @class = class5645_0[0].method_2();
		if (@class != null)
		{
			@break = @class.imethod_2();
		}
		context.method_58(Class5676.smethod_1(@break, class5645_0[0].method_14()));
		int break2 = 9;
		Class5155 class2 = class5645_0[class5645_0.Length - 1].method_2();
		if (class2 != null)
		{
			break2 = class2.imethod_1();
		}
		context.method_60(Class5676.smethod_1(break2, class5645_0[class5645_0.Length - 1].method_15()));
		return arrayList;
	}

	private void method_1(Class5687 context, int alignment, int bodyType, ArrayList returnList)
	{
		for (int i = 0; i < class5645_0.Length; i++)
		{
			Class5645 @class = class5645_0[i];
			Interface208 @interface = new Class5495(@class.method_7());
			while (@interface.imethod_0())
			{
				Class5630 class2 = (Class5630)@interface.imethod_1();
				if (class2.vmethod_2())
				{
					Class5631 class3 = class2.vmethod_1();
					class3.method_35();
					class3.method_20().imethod_1(class5287_0);
					int num = 0;
					Interface208 interface2 = new Class5495(class5287_0.method_53().method_57(), class3.method_32());
					int j = 0;
					for (int num2 = class3.method_1().method_53(); j < num2; j++)
					{
						num += ((Class5158)interface2.imethod_1()).method_52().imethod_6(class5287_0);
					}
					Class5687 class4 = new Class5687(0);
					class4.method_28(context.method_29());
					class4.method_30(num);
					ArrayList arrayList = class3.method_20().imethod_14(class4, alignment);
					Class5651.smethod_2(arrayList, "table-cell", class3.method_1().vmethod_31());
					class3.method_21(arrayList);
				}
			}
		}
		method_2();
		ArrayList c = class5675_0.method_4(context, class5645_0, bodyType);
		returnList.AddRange(c);
	}

	private void method_2()
	{
		Class5746[] array = new Class5746[class5645_0.Length];
		for (int i = 0; i < class5645_0.Length; i++)
		{
			Class5645 @class = class5645_0[i];
			Class5155 class2 = class5645_0[i].method_2();
			Class5746 class3;
			if (class2 == null)
			{
				array[i] = class5746_0;
				class3 = class5746_0;
			}
			else
			{
				Class5045 class4 = class2.method_60();
				array[i] = class4.method_3(class5287_0);
				class3 = class4.method_3(class5287_0);
			}
			Interface208 @interface = new Class5495(@class.method_7());
			while (@interface.imethod_0())
			{
				Class5630 class5 = (Class5630)@interface.imethod_1();
				if (!class5.method_4() && class5.method_6() == 0 && class5.vmethod_4())
				{
					Class5631 class6 = class5.vmethod_1();
					int val = 0;
					Class5045 class7 = class6.method_1().method_55();
					if (!class7.method_8(class5287_0).method_2())
					{
						val = class7.method_8(class5287_0).vmethod_0().imethod_6(class5287_0);
					}
					if (!class7.method_10(class5287_0).method_2())
					{
						val = class7.method_10(class5287_0).vmethod_0().imethod_6(class5287_0);
					}
					if (class5.method_5() == 0)
					{
						val = Math.Max(val, class3.method_2());
					}
					val = Math.Max(val, class6.method_27());
					int num = class6.method_23();
					int num2 = 0;
					Class5703 class8 = class6.method_1().vmethod_33();
					num2 = 0 + class8.method_10(discard: false, class6.method_20());
					num2 += class8.method_11(discard: false, class6.method_20());
					int num3 = val + num2 + num;
					for (int num4 = i - 1; num4 >= i - class5.method_5(); num4--)
					{
						num3 -= array[num4].method_2();
					}
					if (num3 > array[i].method_1())
					{
						array[i] = array[i].method_19(num3);
					}
				}
			}
			@class.method_4(array[i]);
			@class.method_6(class3);
		}
	}
}
