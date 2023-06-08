using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[Guid("6aebdca4-ec10-4849-a7ca-8c29143a5664")]
[ComVisible(true)]
public interface IOuterShadow
{
	double BlurRadius { get; set; }

	float Direction { get; set; }

	double Distance { get; set; }

	IColorFormat ShadowColor { get; }

	RectangleAlignment RectangleAlign { get; set; }

	double SkewHorizontal { get; set; }

	double SkewVertical { get; set; }

	bool RotateShadowWithShape { get; set; }

	double ScaleHorizontal { get; set; }

	double ScaleVertical { get; set; }
}
