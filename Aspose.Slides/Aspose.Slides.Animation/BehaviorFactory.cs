using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("ECF922F5-8512-493E-AF56-750D2E443E2D")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class BehaviorFactory : IBehaviorFactory
{
	public IColorEffect CreateColorEffect()
	{
		return new ColorEffect();
	}

	public ICommandEffect CreateCommandEffect()
	{
		return new CommandEffect();
	}

	public IFilterEffect CreateFilterEffect()
	{
		return new FilterEffect();
	}

	public IMotionEffect CreateMotionEffect()
	{
		return new MotionEffect();
	}

	public IPropertyEffect CreatePropertyEffect()
	{
		return new PropertyEffect();
	}

	public IRotationEffect CreateRotationEffect()
	{
		return new RotationEffect();
	}

	public IScaleEffect CreateScaleEffect()
	{
		return new ScaleEffect();
	}

	public ISetEffect CreateSetEffect()
	{
		return new SetEffect();
	}
}
