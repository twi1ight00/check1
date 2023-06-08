using System;
using System.Collections;
using System.Text;
using ns183;
using ns205;

namespace ns196;

internal class Class5644
{
	internal class Class5263 : Class5254
	{
		private Class5644 class5644_0;

		private Class5254 class5254_0;

		public Class5263(Class5644 resolver, Class5336 breakPoss)
			: base(null)
		{
			class5644_0 = resolver;
			class5254_0 = breakPoss.method_0();
			while (class5254_0 is Class5255)
			{
				class5254_0 = class5254_0.vmethod_0();
			}
		}

		public Class5644 method_6()
		{
			return class5644_0;
		}

		public void method_7(bool isBreakSituation, Class5695 side)
		{
			if (isBreakSituation)
			{
				if (Class5695.class5695_0 == side)
				{
					for (int i = 0; i < class5644_0.class5330_1.Length; i++)
					{
						class5644_0.class5330_1[i].vmethod_6(class5644_0.class5746_1[i]);
					}
				}
				else
				{
					for (int j = 0; j < class5644_0.class5330_0.Length; j++)
					{
						class5644_0.class5330_0[j].vmethod_6(class5644_0.class5746_0[j]);
					}
				}
			}
			else
			{
				for (int k = 0; k < class5644_0.class5330_2.Length; k++)
				{
					class5644_0.class5330_2[k].vmethod_6(class5644_0.class5746_2[k]);
				}
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SpaceHandlingBreakPosition(");
			stringBuilder.Append(class5254_0);
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}

		public Class5254 method_8()
		{
			return class5254_0;
		}

		public override Class5254 vmethod_0()
		{
			return class5254_0;
		}
	}

	internal class Class5264 : Class5254
	{
		private Class5644 class5644_0;

		public Class5264(Class5644 resolver)
			: base(null)
		{
			class5644_0 = resolver;
		}

		public Class5644 method_6()
		{
			return class5644_0;
		}

		public void method_7()
		{
			if (class5644_0.class5336_0 != null)
			{
				throw new InvalidOperationException("Only applicable to no-break situations");
			}
			for (int i = 0; i < class5644_0.class5330_1.Length; i++)
			{
				class5644_0.class5330_1[i].vmethod_6(class5644_0.class5746_1[i]);
			}
		}

		public string method_8()
		{
			return "SpaceHandlingPosition";
		}
	}

	private Class5330[] class5330_0;

	private Class5336 class5336_0;

	private Class5330[] class5330_1;

	private Class5330[] class5330_2;

	private Class5746[] class5746_0;

	private Class5746[] class5746_1;

	private Class5746[] class5746_2;

	private bool bool_0;

	private bool bool_1;

	private Class5644(ArrayList first, Class5336 breakPoss, ArrayList second, bool isFirst, bool isLast)
	{
		bool_0 = isFirst;
		bool_1 = isLast;
		int num = 0;
		if (first != null)
		{
			num += first.Count;
		}
		if (second != null)
		{
			num += second.Count;
		}
		class5330_2 = new Class5330[num];
		class5746_2 = new Class5746[num];
		int num2 = 0;
		if (first != null)
		{
			Interface168 @interface = new Class5495(first);
			while (@interface.imethod_0())
			{
				class5330_2[num2] = (Class5330)@interface.imethod_1();
				class5746_2[num2] = class5330_2[num2].method_4();
				num2++;
			}
		}
		if (second != null)
		{
			Interface168 @interface = new Class5495(second);
			while (@interface.imethod_0())
			{
				class5330_2[num2] = (Class5330)@interface.imethod_1();
				class5746_2[num2] = class5330_2[num2].method_4();
				num2++;
			}
		}
		if (breakPoss != null)
		{
			if (breakPoss.method_10() != null)
			{
				first.InsertRange(0, breakPoss.method_10());
			}
			if (breakPoss.method_9() != null)
			{
				second.InsertRange(0, breakPoss.method_9());
			}
		}
		if (first != null)
		{
			class5330_0 = new Class5330[first.Count];
			class5746_0 = new Class5746[class5330_0.Length];
			class5330_0 = (Class5330[])first.ToArray(typeof(Class5330));
			for (num2 = 0; num2 < class5330_0.Length; num2++)
			{
				class5746_0[num2] = class5330_0[num2].method_4();
			}
		}
		class5336_0 = breakPoss;
		if (second != null)
		{
			class5330_1 = new Class5330[second.Count];
			class5746_1 = new Class5746[class5330_1.Length];
			class5330_1 = (Class5330[])second.ToArray(typeof(Class5330));
			for (num2 = 0; num2 < class5330_1.Length; num2++)
			{
				class5746_1[num2] = class5330_1[num2].method_4();
			}
		}
		method_2();
	}

	private static string smethod_0(object[] arr1, object[] arr2)
	{
		if (arr1.Length != arr2.Length)
		{
			throw new ArgumentException("The length of both arrays must be equal");
		}
		StringBuilder stringBuilder = new StringBuilder("[");
		for (int i = 0; i < arr1.Length; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append((string)arr1[i]);
			stringBuilder.Append("/");
			stringBuilder.Append((string)arr2[i]);
		}
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	private static void smethod_1(Class5329[] elems, Class5746[] lengths, bool reverse)
	{
		for (int i = 0; i < elems.Length; i++)
		{
			int num = ((!reverse) ? i : (elems.Length - 1 - i));
			if (elems[num] is Class5332)
			{
				Class5332 @class = (Class5332)elems[num];
				if (@class.vmethod_5() && !@class.method_7() && !@class.method_8())
				{
					lengths[num] = null;
				}
			}
		}
	}

	private static void smethod_2(Class5329[] elems, Class5746[] lengths, bool reverse)
	{
		for (int i = 0; i < elems.Length; i++)
		{
			int num = ((!reverse) ? i : (elems.Length - 1 - i));
			if (lengths[num] != null)
			{
				if (elems[num] is Class5332 || !elems[num].vmethod_5())
				{
					break;
				}
				lengths[num] = null;
			}
		}
	}

	private static void smethod_3(Class5329[] elems, Class5746[] lengths, int start, int end)
	{
		bool flag = false;
		int num = 0;
		for (int i = start; i <= end; i++)
		{
			if (lengths[i] != null)
			{
				num++;
				Class5335 @class = (Class5335)elems[i];
				if (@class.method_9())
				{
					flag = true;
					break;
				}
			}
		}
		if (num == 0)
		{
			return;
		}
		if (flag)
		{
			for (int j = start; j <= end; j++)
			{
				if (lengths[j] != null)
				{
					Class5335 @class = (Class5335)elems[j];
					if (!@class.method_9())
					{
						lengths[j] = null;
					}
				}
			}
			return;
		}
		int num2 = int.MinValue;
		for (int k = start; k <= end; k++)
		{
			if (lengths[k] != null)
			{
				Class5335 @class = (Class5335)elems[k];
				num2 = Math.Max(num2, @class.method_10());
			}
		}
		num = 0;
		int num3 = int.MinValue;
		for (int l = start; l <= end; l++)
		{
			if (lengths[l] != null)
			{
				Class5335 @class = (Class5335)elems[l];
				if (@class.method_10() != num2)
				{
					lengths[l] = null;
					continue;
				}
				num3 = Math.Max(num3, @class.method_4().method_2());
				num++;
			}
		}
		if (num <= 1)
		{
			return;
		}
		num = 0;
		for (int m = start; m <= end; m++)
		{
			if (lengths[m] != null)
			{
				Class5335 @class = (Class5335)elems[m];
				if (@class.method_4().method_2() < num3)
				{
					lengths[m] = null;
				}
				else
				{
					num++;
				}
			}
		}
		if (num <= 1)
		{
			return;
		}
		int num4 = int.MinValue;
		int num5 = int.MaxValue;
		for (int n = start; n <= end; n++)
		{
			if (lengths[n] != null)
			{
				Class5335 @class = (Class5335)elems[n];
				num4 = Math.Max(num4, @class.method_4().method_1());
				num5 = Math.Min(num5, @class.method_4().method_3());
				if (num > 1)
				{
					lengths[n] = null;
					num--;
				}
				else
				{
					lengths[n] = Class5746.smethod_0(num4, lengths[n].method_2(), num5);
				}
			}
		}
	}

	private static void smethod_4(Class5329[] elems, Class5746[] lengths)
	{
		int start = 0;
		int i = 0;
		while (i < elems.Length)
		{
			if (elems[i] is Class5335)
			{
				for (; i < elems.Length && (elems[i] == null || elems[i] is Class5335); i++)
				{
				}
				smethod_3(elems, lengths, start, i - 1);
			}
			i++;
			start = i;
		}
	}

	private bool method_0()
	{
		if (class5330_0 != null)
		{
			return class5330_0.Length > 0;
		}
		return false;
	}

	private bool method_1()
	{
		if (class5330_1 != null)
		{
			return class5330_1.Length > 0;
		}
		return false;
	}

	private void method_2()
	{
		if (class5336_0 != null)
		{
			if (method_0())
			{
				smethod_1(class5330_0, class5746_0, reverse: true);
				smethod_2(class5330_0, class5746_0, reverse: true);
				smethod_4(class5330_0, class5746_0);
			}
			if (method_1())
			{
				smethod_1(class5330_1, class5746_1, reverse: false);
				smethod_2(class5330_1, class5746_1, reverse: false);
				smethod_4(class5330_1, class5746_1);
			}
			if (class5330_2 != null)
			{
				smethod_4(class5330_2, class5746_2);
			}
			return;
		}
		if (bool_0)
		{
			smethod_1(class5330_1, class5746_1, reverse: false);
			smethod_2(class5330_1, class5746_1, reverse: false);
		}
		if (bool_1)
		{
			smethod_1(class5330_0, class5746_0, reverse: true);
			smethod_2(class5330_0, class5746_0, reverse: true);
		}
		if (method_0())
		{
			Class5330[] array = class5330_1;
			Class5746[] array2 = class5746_1;
			class5330_1 = class5330_0;
			class5746_1 = class5746_0;
			class5330_0 = array;
			class5746_0 = array2;
			if (method_0())
			{
				throw new InvalidOperationException("Didn't expect more than one parts in ano-break condition.");
			}
		}
		smethod_4(class5330_1, class5746_1);
	}

	private static Class5746 smethod_5(Class5746[] lengths)
	{
		Class5746 @class = Class5746.class5746_0;
		for (int i = 0; i < lengths.Length; i++)
		{
			if (lengths[i] != null)
			{
				@class = @class.method_6(lengths[i]);
			}
		}
		return @class;
	}

	private void method_3(Interface168 iter)
	{
		Class5746 @class = smethod_5(class5746_0);
		Class5746 class2 = smethod_5(class5746_1);
		bool flag = false;
		if (class5336_0 != null)
		{
			if (@class.method_16())
			{
				iter.imethod_8(new Class5342(0, Class5337.int_0, penaltyFlagged: false, null, auxiliary: true));
				iter.imethod_8(new Class5344(@class, null, auxiliary: true));
				if (class5336_0.vmethod_3())
				{
					iter.imethod_8(new Class5338(0, null, auxiliary: true));
				}
			}
			iter.imethod_8(new Class5342(class5336_0.method_4(), class5336_0.method_5(), penaltyFlagged: false, class5336_0.method_7(), new Class5263(this, class5336_0), isAuxiliary: false));
			if (class5336_0.method_5() <= -Class5337.int_0)
			{
				return;
			}
			Class5746 class3 = smethod_5(class5746_2);
			Class5746 class4 = @class.method_6(class2);
			int num = class3.method_2() - class4.method_2();
			int num2 = class3.method_5() - class4.method_5();
			int num3 = class3.method_4() - class4.method_4();
			if (num != 0 || num2 != 0 || num3 != 0)
			{
				iter.imethod_8(new Class5344(num, num2, num3, null, auxiliary: true));
			}
		}
		else if (@class.method_16())
		{
			throw new InvalidOperationException("spaceBeforeBreak should be 0 in this case");
		}
		Class5254 class5 = null;
		if (class5336_0 == null)
		{
			class5 = new Class5264(this);
		}
		if (class2.method_16() || class5 != null)
		{
			iter.imethod_8(new Class5338(0, class5, auxiliary: true));
		}
		if (class2.method_16())
		{
			iter.imethod_8(new Class5342(0, Class5337.int_0, penaltyFlagged: false, null, auxiliary: true));
			iter.imethod_8(new Class5344(class2, null, auxiliary: true));
			flag = true;
		}
		if (bool_1 && flag)
		{
			iter.imethod_8(new Class5338(0, null, auxiliary: true));
		}
	}

	public static void smethod_6(ArrayList elems)
	{
		bool isFirst = true;
		bool flag = false;
		bool flag2 = false;
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		Interface168 @interface = new Class5495(elems);
		while (@interface.imethod_0())
		{
			Class5328 @class = (Class5328)@interface.imethod_1();
			if (@class.vmethod_4())
			{
				Class5336 class2 = null;
				arrayList.Clear();
				arrayList2.Clear();
				ArrayList arrayList3;
				if (@class is Class5336)
				{
					class2 = (Class5336)@class;
					arrayList3 = arrayList2;
				}
				else
				{
					arrayList3 = arrayList;
					arrayList3.Add(@class);
				}
				@interface.imethod_6();
				flag = true;
				flag2 = true;
				while (@interface.imethod_0())
				{
					@class = (Class5328)@interface.imethod_1();
					if (!(@class is Class5336) || class2 == null)
					{
						if (arrayList3 == arrayList && @class is Class5336)
						{
							class2 = (Class5336)@class;
							@interface.imethod_6();
							arrayList3 = arrayList2;
							continue;
						}
						if (@class.vmethod_4())
						{
							arrayList3.Add(@class);
							@interface.imethod_6();
							continue;
						}
						flag = false;
						break;
					}
					flag2 = false;
					flag = false;
					break;
				}
				if (class2 == null && arrayList2.Count == 0 && !flag)
				{
					ArrayList arrayList4 = arrayList2;
					arrayList2 = arrayList;
					arrayList = arrayList4;
				}
				Class5644 class3 = new Class5644(arrayList, class2, arrayList2, isFirst, flag);
				if (!flag)
				{
					@interface.imethod_3();
				}
				class3.method_3(@interface);
				if (!flag && flag2)
				{
					@interface.imethod_1();
				}
			}
			isFirst = false;
		}
	}

	public static void smethod_7(ArrayList effectiveList, int startElementIndex, int endElementIndex, int prevBreak)
	{
		Class5337 @class = null;
		if (prevBreak > 0)
		{
			@class = (Class5337)effectiveList[prevBreak];
		}
		Class5263 class2 = null;
		Class5263 class3 = null;
		if (@class != null && @class.vmethod_2())
		{
			Class5254 class4 = @class.method_0();
			if (class4 is Class5263)
			{
				class2 = (Class5263)class4;
				class2.method_7(isBreakSituation: true, Class5695.class5695_0);
			}
		}
		@class = (Class5337)effectiveList[endElementIndex];
		if (@class != null && @class.vmethod_2())
		{
			Class5254 class5 = @class.method_0();
			if (class5 is Class5263)
			{
				class3 = (Class5263)class5;
				class3.method_7(isBreakSituation: true, Class5695.class5695_1);
			}
		}
		for (int i = startElementIndex; i <= endElementIndex; i++)
		{
			Class5254 class6 = ((Class5337)effectiveList[i]).method_0();
			if (class6 is Class5264)
			{
				((Class5264)class6).method_7();
			}
			else if (class6 is Class5263)
			{
				Class5263 class7 = (Class5263)class6;
				if (class7 != class2 && class7 != class3)
				{
					class7.method_7(isBreakSituation: false, null);
				}
			}
		}
	}
}
