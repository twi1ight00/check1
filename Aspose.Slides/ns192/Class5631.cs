using System;
using System.Collections;
using System.Text;
using ns171;
using ns187;
using ns196;
using ns197;

namespace ns192;

internal class Class5631 : Class5630
{
	private Class5296 class5296_0;

	private ArrayList arrayList_0;

	private int int_6;

	private int int_7;

	private ArrayList arrayList_1;

	private int int_8 = -1;

	private bool bool_0;

	private int int_9;

	private Class5686 class5686_0 = Class5686.class5686_0;

	private Class5686 class5686_1 = Class5686.class5686_0;

	private int int_10 = 9;

	private int int_11 = 9;

	internal Class5631(Class5157 cell, int colIndex)
		: base(cell, 0, 0)
	{
		int_7 = colIndex;
		bool_0 = cell.vmethod_32().method_72();
		int_9 = cell.vmethod_32().method_73().method_4()
			.vmethod_0()
			.imethod_5() / 2;
	}

	public Class5151 method_19()
	{
		Class5088 @class = class5157_0.method_4();
		if (@class is Class5155)
		{
			@class = @class.method_4();
		}
		return (Class5151)@class;
	}

	public Class5296 method_20()
	{
		return class5296_0;
	}

	public override Class5631 vmethod_1()
	{
		return this;
	}

	public override bool vmethod_2()
	{
		return true;
	}

	public void method_21(ArrayList elementS)
	{
		arrayList_0 = elementS;
	}

	public ArrayList method_22()
	{
		return arrayList_0;
	}

	public int method_23()
	{
		return method_24(0, 0) + method_26(0);
	}

	public int method_24(int rowIndex, int which)
	{
		if (bool_0)
		{
			if (method_1() == null)
			{
				return 0;
			}
			Class5703 @class = method_1().vmethod_33();
			switch (which)
			{
			default:
				return 0;
			case 0:
			case 1:
				return @class.method_6(discard: false) + int_9;
			case 2:
				if (@class.method_2(0).method_2().vmethod_16())
				{
					return 0;
				}
				return @class.method_6(discard: true) + int_9;
			}
		}
		int num = 0;
		Class5630[] array = (Class5630[])arrayList_1[rowIndex];
		for (int i = 0; i < array.Length; i++)
		{
			num = Math.Max(num, array[i].method_7(which).method_3());
		}
		return num / 2;
	}

	public int method_25(int rowIndex, int which)
	{
		if (bool_0)
		{
			if (method_1() == null)
			{
				return 0;
			}
			Class5703 @class = method_1().vmethod_33();
			switch (which)
			{
			default:
				return 0;
			case 0:
			case 1:
				return @class.method_7(discard: false) + int_9;
			case 2:
				if (@class.method_2(1).method_2().vmethod_16())
				{
					return 0;
				}
				return @class.method_7(discard: true) + int_9;
			}
		}
		int num = 0;
		Class5630[] array = (Class5630[])arrayList_1[rowIndex];
		for (int i = 0; i < array.Length; i++)
		{
			num = Math.Max(num, array[i].method_8(which).method_3());
		}
		return num / 2;
	}

	public int method_26(int which)
	{
		return method_25(method_1().method_54() - 1, which);
	}

	public int method_27()
	{
		int_8 = Class5683.smethod_5(arrayList_0);
		return int_8;
	}

	public ArrayList method_28()
	{
		return arrayList_1;
	}

	public void method_29(Class5630[] row)
	{
		if (arrayList_1 == null)
		{
			arrayList_1 = new ArrayList();
		}
		arrayList_1.Add(row);
	}

	internal void method_30(int rowIndex)
	{
		int_6 = rowIndex;
	}

	public int method_31()
	{
		return int_6;
	}

	public int method_32()
	{
		return int_7;
	}

	public int[] method_33()
	{
		int[] array = new int[2];
		if (method_1() == null)
		{
			return array;
		}
		if (method_1().vmethod_32().method_72())
		{
			array[0] = method_1().vmethod_33().method_4(discard: false);
			array[1] = method_1().vmethod_33().method_5(discard: false);
		}
		else
		{
			for (int i = 0; i < arrayList_1.Count; i++)
			{
				Class5630[] array2 = (Class5630[])arrayList_1[i];
				array[0] = Math.Max(array[0], array2[0].class5706_0.method_0().method_3());
				array[1] = Math.Max(array[1], array2[array2.Length - 1].class5706_1.method_0().method_3());
			}
		}
		return array;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(base.ToString());
		stringBuilder.Append(" rowIndex=").Append(int_6);
		stringBuilder.Append(" colIndex=").Append(int_7);
		return stringBuilder.ToString();
	}

	public bool method_34()
	{
		if (method_1().method_53() <= 1)
		{
			return method_1().method_54() > 1;
		}
		return true;
	}

	public void method_35()
	{
		class5296_0 = new Class5296(class5157_0, this);
	}

	public Class5686 method_36()
	{
		return class5686_0;
	}

	public void method_37(Class5686 keep)
	{
		class5686_0 = keep;
	}

	public Class5686 method_38()
	{
		return class5686_1;
	}

	public void method_39(Class5686 keep)
	{
		class5686_1 = keep;
	}

	public int method_40()
	{
		return int_10;
	}

	public void method_41(int breakBefore)
	{
		int_10 = breakBefore;
	}

	public int method_42()
	{
		return int_11;
	}

	public void method_43(int breakAfter)
	{
		int_11 = breakAfter;
	}
}
