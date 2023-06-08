using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("571955f4-210f-456b-a171-b416757bd2e2")]
[ComVisible(true)]
public interface IPictureFrameLock : IBaseShapeLock
{
	bool GroupingLocked { get; set; }

	bool SelectLocked { get; set; }

	bool RotationLocked { get; set; }

	bool AspectRatioLocked { get; set; }

	bool PositionLocked { get; set; }

	bool SizeLocked { get; set; }

	bool EditPointsLocked { get; set; }

	bool AdjustHandlesLocked { get; set; }

	bool ArrowheadsLocked { get; set; }

	bool ShapeTypeLocked { get; set; }

	bool CropLocked { get; set; }

	IBaseShapeLock AsIBaseShapeLock { get; }
}
