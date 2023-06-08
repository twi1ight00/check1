using System.Runtime.InteropServices;

namespace Aspose.Slides.Vba;

[ComVisible(true)]
[Guid("D71DB457-E6BD-4A78-8B6C-132A0DAA2F98")]
public interface IVbaReferenceOleTypeLib : IVbaReference
{
	string Libid { get; set; }

	IVbaReference AsIVbaReference { get; }
}
