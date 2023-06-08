using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("1d0702a7-e7b3-438f-88ef-f792e92086a1")]
[ComVisible(true)]
public interface IGradientFormatEffectiveData
{
	TileFlip TileFlip { get; }

	GradientDirection GradientDirection { get; }

	float LinearGradientAngle { get; }

	bool LinearGradientScaled { get; }

	GradientShape GradientShape { get; }

	IGradientStopCollectionEffectiveData GradientStops { get; }
}
