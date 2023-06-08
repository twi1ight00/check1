using Aspose.Slides.Effects;
using ns56;

namespace ns18;

internal class Class941
{
	public static void smethod_0(IGlow glow, Class1852 glowEffectElementData)
	{
		if (glowEffectElementData != null)
		{
			Class930.smethod_1(glow.Color, glowEffectElementData.Color);
			glow.Radius = glowEffectElementData.Rad;
		}
	}

	public static void smethod_1(IGlow glow, Class1852.Delegate1435 addGlow)
	{
		if (glow != null)
		{
			Class1852 @class = addGlow();
			Class930.smethod_4(glow.Color, @class.delegate2773_0);
			@class.Rad = glow.Radius;
		}
	}
}
