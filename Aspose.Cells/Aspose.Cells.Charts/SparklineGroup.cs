using System;
using ns16;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///   <see cref="T:Aspose.Cells.Charts.Sparkline" /> is organized into sparkline group. A SparklineGroup contains a variable number of sparkline items.
///       A sparkline group specifies the type, display settings and axis settings for the sparklines.
///       </summary>
public class SparklineGroup
{
	private SparklineGroupCollection sparklineGroupCollection_0;

	private SparklineCollection sparklineCollection_0;

	internal SparklineType sparklineType_0;

	private PlotEmptyCellsType plotEmptyCellsType_0;

	private bool bool_0;

	private bool bool_1;

	private CellsColor cellsColor_0;

	private bool bool_2;

	private CellsColor cellsColor_1;

	private bool bool_3;

	private CellsColor cellsColor_2;

	private bool bool_4;

	private CellsColor cellsColor_3;

	private bool bool_5;

	private CellsColor cellsColor_4;

	private bool bool_6;

	private CellsColor cellsColor_5;

	private CellsColor cellsColor_6;

	private bool bool_7;

	private double double_0 = 0.75;

	private CellsColor cellsColor_7;

	private bool bool_8;

	private Class1309 class1309_0;

	private SparklineAxisMinMaxType sparklineAxisMinMaxType_0;

	private double double_1;

	private SparklineAxisMinMaxType sparklineAxisMinMaxType_1;

	private double double_2;

	/// <summary>
	///       Gets and sets the preset style type of the sparkline group.
	///       </summary>
	public SparklinePresetStyleType PresetStyle
	{
		get
		{
			return Class1311.GetStyle(this);
		}
		set
		{
			Class1311.SetStyle(this, value);
		}
	}

	/// <summary>
	///       Gets the <see cref="P:Aspose.Cells.Charts.SparklineGroup.SparklineCollection" /> object of the sparkline group.
	///       </summary>
	public SparklineCollection SparklineCollection => sparklineCollection_0;

	/// <summary>
	///       Indicates the sparkline type of the sparkline group.
	///       </summary>
	public SparklineType Type
	{
		get
		{
			return sparklineType_0;
		}
		set
		{
			sparklineType_0 = value;
		}
	}

	/// <summary>
	///       Indicates how to plot empty cells.
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
	///       Indicates whether to show data in hidden rows and columns.
	///       </summary>
	public bool DisplayHidden
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
	///       Indicates whether to highlight the highest points of data in the sparkline group.
	///       </summary>
	public bool ShowHighPoint
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	/// <summary>
	///       Gets and sets the color of the highest points of data in the sparkline group.
	///       </summary>
	public CellsColor HighPointColor
	{
		get
		{
			return cellsColor_0;
		}
		set
		{
			if (value != null)
			{
				cellsColor_0 = value;
			}
		}
	}

	/// <summary>
	///       Indicates whether to highlight the lowest points of data in the sparkline group.
	///       </summary>
	public bool ShowLowPoint
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
	///       Gets and sets the color of the lowest points of data in the sparkline group.
	///       </summary>
	public CellsColor LowPointColor
	{
		get
		{
			return cellsColor_1;
		}
		set
		{
			if (value != null)
			{
				cellsColor_1 = value;
			}
		}
	}

	/// <summary>
	///       Indicates whether to highlight the negative values on the sparkline group with a different color or marker.
	///       </summary>
	public bool ShowNegativePoints
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
	///       Gets and sets the color of the negative values on the sparkline group.
	///       </summary>
	public CellsColor NegativePointsColor
	{
		get
		{
			return cellsColor_2;
		}
		set
		{
			if (value != null)
			{
				cellsColor_2 = value;
			}
		}
	}

	/// <summary>
	///       Indicates whether to highlight the first point of data in the sparkline group.
	///       </summary>
	public bool ShowFirstPoint
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
	///       Gets and sets the color of the first point of data in the sparkline group.
	///       </summary>
	public CellsColor FirstPointColor
	{
		get
		{
			return cellsColor_3;
		}
		set
		{
			if (value != null)
			{
				cellsColor_3 = value;
			}
		}
	}

	/// <summary>
	///       Indicates whether to highlight the last point of data in the sparkline group.
	///       </summary>
	public bool ShowLastPoint
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	/// <summary>
	///       Gets and sets the color of the last point of data in the sparkline group.
	///       </summary>
	public CellsColor LastPointColor
	{
		get
		{
			return cellsColor_4;
		}
		set
		{
			if (value != null)
			{
				cellsColor_4 = value;
			}
		}
	}

	/// <summary>
	///       Indicates whether to highlight each point in each line sparkline in the sparkline group.
	///       </summary>
	public bool ShowMarkers
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	/// <summary>
	///       Gets and sets the color of points in each line sparkline in the sparkline group.
	///       </summary>
	public CellsColor MarkersColor
	{
		get
		{
			return cellsColor_5;
		}
		set
		{
			if (value != null)
			{
				cellsColor_5 = value;
			}
		}
	}

	/// <summary>
	///       Gets and sets the color of the sparklines in the sparkline group.
	///       </summary>
	public CellsColor SeriesColor
	{
		get
		{
			return cellsColor_6;
		}
		set
		{
			if (value != null)
			{
				cellsColor_6 = value;
			}
		}
	}

	/// <summary>
	///       Indicates whether the plot data is right to left.
	///       </summary>
	public bool PlotRightToLeft
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
	///       Gets and sets the line weight in each line sparkline in the sparkline group, in the unit of points.
	///       </summary>
	public double LineWeight
	{
		get
		{
			return Math.Round(double_0, 2);
		}
		set
		{
			if (value < 0.0)
			{
				throw new CellsException(ExceptionType.InvalidData, "Line weight must greater than zero.");
			}
			double_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets the color of the horizontal axis in the sparkline group.
	///       </summary>
	public CellsColor HorizontalAxisColor
	{
		get
		{
			return cellsColor_7;
		}
		set
		{
			cellsColor_7 = value;
		}
	}

	/// <summary>
	///       Indicates whether to show the sparkline horizontal axis.
	///       The horizontal axis appears if the sparkline has data that crosses the zero axis.
	///       </summary>
	public bool ShowHorizontalAxis
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
	///       Represents the range that contains the date values for the sparkline data.
	///       </summary>
	public string HorizontalAxisDateRange
	{
		get
		{
			if (class1309_0 == null)
			{
				return null;
			}
			return Class1618.smethod_93(class1309_0.Values);
		}
		set
		{
			if (value == null)
			{
				class1309_0 = null;
				return;
			}
			Worksheet worksheet_ = sparklineCollection_0.method_1().SparklineGroupCollection.method_0();
			Class1309 @class = new Class1309(worksheet_);
			@class.Values = value;
			@class.GetRange();
			if (@class.int_1 == @class.int_3)
			{
				if (@class.bool_2 != @class.bool_3)
				{
					throw new CellsException(ExceptionType.Sparkline, "The reference for the data range is invalid");
				}
			}
			else
			{
				if (@class.int_0 != @class.int_2)
				{
					throw new CellsException(ExceptionType.Sparkline, "Data range cells must in same column or row");
				}
				if (@class.bool_0 != @class.bool_1)
				{
					throw new CellsException(ExceptionType.Sparkline, "The reference for the data range is invalid");
				}
			}
			class1309_0 = @class;
		}
	}

	/// <summary>
	///       Represents the vertical axis maximum value type.
	///       </summary>
	public SparklineAxisMinMaxType VerticalAxisMaxValueType
	{
		get
		{
			return sparklineAxisMinMaxType_0;
		}
		set
		{
			sparklineAxisMinMaxType_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets the custom maximum value for the vertical axis.
	///       </summary>
	public double VerticalAxisMaxValue
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	/// <summary>
	///       Represents the vertical axis minimum value type.
	///       </summary>
	public SparklineAxisMinMaxType VerticalAxisMinValueType
	{
		get
		{
			return sparklineAxisMinMaxType_1;
		}
		set
		{
			sparklineAxisMinMaxType_1 = value;
		}
	}

	/// <summary>
	///       Gets and sets the custom minimum value for the vertical axis.
	///       </summary>
	public double VerticalAxisMinValue
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	internal SparklineGroupCollection SparklineGroupCollection => sparklineGroupCollection_0;

	internal SparklineGroup(SparklineGroupCollection sparklineGroupCollection_1, SparklineType sparklineType_1, string string_0, bool bool_9, CellArea cellArea_0)
	{
		sparklineGroupCollection_0 = sparklineGroupCollection_1;
		sparklineType_0 = sparklineType_1;
		if (sparklineType_1 == SparklineType.Stacked)
		{
			bool_3 = true;
		}
		sparklineCollection_0 = new SparklineCollection(this, string_0, bool_9, cellArea_0);
		PresetStyle = SparklinePresetStyleType.Style1;
	}

	internal SparklineGroup(SparklineGroupCollection sparklineGroupCollection_1)
	{
		sparklineGroupCollection_0 = sparklineGroupCollection_1;
		sparklineCollection_0 = new SparklineCollection(this);
	}

	/// <summary>
	///       Resets the data range and location range of the sparkline group. 
	///       This method will clear original sparkline items in the group and creates new sparkline items for the new ranges.
	///       </summary>
	/// <param name="dataRange">Specifies the new data range of the sparkline group.</param>
	/// <param name="isVertical">Specifies whether to plot the sparklines from the new data range by row or by column.</param>
	/// <param name="locationRange">Specifies where the sparklines to be placed.</param>
	public void ResetRanges(string dataRange, bool isVertical, CellArea locationRange)
	{
		sparklineCollection_0.Reset(dataRange, isVertical, locationRange);
	}

	internal Class1309 method_0()
	{
		return class1309_0;
	}

	internal int InsertRows(Cells cells_0, int int_0, int int_1, bool bool_9)
	{
		return sparklineCollection_0.InsertRows(cells_0, int_0, int_1, bool_9);
	}

	internal int InsertColumns(Cells cells_0, int int_0, int int_1, bool bool_9)
	{
		return sparklineCollection_0.InsertColumns(cells_0, int_0, int_1, bool_9);
	}

	internal void Copy(SparklineGroup sparklineGroup_0, CopyOptions copyOptions_0)
	{
		bool_0 = sparklineGroup_0.bool_0;
		cellsColor_3 = method_1(sparklineGroup_0.cellsColor_3, copyOptions_0);
		cellsColor_0 = method_1(sparklineGroup_0.cellsColor_0, copyOptions_0);
		cellsColor_7 = method_1(sparklineGroup_0.cellsColor_7, copyOptions_0);
		class1309_0 = sparklineGroup_0.class1309_0;
		cellsColor_4 = method_1(sparklineGroup_0.cellsColor_4, copyOptions_0);
		double_0 = sparklineGroup_0.double_0;
		cellsColor_1 = method_1(sparklineGroup_0.cellsColor_1, copyOptions_0);
		cellsColor_5 = method_1(sparklineGroup_0.cellsColor_5, copyOptions_0);
		cellsColor_2 = method_1(sparklineGroup_0.cellsColor_2, copyOptions_0);
		plotEmptyCellsType_0 = sparklineGroup_0.plotEmptyCellsType_0;
		bool_7 = sparklineGroup_0.bool_7;
		cellsColor_6 = method_1(sparklineGroup_0.cellsColor_6, copyOptions_0);
		bool_4 = sparklineGroup_0.bool_4;
		bool_1 = sparklineGroup_0.bool_1;
		bool_8 = sparklineGroup_0.bool_8;
		bool_5 = sparklineGroup_0.bool_5;
		bool_2 = sparklineGroup_0.bool_2;
		bool_6 = sparklineGroup_0.bool_6;
		bool_3 = sparklineGroup_0.bool_3;
		sparklineType_0 = sparklineGroup_0.sparklineType_0;
		double_1 = sparklineGroup_0.double_1;
		sparklineAxisMinMaxType_0 = sparklineGroup_0.sparklineAxisMinMaxType_0;
		double_2 = sparklineGroup_0.double_2;
		sparklineAxisMinMaxType_1 = sparklineGroup_0.sparklineAxisMinMaxType_1;
		for (int i = 0; i < sparklineGroup_0.sparklineCollection_0.Count; i++)
		{
			Sparkline sparkline_ = sparklineGroup_0.sparklineCollection_0[i];
			Sparkline sparkline = new Sparkline(sparklineCollection_0);
			sparklineCollection_0.method_2(sparkline);
			sparkline.Copy(sparkline_, copyOptions_0);
		}
	}

	private CellsColor method_1(CellsColor cellsColor_8, CopyOptions copyOptions_0)
	{
		if (cellsColor_8 == null)
		{
			return null;
		}
		CellsColor cellsColor = sparklineGroupCollection_0.method_0().Workbook.CreateCellsColor();
		cellsColor.Copy(cellsColor_8, copyOptions_0);
		return cellsColor;
	}
}
