using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("b78f909c-f191-40df-995c-2cc2b6420052")]
public interface ILightRig
{
	LightingDirection Direction { get; set; }

	LightRigPresetType LightType { get; set; }

	void SetRotation(float latitude, float longitude, float revolution);

	float[] GetRotation();
}
