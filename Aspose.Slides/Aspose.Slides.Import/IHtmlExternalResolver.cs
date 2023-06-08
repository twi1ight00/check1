using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Import;

[Guid("b80e794a-cccc-440c-bcda-12553ccf82ce")]
[ComVisible(true)]
public interface IHtmlExternalResolver
{
	string ResolveUri(string baseUri, string relativeUri);

	Stream GetEntity(string absoluteUri);
}
