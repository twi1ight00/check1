using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
[Guid("F38C5F58-D358-4903-A1D2-6A4D7DCA9697")]
public class ScaleEffect : Behavior, IBehavior, IScaleEffect
{
	internal PointF pointF_0 = new PointF(float.NaN, float.NaN);

	internal PointF pointF_1 = new PointF(float.NaN, float.NaN);

	internal PointF pointF_2 = new PointF(float.NaN, float.NaN);

	internal NullableBool nullableBool_1 = NullableBool.NotDefined;

	public NullableBool ZoomContent
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			nullableBool_1 = value;
		}
	}

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

	IBehavior IScaleEffect.AsIBehavior => this;
}
