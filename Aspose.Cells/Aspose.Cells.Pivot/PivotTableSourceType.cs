namespace Aspose.Cells.Pivot;

/// <summary>
///       Represents the pivot table data source type.
///       </summary>
public enum PivotTableSourceType : byte
{
	/// <summary>
	///       Represents Microsoft Excel list or database.
	///       </summary>
	ListDatabase = 1,
	/// Represents External data source (Microsoft Query).
	External = 2,
	/// <summary>
	///       Represents Multiple consolidation ranges.
	///       </summary>
	Consilidation = 4,
	/// Represents Another PivotTable.
	PivotTable = 8
}
