using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("e8edabd0-0e1d-442f-9349-28b28a7d2741")]
[ComVisible(true)]
public interface ICamera
{
	CameraPresetType CameraType { get; set; }

	float FieldOfViewAngle { get; set; }

	float Zoom { get; set; }

	void SetRotation(float latitude, float longitude, float revolution);

	float[] GetRotation();
}
