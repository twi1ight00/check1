using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("be92d194-16a7-475c-b6ad-d23db7754edb")]
[ComVisible(true)]
public interface IPresentationComponent
{
	IPresentation Presentation { get; }
}
