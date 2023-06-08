namespace Aspose.Slides.SlideShow;

public class SplitTransition : TransitionValueBase, ITransitionValueBase, ISplitTransition
{
	private TransitionInOutDirectionType transitionInOutDirectionType_0;

	private Orientation orientation_0;

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

	public Orientation Orientation
	{
		get
		{
			return orientation_0;
		}
		set
		{
			orientation_0 = value;
		}
	}

	ITransitionValueBase ISplitTransition.AsITransitionValueBase => this;

	internal SplitTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is SplitTransition)
		{
			return Equals((SplitTransition)transition);
		}
		return false;
	}

	internal bool Equals(ISplitTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		SplitTransition splitTransition = (SplitTransition)transition;
		if (transitionType_0 == splitTransition.transitionType_0 && transitionInOutDirectionType_0 == splitTransition.transitionInOutDirectionType_0)
		{
			return orientation_0 == splitTransition.orientation_0;
		}
		return false;
	}
}
