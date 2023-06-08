using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("1a8b3fc0-d594-4627-8035-962a494d520d")]
public interface IReflectionEffectiveData
{
	float StartPosAlpha { get; }

	float EndPosAlpha { get; }

	float FadeDirection { get; }

	float StartReflectionOpacity { get; }

	float EndReflectionOpacity { get; }

	double BlurRadius { get; }

	float Direction { get; }

	double Distance { get; }

	RectangleAlignment RectangleAlign { get; }

	double SkewHorizontal { get; }

	double SkewVertical { get; }

	bool RotateShadowWithShape { get; }

	double ScaleHorizontal { get; }

	double ScaleVertical { get; }
}
