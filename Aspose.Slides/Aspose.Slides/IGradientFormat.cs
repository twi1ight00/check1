using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("1cc48ece-7467-4f7b-a6fc-42b5917ff928")]
[ComVisible(true)]
public interface IGradientFormat : IFillParamSource
{
	TileFlip TileFlip { get; set; }

	GradientDirection GradientDirection { get; set; }

	float LinearGradientAngle { get; set; }

	NullableBool LinearGradientScaled { get; set; }

	GradientShape GradientShape { get; set; }

	IGradientStopCollection GradientStops { get; }

	IFillParamSource AsIFillParamSource { get; }
}
