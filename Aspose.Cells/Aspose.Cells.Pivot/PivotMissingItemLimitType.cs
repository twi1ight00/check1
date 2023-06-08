namespace Aspose.Cells.Pivot;

/// <summary>
///       Represents number of items to retain per field.
///       </summary>
public enum PivotMissingItemLimitType
{
	/// <summary>
	///       The default number of unique items per PivotField allowed.
	///       </summary>
	Automatic,
	/// <summary>
	///       The maximum number of unique items per PivotField allowed (&gt;32,500).
	///       </summary>
	Max,
	/// <summary>
	///       No unique items per PivotField allowed.
	///       </summary>
	None
}
