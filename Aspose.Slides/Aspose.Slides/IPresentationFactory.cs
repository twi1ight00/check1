using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("f818a1cd-3dfc-45bc-bc3b-7fe35b8baca8")]
[ComVisible(true)]
public interface IPresentationFactory
{
	IPresentation CreatePresentation();

	IPresentation CreatePresentation(ILoadOptions options);

	IPresentationInfo GetPresentationInfo(string file);

	IPresentationInfo GetPresentationInfo(Stream stream);

	IPresentation ReadPresentation(byte[] data);

	IPresentation ReadPresentation(byte[] data, ILoadOptions options);

	IPresentation ReadPresentation(Stream stream);

	IPresentation ReadPresentation(Stream stream, ILoadOptions options);

	IPresentation ReadPresentation(string file);

	IPresentation ReadPresentation(string file, ILoadOptions options);
}
