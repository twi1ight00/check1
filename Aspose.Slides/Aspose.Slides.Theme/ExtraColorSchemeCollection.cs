using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides.Theme;

public class ExtraColorSchemeCollection : IEnumerable<IExtraColorScheme>, ICollection, IEnumerable, IExtraColorSchemeCollection
{
	private readonly List<IExtraColorScheme> list_0 = new List<IExtraColorScheme>();

	private uint uint_0;

	public int Count => list_0.Count;

	public IExtraColorScheme this[int index] => list_0[index];

	internal uint Version
	{
		get
		{
			uint num = uint_0;
			foreach (ExtraColorScheme item in list_0)
			{
				num += item.Version;
			}
			return num;
		}
	}

	IEnumerable IExtraColorSchemeCollection.AsIEnumerable => this;

	ICollection IExtraColorSchemeCollection.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal ExtraColorSchemeCollection()
	{
	}

	internal IExtraColorScheme Add(IPresentationComponent parent)
	{
		ExtraColorScheme extraColorScheme = new ExtraColorScheme(parent);
		list_0.Add(extraColorScheme);
		method_0();
		return extraColorScheme;
	}

	internal void Add(ExtraColorScheme item)
	{
		list_0.Add(item);
		method_0();
	}

	internal void Insert(int index, ExtraColorScheme item)
	{
		list_0.Insert(index, item);
		method_0();
	}

	internal void Remove(ExtraColorScheme item)
	{
		uint_0 = Version;
		method_0();
		list_0.Remove(item);
	}

	internal void RemoveAt(int index)
	{
		uint_0 = Version;
		method_0();
		list_0.RemoveAt(index);
	}

	internal void Clear()
	{
		uint_0 = Version;
		method_0();
		list_0.Clear();
	}

	private void method_0()
	{
		uint_0++;
	}

	IEnumerator<IExtraColorScheme> IEnumerable<IExtraColorScheme>.GetEnumerator()
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
