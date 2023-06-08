using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[ComVisible(true)]
[Guid("ab682b3a-6bdf-4946-9da3-db1498a27d0b")]
public interface IPptxOptions : ISaveOptions
{
	ISaveOptions AsISaveOptions { get; }
}
