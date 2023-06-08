using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides.Theme;

public class EffectStyleCollectionEffectiveData : IEnumerable<IEffectStyleEffectiveData>, ICollection, IEnumerable, IEffectStyleCollectionEffectiveData, IEffectiveData
{
	internal List<IEffectStyleEffectiveData> list_0 = new List<IEffectStyleEffectiveData>();

	public int Count => list_0.Count;

	public IEffectStyleEffectiveData this[int index] => list_0[index];

	IEnumerable IEffectStyleCollectionEffectiveData.AsIEnumerable => this;

	ICollection IEffectStyleCollectionEffectiveData.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal EffectStyleCollectionEffectiveData()
	{
	}

	internal void method_0(IEffectStyleCollection source, BaseSlide slide, FloatColor styleColor)
	{
		EffectStyleCollection effectStyleCollection = (EffectStyleCollection)source;
		list_0.Clear();
		foreach (IEffectStyle item in effectStyleCollection.list_0)
		{
			EffectStyleEffectiveData effectStyleEffectiveData = new EffectStyleEffectiveData();
			effectStyleEffectiveData.method_0(item, slide, styleColor);
			list_0.Add(effectStyleEffectiveData);
		}
	}

	IEnumerator<IEffectStyleEffectiveData> IEnumerable<IEffectStyleEffectiveData>.GetEnumerator()
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
