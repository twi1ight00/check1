using System.Collections;
using ns176;
using ns183;
using ns186;
using ns187;
using ns192;
using ns205;

namespace ns197;

internal class Class5650
{
	private Class5156 class5156_0;

	private Interface231 interface231_0;

	private ArrayList arrayList_0 = new ArrayList();

	private ArrayList arrayList_1 = new ArrayList();

	private int int_0;

	public Class5650(Class5156 table)
	{
		class5156_0 = table;
		interface231_0 = Class5678.smethod_0(table);
		method_0();
		method_4();
	}

	private void method_0()
	{
		ArrayList arrayList = class5156_0.method_57();
		if (arrayList == null)
		{
			return;
		}
		int num = 1;
		Interface168 @interface = new Class5495(arrayList);
		while (@interface.imethod_0())
		{
			Class5158 @class = (Class5158)@interface.imethod_1();
			if (@class == null)
			{
				continue;
			}
			num = @class.method_56();
			for (int i = 0; i < @class.method_58(); i++)
			{
				while (num > arrayList_0.Count)
				{
					arrayList_0.Add(null);
				}
				arrayList_0[num - 1] = @class;
				num++;
			}
		}
		int num2 = 1;
		Interface168 interface2 = new Class5495(arrayList_0);
		while (interface2.imethod_0())
		{
			_ = (Class5158)interface2.imethod_1();
			num2++;
		}
	}

	public Class5158 method_1(int index)
	{
		int count = arrayList_0.Count;
		if (index > count)
		{
			if (index > int_0)
			{
				int_0 = index;
				Class5158 @class = method_1(1);
				if (count != 1 || !@class.method_60())
				{
					class5156_0.method_56();
				}
			}
			return (Class5158)arrayList_0[count - 1];
		}
		return (Class5158)arrayList_0[index - 1];
	}

	public override string ToString()
	{
		return arrayList_0.ToString();
	}

	public int method_2()
	{
		if (int_0 > arrayList_0.Count)
		{
			return int_0;
		}
		return arrayList_0.Count;
	}

	public Interface208 method_3()
	{
		return new Class5495(arrayList_0);
	}

	private void method_4()
	{
		int num = arrayList_0.Count;
		while (--num >= 0)
		{
			if (arrayList_0[num] != null)
			{
				Class5158 @class = (Class5158)arrayList_0[num];
				Interface182 value = @class.method_52();
				arrayList_1.Insert(0, value);
			}
		}
		arrayList_1.Insert(0, null);
	}

	internal double method_5(Class5287 tlm)
	{
		return method_6(tlm, tlm.imethod_16());
	}

	public float method_6(Interface172 percentBaseContext, int contentAreaIPD)
	{
		int num = 0;
		float num2 = 0f;
		float result = 0f;
		Interface208 @interface = new Class5495(arrayList_1);
		while (@interface.imethod_0())
		{
			Interface182 interface2 = (Interface182)@interface.imethod_1();
			if (interface2 != null)
			{
				num += interface2.imethod_6(percentBaseContext);
				if (interface2 is Class5049)
				{
					num2 += (float)((Class5049)interface2).method_4();
				}
				else if (interface2 is Class5038)
				{
					num2 += (float)((Class5038)interface2).method_3();
				}
			}
		}
		if (num2 > 0f && num < contentAreaIPD)
		{
			result = (float)(contentAreaIPD - num) / num2;
		}
		return result;
	}

	public int method_7(int col, Interface172 context)
	{
		if (interface231_0 != null && interface231_0.imethod_4() == Class5444.class5444_1)
		{
			return method_8(col, context);
		}
		return method_9(col, context);
	}

	private int method_8(int col, Interface172 context)
	{
		int num = 0;
		int num2 = col;
		int count = arrayList_1.Count;
		while (++num2 < count)
		{
			int index = num2;
			if (arrayList_1[index] != null)
			{
				num += ((Interface182)arrayList_1[index]).imethod_6(context);
			}
		}
		return num;
	}

	private int method_9(int col, Interface172 context)
	{
		int num = 0;
		int num2 = col;
		while (--num2 >= 0)
		{
			int index = ((num2 >= arrayList_1.Count) ? (arrayList_1.Count - 1) : num2);
			if (arrayList_1[index] != null)
			{
				num += ((Interface182)arrayList_1[index]).imethod_6(context);
			}
		}
		return num;
	}

	public int method_10(Interface172 context)
	{
		int num = 0;
		int i = 1;
		for (int num2 = method_2(); i <= num2; i++)
		{
			int index = i;
			if (i >= arrayList_1.Count)
			{
				index = arrayList_1.Count - 1;
			}
			if (arrayList_1[index] != null)
			{
				num += ((Interface182)arrayList_1[index]).imethod_6(context);
			}
		}
		return num;
	}

	public void method_11(Interface172 context)
	{
		int num = method_2();
		for (int i = 1; i <= num; i++)
		{
			Class5158 @class = method_1(i);
			if (@class.method_52().imethod_4())
			{
				int num2 = @class.method_52().imethod_6(context);
				Class5746 class2 = @class.method_53();
				if (class2 != null && class2.method_1() > num2)
				{
					@class.method_55(Class5036.smethod_2(class2.method_1()));
				}
			}
		}
	}

	public int method_12(Interface172 context)
	{
		int num = method_2();
		int num2 = 0;
		for (int i = 1; i <= num; i++)
		{
			Class5158 @class = method_1(i);
			if (@class.method_52().imethod_4() && @class.method_52().imethod_6(context) != 0)
			{
				num2 += @class.method_52().imethod_6(context);
			}
		}
		return num2;
	}

	public bool method_13(Interface172 context)
	{
		int num = method_2();
		int num2 = 1;
		while (true)
		{
			if (num2 <= num)
			{
				Class5158 @class = method_1(num2);
				if (!@class.method_52().imethod_4() || @class.method_52().imethod_6(context) == 0)
				{
					break;
				}
				num2++;
				continue;
			}
			return false;
		}
		return true;
	}

	public bool method_14(Interface172 context)
	{
		int num = method_2();
		int num2 = 1;
		while (true)
		{
			if (num2 <= num)
			{
				Class5158 @class = method_1(num2);
				if ((!@class.method_52().imethod_4() || @class.method_52().imethod_6(context) == 0) && !(@class.method_52() is Class5037))
				{
					break;
				}
				num2++;
				continue;
			}
			return false;
		}
		return true;
	}

	public void method_15(Interface172 context, int maxSize)
	{
		int num = method_2();
		int num2 = method_12(context);
		for (int i = 1; i <= num; i++)
		{
			Class5158 @class = method_1(i);
			double num3 = (double)maxSize / (double)num2;
			int num4 = @class.method_52().imethod_6(context);
			num2 -= num4;
			num4 = (int)((double)num4 * num3);
			maxSize -= num4;
			@class.method_55(Class5036.smethod_1(num4, "mpt"));
		}
	}

	public int method_16(Interface172 context, int parentIPD)
	{
		int num = method_2();
		float num2 = 0f;
		for (int i = 1; i <= num; i++)
		{
			Class5158 @class = method_1(i);
			if (@class.method_52() is Class5037 class2)
			{
				float num3 = (float)(class2.method_4() / 100.0 * (double)parentIPD);
				Class5746 class3 = @class.method_53();
				if (class3 != null && (float)class3.method_1() > num3)
				{
					num3 = class3.method_2();
				}
				num2 += num3;
			}
		}
		return (int)num2;
	}

	private int method_17(Interface172 context, int startColumnIndex)
	{
		int num = method_2();
		int num2 = 0;
		for (int i = startColumnIndex; i <= num; i++)
		{
			Class5158 @class = method_1(i);
			if (@class.method_52().imethod_4() && @class.method_52().imethod_6(context) != 0)
			{
				num2 += @class.method_52().imethod_6(context);
				continue;
			}
			Class5746 class2 = @class.method_53();
			if (class2 != null)
			{
				num2 += class2.method_1() + @class.int_5 * 4;
			}
		}
		return num2;
	}

	public void method_18(Interface172 context, int parentIPD)
	{
		int num = method_2();
		if (num <= 1)
		{
			return;
		}
		for (int i = 1; i <= num; i++)
		{
			Class5158 @class = method_1(i);
			if (@class.method_52() is Class5037 class2)
			{
				int num2 = (int)(class2.method_4() / 100.0 * (double)parentIPD);
				Class5746 class3 = @class.method_53();
				if (class3 != null && class3.method_1() > num2)
				{
					num2 = class3.method_2();
				}
				@class.method_55(Class5036.smethod_2(num2));
			}
		}
	}

	public void method_19(Interface172 context, int parentIPD, int ipIndents)
	{
		int num = method_2();
		if (num <= 1)
		{
			return;
		}
		for (int i = 1; i <= num; i++)
		{
			Class5158 @class = method_1(i);
			int num2 = parentIPD;
			if (@class.method_52() is Class5037 class2)
			{
				if (i < num - 1)
				{
					num2 -= method_17(context, i + 1) + @class.int_5 * 4;
				}
				int num3 = (int)(class2.method_4() / 100.0 * (double)num2);
				if (num3 > num2)
				{
					Class5746 class3 = @class.method_53();
					num3 = ((class3 == null || class3.method_1() <= num2) ? num2 : class3.method_1());
				}
				@class.method_55(Class5036.smethod_2(num3));
				parentIPD -= num3;
			}
			else if (@class.method_52().imethod_4() && @class.method_52().imethod_6(context) != 0)
			{
				parentIPD -= @class.method_52().imethod_6(context);
			}
			else
			{
				Class5746 class4 = @class.method_53();
				if (class4 != null)
				{
					parentIPD -= class4.method_1();
				}
			}
		}
	}
}
