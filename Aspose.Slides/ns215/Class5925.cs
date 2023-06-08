using System.Collections;
using ns216;
using ns217;

namespace ns215;

internal class Class5925
{
	private Class5908 class5908_0;

	private int int_0;

	private Class5908 class5908_1;

	private int int_1;

	private ArrayList arrayList_0 = new ArrayList();

	private Class5923 class5923_0;

	internal Class5925(Class5835 pageSet)
	{
		class5908_0 = pageSet.method_3($"#{Class5834.Tag}[*]");
		class5908_1 = pageSet.method_3($"..#{Class5802.Tag}[*]");
		class5923_0 = new Class5923((Class5834)class5908_0.method_1(int_0));
		class5923_0.Number = 0;
		arrayList_0.Add(class5923_0);
	}

	internal Class5802 method_0()
	{
		return (Class5802)class5908_1.method_1(int_1);
	}

	internal bool method_1()
	{
		int_1++;
		if (int_1 >= class5908_1.Length)
		{
			if (int_0 < class5908_0.Length - 1)
			{
				int_0++;
				int_1 = 0;
				class5923_0 = new Class5923((Class5834)class5908_0.method_1(int_0));
				class5923_0.Number = int_0;
				arrayList_0.Add(class5923_0);
				return true;
			}
			int_1--;
			return false;
		}
		return true;
	}

	internal void method_2(Class5916 layout)
	{
		class5923_0.ContentAreas.Add(new Class5924(method_0(), layout));
	}

	internal Class5923[] method_3()
	{
		return (Class5923[])arrayList_0.ToArray(typeof(Class5923));
	}
}
