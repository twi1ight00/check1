using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("D4C36C85-F519-40A1-99B7-07A15FFBB22E")]
public interface IBehaviorFactory
{
	IColorEffect CreateColorEffect();

	ICommandEffect CreateCommandEffect();

	IFilterEffect CreateFilterEffect();

	IMotionEffect CreateMotionEffect();

	IPropertyEffect CreatePropertyEffect();

	IRotationEffect CreateRotationEffect();

	IScaleEffect CreateScaleEffect();

	ISetEffect CreateSetEffect();
}
