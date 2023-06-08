using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides;

public class LayoutSlideCollection : IEnumerable<ILayoutSlide>, ICollection, IEnumerable, ILayoutSlideCollection
{
	internal List<ILayoutSlide> list_0;

	internal object object_0;

	public int Count => list_0.Count;

	public ILayoutSlide this[int index] => list_0[index];

	internal Presentation PresentationInternal
	{
		get
		{
			if (object_0 is MasterSlide)
			{
				return ((MasterSlide)object_0).PresentationInternal;
			}
			return (Presentation)object_0;
		}
	}

	ICollection ILayoutSlideCollection.AsICollection => this;

	IEnumerable ILayoutSlideCollection.AsIEnumerable => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal LayoutSlideCollection(object parent)
	{
		list_0 = new List<ILayoutSlide>();
		object_0 = parent;
	}

	public ILayoutSlide GetByType(SlideLayoutType type)
	{
		int count = list_0.Count;
		int num = 0;
		while (true)
		{
			if (num < count)
			{
				if (this[num].LayoutType == type)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return this[num];
	}

	internal LayoutSlide method_0(uint id)
	{
		foreach (LayoutSlide item in list_0)
		{
			if (item.PPTXUnsupportedProps.SlideId == id)
			{
				return item;
			}
		}
		return null;
	}

	internal void Add(ILayoutSlide value)
	{
		list_0.Add(value);
	}

	internal void Insert(int index, ILayoutSlide value)
	{
		list_0.Insert(index, value);
	}

	public void Remove(ILayoutSlide value)
	{
		if (list_0.Contains(value))
		{
			value.Remove();
		}
	}

	public void RemoveUnused()
	{
		lock (((ICollection)list_0).SyncRoot)
		{
			int num = 0;
			while (num < list_0.Count)
			{
				ILayoutSlide layoutSlide = list_0[num];
				if (layoutSlide.HasDependingSlides)
				{
					num++;
				}
				else
				{
					layoutSlide.Remove();
				}
			}
		}
	}

	IEnumerator<ILayoutSlide> IEnumerable<ILayoutSlide>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}
}
