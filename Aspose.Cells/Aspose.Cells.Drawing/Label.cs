using ns2;

namespace Aspose.Cells.Drawing;

/// <summary>
///        Encapsulates the object that represents a label in a spreadsheet.
///        </summary>
/// <example>
///   <code>
///        //Create a new Workbook.
///        Workbook workbook = new Workbook();
///
///        //Get the first worksheet in the workbook.
///        Worksheet sheet = workbook.Worksheets[0];
///
///        //Add a new label to the worksheet.
///        Aspose.Cells.Label label = sheet.Shapes.AddLabel(2, 0, 2, 0, 60, 120);
///
///        //Set the caption of the label.
///        label.Text = "This is a Label";
///
///        //Set the Placement Type, the way the
///        //label is attached to the cells.
///        label.Placement = PlacementType.FreeFloating;
///
///        //Set the fill color of the label.
///        label.FillFormat.ForeColor = Color.Yellow;
///
///        //Saves the file.
///        workbook.Save(@"d:\test\tstlabel.xls");
///
///        [VB.NET]
///
///       'Create a new Workbook.
///        Dim workbook As Workbook = New Workbook()
///
///        'Get the first worksheet in the workbook.
///        Dim sheet As Worksheet = workbook.Worksheets(0)
///
///        'Add a new label to the worksheet.
///        Dim label As Aspose.Cells.Label = sheet.Shapes.AddLabel(2, 0, 2, 0, 60, 120)
///
///        'Set the caption of the label.
///        label.Text = "This is a Label"
///
///        'Set the Placement Type, the way the
///        'label is attached to the cells.
///        label.Placement = PlacementType.FreeFloating
///
///        'Set the fill color of the label.
///        label.FillFormat.ForeColor = Color.Yellow
///
///        'Saves the file.
///        workbook.Save("d:\test\tstlabel.xls")
///        </code>
/// </example>
public class Label : Shape
{
	internal Label(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.Label, shapeCollection_1)
	{
		class1737_0 = new Class1737(this);
	}

	internal void Copy(Label label_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)label_0, copyOptions_0);
		if (label_0.class1737_0 != null)
		{
			method_63().Copy(label_0.class1737_0);
		}
	}
}
