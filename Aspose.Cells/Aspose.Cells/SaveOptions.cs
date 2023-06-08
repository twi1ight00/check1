using System;
using System.ComponentModel;
using Aspose.Cells.Rendering;

namespace Aspose.Cells;

/// <summary>
///       Represents all save options
///       </summary>
public class SaveOptions
{
	protected SaveFormat m_SaveFormat;

	internal bool bool_0 = true;

	private bool bool_1;

	private string string_0;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	internal string string_1;

	internal PdfCompliance pdfCompliance_0;

	internal PdfBookmarkEntry pdfBookmarkEntry_0;

	internal string string_2;

	internal bool bool_6;

	/// <summary>
	///       Gets and sets the save file format.
	///       </summary>
	public SaveFormat SaveFormat => m_SaveFormat;

	/// <summary>
	///       Indicates if export cell name to Excel2007 .xlsx (.xlsm, .xltx, .xltm) file. 
	///       If the output file may be accessed by SQL Server DTS, this value must be true.
	///       Setting the value to false will highly increase the performance and reduce the file size when creating large file.
	///       Default value is false. 
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use OoxmlSaveOptions.ExportCellName property.
	///       This property will be removed 12 months later since July 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use OoxmlSaveOptions.ExportCellName property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool ExpCellNameToXLSX
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
	///       Make the workbook empty after saving the file.
	///       </summary>
	public bool ClearData
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	/// <summary>
	///       The cached file folder is used to store some large data.
	///       </summary>
	public string CachedFileFolder
	{
		get
		{
			return string_0;
		}
		set
		{
			if (value != null && !(value == ""))
			{
				string_0 = value;
			}
			else
			{
				string_0 = null;
			}
		}
	}

	/// <summary>
	///       Indicates whether validate merged areas before saving the file.
	///       </summary>
	/// <remarks>
	///       The default value is false.
	///       </remarks>
	public bool ValidateMergedAreas
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	/// <summary>
	///       If true and the directory does not exist, the directory will be automatically created before saving the file.
	///       </summary>
	/// <remarks>
	///       The default value is false.
	///       </remarks>
	public bool CreateDirectory
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	/// <summary>
	///       Indicates whether sorting defined names before saving file.
	///       </summary>
	public bool SortNames
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool RefreshChartCache
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	/// <summary>
	///       When characters in the Excel are unicode and not be set with correct font in cell style,
	///       They may appear as block in pdf,image.
	///       Set the DefaultFont such as MingLiu or MS Gothic to show these characters.
	///       If this property is not set, Aspose.Cells will use system default font to show these unicode characters.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use PdfSaveOptions.DefaultFont property.
	///       This property will be removed 12 months later since July 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use PdfSaveOptions.DefaultFont property instead.")]
	public string DefaultFont
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
	///       Workbook converts to pdf will according to PdfCompliance in this property.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use PdfSaveOptions.Compliance property.
	///       This property will be removed 12 months later since July 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use PdfSaveOptions.Compliance property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public PdfCompliance Compliance
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
	///       Gets and sets the <see cref="T:Aspose.Cells.Rendering.PdfBookmarkEntry">PdfBookmarkEntry</see> object.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use PdfSaveOptions.Bookmark property.
	///       This property will be removed 12 months later since July 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use PdfSaveOptions.Bookmark property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public PdfBookmarkEntry PdfBookmark
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
	///       The physical folder where images will be saved when exporting a workbook to Aspose.Pdf XML format.
	///       Default is an empty string. 
	///       </summary>
	public string PdfExportImagesFolder
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

	public bool EnableHTTPCompression
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	internal SaveOptions()
	{
	}

	internal void method_0(SaveFormat saveFormat_0)
	{
		m_SaveFormat = saveFormat_0;
	}

	internal void Copy(SaveOptions saveOptions_0)
	{
		if (saveOptions_0 != null)
		{
			bool_6 = saveOptions_0.bool_6;
			string_0 = saveOptions_0.string_0;
			bool_1 = saveOptions_0.bool_1;
			bool_0 = saveOptions_0.bool_0;
			pdfBookmarkEntry_0 = saveOptions_0.pdfBookmarkEntry_0;
			string_2 = saveOptions_0.string_2;
			string_1 = saveOptions_0.string_1;
			pdfCompliance_0 = saveOptions_0.pdfCompliance_0;
		}
	}
}
