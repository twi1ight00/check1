using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("CA8BBB80-8368-4298-BBE5-BC930DD2FAFF")]
[ClassInterface(ClassInterfaceType.None)]
public class FontSubstRuleCollection : IEnumerable<IFontSubstRule>, ICollection, IEnumerable, IFontSubstRuleCollection
{
	private readonly List<IFontSubstRule> list_0 = new List<IFontSubstRule>();

	public int Count => list_0.Count;

	public IFontSubstRule this[int index] => list_0[index];

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	ICollection IFontSubstRuleCollection.AsICollection => this;

	IEnumerable IFontSubstRuleCollection.AsIEnumerable => this;

	public void Add(IFontSubstRule value)
	{
		list_0.Add(value);
	}

	public void Remove(IFontSubstRule value)
	{
		if (list_0.Contains(value))
		{
			list_0.Remove(value);
		}
	}

	IEnumerator<IFontSubstRule> IEnumerable<IFontSubstRule>.GetEnumerator()
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
