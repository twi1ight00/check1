using System;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns21;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Represents a trendline in a chart.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
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
///       //adding a linear trendline
///       int index = chart.NSeries[0].TrendLines.Add(TrendlineType.Linear);
///       Trendline trendline = chart.NSeries[0].TrendLines[index];
///       //Setting the custom name of the trendline.
///       trendline.Name = "Linear";
///       //Displaying the equation on chart
///       trendline.DisplayEquation = true;
///       //Displaying the R-Squared value on chart
///       trendline.DisplayRSquared = true;
///       //Saving the Excel file
///       workbook.Save("C:\\book1.xls");
///
///       [Visual Basic]
///
///       'Instantiating a Workbook object
///       Dim workbook As Workbook = New Workbook()
///       'Adding a new worksheet to the Excel object
///       Dim sheetIndex As Int32 = workbook.Worksheets.Add()
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
///       Dim chartIndex As Int32 = worksheet.Charts.Add(ChartType.Column, 5, 0, 15, 5)
///       'Accessing the instance of the newly added chart
///       Dim chart As Chart = worksheet.Charts(chartIndex)
///       'Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B4"
///       chart.NSeries.Add("A1:B4", True)
///       'Setting the data source for the category data of NSeries
///       Chart.NSeries.CategoryData = "C1:C4"
///       'adding a linear trendline
///       Dim index As Int32 = chart.NSeries(0).TrendLines.Add(TrendlineType.Linear)
///       Dim trendline As Trendline = chart.NSeries(0).TrendLines(index)
///       'Setting the custom name of the trendline.
///       trendline.Name = "Linear"
///       'Displaying the equation on chart
///       trendline.DisplayEquation = True
///       'Displaying the R-Squared value on chart
///       trendline.DisplayRSquared = True
///       'Saving the Excel file
///       workbook.Save("C:\\book1.xls")
///       </code>
/// </example>
public class Trendline : Line
{
	private Series series_0;

	private bool bool_0;

	private TrendlineType trendlineType_0;

	private string string_0;

	internal int int_2 = 2;

	private int int_3 = 2;

	private double double_0;

	private double double_1;

	private bool bool_1;

	private bool bool_2;

	private double double_2;

	private DataLabels dataLabels_0;

	private bool bool_3;

	private int int_4;

	private ShapePropertyCollection shapePropertyCollection_0;

	/// <summary>
	///       Returns if Microsoft Excel automatically determines the name of the trendline. 
	///       </summary>
	public bool IsNameAuto
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

	/// <summary>
	///       Returns the trendline type.
	///       </summary>
	public TrendlineType Type => trendlineType_0;

	/// <summary>
	///       Returns the name of the trendline.
	///       </summary>
	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			if (value != null && value != "")
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Returns or sets the trendline order (an integer greater than 1) when the trendline type is Polynomial. 
	///       The order must be between 2 and 6.
	///       </summary>
	public int Order
	{
		get
		{
			return int_2;
		}
		set
		{
			if (value < 2 || value > 6)
			{
				throw new ArgumentException("Invalid the trendline order");
			}
			int_2 = value;
		}
	}

	/// <summary>
	///       Returns or sets the period for the moving-average trendline.
	///       </summary>
	/// <remarks>This value should be between 2 and 255.
	///       And it must be less than the number of the chart points in the series</remarks>
	public int Period
	{
		get
		{
			return int_3;
		}
		set
		{
			int num = 0;
			if (series_0.method_16() != null)
			{
				num = series_0.method_16().imethod_11();
			}
			if (value < 2 || value > num)
			{
				throw new ArgumentException("This value should be between 2 and  the number of the chart points in the series.");
			}
			int_3 = value;
		}
	}

	/// <summary>
	///       Returns or sets the number of periods (or units on a scatter chart) that the trendline extends forward.
	///       The number of periods must be greater than and equal to zero.
	///       </summary>
	public double Forward
	{
		get
		{
			return double_0;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentException("The forward value must be greater than and equal to zero");
			}
			double_0 = value;
		}
	}

	/// <summary>
	///       Returns or sets the number of periods (or units on a scatter chart) that the trendline extends backward. 
	///       The number of periods must be greater than and equal to zero.
	///       If the chart type is column ,the number of periods must be between 0 and 0.5
	///       </summary>
	public double Backward
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentException("The backward value must greater than and equal to zero");
			}
			if (!ChartCollection.smethod_11(series_0.Type) && !ChartCollection.smethod_17(series_0.Type) && value > 0.5)
			{
				throw new ArgumentException("The backward value must be between 0 and 0.5 when the chart type is column");
			}
			double_1 = value;
		}
	}

	/// <summary>
	///       Represents if the equation for the trendline is displayed on the chart (in the same data label as the R-squared value). Setting this property to True automatically turns on data labels. 
	///       </summary>
	public bool DisplayEquation
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			if (value && dataLabels_0 == null)
			{
				dataLabels_0 = new DataLabels(this, series_0.NSeries.Chart);
			}
		}
	}

	/// <summary>
	///       Represents if the R-squared value of the trendline is displayed on the chart (in the same data label as the equation). Setting this property to True automatically turns on data labels. 
	///       </summary>
	public bool DisplayRSquared
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			if (value && dataLabels_0 == null)
			{
				dataLabels_0 = new DataLabels(this, series_0.NSeries.Chart);
			}
		}
	}

	/// <summary>
	///       Returns or sets the point where the trendline crosses the value axis.
	///       </summary>
	public double Intercept
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			bool_3 = true;
		}
	}

	/// <summary>
	///       Represents the DataLabels object for the specified ASeries. 
	///       </summary>
	public DataLabels DataLabels
	{
		get
		{
			if (dataLabels_0 == null)
			{
				dataLabels_0 = new DataLabels(this, series_0.NSeries.Chart);
			}
			return dataLabels_0;
		}
	}

	/// <summary>
	///       Gets the legend entry according to this trendline
	///       </summary>
	public LegendEntry LegendEntry
	{
		get
		{
			LegendEntryCollection legendEntries = series_0.NSeries.Chart.Legend.LegendEntries;
			return legendEntries[int_4 + series_0.NSeries.Count];
		}
	}

	internal ShapePropertyCollection ShapeProperties
	{
		get
		{
			if (shapePropertyCollection_0 == null)
			{
				shapePropertyCollection_0 = new ShapePropertyCollection(series_0.method_28().method_0().Chart, this, Enum178.const_6);
			}
			return shapePropertyCollection_0;
		}
	}

	[SpecialName]
	internal Series method_31()
	{
		return series_0;
	}

	internal Trendline(Series series_1, TrendlineType trendlineType_1)
		: base(series_1.NSeries.Chart, series_1)
	{
		trendlineType_0 = trendlineType_1;
		bool_0 = true;
		method_32(series_1);
		series_0 = series_1;
	}

	internal Trendline(Series series_1)
		: base(series_1.NSeries.Chart, series_1)
	{
		bool_0 = true;
		method_32(series_1);
		series_0 = series_1;
	}

	internal Trendline(Series series_1, TrendlineType trendlineType_1, string string_1)
		: base(series_1.NSeries.Chart, series_1)
	{
		trendlineType_0 = trendlineType_1;
		string_0 = string_1;
		method_32(series_1);
		series_0 = series_1;
	}

	private void method_32(Series series_1)
	{
		if (series_1.NSeries.Chart.method_56() == Enum19.const_2)
		{
			base.Weight = WeightType.MediumLine;
		}
		else
		{
			base.WeightPt = 0.75;
		}
	}

	internal void method_33(TrendlineType trendlineType_1)
	{
		trendlineType_0 = trendlineType_1;
	}

	internal void method_34(int int_5)
	{
		int_3 = int_5;
	}

	internal void method_35(double double_3)
	{
		double_1 = double_3;
	}

	internal DataLabels method_36()
	{
		return dataLabels_0;
	}

	[SpecialName]
	internal bool method_37()
	{
		return bool_3;
	}

	[SpecialName]
	internal int method_38()
	{
		return int_4;
	}

	[SpecialName]
	internal void method_39(int int_5)
	{
		int_4 = int_5;
	}

	internal void Copy(Trendline trendline_0)
	{
		Copy((Line)trendline_0);
		if (trendline_0.shapePropertyCollection_0 != null)
		{
			shapePropertyCollection_0 = new ShapePropertyCollection(series_0.method_28().method_0().Chart, this, Enum178.const_6);
			shapePropertyCollection_0.Copy(trendline_0.shapePropertyCollection_0);
		}
	}
}
