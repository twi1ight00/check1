using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using ns17;
using ns18;
using ns19;

namespace Aspose.Cells.Rendering;

/// <summary>
///       Represents a worksheet render which can render worksheet to various images such as (BMP, PNG, JPEG, TIFF..)
///       The constructor of this class , must be used after modification of pagesetup, cell style.    
///       </summary>
public class SheetRender
{
	private Workbook workbook_0;

	private Worksheet worksheet_0;

	private ImageOrPrintOptions imageOrPrintOptions_0;

	private Class1243 class1243_0;

	private int int_0;

	private int int_1;

	/// <summary>
	///       Indicate the total page count of current worksheet
	///       </summary>
	public int PageCount
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	/// <summary>
	///       the construct of SheetRender, need worksheet and ImageOrPrintOptions as params
	///       </summary>
	/// <param name="worksheet">Indicate which spreadsheet to be rendered.</param>
	/// <param name="options">ImageOrPrintOptions contains some property of output image</param>
	public SheetRender(Worksheet worksheet, ImageOrPrintOptions options)
	{
		workbook_0 = worksheet.Workbook;
		worksheet_0 = worksheet;
		imageOrPrintOptions_0 = options;
		class1243_0 = new Class1243(workbook_0);
		class1243_0.class468_0 = new Class472();
		if (worksheet.PageSetup.BlackAndWhite)
		{
			imageOrPrintOptions_0.bool_6 = true;
		}
		class1243_0.method_8(worksheet, imageOrPrintOptions_0);
		if (class1243_0.arrayList_1 != null)
		{
			int_1 = class1243_0.arrayList_1.Count;
		}
	}

	/// <summary>
	///       Get page size of output image. The size unit is in pixel.
	///       </summary>
	/// <param name="pageIndex">The page index is based on zero.</param>
	/// <returns>
	/// </returns>
	public Size GetPageSize(int pageIndex)
	{
		Class456 @class = (Class456)class1243_0.arrayList_1[pageIndex];
		if (imageOrPrintOptions_0.ImageFormat == ImageFormat.Tiff)
		{
			return new Size((int)Math.Ceiling(@class.double_1 * (double)imageOrPrintOptions_0.HorizontalResolution) + 2, (int)Math.Ceiling(@class.double_2 * (double)imageOrPrintOptions_0.VerticalResolution) + 2);
		}
		if (imageOrPrintOptions_0.ImageFormat == ImageFormat.Emf)
		{
			return new Size((int)Math.Ceiling(@class.double_1 * 96.0) + 1, (int)Math.Ceiling(@class.double_2 * 96.0) + 1);
		}
		return new Size((int)Math.Ceiling(@class.double_1 * (double)imageOrPrintOptions_0.HorizontalResolution) + 1, (int)Math.Ceiling(@class.double_2 * (double)imageOrPrintOptions_0.VerticalResolution) + 1);
	}

	/// <summary>
	///       Render certain page to a file.
	///       </summary>
	/// <param name="pageIndex">indicate which page is to be converted</param>
	/// <param name="fileName">filename of the output image</param>
	public void ToImage(int pageIndex, string fileName)
	{
		class1243_0.method_3(pageIndex, fileName, imageOrPrintOptions_0);
	}

	/// <summary>
	///       Render certain page to a stream.
	///       </summary>
	/// <param name="pageIndex">indicate which page is to be converted</param>
	/// <param name="stream">the stream of the output image</param>
	public void ToImage(int pageIndex, Stream stream)
	{
		class1243_0.method_2(pageIndex, imageOrPrintOptions_0, stream);
	}

	/// <summary>
	///       Render certain page to a Bitmap object.
	///       </summary>
	/// <param name="pageIndex">indicate which page is to be converted</param>
	/// <returns>the bitmap object of the page</returns>
	public Bitmap ToImage(int pageIndex)
	{
		return class1243_0.method_5(pageIndex, imageOrPrintOptions_0);
	}

	/// <summary>
	///       Render whole worksheet as Tiff Image to stream.
	///       </summary>
	/// <param name="stream">the stream of the output image</param>
	public void ToTiff(Stream stream)
	{
		if (stream != null)
		{
			class1243_0.method_6(stream, imageOrPrintOptions_0);
		}
	}

	/// <summary>
	///       Render whole worksheet as Tiff Image to a file.
	///       </summary>
	/// <param name="filename">the filename of the output image</param>
	public void ToTiff(string filename)
	{
		FileStream fileStream = new FileStream(filename, FileMode.Create);
		MemoryStream memoryStream = new MemoryStream();
		if (memoryStream != null)
		{
			class1243_0.method_6(memoryStream, imageOrPrintOptions_0);
			memoryStream.Position = 0L;
			memoryStream.WriteTo(fileStream);
			memoryStream.Close();
			fileStream.Close();
		}
	}

	internal void method_0(PrintDocument printDocument_0)
	{
		if (worksheet_0.PageSetup.Orientation == PageOrientationType.Landscape)
		{
			printDocument_0.DefaultPageSettings.Landscape = true;
		}
		else
		{
			printDocument_0.DefaultPageSettings.Landscape = false;
		}
		int paperSize = (int)worksheet_0.PageSetup.PaperSize;
		foreach (PaperSize paperSize2 in printDocument_0.DefaultPageSettings.PrinterSettings.PaperSizes)
		{
			if (paperSize2.Kind == (PaperKind)paperSize)
			{
				printDocument_0.DefaultPageSettings.PaperSize = paperSize2;
				break;
			}
		}
	}

	/// <summary>
	///       Render worksheet to Printer
	///       </summary>
	/// <param name="PrinterName">the name of the printer , for example: "Microsoft Office Document Image Writer"</param>
	public void ToPrinter(string PrinterName)
	{
		method_1(PrinterName, null);
	}

	public void ToPrinter(string PrinterName, string DocumentName)
	{
		method_1(PrinterName, DocumentName);
	}

	private void method_1(string string_0, string string_1)
	{
		using PrintDocument printDocument = new PrintDocument();
		method_0(printDocument);
		int_0 = 0;
		printDocument.PrinterSettings.PrinterName = string_0;
		if (!printDocument.PrinterSettings.IsValid)
		{
			throw new CellsException(ExceptionType.InvalidData, "\"" + string_0 + "\" Printer not found!");
		}
		if (imageOrPrintOptions_0.CustomPrintPageEventHandler != null)
		{
			printDocument.PrintPage += imageOrPrintOptions_0.CustomPrintPageEventHandler;
		}
		else
		{
			printDocument.PrintPage += method_2;
		}
		if (!imageOrPrintOptions_0.PrintWithStatusDialog)
		{
			printDocument.PrintController = new StandardPrintController();
		}
		if (string_1 != null)
		{
			printDocument.DocumentName = string_1;
		}
		printDocument.Print();
	}

	/// <summary>
	///       Client can control page setting of printer when print each page using this function.
	///       </summary>
	/// <param name="nextPageAfterPrint">If true , printer will go to next page after print current page</param>
	/// <param name="printPageEventArgs">System.Drawing.Printing.PrintPageEventArgs</param>
	/// <returns>Indirect next page index,  based on zero</returns>
	public int CustomPrint(bool nextPageAfterPrint, PrintPageEventArgs printPageEventArgs)
	{
		if (class1243_0 != null)
		{
			class1243_0.method_4(int_0, imageOrPrintOptions_0, printPageEventArgs);
		}
		if (nextPageAfterPrint)
		{
			int_0++;
		}
		return int_0;
	}

	private void method_2(object sender, PrintPageEventArgs e)
	{
		if (class1243_0.method_4(int_0, imageOrPrintOptions_0, e))
		{
			e.HasMorePages = true;
			int_0++;
		}
		else
		{
			e.HasMorePages = false;
		}
	}
}
