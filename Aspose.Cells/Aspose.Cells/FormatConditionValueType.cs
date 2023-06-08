namespace Aspose.Cells;

/// <summary>
///       Condition value type.
///       </summary>
public enum FormatConditionValueType
{
	/// <summary>
	///       The minimum/ midpoint / maximum value for the
	///       gradient is determined by a formula.
	///       </summary>
	Formula,
	/// <summary>
	///       Indicates that the maximum value in the range shall be
	///       used as the maximum value for the gradient.
	///       </summary>
	Max,
	/// <summary>
	///       Indicates that the minimum value in the range shall be
	///       used as the minimum value for the gradient.
	///       </summary>
	Min,
	/// <summary>
	///       Indicates that the minimum / midpoint / maximum
	///       value for the gradient is specified by a constant
	///       numeric value.
	///       </summary>
	Number,
	/// <summary>
	///       Value indicates a percentage between the minimum
	///       and maximum values in the range shall be used as the
	///       minimum / midpoint / maximum value for the gradient.
	///       </summary>
	Percent,
	/// <summary>
	///       Value indicates a percentile ranking in the range shall
	///       be used as the minimum / midpoint / maximum value
	///       for the gradient.
	///       </summary>
	Percentile,
	AutomaticMax,
	AutomaticMin
}
