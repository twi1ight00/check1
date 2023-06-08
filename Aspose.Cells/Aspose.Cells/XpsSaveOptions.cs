using Aspose.Cells.Rendering;

namespace Aspose.Cells;

/// <summary>
///       Can be used to specify additional options when saving the file into the Xps format. 
///       </summary>
public class XpsSaveOptions : SaveOptions
{
	private ImageOrPrintOptions imageOrPrintOptions_0;

	internal ImageOrPrintOptions ImageOrPrintOptions => imageOrPrintOptions_0;

	/// <summary>
	///        Creates options for saving xps file.
	///       </summary>
	public XpsSaveOptions()
	{
		m_SaveFormat = SaveFormat.XPS;
		imageOrPrintOptions_0 = new ImageOrPrintOptions();
		imageOrPrintOptions_0.SaveFormat = m_SaveFormat;
	}

	/// <summary>
	///        Creates options for saving xps file.
	///       </summary>
	/// <param name="saveFormat">The save format</param>
	public XpsSaveOptions(SaveFormat saveFormat)
	{
		m_SaveFormat = saveFormat;
		imageOrPrintOptions_0 = new ImageOrPrintOptions();
		imageOrPrintOptions_0.SaveFormat = m_SaveFormat;
	}

	internal static XpsSaveOptions smethod_0(SaveOptions saveOptions_0)
	{
		if (saveOptions_0 is XpsSaveOptions)
		{
			return (XpsSaveOptions)saveOptions_0;
		}
		return new XpsSaveOptions();
	}
}
