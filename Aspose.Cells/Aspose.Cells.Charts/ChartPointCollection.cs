using System.Collections;
using System.Runtime.CompilerServices;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///        Represents a collection that contains all the points in one series.
///        </summary>
/// <example>
///   <code>
///        //Instantiating a Workbook object
///        Workbook workbook = new Workbook();
///
///        //Obtaining the reference of the first worksheet
///        Worksheet worksheet = workbook.Worksheets[0];
///
///        //Adding a sample value to "A1" cell
///        worksheet.Cells["A1"].PutValue(50);
///
///        //Adding a sample value to "A2" cell
///        worksheet.Cells["A2"].PutValue(100);
///
///        //Adding a sample value to "A3" cell
///        worksheet.Cells["A3"].PutValue(150);
///
///        //Adding a sample value to "B1" cell
///        worksheet.Cells["B1"].PutValue(60);
///
///        //Adding a sample value to "B2" cell
///        worksheet.Cells["B2"].PutValue(32);
///
///        //Adding a sample value to "B3" cell
///        worksheet.Cells["B3"].PutValue(50);
///
///        //Adding a chart to the worksheet
///        int chartIndex = worksheet.Charts.Add(ChartType.PieExploded, 5, 0, 25, 10);
///
///        //Accessing the instance of the newly added chart
///        Chart chart = worksheet.Charts[chartIndex];
///
///        //Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B3"
///        chart.NSeries.Add("A1:B3", true);
///
///        //Show Data Labels 
///        chart.NSeries[0].DataLabels.IsValueShown = true;
///
///        ChartPointCollection points = chart.NSeries[0].Points;
///
///        for (int i = 0; i &lt; points.Count; i++)
///        {
///            //Get Data Point
///            ChartPoint point = points[i];
///            //Set Pir Explosion
///            point.Explosion = 15;
///            //Set Border Color
///            point.Border.Color = System.Drawing.Color.Red;
///        }
///
///        //Saving the Excel file
///        workbook.Save("D:\\book1.xls");
///
///        [VB.NET]
///
///        'Instantiating a Workbook object
///        Dim workbook As New Workbook()
///
///        'Obtaining the reference of the first worksheet
///        Dim worksheet As Worksheet = workbook.Worksheets(0)
///
///        'Adding a sample value to "A1" cell
///        worksheet.Cells("A1").PutValue(50)
///
///        'Adding a sample value to "A2" cell
///        worksheet.Cells("A2").PutValue(100)
///
///        'Adding a sample value to "A3" cell
///        worksheet.Cells("A3").PutValue(150)
///
///        'Adding a sample value to "B1" cell
///        worksheet.Cells("B1").PutValue(60)
///
///        'Adding a sample value to "B2" cell
///        worksheet.Cells("B2").PutValue(32)
///
///        'Adding a sample value to "B3" cell
///        worksheet.Cells("B3").PutValue(50)
///
///        'Adding a chart to the worksheet
///        Dim chartIndex As Integer = worksheet.Charts.Add(ChartType.PieExploded, 5, 0, 25, 10)
///
///        'Accessing the instance of the newly added chart
///        Dim chart As Chart = worksheet.Charts(chartIndex)
///
///        'Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B3"
///        chart.NSeries.Add("A1:B3", True)
///
///        'Show Data Labels 
///        chart.NSeries(0).DataLabels.IsValueShown = True
///
///        Dim points As ChartPointCollection = chart.NSeries(0).Points
///
///        For i As Integer = 0 To points.Count - 1
///            'Get Data Point
///            Dim point As ChartPoint = points(i)
///            'Set Pir Explosion
///            point.Explosion = 15
///            'Set Border Color
///            point.Border.Color = System.Drawing.Color.Red
///        Next i
///
///        'Saving the Excel file
///        workbook.Save("D:\book1.xls")
///
///        </code>
/// </example>
public class ChartPointCollection
{
	internal ArrayList arrayList_0;

	private Series series_0;

	/// <summary>
	///       Gets the count of the chart point.
	///       </summary>
	public int Count
	{
		get
		{
			int num = 0;
			if (series_0.method_16() != null)
			{
				bool bool_ = false;
				ArrayList arrayList = series_0.method_16().imethod_8(bool_0: true, series_0.NSeries.Chart.method_5(), ref bool_);
				num += arrayList.Count;
				if (series_0.NSeries.Chart.PlotVisibleCells)
				{
					for (int i = 0; i < arrayList.Count; i++)
					{
						Class1196 @class = (Class1196)arrayList[i];
						if (!@class.bool_0)
						{
							num--;
						}
					}
				}
				if (series_0.Type == ChartType.PiePie || series_0.Type == ChartType.PieBar)
				{
					num++;
				}
			}
			return num;
		}
	}

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Charts.ChartPoint" /> element at the specified index in the series.
	///        </summary>
	/// <param name="index">The index of chart point in the series.</param>
	/// <returns>The ChartPoint object.</returns>
	public ChartPoint this[int index]
	{
		get
		{
			bool isNew = false;
			ChartPoint chartPoint = method_2(index, out isNew);
			if (isNew && series_0.method_39() != null)
			{
				chartPoint.ShapeProperties.Copy(series_0.ShapeProperties);
			}
			return chartPoint;
		}
	}

	internal ChartPointCollection(Series series_1)
	{
		series_0 = series_1;
		arrayList_0 = new ArrayList();
	}

	/// <summary>
	///       Returns an enumerator for the entire <see cref="T:Aspose.Cells.Charts.ChartPointCollection" />.
	///       </summary>
	/// <returns>
	/// </returns>
	public IEnumerator GetEnumerator()
	{
		return arrayList_0.GetEnumerator();
	}

	/// <summary>
	///       Remove all setting of the chart points.
	///       </summary>
	public void Clear()
	{
		arrayList_0.Clear();
	}

	/// <summary>
	///       Removes point at the index of the series..
	///       </summary>
	/// <param name="index">The index of the point.</param>
	public void RemoveAt(int index)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				ChartPoint chartPoint = (ChartPoint)arrayList_0[num];
				if (chartPoint.int_0 == index)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		arrayList_0.RemoveAt(index);
	}

	internal void method_0(ChartPoint chartPoint_0)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				ChartPoint chartPoint = (ChartPoint)arrayList_0[num];
				if (chartPoint.int_0 <= chartPoint_0.int_0)
				{
					if (chartPoint.int_0 == chartPoint_0.int_0)
					{
						break;
					}
					num++;
					continue;
				}
				arrayList_0.Insert(num, chartPoint_0);
				return;
			}
			arrayList_0.Add(chartPoint_0);
			return;
		}
		arrayList_0[num] = chartPoint_0;
	}

	internal ChartPoint method_1(int int_0)
	{
		bool isNew;
		return method_2(int_0, out isNew);
	}

	private ChartPoint method_2(int index, out bool isNew)
	{
		isNew = true;
		if (arrayList_0.Count == 0)
		{
			ChartPoint chartPoint = new ChartPoint(series_0, index);
			arrayList_0.Add(chartPoint);
			return chartPoint;
		}
		if (arrayList_0.Count > index)
		{
			ChartPoint chartPoint2 = (ChartPoint)arrayList_0[index];
			if (index == chartPoint2.int_0)
			{
				isNew = false;
				return chartPoint2;
			}
		}
		return method_3(index, 0, arrayList_0.Count - 1, out isNew);
	}

	private ChartPoint method_3(int index, int start, int end, out bool isNew)
	{
		isNew = true;
		switch (end - start)
		{
		default:
		{
			ChartPoint chartPoint6 = (ChartPoint)arrayList_0[start];
			ChartPoint chartPoint7 = (ChartPoint)arrayList_0[end];
			if (index > chartPoint7.int_0)
			{
				ChartPoint chartPoint8 = new ChartPoint(series_0, index);
				if (end == arrayList_0.Count - 1)
				{
					arrayList_0.Add(chartPoint8);
				}
				else
				{
					arrayList_0.Insert(end + 1, chartPoint8);
				}
				return chartPoint8;
			}
			if (index == chartPoint7.int_0)
			{
				isNew = false;
				return chartPoint7;
			}
			if (index > chartPoint6.int_0 && index < chartPoint7.int_0)
			{
				int num = (end + start) / 2;
				ChartPoint chartPoint9 = (ChartPoint)arrayList_0[num];
				if (index > chartPoint9.int_0)
				{
					if (end - num == 1)
					{
						ChartPoint chartPoint10 = new ChartPoint(series_0, index);
						arrayList_0.Insert(end, chartPoint10);
						return chartPoint10;
					}
					return method_3(index, num + 1, end - 1, out isNew);
				}
				if (index == chartPoint9.int_0)
				{
					isNew = false;
					return chartPoint9;
				}
				if (num - start == 1)
				{
					ChartPoint chartPoint11 = new ChartPoint(series_0, index);
					arrayList_0.Insert(num, chartPoint11);
					return chartPoint11;
				}
				return method_3(index, start + 1, num - 1, out isNew);
			}
			if (index == chartPoint6.int_0)
			{
				isNew = false;
				return chartPoint6;
			}
			ChartPoint chartPoint12 = new ChartPoint(series_0, index);
			arrayList_0.Insert(start, chartPoint12);
			return chartPoint12;
		}
		case 0:
		{
			ChartPoint chartPoint13 = (ChartPoint)arrayList_0[start];
			if (index > chartPoint13.int_0)
			{
				ChartPoint chartPoint14 = new ChartPoint(series_0, index);
				if (end == arrayList_0.Count - 1)
				{
					arrayList_0.Add(chartPoint14);
				}
				else
				{
					arrayList_0.Insert(end + 1, chartPoint14);
				}
				return chartPoint14;
			}
			if (index == chartPoint13.int_0)
			{
				isNew = false;
				return chartPoint13;
			}
			ChartPoint chartPoint15 = new ChartPoint(series_0, index);
			arrayList_0.Insert(start, chartPoint15);
			return chartPoint15;
		}
		case 1:
		{
			ChartPoint chartPoint = (ChartPoint)arrayList_0[start];
			ChartPoint chartPoint2 = (ChartPoint)arrayList_0[end];
			if (index > chartPoint2.int_0)
			{
				ChartPoint chartPoint3 = new ChartPoint(series_0, index);
				if (end == arrayList_0.Count - 1)
				{
					arrayList_0.Add(chartPoint3);
				}
				else
				{
					arrayList_0.Insert(end + 1, chartPoint3);
				}
				return chartPoint3;
			}
			if (index == chartPoint2.int_0)
			{
				isNew = false;
				return chartPoint2;
			}
			if (index > chartPoint.int_0 && index < chartPoint2.int_0)
			{
				ChartPoint chartPoint4 = new ChartPoint(series_0, index);
				arrayList_0.Insert(end, chartPoint4);
				return chartPoint4;
			}
			if (index == chartPoint.int_0)
			{
				isNew = false;
				return chartPoint;
			}
			ChartPoint chartPoint5 = new ChartPoint(series_0, index);
			arrayList_0.Insert(start, chartPoint5);
			return chartPoint5;
		}
		}
	}

	[SpecialName]
	internal int method_4()
	{
		return arrayList_0.Count;
	}

	internal ChartPoint method_5(int int_0)
	{
		if (arrayList_0.Count == 0)
		{
			return null;
		}
		if (arrayList_0.Count > int_0)
		{
			ChartPoint chartPoint = (ChartPoint)arrayList_0[int_0];
			if (chartPoint.int_0 == int_0)
			{
				return chartPoint;
			}
		}
		return method_6(int_0, 0, arrayList_0.Count - 1);
	}

	private ChartPoint method_6(int int_0, int int_1, int int_2)
	{
		switch (int_2 - int_1)
		{
		default:
		{
			ChartPoint chartPoint4 = (ChartPoint)arrayList_0[int_1];
			ChartPoint chartPoint5 = (ChartPoint)arrayList_0[int_2];
			if (int_0 > chartPoint5.int_0)
			{
				return null;
			}
			if (int_0 == chartPoint5.int_0)
			{
				return chartPoint5;
			}
			if (int_0 > chartPoint4.int_0 && int_0 < chartPoint5.int_0)
			{
				int num = (int_2 + int_1) / 2;
				ChartPoint chartPoint6 = (ChartPoint)arrayList_0[num];
				if (int_0 > chartPoint6.int_0)
				{
					if (int_2 - num == 1)
					{
						return null;
					}
					return method_6(int_0, num + 1, int_2 - 1);
				}
				if (int_0 == chartPoint6.int_0)
				{
					return chartPoint6;
				}
				if (num - int_1 == 1)
				{
					return null;
				}
				return method_6(int_0, int_1 + 1, num - 1);
			}
			if (int_0 == chartPoint4.int_0)
			{
				return chartPoint4;
			}
			return null;
		}
		case 0:
		{
			ChartPoint chartPoint3 = (ChartPoint)arrayList_0[int_1];
			if (int_0 == chartPoint3.int_0)
			{
				return chartPoint3;
			}
			return null;
		}
		case 1:
		{
			ChartPoint chartPoint = (ChartPoint)arrayList_0[int_1];
			ChartPoint chartPoint2 = (ChartPoint)arrayList_0[int_2];
			if (int_0 == chartPoint.int_0)
			{
				return chartPoint;
			}
			if (int_0 == chartPoint2.int_0)
			{
				return chartPoint2;
			}
			return null;
		}
		}
	}

	internal ChartPoint method_7(int int_0)
	{
		return (ChartPoint)arrayList_0[int_0];
	}

	internal void method_8()
	{
		int count = Count;
		if (count < arrayList_0.Count)
		{
			arrayList_0.RemoveRange(count, arrayList_0.Count - count);
		}
	}

	internal void Copy(ChartPointCollection chartPointCollection_0)
	{
		for (int i = 0; i < chartPointCollection_0.method_4(); i++)
		{
			ChartPoint chartPoint = (ChartPoint)chartPointCollection_0.arrayList_0[i];
			ChartPoint chartPoint2 = new ChartPoint(series_0, chartPoint.int_0);
			arrayList_0.Add(chartPoint2);
			chartPoint2.Copy(chartPoint);
		}
	}
}
