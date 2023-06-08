namespace Aspose.Cells.Markup;

/// <summary>
///       Represents the options of the smart tag.
///       </summary>
public class SmartTagOptions
{
	private bool bool_0;

	private SmartTagShowType smartTagShowType_0;

	/// <summary>
	///       Indicates whether saving smart tags with the workbook. 
	///       </summary>
	public bool EmbedSmartTags
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
	///       Repesents the show type of smart tag.
	///       </summary>
	public SmartTagShowType ShowType
	{
		get
		{
			return smartTagShowType_0;
		}
		set
		{
			smartTagShowType_0 = value;
		}
	}

	internal void Copy(SmartTagOptions smartTagOptions_0)
	{
		smartTagShowType_0 = smartTagOptions_0.smartTagShowType_0;
		bool_0 = smartTagOptions_0.bool_0;
	}
}
