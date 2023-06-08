namespace Aspose.Slides.SlideShow;

public class CornerDirectionTransition : TransitionValueBase, ITransitionValueBase, ICornerDirectionTransition
{
	private TransitionCornerDirectionType transitionCornerDirectionType_0;

	public TransitionCornerDirectionType Direction
	{
		get
		{
			return transitionCornerDirectionType_0;
		}
		set
		{
			transitionCornerDirectionType_0 = value;
		}
	}

	ITransitionValueBase ICornerDirectionTransition.AsITransitionValueBase => this;

	internal CornerDirectionTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is CornerDirectionTransition)
		{
			return Equals((CornerDirectionTransition)transition);
		}
		return false;
	}

	internal bool Equals(ICornerDirectionTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		CornerDirectionTransition cornerDirectionTransition = (CornerDirectionTransition)transition;
		if (transitionType_0 == cornerDirectionTransition.transitionType_0)
		{
			return transitionCornerDirectionType_0 == cornerDirectionTransition.transitionCornerDirectionType_0;
		}
		return false;
	}
}
