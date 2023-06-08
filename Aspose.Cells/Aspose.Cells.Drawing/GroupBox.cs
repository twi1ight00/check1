using System.Collections;
using System.Runtime.CompilerServices;
using ns2;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Encapsulates the object that represents a groupbox in a spreadsheet.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiate a new Workbook.
///       Workbook excelbook = new Workbook();
///
///       //Add a group box to the first worksheet.
///       Aspose.Cells.GroupBox box = excelbook.Worksheets[0].Shapes.AddGroupBox(1, 0, 1, 0, 300, 250);
///
///       //Set the caption of the group box.
///       box.Text = "Age Groups";
///       box.Placement = PlacementType.FreeFloating;
///
///       //Make it 2-D box.
///       box.Shadow = false;
///
///       //Add a radio button.
///       Aspose.Cells.RadioButton radio1 = excelbook.Worksheets[0].Shapes.AddRadioButton(3, 0, 2, 0, 30, 110);
///
///       //Set its text string.
///       radio1.Text = "20-29";
///
///       //Set A1 cell as a linked cell for the radio button.
///       radio1.LinkedCell = "A1";
///
///       //Make the radio button 3-D.
///       radio1.Shadow = true;
///
///       //Set the foreground color of the radio button.
///       radio1.FillFormat.ForeColor = Color.LightGreen;
///
///       //Set the line style of the radio button.
///       radio1.LineFormat.Style = MsoLineStyle.ThickThin;
///
///       //Set the weight of the radio button.
///       radio1.LineFormat.Weight = 4;
///
///       //Set the line color of the radio button.
///       radio1.LineFormat.ForeColor = Color.Blue;
///
///       //Set the dash style of the radio button.
///       radio1.LineFormat.DashStyle = MsoLineDashStyle.Solid;
///
///       //Make the line format visible.
///       radio1.LineFormat.IsVisible = true;
///
///       //Make the fill format visible.
///       radio1.FillFormat.IsVisible = true;
///
///       //Add another radio button.
///       Aspose.Cells.RadioButton radio2 = excelbook.Worksheets[0].Shapes.AddRadioButton(6, 0, 2, 0, 30, 110);
///
///       //Set its text string.
///       radio2.Text = "30-39";
///
///       //Set A1 cell as a linked cell for the radio button.
///       radio2.LinkedCell = "A1";
///
///       //Make the radio button 3-D.
///       radio2.Shadow = true;
///
///       //Set the foreground color of the radio button.
///       radio2.FillFormat.ForeColor = Color.LightGreen;
///
///       //Set the line style of the radio button.
///       radio2.LineFormat.Style = MsoLineStyle.ThickThin;
///
///       //Set the weight of the radio button.
///       radio2.LineFormat.Weight = 4;
///
///       //Set the line color of the radio button.
///       radio2.LineFormat.ForeColor = Color.Blue;
///
///       //Set the dash style of the radio button.
///       radio2.LineFormat.DashStyle = MsoLineDashStyle.Solid;
///
///       //Make the line format visible.
///       radio2.LineFormat.IsVisible = true;
///
///       //Make the fill format visible.
///       radio2.FillFormat.IsVisible = true;
///
///       //Add another radio button.
///       Aspose.Cells.RadioButton radio3 = excelbook.Worksheets[0].Shapes.AddRadioButton(9, 0, 2, 0, 30, 110);
///
///       //Set its text string.
///       radio3.Text = "40-49";
///
///       //Set A1 cell as a linked cell for the radio button.
///       radio3.LinkedCell = "A1";
///
///       //Make the radio button 3-D.
///       radio3.Shadow = true;
///
///       //Set the foreground color of the radio button.
///       radio3.FillFormat.ForeColor = Color.LightGreen;
///
///       //Set the line style of the radio button.
///       radio3.LineFormat.Style = MsoLineStyle.ThickThin;
///
///       //Set the weight of the radio button.
///       radio3.LineFormat.Weight = 4;
///
///       //Set the line color of the radio button.
///       radio3.LineFormat.ForeColor = Color.Blue;
///
///       //Set the dash style of the radio button.
///       radio3.LineFormat.DashStyle = MsoLineDashStyle.Solid;
///
///       //Make the line format visible.
///       radio3.LineFormat.IsVisible = true;
///
///       //Make the fill format visible.
///       radio3.FillFormat.IsVisible = true;
///
///       //Get the shapes.
///       Aspose.Cells.Shape[] shapeobjects = new Aspose.Cells.Shape[] { box, radio1, radio2, radio3 };
///
///       //Group the shapes.
///       Aspose.Cells.GroupShape group = excelbook.Worksheets[0].Shapes.Group(shapeobjects);
///
///       //Save the excel file.
///       excelbook.Save("d:\\test\\groupshapes.xls");
///
///       [VB.NET]
///
///       'Instantiate a new Workbook.
///       Dim excelbook As Workbook = New Workbook()
///
///       'Add a group box to the first worksheet.
///       Dim box As Aspose.Cells.GroupBox = excelbook.Worksheets(0).Shapes.AddGroupBox(1, 0, 1, 0, 300, 250)
///
///       'Set the caption of the group box.
///       box.Text = "Age Groups"
///       box.Placement = PlacementType.FreeFloating
///
///       'Make it 2-D box.
///       box.Shadow = False
///
///       'Add a radio button.
///       Dim radio1 As Aspose.Cells.RadioButton = excelbook.Worksheets(0).Shapes.AddRadioButton(3, 0, 2, 0, 30, 110)
///
///       'Set its text string.
///       radio1.Text = "20-29"
///
///       'Set A1 cell as a linked cell for the radio button.
///       radio1.LinkedCell = "A1"
///
///       'Make the radio button 3-D.
///       radio1.Shadow = True
///
///       'Set the foreground color of the radio button.
///       radio1.FillFormat.ForeColor = Color.LightGreen
///
///       'Set the line style of the radio button.
///       radio1.LineFormat.Style = MsoLineStyle.ThickThin
///
///       'Set the weight of the radio button.
///       radio1.LineFormat.Weight = 4
///
///       'Set the line color of the radio button.
///       radio1.LineFormat.ForeColor = Color.Blue
///
///       'Set the dash style of the radio button.
///       radio1.LineFormat.DashStyle = MsoLineDashStyle.Solid
///
///       'Make the line format visible.
///       radio1.LineFormat.IsVisible = True
///
///       'Make the fill format visible.
///       radio1.FillFormat.IsVisible = True
///
///       'Add another radio button.
///       Dim radio2 As Aspose.Cells.RadioButton = excelbook.Worksheets(0).Shapes.AddRadioButton(6, 0, 2, 0, 30, 110)
///
///       'Set its text string.
///       radio2.Text = "30-39"
///
///       'Set A1 cell as a linked cell for the radio button.
///       radio2.LinkedCell = "A1"
///
///       'Make the radio button 3-D.
///       radio2.Shadow = True
///
///       'Set the foreground color of the radio button.
///       radio2.FillFormat.ForeColor = Color.LightGreen
///
///       'Set the line style of the radio button.
///       radio2.LineFormat.Style = MsoLineStyle.ThickThin
///
///       'Set the weight of the radio button.
///       radio2.LineFormat.Weight = 4
///
///       'Set the line color of the radio button.
///       radio2.LineFormat.ForeColor = Color.Blue
///
///       'Set the dash style of the radio button.
///       radio2.LineFormat.DashStyle = MsoLineDashStyle.Solid
///
///       'Make the line format visible.
///       radio2.LineFormat.IsVisible = True
///
///       'Make the fill format visible.
///       radio2.FillFormat.IsVisible = True
///
///       'Add another radio button.
///       Dim radio3 As Aspose.Cells.RadioButton = excelbook.Worksheets(0).Shapes.AddRadioButton(9, 0, 2, 0, 30, 110)
///
///       'Set its text string.
///       radio3.Text = "40-49"
///
///       'Set A1 cell as a linked cell for the radio button.
///       radio3.LinkedCell = "A1"
///
///       'Make the radio button 3-D.
///       radio3.Shadow = True
///
///       'Set the foreground color of the radio button.
///       radio3.FillFormat.ForeColor = Color.LightGreen
///
///       'Set the line style of the radio button.
///       radio3.LineFormat.Style = MsoLineStyle.ThickThin
///
///       'Set the weight of the radio button.
///       radio3.LineFormat.Weight = 4
///
///       'Set the line color of the radio button.
///       radio3.LineFormat.ForeColor = Color.Blue
///
///       'Set the dash style of the radio button.
///       radio3.LineFormat.DashStyle = MsoLineDashStyle.Solid
///
///       'Make the line format visible.
///       radio3.LineFormat.IsVisible = True
///
///       'Make the fill format visible.
///       radio3.FillFormat.IsVisible = True
///
///       'Get the shapes.
///       Dim shapeobjects() As Aspose.Cells.Shape = New Aspose.Cells.Shape() {box, radio1, radio2, radio3}
///
///       'Group the shapes.
///       Dim group As Aspose.Cells.GroupShape = excelbook.Worksheets(0).Shapes.Group(shapeobjects)
///
///       'Save the excel file.
///       excelbook.Save("d:\test\groupshapes.xls")
///       </code>
/// </example>
public class GroupBox : Shape
{
	private bool bool_3;

	/// <summary>
	///       Indicates whether the groupbox has shadow.
	///       </summary>
	public bool Shadow
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

	internal GroupBox(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.GroupBox, shapeCollection_1)
	{
		class1737_0 = new Class1737(this);
	}

	[SpecialName]
	internal ArrayList method_69()
	{
		ArrayList arrayList = new ArrayList();
		PlacementType placement = base.Placement;
		base.Placement = PlacementType.MoveAndSize;
		int upperLeftRow = base.UpperLeftRow;
		int upperDeltaY = base.UpperDeltaY;
		int upperLeftColumn = base.UpperLeftColumn;
		int upperDeltaX = base.UpperDeltaX;
		int lowerRightRow = base.LowerRightRow;
		int lowerDeltaY = base.LowerDeltaY;
		int lowerRightColumn = base.LowerRightColumn;
		int lowerDeltaX = base.LowerDeltaX;
		base.Placement = placement;
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		int num4 = -1;
		foreach (Shape shape in base.Shapes)
		{
			if (shape == this || shape.method_33())
			{
				continue;
			}
			bool flag = false;
			switch (shape.Placement)
			{
			case PlacementType.FreeFloating:
			{
				if (num == -1)
				{
					num = method_36();
					num2 = method_38();
					num3 = num2 + base.Width;
					num4 = num + base.Height;
				}
				int num5 = shape.method_36();
				int num6 = shape.method_38();
				int num7 = num6 + shape.Width;
				int num8 = num5 + shape.Height;
				if (num5 >= num && num8 <= num4 && num6 >= num2 && num7 <= num3)
				{
					flag = true;
				}
				break;
			}
			case PlacementType.Move:
			case PlacementType.MoveAndSize:
			{
				int upperLeftRow2 = shape.UpperLeftRow;
				int upperDeltaY2 = shape.UpperDeltaY;
				int upperLeftColumn2 = shape.UpperLeftColumn;
				int upperDeltaX2 = shape.UpperDeltaX;
				if ((upperLeftRow2 > upperLeftRow || (upperLeftRow2 == upperLeftRow && upperDeltaY2 >= upperDeltaY)) && (upperLeftColumn2 > upperLeftColumn || (upperLeftColumn2 == upperLeftColumn && upperDeltaX2 >= upperDeltaX)))
				{
					placement = shape.Placement;
					shape.Placement = PlacementType.MoveAndSize;
					int lowerRightRow2 = shape.LowerRightRow;
					int lowerDeltaY2 = shape.LowerDeltaY;
					int lowerRightColumn2 = shape.LowerRightColumn;
					int lowerDeltaX2 = shape.LowerDeltaX;
					if ((lowerRightRow2 < lowerRightRow || (lowerRightRow2 == lowerRightRow && lowerDeltaY2 <= lowerDeltaY)) && (lowerRightColumn2 < lowerRightColumn || (lowerRightColumn2 == lowerRightColumn && lowerDeltaX2 <= lowerDeltaX)))
					{
						flag = true;
					}
					shape.Placement = placement;
				}
				break;
			}
			}
			if (flag)
			{
				arrayList.Add(shape);
				if (shape.IsGroup)
				{
					arrayList.AddRange(((GroupShape)shape).GetGroupedShapes());
				}
			}
		}
		return arrayList;
	}

	internal void Copy(GroupBox groupBox_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)groupBox_0, copyOptions_0);
		bool_3 = groupBox_0.bool_3;
	}
}
