using System.Collections;
using ns173;
using ns181;
using ns183;
using ns190;

namespace ns182;

internal class Class5433
{
	private Class5433()
	{
	}

	public static void smethod_0(Class5127 ps)
	{
		ArrayList ranges = smethod_12(ps.method_21(new Stack()));
		smethod_2(ranges);
	}

	public static void smethod_1(Class4972 la)
	{
		ArrayList arrayList = smethod_3(la.method_39(), new ArrayList());
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class5742 @class = (Class5742)arrayList[i];
			if (!@class.method_5() || @class.method_1() != -1)
			{
				continue;
			}
			int[] array = @class.method_3();
			if (array != null)
			{
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = 0;
				}
				@class.method_4(array);
			}
		}
		arrayList = smethod_4(arrayList);
		int[] array2 = smethod_5(arrayList, null);
		int num = array2[0];
		int num2 = array2[1];
		if (num2 > 0)
		{
			int num3 = num2;
			int num4 = (((num & 1) == 0) ? (num + 1) : num);
			while (num3 >= num4)
			{
				arrayList = smethod_6(arrayList, num3);
				num3--;
			}
		}
		smethod_8(arrayList, mirror: true);
		smethod_10(la, smethod_9(arrayList));
	}

	private static void smethod_2(ArrayList ranges)
	{
		Interface208 @interface = new Class5495(ranges);
		while (@interface.imethod_0())
		{
			Class5727 @class = (Class5727)@interface.imethod_1();
			@class.method_4();
		}
	}

	private static ArrayList smethod_3(ArrayList inlines, ArrayList runs)
	{
		Interface208 @interface = new Class5495(inlines);
		while (@interface.imethod_0())
		{
			Class4943 @class = (Class4943)@interface.imethod_1();
			runs = @class.vmethod_8(runs);
		}
		return runs;
	}

	private static ArrayList smethod_4(ArrayList runs)
	{
		ArrayList arrayList = new ArrayList();
		Interface208 @interface = new Class5495(runs);
		while (@interface.imethod_0())
		{
			Class5742 @class = (Class5742)@interface.imethod_1();
			if (@class.method_5())
			{
				arrayList.Add(@class);
			}
			else
			{
				arrayList.AddRange(@class.method_6());
			}
		}
		if (!arrayList.Equals(runs))
		{
			runs = arrayList;
		}
		return runs;
	}

	private static int[] smethod_5(ArrayList runs, int[] mm)
	{
		if (mm == null)
		{
			mm = new int[2] { 2147483647, -2147483648 };
		}
		Interface208 @interface = new Class5495(runs);
		while (@interface.imethod_0())
		{
			Class5742 @class = (Class5742)@interface.imethod_1();
			@class.method_7(mm);
		}
		return mm;
	}

	private static ArrayList smethod_6(ArrayList runs, int level)
	{
		ArrayList arrayList = new ArrayList();
		int i = 0;
		for (int count = runs.Count; i < count; i++)
		{
			Class5742 @class = (Class5742)runs[i];
			if (@class.method_1() < level)
			{
				arrayList.Add(@class);
				continue;
			}
			int num = i;
			int j;
			for (j = num; j < count; j++)
			{
				Class5742 class2 = (Class5742)runs[j];
				if (class2.method_1() < level)
				{
					break;
				}
			}
			if (num < j)
			{
				arrayList.AddRange(smethod_7(runs, num, j));
			}
			i = j - 1;
		}
		if (!arrayList.Equals(runs))
		{
			runs = arrayList;
		}
		return runs;
	}

	private static ArrayList smethod_7(ArrayList runs, int s, int e)
	{
		int num = e - s;
		ArrayList arrayList = new ArrayList(num);
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				int num2 = num - i - 1;
				Class5742 @class = (Class5742)runs[s + num2];
				@class.method_9();
				arrayList.Add(@class);
			}
		}
		return arrayList;
	}

	private static void smethod_8(ArrayList runs, bool mirror)
	{
		Interface208 @interface = new Class5495(runs);
		while (@interface.imethod_0())
		{
			Class5742 @class = (Class5742)@interface.imethod_1();
			@class.method_10(mirror);
		}
	}

	private static ArrayList smethod_9(ArrayList runs)
	{
		return runs;
	}

	private static void smethod_10(Class4972 la, ArrayList runs)
	{
		ArrayList arrayList = new ArrayList();
		Interface208 @interface = new Class5495(runs);
		while (@interface.imethod_0())
		{
			Class5742 @class = (Class5742)@interface.imethod_1();
			arrayList.Add(@class.method_0());
		}
		la.method_38(smethod_11(arrayList));
	}

	private static ArrayList smethod_11(ArrayList inlines)
	{
		return new Class5435(inlines).method_0();
	}

	private static ArrayList smethod_12(Stack ranges)
	{
		ArrayList arrayList = new ArrayList();
		foreach (Class5727 range in ranges)
		{
			if (!range.method_3())
			{
				arrayList.Add(range);
			}
		}
		return arrayList;
	}
}
