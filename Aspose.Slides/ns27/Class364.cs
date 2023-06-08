using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;
using ns24;
using ns56;
using ns57;

namespace ns27;

internal class Class364 : Class278
{
	private Enum303 enum303_0;

	private int int_0;

	private Class2304 class2304_0;

	private List<IEffect> list_0 = new List<IEffect>();

	private readonly List<Class2605> list_1 = new List<Class2605>();

	private float float_0;

	private float float_1;

	private float float_2;

	private Class2304 class2304_1;

	private IShape ishape_0;

	private EffectTriggerType effectTriggerType_0;

	private IBehaviorFactory ibehaviorFactory_0;

	public Enum303 SeqType
	{
		get
		{
			return enum303_0;
		}
		set
		{
			enum303_0 = value;
		}
	}

	public int NNodeCounter
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public Class2304 ParLastEffect
	{
		get
		{
			return class2304_0;
		}
		set
		{
			class2304_0 = value;
		}
	}

	public List<IEffect> Effects
	{
		get
		{
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	public float FDelaySum
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public float FDelayEffectLast
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public float FDelayEffect
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public Class2304 ParLastJoint
	{
		get
		{
			return class2304_1;
		}
		set
		{
			class2304_1 = value;
		}
	}

	public IShape ShapeRef
	{
		get
		{
			return ishape_0;
		}
		set
		{
			ishape_0 = value;
		}
	}

	public EffectTriggerType TriggerNew
	{
		get
		{
			return effectTriggerType_0;
		}
		set
		{
			effectTriggerType_0 = value;
		}
	}

	public IBehaviorFactory BehaviorFactory => ibehaviorFactory_0;

	public List<Class2605> VideoObjects => list_1;

	public Class364()
	{
		ibehaviorFactory_0 = new BehaviorFactory();
	}
}
