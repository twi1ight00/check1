using Aspose.Slides.Animation;
using ns16;
using ns27;
using ns56;
using ns57;

namespace ns18;

internal class Class1012
{
	public static void smethod_0(ICommandEffect commandEffect, Class2280 commandBehaviorElementData, Class233 timelineDeserializationContext)
	{
		Class361 pPTXUnsupportedProps = ((CommandEffect)commandEffect).PPTXUnsupportedProps;
		commandEffect.CommandString = commandBehaviorElementData.Cmd;
		commandEffect.Type = (CommandEffectType)commandBehaviorElementData.Type;
		pPTXUnsupportedProps.Duration = Class1008.smethod_7(commandBehaviorElementData.CBhvr.CTn.Dur);
		pPTXUnsupportedProps.Fill = commandBehaviorElementData.CBhvr.CTn.Fill;
		commandEffect.ShapeTarget = Class1019.smethod_5(timelineDeserializationContext, commandBehaviorElementData.CBhvr.TgtEl);
	}

	public static void smethod_1(ICommandEffect commandEffect, Class2605.Delegate2773 addNodeDelegate, ref Class2281 commonBehaviorElementData)
	{
		Class2280 @class = (Class2280)addNodeDelegate("cmd").Object;
		commonBehaviorElementData = @class.CBhvr;
		_ = ((CommandEffect)commandEffect).PPTXUnsupportedProps;
		@class.Type = (Enum288)commandEffect.Type;
		@class.Cmd = commandEffect.CommandString;
	}
}
