namespace Aspose.Slides.SlideShow;

public class RippleTransition : TransitionValueBase, ITransitionValueBase, IRippleTransition
{
	private TransitionCornerAndCenterDirectionType transitionCornerAndCenterDirectionType_0;

	public TransitionCornerAndCenterDirectionType Direction
	{
		get
		{
			return transitionCornerAndCenterDirectionType_0;
		}
		set
		{
			transitionCornerAndCenterDirectionType_0 = value;
		}
	}

	ITransitionValueBase IRippleTransition.AsITransitionValueBase => this;

	internal RippleTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is RippleTransition)
		{
			return Equals((RippleTransition)transition);
		}
		return false;
	}

	internal bool Equals(IRippleTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		RippleTransition rippleTransition = (RippleTransition)transition;
		if (transitionType_0 == rippleTransition.transitionType_0)
		{
			return transitionCornerAndCenterDirectionType_0 == rippleTransition.transitionCornerAndCenterDirectionType_0;
		}
		return false;
	}
}
