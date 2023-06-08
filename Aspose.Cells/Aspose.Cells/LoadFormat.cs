namespace Aspose.Cells;

/// <summary>
///       Represents the load file format.
///       </summary>
public enum LoadFormat
{
	/// <summary>
	///       Represents recognizing the format automatically. 
	///       </summary>
	Auto = 0,
	/// <summary>
	///       Represents a CSV file.
	///       </summary>
	CSV = 1,
	/// <summary>
	///       Represents Office Open XML spreadsheetML workbook or template, with or without macros. 
	///       </summary>
	Xlsx = 6,
	/// <summary>
	///       Represents a tab delimited text file.
	///       </summary>
	TabDelimited = 11,
	/// <summary>
	///       Represents a html file.
	///       </summary>
	Html = 12,
	MHtml = 13,
	/// <summary>
	///       Represents a ods file.
	///       </summary>
	ODS = 14,
	/// <summary>
	///       Represents an Excel97-2003 xls file.
	///       </summary>
	Excel97To2003 = 5,
	/// <summary>
	///       Represents an Excel 2003 xml file.
	///       </summary>
	SpreadsheetML = 15,
	/// <summary>
	///       Represents an xlsb file.
	///       </summary>
	Xlsb = 16,
	/// <summary>
	///       Represents unrecognized format, cannot be loaded. 
	///       </summary>
	Unknown = 255
}
