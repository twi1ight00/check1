using System.Collections.Generic;
using System.IO;
using ns1;

namespace Aspose.Cells;

/// <summary>
///       Provides utility methods for conveting file format enums to strings or file extensions and back.
///       </summary>
public class FileFormatUtil
{
	internal static FileFormatType smethod_0(SaveFormat saveFormat_0, FileFormatType fileFormatType_0)
	{
		return saveFormat_0 switch
		{
			SaveFormat.Auto => FileFormatType.Xlsx, 
			SaveFormat.CSV => FileFormatType.CSV, 
			SaveFormat.Excel97To2003 => FileFormatType.Default, 
			SaveFormat.Xlsx => FileFormatType.Xlsx, 
			SaveFormat.Xlsm => FileFormatType.Xlsm, 
			SaveFormat.Xltx => FileFormatType.Xltx, 
			SaveFormat.Xltm => FileFormatType.Xltm, 
			SaveFormat.TabDelimited => FileFormatType.TabDelimited, 
			SaveFormat.Html => FileFormatType.Html, 
			SaveFormat.Pdf => FileFormatType.Pdf, 
			SaveFormat.ODS => FileFormatType.ODS, 
			SaveFormat.SpreadsheetML => FileFormatType.Excel2003XML, 
			SaveFormat.Xlsb => FileFormatType.Xlsb, 
			SaveFormat.MHtml => FileFormatType.MHtml, 
			_ => fileFormatType_0, 
		};
	}

	internal static SaveOptions smethod_1(string string_0, SaveFormat saveFormat_0, SaveOptions saveOptions_0)
	{
		if (saveFormat_0 == SaveFormat.Auto)
		{
			if (string_0 != null)
			{
				string extension = Path.GetExtension(string_0);
				if (extension != null)
				{
					saveFormat_0 = ExtensionToSaveFormat(extension);
				}
			}
			if (saveFormat_0 == SaveFormat.Auto || saveFormat_0 == SaveFormat.Unknown)
			{
				return new OoxmlSaveOptions(saveOptions_0);
			}
		}
		switch (saveFormat_0)
		{
		case SaveFormat.Excel97To2003:
			return new XlsSaveOptions(saveOptions_0);
		case SaveFormat.Xlsx:
		case SaveFormat.Xlsm:
		case SaveFormat.Xltx:
		case SaveFormat.Xltm:
			return new OoxmlSaveOptions(saveFormat_0, saveOptions_0);
		case SaveFormat.CSV:
		case SaveFormat.TabDelimited:
			return new TxtSaveOptions(saveFormat_0, saveOptions_0);
		case SaveFormat.Html:
			return new HtmlSaveOptions(saveOptions_0);
		case SaveFormat.Pdf:
			return new PdfSaveOptions(saveOptions_0);
		case SaveFormat.ODS:
			return new OdsSaveOptions(saveOptions_0);
		case SaveFormat.SpreadsheetML:
			return new SpreadsheetML2003SaveOptions(saveOptions_0);
		case SaveFormat.Xlsb:
			return new XlsbSaveOptions(saveOptions_0);
		case SaveFormat.MHtml:
			return new HtmlSaveOptions(SaveFormat.MHtml);
		case SaveFormat.XPS:
			return new XpsSaveOptions(saveFormat_0);
		case SaveFormat.TIFF:
			return new ImageSaveOptions(saveFormat_0);
		case SaveFormat.SVG:
			return new SvgSaveOptions(saveFormat_0);
		default:
			return new OoxmlSaveOptions(saveOptions_0);
		case SaveFormat.Dif:
			return new DifSaveOptions();
		}
	}

	internal static FileFormatType smethod_2(string string_0, FileFormatType fileFormatType_0)
	{
		FileFormatType result = fileFormatType_0;
		string key;
		if (string_0 != null && (key = string_0.ToLower()) != null)
		{
			if (Class1742.dictionary_50 == null)
			{
				Class1742.dictionary_50 = new Dictionary<string, int>(20)
				{
					{ ".xls", 0 },
					{ ".xlt", 1 },
					{ ".xlsx", 2 },
					{ ".xlsm", 3 },
					{ ".xml", 4 },
					{ ".xltx", 5 },
					{ ".xlsb", 6 },
					{ ".xltm", 7 },
					{ ".htm", 8 },
					{ ".html", 9 },
					{ ".mht", 10 },
					{ ".mhtml", 11 },
					{ ".txt", 12 },
					{ ".csv", 13 },
					{ ".pdf", 14 },
					{ ".ods", 15 },
					{ ".xps", 16 },
					{ ".tiff", 17 },
					{ ".svg", 18 },
					{ ".dif", 19 }
				};
			}
			if (Class1742.dictionary_50.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
					result = FileFormatType.Default;
					break;
				case 2:
					result = FileFormatType.Xlsx;
					break;
				case 3:
					result = FileFormatType.Xlsm;
					break;
				case 4:
					result = FileFormatType.Excel2003XML;
					break;
				case 5:
					result = FileFormatType.Xltx;
					break;
				case 6:
					result = FileFormatType.Xlsb;
					break;
				case 7:
					result = FileFormatType.Xltm;
					break;
				case 8:
				case 9:
					result = FileFormatType.Html;
					break;
				case 10:
				case 11:
					result = FileFormatType.MHtml;
					break;
				case 12:
					result = FileFormatType.TabDelimited;
					break;
				case 13:
					result = FileFormatType.CSV;
					break;
				case 14:
					result = FileFormatType.Pdf;
					break;
				case 15:
					result = FileFormatType.ODS;
					break;
				case 16:
					result = FileFormatType.XPS;
					break;
				case 17:
					result = FileFormatType.TIFF;
					break;
				case 18:
					result = FileFormatType.SVG;
					break;
				case 19:
					result = FileFormatType.Dif;
					break;
				}
			}
		}
		return result;
	}

	/// <summary>
	///       Converts a file name extension into a SaveFormat value.
	///       </summary>
	/// <param name="extension">The file extension. Can be with or without a leading dot. Case-insensitive.</param>
	/// <returns>
	/// </returns>
	/// <remarks>If the extension cannot be recognized, returns <see cref="F:Aspose.Cells.SaveFormat.Unknown" />.</remarks>
	public static SaveFormat ExtensionToSaveFormat(string extension)
	{
		if (extension[0] != '.')
		{
			extension = "." + extension;
		}
		string key;
		if ((key = extension.ToLower()) != null)
		{
			if (Class1742.dictionary_51 == null)
			{
				Class1742.dictionary_51 = new Dictionary<string, int>(19)
				{
					{ ".xls", 0 },
					{ ".xlt", 1 },
					{ ".xlsx", 2 },
					{ ".xlsm", 3 },
					{ ".xml", 4 },
					{ ".xltx", 5 },
					{ ".xlsb", 6 },
					{ ".xltm", 7 },
					{ ".htm", 8 },
					{ ".html", 9 },
					{ ".mht", 10 },
					{ ".mhtml", 11 },
					{ ".txt", 12 },
					{ ".csv", 13 },
					{ ".pdf", 14 },
					{ ".ods", 15 },
					{ ".ots", 16 },
					{ ".xps", 17 },
					{ ".dif", 18 }
				};
			}
			if (Class1742.dictionary_51.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
					return SaveFormat.Excel97To2003;
				case 2:
					return SaveFormat.Xlsx;
				case 3:
					return SaveFormat.Xlsm;
				case 4:
					return SaveFormat.SpreadsheetML;
				case 5:
					return SaveFormat.Xltx;
				case 6:
					return SaveFormat.Xlsb;
				case 7:
					return SaveFormat.Xltm;
				case 8:
				case 9:
					return SaveFormat.Html;
				case 10:
				case 11:
					return SaveFormat.MHtml;
				case 12:
					return SaveFormat.TabDelimited;
				case 13:
					return SaveFormat.CSV;
				case 14:
					return SaveFormat.Pdf;
				case 15:
				case 16:
					return SaveFormat.ODS;
				case 17:
					return SaveFormat.XPS;
				case 18:
					return SaveFormat.Dif;
				}
			}
		}
		return SaveFormat.Unknown;
	}

	/// <summary>
	///       Returns true if the extension is .xlt, .xltX, .xltm,.ots.
	///       </summary>
	/// <param name="extension">
	/// </param>
	/// <returns>
	/// </returns>
	public static bool IsTemplateFormat(string extension)
	{
		extension = ((extension[0] != '.') ? ("." + extension.ToLower()) : extension.ToLower());
		switch (extension)
		{
		case ".xlt":
		case ".xltx":
		case ".xltm":
		case ".ots":
			return true;
		default:
			return false;
		}
	}

	/// <summary>
	///       Converts a load format enumerated value into a file extension.
	///       </summary>
	/// <param name="loadFormat">The loaded file format.</param>
	/// <returns> The returned extension is a lower-case string with a leading dot.</returns>
	/// <remarks>If can not convert, returns null.</remarks>
	public static string LoadFormatToExtension(LoadFormat loadFormat)
	{
		return loadFormat switch
		{
			LoadFormat.TabDelimited => ".txt", 
			LoadFormat.ODS => ".ods", 
			LoadFormat.SpreadsheetML => ".xml", 
			LoadFormat.Xlsb => ".xlsb", 
			LoadFormat.Excel97To2003 => ".xls", 
			LoadFormat.Xlsx => ".xlsx", 
			LoadFormat.CSV => ".csv", 
			_ => null, 
		};
	}

	/// <summary>
	///       Converts a LoadFormat value to a SaveFormat value if possible. 
	///       </summary>
	/// <param name="loadFormat">The load format.</param>
	/// <returns>The save format.</returns>
	public static SaveFormat LoadFormatToSaveFormat(LoadFormat loadFormat)
	{
		return loadFormat switch
		{
			LoadFormat.TabDelimited => SaveFormat.TabDelimited, 
			LoadFormat.ODS => SaveFormat.ODS, 
			LoadFormat.SpreadsheetML => SaveFormat.SpreadsheetML, 
			LoadFormat.Xlsb => SaveFormat.Xlsb, 
			LoadFormat.Auto => SaveFormat.Auto, 
			LoadFormat.CSV => SaveFormat.CSV, 
			LoadFormat.Excel97To2003 => SaveFormat.Excel97To2003, 
			LoadFormat.Xlsx => SaveFormat.Xlsx, 
			_ => SaveFormat.Unknown, 
		};
	}

	/// <summary>
	///       Converts a save format enumerated value into a file extension.
	///       </summary>
	/// <param name="format">The save format.</param>
	/// <returns>The returned extension is a lower-case string with a leading dot. </returns>
	public static string SaveFormatToExtension(SaveFormat format)
	{
		return format switch
		{
			SaveFormat.CSV => ".csv", 
			SaveFormat.Excel97To2003 => ".xls", 
			SaveFormat.Xlsx => ".xlsx", 
			SaveFormat.Xlsm => ".xlsm", 
			SaveFormat.Xltx => ".xltx", 
			SaveFormat.Xltm => ".xltm", 
			SaveFormat.TabDelimited => ".txt", 
			SaveFormat.Html => ".html", 
			SaveFormat.Pdf => ".pdf", 
			SaveFormat.ODS => ".ods", 
			SaveFormat.SpreadsheetML => ".xml", 
			SaveFormat.Xlsb => ".xlsb", 
			_ => null, 
		};
	}

	/// <summary>
	///       Converts a SaveFormat value to a LoadFormat value if possible. 
	///       </summary>
	/// <param name="saveFormat">The save format.</param>
	/// <returns>The load format</returns>
	public static LoadFormat SaveFormatToLoadFormat(SaveFormat saveFormat)
	{
		switch (saveFormat)
		{
		case SaveFormat.Auto:
			return LoadFormat.Auto;
		case SaveFormat.CSV:
			return LoadFormat.CSV;
		case SaveFormat.Excel97To2003:
			return LoadFormat.Excel97To2003;
		case SaveFormat.Xlsx:
		case SaveFormat.Xltx:
			return LoadFormat.Xlsx;
		case SaveFormat.Xlsm:
		case SaveFormat.Xltm:
			return LoadFormat.Xlsx;
		default:
			return LoadFormat.Unknown;
		case SaveFormat.TabDelimited:
			return LoadFormat.TabDelimited;
		case SaveFormat.Html:
			return LoadFormat.Unknown;
		case SaveFormat.Pdf:
			return LoadFormat.Unknown;
		case SaveFormat.ODS:
			return LoadFormat.ODS;
		case SaveFormat.SpreadsheetML:
			return LoadFormat.SpreadsheetML;
		case SaveFormat.Xlsb:
			return LoadFormat.Xlsb;
		}
	}

	internal static SaveOptions smethod_3(FileFormatType fileFormatType_0, SaveOptions saveOptions_0)
	{
		switch (fileFormatType_0)
		{
		case FileFormatType.CSV:
			return new TxtSaveOptions(SaveFormat.CSV, saveOptions_0);
		case FileFormatType.Excel97:
		case FileFormatType.Excel2000:
		case FileFormatType.ExcelXP:
		case FileFormatType.Default:
			return new XlsSaveOptions(saveOptions_0);
		case FileFormatType.Xlsx:
			return new OoxmlSaveOptions(SaveFormat.Xlsx, saveOptions_0);
		case FileFormatType.Xlsm:
			return new OoxmlSaveOptions(SaveFormat.Xlsm, saveOptions_0);
		case FileFormatType.Xltx:
			return new OoxmlSaveOptions(SaveFormat.Xltx, saveOptions_0);
		case FileFormatType.Xltm:
			return new OoxmlSaveOptions(SaveFormat.Xltm, saveOptions_0);
		case FileFormatType.TabDelimited:
			return new TxtSaveOptions(SaveFormat.TabDelimited, saveOptions_0);
		case FileFormatType.Html:
			return new HtmlSaveOptions(saveOptions_0);
		case FileFormatType.Pdf:
			return new PdfSaveOptions(saveOptions_0);
		case FileFormatType.ODS:
			return new OdsSaveOptions(saveOptions_0);
		case FileFormatType.SpreadsheetML:
		case FileFormatType.Excel2003XML:
			return new SpreadsheetML2003SaveOptions(saveOptions_0);
		case FileFormatType.Xlsb:
			return new XlsbSaveOptions(saveOptions_0);
		case FileFormatType.MHtml:
			return new HtmlSaveOptions(saveOptions_0, bool_13: true);
		case FileFormatType.XPS:
			return XpsSaveOptions.smethod_0(saveOptions_0);
		case FileFormatType.TIFF:
			saveOptions_0.method_0(SaveFormat.TIFF);
			return ImageSaveOptions.smethod_0(saveOptions_0);
		case FileFormatType.SVG:
			return SvgSaveOptions.smethod_1(saveOptions_0);
		default:
			return new OoxmlSaveOptions(SaveFormat.Xlsx, saveOptions_0);
		case FileFormatType.Dif:
			return new DifSaveOptions(saveOptions_0);
		}
	}
}
