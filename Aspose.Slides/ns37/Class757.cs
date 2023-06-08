using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides.Charts;
using ns36;

namespace ns37;

internal class Class757 : CollectionBase, Interface20
{
	private Class740 class740_0;

	private Class742 class742_0;

	private Class742 class742_1;

	private List<Interface8> list_0;

	private List<Interface8> list_1;

	internal bool bool_0;

	internal bool bool_1;

	private List<Interface8>[] list_2;

	private List<Interface8> list_3 = new List<Interface8>();

	private List<Interface8>[] list_4;

	public Interface7 CategoryLabels => class742_0;

	public Interface7 Category2Labels => class742_1;

	internal List<Interface8> CategoryLabelsInternal
	{
		get
		{
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	internal List<Interface8> Category2LabelsInternal
	{
		get
		{
			return list_1;
		}
		set
		{
			list_1 = value;
		}
	}

	internal List<Interface8>[] Categories
	{
		get
		{
			return list_2;
		}
		set
		{
			list_2 = value;
		}
	}

	internal List<Interface8> OriginalCategory2Labels => list_3;

	internal List<Interface8>[] Categories2
	{
		get
		{
			return list_4;
		}
		set
		{
			list_4 = value;
		}
	}

	public Interface21 this[int index] => (Interface21)base.List[index];

	internal IList ListSeries => base.List;

	internal bool HasTrendline
	{
		get
		{
			if (method_13().Count != 0)
			{
				return true;
			}
			return false;
		}
	}

	internal bool IsWideKey
	{
		get
		{
			if (base.List == null)
			{
				return false;
			}
			foreach (Class759 item in base.List)
			{
				if (item.IsWideKeyInLegend)
				{
					return true;
				}
			}
			return false;
		}
	}

	internal int MaxColorCount
	{
		get
		{
			int num = base.List.Count;
			foreach (Class759 item in base.List)
			{
				if (item.SeriesIndex + 1 > num)
				{
					num = item.SeriesIndex + 1;
				}
			}
			return num;
		}
	}

	internal Class757(Class740 chart)
	{
		class740_0 = chart;
		class742_0 = new Class742(null);
		class742_1 = new Class742(null);
		list_0 = new List<Interface8>();
		list_1 = new List<Interface8>();
	}

	internal Class759 method_0(int index)
	{
		return (Class759)base.List[index];
	}

	public Interface21 Add(ChartType seriesType)
	{
		Class759 @class = new Class759(class740_0, this, seriesType);
		@class.DisplayOrder = base.Count;
		@class.ID = base.Count;
		@class.SeriesIndex = base.Count;
		base.InnerList.Add(@class);
		return @class;
	}

	internal void Add(Class759 series)
	{
		base.InnerList.Add(series);
	}

	internal int method_1()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < base.Count; i++)
		{
			list.Add(this[i].Points.Count);
		}
		list.Sort();
		return list[list.Count - 1];
	}

	internal void method_2(out double minValue, out double maxValue)
	{
		minValue = 0.0;
		maxValue = 0.0;
		new ArrayList();
		for (int i = 0; i < base.Count; i++)
		{
			Class747 pointsInternal = method_0(i).PointsInternal;
			for (int j = 0; j < pointsInternal.Count; j++)
			{
				double yValue = pointsInternal[j].YValue;
				if (yValue < minValue)
				{
					minValue = yValue;
				}
				if (yValue > maxValue)
				{
					maxValue = yValue;
				}
			}
		}
	}

	internal Class759 method_3(Enum141 axisGroupType)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class759 @class = (Class759)enumerator.Current;
				if (@class.IsColumnSeries && @class.AxisGroup == axisGroupType)
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

	internal int method_4(Enum141 axisGroup)
	{
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class759 @class = (Class759)enumerator.Current;
				if (@class.IsColumnSeries && axisGroup == @class.AxisGroup)
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

	internal Class759 method_5(Enum141 axisGroupType, ChartType chartType)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class759 @class = (Class759)enumerator.Current;
				if (@class.Type == chartType && axisGroupType == @class.AxisGroup)
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

	internal Class759 method_6(ChartType chartType)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class759 @class = (Class759)enumerator.Current;
				if (@class.ResembleType == chartType)
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

	internal int method_7(Enum141 axisGroup, ChartType chartType)
	{
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class759 @class = (Class759)enumerator.Current;
				if (@class.Type == chartType && axisGroup == @class.AxisGroup)
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

	internal bool method_8()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class759 @class = (Class759)enumerator.Current;
				if (@class.AxisGroup == Enum141.const_1)
				{
					return true;
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
		return false;
	}

	internal List<Class759> method_9()
	{
		List<Class759> list = new List<Class759>();
		foreach (Class759 item in base.List)
		{
			list.Add(item);
		}
		Class758 comparer = new Class758();
		list.Sort(comparer);
		return list;
	}

	internal List<Class759> method_10(Enum141 axisGroup, ChartType[] chartType)
	{
		List<Class759> list = method_9();
		List<Class759> list2 = new List<Class759>();
		foreach (Class759 item in list)
		{
			if (item.method_2(chartType) && item.AxisGroup == axisGroup)
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	internal Class759 method_11(int order, Enum141 axisGroup, ChartType[] chartType)
	{
		List<Class759> list = method_10(axisGroup, chartType);
		if (list.Count > order)
		{
			return list[order];
		}
		return null;
	}

	internal int method_12(Class759 aSeries, Enum141 axisGroup, ChartType[] chartType)
	{
		List<Class759> list = new List<Class759>();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class759 @class = (Class759)enumerator.Current;
				foreach (ChartType chartType2 in chartType)
				{
					if (@class.Type == chartType2 && @class.AxisGroup == axisGroup)
					{
						list.Add(@class);
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
		if (list.Count > 0)
		{
			Class758 comparer = new Class758();
			list.Sort(comparer);
			for (int j = 0; j < list.Count; j++)
			{
				Class759 obj = list[j];
				if (aSeries.Equals(obj))
				{
					return j;
				}
			}
		}
		return -1;
	}

	internal List<Interface23> method_13()
	{
		List<Interface23> list = new List<Interface23>();
		for (int i = 0; i < base.List.Count; i++)
		{
			Class759 @class = method_0(i);
			for (int j = 0; j < @class.TrendlinesInternal.Count; j++)
			{
				list.Add(@class.TrendlinesInternal[j]);
			}
		}
		return list;
	}

	internal List<Interface23> method_14()
	{
		List<Interface23> list = new List<Interface23>();
		for (int i = 0; i < base.List.Count; i++)
		{
			Class759 @class = method_0(i);
			if (!@class.PlotOnSecondAxis)
			{
				for (int j = 0; j < @class.TrendlinesInternal.Count; j++)
				{
					list.Add(@class.TrendlinesInternal[j]);
				}
			}
		}
		return list;
	}

	internal List<Interface23> method_15()
	{
		List<Interface23> list = new List<Interface23>();
		for (int i = 0; i < base.List.Count; i++)
		{
			Class759 @class = method_0(i);
			if (@class.PlotOnSecondAxis)
			{
				for (int j = 0; j < @class.TrendlinesInternal.Count; j++)
				{
					list.Add(@class.TrendlinesInternal[j]);
				}
			}
		}
		return list;
	}
}
