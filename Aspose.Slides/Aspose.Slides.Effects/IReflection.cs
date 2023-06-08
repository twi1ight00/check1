using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("f48bb311-1dd5-4849-8118-9d876338f3f4")]
public interface IReflection
{
	float StartPosAlpha { get; set; }

	float EndPosAlpha { get; set; }

	float FadeDirection { get; set; }

	float StartReflectionOpacity { get; set; }

	float EndReflectionOpacity { get; set; }

	double BlurRadius { get; set; }

	float Direction { get; set; }

	double Distance { get; set; }

	RectangleAlignment RectangleAlign { get; set; }

	double SkewHorizontal { get; set; }

	double SkewVertical { get; set; }

	bool RotateShadowWithShape { get; set; }

	double ScaleHorizontal { get; set; }

	double ScaleVertical { get; set; }
}
