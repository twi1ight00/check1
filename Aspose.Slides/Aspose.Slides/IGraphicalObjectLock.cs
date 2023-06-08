using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("f1f6d7ac-6b8c-4efe-85a8-1feed15cacbe")]
public interface IGraphicalObjectLock : IBaseShapeLock
{
	bool GroupingLocked { get; set; }

	bool DrilldownLocked { get; set; }

	bool SelectLocked { get; set; }

	bool AspectRatioLocked { get; set; }

	bool PositionLocked { get; set; }

	bool SizeLocked { get; set; }

	IBaseShapeLock AsIBaseShapeLock { get; }
}
