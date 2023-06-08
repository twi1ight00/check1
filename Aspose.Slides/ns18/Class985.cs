using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class985
{
	public static void smethod_0(ICornerDirectionTransition cornerDirectionTransition, Class2230 cornerDirectionTransitionElementData)
	{
		if (cornerDirectionTransitionElementData != null)
		{
			cornerDirectionTransition.Direction = cornerDirectionTransitionElementData.Dir;
		}
	}

	public static void smethod_1(ICornerDirectionTransition cornerDirectionTransition, Class2230 cornerDirectionTransitionElementData)
	{
		cornerDirectionTransitionElementData.Dir = cornerDirectionTransition.Direction;
	}
}
