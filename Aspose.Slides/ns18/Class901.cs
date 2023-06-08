using Aspose.Slides;
using ns56;

namespace ns18;

internal class Class901
{
	public static void smethod_0(ICamera camera, Class1812 cameraElementData)
	{
		if (cameraElementData != null)
		{
			camera.CameraType = cameraElementData.Prst;
			camera.Zoom = cameraElementData.Zoom;
			camera.FieldOfViewAngle = cameraElementData.Fov;
			if (cameraElementData.Rot != null)
			{
				camera.SetRotation(cameraElementData.Rot.Lat, cameraElementData.Rot.Lon, cameraElementData.Rot.Rev);
			}
		}
	}

	public static void smethod_1(ICamera camera, Class1812 cameraElementData)
	{
		if (camera.CameraType != CameraPresetType.NotDefined)
		{
			cameraElementData.Prst = camera.CameraType;
			cameraElementData.Zoom = camera.Zoom;
			cameraElementData.Fov = camera.FieldOfViewAngle;
			float[] rotation = camera.GetRotation();
			if (rotation != null)
			{
				Class1925 @class = cameraElementData.delegate1642_0();
				@class.Lat = rotation[0];
				@class.Lon = rotation[1];
				@class.Rev = rotation[2];
			}
		}
	}
}
