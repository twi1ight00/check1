using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides.Charts;
using ns21;
using ns42;
using ns43;

namespace ns34;

internal sealed class Class739 : ICollection, IEnumerable, IEnumerable<ChartDataWorksheet>
{
	private List<ChartDataWorksheet> list_0;

	private ChartDataWorkbook chartDataWorkbook_0;

	internal int int_0;

	public int Count => list_0.Count;

	public ChartDataWorksheet this[int index] => list_0[index];

	public ChartDataWorksheet this[string name]
	{
		get
		{
			foreach (ChartDataWorksheet item in list_0)
			{
				if (item.Name == name)
				{
					return item;
				}
			}
			return null;
		}
	}

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal Class739(ChartDataWorkbook parent)
	{
		list_0 = new List<ChartDataWorksheet>();
		chartDataWorkbook_0 = parent;
	}

	internal int Add(ChartDataWorksheet value)
	{
		if (int_0 < value.Index)
		{
			int_0 = value.Index + 1;
		}
		list_0.Add(value);
		return list_0.IndexOf(value);
	}

	public ChartDataWorksheet Add(string val)
	{
		ChartDataWorksheet chartDataWorksheet = Add();
		chartDataWorksheet.NameInternal = val;
		return chartDataWorksheet;
	}

	public ChartDataWorksheet Add()
	{
		if (Class257.bool_0)
		{
			Class1086 @class = new Class1086("*newSheet_" + chartDataWorkbook_0.class834_0.method_8() + ".xml");
			Class834 class834_ = chartDataWorkbook_0.class834_0;
			@class.class822_0 = new Class827(class834_);
			@class.class822_0.class1086_0 = @class;
			@class.class822_0.class1090_0 = new Class1090();
			Class834.smethod_5(@class.class822_0);
			class834_.sortedList_0.Add(@class.string_0, @class);
			@class.string_1 = "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml";
			Class1086 class2 = new Class1086(Class834.smethod_4(@class.string_0));
			class2.class1090_0 = @class.class822_0.Relationships;
			class2.string_1 = "application/vnd.openxmlformats-package.relationships+xml";
			class834_.sortedList_0.Add(class2.string_0, class2);
			ChartDataWorksheet chartDataWorksheet = new ChartDataWorksheet(chartDataWorkbook_0, (Class819)@class.class822_0.DocumentElement, chartDataWorkbook_0.class808_0);
			if (chartDataWorksheet.Name == "*")
			{
				chartDataWorksheet.NameInternal = "Sheet" + int_0;
			}
			chartDataWorksheet.IndexInternal = int_0++;
			list_0.Add(chartDataWorksheet);
			return chartDataWorksheet;
		}
		ChartDataWorksheet chartDataWorksheet2 = new ChartDataWorksheet(chartDataWorkbook_0);
		if (chartDataWorksheet2.Name == "*")
		{
			chartDataWorksheet2.NameInternal = "Sheet" + int_0;
		}
		chartDataWorksheet2.IndexInternal = int_0++;
		list_0.Add(chartDataWorksheet2);
		return chartDataWorksheet2;
	}

	IEnumerator<ChartDataWorksheet> IEnumerable<ChartDataWorksheet>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}
}
