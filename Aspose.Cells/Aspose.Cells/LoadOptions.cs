using System.Runtime.CompilerServices;

namespace Aspose.Cells;

/// <summary>
///       Represents the options of loading the file.
///       </summary>
public class LoadOptions
{
	protected LoadFormat m_LoadFormat;

	private string string_0;

	private bool bool_0 = true;

	private bool bool_1;

	private LoadDataOption loadDataOption_0;

	private bool bool_2;

	private CountryCode countryCode_0;

	private CountryCode countryCode_1;

	private bool bool_3 = true;

	internal bool bool_4;

	internal bool bool_5;

	private string string_1 = "Arial";

	private ushort ushort_0 = 200;

	private InterruptMonitor interruptMonitor_0;

	private bool bool_6;

	private bool bool_7;

	/// <summary>
	///       Gets and set the load format.
	///       </summary>
	public LoadFormat LoadFormat => m_LoadFormat;

	/// <summary>
	///       Gets and set the password of the workbook.
	///       </summary>
	public string Password
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
	///       Indicates whether parsing the formula when reading the file.
	///       </summary>
	/// <remarks>
	///       Only applies for Excel Xlsx,Xltx, Xltm,Xlsm file
	///       because the formulas in the files are stored with a string formula.
	///       </remarks>
	public bool ParsingFormulaOnOpen
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
	///       If true, only loads data and formulas from the file,other contents and settings are all discarded. 
	///       </summary>
	public bool LoadDataOnly
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
	///       If true, only loads document properties
	///       </summary>
	/// <remarks>
	///       Only for excel 97- 2003 xls file.
	///       If the file is encrypted, we still can get the document properties without password
	///       </remarks>
	public bool OnlyLoadDocumentProperties
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
	///       Only effects when OnlyLoadData is true.
	///       </summary>
	public LoadDataOption LoadDataOptions
	{
		get
		{
			if (loadDataOption_0 == null)
			{
				loadDataOption_0 = new LoadDataOption();
			}
			return loadDataOption_0;
		}
		set
		{
			loadDataOption_0 = value;
		}
	}

	/// <summary>
	///       Gets or sets the user interface language of the Workbook version based on CountryCode that has saved the file. 
	///       </summary>
	public CountryCode LanguageCode
	{
		get
		{
			return countryCode_0;
		}
		set
		{
			countryCode_0 = value;
		}
	}

	/// <summary>
	///       Gets or sets the system regional settings based on CountryCode at the time the file was saved. 
	///       </summary>
	/// <remarks>If you do not want to use the region  saved in the file, 
	///       please reset it after reading the file.</remarks>
	public CountryCode Region
	{
		get
		{
			return countryCode_1;
		}
		set
		{
			countryCode_1 = value;
		}
	}

	/// <summary>
	///       Gets or sets a value that indicates whether the string in text file is converted to numeric data.
	///       </summary>
	public bool ConvertNumericData
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
	///       Sets the default standard font name
	///       </summary>
	public string StandardFont
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			bool_4 = true;
		}
	}

	/// <summary>
	///       Sets the default standard font size.
	///       </summary>
	public double StandardFontSize
	{
		get
		{
			return (float)(int)ushort_0 / 20f;
		}
		set
		{
			ushort_0 = (ushort)(value * 20.0 + 0.5);
			bool_5 = true;
		}
	}

	/// <summary>
	///       Gets and sets the interrupt monitor.
	///       </summary>
	public InterruptMonitor InterruptMonitor
	{
		get
		{
			return interruptMonitor_0;
		}
		set
		{
			interruptMonitor_0 = value;
		}
	}

	public bool IgnoreNotPrinted
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

	internal void method_0(LoadFormat loadFormat_0)
	{
		m_LoadFormat = loadFormat_0;
	}

	/// <summary>
	///       Creates an options of loading the file.
	///       </summary>
	public LoadOptions()
	{
		m_LoadFormat = LoadFormat.Auto;
	}

	/// <summary>
	///       Creates an options of loading the file.
	///       </summary>
	/// <param name="loadFormat">The loading format.</param>
	public LoadOptions(LoadFormat loadFormat)
	{
		m_LoadFormat = loadFormat;
	}

	[SpecialName]
	internal bool method_1()
	{
		return bool_7;
	}
}
