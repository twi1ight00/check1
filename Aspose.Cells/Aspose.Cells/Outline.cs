namespace Aspose.Cells;

/// <summary>
///       Represents an outline on a worksheet.
///       </summary>
public class Outline
{
	/// <summary>
	///       Indicates if the summary row will be positioned below the detail rows in the outline.
	///       </summary>
	public bool SummaryRowBelow;

	/// <summary>
	///       Indicates if the summary column will be positioned to the right of the detail columns in the outline.
	///       </summary>
	public bool SummaryColumnRight;

	internal Outline()
	{
		SummaryColumnRight = true;
		SummaryRowBelow = true;
	}
}
