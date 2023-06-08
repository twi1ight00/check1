using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;
using ns7;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Encapsulates the object that represents an area format.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///       //Adding a new worksheet to the Workbook object
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
///       worksheet.Cells["B1"].PutValue(60);
///       //Adding a sample value to "B2" cell
///       worksheet.Cells["B2"].PutValue(32);
///       //Adding a sample value to "B3" cell
///       worksheet.Cells["B3"].PutValue(50);
///       //Adding a chart to the worksheet
///       int chartIndex = worksheet.Charts.Add(ChartType.Column, 5, 0, 15, 5);
///       //Accessing the instance of the newly added chart
///       Chart chart = worksheet.Charts[chartIndex];
///       //Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B3"
///       chart.NSeries.Add("A1:B3", true);
///       //Setting the foreground color of the plot area
///       chart.PlotArea.Area.ForegroundColor = Color.Blue;
///       //Setting the foreground color of the chart area
///       chart.ChartArea.Area.ForegroundColor = Color.Yellow;
///       //Setting the foreground color of the 1st NSeries area
///       chart.NSeries[0].Area.ForegroundColor = Color.Red;
///       //Setting the foreground color of the area of the 1st NSeries point
///       chart.NSeries[0].Points[0].Area.ForegroundColor = Color.Cyan;
///       //Saving the Excel file
///       workbook.Save("C:\\book1.xls");
///
///       [Visual Basic]
///
///       'Instantiating a Workbook object
///       Dim workbook As Workbook = New Workbook()
///       'Adding a new worksheet to the Workbook object
///       Dim sheetIndex As Integer = workbook.Worksheets.Add()
///       'Obtaining the reference of the newly added worksheet by passing its sheet index
///       Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)
///       'Adding a sample value to "A1" cell
///       worksheet.Cells("A1").PutValue(50)
///       'Adding a sample value to "A2" cell
///       worksheet.Cells("A2").PutValue(100)
///       'Adding a sample value to "A3" cell
///       worksheet.Cells("A3").PutValue(150)
///       'Adding a sample value to "B1" cell
///       worksheet.Cells("B1").PutValue(60)
///       'Adding a sample value to "B2" cell
///       worksheet.Cells("B2").PutValue(32)
///       'Adding a sample value to "B3" cell
///       worksheet.Cells("B3").PutValue(50)
///       'Adding a chart to the worksheet
///       Dim chartIndex As Integer = worksheet.Charts.Add(ChartType.Column, 5, 0, 15, 5)
///       'Accessing the instance of the newly added chart
///       Dim chart As Chart = worksheet.Charts(chartIndex)
///       'Adding NSeries (chart data source) to the chart ranging from "A1" cell to "B3"
///       chart.NSeries.Add("A1:B3", True)
///       'Setting the foreground color of the plot area
///       chart.PlotArea.Area.ForegroundColor = Color.Blue
///       'Setting the foreground color of the chart area
///       chart.ChartArea.Area.ForegroundColor = Color.Yellow
///       'Setting the foreground color of the 1st NSeries area
///       chart.NSeries(0).Area.ForegroundColor = Color.Red
///       'Setting the foreground color of the area of the 1st NSeries point
///       chart.NSeries(0).Points(0).Area.ForegroundColor = Color.Cyan
///       'Saving the Excel file
///       workbook.Save("C:\book1.xls")
///       </code>
/// </example>
public class Area
{
	private Chart chart_0;

	internal object object_0;

	private bool bool_0;

	private FillFormat fillFormat_0;

	/// <summary>
	///       Gets or sets the background <see cref="T:System.Drawing.Color" /> of the <see cref="T:Aspose.Cells.Drawing.Area" />.
	///       </summary>
	public Color BackgroundColor
	{
		get
		{
			if (FillFormat.Type == FillType.Pattern)
			{
				return FillFormat.PatternFill.BackgroundColor;
			}
			if (FillFormat.Type == FillType.Solid)
			{
				return FillFormat.SolidFill.BackgroundColor;
			}
			return Color.Empty;
		}
		set
		{
			Formatting = FormattingType.Custom;
			if (FillFormat.Type == FillType.Pattern)
			{
				FillFormat.PatternFill.BackgroundColor = value;
			}
			else if (FillFormat.Type == FillType.Solid)
			{
				FillFormat.SolidFill.BackgroundColor = value;
			}
			method_1();
		}
	}

	/// <summary>
	///       Gets or sets the foreground <see cref="T:System.Drawing.Color" />.
	///       </summary>
	public Color ForegroundColor
	{
		get
		{
			if (FillFormat.Type == FillType.Solid)
			{
				return FillFormat.SolidFill.Color;
			}
			if (FillFormat.Type == FillType.Pattern)
			{
				return FillFormat.PatternFill.ForegroundColor;
			}
			return Color.Empty;
		}
		set
		{
			Formatting = FormattingType.Custom;
			if (FillFormat.Type == FillType.Solid)
			{
				FillFormat.SolidFill.Color = value;
			}
			else if (FillFormat.Type == FillType.Pattern)
			{
				FillFormat.PatternFill.ForegroundColor = value;
			}
			method_1();
		}
	}

	/// <summary>
	///       Represents the formatting of the area.
	///       </summary>
	public FormattingType Formatting
	{
		get
		{
			if (FillFormat.Type == FillType.Automatic)
			{
				return FormattingType.Automatic;
			}
			if (FillFormat.Type == FillType.None)
			{
				return FormattingType.None;
			}
			return FormattingType.Custom;
		}
		set
		{
			switch (value)
			{
			case FormattingType.Automatic:
				FillFormat.Type = FillType.Automatic;
				break;
			case FormattingType.None:
				FillFormat.Type = FillType.None;
				break;
			case FormattingType.Custom:
				if (FillFormat.Type == FillType.Automatic || FillFormat.Type == FillType.None)
				{
					FillFormat.Type = FillType.Solid;
				}
				break;
			}
			method_1();
		}
	}

	/// <summary>
	///       If the property is true and the value of chart point is a negative number,
	///       the foreground color and background color will be exchanged.
	///       </summary>
	/// <example>
	///   <code>
	///
	///       [C#]
	///
	///       //Instantiating a Workbook object
	///       Workbook workbook = new Workbook();
	///       //Adding a new worksheet to the Workbook object
	///       int sheetIndex = workbook.Worksheets.Add();
	///       //Obtaining the reference of the newly added worksheet by passing its sheet index
	///       Worksheet worksheet = workbook.Worksheets[sheetIndex];
	///       //Adding a sample value to "A1" cell
	///       worksheet.Cells["A1"].PutValue(50);
	///       //Adding a sample value to "A2" cell
	///       worksheet.Cells["A2"].PutValue(-100);
	///       //Adding a sample value to "A3" cell
	///       worksheet.Cells["A3"].PutValue(150);
	///       //Adding a chart to the worksheet
	///       int chartIndex = worksheet.Charts.Add(ChartType.Column, 5, 0, 15, 5);
	///       //Accessing the instance of the newly added chart
	///       Chart chart = worksheet.Charts[chartIndex];
	///       //Adding NSeries (chart data source) to the chart ranging from "A1" cell to "A3"
	///       chart.NSeries.Add("A1:A3", true);
	///       chart.NSeries[0].Area.InvertIfNegative = true;
	///       //Setting the foreground color of the 1st NSeries area
	///       chart.NSeries[0].Area.ForegroundColor = Color.Red;
	///       //Setting the background color of the 1st NSeries area.
	///       //The displayed area color of second chart point will be the background color.
	///       chart.NSeries[0].Area.BackgroundColor = Color.Yellow;
	///       //Saving the Excel file
	///       workbook.Save("C:\\book1.xls");
	///
	///       [Visual Basic]
	///
	///       'Instantiating a Workbook object
	///       Dim workbook As Workbook = New Workbook()
	///       'Adding a new worksheet to the Workbook object
	///       Dim sheetIndex As Integer = workbook.Worksheets.Add()
	///       'Obtaining the reference of the newly added worksheet by passing its sheet index
	///       Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)
	///       'Adding a sample value to "A1" cell
	///       worksheet.Cells("A1").PutValue(50)
	///       'Adding a sample value to "A2" cell
	///       worksheet.Cells("A2").PutValue(-100)
	///       'Adding a sample value to "A3" cell
	///       worksheet.Cells("A3").PutValue(150)
	///       'Adding a chart to the worksheet
	///       Dim chartIndex As Integer = worksheet.Charts.Add(ChartType.Column, 5, 0, 15, 5)
	///       'Accessing the instance of the newly added chart
	///       Dim chart As Chart = worksheet.Charts(chartIndex)
	///       'Adding NSeries (chart data source) to the chart ranging from "A1" cell to "A3"
	///       chart.NSeries.Add("A1:A3", True)
	///       chart.NSeries(0).Area.InvertIfNegative = True
	///       'Setting the foreground color of the 1st NSeries area
	///       chart.NSeries(0).Area.ForegroundColor = Color.Red
	///       'Setting the background color of the 1st NSeries area.
	///       'The displayed area color of second chart point will be the background color.
	///       chart.NSeries(0).Area.BackgroundColor = Color.Yellow
	///       'Saving the Excel file
	///       workbook.Save("C:\book1.xls")
	///
	///       </code>
	/// </example>
	public bool InvertIfNegative
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
	///       Represents a <seealso cref="P:Aspose.Cells.Drawing.Area.FillFormat" /> object that contains fill formatting properties for the specified chart or shape.
	///       </summary>
	public FillFormat FillFormat
	{
		get
		{
			if (fillFormat_0 == null)
			{
				fillFormat_0 = new FillFormat(this, chart_0.method_14().Workbook);
			}
			method_1();
			return fillFormat_0;
		}
	}

	/// <summary>
	///       Returns or sets the degree of transparency of the area as a value from 0.0 (opaque) through 1.0 (clear).
	///       </summary>
	public double Transparency
	{
		get
		{
			return Math.Round((double)(100 - method_3()) / 100.0, 2);
		}
		set
		{
			if (!(value < 0.0) && value <= 1.0)
			{
				int num = 100 - (int)(value * 100.0);
				method_4(num);
				if (fillFormat_0 == null || fillFormat_0.Type != FillType.Gradient)
				{
					return;
				}
				GradientFill gradientFill = fillFormat_0.GradientFill;
				if (gradientFill.GradientStops != null && gradientFill.GradientStops.Count > 0)
				{
					for (int i = 0; i < gradientFill.GradientStops.Count; i++)
					{
						gradientFill.GradientStops[i].method_3(num);
					}
				}
				return;
			}
			throw new CellsException(ExceptionType.InvalidData, "Transparency must between 0.0 (opaque) and 1.0 (clear)");
		}
	}

	internal Chart Chart => chart_0;

	internal Area(Chart chart_1, object object_1)
	{
		chart_0 = chart_1;
		object_0 = object_1;
	}

	[SpecialName]
	internal bool method_0()
	{
		if (fillFormat_0 != null)
		{
			if (fillFormat_0.Type != FillType.Pattern && fillFormat_0.Type != FillType.Texture)
			{
				return fillFormat_0.Type == FillType.Gradient;
			}
			return true;
		}
		return false;
	}

	internal void method_1()
	{
		if (object_0 != null)
		{
			if (object_0 is Class1632)
			{
				((Class1632)object_0).method_0(null);
			}
			else if (object_0 is ChartFrame)
			{
				((ChartFrame)object_0).method_0(null);
			}
		}
	}

	internal void method_2()
	{
		method_1();
	}

	[SpecialName]
	internal int method_3()
	{
		int result = 100;
		if (fillFormat_0 != null)
		{
			if (fillFormat_0.Type == FillType.Solid)
			{
				result = fillFormat_0.SolidFill.method_2();
			}
			else if (fillFormat_0.Type == FillType.Texture)
			{
				result = fillFormat_0.TextureFill.method_8();
			}
			else if (fillFormat_0.Type == FillType.Pattern)
			{
				result = fillFormat_0.PatternFill.method_0();
			}
		}
		return result;
	}

	[SpecialName]
	internal void method_4(int int_0)
	{
		if (fillFormat_0 != null)
		{
			if (fillFormat_0.Type == FillType.Solid)
			{
				fillFormat_0.SolidFill.method_3(int_0);
			}
			else if (fillFormat_0.Type == FillType.Texture)
			{
				fillFormat_0.TextureFill.method_9(int_0);
			}
			else if (fillFormat_0.Type == FillType.Pattern)
			{
				fillFormat_0.PatternFill.method_1(int_0);
			}
		}
	}

	internal FillFormat method_5()
	{
		return fillFormat_0;
	}

	internal void Copy(Area area_0)
	{
		bool_0 = area_0.bool_0;
		if (area_0.fillFormat_0 != null)
		{
			fillFormat_0 = new FillFormat(this, chart_0.method_14().Workbook);
			fillFormat_0.Copy(area_0.fillFormat_0);
		}
		else
		{
			fillFormat_0 = null;
		}
	}
}
