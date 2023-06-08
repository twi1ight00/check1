using System;
using System.Collections;

namespace Aspose.Words.Markup;

[JavaGenericArguments("Iterable<CustomXmlPart>")]
public class CustomXmlPartCollection : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	public int Count => x82b70567a5f68f41.Count;

	public CustomXmlPart this[int index]
	{
		get
		{
			return (CustomXmlPart)x82b70567a5f68f41[index];
		}
		set
		{
			x82b70567a5f68f41[index] = value;
		}
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	public void Add(CustomXmlPart part)
	{
		x82b70567a5f68f41.Add(part);
	}

	public void RemoveAt(int index)
	{
		x82b70567a5f68f41.RemoveAt(index);
	}

	public void Clear()
	{
		x82b70567a5f68f41.Clear();
	}

	public CustomXmlPart GetById(string id)
	{
		foreach (CustomXmlPart item in x82b70567a5f68f41)
		{
			if (item.Id == id)
			{
				return item;
			}
		}
		return null;
	}

	public CustomXmlPartCollection Clone()
	{
		CustomXmlPartCollection customXmlPartCollection = new CustomXmlPartCollection();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CustomXmlPart customXmlPart = (CustomXmlPart)enumerator.Current;
				customXmlPartCollection.Add(customXmlPart.Clone());
			}
			return customXmlPartCollection;
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
