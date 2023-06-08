namespace Aspose.Cells;

/// <summary>
///       Allows users to add their custom value parser for parsing string values to other proper cell value object. 	
///       </summary>
public interface ICustomParser
{
	/// <summary>
	///       Parses given string to proper value object.
	///       </summary>
	/// <param name="value">The string value to be parsed</param>
	/// <returns>
	///       Parsed value object from given string. If given string cannot be parsed to proper value object, returns null.
	///       </returns>
	object ParseObject(string value);

	/// <summary>
	///       Gets the formatting pattern for last invocation of <see cref="M:Aspose.Cells.ICustomParser.ParseObject(System.String)" />.
	///       </summary>
	/// <remarks>
	///       The formatting pattern should be like Style.Custom and may be used for formatting corresponding cell.
	///       </remarks>
	string GetFormat();
}
