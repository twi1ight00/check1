namespace Aspose.Slides.SlideShow;

public class LeftRightDirectionTransition : TransitionValueBase, ITransitionValueBase, ILeftRightDirectionTransition
{
	private TransitionLeftRightDirectionType transitionLeftRightDirectionType_0;

	public TransitionLeftRightDirectionType Direction
	{
		get
		{
			return transitionLeftRightDirectionType_0;
		}
		set
		{
			transitionLeftRightDirectionType_0 = value;
		}
	}

	ITransitionValueBase ILeftRightDirectionTransition.AsITransitionValueBase => this;

	internal LeftRightDirectionTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is LeftRightDirectionTransition)
		{
			return Equals((LeftRightDirectionTransition)transition);
		}
		return false;
	}

	internal bool Equals(ILeftRightDirectionTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		LeftRightDirectionTransition leftRightDirectionTransition = (LeftRightDirectionTransition)transition;
		if (transitionType_0 == leftRightDirectionTransition.transitionType_0)
		{
			return transitionLeftRightDirectionType_0 == leftRightDirectionTransition.transitionLeftRightDirectionType_0;
		}
		return false;
	}
}
