using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Aspose.Slides;

public class GradientStopCollectionEffectiveData : ICollection, IEnumerable, IEnumerable<IGradientStopEffectiveData>, IGradientStopCollectionEffectiveData, IEffectiveData
{
	private SortedList<float, IGradientStopEffectiveData> sortedList_0;

	public int Count => sortedList_0.Count;

	public IGradientStopEffectiveData this[int index] => sortedList_0.Values[index];

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	ICollection IGradientStopCollectionEffectiveData.AsICollection => this;

	IEnumerable IGradientStopCollectionEffectiveData.AsIEnumerable => this;

	internal GradientStopCollectionEffectiveData()
	{
		sortedList_0 = new SortedList<float, IGradientStopEffectiveData>();
	}

	internal void Add(float position, Color color)
	{
		sortedList_0[position] = new GradientStopEffectiveData(position, color);
	}

	internal void Clear()
	{
		sortedList_0.Clear();
	}

	IEnumerator<IGradientStopEffectiveData> IEnumerable<IGradientStopEffectiveData>.GetEnumerator()
	{
		return sortedList_0.Values.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return sortedList_0.Values.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)sortedList_0).CopyTo(array, index);
	}
}
