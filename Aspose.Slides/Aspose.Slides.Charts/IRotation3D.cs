using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("df6070ef-bf47-40bd-8910-5a19dc1fad02")]
public interface IRotation3D
{
	sbyte RotationX { get; set; }

	ushort RotationY { get; set; }

	byte Perspective { get; set; }

	bool RightAngleAxes { get; set; }

	ushort DepthPercents { get; set; }

	ushort HeightPercents { get; set; }
}
