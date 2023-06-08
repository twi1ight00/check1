using System;
using System.Collections;
using System.Drawing;

namespace Aspose.Slides;

public class ThreeDFormatEffectiveData : IThreeDFormatEffectiveData, IEffectiveData
{
	private double double_0;

	private double double_1;

	private double double_2;

	private MaterialPresetType materialPresetType_0 = MaterialPresetType.NotDefined;

	private ShapeBevel shapeBevel_0 = new ShapeBevel(bIsTopBevel: true);

	private ShapeBevel shapeBevel_1 = new ShapeBevel(bIsTopBevel: false);

	private Color color_0;

	private Color color_1;

	private BevelColorMode bevelColorMode_0;

	private Camera camera_0 = new Camera();

	private LightRig lightRig_0 = new LightRig();

	private Backdrop3DScene backdrop3DScene_0 = new Backdrop3DScene();

	private bool bool_0;

	private float float_0;

	public double ContourWidth => double_0;

	public double ExtrusionHeight => double_1;

	public double Depth => double_2;

	public IShapeBevelEffectiveData BevelTop
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public IShapeBevelEffectiveData BevelBottom
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public Color ContourColor => color_0;

	public Color ExtrusionColor => color_1;

	public BevelColorMode BevelColorMode => bevelColorMode_0;

	public ICameraEffectiveData Camera
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public ILightRigEffectiveData LightRig
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public MaterialPresetType Material => materialPresetType_0;

	internal ThreeDFormatEffectiveData()
	{
	}

	internal ThreeDFormatEffectiveData(ThreeDFormat format, BaseSlide slide, FloatColor styleColor)
		: this()
	{
		method_0(format, slide, styleColor);
	}

	internal void method_0(ThreeDFormat source, BaseSlide slide, FloatColor styleColor)
	{
		if (source == null)
		{
			return;
		}
		if (!double.IsNaN(source.double_0))
		{
			double_0 = source.double_0;
		}
		if (!double.IsNaN(source.double_1))
		{
			double_1 = source.double_1;
		}
		if (!double.IsNaN(source.double_2))
		{
			double_2 = source.double_2;
		}
		if (source.shapeBevel_0 != null)
		{
			shapeBevel_0.double_1 = source.shapeBevel_0.double_1;
			shapeBevel_0.bevelPresetType_0 = source.shapeBevel_0.bevelPresetType_0;
			shapeBevel_0.double_0 = source.shapeBevel_0.double_0;
		}
		if (source.shapeBevel_1 != null)
		{
			shapeBevel_1.double_1 = source.shapeBevel_1.double_1;
			shapeBevel_1.bevelPresetType_0 = source.shapeBevel_1.bevelPresetType_0;
			shapeBevel_1.double_0 = source.shapeBevel_1.double_0;
		}
		if (source.colorFormat_0 != null)
		{
			color_0 = source.colorFormat_0.method_5(slide, styleColor);
		}
		if (source.colorFormat_1 != null)
		{
			color_1 = source.colorFormat_1.method_5(slide, styleColor);
		}
		if (source.camera_0 != null)
		{
			camera_0.float_2 = source.camera_0.float_2;
			camera_0.CameraType = source.camera_0.cameraPresetType_0;
			camera_0.float_0 = source.camera_0.float_0;
			camera_0.sortedList_0.Clear();
			if (source.camera_0.sortedList_0 != null)
			{
				camera_0.sortedList_0 = (SortedList)source.camera_0.sortedList_0.Clone();
			}
			camera_0.float_1 = source.camera_0.float_1;
		}
		if (source.lightRig_0 != null)
		{
			lightRig_0.float_0 = source.lightRig_0.float_0;
			lightRig_0.lightingDirection_0 = source.lightRig_0.lightingDirection_0;
			lightRig_0.lightRigPresetType_0 = source.lightRig_0.lightRigPresetType_0;
		}
		if (source.materialPresetType_0 != MaterialPresetType.NotDefined)
		{
			materialPresetType_0 = source.materialPresetType_0;
		}
	}
}
