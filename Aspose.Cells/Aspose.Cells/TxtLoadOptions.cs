using System.Runtime.CompilerServices;
using System.Text;

namespace Aspose.Cells;

/// <summary>
///       Represents the options for loading text file.
///       </summary>
public class TxtLoadOptions : LoadOptions
{
	private string string_2;

	private Encoding encoding_0 = Encoding.Default;

	internal bool bool_8 = true;

	private ICustomParser[] icustomParser_0;

	private bool bool_9 = true;

	private bool bool_10 = true;

	/// <summary>
	///       Gets and sets char Delimiter of text file.
	///       </summary>
	public char Separator
	{
		get
		{
			if (string_2 != null && string_2.Length >= 1)
			{
				return string_2[0];
			}
			return ',';
		}
		set
		{
			string_2 = "" + value;
		}
	}

	/// <summary>
	///       Gets and sets the a string value as separator.
	///       </summary>
	public string SeparatorString
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
	///       Gets and sets the default encoding.Only applies for csv file.
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
			bool_8 = false;
		}
	}

	/// <summary>
	///       Gets and sets preferred value parsers for loading text file.
	///       </summary>
	/// <remarks>
	///       parsers[0] is the parser will be used for the first column in text template file,
	///       parsers[1] is the parser will be used for the second column, ...etc.
	///       The last one(parsers[parsers.length-1]) will be used for all other columns start from parsers.length-1.
	///       </remarks>
	public ICustomParser[] PreferredParsers
	{
		get
		{
			return icustomParser_0;
		}
		set
		{
			icustomParser_0 = value;
		}
	}

	/// <summary>
	///       Gets or sets a value that indicates whether the string in text file is converted to date data.
	///       </summary>
	public bool ConvertDateTimeData
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
	///       Creates the options for loading text file.
	///       </summary>
	/// <remarks>The default load file type is CSV .</remarks>
	public TxtLoadOptions()
	{
		m_LoadFormat = LoadFormat.CSV;
		string_2 = ",";
	}

	/// <summary>
	///       Creates the options for loading text file.
	///       </summary>
	/// <param name="loadFormat">The loading format</param>
	public TxtLoadOptions(LoadFormat loadFormat)
	{
		m_LoadFormat = loadFormat;
		switch (loadFormat)
		{
		case LoadFormat.TabDelimited:
			string_2 = "\t";
			break;
		case LoadFormat.Auto:
		case LoadFormat.CSV:
			string_2 = ",";
			break;
		}
	}

	[SpecialName]
	internal bool method_2()
	{
		if (string_2 != null)
		{
			return string_2.Length == 1;
		}
		return false;
	}

	[SpecialName]
	internal bool method_3()
	{
		return bool_10;
	}
}
