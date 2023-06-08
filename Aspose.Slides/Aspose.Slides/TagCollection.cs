using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides;

public sealed class TagCollection : ICollection, IEnumerable, IEnumerable<KeyValuePair<string, string>>, ITagCollection
{
	private readonly SortedList<string, string> sortedList_0 = new SortedList<string, string>();

	internal SortedList<string, string> Items => sortedList_0;

	public int Count => Items.Count;

	public string this[string name]
	{
		get
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			name = name.ToUpper();
			Items.TryGetValue(name, out var value);
			return value;
		}
		set
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			name = name.ToUpper();
			Items[name] = value;
		}
	}

	ICollection ITagCollection.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	IEnumerable ITagCollection.AsIEnumerable => this;

	internal TagCollection()
	{
	}

	public int Add(string name, string value)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		name = name.ToUpper();
		if (Items.ContainsKey(name))
		{
			Items[name] = value;
		}
		else
		{
			Items.Add(name, value);
		}
		return Items.IndexOfKey(name);
	}

	public void Remove(string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		name = name.ToUpper();
		Items.Remove(name);
	}

	public int IndexOfName(string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		name = name.ToUpper();
		return Items.IndexOfKey(name);
	}

	public bool Contains(string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		name = name.ToUpper();
		return Items.ContainsKey(name);
	}

	public void RemoveAt(int index)
	{
		Items.RemoveAt(index);
	}

	public void Clear()
	{
		Items.Clear();
	}

	public string GetValueByIndex(int index)
	{
		return Items.Values[index];
	}

	public string GetNameByIndex(int index)
	{
		return Items.Keys[index];
	}

	public string[] GetNamesOfTags()
	{
		string[] array = new string[Items.Keys.Count];
		Items.Keys.CopyTo(array, 0);
		return array;
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)Items).CopyTo(array, index);
	}

	IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
	{
		return Items.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return Items.GetEnumerator();
	}
}
