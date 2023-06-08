using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using Aspose.Cells.Rendering;
using Aspose.Cells.Rendering.PdfSecurity;

namespace Aspose.Cells;

/// <summary>
///       Represents the options for saving pdf file.
///       </summary>
public class PdfSaveOptions : SaveOptions
{
	private PrintingPageType printingPageType_0;

	private bool bool_7;

	private ImageFormat imageFormat_0 = ImageFormat.Emf;

	private PdfSecurityOptions pdfSecurityOptions_0;

	private bool bool_8;

	private bool bool_9 = true;

	/// <summary>
	///       Indicates which pages will not be printed.
	///       </summary>
	public PrintingPageType PrintingPageType
	{
		get
		{
			return printingPageType_0;
		}
		set
		{
			printingPageType_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets the <see cref="T:Aspose.Cells.Rendering.PdfBookmarkEntry">PdfBookmarkEntry</see> object.
	///       </summary>
	public PdfBookmarkEntry Bookmark
	{
		get
		{
			return pdfBookmarkEntry_0;
		}
		set
		{
			pdfBookmarkEntry_0 = value;
		}
	}

	/// <summary>
	///       Workbook converts to pdf will according to PdfCompliance in this property.
	///       </summary>
	public new PdfCompliance Compliance
	{
		get
		{
			return pdfCompliance_0;
		}
		set
		{
			pdfCompliance_0 = value;
		}
	}

	/// <summary>
	///       When characters in the Excel are unicode and not be set with correct font in cell style,
	///       They may appear as block in pdf,image.
	///       Set the DefaultFont such as MingLiu or MS Gothic to show these characters.
	///       If this property is not set, Aspose.Cells will use system default font to show these unicode characters.
	///       </summary>
	public new string DefaultFont
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
	///       Set this options, when security is need in xls2pdf result.      
	///       </summary>
	public PdfSecurityOptions SecurityOptions
	{
		get
		{
			return pdfSecurityOptions_0;
		}
		set
		{
			pdfSecurityOptions_0 = value;
		}
	}

	/// <summary>
	///       If OnePagePerSheet is true , all content of one sheet will output to only one page in result. 
	///       The paper size of pagesetup will be invalid, and the other settings of pagesetup 
	///       will still take effect.
	///       </summary>
	public bool OnePagePerSheet
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public ImageFormat ImageType
	{
		get
		{
			return imageFormat_0;
		}
		set
		{
			imageFormat_0 = value;
		}
	}

	/// <summary>
	///       Indicate the chart imagetype when converting.
	///       </summary>
	[Obsolete("Use PdfSaveOptions.ImageType instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ImageFormat ChartImageType
	{
		get
		{
			return imageFormat_0;
		}
		set
		{
			imageFormat_0 = value;
		}
	}

	public bool CalculateFormula
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public bool CheckFontCompatibility
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	/// <summary>
	///       Creates the options for saving pdf file.
	///       </summary>
	public PdfSaveOptions()
	{
		m_SaveFormat = SaveFormat.Pdf;
	}

	/// <summary>
	///       Creates the options for saving pdf file.
	///       </summary>
	/// <param name="saveFormat">The save format.It must be pdf.</param>
	public PdfSaveOptions(SaveFormat saveFormat)
	{
		m_SaveFormat = saveFormat;
	}

	internal PdfSaveOptions(SaveOptions saveOptions_0)
	{
		m_SaveFormat = SaveFormat.Pdf;
		Copy(saveOptions_0);
	}
}
