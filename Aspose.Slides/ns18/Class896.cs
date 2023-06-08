using Aspose.Slides;
using ns56;

namespace ns18;

internal class Class896
{
	public static void smethod_0(IBackdrop3DScene backdrop3DScene, Class1802 backdropElementData)
	{
		if (backdropElementData != null)
		{
			backdrop3DScene.AnchorPoint = new float[3]
			{
				(float)backdropElementData.Anchor.X,
				(float)backdropElementData.Anchor.Y,
				(float)backdropElementData.Anchor.Z
			};
			backdrop3DScene.NormalVector = new float[3]
			{
				(float)backdropElementData.Norm.Dx,
				(float)backdropElementData.Norm.Dy,
				(float)backdropElementData.Norm.Dz
			};
			backdrop3DScene.UpVector = new float[3]
			{
				(float)backdropElementData.Up.Dx,
				(float)backdropElementData.Up.Dy,
				(float)backdropElementData.Up.Dz
			};
		}
	}

	public static void smethod_1(IBackdrop3DScene backdrop3DScene, Class1802.Delegate1285 addBackdrop)
	{
		float[] anchorPoint = backdrop3DScene.AnchorPoint;
		float[] normalVector = backdrop3DScene.NormalVector;
		float[] upVector = backdrop3DScene.UpVector;
		if (normalVector[0] != 0f || normalVector[1] != 0f || normalVector[2] != 0f || upVector[0] != 0f || upVector[1] != 0f || upVector[2] != 0f)
		{
			Class1802 @class = addBackdrop();
			@class.Anchor.X = anchorPoint[0];
			@class.Anchor.Y = anchorPoint[1];
			@class.Anchor.Z = anchorPoint[2];
			@class.Norm.Dx = normalVector[0];
			@class.Norm.Dy = normalVector[1];
			@class.Norm.Dz = normalVector[2];
			@class.Up.Dx = upVector[0];
			@class.Up.Dy = upVector[1];
			@class.Up.Dz = upVector[2];
		}
	}
}
