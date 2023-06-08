using System.Collections;
using System.Collections.Generic;

namespace SolrNet.Impl;

/// <summary>
/// Highlighted snippets by field
/// </summary>
public class HighlightedSnippets : IDictionary<string, ICollection<string>>, ICollection<KeyValuePair<string, ICollection<string>>>, IEnumerable<KeyValuePair<string, ICollection<string>>>, IEnumerable
{
	private readonly IDictionary<string, ICollection<string>> fields = new Dictionary<string, ICollection<string>>();

	/// <summary>
	/// Highlighted snippets by field
	/// </summary>
	public IDictionary<string, ICollection<string>> Snippets => fields;

	public int Count => fields.Count;

	public bool IsReadOnly => fields.IsReadOnly;

	public ICollection<string> this[string key]
	{
		get
		{
			return fields[key];
		}
		set
		{
			fields[key] = value;
		}
	}

	public ICollection<string> Keys => fields.Keys;

	public ICollection<ICollection<string>> Values => fields.Values;

	public IEnumerator<KeyValuePair<string, ICollection<string>>> GetEnumerator()
	{
		return fields.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(KeyValuePair<string, ICollection<string>> item)
	{
		fields.Add(item);
	}

	public void Clear()
	{
		fields.Clear();
	}

	public bool Contains(KeyValuePair<string, ICollection<string>> item)
	{
		return fields.Contains(item);
	}

	public void CopyTo(KeyValuePair<string, ICollection<string>>[] array, int arrayIndex)
	{
		fields.CopyTo(array, arrayIndex);
	}

	public bool Remove(KeyValuePair<string, ICollection<string>> item)
	{
		return fields.Remove(item);
	}

	public bool ContainsKey(string key)
	{
		return fields.ContainsKey(key);
	}

	public void Add(string key, ICollection<string> value)
	{
		fields.Add(key, value);
	}

	public bool Remove(string key)
	{
		return fields.Remove(key);
	}

	public bool TryGetValue(string key, out ICollection<string> value)
	{
		return fields.TryGetValue(key, out value);
	}
}
