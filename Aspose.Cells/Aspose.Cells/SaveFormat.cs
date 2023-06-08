namespace Aspose.Cells;

/// <summary>
///       Represents the format in which the workbook is saved.
///       </summary>
public enum SaveFormat
{
	/// <summary>
	///       Represents a CSV file.
	///       </summary>
	CSV = 1,
	/// <summary>
	///       Represents an xlsx file.
	///       </summary>
	Xlsx = 6,
	/// <summary>
	///       Represents an xlsm file which enable macros.
	///       </summary>
	Xlsm = 7,
	/// <summary>
	///       Represents an xltx file.
	///       </summary>
	Xltx = 8,
	/// <summary>
	///       Represents an xltm file which enable macros.
	///       </summary>
	Xltm = 9,
	/// <summary>
	///       Represents a tab delimited text file.
	///       </summary>
	TabDelimited = 11,
	/// <summary>
	///       Represents a html file.
	///       </summary>
	Html = 12,
	MHtml = 17,
	/// <summary>
	///       Represents a Pdf file.
	///       </summary>
	Pdf = 13,
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
	///       If saving the file to the disk,the file format format accords to the extesion of the file name.
	///       If saving the file to the stream, the file format is xlsx.
	///       </summary>
	Auto = 0,
	/// <summary>
	///       Represents unrecognized format, cannot be saved. 
	///       </summary>
	Unknown = 255,
	/// <summary>
	///       Represents an XPS file.
	///       </summary>
	XPS = 20,
	/// <summary>
	///       Represents an TIFF file.
	///       </summary>
	TIFF = 21,
	SVG = 22,
	/// <summary>
	///       Data Interchange Format.
	///       </summary>
	Dif = 30
}
