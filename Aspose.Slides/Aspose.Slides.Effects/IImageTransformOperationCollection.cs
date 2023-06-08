using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("7a41712f-e85d-4a01-aa47-ffb741cfaf34")]
public interface IImageTransformOperationCollection : IEnumerable, ICollection<IImageTransformOperation>, IEnumerable<IImageTransformOperation>
{
	IImageTransformOperation this[int index] { get; }

	IEnumerable AsIEnumerable { get; }

	void RemoveAt(int index);

	IAlphaBiLevel AddAlphaBiLevelEffect(float threshold);

	IAlphaCeiling AddAlphaCeilingEffect();

	IAlphaFloor AddAlphaFloorEffect();

	IAlphaInverse AddAlphaInverseEffect();

	IAlphaModulate AddAlphaModulateEffect();

	IAlphaModulateFixed AddAlphaModulateFixedEffect(float amount);

	IAlphaReplace AddAlphaReplaceEffect(float alpha);

	IBiLevel AddBiLevelEffect(float threshold);

	IBlur AddBlurEffect(double radius, bool grow);

	IColorChange AddColorChangeEffect();

	IColorReplace AddColorReplaceEffect();

	IDuotone AddDuotoneEffect();

	IFillOverlay AddFillOverlayEffect();

	IGrayScale AddGrayScaleEffect();

	IHSL AddHSLEffect(float hue, float saturation, float luminance);

	ILuminance AddLuminanceEffect(float brightness, float contrast);

	ITint AddTintEffect(float hue, float amount);
}
