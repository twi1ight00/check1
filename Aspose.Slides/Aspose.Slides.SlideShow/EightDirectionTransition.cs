namespace Aspose.Slides.SlideShow;

public class EightDirectionTransition : TransitionValueBase, ITransitionValueBase, IEightDirectionTransition
{
	private TransitionEightDirectionType transitionEightDirectionType_0;

	public TransitionEightDirectionType Direction
	{
		get
		{
			return transitionEightDirectionType_0;
		}
		set
		{
			transitionEightDirectionType_0 = value;
		}
	}

	ITransitionValueBase IEightDirectionTransition.AsITransitionValueBase => this;

	internal EightDirectionTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is EightDirectionTransition)
		{
			return Equals((EightDirectionTransition)transition);
		}
		return false;
	}

	internal bool Equals(IEightDirectionTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		EightDirectionTransition eightDirectionTransition = (EightDirectionTransition)transition;
		if (transitionType_0 == eightDirectionTransition.transitionType_0)
		{
			return transitionEightDirectionType_0 == eightDirectionTransition.transitionEightDirectionType_0;
		}
		return false;
	}
}
