using System;
using System.Collections.Generic;

namespace Aspose.Slides.Charts;

public class ChartCategoryLevelsManager : IChartCategoryLevelsManager
{
	private List<IChartDataCell> list_0;

	public IChartDataCell this[int level]
	{
		get
		{
			if (level < 0)
			{
				throw new ArgumentOutOfRangeException("level must be >= 0");
			}
			if (level >= list_0.Count)
			{
				return null;
			}
			if (list_0[level] != null)
			{
				return list_0[level];
			}
			return null;
		}
	}

	internal int MaxLevelIndex => list_0.Count - 1;

	[Obsolete("Use SetGroupingItem(int level, object value) method instead. Will be removed after 01.05.2014.")]
	public void SetValueOfLevel(int level, IChartDataCell value)
	{
		SetGroupingItem(level, value);
	}

	[Obsolete("Use SetGroupingItem(int level, object value) method instead. Will be removed after 01.05.2014.")]
	public void SetGroupingItem(int level, IChartDataCell value)
	{
		if (level < 0)
		{
			throw new ArgumentOutOfRangeException("level must be >= 0");
		}
		for (int i = list_0.Count; i <= level; i++)
		{
			list_0.Add(null);
		}
		list_0[level] = value;
	}

	public void SetGroupingItem(int level, object value)
	{
		ChartDataCell chartDataCell = (ChartDataCell)list_0[0];
		if (level < 0)
		{
			throw new ArgumentOutOfRangeException("level must be >= 0");
		}
		if (chartDataCell == null)
		{
			throw new ArgumentException("Undefined workbook cell for category of level 0.");
		}
		if (chartDataCell.Column - level < 0)
		{
			throw new ArgumentException("Cell for category of level 0 has Name \"" + chartDataCell.Name + "\". It's zero-based column number is " + chartDataCell.Column + ". So max level for this category is " + chartDataCell.Column + ".");
		}
		for (int i = list_0.Count; i <= level; i++)
		{
			list_0.Add(null);
		}
		ChartDataWorkbook parentWorkbook = ((ChartDataWorksheet)chartDataCell.ChartDataWorksheet).ParentWorkbook;
		list_0[level] = parentWorkbook.GetCell(chartDataCell.ChartDataWorksheet.Index, chartDataCell.Row, chartDataCell.Column - level, value);
	}

	[Obsolete("Use DeleteGroupingItem method instead. Will be removed after 01.05.2014.")]
	public void DeleteValueOfLevel(int level)
	{
		DeleteGroupingItem(level);
	}

	public void DeleteGroupingItem(int level)
	{
		if (level > 0 && level < list_0.Count)
		{
			list_0[level] = null;
			int num = list_0.Count - 1;
			while (num > 0 && list_0[num] == null)
			{
				list_0.RemoveAt(num);
				num--;
			}
		}
	}

	internal ChartCategoryLevelsManager()
	{
		list_0 = new List<IChartDataCell>();
		list_0.Add(null);
	}
}
