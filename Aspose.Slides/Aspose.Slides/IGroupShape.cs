using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("5ca11dd2-d965-45a2-b56d-a516696c647b")]
public interface IGroupShape : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape
{
	new IGroupShapeLock ShapeLock { get; }

	IShapeCollection Shapes { get; }

	IShape AsIShape { get; }
}
