using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ns1;
using ns12;
using ns16;
using ns2;
using ns22;
using ns25;
using ns47;
using ns57;

namespace Aspose.Cells;

/// <summary>
///       Provides helper functions.
///       </summary>
public class CellsHelper
{
	private static string string_0;

	private static string string_1;

	private static string string_2;

	/// <summary>
	///       When generating PDF/XPS, specific font file directory can be set in the property.
	///       If it is not set , using %WINDOWS%\fonts by default.
	///       </summary>
	public static string FontDir
	{
		get
		{
			return Class1462.smethod_0();
		}
		set
		{
			Class1462.smethod_1(value);
			new Class1462(bool_0: true);
		}
	}

	/// <summary>
	///       When generating PDF/XPS, specific font file directorys can be set in the property.
	///       If it is not set , using %WINDOWS%\fonts by default.
	///       </summary>
	public static ArrayList FontDirs
	{
		get
		{
			return Class1462.arrayList_0;
		}
		set
		{
			Class1462.arrayList_0 = value;
			new Class1462(bool_0: true);
		}
	}

	/// <summary>
	///       When generating PDF/XPS, specific font files can be set in the property.
	///       such as "d:\myfonts\myArial.ttf" 
	///       </summary>
	public static ArrayList FontFiles
	{
		get
		{
			return Class1462.arrayList_1;
		}
		set
		{
			Class1462.arrayList_1 = value;
			new Class1462(bool_0: true);
		}
	}

	/// <summary>
	///       Gets or sets the startup path, which is referred to by some external formula references.  
	///       </summary>
	public static string StartupPath
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	/// <summary>
	///       Gets or sets the alternate startup path, which is referred to by some external formula references. 
	///       </summary>
	public static string AltStartPath
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	/// <summary>
	///       Gets or sets the library path which is referred to by some external formula references.  
	///       </summary>
	public static string LibraryPath
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	/// <summary>
	///       Get the release version.
	///       </summary>
	/// <returns>The release version.</returns>
	public static string GetVersion()
	{
		return Class1184.smethod_0();
	}

	/// <summary>
	///       Gets whtether the file is protected by Microsoft Rights Management Server.
	///       </summary>
	/// <param name="fileName">The file name.</param>
	/// <returns>
	/// </returns>
	public static bool IsProtectedByRMS(string fileName)
	{
		FileStream fileStream = File.OpenRead(fileName);
		try
		{
			return IsProtectedByRMS(fileStream);
		}
		finally
		{
			fileStream.Close();
		}
	}

	/// <summary>
	///       Gets whether the file is protected by Microsoft Rights Management Server.
	///       </summary>
	/// <param name="stream">The file stream.</param>
	/// <returns>
	/// </returns>
	public static bool IsProtectedByRMS(Stream stream)
	{
		BinaryReader binaryReader = new BinaryReader(stream);
		long num = binaryReader.ReadInt64();
		stream.Seek(-8L, SeekOrigin.Current);
		if (num == -2226271756974174256L)
		{
			Class1317 @class = new Class1317(stream);
			Class1319 class2 = @class.method_9().method_0("\u0006DataSpaces");
			if (class2 == null)
			{
				return false;
			}
			Class1319 class3 = class2.method_0("DataSpaceInfo");
			if (class3 == null)
			{
				return false;
			}
			IList keyList = class3.GetKeyList();
			IEnumerator enumerator = keyList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string text = (string)enumerator.Current;
				if (text.ToUpper().IndexOf("DRM") != -1)
				{
					return true;
				}
			}
		}
		return false;
	}

	/// <summary>
	///       Gets the cell row and column indexes according to its name
	///       </summary>
	/// <param name="cellName">Name of cell.</param>
	/// <param name="row">Output row index</param>
	/// <param name="column">Output column index</param>
	public static void CellNameToIndex(string cellName, out int row, out int column)
	{
		if (cellName == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid cell name");
		}
		column = 0;
		int num = 0;
		for (num = 0; num < cellName.Length; num++)
		{
			int num2 = cellName[num] | 0x20;
			if (num2 < 97 || num2 > 122)
			{
				break;
			}
			column = column * 26 + num2 - 97 + 1;
		}
		if (num != 0 && num != cellName.Length)
		{
			column--;
			row = 0;
			for (; num < cellName.Length; num++)
			{
				int num2 = cellName[num];
				if (num2 < 48 || num2 > 57)
				{
					break;
				}
				row = row * 10 + cellName[num] - 48;
			}
			if (num == cellName.Length && row != 0)
			{
				row--;
				if (row > 1048575 || column > 16383)
				{
					throw new CellsException(ExceptionType.InvalidData, "Invalid cell name");
				}
				return;
			}
			throw new CellsException(ExceptionType.InvalidData, "Invalid cell name");
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid cell name");
	}

	/// <summary>
	///       Gets cell name according to its row and column indexes.
	///       </summary>
	/// <param name="row">Row index.</param>
	/// <param name="column">Column index.</param>
	/// <returns>Name of cell.</returns>
	public static string CellIndexToName(int row, int column)
	{
		Class1677.CheckCell(row, column);
		row++;
		return ColumnIndexToName(column) + row;
	}

	/// <summary>
	///       Gets column name according to column index.
	///       </summary>
	/// <param name="column">Column index.</param>
	/// <returns>Name of column.</returns>
	public static string ColumnIndexToName(int column)
	{
		if (column >= 0 && column <= 16383)
		{
			string text = ((char)(column % 26 + 65)).ToString();
			if (column < 26)
			{
				return text;
			}
			column /= 26;
			int num = 0;
			while (column > 0)
			{
				num = (column - 1) % 26;
				column = (column - 1) / 26;
				text = (char)(num + 65) + text;
			}
			return text;
		}
		throw new ArgumentOutOfRangeException();
	}

	/// <summary>
	///       Gets column index according to column name.
	///       </summary>
	/// <param name="columnName">Column name.</param>
	/// <returns>Column index.</returns>
	public static int ColumnNameToIndex(string columnName)
	{
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < columnName.Length)
			{
				if (char.IsLetter(columnName[num2]))
				{
					num = num * 26 + (columnName[num2] | 0x20) - 97 + 1;
					num2++;
					continue;
				}
				throw new CellsException(ExceptionType.InvalidData, "Invalid Column name.");
			}
			if (num > 0)
			{
				num--;
			}
			if (num <= 16383)
			{
				break;
			}
			throw new CellsException(ExceptionType.Limitation, "Invalid Column name.");
		}
		return num;
	}

	/// <summary>
	///       Gets row name according to row index.
	///       </summary>
	/// <param name="row">Row index.</param>
	/// <returns>Name of row.</returns>
	public static string RowIndexToName(int row)
	{
		row++;
		return row.ToString();
	}

	/// <summary>
	///       Gets row index according to row name.
	///       </summary>
	/// <param name="rowName">Row name.</param>
	/// <returns>Row index.</returns>
	public static int RowNameToIndex(string rowName)
	{
		int num = int.Parse(rowName);
		return num - 1;
	}

	/// <summary>
	///       Converts the r1c1 formula of the cell to A1 formula.
	///       </summary>
	/// <param name="r1c1Formula">The r1c1 formula.</param>
	/// <param name="row">The row index of the cell.</param>
	/// <param name="column">The column index of the cell.</param>
	/// <returns>The A1 formula.</returns>
	public static string ConvertR1C1FormulaToA1(string r1c1Formula, int row, int column)
	{
		return Class1619.smethod_10(r1c1Formula, row, column);
	}

	/// <summary>
	///       Converts A1 formula of the cell to the r1c1 formula.
	///       </summary>
	/// <param name="formula">The A1 formula.</param>
	/// <param name="row">The row index of the cell.</param>
	/// <param name="column">The column index of the cell.</param>
	/// <returns>The R1C1 formula.</returns>
	public static string ConvertA1FormulaToR1C1(string formula, int row, int column)
	{
		return Class1619.smethod_6(formula, row, column);
	}

	public static DateTime GetDateTimeFromDouble(double doubleValue, bool date1904)
	{
		return Class428.GetDateTimeFromDouble(doubleValue, date1904);
	}

	/// <summary>
	///       Convert the date time to double value.
	///       </summary>
	/// <param name="dateTime">The date time.</param>
	/// <param name="date1904">Date 1904 system.</param>
	/// <returns>
	/// </returns>
	public static double GetDoubleFromDateTime(DateTime dateTime, bool date1904)
	{
		return Class428.GetDoubleFromDateTime(dateTime, date1904);
	}

	/// <summary>
	///       Detects the file load format.
	///       </summary>
	/// <param name="fileName">The file name.</param>
	/// <returns>The load format.</returns>
	public static LoadFormat DetectLoadFormat(string fileName)
	{
		FileStream fileStream = null;
		try
		{
			fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			if (fileStream.Length == 0)
			{
				string extension = Path.GetExtension(fileName);
				string key;
				if (extension != null && (key = extension.ToLower()) != null)
				{
					if (Class1742.dictionary_209 == null)
					{
						Class1742.dictionary_209 = new Dictionary<string, int>(12)
						{
							{ ".xls", 0 },
							{ ".xlsx", 1 },
							{ ".xlsm", 2 },
							{ ".xml", 3 },
							{ ".xltx", 4 },
							{ ".xlsb", 5 },
							{ ".xltm", 6 },
							{ ".htm", 7 },
							{ ".html", 8 },
							{ ".txt", 9 },
							{ ".csv", 10 },
							{ ".ods", 11 }
						};
					}
					if (Class1742.dictionary_209.TryGetValue(key, out var value))
					{
						switch (value)
						{
						case 0:
							return LoadFormat.Excel97To2003;
						case 1:
							return LoadFormat.Xlsx;
						case 2:
							return LoadFormat.Xlsx;
						case 3:
							return LoadFormat.SpreadsheetML;
						case 4:
							return LoadFormat.Xlsx;
						case 5:
							return LoadFormat.Xlsb;
						case 6:
							return LoadFormat.Xlsx;
						case 7:
						case 8:
							return LoadFormat.Html;
						case 9:
							return LoadFormat.TabDelimited;
						case 10:
							return LoadFormat.CSV;
						case 11:
							return LoadFormat.ODS;
						}
					}
				}
				return LoadFormat.Unknown;
			}
			bool isValid = false;
			int header = 0;
			LoadFormat result = smethod_0(null, fileStream, out isValid, out header);
			fileStream.Close();
			if (!isValid)
			{
				return LoadFormat.Unknown;
			}
			return result;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			fileStream?.Close();
		}
	}

	/// <summary>
	///       Detects the file load format.
	///       </summary>
	/// <param name="stream">The stream.</param>
	/// <returns>
	/// </returns>
	public static LoadFormat DetectLoadFormat(Stream stream)
	{
		bool isValid = false;
		int header = 0;
		LoadFormat result = smethod_0(null, stream, out isValid, out header);
		if (!isValid)
		{
			return LoadFormat.Unknown;
		}
		return result;
	}

	internal static LoadFormat smethod_0(string fileName, Stream stream, out bool isValid, out int header)
	{
		long position = stream.Position;
		isValid = false;
		LoadFormat result = LoadFormat.Unknown;
		BinaryReader binaryReader = new BinaryReader(stream);
		long num = binaryReader.ReadInt64();
		header = (int)(num & 0xFFFF);
		stream.Seek(-8L, SeekOrigin.Current);
		if (num == -2226271756974174256L)
		{
			isValid = true;
			Class1317 @class = new Class1317(stream);
			if (@class.method_9().GetStream("Workbook") != null)
			{
				result = LoadFormat.Excel97To2003;
			}
			else if (@class.method_9().GetStream("EncryptedPackage") != null)
			{
				result = LoadFormat.Xlsx;
			}
			else
			{
				isValid = false;
				result = LoadFormat.Unknown;
			}
			stream.Seek(position, SeekOrigin.Begin);
		}
		else if ((num & 0xFFFFFFFFu) == 67324752)
		{
			isValid = true;
			result = LoadFormat.Xlsx;
			if (fileName != null)
			{
				string extension = Path.GetExtension(fileName);
				string key;
				if (extension != null && (key = extension.ToLower()) != null)
				{
					if (Class1742.dictionary_210 == null)
					{
						Class1742.dictionary_210 = new Dictionary<string, int>(7)
						{
							{ ".xlsb", 0 },
							{ ".xlsx", 1 },
							{ ".xlsm", 2 },
							{ ".xltx", 3 },
							{ ".xltm", 4 },
							{ ".ods", 5 },
							{ ".ots", 6 }
						};
					}
					if (Class1742.dictionary_210.TryGetValue(key, out var value))
					{
						switch (value)
						{
						case 0:
							result = LoadFormat.Xlsb;
							break;
						case 1:
							result = LoadFormat.Xlsx;
							break;
						case 2:
							result = LoadFormat.Xlsx;
							break;
						case 3:
							result = LoadFormat.Xlsx;
							break;
						case 4:
							result = LoadFormat.Xlsx;
							break;
						case 5:
						case 6:
							result = LoadFormat.ODS;
							break;
						}
					}
				}
			}
			else
			{
				MemoryStream memoryStream = new MemoryStream();
				Class1677.smethod_5(stream, memoryStream);
				Class746 class2 = Class746.Read(memoryStream);
				if (class2.method_40("xl/workbook.bin", bool_18: true) != -1)
				{
					result = LoadFormat.Xlsb;
				}
				else if (class2.method_40("content.xml", bool_18: true) != -1)
				{
					result = LoadFormat.ODS;
				}
				class2.Close();
				memoryStream.Close();
			}
		}
		else
		{
			switch (Class1677.smethod_9(stream, binaryReader, num))
			{
			case 1:
				isValid = true;
				result = LoadFormat.SpreadsheetML;
				break;
			case 2:
				isValid = true;
				result = LoadFormat.Html;
				break;
			}
		}
		return result;
	}

	/// <summary>
	///       Detects the file format type.
	///       </summary>
	/// <param name="fileName">the file name</param>
	/// <returns>The file format type.</returns>
	public static FileFormatType DetectFileFormat(string fileName)
	{
		FileStream fileStream = null;
		try
		{
			fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			FileFormatType result = smethod_1(fileName, fileStream);
			fileStream.Close();
			return result;
		}
		finally
		{
			fileStream?.Close();
		}
	}

	/// <summary>
	///       Detects the format type of the file stored in the stream.
	///       </summary>
	/// <param name="stream">The stream</param>
	/// <returns>The file format type.</returns>
	public static FileFormatType DetectFileFormat(Stream stream)
	{
		return smethod_1(null, stream);
	}

	internal static FileFormatType smethod_1(string string_3, Stream stream_0)
	{
		long position = stream_0.Position;
		bool flag = false;
		FileFormatType result = FileFormatType.Unknown;
		BinaryReader binaryReader = new BinaryReader(stream_0);
		long num = binaryReader.ReadInt64();
		int num2 = (int)(num & 0xFFFF);
		stream_0.Seek(-8L, SeekOrigin.Current);
		if (num == -2226271756974174256L)
		{
			flag = true;
			Class1317 @class = new Class1317(stream_0);
			if (@class.method_9().GetStream("Workbook") != null)
			{
				result = FileFormatType.Default;
			}
			else if (@class.method_9().GetStream("EncryptedPackage") != null)
			{
				result = FileFormatType.Xlsx;
			}
			else if (@class.method_9().GetStream("Book") != null)
			{
				MemoryStream stream = @class.method_9().GetStream("Book");
				byte[] array = new byte[6];
				stream.Read(array, 0, array.Length);
				if (array[0] == 9 && array[1] == 8 && array[2] == 16 && array[3] == 0 && array[4] == 0 && array[5] == 6)
				{
					flag = true;
					result = FileFormatType.Default;
				}
				else
				{
					flag = true;
					result = FileFormatType.Excel95;
				}
			}
			else
			{
				flag = false;
				result = FileFormatType.Unknown;
			}
			stream_0.Seek(position, SeekOrigin.Begin);
		}
		else
		{
			switch (num2)
			{
			case 1033:
				result = FileFormatType.Excel4;
				break;
			case 521:
				result = FileFormatType.Excel3;
				break;
			case 9:
				result = FileFormatType.Excel2;
				break;
			default:
			{
				if ((num & 0xFFFFFFFFu) == 526345)
				{
					result = FileFormatType.Excel95;
					break;
				}
				if ((num & 0xFFFFFFFFu) == 67324752)
				{
					flag = true;
					result = FileFormatType.Xlsx;
					if (string_3 != null)
					{
						string extension = Path.GetExtension(string_3);
						string key;
						if (extension == null || (key = extension.ToLower()) == null)
						{
							break;
						}
						if (Class1742.dictionary_211 == null)
						{
							Class1742.dictionary_211 = new Dictionary<string, int>(8)
							{
								{ ".xlsb", 0 },
								{ ".xlsx", 1 },
								{ ".xlsm", 2 },
								{ ".xltx", 3 },
								{ ".xltm", 4 },
								{ ".ods", 5 },
								{ ".ots", 6 },
								{ ".pptx", 7 }
							};
						}
						if (Class1742.dictionary_211.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
								result = FileFormatType.Xlsb;
								break;
							case 1:
								result = FileFormatType.Xlsx;
								break;
							case 2:
								result = FileFormatType.Xlsm;
								break;
							case 3:
								result = FileFormatType.Xltx;
								break;
							case 4:
								result = FileFormatType.Xltm;
								break;
							case 5:
							case 6:
								result = FileFormatType.ODS;
								break;
							case 7:
								result = FileFormatType.Unknown;
								break;
							}
						}
					}
					else
					{
						MemoryStream memoryStream = new MemoryStream();
						Class1677.smethod_5(stream_0, memoryStream);
						Class746 class2 = Class746.Read(memoryStream);
						result = ((class2.method_40("xl/workbook.xml", bool_18: true) != -1) ? Class1600.DetectFileFormat(class2) : ((class2.method_40("xl/workbook.bin", bool_18: true) != -1) ? FileFormatType.Xlsb : ((class2.method_40("content.xml", bool_18: true) != -1) ? FileFormatType.ODS : ((class2.method_40("ppt/presentation.xml", bool_18: true) != -1) ? FileFormatType.Pptx : ((class2.method_40("word/document.xml", bool_18: true) == -1) ? FileFormatType.Unknown : FileFormatType.Docx)))));
						class2.Close();
						memoryStream.Close();
					}
					break;
				}
				if ((num & 0xFFFFFFFFu) == 1178882085)
				{
					result = FileFormatType.Pdf;
					break;
				}
				switch (Class1677.smethod_9(stream_0, binaryReader, num))
				{
				case 1:
					flag = true;
					result = FileFormatType.Excel2003XML;
					break;
				case 2:
					flag = true;
					result = FileFormatType.Html;
					break;
				}
				if (flag || string_3 == null)
				{
					break;
				}
				string extension2 = Path.GetExtension(string_3);
				if (extension2 != null)
				{
					switch (extension2.ToLower())
					{
					case ".txt":
						flag = true;
						return FileFormatType.TabDelimited;
					case ".csv":
						flag = true;
						return FileFormatType.CSV;
					}
				}
				break;
			}
			}
		}
		return result;
	}

	/// <summary>
	///       Gets all used colors in the workbook.
	///       </summary>
	/// <param name="workbook">The workbook object.</param>
	/// <returns>The used colors.</returns>
	public static Color[] GetUsedColors(Workbook workbook)
	{
		return Class1302.smethod_0(workbook);
	}

	public static void AddAddInFunction(string function, int minCountOfParameters, int maxCountOfParameters, ParameterType[] paramersType, ParameterType fuctionValueType)
	{
		Enum227[] array = new Enum227[paramersType.Length];
		for (int i = 0; i < array.Length; i++)
		{
			switch (paramersType[i])
			{
			case ParameterType.Reference:
				array[i] = Enum227.const_0;
				break;
			case ParameterType.Value:
				array[i] = Enum227.const_1;
				break;
			case ParameterType.Array:
				array[i] = Enum227.const_2;
				break;
			}
		}
		Enum227 enum227_ = Enum227.const_1;
		switch (fuctionValueType)
		{
		case ParameterType.Reference:
			enum227_ = Enum227.const_0;
			break;
		case ParameterType.Array:
			enum227_ = Enum227.const_2;
			break;
		}
		Class1663.AddAddInFunction(function, minCountOfParameters, maxCountOfParameters, array, enum227_);
	}

	/// <summary>
	///       Merges some large files to a file.
	///       </summary>
	/// <param name="files">The files.</param>
	/// <param name="cachedFile">The cached file.</param>
	/// <param name="destFile">The dest file.</param>
	/// <remarks>
	///       This method only supports merging data, style and formulas to the new file.
	///       The cached file is used to store some temporary data.
	///       </remarks>
	public static void MergeFiles(string[] files, string cachedFile, string destFile)
	{
		Class1284 @class = new Class1284();
		@class.Combine(files, cachedFile, destFile);
	}
}
