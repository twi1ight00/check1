using System;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;

namespace Aspose.Cells.Rendering;

/// <summary>
///       Allows to specify options when rendering worksheet to images, printing worksheet or rendering chart to image.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Set Image Or Print Options
///       ImageOrPrintOptions options = new ImageOrPrintOptions();
///
///       //set Horizontal resolution
///       options.HorizontalResolution = 200;
///
///       //set Vertica; Resolution
///       options.VerticalResolution = 300;
///
///       //Instantiate Workbook
///       Workbook book = new Workbook(@"c:\test.xls");
///
///       //Save chart as Image using ImageOrPrint Options
///       Bitmap chartObject = book.Worksheets[0].Charts[0].ToImage(options);
///
///       [VB.NET]
///
///       'Set Image Or Print Options
///       Dim options As New ImageOrPrintOptions()
///
///       'set Horizontal resolution
///       options.HorizontalResolution = 200
///
///       'set Vertica; Resolution
///       options.VerticalResolution = 300
///
///       'Instantiate Workbook
///       Dim book As New Workbook("c:\test.xls")
///
///       'Save chart as Image using ImageOrPrint Options
///       Dim chartObject As Bitmap = book.Worksheets(0).Charts(0).ToImage(options)
///       </code>
/// </example>
public class ImageOrPrintOptions
{
	private int int_0 = 96;

	private int int_1 = 96;

	private TiffCompression tiffCompression_0 = TiffCompression.CompressionLZW;

	private PrintingPageType printingPageType_0;

	private int int_2 = 100;

	private ImageFormat imageFormat_0 = ImageFormat.Bmp;

	private bool bool_0;

	private bool bool_1 = true;

	internal bool bool_2;

	internal bool bool_3;

	internal bool bool_4;

	internal bool bool_5;

	internal bool bool_6;

	private SaveFormat saveFormat_0 = SaveFormat.XPS;

	private PrintPageEventHandler printPageEventHandler_0;

	internal bool bool_7 = true;

	private bool bool_8;

	private bool bool_9;

	private DrawObjectEventHandler drawObjectEventHandler_0;

	private ImageFormat imageFormat_1 = ImageFormat.Emf;

	private string string_0 = "c:\\xpsEmbeded";

	private bool bool_10;

	/// <summary>
	///       Gets or sets the output file format type
	///       Support Tiff/XPS
	///       </summary>
	public SaveFormat SaveFormat
	{
		get
		{
			return saveFormat_0;
		}
		set
		{
			saveFormat_0 = value;
			ImageFormat = ImageFormat.Icon;
		}
	}

	/// <summary>
	///       Client can control page setting of printer when print each page using this EventHandler
	///       </summary>
	public PrintPageEventHandler CustomPrintPageEventHandler
	{
		get
		{
			return printPageEventHandler_0;
		}
		set
		{
			printPageEventHandler_0 = value;
		}
	}

	/// <summary>
	///       If PrintWithStatusDialog = true , there will be a dialog that shows current print status.
	///       else no such dialog will show.
	///       </summary>
	public bool PrintWithStatusDialog
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

	/// <summary>
	///       Gets or sets the horizontal resolution for generated images, in dots per inch.
	///       Applies generating image method except Emf format images.
	///       </summary>
	/// <remarks>
	///       The default value is 96.
	///       </remarks>
	public int HorizontalResolution
	{
		get
		{
			return int_0;
		}
		set
		{
			bool_2 = true;
			int_0 = value;
		}
	}

	/// <summary>
	///       Gets or sets the vertical  resolution for generated images, in dots per inch.
	///       Applies generating image method except Emf format image.
	///       </summary>
	/// <remarks>
	///       The default value is 96.
	///       </remarks>
	public int VerticalResolution
	{
		get
		{
			return int_1;
		}
		set
		{
			bool_2 = true;
			int_1 = value;
		}
	}

	/// <summary>
	///       Gets or sets the type of compression to apply only when saving pages to the <c>Tiff</c> format. 
	///       </summary>
	/// <remarks>
	///       Has effect only when saving to TIFF.
	///       The default value is Lzw.
	///       </remarks>
	public TiffCompression TiffCompression
	{
		get
		{
			return tiffCompression_0;
		}
		set
		{
			bool_4 = true;
			tiffCompression_0 = value;
		}
	}

	/// <summary>
	///       Indicates which pages will not be printed.
	///       </summary>
	public PrintingPageType PrintingPage
	{
		get
		{
			return printingPageType_0;
		}
		set
		{
			bool_3 = true;
			printingPageType_0 = value;
		}
	}

	/// <summary>
	///       Gets or sets a value determining the quality of the generated  images
	///       to apply only when saving pages to the <c>Jpeg</c> format. 
	///       </summary>
	/// <remarks>
	///       Has effect only when saving to JPEG.
	///       The value must be between 0 and 100.
	///       The default value is 100.
	///       </remarks>
	public int Quality
	{
		get
		{
			return int_2;
		}
		set
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentOutOfRangeException("Quality must be between 0 and 100");
			}
			int_2 = value;
		}
	}

	/// <summary>
	///       Gets or sets the format of the generated images.
	///       Don't apply the method that returns a <c>Bitmap</c> object.
	///       </summary>
	/// <remarks>
	///       The default value is ImageFormat.Bmp.
	///       Don't apply the method that returns a <c>Bitmap</c> object.
	///       </remarks>
	public ImageFormat ImageFormat
	{
		get
		{
			return imageFormat_0;
		}
		set
		{
			imageFormat_0 = value;
			bool_5 = true;
		}
	}

	/// <summary>
	///       Indicates whether the width and height of the cells is automatically fitted by cell value. 
	///       The default value is false.
	///       </summary>
	public bool IsCellAutoFit
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	/// <summary>
	///       When set the value to true, the page only include the cells that have data.
	///       The default value is false.
	///       </summary>
	[Obsolete("this property is obsolete")]
	public bool IsImageFitToPage
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

	/// <summary>
	///       If OnePagePerSheet is true , all content of one sheet will output to only one page in result. 
	///       The paper size of pagesetup will be invalid, and the other settings of pagesetup 
	///       will still take effect.
	///       </summary>
	public bool OnePagePerSheet
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
	///       Implements this interface to get DrawObject and Bound when rendering.
	///       </summary>
	public DrawObjectEventHandler DrawObjectEventHandler
	{
		get
		{
			return drawObjectEventHandler_0;
		}
		set
		{
			drawObjectEventHandler_0 = value;
		}
	}

	/// <summary>
	///       Indicate the chart imagetype when converting.
	///       </summary>
	public ImageFormat ChartImageType
	{
		get
		{
			return imageFormat_1;
		}
		set
		{
			imageFormat_1 = value;
		}
	}

	public string EmbededImageNameInSvg
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

	public bool OnlyArea
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	[SpecialName]
	internal bool method_0()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_1(bool bool_11)
	{
		bool_1 = bool_11;
	}
}
