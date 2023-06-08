using System;
using System.ComponentModel;
using System.Text;

namespace Aspose.Cells;

/// <summary>
///       Repesents the save options for csv/tab delimitered/other text format.
///       </summary>
public class TxtSaveOptions : SaveOptions
{
	private string string_3;

	private Encoding encoding_0 = Encoding.Default;

	internal bool bool_7 = true;

	private TxtValueQuoteType txtValueQuoteType_0;

	/// <summary>
	///       Gets and sets char Delimiter of text file.
	///       </summary>
	public char Separator
	{
		get
		{
			if (string_3 != null && string_3.Length >= 1)
			{
				return string_3[0];
			}
			return ',';
		}
		set
		{
			string_3 = "" + value;
		}
	}

	/// <summary>
	///       Gets and sets the a string value as separator.
	///       </summary>
	public string SeparatorString
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

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use QuoteType property instead.")]
	public bool AlwaysQuoted
	{
		get
		{
			return txtValueQuoteType_0 == TxtValueQuoteType.Always;
		}
		set
		{
			txtValueQuoteType_0 = (value ? TxtValueQuoteType.Always : TxtValueQuoteType.Normal);
		}
	}

	public TxtValueQuoteType QuoteType
	{
		get
		{
			return txtValueQuoteType_0;
		}
		set
		{
			txtValueQuoteType_0 = value;
		}
	}

	internal Encoding Encoding
	{
		get
		{
			return encoding_0;
		}
		set
		{
			encoding_0 = value;
			bool_7 = false;
		}
	}

	/// <summary>
	///       Creates text file save options.
	///       </summary>
	public TxtSaveOptions()
	{
		m_SaveFormat = SaveFormat.CSV;
		string_3 = ",";
	}

	/// <summary>
	///       Creates text file save options.
	///       </summary>
	/// <param name="format">The save foramt of the text file.</param>
	public TxtSaveOptions(SaveFormat format)
	{
		m_SaveFormat = format;
		switch (format)
		{
		case SaveFormat.TabDelimited:
			string_3 = "\t";
			break;
		case SaveFormat.Auto:
			m_SaveFormat = SaveFormat.CSV;
			string_3 = ",";
			break;
		case SaveFormat.CSV:
			string_3 = ",";
			break;
		}
	}

	internal TxtSaveOptions(SaveFormat saveFormat_0, SaveOptions saveOptions_0)
	{
		m_SaveFormat = saveFormat_0;
		switch (saveFormat_0)
		{
		case SaveFormat.TabDelimited:
			string_3 = "\t";
			break;
		case SaveFormat.Auto:
			m_SaveFormat = SaveFormat.CSV;
			string_3 = ",";
			break;
		case SaveFormat.CSV:
			string_3 = ",";
			break;
		}
		Copy(saveOptions_0);
	}

	internal static TxtSaveOptions smethod_0(WorkbookSettings workbookSettings_0, SaveFormat saveFormat_0, SaveOptions saveOptions_0)
	{
		TxtSaveOptions txtSaveOptions = null;
		txtSaveOptions = ((!(saveOptions_0 is TxtSaveOptions)) ? new TxtSaveOptions(saveFormat_0, saveOptions_0) : ((TxtSaveOptions)saveOptions_0));
		if (!workbookSettings_0.bool_12)
		{
			txtSaveOptions.Encoding = workbookSettings_0.Encoding;
		}
		return txtSaveOptions;
	}
}
