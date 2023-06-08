namespace Aspose.Slides.SlideShow;

public class FlyThroughTransition : TransitionValueBase, ITransitionValueBase, IFlyThroughTransition
{
	private TransitionInOutDirectionType transitionInOutDirectionType_0;

	private bool bool_0;

	public TransitionInOutDirectionType Direction
	{
		get
		{
			return transitionInOutDirectionType_0;
		}
		set
		{
			transitionInOutDirectionType_0 = value;
		}
	}

	public bool HasBounce
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

	ITransitionValueBase IFlyThroughTransition.AsITransitionValueBase => this;

	internal FlyThroughTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is FlyThroughTransition)
		{
			return Equals((FlyThroughTransition)transition);
		}
		return false;
	}

	internal bool Equals(IFlyThroughTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		FlyThroughTransition flyThroughTransition = (FlyThroughTransition)transition;
		if (transitionType_0 == flyThroughTransition.transitionType_0 && transitionInOutDirectionType_0 == flyThroughTransition.transitionInOutDirectionType_0)
		{
			return bool_0 == flyThroughTransition.bool_0;
		}
		return false;
	}
}
