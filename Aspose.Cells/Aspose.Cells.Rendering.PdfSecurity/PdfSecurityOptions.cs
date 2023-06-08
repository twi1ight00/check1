namespace Aspose.Cells.Rendering.PdfSecurity;

/// <summary>
///       Settings of pdf when converting excel to pdf, PDF/A does not allow security setting.
///       </summary>
public class PdfSecurityOptions
{
	private string string_0;

	private string string_1;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	/// <summary>
	///       Gets or sets the user password
	///       </summary>
	public string UserPassword
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
	///       Gets or sets the owner password of the document
	///       </summary>
	public string OwnerPassword
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
	///       Permission to print pdf document
	///       </summary>
	public bool PrintPermission
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
	///       Permission to modify pdf document
	///       </summary>
	public bool ModifyDocumentPermission
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
	///       Permission to copy or extract content Obsoleted according to PDF reference.
	///       </summary>
	public bool ExtractContentPermissionObsolete
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
	///       Permission to comment on the document.
	///       </summary>
	public bool AnnotationsPermission
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
	///       Permission to fill the form fields.
	///       </summary>
	public bool FillFormsPermission
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

	/// <summary>
	///        Permission to copy or extract content.
	///       </summary>
	public bool ExtractContentPermission
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = true;
		}
	}

	/// <summary>
	///       Permission to insert, rotate, or delete pages and create bookmarks or thumbnail images even if ModifyDocumentPermission is not set.
	///       </summary>
	public bool AssembleDocumentPermission
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

	/// <summary>
	///       Permission to print in high quality.
	///       </summary>
	public bool FullQualityPrintPermission
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
	///       The constructor of PdfSecurityOptions
	///       </summary>
	public PdfSecurityOptions()
	{
	}
}
