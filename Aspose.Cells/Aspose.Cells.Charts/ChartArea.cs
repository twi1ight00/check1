using System.Runtime.CompilerServices;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Encapsulates the object that represents the chart area in the worksheet.
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
///       int chartIndex = worksheet.Charts.Add(ChartType.Column, 5, 0, 15, 5);
///
///       //Accessing the instance of the newly added chart
///       Chart chart = worksheet.Charts[chartIndex];
///
///       //Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B3"
///       chart.NSeries.Add("A1:B3", true);
///
///       //Getting Chart Area
///       ChartArea chartArea = chart.ChartArea;
///
///       //Setting the foreground color of the chart area
///       chartArea.Area.ForegroundColor = Color.Yellow;
///
///       //Setting Chart Area Shadow
///       chartArea.Shadow = true;
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
///       Dim chartIndex As Integer = worksheet.Charts.Add(ChartType.Column, 5, 0, 15, 5)
///
///       'Accessing the instance of the newly added chart
///       Dim chart As Chart = worksheet.Charts(chartIndex)
///
///       'Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B3"
///       chart.NSeries.Add("A1:B3", True)
///
///       'Getting Chart Area
///       Dim chartArea As ChartArea = chart.ChartArea
///
///       'Setting the foreground color of the chart area
///       chartArea.Area.ForegroundColor = Color.Yellow
///
///       'Setting Chart Area Shadow
///       chartArea.Shadow = True
///
///       'Saving the Excel file
///       workbook.Save("D:\book1.xls")
///       </code>
/// </example>
public class ChartArea : ChartFrame
{
	private int int_12 = -1;

	/// <summary>
	///       Gets or gets the horizontal offset from its upper left corner column.
	///       </summary>
	public override int X
	{
		get
		{
			return method_23();
		}
		set
		{
			if (value >= 0 && value <= 4000)
			{
				method_22(value);
			}
		}
	}

	/// <summary>
	///       Gets or gets the vertical offset from its upper left corner row.		
	///       </summary>
	public override int Y
	{
		get
		{
			return method_25();
		}
		set
		{
			if (value >= 0 && value <= 4000)
			{
				method_24(value);
			}
		}
	}

	/// <summary>
	///       Gets or sets the vertical offset from its lower right corner row.		
	///       </summary>
	public override int Height
	{
		get
		{
			return method_26();
		}
		set
		{
			if (value >= 0 && value <= 4000)
			{
				method_27(value);
			}
		}
	}

	/// <summary>
	///       Gets or sets the horizontal offset from its lower right corner column.		
	///       </summary>
	public override int Width
	{
		get
		{
			return method_29();
		}
		set
		{
			if (value >= 0 && value <= 4000)
			{
				method_28(value);
			}
		}
	}

	public override Font Font
	{
		get
		{
			if (m_font == null)
			{
				m_font = new Font(base.Chart.method_14(), null, bool_0: true);
				m_font.method_15(10.0);
				if (m_fontIndex != -1)
				{
					Font font_ = base.Chart.method_14().method_53(m_fontIndex);
					m_font.Copy(font_);
					m_font.InternalColor.IsShapeColor = true;
					Class1383 @class = base.Chart.method_41(m_fontIndex);
					if (@class != null)
					{
						Class1383 class2 = new Class1383(@class.chart_0, 0, bool_0: false);
						class2.Copy(@class);
						m_font.method_5(class2);
					}
					else if (m_AutoScaleFont)
					{
						m_font.method_5(new Class1383(base.Chart, 10, bool_0: true));
					}
				}
				else if (m_AutoScaleFont)
				{
					m_font.method_5(new Class1383(base.Chart, 10, bool_0: true));
				}
			}
			return m_font;
		}
	}

	internal ChartArea(Chart chart_1)
		: base(chart_1)
	{
		method_8(Enum18.const_0);
	}

	[SpecialName]
	internal int method_39()
	{
		return int_12;
	}

	[SpecialName]
	internal void method_40(int int_13)
	{
		int_12 = int_13;
	}

	internal void Copy(ChartArea chartArea_0)
	{
		Copy((ChartFrame)chartArea_0);
	}
}
