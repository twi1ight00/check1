using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("8bb9788c-86c4-405a-b148-164ca233b4a5")]
public interface IColorFormat : IFillParamSource
{
	ColorType ColorType { get; set; }

	Color Color { get; set; }

	PresetColor PresetColor { get; set; }

	SystemColor SystemColor { get; set; }

	SchemeColor SchemeColor { get; set; }

	byte R { get; set; }

	byte G { get; set; }

	byte B { get; set; }

	float FloatR { get; set; }

	float FloatG { get; set; }

	float FloatB { get; set; }

	float Hue { get; set; }

	float Saturation { get; set; }

	float Luminance { get; set; }

	IColorOperationCollection ColorTransform { get; }

	IFillParamSource AsIFillParamSource { get; }

	string ToString(ColorStringFormat format);

	void CopyFrom(IColorFormat color);
}
