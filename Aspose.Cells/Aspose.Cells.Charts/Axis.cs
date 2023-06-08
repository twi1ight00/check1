using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns21;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Encapsulates the object that represents a chart's axis.
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
///       //Adding a sample value to "B1" cell
///       worksheet.Cells["B1"].PutValue(4);
///       //Adding a sample value to "B2" cell
///       worksheet.Cells["B2"].PutValue(20);
///       //Adding a sample value to "B3" cell
///       worksheet.Cells["B3"].PutValue(50);
///       //Adding a chart to the worksheet
///       int chartIndex = worksheet.Charts.Add(ChartType.Column, 5, 0, 25, 5);
///       //Accessing the instance of the newly added chart
///       Chart chart = worksheet.Charts[chartIndex];
///       //Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B3"
///       chart.NSeries.Add("A1:B3", true);
///       //Set the max value of value axis
///       chart.ValueAxis.MaxValue = 200;
///       //Set the min value of value axis
///       chart.ValueAxis.MinValue = 0;
///       //Set the major unit
///       chart.ValueAxis.MajorUnit = 25;
///       //Category(X) axis crosses at the maxinum value.
///       chart.ValueAxis.Crosses = CrossType.Maximum;
///       //Set he number of categories or series between tick-mark labels. 
///       chart.CategoryAxis.TickLabelSpacing = 2;
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
///       'Adding a sample value to "B1" cell
///       worksheet.Cells("B1").PutValue(4)
///       'Adding a sample value to "B2" cell
///       worksheet.Cells("B2").PutValue(20)
///       'Adding a sample value to "B3" cell
///       worksheet.Cells("B3").PutValue(50)
///       'Adding a chart to the worksheet
///       Dim chartIndex As Int32 = worksheet.Charts.Add(ChartType.Column, 5, 0, 25, 5)
///       'Accessing the instance of the newly added chart
///       Dim chart As Chart = worksheet.Charts(chartIndex)
///       'Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B3"
///       chart.NSeries.Add("A1:B3", True)
///       'Set the max value of value axis
///       chart.ValueAxis.MaxValue = 200
///       'Set the min value of value axis
///       chart.ValueAxis.MinValue = 0
///       'Set the major unit
///       chart.ValueAxis.MajorUnit = 25
///       'Category(X) axis crosses at the maxinum value.
///       chart.ValueAxis.Crosses = CrossType.Maximum
///       'Set he number of categories or series between tick-mark labels. 
///       chart.CategoryAxis.TickLabelSpacing = 2
///       'Saving the Excel file
///       workbook.Save("C:\book1.xls")
///       </code>
/// </example>
public class Axis
{
	internal ArrayList arrayList_0;

	private Chart chart_0;

	private Enum195 enum195_0;

	internal string string_0 = "";

	internal string string_1 = "";

	private Enum17 enum17_0 = Enum17.const_3;

	private Area area_0;

	private object object_0;

	private bool bool_0 = true;

	private bool bool_1 = true;

	private object object_1;

	private bool bool_2 = true;

	private double double_0;

	private bool bool_3 = true;

	private double double_1;

	private Line line_0;

	private TickMarkType tickMarkType_0 = TickMarkType.Inside;

	private TickMarkType tickMarkType_1 = TickMarkType.None;

	private TickLabelPositionType tickLabelPositionType_0 = TickLabelPositionType.NextToAxis;

	private double double_2;

	internal bool bool_4;

	private CrossType crossType_0;

	private bool bool_5;

	private double double_3 = 10.0;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8 = true;

	private TickLabels tickLabels_0;

	private int int_0 = 1;

	private bool bool_9 = true;

	private int int_1 = 1;

	private DisplayUnitType displayUnitType_0;

	private DisplayUnitLabel displayUnitLabel_0;

	private bool bool_10 = true;

	private Title title_0;

	internal bool bool_11;

	private CategoryType categoryType_0;

	private TimeUnit timeUnit_0;

	private bool bool_12 = true;

	private TimeUnit timeUnit_1;

	private TimeUnit timeUnit_2;

	private bool bool_13;

	private Line line_1;

	private Line line_2;

	private bool bool_14 = true;

	private ShapePropertyCollection shapePropertyCollection_0;

	private ShapePropertyCollection shapePropertyCollection_1;

	private ShapePropertyCollection shapePropertyCollection_2;

	/// <summary>
	///       Gets the <see cref="P:Aspose.Cells.Charts.Axis.Area" />.
	///       </summary>
	public Area Area
	{
		get
		{
			if (area_0 == null)
			{
				area_0 = new Area(chart_0, this);
			}
			return area_0;
		}
	}

	/// <summary>
	///       Indicates whether the min value is automatically assigned.
	///       </summary>
	public bool IsAutomaticMinValue
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
	///       Represents the minimum value on the value axis.
	///       </summary>
	/// <remarks>
	///       The minValue type only can be double or DateTime
	///       </remarks>
	public object MinValue
	{
		get
		{
			return object_0;
		}
		set
		{
			if (value == null)
			{
				bool_0 = true;
				return;
			}
			Type type = value.GetType();
			switch (System.Type.GetTypeCode(type))
			{
			default:
				throw new CellsException(ExceptionType.DataType, "MinValue should be numeric or Date values.");
			case TypeCode.SByte:
				object_0 = (double)(sbyte)value;
				bool_0 = false;
				break;
			case TypeCode.Byte:
				object_0 = (double)(int)(byte)value;
				bool_0 = false;
				break;
			case TypeCode.Int16:
				object_0 = (double)(short)value;
				bool_0 = false;
				break;
			case TypeCode.UInt16:
				object_0 = (double)(int)(ushort)value;
				bool_0 = false;
				break;
			case TypeCode.Int32:
				object_0 = (double)(int)value;
				bool_0 = false;
				break;
			case TypeCode.UInt32:
				object_0 = (double)(uint)value;
				bool_0 = false;
				break;
			case TypeCode.Int64:
				object_0 = (double)(long)value;
				bool_0 = false;
				break;
			case TypeCode.UInt64:
				object_0 = (double)(ulong)value;
				bool_0 = false;
				break;
			case TypeCode.Single:
				object_0 = (double)(float)value;
				bool_0 = false;
				break;
			case TypeCode.Decimal:
				object_0 = (double)(decimal)value;
				bool_0 = false;
				break;
			case TypeCode.Double:
			case TypeCode.DateTime:
				object_0 = value;
				bool_0 = false;
				break;
			}
		}
	}

	/// <summary>
	///       Indicates whether the max value is automatically assigned.
	///       </summary>
	public bool IsAutomaticMaxValue
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
	///       Represents the maximum value on the value axis.
	///       </summary>
	/// <remarks>
	///       The maxValue type only can be double or DateTime
	///       </remarks>
	public object MaxValue
	{
		get
		{
			return object_1;
		}
		set
		{
			if (value == null)
			{
				bool_1 = true;
				return;
			}
			Type type = value.GetType();
			switch (System.Type.GetTypeCode(type))
			{
			default:
				throw new CellsException(ExceptionType.DataType, "MaxValue should be numeric or Date values.");
			case TypeCode.SByte:
				object_1 = (double)(sbyte)value;
				bool_1 = false;
				break;
			case TypeCode.Byte:
				object_1 = (double)(int)(byte)value;
				bool_1 = false;
				break;
			case TypeCode.Int16:
				object_1 = (double)(short)value;
				bool_1 = false;
				break;
			case TypeCode.UInt16:
				object_1 = (double)(int)(ushort)value;
				bool_1 = false;
				break;
			case TypeCode.Int32:
				object_1 = (double)(int)value;
				bool_1 = false;
				break;
			case TypeCode.UInt32:
				object_1 = (double)(uint)value;
				bool_1 = false;
				break;
			case TypeCode.Int64:
				object_1 = (double)(long)value;
				bool_1 = false;
				break;
			case TypeCode.UInt64:
				object_1 = (double)(ulong)value;
				bool_1 = false;
				break;
			case TypeCode.Single:
				object_1 = (double)(float)value;
				bool_1 = false;
				break;
			case TypeCode.Decimal:
				object_1 = (double)(decimal)value;
				bool_1 = false;
				break;
			case TypeCode.Double:
			case TypeCode.DateTime:
				object_1 = value;
				bool_1 = false;
				break;
			}
		}
	}

	/// <summary>
	///       Indicates whether the major unit of the axis is automatically assigned.
	///       </summary>
	public bool IsAutomaticMajorUnit
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
	///       Represents the major units for the axis.
	///       </summary>
	/// <remarks> The major units must be greater than zero.</remarks>
	public double MajorUnit
	{
		get
		{
			return double_0;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentException("Invalid major unit: it must be greated than zero.");
			}
			double_0 = value;
			bool_2 = false;
		}
	}

	/// <summary>
	///       Indicates whether the minor unit of the axis is automatically assigned.
	///       </summary>
	public bool IsAutomaticMinorUnit
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
	///       Represents the minor units for the axis.
	///       </summary>
	/// <remarks> The minor units must be greater than zero.</remarks>
	public double MinorUnit
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentException("Invalid minor unit: it must be greated than zero.");
			}
			double_1 = value;
			bool_3 = false;
		}
	}

	/// <summary>
	///       Gets the appearance of an Axis.
	///       </summary>
	public Line AxisLine
	{
		get
		{
			if (line_0 == null)
			{
				line_0 = new Line(chart_0, this);
			}
			return line_0;
		}
	}

	/// <summary>
	///       Represents the type of major tick mark for the specified axis.
	///       </summary>
	public TickMarkType MajorTickMark
	{
		get
		{
			return tickMarkType_0;
		}
		set
		{
			tickMarkType_0 = value;
			bool_5 = true;
		}
	}

	/// <summary>
	///       Represents the type of minor tick mark for the specified axis.
	///       </summary>
	public TickMarkType MinorTickMark
	{
		get
		{
			return tickMarkType_1;
		}
		set
		{
			tickMarkType_1 = value;
			bool_5 = true;
		}
	}

	/// <summary>
	///       Represents the position of tick-mark labels on the specified axis.
	///       </summary>
	public TickLabelPositionType TickLabelPosition
	{
		get
		{
			return tickLabelPositionType_0;
		}
		set
		{
			tickLabelPositionType_0 = value;
			bool_5 = true;
		}
	}

	/// <summary>
	///       Represents the point on the value axis where the category axis crosses it.
	///       </summary>
	/// <remarks>The number should be a integer when it applies to category axis.
	///       And the value must be between 1 and 31999.</remarks>
	public double CrossAt
	{
		get
		{
			return double_2;
		}
		set
		{
			bool_4 = false;
			switch (enum195_0)
			{
			case Enum195.const_0:
			{
				if (ChartCollection.smethod_12(chart_0.Type))
				{
					double_2 = value;
					crossType_0 = CrossType.Custom;
					break;
				}
				int num = (int)value;
				if (num >= 1 && num <= 31999)
				{
					double_2 = num;
					crossType_0 = CrossType.Custom;
				}
				break;
			}
			case Enum195.const_1:
				double_2 = value;
				crossType_0 = CrossType.Custom;
				break;
			}
		}
	}

	/// <summary>
	///       Represents the <see cref="P:Aspose.Cells.Charts.Axis.CrossType" /> on the specified axis where the other axis crosses. 
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Axis.CrossType property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Aixs.CrossType property instead.")]
	[Browsable(false)]
	public CrossType Crosses
	{
		get
		{
			return crossType_0;
		}
		set
		{
			crossType_0 = value;
			if (value != 0)
			{
				bool_4 = false;
			}
		}
	}

	/// <summary>
	///       Represents the <see cref="P:Aspose.Cells.Charts.Axis.CrossType" /> on the specified axis where the other axis crosses. 
	///       </summary>
	public CrossType CrossType
	{
		get
		{
			return crossType_0;
		}
		set
		{
			crossType_0 = value;
		}
	}

	/// <summary>
	///       Represents the logarithmic base. Default value is 10.Only applies for Excel2007.
	///       </summary>
	public double LogBase
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	/// <summary>
	///       Represents if the value axis scale type is logarithmic or not.
	///       </summary>
	public bool IsLogarithmic
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
	///       Represents if Microsoft Excel plots data points from last to first.
	///       </summary>
	public bool IsPlotOrderReversed
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
	///       Represents if the value axis crosses the category axis between categories.
	///       </summary>
	/// <remarks>This property applies only to category axes, and it doesn't apply to 3-D charts.
	///       </remarks>
	public bool AxisBetweenCategories
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
	///       Returns a <see cref="P:Aspose.Cells.Charts.Axis.TickLabels" /> object that represents the tick-mark labels for the specified axis.
	///       </summary>
	public TickLabels TickLabels
	{
		get
		{
			if (tickLabels_0 == null)
			{
				tickLabels_0 = new TickLabels(this);
				bool_5 = true;
			}
			return tickLabels_0;
		}
	}

	/// <summary>
	///       Represents the number of categories or series between tick-mark labels. Applies only to category and series axes.
	///       </summary>
	/// <remarks>The number must be between 1 and 31999.</remarks>
	public int TickLabelSpacing
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 1 || value > 31999)
			{
				throw new ArgumentException("Invalid tick label spacing : it must be between 1 and 31999.");
			}
			int_0 = value;
			bool_9 = false;
		}
	}

	/// <summary>
	///       Returns or sets the number of categories or series between tick marks. Applies only to category and series axes. 
	///       </summary>
	/// <remarks>The number must be between 1 and 31999.</remarks>
	public int TickMarkSpacing
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value >= 1 && value <= 31999)
			{
				int_1 = value;
			}
		}
	}

	/// <summary>
	///       Represents the unit label for the specified axis. 
	///       </summary>
	public DisplayUnitType DisplayUnit
	{
		get
		{
			return displayUnitType_0;
		}
		set
		{
			if (displayUnitType_0 == value)
			{
				return;
			}
			if (value == DisplayUnitType.None)
			{
				displayUnitLabel_0 = null;
				displayUnitType_0 = value;
				return;
			}
			if (displayUnitType_0 == DisplayUnitType.None && bool_10)
			{
				displayUnitLabel_0 = new DisplayUnitLabel(this);
			}
			displayUnitType_0 = value;
		}
	}

	/// <summary>
	///       Represents a unit label on an axis in the specified chart. 
	///       Unit labels are useful for charting large values— for example, in the millions or billions. 
	///       </summary>
	public DisplayUnitLabel DisplayUnitLabel
	{
		get
		{
			if (displayUnitLabel_0 == null)
			{
				displayUnitLabel_0 = new DisplayUnitLabel(this);
			}
			return displayUnitLabel_0;
		}
	}

	/// <summary>
	///       Represents if the display unit label is shown on the specified axis. 
	///       </summary>
	/// <remarks>The default value is True.</remarks>
	public bool IsDisplayUnitLabelShown
	{
		get
		{
			return bool_10;
		}
		set
		{
			if (value && displayUnitLabel_0 == null)
			{
				displayUnitLabel_0 = new DisplayUnitLabel(this);
			}
			bool_10 = value;
		}
	}

	/// <summary>
	///       Gets the axis' title.
	///       </summary>
	public Title Title
	{
		get
		{
			if (title_0 == null)
			{
				title_0 = new Title(this);
				if (enum195_0 == Enum195.const_1)
				{
					title_0.RotationAngle = 90;
				}
				title_0.Border.IsVisible = false;
				title_0.Area.Formatting = FormattingType.None;
			}
			return title_0;
		}
	}

	/// <summary>
	///       Represents the category axis type.
	///       </summary>
	public CategoryType CategoryType
	{
		get
		{
			return categoryType_0;
		}
		set
		{
			categoryType_0 = value;
		}
	}

	/// <summary>
	///       Represents the base unit scale for the category axis.
	///       </summary>
	/// <remarks>Setting this property only takes effect when the CategoryType property is set to TimeScale.</remarks>
	public TimeUnit BaseUnitScale
	{
		get
		{
			return timeUnit_0;
		}
		set
		{
			timeUnit_0 = value;
			bool_12 = false;
		}
	}

	/// <summary>
	///       Represents the major unit scale for the category axis.
	///       </summary>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       chart.CategoryAxis.CategoryType = CategoryType.TimeScale;
	///       chart.CategoryAxis.MajorUnitScale = TimeUnit.Months;
	///       chart.CategoryAxis.MajorUnit = 2;
	///
	///       [Visual Basic]
	///       chart.CategoryAxis.CategoryType = CategoryType.TimeScale
	///       chart.CategoryAxis.MajorUnitScale = TimeUnit.Months
	///       chart.CategoryAxis.MajorUnit = 2
	///       </code>
	/// </example>
	public TimeUnit MajorUnitScale
	{
		get
		{
			return timeUnit_1;
		}
		set
		{
			timeUnit_1 = value;
			bool_2 = false;
			if (double_0 == 0.0)
			{
				double_0 = 1.0;
			}
		}
	}

	/// <summary>
	///       Represents the major unit scale for the category axis.
	///       </summary>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       chart.CategoryAxis.CategoryType = CategoryType.TimeScale;
	///       chart.CategoryAxis.MinorUnitScale = TimeUnit.Months;
	///       chart.CategoryAxis.MinorUnit = 2;
	///
	///       [Visual Basic]
	///       chart.CategoryAxis.CategoryType = CategoryType.TimeScale
	///       chart.CategoryAxis.MinorUnitScale = TimeUnit.Months
	///       chart.CategoryAxis.MinorUnit = 2
	///       </code>
	/// </example>
	public TimeUnit MinorUnitScale
	{
		get
		{
			return timeUnit_2;
		}
		set
		{
			timeUnit_2 = value;
			bool_3 = false;
			if (double_0 == 0.0)
			{
				double_0 = 1.0;
			}
		}
	}

	/// <summary>
	///       Represents if the axis is visible.
	///       </summary>
	public bool IsVisible
	{
		get
		{
			return bool_13;
		}
		set
		{
			bool_13 = value;
		}
	}

	/// <summary>
	///       Represents major gridlines on a chart axis.
	///       </summary>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       chart.ValueAxis.MajorGridLines.IsVisible = false;
	///       chart.CategoryAxis.MajorGridLines.IsVisible = true;
	///
	///       [Visual Basic]
	///       chart.ValueAxis.MajorGridLines.IsVisible = false
	///       chart.CategoryAxis.MajorGridLines.IsVisible = true
	///       </code>
	/// </example>
	public Line MajorGridLines
	{
		get
		{
			if (line_1 == null)
			{
				line_1 = new Line(chart_0, this);
				line_1.IsVisible = false;
			}
			return line_1;
		}
	}

	/// <summary>
	///       Represents minor gridlines on a chart axis.
	///       </summary>
	public Line MinorGridLines
	{
		get
		{
			if (line_2 == null)
			{
				line_2 = new Line(chart_0, this);
				line_2.IsVisible = false;
			}
			return line_2;
		}
	}

	/// <summary>
	///       Indicates whether the labels shall be shown as multi level.
	///       </summary>
	/// <remarks>
	///       Only valid for category axis.
	///       </remarks>
	public bool HasMultiLevelLabels
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	internal Chart Chart => chart_0;

	internal Enum195 Type
	{
		get
		{
			return enum195_0;
		}
		set
		{
			enum195_0 = value;
		}
	}

	internal ShapePropertyCollection ShapeProperties
	{
		get
		{
			if (shapePropertyCollection_0 == null)
			{
				shapePropertyCollection_0 = new ShapePropertyCollection(chart_0, this, Enum178.const_0);
			}
			return shapePropertyCollection_0;
		}
	}

	internal Axis(Enum195 enum195_1, bool bool_15, Chart chart_1)
	{
		chart_0 = chart_1;
		enum195_0 = enum195_1;
		if (enum195_1 == Enum195.const_0)
		{
			double_2 = 1.0;
		}
		IsVisible = bool_15;
	}

	[SpecialName]
	internal Enum17 method_0()
	{
		return enum17_0;
	}

	[SpecialName]
	internal void method_1(Enum17 enum17_1)
	{
		enum17_0 = enum17_1;
	}

	internal Area method_2()
	{
		return area_0;
	}

	[SpecialName]
	internal bool method_3()
	{
		return bool_0;
	}

	internal void method_4(object object_2)
	{
		object_0 = object_2;
	}

	internal void method_5(object object_2)
	{
		object_1 = object_2;
	}

	[SpecialName]
	internal bool method_6()
	{
		return bool_1;
	}

	[SpecialName]
	internal bool method_7()
	{
		return bool_2;
	}

	internal void method_8(double double_4)
	{
		double_0 = double_4;
	}

	[SpecialName]
	internal bool method_9()
	{
		return bool_3;
	}

	internal void method_10(double double_4)
	{
		double_1 = double_4;
	}

	internal Line method_11()
	{
		return line_0;
	}

	internal void method_12(double double_4)
	{
		double_2 = double_4;
		crossType_0 = CrossType.Custom;
		bool_4 = false;
	}

	[SpecialName]
	internal bool method_13()
	{
		return bool_5;
	}

	internal TickLabels method_14()
	{
		return tickLabels_0;
	}

	internal void method_15(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	internal bool method_16()
	{
		return bool_9;
	}

	[SpecialName]
	internal void method_17(bool bool_15)
	{
		bool_9 = bool_15;
	}

	internal DisplayUnitLabel method_18()
	{
		return displayUnitLabel_0;
	}

	internal void method_19(bool bool_15)
	{
		bool_10 = bool_15;
	}

	internal Title method_20()
	{
		return title_0;
	}

	internal void method_21(TimeUnit timeUnit_3)
	{
		timeUnit_0 = timeUnit_3;
	}

	[SpecialName]
	internal bool method_22()
	{
		return bool_12;
	}

	[SpecialName]
	internal void method_23(bool bool_15)
	{
		bool_12 = bool_15;
	}

	internal void method_24(TimeUnit timeUnit_3)
	{
		timeUnit_1 = timeUnit_3;
	}

	internal void method_25(TimeUnit timeUnit_3)
	{
		timeUnit_2 = timeUnit_3;
	}

	internal void Copy(Axis axis_0, CopyOptions copyOptions_0)
	{
		enum195_0 = axis_0.enum195_0;
		if (axis_0.line_0 != null)
		{
			AxisLine.Copy(axis_0.line_0);
		}
		else
		{
			line_0 = null;
		}
		bool_14 = axis_0.bool_14;
		bool_13 = axis_0.bool_13;
		object_1 = axis_0.object_1;
		object_0 = axis_0.object_0;
		double_0 = axis_0.double_0;
		double_1 = axis_0.double_1;
		bool_2 = axis_0.bool_2;
		bool_3 = axis_0.bool_3;
		bool_0 = axis_0.bool_0;
		bool_1 = axis_0.bool_1;
		tickMarkType_0 = axis_0.tickMarkType_0;
		tickMarkType_1 = axis_0.tickMarkType_1;
		bool_5 = axis_0.bool_5;
		tickLabelPositionType_0 = axis_0.tickLabelPositionType_0;
		double_2 = axis_0.double_2;
		crossType_0 = axis_0.crossType_0;
		bool_6 = axis_0.bool_6;
		bool_7 = axis_0.bool_7;
		bool_8 = axis_0.bool_8;
		if (axis_0.tickLabels_0 != null)
		{
			tickLabels_0 = new TickLabels(this);
			tickLabels_0.Copy(axis_0.tickLabels_0);
		}
		else
		{
			tickLabels_0 = null;
		}
		int_0 = axis_0.int_0;
		int_1 = axis_0.int_1;
		displayUnitType_0 = axis_0.displayUnitType_0;
		bool_10 = axis_0.bool_10;
		if (axis_0.displayUnitLabel_0 != null)
		{
			DisplayUnitLabel.Copy(axis_0.displayUnitLabel_0);
		}
		else
		{
			displayUnitLabel_0 = null;
		}
		if (axis_0.title_0 != null)
		{
			title_0 = new Title(this);
			title_0.Copy(axis_0.title_0, copyOptions_0);
		}
		else
		{
			title_0 = null;
		}
		categoryType_0 = axis_0.categoryType_0;
		timeUnit_0 = axis_0.timeUnit_0;
		bool_12 = axis_0.bool_12;
		timeUnit_1 = axis_0.timeUnit_1;
		timeUnit_2 = axis_0.timeUnit_2;
		if (axis_0.line_1 != null)
		{
			line_1 = new Line(chart_0, this);
			line_1.Copy(axis_0.line_1);
		}
		else
		{
			line_1 = null;
		}
		if (axis_0.line_2 != null)
		{
			MinorGridLines.Copy(axis_0.line_2);
		}
		else
		{
			line_2 = null;
		}
		if (axis_0.shapePropertyCollection_0 != null)
		{
			shapePropertyCollection_0 = new ShapePropertyCollection(chart_0, this, Enum178.const_0);
			shapePropertyCollection_0.Copy(axis_0.shapePropertyCollection_0);
		}
		if (axis_0.shapePropertyCollection_1 != null)
		{
			shapePropertyCollection_1 = new ShapePropertyCollection(chart_0, this, Enum178.const_1);
			shapePropertyCollection_1.Copy(axis_0.shapePropertyCollection_1);
		}
		if (axis_0.shapePropertyCollection_2 != null)
		{
			shapePropertyCollection_2 = new ShapePropertyCollection(chart_0, this, Enum178.const_2);
			shapePropertyCollection_2.Copy(axis_0.shapePropertyCollection_2);
		}
	}

	internal Line method_26()
	{
		return line_1;
	}

	internal void method_27(Line line_3)
	{
		line_1 = line_3;
	}

	internal Line method_28()
	{
		return line_2;
	}

	internal void method_29(Line line_3)
	{
		line_2 = line_3;
	}

	[SpecialName]
	internal bool method_30()
	{
		return enum195_0 switch
		{
			Enum195.const_0 => chart_0.CategoryAxis == this, 
			Enum195.const_1 => chart_0.ValueAxis == this, 
			_ => true, 
		};
	}

	[SpecialName]
	internal ShapePropertyCollection method_31()
	{
		if (shapePropertyCollection_1 == null)
		{
			shapePropertyCollection_1 = new ShapePropertyCollection(chart_0, this, Enum178.const_1);
		}
		return shapePropertyCollection_1;
	}

	[SpecialName]
	internal ShapePropertyCollection method_32()
	{
		if (shapePropertyCollection_2 == null)
		{
			shapePropertyCollection_2 = new ShapePropertyCollection(chart_0, this, Enum178.const_2);
		}
		return shapePropertyCollection_2;
	}
}
