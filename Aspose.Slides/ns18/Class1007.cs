using Aspose.Slides;
using ns24;
using ns56;

namespace ns18;

internal class Class1007
{
	public static void smethod_0(IThreeDFormat threeDFormat, Class1916 scene3DElementData, Class1919 shape3DElementData, Class1844 flatTextElementData)
	{
		Class359 pPTXUnsupportedProps = ((ThreeDFormat)threeDFormat).PPTXUnsupportedProps;
		if (shape3DElementData != null)
		{
			threeDFormat.ContourWidth = shape3DElementData.ContourW;
			threeDFormat.ExtrusionHeight = shape3DElementData.ExtrusionH;
			threeDFormat.Depth = shape3DElementData.Z;
			threeDFormat.Material = shape3DElementData.PrstMaterial;
			Class982.smethod_0(threeDFormat.BevelTop, shape3DElementData.BevelT);
			Class982.smethod_0(threeDFormat.BevelBottom, shape3DElementData.BevelB);
			Class930.smethod_0(threeDFormat.ContourColor, shape3DElementData.ContourClr);
			Class930.smethod_0(threeDFormat.ExtrusionColor, shape3DElementData.ExtrusionClr);
		}
		if (scene3DElementData != null)
		{
			Class901.smethod_0(threeDFormat.Camera, scene3DElementData.Camera);
			Class966.smethod_0(threeDFormat.LightRig, scene3DElementData.LightRig);
			Class896.smethod_0(pPTXUnsupportedProps.BackdropPlane, scene3DElementData.Backdrop);
		}
		pPTXUnsupportedProps.FlatText = false;
		if (flatTextElementData != null)
		{
			pPTXUnsupportedProps.FlatText = true;
			pPTXUnsupportedProps.FlatTextZCoordinate = (float)flatTextElementData.Z;
		}
	}

	public static void smethod_1(IThreeDFormat threeDFormat, Class1916.Delegate1615 addScene3d, Class1919.Delegate1624 addShape3D, Class1844.Delegate1411 addFlatTx)
	{
		if (threeDFormat != null)
		{
			Class359 pPTXUnsupportedProps = ((ThreeDFormat)threeDFormat).PPTXUnsupportedProps;
			if (threeDFormat.Camera.CameraType != CameraPresetType.NotDefined || threeDFormat.LightRig.LightType != LightRigPresetType.NotDefined)
			{
				Class1916 @class = addScene3d();
				Class901.smethod_1(threeDFormat.Camera, @class.Camera);
				Class966.smethod_1(threeDFormat.LightRig, @class.LightRig);
				Class896.smethod_1(pPTXUnsupportedProps.BackdropPlane, @class.delegate1285_0);
			}
			if ((threeDFormat.Material != MaterialPresetType.NotDefined && threeDFormat.Material != MaterialPresetType.WarmMatte) || threeDFormat.ContourWidth != 0.0 || threeDFormat.ExtrusionHeight != 0.0 || threeDFormat.BevelTop.BevelType != BevelPresetType.NotDefined || threeDFormat.BevelBottom.BevelType != BevelPresetType.NotDefined)
			{
				Class1919 class2 = addShape3D();
				class2.ContourW = threeDFormat.ContourWidth;
				class2.ExtrusionH = threeDFormat.ExtrusionHeight;
				class2.Z = threeDFormat.Depth;
				class2.PrstMaterial = ((threeDFormat.Material == MaterialPresetType.NotDefined) ? MaterialPresetType.WarmMatte : threeDFormat.Material);
				Class982.smethod_1(threeDFormat.BevelTop, class2.delegate1297_0);
				Class982.smethod_1(threeDFormat.BevelBottom, class2.delegate1297_1);
				Class930.smethod_2(threeDFormat.ExtrusionColor, class2.delegate1321_0);
				Class930.smethod_2(threeDFormat.ContourColor, class2.delegate1321_1);
			}
			if (pPTXUnsupportedProps.FlatText)
			{
				Class1844 class3 = addFlatTx();
				class3.Z = pPTXUnsupportedProps.FlatTextZCoordinate;
			}
		}
	}

	internal static bool smethod_2(IThreeDFormat threeDFormat, bool shape3d)
	{
		Class359 pPTXUnsupportedProps = ((ThreeDFormat)threeDFormat).PPTXUnsupportedProps;
		if ((!shape3d || threeDFormat.Material == MaterialPresetType.NotDefined || threeDFormat.Material == MaterialPresetType.WarmMatte) && threeDFormat.Camera.CameraType == CameraPresetType.NotDefined && threeDFormat.LightRig.LightType == LightRigPresetType.NotDefined)
		{
			return pPTXUnsupportedProps.FlatText;
		}
		return true;
	}
}
