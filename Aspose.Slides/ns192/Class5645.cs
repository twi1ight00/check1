using System;
using System.Collections;
using System.Text;
using ns195;
using ns196;
using ns205;

namespace ns192;

internal class Class5645
{
	public static int int_0 = Class5630.int_0;

	public static int int_1 = Class5630.int_1;

	private ArrayList arrayList_0 = new ArrayList();

	private int int_2;

	private int int_3;

	private Class5746 class5746_0;

	private Class5746 class5746_1;

	public Class5645(int index, int bodyType, ArrayList gridUnits)
	{
		int_2 = index;
		int_3 = bodyType;
		arrayList_0 = gridUnits;
		foreach (object gridUnit in gridUnits)
		{
			if (gridUnit is Class5631)
			{
				((Class5631)gridUnit).method_30(index);
			}
		}
	}

	public int method_0()
	{
		return int_2;
	}

	public int method_1()
	{
		return int_3;
	}

	public Class5155 method_2()
	{
		return method_8(0).method_2();
	}

	public Class5746 method_3()
	{
		return class5746_0;
	}

	public void method_4(Class5746 mom)
	{
		class5746_0 = mom;
	}

	public Class5746 method_5()
	{
		return class5746_1;
	}

	public void method_6(Class5746 mom)
	{
		class5746_1 = mom;
	}

	public ArrayList method_7()
	{
		return arrayList_0;
	}

	public Class5630 method_8(int column)
	{
		return (Class5630)arrayList_0[column];
	}

	public Class5630 method_9(int column)
	{
		if (column < arrayList_0.Count)
		{
			return (Class5630)arrayList_0[column];
		}
		return null;
	}

	public bool method_10(int which)
	{
		if (which == int_0)
		{
			return method_8(0).method_16(Class5630.int_0);
		}
		if (which != int_1)
		{
			throw new ArgumentException("Illegal flag queried: " + which);
		}
		return method_8(0).method_16(Class5630.int_1);
	}

	public Class5686 method_11()
	{
		Class5686 @class = Class5686.class5686_0;
		Class5155 class2 = method_2();
		if (class2 != null)
		{
			@class = Class5686.smethod_1(class2.method_54());
		}
		foreach (Class5630 item in arrayList_0)
		{
			if (item.vmethod_2())
			{
				@class = @class.method_4(item.vmethod_1().method_36());
			}
		}
		return @class;
	}

	public Class5686 method_12()
	{
		Class5686 @class = Class5686.class5686_0;
		Class5155 class2 = method_2();
		if (class2 != null)
		{
			@class = Class5686.smethod_1(class2.method_55());
		}
		foreach (Class5630 item in arrayList_0)
		{
			if (!item.method_4() && item.method_6() == 0 && item.vmethod_4())
			{
				@class = @class.method_4(item.vmethod_1().method_38());
			}
		}
		return @class;
	}

	public Class5686 method_13()
	{
		Class5155 @class = method_2();
		Class5686 result = Class5686.class5686_0;
		if (@class != null)
		{
			result = Class5686.smethod_1(@class.method_56());
		}
		return result;
	}

	public int method_14()
	{
		int num = 9;
		foreach (Class5630 item in arrayList_0)
		{
			if (item.vmethod_2())
			{
				num = Class5676.smethod_1(num, item.vmethod_1().method_40());
			}
		}
		return num;
	}

	public int method_15()
	{
		int num = 9;
		foreach (Class5630 item in arrayList_0)
		{
			if (!item.method_4() && item.method_6() == 0 && item.vmethod_4())
			{
				num = Class5676.smethod_1(num, item.vmethod_1().method_42());
			}
		}
		return num;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("EffRow {");
		stringBuilder.Append(int_2);
		if (method_1() == 0)
		{
			stringBuilder.Append(" in body");
		}
		else if (method_1() == 1)
		{
			stringBuilder.Append(" in header");
		}
		else
		{
			stringBuilder.Append(" in footer");
		}
		stringBuilder.Append(", ").Append(class5746_0);
		stringBuilder.Append(", ").Append(class5746_1);
		stringBuilder.Append(", ").Append(arrayList_0.Count).Append(" gu");
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}
}
