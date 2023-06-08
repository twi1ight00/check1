using System;

namespace Aspose.Slides.Charts;

public class ChartCategory : IChartCategory
{
	private ChartCategoryCollection chartCategoryCollection_0;

	private ChartCategoryLevelsManager chartCategoryLevelsManager_0;

	private object object_0;

	public bool UseCell => chartCategoryCollection_0.UseCells;

	public IChartDataCell AsCell
	{
		get
		{
			if (!UseCell)
			{
				throw new InvalidOperationException("See ChartCategory.UseCell property summary.");
			}
			return chartCategoryLevelsManager_0[0];
		}
		set
		{
			if (!UseCell)
			{
				throw new InvalidOperationException("See ChartCategory.UseCell property summary.");
			}
			chartCategoryLevelsManager_0.SetGroupingItem(0, value);
		}
	}

	public object AsLiteral
	{
		get
		{
			if (UseCell)
			{
				throw new InvalidOperationException("See ChartCategory.UseCell property summary.");
			}
			return object_0;
		}
		set
		{
			if (UseCell)
			{
				throw new InvalidOperationException("See ChartCategory.UseCell property summary.");
			}
			object_0 = value;
		}
	}

	public object Value
	{
		get
		{
			if (UseCell)
			{
				return AsCell.Value;
			}
			return AsLiteral;
		}
		set
		{
			if (UseCell)
			{
				AsCell.Value = value;
			}
			else
			{
				AsLiteral = value;
			}
		}
	}

	[Obsolete("Use GroupingLevels property instead. Will be removed after 01.05.2014.")]
	public IChartCategoryLevelsManager Levels => GroupingLevels;

	public IChartCategoryLevelsManager GroupingLevels
	{
		get
		{
			if (!UseCell)
			{
				return null;
			}
			return chartCategoryLevelsManager_0;
		}
	}

	public void Remove()
	{
		if (chartCategoryCollection_0 == null)
		{
			throw new PptxEditException("Category is already removed from chart.");
		}
		lock (chartCategoryCollection_0.SyncRoot)
		{
			chartCategoryCollection_0.Remove(this);
			chartCategoryCollection_0 = null;
		}
	}

	internal ChartCategory(ChartCategoryCollection parent)
	{
		chartCategoryCollection_0 = parent;
		chartCategoryLevelsManager_0 = new ChartCategoryLevelsManager();
	}
}
