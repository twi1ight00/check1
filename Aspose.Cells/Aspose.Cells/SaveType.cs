namespace Aspose.Cells;

/// <summary>
///       Enumerates spreadsheet creation and saving types.
///       </summary>
public enum SaveType
{
	/// <summary>
	///       Writes the spreadsheet directly to the hard disk. 
	///       </summary>
	Default,
	/// <summary>
	///       Returns the spreadsheet as a stream of binary data and 
	///       asks the user to either save or open it.
	///       </summary>
	OpenInExcel,
	/// <summary>
	///       Sends the spreadsheet to browser and opens it in browser. 
	///       </summary>
	OpenInBrowser
}
