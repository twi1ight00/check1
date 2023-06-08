using System.Runtime.InteropServices;

namespace Aspose.Slides.Vba;

[ComVisible(true)]
[Guid("F145A4F2-4EDF-4954-ABC3-43DE4A62B289")]
public interface IVbaProject
{
	string Name { get; }

	IVbaModuleCollection Modules { get; }

	IVbaReferenceCollection References { get; }

	byte[] ToBinary();
}
