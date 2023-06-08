using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Render;
using ns3;

namespace ns33;

internal class Class842 : CollectionBase, Interface27
{
	private Class821 class821_0;

	private Class824 class824_0;

	private Class824 class824_1;

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	internal bool bool_0;

	internal bool bool_1;

	private ArrayList[] arrayList_2;

	private ArrayList arrayList_3 = new ArrayList();

	private ArrayList[] arrayList_4;

	public Interface28 this[int int_0] => (Interface28)base.InnerList[int_0];

	internal Class842(Class821 class821_1)
	{
		class821_0 = class821_1;
		class824_0 = new Class824(null);
		class824_1 = new Class824(null);
		arrayList_0 = new ArrayList();
		arrayList_1 = new ArrayList();
	}

	[SpecialName]
	public Interface10 imethod_0()
	{
		return class824_0;
	}

	[SpecialName]
	public Interface10 imethod_1()
	{
		return class824_1;
	}

	[SpecialName]
	internal ArrayList method_0()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal void method_1(ArrayList arrayList_5)
	{
		arrayList_0 = arrayList_5;
	}

	[SpecialName]
	internal ArrayList method_2()
	{
		return arrayList_1;
	}

	[SpecialName]
	internal void method_3(ArrayList arrayList_5)
	{
		arrayList_1 = arrayList_5;
	}

	[SpecialName]
	internal ArrayList[] method_4()
	{
		return arrayList_2;
	}

	[SpecialName]
	internal void method_5(ArrayList[] arrayList_5)
	{
		arrayList_2 = arrayList_5;
	}

	[SpecialName]
	internal ArrayList method_6()
	{
		return arrayList_3;
	}

	[SpecialName]
	internal ArrayList[] method_7()
	{
		return arrayList_4;
	}

	[SpecialName]
	internal void method_8(ArrayList[] arrayList_5)
	{
		arrayList_4 = arrayList_5;
	}

	internal Class844 method_9(int int_0)
	{
		return (Class844)base.InnerList[int_0];
	}

	public Interface28 Add(ChartType_Chart chartType_Chart_0)
	{
		Class844 @class = new Class844(class821_0, this, chartType_Chart_0);
		@class.imethod_8(base.Count);
		@class.imethod_1(base.Count);
		@class.imethod_0(base.Count);
		base.InnerList.Add(@class);
		return @class;
	}

	internal void Add(Class844 class844_0)
	{
		base.InnerList.Add(class844_0);
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

	internal Class844 method_11(Enum53 enum53_0)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class844 @class = (Class844)enumerator.Current;
				if (@class.method_28() && @class.method_20() == enum53_0)
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
				Class844 @class = (Class844)enumerator.Current;
				if (@class.method_28() && enum53_0 == @class.method_20())
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

	internal Class844 method_13(Enum53 enum53_0, ChartType_Chart chartType_Chart_0)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class844 @class = (Class844)enumerator.Current;
				if (@class.Type == chartType_Chart_0 && enum53_0 == @class.method_20())
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
				Class844 @class = (Class844)enumerator.Current;
				if (@class.Type == chartType_Chart_0 && enum53_0 == @class.method_20())
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
	internal IList method_15()
	{
		return base.InnerList;
	}

	internal ArrayList method_16()
	{
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(base.InnerList);
		Class843 comparer = new Class843();
		arrayList.Sort(comparer);
		return arrayList;
	}

	internal IList method_17(Enum53 enum53_0, ChartType_Chart[] chartType_Chart_0)
	{
		IList list = method_16();
		ArrayList arrayList = new ArrayList();
		foreach (Class844 item in list)
		{
			if (item.method_24(chartType_Chart_0) && item.method_20() == enum53_0)
			{
				arrayList.Add(item);
			}
		}
		return arrayList;
	}

	internal Class844 method_18(int int_0, Enum53 enum53_0, ChartType_Chart[] chartType_Chart_0)
	{
		IList list = method_17(enum53_0, chartType_Chart_0);
		if (list.Count > int_0)
		{
			return (Class844)list[int_0];
		}
		return null;
	}

	internal int method_19(Class844 class844_0, Enum53 enum53_0, ChartType_Chart[] chartType_Chart_0)
	{
		ArrayList arrayList = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class844 @class = (Class844)enumerator.Current;
				foreach (ChartType_Chart chartType_Chart in chartType_Chart_0)
				{
					if (@class.Type == chartType_Chart && @class.method_20() == enum53_0)
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
			Class843 comparer = new Class843();
			arrayList.Sort(comparer);
			for (int j = 0; j < arrayList.Count; j++)
			{
				Class844 obj = (Class844)arrayList[j];
				if (class844_0.Equals(obj))
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
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Class844 @class = method_9(i);
			if (!@class.PlotOnSecondAxis)
			{
				for (int j = 0; j < @class.method_10().Count; j++)
				{
					arrayList.Add(@class.method_10()[j]);
				}
			}
		}
		return arrayList;
	}

	internal ArrayList method_21()
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Class844 @class = method_9(i);
			if (@class.PlotOnSecondAxis)
			{
				for (int j = 0; j < @class.method_10().Count; j++)
				{
					arrayList.Add(@class.method_10()[j]);
				}
			}
		}
		return arrayList;
	}

	[SpecialName]
	internal int method_22()
	{
		int num = base.InnerList.Count;
		foreach (Class844 inner in base.InnerList)
		{
			if (inner.vmethod_4() + 1 > num)
			{
				num = inner.vmethod_4() + 1;
			}
		}
		return num;
	}
}
