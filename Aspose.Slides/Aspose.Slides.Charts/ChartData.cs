using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ns17;
using ns2;
using ns33;

namespace Aspose.Slides.Charts;

public class ChartData : IChartData
{
	internal Chart chart_0;

	internal ChartDataWorkbook chartDataWorkbook_0;

	private ChartSeriesCollection chartSeriesCollection_0;

	private Class13 class13_0;

	private ChartCategoryCollection chartCategoryCollection_0;

	private ChartCategoryCollection chartCategoryCollection_1;

	private bool bool_0;

	public IChartDataWorkbook ChartDataWorkbook
	{
		get
		{
			if (chartDataWorkbook_0 == null)
			{
				chartDataWorkbook_0 = new ChartDataWorkbook(chart_0);
			}
			return chartDataWorkbook_0;
		}
	}

	public IChartSeriesCollection Series => chartSeriesCollection_0;

	public IChartSeriesGroupCollection SeriesGroups => class13_0;

	public IChartCategoryCollection Categories => chartCategoryCollection_0;

	public bool UseSecondaryCategories
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

	public IChartCategoryCollection SecondaryCategories
	{
		get
		{
			if (!bool_0)
			{
				return null;
			}
			return chartCategoryCollection_1;
		}
	}

	internal ChartData(Chart parent)
	{
		chart_0 = parent;
		chartCategoryCollection_0 = new ChartCategoryCollection(parent);
		chartCategoryCollection_1 = new ChartCategoryCollection(parent);
		chartSeriesCollection_0 = new ChartSeriesCollection(parent);
		class13_0 = new Class13();
	}

	public IEnumerator GetEnumerator()
	{
		return chartSeriesCollection_0.GetEnumerator();
	}

	public MemoryStream ReadWorkbookStream()
	{
		MemoryStream memoryStream = new MemoryStream();
		((ChartDataWorkbook)ChartDataWorkbook).Write(memoryStream);
		memoryStream.Position = 0L;
		return memoryStream;
	}

	public void WriteWorkbookStream(MemoryStream ms)
	{
		if (ms != null)
		{
			chartDataWorkbook_0 = new ChartDataWorkbook(ms, chart_0);
			method_0();
		}
	}

	private void method_0()
	{
		ChartDataWorkbook chartDataWorkbook = (ChartDataWorkbook)ChartDataWorkbook;
		bool flag = false;
		bool flag2 = false;
		foreach (IChartSeries item in chartSeriesCollection_0)
		{
			if (item.Name.DataSourceType == DataSourceType.Worksheet)
			{
				Class913.smethod_9(item, item.Name.AsCells.GetCellsAddress(), chartDataWorkbook);
			}
			if ((!item.PlotOnSecondAxis || !bool_0) && !flag && chartCategoryCollection_0.UseCells)
			{
				if (chartCategoryCollection_0.GroupingLevelCount > 1)
				{
					Class906.smethod_2(chartCategoryCollection_0, chartCategoryCollection_0.GetCellsAddress(), chartDataWorkbook, chartCategoryCollection_0.GroupingLevelCount);
				}
				else
				{
					Class906.smethod_3(chartCategoryCollection_0, chartCategoryCollection_0.GetCellsAddress(), chartDataWorkbook);
				}
				flag = true;
			}
			if (item.PlotOnSecondAxis && bool_0 && !flag2 && chartCategoryCollection_1.UseCells)
			{
				if (chartCategoryCollection_1.GroupingLevelCount > 1)
				{
					Class906.smethod_2(chartCategoryCollection_1, chartCategoryCollection_1.GetCellsAddress(), chartDataWorkbook, chartCategoryCollection_1.GroupingLevelCount);
				}
				else
				{
					Class906.smethod_3(chartCategoryCollection_1, chartCategoryCollection_1.GetCellsAddress(), chartDataWorkbook);
				}
				flag2 = true;
			}
			if (item.DataPoints.DataSourceTypeForValues == DataSourceType.Worksheet)
			{
				foreach (IChartDataPoint dataPoint in item.DataPoints)
				{
					ChartDataCell chartDataCell = (ChartDataCell)dataPoint.Value.AsCell;
					if (chartDataCell != null)
					{
						dataPoint.Value.AsCell = chartDataWorkbook.GetCell(chartDataCell.ChartDataWorksheet.Index, chartDataCell.Name);
					}
				}
			}
			if (item.DataPoints.DataSourceTypeForXValues == DataSourceType.Worksheet)
			{
				foreach (IChartDataPoint dataPoint2 in item.DataPoints)
				{
					ChartDataCell chartDataCell2 = (ChartDataCell)dataPoint2.XValue.AsCell;
					if (chartDataCell2 != null)
					{
						dataPoint2.XValue.AsCell = chartDataWorkbook.GetCell(chartDataCell2.ChartDataWorksheet.Index, chartDataCell2.Name);
					}
				}
			}
			if (item.DataPoints.DataSourceTypeForYValues == DataSourceType.Worksheet)
			{
				foreach (IChartDataPoint dataPoint3 in item.DataPoints)
				{
					ChartDataCell chartDataCell3 = (ChartDataCell)dataPoint3.YValue.AsCell;
					if (chartDataCell3 != null)
					{
						dataPoint3.YValue.AsCell = chartDataWorkbook.GetCell(chartDataCell3.ChartDataWorksheet.Index, chartDataCell3.Name);
					}
				}
			}
			if (item.DataPoints.DataSourceTypeForBubbleSizes != 0)
			{
				continue;
			}
			foreach (IChartDataPoint dataPoint4 in item.DataPoints)
			{
				ChartDataCell chartDataCell4 = (ChartDataCell)dataPoint4.BubbleSize.AsCell;
				if (chartDataCell4 != null)
				{
					dataPoint4.BubbleSize.AsCell = chartDataWorkbook.GetCell(chartDataCell4.ChartDataWorksheet.Index, chartDataCell4.Name);
				}
			}
		}
	}

	internal bool method_1(MemoryStream ms, List<string> namesToCheckResolve)
	{
		try
		{
			bool flag = false;
			if (ms != null)
			{
				chartDataWorkbook_0 = new ChartDataWorkbook(ms, chart_0);
				flag = true;
				foreach (string item in namesToCheckResolve)
				{
					if (!chartDataWorkbook_0.method_7(item))
					{
						flag = false;
						break;
					}
				}
			}
			if (flag && ms != null)
			{
				return true;
			}
			chartDataWorkbook_0 = new ChartDataWorkbook(chart_0);
			return false;
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			chartDataWorkbook_0 = new ChartDataWorkbook(chart_0);
			return false;
		}
	}

	internal void method_2(int index, IChartSeries series)
	{
		chartSeriesCollection_0.method_1(index, series);
	}
}
