using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface ICollection<T> : IExtensible<T>, ICollectionValue<T>, IShowable, IFormattable, ICloneable, System.Collections.Generic.ICollection<T>, IEnumerable<T>, IEnumerable
{
	[ComVisible(true)]
	Speed ContainsSpeed
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	new int Count
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	new bool IsReadOnly
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	new bool Add(T item);

	[ComVisible(true)]
	new void CopyTo(T[] array, int index);

	[ComVisible(true)]
	int GetUnsequencedHashCode();

	[ComVisible(true)]
	bool UnsequencedEquals(ICollection<T> otherCollection);

	[ComVisible(true)]
	new bool Contains(T item);

	[ComVisible(true)]
	int ContainsCount(T item);

	[ComVisible(true)]
	ICollectionValue<T> UniqueItems();

	[ComVisible(true)]
	ICollectionValue<KeyValuePair<T, int>> ItemMultiplicities();

	[ComVisible(true)]
	bool ContainsAll<U>(IEnumerable<U> items) where U : T;

	[ComVisible(true)]
	bool Find(ref T item);

	[ComVisible(true)]
	bool FindOrAdd(ref T item);

	[ComVisible(true)]
	bool Update(T item);

	[ComVisible(true)]
	bool Update(T item, out T olditem);

	[ComVisible(true)]
	bool UpdateOrAdd(T item);

	[ComVisible(true)]
	bool UpdateOrAdd(T item, out T olditem);

	[ComVisible(true)]
	new bool Remove(T item);

	[ComVisible(true)]
	bool Remove(T item, out T removeditem);

	[ComVisible(true)]
	void RemoveAllCopies(T item);

	[ComVisible(true)]
	void RemoveAll<U>(IEnumerable<U> items) where U : T;

	[ComVisible(true)]
	new void Clear();

	[ComVisible(true)]
	void RetainAll<U>(IEnumerable<U> items) where U : T;
}
