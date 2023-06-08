using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("CF27B728-1DA1-4424-8E8E-A93C1CC535B4")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class Timing : ITiming
{
	internal float float_0;

	internal float float_1;

	internal bool bool_0;

	internal float float_2 = float.NaN;

	internal float float_3 = 1f;

	internal float float_4 = float.NaN;

	internal EffectRestartType effectRestartType_0 = EffectRestartType.NotDefined;

	internal EffectFillType effectFillType_0 = EffectFillType.NotDefined;

	internal float float_5 = 1f;

	internal float float_6 = float.NaN;

	internal EffectTriggerType effectTriggerType_0;

	public float Accelerate
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

	public float Decelerate
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

	public bool AutoReverse
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

	public float Duration
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

	public float RepeatCount
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public float RepeatDuration
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	public EffectRestartType Restart
	{
		get
		{
			return effectRestartType_0;
		}
		set
		{
			effectRestartType_0 = value;
		}
	}

	public float Speed
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	public float TriggerDelayTime
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	public EffectTriggerType TriggerType
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
}
