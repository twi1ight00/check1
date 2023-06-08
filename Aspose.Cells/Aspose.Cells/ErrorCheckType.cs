namespace Aspose.Cells;

/// <summary>
///       Represents all error check type.
///       </summary>
public enum ErrorCheckType
{
	/// <sumarry>
	///        check for calculation errors
	///       </sumarry>
	Calc = 1,
	/// <sumarry>
	///        check for references to empty cells
	///       </sumarry>
	EmptyCellRef = 2,
	/// <sumarry>
	///        check the format of numeric values
	///       </sumarry>
	TextNumber = 4,
	/// <sumarry>
	///        check formulas with references to less than the entirety
	///        of a range containing continuous data
	///       </sumarry>
	InconsistRange = 8,
	/// <sumarry>
	///        check formulas that are inconsistent with formulas in neighboring cells.
	///       </sumarry>
	InconsistFormula = 16,
	/// <sumarry>
	///        check the format of date/time values
	///       </sumarry>
	TextDate = 32,
	/// <sumarry>
	///        check for unprotected formulas
	///       </sumarry>
	UnproctedFormula = 64,
	/// <sumarry>
	///        whether to perform data validation
	///       </sumarry>
	Validation = 128,
	CalculatedColumn = 129
}
