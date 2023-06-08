using System.Collections;
using System.Collections.Generic;
using ns57;

namespace Aspose.Slides.Animation;

public class SequenceCollection : IEnumerable, IEnumerable<ISequence>, ISequenceCollection
{
	private readonly List<ISequence> list_0 = new List<ISequence>();

	internal AnimationTimeLine animationTimeLine_0;

	public int Count => list_0.Count;

	public ISequence this[int index] => list_0[index];

	IEnumerable ISequenceCollection.AsIEnumerable => this;

	internal SequenceCollection(AnimationTimeLine tl)
	{
		animationTimeLine_0 = tl;
	}

	public ISequence Add(IShape shapeTrigger)
	{
		Sequence sequence = new Sequence(animationTimeLine_0);
		sequence.TriggerShape = shapeTrigger;
		sequence.PPTXUnsupportedProps.SeqType = Enum303.const_5;
		list_0.Add(sequence);
		return sequence;
	}

	internal ISequence Insert(int index, IShape shapeTrigger)
	{
		Sequence sequence = new Sequence(animationTimeLine_0);
		sequence.TriggerShape = shapeTrigger;
		sequence.PPTXUnsupportedProps.SeqType = Enum303.const_5;
		list_0.Insert(index, sequence);
		return sequence;
	}

	public void Remove(ISequence item)
	{
		list_0.Remove(item);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public void Clear()
	{
		list_0.Clear();
	}

	IEnumerator<ISequence> IEnumerable<ISequence>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
