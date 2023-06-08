using Aspose.Slides.Animation;
using ns56;
using ns57;

namespace ns18;

internal class Class1015
{
	public static void smethod_0(IPropertyEffect propertyEffect, Class2265 behaviorElementData)
	{
		propertyEffect.From = behaviorElementData.From;
		propertyEffect.To = behaviorElementData.To;
		propertyEffect.By = behaviorElementData.By;
		propertyEffect.ValueType = (PropertyValueType)behaviorElementData.ValueType;
		propertyEffect.CalcMode = (PropertyCalcModeType)behaviorElementData.Calcmode;
		Class1014.smethod_0(propertyEffect.Points, behaviorElementData.TavLst);
	}

	public static void smethod_1(IPropertyEffect propertyEffect, Class2605.Delegate2773 addNodeDelegate, ref Class2281 commonBehaviorElementData)
	{
		Class2265 @class = (Class2265)addNodeDelegate("anim").Object;
		commonBehaviorElementData = @class.CBhvr;
		@class.From = propertyEffect.From;
		@class.To = propertyEffect.To;
		@class.By = propertyEffect.By;
		@class.ValueType = (Enum379)propertyEffect.ValueType;
		@class.Calcmode = (Enum278)propertyEffect.CalcMode;
		if (propertyEffect.Points.Count != 0)
		{
			Class2300 pointsElementData = @class.delegate2647_0();
			Class1014.smethod_1(propertyEffect.Points, pointsElementData);
		}
	}
}
