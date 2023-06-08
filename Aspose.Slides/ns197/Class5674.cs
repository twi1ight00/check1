using System;
using System.Collections;
using ns171;
using ns176;
using ns183;
using ns187;
using ns192;
using ns195;
using ns196;
using ns205;

namespace ns197;

internal class Class5674 : Interface172
{
	private Class5287 class5287_0;

	private Hashtable hashtable_0 = new Hashtable();

	private Class5637 class5637_0;

	private Class5637 class5637_1;

	private Class5637 class5637_2;

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private Class5675 class5675_0;

	private int int_4;

	internal Class5674(Class5287 parent)
	{
		class5287_0 = parent;
		Class5156 @class = method_0().method_53();
		class5637_0 = new Class5637(@class, 0);
		if (@class.method_60() != null)
		{
			class5637_1 = new Class5637(@class, 1);
		}
		if (@class.method_61() != null)
		{
			class5637_2 = new Class5637(@class, 2);
		}
		class5675_0 = new Class5675(this);
	}

	internal Class5287 method_0()
	{
		return class5287_0;
	}

	internal bool method_1()
	{
		return method_0().method_53().method_72();
	}

	internal Class5650 method_2()
	{
		return method_0().method_54();
	}

	internal int method_3()
	{
		return int_0;
	}

	internal int method_4()
	{
		return int_1;
	}

	internal ArrayList method_5()
	{
		return arrayList_0;
	}

	internal ArrayList method_6()
	{
		return arrayList_1;
	}

	public object method_7(Class5094 key)
	{
		return hashtable_0[key];
	}

	private bool method_8(Class5631 primary)
	{
		Class5156 @class = class5287_0.method_53();
		int num = primary.method_32();
		Class5158 class2 = @class.method_58(num);
		int num2 = class2.method_52().imethod_6(class5287_0);
		int num3 = num + primary.method_1().method_53();
		for (int i = num + 1; i < num3; i++)
		{
			Class5158 class3 = @class.method_58(i);
			num2 += class3.method_52().imethod_6(class5287_0);
		}
		object obj = method_7(class2);
		int num4 = primary.method_20().method_56();
		primary.method_20().vmethod_7();
		if (num == @class.method_57().Count - 1)
		{
			class2.int_5 = Math.Max(class2.int_5, primary.method_20().class5631_0.method_33()[1]);
		}
		if (class2.method_52() is Class5038 && primary.method_1().method_57().imethod_0() != 9 && primary.method_1().method_57() is Class5037)
		{
			class2.method_55(primary.method_1().method_57());
		}
		if (primary.method_1().method_53() == 1)
		{
			Class5746 class5 = primary.method_20().method_64();
			if (primary.method_1().method_57().imethod_4())
			{
				int newOpt = primary.method_1().method_57().imethod_6(class5287_0);
				class5 = class5.method_21(newOpt);
			}
			Class5746 class6 = class2.method_53();
			if (class6 != null)
			{
				if (class5 != null)
				{
					class6 = class6.method_19(class5.method_1()).method_20(class5.method_3());
				}
			}
			else
			{
				class6 = class5;
			}
			class2.method_54(class6);
		}
		else
		{
			Class5746 class7 = primary.method_20().method_64();
			if (primary.method_1().method_57().imethod_4())
			{
				int newOpt2 = primary.method_1().method_57().imethod_6(class5287_0);
				class7 = class7.method_21(newOpt2);
			}
			Class5746 class8 = class2.method_53();
			if (class8 != null)
			{
				if (class7 != null)
				{
					class8 = class8.method_20(class7.method_3());
				}
			}
			else
			{
				class8 = class7;
			}
			num3 = Math.Min(primary.method_1().method_53() + num, @class.method_59());
			int num5 = @class.method_59() - primary.method_1().method_51() + 1;
			class8 = Class5746.smethod_0(class8.method_1() / num5, class8.method_2() / num5, class8.method_3() / num5);
			class7 = class2.method_53();
			if (class7 != null)
			{
				class8 = class8.method_19(class7.method_1()).method_20(class7.method_3());
			}
			class2.method_54(class8);
		}
		if (num2 == 0)
		{
			if (obj == null)
			{
				hashtable_0[class2] = num4;
				class2.int_4 = num4;
				class2.hashtable_2[primary.method_31()] = num4;
			}
		}
		else
		{
			if (num2 < num4 && num == num3 - 1 && obj != null)
			{
				hashtable_0[class2] = num4;
				class2.int_4 = num4;
				class2.hashtable_2[primary.method_31()] = num4;
				return (int)obj == num4;
			}
			if (obj == null)
			{
				class2.int_4 = num2;
				class2.hashtable_2[primary.method_31()] = num2;
			}
		}
		return false;
	}

	private bool method_9(Class5265 position)
	{
		bool flag = false;
		Class5645 @class = position.method_8();
		Interface208 @interface = new Class5495(@class.method_7());
		while (@interface.imethod_0())
		{
			Class5630 class2 = (Class5630)@interface.imethod_1();
			if (class2 is Class5631)
			{
				flag = method_8((Class5631)class2) || flag;
			}
		}
		return flag;
	}

	private bool method_10(Interface208 content)
	{
		bool flag = false;
		while (content.imethod_0())
		{
			Class5328 @class = (Class5328)content.imethod_1();
			Class5254 class2 = @class.method_0();
			if (class2 is Class5265)
			{
				flag = method_9((Class5265)class2) || flag;
			}
		}
		return flag;
	}

	private bool method_11(ArrayList content)
	{
		Class5156 @class = class5287_0.method_53();
		if (method_10(new Class5495(content)))
		{
			return @class.method_56();
		}
		return false;
	}

	public ArrayList method_12(Class5687 context, int alignment)
	{
		Class5338 @class = null;
		Class5338 class2 = null;
		Class5338 class3 = null;
		if (class5637_1 != null && arrayList_0 == null)
		{
			arrayList_0 = method_13(class5637_1, context, alignment, 1);
			if (method_11(arrayList_0))
			{
				Class5156 table = class5287_0.method_53();
				class5637_1 = new Class5637(table, 1);
				arrayList_0 = null;
				return method_12(context, alignment);
			}
			int_0 = Class5683.smethod_5(arrayList_0);
			Class5266 pos = new Class5266(method_0(), header: true, arrayList_0);
			Class5338 class4 = new Class5338(int_0, pos, auxiliary: false);
			if (method_0().method_53().method_62())
			{
				@class = class4;
			}
			else
			{
				class2 = class4;
			}
		}
		if (class5637_2 != null && arrayList_1 == null)
		{
			arrayList_1 = method_13(class5637_2, context, alignment, 2);
			if (method_11(arrayList_1))
			{
				Class5156 table2 = class5287_0.method_53();
				if (class5637_1 != null)
				{
					class5637_1 = new Class5637(table2, 1);
					arrayList_0 = null;
				}
				class5637_2 = new Class5637(table2, 2);
				arrayList_1 = null;
				return method_12(context, alignment);
			}
			int_1 = Class5683.smethod_5(arrayList_1);
			Class5266 pos2 = new Class5266(method_0(), header: false, arrayList_1);
			Class5338 class5 = new Class5338(int_1, pos2, auxiliary: false);
			class3 = class5;
		}
		ArrayList arrayList = method_13(class5637_0, context, alignment, 0);
		if (method_11(arrayList))
		{
			Class5156 table3 = class5287_0.method_53();
			if (class5637_1 != null)
			{
				class5637_1 = new Class5637(table3, 1);
				arrayList_0 = null;
			}
			if (class5637_2 != null)
			{
				class5637_2 = new Class5637(table3, 2);
				arrayList_1 = null;
			}
			class5637_0 = new Class5637(table3, 0);
			return method_12(context, alignment);
		}
		if (@class != null)
		{
			int num = 0;
			if (arrayList.Count > 0 && ((Class5328)arrayList[0]).vmethod_3())
			{
				num++;
			}
			arrayList.Insert(num, @class);
		}
		else if (class2 != null)
		{
			int num2 = arrayList.Count;
			if (arrayList.Count > 0 && ((Class5328)arrayList[arrayList.Count - 1]).vmethod_3())
			{
				num2--;
			}
			arrayList.Insert(num2, class2);
		}
		if (class3 != null)
		{
			int num3 = arrayList.Count;
			if (arrayList.Count > 0 && ((Class5328)arrayList[arrayList.Count - 1]).vmethod_3())
			{
				num3--;
			}
			arrayList.Insert(num3, class3);
		}
		return arrayList;
	}

	private ArrayList method_13(Class5637 iter, Class5687 context, int alignment, int bodyType)
	{
		ArrayList arrayList = new ArrayList();
		Class5645[] array = iter.method_0();
		context.method_13();
		context.method_58(9);
		context.method_60(9);
		Class5686 @class = Class5686.class5686_0;
		int breakBefore = 9;
		Interface168 @interface;
		Class5328 class5;
		if (array != null)
		{
			Class5654 class2 = new Class5654(method_0(), array, class5675_0);
			ArrayList c = class2.method_0(context, alignment, bodyType);
			@class = @class.method_4(context.method_10());
			breakBefore = context.method_57();
			int @break = context.method_59();
			arrayList.AddRange(c);
			while ((array = iter.method_0()) != null)
			{
				class2 = new Class5654(method_0(), array, class5675_0);
				Class5686 class3 = context.method_9();
				context.method_11();
				c = class2.method_0(context, alignment, bodyType);
				Class5686 class4 = class3.method_4(context.method_10());
				context.method_12();
				class4 = class4.method_4(method_0().imethod_29());
				int p = class4.method_3();
				int breakClass = class4.method_2();
				@break = Class5676.smethod_1(@break, context.method_57());
				if (@break != 9)
				{
					p = -Class5337.int_0;
					breakClass = @break;
				}
				@interface = new Class5495(arrayList, arrayList.Count);
				class5 = (Class5328)@interface.imethod_3();
				Class5336 class6 = ((!(class5 is Class5344)) ? ((Class5336)class5) : ((Class5336)@interface.imethod_3()));
				class6.method_6(p);
				class6.method_8(breakClass);
				arrayList.AddRange(c);
				@break = context.method_59();
			}
		}
		@interface = new Class5495(arrayList, arrayList.Count);
		class5 = (Class5328)@interface.imethod_3();
		if (class5 is Class5344)
		{
			Class5336 class7 = (Class5336)@interface.imethod_3();
			class7.method_6(Class5337.int_0);
		}
		else
		{
			@interface.imethod_6();
		}
		context.method_15(@class);
		context.method_58(breakBefore);
		int num = method_0().method_53().method_75().imethod_5();
		if (num != 0 && bodyType == 0)
		{
			Class5683.smethod_1(arrayList, num);
		}
		int num2 = method_0().method_53().method_76().imethod_5();
		if (num2 != 0 && bodyType == 0)
		{
			Class5683.smethod_2(arrayList, num2);
		}
		return arrayList;
	}

	internal int method_14(Class5631 gu)
	{
		return method_15(gu.method_32());
	}

	protected internal int method_15(int colIndex)
	{
		return int_2 + method_0().method_54().method_7(colIndex + 1, method_0());
	}

	internal void method_16(Class5652 parentIter, Class5687 layoutContext)
	{
		int_3 = 0;
		Class5655 @class = new Class5655(this, layoutContext);
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = null;
		ArrayList arrayList3 = null;
		Class5254 class2 = null;
		Class5254 class3 = null;
		Class5254 pos = null;
		while (parentIter.imethod_0())
		{
			Class5254 class4 = (Class5254)parentIter.imethod_1();
			if (class4 is Class5644.Class5263)
			{
				class4 = ((Class5644.Class5263)class4).method_8();
			}
			if (class4 == null)
			{
				continue;
			}
			if (class2 == null)
			{
				class2 = class4;
			}
			class3 = class4;
			if (class4.method_4() >= 0)
			{
				pos = class4;
			}
			if (class4 is Class5266)
			{
				Class5266 class5 = (Class5266)class4;
				if (class5.bool_0)
				{
					arrayList2 = class5.arrayList_0;
				}
				else
				{
					arrayList3 = class5.arrayList_0;
				}
			}
			else if (!(class4 is Class5267) && class4 is Class5265)
			{
				arrayList.Add(class4);
			}
		}
		if (class3 is Class5267)
		{
			Class5267 class6 = (Class5267)class3;
			if (class6.arrayList_0 != null)
			{
				arrayList2 = class6.arrayList_0;
			}
			if (class6.arrayList_1 != null)
			{
				arrayList3 = class6.arrayList_1;
			}
		}
		Hashtable hashtable = method_0().method_53().method_32();
		if (hashtable != null)
		{
			method_0().method_15().method_23(hashtable, starting: true, method_0().method_16(class2), method_0().method_17(pos));
		}
		if (arrayList2 != null)
		{
			method_17(arrayList2, class5287_0.method_53().method_60(), @class, lastOnPage: false);
		}
		if (arrayList.Count != 0)
		{
			method_18(new Class5495(arrayList), @class, arrayList3 == null);
		}
		if (arrayList3 != null)
		{
			method_17(arrayList3, class5287_0.method_53().method_61(), @class, lastOnPage: true);
		}
		int_3 += @class.method_2();
		if (hashtable != null)
		{
			method_0().method_15().method_23(hashtable, starting: false, method_0().method_16(class2), method_0().method_17(pos));
		}
	}

	private void method_17(ArrayList elements, Class5151 part, Class5655 painter, bool lastOnPage)
	{
		ArrayList arrayList = new ArrayList(elements.Count);
		Interface208 @interface = new Class5653(elements);
		while (@interface.imethod_0())
		{
			Class5254 @class = (Class5254)@interface.imethod_1();
			if (@class is Class5265)
			{
				arrayList.Add((Class5265)@class);
			}
		}
		method_19(arrayList, painter, part, isFirstPos: true, isLastPos: true, lastInBody: true, lastOnPage);
	}

	private void method_18(Interface208 iterator, Class5655 painter, bool lastOnPage)
	{
		painter.method_10();
		ArrayList arrayList = new ArrayList();
		Class5265 @class = (Class5265)iterator.imethod_1();
		bool isFirstPos = @class.method_10(Class5265.int_1) && @class.method_8().method_10(Class5645.int_0);
		Class5151 class2 = @class.method_9();
		arrayList.Add(@class);
		while (iterator.imethod_0())
		{
			@class = (Class5265)iterator.imethod_1();
			if (@class.method_9() != class2)
			{
				method_19(arrayList, painter, class2, isFirstPos, isLastPos: true, lastInBody: false, lastOnPage: false);
				isFirstPos = true;
				arrayList.Clear();
				class2 = @class.method_9();
			}
			arrayList.Add(@class);
		}
		bool isLastPos = @class.method_10(Class5265.int_2) && @class.method_8().method_10(Class5645.int_1);
		method_19(arrayList, painter, class2, isFirstPos, isLastPos, lastInBody: true, lastOnPage);
		painter.method_11();
	}

	private void method_19(ArrayList positions, Class5655 painter, Class5151 body, bool isFirstPos, bool isLastPos, bool lastInBody, bool lastOnPage)
	{
		method_0().method_15().method_23(body.method_32(), starting: true, isFirstPos, isLastPos);
		painter.method_0(body);
		Interface208 @interface = new Class5495(positions);
		while (@interface.imethod_0())
		{
			painter.method_3((Class5265)@interface.imethod_1());
		}
		method_0().method_15().method_23(body.method_32(), starting: false, isFirstPos, isLastPos);
		painter.method_1(lastInBody, lastOnPage);
	}

	internal void method_20(int startXOffset)
	{
		int_2 = startXOffset;
	}

	internal int method_21()
	{
		return int_3;
	}

	public int imethod_0(int lengthBase, Class5094 fobj)
	{
		return class5287_0.imethod_0(lengthBase, fobj);
	}
}
