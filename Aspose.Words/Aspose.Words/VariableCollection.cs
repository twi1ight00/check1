using System;
using System.Collections;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

[JavaGenericArguments("Iterable<Map.Entry>")]
public class VariableCollection : IEnumerable
{
	private readonly xd345c73dd1b16b74 x82b70567a5f68f41 = new xd345c73dd1b16b74(isCaseSensitive: false);

	public int Count => x82b70567a5f68f41.Count;

	public string this[string name]
	{
		get
		{
			x0d299f323d241756.x48501aec8e48c869(name, "name");
			return (string)x82b70567a5f68f41[name];
		}
		set
		{
			x0d299f323d241756.x48501aec8e48c869(name, "name");
			x82b70567a5f68f41[name] = (x0d299f323d241756.x5959bccb67bbf051(value) ? value : "");
		}
	}

	public string this[int index]
	{
		get
		{
			return (string)x82b70567a5f68f41.GetByIndex(index);
		}
		set
		{
			x82b70567a5f68f41.SetByIndex(index, x0d299f323d241756.x5959bccb67bbf051(value) ? value : "");
		}
	}

	internal VariableCollection()
	{
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	public void Add(string name, string value)
	{
		x82b70567a5f68f41[name] = (x0d299f323d241756.x5959bccb67bbf051(value) ? value : "");
	}

	public bool Contains(string name)
	{
		return x82b70567a5f68f41.Contains(name);
	}

	public int IndexOfKey(string name)
	{
		return x82b70567a5f68f41.IndexOfKey(name);
	}

	public void Remove(string name)
	{
		x82b70567a5f68f41.Remove(name);
	}

	public void RemoveAt(int index)
	{
		x82b70567a5f68f41.RemoveAt(index);
	}

	public void Clear()
	{
		x82b70567a5f68f41.Clear();
	}

	internal VariableCollection x8b61531c8ea35b85()
	{
		VariableCollection variableCollection = new VariableCollection();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				variableCollection.Add((string)dictionaryEntry.Key, (string)dictionaryEntry.Value);
			}
			return variableCollection;
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}
}
