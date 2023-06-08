using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class993
{
	public static void smethod_0(IWheelTransition wheelTransition, Class2311 wheelElementData)
	{
		if (wheelElementData != null)
		{
			wheelTransition.Spokes = wheelElementData.Spokes;
		}
	}

	public static void smethod_1(IWheelTransition wheelTransition, Class2311 wheelElementData)
	{
		wheelElementData.Spokes = wheelTransition.Spokes;
	}
}
