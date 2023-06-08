namespace Aspose.Slides.SlideShow;

public class ShredTransition : TransitionValueBase, ITransitionValueBase, IShredTransition
{
	private TransitionInOutDirectionType transitionInOutDirectionType_0;

	private TransitionShredPattern transitionShredPattern_0;

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

	public TransitionShredPattern Pattern
	{
		get
		{
			return transitionShredPattern_0;
		}
		set
		{
			transitionShredPattern_0 = value;
		}
	}

	ITransitionValueBase IShredTransition.AsITransitionValueBase => this;

	internal ShredTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is ShredTransition)
		{
			return Equals((ShredTransition)transition);
		}
		return false;
	}

	internal bool Equals(IShredTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		ShredTransition shredTransition = (ShredTransition)transition;
		if (transitionType_0 == shredTransition.transitionType_0 && transitionInOutDirectionType_0 == shredTransition.transitionInOutDirectionType_0)
		{
			return transitionShredPattern_0 == shredTransition.transitionShredPattern_0;
		}
		return false;
	}
}
