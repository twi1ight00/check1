using System;
using System.Collections;
using System.Collections.Generic;
using ns53;

namespace ns19;

internal sealed class Class249 : ICollection, IEnumerable, IEnumerable<Class248>
{
	private SortedList<string, Class248> sortedList_0 = new SortedList<string, Class248>();

	public int Count => sortedList_0.Count;

	public Class248 this[string partPath]
	{
		get
		{
			if (sortedList_0.ContainsKey(partPath))
			{
				return sortedList_0[partPath];
			}
			return null;
		}
	}

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public void Add(string partPath, byte[] partData, string contentType, string typeAttributeOfSourceRelationship, Class1348 partRelationships)
	{
		if (!sortedList_0.ContainsKey(partPath))
		{
			sortedList_0.Add(partPath, new Class248(partPath, partData, contentType, typeAttributeOfSourceRelationship, partRelationships));
		}
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)sortedList_0).CopyTo(array, index);
	}

	IEnumerator<Class248> IEnumerable<Class248>.GetEnumerator()
	{
		return sortedList_0.Values.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return sortedList_0.Values.GetEnumerator();
	}
}
