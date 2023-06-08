using System;
using System.Collections;
using System.Collections.Generic;
using ns25;

namespace Aspose.Slides.Charts;

public class ChartCategoryCollection : ICollection, IEnumerable, IEnumerable<IChartCategory>, IChartCategoryCollection
{
	private Class308 class308_0 = new Class308();

	private List<IChartCategory> list_0 = new List<IChartCategory>();

	private Chart chart_0;

	private bool bool_0 = true;

	public IChartCategory this[int index] => list_0[index];

	public bool UseCells
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	[Obsolete("Use GroupingLevelCount property instead. Will be removed after 01.05.2014.")]
	public int LevelCount => GroupingLevelCount;

	public int GroupingLevelCount
	{
		get
		{
			int num = 0;
			foreach (ChartCategory item in list_0)
			{
				int num2 = ((item.GroupingLevels != null) ? ((ChartCategoryLevelsManager)item.GroupingLevels).MaxLevelIndex : 0);
				if (num < num2)
				{
					num = num2;
				}
			}
			return num + 1;
		}
	}

	internal Class308 PPTXUnsupportedProps => class308_0;

	IEnumerable IChartCategoryCollection.AsIEnumerable => this;

	ICollection IChartCategoryCollection.AsICollection => this;

	public int Count => list_0.Count;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public IChartCategory Add(IChartDataCell chartDataCell)
	{
		if (bool_0)
		{
			foreach (ChartCategory item in list_0)
			{
				if (((ChartDataCell)item.AsCell).Name == ((ChartDataCell)chartDataCell).Name)
				{
					item.AsCell = chartDataCell;
					return item;
				}
			}
			ChartCategory chartCategory2 = new ChartCategory(this);
			chartCategory2.AsCell = chartDataCell;
			list_0.Add(chartCategory2);
			return chartCategory2;
		}
		throw new InvalidOperationException("For using worksheet set UseCells property to true.");
	}

	public IChartCategory Add(object value)
	{
		ChartCategory chartCategory = new ChartCategory(this);
		if (bool_0)
		{
			ChartDataCell chartDataCell = ((ChartDataWorkbook)chart_0.ChartData.ChartDataWorkbook).method_3();
			chartDataCell.Value = value;
			chartCategory.AsCell = chartDataCell;
		}
		else
		{
			chartCategory.AsLiteral = value;
		}
		list_0.Add(chartCategory);
		return chartCategory;
	}

	public int IndexOf(IChartCategory value)
	{
		return list_0.IndexOf(value);
	}

	public void Remove(IChartCategory value)
	{
		if (list_0.IndexOf(value) == -1)
		{
			throw new ArgumentException("The value parameter was not found in the collection.");
		}
		list_0.Remove(value);
	}

	public void Clear()
	{
		list_0.Clear();
	}

	internal void Add(IChartCategory category)
	{
		list_0.Add(category);
	}

	internal ChartCategoryCollection(IChart parent)
	{
		chart_0 = (Chart)parent;
	}

	internal string GetCellsAddress()
	{
		IChartDataWorkbook chartDataWorkbook = chart_0.ChartData.ChartDataWorkbook;
		ChartCellCollection chartCellCollection = (ChartCellCollection)chartDataWorkbook.GetCellCollection("", skipHiddenCells: true);
		foreach (IChartCategory item in list_0)
		{
			chartCellCollection.Add(item.AsCell);
		}
		if (GroupingLevelCount == 1)
		{
			return chartCellCollection.GetCellsAddress();
		}
		for (int i = 1; i < GroupingLevelCount; i++)
		{
			foreach (IChartCategory item2 in list_0)
			{
				if (item2.GroupingLevels[i] != null)
				{
					chartCellCollection.Add(item2.GroupingLevels[i]);
				}
			}
		}
		return chartCellCollection.method_1();
	}

	IEnumerator<IChartCategory> IEnumerable<IChartCategory>.GetEnumerator()
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
