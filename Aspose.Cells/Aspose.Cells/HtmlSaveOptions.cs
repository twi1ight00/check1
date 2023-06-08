using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Text;

namespace Aspose.Cells;

/// <summary>
///       Represents the options for saving html file.
///       </summary>
public class HtmlSaveOptions : SaveOptions
{
	private string string_3;

	private string string_4;

	private string string_5;

	private bool bool_7 = true;

	private bool bool_8 = true;

	private bool bool_9;

	internal bool bool_10 = true;

	private bool bool_11 = true;

	private bool bool_12 = true;

	private HtmlCrossType htmlCrossType_0;

	private HtmlHiddenColDisplayType htmlHiddenColDisplayType_0;

	private HtmlHiddenRowDisplayType htmlHiddenRowDisplayType_0;

	private Encoding encoding_0;

	private IExportObjectListener iexportObjectListener_0;

	private IStreamProvider istreamProvider_0;

	private ImageFormat imageFormat_0 = ImageFormat.Png;

	/// <summary>
	///       The title of the html page.
	///       Only for saving to html stream.
	///       </summary>
	public string PageTitle
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	/// <summary>
	///       The directory that the attached files will be saved to.
	///       Only for saving to html stream.
	///       </summary>
	public string AttachedFilesDirectory
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	/// <summary>
	///       Specify the Url prefix of attached files such as image in the html file.
	///       Only for saving to html stream.
	///       </summary>
	public string AttachedFilesUrlPrefix
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	/// <summary>
	///       Indicates if a cross-cell string will be displayed in the same way as MS Excel when saving an Excel file in html format.
	///       By default the value is false, so, for cross-cell strings, there is little difference between the html files created by Aspose.Cells and MS Excel. But the performance for creating large html files will be more than ten times faster than setting the value to true.
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use HtmlSaveOptions.HtmlCrossStringType property instead.")]
	[Browsable(false)]
	public bool DisplayHTMLCrossString
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
			if (bool_7)
			{
				HtmlCrossStringType = HtmlCrossType.Default;
			}
			else
			{
				HtmlCrossStringType = HtmlCrossType.FitToCell;
			}
		}
	}

	/// <summary>
	///       Indicates if export image files to temp directory.
	///       Only for saving to html stream.
	///       </summary>
	public bool IsExpImageToTempDir
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

	public bool ExportImagesAsBase64
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
	///       Indicates if exporting the whole workbook to html file.
	///       </summary>
	public bool ExportActiveWorksheetOnly
	{
		get
		{
			return !bool_11;
		}
		set
		{
			bool_11 = !value;
			bool_10 = false;
		}
	}

	public bool ParseHtmlTagInCell
	{
		get
		{
			return bool_12;
		}
		set
		{
			bool_12 = value;
		}
	}

	public HtmlCrossType HtmlCrossStringType
	{
		get
		{
			return htmlCrossType_0;
		}
		set
		{
			htmlCrossType_0 = value;
		}
	}

	public HtmlHiddenColDisplayType HiddenColDisplayType
	{
		get
		{
			return htmlHiddenColDisplayType_0;
		}
		set
		{
			htmlHiddenColDisplayType_0 = value;
		}
	}

	public HtmlHiddenRowDisplayType HiddenRowDisplayType
	{
		get
		{
			return htmlHiddenRowDisplayType_0;
		}
		set
		{
			htmlHiddenRowDisplayType_0 = value;
		}
	}

	public Encoding Encoding
	{
		get
		{
			return encoding_0;
		}
		set
		{
			encoding_0 = value;
		}
	}

	public IExportObjectListener ExportObjectListener
	{
		get
		{
			return iexportObjectListener_0;
		}
		set
		{
			iexportObjectListener_0 = value;
		}
	}

	public IStreamProvider ExportProviderFile
	{
		get
		{
			return istreamProvider_0;
		}
		set
		{
			istreamProvider_0 = value;
		}
	}

	public ImageFormat ExportChartImageFormat
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
	///       Creates options for saving html file.
	///       </summary>
	public HtmlSaveOptions()
	{
		m_SaveFormat = SaveFormat.Html;
	}

	/// <summary>
	///       Creates options for saving htm file.
	///       </summary>
	/// <param name="format">The saving file format.</param>
	public HtmlSaveOptions(SaveFormat format)
	{
		m_SaveFormat = format;
	}

	internal HtmlSaveOptions(SaveOptions saveOptions_0)
	{
		Copy(saveOptions_0);
		m_SaveFormat = SaveFormat.Html;
	}

	internal HtmlSaveOptions(SaveOptions saveOptions_0, bool bool_13)
	{
		Copy(saveOptions_0);
		if (bool_13)
		{
			m_SaveFormat = SaveFormat.MHtml;
		}
		else
		{
			m_SaveFormat = SaveFormat.Html;
		}
	}
}
