namespace Aspose.Slides.SlideShow;

public class RevealTransition : TransitionValueBase, ITransitionValueBase, IRevealTransition
{
	private TransitionLeftRightDirectionType transitionLeftRightDirectionType_0;

	private bool bool_0;

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

	public bool ThroughBlack
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

	ITransitionValueBase IRevealTransition.AsITransitionValueBase => this;

	internal RevealTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is RevealTransition)
		{
			return Equals((RevealTransition)transition);
		}
		return false;
	}

	internal bool Equals(IRevealTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		RevealTransition revealTransition = (RevealTransition)transition;
		if (transitionType_0 == revealTransition.transitionType_0 && transitionLeftRightDirectionType_0 == revealTransition.transitionLeftRightDirectionType_0)
		{
			return bool_0 == revealTransition.bool_0;
		}
		return false;
	}
}
