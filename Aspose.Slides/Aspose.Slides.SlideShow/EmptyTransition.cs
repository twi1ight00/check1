namespace Aspose.Slides.SlideShow;

public class EmptyTransition : TransitionValueBase, ITransitionValueBase, IEmptyTransition
{
	ITransitionValueBase IEmptyTransition.AsITransitionValueBase => this;

	internal EmptyTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is EmptyTransition)
		{
			return Equals((EmptyTransition)transition);
		}
		return false;
	}

	internal bool Equals(IEmptyTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		EmptyTransition emptyTransition = (EmptyTransition)transition;
		return transitionType_0 == emptyTransition.transitionType_0;
	}
}
