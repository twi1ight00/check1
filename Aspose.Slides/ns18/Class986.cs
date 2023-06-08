using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class986
{
	public static void smethod_0(IEightDirectionTransition eightDirectionTransition, Class2233 eightDirectionTransitionElementData)
	{
		if (eightDirectionTransitionElementData != null)
		{
			eightDirectionTransition.Direction = eightDirectionTransitionElementData.Dir;
		}
	}

	public static void smethod_1(IEightDirectionTransition eightDirectionTransition, Class2233 eightDirectionTransitionElementData)
	{
		eightDirectionTransitionElementData.Dir = eightDirectionTransition.Direction;
	}
}
