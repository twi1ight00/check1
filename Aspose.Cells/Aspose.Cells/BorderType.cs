namespace Aspose.Cells;

/// <summary>
///       Enumerates the border line and diagonal line types.
///       </summary>
public enum BorderType
{
	/// <summary>
	///       Represents bottom border line.
	///       </summary>
	BottomBorder = 8,
	/// <summary>
	///       Represents the diagonal line from top left to right bottom.
	///       </summary>
	DiagonalDown = 16,
	/// <summary>
	///       Represents the diagonal line from bottom left to right top.
	///       </summary>
	DiagonalUp = 32,
	/// <summary>
	///       Represents left border line.
	///       </summary>
	LeftBorder = 1,
	/// <summary>
	///       Represents right border line exists.
	///       </summary>
	RightBorder = 2,
	/// <summary>
	///       Represents top border line.
	///       </summary>
	TopBorder = 4,
	/// <summary>
	///       Only for dynamic style,such as conditional formatting.
	///       </summary>
	Horizontal = 63,
	/// <summary>
	///       Only for dynamic style,such as conditional formatting.
	///       </summary>
	Vertical = 64
}
