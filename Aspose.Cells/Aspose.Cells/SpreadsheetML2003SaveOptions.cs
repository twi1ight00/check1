namespace Aspose.Cells;

/// <summary>
///       Represents the options for saving Excel 2003 spreadml file.
///       </summary>
public class SpreadsheetML2003SaveOptions : SaveOptions
{
	private bool bool_7 = true;

	private bool bool_8 = true;

	private bool bool_9;

	/// <summary>
	///       Causes child elements to be indented.
	///       </summary>
	/// <remarks>
	///       The default value is true.
	///       If the value is false, it will reduce the size of the xml file 
	///       </remarks>
	public bool IsIndentedFormatting
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
	///       Limit as xls, the max row index is 65535 and the max column index is 255.
	///       </summary>
	public bool LimitAsXls
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
	///       The default value is false, it means that column index  will be ignored if the cell is contiguous to the previous cell.
	///       </summary>
	public bool ExportColumnIndexOfCell
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
	///       Creates the options for saving Excel 2003 spreadml file.
	///       </summary>
	public SpreadsheetML2003SaveOptions()
	{
		m_SaveFormat = SaveFormat.SpreadsheetML;
	}

	/// <summary>
	///       Creates the options for saving Excel 2003 spreadml file.
	///       </summary>
	/// <param name="saveFormat">The save format.</param>
	public SpreadsheetML2003SaveOptions(SaveFormat saveFormat)
	{
		m_SaveFormat = saveFormat;
	}

	internal SpreadsheetML2003SaveOptions(SaveOptions saveOptions_0)
	{
		m_SaveFormat = SaveFormat.SpreadsheetML;
		Copy(saveOptions_0);
	}
}
