using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns16;
using ns21;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Encapsulates the object that represents a single data series in a chart.
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
///       Series series = chart.NSeries[1];
///       //Setting the values of the series.
///       series.Values = "=B1:B4";
///       //Changing the chart type of the series.
///       series.Type = ChartType.Line;
///       //Setting marker properties.
///       series.MarkerStyle = ChartMarkerType.Circle;
///       series.MarkerForegroundColorSetType = FormattingType.Automatic;
///       series.MarkerForegroundColor = System.Drawing.Color.Black;
///       series.MarkerBackgroundColorSetType = FormattingType.Automatic;
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
///       chart.NSeries.CategoryData = "C1:C4"
///       Dim series As Series = chart.NSeries(1)
///       'Setting the values of the series.
///       series.Values = "=B1:B4"
///       'Changing the chart type of the series.
///       series.Type = ChartType.Line
///       'Setting marker properties.
///       series.MarkerStyle = ChartMarkerType.Circle
///       series.MarkerForegroundColorSetType = FormattingType.Automatic
///       series.MarkerForegroundColor = System.Drawing.Color.Black
///       series.MarkerBackgroundColorSetType = FormattingType.Automatic
///       'Saving the Excel file
///       workbook.Save("C:\\book1.xls")
///       </code>
/// </example>
public class Series
{
	private int int_0;

	private ChartPointCollection chartPointCollection_0;

	private Class1632 class1632_0;

	internal Class929 class929_0;

	private int int_1 = -1;

	private SeriesCollection seriesCollection_0;

	private object object_0;

	internal string string_0;

	private string string_1 = "";

	private Interface45 interface45_0;

	private Interface45 interface45_1;

	private Interface45 interface45_2;

	private TrendlineCollection trendlineCollection_0;

	internal int int_2;

	private DataLabels dataLabels_0;

	private Class1387 class1387_0;

	private bool bool_0;

	private ErrorBar errorBar_0;

	private ErrorBar errorBar_1;

	private bool bool_1 = true;

	private bool bool_2;

	internal int int_3 = -1;

	private Line line_0;

	private ShapePropertyCollection shapePropertyCollection_0;

	private ShapePropertyCollection shapePropertyCollection_1;

	/// <summary>
	///       Gets the collection of points in a series in a chart.
	///       </summary>
	public ChartPointCollection Points
	{
		get
		{
			if (chartPointCollection_0 == null)
			{
				chartPointCollection_0 = new ChartPointCollection(this);
			}
			return chartPointCollection_0;
		}
	}

	/// <summary>
	///       Represents the background area of ASeries object.
	///       </summary>
	public Area Area => method_7().Area;

	/// <summary>
	///       Represents the line or border of ASeries object.
	///       </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Series.Border property instead.")]
	public Line Line => method_7().Border;

	public Line Border => method_7().Border;

	/// <summary>
	///       Gets or sets the name of the data series.
	///       </summary>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       //Reference name to a cell
	///       chart.NSeries[0].Name = "=A1";
	///
	///       //Set a string to name
	///       chart.NSeries[0].Name = "First Series";
	///       [Visual Basic]
	///
	///       'Reference name to a cell
	///       chart.NSeries[0].Name = "=A1"
	///
	///       'Set a string to name
	///       chart.NSeries[0].Name = "First Series"
	///       </code>
	/// </example>
	public string Name
	{
		get
		{
			if (object_0 == null)
			{
				return "";
			}
			if (object_0 is string)
			{
				return (string)object_0;
			}
			if (object_0 is byte[])
			{
				byte[] byte_ = (byte[])object_0;
				return method_10().method_4().method_4(-1, -1, byte_, 0, 0, bool_0: false);
			}
			return "";
		}
		set
		{
			string_0 = null;
			if (value == null)
			{
				object_0 = null;
				return;
			}
			string text = value.Trim();
			if (text == "")
			{
				object_0 = "";
				string_0 = "";
			}
			else if (text[0] != '=')
			{
				object_0 = text;
			}
			else
			{
				text = text.Substring(1);
				Interface45 @interface = Class1195.smethod_1(method_10(), method_11(), text);
				object_0 = @interface.imethod_4();
			}
		}
	}

	public string DisplayName => string_1;

	/// <summary>
	///       Gets the number of the data values.
	///       </summary>
	public int CountOfDataValues
	{
		get
		{
			if (interface45_0 == null)
			{
				return 0;
			}
			return interface45_0.imethod_11();
		}
	}

	public bool IsVerticalValues => interface45_0.StartRow != interface45_0.EndRow;

	/// <summary>
	///       Represents the data of the chart series.
	///       </summary>
	public string Values
	{
		get
		{
			if (interface45_0 == null)
			{
				return null;
			}
			return interface45_0.Values;
		}
		set
		{
			string text = method_15(value);
			if (text != null && !(text == ""))
			{
				interface45_0 = Class1195.smethod_1(method_10(), method_11(), text);
				bool_0 = true;
				if (chartPointCollection_0 != null)
				{
					chartPointCollection_0.method_8();
				}
			}
			else
			{
				interface45_0 = null;
			}
		}
	}

	/// <summary>
	///       Represents the x values of the chart series.
	///       </summary>
	public string XValues
	{
		get
		{
			if (interface45_1 == null)
			{
				return null;
			}
			return interface45_1.Values;
		}
		set
		{
			string text = method_15(value);
			if (text != null && !(text == ""))
			{
				interface45_1 = Class1195.smethod_1(method_10(), method_11(), text);
			}
			else
			{
				interface45_1 = null;
			}
		}
	}

	/// <summary>
	///       Gets or sets the bubble sizes values of the chart series.
	///       </summary>
	public string BubbleSizes
	{
		get
		{
			if (interface45_2 == null)
			{
				return null;
			}
			return interface45_2.Values;
		}
		set
		{
			string text = method_15(value);
			if (text != null && !(text == ""))
			{
				interface45_2 = Class1195.smethod_1(method_10(), method_11(), text);
			}
			else
			{
				interface45_2 = null;
			}
		}
	}

	/// <summary>
	///       Returns an object that represents a collection of all the trendlines for the series.
	///       </summary>
	public TrendlineCollection TrendLines
	{
		get
		{
			if (trendlineCollection_0 == null)
			{
				trendlineCollection_0 = new TrendlineCollection(this);
			}
			return trendlineCollection_0;
		}
	}

	/// <summary>
	///       Represents curve smoothing. 
	///       True if curve smoothing is turned on for the line chart or scatter chart.
	///       Applies only to line and scatter connected by lines charts.
	///       </summary>
	public bool Smooth
	{
		get
		{
			if (class1632_0 != null && class1632_0.method_9())
			{
				return method_7().Smooth;
			}
			if (class1387_0.method_5() != null)
			{
				return class1387_0.method_3().Smooth;
			}
			return false;
		}
		set
		{
			method_7().Smooth = value;
		}
	}

	/// <summary>
	///       True if the series has a shadow. 
	///       </summary>
	public bool Shadow
	{
		get
		{
			if (class1632_0 == null)
			{
				return false;
			}
			return method_7().Shadow;
		}
		set
		{
			method_7().Shadow = value;
		}
	}

	/// <summary>
	///       True if the series has a three-dimensional appearance. 
	///       Applies only to bubble charts.
	///       </summary>
	public bool Has3DEffect
	{
		get
		{
			if (ChartCollection.smethod_17(Type))
			{
				if (class1632_0 != null && class1632_0.method_13())
				{
					return method_7().method_11();
				}
				if (class1387_0.method_3() != null)
				{
					return class1387_0.method_3().method_11();
				}
			}
			return false;
		}
		set
		{
			if (ChartCollection.smethod_17(Type))
			{
				method_7().method_12(value);
			}
		}
	}

	/// <summary>
	///       Gets or sets the 3D shape type used with the 3-D bar or column chart.
	///       </summary>
	public Bar3DShapeType Bar3DShapeType
	{
		get
		{
			if (!ChartCollection.smethod_0(Type))
			{
				return Bar3DShapeType.Box;
			}
			if (class1632_0 == null)
			{
				if (class1387_0.method_3() == null)
				{
					return Bar3DShapeType.Box;
				}
				return class1387_0.method_3().BarShape;
			}
			return method_7().BarShape;
		}
		set
		{
			if (ChartCollection.smethod_0(Type))
			{
				method_7().BarShape = value;
			}
		}
	}

	/// <summary>
	///       Gets or sets the 3D shape type used with the 3-D bar or column chart.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use ASeries.Bar3DShapeType property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Series.Bar3DShapeType property instead.")]
	[Browsable(false)]
	public Bar3DShapeType BarShape
	{
		get
		{
			return Bar3DShapeType;
		}
		set
		{
			Bar3DShapeType = value;
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
				dataLabels_0 = new DataLabels(this, NSeries.Chart);
			}
			return dataLabels_0;
		}
	}

	/// <summary>
	///       Gets or sets a data series' type.
	///       </summary>
	public ChartType Type
	{
		get
		{
			return class1387_0.method_11();
		}
		set
		{
			if (class1387_0.method_11() == value)
			{
				return;
			}
			Chart chart = seriesCollection_0.Chart;
			if (seriesCollection_0.Count == 1)
			{
				chart.Type = value;
				return;
			}
			if (ChartCollection.smethod_0(value))
			{
				chart.Type = value;
				return;
			}
			if (ChartCollection.smethod_0(chart.Type))
			{
				chart.Type = value;
				return;
			}
			if (ChartCollection.smethod_18(value))
			{
				throw new CellsException(ExceptionType.Chart, "Some chart types could not be combined with other chart types.");
			}
			if (ChartCollection.smethod_11(value) && ChartCollection.smethod_11(class1387_0.method_11()))
			{
				switch (value)
				{
				case ChartType.Scatter:
					Line.IsVisible = false;
					MarkerStyle = ChartMarkerType.None;
					break;
				case ChartType.ScatterConnectedByCurvesWithDataMarker:
					Line.IsVisible = true;
					Smooth = true;
					MarkerStyle = ChartMarkerType.Automatic;
					break;
				case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
					Line.IsVisible = true;
					Smooth = true;
					MarkerStyle = ChartMarkerType.None;
					break;
				case ChartType.ScatterConnectedByLinesWithDataMarker:
					Line.IsVisible = true;
					Smooth = false;
					MarkerStyle = ChartMarkerType.None;
					break;
				case ChartType.ScatterConnectedByLinesWithoutDataMarker:
					Line.IsVisible = true;
					Smooth = false;
					MarkerStyle = ChartMarkerType.None;
					break;
				}
				return;
			}
			if (ChartCollection.smethod_14(value))
			{
				switch (value)
				{
				case ChartType.Line:
					if (class1387_0.method_11() == ChartType.LineWithDataMarkers)
					{
						MarkerStyle = ChartMarkerType.None;
						return;
					}
					break;
				case ChartType.LineStacked:
					if (class1387_0.method_11() == ChartType.LineStackedWithDataMarkers)
					{
						MarkerStyle = ChartMarkerType.None;
						return;
					}
					break;
				case ChartType.Line100PercentStacked:
					if (class1387_0.method_11() == ChartType.Line100PercentStackedWithDataMarkers)
					{
						MarkerStyle = ChartMarkerType.None;
						return;
					}
					break;
				case ChartType.LineWithDataMarkers:
					if (class1387_0.method_11() == ChartType.Line)
					{
						MarkerStyle = ChartMarkerType.Automatic;
						return;
					}
					break;
				case ChartType.LineStackedWithDataMarkers:
					if (class1387_0.method_11() == ChartType.LineStacked)
					{
						MarkerStyle = ChartMarkerType.Automatic;
						return;
					}
					break;
				case ChartType.Line100PercentStackedWithDataMarkers:
					if (class1387_0.method_11() == ChartType.Line100PercentStacked)
					{
						MarkerStyle = ChartMarkerType.Automatic;
						return;
					}
					break;
				}
			}
			if (ChartCollection.smethod_15(class1387_0.method_11()))
			{
				switch (value)
				{
				case ChartType.Radar:
					switch (class1387_0.method_11())
					{
					case ChartType.RadarWithDataMarkers:
						Area.Formatting = FormattingType.None;
						MarkerStyle = ChartMarkerType.None;
						return;
					case ChartType.RadarFilled:
						class1387_0.method_12(value);
						return;
					}
					break;
				case ChartType.RadarWithDataMarkers:
					switch (class1387_0.method_11())
					{
					case ChartType.RadarWithDataMarkers:
						Area.Formatting = FormattingType.None;
						MarkerStyle = ChartMarkerType.Automatic;
						return;
					case ChartType.RadarFilled:
						class1387_0.method_12(value);
						return;
					}
					break;
				case ChartType.RadarFilled:
					class1387_0.method_12(value);
					break;
				}
			}
			Class1387 @class = class1387_0;
			bool flag = @class.method_14() == 1;
			bool flag2 = @class.PlotOnSecondAxis;
			method_4();
			if (!ChartCollection.smethod_2(@class.method_11(), value))
			{
				if (@class.PlotOnSecondAxis)
				{
					throw new CellsException(ExceptionType.Chart, "Some chart types could not be combined with other chart types.");
				}
				flag2 = true;
				if (!chart.class1388_0.method_1())
				{
					if (flag)
					{
						class1387_0.method_12(value);
						method_28().PlotOnSecondAxis = true;
					}
					else
					{
						_ = class1387_0.Index;
						class1387_0 = new Class1387(chart.class1388_0, value, bool_11: true);
						chart.class1388_0.Add(class1387_0);
					}
					return;
				}
				if (!ChartCollection.smethod_2(chart.class1388_0.method_2(bool_0: true).method_11(), value))
				{
					throw new CellsException(ExceptionType.Chart, "Some chart types could not be combined with other chart types.");
				}
			}
			if (flag)
			{
				chart.class1388_0.Remove(class1387_0);
			}
			foreach (Class1387 item in chart.class1388_0)
			{
				if (item.PlotOnSecondAxis == flag2)
				{
					if (item.method_11() == value)
					{
						class1387_0 = item;
						return;
					}
					if (ChartCollection.smethod_1(item.method_11(), value))
					{
						class1387_0 = item;
						item.method_12(value);
						return;
					}
				}
			}
			class1387_0 = new Class1387(chart.class1388_0, value, flag2);
			chart.class1388_0.Add(class1387_0);
		}
	}

	public Marker Marker => method_7().Marker;

	/// <summary>
	///       Represents the marker style in a line chart, scatter chart, or radar chart. 
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Marker.MarkerStyle property instead.")]
	[Browsable(false)]
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
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Marker.MarkerSize property instead.")]
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
	///       Represents the marker foreground color in a line chart, scatter chart, or radar chart. 
	///       </summary>
	[Obsolete("Use Marker.Border.Color property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
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
	///       Represents the marker background color in a line chart, scatter chart, or radar chart. 
	///       </summary>
	[Obsolete("Use Marker.Area.ForegroundColor property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
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
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Marker.Area.Formatting property instead.")]
	[Browsable(false)]
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
	///       Indicates if this series is plotted on second value axis.
	///       </summary>
	public bool PlotOnSecondAxis
	{
		get
		{
			return class1387_0.PlotOnSecondAxis;
		}
		set
		{
			if (class1387_0.PlotOnSecondAxis == value)
			{
				return;
			}
			if (ChartCollection.smethod_0(class1387_0.method_11()))
			{
				throw new CellsException(ExceptionType.Chart, "If the chart type is 3-D chart type, you could not plot the series to the second axis ");
			}
			if (!class1387_0.PlotOnSecondAxis && seriesCollection_0.method_9(bool_0: false) <= 1)
			{
				throw new CellsException(ExceptionType.Chart, "If there is only a series on the primary axis, you could not plot the series to the second axis ");
			}
			Chart chart = seriesCollection_0.Chart;
			if (class1387_0.method_14() == 1)
			{
				chart.class1388_0.Remove(class1387_0);
			}
			Class1387 @class = chart.class1388_0.method_2(value);
			if (@class == null)
			{
				Class1387 class2 = new Class1387(chart.class1388_0);
				class2.Copy(class1387_0);
				class2.PlotOnSecondAxis = value;
				class1387_0 = class2;
				chart.class1388_0.Add(class2);
				if (value && !chart.CategoryAxis.IsPlotOrderReversed && !chart.SecondCategoryAxis.IsPlotOrderReversed && chart.SecondValueAxis.CrossType == CrossType.Automatic)
				{
					chart.SecondCategoryAxis.CrossType = CrossType.Maximum;
				}
				return;
			}
			if (!ChartCollection.smethod_2(@class.method_11(), class1387_0.method_11()))
			{
				throw new CellsException(ExceptionType.Chart, "Some chart types could not be combined with other chart types");
			}
			foreach (Class1387 item in chart.class1388_0)
			{
				if (item.PlotOnSecondAxis == value)
				{
					if (item.method_11() == class1387_0.method_11())
					{
						class1387_0 = item;
						return;
					}
					if (ChartCollection.smethod_1(item.method_11(), class1387_0.method_11()))
					{
						item.method_12(class1387_0.method_11());
						class1387_0 = item;
						return;
					}
				}
			}
			Class1387 class4 = new Class1387(chart.class1388_0);
			class4.Copy(class1387_0);
			class4.PlotOnSecondAxis = value;
			class1387_0 = class4;
			chart.class1388_0.Add(class4);
		}
	}

	/// <summary>
	///       Represents X direction error bar of the series.
	///       </summary>
	public ErrorBar XErrorBar
	{
		get
		{
			if (errorBar_0 == null)
			{
				errorBar_0 = new ErrorBar(this, bool_2: false);
			}
			return errorBar_0;
		}
	}

	/// <summary>
	///       Represents Y direction error bar of the series.
	///       </summary>
	public ErrorBar YErrorBar
	{
		get
		{
			if (errorBar_1 == null)
			{
				errorBar_1 = new ErrorBar(this, bool_2: true);
			}
			return errorBar_1;
		}
	}

	/// <summary>
	///       True if the line chart has high-low lines. 
	///        Applies only to line charts.
	///        </summary>
	public bool HasHiLoLines
	{
		get
		{
			return class1387_0.HasHiLoLines;
		}
		set
		{
			class1387_0.HasHiLoLines = value;
		}
	}

	/// <summary>
	///       Returns a HiLoLines object that represents the high-low lines for a series on a line chart. 
	///       Applies only to line charts.
	///        </summary>
	public Line HiLoLines => class1387_0.HiLoLines;

	/// <summary>
	///       True if a stacked column chart or bar chart has series lines or
	///       if a Pie of Pie chart or Bar of Pie chart has connector lines between the two sections. 
	///       Applies only to stacked column charts, bar charts, Pie of Pie charts, or Bar of Pie charts.
	///       </summary>
	public bool HasSeriesLines
	{
		get
		{
			return class1387_0.HasSeriesLines;
		}
		set
		{
			class1387_0.HasSeriesLines = value;
		}
	}

	/// <summary>
	///       Returns a SeriesLines object that represents the series lines for a stacked bar chart or a stacked column chart.
	///       Applies only to stacked bar and stacked column charts.
	///       </summary>
	public Line SeriesLines => class1387_0.SeriesLines;

	/// <summary>
	///       True if the chart has drop lines.
	///       Applies only to line chart or area charts.
	///       </summary>
	public bool HasDropLines
	{
		get
		{
			return class1387_0.HasDropLines;
		}
		set
		{
			class1387_0.HasDropLines = value;
		}
	}

	/// <summary>
	///       Returns a <see cref="P:Aspose.Cells.Charts.Series.Line" /> object that represents the drop lines for a series on the line chart or area chart.
	///       Applies only to line chart or area charts.
	///       </summary>
	public Line DropLines => class1387_0.DropLines;

	/// <summary>
	///       True if a line chart has up and down bars.
	///       Applies only to line charts.
	///       </summary>
	public bool HasUpDownBars
	{
		get
		{
			return class1387_0.HasUpDownBars;
		}
		set
		{
			class1387_0.HasUpDownBars = value;
		}
	}

	/// <summary>
	///       Returns an DropBars object that represents the up bars on a line chart.
	///       Applies only to line charts.
	///       </summary>
	public DropBars UpBars => class1387_0.UpBars;

	/// <summary>
	///       Returns a <see cref="T:Aspose.Cells.Charts.DropBars" /> object that represents the down bars on a line chart.
	///       Applies only to line charts.
	///       </summary>
	public DropBars DownBars => class1387_0.DownBars;

	/// <summary>
	///       Represents if the color of points is varied. 
	///       The chart must contain only one series.
	///       </summary>
	public bool IsColorVaried
	{
		get
		{
			return class1387_0.IsColorVaried;
		}
		set
		{
			class1387_0.IsColorVaried = value;
		}
	}

	/// <summary>
	///       Returns or sets the space between bar or column clusters, as a percentage of the bar or column width.
	///       The value of this property must be between 0 and 500.
	///       </summary>
	public short GapWidth
	{
		get
		{
			return (short)class1387_0.GapWidth;
		}
		set
		{
			class1387_0.GapWidth = value;
		}
	}

	/// <summary>
	///       Gets or sets the angle of the first pie-chart or doughnut-chart slice, in degrees (clockwise from vertical). 
	///       Applies only to pie, 3-D pie, and doughnut charts, 0 to 360. 
	///       </summary>
	public short FirstSliceAngle
	{
		get
		{
			return (short)class1387_0.FirstSliceAngle;
		}
		set
		{
			class1387_0.FirstSliceAngle = value;
		}
	}

	/// <summary>
	///       Specifies how bars and columns are positioned.
	///       Can be a value between – 100 and 100. 
	///       Applies only to 2-D bar and 2-D column charts. 
	///       </summary>
	public short Overlap
	{
		get
		{
			return (short)class1387_0.Overlap;
		}
		set
		{
			class1387_0.Overlap = value;
		}
	}

	/// <summary>
	///       Returns or sets the size of the secondary section of either a pie of pie chart or a bar of pie chart, 
	///       as a percentage of the size of the primary pie.
	///       Can be a value from 5 to 200. 
	///       </summary>
	public short SecondPlotSize
	{
		get
		{
			return (short)class1387_0.SecondPlotSize;
		}
		set
		{
			class1387_0.SecondPlotSize = value;
		}
	}

	/// <summary>
	///       Gets or sets the way the two sections of either a pie of pie chart or a bar of pie chart are split.
	///       </summary>
	public ChartSplitType SplitType
	{
		get
		{
			return class1387_0.SplitType;
		}
		set
		{
			class1387_0.SplitType = value;
			class1387_0.method_21(bool_11: false);
		}
	}

	/// <summary>
	///       Returns or sets the threshold value separating the two sections of either a pie of pie chart or a bar of pie chart.
	///       </summary>
	public double SplitValue
	{
		get
		{
			return class1387_0.SplitValue;
		}
		set
		{
			class1387_0.SplitValue = value;
		}
	}

	/// <summary>
	///       Indicates whether the threshold value is automatic.
	///       </summary>
	public bool IsAutoSplit => class1387_0.IsAutoSplit;

	/// <summary>
	///       Gets or sets the scale factor for bubbles in the specified chart group. 
	///       It can be an integer value from 0 (zero) to 300, 
	///       corresponding to a percentage of the default size.
	///       Applies only to bubble charts. 
	///       </summary>
	public int BubbleScale
	{
		get
		{
			return class1387_0.BubbleScale;
		}
		set
		{
			class1387_0.BubbleScale = value;
		}
	}

	/// <summary>
	///       Gets or sets what the bubble size represents on a bubble chart.
	///       </summary>
	/// <remarks>
	///       BubbleSizeRepresents.SizeIsArea means the value <see cref="P:Aspose.Cells.Charts.Series.BubbleSizes" /> is the area of the bubble.
	///       BubbleSizeRepresents.SizeIsWidth means the value <see cref="P:Aspose.Cells.Charts.Series.BubbleSizes" /> is the width of the bubble.
	///       </remarks>
	public BubbleSizeRepresents SizeRepresents
	{
		get
		{
			return class1387_0.SizeRepresents;
		}
		set
		{
			class1387_0.SizeRepresents = value;
		}
	}

	/// <summary>
	///       True if negative bubbles are shown for the chart group. Valid only for bubble charts. 
	///       </summary>
	public bool ShowNegativeBubbles
	{
		get
		{
			return class1387_0.ShowNegativeBubbles;
		}
		set
		{
			class1387_0.ShowNegativeBubbles = value;
		}
	}

	/// <summary>
	///       Returns or sets the size of the hole in a doughnut chart group. 
	///       The hole size is expressed as a percentage of the chart size, between 10 and 90 percent.
	///       </summary>
	public int DoughnutHoleSize
	{
		get
		{
			return class1387_0.DoughnutHoleSize;
		}
		set
		{
			class1387_0.DoughnutHoleSize = value;
		}
	}

	/// <summary>
	///       The distance of an open pie slice from the center of the pie chart is expressed as a percentage of the pie diameter.
	///       </summary>
	public int Explosion
	{
		get
		{
			if (class1632_0 != null && class1632_0.method_6() != null)
			{
				return class1632_0.method_6().method_0();
			}
			if (class1387_0.method_5() != null && class1387_0.method_3().method_6() != null)
			{
				return class1387_0.method_3().method_8().method_0();
			}
			return 0;
		}
		set
		{
			if (ChartCollection.smethod_3(class1387_0.method_11()) || ChartCollection.smethod_13(class1387_0.method_11()))
			{
				method_7().method_8().method_1(value);
			}
		}
	}

	/// <summary>
	///       True if a radar chart has category axis labels. Applies only to radar charts.
	///       </summary>
	public bool HasRadarAxisLabels
	{
		get
		{
			return class1387_0.HasRadarAxisLabels;
		}
		set
		{
			class1387_0.HasRadarAxisLabels = value;
		}
	}

	/// <summary>
	///       True if the series has leader lines.
	///       </summary>
	public bool HasLeaderLines
	{
		get
		{
			return class1387_0.HasLeaderLines;
		}
		set
		{
			class1387_0.HasLeaderLines = value;
		}
	}

	/// <summary>
	///       Represents leader lines on a chart. Leader lines connect data labels to data points. 
	///       This object isn’t a collection; there’s no object that represents a single leader line.
	///       </summary>
	public Line LeaderLines => class1387_0.LeaderLines;

	/// <summary>
	///       Gets the legend entry according to this series.
	///       </summary>
	public LegendEntry LegendEntry
	{
		get
		{
			LegendEntryCollection legendEntries = NSeries.Chart.Legend.LegendEntries;
			return legendEntries[Index];
		}
	}

	/// <summary>
	///       Gets the <seealso cref="P:Aspose.Cells.Charts.Series.ShapeProperties" /> object that holds the visual shape properties of the ASeries.
	///       </summary>
	public ShapePropertyCollection ShapeProperties
	{
		get
		{
			if (shapePropertyCollection_1 == null)
			{
				shapePropertyCollection_1 = new ShapePropertyCollection(seriesCollection_0.Chart, this, Enum178.const_8);
			}
			return shapePropertyCollection_1;
		}
	}

	internal SeriesCollection NSeries => seriesCollection_0;

	internal bool IsVisible
	{
		get
		{
			if (seriesCollection_0.Chart.PlotVisibleCells)
			{
				if (interface45_0 == null)
				{
					return false;
				}
				return interface45_0.IsVisible;
			}
			return true;
		}
	}

	internal int Index
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < NSeries.Count)
				{
					if (seriesCollection_0[num] == this)
					{
						break;
					}
					num++;
					continue;
				}
				return 0;
			}
			return num;
		}
	}

	[SpecialName]
	internal int method_0()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_1(int int_4)
	{
		int_0 = int_4;
	}

	[SpecialName]
	internal void method_2(int int_4)
	{
		int_1 = int_4;
	}

	/// <summary>
	///       Moves the series up or down.
	///       </summary>
	/// <param name="count">The number of moving up or down.
	///       Move the series up if this is less than zero;
	///       Move the series down if this is greater than zero.
	///       </param>
	public void Move(int count)
	{
		if (count < 0)
		{
			int index = Index;
			int num = Index + count;
			if (num < 0)
			{
				num = 0;
			}
			seriesCollection_0.method_5(index, num);
		}
		else
		{
			int index2 = Index;
			int num2 = index2 + count + 1;
			if (num2 >= seriesCollection_0.Count)
			{
				num2 = seriesCollection_0.Count - 1;
			}
			seriesCollection_0.method_6(index2, num2);
		}
	}

	internal ChartPointCollection method_3()
	{
		return chartPointCollection_0;
	}

	internal void method_4()
	{
		chartPointCollection_0 = null;
	}

	internal Area method_5()
	{
		if (class1632_0 == null)
		{
			return null;
		}
		return class1632_0.method_5();
	}

	internal Line method_6()
	{
		if (class1632_0 == null)
		{
			return null;
		}
		return class1632_0.method_4();
	}

	[SpecialName]
	internal Class1632 method_7()
	{
		if (class1632_0 == null)
		{
			class1632_0 = new Class1632(this);
			if (class1387_0.method_3() != null)
			{
				class1632_0.Copy(class1387_0.method_3());
			}
		}
		return class1632_0;
	}

	[SpecialName]
	internal void method_8(Class1632 class1632_1)
	{
		class1632_0 = class1632_1;
	}

	internal Class1632 method_9()
	{
		return class1632_0;
	}

	internal Series(WorksheetCollection worksheetCollection_0, SeriesCollection seriesCollection_1, int int_4)
	{
		int_0 = int_4;
		seriesCollection_0 = seriesCollection_1;
		class929_0 = new Class929();
	}

	[SpecialName]
	internal WorksheetCollection method_10()
	{
		return seriesCollection_0.method_1();
	}

	[SpecialName]
	internal Worksheet method_11()
	{
		return seriesCollection_0.method_0();
	}

	internal void method_12(object object_1)
	{
		object_0 = object_1;
	}

	internal object method_13()
	{
		return object_0;
	}

	internal void method_14(string string_2)
	{
		string_1 = string_2;
	}

	private string method_15(string string_2)
	{
		if (string_2 == null)
		{
			return null;
		}
		string_2 = string_2.Trim();
		if (string_2 != null && !(string_2 == ""))
		{
			if (string_2[0] == '=')
			{
				string_2 = string_2.Substring(1);
			}
			if (string_2 != null && !(string_2 == ""))
			{
				return string_2;
			}
			return null;
		}
		return null;
	}

	[SpecialName]
	internal Interface45 method_16()
	{
		return interface45_0;
	}

	[SpecialName]
	internal void method_17(Interface45 interface45_3)
	{
		interface45_0 = interface45_3;
	}

	[SpecialName]
	internal Interface45 method_18()
	{
		return interface45_1;
	}

	[SpecialName]
	internal void method_19(Interface45 interface45_3)
	{
		interface45_1 = interface45_3;
	}

	[SpecialName]
	internal Interface45 method_20()
	{
		return interface45_2;
	}

	[SpecialName]
	internal void method_21(Interface45 interface45_3)
	{
		interface45_2 = interface45_3;
	}

	internal TrendlineCollection method_22()
	{
		return trendlineCollection_0;
	}

	internal void method_23(Bar3DShapeType bar3DShapeType_0)
	{
		method_7().method_2(bar3DShapeType_0);
	}

	internal void Copy(Series series_0, CopyOptions copyOptions_0)
	{
		method_29(seriesCollection_0.Chart.class1388_0[series_0.method_28().Index]);
		if (series_0.class1632_0 != null)
		{
			class1632_0 = new Class1632(this);
			class1632_0.Copy(series_0.class1632_0);
		}
		if (series_0.errorBar_0 != null)
		{
			XErrorBar.Copy(series_0.XErrorBar);
		}
		if (series_0.errorBar_1 != null)
		{
			YErrorBar.Copy(series_0.YErrorBar);
		}
		if (series_0.object_0 != null)
		{
			string_0 = series_0.string_0;
			if (series_0.object_0 is string)
			{
				object_0 = series_0.object_0;
			}
			else if (series_0.object_0 is byte[])
			{
				Interface45 @interface = Class1195.smethod_0(series_0.method_10(), series_0.method_11());
				@interface.imethod_5((byte[])series_0.object_0);
				Interface45 interface2 = Class1195.smethod_0(method_10(), method_11());
				interface2.Copy(@interface, series_0.method_11().SheetIndex, copyOptions_0);
				object_0 = interface2.imethod_4();
			}
		}
		if (series_0.interface45_0 != null)
		{
			interface45_0 = Class1195.smethod_0(method_10(), method_11());
			interface45_0.Copy(series_0.interface45_0, method_11().SheetIndex, copyOptions_0);
		}
		if (series_0.interface45_1 != null)
		{
			interface45_1 = Class1195.smethod_0(method_10(), method_11());
			interface45_1.Copy(series_0.interface45_1, method_11().SheetIndex, copyOptions_0);
		}
		if (series_0.interface45_2 != null)
		{
			interface45_2 = Class1195.smethod_0(method_10(), method_11());
			interface45_2.Copy(series_0.interface45_2, method_11().SheetIndex, copyOptions_0);
		}
		if (series_0.dataLabels_0 != null)
		{
			if (dataLabels_0 == null)
			{
				dataLabels_0 = new DataLabels(this, NSeries.Chart);
			}
			dataLabels_0.Copy(series_0.dataLabels_0);
		}
		else
		{
			dataLabels_0 = null;
		}
		if (series_0.chartPointCollection_0 != null && series_0.chartPointCollection_0.method_4() != 0)
		{
			Points.Copy(series_0.chartPointCollection_0);
		}
		if (series_0.trendlineCollection_0 != null && series_0.trendlineCollection_0.Count != 0)
		{
			TrendLines.Copy(series_0.TrendLines);
		}
		int_0 = series_0.int_0;
		bool_0 = series_0.bool_0;
		bool_1 = series_0.bool_1;
		line_0 = series_0.line_0;
		if (series_0.shapePropertyCollection_0 != null)
		{
			shapePropertyCollection_0 = new ShapePropertyCollection(class1387_0.method_0().Chart, this, Enum178.const_15);
			shapePropertyCollection_0.Copy(series_0.shapePropertyCollection_0);
		}
		bool_2 = series_0.bool_2;
		int_3 = series_0.int_3;
	}

	internal DataLabels method_24()
	{
		return dataLabels_0;
	}

	[SpecialName]
	internal int method_25()
	{
		return class1387_0.Index;
	}

	internal void method_26(ChartType chartType_0)
	{
		class1387_0 = seriesCollection_0.Chart.class1388_0[0];
	}

	internal ChartType method_27()
	{
		return class1387_0.method_11();
	}

	[SpecialName]
	internal Class1387 method_28()
	{
		return class1387_0;
	}

	[SpecialName]
	internal void method_29(Class1387 class1387_1)
	{
		class1387_0 = class1387_1;
	}

	internal Marker method_30()
	{
		if (class1632_0 == null)
		{
			return null;
		}
		return class1632_0.method_7();
	}

	internal Marker method_31()
	{
		if (class1632_0 != null && class1632_0.method_7() != null)
		{
			return class1632_0.method_7();
		}
		if (class1387_0.method_5() != null)
		{
			return class1387_0.method_5().method_7();
		}
		return null;
	}

	internal ErrorBar method_32()
	{
		return errorBar_0;
	}

	internal ErrorBar method_33()
	{
		return errorBar_1;
	}

	[SpecialName]
	internal bool method_34()
	{
		if (class1632_0 != null && class1632_0.method_6() != null)
		{
			return false;
		}
		if (class1387_0.method_5() != null && class1387_0.method_3().method_6() != null)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal bool method_35()
	{
		return bool_2;
	}

	[SpecialName]
	internal void method_36(bool bool_3)
	{
		bool_2 = bool_3;
	}

	internal Line method_37()
	{
		return line_0;
	}

	[SpecialName]
	internal bool method_38()
	{
		if (class1632_0 == null)
		{
			if (class1387_0.method_5() != null)
			{
				return class1387_0.method_3().bool_2;
			}
			return false;
		}
		return class1632_0.bool_2;
	}

	internal ShapePropertyCollection method_39()
	{
		return shapePropertyCollection_1;
	}
}
