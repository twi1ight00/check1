using Aspose.Slides;
using ns63;

namespace ns15;

internal class Class881
{
	internal static void smethod_0(ICustomData customData, Class2727 progTags)
	{
		if (progTags != null)
		{
			CustomData customData2 = (CustomData)customData;
			customData2.PPTUnsupportedProps.UnknownBinaryTags = progTags.UnknownBinaryTags;
			Class880.smethod_0(customData2.Tags, progTags);
		}
	}
}
