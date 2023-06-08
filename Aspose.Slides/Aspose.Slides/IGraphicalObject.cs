using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("f5d2e330-8ee8-4f53-a9e6-6b6c72ce5b0f")]
public interface IGraphicalObject : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape
{
	new IGraphicalObjectLock ShapeLock { get; }

	IShape AsIShape { get; }
}
