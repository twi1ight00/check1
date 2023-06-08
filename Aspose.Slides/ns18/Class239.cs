using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class239
{
	public static void smethod_0(IShredTransition shredTransition, Class1365 shredElementData)
	{
		if (shredElementData != null)
		{
			shredTransition.Direction = shredElementData.Dir;
			shredTransition.Pattern = shredElementData.Pattern;
		}
	}

	public static void smethod_1(IShredTransition shredTransition, Class1365 shredElementData)
	{
		shredElementData.Dir = shredTransition.Direction;
		shredElementData.Pattern = shredTransition.Pattern;
	}
}
