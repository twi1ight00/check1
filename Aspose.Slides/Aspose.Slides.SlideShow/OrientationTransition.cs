namespace Aspose.Slides.SlideShow;

public class OrientationTransition : TransitionValueBase, ITransitionValueBase, IOrientationTransition
{
	private Orientation orientation_0;

	public Orientation Direction
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

	ITransitionValueBase IOrientationTransition.AsITransitionValueBase => this;

	internal OrientationTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is OrientationTransition)
		{
			return Equals((OrientationTransition)transition);
		}
		return false;
	}

	internal bool Equals(IOrientationTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		OrientationTransition orientationTransition = (OrientationTransition)transition;
		if (transitionType_0 == orientationTransition.transitionType_0)
		{
			return orientation_0 == orientationTransition.orientation_0;
		}
		return false;
	}
}
