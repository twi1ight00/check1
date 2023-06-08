namespace Aspose.Cells;

/// <summary>
///       Indicates which pages will not be printed.
///       </summary>
public enum PrintingPageType
{
	/// <summary>
	///       Prints all pages.
	///       </summary>
	Default,
	/// <summary>
	///       Don't print the pages which the cells are blank. 
	///       </summary>
	IgnoreBlank,
	/// <summary>
	///       Don't print the pages which cells only contain styles. 
	///       </summary>
	IgnoreStyle
}
