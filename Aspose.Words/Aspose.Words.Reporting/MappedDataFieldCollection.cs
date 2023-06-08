using System.Collections;

namespace Aspose.Words.Reporting;

[JavaGenericArguments("Iterable<String>")]
public class MappedDataFieldCollection : IEnumerable
{
	private readonly Hashtable x82b70567a5f68f41 = new Hashtable();

	public int Count => x82b70567a5f68f41.Count;

	public string this[string documentFieldName]
	{
		get
		{
			return (string)x82b70567a5f68f41[documentFieldName];
		}
		set
		{
			x82b70567a5f68f41[documentFieldName] = value;
		}
	}

	internal MappedDataFieldCollection()
	{
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	public void Add(string documentFieldName, string dataSourceFieldName)
	{
		x82b70567a5f68f41.Add(documentFieldName, dataSourceFieldName);
	}

	public bool ContainsKey(string documentFieldName)
	{
		return x82b70567a5f68f41.ContainsKey(documentFieldName);
	}

	public bool ContainsValue(string dataSourceFieldName)
	{
		return x82b70567a5f68f41.ContainsValue(dataSourceFieldName);
	}

	public void Remove(string documentFieldName)
	{
		x82b70567a5f68f41.Remove(documentFieldName);
	}

	public void Clear()
	{
		x82b70567a5f68f41.Clear();
	}
}
