using ns52;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the line shape.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiate a new Workbook.
///       Workbook workbook = new Workbook();
///
///       //Get the first worksheet in the book.
///       Worksheet worksheet = workbook.Worksheets[0];
///
///       //Add a new line to the worksheet.
///       Aspose.Cells.LineShape line1 = worksheet.Shapes.AddLine(5, 0, 1, 0, 0, 250);
///
///       //Set the line dash style
///       line1.LineFormat.DashStyle = MsoLineDashStyle.Solid;
///
///       //Set the placement.
///       line1.Placement = PlacementType.FreeFloating;
///
///       //Add another line to the worksheet.
///       Aspose.Cells.LineShape line2 = worksheet.Shapes.AddLine(7, 0, 1, 0, 85, 250);
///
///       //Set the line dash style.
///       line2.LineFormat.DashStyle = MsoLineDashStyle.DashLongDash;
///
///       //Set the weight of the line.
///       line2.LineFormat.Weight = 4;
///
///       //Set the placement.
///       line2.Placement = PlacementType.FreeFloating;
///
///       //Add the third line to the worksheet.
///       Aspose.Cells.LineShape line3 = worksheet.Shapes.AddLine(13, 0, 1, 0, 0, 250);
///
///       //Set the line dash style
///       line3.LineFormat.DashStyle = MsoLineDashStyle.Solid;
///
///       //Set the placement.
///       line3.Placement = PlacementType.FreeFloating;
///
///       //Make the gridlines invisible in the first worksheet.
///       workbook.Worksheets[0].IsGridlinesVisible = false;
///
///       //Save the excel file.
///       workbook.Save("d:\\test\\tstlines.xls"); 
///
///       [VB.NET]
///
///       'Instantiate a new Workbook.
///       Dim workbook As Workbook = New Workbook()
///
///       'Get the first worksheet in the book.
///       Dim worksheet As Worksheet = workbook.Worksheets(0)
///
///       'Add a new line to the worksheet.
///       Dim line1 As Aspose.Cells.LineShape = worksheet.Shapes.AddLine(5, 0, 1, 0, 0, 250)
///
///       'Set the line dash style
///       line1.LineFormat.DashStyle = MsoLineDashStyle.Solid
///
///       'Set the placement.
///       line1.Placement = PlacementType.FreeFloating
///
///       'Add another line to the worksheet.
///       Dim line2 As Aspose.Cells.LineShape = worksheet.Shapes.AddLine(7, 0, 1, 0, 85, 250)
///
///       'Set the line dash style.
///       line2.LineFormat.DashStyle = MsoLineDashStyle.DashLongDash
///
///       'Set the weight of the line.
///       line2.LineFormat.Weight = 4
///
///       'Set the placement.
///       line2.Placement = PlacementType.FreeFloating
///
///       'Add the third line to the worksheet.
///       Dim line3 As Aspose.Cells.LineShape = worksheet.Shapes.AddLine(13, 0, 1, 0, 0, 250)
///
///       'Set the line dash style
///       line3.LineFormat.DashStyle = MsoLineDashStyle.Solid
///
///       'Set the placement.
///       line3.Placement = PlacementType.FreeFloating
///
///       'Make the gridlines invisible in the first worksheet.
///       workbook.Worksheets(0).IsGridlinesVisible = False
///
///       'Save the excel file.
///       workbook.Save("d:\test\tstlines.xls") 
///       </code>
/// </example>
public class LineShape : Shape
{
	/// <summary>
	///       Gets and sets the begin arrow head style of the line.
	///       </summary>
	public MsoArrowheadStyle BeginArrowheadStyle
	{
		get
		{
			return (MsoArrowheadStyle)method_27().method_2().method_4(464, 0);
		}
		set
		{
			method_27().method_2().method_1(464, Enum183.const_0, (int)value);
		}
	}

	/// <summary>
	///       Gets and sets the begin arrow head width of the line.
	///       </summary>
	public MsoArrowheadWidth BeginArrowheadWidth
	{
		get
		{
			return (MsoArrowheadWidth)method_27().method_2().method_4(466, 1);
		}
		set
		{
			method_27().method_2().method_1(466, Enum183.const_0, (int)value);
		}
	}

	/// <summary>
	///       Gets and sets the begin arrow head length of the line.
	///       </summary>
	public MsoArrowheadLength BeginArrowheadLength
	{
		get
		{
			return (MsoArrowheadLength)method_27().method_2().method_4(467, 1);
		}
		set
		{
			method_27().method_2().method_1(467, Enum183.const_0, (int)value);
		}
	}

	/// <summary>
	///       Gets and sets the end arrow head style of the line.
	///       </summary>
	public MsoArrowheadStyle EndArrowheadStyle
	{
		get
		{
			return (MsoArrowheadStyle)method_27().method_2().method_4(465, 0);
		}
		set
		{
			method_27().method_2().method_1(465, Enum183.const_0, (int)value);
		}
	}

	/// <summary>
	///       Gets and sets the end arrow head width of the line.
	///       </summary>
	public MsoArrowheadWidth EndArrowheadWidth
	{
		get
		{
			return (MsoArrowheadWidth)method_27().method_2().method_4(468, 1);
		}
		set
		{
			method_27().method_2().method_1(468, Enum183.const_0, (int)value);
		}
	}

	/// <summary>
	///       Gets and sets the end arrow head length of the line.
	///       </summary>
	public MsoArrowheadLength EndArrowheadLength
	{
		get
		{
			return (MsoArrowheadLength)method_27().method_2().method_4(469, 1);
		}
		set
		{
			method_27().method_2().method_1(469, Enum183.const_0, (int)value);
		}
	}

	internal LineShape(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.Line, shapeCollection_1)
	{
	}

	internal void Copy(LineShape lineShape_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)lineShape_0, copyOptions_0);
	}
}
