namespace Aspose.Cells;

/// <summary>
///       Encapsulates the object that represents a vertical page break. 
///       </summary>
/// <example>
///   <code>
///       [C#]
///       //Add a pagebreak at G5
///       excel.Worksheets[0].HorizontalPageBreaks.Add("G5");
///       excel.Worksheets[0].VerticalPageBreaks.Add("G5");
///
///       [VB]
///       'Add a pagebreak at G5
///       excel.Worksheets(0).HorizontalPageBreaks.Add("G5")
///       excel.Worksheets(0).VerticalPageBreaks.Add("G5")
///       </code>
/// </example>
public class VerticalPageBreak
{
	private int int_0;

	private int int_1;

	private int int_2 = 65535;

	/// <summary>
	///       Gets the start row index of the vertical page break.
	///       </summary>
	public int StartRow => int_1;

	/// <summary>
	///       Gets the end row index of the vertical page break.
	///       </summary>
	public int EndRow => int_2;

	/// <summary>
	///       Gets the column index of the vertical page break.
	///       </summary>
	public int Column => int_0;

	internal VerticalPageBreak(int int_3)
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
}
