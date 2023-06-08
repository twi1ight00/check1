using System;
using System.ComponentModel;

namespace Aspose.Cells;

/// <summary>
///       Enumerates spreadsheet file format types
///       </summary>
public enum FileFormatType
{
	/// <summary>
	///       Saves the spreadsheet in Aspose.Pdf.Xml format that can be read by Aspose.Pdf to produce a PDF file.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use <see cref="F:Aspose.Cells.FileFormatType.Pdf" /> property.
	///       This property will be removed 6 months later since April 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.
	///       </summary>
	[Browsable(false)]
	[Obsolete("Use FileFormatType.Pdf instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	AsposePdf = 0,
	/// <summary>
	///       Represents a CSV file.
	///       </summary>
	CSV = 1,
	/// <summary>
	///       Represents an Excel 97-2003 xls file.        
	///       NOTE: This member is now obsolete. Instead, 
	///       please use <see cref="F:Aspose.Cells.FileFormatType.Excel97To2003" />property.
	///       This property will be removed 12 months later since March 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use FileFormatType.Excel97To2003 instead.")]
	Default = 5,
	/// <summary>
	///       Represents an Excel97 file
	///       NOTE: This member is now obsolete. Instead, 
	///       please use <see cref="F:Aspose.Cells.FileFormatType.Excel97To2003" /> property.
	///       This property will be removed 12 months later since March 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.
	///       </summary>
	[Obsolete("Use FileFormatType.Excel97To2003 instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	Excel97 = 2,
	/// <summary>
	///       Represents an Excel2000 file.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use <see cref="F:Aspose.Cells.FileFormatType.Excel97To2003" /> property.
	///       This property will be removed 12 months later since March 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.
	///       </summary>
	[Browsable(false)]
	[Obsolete("Use FileFormatType.Excel97To2003 instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	Excel2000 = 3,
	/// <summary>
	///       Represents an ExcelXP/Excel2002 file.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use <see cref="F:Aspose.Cells.FileFormatType.Excel97To2003" /> property.
	///       This property will be removed 12 months later since March 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.
	///       </summary>
	[Obsolete("Use FileFormatType.Excel97To2003 instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	ExcelXP = 4,
	/// <summary>
	///       Represents an Excel2003 file.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use <see cref="F:Aspose.Cells.FileFormatType.Excel97To2003" /> property.
	///       This property will be removed 12 months later since March 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.
	///       </summary>
	[Browsable(false)]
	[Obsolete("Use FileFormatType.Excel97To2003 instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	Excel2003 = 5,
	/// <summary>
	///       Represents an xlsx file.
	///       </summary>
	Xlsx = 6,
	/// <summary>
	///       Represents an xlsx file.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use <see cref="F:Aspose.Cells.FileFormatType.Xlsx" /> property.
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.
	///       </summary>
	[Obsolete("Use FileFormatType.Xlsx instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	Excel2007Xlsx = 6,
	/// <summary>
	///       Represents an xlsm file which enable macros.
	///       </summary>
	Xlsm = 7,
	/// <summary>
	///       Represents an xlsm file which enable macros.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use <see cref="F:Aspose.Cells.FileFormatType.Xlsm" /> property.
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.
	///       </summary>
	[Obsolete("Use FileFormatType.Xlsm instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	Excel2007Xlsm = 7,
	/// <summary>
	///       Represents a template xltx file.
	///       </summary>
	Xltx = 8,
	/// <summary>
	///       Represents a template xltx file.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use <see cref="F:Aspose.Cells.FileFormatType.Xltx" /> property.
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use FileFormatType.Xltx instead.")]
	Excel2007Xltx = 8,
	/// <summary>
	///       Represents a macro-enabled template xltm file.
	///       </summary>
	Xltm = 9,
	/// <summary>
	///       Represents a macro-enabled template xltm file.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use <see cref="F:Aspose.Cells.FileFormatType.Xltm" /> property.
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.
	///       </summary>
	[Obsolete("Use FileFormatType.Xltm instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	Excel2007Xltm = 9,
	/// <summary>
	///       Represents a SpreadSheetML file.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use <see cref="F:Aspose.Cells.FileFormatType.Excel2003XML" /> property.
	///       This property will be removed 12 months later since May 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.
	///       </summary>
	[Obsolete("Use FileFormatType.Excel2003XML instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	SpreadsheetML = 10,
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
	Excel2003XML = 15,
	/// <summary>
	///       Represents an xlsb file.
	///       </summary>
	Xlsb = 16,
	/// <summary>
	///       Represents an xlsb file.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use <see cref="F:Aspose.Cells.FileFormatType.Xlsb" /> property.
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use FileFormatType.Xlsb instead.")]
	[Browsable(false)]
	Excel2007Xlsb = 16,
	/// <summary>
	///       Represents unrecognized format, cannot be loaded. 
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
	/// <summary>
	///       Represents an Excel95 xls file.
	///       </summary>
	/// <remarks>
	///       The file format is not supported
	///       </remarks>
	Excel95 = 22,
	/// <summary>
	///       Represents an Excel4.0 xls file.
	///       </summary>
	/// <remarks>
	///       The file format is not supported
	///       </remarks>
	Excel4 = 23,
	/// <summary>
	///       Represents an Excel3.0 xls file.
	///       </summary>
	/// <remarks>
	///       The file format is not supported
	///       </remarks>
	Excel3 = 24,
	/// <summary>
	///       Represents an Excel2.1 xls file.
	///       </summary>
	/// <remarks>
	///       The file format is not supported
	///       </remarks>
	Excel2 = 25,
	Pptx = 26,
	Docx = 27,
	SVG = 28,
	/// <summary>
	///       Data Interchange Format.
	///       </summary>
	Dif = 30
}
