using System.Collections;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("e5dcc028-40e4-4693-83da-f43013063e91")]
public interface ISequence : IEnumerable
{
	int Count { get; }

	IEffect this[int index] { get; }

	IShape TriggerShape { get; set; }

	IEnumerable AsIEnumerable { get; }

	void Remove(IEffect item);

	void RemoveAt(int index);

	void Clear();

	void RemoveByShape(IShape shape);

	IEffect[] GetEffectsByShape(IShape shape);

	int GetCount(IShape shape);

	IEffect AddEffect(IShape shape, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);
}
