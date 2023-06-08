using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[Guid("55c32f94-1d92-4a4d-ad2f-02e69290c382")]
[ComVisible(true)]
public interface IPresetShadow
{
	float Direction { get; set; }

	double Distance { get; set; }

	IColorFormat ShadowColor { get; }

	PresetShadowType Preset { get; set; }
}
