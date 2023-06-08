using System;
using System.Collections;
using System.Drawing;
using ns166;
using ns167;

namespace ns169;

internal class Class4807
{
	private const double double_0 = 0.20000000298023224;

	private int int_0;

	private Class4786 class4786_0;

	private Class4786 class4786_1;

	private Class4786 class4786_2;

	private Hashtable hashtable_0;

	private Class4786 class4786_3;

	private Class4786 class4786_4;

	internal Class4786 TargetSpace => class4786_4;

	internal Class4807(Class4786 source)
	{
		if (source == null)
		{
			throw new ArgumentException();
		}
		class4786_0 = new Class4786();
		class4786_2 = new Class4786();
		class4786_1 = new Class4786();
		class4786_3 = source;
		class4786_4 = new Class4786();
		int_0 = -1;
		method_0();
	}

	internal void method_0()
	{
		bool flag;
		do
		{
			flag = true;
			Class4843 @class = method_1();
			if (@class != null)
			{
				method_2(@class);
				method_4(@class);
			}
			else
			{
				class4786_1.Add(class4786_2);
				class4786_2.Clear();
				flag = false;
			}
			method_5();
			method_6();
			method_7();
			method_8();
		}
		while (flag);
		class4786_3.Flush();
		class4786_4.Flush();
	}

	internal Class4843 method_1()
	{
		Class4843 result = null;
		int_0++;
		if (int_0 < class4786_3.LineCount)
		{
			result = new Class4843(class4786_3[int_0]);
		}
		return result;
	}

	internal void method_2(Class4843 newMaterial)
	{
		hashtable_0 = new Hashtable();
		foreach (Class4845 item in class4786_2)
		{
			Class4846 class2 = smethod_1(item, newMaterial);
			if (class2.method_3())
			{
				continue;
			}
			if (class2.Count == 1)
			{
				hashtable_0.Add(item, class2[0]);
			}
			else
			{
				class4786_1.Add(item.Value);
				item.Remove();
				foreach (Class4845 item2 in class2)
				{
					Class4788 element2 = new Class4788(item2);
					class4786_0.Add(element2);
				}
			}
			smethod_0(newMaterial, class2);
		}
		method_3();
	}

	internal void method_3()
	{
		Class4846 @class = method_10(class4786_2, includeCheckedSpaceElsIntoSeeds: true);
		@class.method_9(method_10(class4786_1, includeCheckedSpaceElsIntoSeeds: false));
		method_11(@class);
		if (int_0 + 1 < class4786_3.LineCount && Class4778.smethod_27(class4786_3[int_0], class4786_3[int_0 + 1]))
		{
			@class = method_10(class4786_3[int_0 + 1], includeCheckedSpaceElsIntoSeeds: false);
			method_11(@class);
		}
	}

	internal static void smethod_0(Class4843 elements, Class4846 candidates)
	{
		if (candidates == null)
		{
			return;
		}
		foreach (Class4845 candidate in candidates)
		{
			elements.method_1(candidate.Column);
		}
	}

	internal static Class4846 smethod_1(Class4845 elPtr, Class4843 elements)
	{
		if (elPtr == null)
		{
			return null;
		}
		Class4846 @class = new Class4846();
		for (int i = 0; i < elements.Source.PageElementCount; i++)
		{
			if (!elements.method_0(i))
			{
				Class4845 class2 = elements.Source.method_33(i);
				if (Class4778.smethod_19(elPtr.Value, class2.Value) || Class4778.smethod_19(class2.Value, elPtr.Value))
				{
					@class.Add(class2);
				}
			}
		}
		return @class;
	}

	internal void method_4(Class4843 newMaterial)
	{
		if (newMaterial == null)
		{
			return;
		}
		for (int i = 0; i < newMaterial.Source.PageElementCount; i++)
		{
			if (!newMaterial.method_0(i))
			{
				Class4788 element = new Class4788(newMaterial.Source.method_33(i));
				class4786_0.Add(element);
			}
		}
	}

	internal void method_5()
	{
		Class4846 overlaps = method_10(class4786_0, includeCheckedSpaceElsIntoSeeds: true);
		method_11(overlaps);
	}

	internal void method_6()
	{
		if (hashtable_0 == null)
		{
			return;
		}
		Class4786 @class = new Class4786();
		foreach (Class4845 key in hashtable_0.Keys)
		{
			Class4788 class3 = (Class4788)key.Value;
			PointF origin = class3.Origin;
			class3.Add((Class4845)hashtable_0[key]);
			if (origin != class3.Origin)
			{
				@class.Add(class3);
				key.Remove();
			}
		}
		hashtable_0.Clear();
		class4786_2.Flush();
		if (@class.ChildrenCount != 0)
		{
			class4786_2.Add(@class);
		}
	}

	internal void method_7()
	{
		class4786_2.Add(class4786_0);
		class4786_0.Clear();
	}

	internal void method_8()
	{
		foreach (Class4845 item in class4786_1)
		{
			if (!(item.Value is Class4788 class2) || !method_9(class2))
			{
				continue;
			}
			Class4785 class3 = new Class4785();
			foreach (Class4845 item2 in class2)
			{
				class3.Add(item2.Value);
			}
			foreach (Class4845 item3 in class2)
			{
				item3.Remove();
			}
			ArrayList arrayList = Class4805.smethod_1(class3);
			foreach (Class4785 item4 in arrayList)
			{
				if (item4.LineCount == 2 && (double)item4.Compactness < 0.20000000298023224)
				{
					foreach (Class4845 item5 in item4)
					{
						class4786_4.Add(item5.Value);
					}
				}
				else
				{
					class4786_4.Add(item4);
				}
			}
		}
		class4786_1.Clear();
	}

	internal bool method_9(Class4788 grownSeed)
	{
		return Class4778.smethod_29(grownSeed);
	}

	internal Class4846 method_10(IEnumerable checkedSpace, bool includeCheckedSpaceElsIntoSeeds)
	{
		Class4846 @class = new Class4846();
		if (hashtable_0 != null)
		{
			foreach (Class4845 key in hashtable_0.Keys)
			{
				if (@class.Contains(key))
				{
					continue;
				}
				Class4845 class3 = (Class4845)hashtable_0[key];
				RectangleF testedElPtr = RectangleF.Union(key.Value.BoundingBox, class3.Value.BoundingBox);
				if (testedElPtr.IsEmpty)
				{
					@class.Add(key);
					@class.Add(class3);
					continue;
				}
				foreach (Class4845 item in checkedSpace)
				{
					if (!(item == key) && !@class.Contains(item) && smethod_2(testedElPtr, item.Value))
					{
						if (includeCheckedSpaceElsIntoSeeds)
						{
							@class.Add(item);
						}
						@class.Add(key);
					}
				}
			}
		}
		return @class;
	}

	internal void method_11(Class4846 overlaps)
	{
		if (overlaps == null)
		{
			return;
		}
		Class4786 @class = new Class4786();
		Class4786 class2 = new Class4786();
		foreach (Class4845 overlap in overlaps)
		{
			if (hashtable_0.ContainsKey(overlap))
			{
				Class4845 element = (Class4845)hashtable_0[overlap];
				Class4788 element2 = new Class4788(element);
				@class.Add(element2);
				hashtable_0.Remove(overlap);
			}
			class2.Add(overlap.Value);
			overlap.Remove();
		}
		class4786_0.Add(@class);
		class4786_1.Add(class2);
	}

	internal static bool smethod_2(RectangleF testedElPtr, Class4779 seed)
	{
		if (seed == null)
		{
			return false;
		}
		return !Class4778.smethod_24(seed.BoundingBox, testedElPtr) | !Class4778.smethod_24(testedElPtr, seed.BoundingBox);
	}
}
