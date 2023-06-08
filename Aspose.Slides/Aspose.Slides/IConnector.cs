using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("18cb7918-a5b5-4839-90f1-5c922a4b1d94")]
public interface IConnector : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape
{
	new IConnectorLock ShapeLock { get; }

	IShape StartShapeConnectedTo { get; set; }

	IShape EndShapeConnectedTo { get; set; }

	uint StartShapeConnectionSiteIndex { get; set; }

	uint EndShapeConnectionSiteIndex { get; set; }

	IGeometryShape AsIGeometryShape { get; }
}
