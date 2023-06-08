using System.Runtime.InteropServices;

namespace Aspose.Slides.Vba;

[Guid("BEDF0867-105A-45FE-A4B3-06D8C8758B9B")]
[ComVisible(true)]
public interface IVbaModule
{
	string Name { get; }

	string SourceCode { get; set; }
}
