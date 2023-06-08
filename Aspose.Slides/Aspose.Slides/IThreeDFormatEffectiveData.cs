using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("8ac0da79-ff20-467f-acb2-acb5ae569ba0")]
[ComVisible(true)]
public interface IThreeDFormatEffectiveData
{
	double ContourWidth { get; }

	double ExtrusionHeight { get; }

	double Depth { get; }

	IShapeBevelEffectiveData BevelTop { get; }

	IShapeBevelEffectiveData BevelBottom { get; }

	Color ContourColor { get; }

	Color ExtrusionColor { get; }

	ICameraEffectiveData Camera { get; }

	ILightRigEffectiveData LightRig { get; }

	MaterialPresetType Material { get; }
}
