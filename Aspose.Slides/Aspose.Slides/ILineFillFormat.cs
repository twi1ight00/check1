using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("4b9f2738-8b3e-4d5c-a8ef-a8d9cdcac280")]
public interface ILineFillFormat : IFillParamSource
{
	FillType FillType { get; set; }

	IColorFormat SolidFillColor { get; }

	IGradientFormat GradientFormat { get; }

	IPatternFormat PatternFormat { get; }

	NullableBool RotateWithShape { get; set; }

	IFillParamSource AsIFillParamSource { get; }
}
