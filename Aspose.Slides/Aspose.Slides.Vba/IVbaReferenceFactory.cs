using System.Runtime.InteropServices;

namespace Aspose.Slides.Vba;

[Guid("95ADE943-DEFE-4AF4-8486-74A93B12D148")]
[ComVisible(true)]
public interface IVbaReferenceFactory
{
	IVbaReferenceOleTypeLib CreateOleTypeLibReference(string name, string libid);
}
