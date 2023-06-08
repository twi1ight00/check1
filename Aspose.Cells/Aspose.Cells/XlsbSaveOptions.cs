namespace Aspose.Cells;

/// <summary>
///       Represents the options for saving xlsb file.
///       </summary>
public class XlsbSaveOptions : SaveOptions
{
	/// <summary>
	///       Creates xlsb file save options.
	///       </summary>
	public XlsbSaveOptions()
	{
		m_SaveFormat = SaveFormat.Xlsb;
	}

	/// <summary>
	///       Creates xlsb file save options.
	///       </summary>
	/// <param name="saveFormat">The save format . It must be xlsb.</param>
	public XlsbSaveOptions(SaveFormat saveFormat)
	{
		m_SaveFormat = SaveFormat.Xlsb;
	}

	internal XlsbSaveOptions(SaveOptions saveOptions_0)
	{
		m_SaveFormat = SaveFormat.Xlsb;
		Copy(saveOptions_0);
	}
}
