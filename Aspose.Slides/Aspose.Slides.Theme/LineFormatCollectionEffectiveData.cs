using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides.Theme;

public class LineFormatCollectionEffectiveData : ICollection, IEnumerable, IEnumerable<ILineFormatEffectiveData>, ILineFormatCollectionEffectiveData, IEffectiveData
{
	internal List<ILineFormatEffectiveData> list_0 = new List<ILineFormatEffectiveData>();

	public int Count => list_0.Count;

	public ILineFormatEffectiveData this[int index] => list_0[index];

	IEnumerable ILineFormatCollectionEffectiveData.AsIEnumerable => this;

	ICollection ILineFormatCollectionEffectiveData.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal LineFormatCollectionEffectiveData()
	{
	}

	internal void method_0(ILineFormatCollection source, BaseSlide slide, FloatColor styleColor)
	{
		LineFormatCollection lineFormatCollection = (LineFormatCollection)source;
		list_0.Clear();
		foreach (LineFormat item in lineFormatCollection.list_0)
		{
			LineFormatEffectiveData lineFormatEffectiveData = new LineFormatEffectiveData();
			lineFormatEffectiveData.method_0(item, slide, styleColor);
			list_0.Add(lineFormatEffectiveData);
		}
	}

	IEnumerator<ILineFormatEffectiveData> IEnumerable<ILineFormatEffectiveData>.GetEnumerator()
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
