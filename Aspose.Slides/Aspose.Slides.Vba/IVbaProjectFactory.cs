using System.Runtime.InteropServices;

namespace Aspose.Slides.Vba;

[Guid("DC326EC1-5A22-4F5B-8A0B-014146939D44")]
[ComVisible(true)]
public interface IVbaProjectFactory
{
	IVbaProject CreateVbaProject();

	IVbaProject ReadVbaProject(byte[] data);
}
