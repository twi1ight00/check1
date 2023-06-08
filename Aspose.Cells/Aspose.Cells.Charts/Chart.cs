using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using Aspose.Cells.Rendering;
using ns12;
using ns16;
using ns2;
using ns27;
using ns3;
using ns53;
using ns54;
using ns59;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///        Encapsulates the object that represents a single Excel chart.
///        </summary>
/// <example>
///   <code>
///        [C#]
///
///        Workbook workbook = new Workbook();
///       	Worksheet sheet = workbook.Worksheets[0];
///
///       	Cells cells = sheet.Cells;
///       	cells[0,1].PutValue("Income");
///       	cells[1,0].PutValue("Company A");
///       	cells[2,0].PutValue("Company B");
///       	cells[3,0].PutValue("Company C");
///       	cells[1,1].PutValue(10000);
///       	cells[2,1].PutValue(20000);
///       	cells[3,1].PutValue(30000);
///
///       	int chartIndex = sheet.Charts.Add(ChartType.Column, 9, 9, 21, 15);
///
///       	Chart chart = sheet.Charts[chartIndex];
///       	chart.NSeries.Add("B2:B4", true);
///       	chart.NSeries.CategoryData = "A2:A4";
///
///       	ASeries aSeries = chart.NSeries[0];
///       	aSeries.Name = "=B1";
///       	chart.IsLegendShown = true;
///       	chart.Title.Text = "Income Analysis";
///
///        [Visual Basic]
///
///        Dim workbook as Workbook = new Workbook()
///        Dim sheet as Worksheet = workbook.Worksheets(0)
///
///        Dim cells as Cells = sheet.Cells
///        cells(0,1).PutValue("Income")
///       	cells(1,0).PutValue("Company A")
///       	cells(2,0).PutValue("Company B")
///       	cells(3,0).PutValue("Company C")
///       	cells(1,1).PutValue(10000)
///       	cells(2,1).PutValue(20000)
///       	cells(3,1).PutValue(30000)
///
///       	Dim chartIndex as Integer = sheet.Charts.Add(ChartType.Column, 9, 9, 21, 15)
///
///       	Dim chart as Chart = sheet.Charts(chartIndex)
///       	chart.NSeries.Add("B2:B4", true)
///       	chart.NSeries.CategoryData = "A2:A4"
///
///       	Dim aSeries as ASeries = chart.NSeries(0)
///       	aSeries.Name = "=B1"
///       	chart.IsLegendShown = true
///       	chart.Title.Text = "Income Analysis"
///        </code>
/// </example>
public class Chart
{
	internal Class1549 class1549_0;

	internal ArrayList arrayList_0;

	private int int_0 = -1;

	private ChartShape chartShape_0;

	private ArrayList arrayList_1;

	private bool bool_0;

	private string string_0;

	private byte byte_0 = 2;

	private PlotEmptyCellsType plotEmptyCellsType_0;

	private bool bool_1;

	private WorksheetCollection worksheetCollection_0;

	private Worksheet worksheet_0;

	private ShapeCollection shapeCollection_0;

	private PrintSizeType printSizeType_0;

	private ChartType chartType_0 = ChartType.Column;

	internal Class1388 class1388_0;

	private SeriesCollection seriesCollection_0;

	private Title title_0;

	private PlotArea plotArea_0;

	private ChartArea chartArea_0;

	private Axis axis_0;

	private Axis axis_1;

	private Axis axis_2;

	private Axis axis_3;

	private Axis axis_4;

	private Legend legend_0;

	private ChartDataTable chartDataTable_0;

	private bool bool_2 = true;

	private bool bool_3 = true;

	private bool bool_4;

	private int int_1 = 150;

	private bool bool_5;

	private Floor floor_0;

	private Walls walls_0;

	private Walls walls_1;

	private bool bool_6;

	private int int_2 = 20;

	private int int_3 = 15;

	private bool bool_7 = true;

	private bool bool_8 = true;

	private short short_0 = 100;

	private short short_1 = 30;

	private int int_4 = 100;

	private ArrayList arrayList_2;

	private ArrayList arrayList_3;

	private PageSetup pageSetup_0;

	private double double_0 = 1.0;

	private double double_1 = 1.0;

	internal int int_5;

	private Enum19 enum19_0;

	private Class591 class591_0;

	/// <summary>
	///       Gets and sets the builtin style.
	///       </summary>
	/// <remarks>
	///       It should be between 1 and 48.
	///       Return -1 if it's not be set.
	///       </remarks>
	public int Style
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value >= 1 && value <= 48)
			{
				int_0 = value;
				if (class1549_0 != null)
				{
					class1549_0.string_3 = null;
				}
			}
		}
	}

	/// <summary>
	///       Represents the chartShape;
	///       </summary>
	public ChartShape ChartObject => chartShape_0;

	/// <summary>
	///       Indicates whether hide the pivot chart field buttons only when the chart is PivotChart
	///       </summary>
	public bool HidePivotFieldButtons
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
	///       The source is the data of the pivotTable.
	///       If PivotSource is not empty ,the chart is PivotChart.
	///       </summary>
	/// <remarks>If the pivot table  "PivotTable1" in the Worksheet "Sheet1" in the file "Book1.xls".
	///       The pivotSource could be "[Book1.xls]Sheet1!PivotTable1" if the chart and the PivotTable is not in the same workbook.
	///       If you set this property ,the previous data source setting will be lost.
	///       </remarks>
	public string PivotSource
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets  how to plot the empty cells.
	///       </summary>
	public PlotEmptyCellsType PlotEmptyCellsType
	{
		get
		{
			return plotEmptyCellsType_0;
		}
		set
		{
			plotEmptyCellsType_0 = value;
		}
	}

	/// <summary>
	///       Indicates whether only plot visible cells.
	///       </summary>
	public bool PlotVisibleCells
	{
		get
		{
			return (byte_0 & 2) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 2;
			}
			else
			{
				byte_0 &= 253;
			}
		}
	}

	/// <summary>
	///       Gets and sets the name of the chart.
	///       </summary>
	public string Name
	{
		get
		{
			return ChartObject.Name;
		}
		set
		{
			ChartObject.Name = value;
		}
	}

	/// <summary>
	///       True if Microsoft Excel resizes the chart to match the size of the chart sheet window.
	///       </summary>
	public bool SizeWithWindow
	{
		get
		{
			return (method_10() & 4) == 0;
		}
		set
		{
			method_11((byte)(method_10() & 0xFBu));
			if (!value)
			{
				method_11((byte)(method_10() | 4u));
			}
		}
	}

	/// <summary>
	///       Returns all drawing shapes in this chart.
	///       </summary>
	public ShapeCollection Shapes
	{
		get
		{
			if (shapeCollection_0 == null)
			{
				shapeCollection_0 = new ShapeCollection(worksheetCollection_0, worksheet_0, worksheetCollection_0.method_84(), this, -1);
			}
			return shapeCollection_0;
		}
	}

	/// <summary>
	///       Gets and sets the printed chart size.
	///       </summary>
	public PrintSizeType PrintSize
	{
		get
		{
			return printSizeType_0;
		}
		set
		{
			printSizeType_0 = value;
		}
	}

	/// <summary>
	///       Gets or sets a chart's type.
	///       </summary>
	public ChartType Type
	{
		get
		{
			return chartType_0;
		}
		set
		{
			if (chartType_0 == value)
			{
				return;
			}
			chartType_0 = value;
			if (legend_0 != null && legend_0.method_44() != null)
			{
				legend_0.method_47();
			}
			method_13();
			switch (chartType_0)
			{
			case ChartType.StockHighLowClose:
			{
				if (seriesCollection_0.Count != 3)
				{
					throw new CellsException(ExceptionType.Chart, "To creat this stock chart,arrange the data on the your in this order:high price,low price,closing price");
				}
				for (int j = 0; j < 3; j++)
				{
					seriesCollection_0[j].Line.IsVisible = false;
					seriesCollection_0[j].method_29(class1388_0[0]);
				}
				seriesCollection_0[2].MarkerStyle = ChartMarkerType.Dot;
				seriesCollection_0[2].MarkerForegroundColor = Color.Black;
				seriesCollection_0[2].MarkerBackgroundColor = Color.Black;
				return;
			}
			case ChartType.StockOpenHighLowClose:
			{
				if (seriesCollection_0.Count != 4)
				{
					throw new CellsException(ExceptionType.Chart, "To creat this stock chart,arrange the data on the your in this order:opening price,high price,low price,closing price");
				}
				for (int k = 0; k < 4; k++)
				{
					seriesCollection_0[k].Line.IsVisible = false;
					seriesCollection_0[k].method_29(class1388_0[0]);
				}
				return;
			}
			case ChartType.StockVolumeHighLowClose:
			{
				if (seriesCollection_0.Count != 4)
				{
					throw new CellsException(ExceptionType.Chart, "To creat this stock chart,arrange the data on the your in this order:volumn traded,high price,low price,closing price");
				}
				seriesCollection_0[0].method_29(class1388_0[0]);
				for (int l = 1; l < 4; l++)
				{
					seriesCollection_0[l].Line.IsVisible = false;
					seriesCollection_0[l].method_29(class1388_0[1]);
				}
				seriesCollection_0[3].MarkerStyle = ChartMarkerType.Dot;
				seriesCollection_0[3].MarkerForegroundColor = Color.Black;
				seriesCollection_0[3].MarkerBackgroundColor = Color.Black;
				return;
			}
			case ChartType.StockVolumeOpenHighLowClose:
			{
				if (seriesCollection_0.Count != 5)
				{
					throw new CellsException(ExceptionType.Chart, "To creat this stock chart,arrange the data on the your in this order:volumn traded,opening price,high price,low price,closing price");
				}
				seriesCollection_0[0].method_29(class1388_0[0]);
				for (int i = 1; i < 5; i++)
				{
					seriesCollection_0[i].Line.IsVisible = false;
					seriesCollection_0[i].method_29(class1388_0[1]);
				}
				return;
			}
			}
			foreach (Series item in seriesCollection_0)
			{
				item.method_29(class1388_0[0]);
				item.method_24();
				item.method_4();
			}
		}
	}

	/// <summary>
	///       Gets a <see cref="T:Aspose.Cells.Charts.SeriesCollection" /> collection representing the data series in the chart.
	///       </summary>
	public SeriesCollection NSeries => seriesCollection_0;

	/// <summary>
	///       Gets the chart's title.
	///       </summary>
	public Title Title
	{
		get
		{
			if (title_0 == null)
			{
				title_0 = new Title(this);
				title_0.Border.IsVisible = false;
				title_0.Area.Formatting = FormattingType.None;
			}
			return title_0;
		}
	}

	/// <summary>
	///        Gets the chart's plot area which does not inculde axis tick lables.
	///       </summary>
	/// <remarks>
	///   <p>Only for reading.
	///       If the chart is not created by MS Excel, please call Chart.Calculate() method before calling this method.</p>
	/// </remarks>
	[Obsolete("Use Chart.PlotArea.InnerX,ChartPlotArea.InnerY,Chart.PlotArea.InnerWidth and Chart.PlotArea.InnerHeight property instead.")]
	public ChartFrame PlotAreaWithoutTickLabels
	{
		get
		{
			ChartFrame chartFrame = new ChartFrame(this);
			chartFrame.method_30(plotArea_0.InnerX, plotArea_0.InnerY, plotArea_0.InnerWidth, plotArea_0.InnerHeight);
			return chartFrame;
		}
	}

	/// <summary>
	///       Gets the chart's plot area which includes axis tick lables.
	///       </summary>
	/// <remarks>
	/// </remarks>
	public PlotArea PlotArea => plotArea_0;

	/// <summary>
	///       Gets the chart area in the worksheet
	///       </summary>
	public ChartArea ChartArea => chartArea_0;

	/// <summary>
	///       Gets the chart's X axis.
	///       </summary>
	public Axis CategoryAxis => axis_0;

	/// <summary>
	///       Gets the chart's Y axis.
	///       </summary>
	public Axis ValueAxis => axis_1;

	/// <summary>
	///       Gets the chart's second Y axis.
	///       </summary>
	public Axis SecondValueAxis => axis_2;

	/// <summary>
	///       Gets the chart's second X axis.
	///       </summary>
	public Axis SecondCategoryAxis => axis_3;

	/// <summary>
	///       Gets the chart's series axis.
	///       </summary>
	public Axis SeriesAxis
	{
		get
		{
			if (axis_4 == null)
			{
				axis_4 = new Axis(Enum195.const_2, bool_15: true, this);
			}
			return axis_4;
		}
	}

	/// <summary>
	///       Gets the chart legend.
	///       </summary>
	public Legend Legend
	{
		get
		{
			if (legend_0 == null)
			{
				legend_0 = new Legend(this);
			}
			return legend_0;
		}
	}

	/// <summary>
	///       Represents the chart data table.
	///       </summary>
	public ChartDataTable ChartDataTable
	{
		get
		{
			if (chartDataTable_0 == null)
			{
				chartDataTable_0 = new ChartDataTable(this);
			}
			return chartDataTable_0;
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the chart legend will be displayed. Default is true.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Chart.ShowLegend property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Chart.ShowLegend property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool IsLegendShown
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the chart legend will be displayed. Default is true.
	///       </summary>
	public bool ShowLegend
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the chart area is rectangular cornered.
	///       Default is true.
	///       </summary>
	public bool IsRectangularCornered
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the chart displays a data table. 
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Chart.ShowDataTable property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Chart.ShowDataTable property instead.")]
	public bool IsDataTableShown
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the chart displays a data table. 
	///       </summary>
	public bool ShowDataTable
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	/// <summary>
	///       Gets or sets the angle of the first pie-chart or doughnut-chart slice, in degrees (clockwise from vertical). Applies only to pie, 3-D pie, and doughnut charts, 0 to 360. 
	///       </summary>
	public int FirstSliceAngle
	{
		get
		{
			return class1388_0[0].FirstSliceAngle;
		}
		set
		{
			if (value < 0 || value > 360)
			{
				throw new ArgumentException("First slice angle should be degree 0 to 360.");
			}
			class1388_0[0].FirstSliceAngle = value;
		}
	}

	/// <summary>
	///       Returns or sets the space between bar or column clusters, as a percentage of the bar or column width.
	///       The value of this property must be between 0 and 500.
	///       </summary>
	public int GapWidth
	{
		get
		{
			return class1388_0[0].GapWidth;
		}
		set
		{
			if (value < 0 || value > 500)
			{
				throw new ArgumentException("The GapWidth should be degree 0 to 500.");
			}
			class1388_0[0].GapWidth = value;
		}
	}

	/// <summary>
	///       Gets or sets the distance between the data series in a 3-D chart, as a percentage of the marker width.
	///       The value of this property must be between 0 and 500.
	///       </summary>
	public int GapDepth
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value < 0 || value > 500)
			{
				throw new ArgumentException("The GapWidth should be degree 0 to 500.");
			}
			int_1 = value;
		}
	}

	/// <summary>
	///        Returns a <see cref="P:Aspose.Cells.Charts.Chart.Floor" /> object that represents the walls of a 3-D chart.
	///       </summary>
	/// <remarks>This property doesn't apply to 3-D pie charts.</remarks>
	public Floor Floor
	{
		get
		{
			if (ChartCollection.smethod_0(chartType_0) && floor_0 == null)
			{
				floor_0 = new Floor(this);
			}
			return floor_0;
		}
	}

	/// <summary>
	///       Returns a <see cref="P:Aspose.Cells.Charts.Chart.Walls" /> object that represents the walls of a 3-D chart.
	///       </summary>
	/// <remarks>This property doesn't apply to 3-D pie charts.</remarks>
	public Walls Walls
	{
		get
		{
			if (ChartCollection.smethod_0(chartType_0) && walls_0 == null)
			{
				walls_0 = new Walls(this);
			}
			return walls_0;
		}
	}

	public Walls BackWall
	{
		get
		{
			if (ChartCollection.smethod_0(chartType_0) && walls_0 == null)
			{
				walls_0 = new Walls(this);
			}
			return walls_0;
		}
	}

	public Walls SideWall
	{
		get
		{
			if (ChartCollection.smethod_0(chartType_0) && walls_1 == null)
			{
				walls_1 = new Walls(this);
			}
			return walls_1;
		}
	}

	/// <summary>
	///       True if gridlines are drawn two-dimensionally on a 3-D chart.
	///       </summary>
	public bool WallsAndGridlines2D
	{
		get
		{
			if (!ChartCollection.smethod_0(chartType_0))
			{
				bool_6 = false;
			}
			return bool_6;
		}
		set
		{
			if (ChartCollection.smethod_0(chartType_0))
			{
				bool_6 = value;
			}
		}
	}

	/// <summary>
	///       Represents the rotation of the 3-D chart view (the rotation of the plot area around the z-axis, in degrees).
	///       </summary>
	/// <remarks>
	///       The value of this property must be from 0 to 360, except for 3-D bar charts, where the value must be from 0 to 44. 
	///       The default value is 20. Applies only to 3-D charts. 
	///       </remarks>
	public int RotationAngle
	{
		get
		{
			return int_2;
		}
		set
		{
			if (chartType_0 != ChartType.Bar3D100PercentStacked && chartType_0 != ChartType.Bar3DClustered && chartType_0 != ChartType.Bar3DStacked)
			{
				if (value < 0 || value > 360)
				{
					throw new ArgumentException();
				}
				int_2 = value;
			}
			else
			{
				if (value < 0 || value > 44)
				{
					throw new ArgumentException();
				}
				int_2 = value;
			}
		}
	}

	/// <summary>
	///       Represents the rotation of the 3-D chart view (the rotation of the plot area around the z-axis, in degrees).
	///       </summary>
	/// <remarks>
	///       The value of this property must be from 0 to 360, except for 3-D bar charts, where the value must be from 0 to 44. 
	///       The default value is 20. Applies only to 3-D charts. 
	///       </remarks>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Chart.RotationAngle property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Chart.RotationAngle property instead.")]
	public int Rotation
	{
		get
		{
			return int_2;
		}
		set
		{
			RotationAngle = value;
		}
	}

	/// <summary>
	///       Represents the elevation of the 3-D chart view, in degrees.
	///       </summary>
	/// <remarks>
	///       The chart elevation is the height at which you view the chart, in degrees. 
	///       The default is 15 for most chart types. 
	///       The value of this property must be between -90 and 90, except for 3-D bar charts, where it must be between 0 and 44.
	///       </remarks>
	public int Elevation
	{
		get
		{
			return int_3;
		}
		set
		{
			if (chartType_0 != ChartType.Bar3D100PercentStacked && chartType_0 != ChartType.Bar3DClustered && chartType_0 != ChartType.Bar3DStacked)
			{
				if (value < -90 || value > 90)
				{
					throw new ArgumentException();
				}
				int_3 = value;
			}
			else
			{
				if (value < 0 || value > 44)
				{
					throw new ArgumentException();
				}
				int_3 = value;
			}
		}
	}

	/// <summary>
	///       True if the chart axes are at right angles.Applies only for 3-D charts(except Column3D and 3-D Pie Charts).
	///       </summary>
	/// <remarks>
	///       If this property is True, the Perspective property is ignored.
	///       </remarks>
	public bool RightAngleAxes
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	/// <summary>
	///       True if Microsoft Excel scales a 3-D chart so that it's closer in size to the equivalent 2-D chart. 
	///       The RightAngleAxes property must be True.
	///       </summary>
	public bool AutoScaling
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	/// <summary>
	///       Returns or sets the height of a 3-D chart as a percentage of the chart width (between 5 and 500 percent).
	///       </summary>
	public short HeightPercent
	{
		get
		{
			return short_0;
		}
		set
		{
			if (value < 5 || value > 500)
			{
				throw new CellsException(ExceptionType.Chart, "The height percent must be between 5 and 500.");
			}
			short_0 = value;
		}
	}

	/// <summary>
	///       Returns or sets the perspective for the 3-D chart view. Must be between 0 and 100.
	///       This property is ignored if the RightAngleAxes property is True. 
	///       </summary>
	public short Perspective
	{
		get
		{
			return short_1;
		}
		set
		{
			if (short_1 < 0 || short_1 > 100)
			{
				throw new CellsException(ExceptionType.Chart, "The perspective must be between 0 and 100.");
			}
			short_1 = value;
		}
	}

	/// <summary>
	///       Indicates whether the chart is a 3d chart.
	///       </summary>
	public bool Is3D => ChartCollection.smethod_0(chartType_0);

	/// <summary>
	///       Represents the depth of a 3-D chart as a percentage of the chart width (between 20 and 2000 percent). 
	///       </summary>
	public int DepthPercent
	{
		get
		{
			return int_4;
		}
		set
		{
			if (value < 20 || value > 2000)
			{
				throw new ArgumentException();
			}
			int_4 = value;
		}
	}

	/// <summary>
	///       Represents the way the chart is attached to the cells below it.
	///       </summary>
	public PlacementType Placement
	{
		get
		{
			return ChartObject.Placement;
		}
		set
		{
			ChartObject.Placement = value;
		}
	}

	/// <summary>
	///       Represents the page setup description in this chart.
	///       </summary>
	public PageSetup PageSetup
	{
		get
		{
			if (pageSetup_0 == null)
			{
				pageSetup_0 = new PageSetup(worksheet_0);
				pageSetup_0.method_8();
			}
			return pageSetup_0;
		}
	}

	internal ChartCollection Charts => worksheet_0.Charts;

	[SpecialName]
	internal int method_0()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_1(int int_6)
	{
		if (int_6 >= 1 && int_6 <= 48)
		{
			int_0 = int_6;
		}
	}

	internal int method_2()
	{
		return int_0;
	}

	[SpecialName]
	internal ArrayList method_3()
	{
		if (arrayList_1 == null)
		{
			arrayList_1 = new ArrayList();
		}
		return arrayList_1;
	}

	internal ArrayList method_4()
	{
		return arrayList_1;
	}

	[SpecialName]
	internal bool method_5()
	{
		if (string_0 != null)
		{
			return string_0 != "";
		}
		return false;
	}

	internal void RefreshData()
	{
		if (method_5())
		{
			RefreshPivotData();
			return;
		}
		bool bool_ = method_9();
		for (int i = 0; i < NSeries.Count; i++)
		{
			Series series = NSeries[i];
			if (series.method_18() != null && series.method_18().imethod_4() != null && series.method_18().imethod_4().Length > 0)
			{
				method_7(bool_, series.method_18());
			}
			if (series.method_16() != null && series.method_16().imethod_4() != null && series.method_16().imethod_4().Length > 0)
			{
				method_6(series.method_16());
			}
		}
	}

	private void method_6(Interface45 interface45_0)
	{
		bool flag = false;
		StringBuilder stringBuilder = new StringBuilder(50);
		ArrayList arrayList = interface45_0.imethod_8(bool_0: true, bool_1: false, ref flag);
		if (arrayList != null && arrayList.Count != 0)
		{
			bool flag2 = true;
			for (int i = 0; i < arrayList.Count; i++)
			{
				Class1196 @class = (Class1196)arrayList[i];
				if (!PlotVisibleCells || @class.bool_0)
				{
					string text = "0";
					if (@class.cellValueType_0 == CellValueType.IsNumeric || @class.cellValueType_0 == CellValueType.IsDateTime || @class.cellValueType_0 == CellValueType.IsBool)
					{
						text = @class.method_0();
					}
					if (flag2)
					{
						stringBuilder.Append(text);
					}
					else
					{
						stringBuilder.Append("," + text);
					}
					flag2 = false;
				}
			}
			method_8(stringBuilder, ',');
		}
		string text2 = stringBuilder.ToString();
		if (text2.Length != 0)
		{
			ArrayList arrayList2 = new ArrayList();
			arrayList2.AddRange(text2.Split(','));
			interface45_0.imethod_3(arrayList2);
		}
		else
		{
			interface45_0.imethod_3(null);
		}
	}

	private void method_7(bool bool_9, Interface45 interface45_0)
	{
		int num = 1;
		StringBuilder stringBuilder = new StringBuilder(50);
		ArrayList arrayList = interface45_0.imethod_7(bool_9, bool_1: false, ref num);
		if (arrayList != null && arrayList.Count != 0)
		{
			if (num == 1)
			{
				bool flag = true;
				for (int i = 0; i < arrayList.Count; i++)
				{
					Class1196 @class = (Class1196)arrayList[i];
					if (!PlotVisibleCells || @class.bool_0)
					{
						string text = "";
						if (!@class.bool_1 && @class.StringValue != "")
						{
							text = @class.StringValue;
						}
						if (flag)
						{
							stringBuilder.Append(text);
						}
						else
						{
							stringBuilder.Append("," + text);
						}
						flag = false;
					}
				}
				method_8(stringBuilder, ',');
			}
			else
			{
				int count = arrayList.Count;
				int count2 = ((ArrayList)arrayList[0]).Count;
				ArrayList arrayList2 = new ArrayList(count2);
				for (int j = 0; j < count2; j++)
				{
					arrayList2.Add(new StringBuilder());
				}
				for (int num2 = count - 1; num2 >= 0; num2--)
				{
					ArrayList arrayList3 = (ArrayList)arrayList[num2];
					for (int k = 0; k < arrayList3.Count; k++)
					{
						Class1196 class2 = (Class1196)arrayList3[k];
						string text2 = "";
						if (!class2.bool_1 && class2.StringValue != "")
						{
							text2 = class2.StringValue;
						}
						StringBuilder stringBuilder2 = (StringBuilder)arrayList2[k];
						if (num2 == count - 1)
						{
							stringBuilder2.Append(text2);
						}
						else
						{
							stringBuilder2.Append("\n" + text2);
						}
					}
				}
				for (int l = 0; l < count2; l++)
				{
					StringBuilder stringBuilder3 = (StringBuilder)arrayList2[l];
					method_8(stringBuilder3, '\n');
					if (l == 0)
					{
						stringBuilder.Append(stringBuilder3.ToString());
					}
					else
					{
						stringBuilder.Append("," + stringBuilder3.ToString());
					}
				}
			}
		}
		string text3 = stringBuilder.ToString();
		if (text3.Length != 0)
		{
			ArrayList arrayList4 = new ArrayList();
			arrayList4.AddRange(text3.Split(','));
			interface45_0.imethod_3(arrayList4);
		}
		else
		{
			interface45_0.imethod_3(null);
		}
	}

	private void method_8(StringBuilder stringBuilder_0, char char_0)
	{
		while (stringBuilder_0.Length > 0 && stringBuilder_0[stringBuilder_0.Length - 1] == char_0)
		{
			stringBuilder_0.Remove(stringBuilder_0.Length - 1, 1);
		}
	}

	private bool method_9()
	{
		bool result = false;
		for (int i = 0; i < NSeries.Count; i++)
		{
			Interface45 @interface = NSeries[i].method_16();
			if (@interface != null && @interface.imethod_1())
			{
				result = true;
				break;
			}
		}
		return result;
	}

	/// <summary>
	///       Refreshes pivot chart's data  from it's pivot data source.
	///       </summary>
	/// <remarks>
	///       We will gather data from pivot data source to the pivot chart cache.
	///       This method is only used to gather all data to a pivot chart.
	///       </remarks>
	public void RefreshPivotData()
	{
		PivotTable pivotTable = null;
		if (string_0 == null || string_0 == "")
		{
			return;
		}
		string text = string_0;
		int num = -1;
		if (text[0] == '[')
		{
			num = text.LastIndexOf(']');
			if (num == -1)
			{
				return;
			}
			text.Substring(1, num - 2);
			text = text.Substring(num + 1);
		}
		num = text.LastIndexOf('!');
		Worksheet worksheet = worksheet_0;
		string text2 = worksheet.Name;
		if (num != -1)
		{
			text2 = text.Substring(0, num);
			if (text2[0] == '\'')
			{
				text2 = text2.Substring(1, text2.Length - 2);
			}
			worksheet = worksheetCollection_0[text2];
			if (worksheet == null)
			{
				return;
			}
			text = text.Substring(num + 1);
		}
		bool flag = Class1677.smethod_21(text2);
		string text3 = text2;
		if (flag)
		{
			text3 = '\'' + text3 + '\'';
		}
		int num2 = 0;
		while (worksheet.pivotTableCollection_0 != null && num2 < worksheet.pivotTableCollection_0.Count)
		{
			if (string.Compare(worksheet.pivotTableCollection_0[num2].Name, text, ignoreCase: true) != 0)
			{
				num2++;
				continue;
			}
			pivotTable = worksheet.pivotTableCollection_0[num2];
			break;
		}
		pivotTable?.method_15(this, text3);
	}

	[SpecialName]
	internal byte method_10()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_11(byte byte_1)
	{
		byte_0 = byte_1;
	}

	[SpecialName]
	internal bool method_12()
	{
		return bool_1;
	}

	internal Chart(Worksheet worksheet_1, ChartType chartType_1)
	{
		worksheetCollection_0 = worksheet_1.method_2();
		worksheet_0 = worksheet_1;
		bool_1 = !worksheet_1.method_2().Workbook.method_24();
		chartShape_0 = new ChartShape(worksheet_1.Shapes, this);
		seriesCollection_0 = new SeriesCollection(this);
		chartArea_0 = new ChartArea(this);
		plotArea_0 = new PlotArea(this);
		plotArea_0.method_39();
		axis_0 = new Axis(Enum195.const_0, bool_15: true, this);
		axis_1 = new Axis(Enum195.const_1, bool_15: true, this);
		axis_1.MajorGridLines.IsVisible = true;
		axis_2 = new Axis(Enum195.const_1, bool_15: false, this);
		axis_3 = new Axis(Enum195.const_0, bool_15: false, this);
		axis_2.CrossType = CrossType.Maximum;
		axis_3.CrossType = CrossType.Maximum;
		chartType_0 = chartType_1;
		method_13();
	}

	internal Chart(Worksheet worksheet_1)
	{
		worksheetCollection_0 = worksheet_1.method_2();
		worksheet_0 = worksheet_1;
		bool_1 = !worksheet_1.method_2().Workbook.method_24();
		chartShape_0 = new ChartShape(worksheet_1.Shapes, this);
		seriesCollection_0 = new SeriesCollection(this);
		chartArea_0 = new ChartArea(this);
		plotArea_0 = new PlotArea(this);
		axis_0 = new Axis(Enum195.const_0, bool_15: true, this);
		axis_1 = new Axis(Enum195.const_1, bool_15: true, this);
		axis_2 = new Axis(Enum195.const_1, bool_15: false, this);
		axis_3 = new Axis(Enum195.const_0, bool_15: false, this);
		class1388_0 = new Class1388(this);
	}

	internal Chart(Worksheet worksheet_1, ShapeCollection shapeCollection_1)
	{
		worksheetCollection_0 = worksheet_1.method_2();
		worksheet_0 = worksheet_1;
		bool_1 = !worksheet_1.method_2().Workbook.method_24();
		chartShape_0 = new ChartShape(shapeCollection_1, this);
		seriesCollection_0 = new SeriesCollection(this);
		chartArea_0 = new ChartArea(this);
		plotArea_0 = new PlotArea(this);
		axis_0 = new Axis(Enum195.const_0, bool_15: true, this);
		axis_1 = new Axis(Enum195.const_1, bool_15: true, this);
		axis_2 = new Axis(Enum195.const_1, bool_15: false, this);
		axis_3 = new Axis(Enum195.const_0, bool_15: false, this);
		class1388_0 = new Class1388(this);
	}

	private void method_13()
	{
		if (worksheet_0.Type == SheetType.Chart)
		{
			byte_0 = (byte_0 |= 4);
		}
		if (ChartCollection.smethod_3(chartType_0))
		{
			plotArea_0.Border.IsVisible = false;
			plotArea_0.Area.Formatting = FormattingType.None;
		}
		else if (ChartCollection.smethod_0(chartType_0) && !ChartCollection.smethod_5(chartType_0))
		{
			walls_0 = new Walls(this);
		}
		switch (chartType_0)
		{
		case ChartType.Area3D:
		case ChartType.Line3D:
		case ChartType.Surface3D:
		case ChartType.SurfaceWireframe3D:
			bool_7 = false;
			break;
		case ChartType.SurfaceContour:
		case ChartType.SurfaceContourWireframe:
			bool_7 = false;
			int_3 = 90;
			int_2 = 0;
			short_1 = 0;
			break;
		case ChartType.Pie3D:
		case ChartType.Pie3DExploded:
			int_2 = 0;
			bool_7 = false;
			break;
		}
		class1388_0 = new Class1388(this);
		Class1387 @class = null;
		switch (chartType_0)
		{
		default:
			@class = new Class1387(class1388_0, chartType_0, bool_11: false);
			class1388_0.Add(@class);
			break;
		case ChartType.StockHighLowClose:
			@class = new Class1387(class1388_0, ChartType.Line, bool_11: false);
			@class.HasHiLoLines = true;
			class1388_0.Add(@class);
			break;
		case ChartType.StockOpenHighLowClose:
			@class = new Class1387(class1388_0, ChartType.Line, bool_11: false);
			@class.HasHiLoLines = true;
			@class.HasUpDownBars = true;
			class1388_0.Add(@class);
			break;
		case ChartType.StockVolumeHighLowClose:
			SecondValueAxis.IsVisible = true;
			@class = new Class1387(class1388_0, ChartType.Column, bool_11: false);
			class1388_0.Add(@class);
			@class = new Class1387(class1388_0, ChartType.Line, bool_11: true);
			@class.HasHiLoLines = true;
			class1388_0.Add(@class);
			break;
		case ChartType.StockVolumeOpenHighLowClose:
			SecondValueAxis.IsVisible = true;
			@class = new Class1387(class1388_0, ChartType.Column, bool_11: false);
			class1388_0.Add(@class);
			@class = new Class1387(class1388_0, ChartType.Line, bool_11: true);
			@class.HasHiLoLines = true;
			@class.GapWidth = 100;
			@class.HasUpDownBars = true;
			class1388_0.Add(@class);
			break;
		}
	}

	[SpecialName]
	internal WorksheetCollection method_14()
	{
		return worksheetCollection_0;
	}

	[SpecialName]
	internal Worksheet method_15()
	{
		return worksheet_0;
	}

	internal ShapeCollection method_16()
	{
		return shapeCollection_0;
	}

	internal void method_17(ShapeCollection shapeCollection_1)
	{
		shapeCollection_0 = shapeCollection_1;
	}

	[SpecialName]
	internal Class1388 method_18()
	{
		return class1388_0;
	}

	internal void method_19(ChartType chartType_1)
	{
		chartType_0 = chartType_1;
	}

	/// <summary>
	///       Moves the chart to a specified location.
	///       </summary>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="lowerRightColumn">Lower right column index</param>
	/// <param name="lowerRightRow">Lower right row index</param>
	public void Move(int upperLeftRow, int upperLeftColumn, int lowerRightRow, int lowerRightColumn)
	{
		chartShape_0.MoveToRange(upperLeftRow, upperLeftColumn, lowerRightRow, lowerRightColumn);
	}

	internal Title method_20()
	{
		return title_0;
	}

	internal Axis method_21()
	{
		return axis_4;
	}

	internal void method_22(bool bool_9, Axis axis_5)
	{
		if (bool_9)
		{
			switch (axis_5.Type)
			{
			case Enum195.const_0:
				axis_3 = axis_5;
				break;
			case Enum195.const_1:
				axis_2 = axis_5;
				break;
			}
			return;
		}
		switch (axis_5.Type)
		{
		case Enum195.const_0:
			axis_0 = axis_5;
			break;
		case Enum195.const_1:
			axis_1 = axis_5;
			break;
		case Enum195.const_2:
			axis_4 = axis_5;
			break;
		}
	}

	internal void method_23(bool bool_9, Axis axis_5, Axis axis_6)
	{
		if (axis_5.string_0.ToLower() == "valax" && axis_6.string_0.ToLower() == "valax")
		{
			if (!(axis_5.string_1 == "b") && !(axis_5.string_1 == "t"))
			{
				axis_6.Type = Enum195.const_0;
			}
			else
			{
				axis_5.Type = Enum195.const_0;
			}
		}
		method_22(bool_9, axis_5);
		method_22(bool_9, axis_6);
	}

	internal Legend method_24()
	{
		return legend_0;
	}

	internal ChartDataTable method_25()
	{
		return chartDataTable_0;
	}

	/// <summary>
	///       Calcuate the custom postion of plot area, axises if the postion of them are auto assigned.
	///       </summary>
	public void Calculate()
	{
		Calculate(bool_9: true, bool_10: false);
	}

	internal void method_26(bool bool_9)
	{
		bool_5 = bool_9;
	}

	internal void Calculate(bool bool_9, bool bool_10)
	{
		Class868 @class = new Class868();
		if (bool_9)
		{
			@class.Calculate(this, bool_10);
		}
		else if (!bool_5)
		{
			@class.Calculate(this, bool_10);
			bool_5 = true;
		}
	}

	internal void Copy(Chart chart_0, CopyOptions copyOptions_0)
	{
		if (copyOptions_0.hashtable_4 == null)
		{
			Hashtable hashtable = new Hashtable();
			Worksheet worksheet = chart_0.method_15();
			int[] array = worksheet.method_2().method_32().method_9(worksheet.method_2().method_36(), worksheet.Index);
			int num = method_14().method_32().method_8(method_14().method_36(), method_15().Index);
			for (int i = 0; i < array.Length; i++)
			{
				hashtable.Add(array[i], num);
			}
			int num2 = method_14().method_32().method_10(method_14().method_36(), 65535, 65535);
			if (num2 == -1)
			{
				num2 = method_14().method_32().method_3((ushort)method_14().method_36(), ushort.MaxValue, ushort.MaxValue);
			}
			Hashtable hashtable_ = new Hashtable();
			copyOptions_0.hashtable_4 = hashtable;
			copyOptions_0.hashtable_5 = hashtable_;
			if (worksheetCollection_0 != worksheet.method_2() && copyOptions_0.method_0())
			{
				for (int j = 0; j < worksheet.method_2().Count; j++)
				{
					Worksheet worksheet2 = worksheet.method_2()[j];
					if (worksheet2 == worksheet)
					{
						continue;
					}
					Worksheet worksheet3 = worksheetCollection_0[worksheet2.Name];
					if (worksheet3 != null)
					{
						array = worksheet.method_2().method_32().method_9(worksheet.method_2().method_36(), worksheet2.Index);
						num = method_14().method_32().method_8(method_14().method_36(), worksheet3.Index);
						for (int k = 0; k < array.Length; k++)
						{
							hashtable[array[k]] = num;
						}
					}
				}
			}
		}
		bool_3 = chart_0.bool_3;
		int_5 = chart_0.int_5;
		axis_0.Copy(chart_0.axis_0, copyOptions_0);
		axis_1.Copy(chart_0.axis_1, copyOptions_0);
		axis_3.Copy(chart_0.axis_3, copyOptions_0);
		axis_2.Copy(chart_0.axis_2, copyOptions_0);
		int_0 = chart_0.int_0;
		if (chart_0.class1549_0 != null && chart_0.class1549_0.string_3 != null)
		{
			class1549_0 = new Class1549();
			class1549_0.string_3 = chart_0.class1549_0.string_3;
		}
		if (chart_0.class1388_0 != null)
		{
			class1388_0.Clear();
			foreach (Class1387 item in chart_0.class1388_0)
			{
				Class1387 @class = new Class1387(class1388_0);
				@class.Copy(item);
				class1388_0.Add(@class);
			}
		}
		if (chart_0.axis_4 != null)
		{
			SeriesAxis.Copy(chart_0.axis_4, copyOptions_0);
		}
		else
		{
			axis_4 = null;
		}
		chartArea_0.Copy(chart_0.chartArea_0);
		bool_4 = chart_0.bool_4;
		bool_2 = chart_0.bool_2;
		if (chart_0.legend_0 != null)
		{
			if (legend_0 == null)
			{
				legend_0 = new Legend(this);
			}
			legend_0.Copy(chart_0.legend_0);
		}
		chartType_0 = chart_0.chartType_0;
		if (chart_0.chartDataTable_0 != null)
		{
			chartDataTable_0 = new ChartDataTable(this);
			chartDataTable_0.Copy(chart_0.chartDataTable_0);
		}
		else
		{
			chartDataTable_0 = null;
		}
		if (chart_0.title_0 != null)
		{
			if (title_0 == null)
			{
				title_0 = new Title(this);
			}
			title_0.Copy(chart_0.title_0, copyOptions_0);
		}
		else
		{
			title_0 = null;
		}
		plotArea_0.Copy(chart_0.plotArea_0);
		seriesCollection_0.Copy(chart_0.seriesCollection_0, copyOptions_0);
		int_2 = chart_0.int_2;
		int_4 = chart_0.int_4;
		bool_6 = chart_0.bool_6;
		bool_7 = chart_0.bool_7;
		bool_8 = chart_0.bool_8;
		int_3 = chart_0.int_3;
		short_0 = chart_0.short_0;
		if (chart_0.walls_0 != null)
		{
			walls_0 = new Walls(this);
			walls_0.Copy(chart_0.walls_0);
		}
		else
		{
			walls_0 = null;
		}
		if (chart_0.floor_0 != null)
		{
			floor_0 = new Floor(this);
			floor_0.Copy(chart_0.floor_0);
		}
		else
		{
			floor_0 = null;
		}
		byte_0 = chart_0.byte_0;
		if (chart_0.shapeCollection_0 != null && chart_0.shapeCollection_0.Count != 0)
		{
			shapeCollection_0 = null;
			Shapes.Copy(chart_0.Shapes, copyOptions_0);
		}
		else
		{
			shapeCollection_0 = null;
		}
		pageSetup_0 = null;
		if (chart_0.pageSetup_0 != null)
		{
			PageSetup.Copy(chart_0.pageSetup_0, copyOptions_0);
		}
		string_0 = chart_0.string_0;
		bool_0 = chart_0.bool_0;
		double_0 = chart_0.double_0;
		double_1 = chart_0.double_1;
	}

	[SpecialName]
	internal Floor method_27()
	{
		if (floor_0 == null)
		{
			floor_0 = new Floor(this);
		}
		return floor_0;
	}

	internal Floor method_28()
	{
		return floor_0;
	}

	internal Walls method_29()
	{
		return walls_0;
	}

	internal Walls method_30()
	{
		return walls_0;
	}

	[SpecialName]
	internal Walls method_31()
	{
		if (walls_0 == null)
		{
			walls_0 = new Walls(this);
		}
		return walls_0;
	}

	internal Walls method_32()
	{
		return walls_1;
	}

	[SpecialName]
	internal Walls method_33()
	{
		if (walls_1 == null)
		{
			walls_1 = new Walls(this);
		}
		return walls_1;
	}

	[SpecialName]
	internal Walls method_34()
	{
		if (walls_0 == null)
		{
			walls_0 = new Walls(this);
		}
		return walls_0;
	}

	/// <summary>
	///       Gets a 32-bit <c>Bitmap</c> object of the chart.
	///       </summary>
	/// <returns>the picture of the chart.</returns>
	/// <remarks>
	///       If the width or height is zero or the chart is not supported according to Supported Charts List, it will return null.
	///       Please refer to <a href="http://www.aspose.com/documentation/.net-components/aspose.cells-for-.net/converting-chart-to-image.html">Supported Charts List</a> for more details.
	///       </remarks>
	public Bitmap ToImage()
	{
		using Class870 @class = new Class870(null);
		return @class.ToImage(this);
	}

	/// <summary>
	///       Creates the chart image and saves it to a file.
	///       The extension of the file name determines the format of the image.
	///       </summary>
	/// <param name="imageFile">The image file name with full path.</param>
	/// <remarks>
	///   <p>The format of the image is specified by using the extension of the file name.
	///       For example, if you specify "myfile.png", then the image will be saved
	///       in the PNG format. The following file extensions are recognized: 
	///       .bmp, .gif, .png, .jpg, .jpeg, .tiff, .tif, .emf.</p>
	///       If the width or height is zero or the chart is not supported according to Supported Charts List, this method will do nothing.
	///       Please refer to <a href="http://www.aspose.com/documentation/.net-components/aspose.cells-for-.net/converting-chart-to-image.html">Supported Charts List</a> for more details.
	///       </remarks>
	public void ToImage(string imageFile)
	{
		using Class870 @class = new Class870(null);
		@class.ToImage(imageFile, this);
	}

	/// <summary>
	///       Creates the chart image and saves it to a file in the specified format.
	///       </summary>
	/// <param name="imageFile">The image file name with full path.</param>
	/// <param name="imageFormat">The format in which to save the image.</param>
	/// <remarks>
	///   <p>The format of the image is specified by using <c>imageFormat</c>.
	///       The following formats are supported: 
	///       ImageFormat.Bmp, ImageFormat.Gif, ImageFormat.Png, ImageFormat.Jpeg, ImageFormat.Tiff, ImageFormat.Emf.</p>
	///       If the width or height is zero or the chart is not supported according to Supported Charts List, this method will do nothing.
	///       Please refer to <a href="http://www.aspose.com/documentation/.net-components/aspose.cells-for-.net/converting-chart-to-image.html">Supported Charts List</a> for more details.
	///       </remarks>
	public void ToImage(string imageFile, ImageFormat imageFormat)
	{
		using Class870 @class = new Class870(null);
		@class.ToImage(imageFile, imageFormat, this);
	}

	/// <summary>
	///       Creates the chart image and saves it to a file in the Jpeg format.
	///       </summary>
	/// <param name="imageFile">The image file name with full path.</param>
	/// <param name="jpegQuality">Jpeg quality.</param>
	/// <remarks>
	///       If the width or height is zero or the chart is not supported according to Supported Charts List, this method will do nothing.
	///       Please refer to <a href="http://www.aspose.com/documentation/.net-components/aspose.cells-for-.net/converting-chart-to-image.html">Supported Charts List</a> for more details.
	///       </remarks>
	public void ToImage(string imageFile, long jpegQuality)
	{
		using Class870 @class = new Class870(null);
		@class.ToImage(imageFile, jpegQuality, this);
	}

	/// <summary>
	///       Creates the chart image and saves it to a stream in the Jpeg format.
	///       </summary>
	/// <param name="stream">The output stream.</param>
	/// <param name="jpegQuality">Jpeg quality.</param>
	/// <remarks>
	///       If the width or height is zero or the chart is not supported according to Supported Charts List, this method will do nothing.
	///       Please refer to <a href="http://www.aspose.com/documentation/.net-components/aspose.cells-for-.net/converting-chart-to-image.html">Supported Charts List</a> for more details.
	///       </remarks>
	public void ToImage(Stream stream, long jpegQuality)
	{
		using Class870 @class = new Class870(null);
		@class.ToImage(stream, jpegQuality, this);
	}

	/// <summary>
	///       Creates the chart image and saves it to a stream in the specified format.
	///       </summary>
	/// <param name="stream">The output stream.</param>
	/// <param name="imageFormat">The format in which to save the image.</param>
	/// <remarks>
	///   <p>The format of the image is specified by using <c>imageFormat</c>.
	///       The following formats are supported: 
	///       ImageFormat.Bmp, ImageFormat.Gif, ImageFormat.Png, ImageFormat.Jpeg, ImageFormat.Tiff, ImageFormat.Emf.</p>
	///       If the width or height is zero or the chart is not supported according to Supported Charts List, this method will do nothing.
	///       Please refer <a href="http://www.aspose.com/documentation/.net-components/aspose.cells-for-.net/converting-chart-to-image.html">Supported Charts List</a> for more details.
	///       </remarks>
	public void ToImage(Stream stream, ImageFormat imageFormat)
	{
		using Class870 @class = new Class870(null);
		@class.ToImage(stream, imageFormat, this);
	}

	/// <summary>
	///        Gets a 32-bit <c>Bitmap</c> object of the chart.
	///        <c>ImageOrPrintOptions.ImageFormat</c>, ImageOrPrintOptions.TiffCompression and ImageOrPrintOptions.Quality attributes are ignored.
	///        </summary>
	/// <param name="options">Addtional image creation options</param>
	/// <returns>the picture of the chart.</returns>
	/// <remarks>
	///        Returns a 32-bit bitmap object, so ImageOrPrintOptions.ImageFormat, ImageOrPrintOptions.TiffCompression and ImageOrPrintOptions.Quality
	///        attributes do not affect the method.
	///
	///        If the width or height is zero or the chart is not supported according to Supported Charts List, it will return null.
	///        Please refer to <a href="http://www.aspose.com/documentation/.net-components/aspose.cells-for-.net/converting-chart-to-image.html">Supported Charts List</a> for more details.
	///        </remarks>
	/// <example>
	///        Gets a bitmap object with 200 x dpi and 300 y dpi.
	///        <code>
	///
	///        [C#]
	///        ImageOrPrintOptions options = new ImageOrPrintOptions();
	///        options.HorizontalResolution = 200;
	///        options.VerticalResolution = 300;
	///
	///        Workbook book = new Workbook(@"c:\test.xls");
	///        Bitmap chartObject = book.Worksheets[0].Charts[0].ToImage(options);
	///
	///        [VB]
	///        Dim options As ImageOrPrintOptions =  New ImageOrPrintOptions() 
	///        options.HorizontalResolution = 200
	///        options.VerticalResolution = 300
	///
	///        Dim book As Workbook =  New Workbook("c:\test.xls")
	///        Dim chartObject As Bitmap = book.Worksheets(0).Charts(0).ToImage(options)
	///
	///        </code></example>
	public Bitmap ToImage(ImageOrPrintOptions options)
	{
		using Class870 @class = new Class870(options);
		return @class.ToImage(this);
	}

	/// <summary>
	///        Creates the chart image and saves it to a file.
	///        The extension of the file name determines the format of the image.
	///        </summary>
	/// <param name="imageFile">The image file name with full path.</param>
	/// <param name="options">Addtional image creation options</param>
	/// <remarks>
	///   <p>The format of the image is specified by using the extension of the file name.
	///        For example, if you specify "myfile.png", then the image will be saved
	///        in the PNG format. The following file extensions are recognized: 
	///        .bmp, .gif, .png, .jpg, .jpeg, .tiff, .tif, .emf.</p>
	///        If the width or height is zero or the chart is not supported according to Supported Charts List, this method will do nothing.
	///        Please refer to <a href="http://www.aspose.com/documentation/.net-components/aspose.cells-for-.net/converting-chart-to-image.html">Supported Charts List</a> for more details.
	///        </remarks>
	/// <example>
	///        Saves to Tiff with 300 dpi and CCITT4 compression.
	///        <code>
	///
	///        [C#]
	///        ImageOrPrintOptions options = new ImageOrPrintOptions();
	///        options.HorizontalResolution = 300;
	///        options.VerticalResolution = 300;
	///        options.TiffCompression = TiffCompression.CompressionCCITT4;
	///
	///        Workbook book = new Workbook(@"c:\test.xls");
	///        book.Worksheets[0].Charts[0].ToImage(@"c:\chart.Tiff", options);
	///
	///        [VB]
	///        Dim options As ImageOrPrintOptions =  New ImageOrPrintOptions() 
	///        options.HorizontalResolution = 300
	///        options.VerticalResolution = 300
	///        options.TiffCompression = TiffCompression.CompressionCCITT4
	///
	///        Dim book As Workbook =  New Workbook("c:\test.xls")
	///        book.Worksheets(0).Charts(0).ToImage("c:\chart.Tiff", options)
	///
	///        </code>
	///
	///        Saves to Jpeg with 300 dpi and 80 image quality.
	///        <code>
	///
	///        [C#]
	///        ImageOrPrintOptions options = new ImageOrPrintOptions();
	///        options.HorizontalResolution = 300;
	///        options.VerticalResolution = 300;
	///        options.Quality = 80;
	///
	///        Workbook book = new Workbook(@"c:\test.xls");
	///        book.Worksheets[0].Charts[0].ToImage(@"c:\chart.Jpeg", options);
	///
	///        [VB]
	///        Dim options As ImageOrPrintOptions =  New ImageOrPrintOptions()
	///        options.HorizontalResolution = 300
	///        options.VerticalResolution = 300
	///        options.Quality = 80
	///
	///        Dim book As Workbook =  New Workbook("c:\test.xls")
	///        book.Worksheets(0).Charts(0).ToImage("c:\chart.Jpeg", options)
	///
	///        </code></example>
	public void ToImage(string imageFile, ImageOrPrintOptions options)
	{
		using Class870 @class = new Class870(options);
		@class.ToImage(imageFile, this);
	}

	/// <summary>
	///       Creates the chart image and saves it to a stream in the specified format.
	///       </summary>
	/// <param name="stream">The output stream.</param>
	/// <param name="options">Addtional image creation options</param>
	/// <remarks>
	///   <p>The format of the image is specified by using <c>options.ImageFormat</c>.
	///       The following formats are supported: 
	///       ImageFormat.Bmp, ImageFormat.Gif, ImageFormat.Png, ImageFormat.Jpeg, ImageFormat.Tiff, ImageFormat.Emf.</p>
	///       If the width or height is zero or the chart is not supported according to Supported Charts List, this method will do nothing.
	///       Please refer to <a href="http://www.aspose.com/documentation/.net-components/aspose.cells-for-.net/converting-chart-to-image.html">Supported Charts List</a> for more details.
	///       </remarks>
	public void ToImage(Stream stream, ImageOrPrintOptions options)
	{
		ImageFormat imageFormat = options.ImageFormat;
		using Class870 @class = new Class870(options);
		@class.ToImage(stream, imageFormat, this);
	}

	[SpecialName]
	internal ArrayList method_35()
	{
		if (arrayList_2 == null)
		{
			arrayList_2 = new ArrayList();
		}
		return arrayList_2;
	}

	internal void method_36(Font font_0, ArrayList arrayList_4)
	{
		if (font_0.method_6())
		{
			method_38(font_0, arrayList_4);
		}
		else
		{
			method_40(font_0, arrayList_4);
		}
	}

	internal void method_37(ArrayList arrayList_4)
	{
		if (!method_14().Workbook.method_24())
		{
			arrayList_3 = new ArrayList();
			if (arrayList_2 == null)
			{
				arrayList_2 = new ArrayList();
			}
			method_43(arrayList_4);
			arrayList_3 = null;
			if (shapeCollection_0 != null)
			{
				shapeCollection_0.method_2();
			}
		}
	}

	internal void method_38(Font font_0, ArrayList arrayList_4)
	{
		Class1383 @class = (Class1383)font_0.method_4();
		if (@class == null)
		{
			return;
		}
		foreach (Class1383 item in arrayList_2)
		{
			if (item.method_0(@class, font_0))
			{
				font_0.method_22(item.int_0);
				@class.int_0 = font_0.method_21();
				return;
			}
		}
		arrayList_4.Add(font_0);
		font_0.method_22(arrayList_4.Count);
		Class1383 class3 = (Class1383)font_0.method_4();
		arrayList_2.Add(class3);
		class3.int_0 = font_0.method_21();
	}

	internal int method_39(Font font_0, ArrayList arrayList_4, int int_6, ref bool bool_9)
	{
		bool_9 = false;
		int num = 0;
		num = int_6;
		Font font;
		while (true)
		{
			if (num < arrayList_4.Count)
			{
				font = (Font)arrayList_4[num];
				if ((!font_0.method_6() || !font.method_6() || font_0.method_4() != font.method_4()) && font_0.method_18(font))
				{
					break;
				}
				num++;
				continue;
			}
			arrayList_4.Add(font_0);
			font_0.method_22(arrayList_4.Count);
			bool_9 = true;
			return num;
		}
		font_0.method_22(font.method_21());
		return num;
	}

	internal void method_40(Font font_0, ArrayList arrayList_4)
	{
		foreach (Font item in arrayList_3)
		{
			if (item.method_18(font_0))
			{
				font_0.method_22(item.method_21());
				return;
			}
		}
		int num = -1;
		bool bool_ = false;
		bool flag = false;
		while (true)
		{
			num = method_39(font_0, arrayList_4, num + 1, ref bool_);
			if (!bool_)
			{
				foreach (Class1383 item2 in arrayList_2)
				{
					if (item2.int_0 == font_0.method_21())
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
				flag = false;
				continue;
			}
			arrayList_3.Add(font_0);
			return;
		}
		arrayList_3.Add(font_0);
	}

	internal Class1383 method_41(int int_6)
	{
		if (arrayList_2 == null)
		{
			return null;
		}
		foreach (Class1383 item in arrayList_2)
		{
			if (item.int_0 == int_6)
			{
				return item;
			}
		}
		return null;
	}

	internal void method_42(ArrayList arrayList_4)
	{
		if ((worksheetCollection_0.Workbook.method_21() != Enum187.const_1 || chartArea_0.method_12() != null) && (chartArea_0.method_12() != null || chartArea_0.method_13() == -1 || chartArea_0.method_39() == -1))
		{
			if (chartArea_0.AutoScaleFont)
			{
				Font font = chartArea_0.Font;
				method_38(font, arrayList_4);
				method_35().Remove(font.method_4());
				method_35().Insert(0, font.method_4());
				Class1383 @class = new Class1383(this, 0, bool_0: false);
				@class.Copy((Class1383)font.method_4());
				@class.ushort_2 = 0;
				Font font2 = new Font(method_14(), @class, bool_0: true);
				font2.Copy(font);
				font2.method_5(@class);
				method_38(font2, arrayList_4);
				method_35().Remove(font2.method_4());
				method_35().Insert(0, font2.method_4());
				chartArea_0.method_14(chartArea_0.Font.method_21());
			}
			else
			{
				method_36(chartArea_0.Font, arrayList_4);
				chartArea_0.method_14(chartArea_0.Font.method_21());
			}
			chartArea_0.method_40(-1);
		}
	}

	internal void method_43(ArrayList arrayList_4)
	{
		method_42(arrayList_4);
		if (bool_4 && chartDataTable_0 != null && chartDataTable_0.method_0() != null)
		{
			method_36(chartDataTable_0.method_0(), arrayList_4);
		}
		method_44(title_0, arrayList_4);
		if (legend_0 != null)
		{
			method_45(legend_0, arrayList_4);
			if (bool_2 && legend_0.method_44() != null)
			{
				LegendEntryCollection legendEntries = legend_0.LegendEntries;
				for (int i = 0; i < legendEntries.Count; i++)
				{
					LegendEntry legendEntry = legendEntries.method_1(i);
					if (legendEntry != null && legendEntry.method_0() != null)
					{
						method_36(legendEntry.method_0(), arrayList_4);
					}
				}
			}
		}
		method_46(axis_0, arrayList_4);
		method_46(axis_1, arrayList_4);
		method_46(axis_2, arrayList_4);
		method_46(SecondCategoryAxis, arrayList_4);
		method_47(axis_1, SecondValueAxis, arrayList_4);
		if (method_21() != null)
		{
			method_46(method_21(), arrayList_4);
		}
		for (int j = 0; j < seriesCollection_0.Count; j++)
		{
			Series series = seriesCollection_0[j];
			method_45(series.method_24(), arrayList_4);
			if (series.method_3() != null)
			{
				ChartPointCollection points = series.Points;
				for (int k = 0; k < points.method_4(); k++)
				{
					method_45(points.method_7(k).method_9(), arrayList_4);
				}
			}
			if (series.method_22() != null && series.TrendLines.Count != 0)
			{
				for (int l = 0; l < series.TrendLines.Count; l++)
				{
					Trendline trendline = series.TrendLines[l];
					method_45(trendline.method_36(), arrayList_4);
				}
			}
		}
	}

	internal void method_44(Title title_1, ArrayList arrayList_4)
	{
		if (title_1 == null)
		{
			return;
		}
		if (title_1.method_12() != null)
		{
			method_36(title_1.Font, arrayList_4);
			title_1.method_14(title_1.Font.method_21());
		}
		if (title_1.method_39() == null)
		{
			return;
		}
		if (title_1.method_12() == null && title_1.method_13() == -1)
		{
			method_36(title_1.Font, arrayList_4);
		}
		foreach (FontSetting item in title_1.method_39())
		{
			if (item.method_2() != null)
			{
				method_36(item.method_2(), arrayList_4);
			}
		}
	}

	internal void method_45(ChartFrame chartFrame_0, ArrayList arrayList_4)
	{
		if (chartFrame_0 != null && chartFrame_0.method_12() != null)
		{
			method_36(chartFrame_0.Font, arrayList_4);
			chartFrame_0.method_14(chartFrame_0.Font.method_21());
		}
	}

	internal void method_46(Axis axis_5, ArrayList arrayList_4)
	{
		if (axis_5 != null)
		{
			if (axis_5.method_14() != null && axis_5.TickLabels.method_0() != null)
			{
				method_36(axis_5.TickLabels.Font, arrayList_4);
				axis_5.TickLabels.method_2(axis_5.TickLabels.Font.method_21());
			}
			if (axis_5.method_18() != null && axis_5.method_18().method_12() != null)
			{
				method_36(axis_5.DisplayUnitLabel.Font, arrayList_4);
				axis_5.DisplayUnitLabel.method_14(axis_5.DisplayUnitLabel.Font.method_21());
			}
			method_44(axis_5.method_20(), arrayList_4);
		}
	}

	internal void method_47(Axis axis_5, Axis axis_6, ArrayList arrayList_4)
	{
		bool flag = axis_5.Type == Enum195.const_1 && axis_5.DisplayUnit != 0 && axis_5.IsDisplayUnitLabelShown;
		Font font = null;
		if (flag)
		{
			font = axis_5.DisplayUnitLabel.Font;
			method_36(font, arrayList_4);
			if (axis_5.DisplayUnitLabel.AutoScaleFont)
			{
				((Class1383)font.method_4()).int_0 = font.method_21();
			}
			axis_5.DisplayUnitLabel.method_14(font.method_21());
		}
		if (flag = axis_6.Type == Enum195.const_1 && axis_6.DisplayUnit != 0 && axis_6.IsDisplayUnitLabelShown)
		{
			font = axis_6.DisplayUnitLabel.Font;
			method_36(font, arrayList_4);
			if (axis_6.DisplayUnitLabel.AutoScaleFont)
			{
				((Class1383)font.method_4()).int_0 = font.method_21();
			}
			axis_6.DisplayUnitLabel.method_14(font.method_21());
		}
	}

	internal void method_48()
	{
		TickLabels tickLabels = axis_0.method_14();
		if (tickLabels != null && tickLabels.NumberFormat != null && !tickLabels.NumberFormatLinked)
		{
			tickLabels.method_7(worksheetCollection_0.method_65(tickLabels.NumberFormat));
		}
		tickLabels = axis_1.method_14();
		if (tickLabels != null && tickLabels.NumberFormat != null && !tickLabels.NumberFormatLinked)
		{
			tickLabels.method_7(worksheetCollection_0.method_65(tickLabels.NumberFormat));
		}
		tickLabels = SecondValueAxis.method_14();
		if (tickLabels != null && tickLabels.NumberFormat != null && !tickLabels.NumberFormatLinked)
		{
			tickLabels.method_7(worksheetCollection_0.method_65(tickLabels.NumberFormat));
		}
		if (method_21() != null)
		{
			tickLabels = method_21().method_14();
			if (tickLabels != null && tickLabels.NumberFormat != null && !tickLabels.NumberFormatLinked)
			{
				tickLabels.method_7(worksheetCollection_0.method_65(tickLabels.NumberFormat));
			}
		}
		tickLabels = SecondCategoryAxis.method_14();
		if (tickLabels != null && tickLabels.NumberFormat != null && !tickLabels.NumberFormatLinked)
		{
			tickLabels.method_7(worksheetCollection_0.method_65(tickLabels.NumberFormat));
		}
		foreach (Series item in seriesCollection_0)
		{
			DataLabels dataLabels = null;
			if (item.method_3() != null)
			{
				ArrayList arrayList = item.method_3().arrayList_0;
				foreach (ChartPoint item2 in arrayList)
				{
					if (item2.method_9() != null && item2.method_9().method_65())
					{
						dataLabels = item2.method_9();
						if (!dataLabels.NumberFormatLinked && dataLabels.NumberFormat != null)
						{
							dataLabels.method_51(worksheetCollection_0.method_65(dataLabels.NumberFormat));
						}
					}
				}
			}
			dataLabels = item.method_24();
			if (dataLabels != null && dataLabels.method_65() && !dataLabels.NumberFormatLinked && dataLabels.NumberFormat != null)
			{
				dataLabels.method_51(worksheetCollection_0.method_65(dataLabels.NumberFormat));
			}
		}
	}

	[SpecialName]
	internal double method_49()
	{
		return double_0;
	}

	[SpecialName]
	internal void method_50(double double_2)
	{
		double_0 = double_2;
	}

	[SpecialName]
	internal double method_51()
	{
		return double_1;
	}

	[SpecialName]
	internal void method_52(double double_2)
	{
		double_1 = double_2;
	}

	internal void method_53()
	{
		if (method_16() != null && method_16().Count > 0)
		{
			Shapes.method_40();
		}
		Title title = method_20();
		if (title != null && title.byte_1 != null)
		{
			title.byte_1 = Class1247.smethod_1(title.byte_1, -1, 0, 0, bool_0: false);
		}
		title = axis_0.method_20();
		if (title != null && title.byte_1 != null)
		{
			title.byte_1 = Class1247.smethod_1(title.byte_1, -1, 0, 0, bool_0: false);
		}
		title = axis_1.method_20();
		if (title != null && title.byte_1 != null)
		{
			title.byte_1 = Class1247.smethod_1(title.byte_1, -1, 0, 0, bool_0: false);
		}
		for (int i = 0; i < seriesCollection_0.Count; i++)
		{
			Series series = seriesCollection_0[i];
			object obj = series.method_13();
			if (obj != null && obj is byte[])
			{
				byte[] array = (byte[])obj;
				series.method_12(Class1247.smethod_1(array, -1, 0, 0, bool_0: false));
			}
			if (series.method_18() != null)
			{
				series.method_19(((Class1197)series.method_18()).method_11());
			}
			if (series.method_16() != null)
			{
				series.method_17(((Class1197)series.method_16()).method_11());
			}
			if (series.method_20() != null)
			{
				series.method_21(((Class1197)series.method_20()).method_11());
			}
			if (series.method_32() != null)
			{
				ErrorBar errorBar = series.method_32();
				if (errorBar.method_37() != null)
				{
					errorBar.method_38(((Class1197)errorBar.method_37()).method_11());
				}
				if (errorBar.method_35() != null)
				{
					errorBar.method_36(((Class1197)errorBar.method_35()).method_11());
				}
			}
			if (series.method_33() != null)
			{
				ErrorBar errorBar2 = series.method_33();
				if (errorBar2.method_37() != null)
				{
					errorBar2.method_38(((Class1197)errorBar2.method_37()).method_11());
				}
				if (errorBar2.method_35() != null)
				{
					errorBar2.method_36(((Class1197)errorBar2.method_35()).method_11());
				}
			}
			if (series.method_3() == null)
			{
				continue;
			}
			ArrayList arrayList = series.method_3().arrayList_0;
			for (int j = 0; j < arrayList.Count; j++)
			{
				ChartPoint chartPoint = (ChartPoint)arrayList[j];
				if (chartPoint.method_9() != null)
				{
					DataLabels dataLabels = chartPoint.method_9();
					if (dataLabels.byte_3 != null)
					{
						dataLabels.byte_3 = Class1247.smethod_1(dataLabels.byte_3, -1, 0, 0, bool_0: false);
					}
				}
			}
		}
	}

	internal void method_54()
	{
		if (method_16() != null && method_16().Count > 0)
		{
			Shapes.method_39();
		}
		Title title = method_20();
		if (title != null && title.byte_1 != null)
		{
			title.byte_1 = Class1248.smethod_1(title.byte_1, -1);
		}
		title = axis_0.method_20();
		if (title != null && title.byte_1 != null)
		{
			title.byte_1 = Class1248.smethod_1(title.byte_1, -1);
		}
		title = axis_1.method_20();
		if (title != null && title.byte_1 != null)
		{
			title.byte_1 = Class1248.smethod_1(title.byte_1, -1);
		}
		for (int i = 0; i < seriesCollection_0.Count; i++)
		{
			Series series = seriesCollection_0[i];
			object obj = series.method_13();
			if (obj != null && obj is byte[])
			{
				byte[] array = (byte[])obj;
				series.method_12(Class1248.smethod_1(array, -1));
			}
			if (series.method_18() != null)
			{
				series.method_19(((Class1198)series.method_18()).method_12());
			}
			if (series.method_16() != null)
			{
				series.method_17(((Class1198)series.method_16()).method_12());
			}
			if (series.method_20() != null)
			{
				series.method_21(((Class1198)series.method_20()).method_12());
			}
			if (series.method_32() != null)
			{
				ErrorBar errorBar = series.method_32();
				if (errorBar.method_37() != null)
				{
					errorBar.method_38(((Class1198)errorBar.method_37()).method_12());
				}
				if (errorBar.method_35() != null)
				{
					errorBar.method_36(((Class1198)errorBar.method_35()).method_12());
				}
			}
			if (series.method_33() != null)
			{
				ErrorBar errorBar2 = series.method_33();
				if (errorBar2.method_37() != null)
				{
					errorBar2.method_38(((Class1198)errorBar2.method_37()).method_12());
				}
				if (errorBar2.method_35() != null)
				{
					errorBar2.method_36(((Class1198)errorBar2.method_35()).method_12());
				}
			}
			if (series.method_3() == null)
			{
				continue;
			}
			ArrayList arrayList = series.method_3().arrayList_0;
			for (int j = 0; j < arrayList.Count; j++)
			{
				ChartPoint chartPoint = (ChartPoint)arrayList[j];
				if (chartPoint.method_9() != null)
				{
					DataLabels dataLabels = chartPoint.method_9();
					if (dataLabels.byte_3 != null)
					{
						dataLabels.byte_3 = Class1248.smethod_1(dataLabels.byte_3, -1);
					}
				}
			}
		}
	}

	internal void method_55(Class1725 class1725_0)
	{
		if (pageSetup_0 == null)
		{
			class1725_0.method_5(20);
			class1725_0.method_5(21);
			class1725_0.method_5(131203);
			class1725_0.method_8(0);
			class1725_0.method_5(131204);
			class1725_0.method_8(0);
			return;
		}
		if (pageSetup_0.method_32() != null && pageSetup_0.method_32().Count != 0)
		{
			Class687 @class = new Class687();
			@class.method_6(pageSetup_0.method_32());
			@class.method_7(class1725_0);
		}
		Class645 class2 = new Class645(bool_0: true);
		class2.method_4(pageSetup_0.string_2);
		class2.vmethod_0(class1725_0);
		Class645 class3 = new Class645(bool_0: false);
		class3.method_4(pageSetup_0.string_3);
		class3.vmethod_0(class1725_0);
		class1725_0.method_8(131);
		class1725_0.method_8(2);
		if (pageSetup_0.CenterHorizontally)
		{
			class1725_0.method_8(1);
		}
		else
		{
			class1725_0.method_8(0);
		}
		class1725_0.method_8(132);
		class1725_0.method_8(2);
		if (pageSetup_0.CenterVertically)
		{
			class1725_0.method_8(1);
		}
		else
		{
			class1725_0.method_8(0);
		}
		if (pageSetup_0.LeftMargin >= 0.0)
		{
			class1725_0.method_8(38);
			class1725_0.method_8(8);
			class1725_0.method_9(pageSetup_0.LeftMarginInch);
		}
		if (pageSetup_0.RightMargin >= 0.0)
		{
			class1725_0.method_8(39);
			class1725_0.method_8(8);
			class1725_0.method_9(pageSetup_0.RightMarginInch);
		}
		if (pageSetup_0.TopMargin >= 0.0)
		{
			class1725_0.method_8(40);
			class1725_0.method_8(8);
			class1725_0.method_9(pageSetup_0.TopMarginInch);
		}
		if (pageSetup_0.BottomMargin >= 0.0)
		{
			class1725_0.method_8(41);
			class1725_0.method_8(8);
			class1725_0.method_9(pageSetup_0.BottomMarginInch);
		}
		if (pageSetup_0.method_4() != null)
		{
			Class668 class4 = new Class668();
			class4.method_4(pageSetup_0.method_4());
			class4.vmethod_0(class1725_0);
		}
		Class702 class5 = new Class702();
		class5.method_3(pageSetup_0.method_12());
		class5.vmethod_0(class1725_0);
	}

	[SpecialName]
	internal Enum19 method_56()
	{
		return enum19_0;
	}

	[SpecialName]
	internal void method_57(Enum19 enum19_1)
	{
		enum19_0 = enum19_1;
	}

	[SpecialName]
	internal Class591 method_58()
	{
		return class591_0;
	}

	[SpecialName]
	internal void method_59(Class591 class591_1)
	{
		class591_0 = class591_1;
	}
}
