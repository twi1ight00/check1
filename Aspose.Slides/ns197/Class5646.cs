using System;
using System.Collections;
using ns183;
using ns187;
using ns192;
using ns196;
using ns205;

namespace ns197;

internal class Class5646
{
	private class Class5647
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal int int_3;

		internal int int_4;

		internal int int_5;

		internal ArrayList arrayList_0;

		internal int int_6;

		internal int int_7;

		internal Class5647(int contentLength)
		{
			int_2 = contentLength;
			int_1 = -1;
		}

		internal Class5647(Class5647 other)
		{
			method_0(other);
		}

		internal void method_0(Class5647 other)
		{
			int_0 = other.int_0;
			int_1 = other.int_1;
			int_2 = other.int_2;
			int_3 = other.int_3;
			int_4 = other.int_4;
			int_5 = other.int_5;
			if (other.arrayList_0 != null)
			{
				if (arrayList_0 == null)
				{
					arrayList_0 = new ArrayList();
				}
				arrayList_0.AddRange(other.arrayList_0);
			}
			int_7 = other.int_7;
			int_6 = other.int_6;
		}

		public override string ToString()
		{
			return "Step: start=" + int_0 + " end=" + int_1 + " length=" + int_3;
		}
	}

	private class Class5343 : Class5342
	{
		internal int int_5;

		internal Class5343(Class5342 p, int length)
			: base(length, p.vmethod_5(), p.method_7(), p.method_8(), p.method_0(), p.method_3())
		{
			int_5 = p.method_4();
		}

		internal Class5343(int length)
			: base(length, 0, penaltyFlagged: false, null, auxiliary: true)
		{
			int_5 = 0;
		}
	}

	private class Class5340 : Class5338
	{
		internal Class5340(int length)
			: base(length, null, auxiliary: true)
		{
		}
	}

	private Class5631 class5631_0;

	private ArrayList arrayList_0;

	private Interface168 interface168_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private bool bool_0;

	private Class5686 class5686_0;

	private int int_12;

	private Class5647 class5647_0;

	private Class5647 class5647_1;

	private Class5647 class5647_2;

	internal static int smethod_0(Class5337 el)
	{
		if (el is Class5343)
		{
			return ((Class5343)el).int_5;
		}
		if (el is Class5340)
		{
			return 0;
		}
		return el.method_4();
	}

	internal Class5646(Class5631 pgu, Class5645 row, int rowIndex, int previousRowsLength, Class5287 tableLM)
	{
		class5631_0 = pgu;
		Class5703 @class = pgu.method_1().vmethod_33();
		Class5296 context = pgu.method_20();
		int_4 = @class.method_10(discard: false, context);
		int_5 = @class.method_10(discard: true, context);
		int_6 = @class.method_11(discard: false, context);
		int_7 = @class.method_11(discard: true, context);
		int_8 = int_4 + pgu.method_24(0, 0);
		int_9 = int_5 + pgu.method_24(0, 2);
		int_10 = int_6 + pgu.method_26(0);
		int_11 = int_7 + pgu.method_25(0, 2);
		arrayList_0 = pgu.method_22();
		method_0(pgu.method_1().method_55().method_3(tableLM), row.method_5());
		interface168_0 = new Class5495(arrayList_0);
		int_3 = -1;
		int_2 = previousRowsLength + Class5683.smethod_5(arrayList_0);
		int_0 = rowIndex + pgu.method_1().method_54() - 1;
		class5686_0 = Class5686.class5686_0;
		int_1 = int_2 - previousRowsLength;
		class5647_2 = new Class5647(previousRowsLength);
		class5647_0 = new Class5647(class5647_2);
		method_4();
		class5647_1 = new Class5647(class5647_2);
		if (class5647_2.int_1 < arrayList_0.Count - 1)
		{
			method_4();
		}
	}

	private void method_0(Class5746 cellBPD, Class5746 rowBPD)
	{
		int num = Math.Max(cellBPD.method_1(), rowBPD.method_1());
		if (num > 0)
		{
			Interface168 @interface = new Class5495(arrayList_0);
			int num2 = 0;
			bool flag = false;
			while (@interface.imethod_0() && num2 < num)
			{
				Class5337 @class = (Class5337)@interface.imethod_1();
				if (@class.vmethod_0())
				{
					flag = true;
					num2 += @class.method_4();
				}
				else if (@class.vmethod_1())
				{
					if (flag)
					{
						arrayList_0.Insert(@interface.imethod_4() - 1, new Class5343(num - num2));
					}
					flag = false;
					num2 += @class.method_4();
				}
				else
				{
					flag = false;
					if (num2 + @class.method_4() < num)
					{
						@interface.imethod_7(new Class5343((Class5342)@class, num - num2));
					}
				}
			}
		}
		int num3 = Math.Max(num, Math.Max(cellBPD.method_2(), rowBPD.method_2()));
		if (class5631_0.method_27() < num3)
		{
			arrayList_0.Add(new Class5340(num3 - class5631_0.method_27()));
		}
	}

	internal Class5631 method_1()
	{
		return class5631_0;
	}

	internal bool method_2(int rowIndex)
	{
		return rowIndex == int_0;
	}

	internal int method_3()
	{
		if (method_11() && class5647_1.int_1 == arrayList_0.Count - 1)
		{
			return 0;
		}
		return int_9 + int_1 + int_10;
	}

	private void method_4()
	{
		class5647_2.int_4 = 0;
		class5647_2.int_5 = 0;
		class5647_2.int_7 = 0;
		class5647_2.int_6 = 9;
		if (class5647_2.arrayList_0 != null)
		{
			class5647_2.arrayList_0.Clear();
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		while (!flag && interface168_0.imethod_0())
		{
			Class5337 @class = (Class5337)interface168_0.imethod_1();
			if (@class.vmethod_2())
			{
				flag2 = false;
				if (@class.vmethod_5() < Class5337.int_0 || ((Class5342)@class).method_8() == 104)
				{
					flag = true;
					Class5342 class2 = (Class5342)@class;
					class5647_2.int_4 = class2.method_4();
					class5647_2.int_5 = class2.vmethod_5();
					if (class2.vmethod_3())
					{
						class5647_2.int_6 = class2.method_8();
					}
				}
				continue;
			}
			if (@class.vmethod_1())
			{
				if (flag2)
				{
					flag = true;
				}
				else
				{
					class5647_2.int_2 += @class.method_4();
					if (!flag3)
					{
						class5647_2.int_7 += @class.method_4();
					}
				}
				flag2 = false;
				continue;
			}
			if (@class is Class5341 && ((Class5341)@class).method_8())
			{
				if (class5647_2.arrayList_0 == null)
				{
					class5647_2.arrayList_0 = new ArrayList();
				}
				class5647_2.arrayList_0.AddRange(((Class5341)@class).method_6());
			}
			flag2 = true;
			flag3 = true;
			class5647_2.int_2 += @class.method_4();
		}
		class5647_2.int_1 = interface168_0.imethod_4() - 1;
		class5647_2.int_3 = int_8 + class5647_2.int_2 + class5647_2.int_4 + int_11;
	}

	internal int method_5()
	{
		return class5647_1.int_3;
	}

	internal int method_6()
	{
		return int_8 + int_2 + int_6 + class5631_0.method_26(1);
	}

	private void method_7(int limit)
	{
		if (class5647_1.int_1 >= arrayList_0.Count - 1)
		{
			return;
		}
		while (class5647_2.int_3 <= limit && class5647_1.int_6 == 9)
		{
			int num = class5647_1.int_7;
			class5647_1.method_0(class5647_2);
			class5647_1.int_7 = num;
			if (class5647_2.int_1 < arrayList_0.Count - 1)
			{
				method_4();
				continue;
			}
			break;
		}
	}

	internal void method_8(int firstStep)
	{
		method_7(firstStep);
	}

	internal void method_9(int lastStep)
	{
		method_7(lastStep);
	}

	internal int method_10()
	{
		if (method_11())
		{
			class5647_0.method_0(class5647_1);
			if (class5647_1.int_1 >= arrayList_0.Count - 1)
			{
				class5647_1.int_0 = arrayList_0.Count;
				return -1;
			}
			class5647_1.method_0(class5647_2);
			class5647_1.int_0 = class5647_0.int_1 + 1;
			class5647_2.int_0 = class5647_1.int_0;
			if (class5647_2.int_1 < arrayList_0.Count - 1)
			{
				method_4();
			}
		}
		return class5647_1.int_3;
	}

	private bool method_11()
	{
		return int_3 == class5647_1.int_2;
	}

	internal int method_12(int minStep)
	{
		if (class5647_1.int_3 <= minStep)
		{
			int_3 = class5647_1.int_2;
			int_1 = int_2 - int_3 - class5647_2.int_7;
			return class5647_1.int_6;
		}
		return 9;
	}

	internal void method_13()
	{
		int_12++;
		class5647_1.int_3 -= int_11;
		class5647_2.int_3 -= int_11;
		int_11 = int_7 + class5631_0.method_25(int_12, 2);
		class5647_1.int_3 += int_11;
		class5647_2.int_3 += int_11;
	}

	internal void method_14(int rowIndex)
	{
		if (method_2(rowIndex))
		{
			class5647_1.int_3 -= int_11;
			int_11 = int_6 + class5631_0.method_26(1);
			class5647_1.int_3 += int_11;
			bool_0 = true;
		}
		else
		{
			int_9 = int_5 + class5631_0.method_24(int_12 + 1, 2);
		}
	}

	internal bool method_15(int step)
	{
		if (class5647_1.int_3 <= step)
		{
			return class5647_1.int_1 == arrayList_0.Count - 1;
		}
		return false;
	}

	internal Class5649 method_16()
	{
		if (class5647_1.int_1 + 1 == arrayList_0.Count)
		{
			class5686_0 = class5631_0.method_38();
		}
		int bpBeforeFirst = ((class5647_1.int_0 != 0) ? int_9 : (class5631_0.method_24(0, 1) + int_4));
		int length = class5647_1.int_2 - class5647_1.int_7 - class5647_0.int_2;
		if (method_11() && class5647_1.int_0 != arrayList_0.Count)
		{
			return new Class5649(class5631_0, class5647_1.int_0, class5647_1.int_1, bool_0, class5647_1.int_7, length, class5647_1.int_4, int_8, bpBeforeFirst, int_10, int_11);
		}
		return new Class5649(class5631_0, class5647_1.int_0, class5647_0.int_1, bool_0, 0, 0, class5647_0.int_4, int_8, bpBeforeFirst, int_10, int_11);
	}

	internal void method_17(ArrayList footnoteList)
	{
		if (method_11() && class5647_1.arrayList_0 != null)
		{
			footnoteList.AddRange(class5647_1.arrayList_0);
			class5647_1.arrayList_0.Clear();
		}
	}

	internal Class5686 method_18()
	{
		return class5686_0;
	}

	internal int method_19()
	{
		if (method_11())
		{
			return class5647_1.int_5;
		}
		return class5647_0.int_5;
	}

	public string method_20()
	{
		return "Cell " + (class5631_0.method_31() + 1) + "." + (class5631_0.method_32() + 1);
	}
}
