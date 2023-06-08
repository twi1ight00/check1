using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Tables;
using ns1;
using ns11;
using ns22;
using ns29;
using ns57;

namespace ns2;

internal class Class1677
{
	internal static double smethod_0(double double_0, WorksheetCollection worksheetCollection_0)
	{
		int num = worksheetCollection_0.method_72();
		int num2 = worksheetCollection_0.method_71();
		int num3 = worksheetCollection_0.method_73();
		if (double_0 < (double)(num + num3))
		{
			return 1.0 * double_0 / (double)(num + num3);
		}
		return (double)(int)((double)(int)(double_0 - (double)(int)((double)(num * num2) / 256.0 + 0.5)) * 100.0 / (double)num + 0.5) / 100.0;
	}

	internal static int smethod_1(double double_0, WorksheetCollection worksheetCollection_0)
	{
		if (double_0 > 1.0)
		{
			int num = (int)(double_0 * (double)worksheetCollection_0.method_72() + 0.5);
			int num2 = (int)((double)(worksheetCollection_0.method_72() * worksheetCollection_0.method_71()) / 256.0 + 0.5);
			return num + num2;
		}
		return (int)(double_0 * (double)(worksheetCollection_0.method_72() + (int)((double)(worksheetCollection_0.method_72() * worksheetCollection_0.method_71()) / 256.0 + 0.5)) + 0.5);
	}

	internal static PaperSizeType smethod_2(double double_0, double double_1)
	{
		if (double_0 < 3.8)
		{
			return PaperSizeType.PaperEnvelopePersonal;
		}
		if (double_0 < 3.9)
		{
			if (double_1 < 8.0)
			{
				return PaperSizeType.PaperEnvelopeMonarch;
			}
			return PaperSizeType.PaperEnvelope9;
		}
		if (double_0 < 4.0)
		{
			return PaperSizeType.PaperJapanesePostcard;
		}
		if (double_0 < 4.3)
		{
			return PaperSizeType.PaperEnvelope10;
		}
		if (double_0 < 4.45)
		{
			if (double_1 < 8.9)
			{
				return PaperSizeType.PaperEnvelopeDL;
			}
			return PaperSizeType.PaperEnvelopeItaly;
		}
		if (double_0 < 4.49)
		{
			if (double_1 < 7.5)
			{
				return PaperSizeType.PaperEnvelopeC6;
			}
			return PaperSizeType.PaperEnvelopeC65;
		}
		if (double_0 < 4.65)
		{
			return PaperSizeType.PaperEnvelope11;
		}
		if (double_0 < 4.9)
		{
			return PaperSizeType.PaperEnvelope12;
		}
		if (double_0 < 5.25)
		{
			return PaperSizeType.PaperEnvelope14;
		}
		if (double_0 < 5.7)
		{
			return PaperSizeType.PaperStatement;
		}
		if (double_0 < 6.0)
		{
			return PaperSizeType.PaperA5;
		}
		if (double_0 < 6.8)
		{
			return PaperSizeType.PaperEnvelopeC5;
		}
		if (double_0 < 7.3)
		{
			return PaperSizeType.PaperB5;
		}
		if (double_0 < 7.9)
		{
			return PaperSizeType.PaperExecutive;
		}
		if (double_0 < 8.36)
		{
			return PaperSizeType.PaperA4;
		}
		if (double_0 < 8.48)
		{
			return PaperSizeType.PaperQuarto;
		}
		if (double_0 < 8.58)
		{
			if (double_1 < 11.5)
			{
				return PaperSizeType.PaperLetter;
			}
			if (double_1 < 12.5)
			{
				return PaperSizeType.PaperFanfoldStdGerman;
			}
			if (double_1 < 13.5)
			{
				return PaperSizeType.PaperFolio;
			}
			return PaperSizeType.PaperLegal;
		}
		if (double_0 < 8.85)
		{
			return PaperSizeType.PaperEnvelopeInvite;
		}
		if (double_0 < 9.01)
		{
			return PaperSizeType.Paper9x11;
		}
		if (double_0 < 9.4)
		{
			return PaperSizeType.PaperEnvelopeC4;
		}
		if (double_0 < 9.9)
		{
			return PaperSizeType.PaperB4;
		}
		if (double_0 < 10.5)
		{
			if (double_1 < 12.5)
			{
				return PaperSizeType.Paper10x11;
			}
			return PaperSizeType.Paper10x14;
		}
		if (double_0 < 11.4)
		{
			return PaperSizeType.Paper11x17;
		}
		if (double_0 < 12.2)
		{
			return PaperSizeType.PaperA3;
		}
		if (double_0 < 13.7)
		{
			return PaperSizeType.PaperEnvelopeC3;
		}
		if (double_0 < 14.9)
		{
			return PaperSizeType.PaperFanfoldUS;
		}
		if (double_0 < 16.0)
		{
			return PaperSizeType.Paper15x11;
		}
		return PaperSizeType.PaperA4;
	}

	internal static void smethod_3(PageSetup pageSetup, out double pageWidthBase, out double pageHeightBase)
	{
		pageWidthBase = 0.0;
		pageHeightBase = 0.0;
		switch (pageSetup.PaperSize)
		{
		default:
			pageWidthBase = Math.Round(8.267716535433072, 2);
			pageHeightBase = Math.Round(11.692913385826772, 2);
			break;
		case PaperSizeType.PaperLetter:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 11.0;
			break;
		}
		case PaperSizeType.PaperLetterSmall:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 11.0;
			break;
		}
		case PaperSizeType.PaperTabloid:
			pageWidthBase = 11.0;
			pageHeightBase = 17.0;
			break;
		case PaperSizeType.PaperLedger:
			pageWidthBase = 17.0;
			pageHeightBase = 11.0;
			break;
		case PaperSizeType.PaperLegal:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 14.0;
			break;
		}
		case PaperSizeType.PaperStatement:
			pageWidthBase = 5.5;
			pageHeightBase = 8.5;
			break;
		case PaperSizeType.PaperExecutive:
		{
			double value = 7.5;
			pageWidthBase = Math.Round(value, 2);
			value = 10.5;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperA3:
			pageWidthBase = Math.Round(11.692913385826772, 2);
			pageHeightBase = Math.Round(16.535433070866144, 2);
			break;
		case PaperSizeType.PaperA4:
			pageWidthBase = Math.Round(8.267716535433072, 2);
			pageHeightBase = Math.Round(11.692913385826772, 2);
			break;
		case PaperSizeType.PaperA4Small:
			pageWidthBase = Math.Round(8.267716535433072, 2);
			pageHeightBase = Math.Round(11.692913385826772, 2);
			break;
		case PaperSizeType.PaperA5:
			pageWidthBase = Math.Round(5.826771653543307, 2);
			pageHeightBase = Math.Round(8.267716535433072, 2);
			break;
		case PaperSizeType.PaperB4:
			pageWidthBase = Math.Round(9.84251968503937, 2);
			pageHeightBase = Math.Round(13.937007874015748, 2);
			break;
		case PaperSizeType.PaperB5:
			pageWidthBase = Math.Round(7.165354330708662, 2);
			pageHeightBase = Math.Round(10.118110236220472, 2);
			break;
		case PaperSizeType.PaperFolio:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 13.0;
			break;
		}
		case PaperSizeType.PaperQuarto:
			pageWidthBase = Math.Round(8.46456692913386, 2);
			pageHeightBase = Math.Round(10.826771653543307, 2);
			break;
		case PaperSizeType.Paper10x14:
			pageWidthBase = 10.0;
			pageHeightBase = 14.0;
			break;
		case PaperSizeType.Paper11x17:
			pageWidthBase = 11.0;
			pageHeightBase = 17.0;
			break;
		case PaperSizeType.PaperNote:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 11.0;
			break;
		}
		case PaperSizeType.PaperEnvelope9:
		{
			double value = 3.875;
			pageWidthBase = Math.Round(value, 2);
			value = 8.875;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperEnvelope10:
		{
			double value = 4.125;
			pageWidthBase = Math.Round(value, 2);
			value = 9.5;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperEnvelope11:
		{
			double value = 4.5;
			pageWidthBase = Math.Round(value, 2);
			value = 10.375;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperEnvelope12:
		{
			double value = 4.75;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 11.0;
			break;
		}
		case PaperSizeType.PaperEnvelope14:
		{
			pageWidthBase = 5.0;
			double value = 11.5;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperEnvelopeDL:
			pageWidthBase = Math.Round(4.330708661417323, 2);
			pageHeightBase = Math.Round(8.661417322834646, 2);
			break;
		case PaperSizeType.PaperEnvelopeC5:
			pageWidthBase = Math.Round(6.377952755905512, 2);
			pageHeightBase = Math.Round(9.015748031496063, 2);
			break;
		case PaperSizeType.PaperEnvelopeC3:
			pageWidthBase = Math.Round(12.755905511811024, 2);
			pageHeightBase = Math.Round(18.031496062992126, 2);
			break;
		case PaperSizeType.PaperEnvelopeC4:
			pageWidthBase = Math.Round(9.015748031496063, 2);
			pageHeightBase = Math.Round(12.755905511811024, 2);
			break;
		case PaperSizeType.PaperEnvelopeC6:
			pageWidthBase = Math.Round(4.488188976377953, 2);
			pageHeightBase = Math.Round(6.377952755905512, 2);
			break;
		case PaperSizeType.PaperEnvelopeC65:
			pageWidthBase = Math.Round(4.488188976377953, 2);
			pageHeightBase = Math.Round(9.015748031496063, 2);
			break;
		case PaperSizeType.PaperEnvelopeB4:
			pageWidthBase = Math.Round(9.84251968503937, 2);
			pageHeightBase = Math.Round(13.89763779527559, 2);
			break;
		case PaperSizeType.PaperEnvelopeB5:
			pageWidthBase = Math.Round(6.929133858267717, 2);
			pageHeightBase = Math.Round(9.84251968503937, 2);
			break;
		case PaperSizeType.PaperEnvelopeB6:
			pageWidthBase = Math.Round(6.929133858267717, 2);
			pageHeightBase = Math.Round(4.921259842519685, 2);
			break;
		case PaperSizeType.PaperEnvelopeItaly:
			pageWidthBase = Math.Round(4.330708661417323, 2);
			pageHeightBase = Math.Round(9.05511811023622, 2);
			break;
		case PaperSizeType.PaperEnvelopeMonarch:
		{
			double value = 3.875;
			pageWidthBase = Math.Round(value, 2);
			value = 7.5;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperEnvelopePersonal:
		{
			double value = 3.625;
			pageWidthBase = Math.Round(value, 2);
			value = 6.5;
			pageHeightBase = Math.Round(value, 2);
			break;
		}
		case PaperSizeType.PaperFanfoldUS:
		{
			double value = 14.875;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 11.0;
			break;
		}
		case PaperSizeType.PaperFanfoldStdGerman:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 12.0;
			break;
		}
		case PaperSizeType.PaperFanfoldLegalGerman:
		{
			double value = 8.5;
			pageWidthBase = Math.Round(value, 2);
			pageHeightBase = 13.0;
			break;
		}
		case PaperSizeType.PaperCSheet:
		case PaperSizeType.PaperDSheet:
		case PaperSizeType.PaperESheet:
			break;
		}
		if (pageSetup.Orientation == PageOrientationType.Landscape)
		{
			double num = pageWidthBase;
			pageWidthBase = pageHeightBase;
			pageHeightBase = num;
		}
	}

	internal static void smethod_4(Cell cell_0, object object_0, bool bool_0, string string_0, bool bool_1)
	{
		if (object_0 == null)
		{
			return;
		}
		if (bool_1)
		{
			if (object_0 is string)
			{
				cell_0.PutValue((string)object_0, isConverted: true);
			}
			else
			{
				cell_0.PutValue(object_0);
			}
		}
		else
		{
			cell_0.PutValue(object_0);
		}
		if (bool_0 && string_0 != null && string_0 != "")
		{
			Style style = cell_0.method_28();
			style.Custom = string_0;
			cell_0.method_30(style);
		}
	}

	internal static void smethod_5(Stream stream_0, Stream stream_1)
	{
		long position = stream_0.Position;
		byte[] array = new byte[4096];
		while (true)
		{
			int num = stream_0.Read(array, 0, array.Length);
			if (num <= 0)
			{
				break;
			}
			stream_1.Write(array, 0, num);
		}
		stream_1.Seek(0L, SeekOrigin.Begin);
		stream_0.Seek(position, SeekOrigin.Begin);
	}

	internal static bool smethod_6(Stream stream_0)
	{
		BinaryReader binaryReader = new BinaryReader(stream_0);
		int num = binaryReader.ReadInt32();
		stream_0.Seek(-4L, SeekOrigin.Current);
		return num == 67324752;
	}

	internal static FileFormatType smethod_7(string fileName, Stream stream, out bool isValid, out int header)
	{
		isValid = false;
		FileFormatType result = FileFormatType.Xlsx;
		BinaryReader binaryReader = new BinaryReader(stream);
		long num = binaryReader.ReadInt64();
		header = (int)(num & 0xFFFF);
		stream.Seek(-8L, SeekOrigin.Current);
		if (num == -2226271756974174256L)
		{
			isValid = true;
			result = FileFormatType.Default;
		}
		else if ((num & 0xFFFFFFFFu) == 67324752)
		{
			isValid = true;
			result = FileFormatType.Xlsx;
			if (fileName != null)
			{
				string extension = Path.GetExtension(fileName);
				string key;
				if (extension != null && (key = extension.ToLower()) != null)
				{
					if (Class1742.dictionary_215 == null)
					{
						Class1742.dictionary_215 = new Dictionary<string, int>(7)
						{
							{ ".xlsx", 0 },
							{ ".xlsm", 1 },
							{ ".xltx", 2 },
							{ ".xltm", 3 },
							{ ".xlsb", 4 },
							{ ".ods", 5 },
							{ ".ots", 6 }
						};
					}
					if (Class1742.dictionary_215.TryGetValue(key, out var value))
					{
						switch (value)
						{
						case 0:
							result = FileFormatType.Xlsx;
							break;
						case 1:
							result = FileFormatType.Xlsm;
							break;
						case 2:
							result = FileFormatType.Xltx;
							break;
						case 3:
							result = FileFormatType.Xltm;
							break;
						case 4:
							result = FileFormatType.Xlsb;
							break;
						case 5:
						case 6:
							result = FileFormatType.ODS;
							break;
						}
					}
				}
			}
		}
		else
		{
			int num2 = smethod_9(stream, binaryReader, num);
			int num3 = num2;
			if (num3 == 1)
			{
				isValid = true;
				result = FileFormatType.Excel2003XML;
			}
		}
		if (!isValid && fileName != null)
		{
			string extension2 = Path.GetExtension(fileName);
			if (extension2 != null)
			{
				switch (extension2.ToLower())
				{
				case ".txt":
					isValid = true;
					return FileFormatType.TabDelimited;
				case ".csv":
					isValid = true;
					return FileFormatType.CSV;
				}
			}
		}
		return result;
	}

	internal static LoadFormat smethod_8(string fileName, Stream stream, out bool isValid, out int header)
	{
		isValid = false;
		LoadFormat result = LoadFormat.Xlsx;
		if (stream.Length < 8)
		{
			header = 0;
			string extension = Path.GetExtension(fileName);
			string key;
			if (extension != null && (key = extension.ToLower()) != null)
			{
				if (Class1742.dictionary_216 == null)
				{
					Class1742.dictionary_216 = new Dictionary<string, int>(14)
					{
						{ ".xls", 0 },
						{ ".xlsx", 1 },
						{ ".xlsm", 2 },
						{ ".xltx", 3 },
						{ ".xltm", 4 },
						{ ".xml", 5 },
						{ ".xlsb", 6 },
						{ ".txt", 7 },
						{ ".csv", 8 },
						{ ".ods", 9 },
						{ ".htm", 10 },
						{ ".html", 11 },
						{ ".mht", 12 },
						{ ".mhtml", 13 }
					};
				}
				if (Class1742.dictionary_216.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						isValid = true;
						result = LoadFormat.Excel97To2003;
						break;
					case 1:
					case 2:
					case 3:
					case 4:
						isValid = true;
						result = LoadFormat.Xlsx;
						break;
					case 5:
						isValid = true;
						result = LoadFormat.SpreadsheetML;
						break;
					case 6:
						isValid = true;
						result = LoadFormat.Xlsb;
						break;
					case 7:
						isValid = true;
						result = LoadFormat.TabDelimited;
						break;
					case 8:
						isValid = true;
						result = LoadFormat.CSV;
						break;
					case 9:
						isValid = true;
						result = LoadFormat.ODS;
						break;
					case 10:
					case 11:
						isValid = true;
						result = LoadFormat.Html;
						break;
					case 12:
					case 13:
						isValid = true;
						result = LoadFormat.MHtml;
						break;
					}
				}
			}
			return result;
		}
		BinaryReader binaryReader = new BinaryReader(stream);
		long num = binaryReader.ReadInt64();
		header = (int)(num & 0xFFFF);
		stream.Seek(-8L, SeekOrigin.Current);
		if (num == -2226271756974174256L)
		{
			isValid = true;
			result = LoadFormat.Excel97To2003;
		}
		else if ((num & 0xFFFFFFFFu) == 67324752)
		{
			isValid = true;
			result = LoadFormat.Xlsx;
			if (fileName != null)
			{
				string extension2 = Path.GetExtension(fileName);
				string key2;
				if (extension2 != null && (key2 = extension2.ToLower()) != null)
				{
					if (Class1742.dictionary_217 == null)
					{
						Class1742.dictionary_217 = new Dictionary<string, int>(7)
						{
							{ ".xlsx", 0 },
							{ ".xlsm", 1 },
							{ ".xltx", 2 },
							{ ".xltm", 3 },
							{ ".xlsb", 4 },
							{ ".ods", 5 },
							{ ".ots", 6 }
						};
					}
					if (Class1742.dictionary_217.TryGetValue(key2, out var value2))
					{
						switch (value2)
						{
						case 0:
						case 1:
						case 2:
						case 3:
							result = LoadFormat.Xlsx;
							break;
						case 4:
							result = LoadFormat.Xlsb;
							break;
						case 5:
						case 6:
							result = LoadFormat.ODS;
							break;
						}
					}
				}
			}
		}
		else
		{
			switch (smethod_9(stream, binaryReader, num))
			{
			case 1:
				isValid = true;
				result = LoadFormat.SpreadsheetML;
				break;
			case 2:
				isValid = true;
				result = LoadFormat.Html;
				break;
			case 3:
				isValid = true;
				result = LoadFormat.MHtml;
				break;
			}
		}
		if (!isValid && fileName != null)
		{
			string extension3 = Path.GetExtension(fileName);
			if (extension3 != null)
			{
				switch (extension3.ToLower())
				{
				case ".htm":
				case ".html":
					isValid = true;
					return LoadFormat.Html;
				case ".mht":
				case ".mhtml":
					isValid = true;
					return LoadFormat.MHtml;
				case ".txt":
					isValid = true;
					return LoadFormat.TabDelimited;
				case ".csv":
					isValid = true;
					return LoadFormat.CSV;
				}
			}
		}
		return result;
	}

	internal static string CellIndexToName(int int_0, int int_1, bool bool_0, bool bool_1)
	{
		int_0++;
		StringBuilder stringBuilder = new StringBuilder();
		if (bool_1)
		{
			stringBuilder.Append('$');
		}
		stringBuilder.Append(CellsHelper.ColumnIndexToName(int_1));
		if (bool_0)
		{
			stringBuilder.Append('$');
		}
		stringBuilder.Append(int_0.ToString());
		return stringBuilder.ToString();
	}

	internal static int smethod_9(Stream stream_0, BinaryReader binaryReader_0, long long_0)
	{
		int num = 0;
		if ((long_0 & 0xFFFFFF) == 12565487)
		{
			stream_0.Seek(3L, SeekOrigin.Current);
			long_0 >>= 24;
		}
		else if ((long_0 & 0xFFFF) == 65279 || (long_0 & 0xFFFF) == 65534)
		{
			binaryReader_0 = new BinaryReader(stream_0, Encoding.Unicode);
			stream_0.Seek(2L, SeekOrigin.Current);
			num = 1;
			long_0 >>= 16;
		}
		while ((long_0 & 0xFF) == 10 || (long_0 & 0xFF) == 13)
		{
			long_0 >>= 8;
			stream_0.Seek(1L, SeekOrigin.Current);
		}
		if ((long_0 & 0xFF) == 60)
		{
			string text = Class1679.smethod_6(binaryReader_0, 5, num > 0).ToLower();
			if (text.Equals("<?xml"))
			{
				stream_0.Seek(0L, SeekOrigin.Begin);
				return 1;
			}
			if (text.Equals("<html"))
			{
				stream_0.Seek(0L, SeekOrigin.Begin);
				return 2;
			}
			if (text.Equals("<!doc"))
			{
				text += Class1679.smethod_6(binaryReader_0, 9, num > 0).ToLower();
				if (text == "<!doctype html")
				{
					stream_0.Seek(0L, SeekOrigin.Begin);
					return 2;
				}
			}
		}
		if ((long_0 & 0xFF) == 77)
		{
			string text2 = Class1679.smethod_6(binaryReader_0, 4, num > 0).ToLower();
			if (text2.Equals("mime"))
			{
				stream_0.Seek(0L, SeekOrigin.Begin);
				return 3;
			}
		}
		stream_0.Seek(0L, SeekOrigin.Begin);
		return -1;
	}

	internal static Guid smethod_10(OleFileType oleFileType_0)
	{
		return oleFileType_0 switch
		{
			OleFileType.Doc => new Guid("00020906-0000-0000-c000-000000000046"), 
			OleFileType.Ppt => new Guid("64818d10-4f9b-11cf-86ea-00aa00b929e8"), 
			OleFileType.Pdf => new Guid("b801ca65-a1fc-11d0-85ad-444553540000"), 
			OleFileType.MapiMessage => new Guid("00020d09-0000-0000-c000-000000000046"), 
			_ => WorksheetCollection.guid_0, 
		};
	}

	internal static OleFileType smethod_11(Class1317 class1317_0)
	{
		if (class1317_0.method_9().GetStream("Workbook") != null)
		{
			return OleFileType.Xls;
		}
		if (class1317_0.method_9().GetStream("PowerPoint Document") != null)
		{
			return OleFileType.Ppt;
		}
		if (class1317_0.method_9().GetStream("WordDocument") != null)
		{
			return OleFileType.Doc;
		}
		if (class1317_0.method_9().GetStream("Equation Native") != null)
		{
			return OleFileType.MSEquation;
		}
		if (class1317_0.method_9().method_0("MAPIMessage") != null)
		{
			return OleFileType.MapiMessage;
		}
		if (class1317_0.method_9().method_1().CompareTo(new Guid("00020D09-0000-0000-C000-000000000046")) == 0)
		{
			return OleFileType.MapiMessage;
		}
		foreach (string key in class1317_0.method_9().Keys)
		{
			if (key.StartsWith("__substg1.0"))
			{
				return OleFileType.MapiMessage;
			}
		}
		return OleFileType.Unknown;
	}

	internal static bool smethod_12(byte[] byte_0)
	{
		if (byte_0 != null && byte_0.Length >= 8)
		{
			long num = BitConverter.ToInt64(byte_0, 0);
			return num == -2226271756974174256L;
		}
		return false;
	}

	internal static bool smethod_13(Class1319 class1319_0)
	{
		return class1319_0.GetStream("CONTENTS") == null;
	}

	internal static bool smethod_14(Class1319 class1319_0)
	{
		return class1319_0.GetStream("\u0001Ole10Native") != null;
	}

	internal static byte[] smethod_15(string string_0)
	{
		if (string_0 != null && string_0 != "")
		{
			bool flag = true;
			byte[] bytes = Encoding.Unicode.GetBytes(string_0);
			for (int i = 0; i < bytes.Length / 2; i++)
			{
				if (bytes[2 * i + 1] != 0)
				{
					flag = false;
					break;
				}
			}
			byte[] array;
			if (flag)
			{
				array = new byte[bytes.Length / 2];
				for (int j = 0; j < bytes.Length / 2; j++)
				{
					array[j] = bytes[2 * j];
				}
			}
			else
			{
				array = bytes;
			}
			return array;
		}
		return null;
	}

	internal static bool smethod_16(string string_0)
	{
		string pattern = "(^\\d{0,4}[ -/.]\\d{1,2}[ -/.]\\d{0,4}$)|(^\\d{1,2}/\\d{1,2}$)|(^[a-z]{1,9}\\s\\d{1,2},\\s*\\d{2,4}$)|(^(\\d{1,2}[ -/.]\\s)?[a-z]{1,9}[ -/.]\\d{2,4}$)|(^\\d{0,4}[ -/]\\d{1,2}[ -/]\\d{0,4},?\\s*\\d{1,2}:\\d{2}(AM|PM)?)|(^\\d{0,4}\\s*[a-z]{1,9}\\s*\\d{0,4},?\\s*\\d{1,2}:\\d{2}(AM|PM)?)";
		return Regex.IsMatch(string_0, pattern, RegexOptions.IgnoreCase);
	}

	internal static bool smethod_17(string string_0)
	{
		Match match = Regex.Match(string_0, "^\\d*[ -/](\\d*[ -/])?\\d*$");
		if (match.Success)
		{
			return true;
		}
		return false;
	}

	internal static bool smethod_18(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < string_0.Length; i++)
			{
				switch (string_0[i])
				{
				case '+':
				case '-':
					if (i != 0 || string_0.Length == 1)
					{
						return false;
					}
					break;
				case '.':
					num++;
					if (num <= 1)
					{
						if (string_0.Length == 1)
						{
							return false;
						}
						break;
					}
					return false;
				case 'E':
				case 'e':
					if (num2 <= 0)
					{
						num2++;
						if (i != 0)
						{
							if (i + 1 != string_0.Length)
							{
								if (i + 1 < string_0.Length)
								{
									char c = string_0[i + 1];
									if (c == '+' || c == '-')
									{
										i++;
									}
								}
								break;
							}
							return false;
						}
						return false;
					}
					return false;
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
					break;
				default:
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public static bool smethod_19(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			string_0 = string_0.Trim();
			if (string_0.Length == 0)
			{
				return false;
			}
			int num = 0;
			int num2 = 0;
			bool result = false;
			char c = Class1187.smethod_0().NumberFormat.NumberDecimalSeparator[0];
			int num3 = 0;
			while (true)
			{
				if (num3 < string_0.Length)
				{
					if (string_0[num3] >= '0' && string_0[num3] <= '9')
					{
						result = true;
					}
					else if (string_0[num3] != c && string_0[num3] != '.')
					{
						switch (string_0[num3])
						{
						case 'E':
						case 'e':
							if (string_0.Length != 1 && num3 != 0 && num3 + 1 < string_0.Length)
							{
								switch (string_0[num3 + 1])
								{
								case '+':
								case '-':
									if (num3 + 2 < string_0.Length)
									{
										if (!char.IsDigit(string_0[num3 + 2]))
										{
											return false;
										}
										goto case '0';
									}
									return false;
								case '0':
								case '1':
								case '2':
								case '3':
								case '4':
								case '5':
								case '6':
								case '7':
								case '8':
								case '9':
									num2++;
									if (num2 <= 1)
									{
										num3++;
										break;
									}
									return false;
								default:
									return false;
								}
								break;
							}
							return false;
						default:
							if (num == 0)
							{
								if (string_0[num3] == CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0])
								{
									if (num3 + 3 < string_0.Length)
									{
										for (int i = 0; i < 3; i++)
										{
											if (!char.IsDigit(string_0[num3 + 1 + i]))
											{
												return false;
											}
										}
										num3 += 3;
										break;
									}
									return false;
								}
								return false;
							}
							return false;
						case '+':
						case '-':
							if (num3 != 0 || string_0.Length == 1)
							{
								return false;
							}
							break;
						}
					}
					else
					{
						num++;
						if (num > 1 || string_0.Length == 1)
						{
							break;
						}
					}
					num3++;
					continue;
				}
				return result;
			}
			return false;
		}
		return false;
	}

	internal static bool smethod_20(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			string_0 = string_0.Trim();
			if (string_0.Length == 0)
			{
				return false;
			}
			int num = 0;
			int num2 = 0;
			bool result = false;
			char c = Class1187.smethod_0().NumberFormat.NumberDecimalSeparator[0];
			_ = Class1187.smethod_0().NumberFormat.NumberGroupSeparator[0];
			int num3 = 0;
			while (true)
			{
				if (num3 < string_0.Length)
				{
					if (string_0[num3] >= '0' && string_0[num3] <= '9')
					{
						result = true;
					}
					else if (string_0[num3] == c)
					{
						num++;
						if (num > 1 || string_0.Length == 1)
						{
							break;
						}
					}
					else
					{
						switch (string_0[num3])
						{
						case 'E':
							if (string_0.Length != 1 && num3 != 0 && num3 <= string_0.Length - 3)
							{
								if (string_0[num3 + 1] == '+' || string_0[num3 + 1] == '-')
								{
									num2++;
									if (num2 <= 1)
									{
										num3++;
										break;
									}
									return false;
								}
								return false;
							}
							return false;
						default:
							if (string_0[num3] != CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0])
							{
								return false;
							}
							break;
						case '+':
						case '-':
							if (num3 != 0 || string_0.Length == 1)
							{
								return false;
							}
							break;
						}
					}
					num3++;
					continue;
				}
				return result;
			}
			return false;
		}
		return false;
	}

	public static bool smethod_21(string string_0)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			switch (string_0[i])
			{
			case ' ':
			case '!':
			case '#':
			case '$':
			case '%':
			case '&':
			case '\'':
			case '(':
			case ')':
			case '+':
			case ',':
			case '-':
			case '.':
			case '<':
			case '=':
			case '>':
			case '@':
			case '\\':
			case '{':
			case '|':
			case '}':
			case '~':
				return true;
			}
		}
		return smethod_23(string_0);
	}

	public static bool smethod_22(string string_0)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			switch (string_0[i])
			{
			case '!':
			case '+':
			case '-':
			case '[':
			case ']':
				return true;
			}
		}
		return smethod_23(string_0);
	}

	public static bool smethod_23(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			string_0 = string_0.Replace("$", "");
			string_0 = string_0.ToUpper();
			if (string_0.Length == 1)
			{
				if ((string_0[0] >= 'A' && string_0[0] <= 'Z') || (string_0[0] >= '0' && string_0[0] <= '9'))
				{
					return true;
				}
				return false;
			}
			if (char.IsLetter(string_0, 1))
			{
				uint num = (uint)((string_0[0] - 64) * 26 + string_0[1] - 65);
				if (num > 255)
				{
					return false;
				}
				if (string_0.Length != 2 && !char.IsDigit(string_0, 2))
				{
					return false;
				}
				return true;
			}
			if (char.IsDigit(string_0, 1))
			{
				return true;
			}
			if (string_0[1] != '=')
			{
				return false;
			}
			return true;
		}
		return false;
	}

	internal static void ApplyStyle(Style style_0, Style style_1, StyleFlag styleFlag_0)
	{
		if (styleFlag_0.All)
		{
			styleFlag_0 = new StyleFlag();
			styleFlag_0.Borders = true;
			styleFlag_0.Font = true;
			styleFlag_0.CellShading = true;
			styleFlag_0.HideFormula = true;
			styleFlag_0.HorizontalAlignment = true;
			styleFlag_0.Indent = true;
			styleFlag_0.Locked = true;
			styleFlag_0.NumberFormat = true;
			styleFlag_0.Rotation = true;
			styleFlag_0.ShrinkToFit = true;
			styleFlag_0.TextDirection = true;
			styleFlag_0.VerticalAlignment = true;
			styleFlag_0.WrapText = true;
		}
		if (styleFlag_0.Borders)
		{
			style_1.Borders.Copy(style_0.Borders);
		}
		else
		{
			if (styleFlag_0.LeftBorder)
			{
				style_1.Borders[BorderType.LeftBorder].Color = style_0.Borders[BorderType.LeftBorder].Color;
				style_1.Borders[BorderType.LeftBorder].LineStyle = style_0.Borders[BorderType.LeftBorder].LineStyle;
			}
			if (styleFlag_0.RightBorder)
			{
				style_1.Borders[BorderType.RightBorder].Color = style_0.Borders[BorderType.RightBorder].Color;
				style_1.Borders[BorderType.RightBorder].LineStyle = style_0.Borders[BorderType.RightBorder].LineStyle;
			}
			if (styleFlag_0.TopBorder)
			{
				style_1.Borders[BorderType.TopBorder].Color = style_0.Borders[BorderType.TopBorder].Color;
				style_1.Borders[BorderType.TopBorder].LineStyle = style_0.Borders[BorderType.TopBorder].LineStyle;
			}
			if (styleFlag_0.BottomBorder)
			{
				style_1.Borders[BorderType.BottomBorder].Color = style_0.Borders[BorderType.BottomBorder].Color;
				style_1.Borders[BorderType.BottomBorder].LineStyle = style_0.Borders[BorderType.BottomBorder].LineStyle;
			}
			if (styleFlag_0.DiagonalDownBorder)
			{
				style_1.Borders[BorderType.DiagonalDown].Color = style_0.Borders[BorderType.DiagonalDown].Color;
				style_1.Borders[BorderType.DiagonalDown].LineStyle = style_0.Borders[BorderType.DiagonalDown].LineStyle;
			}
			if (styleFlag_0.DiagonalUpBorder)
			{
				style_1.Borders[BorderType.DiagonalUp].Color = style_0.Borders[BorderType.DiagonalUp].Color;
				style_1.Borders[BorderType.DiagonalUp].LineStyle = style_0.Borders[BorderType.DiagonalUp].LineStyle;
			}
		}
		if (styleFlag_0.Font)
		{
			style_1.Font.Copy(style_0.Font);
		}
		else
		{
			if (styleFlag_0.FontBold)
			{
				style_1.Font.IsBold = style_0.Font.IsBold;
			}
			if (styleFlag_0.FontColor)
			{
				style_1.Font.Color = style_0.Font.Color;
			}
			if (styleFlag_0.FontItalic)
			{
				style_1.Font.IsItalic = style_0.Font.IsItalic;
			}
			if (styleFlag_0.FontName)
			{
				style_1.Font.method_14(style_0.Font.Name, style_0.Font.method_23());
			}
			if (styleFlag_0.FontScript)
			{
				style_1.Font.method_10(style_0.Font.method_9());
			}
			if (styleFlag_0.FontSize)
			{
				style_1.Font.Size = style_0.Font.Size;
			}
			if (styleFlag_0.FontStrike)
			{
				style_1.Font.IsStrikeout = style_0.Font.IsStrikeout;
			}
			if (styleFlag_0.FontUnderline)
			{
				style_1.Font.Underline = style_0.Font.Underline;
			}
		}
		if (styleFlag_0.NumberFormat)
		{
			if (style_0.Custom != null && !(style_0.Custom == ""))
			{
				style_1.Custom = style_0.Custom;
			}
			else
			{
				style_1.Number = style_0.Number;
			}
		}
		if (styleFlag_0.HorizontalAlignment)
		{
			style_1.HorizontalAlignment = style_0.HorizontalAlignment;
		}
		if (styleFlag_0.VerticalAlignment)
		{
			style_1.VerticalAlignment = style_0.VerticalAlignment;
		}
		if (styleFlag_0.Indent)
		{
			style_1.method_39(style_0.IndentLevel);
		}
		if (styleFlag_0.Rotation)
		{
			style_1.RotationAngle = style_0.RotationAngle;
		}
		if (styleFlag_0.WrapText)
		{
			style_1.IsTextWrapped = style_0.IsTextWrapped;
		}
		if (styleFlag_0.ShrinkToFit)
		{
			style_1.ShrinkToFit = style_0.ShrinkToFit;
		}
		if (styleFlag_0.TextDirection)
		{
			style_1.TextDirection = style_0.TextDirection;
		}
		if (styleFlag_0.CellShading)
		{
			style_1.ForegroundColor = style_0.ForegroundColor;
			style_1.BackgroundColor = style_0.BackgroundColor;
			style_1.Pattern = style_0.Pattern;
		}
		if (styleFlag_0.Locked)
		{
			style_1.IsLocked = style_0.IsLocked;
		}
		if (styleFlag_0.HideFormula)
		{
			style_1.IsFormulaHidden = style_0.IsFormulaHidden;
		}
	}

	internal static void ApplyStyle(Style style_0, Aspose.Cells.Font font_0, StyleFlag styleFlag_0)
	{
		if (!styleFlag_0.Font && !styleFlag_0.All)
		{
			if (styleFlag_0.FontBold)
			{
				font_0.IsBold = style_0.Font.IsBold;
			}
			if (styleFlag_0.FontColor)
			{
				font_0.Color = style_0.Font.Color;
			}
			if (styleFlag_0.FontItalic)
			{
				font_0.IsItalic = style_0.Font.IsItalic;
			}
			if (styleFlag_0.FontName)
			{
				font_0.method_13(style_0.Font.Name);
			}
			if (styleFlag_0.FontScript)
			{
				font_0.method_10(style_0.Font.method_9());
			}
			if (styleFlag_0.FontSize)
			{
				font_0.Size = style_0.Font.Size;
			}
			if (styleFlag_0.FontStrike)
			{
				font_0.IsStrikeout = style_0.Font.IsStrikeout;
			}
			if (styleFlag_0.FontUnderline)
			{
				font_0.Underline = style_0.Font.Underline;
			}
		}
		else
		{
			font_0.Copy(style_0.Font);
		}
	}

	internal static void smethod_24(int int_0)
	{
		if (int_0 < 0 || int_0 > 1048575)
		{
			throw new ArgumentException("Invalid row index.");
		}
	}

	internal static void smethod_25(int int_0)
	{
		if (int_0 < 0 || int_0 > 16383)
		{
			throw new ArgumentException("Invalid column index.");
		}
	}

	internal static void CheckCell(int int_0, int int_1)
	{
		if (int_0 >= 0 && int_0 <= 1048575)
		{
			if (int_1 < 0 || int_1 > 16383)
			{
				throw new ArgumentException("Invalid column index.");
			}
			return;
		}
		throw new ArgumentException("Invalid row index.");
	}

	internal static void smethod_26(int int_0, int int_1, int int_2, int int_3)
	{
		if (int_0 >= 0 && int_0 <= 1048575)
		{
			if (int_1 >= 0 && int_1 <= 16383)
			{
				if (int_2 >= 0 && int_2 <= 1048575 && int_2 >= int_0)
				{
					if (int_3 < 0 || int_3 > 16383 || int_3 < int_1)
					{
						throw new ArgumentException("Invalid end column index.");
					}
					return;
				}
				throw new ArgumentException("Invalid end row index.");
			}
			throw new ArgumentException("Invalid start column index.");
		}
		throw new ArgumentException("Invalid start row index.");
	}

	internal static void smethod_27(int int_0, int int_1)
	{
		if (int_0 >= 0 && int_0 <= 1048575)
		{
			if (int_1 < 0 || int_1 > 1048575 || int_1 < int_0)
			{
				throw new ArgumentException("Invalid end row index.");
			}
			return;
		}
		throw new ArgumentException("Invalid start row index.");
	}

	internal static void smethod_28(int int_0, int int_1)
	{
		if (int_0 >= 0 && int_0 <= 16383)
		{
			if (int_1 < 0 || int_1 > 16383 || int_1 < int_0)
			{
				throw new ArgumentException("Invalid end column index.");
			}
			return;
		}
		throw new ArgumentException("Invalid start column index.");
	}

	internal static int smethod_29(string string_0)
	{
		if (string_0 != null)
		{
			if (!smethod_30(string_0))
			{
				return string_0.Length * 2 + 1;
			}
			return string_0.Length + 1;
		}
		return 0;
	}

	internal static bool smethod_30(string string_0)
	{
		bool result = true;
		if (string_0 != null && string_0 != "")
		{
			result = true;
			byte[] bytes = Encoding.Unicode.GetBytes(string_0);
			for (int i = 0; i < bytes.Length / 2; i++)
			{
				if (bytes[2 * i + 1] != 0)
				{
					result = false;
					break;
				}
			}
		}
		return result;
	}

	internal static string[] smethod_31(string string_0)
	{
		string[] array = new string[2];
		if (string_0[0] == '=')
		{
			string_0 = string_0.Substring(1);
		}
		array[1] = string_0;
		Regex regex = new Regex("!");
		Match match = regex.Match(string_0);
		if (match.Success)
		{
			string text = string_0.Substring(0, match.Index).Trim();
			if (text[0] == '\'' && text[text.Length - 1] == '\'')
			{
				text = text.Substring(1, text.Length - 2);
				if (text == null || text == "")
				{
					throw new CellsException(ExceptionType.SheetName, "Invalid worksheet name.");
				}
			}
			array[0] = text;
			array[1] = string_0.Substring(match.Index + 1).Trim();
		}
		return array;
	}

	internal static object smethod_32(WorksheetCollection worksheetCollection_0, int int_0, char[] char_0)
	{
		object obj = smethod_33(char_0);
		if (obj == null)
		{
			obj = worksheetCollection_0.Names[new string(char_0), int_0];
		}
		if (obj == null)
		{
			string string_ = new string(char_0);
			for (int i = 0; i < worksheetCollection_0.Count; i++)
			{
				ListObject listObject = worksheetCollection_0[i].ListObjects.method_1(string_);
				if (listObject != null)
				{
					CellArea cellArea = default(CellArea);
					cellArea.StartRow = listObject.StartRow;
					cellArea.EndRow = listObject.EndRow;
					cellArea.StartColumn = listObject.StartColumn;
					cellArea.EndColumn = listObject.EndColumn;
					return cellArea;
				}
			}
		}
		return obj;
	}

	internal static object smethod_33(char[] char_0)
	{
		int num = char_0.Length - 1;
		int int_ = 0;
		int num2 = -1;
		int num3 = 0;
		while (true)
		{
			if (num3 <= num)
			{
				char c = char_0[num3];
				if (c == ':')
				{
					if (num2 != -1)
					{
						break;
					}
					num2 = num3;
				}
				num3++;
				continue;
			}
			if (num2 != 0 && num2 != num)
			{
				if (num2 != -1)
				{
					int[] array = smethod_34(char_0, int_, num2 - 1, 'S');
					if (array == null)
					{
						return null;
					}
					int[] array2 = smethod_34(char_0, num2 + 1, num, 'E');
					if (array2 == null)
					{
						return null;
					}
					CellArea cellArea = default(CellArea);
					cellArea.StartRow = array[0];
					cellArea.StartColumn = (byte)array[1];
					cellArea.EndRow = array2[0];
					cellArea.EndColumn = (byte)array2[1];
					return cellArea;
				}
				int[] array3 = smethod_34(char_0, int_, num, 'N');
				if (array3 == null)
				{
					return null;
				}
				CellArea cellArea2 = default(CellArea);
				cellArea2.StartRow = array3[0];
				cellArea2.StartColumn = array3[1];
				cellArea2.EndRow = array3[0];
				cellArea2.EndColumn = array3[1];
				return cellArea2;
			}
			return null;
		}
		return null;
	}

	private static int[] smethod_34(char[] char_0, int int_0, int int_1, char char_1)
	{
		int[] array = new int[2];
		array[1] = -1;
		array[0] = -1;
		bool flag = false;
		bool flag2 = false;
		int i = int_0;
		while (true)
		{
			if (i <= int_1)
			{
				char c = char.ToUpper(char_0[i]);
				if (c == '$' || char.IsLetterOrDigit(c))
				{
					if (c == '$')
					{
						if ((i == int_1 || !char.IsLetter(char_0[i + 1])) && (i == int_1 || !char.IsDigit(char_0[i + 1])))
						{
							return null;
						}
					}
					else if (char.IsLetter(c))
					{
						if (flag)
						{
							return null;
						}
						flag = true;
						array[1] = c - 65;
						if (i != int_1 && char.IsLetter(char_0[i + 1]))
						{
							c = char.ToUpper(char_0[++i]);
							array[1] = (array[1] + 1) * 26 + c - 65;
							if (array[1] > 16383)
							{
								return null;
							}
						}
					}
					else if (char.IsDigit(c))
					{
						if (flag2)
						{
							break;
						}
						array[0] = c - 48;
						flag2 = true;
						for (i++; i <= int_1; i++)
						{
							c = char_0[i];
							if (char.IsDigit(c))
							{
								array[0] = array[0] * 10 + c - 48;
								if (array[0] - 1 > 1048575)
								{
									return null;
								}
								continue;
							}
							return null;
						}
					}
					i++;
					continue;
				}
				return null;
			}
			array[0]--;
			if (!flag2 && !flag)
			{
				return null;
			}
			if ((!flag2 || !flag) && char_1 == 'N')
			{
				return null;
			}
			switch (char_1)
			{
			case 'S':
				if (!flag2)
				{
					array[0] = 0;
				}
				if (!flag)
				{
					array[1] = 0;
				}
				break;
			case 'E':
				if (!flag2)
				{
					array[0] = 65535;
				}
				if (!flag)
				{
					array[1] = 255;
				}
				break;
			}
			return array;
		}
		return null;
	}

	internal static string smethod_35()
	{
		return "Aspose.Cells for .NET";
	}

	internal static void smethod_36(Worksheet worksheet_0)
	{
		string text = "Aspose.Cells for .NET.";
		string stringValue = "EVALUATION COPYRIGHT WARNING";
		string stringValue2 = "This file is created using EVALUATION VERSION of " + text;
		string stringValue3 = "Evaluation Limitations:";
		string stringValue4 = "This EVALUATION LICENSE WARNING worksheet will be added to all worksheets created with " + text;
		string stringValue5 = "The usage of this Evaluation Version in any Commercial Application is strongly PROHIBITED.";
		string stringValue6 = "Any Violation to the Usage Policies of this Product shall require a mandatory purchase of pay license ";
		string stringValue7 = "as well as expose the user to other legal recourse for collection and punitive damages.";
		string stringValue8 = "Copyright 2003 - " + DateTime.Now.Year + " Aspose Pty Ltd.";
		int int_ = -1;
		worksheet_0.method_8(ref int_);
		Style style = new Style(worksheet_0.method_2());
		style.Font.method_13("Arial");
		style.Font.Size = 18;
		style.Font.Color = Color.Blue;
		style.Font.IsBold = true;
		Cell cell = null;
		cell = worksheet_0.Cells.method_7("C4");
		cell.PutValue(stringValue);
		cell.method_30(style);
		worksheet_0.AutoFitRow(3);
		Range range = worksheet_0.Cells.CreateRange("C4", "I4");
		range.SetOutlineBorder(BorderType.TopBorder, CellBorderType.Medium, Color.Blue);
		range.SetOutlineBorder(BorderType.BottomBorder, CellBorderType.Medium, Color.Blue);
		range.SetOutlineBorder(BorderType.LeftBorder, CellBorderType.Medium, Color.Blue);
		range.SetOutlineBorder(BorderType.RightBorder, CellBorderType.Medium, Color.Blue);
		style = new Style(worksheet_0.method_2());
		style.Font.method_13("Arial");
		style.Font.Size = 10;
		style.Font.Color = Color.Blue;
		style.Font.IsBold = true;
		cell = worksheet_0.Cells.method_7("B7");
		cell.PutValue(stringValue2);
		cell.method_30(style);
		cell = worksheet_0.Cells.method_7("B9");
		cell.PutValue(stringValue3);
		cell.method_30(style);
		Style style2 = new Style(worksheet_0.method_2());
		style2.Font.method_13("Arial");
		style2.Font.Size = 10;
		style2.Font.Color = Color.White;
		style2.ForegroundColor = Color.Blue;
		style2.Pattern = BackgroundType.Solid;
		worksheet_0.Cells.method_7("A11").PutValue(1);
		worksheet_0.Cells.method_7("A13").PutValue(2);
		worksheet_0.Cells.method_7("A15").PutValue(3);
		worksheet_0.Cells.method_7("A11").method_30(style2);
		worksheet_0.Cells.method_7("A13").method_30(style2);
		worksheet_0.Cells.method_7("A15").method_30(style2);
		style2 = new Style(worksheet_0.method_2());
		style2.Font.method_13("Arial");
		style2.Font.Size = 10;
		worksheet_0.Cells.method_7("B11").method_30(style2);
		worksheet_0.Cells.method_7("B13").method_30(style2);
		worksheet_0.Cells.method_7("B15").method_30(style2);
		worksheet_0.Cells.method_7("B16").method_30(style2);
		style2.Font.IsBold = true;
		style2.Font.Color = Color.Blue;
		worksheet_0.Cells.method_7("B18").method_30(style2);
		worksheet_0.Cells.method_7("B11").PutValue(stringValue4);
		worksheet_0.Cells.method_7("B13").PutValue(stringValue5);
		worksheet_0.Cells.method_7("B15").PutValue(stringValue6);
		worksheet_0.Cells.method_7("B16").PutValue(stringValue7);
		worksheet_0.Cells.method_7("B18").PutValue(stringValue8);
		for (int i = 0; i < worksheet_0.method_2().Count - 1; i++)
		{
			worksheet_0.method_2()[i].IsSelected = false;
		}
		worksheet_0.method_2().ActiveSheetIndex = worksheet_0.SheetIndex;
	}

	internal static object smethod_37(string string_0)
	{
		if (smethod_19(string_0))
		{
			return double.Parse(string_0);
		}
		string text = null;
		switch (string_0[0])
		{
		default:
			if (string_0[string_0.Length - 1] == '€')
			{
				text = string_0.Substring(0, string_0.Length - 1);
			}
			break;
		case '$':
		case '€':
		case '￡':
		case '￥':
			text = string_0.Substring(1);
			break;
		}
		if (text != null)
		{
			if (smethod_19(text))
			{
				return double.Parse(text);
			}
			string pattern = "^\\d{0,4}[ -/]\\d{1,2}[ -/]\\d{0,4}$|^[a-z]{1,9}\\s\\d{1,2},\\s*\\d{2,4}$";
			if (Regex.IsMatch(string_0, pattern, RegexOptions.IgnoreCase))
			{
				try
				{
					return DateTime.Parse(string_0).ToOADate();
				}
				catch
				{
				}
			}
		}
		else
		{
			string pattern2 = "^\\d{0,4}[ -/]\\d{1,2}[ -/]\\d{0,4}$|^[a-z]{1,9}\\s\\d{1,2},\\s*\\d{2,4}$";
			if (Regex.IsMatch(string_0, pattern2, RegexOptions.IgnoreCase))
			{
				try
				{
					return DateTime.Parse(string_0).ToOADate();
				}
				catch
				{
				}
			}
		}
		return null;
	}

	internal static object smethod_38(string string_0, bool bool_0)
	{
		if (smethod_19(string_0))
		{
			try
			{
				return double.Parse(string_0);
			}
			catch
			{
			}
		}
		if (!bool_0)
		{
			string pattern = "^\\d{0,4}[ -/]\\d{1,2}[ -/]\\d{0,4}$|^[a-z]{1,9}\\s\\d{1,2},\\s*\\d{2,4}$";
			if (Regex.IsMatch(string_0, pattern, RegexOptions.IgnoreCase))
			{
				try
				{
					return DateTime.Parse(string_0);
				}
				catch
				{
				}
			}
		}
		else
		{
			string text = null;
			switch (string_0[0])
			{
			default:
				if (string_0[string_0.Length - 1] == '€')
				{
					text = string_0.Substring(0, string_0.Length - 1);
				}
				break;
			case '$':
			case '€':
			case '￡':
			case '￥':
				text = string_0.Substring(1);
				break;
			}
			if (text != null)
			{
				if (smethod_19(text))
				{
					return double.Parse(text);
				}
				string pattern2 = "^\\d{0,4}[ -/]\\d{1,2}[ -/]\\d{0,4}$|^[a-z]{1,9}\\s\\d{1,2},\\s*\\d{2,4}$";
				if (Regex.IsMatch(string_0, pattern2, RegexOptions.IgnoreCase))
				{
					try
					{
						return DateTime.Parse(string_0);
					}
					catch
					{
					}
				}
			}
			else
			{
				string pattern3 = "(^\\d{0,4}[ -/]\\d{1,2}[ -/]\\d{0,4}$)|(^[a-z]{1,9}\\s\\d{1,2}(,\\s*\\d{2,4})?$)|(^\\d{0,4}[ -/]\\d{1,2}[ -/]\\d{0,4},?\\s*\\d{1,2}:\\d{1,2}(AM|PM)?)";
				if (Regex.IsMatch(string_0, pattern3, RegexOptions.IgnoreCase))
				{
					try
					{
						return DateTime.Parse(string_0);
					}
					catch
					{
					}
				}
			}
		}
		return string_0;
	}

	internal static Class1647 smethod_39()
	{
		byte[] byte_ = new byte[16]
		{
			21, 122, 103, 84, 81, 87, 50, 85, 62, 80,
			120, 119, 24, 18, 180, 131
		};
		byte[] byte_2 = new byte[16]
		{
			124, 52, 204, 7, 161, 117, 147, 128, 180, 188,
			255, 58, 124, 215, 52, 186
		};
		byte[] byte_3 = new byte[16]
		{
			234, 87, 79, 169, 179, 114, 80, 50, 185, 103,
			111, 80, 29, 110, 25, 46
		};
		return new Class1647("VelvetSweatshop", byte_, byte_2, byte_3);
	}

	internal static bool smethod_40(WorksheetCollection worksheetCollection_0, string string_0)
	{
		string_0 = string_0.ToUpper();
		int num = 0;
		while (true)
		{
			if (num < worksheetCollection_0.Count)
			{
				if (worksheetCollection_0[num].Name.ToUpper() == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal static int smethod_41(ErrorType errorType_0)
	{
		return errorType_0 switch
		{
			ErrorType.Div => 6, 
			ErrorType.NA => 1, 
			ErrorType.Name => 3, 
			ErrorType.Null => 7, 
			ErrorType.Number => 2, 
			ErrorType.Ref => 4, 
			ErrorType.Value => 5, 
			_ => 0, 
		};
	}
}
