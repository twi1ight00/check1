using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns2;

namespace Aspose.Cells.Charts;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.Charts.Chart" /> objects.
///       </summary>
/// <example>
///   <code>
///       [C#]
///
///       Workbook workbook = new Workbook();
///
///       ChartCollection charts = workbook.Worksheets[0].Charts;
///
///       [Visual Basic]
///
///       Dim workbook as Workbook = new Workbook()
///
///       Dim ChartCollection as Charts = workbook.Worksheets(0).Charts
///
///       </code>
/// </example>
public class ChartCollection : CollectionBase
{
	private Worksheet worksheet_0;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Charts.Chart" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public Chart this[int index] => (Chart)base.InnerList[index];

	/// <summary>
	///       Gets the chart by the name.
	///       </summary>
	/// <param name="name"> The chart name.</param>
	/// <returns>The chart.</returns>
	/// <remarks>
	///       The default chart name is null. So you have to explicitly set the name of the chart.
	///       </remarks>
	public Chart this[string name]
	{
		get
		{
			int num = 0;
			Chart chart;
			while (true)
			{
				if (num < base.Count)
				{
					chart = this[num];
					string name2 = chart.Name;
					if (name2 != null && name2 == name)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return chart;
		}
	}

	internal ChartCollection(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	[SpecialName]
	internal Worksheet method_0()
	{
		return worksheet_0;
	}

	/// <summary>
	///       Adds a chart to the collection.
	///       </summary>
	/// <param name="type">Chart type</param>
	/// <param name="left">The x offset to corner</param>
	/// <param name="top">The y offset to corner</param>
	/// <param name="width">The chart width</param>
	/// <param name="height">The chart height</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Charts.Chart" /> object index.</returns>
	public int AddFloatingChart(ChartType type, int left, int top, int width, int height)
	{
		Chart chart = new Chart(worksheet_0, type);
		base.InnerList.Add(chart);
		worksheet_0.Shapes.Add(chart.ChartObject);
		if (worksheet_0.Type == SheetType.Chart)
		{
			chart.ChartObject.method_27().method_7().method_4(PlacementType.FreeFloating);
			chart.ChartObject.method_27().method_7().Top = 0;
			chart.ChartObject.method_27().method_7().Left = 0;
			chart.ChartObject.method_27().method_7().Right = 900;
			chart.ChartObject.method_27().method_7().Bottom = 600;
		}
		else
		{
			chart.ChartObject.method_27().method_7().method_4(PlacementType.FreeFloating);
			chart.ChartObject.method_27().method_7().Top = top;
			chart.ChartObject.method_27().method_7().Left = left;
			chart.ChartObject.method_27().method_7().Right = width;
			chart.ChartObject.method_27().method_7().Bottom = height;
		}
		return base.Count - 1;
	}

	/// <summary>
	///       Adds a chart to the collection.
	///       </summary>
	/// <param name="type">Chart type</param>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="lowerRightRow">Lower right row index</param>
	/// <param name="lowerRightColumn">Lower right column index</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Charts.Chart" /> object index.</returns>
	public int Add(ChartType type, int upperLeftRow, int upperLeftColumn, int lowerRightRow, int lowerRightColumn)
	{
		Chart chart = new Chart(worksheet_0, type);
		base.InnerList.Add(chart);
		worksheet_0.Shapes.Add(chart.ChartObject);
		if (worksheet_0.Type == SheetType.Chart)
		{
			chart.ChartObject.method_27().method_7().method_4(PlacementType.FreeFloating);
			chart.ChartObject.method_27().method_7().Top = 0;
			chart.ChartObject.method_27().method_7().Left = 0;
			chart.ChartObject.method_27().method_7().Right = 900;
			chart.ChartObject.method_27().method_7().Bottom = 600;
		}
		else
		{
			chart.ChartObject.MoveToRange(upperLeftRow, upperLeftColumn, lowerRightRow, lowerRightColumn);
		}
		return base.Count - 1;
	}

	internal void RemoveExternalLinks()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Chart chart = (Chart)enumerator.Current;
				foreach (Series item in chart.NSeries)
				{
					if (item.method_16() != null && item.method_16().imethod_4() != null)
					{
						item.method_16().RemoveExternalLinks();
					}
					if (item.method_18() != null && item.method_18().imethod_4() != null)
					{
						item.method_18().RemoveExternalLinks();
					}
					if (item.method_20() != null && item.method_20().imethod_4() != null)
					{
						item.method_20().RemoveExternalLinks();
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
	}

	internal void InsertRows(int int_0, int int_1, Worksheet worksheet_1, bool bool_0)
	{
		byte[] array = null;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Chart chart = (Chart)enumerator.Current;
				foreach (Series item in chart.NSeries)
				{
					object obj = item.method_13();
					if (obj != null && obj is byte[])
					{
						array = (byte[])obj;
						Class1674.InsertRows(worksheet_1, bool_0, int_0, int_1, 0, 0, -1, -1, array);
					}
					if (item.method_16() != null && item.method_16().imethod_4() != null)
					{
						array = item.method_16().imethod_4();
						Class1674.InsertRows(worksheet_1, bool_0, int_0, int_1, 0, 0, -1, -1, array);
						if (item.method_16().imethod_2() != null && item.method_16().imethod_0())
						{
							item.method_16().imethod_3(null);
						}
					}
					if (item.method_18() != null && item.method_18().imethod_4() != null)
					{
						array = item.method_18().imethod_4();
						Class1674.InsertRows(worksheet_1, bool_0, int_0, int_1, 0, 0, -1, -1, array);
						if (item.method_18().imethod_2() != null && item.method_18().imethod_0())
						{
							item.method_18().imethod_3(null);
						}
					}
					if (item.method_20() != null && item.method_20().imethod_4() != null)
					{
						array = item.method_20().imethod_4();
						Class1674.InsertRows(worksheet_1, bool_0, int_0, int_1, 0, 0, -1, -1, array);
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
	}

	internal void method_1(ChartCollection chartCollection_0, int int_0, int int_1, int int_2)
	{
	}

	internal void InsertColumns(int int_0, int int_1, Worksheet worksheet_1, bool bool_0)
	{
		byte[] array = null;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Chart chart = (Chart)enumerator.Current;
				foreach (Series item in chart.NSeries)
				{
					object obj = item.method_13();
					if (obj != null && obj is byte[])
					{
						array = (byte[])obj;
						Class1674.InsertColumns(worksheet_1, bool_0, int_0, int_1, 0, 0, -1, -1, array);
					}
					if (item.method_16() != null && item.method_16().imethod_4() != null)
					{
						array = item.method_16().imethod_4();
						Class1674.InsertColumns(worksheet_1, bool_0, int_0, int_1, 0, 0, -1, -1, array);
					}
					if (item.method_18() != null && item.method_18().imethod_4() != null)
					{
						array = item.method_18().imethod_4();
						Class1674.InsertColumns(worksheet_1, bool_0, int_0, int_1, 0, 0, -1, -1, array);
					}
					if (item.method_20() != null && item.method_20().imethod_4() != null)
					{
						array = item.method_20().imethod_4();
						Class1674.InsertColumns(worksheet_1, bool_0, int_0, int_1, 0, 0, -1, -1, array);
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
	}

	internal void method_2(CellArea cellArea_0, int int_0, ShiftType shiftType_0, Worksheet worksheet_1, bool bool_0)
	{
		byte[] array = null;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Chart chart = (Chart)enumerator.Current;
				foreach (Series item in chart.NSeries)
				{
					object obj = item.method_13();
					if (obj != null && obj is byte[])
					{
						array = (byte[])obj;
						Class1674.smethod_19(cellArea_0, int_0, shiftType_0, worksheet_1, bool_0, array, -1, -1, 0, 0, 0, 0);
					}
					if (item.method_16() != null && item.method_16().imethod_4() != null)
					{
						array = item.method_16().imethod_4();
						Class1674.smethod_19(cellArea_0, int_0, shiftType_0, worksheet_1, bool_0, array, -1, -1, 0, 0, 0, 0);
					}
					if (item.method_18() != null && item.method_18().imethod_4() != null)
					{
						array = item.method_18().imethod_4();
						Class1674.smethod_19(cellArea_0, int_0, shiftType_0, worksheet_1, bool_0, array, -1, -1, 0, 0, 0, 0);
					}
					if (item.method_20() != null && item.method_20().imethod_4() != null)
					{
						array = item.method_20().imethod_4();
						Class1674.smethod_19(cellArea_0, int_0, shiftType_0, worksheet_1, bool_0, array, -1, -1, 0, 0, 0, 0);
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
	}

	internal void method_3(Hashtable hashtable_0)
	{
		byte[] array = null;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Chart chart = (Chart)enumerator.Current;
				foreach (Series item in chart.NSeries)
				{
					object obj = item.method_13();
					if (obj != null && obj is byte[])
					{
						array = (byte[])obj;
						Class1674.smethod_17(array, -1, -1, hashtable_0, worksheet_0.method_2());
					}
					if (item.method_16() != null && item.method_16().imethod_4() != null)
					{
						array = item.method_16().imethod_4();
						Class1674.smethod_17(array, -1, -1, hashtable_0, worksheet_0.method_2());
					}
					if (item.method_18() != null && item.method_18().imethod_4() != null)
					{
						array = item.method_18().imethod_4();
						Class1674.smethod_17(array, -1, -1, hashtable_0, worksheet_0.method_2());
					}
					if (item.method_20() != null && item.method_20().imethod_4() != null)
					{
						array = item.method_20().imethod_4();
						Class1674.smethod_17(array, -1, -1, hashtable_0, worksheet_0.method_2());
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
	}

	internal bool method_4(int int_0)
	{
		byte[] array = null;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Chart chart = (Chart)enumerator.Current;
				foreach (Series item in chart.NSeries)
				{
					object obj = item.method_13();
					if (obj != null && obj is byte[])
					{
						array = (byte[])obj;
						if (Class1674.smethod_14(array, -1, -1, int_0, worksheet_0.method_2()))
						{
							return true;
						}
					}
					if (item.method_16() != null && item.method_16().imethod_4() != null)
					{
						array = item.method_16().imethod_4();
						if (Class1674.smethod_14(array, -1, -1, int_0, worksheet_0.method_2()))
						{
							return true;
						}
					}
					if (item.method_18() != null && item.method_18().imethod_4() != null)
					{
						array = item.method_18().imethod_4();
						if (Class1674.smethod_14(array, -1, -1, int_0, worksheet_0.method_2()))
						{
							return true;
						}
					}
					if (item.method_20() != null && item.method_20().imethod_4() != null)
					{
						array = item.method_20().imethod_4();
						if (Class1674.smethod_14(array, -1, -1, int_0, worksheet_0.method_2()))
						{
							return true;
						}
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
		return false;
	}

	internal bool method_5(SortedList sortedList_0)
	{
		byte[] byte_ = null;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Chart chart = (Chart)enumerator.Current;
				foreach (Series item in chart.NSeries)
				{
					object obj = item.method_13();
					if (obj != null && obj is byte[])
					{
						byte_ = (byte[])obj;
						Class1674.smethod_16(byte_, -1, -1, sortedList_0, worksheet_0.method_2());
					}
					if (item.method_16() != null && item.method_16().imethod_4() != null)
					{
						byte_ = item.method_16().imethod_4();
						Class1674.smethod_16(byte_, -1, -1, sortedList_0, worksheet_0.method_2());
					}
					if (item.method_18() != null && item.method_18().imethod_4() != null)
					{
						Class1674.smethod_16(byte_, -1, -1, sortedList_0, worksheet_0.method_2());
					}
					if (item.method_20() != null && item.method_20().imethod_4() != null)
					{
						byte_ = item.method_20().imethod_4();
						Class1674.smethod_16(byte_, -1, -1, sortedList_0, worksheet_0.method_2());
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
		return false;
	}

	internal bool method_6(bool[] bool_0)
	{
		byte[] byte_ = null;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Chart chart = (Chart)enumerator.Current;
				foreach (Series item in chart.NSeries)
				{
					object obj = item.method_13();
					if (obj != null && obj is byte[])
					{
						byte_ = (byte[])obj;
						Class1674.smethod_15(byte_, -1, -1, bool_0, worksheet_0.method_2());
					}
					if (item.method_16() != null && item.method_16().imethod_4() != null)
					{
						byte_ = item.method_16().imethod_4();
						Class1674.smethod_15(byte_, -1, -1, bool_0, worksheet_0.method_2());
					}
					if (item.method_18() != null && item.method_18().imethod_4() != null)
					{
						Class1674.smethod_15(byte_, -1, -1, bool_0, worksheet_0.method_2());
					}
					if (item.method_20() != null && item.method_20().imethod_4() != null)
					{
						byte_ = item.method_20().imethod_4();
						Class1674.smethod_15(byte_, -1, -1, bool_0, worksheet_0.method_2());
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
		return false;
	}

	/// <summary>
	/// </summary>
	/// <param name="chart">
	/// </param>
	/// <remarks>Only for reading</remarks>
	internal void Add(Chart chart_0)
	{
		base.InnerList.Add(chart_0);
	}

	internal void Remove(Chart chart_0)
	{
		base.InnerList.Remove(chart_0);
	}

	/// <summary>
	///       Remove a chart at the specific index.
	///       </summary>
	/// <param name="index">The chart index.</param>
	public new void RemoveAt(int index)
	{
		Chart chart = this[index];
		if (worksheet_0.Type == SheetType.Worksheet)
		{
			worksheet_0.Shapes.method_26(chart.ChartObject);
		}
		else
		{
			base.InnerList.RemoveAt(index);
		}
	}

	internal void method_7()
	{
		base.InnerList.Clear();
	}

	/// <summary>
	///       Clear all charts.
	///       </summary>
	public new void Clear()
	{
		if (base.Count <= 0)
		{
			return;
		}
		base.InnerList.Clear();
		for (int i = 0; i < worksheet_0.Shapes.Count; i++)
		{
			Shape shape = worksheet_0.Shapes[i];
			if (shape.MsoDrawingType == MsoDrawingType.Chart)
			{
				worksheet_0.Shapes.method_18(shape);
				i--;
			}
		}
	}

	internal static bool smethod_0(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Area3D:
		case ChartType.Area3DStacked:
		case ChartType.Area3D100PercentStacked:
		case ChartType.Bar3DClustered:
		case ChartType.Bar3DStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.Bubble3D:
		case ChartType.Column3D:
		case ChartType.Column3DClustered:
		case ChartType.Column3DStacked:
		case ChartType.Column3D100PercentStacked:
		case ChartType.Cone:
		case ChartType.ConeStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBar:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.ConicalColumn3D:
		case ChartType.Cylinder:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.CylindricalColumn3D:
		case ChartType.Line3D:
		case ChartType.Pie3D:
		case ChartType.Pie3DExploded:
		case ChartType.Pyramid:
		case ChartType.PyramidStacked:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBar:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
		case ChartType.PyramidColumn3D:
		case ChartType.Surface3D:
		case ChartType.SurfaceWireframe3D:
		case ChartType.SurfaceContour:
		case ChartType.SurfaceContourWireframe:
			return true;
		}
	}

	internal static bool smethod_1(ChartType chartType_0, ChartType chartType_1)
	{
		if (chartType_0 == chartType_1)
		{
			return true;
		}
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Area:
		case ChartType.AreaStacked:
		case ChartType.Area100PercentStacked:
		case ChartType.Area3D:
		case ChartType.Area3DStacked:
		case ChartType.Area3D100PercentStacked:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Area:
			case ChartType.AreaStacked:
			case ChartType.Area100PercentStacked:
			case ChartType.Area3D:
			case ChartType.Area3DStacked:
			case ChartType.Area3D100PercentStacked:
				return true;
			}
		case ChartType.Bar:
		case ChartType.BarStacked:
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3DClustered:
		case ChartType.Bar3DStacked:
		case ChartType.Bar3D100PercentStacked:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Bar:
			case ChartType.BarStacked:
			case ChartType.Bar100PercentStacked:
			case ChartType.Bar3DClustered:
			case ChartType.Bar3DStacked:
			case ChartType.Bar3D100PercentStacked:
				return true;
			}
		case ChartType.Bubble:
		case ChartType.Bubble3D:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Bubble:
			case ChartType.Bubble3D:
				return true;
			}
		case ChartType.Column:
		case ChartType.ColumnStacked:
		case ChartType.Column100PercentStacked:
		case ChartType.Column3D:
		case ChartType.Column3DClustered:
		case ChartType.Column3DStacked:
		case ChartType.Column3D100PercentStacked:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Column:
			case ChartType.ColumnStacked:
			case ChartType.Column100PercentStacked:
			case ChartType.Column3D:
			case ChartType.Column3DClustered:
			case ChartType.Column3DStacked:
			case ChartType.Column3D100PercentStacked:
				return true;
			}
		case ChartType.Cone:
		case ChartType.ConeStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBar:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.ConicalColumn3D:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Cone:
			case ChartType.ConeStacked:
			case ChartType.Cone100PercentStacked:
			case ChartType.ConicalBar:
			case ChartType.ConicalBarStacked:
			case ChartType.ConicalBar100PercentStacked:
			case ChartType.ConicalColumn3D:
				return true;
			}
		case ChartType.Cylinder:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.CylindricalColumn3D:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Cylinder:
			case ChartType.CylinderStacked:
			case ChartType.Cylinder100PercentStacked:
			case ChartType.CylindricalBar:
			case ChartType.CylindricalBarStacked:
			case ChartType.CylindricalBar100PercentStacked:
			case ChartType.CylindricalColumn3D:
				return true;
			}
		case ChartType.Doughnut:
		case ChartType.DoughnutExploded:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Doughnut:
			case ChartType.DoughnutExploded:
				return true;
			}
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.LineWithDataMarkers:
		case ChartType.LineStackedWithDataMarkers:
		case ChartType.Line100PercentStackedWithDataMarkers:
		case ChartType.Line3D:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Line:
			case ChartType.LineStacked:
			case ChartType.Line100PercentStacked:
			case ChartType.LineWithDataMarkers:
			case ChartType.LineStackedWithDataMarkers:
			case ChartType.Line100PercentStackedWithDataMarkers:
			case ChartType.Line3D:
				return true;
			}
		case ChartType.Pie:
		case ChartType.Pie3D:
		case ChartType.PiePie:
		case ChartType.PieExploded:
		case ChartType.Pie3DExploded:
		case ChartType.PieBar:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Pie:
			case ChartType.Pie3D:
			case ChartType.PiePie:
			case ChartType.PieExploded:
			case ChartType.Pie3DExploded:
			case ChartType.PieBar:
				return true;
			}
		case ChartType.Pyramid:
		case ChartType.PyramidStacked:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBar:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
		case ChartType.PyramidColumn3D:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Pyramid:
			case ChartType.PyramidStacked:
			case ChartType.Pyramid100PercentStacked:
			case ChartType.PyramidBar:
			case ChartType.PyramidBarStacked:
			case ChartType.PyramidBar100PercentStacked:
			case ChartType.PyramidColumn3D:
				return true;
			}
		case ChartType.Radar:
		case ChartType.RadarWithDataMarkers:
		case ChartType.RadarFilled:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Radar:
			case ChartType.RadarWithDataMarkers:
			case ChartType.RadarFilled:
				return true;
			}
		case ChartType.Scatter:
		case ChartType.ScatterConnectedByCurvesWithDataMarker:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType.ScatterConnectedByLinesWithDataMarker:
		case ChartType.ScatterConnectedByLinesWithoutDataMarker:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Scatter:
			case ChartType.ScatterConnectedByCurvesWithDataMarker:
			case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
			case ChartType.ScatterConnectedByLinesWithDataMarker:
			case ChartType.ScatterConnectedByLinesWithoutDataMarker:
				return true;
			}
		case ChartType.StockHighLowClose:
		case ChartType.StockOpenHighLowClose:
		case ChartType.StockVolumeHighLowClose:
		case ChartType.StockVolumeOpenHighLowClose:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.StockHighLowClose:
			case ChartType.StockOpenHighLowClose:
			case ChartType.StockVolumeHighLowClose:
			case ChartType.StockVolumeOpenHighLowClose:
				return true;
			}
		case ChartType.Surface3D:
		case ChartType.SurfaceWireframe3D:
		case ChartType.SurfaceContour:
		case ChartType.SurfaceContourWireframe:
			switch (chartType_1)
			{
			default:
				return false;
			case ChartType.Surface3D:
			case ChartType.SurfaceWireframe3D:
			case ChartType.SurfaceContour:
			case ChartType.SurfaceContourWireframe:
				return true;
			}
		}
	}

	internal static bool smethod_2(ChartType chartType_0, ChartType chartType_1)
	{
		if (chartType_0 == chartType_1)
		{
			return true;
		}
		if (!smethod_0(chartType_0) && !smethod_0(chartType_0))
		{
			switch (chartType_0)
			{
			case ChartType.Doughnut:
			case ChartType.DoughnutExploded:
				switch (chartType_1)
				{
				default:
					return false;
				case ChartType.Doughnut:
				case ChartType.DoughnutExploded:
					return true;
				}
			case ChartType.Pie:
			case ChartType.PiePie:
			case ChartType.PieBar:
				switch (chartType_1)
				{
				default:
					return false;
				case ChartType.Pie:
				case ChartType.PiePie:
				case ChartType.PieBar:
					return true;
				}
			case ChartType.Radar:
			case ChartType.RadarWithDataMarkers:
				switch (chartType_1)
				{
				default:
					return false;
				case ChartType.Radar:
				case ChartType.RadarWithDataMarkers:
					return true;
				}
			case ChartType.RadarFilled:
				if (chartType_1 == ChartType.RadarFilled)
				{
					return true;
				}
				return false;
			case ChartType.Bar:
			case ChartType.BarStacked:
			case ChartType.Bar100PercentStacked:
				switch (chartType_1)
				{
				default:
					return false;
				case ChartType.Bar:
				case ChartType.BarStacked:
				case ChartType.Bar100PercentStacked:
					return true;
				}
			default:
				return false;
			case ChartType.Area:
			case ChartType.AreaStacked:
			case ChartType.Area100PercentStacked:
			case ChartType.Column:
			case ChartType.ColumnStacked:
			case ChartType.Column100PercentStacked:
			case ChartType.Line:
			case ChartType.LineStacked:
			case ChartType.Line100PercentStacked:
			case ChartType.LineWithDataMarkers:
			case ChartType.LineStackedWithDataMarkers:
			case ChartType.Line100PercentStackedWithDataMarkers:
			case ChartType.Scatter:
			case ChartType.ScatterConnectedByCurvesWithDataMarker:
			case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
			case ChartType.ScatterConnectedByLinesWithDataMarker:
			case ChartType.ScatterConnectedByLinesWithoutDataMarker:
				switch (chartType_1)
				{
				default:
					return false;
				case ChartType.Area:
				case ChartType.AreaStacked:
				case ChartType.Area100PercentStacked:
				case ChartType.Column:
				case ChartType.ColumnStacked:
				case ChartType.Column100PercentStacked:
				case ChartType.Line:
				case ChartType.LineStacked:
				case ChartType.Line100PercentStacked:
				case ChartType.LineWithDataMarkers:
				case ChartType.LineStackedWithDataMarkers:
				case ChartType.Line100PercentStackedWithDataMarkers:
				case ChartType.Scatter:
				case ChartType.ScatterConnectedByCurvesWithDataMarker:
				case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
				case ChartType.ScatterConnectedByLinesWithDataMarker:
				case ChartType.ScatterConnectedByLinesWithoutDataMarker:
					return true;
				}
			}
		}
		throw new ArgumentException("You could not combin 2-D and 3-D chart types");
	}

	internal static bool smethod_3(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Pie:
		case ChartType.Pie3D:
		case ChartType.PiePie:
		case ChartType.PieExploded:
		case ChartType.Pie3DExploded:
		case ChartType.PieBar:
			return true;
		}
	}

	internal static bool smethod_4(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return true;
		case ChartType.Doughnut:
		case ChartType.DoughnutExploded:
		case ChartType.Pie:
		case ChartType.Pie3D:
		case ChartType.PiePie:
		case ChartType.PieExploded:
		case ChartType.Pie3DExploded:
		case ChartType.PieBar:
			return false;
		}
	}

	internal static bool smethod_5(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Surface3D:
		case ChartType.SurfaceWireframe3D:
		case ChartType.SurfaceContour:
		case ChartType.SurfaceContourWireframe:
			return true;
		}
	}

	internal static bool smethod_6(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Area3D:
		case ChartType.Column3D:
		case ChartType.ConicalColumn3D:
		case ChartType.CylindricalColumn3D:
		case ChartType.Line3D:
		case ChartType.PyramidColumn3D:
		case ChartType.Surface3D:
		case ChartType.SurfaceWireframe3D:
		case ChartType.SurfaceContour:
		case ChartType.SurfaceContourWireframe:
			return true;
		}
	}

	internal static bool smethod_7(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Bar:
		case ChartType.BarStacked:
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3DClustered:
		case ChartType.Bar3DStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.Column:
		case ChartType.ColumnStacked:
		case ChartType.Column100PercentStacked:
		case ChartType.Column3D:
		case ChartType.Column3DClustered:
		case ChartType.Column3DStacked:
		case ChartType.Column3D100PercentStacked:
			return true;
		}
	}

	internal static bool smethod_8(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Bar:
		case ChartType.BarStacked:
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3DClustered:
		case ChartType.Bar3DStacked:
		case ChartType.Bar3D100PercentStacked:
			return true;
		}
	}

	internal static bool smethod_9(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.AreaStacked:
		case ChartType.Area3DStacked:
		case ChartType.BarStacked:
		case ChartType.Bar3DStacked:
		case ChartType.ColumnStacked:
		case ChartType.Column3DStacked:
		case ChartType.ConeStacked:
		case ChartType.ConicalBarStacked:
		case ChartType.CylinderStacked:
		case ChartType.CylindricalBarStacked:
		case ChartType.LineStacked:
		case ChartType.LineStackedWithDataMarkers:
		case ChartType.PyramidStacked:
		case ChartType.PyramidBarStacked:
			return true;
		}
	}

	internal static bool smethod_10(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Bar3DClustered:
		case ChartType.Bar3DStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.Column3D:
		case ChartType.Column3DClustered:
		case ChartType.Column3DStacked:
		case ChartType.Column3D100PercentStacked:
		case ChartType.Cone:
		case ChartType.ConeStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBar:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.ConicalColumn3D:
		case ChartType.Cylinder:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.CylindricalColumn3D:
		case ChartType.Pyramid:
		case ChartType.PyramidStacked:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBar:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
		case ChartType.PyramidColumn3D:
			return true;
		}
	}

	internal static bool smethod_11(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Scatter:
		case ChartType.ScatterConnectedByCurvesWithDataMarker:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType.ScatterConnectedByLinesWithDataMarker:
		case ChartType.ScatterConnectedByLinesWithoutDataMarker:
			return true;
		}
	}

	internal static bool smethod_12(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Bubble:
		case ChartType.Bubble3D:
		case ChartType.Scatter:
		case ChartType.ScatterConnectedByCurvesWithDataMarker:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType.ScatterConnectedByLinesWithDataMarker:
		case ChartType.ScatterConnectedByLinesWithoutDataMarker:
			return true;
		}
	}

	internal static bool smethod_13(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Doughnut:
		case ChartType.DoughnutExploded:
			return true;
		}
	}

	internal static bool smethod_14(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.LineWithDataMarkers:
		case ChartType.LineStackedWithDataMarkers:
		case ChartType.Line100PercentStackedWithDataMarkers:
		case ChartType.Line3D:
			return true;
		}
	}

	internal static bool smethod_15(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Radar:
		case ChartType.RadarWithDataMarkers:
		case ChartType.RadarFilled:
			return true;
		}
	}

	internal static bool smethod_16(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Area:
		case ChartType.AreaStacked:
		case ChartType.Area100PercentStacked:
		case ChartType.Area3D:
		case ChartType.Area3DStacked:
		case ChartType.Area3D100PercentStacked:
			return true;
		}
	}

	internal static bool smethod_17(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.Bubble:
		case ChartType.Bubble3D:
			return true;
		}
	}

	internal static bool smethod_18(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		default:
			return false;
		case ChartType.StockHighLowClose:
		case ChartType.StockOpenHighLowClose:
		case ChartType.StockVolumeHighLowClose:
		case ChartType.StockVolumeOpenHighLowClose:
			return true;
		}
	}
}
