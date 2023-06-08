using System;
using System.Collections;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Markup;

[JavaGenericArguments("Iterable<String>")]
public class CustomXmlSchemaCollection : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	public int Count => x82b70567a5f68f41.Count;

	public string this[int index]
	{
		get
		{
			return (string)x82b70567a5f68f41[index];
		}
		set
		{
			x82b70567a5f68f41[index] = value;
		}
	}

	internal CustomXmlSchemaCollection()
	{
	}

	[JavaGenericArguments("Iterator<String>")]
	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	public void Add(string value)
	{
		x0d299f323d241756.x0aaaea7864a53f26(value, "value");
		x82b70567a5f68f41.Add(value);
	}

	public int IndexOf(string value)
	{
		return x82b70567a5f68f41.IndexOf(value);
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

	public CustomXmlSchemaCollection Clone()
	{
		CustomXmlSchemaCollection customXmlSchemaCollection = new CustomXmlSchemaCollection();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string value = (string)enumerator.Current;
				customXmlSchemaCollection.Add(value);
			}
			return customXmlSchemaCollection;
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
