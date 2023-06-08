using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("016cf6f7-49f7-42c7-bfa1-36007fd92e72")]
public interface IFillFormatEffectiveData
{
	FillType FillType { get; }

	Color SolidFillColor { get; }

	IGradientFormatEffectiveData GradientFormat { get; }

	IPatternFormatEffectiveData PatternFormat { get; }

	IPictureFillFormatEffectiveData PictureFillFormat { get; }

	bool RotateWithShape { get; }
}
