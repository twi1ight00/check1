using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the shape of the chart.
///       Properties and methods for the ChartObject object control the appearance and size of the embedded chart on the worksheet.
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
///       //Getting Chart Shape
///       ChartShape chartShape = chart.ChartObject;
///
///       //Set Lower Right Column
///       chartShape.LowerRightColumn = 10;
///
///       //Set LowerDeltaX
///       chartShape.LowerDeltaX = 1024;
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
///       'Getting Chart Shape
///       Dim chartShape As ChartShape = chart.ChartObject
///
///       'Set Lower Right Column
///       chartShape.LowerRightColumn = 10
///
///       'Set LowerDeltaX
///       chartShape.LowerDeltaX = 1024
///
///       'Saving the Excel file
///       workbook.Save("D:\book1.xls")
///       </code>
/// </example>
public class ChartShape : Shape
{
	private Chart chart_0;

	/// <summary>
	///       Returns a Chart object that represents the chart contained in the object. 
	///       </summary>
	public Chart Chart => chart_0;

	internal ChartShape(ShapeCollection shapeCollection_1, Chart chart_1)
		: base(shapeCollection_1, MsoDrawingType.Chart, shapeCollection_1)
	{
		chart_0 = chart_1;
	}

	[SpecialName]
	internal Chart method_69()
	{
		return chart_0;
	}

	internal void Copy(ChartShape chartShape_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)chartShape_0, copyOptions_0);
		chart_0.Copy(chartShape_0.chart_0, copyOptions_0);
	}
}
