using System.Text;

namespace Aspose.Cells;

/// <summary>
///       Represents options when importing a html file.
///       </summary>
public class HTMLLoadOptions : LoadOptions
{
	private string string_2;

	private bool bool_8 = true;

	private Encoding encoding_0 = Encoding.UTF8;

	private bool bool_9 = true;

	private bool bool_10 = true;

	/// <summary>
	///       The directory that the attached files will be saved to.
	///       </summary>
	public string AttachedFilesDirectory
	{
		get
		{
			return string_2;
		}
		set
		{
			if (!value.EndsWith("/") && !value.EndsWith("\\"))
			{
				value += "\\";
			}
			string_2 = value;
		}
	}

	/// <summary>
	///       Indicates whether importing formulas if the orignal html file contains falmulas
	///       </summary>
	public bool LoadFormulas
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
	///       If not set,use Encoding.Default as default enconding type.
	///       </summary>
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

	/// <summary>
	///       if set true, do format, default is true
	///       </summary>
	public new bool ConvertNumericData
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
	///       if set true, do format, default is true
	///       </summary>
	public bool ConvertDateTimeData
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

	public HTMLLoadOptions()
	{
		m_LoadFormat = LoadFormat.Html;
	}

	public HTMLLoadOptions(LoadFormat loadFormat)
	{
		m_LoadFormat = loadFormat;
	}
}
