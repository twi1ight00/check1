using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("252D8725-1F81-4507-B866-5EC798290221")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class ColorEffect : Behavior, IBehavior, IColorEffect
{
	internal ColorFormat colorFormat_0 = new ColorFormat(null);

	internal ColorFormat colorFormat_1 = new ColorFormat(null);

	internal ColorDirection colorDirection_0;

	internal ColorSpace colorSpace_0;

	internal ColorOffset colorOffset_0 = new ColorOffset();

	public IColorFormat From
	{
		get
		{
			return colorFormat_0;
		}
		set
		{
			colorFormat_0 = (ColorFormat)value;
		}
	}

	public IColorFormat To
	{
		get
		{
			return colorFormat_1;
		}
		set
		{
			colorFormat_1 = (ColorFormat)value;
		}
	}

	public IColorOffset By
	{
		get
		{
			return colorOffset_0;
		}
		set
		{
			colorOffset_0 = (ColorOffset)value;
		}
	}

	public ColorSpace ColorSpace
	{
		get
		{
			return colorSpace_0;
		}
		set
		{
			colorSpace_0 = value;
		}
	}

	public ColorDirection Direction
	{
		get
		{
			return colorDirection_0;
		}
		set
		{
			colorDirection_0 = value;
		}
	}

	IBehavior IColorEffect.AsIBehavior => this;
}
