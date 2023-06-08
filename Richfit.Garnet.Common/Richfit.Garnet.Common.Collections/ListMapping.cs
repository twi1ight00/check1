using System;
using System.Collections;
using System.Collections.Generic;

namespace Richfit.Garnet.Common.Collections;

/// <summary>
/// 键和List对象值相匹配的泛型集合
/// </summary>
/// <typeparam name="T1">主键值</typeparam>
/// <typeparam name="T2">List中包含的元素类型</typeparam>
public class ListMapping<T1, T2> : IDictionary<T1, List<T2>>, ICollection<KeyValuePair<T1, List<T2>>>, IEnumerable<KeyValuePair<T1, List<T2>>>, IEnumerable
{
	/// <summary>
	/// Container holding the data
	/// </summary>
	protected virtual Dictionary<T1, List<T2>> Items { get; set; }

	/// <summary>
	/// List that contains the list of values
	/// </summary>
	public ICollection<List<T2>> Values
	{
		get
		{
			List<List<T2>> lists = new List<List<T2>>();
			foreach (T1 key in Keys)
			{
				lists.Add(this[key]);
			}
			return lists;
		}
	}

	/// <summary>
	/// The number of items in the listing
	/// </summary>
	public virtual int Count => Items.Count;

	/// <summary>
	/// Gets a list of values associated with a key
	/// </summary>
	/// <param name="key">Key to look for</param>
	/// <returns>The list of values</returns>
	public virtual List<T2> this[T1 key]
	{
		get
		{
			return Items[key];
		}
		set
		{
			Items[key] = value;
		}
	}

	/// <summary>
	/// The list of keys within the mapping
	/// </summary>
	public virtual ICollection<T1> Keys => Items.Keys;

	/// <summary>
	/// Not read only
	/// </summary>
	public bool IsReadOnly => false;

	/// <summary>
	/// Constructor
	/// </summary>
	public ListMapping()
	{
		Items = new Dictionary<T1, List<T2>>();
	}

	/// <summary>
	/// Adds an item to the mapping
	/// </summary>
	/// <param name="key">Key value</param>
	/// <param name="value">The value to add</param>
	public virtual void Add(T1 key, T2 value)
	{
		if (!Items.ContainsKey(key))
		{
			List<T2> temp = new List<T2>();
			Items.Add(key, temp);
		}
		Items[key].Add(value);
	}

	/// <summary>
	/// Adds an item to the mapping，the Value is Unique
	/// </summary>
	/// <param name="key">Key value</param>
	/// <param name="value">The value to add</param>
	public virtual void AddUniqueValue(T1 key, T2 value)
	{
		if (!Items.ContainsKey(key))
		{
			List<T2> temp = new List<T2>();
			Items.Add(key, temp);
		}
		if (!Items[key].Contains(value))
		{
			Items[key].Add(value);
		}
	}

	/// <summary>
	/// Adds a key value pair
	/// </summary>
	/// <param name="item">Key value pair to add</param>
	public virtual void Add(KeyValuePair<T1, List<T2>> item)
	{
		Add(item.Key, item.Value);
	}

	/// <summary>
	/// Adds a list of items to the mapping
	/// </summary>
	/// <param name="key">Key value</param>
	/// <param name="value">The values to add</param>
	public virtual void Add(T1 key, List<T2> value)
	{
		if (!Items.ContainsKey(key))
		{
			List<T2> temp = new List<T2>();
			Items.Add(key, temp);
		}
		Items[key].AddRange(value);
	}

	/// <summary>
	/// Determines if a key exists
	/// </summary>
	/// <param name="key">Key to check on</param>
	/// <returns>True if it exists, false otherwise</returns>
	public virtual bool ContainsKey(T1 key)
	{
		return Items.ContainsKey(key);
	}

	/// <summary>
	/// Remove a list of items associated with a key
	/// </summary>
	/// <param name="key">Key to use</param>
	/// <returns>True if the key is found, false otherwise</returns>
	public virtual bool Remove(T1 key)
	{
		return Items.Remove(key);
	}

	/// <summary>
	/// Removes a key value pair from the list mapping
	/// </summary>
	/// <param name="item">items to remove</param>
	/// <returns>True if it is removed, false otherwise</returns>
	public virtual bool Remove(KeyValuePair<T1, List<T2>> item)
	{
		if (!Contains(item))
		{
			return false;
		}
		foreach (T2 value in item.Value)
		{
			if (!Remove(item.Key, value))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// Removes a key value pair from the list mapping
	/// </summary>
	/// <param name="key">Key to remove</param>
	/// <param name="value">Value to remove</param>
	/// <returns>True if it is removed, false otherwise</returns>
	public virtual bool Remove(T1 key, T2 value)
	{
		if (!Contains(key, value))
		{
			return false;
		}
		this[key].Remove(value);
		if (this[key].Count == 0)
		{
			Remove(key);
		}
		return true;
	}

	/// <summary>
	/// Clears all items from the listing
	/// </summary>
	public virtual void Clear()
	{
		Items.Clear();
	}

	/// <summary>
	/// Tries to get the value associated with the key
	/// </summary>
	/// <param name="key">Key value</param>
	/// <param name="value">The values getting</param>
	/// <returns>True if it was able to get the value, false otherwise</returns>
	public virtual bool TryGetValue(T1 key, out List<T2> value)
	{
		if (ContainsKey(key))
		{
			value = this[key];
			return true;
		}
		value = new List<T2>();
		return false;
	}

	/// <summary>
	/// Does this contain the key value pairs?
	/// </summary>
	/// <param name="item">Key value pair to check</param>
	/// <returns>True if it exists, false otherwise</returns>
	public virtual bool Contains(KeyValuePair<T1, List<T2>> item)
	{
		if (!ContainsKey(item.Key))
		{
			return false;
		}
		if (!Contains(item.Key, item.Value))
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// Does the list mapping contain the key value pairs?
	/// </summary>
	/// <param name="key">Key value</param>
	/// <param name="values">Value</param>
	/// <returns>True if it exists, false otherwise</returns>
	public virtual bool Contains(T1 key, List<T2> values)
	{
		if (!ContainsKey(key))
		{
			return false;
		}
		foreach (T2 value in values)
		{
			if (!Contains(key, value))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// Does the list mapping contain the key value pair?
	/// </summary>
	/// <param name="key">Key</param>
	/// <param name="value">Value</param>
	/// <returns>True if it exists, false otherwise</returns>
	public bool Contains(T1 key, T2 value)
	{
		if (!ContainsKey(key))
		{
			return false;
		}
		if (!this[key].Contains(value))
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// Not implemented
	/// </summary>
	/// <param name="array">Array to copy to</param>
	/// <param name="arrayIndex">array index</param>
	public void CopyTo(KeyValuePair<T1, List<T2>>[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Gets the enumerator
	/// </summary>
	/// <returns>The enumerator for this object</returns>
	public IEnumerator<KeyValuePair<T1, List<T2>>> GetEnumerator()
	{
		foreach (T1 key in Keys)
		{
			yield return new KeyValuePair<T1, List<T2>>(key, this[key]);
		}
	}

	/// <summary>
	/// Gets the enumerator
	/// </summary>
	/// <returns>The enumerator for this object</returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		foreach (T1 key in Keys)
		{
			yield return this[key];
		}
	}
}
