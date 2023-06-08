using System.Collections;
using ns183;
using ns205;

namespace ns196;

internal class Class5345
{
	internal class Class5346
	{
		private Class5345 class5345_0;

		internal int int_0;

		internal int int_1 = -1;

		internal int int_2 = -1;

		internal Class5346(Class5345 owner)
		{
			class5345_0 = owner;
		}

		internal void method_0()
		{
			int_0 = 0;
			int_1 = -1;
			int_2 = -1;
		}

		public Class5346 method_1()
		{
			Class5346 @class = new Class5346(class5345_0);
			@class.int_0 = int_0;
			@class.int_1 = int_1;
			@class.int_2 = int_2;
			return @class;
		}

		public int method_2()
		{
			return int_0;
		}

		public int method_3()
		{
			return int_2;
		}

		public int method_4()
		{
			return int_1;
		}

		public string method_5()
		{
			return "length=" + int_0 + ", index=" + int_1 + ", elt=" + int_2;
		}
	}

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	private bool bool_0;

	private int int_0;

	private Class5746 class5746_0;

	private Class5346 class5346_0;

	public Class5345(Class5746 separatorLength)
	{
		class5746_0 = separatorLength;
		class5346_0 = new Class5346(this);
	}

	public void method_0()
	{
		arrayList_0 = null;
		arrayList_1 = null;
		bool_0 = false;
		int_0 = 0;
		class5346_0.method_0();
	}

	public Class5346 method_1()
	{
		return class5346_0;
	}

	public Class5746 method_2()
	{
		return class5746_0;
	}

	public int method_3()
	{
		if (arrayList_1 != null && arrayList_1.Count != 0)
		{
			return (int)arrayList_1[arrayList_1.Count - 1];
		}
		return 0;
	}

	public bool method_4()
	{
		if (arrayList_0 != null)
		{
			return arrayList_0.Count > 0;
		}
		return false;
	}

	public void method_5()
	{
		bool_0 = false;
	}

	public bool method_6()
	{
		return bool_0;
	}

	public void method_7(ArrayList elementLists)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
			arrayList_1 = new ArrayList();
		}
		if (!bool_0)
		{
			bool_0 = true;
			int_0 = arrayList_0.Count;
		}
		Interface168 @interface = new Class5495(elementLists);
		while (@interface.imethod_0())
		{
			ArrayList arrayList = (ArrayList)@interface.imethod_1();
			Class5644.smethod_6(arrayList);
			int num = 0;
			arrayList_0.Add(arrayList);
			Interface168 interface2 = new Class5495(arrayList);
			while (interface2.imethod_0())
			{
				Class5337 @class = (Class5337)interface2.imethod_1();
				if (@class.vmethod_0() || @class.vmethod_1())
				{
					num += @class.method_4();
				}
			}
			arrayList_1.Add(method_3() + num);
		}
	}

	public void method_8(Class5346 info)
	{
		class5346_0.int_0 = info.int_0;
		class5346_0.int_2 = info.int_2;
		class5346_0.int_1 = info.int_1;
	}

	public bool method_9()
	{
		return class5346_0.int_0 < method_3();
	}

	public int method_10()
	{
		return arrayList_0.Count - 1 - class5346_0.int_1;
	}

	public bool method_11()
	{
		return class5346_0.int_2 < ((ArrayList)arrayList_0[class5346_0.int_1]).Count - 1;
	}

	public ArrayList method_12(int index)
	{
		if (arrayList_0 == null)
		{
			return null;
		}
		return (ArrayList)arrayList_0[index];
	}

	public int method_13(Class5346 prevNodeProgress, int availableLength, bool canDeferOldFootnotes)
	{
		if (availableLength <= 0)
		{
			class5346_0.int_0 = prevNodeProgress.method_2();
			return 0;
		}
		int num = 0;
		Interface168 @interface = null;
		Class5337 @class = null;
		bool flag = false;
		int num2 = prevNodeProgress.int_1;
		int int_ = prevNodeProgress.int_2;
		if (num2 != -1 && int_ != ((ArrayList)arrayList_0[num2]).Count - 1)
		{
			int_++;
		}
		else
		{
			num2++;
			int_ = 0;
		}
		if (arrayList_0.Count - 1 > num2)
		{
			if (!canDeferOldFootnotes && method_6() && int_0 > 0)
			{
				num = (int)arrayList_1[int_0 - 1] - prevNodeProgress.int_0;
				num2 = int_0;
				int_ = 0;
			}
			while ((int)arrayList_1[num2] - prevNodeProgress.int_0 <= availableLength)
			{
				num = (int)arrayList_1[num2] - prevNodeProgress.int_0;
				flag = true;
				num2++;
				int_ = 0;
			}
		}
		@interface = new Class5495((ArrayList)arrayList_0[num2], int_);
		int num3 = 0;
		int num4 = -1;
		int num5 = -1;
		while (!flag || num <= availableLength)
		{
			if (!flag)
			{
				flag = true;
			}
			else
			{
				num3 = num;
				num4 = num5;
			}
			bool flag2 = false;
			while (@interface.imethod_0())
			{
				@class = (Class5337)@interface.imethod_1();
				if (@class.vmethod_0())
				{
					num += @class.method_4();
					flag2 = true;
				}
				else if (@class.vmethod_1())
				{
					if (flag2)
					{
						num5 = @interface.imethod_5();
						break;
					}
					flag2 = false;
					num += @class.method_4();
				}
				else if (@class.vmethod_5() < Class5337.int_0)
				{
					num5 = @interface.imethod_5();
					break;
				}
			}
		}
		if (!flag)
		{
			num3 = 0;
		}
		else if (num3 > 0)
		{
			class5346_0.int_1 = ((num4 != -1) ? num2 : (num2 - 1));
			class5346_0.int_2 = ((num4 != -1) ? num4 : (((ArrayList)arrayList_0[class5346_0.int_1]).Count - 1));
		}
		class5346_0.int_0 = prevNodeProgress.method_2() + num3;
		return num3;
	}

	public int method_14(Class5346 prevProgress, int availableLength)
	{
		int num = 0;
		int i;
		for (i = prevProgress.int_1 + 1; i < arrayList_0.Count && (int)arrayList_1[i] - prevProgress.int_0 <= availableLength; i++)
		{
			num = (int)arrayList_1[i] - prevProgress.int_0;
		}
		class5346_0.int_1 = i - 1;
		class5346_0.int_0 = prevProgress.int_0 + num;
		return num;
	}

	public void method_15()
	{
		class5346_0.int_0 = method_3();
		class5346_0.int_1 = arrayList_0.Count - 1;
		class5346_0.int_2 = ((ArrayList)arrayList_0[class5346_0.int_1]).Count - 1;
	}

	public void method_16(ArrayList elementLists)
	{
		for (int i = 0; i < elementLists.Count; i++)
		{
			arrayList_0.Remove(arrayList_0.Count - 1);
			arrayList_1.Remove(arrayList_1.Count - 1);
		}
	}

	public void method_17(Class5395.Class5400 lastNode, Class5395 algo, int lineWidth)
	{
		class5346_0.int_0 = lastNode.class5346_0.method_2();
		class5346_0.int_1 = lastNode.class5346_0.method_4();
		class5346_0.int_2 = lastNode.class5346_0.method_3();
		int num = lineWidth;
		int num2 = 0;
		Class5395.Class5400 @class = lastNode;
		while (class5346_0.int_0 < method_3())
		{
			if ((int)arrayList_1[class5346_0.int_1] - class5346_0.int_0 <= num)
			{
				num -= (int)arrayList_1[class5346_0.int_1] - class5346_0.int_0;
				class5346_0.int_0 = (int)arrayList_1[class5346_0.int_1];
				class5346_0.int_2 = ((ArrayList)arrayList_0[class5346_0.int_1]).Count - 1;
			}
			else if ((num2 = method_13(class5346_0, num, canDeferOldFootnotes: true)) > 0)
			{
				num -= num2;
			}
			else
			{
				Class5395.Class5400 class2 = (Class5395.Class5400)algo.vmethod_7(lastNode.int_0, @class.int_1 + 1, 1, class5346_0.int_0 - @class.class5346_0.method_2(), 0, 0, 0.0, 0, 0, 0, 0.0, @class);
				algo.vmethod_20(class2.int_1, class2);
				algo.method_15(@class.int_1, @class);
				@class = class2;
				num = lineWidth;
			}
		}
		Class5395.Class5400 class3 = (Class5395.Class5400)algo.vmethod_7(lastNode.int_0, @class.int_1 + 1, 1, method_3() - @class.class5346_0.method_2(), 0, 0, 0.0, 0, 0, 0, 0.0, @class);
		algo.vmethod_20(class3.int_1, class3);
		algo.method_15(@class.int_1, @class);
	}

	public void method_18(Class5395.Class5400 lastNode, Class5395 algo, int lineWidth)
	{
		class5346_0.int_0 = lastNode.class5346_1.method_2();
		class5346_0.int_1 = lastNode.class5346_1.method_4();
		int num = lineWidth;
		Class5395.Class5400 @class = lastNode;
		while (class5346_0.int_0 < method_3())
		{
			if ((int)arrayList_1[class5346_0.int_1 + 1] - class5346_0.int_0 <= num)
			{
				class5346_0.int_1++;
				num -= (int)arrayList_1[class5346_0.int_1] - class5346_0.int_0;
				class5346_0.int_0 = (int)arrayList_1[class5346_0.int_1];
			}
			else
			{
				Class5395.Class5400 class2 = (Class5395.Class5400)algo.vmethod_7(lastNode.int_0, @class.int_1 + 1, 1, class5346_0.int_0 - @class.class5346_1.method_2(), 0, 0, 0.0, 0, 0, 0, @class.double_1 + (double)((class5346_0.int_1 - @class.class5346_1.int_1) * 10000), @class);
				algo.vmethod_20(class2.int_1, class2);
				algo.method_15(@class.int_1, @class);
				@class = class2;
				num = lineWidth;
			}
		}
		Class5395.Class5400 class3 = (Class5395.Class5400)algo.vmethod_7(lastNode.int_0, @class.int_1 + 1, 1, method_3() - @class.class5346_1.method_2(), 0, 0, 0.0, 0, 0, 0, @class.double_1 + (double)((class5346_0.int_1 - @class.class5346_1.int_1) * 10000), @class);
		algo.vmethod_20(class3.int_1, class3);
		algo.method_15(@class.int_1, @class);
	}
}
