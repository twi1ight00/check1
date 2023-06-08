using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[Guid("72c427ce-7d32-4fbe-81b4-e6d97678c778")]
[ComVisible(true)]
public interface IOuterShadowEffectiveData
{
	double BlurRadius { get; }

	float Direction { get; }

	double Distance { get; }

	Color ShadowColor { get; }

	RectangleAlignment RectangleAlign { get; }

	double SkewHorizontal { get; }

	double SkewVertical { get; }

	bool RotateShadowWithShape { get; }

	double ScaleHorizontal { get; }

	double ScaleVertical { get; }
}
