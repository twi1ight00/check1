namespace Aspose.Cells;

/// <summary>
///       Represents the options of saving office open xml file.
///       </summary>
public class OoxmlSaveOptions : SaveOptions
{
	private LightCellsDataProvider lightCellsDataProvider_0;

	/// <summary>
	///       Indicates if export cell name to Excel2007 .xlsx (.xlsm, .xltx, .xltm) file. 
	///       If the output file may be accessed by SQL Server DTS, this value must be true.
	///       Setting the value to false will highly increase the performance and reduce the file size when creating large file.
	///       Default value is false. 
	///       </summary>
	public bool ExportCellName
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
	///       Creates the options for saving office open xml file.
	///       </summary>
	public OoxmlSaveOptions()
	{
		m_SaveFormat = SaveFormat.Xlsx;
	}

	/// <summary>
	///       Creates the options for saving office open xml file.
	///       </summary>
	/// <param name="saveFormat">The file format.
	///       It must be xlsx,xltx,xlsm,xltm.</param>
	public OoxmlSaveOptions(SaveFormat saveFormat)
	{
		m_SaveFormat = saveFormat;
	}

	internal OoxmlSaveOptions(SaveFormat saveFormat_0, SaveOptions saveOptions_0)
	{
		m_SaveFormat = saveFormat_0;
		Copy(saveOptions_0);
	}

	internal OoxmlSaveOptions(SaveOptions saveOptions_0)
	{
		m_SaveFormat = saveOptions_0.SaveFormat;
		Copy(saveOptions_0);
	}
}
