using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[Guid("3F87C558-7973-421D-80D3-B1B3F9AB403F")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class PptxOptions : SaveOptions, ISaveOptions, IPptxOptions
{
	ISaveOptions IPptxOptions.AsISaveOptions => this;

	internal PptxOptions Clone()
	{
		return (PptxOptions)MemberwiseClone();
	}
}
