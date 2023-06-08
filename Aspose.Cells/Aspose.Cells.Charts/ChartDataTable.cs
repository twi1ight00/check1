using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns21;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Represents a chart data table.
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
///       int chartIndex = worksheet.Charts.Add(ChartType.Column, 5, 0, 25, 10);
///
///       //Accessing the instance of the newly added chart
///       Chart chart = worksheet.Charts[chartIndex];
///
///       //Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B3"
///       chart.NSeries.Add("A1:B3", true);
///
///       chart.IsDataTableShown = true;
///
///       //Getting Chart Table
///       ChartDataTable chartTable = chart.ChartDataTable;
///
///       //Setting Chart Table Font Color
///       chartTable.Font.Color = System.Drawing.Color.Red;
///
///       //Setting Legend Key Visibility
///       chartTable.ShowLegendKey = false;
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
///       Dim chartIndex As Integer = worksheet.Charts.Add(ChartType.Column, 5, 0, 25, 10)
///
///       'Accessing the instance of the newly added chart
///       Dim chart As Chart = worksheet.Charts(chartIndex)
///
///       'Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B3"
///       chart.NSeries.Add("A1:B3", True)
///
///       chart.IsDataTableShown = True
///
///       'Getting Chart Table
///       Dim chartTable As ChartDataTable = chart.ChartDataTable
///
///       'Setting Chart Table Font Color
///       chartTable.Font.Color = System.Drawing.Color.Red
///
///       'Setting Legend Key Visibility
///       chartTable.ShowLegendKey = False
///
///       'Saving the Excel file
///       workbook.Save("D:\book1.xls")
///
///       </code>
/// </example>
public class ChartDataTable
{
	private Chart chart_0;

	private Font font_0;

	private int int_0 = -1;

	private bool bool_0 = true;

	private BackgroundMode backgroundMode_0;

	private bool bool_1 = true;

	private bool bool_2 = true;

	private bool bool_3 = true;

	private bool bool_4 = true;

	private Line line_0;

	private ShapePropertyCollection shapePropertyCollection_0;

	/// <summary>
	///       Gets a <see cref="P:Aspose.Cells.Charts.ChartDataTable.Font" /> object which represents the font setting of the specified chart data table.
	///       </summary>
	public Font Font
	{
		get
		{
			if (font_0 == null)
			{
				font_0 = new Font(chart_0.method_14(), null, bool_0: true);
				font_0.Size = 10;
				if (int_0 != -1)
				{
					Font font = (Font)chart_0.method_14().method_52()[(int_0 > 4) ? (int_0 - 1) : int_0];
					font_0.Copy(font);
					font_0.InternalColor.IsShapeColor = true;
					Class1383 @class = chart_0.method_41(int_0);
					if (@class != null)
					{
						Class1383 class2 = new Class1383(@class.chart_0, 0, bool_0: false);
						class2.Copy(@class);
						font_0.method_5(class2);
					}
				}
				else if (AutoScaleFont)
				{
					font_0.method_5(new Class1383(chart_0, font_0.Size, bool_0: true));
				}
			}
			return font_0;
		}
	}

	/// <summary>
	///       True if the text in the object changes font size when the object size changes. 
	///       The default value is True. 
	///       </summary>
	public bool AutoScaleFont
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (value)
			{
				if (font_0 != null)
				{
					Class1383 object_ = new Class1383(chart_0, font_0.Size, bool_0: true);
					font_0.method_5(object_);
				}
			}
			else
			{
				Font.method_5(null);
			}
			bool_0 = value;
		}
	}

	public BackgroundMode BackgroundMode
	{
		get
		{
			return backgroundMode_0;
		}
		set
		{
			backgroundMode_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets the display mode of the background
	///       </summary>
	[Obsolete("Use ChartDataTable.BackgroundMode property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BackgroundMode Background
	{
		get
		{
			return backgroundMode_0;
		}
		set
		{
			backgroundMode_0 = value;
		}
	}

	/// <summary>
	///       True if the chart data table has horizontal cell borders
	///       </summary>
	public bool HasBorderHorizontal
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
	///       True if the chart data table has vertical cell borders
	///       </summary>
	public bool HasBorderVertical
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
	///       True if the chart data table has outline borders
	///       </summary>
	public bool HasBorderOutline
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
	///       True if the data label legend key is visible.
	///       </summary>
	public bool ShowLegendKey
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
	///       Returns a Border object that represents the border of the object
	///       </summary>
	public Line Border
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

	internal ShapePropertyCollection ShapeProperties
	{
		get
		{
			if (shapePropertyCollection_0 == null)
			{
				shapePropertyCollection_0 = new ShapePropertyCollection(chart_0, this, Enum178.const_3);
			}
			return shapePropertyCollection_0;
		}
	}

	internal ChartDataTable(Chart chart_1)
	{
		chart_0 = chart_1;
	}

	internal void Copy(ChartDataTable chartDataTable_0)
	{
		bool_0 = chartDataTable_0.bool_0;
		int_0 = -1;
		backgroundMode_0 = chartDataTable_0.backgroundMode_0;
		if (chartDataTable_0.font_0 == null && chartDataTable_0.int_0 == -1)
		{
			font_0 = null;
		}
		else
		{
			font_0 = new Font(chart_0.method_14(), null, bool_0: true);
			font_0.Copy(chartDataTable_0.Font);
			if (chartDataTable_0.Font.method_4() != null && chartDataTable_0.bool_0)
			{
				Class1383 class1383_ = (Class1383)chartDataTable_0.Font.method_4();
				Class1383 @class = new Class1383(chart_0, 0, bool_0: false);
				@class.Copy(class1383_);
				font_0.method_5(@class);
			}
		}
		bool_1 = chartDataTable_0.bool_1;
		bool_3 = chartDataTable_0.bool_3;
		bool_2 = chartDataTable_0.bool_2;
		bool_4 = chartDataTable_0.bool_4;
		if (chartDataTable_0.line_0 != null)
		{
			line_0 = new Line(chart_0, this);
			line_0.Copy(chartDataTable_0.line_0);
		}
		else
		{
			line_0 = null;
		}
		if (chartDataTable_0.shapePropertyCollection_0 != null)
		{
			shapePropertyCollection_0 = new ShapePropertyCollection(chart_0, this, Enum178.const_3);
			shapePropertyCollection_0.Copy(chartDataTable_0.shapePropertyCollection_0);
		}
	}

	internal Font method_0()
	{
		if (font_0 == null && int_0 != -1)
		{
			return chart_0.method_14().method_53(int_0);
		}
		return font_0;
	}

	[SpecialName]
	internal int method_1()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_2(int int_1)
	{
		int_0 = int_1;
	}

	internal void method_3(bool bool_5)
	{
		bool_0 = bool_5;
	}

	internal Line method_4()
	{
		return line_0;
	}
}
