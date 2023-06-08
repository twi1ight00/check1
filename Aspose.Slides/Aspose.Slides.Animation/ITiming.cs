using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("2df4dbc3-f981-4e75-8608-f014384110f7")]
public interface ITiming
{
	float Accelerate { get; set; }

	float Decelerate { get; set; }

	bool AutoReverse { get; set; }

	float Duration { get; set; }

	float RepeatCount { get; set; }

	float RepeatDuration { get; set; }

	EffectRestartType Restart { get; set; }

	float Speed { get; set; }

	float TriggerDelayTime { get; set; }

	EffectTriggerType TriggerType { get; set; }
}
