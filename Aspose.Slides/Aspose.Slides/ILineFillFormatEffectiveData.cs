using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("652afd58-c756-41dc-be29-678dec903b22")]
public interface ILineFillFormatEffectiveData : IFillParamSource
{
	FillType FillType { get; }

	Color SolidFillColor { get; }

	IGradientFormatEffectiveData GradientFormat { get; }

	IPatternFormatEffectiveData PatternFormat { get; }

	bool RotateWithShape { get; }

	IFillParamSource AsIFillParamSource { get; }
}
