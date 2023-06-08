using ns2;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Encapsulates the object that represents a textbox in a spreadsheet.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiate a new Workbook.
///       Workbook workbook = new Workbook();
///       //Get the first worksheet in the book.
///       Worksheet worksheet = workbook.Worksheets[0];
///       //Add a new textbox to the collection.
///       int textboxIndex = worksheet.TextBoxes.Add(2, 1, 160, 200);
///       //Get the textbox object.
///       Aspose.Cells.TextBox textbox0 = worksheet.TextBoxes[textboxIndex];
///       //Fill the text.
///       textbox0.Text = "ASPOSE______The .NET and JAVA Component Publisher!";
///       //Get the textbox text frame.
///       MsoTextFrame textframe0 = textbox0.TextFrame;
///       //Set the textbox to adjust it according to its contents.
///       textframe0.AutoSize = true;
///       //Set the placement.
///       textbox0.Placement = PlacementType.FreeFloating;
///       //Set the font color.
///       textbox0.Font.Color = Color.Blue;
///       //Set the font to bold.
///       textbox0.Font.IsBold = true;
///       //Set the font size.
///       textbox0.Font.Size = 14;
///       //Set font attribute to italic.
///       textbox0.Font.IsItalic = true;
///       //Add a hyperlink to the textbox.
///       textbox0.AddHyperlink("http://www.aspose.com/");
///       //Get the filformat of the textbox.
///       MsoFillFormat fillformat = textbox0.FillFormat;
///       //Set the fillcolor.
///       fillformat.ForeColor = Color.Silver;
///       //Get the lineformat type of the textbox.
///       MsoLineFormat lineformat = textbox0.LineFormat;
///       //Set the line style.
///       lineformat.Style = MsoLineStyle.ThinThick;
///       //Set the line weight.
///       lineformat.Weight = 6;
///       //Set the dash style to squaredot.
///       lineformat.DashStyle = MsoLineDashStyle.SquareDot;
///       //Add another textbox.
///       textboxIndex = worksheet.TextBoxes.Add(15, 4, 85, 120);
///       //Get the second textbox.
///       Aspose.Cells.TextBox textbox1 = worksheet.TextBoxes[textboxIndex];
///       //Input some text to it.
///       textbox1.Text = "This is another simple text box";
///       //Set the placement type as the textbox will move and
///       //resize with cells.
///       textbox1.Placement = PlacementType.MoveAndSize;
///       //Save the excel file.
///       workbook.Save("C:\\tsttextboxes.xls");
///
///       [Visual Basic]
///
///       'Instantiate a new Workbook.
///       Dim workbook As Workbook = New Workbook()
///       'Get the first worksheet in the book.
///       Dim worksheet As Worksheet = workbook.Worksheets(0)
///       'Add a new textbox to the collection.
///       Dim textboxIndex As Integer = worksheet.TextBoxes.Add(2, 1, 160, 200)
///       'Get the textbox object.
///       Dim textbox0 As Aspose.Cells.TextBox = worksheet.TextBoxes(textboxIndex)
///       'Fill the text.
///       textbox0.Text = "ASPOSE______The .NET and JAVA Component Publisher!"
///       'Get the textbox text frame.
///       Dim textframe0 As MsoTextFrame = textbox0.TextFrame
///       'Set the textbox to adjust it according to its contents.
///       textframe0.AutoSize = True
///       'Set the placement.
///       textbox0.Placement = PlacementType.FreeFloating
///       'Set the font color.
///       textbox0.Font.Color = Color.Blue
///       'Set the font to bold.
///       textbox0.Font.IsBold = True
///       'Set the font size.
///       textbox0.Font.Size = 14
///       'Set font attribute to italic.
///       textbox0.Font.IsItalic = True
///       'Add a hyperlink to the textbox.
///       textbox0.AddHyperlink("http://www.aspose.com/")
///       'Get the filformat of the textbox.
///       Dim fillformat As MsoFillFormat = textbox0.FillFormat
///       'Set the fillcolor.
///       fillformat.ForeColor = Color.Silver
///       'Get the lineformat type of the textbox.
///       Dim lineformat As MsoLineFormat = textbox0.LineFormat
///       'Set the line style.
///       lineformat.Style = MsoLineStyle.ThinThick
///       'Set the line weight.
///       lineformat.Weight = 6
///       'Set the dash style to squaredot.
///       lineformat.DashStyle = MsoLineDashStyle.SquareDot
///       'Add another textbox.
///       textboxIndex = worksheet.TextBoxes.Add(15, 4, 85, 120)
///       'Get the second textbox.
///       Dim textbox1 As Aspose.Cells.TextBox = worksheet.TextBoxes(textboxIndex)
///       'Input some text to it.
///       textbox1.Text = "This is another simple text box"
///       'Set the placement type as the textbox will move and
///       'resize with cells.
///       textbox1.Placement = PlacementType.MoveAndSize
///       'Save the excel file.
///       workbook.Save("C:\tsttextboxes.xls")
///       </code>
/// </example>
public class TextBox : Shape
{
	internal TextBox(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.TextBox, shapeCollection_1)
	{
		class1737_0 = new Class1737(this);
	}

	internal void Copy(TextBox textBox_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)textBox_0, copyOptions_0);
	}
}
