using System.Drawing.Printing;

namespace Aspose.Words.Rendering;

[JavaDelete("We don't cash printer settings in java.")]
public class PrinterSettingsContainer
{
	private readonly PrinterSettings.PaperSizeCollection x5bdc67fc5ffdb791;

	private readonly PaperSource xed47d741a8ce78ff;

	private readonly PrinterSettings.PaperSourceCollection x8c7d66b47d62cc06;

	public PrinterSettings.PaperSizeCollection PaperSizes => x5bdc67fc5ffdb791;

	public PaperSource DefaultPageSettingsPaperSource => xed47d741a8ce78ff;

	public PrinterSettings.PaperSourceCollection PaperSources => x8c7d66b47d62cc06;

	public PrinterSettingsContainer(PrinterSettings settings)
	{
		int count = settings.PaperSizes.Count;
		System.Drawing.Printing.PaperSize[] array = new System.Drawing.Printing.PaperSize[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = settings.PaperSizes[i];
		}
		x5bdc67fc5ffdb791 = new PrinterSettings.PaperSizeCollection(array);
		xed47d741a8ce78ff = settings.DefaultPageSettings.PaperSource;
		count = settings.PaperSources.Count;
		PaperSource[] array2 = new PaperSource[count];
		for (int j = 0; j < count; j++)
		{
			array2[j] = settings.PaperSources[j];
		}
		x8c7d66b47d62cc06 = new PrinterSettings.PaperSourceCollection(array2);
	}
}
