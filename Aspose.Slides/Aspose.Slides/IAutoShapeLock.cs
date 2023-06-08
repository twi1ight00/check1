using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("00b2a808-ad69-46d8-9ac0-2a0abcb17e1e")]
[ComVisible(true)]
public interface IAutoShapeLock : IBaseShapeLock
{
	bool GroupingLocked { get; set; }

	bool SelectLocked { get; set; }

	bool RotateLocked { get; set; }

	bool AspectRatioLocked { get; set; }

	bool PositionLocked { get; set; }

	bool SizeLocked { get; set; }

	bool EditPointsLocked { get; set; }

	bool AdjustHandlesLocked { get; set; }

	bool ArrowheadsLocked { get; set; }

	bool ShapeTypeLocked { get; set; }

	bool TextLocked { get; set; }

	IBaseShapeLock AsIBaseShapeLock { get; }
}
