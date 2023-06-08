using Aspose.Slides;
using ns62;

namespace ns15;

internal class Class1047
{
	internal static void smethod_0(Background background, Class2670 shapeContainer, Class854 slideDeserializationContext)
	{
		background.Type = BackgroundType.OwnBackground;
		Class1052.smethod_0(background.fillFormat_0, shapeContainer, slideDeserializationContext);
		if (shapeContainer.ClientData != null)
		{
			Class881.smethod_0(background.PPTUnsupportedProps.CustomDataInternal, shapeContainer.ClientData.ProgTags);
		}
	}
}
