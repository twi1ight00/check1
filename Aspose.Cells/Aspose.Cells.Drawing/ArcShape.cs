using ns52;

namespace Aspose.Cells.Drawing;

/// <summary>
///        Represents the arc shape.
///        </summary>
/// <example>
///   <code>
///
///        [C#]
///        //Instantiate a new Workbook.
///       Workbook excelbook = new Workbook();
///
///        //Add an arc shape.
///       Aspose.Cells.ArcShape arc1 = excelbook.Worksheets[0].Shapes.AddArc(2, 0, 2, 0, 130, 130);
///
///        //Set the placement of the arc.
///       arc1.Placement = PlacementType.FreeFloating;
///
///        //Set the fill format.
///       arc1.FillFormat.ForeColor = Color.Blue;
///
///        //Set the line style.
///       arc1.LineFormat.Style = MsoLineStyle.Single;
///
///        //Set the line weight.
///       arc1.LineFormat.Weight = 1;
///
///        //Set the color of the arc line.
///       arc1.LineFormat.ForeColor = Color.Blue;
///
///        //Set the dash style of the arc.
///       arc1.LineFormat.DashStyle = MsoLineDashStyle.Solid;
///
///        //Add another arc shape.
///       Aspose.Cells.ArcShape arc2 = excelbook.Worksheets[0].Shapes.AddArc(9, 0, 2, 0, 130, 130);
///
///        //Set the placement of the arc.
///       arc2.Placement = PlacementType.FreeFloating;
///
///        //Set the line style.
///       arc2.LineFormat.Style = MsoLineStyle.Single;
///
///        //Set the line weight.
///       arc2.LineFormat.Weight = 1;
///
///        //Set the color of the arc line.
///       arc2.LineFormat.ForeColor = Color.Blue;
///
///        //Set the dash style of the arc.
///       arc2.LineFormat.DashStyle = MsoLineDashStyle.Solid;
///
///        //Save the excel file.
///       excelbook.Save("d:\\test\\tstarcs.xls");
///
///        [VB..NET]
///
///       'Instantiate a new Workbook.
///       Dim excelbook As Workbook = New Workbook()
///
///       'Add an arc shape.
///       Dim arc1 As Aspose.Cells.ArcShape = excelbook.Worksheets(0).Shapes.AddArc(2, 0, 2, 0, 130, 130)
///
///       'Set the placement of the arc.
///       arc1.Placement = PlacementType.FreeFloating
///
///       'Set the fill format.
///       arc1.FillFormat.ForeColor = Color.Blue
///
///       'Set the line style.
///       arc1.LineFormat.Style = MsoLineStyle.Single
///
///       'Set the line weight.
///       arc1.LineFormat.Weight = 1
///
///       'Set the color of the arc line.
///       arc1.LineFormat.ForeColor = Color.Blue
///
///       'Set the dash style of the arc.
///       arc1.LineFormat.DashStyle = MsoLineDashStyle.Solid
///
///       'Add another arc shape.
///       Dim arc2 As Aspose.Cells.ArcShape = excelbook.Worksheets(0).Shapes.AddArc(9, 0, 2, 0, 130, 130)
///
///       'Set the placement of the arc.
///       arc2.Placement = PlacementType.FreeFloating
///
///       'Set the line style.
///       arc2.LineFormat.Style = MsoLineStyle.Single
///
///       'Set the line weight.
///       arc2.LineFormat.Weight = 1
///
///       'Set the color of the arc line.
///       arc2.LineFormat.ForeColor = Color.Blue
///
///       'Set the dash style of the arc.
///       arc2.LineFormat.DashStyle = MsoLineDashStyle.Solid
///
///       'Save the excel file.
///       excelbook.Save("d:\test\tstarcs.xls")
///        </code>
/// </example>
public class ArcShape : Shape
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
			return (MsoArrowheadWidth)method_27().method_2().method_4(466, 0);
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
			return (MsoArrowheadLength)method_27().method_2().method_4(467, 0);
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
			return (MsoArrowheadWidth)method_27().method_2().method_4(468, 0);
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
			return (MsoArrowheadLength)method_27().method_2().method_4(469, 0);
		}
		set
		{
			method_27().method_2().method_1(469, Enum183.const_0, (int)value);
		}
	}

	internal ArcShape(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.Arc, shapeCollection_1)
	{
	}

	internal void Copy(ArcShape arcShape_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)arcShape_0, copyOptions_0);
	}
}
