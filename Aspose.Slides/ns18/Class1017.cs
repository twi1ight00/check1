using Aspose.Slides.Animation;
using ns56;

namespace ns18;

internal class Class1017
{
	public static void smethod_0(IRotationEffect rotationEffect, Class2269 rotationBehaviorElementData)
	{
		rotationEffect.From = rotationBehaviorElementData.From;
		rotationEffect.To = rotationBehaviorElementData.To;
		rotationEffect.By = rotationBehaviorElementData.By;
	}

	public static void smethod_1(IRotationEffect rotationEffect, Class2605.Delegate2773 addNodeDelegate, ref Class2281 commonBehaviorElementData)
	{
		Class2269 @class = (Class2269)addNodeDelegate("animRot").Object;
		commonBehaviorElementData = @class.CBhvr;
		@class.From = rotationEffect.From;
		@class.To = rotationEffect.To;
		@class.By = rotationEffect.By;
	}
}
