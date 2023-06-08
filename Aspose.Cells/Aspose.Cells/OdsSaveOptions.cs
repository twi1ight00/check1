namespace Aspose.Cells;

/// <summary>
///       Represents the options of saving ods file.
///       </summary>
public class OdsSaveOptions : SaveOptions
{
	/// <summary>
	///       Creates the options of saving ods file.
	///       </summary>
	public OdsSaveOptions()
	{
		m_SaveFormat = SaveFormat.ODS;
	}

	/// <summary>
	///       Creates the options of saving ods file.
	///       </summary>
	/// <param name="saveFormat">
	/// </param>
	public OdsSaveOptions(SaveFormat saveFormat)
	{
		m_SaveFormat = SaveFormat.ODS;
	}

	internal OdsSaveOptions(SaveOptions saveOptions_0)
	{
		m_SaveFormat = SaveFormat.ODS;
		Copy(saveOptions_0);
	}
}
