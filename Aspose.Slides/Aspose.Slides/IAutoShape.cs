using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("c95895f4-0bed-4cc9-8ecb-07101d097182")]
public interface IAutoShape : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape
{
	new IAutoShapeLock ShapeLock { get; }

	ITextFrame TextFrame { get; }

	bool UseBackgroundFill { get; set; }

	IGeometryShape AsIGeometryShape { get; }

	ITextFrame AddTextFrame(string text);
}
