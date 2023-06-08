using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("bd620214-7ee0-4f63-8a35-95d78a47c678")]
public interface IGeometryShape : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape
{
	IShapeStyle ShapeStyle { get; }

	ShapeType ShapeType { get; set; }

	IAdjustValueCollection Adjustments { get; }

	IShape AsIShape { get; }

	IShapeElement[] CreateShapeElements();
}
