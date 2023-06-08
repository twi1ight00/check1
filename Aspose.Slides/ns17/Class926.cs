using Aspose.Slides.Charts;
using ns25;
using ns56;

namespace ns17;

internal class Class926
{
	public static void smethod_0(IChart chart, Class2138 view3DElementData)
	{
		if (view3DElementData != null)
		{
			IRotation3D rotation3D = chart.Rotation3D;
			if (view3DElementData.RotX != null)
			{
				rotation3D.RotationX = view3DElementData.RotX.Val;
			}
			if (view3DElementData.RotY != null)
			{
				rotation3D.RotationY = view3DElementData.RotY.Val;
			}
			if (view3DElementData.HPercent != null)
			{
				rotation3D.HeightPercents = view3DElementData.HPercent.Val;
			}
			if (view3DElementData.DepthPercent != null)
			{
				rotation3D.DepthPercents = view3DElementData.DepthPercent.Val;
			}
			if (view3DElementData.RAngAx != null)
			{
				rotation3D.RightAngleAxes = view3DElementData.RAngAx.Val;
			}
			if (view3DElementData.Perspective != null)
			{
				rotation3D.Perspective = view3DElementData.Perspective.Val;
			}
			smethod_1(rotation3D, view3DElementData);
		}
	}

	private static void smethod_1(IRotation3D rotation3D, Class2138 view3DElementData)
	{
		Class326 pPTXUnsupportedProps = ((Rotation3D)rotation3D).PPTXUnsupportedProps;
		pPTXUnsupportedProps.ExtensionList = view3DElementData.ExtLst;
	}

	public static void smethod_2(IRotation3D rotation3D, Class2138.Delegate2146 addView3D)
	{
		if (smethod_4(rotation3D))
		{
			Class2138 @class = addView3D();
			@class.delegate2051_0().Val = rotation3D.RotationX;
			@class.delegate2054_0().Val = rotation3D.RotationY;
			if (rotation3D.HeightPercents != 100)
			{
				@class.delegate1952_0().Val = rotation3D.HeightPercents;
			}
			if (rotation3D.DepthPercents != 100)
			{
				@class.delegate1902_0().Val = rotation3D.DepthPercents;
			}
			@class.delegate2763_0().Val = rotation3D.RightAngleAxes;
			@class.delegate2034_0().Val = rotation3D.Perspective;
			smethod_3(rotation3D, @class);
		}
	}

	private static void smethod_3(IRotation3D rotation3D, Class2138 view3DElementData)
	{
		Class326 pPTXUnsupportedProps = ((Rotation3D)rotation3D).PPTXUnsupportedProps;
		view3DElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}

	internal static bool smethod_4(IRotation3D rotation3D)
	{
		Class326 pPTXUnsupportedProps = ((Rotation3D)rotation3D).PPTXUnsupportedProps;
		if (rotation3D.HeightPercents == 100 && rotation3D.DepthPercents == 100 && !rotation3D.RightAngleAxes && rotation3D.Perspective == 30)
		{
			return pPTXUnsupportedProps.ExtensionList != null;
		}
		return true;
	}
}
