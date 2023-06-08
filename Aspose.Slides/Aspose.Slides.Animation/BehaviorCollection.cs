using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides.Animation;

public class BehaviorCollection : IEnumerable, IEnumerable<IBehavior>, IBehaviorCollection
{
	private readonly List<IBehavior> list_0 = new List<IBehavior>();

	internal Effect effect_0;

	public int Count => list_0.Count;

	public bool IsReadOnly => ((ICollection<IBehavior>)list_0).IsReadOnly;

	public IBehavior this[int index]
	{
		get
		{
			return list_0[index];
		}
		set
		{
			list_0[index] = value;
		}
	}

	IEnumerable IBehaviorCollection.AsIEnumerable => this;

	internal BehaviorCollection()
	{
	}

	public void Add(IBehavior item)
	{
		((Behavior)item).PPTXUnsupportedProps.ParentEffect = effect_0;
		list_0.Add(item);
	}

	public int IndexOf(IBehavior item)
	{
		return list_0.IndexOf(item);
	}

	public void Insert(int index, IBehavior item)
	{
		((Behavior)item).PPTXUnsupportedProps.ParentEffect = effect_0;
		list_0.Insert(index, item);
	}

	public void CopyTo(IBehavior[] array, int arrayIndex)
	{
		list_0.CopyTo(array, arrayIndex);
	}

	public bool Remove(IBehavior item)
	{
		return list_0.Remove(item);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public void Clear()
	{
		list_0.Clear();
	}

	public bool Contains(IBehavior item)
	{
		return list_0.Contains(item);
	}

	IEnumerator<IBehavior> IEnumerable<IBehavior>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
