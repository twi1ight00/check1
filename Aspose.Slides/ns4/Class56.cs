using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides;

namespace ns4;

internal class Class56 : ICollection, IEnumerable, IEnumerable<IGradientStopEffectiveData>, IGradientStopCollectionEffectiveData, IEffectiveData
{
	private List<IGradientStopEffectiveData> list_0;

	public int Count => list_0.Count;

	public IGradientStopEffectiveData this[int index] => list_0[index];

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	ICollection IGradientStopCollectionEffectiveData.AsICollection => this;

	IEnumerable IGradientStopCollectionEffectiveData.AsIEnumerable => this;

	internal Class56()
	{
		list_0 = new List<IGradientStopEffectiveData>();
	}

	internal void Add(float position, Class21.Delegate2 colorResolver)
	{
		Class57 item = new Class57(position, colorResolver);
		list_0.Add(item);
	}

	internal void method_0(Class57 source)
	{
		Class57 item = new Class57(source);
		list_0.Add(item);
	}

	internal void Clear()
	{
		list_0.Clear();
	}

	IEnumerator<IGradientStopEffectiveData> IEnumerable<IGradientStopEffectiveData>.GetEnumerator()
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
