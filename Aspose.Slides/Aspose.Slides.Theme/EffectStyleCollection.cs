using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides.Theme;

public sealed class EffectStyleCollection : IEnumerable<IEffectStyle>, ICollection, IEnumerable, IEffectStyleCollection
{
	internal List<IEffectStyle> list_0 = new List<IEffectStyle>();

	private FormatScheme formatScheme_0;

	private uint uint_0;

	public int Count => list_0.Count;

	public IEffectStyle this[int index] => list_0[index];

	internal uint Version
	{
		get
		{
			uint num = uint_0;
			foreach (EffectStyle item in list_0)
			{
				num += item.Version;
			}
			return num;
		}
	}

	IEnumerable IEffectStyleCollection.AsIEnumerable => this;

	ICollection IEffectStyleCollection.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal IEffectStyle Add()
	{
		EffectStyle effectStyle = new EffectStyle();
		list_0.Add(effectStyle);
		method_1();
		return effectStyle;
	}

	internal EffectStyleCollection(FormatScheme parent)
	{
		formatScheme_0 = parent;
	}

	internal void method_0(EffectStyleCollection effectStyleCollection)
	{
		uint_0 = Version;
		method_1();
		list_0.Clear();
		foreach (EffectStyle item in effectStyleCollection.list_0)
		{
			EffectStyle effectStyle2 = new EffectStyle();
			list_0.Add(effectStyle2);
			effectStyle2.method_0(item);
		}
	}

	private void method_1()
	{
		uint_0++;
	}

	IEnumerator<IEffectStyle> IEnumerable<IEffectStyle>.GetEnumerator()
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
