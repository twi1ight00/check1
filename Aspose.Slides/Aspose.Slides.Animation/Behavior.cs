using ns27;

namespace Aspose.Slides.Animation;

public abstract class Behavior : IBehavior
{
	internal NullableBool nullableBool_0 = NullableBool.NotDefined;

	internal BehaviorAdditiveType behaviorAdditiveType_0 = BehaviorAdditiveType.NotDefined;

	internal BehaviorProperties behaviorProperties_0 = new BehaviorProperties();

	internal ITiming itiming_0 = new Timing();

	private Class360 class360_0;

	internal Class360 PPTXUnsupportedProps => class360_0;

	public NullableBool Accumulate
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			nullableBool_0 = value;
		}
	}

	public BehaviorAdditiveType Additive
	{
		get
		{
			return behaviorAdditiveType_0;
		}
		set
		{
			behaviorAdditiveType_0 = value;
		}
	}

	public IBehaviorProperties Properties => behaviorProperties_0;

	public ITiming Timing
	{
		get
		{
			return itiming_0;
		}
		set
		{
			itiming_0 = value;
		}
	}

	protected Behavior()
	{
		class360_0 = new Class360();
	}

	internal Behavior(Class360 pptxUnsupportedProps)
	{
		class360_0 = pptxUnsupportedProps;
	}
}
