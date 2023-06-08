namespace Aspose.Cells;

public class DifSaveOptions : SaveOptions
{
	/// <summary>
	///       Creates the options for saving office open xml file.
	///       </summary>
	public DifSaveOptions()
	{
		m_SaveFormat = SaveFormat.Dif;
	}

	internal DifSaveOptions(SaveOptions saveOptions_0)
	{
		m_SaveFormat = SaveFormat.Dif;
		Copy(saveOptions_0);
	}
}
