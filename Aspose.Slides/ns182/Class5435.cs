using System.Collections;
using ns173;
using ns181;
using ns183;

namespace ns182;

internal class Class5435
{
	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	private int int_0;

	private Class4948 class4948_0;

	private Class4948 class4948_1;

	private Stack stack_0;

	private Stack stack_1;

	internal Class5435(ArrayList inlines)
	{
		arrayList_0 = inlines;
		arrayList_1 = new ArrayList();
		int_0 = -1;
		stack_0 = new Stack();
		stack_1 = new Stack();
	}

	internal ArrayList method_0()
	{
		if (arrayList_0 != null)
		{
			foreach (Class4943 item in arrayList_0)
			{
				method_1(item);
			}
		}
		method_11();
		return arrayList_1;
	}

	private void method_1(Class4943 ia)
	{
		method_2(smethod_10(ia), smethod_9(ia), ia);
	}

	private void method_2(ArrayList ich, Class4948 tc, Class4943 ia)
	{
		if (class4948_1 == null || tc != class4948_1)
		{
			method_6(tc, ia);
			method_10(ich, tc);
			method_12(ich, tc, ia);
		}
	}

	private bool method_3(Class4948 tc, Class4943 ia)
	{
		if (class4948_0 != null && tc != class4948_0)
		{
			return true;
		}
		if (int_0 != -1 && ia.method_18() != int_0)
		{
			return true;
		}
		return false;
	}

	private void method_4()
	{
		method_5(null);
	}

	private void method_5(Class4948 tc)
	{
		if (class4948_1 != null)
		{
			smethod_8(class4948_1);
			if (stack_1.Count != 0)
			{
				((Class4944)stack_1.Peek()).vmethod_2(class4948_1);
			}
			else
			{
				arrayList_1.Add(class4948_1);
			}
		}
		class4948_1 = null;
	}

	private void method_6(Class4948 tc, Class4943 ia)
	{
		if (method_3(tc, ia))
		{
			method_5(tc);
		}
	}

	private bool method_7(ArrayList ich, Class4948 tc)
	{
		if (ich != null && ich.Count != 0)
		{
			if (stack_0.Count != 0)
			{
				Class4944 @class = (Class4944)ich[0];
				Class4944 class2 = (Class4944)stack_0.Peek();
				if (@class != class2)
				{
					return !smethod_11(@class, class2);
				}
				return false;
			}
			return false;
		}
		return stack_0.Count != 0;
	}

	private void method_8()
	{
		method_9(null, null);
	}

	private void method_9(ArrayList ich, Class4948 tc)
	{
		if (ich != null && ich.Count != 0)
		{
			Interface208 @interface = new Class5495(ich);
			while (@interface.imethod_0())
			{
				Class4944 @class = (Class4944)@interface.imethod_1();
				Class4944 class2 = ((stack_0.Count == 0) ? null : ((Class4944)stack_0.Peek()));
				if (class2 != null)
				{
					if (@class == class2)
					{
						break;
					}
					stack_0.Pop();
					Class4944 class3 = (Class4944)stack_1.Pop();
					if (stack_1.Count == 0)
					{
						arrayList_1.Add(class3);
					}
					else
					{
						((Class4944)stack_1.Peek()).vmethod_2(class3);
					}
					if (stack_0.Count != 0 && stack_0.Peek() == @class)
					{
						break;
					}
				}
			}
			return;
		}
		while (stack_1.Count != 0)
		{
			stack_0.Pop();
			Class4944 class4 = (Class4944)stack_1.Pop();
			if (stack_1.Count == 0)
			{
				arrayList_1.Add(class4);
			}
			else
			{
				((Class4944)stack_1.Peek()).vmethod_2(class4);
			}
		}
	}

	private void method_10(ArrayList ich, Class4948 tc)
	{
		if (method_7(ich, tc))
		{
			method_9(ich, tc);
		}
	}

	private void method_11()
	{
		method_4();
		method_8();
	}

	private void method_12(ArrayList ich, Class4948 tc, Class4943 ia)
	{
		if (!method_13(ia))
		{
			if (ich != null && ich.Count != 0)
			{
				method_14(ich);
			}
			if (tc != null)
			{
				method_15(tc, ia);
			}
			else
			{
				method_16(ia);
			}
			int_0 = ia.method_18();
			class4948_0 = tc;
		}
		else if (class4948_1 != null)
		{
			method_4();
			class4948_0 = null;
		}
		else
		{
			class4948_0 = null;
		}
	}

	private bool method_13(Class4943 ia)
	{
		foreach (Class4944 item in arrayList_1)
		{
			if (ia.method_49(item))
			{
				return true;
			}
		}
		return false;
	}

	private void method_14(ArrayList ich)
	{
		ArrayList arrayList = new ArrayList();
		foreach (Class4944 item in ich)
		{
			if (!stack_0.Contains(item))
			{
				arrayList.Insert(0, item);
				continue;
			}
			break;
		}
		foreach (Class4944 item2 in arrayList)
		{
			stack_0.Push(item2);
			stack_1.Push(smethod_0(item2));
		}
	}

	private void method_15(Class4948 tc, Class4943 ia)
	{
		if (tc is Class4949)
		{
			class4948_1 = tc;
			return;
		}
		if (class4948_1 == null)
		{
			class4948_1 = smethod_7(tc);
		}
		class4948_1.vmethod_2(ia);
	}

	private void method_16(Class4943 ia)
	{
		if (stack_1.Count == 0)
		{
			arrayList_1.Add(ia);
		}
		else
		{
			((Class4944)stack_1.Peek()).vmethod_2(ia);
		}
	}

	private static Class4944 smethod_0(Class4944 i)
	{
		if (i is Class4945)
		{
			return smethod_1((Class4945)i);
		}
		if (i is Class4946)
		{
			return smethod_3((Class4946)i);
		}
		return smethod_5(i);
	}

	private static Class4944 smethod_1(Class4945 l)
	{
		Class4945 @class = new Class4945();
		if (l != null)
		{
			smethod_6(@class, l);
			smethod_2(@class, l);
		}
		return @class;
	}

	private static void smethod_2(Class4945 lc, Class4945 l)
	{
		Class5434 @class = l.method_54();
		if (@class != null)
		{
			string[] array = @class.imethod_3();
			if (array.Length > 0)
			{
				string id = array[0];
				Class5434 class2 = new Class5434(id, lc);
				lc.method_53(class2);
				@class.method_1(class2);
			}
		}
	}

	private static Class4944 smethod_3(Class4946 f)
	{
		Class4946 @class = new Class4946();
		if (f != null)
		{
			smethod_6(@class, f);
			smethod_4(@class, f);
		}
		return @class;
	}

	private static void smethod_4(Class4946 fc, Class4946 f)
	{
		fc.method_11(f.method_12());
		fc.method_53(f.method_54());
	}

	private static Class4944 smethod_5(Class4944 i)
	{
		Class4944 @class = new Class4944();
		if (i != null)
		{
			smethod_6(@class, i);
		}
		return @class;
	}

	private static void smethod_6(Class4944 ic, Class4944 i)
	{
		ic.method_30(i.method_31());
		ic.method_13(i.vmethod_1());
		ic.method_41(i.method_42());
	}

	private static Class4948 smethod_7(Class4948 t)
	{
		Class4948 @class = new Class4948();
		if (t != null)
		{
			@class.method_30(t.method_31());
			@class.method_13(t.vmethod_1());
			@class.method_41(t.method_42());
			@class.method_59(t.method_58());
			@class.method_54(t.method_53());
			@class.method_56(t.method_55());
		}
		return @class;
	}

	private static void smethod_8(Class4948 tc)
	{
		int num = 0;
		foreach (Class4943 item in tc.vmethod_9())
		{
			if (item is Class4955)
			{
				Class4955 class2 = (Class4955)item;
				if (class2.method_52())
				{
					num++;
				}
			}
		}
		if (num > 0)
		{
			tc.method_11(tc.method_12() + num * tc.method_53());
		}
	}

	private static Class4948 smethod_9(Class4943 ia)
	{
		Class4948 @class = null;
		while (@class == null)
		{
			if (ia is Class4948)
			{
				@class = (Class4948)ia;
				continue;
			}
			Class4942 class2 = ia.method_28();
			if (!(class2 is Class4943))
			{
				break;
			}
			ia = (Class4943)class2;
		}
		return @class;
	}

	private static ArrayList smethod_10(Class4943 ia)
	{
		ArrayList arrayList = new ArrayList();
		Class4942 @class = ia.method_28();
		while (@class != null)
		{
			if (@class is Class4943)
			{
				if (@class is Class4944 && !(@class is Class4948))
				{
					arrayList.Add((Class4944)@class);
				}
				@class = ((Class4943)@class).method_28();
			}
			else
			{
				@class = null;
			}
		}
		return arrayList;
	}

	private static bool smethod_11(Class4944 ic0, Class4944 ic1)
	{
		return ic0.method_28() == ic1;
	}
}
