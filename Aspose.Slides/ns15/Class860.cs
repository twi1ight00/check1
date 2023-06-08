using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns62;

namespace ns15;

internal class Class860
{
	internal static void smethod_0(IBackdrop3DScene backdrop3DScene, Class2834 fopt, Class2837 tertiaryFopt)
	{
	}

	internal static void smethod_1(IBackdrop3DScene backdrop3DScene, Class2834 fopt, Class2837 tertiaryFopt, Class856 serializationContext)
	{
		_ = backdrop3DScene.AnchorPoint;
		float[] normalVector = backdrop3DScene.NormalVector;
		float[] upVector = backdrop3DScene.UpVector;
		if (normalVector[0] != 0f || normalVector[1] != 0f || normalVector[2] != 0f || upVector[0] != 0f || upVector[1] != 0f || upVector[2] != 0f)
		{
			serializationContext.method_15("Serialization of the Backdrop3DScene is not imlemented yet.", WarningType.MajorFormattingLoss);
		}
	}
}
