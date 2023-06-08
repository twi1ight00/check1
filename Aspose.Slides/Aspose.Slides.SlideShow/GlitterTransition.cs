namespace Aspose.Slides.SlideShow;

public class GlitterTransition : TransitionValueBase, ITransitionValueBase, IGlitterTransition
{
	private TransitionSideDirectionType transitionSideDirectionType_0;

	private TransitionPattern transitionPattern_0;

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

	public TransitionPattern Pattern
	{
		get
		{
			return transitionPattern_0;
		}
		set
		{
			transitionPattern_0 = value;
		}
	}

	ITransitionValueBase IGlitterTransition.AsITransitionValueBase => this;

	internal GlitterTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is GlitterTransition)
		{
			return Equals((GlitterTransition)transition);
		}
		return false;
	}

	internal bool Equals(IGlitterTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		GlitterTransition glitterTransition = (GlitterTransition)transition;
		if (transitionType_0 == glitterTransition.transitionType_0 && transitionSideDirectionType_0 == glitterTransition.transitionSideDirectionType_0)
		{
			return transitionPattern_0 == glitterTransition.transitionPattern_0;
		}
		return false;
	}
}
