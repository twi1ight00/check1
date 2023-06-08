using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns21;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Represents a single point in a series in a chart.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///
///       //Obtaining the reference of the first worksheet
///       Worksheet worksheet = workbook.Worksheets[0];
///
///       //Adding a sample value to "A1" cell
///       worksheet.Cells["A1"].PutValue(50);
///
///       //Adding a sample value to "A2" cell
///       worksheet.Cells["A2"].PutValue(100);
///
///       //Adding a sample value to "A3" cell
///       worksheet.Cells["A3"].PutValue(150);
///
///       //Adding a sample value to "B1" cell
///       worksheet.Cells["B1"].PutValue(60);
///
///       //Adding a sample value to "B2" cell
///       worksheet.Cells["B2"].PutValue(32);
///
///       //Adding a sample value to "B3" cell
///       worksheet.Cells["B3"].PutValue(50);
///
///       //Adding a chart to the worksheet
///       int chartIndex = worksheet.Charts.Add(ChartType.PieExploded, 5, 0, 25, 10);
///
///       //Accessing the instance of the newly added chart
///       Chart chart = worksheet.Charts[chartIndex];
///
///       //Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B3"
///       chart.NSeries.Add("A1:B3", true);
///
///       //Show Data Labels 
///       chart.NSeries[0].DataLabels.IsValueShown = true;
///
///       for (int i = 0; i  &lt; chart.NSeries[0].Points.Count; i++)
///       {
///           //Get Data Point
///           ChartPoint point = chart.NSeries[0].Points[i];
///           //Set Pir Explosion
///           point.Explosion = 15;
///           //Set Border Color
///           point.Border.Color = System.Drawing.Color.Red;
///       }
///
///       //Saving the Excel file
///       workbook.Save("D:\\book1.xls");
///
///       [VB.NET]
///
///       'Instantiating a Workbook object
///       Dim workbook As New Workbook()
///
///       'Obtaining the reference of the first worksheet
///       Dim worksheet As Worksheet = workbook.Worksheets(0)
///
///       'Adding a sample value to "A1" cell
///       worksheet.Cells("A1").PutValue(50)
///
///       'Adding a sample value to "A2" cell
///       worksheet.Cells("A2").PutValue(100)
///
///       'Adding a sample value to "A3" cell
///       worksheet.Cells("A3").PutValue(150)
///
///       'Adding a sample value to "B1" cell
///       worksheet.Cells("B1").PutValue(60)
///
///       'Adding a sample value to "B2" cell
///       worksheet.Cells("B2").PutValue(32)
///
///       'Adding a sample value to "B3" cell
///       worksheet.Cells("B3").PutValue(50)
///
///       'Adding a chart to the worksheet
///       Dim chartIndex As Integer = worksheet.Charts.Add(ChartType.PieExploded, 5, 0, 25, 10)
///
///       'Accessing the instance of the newly added chart
///       Dim chart As Chart = worksheet.Charts(chartIndex)
///
///       'Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B3"
///       chart.NSeries.Add("A1:B3", True)
///
///       'Show Data Labels 
///       chart.NSeries(0).DataLabels.IsValueShown = True
///
///       For i As Integer = 0 To chart.NSeries(0).Points.Count - 1
///           'Get Data Point
///           Dim point As ChartPoint = chart.NSeries(0).Points(i)
///           'Set Pir Explosion
///           point.Explosion = 15
///           'Set Border Color
///           point.Border.Color = System.Drawing.Color.Red
///       Next i
///
///       'Saving the Excel file
///       workbook.Save("D:\book1.xls")
///
///       </code>
/// </example>
public class ChartPoint
{
	private Series series_0;

	private Class1632 class1632_0;

	internal int int_0;

	private DataLabels dataLabels_0;

	private object object_0;

	private object object_1;

	private ShapePropertyCollection shapePropertyCollection_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	/// <summary>
	///       The distance of an open pie slice from the center of the pie chart is expressed as a percentage of the pie diameter.
	///       </summary>
	public int Explosion
	{
		get
		{
			if (class1632_0 != null && method_2().method_6() != null)
			{
				return method_2().method_8().method_0();
			}
			if (series_0 != null)
			{
				return series_0.Explosion;
			}
			return 0;
		}
		set
		{
			if (ChartCollection.smethod_3(method_1()))
			{
				method_2().method_8().method_1(value);
			}
		}
	}

	/// <summary>
	///       True if the chartpoint has a shadow. 
	///       </summary>
	public bool Shadow
	{
		get
		{
			if (class1632_0 == null)
			{
				if (series_0.method_9() != null)
				{
					return series_0.method_7().Shadow;
				}
				return false;
			}
			return method_2().Shadow;
		}
		set
		{
			method_2().Shadow = value;
		}
	}

	/// <summary>
	///       Gets the border <see cref="T:Aspose.Cells.Drawing.Line" />.
	///       </summary>
	public Line Border => method_2().Border;

	/// <summary>
	///       Gets the <see cref="P:Aspose.Cells.Charts.ChartPoint.Area" />.
	///       </summary>
	public Area Area => method_2().Area;

	public Marker Marker
	{
		get
		{
			if (method_7() == null && method_0() != null && method_0().method_30() != null)
			{
				Marker marker = method_2().Marker;
				marker.Copy(method_0().Marker);
			}
			return method_2().Marker;
		}
	}

	/// <summary>
	///       Represents the marker style in a line chart, scatter chart, or radar chart. 
	///       </summary>
	[Browsable(false)]
	[Obsolete("Use Marker.MarkerStyle property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ChartMarkerType MarkerStyle
	{
		get
		{
			return Marker.MarkerStyle;
		}
		set
		{
			Marker.MarkerStyle = value;
		}
	}

	/// <summary>
	///       Represents the marker size in a line chart, scatter chart, or radar chart. 
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Marker.MarkerSize property instead.")]
	[Browsable(false)]
	public int MarkerSize
	{
		get
		{
			return Marker.MarkerSize;
		}
		set
		{
			if (value >= 2 && value <= 72)
			{
				Marker.MarkerSize = value;
			}
		}
	}

	/// <summary>
	///       Represents the marker foregournd color in a line chart, scatter chart, or radar chart. 
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Marker.Border.Color property instead.")]
	public Color MarkerForegroundColor
	{
		get
		{
			return Marker.MarkerForegroundColor;
		}
		set
		{
			Marker.MarkerForegroundColor = value;
		}
	}

	/// <summary>
	///       Gets or sets the marker foreground color set type.
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Marker.Border.Formatting property instead.")]
	[Browsable(false)]
	public FormattingType MarkerForegroundColorSetType
	{
		get
		{
			return Marker.MarkerForegroundColorSetType;
		}
		set
		{
			Marker.MarkerForegroundColorSetType = value;
		}
	}

	/// <summary>
	///       Represents the marker backgournd color in a line chart, scatter chart, or radar chart. 
	///       </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Marker.Area.ForegroundColor property instead.")]
	public Color MarkerBackgroundColor
	{
		get
		{
			return Marker.MarkerBackgroundColor;
		}
		set
		{
			Marker.MarkerBackgroundColor = value;
		}
	}

	/// <summary>
	///       Gets or sets the marker background color set type.
	///       </summary>
	[Obsolete("Use Marker.Area.Formatting property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public FormattingType MarkerBackgroundColorSetType
	{
		get
		{
			return Marker.MarkerBackgroundColorSetType;
		}
		set
		{
			Marker.MarkerBackgroundColorSetType = value;
		}
	}

	/// <summary>
	///       Returns a DataLabels object that represents the data label associated with the point.
	///       </summary>
	public DataLabels DataLabels
	{
		get
		{
			if (dataLabels_0 == null)
			{
				dataLabels_0 = new DataLabels(this, series_0.NSeries.Chart);
				if (series_0.method_24() != null)
				{
					dataLabels_0.Copy(series_0.DataLabels);
					dataLabels_0.bool_14 = false;
				}
			}
			return dataLabels_0;
		}
	}

	public object YValue
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	public object XValue
	{
		get
		{
			return object_1;
		}
		set
		{
			object_1 = value;
		}
	}

	public ShapePropertyCollection ShapeProperties
	{
		get
		{
			if (shapePropertyCollection_0 == null)
			{
				shapePropertyCollection_0 = new ShapePropertyCollection(method_0().method_28().method_0().Chart, this, Enum178.const_5);
			}
			return shapePropertyCollection_0;
		}
	}

	public int ShapeX => int_1;

	public int ShapeY => int_2;

	public int ShapeWidth => int_3;

	public int ShapeHeight => int_4;

	internal bool IsAuto
	{
		get
		{
			if (class1632_0 == null)
			{
				return true;
			}
			return class1632_0.IsAuto;
		}
	}

	internal ChartPoint(Series series_1, int int_5)
	{
		series_0 = series_1;
		int_0 = int_5;
	}

	[SpecialName]
	internal Series method_0()
	{
		return series_0;
	}

	[SpecialName]
	internal ChartType method_1()
	{
		return series_0.Type;
	}

	[SpecialName]
	internal Class1632 method_2()
	{
		if (class1632_0 == null)
		{
			class1632_0 = new Class1632(series_0);
			if (series_0.method_9() != null)
			{
				class1632_0.Copy(series_0.method_7());
			}
			else if (series_0.method_28().method_5() != null)
			{
				class1632_0.Copy(series_0.method_28().method_3());
			}
		}
		return class1632_0;
	}

	[SpecialName]
	internal void method_3(Class1632 class1632_1)
	{
		class1632_0 = class1632_1;
	}

	[SpecialName]
	internal bool method_4()
	{
		if (class1632_0 != null && method_2().method_6() != null)
		{
			return false;
		}
		if (series_0 != null)
		{
			return series_0.method_34();
		}
		return true;
	}

	internal Line method_5()
	{
		if (class1632_0 == null)
		{
			return null;
		}
		return method_2().method_4();
	}

	internal Area method_6()
	{
		if (class1632_0 == null)
		{
			return null;
		}
		return method_2().method_5();
	}

	internal Marker method_7()
	{
		if (class1632_0 == null)
		{
			return null;
		}
		return method_2().method_7();
	}

	internal Class1633 method_8()
	{
		if (class1632_0 == null)
		{
			return null;
		}
		return method_2().method_6();
	}

	internal DataLabels method_9()
	{
		return dataLabels_0;
	}

	internal void Copy(ChartPoint chartPoint_0)
	{
		int_0 = chartPoint_0.int_0;
		if (chartPoint_0.class1632_0 != null)
		{
			class1632_0 = new Class1632(series_0);
			class1632_0.Copy(chartPoint_0.class1632_0);
		}
		if (chartPoint_0.dataLabels_0 != null)
		{
			dataLabels_0 = new DataLabels(this, series_0.NSeries.Chart);
			dataLabels_0.Copy(chartPoint_0.dataLabels_0);
		}
		if (chartPoint_0.shapePropertyCollection_0 != null)
		{
			shapePropertyCollection_0 = new ShapePropertyCollection(method_0().method_28().method_0().Chart, this, Enum178.const_5);
			shapePropertyCollection_0.Copy(chartPoint_0.shapePropertyCollection_0);
		}
	}

	internal void method_10(int int_5, int int_6)
	{
		int_1 = int_5;
		int_2 = int_6;
	}

	internal void method_11(int int_5, int int_6)
	{
		int_3 = int_5;
		int_4 = int_6;
	}
}
