using System.Collections;
using System.Runtime.CompilerServices;
using ns3;

namespace ns31;

internal class Class802 : CollectionBase, Interface21
{
	private Class787 class787_0;

	public Class803 this[int int_0] => (Class803)base.List[int_0];

	internal Class802(Class787 class787_1)
	{
		class787_0 = class787_1;
	}

	public Interface22 Add(int int_0)
	{
		Class803 @class = new Class803(class787_0, class787_0.method_6(), int_0);
		base.InnerList.Add(@class);
		return @class;
	}

	public int Add(Class803 class803_0)
	{
		return base.InnerList.Add(class803_0);
	}

	[SpecialName]
	internal int method_0()
	{
		int num = 0;
		foreach (Class803 item in base.List)
		{
			if (item.IsDeleted)
			{
				num++;
			}
		}
		return num;
	}

	[SpecialName]
	internal int method_1()
	{
		int num = 0;
		foreach (Class803 item in base.List)
		{
			if (!item.IsDeleted)
			{
				num++;
			}
		}
		return num;
	}

	internal ArrayList method_2(bool bool_0, bool bool_1)
	{
		ArrayList arrayList = method_5(Enum56.const_0, bool_0: false);
		ArrayList arrayList2 = method_5(Enum56.const_0, bool_0: true);
		ArrayList arrayList3 = method_5(Enum56.const_1, bool_0: false);
		ArrayList arrayList4 = method_5(Enum56.const_1, bool_0: true);
		bool isPlotOrderReversed = class787_0.method_1().IsPlotOrderReversed;
		bool isPlotOrderReversed2 = class787_0.method_9().IsPlotOrderReversed;
		bool flag = true;
		ArrayList arrayList5 = class787_0.method_7().method_16();
		if (arrayList5.Count > 0 && ((Class810)arrayList5[0]).PlotOnSecondAxis)
		{
			flag = false;
		}
		bool flag2 = false;
		if (arrayList.Count > 0)
		{
			Class810 @class = ((Class803)arrayList[0]).method_0();
			if (@class.method_30() || @class.method_32())
			{
				flag2 = true;
			}
		}
		if (arrayList2.Count > 0)
		{
			Class810 class2 = ((Class803)arrayList2[0]).method_0();
			if (class2.method_30() || class2.method_32())
			{
				flag2 = true;
			}
		}
		if (bool_1)
		{
			if (!flag2)
			{
				if (!isPlotOrderReversed && bool_0)
				{
					arrayList = method_4(arrayList);
					arrayList2 = method_4(arrayList2);
					arrayList3.Reverse();
					arrayList4.Reverse();
				}
			}
			else if (isPlotOrderReversed2 && bool_0)
			{
				arrayList = method_4(arrayList);
				arrayList2 = method_4(arrayList2);
				arrayList3.Reverse();
				arrayList4.Reverse();
			}
		}
		else if (flag2 && bool_0)
		{
			arrayList = method_4(arrayList);
			arrayList2 = method_4(arrayList2);
			arrayList3.Reverse();
			arrayList4.Reverse();
		}
		ArrayList arrayList6 = new ArrayList();
		if (flag)
		{
			arrayList6.AddRange(arrayList);
			arrayList6.AddRange(arrayList2);
			arrayList6.AddRange(arrayList3);
			arrayList6.AddRange(arrayList4);
		}
		else
		{
			arrayList6.AddRange(arrayList2);
			arrayList6.AddRange(arrayList);
			arrayList6.AddRange(arrayList4);
			arrayList6.AddRange(arrayList3);
		}
		return arrayList6;
	}

	internal Class803 method_3(int int_0)
	{
		foreach (Class803 inner in base.InnerList)
		{
			if (inner.vmethod_0() == int_0)
			{
				return inner;
			}
		}
		return null;
	}

	private ArrayList method_4(ArrayList arrayList_0)
	{
		ArrayList arrayList = new ArrayList();
		Class810 @class = null;
		if (arrayList_0.Count > 0)
		{
			@class = ((Class803)arrayList_0[0]).method_0();
			ArrayList arrayList2 = new ArrayList();
			arrayList2.Add(arrayList_0[0]);
			arrayList.Add(arrayList2);
			for (int i = 1; i < arrayList_0.Count; i++)
			{
				Class803 class2 = (Class803)arrayList_0[i];
				if (class2.method_0().method_22() == @class.method_22())
				{
					ArrayList arrayList3 = (ArrayList)arrayList[arrayList.Count - 1];
					arrayList3.Add(arrayList_0[i]);
					continue;
				}
				@class = class2.method_0();
				ArrayList arrayList4 = new ArrayList();
				arrayList4.Add(arrayList_0[i]);
				arrayList.Add(arrayList4);
			}
			ArrayList arrayList5 = new ArrayList();
			for (int j = 0; j < arrayList.Count; j++)
			{
				ArrayList arrayList6 = (ArrayList)arrayList[j];
				arrayList6.Reverse();
				arrayList5.AddRange(arrayList6);
			}
			return arrayList5;
		}
		return arrayList_0;
	}

	private ArrayList method_5(Enum56 enum56_0, bool bool_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < base.Count; i++)
		{
			Class803 @class = this[i];
			if (@class.Type == enum56_0 && @class.method_0().PlotOnSecondAxis == bool_0)
			{
				arrayList.Add(@class);
			}
		}
		return arrayList;
	}

	public void Insert(int int_0, Class803 class803_0)
	{
		base.InnerList.Insert(int_0, class803_0);
	}

	[SpecialName]
	internal bool method_6()
	{
		if (base.List == null)
		{
			return false;
		}
		foreach (Class803 item in base.List)
		{
			if (item.Type != Enum56.const_1)
			{
				if (item.Type == Enum56.const_0 && item.method_0().method_28())
				{
					return true;
				}
				continue;
			}
			return true;
		}
		return false;
	}
}
