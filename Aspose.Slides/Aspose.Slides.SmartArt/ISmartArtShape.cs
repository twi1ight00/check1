using System.Runtime.InteropServices;

namespace Aspose.Slides.SmartArt;

[Guid("92298AD6-E2BF-4D28-9380-C61B3B298893")]
[ComVisible(true)]
public interface ISmartArtShape : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape
{
	IGeometryShape AsIGeometryShape { get; }
}
