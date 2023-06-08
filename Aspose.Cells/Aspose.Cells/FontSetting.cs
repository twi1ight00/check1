using System.Runtime.CompilerServices;

namespace Aspose.Cells;

/// <summary>
///        Represents a range of characters within the cell text.
///        </summary>
/// <example>
///   <code>
///
///        [C#]
///
///        //Instantiating a Workbook object
///        Workbook workbook = new Workbook();
///
///        //Adding a new worksheet to the Excel object
///        workbook.Worksheets.Add();
///
///        //Obtaining the reference of the newly added worksheet by passing its sheet index
///        Worksheet worksheet = workbook.Worksheets[0];
///
///        //Accessing the "A1" cell from the worksheet
///        Aspose.Cells.Cell cell = worksheet.Cells["A1"];
///
///        //Adding some value to the "A1" cell
///        cell.PutValue("Visit Aspose!");
///
///        //getting charactor
///        FontSetting charactor = cell.Characters(6, 7);
///
///        //Setting the font of selected characters to bold
///        charactor.Font.IsBold = true;
///
///        //Setting the font color of selected characters to blue
///        charactor.Font.Color = Color.Blue;
///
///        //Saving the Excel file
///        workbook.Save("D:\\book1.xls");
///
///        [VB.NET]
///
///        'Instantiating a Workbook object
///        Dim workbook As New Workbook()
///
///        'Adding a new worksheet to the Excel object
///        workbook.Worksheets.Add()
///
///        'Obtaining the reference of the newly added worksheet by passing its sheet index
///        Dim worksheet As Worksheet = workbook.Worksheets(0)
///
///        'Accessing the "A1" cell from the worksheet
///        Dim cell As Aspose.Cells.Cell = worksheet.Cells("A1")
///
///        'Adding some value to the "A1" cell
///        cell.PutValue("Visit Aspose!")
///
///        'getting charactor
///        Dim charactor As FontSetting = cell.Characters(6, 7)
///
///        'Setting the font of selected characters to bold
///        charactor.Font.IsBold = True
///
///        'Setting the font color of selected characters to blue
///        charactor.Font.Color = Color.Blue
///
///        'Saving the Excel file
///        workbook.Save("D:\book1.xls")
///
///        </code>
/// </example>
public class FontSetting
{
	private int int_0;

	private int int_1;

	private Font font_0;

	internal WorksheetCollection worksheetCollection_0;

	private bool bool_0;

	/// <summary>
	///       Gets the start index of the characters.
	///       </summary>
	public int StartIndex => int_0;

	/// <summary>
	///       Gets the length of the characters.
	///       </summary>
	public int Length => int_1;

	/// <summary>
	///       Returns the font of this object.
	///       </summary>
	public Font Font
	{
		get
		{
			if (font_0 == null)
			{
				font_0 = new Font(worksheetCollection_0, null, bool_0);
			}
			return font_0;
		}
	}

	internal FontSetting(int int_2, int int_3, WorksheetCollection worksheetCollection_1, bool bool_1)
	{
		int_0 = int_2;
		int_1 = int_3;
		worksheetCollection_0 = worksheetCollection_1;
		bool_0 = bool_1;
	}

	[SpecialName]
	internal bool method_0()
	{
		return bool_0;
	}

	internal void method_1(int int_2)
	{
		int_1 = int_2;
	}

	internal Font method_2()
	{
		return font_0;
	}

	internal void method_3(Font font_1)
	{
		font_0 = font_1;
	}

	internal void Copy(FontSetting fontSetting_0)
	{
		if (fontSetting_0.font_0 != null)
		{
			Font.Copy(fontSetting_0.Font);
		}
		else
		{
			font_0 = null;
		}
		int_1 = fontSetting_0.Length;
		int_0 = fontSetting_0.int_0;
	}
}
