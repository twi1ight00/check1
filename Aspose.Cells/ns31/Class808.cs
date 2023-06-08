using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Render;
using ns3;

namespace ns31;

internal class Class808 : CollectionBase, Interface27
{
	private Class787 class787_0;

	private Class790 class790_0;

	private Class790 class790_1;

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	internal bool bool_0;

	internal bool bool_1;

	private ArrayList[] arrayList_2;

	private ArrayList arrayList_3 = new ArrayList();

	private ArrayList[] arrayList_4;

	public Interface28 this[int int_0] => (Class810)base.InnerList[int_0];

	internal Class808(Class787 class787_1)
	{
		class787_0 = class787_1;
		class790_0 = new Class790(null);
		class790_1 = new Class790(null);
		arrayList_0 = new ArrayList();
		arrayList_1 = new ArrayList();
	}

	[SpecialName]
	public Interface10 imethod_0()
	{
		return class790_0;
	}

	[SpecialName]
	public Interface10 imethod_1()
	{
		return class790_1;
	}

	[SpecialName]
	public ArrayList method_0()
	{
		return arrayList_0;
	}

	[SpecialName]
	public void method_1(ArrayList arrayList_5)
	{
		arrayList_0 = arrayList_5;
	}

	[SpecialName]
	public ArrayList method_2()
	{
		return arrayList_1;
	}

	[SpecialName]
	public void method_3(ArrayList arrayList_5)
	{
		arrayList_1 = arrayList_5;
	}

	[SpecialName]
	public ArrayList[] method_4()
	{
		return arrayList_2;
	}

	[SpecialName]
	public void method_5(ArrayList[] arrayList_5)
	{
		arrayList_2 = arrayList_5;
	}

	[SpecialName]
	public ArrayList method_6()
	{
		return arrayList_3;
	}

	[SpecialName]
	public ArrayList[] method_7()
	{
		return arrayList_4;
	}

	[SpecialName]
	public void method_8(ArrayList[] arrayList_5)
	{
		arrayList_4 = arrayList_5;
	}

	internal Class810 method_9(int int_0)
	{
		return (Class810)base.InnerList[int_0];
	}

	public Interface28 Add(ChartType_Chart chartType_Chart_0)
	{
		Class810 @class = new Class810(class787_0, this, chartType_Chart_0);
		@class.imethod_8(base.Count);
		@class.imethod_1(base.Count);
		@class.imethod_0(base.Count);
		base.InnerList.Add(@class);
		return @class;
	}

	internal int Add(Class810 class810_0)
	{
		_ = base.InnerList.Count;
		if (class810_0.NSeries == null)
		{
			class810_0.method_26(this);
		}
		class810_0.method_2(class787_0);
		return base.InnerList.Add(class810_0);
	}

	internal int method_10()
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < base.Count; i++)
		{
			arrayList.Add(this[i].Points.Count);
		}
		arrayList.Sort();
		return (int)arrayList[arrayList.Count - 1];
	}

	internal Class810 method_11(Enum53 enum53_0)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class810 @class = (Class810)enumerator.Current;
				if (@class.method_29() && @class.method_21() == enum53_0)
				{
					return @class;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	internal int method_12(Enum53 enum53_0)
	{
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class810 @class = (Class810)enumerator.Current;
				if (@class.method_29() && enum53_0 == @class.method_21())
				{
					num++;
				}
			}
			return num;
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal Class810 method_13(Enum53 enum53_0, ChartType_Chart chartType_Chart_0)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class810 @class = (Class810)enumerator.Current;
				if (@class.Type == chartType_Chart_0 && enum53_0 == @class.method_21())
				{
					return @class;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	internal int method_14(Enum53 enum53_0, ChartType_Chart chartType_Chart_0)
	{
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class810 @class = (Class810)enumerator.Current;
				if (@class.Type == chartType_Chart_0 && enum53_0 == @class.method_21())
				{
					num++;
				}
			}
			return num;
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	[SpecialName]
	internal ArrayList method_15()
	{
		return base.InnerList;
	}

	internal ArrayList method_16()
	{
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(base.InnerList);
		Class809 comparer = new Class809();
		arrayList.Sort(comparer);
		return arrayList;
	}

	internal IList method_17(Enum53 enum53_0, ChartType_Chart[] chartType_Chart_0)
	{
		IList list = method_16();
		ArrayList arrayList = new ArrayList();
		foreach (Class810 item in list)
		{
			if (item.method_24(chartType_Chart_0) && item.method_21() == enum53_0)
			{
				arrayList.Add(item);
			}
		}
		return arrayList;
	}

	internal Class810 method_18(int int_0, Enum53 enum53_0, ChartType_Chart[] chartType_Chart_0)
	{
		IList list = method_17(enum53_0, chartType_Chart_0);
		if (list.Count > int_0)
		{
			return (Class810)list[int_0];
		}
		return null;
	}

	internal int method_19(Class810 class810_0, Enum53 enum53_0, ChartType_Chart[] chartType_Chart_0)
	{
		ArrayList arrayList = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class810 @class = (Class810)enumerator.Current;
				if (@class.method_21() != enum53_0)
				{
					continue;
				}
				foreach (ChartType_Chart chartType_Chart in chartType_Chart_0)
				{
					if (@class.Type == chartType_Chart && @class.method_21() == enum53_0)
					{
						arrayList.Add(@class);
						break;
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		if (arrayList.Count > 0)
		{
			Class809 comparer = new Class809();
			arrayList.Sort(comparer);
			for (int j = 0; j < arrayList.Count; j++)
			{
				Class810 obj = (Class810)arrayList[j];
				if (class810_0.Equals(obj))
				{
					return j;
				}
			}
		}
		return -1;
	}

	internal ArrayList method_20()
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = class787_0.method_7().method_16();
		for (int i = 0; i < arrayList2.Count; i++)
		{
			Class810 @class = (Class810)arrayList2[i];
			arrayList.AddRange(@class.method_11().method_3());
		}
		return arrayList;
	}

	internal ArrayList method_21()
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Class810 @class = method_9(i);
			if (!@class.PlotOnSecondAxis)
			{
				for (int j = 0; j < @class.method_11().Count; j++)
				{
					arrayList.Add(@class.method_11()[j]);
				}
			}
		}
		return arrayList;
	}

	internal ArrayList method_22()
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Class810 @class = method_9(i);
			if (@class.PlotOnSecondAxis)
			{
				for (int j = 0; j < @class.method_11().Count; j++)
				{
					arrayList.Add(@class.method_11()[j]);
				}
			}
		}
		return arrayList;
	}

	[SpecialName]
	internal bool method_23()
	{
		if (method_20().Count != 0)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal bool method_24()
	{
		if (base.InnerList == null)
		{
			return false;
		}
		foreach (Class810 inner in base.InnerList)
		{
			if (inner.method_28())
			{
				return true;
			}
		}
		return false;
	}
}
