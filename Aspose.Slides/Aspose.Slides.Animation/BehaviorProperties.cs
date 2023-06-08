using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides.Animation;

public class BehaviorProperties : IEnumerable, IList<PropertyType>, ICollection<PropertyType>, IEnumerable<PropertyType>, IBehaviorProperties
{
	private readonly List<PropertyType> list_0 = new List<PropertyType>();

	public int Count => list_0.Count;

	public bool IsReadOnly => ((ICollection<PropertyType>)list_0).IsReadOnly;

	public PropertyType this[int index]
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

	IEnumerable IBehaviorProperties.AsIEnumerable => this;

	internal BehaviorProperties()
	{
	}

	public void Add(PropertyType item)
	{
		list_0.Add(item);
	}

	public int IndexOf(PropertyType item)
	{
		return list_0.IndexOf(item);
	}

	public void Insert(int index, PropertyType item)
	{
		list_0.Insert(index, item);
	}

	public void CopyTo(PropertyType[] array, int arrayIndex)
	{
		list_0.CopyTo(array, arrayIndex);
	}

	public bool Remove(PropertyType item)
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

	public bool Contains(PropertyType item)
	{
		return list_0.Contains(item);
	}

	IEnumerator<PropertyType> IEnumerable<PropertyType>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
