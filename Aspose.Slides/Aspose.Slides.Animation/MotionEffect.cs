using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("3F39AAD1-65AD-4B2D-8584-E836994C7389")]
public class MotionEffect : Behavior, IBehavior, IMotionEffect
{
	internal PointF pointF_0 = new PointF(float.NaN, float.NaN);

	internal PointF pointF_1 = new PointF(float.NaN, float.NaN);

	internal PointF pointF_2 = new PointF(float.NaN, float.NaN);

	internal PointF pointF_3 = new PointF(float.NaN, float.NaN);

	internal MotionOriginType motionOriginType_0;

	internal MotionPath motionPath_0;

	internal MotionPathEditMode motionPathEditMode_0;

	internal float float_0;

	public PointF From
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	public PointF To
	{
		get
		{
			return pointF_1;
		}
		set
		{
			pointF_1 = value;
		}
	}

	public PointF By
	{
		get
		{
			return pointF_2;
		}
		set
		{
			pointF_2 = value;
		}
	}

	public PointF RotationCenter
	{
		get
		{
			return pointF_3;
		}
		set
		{
			pointF_3 = value;
		}
	}

	public MotionOriginType Origin
	{
		get
		{
			return motionOriginType_0;
		}
		set
		{
			motionOriginType_0 = value;
		}
	}

	public IMotionPath Path
	{
		get
		{
			return motionPath_0;
		}
		set
		{
			motionPath_0 = (MotionPath)value;
		}
	}

	public MotionPathEditMode PathEditMode
	{
		get
		{
			return motionPathEditMode_0;
		}
		set
		{
			motionPathEditMode_0 = value;
		}
	}

	public float Angle
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	IBehavior IMotionEffect.AsIBehavior => this;
}
