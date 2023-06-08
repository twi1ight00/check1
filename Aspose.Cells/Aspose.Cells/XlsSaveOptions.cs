namespace Aspose.Cells;

/// <summary>
///       Represents the save options for the Excel 97-2003 file format: xls and xlt.
///       </summary>
public class XlsSaveOptions : SaveOptions
{
	private LightCellsDataProvider lightCellsDataProvider_0;

	/// <summary>
	///       The Data provider to provide cells data for saving workbook in light mode.
	///       </summary>
	public LightCellsDataProvider LightCellsDataProvider
	{
		get
		{
			return lightCellsDataProvider_0;
		}
		set
		{
			lightCellsDataProvider_0 = value;
		}
	}

	/// <summary>
	///       Creates options for saving Excel 97-2003 xls/xlt file.
	///       </summary>
	public XlsSaveOptions()
	{
		m_SaveFormat = SaveFormat.Excel97To2003;
	}

	/// <summary>
	///       Creates options for saving Excel 97-2003 xls/xlt file.
	///       </summary>
	/// <param name="format">The file format. It must be xls/xlt.</param>
	public XlsSaveOptions(SaveFormat format)
	{
		m_SaveFormat = format;
	}

	internal XlsSaveOptions(SaveOptions saveOptions_0)
	{
		m_SaveFormat = SaveFormat.Excel97To2003;
		Copy(saveOptions_0);
	}
}
