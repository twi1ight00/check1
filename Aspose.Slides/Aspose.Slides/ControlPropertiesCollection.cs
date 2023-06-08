using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides;

public class ControlPropertiesCollection : IEnumerable, IEnumerable<KeyValuePair<string, string>>, IControlPropertiesCollection
{
	internal Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	public string this[string name]
	{
		get
		{
			dictionary_0.TryGetValue(name, out var value);
			return value;
		}
		set
		{
			dictionary_0[name] = value;
		}
	}

	public ICollection NamesOfProperties => dictionary_0.Keys;

	IEnumerable IControlPropertiesCollection.AsIEnumerable => this;

	public int Count => dictionary_0.Count;

	internal ControlPropertiesCollection()
	{
	}

	public void Add(string name, string value)
	{
		dictionary_0.Add(name, value);
	}

	public void Remove(string name)
	{
		dictionary_0.Remove(name);
	}

	public void Clear()
	{
		dictionary_0.Clear();
	}

	IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
	{
		return dictionary_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return dictionary_0.GetEnumerator();
	}
}
