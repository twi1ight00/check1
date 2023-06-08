namespace Aspose.Slides.SlideShow;

public class TransitionValueBase : ITransitionValueBase
{
	internal TransitionType transitionType_0;

	internal TransitionValueBase(TransitionType type)
	{
		transitionType_0 = type;
	}

	public override bool Equals(object obj)
	{
		if (obj is TransitionValueBase)
		{
			return Equals((TransitionValueBase)obj);
		}
		return false;
	}

	internal virtual bool Equals(ITransitionValueBase transition)
	{
		if (transition == null)
		{
			return false;
		}
		TransitionValueBase transitionValueBase = (TransitionValueBase)transition;
		return transitionType_0 == transitionValueBase.transitionType_0;
	}
}
