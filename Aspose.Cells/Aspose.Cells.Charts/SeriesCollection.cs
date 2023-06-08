using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns2;
using ns25;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.Charts.Series" /> objects.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///       //Adding a new worksheet to the Excel object
///       int sheetIndex = workbook.Worksheets.Add();
///       //Obtaining the reference of the newly added worksheet by passing its sheet index
///       Worksheet worksheet = workbook.Worksheets[sheetIndex];
///       //Adding a sample value to "A1" cell
///       worksheet.Cells["A1"].PutValue(50);
///       //Adding a sample value to "A2" cell
///       worksheet.Cells["A2"].PutValue(100);
///       //Adding a sample value to "A3" cell
///       worksheet.Cells["A3"].PutValue(150);
///       //Adding a sample value to "A4" cell
///       worksheet.Cells["A4"].PutValue(200);
///       //Adding a sample value to "B1" cell
///       worksheet.Cells["B1"].PutValue(60);
///       //Adding a sample value to "B2" cell
///       worksheet.Cells["B2"].PutValue(32);
///       //Adding a sample value to "B3" cell
///       worksheet.Cells["B3"].PutValue(50);
///       //Adding a sample value to "B4" cell
///       worksheet.Cells["B4"].PutValue(40);
///       //Adding a sample value to "C1" cell as category data
///       worksheet.Cells["C1"].PutValue("Q1");
///       //Adding a sample value to "C2" cell as category data
///       worksheet.Cells["C2"].PutValue("Q2");
///       //Adding a sample value to "C3" cell as category data
///       worksheet.Cells["C3"].PutValue("Y1");
///       //Adding a sample value to "C4" cell as category data
///       worksheet.Cells["C4"].PutValue("Y2");
///       //Adding a chart to the worksheet
///       int chartIndex = worksheet.Charts.Add(ChartType.Column, 5, 0, 15, 5);
///       //Accessing the instance of the newly added chart
///       Chart chart = worksheet.Charts[chartIndex];
///       //Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B4"
///       chart.NSeries.Add("A1:B4", true);
///       //Setting the data source for the category data of NSeries
///       chart.NSeries.CategoryData = "C1:C4";
///       //Saving the Excel file
///       workbook.Save("C:\\book1.xls");
///
///       [Visual Basic]
///
///       'Instantiating a Workbook object
///       Dim workbook As Workbook = New Workbook()
///       'Adding a new worksheet to the Excel object
///       Dim sheetIndex As Integer = workbook.Worksheets.Add()
///       'Obtaining the reference of the newly added worksheet by passing its sheet index
///       Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)
///       'Adding a sample value to "A1" cell
///       worksheet.Cells("A1").PutValue(50)
///       'Adding a sample value to "A2" cell
///       worksheet.Cells("A2").PutValue(100)
///       'Adding a sample value to "A3" cell
///       worksheet.Cells("A3").PutValue(150)
///       'Adding a sample value to "A4" cell
///       worksheet.Cells("A4").PutValue(200)
///       'Adding a sample value to "B1" cell
///       worksheet.Cells("B1").PutValue(60)
///       'Adding a sample value to "B2" cell
///       worksheet.Cells("B2").PutValue(32)
///       'Adding a sample value to "B3" cell
///       worksheet.Cells("B3").PutValue(50)
///       'Adding a sample value to "B4" cell
///       worksheet.Cells("B4").PutValue(40)
///       'Adding a sample value to "C1" cell as category data
///       worksheet.Cells("C1").PutValue("Q1")
///       'Adding a sample value to "C2" cell as category data
///       worksheet.Cells("C2").PutValue("Q2")
///       'Adding a sample value to "C3" cell as category data
///       worksheet.Cells("C3").PutValue("Y1")
///       'Adding a sample value to "C4" cell as category data
///       worksheet.Cells("C4").PutValue("Y2")
///       'Adding a chart to the worksheet
///       Dim chartIndex As Integer = worksheet.Charts.Add(ChartType.Column, 5, 0, 15, 5)
///       'Accessing the instance of the newly added chart
///       Dim chart As Chart = worksheet.Charts(chartIndex)
///       'Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B4"
///       chart.NSeries.Add("A1:B4", True)
///       'Setting the data source for the category data of NSeries
///       chart.NSeries.CategoryData = "C1:C4"
///       'Saving the Excel file
///       workbook.Save("C:\book1.xls")
///       </code>
/// </example>
public class SeriesCollection : CollectionBase
{
	private Chart chart_0;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Charts.Series" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public Series this[int index] => (Series)base.InnerList[index];

	/// <summary>
	///       Gets or sets the range of category Axis values. 
	///        It can be a range of cells (such as, "d1:e10"), 
	///        or a sequence of values (such as,"{2,6,8,10}"). 
	///        </summary>
	public string CategoryData
	{
		get
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Series series = (Series)enumerator.Current;
					if (!series.PlotOnSecondAxis)
					{
						return series.XValues;
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
			return "";
		}
		set
		{
			string xValues = value.Trim();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Series series = (Series)enumerator.Current;
					if (!series.PlotOnSecondAxis)
					{
						series.XValues = xValues;
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
		}
	}

	/// <summary>
	///       Gets or sets the range of second category Axis values. 
	///        It can be a range of cells (such as, "d1:e10"), 
	///        or a sequence of values (such as,"{2,6,8,10}"). 
	///        Only effects when some ASerieses plot on the second axis.
	///        </summary>
	public string SecondCatergoryData
	{
		get
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Series series = (Series)enumerator.Current;
					if (series.PlotOnSecondAxis)
					{
						return series.XValues;
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
			return "";
		}
		set
		{
			string xValues = value.Trim();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Series series = (Series)enumerator.Current;
					if (series.PlotOnSecondAxis)
					{
						series.XValues = xValues;
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
		}
	}

	/// <summary>
	///       Represents if the color of points is varied. 
	///       </summary>
	public bool IsColorVaried
	{
		get
		{
			return chart_0.class1388_0[0].IsColorVaried;
		}
		set
		{
			switch (chart_0.Type)
			{
			case ChartType.Pie:
			case ChartType.Pie3D:
			case ChartType.PiePie:
			case ChartType.PieExploded:
			case ChartType.Pie3DExploded:
			case ChartType.PieBar:
				chart_0.class1388_0[0].IsColorVaried = value;
				return;
			}
			if (base.Count == 1)
			{
				chart_0.class1388_0[0].IsColorVaried = value;
			}
		}
	}

	internal Chart Chart => chart_0;

	internal SeriesCollection(Chart chart_1)
	{
		chart_0 = chart_1;
	}

	[SpecialName]
	internal Worksheet method_0()
	{
		return chart_0.method_15();
	}

	[SpecialName]
	internal WorksheetCollection method_1()
	{
		return chart_0.method_14();
	}

	/// <summary>
	///       Remove at a series at the specific index.
	///       </summary>
	/// <param name="index">The index.</param>
	public new void RemoveAt(int index)
	{
		_ = (Series)base.InnerList[index];
		base.InnerList.RemoveAt(index);
	}

	internal void RemoveRange(int int_0, int int_1)
	{
		base.InnerList.RemoveRange(int_0, int_1);
	}

	private void method_2(Series series_0)
	{
		switch (chart_0.Type)
		{
		case ChartType.StockHighLowClose:
			series_0.Line.IsVisible = false;
			if (base.InnerList.Count >= 2 && base.InnerList.Count == 2)
			{
				series_0.MarkerStyle = ChartMarkerType.Dot;
				series_0.MarkerForegroundColor = Color.Black;
				series_0.MarkerBackgroundColor = Color.Black;
			}
			break;
		case ChartType.StockOpenHighLowClose:
			series_0.Line.IsVisible = false;
			break;
		case ChartType.StockVolumeHighLowClose:
			series_0.Line.IsVisible = false;
			series_0.MarkerStyle = ChartMarkerType.None;
			if (base.InnerList.Count == 0)
			{
				series_0.method_29(chart_0.class1388_0[0]);
				series_0.method_1(3);
			}
			else if (base.InnerList.Count < 3)
			{
				series_0.method_29(chart_0.class1388_0[1]);
				series_0.method_1(base.InnerList.Count - 1);
			}
			else if (base.InnerList.Count == 3)
			{
				series_0.method_29(chart_0.class1388_0[1]);
				series_0.MarkerStyle = ChartMarkerType.Dot;
				series_0.MarkerForegroundColor = Color.Black;
				series_0.MarkerBackgroundColor = Color.Black;
				series_0.method_1(base.InnerList.Count - 1);
			}
			break;
		case ChartType.StockVolumeOpenHighLowClose:
			if (base.InnerList.Count == 0)
			{
				series_0.method_29(chart_0.class1388_0[0]);
				series_0.method_1(4);
			}
			else if (base.InnerList.Count < 5)
			{
				series_0.Line.IsVisible = false;
				series_0.MarkerStyle = ChartMarkerType.None;
				series_0.method_29(chart_0.class1388_0[1]);
				series_0.GapWidth = 100;
				series_0.method_1(base.InnerList.Count - 1);
			}
			break;
		}
	}

	private void method_3(Series series_0)
	{
		method_2(series_0);
		if (series_0.Type == ChartType.Bubble3D)
		{
			series_0.Has3DEffect = true;
		}
	}

	private void method_4(Series series_0)
	{
		method_3(series_0);
		base.InnerList.Add(series_0);
	}

	/// <summary>
	///       Directly chanages the orders of the two series.
	///       </summary>
	/// <param name="sourceIndex">The current index</param>
	/// <param name="destIndex">The dest index</param>
	public void ChangeSeriesOrder(int sourceIndex, int destIndex)
	{
		object value = base.InnerList[destIndex];
		object value2 = base.InnerList[sourceIndex];
		base.InnerList[destIndex] = value2;
		base.InnerList[sourceIndex] = value;
	}

	internal void method_5(int int_0, int int_1)
	{
		object value = base.InnerList[int_0];
		base.InnerList.Insert(int_1, value);
		base.InnerList.RemoveAt(int_0 + 1);
	}

	internal void method_6(int int_0, int int_1)
	{
		object value = base.InnerList[int_0];
		base.InnerList.Insert(int_1, value);
		base.InnerList.RemoveAt(int_0);
	}

	internal void method_7(int int_0, Series series_0)
	{
		if (int_0 >= base.Count)
		{
			base.InnerList.Add(series_0);
		}
		else
		{
			base.InnerList.Insert(int_0, series_0);
		}
	}

	internal void method_8(Series series_0)
	{
		base.InnerList.Add(series_0);
	}

	/// <summary>
	///       Adds the <see cref="T:Aspose.Cells.Charts.SeriesCollection" /> collection to a chart.
	///       </summary>
	/// <param name="area">Specifies values from which to plot the data series</param>
	/// <param name="isVertical">Specifies whether to plot the series from a range of cell values by row or by column.</param>
	/// <returns>Return the first index of the added ASeries in the NSeries.</returns>
	/// <remarks>
	///   <br>If set data on contiguous cells, use colon to seperate them.For example, R[1]C[1]:R[3]C[2].</br>
	///   <br>If set data on contiguous cells, use comma to seperate them.For example,R[1]C[1],R[3]C[2].</br>
	/// </remarks>
	public int AddR1C1(string area, bool isVertical)
	{
		area = Class1619.smethod_10(area, 0, 0);
		return Add(area, isVertical);
	}

	/// <summary>
	///       Adds the <see cref="T:Aspose.Cells.Charts.SeriesCollection" /> collection to a chart.
	///       </summary>
	/// <param name="area">Specifies values from which to plot the data series</param>
	/// <param name="isVertical">Specifies whether to plot the series from a range of cell values by row or by column.</param>
	/// <returns>Return the first index of the added ASeries in the NSeries.</returns>
	/// <remarks>
	///   <br>If set data on contiguous cells, use colon to seperate them.For example, C2:C5.</br>
	///   <br>If set data on non contiguous cells, use comma to seperate them.For example, C2,D5.</br>
	/// </remarks>
	public int Add(string area, bool isVertical)
	{
		if (area == null)
		{
			return -1;
		}
		area = area.Trim();
		Interface45 @interface = Class1195.smethod_1(method_1(), method_0(), area);
		int count = base.Count;
		switch (@interface.imethod_13())
		{
		default:
			throw new CellsException(ExceptionType.InvalidData, "Invalid series values");
		case Enum126.const_3:
		{
			string string_ = "";
			int supbook = 0;
			int sheetIndex = 0;
			@interface.imethod_10(out supbook, out sheetIndex);
			if (sheetIndex == method_0().SheetIndex)
			{
				if (method_1()[method_0().SheetIndex].Type == SheetType.Chart)
				{
					throw new CellsException(ExceptionType.InvalidData, "Invalid chart data source.");
				}
			}
			else
			{
				string_ = method_1()[sheetIndex].Name;
			}
			Add(isVertical, string_, @interface.StartRow, @interface.StartColumn, @interface.EndRow, @interface.EndColumn, bool_1: false);
			break;
		}
		case Enum126.const_4:
		{
			Range range = @interface.imethod_12();
			if (range == null)
			{
				break;
			}
			if (isVertical)
			{
				if (range.ColumnCount == 1)
				{
					Series series = new Series(method_1(), this, base.Count);
					series.method_17(@interface);
					series.method_26(chart_0.Type);
					method_4(series);
					return count;
				}
			}
			else if (range.RowCount == 1)
			{
				Series series = new Series(method_1(), this, base.Count);
				series.method_17(@interface);
				series.method_26(chart_0.Type);
				method_4(series);
				return count;
			}
			CellArea area2 = range.Area;
			Add(isVertical, range.Worksheet.Name, area2.StartRow, area2.StartColumn, area2.EndRow, area2.EndColumn, bool_1: false);
			break;
		}
		case Enum126.const_2:
		case Enum126.const_5:
		{
			Series series = new Series(method_1(), this, base.Count);
			series.Values = area;
			series.method_26(chart_0.Type);
			method_4(series);
			break;
		}
		case Enum126.const_1:
		case Enum126.const_6:
		{
			Series series = new Series(method_1(), this, base.Count);
			series.Values = area;
			series.method_26(chart_0.Type);
			method_4(series);
			break;
		}
		}
		if (base.Count >= 256)
		{
			throw new CellsException(ExceptionType.Limitation, "The number of series could not exceed 256.");
		}
		return count;
	}

	private void Add(bool bool_0, string string_0, int int_0, int int_1, int int_2, int int_3, bool bool_1)
	{
		if (string_0 != "")
		{
			if (Class1677.smethod_21(string_0))
			{
				string_0 = "'" + string_0 + "'";
			}
			string_0 += "!";
		}
		if (bool_0)
		{
			for (int i = int_1; i <= int_3; i++)
			{
				string text = CellsHelper.CellIndexToName(int_0, i);
				string text2 = CellsHelper.CellIndexToName(int_2, i);
				Series series = new Series(method_1(), this, base.Count);
				series.Values = string_0 + text + ":" + text2;
				series.method_26(chart_0.Type);
				if (base.Count < 65535)
				{
					method_4(series);
				}
			}
			return;
		}
		for (int j = int_0; j <= int_2; j++)
		{
			string text3 = CellsHelper.CellIndexToName(j, int_1);
			string text4 = CellsHelper.CellIndexToName(j, int_3);
			Series series2 = new Series(method_1(), this, base.Count);
			series2.Values = string_0 + text3 + ":" + text4;
			series2.method_26(chart_0.Type);
			if (base.Count < 65535)
			{
				method_4(series2);
			}
		}
	}

	internal void Copy(SeriesCollection seriesCollection_0, CopyOptions copyOptions_0)
	{
		for (int i = 0; i < seriesCollection_0.InnerList.Count; i++)
		{
			Series series_ = (Series)seriesCollection_0.InnerList[i];
			Series series = new Series(method_1(), this, base.Count);
			series.Copy(series_, copyOptions_0);
			base.InnerList.Add(series);
		}
	}

	internal int method_9(bool bool_0)
	{
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Series series = (Series)enumerator.Current;
				if (series.method_28().PlotOnSecondAxis == bool_0)
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

	internal void method_10(Class1387 class1387_0, DataLabels dataLabels_0)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Series series = (Series)enumerator.Current;
				if (series.method_28() == class1387_0 && series.method_24() == null)
				{
					series.DataLabels.Copy(dataLabels_0);
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
	}
}
