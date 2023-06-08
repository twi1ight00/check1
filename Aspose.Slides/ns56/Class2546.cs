using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2546
{
	private static readonly Class1151 class1151_0 = new Class1151("isometricBottomDown", "isometricBottomUp", "isometricLeftDown", "isometricLeftUp", "isometricOffAxis1Left", "isometricOffAxis1Right", "isometricOffAxis1Top", "isometricOffAxis2Left", "isometricOffAxis2Right", "isometricOffAxis2Top", "isometricOffAxis3Bottom", "isometricOffAxis3Left", "isometricOffAxis3Right", "isometricOffAxis4Bottom", "isometricOffAxis4Left", "isometricOffAxis4Right", "isometricRightDown", "isometricRightUp", "isometricTopDown", "isometricTopUp", "legacyObliqueBottom", "legacyObliqueBottomLeft", "legacyObliqueBottomRight", "legacyObliqueFront", "legacyObliqueLeft", "legacyObliqueRight", "legacyObliqueTop", "legacyObliqueTopLeft", "legacyObliqueTopRight", "legacyPerspectiveBottom", "legacyPerspectiveBottomLeft", "legacyPerspectiveBottomRight", "legacyPerspectiveFront", "legacyPerspectiveLeft", "legacyPerspectiveRight", "legacyPerspectiveTop", "legacyPerspectiveTopLeft", "legacyPerspectiveTopRight", "obliqueBottom", "obliqueBottomLeft", "obliqueBottomRight", "obliqueLeft", "obliqueRight", "obliqueTop", "obliqueTopLeft", "obliqueTopRight", "orthographicFront", "perspectiveAbove", "perspectiveAboveLeftFacing", "perspectiveAboveRightFacing", "perspectiveBelow", "perspectiveContrastingLeftFacing", "perspectiveContrastingRightFacing", "perspectiveFront", "perspectiveHeroicExtremeLeftFacing", "perspectiveHeroicExtremeRightFacing", "perspectiveHeroicLeftFacing", "perspectiveHeroicRightFacing", "perspectiveLeft", "perspectiveRelaxed", "perspectiveRelaxedModerately", "perspectiveRight");

	public static CameraPresetType smethod_0(string xmlValue)
	{
		return (CameraPresetType)class1151_0[xmlValue];
	}

	public static string smethod_1(CameraPresetType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
