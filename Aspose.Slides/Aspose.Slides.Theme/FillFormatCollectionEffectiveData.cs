using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides.Theme;

public class FillFormatCollectionEffectiveData : ICollection, IEnumerable<IFillFormatEffectiveData>, IEnumerable, IFillFormatCollectionEffectiveData, IEffectiveData
{
	internal List<IFillFormatEffectiveData> list_0 = new List<IFillFormatEffectiveData>();

	public int Count => list_0.Count;

	public IFillFormatEffectiveData this[int index] => list_0[index];

	IEnumerable IFillFormatCollectionEffectiveData.AsIEnumerable => this;

	ICollection IFillFormatCollectionEffectiveData.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal FillFormatCollectionEffectiveData()
	{
	}

	internal void method_0(IFillFormatCollection source, BaseSlide slide, FloatColor styleColor)
	{
		FillFormatCollection fillFormatCollection = (FillFormatCollection)source;
		list_0.Clear();
		foreach (IFillFormat item in fillFormatCollection.list_0)
		{
			FillFormatEffectiveData fillFormatEffectiveData = new FillFormatEffectiveData();
			fillFormatEffectiveData.method_0(item, slide, styleColor);
			list_0.Add(fillFormatEffectiveData);
		}
	}

	IEnumerator<IFillFormatEffectiveData> IEnumerable<IFillFormatEffectiveData>.GetEnumerator()
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
