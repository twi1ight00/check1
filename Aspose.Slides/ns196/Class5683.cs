using System.Collections;
using ns183;
using ns195;
using ns205;

namespace ns196;

internal class Class5683
{
	private Class5683()
	{
	}

	public static bool smethod_0(ArrayList elements, Class5746 constraint)
	{
		return smethod_1(elements, constraint.method_2());
	}

	public static bool smethod_1(ArrayList elements, int constraint)
	{
		return smethod_3(elements, constraint, fromEnd: false);
	}

	public static bool smethod_2(ArrayList elements, int constraint)
	{
		return smethod_3(elements, constraint, fromEnd: true);
	}

	private static bool smethod_3(ArrayList elements, int constraint, bool fromEnd)
	{
		int num = 0;
		Interface168 @interface = new Class5495(elements, fromEnd ? elements.Count : 0);
		do
		{
			if (!((!fromEnd) ? @interface.imethod_0() : @interface.imethod_2()))
			{
				return true;
			}
			Class5328 @class = ((!fromEnd) ? ((Class5328)@interface.imethod_1()) : ((Class5328)@interface.imethod_3()));
			if (@class.vmethod_2())
			{
				Class5342 class2 = (Class5342)@class;
				if (class2.vmethod_5() < Class5337.int_0)
				{
					@interface.imethod_7(new Class5342(class2.method_4(), Class5337.int_0, class2.method_7(), class2.method_0(), class2.method_3()));
				}
			}
			else if (@class.vmethod_1())
			{
				Class5344 class3 = (Class5344)@class;
				num += class3.method_4();
				if (!fromEnd)
				{
					@interface.imethod_3();
				}
				@class = (Class5328)@interface.imethod_3();
				@interface.imethod_1();
				if (@class.vmethod_0())
				{
					@interface.imethod_8(new Class5342(0, Class5337.int_0, penaltyFlagged: false, null, auxiliary: false));
				}
				if (!fromEnd)
				{
					@interface.imethod_1();
				}
			}
			else if (@class.vmethod_4())
			{
				if (@class is Class5336)
				{
					Class5336 class4 = (Class5336)@class;
					if (class4.method_5() < Class5337.int_0)
					{
						class4.method_6(Class5337.int_0);
					}
				}
				else if (@class is Class5330)
				{
					Class5330 class5 = (Class5330)@class;
					num += class5.method_4().method_2();
				}
			}
			else
			{
				Class5337 class6 = (Class5337)@class;
				num += class6.method_4();
			}
		}
		while (num < constraint);
		return false;
	}

	public static int smethod_4(ArrayList elems, int start, int end)
	{
		Interface168 @interface = new Class5495(elems);
		int num = end - start + 1;
		int num2 = 0;
		while (@interface.imethod_0())
		{
			Class5328 @class = (Class5328)@interface.imethod_1();
			if (@class.vmethod_0())
			{
				num2 += ((Class5337)@class).method_4();
			}
			else if (@class.vmethod_1())
			{
				num2 += ((Class5337)@class).method_4();
			}
			num--;
			if (num == 0)
			{
				break;
			}
		}
		return num2;
	}

	public static int smethod_5(ArrayList elems)
	{
		return smethod_4(elems, 0, elems.Count - 1);
	}

	public static bool smethod_6(ArrayList elems)
	{
		object obj = Class5693.smethod_0(elems);
		if (obj is Class5328 @class)
		{
			return @class.vmethod_3();
		}
		return ((Class5328)((Class5274)obj)[0]).vmethod_3();
	}

	public static bool smethod_7(ArrayList elems)
	{
		if (elems.Count == 0)
		{
			return false;
		}
		if (elems[0] is Class5328 @class)
		{
			return @class.vmethod_3();
		}
		return ((Class5328)((Class5274)elems[0])[0]).vmethod_3();
	}

	public static bool smethod_8(ArrayList elems)
	{
		Class5328 @class = (Class5328)Class5693.smethod_0(elems);
		if (@class.vmethod_2() && ((Class5342)@class).vmethod_5() < Class5337.int_0)
		{
			return true;
		}
		if (@class is Class5336 && ((Class5336)@class).method_5() < Class5337.int_0)
		{
			return true;
		}
		return false;
	}

	public static int smethod_9(ArrayList elems, int startIndex)
	{
		int num;
		for (num = startIndex - 1; num >= 0; num--)
		{
			Class5337 @class = (Class5337)elems[num];
			if (@class.vmethod_2() && @class.vmethod_5() < Class5337.int_0)
			{
				break;
			}
		}
		return num;
	}
}
