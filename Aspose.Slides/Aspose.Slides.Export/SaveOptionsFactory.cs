using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[ComVisible(true)]
[Guid("183c9cd9-ef9a-4d06-806b-ee4ef6239dc5")]
[ClassInterface(ClassInterfaceType.None)]
public class SaveOptionsFactory : ISaveOptionsFactory
{
	public IPptxOptions CreatePptxOptions()
	{
		return new PptxOptions();
	}
}
