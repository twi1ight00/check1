using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("61b7250d-128b-4d2f-97f1-2646199b0a15")]
public interface IFillFormat : IFillParamSource
{
	FillType FillType { get; set; }

	IColorFormat SolidFillColor { get; }

	IGradientFormat GradientFormat { get; }

	IPatternFormat PatternFormat { get; }

	IPictureFillFormat PictureFillFormat { get; }

	NullableBool RotateWithShape { get; set; }

	IFillParamSource AsIFillParamSource { get; }
}
