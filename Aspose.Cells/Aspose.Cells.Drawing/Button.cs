using ns2;

namespace Aspose.Cells.Drawing;

/// <summary>
///        Represents the Forms control: Button
///        </summary>
/// <example>
///   <code>
///       [C#]
///
///        //Create a new Workbook.
///        Workbook workbook = new Workbook();
///
///        //Get the first worksheet in the workbook.
///        Worksheet sheet = workbook.Worksheets[0];
///
///        //Add a new button to the worksheet.
///        Aspose.Cells.Button button = sheet.Shapes.AddButton(2, 0, 2, 0, 28, 80);
///
///        //Set the caption of the button.
///        button.Text = "Aspose";
///
///        //Set the Placement Type, the way the
///        //button is attached to the cells.
///        button.Placement = PlacementType.FreeFloating;
///
///        //Set the font name.
///        button.Font.Name = "Tahoma";
///
///        //Set the caption string bold.
///        button.Font.IsBold = true;
///
///        //Set the color to blue.
///        button.Font.Color = Color.Blue;
///
///        //Set the hyperlink for the button.
///        button.AddHyperlink("http://www.aspose.com/");
///
///        //Saves the file.
///        workbook.Save(@"d:\test\tstbutton.xls");
///
///        [VB.NET]
///
///        'Create a new Workbook.
///        Dim workbook As Workbook = New Workbook()
///
///        'Get the first worksheet in the workbook.
///        Dim sheet As Worksheet = workbook.Worksheets(0)
///
///        'Add a new button to the worksheet.
///        Dim button As Aspose.Cells.Button = sheet.Shapes.AddButton(2, 0, 2, 0, 28, 80)
///
///        'Set the caption of the button.
///        button.Text = "Aspose"
///
///        'Set the Placement Type, the way the
///        'button is attached to the cells.
///        button.Placement = PlacementType.FreeFloating
///
///        'Set the font name.
///        button.Font.Name = "Tahoma"
///
///        'Set the caption string bold.
///        button.Font.IsBold = True
///
///        'Set the color to blue.
///        button.Font.Color = Color.Blue
///
///        'Set the hyperlink for the button.
///        button.AddHyperlink("http://www.aspose.com/")
///
///        'Saves the file.
///        workbook.Save("d:\test\tstbutton.xls")
///       </code>
/// </example>
public class Button : Shape
{
	internal Button(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.Button, shapeCollection_1)
	{
		class1737_0 = new Class1737(this);
	}

	internal void Copy(Button button_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)button_0, copyOptions_0);
	}
}
