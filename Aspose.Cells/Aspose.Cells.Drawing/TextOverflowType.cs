namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the way the text vertical or horizontal overflow.
///       </summary>
public enum TextOverflowType
{
	/// <summary>
	///       Pay attention to top and bottom barriers. 
	///       Provide no indication that there is text which is not visible.
	///       </summary>
	Clip,
	/// <summary>
	///       Pay attention to top and bottom barriers. 
	///       Use an ellipsis to denote that there is text which is not visible.
	///       Only for vertical overflow.
	///       </summary>
	Ellipsis,
	/// <summary>
	///       Overflow the text and pay no attention to top and bottom barriers.
	///       </summary>
	Overflow
}
