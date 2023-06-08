using System;
using ns24;

namespace Aspose.Slides;

public class ThreeDFormat : IPresentationComponent, ISlideComponent, IThreeDFormat
{
	private ISlideComponent islideComponent_0;

	private Class359 class359_0 = new Class359();

	private uint uint_0;

	internal double double_0;

	internal double double_1;

	internal double double_2;

	internal MaterialPresetType materialPresetType_0 = MaterialPresetType.NotDefined;

	internal ShapeBevel shapeBevel_0 = new ShapeBevel(bIsTopBevel: true);

	internal ShapeBevel shapeBevel_1 = new ShapeBevel(bIsTopBevel: false);

	internal ColorFormat colorFormat_0 = new ColorFormat(null);

	internal ColorFormat colorFormat_1 = new ColorFormat(null);

	internal Camera camera_0 = new Camera();

	internal LightRig lightRig_0 = new LightRig();

	internal Class359 PPTXUnsupportedProps => class359_0;

	public double ContourWidth
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			method_2();
		}
	}

	public double ExtrusionHeight
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
			method_2();
		}
	}

	public double Depth
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			method_2();
		}
	}

	public IShapeBevel BevelTop => shapeBevel_0;

	public IShapeBevel BevelBottom => shapeBevel_1;

	public IColorFormat ContourColor => colorFormat_0;

	public IColorFormat ExtrusionColor => colorFormat_1;

	public ICamera Camera => camera_0;

	public ILightRig LightRig => lightRig_0;

	public MaterialPresetType Material
	{
		get
		{
			return materialPresetType_0;
		}
		set
		{
			materialPresetType_0 = value;
			method_2();
		}
	}

	ISlideComponent IThreeDFormat.AsISlideComponent => this;

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	IBaseSlide ISlideComponent.Slide
	{
		get
		{
			if (islideComponent_0 == null)
			{
				return null;
			}
			return islideComponent_0.Slide;
		}
	}

	IPresentation IPresentationComponent.Presentation
	{
		get
		{
			if (islideComponent_0 == null)
			{
				return null;
			}
			return islideComponent_0.Presentation;
		}
	}

	internal uint Version => uint_0 + class359_0.Version + shapeBevel_0.Version + shapeBevel_1.Version + colorFormat_0.Version + colorFormat_1.Version + camera_0.Version + lightRig_0.Version;

	internal ThreeDFormat(ISlideComponent parent)
	{
		islideComponent_0 = parent;
	}

	internal bool method_0(bool shape3d)
	{
		if ((!shape3d || materialPresetType_0 == MaterialPresetType.NotDefined || materialPresetType_0 == MaterialPresetType.WarmMatte) && camera_0.CameraType == CameraPresetType.NotDefined)
		{
			return lightRig_0.LightType != LightRigPresetType.NotDefined;
		}
		return true;
	}

	internal void method_1(ThreeDFormat threeDFormat)
	{
		PPTXUnsupportedProps.method_0(threeDFormat.PPTXUnsupportedProps);
		((Backdrop3DScene)PPTXUnsupportedProps.BackdropPlane).method_0((Backdrop3DScene)threeDFormat.PPTXUnsupportedProps.BackdropPlane);
		camera_0.method_0(threeDFormat.camera_0);
		colorFormat_0.method_0(threeDFormat.colorFormat_0);
		double_0 = threeDFormat.double_0;
		double_2 = threeDFormat.double_2;
		colorFormat_1.method_0(threeDFormat.colorFormat_1);
		double_1 = threeDFormat.double_1;
		lightRig_0.method_0(threeDFormat.lightRig_0);
		materialPresetType_0 = threeDFormat.materialPresetType_0;
		islideComponent_0 = threeDFormat.islideComponent_0;
		shapeBevel_1.method_0(threeDFormat.shapeBevel_1);
		shapeBevel_0.method_0(threeDFormat.shapeBevel_0);
		method_2();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ThreeDFormat threeDFormat))
		{
			return base.Equals(obj);
		}
		if (double_0 == threeDFormat.double_0 && double_1 == threeDFormat.double_1 && double_2 == threeDFormat.double_2 && materialPresetType_0 == threeDFormat.materialPresetType_0 && shapeBevel_0.Equals(threeDFormat.shapeBevel_0) && shapeBevel_1.Equals(threeDFormat.shapeBevel_1) && colorFormat_0.Equals(threeDFormat.colorFormat_0) && colorFormat_1.Equals(threeDFormat.colorFormat_1) && camera_0.Equals(threeDFormat.camera_0))
		{
			return lightRig_0.Equals(threeDFormat.lightRig_0);
		}
		return false;
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}

	private void method_2()
	{
		uint_0++;
	}
}
