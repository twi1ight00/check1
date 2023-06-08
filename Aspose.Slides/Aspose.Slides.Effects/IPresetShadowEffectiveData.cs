using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("47abcf33-44ca-4f33-ba41-e394b1c0b583")]
public interface IPresetShadowEffectiveData
{
	float Direction { get; }

	double Distance { get; }

	Color ShadowColor { get; }

	PresetShadowType Preset { get; }
}
