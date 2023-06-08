using System.Collections;
using System.Text;
using ns171;
using ns183;
using ns195;
using ns205;

namespace ns182;

internal class Class5727
{
	private Class5088 class5088_0;

	private StringBuilder stringBuilder_0;

	private ArrayList arrayList_0;

	public Class5727(Class5088 fn)
	{
		class5088_0 = fn;
		stringBuilder_0 = new StringBuilder();
		arrayList_0 = new ArrayList();
	}

	public Class5088 method_0()
	{
		return class5088_0;
	}

	public void method_1(Class5656 it, Class5088 fN)
	{
		if (it != null)
		{
			int length = stringBuilder_0.Length;
			int num = length;
			while (it.imethod_0())
			{
				char value = it.vmethod_0();
				stringBuilder_0.Append(value);
				num++;
			}
			arrayList_0.Add(new Class5756(fN, length, num));
		}
	}

	public void method_2(char c, Class5088 fN)
	{
		if (c != 0)
		{
			int length = stringBuilder_0.Length;
			int end = length + 1;
			stringBuilder_0.Append(c);
			arrayList_0.Add(new Class5756(fN, length, end));
		}
	}

	public bool method_3()
	{
		return stringBuilder_0.Length == 0;
	}

	public void method_4()
	{
		Interface231 @interface;
		if ((@interface = Class5678.smethod_0(method_0())) != null)
		{
			method_5(@interface.imethod_0());
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("DR: " + class5088_0.vmethod_21() + " { <" + Class5710.smethod_9(stringBuilder_0.ToString()) + ">");
		stringBuilder.Append(", intervals <");
		bool flag = true;
		foreach (Class5756 item in arrayList_0)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				stringBuilder.Append(',');
			}
			stringBuilder.Append(item.method_9());
		}
		stringBuilder.Append("> }");
		return stringBuilder.ToString();
	}

	private void method_5(Class5444 paragraphEmbeddingLevel)
	{
		int[] levels;
		if ((levels = Class4983.smethod_0(new Class5709(stringBuilder_0.ToString().ToCharArray()), paragraphEmbeddingLevel)) != null)
		{
			method_6(levels);
			method_8(paragraphEmbeddingLevel);
			method_7();
		}
	}

	private void method_6(int[] levels)
	{
		ArrayList arrayList = new ArrayList(arrayList_0.Count);
		foreach (Class5756 item in arrayList_0)
		{
			arrayList.AddRange(smethod_0(item, levels));
		}
		if (!arrayList.Equals(arrayList_0))
		{
			arrayList_0 = arrayList;
		}
	}

	private static ArrayList smethod_0(Class5756 ti, int[] levels)
	{
		ArrayList arrayList = new ArrayList();
		Class5088 fn = ti.method_0();
		int num = ti.method_2();
		int num2 = num;
		int num3 = ti.method_3();
		while (num2 < num3)
		{
			int num4 = num2;
			int i = num4;
			int num5;
			for (num5 = levels[num4]; i < num3 && levels[i] == num5; i++)
			{
			}
			if (ti.method_2() == num4 && ti.method_3() == i)
			{
				ti.method_5(num5);
			}
			else
			{
				ti = new Class5756(fn, num, num4, i, num5);
			}
			arrayList.Add(ti);
			num2 = i;
		}
		return arrayList;
	}

	private void method_7()
	{
		foreach (Class5756 item in arrayList_0)
		{
			item.method_8();
		}
	}

	private void method_8(Class5444 paragraphEmbeddingLevel)
	{
		int defaultLevel = ((paragraphEmbeddingLevel == Class5444.class5444_1) ? 1 : 0);
		foreach (Class5756 item in arrayList_0)
		{
			smethod_1(item.method_0(), defaultLevel);
		}
	}

	private static void smethod_1(Class5088 node, int defaultLevel)
	{
		Class5088 @class = node;
		Class5094 class2;
		while (true)
		{
			if (@class == null)
			{
				return;
			}
			if (@class is Class5094)
			{
				class2 = (Class5094)@class;
				if (class2.vmethod_28())
				{
					break;
				}
			}
			@class = @class.method_4();
		}
		if (class2.method_41() < 0)
		{
			class2.method_40(defaultLevel);
		}
	}
}
