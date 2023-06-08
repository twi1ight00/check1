namespace Aspose.Cells;

/// <summary>
///       Represents the states for sheet visibility. 
///       </summary>
public enum VisibilityType
{
	/// <summary>
	///       Indicates the sheet is hidden, but can be shown by the user via the user interface.  
	///        </summary>
	Hidden = 1,
	/// <summary>
	///       ndicates the sheet is hidden and cannot be shown in the user interface (UI). 
	///       This state is only available programmatically.
	///       </summary>
	VeryHidden = 2,
	/// <summary>
	///       Indicates the sheet is visible. 
	///       </summary>
	Visible = 0
}
