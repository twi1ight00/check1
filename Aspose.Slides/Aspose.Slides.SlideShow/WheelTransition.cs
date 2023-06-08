namespace Aspose.Slides.SlideShow;

public class WheelTransition : TransitionValueBase, ITransitionValueBase, IWheelTransition
{
	private uint uint_0;

	public uint Spokes
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	ITransitionValueBase IWheelTransition.AsITransitionValueBase => this;

	internal WheelTransition(TransitionType type)
		: base(type)
	{
	}

	internal override bool Equals(ITransitionValueBase transition)
	{
		if (transition is WheelTransition)
		{
			return Equals((WheelTransition)transition);
		}
		return false;
	}

	internal bool Equals(IWheelTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		WheelTransition wheelTransition = (WheelTransition)transition;
		if (transitionType_0 == wheelTransition.transitionType_0)
		{
			return uint_0 == wheelTransition.uint_0;
		}
		return false;
	}
}
