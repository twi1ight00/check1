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
///       Represents a Workbook render. 
///       The constructor of this class , must be used after modification of pagesetup, cell style.    
///       </summary>
/// <remarks>
/// </remarks>
public class WorkbookRender
{
	private Workbook workbook_0;

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
	///       The construct of WorkbookRender
	///       </summary>
	/// <param name="workbook">Indicate which workbook to be rendered.</param>
	/// <param name="options">ImageOrPrintOptions contains some property of output kiimage</param>
	public WorkbookRender(Workbook workbook, ImageOrPrintOptions options)
	{
		workbook_0 = workbook;
		imageOrPrintOptions_0 = options;
		class1243_0 = new Class1243(workbook_0);
		class1243_0.class468_0 = new Class472();
		class1243_0.method_7(imageOrPrintOptions_0);
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
	///       Render whole workbook as Tiff Image to stream.
	///       </summary>
	/// <param name="stream">the stream of the output image</param>
	public void ToImage(Stream stream)
	{
		if (imageOrPrintOptions_0.ImageFormat != ImageFormat.Tiff && imageOrPrintOptions_0.SaveFormat != SaveFormat.TIFF && imageOrPrintOptions_0.SaveFormat != SaveFormat.XPS)
		{
			throw new CellsException(ExceptionType.UnsupportedFeature, "WorkbookRender only support Tiff/XPS");
		}
		if (stream != null)
		{
			class1243_0.method_6(stream, imageOrPrintOptions_0);
		}
	}

	/// <summary>
	///       Render whole workbook as Tiff Image to a file.
	///       </summary>
	/// <param name="filename">the filename of the output image</param>
	public void ToImage(string filename)
	{
		if (imageOrPrintOptions_0.ImageFormat != ImageFormat.Tiff && imageOrPrintOptions_0.SaveFormat != SaveFormat.TIFF && imageOrPrintOptions_0.SaveFormat != SaveFormat.XPS)
		{
			throw new CellsException(ExceptionType.UnsupportedFeature, "WorkbookRender only support Tiff/XPS");
		}
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

	/// <summary>
	///       Render workbook to Printer
	///       </summary>
	/// <param name="PrinterName">the name of the printer , for example: "Microsoft Office Document Image Writer"</param>
	public void ToPrinter(string PrinterName)
	{
		method_0(PrinterName, null);
	}

	public void ToPrinter(string PrinterName, string DocumentName)
	{
		method_0(PrinterName, DocumentName);
	}

	private void method_0(string string_0, string string_1)
	{
		PrintDocument printDocument = new PrintDocument();
		method_1(printDocument);
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
		if (string_1 != null)
		{
			printDocument.DocumentName = string_1;
		}
		if (!imageOrPrintOptions_0.PrintWithStatusDialog)
		{
			printDocument.PrintController = new StandardPrintController();
		}
		printDocument.Print();
	}

	internal void method_1(PrintDocument printDocument_0)
	{
		Worksheet worksheet_ = ((Class456)class1243_0.arrayList_1[int_0]).worksheet_0;
		if (worksheet_.PageSetup.Orientation == PageOrientationType.Landscape)
		{
			printDocument_0.DefaultPageSettings.Landscape = true;
		}
		else
		{
			printDocument_0.DefaultPageSettings.Landscape = false;
		}
		int paperSize = (int)worksheet_.PageSetup.PaperSize;
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
	///       Client can control page setting of printer when print each page using this function.
	///       </summary>
	/// <param name="nextPageAfterPrint">If true , printer will go to next page after print current page</param>
	/// <param name="printPageEventArgs">System.Drawing.Printing.PrintPageEventArgs</param>
	/// <returns>Indirects next page index,  based on zero</returns>
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
	}
}
