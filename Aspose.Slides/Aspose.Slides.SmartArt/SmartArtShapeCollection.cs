using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides.SmartArt;

public class SmartArtShapeCollection : IEnumerable<ISmartArtShape>, ICollection, IEnumerable, ISmartArtShapeCollection
{
	private List<ISmartArtShape> list_0;

	public int Count => list_0.Count;

	public ISmartArtShape this[int index] => list_0[index];

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	ICollection ISmartArtShapeCollection.AsICollection => this;

	IEnumerable ISmartArtShapeCollection.AsIEnumerable => this;

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}

	IEnumerator<ISmartArtShape> IEnumerable<ISmartArtShape>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	internal SmartArtShapeCollection()
	{
		list_0 = new List<ISmartArtShape>();
	}

	internal void Add(ISmartArtShape shape)
	{
		list_0.Add(shape);
	}
}
