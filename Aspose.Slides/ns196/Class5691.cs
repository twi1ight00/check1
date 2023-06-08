using System;
using System.Collections;
using ns173;
using ns190;

namespace ns196;

internal class Class5691
{
	public static int int_0 = 0;

	public static int int_1 = 1;

	private int int_2;

	private int int_3;

	private int int_4;

	private bool bool_0;

	private ArrayList arrayList_0 = new ArrayList();

	private int int_5 = -1;

	private int int_6 = -1;

	private int int_7 = -1;

	private int int_8 = -1;

	private Class4872 class4872_0;

	private Class5127 class5127_0;

	public Class5691(Class4872 ath, Class5127 ps)
	{
		class4872_0 = ath;
		class5127_0 = ps;
		int_2 = ps.method_49();
	}

	public void method_0(int startPage, int startColumn, bool spanAll)
	{
		int_3 = startPage - int_2 + 1;
		int_4 = startColumn;
		bool_0 = spanAll;
		int_7 = -1;
		int_8 = -1;
	}

	public void method_1(int index)
	{
		int_5 = index;
	}

	public int method_2(int index)
	{
		if (int_7 == index)
		{
			return int_8;
		}
		int num = index;
		int num2 = 0;
		int num3 = int_4;
		Class5690 @class = method_9(isBlank: false, 0, int_1);
		while (num > 0)
		{
			num3++;
			if (num3 >= @class.method_1().method_34().method_38())
			{
				num3 = 0;
				num2++;
				@class = method_9(isBlank: false, num2, int_1);
			}
			num--;
		}
		int_7 = index;
		int_8 = @class.method_1().method_32().method_51();
		return int_8;
	}

	private int[] method_3(int index)
	{
		int num = 0;
		int num2 = int_4 + index;
		int num3 = -1;
		do
		{
			num2 -= num;
			num3++;
			Class5690 @class = method_9(isBlank: false, num3, int_1);
			num = @class.method_1().method_34().method_38();
		}
		while (num2 >= num);
		return new int[2] { num2, num };
	}

	public int method_4(int index)
	{
		int num = 0;
		int num2 = int_4 + index;
		int num3 = -1;
		Class5690 @class;
		do
		{
			num2 -= num;
			num3++;
			@class = method_9(isBlank: false, num3, int_1);
			num = @class.method_1().method_34().method_38();
		}
		while (num2 >= num);
		if (num2 + 1 < num)
		{
			return 0;
		}
		Class5690 class2 = method_9(isBlank: false, num3 + 1, int_1);
		return @class.method_1().method_32().method_12() - class2.method_1().method_32().method_12();
	}

	private bool method_5(int index)
	{
		return method_3(index)[0] == 0;
	}

	internal bool method_6(int index)
	{
		int[] array = method_3(index);
		return array[0] == array[1] - 1;
	}

	private int method_7(int index)
	{
		return method_3(index)[1];
	}

	public int method_8(int partCount)
	{
		int result = 0;
		int i = 0;
		int num = 0;
		int num2 = int_4;
		Class5690 @class = method_9(isBlank: false, 0, int_1);
		for (; i < partCount; i++)
		{
			if (num2 >= @class.method_1().method_34().method_38())
			{
				num2 = 0;
				num++;
				@class = method_9(isBlank: false, num, int_1);
				result = i;
			}
			num2++;
		}
		return result;
	}

	public Class5690 method_9(bool isBlank, int index, int relativeTo)
	{
		if (relativeTo == int_0)
		{
			return method_10(isBlank, index);
		}
		if (relativeTo != int_1)
		{
			throw new InvalidOperationException("Illegal value for relativeTo: " + relativeTo);
		}
		int num = int_3 + index;
		num += int_2 - 1;
		return method_10(isBlank, num);
	}

	internal Class5690 method_10(bool isBlank, int index)
	{
		bool flag = int_5 >= 0 && index == int_5;
		int num = index - int_2;
		while (num >= arrayList_0.Count)
		{
			method_12(index, isBlank, flag, bool_0);
		}
		Class5690 @class = (Class5690)arrayList_0[num];
		bool flag2 = false;
		if (@class.method_1().method_31() != isBlank)
		{
			flag2 = true;
		}
		if ((flag && int_6 != num) || (!flag && int_6 >= 0))
		{
			flag2 = true;
			int_6 = (flag ? num : (-1));
		}
		if (flag2)
		{
			method_11(num);
			@class = method_12(index, isBlank, flag, bool_0);
		}
		return @class;
	}

	private void method_11(int index)
	{
		while (index < arrayList_0.Count)
		{
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			class5127_0.method_60();
		}
	}

	private Class5690 method_12(int index, bool isBlank, bool isLastPage, bool spanAll)
	{
		string pageNumberStr = class5127_0.method_50(index);
		bool isFirstPage = int_2 == index;
		Class5171 @class = class5127_0.method_59(index, isFirstPage, isLastPage, isBlank);
		Class5690 class2 = new Class5690(@class, index, pageNumberStr, isBlank, spanAll);
		class2.method_1().method_18(class4872_0.method_10());
		class2.method_1().method_1(@class.method_47());
		class2.method_1().method_38(class5127_0);
		arrayList_0.Add(class2);
		return class2;
	}
}
