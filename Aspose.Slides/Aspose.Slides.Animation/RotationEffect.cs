using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("83C5425F-6F22-41A2-B8C9-95A46C00162F")]
[ClassInterface(ClassInterfaceType.None)]
public class RotationEffect : Behavior, IBehavior, IRotationEffect
{
	internal float float_0 = float.NaN;

	internal float float_1 = float.NaN;

	internal float float_2 = float.NaN;

	public float From
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

	public float To
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public float By
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	IBehavior IRotationEffect.AsIBehavior => this;
}
