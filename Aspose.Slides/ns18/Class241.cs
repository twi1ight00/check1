using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class241
{
	public static void smethod_0(IGlitterTransition glitterTransition, Class1359 glitterTransitionElementData)
	{
		if (glitterTransitionElementData != null)
		{
			glitterTransition.Direction = glitterTransitionElementData.Dir;
			glitterTransition.Pattern = glitterTransitionElementData.Pattern;
		}
	}

	public static void smethod_1(IGlitterTransition glitterTransition, Class1359 glitterTransitionElementData)
	{
		glitterTransitionElementData.Dir = glitterTransition.Direction;
		glitterTransitionElementData.Pattern = glitterTransition.Pattern;
	}
}
