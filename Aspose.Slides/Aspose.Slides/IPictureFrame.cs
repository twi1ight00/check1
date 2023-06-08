using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("e9a99c7c-5087-4fa2-8610-708057025ad9")]
public interface IPictureFrame : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape
{
	new IPictureFrameLock ShapeLock { get; }

	IPictureFillFormat PictureFormat { get; }

	float RelativeScaleHeight { get; set; }

	float RelativeScaleWidth { get; set; }

	IGeometryShape AsIGeometryShape { get; }
}
