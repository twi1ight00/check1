namespace Aspose.Slides.SlideShow;

public class InOutTransition : TransitionValueBase, ITransitionValueBase, IInOutTransition
{
	private TransitionInOutDirectionType transitionInOutDirectionType_0;

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

	ITransitionValueBase IInOutTransition.AsITransitionValueBase => this;

	internal InOutTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is InOutTransition)
		{
			return Equals((InOutTransition)transition);
		}
		return false;
	}

	internal bool Equals(IInOutTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		InOutTransition inOutTransition = (InOutTransition)transition;
		if (transitionType_0 == inOutTransition.transitionType_0)
		{
			return transitionInOutDirectionType_0 == inOutTransition.transitionInOutDirectionType_0;
		}
		return false;
	}
}
