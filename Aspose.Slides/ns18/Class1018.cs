using System.Drawing;
using Aspose.Slides.Animation;
using ns56;

namespace ns18;

internal class Class1018
{
	public static void smethod_0(IScaleEffect scaleEffect, Class2270 scaleBehaviorElementData)
	{
		if (scaleBehaviorElementData.From != null)
		{
			scaleEffect.From = new PointF(scaleBehaviorElementData.From.X, scaleBehaviorElementData.From.Y);
		}
		if (scaleBehaviorElementData.To != null)
		{
			scaleEffect.To = new PointF(scaleBehaviorElementData.To.X, scaleBehaviorElementData.To.Y);
		}
		if (scaleBehaviorElementData.By != null)
		{
			scaleEffect.By = new PointF(scaleBehaviorElementData.By.X, scaleBehaviorElementData.By.Y);
		}
		scaleEffect.ZoomContent = scaleBehaviorElementData.ZoomContents;
	}

	public static void smethod_1(IScaleEffect scaleEffect, Class2605.Delegate2773 addNodeDelegate, ref Class2281 commonBehaviorElementData)
	{
		Class2270 @class = (Class2270)addNodeDelegate("animScale").Object;
		commonBehaviorElementData = @class.CBhvr;
		if (!float.IsNaN(scaleEffect.From.X) && !float.IsNaN(scaleEffect.From.Y))
		{
			Class1008.smethod_8(@class.delegate2623_1, scaleEffect.From);
		}
		if (!float.IsNaN(scaleEffect.To.X) && !float.IsNaN(scaleEffect.To.Y))
		{
			Class1008.smethod_8(@class.delegate2623_2, scaleEffect.To);
		}
		if (!float.IsNaN(scaleEffect.By.X) && !float.IsNaN(scaleEffect.By.Y))
		{
			Class1008.smethod_8(@class.delegate2623_0, scaleEffect.By);
		}
		@class.ZoomContents = scaleEffect.ZoomContent;
	}
}
