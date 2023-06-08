using System.Collections;
using System.Runtime.CompilerServices;
using ns3;

namespace ns33;

internal class Class836 : CollectionBase, Interface21
{
	private Class821 class821_0;

	public Class837 this[int int_0] => (Class837)base.List[int_0];

	internal Class836(Class821 class821_1)
	{
		class821_0 = class821_1;
	}

	public Interface22 Add(int int_0)
	{
		Class837 @class = new Class837(class821_0, class821_0.method_6(), int_0);
		base.InnerList.Add(@class);
		return @class;
	}

	internal void Add(Class837 class837_0)
	{
		base.InnerList.Add(class837_0);
	}

	[SpecialName]
	internal int method_0()
	{
		int num = 0;
		foreach (Class837 item in base.List)
		{
			if (!item.IsDeleted)
			{
				num++;
			}
		}
		return num;
	}

	internal Class837 method_1(int int_0)
	{
		foreach (Class837 inner in base.InnerList)
		{
			if (inner.vmethod_0() == int_0)
			{
				return inner;
			}
		}
		return null;
	}

	internal ArrayList method_2(bool bool_0, bool bool_1)
	{
		ArrayList arrayList = method_4(Enum56.const_0, bool_0: false);
		ArrayList arrayList2 = method_4(Enum56.const_0, bool_0: true);
		ArrayList arrayList3 = method_4(Enum56.const_1, bool_0: false);
		ArrayList arrayList4 = method_4(Enum56.const_1, bool_0: true);
		bool isPlotOrderReversed = class821_0.method_1().IsPlotOrderReversed;
		bool isPlotOrderReversed2 = class821_0.method_9().IsPlotOrderReversed;
		bool flag = true;
		ArrayList arrayList5 = class821_0.method_7().method_16();
		if (arrayList5.Count > 0 && ((Class844)arrayList5[0]).PlotOnSecondAxis)
		{
			flag = false;
		}
		bool flag2 = false;
		if (arrayList.Count > 0)
		{
			Class844 @class = ((Class837)arrayList[0]).method_0();
			if (@class.method_29() || @class.method_31())
			{
				flag2 = true;
			}
		}
		if (arrayList2.Count > 0)
		{
			Class844 class2 = ((Class837)arrayList2[0]).method_0();
			if (class2.method_29() || class2.method_31())
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
					arrayList = method_3(arrayList);
					arrayList2 = method_3(arrayList2);
					arrayList3.Reverse();
					arrayList4.Reverse();
				}
			}
			else if (isPlotOrderReversed2 && bool_0)
			{
				arrayList = method_3(arrayList);
				arrayList2 = method_3(arrayList2);
				arrayList3.Reverse();
				arrayList4.Reverse();
			}
		}
		else if (flag2 && bool_0)
		{
			arrayList = method_3(arrayList);
			arrayList2 = method_3(arrayList2);
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

	private ArrayList method_3(ArrayList arrayList_0)
	{
		ArrayList arrayList = new ArrayList();
		Class844 @class = null;
		if (arrayList_0.Count > 0)
		{
			@class = ((Class837)arrayList_0[0]).method_0();
			ArrayList arrayList2 = new ArrayList();
			arrayList2.Add(arrayList_0[0]);
			arrayList.Add(arrayList2);
			for (int i = 1; i < arrayList_0.Count; i++)
			{
				Class837 class2 = (Class837)arrayList_0[i];
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

	private ArrayList method_4(Enum56 enum56_0, bool bool_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < base.Count; i++)
		{
			Class837 @class = this[i];
			if (@class.Type == enum56_0 && @class.method_0().PlotOnSecondAxis == bool_0)
			{
				arrayList.Add(@class);
			}
		}
		return arrayList;
	}

	public void Insert(int int_0, Class837 class837_0)
	{
		base.InnerList.Insert(int_0, class837_0);
	}

	[SpecialName]
	internal bool method_5()
	{
		if (base.List == null)
		{
			return false;
		}
		foreach (Class837 item in base.List)
		{
			if (item.Type != Enum56.const_1)
			{
				if (item.Type == Enum56.const_0 && item.method_0().method_27())
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
