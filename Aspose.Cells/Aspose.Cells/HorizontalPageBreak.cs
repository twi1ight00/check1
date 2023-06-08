namespace Aspose.Cells;

/// <summary>
///       Encapsulates the object that represents a horizontal page break. 
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///
///       //Obtaining the reference of the newly added worksheet by passing its sheet index
///       Worksheet worksheet = workbook.Worksheets[0];
///
///       //Add a page break at cell Y30
///       int Index = worksheet.HorizontalPageBreaks.Add("Y30");
///
///       //get the newly added horizontal page break
///       HorizontalPageBreak hPageBreak = worksheet.HorizontalPageBreaks[Index];  
///
///       [VB.NET]
///
///       'Instantiating a Workbook object
///       Dim workbook As New Workbook()
///
///       'Obtaining the reference of the newly added worksheet by passing its sheet index
///       Dim worksheet As Worksheet = workbook.Worksheets(0)
///
///       'Add a page break at cell Y30
///       Dim Index As Integer = worksheet.HorizontalPageBreaks.Add("Y30")
///
///       'get the newly added horizontal page break
///       Dim hPageBreak As HorizontalPageBreak = worksheet.HorizontalPageBreaks(Index)
///       </code>
/// </example>
public class HorizontalPageBreak
{
	private int int_0;

	private int int_1;

	private int int_2 = 255;

	/// <summary>
	///       Gets the start column index of this horizontal page break.
	///       </summary>
	public int StartColumn => int_1;

	/// <summary>
	///       Gets the end column index of this horizontal page break.
	///       </summary>
	public int EndColumn => int_2;

	/// <summary>
	///       Gets the zero based row index.
	///       </summary>
	public int Row => int_0;

	internal HorizontalPageBreak(int int_3)
	{
		int_0 = int_3;
	}

	internal void method_0(int int_3)
	{
		int_1 = int_3;
	}

	internal void method_1(int int_3)
	{
		int_2 = int_3;
	}

	internal void method_2(int int_3)
	{
		int_0 = int_3;
	}
}
