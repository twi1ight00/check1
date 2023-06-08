using System;
using System.Collections;

namespace Aspose.Cells.Charts;

/// <summary>
///       Represents a collection of all the <see cref="T:Aspose.Cells.Charts.Trendline" /> objects for the specified data series.
///       </summary>
/// <example>
///   <code>
///       [C#]
///       int chartIndex = excel.Worksheets[0].Charts.Add(ChartType.Column, 3, 3, 15, 10);
///       Chart chart = excel.Worksheets[0].Charts[chartIndex];
///       chart.NSeries.Add("A1:a3", true);
///       chart.NSeries[0].TrendLines.Add(TrendlineType.Linear, "MyTrendLine");
///       Trendline line = chart.NSeries[0].TrendLines[0];
///       line.DisplayEquation = true;
///       line.DisplayRSquared = true;
///       line.Color = Color.Red;
///
///       [Visual Basic]
///       Dim chartIndex As Integer =  excel.Worksheets(0).Charts.Add(ChartType.Column,3,3,15,10) 
///       Dim chart As Chart =  excel.Worksheets(0).Charts(chartIndex) 
///       chart.NSeries.Add("A1:a3", True)
///       chart.NSeries(0).TrendLines.Add(TrendlineType.Linear, "MyTrendLine")
///       Dim line As Trendline =  chart.NSeries(0).TrendLines(0) 
///       line.DisplayEquation = True
///       line.DisplayRSquared = True
///       line.Color = Color.Red
///       </code>
/// </example>
public class TrendlineCollection : CollectionBase
{
	private Series series_0;

	/// <summary>
	///       Gets a <seealso cref="T:Aspose.Cells.Charts.Trendline" /> object by its index.
	///       </summary>
	public Trendline this[int index] => (Trendline)base.InnerList[index];

	internal TrendlineCollection(Series series_1)
	{
		series_0 = series_1;
	}

	/// <summary>
	///       Adds a <seealso cref="T:Aspose.Cells.Charts.Trendline" /> object to this collection with specified type.
	///       </summary>
	/// <param name="type">Trendline type.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Charts.Trendline" /> object index.</returns>
	public int Add(TrendlineType type)
	{
		Trendline value = new Trendline(series_0, type);
		base.InnerList.Add(value);
		return base.Count - 1;
	}

	internal int method_0(TrendlineType trendlineType_0)
	{
		Trendline trendline = new Trendline(series_0, trendlineType_0);
		trendline.method_39(series_0.NSeries.Chart.int_5++);
		base.InnerList.Add(trendline);
		return base.Count - 1;
	}

	/// <summary>
	///       Adds a <seealso cref="T:Aspose.Cells.Charts.Trendline" /> object to this collection with specified type and name.
	///       </summary>
	/// <param name="type">Trendline type.</param>
	/// <param name="name">Trendline name.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Charts.Trendline" /> object index.</returns>
	public int Add(TrendlineType type, string name)
	{
		if (name != null && !(name == ""))
		{
			if (name.Length > 255)
			{
				throw new ArgumentException("Too long name.");
			}
			Trendline trendline = new Trendline(series_0, type, name);
			trendline.method_39(series_0.NSeries.Chart.int_5++);
			base.InnerList.Add(trendline);
			return base.Count - 1;
		}
		return Add(type);
	}

	internal void Add(Trendline trendline_0)
	{
		base.InnerList.Add(trendline_0);
	}

	internal void Copy(TrendlineCollection trendlineCollection_0)
	{
		for (int i = 0; i < trendlineCollection_0.Count; i++)
		{
			Trendline trendline = new Trendline(series_0, trendlineCollection_0[i].Type, trendlineCollection_0[i].Name);
			base.InnerList.Add(trendline);
			trendline.Copy(trendlineCollection_0[i]);
		}
	}
}
