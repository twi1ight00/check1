namespace Aspose.Cells;

/// <summary>
///       Represents look in type.
///       </summary>
public enum LookInType
{
	/// <summary>
	///       If the cell contains a formula, find it from formula.
	///       Else find object from the formula.
	///       </summary>
	Formulas,
	/// <summary>
	///       Only find object from the values.
	///       </summary>
	Values,
	ValuesExcludeFormulaCell,
	/// <summary>
	///       Only find object from the comments.
	///       </summary>
	Comments,
	/// <summary>
	///       Only find object from formulas.
	///       </summary>
	OnlyFormulas
}
