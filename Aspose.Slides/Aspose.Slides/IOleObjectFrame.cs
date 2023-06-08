using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("849679b6-7ac6-41cc-859d-d3eb9e31cd30")]
[ComVisible(true)]
public interface IOleObjectFrame : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGraphicalObject
{
	IPictureFillFormat SubstitutePictureFormat { get; }

	string ObjectName { get; set; }

	string ObjectProgId { get; set; }

	byte[] ObjectData { get; set; }

	string LinkFileName { get; }

	string LinkPathLong { get; set; }

	bool IsObjectIcon { get; set; }

	bool IsObjectLink { get; }

	bool UpdateAutomatic { get; set; }

	IGraphicalObject AsIGraphicalObject { get; }
}
