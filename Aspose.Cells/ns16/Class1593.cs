using System.IO;
using Aspose.Cells;

namespace ns16;

internal class Class1593
{
	internal static void smethod_0(Workbook workbook_0, Stream stream_0, FileFormatType fileFormatType_0, SaveOptions saveOptions_0)
	{
		if (saveOptions_0 == null)
		{
			saveOptions_0 = new OoxmlSaveOptions();
		}
		else if (!(saveOptions_0 is OoxmlSaveOptions))
		{
			saveOptions_0 = new OoxmlSaveOptions(saveOptions_0);
		}
		Class1594 @class = new Class1594(workbook_0, stream_0, fileFormatType_0, (OoxmlSaveOptions)saveOptions_0);
		@class.Write();
	}
}
