using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("e17362a3-f110-4e61-bba1-10dfba941394")]
public interface IConnectorLock : IBaseShapeLock
{
	bool GroupingLocked { get; set; }

	bool SelectLocked { get; set; }

	bool RotateLocked { get; set; }

	bool AspectRatioLocked { get; set; }

	bool PositionMove { get; set; }

	bool SizeLocked { get; set; }

	bool EditPointsLocked { get; set; }

	bool AdjustHandlesLocked { get; set; }

	bool ArrowheadsLocked { get; set; }

	bool ShapeTypeLocked { get; set; }

	IBaseShapeLock AsIBaseShapeLock { get; }
}
