namespace Aspose.Slides.SlideShow;

public class OptionalBlackTransition : TransitionValueBase, ITransitionValueBase, IOptionalBlackTransition
{
	private bool bool_0;

	public bool FromBlack
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	ITransitionValueBase IOptionalBlackTransition.AsITransitionValueBase => this;

	internal OptionalBlackTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is OptionalBlackTransition)
		{
			return Equals((OptionalBlackTransition)transition);
		}
		return false;
	}

	internal bool Equals(IOptionalBlackTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		OptionalBlackTransition optionalBlackTransition = (OptionalBlackTransition)transition;
		if (transitionType_0 == optionalBlackTransition.transitionType_0)
		{
			return bool_0 == optionalBlackTransition.bool_0;
		}
		return false;
	}
}
