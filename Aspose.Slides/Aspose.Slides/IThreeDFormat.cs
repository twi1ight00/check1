using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("1ebfccff-739c-4deb-b04d-e63d9adc595a")]
public interface IThreeDFormat : IPresentationComponent, ISlideComponent
{
	double ContourWidth { get; set; }

	double ExtrusionHeight { get; set; }

	double Depth { get; set; }

	IShapeBevel BevelTop { get; }

	IShapeBevel BevelBottom { get; }

	IColorFormat ContourColor { get; }

	IColorFormat ExtrusionColor { get; }

	ICamera Camera { get; }

	ILightRig LightRig { get; }

	MaterialPresetType Material { get; set; }

	ISlideComponent AsISlideComponent { get; }
}
