namespace Aspose.Slides.SlideShow;

public class SideDirectionTransition : TransitionValueBase, ITransitionValueBase, ISideDirectionTransition
{
	private TransitionSideDirectionType transitionSideDirectionType_0;

	public TransitionSideDirectionType Direction
	{
		get
		{
			return transitionSideDirectionType_0;
		}
		set
		{
			transitionSideDirectionType_0 = value;
		}
	}

	ITransitionValueBase ISideDirectionTransition.AsITransitionValueBase => this;

	internal SideDirectionTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is SideDirectionTransition)
		{
			return Equals((SideDirectionTransition)transition);
		}
		return false;
	}

	internal bool Equals(ISideDirectionTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		SideDirectionTransition sideDirectionTransition = (SideDirectionTransition)transition;
		if (transitionType_0 == sideDirectionTransition.transitionType_0)
		{
			return transitionSideDirectionType_0 == sideDirectionTransition.transitionSideDirectionType_0;
		}
		return false;
	}
}
