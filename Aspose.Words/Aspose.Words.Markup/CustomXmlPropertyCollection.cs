using System;
using System.Collections;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Markup;

[JavaGenericArguments("Iterable<CustomXmlProperty>")]
public class CustomXmlPropertyCollection : IEnumerable
{
	private readonly xd345c73dd1b16b74 x82b70567a5f68f41 = new xd345c73dd1b16b74();

	public int Count => x82b70567a5f68f41.Count;

	public CustomXmlProperty this[string name] => (CustomXmlProperty)x82b70567a5f68f41[name];

	public CustomXmlProperty this[int index] => (CustomXmlProperty)x82b70567a5f68f41.GetByIndex(index);

	internal CustomXmlPropertyCollection()
	{
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetValueList().GetEnumerator();
	}

	public void Add(CustomXmlProperty property)
	{
		x82b70567a5f68f41.Add(property.Name, property);
	}

	internal void x1cd8943d02c5342f(CustomXmlProperty x46710263f0fedd95)
	{
		x82b70567a5f68f41[x46710263f0fedd95.Name] = x46710263f0fedd95;
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

	internal CustomXmlPropertyCollection x8b61531c8ea35b85()
	{
		CustomXmlPropertyCollection customXmlPropertyCollection = new CustomXmlPropertyCollection();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CustomXmlProperty customXmlProperty = (CustomXmlProperty)enumerator.Current;
				customXmlPropertyCollection.Add(customXmlProperty.x8b61531c8ea35b85());
			}
			return customXmlPropertyCollection;
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
