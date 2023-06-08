using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("f6dcf748-fcb1-47ba-a49b-f9e395963e9d")]
public interface IGroupShapeLock : IBaseShapeLock
{
	bool GroupingLocked { get; set; }

	bool UngroupingLocked { get; set; }

	bool SelectLocked { get; set; }

	bool RotationLocked { get; set; }

	bool AspectRatioLocked { get; set; }

	bool PositionLocked { get; set; }

	bool SizeLocked { get; set; }

	IBaseShapeLock AsIBaseShapeLock { get; }
}
