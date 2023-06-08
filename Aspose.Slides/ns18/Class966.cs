using Aspose.Slides;
using ns56;

namespace ns18;

internal class Class966
{
	public static void smethod_0(ILightRig lightRig, Class1869 lightRigElementData)
	{
		if (lightRigElementData != null)
		{
			lightRig.Direction = lightRigElementData.Dir;
			lightRig.LightType = lightRigElementData.Rig;
			if (lightRigElementData.Rot != null)
			{
				lightRig.SetRotation(lightRigElementData.Rot.Lat, lightRigElementData.Rot.Lon, lightRigElementData.Rot.Rev);
			}
		}
	}

	public static void smethod_1(ILightRig lightRig, Class1869 lightRigElementData)
	{
		if (lightRig.LightType != LightRigPresetType.NotDefined)
		{
			lightRigElementData.Dir = ((lightRig.Direction == LightingDirection.NotDefined) ? LightingDirection.Top : lightRig.Direction);
			lightRigElementData.Rig = ((lightRig.LightType == LightRigPresetType.NotDefined) ? LightRigPresetType.TwoPt : lightRig.LightType);
			float[] rotation = lightRig.GetRotation();
			if (rotation[0] != 0f || rotation[1] != 0f || rotation[2] != 0f)
			{
				Class1925 @class = lightRigElementData.delegate1642_0();
				@class.Lat = rotation[0];
				@class.Lon = rotation[1];
				@class.Rev = rotation[2];
			}
		}
	}
}
